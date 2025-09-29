using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 選択ガイド
    /// </summary>
    /// <remarks>
    /// <br>本クラスはinternalで宣言されている為、外部アセンブリからは直接参照できない。</br>
    /// <br>外部アセンブリから本クラスにアクセスする場合は、操作クラスにインターフェース</br>
    /// <br>となるメソッドやプロパティを作成する事</br>
    /// <br>Update Note: 2013/02/06 donggy </br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信</br>
    /// <br>           : Redmine#33919の対応</br>
    /// <br>Update Note: 2016/01/13 田建委</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : ①初期表示した時、初期フォーカスを名称絞込に初期区分を曖昧にする変更</br>
    /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、フォーカスを名称絞込に初期区分を曖昧にする変更</br>
    /// <br>Update Note: 2016/02/03 田建委</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : ①初期表示した時、「自動検索」をチェックオンにする変更</br>
    /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、「自動検索」をチェックオンにする変更</br>
    /// <br>Update Note: 2016/02/17  田建委</br>
    /// <br>           : 11200090-00 Redmine#48587</br>
    /// <br>           : ①名称絞込みの初期入力モードを「半角カナ」にする変更</br>
    /// <br>           : ②アローキー、enter、tabのフォーカス遷移の対応</br>
    /// <br>Update Note: 2016/12/26 譚洪</br>
    /// <br>管理番号   : 11270116-00 売上伝票入力パッケージ出荷用ソースのマージ</br>
    /// <br>             Designer.csの修正</br>
    /// </remarks>
    internal partial class SelectionForm2 : Form
    {
        # region 変数定義
        private BlInfo.BL1DataTable _blInfoTable = null;

        private BlInfo.BLDataTable _dt;
        /// <summary>ガイド用リスト</summary>
        private ArrayList lstGuide = null;
        /// <summary>拠点コード（BLコードガイド表示用）</summary>
        private string _sectionCd;

        /// <summary>現在表示中ページの先頭位置</summary>
        private int curPos = 0;
        /// <summary>全体BLカウント</summary>
        private int cnt;
        private bool flipflopFlg = false;
        private bool isUserClose;
        private bool guideOn = false;

        private RetType retType;

        private const int ct_CntPerPage = 54;
        private const int ct_CntPerColumn = 18;
        private bool flgPgTxt = false;
        private int time_count;//ADD 2016/02/17 田建委 Redmine#48587
        # endregion

        #region [ コンストラクタ ]
        /// <summary>
        /// 選択画面コンストラクタ
        /// </summary>
        /// <param name="myOwner"></param>
        /// <param name="dt">グリッドに表示するデータを指定します。</param>
        /// <param name="sectionCd"></param>
        public SelectionForm2(Form myOwner, BlInfo.BLDataTable dt, string sectionCd)
        {
            InitializeComponent();
            // DataTable の設定
            Owner = myOwner;
            _dt = new BlInfo.BLDataTable();
            _dt.Merge(dt);
            _dt.DefaultView.RowFilter = string.Empty;
            _sectionCd = sectionCd;

            InitializeForm();
            _blInfoTable = new BlInfo.BL1DataTable();
            ((StateButtonTool)ToolbarsManager.Tools["Btn_ByCode"]).Checked = true; // コード順でBLコード表示
            //InitializeData();
            flipflopFlg = true;
            ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = true;
            flipflopFlg = false;
        }
        #endregion

        #region [ 初期処理 ]
        private void InitializeForm()
        {
            // ステータスバーの初期化
            StatusBar.Panels[0].Text = "";

            // ツールバーのイメージ(16x16)やメッセージを設定する
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_All"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            ToolbarsManager.Tools["Button_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PARTSSELECT;
            ToolbarsManager.Tools["Button_Pos"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.LABEL;
            ToolbarsManager.Tools["Button_Guide"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            ToolbarsManager.Tools["Btn_PrevPg"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE2;
            ToolbarsManager.Tools["Btn_NextPg"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEXT2;
            if (((SelectionForm)Owner)._orgBlInfoTable.Count == 0)
            {
                //ToolbarsManager.Tools["Button_All"].SharedProps.Visible = false;
                ToolbarsManager.Tools["Button_Search"].SharedProps.Visible = false;
            }

        }

        /// <summary>
        /// 表示用データをDataTableに登録するためのサブスレッド
        /// </summary>
        private void InitializeData()
        {
            _blInfoTable.Clear();
            _blInfoTable.BeginLoadData();
            try
            {
                if (guideOn) // BLコードガイド表示の場合のデータ設定
                {
                    int pg = curPos / ct_CntPerPage + 1;
                    BlInfo.BL1Row wkRow;
                    for (int i = 0; i < ct_CntPerColumn; i++)
                    {
                        wkRow = _blInfoTable.NewBL1Row();
                        _blInfoTable.AddBL1Row(wkRow);
                    }
                    for (int i = 0; i < lstGuide.Count; i++)
                    {
                        BLCodeGuide blCodeGuide = lstGuide[i] as BLCodeGuide;
                        if (blCodeGuide.BLCodeDspPage == pg)
                        {
                            string blCd = blCodeGuide.BLGoodsCode.ToString("00000");
                            string blName = blCodeGuide.BLGoodsName;
                            wkRow = _blInfoTable[blCodeGuide.BLCodeDspRow - 1];
                            switch (blCodeGuide.BLCodeDspCol)
                            {
                                case 1:
                                    wkRow.BLCd = blCd;
                                    wkRow.BLName = blName;
                                    break;
                                case 2:
                                    wkRow.BLCd2 = blCd;
                                    wkRow.BLName2 = blName;
                                    break;
                                case 3:
                                    wkRow.BLCd3 = blCd;
                                    wkRow.BLName3 = blName;
                                    break;
                            }
                        }
                    }
                }
                else // BL全表示の場合のデータ設定
                {
                    DataRowView row;
                    for (int i = curPos; i < curPos + ct_CntPerColumn; i++)
                    {
                        BlInfo.BL1Row wkRow = wkRow = _blInfoTable.NewBL1Row();
                        if (i < cnt) // 第1カラム
                        {
                            row = _dt.DefaultView[i];
                            wkRow[_blInfoTable.BLCdColumn] = string.Format("{0:00000}", row[_dt.BLCdColumn.ColumnName]);
                            wkRow[_blInfoTable.BLNameColumn] = row[_dt.BLNameColumn.ColumnName];
                        }
                        if (i + ct_CntPerColumn < cnt) // 第2カラム
                        {
                            row = _dt.DefaultView[i + ct_CntPerColumn];
                            wkRow[_blInfoTable.BLCd2Column] = string.Format("{0:00000}", row[_dt.BLCdColumn.ColumnName]);
                            wkRow[_blInfoTable.BLName2Column] = row[_dt.BLNameColumn.ColumnName];
                        }
                        if (i + ct_CntPerColumn * 2 < cnt) // 第3カラム
                        {
                            row = _dt.DefaultView[i + ct_CntPerColumn * 2];
                            wkRow[_blInfoTable.BLCd3Column] = string.Format("{0:00000}", row[_dt.BLCdColumn.ColumnName]);
                            wkRow[_blInfoTable.BLName3Column] = row[_dt.BLNameColumn.ColumnName];
                        }
                        _blInfoTable.AddBL1Row(wkRow);
                    }
                }
            }
            finally
            {
                _blInfoTable.EndLoadData();
                gridBL.BeginUpdate();
                gridBL.DataSource = _blInfoTable;
                gridBL.EndUpdate();
                RefreshDataCount(); // [現ページ／総ページ]表示更新
            }
        }
        #endregion

        #region [ フォームイベント処理 ]

        /// <summary>
        /// ESCキー押下による終了処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstBlCd"></param>
        /// <param name="result">BL全表示画面を閉じてから処理フラグ</param>
        /// <param name="isGuide">true : ガイド表示 / false : BL全表示</param>
        /// <returns></returns>
        internal DialogResult ShowDialog(out List<int> lstBlCd, out RetType result, bool isGuide)
        {
            isUserClose = true;
            lstBlCd = new List<int>();
            if (isGuide) // ガイド表示の場合
            {
                ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = true;
            }
            else
            {
                if (((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked)
                {
                    ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = true;
                }
            }
            if (this.Left + this.Width > Screen.PrimaryScreen.Bounds.Width - 200)
            {
                this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width - 200;
            }
            DialogResult ret = base.ShowDialog();
            if (isUserClose)
            {
                result = RetType.Cancel;
            }
            else
            {
                result = retType;
            }
            if (ret == DialogResult.OK)
            {
                for (int i = 0; i < ultraListView1.Items.Count; i++)
                {
                    lstBlCd.Add((int)ultraListView1.Items[i].Value);
                }
            }
            return ret;
        }
        #endregion

        #region [ ツールバーイベント処理 ]
        /// <summary>
        /// ツールボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2013/02/06 donggy </br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信</br>
        /// <br>             Redmine#33919対応</br>
        /// <br>Update Note: 2016/01/13 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、初期フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>Update Note: 2016/02/03 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、「自動検索」をチェックオンにする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、「自動検索」をチェックオンにする変更</br>
        /// </remarks>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (flipflopFlg)
                return;
            switch (e.Tool.Key)
            {
                case "Button_Select": // 選択されている行を確定する
                    retType = RetType.OK;
                    isUserClose = false;
                    DialogResult = DialogResult.OK;
                    break;

                case "Button_Back": // 前の画面に戻る
                    retType = RetType.Cancel;
                    isUserClose = false;
                    DialogResult = DialogResult.Cancel;
                    break;

                case "Button_All": // 全表示
                    if (((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked)
                    {
                        guideOn = false;
                        flipflopFlg = true;
                        ToolbarsManager.Tools["Btn_ByCode"].SharedProps.Enabled = true;
                        ToolbarsManager.Tools["Btn_ByName"].SharedProps.Enabled = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = false;
                        flipflopFlg = false;
                        cnt = _dt.DefaultView.Count;
                        InitializeData();
                    }
                    else
                    {
                        flipflopFlg = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = true;
                        flipflopFlg = false;
                    }
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ------>>>>>>
                    //区分別変更する時、絞込の名称のクリア
                    txtName.Clear();
                    BLFiltering();
                    // --- ADD donggy 2013/02/06 for Redmine#33919 ------<<<<<<
                    //----- ADD 2016/01/13 田建委 Redmine#48587 ----->>>>>
                    // 初期フォーカス：名称絞込に設定し、「曖昧」をチェックオン
                    this.OptionSearch.CheckedIndex = 1;
                    this.txtName.Focus();
                    this.chkSearch.Checked = true;//ADD 2016/02/03 田建委 Redmine#48587
                    //----- ADD 2016/01/13 田建委 Redmine#48587 -----<<<<<
                    break;

                case "Button_Search": // 検索可能対象のみ表示                    
                    retType = RetType.ShowSearch;
                    flipflopFlg = true;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_Search"]).Checked = false;
                    flipflopFlg = false;
                    isUserClose = false;
                    DialogResult = DialogResult.Cancel;
                    break;

                case "Button_Pos": // 部位別表示処理                    
                    retType = RetType.ShowPos;
                    flipflopFlg = true;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked = false;
                    flipflopFlg = false;
                    isUserClose = false;
                    DialogResult = DialogResult.Cancel;
                    break;

                case "Button_Guide": // BLコードガイド表示
                    ShowByGuide();
                    break;

                case "Btn_PrevPg":
                    if (curPos == 0)
                    {
                        StatusBar.Panels[0].Text = "先頭ページです。";
                    }
                    else
                    {
                        StatusBar.Panels[0].Text = "";
                        curPos -= ct_CntPerPage;
                        InitializeData();
                    }
                    break;

                case "Btn_NextPg":
                    if (curPos + ct_CntPerPage >= cnt)
                    {
                        StatusBar.Panels[0].Text = "最後ページです。";
                    }
                    else
                    {
                        StatusBar.Panels[0].Text = "";
                        curPos += ct_CntPerPage;
                        InitializeData();
                    }
                    break;

                case "Btn_ByCode":
                    if (((StateButtonTool)ToolbarsManager.Tools["Btn_ByCode"]).Checked)
                    {
                        _dt.DefaultView.Sort = _dt.BLCdColumn.ColumnName;
                        cnt = _dt.DefaultView.Count;
                        flipflopFlg = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Btn_ByName"]).Checked = false;
                        flipflopFlg = false;
                        InitializeData();
                    }
                    else
                    {
                        flipflopFlg = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Btn_ByCode"]).Checked = true;
                        flipflopFlg = false;
                    }
                    break;

                case "Btn_ByName":
                    if (((StateButtonTool)ToolbarsManager.Tools["Btn_ByName"]).Checked)
                    {
                        _dt.DefaultView.Sort = _dt.BLNameColumn.ColumnName;
                        cnt = _dt.DefaultView.Count;
                        flipflopFlg = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Btn_ByCode"]).Checked = false;
                        flipflopFlg = false;
                        InitializeData();
                    }
                    else
                    {
                        flipflopFlg = true;
                        ((StateButtonTool)ToolbarsManager.Tools["Btn_ByName"]).Checked = true;
                        flipflopFlg = false;
                    }
                    break;
            }
            //txtBLCode.Select();
        }

        private void ToolbarsManager_AfterToolExitEditMode(object sender, AfterToolExitEditModeEventArgs e)
        {
            int pg;
            if (int.TryParse(((TextBoxTool)e.Tool).Text, out pg))
            {
                if (pg < (((cnt - 1) / ct_CntPerPage) + 2))
                {
                    curPos = (pg - 1) * ct_CntPerPage;
                    InitializeData();
                }
            }
            StatusBar.Panels[0].Text = "";
            flgPgTxt = true;
            ((TextBoxTool)e.Tool).Text = string.Empty;
            txtBLCode.Select();
        }

        private void ToolbarsManager_BeforeToolActivate(object sender, CancelableToolEventArgs e)
        {
            if (e.Tool.Key == "Button_Select" && flgPgTxt)
            {
                e.Cancel = true;
            }
            flgPgTxt = false;
        }

        /// <summary>
        /// BLコードガイド表示
        /// </summary>
        /// <remarks>
        /// <br>Update Note: 2013/02/06 donggy </br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信</br>
        /// <br>             Redmine#33919対応</br>
        /// <br>Update Note: 2016/01/13 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、初期フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>Update Note: 2016/02/03 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、「自動検索」をチェックオンにする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、「自動検索」をチェックオンにする変更</br>
        /// </remarks>
        private void ShowByGuide()
        {
            if (((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked)
            {
                guideOn = true;
                flipflopFlg = true;
                ToolbarsManager.Tools["Btn_ByCode"].SharedProps.Enabled = false;
                ToolbarsManager.Tools["Btn_ByName"].SharedProps.Enabled = false;
                ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = false;
                flipflopFlg = false;
                if (lstGuide == null)
                {
                    BLCodeGuideAcs blCodeGuideAcs = new BLCodeGuideAcs();
                    int status = blCodeGuideAcs.Search(out lstGuide, LoginInfoAcquisition.EnterpriseCode,
                        _sectionCd, ConstantManagement.LogicalMode.GetData0);
                    if (status != 0)
                    {
                        if (status == 9)
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Text, "BLコードガイドが設定されていません。", 0, MessageBoxButtons.OK);
                        else
                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Text, "BLコードガイドの取得に失敗しました。", 0, MessageBoxButtons.OK);
                        lstGuide = null;
                        flipflopFlg = true;
                        ToolbarsManager.Tools["Btn_ByCode"].SharedProps.Enabled = false;
                        ToolbarsManager.Tools["Btn_ByName"].SharedProps.Enabled = false;
                        ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = false;
                        flipflopFlg = false;
                        ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = true;
                        return;
                    }
                }
                cnt = ct_CntPerPage * 5; // 1ページあたり54項目5ページ分
                curPos = 0;
                InitializeData();
            }
            else
            {
                flipflopFlg = true;
                ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = true;
                flipflopFlg = false;
            }
            // --- ADD donggy 2013/02/06 for Redmine#33919 ------>>>>>>
            //区分別変更する時、絞込の名称のクリア
            txtName.Clear();
            BLFiltering();
            // --- ADD donggy 2013/02/06 for Redmine#33919 ------<<<<<<
            //----- ADD 2016/01/13 田建委 Redmine#48587 ----->>>>>
            // 初期フォーカス：名称絞込に設定し、「曖昧」をチェックオン
            this.OptionSearch.CheckedIndex = 1;
            this.txtName.Focus();
            this.chkSearch.Checked = true;//ADD 2016/02/03 田建委 Redmine#48587
            //----- ADD 2016/01/13 田建委 Redmine#48587 -----<<<<<
        }

        #endregion

        #region [ グリッドイベント処理 ]
        /// <summary>
        /// InitializeLayout イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>グリッドのレイアウト初期化処理</br>
        /// </remarks>
        private void gridBLInfo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            #region グリッドのレイアウト初期化
            // 列幅の自動調整方法
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;

            // バンドの取得
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                // 水平表示位置
                if (Band.Columns[Index].DataType == typeof(int))
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // 垂直表示位置
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }

            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLCdColumn.ColumnName, 2, 0, 1, 2, 22);
            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLNameColumn.ColumnName, 3, 0, 5, 2, 130);
            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLCd2Column.ColumnName, 8, 0, 1, 2, 21);
            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLName2Column.ColumnName, 9, 0, 5, 2, 130);
            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLCd3Column.ColumnName, 14, 0, 1, 2, 21);
            SelectionForm.ColInfo.SetColInfo(Band, _blInfoTable.BLName3Column.ColumnName, 15, 0, 5, 2, 130);
            #endregion
        }

        #endregion

        #region [ フィルタリング処理 ]
        private void txtName_ValueChanged(object sender, EventArgs e)
        {
            if (chkSearch.Checked && txtName.Text.Equals(txtName.Tag) == false)
            {
                BLFiltering();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (chkSearch.Checked == false && txtName.Text.Equals(txtName.Tag) == false)
            {
                BLFiltering();
            }
        }

        private void OptionSearch_ValueChanged(object sender, EventArgs e)
        {
            BLFiltering();
        }

        private void BLFiltering()
        {
            if (guideOn == false)
            {
                if (txtName.Text != string.Empty)
                {
                    if (OptionSearch.Value.Equals(true)) // 曖昧検索
                        _dt.DefaultView.RowFilter = string.Format("{0} like '%{1}%'", _dt.BLNameColumn.ColumnName, txtName.Text);
                    else // 前方一致検索
                        _dt.DefaultView.RowFilter = string.Format("{0} like '{1}%'", _dt.BLNameColumn.ColumnName, txtName.Text);
                }
                else
                {
                    _dt.DefaultView.RowFilter = string.Empty;
                }
                cnt = _dt.DefaultView.Count;
                curPos = 0;
                InitializeData();
                txtName.Tag = txtName.Text;
            }
            // --- ADD donggy 2013/02/06 for Redmine#33919 --->>>>>>
            // ガイドの名称絞込の追加
            else
            {
                // ガイド別のデータの取得
                BLCodeGuideAcs blCodeGuideAcs = new BLCodeGuideAcs();
                int status = blCodeGuideAcs.Search(out lstGuide, LoginInfoAcquisition.EnterpriseCode,
                    _sectionCd, ConstantManagement.LogicalMode.GetData0);
                if (status != 0)
                {
                    if (status == 9)
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Text, "BLコードガイドが設定されていません。", 0, MessageBoxButtons.OK);
                    else
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Text, "BLコードガイドの取得に失敗しました。", 0, MessageBoxButtons.OK);
                    lstGuide = null;
                    flipflopFlg = true;
                    ToolbarsManager.Tools["Btn_ByCode"].SharedProps.Enabled = false;
                    ToolbarsManager.Tools["Btn_ByName"].SharedProps.Enabled = false;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_Guide"]).Checked = false;
                    flipflopFlg = false;
                    ((StateButtonTool)ToolbarsManager.Tools["Button_All"]).Checked = true;
                    return;
                }
                //絞込用DataTableとDataView
                DataTable tempGuideTable = new DataTable();
                DataView tempGuideView = new DataView(tempGuideTable);
                tempGuideTable.Columns.Add("BLCodeDspCol", typeof(int));
                tempGuideTable.Columns.Add("BLCodeDspPage", typeof(int));
                tempGuideTable.Columns.Add("BLCodeDspRow", typeof(int));
                tempGuideTable.Columns.Add("BLGoodsCode", typeof(int));
                tempGuideTable.Columns.Add(_dt.BLNameColumn.ColumnName, typeof(string));
                tempGuideTable.Columns.Add("EnterpriseCode", typeof(string));
                tempGuideTable.Columns.Add("SectionCode", typeof(string));
                DataRow row = null;
                // ガイド別のデータが絞込用DataTableに落とす
                foreach (BLCodeGuide blCodeGuide in lstGuide)
                {
                    row = tempGuideTable.NewRow();
                    row["BLCodeDspCol"] = blCodeGuide.BLCodeDspCol;
                    row["BLCodeDspPage"] = blCodeGuide.BLCodeDspPage;
                    row["BLCodeDspRow"] = blCodeGuide.BLCodeDspRow;
                    row["BLGoodsCode"] = blCodeGuide.BLGoodsCode;
                    row[_dt.BLNameColumn.ColumnName] = blCodeGuide.BLGoodsName;
                    row["EnterpriseCode"] = blCodeGuide.EnterpriseCode;
                    row["SectionCode"] = blCodeGuide.SectionCode;
                    tempGuideTable.Rows.Add(row);
                }
                //絞込実行
                if (txtName.Text != string.Empty)
                {
                    ArrayList tempGuide = new ArrayList();
                    if (OptionSearch.Value.Equals(true)) // 曖昧検索
                        tempGuideView.RowFilter = string.Format("{0} like '%{1}%'", _dt.BLNameColumn.ColumnName, txtName.Text);
                    else // 前方一致検索
                        tempGuideView.RowFilter = string.Format("{0} like '{1}%'", _dt.BLNameColumn.ColumnName, txtName.Text);
                    int rowNo = 1;
                    int colNo = 0;
                    BLCodeGuide tempBLCodeGuide = null;
                    //絞込後のデータの表示位置の設定
                    foreach( DataRowView tempRow in tempGuideView)
                    {
                        tempBLCodeGuide = new BLCodeGuide();
                        if (colNo < 3)
                        {
                            tempRow["BLCodeDspRow"] = rowNo;
                        }
                        else
                        {
                            tempRow["BLCodeDspRow"] = rowNo + 1;
                            colNo = 0;
                        }
                        tempRow["BLCodeDspCol"] = colNo + 1;
                        colNo++;
                        //表示用データの取得
                        foreach (BLCodeGuide blCodeGuide in lstGuide)
                        {
                            if (blCodeGuide.BLCodeDspPage.ToString() == tempRow["BLCodeDspPage"].ToString() && blCodeGuide.BLGoodsCode.ToString() == tempRow["BLGoodsCode"].ToString()
                                && blCodeGuide.EnterpriseCode == tempRow["EnterpriseCode"].ToString() && blCodeGuide.SectionCode == tempRow["SectionCode"].ToString()
                                && blCodeGuide.BLGoodsName == tempRow[_dt.BLNameColumn.ColumnName].ToString())
                            {
                                blCodeGuide.BLCodeDspCol = (int)tempRow["BLCodeDspCol"];
                                blCodeGuide.BLCodeDspRow = (int)tempRow["BLCodeDspRow"];
                                tempGuide.Add(blCodeGuide);
                            }
                        }

                    }
                    lstGuide = tempGuide;
                    cnt = lstGuide.Count;
                }
                else
                {
                   tempGuideView.RowFilter = string.Empty;
                   cnt = ct_CntPerPage * 5;
                }
                curPos = 0;
                InitializeData();
                txtName.Tag = txtName.Text;
            }
            // --- ADD donggy 2013/02/06 for Redmine#33919 --- <<<<<<
        }
        #endregion

        #region [ BLコード登録処理 ]
        private void txtBLCode_Validating(object sender, CancelEventArgs e)
        {
            DoBLRegister();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int cnt = ultraListView1.SelectedItems.Count;
            for (int i = 0; i < cnt; i++)
                ultraListView1.Items.RemoveAt(ultraListView1.SelectedItems[0].Index);
            txtBLCode.Select();
        }

        /// <summary>
        /// アローキー、enter、tabのフォーカス遷移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17  田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ②アローキー、enter、tabのフォーカス遷移の対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            //if (e.PrevCtrl == txtBLCode && e.NextCtrl == gridBL)
            //----- DEL 2016/02/17 田建委 Redmine#48587 ----->>>>>
            //if (e.PrevCtrl == txtBLCode)// && e.NextCtrl == btnDel)
            //{
            //    DoBLRegister();
            //    e.NextCtrl = txtBLCode;
            //}
            //else
            //{
            //    e.NextCtrl = txtBLCode;
            //}
            //----- DEL 2016/02/17 田建委 Redmine#48587 -----<<<<<
            //----- ADD 2016/02/17 田建委 Redmine#48587 ----->>>>>
            switch (e.Key)
            {
                case Keys.Enter:
                case Keys.Tab:
                    if (e.PrevCtrl == txtBLCode)
                    {
                        //SHIFT押下しない
                        if (!e.ShiftKey)
                        {
                            DoBLRegister();
                            e.NextCtrl = txtBLCode;
                        }
                        //SHIFT+ENTER、SHIFT+TAB　BLコード⇒前方・曖昧
                        else
                        {
                            DoBLRegister();
                            e.NextCtrl = OptionSearch;
                        }
                    }
                    //SHIFT+ENTER、SHIFT+TAB　名称絞込み⇒BLコード
                    else if (e.PrevCtrl == txtName)
                    {
                        if (e.ShiftKey)
                        {
                            e.NextCtrl = txtBLCode;
                        }
                    }
                    break;
            }
            //----- ADD 2016/02/17 田建委 Redmine#48587 -----<<<<<
        }

        private void DoBLRegister()
        {
            int bl;
            if (int.TryParse(txtBLCode.Text, out bl) && _dt.FindByBLCd(bl) != null)
            {
                ultraListView1.Items.Add(ultraListView1.Items.ToString(), bl);
            }
            txtBLCode.Clear();
        }
        #endregion

        /// <summary>
        /// [現ページ／総ページ]表示更新
        /// </summary>
        private void RefreshDataCount()
        {
            int pg = curPos / ct_CntPerPage + 1;
            string cntMsg;
            cntMsg = string.Format("{0} / {1}", pg, ((cnt - 1) / ct_CntPerPage) + 1);

            ToolbarsManager.Tools["lbl_Cnt"].SharedProps.Caption = cntMsg;
        }

        //----- ADD 2016/01/13 田建委 Redmine#48587 ----->>>>>
        /// <summary>
        /// 画面の表示
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベント</param>
        /// <remarks>
        /// <br>Update Note: 2016/01/13 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、初期フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、フォーカスを名称絞込に初期区分を曖昧にする変更</br>
        /// <br>Update Note: 2016/02/03 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : ①初期表示した時、「自動検索」をチェックオンにする変更</br>
        /// <br>           : ②画面表示した後、F5、F6、F7、F8を切替し、「自動検索」をチェックオンにする変更</br>
        /// </remarks>
        private void SelectionForm2_Shown(object sender, EventArgs e)
        {
            // BLコードガイド初期表示区分が「BLコードガイド」の場合、
            // 初期フォーカス：名称絞込に設定し、「曖昧」をチェックオン
            this.OptionSearch.CheckedIndex = 1;
            this.txtName.Focus();
            this.chkSearch.Checked = true;//ADD 2016/02/03 田建委 Redmine#48587
        }
        //----- ADD 2016/01/13 田建委 Redmine#48587 -----<<<<<

        //----- ADD 2016/02/17 田建委 Redmine#48587 ----->>>>>
        /// <summary>
        /// 売上入力から起動の場合、カーソルを取得できない既存障害あるので、初期カーソルはtimer1_Tickで「名称絞込み」にセットする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : 名称絞込みの初期入力モードを「半角カナ」にする</br>
        /// </remarks>
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.label1.Focus();
            this.txtName.Focus();
            time_count++;
            if (time_count > 1)
            {
                this.timer1.Enabled = false;
            }
        }

        /// <summary>
        /// 売上入力から起動の場合、カーソルを取得できない既存障害あるので、初期カーソルはtimer1_Tickで「名称絞込み」にセットする。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2016/02/17 田建委</br>
        /// <br>           : 11200090-00 Redmine#48587</br>
        /// <br>           : 名称絞込みの初期入力モードを「半角カナ」にする</br>
        /// </remarks>
        private void SelectionForm2_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
        }
        //----- ADD 2016/02/17 田建委 Redmine#48587 -----<<<<<
    }

    internal enum RetType
    {
        OK = 0,
        Cancel = 1,
        ShowSearch = 2,
        ShowPos = 3
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入チェックリスト
// プログラム概要   : 仕入チェックリスト帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日 2009/08/07   修正内容 : カーソルがPM拠点の名称へ移動した時に入力可能状態（セルがオレンジ色）となるように修正 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinGrid;
using System.Collections;
using Infragistics.Win;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 拠点変換設定UIクラス                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点変換設定UIで、抽出条件を入力します。</br>       
    /// <br>Programmer : 張莉莉</br>                                   
    /// <br>Date       : 2009.05.10</br>                                   
    /// </remarks>
    public partial class PMKOU02050UB : Form
    {
        #region ■ Constants

        // プログラムID
        private const string ASSEMBLY_ID = "PMKOU02050UB";

        // グリッド列タイトル
        private const string COLUMN_CSV_NO = "CSV_No";
        private const string COLUMN_CSV_SECCD = "CSV_SecCd";
        private const string COLUMN_PM_NO = "PM_No";
        private const string COLUMN_PM_SECCD = "PM_SecCd";
        private const string COLUMN_PM_SECNM = "PM_SecNm";
        private const string COLUMN_PM_SECGUIDE = "PM_SecGuide";
        #region ■ Private Members

        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;

        private SectionCdInputConstructionAcs _sectionCdInputConstructionAcs = null;

        private Hashtable _inputData = new Hashtable();
        private ArrayList keyData = new ArrayList();
        private ArrayList keyData1 = new ArrayList();
        private ArrayList keyData2 = new ArrayList();
        private ArrayList valueData = new ArrayList();

        private string firstGridActiveStr = null;
        private string beforeChangeStr = null;
        private int firstGridActiveRow;

        private DataTable dataTableCsv = new DataTable();
        private DataTable dataTablePm = new DataTable();
        private string _enterpriseCode;
        private ControlScreenSkin _controlScreenSkin;           // 画面デザイン変更クラス
   

        #endregion ■ Private Members
        #endregion ■ Constants

        /// <summary>
        /// 拠点変換設定UIクラスコンストラクタ　　　　　　　　　　　　　　　　　　 　
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点変換設定UI初期化およびインスタンスの生成を行う</br>                 
        /// <br>Programmer : 張莉莉</br>                                  
        /// <br>Date       : 2009.05.10</br>                                     
        /// </remarks>
        public PMKOU02050UB()
        {
            InitializeComponent();

            // 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();

            this._controlScreenSkin = new ControlScreenSkin();

            // マスタ読込
            ReadSecInfoSet();

            // DataSet列情報構築
            this.Bind_DataSet = new DataSet();

            this._sectionCdInputConstructionAcs = new SectionCdInputConstructionAcs();
            keyData = this._sectionCdInputConstructionAcs.InputSecCdCSV;
            valueData = this._sectionCdInputConstructionAcs.InputSecCdPM;
            if (keyData != null)
            {
                for (int i = 0; i < keyData.Count; i++)
                {
                    _inputData.Add(keyData[i], valueData[i]);
                }
            }
                      
        }


        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォームのLoad時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void PMKOU02050UB_Load(object sender, EventArgs e)
        {
            // 画面初期設定
            SetScreenInitialSetting();

            this.timer_SetFocus.Enabled = true;
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void SetScreenInitialSetting()
        {
            // マスタ読込
            ReadSecInfoSet();

            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);

            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList16 = IconResourceManagement.ImageList16;
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Ok_Button.ImageList = imageList24;
            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // グリッド構築
            dataTableCsv.Columns.Add(COLUMN_CSV_NO, typeof(string));
            dataTableCsv.Columns.Add(COLUMN_CSV_SECCD, typeof(string));

            dataTablePm.Columns.Add(COLUMN_PM_NO, typeof(string));
            dataTablePm.Columns.Add(COLUMN_PM_SECCD, typeof(string));
            dataTablePm.Columns.Add(COLUMN_PM_SECNM, typeof(string));
            dataTablePm.Columns.Add(COLUMN_PM_SECGUIDE, typeof(string));

            if (_inputData.Count > 0)
            {
                keyData1 = new ArrayList (_inputData.Keys);
                keyData1.Sort();
                keyData2 = new ArrayList(_inputData.Values);
                for (int i = 0; i < keyData1.Count; i++)
                {
                    DataRow dataRowCsv = dataTableCsv.NewRow();
                    dataRowCsv[COLUMN_CSV_NO] = "";
                    dataRowCsv[COLUMN_CSV_SECCD] = keyData1[i];
                    dataTableCsv.Rows.Add(dataRowCsv);
                }

                ArrayList firstPmData = new ArrayList();
                firstPmData = (ArrayList)_inputData[keyData1[0]];
                firstPmData.Sort();
                for (int j = 0; j < firstPmData.Count; j++)
                {
                    DataRow dataRowPm = dataTablePm.NewRow();
                    dataRowPm[COLUMN_PM_NO] = "";
                    dataRowPm[COLUMN_PM_SECCD] = firstPmData[j].ToString();
                    dataRowPm[COLUMN_PM_SECNM] = GetSectionName(firstPmData[j].ToString().Trim());
                    dataTablePm.Rows.Add(dataRowPm);

                }
                
            }
            DataRow dataRowCsvbk = dataTableCsv.NewRow();
            dataRowCsvbk[COLUMN_CSV_NO] = "";
            dataRowCsvbk[COLUMN_CSV_SECCD] = "";
            dataTableCsv.Rows.Add(dataRowCsvbk);

            DataRow dataRowPmbk = dataTablePm.NewRow();
            dataRowPmbk[COLUMN_PM_NO] = "";
            dataRowPmbk[COLUMN_PM_SECCD] = "";
            dataRowPmbk[COLUMN_PM_SECNM] = "";
            dataRowPmbk[COLUMN_PM_SECGUIDE] = "";
            dataTablePm.Rows.Add(dataRowPmbk);
            
            this.First_Grid.DataSource = dataTableCsv;
            this.Second_Grid.DataSource = dataTablePm;

            ColumnsCollection columnsCsv = this.First_Grid.DisplayLayout.Bands[0].Columns;
            ColumnsCollection columnsPm = this.Second_Grid.DisplayLayout.Bands[0].Columns;

            // ヘッダーキャプション
            columnsCsv[COLUMN_CSV_NO].Header.Caption = "";
            columnsCsv[COLUMN_CSV_SECCD].Header.Caption = "拠点コード";

            columnsPm[COLUMN_PM_NO].Header.Caption = "";
            columnsPm[COLUMN_PM_SECCD].Header.Caption = "拠点コード";
            columnsPm[COLUMN_PM_SECNM].Header.Caption = "拠点名称";
            columnsPm[COLUMN_PM_SECGUIDE].Header.Caption = "";

            // TextHAlign
            columnsCsv[COLUMN_CSV_NO].CellAppearance.TextHAlign = HAlign.Right;
            columnsCsv[COLUMN_CSV_SECCD].CellAppearance.TextHAlign = HAlign.Right;

            columnsPm[COLUMN_PM_NO].CellAppearance.TextHAlign = HAlign.Right;
            columnsPm[COLUMN_PM_SECCD].CellAppearance.TextHAlign = HAlign.Right;
            columnsPm[COLUMN_PM_SECNM].CellAppearance.TextHAlign = HAlign.Left;
            columnsPm[COLUMN_PM_SECGUIDE].CellAppearance.TextHAlign = HAlign.Center;

            // TextVAlign
            columnsCsv[COLUMN_CSV_NO].CellAppearance.TextVAlign = VAlign.Middle;
            columnsCsv[COLUMN_CSV_SECCD].CellAppearance.TextVAlign = VAlign.Middle;

            columnsPm[COLUMN_PM_NO].CellAppearance.TextVAlign = VAlign.Middle;
            columnsPm[COLUMN_PM_SECCD].CellAppearance.TextVAlign = VAlign.Middle;
            columnsPm[COLUMN_PM_SECNM].CellAppearance.TextVAlign = VAlign.Middle;
            columnsPm[COLUMN_PM_SECGUIDE].CellAppearance.TextVAlign = VAlign.Middle;

            // 入力制御
            columnsCsv[COLUMN_CSV_NO].CellActivation = Activation.Disabled;
            columnsCsv[COLUMN_CSV_SECCD].CellActivation = Activation.AllowEdit;

            columnsPm[COLUMN_PM_NO].CellActivation = Activation.Disabled;
            columnsPm[COLUMN_PM_SECCD].CellActivation = Activation.AllowEdit;
            columnsPm[COLUMN_PM_SECNM].CellActivation = Activation.Disabled;
            columnsPm[COLUMN_PM_SECGUIDE].CellActivation = Activation.AllowEdit;

            // 列幅
            columnsCsv[COLUMN_CSV_NO].Width = 20;
            columnsCsv[COLUMN_CSV_SECCD].Width = 110;

            columnsPm[COLUMN_PM_NO].Width = 20;
            columnsPm[COLUMN_PM_SECCD].Width = 110;
            columnsPm[COLUMN_PM_SECNM].Width = 200;
            columnsPm[COLUMN_PM_SECGUIDE].Width = 24;

            // セルColor
            columnsCsv[COLUMN_CSV_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columnsCsv[COLUMN_CSV_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columnsCsv[COLUMN_CSV_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columnsCsv[COLUMN_CSV_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columnsCsv[COLUMN_CSV_NO].CellAppearance.ForeColor = Color.White;
            columnsCsv[COLUMN_CSV_NO].CellAppearance.ForeColorDisabled = Color.White;
            columnsCsv[COLUMN_CSV_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columnsCsv[COLUMN_CSV_SECCD].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);

            columnsPm[COLUMN_PM_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columnsPm[COLUMN_PM_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columnsPm[COLUMN_PM_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columnsPm[COLUMN_PM_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columnsPm[COLUMN_PM_NO].CellAppearance.ForeColor = Color.White;
            columnsPm[COLUMN_PM_NO].CellAppearance.ForeColorDisabled = Color.White;
            columnsPm[COLUMN_PM_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columnsPm[COLUMN_PM_SECCD].CellAppearance.BackColorDisabled = Color.FromKnownColor(KnownColor.Control);
            columnsPm[COLUMN_PM_SECNM].CellAppearance.BackColor = Color.Gainsboro;
            columnsPm[COLUMN_PM_SECNM].CellAppearance.BackColorDisabled = Color.Gainsboro;

            // MaxLength
            columnsCsv[COLUMN_CSV_SECCD].MaxLength = 10;
            columnsPm[COLUMN_PM_SECCD].MaxLength = 2;
            columnsPm[COLUMN_PM_SECNM].MaxLength = 10;

            // セルボタン
            columnsPm[COLUMN_PM_SECGUIDE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columnsPm[COLUMN_PM_SECGUIDE].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columnsPm[COLUMN_PM_SECGUIDE].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columnsPm[COLUMN_PM_SECGUIDE].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columnsPm[COLUMN_PM_SECGUIDE].CellButtonAppearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            columnsPm[COLUMN_PM_SECGUIDE].CellAppearance.Cursor = Cursors.Hand;

        }


        /// <summary>
        /// 拠点マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点マスタを読込、バッファに保持します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// 拠点名取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note       : 拠点名を取得します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 新規行作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note       : グリッドに行を追加します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void CreateNewRow(ref UltraGrid uGrid)
        {
            // 行追加
            uGrid.DisplayLayout.Bands[0].AddNew();
        }

        /// <summary>
        /// UltraWinGrid.AfterSelectChange イベント(First_Grid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">Bandオブジェクトを引数とするイベントで使用されるイベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : １つ以上の行、セル、または列オブジェクトが選択または選択解除された後に発生します。 </br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (this.First_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.First_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;

            // 空値の場合
            if (cell.Value is DBNull)
            {
                return;
            }

            int code = Convert.ToInt32(cell.Value.ToString());

            string secCd = code.ToString("0000000000");
            if (!string.IsNullOrEmpty(secCd))
            {
                ArrayList pmData = new ArrayList();
                pmData = (ArrayList)_inputData[secCd];
                pmData.Sort();
                for (int j = 0; j < pmData.Count; j++)
                {
                    DataRow dataRowPm = dataTablePm.NewRow();
                    dataRowPm[COLUMN_PM_NO] = "";
                    dataRowPm[COLUMN_PM_SECCD] = pmData[j].ToString();
                    dataRowPm[COLUMN_PM_SECNM] = GetSectionName(secCd[j].ToString().Trim());
                    dataTablePm.Rows.Add(dataRowPm);

                }
            }
        }

        /// <summary>
        /// Button_Click イベント(閉じるボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 閉じるボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Button_Click イベント(保存ボタン)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 保存ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (_inputData.Contains(""))
            {
                _inputData.Remove("");
            }
            keyData = new ArrayList(_inputData.Keys);
            valueData = new ArrayList(_inputData.Values);
            this._sectionCdInputConstructionAcs.InputSecCdCSV = this.keyData;
            this._sectionCdInputConstructionAcs.InputSecCdPM = this.valueData;
            this._sectionCdInputConstructionAcs.Serialize();

            this.Close();
        }

        /// <summary>
        /// ClickCellButton イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : セルボタンをクリックされた時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Second_Grid_ClickCellButton(object sender, CellEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;
            int status;
            switch (e.Cell.Column.Key)
            {
                // 拠点ガイドボタン
                case COLUMN_PM_SECGUIDE:                    
                    {
                        SecInfoSet secInfoSet;
                        status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                        if (status == 0)
                        {
                            // 拠点コード
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_PM_SECCD].Value = secInfoSet.SectionCode.Trim();
                            // 拠点名
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_PM_SECNM].Value = GetSectionName(secInfoSet.SectionCode.Trim());

                            if (e.Cell.Row.Index == uGrid.Rows.Count - 1)
                            {
                                // 最終行だった場合、行を追加
                                CreateNewRow(ref uGrid);
                            }

                            // フォーカス設定
                            uGrid.Rows[e.Cell.Row.Index].Cells[COLUMN_PM_SECCD].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
            }
        }

        // --------DEL 20090819 張莉莉　フォーカス移動の修正------>>>>>>>>>
        ///// <summary>
        ///// AfterExitEditMode イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントハンドラ</param>
        ///// <remarks>
        ///// <br>Note       : 編集モードが終了した時に発生します。</br>
        ///// <br>Programmer : 張莉莉</br>
        ///// <br>Date	   : 2009.05.10</br>
        ///// </remarks>
        //private void Second_Grid_AfterExitEditMode(object sender, EventArgs e)
        //{
        //    UltraGrid uGrid = (UltraGrid)sender;
        //    int rowNm = Second_Grid.ActiveCell.Row.Index;
        //    if (uGrid.ActiveCell == null)
        //    {
        //        return;
        //    }
        //    //switch (uGrid.ActiveCell.Column.Key)
        //    //{
        //    //    case COLUMN_PM_SECCD:
        //    //        {
        //    //            // ゼロ詰め
        //    //            uGrid.ActiveCell.Value = this.uiSetControl1.GetZeroPaddedText(uGrid.ActiveCell.Column.Key, uGrid.ActiveCell.Value.ToString());

        //    //            // 拠点コード取得
        //    //            string sectionCode = CellTextToString(uGrid.ActiveCell.Text);
            
        //    //            if (sectionCode == "")
        //    //            {
        //    //                // 行クリア
        //    //                ClearRow(rowNm);
        //    //                if (rowNm != uGrid.Rows.Count - 1)
        //    //                {
        //    //                    this.dataTablePm.AcceptChanges();
        //    //                    this.dataTablePm.Rows[rowNm].Delete();
                                
        //    //                    this.Second_Grid.Rows[rowNm].Cells[1].Activate();
        //    //                }
        //    //            }
        //    //            else
        //    //            {
        //    //                bool bStatus = CheckSectionCode(sectionCode);
        //    //                if (!bStatus)
        //    //                {
        //    //                    // 行クリア
        //    //                    ClearRow(Second_Grid.ActiveCell.Row.Index);
        //    //                    return;
        //    //                }

        //    //                // 拠点名取得
        //    //                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_PM_SECNM].Value = GetSectionName(sectionCode);

        //    //                uGrid.Rows[uGrid.ActiveCell.Row.Index].Cells[COLUMN_PM_SECCD].Value = sectionCode;

        //    //                if (uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1)
        //    //                {
        //    //                    // 最終行だった場合、行追加
        //    //                    CreateNewRow(ref uGrid);
        //    //                }
        //    //                this.Second_Grid.Rows[rowNm].Cells[1].Activate();
                            
        //    //            }

        //    //            break;
        //    //        }
        //    //}

        //    ArrayList nowPmData = new ArrayList();
        //    for (int i = 0; i < uGrid.Rows.Count; i++)
        //    {
        //        // 画面のPMデータを取得
        //        if (!string.IsNullOrEmpty(uGrid.Rows[i].Cells[COLUMN_PM_SECCD].Text.ToString()))
        //        {
        //            nowPmData.Add(uGrid.Rows[i].Cells[COLUMN_PM_SECCD].Text);
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(firstGridActiveStr))
        //    {
        //        //　元データを削除する
        //        if (_inputData.Contains(firstGridActiveStr))
        //        {
        //            _inputData.Remove(firstGridActiveStr);
        //        }
        //        //　今のデータをセーフ
        //        if (nowPmData.Count > 0)
        //        {
        //            _inputData.Add(firstGridActiveStr, nowPmData);
        //        }
        //    }
        //}
        // --------DEL 20090819 張莉莉　フォーカス移動の修正------<<<<<<<<<<

        /// <summary>
        /// 行クリア処理
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <remarks>
        /// <br>Note       : 対象行のデータをクリアします。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void ClearRow(int rowIndex)
        {
            this.Second_Grid.Rows[rowIndex].Cells[COLUMN_PM_SECCD].Value = "";
            this.Second_Grid.Rows[rowIndex].Cells[COLUMN_PM_SECNM].Value = "";
        }

        /// <summary>
        /// 変換処理(object→string)
        /// </summary>
        /// <param name="targetValue">変換対象object</param>
        /// <returns>文字列</returns>
        /// <remarks>
        /// <br>Note       : object型をstringに変換します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private string StrObjectToString(object targetValue)
        {
            if ((targetValue == DBNull.Value) || (targetValue == null) || ((string)targetValue == ""))
            {
                return "";
            }

            return (string)targetValue;
        }

        /// <summary>
        /// 変換処理(string→string)
        /// </summary>
        /// <param name="cellText">変換対象</param>
        /// <returns>文字列</returns>
        /// <remarks>
        /// <br>Note       : 変換します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private string CellTextToString(string cellText)
        {
            if ((cellText == null) || (cellText.Trim() == ""))
            {
                return "";
            }

            return cellText.Trim().PadLeft(2, '0');
        }

        /// <summary>
        /// 拠点コードチェック処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点コードがマスタに存在するかチェックします。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private bool CheckSectionCode(string sectionCode)
        {
            string errMsg = "";

            try
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()) == false)
                {
                    errMsg = "拠点情報設定マスタに登録されていません。";
                    return (false);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   -1,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                       // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// AfterEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードが開始した時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_AfterEnterEditMode(object sender, EventArgs e)
        {
            if (this.First_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.First_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;

            // 空値を判断する
            if (!string.IsNullOrEmpty(cell.Value.ToString()))
            {
                int code = Convert.ToInt32(cell.Value.ToString());

                string secCd = code.ToString("0000000000");

                firstGridActiveStr = code.ToString("0000000000");
                //　PMデータを表示する
                if (!string.IsNullOrEmpty(secCd))
                {
                    ArrayList pmData = new ArrayList();
                    pmData = (ArrayList)_inputData[secCd];
                    
                    dataTablePm.Clear();
                    if (pmData != null && pmData.Count > 0)
                    {
                        pmData.Sort();
                        for (int j = 0; j < pmData.Count; j++)
                        {
                            DataRow dataRowPm = dataTablePm.NewRow();
                            dataRowPm[COLUMN_PM_NO] = "";
                            dataRowPm[COLUMN_PM_SECCD] = pmData[j].ToString();
                            dataRowPm[COLUMN_PM_SECNM] = GetSectionName(pmData[j].ToString().Trim());
                            dataTablePm.Rows.Add(dataRowPm);
                        }
                    }

                    DataRow dataRowPmbk = dataTablePm.NewRow();
                    dataRowPmbk[COLUMN_PM_NO] = "";
                    dataRowPmbk[COLUMN_PM_SECCD] = "";
                    dataRowPmbk[COLUMN_PM_SECNM] = "";
                    dataTablePm.Rows.Add(dataRowPmbk);

                    this.First_Grid.DataSource = dataTableCsv;
                    this.Second_Grid.DataSource = dataTablePm;
                }
                else
                {
                    //　行を追加
                    dataTablePm.Clear();
                    DataRow dataRowPmbk = dataTablePm.NewRow();
                    dataRowPmbk[COLUMN_PM_NO] = "";
                    dataRowPmbk[COLUMN_PM_SECCD] = "";
                    dataRowPmbk[COLUMN_PM_SECNM] = "";
                    dataTablePm.Rows.Add(dataRowPmbk);
                }
            }
            else
            {
                firstGridActiveStr = string.Empty;
                //　行を追加
                dataTablePm.Clear();
                DataRow dataRowPmbk = dataTablePm.NewRow();
                dataRowPmbk[COLUMN_PM_NO] = "";
                dataRowPmbk[COLUMN_PM_SECCD] = "";
                dataRowPmbk[COLUMN_PM_SECNM] = "";
                dataTablePm.Rows.Add(dataRowPmbk);
            }
        }

        /// <summary>
        /// BeforeCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 更新が開始した時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // IMEをひらがなモードにする
            this.First_Grid.ImeMode = System.Windows.Forms.ImeMode.Close;

            UltraGrid uGrid = (UltraGrid)sender;
            int rowNo = uGrid.ActiveRow.Index;
            beforeChangeStr = uGrid.ActiveRow.Cells[COLUMN_CSV_SECCD].Text;
        }

        /// <summary>
        /// SetFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : フォカスを指定した時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            if (dataTableCsv.Rows.Count != 0)
            {
                this.First_Grid.Focus();
                this.First_Grid.Rows[0].Cells[1].Activate();
                this.First_Grid.PerformAction(UltraGridAction.EnterEditMode);
            }

            this.timer_SetFocus.Enabled = false;
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : グリッドアクティブ時にキーが押されたタイミングで発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            int rowIndex;
            int columnIndex;

            if (uGrid.ActiveCell == null)
            {
                if (uGrid.ActiveRow == null)
                {
                    return;
                }
                else
                {
                    rowIndex = uGrid.ActiveRow.Index;
                    columnIndex = 1;
                }
            }
            else
            {
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
            }

            switch (e.KeyCode)
            {
                case Keys.Space:
                    {
                        e.Handled = true;
                        if (uGrid == Second_Grid)
                        {
                            if (columnIndex == 3)
                            {
                                Second_Grid_ClickCellButton(this.Second_Grid, new CellEventArgs(uGrid.ActiveCell));
                            }
                        }
                        break;
                    }
                case Keys.Up:
                    {
                        e.Handled = true;

                        // 編集モード終了
                        uGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex != 0)
                        {
                            uGrid.Rows[rowIndex - 1].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        // 編集モード終了
                        uGrid.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex != uGrid.Rows.Count - 1)
                        {
                            uGrid.Rows[rowIndex + 1].Cells[columnIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid == Second_Grid)
                        {
                            e.Handled = true;

                            // 編集モード終了
                            uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            int colNo = (columnIndex + 2) % 4;
                            if (columnIndex == 1)
                            {
                                this.First_Grid.Rows[firstGridActiveRow].Cells[1].Activate();
                                this.First_Grid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                uGrid.Rows[rowIndex].Cells[(columnIndex + 2) % 4].Activate();
                                if (colNo == 1)
                                {
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            
                        }
                        
                        break;
                    }
                case Keys.Right:
                    {
                        if (uGrid == Second_Grid)
                        {
                            e.Handled = true;

                            // 編集モード終了
                            uGrid.PerformAction(UltraGridAction.ExitEditMode);
                            int colNo = (columnIndex + 2) % 4;
                            uGrid.Rows[rowIndex].Cells[(columnIndex + 2) % 4].Activate();
                            if (colNo == 1)
                            {
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                        }
                        break;
                    }

            }
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.First_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.First_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;
            firstGridActiveRow = rowIndex;
            string data = cell.Value.ToString();

            bool hasAdd = false;
            // 同じ仕入先拠点存在の場合、エラーを出す。
            if (!string.IsNullOrEmpty(cell.Value.ToString()))
            {
                int code = Convert.ToInt32(cell.Value.ToString());

                firstGridActiveStr = code.ToString("0000000000");
                for (int i = 0; i < this.First_Grid.Rows.Count; i++)
                {
                    string secStr = this.First_Grid.Rows[i].Cells[COLUMN_CSV_SECCD].Text.ToString();
                    if (firstGridActiveStr.Equals(secStr) && rowIndex != i && firstGridActiveStr != string.Empty)
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "指定された仕入先拠点は存在しました。",
                                       -1,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);
                        // 行クリア
                        this.First_Grid.Rows[rowIndex].Cells[COLUMN_CSV_SECCD].Value = "";
                        data = null;
                        hasAdd = true;
                        break;

                    }

                }

                if ((rowIndex == this.First_Grid.Rows.Count - 1) && !hasAdd)
                {
                    // 最終行だった場合、行を追加
                    CreateNewRow(ref this.First_Grid);
                }
            }
            else
            {
                firstGridActiveStr = string.Empty;
            }
            // DeleteKEYで行う、このデータを削除
            if (_inputData.Contains(beforeChangeStr) && !beforeChangeStr.Equals(firstGridActiveStr))
            {
                _inputData.Remove(beforeChangeStr);
            }
            // DeleteKEYで行う、行を削除
            if (rowIndex != this.First_Grid.Rows.Count - 1 && string.IsNullOrEmpty(data))
            {
                DataRow row = this.dataTableCsv.Rows[rowIndex];
                this.dataTableCsv.Rows.Remove(row);
                //　次行のデータを表示する
                this.First_Grid.Rows[rowIndex].Cells[1].Activate();
                this.First_Grid.Rows[rowIndex].Cells[1].Selected = true;
                if (!string.IsNullOrEmpty(this.First_Grid.ActiveCell.Value.ToString()))
                {
                    int nowCd = Convert.ToInt32(this.First_Grid.ActiveCell.Value.ToString());
                    //　PMデータを設定する
                    string secCd = nowCd.ToString("0000000000");
                    if (!string.IsNullOrEmpty(secCd))
                    {
                        ArrayList pmData = new ArrayList();
                        dataTablePm.Clear();
                        pmData = (ArrayList)_inputData[secCd];
                        if (pmData != null && pmData.Count > 0)
                        {
                            for (int j = 0; j < pmData.Count; j++)
                            {
                                DataRow dataRowPm = dataTablePm.NewRow();
                                dataRowPm[COLUMN_PM_NO] = "";
                                dataRowPm[COLUMN_PM_SECCD] = pmData[j].ToString();
                                dataRowPm[COLUMN_PM_SECNM] = GetSectionName(pmData[j].ToString().Trim());
                                dataTablePm.Rows.Add(dataRowPm);

                            }
                        }

                        //　行を追加
                        DataRow dataRowPmbk = dataTablePm.NewRow();
                        dataRowPmbk[COLUMN_PM_NO] = "";
                        dataRowPmbk[COLUMN_PM_SECCD] = "";
                        dataRowPmbk[COLUMN_PM_SECNM] = "";
                        dataTablePm.Rows.Add(dataRowPmbk);
                    }
                }
                else
                {
                    dataTablePm.Clear();
                    //　行を追加
                    DataRow dataRowPmbk = dataTablePm.NewRow();
                    dataRowPmbk[COLUMN_PM_NO] = "";
                    dataRowPmbk[COLUMN_PM_SECCD] = "";
                    dataRowPmbk[COLUMN_PM_SECNM] = "";
                    dataTablePm.Rows.Add(dataRowPmbk);

                }
            }
            //　フォーマット設定
            else
            {
                if (cell.Column.Key == COLUMN_CSV_SECCD)
                {
                    if (!(cell.Value is DBNull))
                    {
                        if (!string.IsNullOrEmpty(cell.Value.ToString()))
                        {
                            int value = Convert.ToInt32(cell.Value.ToString());
                            cell.Value = value.ToString("0000000000");
                        }
                    }
                }
            }

            // ADD 20090807 張莉莉　
            // カーソルがPM拠点の名称へ移動した時に入力可能状態（セルがオレンジ色）となるように修正 
            this.Second_Grid.Rows[0].Cells[1].Activate();
            this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : キーが押された時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.First_Grid.ActiveCell == null) return;

            //this.First_Grid.Rows[rowIndex].Cells[1].Activate();
            this.First_Grid.PerformAction(UltraGridAction.EnterEditMode);

            UltraGrid uGrid = (UltraGrid)sender;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = (UltraGridCell)uGrid.ActiveCell;

            if (cell.Column.Key == COLUMN_CSV_SECCD)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(10, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                //int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                int _Rketa = this.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 比較関数
        /// </summary>
        /// <typeparam name="T">型指定</typeparam>
        /// <param name="condition">条件</param>
        /// <param name="valueOnTrue">Trueの時の値</param>
        /// <param name="valueOnFalse">Falseの時の値</param>
        /// <returns>条件により選択された値</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public T diverge<T>(bool condition, T valueOnTrue, T valueOnFalse)
        {
            if (condition)
            {
                return valueOnTrue;
            }
            else
            {
                return valueOnFalse;
            }
        }

        /// <summary>
        /// BeforeCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードが開始した時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Second_Grid_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            // IMEをひらがなモードにする
            this.First_Grid.ImeMode = System.Windows.Forms.ImeMode.Close;
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : キーが押された時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void Second_Grid_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (this.Second_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.Second_Grid.ActiveCell;

            if (cell.Column.Key == COLUMN_PM_SECCD)
            {
                // 編集モード中？
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// BeforeEnterEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 編集モードが開始した時に発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void First_Grid_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.First_Grid.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.First_Grid.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ActiveCellが開始時間の場合
            if (cell.Column.Key == COLUMN_CSV_SECCD)
            {
                if (!(cell.Value is DBNull) && !string.IsNullOrEmpty(cell.Value.ToString()))
                {
                    int value = Convert.ToInt32(cell.Value.ToString());
                    cell.Value = value.ToString();
                }
            }
        }

        // --------ADD 20090819 張莉莉　フォーカス移動の修正------>>>>>>>>>
        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date	   : 2009.05.10</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            if (e.PrevCtrl == this.Second_Grid)
            {
                if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                {
                    if (this.Second_Grid.ActiveCell == null)
                    {
                        this.Second_Grid.PerformAction(UltraGridAction.NextCell);
                        this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        return;
                    }

                    int activeRowIndex = this.Second_Grid.ActiveCell.Row.Index;
                    int activeColumnIndex = this.Second_Grid.ActiveCell.Column.Index;
                    // 拠点コード取得
                    string sectionCd = CellTextToString(this.Second_Grid.ActiveCell.Text);
                    if (string.Empty.Equals(sectionCd))
                    {
                        // 行クリア
                        ClearRow(activeRowIndex);
                        if (activeRowIndex != this.Second_Grid.Rows.Count - 1)
                        {
                            this.dataTablePm.AcceptChanges();
                            this.dataTablePm.Rows[activeRowIndex].Delete();
                        }
                        this.Second_Grid.Rows[activeRowIndex].Cells[activeColumnIndex].Activate();
                        this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        ArrayList nowPmData = new ArrayList();
                for (int i = 0; i < this.Second_Grid.Rows.Count; i++)
                {
                    // 画面のPMデータを取得
                    if (!string.IsNullOrEmpty(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text.ToString()))
                    {
                        nowPmData.Add(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text);
                    }
                }
                if (!string.IsNullOrEmpty(firstGridActiveStr))
                {
                    //　元データを削除する
                    if (_inputData.Contains(firstGridActiveStr))
                    {
                        _inputData.Remove(firstGridActiveStr);
                    }
                    //　今のデータをセーフ
                    if (nowPmData.Count > 0)
                    {
                        _inputData.Add(firstGridActiveStr, nowPmData);
                    }
                }
                        return;
                    }
                    
                    bool Scdstatus = CheckSectionCode(sectionCd);
                    if (!Scdstatus)
                    {
                        // 行クリア
                        ClearRow(activeRowIndex);
                        this.Second_Grid.Rows[activeRowIndex].Cells[activeColumnIndex].Activate();
                        this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        ArrayList nowPmData = new ArrayList();
                        for (int i = 0; i < this.Second_Grid.Rows.Count; i++)
                        {
                            // 画面のPMデータを取得
                            if (!string.IsNullOrEmpty(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text.ToString()))
                            {
                                nowPmData.Add(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text);
                            }
                        }
                        if (!string.IsNullOrEmpty(firstGridActiveStr))
                        {
                            //　元データを削除する
                            if (_inputData.Contains(firstGridActiveStr))
                            {
                                _inputData.Remove(firstGridActiveStr);
                            }
                            //　今のデータをセーフ
                            if (nowPmData.Count > 0)
                            {
                                _inputData.Add(firstGridActiveStr, nowPmData);
                            }
                        }
                        return;
                    }
                    else
                    {
                        if (activeRowIndex != this.Second_Grid.Rows.Count - 1)
                        {
                            this.Second_Grid.Rows[activeRowIndex + 1].Cells[activeColumnIndex].Activate();
                            this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            // 拠点名取得
                            this.Second_Grid.Rows[activeRowIndex].Cells[COLUMN_PM_SECNM].Value = GetSectionName(sectionCd);
                            this.Second_Grid.Rows[activeRowIndex].Cells[COLUMN_PM_SECCD].Value = sectionCd;
                            // 最終行だった場合、行追加
                            CreateNewRow(ref this.Second_Grid);    

                            this.Second_Grid.Rows[activeRowIndex + 1].Cells[activeColumnIndex].Activate();
                            this.Second_Grid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        e.NextCtrl = null;

                        ArrayList nowPmData = new ArrayList();
                        for (int i = 0; i < this.Second_Grid.Rows.Count; i++)
                        {
                            // 画面のPMデータを取得
                            if (!string.IsNullOrEmpty(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text.ToString()))
                            {
                                nowPmData.Add(this.Second_Grid.Rows[i].Cells[COLUMN_PM_SECCD].Text);
                            }
                        }
                        if (!string.IsNullOrEmpty(firstGridActiveStr))
                        {
                            //　元データを削除する
                            if (_inputData.Contains(firstGridActiveStr))
                            {
                                _inputData.Remove(firstGridActiveStr);
                            }
                            //　今のデータをセーフ
                            if (nowPmData.Count > 0)
                            {
                                _inputData.Add(firstGridActiveStr, nowPmData);
                            }
                        }
                        return;
                    }
                }
            }
        }
        // --------ADD 20090819 張莉莉　フォーカス移動の修正------<<<<<<<<<<
    }
}
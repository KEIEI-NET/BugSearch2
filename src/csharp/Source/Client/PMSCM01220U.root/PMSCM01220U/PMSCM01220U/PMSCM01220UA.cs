//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : マスタ取込処理                                          //
// プログラム概要   : マスタ取込処理                                          //
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : qianl                                     //
// 作 成 日  2011/08/01  修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaoy                                      //
// 修 正 日  2011/08/20  修正内容 : マスタ取込処理にての修正(Redmine#23848)   //
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Threading;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using System.Reflection;
using System.IO;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// マスタ取込処理フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : マスタ取込処理を行います。</br>
    /// <br>Programer  : qianl</br>
    /// <br>Date       : 2011/08/01</br>
    /// <br>Update Note: 障害報告 #23848対応</br>
    /// <br>Programmer : gaoy</br>
    /// <br>Date       : 2011.08.20</br>
    /// </remarks>
    public partial class PMSCM01220UA : Form
    {
        # region << Private Members >>

        private SFCMN00299CA _progressForm;

        private string _enterpriseCode;        //企業コード
        private string _sectionCode;           //拠点コード

        private PM7RkSetting _pM7RkSetting;            //PM7連携全体設定マスタ
        private PM7RkSettingAcs _pM7RkSettingAcs;      //PM7連携全体設定アクセスクラス

        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;        // ログイン担当者Title
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;         // ログイン担当者Name

        private ConvertList.ListDataTable ConvertDataList;

        private const string ctPGID = "PMSCM01220U";        //プログラムID

        private Dictionary<string, string> lstTblNm = new Dictionary<string, string>();

        private Dictionary<string, string> lstTableName = new Dictionary<string, string>();
        private ArrayList tableIdList = new ArrayList();
        private ArrayList tableNmList = new ArrayList();

        private StringBuilder TableIdString = null;

        # endregion

        # region << Constructor >>

        /// <summary>
        /// マスタ取込処理フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : マスタ取込処理フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programer  : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        public PMSCM01220UA()
        {
            InitializeComponent();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;              //企業コード
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;     //拠点コード

            this._pM7RkSetting = new PM7RkSetting();            //PM7連携全体設定マスタ
            this._pM7RkSettingAcs = new PM7RkSettingAcs();      //PM7連携全体設定アクセスクラス

            this._pM7RkSetting.EnterpriseCode = this._enterpriseCode;
            this._pM7RkSetting.SectionCode = this._sectionCode;

        }

        # endregion

        # region << コントロールイベントハンドラ >>

        /// <summary>
        /// フォームClose前イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォームが終了する前に発生します。</br>
        /// <br>Programer  : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void PMSCM01220UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// マスタ取込処理フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : マスタ取込処理フォームを初期化します。</br>
        /// <br>Programer  : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void PMSCM01220UA_Load(object sender, EventArgs e)
        {
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)ToolbarsManager_Main.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)ToolbarsManager_Main.Tools["LabelTool_LoginName"];
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;

            // ツールバーの設定
            this.SettingToolbar();

            //PM7連携設定マスタからテキスト格納フォルダを検索する
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                status = this._pM7RkSettingAcs.Read(ref this._pM7RkSetting);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.TextSaveFolder_tEdit.Text = this._pM7RkSetting.TextSaveFolder;

                }
                else
                {
                    this.TextSaveFolder_tEdit.Text = "";
                }
            }
            catch (Exception)
            {
                this.TextSaveFolder_tEdit.Text = "";
            }

            ConvertDataList = new ConvertList.ListDataTable();

            DataTable CustomersTable = new DataTable("Customers");
            DataRow row;
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "TableId";
            CustomersTable.Columns.Add(column);


            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "TableNm";
            CustomersTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "ReadDataCnt";
            CustomersTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "WriteDataCnt";
            CustomersTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Result";
            CustomersTable.Columns.Add(column);

            tableIdList.Add("GOODSMNG");
            tableIdList.Add("GOODSU");
            tableIdList.Add("GOODSPRICEU");
            tableIdList.Add("JOINPARTSU");
            tableIdList.Add("GOODSSET");
            tableIdList.Add("PRMSETTINGU");
            tableIdList.Add("PARTSSUBSTU");
            tableIdList.Add("RATE");
            tableIdList.Add("STOCK");
            tableIdList.Add("CARMANAGEMENT");
            tableIdList.Add("USERGDBDU");
            tableNmList.Add("商品管理情報マスタ");
            tableNmList.Add("商品マスタ（ユーザー登録分）");
            tableNmList.Add("価格マスタ");
            tableNmList.Add("結合マスタ(ユーザー登録）");
            tableNmList.Add("商品セットマスタ");
            tableNmList.Add("優良設定マスタ（ユーザー登録分）");
            tableNmList.Add("部品代替マスタ（ユーザー登録分）");
            tableNmList.Add("掛率マスタ");
            tableNmList.Add("在庫マスタ");
            tableNmList.Add("車両管理マスタ");
            tableNmList.Add("ユーザーガイドマスタ（ボディ）（ユーザ変更分）");
            try
            {
                for (int i = 0; i < tableIdList.Count; i++)
                {
                    row = CustomersTable.NewRow();
                    row["TableID"] = tableIdList[i].ToString();
                    row["TableNm"] = tableNmList[i].ToString();
                    row["ReadDataCnt"] = 0;
                    row["WriteDataCnt"] = 0;
                    row["Result"] = "";
                    CustomersTable.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                   ex.Message, 0, MessageBoxButtons.OK);
            }

            try
            {
                ConvertDataList.Merge(CustomersTable, false, MissingSchemaAction.Ignore);
                ConvertDataList.AcceptChanges();

                gridConvData.BeginUpdate();
                gridConvData.DataSource = ConvertDataList.DefaultView;

                //選択チェックボックスの初期値をONにします。
                for (int i = 0; i < gridConvData.Rows.Count; i++)
                {
                    this.gridConvData.Rows[i].Cells[ConvertDataList.TruncateFlgColumn.ColumnName].Value = true;
                }

                ConvertDataList.DefaultView.RowFilter = "Visible = True";
                gridConvData.EndUpdate();

                SetEnabledStockAcPayHist();
            }
            catch (Exception ex)
            {

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                    ex.Message, 0, MessageBoxButtons.OK);

                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                    "マスタ取込処理用設定ファイルを用意して下さい。", 0, MessageBoxButtons.OK);
                Close();
            }
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ツールバーがクリックされた時に発動します。</br>
        /// <br>Programer  : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void ToolbarsManager_Main_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Close_buttonTool":
                    // 終了ボタン
                    // メイン画面のクローズ
                    this.Close();
                    break;

                case "OK_buttonTool":
                    // 更新ボタン
                    if (ValidateInput())
                    {
                        ConvertData();
                    }
                    break;
            }

        }

        /// <summary>
        /// 入力バリデーション処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private bool ValidateInput()
        {
            bool returnbl = false;
            string query = "";

            if (TextSaveFolder_tEdit.Text.Trim() == "")
            {
                this.TextSaveFolder_tEdit.Clear();
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                                "テキスト格納フォルダを入力して下さい。", 0, MessageBoxButtons.OK);
                TextSaveFolder_tEdit.Focus();
                return returnbl;
            }
            if (Directory.Exists(TextSaveFolder_tEdit.Text) == false)
            {
                this.TextSaveFolder_tEdit.Clear();
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, Text,
                                "指定したテキスト格納フォルダが存在しません。", 0, MessageBoxButtons.OK);
                TextSaveFolder_tEdit.Focus();
                return returnbl;
            }

            ConvertList.ListRow[] rows = (ConvertList.ListRow[])ConvertDataList.Select(query);

            for (int ind = 0; ind < rows.Length; ind++)
            {
                if (rows[ind].TruncateFlg == true)
                {
                    returnbl = true;
                    break;
                }
            }
            if (returnbl==false)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, Text,
                                "マスタ取込処理対象を選んで下さい。", 0, MessageBoxButtons.OK);
                return returnbl;
            }
            return returnbl;
        }


        /// <summary>
        /// コンバート処理
        /// </summary>
        /// <remarks>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.08.01</br>
        /// <br>Update Note: 障害報告 #23848対応</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.08.20</br>
        /// </remarks>
        private void ConvertData()
        {
            string query = "";
            string table = string.Empty;
            ConvertDataList.AcceptChanges();
            string SaveFolder = this.TextSaveFolder_tEdit.Text.Trim();
            // コンバート対象のテーブル検索
            ConvertList.ListRow[] rows = (ConvertList.ListRow[])ConvertDataList.Select(query);
            if (rows.Length == 0)
                return;

            try
            {
                _progressForm = new SFCMN00299CA();

                _progressForm.Title = "マスタ取込処理";
                _progressForm.Message = "只今、マスタ取込処理中です．．．";


                StringBuilder selTableId = new StringBuilder();
                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i].ReadDataCnt = 0; // リードカウンタクリア
                    rows[i].WriteDataCnt = 0; // ライトカウンタクリア
                    rows[i].Result = string.Empty; // 処理結果クリア
                }

                _progressForm.Show(this);

                Refresh();

                string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");

                for (int ind = 0; ind < rows.Length; ind++)
                {
                    int readCnt = 0;

                    int updateCnt = 0;

                    string errMsg = "";

                    if (rows[ind].TruncateFlg == true)
                    {
                        SndAndRcvProcAcs sndAndRcvProcAcs = new SndAndRcvProcAcs();

                        int status = sndAndRcvProcAcs.SearchAndTextin(0, datetime, rows[ind].TableId, TextSaveFolder_tEdit.Text.Trim(), this._enterpriseCode, ref readCnt, ref updateCnt, ref errMsg);

                        if (readCnt == 0)
                        {
                            rows[ind].ReadDataCnt = readCnt;
                            rows[ind].WriteDataCnt = updateCnt;
                            if (errMsg != "" && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                rows[ind].Result = "更新" + updateCnt.ToString("#,##0") + "件。" + errMsg;
                            }
                            else
                            {
                                rows[ind].Result = "更新" + updateCnt.ToString("#,##0") + "件。対象CSVファイルが存在しません。";
                            }
                        }

                        if (readCnt != updateCnt && readCnt != 0)
                        {
                            int errCnt = readCnt - updateCnt;
                            rows[ind].ReadDataCnt = readCnt;
                            rows[ind].WriteDataCnt = updateCnt;
                            if (errMsg != "")
                            {
                                rows[ind].Result = "更新" + updateCnt.ToString("#,##0") + "件、エラー" + errCnt.ToString("#,##0") + "件。" + errMsg;

                            }
                            else
                            {
                                rows[ind].Result = "更新" + updateCnt.ToString("#,##0") + "件、エラー" + errCnt.ToString("#,##0") + "件。処理中エラーが発生しました。";
                            }
                        }

                        if (readCnt == updateCnt && readCnt != 0)
                        {
                            rows[ind].ReadDataCnt = readCnt;
                            rows[ind].WriteDataCnt = updateCnt;
                            //rows[ind].Result = "更新" + updateCnt.ToString("#,##0") + "件。エラーがありません。";       // DEL 2011.08.20 gaoy FOR 障害報告 #23848
                            rows[ind].Result = "更新" + updateCnt.ToString("#,##0") + "件。正常終了。";                   // ADD 2011.08.20 gaoy FOR 障害報告 #23848
                            
                        }
                    }
                }
            }
            finally
            {
                if (_progressForm != null)
                {
                    _progressForm.Close();
                    _progressForm = null;
                }
            }
        }

        /// <summary>
        /// Control.MouseHover イベント(uButton_DirGuide)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : テキスト格納フォルダボタンコントロールがMouseHoverされたときに発生します。</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void uButton_DirGuide_MouseHover(object sender, EventArgs e)
        {
            this.uButton_DirGuide.Refresh();
            this.toolTip1.SetToolTip(this.uButton_DirGuide, "テキスト格納フォルダガイド");
        }

        # endregion

        # region << プライベートメソッド >>

        /// <summary>
        /// ツールバーのアイコン設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : フレームのツールバーの設定を行います。</br>
        /// <br>Programer  : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void SettingToolbar()
        {
            //--------------------------------------------------------------
            // メインツールバー
            //--------------------------------------------------------------
            // イメージリストを設定する
            this.ToolbarsManager_Main.ImageListSmall = IconResourceManagement.ImageList16;

            uButton_DirGuide.ImageList = IconResourceManagement.ImageList16;
            uButton_DirGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            // 終了のアイコン設定
            ToolbarsManager_Main.Tools["Close_buttonTool"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 確定のアイコン設定
            ToolbarsManager_Main.Tools["OK_buttonTool"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;

        }

        # endregion

        #region  << ボタンイベント処理 >>

        /// <summary>
        /// Button.Click イベント(uButton_DirGuide_Click)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : テキスト格納フォルダボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void uButton_DirGuide_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            dlg.RootFolder = Environment.SpecialFolder.Desktop;
            dlg.Description = "テキスト格納フォルダを指定して下さい。";
            DialogResult ret = dlg.ShowDialog();
            if (ret == DialogResult.OK)
            {
                TextSaveFolder_tEdit.Text = dlg.SelectedPath;
            }
        }

        /// <summary>
        /// グリッドセット
        /// </summary>
        /// <remarks>
        /// <br>Note　　　 :なし</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void SetEnabledStockAcPayHist()
        {
            for (int rowIndex = 0; rowIndex < gridConvData.Rows.Count; rowIndex++)
            {
                if ((string)gridConvData.Rows[rowIndex].Cells["TableId"].Value == "STOCKACPAYHISTRF")
                {
                    gridConvData.Rows[rowIndex].Cells["TruncateFlg"].Activation = Activation.Disabled;
                }
                else
                {
                    gridConvData.Rows[rowIndex].Cells["TruncateFlg"].Activation = Activation.AllowEdit;
                }
            }
        }

        #endregion

        #region  << グリッドイベント処理 >>

        /// <summary>
        /// グリッド イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void gridConvData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            TableIdString = new StringBuilder();

            e.Layout.Override.CellAppearance.TextVAlign = VAlign.Middle;
            UltraGridBand band0 = e.Layout.Bands[0];
            band0.Columns[ConvertDataList.TableIdColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.ConvKindColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.PrevResultColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.CsvCountColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.VisibleColumn.ColumnName].Hidden = true;
            band0.Columns[ConvertDataList.DeployColumn.ColumnName].Hidden = true;

            band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].Width = 40;
            band0.Columns[ConvertDataList.TableNmColumn.ColumnName].Width = 370;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].Width = 80;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].Width = 420;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].Header.Appearance.TextHAlign = HAlign.Left;

            band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].CellClickAction = CellClickAction.CellSelect;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            band0.Columns[ConvertDataList.ReadDataCntColumn.ColumnName].Format = "###,###,##0";
            band0.Columns[ConvertDataList.WriteDataCntColumn.ColumnName].Format = "###,###,##0";

            band0.Columns[ConvertDataList.TableNmColumn.ColumnName].Header.Fixed = true;
            band0.Columns[ConvertDataList.TruncateFlgColumn.ColumnName].Header.Fixed = true;
            band0.Columns[ConvertDataList.ResultColumn.ColumnName].AutoSizeMode = ColumnAutoSizeMode.VisibleRows;

        }

        /// <summary>
        /// グリッド イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void gridConvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridConvData.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Space)
                {
                    // [削除]カラムの値を設定
                    bool truncateFlag = (bool)this.gridConvData.ActiveRow.Cells[ConvertDataList.TruncateFlgColumn.ColumnName].Value;
                    this.gridConvData.ActiveRow.Cells[ConvertDataList.TruncateFlgColumn.ColumnName].Value = !truncateFlag;
                }
            }
        }

        /// <summary>
        /// グリッド イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void gridConvData_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            
            bool val = !((bool)e.Cell.Value);
            e.Cell.Value = val;

            if (gridConvData.Selected.Rows.Count == 0 || e.Cell.Row != gridConvData.Selected.Rows[0])
                e.Cell.Row.Selected = true;
            e.Cancel = true;
        }

        /// <summary>
        /// グリッド イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void gridConvData_Enter(object sender, EventArgs e)
        {
            if (gridConvData.ActiveRow != null)
            {
                gridConvData.ActiveRow.Selected = true;
            }
            else
            {
                if (gridConvData.Rows.Count > 0)
                {
                    gridConvData.Rows[0].Activate();
                    gridConvData.Rows[0].Selected = true;
                }
            }
        }

        /// <summary>
        /// グリッド イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void gridConvData_Leave(object sender, EventArgs e)
        {
            gridConvData.Selected.Rows.Clear();
        }

        /// <summary>
        /// グリッド インフォセット
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
        {
            System.Drawing.Size sizeHeader = new Size();
            System.Drawing.Size sizeCell = new Size();

            Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

            Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
            Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
            Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

            sizeCell.Height = 20;
            sizeCell.Width = width;
            Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            sizeHeader.Height = 20;
            sizeHeader.Width = width;
            Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

        }

        #endregion

        #region  << フォーカス制御 >> 

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011/08/01</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == uButton_DirGuide)
            {
                if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                {
                    gridConvData.Rows[0].Activate();
                }
            }
            if (e.PrevCtrl == TextSaveFolder_tEdit)
            {
                if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    gridConvData.Rows[gridConvData.Rows.Count - 1].Activate();
                }
            }
           
            if (e.PrevCtrl == gridConvData)
            {
                if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    if (gridConvData.ActiveRow != null && gridConvData.ActiveRow.Index > 0)
                    {
                        UltraGridRow ugr = gridConvData.ActiveRow.GetSibling(SiblingRow.Previous);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        if (gridConvData.ActiveRow.Index >= 0)
                        {
                            e.NextCtrl = gridConvData;
                        }
                    }
                }

                else if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                {
                    if (gridConvData.ActiveRow != null
                    && gridConvData.ActiveRow.Index < gridConvData.Rows.Count - 1)
                    {
                        UltraGridRow ugr = gridConvData.ActiveRow.GetSibling(SiblingRow.Next);
                        if (ugr != null)
                        {
                            ugr.Activate();
                            ugr.Selected = true;
                        }
                        if (gridConvData.ActiveRow.Index <= gridConvData.Rows.Count - 1)
                        {
                            e.NextCtrl = gridConvData;
                        }
                    }
                }
            }
        }

        #endregion

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
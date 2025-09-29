using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// DSPログデータ照会UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : DSPログデータ照会UIフォームクラス</br>
    /// <br>Programmer  : 30350 櫻井 亮太</br>
    /// <br>Date        : 2008/12/02</br>
    /// <br>Update Note : 2009/03/12 30414 忍 幸史 障害ID:12288対応</br>
    /// </remarks>
    public partial class PMUOE04301UA : Form
    {
        #region Constants

        // アセンブリID
        private const string ASSMBLY_ID = "PMUOE04301U";

        // グリッド列
        private const string COLUMN_TITLE = "Title";
        private const string COLUMN_DATE = "Date";
        private const string COLUMN_MACHINENO = "MachineNo";
        private const string COLUMN_UOESUPPL = "UOESuppl";
        private const string COLUMN_DIV = "Div";
        private const string COLUMN_PGID = "PGID";
        private const string COLUMN_ST = "status";
        private const string COLUMN_MESSAGE = "Message";

        // 端末番号combobox

        private PosTerminalMgAcs _posTerminalMgAcs;
        private PosTerminalMg posTerminalMg;

        #endregion Constants


        #region Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private string _sectionCode;

        private OprationLogOrderAcs _oprationLogOrderAcs;

        private UOESupplier _uOESupplier;

        private UOESupplierAcs _uOESupplierAcs;

        private const string MY_TERMINALNO = "自端末";
        private const int MY_TERMINALNO_VALUE = 0;

        private const string AW_TERMINALNO = "他端末";
        private const int AW_TERMINALNO_VALUE = 1;

        private const string AL_TERMINALNO = "全端末";
        private const int AL_TERMINALNO_VALUE = 2;

        #endregion


        #region Constructor

        /// <summary>
        /// DSPログデータ照会UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : DSPログデータ照会UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/12/02</br>
        /// </remarks>
        public PMUOE04301UA()
		{

			InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            
            this._oprationLogOrderAcs = new OprationLogOrderAcs();

            this._uOESupplier = new UOESupplier();

            this._uOESupplierAcs = new UOESupplierAcs();

            this._posTerminalMgAcs = new PosTerminalMgAcs();

            this.posTerminalMg = new PosTerminalMg();

            // 画面クリア
            ClearScreen();

            // 画面初期設定
            SetInitialSetting();

            //ログイン担当
            SetLogin();

            
        }

        #endregion


        #region Private Methods

        private void SetLogin()
        {
            // ログイン担当者へのアイコン設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LoginTitle_LabelToo2"];
            if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // ログイン担当者表示
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LoginName_LabelToo1"];
            if (LoginInfoAcquisition.Employee != null)
            {
                if (loginNameLabel != null) loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }
        }

        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // 画面スキンファイルの読込(デフォルトスキン指定)
            //---------------------------------
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            //excCtrlNm.Add(this.Standard_UGroupBox.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // コントロールサイズ設定
            //this.tEdit_SectionCodeAllowZero.Size = new Size(28, 24);
            //this.tEdit_SectionName.Size = new Size(175, 24);

            //---------------------------------
            // アイコン設定
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            // --- CHG 2009/03/12 障害ID:12288対応------------------------------------------------------>>>>>
            //workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            // --- CHG 2009/03/12 障害ID:12288対応------------------------------------------------------<<<<<
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Initialization "];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;

            ImageList imageList16 = IconResourceManagement.ImageList16;

            //---------------------------------
            // グリッド設定
            //---------------------------------
            CreateGrid(new List<DspRogDataResult>());
            SetGridLayout();

            if (posTerminalMg != null)
                tEdit_TerminalNo.Enabled = false;
            else
                tEdit_TerminalNo.Enabled = true;

            this.TerminalNo_tComboEditor.Focus();
        }

        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// 
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/12/03</br>
        /// </remarks>
        private void ClearScreen()
        {
            this.tNedit_UOESupplierCd.Clear();
            this.tEdit_UOESupplierNm.Clear();
            this.TerminalNo_tComboEditor.SelectedIndex = 0;
            this.tDateEdit_StAddUpDate.Clear();
            this.tDateEdit_EdAddUpDate.SetDateTime(DateTime.Now);
            if (posTerminalMg != null)
            {
                this.tEdit_TerminalNo.Text = this.posTerminalMg.CashRegisterNo.ToString().PadLeft(3,'0');
            }
            
            // グリッド
            CreateGrid(new List<DspRogDataResult>());

            // フォーカス設定
            this.TerminalNo_tComboEditor.Focus();
        }

        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="updHisDspWorkList">更新履歴リスト</param>
        /// <remarks>
        /// <br>Note        : グリッドを作成します。</br>
        /// <br>Programmer  : 3050 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        private void CreateGrid(List<DspRogDataResult> dspRogDataResultList)
        {
            //--------------------------------------
            // グリッド列、データ設定
            //--------------------------------------
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(COLUMN_TITLE, typeof(Int32));
            dataTable.Columns.Add(COLUMN_DATE, typeof(string));
            dataTable.Columns.Add(COLUMN_MACHINENO, typeof(string));
            dataTable.Columns.Add(COLUMN_UOESUPPL, typeof(string));
            dataTable.Columns.Add(COLUMN_DIV, typeof(string));
            dataTable.Columns.Add(COLUMN_PGID, typeof(string));
            dataTable.Columns.Add(COLUMN_ST, typeof(Int32));
            dataTable.Columns.Add(COLUMN_MESSAGE, typeof(string));
            string[] titleArray = new string[dspRogDataResultList.Count];
            if (dspRogDataResultList.Count != 0)
            {
                for (int i =0; i < dspRogDataResultList.Count; i++)
                {
                    titleArray[i] = (i+1).ToString();
                }
            }
            if (dspRogDataResultList.Count != 0)
            {
                for (int index = 0; index < dspRogDataResultList.Count; index++)
                {
                    DataRow dataRow = dataTable.NewRow();

                    dataRow[COLUMN_TITLE] = Int32.Parse(titleArray[index]);
                    dataRow[COLUMN_DATE] = "";
                    dataRow[COLUMN_MACHINENO] = "";
                    dataRow[COLUMN_DIV] = "";
                    dataRow[COLUMN_PGID] = "";
                    //dataRow[COLUMN_ST] = "";
                    dataRow[COLUMN_MESSAGE] = "";

                    dataTable.Rows.Add(dataRow);
                }
            }
            this.uGrid_Details.DataSource = dataTable;
            this.uGrid_Details.ActiveRow = null;
        }

        /// <summary>
        /// グリッドレイアウト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドレイアウトを設定します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        private void SetGridLayout()
        {
            //--------------------------------------
            // グリッド外観設定
            //--------------------------------------
            ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // キャプション
            columns[COLUMN_TITLE].Header.Caption = "No";
            columns[COLUMN_DATE].Header.Caption = "日付";
            columns[COLUMN_MACHINENO].Header.Caption = "マシン番号";
            columns[COLUMN_UOESUPPL].Header.Caption = "発注先";
            columns[COLUMN_DIV].Header.Caption = "区分";
            columns[COLUMN_PGID].Header.Caption = "プログラムＩＤ";
            columns[COLUMN_ST].Header.Caption = "ＳＴ";
            columns[COLUMN_MESSAGE].Header.Caption = "メッセージ";

            // 列幅
            columns[COLUMN_TITLE].Width = 45;
            columns[COLUMN_DATE].Width = 160;
            columns[COLUMN_MACHINENO].Width = 100;
            columns[COLUMN_UOESUPPL].Width = 80;
            columns[COLUMN_DIV].Width = 108;
            columns[COLUMN_PGID].Width = 160;
            columns[COLUMN_ST].Width = 65;
            columns[COLUMN_MESSAGE].Width = 220;

            // テキスト位置(HAlign)
            columns[COLUMN_TITLE].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_DATE].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_MACHINENO].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_UOESUPPL].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_DIV].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_PGID].CellAppearance.TextHAlign = HAlign.Left;
            columns[COLUMN_ST].CellAppearance.TextHAlign = HAlign.Right;
            columns[COLUMN_MESSAGE].CellAppearance.TextHAlign = HAlign.Left;

            // テキスト位置(VAlign)
            columns[COLUMN_TITLE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_DATE].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_MACHINENO].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_UOESUPPL].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_DIV].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_PGID].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_ST].CellAppearance.TextVAlign = VAlign.Middle;
            columns[COLUMN_MESSAGE].CellAppearance.TextVAlign = VAlign.Middle;

            // セルカラー
            columns[COLUMN_TITLE].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            columns[COLUMN_TITLE].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            columns[COLUMN_TITLE].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[COLUMN_TITLE].CellAppearance.ForeColor = Color.White;
            columns[COLUMN_TITLE].CellAppearance.ForeColorDisabled = Color.White;
        
        }

        /// <summary>
        /// DSPログデータ照会抽出結果画面表示処理
        /// </summary>
        /// <param name="shipmentPartsDspResultList">出荷部品照会抽出結果リスト</param>
        /// <remarks>
        /// <br>Note        : 出荷部品照会抽出結果リストを画面表示します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/12/03</br>
        /// </remarks>
        private void DspRogDataResultToScreen(List<DspRogDataResult> dspRogDataResultList)
        {
            if (dspRogDataResultList == null)
            {
                return;
            }
            int i = 0;
            foreach (DspRogDataResult dspRogDataResult in dspRogDataResultList)
            {
                // 日付
                this.uGrid_Details.Rows[i].Cells[COLUMN_DATE].Value = dspRogDataResult.Date;
                // 端末番号
                this.uGrid_Details.Rows[i].Cells[COLUMN_MACHINENO].Value = dspRogDataResult.TerminalNo;
                // 発注先
                if (dspRogDataResult.UOESupplierCd != 0)
                {
                    this.uGrid_Details.Rows[i].Cells[COLUMN_UOESUPPL].Value = dspRogDataResult.UOESupplierCd.ToString().PadLeft(6, '0');
                }
                // 区分
                if (dspRogDataResult.DspDiv == 0)
                    this.uGrid_Details.Rows[i].Cells[COLUMN_DIV].Value = "開始";
                else if (dspRogDataResult.DspDiv == 14)
                    this.uGrid_Details.Rows[i].Cells[COLUMN_DIV].Value = "終了";
                else
                    this.uGrid_Details.Rows[i].Cells[COLUMN_DIV].Value = "エラー終了";
                // プログラムID
                this.uGrid_Details.Rows[i].Cells[COLUMN_PGID].Value = dspRogDataResult.DspPGID;
                // ステータス
                this.uGrid_Details.Rows[i].Cells[COLUMN_ST].Value = dspRogDataResult.DspStatus;
                // メッセージ
                this.uGrid_Details.Rows[i].Cells[COLUMN_MESSAGE].Value = dspRogDataResult.DspMessage;

                i++;
            }
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 確定処理を行います。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        private void Search()
        {
            // 画面情報チェック
            bool bStatus = CheckScreenInput();
            if (!bStatus)
            {
                return;
            }

            // 検索条件格納
            OprationLogOrderParam extrInfo;
            SetExtrInfo(out extrInfo);

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "DSPログデータの抽出中です。";

            int status;
            List<DspRogDataResult> dspRogDataResultList;

            try
            {
                msgForm.Show();

               // 検索処理
                status = this._oprationLogOrderAcs.Search(extrInfo, out dspRogDataResultList);
                if (status == 0)
                {

                    SetGridLayout();
                    CreateGrid(dspRogDataResultList);

                    // 画面表示
                    DspRogDataResultToScreen(dspRogDataResultList);
                    return;
                }
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Search",
                                       "ログデータがありません。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッド情報クリア
                        CreateGrid(new List<DspRogDataResult>());
                        return;
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Search",
                                       "確定処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッド情報クリア
                        CreateGrid(new List<DspRogDataResult>());
                        return;
                    }
            }
        }
        /// <summary>
        /// ログ初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ログ初期化処理を行います。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/12/03</br>
        /// </remarks>
        private void Delete()
        {
            if (TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_QUESTION, "Delete",
                "ログデータを初期化しますか？",
                -1, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            // 検索条件格納
            OprationLogOrderParam opParam = new OprationLogOrderParam();
            opParam.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            string[] str = new string[1];
            for (int i = 0; i < 1; i++)
            {
                str[i] = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            if (str.Length != 0)
            {
                opParam.SectionCodes = str;
            }
            opParam.LogDataKindCd = 10;

            // ログ初期化中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "初期化中";
            msgForm.Message = "DSPログデータの初期化中です。";

            int status;
            try
            {
                msgForm.Show();

                // 検索処理
                status = this._oprationLogOrderAcs.Delete(opParam);
            }
            finally
            {
                msgForm.Close();
            }
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "Delete",
                                       "ログデータがありません。",
                                       status,
                                       MessageBoxButtons.OK);
                        return;
                    }
            }
        }

        /// <summary>
        /// 画面情報チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 画面情報をチェックします。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/12/03</br>
        /// </remarks>
        private bool CheckScreenInput()
        {
            string errMsg = "";

            try
            {
                //日付入力チェック
                if (this.tDateEdit_StAddUpDate.LongDate > this.tDateEdit_EdAddUpDate.LongDate)
                {
                    errMsg = this.AddUpDateLabel.Text + "の入力範囲が不正です。";
                    return (false);
                }
                if (this.TerminalNo_tComboEditor.SelectedIndex == 0 && tEdit_TerminalNo.DataText == "")
                {
                    errMsg = "端末管理設定を行って下さい。";
                    return (false);
                }
                if (this.TerminalNo_tComboEditor.SelectedIndex == 1 && tEdit_TerminalNo.DataText == "")
                {
                    errMsg = TerminalNoLabel.Text + "を入力して下さい。";
                    return (false);
                }

            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 検索条件格納処理
        /// </summary>
        /// <param name="extrInfo">検索条件(明示的にoutパラメータで渡します)</param>
        /// <remarks>
        /// <br>Note        : 検索条件を格納します。</br>
        /// <br>Programmer  : 30350 櫻井　亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        private void SetExtrInfo(out OprationLogOrderParam extrInfo)
        {
            extrInfo = new OprationLogOrderParam();

            // 企業コード
            extrInfo.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 拠点コード


                string[] str = new string[1];
                for (int i = 0; i < 1; i++)
                {
                    str[i] = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                }
                if (str.Length != 0)
                {
                    extrInfo.SectionCodes = str;
                }

            // 端末番号
            if(this.TerminalNo_tComboEditor.SelectedIndex == 1)
                extrInfo.LogDataMachineName = tEdit_TerminalNo.DataText.PadLeft(3,'0');
            if (this.TerminalNo_tComboEditor.SelectedIndex == 0)
                extrInfo.LogDataMachineName = this.posTerminalMg.CashRegisterNo.ToString().PadLeft(3,'0');
            // 発注先
            if (tNedit_UOESupplierCd.DataText != "")
            {
                extrInfo.LogDataObjClassID = tNedit_UOESupplierCd.DataText.ToString().PadLeft(6, '0');
            }

            // 対象日付（開始）
            extrInfo.St_LogDataCreateDateTime = tDateEdit_StAddUpDate.GetDateTime();
            // 対象日付（終了）
            extrInfo.Ed_LogDataCreateDateTime = tDateEdit_EdAddUpDate.GetDateTime();
            // ログデータ種別区分コード
            extrInfo.LogDataKindCd = 10;
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._oprationLogOrderAcs,			// エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        #endregion Private Methods


        #region Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/12/03</br>
        /// </remarks>
        private void PMUOE04301UA_Load(object sender, EventArgs e)
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
            this.UOESupplierGuide_Button.ImageList = imageList16;
            this.UOESupplierGuide_Button.Appearance.Image = Size16_Index.STAR1;

            this.TerminalNo_tComboEditor.Items.Clear();
            this.TerminalNo_tComboEditor.Items.Add(MY_TERMINALNO_VALUE, MY_TERMINALNO);
            this.TerminalNo_tComboEditor.Items.Add(AW_TERMINALNO_VALUE, AW_TERMINALNO);
            this.TerminalNo_tComboEditor.Items.Add(AL_TERMINALNO_VALUE, AL_TERMINALNO);
            this.TerminalNo_tComboEditor.MaxDropDownItems = this.TerminalNo_tComboEditor.Items.Count;

            int status = _posTerminalMgAcs.Search(out posTerminalMg, _enterpriseCode);
            if (status != 0)
            {
                this.tEdit_MyTerminalCode.DataText = "";
                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "端末管理設定を行ってください。",
                                -1,
                                MessageBoxButtons.OK);

            }
            else
            {
                this.tEdit_MyTerminalCode.DataText = posTerminalMg.CashRegisterNo.ToString().PadLeft(3, '0');
            }
            ClearScreen();
        }
        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : コンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/12/03</br>
        /// </remarks>
        private void TerminalNo_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            this.tEdit_TerminalNo.Clear();
            if (this.TerminalNo_tComboEditor.Text == MY_TERMINALNO)
            {
                if (posTerminalMg != null)
                {
                    this.tEdit_TerminalNo.DataText = this.posTerminalMg.CashRegisterNo.ToString().PadLeft(3, '0');
                    this.tEdit_TerminalNo.Enabled = false;
                }
                else
                {
                    this.tEdit_TerminalNo.Enabled = false;
                }

            }
            else if (this.TerminalNo_tComboEditor.Text == AL_TERMINALNO)
            {
                this.tEdit_TerminalNo.DataText = "";
                this.tEdit_TerminalNo.Enabled = false;
            }
            else if (this.TerminalNo_tComboEditor.Text == AW_TERMINALNO)
            {
                this.tEdit_TerminalNo.Enabled = true;
            }
        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        Search();
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // クリア処理
                        ClearScreen();
                        break;
                    }
                case "ButtonTool_Initialization ":
                    {
                        // ログ初期化処理
                        Delete();
                        break;
                    }
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30350 櫻井 亮太</br>
        /// <br>Date        : 2008/11/17</br>
        /// </remarks>
        private void UOESupplier_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                UOESupplier uOESupplier;

                int status = this._uOESupplierAcs.ExecuteGuid(this._enterpriseCode, this._sectionCode, out uOESupplier);
                if (status == 0)
                {
                    this.tNedit_UOESupplierCd.DataText = uOESupplier.UOESupplierCd.ToString().PadLeft(6, '0');
                    this.tEdit_UOESupplierNm.DataText = uOESupplier.UOESupplierName.Trim();

                    // フォーカス設定
                    this.tDateEdit_StAddUpDate.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        ///// <summary>
        ///// ExpandedStateChanged イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントハンドラ</param>
        ///// <remarks>
        ///// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        ///// <br>Programmer  : 30414 忍 幸史</br>
        ///// <br>Date        : 2008/11/10</br>
        ///// </remarks>
        //private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        //{
        //    Size topSize = new Size();

        //    topSize.Width = this.Form1_Top_Panel.Size.Width;
        //    topSize.Height = 20;

        //    if (this.Standard_UGroupBox.Expanded == true)
        //    {
        //        topSize.Height = 210;
        //    }
        //    else
        //    {
        //        topSize.Height = 20;
        //    }

        //    this.Form1_Top_Panel.Size = topSize;
        //}

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveRow.Index;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            this.tDateEdit_StAddUpDate.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex - 1].Activate();
                            this.uGrid_Details.Rows[rowIndex - 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex + 1].Activate();
                            this.uGrid_Details.Rows[rowIndex + 1].Selected = true;
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        // グリッド表示を右にスクロール
                        this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position + 40;
                        break;
                    }
                case Keys.Left:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;
                        if (this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position != 0)
                        {
                            // グリッド表示を左にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position - 40;
                        }
                        break;
                    }
                case Keys.Home:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = 0;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 先頭行に移動
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid);
                        }
                        break;
                    }
                case Keys.End:
                    {
                        // キーが押されたことによるデフォルトのグリッド動作をキャンセルする
                        e.Handled = true;

                        // 他キーとの組合せ無しの場合
                        if (e.Modifiers == Keys.None)
                        {
                            // グリッド表示を左先頭にスクロール
                            this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Position = this.uGrid_Details.DisplayLayout.ColScrollRegions[0].Range;
                        }

                        // Controlキーとの組合せの場合
                        if (e.Modifiers == Keys.Control)
                        {
                            // 最終行に移動
                            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInGrid);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドが非アクティブになった時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;

            for (int index = 0; index < this.uGrid_Details.Rows.Count; index++)
            {
                this.uGrid_Details.Rows[index].Selected = false;
            }
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる度に時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2008/11/10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.TerminalNo_tComboEditor.Focus();

            // グリッドのアクティブ行を削除
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/11/10</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 発注先コード
            if (e.PrevCtrl == this.tNedit_UOESupplierCd)
            {
                this.tNedit_UOESupplierCd.DataText =  tNedit_UOESupplierCd.DataText.ToString().PadLeft(6, '0');

                UOESupplier uOESupplier = new UOESupplier();
                UOESupplierAcs uOESupplierAcs = new UOESupplierAcs();

                uOESupplierAcs.Read(out uOESupplier, this._enterpriseCode, this.tNedit_UOESupplierCd.GetInt(), this._sectionCode);

                if (this.tNedit_UOESupplierCd.DataText != "")
                {
                    if (uOESupplier != null && uOESupplier.LogicalDeleteCode != 1)
                    {
                        this.tEdit_UOESupplierNm.DataText = uOESupplier.UOESupplierName;
                        if (e.Key == Keys.Enter)
                        {
                            e.NextCtrl = tDateEdit_StAddUpDate;
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "該当する発注先が存在しません。",
                        -1,
                        MessageBoxButtons.OK);

                        this.tNedit_UOESupplierCd.Clear();
                        this.tEdit_UOESupplierNm.Clear();
                        e.NextCtrl = this.UOESupplierGuide_Button;
                    }
                }
                else
                {
                    this.tEdit_UOESupplierNm.DataText = "全て";
                    if(e.Key == Keys.Enter)
                    e.NextCtrl = tDateEdit_StAddUpDate;
                }

            }
            if (e.PrevCtrl == this.tEdit_MyTerminalCode)
            {
                if (e.Key == Keys.Down)
                {
                    e.NextCtrl = e.PrevCtrl;
                }
            }
            if (e.PrevCtrl == this.TerminalNo_tComboEditor)
            {
                if (e.Key == Keys.Enter)
                {
                    if (this.TerminalNo_tComboEditor.SelectedIndex == 1)
                    {
                        e.NextCtrl = tEdit_TerminalNo;
                    }
                    else
                    {
                        e.NextCtrl = tNedit_UOESupplierCd;
                    }
                }
            }
            if (e.PrevCtrl == this.tEdit_TerminalNo)
            {
                if (e.Key == Keys.Enter)
                {
                    e.NextCtrl = tNedit_UOESupplierCd;
                }
                this.tEdit_TerminalNo.DataText = this.tEdit_TerminalNo.DataText.PadLeft(3, '0');
                if (this.tEdit_TerminalNo.DataText == "000")
                    this.tEdit_TerminalNo.DataText = "";
            }
            if (e.PrevCtrl == this.UOESupplierGuide_Button)
            {
                if (e.Key == Keys.Enter)
                {
                    e.NextCtrl = tDateEdit_StAddUpDate;
                }
            }
            if (e.PrevCtrl == this.tDateEdit_EdAddUpDate)
            {
                if (e.Key == Keys.Enter)
                {
                    e.NextCtrl = TerminalNo_tComboEditor;
                }
            }
            // グリッド
            if (e.PrevCtrl == this.uGrid_Details)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        if (this.uGrid_Details.Rows.Count != 0)
                        {
                            if (this.uGrid_Details.ActiveRow == null)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Rows[0].Activate();
                                this.uGrid_Details.Rows[0].Selected = true;
                            }
                            else
                            {
                                int rowIndex = this.uGrid_Details.ActiveRow.Index;
                                if (rowIndex != this.uGrid_Details.Rows.Count - 1)
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[rowIndex + 1].Activate();
                                    this.uGrid_Details.Rows[rowIndex + 1].Selected = true;
                                }
                            }
                        }
                    }
                    return;
                }
                else
                {
                    if (this.uGrid_Details.Rows.Count != 0)
                    {
                        if (e.Key == Keys.Tab)
                        {
                            if (this.uGrid_Details.ActiveRow == null)
                            {
                                e.NextCtrl = null;
                                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                                this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Selected = true;
                            }
                            else
                            {
                                int rowIndex = this.uGrid_Details.ActiveRow.Index;
                                if (rowIndex != 0)
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[rowIndex - 1].Activate();
                                    this.uGrid_Details.Rows[rowIndex - 1].Selected = true;
                                }
                                //else
                                //{
                                //    if (this.WarehouseDiv_tComboEditor.SelectedIndex == 0)
                                //        e.NextCtrl = this.tEdit_WarehouseCode_Ed;
                                //    else
                                //        e.NextCtrl = this.tEdit_warehouseCd10;
                                //}
                            }
                        }
                        return;
                    }
                }
            }
            if (e.PrevCtrl == tDateEdit_StAddUpDate)
            {
                if (this.uGrid_Details.Rows.Count == 0)
                {
                    if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
            }
            if (e.PrevCtrl == tDateEdit_EdAddUpDate)
            {
                if (this.uGrid_Details.Rows.Count == 0)
                {
                    if (e.Key == Keys.Down)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
            }
                        // グリッド
            if (e.NextCtrl == this.uGrid_Details)
            {
                if (this.uGrid_Details.Rows.Count != 0)
                {
                    if (e.ShiftKey == false)
                    {
                        this.uGrid_Details.Rows[0].Activate();
                        this.uGrid_Details.Rows[0].Selected = true;
                        return;
                    }
                    else
                    {
                        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Activate();
                        this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Selected = true;
                    }
                }
                else
                {
                    if (e.ShiftKey == false)
                    {
                        //e.NextCtrl = this.TerminalNo_tComboEditor;
                    }
                    else
                    {
                        e.NextCtrl = this.tDateEdit_EdAddUpDate;
                    }
                }
            }
     
        }

        #endregion Control Events

        private void uGrid_Details_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void AddUpDateLabel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Top_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ultraExpandableGroupBoxPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ultraCombo4_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }

        private void tEdit_SectionName_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tNedit_UOESupplierCd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Top_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Standard_UGroupBox_ExpandedStateChanging(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Top_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
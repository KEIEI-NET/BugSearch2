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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 納入先確認画面フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 納入先確認画面のフォームクラスです。</br>
    /// <br>Programmer	: 20056　對馬 大輔</br>
    /// <br>Date		: 2007.09.28</br>
    /// </remarks>
    public partial class DCHNB01050UA : Form
    {
        #region■Constructor

        public DCHNB01050UA()
		{
			InitializeComponent();

			// 変数初期化
            this._addresseeAcs = new AddresseeAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._customerInfoAcs.IsLocalDBRead = this._addresseeAcs.IsLocalDBRead;
            this._imageList16 = IconResourceManagement.ImageList16;

			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Decision"];
            this._undoButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            this._changeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ChangeAddress"];

        }

        #endregion

        #region■Private Member

        private AddresseeAcs _addresseeAcs;                             // 請求確認画面アクセスクラス
        private CustomerInfoAcs _customerInfoAcs;                               // 得意先アクセスクラス
		
        private ImageList _imageList16 = null;									// イメージリスト
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// 確定ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		// 取消ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _changeButton;		// 住所切替ボタン
        private DialogResult _dialogRes = DialogResult.Cancel;                  // ダイアログリザルト
        private Addressee _addresseeOriginal;                           // 請求確認画面（初期表示）

        private AddresseeAcs.GuideMode _guideMode = AddresseeAcs.GuideMode.Addressee;//ガイドモード
        private string _addresseeName = "";//納入先名称
        private string _addresseeName2 = "";//納入先名称２
        private string _addresseeAddr1 = "";//納入先住所１
        private int _addresseeAddr2 = 0;//納入先住所２
        private string _addresseeAddr3 = "";//納入先住所３
        private string _addresseeAddr4 = "";//納入先住所４
        private string _addresseeTelNo = "";//納入先電話番号
        private string _addresseeFaxNo = "";//納入先FAX番号
        private string _addresseePostNo = "";//納入先郵便番号

        private int _addresseeCode = 0; // 納入先コード
        private int _customerCode = 0; // 得意先コード
        private int _claimCode = 0; // 請求先コード

        private bool _isLocalDBRead = true;
        #endregion

        #region ■Property
        /// <summary>ガイドモードプロパティ</summary>
        public AddresseeAcs.GuideMode GuideMode
        {
            get
            {
                if (_addresseeAcs.Addressee == null)
                {
                    return 0;
                }
                else
                {
                    return this._guideMode;
                }
            }
        }
        /// <summary>納入先確認画面クラスプロパティ</summary>
        public Addressee Addressee
        {
            get
            {
                if (_addresseeAcs.Addressee == null)
                {
                    return null;
                }
                else
                {
                    return _addresseeAcs.Addressee;
                }
            }
        }
        /// <summary>ローカルDB読み込みモードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set
            {
                _isLocalDBRead = value;
                this._addresseeAcs.IsLocalDBRead = value;
            }
        }
        #endregion

        #region ■Public Method
        /// <summary>
        /// 呼出制御処理
        /// </summary>
        /// <param name="owner">呼出元オブジェクト</param>
        /// <param name="addressee">納入先情報</param>
        /// <param name="addresseeCode">納入先コード</param>
        /// <param name="CustomerCode">得意先コード</param>
        /// <param name="ClaimCode">請求先コード</param>
        /// <param name="guideMode">ガイドモード(1:得意先 2:請求先 3:納入先)</param>
        /// <returns></returns>
        public DialogResult ShowDialog(IWin32Window owner, Addressee addressee, Int32 addresseeCode, Int32 CustomerCode, Int32 ClaimCode, AddresseeAcs.GuideMode guideMode)
        {
            this._guideMode = guideMode;
            this._addresseeName = addressee.AddresseeName;
            this._addresseeName2 = addressee.AddresseeName2;
            this._addresseeAddr1 = addressee.AddresseeAddr1;
            this._addresseeAddr2 = addressee.AddresseeAddr2;
            this._addresseeAddr3 = addressee.AddresseeAddr3;
            this._addresseeAddr4 = addressee.AddresseeAddr4;
            this._addresseeTelNo = addressee.AddresseeTelNo;
            this._addresseeFaxNo = addressee.AddresseeFaxNo;
            this._addresseePostNo = addressee.AddresseePostNo;

            this._addresseeAcs.Addressee.AddresseeAddr1 = addressee.AddresseeAddr1;
            this._addresseeAcs.Addressee.AddresseeAddr2 = addressee.AddresseeAddr2;
            this._addresseeAcs.Addressee.AddresseeAddr3 = addressee.AddresseeAddr3;
            this._addresseeAcs.Addressee.AddresseeAddr4 = addressee.AddresseeAddr4;
            this._addresseeAcs.Addressee.AddresseeCode = addressee.AddresseeCode;
            this._addresseeAcs.Addressee.AddresseeName = addressee.AddresseeName;
            this._addresseeAcs.Addressee.AddresseeName2 = addressee.AddresseeName2;
            this._addresseeAcs.Addressee.AddresseeTelNo = addressee.AddresseeTelNo;
            this._addresseeAcs.Addressee.AddresseeFaxNo = addressee.AddresseeFaxNo;
            this._addresseeAcs.Addressee.AddresseePostNo = addressee.AddresseePostNo;

            this._addresseeCode = addresseeCode;
            this._customerCode = CustomerCode;
            this._claimCode = ClaimCode;

            this._addresseeAcs.Mode = guideMode;

            return this.ShowDialog(owner);
        }
        #endregion

        #region ■Private Method


        # region 各コントロールイベント処理

        /// <summary>
        /// 画面Loadイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void Form1_Load( object sender, EventArgs e )
        {
            // ボタン初期設定処理
            this.ButtonInitialSetting();

            //// 画面初期情報設定処理
            this.SetInitialInput();

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ツールバーボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tToolbarsManager_MainMenu_ToolClick( object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e )
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        // 終了処理
                        this.CloseForm();
                        break;
                    }
                case "ButtonTool_Decision":
                    {
                        // 確定処理
                        if (DecisionProc())
                        {
                            this.SetDialogRes(DialogResult.OK);
                            this.CloseForm();
                        }
                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 元に戻す処理
                        this._addresseeAcs.Addressee = this._addresseeOriginal.Clone();
                        this.ClearDisplay();
                        this.SetDisplayInfo();

                        break;
                    }
                case "ButtonTool_ChangeAddress":
                    {
                        // 住所切替
                        this.ChangeAddress();
                        this.SetDisplayInfo();
                        break;
                    }
            }
        }

        /// <summary>
        /// 住所切替
        /// </summary>
        private void ChangeAddress()
        {
            Int32 code = 0;

            switch (this._guideMode)
            {
                // 得意先→請求先
                case AddresseeAcs.GuideMode.Customer:
                    {
                        code = this._claimCode;
                        break;
                    }
                // 請求先→納入先
                case AddresseeAcs.GuideMode.CustomerClaim:
                    {
                        code = this._addresseeCode;
                        break;
                    }
                // 納入先→得意先
                case AddresseeAcs.GuideMode.Addressee:
                    {
                        code = this._customerCode;
                        break;
                    }
            }

            if (code == 0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "コードが設定されていない為、住所切替出来ません。",
                    0,
                    MessageBoxButtons.OK);
                return;
            }
            
            switch (this._guideMode)
            {
                // 得意先→請求先
                case AddresseeAcs.GuideMode.Customer:
                    {
                        this.uLabel_InputModeTitle.Text = GetTitleString(AddresseeAcs.GuideMode.CustomerClaim) + "住所";
                        this._guideMode = AddresseeAcs.GuideMode.CustomerClaim;
                        break;
                    }
                // 請求先→納入先(初期表示内容へ)
                case AddresseeAcs.GuideMode.CustomerClaim:
                    {
                        this.uLabel_InputModeTitle.Text = GetTitleString(AddresseeAcs.GuideMode.Addressee) + "住所";
                        this._guideMode = AddresseeAcs.GuideMode.Addressee;
                        break;
                    }
                // 納入先→得意先
                case AddresseeAcs.GuideMode.Addressee:
                    {
                        this.uLabel_InputModeTitle.Text = GetTitleString(AddresseeAcs.GuideMode.Customer) + "住所";
                        this._guideMode = AddresseeAcs.GuideMode.Customer;
                        break;
                    }
            }

            CustomerInfo customerInfo = null;
            this._addresseeAcs.ReadCustomer(code, out customerInfo);
            this._addresseeAcs.Cache(customerInfo);

        }

        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void SetStatusBarMessage( object sender, string message )
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }

        /// <summary>
        /// Timer.Tick イベント イベント(Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。
        ///	                 この処理は、システムが提供するスレッド プール
        ///	                 スレッドで実行されます。</br>
        /// </remarks>
        private void Initial_Timer_Tick( object sender, EventArgs e )
        {
            this.Initial_Timer.Enabled = false;

            this._addresseeOriginal = this._addresseeAcs.Addressee.Clone();
            this.SetInitialInput();
            this.tEdit_PostNo.Focus();
        }

        /// <summary>
        /// フォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            //if (e.PrevCtrl == null || e.NextCtrl == null) return;

            //SetStatusBarMessage(this, "");
            //bool canChangeFocus = true;

            //switch (e.PrevCtrl.Name)
            //{
            //}

            //if (!canChangeFocus)
            //{
            //    e.NextCtrl = e.PrevCtrl;
            //}

        }

        /// <summary>
        /// フォーム終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void MAKON01320UA_FormClosed( object sender, FormClosedEventArgs e )
        {
            DialogResult = _dialogRes;
        }

        /// <summary>
        /// 仕入先ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void uButton_StockCustomerGuide_Click( object sender, EventArgs e )
        {
            int searchMode = SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY;

            SFTOK01370UA customerSearchForm = new SFTOK01370UA(searchMode, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_CustomerSelect( object sender, CustomerSearchRet customerSearchRet )
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;

            int status = this._addresseeAcs.ReadCustomer(customerSearchRet.CustomerCode, out customerInfo);

            // 読み込みOK
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (customerInfo == null )
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "選択した得意先は選択出来ません。",
                        status,
                        MessageBoxButtons.OK);
                }
                else
                {
                    this._addresseeAcs.Cache(customerInfo);
                    SetDisplayInfo();
                }

            }
            // データ無し
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    string.Format("選択した{0}は既に削除されています。", GetTitleString(this._addresseeAcs.Mode)),
                    -1,
                    MessageBoxButtons.OK);
            }
        }
        # endregion

        /// <summary>
        /// 画面初期情報設定処理
        /// </summary>
        private void SetInitialInput()
        {
            // ヘッダ情報クリア処理
            this.ClearDisplay();

            // ヘッダ初期表示処理
            this.SetDisplayInfo();
        }

        /// <summary>
        /// 画面ヘッダクリア処理
        /// </summary>
        private void ClearDisplay()
        {
            this.uLabel_InputModeTitle.BeginUpdate();
            this.uLabel_AddresseeCode.BeginUpdate();
            this.tEdit_AddresseeName.BeginUpdate();
            this.tEdit_AddresseeName2.BeginUpdate();
            this.tEdit_PostNo.BeginUpdate();
            this.tEdit_AddresseeAddr1.BeginUpdate();
            this.tEdit_AddresseeAddr3.BeginUpdate();
            this.tEdit_AddresseeAddr4.BeginUpdate();
            this.uLabel_AddresseeTelNo.BeginUpdate();
            this.uLabel_AddresseeFaxNo.BeginUpdate();

            // 納入先コード
            this.uLabel_AddresseeCode.Text = "";
            // 名称１
            this.tEdit_AddresseeName.Clear();
            // 名称２
            this.tEdit_AddresseeName2.Clear();
            // 郵便番号
            this.tEdit_PostNo.Clear();
            // 住所１
            this.tEdit_AddresseeAddr1.Clear();
            // 住所２
            this.tEdit_AddresseeAddr3.Clear();
            // 住所３
            this.tEdit_AddresseeAddr4.Clear();
            // 勤務先TEL
            this.uLabel_AddresseeTelNo.Text = "";
            // 勤務先FAX
            this.uLabel_AddresseeFaxNo.Text = "";

            try
            {
                switch (this._addresseeAcs.Mode)
                {
                    case AddresseeAcs.GuideMode.Customer:
                        {
                            this.uLabel_InputModeTitle.Text = "得意先住所";
                            break;
                        }
                    case AddresseeAcs.GuideMode.CustomerClaim:
                        {
                            this.uLabel_InputModeTitle.Text = "請求先住所";
                            break;
                        }
                    case AddresseeAcs.GuideMode.Addressee:
                        {
                            this.uLabel_InputModeTitle.Text = "納入先住所";
                            break;
                        }
                }
            }
            finally
            {
                this.uLabel_InputModeTitle.EndUpdate();
                this.uLabel_AddresseeCode.EndUpdate();
                this.tEdit_AddresseeName.EndUpdate();
                this.tEdit_AddresseeName2.EndUpdate();
                this.tEdit_PostNo.EndUpdate();
                this.tEdit_AddresseeAddr1.EndUpdate();
                this.tEdit_AddresseeAddr3.EndUpdate();
                this.tEdit_AddresseeAddr4.EndUpdate();
                this.uLabel_AddresseeTelNo.EndUpdate();
                this.uLabel_AddresseeFaxNo.EndUpdate();
            }
        }

        /// <summary>
        /// 画面ヘッダ表示処理
        /// </summary>
        private void SetDisplayInfo()
        {

            //if (this._addresseeAcs.Addressee.AddresseeCode == 0) return;

            this.uLabel_AddresseeCode.BeginUpdate();
            this.tEdit_AddresseeName.BeginUpdate();
            this.tEdit_AddresseeName2.BeginUpdate();
            this.tEdit_PostNo.BeginUpdate();
            this.tEdit_AddresseeAddr1.BeginUpdate();
            this.tEdit_AddresseeAddr3.BeginUpdate();
            this.tEdit_AddresseeAddr4.BeginUpdate();
            this.uLabel_AddresseeTelNo.BeginUpdate();
            this.uLabel_AddresseeFaxNo.BeginUpdate();

            try
            {
                // 納入先コード
                this.uLabel_AddresseeCode.Text = this._addresseeAcs.Addressee.AddresseeCode.ToString("000000000");
                // 名称１
                this.tEdit_AddresseeName.Text = this._addresseeAcs.Addressee.AddresseeName;
                // 名称２
                this.tEdit_AddresseeName2.Text = this._addresseeAcs.Addressee.AddresseeName2;
                // 郵便番号
                this.tEdit_PostNo.Text = this._addresseeAcs.Addressee.AddresseePostNo;
                // 住所１
                this.tEdit_AddresseeAddr1.Text = this._addresseeAcs.Addressee.AddresseeAddr1;
                // 住所２
                this.tEdit_AddresseeAddr3.Text = this._addresseeAcs.Addressee.AddresseeAddr3;
                // 住所３
                this.tEdit_AddresseeAddr4.Text = this._addresseeAcs.Addressee.AddresseeAddr4;
                // 勤務先TEL
                this.uLabel_AddresseeTelNo.Text = this._addresseeAcs.Addressee.AddresseeTelNo;
                // 勤務先FAX
                this.uLabel_AddresseeFaxNo.Text = this._addresseeAcs.Addressee.AddresseeFaxNo;

            }
            finally
            {
                this.uLabel_AddresseeCode.EndUpdate();
                this.tEdit_AddresseeName.EndUpdate();
                this.tEdit_AddresseeName2.EndUpdate();
                this.tEdit_PostNo.EndUpdate();
                this.tEdit_AddresseeAddr1.EndUpdate();
                this.tEdit_AddresseeAddr3.EndUpdate();
                this.tEdit_AddresseeAddr4.EndUpdate();
                this.uLabel_AddresseeTelNo.EndUpdate();
                this.uLabel_AddresseeFaxNo.EndUpdate();
            }
        }

		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
		private void ButtonInitialSetting()
		{
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			this._undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
            this._changeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.MODIFY;
        }

        /// <summary>
        /// Valueチェック処理（int）
        /// </summary>
        /// <param name="sorce">tComboのValue</param>
        /// <returns>チェック後の値</returns>
        private int ValueToInt(object sorce)
        {
            int dest = 0;
            try
            {
                dest = Convert.ToInt32(sorce);
            }
            catch
            {
                return dest;
            }
            return dest;
        }
       
        /// <summary>
        /// 画面終了処理
        /// </summary>
        public void CloseForm()
        {
            this.Close();
        }

        /// <summary>
        /// ダイアログリザルト設定処理
        /// </summary>
        /// <param name="dialogRes">ダイアログリザルト</param>
        public void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        /// <summary>
        /// 「確定」ボタン表示変更処理
        /// </summary>
        /// <param name="enable">表示設定(true:表示、false:非表示)</param>
        private void ChangeDecisionButtonEnable(bool enableSet)
        {
            this._decisionButton.SharedProps.Enabled = enableSet;
        }

        /// <summary>
        /// 確定処理
        /// </summary>
        private bool DecisionProc()
        {
            Control control = null;
            string message = null;

            if (!ScreenDataCheck(ref control, ref message))
            {
                TMsgDisp.Show(this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    message,
                    0,
                    MessageBoxButtons.OK);

                control.Focus();
                return false;
            }

            //this._addresseeAcs.Addressee.AddresseeAddr1 = this.tEdit_AddresseeAddr1.Text;
            //this._addresseeAcs.Addressee.AddresseeAddr3 = this.tEdit_AddresseeAddr3.Text;
            //this._addresseeAcs.Addressee.AddresseeAddr4 = this.tEdit_AddresseeAddr4.Text;
            if (this._addresseeAcs.Addressee.AddresseeName != this.tEdit_AddresseeName.Text)
            {
                this._addresseeAcs.Addressee.AddresseeName = this.tEdit_AddresseeName.Text;
                this._addresseeAcs.Addressee.AddresseeName2 = "";
            }
            else
            {
                this._addresseeAcs.Addressee.AddresseeName2 = this.tEdit_AddresseeName2.Text;
            }

            this._addresseeAcs.Addressee.SlipAddressDiv = (int)this._guideMode; // 伝票住所区分(1:得意先 2:納品先 3:請求先)

            return true;
        }

        /// <summary>
        /// 画面入力情報不正チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果（true:OK／false:NG）</returns>
        private bool ScreenDataCheck( ref Control control, ref string message )
        {
            bool result = true;

            return result;
        }

        # region ■Static
        /// <summary>
        /// タイトル取得
        /// </summary>
        /// <param name="guideType">ガイドモード</param>
        /// <returns>タイトル（得意先or仕入先)</returns>
        private static string GetTitleString(AddresseeAcs.GuideMode guideType)
        {
            switch (guideType)
            {
                case AddresseeAcs.GuideMode.CustomerClaim:
                    return "請求先";
                case AddresseeAcs.GuideMode.Customer:
                    return "得意先";
                case AddresseeAcs.GuideMode.Addressee:
                    return "納入先";
                default:
                    return "";
            }
        }
        #endregion

        #endregion

    }
}
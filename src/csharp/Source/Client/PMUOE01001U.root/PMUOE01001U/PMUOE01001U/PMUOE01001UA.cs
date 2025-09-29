//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信処理 Ｕｉフォームクラス
// プログラム概要   : ＵＯＥ送信処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
// 作 成 日  2009/05/25  修正内容 : ホンダ UOE WEB対応
//----------------------------------------------------------------------------//
// 管理番号  10504551-00 作成担当 : 21024 佐々木
// 作 成 日  2009/09/24  修正内容 : 在庫一括発注を行う際に数量ゼロ入力分は発注取り消しになるように修正(MANTIS【0014224】)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/11/23  修正内容 : 在庫一括時の発注先選択制御の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : xuxh
// 作 成 日  2009/12/29  修正内容 : 【要件No.3】発注先の入力制御（トヨタは入力不可とする）を行う
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱俊成
// 作 成 日  2011/05/10  修正内容 : Redmine#20867
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2012/11/21  修正内容 : 2013/01/16配信分　Redmine#33506
//                                  伝発発注、検索発注の場合、グリッドに発注先を追加する対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2012/12/17  修正内容 : 2013/01/16配信分　Redmine#33506
//                                  未送信一覧から呼び出すと項目幅が異なる対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00　作成担当 : wangyl
// 修 正 日  2013/04/01  修正内容 : 10801804-00 2013/04/10配信分
//                                  Redmine#34578の対応 システム区分によって、明細グリッドの「倉庫」の位置が異なります 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{

    /// <summary>
    /// ＵＯＥ送信処理フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＵＯＥ送信処理のフォームクラスです。</br>
    /// <br>Programmer : 96186 立花裕輔</br>
    /// <br>Date       : 2008.05.12</br>
    /// <br></br>
    /// <br>UpdateNote : 在庫一括発注を行う際に数量ゼロ入力分は発注取り消しになるように修正(MANTIS【0014224】)</br>
    /// <br>Programmer : 21024 佐々木</br>
    /// <br>Date       : 2009/09/24</br>
    /// <br>UpdateNote : 2009/11/23 李占川 保守依頼③対応</br>
    /// <br>             在庫一括時の発注先選択制御の変更</br>
    /// <br>UpdateNote : 2009/12/29 xuxh 【要件No.3】対応</br>
    /// <br>             発注先の入力制御（トヨタは入力不可とする）を行う</br>
    /// <br>Update Note: 2012/11/21 田建委</br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
    /// <br>Update Note: 2012/12/17 田建委</br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine#33506 未送信一覧から呼び出すと項目幅が異なる対応</br>
    /// <br>Update Note: 2013/04/01 wangyl</br>
    /// <br>管理番号   : 2013/04/10配信分</br>
    /// <br>             Redmine#34578の対応 システム区分によって、明細グリッドの「倉庫」の位置が異なります</br>
    /// </remarks>
	public partial class PMUOE01001UA : Form
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 在庫一括入力フォームクラス デフォルトコンストラクタ
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote : 2009/11/23 李占川 保守依頼③対応</br>
        /// <br>             在庫一括時の発注先選択制御の変更</br>
        /// </remarks>
		public PMUOE01001UA()
		{
			InitializeComponent();

			// 変数初期化
			this._detailInput = new PMUOE01001UB();
			this._imageList16 = IconResourceManagement.ImageList16;
			this._loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
			this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
			this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
			this._saveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
			this._retryButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Retry"];
			this._newButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_New"];
			this._searchButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
			this._deleteButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Delete"];
			
			this._guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"];
			this._setupButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Setup"];
			this._sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionTitle"];
			this._addUpSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_AddUpSectionTitle"];
			this._sectionComboBox = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)this.tToolbarsManager_MainMenu.Tools["ComboBoxTool_SectionCode"];
			this._addUpSectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_AddUpSectionName"];

            this._sendNotButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_SendNot"]; // ADD 2009/11/23

			this._controlScreenSkin = new ControlScreenSkin();

			this._detailInputAcs = StockInputAcs.GetInstance();
			this._detailInputInitDataAcs = StockInputInitDataAcs.GetInstance();


			this._detailInput.GridKeyDownTopRow += new EventHandler(this.StockDetailInput_GridKeyDownTopRow);
			this._detailInput.GridKeyDownButtomRow += new EventHandler(this.StockDetailInput_GridKeyDownButtomRow);
			this._detailInput.StatusBarMessageSetting += new PMUOE01001UB.SettingStatusBarMessageEventHandler(this.StockDetailInput_StatusBarMessageSetting);
            this._detailInputAcs.DataChanged += new EventHandler(this.StockInputAcs_DataChanged);

            // ガイド対応コントロール一覧
			this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode.Name, ctGUIDE_NAME_CustomerGuide);
			this._guideEnableControlDictionary.Add(this.tNedit_SupplierCd.Name, ctGUIDE_NAME_SupplierGuide);

			this._guideEnableExceptControlDictionary.Add(this._detailInput.Name, this._detailInput);
			this._guideEnableExceptControlDictionary.Add(this._detailInput.uGrid_Details.Name, this._detailInput.uGrid_Details);
			this._guideEnableExceptControlDictionary.Add(this._detailInput.uButton_Guide.Name, this._detailInput.uButton_Guide);




            int controlIndexForword = 0;
            this._controlIndexForwordDictionary.Add(this.tComboEditor_TerminalDiv.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_TerminalNoDiv.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tNedit_TerminalNo.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_SysDiv.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tNedit_St_OnlineNo.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tNedit_Ed_OnlineNo.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tDateEdit_InputDateSt.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tDateEdit_InputDateEd.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tNedit_CustomerCode.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tNedit_SupplierCd.Name, controlIndexForword++);

            int controlIndexBack = 99;
            this._controlIndexBackDictionary.Add(this.tComboEditor_TerminalDiv.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_TerminalNoDiv.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tNedit_TerminalNo.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_SysDiv.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tNedit_St_OnlineNo.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tNedit_Ed_OnlineNo.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tDateEdit_InputDateSt.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tDateEdit_InputDateEd.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tNedit_CustomerCode.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tNedit_SupplierCd.Name, controlIndexBack--);

			this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			this._addUpSectionNameLabel.SharedProps.Caption = "";
		}
		# endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        # region UOE発注先マスタアクセスクラス
        /// <summary>
        /// UOE発注先マスタアクセスクラス
        /// </summary>
        public UOESupplierAcs uOESupplierAcs
        {
            get { return _detailInputInitDataAcs.uOESupplierAcs; }
        }
        # endregion

        # region 自端末コード
        /// <summary>
        /// 自端末コード
        /// </summary>
        public int cashRegisterNo
        {
            get { return this._detailInputInitDataAcs.cashRegisterNo; }
        }
        # endregion
        # endregion

        // ===================================================================================== //
        // 定数
        // ===================================================================================== //
        # region Const Members
        //業務区分
        public const Int32 ctTerminalDiv_Order = 1;	//発注
        public const Int32 ctTerminalDiv_Estm = 2;	//見積
        public const Int32 ctTerminalDiv_Alloc = 3;	//在庫確認
        public const Int32 ctTerminalDiv_Cancel = 4;//取消処理

        //端末番号区分
        public const Int32 ctTerminalNoDiv_Own = 0;	//自端末
        public const Int32 ctTerminalNoDiv_Other = 1;	//他端末
        public const Int32 ctTerminalNoDiv_All = 2;	//全端末

        //システム区分
        public const Int32 ctSysDiv_Slip = 1;	//伝発発注
        public const Int32 ctSysDiv_Srch = 2;	//検索発注
        public const Int32 ctSysDiv_stock = 3;	//在庫一括

        //Guide値
        private const string ctGUIDE_NAME_SupplierGuide = "SupplierGuide";
        private const string ctGUIDE_NAME_CustomerGuide = "CustomerGuide";

        //入力メッセージ
        private const string MESSAGE_TerminalDiv = "業務区分を選択してください。";
        private const string MESSAGE_TerminalNoDiv = "端末区分を選択してください。";
        private const string MESSAGE_TerminalNo = "端末番号を選択してください。";
        private const string MESSAGE_SysDiv = "システム区分を選択してください。";
        private const string MESSAGE_St_OnlineNo = "呼出番号(開始)を入力してください。";
        private const string MESSAGE_Ed_OnlineNo = "呼出番号(終了)を入力してください。";
        private const string MESSAGE_InputDateSt = "入力日(開始)を入力してください。";
        private const string MESSAGE_InputDateEd = "入力日(終了)を入力してください。";
        private const string MESSAGE_CustomerCode = "得意先を入力してください。";
        private const string MESSAGE_SupplierCd = "発注先を入力してください。";

        //設定XMLファイル名
        private const string XML_FILE_NAME = "PMUOE01001U_Construction.XML"; // ADD 2012/11/21 田建委 Redmine#33506

        //---ADD 2013/04/01 wangyl Redmine#34578------>>>>>
        //新規追加した列名
        private const string NEW_COLNAME_WAREHOUSE = "WareHouseName";
        //---ADD 2013/04/01 wangyl Redmine#34578------<<<<<

        # endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private PMUOE01001UB _detailInput;
        
		private ImageList _imageList16 = null;											// イメージリスト
		private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// 保存ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _retryButton;				// 元に戻すボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _newButton;				// 新規ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;				// 検索ボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _deleteButton;				// 削除ボタン

		private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// ガイドボタン
		private Infragistics.Win.UltraWinToolbars.ButtonTool _setupButton;				// 設定ボタン
		private Infragistics.Win.UltraWinToolbars.LabelTool _sectionTitleLabel;			// 入力拠点ラベル
		private Infragistics.Win.UltraWinToolbars.ComboBoxTool _sectionComboBox;		// 入力拠点コンボボックス
		private Infragistics.Win.UltraWinToolbars.LabelTool _addUpSectionTitleLabel;	// 計上拠点ラベル
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginEmployeeLabel;		// ログイン担当者タイトル
		private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ログイン担当者名称
		private Infragistics.Win.UltraWinToolbars.LabelTool _addUpSectionNameLabel;		// 計上拠点名称

        private Infragistics.Win.UltraWinToolbars.ButtonTool _sendNotButton;		    // 未送信一覧ボタン  // ADD 2009/11/13

		private ControlScreenSkin _controlScreenSkin;

		private StockInputAcs _detailInputAcs;
		private StockInputInitDataAcs _detailInputInitDataAcs;

        private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();
		private Dictionary<string, Control> _guideEnableExceptControlDictionary = new Dictionary<string, Control>();
		private Dictionary<string, int> _controlIndexForwordDictionary = new Dictionary<string, int>();
		private Dictionary<string, int> _controlIndexBackDictionary = new Dictionary<string, int>();
		private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
		private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
		private string _loginSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
		private string _employeeCode = LoginInfoAcquisition.Employee.EmployeeCode.Trim();
		private string _employeeName = LoginInfoAcquisition.Employee.Name;


        private OLEScannerController _OLEScannerController = new OLEScannerController();

		//画面入力クラス
		private InpDisplay _inpDisplay;

        private UOEUserConst _userSetting; // ADD 2012/11/21 田建委 Redmine#33506
		# endregion

        // ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

        # region ■ 初期設定関連 ■
		# region ■ ボタン初期設定処理 ■
		/// <summary>
		/// ボタン初期設定処理
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote : 2009/11/23 李占川 保守依頼③対応</br>
        /// <br>             在庫一括時の発注先選択制御の変更</br>
        /// </remarks>
		private void ButtonInitialSetting()
		{
			//tToolbarsManager_MainMenu
			this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
			this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			this._saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			this._retryButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;
			this._newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			this._searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
			this._deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;

			this._guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
			this._setupButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;
			this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
			this._addUpSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
			this._loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            this._sendNotButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE; // ADD 2009/11/23

			//ImageList
			this.uButton_CustomerGuide.ImageList = this._imageList16;
            this.uButton_SupplierGuide.ImageList = this._imageList16;

			//Appearance.Image
			this.uButton_CustomerGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_SupplierGuide.Appearance.Image = (int)Size16_Index.STAR1;
		}
		# endregion ■ ボタン初期設定処理 ■

		# region ■ ツールバー初期設定処理 ■
		/// <summary>
		/// ツールバー初期設定処理
		/// </summary>
		private void ToolBarInitilSetting()
		{
			// 管理拠点コンボボックスの設定
			try
			{
				this._detailInputInitDataAcs.SetSectionComboEditor(ref this._sectionComboBox, false);

				// 拠点コンボエディタ選択値設定処理
				this._detailInputInitDataAcs.SetSectionComboEditorValue(this._sectionComboBox, this._loginSectionCode);
			}
			catch (ApplicationException ex)
			{
				TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_STOP,
					this.Name,
					ex.Message,
					0,
					MessageBoxButtons.OK);

				return;
			}

#if False
			if (StockInputInitDataAcs.IsSectionOptionIntroduce)
			{
                this._addUpSectionTitleLabel.SharedProps.Visible = true;
    			this._sectionComboBox.SharedProps.Visible = true;
				this._sectionComboBox.SharedProps.Enabled = true;
			}
			else
			{
#endif
				//this._addUpSectionTitleLabel.SharedProps.Visible = false;
                //this._sectionComboBox.SharedProps.Visible = false;

				this._addUpSectionTitleLabel.SharedProps.Visible = true;
				this._sectionComboBox.SharedProps.Visible = true;
				this._sectionComboBox.SharedProps.Enabled = true;
#if False
			}
#endif
			}
		# endregion ■ ツールバー初期設定処理 ■

		# region ■ コンボエディタアイテム初期設定処理 ■
		/// <summary>
		/// コンボエディタアイテム初期設定処理
		/// </summary>
		private void ComboEditorItemInitialSetting()
		{
			if (InpDisplay == null)
			{
				_inpDisplay = new InpDisplay();
			}

			ClearOrderInpDisplay(InpDisplay);
			SetDisplay(InpDisplay);
		}
		# endregion ■ コンボエディタアイテム初期設定処理 ■
		# endregion ■ 初期設定関連 ■

		# region ■ 画面データ→画面格納処理 ■
		/// <summary>
		/// 画面データクラス→画面格納処理
		/// </summary>
		/// <param name="stockExpansion">在庫一括データオブジェクト</param>
		private void SetDisplay(InpDisplay inpDisplay)
		{
			if (inpDisplay == null)
			{
				inpDisplay = new InpDisplay();
				ClearOrderInpDisplay(inpDisplay);
			}
			
			//入力項目
			this.tComboEditor_TerminalDiv.Value = inpDisplay.BusinessCode;		//業務区分
			this.tComboEditor_TerminalNoDiv.Value = inpDisplay.CashRegisterNoDiv;	//端末区分

			//端末番号
			switch (inpDisplay.CashRegisterNoDiv)
			{
				//自端末
				case ctTerminalNoDiv_Own:
					{
                        inpDisplay.CashRegisterNo = cashRegisterNo;
						tNedit_TerminalNo.Enabled = false;
						break;
					}

				//他端末
				case ctTerminalNoDiv_Other:
					{
						tNedit_TerminalNo.Enabled = true;
						break;
					}

				//全端末
				case ctTerminalNoDiv_All:
					{
						inpDisplay.CashRegisterNo = 0;
						tNedit_TerminalNo.Enabled = false;
						break;
					}
			}
			this.tNedit_TerminalNo.SetInt(inpDisplay.CashRegisterNo);

            // --- ADD 2009/11/23 ---------->>>>>
            ////システム区分
            //switch (inpDisplay.BusinessCode)
            //{
            //    case ctTerminalDiv_Estm:	//見積
            //    case ctTerminalDiv_Alloc:	//在庫確認
            //        inpDisplay.SystemDivCd = ctSysDiv_Srch;
            //        break;
            //    case ctTerminalDiv_Order:	//発注
            //    case ctTerminalDiv_Cancel:	//取消処理
            //        break;
            //}
            // --- ADD 2009/11/23 ----------<<<<<
			this.SetSysDivComboEditor(ref this.tComboEditor_SysDiv, inpDisplay.BusinessCode);
			this.tComboEditor_SysDiv.Value = inpDisplay.SystemDivCd;

			this.tNedit_St_OnlineNo.SetInt(inpDisplay.UOESalesOrderNoSt);					//オンライン番号(開始）
			this.tNedit_Ed_OnlineNo.SetInt(inpDisplay.UOESalesOrderNoEd);					//オンライン番号(終了）
			this.tDateEdit_InputDateSt.SetDateTime(inpDisplay.SalesDateSt);		//入力日（開始）
			this.tDateEdit_InputDateEd.SetDateTime(inpDisplay.SalesDateEd);		//入力日（終了）
			this.tNedit_CustomerCode.SetInt(inpDisplay.CustomerCode);			//得意先ｺｰﾄﾞ
			this.tNedit_SupplierCd.SetInt(inpDisplay.UOESupplierCd);				//発注先ｺｰﾄﾞ

			//出力項目
			this.uLabel_CustomerName.Text = inpDisplay.CustomerName;			//得意先名称
			this.uLabel_SupplierName.Text = inpDisplay.UOESupplierName;			//発注先名称
		}
        # endregion ■ 画面データ→画面格納処理 ■

		# region ■ システム区分コンボエディタリスト設定処理 ■
		/// <summary>
		/// システム区分コンボエディタリスト設定処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="terminalDiv"></param>
		public void SetSysDivComboEditor(ref TComboEditor sender, int terminalDiv)
		{
			Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();

			Infragistics.Win.ValueListItem secInfoItem0 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem secInfoItem1 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem secInfoItem2 = new Infragistics.Win.ValueListItem();

			switch (terminalDiv)
			{
				case ctTerminalDiv_Estm:	//見積
				case ctTerminalDiv_Alloc:	//在庫確認
				case ctTerminalDiv_Order:	//発注
				case ctTerminalDiv_Cancel:	//取消処理
					//伝発発注
					secInfoItem0.DataValue = ctSysDiv_Slip;
					secInfoItem0.DisplayText = "伝発発注";
					valueList.ValueListItems.Add(secInfoItem0);

					//検索発注
					secInfoItem1.DataValue = ctSysDiv_Srch;
					secInfoItem1.DisplayText = "検索発注";
					valueList.ValueListItems.Add(secInfoItem1);

					//在庫一括
					secInfoItem2.DataValue = ctSysDiv_stock;
					secInfoItem2.DisplayText = "在庫一括";
					valueList.ValueListItems.Add(secInfoItem2);
					break;
			}

			if (valueList != null)
			{
				sender.Items.Clear();
				for (int i = 0; i < valueList.ValueListItems.Count; i++)
				{
					Infragistics.Win.ValueListItem vlltem = new Infragistics.Win.ValueListItem();
					vlltem.Tag = valueList.ValueListItems[i].Tag;
					vlltem.DataValue = valueList.ValueListItems[i].DataValue;
					vlltem.DisplayText = valueList.ValueListItems[i].DisplayText;
					sender.Items.Add(vlltem);
				}

				sender.MaxDropDownItems = valueList.ValueListItems.Count;
				sender.Value = 0;
			}
		}
		# endregion ■ システム区分コンボエディタリスト設定処理 ■

		# region ■ 画面→画面データクラス格納処理 ■
		/// <summary>
		/// 画面→画面データクラス格納処理
		/// </summary>
		/// <param name="stockExpansion">在庫一括データオブジェクト</param>
		private InpDisplay GetDisplay()
		{
			InpDisplay inpDisplay = new InpDisplay();

			//環境項目
			inpDisplay.EnterpriseCode = this._enterpriseCode;	//企業コード
			inpDisplay.SectionCode = this._loginSectionCode;	//拠点コード
			inpDisplay.SectionName = this._loginSectionName;	//拠点名
			inpDisplay.EmployeeCode = this._employeeCode;		//入力担当者コード
			inpDisplay.EmployeeName = this._employeeName;		//入力担当者名

			//入力項目
			inpDisplay.BusinessCode = (Int32)this.tComboEditor_TerminalDiv.Value;	//業務区分
			inpDisplay.CashRegisterNoDiv = (Int32)this.tComboEditor_TerminalNoDiv.Value;//端末区分

            //端末番号
            inpDisplay.CashRegisterNo = (Int32)this.tNedit_TerminalNo.GetInt();

            inpDisplay.SystemDivCd = (Int32)this.tComboEditor_SysDiv.Value;				//システム区分


			inpDisplay.UOESalesOrderNoSt = this.tNedit_St_OnlineNo.GetInt();				//オンライン番号(開始）
			inpDisplay.UOESalesOrderNoEd = this.tNedit_Ed_OnlineNo.GetInt();				//オンライン番号(終了）
			inpDisplay.SalesDateSt = this.tDateEdit_InputDateSt.GetDateTime();	//入力日（開始）
			inpDisplay.SalesDateEd = this.tDateEdit_InputDateEd.GetDateTime();	//入力日（終了）
			inpDisplay.CustomerCode = this.tNedit_CustomerCode.GetInt();		//得意先ｺｰﾄﾞ
			inpDisplay.UOESupplierCd = this.tNedit_SupplierCd.GetInt();			//発注先ｺｰﾄﾞ

			//出力項目
			inpDisplay.CustomerName = this.uLabel_CustomerName.Text;			//得意先名称
			inpDisplay.UOESupplierName = this.uLabel_SupplierName.Text;			//発注先名称

			return inpDisplay;
		}
		# endregion ■ 画面→画面データクラス格納処理 ■

		# region ■ 画面データクラスの初期化 ■
		/// <summary>
		/// 画面データクラスの初期化
		/// </summary>
		/// <param name="inpDisplay"></param>
        /// <br>Update Note: 2011/05/10 朱俊成 不正な日付が入力されている状態でフォーカス移動した場合、日付をクリアしない</br>
		private void ClearOrderInpDisplay(InpDisplay inpDisplay)
		{
			//環境項目
			inpDisplay.EnterpriseCode = this._enterpriseCode;	//企業コード
			inpDisplay.SectionCode = this._loginSectionCode;	//拠点コード
			inpDisplay.SectionName = this._loginSectionName;	//拠点名
			inpDisplay.EmployeeCode = this._employeeCode;		//入力担当者コード
			inpDisplay.EmployeeName = this._employeeName;		//入力担当者名

			//入力項目
			inpDisplay.BusinessCode = ctTerminalDiv_Order;	//業務区分
			inpDisplay.CashRegisterNoDiv = ctTerminalNoDiv_Own;	//端末番号
            inpDisplay.CashRegisterNo = cashRegisterNo;			//端末番号
			inpDisplay.SystemDivCd = ctSysDiv_Slip;				//システム区分

			inpDisplay.UOESalesOrderNoSt = 0;					//オンライン番号(開始）
			inpDisplay.UOESalesOrderNoEd = 0;					//オンライン番号(終了）
            // 不正な日付が入力されている状態でフォーカス移動した場合、日付をクリアしない
            // Del 2011/05/10 ------>>>>>
            //inpDisplay.SalesDateSt = DateTime.Now;	//入力日（開始）
            //inpDisplay.SalesDateEd = DateTime.Now;	//入力日（終了）
            // Del 2011/05/10 ------<<<<<
            // ADD 2011/05/10 ------>>>>>
            inpDisplay.SalesDateSt = DateTime.Now.Date;	//入力日（開始）
            inpDisplay.SalesDateEd = DateTime.Now.Date;	//入力日（終了）
            // ADD 2011/05/10 ------<<<<<

			inpDisplay.CustomerCode = 0;				//得意先ｺｰﾄﾞ
			inpDisplay.UOESupplierCd = 0;					//発注先ｺｰﾄﾞ

			//出力項目
			inpDisplay.CustomerName = "";				//得意先名称
			inpDisplay.UOESupplierName = "";				//発注先名称

		}
		# endregion ■ 画面データクラスの初期化 ■

		# region ■ 画面データクラスのプロパティ ■
		/// <summary>画面データクラスのプロパティ</summary>
		public InpDisplay InpDisplay
		{
			get
			{
				return this._inpDisplay;
			}
			set
			{
				this._inpDisplay = value;
			}
		}
		# endregion ■ 画面データクラスのプロパティ ■

		# region ■ フォーカス関連処理 ■
		# region ■ ガイドボタンツール有効無効設定処理 ■
		/// <summary>
		/// ガイドボタンツール有効無効設定処理
		/// </summary>
		/// <param name="nextControl">次のコントロール</param>
		private void SettingGuideButtonToolEnabled(Control nextControl)
		{
			if (nextControl == null) return;

            //-----------------------------------------------------------
            // ガイドボタン
            //-----------------------------------------------------------
            if (this._guideEnableControlDictionary.ContainsKey(nextControl.Name))
			{
				this._guideButton.SharedProps.Enabled = true;
				this._guideButton.SharedProps.Tag = this._guideEnableControlDictionary[nextControl.Name];

				this._detailInput.uButton_Guide.Enabled = false;
			}
			else
			{
				this._guideButton.SharedProps.Enabled = false;
				this._guideButton.SharedProps.Tag = "";

				if (!this._guideEnableExceptControlDictionary.ContainsKey(nextControl.Name))
				{
					this._detailInput.uButton_Guide.Enabled = false;
				}
			}

            //-----------------------------------------------------------
            // 確定ボタン
            //-----------------------------------------------------------
            if (this._detailInputAcs.IsDataChanged == true)
            {
                this._saveButton.SharedProps.Enabled = true;
            }
            else
            {
                this._saveButton.SharedProps.Enabled = false;
            }

		}
		# endregion ■ ガイドボタンツール有効無効設定処理 ■

        # region ■ StatusBarメッセージ表示処理 ■
        /// <summary>
        /// StatusBarメッセージ表示処理
        /// </summary>
        /// <param name="nextControl">次のコントロール</param>
        private void StatusBarMessageSettingProc(Control nextControl)
        {
            string message = "";

            if (nextControl.Name == tComboEditor_TerminalDiv.Name)
            {
                message = MESSAGE_TerminalDiv;
            }
            else if (nextControl.Name == tComboEditor_TerminalNoDiv.Name)
            {
                message = MESSAGE_TerminalNoDiv;
            }
            else if (nextControl.Name == tNedit_TerminalNo.Name)
            {
                message = MESSAGE_TerminalNo;
            }
            else if (nextControl.Name == tComboEditor_SysDiv.Name)
            {
                message = MESSAGE_SysDiv;
            }
            else if (nextControl.Name == tNedit_St_OnlineNo.Name)
            {
                message = MESSAGE_St_OnlineNo;
            }
            else if (nextControl.Name == tNedit_Ed_OnlineNo.Name)
            {
                message = MESSAGE_Ed_OnlineNo;
            }
            else if (nextControl.Name == tDateEdit_InputDateSt.Name)
            {
                message = MESSAGE_InputDateSt;
            }
            else if (nextControl.Name == tDateEdit_InputDateEd.Name)
            {
                message = MESSAGE_InputDateEd;
            }
            else if (nextControl.Name == tNedit_CustomerCode.Name)
            {
                message = MESSAGE_CustomerCode;
            }
            else if (nextControl.Name == tNedit_SupplierCd.Name)
            {
                message = MESSAGE_SupplierCd;
            }
            else
            {
                message = "";
            }
            StockDetailInput_StatusBarMessageSetting(this, message);
        }
        # endregion ■  StatusBarメッセージ表示処理 ■

        # region ■ 指定フォーカス設定処理 ■
        /// <summary>
        /// 指定フォーカス設定処理
        /// </summary>
        private void SetControlFocus(Control control)
        {
            if (control == null) return;
            if (control.Enabled != true) return;
            if (control.Visible != true) return;
            control.Focus();

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(control);
            this.StatusBarMessageSettingProc(control);
        }
        # endregion

        # region ■ コントロールインデックス取得処理 ■
        /// <summary>
        /// コントロールインデックス取得処理
        /// </summary>
        /// <param name="prevCtrl">現在のコントロールの名称</param>
        /// <param name="mode">0:上から 1:下から</param>
        /// <returns>コントロールインデックス</returns>
        private int GetControlIndex ( string prevCtrl, int mode )
        {
            int controlIndex = 0;

            switch ( mode ) {
                case 0: {
                        if ( this._controlIndexForwordDictionary.ContainsKey(prevCtrl) ) {
                            controlIndex = this._controlIndexForwordDictionary[prevCtrl];
                        }

                        break;
                    }
                case 1: {
                        if ( this._controlIndexBackDictionary.ContainsKey(prevCtrl) ) {
                            controlIndex = this._controlIndexBackDictionary[prevCtrl];
                        }

                        break;
                    }
            }

            return controlIndex;
		}
		# endregion ■ コントロールインデックス取得処理 ■

		/// <summary>
        /// ネクストコントロール取得処理
        /// </summary>
        /// <param name="prevCtrl">現在のコントロール</param>
        /// <param name="mode">0:上から 1:下から</param>
        /// <returns>次のコントロール</returns>
        private Control GetNextControl ( Control prevCtrl, int mode )
        {
            Control control = null;

            switch ( mode ) {
                case 0: {
						int prevControlIndex = this.GetControlIndex(prevCtrl.Name, mode);
                        break;
                    }
                case 1: {
						break;
                    }
            }

            return control;
        }

        # endregion ■ フォーカス関連処理 ■

        # region ■ 終了処理 ■
        /// <summary>
		/// 終了処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		private void Close(bool isConfirm)
		{
			if ((isConfirm) && (this._detailInputAcs.IsDataChanged) && this._detailInputAcs.StockRowExists())
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"送信処理を終了してもよろしいですか？",
					0,
					MessageBoxButtons.YesNoCancel,
					MessageBoxDefaultButton.Button1);

				if (dialogResult == DialogResult.Yes)
				{
					this.Close();
				}
				else
				{
					return;
				}
			}
			else
			{
				this.Close();
			}
        }
        # endregion ■ 終了処理 ■

        # region ■ 保存処理 ■
        /// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="isShowSaveCompletionDialog">保存完了ダイアログ表示フラグ</param>
		/// <returns>true:保存完了 false:未保存</returns>
        /// <remarks>
        /// <br>Update Note: 2012/11/21 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// </remarks>
		private bool updateMain()
		{
			bool isSave = false;

			try
			{
                //-----------------------------------------------------------
                // データ書き込みチェック
                //-----------------------------------------------------------
                if (this._detailInputAcs.IsDataChanged == false) return(isSave);

                //グリッド内容の更新ダミー処理
                this.SetControlFocus(uLabel_CustomerName);

                # region データ書き込みチェック
                this.Cursor = Cursors.WaitCursor;
				string retMessage;

				List<string> itemNameList = new List<string>();
				List<string> itemList = new List<string>();

                // 2009/09/24 >>>
				//if (this._detailInputAcs.SaveDataCheck(InpDisplay.BusinessCode, out itemNameList, out itemList) != true)
                if (this._detailInputAcs.SaveDataCheck(InpDisplay.BusinessCode, InpDisplay.SystemDivCd, out itemNameList, out itemList) != true)
                // 2009/09/24 <<<
                {
					StringBuilder message = new StringBuilder();
					message.Append("未入力の項目が存在するため、登録できません。" + "\r\n" + "\r\n");

					foreach (string s in itemNameList)
					{
						message.Append(s + "\r\n");
					}

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						message.ToString(),
						0,
						MessageBoxButtons.OK);

					string itemName = "";
					if (itemList.Count > 0)
					{
						itemName = itemList[0].ToString();

						// 指定フォーカス設定処理
						//this.SetControlFocus(itemName);
					}
					return isSave;
                }
                # endregion

                //-----------------------------------------------------------
                // データ書き込み処理
                //-----------------------------------------------------------
                # region データ書き込み処理
                //----- ADD 2012/11/21 田建委 Redmine#33506 -------------------->>>>>
                DialogResult dialogResult = DialogResult.Yes;
                bool isColumnFilter = this._detailInput.IsColumnFilter();
                if (isColumnFilter)
                {
                    dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "フィルタ前の全データが発注対象となります。\n送信してよろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);
                }
                else
                {
                //----- ADD 2012/11/21 田建委 Redmine#33506 --------------------<<<<<
                    //実行メッセージ表示
                    //DialogResult dialogResult = TMsgDisp.Show( // DEL 2012/11/21 田建委 Redmine#33506
                    dialogResult = TMsgDisp.Show( // ADD 2012/11/21 田建委 Redmine#33506
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "送信処理を実行してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);
                } // ADD 2012/11/21 田建委 Redmine#33506

                if (dialogResult != DialogResult.Yes)
                {
                    return isSave;
                }

                // 書込処理
				int status = this._detailInputAcs.WriteDB(InpDisplay, out retMessage);

                // 明細グリッド設定処理
                this._detailInput.SettingGrid();

                //行クリア
                isSave = true;
                # endregion
            }
			finally
			{
				this.Cursor = Cursors.Default;
			}

			return isSave;
        }
        # endregion ■ 保存処理 ■

		# region ■ 削除処理 ■
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <returns>true:削除完了 false:削除失敗</returns>
        /// <remarks>
        /// <br>Update Note: 2012/11/21 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// <br>Update Note: 2012/12/17 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 フィルタされた状態で取消する時メッセージの変更対応</br>
        /// </remarks>
        bool deleteMain()
		{
            bool retBool = false;
			int status = 0;
			string message = "";

			try
            {
                //削除件数のチェック
                if (this._detailInputAcs.IsDataChanged == false) return (retBool);
                if (this._detailInputAcs.GetDeleteCount() <= 0)
                {
                    StringBuilder messageBuilder = new StringBuilder();
                    messageBuilder.Append("取消対象のデータが選択されていません。" + "\r\n");

                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        messageBuilder.ToString(),
                        0,
                        MessageBoxButtons.OK);
                    return retBool;
                }

                //削除メッセージ表示
                //----- ADD 2012/11/21 田建委 Redmine#33506 -------------------->>>>>
                DialogResult dialogResult = DialogResult.Yes;
                bool isColumnFilter = this._detailInput.IsColumnFilter();
                if (isColumnFilter)
                {
                    dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        //"フィルタ前の全選択済みデータが取消対象となります。\n削除してよろしいですか？", // DEL 2012/12/17 田建委 Redmine#33506
                        "フィルタ前の選択済みデータが取消対象となります。\n削除してよろしいですか？", // ADD 2012/12/17 田建委 Redmine#33506
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);
                }
                else
                {
                //----- ADD 2012/11/21 田建委 Redmine#33506 --------------------<<<<<
                    //DialogResult dialogResult = TMsgDisp.Show( // DEL 2012/11/21 田建委 Redmine#33506
                    dialogResult = TMsgDisp.Show( // ADD 2012/11/21 田建委 Redmine#33506
                        this,
                        emErrorLevel.ERR_LEVEL_QUESTION,
                        this.Name,
                        "選択行を削除してもよろしいですか？",
                        0,
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button1);
                } // ADD 2012/11/21 田建委 Redmine#33506

                if (dialogResult != DialogResult.Yes)
                {
                    return retBool;
                }

                //削除処理の実行
				if ((status = this._detailInputAcs.DeleteDB(out message)) == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    retBool = true;

					// 明細グリッド設定処理
					this._detailInput.SettingGrid();

					SaveCompletionDialog dialog = new SaveCompletionDialog();
					dialog.ShowDialog(2);
                }
			}
			catch (Exception ex)
			{
                retBool = false;
                message = ex.Message;
				status = -1;
			}
			finally
			{
				if (status != 0)
                {
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
						"(" + status.ToString() + ")" +
						"削除に失敗しました。" + "\r\n" + "\r\n" + message,
						status,
						MessageBoxButtons.OK);
				}

			}
			return (retBool);
		}
        # endregion

        # region ■ 初期化処理 ■
        /// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
        /// <param name="detail">true:全クリア false:明細部クリア</param>
        /// <returns>true:初期化実行 false:初期化未実行</returns>
        /// <remarks>
        /// <br>UpdateNote : 2009/11/23 李占川 保守依頼③対応</br>
        /// <br>             在庫一括時の発注先選択制御の変更</br>
        /// </remarks>
        private bool Clear(bool isConfirm, bool detail)
        {
			if ((isConfirm) && (this._detailInputAcs.IsDataChanged) && this._detailInputAcs.StockRowExists())
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"実行しても宜しいですか？",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button1);

				if (dialogResult != DialogResult.Yes)
				{
					return false;
				}
			}

            //グリッド内容の更新ダミー処理
            this.SetControlFocus(uLabel_CustomerName);

			// 画面処理
            if (detail)
            {
                // コンボエディタアイテム初期設定処理
                this.ComboEditorItemInitialSetting();
            }
			// テーブルクリア処理
			this._detailInput.Clear();

            // 明細グリッド設定処理
            this._detailInput.SettingGrid(InpDisplay.BusinessCode, InpDisplay.SystemDivCd); // ADD 2009/11/23
            
            //ヘッダー部画面入入力部のクリア
            this._detailInput.ClearHedaerItem();

			// データ変更フラグプロパティをfalseにする
			this._detailInputAcs.IsDataChanged = false;

            //コントロール関連有効無効設定処理
            this.SettingControlEnabled();

            //----- ADD 2012/11/21 田建委 Redmine#33506 ----->>>>>
            List<ColumnInfo> settingList;
            GetColumnsListFromXml(InpDisplay, out settingList);

            this._detailInput.LoadGridColumnsSetting(settingList);
            //----- ADD 2012/11/21 田建委 Redmine#33506 -----<<<<<

			return true;
        }
        # endregion ■ 初期化処理 ■

        # region ■ 検索処理 ■
		/// <summary>
		/// 検索処理
		/// </summary>
		/// <returns></returns>
        /// <br>Update Note: 2011/05/10 朱俊成 入力日付の入力チェックの追加</br>
		private bool SearchOrderMain()
		{
            //-----------------------------------------------------------
            // ヘッダー部検索条件のチェック
            //-----------------------------------------------------------
            # region ヘッダー部検索条件のチェック
            // ADD 2011/05/10 ------>>>>>
            // 開始日付チェック
            DateTime retDateTime;
            if ((tDateEdit_InputDateSt.LongDate != 0) &&
                (DateTime.TryParse(this.tDateEdit_InputDateSt.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false))
            {
                TMsgDisp.Show(this,
                              emErrorLevel.ERR_LEVEL_INFO,
                              this.Name,
                              "開始日が不正です",
                              -1,
                              MessageBoxButtons.OK);
                this.SetControlFocus(this.tDateEdit_InputDateSt);
                return (false);

            }
            // 終了日付チェック
            if ((tDateEdit_InputDateEd.LongDate != 0) &&
                (DateTime.TryParse(this.tDateEdit_InputDateEd.GetDateTimeString("yyyy.MM.DD"), out retDateTime) == false))
            {
                TMsgDisp.Show(this,
                              emErrorLevel.ERR_LEVEL_INFO,
                              this.Name,
                              "終了日が不正です",
                              -1,
                              MessageBoxButtons.OK);
                this.SetControlFocus(this.tDateEdit_InputDateEd);
                return (false);

            }
            // ADD 2011/05/10 ------<<<<<
            InpDisplay = this.GetDisplay();
            List<Control> controlList = null;
            List<string> nameList = null;
            if (HedDataCheck(out nameList, out controlList) != true)
            {
                StringBuilder messageBuilder = new StringBuilder();
                messageBuilder.Append("ヘッダー部に入力値が不正な項目が存在するため、検索できません。" + "\r\n" + "\r\n");
                foreach (string s in nameList)
                {
                    messageBuilder.Append(s + "\r\n");
                }

                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    messageBuilder.ToString(),
                    0,
                    MessageBoxButtons.OK);

                this.SetControlFocus(controlList[0]);
                return(false);
            }
    		# endregion

            //-----------------------------------------------------------
            // クリア処理
            //-----------------------------------------------------------
            # region クリア処理
            if (this.Clear(true,false) != true)
            {
                return(false);
            }
    		# endregion

            //-----------------------------------------------------------
            // 検索実行処理
            //-----------------------------------------------------------
            # region 検索実行処理
            string message = "";
            int status = _detailInputAcs.SearchDB(InpDisplay, out message);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    message,
                    -1,
                    MessageBoxButtons.OK);

                this.timer_InitialSetFocus.Enabled = true;
                return (false);
            }

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this.ActiveControl);

            //コントロール関連有効無効設定処理
            this.SettingControlEnabled();
            # endregion

            return(true);
		}
		# endregion ■ 検索処理 ■

        # region ■ ヘッダー部入力チェック ■
        /// <summary>
        /// ヘッダー部入力チェック
        /// </summary>
        /// <param name="name">コントロール名称</param>
        /// <param name="control">コントロール</param>
        /// <returns>true:正常 false:エラー</returns>
        private bool HedDataCheck(out List<string> name, out List<Control> control)
        {
            bool bStatus = true;

            InpDisplay = this.GetDisplay();

            name = new List<string>();
            control = new List<Control>();

            //端末番号
            if((InpDisplay.CashRegisterNoDiv == ctTerminalNoDiv_Other)
            && (InpDisplay.CashRegisterNo == 0))
            {
                name.Add("端末番号");
                control.Add(this.tNedit_TerminalNo);
            }

            //入力日
            if ((InpDisplay.SalesDateSt != DateTime.MinValue)
            && (InpDisplay.SalesDateEd != DateTime.MinValue)
            && (InpDisplay.SalesDateSt > InpDisplay.SalesDateEd))
            {
                name.Add("入力日");
                control.Add(this.tDateEdit_InputDateSt);
            }

            //呼出番号
            if ((InpDisplay.UOESalesOrderNoSt != 0)
            && (InpDisplay.UOESalesOrderNoEd != 0)
            && (InpDisplay.UOESalesOrderNoSt > InpDisplay.UOESalesOrderNoEd))
            {
                name.Add("呼出番号");
                control.Add(this.tNedit_St_OnlineNo);
            }

            if (name.Count > 0)
            {
                bStatus = false;
            }

            return (bStatus);
        }
        # endregion

        # region ■ コントロール関連 ■
        /// <summary>
        /// コントロール関連有効無効設定処理
        /// </summary>
        private void SettingControlEnabled()
        {
            if (this._detailInputAcs.IsDataChanged == true)
            {
                this.tComboEditor_TerminalNoDiv.Enabled = false;
                this.tNedit_TerminalNo.Enabled = false;
                this.tComboEditor_SysDiv.Enabled = false;
                this.tNedit_St_OnlineNo.Enabled = false;
                this.tNedit_Ed_OnlineNo.Enabled = false;
                this.tDateEdit_InputDateSt.Enabled = false;
                this.tDateEdit_InputDateEd.Enabled = false;
                this.tNedit_CustomerCode.Enabled = false;
                this.tNedit_SupplierCd.Enabled = false;
                this.uButton_CustomerGuide.Enabled = false;
                this.uButton_SupplierGuide.Enabled = false;
            }
            else
            {
                this.tComboEditor_TerminalNoDiv.Enabled = true;

                //他端末
                if ((Int32)(this.tComboEditor_TerminalNoDiv.Value) == ctTerminalNoDiv_Other)
                {
                    this.tNedit_TerminalNo.Enabled = true;
                }
                //自端末・全端末
                else
                {
                    this.tNedit_TerminalNo.Enabled = false;
                }

                this.tComboEditor_SysDiv.Enabled = true;
                this.tNedit_St_OnlineNo.Enabled = true;
                this.tNedit_Ed_OnlineNo.Enabled = true;
                this.tDateEdit_InputDateSt.Enabled = true;
                this.tDateEdit_InputDateEd.Enabled = true;
                this.tNedit_CustomerCode.Enabled = true;
                this.tNedit_SupplierCd.Enabled = true;
                this.uButton_CustomerGuide.Enabled = true;
                this.uButton_SupplierGuide.Enabled = true;
            }

            SettingToolBarButtonEnabled();
        }
        # endregion ■ コントロール関連 ■

		# region ■ ツールバー関連 ■
		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
        /// <remarks>
        /// <br>UpdateNote : 2009/11/23 李占川 保守依頼③対応</br>
        /// <br>             在庫一括時の発注先選択制御の変更</br>
        /// </remarks>
		private void SettingToolBarButtonEnabled()
		{
            if (this._detailInputAcs.IsDataChanged == true)
            {
                _searchButton.SharedProps.Enabled = false;
                _guideButton.SharedProps.Enabled = false;

                _saveButton.SharedProps.Enabled = true; // ADD 2009/11/23
                _sendNotButton.SharedProps.Enabled = false; // ADD 2009/11/23
            }
            else
            {
                _searchButton.SharedProps.Enabled = true;
                _guideButton.SharedProps.Enabled = true;

                _saveButton.SharedProps.Enabled = false; // ADD 2009/11/23
                _sendNotButton.SharedProps.Enabled = true; // ADD 2009/11/23
            }
        }
        # endregion ■ ツールバー関連 ■

        # region ■ ガイド関連処理 ■
        /// <summary>
		/// ガイド起動処理
		/// </summary>
		private void ExecuteGuide()
		{
			if (this._guideButton.SharedProps.Tag != null)
			{
				switch (this._guideButton.SharedProps.Tag.ToString())
				{
					//得意先
					case ctGUIDE_NAME_CustomerGuide:
					{
						this.uButton_CustomerGuide_Click(this.uButton_CustomerGuide, new EventArgs());
						break;
					}
					//発注先
					case ctGUIDE_NAME_SupplierGuide:
					{
						this.uButton_SupplierGuide_Click(this.uButton_SupplierGuide, new EventArgs());
						break;
					}
                    default :
                        break;
				}
			}
		}
        # endregion ■ ガイド関連処理 ■

		# endregion

		// ===================================================================================== //
		// 各コントロールイベント処理
		// ===================================================================================== //
		# region Control Event Methods
        # region ■ Formイベント ■
        /// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Update Note: 2012/11/21 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// <br>Update Note: 2013/04/01 wangyl</br>
        /// <br>管理番号   : 2013/04/10配信分</br>
        /// <br>             Redmine#34578の対応 システム区分によって、明細グリッドの「倉庫」の位置が異なります</br>
        /// </remarks>
		private void PMUOE01001UA_Load(object sender, EventArgs e)
		{
            try
            {
                string msg = string.Empty;
                int status = this._OLEScannerController.LoadOleControl(ref msg);
                if (status == 0)
                {
                    this._OLEScannerController.DataEvent += new DataEventHandler(this.OLEScanner_DataEvent);
                    this._OLEScannerController.ErrorEvent += new ErrorEventHandler(this.OLEScanner_ErrorEvent);

                    // オープン実行
                    status = this._OLEScannerController.Open(ref msg);

                    if (status == 0)
                    {
                        this._OLEScannerController.ClaimDevice(0, ref msg);
                        this._OLEScannerController.DeviceEnabled = true;
                        this._OLEScannerController.DataEventEnabled = true;
                        this._OLEScannerController.DecodeData = true;
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Skin設定
			this._controlScreenSkin.LoadSkin();
			this._controlScreenSkin.SettingScreenSkin(this);
			this._controlScreenSkin.SettingScreenSkin(this._detailInput);


			this.panel_Detail.Controls.Add(this._detailInput);
			this._detailInput.Dock = DockStyle.Fill;

			// ボタン初期設定処理
			this.ButtonInitialSetting();

			// 初期データ取得処理
            this._detailInputInitDataAcs.ReadInitData(this._enterpriseCode, this._loginSectionCode);

			// ツールバー初期設定処理
			this.ToolBarInitilSetting();

			// コンボエディタアイテム初期設定処理
			this.ComboEditorItemInitialSetting();

			// グリッドのリストを設定（データから設定する分）
            //UOESupplier uOESupplier = new UOESupplier();
            //uOESupplier.UOESupplierCd = 1000;
            //this._detailInput.SetGridList(uOESupplier);

            //----- ADD 2012/11/21 田建委 Redmine#33506 ----->>>>>
            // 設定値があればロード
            this._userSetting = new UOEUserConst();
            this.Deserialize();            
            //----- ADD 2012/11/21 田建委 Redmine#33506 -----<<<<<
            //---ADD 2013/04/01 wangyl Redmine#34578------>>>>>
            bool hasColWareHouse = false;

            // XMLファイルが最新かどうかを判断する
            if (this._userSetting.UserConstList != null)
            {
                foreach (UserConst uc in this._userSetting.UserConstList)
                {
                    // XMLファイルには倉庫情報があるかどうか判断する
                    foreach (ColumnInfo colInfo in uc.ColumnsList)
                    {
                        if (colInfo.ColumnName == NEW_COLNAME_WAREHOUSE)
                        {
                            hasColWareHouse = true;
                            break;
                        }
                    }
                }
                // XMLファイルが最新ではない場合、削除処理を行う
                if (!hasColWareHouse)
                {
                    this._userSetting = new UOEUserConst();
                    string filePath = System.IO.Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }
            //---ADD 2013/04/01 wangyl Redmine#34578------<<<<<

			// クリア処理
			this.Clear(false,false);

			this.timer_InitialSetFocus.Enabled = true;
		}

        //----- ADD 2012/11/21 田建委 Redmine#33506 -------------------->>>>>
        /// <summary>
        /// Xmlファイルにより各列の項目幅の取得
        /// </summary>
        /// <param name="InpDisplay"></param>
        /// <param name="settingList"></param>
        /// <remarks>
        /// <br>Note       : Xmlファイルにより各列の項目幅を取得する。</br>
        /// <br>Update Note: 2012/11/21 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// </remarks>
        private void GetColumnsListFromXml(InpDisplay InpDisplay, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();

            if (this._userSetting.UserConstList == null) return;

            int systemDivCd = 0;
            if (InpDisplay.SystemDivCd == ctSysDiv_Slip || InpDisplay.SystemDivCd == ctSysDiv_Srch)
            {
                systemDivCd = 0;
            }
            else
            {
                systemDivCd = InpDisplay.SystemDivCd;
            }

            foreach (UserConst uc in this._userSetting.UserConstList)
            {
                if (uc.BusinessCode == InpDisplay.BusinessCode && uc.SystemDivCd == systemDivCd)
                {
                    settingList = uc.ColumnsList;
                }
            }           
        }

        /// <summary>
        /// UOE送信処理用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <remarks>
        /// <br>Note       : UOE送信処理用ユーザー設定シリアライズします。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/11/21</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// </remarks>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, System.IO.Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// UOE送信処理用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE送信処理用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/11/21</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<UOEUserConst>(System.IO.Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
                }
                catch
                {
                    this._userSetting = new UOEUserConst();
                }
            }
        }
        //----- ADD 2012/11/21 田建委 Redmine#33506 --------------------<<<<<

		# region ■ フォームクロージングイベント ■
		/// <summary>
		/// フォームクロージングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void PMUOE01001UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			//this._superSlider.ClosePanel();
            string msg = "";
            this._OLEScannerController.DeviceEnabled = false;
            this._OLEScannerController.ReleaseDevice(ref msg);
            this._OLEScannerController.Close(ref msg);
		}
		# endregion ■ フォームクロージングイベント ■

		# endregion ■ Formイベント ■

		# region ■ ChangeFocusイベント ■
		/// <summary>
		/// フォーカスコントロールイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			bool canChangeFocus;
			int code;

			if (e.PrevCtrl == null || e.NextCtrl == null) return;
			if (InpDisplay == null) return;

			switch (e.PrevCtrl.Name)
			{
                // グリッド =============================================== //
				case "uGrid_Details": 
                {
                    #region [ uGrid_Details ]
                    switch (e.Key)
					{
						case Keys.Return:
						{
							if (this._detailInput.uGrid_Details.ActiveCell != null)
							{
								if (this._detailInput.ReturnKeyDown())
								{
									e.NextCtrl = null;
								}
								else
								{
								}
							}
							break;
						}
                    }
                    #endregion
                    break;
				}

			// 業務区分 ============================================ //
			case "tComboEditor_TerminalDiv":
				{
					#region [ tComboEditor_TerminalDiv ]
					InpDisplay.BusinessCode = (Int32)tComboEditor_TerminalDiv.Value;
					#endregion
					break;
				}
			// 端末区分 ============================================ //
			case "tComboEditor_TerminalNoDiv":
				#region [ tComboEditor_TerminalNoDiv ]
                InpDisplay.CashRegisterNoDiv = (Int32)tComboEditor_TerminalNoDiv.Value;
				#endregion
				break;

			// 端末番号 ============================================ //
			case "tNedit_TerminalNo":
				#region [ tNedit_TerminalNo ]
                InpDisplay.CashRegisterNo = this.tNedit_TerminalNo.GetInt();
				#endregion
				break;

			// システム区分 ============================================ //
			case "tComboEditor_SysDiv":
				#region [ tComboEditor_SysDiv ]
				InpDisplay.SystemDivCd = (Int32)tComboEditor_SysDiv.Value;
				#endregion
				break;

			// オンライン番号(開始） ============================================ //
            case "tNedit_St_OnlineNo":
				#region [ St_OnlineNo ]
				InpDisplay.UOESalesOrderNoSt = tNedit_St_OnlineNo.GetInt();
				#endregion
				break;

			// オンライン番号(終了） ============================================ //
            case "tNedit_Ed_OnlineNo":
				#region [ Ed_OnlineNo ]
				InpDisplay.UOESalesOrderNoEd = tNedit_Ed_OnlineNo.GetInt();
				#endregion
				break;

			// 入力日（開始） ============================================ //
			case "tDateEdit_InputDateSt":
				#region [ tDateEdit_InputDateSt ]
				InpDisplay.SalesDateSt = tDateEdit_InputDateSt.GetDateTime();
				#endregion
				break;

			// 入力日（終了） ============================================ //
			case "tDateEdit_InputDateEd":
				#region [ tDateEdit_InputDateEd ]
				InpDisplay.SalesDateEd = tDateEdit_InputDateEd.GetDateTime();
				#endregion
				break;

			// 得意先ｺｰﾄﾞ ============================================ //
			case "tNedit_CustomerCode":
				#region [ tNedit_CustomerCode ]
				canChangeFocus = true;
				code = this.tNedit_CustomerCode.GetInt();

				if (InpDisplay.CustomerCode != code)
				{
					if (code == 0)
					{
						InpDisplay.CustomerCode = 0;
						InpDisplay.CustomerName = "";
					}
					else
					{
                        string customerName = "";
                        if (_detailInputInitDataAcs.GetCustomerNameFromCustomerHTable(code, out customerName) == true)
						{
						    InpDisplay.CustomerCode = code;
						    InpDisplay.CustomerName = customerName;

						}
						else
						{
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "得意先が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
							canChangeFocus = false;
						}
                    }

					// NextCtrl制御
					if (canChangeFocus)
					{
						if (!e.ShiftKey)
						{
							switch (e.Key)
							{
								case Keys.Return:
								case Keys.Tab:
									{
										if (this.tNedit_CustomerCode.GetInt() == 0)
										{
											e.NextCtrl = this.uButton_CustomerGuide;
										}
										else
										{
											e.NextCtrl = this.tNedit_SupplierCd;
										}
										break;
									}
							}
						}
					}
					else
					{
						e.NextCtrl = e.PrevCtrl;
					}
				}

				#endregion
				break;

			// 発注先ｺｰﾄﾞ ============================================ //
			case "tNedit_SupplierCd":
				#region [ tNedit_SupplierCd ]
				canChangeFocus = true;
				code = this.tNedit_SupplierCd.GetInt();

				if (InpDisplay.UOESupplierCd != code)
				{
					if (code == 0)
					{
						InpDisplay.UOESupplierCd = code;
						InpDisplay.UOESupplierName = "";
					}
                    // 2009/05/25 START >>>>>>
                    //Uoe Web E-Partsの判定
                    //else if (_detailInputInitDataAcs.UOESupplierHondaEPaartsExists(code) == true) // DEL 2009/12/29 xuxh
                    else if (_detailInputInitDataAcs.UOESupplierUoeWebExists(code) == true)   // ADD 2009/12/29 xuxh 
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            // "ホンダＵＯＥ ＷＥＢの発注先は入力できません。", // DEL 2009/12/29 xuxh
                            "ＵＯＥ（Ｗｅｂ）の発注先は入力できません。", // ADD 2009/12/29 xuxh
                            -1,
                            MessageBoxButtons.OK);

                        canChangeFocus = false;
                    }
                    // 2009/05/25 END   <<<<<<
                    else if (_detailInputInitDataAcs.UOESupplierExists(code) == true)
                    {
                        //コード・名称セット
                        InpDisplay.UOESupplierCd = code;
                        InpDisplay.UOESupplierName = _detailInputInitDataAcs.GetName_FromUOESupplier(code);
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "発注先が存在しません。",
                            -1,
                            MessageBoxButtons.OK);

                        canChangeFocus = false;
                    }
				}

				// NextCtrl制御
				if (canChangeFocus)
				{
					if (!e.ShiftKey)
					{
						switch (e.Key)
						{
							case Keys.Return:
							case Keys.Tab:
								{
									if (this.tNedit_SupplierCd.GetInt() == 0)
									{
										e.NextCtrl = this.uButton_SupplierGuide;
									}
									else
									{
										e.NextCtrl = this.tNedit_SupplierCd;
									}
									break;
								}
						}
					}
				}
				else
				{
					e.NextCtrl = e.PrevCtrl;
				}

				#endregion
				break;
			}

			// メモリ上の内容と比較する
			InpDisplay InpDisplayNow = this.GetDisplay();
			ArrayList arRetList = InpDisplay.Compare(InpDisplayNow);

			if (arRetList.Count > 0)
			{
				// 画面情報クラス→画面格納処理
				this.SetDisplay(InpDisplay);
			}

			// ガイドボタンツール有効無効設定処理
			if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
			{
				this.SettingGuideButtonToolEnabled(e.NextCtrl);
                this.StatusBarMessageSettingProc(e.NextCtrl);
            }
        }
        # endregion ■ ChangeFocusイベント ■

        # region ■ 各種タイマー起動イベント ■
        /// <summary>
		/// 初期フォーカス設定タイマー起動イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void timer_InitialSetFocus_Tick(object sender, EventArgs e)
		{
			this.timer_InitialSetFocus.Enabled = false;
			bool isSetting = false;

			if (!isSetting)
			{
                SetControlFocus(this.tComboEditor_TerminalDiv);
				this._guideButton.SharedProps.Tag = "";
			}
			this.timer_InitialSetSlider.Enabled = true;
		}
        # endregion ■ 各種タイマー起動イベント ■

		# region ■ ツールバーイベント ■
		/// <summary>
		/// ツールバーボタンクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>UpdateNote : 2009/11/23 李占川 保守依頼③対応</br>
        /// <br>             在庫一括時の発注先選択制御の変更</br>
        /// <br>Update Note: 2012/11/21 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// <br>Update Note: 2012/12/17 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 未送信一覧から呼び出すと項目幅が異なる対応</br>
        /// </remarks>
		private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			//画面→抽出条件クラス
			InpDisplay = this.GetDisplay();

			switch (e.Tool.Key)
			{
				//終了処理
				case "ButtonTool_Close":
				{
					// 終了処理
					this.Close(true);
					break;
				}
				//確定処理
				case "ButtonTool_Save":
				{
                    bool isStatus = false;
					//取消処理
					if (InpDisplay.BusinessCode == ctTerminalDiv_Cancel)
					{
                        isStatus = this.deleteMain();
					}
					//更新処理
					else
					{
						isStatus = this.updateMain();
					}

                    //----- ADD 2012/11/21 田建委 Redmine#33506 ------------>>>>>
                    UserConst userConst = new UserConst();
                    int systemDivCd = 0;
                    userConst.BusinessCode = InpDisplay.BusinessCode;
                    // 伝発発注、検索発注の場合
                    if (InpDisplay.SystemDivCd == ctSysDiv_Slip || InpDisplay.SystemDivCd == ctSysDiv_Srch)
                    {
                        systemDivCd = 0;
                    }
                    else
                    {
                        systemDivCd = InpDisplay.SystemDivCd;
                    }
                    userConst.SystemDivCd = systemDivCd;

                    // グリッドカラム情報の保存
                    List<ColumnInfo> settingList;
                    this._detailInput.SaveGridColumnsSetting(out settingList);
                    userConst.ColumnsList = settingList;

                    if (this._userSetting.UserConstList != null)
                    {
                        List<UserConst> temSettingList = new List<UserConst>(this._userSetting.UserConstList);
                        foreach (UserConst uc in temSettingList)
                        {
                            if (uc.BusinessCode == InpDisplay.BusinessCode && uc.SystemDivCd == systemDivCd)
                            {
                                this._userSetting.UserConstList.Remove(uc);
                            }
                        }
                    }
                    else
                    {
                        this._userSetting.UserConstList = new List<UserConst>();
                    }
                    this._userSetting.UserConstList.Add(userConst);

                    // Xmlへ保存する
                    this.Serialize();
                    //----- ADD 2012/11/21 田建委 Redmine#33506 ------------<<<<<

                    //画面初期化処理
					if (isStatus)
					{
						this.Clear(false,true);
						this.timer_InitialSetFocus.Enabled = true;
					}
                    
					break;
				}
				//検索処理
				case "ButtonTool_Search":
				{
					//検索処理
					if (this.SearchOrderMain() == true)
                    {
                        // 明細グリッドセル設定処理
                        this._detailInput.SettingGrid(InpDisplay.BusinessCode, InpDisplay.SystemDivCd);
                        this._detailInput.uGrid_Details.Focus();
					}
					break;
				}
                //新規処理
                case "ButtonTool_New":
                {
                    bool isSave = this.Clear(true, true);

                    if (isSave)
                    {
                        this.timer_InitialSetFocus.Enabled = true;
                    }
                    break;
                }
                // ガイド起動処理
				case "ButtonTool_Guide":
				{
					this.ExecuteGuide();
					break;
				}
                // --- ADD 2009/11/23 ---------->>>>>
                // 未送信一覧
                case "ButtonTool_SendNot":
                {
                    PMUOE01001UC sendNotForm = new PMUOE01001UC();
                    DialogResult dialogResult = sendNotForm.ShowDialog(this);

                    if (dialogResult == DialogResult.OK)
                    {
                        // 初期設定処理
                        this.SetAfterSendNot();

                        //コントロール関連有効無効設定処理
                        this.SettingControlEnabled(); 

                        // 明細グリッドセル設定処理
                        this._detailInput.SettingGrid(InpDisplay.BusinessCode, InpDisplay.SystemDivCd);
                        this._detailInput.uGrid_Details.Focus();

                        //----- ADD 2012/12/17 田建委 Redmine#33506 ----->>>>>
                        List<ColumnInfo> settingList;
                        GetColumnsListFromXml(InpDisplay, out settingList);

                        this._detailInput.LoadGridColumnsSetting(settingList);
                        //----- ADD 2012/12/17 田建委 Redmine#33506 -----<<<<<
                    }
                    break;
                }
                // --- ADD 2009/11/23 ----------<<<<<
			}
		}

		/// <summary>
		/// コンボボックスツール値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_MainMenu_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "ComboBoxTool_SectionCode":			// 拠点コンボボックス
				{
					string selectedSectionCode = this._sectionComboBox.ValueList.ValueListItems[this._sectionComboBox.SelectedIndex].DataValue.ToString();
					//this._detailInputInitDataAcs.GetOwnSeCtrlCode(selectedSectionCode, SecInfoAcs.CtrlFuncCode.OwnSecSetting, out addUpSectionCode, out addUpSectionName);
					//this._addUpSectionNameLabel.SharedProps.Caption = addUpSectionName;
					//this._addUpSectionNameLabel.SharedProps.Tag = addUpSectionCode;

					//this._detailInput.SectionCode = selectedSectionCode;

                    try
                    {
                        //SecInfoSet secInfoSet;
                        //SecInfoAcs secInfoAcs = new SecInfoAcs();
                        //secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
                        //bool _optSection = !((secInfoAcs.GetMainOfficeFuncFlag(secInfoSet.SectionCode) == 0) || (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) <= 0));
                        //this.tToolbarsManager_MainMenu.Tools["ComboBoxTool_SectionCode"].SharedProps.Enabled = _optSection;
                    }
                    catch { }

					break;
				}
			}
        }
        # endregion ■ ツールバーイベント ■

        # region ■ ガイド関連イベント ■
		# region ■ 得意先ガイドボタンクリックイベント ■
		/// <summary>
		/// 得意先ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_CustomerGuide_Click(object sender, EventArgs e)
		{
            // 得意先ガイド用ライブラリ名変更
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
		}

		/// <summary>
		/// 得意先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
            if (customerSearchRet == null)
            {
                return;
            }

            this.InpDisplay.CustomerCode = customerSearchRet.CustomerCode;                    // 得意先コード
            this.InpDisplay.CustomerName = customerSearchRet.Name + customerSearchRet.Name2;   // 得意先名称

            this.tNedit_CustomerCode.SetInt(this.InpDisplay.CustomerCode);
            this.uLabel_CustomerName.Text = this.InpDisplay.CustomerName;

            // 結果
            ((PMKHN04005UA)sender).DialogResult = DialogResult.OK;
		}

		# endregion ■ 得意先ガイドボタンクリックイベント ■

		# region ■ 発注先ガイドボタンクリックイベント ■
		/// <summary>
		/// 発注先ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_SupplierGuide_Click(object sender, EventArgs e)
		{
			int status = -1;
			// インスタンス生成
            UOESupplier uOESupplier = null;

			// ガイド起動
			status = uOESupplierAcs.ExecuteGuid(_enterpriseCode, _loginSectionCode, out uOESupplier);

			// 項目に展開
			if (status == 0)
			{
                // 2009/05/25 START >>>>>>
                //Uoe Web E-Partsの判定
                //if (_detailInputInitDataAcs.UOESupplierHondaEPaartsExists(uOESupplier) == true) //DEL 2009/12/29 xuxh
                if (_detailInputInitDataAcs.UOESupplierUoeWebExists(uOESupplier) == true)   //ADD 2009/12/29 xuxh
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        // "ホンダＵＯＥ ＷＥＢの発注先は入力できません。", // DEL 2009/12/29 xuxh
                        "ＵＯＥ（Ｗｅｂ）の発注先は入力できません。", // ADD 2009/12/29 xuxh
                        -1,
                        MessageBoxButtons.OK);

                    return;
                }
                // 2009/05/25 END   <<<<<<

                _inpDisplay.UOESupplierCd = uOESupplier.UOESupplierCd;
				_inpDisplay.UOESupplierName = uOESupplier.UOESupplierName;

				this.tNedit_SupplierCd.SetInt(_inpDisplay.UOESupplierCd);
				this.uLabel_SupplierName.Text = _inpDisplay.UOESupplierName;
			}
		}
		# endregion ■ 発注先ガイドボタンクリックイベント ■
		# endregion ■ ガイド関連イベント ■

        # region ■ キー関連イベント ■
        /// <summary>
        /// 詳細グリッド最上位行キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void StockDetailInput_GridKeyDownTopRow ( object sender, EventArgs e )
        {
            Control control = this.GetNextControl(this._detailInput, 1);

            if ( control != null ) {
                control.Focus();
            }

            // ガイドボタンツール有効無効設定処理
            this.SettingGuideButtonToolEnabled(this.ActiveControl);
        }

        /// <summary>
        /// 詳細グリッド最下層行キーダウンイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void StockDetailInput_GridKeyDownButtomRow ( object sender, EventArgs e )
        {
        }
        # endregion ■ キー関連イベント ■

        # region ■ ステータスバーメッセージ表示イベント ■
        /// <summary>
        /// ステータスバーメッセージ表示イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="message">メッセージ</param>
        private void StockDetailInput_StatusBarMessageSetting ( object sender, string message )
        {
            this.uStatusBar_Main.Panels[0].Text = message;
        }
        # endregion ■ ステータスバーメッセージ表示イベント ■

        # region ■ データ変更イベント ■
        /// <summary>
        /// データ変更後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        private void StockInputAcs_DataChanged ( object sender, EventArgs e )
        {
            // ツールバーボタン有効無効設定処理
            this.SettingToolBarButtonEnabled();
        }
        # endregion ■ データ変更イベント ■

        # region ■ OLEScanner関連イベント ■
        /// <summary>
        /// OLEScannerデータ読み込みイベント
        /// </summary>
        /// <param name="status"></param>
        private void OLEScanner_DataEvent ( int status )
        {
            try
            {
			}
            finally
            {
                // イベントイネーブル実行
                this._OLEScannerController.DataEventEnabled = true;
            }
        }

        /// <summary>
        /// OLEScannerエラー発生イベント
        /// </summary>
        /// <param name="ResultCode"></param>
        /// <param name="ResultCodeExtended"></param>
        /// <param name="ErrorLocus"></param>
        /// <param name="pErrorResponse"></param>
        private void OLEScanner_ErrorEvent ( int ResultCode, int ResultCodeExtended, int ErrorLocus, ref int pErrorResponse )
        {
        }
        # endregion ■ OLEScanner関連イベント ■

		# region ■ 業務区分値変更イベント ■
		/// <summary>
		/// 業務区分値変更イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2012/11/21 田建委</br>
        /// <br>管理番号   : 2013/01/16配信分</br>
        /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// </remarks>
		private void tComboEditor_TerminalDiv_ValueChanged(object sender, EventArgs e)
		{
			Int32 code = (Int32)this.tComboEditor_TerminalDiv.Value;
			if (code == InpDisplay.BusinessCode) return;
			InpDisplay.BusinessCode = code;

            // 明細グリッド設定処理
            this._detailInput.SettingGrid(InpDisplay.BusinessCode, InpDisplay.SystemDivCd);

            //----- ADD 2012/11/21 田建委 Redmine#33506 ----->>>>>
            List<ColumnInfo> settingList;
            GetColumnsListFromXml(InpDisplay, out settingList);

            this._detailInput.LoadGridColumnsSetting(settingList);
            //----- ADD 2012/11/21 田建委 Redmine#33506 -----<<<<<
		}
		# endregion ■ 業務区分値変更イベント ■

        // --- ADD 2009/11/23 ---------->>>>>
        # region ■ システム区分値変更イベント ■
        /// <summary>
        /// システム区分値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: システム区分値変更イベント</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/23</br>
        /// <br>Update Note : 2012/11/21 田建委</br>
        /// <br>管理番号    : 2013/01/16配信分</br>
        /// <br>              Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
        /// </remarks>
        private void tComboEditor_SysDiv_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_SysDiv.SelectedItem == null) return;
            Int32 code = (Int32)this.tComboEditor_SysDiv.SelectedItem.DataValue;
            if (code == InpDisplay.SystemDivCd) return;
            InpDisplay.SystemDivCd = code;

            this._detailInput.SettingGridSupply(InpDisplay.SystemDivCd);

            //----- ADD 2012/11/21 田建委 Redmine#33506 ----->>>>>
            List<ColumnInfo> settingList;
            GetColumnsListFromXml(InpDisplay, out settingList);

            this._detailInput.LoadGridColumnsSetting(settingList);
            //----- ADD 2012/11/21 田建委 Redmine#33506 -----<<<<<
        }
        # endregion ■ システム区分値変更イベント ■
        // --- ADD 2009/11/23 ----------<<<<<

        # region ■ 端末区分値変更イベント ■
        /// <summary>
		/// 端末区分値変更イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tComboEditor_TerminalNoDiv_ValueChanged(object sender, EventArgs e)
        {

            Int32 code = (Int32)this.tComboEditor_TerminalNoDiv.Value;
			if (code == InpDisplay.CashRegisterNoDiv) return;
			InpDisplay.CashRegisterNoDiv = code;

			//端末番号
			switch (InpDisplay.CashRegisterNoDiv)
			{
				//自端末
				case ctTerminalNoDiv_Own:
					{
                        InpDisplay.CashRegisterNo = cashRegisterNo;
						tNedit_TerminalNo.Enabled = false;
						break;
					}

				//他端末
				case ctTerminalNoDiv_Other:
					{
						tNedit_TerminalNo.Enabled = true;
						break;
					}
				//全端末
				case ctTerminalNoDiv_All:
					{
						InpDisplay.CashRegisterNo = 0;
						tNedit_TerminalNo.Enabled = false;
						break;
					}
			}
            this.tNedit_TerminalNo.SetInt(InpDisplay.CashRegisterNo);


		}
		# endregion ■ 端末区分値変更イベント ■

        // --- ADD 2009/11/23 ---------->>>>>
        # region ■ 初期設定処理 ■
        /// <summary>
        /// 初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 未送信一覧戻るに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/11/237</br>
        /// </remarks>
        private void SetAfterSendNot()
        {
            if (InpDisplay == null)
            {
                _inpDisplay = new InpDisplay();
            }

            //環境項目
            InpDisplay.EnterpriseCode = this._enterpriseCode;	//企業コード
            InpDisplay.SectionCode = this._loginSectionCode;	//拠点コード
            InpDisplay.SectionName = this._loginSectionName;	//拠点名
            InpDisplay.EmployeeCode = this._employeeCode;		//入力担当者コード
            InpDisplay.EmployeeName = this._employeeName;		//入力担当者名

            //入力項目
            //InpDisplay.BusinessCode = ctTerminalDiv_Order;	//業務区分
            InpDisplay.CashRegisterNoDiv = ctTerminalNoDiv_All;	//端末番号
            InpDisplay.CashRegisterNo = 0;			            //端末番号
            InpDisplay.SystemDivCd = this._detailInputAcs.SelectSysDiv;		//システム区分

            InpDisplay.UOESalesOrderNoSt = 0;					//オンライン番号(開始）
            InpDisplay.UOESalesOrderNoEd = 0;					//オンライン番号(終了）
            InpDisplay.SalesDateSt = DateTime.MinValue;	        //入力日（開始）
            InpDisplay.SalesDateEd = DateTime.MinValue;	        //入力日（終了）
            InpDisplay.CustomerCode = 0;				        //得意先ｺｰﾄﾞ
            InpDisplay.UOESupplierCd = 0;					    //発注先ｺｰﾄﾞ

            //出力項目
            InpDisplay.CustomerName = "";				        //得意先名称
            InpDisplay.UOESupplierName = "";			        //発注先名称

            this.SetDisplay(InpDisplay);
        }
        # endregion ■ 初期設定処理 ■
		# endregion
	}

    //----- ADD 2012/11/21 田建委 Redmine#33506 ------------>>>>>
    #region
    [Serializable]
    /// <summary>
    /// UOEUserConst
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOEUserConstを作成する。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2012/11/21</br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
    /// </remarks>
    public class UOEUserConst
    {
        # region プライベート変数
        private List<UserConst> _userConstList;
        #endregion

        # region プロパティ
        public List<UserConst> UserConstList
        {
            get { return _userConstList; }
            set { _userConstList = value; }
        }
        #endregion

        # region コンストラクタ
        public UOEUserConst()
        {
        }
        #endregion

    }

    [Serializable]
    /// <summary>
    /// UserConst
    /// </summary>
    /// <remarks>
    /// <br>Note       : UserConstを作成する。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2012/11/21</br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
    /// </remarks>
    public struct UserConst
    {
        # region プライベート変数
        /// <summary>業務区分</summary>
        private int _businessCode;
        /// <summary>システム区分</summary>
        private int _systemDivCd;
        /// <summary>グリッドカラムリスト</summary>
        private List<ColumnInfo> _columnsList;
        #endregion

        # region プロパティ
        /// <summary>
        /// 業務区分
        /// </summary>
        public int BusinessCode
        {
            get { return _businessCode; }
            set { _businessCode = value; }
        }
        /// <summary>
        /// システム区分
        /// </summary>
        public int SystemDivCd
        {
            get { return _systemDivCd; }
            set { _systemDivCd = value; }
        }
        /// <summary>
        /// グリッドカラムリスト
        /// </summary>
        public List<ColumnInfo> ColumnsList
        {
            get { return _columnsList; }
            set { _columnsList = value; }
        }
        #endregion
    }

    # region [ColumnInfo]
    /// <summary>
    /// ColumnInfo
    /// </summary>
    [Serializable]
    /// <summary>
    /// グリッドカラムリスト
    /// </summary>
    /// <remarks>
    /// <br>Note       : グリッドカラムリストを作成する。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2012/11/21</br>
    /// <br>管理番号   : 2013/01/16配信分</br>
    /// <br>             Redmine#33506 伝発発注、検索発注の場合、グリッドに発注先を追加する対応</br>
    /// </remarks>
    public struct ColumnInfo
    {
        /// <summary>列名</summary>
        private string _columnName;
        /// <summary>並び順</summary>
        private int _visiblePosition;
        /// <summary>非表示フラグ</summary>
        private bool _hidden;
        /// <summary>幅</summary>
        private int _width;
        /// <summary>固定フラグ</summary>
        private bool _columnFixed;

        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
        /// <summary>
        /// 並び順
        /// </summary>
        public int VisiblePosition
        {
            get { return _visiblePosition; }
            set { _visiblePosition = value; }
        }
        /// <summary>
        /// 非表示フラグ
        /// </summary>
        public bool Hidden
        {
            get { return _hidden; }
            set { _hidden = value; }
        }
        /// <summary>
        /// 幅
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        /// <summary>
        /// 固定フラグ
        /// </summary>
        public bool ColumnFixed
        {
            get { return _columnFixed; }
            set { _columnFixed = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="visiblePosition">並び順</param>
        /// <param name="hidden">非表示フラグ</param>
        /// <param name="width">幅</param>
        /// <param name="columnFixed">固定フラグ</param>
        public ColumnInfo(string columnName, int visiblePosition, bool hidden, int width, bool columnFixed)
        {
            _columnName = columnName;
            _visiblePosition = visiblePosition;
            _hidden = hidden;
            _width = width;
            _columnFixed = columnFixed;
        }
    }
    #endregion
    # endregion
    //----- ADD 2012/11/21 田建委 Redmine#33506 ------------<<<<<
}
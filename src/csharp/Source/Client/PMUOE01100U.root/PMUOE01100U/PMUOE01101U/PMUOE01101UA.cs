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
    /// ＵＯＥ手入力発注フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＵＯＥ手入力発注のフォームクラスです。</br>
    /// <br>Programmer : 96186 立花裕輔</br>
    /// <br>Date       : 2008.05.12</br>
    /// <br></br>
    /// <br>Update Note: 2009.05.25 96186 立花 裕輔</br>
    /// <br>              ・ホンダ UOE WEB対応</br>
    /// <br>UpdateNote : 2009/12/29 xuxh</br>
    /// <br>           : 【要件No.2】                                                 
    /// <br>            発注先にトヨタを指定時には、リマーク２の入力は不可とする（連携時、ﾘﾏｰｸ2に連携番号として使用する為）                                                     
    /// <br>            仕入明細（発注データ）の作成を行い通信は行わない様にする</br>
    /// <br>           : 【Remide#2331】                                                 
    /// <br>            0103の場合、H納品区分取得の修正</br>
    /// <br>UpdateNote : 2009/01/21 張凱</br>
    /// <br>            発注先ﾏｽﾀのプログラムが0103の発注先を入力後、ENTERにて納品区分にﾌｫｰｶｽ移動させて下さい。</br>
    /// <br>           : 【Remide#2506】
    /// <br>Update Note: 2010/01/22 譚洪</br>
    /// <br>             Redmine:2571</br>
    /// <br>             納品区分・Ｈ納品区分・指定拠点をｽﾍﾟｰｽの設定を指定するとエラーになるの対応</br>
    /// <br>Update Note: 2010/03/08 楊明俊</br>
    /// <br>             PM1006</br>
    /// <br>             業務区分は「発注」（固定）に制御の対応</br>
    /// <br>UpdateNote : 2010/04/27 zhshh</br>
    /// <br>             PM1007C 三菱UOE-WEB対応に伴う仕様追加</br>
    /// <br>Update Note: 2011/01/06 鄧潘ハン</br>
    /// <br>             業務区分は「発注」（固定）に制御する</br>
    /// <br>Update Note: 2011/01/30 朱 猛</br>
    /// <br>             UOE自動化改良</br>
    /// <br>Update Note: 2011/03/01 liyp</br>
    /// <br>             業務区分は「発注」（固定）に制御する</br>
    /// <br>Update Note: 2011/05/10 施炳中</br>
    /// <br>             業務区分は「発注」（固定）に制御する</br>
    /// </remarks>
	public partial class PMUOE01101UA : Form
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		/// <summary>
		/// 在庫一括入力フォームクラス デフォルトコンストラクタ
		/// </summary>
		public PMUOE01101UA()
		{
			InitializeComponent();

			// 変数初期化
			this._detailInput = new PMUOE01101UB();
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

			this._controlScreenSkin = new ControlScreenSkin();

			this._stockInputAcs = StockInputAcs.GetInstance();
			this._stockInputInitDataAcs = StockInputInitDataAcs.GetInstance();

			this._detailInput.GridKeyDownTopRow += new EventHandler(this.StockDetailInput_GridKeyDownTopRow);
			this._detailInput.GridKeyDownButtomRow += new EventHandler(this.StockDetailInput_GridKeyDownButtomRow);
			this._detailInput.StatusBarMessageSetting += new PMUOE01101UB.SettingStatusBarMessageEventHandler(this.StockDetailInput_StatusBarMessageSetting);
            this._stockInputAcs.DataChanged += new EventHandler(this.StockInputAcs_DataChanged);

            // ガイド対応コントロール一覧
			this._guideEnableControlDictionary.Add(this.tNedit_UOESupplierCd.Name, ctGUIDE_NAME_SupplierGuide);
			this._guideEnableControlDictionary.Add(this.tEdit_EmployeeCode.Name, ctGUIDE_NAME_EmployeeGuide);

			this._guideEnableExceptControlDictionary.Add(this._detailInput.Name, this._detailInput);
			this._guideEnableExceptControlDictionary.Add(this._detailInput.uGrid_Details.Name, this._detailInput.uGrid_Details);
			this._guideEnableExceptControlDictionary.Add(this._detailInput.uButton_Guide.Name, this._detailInput.uButton_Guide);

			this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			this._addUpSectionNameLabel.SharedProps.Caption = "";

            int controlIndexForword = 0;
            this._controlIndexForwordDictionary.Add(this.tNedit_UOESupplierCd.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_BusinessCode.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_DeliveredGoodsDiv.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_FollowDeliGoodsDiv.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tComboEditor_UOEResvdSection.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tEdit_EmployeeCode.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tEdit_UoeRemark1.Name, controlIndexForword++);
            this._controlIndexForwordDictionary.Add(this.tEdit_UoeRemark2.Name, controlIndexForword++);

            int controlIndexBack = 99;
            this._controlIndexBackDictionary.Add(this.tNedit_UOESupplierCd.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_BusinessCode.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_DeliveredGoodsDiv.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_FollowDeliGoodsDiv.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tComboEditor_UOEResvdSection.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tEdit_EmployeeCode.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tEdit_UoeRemark1.Name, controlIndexBack--);
            this._controlIndexBackDictionary.Add(this.tEdit_UoeRemark2.Name, controlIndexBack--);
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
            get { return _stockInputInitDataAcs.uOESupplierAcs; }
        }
        # endregion


        # region 送受信ＪＮＬアクセスクラス
        /// <summary>
        /// 送受信ＪＮＬアクセスクラス
        /// </summary>
        public UoeSndRcvJnlAcs uoeSndRcvJnlAcs
        {
            get { return _stockInputInitDataAcs.uoeSndRcvJnlAcs; }
        }
        # endregion

        # endregion

        // ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private PMUOE01101UB _detailInput;
        
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

		private ControlScreenSkin _controlScreenSkin;

		private StockInputAcs _stockInputAcs;
		private StockInputInitDataAcs _stockInputInitDataAcs;

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

        private GuideNextFocusControl _guideNextControl;    // ガイド後次フォーカス制御

		//画面入力クラス
		private InpDisplay _inpDisplay;
		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		//Guide値
		private const string ctGUIDE_NAME_SupplierGuide = "SupplierGuide";
		private const string ctGUIDE_NAME_EmployeeGuide = "EmployeeGuide";

		//入力メッセージ
        private const string MESSAGE_BusinessCode = "業務区分を選択してください。";         //業務区分
		private const string MESSAGE_UOESupplierCd = "発注先を入力してください。";			//発注先
		private const string MESSAGE_DeliveredGoodsDiv = "納品区分を選択してください。";	//納品区分
		private const string MESSAGE_FollowDeliGoodsDiv = "Ｈ納品区分を選択してください。";	//Ｈ納品区分
		private const string MESSAGE_UOEResvdSection = "指定拠点を選択してください。";		//指定拠点
		private const string MESSAGE_EmployeeCode = "依頼者を入力してください。";			//依頼者
		private const string MESSAGE_UoeRemark1 = "リマーク１を入力してください。";			//リマーク１
		private const string MESSAGE_UoeRemark2 = "リマーク２を入力してください。";			//リマーク２
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

			//ImageList
			this.uButton_EmployeeGuide.ImageList = this._imageList16;
            this.uButton_UOESupplierGuide.ImageList = this._imageList16;

			//Appearance.Image
			this.uButton_EmployeeGuide.Appearance.Image = (int)Size16_Index.STAR1;
			this.uButton_UOESupplierGuide.Appearance.Image = (int)Size16_Index.STAR1;
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
				this._stockInputInitDataAcs.SetSectionComboEditor(ref this._sectionComboBox, false);

				// 拠点コンボエディタ選択値設定処理
				this._stockInputInitDataAcs.SetSectionComboEditorValue(this._sectionComboBox, this._loginSectionCode);
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
			this._addUpSectionTitleLabel.SharedProps.Visible = true;
			this._sectionComboBox.SharedProps.Visible = true;
			this._sectionComboBox.SharedProps.Enabled = true;
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

			UOESupplierCdChanged(0);
			SetDisplay(InpDisplay);
		}
		# endregion ■ コンボエディタアイテム初期設定処理 ■

        # region ■ ガイド後フォーカス制御設定 ■
        /// <summary>
        /// ガイド後フォーカス制御設定
        /// </summary>
        private void SettingGuideNextControl()
        {
            _guideNextControl = new GuideNextFocusControl();

            _guideNextControl.Add(tNedit_UOESupplierCd);
            _guideNextControl.Add(tComboEditor_BusinessCode);
            _guideNextControl.Add(tComboEditor_DeliveredGoodsDiv);
            _guideNextControl.Add(tComboEditor_FollowDeliGoodsDiv);
            _guideNextControl.Add(tComboEditor_UOEResvdSection);
            _guideNextControl.Add(tEdit_EmployeeCode);
            _guideNextControl.Add(tEdit_UoeRemark1);
            _guideNextControl.Add(tEdit_UoeRemark2);
        }
        # endregion ■ ガイド後フォーカス制御設定 ■

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

            this.tNedit_UOESupplierCd.SetInt(inpDisplay.UOESupplierCd);						//UOE発注先コード
            this.uLabel_UOESupplierName.Text = inpDisplay.UOESupplierName;					//UOE発注先名称

            if (this.tComboEditor_BusinessCode.MaxDropDownItems > 0)
            {   
                this.tComboEditor_BusinessCode.Value = inpDisplay.BusinessCode.ToString();  //業務区分
            }
            
			if (this.tComboEditor_DeliveredGoodsDiv.MaxDropDownItems > 0)
			{
                this.tComboEditor_DeliveredGoodsDiv.Value = inpDisplay.UOEDeliGoodsDiv;	//納品区分
			}

			if (this.tComboEditor_FollowDeliGoodsDiv.MaxDropDownItems > 0)
			{
				this.tComboEditor_FollowDeliGoodsDiv.Value = inpDisplay.FollowDeliGoodsDiv;	//フォロー納品区分
			}

			if (this.tComboEditor_UOEResvdSection.MaxDropDownItems > 0)
			{
                this.tComboEditor_UOEResvdSection.Value = inpDisplay.UOEResvdSection;		//UOE指定拠点
			}

			this.tEdit_EmployeeCode.Text = inpDisplay.EmployeeCode;						//依頼者コード
			this.uLabel_EmployeeName.Text = inpDisplay.EmployeeName;						//依頼者名称

			this.tEdit_UoeRemark1.Text = inpDisplay.UoeRemark1;								//ＵＯＥリマーク１
			this.tEdit_UoeRemark2.Text = inpDisplay.UoeRemark2;								//ＵＯＥリマーク２
		}
        # endregion ■ 画面データ→画面格納処理 ■

        # region ■ コンボエディタリスト設定(業務区分・納品区分・フォロー納品区分・UOE指定拠点) ■
        /// <summary>
		/// コンボエディタ設定(業務区分・納品区分・フォロー納品区分・UOE指定拠点)
		/// </summary>
		/// <param name="sender">コンボエディタ</param>
		/// <param name="list">設定用リスト</param>
		public void SetUOEGuideNameComboEditor(ref TComboEditor sender, List<UOEGuideName> list)
		{
			Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();

			if (list != null)
			{
				foreach (UOEGuideName uOEGuideName in list)
				{
					Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();

					secInfoItem.DataValue = uOEGuideName.UOEGuideCode.Trim();
					secInfoItem.DisplayText = uOEGuideName.UOEGuideNm.Trim();
					valueList.ValueListItems.Add(secInfoItem);
				}
			}

			if (valueList.ValueListItems.Count > 0)
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
			else
			{
				sender.Enabled = false;
			}
		}
		# endregion ■ 納品区分 ■


		# region ■ 画面→画面データクラス格納処理 ■
		/// <summary>
		/// 画面→画面データクラス格納処理
		/// </summary>
		/// <returns>
		/// 画面入力クラス</returns>
		private InpDisplay GetDisplay()
		{
			InpDisplay inpDisplay = new InpDisplay();

			//環境項目
			inpDisplay.EnterpriseCode = this._enterpriseCode;	//企業コード
			inpDisplay.SectionCode = this._loginSectionCode;	//拠点コード
			inpDisplay.SectionName = this._loginSectionName;	//拠点名
            inpDisplay.SystemDivCd = (int)EnumUoeConst.ctSystemDivCd.ct_Input;	//システム区分 0:手入力 1:伝発 2:検索 3：一括 4：補充

			//業務区分
            if (this.tComboEditor_BusinessCode.Value != null)
            {
                inpDisplay.BusinessCode = ToInt32FromString(this.tComboEditor_BusinessCode.Value.ToString());			//納品区分
            }
            else
            {
                inpDisplay.BusinessCode = 0;
            }

			//入力項目
			inpDisplay.UOESupplierCd = this.tNedit_UOESupplierCd.GetInt();							//UOE発注先コード
			inpDisplay.UOESupplierName = this.uLabel_UOESupplierName.Text;							//発注先名称

			//納品区分
			if (this.tComboEditor_DeliveredGoodsDiv.Value != null)
			{
                inpDisplay.UOEDeliGoodsDiv = this.tComboEditor_DeliveredGoodsDiv.Value.ToString();			//納品区分
				inpDisplay.DeliveredGoodsDivNm = this.tComboEditor_DeliveredGoodsDiv.Text;				//納品区分名称
			}
			else
			{
                inpDisplay.UOEDeliGoodsDiv = "";
				inpDisplay.DeliveredGoodsDivNm = "";
			}

			//フォロー納品区分
			if (this.tComboEditor_FollowDeliGoodsDiv.Value != null)
			{
				inpDisplay.FollowDeliGoodsDiv = this.tComboEditor_FollowDeliGoodsDiv.Value.ToString();	//フォロー納品区分
				inpDisplay.FollowDeliGoodsDivNm = this.tComboEditor_FollowDeliGoodsDiv.Text;			//フォロー納品区分名称
			}
			else
			{
				inpDisplay.FollowDeliGoodsDiv = "";		//フォロー納品区分
				inpDisplay.FollowDeliGoodsDivNm = "";	//フォロー納品区分名称
			}

			//UOE指定拠点
			if (this.tComboEditor_UOEResvdSection.Value != null)
			{
				inpDisplay.UOEResvdSection = this.tComboEditor_UOEResvdSection.Value.ToString();	//UOE指定拠点
				inpDisplay.UOEResvdSectionNm = this.tComboEditor_UOEResvdSection.Text;				//UOE指定拠点名称
			}
			else
			{
				inpDisplay.UOEResvdSection = "";	//UOE指定拠点
				inpDisplay.UOEResvdSectionNm = "";	//UOE指定拠点名称
			}
			
			inpDisplay.EmployeeCode = this.tEdit_EmployeeCode.Text.Trim();		//依頼者コード
			inpDisplay.EmployeeName = this.uLabel_EmployeeName.Text.Trim();		//依頼者名称
			inpDisplay.UoeRemark1 = this.tEdit_UoeRemark1.Text.Trim();			//ＵＯＥリマーク１
			inpDisplay.UoeRemark2 = this.tEdit_UoeRemark2.Text.Trim();			//ＵＯＥリマーク２
			return inpDisplay;
		}
		# endregion ■ 画面→画面データクラス格納処理 ■

		# region ■ 画面データクラスの初期化 ■
        /// <summary>
        /// 画面データクラスの初期化
        /// </summary>
        /// <param name="inpDisplay">画面データクラス</param>
        private void ClearOrderInpDisplay(InpDisplay inpDisplay)
        {
            //環境項目
            inpDisplay.EnterpriseCode = this._enterpriseCode;	//企業コード
            inpDisplay.SectionCode = this._loginSectionCode;	//拠点コード
            inpDisplay.SectionName = this._loginSectionName;	//拠点名
            inpDisplay.SystemDivCd = 0;							//システム区分 0:手入力 1:伝発 2:検索 3：一括 4：補充

            inpDisplay.EmployeeCode = "";			//依頼者コード
            inpDisplay.EmployeeName = "";			//依頼者名称

            inpDisplay.UoeRemark1 = "";				//ＵＯＥリマーク１
            inpDisplay.UoeRemark2 = "";				//ＵＯＥリマーク２

            inpDisplay.BusinessCode = 0;            //業務区分
            inpDisplay.UOESupplierCd = 0;			//UOE発注先コード
            inpDisplay.UOESupplierName = "";		//発注先名称

            inpDisplay.UOEDeliGoodsDiv = "";		//納品区分
            inpDisplay.DeliveredGoodsDivNm = "";	//納品区分名称
            inpDisplay.FollowDeliGoodsDiv = "";		//フォロー納品区分
            inpDisplay.FollowDeliGoodsDivNm = "";	//フォロー納品区分名称

            inpDisplay.UOEResvdSection = "";		//UOE指定拠点
            inpDisplay.UOEResvdSectionNm = "";		//UOE指定拠点名称
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

            if (nextControl.Name == tComboEditor_BusinessCode.Name)
			{
                message = MESSAGE_BusinessCode;
			}
            else if (nextControl.Name == tNedit_UOESupplierCd.Name)
			{
				message = MESSAGE_UOESupplierCd;
			}
			else if (nextControl.Name == uButton_UOESupplierGuide.Name)
			{
				message = "";
			}
			else if (nextControl.Name == tComboEditor_DeliveredGoodsDiv.Name)
			{
				message = MESSAGE_DeliveredGoodsDiv;
			}
			else if (nextControl.Name == tComboEditor_FollowDeliGoodsDiv.Name)
			{
				message = MESSAGE_FollowDeliGoodsDiv;
			}
			else if (nextControl.Name == tComboEditor_UOEResvdSection.Name)
			{
				message = MESSAGE_UOEResvdSection;
			}
			else if (nextControl.Name == tEdit_EmployeeCode.Name)
			{
				message = MESSAGE_EmployeeCode;
			}
			else if (nextControl.Name == uButton_EmployeeGuide.Name)
			{
				message = "";
			}
			else if (nextControl.Name == tEdit_UoeRemark1.Name)
			{
				message = MESSAGE_UoeRemark1;
			}
			else if (nextControl.Name == tEdit_UoeRemark2.Name)
			{
				message = MESSAGE_UoeRemark2;
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
		# endregion ■ 指定フォーカス設定処理 ■

		# region ■ コントロールインデックス取得処理 ■
		/// <summary>
        /// コントロールインデックス取得処理
        /// </summary>
        /// <param name="prevCtrl">現在のコントロールの名称</param>
        /// <param name="mode">0:上から 1:下から</param>
        /// <returns>コントロールインデックス</returns>
        private int GetControlIndex(string prevCtrl, int mode)
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
				//0:上から
                case 0:
					{
						int prevControlIndex = this.GetControlIndex(prevCtrl.Name, mode);
                        if ((this.tComboEditor_BusinessCode.Enabled) && (prevCtrl != this.tComboEditor_BusinessCode) && (prevControlIndex < this.GetControlIndex(this.tComboEditor_BusinessCode.Name, mode)))
                        {
                            control = this.tComboEditor_BusinessCode;
                        }
                        else if ((this.tNedit_UOESupplierCd.Enabled) && (prevCtrl != this.tNedit_UOESupplierCd) && (prevControlIndex < this.GetControlIndex(this.tNedit_UOESupplierCd.Name, mode)))
                        {
                            control = this.tNedit_UOESupplierCd;
                        }
                        else if ((this.tComboEditor_DeliveredGoodsDiv.Enabled) && (prevCtrl != this.tComboEditor_DeliveredGoodsDiv) && (prevControlIndex < this.GetControlIndex(this.tComboEditor_DeliveredGoodsDiv.Name, mode)))
                        {
                            control = this.tComboEditor_DeliveredGoodsDiv;
                        }
                        else if ((this.tComboEditor_FollowDeliGoodsDiv.Enabled) && (prevCtrl != this.tComboEditor_FollowDeliGoodsDiv) && (prevControlIndex < this.GetControlIndex(this.tComboEditor_FollowDeliGoodsDiv.Name, mode)))
                        {
                            control = this.tComboEditor_FollowDeliGoodsDiv;
                        }
                        else if ((this.tComboEditor_UOEResvdSection.Enabled) && (prevCtrl != this.tComboEditor_UOEResvdSection) && (prevControlIndex < this.GetControlIndex(this.tComboEditor_UOEResvdSection.Name, mode)))
                        {
                            control = this.tComboEditor_UOEResvdSection;
                        }
                        else if ((this.tEdit_EmployeeCode.Enabled) && (prevCtrl != this.tEdit_EmployeeCode) && (prevControlIndex < this.GetControlIndex(this.tEdit_EmployeeCode.Name, mode)))
                        {
                            control = this.tEdit_EmployeeCode;
                        }
                        else if ((this.tEdit_UoeRemark1.Enabled) && (prevCtrl != this.tEdit_UoeRemark1) && (prevControlIndex < this.GetControlIndex(this.tEdit_UoeRemark1.Name, mode)))
                        {
                            control = this.tEdit_UoeRemark1;
                        }
                        else if ((this.tEdit_UoeRemark2.Enabled) && (prevCtrl != this.tEdit_UoeRemark2) && (prevControlIndex < this.GetControlIndex(this.tEdit_UoeRemark2.Name, mode)))
                        {
                            control = this.tEdit_UoeRemark2;
                        }
                        break;
                    }
				//1:下から
                case 1:
					{
                        //下段
                        if ((this.tEdit_UoeRemark1.Enabled) && (prevCtrl != this.tEdit_UoeRemark1))
                        {
                            control = this.tEdit_UoeRemark1;
                        }
                        else if ((this.tEdit_UoeRemark2.Enabled) && (prevCtrl != this.tEdit_UoeRemark2))
                        {
                            control = this.tEdit_UoeRemark2;
                        }

                        //中段
                        else if ((this.tComboEditor_DeliveredGoodsDiv.Enabled) && (prevCtrl != this.tComboEditor_DeliveredGoodsDiv))
                        {
                            control = this.tComboEditor_DeliveredGoodsDiv;
                        }
                        else if ((this.tComboEditor_FollowDeliGoodsDiv.Enabled) && (prevCtrl != this.tComboEditor_FollowDeliGoodsDiv))
                        {
                            control = this.tComboEditor_FollowDeliGoodsDiv;
                        }
                        else if ((this.tComboEditor_UOEResvdSection.Enabled) && (prevCtrl != this.tComboEditor_UOEResvdSection))
                        {
                            control = this.tComboEditor_UOEResvdSection;
                        }
                        else if ((this.tEdit_EmployeeCode.Enabled) && (prevCtrl != this.tEdit_EmployeeCode))
                        {
                            control = this.tEdit_EmployeeCode;
                        }
                        
                        //上段
                        else if ((this.tComboEditor_BusinessCode.Enabled) && (prevCtrl != this.tComboEditor_BusinessCode))
                        {
                            control = this.tComboEditor_BusinessCode;
                        }

                        //最上段
                        else if ((this.tNedit_UOESupplierCd.Enabled) && (prevCtrl != this.tNedit_UOESupplierCd))
                        {
                            control = this.tNedit_UOESupplierCd;
                        }
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
			if ((isConfirm) && (this._stockInputAcs.IsDataChanged) && this._stockInputAcs.StockRowExists())
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"手入力発注を終了してもよろしいですか？",
					0,
					MessageBoxButtons.YesNo,
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

        # region ■ 確定処理 ■
		/// <summary>
		/// 確定処理
		/// </summary>
		/// <returns>true:保存完了 false:未保存</returns>
		private bool updateMain()
		{
			string retMessage = "";
			bool isSave = false;

			try
			{
				this.Cursor = Cursors.WaitCursor;

                # region 入力項目のチェック
                // 入力項目のチェック -------------------------------------------
				//グリッド内容の更新ダミー処理
                this.SetControlFocus(uLabel_UOESupplierName);

                # region 入力項目(ヘッダー部)のチェック処理
                SetDisplay(_inpDisplay);

                List<string> nameList = null;
				List<Control> controlList = null;

                if (HedDataCheck(_inpDisplay, out nameList, out controlList) != true)
				{
					StringBuilder message = new StringBuilder();
                    // 2009.05.25 START >>>>>>
                    //message.Append("ヘッダー部に未入力の項目が存在するため、送信できません。" + "\r\n" + "\r\n");
                    message.Append("ヘッダー部に未入力の項目が存在するため、確定できません。" + "\r\n" + "\r\n");
                    // 2009.05.25 END   <<<<<<
                    foreach (string s in nameList)
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

						this.SetControlFocus(controlList[0]);
					return (isSave);
                }
                #endregion

                # region 入力項目(明細)のチェック処理
                //入力項目(明細)のチェック処理
				nameList = null;
				List<string> itemList = new List<string>();
				int count = 0;

                if (this._stockInputAcs.SaveDataCheck(_inpDisplay, out nameList, out itemList, out count) != true)
				{
					StringBuilder message = new StringBuilder();
                    // 2009.05.25 START >>>>>>
                    //message.Append("明細部に未入力の項目が存在するため、送信できません。" + "\r\n" + "\r\n");
                    message.Append("明細部に未入力の項目が存在するため、確定できません。" + "\r\n" + "\r\n");
                    // 2009.05.25 END   <<<<<<

					foreach (string s in nameList)
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
						this.SetControlFocus(this._detailInput.uGrid_Details);
					}
					return isSave;
                }
                #endregion

                # region 送信データカウントのチェック
                //送信データカウントのチェック
				if (count == 0)
				{
					StringBuilder message = new StringBuilder();
					message.Append("送信対象のデータが存在しません。" + "\r\n");

					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						this.Name,
						message.ToString(),
						0,
						MessageBoxButtons.OK);

					return isSave;
                }
                #endregion

                #endregion

                # region 送信処理
                string dialogMessage = "";
                switch(InpDisplay.BusinessCode)
                {
                    case (int)EnumUoeConst.TerminalDiv.ct_Order:
                        dialogMessage = "発注処理を実行しますか？";
                        break;
                    case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
                        dialogMessage = "見積処理を実行しますか？";
                        break;
                    case (int)EnumUoeConst.TerminalDiv.ct_Stock:
                        dialogMessage = "在庫確認処理を実行しますか？";
                        break;
                }

                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_QUESTION,
                    //emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    dialogMessage,
                    0,
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult != DialogResult.Yes)
                {
                    return isSave;
                }

                // 送信処理 -----------------------------------------------------
                // 2009.05.25 START >>>>>>
                //int status = this._stockInputAcs.WriteDB(InpDisplay, out retMessage);

                UOESupplier uOESupplier = _stockInputInitDataAcs.GetUOESupplier(InpDisplay.UOESupplierCd);
                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                //通常処理
                // if (uOESupplier.CommAssemblyId != EnumUoeConst.ctCommAssemblyId_0502) // DEL 2009/12/29 xuxh
                if (UoeSndRcvCtlAcs.CanSendAndReceive(uOESupplier)) // ADD 2009/12/29 xuxh
                {
                    status = this._stockInputAcs.WriteDB(InpDisplay, out retMessage);
                }
                //ホンダ UOE WEB対応
                else
                {
                    status = this._stockInputAcs.ePartsWriteDB(InpDisplay, out retMessage);
                }
                // 2009.05.25 END   <<<<<<


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    //登録完了ダイアログを発注時のみ表示
                    // 2009.05.25 START >>>>>>
                    //if (InpDisplay.SystemDivCd == (int)EnumUoeConst.TerminalDiv.ct_Order)
                    if (InpDisplay.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                    // 2009.05.25 END   <<<<<<
                    {
                        SaveCompletionDialog dialog = new SaveCompletionDialog();
                        dialog.ShowDialog(2);
                    }
                    
                    // 明細グリッド設定処理
					this._detailInput.SettingGrid();

                    //行クリア
					isSave = true;
        
					//ヘッダー部初期化
					this.ComboEditorItemInitialSetting();

					//明細部初期化
					this._detailInput.Clear();
				}
				else
				{
					TMsgDisp.Show(
						this,
						emErrorLevel.ERR_LEVEL_STOPDISP,
						this.Name,
                        "(" + status.ToString() + ")" + 
						"送信に失敗しました。" + "\r\n" + "\r\n" + retMessage,
						status,
						MessageBoxButtons.OK);
				}
                #endregion
            }
			finally
			{
				this.Cursor = Cursors.Default;
			}

			return isSave;
        }
        # endregion ■ 保存処理 ■

		# region ■ ヘッダー部入力チェック ■
		/// <summary>
		/// ヘッダー部入力チェック
		/// </summary>
		/// <param name="displayNow">ヘッダー部入力項目</param>
		/// <param name="name">コントロール名称</param>
		/// <param name="control">コントロール</param>
		/// <returns>true:正常 false:エラー</returns>
        private bool HedDataCheck(InpDisplay displayNow, out List<string> name, out List<Control> control)
		{
			bool bStatus = true;

			name = new List<string>();
			control = new List<Control>();

            UOESupplier uOESupplier = _stockInputInitDataAcs.GetUOESupplier(displayNow.UOESupplierCd);

            //業務区分
            if (displayNow.BusinessCode == 0)
            {
                name.Add("業務区分");
                control.Add(this.tComboEditor_BusinessCode);
            }

			//発注先
			if((displayNow.UOESupplierCd == 0) || (uOESupplier == null))
			{
				name.Add("発注先");
				control.Add(this.tNedit_UOESupplierCd);
			}

			//納品区分
            if((displayNow.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
            // 2009.05.25 START >>>>>>
            && (UOESupplierAcs.EnabledDeliveredGoodsDiv(uOESupplier.CommAssemblyId) == true)
            // 2009.05.25 END   <<<<<<
            && (this.tComboEditor_DeliveredGoodsDiv.Enabled == false)
            && (displayNow.UOEDeliGoodsDiv == ""))
			{
				name.Add("納品区分");
				control.Add(this.tComboEditor_DeliveredGoodsDiv);
			}

			//Ｈ納品区分
            if (uOESupplier != null)
            {
                if((displayNow.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                && (uOESupplier.CommAssemblyId == EnumUoeConst.ctCommAssemblyId_0102)
                && (this.tComboEditor_FollowDeliGoodsDiv.Enabled == false)
                && (displayNow.FollowDeliGoodsDiv.Trim() == ""))
                {
                    name.Add("Ｈ納品区分");
                    control.Add(this.tComboEditor_FollowDeliGoodsDiv);
                }
            }

			//指定拠点
            if((displayNow.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
            // 2009.05.25 START >>>>>>
            && (UOESupplierAcs.EnabledUOEResvdSection(uOESupplier.CommAssemblyId) == true)
            // 2009.05.25 END   <<<<<<
            && (displayNow.UOEResvdSection.Trim() == "")
            && (this.tComboEditor_UOEResvdSection.Enabled == false))
			{
				name.Add("指定拠点");
				control.Add(this.tComboEditor_UOEResvdSection);
			}

			//依頼者
            if((displayNow.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
			&& (displayNow.EmployeeCode.Trim() == ""))
			{
				name.Add("依頼者");
				control.Add(this.tEdit_EmployeeCode);
			}

			if (name.Count > 0)
			{
				bStatus = false;
			}

			return (bStatus);
		}
        # endregion

        # region ■ 初期化処理 ■
        /// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <param name="isConfirm">true:確認ダイアログを表示する false:表示しない</param>
		/// <param name="keepSupplierFormal">true:全クリア false:明細部クリア</param>
		/// <returns>true:初期化実行 false:初期化未実行</returns>
		private bool Clear(bool isConfirm, bool detail)
		{
			if ((isConfirm) && (this._stockInputAcs.IsDataChanged) && this._stockInputAcs.StockRowExists())
			{
				DialogResult dialogResult = TMsgDisp.Show(
					this,
					emErrorLevel.ERR_LEVEL_EXCLAMATION,
					this.Name,
					"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
					"初期状態に戻しますか？",
					0,
					MessageBoxButtons.YesNo,
					MessageBoxDefaultButton.Button1);

				if (dialogResult != DialogResult.Yes)
				{
					return false;
				}
			}

			// 画面処理
			if (detail)
			{
				this.ComboEditorItemInitialSetting();
			}

			// テーブルクリア処理
			this._detailInput.Clear();

			return true;
        }
        # endregion ■ 初期化処理 ■

		# region ■ ツールバー関連 ■
		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		private void SettingToolBarButtonEnabled()
		{
		    this._saveButton.SharedProps.Enabled = true;
		    this._retryButton.SharedProps.Enabled = this._stockInputAcs.IsDataChanged;
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
					//発注先
					case ctGUIDE_NAME_SupplierGuide:
						{
							this.uButton_UOESupplierGuide_Click(this.uButton_UOESupplierGuide, new EventArgs());
							break;
						}
					//担当者
					case ctGUIDE_NAME_EmployeeGuide:
					{
						this.uButton_EmployeeGuide_Click(this.uButton_EmployeeGuide, new EventArgs());
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
		private void PMUOE01101UA_Load(object sender, EventArgs e)
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
            this._stockInputInitDataAcs.ReadInitData(this._enterpriseCode, this._loginSectionCode);

			// ツールバー初期設定処理
			this.ToolBarInitilSetting();

			// コンボエディタアイテム初期設定処理
			this.ComboEditorItemInitialSetting();

			// グリッドのリストを設定（データから設定する分）
			this._detailInput.SetGridList(null);

            // ガイド後次フォーカス設定処理
            this.SettingGuideNextControl();

			// クリア処理
			this.Clear(false, false);

			this.timer_InitialSetFocus.Enabled = true;
		}

		# region ■ フォームクロージングイベント ■
		/// <summary>
		/// フォームクロージングイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void MAKON04410UA_FormClosing(object sender, FormClosingEventArgs e)
		{
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
        /// <br>Update Note: 2009/01/21 張凱 発注先を入力後、ENTERにてﾌｫｰｶｽ移動対応</br>
        /// <br>Update Note: 2010/03/08 楊明俊 業務区分は「発注」（固定）に制御の対応</br>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			bool canChangeFocus;

			if (e.PrevCtrl == null || e.NextCtrl == null) return;
			if (InpDisplay == null) return;

			switch (e.PrevCtrl.Name)
			{
                // グリッド =============================================== //
				case "uGrid_Details":
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

                // 業務区分 ============================================ //
                case "tComboEditor_BusinessCode":
                    #region [ tComboEditor_BusinessCode ]
                    if (this.tComboEditor_BusinessCode.Value != null)
                    {
                        InpDisplay.BusinessCode = ToInt32FromString(this.tComboEditor_BusinessCode.Value.ToString());
                    }
                    #endregion
                    break;

				// UOE発注先コード ============================================ //
				case "tNedit_UOESupplierCd":
					#region [ tNedit_UOESupplierCd ]
					canChangeFocus = true;
					int code = this.tNedit_UOESupplierCd.GetInt();

					if (InpDisplay.UOESupplierCd != code)
					{
						//発注先変更メッセージ処理
						if (this._stockInputAcs.IsDataChanged == true)
						{
							DialogResult dialogResult = TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_EXCLAMATION,
								this.Name,
								"現在、編集中のデータが存在します。" + "\r\n" + "\r\n" +
								"発注先を変更しますか？",
								0,
								MessageBoxButtons.YesNo,
								MessageBoxDefaultButton.Button1);

							if (dialogResult != DialogResult.Yes)
							{
								break;
							}
						}

						//発注先クリア
						if (code == 0)
						{
							InpDisplay.UOESupplierCd = code;
							InpDisplay.UOESupplierName = "";
						}
						else if (_stockInputInitDataAcs.UOESupplierExists(code) == true)
						{
							//コード・名称セット
							InpDisplay.UOESupplierCd = code;
							InpDisplay.UOESupplierName = _stockInputInitDataAcs.GetName_FromUOESupplier(code);
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

						//UOE発注先コードの変更時処理
						UOESupplierCdChanged(InpDisplay.UOESupplierCd);
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
										if (this.tNedit_UOESupplierCd.GetInt() == 0)
										{
											e.NextCtrl = this.uButton_UOESupplierGuide;
										}
										else
										{
                                            // --- UPD 2009/01/21 ---------->>>>>
                                            //e.NextCtrl = this.tComboEditor_BusinessCode;

                                            //業務区分
                                            if (this.tComboEditor_BusinessCode.Enabled == true)
                                            {
                                                e.NextCtrl = this.tComboEditor_BusinessCode;
                                            }
                                            //納品区分
                                            else if (this.tComboEditor_DeliveredGoodsDiv.Enabled == true)
                                            {
                                                e.NextCtrl = this.tComboEditor_DeliveredGoodsDiv;
                                            }
                                            //フォロー納品区分
                                            else if (this.tComboEditor_FollowDeliGoodsDiv.Enabled == true)
                                            {
                                                e.NextCtrl = this.tComboEditor_FollowDeliGoodsDiv;
                                            }
                                            //UOE指定拠点
                                            else if (this.tComboEditor_UOEResvdSection.Enabled == true)
                                            {
                                                e.NextCtrl = this.tComboEditor_UOEResvdSection;
                                            }
                                            //依頼者コード
                                            else if (this.tEdit_EmployeeCode.Enabled == true)
                                            {
                                                e.NextCtrl = this.tEdit_EmployeeCode;
                                            }
                                            //ＵＯＥリマーク１
                                            else if (this.tEdit_UoeRemark1.Enabled == true)
                                            {
                                                e.NextCtrl = this.tEdit_UoeRemark1;
                                            }
                                            //ＵＯＥリマーク２
                                            else if (this.tEdit_UoeRemark2.Enabled == true)
                                            {
                                                e.NextCtrl = this.tEdit_UoeRemark2;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this._detailInput.uGrid_Details;
                                            }
                                            // --- UPD 2009/01/21 ----------<<<<<
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

				// 納品区分 ============================================ //
				case "tComboEditor_DeliveredGoodsDiv":
					#region [ tComboEditor_DeliveredGoodsDiv ]
                    if (this.tComboEditor_DeliveredGoodsDiv.Value == null) break;

                    InpDisplay.UOEDeliGoodsDiv = this.tComboEditor_DeliveredGoodsDiv.Value.ToString();		//納品区分
					InpDisplay.DeliveredGoodsDivNm = this.tComboEditor_DeliveredGoodsDiv.Text;				//納品区分名称
					#endregion
					break;

				// Ｈ納品区分 ============================================ //
				case "tComboEditor_FollowDeliGoodsDiv":
					#region [ tComboEditor_FollowDeliGoodsDiv ]
                    if (this.tComboEditor_FollowDeliGoodsDiv.Value == null) break;

					InpDisplay.FollowDeliGoodsDiv = this.tComboEditor_FollowDeliGoodsDiv.Value.ToString();	//フォロー納品区分
					InpDisplay.FollowDeliGoodsDivNm = this.tComboEditor_FollowDeliGoodsDiv.Text;			//フォロー納品区分名称
					#endregion
					break;

				// UOE指定拠点 ============================================ //
				case "tComboEditor_UOEResvdSection":
					#region [ tComboEditor_UOEResvdSection ]
                    if (this.tComboEditor_UOEResvdSection.Value == null) break;

                    InpDisplay.UOEResvdSection = this.tComboEditor_UOEResvdSection.Value.ToString();		//UOE指定拠点
					InpDisplay.UOEResvdSectionNm = this.tComboEditor_UOEResvdSection.Text;					//UOE指定拠点名称
					#endregion
					break;

				// 依頼者コード ============================================ //
				case "tEdit_EmployeeCode":
					#region [ tEdit_EmployeeCode ]

					canChangeFocus = true;
					string codeString = this.tEdit_EmployeeCode.Text.Trim();
					if (InpDisplay.EmployeeCode.Trim() != codeString)
					{
						if (codeString == "")
						{
							InpDisplay.EmployeeCode = codeString.Trim(); ;
							InpDisplay.EmployeeName = "";
						}
						else if (_stockInputInitDataAcs.EmployeeExists(codeString) == true)
						{
							InpDisplay.EmployeeCode = codeString.Trim(); ;
							InpDisplay.EmployeeName = _stockInputInitDataAcs.GetName_FromEmployee(codeString);
						}
						else
						{
							TMsgDisp.Show(
								this,
								emErrorLevel.ERR_LEVEL_INFO,
								this.Name,
								"担当者が存在しません。",
								-1,
								MessageBoxButtons.OK);

							canChangeFocus = false;
							codeString = "";
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
										if (this.tEdit_EmployeeCode.Text.Trim() == "")
										{
											e.NextCtrl = this.uButton_EmployeeGuide;
										}
										else
										{
                                            // --- UPD 2010/03/08 ----------<<<<<
                                            //ＵＯＥリマーク１
                                            if (this.tEdit_UoeRemark1.Enabled == true)
                                            {
                                                e.NextCtrl = this.tEdit_UoeRemark1;
                                            }
                                            //ＵＯＥリマーク２
                                            else if (this.tEdit_UoeRemark2.Enabled == true)
                                            {
                                                e.NextCtrl = this.tEdit_UoeRemark2;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this._detailInput.uGrid_Details;
                                            }
                                            //e.NextCtrl = this.tEdit_UoeRemark1;
                                            // --- UPD 2010/03/08 ----------<<<<<
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

				// ＵＯＥリマーク１ ============================================ //
				case "tEdit_UoeRemark1":
					#region [ tEdit_UoeRemark1 ]
					InpDisplay.UoeRemark1 = this.tEdit_UoeRemark1.Text.Trim();			//ＵＯＥリマーク１
					#endregion
					break;

				// ＵＯＥリマーク２ ============================================ //
				case "tEdit_UoeRemark2":
					#region [ tEdit_UoeRemark2 ]
					InpDisplay.UoeRemark2 = this.tEdit_UoeRemark2.Text.Trim();			//ＵＯＥリマーク１
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

            // ---ADD 2010/01/22 -------------------->>>>
            if (this.tComboEditor_DeliveredGoodsDiv.Enabled == false)
            {
                this.tComboEditor_DeliveredGoodsDiv.Enabled = true;
                this.tComboEditor_DeliveredGoodsDiv.Clear();
                if (this.tComboEditor_DeliveredGoodsDiv.SelectedItem != null)
                {
                    this.tComboEditor_DeliveredGoodsDiv.SelectedItem.DisplayText = string.Empty;
                }
                this.tComboEditor_DeliveredGoodsDiv.Enabled = false;
            }
            if (this.tComboEditor_FollowDeliGoodsDiv.Enabled == false)
            {
                this.tComboEditor_FollowDeliGoodsDiv.Enabled = true;
                this.tComboEditor_FollowDeliGoodsDiv.Clear();
                if (this.tComboEditor_FollowDeliGoodsDiv.SelectedItem != null)
                {
                    this.tComboEditor_FollowDeliGoodsDiv.SelectedItem.DisplayText = string.Empty;
                }
                this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;
            }
            if (this.tComboEditor_UOEResvdSection.Enabled == false)
            {
                this.tComboEditor_UOEResvdSection.Enabled = true;
                this.tComboEditor_UOEResvdSection.Clear();
                if (this.tComboEditor_UOEResvdSection.SelectedItem != null)
                {
                    this.tComboEditor_UOEResvdSection.SelectedItem.DisplayText = string.Empty;
                }
                this.tComboEditor_UOEResvdSection.Enabled = false;
            }
            // ---ADD 2010/01/22 --------------------<<<<
        }
        # endregion ■ ChangeFocusイベント ■

        # region ■ 業務区分の変更処理
        /// <summary>
        /// 業務区分の変更処理(イベント用)
        /// </summary>
        /// <br>Update Note: 2010/01/22 譚洪 納品区分・Ｈ納品区分・指定拠点をｽﾍﾟｰｽの設定を指定するとエラーになるの対応</br>
        private void BusinessCodeChanged()
        {
            if ((InpDisplay == null)
            || (this.tComboEditor_BusinessCode.Value == null))
                return;

            String codeString = (string)this.tComboEditor_BusinessCode.Value;
            Int32 code = UoeCommonFnc.ToInt32FromString(codeString);

            if (code == InpDisplay.BusinessCode) return;
            InpDisplay.BusinessCode = code;

            //業務区分の変更処理
            BusinessCodeChangedProc();

            // ---ADD 2010/01/22 -------------------->>>>
            if (this.tComboEditor_DeliveredGoodsDiv.Enabled == false)
            {
                this.tComboEditor_DeliveredGoodsDiv.Enabled = true;
                this.tComboEditor_DeliveredGoodsDiv.Clear();
                if (this.tComboEditor_DeliveredGoodsDiv.SelectedItem != null)
                {
                    this.tComboEditor_DeliveredGoodsDiv.SelectedItem.DisplayText = string.Empty;
                }
                this.tComboEditor_DeliveredGoodsDiv.Enabled = false;
            }
            if (this.tComboEditor_FollowDeliGoodsDiv.Enabled == false)
            {
                this.tComboEditor_FollowDeliGoodsDiv.Enabled = true;
                this.tComboEditor_FollowDeliGoodsDiv.Clear();
                if (this.tComboEditor_FollowDeliGoodsDiv.SelectedItem != null)
                {
                    this.tComboEditor_FollowDeliGoodsDiv.SelectedItem.DisplayText = string.Empty;
                }
                this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;
            }
            if (this.tComboEditor_UOEResvdSection.Enabled == false)
            {
                this.tComboEditor_UOEResvdSection.Enabled = true;
                this.tComboEditor_UOEResvdSection.Clear();
                if (this.tComboEditor_UOEResvdSection.SelectedItem != null)
                {
                    this.tComboEditor_UOEResvdSection.SelectedItem.DisplayText = string.Empty;
                }
                this.tComboEditor_UOEResvdSection.Enabled = false;
            }
            // ---ADD 2010/01/22 --------------------<<<<
        }

        /// <summary>
        /// 業務区分の変更処理
        /// </summary>
        private void BusinessCodeChangedProc()
        {
            //システム区分
            StatusType statusType = StatusType.ct_Order;
            switch (InpDisplay.BusinessCode)
            {
                //発注
                case (int)EnumUoeConst.TerminalDiv.ct_Order:
                    # region 発注
                    statusType = StatusType.ct_Order;

                    // 2009.05.25 START >>>>>>
                    // //納品区分
                    // this.tComboEditor_DeliveredGoodsDiv.Enabled = true;
                    // 2009.05.25 END   <<<<<<

                    //Ｈ納品区分
                    UOESupplier uOESupplier = this._stockInputInitDataAcs.GetUOESupplier(InpDisplay.UOESupplierCd);
                    if (uOESupplier == null)
                    {
                        this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;
                        // 2009.05.25 START >>>>>>

                        //納品区分
                        this.tComboEditor_DeliveredGoodsDiv.Enabled = false;

                        //指定拠点
                        this.tComboEditor_UOEResvdSection.Enabled = false;
                        // 2009.05.25 END   <<<<<<
                    }
                    else
                    {
                        this.tComboEditor_FollowDeliGoodsDiv.Enabled = UOESupplierAcs.EnabledFollowDeliGoodsDiv(uOESupplier.CommAssemblyId);
                        // 2009.05.25 START >>>>>>
                        //納品区分
                        this.tComboEditor_DeliveredGoodsDiv.Enabled = UOESupplierAcs.EnabledDeliveredGoodsDiv(uOESupplier.CommAssemblyId);

                        //指定拠点
                        this.tComboEditor_UOEResvdSection.Enabled = UOESupplierAcs.EnabledUOEResvdSection(uOESupplier.CommAssemblyId);

                        // 2009.05.25 END   <<<<<<
                    }

                    // 2009.05.25 START >>>>>>
                    // //指定拠点
                    // this.tComboEditor_UOEResvdSection.Enabled = true;
                    // 2009.05.25 END   <<<<<<
                    # endregion
                    break;
                //見積
                case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
                    # region 見積
                    statusType = StatusType.ct_Estmt;

                    //納品区分
                    this.tComboEditor_DeliveredGoodsDiv.Enabled = false;
                    //Ｈ納品区分
                    this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;
                    //指定拠点
                    this.tComboEditor_UOEResvdSection.Enabled = false;
                    # endregion
                    break;
                //在庫
                case (int)EnumUoeConst.TerminalDiv.ct_Stock:
                    # region 在庫
                    statusType = StatusType.ct_Stock;

                    //納品区分
                    this.tComboEditor_DeliveredGoodsDiv.Enabled = false;
                    //Ｈ納品区分
                    this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;
                    //指定拠点
                    this.tComboEditor_UOEResvdSection.Enabled = false;
                    # endregion
                    break;
                //エラー時
                default:
                    # region エラー時
                    //納品区分
                    this.tComboEditor_DeliveredGoodsDiv.Enabled = false;
                    //Ｈ納品区分
                    this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;
                    //指定拠点
                    this.tComboEditor_UOEResvdSection.Enabled = false;
                    # endregion
                    return;
            }

            //純正・優良判定
            int settingGridCol = 2;
            if (uoeSndRcvJnlAcs.ChkCommAssemblyId(InpDisplay.UOESupplierCd) == true)
            {
                //純正
                settingGridCol = 2;
            }
            else
            {
                //優良
                settingGridCol = 1;
            }

            // 明細グリッド設定処理
            this._detailInput.SettingGrid(statusType, settingGridCol);
        }
        # endregion

		# region ■ UOE発注先コードの変更時処理 ■
		/// <summary>
		/// UOE発注先コードの変更時処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        /// <br>UpdateNote : 2010/03/08 楊明俊 業務区分は「発注」（固定）に制御の対応</br>
        /// <br>UpdateNote : 2011/01/06 鄧潘ハン 業務区分は「発注」（固定）に制御する</br>
        /// <br>UpdateNote : 2011/01/30 朱 猛 UOE自動化改良</br>
        /// <br>UpdateNote : 2011/03/01 liyp  業務区分は「発注」（固定）に制御する</br>
        /// <br>UpdateNote : 2011/05/10 施炳中  業務区分は「発注」（固定）に制御する</br>
        private void UOESupplierCdChanged(int uOESupplierCd)
		{
            //-----------------------------------------------------------
            // ヘッダー部初期化
            //-----------------------------------------------------------
            # region ヘッダー部初期化
			UOESupplier uOESupplier = new UOESupplier();	//UOE発注先

			// リスト(tComboEditor用)
			List<UOEGuideName> ListBusinessCode = new List<UOEGuideName>();	        //業務区分
            List<UOEGuideName> ListDeliveredGoodsDiv = new List<UOEGuideName>();	//納品区分
			List<UOEGuideName> ListUOEResvdSection = new List<UOEGuideName>();		//UOE指定拠点


			// リスト初期値表示(tComboEditor用)
			string _defaultEmployeeCode = "";		//依頼者コード
			string _defaultEmployeeName = "";		//依頼者名
            string _defaultBusinessCode = "";	    //1:業務区分
            string _defaultDeliveredGoodsDiv = "";	//2:納品区分
			string _defaultUOEResvdSection = "";	//3:拠点区分    

			// ヘッダー部初期化
            ClearOrderInpDisplay(InpDisplay);

    		// ComboEditor初期化
            this.tComboEditor_BusinessCode.Clear();         //業務区分
			this.tComboEditor_DeliveredGoodsDiv.Clear();	//納品区分
			this.tComboEditor_FollowDeliGoodsDiv.Clear();	//Ｈ納品区分
			this.tComboEditor_UOEResvdSection.Clear();		//拠点区分
	        # endregion 

			//ＵＯＥ発注先マスタ取得 ============================================ //
			# region ＵＯＥ発注先マスタ取得
            uOESupplier = this._stockInputInitDataAcs.GetUOESupplier(uOESupplierCd);

            bool uOESupplierExists = this._stockInputInitDataAcs.UOESupplierExists(uOESupplierCd);

			//ＵＯＥ発注先あり
			if (uOESupplierExists == true)
			{
				uOESupplier = this._stockInputInitDataAcs.GetUOESupplier(uOESupplierCd);

				//グリッドのリストセット処理
				this._detailInput.SetGridList(uOESupplier);

				InpDisplay.UOESupplierCd = uOESupplierCd;
				InpDisplay.UOESupplierName = uOESupplier.UOESupplierName;

                this.tComboEditor_BusinessCode.Enabled = true;          //業務区分
                this.tComboEditor_DeliveredGoodsDiv.Enabled = true;		//納品区分
				this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;	//フォロー納品区分
				this.tComboEditor_UOEResvdSection.Enabled = true;		//UOE指定拠点
				this.tEdit_EmployeeCode.Enabled = true;				    //依頼者コード
				this.uButton_EmployeeGuide.Enabled = true;				//依頼者ガイド
				this.tEdit_UoeRemark1.Enabled = true;					//ＵＯＥリマーク１
				this.tEdit_UoeRemark2.Enabled = true;					//ＵＯＥリマーク２

                # region Ｈ納品区分・リマーク１・リマーク２の設定
                //-----------------------------------------------------------
                // Ｈ納品区分(許可)
                //-----------------------------------------------------------
                this.tComboEditor_FollowDeliGoodsDiv.Enabled = UOESupplierAcs.EnabledFollowDeliGoodsDiv(uOESupplier.CommAssemblyId);

                //-----------------------------------------------------------
                // リマーク１
                //-----------------------------------------------------------
                this.tEdit_UoeRemark1.ExtEdit.Column = UOESupplierAcs.MaxLengthUOERemark1(uOESupplier.CommAssemblyId);
                this.tEdit_UoeRemark1.Enabled = UOESupplierAcs.EnabledUOERemark1(uOESupplier.CommAssemblyId);
                InpDisplay.UoeRemark1 = _stockInputInitDataAcs.uOESetting.InpSearchRemark;

                //-----------------------------------------------------------
                // リマーク２
                //-----------------------------------------------------------
                this.tEdit_UoeRemark2.ExtEdit.Column = UOESupplierAcs.MaxLengthUOERemark2(uOESupplier.CommAssemblyId);
                this.tEdit_UoeRemark2.Enabled = UOESupplierAcs.EnabledUOERemark2(uOESupplier.CommAssemblyId);

                # endregion

				# region ComboEditor値の設定
                //-----------------------------------------------------------
                // 業務区分の設定
                //-----------------------------------------------------------
                # region 業務区分の設定
               
                ListBusinessCode = _stockInputInitDataAcs.GetList_FromUOEGuideName(0, uOESupplierCd);
                if (ListBusinessCode.Count > 0)
                {
                    SetUOEGuideNameComboEditor(ref this.tComboEditor_BusinessCode, ListBusinessCode);
                    _defaultBusinessCode = _stockInputInitDataAcs.GetDefaultUOEGuideCode(ListBusinessCode, uOESupplier.BusinessCode.ToString());
                    InpDisplay.BusinessCode = UoeCommonFnc.ToInt32FromString(_defaultBusinessCode);
                    // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
                    // 通信アセンブリID
                    int commAssemblyId = 0;
                    if (uOESupplier.CommAssemblyId.Trim() != "")
                    {
                        commAssemblyId = int.Parse(uOESupplier.CommAssemblyId.Trim());
                    }
                    
                    // --- UPD 2011/01/06 ---------->>>>>
                    //if (commAssemblyId == 103 || commAssemblyId == 203 || commAssemblyId == 204 || commAssemblyId == 302 || commAssemblyId == 303) // DEL 2011/01/30 朱 猛
                    //if (commAssemblyId == 103 || commAssemblyId == 104 || commAssemblyId == 203 || commAssemblyId == 204 || commAssemblyId == 302 || commAssemblyId == 303) // ADD 2011/01/30 朱 猛 //DEL 2011/03/01
                    // --- UPD 2011/05/10 ---------->>>>>
                    //if (commAssemblyId == 103 || commAssemblyId == 104 || commAssemblyId == 203 || commAssemblyId == 204 || commAssemblyId == 302 || commAssemblyId == 303 || commAssemblyId == 205 || commAssemblyId == 206) // ADD 2011/03/01
                    if (commAssemblyId == 103 || commAssemblyId == 104 || commAssemblyId == 203 || commAssemblyId == 204 || commAssemblyId == 302 || commAssemblyId == 303 || commAssemblyId == 205 || commAssemblyId == 206 || commAssemblyId == 403)
                    // --- UPD 2011/05/10 ----------<<<<<
                    //業務区分
                    // ---UPD 2010/03/08 ---------------------------------------->>>>>
                    //if (commAssemblyId == 103)
                    //if (commAssemblyId == 103 || commAssemblyId == 203)
                    // ---UPD 2010/03/08 ----------------------------------------<<<<<
                    {
                        InpDisplay.BusinessCode = 1;
                        this.tComboEditor_BusinessCode.Enabled = false;
                    }
                    // --- UPD 2011/01/06 ----------<<<<<

                    // ----------------------------　ADD 2009/12/29 xuxh --------------------------------<<<<<

                    // --- ADD 2010/04/27 zhshh---------->>>>>
                    if (commAssemblyId == 302)//UOE発注先が「三菱」
                    {
                        this.tComboEditor_BusinessCode.Enabled = false;
                        this.tComboEditor_BusinessCode.Value = 1; //発注
                    }
                    // --- ADD 2010/04/27 zhshh----------<<<<<
                }
                else
                {
                    this.tComboEditor_BusinessCode.Enabled = false;
                }
                # endregion

                //-----------------------------------------------------------
                // 納品区分・Ｈ納品区分
                //-----------------------------------------------------------
                # region 納品区分・Ｈ納品区分の設定
				ListDeliveredGoodsDiv = _stockInputInitDataAcs.GetList_FromUOEGuideName(2, uOESupplierCd);
				if (ListDeliveredGoodsDiv.Count > 0)
				{
					//納品区分
                    // 2009.05.25 START >>>>>>
					//SetUOEGuideNameComboEditor(ref this.tComboEditor_DeliveredGoodsDiv, ListDeliveredGoodsDiv);
                    //_defaultDeliveredGoodsDiv = _stockInputInitDataAcs.GetDefaultUOEGuideCode(ListDeliveredGoodsDiv, uOESupplier.UOEDeliGoodsDiv);
                    //InpDisplay.UOEDeliGoodsDiv = _defaultDeliveredGoodsDiv;

                    if (UOESupplierAcs.EnabledDeliveredGoodsDiv(uOESupplier.CommAssemblyId) == true)
                    {
                        SetUOEGuideNameComboEditor(ref this.tComboEditor_DeliveredGoodsDiv, ListDeliveredGoodsDiv);
                        _defaultDeliveredGoodsDiv = _stockInputInitDataAcs.GetDefaultUOEGuideCode(ListDeliveredGoodsDiv, uOESupplier.UOEDeliGoodsDiv);
                        InpDisplay.UOEDeliGoodsDiv = _defaultDeliveredGoodsDiv;
                    }
                    // 2009.05.25 END   <<<<<<


					//Ｈ納品区分
                    // if (uOESupplier.CommAssemblyId == EnumUoeConst.ctCommAssemblyId_0102) // DEL 2009/12/29 xuxh
                    if (uOESupplier.CommAssemblyId == EnumUoeConst.ctCommAssemblyId_0102
                        || uOESupplier.CommAssemblyId == EnumUoeConst.ctCommAssemblyId_0104 // ADD 2011/01/30 朱猛
                        || uOESupplier.CommAssemblyId == EnumUoeConst.ctCommAssemblyId_0103) // ADD 2009/12/29 xuxh
                    {
						SetUOEGuideNameComboEditor(ref this.tComboEditor_FollowDeliGoodsDiv, ListDeliveredGoodsDiv);
						InpDisplay.FollowDeliGoodsDiv = _defaultDeliveredGoodsDiv;
					}
				}
				else
				{
					tComboEditor_DeliveredGoodsDiv.Enabled = false;		//納品区分
					tComboEditor_FollowDeliGoodsDiv.Enabled = false;	//Ｈ納品区分
                }
				# endregion

                //-----------------------------------------------------------
                // 拠点区分
                //-----------------------------------------------------------
                # region 拠点区分の設定
				ListUOEResvdSection = _stockInputInitDataAcs.GetList_FromUOEGuideName(3, uOESupplierCd);

                // 2009.05.25 START >>>>>>
                //if (ListUOEResvdSection.Count > 0)
                if ((ListUOEResvdSection.Count > 0)
                && (UOESupplierAcs.EnabledUOEResvdSection(uOESupplier.CommAssemblyId) == true))
                // 2009.05.25 END   <<<<<<
                {
					SetUOEGuideNameComboEditor(ref this.tComboEditor_UOEResvdSection, ListUOEResvdSection);
					_defaultUOEResvdSection = _stockInputInitDataAcs.GetDefaultUOEGuideCode(ListUOEResvdSection, uOESupplier.UOEResvdSection);
					InpDisplay.UOEResvdSection = _defaultUOEResvdSection;
				}
				else
				{
					this.tComboEditor_UOEResvdSection.Enabled = false;
				}
				# endregion
				# endregion

				# region 依頼者の設定
				if (_stockInputInitDataAcs.EmployeeExists(uOESupplier.EmployeeCode) == true)
				{
					_defaultEmployeeCode = uOESupplier.EmployeeCode;
					_defaultEmployeeName = _stockInputInitDataAcs.GetName_FromEmployee(_defaultEmployeeCode);
				}
				else
				{
					_defaultEmployeeCode = "";
					_defaultEmployeeName = "";
				}
				InpDisplay.EmployeeCode = _defaultEmployeeCode;
				InpDisplay.EmployeeName = _defaultEmployeeName;
				# endregion 
			}
			//ＵＯＥ発注先なし
			else
			{
                this.tComboEditor_BusinessCode.Enabled = false;          //業務区分
                this.tComboEditor_DeliveredGoodsDiv.Enabled = false;	//納品区分
				this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;	//フォロー納品区分
				this.tComboEditor_UOEResvdSection.Enabled = false;		//UOE指定拠点
				this.tEdit_EmployeeCode.Enabled = false;				//依頼者コード
				this.uButton_EmployeeGuide.Enabled = false;				//依頼者ガイド
				this.tEdit_UoeRemark1.Enabled = false;					//ＵＯＥリマーク１
				this.tEdit_UoeRemark2.Enabled = false;					//ＵＯＥリマーク２

				//グリッドのリストセット処理
				uOESupplier = null;
				this._detailInput.SetGridList(uOESupplier);
			}
			# endregion

			// 明細部初期化
			this._detailInput.Clear();

            //業務区分の変更処理
            BusinessCodeChangedProc();
		}
		# endregion

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
                SetControlFocus(this.tNedit_UOESupplierCd);
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
		private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			//画面→抽出条件クラス
			//InpDisplay = this.GetDisplay();

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
					bool isSave = this.updateMain();

					if (isSave)
					{
						this.Clear(true, true);
						this.timer_InitialSetFocus.Enabled = true;
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
			}
		}

		/// <summary>
		/// コンボボックスツール値変更後発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		private void tToolbarsManager_MainMenu_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
        }
        # endregion ■ ツールバーイベント ■

        # region ■ ガイド関連イベント ■
		# region ■ 発注先ガイドボタンクリックイベント ■
		/// <summary>
		/// 発注先ガイドボタンクリックイベント
		/// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <br>Update Note: 2010/01/22 譚洪 納品区分・Ｈ納品区分・指定拠点をｽﾍﾟｰｽの設定を指定するとエラーになるの対応</br>
		private void uButton_UOESupplierGuide_Click(object sender, EventArgs e)
		{
			int status = -1;
			// インスタンス生成
			UOESupplier uOESupplier = null;

			// ガイド起動
            status = uOESupplierAcs.ExecuteGuid(_enterpriseCode, _loginSectionCode, out uOESupplier);

			// 項目に展開
			if (status == 0)
			{
				bool uOESupplierCdStatus = true;
				if (_inpDisplay.UOESupplierCd != uOESupplier.UOESupplierCd)
				{
					uOESupplierCdStatus = false;
				}

				_inpDisplay.UOESupplierCd = uOESupplier.UOESupplierCd;
				_inpDisplay.UOESupplierName = uOESupplier.UOESupplierName;

				this.tNedit_UOESupplierCd.SetInt(_inpDisplay.UOESupplierCd);
				this.uLabel_UOESupplierName.Text = _inpDisplay.UOESupplierName;

				//UOE発注先コードの変更時処理
				if (uOESupplierCdStatus == false)
				{
					UOESupplierCdChanged(InpDisplay.UOESupplierCd);

                    // 画面情報クラス→画面格納処理
                    this.SetDisplay(_inpDisplay);
                }

                // ---ADD 2010/01/22 -------------------->>>>
                if (this.tComboEditor_DeliveredGoodsDiv.Enabled == false)
                {
                    this.tComboEditor_DeliveredGoodsDiv.Enabled = true;
                    this.tComboEditor_DeliveredGoodsDiv.Clear();
                    if (this.tComboEditor_DeliveredGoodsDiv.SelectedItem != null)
                    {
                        this.tComboEditor_DeliveredGoodsDiv.SelectedItem.DisplayText = string.Empty;
                    }
                    this.tComboEditor_DeliveredGoodsDiv.Enabled = false;
                }
                if (this.tComboEditor_FollowDeliGoodsDiv.Enabled == false)
                {
                    this.tComboEditor_FollowDeliGoodsDiv.Enabled = true;
                    this.tComboEditor_FollowDeliGoodsDiv.Clear();
                    if (this.tComboEditor_FollowDeliGoodsDiv.SelectedItem != null)
                    {
                        this.tComboEditor_FollowDeliGoodsDiv.SelectedItem.DisplayText = string.Empty;
                    }
                    this.tComboEditor_FollowDeliGoodsDiv.Enabled = false;
                }
                if (this.tComboEditor_UOEResvdSection.Enabled == false)
                {
                    this.tComboEditor_UOEResvdSection.Enabled = true;
                    this.tComboEditor_UOEResvdSection.Clear();
                    if (this.tComboEditor_UOEResvdSection.SelectedItem != null)
                    {
                        this.tComboEditor_UOEResvdSection.SelectedItem.DisplayText = string.Empty;
                    }
                    this.tComboEditor_UOEResvdSection.Enabled = false;
                }
                // ---ADD 2010/01/22 --------------------<<<<

                // 次フォーカス
                SetControlFocus(this._guideNextControl.GetNextControl(tNedit_UOESupplierCd));
			}
		}
		# endregion ■ 発注先ガイドボタンクリックイベント ■

		# region ■ 依頼者ガイドボタンクリックイベント ■
		/// <summary>
		/// 依頼者ガイドボタンクリックイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void uButton_EmployeeGuide_Click(object sender, EventArgs e)
		{
			EmployeeAcs employeeAcs = new EmployeeAcs();
			Employee employee;
			int status = employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				_inpDisplay.EmployeeCode = employee.EmployeeCode.Trim();
				_inpDisplay.EmployeeName = employee.Name;

				this.tEdit_EmployeeCode.Text = _inpDisplay.EmployeeCode;	//依頼者コード
				this.uLabel_EmployeeName.Text = _inpDisplay.EmployeeName;	//依頼者名称

                // 次フォーカス
                SetControlFocus(this._guideNextControl.GetNextControl(tEdit_EmployeeCode));
			}
		}
		# endregion ■ 依頼者ガイドボタンクリックイベント ■
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
			this.StatusBarMessageSettingProc(this.ActiveControl);
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
            try {
#if False
				this._detailInput.AutoSettingGoodsCode(this._OLEScannerController.ScanDataLabel);
#endif
			}
            finally {
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

		# region ■ 文字列→数値変換（String→Int32） ■
		/// <summary>
		/// 文字列→数値変換（String→Int32）
		/// </summary>
		/// <param name="src">文字列</param>
		/// <returns>数値</returns>
		private Int32 ToInt32FromString(string src)
		{
			Int32 cd = 0;
			try
			{
				cd = Int32.Parse(src);
			}
			catch (Exception)
			{
				cd = 0;
			}
			return (cd);
		}
		# endregion

        # region ■ ガイド後次フォーカス制御クラス ■
        /// <summary>
        /// ガイド後次フォーカス制御クラス
        /// </summary>
        internal class GuideNextFocusControl
        {
            private List<Control> _controls;
            private Dictionary<Control, int> _indexDic;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public GuideNextFocusControl()
            {
                _controls = new List<Control>();
                _indexDic = new Dictionary<Control, int>();
            }
            /// <summary>
            /// 対象コントロール追加
            /// </summary>
            /// <param name="control"></param>
            public void Add(Control control)
            {
                _controls.Add(control);
                if (!_indexDic.ContainsKey(control))
                {
                    _indexDic.Add(control, _controls.Count - 1);
                }
            }
            /// <summary>
            /// 対象コントロール追加
            /// </summary>
            /// <param name="collection"></param>
            public void AddRange(IEnumerable<Control> collection)
            {
                int stIndex = _controls.Count;
                _controls.AddRange(collection);
                int edIndex = _controls.Count - 1;

                for (int i = stIndex; i <= edIndex; i++)
                {
                    if (!_indexDic.ContainsKey(_controls[i]))
                    {
                        _indexDic.Add(_controls[i], i);
                    }
                }
            }
            /// <summary>
            /// 対象コントロールクリア
            /// </summary>
            public void Clear()
            {
                _controls.Clear();
                _indexDic.Clear();
            }
            /// <summary>
            /// 次コントロール取得
            /// </summary>
            /// <param name="control"></param>
            /// <returns></returns>
            public Control GetNextControl(Control control)
            {
                int index = _indexDic[control];
                index++;

                for (int i = index; i < _controls.Count; i++)
                {
                    if (!_controls[i].Visible || !_controls[i].Enabled)
                    {
                        continue;
                    }

                    if (_controls[i] is TEdit)
                    {
                        if ((_controls[i] as TEdit).ReadOnly == true)
                        {
                            continue;
                        }
                    }

                    return _controls[i];
                }
                return _controls[_controls.Count - 1];
            }
        }
        # endregion ■ ガイド後次フォーカス制御クラス ■


        # region ■ 業務区分の変更イベント
        /// <summary>
        /// 業務区分の変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_BusinessCode_ValueChanged(object sender, EventArgs e)
        {
            BusinessCodeChanged();
        }
		# endregion


		# endregion
	}
}
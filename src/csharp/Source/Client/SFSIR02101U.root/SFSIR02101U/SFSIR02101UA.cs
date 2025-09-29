using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTabControl;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 支払伝票入力メインフレーム
	/// </summary>
	/// <remarks>
	/// <br>Note		: 支払い入力を行う画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2006.05.20</br>
	/// <br></br>
	/// <br>UpdateNote	: 2007.02.13 T.Kimura MA.NS 画面スキン変更対応</br>
	/// <br>              2007.02.13 T.Kimura MA.NS 得意先スライダーのパラメータを変更</br>
    /// <br>              2008.02.21 20081 疋田 勇人 DC.NS用に変更(拠点取得方法を変更)</br>
    /// <br>              2008/07/08 30414 忍 幸史 Partsman用に変更</br>
   	/// <br>Update Date	: 2012/12/24 王君 </br>
    /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
    /// <br>            : Redmine#33741の対応</br>
    /// </remarks>
	public partial class SFSIR02101UA : Form
	{
		#region Const
		// 支払伝票入力タブキー
		private const string ctNO0_PAYMENTINPUT_TAB = "NO0_PAYMENTINPUT_TAB";
		#endregion

		# region Private Menbers
		// 拠点情報マスタアクセスクラス
		private SecInfoAcs _secInfoAcs;
		// スライダーパネルクラス
		private SFCMN00221UA _superSlider;
		// フォーム制御リストHashtable
		private Hashtable _formControlInfoTable;
		// Tab子画面表示パラメータ
		private int _parameter;
		// 現在選択拠点
		private object selectedSection;
		// 拠点選択中フラグ
		private bool selectedSectionFlg;
		// ウィンドウ状態保持用（DockManager）
		private MemoryStream _dockMemoryStream;
		// ウィンドウ状態保持用（ToolBar）
		private MemoryStream _toolMemoryStream;
		// 初回起動フラグ
		private int _firstStartFlg;

        // ↓ 20070213 18322 a MA.NS用に変更
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // ↑ 20070213 18322 a

        private IOperationAuthority _operationAuthority;    // 操作権限の制御オブジェクト

		# endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFSIR02101UA()
		{
			InitializeComponent();

			try
			{
				// フォーム制御リスト
				this._formControlInfoTable = new Hashtable();
				// MDI表示パラメータ
				this._parameter = 1;
				// 現在選択拠点
				this.selectedSection = null;
				// 拠点選択中フラグ
				this.selectedSectionFlg = false;
				// ウィンドウ状態保持用（DockManager）
				this._dockMemoryStream = null;
				// ウィンドウ状態保持用（ToolBar）
				this._toolMemoryStream = null;
				// 初回起動フラグ
				this._firstStartFlg = 0;

				// ドックマネージャーにイメージリストを設定する
				Main_DockManager.ImageList = IconResourceManagement.ImageList16;
				DockablePaneBase pnlSliderPaneBase = Main_DockManager.DockAreas["pnlSlider"].Panes["pnlSlider"];
				if (pnlSliderPaneBase != null) pnlSliderPaneBase.Settings.Appearance.Image = Size16_Index.VIEW;

				// ツールバー初期処理
				ToobarInitProc();

                SFCMN00221UAParam param = new SFCMN00221UAParam();
                param.SupplierDiv = 1;

				// スライダーをインスタンス化
                _superSlider = new SFCMN00221UA(param);
			}
			catch (Exception ex)
			{
				string message = "初期処理にて例外が発生しました。"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "支払伝票入力メインフレーム"
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_INIT
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
				Program._floatingWindow.Close();
			}
		}
		#endregion

        /// <summary>
        /// オペレーションコード
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>修正</summary>
            Revision = 10,
            /// <summary>削除</summary>
            Delete = 11,
            /// <summary>赤伝</summary>
            RedSlip = 12,
        }

        // 操作権限の制御オブジェクトの保有
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("SFSIR02101U", this);
                }
                return _operationAuthority;
            }
        }

        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        private void BeginControllingByOperationAuthority()
        {
            // 伝票削除ボタン
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                Main_ToolbarsManager.Tools["Delete_ButtonTool"].SharedProps.Visible = false;
                Main_ToolbarsManager.Tools["Delete_ButtonTool"].SharedProps.Shortcut = Shortcut.None;
            }

            // 赤伝ボタン
            if (MyOpeCtrl.Disabled((int)OperationCode.RedSlip))
            {
                Main_ToolbarsManager.Tools["DebitNote_ButtonTool"].SharedProps.Visible = false;
                Main_ToolbarsManager.Tools["DebitNote_ButtonTool"].SharedProps.Shortcut = Shortcut.None;
            }
        }

		#region PrivateMethod
		/// <summary>
		/// ツールバー初期処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ツールバーの初期設定を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
        /// <br>Update Date : 2012/12/24 王君</br> 
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br> 
        /// <br>            : Redmine#33741の対応</br>
		/// </remarks>
		private void ToobarInitProc()
		{
			// 拠点情報取得
			SecInfoSet secInfoSet;
			_secInfoAcs = new SecInfoAcs();
			// 自社情報取得
			_secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);

			// 拠点コンボボックスに拠点リストを設定する
			ValueList secInfoList = new ValueList();
			foreach (SecInfoSet secInfoSetWk in _secInfoAcs.SecInfoSetList)
			{
				ValueListItem secInfoItem = new ValueListItem();
				secInfoItem.DataValue = secInfoSetWk.SectionCode;
				secInfoItem.DisplayText = secInfoSetWk.SectionGuideNm;
				secInfoList.ValueListItems.Add(secInfoItem);
			}
			ComboBoxTool sectionCombo = (ComboBoxTool)Main_ToolbarsManager.Tools["Section_ComboBoxTool"];
			sectionCombo.ValueList = secInfoList;
			LabelTool sectionLabel = (LabelTool)Main_ToolbarsManager.Tools["Section_LabelTool"];

			// 本社機能無しor拠点オプション無しなら拠点を変更できないようにする
            // 2008.12.26 del [9576] 常に本社機能として動作する
			//if (//(_secInfoAcs.GetMainOfficeFuncFlag(secInfoSet.SectionCode) == 0) ||   
				//(LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) < PurchaseStatus.Contract))
			//{
				//if (sectionCombo != null) sectionCombo.SharedProps.Visible = false;
				//if (sectionLabel != null) sectionLabel.SharedProps.Visible = false;
			//}

			// ツールバーにイメージリストを設定する
			Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// 拠点のアイコン設定
			if (sectionLabel != null) sectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
			// ログイン担当者のアイコン設定
			LabelTool loginCaptionLabel = (LabelTool)Main_ToolbarsManager.Tools["LoginCaption_LabelTool"];
			if (loginCaptionLabel != null) loginCaptionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			// ログイン担当名の設定
			LabelTool loginNameLabel = (LabelTool)Main_ToolbarsManager.Tools["LoginName_LabelTool"];
			if ((LoginInfoAcquisition.Employee != null) &&
				(loginNameLabel != null))
			{
				loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			}
			// 終了ボタンのアイコン設定
			ButtonTool exitButton = (ButtonTool)Main_ToolbarsManager.Tools["Exit_ButtonTool"];
			if (exitButton != null) exitButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			// 新規ボタンのアイコン設定
			ButtonTool newButton = (ButtonTool)Main_ToolbarsManager.Tools["New_ButtonTool"];
			if (newButton != null) newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			// 保存ボタンのアイコン設定
			ButtonTool saveButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
			if (saveButton != null) saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			// 削除ボタンのアイコン設定
			ButtonTool deleteButton = (ButtonTool)Main_ToolbarsManager.Tools["Delete_ButtonTool"];
			if (deleteButton != null) deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
			// 赤伝ボタンのアイコン設定
			ButtonTool debitNoteButton = (ButtonTool)Main_ToolbarsManager.Tools["DebitNote_ButtonTool"];
			if (debitNoteButton != null) debitNoteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.REDSLIP;
            // 最新情報ボタンのアイコン設定
            ButtonTool renewalButton = (ButtonTool)Main_ToolbarsManager.Tools["Renewal_ButtonTool"];
            if (renewalButton != null) renewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            //---ADD 王君 2012/12/24 Redmine#33741 ---------->>>>>
            // 支払伝票呼出ボタンのアイコン設定
            ButtonTool readsupslipButton = (ButtonTool)Main_ToolbarsManager.Tools["ReadSupSlip_ButtonTool"];
            if (readsupslipButton != null) readsupslipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
            //---ADD 王君 2012/12/24 Redmine#33741 ----------<<<<<
		}

		/// <summary>
		/// フォームコントロールクラスクリエイト処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 子画面フォーム制御情報を作成します</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void FormControlInfoCreate()
		{
			// 入金入力(入金型)のコントロールクラス生成
			FormControlInfo info = new FormControlInfo(ctNO0_PAYMENTINPUT_TAB, "SFSIR02102U", "Broadleaf.Windows.Forms.SFSIR02102UA", "支払伝票入力", IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2], "", "");

			// フォーム制御リストに追加
			this._formControlInfoTable.Add(ctNO0_PAYMENTINPUT_TAB, info);
		}

		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note		: ツールーバーボタンの有効・無効設定を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
        /// <br>Update Date : 2012/12/24 王君</br> 
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting(object activeForm)
		{
			if (this.Main_TabControl.ActiveTab == null)
				return;

			// アクティブ状態のタブからフォームを取得する
			FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
			Form frm = formControlInfo.Form;

			// 割当済の時は表示する
			// IDepositInputMDIChildインターフェイスを実装している場合は以下を実行する。
			if (!(frm is IDepositInputMDIChild)) return;


			// 保存ボタン
			ButtonTool saveButton = Main_ToolbarsManager.Tools["Save_ButtonTool"] as ButtonTool;
			if (saveButton != null) saveButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).SaveButton;

			// 新規ボタン
			ButtonTool newButton = Main_ToolbarsManager.Tools["New_ButtonTool"] as ButtonTool;
			if (newButton != null) newButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).NewButton;

			// 削除ボタン
			ButtonTool deleteButton = Main_ToolbarsManager.Tools["Delete_ButtonTool"] as ButtonTool;
			if (deleteButton != null) deleteButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).DeleteButton;

			// 赤伝ボタン
			ButtonTool debitNoteButton = Main_ToolbarsManager.Tools["DebitNote_ButtonTool"] as ButtonTool;
			if (debitNoteButton != null) debitNoteButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).AkaButton;

            ButtonTool renewalButton = Main_ToolbarsManager.Tools["Renewal_ButtonTool"] as ButtonTool;
            if (renewalButton != null) renewalButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).RenewalButton;

            // ---- ADD 王君 2012/12/24 Redmine#33741 ----->>>>>
            ButtonTool readsupslipButton = (ButtonTool)Main_ToolbarsManager.Tools["ReadSupSlip_ButtonTool"];
            if (readsupslipButton != null) readsupslipButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).ReadSlipButton;
            // ---- ADD 王君 2012/12/24 Redmine#33741 -----<<<<<

            BeginControllingByOperationAuthority();
		}

		/// <summary>
		/// タブ表示処理
		/// </summary>
		/// <param name="tabKind">タブ種類</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note		: 指定されたタブを表示します</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void TabShow(string tabKind)
		{
			// タブ生成
			this.TabCreate(tabKind);

			// タブアクティブ化処理
			this.TabActive(tabKind);
		}

		/// <summary>
		/// タブクリエイト処理
		/// </summary>
		/// <param name="key">画面種類</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note		: 子画面タブを生成します</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void TabCreate(string key)
		{
			FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
			Form form;

			// タブが存在しない時
			if (this.Main_TabControl.Tabs.Exists(key) == false)
			{
				// TAB子画面生成処理
				form = this.CreateTabChildForm(info.AssemblyID, info.ClassID, info);
			}
			else
			{
				form = info.Form;
			}

			// IDepositInputTabChildインターフェイスを実装している場合は以下の処理を実行する。
			if ((form is IDepositInputMDIChild))
			{
				// ツールバーボタン制御デリゲートの登録
				((IDepositInputMDIChild)form).ParentToolbarSettingEvent += new ParentToolbarDepositSettingEventHandler(this.ParentToolbarSettingEvent);

				// 選択拠点取得デリゲートの登録
				((IDepositInputMDIChild)form).GetSelectSectionCodeEvent += new GetDepositSelectSectionCodeEventHandler(this.GetSelectSectionCodeEvent);

                // 計上拠点取得デリゲートの登録
                ((IDepositInputMDIChild)form).HandOverAddUpSecNameEvent += new HandOverDepositAddUpSecNameEventHandler(this.HandOverAddUpSecNameEvent);  // 2008.02.21 add

				((IDepositInputMDIChild)form).Show(this._parameter);
			}
			else
			{
				form.Show();
			}
		}

		/// <summary>
		/// タブアクティブ化処理
		/// </summary>
		/// <param name="key">画面種類</param>
		/// <returns>処理結果</returns>
		/// <remarks>
		/// <br>Note		: 指定されたタブをアクティブ化します</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void TabActive(string key)
		{
			// タブが存在する時
			if (this.Main_TabControl.Tabs.Exists(key))
			{
				this.Main_TabControl.Tabs[key].Visible = true;
				this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[key];
			}
		}

		/// <summary>
		/// タブ削除処理
		/// </summary>
		/// <param name="key">画面種類</param>
		/// <returns>処理結果</returns>
		/// <remarks>
		/// <br>Note		: 指定されたタブを削除します</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void TabRemove(string key)
		{
			// タブが存在する時
			if (this.Main_TabControl.Tabs.Exists(key))
			{
				this.Main_TabControl.Tabs.Remove(this.Main_TabControl.Tabs[key]);
			}
		}

		/// <summary>
		/// TAB子画面生成処理
		/// </summary>
		/// <param name="frmAssemblyId">アセンブリＩＤ</param>
		/// <param name="frmClassId">クラスＩＤ</param>
		/// <param name="info">フォームコントロール情報</param>
		/// <returns>フォーム</returns>
		/// <remarks>
		/// <br>Note		: TAB子画面を生成します</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private Form CreateTabChildForm(string frmAssemblyId, string frmClassId, FormControlInfo info)
		{
			Form form = null;

			// クラスインスタンス化処理
			form = (Form)this.LoadAssemblyFrom(frmAssemblyId, frmClassId, typeof(Form));

			if (form == null)
			{
				form = new Form();
			}

			// タブコントロールに追加するタブページをインスタンス化する
			UltraTabPageControl dataviewTabPageControl = new UltraTabPageControl();

			// タブの外観を設定し、タブコントロールにタブを追加する
			UltraTab dataviewTab = new UltraTab();

			dataviewTab.TabPage = dataviewTabPageControl;
			dataviewTab.Text = info.Name;
			dataviewTab.Key = info.Key;
			dataviewTab.Tag = info.Form;
			dataviewTab.Appearance.Image = info.Icon;
			dataviewTab.Appearance.BackColor = Color.White;
			dataviewTab.Appearance.BackColor2 = Color.Lavender;
			dataviewTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
			dataviewTab.ActiveAppearance.BackColor = Color.White;
			dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
			dataviewTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;
			dataviewTab.ActiveAppearance.FontData.Bold = DefaultableBoolean.True;

			this.Main_TabControl.Controls.Add(dataviewTabPageControl);
			this.Main_TabControl.Tabs.AddRange(new UltraTab[] { dataviewTab });
			this.Main_TabControl.SelectedTab = dataviewTab;

			// フォームプロパティ変更
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = DockStyle.Fill;
			dataviewTabPageControl.Controls.Add(form);

			info.Form = form;

			return info.Form;
		}

		/// <summary>
		/// クラスインスタンス化処理
		/// </summary>
		/// <param name="asmname">アセンブリ名称</param>
		/// <param name="classname">クラス名称</param>
		/// <param name="type">実装するクラス型</param>
		/// <returns>インスタンス化されたクラス</returns>
		/// <remarks>
		/// <br>Note		: 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;

			try
			{
				// アセンブリリフレクション
				Assembly asm = Assembly.Load(asmname);

				// クラス型取得
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					// 正常であればインスタンス化する
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch (FileNotFoundException exNotFound)
			{
				// 対象アセンブリなし！
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, exNotFound.Message, -1, MessageBoxButtons.OK);
			}
			catch (Exception ex)
			{
				string message = "クラスインスタンス化処理にて例外が発生しました。"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "支払伝票入力メインフレーム"
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_INIT
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
			}

			return obj;
		}

		/// <summary>
		/// Tab子画面のデータ表示指示 (仕入先コード指定モード)
		/// </summary>
        /// <param name="supplierCode">仕入先コード</param>
		/// <remarks>
		/// <br>Note		: Tab子画面のデータ表示指示</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void RefreshTabChildCustomerMode(int supplierCode)
		{
			// パラメータが正常なとき
			if (supplierCode != 0)
			{
				// 現在、アクティブな画面を取得する
				FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
				Form frm = formControlInfo.Form;

				if (frm != null)
				{
					// IDepositInputMDIChildインターフェイスを実装している場合は以下の処理を実行する。
					if ((frm is IDepositInputMDIChild))
					{
						object[] parameter = new object[1] { supplierCode };

						((IDepositInputMDIChild)frm).ShowData(0, parameter);
					}
				}

				if ((!this.Main_DockManager.ControlPanes[0].Pinned) &&
					(this.Main_DockManager.ControlPanes[0].Manager.FlyoutPane != null))
				{
					this.Main_DockManager.ControlPanes[0].Manager.FlyIn(true);
				}
			}
		}

		/// <summary>
		/// ウィンドウ初期化処理
		/// </summary>
		/// <param>none</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: ウィンドウを初期化する</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void InitWindow()
		{
			// ドックの状態を初期化
			if (this._dockMemoryStream == null)
				return;
			this._dockMemoryStream.Position = 0;
			this.Main_DockManager.LoadFromBinary(this._dockMemoryStream);

			// ツールバーの状態を初期化
			if (this._toolMemoryStream == null)
				return;
			this._toolMemoryStream.Position = 0;
			this.Main_ToolbarsManager.LoadFromBinary(this._toolMemoryStream);
		}
		#endregion

		#region DelegateEvent
		/// <summary>
		/// ツールバーボタン制御イベント
		/// </summary>
		/// <param name="sender">オブジェクト</param>
		/// <remarks>
		/// <br>Note		: フレームのボタン有効無効制御をしたい場合に発生させます。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void ParentToolbarSettingEvent(object sender)
		{
			ToolBarButtonEnabledSetting(sender);
		}

		/// <summary>
		/// 拠点コード取得
		/// </summary>
		/// <param name="sender">オブジェクト</param>
		/// <remarks>
		/// <br>Note		: フレームにて選択されている拠点コードを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private string GetSelectSectionCodeEvent(object sender)
		{
			// 現在選択拠点を返す
			ValueListItem secInfoList = selectedSection as ValueListItem;
			if (secInfoList != null)
			{
				return secInfoList.DataValue.ToString();
			}

			return "";
		}

        /// <summary>
        /// 支払計上拠点名称取得
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="sectionName">計上拠点名称</param>
        /// <remarks>
        /// <br>Note       : 支払計上拠点名称を取得します。</br>
        /// <br>Programer  : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.02.21</br>
        /// </remarks>
        private void HandOverAddUpSecNameEvent(object sender, string sectionName)
        {
            // 支払計上拠点を表示
            Main_ToolbarsManager.Tools["SectionCode_L"].SharedProps.Caption = sectionName;
        }

		/// <summary>
		/// ユーザーデータ取得完了デリゲート
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		private void SearchUserDataFinish(object sender, EventArgs e)
		{
			//同期モードしかないので、このロジックは不要です。
		}

		/// <summary>
		/// 提供データ取得完了デリゲート
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		private void SearchOfferDataFinish(object sender, EventArgs e)
		{
			//同期モードしかないので、このロジックは不要です。
		}

		/// <summary>
		/// 顧客車両選択イベント(スライダーにて顧客車両選択時に発生)
		/// </summary>
		/// <param name="selectData">顧客車輌選択情報</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note		: 顧客車両選択イベント(スライダーにて顧客車両選択時に発生)</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// <br>Update Note : 2007.02.22 T.Kimura パラメータをMA.NS用に変更</br>
		/// </remarks>
        // ↓ 20070222 18322 c MA.NS用に変更
        //public void SelectedSupplier(CustomerCarSearchAcsRet selectData)
		//{

        public void SelectedSupplier(Supplier selectData)
		{
        // ↑ 20070222 18322 c
			// 顧客車両が選択され場合に飛び込みます
			if (selectData != null)
			{
				// 子画面のデータ表示指示 (得意先コード指定モード)
				this.RefreshTabChildCustomerMode(selectData.SupplierCd);
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームが読み込まれた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.17</br>
		/// </remarks>
		private void SFSIR02101UA_Load(object sender, EventArgs e)
		{
			// 初回起動フラグ
			try
			{
				if (this._firstStartFlg == 0)
				{
                    // ↓ 20070213 18322 a MA.NS用に変更
                    // 画面スキンファイルの読込(デフォルトスキン指定)
                    this._controlScreenSkin.LoadSkin();

                    // 画面スキン変更
                    this._controlScreenSkin.SettingScreenSkin(this);
                    // ↑ 20070213 18322 a

                    // ↓ 20070519 18322 d 使用しないように変更したので削除
                    //// 仕入在庫共通初期処理ユーザーデータ取得
					//// 支払伝票入力共通初期値取得
					//StokCommonInitDataAcs stokCommonInitDataAcs = new StokCommonInitDataAcs();
					//stokCommonInitDataAcs.Search(StockPayInitProcCall_Mode.PAY
					//	, LoginInfoAcquisition.EnterpriseCode
					//	, _secInfoAcs.SecInfoSet.SectionCode
					//	, new EventHandler(SearchUserDataFinish)
					//	, new EventHandler(SearchOfferDataFinish));
                    // ↑ 20070519 18322 d

					// フォーム制御テーブル初期化
					this._formControlInfoTable.Clear();

					// フォームコントロールクラスクリエイト処理
					FormControlInfoCreate();

					TabShow(ctNO0_PAYMENTINPUT_TAB);

					// 拠点を設定
                    // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
                    //ComboBoxTool sectionCombo = (ComboBoxTool)Main_ToolbarsManager.Tools["Section_ComboBoxTool"];
                    //SecInfoSet secInfoSet;
                    //_secInfoAcs.GetSecInfo(_secInfoAcs.SecInfoSet.SectionCode, SecInfoAcs.CtrlFuncCode.PayAddUpSecCd, out secInfoSet);
                    //sectionCombo.Value = secInfoSet.SectionCode;
                    Main_ToolbarsManager.Tools["SectionCode_L"].SharedProps.Caption = this._secInfoAcs.SecInfoSet.SectionGuideNm.Trim();
                    // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
                    Main_ToolbarsManager_ToolValueChanged(sender, new ToolEventArgs(Main_ToolbarsManager.Tools["Section_ComboBoxTool"]));

                    // ↓ 20070222 18322 d MA.NS用に変更
					//// スーパースライダーアセンブリロード・ガイド追加処理
					//_superSlider.AcceptOrderListShow = false;				// 最近使用した伝票非表示
					//Panel sldpanel = _superSlider.GetMainPanel(0, 15);
					//this.pnlSlider.Controls.Add(sldpanel);					// ←貼り付けるパネルを指定
					//sldpanel.Dock = System.Windows.Forms.DockStyle.Fill;
                    //
					//// 顧客選択イベント(スライダーにて顧客選択時に発生)
					//_superSlider.SelectedSupplier += new SelectedCustomerCarHandler(SelectedSupplier);
                    // ↑ 20070222 18322 d

                    // ↓ 20070309 pend 18322 a MA.NS用に変更
					// スーパースライダーアセンブリロード・ガイド追加処理
					_superSlider.StockSlipListShow = false;				// 最近使用した伝票非表示
					Panel sldpanel = _superSlider.GetMainPanel(0, 15);
					this.pnlSlider.Controls.Add(sldpanel);					// ←貼り付けるパネルを指定
					sldpanel.Dock = DockStyle.Fill;

                    // 顧客選択イベント(スライダーにて顧客選択時に発生)
					_superSlider.SelectedSupplier += new SelectedSupplierHandler(SelectedSupplier);
                    // ↑ 20070309 18322 a

                    BeginControllingByOperationAuthority();

					this._firstStartFlg++;
				}
			}
			catch (Exception ex)
			{
				string message = "フォームロード処理にて例外が発生しました。"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "支払伝票入力メインフレーム"
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_LOAD
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
			}
			finally
			{
				// 起動用フローティングウィンドウ(Close)
				Program._floatingWindow.Close();
			}

			// 起動タイマー開始
			StartTimer.Enabled = true;
		}

		/// <summary>
		/// ツールバー内容選択イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note		: ツールバーの各アイテム内容が選択された時に発生します</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolValueChanged(object sender, ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Section_ComboBoxTool":
				{
					// 二重起動防止フラグ判定
					if (selectedSectionFlg) return;

					// 拠点コンボボックスの取得
					ComboBoxTool sectionList = (ComboBoxTool)e.Tool;
					if (sectionList.Value == null) return;

					// 現在アクティブタブがあるか
					if (this.Main_TabControl.ActiveTab != null)
					{
						// アクティブ状態のタブからフォームを取得する
						FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
						Form frm = formControlInfo.Form;

						// 割当済の時は表示する
						// IDepositInputMDIChildインターフェイスを実装している場合は以下の処理を実行する。
						if ((frm is IDepositInputMDIChild))
						{
							// 拠点変更前通知処理
							if (((IDepositInputMDIChild)frm).BeforeSectionChange() != 0)
							{
								// 前回選択拠点に戻す 当イベントの二重起動防止フラグ使用
								selectedSectionFlg = true;
								sectionList.SelectedItem = selectedSection;
								selectedSectionFlg = false;
								return;
							}

							// 現在選択拠点のコードを保持
							selectedSection = sectionList.SelectedItem;

							// 拠点変更後通知処理
							((IDepositInputMDIChild)frm).AfterSectionChange();
						}
					}
					else
					{
						// 現在選択拠点を保持
						selectedSection = sectionList.SelectedItem;
					}

					break;
				}
			}
		}

		/// <summary>
		/// 起動タイマー開始イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note		: 起動処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void StartTimer_Tick(object sender, EventArgs e)
		{
			// 起動タイマー終了
			StartTimer.Enabled = false;

			RefreshTabChildCustomerMode(0);

			// DockManagerの状態を保持する
			this._dockMemoryStream = new MemoryStream();
			this.Main_DockManager.SaveAsBinary(this._dockMemoryStream);
			// ToolBarの状態を保持する
			this._toolMemoryStream = new MemoryStream();
			this.Main_ToolbarsManager.SaveAsBinary(this._toolMemoryStream, false);
		}

		/// <summary>
		/// ツールバークリックイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note		: ツールバー上のツールがクリックされた時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
        /// <br>Update Date : 2012/12/24 王君</br> 
        /// <br>管理番号　　: 10806793-00 2013/03/13配信分</br>
        /// <br>            : Redmine#33741の対応</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Exit_ButtonTool":
				{
					// メイン画面のクローズ
					this.Close();
					return;
				}
				case "InitWindow_ButtonTool":
				{
					// ウィンドウ初期化処理
					this.InitWindow();
					return;
				}
			}

			// アクティブ状態のタブからフォームを取得する
			FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
			Form frm = formControlInfo.Form;

			// IDepositInputMDIChildインターフェイスを実装している場合のみ以下実行
			if (!(frm is IDepositInputMDIChild)) return;

			switch (e.Tool.Key)
			{
				case "Save_ButtonTool":
				{
					// 保存処理
					((IDepositInputMDIChild)frm).SaveDepositProc();
					break;
				}
				case "New_ButtonTool":
				{
					// 新規処理
					((IDepositInputMDIChild)frm).NewDepositProc();
					break;
				}
				case "Delete_ButtonTool":
				{
					// 削除処理
					((IDepositInputMDIChild)frm).DeleteDepositProc();
					break;
				}
				case "DebitNote_ButtonTool":
				{
					// 赤伝処理
					((IDepositInputMDIChild)frm).AkaDepositProc();
					break;
				}
            case "Renewal_ButtonTool":
                {
                    ((IDepositInputMDIChild)frm).RenewalProc();
                    break;
                }
                // ----- ADD 王君 2012/12/24 Redmine#33741 -------->>>>>
                case "ReadSupSlip_ButtonTool":
                {
                    //伝票呼出処理
                    ((IDepositInputMDIChild)frm).ReadSlipProc();
                    break;
                }
                // ----- ADD 王君 2012/12/24 Redmine#33741 --------<<<<<
			}
		}

		/// <summary>
		/// フォーム終了クエリーイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note		: フォームを閉じようとした時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void SFSIR02101UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// アクティブ状態のタブからフォームを取得する
			FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
			Form frm = formControlInfo.Form;

			// 割当済の時は表示する
			// IDepositInputMDIChildインターフェイスを実装している場合は以下の処理を実行する。
			if ((frm is IDepositInputMDIChild))
			{
				object parameter = null;
				if (((IDepositInputMDIChild)frm).BeforeClose(parameter) != 0)
				{
					e.Cancel = true;
					return;
				}
			}

			if (this.Main_TabControl.Tabs.Exists(ctNO0_PAYMENTINPUT_TAB))
			{
				// スライダーの表示内容を保存する
				_superSlider.ClosePanel();
			}

			// タブ削除処理
			TabRemove(ctNO0_PAYMENTINPUT_TAB);
		}
		#endregion

        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // ボタンを「Visible = False」にすると、イベントが発生しないため、
            // サイズを「1, 1」にし、実質的に見えないようにする

            DialogResult dResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "終了してもよろしいですか？",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
	}
}
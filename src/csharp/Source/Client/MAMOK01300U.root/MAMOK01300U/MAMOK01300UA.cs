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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 売上目標設定(要素別)メインフレーム
	/// </summary>
	/// <remarks>
	/// <br>Note		: 目標入力を行う画面です。</br>
	/// <br>Programmer	: NEPCO</br>
	/// <br>Date		: 2007.03.29</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class MAMOK01300UA : Form
	{
		#region Const

        // 売上目標設定(要素別)タブ
        private const string ctNO0_SALESTARTGETELEMENT_TAB   = "NO0_SALESTARTGETELEMENT_TAB";
        private const string ctNO0_SALESTARTGETELEMENT_ASSY  = "MAMOK01310U";
        private const string ctNO0_SALESTARTGETELEMENT_CLASS = "Broadleaf.Windows.Forms.MAMOK01310UA";
        private const string ctNO0_SALESTARTGETELEMENT_TITLE = "売上目標設定(要素別)";

		#endregion

		# region Private Menbers
		// 拠点情報マスタアクセスクラス
		private SecInfoAcs _secInfoAcs;
		// フォーム制御リストHashtable
		private Hashtable _formControlInfoTable;
		// Tab子画面表示パラメータ
		private int _parameter;
		// 現在選択拠点
		private object selectedSection;
		// 拠点選択中フラグ
		private bool selectedSectionFlg;
		// ウィンドウ状態保持用（ToolBar）
		private MemoryStream _toolMemoryStream;
		// 初回起動フラグ
		private int _firstStartFlg;

		private int _mode;

		/// <summary>画面デザイン変更クラス</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MAMOK01300UA()
		{
			InitializeComponent();

			try
			{
				if (Program._param.Length >= 3)
				{
					this._mode = int.Parse(Program._param[2]);
				}
				else
				{
					this._mode = 0;
				}

				// フォーム制御リスト
				this._formControlInfoTable = new Hashtable();
				// MDI表示パラメータ
				this._parameter = 1;
				// 現在選択拠点
				this.selectedSection = null;
				// 拠点選択中フラグ
				this.selectedSectionFlg = false;
				// ウィンドウ状態保持用（ToolBar）
				this._toolMemoryStream = null;
				// 初回起動フラグ
				this._firstStartFlg = 0;

				// ツールバー初期処理
				ToobarInitProc();
			}
			catch (Exception ex)
			{
				string message = "初期処理にて例外が発生しました"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "目標設定メインフレーム"
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_INIT
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
                //Program._floatingWindow.Close();
			}
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// ツールバー初期処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ツールバーの初期設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void ToobarInitProc()
		{
			// 拠点情報取得
            //SecInfoSet secInfoSet;
            //_secInfoAcs = new SecInfoAcs();
            //// 自社情報取得
            //_secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);

			// 拠点コンボボックスに拠点リストを設定する
            //ValueList secInfoList = new ValueList();
            //foreach (SecInfoSet secInfoSetWk in _secInfoAcs.SecInfoSetList)
            //{
            //    ValueListItem secInfoItem = new ValueListItem();
            //    secInfoItem.DataValue = secInfoSetWk.SectionCode;
            //    secInfoItem.DisplayText = secInfoSetWk.SectionGuideNm;
            //    secInfoList.ValueListItems.Add(secInfoItem);
            //}
            //ComboBoxTool sectionCombo = (ComboBoxTool)Main_ToolbarsManager.Tools["Section_ComboBoxTool"];
            //sectionCombo.ValueList = secInfoList;
            //sectionCombo.SharedProps.Enabled = false;
            //sectionCombo.SharedProps.AppearancesLarge.Appearance.ForeColorDisabled = Color.Black;
            //sectionCombo.SharedProps.AppearancesSmall.Appearance.ForeColorDisabled = Color.Black;
            //LabelTool sectionLabel = (LabelTool)Main_ToolbarsManager.Tools["Section_LabelTool"];

            //// 本社機能無しor拠点オプション無しなら拠点を変更できないようにする
            //if ((_secInfoAcs.GetMainOfficeFuncFlag(secInfoSet.SectionCode) == 0) ||
            //    (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) < PurchaseStatus.Contract))
            //{
            //    //if (sectionCombo != null) sectionCombo.SharedProps.Enabled = false;
            //    if (sectionCombo != null) sectionCombo.SharedProps.Visible = false;
            //    if (sectionLabel != null) sectionLabel.SharedProps.Visible = false;
            //}

			// ツールバーにイメージリストを設定する
			Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// 拠点のアイコン設定
			//if (sectionLabel != null) sectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
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
			ButtonTool workButton;
			// 終了ボタンのアイコン設定
			workButton = (ButtonTool)Main_ToolbarsManager.Tools["Exit_ButtonTool"];
			if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            // 元に戻すボタンのアイコン設定
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Undo_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Undo_MenuTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
        }

		/// <summary>
		/// フォームコントロールクラスクリエイト処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 子画面フォーム制御情報を作成します</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void FormControlInfoCreate()
		{
			FormControlInfo info;

            // 売上目標設定(要素別)のコントロールクラス生成
			info = new FormControlInfo(
				ctNO0_SALESTARTGETELEMENT_TAB,
                ctNO0_SALESTARTGETELEMENT_ASSY,
                ctNO0_SALESTARTGETELEMENT_CLASS,
                ctNO0_SALESTARTGETELEMENT_TITLE,
				IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2],
				"",
				"");
			// フォーム制御リストに追加
			this._formControlInfoTable.Add(ctNO0_SALESTARTGETELEMENT_TAB, info);
		}

		/// <summary>
		/// ツールバーボタン有効無効設定処理
		/// </summary>
        /// <param name="activeForm">アクティブフォーム</param>
        /// <remarks>
		/// <br>Note		: ツールーバーボタンの有効・無効設定を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting(object activeForm)
		{
			if (this.Main_TabControl.ActiveTab == null)
				return;

			// アクティブ状態のタブからフォームを取得する
			FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
			System.Windows.Forms.Form frm = formControlInfo.Form;

			// 割当済の時は表示する
			// ISalesMonDetailsTargetMDIChildインターフェイスを実装している場合は以下を実行する。
			if (!(frm is ISalesMonDetailsTargetMDIChild)) return;

			// タイトル
			this.Text = ((ISalesMonDetailsTargetMDIChild)frm).Title;

			ButtonTool workButton;

            // 元に戻すボタン
            workButton = Main_ToolbarsManager.Tools["Undo_ButtonTool"] as ButtonTool;
            if (workButton != null) workButton.SharedProps.Enabled = ((ISalesMonDetailsTargetMDIChild)frm).UndoButton;
            workButton = Main_ToolbarsManager.Tools["Undo_MenuTool"] as ButtonTool;
            if (workButton != null) workButton.SharedProps.Enabled = ((ISalesMonDetailsTargetMDIChild)frm).UndoButton;

		}

		/// <summary>
		/// タブ表示処理
		/// </summary>
		/// <param name="tabKind">タブ種類</param>
		/// <remarks>
		/// <br>Note		: 指定されたタブを表示します</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
		/// <remarks>
		/// <br>Note		: 子画面タブを生成します</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
			if ((form is ISalesMonDetailsTargetMDIChild))
			{
				// ツールバーボタン制御デリゲートの登録
				((ISalesMonDetailsTargetMDIChild)form).ParentToolbarSettingEvent += new ParentToolbarSalesMonDetailsTargetSettingEventHandler(this.ParentToolbarSettingEvent);

                // 選択拠点取得デリゲートの登録
                //((ISalesMonDetailsTargetMDIChild)form).GetSelectSectionCodeEvent += new GetSalesMonDetailsTargetSelectSectionCodeEventHandler(this.GetSelectSectionCodeEvent);

                int status = ((ISalesMonDetailsTargetMDIChild)form).InitializeForm();
                if (status != 0)
                {
                    return;
                }

                ((ISalesMonDetailsTargetMDIChild)form).Show(this._parameter);
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
		/// <remarks>
		/// <br>Note		: 指定されたタブをアクティブ化します</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private Form CreateTabChildForm(string frmAssemblyId, string frmClassId, FormControlInfo info)
		{
			Form form = null;

			// クラスインスタンス化処理
			form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(frmAssemblyId, frmClassId, typeof(System.Windows.Forms.Form));

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
			dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			dataviewTab.ActiveAppearance.BackColor = Color.White;
			dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
			dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			dataviewTab.ActiveAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

			this.Main_TabControl.Controls.Add(dataviewTabPageControl);
			this.Main_TabControl.Tabs.AddRange(new UltraTab[] { dataviewTab });
			this.Main_TabControl.SelectedTab = dataviewTab;

			// フォームプロパティ変更
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = System.Windows.Forms.DockStyle.Fill;
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
                MessageBox.Show(asmname);
				// 対象アセンブリなし！
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, exNotFound.Message, -1, MessageBoxButtons.OK);
			}
			catch (Exception ex)
			{
                //MessageBox.Show(asmname);
				string message = "クラスインスタンス化処理にて例外が発生しました"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "目標設定メインフレーム"
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
		/// ウィンドウ初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: ウィンドウを初期化する</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void InitWindow()
		{
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
        //private string GetSelectSectionCodeEvent(object sender)
        //{
        //    // 現在選択拠点を返す
        //    ValueListItem secInfoList = selectedSection as ValueListItem;
        //    if (secInfoList != null)
        //    {
        //        return secInfoList.DataValue.ToString();
        //    }

        //    return "";
        //}

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
		#endregion

		#region Event
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォームが読み込まれた時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void MAMOK01300UA_Load(object sender, EventArgs e)
		{
			// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.LoadSkin();

			// 画面スキン変更
			this._controlScreenSkin.SettingScreenSkin(this);

			// 初回起動フラグ
			try
			{
				if (this._firstStartFlg == 0)
				{
					// フォーム制御テーブル初期化
					this._formControlInfoTable.Clear();

					// フォームコントロールクラスクリエイト処理
					FormControlInfoCreate();
					TabShow(ctNO0_SALESTARTGETELEMENT_TAB);

					// 拠点を設定
					//ComboBoxTool sectionCombo = (ComboBoxTool)Main_ToolbarsManager.Tools["Section_ComboBoxTool"];
					//sectionCombo.Value = LoginInfoAcquisition.Employee.BelongSectionCode;

					//Main_ToolbarsManager_ToolValueChanged(sender, new ToolEventArgs(Main_ToolbarsManager.Tools["Section_ComboBoxTool"]));

					this._firstStartFlg++;
				}
			}
			catch (Exception ex)
			{
				string message = "フォームロード処理にて例外が発生しました"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "目標設定メインフレーム"
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
                //Program._floatingWindow.Close();
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolValueChanged(object sender, ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
                //case "Section_ComboBoxTool":
                //{
                //    // 二重起動防止フラグ判定
                //    if (selectedSectionFlg) return;

                //    // 拠点コンボボックスの取得
                //    ComboBoxTool sectionList = (ComboBoxTool)e.Tool;
                //    if (sectionList.Value == null) return;

                //    // 現在アクティブタブがあるか
                //    if (this.Main_TabControl.ActiveTab != null)
                //    {
                //        // アクティブ状態のタブからフォームを取得する
                //        FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
                //        System.Windows.Forms.Form frm = formControlInfo.Form;

                //        // 割当済の時は表示する
                //        // ISalesMonDetailsTargetMDIChildインターフェイスを実装している場合は以下の処理を実行する。
                //        if ((frm is ISalesMonDetailsTargetMDIChild))
                //        {
                //            // 拠点変更前通知処理
                //            if (((ISalesMonDetailsTargetMDIChild)frm).BeforeSectionChange() != 0)
                //            {
                //                // 前回選択拠点に戻す 当イベントの二重起動防止フラグ使用
                //                selectedSectionFlg = true;
                //                sectionList.SelectedItem = selectedSection;
                //                selectedSectionFlg = false;
                //                return;
                //            }

                //            // 現在選択拠点のコードを保持
                //            selectedSection = sectionList.SelectedItem;

                //            // 拠点変更後通知処理
                //            ((ISalesMonDetailsTargetMDIChild)frm).AfterSectionChange();
                //        }
                //    }
                //    else
                //    {
                //        // 現在選択拠点を保持
                //        selectedSection = sectionList.SelectedItem;
                //    }

                //    break;
                //}
			}
		}

		/// <summary>
		/// 起動タイマー開始イベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note		: 起動処理を行います。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void StartTimer_Tick(object sender, EventArgs e)
		{
			// 起動タイマー終了
			StartTimer.Enabled = false;

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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
			System.Windows.Forms.Form frm = formControlInfo.Form;

			// ISalesMonDetailsTargetMDIChildインターフェイスを実装している場合のみ以下実行
			if (!(frm is ISalesMonDetailsTargetMDIChild)) return;

			switch (e.Tool.Key)
			{
                case "Undo_ButtonTool":
                case "Undo_MenuTool":
                    {
                        // 元に戻す処理
                        ((ISalesMonDetailsTargetMDIChild)frm).UndoSalesMonTargetProc();
                        break;
                    }
			}
		}

		/// <summary>
		/// フォーム終了クエリーイベント
		/// </summary>
		/// <param name="sender">イベントオブジェクト</param>
		/// <param name="e">イベント情報</param>
		/// <remarks>
		/// <br>Note		: フォームを閉じようとした時に発生します。</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void MAMOK01300UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// アクティブ状態のタブからフォームを取得する
			FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
			System.Windows.Forms.Form frm = formControlInfo.Form;

			// 割当済の時は表示する
			// ISalesMonDetailsTargetMDIChildインターフェイスを実装している場合は以下の処理を実行する。
			if ((frm is ISalesMonDetailsTargetMDIChild))
			{
				object parameter = null;
				if (((ISalesMonDetailsTargetMDIChild)frm).BeforeClose(parameter) != 0)
				{
					e.Cancel = true;
					return;
				}
			}
			// タブ削除処理
			TabRemove(ctNO0_SALESTARTGETELEMENT_TAB);
		}
		#endregion
	}
}
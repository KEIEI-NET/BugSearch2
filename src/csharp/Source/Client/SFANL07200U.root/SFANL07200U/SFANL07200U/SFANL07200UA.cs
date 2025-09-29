#define CLR2
//#define _ONE_SECTION_ONLY_  // ADD 2010/02/19 MANTIS対応[14310]：疑似的に1拠点のみの状態とするフラグ ※リリース時は無効とすること

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;   // 2008.09.05 T.Kudoh ADD
using Broadleaf.Application.Controller.Facade;  // 2008.09.05 T.Kudoh ADD
using Broadleaf.Application.Controller.Util;    // 2008.09.05 T.Kudoh ADD
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.Misc;
using Broadleaf.Library.Diagnostics;// ADD 譚洪 2021/01/04 PMKOBETSU-4109の対応

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 帳票共通(条件入力タイプ)フレームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 帳票共通(条件入力タイプ)のフレームクラスです。</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2006.01.17</br>
    /// <br>Update Note: 2006.04.17 Y.Sasaki</br>
    /// <br>           : １.ボタン名称変更。PDF出力⇒PDF表示</br>
    /// <br>           : ２.PDF履歴保存機能追加。</br>
    /// <br>Update Note: 2006.04.19 Y.Sasaki</br>
    /// <br>           : １.VS2005(CLR2.0) 対応 </br>
    /// <br>Update Note: 2006.05.01 Y.Sasaki</br>
    /// <br>           : １.終了時にPDFが削除されない現象の回避。 </br>
    /// <br>Update Note: 2006.07.24 Y.Sasaki</br>
    /// <br>           : １.ブラッシュアップ対応(スライダー、タブスタイル)。 </br>
    /// <br>Update Note: 2006.08.09  Y.Sasaki </br>
    /// <br>           : １.システム選択有り時の選択可能システムの設定を<br>
    /// <br>           : 選択可能システムより選択できるように機能追加。<br>
    /// <br>Update Note: 2006.09.01  Y.Sasaki </br>
    /// <br>           : １.テキスト出力機能追加<br>
    /// <br>Update Note: 2006.09.04  Y.Sasaki </br>
    /// <br>           : １.拠点コードのトリム追加<br>
    /// <br>Update Note: 2006.09.26  Y.Sasaki </br>
    /// <br>           : １.拠点制御設定で「全拠点」が設定されるとき、「全社」にチェックがつかない障害解除。<br>
    /// <br>Update Note: 2006.09.28  Y.Sasaki </br>
    /// <br>           : １.テキスト出力機能追加。<br>
    /// <br>Update Note: 2007.03.05  Y.Sasaki </br>
    /// <br>           : １.携帯.NS用に変更。グラフ表示機能追加<br>
    /// <br>Update Note: 2007.06.29  Y.Sasaki </br>
    /// <br>           : １.ナビゲートモード時に全ての画面をとじて、印刷をおこなおうとすると
    /// <br>           : エラーになる障害解除。
    /// <br>Update Note: 2007.06.29  Y.Sasaki </br>
    /// <br>           : １.グラフ画面タブがアクティブな時に抽出条件が選択できないように修正。</br>
    /// <br>Update Note: 2007.07.24  Y.Sasaki </br>
    /// <br>           : １.子画面の日付コンポにフォーカスがある状態、かつゼロサプレスが</br>
    /// <br>           : かかるような入力値の場合に、グラフ表示ボタン押下されると日付コンポの内部値が初期化される現象を解除。</br>
    /// <br>Update Note: 2008.09.05  T.Kudoh </br>
    /// <br>           : １.操作権限に応じたボタン制御の対応</br>
    /// <br>Update Note: 2008.11.12  Y.Shinobu </br>
    /// <br>           : １．実行機能追加</br>
    /// <br>Update Note: 2009.01.14  Y.Shinobu </br>
    /// <br>           : １．障害ID:9980対応</br>
    /// <br>Update Note: 2009.01.19  Y.Shinobu </br>
    /// <br>           : １．障害ID:9982対応</br>
    /// <br>Update Note: 2009.09.02  鈴木 正臣 </br>
    /// <br>           : １．MANTIS 0013848</br>
    /// <br>           :     "実行"ボタン押下時に、プレビューなし印刷しても印刷されない不具合を修正。</br>
    /// <br>Update Note: 2009.12.25  工藤</br>
    /// <br>           : １．MANTIS 0014310</br>
    /// <br>           :     拠点マスタに1拠点のみでの拠点範囲指定の不正を修正</br>
    /// <br>Update Note: 2010.02.19  工藤</br>
    /// <br>           : １．MANTIS 0014310</br>
    /// <br>           :     拠点マスタに1拠点のみでの拠点範囲指定の不正を修正（差し戻し）</br>
    /// <br>Update Note: 2010.05.11  工藤</br>
    /// <br>           : １．MANTIS 0015358</br>
    /// <br>           :     1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正</br>
    /// <br>Update Note: 2010/08/16  高峰</br>
    /// <br>           : 障害改良対応（８月分）/br>
    /// <br>           :     キーボード操作の改良を行う。</br>
    /// <br>Update Note: 2011/03/14 yangmj</br>
    /// <br>             回収予定表で、画面入力内容がXMLに保存し、
    /// <br> 　　　　　　次回起動時に設定した内容が反映される様にするの修正</br>
    /// <br>Update Note: 2011/10/27 凌小青</br>
    /// <br>             障害報告 #26273の対応</br>
    /// <br>Update Note: 2011/12/15 劉亜駿</br>
    /// <br>管理番号   : 10707327-00 2012/01/25配信分</br>
    /// <br>             Redmine#27268　帳票フレーム／起動ナビゲーターのレ点チェックの修正</br>
    /// <br>Update Note: K2014/03/10 licb</br>
    /// <br>管理番号   : 11000606-00  </br>
    /// <br>             信越自動車商会個別開発 テキスト出力機能を追加する</br>
    /// <br>Update Note: 2021/01/04 譚洪</br>
    /// <br>管理番号   : 11670323-00</br>
    /// <br>             PMKOBETSU-4109　プログラム起動ログを操作履歴ログに出力する追加対応</br>
    /// </remarks>
    public class SFANL07200UA : System.Windows.Forms.Form
    {
        # region Private Members (Component)

        private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_TabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTree.UltraTree StartNavigatorTree;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private System.Windows.Forms.Panel SFUKK06180U_Fill_Panel;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Main_StatusBar;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar SelectExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet AddUpCd_UOptionSet;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private Infragistics.Win.UltraWinTree.UltraTree Section_UTree;
        private Infragistics.Win.UltraWinTree.UltraTree System_UTree;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL07200UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL07200UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL07200UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _SFANL07200UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _SFANL07200UAAutoHideControl;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea3;
        private System.Windows.Forms.Panel PdfHistory_Panel;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea2;
        private System.Windows.Forms.ContextMenu TabControl_contextMenu;
        private System.Windows.Forms.MenuItem Close_menuItem;
        private TMemPos tMemPos1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL07200UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Main_ToolbarsManager;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL07200UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL07200UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFANL07200UA_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor startRangeNameUltraTextEditor;
        private Infragistics.Win.Misc.UltraLabel startRangeUltraLabel;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor endRangeNameUltraTextEditor;
        private Infragistics.Win.Misc.UltraLabel endRangeUltraLabel;
        private TNedit tEdit_SectionCode_St;
        private TNedit tEdit_SectionCode_Ed;
        private TRetKeyControl tRetKeyControl;
        private TArrowKeyControl tArrowKeyControl;
        private UiSetControl uiSetControl;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow3;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow2;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow4;
        private System.ComponentModel.IContainer components;
        #endregion

        // ===============================================================================
        // コンストラクタ
        // ===============================================================================
        # region Constructor
        /// <summary>
        /// 帳票共通(条件入力タイプ)フレームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 信越自動車商会個別開発 テキスト出力機能を追加する</br>
        /// </remarks>
        public SFANL07200UA()
        {
            InitializeComponent();

#if !CLR2      
			System.Runtime.Remoting.RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
#endif

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            if (LoginInfoAcquisition.Employee != null)
            {
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
                this._loginSectionCode = this._loginEmployee.BelongSectionCode;
            }

            //--- 導入システム判定
            this._introduceSystem = new Hashtable();

            //  整備有無判定
#if false		// USB ⇒ Company　へ変更 徳永S確認済み
			if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF) == PurchaseStatus.Contract ||     //契約済み
				LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF) == PurchaseStatus.Trial_Contract) //体験版契約済み
			{
				this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF, "整備");
			}

			//  鈑金有無判定
			if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK) == PurchaseStatus.Contract ||     //契約済み
				LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK) == PurchaseStatus.Trial_Contract) //体験版契約済み
			{
				this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK, "鈑金");
			}

			//  車販有無判定
			if (LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS) == PurchaseStatus.Contract ||     //契約済み
				LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS) == PurchaseStatus.Trial_Contract) //体験版契約済み
			{
				this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS, "車販");
			}
#else
            if (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF) == PurchaseStatus.Contract ||     //契約済み
                LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF) == PurchaseStatus.Trial_Contract) //体験版契約済み
            {
                this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF, "整備");
            }

            //  鈑金有無判定
            if (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK) == PurchaseStatus.Contract ||     //契約済み
                LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK) == PurchaseStatus.Trial_Contract) //体験版契約済み
            {
                this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK, "鈑金");
            }

            //  車販有無判定
            if (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS) == PurchaseStatus.Contract ||     //契約済み
                LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS) == PurchaseStatus.Trial_Contract) //体験版契約済み
            {
                this._introduceSystem.Add(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS, "車販");
            }
#endif
            // >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            // FIXME:テキスト出力…USBチェック
            PurchaseStatus purchaseStatus =
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (purchaseStatus == PurchaseStatus.Contract ||			// 契約済
                    purchaseStatus == PurchaseStatus.Trial_Contract)	// 体験版契約済
            {
                this._isOptTextOutPut = true;
            }
            else
            {
                this._isOptTextOutPut = false;
            }
            // <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            //--- アクセスクラスインスタンス化
            this._secInfoAcs = new SecInfoAcs();
            this._prtOutSetAcs = new PrtOutSetAcs();
            this._noMngSetAcs = new NoMngSetAcs();

            // 選択拠点種類のDefaultアイテムを作成します。
            this._arDefultSecKind = new ArrayList(2);

            SectionKind secKind1 = new SectionKind();
            secKind1.CtrlFuncName = "実績計上拠点";
            secKind1.CtrlFuncCode = (int)SecInfoAcs.CtrlFuncCode.ResultsAddUpSecCd;
            this._arDefultSecKind.Add(secKind1);

            SectionKind secKind2 = new SectionKind();
            secKind2.CtrlFuncName = "請求計上拠点";
            secKind2.CtrlFuncCode = (int)SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd;
            this._arDefultSecKind.Add(secKind2);

            // PDF削除リストテーブル作成
            this._delPDFList = new Hashtable();

            // 画面デザイン変更クラス
            SFANL07200UA.mControlScreenSkin = new ControlScreenSkin();
        }
        #endregion

        // ===============================================================================
        // 破棄
        // ===============================================================================
        #region Dispose
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        /// <br>Update Note: 2011/03/14 yangmj</br>
        /// <br>             回収予定表で、画面入力内容がXMLに保存し、
        /// <br> 　　　　　　次回起動時に設定した内容が反映される様にするの修正</br>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            //-----ADD 2011/03/14 ---------->>>>>
            // 選択している拠点を外部出力　※回収予定表で起動している場合のみ
            if (_dckauFlag)
            {
                SectionTreeHelper.ExportCheckedSectionCode(this.Section_UTree, true);
            }
            //-----ADD 2011/03/14 ----------<<<<<

            base.Dispose(disposing);
        }
        #endregion

        // ===============================================================================
        // Windowsフォームデザイナで生成されたコード
        // ===============================================================================
        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("15887006-b123-425f-864e-3a811a2c4619"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("fd30e023-a611-4cef-bd96-552b5157b8bd"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("15887006-b123-425f-864e-3a811a2c4619"), -1);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane2 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("14433859-0725-4ebd-a557-fdb6711dcbf4"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane2 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("8087aaa9-2b2f-45f4-a82f-93170cf47281"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("14433859-0725-4ebd-a557-fdb6711dcbf4"), -1);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane3 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("524f5fb4-ad59-49eb-97a6-66081c3c8354"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane3 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("7fabf8be-5362-446b-9bc9-d84e9a0750d3"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("524f5fb4-ad59-49eb-97a6-66081c3c8354"), -1);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("MainMenu_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Update_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pdf_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Change_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("NextPage_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Graph_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pdf_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Print_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Update_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Pdf_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("End_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginTitle_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("LoginName_LabelTool");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Extract_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Forms_PopupMenuTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("PDFSave_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("TextOutPut_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Graph_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Setup_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Update_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Guide_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Change_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("NextPage_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL07200UA));
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.AddUpCd_UOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tEdit_SectionCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_SectionCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.endRangeNameUltraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.endRangeUltraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.startRangeNameUltraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.startRangeUltraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.Section_UTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.System_UTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.StartNavigatorTree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.PdfHistory_Panel = new System.Windows.Forms.Panel();
            this.SelectExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.SFUKK06180U_Fill_Panel = new System.Windows.Forms.Panel();
            this.Main_TabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._SFANL07200UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL07200UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL07200UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL07200UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._SFANL07200UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow3 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.dockableWindow2 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.Main_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.TabControl_contextMenu = new System.Windows.Forms.ContextMenu();
            this.Close_menuItem = new System.Windows.Forms.MenuItem();
            this.tMemPos1 = new Broadleaf.Library.Windows.Forms.TMemPos(this.components);
            this.tRetKeyControl = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.uiSetControl = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.windowDockingArea3 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.windowDockingArea2 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.dockableWindow4 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this._SFANL07200UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._SFANL07200UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFANL07200UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpCd_UOptionSet)).BeginInit();
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endRangeNameUltraTextEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRangeNameUltraTextEditor)).BeginInit();
            this.ultraExplorerBarContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Section_UTree)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.System_UTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectExplorerBar)).BeginInit();
            this.SelectExplorerBar.SuspendLayout();
            this.SFUKK06180U_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_TabControl)).BeginInit();
            this.Main_TabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            this._SFANL07200UAAutoHideControl.SuspendLayout();
            this.dockableWindow1.SuspendLayout();
            this.dockableWindow2.SuspendLayout();
            this.dockableWindow4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AddUpCd_UOptionSet);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(201, 44);
            this.ultraExplorerBarContainerControl1.TabIndex = 0;
            this.ultraExplorerBarContainerControl1.Visible = false;
            // 
            // AddUpCd_UOptionSet
            // 
            this.AddUpCd_UOptionSet.BackColor = System.Drawing.Color.Transparent;
            this.AddUpCd_UOptionSet.BackColorInternal = System.Drawing.Color.Transparent;
            this.AddUpCd_UOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.AddUpCd_UOptionSet.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.AddUpCd_UOptionSet.Location = new System.Drawing.Point(2, 4);
            this.AddUpCd_UOptionSet.Name = "AddUpCd_UOptionSet";
            this.AddUpCd_UOptionSet.Size = new System.Drawing.Size(224, 35);
            this.AddUpCd_UOptionSet.TabIndex = 0;
            this.AddUpCd_UOptionSet.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.AddUpCd_UOptionSet.ValueChanged += new System.EventHandler(this.AddUpCd_UOptionSet_ValueChanged);
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tEdit_SectionCode_Ed);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tEdit_SectionCode_St);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.endRangeNameUltraTextEditor);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.endRangeUltraLabel);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.startRangeNameUltraTextEditor);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.startRangeUltraLabel);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(28, 146);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(201, 50);
            this.ultraExplorerBarContainerControl4.TabIndex = 3;
            // 
            // tEdit_SectionCode_Ed
            // 
            this.tEdit_SectionCode_Ed.ActiveAppearance = appearance9;
            this.tEdit_SectionCode_Ed.AutoSelect = true;
            this.tEdit_SectionCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tEdit_SectionCode_Ed.DataText = "99";
            this.tEdit_SectionCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SectionCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCode_Ed.Location = new System.Drawing.Point(46, 26);
            this.tEdit_SectionCode_Ed.MaxLength = 12;
            this.tEdit_SectionCode_Ed.Name = "tEdit_SectionCode_Ed";
            this.tEdit_SectionCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tEdit_SectionCode_Ed.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCode_Ed.TabIndex = 2;
            this.tEdit_SectionCode_Ed.Text = "99";
            this.tEdit_SectionCode_Ed.Leave += new System.EventHandler(this.endRangeTNedit_Leave);
            // 
            // tEdit_SectionCode_St
            // 
            this.tEdit_SectionCode_St.ActiveAppearance = appearance10;
            this.tEdit_SectionCode_St.AutoSelect = true;
            this.tEdit_SectionCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tEdit_SectionCode_St.DataText = "99";
            this.tEdit_SectionCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SectionCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCode_St.Location = new System.Drawing.Point(46, 0);
            this.tEdit_SectionCode_St.MaxLength = 12;
            this.tEdit_SectionCode_St.Name = "tEdit_SectionCode_St";
            this.tEdit_SectionCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tEdit_SectionCode_St.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCode_St.TabIndex = 1;
            this.tEdit_SectionCode_St.Text = "99";
            this.tEdit_SectionCode_St.Leave += new System.EventHandler(this.startRangeTNedit_Leave);
            // 
            // endRangeNameUltraTextEditor
            // 
            this.endRangeNameUltraTextEditor.Enabled = false;
            this.endRangeNameUltraTextEditor.Location = new System.Drawing.Point(80, 26);
            this.endRangeNameUltraTextEditor.Name = "endRangeNameUltraTextEditor";
            this.endRangeNameUltraTextEditor.Size = new System.Drawing.Size(104, 24);
            this.endRangeNameUltraTextEditor.TabIndex = 5;
            // 
            // endRangeUltraLabel
            // 
            this.endRangeUltraLabel.Location = new System.Drawing.Point(0, 30);
            this.endRangeUltraLabel.Name = "endRangeUltraLabel";
            this.endRangeUltraLabel.Size = new System.Drawing.Size(40, 20);
            this.endRangeUltraLabel.TabIndex = 3;
            this.endRangeUltraLabel.Text = "終了";
            // 
            // startRangeNameUltraTextEditor
            // 
            this.startRangeNameUltraTextEditor.Enabled = false;
            this.startRangeNameUltraTextEditor.Location = new System.Drawing.Point(80, 0);
            this.startRangeNameUltraTextEditor.Name = "startRangeNameUltraTextEditor";
            this.startRangeNameUltraTextEditor.Size = new System.Drawing.Size(104, 24);
            this.startRangeNameUltraTextEditor.TabIndex = 2;
            // 
            // startRangeUltraLabel
            // 
            this.startRangeUltraLabel.Location = new System.Drawing.Point(0, 4);
            this.startRangeUltraLabel.Name = "startRangeUltraLabel";
            this.startRangeUltraLabel.Size = new System.Drawing.Size(40, 20);
            this.startRangeUltraLabel.TabIndex = 0;
            this.startRangeUltraLabel.Text = "開始";
            // 
            // ultraExplorerBarContainerControl2
            // 
            this.ultraExplorerBarContainerControl2.Controls.Add(this.Section_UTree);
            this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(28, 249);
            this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
            this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(184, 0);
            this.ultraExplorerBarContainerControl2.TabIndex = 1;
            this.ultraExplorerBarContainerControl2.Visible = false;
            // 
            // Section_UTree
            // 
            this.Section_UTree.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Section_UTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Section_UTree.Location = new System.Drawing.Point(0, 0);
            this.Section_UTree.Name = "Section_UTree";
            this.Section_UTree.Size = new System.Drawing.Size(184, 0);
            this.Section_UTree.TabIndex = 3;
            this.Section_UTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Section_UTree_AfterCheck);
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.System_UTree);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(201, 71);
            this.ultraExplorerBarContainerControl3.TabIndex = 2;
            this.ultraExplorerBarContainerControl3.Visible = false;
            // 
            // System_UTree
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.System_UTree.Appearance = appearance2;
            this.System_UTree.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.System_UTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.System_UTree.Location = new System.Drawing.Point(0, 0);
            this.System_UTree.Name = "System_UTree";
            this.System_UTree.Size = new System.Drawing.Size(201, 71);
            this.System_UTree.TabIndex = 0;
            this.System_UTree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.System_UTree_AfterCheck);
            // 
            // StartNavigatorTree
            // 
            this.StartNavigatorTree.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.StartNavigatorTree.Location = new System.Drawing.Point(0, 27);
            this.StartNavigatorTree.Name = "StartNavigatorTree";
            this.StartNavigatorTree.Size = new System.Drawing.Size(250, 621);
            this.StartNavigatorTree.TabIndex = 0;
            this.StartNavigatorTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartNavigatorTree_MouseDown);
            this.StartNavigatorTree.DoubleClick += new System.EventHandler(this.StartNavigatorTree_DoubleClick);
            // 
            // PdfHistory_Panel
            // 
            this.PdfHistory_Panel.BackColor = System.Drawing.Color.White;
            this.PdfHistory_Panel.Location = new System.Drawing.Point(0, 27);
            this.PdfHistory_Panel.Name = "PdfHistory_Panel";
            this.PdfHistory_Panel.Size = new System.Drawing.Size(250, 621);
            this.PdfHistory_Panel.TabIndex = 0;
            // 
            // SelectExplorerBar
            // 
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl2);
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.SelectExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup1.Key = "AddUpCdList";
            ultraExplorerBarGroup1.Settings.ContainerHeight = 44;
            ultraExplorerBarGroup1.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup1.Text = "計上拠点を選択します";
            ultraExplorerBarGroup1.Visible = false;
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup2.Key = "SectionRange";
            ultraExplorerBarGroup2.Settings.ContainerHeight = 50;
            ultraExplorerBarGroup2.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup2.Text = "出力拠点の範囲を指定します";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl2;
            ultraExplorerBarGroup3.Expanded = false;
            ultraExplorerBarGroup3.Key = "SectionList";
            ultraExplorerBarGroup3.Settings.ContainerHeight = 316;
            ultraExplorerBarGroup3.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup3.Text = "出力対象拠点を選択します";
            ultraExplorerBarGroup3.Visible = false;
            ultraExplorerBarGroup4.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup4.Key = "SystemList";
            ultraExplorerBarGroup4.Settings.ContainerHeight = 71;
            ultraExplorerBarGroup4.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup4.Text = "システムを選択します";
            ultraExplorerBarGroup4.Visible = false;
            this.SelectExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3,
            ultraExplorerBarGroup4});
            this.SelectExplorerBar.GroupSpacing = 5;
            this.SelectExplorerBar.Location = new System.Drawing.Point(0, 27);
            this.SelectExplorerBar.Name = "SelectExplorerBar";
            this.SelectExplorerBar.ShowDefaultContextMenu = false;
            this.SelectExplorerBar.Size = new System.Drawing.Size(250, 621);
            this.SelectExplorerBar.TabIndex = 0;
            this.SelectExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.XPExplorerBar;
            // 
            // SFUKK06180U_Fill_Panel
            // 
            this.SFUKK06180U_Fill_Panel.Controls.Add(this.Main_TabControl);
            this.SFUKK06180U_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.SFUKK06180U_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SFUKK06180U_Fill_Panel.Location = new System.Drawing.Point(22, 63);
            this.SFUKK06180U_Fill_Panel.Name = "SFUKK06180U_Fill_Panel";
            this.SFUKK06180U_Fill_Panel.Size = new System.Drawing.Size(994, 648);
            this.SFUKK06180U_Fill_Panel.TabIndex = 0;
            // 
            // Main_TabControl
            // 
            this.Main_TabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Main_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TabControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Main_TabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.Main_TabControl.Location = new System.Drawing.Point(0, 0);
            this.Main_TabControl.Name = "Main_TabControl";
            this.Main_TabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_TabControl.Size = new System.Drawing.Size(994, 648);
            this.Main_TabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.Main_TabControl.TabIndex = 0;
            this.Main_TabControl.TabPadding = new System.Drawing.Size(3, 3);
            this.Main_TabControl.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Main_TabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.Main_TabControl.TabMoved += new Infragistics.Win.UltraWinTabControl.TabMovedEventHandler(this.Main_TabControl_TabMoved);
            this.Main_TabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.Main_TabControl_SelectedTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(1, 20);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(992, 627);
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            dockAreaPane1.DockedBefore = new System.Guid("14433859-0725-4ebd-a557-fdb6711dcbf4");
            dockableControlPane1.Control = this.StartNavigatorTree;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(250, -1);
            dockableControlPane1.Key = "StartNavigator";
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(12, 156, 250, 274);
            dockableControlPane1.Pinned = false;
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance3.FontData.SizeInPoints = 10F;
            dockableControlPane1.Settings.Appearance = appearance3;
            dockableControlPane1.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockableControlPane1.Text = "起動ナビゲータ";
            dockableControlPane1.ToolTipCaption = "出力する帳票を選択します。";
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(250, 648);
            dockAreaPane2.DockedBefore = new System.Guid("524f5fb4-ad59-49eb-97a6-66081c3c8354");
            dockableControlPane2.Control = this.PdfHistory_Panel;
            dockableControlPane2.FlyoutSize = new System.Drawing.Size(250, -1);
            dockableControlPane2.Key = "PdfHistory";
            dockableControlPane2.OriginalControlBounds = new System.Drawing.Rectangle(21, 14, 250, 354);
            dockableControlPane2.Pinned = false;
            dockableControlPane2.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance4.FontData.SizeInPoints = 10F;
            dockableControlPane2.Settings.Appearance = appearance4;
            dockableControlPane2.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane2.Size = new System.Drawing.Size(100, 100);
            dockableControlPane2.Text = "出力済み帳票検索";
            dockableControlPane2.ToolTipCaption = "過去に出力した帳票の検索を行います。";
            dockAreaPane2.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane2});
            dockAreaPane2.Size = new System.Drawing.Size(250, 648);
            dockableControlPane3.Control = this.SelectExplorerBar;
            dockableControlPane3.FlyoutSize = new System.Drawing.Size(250, -1);
            dockableControlPane3.Key = "SelectCondition";
            dockableControlPane3.OriginalControlBounds = new System.Drawing.Rectangle(17, 7, 250, 621);
            dockableControlPane3.Pinned = false;
            dockableControlPane3.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance5.FontData.SizeInPoints = 10F;
            dockableControlPane3.Settings.Appearance = appearance5;
            dockableControlPane3.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane3.Size = new System.Drawing.Size(100, 100);
            dockableControlPane3.Text = "出力条件選択";
            dockableControlPane3.ToolTipCaption = "帳票の出力条件を選択します。";
            dockAreaPane3.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane3});
            dockAreaPane3.Size = new System.Drawing.Size(250, 648);
            this.Main_DockManager.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1,
            dockAreaPane2,
            dockAreaPane3});
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.LayoutStyle = Infragistics.Win.UltraWinDock.DockAreaLayoutStyle.FillContainer;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            this.Main_DockManager.PaneDisplayed += new Infragistics.Win.UltraWinDock.PaneDisplayedEventHandler(this.Main_DockManager_PaneDisplayed);
            // 
            // _SFANL07200UAUnpinnedTabAreaLeft
            // 
            this._SFANL07200UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._SFANL07200UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL07200UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 63);
            this._SFANL07200UAUnpinnedTabAreaLeft.Name = "_SFANL07200UAUnpinnedTabAreaLeft";
            this._SFANL07200UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._SFANL07200UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(22, 648);
            this._SFANL07200UAUnpinnedTabAreaLeft.TabIndex = 5;
            // 
            // _SFANL07200UAUnpinnedTabAreaRight
            // 
            this._SFANL07200UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._SFANL07200UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL07200UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1016, 63);
            this._SFANL07200UAUnpinnedTabAreaRight.Name = "_SFANL07200UAUnpinnedTabAreaRight";
            this._SFANL07200UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._SFANL07200UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 648);
            this._SFANL07200UAUnpinnedTabAreaRight.TabIndex = 6;
            // 
            // _SFANL07200UAUnpinnedTabAreaTop
            // 
            this._SFANL07200UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._SFANL07200UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL07200UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(22, 63);
            this._SFANL07200UAUnpinnedTabAreaTop.Name = "_SFANL07200UAUnpinnedTabAreaTop";
            this._SFANL07200UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._SFANL07200UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(994, 0);
            this._SFANL07200UAUnpinnedTabAreaTop.TabIndex = 7;
            // 
            // _SFANL07200UAUnpinnedTabAreaBottom
            // 
            this._SFANL07200UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._SFANL07200UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL07200UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(22, 711);
            this._SFANL07200UAUnpinnedTabAreaBottom.Name = "_SFANL07200UAUnpinnedTabAreaBottom";
            this._SFANL07200UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._SFANL07200UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(994, 0);
            this._SFANL07200UAUnpinnedTabAreaBottom.TabIndex = 8;
            // 
            // _SFANL07200UAAutoHideControl
            // 
            this._SFANL07200UAAutoHideControl.Controls.Add(this.dockableWindow3);
            this._SFANL07200UAAutoHideControl.Controls.Add(this.dockableWindow2);
            this._SFANL07200UAAutoHideControl.Controls.Add(this.dockableWindow1);
            this._SFANL07200UAAutoHideControl.Controls.Add(this.dockableWindow4);
            this._SFANL07200UAAutoHideControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._SFANL07200UAAutoHideControl.Location = new System.Drawing.Point(22, 63);
            this._SFANL07200UAAutoHideControl.Name = "_SFANL07200UAAutoHideControl";
            this._SFANL07200UAAutoHideControl.Owner = this.Main_DockManager;
            this._SFANL07200UAAutoHideControl.Size = new System.Drawing.Size(55, 648);
            this._SFANL07200UAAutoHideControl.TabIndex = 9;
            // 
            // dockableWindow3
            // 
            this.dockableWindow3.Location = new System.Drawing.Point(-10000, 0);
            this.dockableWindow3.Name = "dockableWindow3";
            this.dockableWindow3.Owner = this.Main_DockManager;
            this.dockableWindow3.Size = new System.Drawing.Size(250, 648);
            this.dockableWindow3.TabIndex = 36;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.PdfHistory_Panel);
            this.dockableWindow1.Location = new System.Drawing.Point(-10000, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.Main_DockManager;
            this.dockableWindow1.Size = new System.Drawing.Size(250, 648);
            this.dockableWindow1.TabIndex = 37;
            // 
            // dockableWindow2
            // 
            this.dockableWindow2.Controls.Add(this.StartNavigatorTree);
            this.dockableWindow2.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow2.Name = "dockableWindow2";
            this.dockableWindow2.Owner = this.Main_DockManager;
            this.dockableWindow2.Size = new System.Drawing.Size(250, 648);
            this.dockableWindow2.TabIndex = 36;
            // 
            // Main_StatusBar
            // 
            this.Main_StatusBar.Location = new System.Drawing.Point(0, 711);
            this.Main_StatusBar.Name = "Main_StatusBar";
            appearance7.TextHAlignAsString = "Center";
            this.Main_StatusBar.PanelAppearance = appearance7;
            ultraStatusPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            ultraStatusPanel1.Key = "Text";
            ultraStatusPanel1.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel2.Key = "Date";
            ultraStatusPanel2.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Date;
            ultraStatusPanel2.Width = 90;
            ultraStatusPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            ultraStatusPanel3.Key = "Time";
            ultraStatusPanel3.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.Time;
            ultraStatusPanel3.Width = 50;
            this.Main_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.Main_StatusBar.Size = new System.Drawing.Size(1016, 23);
            this.Main_StatusBar.TabIndex = 15;
            this.Main_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // TabControl_contextMenu
            // 
            this.TabControl_contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Close_menuItem});
            // 
            // Close_menuItem
            // 
            this.Close_menuItem.Index = 0;
            this.Close_menuItem.Text = "閉じる(&C)";
            this.Close_menuItem.Click += new System.EventHandler(this.Close_menuItem_Click);
            // 
            // tMemPos1
            // 
            this.tMemPos1.OwnerForm = this;
            // 
            // tRetKeyControl
            // 
            this.tRetKeyControl.OwnerForm = this;
            this.tRetKeyControl.TabEnable = false;
            this.tRetKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // tArrowKeyControl
            // 
            this.tArrowKeyControl.OwnerForm = this;
            this.tArrowKeyControl.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl_ChangeFocus);
            // 
            // uiSetControl
            // 
            this.uiSetControl.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl.OwnerForm = this;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(22, 63);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.Main_DockManager;
            this.windowDockingArea1.Size = new System.Drawing.Size(255, 648);
            this.windowDockingArea1.TabIndex = 16;
            // 
            // windowDockingArea3
            // 
            this.windowDockingArea3.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea3.Location = new System.Drawing.Point(22, 63);
            this.windowDockingArea3.Name = "windowDockingArea3";
            this.windowDockingArea3.Owner = this.Main_DockManager;
            this.windowDockingArea3.Size = new System.Drawing.Size(255, 648);
            this.windowDockingArea3.TabIndex = 26;
            // 
            // windowDockingArea2
            // 
            this.windowDockingArea2.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea2.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea2.Location = new System.Drawing.Point(277, 63);
            this.windowDockingArea2.Name = "windowDockingArea2";
            this.windowDockingArea2.Owner = this.Main_DockManager;
            this.windowDockingArea2.Size = new System.Drawing.Size(255, 648);
            this.windowDockingArea2.TabIndex = 31;
            // 
            // dockableWindow4
            // 
            this.dockableWindow4.Controls.Add(this.SelectExplorerBar);
            this.dockableWindow4.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow4.Name = "dockableWindow4";
            this.dockableWindow4.Owner = this.Main_DockManager;
            this.dockableWindow4.Size = new System.Drawing.Size(0, 0);
            this.dockableWindow4.TabIndex = 38;
            // 
            // _SFANL07200UA_Toolbars_Dock_Area_Left
            // 
            this._SFANL07200UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL07200UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFANL07200UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFANL07200UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL07200UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._SFANL07200UA_Toolbars_Dock_Area_Left.Name = "_SFANL07200UA_Toolbars_Dock_Area_Left";
            this._SFANL07200UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 648);
            this._SFANL07200UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            labelTool1.InstanceProps.Spring = Infragistics.Win.DefaultableBoolean.True;
            labelTool2.InstanceProps.Width = 103;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            labelTool1,
            labelTool2,
            labelTool3});
            ultraToolbar1.Text = "メインメニュー";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool11,
            buttonTool12});
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            buttonTool13.SharedProps.Caption = "終了(F1)";
            buttonTool13.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool13.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F1;
            buttonTool14.SharedProps.Caption = "印刷(F10)";
            buttonTool14.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool14.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F10;
            buttonTool15.SharedProps.Caption = "PDF表示(F11)";
            buttonTool15.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool15.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F11;
            popupMenuTool3.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool3.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            buttonTool19.InstanceProps.IsFirstInGroup = true;
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool16,
            buttonTool17,
            buttonTool18,
            buttonTool19});
            labelTool5.SharedProps.Caption = "ログイン担当者";
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Bottom";
            labelTool6.SharedProps.AppearancesSmall.Appearance = appearance6;
            labelTool6.SharedProps.Width = 150;
            buttonTool20.SharedProps.Caption = "抽出(&E)";
            buttonTool20.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            popupMenuTool4.SharedProps.Caption = "ウィンドウ(&W)";
            popupMenuTool5.SharedProps.Caption = "タブ切替(&J)";
            popupMenuTool5.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            popupMenuTool5.SharedProps.ToolTipText = "画面を切り替えます。";
            buttonTool21.SharedProps.Caption = "PDF履歴保存(F12)";
            buttonTool21.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool21.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F12;
            buttonTool22.SharedProps.Caption = "テキスト出力(&O)";
            buttonTool22.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool22.SharedProps.Enabled = false;
            buttonTool23.SharedProps.Caption = "グラフ表示(&G)";
            buttonTool23.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool23.SharedProps.Visible = false;
            buttonTool24.SharedProps.Caption = "設定(&O)";
            buttonTool24.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool24.SharedProps.Visible = false;
            buttonTool25.SharedProps.Caption = "確定(&A)";
            buttonTool25.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool25.SharedProps.Enabled = false;
            buttonTool25.SharedProps.Visible = false;
            buttonTool26.SharedProps.Caption = "ガイド(F5)";
            buttonTool26.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool26.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F5;
            buttonTool26.SharedProps.Visible = false;
            buttonTool27.SharedProps.Caption = "切替(F2)";
            buttonTool27.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool27.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F2;
            buttonTool28.SharedProps.Caption = "次頁(F3)";
            buttonTool28.SharedProps.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            buttonTool28.SharedProps.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool13,
            buttonTool14,
            buttonTool15,
            popupMenuTool3,
            labelTool4,
            labelTool5,
            labelTool6,
            buttonTool20,
            popupMenuTool4,
            popupMenuTool5,
            buttonTool21,
            buttonTool22,
            buttonTool23,
            buttonTool24,
            buttonTool25,
            buttonTool26,
            buttonTool27,
            buttonTool28});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _SFANL07200UA_Toolbars_Dock_Area_Right
            // 
            this._SFANL07200UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL07200UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFANL07200UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFANL07200UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL07200UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1016, 63);
            this._SFANL07200UA_Toolbars_Dock_Area_Right.Name = "_SFANL07200UA_Toolbars_Dock_Area_Right";
            this._SFANL07200UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 648);
            this._SFANL07200UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFANL07200UA_Toolbars_Dock_Area_Top
            // 
            this._SFANL07200UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL07200UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFANL07200UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFANL07200UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL07200UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFANL07200UA_Toolbars_Dock_Area_Top.Name = "_SFANL07200UA_Toolbars_Dock_Area_Top";
            this._SFANL07200UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1016, 63);
            this._SFANL07200UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFANL07200UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 711);
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.Name = "_SFANL07200UA_Toolbars_Dock_Area_Bottom";
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1016, 0);
            this._SFANL07200UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // SFANL07200UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this._SFANL07200UAAutoHideControl);
            this.Controls.Add(this.SFUKK06180U_Fill_Panel);
            this.Controls.Add(this.windowDockingArea2);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this.windowDockingArea3);
            this.Controls.Add(this._SFANL07200UAUnpinnedTabAreaTop);
            this.Controls.Add(this._SFANL07200UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._SFANL07200UAUnpinnedTabAreaRight);
            this.Controls.Add(this._SFANL07200UAUnpinnedTabAreaLeft);
            this.Controls.Add(this._SFANL07200UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFANL07200UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFANL07200UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFANL07200UA_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.Main_StatusBar);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SFANL07200UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "帳票";
            this.Load += new System.EventHandler(this.SFANL07200UA_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SFANL07200UA_FormClosed);
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddUpCd_UOptionSet)).EndInit();
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endRangeNameUltraTextEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRangeNameUltraTextEditor)).EndInit();
            this.ultraExplorerBarContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Section_UTree)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.System_UTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNavigatorTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectExplorerBar)).EndInit();
            this.SelectExplorerBar.ResumeLayout(false);
            this.SFUKK06180U_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_TabControl)).EndInit();
            this.Main_TabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            this._SFANL07200UAAutoHideControl.ResumeLayout(false);
            this.dockableWindow1.ResumeLayout(false);
            this.dockableWindow2.ResumeLayout(false);
            this.dockableWindow4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        // ===============================================================================
        // デリゲート宣言
        // ===============================================================================
        #region デリゲート宣言
        /// <summary>計上拠点選択イベント用デリゲート</summary>
        /// <param name="checkState">選択計上拠点(1:実績 2:請求)</param>
        private delegate void CheckedAddUpEventHandler(int AddUpCd);

        /// <summary>拠点選択イベント用デリゲート</summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="checkState">チェック状態</param>
        private delegate void CheckedSectionEventHandler(string sectionCode, CheckState checkState);

        /// <summary>システム選択イベント用デリゲート</summary>
        /// <param name="sectionCode">システムコード</param>
        /// <param name="checkState">チェック状態</param>
        private delegate void CheckedSystemEventHandler(int sysCode, CheckState checkState);

        /// <summary>初期拠点設定用デリゲート</summary>
        /// <param name="sectionCodeLst">拠点コードリスト</param>
        private delegate void InitSelectSectionEventHandler(string[] sectionCodeLst);
        #endregion

        // ===============================================================================
        // プライベート変数
        // ===============================================================================
        #region private member
        internal static string[] _parameter;																				// 起動パラメータ
        private bool _navigaterMenuMode = false;						// 起動ナビゲーターモード
        private string _enterpriseCode = "";
        private Employee _loginEmployee = null;
        private string _loginSectionCode = "";								// ログイン拠点コード


        private Hashtable _formControlInfoTable = new Hashtable();
        private Hashtable _introduceSystem = null;							// 導入システム
        private Hashtable _setPdfKeyList = new Hashtable();	// 出力履歴検索用KEYリスト(KEY:帳票KEY, Value:帳票DLL)

        private int[] _introduceSystemCdLst = null;							// 導入システムコードリスト

        private Point _lastMouseDown;
        private static System.Windows.Forms.Form _form = null;

        private bool _isOptSection = false;						// 拠点オプションフラグ	
        private bool _isMainOfficeFunc = false;						// 本社機能有無
        private bool _isOptTextOutPut = false;													// テキスト出力オプションフラグ

        private SortedList _secInfoLst = null;							// 拠点情報リスト
        private SecInfoAcs _secInfoAcs = null;							// 拠点情報取得アクセスクラス

        private bool _isEvent = false;
        private bool _secNodeCheckEvent = false;						// 拠点選択イベント処理フラグ				
        private bool _sysNodeCheckEvent = false;						// システム選択イベント処理フラグ

        private bool _isDefaultSectionSelect = false;						// デフォルト拠点選択表示フラグ
        private bool _isDefaultSystemSelect = false;						// デフォルトシステム選択表示フラグ

        private SFANL06101UA _pdfHistorySerchForm = null;							// PDF履歴検索画面

#if false
		private CheckedAddUpEventHandler _checkedAddUpEvent     = null;							// 計上拠点選択イベント
		private CheckedSectionEventHandler _checkedSectionEvent = null;							// 拠点選択イベント
		private CheckedSystemEventHandler _checkedSystemEvent   = null;							// システム選択イベント
		private InitSelectSectionEventHandler _initSelectSectionEvent = null;				// 初期設定拠点イベント
#endif
        private PrtOutSetAcs _prtOutSetAcs = null;							// 帳票出力設定アクセスクラス
        private PrtOutSet _prtOutSet = null;							// 帳票出力設定データクラス
        private ArrayList _arDefultSecKind = null;							// 初期選択拠点種類リスト
        private MemoryStream _dockMemoryStream = null;							// DocManager初期保存情報
        private NoMngSetAcs _noMngSetAcs = null;																		// 番号タイプ管理マスタ

        private Hashtable _delPDFList = null;							// 削除PDF格納リスト

        // >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        private SortedList<int, string> _slDefSoftWareCode = null;							// デフォルト選択可能システム
        // <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

        private SFANL07200UE _userSetupFrm = null;																	// ユーザー設定画面
        internal static ControlScreenSkin mControlScreenSkin = null;												// 画面スキン変更部品 

        // --- ADD 譚洪 2021/01/04 PMKOBETSU-4109の対応 ------>>>>
        private OperationHistoryLog operationHistoryLog = null;
        private ClientLogTextOut clientLogTextOut = null;
        // ログデータ種別区分コード：2（メニューログ出力）
        private const int MenuLog = 2;
        private const int OperationCode = 0;
        private const string DateMessage = "{0},{1},{2},{3},";
        private const string MethodName = "StartNavigatorTree_DoubleClick";
        private const string ErrMessageInit = "ログ出力部品初期化エラー";
        private const string ErrMessage = ":起動PGログ出力エラー";
        // --- ADD 譚洪 2021/01/04 PMKOBETSU-4109の対応 ------<<<<

        // >>>>> 2008.09.05 T.Kudoh ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        /// <summary>操作権限の制御オブジェクトのマップ</summary>
        /// <remarks>キー：プログラムID</remarks>
        private readonly OperationAuthorityControllableMap<ReportController>
            _myOpeCtrlMap = new OperationAuthorityControllableMap<ReportController>();
        /// <summary>
        /// 操作権限の制御オブジェクトのマップを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクトのマップ</value>
        private OperationAuthorityControllableMap<ReportController> MyOpeCtrlMap
        {
            get { return _myOpeCtrlMap; }
        }
        // <<<<< 2008.09.05 T.Kudoh ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

        private bool _dckauFlag = false; //回収予定表  //ADD 2011/03/14
        #endregion

        // ===============================================================================
        // プライベート定数
        // ===============================================================================
        #region private constant
        private const string CT_PGID = "SFANL07200U";
        private const string MAIN_TITLE = "帳票";
        private const string NAVIGATORTREE_XML = "SFANL07200U_Navigator.Dat";

        // ツールバーツールキー設定
        private const string TOOLBAR_LOGINLABEL_TITLE = "LoginTitle_LabelTool";
        private const string TOOLBAR_LOGINNAMELABEL_KEY = "LoginName_LabelTool";
        private const string TOOLBAR_WINDOW_KEY = "Window_PopupMenuTool";
        private const string TOOLBAR_FORMS_KEY = "Forms_PopupMenuTool";
        private const string TOOLBAR_RESETBUTTON_KEY = "Reset_ButtonTool";

        private const string TOOLBAR_ENDBUTTON_KEY = "End_ButtonTool";
        private const string TOOLBAR_PRINTBUTTON_KEY = "Print_ButtonTool";
        private const string TOOLBAR_EXTRABUTTON_KEY = "Extract_ButtonTool";
        private const string TOOLBAR_PDFBUTTON_KEY = "Pdf_ButtonTool";
        private const string TOOLBAR_PDFSAVEBUTTON_KEY = "PDFSave_ButtonTool";
        private const string TOOLBAR_TEXTOUTPUTBUTTON_KEY = "TextOutPut_ButtonTool";		// 2006.09.01 Y.Sasaki ADD
        private const string TOOLBAR_UPDATEBUTTON_KEY = "Update_ButtonTool";		// 2008.11.12 Y.Shinobu ADD
        private const string TOOLBAR_GRAPHBUTTON_KEY = "Graph_ButtonTool";
        private const string TOOLBAR_SETUPBUTTON_KEY = "Setup_ButtonTool";

        // ---ADD 2010/08/16-------------------->>>
        // ガイド
        private const string TOOLBAR_GUIDEBUTTON_KEY = "Guide_ButtonTool";
        // 切替
        private const string TOOLBAR_CHANGEBUTTON_KEY = "Change_ButtonTool";
        // 次頁
        private const string TOOLBAR_NEXTPAGEBUTTON_KEY = "NextPage_ButtonTool";
        // ---ADD 2010/08/16--------------------<<<

        // ドックマネージャーキー設定
        private const string DOCKMANAGER_NAVIGATOR_KEY = "StartNavigator";
        private const string DOCKMANAGER_SELECTCONDITION_KEY = "SelectCondition";
        private const string DOCKMANAGER_PDFHISTORTY_KEY = "PdfHistory";

        // エクスプローラーバーキー設定
        private const string EXPLORERBAR_ADDUPCDLIST = "AddUpCdList";
        private const string EXPLORERBAR_SECTIONRANGE = "SectionRange";              // 2008.09.09 T.Kudoh ADD
        private const string EXPLORERBAR_SECTIONLIST = "SectionList";
        private const string EXPLORERBAR_SYSTEMLIST = "SystemList";

        // ビューフォーム用追加キー情報(対象アセンブリ_VIEWR)
        private const string TAB_VIEWFORM_ADDKEY = "_VIWER";

        // チャートビューフォーム用追加キー情報(対象アセンブリ_CHART)
        private const string TAB_CHARTVIEWFORM_ADDKEY = "_CHART";

        // 全社拠点コード
        private const string CT_AllSectionCode = "0";

        // 拠点選択種類カラム初期タイトル
        private const string CT_EXPLORERBAR_ADDUPCDLIST_TITLE = "計上拠点を選択します。";

        // 全拠点コード
        private const string CT_AllCtrlFuncSecCode = "000000";	// 2006.09.26 Y.Sasaki ADD
        // >>>>> 2008.09.05 T.Kudoh ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        private const string CT_AllCtrlFuncSecName = "全社";
        private const string SECTION_CODE_FORMAT = "00";

        // 拠点コードの範囲
        private const string DEFAULT_START_SECTION_NAME = "最初から";
        private const string DEFAULT_END_SECTION_NAME = "最後まで";
        private const int MIN_SECTION_CODE = 1;
        private const int MAX_SECTION_CODE = 99;
        // <<<<< 2008.09.05 T.Kudoh ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        #endregion

        // ===============================================================================
        // プライベート列挙型
        // ===============================================================================
        #region private enum
        /// <summary>印刷モード</summary>
        private enum emPrintMode : int
        {
            /// <summary>印刷</summary>
            emPrinter = 1,
            /// <summary>ＰＤＦ</summary>
            emPDF = 2,
            /// <summary>印刷＆ＰＤＦ</summary>
            emPrinterAndPDF = 3
        }
        #endregion

        // ===============================================================================
        // メイン
        // ===============================================================================
        #region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            try
            {
                string msg = "";
                _parameter = args;
                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
                if (status == 0)
                {
                    // オンライン状態判定
                    if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
                    {
                        // オフライン情報
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, CT_PGID,
                            "オフライン状態で本機能はご使用できません。", 0, MessageBoxButtons.OK);
                    }
                    else
                    {
                        System.Windows.Forms.Application.EnableVisualStyles();
                        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                        _form = new SFANL07200UA();
                        System.Windows.Forms.Application.Run(_form);
                    }
                }
                if (status != 0) TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, CT_PGID, msg, 0, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, CT_PGID, ex.Message, -1, MessageBoxButtons.OK);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">メッセージ</param>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
            //従業員ログオフのメッセージを表示
            if (_form != null) TMsgDisp.Show(_form.Owner, emErrorLevel.ERR_LEVEL_INFO, "SFUKK06180U", e.ToString(), 0, MessageBoxButtons.OK);
            else TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFUKK06180U", e.ToString(), 0, MessageBoxButtons.OK);
            //アプリケーション終了
            System.Windows.Forms.Application.Exit();
        }
        #endregion

        // ===============================================================================
        // デリゲートイベント
        // ===============================================================================
        #region delegateEvent
        private void ParentToolbarSettingEvent(object sender)
        {
            this.ToolBarSetting(sender);
        }

        // --- 2010/08/16 ---------->>>>>
        private void ParentToolbarGuideSettingEvent(bool enabled)
        {
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
            if (buttonTool != null)
            {
                buttonTool.SharedProps.Enabled = enabled;
            }
        }
        // --- 2010/08/16 ----------<<<<<
        #endregion

        // ===============================================================================
        // 内部メソッド
        // ===============================================================================
        #region private method

        #region ◆　初期設定系データREAD処理
        /// <summary>
        /// 初期設定系データREAD処理
        /// </summary>
        /// <returns></returns>
        /// <br>Note       : 初期設定系のデータ読込処理を行います。
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.27</br>
        private int InitialSettingDBRead(out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                message = "帳票設定データの読込に失敗しました。";

                // 帳票設定データREAD
                status = this._prtOutSetAcs.Read(out this._prtOutSet, this._enterpriseCode, this._loginSectionCode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            message = String.Format("拠点コード：[0]", this._loginSectionCode) + "\n\r" + "帳票出力設定を行ってください。";
                            break;
                        }
                    default:
                        message = "帳票設定データの読込に失敗しました。";
                        break;
                }

                // 番号タイプ管理マスタREAD
                message = "番号タイプ管理マスタの読込に失敗しました。";

                ArrayList retNoTypMngList;
                status = this._noMngSetAcs.Search(out retNoTypMngList, LoginInfoAcquisition.EnterpriseCode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            NumberControl.NoTypeMngList = retNoTypMngList.ToArray(typeof(NoTypeMng)) as NoTypeMng[];
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                message += "\n\r" + ex.Message;
            }


            return status;
        }
        #endregion

        #region ◆　起動ナビゲータツリー情報構築処理
        /// <summary>
        /// ツリー情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツリー情報を構築します。
        ///					（２階層目の表示非表示チェック、３階層目のカラー設定）</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.19</br>
        /// <br>Update Note: 2011/12/15 劉亜駿</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27268　帳票フレーム／起動ナビゲーターのレ点チェックの修正</br>
        /// </remarks>
        private void ConstructionTreeNode()
        {
            // 起動ナビゲータ情報が格納されたバイナリファイルのロード
            if (System.IO.File.Exists(NAVIGATORTREE_XML))
            {
                this.StartNavigatorTree.LoadFromBinary(NAVIGATORTREE_XML);
            }

            this.StartNavigatorTree.Appearance.BackColor = Color.White;
            this.StartNavigatorTree.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((System.Byte)(222)), ((System.Byte)(239)), ((System.Byte)(255)));
            this.StartNavigatorTree.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.StartNavigatorTree.HideSelection = false;
            bool firstNode = true;

            Hashtable delNode2KeyLst = new Hashtable();
            Hashtable delNode3KeyLst = new Hashtable();

            // ノードの表示非表示を制御する
            if (_parameter.Length != 0)
            {
                // 選択ノードを先頭に移動させる
                firstNode = this.StartNavigatorTree.PerformAction(
                    Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                    false,
                    false);

                if (!firstNode)
                {
                    return;
                }

                //----------------------------------------------------------------------------//
                // 導入システムのチェック                                                     //
                //----------------------------------------------------------------------------//
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
                {
                    if (utn1.Nodes.Count != 0)
                    {
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                        {
                            if (utn2.Nodes.Count != 0)
                            {
                                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                                {
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;//ADD liuyj 2011/12/15 Redmine#27268
                                    bool nodeVisible = false;
                                    string productCodes = "";
                                    if (utn3.Override.NodeAppearance.Tag != null)
                                    {
                                        productCodes = utn3.Override.NodeAppearance.Tag.ToString();
                                    }

                                    string[] split = productCodes.Split(new Char[] { ' ' });

                                    foreach (string productCode in split)
                                    {
                                        if ((productCode != null) && (productCode.Trim() != ""))
                                        {
#if false		// USB⇒Companyチェックへ変更
                      if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(productCode) > 0)
                      {
#else
                                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(productCode) > 0)
                                            {
#endif
                                                nodeVisible = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (!nodeVisible)
                                    {
                                        if (!delNode3KeyLst.ContainsKey(utn3.Key))
                                        {
                                            delNode3KeyLst.Add(utn3.Key, utn3);
                                        }
                                    }
                                }

                                if (utn2.Nodes.Count == 0)
                                {
                                    if (!delNode2KeyLst.ContainsKey(utn2.Key))
                                    {
                                        delNode2KeyLst.Add(utn2.Key, utn2);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //----------------------------------------------------------------------------//
            // グループの表示非表示を制御する                                             //
            //----------------------------------------------------------------------------//
            // 選択ノードを先頭に移動させる
            firstNode = this.StartNavigatorTree.PerformAction(
                Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                false,
                false);

            if (!firstNode)
            {
                return;
            }


            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
            {
                if (utn1.Nodes.Count != 0)
                {
                    utn1.Expanded = true;

                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        bool utn2DeleteFlg = true;

                        // パラメータが空白の場合は全ノードを表示する（デリバリ時には非表示とする）
                        if (_parameter.Length == 0)
                        {
                            utn2DeleteFlg = false;
                        }
                        else
                        {
                            // Key値がnullの場合は非表示とする
                            if (utn2.Key != null)
                            {

                                for (int i = 0; i < _parameter.Length; i++)
                                {
                                    //----------------------------------------------------------------------------//
                                    // パラメータを100で割った余りにより、グループ起動か単体起動か判定            //
                                    // 端数なし：グループ                                                         //
                                    // 端数あり：単体(※複数存在する場合は親グループも表示)                       //
                                    //----------------------------------------------------------------------------//
                                    string strPara = SFANL07200UA._parameter[i];
                                    int intPara = TStrConv.StrToIntDef(SFANL07200UA._parameter[i], -1);

                                    if ((intPara % 100) != 0)
                                    {
                                        intPara = (intPara / 100) * 100;
                                        strPara = intPara.ToString();
                                    }
                                    if (utn2.Key.ToString() == strPara)
                                    {
                                        utn2DeleteFlg = false;
                                        break;
                                    }
                                }
                            }
                        }

                        if (utn2DeleteFlg == true)
                        {
                            if (!delNode2KeyLst.ContainsKey(utn2.Key))
                            {
                                delNode2KeyLst.Add(utn2.Key, utn2);
                            }
                        }
                        else
                        {
                            if (utn2.Nodes.Count != 0)
                            {
                                // パラメータが空白以外場合はノードを展開する
                                if (_parameter.Length != 0)
                                {
                                    utn2.Expanded = true;
                                }

                                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                                {
                                    utn3.Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.Standard;//ADD liuyj 2011/12/15 Redmine#27268
                                    bool utn3DeleteFlg = true;

                                    // パラメータが空白の場合は全ノードを表示する（デリバリ時には非表示とする）
                                    if (_parameter.Length == 0)
                                    {
                                        utn3DeleteFlg = false;
                                    }

                                    // Key値がnullの場合は非表示とする
                                    if (utn3.Key != null)
                                    {
                                        for (int i = 0; i < _parameter.Length; i++)
                                        {

                                            //----------------------------------------------------------------------------//
                                            // パラメータを100で割った余りにより、グループ起動か単体起動か判定            //
                                            // 端数なし：グループ                                                         //
                                            // 端数あり：単体(※複数存在する場合は親グループも表示)                       //
                                            //----------------------------------------------------------------------------//
                                            string strPara = SFANL07200UA._parameter[i];
                                            int intPara = TStrConv.StrToIntDef(SFANL07200UA._parameter[i], -1);

                                            if ((intPara % 100) != 0)
                                            {
                                                if (utn3.Key.ToString() == strPara)
                                                {
                                                    utn3DeleteFlg = false;
                                                    utn3.Override.NodeAppearance.ForeColor = Color.Blue;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                utn3DeleteFlg = false;
                                                utn3.Override.NodeAppearance.ForeColor = Color.Blue;
                                                break;
                                            }
                                        }
                                    }
                                    if (utn3DeleteFlg == true)
                                    {
                                        if (!delNode3KeyLst.ContainsKey(utn3.Key))
                                        {
                                            delNode3KeyLst.Add(utn3.Key, utn3);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // 第三階層を削除
            foreach (DictionaryEntry entry in delNode3KeyLst)
            {
                // 削除対象ノード
                Infragistics.Win.UltraWinTree.UltraTreeNode utn = (Infragistics.Win.UltraWinTree.UltraTreeNode)entry.Value;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
                {
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        if (utn.Parent.Key == utn2.Key)
                        {
                            utn2.Nodes.Remove(utn);
                            break;
                        }
                    }
                }
            }

            // 第二階層を削除
            foreach (DictionaryEntry entry in delNode2KeyLst)
            {
                // 削除対象ノード
                Infragistics.Win.UltraWinTree.UltraTreeNode utn = (Infragistics.Win.UltraWinTree.UltraTreeNode)entry.Value;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
                {
                    utn1.Nodes.Remove(utn);
                }
            }

            this.StartNavigatorTree.ExpandAll();
        }
        #endregion

        #region ◆　画面コントロールクラス作成処理
        /// <summary>
        /// 画面コントロールクラス作成処理
        /// </summary>
        /// <returns> </returns>
        /// <remarks>
        /// <br>Note       : 各種条件画面のアセンブリ情報を作成します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private int CreateFormControlInfo()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            if (this.StartNavigatorTree.Nodes.Count == 0) return status;

            this._formControlInfoTable.Clear();

            FormControlInfo info = null;

            // 選択ノードを先頭に移動させる
            bool result = this.StartNavigatorTree.PerformAction(
                Infragistics.Win.UltraWinTree.UltraTreeAction.FirstNode,
                false,
                false);
            if (!result)
            {
                return status;
            }

            // ツリーのノード情報を元に、プログラム情報コレクションクラスを構築する

            // ツリーのノードより取得する情報は以下の通り
            // [DataKey:アセンブリ名称]
            // [Override.Tag:クラス厳密名]
            // [Text:プログラム名称]
            // [Tag:制御拠点コード]
            // [Tag:制御拠点コード]

            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn1 in this.StartNavigatorTree.Nodes)
            {
                if (utn1.Nodes.Count != 0)
                {
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn2 in utn1.Nodes)
                    {
                        if (utn2.Nodes.Count != 0)
                        {
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn3 in utn2.Nodes)
                            {
                                if (utn3.DataKey != null && utn3.DataKey.ToString().Trim() != "")
                                {
                                    // アセンブリID,パラメータ
                                    string target = utn3.DataKey.ToString();
                                    string assemblyID;
                                    string param;

                                    this.SplitTargetAssemblyID(target, out assemblyID, out param);
                                    // 制御コード
                                    int ctrlFuncCode = 0;
                                    if (utn3.Tag != null)
                                    {
                                        ctrlFuncCode = TStrConv.StrToIntDef(utn3.Tag.ToString(), 0);
                                    }

                                    // >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                                    // 選択可能システム情報の取得
                                    string productCodes = "";
                                    if (utn3.Override.NodeAppearance.Tag != null)
                                    {
                                        productCodes = utn3.Override.NodeAppearance.Tag.ToString();
                                    }

                                    string[] split = productCodes.Split(new Char[] { ' ' });
                                    List<int> softWareCodeList = new List<int>(split.Length);

                                    foreach (string productCode in split)
                                    {
                                        if ((productCode != null) && (productCode.Trim() != ""))
                                        {
                                            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(productCode) > 0)
                                            {
                                                switch (productCode)
                                                {
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_SF:
                                                        softWareCodeList.Add(1);
                                                        break;
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_BK:
                                                        softWareCodeList.Add(2);
                                                        break;
                                                    case ConstantManagement_SF_PRO.SoftwareCode_PAC_CS:
                                                        softWareCodeList.Add(3);
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    // <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                                    // >>>>> 2006.08.09 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                                    // タブに表示するフォームクラスの情報を構築する
                                    info = new FormControlInfo(utn3.DataKey.ToString(),
                                        assemblyID,
                                        utn3.Override.Tag.ToString(),
                                        utn3.Text,
                                        utn3.Override.NodeAppearance.Image,
                                        ctrlFuncCode,
                                        param,
                                        softWareCodeList.ToArray());
                                    //// タブに表示するフォームクラスの情報を構築する
                                    //info = new FormControlInfo(utn3.DataKey.ToString(),
                                    //  assemblyID,
                                    //  utn3.Override.Tag.ToString(),
                                    //  utn3.Text,
                                    //  utn3.Override.NodeAppearance.Image,
                                    //  ctrlFuncCode,
                                    //  param);
                                    // <<<<< 2006.08.09 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                                    Debug.WriteLine("<<" + utn3.DataKey.ToString() + ">> " + (info == null ? "null" : "OK"));
                                    this._formControlInfoTable.Add(utn3.DataKey.ToString(), info);

                                    utn3.Key = utn3.DataKey.ToString();
                                }
                            }
                        }
                    }
                }
            }

            // プログラム情報は設定されているか
            status = (this._formControlInfoTable.Count == 0 ? (int)ConstantManagement.MethodResult.ctFNC_ERROR : (int)ConstantManagement.MethodResult.ctFNC_NORMAL);
            return status;
        }
        #endregion

        #region ◆　文字列分割処理
        /// <summary>
        /// 文字列分割処理
        /// </summary>
        /// <param name="target">対象文字列</param>
        /// <param name="id">分割文字１</param>
        /// <param name="prm">分割文字２</param>
        /// <remarks>
        /// <br>Note       : 対象文字列をスペースで２分割します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.10</br>
        /// </remarks>
        private void SplitTargetAssemblyID(string target, out string id, out string prm)
        {
            id = "";
            prm = "";

            string[] split = target.Split(new Char[] { ' ' });
            if (split != null)
            {
                int i = 0;
                foreach (string wk in split)
                {
                    switch (i)
                    {
                        case 0:		// アセンブリID
                            {
                                id = wk;
                                break;
                            }
                        default:	// 呼出パラメータ
                            {
                                if (prm != "")
                                {
                                    prm += " " + wk;
                                }
                                else
                                {
                                    prm = wk;
                                }
                                break;
                            }
                    }
                    i++;
                }
            }
        }
        #endregion

        #region ◆　ドックマネージャー初期設定処理
        /// <summary>
        /// ドックマネージャー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ドックマネージャーの初期設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void InitSettingDockManager()
        {
            //--- ドックマネージャーのアイコン設定
            // 起動ナビゲータ
            this.Main_DockManager.ImageList = IconResourceManagement.ImageList16;
            this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Settings.Appearance.Image = Size16_Index.TREE;

            // 出力条件選択
            this.Main_DockManager.ImageList = IconResourceManagement.ImageList16;
            this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Settings.Appearance.Image = Size16_Index.TREE;

            // 出力条件選択
            this.Main_DockManager.ImageList = IconResourceManagement.ImageList16;
            this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Settings.Appearance.Image = Size16_Index.PRINT;
        }
        #endregion

        #region ◆　ツールバー初期設定処理
        /// <summary>
        /// ツールバー初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーの初期設定を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// <br>UpdateNote : キーボード操作の改良を行う</br>
        /// <br>Programmer : PM1012C 朱 猛</br>
        /// <br>Date       : 2010/08/16</br>
        /// </remarks>
        private void InitSettingToolBar()
        {
            // ツールバーアイコンの設定
            this.Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            // ログイン担当者へのアイコン設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINLABEL_TITLE];
            if (loginEmployeeLabel != null) loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

            // ログイン担当者名設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginEmployeeName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[TOOLBAR_LOGINNAMELABEL_KEY];
            if (loginEmployeeName != null && this._loginEmployee != null)
            {
                loginEmployeeName.SharedProps.Caption = this._loginEmployee.Name;
            }

            // 終了のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_ENDBUTTON_KEY];
            if (closeButton != null) closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

            // 印刷のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool printButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
            if (printButton != null) printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

            // 抽出のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool extraButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRABUTTON_KEY];
            if (extraButton != null) extraButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RETRY;

            // PDFのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool pdfButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFBUTTON_KEY];
            if (pdfButton != null) pdfButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PREVIEW;

            // PDF履歴保存のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool pdfSaveButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
            if (pdfSaveButton != null) pdfSaveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

            // >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            // テキスト出力のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool textOutPutButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
            if (textOutPutButton != null) textOutPutButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CSVOUTPUT;
            // <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            // 実行のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool updateButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_UPDATEBUTTON_KEY];
            if (updateButton != null) updateButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // グラフ表示のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool graphButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
            if (graphButton != null) graphButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BARGRAPH1;

            // ユーザー設定のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool setUpButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
            if (setUpButton != null) setUpButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SETUP1;

            // ---ADD 2010/08/16-------------------->>>
            // ガイドのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool guideButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
            if (guideButton != null) guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;

            // 切替のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool changeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_CHANGEBUTTON_KEY];
            if (changeButton != null) changeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;

            // 次頁のアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool nextPageButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_NEXTPAGEBUTTON_KEY];
            if (nextPageButton != null) nextPageButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            // ---ADD 2010/08/16--------------------<<<
        }
        #endregion

        #region ◆　拠点情報選択リスト設定処理
        /// <summary>
        /// 拠点情報選択リスト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報選択リストの作成を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.18</br>
        /// </remarks>
        private void InitSettingSectionTree()
        {
            // 拠点選択・計上拠点選択を非表示
            this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = false;
            this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
            this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONRANGE].Visible = false; // ADD 2008/09/19 不具合対応[5528]

            // 拠点オプション有無チェック
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            {
                this._isOptSection = true;
            }
            else
            {
                this._isOptSection = false;
            }

#if DEBUG
            this._isOptSection = true;
#endif

            // 拠点オプション有り
            if (this._isOptSection)
            {

                // 本社機能？
                // 2008.12.26 [9574]
                //this._isMainOfficeFunc = (this._secInfoAcs.GetMainOfficeFuncFlag(this._loginSectionCode) == 1);
                this._isMainOfficeFunc = true;  // 本社機能限定
                // 2008.12.26 [9574]
                if (this._isMainOfficeFunc)
                {
                    // 拠点選択・計上拠点選択を非表示
                    this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = true;
                    this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = true;
                    this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONRANGE].Visible = true;  // ADD 2008/09/19 不具合対応[5528]

                    // 拠点情報リスト作成
                    this._secInfoLst = new SortedList();
                    if (this._secInfoLst != null)
                    {
                        for (int i = 0; i < this._secInfoAcs.SecInfoSetList.Length; i++)
                        {
                            this._secInfoLst.Add(this._secInfoAcs.SecInfoSetList[i].SectionCode.TrimEnd(), this._secInfoAcs.SecInfoSetList[i].Clone());
                            // HACK:↓デバッグ用処理…1拠点のみとする場合、有効にする
#if _ONE_SECTION_ONLY_
                            break;
#endif
                        }
                    }

                    // 拠点ツリー作成
                    this.Section_UTree.ShowLines = false;

                    // TODO:複数拠点存在する場合、全社を設定
                    // DEL 2010/05/11 MANTIS対応[15358]：1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正 ---------->>>>>
                    //if (this._secInfoLst.Count > 1)
                    // DEL 2010/05/11 MANTIS対応[15358]：1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正 ----------<<<<<
                    // ADD 2010/05/11 MANTIS対応[15358]：1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正 ---------->>>>>
                    if (this._secInfoLst.Count > 0)
                    // ADD 2010/05/11 MANTIS対応[15358]：1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正 ----------<<<<<
                    {
                        //this.Section_UTree.Nodes.Add(CT_AllSectionCode,"全社");               // 2008.09.05 T.Kudoh DEL
                        this.Section_UTree.Nodes.Add(CT_AllSectionCode, CT_AllCtrlFuncSecName); // 2008.09.05 T.Kudoh ADD
                        this.Section_UTree.Nodes[CT_AllSectionCode].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                        this.Section_UTree.Nodes[CT_AllSectionCode].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                    }

                    foreach (DictionaryEntry entry in this._secInfoLst)
                    {
                        SecInfoSet secInfoSet = (SecInfoSet)entry.Value;

                        // >>>>> 2008.09.05 T.Kudoh ADD and DEL START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                        //this.Section_UTree.Nodes.Add(secInfoSet.SectionCode.TrimEnd(), secInfoSet.SectionGuideNm);
                        string key = secInfoSet.SectionCode.TrimEnd();
                        string text = key + ":" + secInfoSet.SectionGuideNm;
                        this.Section_UTree.Nodes.Add(key, text);
                        // <<<<< 2008.09.05 T.Kudoh ADD and DEL END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                        this.Section_UTree.Nodes[secInfoSet.SectionCode.TrimEnd()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                        this.Section_UTree.Nodes[secInfoSet.SectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                    }

                    // DEL 2010/05/11 MANTIS対応[15358]：1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正 ---------->>>>>
                    // ADD 2009/12/25 MANTIS対応[14310]：拠点マスタに1拠点のみでの拠点範囲指定の不正 ---------->>>>>
                    //// 拠点が一つの場合、その拠点に固定
                    //if (this.Section_UTree.Nodes.Count.Equals(1))
                    //{
                    //    this.Section_UTree.Nodes[0].CheckedState = CheckState.Checked;
                    //    this.Section_UTree.Enabled = false;
                    //}
                    // ADD 2009/12/25 MANTIS対応[14310]：拠点マスタに1拠点のみでの拠点範囲指定の不正 ----------<<<<<
                    // DEL 2010/05/11 MANTIS対応[15358]：1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正 ----------<<<<<
                }
            }
        }
        #endregion

        #region ◆　出力対象拠点の範囲の初期設定

        /// <summary>
        /// 出力対象拠点の範囲を指定するコントロールの初期設定を行います。
        /// </summary>
        /// <param name="loading">ロード中のフラグ</param>
        /// <remarks>
        /// <br>Note       : 帳票フレーム修正</br>
        /// <br>Programmer : 30434 T.Kudoh</br>
        /// <br>Date       : 2008.09.05</br>
        /// <br>Update Note: 2011/03/14 yangmj</br>
        /// <br>             回収予定表で、画面入力内容がXMLに保存し、
        /// <br> 　　　　　　次回起動時に設定した内容が反映される様にするの修正</br>
        /// </remarks>
        private void InitSectionRange(bool loading)
        {
            #region <Guard Phrase/>

            if (this.Section_UTree.Nodes.Count.Equals(0)) return;

            #endregion  // <Guard Phrase/>

            //----ADD 2011/03/14----->>>>>
            if (_dckauFlag)
            {
                SortedList<string, string> sortedSectionList = new SortedList<string, string>();
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode sectionNode in this.Section_UTree.Nodes)
                {
                    if (sectionNode.CheckedState.Equals(CheckState.Checked))
                    {
                        sortedSectionList.Add(sectionNode.Key, sectionNode.Text);
                    }
                }
                if (sortedSectionList.Count == 0)
                {
                    // 開始拠点コードの初期値
                    this.tEdit_SectionCode_St.Text = string.Empty;
                    this.startRangeNameUltraTextEditor.Text = DEFAULT_START_SECTION_NAME;

                    // 終了拠点コードの初期値
                    this.tEdit_SectionCode_Ed.Text = string.Empty;
                    this.endRangeNameUltraTextEditor.Text = DEFAULT_END_SECTION_NAME;
                }
                else
                {
                    // 開始拠点コードの初期値
                    this.tEdit_SectionCode_St.Text = sortedSectionList.Keys[0].Trim();
                    this.startRangeNameUltraTextEditor.Text = GetSectionName(sortedSectionList.Keys[0]);
                    // 全社用の補正
                    if (sortedSectionList.Keys[0].Trim().Equals(CT_AllSectionCode))
                    {
                        this.tEdit_SectionCode_St.Text = string.Empty;
                        this.startRangeNameUltraTextEditor.Text = DEFAULT_START_SECTION_NAME;
                    }

                    // 終了拠点コードの初期値
                    this.tEdit_SectionCode_Ed.Text = sortedSectionList.Keys[sortedSectionList.Count - 1].Trim();
                    this.endRangeNameUltraTextEditor.Text = GetSectionName(sortedSectionList.Keys[sortedSectionList.Count - 1]);
                    // 全社用の補正
                    if (sortedSectionList.Keys[sortedSectionList.Count - 1].Trim().Equals(CT_AllSectionCode))
                    {
                        this.tEdit_SectionCode_Ed.Text = string.Empty;
                        this.endRangeNameUltraTextEditor.Text = DEFAULT_END_SECTION_NAME;
                    }
                }
            }
            else
            {
                //----ADD 2011/03/14-----<<<<<

                // 開始拠点コードの初期値
                string currentSectionCode = string.Empty;
                string currentSectionName = string.Empty;
                for (int i = 0; i < this.Section_UTree.Nodes.Count; i++)
                {
                    if (this.Section_UTree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
                    {
                        currentSectionCode = this.Section_UTree.Nodes[i].Key;
                        currentSectionName = GetSectionName(currentSectionCode);
                        break;
                    }
                }
                this.tEdit_SectionCode_St.Text = currentSectionCode;
                this.startRangeNameUltraTextEditor.Text = currentSectionName;

                // 終了拠点コードの初期値
                this.tEdit_SectionCode_Ed.Text = this.tEdit_SectionCode_St.Text;
                this.endRangeNameUltraTextEditor.Text = this.startRangeNameUltraTextEditor.Text;
            } //ADD 2011/03/14

            // DEL 2010/05/11 MANTIS対応[15358]：1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正 ---------->>>>>
            // ADD 2009/12/25 MANTIS対応[14310]：拠点マスタに1拠点のみでの拠点範囲指定の不正 ---------->>>>>
            //// 拠点が一つの場合、その拠点に固定
            //if (this.Section_UTree.Nodes.Count.Equals(1))
            //{
            //    this.tEdit_SectionCode_St.Enabled = false;
            //    this.tEdit_SectionCode_Ed.Enabled = false;
            //}
            // ADD 2009/12/25 MANTIS対応[14310]：拠点マスタに1拠点のみでの拠点範囲指定の不正 ----------<<<<<
            // DEL 2010/05/11 MANTIS対応[15358]：1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正 ----------<<<<<

            if (loading) this.tEdit_SectionCode_St.Focus();
        }

        /// <summary>
        /// 拠点名称を取得します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 帳票フレーム修正</br>
        /// <br>Programmer : 30434 T.Kudoh</br>
        /// <br>Date       : 2008.09.05</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            if (int.Parse(sectionCode).Equals(int.Parse(CT_AllCtrlFuncSecCode)))
            {
                return CT_AllCtrlFuncSecName;   // 全社
            }
            if (this._secInfoLst.ContainsKey(sectionCode))
            {
                return ((SecInfoSet)this._secInfoLst[sectionCode]).SectionGuideNm;
            }
            else
            {
                return string.Empty;
            }
        }

        // ADD 2009/03/12 不具合対応[11606] ---------->>>>>
        /// <summary>
        /// 出力対象拠点の範囲を設定します。
        /// </summary>
        /// <param name="checkedSectionCodes">選択されている拠点コード</param>
        /// <remarks>
        /// <br>Note       : 不具合対応[11606]</br>
        /// <br>Programmer : 30434 T.Kudoh</br>
        /// <br>Date       : 2009.03.12</br>
        /// </remarks>
        private void SetSectionRange(string[] checkedSectionCodes)
        {
            #region <Guard Phrase/>

            if (checkedSectionCodes == null || checkedSectionCodes.Length.Equals(0)) return;

            #endregion

            string startSectionCode = checkedSectionCodes[0];
            string endSectionCode = checkedSectionCodes[checkedSectionCodes.Length - 1];
            SetSectionRange(startSectionCode, endSectionCode);
        }

        /// <summary>
        /// 出力対象拠点の範囲を設定します。
        /// </summary>
        /// <param name="startSectionCode">開始拠点コード</param>
        /// <param name="endSectionCode">終了拠点コード</param>
        /// <remarks>
        /// <br>Note       : 不具合対応[11606]</br>
        /// <br>Programmer : 30434 T.Kudoh</br>
        /// <br>Date       : 2009.03.12</br>
        /// </remarks>
        private void SetSectionRange(
            string startSectionCode,
            string endSectionCode
        )
        {
            // 開始拠点
            this.tEdit_SectionCode_St.Text = startSectionCode;
            this.startRangeNameUltraTextEditor.Text = GetSectionName(startSectionCode);

            // 終了拠点
            this.tEdit_SectionCode_Ed.Text = endSectionCode;
            this.endRangeNameUltraTextEditor.Text = GetSectionName(endSectionCode);
        }
        // ADD 2009/03/12 不具合対応[11606] ----------<<<<<

        #endregion  // ◆　出力対象拠点の範囲の初期設定

        #region ◆　システム選択リスト設定処理
        /// <summary>
        /// システム選択リスト設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : システム選択リストの作成を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.18</br>
        /// </remarks>
        private void InitSettingSystemTree()
        {
            // システム選択を非表示
            this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible = false;

            int systemCnt = 0;

            // 整備
            if (this._introduceSystem.ContainsKey(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF)) { systemCnt += 1; }
            // 鈑金
            if (this._introduceSystem.ContainsKey(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK)) { systemCnt += 2; }
            // 車販
            if (this._introduceSystem.ContainsKey(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS)) { systemCnt += 4; }

            // 導入システムパターンを判定
            switch (systemCnt)
            {
                case 1:  // 整備のみ
                    this._introduceSystemCdLst = new int[] { 1 };
                    break;
                case 2:  // 鈑金のみ
                    this._introduceSystemCdLst = new int[] { 2 };
                    break;
                case 3:  // 整備＋鈑金
                    this._introduceSystemCdLst = new int[] { 1, 2 };
                    break;
                case 4:  // 車販のみ
                    this._introduceSystemCdLst = new int[] { 3 };
                    break;
                case 5:  // 整備＋車販
                    this._introduceSystemCdLst = new int[] { 1, 3 };
                    break;
                case 6:  // 鈑金＋車販
                    this._introduceSystemCdLst = new int[] { 2, 3 };
                    break;
                case 7:  // 整備＋鈑金＋車販
                    this._introduceSystemCdLst = new int[] { 1, 2, 3 };
                    break;
            }

            // >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            this._slDefSoftWareCode = new SortedList<int, string>();
            // <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // 導入システムが単体の場合、システム選択は非表示とする。
            if (this._introduceSystem.Count > 1)
            {
                this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible = true;

                // システムツリー作成
                this.System_UTree.ShowLines = false;

                foreach (int sysCode in this._introduceSystemCdLst)
                {
                    string sysName = "";

                    switch (sysCode)
                    {
                        case 1:
                            sysName = "整備";
                            break;
                        case 2:
                            sysName = "鈑金";
                            break;
                        case 3:
                            sysName = "車販";
                            break;
                    }

                    this.System_UTree.Nodes.Add(sysCode.ToString(), sysName);
                    this.System_UTree.Nodes[sysCode.ToString()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                    this.System_UTree.Nodes[sysCode.ToString()].CheckedState = System.Windows.Forms.CheckState.Checked;

                    // >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                    this._slDefSoftWareCode.Add(sysCode, sysName);
                    // <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                }
            }
            else
            {
                if (this._introduceSystemCdLst == null) return;

                foreach (int sysCode in this._introduceSystemCdLst)
                {
                    string sysName = "";

                    switch (sysCode)
                    {
                        case 1:
                            sysName = "整備";
                            break;
                        case 2:
                            sysName = "鈑金";
                            break;
                        case 3:
                            sysName = "車販";
                            break;
                    }

                    this._slDefSoftWareCode.Add(sysCode, sysName);
                }
            }
        }
        #endregion

        #region ◆　出力帳票履歴初期設定処理
        /// <summary>
        /// 出力帳票履歴処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : システム選択リストの作成を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.18</br>
        /// </remarks>
        private void InitSettingPdfHistorySubForm()
        {
            try
            {
                this._pdfHistorySerchForm = new SFANL06101UA();
                this._pdfHistorySerchForm.LoginWorker = this._loginEmployee.Name;

                mControlScreenSkin.SettingScreenSkin(this._pdfHistorySerchForm);

                // 帳票選択イベントを追加
                this._pdfHistorySerchForm.SelectNode += new SelectNodeEvent(SelectPdfHistoryListNode);

                // フォームの起動
                this._pdfHistorySerchForm.TopLevel = false;
                this._pdfHistorySerchForm.FormBorderStyle = FormBorderStyle.None;
                this.PdfHistory_Panel.Controls.Add(this._pdfHistorySerchForm);
                this._pdfHistorySerchForm.Dock = System.Windows.Forms.DockStyle.Fill;
                this._pdfHistorySerchForm.BringToFront();
                this._pdfHistorySerchForm.Show();
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        #region ◆　出力帳票履歴管理画面帳票選択処理
        /// <summary>
        /// 出力履歴管理画面選択処理
        /// </summary>
        /// <param name="printKey">帳票KEY</param>
        /// <param name="printName">帳票名</param>
        /// <param name="PDFFileName">PDFファイル名</param>
        /// <remarks>
        /// <br>Note       : システム選択リストの作成を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.20</br>
        /// </remarks>
        private void SelectPdfHistoryListNode(string printKey, string printName, string PDFFileName)
        {
            // ドックマネージャーの固定ピン解除
            this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Unpin();

            if (this._setPdfKeyList.ContainsKey(printKey))
            {
                string infoKey = this._setPdfKeyList[printKey].ToString();

                System.Windows.Forms.Form frm = null;

                this.ViewFormTabCreate(infoKey);

                this.ViewFormTabActive(infoKey, ref frm);

                if (frm != null)
                {
                    SFANL07200UB target = frm as SFANL07200UB;

                    target.IsSave = false;
                    target.PrintKey = "";
                    target.PrintName = "";
                    target.PrintDetailName = "";
                    target.PrintPDFPath = "";

                    target.ShowPDFPreview((Object)PDFFileName);
                }

                // ツールバーボタン設定
                this.ToolBarSetting(frm);
                // ドックマネジャー設定
                this.DockManagerCtrlPaneSetting(frm);
            }
        }
        #endregion

        #region ◆　ＰＤＦ履歴保存
        /// <summary>
        /// ＰＤＦ履歴保存処理
        /// </summary>
        /// <param name="key">対象帳票KEY</param>
        /// <remarks>
        /// <br>Note       : 対象帳票KEYのＰＤＦファイルを履歴保存します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.04.13</br>
        /// </remarks>
        private void SavePDF(string key)
        {
            try
            {
                // ビューフォームの場合は親のKEYを取得
                string mainKey = key.ToString().Replace(TAB_VIEWFORM_ADDKEY, "");

                // アクティブタブから帳票コントロール情報を取得
                FormControlInfo info = this._formControlInfoTable[mainKey] as FormControlInfo;
                if (info == null) return;
                // --- ADD 2010/08/26 ---------->>>>>
                if (info.Form is IPrintConditionInpTypeGuidExecuter)
                {
                    ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                    ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
                }
                // --- ADD 2010/08/26 ----------<<<<<
                // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
                if (info.Form is IPrintConditionInpTypeTextOutControl)
                {
                    ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                    ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
                }
                // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

                // PDFプレビューフォーム
                SFANL07200UB target = info.ViewForm as SFANL07200UB;
                if (target == null) return;

                // 履歴保存は可能か？
                if (target.IsSave)
                {
                    if (this._pdfHistorySerchForm != null)
                    {
                        // 重複チェック
                        if (this._pdfHistorySerchForm.Contains(target.PrintKey, target.PrintPDFPath))
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当のＰＤＦは既に履歴登録されています。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        // 出力履歴管理に追加
                        this._pdfHistorySerchForm.AddPrintInfo(target.PrintKey, target.PrintName, target.PrintDetailName,
                            target.PrintPDFPath);

                        // 削除リストから除外する
                        if (this._delPDFList.Contains(target.PrintPDFPath))
                        {
                            this._delPDFList.Remove(target.PrintPDFPath);
                        }
                    }

                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "保存しました。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, "ＰＤＦの履歴保存に失敗しました。" + "\n\r" + ex.Message,
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        #region ◆　出力条件選択エクスプローラーバーグループ項目チェック
        /// <summary>
        /// 出力条件選択エクスプローラーバーグループ項目チェック
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出力条件選択エクスプローラーバー内のグループ項目のチェック処理。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void CheckExplorerBarGroup()
        {
            bool isShow = this.IsSelectGroup();

            if (isShow)
            {
                if (this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Closed)
                {
                    this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Show();
                    this.Main_TabControl.Focus(); // ADD 2010/08/26
                }
            }
            else
            {
                this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Close();
            }
        }

        /// <summary>
        /// 出力条件選択エクスプローラーバーグループ項目表示チェック
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 出力条件選択エクスプローラーバー内のグループ項目の表示チェック処理。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.04.22</br>
        /// </remarks>
        private bool IsSelectGroup()
        {
            bool isShow = false;

            // グループ項目の表示状態チェック
            foreach (Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup grp in this.SelectExplorerBar.Groups)
            {
                isShow = grp.Visible;
                // 一つでも表示されていればドックマネージャーのペインは表示する
                if (isShow)
                {
                    break;
                }
            }
            return isShow;
        }
        #endregion

        #region ◆　単体起動・ナビ起動判定処理
        /// <summary>
        /// 単体起動・ナビ起動判定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// <br>Update Note: 2011/03/14 yangmj</br>
        /// <br>             回収予定表で、画面入力内容がXMLに保存し、
        /// <br> 　　　　　　次回起動時に設定した内容が反映される様にするの修正</br>
        /// </remarks>
        private void CheckNaviOrSingleStart()
        {
            // 起動ナビゲータより起動
            if (this._formControlInfoTable.Count > 1)
            {
                this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Show();
                this._navigaterMenuMode = true;

                // 拠点OP = 有 && 本社機能
                if (this._isOptSection && this._isMainOfficeFunc)
                {
                    // デフォルトチェックはログイン拠点
                    if (this._secInfoLst.ContainsKey(this._loginSectionCode.TrimEnd()))
                    {
                        this.Section_UTree.Nodes[this._loginSectionCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                    }
                }

                this.StartNavigatorTree.Focus();
            }
            // 単体起動
            else
            {
                FormControlInfo info = null;

                foreach (DictionaryEntry entry in this._formControlInfoTable)
                {
                    info = (FormControlInfo)entry.Value;
                    break;
                }
                if (info != null)
                {
                    //-----ADD 2011/03/14----->>>>>
                    if ("DCKAU02520U.DLL".Equals(info.AssemblyID))
                    {
                        _dckauFlag = true;
                    }
                    //-----ADD 2011/03/14-----<<<<<
                    this._navigaterMenuMode = false;
                    this.Text = info.Name;

                    // 拠点OP = 有 && 本社機能
                    if (this._isOptSection && this._isMainOfficeFunc)
                    {
                        // 制御機能コードより拠点コード取得
                        string ctrlSecCode;
                        this.GetOwnSeCtrlCode(this._loginSectionCode, info.CtrlFuncCode, out ctrlSecCode);

                        // 該当拠点を初期設定
                        if (this._secInfoLst.ContainsKey(ctrlSecCode))
                        {
                            this.Section_UTree.Nodes[ctrlSecCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                        }
                    }

                    // 条件入力画面UI起動処理
                    this.ShowChildInputForm(info.Key);

                    // ADD 2009/03/18 不具合対応[8937]：セキュリティ管理設定で制限した機能が有効となっていない ---------->>>>>
                    // 操作権限制御
                    if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                    {
                        if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                            EntityUtil.CategoryCode.Report,
                            MyOpeCtrlMap.AddController(info.AssemblyID),
                            info.AssemblyID,
                            info.Name
                        ))
                        {
                            this.Close();   // 起動不可のため強制終了
                        }
                    }

                    //-----ADD 2011/03/14----->>>>>
                    if (_dckauFlag)
                    {
                        // 制御機能コードより拠点コード取得
                        string ctrlSecCode;
                        this.GetOwnSeCtrlCode(this._loginSectionCode, info.CtrlFuncCode, out ctrlSecCode);

                        // 拠点OP = 有 && 本社機能
                        if (this._isOptSection && this._isMainOfficeFunc)
                        {
                            // 該当拠点を初期設定
                            if (this._secInfoLst.ContainsKey(ctrlSecCode))
                            {
                                this.Section_UTree.Nodes[ctrlSecCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                            }
                        }

                        // 前回選択していた拠点を設定
                        if (!SectionTreeHelper.ImportCheckedSectionCode(this.Section_UTree, true))
                        {
                            // 請求設定拠点にデフォルトチェック？
                            if (this._secInfoLst.ContainsKey(ctrlSecCode))
                            {
                                this.Section_UTree.Nodes[ctrlSecCode.TrimEnd()].CheckedState = System.Windows.Forms.CheckState.Checked;
                            }
                        }
                    }
                    //-----ADD 2011/03/14-----<<<<<

                    BeginControllingByOperationAuthority(info.AssemblyID);
                    // ADD 2009/03/18 不具合対応[8937]：セキュリティ管理設定で制限した機能が有効となっていない ----------<<<<<

                }
            }
        }
        #endregion

        #region ◆　各帳票条件ＵＩクラス起動処理
        /// <summary>
        /// 各帳票条件UI画面起動処理
        /// </summary>
        /// <param name="key">対象キー情報</param>
        /// <remarks>
        /// <br>Note       : 引数のキー情報を元に、タブをアクティブ化します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.19</br>
        /// </remarks>
        private void ShowChildInputForm(string key)
        {
            Cursor nowCursor = this.Cursor;
            System.Windows.Forms.Form childForm = null;

            this._isEvent = false;

            try
            {
                // 起動子画面作成処理
                this.TabCreate(key);

                // 起動子画面アクティブ化処理		
                this.TabActive(key, ref childForm);

                // ツールバーセッティング
                this.ToolBarSetting(childForm);

                // メインフレームの個別画面設定
                this.ScreenPrivateSetting(key, childForm);

                // 起動ナビゲーターペイン非固定
                this.PinnedDockManagerControlPane(DOCKMANAGER_NAVIGATOR_KEY, false);

                // 出力条件選択ペイン固定
                this.PinnedDockManagerControlPane(DOCKMANAGER_SELECTCONDITION_KEY, true);

                // 出力履歴検索ペイン非固定
                this.PinnedDockManagerControlPane(DOCKMANAGER_PDFHISTORTY_KEY, false);
            }
            finally
            {
                this._isEvent = true;
                this.Cursor = nowCursor;
            }
        }
        #endregion

        #region ◆　各帳票条件UI画面個別画面設定処理
        // TODO:注意！メニューから呼び出される場合、本メソッドで拠点の選択設定が再設定されます。
        /// <summary>
        /// 各帳票条件UI画面個別画面設定処理
        /// </summary>
        /// <param name="key">対象キー情報</param>
        /// <param name="activeForm">アクティブ対象となるForm</param>
        /// <remarks>
        /// <br>Note       :各条件画面個別のフレーム画面を設定します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.19</br>
        /// <br>Update Note: 2006.03.28 Y.Sasaki</br>
        /// <br>           : １.カスタム拠点種類選択に対応</br>
        /// </remarks>
        private void ScreenPrivateSetting(string key, System.Windows.Forms.Form activeForm)
        {
            if (activeForm == null) return;

            // コントロール情報取得
            FormControlInfo info = null;
            if (this._formControlInfoTable.ContainsKey(key))
            {
                info = this._formControlInfoTable[key] as FormControlInfo;
            }
            else
            {
                return;
            }

            // 初回起動時はそれぞれの初期値を帳票共通用フォームコントロールクラスに設定
            if (!info.IsInit)
            {
                info.SelSectionKindIndex = 0;														// 拠点種類

                // >>>>> 2006.08.09 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                info.SelSystems = info.SoftWareCode;										// システム選択
                //info.SelSystems = this._introduceSystemCdLst;						// システム選択
                // <<<<< 2006.08.09 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                // 拠点OP有時
                if (this._isOptSection)
                {
                    // 初期拠点設定
                    string ctrlSecCode;
                    this.GetOwnSeCtrlCode(this._loginSectionCode, info.CtrlFuncCode, out ctrlSecCode);
                    info.SelSections = new string[] { ctrlSecCode };
                }
            }

            //----------------------------------------------------------------------------//
            // 画面情報更新処理                                                           //
            //----------------------------------------------------------------------------//
            // TODO:拠点関連情報…メニューから呼び出される場合、ここで拠点の選択設定が再設定されます。
            if (this.Section_UTree.Nodes.Count > 1) // ADD 2010/02/19 MANTIS対応[14310]：拠点マスタに1拠点のみでの拠点範囲指定の不正
            {   // 選択できる拠点が複数の場合、初期選択設定を再設定する
                // 一旦全てのチェックをはずす	
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
                {
                    utn.CheckedState = CheckState.Unchecked;
                }

                // 選択されている拠点をチェック
                foreach (string wkSection in info.SelSections)
                {
                    if (this.Section_UTree.Nodes.Exists(wkSection))
                    {
                        this.Section_UTree.Nodes[wkSection].CheckedState = CheckState.Checked;
                    }
                }

                // 出力拠点の範囲指定（開始と終了）を設定
                SetSectionRange(info.SelSections);  // ADD 2009/03/12 不具合対応[11606]
            }   // ADD 2010/02/19 MANTIS対応[14310]：拠点マスタに1拠点のみでの拠点範囲指定の不正

            // システム関連情報
            // 一旦全てのチェックをはずす	
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.System_UTree.Nodes)
            {
                utn.CheckedState = CheckState.Unchecked;
            }
            // 選択されているシステムをチェック
            foreach (int wkSystem in info.SelSystems)
            {
                if (this.System_UTree.Nodes.Exists(wkSystem.ToString()))
                {
                    this.System_UTree.Nodes[wkSystem.ToString()].CheckedState = CheckState.Checked;
                }
            }

            //----------------------------------------------------------------------------//
            // 拠点選択グループ表示判定                                                   //
            //----------------------------------------------------------------------------//
            // 拠点選択インターフェイスを実装している
            if (activeForm is IPrintConditionInpTypeSelectedSection)
            {
                // 拠点種類カスタムインターフェースを実装している？
                if (activeForm is IPrintConditionInpTypeCustomSelectSectionKind)
                {
                    IPrintConditionInpTypeCustomSelectSectionKind target = activeForm as IPrintConditionInpTypeCustomSelectSectionKind;

                    // 拠点種類の画面設定
                    if (target != null) { this.SettingSectionKindItemList(target.Title, target.CustomSectionKindList); }
                }
                else
                {
                    // 拠点種類の画面設定
                    this.SettingSectionKindItemList(CT_EXPLORERBAR_ADDUPCDLIST_TITLE, (SectionKind[])this._arDefultSecKind.ToArray(typeof(SectionKind)));
                }


                // 前回拠点種類を画面に設定
                if (this.AddUpCd_UOptionSet.Items != null && this.AddUpCd_UOptionSet.Items.Count > 0)
                {
                    this.AddUpCd_UOptionSet.CheckedIndex = info.SelSectionKindIndex;
                }

                // 拠点選択インターフェイスでキャスト 
                IPrintConditionInpTypeSelectedSection targetObj = activeForm as IPrintConditionInpTypeSelectedSection;

                if (targetObj != null)
                {
                    bool isVisibled = false;

                    if (this._isOptSection)
                    {
                        // 帳票個別条件による表示有無
                        isVisibled = targetObj.InitVisibleCheckSection(this._isDefaultSectionSelect);

                        this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = targetObj.VisibledSelectAddUpCd;
                        this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = isVisibled;
                        this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONRANGE].Visible = isVisibled;    // ADD 2008/09/19 不具合対応[5528]
                    }
                    else
                    {
                        this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = false;
                        this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
                        this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONRANGE].Visible = false;   // ADD 2008/09/19 不具合対応[5528]
                    }

                    // 計上拠点選択はあるか？
                    if (targetObj.VisibledSelectAddUpCd)
                    {
                        int addCode = TStrConv.StrToIntDef(this.AddUpCd_UOptionSet.CheckedItem.DataValue.ToString(), 0);
                        targetObj.InitSelectAddUpCd(addCode);
                    }

                    // 拠点情報設定
                    targetObj.InitSelectSection(info.SelSections);

#if false					
					// 初回起動時のみ初期設定情報設定
					if (!info.IsInit)
					{
						// デフォルト設定初期制御機能コード取得
						int ctrlFuncCode = info.CtrlFuncCode;
						
						// 計上拠点選択 = 有
						if (targetObj.VisibledSelectAddUpCd)
						{
							// 初期計上拠点設定処理
							int addCode = 0;
							
							if (this.AddUpCd_UOptionSet.CheckedIndex != -1)
							{
								// 拠点種類の取得
								addCode = TStrConv.StrToIntDef(this.AddUpCd_UOptionSet.CheckedItem.DataValue.ToString(), 0);
							
								// 制御機能コード取得
								ctrlFuncCode = TStrConv.StrToIntDef(this.AddUpCd_UOptionSet.CheckedItem.Tag.ToString(), 0);
							}
							
							targetObj.InitSelectAddUpCd(addCode);
						}

						string[] selSections = null;
						
						// 拠点選択有り
						if (isVisibled)
						{
							// 初期選択拠点設定処理
							ArrayList selSecList = new ArrayList();
							foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
							{
								if (utn.CheckedState == CheckState.Checked)
								{
									selSecList.Add(utn.Key);
								}
							}
							selSections = (string[])selSecList.ToArray(typeof(string));
						} 
						// 拠点選択なし
						else 
						{
							// 拠点OP有
							if (this._isOptSection)
							{
								// 制御拠点取得
								string ctrlSecCode; 
								this.GetOwnSeCtrlCode(this._loginSectionCode, ctrlFuncCode, out ctrlSecCode);
								selSections = new string[]{ctrlSecCode};
							} 
								// 拠点OP無
							else
							{
								// 自拠点コード取得
								string ctrlSecCode; 
								this.GetOwnSeCtrlCode(this._loginSectionCode, 10, out ctrlSecCode);
								selSections = new string[]{ctrlSecCode};
							}
						}

						// 拠点初期設定
						targetObj.InitSelectSection(selSections);
					}
#endif
                }
            }
            else
            {
                this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Visible = false;
                this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = false;
                this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONRANGE].Visible = false;   // ADD 2008/09/19 不具合対応[5528]
            }

            //----------------------------------------------------------------------------//
            // システム選択グループ表示判定                                               //
            //----------------------------------------------------------------------------//
            // システム選択インターフェイスを実装している
            if (activeForm is IPrintConditionInpTypeSelectedSystem)
            {
                // システム選択インターフェイスでキャスト 
                IPrintConditionInpTypeSelectedSystem targetObj = activeForm as IPrintConditionInpTypeSelectedSystem;

                // 帳票個別条件による表示有無
                bool isVisibled = targetObj.InitVisibleCheckSystem(this._isDefaultSystemSelect);

                this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible = isVisibled;

                // >>>>> 2006.08.09 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                if (isVisibled)
                {
                    // システム選択リスト再作成
                    this.SettingSystemItemList(info.SoftWareCode);

                    // 選択されているシステムをチェック
                    foreach (int wkSystem in info.SelSystems)
                    {
                        if (this.System_UTree.Nodes.Exists(wkSystem.ToString()))
                        {
                            this.System_UTree.Nodes[wkSystem.ToString()].CheckedState = CheckState.Checked;
                        }
                    }
                }
                // <<<<< 2006.08.09 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
#if true
                targetObj.InitSelectSystem(info.SelSystems);
#else
				// 初回起動時のみ初期設定情報設定
				if (!info.IsInit)
				{
					// 初期選択システム処理
					ArrayList selSysList = new ArrayList();
					foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.System_UTree.Nodes)
					{
						if (utn.CheckedState == CheckState.Checked)
						{
							selSysList.Add(TStrConv.StrToIntDef(utn.Key,-1));
						}
					}
					
					int[] selSystems = (int[])selSysList.ToArray(typeof(int));
					targetObj.InitSelectSystem(selSystems);
				}
#endif

            }
            else
            {
                this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible = false;
            }

            // 出力条件選択ペイン表示制御
            this.CheckExplorerBarGroup();

            //----------------------------------------------------------------------------//
            // 出力帳票履歴検索表示判定                                                   //
            //----------------------------------------------------------------------------//
            // 出力帳票履歴検索インターフェイスを実装している
            if (activeForm is IPrintConditionInpTypePdfCareer)
            {
                if (this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Closed)
                    this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Show();

                // 出力帳票履歴検索インターフェイスでキャスト 
                IPrintConditionInpTypePdfCareer targetObj = activeForm as IPrintConditionInpTypePdfCareer;

                if (!info.IsInit)
                {
                    if (targetObj.PrintKey != null)
                    {
                        // 該当の帳票KEYは既に設定済みか？
                        if (!this._setPdfKeyList.ContainsKey(targetObj.PrintKey))
                        {
                            // 帳票履歴検索画面に帳票KEY追加
                            this._pdfHistorySerchForm.SetPrintKey(targetObj.PrintKey, targetObj.PrintName);
                            if (info != null)
                            {
                                this._setPdfKeyList.Add(targetObj.PrintKey, info.Key);
                            }
                        }
                    }
                }
            }
            else
            {
                // 単体起動の時のみ判定、グループ起動時は常に表示しておく
                if (!this._navigaterMenuMode)
                {
                    this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Close();
                }
            }

            // >>>>> 2006.09.28 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //----------------------------------------------------------------------------//
            // テキスト出力判定                                                           //
            //----------------------------------------------------------------------------//
            // TODO:テキスト出力インターフェイスを実装している…Enabled
            if (this._isOptTextOutPut && activeForm is IPrintConditionInpTypeTextOutPut)
            {
                // 出力帳票履歴検索インターフェイスでキャスト 
                IPrintConditionInpTypeTextOutPut targetObj = activeForm as IPrintConditionInpTypeTextOutPut;
                if (targetObj != null)
                {
                    // テキスト出力
                    Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = targetObj.CanTextOutPut;
                    }
                }
            }
            // <<<<< 2006.09.28 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //----------------------------------------------------------------------------//
            // 実行判定                                                           //
            //----------------------------------------------------------------------------//
            // 実行インターフェイスを実装している
            if (activeForm is IPrintConditionInpTypeUpdate)
            {
                // 実行インターフェイスでキャスト 
                IPrintConditionInpTypeUpdate targetObj = activeForm as IPrintConditionInpTypeUpdate;
                if (targetObj != null)
                {
                    // 実行
                    Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_UPDATEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = targetObj.CanUpdate;
                    }
                }
            }
            // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            //----------------------------------------------------------------------------//
            // グラフ表示判定                                                             //
            //----------------------------------------------------------------------------//
            // グラフ表示インターフェイスを実装している
            if (activeForm is IPrintConditionInpTypeChart)
            {
                // グラフ表示インターフェイスでキャスト 
                IPrintConditionInpTypeChart targetObj = activeForm as IPrintConditionInpTypeChart;
                if (targetObj != null)
                {
                    // ユーザー設定
                    Infragistics.Win.UltraWinToolbars.ButtonTool setUpBtnTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                    if (setUpBtnTool != null)
                    {
                        setUpBtnTool.SharedProps.Enabled = true;
                    }

                    // グラフ表示
                    Infragistics.Win.UltraWinToolbars.ButtonTool graphBtnTool =
                        (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
                    if (graphBtnTool != null)
                    {
                        graphBtnTool.SharedProps.Enabled = targetObj.CanChart;
                    }
                }
            }

            // 初期設定済み
            info.IsInit = true;
        }
        #endregion

        #region ◆　拠点種類リスト画面レイアウト設定
        /// <summary>
        /// 拠点種類リスト画面レイアウト設定
        /// </summary>
        /// <param name="title">タイトル</param>
        /// <param name="kindList">設定内容リスト</param>
        /// <remarks>
        /// <br>Note       : 拠点種類を画面に設定します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.04.07</br>
        /// </remarks>
        private void SettingSectionKindItemList(string title, SectionKind[] kindList)
        {
            // 計上種類コンボ初期化
            this.AddUpCd_UOptionSet.Items.Clear();

            // タイトル設定
            this.SelectExplorerBar.Groups[EXPLORERBAR_ADDUPCDLIST].Text = title;

            // アイテム内容の取得
            if (kindList != null)
            {
                int i = 1;
                foreach (SectionKind kind in kindList)
                {
                    Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
                    item.DataValue = i;
                    item.DisplayText = kind.CtrlFuncName;
                    item.Tag = kind.CtrlFuncCode;

                    this.AddUpCd_UOptionSet.Items.Add(item);
                    i++;
                }
            }
        }
        #endregion

        #region ◆　システム選択リスト画面レイアウト設定
        /// <summary>
        /// システム選択リスト画面レイアウト設定
        /// </summary>
        /// <param name="softwareCode">選択可能システム</param>
        /// <remarks>
        /// <br>Note       : 選択可能システムを画面に設定します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.08.09</br>
        /// </remarks>
        private void SettingSystemItemList(int[] softwareCode)
        {
            // システムツリー作成
            this.System_UTree.Nodes.Clear();
            this.System_UTree.ShowLines = false;

            foreach (int sysCode in softwareCode)
            {
                if (this._slDefSoftWareCode.ContainsKey(sysCode))
                {
                    string sysName = "";

                    switch (sysCode)
                    {
                        case 1:
                            sysName = "整備";
                            break;
                        case 2:
                            sysName = "鈑金";
                            break;
                        case 3:
                            sysName = "車販";
                            break;
                    }

                    this.System_UTree.Nodes.Add(sysCode.ToString(), sysName);
                    this.System_UTree.Nodes[sysCode.ToString()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                    this.System_UTree.Nodes[sysCode.ToString()].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                }
            }

            if (this.System_UTree.Nodes.Count <= 1)
            {
                this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible = false;
            }
        }
        #endregion

        #region ◆　コントロールペインピン制御
        /// <summary>
        /// コントロールペインピン制御
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="isPinned">[T:固定・F:非固定]</param>
        /// <remarks>
        /// <br>Note       : 該当キーのペインの固定・非固定状態を制御します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void PinnedDockManagerControlPane(string key, bool isPinned)
        {
            // フローティングされているペインは無視
            if (this.Main_DockManager.ControlPanes[key].DockedState == Infragistics.Win.UltraWinDock.DockedState.Floating) return;

            // 固定
            if (isPinned)
            {
                if (!this.Main_DockManager.ControlPanes[key].Closed)
                {
                    if (!this.Main_DockManager.ControlPanes[key].Pinned)
                    {
                        this.Main_DockManager.ControlPanes[key].Pin();
                    }
                }
            }
            // 非固定
            else
            {
                if (!this.Main_DockManager.ControlPanes[key].Closed)
                {
                    if (this.Main_DockManager.ControlPanes[key].Pinned)
                    {
                        this.Main_DockManager.ControlPanes[key].Unpin();

                        if (!this.Main_DockManager.ControlPanes[key].Pinned &&
                            this.Main_DockManager.ControlPanes[key].Manager.FlyoutPane != null)
                        {
                            this.Main_DockManager.ControlPanes[key].Manager.FlyIn(true);
                        }
                    }
                }
            }
        }
        #endregion

        #region ◆　タブ制御関連処理
        /// <summary>
        /// タブアクティブ処理
        /// </summary>
        /// <param name="key">対象キー情報</param>
        /// <param name="form">アクティブ化したフォームのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 引数のキー情報を元に、タブをアクティブ化します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void TabActive(string key, ref Form form)
        {
            if (this.Main_TabControl.Tabs.Exists(key))
            {
                this.Main_TabControl.Tabs[key].Visible = true;
                this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[key];

                form = this.Main_TabControl.Tabs[key].Tag as System.Windows.Forms.Form;

                // ウィンドウステイト状態変更
                this.CreateWindowStateButtonTools();

                // WindowStateボタンを選択状態にする
                Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                {
                    if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                    if ((this.Main_TabControl.SelectedTab != null) && (key == stateButtonTool.Key))
                    {
                        stateButtonTool.Checked = true;
                    }
                    else
                    {
                        stateButtonTool.Checked = false;
                    }
                }
            }
        }

        /// <summary>
        /// ビューフォームタブアクティブ処理
        /// </summary>
        /// <param name="key">対象キー情報</param>
        /// <param name="form">アクティブ化したフォームのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 引数のキー情報を元に、タブをアクティブ化します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void ViewFormTabActive(string key, ref Form form)
        {
            Cursor nowCursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 追加キー情報設定
                string viewKey = key + TAB_VIEWFORM_ADDKEY;

                if (this.Main_TabControl.Tabs.Exists(viewKey))
                {
                    this.Main_TabControl.Tabs[viewKey].Visible = true;
                    this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[viewKey];

                    // ウィンドウステイト状態変更
                    this.CreateWindowStateButtonTools();

                    form = this.Main_TabControl.Tabs[viewKey].Tag as System.Windows.Forms.Form;

                    // WindowStateボタンを選択状態にする
                    Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                    for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                    {
                        if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                        Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                        if ((this.Main_TabControl.SelectedTab != null) && (viewKey == stateButtonTool.Key))
                        {
                            stateButtonTool.Checked = true;
                        }
                        else
                        {
                            stateButtonTool.Checked = false;
                        }
                    }

                }
            }
            finally
            {
                this.Cursor = nowCursor;
            }
        }

        /// <summary>
        /// チャート表示ビューフォームタブアクティブ処理
        /// </summary>
        /// <param name="key">対象キー情報</param>
        /// <param name="number">表示No.</param>
        /// <param name="form">アクティブ化したチャートビューのインスタンス</param>
        /// <remarks>
        /// <br>Note       : 引数のキー情報を元に、タブをアクティブ化します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        private void ChartViewFormTabActive(string key, int number, ref Form form)
        {
            Cursor nowCursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 追加キー情報設定
                string chartViewKey = key + TAB_CHARTVIEWFORM_ADDKEY + number.ToString();

                if (this.Main_TabControl.Tabs.Exists(chartViewKey))
                {
                    this.Main_TabControl.Tabs[chartViewKey].Visible = true;
                    this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[chartViewKey];

                    // ウィンドウステイト状態変更
                    this.CreateWindowStateButtonTools();

                    form = this.Main_TabControl.Tabs[chartViewKey].Tag as AnalysisChartViewForm;

                    // WindowStateボタンを選択状態にする
                    Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];

                    for (int i = 0; i < windowPopupMenuTool.Tools.Count; i++)
                    {
                        if (!(windowPopupMenuTool.Tools[i] is Infragistics.Win.UltraWinToolbars.StateButtonTool)) continue;

                        Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[i];

                        if ((this.Main_TabControl.SelectedTab != null) && (chartViewKey == stateButtonTool.Key))
                        {
                            stateButtonTool.Checked = true;
                        }
                        else
                        {
                            stateButtonTool.Checked = false;
                        }
                    }

                }
            }
            finally
            {
                this.Cursor = nowCursor;
            }
        }


        /// <summary>
        /// タブクリエイト処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : タブフォームを生成します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void TabCreate(string key)
        {
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

            if (info == null) return;

            // --- ADD 2010/08/26 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
            }
            // --- ADD 2010/08/26 ----------<<<<<
            // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
            if (info.Form is IPrintConditionInpTypeTextOutControl)
            {
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
            }
            // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

            // 既にロード済み！
            if (info.Form != null) return;

            this.CreateTabForm(info);
        }

        /// <summary>
        /// ビューフォームタブクリエイト処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ビュータブフォームを生成します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private void ViewFormTabCreate(string key)
        {
            // ビュー表示元アセンブリ情報取得
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

            if (info == null) return;
            // --- ADD 2010/08/26 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
            }
            // --- ADD 2010/08/26 ----------<<<<<
            // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
            if (info.Form is IPrintConditionInpTypeTextOutControl)
            {
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
            }
            // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

            // 既にロード済み！
            if (info.ViewForm != null) return;

            this.CreateTabViewForm(info);
        }

        /// <summary>
        /// チャート用ビューフォームタブクリエイト処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : チャート用ビュータブフォームを生成します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        private void ChartViewFormTabCreate(string key, int number)
        {
            // ビュー表示元アセンブリ情報取得
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];

            if (info == null) return;
            // --- ADD 2010/08/26 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
            }
            // --- ADD 2010/08/26 ----------<<<<<
            // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
            if (info.Form is IPrintConditionInpTypeTextOutControl)
            {
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
            }
            // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

            // 既にロード済み！
            int index = number + 1;
            if (info.AnalysisChartViewFormLst.Count != 0 && index <= info.AnalysisChartViewFormLst.Count) return;

            this.CreateChartViewForm(info, number);
        }

        /// <summary>
        /// Tabフォーム生成処理
        /// </summary>
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : MDI子画面を生成する</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.17</br>
        /// </remarks>
        private Form CreateTabForm(FormControlInfo info)
        {
            Form form = null;

            form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(System.Windows.Forms.Form));
            if (form == null)
            {
                form = new Form();
            }

            if (form != null)
            {
                info.Form = form;

                // --- ADD 2010/08/26 ---------->>>>>
                if (info.Form is IPrintConditionInpTypeGuidExecuter)
                {
                    ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                    ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
                }
                // --- ADD 2010/08/26 ----------<<<<<
                // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
                if (info.Form is IPrintConditionInpTypeTextOutControl)
                {
                    ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                    ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
                }
                // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

                // タブコントロールに追加するタブページをインスタンス化する
                Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
                  new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

                // タブの外観を設定し、タブコントロールにタブを追加する
                Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

                dataviewTab.TabPage = dataviewTabPageControl;
                dataviewTab.Text = info.Name;
                dataviewTab.Key = info.Key;
                dataviewTab.Tag = form;
                dataviewTab.Appearance.Image = info.Icon;
                dataviewTab.Appearance.BackColor = Color.White;
                dataviewTab.Appearance.BackColor2 = Color.Lavender;
                dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                dataviewTab.ActiveAppearance.BackColor = Color.White;
                dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
                dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                //----------------------------------------------------------------------------//
                // 各種デリゲートイベント登録                                                 //
                //----------------------------------------------------------------------------//

                // ツールバーボタン制御イベント 
                if (form is IPrintConditionInpType)
                {
                    ((IPrintConditionInpType)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                }

                // --- 2010/08/16 ---------->>>>>
                if (form is IPrintConditionInpTypeGuidExecuter)
                {
                    ((IPrintConditionInpTypeGuidExecuter)form).ParentToolbarGuideSettingEvent += new ParentToolbarGuideSettingEventHandler(this.ParentToolbarGuideSettingEvent);
                }
                // --- 2010/08/16 ----------<<<<<

                // 拠点選択イベント
                if (form is IPrintConditionInpTypeSelectedSection)
                {
                    // 拠点オプションプロパティ
                    ((IPrintConditionInpTypeSelectedSection)form).IsOptSection = this._isOptSection;

                    // 本社機能プロパティ
                    ((IPrintConditionInpTypeSelectedSection)form).IsMainOfficeFunc = this._isMainOfficeFunc;

#if false
					// 計上拠点選択イベント
					this._checkedAddUpEvent   += new CheckedAddUpEventHandler(((IPrintConditionInpTypeSelectedSection)form).SelectedAddUpCd);
					
					// 初期拠点設定デリゲート
					this._initSelectSectionEvent += new InitSelectSectionEventHandler(((IPrintConditionInpTypeSelectedSection)form).InitSelectSection);
					
					// 拠点選択イベント
					this._checkedSectionEvent += new CheckedSectionEventHandler(((IPrintConditionInpTypeSelectedSection)form).CheckedSection);
#endif
                }

#if false
				// システム選択イベント
				if (form is IPrintConditionInpTypeSelectedSystem)
				{
					this._checkedSystemEvent  += new CheckedSystemEventHandler(((IPrintConditionInpTypeSelectedSystem)form).CheckedSystem);
				}
#endif

                this.Main_TabControl.Controls.Add(dataviewTabPageControl);
                this.Main_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                this.Main_TabControl.SelectedTab = dataviewTab;

                // フォームプロパティ変更
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                dataviewTabPageControl.Controls.Add(form);

                if (form is IPrintConditionInpType)
                {
                    ((IPrintConditionInpType)form).Show(info.Param);
                }
                else
                {
                    form.Show();
                }
                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            return form;
        }

        /// <summary>
        /// Tabビューフォーム生成処理
        /// </summary>
        /// <param>none</param>
        /// <returns>none</returns>
        /// <remarks>
        /// <br>Note       : MDI子画面を生成する</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.20</br>
        /// </remarks>
        private Form CreateTabViewForm(FormControlInfo info)
        {
            Form form = null;

            form = new SFANL07200UB();
            if (form == null)
            {
                form = new Form();
            }

            if (form != null)
            {
                info.ViewForm = form;

                // タブコントロールに追加するタブページをインスタンス化する
                Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
                  new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

                // タブの外観を設定し、タブコントロールにタブを追加する
                Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

                dataviewTab.TabPage = dataviewTabPageControl;
                dataviewTab.Text = info.Name + "ビュー";
                dataviewTab.Key = info.Key + TAB_VIEWFORM_ADDKEY;
                dataviewTab.Tag = form;
                dataviewTab.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW];
                dataviewTab.Appearance.BackColor = Color.White;
                dataviewTab.Appearance.BackColor2 = Color.Lavender;
                dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                dataviewTab.ActiveAppearance.BackColor = Color.White;
                dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
                dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

                ((SFANL07200UB)form).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
                // 帳票共通用フォームコントロールのキー情報を格納しておく
                ((SFANL07200UB)form).FormControlInfoKey = info.Key;

                this.Main_TabControl.Controls.Add(dataviewTabPageControl);
                this.Main_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });
                this.Main_TabControl.SelectedTab = dataviewTab;

                // フォームプロパティ変更
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                dataviewTabPageControl.Controls.Add(form);
                form.Show();
                form.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            return form;
        }

        /// <summary>
        /// チャートビューフォーム生成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : MDI子画面を生成する</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        private Form CreateChartViewForm(FormControlInfo info, int number)
        {
            AnalysisChartViewForm chartform = null;
            chartform = new AnalysisChartViewForm();

            info.AnalysisChartViewFormLst.Add(chartform);

            // タブコントロールに追加するタブページをインスタンス化する
            Infragistics.Win.UltraWinTabControl.UltraTabPageControl dataviewTabPageControl =
                new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();

            // タブの外観を設定し、タブコントロールにタブを追加する
            Infragistics.Win.UltraWinTabControl.UltraTab dataviewTab = new Infragistics.Win.UltraWinTabControl.UltraTab();

            dataviewTab.TabPage = dataviewTabPageControl;

            // 分析グラフが複数ページに分かれる場合
            if (info.AnalysisChartViewFormLst.Count > 1)
                dataviewTab.Text = info.Name + "分析グラフ(&" + number.ToString() + ")";
            else
                dataviewTab.Text = info.Name + "分析グラフ";
            dataviewTab.Key = info.Key + TAB_CHARTVIEWFORM_ADDKEY + number.ToString();
            dataviewTab.Tag = chartform;
            //				dataviewTab.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.];
            dataviewTab.Appearance.BackColor = Color.White;
            dataviewTab.Appearance.BackColor2 = Color.Lavender;
            dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            dataviewTab.ActiveAppearance.BackColor = Color.White;
            dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
            dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            ((AnalysisChartViewForm)chartform).ParentToolbarSettingEvent += new ParentToolbarSettingEventHandler(this.ParentToolbarSettingEvent);
            // 帳票共通用フォームコントロールのキー情報を格納しておく
            ((AnalysisChartViewForm)chartform).FormControlInfoKey = info.Key;
            ((AnalysisChartViewForm)chartform).Number = number;

            this.Main_TabControl.Controls.Add(dataviewTabPageControl);
            this.Main_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] { dataviewTab });

            this.Main_TabControl.SelectedTab = dataviewTab;

            // フォームプロパティ変更
            chartform.TopLevel = false;
            chartform.FormBorderStyle = FormBorderStyle.None;
            dataviewTabPageControl.Controls.Add(chartform);
            chartform.Show();
            chartform.Dock = System.Windows.Forms.DockStyle.Fill;

            return chartform;
        }

        #endregion

        #region ◆　指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
        /// <summary>
        /// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化する
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <param name="type">実装するクラス型</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : MDI子画面を生成する</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.01.20</br>
        /// </remarks>
        private object LoadAssemblyFrom(string asmname, string classname, Type type)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.LoadFrom(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
                    {
                        obj = Activator.CreateInstance(objType);
                    }
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            catch (System.Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    "Message=" + ex.Message + "\r\n" + "Trace  =" + ex.StackTrace + "\r\n" + "Source =" + ex.Source,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            return obj;
        }
        #endregion

        #region ◆　ツールバーの表示・有効設定
        /// <summary>
        /// ツールバーの表示・有効設定
        /// </summary>
        /// <param name="activeForm">アクティブなフォームのオブジェクト</param>
        /// <remarks>
        /// <br>Note       : ツールバーの表示・非表示、有効・無効設定を行います。</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.09</br>
        /// </remarks>
        private void ToolBarSetting(object activeForm)
        {

            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool;

            // --- 2010/08/16 ---------->>>>>
            int count = 0;

            for (int i = 0; i < this.Main_TabControl.Tabs.Count; i++)
            {
                if (this.Main_TabControl.Tabs[i].IsInView)
                {
                    count++;
                }
            }
            // F5:ガイド
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];

            if (buttonTool != null)
            {
                buttonTool.SharedProps.Enabled = false;
            }

            // F3:次頁
            buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_NEXTPAGEBUTTON_KEY];

            if (count > 1)
            {
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = true;
                }
            }
            else
            {
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
            }
            // --- 2010/08/16 ----------<<<<<

            if (activeForm != null)
            {
                if (activeForm is IPrintConditionInpType)
                {
                    // 印刷
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 不具合対応[8937]：セキュリティ管理設定で制限した機能が有効となっていない
                        {
                            buttonTool.SharedProps.Visible = ((IPrintConditionInpType)activeForm).VisibledPrintButton;
                            buttonTool.SharedProps.Enabled = ((IPrintConditionInpType)activeForm).CanPrint;
                        }
                    }

                    // 抽出
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRABUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 不具合対応[8937]：セキュリティ管理設定で制限した機能が有効となっていない
                        {
                            buttonTool.SharedProps.Visible = ((IPrintConditionInpType)activeForm).VisibledExtractButton;
                            buttonTool.SharedProps.Enabled = ((IPrintConditionInpType)activeForm).CanExtract;
                        }
                    }

                    // PDF
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 不具合対応[8937]：セキュリティ管理設定で制限した機能が有効となっていない
                        {
                            buttonTool.SharedProps.Visible = ((IPrintConditionInpType)activeForm).VisibledPdfButton;
                            buttonTool.SharedProps.Enabled = ((IPrintConditionInpType)activeForm).CanPdf;
                        }
                    }

                    // PDF履歴保存
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 不具合対応[8937]：セキュリティ管理設定で制限した機能が有効となっていない
                        {
                            buttonTool.SharedProps.Visible = ((IPrintConditionInpType)activeForm).VisibledPdfButton;
                            buttonTool.SharedProps.Enabled = false;
                        }
                    }

                    // >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                    // TODO:テキスト出力…ツールバー設定
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (activeForm is IPrintConditionInpTypeTextOutPut)
                        {
                            if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 不具合対応[8937]：セキュリティ管理設定で制限した機能が有効となっていない
                            {
                                buttonTool.SharedProps.Visible = this._isOptTextOutPut;
                                buttonTool.SharedProps.Enabled = ((IPrintConditionInpTypeTextOutPut)activeForm).CanTextOutPut;
                            }
                        }
                        else
                        {
                            buttonTool.SharedProps.Visible = false;
                            buttonTool.SharedProps.Enabled = false;
                        }
                    }
                    else
                    {
                        buttonTool.SharedProps.Visible = false;
                    }
                    // <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                    // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                    // 実行
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_UPDATEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        if (activeForm is IPrintConditionInpTypeUpdate)
                        {
                            buttonTool.SharedProps.Visible = true;
                            buttonTool.SharedProps.Enabled = ((IPrintConditionInpTypeUpdate)activeForm).CanUpdate;
                        }
                        else
                        {
                            buttonTool.SharedProps.Visible = false;
                            buttonTool.SharedProps.Enabled = false;
                        }
                    }
                    else
                    {
                        buttonTool.SharedProps.Visible = false;
                    }
                    // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                    // グラフ表示
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
                    if (activeForm is IPrintConditionInpTypeChart)
                    {
                        if (buttonTool != null)
                        {
                            if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 不具合対応[8937]：セキュリティ管理設定で制限した機能が有効となっていない
                            {
                                buttonTool.SharedProps.Visible = ((IPrintConditionInpTypeChart)activeForm).VisibledChartButton;
                                buttonTool.SharedProps.Enabled = ((IPrintConditionInpTypeChart)activeForm).CanChart;
                            }
                        }

                        // ユーザー設定 
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                        if (buttonTool != null)
                        {
                            if (buttonTool.SharedProps.Visible) // ADD 2008/03/16 不具合対応[8937]：セキュリティ管理設定で制限した機能が有効となっていない
                            {
                                buttonTool.SharedProps.Visible = true;
                                buttonTool.SharedProps.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        if (buttonTool != null)
                        {
                            buttonTool.SharedProps.Visible = false;
                        }

                        // ユーザー設定 
                        buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                        if (buttonTool != null)
                        {
                            buttonTool.SharedProps.Visible = false;
                        }
                    }

                }
                else if (activeForm is SFANL07200UB)
                {
                    // 印刷
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    //// 抽出
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRABUTTON_KEY];
                    //if (buttonTool != null) 
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}

                    //// PDF
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFBUTTON_KEY];
                    //if (buttonTool != null) 
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}

                    // PDF履歴保存
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = ((SFANL07200UB)activeForm).IsSave;
                    }

                    //// >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                    //// テキスト出力
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}
                    //// <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                    //// 設定
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}

                    //// グラフ表示
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}
                }
                else if (activeForm is AnalysisChartViewForm)
                {
                    // 印刷
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    // 抽出
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRABUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    //// PDF
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}

                    // PDF履歴保存
                    buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                    if (buttonTool != null)
                    {
                        buttonTool.SharedProps.Enabled = false;
                    }

                    //// テキスト出力
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}

                    //// 設定
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = true;
                    //}

                    //// グラフ表示
                    //buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
                    //if (buttonTool != null)
                    //{
                    //  buttonTool.SharedProps.Enabled = false;
                    //}
                }

            }
            else
            {
                // 印刷
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // 抽出
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_EXTRABUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // PDF
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // PDF履歴保存
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_PDFSAVEBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                // テキスト出力
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                // 実行
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_UPDATEBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
                // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                // グラフ表示
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GRAPHBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }

                // ユーザー設定 
                buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_SETUPBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Enabled = false;
                }
            }
        }
        #endregion

        #region ◆　ドックマネージャ各コントロールペインの表示・非表示制御
        /// <summary>
        /// ドックマネージャ各コントロールペインの表示・非表示制御
        /// </summary>
        /// <param name="activeForm">アクティブなフォームのオブジェクト</param>
        /// <remarks>
        /// <br>Note       : ドックマネージャ各コントロールペインの表示・非表示、有効・無効設定を行います。</br>
        /// <br>Programer  : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.04.22</br>
        /// </remarks>
        private void DockManagerCtrlPaneSetting(object activeFrom)
        {
            if (activeFrom != null)
            {
                // >>>>> 2007.07.17 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                //if (activeFrom is SFANL07200UB)
                //{
                // <<<<< 2007.07.17 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                if (!(activeFrom is IPrintConditionInpType))
                {
                    // 出力条件設定ペインを消す
                    this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Close();
                }
            }
            else
            {
                // 出力条件設定ペインを消す
                this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Close();
            }
        }
        #endregion

        #region ◆　選択タブ変更時ツリーノード選択処理
        /// <summary>
        /// 選択タブ変更時ツリーノード選択処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : タブが変更された場合に、変更されたタブに関連付け
        ///					 られたツリーノードを選択します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.09.12</br>
        /// </remarks>
        private void SelectedTabChangedNodeSelect()
        {
            Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Main_TabControl.SelectedTab;
            if (tab == null)
            {
                return;
            }

            string key = tab.Key;

            if (tab.Tag is SFANL07200UB)
            {
                SFANL07200UB targetObj = tab.Tag as SFANL07200UB;
                key = targetObj.FormControlInfoKey;
            }
            else if (tab.Tag is AnalysisChartViewForm)
            {
                AnalysisChartViewForm targetObj = tab.Tag as AnalysisChartViewForm;
                key = targetObj.FormControlInfoKey;
            }

            Infragistics.Win.UltraWinTree.UltraTreeNode utn = this.StartNavigatorTree.GetNodeByKey(key);
            if (utn == null)
            {
                return;
            }

            this.StartNavigatorTree.ActiveNode = utn;

            bool result;

            result = this.StartNavigatorTree.PerformAction(
              Infragistics.Win.UltraWinTree.UltraTreeAction.ClearAllSelectedNodes,
              false,
              false);
            if (!result)
            {
                return;
            }

            result = this.StartNavigatorTree.PerformAction(
              Infragistics.Win.UltraWinTree.UltraTreeAction.SelectActiveNode,
              false,
              false);
            if (!result)
            {
                return;
            }
        }
        #endregion

        #region ◆　印刷前メインフレーム条件チェック
        /// <summary>
        /// 印刷前メインフレーム側条件チェック
        /// </summary>
        /// <returns>[T:OK,F:NG]</returns>
        /// <remarks>
        /// <br>Note       : メインフレーム側抽出条件チェックを行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.02.15</br>
        /// </remarks>
        private bool IsPrint()
        {
            // --- ADD 2009/01/14 障害ID:9980対応------------------------------------------------------>>>>>
            // 拠点範囲チェック
            if ((this.tEdit_SectionCode_St.DataText.Trim() != "") && (this.tEdit_SectionCode_Ed.DataText.Trim() != ""))
            {
                string sectionCodeSt = this.tEdit_SectionCode_St.DataText.Trim();
                string sectionCodeEd = this.tEdit_SectionCode_Ed.DataText.Trim();

                if (String.Compare(sectionCodeSt, sectionCodeEd) > 0)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, "出力拠点の範囲が不正です。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    this.tEdit_SectionCode_St.Focus();
                    return false;
                }
            }
            // --- ADD 2009/01/14 障害ID:9980対応------------------------------------------------------<<<<<

            // 拠点選択チェック		
            if (this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible)
            {
                bool isSecCheck = false;
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
                {
                    if (utn.CheckedState == CheckState.Checked)
                    {
                        isSecCheck = true;
                        break;
                    }
                }

                if (!isSecCheck)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, "出力対象拠点は必ず一つはチェックしてください。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }

            // システム選択チェック
            if (this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible)
            {
                bool isSystem = false;
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.System_UTree.Nodes)
                {
                    if (utn.CheckedState == CheckState.Checked)
                    {
                        isSystem = true;
                        break;
                    }
                }

                if (!isSystem)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, "出力対象システムは必ず一つはチェックしてください。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region ◆　制御機能拠点取得
        /// <summary>
        /// 制御機能拠点取得
        /// </summary>
        /// <param name="sectionCode">対象拠点コード</param>
        /// <param name="ctrlFuncCode">取得する制御機能コード</param>
        /// <param name="ctrlSectionCode">対象制御拠点コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 該当拠点の拠点制御情報の読込を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.01</br>
        /// </remarks>
        private int GetOwnSeCtrlCode(string sectionCode, int ctrlFuncCode, out string ctrlSectionCode)
        {
            // DEL 2010/05/11 MANTIS対応[15358]：1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正 ---------->>>>>
            // ADD 2009/12/25 MANTIS対応[14310]：拠点マスタに1拠点のみでの拠点範囲指定の不正 ---------->>>>>
            //// 拠点が一つの場合、その拠点に固定
            //if (this.Section_UTree.Nodes.Count.Equals(1))
            //{
            //    string theSectionCode = this.tEdit_SectionCode_St.Text.Trim();
            //    if (!theSectionCode.Equals(sectionCode.Trim()))
            //    {
            //        ctrlSectionCode = this.tEdit_SectionCode_St.Text;
            //        return 0;
            //    }
            //}
            // ADD 2009/12/25 MANTIS対応[14310]：拠点マスタに1拠点のみでの拠点範囲指定の不正 ----------<<<<<
            // DEL 2010/05/11 MANTIS対応[15358]：1拠点しか登録がない場合、拠点の範囲指定が入力できないので、入力可能へ修正 ----------<<<<<

            // 対象制御拠点の初期値は自拠点
            ctrlSectionCode = sectionCode;

            SecInfoSet secInfoSet;

            int status = this._secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if (secInfoSet != null)
                    {
                        //						ctrlSectionCode = secInfoSet.SectionCode;
                        ctrlSectionCode = secInfoSet.SectionCode.TrimEnd();			// 2006.09.04 Y.Sasaki ADD

                        // >>>>> 2006.09.26 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                        //「全拠点: 000000」だったら「全社: 0」に置き換える
                        if (ctrlSectionCode.Equals(CT_AllCtrlFuncSecCode))
                        {
                            ctrlSectionCode = CT_AllSectionCode;
                        }
                        // <<<<< 2006.09.26 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                    }
                    break;
                default:
                    break;
            }

            return status;
        }
        #endregion

#if false
//		/// <summary>
//		/// 共通抽出条件設定処理
//		/// </summary>
//		/// <param name="target">設定対象object</param>
//		/// <remarks>
//		/// <br>Note       : 共通抽出条件を設定します。</br>
//		/// <br>Programmer : 18012 Y.Sasaki</br>
//		/// <br>Date       : 2006.03.27</br>
//		/// </remarks>
//		private void SetExtractCondtnUI(object target)
//		{
//			// 抽出条件取得・設定インタフェースを実装しているか
//			if (target is IPrintConditionInpTypeCondition)
//			{
//				object objCondtn = ((IPrintConditionInpTypeCondition)target).ObjExtract;
//				
//				// 抽出条件基本クラスを継承している
//				if (objCondtn != null && objCondtn is ExtractionCondtnUI)
//				{
//					// 帳票出力設定
//					((ExtractionCondtnUI)objCondtn).PrtOutSet = this._prtOutSet;
//				}
//			}
//		}
#endif

        #region ◆　ウィンドウステートボタンツール構築処理
        /// <summary>
        /// ウィンドウステートボタンツール構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ウインドウ表位置状態ボタンを作成します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void CreateWindowStateButtonTools()
        {
            Infragistics.Win.UltraWinToolbars.PopupMenuTool windowPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_WINDOW_KEY];
            Infragistics.Win.UltraWinToolbars.PopupMenuTool formsPopupMenuTool = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.Main_ToolbarsManager.Tools[TOOLBAR_FORMS_KEY];

            windowPopupMenuTool.ResetTools();
            formsPopupMenuTool.ResetTools();

            // 「ウィンドウを初期状態に戻す」　ボタンツール追加
            if (!this.Main_ToolbarsManager.Tools.Exists(TOOLBAR_RESETBUTTON_KEY))
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool resetButtonTool = new Infragistics.Win.UltraWinToolbars.ButtonTool(TOOLBAR_RESETBUTTON_KEY);
                resetButtonTool.SharedProps.Caption = "ウィンドウを初期状態に戻す(&R)";
                resetButtonTool.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.WindowResetButtonTool_ToolClick);
                this.Main_ToolbarsManager.Tools.Add(resetButtonTool);
            }
            windowPopupMenuTool.Tools.AddTool(TOOLBAR_RESETBUTTON_KEY);

            for (int i = 0; i < this.Main_TabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Main_TabControl.Tabs[i];

                if (!tab.Visible) continue;

                string key = tab.Key;

                if (this.Main_ToolbarsManager.Tools.Exists(key))
                {
                    windowPopupMenuTool.Tools.AddTool(key);
                    formsPopupMenuTool.Tools.AddTool(key);
                }
                else
                {
                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = new Infragistics.Win.UltraWinToolbars.StateButtonTool(key, "TabWindow");
                    stateButtonTool.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark;
                    stateButtonTool.SharedProps.Caption = tab.Text;
                    stateButtonTool.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.WindowStateButtonTool_ToolClick);
                    stateButtonTool.Tag = true;
                    this.Main_ToolbarsManager.Tools.Add(stateButtonTool);

                    windowPopupMenuTool.Tools.AddTool(key);
                    formsPopupMenuTool.Tools.AddTool(key);
                }

                if ((i == 0) && (windowPopupMenuTool.Tools.Exists(key)))
                {
                    Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)windowPopupMenuTool.Tools[key];
                    stateButtonTool.InstanceProps.IsFirstInGroup = true;
                }
            }
        }
        #endregion

        #region ◆　「ウィンドウを初期値に戻す」ボタンクリック時イベント
        /// <summary>
        /// ウィンドウステートボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ウィンドウステートボタンクリック時に発生します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void WindowResetButtonTool_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (this._dockMemoryStream == null)
            {
                return;
            }

            this._dockMemoryStream.Position = 0;

            this.Main_DockManager.LoadFromBinary(this._dockMemoryStream);
        }
        #endregion

        #region ◆　ウィンドウステートボタンクリックイベント
        /// <summary>
        /// ウィンドウステートボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note       : ウィンドウステートボタンクリック時に発生します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void WindowStateButtonTool_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if ((this.Main_TabControl.Tabs.Exists(e.Tool.Key)))
            {
                if (!(e.Tool is Infragistics.Win.UltraWinToolbars.StateButtonTool)) return;

                Infragistics.Win.UltraWinToolbars.StateButtonTool stateButtonTool = (Infragistics.Win.UltraWinToolbars.StateButtonTool)e.Tool;
                if (stateButtonTool.Checked)
                {
                    this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[e.Tool.Key];

                    // ナビゲータメニューモード
                    if (this._navigaterMenuMode)
                    {
                        this.Main_TabControl.ContextMenu = this.TabControl_contextMenu;
                    }
                    else
                    {
                        int index = e.Tool.Key.ToString().IndexOf(TAB_VIEWFORM_ADDKEY);
                        if (index == -1)
                        {
                            // 条件入力
                            this.Main_TabControl.ContextMenu = null;
                        }
                        else
                        {
                            // プレビュ画面
                            this.Main_TabControl.ContextMenu = this.TabControl_contextMenu;
                        }
                    }
                    Debug.WriteLine(this._formControlInfoTable.Contains(this.Main_TabControl.SelectedTab.Key) ? "OK" : "NG");
                    Form selectedForm = this._formControlInfoTable[this.Main_TabControl.SelectedTab.Key] as Form;

                    // ADD 2008/10/02 不具合対応[5774]---------->>>>>
                    if (selectedForm == null)
                    {
                        if (this._formControlInfoTable.Contains(this.Main_TabControl.SelectedTab.Key))
                        {
                            FormControlInfo formInfo = this._formControlInfoTable[this.Main_TabControl.SelectedTab.Key] as FormControlInfo;
                            if (formInfo != null) selectedForm = formInfo.Form;
                        }
                    }

                    if (this.Main_TabControl.ActiveTab != null)
                    {
                        this.Text = MAIN_TITLE + "－" + this.Main_TabControl.ActiveTab.Text;
                        return;
                    }
                    // ADD 2008/10/02 不具合対応[5774]----------<<<<<

                    if (selectedForm != null)
                    {
                        this.Text = MAIN_TITLE + "－" + selectedForm.Text;
                    }
                }
            }
        }
        #endregion

        #region ◆　タブ表示・非表示制御
        /// <summary>
        /// タブ表示／非表示化処理
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="hidden">true:表示 false:非表示</param>
        /// <remarks>
        /// <br>Note       : タブの表示／非表示を制御します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void TabVisibleChange(string key, bool visible)
        {
            for (int i = 0; i < this.Main_TabControl.Tabs.Count; i++)
            {
                Infragistics.Win.UltraWinTabControl.UltraTab tab = this.Main_TabControl.Tabs[i];

                if (tab.Key == key)
                {
                    tab.Visible = visible;
                    this.NodeSelectChaneg(key, visible);
                }
            }
        }
        #endregion

        #region ◆　ナビゲーションの該当キーノード選択状態変更
        /// <summary>
        /// ナビゲーションの該当キーノード選択状態変更
        /// </summary>
        /// <param name="key">キー</param>
        /// <remarks>
        /// <br>Note       : ナビゲーションの該当キーノード選択状態を制御します。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2006.03.28</br>
        /// </remarks>
        private void NodeSelectChaneg(string key, bool isSelected)
        {
            // 該当キーのノードを取得
            Infragistics.Win.UltraWinTree.UltraTreeNode node = this.StartNavigatorTree.GetNodeByKey(key);

            if (node != null)
            {
                if (isSelected)
                {
                    node.Override.NodeAppearance.ForeColor = Color.Red;
                }
                else
                {
                    node.Override.NodeAppearance.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        #region ◆　エラーメッセージ表示処理
        /// <summary>
        /// メッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">ステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">デフォルトフォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージの表示を行います。</br>
        /// <br>Programmer : 18012 Y.Sasaki</br>
        /// <br>Date       : 2005.01.19</br>
        /// </remarks>
        internal static DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, CT_PGID, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        #region ◆　チャートタブフォームクリア

        /// <summary>
        /// チャートタブフォームクリア
        /// </summary>
        /// <param name="info">帳票共通用フォームコントロールクラス</param>
        private void ClearChartTabForm(FormControlInfo info)
        {
            if (info == null) return;
            // --- ADD 2010/08/26 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
            }
            // --- ADD 2010/08/26 ----------<<<<<
            // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
            if (info.Form is IPrintConditionInpTypeTextOutControl)
            {
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
            }
            // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<
            if (info.AnalysisChartViewFormLst == null || info.AnalysisChartViewFormLst.Count == 0) return;

            try
            {
                this.Main_TabControl.BeginUpdate();

                foreach (AnalysisChartViewForm viewFrm in info.AnalysisChartViewFormLst)
                {
                    string tabKey = info.Key + TAB_CHARTVIEWFORM_ADDKEY + viewFrm.Number.ToString();

                    // タブの削除
                    if (this.Main_TabControl.Tabs.Exists(tabKey))
                        this.Main_TabControl.Tabs.Remove(this.Main_TabControl.Tabs[tabKey]);

                    // ウィンドウメニューの削除
                    if (this.Main_ToolbarsManager.Tools.Exists(tabKey))
                        this.Main_ToolbarsManager.Tools.Remove(this.Main_ToolbarsManager.Tools[tabKey]);

                    viewFrm.Clear();
                }

                info.AnalysisChartViewFormLst.Clear();
            }
            finally
            {
                this.Main_TabControl.EndUpdate();
                this.Update();
            }
        }

        #endregion

        #region	◆ DEBUG 用コード
#if DEBUG
        private DateTime _dtime_s, _dtime_e;
        private System.IO.FileStream _fs = null;
        private System.IO.StreamWriter _sw = null;

        private void DebugLogWrite(int mode, string msg)
        {
            this._fs = new System.IO.FileStream("SFANL07200U_Log.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
            this._sw = new System.IO.StreamWriter(this._fs, System.Text.Encoding.GetEncoding("shift_jis"));
            if (mode == 0)
            {

                this._dtime_s = DateTime.Now;
                TimeSpan ts = this._dtime_s.Subtract(this._dtime_s);
                string s = String.Format("{0,-20} {1,-5} ==> {2,-20} [0] {3} \n",
                    this._dtime_s, this._dtime_s.Millisecond, ts.ToString(), msg);
                this._sw.WriteLine(s);
                //				System.Diagnostics.Debug.WriteLine( s );
            }
            else if (mode == 1)
            {
                this._dtime_e = DateTime.Now;
                TimeSpan ts = this._dtime_e.Subtract(this._dtime_s);
                string s = string.Format("{0,-20} {1,-5} ==> {2,-20} [1] {3} \n",
                    this._dtime_e, this._dtime_e.Millisecond, ts.ToString(), msg);

                this._sw.WriteLine(s);
                //				System.Diagnostics.Debug.WriteLine( s );

                this._dtime_s = this._dtime_e;
            }
            else if (mode == 9)
            {
            }
            this._sw.Close();
            this._fs.Close();
        }
#endif
        #endregion

        #endregion

        // ===============================================================================
        // コントロールイベント
        // ===============================================================================
        #region control event
        /// <summary>
        /// メインフレームのLOADイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : イベントの解説を記述します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2005.09.09</br>
        /// </remarks>
        private void SFANL07200UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            mControlScreenSkin.LoadSkin();
            mControlScreenSkin.SettingScreenSkin(this);

            this._dockMemoryStream = new MemoryStream();

            // 起動ナビゲーターを消しておく
            this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Close();

            this._isEvent = false;
            int status;
            string message = "";
            try
            {
                // 初期設定データ読込
                status = this.InitialSettingDBRead(out message);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                        message,
                        status,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                    this.Close();
                    return;
                }

                // 起動ナビゲーター構築
                this.ConstructionTreeNode();

                // プログラム情報テーブル構築
                status = this.CreateFormControlInfo();
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                        "起動パラメータが不正です。!!",//ahn
                        -1,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);

                    this.Close();
                    return;
                }

                // ドックマネージャー初期設定
                this.InitSettingDockManager();

                // ツールバー初期設定
                this.InitSettingToolBar();

                // ツールバーボタン状態設定
                this.ToolBarSetting(null);

                // 拠点情報設定処理
                this.InitSettingSectionTree();

                // システム情報設定処理
                this.InitSettingSystemTree();

                // 出力帳票管理履歴画面設定
                this.InitSettingPdfHistorySubForm();

                // 出力条件選択ペイン表示制御
                this.CheckExplorerBarGroup();

                // ウインドウボタン作成処理
                this.CreateWindowStateButtonTools();
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message,
                    -1,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);
            }
            finally
            {
                // 初期拠点選択表示状態保存
                this._isDefaultSectionSelect = this.SelectExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible;

                // 初期システム選択表示状態保存
                this._isDefaultSystemSelect = this.SelectExplorerBar.Groups[EXPLORERBAR_SYSTEMLIST].Visible;

                // 単体起動・ナビ起動判定処理
                this.CheckNaviOrSingleStart();

                // DockManagerの状態を保持する
                this.Main_DockManager.SaveAsBinary(this._dockMemoryStream);

                this._isEvent = true;
            }

            // 出力対象拠点の範囲の初期設定
            this.InitSectionRange(true);    // 2008.09.05 T.Kudoh ADD
        }

        /// <summary>
        /// ツリーノードダブルクリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : 起動ナビゲーターのダブルクリックイベントです。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void StartNavigatorTree_DoubleClick(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinTree.UltraTreeNode doubleClickedNode =
                this.StartNavigatorTree.GetNodeFromPoint(this._lastMouseDown);

            if (doubleClickedNode == null) return;

            FormControlInfo info = this._formControlInfoTable[doubleClickedNode.Key.ToString()] as FormControlInfo;
            if (info == null) return;
            // --- ADD 2010/08/26 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
            }
            // --- ADD 2010/08/26 ----------<<<<<

            // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
            if (info.Form is IPrintConditionInpTypeTextOutControl)
            {
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
            }
            // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

            if (doubleClickedNode.Level == 2)
            {
                // >>>>> 2008.09.05 T.Kudoh ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                {
                    if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                        EntityUtil.CategoryCode.Report,
                        MyOpeCtrlMap.AddController(info.AssemblyID),
                        info.AssemblyID,
                        info.Name
                    ))
                    {
                        return; // 起動不可のため強制終了
                    }
                }
                // <<<<< 2008.09.05 T.Kudoh ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                Infragistics.Win.UltraWinTree.UltraTreeNode node = doubleClickedNode;

                // 条件入力画面UI起動処理
                ShowChildInputForm(node.Key.ToString());

                doubleClickedNode.Override.NodeAppearance.ForeColor = Color.Red;

                BeginControllingByOperationAuthority(info.AssemblyID);  // 2008.09.05 T.Kudoh ADD

                // --- ADD 譚洪 2021/01/04 PMKOBETSU-4109の対応 ------>>>>
                try
                {
                    try
                    {
                        // クライアントログ出力部品初期化
                        if (clientLogTextOut == null)
                        {
                            clientLogTextOut = new ClientLogTextOut();
                        }
                    }
                    catch
                    {
                        // 後続処理に影響しないよう例外キャッチ
                    }

                    try
                    {
                        // 操作履歴ログ出力部品初期化
                        if (operationHistoryLog == null)
                        {
                            operationHistoryLog = new OperationHistoryLog();
                        }
                    }
                    catch (Exception ex)
                    {
                        // エラー時ログ出力
                        try
                        {
                            if (clientLogTextOut != null)
                            {
                                clientLogTextOut.Output(ex.Source, ErrMessageInit, (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                            }
                        }
                        catch
                        {
                            // 後続処理に影響しないよう例外キャッチ
                        }
                    }

                    // ログ出力を行う
                    string dateMessage = string.Format(DateMessage, MAIN_TITLE, node.Parent.Text, node.Text, info.AssemblyID);
                    if (operationHistoryLog != null)
                    {
                        // 操作履歴ログ出力
                        operationHistoryLog.WriteOperationLog(this, DateTime.Now, (LogDataKind)MenuLog,
                        CT_PGID, MAIN_TITLE, MethodName, OperationCode, (int)ConstantManagement.MethodResult.ctFNC_NORMAL, dateMessage, string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    // エラー時ログ出力
                    try
                    {
                        if (clientLogTextOut != null)
                        {
                            clientLogTextOut.Output(ex.Source, MethodName + ErrMessage, (int)ConstantManagement.MethodResult.ctFNC_ERROR, ex);
                        }
                    }
                    catch
                    {
                        // 後続処理に影響しないよう例外キャッチ
                    }
                }
                // --- ADD 譚洪 2021/01/04 PMKOBETSU-4109の対応 ------<<<<
            }
            // --- 2010/08/16 ---------->>>>>
            if (info.Form is IPrintConditionInpTypeGuidExecuter)
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool guideButtonTool;
                // F3:次頁
                guideButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
                if (guideButtonTool != null)
                {
                    guideButtonTool.SharedProps.Visible = true;
                }
            }

            if (this.Main_TabControl.Tabs.Count > 1)
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool nextPageButtonTool;
                // F3:次頁
                nextPageButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_NEXTPAGEBUTTON_KEY];
                if (nextPageButtonTool != null)
                {
                    nextPageButtonTool.SharedProps.Enabled = true;
                }
            }
            // --- 2010/08/16 ----------<<<<<
        }

        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        /// <param name="assemblyId">アセンブリID</param>
        /// <remarks>
        /// <br>Note　　　  : 操作権限に応じたボタン制御の対応</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void BeginControllingByOperationAuthority(string assemblyId)
        {
            #region <Guard Phrase/>

            if (!MyOpeCtrlMap.ContainsKey(assemblyId)) return;

            #endregion  // <Guard Phrase/>

            // ツールボタンの操作権限の制御設定
            List<ToolButtonInfo> toolButtonInfoList = new List<ToolButtonInfo>();

            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PRINTBUTTON_KEY, ReportFrameOpeCode.Print, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_EXTRABUTTON_KEY, ReportFrameOpeCode.Extract, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PDFBUTTON_KEY, ReportFrameOpeCode.OutputPDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_PDFSAVEBUTTON_KEY, ReportFrameOpeCode.SavePDF, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_TEXTOUTPUTBUTTON_KEY, ReportFrameOpeCode.OutputText, false));
            //toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_UPDATEBUTTON_KEY, ReportFrameOpeCode.OutputText, false)); // [実行]ボタンは操作権限制御の管理外
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_GRAPHBUTTON_KEY, ReportFrameOpeCode.ShowGraph, false));
            toolButtonInfoList.Add(new ReportToolButtonInfo(TOOLBAR_SETUPBUTTON_KEY, ReportFrameOpeCode.Setup, true));

            MyOpeCtrlMap[assemblyId].MyOpeCtrl.AddControlItem(this.Main_ToolbarsManager, toolButtonInfoList);

            // 操作権限の制御を開始
            MyOpeCtrlMap[assemblyId].MyOpeCtrl.BeginControl();
        }

        /// <summary>
        /// Control.MouseDown イベント(StartNavigatorTree)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ツリーコントロールにてマウスボタンがクリックされたときに発生します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void StartNavigatorTree_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this._lastMouseDown = new Point(e.X, e.Y);
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : ツールバークリック時に発生します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            // フォームからUiSetControlを探す	
            UiSetControl uiSetControl = UiSetControl.SearchFromOwner(this);
            if (uiSetControl != null)
            {
                // 一括ゼロ詰め処理	
                uiSetControl.SettingAllControlsZeroPaddedText();
            }
            switch (e.Tool.Key)
            {
                case TOOLBAR_ENDBUTTON_KEY:		// 終了
                    {
                        this.Close();
                        break;
                    }

                case TOOLBAR_PRINTBUTTON_KEY:		// 印刷
                case TOOLBAR_PDFBUTTON_KEY:		// PDF出力
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        // 条件チェック
                        if (!this.IsPrint()) return;

                        int printMode = (int)emPrintMode.emPrinter;

                        switch (e.Tool.Key)
                        {
                            case TOOLBAR_PRINTBUTTON_KEY:
                                // 通常印刷
                                printMode = (int)emPrintMode.emPrinterAndPDF;
                                break;
                            case TOOLBAR_PDFBUTTON_KEY:
                                // PDF表示
                                printMode = (int)emPrintMode.emPDF;
                                break;
                            default:
                                break;
                        }

                        // アクティブタブからフォームを取得
                        string key = this.Main_TabControl.ActiveTab.Key.ToString();

                        if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                        {
                            key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }
                        else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                        {
                            key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }

                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        System.Windows.Forms.Form activeForm = info.Form;

                        if (activeForm is IPrintConditionInpType)
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();
                            printInfo.printmode = printMode;
                            printInfo.pdfopen = false;
                            printInfo.pdftemppath = "";

                            IPrintConditionInpType childObj = activeForm as IPrintConditionInpType;

                            // 印刷前チェック
                            if (!childObj.PrintBeforeCheck()) return;

                            //            // 共通抽出条件設定 
                            //						this.SetExtractCondtnUI(activeForm);

                            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            Object parameter = (object)printInfo;

                            // チャート出力あり？
                            if (activeForm is IPrintConditionInpTypeChart)
                            {
                                // 抽出処理
                                status = childObj.Extract(ref parameter);
                                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                    return;
                            }

                            // 印刷処理
                            status = childObj.Print(ref parameter);

                            switch (status)
                            {
                                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                                    {
                                        // PDF表示の場合
                                        if (printMode == (int)emPrintMode.emPDF)
                                        {
                                            // ＰＤＦ削除リストに追加
                                            if (printInfo.pdftemppath != "")
                                            {
                                                if (!this._delPDFList.Contains(printInfo.pdftemppath))
                                                {
                                                    this._delPDFList.Add(printInfo.pdftemppath, printInfo.pdftemppath);
                                                }
                                            }

                                            // ＰＤＦ画面表示
                                            if (printInfo.pdfopen)
                                            {
                                                System.Windows.Forms.Form frm = null;

                                                this.ViewFormTabCreate(info.Key);

                                                this.ViewFormTabActive(info.Key, ref frm);

                                                SFANL07200UB viewFrm = frm as SFANL07200UB;

                                                if (viewFrm != null)
                                                {
                                                    viewFrm.IsSave = true;
                                                    viewFrm.PrintKey = printInfo.key;
                                                    viewFrm.PrintName = printInfo.prpnm;
                                                    viewFrm.PrintDetailName = printInfo.prpnm;
                                                    viewFrm.PrintPDFPath = printInfo.pdftemppath;

                                                    viewFrm.ShowPDFPreview((Object)printInfo.pdftemppath);
                                                }

                                                this.ToolBarSetting(viewFrm);
                                                this.DockManagerCtrlPaneSetting(viewFrm);
                                            }
                                        }
                                        break;
                                    }
                                case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case TOOLBAR_EXTRABUTTON_KEY:		// 抽出
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        // 条件チェック
                        if (!this.IsPrint()) return;

                        string key = this.Main_TabControl.ActiveTab.Key.ToString();

                        if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                        {
                            key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }
                        else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                        {
                            key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }

                        // アクティブタブからフォームを取得
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        System.Windows.Forms.Form activeForm = info.Form;

                        if (activeForm is IPrintConditionInpType)
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();

                            IPrintConditionInpType childObj = activeForm as IPrintConditionInpType;

                            // 印刷前チェック
                            if (!childObj.PrintBeforeCheck()) return;

                            //						// 共通抽出条件設定 
                            //						this.SetExtractCondtnUI(activeForm);

                            // 抽出処理
                            Object parameter = (object)printInfo;
                            int status = childObj.Extract(ref parameter);

                            // ツールバーボタン設定
                            this.ToolBarSetting(activeForm);
                            // ドックマネジャー設定
                            this.DockManagerCtrlPaneSetting(activeForm);
                        }
                        break;
                    }

                case TOOLBAR_PDFSAVEBUTTON_KEY:	// ＰＤＦ履歴保存
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        this.SavePDF(this.Main_TabControl.ActiveTab.Key.ToString());
                        break;
                    }
                // >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                case TOOLBAR_TEXTOUTPUTBUTTON_KEY:	// TODO:テキスト出力…機能呼出し
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        // 条件チェック
                        if (!this.IsPrint()) return;

                        string key = this.Main_TabControl.ActiveTab.Key.ToString();

                        if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                        {
                            key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }
                        else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                        {
                            key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }

                        // アクティブタブからフォームを取得
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        System.Windows.Forms.Form activeForm = info.Form;

                        if (activeForm is IPrintConditionInpType && activeForm is IPrintConditionInpTypeTextOutPut)
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();

                            IPrintConditionInpType childObj = activeForm as IPrintConditionInpType;

                            // 印刷前チェック
                            if (!childObj.PrintBeforeCheck()) return;

                            object parameter = (object)printInfo;

                            // 抽出処理
                            int status = childObj.Extract(ref parameter);
                            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                return;

                            IPrintConditionInpTypeTextOutPut outPutObj = activeForm as IPrintConditionInpTypeTextOutPut;

                            // パラメータ設定
                            printInfo.selectInfoCode = 1;			// 選択情報区分(１：テキスト)

                            // テキスト出力処理
                            outPutObj.OutPutText(ref parameter);
                        }
                        break;
                    }
                // <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                case TOOLBAR_UPDATEBUTTON_KEY:	// 実行
                    {
                        // 条件チェック
                        if (!this.IsPrint()) return;

                        string key = this.Main_TabControl.ActiveTab.Key.ToString();

                        if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                        {
                            key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }
                        else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                        {
                            key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }

                        // アクティブタブからフォームを取得
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        System.Windows.Forms.Form activeForm = info.Form;

                        if (activeForm is IPrintConditionInpType && activeForm is IPrintConditionInpTypeUpdate)
                        {
                            SFCMN06002C printInfo = new SFCMN06002C();
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.09.02 ADD
                            // 印刷ボタン押下時と同様にPrintModeをセットする。
                            printInfo.printmode = (int)emPrintMode.emPrinterAndPDF;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.09.02 ADD

                            IPrintConditionInpType childObj = activeForm as IPrintConditionInpType;

                            // 印刷前チェック
                            if (!childObj.PrintBeforeCheck()) return;

                            object parameter = (object)printInfo;

                            // 抽出処理
                            int status = childObj.Extract(ref parameter);
                            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                return;

                            IPrintConditionInpTypeUpdate updateObj = activeForm as IPrintConditionInpTypeUpdate;

                            // パラメータ設定
                            printInfo.selectInfoCode = 1;			// 選択情報区分(１：テキスト)

                            // 実行処理
                            updateObj.Update(ref parameter);
                        }
                        break;
                    }
                // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                case TOOLBAR_GRAPHBUTTON_KEY:	// グラフ表示
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        // 共通処理中画面生成
                        SFCMN00299CA progressForm = new SFCMN00299CA();
                        progressForm.DispCancelButton = false;
                        progressForm.Title = "分析チャート作成中";
                        progressForm.Message = "現在、分析チャート作成中です．．．";

                        try
                        {
                            // 条件チェック
                            if (!this.IsPrint()) return;

                            string key = this.Main_TabControl.ActiveTab.Key.ToString();

                            if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                            {
                                key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                            }
                            else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                            {
                                key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                            }

                            // アクティブタブからフォームを取得
                            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                            System.Windows.Forms.Form activeForm = info.Form;

                            if (activeForm is IPrintConditionInpTypeChart)
                            {

                                // 帳票共通インタフェースを実装しているなら抽出処理を行う
                                if (activeForm is IPrintConditionInpType)
                                {
                                    IPrintConditionInpType extraObj = activeForm as IPrintConditionInpType;

                                    // 印刷前チェック
                                    if (!extraObj.PrintBeforeCheck()) return;

                                    // >>>>> 2007.07.24 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                                    // 画面内容を確定させてやる
                                    this.Main_TabControl.Focus();
                                    // <<<<< 2007.07.24 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                                    // チャートタブのクリア
                                    this.ClearChartTabForm(info);

                                    // チャート出力あり？
                                    if (activeForm is IPrintConditionInpTypeChart)
                                    {
                                        // 抽出処理
                                        object para = 0;
                                        int status = extraObj.Extract(ref para);
                                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                            return;
                                    }
                                }

                                // 抽出条件パラメータを取得
                                object paramater = null;
                                if (activeForm is IPrintConditionInpTypeCondition)
                                {
                                    paramater = ((IPrintConditionInpTypeCondition)activeForm).ObjExtract;
                                }

                                IPrintConditionInpTypeChart childObj = activeForm as IPrintConditionInpTypeChart;

                                // チャート抽出クラスメンバを取得する
                                List<IChartExtract> chartExtractMember;
                                childObj.GetChartExtractMember(out chartExtractMember);

                                if (chartExtractMember == null) return;

                                // 分析チャートビューフォーム数取得（一つの分析チャートビューフォームに対して最大４つまで格納）
                                int viewFormCount = chartExtractMember.Count / 4;
                                if ((chartExtractMember.Count % 4) != 0)
                                {
                                    viewFormCount++;
                                }

                                Form chartViewFrm = null;

                                // 共通処理中画面表示
                                progressForm.Show(this);

                                // 分析チャートビューフォーム情報管理クラス生成
                                for (int ix = 0; ix < viewFormCount; ix++)
                                {
                                    this.ChartViewFormTabCreate(info.Key, ix);
                                    this.ChartViewFormTabActive(info.Key, ix, ref chartViewFrm);

                                    List<IChartExtract> extraList = new List<IChartExtract>();

                                    // 該当チャート画面に引き渡すチャートパラメータ作成
                                    for (int i = ix * 4; i < (ix + 1) * 4; i++)
                                    {
                                        if ((i + 1) > chartExtractMember.Count)
                                            break;

                                        extraList.Add(chartExtractMember[i]);
                                    }

                                    // チャート表示
                                    ((AnalysisChartViewForm)chartViewFrm).ChartExtractList = extraList;
                                    ((AnalysisChartViewForm)chartViewFrm).ShowMe(paramater);

                                }

                                // ツールバーボタン設定
                                this.ToolBarSetting(chartViewFrm);

                                // ドックマネジャー設定
                                this.DockManagerCtrlPaneSetting(chartViewFrm);
                            }
                        }
                        finally
                        {
                            // 共通処理中画面終了
                            progressForm.Close();
                        }
                        break;
                    }
                case TOOLBAR_SETUPBUTTON_KEY:	// ユーザー設定
                    {
                        if (this._userSetupFrm == null)
                            this._userSetupFrm = new SFANL07200UE();

                        this._userSetupFrm.ShowDialog();
                        break;
                    }
                // --- 2010/08/16 ---------->>>>>
                case TOOLBAR_GUIDEBUTTON_KEY:	// F5:ガイド
                    {
                        string key = this.Main_TabControl.ActiveTab.Key.ToString();

                        if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                        {
                            key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }
                        else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                        {
                            key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                        }

                        // アクティブタブからフォームを取得
                        FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                        System.Windows.Forms.Form activeForm = info.Form;

                        if (activeForm is IPrintConditionInpTypeGuidExecuter)
                        {
                            ((IPrintConditionInpTypeGuidExecuter)activeForm).ExcuteGuide(sender, e);
                        }

                        break;
                    }
                case TOOLBAR_NEXTPAGEBUTTON_KEY:	// F3：次頁
                    {
                        int count = 0;
                        int maxIndex = 0;

                        for (int i = 0; i < this.Main_TabControl.Tabs.Count; i++) {
                            if (this.Main_TabControl.Tabs[i].Visible) {
                                count++;
                                maxIndex = i;
                            }
                        }

                        if (this.Main_TabControl.SelectedTab.Index < maxIndex)
                        {
                            for (int j = this.Main_TabControl.SelectedTab.Index + 1; j <= maxIndex; j++)
                            {
                                if (this.Main_TabControl.Tabs[j].Visible)
                                {
                                    this.Main_TabControl.Tabs[j].Active = true;
                                    this.Main_TabControl.Tabs[j].Selected = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j <= maxIndex; j++)
                            {
                                if (this.Main_TabControl.Tabs[j].Visible)
                                {
                                    this.Main_TabControl.Tabs[j].Active = true;
                                    this.Main_TabControl.Tabs[j].Selected = true;
                                    break;
                                }
                            }
                        }
                        this.setInitFocus();
                        break;
                    }
                case TOOLBAR_CHANGEBUTTON_KEY:	// F2:切替
                    {
                        SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);//add by 凌小青 on 2011/10/27 
                        if (StartNavigatorTree.ContainsFocus)
                        {
                            if (this.Main_TabControl.ActiveTab != null)
                            {
                                this.setInitFocus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Activate();
                                this.tEdit_SectionCode_St.Focus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Activate();
                                _pdfHistorySerchForm.Controls[1].Controls[0].Focus();
                            }
                        }
                        else if (Main_TabControl.ContainsFocus)
                        {
                            if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Activate();
                                this.tEdit_SectionCode_St.Focus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Activate();
                                _pdfHistorySerchForm.Controls[1].Controls[0].Focus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Activate();
                                this.StartNavigatorTree.Nodes[0].Selected = true;
                            }
                        }
                        else if (SelectExplorerBar.ContainsFocus)
                        {
                            if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_PDFHISTORTY_KEY].Activate();
                                _pdfHistorySerchForm.Controls[1].Controls[0].Focus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Activate();
                                this.StartNavigatorTree.Nodes[0].Selected = true;
                            }
                            else if (this.Main_TabControl.ActiveTab != null)
                            {
                                this.setInitFocus();
                            }
                        }
                        else if (PdfHistory_Panel.ContainsFocus)
                        {
                            if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_NAVIGATOR_KEY].Activate();
                                this.StartNavigatorTree.Nodes[0].Selected = true;
                            }
                            else if (this.Main_TabControl.ActiveTab != null)
                            {
                                this.setInitFocus();
                            }
                            else if (!this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Closed)
                            {
                                this.Main_DockManager.ControlPanes[DOCKMANAGER_SELECTCONDITION_KEY].Activate();
                                this.tEdit_SectionCode_St.Focus();
                            }
                        }

                        this.ParentToolbarGuideSettingEvent(false);
                        break;
                    }
                // --- 2010/08/16 ----------<<<<<


            }
        }

        /// <summary>
        /// UltraTabControl.SelectedTabChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">SelectedTabChangedイベントに使用されるイベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : タブコントロールのSelectedTabが変更された後に発生します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void Main_TabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
        {
            // --- ADD 2010/08/16 ---------->>>>>
            if (this.Main_TabControl.ActiveTab != null)
            {
                string key = this.Main_TabControl.ActiveTab.Key.ToString();

                if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
                {
                    key = ((SFANL07200UB)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                }
                else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
                {
                    key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
                }

                // アクティブタブからフォームを取得
                FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
                System.Windows.Forms.Form activeForm = info.Form;

                Infragistics.Win.UltraWinToolbars.ButtonTool guideButtonTool;
                // F5:ガイド
                guideButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
                if (guideButtonTool != null)
                {
                    if (activeForm is IPrintConditionInpTypeGuidExecuter)
                    {
                        guideButtonTool.SharedProps.Visible = true;
                    }
                    else
                    {
                        guideButtonTool.SharedProps.Visible = false;
                    }
                }
            }
            else
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool guideButtonTool;
                // F5:ガイド
                guideButtonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_GUIDEBUTTON_KEY];
                if (guideButtonTool != null)
                {
                    guideButtonTool.SharedProps.Visible = false;
                }
            }
            // --- ADD 2010/08/16 ----------<<<<<

            if (!this._isEvent) return;

            this._isEvent = false;

            try
            {
                // 選択タブ変更時ツリーノード選択処理
                SelectedTabChangedNodeSelect();

                if (e.Tab != null)
                {
                    if (this._navigaterMenuMode)
                    {
                        this.Text = MAIN_TITLE + "－" + e.Tab.Text;
                    }

                    // 親のKEYを取得
                    string key = e.Tab.Key.ToString();

                    if (e.Tab.Tag is SFANL07200UB)
                    {
                        key = ((SFANL07200UB)e.Tab.Tag).FormControlInfoKey;
                    }
                    else if (e.Tab.Tag is AnalysisChartViewForm)
                    {
                        key = ((AnalysisChartViewForm)e.Tab.Tag).FormControlInfoKey;
                    }

                    if (!this._formControlInfoTable.ContainsKey(key))
                    {
                        return;
                    }

                    this.Main_TabControl.Focus();

                    FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[key];
                    Form targetForm = e.Tab.Tag as Form;

                    if (targetForm is IPrintConditionInpType)
                    {
                        // メインフレームの個別画面設定
                        this.ScreenPrivateSetting(key, targetForm);

                        // 出力条件選択ペインを固定
                        this.PinnedDockManagerControlPane(DOCKMANAGER_SELECTCONDITION_KEY, true);

                        // 起動子画面アクティブ化処理		
                        this.TabActive(key, ref targetForm);
                    }
                    else if (targetForm is SFANL07200UB)
                    {
                        // 出力条件選択ペインを非固定
                        this.PinnedDockManagerControlPane(DOCKMANAGER_SELECTCONDITION_KEY, false);

                        // ビューフォームをアクティブ化
                        this.ViewFormTabActive(key, ref targetForm);
                    }
                    else if (targetForm is AnalysisChartViewForm)
                    {
                        // 出力条件選択ペインを非固定
                        this.PinnedDockManagerControlPane(DOCKMANAGER_SELECTCONDITION_KEY, false);

                        // ビューフォームをアクティブ化
                        this.ChartViewFormTabActive(key, ((AnalysisChartViewForm)targetForm).Number, ref targetForm);
                    }

                    // 起動ナビゲーターペインを非固定
                    this.PinnedDockManagerControlPane(DOCKMANAGER_NAVIGATOR_KEY, false);

                    // 出力履歴検索ペインを非固定
                    this.PinnedDockManagerControlPane(DOCKMANAGER_PDFHISTORTY_KEY, false);

                    if (targetForm != null)
                    {
                        this.ToolBarSetting(targetForm);
                        this.DockManagerCtrlPaneSetting(targetForm);
                    }

                }
                else
                {
                    this.Text = MAIN_TITLE;
                }
            }
            finally
            {
                this._isEvent = true;
            }
        }

        /// <summary>
        /// UltraTabControl.TabMoved イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">TabMovedイベントに使用されるイベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : タブが移動された後に発生します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.04.22</br>
        /// </remarks>
        private void Main_TabControl_TabMoved(object sender, Infragistics.Win.UltraWinTabControl.TabMovedEventArgs e)
        {
            if (!this._isEvent) return;

            if (e.Tab == null) return;

            string key = e.Tab.Key;
            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[key];

            Form targetForm = null;
            int index = e.Tab.Key.IndexOf(TAB_VIEWFORM_ADDKEY);
            if (index == -1)
            {
                targetForm = formControlInfo.Form;

                // 起動子画面アクティブ化処理		
                this.TabActive(key, ref targetForm);
            }
            else
            {
                targetForm = formControlInfo.ViewForm;

                // ビューフォームをアクティブ化
                this.ViewFormTabActive(key, ref targetForm);
            }
        }

        /// <summary>
        /// 計上拠点選択状態変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントソース</param>
        /// <remarks>
        /// <br>Note　　　  : コントロールの値が変更された後に発生します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void AddUpCd_UOptionSet_ValueChanged(object sender, System.EventArgs e)
        {
            if (!this._isEvent) return;

            // アクティブタブは存在するか
            if (this.Main_TabControl.ActiveTab == null) return;

            //--------------------------------------------------------------------------
            // アクティブな条件入力ＵＩへの通知処理
            //--------------------------------------------------------------------------
            // アクティブタブからフォームを取得
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
            IPrintConditionInpTypeSelectedSection target = info.Form as IPrintConditionInpTypeSelectedSection;

            int addCode = TStrConv.StrToIntDef(this.AddUpCd_UOptionSet.CheckedItem.DataValue.ToString(), 0);

            if (target != null)
            {
                if (target.VisibledSelectAddUpCd)
                {
                    // 選択拠点種類を通知
                    target.SelectedAddUpCd(addCode);
                    info.SelSectionKindIndex = this.AddUpCd_UOptionSet.CheckedIndex;
                }
            }

            // 計上拠点の選択により制御機能コードを切替る
            int ctrlFuncCode = TStrConv.StrToIntDef(this.AddUpCd_UOptionSet.CheckedItem.Tag.ToString(), 0);

            string ctrlSecCode;
            this.GetOwnSeCtrlCode(this._loginSectionCode, ctrlFuncCode, out ctrlSecCode);
            string[] selSections = new string[] { ctrlSecCode };

            // 拠点初期設定デリゲート
            if (target != null)
            {
                // 選択拠点種類を通知
                target.InitSelectSection(selSections);
                info.SelSections = selSections;
            }

            //--------------------------------------------------------------------------
            // メインフレーム関連の処理
            //--------------------------------------------------------------------------
            // 本社機能時のみ
            if (this._isMainOfficeFunc)
            {
                // 拠点変更イベントを発生させない為、イベントをOFF
                this._isEvent = false;
                try
                {
                    // 全てのチェックをはずす
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
                    {
                        utn.CheckedState = System.Windows.Forms.CheckState.Unchecked;
                    }

                    // 該当拠点コードにチェック
                    if (this._secInfoLst.ContainsKey(ctrlSecCode))
                    {
                        this.Section_UTree.Nodes[ctrlSecCode].CheckedState = System.Windows.Forms.CheckState.Checked;
                    }
                }
                finally
                {
                    this._isEvent = true; ;
                }
            }
        }

        /// <summary>
        /// 拠点選択チェックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : checkedStateプロパティが変更された後に発生します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void Section_UTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (!this._isEvent) return;

            if (this._secNodeCheckEvent) return;

            // イベント中フラグON
            this._secNodeCheckEvent = true;

            // アクティブタブは存在するか
            if (this.Main_TabControl.ActiveTab == null) return;

            // ビューフォームの場合は親のKEYを取得
            string key = this.Main_TabControl.ActiveTab.Key.ToString().Replace(TAB_VIEWFORM_ADDKEY, "");

            // アクティブタブからフォームを取得
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
            IPrintConditionInpTypeSelectedSection target = info.Form as IPrintConditionInpTypeSelectedSection;

            try
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode utnAll =
                    this.Section_UTree.GetNodeByKey(CT_AllSectionCode);

                // ”全社”指定された
                if (e.TreeNode.Key.ToString().Equals(CT_AllSectionCode))
                {
                    // 選択
                    if (utnAll != null)
                    {
                        if (utnAll.CheckedState == CheckState.Checked)
                        {
                            // その他の項目のチェックをはずす
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
                            {
                                if (utn.Key.Equals(CT_AllSectionCode) == false)
                                {
                                    utn.CheckedState = CheckState.Unchecked;
                                }
                            }
                        }
                    }
                }
                // その他拠点
                else
                {
                    if (utnAll != null)
                    {
                        if (utnAll.CheckedState == CheckState.Checked)
                        {
                            utnAll.CheckedState = CheckState.Unchecked;

                            if (target != null)
                            {
                                target.CheckedSection(utnAll.Key.ToString(), CheckState.Unchecked);
                            }

                        }
                    }
                }

                if (target != null)
                {
                    target.CheckedSection(e.TreeNode.Key.ToString(), e.TreeNode.CheckedState);
                }

                // 選択されている拠点情報を保存
                if (info != null)
                {
                    ArrayList selSecList = new ArrayList();
                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_UTree.Nodes)
                    {
                        if (utn.CheckedState == CheckState.Checked)
                        {
                            selSecList.Add(utn.Key.ToString());
                        }
                    }
                    string[] selSections = (string[])selSecList.ToArray(typeof(string));
                    info.SelSections = selSections;
                }

            }
            finally
            {
                e.TreeNode.Selected = true;
                this._secNodeCheckEvent = false;
            }
        }

        /// <summary>
        /// システム選択チェックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : checkedStateプロパティが変更された後に発生します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.01.19</br>
        /// </remarks>
        private void System_UTree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (!this._isEvent) return;

            if (this._sysNodeCheckEvent) return;

            // イベント中フラグON
            this._sysNodeCheckEvent = true;

            // アクティブタブは存在するか
            if (this.Main_TabControl.ActiveTab == null) return;

            // ビューフォームの場合は親のKEYを取得
            string key = this.Main_TabControl.ActiveTab.Key.ToString().Replace(TAB_VIEWFORM_ADDKEY, "");

            // アクティブタブからフォームを取得
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
            IPrintConditionInpTypeSelectedSystem target = info.Form as IPrintConditionInpTypeSelectedSystem;

            try
            {
                if (target != null)
                {
                    int sysCode = TStrConv.StrToIntDef(e.TreeNode.Key.ToString(), 0);
                    target.CheckedSystem(sysCode, e.TreeNode.CheckedState);

                    // 選択されているシステム情報を保存
                    if (info != null)
                    {
                        ArrayList selSysList = new ArrayList();
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.System_UTree.Nodes)
                        {
                            if (utn.CheckedState == CheckState.Checked)
                            {
                                selSysList.Add(utn.Key.ToString());
                            }
                        }

                        int[] selSystems = new int[selSysList.Count];

                        for (int i = 0; i < selSysList.Count; i++)
                        {
                            int wkInt = TStrConv.StrToIntDef(selSysList[i].ToString(), -1);
                            selSystems[i] = wkInt;
                        }
                        info.SelSystems = selSystems;
                    }
                }

            }
            finally
            {
                e.TreeNode.Selected = true;
                this._sysNodeCheckEvent = false;
            }
        }

        /// <summary>
        /// ポップメニュー「閉じる」イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 「閉じる」ボタン押下時に発生します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.03.28</br>
        /// </remarks>
        private void Close_menuItem_Click(object sender, System.EventArgs e)
        {
            if (this.Main_TabControl.ActiveTab == null) return;

            string key = this.Main_TabControl.ActiveTab.Key;

            // タブ表示変更
            this.TabVisibleChange(key, false);

            // ウィンドウステートボタンツール構築処理
            this.CreateWindowStateButtonTools();

            // >>>>> 2007.06.29 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            if (this.Main_TabControl.Tabs.Count == 0)
            {
                this.ToolBarSetting(null);
            }
            else
            {
                this.ToolBarSetting(this.Main_TabControl.ActiveTab);
            }
            // <<<<< 2007.06.29 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        }

        /// <summary>
        ///	フォームを閉じようとした時のイベントです。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note        : フォームが閉じられた後に発生します。</br>
        /// <br>Programmer  : 18012 Y.Sasaki</br>
        /// <br>Date        : 2006.05.01</br>
        /// </remarks>
        private void SFANL07200UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            // イベントを制御する為、フラグをOFFに
            this._isEvent = false;

            //int tabCnt = this.Main_TabControl.Tabs.Count;
            //for (int i = 0; i < tabCnt; i++)
            //{
            //    this.Main_TabControl.Tabs.RemoveAt(0);
            //}

            // 各帳票のブラウザに空アドレスを表示させます。表示しているPDFファイルを閉じる為です。
            foreach (DictionaryEntry entry in this._formControlInfoTable)
            {
                FormControlInfo info = entry.Value as FormControlInfo;
                if (info != null)
                {
                    SFANL07200UB viewFrm = info.ViewForm as SFANL07200UB;
                    if (viewFrm != null)
                    {
                        viewFrm.ShowPDFPreview("about:blank");
                        // --- ADD m.suzuki 2010/11/02 ---------->>>>>
                        viewFrm.Close();
                        // --- ADD m.suzuki 2010/11/02 ----------<<<<<
                        viewFrm.Dispose();
                    }
                }
            }

            foreach (Infragistics.Win.UltraWinTabControl.UltraTab tab in this.Main_TabControl.Tabs)
            {
                this.Main_TabControl.Tabs.Remove(tab);
            }

            // プレビューで生成したＰＤＦファイルを削除します。
            int tryCnt;
            foreach (DictionaryEntry wkEntry in this._delPDFList)
            {
                if (System.IO.File.Exists(wkEntry.Value.ToString()))
                {
                    tryCnt = 0;
                    while (tryCnt < 3)
                    {
                        try
                        {
                            System.IO.File.Delete(wkEntry.Value.ToString());
                            break;
                        }
                        // --- UPD 2021/01/04 警告対応 ------>>>>
                        //catch (System.IO.IOException ex)
                        catch (System.IO.IOException)
                        // --- UPD 2021/01/04 警告対応 ------<<<<
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                        catch (Exception)
                        {
                            break;
                        }

                        tryCnt++;
                    }
                }
            }
        }

        #region <拠点の範囲指定/>

        /// <summary>
        /// 開始拠点コードテキストボックスのLeaveイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 操作権限に応じたボタン制御の対応</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void startRangeTNedit_Leave(object sender, EventArgs e)
        {
            SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);
        }

        /// <summary>
        /// 終了拠点コードテキストボックスのLeaveイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 操作権限に応じたボタン制御の対応</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void endRangeTNedit_Leave(object sender, EventArgs e)
        {
            SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);

            // 開始拠点コードへ戻る
            if (_focusStartRangeFlag)
            {
                _focusStartRangeFlag = false;
                this.tEdit_SectionCode_St.Focus();
            }
        }

        /// <summary>開始拠点コードを選択するフラグ</summary>
        private bool _focusStartRangeFlag;

        /// <summary>
        /// [Enter]キーでフォーカス移動したときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 操作権限に応じたボタン制御の対応</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012C 朱 猛</br>
        /// <br>Date        : 2010/08/16</br>
        /// </remarks>
        private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl != null)
            {
                Debug.WriteLine("直前のコントロール：" + e.PrevCtrl.Name);
            }
            else
            {
                Debug.WriteLine("直前のコントロール：null");
            }

            // 拠点を選択する処理
            if ((e.PrevCtrl == this.tEdit_SectionCode_St) || (e.PrevCtrl == this.tEdit_SectionCode_Ed))
            {
                CheckSectionTreeNode(this.tEdit_SectionCode_St.Text.Trim(), this.tEdit_SectionCode_Ed.Text.Trim());

                // 開始拠点コードへ戻る
                if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                {
                    _focusStartRangeFlag = true;
                }
            }

            // ---ADD 2010/08/16-------------------->>>
            if (e.Key == Keys.Enter)
            {
                // 起動ナビゲータでEnterキーが押下された時
                if (this.StartNavigatorTree.ContainsFocus)
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode keyDownNode =
                    this.StartNavigatorTree.SelectedNodes[0];
                    if (keyDownNode == null) return;

                    FormControlInfo info = this._formControlInfoTable[keyDownNode.Key.ToString()] as FormControlInfo;
                    if (info == null) return;

                    // --- ADD 2010/08/26 ---------->>>>>
                    if (info.Form is IPrintConditionInpTypeGuidExecuter)
                    {
                        ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall -= new ParentPrint(this.ParentPrint);
                        ((IPrintConditionInpTypeGuidExecuter)info.Form).ParentPrintCall += new ParentPrint(this.ParentPrint);
                    }
                    // --- ADD 2010/08/26 ----------<<<<<
                    // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
                    if (info.Form is IPrintConditionInpTypeTextOutControl)
                    {
                        ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall -= new TextOutControl(this.TextOutControl);
                        ((IPrintConditionInpTypeTextOutControl)info.Form).TextOutControlCall += new TextOutControl(this.TextOutControl);
                    }
                    // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<


                    if (keyDownNode.Level == 2)
                    {
                        if (!MyOpeCtrlMap.ContainsKey(info.AssemblyID))
                        {
                            if (!OpeAuthCtrlFacade.CanRunWithInitializing(
                                EntityUtil.CategoryCode.Report,
                                MyOpeCtrlMap.AddController(info.AssemblyID),
                                info.AssemblyID,
                                info.Name
                            ))
                            {
                                // 起動不可のため強制終了
                                return;
                            }
                        }

                        Infragistics.Win.UltraWinTree.UltraTreeNode node = keyDownNode;

                        // 条件入力画面UI起動処理
                        ShowChildInputForm(node.Key.ToString());

                        keyDownNode.Override.NodeAppearance.ForeColor = Color.Red;

                        BeginControllingByOperationAuthority(info.AssemblyID);
                    }
                }
            }
            // ---ADD 2010/08/16--------------------<<<
        }

        /// <summary>
        /// 拠点の範囲を指定するUIを設定します。
        /// </summary>
        /// <param name="sectionCodeUI">拠点コードUI</param>
        /// <param name="sectionNameUI">拠点名称UI</param>
        /// <param name="defaultText">UIに応じたテキスト</param>
        /// <remarks>
        /// <br>Note　　　  : 操作権限に応じたボタン制御の対応</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void SetSectionRangeUI(
            Broadleaf.Library.Windows.Forms.TNedit sectionCodeUI,
            Infragistics.Win.UltraWinEditors.UltraTextEditor sectionNameUI,
            string defaultText
        )
        {
            // 最初から／最後まで
            if (string.IsNullOrEmpty(sectionCodeUI.Text.Trim()))
            {
                sectionNameUI.Text = defaultText;
                return;
            }

            // 全社
            if (int.Parse(sectionCodeUI.Text.Trim()).Equals(0))
            {
                // 開始
                this.tEdit_SectionCode_St.Text = int.Parse(CT_AllCtrlFuncSecCode).ToString(SECTION_CODE_FORMAT);
                this.startRangeNameUltraTextEditor.Text = CT_AllCtrlFuncSecName;

                // 終了
                this.tEdit_SectionCode_Ed.Text = int.Parse(CT_AllCtrlFuncSecCode).ToString(SECTION_CODE_FORMAT);
                this.endRangeNameUltraTextEditor.Text = CT_AllCtrlFuncSecName;

                return;
            }

            // 任意
            string sectionCode = int.Parse(sectionCodeUI.Text.Trim()).ToString(SECTION_CODE_FORMAT);
            sectionCodeUI.Text = sectionCode;
            sectionNameUI.Text = GetSectionName(sectionCode);
        }

        /// <summary>
        /// 拠点ツリーのノードをチェック状態にします。
        /// </summary>
        /// <param name="startSectionCode">開始拠点コード</param>
        /// <param name="endSectionCode">終了拠点コード</param>
        /// <remarks>
        /// <br>Note　　　  : 操作権限に応じたボタン制御の対応</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void CheckSectionTreeNode(
            string startSectionCode,
            string endSectionCode
        )
        {
            // 開始拠点コード値
            int startCode = MIN_SECTION_CODE;
            if (!string.IsNullOrEmpty(startSectionCode))
            {
                startCode = int.Parse(startSectionCode);
                if (startCode < 0) startCode = MIN_SECTION_CODE;
            }
            // --- ADD 2009/01/19 障害ID:9982対応------------------------------------------------------>>>>>
            else
            {
                if ((startSectionCode == null) || (startSectionCode.Trim() == ""))
                {
                    startCode = 0;
                }
            }
            // --- ADD 2009/01/19 障害ID:9982対応------------------------------------------------------<<<<<

            // 終了拠点コード値
            int endCode = MAX_SECTION_CODE;
            if (!string.IsNullOrEmpty(endSectionCode))
            {
                endCode = int.Parse(endSectionCode);
                if (endCode > MAX_SECTION_CODE) endCode = MAX_SECTION_CODE;
            }
            // --- ADD 2009/01/19 障害ID:9982対応------------------------------------------------------>>>>>
            else
            {
                if ((endSectionCode == null) || (endSectionCode.Trim() == ""))
                {
                    endCode = 99;
                }
            }
            // --- ADD 2009/01/19 障害ID:9982対応------------------------------------------------------<<<<<

            // --- DEL 2009/01/19 障害ID:9982対応------------------------------------------------------>>>>>
            //// 全社指定の補正
            //int allSectionCode = int.Parse(CT_AllSectionCode);
            //if (startCode.Equals(allSectionCode) || endCode.Equals(allSectionCode))
            //{
            //    startCode = allSectionCode;
            //    endCode = allSectionCode;
            //}
            // --- DEL 2009/01/19 障害ID:9982対応------------------------------------------------------<<<<<

            if (startCode > endCode)
            {
                const string MSG = "開始拠点コードが終了拠点コードより大きな値です。";  // LITERAL:
                this.Main_StatusBar.Panels["Text"].Text = MSG;
                return;
            }
            else
            {
                this.Main_StatusBar.Panels["Text"].Text = string.Empty;
            }

            // --- ADD 2009/01/19 障害ID:9982対応------------------------------------------------------>>>>>
            for (int i = 0; i < this.Section_UTree.Nodes.Count; i++)
            {
                // 強制的に未選択にする
                if (this.Section_UTree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
                {
                    this.Section_UTree.Nodes[i].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                }
            }

            if (((string.IsNullOrEmpty(startSectionCode)) || (int.Parse(startSectionCode) == 0)) &&
                ((string.IsNullOrEmpty(endSectionCode)) || (int.Parse(endSectionCode) == 0)))
            {
                // 全社選択
                this.Section_UTree.Nodes[CT_AllSectionCode].CheckedState = CheckState.Checked;
            }
            else
            {
                if ((string.IsNullOrEmpty(startSectionCode)) || (int.Parse(startSectionCode) == 0))
                {
                    startCode = MIN_SECTION_CODE;
                }
                else
                {
                    startCode = int.Parse(startSectionCode);
                }
                if ((string.IsNullOrEmpty(endSectionCode)) || (int.Parse(endSectionCode) == 0))
                {
                    endCode = MAX_SECTION_CODE;
                }
                else
                {
                    endCode = int.Parse(endSectionCode);
                }

                for (int i = 0; i < this.Section_UTree.Nodes.Count; i++)
                {
                    // 強制的に未選択にする
                    if (this.Section_UTree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
                    {
                        this.Section_UTree.Nodes[i].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                    }

                    // 開始拠点コード値と終了拠点コード値の範囲内なら、選択する（全社指定の場合、全社を選択する）
                    int sectionCode = int.Parse(this.Section_UTree.Nodes[i].Key);
                    if ((startCode <= sectionCode) && (sectionCode <= endCode))
                    {
                        if (!sectionCode.Equals(int.Parse(CT_AllSectionCode)))
                        {
                            string key = sectionCode.ToString(SECTION_CODE_FORMAT);
                            if (this._secInfoLst.ContainsKey(key))
                            {
                                this.Section_UTree.Nodes[key].CheckedState = System.Windows.Forms.CheckState.Checked;
                            }
                        }
                        else
                        {
                            this.Section_UTree.Nodes[CT_AllSectionCode].CheckedState = System.Windows.Forms.CheckState.Checked;
                        }
                    }
                }
            }
            // --- ADD 2009/01/19 障害ID:9982対応------------------------------------------------------<<<<<

            // --- DEL 2009/01/19 障害ID:9982対応------------------------------------------------------>>>>>
            //// ノード選択
            //for (int i = 0; i < this.Section_UTree.Nodes.Count; i++)
            //{
            //    // 強制的に未選択にする
            //    if (this.Section_UTree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
            //    {
            //        this.Section_UTree.Nodes[i].CheckedState = System.Windows.Forms.CheckState.Unchecked;
            //    }

            //    // 開始拠点コード値と終了拠点コード値の範囲内なら、選択する（全社指定の場合、全社を選択する）
            //    int sectionCode = int.Parse(this.Section_UTree.Nodes[i].Key);
            //    if ((startCode <= sectionCode) && (sectionCode <= endCode))
            //    {
            //        if (!sectionCode.Equals(int.Parse(CT_AllSectionCode)))
            //        {
            //            string key = sectionCode.ToString(SECTION_CODE_FORMAT);
            //            if (this._secInfoLst.ContainsKey(key))
            //            {
            //                this.Section_UTree.Nodes[key].CheckedState = System.Windows.Forms.CheckState.Checked;
            //            }
            //        }
            //        else
            //        {
            //            this.Section_UTree.Nodes[CT_AllSectionCode].CheckedState = System.Windows.Forms.CheckState.Checked;
            //        }
            //    }
            //}
            // --- DEL 2009/01/19 障害ID:9982対応------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ペインが表示されたときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 操作権限に応じたボタン制御の対応</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void Main_DockManager_PaneDisplayed(object sender, Infragistics.Win.UltraWinDock.PaneDisplayedEventArgs e)
        {
            if (e.Pane.Control.Name.Equals("SelectExplorerBar"))  // TODO:this.SelectExplorerBarの名前を変更した場合、ここも変更
            {
                e.Pane.Control.Select();
                this.tEdit_SectionCode_St.Focus();
            }
        }

        /// <summary>
        /// フォーカスが変化したときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 操作権限に応じたボタン制御の対応</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2008.09.05</br>
        /// </remarks>
        private void tArrowKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.NextCtrl == this.tEdit_SectionCode_St)
            {
                this.tEdit_SectionCode_St.Focus();
                this.tEdit_SectionCode_St.SelectAll();
                return;
            }
            if (e.NextCtrl == this.tEdit_SectionCode_Ed)
            {
                this.tEdit_SectionCode_Ed.Focus();
                this.tEdit_SectionCode_Ed.SelectAll();
                return;
            }
        }

        #endregion  // <拠点の範囲指定/>

        // --- ADD 2010/08/16 ---------->>>>>
        /// <summary>
        /// getFirstControl
        /// </summary>
        /// <param name="firstControl"></param>
        /// <param name="parentControl"></param>
        /// <remarks>
        /// <br>Note　　　  : キーボード操作の改良の対応</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/16</br>
        /// </remarks>
        private void getFirstControl(ref Control firstControl, Control parentControl)
        {
            bool flg = false;
            foreach (Control control in parentControl.Controls)
            {
                if (!(control is Panel))
                {
                    flg = true;
                }
            }

            List<Control> controlList = new List<Control>();
            if (!flg)
            {
                Control firstPanel = new Control();
                firstPanel.Left = 1024;
                firstPanel.Top = 768;
                foreach (Control control in parentControl.Controls)
                {
                    if (control.Top < firstPanel.Top)
                    {
                        firstPanel = control;
                    }
                    else if (control.Top == firstPanel.Top)
                    {
                        if (control.Left < firstPanel.Left)
                        {
                            firstPanel = control;
                        }
                    }
                }

                foreach (Control controlTmp in firstPanel.Controls)
                {
                    controlList.Add(controlTmp);
                }
            }
            else
            {
                foreach (Control control in parentControl.Controls)
                {
                    controlList.Add(control);
                }
            }

            foreach (Control control in controlList)
            {
                if (control.Visible && control.Enabled && control.CanFocus && (control is TEdit || control is TNedit || control is TComboEditor
                            || control is TDateEdit || control is UltraOptionSet || control is UltraButton))
                {
                    if (control.Top < firstControl.Top)
                    {
                        firstControl = control;
                    }
                    else if (control.Top == firstControl.Top)
                    {
                        if (control.Left < firstControl.Left)
                        {
                            firstControl = control;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// getFirstExplorerBarContainerControl
        /// </summary>
        /// <param name="firstExplorerBar"></param>
        /// <param name="parentControl"></param>
        /// <remarks>
        /// <br>Note　　　  : キーボード操作の改良の対応</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/16</br>
        /// </remarks>
        private void getFirstExplorerBarContainerControl(ref Control firstExplorerBar, Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (!(control is Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl) && control.Controls.Count != 0)
                {
                    getFirstExplorerBarContainerControl(ref firstExplorerBar, control);
                }
                else
                {
                    if (control is Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl && control.Visible && control.Enabled)
                    {
                        if (control.Top < firstExplorerBar.Top)
                        {
                            firstExplorerBar = control;
                        }
                        else if (control.Top == firstExplorerBar.Top)
                        {
                            if (control.Left < firstExplorerBar.Left)
                            {
                                firstExplorerBar = control;
                            }
                        }
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// プリントの処理
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : キーボード操作の改良の対応</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/26</br>
        /// </remarks>
        public void ParentPrint()
        {
            object sender = new object();
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e = new Infragistics.Win.UltraWinToolbars.ToolClickEventArgs(this.Main_ToolbarsManager.Tools[TOOLBAR_PRINTBUTTON_KEY], null);

            this.Main_ToolbarsManager_ToolClick(sender, e);
        }

        // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
        /// <summary>
        /// テキスト出力ボタンの制御
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : テキスト出力ボタンの制御</br>
        /// <br>Programmer  : licb</br>
        /// <br>Date        : K2014/03/10</br>
        /// </remarks>
        public void TextOutControl()
        {
            //テキスト出力…USBチェック
            PurchaseStatus purchaseStatus =
                LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            //信越…USBチェック
            PurchaseStatus sletuPurchaseStatus =
                            LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_ShinetsuInventoryListCtl);
            if ((purchaseStatus == PurchaseStatus.Contract ||			// テキスト出力契約済
                    purchaseStatus == PurchaseStatus.Trial_Contract) &&   // テキスト出力体験版契約済
                    (sletuPurchaseStatus == PurchaseStatus.Contract || // 信越契約済
                    sletuPurchaseStatus == PurchaseStatus.Trial_Contract))// 信越体験版契約済
            {
                //テキスト出力ボタン
                Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                if (buttonTool != null)
                {

                    buttonTool.SharedProps.Visible = true;
                }
            }
            else
            {
                Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool = (Infragistics.Win.UltraWinToolbars.ButtonTool)Main_ToolbarsManager.Tools[TOOLBAR_TEXTOUTPUTBUTTON_KEY];
                if (buttonTool != null)
                {
                    buttonTool.SharedProps.Visible = false;
                }

            }
        }
        // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<
        /// <summary>
        /// 初期化時のフォーカスを取得する
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 初期化時のフォーカスを取得する</br>
        /// <br>Programmer  : 高峰</br>
        /// <br>Date        : 2010/08/26</br>
        /// </remarks>
        private void setInitFocus() {
            string key = this.Main_TabControl.ActiveTab.Key.ToString();

            if (this.Main_TabControl.ActiveTab.Tag is SFANL07200UB)
            {
                this.Main_TabControl.Focus();
                return;
            }
            else if (this.Main_TabControl.ActiveTab.Tag is AnalysisChartViewForm)
            {
                key = ((AnalysisChartViewForm)this.Main_TabControl.ActiveTab.Tag).FormControlInfoKey;
            }

            // アクティブタブからフォームを取得
            FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
            System.Windows.Forms.Form activeForm = info.Form;

            Control firstPanel = new Control();
            firstPanel.Left = 1024;
            firstPanel.Top = 768;
            foreach (Control parentControl in activeForm.Controls)
            {
                getFirstExplorerBarContainerControl(ref firstPanel, parentControl);
            }
            Control firstControl = new Control();
            firstControl.Left = 1024;
            firstControl.Top = 768;
            getFirstControl(ref firstControl, firstPanel);
            firstControl.Focus();
        }
        // --- ADD 2010/08/16 ----------<<<<<
    }

    // -----ADD 2011/03/14  ---------->>>>>
    #region 拠点ツリーコントロールのヘルパ

    /// <summary>
    /// 拠点ツリーコントロールのヘルパクラス
    /// </summary>
    internal static class SectionTreeHelper
    {
        /// <summary>
        /// エクスポートファイルのフルパスを取得します。
        /// </summary>
        private static string ExportPathName
        {
            get
            {
                return @".\UISettings\DCKAU02520U_SectionSetting.xml";
            }
        }

        /// <summary>
        /// チェックされている拠点コードをエクスポートします。
        /// </summary>
        /// <param name="sectionTree">拠点ツリーコントロール</param>
        /// <param name="enabled">有効フラグ</param>
        public static void ExportCheckedSectionCode(
            Infragistics.Win.UltraWinTree.UltraTree sectionTree,
            bool enabled
        )
        {
            #region Guard Phrase

            if (sectionTree == null) return;
            if (!enabled) return;

            #endregion // Guard Phrase

            List<string> sectionPairList = new List<string>();

            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode sectionNode in sectionTree.Nodes)
            {
                if (sectionNode.CheckedState.Equals(CheckState.Checked))
                {
                    sectionPairList.Add(sectionNode.Key);
                }
            }

            System.IO.FileStream outputFile = null;
            try
            {
                outputFile = new System.IO.FileStream(ExportPathName, System.IO.FileMode.Create);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
                serializer.Serialize(outputFile, sectionPairList);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (outputFile != null) outputFile.Close();
            }
        }

        /// <summary>
        /// チェックされていた拠点コードをインポートします。
        /// </summary>
        /// <param name="sectionTree">拠点ツリーコントロール</param>
        /// <param name="enabed">有効フラグ</param>
        /// <returns>
        /// <c>true</c> :インポートしました。<br/>
        /// <c>false</c>:インポートしませんでした。
        /// </returns>
        public static bool ImportCheckedSectionCode(
            Infragistics.Win.UltraWinTree.UltraTree sectionTree,
            bool enabed
        )
        {
            #region Guard Phrase

            if (sectionTree == null) return false;
            if (!System.IO.File.Exists(ExportPathName)) return false;
            if (!enabed) return false;

            #endregion // Guard Phrase

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));

            bool checkedTree = false;
            System.IO.FileStream inputFile = null;
            try
            {
                inputFile = new System.IO.FileStream(ExportPathName, System.IO.FileMode.Open);
                List<string> checkedSectionCodeList = (List<string>)serializer.Deserialize(inputFile);
                if (checkedSectionCodeList == null) return false;

                foreach (string sectionCode in checkedSectionCodeList)
                {
                    if (sectionTree.Nodes.Exists(sectionCode))
                    {
                        sectionTree.Nodes[sectionCode].CheckedState = CheckState.Checked;
                        checkedTree = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (inputFile != null) inputFile.Close();
            }
            return checkedTree;
        }
    }

    #endregion // 拠点ツリーコントロールのヘルパ
    // -----ADD 2011/03/14  ----------<<<<<
}
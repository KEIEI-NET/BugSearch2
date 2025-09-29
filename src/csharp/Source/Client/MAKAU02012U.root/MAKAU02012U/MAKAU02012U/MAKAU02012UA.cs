//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：請求帳票
// プログラム概要   ：請求帳票の印刷を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2008/09/04     修正内容：Partsman用に修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/20     修正内容：Mantis【13192】抽出画面にレコード名を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30531 大矢睦美
// 修正日    2010/01/27     修正内容：Mantis【14928】請求書タイプを取得する処理を追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30531 大矢睦美
// 修正日    2010/02/25     修正内容：Mantis【15055】請求一覧表で出力金額区分の制御が正しく行われるようにする
//                                                   複数の請求書タイプを印刷する時、エラーが出ないように修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/03/11     修正内容：Mantis【15131】印字条件を保持可能へ変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2010/07/22     修正内容：アウトオブメモリエラーの対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：鄧潘ハン
// 修正日    2011/02/16     修正内容：印刷処理の速度アップ対応
// ---------------------------------------------------------------------//
// 管理番号  10700008-00    作成担当：yangmj
// 修正日    2011/03/14     修正内容：印字制御の区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：曹文傑
// 修正日    2011/03/23     修正内容：仕様連絡 #20083
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：凌小青
// 修正日    2011/10/31　   修正内容：障害報告 #26321
//----------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 李小路 
// 修 正 日  2011/12/27  修正内容 : 2012/01/25配信分、Redmine#27270　 
//                                  請求書/メモリ領域のオーバーフローエラーの発生の修正
//----------------------------------------------------------------------// 
// 管理番号  10707327-00    作成担当：許培珠
// 修正日    2012/02/06　   修正内容：2012/03/28配信分 障害報告redmine#28258 請求書／ログ出力の追加
//----------------------------------------------------------------------//
// 管理番号  10707327-00    作成担当：許培珠
// 修正日    2012/03/05　   修正内容：2012/03/28配信分 障害報告redmine#28258 請求書／ログ出力の追加
//----------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2012/06/04　   修正内容：請求書／ログ出力内容の改良
//----------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2012/06/21　   修正内容：入金手数料・値引の不具合修正
//----------------------------------------------------------------------//
// 管理番号  11570208-00    作成担当：陳艶丹
// 修正日    2020/04/13     修正内容：PMKOBETSU-2912 軽減税率の対応
// ---------------------------------------------------------------------//
#define CHG20060418
#define CLR2								// 2006.04.19 修正
#define CHG20060421					// 2006.04.21 修正
//#define EARLY_BINDING   // デバッグ用　※リリース時にはコメント化すること！
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;    // ADD 2008/03/09 請求書系フレーム対応：PDFを一括表示
using System.Windows.Forms;
using System.Data;
// TODO ダミー
using System.Threading;

using Microsoft.Win32;

using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Text;
using DataDynamics.ActiveReports.Document; // 2010/07/22 ADD
using Broadleaf.Application.Remoting.ParamData;
using System.Reflection; //  ADD 2020/04/13 陳艶丹 軽減税率対応
namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 請求書印刷(一覧・鑑・明細)条件フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求書印刷(一覧・合計・明細)条件フォームクラスです。</br>
    /// <br>Programmer : 980023 飯谷 耕平</br>
    /// <br>Date       : 2007.06.30</br>
    /// <br>Update Note: 20081 疋田 勇人
    /// <br>           : 2007.10.15 DC.NS用に変更</br> 
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.09.04</br>
    /// <br>Update Note: 2011/02/16 鄧潘ハン</br>                       
    /// <br>           : 印刷処理の速度アップ対応</br>
    /// <br>Update Note: 2011/03/14 yangmj</br>                       
    /// <br>           : 印字制御の区分の追加</br>
    /// <br>Update Note: 2011/03/23 曹文傑</br>                       
    /// <br>           : 仕様連絡 #20083</br>
    /// <br>Update Note: 2011/12/27 李小路</br>	
    /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>	
    /// <br>             Redmine#27270　請求書/メモリ領域のオーバーフローエラーの発生の修正</br>
    /// <br>Update Note: 2012/02/06 許培珠</br>	
    /// <br>管理番号   ：10707327-00 2012/03/28配信分</br>	 
    /// <br>             redmine##28258 請求書／ログ出力の追加</br>
    /// <br>Update Note: 11570208-00 軽減税率対応</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/04/13</br>
    /// </remarks>
    public class MAKAU02012UA : System.Windows.Forms.Form, IDemandTbsMDIChildMain, ICustomTextSelectAndWriter
    {
        # region Private Members (Component)
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_TabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private System.Windows.Forms.Panel ExtraInfo_Panel;
        private System.Windows.Forms.Panel ExtraData_Panel;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Panel PrintExtra_Panel;
        private System.Windows.Forms.Panel DataView_Panel;
        private System.Windows.Forms.Panel Total_Panel;
        private System.Windows.Forms.Panel panel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private System.Windows.Forms.Panel panel7;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit6;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Infragistics.Win.UltraWinGrid.UltraGrid DEMANDLISTVIEW;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl SectionList_ExplorerBarContainerControl;
        private Infragistics.Win.UltraWinTree.UltraTree Section_Tree;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoFillToGridColumn_CheckEditor;
        private Broadleaf.Library.Windows.Forms.TNedit TotalSales_tNedit;
        private Infragistics.Win.Misc.UltraButton Select_Button;
        private Infragistics.Win.Misc.UltraButton UnSelect_Button;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02012UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02012UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02012UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU02012UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _MAKAU02012UAAutoHideControl;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl5;
        private Broadleaf.Library.Windows.Forms.TComboEditor PrintOder_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Broadleaf.Library.Windows.Forms.TDateEdit AddUpDate_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode_Ed;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Broadleaf.Library.Windows.Forms.TComboEditor ChargeEmployee_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Broadleaf.Library.Windows.Forms.TComboEditor OutPutPriceCond_tComboEditor;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Extra_ultraExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinTree.UltraTree History_Tree;
        private System.Windows.Forms.ToolTip History_ToolTip;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Panel panel2;
        private Broadleaf.Library.Windows.Forms.TNedit TotalDmd_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private System.Windows.Forms.Panel panel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private Broadleaf.Library.Windows.Forms.TNedit TotalDeposit_tNedit;
        private System.Windows.Forms.Panel panel4;
        private Broadleaf.Library.Windows.Forms.TNedit TotalLastDmd_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel19;
        private System.Windows.Forms.Panel panel5;
        private Broadleaf.Library.Windows.Forms.TNedit TotalTax_tNedit;
        private System.Windows.Forms.Panel panel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
        private Broadleaf.Library.Windows.Forms.TNedit RpSlipCount_tNedit;
        private Infragistics.Win.Misc.UltraLabel BillTableOutPut_Label;
        private Infragistics.Win.Misc.UltraLabel ConsTaxTiTle_Label;
        private System.Windows.Forms.MenuItem menuItem2;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager Button_UToolTipManager;
        private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
        private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton EmployeeCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton EmployeeCdSt_GuideBtn;
        private TComboEditor DmdDtl_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DmdDtl_Label;
        private TEdit tEdit_EmployeeCode_Ed;
        private TEdit tEdit_EmployeeCode_St;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private TComboEditor NewPageDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraButton ub_SalesAreaCodeStGuid;
        private Infragistics.Win.Misc.UltraButton ub_SalesAreaCodeEdGuid;
        private TNedit tNedit_SalesAreaCode_St;
        private TNedit tNedit_SalesAreaCode_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private TComboEditor BalanceDepositDtl_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TComboEditor CollectRatePrtDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Panel panel_IssueType;
        private Panel panel_NewPage;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private TComboEditor IssueType_tComboEditor;
        private Panel panel_CollectRate;
        private Panel panel_IssueDay;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Panel panel_BalanceDepositDtl_;
        private TDateEdit IssueDay_tDateEdit;
        private Panel panel_DmdDtl;
        private UiMemInput uiMemInput1;
        private Panel panel_PrCustDtl;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private TComboEditor PrCustDtl_tComboEditor;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl6;
        private TNedit tEdit_SectionCode_Ed;
        private TNedit tEdit_SectionCode_St;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor endRangeNameUltraTextEditor;
        private Infragistics.Win.Misc.UltraLabel endRangeUltraLabel;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor startRangeNameUltraTextEditor;
        private Infragistics.Win.Misc.UltraLabel startRangeUltraLabel;
        private TComboEditor AccRecDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Panel panel_AccRecDivCd;
        private Panel panel_PrintBlLiDiv;
        private Infragistics.Win.Misc.UltraLabel Label_PrintBlLiDiv;
        private TComboEditor PrintBlLiDiv_tComboEditor;
        private Panel panel_LineMaSqOfChDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private TComboEditor lineMaSqOfChDiv_tComboEditor;
        private Panel panel9;
        private TComboEditor tComboEditor_TaxPrintDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private System.ComponentModel.IContainer components;
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// 請求書印刷(一覧・合計・明細)条件フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : コンストラクタ内処理の概要を記述</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// <br>Update Note: 2011/03/14 yangmj</br>                       
        /// <br>           : 印字制御の区分の追加</br>
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        public MAKAU02012UA()
        {
            InitializeComponent();

            mDemandPrintAcs = new DemandPrintAcs();
            mPdfHistoryControl = new PdfHistoryControl();

            this._extraInfo_DemandTotal = new ExtrInfo_DemandTotal();
            this._prevExtraInfo_DemandTotal = new ExtrInfo_DemandTotal();
            this._sectionCodeList = new Hashtable();

            // 出力済み履歴管理クラス
            this._printHistoryList = new Hashtable();
            this._printHistoryKeyList = new ArrayList();
            PdfHistoryControl.PdfHistoryListChanged += new PdfHistoryListChangedEvent(this.DisplaySettingPdfList);

            // >>>>> 2006.08.18 Y.Sasaki DEL START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //// 抽出中フォーム
            //this._extractionForm      = new MAKAU02012UB();
            // <<<<< 2006.08.18 Y.Sasaki DEL END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ログイン担当者
            this._loginEmployee = LoginInfoAcquisition.Employee.Clone();

            // アクセスクラス インスタンス生成
            this._employeeAcs = new EmployeeAcs();

            // 2008.09.09 30413 犬飼 ユーザーガイドの追加 >>>>>>START
            this._userGuideAcs = new UserGuideAcs();
            // 2008.09.09 30413 犬飼 ユーザーガイドの追加 <<<<<<END

            // 2008.09.08 30413 犬飼 日付取得部品の追加 >>>>>>START
            //日付取得部品
            this._dateGetAcs = DateGetAcs.GetInstance();
            // 2008.09.08 30413 犬飼 日付取得部品の追加 <<<<<<END

            // 2009.01.14 30413 犬飼 ＵＩ入力保存コンポーネントの追加 >>>>>>START
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.IssueType_tComboEditor);              // 発行タイプ
            ctrlList.Add(this.PrintOder_tComboEditor);              // 出力順
            ctrlList.Add(this.OutPutPriceCond_tComboEditor);        // 出力金額区分
            ctrlList.Add(this.DmdDtl_tComboEditor);                 // 請求先内訳
            
            // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ---------->>>>>
            //ctrlList.Add(this.AddUpDate_tDateEdit);             // 締日は保持項目ではない
            ctrlList.Add(this.NewPageDiv_tComboEditor);         // 改頁
            ctrlList.Add(this.ChargeEmployee_tComboEditor);     // 担当
            ctrlList.Add(this.tEdit_EmployeeCode_St);           // 従業員コード開始
            ctrlList.Add(this.tEdit_EmployeeCode_Ed);           // 従業員コード終了
            ctrlList.Add(this.tNedit_SalesAreaCode_St);         // 地区コード開始
            ctrlList.Add(this.tNedit_SalesAreaCode_Ed);         // 地区コード終了
            ctrlList.Add(this.tNedit_CustomerCode_St);          // 得意先コード開始
            ctrlList.Add(this.tNedit_CustomerCode_Ed);          // 得意先コード終了
            ctrlList.Add(this.AccRecDivCd_tComboEditor);        // 売掛区分
            ctrlList.Add(this.CollectRatePrtDiv_tComboEditor);  // 回収率印字
            ctrlList.Add(this.BalanceDepositDtl_tComboEditor);  // 残高入金内訳
            ctrlList.Add(this.PrCustDtl_tComboEditor);          // 親得意先内訳

            ctrlList.Add(this.IssueDay_tDateEdit);  // 発行日
            // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ----------<<<<<

            //---ADD 2011/03/14----->>>>>
            ctrlList.Add(this.PrintBlLiDiv_tComboEditor);        // 空白行印字
            ctrlList.Add(this.lineMaSqOfChDiv_tComboEditor);     // 罫線印字
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
            // 税別内訳印字区分
            ctrlList.Add(this.tComboEditor_TaxPrintDiv);
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

            //---ADD 2011/03/14-----<<<<<
            uiMemInput1.TargetControls = ctrlList;
            // 2009.01.14 30413 犬飼 ＵＩ入力保存コンポーネントの追加 <<<<<<END

            this.StatusBarInfoPrinted += new PrintStatusBar(PrintStatusBarOfDefault);
        }
        #endregion

        // ===================================================================================== //
        // 破棄
        // ===================================================================================== //
        # region Dispose
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ---------->>>>>
            // 選択している拠点を外部出力　※請求一覧で起動している場合のみ
            SectionTreeHelper.ExportCheckedSectionCode(this.Section_Tree, IsDemandListMode());
            // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ----------<<<<<

            base.Dispose(disposing);
        }
        #endregion

        // ===================================================================================== //
        // Windowsフォームデザイナで生成されたコード
        // ===================================================================================== //
        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem26 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem27 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem28 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem29 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem30 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("全て選択します", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("全ての選択を解除します", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup5 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup6 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup7 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("920e15ec-1184-42a2-9b25-5dbbe53ad37a"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("8c0ea4bb-1e17-45f9-8bf8-706ad246d773"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("920e15ec-1184-42a2-9b25-5dbbe53ad37a"), -1);
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tComboEditor_TaxPrintDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.panel_LineMaSqOfChDiv = new System.Windows.Forms.Panel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.lineMaSqOfChDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel_PrintBlLiDiv = new System.Windows.Forms.Panel();
            this.Label_PrintBlLiDiv = new Infragistics.Win.Misc.UltraLabel();
            this.PrintBlLiDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel_NewPage = new System.Windows.Forms.Panel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.NewPageDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AddUpDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.panel_IssueType = new System.Windows.Forms.Panel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.IssueType_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrintOder_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.panel_AccRecDivCd = new System.Windows.Forms.Panel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.AccRecDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ub_SalesAreaCodeStGuid = new Infragistics.Win.Misc.UltraButton();
            this.ub_SalesAreaCodeEdGuid = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_SalesAreaCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesAreaCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_EmployeeCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_EmployeeCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EmployeeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_CustomerCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EmployeeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ChargeEmployee_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraExplorerBarContainerControl5 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.panel_PrCustDtl = new System.Windows.Forms.Panel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.PrCustDtl_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel_DmdDtl = new System.Windows.Forms.Panel();
            this.DmdDtl_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DmdDtl_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel_IssueDay = new System.Windows.Forms.Panel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.IssueDay_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.panel_BalanceDepositDtl_ = new System.Windows.Forms.Panel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.BalanceDepositDtl_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel_CollectRate = new System.Windows.Forms.Panel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.CollectRatePrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BillTableOutPut_Label = new Infragistics.Win.Misc.UltraLabel();
            this.OutPutPriceCond_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraExplorerBarContainerControl6 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tEdit_SectionCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_SectionCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.endRangeNameUltraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.endRangeUltraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.startRangeNameUltraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.startRangeUltraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionList_ExplorerBarContainerControl = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.Section_Tree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.History_Tree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ExtraInfo_Panel = new System.Windows.Forms.Panel();
            this.Extra_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ExtraData_Panel = new System.Windows.Forms.Panel();
            this.DataView_Panel = new System.Windows.Forms.Panel();
            this.DEMANDLISTVIEW = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Total_Panel = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.RpSlipCount_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TotalLastDmd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.TotalDeposit_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.TotalSales_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ConsTaxTiTle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TotalTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TotalDmd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.PrintExtra_Panel = new System.Windows.Forms.Panel();
            this.AutoFillToGridColumn_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.Select_Button = new Infragistics.Win.Misc.UltraButton();
            this.UnSelect_Button = new Infragistics.Win.Misc.UltraButton();
            this.Main_ExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Main_TabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._MAKAU02012UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02012UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02012UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02012UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU02012UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tNedit6 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.History_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Button_UToolTipManager = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            this.ultraExplorerBarContainerControl2.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TaxPrintDiv)).BeginInit();
            this.panel_LineMaSqOfChDiv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineMaSqOfChDiv_tComboEditor)).BeginInit();
            this.panel_PrintBlLiDiv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintBlLiDiv_tComboEditor)).BeginInit();
            this.panel_NewPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewPageDiv_tComboEditor)).BeginInit();
            this.panel_IssueType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IssueType_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            this.panel_AccRecDivCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccRecDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChargeEmployee_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl5.SuspendLayout();
            this.panel_PrCustDtl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrCustDtl_tComboEditor)).BeginInit();
            this.panel_DmdDtl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DmdDtl_tComboEditor)).BeginInit();
            this.panel_IssueDay.SuspendLayout();
            this.panel_BalanceDepositDtl_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceDepositDtl_tComboEditor)).BeginInit();
            this.panel_CollectRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CollectRatePrtDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutPutPriceCond_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endRangeNameUltraTextEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRangeNameUltraTextEditor)).BeginInit();
            this.SectionList_ExplorerBarContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Section_Tree)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.History_Tree)).BeginInit();
            this.ultraTabPageControl1.SuspendLayout();
            this.ExtraInfo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Extra_ultraExplorerBar)).BeginInit();
            this.Extra_ultraExplorerBar.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.ExtraData_Panel.SuspendLayout();
            this.DataView_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DEMANDLISTVIEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.Total_Panel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RpSlipCount_tNedit)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalLastDmd_tNedit)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDeposit_tNedit)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSales_tNedit)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalTax_tNedit)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDmd_tNedit)).BeginInit();
            this.PrintExtra_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ExplorerBar)).BeginInit();
            this.Main_ExplorerBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_TabControl)).BeginInit();
            this.Main_TabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            this.dockableWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit6)).BeginInit();
            this.windowDockingArea1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl2
            // 
            this.ultraExplorerBarContainerControl2.Controls.Add(this.panel9);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.panel_LineMaSqOfChDiv);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.panel_PrintBlLiDiv);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.panel_NewPage);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.AddUpDate_tDateEdit);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.panel_IssueType);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
            this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(644, 214);
            this.ultraExplorerBarContainerControl2.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tComboEditor_TaxPrintDiv);
            this.panel9.Controls.Add(this.ultraLabel20);
            this.panel9.Location = new System.Drawing.Point(3, 180);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(535, 30);
            this.panel9.TabIndex = 209;
            this.panel9.Visible = false;
            // 
            // tComboEditor_TaxPrintDiv
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TaxPrintDiv.ActiveAppearance = appearance49;
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_TaxPrintDiv.Appearance = appearance51;
            this.tComboEditor_TaxPrintDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_TaxPrintDiv.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_TaxPrintDiv.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TaxPrintDiv.ItemAppearance = appearance50;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "印字する";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "印字しない";
            this.tComboEditor_TaxPrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.tComboEditor_TaxPrintDiv.Location = new System.Drawing.Point(205, 3);
            this.tComboEditor_TaxPrintDiv.Name = "tComboEditor_TaxPrintDiv";
            this.tComboEditor_TaxPrintDiv.Size = new System.Drawing.Size(176, 24);
            this.tComboEditor_TaxPrintDiv.TabIndex = 1;
            // 
            // ultraLabel20
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance48;
            this.ultraLabel20.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel20.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel20.Location = new System.Drawing.Point(46, 4);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(141, 23);
            this.ultraLabel20.TabIndex = 210;
            this.ultraLabel20.Text = "税別内訳印字";
            // 
            // panel_LineMaSqOfChDiv
            // 
            this.panel_LineMaSqOfChDiv.Controls.Add(this.ultraLabel15);
            this.panel_LineMaSqOfChDiv.Controls.Add(this.lineMaSqOfChDiv_tComboEditor);
            this.panel_LineMaSqOfChDiv.Location = new System.Drawing.Point(3, 143);
            this.panel_LineMaSqOfChDiv.Name = "panel_LineMaSqOfChDiv";
            this.panel_LineMaSqOfChDiv.Size = new System.Drawing.Size(535, 30);
            this.panel_LineMaSqOfChDiv.TabIndex = 4;
            this.panel_LineMaSqOfChDiv.Visible = false;
            // 
            // ultraLabel15
            // 
            appearance134.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance134;
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel15.Location = new System.Drawing.Point(47, 3);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel15.TabIndex = 208;
            this.ultraLabel15.Text = "罫線印字";
            // 
            // lineMaSqOfChDiv_tComboEditor
            // 
            appearance135.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.lineMaSqOfChDiv_tComboEditor.ActiveAppearance = appearance135;
            appearance136.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.lineMaSqOfChDiv_tComboEditor.Appearance = appearance136;
            this.lineMaSqOfChDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.lineMaSqOfChDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.lineMaSqOfChDiv_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance137.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.lineMaSqOfChDiv_tComboEditor.ItemAppearance = appearance137;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "印字する";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "印字しない";
            this.lineMaSqOfChDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.lineMaSqOfChDiv_tComboEditor.Location = new System.Drawing.Point(205, 3);
            this.lineMaSqOfChDiv_tComboEditor.Name = "lineMaSqOfChDiv_tComboEditor";
            this.lineMaSqOfChDiv_tComboEditor.Size = new System.Drawing.Size(176, 24);
            this.lineMaSqOfChDiv_tComboEditor.TabIndex = 1;
            // 
            // panel_PrintBlLiDiv
            // 
            this.panel_PrintBlLiDiv.Controls.Add(this.Label_PrintBlLiDiv);
            this.panel_PrintBlLiDiv.Controls.Add(this.PrintBlLiDiv_tComboEditor);
            this.panel_PrintBlLiDiv.Location = new System.Drawing.Point(3, 107);
            this.panel_PrintBlLiDiv.Name = "panel_PrintBlLiDiv";
            this.panel_PrintBlLiDiv.Size = new System.Drawing.Size(535, 30);
            this.panel_PrintBlLiDiv.TabIndex = 3;
            this.panel_PrintBlLiDiv.Visible = false;
            // 
            // Label_PrintBlLiDiv
            // 
            appearance130.TextVAlignAsString = "Middle";
            this.Label_PrintBlLiDiv.Appearance = appearance130;
            this.Label_PrintBlLiDiv.BackColorInternal = System.Drawing.Color.Transparent;
            this.Label_PrintBlLiDiv.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_PrintBlLiDiv.Location = new System.Drawing.Point(47, 3);
            this.Label_PrintBlLiDiv.Name = "Label_PrintBlLiDiv";
            this.Label_PrintBlLiDiv.Size = new System.Drawing.Size(100, 23);
            this.Label_PrintBlLiDiv.TabIndex = 208;
            this.Label_PrintBlLiDiv.Text = "空白行印字";
            // 
            // PrintBlLiDiv_tComboEditor
            // 
            appearance131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintBlLiDiv_tComboEditor.ActiveAppearance = appearance131;
            appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintBlLiDiv_tComboEditor.Appearance = appearance132;
            this.PrintBlLiDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintBlLiDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrintBlLiDiv_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintBlLiDiv_tComboEditor.ItemAppearance = appearance133;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "印字する";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "印字しない";
            this.PrintBlLiDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6});
            this.PrintBlLiDiv_tComboEditor.Location = new System.Drawing.Point(205, 3);
            this.PrintBlLiDiv_tComboEditor.Name = "PrintBlLiDiv_tComboEditor";
            this.PrintBlLiDiv_tComboEditor.Size = new System.Drawing.Size(176, 24);
            this.PrintBlLiDiv_tComboEditor.TabIndex = 1;
            // 
            // panel_NewPage
            // 
            this.panel_NewPage.Controls.Add(this.ultraLabel1);
            this.panel_NewPage.Controls.Add(this.NewPageDiv_tComboEditor);
            this.panel_NewPage.Location = new System.Drawing.Point(3, 35);
            this.panel_NewPage.Name = "panel_NewPage";
            this.panel_NewPage.Size = new System.Drawing.Size(535, 30);
            this.panel_NewPage.TabIndex = 1;
            this.panel_NewPage.Visible = false;
            // 
            // ultraLabel1
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance38;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel1.Location = new System.Drawing.Point(47, 3);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel1.TabIndex = 208;
            this.ultraLabel1.Text = "改　　頁";
            // 
            // NewPageDiv_tComboEditor
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageDiv_tComboEditor.ActiveAppearance = appearance17;
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NewPageDiv_tComboEditor.Appearance = appearance34;
            this.NewPageDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NewPageDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.NewPageDiv_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageDiv_tComboEditor.ItemAppearance = appearance18;
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "拠点";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "小計";
            valueListItem9.DataValue = 2;
            valueListItem9.DisplayText = "しない";
            this.NewPageDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9});
            this.NewPageDiv_tComboEditor.Location = new System.Drawing.Point(205, 3);
            this.NewPageDiv_tComboEditor.Name = "NewPageDiv_tComboEditor";
            this.NewPageDiv_tComboEditor.Size = new System.Drawing.Size(176, 24);
            this.NewPageDiv_tComboEditor.TabIndex = 1;
            // 
            // AddUpDate_tDateEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AddUpDate_tDateEdit.ActiveEditAppearance = appearance7;
            this.AddUpDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.AddUpDate_tDateEdit.CalendarDisp = true;
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance26.TextHAlignAsString = "Left";
            appearance26.TextVAlignAsString = "Middle";
            this.AddUpDate_tDateEdit.EditAppearance = appearance26;
            this.AddUpDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.AddUpDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AddUpDate_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance32.TextHAlignAsString = "Left";
            appearance32.TextVAlignAsString = "Middle";
            this.AddUpDate_tDateEdit.LabelAppearance = appearance32;
            this.AddUpDate_tDateEdit.Location = new System.Drawing.Point(208, 6);
            this.AddUpDate_tDateEdit.Name = "AddUpDate_tDateEdit";
            this.AddUpDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.AddUpDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.AddUpDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.AddUpDate_tDateEdit.TabIndex = 0;
            this.AddUpDate_tDateEdit.TabStop = true;
            // 
            // panel_IssueType
            // 
            this.panel_IssueType.Controls.Add(this.ultraLabel9);
            this.panel_IssueType.Controls.Add(this.IssueType_tComboEditor);
            this.panel_IssueType.Location = new System.Drawing.Point(3, 71);
            this.panel_IssueType.Name = "panel_IssueType";
            this.panel_IssueType.Size = new System.Drawing.Size(535, 30);
            this.panel_IssueType.TabIndex = 2;
            this.panel_IssueType.Visible = false;
            // 
            // ultraLabel9
            // 
            appearance126.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance126;
            this.ultraLabel9.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel9.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel9.Location = new System.Drawing.Point(47, 3);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel9.TabIndex = 208;
            this.ultraLabel9.Text = "発行タイプ";
            // 
            // IssueType_tComboEditor
            // 
            appearance127.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.IssueType_tComboEditor.ActiveAppearance = appearance127;
            appearance128.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.IssueType_tComboEditor.Appearance = appearance128;
            this.IssueType_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.IssueType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.IssueType_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance129.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.IssueType_tComboEditor.ItemAppearance = appearance129;
            valueListItem10.DataValue = 50;
            valueListItem10.DisplayText = "合計請求書";
            valueListItem11.DataValue = 60;
            valueListItem11.DisplayText = "明細請求書";
            valueListItem12.DataValue = 70;
            valueListItem12.DisplayText = "伝票合計請求書";
            this.IssueType_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11,
            valueListItem12});
            this.IssueType_tComboEditor.Location = new System.Drawing.Point(205, 3);
            this.IssueType_tComboEditor.Name = "IssueType_tComboEditor";
            this.IssueType_tComboEditor.Size = new System.Drawing.Size(176, 24);
            this.IssueType_tComboEditor.TabIndex = 1;
            // 
            // ultraLabel3
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance11;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(50, 6);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 208;
            this.ultraLabel3.Text = "締　　日";
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOder_tComboEditor);
            this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraLabel5);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(18, 298);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(644, 43);
            this.ultraExplorerBarContainerControl3.TabIndex = 1;
            // 
            // PrintOder_tComboEditor
            // 
            appearance122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ActiveAppearance = appearance122;
            appearance123.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.Appearance = appearance123;
            this.PrintOder_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrintOder_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ItemAppearance = appearance124;
            valueListItem13.DataValue = 0;
            valueListItem13.DisplayText = "得意先順";
            valueListItem14.DataValue = 1;
            valueListItem14.DisplayText = "担当者順";
            valueListItem15.DataValue = 2;
            valueListItem15.DisplayText = "地区順";
            this.PrintOder_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem13,
            valueListItem14,
            valueListItem15});
            this.PrintOder_tComboEditor.Location = new System.Drawing.Point(208, 12);
            this.PrintOder_tComboEditor.Name = "PrintOder_tComboEditor";
            this.PrintOder_tComboEditor.Size = new System.Drawing.Size(184, 24);
            this.PrintOder_tComboEditor.TabIndex = 0;
            this.PrintOder_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.PrintOder_tComboEditor_SelectionChangeCommitted);
            // 
            // ultraLabel5
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance3;
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel5.Location = new System.Drawing.Point(50, 12);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel5.TabIndex = 209;
            this.ultraLabel5.Text = "出力順";
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.panel_AccRecDivCd);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ub_SalesAreaCodeStGuid);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ub_SalesAreaCodeEdGuid);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tNedit_SalesAreaCode_St);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tNedit_SalesAreaCode_Ed);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tEdit_EmployeeCode_Ed);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tEdit_EmployeeCode_St);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel14);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tNedit_CustomerCode_Ed);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.EmployeeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tNedit_CustomerCode_St);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.EmployeeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ChargeEmployee_tComboEditor);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 379);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(644, 126);
            this.ultraExplorerBarContainerControl4.TabIndex = 2;
            // 
            // panel_AccRecDivCd
            // 
            this.panel_AccRecDivCd.Controls.Add(this.ultraLabel13);
            this.panel_AccRecDivCd.Controls.Add(this.AccRecDivCd_tComboEditor);
            this.panel_AccRecDivCd.Location = new System.Drawing.Point(3, 93);
            this.panel_AccRecDivCd.Name = "panel_AccRecDivCd";
            this.panel_AccRecDivCd.Size = new System.Drawing.Size(535, 30);
            this.panel_AccRecDivCd.TabIndex = 13;
            // 
            // ultraLabel13
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance12;
            this.ultraLabel13.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel13.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel13.Location = new System.Drawing.Point(46, 3);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel13.TabIndex = 251;
            this.ultraLabel13.Text = "売掛区分";
            // 
            // AccRecDivCd_tComboEditor
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AccRecDivCd_tComboEditor.ActiveAppearance = appearance1;
            appearance104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AccRecDivCd_tComboEditor.Appearance = appearance104;
            this.AccRecDivCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AccRecDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AccRecDivCd_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AccRecDivCd_tComboEditor.ItemAppearance = appearance2;
            valueListItem16.DataValue = 1;
            valueListItem16.DisplayText = "売掛";
            valueListItem17.DataValue = 0;
            valueListItem17.DisplayText = "売掛なし";
            valueListItem18.DataValue = -1;
            valueListItem18.DisplayText = "全て";
            this.AccRecDivCd_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem16,
            valueListItem17,
            valueListItem18});
            this.AccRecDivCd_tComboEditor.Location = new System.Drawing.Point(205, 3);
            this.AccRecDivCd_tComboEditor.Name = "AccRecDivCd_tComboEditor";
            this.AccRecDivCd_tComboEditor.Size = new System.Drawing.Size(184, 24);
            this.AccRecDivCd_tComboEditor.TabIndex = 0;
            this.AccRecDivCd_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.PrintOder_tComboEditor_SelectionChangeCommitted);
            // 
            // ultraLabel2
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance27;
            this.ultraLabel2.Location = new System.Drawing.Point(50, 38);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel2.TabIndex = 257;
            this.ultraLabel2.Text = "地区";
            // 
            // ub_SalesAreaCodeStGuid
            // 
            appearance28.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_SalesAreaCodeStGuid.Appearance = appearance28;
            this.ub_SalesAreaCodeStGuid.Location = new System.Drawing.Point(262, 37);
            this.ub_SalesAreaCodeStGuid.Name = "ub_SalesAreaCodeStGuid";
            this.ub_SalesAreaCodeStGuid.Size = new System.Drawing.Size(25, 25);
            this.ub_SalesAreaCodeStGuid.TabIndex = 6;
            this.ub_SalesAreaCodeStGuid.Tag = "3";
            this.ub_SalesAreaCodeStGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_SalesAreaCodeStGuid.Click += new System.EventHandler(this.ub_SalesAreaCodeStGuid_Click);
            // 
            // ub_SalesAreaCodeEdGuid
            // 
            appearance29.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_SalesAreaCodeEdGuid.Appearance = appearance29;
            this.ub_SalesAreaCodeEdGuid.Location = new System.Drawing.Point(419, 37);
            this.ub_SalesAreaCodeEdGuid.Name = "ub_SalesAreaCodeEdGuid";
            this.ub_SalesAreaCodeEdGuid.Size = new System.Drawing.Size(25, 25);
            this.ub_SalesAreaCodeEdGuid.TabIndex = 8;
            this.ub_SalesAreaCodeEdGuid.Tag = "4";
            this.ub_SalesAreaCodeEdGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_SalesAreaCodeEdGuid.Click += new System.EventHandler(this.ub_SalesAreaCodeEdGuid_Click);
            // 
            // tNedit_SalesAreaCode_St
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SalesAreaCode_St.ActiveAppearance = appearance74;
            appearance75.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_St.Appearance = appearance75;
            this.tNedit_SalesAreaCode_St.AutoSelect = true;
            this.tNedit_SalesAreaCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_St.DataText = "";
            this.tNedit_SalesAreaCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_St.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SalesAreaCode_St.Location = new System.Drawing.Point(212, 38);
            this.tNedit_SalesAreaCode_St.MaxLength = 4;
            this.tNedit_SalesAreaCode_St.Name = "tNedit_SalesAreaCode_St";
            this.tNedit_SalesAreaCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesAreaCode_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_SalesAreaCode_St.TabIndex = 5;
            // 
            // tNedit_SalesAreaCode_Ed
            // 
            appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SalesAreaCode_Ed.ActiveAppearance = appearance76;
            appearance84.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_Ed.Appearance = appearance84;
            this.tNedit_SalesAreaCode_Ed.AutoSelect = true;
            this.tNedit_SalesAreaCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_Ed.DataText = "";
            this.tNedit_SalesAreaCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SalesAreaCode_Ed.Location = new System.Drawing.Point(369, 38);
            this.tNedit_SalesAreaCode_Ed.MaxLength = 4;
            this.tNedit_SalesAreaCode_Ed.Name = "tNedit_SalesAreaCode_Ed";
            this.tNedit_SalesAreaCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesAreaCode_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_SalesAreaCode_Ed.TabIndex = 7;
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance8.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance8;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(459, 67);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 12;
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // tEdit_EmployeeCode_Ed
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode_Ed.ActiveAppearance = appearance31;
            this.tEdit_EmployeeCode_Ed.AutoSelect = true;
            this.tEdit_EmployeeCode_Ed.DataText = "";
            this.tEdit_EmployeeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_EmployeeCode_Ed.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_EmployeeCode_Ed.Location = new System.Drawing.Point(369, 8);
            this.tEdit_EmployeeCode_Ed.MaxLength = 9;
            this.tEdit_EmployeeCode_Ed.Name = "tEdit_EmployeeCode_Ed";
            this.tEdit_EmployeeCode_Ed.Size = new System.Drawing.Size(44, 24);
            this.tEdit_EmployeeCode_Ed.TabIndex = 3;
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance39.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance39;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(302, 67);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 10;
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // tEdit_EmployeeCode_St
            // 
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode_St.ActiveAppearance = appearance93;
            this.tEdit_EmployeeCode_St.AutoSelect = true;
            this.tEdit_EmployeeCode_St.DataText = "";
            this.tEdit_EmployeeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_EmployeeCode_St.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_EmployeeCode_St.Location = new System.Drawing.Point(212, 8);
            this.tEdit_EmployeeCode_St.MaxLength = 9;
            this.tEdit_EmployeeCode_St.Name = "tEdit_EmployeeCode_St";
            this.tEdit_EmployeeCode_St.Size = new System.Drawing.Size(44, 24);
            this.tEdit_EmployeeCode_St.TabIndex = 1;
            // 
            // ultraLabel14
            // 
            appearance125.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance125;
            this.ultraLabel14.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel14.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel14.Location = new System.Drawing.Point(50, 67);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel14.TabIndex = 251;
            this.ultraLabel14.Text = "得意先";
            // 
            // tNedit_CustomerCode_Ed
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode_Ed.ActiveAppearance = appearance13;
            appearance14.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.Appearance = appearance14;
            this.tNedit_CustomerCode_Ed.AutoSelect = true;
            this.tNedit_CustomerCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_Ed.DataText = "";
            this.tNedit_CustomerCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_Ed.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustomerCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_Ed.Location = new System.Drawing.Point(369, 67);
            this.tNedit_CustomerCode_Ed.MaxLength = 8;
            this.tNedit_CustomerCode_Ed.Name = "tNedit_CustomerCode_Ed";
            this.tNedit_CustomerCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode_Ed.Size = new System.Drawing.Size(84, 24);
            this.tNedit_CustomerCode_Ed.TabIndex = 11;
            // 
            // EmployeeCdEd_GuideBtn
            // 
            appearance94.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.EmployeeCdEd_GuideBtn.Appearance = appearance94;
            this.EmployeeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.EmployeeCdEd_GuideBtn.Location = new System.Drawing.Point(419, 7);
            this.EmployeeCdEd_GuideBtn.Name = "EmployeeCdEd_GuideBtn";
            this.EmployeeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.EmployeeCdEd_GuideBtn.TabIndex = 4;
            this.EmployeeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.EmployeeCdEd_GuideBtn.Click += new System.EventHandler(this.EmployeeCdEd_GuideBtn_Click);
            // 
            // tNedit_CustomerCode_St
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode_St.ActiveAppearance = appearance15;
            appearance16.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.Appearance = appearance16;
            this.tNedit_CustomerCode_St.AutoSelect = true;
            this.tNedit_CustomerCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_St.DataText = "";
            this.tNedit_CustomerCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_St.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustomerCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_St.Location = new System.Drawing.Point(212, 67);
            this.tNedit_CustomerCode_St.MaxLength = 8;
            this.tNedit_CustomerCode_St.Name = "tNedit_CustomerCode_St";
            this.tNedit_CustomerCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode_St.Size = new System.Drawing.Size(84, 24);
            this.tNedit_CustomerCode_St.TabIndex = 9;
            // 
            // EmployeeCdSt_GuideBtn
            // 
            appearance30.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.EmployeeCdSt_GuideBtn.Appearance = appearance30;
            this.EmployeeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.EmployeeCdSt_GuideBtn.Location = new System.Drawing.Point(262, 7);
            this.EmployeeCdSt_GuideBtn.Name = "EmployeeCdSt_GuideBtn";
            this.EmployeeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.EmployeeCdSt_GuideBtn.TabIndex = 2;
            this.EmployeeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.EmployeeCdSt_GuideBtn.Click += new System.EventHandler(this.EmployeeCdSt_GuideBtn_Click);
            // 
            // ultraLabel7
            // 
            appearance21.TextHAlignAsString = "Center";
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance21;
            this.ultraLabel7.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel7.Location = new System.Drawing.Point(333, 68);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(30, 24);
            this.ultraLabel7.TabIndex = 244;
            this.ultraLabel7.Text = "～";
            // 
            // ultraLabel8
            // 
            appearance33.TextHAlignAsString = "Center";
            appearance33.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance33;
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel8.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel8.Location = new System.Drawing.Point(333, 39);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(30, 23);
            this.ultraLabel8.TabIndex = 239;
            this.ultraLabel8.Text = "～";
            // 
            // ultraLabel10
            // 
            appearance95.TextHAlignAsString = "Center";
            appearance95.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance95;
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel10.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(333, 9);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(30, 23);
            this.ultraLabel10.TabIndex = 239;
            this.ultraLabel10.Text = "～";
            // 
            // ChargeEmployee_tComboEditor
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ChargeEmployee_tComboEditor.ActiveAppearance = appearance20;
            appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ChargeEmployee_tComboEditor.Appearance = appearance113;
            this.ChargeEmployee_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ChargeEmployee_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ChargeEmployee_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ChargeEmployee_tComboEditor.ItemAppearance = appearance24;
            valueListItem19.DataValue = 0;
            valueListItem19.DisplayText = "得意先担当";
            valueListItem20.DataValue = 1;
            valueListItem20.DisplayText = "集金担当";
            this.ChargeEmployee_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem19,
            valueListItem20});
            this.ChargeEmployee_tComboEditor.Location = new System.Drawing.Point(50, 8);
            this.ChargeEmployee_tComboEditor.Name = "ChargeEmployee_tComboEditor";
            this.ChargeEmployee_tComboEditor.Size = new System.Drawing.Size(140, 24);
            this.ChargeEmployee_tComboEditor.TabIndex = 0;
            // 
            // ultraExplorerBarContainerControl5
            // 
            this.ultraExplorerBarContainerControl5.Controls.Add(this.panel_PrCustDtl);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.panel_DmdDtl);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.panel_IssueDay);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.panel_BalanceDepositDtl_);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.panel_CollectRate);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.BillTableOutPut_Label);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.OutPutPriceCond_tComboEditor);
            this.ultraExplorerBarContainerControl5.Location = new System.Drawing.Point(18, 543);
            this.ultraExplorerBarContainerControl5.Name = "ultraExplorerBarContainerControl5";
            this.ultraExplorerBarContainerControl5.Size = new System.Drawing.Size(644, 209);
            this.ultraExplorerBarContainerControl5.TabIndex = 3;
            // 
            // panel_PrCustDtl
            // 
            this.panel_PrCustDtl.Controls.Add(this.ultraLabel12);
            this.panel_PrCustDtl.Controls.Add(this.PrCustDtl_tComboEditor);
            this.panel_PrCustDtl.Location = new System.Drawing.Point(3, 176);
            this.panel_PrCustDtl.Name = "panel_PrCustDtl";
            this.panel_PrCustDtl.Size = new System.Drawing.Size(535, 30);
            this.panel_PrCustDtl.TabIndex = 250;
            this.panel_PrCustDtl.Visible = false;
            // 
            // ultraLabel12
            // 
            appearance114.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance114;
            this.ultraLabel12.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel12.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel12.Location = new System.Drawing.Point(46, 3);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(110, 23);
            this.ultraLabel12.TabIndex = 249;
            this.ultraLabel12.Text = "親得意先内訳";
            // 
            // PrCustDtl_tComboEditor
            // 
            appearance115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrCustDtl_tComboEditor.ActiveAppearance = appearance115;
            appearance116.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrCustDtl_tComboEditor.Appearance = appearance116;
            this.PrCustDtl_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrCustDtl_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance117.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrCustDtl_tComboEditor.ItemAppearance = appearance117;
            valueListItem21.DataValue = 0;
            valueListItem21.DisplayText = "請求先へ含む";
            valueListItem22.DataValue = 1;
            valueListItem22.DisplayText = "請求先へ含まない";
            this.PrCustDtl_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem21,
            valueListItem22});
            this.PrCustDtl_tComboEditor.Location = new System.Drawing.Point(205, 3);
            this.PrCustDtl_tComboEditor.Name = "PrCustDtl_tComboEditor";
            this.PrCustDtl_tComboEditor.Size = new System.Drawing.Size(283, 24);
            this.PrCustDtl_tComboEditor.TabIndex = 0;
            // 
            // panel_DmdDtl
            // 
            this.panel_DmdDtl.Controls.Add(this.DmdDtl_Label);
            this.panel_DmdDtl.Controls.Add(this.DmdDtl_tComboEditor);
            this.panel_DmdDtl.Location = new System.Drawing.Point(3, 68);
            this.panel_DmdDtl.Name = "panel_DmdDtl";
            this.panel_DmdDtl.Size = new System.Drawing.Size(535, 30);
            this.panel_DmdDtl.TabIndex = 3;
            this.panel_DmdDtl.Visible = false;
            // 
            // DmdDtl_Label
            // 
            appearance97.TextVAlignAsString = "Middle";
            this.DmdDtl_Label.Appearance = appearance97;
            this.DmdDtl_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DmdDtl_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DmdDtl_Label.Location = new System.Drawing.Point(46, 3);
            this.DmdDtl_Label.Name = "DmdDtl_Label";
            this.DmdDtl_Label.Size = new System.Drawing.Size(108, 23);
            this.DmdDtl_Label.TabIndex = 250;
            this.DmdDtl_Label.Text = "請求先内訳";
            // 
            // DmdDtl_tComboEditor
            // 
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DmdDtl_tComboEditor.ActiveAppearance = appearance96;
            appearance107.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DmdDtl_tComboEditor.Appearance = appearance107;
            this.DmdDtl_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DmdDtl_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DmdDtl_tComboEditor.ItemAppearance = appearance111;
            valueListItem23.DataValue = 0;
            valueListItem23.DisplayText = "両方";
            valueListItem24.DataValue = 1;
            valueListItem24.DisplayText = "請求先";
            valueListItem25.DataValue = 2;
            valueListItem25.DisplayText = "得意先";
            this.DmdDtl_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem23,
            valueListItem24,
            valueListItem25});
            this.DmdDtl_tComboEditor.Location = new System.Drawing.Point(205, 3);
            this.DmdDtl_tComboEditor.Name = "DmdDtl_tComboEditor";
            this.DmdDtl_tComboEditor.Size = new System.Drawing.Size(283, 24);
            this.DmdDtl_tComboEditor.TabIndex = 2;
            this.DmdDtl_tComboEditor.ValueChanged += new System.EventHandler(this.DmdDtl_tComboEditor_ValueChanged);
            // 
            // panel_IssueDay
            // 
            this.panel_IssueDay.Controls.Add(this.ultraLabel11);
            this.panel_IssueDay.Controls.Add(this.IssueDay_tDateEdit);
            this.panel_IssueDay.Location = new System.Drawing.Point(3, 140);
            this.panel_IssueDay.Name = "panel_IssueDay";
            this.panel_IssueDay.Size = new System.Drawing.Size(535, 30);
            this.panel_IssueDay.TabIndex = 1;
            this.panel_IssueDay.Visible = false;
            // 
            // ultraLabel11
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance37;
            this.ultraLabel11.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel11.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel11.Location = new System.Drawing.Point(46, 3);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(108, 23);
            this.ultraLabel11.TabIndex = 250;
            this.ultraLabel11.Text = "発行日";
            // 
            // IssueDay_tDateEdit
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.IssueDay_tDateEdit.ActiveEditAppearance = appearance4;
            this.IssueDay_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.IssueDay_tDateEdit.CalendarDisp = true;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.IssueDay_tDateEdit.EditAppearance = appearance5;
            this.IssueDay_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.IssueDay_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.IssueDay_tDateEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.IssueDay_tDateEdit.LabelAppearance = appearance6;
            this.IssueDay_tDateEdit.Location = new System.Drawing.Point(205, 3);
            this.IssueDay_tDateEdit.Name = "IssueDay_tDateEdit";
            this.IssueDay_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.IssueDay_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.IssueDay_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.IssueDay_tDateEdit.TabIndex = 0;
            this.IssueDay_tDateEdit.TabStop = true;
            this.IssueDay_tDateEdit.ValueChanged += new System.EventHandler(this.AddUpDate_tDateEdit_ValueChanged);
            // 
            // panel_BalanceDepositDtl_
            // 
            this.panel_BalanceDepositDtl_.Controls.Add(this.ultraLabel6);
            this.panel_BalanceDepositDtl_.Controls.Add(this.BalanceDepositDtl_tComboEditor);
            this.panel_BalanceDepositDtl_.Location = new System.Drawing.Point(3, 104);
            this.panel_BalanceDepositDtl_.Name = "panel_BalanceDepositDtl_";
            this.panel_BalanceDepositDtl_.Size = new System.Drawing.Size(535, 30);
            this.panel_BalanceDepositDtl_.TabIndex = 4;
            this.panel_BalanceDepositDtl_.Visible = false;
            // 
            // ultraLabel6
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance25;
            this.ultraLabel6.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(46, 3);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(108, 23);
            this.ultraLabel6.TabIndex = 250;
            this.ultraLabel6.Text = "残高入金内訳";
            // 
            // BalanceDepositDtl_tComboEditor
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BalanceDepositDtl_tComboEditor.ActiveAppearance = appearance36;
            appearance108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BalanceDepositDtl_tComboEditor.Appearance = appearance108;
            this.BalanceDepositDtl_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BalanceDepositDtl_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BalanceDepositDtl_tComboEditor.ItemAppearance = appearance112;
            valueListItem26.DataValue = 0;
            valueListItem26.DisplayText = "印字する";
            valueListItem27.DataValue = 1;
            valueListItem27.DisplayText = "印字しない";
            this.BalanceDepositDtl_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem26,
            valueListItem27});
            this.BalanceDepositDtl_tComboEditor.Location = new System.Drawing.Point(205, 3);
            this.BalanceDepositDtl_tComboEditor.Name = "BalanceDepositDtl_tComboEditor";
            this.BalanceDepositDtl_tComboEditor.Size = new System.Drawing.Size(283, 24);
            this.BalanceDepositDtl_tComboEditor.TabIndex = 3;
            // 
            // panel_CollectRate
            // 
            this.panel_CollectRate.Controls.Add(this.ultraLabel4);
            this.panel_CollectRate.Controls.Add(this.CollectRatePrtDiv_tComboEditor);
            this.panel_CollectRate.Location = new System.Drawing.Point(3, 5);
            this.panel_CollectRate.Name = "panel_CollectRate";
            this.panel_CollectRate.Size = new System.Drawing.Size(535, 30);
            this.panel_CollectRate.TabIndex = 0;
            this.panel_CollectRate.Visible = false;
            // 
            // ultraLabel4
            // 
            appearance118.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance118;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(46, 3);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(110, 23);
            this.ultraLabel4.TabIndex = 249;
            this.ultraLabel4.Text = "回収率印字";
            // 
            // CollectRatePrtDiv_tComboEditor
            // 
            appearance119.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CollectRatePrtDiv_tComboEditor.ActiveAppearance = appearance119;
            appearance120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CollectRatePrtDiv_tComboEditor.Appearance = appearance120;
            this.CollectRatePrtDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CollectRatePrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance121.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CollectRatePrtDiv_tComboEditor.ItemAppearance = appearance121;
            valueListItem28.DataValue = 0;
            valueListItem28.DisplayText = "前回残計算";
            valueListItem29.DataValue = 1;
            valueListItem29.DisplayText = "回収月計算";
            valueListItem30.DataValue = 2;
            valueListItem30.DisplayText = "印字なし";
            this.CollectRatePrtDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem28,
            valueListItem29,
            valueListItem30});
            this.CollectRatePrtDiv_tComboEditor.Location = new System.Drawing.Point(205, 3);
            this.CollectRatePrtDiv_tComboEditor.Name = "CollectRatePrtDiv_tComboEditor";
            this.CollectRatePrtDiv_tComboEditor.Size = new System.Drawing.Size(283, 24);
            this.CollectRatePrtDiv_tComboEditor.TabIndex = 0;
            // 
            // BillTableOutPut_Label
            // 
            appearance98.TextVAlignAsString = "Middle";
            this.BillTableOutPut_Label.Appearance = appearance98;
            this.BillTableOutPut_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BillTableOutPut_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillTableOutPut_Label.Location = new System.Drawing.Point(49, 40);
            this.BillTableOutPut_Label.Name = "BillTableOutPut_Label";
            this.BillTableOutPut_Label.Size = new System.Drawing.Size(110, 23);
            this.BillTableOutPut_Label.TabIndex = 249;
            this.BillTableOutPut_Label.Text = "出力金額区分";
            // 
            // OutPutPriceCond_tComboEditor
            // 
            appearance99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OutPutPriceCond_tComboEditor.ActiveAppearance = appearance99;
            appearance106.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.OutPutPriceCond_tComboEditor.Appearance = appearance106;
            this.OutPutPriceCond_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.OutPutPriceCond_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OutPutPriceCond_tComboEditor.ItemAppearance = appearance110;
            this.OutPutPriceCond_tComboEditor.Location = new System.Drawing.Point(208, 38);
            this.OutPutPriceCond_tComboEditor.Name = "OutPutPriceCond_tComboEditor";
            this.OutPutPriceCond_tComboEditor.Size = new System.Drawing.Size(283, 24);
            this.OutPutPriceCond_tComboEditor.TabIndex = 2;
            // 
            // ultraExplorerBarContainerControl6
            // 
            this.ultraExplorerBarContainerControl6.Controls.Add(this.tEdit_SectionCode_Ed);
            this.ultraExplorerBarContainerControl6.Controls.Add(this.tEdit_SectionCode_St);
            this.ultraExplorerBarContainerControl6.Controls.Add(this.endRangeNameUltraTextEditor);
            this.ultraExplorerBarContainerControl6.Controls.Add(this.endRangeUltraLabel);
            this.ultraExplorerBarContainerControl6.Controls.Add(this.startRangeNameUltraTextEditor);
            this.ultraExplorerBarContainerControl6.Controls.Add(this.startRangeUltraLabel);
            this.ultraExplorerBarContainerControl6.Location = new System.Drawing.Point(28, 48);
            this.ultraExplorerBarContainerControl6.Name = "ultraExplorerBarContainerControl6";
            this.ultraExplorerBarContainerControl6.Size = new System.Drawing.Size(228, 50);
            this.ultraExplorerBarContainerControl6.TabIndex = 3;
            // 
            // tEdit_SectionCode_Ed
            // 
            this.tEdit_SectionCode_Ed.ActiveAppearance = appearance9;
            this.tEdit_SectionCode_Ed.AutoSelect = true;
            this.tEdit_SectionCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tEdit_SectionCode_Ed.DataText = "01";
            this.tEdit_SectionCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SectionCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCode_Ed.Location = new System.Drawing.Point(59, 26);
            this.tEdit_SectionCode_Ed.MaxLength = 12;
            this.tEdit_SectionCode_Ed.Name = "tEdit_SectionCode_Ed";
            this.tEdit_SectionCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tEdit_SectionCode_Ed.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCode_Ed.TabIndex = 9;
            this.tEdit_SectionCode_Ed.Text = "01";
            this.tEdit_SectionCode_Ed.Leave += new System.EventHandler(this.tEdit_SectionCode_Ed_Leave);
            // 
            // tEdit_SectionCode_St
            // 
            this.tEdit_SectionCode_St.ActiveAppearance = appearance10;
            this.tEdit_SectionCode_St.AutoSelect = true;
            this.tEdit_SectionCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tEdit_SectionCode_St.DataText = "01";
            this.tEdit_SectionCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SectionCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCode_St.Location = new System.Drawing.Point(59, 0);
            this.tEdit_SectionCode_St.MaxLength = 12;
            this.tEdit_SectionCode_St.Name = "tEdit_SectionCode_St";
            this.tEdit_SectionCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tEdit_SectionCode_St.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCode_St.TabIndex = 7;
            this.tEdit_SectionCode_St.Text = "01";
            this.tEdit_SectionCode_St.Leave += new System.EventHandler(this.tEdit_SectionCode_St_Leave);
            // 
            // endRangeNameUltraTextEditor
            // 
            this.endRangeNameUltraTextEditor.Enabled = false;
            this.endRangeNameUltraTextEditor.Location = new System.Drawing.Point(93, 26);
            this.endRangeNameUltraTextEditor.Name = "endRangeNameUltraTextEditor";
            this.endRangeNameUltraTextEditor.Size = new System.Drawing.Size(104, 24);
            this.endRangeNameUltraTextEditor.TabIndex = 11;
            // 
            // endRangeUltraLabel
            // 
            appearance109.BackColor = System.Drawing.Color.Transparent;
            this.endRangeUltraLabel.Appearance = appearance109;
            this.endRangeUltraLabel.Location = new System.Drawing.Point(13, 30);
            this.endRangeUltraLabel.Name = "endRangeUltraLabel";
            this.endRangeUltraLabel.Size = new System.Drawing.Size(40, 20);
            this.endRangeUltraLabel.TabIndex = 10;
            this.endRangeUltraLabel.Text = "終了";
            // 
            // startRangeNameUltraTextEditor
            // 
            this.startRangeNameUltraTextEditor.Enabled = false;
            this.startRangeNameUltraTextEditor.Location = new System.Drawing.Point(93, 0);
            this.startRangeNameUltraTextEditor.Name = "startRangeNameUltraTextEditor";
            this.startRangeNameUltraTextEditor.Size = new System.Drawing.Size(104, 24);
            this.startRangeNameUltraTextEditor.TabIndex = 8;
            // 
            // startRangeUltraLabel
            // 
            appearance105.BackColor = System.Drawing.Color.Transparent;
            this.startRangeUltraLabel.Appearance = appearance105;
            this.startRangeUltraLabel.Location = new System.Drawing.Point(13, 4);
            this.startRangeUltraLabel.Name = "startRangeUltraLabel";
            this.startRangeUltraLabel.Size = new System.Drawing.Size(40, 20);
            this.startRangeUltraLabel.TabIndex = 6;
            this.startRangeUltraLabel.Text = "開始";
            // 
            // SectionList_ExplorerBarContainerControl
            // 
            this.SectionList_ExplorerBarContainerControl.Controls.Add(this.Section_Tree);
            this.SectionList_ExplorerBarContainerControl.Location = new System.Drawing.Point(28, 156);
            this.SectionList_ExplorerBarContainerControl.Name = "SectionList_ExplorerBarContainerControl";
            this.SectionList_ExplorerBarContainerControl.Size = new System.Drawing.Size(228, 234);
            this.SectionList_ExplorerBarContainerControl.TabIndex = 1;
            // 
            // Section_Tree
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.Section_Tree.Appearance = appearance40;
            this.Section_Tree.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Section_Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Section_Tree.Location = new System.Drawing.Point(0, 0);
            this.Section_Tree.Name = "Section_Tree";
            this.Section_Tree.Size = new System.Drawing.Size(228, 234);
            this.Section_Tree.TabIndex = 0;
            this.Section_Tree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Section_Tree_AfterCheck);
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.History_Tree);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(28, 448);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(228, 120);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // History_Tree
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.History_Tree.Appearance = appearance41;
            this.History_Tree.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.History_Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.History_Tree.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.History_Tree.Location = new System.Drawing.Point(0, 0);
            this.History_Tree.Name = "History_Tree";
            this.History_Tree.Size = new System.Drawing.Size(228, 120);
            this.History_Tree.TabIndex = 0;
            this.History_Tree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.History_Tree_MouseMove);
            this.History_Tree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.History_Tree_MouseClick);
            this.History_Tree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.History_Tree_MouseDoubleClick);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ExtraInfo_Panel);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(25, 2);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(697, 666);
            // 
            // ExtraInfo_Panel
            // 
            this.ExtraInfo_Panel.AutoScroll = true;
            this.ExtraInfo_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ExtraInfo_Panel.Controls.Add(this.Extra_ultraExplorerBar);
            this.ExtraInfo_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtraInfo_Panel.Location = new System.Drawing.Point(0, 0);
            this.ExtraInfo_Panel.Name = "ExtraInfo_Panel";
            this.ExtraInfo_Panel.Size = new System.Drawing.Size(697, 666);
            this.ExtraInfo_Panel.TabIndex = 0;
            // 
            // Extra_ultraExplorerBar
            // 
            this.Extra_ultraExplorerBar.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.Extra_ultraExplorerBar.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance42.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance42.FontData.Name = "ＭＳ ゴシック";
            appearance42.FontData.SizeInPoints = 11.25F;
            this.Extra_ultraExplorerBar.Appearance = appearance42;
            this.Extra_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Extra_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl2);
            this.Extra_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.Extra_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            this.Extra_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl5);
            this.Extra_ultraExplorerBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.Extra_ultraExplorerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Extra_ultraExplorerBar.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl2;
            ultraExplorerBarGroup1.Key = "ReportSelectGroup";
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance43;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 216;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "　出力条件";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Key = "ReportSortGroup";
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance44;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 45;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "　ソート順";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup3.Key = "PrintConditionGroup";
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance45;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 128;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "　抽出条件";
            ultraExplorerBarGroup4.Container = this.ultraExplorerBarContainerControl5;
            ultraExplorerBarGroup4.Key = "BillPrtStGroup";
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup4.Settings.AppearancesSmall.Appearance = appearance46;
            ultraExplorerBarGroup4.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup4.Settings.ContainerHeight = 211;
            ultraExplorerBarGroup4.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup4.Text = "　請求印刷設定";
            this.Extra_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3,
            ultraExplorerBarGroup4});
            this.Extra_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Extra_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance47.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance47.Cursor = System.Windows.Forms.Cursors.Default;
            this.Extra_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance47;
            appearance138.Cursor = System.Windows.Forms.Cursors.Default;
            this.Extra_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance138;
            this.Extra_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Extra_ultraExplorerBar.GroupSpacing = 4;
            this.Extra_ultraExplorerBar.Location = new System.Drawing.Point(0, 0);
            this.Extra_ultraExplorerBar.Margins.Bottom = 10;
            this.Extra_ultraExplorerBar.Margins.Top = 10;
            this.Extra_ultraExplorerBar.Name = "Extra_ultraExplorerBar";
            this.Extra_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Extra_ultraExplorerBar.Size = new System.Drawing.Size(697, 666);
            this.Extra_ultraExplorerBar.TabIndex = 234;
            this.Extra_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Extra_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing);
            this.Extra_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Extra_ultraExplorerBar_GroupExpanding);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ExtraData_Panel);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(697, 666);
            // 
            // ExtraData_Panel
            // 
            this.ExtraData_Panel.BackColor = System.Drawing.Color.Transparent;
            this.ExtraData_Panel.Controls.Add(this.DataView_Panel);
            this.ExtraData_Panel.Controls.Add(this.PrintExtra_Panel);
            this.ExtraData_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtraData_Panel.Location = new System.Drawing.Point(0, 0);
            this.ExtraData_Panel.Name = "ExtraData_Panel";
            this.ExtraData_Panel.Size = new System.Drawing.Size(697, 666);
            this.ExtraData_Panel.TabIndex = 0;
            // 
            // DataView_Panel
            // 
            this.DataView_Panel.Controls.Add(this.DEMANDLISTVIEW);
            this.DataView_Panel.Controls.Add(this.ultraGrid1);
            this.DataView_Panel.Controls.Add(this.Total_Panel);
            this.DataView_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataView_Panel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DataView_Panel.Location = new System.Drawing.Point(0, 32);
            this.DataView_Panel.Name = "DataView_Panel";
            this.DataView_Panel.Size = new System.Drawing.Size(697, 634);
            this.DataView_Panel.TabIndex = 3;
            // 
            // DEMANDLISTVIEW
            // 
            appearance139.BackColor = System.Drawing.Color.White;
            appearance139.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance139.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.DEMANDLISTVIEW.DisplayLayout.Appearance = appearance139;
            this.DEMANDLISTVIEW.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            appearance140.BackColor = System.Drawing.Color.Transparent;
            this.DEMANDLISTVIEW.DisplayLayout.Override.ActiveCardCaptionAppearance = appearance140;
            this.DEMANDLISTVIEW.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.DEMANDLISTVIEW.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.DEMANDLISTVIEW.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.DEMANDLISTVIEW.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance141.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance141.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance141.ForeColor = System.Drawing.Color.White;
            appearance141.TextHAlignAsString = "Left";
            appearance141.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.DEMANDLISTVIEW.DisplayLayout.Override.HeaderAppearance = appearance141;
            this.DEMANDLISTVIEW.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance52.BackColor = System.Drawing.Color.Lavender;
            this.DEMANDLISTVIEW.DisplayLayout.Override.RowAlternateAppearance = appearance52;
            appearance53.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.DEMANDLISTVIEW.DisplayLayout.Override.RowAppearance = appearance53;
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance54.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance54.ForeColor = System.Drawing.Color.White;
            this.DEMANDLISTVIEW.DisplayLayout.Override.RowSelectorAppearance = appearance54;
            this.DEMANDLISTVIEW.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.DEMANDLISTVIEW.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance55.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance55.ForeColor = System.Drawing.Color.Black;
            this.DEMANDLISTVIEW.DisplayLayout.Override.SelectedRowAppearance = appearance55;
            this.DEMANDLISTVIEW.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.DEMANDLISTVIEW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DEMANDLISTVIEW.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DEMANDLISTVIEW.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DEMANDLISTVIEW.Location = new System.Drawing.Point(0, 0);
            this.DEMANDLISTVIEW.Name = "DEMANDLISTVIEW";
            this.DEMANDLISTVIEW.Size = new System.Drawing.Size(697, 586);
            this.DEMANDLISTVIEW.TabIndex = 0;
            this.DEMANDLISTVIEW.Click += new System.EventHandler(this.DEMANDLISTVIEW_Click);
            this.DEMANDLISTVIEW.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.DEMANDLISTVIEW_InitializeLayout);
            this.DEMANDLISTVIEW.BeforeRowFilterDropDown += new Infragistics.Win.UltraWinGrid.BeforeRowFilterDropDownEventHandler(this.DEMANDLISTVIEW_BeforeRowFilterDropDown);
            this.DEMANDLISTVIEW.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.DEMANDLISTVIEW_AfterRowFilterChanged);
            this.DEMANDLISTVIEW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DEMANDLISTVIEW_KeyDown);
            // 
            // ultraGrid1
            // 
            appearance56.BackColor = System.Drawing.Color.White;
            appearance56.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid1.DisplayLayout.Appearance = appearance56;
            this.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            appearance57.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid1.DisplayLayout.Override.ActiveCardCaptionAppearance = appearance57;
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance58.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance58.ForeColor = System.Drawing.Color.White;
            appearance58.TextHAlignAsString = "Left";
            appearance58.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance58;
            appearance59.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid1.DisplayLayout.Override.RowAlternateAppearance = appearance59;
            appearance60.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance60;
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance61.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.ForeColor = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorAppearance = appearance61;
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance62.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance62.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance62;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(697, 586);
            this.ultraGrid1.TabIndex = 0;
            // 
            // Total_Panel
            // 
            this.Total_Panel.BackColor = System.Drawing.Color.AliceBlue;
            this.Total_Panel.Controls.Add(this.panel7);
            this.Total_Panel.Controls.Add(this.panel8);
            this.Total_Panel.Controls.Add(this.panel4);
            this.Total_Panel.Controls.Add(this.panel3);
            this.Total_Panel.Controls.Add(this.panel6);
            this.Total_Panel.Controls.Add(this.panel5);
            this.Total_Panel.Controls.Add(this.panel2);
            this.Total_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Total_Panel.Location = new System.Drawing.Point(0, 586);
            this.Total_Panel.Name = "Total_Panel";
            this.Total_Panel.Size = new System.Drawing.Size(697, 48);
            this.Total_Panel.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ultraLabel16);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(0, 48);
            this.panel7.TabIndex = 107;
            // 
            // ultraLabel16
            // 
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance63.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance63.ForeColor = System.Drawing.Color.White;
            appearance63.TextHAlignAsString = "Center";
            appearance63.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance63;
            this.ultraLabel16.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel16.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(0, 48);
            this.ultraLabel16.TabIndex = 11;
            this.ultraLabel16.Text = "合計";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.ultraLabel22);
            this.panel8.Controls.Add(this.RpSlipCount_tNedit);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(-71, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(128, 48);
            this.panel8.TabIndex = 106;
            this.panel8.Visible = false;
            // 
            // ultraLabel22
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance64.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance64.ForeColor = System.Drawing.Color.White;
            appearance64.TextHAlignAsString = "Center";
            appearance64.TextVAlignAsString = "Middle";
            this.ultraLabel22.Appearance = appearance64;
            this.ultraLabel22.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ultraLabel22.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel22.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel22.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel22.TabIndex = 2;
            this.ultraLabel22.Text = "伝票枚数";
            this.ultraLabel22.Visible = false;
            // 
            // RpSlipCount_tNedit
            // 
            this.RpSlipCount_tNedit.ActiveAppearance = appearance65;
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance66.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance66.FontData.BoldAsString = "True";
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            appearance66.TextHAlignAsString = "Right";
            this.RpSlipCount_tNedit.Appearance = appearance66;
            this.RpSlipCount_tNedit.AutoSelect = true;
            this.RpSlipCount_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.RpSlipCount_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.RpSlipCount_tNedit.DataText = "";
            this.RpSlipCount_tNedit.Enabled = false;
            this.RpSlipCount_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RpSlipCount_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.RpSlipCount_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RpSlipCount_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.RpSlipCount_tNedit.Location = new System.Drawing.Point(0, 24);
            this.RpSlipCount_tNedit.MaxLength = 14;
            this.RpSlipCount_tNedit.Name = "RpSlipCount_tNedit";
            this.RpSlipCount_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.RpSlipCount_tNedit.Size = new System.Drawing.Size(128, 24);
            this.RpSlipCount_tNedit.TabIndex = 1;
            this.RpSlipCount_tNedit.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.TotalLastDmd_tNedit);
            this.panel4.Controls.Add(this.ultraLabel19);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(57, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 48);
            this.panel4.TabIndex = 105;
            // 
            // TotalLastDmd_tNedit
            // 
            this.TotalLastDmd_tNedit.ActiveAppearance = appearance67;
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance68.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance68.FontData.BoldAsString = "True";
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            appearance68.TextHAlignAsString = "Right";
            this.TotalLastDmd_tNedit.Appearance = appearance68;
            this.TotalLastDmd_tNedit.AutoSelect = true;
            this.TotalLastDmd_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.TotalLastDmd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalLastDmd_tNedit.DataText = "";
            this.TotalLastDmd_tNedit.Enabled = false;
            this.TotalLastDmd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalLastDmd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalLastDmd_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalLastDmd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalLastDmd_tNedit.Location = new System.Drawing.Point(0, 24);
            this.TotalLastDmd_tNedit.MaxLength = 14;
            this.TotalLastDmd_tNedit.Name = "TotalLastDmd_tNedit";
            this.TotalLastDmd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalLastDmd_tNedit.Size = new System.Drawing.Size(128, 24);
            this.TotalLastDmd_tNedit.TabIndex = 1;
            // 
            // ultraLabel19
            // 
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance69.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance69.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance69.ForeColor = System.Drawing.Color.White;
            appearance69.TextHAlignAsString = "Center";
            appearance69.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance69;
            this.ultraLabel19.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ultraLabel19.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel19.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel19.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel19.TabIndex = 2;
            this.ultraLabel19.Text = "前回請求額";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ultraLabel18);
            this.panel3.Controls.Add(this.TotalDeposit_tNedit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(185, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(128, 48);
            this.panel3.TabIndex = 104;
            // 
            // ultraLabel18
            // 
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance70.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance70.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance70.ForeColor = System.Drawing.Color.White;
            appearance70.TextHAlignAsString = "Center";
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance70;
            this.ultraLabel18.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ultraLabel18.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel18.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel18.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel18.TabIndex = 2;
            this.ultraLabel18.Text = "今回入金";
            // 
            // TotalDeposit_tNedit
            // 
            this.TotalDeposit_tNedit.ActiveAppearance = appearance71;
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance72.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance72.FontData.BoldAsString = "True";
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            appearance72.TextHAlignAsString = "Right";
            this.TotalDeposit_tNedit.Appearance = appearance72;
            this.TotalDeposit_tNedit.AutoSelect = true;
            this.TotalDeposit_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.TotalDeposit_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalDeposit_tNedit.DataText = "";
            this.TotalDeposit_tNedit.Enabled = false;
            this.TotalDeposit_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalDeposit_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalDeposit_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalDeposit_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalDeposit_tNedit.Location = new System.Drawing.Point(0, 24);
            this.TotalDeposit_tNedit.MaxLength = 14;
            this.TotalDeposit_tNedit.Name = "TotalDeposit_tNedit";
            this.TotalDeposit_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalDeposit_tNedit.Size = new System.Drawing.Size(128, 24);
            this.TotalDeposit_tNedit.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ultraLabel21);
            this.panel6.Controls.Add(this.TotalSales_tNedit);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(313, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(128, 48);
            this.panel6.TabIndex = 103;
            // 
            // ultraLabel21
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance73.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance73.ForeColor = System.Drawing.Color.White;
            appearance73.TextHAlignAsString = "Center";
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance73;
            this.ultraLabel21.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ultraLabel21.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel21.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel21.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel21.TabIndex = 2;
            this.ultraLabel21.Text = "今回売上";
            // 
            // TotalSales_tNedit
            // 
            this.TotalSales_tNedit.ActiveAppearance = appearance100;
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance101.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance101.FontData.BoldAsString = "True";
            appearance101.ForeColorDisabled = System.Drawing.Color.Black;
            appearance101.TextHAlignAsString = "Right";
            this.TotalSales_tNedit.Appearance = appearance101;
            this.TotalSales_tNedit.AutoSelect = true;
            this.TotalSales_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.TotalSales_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalSales_tNedit.DataText = "";
            this.TotalSales_tNedit.Enabled = false;
            this.TotalSales_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalSales_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalSales_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalSales_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalSales_tNedit.Location = new System.Drawing.Point(0, 24);
            this.TotalSales_tNedit.MaxLength = 14;
            this.TotalSales_tNedit.Name = "TotalSales_tNedit";
            this.TotalSales_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalSales_tNedit.Size = new System.Drawing.Size(128, 24);
            this.TotalSales_tNedit.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ConsTaxTiTle_Label);
            this.panel5.Controls.Add(this.TotalTax_tNedit);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(441, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(128, 48);
            this.panel5.TabIndex = 102;
            // 
            // ConsTaxTiTle_Label
            // 
            appearance102.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance102.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance102.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance102.ForeColor = System.Drawing.Color.White;
            appearance102.TextHAlignAsString = "Center";
            appearance102.TextVAlignAsString = "Middle";
            this.ConsTaxTiTle_Label.Appearance = appearance102;
            this.ConsTaxTiTle_Label.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ConsTaxTiTle_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ConsTaxTiTle_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConsTaxTiTle_Label.Location = new System.Drawing.Point(0, 0);
            this.ConsTaxTiTle_Label.Name = "ConsTaxTiTle_Label";
            this.ConsTaxTiTle_Label.Size = new System.Drawing.Size(128, 24);
            this.ConsTaxTiTle_Label.TabIndex = 2;
            this.ConsTaxTiTle_Label.Text = "今回消費税";
            // 
            // TotalTax_tNedit
            // 
            this.TotalTax_tNedit.ActiveAppearance = appearance77;
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance78.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance78.FontData.BoldAsString = "True";
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            appearance78.TextHAlignAsString = "Right";
            this.TotalTax_tNedit.Appearance = appearance78;
            this.TotalTax_tNedit.AutoSelect = true;
            this.TotalTax_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.TotalTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalTax_tNedit.DataText = "";
            this.TotalTax_tNedit.Enabled = false;
            this.TotalTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalTax_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalTax_tNedit.Location = new System.Drawing.Point(0, 24);
            this.TotalTax_tNedit.MaxLength = 14;
            this.TotalTax_tNedit.Name = "TotalTax_tNedit";
            this.TotalTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalTax_tNedit.Size = new System.Drawing.Size(128, 24);
            this.TotalTax_tNedit.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TotalDmd_tNedit);
            this.panel2.Controls.Add(this.ultraLabel17);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(569, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(128, 48);
            this.panel2.TabIndex = 101;
            // 
            // TotalDmd_tNedit
            // 
            this.TotalDmd_tNedit.ActiveAppearance = appearance79;
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance80.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance80.FontData.BoldAsString = "True";
            appearance80.ForeColorDisabled = System.Drawing.Color.Black;
            appearance80.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance80.TextHAlignAsString = "Right";
            this.TotalDmd_tNedit.Appearance = appearance80;
            this.TotalDmd_tNedit.AutoSelect = true;
            this.TotalDmd_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.TotalDmd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalDmd_tNedit.DataText = "";
            this.TotalDmd_tNedit.Enabled = false;
            this.TotalDmd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalDmd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalDmd_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalDmd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalDmd_tNedit.Location = new System.Drawing.Point(0, 24);
            this.TotalDmd_tNedit.MaxLength = 14;
            this.TotalDmd_tNedit.Name = "TotalDmd_tNedit";
            this.TotalDmd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalDmd_tNedit.Size = new System.Drawing.Size(128, 24);
            this.TotalDmd_tNedit.TabIndex = 1;
            // 
            // ultraLabel17
            // 
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance81.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance81.ForeColor = System.Drawing.Color.White;
            appearance81.TextHAlignAsString = "Center";
            appearance81.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance81;
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraLabel17.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel17.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel17.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel17.TabIndex = 2;
            this.ultraLabel17.Text = "請求金額";
            // 
            // PrintExtra_Panel
            // 
            this.PrintExtra_Panel.Controls.Add(this.AutoFillToGridColumn_CheckEditor);
            this.PrintExtra_Panel.Controls.Add(this.Select_Button);
            this.PrintExtra_Panel.Controls.Add(this.UnSelect_Button);
            this.PrintExtra_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrintExtra_Panel.Location = new System.Drawing.Point(0, 0);
            this.PrintExtra_Panel.Name = "PrintExtra_Panel";
            this.PrintExtra_Panel.Size = new System.Drawing.Size(697, 32);
            this.PrintExtra_Panel.TabIndex = 2;
            // 
            // AutoFillToGridColumn_CheckEditor
            // 
            this.AutoFillToGridColumn_CheckEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance82.FontData.SizeInPoints = 9F;
            this.AutoFillToGridColumn_CheckEditor.Appearance = appearance82;
            this.AutoFillToGridColumn_CheckEditor.Checked = true;
            this.AutoFillToGridColumn_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillToGridColumn_CheckEditor.Location = new System.Drawing.Point(555, 8);
            this.AutoFillToGridColumn_CheckEditor.Name = "AutoFillToGridColumn_CheckEditor";
            this.AutoFillToGridColumn_CheckEditor.Size = new System.Drawing.Size(136, 20);
            this.AutoFillToGridColumn_CheckEditor.TabIndex = 4;
            this.AutoFillToGridColumn_CheckEditor.Text = "列サイズの自動調整";
            this.AutoFillToGridColumn_CheckEditor.CheckedChanged += new System.EventHandler(this.AutoFillToGridColumn_CheckEditor_CheckedChanged);
            // 
            // Select_Button
            // 
            this.Select_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.Select_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Select_Button.HotTrackAppearance = appearance83;
            this.Select_Button.Location = new System.Drawing.Point(108, 4);
            this.Select_Button.Name = "Select_Button";
            this.Select_Button.Size = new System.Drawing.Size(100, 27);
            this.Select_Button.TabIndex = 3;
            this.Select_Button.Text = "全て印字";
            ultraToolTipInfo1.ToolTipText = "全て選択します";
            this.Button_UToolTipManager.SetUltraToolTip(this.Select_Button, ultraToolTipInfo1);
            this.Select_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Select_Button.Visible = false;
            this.Select_Button.Click += new System.EventHandler(this.Select_Button_Click);
            // 
            // UnSelect_Button
            // 
            this.UnSelect_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.UnSelect_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UnSelect_Button.HotTrackAppearance = appearance103;
            this.UnSelect_Button.Location = new System.Drawing.Point(4, 4);
            this.UnSelect_Button.Name = "UnSelect_Button";
            this.UnSelect_Button.Size = new System.Drawing.Size(100, 27);
            this.UnSelect_Button.TabIndex = 1;
            this.UnSelect_Button.Text = "全て非印字";
            ultraToolTipInfo2.ToolTipText = "全ての選択を解除します";
            this.Button_UToolTipManager.SetUltraToolTip(this.UnSelect_Button, ultraToolTipInfo2);
            this.UnSelect_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.UnSelect_Button.Visible = false;
            this.UnSelect_Button.Click += new System.EventHandler(this.Select_Button_Click);
            // 
            // Main_ExplorerBar
            // 
            appearance85.FontData.SizeInPoints = 9F;
            this.Main_ExplorerBar.Appearance = appearance85;
            this.Main_ExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ExplorerBar.Controls.Add(this.SectionList_ExplorerBarContainerControl);
            this.Main_ExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl6);
            ultraExplorerBarGroup5.Container = this.ultraExplorerBarContainerControl6;
            ultraExplorerBarGroup5.Key = "SectionRange";
            ultraExplorerBarGroup5.Settings.ContainerHeight = 50;
            ultraExplorerBarGroup5.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup5.Text = "出力拠点の範囲を指定します";
            ultraExplorerBarGroup6.Container = this.SectionList_ExplorerBarContainerControl;
            ultraExplorerBarGroup6.Key = "SectionList";
            ultraExplorerBarGroup6.Settings.ContainerHeight = 234;
            ultraExplorerBarGroup6.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup6.Text = "出力対象拠点を選択します";
            ultraExplorerBarGroup6.Visible = false;
            ultraExplorerBarGroup7.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup7.Key = "HistoryList";
            ultraExplorerBarGroup7.Settings.ContainerHeight = 120;
            ultraExplorerBarGroup7.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup7.Text = "最近出力した一覧表";
            this.Main_ExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup5,
            ultraExplorerBarGroup6,
            ultraExplorerBarGroup7});
            this.Main_ExplorerBar.Location = new System.Drawing.Point(0, 27);
            this.Main_ExplorerBar.Name = "Main_ExplorerBar";
            this.Main_ExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ExplorerBar.Size = new System.Drawing.Size(277, 643);
            this.Main_ExplorerBar.TabIndex = 0;
            this.Main_ExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.XPExplorerBar;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "この帳票を削除(&D)";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "この帳票以前を削除(&B)";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Main_TabControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(282, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 670);
            this.panel1.TabIndex = 91;
            // 
            // Main_TabControl
            // 
            appearance86.BackColor = System.Drawing.Color.White;
            appearance86.BackColor2 = System.Drawing.Color.LightPink;
            this.Main_TabControl.ActiveTabAppearance = appearance86;
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            appearance87.BackColor2 = System.Drawing.Color.White;
            appearance87.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            this.Main_TabControl.Appearance = appearance87;
            this.Main_TabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            appearance88.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Main_TabControl.ClientAreaAppearance = appearance88;
            this.Main_TabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Main_TabControl.Controls.Add(this.ultraTabPageControl1);
            this.Main_TabControl.Controls.Add(this.ultraTabPageControl2);
            this.Main_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TabControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Main_TabControl.Location = new System.Drawing.Point(0, 0);
            this.Main_TabControl.Name = "Main_TabControl";
            appearance89.FontData.BoldAsString = "True";
            this.Main_TabControl.SelectedTabAppearance = appearance89;
            this.Main_TabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_TabControl.Size = new System.Drawing.Size(724, 670);
            this.Main_TabControl.TabIndex = 0;
            this.Main_TabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.LeftBottom;
            ultraTab1.Key = "ExtractInfoTab";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "抽出条件";
            ultraTab2.Key = "ExtractDataTab";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "抽出結果";
            ultraTab2.Visible = false;
            this.Main_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.Main_TabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_TabControl.ActiveTabChanged += new Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventHandler(this.Main_TabControl_ActiveTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(697, 666);
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.Main_DockManager.AutoHideDelay = 50;
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            dockableControlPane1.Control = this.Main_ExplorerBar;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(240, -1);
            dockableControlPane1.Key = "ControlPane0";
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(230, -1, 260, 648);
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance90.FontData.SizeInPoints = 10F;
            dockableControlPane1.Settings.Appearance = appearance90;
            dockableControlPane1.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(277, 670);
            this.Main_DockManager.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.ShowCloseButton = false;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _MAKAU02012UAUnpinnedTabAreaLeft
            // 
            this._MAKAU02012UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._MAKAU02012UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU02012UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._MAKAU02012UAUnpinnedTabAreaLeft.Name = "_MAKAU02012UAUnpinnedTabAreaLeft";
            this._MAKAU02012UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._MAKAU02012UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 670);
            this._MAKAU02012UAUnpinnedTabAreaLeft.TabIndex = 92;
            // 
            // _MAKAU02012UAUnpinnedTabAreaRight
            // 
            this._MAKAU02012UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._MAKAU02012UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU02012UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1006, 0);
            this._MAKAU02012UAUnpinnedTabAreaRight.Name = "_MAKAU02012UAUnpinnedTabAreaRight";
            this._MAKAU02012UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._MAKAU02012UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 670);
            this._MAKAU02012UAUnpinnedTabAreaRight.TabIndex = 93;
            // 
            // _MAKAU02012UAUnpinnedTabAreaTop
            // 
            this._MAKAU02012UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._MAKAU02012UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU02012UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._MAKAU02012UAUnpinnedTabAreaTop.Name = "_MAKAU02012UAUnpinnedTabAreaTop";
            this._MAKAU02012UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._MAKAU02012UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(1006, 0);
            this._MAKAU02012UAUnpinnedTabAreaTop.TabIndex = 94;
            // 
            // _MAKAU02012UAUnpinnedTabAreaBottom
            // 
            this._MAKAU02012UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._MAKAU02012UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU02012UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 670);
            this._MAKAU02012UAUnpinnedTabAreaBottom.Name = "_MAKAU02012UAUnpinnedTabAreaBottom";
            this._MAKAU02012UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._MAKAU02012UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1006, 0);
            this._MAKAU02012UAUnpinnedTabAreaBottom.TabIndex = 95;
            // 
            // _MAKAU02012UAAutoHideControl
            // 
            this._MAKAU02012UAAutoHideControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU02012UAAutoHideControl.Location = new System.Drawing.Point(22, 0);
            this._MAKAU02012UAAutoHideControl.Name = "_MAKAU02012UAAutoHideControl";
            this._MAKAU02012UAAutoHideControl.Owner = this.Main_DockManager;
            this._MAKAU02012UAAutoHideControl.Size = new System.Drawing.Size(245, 605);
            this._MAKAU02012UAAutoHideControl.TabIndex = 96;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.Main_ExplorerBar);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.Main_DockManager;
            this.dockableWindow1.Size = new System.Drawing.Size(277, 670);
            this.dockableWindow1.TabIndex = 98;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tNedit6
            // 
            this.tNedit6.ActiveAppearance = appearance91;
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance92.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance92.ForeColorDisabled = System.Drawing.Color.Black;
            appearance92.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.tNedit6.Appearance = appearance92;
            this.tNedit6.AutoSelect = true;
            this.tNedit6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.tNedit6.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit6.DataText = "";
            this.tNedit6.Enabled = false;
            this.tNedit6.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit6.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit6.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit6.Location = new System.Drawing.Point(0, 24);
            this.tNedit6.MaxLength = 11;
            this.tNedit6.Name = "tNedit6";
            this.tNedit6.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit6.Size = new System.Drawing.Size(97, 21);
            this.tNedit6.TabIndex = 1;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Controls.Add(this.dockableWindow1);
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.Main_DockManager;
            this.windowDockingArea1.Size = new System.Drawing.Size(282, 670);
            this.windowDockingArea1.TabIndex = 97;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Button_UToolTipManager
            // 
            this.Button_UToolTipManager.ContainingControl = this;
            this.Button_UToolTipManager.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            this.uiMemInput1.ReadOnLoad = false;
            // 
            // MAKAU02012UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1006, 670);
            this.Controls.Add(this._MAKAU02012UAAutoHideControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._MAKAU02012UAUnpinnedTabAreaTop);
            this.Controls.Add(this._MAKAU02012UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._MAKAU02012UAUnpinnedTabAreaRight);
            this.Controls.Add(this._MAKAU02012UAUnpinnedTabAreaLeft);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MAKAU02012UA";
            this.Text = "請求書";
            this.Load += new System.EventHandler(this.MAKAU02012UA_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MAKAU02012UA_FormClosing);
            this.ultraExplorerBarContainerControl2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TaxPrintDiv)).EndInit();
            this.panel_LineMaSqOfChDiv.ResumeLayout(false);
            this.panel_LineMaSqOfChDiv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineMaSqOfChDiv_tComboEditor)).EndInit();
            this.panel_PrintBlLiDiv.ResumeLayout(false);
            this.panel_PrintBlLiDiv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintBlLiDiv_tComboEditor)).EndInit();
            this.panel_NewPage.ResumeLayout(false);
            this.panel_NewPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewPageDiv_tComboEditor)).EndInit();
            this.panel_IssueType.ResumeLayout(false);
            this.panel_IssueType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IssueType_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.ultraExplorerBarContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            this.panel_AccRecDivCd.ResumeLayout(false);
            this.panel_AccRecDivCd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccRecDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChargeEmployee_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl5.ResumeLayout(false);
            this.ultraExplorerBarContainerControl5.PerformLayout();
            this.panel_PrCustDtl.ResumeLayout(false);
            this.panel_PrCustDtl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrCustDtl_tComboEditor)).EndInit();
            this.panel_DmdDtl.ResumeLayout(false);
            this.panel_DmdDtl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DmdDtl_tComboEditor)).EndInit();
            this.panel_IssueDay.ResumeLayout(false);
            this.panel_BalanceDepositDtl_.ResumeLayout(false);
            this.panel_BalanceDepositDtl_.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceDepositDtl_tComboEditor)).EndInit();
            this.panel_CollectRate.ResumeLayout(false);
            this.panel_CollectRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CollectRatePrtDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutPutPriceCond_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl6.ResumeLayout(false);
            this.ultraExplorerBarContainerControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endRangeNameUltraTextEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRangeNameUltraTextEditor)).EndInit();
            this.SectionList_ExplorerBarContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Section_Tree)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.History_Tree)).EndInit();
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ExtraInfo_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Extra_ultraExplorerBar)).EndInit();
            this.Extra_ultraExplorerBar.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ExtraData_Panel.ResumeLayout(false);
            this.DataView_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DEMANDLISTVIEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.Total_Panel.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RpSlipCount_tNedit)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalLastDmd_tNedit)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDeposit_tNedit)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSales_tNedit)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalTax_tNedit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDmd_tNedit)).EndInit();
            this.PrintExtra_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ExplorerBar)).EndInit();
            this.Main_ExplorerBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_TabControl)).EndInit();
            this.Main_TabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            this.dockableWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit6)).EndInit();
            this.windowDockingArea1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region private member
        private bool _eventDoFlag = false;
        // >>>>> 2006.08.18 Y.Sasaki DEL START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        //		private MAKAU02012UB _extractionForm = null;
        // <<<<< 2006.08.18 Y.Sasaki DEL END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        private string _enterpriseCode = "";

        // 起動モード定数
        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        //private const int START_MODE_ALL = 0;		        // 請求書発行(ALL)
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

        private const int START_MODE_DEFAULT_LIST = 1;		// 請求一覧表
        private const int START_MODE_DEFAULT_TOTAL = 2;		// 合計請求書
        private const int START_MODE_DEFAULT_DETAIL = 3;	// 明細請求書
        // 2007.10.15 hikita upd start -------------------------------------------------->>
        //private const int START_MODE_DEMANDHAND = 4;		// 手入力合計請求書
        private const int START_MODE_DEFAULT_DETAILSLIP = 4;// 明細請求書(伝票)
        private const int START_MODE_DEFAULT_RECEIPT = 5;	// 領収書           
        // 2007.10.15 hikita upd end ----------------------------------------------------<<

        private const int START_MODE_DEMANDLIST = 10;		// 請求一覧表
        private const int START_MODE_DEMANDTOTAL = 20;		// 合計請求書
        private const int START_MODE_DEMANDDETAIL = 30;	    // 明細請求書(詳細)
        // 2007.10.15 hikita add start -------------------------------------------------->>
        private const int START_MODE_DEMANDDETAILSLIP = 40;	// 明細請求書(伝票)
        private const int START_MODE_DEMANDRECEIPT = 50;	// 領収書           
        // 2007.10.15 hikita add end ----------------------------------------------------<<

        // 請求設定拠点
        private string _demandSectionCode = "";
        private ExtrInfo_DemandTotal _extraInfo_DemandTotal = null;
        private ExtrInfo_DemandTotal _prevExtraInfo_DemandTotal = null;

        private DemandPrintAcs mDemandPrintAcs = null;
        private PdfHistoryControl mPdfHistoryControl = null;

        private Hashtable _sectionCodeList = null;
        private Hashtable _printHistoryList = null;
        private ArrayList _printHistoryKeyList = null;

        private bool _nodeCheckEventDo = false;

        private Employee _loginEmployee = null;
        // 2009.01.21 30413 犬飼 テキストを修正 >>>>>>START
        private string[] outputCdNames = new string[]{
                                                   "全て出力",
                                                   "０とプラス金額を出力",
                                                   "プラス金額のみ出力",
                                                   "０のみ出力",
                                                   //"プラス金額とマイナス金額",
                                                   "プラス金額とマイナス金額を出力",
                                                   "０とマイナス金額を出力",
                                                   "マイナス金額のみ出力"
                                                 };
        // 2009.01.21 30413 犬飼 テキストを修正 <<<<<<END

        private bool _eventDateChange = false;
        private bool _isOptSection = false;
        private bool _isMainOfficeFunc = false;

        // ガイド系アクセスクラス
        EmployeeAcs _employeeAcs;

        // 2008.09.09 30413 犬飼 ユーザガイドの追加 >>>>>>START
        UserGuideAcs _userGuideAcs;
        // 2008.09.09 30413 犬飼 ユーザガイドの追加 <<<<<<END

        //マウスポインタのあるノードを保存する領域
        private Infragistics.Win.UltraWinTree.UltraTreeNode _lastUltraTreeNode = null;

        // 親フレーム呼出モード
        private int _callMode = 0;

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        // 自由帳票制御クラス
        private FreePrintController _freePrintController;
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ---------->>>>>
        /// <summary>
        /// 請求一覧表で起動しているか判断します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :請求一覧表で起動しています。<br/>
        /// <c>false</c>:請求一覧表で起動していません。
        /// </returns>
        private bool IsDemandListMode()
        {
            return this._callMode.Equals(START_MODE_DEFAULT_LIST);
        }
        // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ----------<<<<<

        // エクスプローラバー拡大基準高さ 
        private int _expandBaseHeigt;			// 2006.09.07 Y.Sasaki ADD
        private Form _topForm = null;
        private bool _explorerBarExpanding = false;

        // 2008.09.08 30413 犬飼 日付取得部品の追加 >>>>>>START
        // 日付取得部品
        private DateGetAcs _dateGetAcs;
        // 2008.09.08 30413 犬飼 日付取得部品の追加 <<<<<<END

        // ADD 2009/03/06 請求書系フレーム対応：PDFを一括表示 ---------->>>>>
        #region <出力PDF/>

        /// <summary>出力PDF情報</summary>
        private PDFManager _outputPDF;
        /// <summary>
        /// 出力PDF情報を取得します。
        /// </summary>
        public PDFManager OutputPDF { get { return _outputPDF; } }

        /// <summary>
        /// PDFの出力パス（表示用）リストを取得します。
        /// </summary>
        public List<string> PreviewPDFPathList
        {
            get
            {
                if (OutputPDF == null) return new List<string>();
                return OutputPDF.PreviewPDFPathList;
            }
        }

        /// <summary>
        /// 関連するPDFファイルを全て削除します。
        /// </summary>
        /// <param name="previewPDFPath">PDFの出力パス（表示用）</param>
        public void DeletePDFFiles(string previewPDFPath)
        {
            if (OutputPDF == null) return;
            OutputPDF.DeleteFiles(previewPDFPath);
        }

        #endregion  // <出力PDF/>
        // ADD 2009/03/06 請求書系フレーム対応：PDFを一括表示 ----------<<<<<

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        // プレビュー用PDFパスリスト
        private List<string> _previewPdfPathList;
        // 請求書単位のPDFパスリスト
        private List<string> _billPdfPathList;
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        // ---ADD 2011/03/23---------->>>>>
        private SFCMN06002C _printInfo = null;
        // ---ADD 2011/03/23----------<<<<<
        #endregion

        // ===================================================================================== //
        // プライベート定数
        // ===================================================================================== //
        #region private constant
        private const string TABCONTROL_EXTRAINFOSCREEN_KEY = "ExtractInfoTab";
        private const string TABCONTROL_EXTRADATASCREEN_KEY = "ExtractDataTab";
        private const string THIS_ASSEMBLYID = "MAKAU02012U";

        private const string EXPLORERBAR_SECTIONLIST = "SectionList";
        private const string EXPLORERBAR_HISTORYLIST = "HistoryList";

        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
        //private const string EXPLORERBAR_GROUP0_KEY = "AddUpDateGroup";
        //private const string EXPLORERBAR_GROUP1_KEY = "CustomerGroup";
        //private const string EXPLORERBAR_GROUP2_KEY = "ChargeGroup";
        //private const string EXPLORERBAR_GROUP3_KEY = "BillPrtStGroup";
        //private const string EXPLORERBAR_GROUP4_KEY = "AnalysCodeGroup";
        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

        private const int EXPLORERBAR_GROUPHEADER_HEIGHT = 30;
        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
        // 税率設定ファイル
        private const string CtPrintXmlFileName = "TaxRate_UserSetting.XML";
        // 税別内訳印字警告メッセージ
        private const string CtTaxPrintMsg = "消費税率別の内訳を印字すると、処理が遅くなる可能性があります。\nよろしいですか？";
        // 軽減税率を対応するか判断専用(注意：他PG(A,Pクラス)で条件判断に使用)
        public const bool TaxReductionUIDone = true;
        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

        // TODO 要変更
        /// <summary>PDF履歴管理用KEY（請求一覧表用）</summary>
        private const string PDF_HISTORY_KEY = "5590a061-9176-4900-bfac-f433b8e164b9";
        // ADD 2009/03/18 不具合対応[10938]：「最近出力した一覧表」ツリーのルートノードの名称 ---------->>>>>
        /// <summary>PDF履歴管理用KEY（請求書用）</summary>
        private const string PDF_HISTORY_DETAIL_KEY = "563ef6ad-a619-41f4-8f27-12a21d1ccb93";
        /// <summary>PDF履歴管理用KEY（領収書用）</summary>
        private const string PDF_HISTORY_RECEIPT_KEY= "aa5e075e-93c2-48a7-864c-cef19b3b25b2";
        /// <summary>
        /// PDF履歴管理用キーを取得します。
        /// </summary>
        /// <value>請求一覧表、領収書、請求書に応じたPDF履歴管理用キー</value>
        private string PDFHistoryKey
        {
            get
            {
                string key = string.Empty;
                switch (_callMode)
                {
                    case START_MODE_DEFAULT_LIST:   // 請求一覧表
                    case START_MODE_DEMANDLIST:	    // 請求一覧表
                        key = PDF_HISTORY_KEY;
                        break;
                    case START_MODE_DEFAULT_RECEIPT:// 領収書
                    case START_MODE_DEMANDRECEIPT:  // 領収書
                        key = PDF_HISTORY_RECEIPT_KEY;
                        break;
                    default:                        // 請求書
                        key = PDF_HISTORY_DETAIL_KEY;
                        break;
                }
                return key;
            }
        }
        // ADD 2009/03/18 不具合対応[10938]：「最近出力した一覧表」ツリーのルートノードの名称 ----------<<<<<
        private const string DOCK_PANE0_KEY = "ControlPane0";

        // エクスプローラーバーの表示状態を決定するための基準となるトップフォームの高さ
        ////////////////////////////////////////////// 2007.01.19 TERASAKA DEL STA //
        //		private const int CT_TOPFORM_BASE_HEIGHT = 768;
        // 2007.01.19 TERASAKA DEL END //////////////////////////////////////////////
        ////////////////////////////////////////////// 2007.01.19 TERASAKA ADD STA //
        private const int CT_TOPFORM_BASE_HEIGHT = 771;
        // 2007.01.19 TERASAKA ADD END //////////////////////////////////////////////
        #endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        #region events
        public event SelectedPdfNodeEventHandler SelectedPdfNodeEvent;

        // ADD 2009/03/03 請求書系フレーム対応：拠点範囲指定の追加 ---------->>>>>
        /// <summary>ステータスバー表示する情報が出力されたときのイベントハンドラ</summary>
        public event PrintStatusBar StatusBarInfoPrinted;

        /// <summary>
        /// ステータスバーに情報を出力します。（デフォルト）
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private static void PrintStatusBarOfDefault(object sender, PrintStatusBarEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }
        // ADD 2008/03/03 請求書系フレーム対応：拠点範囲指定の追加 ----------<<<<<

        #endregion

        // ===================================================================================== //
        // メイン
        // ===================================================================================== //
        #region Main
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new MAKAU02012UA());
        }
        #endregion

        // ===================================================================================== //
        // IDemandTbsMDIChildExtrViewPrintForm　実装部
        // ===================================================================================== //
        #region IDemandTbsMDIChildMain
        /// <summary>
        /// Control.Show メソッドのオーバーロード
        /// </summary>
        /// <param name="parameter"></param>
        /// <remarks>
        /// <br>Note       : 画面の表示を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // 呼出モード設定
            this._callMode = Broadleaf.Library.Text.TStrConv.StrToIntDef(parameter.ToString(), 0);

            // >>>>> 2006.09.07 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            // 拡大基準高さの取得
            this._expandBaseHeigt = CT_TOPFORM_BASE_HEIGHT;
            // <<<<< 2006.09.07 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // 2009.01.14 30413 犬飼 ＵＩ入力保存コンポーネントの追加 >>>>>>START
            // UI設定保存コンポーネント設定
            this.uiMemInput1.OptionCode = this._callMode.ToString();
            // 2009.01.14 30413 犬飼 ＵＩ入力保存コンポーネントの追加 <<<<<<END

            this.Show();
        }

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <returns>true:OK, false:NG</returns>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        public bool ScreenInputCheck()
        {
            string message;
            Control errControl = null;

            // 画面入力条件チェック
            bool result = this.ScreenInputCheck(out message, ref errControl);
            if (!result)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

                if (errControl != null) errControl.Focus();
            }
            return result;
        }
        /// <summary>
        /// データ抽出処理
        /// </summary>
        /// <param name="printKind">帳票種類[1:請求一覧,2:合計請求書,3:明細請求書,4:明細請求書(伝票),5:領収書]</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// <br>Update Note: 2011/03/23 曹文傑</br>                       
        /// <br>           : 仕様連絡 #20083</br>
        /// </remarks>
        public int ExtractData(int printKind)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 画面→抽出条件クラス
            this.SetExtraInfo_DemandTotalFromScreen(ref this._extraInfo_DemandTotal);

            // >>>>> 2006.09.05 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //      status = this.SearchDemandData(0,printKind);
            string msg;
            // ---ADD 2011/03/23---------->>>>>
            _printInfo = null;
            // ---ADD 2011/03/23----------<<<<<
            status = this.SearchDemandData(0, printKind, out msg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        TMessageBox(emErrorLevel.ERR_LEVEL_INFO, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        break;
                    }
                default:
                    {
                        TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        break;
                    }
            }
            // <<<<< 2006.09.05 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // 前回抽出条件設定
            this._prevExtraInfo_DemandTotal = this._extraInfo_DemandTotal.Clone();

            return status;
        }

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <param name="printMode">印刷モード[0:ＰＤＦ出力,1:通常印刷]</param>
        /// <param name="parameter">印刷パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 印刷処理を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// <br>Update Note: 2011/02/16 鄧潘ハン</br>                       
        /// <br>           : 印刷処理の速度アップ対応</br>	
        /// <br>Update Note: 2011/03/23 曹文傑</br>                       
        /// <br>           : 仕様連絡 #20083</br>
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/27 李小路</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27270　請求書/メモリ領域のオーバーフローエラーの発生の修正</br>
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
# if DEBUG
            LogWriter.Write(new string('-', 50));
            LogWriter.Write("ST >> " + GC.GetTotalMemory(true).ToString("#,##0"));
# endif
            try
            {
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                // 税率内訳印字メッセージ追加
                if (this.tComboEditor_TaxPrintDiv.SelectedIndex == 0 && this._extraInfo_DemandTotal.SlipPrtKind == 0)
                {
                    DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, "MAKAU02012UA", CtTaxPrintMsg, 0, MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        return -1;
                    }
                }
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

                SFCMN06001U printDialog = new SFCMN06001U();            // 帳票選択ガイド
                SFCMN06002C printInfo = parameter as SFCMN06002C;       // 印刷情報パラメータ
                // ---ADD 2011/03/23---------->>>>>
                _printInfo = printInfo;
                // ---ADD 2011/03/23----------<<<<<

                // 企業コード
                printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                printInfo.kidopgid = THIS_ASSEMBLYID;             // 起動ＰＧＩＤ
                printInfo.key = PDFHistoryKey;                  // PDF履歴管理用KEY情報
                //            printInfo.printmode      = printMode;                   // 印刷モード(0:PDF 1:通常印刷 2:両方)

                // 画面→抽出条件クラス
                this.SetExtraInfo_DemandTotalFromScreen(ref this._extraInfo_DemandTotal);

                // アクティブなタブは？
                // 抽出条件画面
                if (this.Main_TabControl.ActiveTab.Key == TABCONTROL_EXTRAINFOSCREEN_KEY)
                {
                    // --- UPD  大矢睦美  2010/01/27 ---------->>>>>
                    // 既に前回同一条件で抽出済み
                    //if (this._extraInfo_DemandTotal.Equals(this._prevExtraInfo_DemandTotal) && this.mDemandPrintAcs.CustDmdPrcDataView.Count != 0)
                    //{
                    //    printDialog.PrintMode = 0;  // 直接印刷
                    //}
                    //else
                    //{
                    //    printDialog.PrintMode = 1;  // 抽出→印刷
                    //}
                    printDialog.PrintMode = 1;  // 抽出→印刷
                    // --- UPD  大矢睦美  2010/01/27 ----------<<<<<
                }
                // 抽出データ表示画面
                else
                {
                    // 前回抽出条件と同じか？
                    if (!this._extraInfo_DemandTotal.Equals(this._prevExtraInfo_DemandTotal))
                    {
                        TMessageBox(emErrorLevel.ERR_LEVEL_QUESTION, "抽出条件に変更があります。再抽出を行って下さい。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        return 9;
                    }
                    // --- UPD  大矢睦美  2010/01/27 ---------->>>>>
                    //printDialog.PrintMode = 0;  // 直接印刷
                    printDialog.PrintMode = 1;  // 抽出→印刷
                    // --- UPD  大矢睦美  2010/01/27 ----------<<<<<
                }

                // 印字位置選択有無
                // 2008.09.09 30413 犬飼 処理変更 >>>>>>START
                //if (printInfo.PrintPaperSetCd == 2)
                //{
                //    // 合計請求書
                //    printDialog.PrtPosSetButtonVisible = true;
                //}
                //else
                //{
                //    // その他
                //    printDialog.PrtPosSetButtonVisible = false;
                //}
                printDialog.PrtPosSetButtonVisible = false;
                // 2008.09.09 30413 犬飼 処理変更 <<<<<<END

                // --- DEL  大矢睦美  2010/02/25 ---------->>>>>
                //// 2008.09.09 30413 犬飼 印字する帳票選択を制御 >>>>>>START
                //if (this._extraInfo_DemandTotal.DmdDtl == 0)
                //{
                //    // 請求内訳が両方
                //    printInfo.PrintPaperSetCd = 6;
                //}
                //// 2008.09.09 30413 犬飼 印字する帳票選択を制御 <<<<<<END
                // --- DEL  大矢睦美  2010/02/25 ----------<<<<<

                // 請求一覧表か？
                if (this._extraInfo_DemandTotal.SlipPrtKind == 0)
                {
                    // --- ADD  大矢睦美  2010/02/25 ---------->>>>>
                    if (this._extraInfo_DemandTotal.DmdDtl == 0)
                    {
                        // 請求内訳が両方
                        printInfo.PrintPaperSetCd = 6;
                    }
                    // --- ADD  大矢睦美  2010/02/25 ----------<<<<<

                    // 請求一覧表(通常のアクティブレポート印刷)
                    DialogResult dialogResult;

                    // 直接印刷
                    if (printDialog.PrintMode == 0)
                    {
                        // 印刷用DataTable作成
                        this.mDemandPrintAcs.MakePrintDataTable();

                        // 一覧画面が表示されている場合、１件以上出力設定されているか？
                        if (this.Main_TabControl.Tabs[TABCONTROL_EXTRADATASCREEN_KEY].Visible)
                        {
                            if (this.mDemandPrintAcs.CustDmdPrcDataViewPrint.Count == 0)
                            {
                                TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, "出力するデータを設定して下さい", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                return 4;
                            }
                        }


                        // 抽出条件の設定
                        printInfo.jyoken = this._extraInfo_DemandTotal;

                        // 印刷用DataView設定
                        printInfo.rdData = this.mDemandPrintAcs.CustDmdPrcDataViewPrint;

                        printDialog.PrintInfo = printInfo;

                        // 帳票選択ガイド
                        dialogResult = printDialog.ShowDialog();


                    }
                    // 抽出後印刷
                    else
                    {
                        // 条件入力チェックを行う
                        string message;
                        Control errControl = null;
                        bool result = this.ScreenInputCheck(out message, ref errControl);
                        if (!result)
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            if (errControl != null) errControl.Focus();
                            return 9;
                        }

                        printDialog.PrintInfo = printInfo;
                        // 帳票選択ガイド
                        dialogResult = printDialog.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            // 設定情報取得
                            printInfo = printDialog.PrintInfo;

                            // 抽出処理
                            //int status = -1;
                            //status = this.SearchDemandData(1,printInfo.PrintPaperSetCd);
                            //if (status != 0) return status;

                            // >>>>> 2006.09.05 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                            string msg;
                            int status = this.SearchDemandData(1, printInfo.PrintPaperSetCd, out msg);
                            switch (status)
                            {
                                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                    {
                                        break;
                                    }
                                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                    {
                                        TMessageBox(emErrorLevel.ERR_LEVEL_INFO, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                        return status;
                                    }
                                default:
                                    {
                                        TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                        return status;
                                    }
                            }
                            // <<<<< 2006.09.05 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                            // 印刷用DataTable作成
                            this.mDemandPrintAcs.MakePrintDataTable();

                            // 画面リフレッシュ
                            this.Refresh();

                            // 抽出条件の設定
                            printInfo.jyoken = this._extraInfo_DemandTotal;
                            // 印刷用DataView設定
                            printInfo.rdData = this.mDemandPrintAcs.CustDmdPrcDataViewPrint;

                            printDialog.PrintInfo = printInfo;

                            // 印刷処理
                            printDialog.PrtProc();

                        }
                    }

                    // 前回抽出条件設定
                    if (dialogResult == DialogResult.OK)
                    {
                        this._prevExtraInfo_DemandTotal = this._extraInfo_DemandTotal.Clone();
                    }

                    parameter = (Object)printInfo;
                }   // if (this._extraInfo_DemandTotal.SlipPrtKind == 0)    // 請求一覧表
                else
                {   // TODO:請求一覧表以外の場合分け
                    // 条件入力チェックを行う
                    string message;
                    Control errControl = null;
                    bool result = this.ScreenInputCheck(out message, ref errControl);
                    if (!result)
                    {
                        TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        if (errControl != null) errControl.Focus();
                        return 9;
                    }

                    // 自由帳票印刷
                    int status = 0;
                    // 抽出後印刷
                    if (printDialog.PrintMode == 1)
                    {
                        string msg;
                        status = this.SearchDemandData(1, printInfo.PrintPaperSetCd, out msg);
                        switch (status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                {
                                    break;
                                }
                            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                {
                                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                    return status;
                                }
                            default:
                                {
                                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                    return status;
                                }
                        }
                    }

                    // 2009.01.29 30413 犬飼 出力順を考慮するように修正 >>>>>>START
                    // 2009.01.22 30413 犬飼 印刷一時中断枚数の処理を追加 >>>>>>START
                    // 印刷用DataTable作成
                    //this.mDemandPrintAcs.MakePrintDataTable();
                    //this.mDemandPrintAcs.MakePrintDataTable(printInfo.PcardPrtSuspendcnt);
                    status = this.mDemandPrintAcs.MakePrintDataTable(printInfo.PcardPrtSuspendcnt, this._extraInfo_DemandTotal);
                    // 2009.01.22 30413 犬飼 印刷一時中断枚数の処理を追加 <<<<<<END
                    // 2009.01.29 30413 犬飼 出力順を考慮するように修正 <<<<<<END

                    // 2009.03.17 30413 犬飼 請求書印刷なしの抽出結果判定を追加 >>>>>>START
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                    {
                        string errmsg = "該当するデータがありません";
                        TMessageBox(emErrorLevel.ERR_LEVEL_INFO, errmsg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        return status;
                    }
                    // 2009.03.17 30413 犬飼 請求書印刷なしの抽出結果判定を追加 <<<<<<END
                   
                    // 画面リフレッシュ
                    this.Refresh();

                    // DEL 2009/03/09 請求書系フレーム対応↓：PDFを一括表示
                    //status = FreePrintPaper();  // 実印刷処理
                    // --- UPD m.suzuki 2010/07/22 ---------->>>>>
                    //status = FreePrintPaper(printInfo); // ADD 2008/03/09 請求書系フレーム対応：PDFを一括表示

                    // 初期化
                    _billPdfPathList = new List<string>();
                    _previewPdfPathList = new List<string>();

                    // ---ADD 2011/03/23---------->>>>>
                    string pgName;
                    switch (_callMode)
                    {
                        case START_MODE_DEFAULT_RECEIPT:
                        case START_MODE_DEMANDRECEIPT:
                            pgName = "領収書";
                            break;
                        default:
                            pgName = "請求書";
                            break;
                    }

                    // 2:印刷,1:PDF
                    int operationCode = 2;
                    if (_printInfo != null)
                    {
                        operationCode = (_printInfo.printmode == 2) ? 1 : 2;
                    }
                    OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
                    operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, "SFANL07200U", pgName, "", operationCode, 0, "印刷開始", "");
                    // ---ADD 2011/03/23----------<<<<<

                    // 選択中の拠点の分、繰り返す
                    # region [FreePrintPaperを拠点毎に実行]
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

                    List<string> sectionCodeList = CreateSelectedSectionCodeList( _extraInfo_DemandTotal.ResultsAddUpSecList );
                    sectionCodeList.Sort();

                    // 自由帳票制御クラス
                    if ( _freePrintController == null )
                    {
                        _freePrintController = new FreePrintController();
                    }
                    // 処理中ダイアログ表示　＞＞＞
                    _freePrintController.ShowProgressDialog();
                    // --- ADD 2011/02/16--------------------------->>>>>
                    if (printInfo.printmode == 1 && printInfo.prevkbn == 0)
                    {
                        string preAddUpSecCode = "";
                        string nextAddUpSecCode = "";
                        List<string> AddUpSecCodeList = new List<string>();
                        for (int i = 0; i < this.mDemandPrintAcs.CustDmdPrcDataViewPrint.Count; i++)
                        {
                            nextAddUpSecCode = (string)this.mDemandPrintAcs.CustDmdPrcDataViewPrint[i].Row["AddUpSecCode"].ToString().Trim();
                            if (preAddUpSecCode != nextAddUpSecCode)
                            {
                                AddUpSecCodeList.Add(nextAddUpSecCode);
                                preAddUpSecCode = nextAddUpSecCode;
                            }    
                        }
                        sectionCodeList = AddUpSecCodeList;
                    }
                    // --- ADD 2011/02/16---------------------------<<<<<

                    // ログフラグ初始値
                    _freePrintController._logCnt = 0; // ADD 2012/03/05 xupz for redmine#28258

                    foreach (string sectionCode in sectionCodeList)
                    {
# if DEBUG
                        // 開始時メモリ使用量を退避
                        long memStart = GC.GetTotalMemory(true);
# endif
                        // foreach内の前回プレビュー表示で一時的にダイアログ非表示にしても今回分は再度表示する為の処理
                        _freePrintController.RestartShowProgressDialog();

                        // １請求書分の印刷処理実行
                        int secStatus = FreePrintPaper(printInfo, sectionCode); // ADD 2008/03/09 請求書系フレーム対応：PDFを一括表示

                        // STATUSの確定
                        if (secStatus == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                        {
                            // エラー
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            break;
                        }
                        else if (secStatus == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                        {
                            // キャンセル
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        }
                        else if (secStatus == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // 正常
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            // (breakしない)
                        }

                        // ガベージコレクタを強制的に呼び出す。(メモリ解放)
                        //GC.Collect();     //DEL 李小路 2011/12/27 Redmine#27270
# if DEBUG
                        // メモリ使用量の表示
                        long memEnd = GC.GetTotalMemory(true);
                        LogWriter.Write(string.Format("{0} : {1} -> {2}", sectionCode, memStart.ToString("#,##0"), memEnd.ToString("#,##0")));
# endif
                    }
 
                    # endregion

                    // ---ADD 2011/03/23---------->>>>>
                    operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, "SFANL07200U", pgName, "", operationCode, 0, "印刷終了", "");
                    // ---ADD 2011/03/23----------<<<<<

                    // 解放・ダイアログ終了　＜＜＜
                    _freePrintController.Dispose();

                    // PDF出力処理(PDF出力の場合のみ)
                    # region [プレビュー用PDF表示]
                    // 出力PDF情報を設定
                    _outputPDF = new PDFManager(
                        _previewPdfPathList,  // 表示用PDFフルパス
                        _billPdfPathList     // 請求書単位PDFフルパス
                    );
                    if ( OutputPDF.PreviewPDFPathList.Count > 1 )
                    {
                        printInfo.pdftemppath = OutputPDF.PreviewPDFPathList[0];
                    }
                    # endregion

                    // 画面リフレッシュ
                    this.Refresh();

                    // ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
                    // LOGﾌｧｲﾙが有る場合
                    if (_freePrintController._logCnt != 0)
                    {
                        // エラー発生のメッセージを表示する
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "請求書発行時にエラーがありました、LOGﾌｧｲﾙを確認してください。", status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    }
                    // ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<

                    // ガベージコレクタを強制的に呼び出す。(メモリ解放)
                    GC.Collect();
# if DEBUG
                    LogWriter.Write("ED << " + GC.GetTotalMemory(true).ToString("#,##0"));
# endif
                    // --- UPD m.suzuki 2010/07/22 ----------<<<<<
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            return 0;

        }

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// 拠点コードリスト生成（全社指定はリストに展開して対応する）
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private List<string> CreateSelectedSectionCodeList( string[] sectionCodeArray )
        {
            if ( sectionCodeArray.Length == 0 ||
                 (sectionCodeArray.Length == 1 && (sectionCodeArray[0].Trim() == "00" || sectionCodeArray[0].Trim() == string.Empty)) )
            {
                // 全社指定とみなす

                // リスト化する
                List<string> sectionList = new List<string>();
                foreach ( object obj in this.mDemandPrintAcs.SectionTable.Values )
                {
                    if ( obj is SecInfoSet )
                    {
                        if ( (obj as SecInfoSet).SectionCode.Trim() != "00" && (obj as SecInfoSet).SectionCode.Trim() != string.Empty )
                        {
                            sectionList.Add( (obj as SecInfoSet).SectionCode.Trim() );
                        }
                    }
                }
                return sectionList;
            }
            else if ( sectionCodeArray.Length > 0 )
            {
                // 拠点指定
                return new List<string>( sectionCodeArray );
            }

            return new List<string>();
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        /// <summary>
        /// 印刷書類変更処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 印刷書類変更時の処理を行います。
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        // --- UPD  大矢睦美  2010/01/27 ---------->>>>>
        //public void ChangePrintType(int printType)
        public void ChangePrintType(int printType)
        // --- UPD  大矢睦美  2010/01/27 ----------<<<<<
        {
            int outPutDiv = 0;
            int dmdDtlDiv = 0;
            // --- ADD  大矢睦美  2010/01/27 ---------->>>>>
            int issueType = 0;
            // --- ADD  大矢睦美  2010/01/27 ----------<<<<<

            //// フィルタ条件を設定する
            //switch (printType)
            //{
            //    case 1:	// 請求一覧表
            //        outPutDiv = (int)this.BillTableOutPut_tComboEditor.SelectedItem.DataValue;
            //        break;
            //    case 2:	// 合計請求書
            //        outPutDiv = (int)this.TotalBillOutput_tComboEditor.SelectedItem.DataValue;
            //        break;
            //    case 3:	// 明細請求書
            //        outPutDiv = (int)this.DetailBillOutput_tComboEditor.SelectedItem.DataValue;
            //        break;
            //    default:
            //        break;
            //}
            outPutDiv = (int)this.OutPutPriceCond_tComboEditor.SelectedItem.DataValue;

            dmdDtlDiv = (int)this.DmdDtl_tComboEditor.SelectedItem.DataValue;
            
            // --- DEL  大矢睦美  2010/02/25 ---------->>>>>
            // --- ADD  大矢睦美  2010/01/27 ---------->>>>>
            //issueType = (int)this.IssueType_tComboEditor.SelectedItem.DataValue;
            // --- ADD  大矢睦美  2010/01/27 ----------<<<<<
            // --- DEL  大矢睦美  2010/02/25 ----------<<<<<

            // --- ADD  大矢睦美  2010/02/25 ---------->>>>>
            if (IssueType_tComboEditor.Visible == false)
            {
                issueType = -1;
            }
            else
            {
                issueType = (int)this.IssueType_tComboEditor.SelectedItem.DataValue;
            }
            // --- ADD  大矢睦美  2010/02/25 ----------<<<<<

            // フィルタ条件をDataViewに設定
            // --- UPD  大矢睦美  2010/01/27 ---------->>>>>
            //this.mDemandPrintAcs.SelectViewData(outPutDiv, dmdDtlDiv);
            this.mDemandPrintAcs.SelectViewData(outPutDiv, dmdDtlDiv, issueType);
            // --- UPD  大矢睦美  2010/01/27 ----------<<<<<

            // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            // 合計金額計算
            this.CalculationTotalViewRow();
            // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        }
        #endregion

        // >>>>> 2006.08.31 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        // ===================================================================================== //
        // ICustomTextSelectAndWriter	        　実装部
        // ===================================================================================== //
        #region ICustomTextSelectAndWriter メンバ
        /// <summary>
        /// テキスト出力ダイアログ操作＆実行インタフェース
        /// </summary>
        /// <param name="source">出力対象データ</param>
        /// <param name="schemaPath">スキーマファイルパス</param>
        /// <param name="outputFilePath">出力ファイルパス</param>
        /// <param name="customTextProviderInfo">テキスト出力設定情報</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : テキスト出力ダイアログを起動しテキスト出力を実行します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        public int SelectInfoAndMakeCustomText(object source, string schemaPath, string outputFilePath, ref CustomTextProviderInfo customTextProviderInfo)
        {
            try
            {
                SFCMN00391U textDialog = new SFCMN00391U();						// テキスト出力選択ダイアログ
                SFCMN06002C printInfo = new SFCMN06002C();						// 印刷情報パラメータ

                // 企業コード
                printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                printInfo.kidopgid = THIS_ASSEMBLYID;						    			// 起動ＰＧＩＤ
                printInfo.key = PDFHistoryKey;											// PDF履歴管理用KEY情報
                printInfo.selectInfoCode = 1;												// １：テキスト
                // 呼出モードにより出力金額区分を設定
                switch (this._callMode)
                {
                    // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                    //case START_MODE_ALL:		        // 全帳票
                    //    {
                    //        break;
                    //    }
                    // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                    case START_MODE_DEFAULT_LIST:		// 請求一覧表
                    case START_MODE_DEMANDLIST:	        // 請求一覧表
                        {
                            printInfo.PrintPaperSetCd = 1;												// 請求一覧表
                            break;
                        }
                    case START_MODE_DEFAULT_TOTAL:		// 請求書(鑑)
                    case START_MODE_DEMANDTOTAL:	    // 請求書(鑑)
                        {
                            printInfo.PrintPaperSetCd = 2;												// 請求書(鑑)
                            break;
                        }
                    case START_MODE_DEFAULT_DETAIL:		// 明細請求書
                    case START_MODE_DEMANDDETAIL:	    // 明細請求書
                        {
                            printInfo.PrintPaperSetCd = 3;											    // 請求明細書
                            break;
                        }
                    // 2007.10.15 hikita add start ------------------------------------->>
                    case START_MODE_DEFAULT_DETAILSLIP:		// 請求明細書(伝票)
                    case START_MODE_DEMANDDETAILSLIP:	    // 請求明細書(伝票)
                        {
                            printInfo.PrintPaperSetCd = 4;												// 請求明細書(伝票)
                            break;
                        }
                    case START_MODE_DEFAULT_RECEIPT:    // 領収書
                    case START_MODE_DEMANDRECEIPT:      // 領収書
                        {
                            printInfo.PrintPaperSetCd = 5;												// 領収書
                            break;
                        }
                    // 2007.10.15 hikita add end ---------------------------------------<<
                    default:
                        break;
                }

                //            printInfo.printmode      = printMode;                         // 印刷モード(0:PDF 1:通常印刷 2:両方)

                // 画面→抽出条件クラス
                this.SetExtraInfo_DemandTotalFromScreen(ref this._extraInfo_DemandTotal);

                // アクティブなタブは？
                // 抽出条件画面
                if (this.Main_TabControl.ActiveTab.Key == TABCONTROL_EXTRAINFOSCREEN_KEY)
                {                    
                     //既に前回同一条件で抽出済み
                    if (this._extraInfo_DemandTotal.Equals(this._prevExtraInfo_DemandTotal) && this.mDemandPrintAcs.CustDmdPrcDataView.Count != 0)
                    {
                        textDialog.PrintMode = 0;  // 直接印刷
                    }
                    else
                    {
                        textDialog.PrintMode = 1;  // 抽出→印刷
                    }                                   
                }
                // 抽出データ表示画面
                else
                {
                    // 前回抽出条件と同じか？
                    if (!this._extraInfo_DemandTotal.Equals(this._prevExtraInfo_DemandTotal))
                    {
                        TMessageBox(emErrorLevel.ERR_LEVEL_QUESTION, "抽出条件に変更があります。再抽出を行って下さい。", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        return 9;
                    }                  
                    textDialog.PrintMode = 0;  // 直接印刷                                        
                }

                DialogResult dialogResult;

                // 直接印刷
                if (textDialog.PrintMode == 0)
                {
                    // 印刷用DataTable作成
                    this.mDemandPrintAcs.MakePrintDataTable();

                    // 一覧画面が表示されている場合、１件以上出力設定されているか？
                    if (this.Main_TabControl.Tabs[TABCONTROL_EXTRADATASCREEN_KEY].Visible)
                    {
                        if (this.mDemandPrintAcs.CustDmdPrcDataViewPrint.Count == 0)
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, "出力するデータを設定して下さい", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            return 4;
                        }
                    }

                    // 抽出条件の設定
                    printInfo.jyoken = this._extraInfo_DemandTotal;

                    // 印刷用DataView設定
                    printInfo.rdData = this.mDemandPrintAcs.CustDmdPrcDataViewPrint;

                    textDialog.PrintInfo = printInfo;

                    // 帳票選択ガイド
                    dialogResult = textDialog.ShowDialog();

                }
                // 抽出後印刷
                else
                {
                    // 条件入力チェックを行う
                    string message;
                    Control errControl = null;
                    bool result = this.ScreenInputCheck(out message, ref errControl);
                    if (!result)
                    {
                        TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        if (errControl != null) errControl.Focus();
                        return 9;
                    }

                    textDialog.PrintInfo = printInfo;
                    // 帳票選択ガイド
                    dialogResult = textDialog.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        // 設定情報取得
                        printInfo = textDialog.PrintInfo;

                        // 抽出処理
                        // >>>>> 2006.09.05 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                        //int status = -1;
                        //status = this.SearchDemandData(1, printInfo.PrintPaperSetCd);
                        //if (status != 0) return status;
                        string msg;
                        int status = this.SearchDemandData(1, printInfo.PrintPaperSetCd, out msg);
                        switch (status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                {
                                    break;
                                }
                            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                {
                                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                    return status;
                                }
                            default:
                                {
                                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                    return status;
                                }
                        }
                        // <<<<< 2006.09.05 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                        // 印刷用DataTable作成
                        this.mDemandPrintAcs.MakePrintDataTable();

                        // 画面リフレッシュ
                        this.Refresh();

                        // 抽出条件の設定
                        printInfo.jyoken = this._extraInfo_DemandTotal;
                        // 印刷用DataView設定
                        printInfo.rdData = this.mDemandPrintAcs.CustDmdPrcDataViewPrint;

                        textDialog.PrintInfo = printInfo;

                        // 印刷処理
                        textDialog.PrtProc();

                    }
                }

                // 前回抽出条件設定
                if (dialogResult == DialogResult.Abort)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                        "「" + printInfo.outPutFileName + "」の出力に失敗しました。",
                        printInfo.status,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                }
                else if (dialogResult == DialogResult.OK)
                {
                    switch (printInfo.status)
                    {
                        case 0:
                            {
                                this._prevExtraInfo_DemandTotal = this._extraInfo_DemandTotal.Clone();

                                TMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                    "「" + printInfo.outPutFileName + "」を出力しました。",
                                    printInfo.status,
                                    MessageBoxButtons.OK,
                                    MessageBoxDefaultButton.Button1);
                                break;
                            }
                        case 4:
                            {
                                TMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                    "「" + printInfo.outPutFileName + "」の対象データが存在しません。",
                                    printInfo.status,
                                    MessageBoxButtons.OK,
                                    MessageBoxDefaultButton.Button1);
                                break;
                            }
                        default:
                            {
                                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                                    "「" + printInfo.outPutFileName + "」の出力に失敗しました。",
                                    printInfo.status,
                                    MessageBoxButtons.OK,
                                    MessageBoxDefaultButton.Button1);
                                break;
                            }
                    }
                }

            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            return 0;
        }
        #endregion
        // <<<<< 2006.08.31 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private methods
        /// <summary>
        /// 請求情報抽出グリッドを設定します。
        /// </summary>
        /// <remarks>
        /// <br>Note       : 請求情報を表示するグリッドを設定します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void SettingGrid()
        {
            // グリッドのカラム情報を設定します。
            SettingGridColumn(DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns);
        }
        /// <summary>
        /// 請求情報抽出グリッドカラム情報設定処理
        /// </summary>
        /// <param name="Columns">グリッドのカラムコレクション</param>
        /// <remarks>
        /// <br>Note       : 元帳グリッドに表示するカラム情報を設定します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void SettingGridColumn(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            string _moneyFormat = "#,##0;-#,##0;";

            // 一旦、全ての列を非表示にする。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                column.Hidden = true;
            }

            //--------------------------------------------------------------------------------
            //  表示するカラム情報
            //--------------------------------------------------------------------------------
            // 2008.11.14 30413 犬飼 印刷フラグは非表示 >>>>>>START
            // 印刷フラグ
            Columns[DemandPrintAcs.CT_CsDmd_PrintFlag].Hidden = true;
            Columns[DemandPrintAcs.CT_CsDmd_PrintFlag].Header.Caption = "";
            Columns[DemandPrintAcs.CT_CsDmd_PrintFlag].Width = 10;
            Columns[DemandPrintAcs.CT_CsDmd_PrintFlag].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            // 2008.11.14 30413 犬飼 印刷フラグは非表示 <<<<<<END

            // ADD 2009/04/20 ------>>>
            // レコード名
            Columns[DemandPrintAcs.CT_CsDmd_RecordName].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_RecordName].Header.Caption = "レコード名";
            Columns[DemandPrintAcs.CT_CsDmd_RecordName].Width = 50;
            Columns[DemandPrintAcs.CT_CsDmd_RecordName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // ADD 2009/04/20 ------<<<

            // 2008.09.05 30413 犬飼 項目追加 >>>>>>START
            // 計上拠点
            Columns[DemandPrintAcs.CT_CsDmd_AddUpSecCode].Hidden = false;
            // 2009.01.26 30413 犬飼 計上拠点→請求拠点に変更 >>>>>>START
            //Columns[DemandPrintAcs.CT_CsDmd_AddUpSecCode].Header.Caption = "計上拠点";
            Columns[DemandPrintAcs.CT_CsDmd_AddUpSecCode].Header.Caption = "請求拠点";
            // 2009.01.26 30413 犬飼 計上拠点→請求拠点に変更 <<<<<<END
            Columns[DemandPrintAcs.CT_CsDmd_AddUpSecCode].Width = 30;
            Columns[DemandPrintAcs.CT_CsDmd_AddUpSecCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // 2009.01.21 30413 犬飼 請求拠点→実績拠点の印字 >>>>>>START
            //// 請求拠点
            //Columns[DemandPrintAcs.CT_CsDmd_ClaimSectionCode].Hidden = false;
            //Columns[DemandPrintAcs.CT_CsDmd_ClaimSectionCode].Header.Caption = "請求拠点";
            //Columns[DemandPrintAcs.CT_CsDmd_ClaimSectionCode].Width = 30;
            //Columns[DemandPrintAcs.CT_CsDmd_ClaimSectionCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 実績拠点
            Columns[DemandPrintAcs.CT_CsDmd_ResultsSectCd].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_ResultsSectCd].Header.Caption = "実績拠点";
            Columns[DemandPrintAcs.CT_CsDmd_ResultsSectCd].Width = 30;
            Columns[DemandPrintAcs.CT_CsDmd_ResultsSectCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 2009.01.21 30413 犬飼 請求拠点→実績拠点の印字 <<<<<<END

            // 2008.11.19 30413 犬飼 集計レコードの印字内容に合わせて修正 >>>>>>START
            // 請求先
            //Columns[DemandPrintAcs.CT_CsDmd_ClaimCode].Hidden = false;
            //Columns[DemandPrintAcs.CT_CsDmd_ClaimCode].Header.Caption = "請求先";
            //Columns[DemandPrintAcs.CT_CsDmd_ClaimCode].Width = 50;
            //Columns[DemandPrintAcs.CT_CsDmd_ClaimCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DemandPrintAcs.CT_CsDmd_ClaimCodeDisp].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_ClaimCodeDisp].Header.Caption = "請求先";
            Columns[DemandPrintAcs.CT_CsDmd_ClaimCodeDisp].Width = 50;
            Columns[DemandPrintAcs.CT_CsDmd_ClaimCodeDisp].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 2008.09.05 30413 犬飼 項目追加 <<<<<<END

            // 2008.09.05 30413 犬飼 項目変更 >>>>>>START
            //// 得意先コード
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerCode].Hidden = false;
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerCode].Header.Caption = "得意先コード";
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerCode].Width = 50;
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 得意先
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerCode].Hidden = false;
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerCode].Header.Caption = "得意先";
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerCode].Width = 50;
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DemandPrintAcs.CT_CsDmd_CustomerCodeDisp].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_CustomerCodeDisp].Header.Caption = "得意先";
            Columns[DemandPrintAcs.CT_CsDmd_CustomerCodeDisp].Width = 50;
            Columns[DemandPrintAcs.CT_CsDmd_CustomerCodeDisp].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 2008.09.05 30413 犬飼 項目変更 <<<<<<END

            // 得意先名称
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerSnm].Hidden = false;
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerSnm].Header.Caption = "得意先名";
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerSnm].Width = 100;
            //Columns[DemandPrintAcs.CT_CsDmd_CustomerSnm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[DemandPrintAcs.CT_CsDmd_CustomerSnmDisp].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_CustomerSnmDisp].Header.Caption = "得意先名";
            Columns[DemandPrintAcs.CT_CsDmd_CustomerSnmDisp].Width = 100;
            Columns[DemandPrintAcs.CT_CsDmd_CustomerSnmDisp].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // 2008.11.19 30413 犬飼 集計レコードの印字内容に合わせて修正 <<<<<<END

            // 集金月
            Columns[DemandPrintAcs.CT_CsDmd_CollectMoneyName].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_CollectMoneyName].Header.Caption = "集金月";
            Columns[DemandPrintAcs.CT_CsDmd_CollectMoneyName].Width = 20;
            Columns[DemandPrintAcs.CT_CsDmd_CollectMoneyName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // 集金日
            Columns[DemandPrintAcs.CT_CsDmd_CollectMoneyDay].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_CollectMoneyDay].Header.Caption = "集金日";
            Columns[DemandPrintAcs.CT_CsDmd_CollectMoneyDay].Width = 20;
            Columns[DemandPrintAcs.CT_CsDmd_CollectMoneyDay].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //// 伝票枚数
            //Columns[DemandPrintAcs.CT_CsDmd_TleDmdSlipTotalCnt].Hidden = false;
            //Columns[DemandPrintAcs.CT_CsDmd_TleDmdSlipTotalCnt].Header.Caption = "伝票枚数";
            //Columns[DemandPrintAcs.CT_CsDmd_TleDmdSlipTotalCnt].Width = 20;
            //Columns[DemandPrintAcs.CT_CsDmd_TleDmdSlipTotalCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // 2008.11.18 30413 犬飼 前回請求金額→請求残高に変更 >>>>>>START
            // 前回請求金額
            //Columns[DemandPrintAcs.CT_CsDmd_LastTimeDemand].Hidden = false;
            //Columns[DemandPrintAcs.CT_CsDmd_LastTimeDemand].Header.Caption = "前回請求金額";
            //Columns[DemandPrintAcs.CT_CsDmd_LastTimeDemand].Width = 77;
            //Columns[DemandPrintAcs.CT_CsDmd_LastTimeDemand].Format = _moneyFormat;
            //Columns[DemandPrintAcs.CT_CsDmd_LastTimeDemand].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[DemandPrintAcs.CT_CsDmd_DemandBalance].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_DemandBalance].Header.Caption = "前回請求金額";
            Columns[DemandPrintAcs.CT_CsDmd_DemandBalance].Width = 77;
            Columns[DemandPrintAcs.CT_CsDmd_DemandBalance].Format = _moneyFormat;
            Columns[DemandPrintAcs.CT_CsDmd_DemandBalance].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // 2008.11.18 30413 犬飼 前回請求金額→請求残高に変更 <<<<<<END

            // 今回入金
            Columns[DemandPrintAcs.CT_CsDmd_ThisTimeDmdNrml].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_ThisTimeDmdNrml].Header.Caption = "今回入金";
            Columns[DemandPrintAcs.CT_CsDmd_ThisTimeDmdNrml].Width = 77;
            Columns[DemandPrintAcs.CT_CsDmd_ThisTimeDmdNrml].Format = _moneyFormat;
            Columns[DemandPrintAcs.CT_CsDmd_ThisTimeDmdNrml].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            if (mDemandPrintAcs.AllDefSetData != null)
            {
                if (mDemandPrintAcs.AllDefSetData.TotalAmountDispWayCd == 0)
                {
                    // 総額表示方法 = 税抜き
                    // 今回売上額
                    Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Hidden = false;
                    Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Header.Caption = "今回売上";
                    Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Width = 77;
                    Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Format = _moneyFormat;
                    Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    // 今回消費税
                    Columns[DemandPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].Header.Caption = "今回消費税";
                }
                else
                {
                    // 総額表示方法 = 税込み
                    // 今回売上額
                    Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Hidden = false;
                    Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Header.Caption = "今回売上";
                    Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Width = 77;
                    Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Format = _moneyFormat;
                    Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    // 今回消費税
                    Columns[DemandPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].Header.Caption = "(内今回消費税)";
                }
            }
            else
            {
                // 今回売上額
                Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Hidden = false;
                Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Header.Caption = "今回売上";
                Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Width = 77;
                Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Format = _moneyFormat;
                Columns[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // 今回消費税
                Columns[DemandPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].Header.Caption = "今回消費税";
            }

            // 今回消費税
            Columns[DemandPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].Width = 77;
            Columns[DemandPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 請求金額
            Columns[DemandPrintAcs.CT_CsDmd_AfCalDemandPrice].Hidden = false;
            Columns[DemandPrintAcs.CT_CsDmd_AfCalDemandPrice].Header.Caption = "請求金額";
            Columns[DemandPrintAcs.CT_CsDmd_AfCalDemandPrice].Width = 77;
            Columns[DemandPrintAcs.CT_CsDmd_AfCalDemandPrice].Format = _moneyFormat;
            Columns[DemandPrintAcs.CT_CsDmd_AfCalDemandPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // 担当者名称
            if (TStrConv.StrToIntDef(this.ChargeEmployee_tComboEditor.SelectedItem.DataValue.ToString(), 0) == 1)
            {
                Columns[DemandPrintAcs.CT_CsDmd_BillCollecterNm].Hidden = false;
                Columns[DemandPrintAcs.CT_CsDmd_BillCollecterNm].Header.Caption = "集金担当";
                Columns[DemandPrintAcs.CT_CsDmd_BillCollecterNm].Width = 100;
                Columns[DemandPrintAcs.CT_CsDmd_BillCollecterNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            }
            else
            {
                Columns[DemandPrintAcs.CT_CsDmd_CustomerAgentNm].Hidden = false;
                Columns[DemandPrintAcs.CT_CsDmd_CustomerAgentNm].Header.Caption = "得意先担当";
                Columns[DemandPrintAcs.CT_CsDmd_CustomerAgentNm].Width = 100;
                Columns[DemandPrintAcs.CT_CsDmd_CustomerAgentNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            }
        }



        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を初期化します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// <br>Update Note: 2011/03/14 yangmj</br>                       
        /// <br>           : 印字制御の区分の追加</br>
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            this.InitialExtraInfoSetting();
            this.SetScreenFromExtraInfo_DemandTotal(this._extraInfo_DemandTotal);

            // 総額表示方法
            if (mDemandPrintAcs.AllDefSetData != null && mDemandPrintAcs.AllDefSetData.TotalAmountDispWayCd == 0)
            {
                // 税抜き
                this.ConsTaxTiTle_Label.Text = "今回消費税";
            }
            else
            {
                // 税込み
                this.ConsTaxTiTle_Label.Text = "(内今回消費税)";
            }

            // ガイドボタンイメージ設定
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            EmployeeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            EmployeeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            EmployeeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            EmployeeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            // 2008.09.11 30413 犬飼 地区ガイドボタンのイメージ設定 >>>>>>START
            ub_SalesAreaCodeStGuid.ImageList = IconResourceManagement.ImageList16;
            ub_SalesAreaCodeStGuid.Appearance.Image = Size16_Index.STAR1;
            ub_SalesAreaCodeEdGuid.ImageList = IconResourceManagement.ImageList16;
            ub_SalesAreaCodeEdGuid.Appearance.Image = Size16_Index.STAR1;
            // 2008.09.11 30413 犬飼 地区ガイドボタンのイメージ設定 <<<<<<END

            // 2008.09.11 30413 犬飼 表示制御の追加 >>>>>>START
            #region < 表示制御 >
            Point point = new Point();
            point.X = 3;
            point.Y = 35;

            // 帳票の種類により処理を分ける
            switch (this._callMode)
            {
                //case START_MODE_ALL:
                //    break;
                case START_MODE_DEFAULT_LIST:       // 請求一覧表
                    {
                        // 出力条件部
                        this.panel_NewPage.Location = point;
                        this.panel_NewPage.Visible = true;

                        // 請求印刷指定部
                        point.X = 3;
                        point.Y = 5;
                        this.panel_CollectRate.Location = point;
                        this.panel_CollectRate.Visible = true;
                        point.Y = 68;
                        this.panel_DmdDtl.Location = point;
                        this.panel_DmdDtl.Visible = true;
                        point.Y = 99;
                        this.panel_BalanceDepositDtl_.Location = point;
                        this.panel_BalanceDepositDtl_.Visible = true;
                        // 2009.01.19 30413 犬飼 親得意先内訳の追加 >>>>>>START
                        point.Y = 130;
                        this.panel_PrCustDtl.Location = point;
                        this.panel_PrCustDtl.Visible = true;

                        //-----ADD 2011/03/14----->>>>>
                        //空白行印字
                        point.Y = 64;
                        this.panel_PrintBlLiDiv.Location = point;
                        this.panel_PrintBlLiDiv.Visible = true;

                        //罫線印字 
                        point.Y = 93;
                        this.panel_LineMaSqOfChDiv.Location = point;
                        this.panel_LineMaSqOfChDiv.Visible = true;
                        //-----ADD 2011/03/14-----<<<<<

                        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                        // 税別内訳印字区分
                        point.Y = 122;
                        this.panel9.Location = point;
                        this.panel9.Visible = true;
                        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

                        // エクスプローラーバー高さ調節
                        //-----UPD 2011/03/14----->>>>>
                        //this.Extra_ultraExplorerBar.Groups[0].Settings.ContainerHeight = 75;
                        // --- UPD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                        //this.Extra_ultraExplorerBar.Groups[0].Settings.ContainerHeight = 131;
                        this.Extra_ultraExplorerBar.Groups[0].Settings.ContainerHeight = 160;
                        // --- UPD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
                        //-----UPD 2011/03/14-----<<<<<

                        //this.Extra_ultraExplorerBar.Groups[3].Settings.ContainerHeight = 145;
                        this.Extra_ultraExplorerBar.Groups[3].Settings.ContainerHeight = 175;
                        // 2009.01.19 30413 犬飼 親得意先内訳の追加 <<<<<<END
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:		// 請求書(鑑)
                    {
                        // 出力条件部
                        this.panel_IssueType.Location = point;
                        this.panel_IssueType.Visible = true;
                        // 請求印刷指定部
                        point.X = 3;
                        point.Y = 5;
                        this.panel_IssueDay.Location = point;
                        this.panel_IssueDay.Visible = true;
                        point.Y = 68;
                        this.panel_DmdDtl.Location = point;
                        this.panel_DmdDtl.Visible = true;
                        // 2009.01.19 30413 犬飼 親得意先内訳の追加 >>>>>>START
                        point.Y = 99;
                        this.panel_PrCustDtl.Location = point;
                        this.panel_PrCustDtl.Visible = true;
                        // エクスプローラーバー高さ調節
                        this.Extra_ultraExplorerBar.Groups[0].Settings.ContainerHeight = 75;
                        //this.Extra_ultraExplorerBar.Groups[3].Settings.ContainerHeight = 110;
                        this.Extra_ultraExplorerBar.Groups[3].Settings.ContainerHeight = 145;
                        // 2009.01.19 30413 犬飼 親得意先内訳の追加 <<<<<<END

                        // 売掛区分の追加
                        this.panel_AccRecDivCd.Visible = false;
                        this.Extra_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 100;
                        this.IssueDay_tDateEdit.SetDateTime(System.DateTime.Now); //ADD BY 凌小青　on 2011/10/31 for Redmine#26321

                        break;
                    }
                case START_MODE_DEFAULT_RECEIPT:    // 領収書
                    {
                        // 請求印刷指定部
                        point.X = 3;
                        point.Y = 5;
                        this.panel_IssueDay.Location = point;
                        this.panel_IssueDay.Visible = true;
                        // エクスプローラーバー高さ調節
                        this.Extra_ultraExplorerBar.Groups[0].Settings.ContainerHeight = 40;
                        this.Extra_ultraExplorerBar.Groups[3].Settings.ContainerHeight = 75;

                        // 売掛区分の追加
                        this.panel_AccRecDivCd.Visible = false;
                        this.Extra_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 100;
                        this.IssueDay_tDateEdit.SetDateTime(System.DateTime.Now); //ADD BY 凌小青　on 2011/10/31 for Redmine#26321
                        break;
                    }
            }
            #endregion
            // 2008.09.11 30413 犬飼 表示制御の追加 <<<<<<END
        }

        /// <summary>
        /// 初期設定データ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期設定データの読込を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private int InitalDataRead()
        {
            string message;
            // 初期データ読込
            int status = this.mDemandPrintAcs.InitialDataRead(LoginInfoAcquisition.EnterpriseCode, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
                      message,
                      status,
                      MessageBoxButtons.OK,
                      MessageBoxDefaultButton.Button1);
                    break;
            }
            return status;
        }

        /// <summary>
        /// 拠点情報設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報を設定します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void SettingSectonListForm()
        {
            this.Section_Tree.ShowLines = false;
            foreach (string secCode in this.mDemandPrintAcs.SecCodeList)
            {
                SecInfoSet secInfoSet = (SecInfoSet)this.mDemandPrintAcs.SectionTable[secCode];

                this.Section_Tree.Nodes.Add(secCode, secInfoSet.SectionGuideNm);
                this.Section_Tree.Nodes[secCode].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                this.Section_Tree.Nodes[secCode].CheckedState = System.Windows.Forms.CheckState.Unchecked;
            }
        }

        /// <summary>
        /// ＰＤＦ出力履歴情報設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＰＤＦ出力履歴を設定します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void SettingRecentPdfList()
        {

            // 出力管理履歴用帳票毎KEY設定(今の所、請求一覧のみ)
            this._printHistoryKeyList.Add(PDFHistoryKey);

            // 出力管理履歴クラス初期化
            string[] keys = (string[])this._printHistoryKeyList.ToArray(typeof(string));
            this.mPdfHistoryControl.InitializeHistoryTable(keys);

            // 出力管理履歴初期表示
            this.DisplaySettingPdfList();
        }

        /// <summary>
        /// ＰＤＦ出力履歴情報画面表示処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＰＤＦ出力履歴を画面表示します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void DisplaySettingPdfList()
        {
#if !REP20060302 // 2006.03.02 Y.Sasaki 共通部品を使用するように変更
            Infragistics.Win.UltraWinTree.UltraTreeNode topNode;
            PrintInfoItem infoItem;

            this.History_Tree.Nodes.Clear();
            this._printHistoryList.Clear();

            foreach (string wkKey in this._printHistoryKeyList)
            {
                // フィルタ条件設定
                this.mPdfHistoryControl.HistoryDataView.RowFilter =
                    String.Format(
                    "{0} = '{1}' AND {2} = '{3}'",
                    PdfHistoryControl.ctCOL_PrintKey,
                    wkKey,
                    PdfHistoryControl.ctCOL_LoginWorkerCode,
                    (this._loginEmployee != null) ? this._loginEmployee.EmployeeCode : "");

                // ソート順設定
                this.mPdfHistoryControl.HistoryDataView.Sort =
                    String.Format("{0} DESC, {1} ASC", PdfHistoryControl.ctCOL_PrintOutDateTime, PdfHistoryControl.ctCOL_PdfFileName);

                foreach (DataRowView rowView in this.mPdfHistoryControl.HistoryDataView)
                {
                    // 出力履歴テーブルに追加
                    infoItem = new PrintInfoItem(rowView.Row);
                    this._printHistoryList.Add(infoItem.Id, infoItem);

                    // 親ノード取得
                    topNode = this.History_Tree.GetNodeByKey(infoItem.PrintKey);
                    if (topNode == null)
                    {
                        topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode(infoItem.PrintKey, infoItem.PrintName);
                        this.History_Tree.Nodes.Add(topNode);
                    }

                    // 子ノードを追加する
                    Infragistics.Win.UltraWinTree.UltraTreeNode childNode = new Infragistics.Win.UltraWinTree.UltraTreeNode(
                        infoItem.Id.ToString(),
                        String.Format("{0} {1}",
                        TDateTime.DateTimeToString("GGYYMMDD", infoItem.PrintOutDateTime),
                        TDateTime.DateTimeToString("HHMM", infoItem.PrintOutDateTime)));
                    childNode.LeftImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4]);
                    childNode.Tag = infoItem.PdfFileName;

                    topNode.Nodes.Add(childNode);
                }
            }

            this.History_Tree.ExpandAll();
#else
			ArrayList ar;
      Infragistics.Win.UltraWinTree.UltraTreeNode topNode;
            
			mPdfHistoryControl.GetPrintHistoryList(out ar, PDFHistoryKey, "");

			this.History_Tree.Nodes.Clear();
			this._printHistoryList.Clear();
          
			for (int i = 0; i < ar.Count; i++)
			{
				PrintInfoItem infoItem = (PrintInfoItem)ar[i];
          
				// 出力履歴テーブルに追加
				this._printHistoryList.Add(infoItem.Id, infoItem);
              
				// 親ノード取得
				topNode = this.History_Tree.GetNodeByKey(infoItem.PrintKey);
				if (topNode == null)
				{
					topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode(infoItem.PrintKey,infoItem.PrintName);
					this.History_Tree.Nodes.Add(topNode);
				} 
              
				// 子ノードを追加する
				string wrk = TDateTime.DateTimeToString("GGYYMMDD", infoItem.PrintOutDateTime);
				wrk += " " + TDateTime.DateTimeToString("HHMM", infoItem.PrintOutDateTime);

				Infragistics.Win.UltraWinTree.UltraTreeNode childNode = new Infragistics.Win.UltraWinTree.UltraTreeNode(infoItem.Id.ToString(),wrk);
				childNode.LeftImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4]);
				childNode.Tag = infoItem.PdfFileName;
              
              
				topNode.Nodes.Add(childNode);
			}
			this.History_Tree.ExpandAll();
#endif

        }
        /// <summary>
        /// 抽出条件初期値設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件に初期値を設定します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void InitialExtraInfoSetting()
        {
            // 企業コード
            this._extraInfo_DemandTotal.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点OP
            this._extraInfo_DemandTotal.IsOptSection = this._isOptSection;

            // 本社機能有無
            //this._extraInfo_DemandTotal.IsMainOfficeFunc = (this._isMainOfficeFunc ? 1 : 0);
            this._extraInfo_DemandTotal.IsMainOfficeFunc = this._isMainOfficeFunc;

            //            // 計上拠点リスト
            //            private ArrayList ResultsAddUpSecList;
            //            // 全社選択有無[true:全社,false:拠点選択]
            //            private bool isSelectAllSection = false;
            // 帳票種類
            //      this._extraInfo_DemandTotal.PrintType = 0;

            // 2008.09.05 30413 犬飼 システム日付取得の削除 >>>>>>START
            //// システム日付取得(Int32)
            //int nowDateInt32 = TDateTime.DateTimeToLongDate(DateTime.Now);
            //int yy = nowDateInt32 / 10000;
            //int mm = nowDateInt32 / 100 % 100;
            //int dd = nowDateInt32 % 100;

            //// 締日
            //this._extraInfo_DemandTotal.TotalDay = dd;
            ////this._extraInfo_DemandTotal.IsLastDay = true;

            //// 出力対象計上年月日
            //if (dd >= 28)
            //{
            //    dd = TDateTime.GetLastDate(yy, mm);
            //}

            //this._extraInfo_DemandTotal.TargetAddUpDate = yy * 10000 + mm * 100 + dd;

            // 得意先締日末日全て
            //this._extraInfo_DemandTotal.IsLastDay = true;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

            // 2008.09.08 30413 犬飼 締日の設定 >>>>>>START
            //DateTime yearMonth, startMonthDate, endMonthDate;
            //Int32 year;
            //_dateGet.GetYearMonth(DateTime.Now, out yearMonth, out year, out startMonthDate, out endMonthDate);
            //this._extraInfo_DemandTotal.AddUpDate = endMonthDate;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            totalDayCalculator.InitializeHisDmdC();
            totalDayCalculator.GetHisTotalDayDmdC(this._loginEmployee.BelongSectionCode, out prevTotalDay);
            if (prevTotalDay != DateTime.MinValue)
            {
                // 前回締日を設定
                this._extraInfo_DemandTotal.AddUpDate = prevTotalDay;
            }
            else
            {
                // 現在日時を設定
                this._extraInfo_DemandTotal.AddUpDate = DateTime.Now;
            }
            // 2008.09.08 30413 犬飼 締日の設定 <<<<<<END            

            // 2008.09.08 30413 犬飼 改頁の初期値 >>>>>>START
            this._extraInfo_DemandTotal.NewPageDiv = 0;
            // 2008.09.08 30413 犬飼 改頁の初期値 <<<<<<END

            switch (this._callMode)
            {
                case START_MODE_DEFAULT_LIST:		// 請求一覧表
                    {
                        this._extraInfo_DemandTotal.SlipPrtKind = 0;
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:		// 請求書(鑑)
                    {
                        this._extraInfo_DemandTotal.SlipPrtKind = 50;
                        break;
                    }
                case START_MODE_DEFAULT_DETAIL:		// 明細請求書
                    {
                        this._extraInfo_DemandTotal.SlipPrtKind = 60;
                        break;
                    }
                case START_MODE_DEFAULT_DETAILSLIP:		// 請求明細書(伝票)
                    {
                        this._extraInfo_DemandTotal.SlipPrtKind = 70;
                        break;
                    }
                case START_MODE_DEFAULT_RECEIPT:        // 領収書
                    {
                        this._extraInfo_DemandTotal.SlipPrtKind = 80;
                        break;
                    }
            }

            // 出力順
            this._extraInfo_DemandTotal.SortOrder = 0;

            // 得意先コード(開始)
            this._extraInfo_DemandTotal.CustomerCodeSt = 0;

            // 得意先コード(終了)
            this._extraInfo_DemandTotal.CustomerCodeEd = 0;

            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //// 得意先カナ(開始)
            //this._extraInfo_DemandTotal.KanaSt = "";

            //// 得意先カナ(終了)
            //this._extraInfo_DemandTotal.KanaEd = "";
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

            // 法人・個人区分
            // 2007.10.15 hikita del start -------------------------------------------->>
            //int[] corporateDivCodes = new int[] { 0, 1, 2, 3, 4 };
            //this._extraInfo_DemandTotal.CorporateDivCodeList = corporateDivCodes;
            // 2007.10.15 hikita del end ----------------------------------------------<<

            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //// 請求書出力区分
            //this._extraInfo_DemandTotal.IsJudgeBillOutputCode = true;			// 2006.09.05 Y.Sasaki CHG
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

            // 顧客担当者コード(開始)
            this._extraInfo_DemandTotal.CustomerAgentCdSt = "";

            // 顧客担当者コード(終了)
            this._extraInfo_DemandTotal.CustomerAgentCdEd = "";

            // 集金担当者コード(開始)
            this._extraInfo_DemandTotal.BillCollecterCdSt = "";

            // 集金担当者コード(終了)
            this._extraInfo_DemandTotal.BillCollecterCdEd = "";

            //// 担当者毎改ページ有無
            //this._extraInfo_DemandTotal.IsEmployeeNextPage = false;


            // 2008.09.08 30413 犬飼 地区の追加 >>>>>>START
            // 地区(開始)
            this._extraInfo_DemandTotal.SalesAreaCodeSt = 0;

            // 地区(終了)
            this._extraInfo_DemandTotal.SalesAreaCodeEd = 0;
            // 2008.09.08 30413 犬飼 地区の追加 <<<<<<END

            // 2008.11.12 30413 犬飼 請求印刷設定マスタから出力区分を取得 >>>>>>START
            // 呼出モードにより出力金額区分を設定
            switch (this._callMode)
            {
                // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                //case START_MODE_ALL:		        // 全帳票
                //    {
                //        break;
                //    }
                // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                case START_MODE_DEFAULT_LIST:		// 請求一覧表
                case START_MODE_DEMANDLIST:	        // 請求一覧表
                    {
                        this._extraInfo_DemandTotal.OutPutPriceCond = this.mDemandPrintAcs.BillPrtStData.BillTableOutCd;
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:		// 請求書
                case START_MODE_DEMANDTOTAL:	    // 請求書
                    {
                        this._extraInfo_DemandTotal.OutPutPriceCond = this.mDemandPrintAcs.BillPrtStData.TotalBillOutputDiv;
                        break;
                    }
                //case START_MODE_DEFAULT_TOTAL:		// 合計請求書
                //case START_MODE_DEMANDTOTAL:	    // 合計請求書
                //    {
                //        this._extraInfo_DemandTotal.OutPutPriceCond = this.mDemandPrintAcs.BillPrtStData.TotalBillOutputDiv;
                //        break;
                //    }
                //case START_MODE_DEFAULT_DETAIL:		// 明細請求書
                //case START_MODE_DEMANDDETAIL:	    // 明細請求書
                //    {
                //        this._extraInfo_DemandTotal.OutPutPriceCond = this.mDemandPrintAcs.BillPrtStData.DetailBillOutputCode;
                //        break;
                //    }
                // 2007.10.15 hikita del start ---------------------------------->>
                //case START_MODE_DEMANDHAND:		    // 手入力合計請求書
                //    {
                //        break;
                //    }
                // 2007.10.15 hikita del end ------------------------------------<< 
                // 2007.10.15 hikita add start ---------------------------------->>
                //case START_MODE_DEFAULT_DETAILSLIP:		// 明細請求書(伝票)
                //case START_MODE_DEMANDDETAILSLIP:	    // 明細請求書(伝票)
                //    {
                //        this._extraInfo_DemandTotal.OutPutPriceCond = this.mDemandPrintAcs.BillPrtStData.DetailBillOutputCode;
                //        break;
                //    }
                case START_MODE_DEFAULT_RECEIPT:	// 領収書
                case START_MODE_DEMANDRECEIPT:	    // 領収書
                    {
                        //this._extraInfo_DemandTotal.OutPutPriceCond = this.mDemandPrintAcs.BillPrtStData.TotalBillOutputDiv;
                        this._extraInfo_DemandTotal.OutPutPriceCond = this.mDemandPrintAcs.BillPrtStData.DetailBillOutputCode;
                        break;
                    }
                // 2007.10.15 hikita add end ------------------------------------<<
                default:
                    break;
            }
            // 2008.11.12 30413 犬飼 請求印刷設定マスタから出力区分を取得 <<<<<<END

            // 2007.10.15 hikita add start --------------------------------------->>
            // 請求内訳
            this._extraInfo_DemandTotal.DmdDtl = 1;
            // 2007.10.15 hikita add end -----------------------------------------<<

            // 2008.09.08 30413 犬飼 回収率、残高入金内訳、発行日の初期値 >>>>>>START
            this._extraInfo_DemandTotal.CollectRatePrtDiv = 0;
            this._extraInfo_DemandTotal.BalanceDepositDtl = 1;
            this._extraInfo_DemandTotal.IssueDay = DateTime.Now;
            // 2008.09.08 30413 犬飼 回収率、残高入金内訳、発行日の初期値 <<<<<<END

            // 2009.01.19 30413 犬飼 親得意先内訳の追加 >>>>>>START
            this._extraInfo_DemandTotal.PrCustDtl = 0;
            // 2009.01.19 30413 犬飼 親得意先内訳の追加 <<<<<<END

            // 2009.03.12 30413 犬飼 売掛区分の処理を追加 >>>>>>START
            // 売掛区分
            this._extraInfo_DemandTotal.AccRecDivCd = 1;
            // 2009.03.12 30413 犬飼 売掛区分の処理を追加 <<<<<<END
            
            // 2007.10.15 hikita del start ---------------------------------->>
            // >>>>> 2006.09.07 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //// 開始得意先分析コード1
            //this._extraInfo_DemandTotal.CustAnalysCode1St = 0;

            //// 開始得意先分析コード2
            //this._extraInfo_DemandTotal.CustAnalysCode2St = 0;

            //// 開始得意先分析コード3
            //this._extraInfo_DemandTotal.CustAnalysCode3St = 0;

            //// 開始得意先分析コード4
            //this._extraInfo_DemandTotal.CustAnalysCode4St = 0;

            //// 開始得意先分析コード5
            //this._extraInfo_DemandTotal.CustAnalysCode5St = 0;

            //// 開始得意先分析コード6
            //this._extraInfo_DemandTotal.CustAnalysCode6St = 0;

            //// 終了得意先分析コード1
            //this._extraInfo_DemandTotal.CustAnalysCode1Ed = 999;

            //// 終了得意先分析コード2
            //this._extraInfo_DemandTotal.CustAnalysCode2Ed = 999;

            //// 終了得意先分析コード3
            //this._extraInfo_DemandTotal.CustAnalysCode3Ed = 999;

            //// 終了得意先分析コード4
            //this._extraInfo_DemandTotal.CustAnalysCode4Ed = 999;

            //// 終了得意先分析コード5
            //this._extraInfo_DemandTotal.CustAnalysCode5Ed = 999;

            //// 終了得意先分析コード6
            //this._extraInfo_DemandTotal.CustAnalysCode6Ed = 999;
            // <<<<< 2006.09.07 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
            // 2007.10.15 hikita del end ------------------------------------<< 
        }

        /// <summary>
        /// 抽出条件設定から画面表示処理(抽出条件→画面)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 抽出条件設定→画面へ表示します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// <br>Update Note: 2011/03/14 yangmj</br>                       
        /// <br>           : 印字制御の区分の追加</br>
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void SetScreenFromExtraInfo_DemandTotal(ExtrInfo_DemandTotal extraInfo)
        {
            this._eventDoFlag = false;
            try
            {
                // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                //this.TotalDay_tNedit.SetInt(extraInfo.TotalDay);

                //// 得意先締日末日全て
                //this.LastDay_CheckEditor.Checked = extraInfo.IsLastDay;

                //if (extraInfo.TotalDay >= 28)
                //{
                //    this.LastDay_CheckEditor.Enabled = true;
                //}
                //else
                //{
                //    this.LastDay_CheckEditor.Enabled = false;
                //}

                //// 締日
                //this.AddUpDate_tDateEdit.SetLongDate(extraInfo.TargetAddUpDate);
                // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

                // 2008.09.08 30413 犬飼 締日、発行タイプ、改頁の追加 >>>>>>START
                // 締日
                this.AddUpDate_tDateEdit.SetDateTime(extraInfo.AddUpDate);

                // 発行タイプ
                this.IssueType_tComboEditor.Value = extraInfo.SlipPrtKind;

                // 改頁
                this.NewPageDiv_tComboEditor.Value = extraInfo.NewPageDiv;
                // 2008.09.08 30413 犬飼 締日、発行タイプ、改頁の追加 <<<<<<END

                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                // 税別内訳印字区分
                this.tComboEditor_TaxPrintDiv.Value = 1;
                // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<

                //---ADD 2011/03/14------------->>>>>
                this.lineMaSqOfChDiv_tComboEditor.Value = extraInfo.LineMaSqOfChDiv;
                this.PrintBlLiDiv_tComboEditor.Value = extraInfo.PrintBlLiDiv;
                //---ADD 2011/03/14-------------<<<<<
                // 出力順
                this.PrintOder_tComboEditor.Value = extraInfo.SortOrder;

                // 得意先コード(開始)
                this.tNedit_CustomerCode_St.SetInt(extraInfo.CustomerCodeSt);
                // 得意先コード(終了)
                this.tNedit_CustomerCode_Ed.SetInt(extraInfo.CustomerCodeEd);

                // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                //// 得意先カナ(開始)
                //this.CustomerKanaStrat_Edit.DataText = extraInfo.KanaSt;
                //// 得意先カナ(終了)
                //this.CustomerKanaEnd_Edit.DataText = extraInfo.KanaEd;
                // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

                // 法人・個人区分
                // 2007.10.15 hikita del start ------------------------------>>
                //this.Personal_CheckEditor.Checked = false;
                //this.Corpo_CheckEditor.Checked = false;
                //this.BigCorpo_CheckEditor.Checked = false;
                //this.Trade_CheckEditor.Checked = false;
                //this.Employee_CheckEditor.Checked = false;
                //foreach (int i in extraInfo.CorporateDivCodeList)
                //{
                //    switch (i)
                //    {
                //        case 0:
                //            this.Personal_CheckEditor.Checked = true;
                //            break;
                //        case 1:
                //            this.Corpo_CheckEditor.Checked = true;
                //            break;
                //        case 2:
                //            this.BigCorpo_CheckEditor.Checked = true;
                //            break;
                //        case 3:
                //            this.Trade_CheckEditor.Checked = true;
                //            break;
                //        case 4:
                //            this.Employee_CheckEditor.Checked = true;
                //            break;
                //    }
                //}
                // 2007.10.15 hikita del end --------------------------------<<

                // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                //// 請求書出力区分
                //this.BillOutputCode_CheckEditor.Checked = extraInfo.IsJudgeBillOutputCode;
                // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

                // 担当者区分
                this.ChargeEmployee_tComboEditor.Value = extraInfo.CustomerAgentDivCd;
                if (extraInfo.CustomerAgentDivCd == 0)
                {
                    // 顧客担当者コード(開始)
                    this.tEdit_EmployeeCode_St.DataText = extraInfo.CustomerAgentCdSt;
                    // 顧客担当者コード(終了)
                    this.tEdit_EmployeeCode_Ed.DataText = extraInfo.CustomerAgentCdEd;
                }
                else
                {
                    // 集金担当者コード(開始)
                    this.tEdit_EmployeeCode_St.DataText = extraInfo.BillCollecterCdSt;
                    // 集金担当者コード(終了)
                    this.tEdit_EmployeeCode_Ed.DataText = extraInfo.BillCollecterCdEd;
                }

                // 出力金額区分
                this.OutPutPriceCond_tComboEditor.SelectedIndex = this._extraInfo_DemandTotal.OutPutPriceCond;

                // 2007.10.15 hikita add start ----------------------------------------------------->>
                // 請求先内訳
                if (this._callMode != START_MODE_DEFAULT_LIST)  // 請求一覧の以外
                {
                    this.DmdDtl_tComboEditor.SelectedIndex = 1;
                }
                else
                {
                    this.DmdDtl_tComboEditor.SelectedIndex = this._extraInfo_DemandTotal.DmdDtl;
                }
                // 2007.10.15 hikita add end -------------------------------------------------------<<

                // 2008.09.08 30413 犬飼 回収率印字、残高入金内訳、発行日の追加 >>>>>>START
                // 回収率印字
                this.CollectRatePrtDiv_tComboEditor.Value = extraInfo.CollectRatePrtDiv;

                // 残高入金内訳
                this.BalanceDepositDtl_tComboEditor.Value = extraInfo.BalanceDepositDtl;

                // 発行日
                this.IssueDay_tDateEdit.SetDateTime(extraInfo.IssueDay);
                // 2008.09.08 30413 犬飼 回収率、残高入金内訳、発行日の追加 <<<<<<END

                // 2009.01.19 30413 犬飼 親得意先内訳の追加 >>>>>>START
                // 親得意先内訳
                this.PrCustDtl_tComboEditor.Value = extraInfo.PrCustDtl;
                // 2009.01.19 30413 犬飼 親得意先内訳の追加 <<<<<<END

                // 2009.03.12 30413 犬飼 売掛区分の処理を追加 >>>>>>START
                // 売掛区分
                this.AccRecDivCd_tComboEditor.Value = extraInfo.AccRecDivCd;
                // 2009.03.12 30413 犬飼 売掛区分の処理を追加 <<<<<<END
            
                // 2007.10.15 hikita del start ------------------------------>>
                // >>>>> 2006.09.07 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                //// 開始得意先分析コード1
                //this.CustAnalysCode1St_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode1St);
                //// 開始得意先分析コード2
                //this.CustAnalysCode2St_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode2St);
                //// 開始得意先分析コード3
                //this.CustAnalysCode3St_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode3St);
                //// 開始得意先分析コード4
                //this.CustAnalysCode4St_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode4St);
                //// 開始得意先分析コード5
                //this.CustAnalysCode5St_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode5St);
                //// 開始得意先分析コード6
                //this.CustAnalysCode6St_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode6St);

                //// 終了得意先分析コード1
                //this.CustAnalysCode1Ed_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode1Ed);
                //// 終了得意先分析コード2
                //this.CustAnalysCode2Ed_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode2Ed);
                //// 終了得意先分析コード3
                //this.CustAnalysCode3Ed_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode3Ed);
                //// 終了得意先分析コード4
                //this.CustAnalysCode4Ed_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode4Ed);
                //// 終了得意先分析コード5
                //this.CustAnalysCode5Ed_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode5Ed);
                //// 終了得意先分析コード6
                //this.CustAnalysCode6Ed_tNedit.SetInt(this._extraInfo_DemandTotal.CustAnalysCode6Ed);
                // <<<<< 2006.09.07 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
                // 2007.10.15 hikita del end --------------------------------<<
                //-----2011/03/14----->>>>>
                this.PrintBlLiDiv_tComboEditor.Value = 1;
                this.lineMaSqOfChDiv_tComboEditor.Value = 0;
                //-----2011/03/14-----<<<<<
            }
            finally
            {
                this._eventDoFlag = true;

                // 2009.01.14 30413 犬飼 ＵＩ入力保存コンポーネントの追加 >>>>>>START
                uiMemInput1.ReadMemInput();
                // 2009.01.14 30413 犬飼 ＵＩ入力保存コンポーネントの追加 <<<<<<END
            }
        }

        /// <summary>
        /// 抽出条件設定処理(画面→抽出条件)
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面→抽出条件へ設定します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// <br>Update Note: 2011/03/14 yangmj</br>                       
        /// <br>           : 印字制御の区分の追加</br>
        /// <br>Update Note: 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void SetExtraInfo_DemandTotalFromScreen(ref ExtrInfo_DemandTotal extraInfo)
        {
            // 企業コード
            this._extraInfo_DemandTotal.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 拠点OP
            this._extraInfo_DemandTotal.IsOptSection = this._isOptSection;

            // 2008.10.17 30413 犬飼 拠点選択の処理を仮変更 >>>>>>START
            // 本社機能有無
            //this._extraInfo_DemandTotal.MainOfficeFuncFlag = (this._isMainOfficeFunc ? 1 : 0);
            this._extraInfo_DemandTotal.IsMainOfficeFunc = this._isMainOfficeFunc;

            //if (extraInfo.ResultsAddUpSecList == null)
            //{
            //    extraInfo.ResultsAddUpSecList = new ArrayList();
            //}

            // 本社機能あり
            if (this.Main_ExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible)
            {
                ArrayList secList = new ArrayList();

                // 拠点の選択情報を設定
                this._sectionCodeList.Clear();
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_Tree.Nodes)
                {
                    if (utn.CheckedState == CheckState.Checked)
                    {
                        this._sectionCodeList.Add(utn.Key, utn.Key);
                    }
                }

                // 拠点情報設定
                //extraInfo.ResultsAddUpSecList.Clear();
                if (this._sectionCodeList.ContainsKey(DemandPrintAcs.CT_AllSectionCode))
                {
                    // 全社?
                    extraInfo.IsSelectAllSection = false;
                    extraInfo.IsOutputAllSecRec = true;

                    // 拠点名称カラムON
                    this.DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns[DemandPrintAcs.CT_CsDmd_AddUpSecName].Hidden = false;

                    extraInfo.ResultsAddUpSecList = new string[1];
                    extraInfo.ResultsAddUpSecList[0] = "";
                }
                else
                {
                    // 選択拠点
                    foreach (DictionaryEntry entry in this._sectionCodeList)
                    {
                        //extraInfo.ResultsAddUpSecList.Add(entry.Value.ToString());
                        secList.Add(entry.Value.ToString());
                    }
                    extraInfo.ResultsAddUpSecList = (string[])secList.ToArray(typeof(string));

                    extraInfo.IsSelectAllSection = false;
                    extraInfo.IsOutputAllSecRec = false;

                    // 拠点名称カラムOFF
                    this.DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns[DemandPrintAcs.CT_CsDmd_AddUpSecName].Hidden = true;
                }
            }
            // 本社機能なし　or 拠点オプションなし
            else
            {
                //extraInfo.ResultsAddUpSecList.Clear();
                //extraInfo.ResultsAddUpSecList.Add(this._demandSectionCode);
                extraInfo.ResultsAddUpSecList = new string[0];

                extraInfo.IsSelectAllSection = false;
                extraInfo.IsOutputAllSecRec = false;
                // 拠点名称カラムOFF
                this.DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns[DemandPrintAcs.CT_CsDmd_AddUpSecName].Hidden = true;
            }
            // 2008.10.17 30413 犬飼 拠点選択の処理を仮変更 <<<<<<END

            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //// 得意先締日
            //extraInfo.TotalDay = this.TotalDay_tNedit.GetInt();

            //if (LastDay_CheckEditor.Enabled)
            //{
            //    extraInfo.IsLastDay = this.LastDay_CheckEditor.Checked;
            //}
            //else
            //{
            //    extraInfo.IsLastDay = false;
            //}

            //// 計上年月日
            //extraInfo.TargetAddUpDate = this.AddUpDate_tDateEdit.GetLongDate();
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

            // 2008.09.08 30413 犬飼 出力条件の追加 >>>>>>START
            // 締日
            extraInfo.AddUpDate = this.AddUpDate_tDateEdit.GetDateTime();

            switch (this._callMode)
            {
                case START_MODE_DEFAULT_LIST:		// 請求一覧表
                case START_MODE_DEMANDLIST:	        // 請求一覧表
                    {
                        // 改頁
                        extraInfo.NewPageDiv = Convert.ToInt32(this.NewPageDiv_tComboEditor.SelectedItem.DataValue);

                        // 回収率印字
                        extraInfo.CollectRatePrtDiv = Convert.ToInt32(this.CollectRatePrtDiv_tComboEditor.SelectedItem.DataValue);
                        // 残高入金内訳
                        extraInfo.BalanceDepositDtl = Convert.ToInt32(this.BalanceDepositDtl_tComboEditor.SelectedItem.DataValue);

                        //---ADD 2011/03/14----->>>>>
                        extraInfo.PrintBlLiDiv = Convert.ToInt32(this.PrintBlLiDiv_tComboEditor.SelectedItem.DataValue);
                        extraInfo.LineMaSqOfChDiv = Convert.ToInt32(this.lineMaSqOfChDiv_tComboEditor.SelectedItem.DataValue);
                        //---ADD 2011/03/14-----<<<<<
                        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ---------->>>>>
                        // 税別内訳印字区分
                        SetPropertyValue(extraInfo, "TaxPrintDiv", Convert.ToInt32(this.tComboEditor_TaxPrintDiv.SelectedItem.DataValue));

                        // 税別内訳印字する
                        if (Convert.ToInt32(this.tComboEditor_TaxPrintDiv.SelectedItem.DataValue) == 0)
                        {
                            TaxRatePrintInfo taxInfo = null;
                            string errMsg = string.Empty;

                            int status = Deserialize(out taxInfo, out errMsg);
                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                // 税率1
                                SetPropertyValue(extraInfo, "TaxRate1", Convert.ToDouble(taxInfo.TaxRate1));
                                // 税率2
                                SetPropertyValue(extraInfo, "TaxRate2", Convert.ToDouble(taxInfo.TaxRate2));
                            }
                        }
                        // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----------<<<<<
                        break;
                    }
                case START_MODE_DEFAULT_TOTAL:		// 請求書(鑑)
                case START_MODE_DEFAULT_DETAIL:		// 明細請求書
                case START_MODE_DEFAULT_DETAILSLIP:	// 請求明細書(伝票)
                    {
                        // 発行タイプ
                        extraInfo.SlipPrtKind = Convert.ToInt32(this.IssueType_tComboEditor.SelectedItem.DataValue);
                        break;
                    }
                case START_MODE_DEFAULT_RECEIPT:    // 領収書
                    {
                        // 発行タイプ
                        extraInfo.SlipPrtKind = 80;
                        break;
                    }
            }

            // 地区(開始)
            extraInfo.SalesAreaCodeSt = this.tNedit_SalesAreaCode_St.GetInt();
            // 地区(終了)
            extraInfo.SalesAreaCodeEd = this.tNedit_SalesAreaCode_Ed.GetInt();


            // 発行日
            extraInfo.IssueDay = this.IssueDay_tDateEdit.GetDateTime();

            // 2008.09.08 30413 犬飼 出力条件の追加 <<<<<<END

            // 出力順
            extraInfo.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);

            // 得意先コード(開始)
            extraInfo.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
            // 得意先コード(終了)
            extraInfo.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //// 得意先カナ(開始)
            //extraInfo.KanaSt = this.CustomerKanaStrat_Edit.DataText;
            //// 得意先カナ(終了)
            //extraInfo.KanaEd = this.CustomerKanaEnd_Edit.DataText;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

            // 法人・個人区分
            // 2007.10.15 hikita del start --------------------------------------->>
            //List<int> checkedList = new List<int>();
            //extraInfo.CorporateDivCodeList.Initialize();

            //if (this.Personal_CheckEditor.Checked)  checkedList.Add(0);
            //if (this.Corpo_CheckEditor.Checked)     checkedList.Add(1);
            //if (this.BigCorpo_CheckEditor.Checked)  checkedList.Add(2);
            //if (this.Trade_CheckEditor.Checked)     checkedList.Add(3);
            //if (this.Employee_CheckEditor.Checked)  checkedList.Add(4);

            //if (extraInfo.CorporateDivCodeList.Length != checkedList.Count)
            //{
            //    extraInfo.CorporateDivCodeList = new int[checkedList.Count];
            //}

            //if (extraInfo.CorporateDivNameList == null)
            //{
            //    extraInfo.CorporateDivNameList = new ArrayList();
            //}
            //extraInfo.CorporateDivNameList.Clear();
            //for (int i = 0; i < checkedList.Count; i++)
            //{
            //    extraInfo.CorporateDivNameList.Add("");
            //}

            //int setCnt = 0;
            //if (this.Personal_CheckEditor.Checked)
            //{
            //    extraInfo.CorporateDivCodeList[setCnt] = 0;
            //    setCnt++;
            //}
            //if (this.Corpo_CheckEditor.Checked)
            //{
            //    extraInfo.CorporateDivCodeList[setCnt] = 1;
            //    setCnt++;
            //}
            //if (this.BigCorpo_CheckEditor.Checked)
            //{
            //    extraInfo.CorporateDivCodeList[setCnt] = 2;
            //    setCnt++;
            //}
            //if (this.Trade_CheckEditor.Checked)
            //{
            //    extraInfo.CorporateDivCodeList[setCnt] = 3;
            //    setCnt++;
            //}
            //if (this.Employee_CheckEditor.Checked)
            //{
            //    extraInfo.CorporateDivCodeList[setCnt] = 4;
            //    setCnt++;
            //}
            // 2007.10.15 hikita del end -----------------------------------------<<

            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //// 請求書出力区分
            //extraInfo.IsJudgeBillOutputCode = this.BillOutputCode_CheckEditor.Checked;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            // 担当者区分
            extraInfo.CustomerAgentDivCd = TStrConv.StrToIntDef(this.ChargeEmployee_tComboEditor.SelectedItem.DataValue.ToString(), 0);

            if (this.ChargeEmployee_tComboEditor.SelectedIndex == 0)
            {
                // 2008.10.17 30413 犬飼 0詰め対応 >>>>>>START
                //// 顧客担当者コード(開始)
                //extraInfo.CustomerAgentCdSt = this.tEdit_EmployeeCode_St.DataText;
                //// 顧客担当者コード(終了)
                //extraInfo.CustomerAgentCdEd = this.tEdit_EmployeeCode_Ed.DataText;
                // 顧客担当者コード(開始)
                if (this.tEdit_EmployeeCode_St.Text.Trim() == "")
                {
                    extraInfo.CustomerAgentCdSt = "";
                }
                else
                {
                    extraInfo.CustomerAgentCdSt = this.tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                }
                // 顧客担当者コード(終了)
                if (this.tEdit_EmployeeCode_Ed.Text.Trim() == "")
                {
                    extraInfo.CustomerAgentCdEd = "";
                }
                else
                {
                    extraInfo.CustomerAgentCdEd = this.tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                }
                // 2008.10.17 30413 犬飼 0詰め対応 <<<<<<END
            }
            else
            {
                // 2008.10.17 30413 犬飼 0詰め対応 >>>>>>START
                //// 集金担当者コード(開始)
                //extraInfo.BillCollecterCdSt = this.tEdit_EmployeeCode_St.DataText;
                //// 集金担当者コード(終了)
                //extraInfo.BillCollecterCdEd = this.tEdit_EmployeeCode_Ed.DataText;
                // 集金担当者コード(開始)
                if (this.tEdit_EmployeeCode_St.Text.Trim() == "")
                {
                    extraInfo.BillCollecterCdSt = "";
                }
                else
                {
                    extraInfo.BillCollecterCdSt = this.tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                }
                // 集金担当者コード(終了)
                if (this.tEdit_EmployeeCode_Ed.Text.Trim() == "")
                {
                    extraInfo.BillCollecterCdEd = "";
                }
                else
                {
                    extraInfo.BillCollecterCdEd = this.tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                }
                // 2008.10.17 30413 犬飼 0詰め対応 <<<<<<END
            }

            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (EmployeeNext_CheckEditor.Enabled)
            //{
            //    extraInfo.IsEmployeeNextPage = EmployeeNext_CheckEditor.Checked;
            //}
            //else
            //{
            //    extraInfo.IsEmployeeNextPage = false;
            //}
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            //// 請求一覧表出力区分
            //extraInfo.BillTableOutCd = (int)this.BillTableOutPut_tComboEditor.SelectedItem.DataValue;
            //// 合計請求書出力区分
            //extraInfo.TotalBillOutputDiv = (int)this.TotalBillOutput_tComboEditor.SelectedItem.DataValue;
            //// 明細請求書出力区分
            //extraInfo.DetailBillOutputCode = (int)this.DetailBillOutput_tComboEditor.SelectedItem.DataValue;
            // 出力金額区分
            extraInfo.OutPutPriceCond = (int)this.OutPutPriceCond_tComboEditor.SelectedItem.DataValue;

            // 2007.10.15 hikita add start ------------------------------------------------>>
            // 請求内訳
            extraInfo.DmdDtl = (int)this.DmdDtl_tComboEditor.SelectedIndex;
            // 2007.10.15 hikita add end --------------------------------------------------<<

            // 2009.01.19 30413 犬飼 親得意先内訳の追加 >>>>>>START
            extraInfo.PrCustDtl = (int)this.PrCustDtl_tComboEditor.Value;
            // 2009.01.19 30413 犬飼 親得意先内訳の追加 <<<<<<END

            // 2009.03.12 30413 犬飼 売掛区分の処理を追加 >>>>>>START
            // 売掛区分
            extraInfo.AccRecDivCd = (int)this.AccRecDivCd_tComboEditor.Value;
            // 2009.03.12 30413 犬飼 売掛区分の処理を追加 <<<<<<END
            
            // 2007.10.15 hikita del start ------------------------------------------------>>
            // >>>>> 2006.09.07 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //// 開始得意先分析コード1
            //extraInfo.CustAnalysCode1St = this.CustAnalysCode1St_tNedit.GetInt();
            //// 開始得意先分析コード2
            //extraInfo.CustAnalysCode2St = this.CustAnalysCode2St_tNedit.GetInt();
            //// 開始得意先分析コード3
            //extraInfo.CustAnalysCode3St = this.CustAnalysCode3St_tNedit.GetInt();
            //// 開始得意先分析コード4
            //extraInfo.CustAnalysCode4St = this.CustAnalysCode4St_tNedit.GetInt();
            //// 開始得意先分析コード5
            //extraInfo.CustAnalysCode5St = this.CustAnalysCode5St_tNedit.GetInt();
            //// 開始得意先分析コード6
            //extraInfo.CustAnalysCode6St = this.CustAnalysCode6St_tNedit.GetInt();

            //// 終了得意先分析コード1
            //extraInfo.CustAnalysCode1Ed = this.CustAnalysCode1Ed_tNedit.GetInt();
            //// 終了得意先分析コード2
            //extraInfo.CustAnalysCode2Ed = this.CustAnalysCode2Ed_tNedit.GetInt();
            //// 終了得意先分析コード3
            //extraInfo.CustAnalysCode3Ed = this.CustAnalysCode3Ed_tNedit.GetInt();
            //// 終了得意先分析コード4
            //extraInfo.CustAnalysCode4Ed = this.CustAnalysCode4Ed_tNedit.GetInt();
            //// 終了得意先分析コード5
            //extraInfo.CustAnalysCode5Ed = this.CustAnalysCode5Ed_tNedit.GetInt();
            //// 終了得意先分析コード6
            //extraInfo.CustAnalysCode6Ed = this.CustAnalysCode6Ed_tNedit.GetInt();
            // <<<<< 2006.09.07 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
            // 2007.10.15 hikita del end --------------------------------------------------<<
        }

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private bool ScreenInputCheck(out string message, ref Control errControl)
        {
            message = "";
            bool status = true;
            bool result = false;
            errControl = null;
            DateGetAcs.CheckDateResult cdrResult;

            const string ct_InputError = "の入力が不正です";
            const string ct_NoInput = "を入力して下さい";
            const string ct_RangeError = "の範囲指定に誤りがあります";

            // ADD 2009/03/18 不具合対応[12420]：出力拠点の入力チェックの不正 ---------->>>>>
            // 拠点範囲
            _currentResultCode = ResultCode.Normal;
            if (CheckSectionTreeNode(
                this.tEdit_SectionCode_St.Text,
                this.tEdit_SectionCode_Ed.Text
            ).Equals((int)ResultCode.StartSectionCodeHasError))
            {
                _currentResultCode = ResultCode.StartSectionCodeHasError;
                message = "拠点" + ct_RangeError;
                errControl = this.tEdit_SectionCode_St;
                return false;
            }
            // ADD 2009/03/18 不具合対応[12420]：出力拠点の入力チェックの不正 ----------<<<<<

            // 2008.09.10 30413 犬飼 締日チェック変更 >>>>>>START
            //// 計上年月日
            //if (!InputDateEditCheack(this.AddUpDate_tDateEdit))
            //{
            //    message = "締日の指定に誤りがあります";
            //    errControl = this.AddUpDate_tDateEdit;
            //    return result;
            //}

            // 締日
            if (CallCheckDate(out cdrResult, ref AddUpDate_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            message = string.Format("締日{0}", ct_InputError);
                            errControl = this.AddUpDate_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            message = string.Format("締日{0}", ct_NoInput);
                            errControl = this.AddUpDate_tDateEdit;
                        }
                        break;
                }
                status = false;
            }
            // 2008.09.10 30413 犬飼 締日チェック変更 <<<<<<END

            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //// 得意先締日
            //if (TotalDay_tNedit.GetInt() < 0 || TotalDay_tNedit.GetInt() >= 32)
            //{
            //    message = "得意先締日の指定に誤りがあります";
            //    errControl = this.TotalDay_tNedit;
            //    return result;
            //}
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

            // 2008.09.10 30413 犬飼 チェック順序変更 >>>>>>START
            //// 得意先コード範囲チェック
            //if ((this.CustomerCodeStRF_Nedit.GetInt() > this.CustomerCodeEdRF_Nedit.GetInt()) && (this.CustomerCodeEdRF_Nedit.GetInt() != 0))
            //{
            //    message = "得意先コードの範囲指定に誤りがあります";
            //    errControl = this.CustomerCodeStRF_Nedit;
            //    return result;
            //}
            // 2008.09.10 30413 犬飼 チェック順序変更 <<<<<<END

            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //// 得意先カナ範囲チェック
            //if ((this.CustomerKanaStrat_Edit.DataText != "") && (this.CustomerKanaEnd_Edit.DataText != ""))
            //{
            //    if (this.CustomerKanaStrat_Edit.DataText.CompareTo(this.CustomerKanaEnd_Edit.DataText) > 0)
            //    {
            //        message = "得意先カナの範囲指定に誤りがあります。";
            //        errControl = this.CustomerKanaStrat_Edit;
            //        return result;
            //    }
            //}
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

            // 個人・法人区分
            // 2007.10.15 hikita del start --------------------------------------------------->>
            //if (!((this.Personal_CheckEditor.Checked) || (this.Corpo_CheckEditor.Checked) ||
            //  (this.BigCorpo_CheckEditor.Checked) || (this.Trade_CheckEditor.Checked) ||
            //  (this.Employee_CheckEditor.Checked)))
            //{
            //    message = "個人・法人区分を最低１つは選択してください。";
            //    errControl = this.Personal_CheckEditor;
            //    return result;
            //}
            // 2007.10.15 hikita del end -----------------------------------------------------<<

            //// 担当者コード範囲チェック
            //if ((this.EmployeeCodeStart_Edit.DataText != "") && (this.EmployeeCodeEnd_Edit.DataText != ""))
            //{
            //    if (this.EmployeeCodeStart_Edit.DataText.CompareTo(this.EmployeeCodeEnd_Edit.DataText) > 0)
            //    {
            //        message = "担当者コードの範囲指定に誤りがあります。";
            //        errControl = this.EmployeeCodeStart_Edit;
            //        return result;
            //    }
            //}

            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 ----->>>>>
            // XMLの税率情報
            if (tComboEditor_TaxPrintDiv.SelectedIndex == 0 && this._extraInfo_DemandTotal.SlipPrtKind == 0)
            {
                string errMsg = string.Empty;
                TaxRatePrintInfo taxRatePrintInfo = null;
                Deserialize(out taxRatePrintInfo, out errMsg);
                if (errMsg != string.Empty)
                {
                    message = errMsg;
                    errControl = tComboEditor_TaxPrintDiv;
                    status = false;
                    return status;
                }
            }
            // --- ADD 2020/04/13 陳艶丹 軽減税率対応 -----<<<<<

            // 担当者コード
            else if (
              (this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
              (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
              (this.tEdit_EmployeeCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
            {
                if (this.ChargeEmployee_tComboEditor.SelectedIndex == 0)
                {
                    message = string.Format("得意先担当{0}", ct_RangeError);
                }
                else
                {
                    message = string.Format("集計担当{0}", ct_RangeError);
                }
                errControl = this.tEdit_EmployeeCode_St;
                status = false;
            }
            // 地区
            else if ((tNedit_SalesAreaCode_St.DataText.Trim() != "")
                && (tNedit_SalesAreaCode_Ed.DataText.Trim() != "")
                && (this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt()))
            {
                message = string.Format("地区{0}", ct_RangeError);
                errControl = this.tNedit_SalesAreaCode_St;
                status = false;
            }

            // 得意先コード
            else if ((tNedit_CustomerCode_St.DataText.Trim() != "")
                && (tNedit_CustomerCode_Ed.DataText.Trim() != "")
                && (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()))
            {
                message = string.Format("得意先{0}", ct_RangeError);
                errControl = this.tNedit_CustomerCode_St;
                status = false;
            }

            // 2009.01.20 30413 犬飼 発行日のチェックを追加 >>>>>>START
            // 発行日
            else if (CallCheckDate(out cdrResult, ref IssueDay_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            message = string.Format("発行日{0}", ct_InputError);
                            errControl = this.IssueDay_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            message = string.Format("発行日{0}", ct_NoInput);
                            errControl = this.IssueDay_tDateEdit;
                        }
                        break;
                }
                status = false;
            }
            // 2009.01.20 30413 犬飼 発行日のチェックを追加 <<<<<<END

            // 2007.10.15 hikita del start --------------------------------------------------->>
            // >>>>> 2006.09.07 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            #region 得意先分析コードチェック
            //// 得意先分析コード１
            //if (this.CustAnalysCode1St_tNedit.GetInt() > this.CustAnalysCode1Ed_tNedit.GetInt())
            //{
            //    message = "得意先分析コード１の範囲指定に誤りがあります";
            //    errControl = this.CustAnalysCode1St_tNedit;
            //    return result;
            //}

            //// 得意先分析コード２　
            //if (this.CustAnalysCode2St_tNedit.GetInt() > this.CustAnalysCode2Ed_tNedit.GetInt())
            //{
            //    message = "得意先分析コード２の範囲指定に誤りがあります";
            //    errControl = this.CustAnalysCode2St_tNedit;
            //    return result;
            //}

            //// 得意先分析コード３
            //if (this.CustAnalysCode3St_tNedit.GetInt() > this.CustAnalysCode3Ed_tNedit.GetInt())
            //{
            //    message = "得意先分析コード３の範囲指定に誤りがあります";
            //    errControl = this.CustAnalysCode3St_tNedit;
            //    return result;
            //}

            //// 得意先分析コード４
            //if (this.CustAnalysCode4St_tNedit.GetInt() > this.CustAnalysCode4Ed_tNedit.GetInt())
            //{
            //    message = "得意先分析コード４の範囲指定に誤りがあります";
            //    errControl = this.CustAnalysCode4St_tNedit;
            //    return result;
            //}

            //// 得意先分析コード５
            //if (this.CustAnalysCode5St_tNedit.GetInt() > this.CustAnalysCode5Ed_tNedit.GetInt())
            //{
            //    message = "得意先分析コード５の範囲指定に誤りがあります";
            //    errControl = this.CustAnalysCode5St_tNedit;
            //    return result;
            //}

            //// 得意先分析コード６
            //if (this.CustAnalysCode6St_tNedit.GetInt() > this.CustAnalysCode6Ed_tNedit.GetInt())
            //{
            //    message = "得意先分析コード６の範囲指定に誤りがあります";
            //    errControl = this.CustAnalysCode6St_tNedit;
            //    return result;
            //}
            #endregion
            // <<<<< 2006.09.07 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
            // 2007.10.15 hikita del end -----------------------------------------------------<<

            // 拠点チェック
            if (this.Main_ExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible)
            {
                bool blnCheck = false;

                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_Tree.Nodes)
                {
                    if (utn.CheckedState == CheckState.Checked)
                    {
                        blnCheck = true;
                        break;
                    }
                }

                if (!blnCheck)
                {
                    message = "出力対象拠点は必ず一つはチェックしてください。";
                    errControl = this.Section_Tree;
                    return result;
                }
            }

            return status;
        }

        /// <summary>
        /// 請求金額情報取得
        /// </summary>
        /// <param name="displayMode">抽出結果表示モード[0:結果表示,1:結果非表示]</param>
        /// <param name="printType">帳票種類</param>
        /// <remarks>
        /// <br>Note       : 請求金額情報の検索情報の抽出を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private int SearchDemandData(int displayMode, int printType)
        {
            string errDspMsg = null;

            // >>>>> 2006.08.18 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // <<<<< 2006.08.18 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // >>>>> 2006.08.18 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //if (this._extractionForm == null || this._extractionForm.IsDisposed)
            //{
            //  this._extractionForm = new MAKAU02012UB();
            //}
            // <<<<< 2006.08.18 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            // 抽出結果タブを非表示にする
            Infragistics.Win.UltraWinTabControl.UltraTab tab =
                this.Main_TabControl.Tabs[TABCONTROL_EXTRADATASCREEN_KEY];
            if (tab != null) { tab.Visible = false; }

            // 抽出中ダイアログ作成
            SFCMN00299CA pd = new SFCMN00299CA();
            pd.Title = "抽出中";
            pd.Message = "現在、データ抽出中です．．．";
            pd.DispCancelButton = false;

            // >>>>> 2006.10.24 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //			pd.Show(this);
            pd.Show(this._topForm);
            // <<<<< 2006.10.24 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            try
            {
                // データ抽出処理
                string message;

                // >>>>> 2006.08.18 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
                //			int status = this._extractionForm.ExtractStart(this.mDemandPrintAcs, this._extraInfo_DemandTotal, out message);
                status = this.mDemandPrintAcs.SearchDemandList(this._extraInfo_DemandTotal, out message, out errDspMsg);
                // <<<<< 2006.08.18 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

                // >>>>> 2006.08.18 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //

                // 請求印刷設定の帳票別出力条件でフィルタをかける
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.26 30413 犬飼 抽出時は得意先順とする >>>>>>START
                    // ソート順設定
                    //mDemandPrintAcs.CustDmdPrcDataView.Sort = this.GetPrintOderQuerry();
                    // 2009.01.26 30413 犬飼 抽出時は得意先順とする <<<<<<END

                    this.ChangePrintType(printType);

                    // フィルタをかけた結果、該当件数なしの場合ステータスを変更する
                    if (this.mDemandPrintAcs.CustDmdPrcDataView.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                }

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            if (tab != null)
                            {
                                tab.Visible = true;

                                if (displayMode == 0)
                                {
                                    this.Main_TabControl.Focus();
                                    this.Main_TabControl.SelectedTab = tab;
                                    this.UnSelect_Button.Focus();
                                }
                                this.DEMANDLISTVIEW.Refresh();
                                this.ColumnPerformAutoResize();
                                this.CalculationTotalViewRow();
                            }
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "該当するデータがありません", status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        }
                    default:
                        TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        break;
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                pd.Close();
                if (String.IsNullOrEmpty(errDspMsg) == false)
                {
                    MessageBox.Show(errDspMsg, "出力回避請求先リスト", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            //{
            //  // ソート順設定
            //  mDemandPrintAcs.CustDmdPrcDataView.Sort = this.GetPrintOderQuerry();				

            //  this.ChangePrintType(printType);

            //  // フィルタをかけた結果、該当件数なしの場合ステータスを変更する
            //  if (this.mDemandPrintAcs.CustDmdPrcDataView.Count == 0)
            //  {
            //    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN; 
            //  }
            //}

            //switch (status)
            //{
            //  case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
            //  {
            //    if (tab != null)
            //    { 
            //      tab.Visible = true;

            //      if (displayMode == 0)
            //      {
            //        this.Main_TabControl.Focus();
            //        this.Main_TabControl.SelectedTab = tab;
            //        this.UnSelect_Button.Focus();
            //      }
            //      this.DEMANDLISTVIEW.Refresh();
            //      this.ColumnPerformAutoResize();
            //      this.CalculationTotalViewRow();
            //    }
            //    break;
            //  }
            //  case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
            //  {
            //    TMessageBox(emErrorLevel.ERR_LEVEL_INFO,"該当するデータがありません",status,MessageBoxButtons.OK,MessageBoxDefaultButton.Button1); 
            //    break;
            //  }
            //  case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
            //    break;
            //  default:
            //    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,message,status,MessageBoxButtons.OK,MessageBoxDefaultButton.Button1); 
            //    break;
            //}
            // <<<<< 2006.08.18 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            return status;
        }

        /// <summary>
        /// 請求金額情報取得
        /// </summary>
        /// <param name="displayMode">抽出結果表示モード[0:結果表示,1:結果非表示]</param>
        /// <param name="printType">帳票種類</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 請求金額情報の検索情報の抽出を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// <br>Update Note: 2011/03/23 曹文傑</br>                       
        /// <br>           : 仕様連絡 #20083</br>
        /// </remarks>
        private int SearchDemandData(int displayMode, int printType, out string msg)
        {
            string errDspMsg = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";

            // 抽出結果タブを非表示にする
            Infragistics.Win.UltraWinTabControl.UltraTab tab =
                this.Main_TabControl.Tabs[TABCONTROL_EXTRADATASCREEN_KEY];
            if (tab != null) { tab.Visible = false; }

            // 抽出中ダイアログ作成
            SFCMN00299CA pd = new SFCMN00299CA();
            pd.Title = "抽出中";
            pd.Message = "現在、データ抽出中です．．．";
            pd.DispCancelButton = false;

            // >>>>> 2006.10.24 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
            //			pd.Show(this);
            pd.Show(this._topForm);
            // <<<<< 2006.10.24 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

            try
            {
                // ---ADD 2011/03/23---------->>>>>
                string pgName;
                switch (_callMode)
                {
                    case START_MODE_DEFAULT_LIST:
                    case START_MODE_DEMANDLIST:
                        pgName = "請求一覧表";
                        break;
                    case START_MODE_DEFAULT_RECEIPT:
                    case START_MODE_DEMANDRECEIPT:
                        pgName = "領収書";
                        break;
                    default:
                        pgName = "請求書";
                        break;
                }

                // 2:印刷,1:PDF
                int operationCode = 2;
                if (_printInfo != null)
                {
                    operationCode = (_printInfo.printmode == 2) ? 1 : 2;
                }
                OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
                operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, "SFANL07200U", pgName, "", operationCode, 0, "抽出開始", "");
                // ---ADD 2011/03/23----------<<<<<

                // データ抽出処理
                status = this.mDemandPrintAcs.SearchDemandList(this._extraInfo_DemandTotal, out msg, out errDspMsg);

                // ---ADD 2011/03/23---------->>>>>
                operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, "SFANL07200U", pgName, "", operationCode, 0, "抽出終了", "");
                // ---ADD 2011/03/23----------<<<<<

                // 請求印刷設定の帳票別出力条件でフィルタをかける
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.26 30413 犬飼 抽出時は得意先順とする >>>>>>START
                    // ソート順設定
                    //mDemandPrintAcs.CustDmdPrcDataView.Sort = this.GetPrintOderQuerry();
                    // 2009.01.26 30413 犬飼 抽出時は得意先順とする <<<<<<END

                    this.ChangePrintType(printType);

                    // フィルタをかけた結果、該当件数なしの場合ステータスを変更する
                    if (this.mDemandPrintAcs.CustDmdPrcDataView.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            if (tab != null)
                            {
                                tab.Visible = true;

                                if (displayMode == 0)
                                {
                                    this.Main_TabControl.Focus();
                                    this.Main_TabControl.SelectedTab = tab;
                                    this.UnSelect_Button.Focus();
                                }
                                this.DEMANDLISTVIEW.Refresh();
                                this.ColumnPerformAutoResize();
                                // iitani 仮
                                this.CalculationTotalViewRow();
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            msg = "該当するデータがありません";
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                pd.Close();
                if (String.IsNullOrEmpty(errDspMsg) == false)
                {
                    MessageBox.Show(errDspMsg, "出力回避請求先リスト", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return status;
        }

        /// <summary>
        /// 印字順クエリ作成処理
        /// </summary>
        /// <returns>作成したクエリ</returns>
        /// <remarks>
        /// <br>Note       : DataViewに設定する印字順位のクエリを作成します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            // 印字順設定
            switch (this._extraInfo_DemandTotal.SortOrder)
            {
                // 2008.09.08 30413 犬飼 ソート内容変更 >>>>>>START
                //case 0:
                //    {
                //        // 得意先コード順(拠点コード,請求先コード,得意先コード)
                //        oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + "," + 
                //            DemandPrintAcs.CT_CsDmd_ClaimCode + "," +         
                //            DemandPrintAcs.CT_CsDmd_CustomerCode;
                //        break;
                //    }
                //case 1:
                //    {
                //        // 得意先カナ順(拠点コード,得意先カナ,請求先コード,得意先コード)
                //        oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + "," +
                //            DemandPrintAcs.CT_CsDmd_Kana + "," +
                //            DemandPrintAcs.CT_CsDmd_ClaimCode + "," +
                //            DemandPrintAcs.CT_CsDmd_CustomerCode;
                //        break;
                //    }
                //case 2:
                //    {
                //        // 担当者→得意先コード順(拠点コード,担当者コード,請求先コード,得意先コード)
                //        string employeeKey = "";

                //        switch (this._extraInfo_DemandTotal.CustomerAgentDivCd)
                //        {
                //            case 0:     // 顧客担当
                //                employeeKey = DemandPrintAcs.CT_CsDmd_CustomerAgentCd;
                //                break;
                //            case 1:     // 集金担当
                //                employeeKey = DemandPrintAcs.CT_CsDmd_BillCollecterCd;
                //                break;
                //            default:
                //                break;
                //        }

                //        oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + "," +
                //            employeeKey + "," +
                //            DemandPrintAcs.CT_CsDmd_ClaimCode + "," +
                //            DemandPrintAcs.CT_CsDmd_CustomerCode;
                //        break;
                //    }
                //case 3:
                //    {
                //        // 担当者→得意先カナ順(拠点コード,担当者コード,得意先カナ,請求先コード,得意先コード)
                //        string employeeKey = "";

                //        switch (this._extraInfo_DemandTotal.CustomerAgentDivCd)
                //        {
                //            case 0:     // 顧客担当
                //                employeeKey = DemandPrintAcs.CT_CsDmd_CustomerAgentCd;
                //                break;
                //            case 1:     // 集金担当
                //                employeeKey = DemandPrintAcs.CT_CsDmd_BillCollecterCd;
                //                break;
                //            default:
                //                break;
                //        }

                //        oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + "," +
                //            employeeKey + "," +
                //            DemandPrintAcs.CT_CsDmd_Kana + "," +
                //            DemandPrintAcs.CT_CsDmd_ClaimCode + "," +
                //            DemandPrintAcs.CT_CsDmd_CustomerCode;
                //        break;
                //    }
                case 0:
                    {
                        // 得意先順(拠点－得意先順)
                        oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + ","
                                   + DemandPrintAcs.CT_CsDmd_CustomerCode;
                        break;
                    }
                case 1:
                    {
                        // 担当者順(拠点－担当者－得意先順)
                        string employeeKey = "";

                        if ((int)this._extraInfo_DemandTotal.CustomerAgentDivCd == 0)
                        {
                            // 得意先担当
                            employeeKey = DemandPrintAcs.CT_CsDmd_CustomerAgentCd;
                        }
                        else
                        {
                            // 集金担当
                            employeeKey = DemandPrintAcs.CT_CsDmd_BillCollecterCd;
                        }

                        oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + ","
                                   + employeeKey + ","
                                   + DemandPrintAcs.CT_CsDmd_CustomerCode;
                        break;
                    }
                case 2:
                    {
                        // 地区順(拠点－地区－得意先順)
                        oderQuerry = DemandPrintAcs.CT_CsDmd_AddUpSecCode + ","
                                   + DemandPrintAcs.CT_CsDmd_SalesAreaCode + ","
                                   + DemandPrintAcs.CT_CsDmd_CustomerCode;
                        break;
                    }
                // 2008.09.08 30413 犬飼 ソート内容変更 <<<<<<END
            }

            return oderQuerry;
        }


        /// <summary>
        /// 印刷出力区分コンボ初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : 印刷出力区分コンボボックスの初期設定を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void InitialSettingOutCombo(TComboEditor control)
        {
            control.Items.Clear();
            for (int i = 0; i < outputCdNames.Length; i++)
            {
                control.Items.Add(i, outputCdNames[i]);
            }
            control.MaxDropDownItems = control.Items.Count;
        }

        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="control">チェック対象コントロール</param>
        /// <returns>true:チェックOK,false:チェックNG</returns>
        /// <remarks>
        /// <br>Note       : 日付の入力チェックを行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private bool InputDateEditCheack(TDateEdit control)
        {
            // 日付を数値型で取得
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // 日付未入力チェック
            if (date == 0) return false;

            // システムサポートチェック
            if (yy < 1900) return false;

            // 年・月・日別入力チェック
            switch (control.DateFormat)
            {
                // 年・月・日表示時
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;
                // 年・月    表示時
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;
                // 年        表示時
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;
                // 月・日　　表示時
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;
                // 月        表示時
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;
                // 日        表示時
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            // 単純日付妥当性チェック
            if (TDateTime.IsAvailableDate(control.GetDateTime()) == false) return false;

            return true;
        }

        /// <summary>
        /// 日付チェック処理呼び出し
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = _dateGetAcs.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// カラム列幅調整
        /// </summary>
        /// <remarks>
        /// <br>Note       : カラムの列幅を調整します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void ColumnPerformAutoResize()
        {
            if (AutoFillToGridColumn_CheckEditor.Checked == false)
            {
                for (int i = 0; i < this.DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns.Count; i++)
                {
                    this.DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                }
            }
        }

        /// <summary>
        /// 表示行合計計算処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 表示されているRowの合計を計算します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void CalculationTotalViewRow()
        {
            Int32 rpSlipCnt = 0;
            Int64 totalLastDmd = 0;
            Int64 totalDeposit = 0;
            Int64 totalSales = 0;
            Int64 totalTax = 0;
            Int64 totalDmd = 0;

            Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
                this.DEMANDLISTVIEW.Rows.GetFilteredInNonGroupByRows();

            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
            {
                // 2008.11.14 30413 犬飼 請求内訳が得意先の場合も集計対象とする >>>>>>START
                //if ((Boolean)_row.Cells[DemandPrintAcs.CT_CsDmd_DataType].Value)
                if (((Boolean)_row.Cells[DemandPrintAcs.CT_CsDmd_DataType].Value) ||
                    (this._extraInfo_DemandTotal.DmdDtl == 2))
                {
                    //rpSlipCnt += (Int32)_row.Cells[DemandPrintAcs.CT_CsDmd_TleDmdSlipTotalCnt].Value;
                    // 2008.11.18 30413 犬飼 前回請求金額→請求残高に変更 >>>>>>START
                    //totalLastDmd += (Int64)_row.Cells[DemandPrintAcs.CT_CsDmd_LastTimeDemand].Value;
                    totalLastDmd += (Int64)_row.Cells[DemandPrintAcs.CT_CsDmd_DemandBalance].Value;
                    // 2008.11.18 30413 犬飼 前回請求金額→請求残高に変更 <<<<<<END

                    totalDeposit += (Int64)_row.Cells[DemandPrintAcs.CT_CsDmd_ThisTimeDmdNrml].Value;
                    totalSales += (Int64)_row.Cells[DemandPrintAcs.CT_CsDmd_OfsThisTimeSales].Value;
                    totalTax += (Int64)_row.Cells[DemandPrintAcs.CT_CsDmd_OfsThisSalesTax].Value;
                    totalDmd += (Int64)_row.Cells[DemandPrintAcs.CT_CsDmd_AfCalDemandPrice].Value;
                }
                // 2008.11.14 30413 犬飼 請求内訳が得意先の場合も集計対象とする <<<<<<END
            }

            this.RpSlipCount_tNedit.SetInt(rpSlipCnt);
            this.TotalLastDmd_tNedit.SetValue(totalLastDmd);
            this.TotalDeposit_tNedit.SetValue(totalDeposit);

            // 総額表示方法
            if (mDemandPrintAcs.AllDefSetData != null && mDemandPrintAcs.AllDefSetData.TotalAmountDispWayCd == 0)
            {
                // 税抜き
                this.TotalSales_tNedit.SetValue(totalSales);
                this.TotalTax_tNedit.SetValue(totalTax);
            }
            else
            {
                // 税込み
                Int64 totalSalesInConsTax = totalSales + totalTax;
                this.TotalSales_tNedit.SetValue(totalSalesInConsTax);
                this.TotalTax_tNedit.Text = "(" + totalTax.ToString("#,##0") + ")";
            }

            this.TotalDmd_tNedit.SetValue(totalDmd);

            // 2009.01.28 30413 犬飼 請求内訳が得意先の場合は合計消費税をゼロとする >>>>>>START
            if (this._extraInfo_DemandTotal.DmdDtl == 2)
            {
                // 請求内訳が得意先
                this.TotalTax_tNedit.SetInt(0);
            }
            // 2009.01.28 30413 犬飼 請求内訳が得意先の場合は合計消費税をゼロとする <<<<<<END

        }

        /// <summary>
        /// ノードアイテム取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : ノードKEYよりItemを取得します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private PrintInfoItem NodeKeyToItem(string nodeKey)
        {
            PrintInfoItem item = new PrintInfoItem();

            if (nodeKey.Length > 0 && nodeKey != null)
            {
                // ノードに埋めたKEY（Guid)をGuid型に変換する
                GuidConverter gc = new GuidConverter();
                Guid wId = (Guid)gc.ConvertFromString(nodeKey);

                if (this._printHistoryList.ContainsKey(wId))
                {
                    item = (PrintInfoItem)this._printHistoryList[wId];
                }
                else
                {
                    item = null;
                }
            }
            else
            {
                item = null;
            }

            return item;
        }

        /// <summary>
        /// 最上位フォーム取得
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void GetTopForm()
        {
            // 最上位の親コントロールを取得する
            Control parent = this.Parent;

            while (parent != null)
            {
                if (parent.Parent == null) break;

                parent = parent.Parent;
            }

            if (parent != null)
            {
                if (parent is Form)
                {
                    this._topForm = (Form)parent;
                    this._topForm.SizeChanged += new EventHandler(TopForm_SizeChanged);
                }
            }
        }

        /// <summary>
        /// トップフォームサイズ変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopForm_SizeChanged(object sender, EventArgs e)
        {
            //this.AdjustExplorerBarExpand();  // 2007.10.15 hiktia del
        }

        /// <summary>
        /// エクスプローラーバー展開状態調整
        /// </summary>
        private void AdjustExplorerBarExpand()
        {
            if (this._topForm == null) return;

            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (this._topForm.Height > this._expandBaseHeigt)
            //{
            //    // トップフォームの高さが基準値より高い場合
            //    this._explorerBarExpanding = true;
            //    try
            //    {
            //        this.Extra_ultraExplorerBar.Groups[EXPLORERBAR_GROUP4_KEY].Expanded = true;

            //    }
            //    finally
            //    {
            //        this._explorerBarExpanding = false;
            //    }
            //}
            //else
            //{
            //    // トップフォームの高さが基準値より低い場合
            //    this._explorerBarExpanding = true;
            //    try
            //    {
            //        this.Extra_ultraExplorerBar.Groups[EXPLORERBAR_GROUP4_KEY].Expanded = false;
            //    }
            //    finally
            //    {
            //        this._explorerBarExpanding = false;
            //    }
            //}
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        }

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
        /// <br>Note       : 出力件数の設定を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, "MAKAU02012U", iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        // ADD 2009/02/27 請求書系フレーム対応：拠点範囲指定の追加 ---------->>>>>
        #region ◎　出力対象拠点の範囲の初期設定

        /// <summary>
        /// 出力対象拠点の範囲を指定するコントロールの初期設定を行います。
        /// </summary>
        /// <param name="loading">ロード中のフラグ</param>
        /// <remarks>
        /// <br>Note       : 請求書系フレーム対応</br>
        /// <br>Programmer : 30434 T.Kudoh</br>
        /// <br>Date       : 2000.02.27</br>
        /// </remarks>
        private void InitSectionRange()
        {
            #region <Guard Phrase/>

            if (this.Section_Tree.Nodes.Count.Equals(0)) return;

            #endregion  // <Guard Phrase/>

            // DEL 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ---------->>>>>
            #region 削除コード

            //// 開始拠点コードの初期値
            //string currentSectionCode = string.Empty;
            //string currentSectionName = string.Empty;
            //for (int i = 0; i < this.Section_Tree.Nodes.Count; i++)
            //{
            //    if (this.Section_Tree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
            //    {
            //        currentSectionCode = this.Section_Tree.Nodes[i].Key;
            //        currentSectionName = GetSectionName(currentSectionCode);
            //        break;
            //    }
            //}
            //this.tEdit_SectionCode_St.Text = currentSectionCode;
            //this.startRangeNameUltraTextEditor.Text = currentSectionName;

            //// 終了拠点コードの初期値
            //this.tEdit_SectionCode_Ed.Text = this.tEdit_SectionCode_St.Text;
            //this.endRangeNameUltraTextEditor.Text = this.startRangeNameUltraTextEditor.Text;

            #endregion // 削除コード
            // DEL 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ----------<<<<<
            // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ---------->>>>>
            SortedList<string, string> sortedSectionList = new SortedList<string, string>();
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode sectionNode in this.Section_Tree.Nodes)
            {
                if (sectionNode.CheckedState.Equals(CheckState.Checked))
                {
                    sortedSectionList.Add(sectionNode.Key, sectionNode.Text);
                }
            }
            if (sortedSectionList.Count.Equals(0))
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
                if (sortedSectionList.Keys[0].Trim().Equals(ALL_SECTION_CODE))
                {
                    this.tEdit_SectionCode_St.Text = string.Empty;
                    this.startRangeNameUltraTextEditor.Text = DEFAULT_START_SECTION_NAME;
                }

                // 終了拠点コードの初期値
                this.tEdit_SectionCode_Ed.Text = sortedSectionList.Keys[sortedSectionList.Count - 1].Trim();
                this.endRangeNameUltraTextEditor.Text = GetSectionName(sortedSectionList.Keys[sortedSectionList.Count - 1]);
                // 全社用の補正
                if (sortedSectionList.Keys[sortedSectionList.Count - 1].Trim().Equals(ALL_SECTION_CODE))
                {
                    this.tEdit_SectionCode_Ed.Text = string.Empty;
                    this.endRangeNameUltraTextEditor.Text = DEFAULT_END_SECTION_NAME;
                }
            }
            // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ----------<<<<<
        }

        /// <summary>
        /// 拠点名称を取得します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 請求書系フレーム対応</br>
        /// <br>Programmer : 30434 T.Kudoh</br>
        /// <br>Date       : 2008.02.27</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            try
            {
                SecInfoSet secInfoSet = (SecInfoSet)this.mDemandPrintAcs.SectionTable[sectionCode.PadRight(6)];
                return secInfoSet.SectionGuideNm;
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion  // ◎　出力対象拠点の範囲の初期設定

        #region ◎出力対象拠点の範囲を拠点ツリーに展開

        // 全社拠点コード
        private const string ALL_SECTION_CODE   = "00";
        private const string ALL_SECTION_NAME   = "全社";
        private const string SECTION_CODE_FORMAT= "00";

        // 拠点コードの範囲
        private const string DEFAULT_START_SECTION_NAME = "最初から";
        private const string DEFAULT_END_SECTION_NAME   = "最後まで";
        private const int MIN_SECTION_CODE = 1;
        private const int MAX_SECTION_CODE = 99;

        /// <summary>
        /// 開始拠点コードのテキストボックスのLeaveイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tEdit_SectionCode_St_Leave(object sender, EventArgs e)
        {
            SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);

            if (_currentResultCode.Equals(ResultCode.StartSectionCodeHasError))
            {
                this.tEdit_SectionCode_St.Focus();
            }
        }

        /// <summary>
        /// 終了拠点コードのテキストボックスのLeaveイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tEdit_SectionCode_Ed_Leave(object sender, EventArgs e)
        {
            SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);

            // HACK:開始拠点コードへ戻る
            //if (_focusStartRangeFlag)
            //{
            //    _focusStartRangeFlag = false;
            //    this.tEdit_SectionCode_St.Focus();
            //}

            // ADD 2009/03/18 不具合対応[12420]：出力拠点の入力チェックの不正 ---------->>>>>
            // フォーカス遷移
            if (_currentResultCode.Equals(ResultCode.StartSectionCodeHasError))
            {
                _currentResultCode = ResultCode.Normal;
                this.tEdit_SectionCode_St.Focus();
            }
            else
            {
                this.AddUpDate_tDateEdit.Focus();
            }
            // ADD 2009/03/18 不具合対応[12420]：出力拠点の入力チェックの不正 ----------<<<<<
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
                this.tEdit_SectionCode_St.Text = int.Parse(ALL_SECTION_CODE).ToString(SECTION_CODE_FORMAT);
                this.startRangeNameUltraTextEditor.Text = ALL_SECTION_NAME;

                // 終了
                this.tEdit_SectionCode_Ed.Text = int.Parse(ALL_SECTION_CODE).ToString(SECTION_CODE_FORMAT);
                this.endRangeNameUltraTextEditor.Text = ALL_SECTION_NAME;

                return;
            }

            // 任意
            string sectionCode = int.Parse(sectionCodeUI.Text.Trim()).ToString(SECTION_CODE_FORMAT);
            sectionCodeUI.Text = sectionCode;
            sectionNameUI.Text = GetSectionName(sectionCode);
        }

        /// <summary>
        /// 拠点を選択するツリーのノードのキーを取得します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns><c>sectionCode.PadRight(6)</c></returns>
        private static string GetSectionTreeNodeKey(string sectionCode)
        {
            int sectionCodeNumber = int.Parse(sectionCode);
            if (sectionCodeNumber.Equals(0))
            {
                return sectionCode.Trim();
            }
            return sectionCode.PadRight(6);
        }

        /// <summary>
        /// 結果コード列挙体
        /// </summary>
        private enum ResultCode : int
        {
            /// <summary>正常</summary>
            Normal,
            /// <summary>エラー</summary>
            Error,
            /// <summary>開始拠点コードにエラー</summary>
            StartSectionCodeHasError
        }

        /// <summary>現在の結果コード</summary>
        private ResultCode _currentResultCode;

        /// <summary>
        /// 拠点ツリーのノードをチェック状態にします。
        /// </summary>
        /// <param name="startSectionCode">開始拠点コード</param>
        /// <param name="endSectionCode">終了拠点コード</param>
        /// <remarks>
        /// <br>Note　　　  : 請求書系フレーム対応</br>
        /// <br>Programmer  : 30434 T.Kudoh</br>
        /// <br>Date        : 2009.02.27</br>
        /// </remarks>
        /// <returns>結果コード（<c>0</c>:正常）</returns>
        private int CheckSectionTreeNode(
            string startSectionCode,
            string endSectionCode
        )
        {
            #region 開始拠点コード値

            int startCode = MIN_SECTION_CODE;
            if (!string.IsNullOrEmpty(startSectionCode))
            {
                startCode = int.Parse(startSectionCode);
                if (startCode < 0) startCode = MIN_SECTION_CODE;
            }
            else
            {
                if ((startSectionCode == null) || (startSectionCode.Trim() == ""))
                {
                    startCode = 0;
                }
            }

            #endregion  // 開始拠点コード値

            #region 終了拠点コード値

            int endCode = MAX_SECTION_CODE;
            if (!string.IsNullOrEmpty(endSectionCode))
            {
                endCode = int.Parse(endSectionCode);
                if (endCode > MAX_SECTION_CODE) endCode = MAX_SECTION_CODE;
            }
            else
            {
                if ((endSectionCode == null) || (endSectionCode.Trim() == ""))
                {
                    endCode = 99;
                }
            }

            #endregion  // 終了拠点コード値

            // 開始拠点コードが終了拠点コードより大きな値
            if (startCode > endCode)
            {
                const string MSG = "開始拠点コードが終了拠点コードより大きな値です。";  // LITERAL:
                StatusBarInfoPrinted(this, new PrintStatusBarEventArgs(MSG));
                return (int)ResultCode.StartSectionCodeHasError;
            }
            else
            {
                StatusBarInfoPrinted(this, new PrintStatusBarEventArgs());
            }

            #region 強制的に全拠点を未選択にする

            for (int i = 0; i < this.Section_Tree.Nodes.Count; i++)
            {
                // 強制的に未選択にする
                if (this.Section_Tree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
                {
                    this.Section_Tree.Nodes[i].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                }
            }

            #endregion  // 強制的に全拠点を未選択にする

            if (((string.IsNullOrEmpty(startSectionCode)) || (int.Parse(startSectionCode) == 0)) &&
                ((string.IsNullOrEmpty(endSectionCode)) || (int.Parse(endSectionCode) == 0)))
            {
                // 全社選択
                this.Section_Tree.Nodes[GetSectionTreeNodeKey(ALL_SECTION_CODE)].CheckedState = CheckState.Checked;
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

                for (int i = 0; i < this.Section_Tree.Nodes.Count; i++)
                {
                    // 強制的に未選択にする
                    if (this.Section_Tree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
                    {
                        this.Section_Tree.Nodes[i].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                    }

                    // 開始拠点コード値と終了拠点コード値の範囲内なら、選択する（全社指定の場合、全社を選択する）
                    int sectionCode = int.Parse(this.Section_Tree.Nodes[i].Key.Trim());
                    if ((startCode <= sectionCode) && (sectionCode <= endCode))
                    {
                        if (!sectionCode.Equals(int.Parse(ALL_SECTION_CODE)))
                        {
                            string key = GetSectionTreeNodeKey(sectionCode.ToString(SECTION_CODE_FORMAT));
                            if (!string.IsNullOrEmpty(GetSectionName(key)))
                            {
                                this.Section_Tree.Nodes[key].CheckedState = System.Windows.Forms.CheckState.Checked;
                            }
                        }
                        else
                        {
                            this.Section_Tree.Nodes[ALL_SECTION_CODE].CheckedState = System.Windows.Forms.CheckState.Checked;
                        }
                    }   // if ((startCode <= sectionCode) && (sectionCode <= endCode))
                }   // for (int i = 0; i < this.Section_Tree.Nodes.Count; i++)
            }

            return (int)ResultCode.Normal;
        }

        #endregion  // ◎出力対象拠点の範囲を拠点ツリーに展開
        // ADD 2008/02/27 請求書系フレーム対応：拠点範囲指定の追加 ----------<<<<<

        // ===================================================================================== //
        // コントロールイベント
        // ===================================================================================== //
        #region Control Event
        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 画面がロードされた際、発生するイベントです。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void MAKAU02012UA_Load(object sender, System.EventArgs e)
        {

            // 最上位フォーム取得
            this.GetTopForm();

            // 呼出モードにより表示・非表示変化項目を全て非表示に
            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //this.EmployeeNext_CheckEditor.Visible = false;
            //this.EmployeeNext_Label.Visible = false;
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            //this.BillTableOutPut_Label.Visible = false;
            //this.BillTableOutPut_tComboEditor.Visible = false;
            //this.TotalBillOutputTitle_Label.Visible = false;
            //this.TotalBillOutput_tComboEditor.Visible = false;
            //this.DetailBillOutput_Label.Visible = false;
            //this.DetailBillOutput_tComboEditor.Visible = false;

            // 呼出モードにより非表示項目を設定
            switch (this._callMode)
            {
                // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                //case START_MODE_ALL:		// 全帳票
                // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                case START_MODE_DEFAULT_LIST:		// 請求一覧表
                case START_MODE_DEFAULT_TOTAL:		// 合計請求書
                case START_MODE_DEFAULT_DETAIL:		// 明細請求書
                case START_MODE_DEFAULT_DETAILSLIP:	// 明細請求書(伝票) // 2007.10.15 hikita add 
                case START_MODE_DEFAULT_RECEIPT:    // 領収書           // 2007.10.15 hikita add 
                //case START_MODE_DEMANDHAND:		// 手入力合計請求書
                //    {
                //        this.Main_ExplorerBar.Groups[EXPLORERBAR_HISTORYLIST].Visible = true;

                //        this.EmployeeNext_CheckEditor.Visible = true;
                //        this.EmployeeNext_Label.Visible = true;
                //        this.BillTableOutPut_Label.Visible = true;
                //        this.BillTableOutPut_tComboEditor.Visible = true;
                //        this.TotalBillOutputTitle_Label.Visible = true;
                //        this.TotalBillOutput_tComboEditor.Visible = true;
                //        this.DetailBillOutput_Label.Visible = true;
                //        this.DetailBillOutput_tComboEditor.Visible = true;

                //        break;
                //    }
                case START_MODE_DEMANDLIST:	// 請求一覧表
                    {
                        this.Main_ExplorerBar.Groups[EXPLORERBAR_HISTORYLIST].Visible = true;
                        // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                        //this.EmployeeNext_CheckEditor.Visible = true;
                        //this.EmployeeNext_Label.Visible = true;
                        // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                        //this.BillTableOutPut_Label.Visible = true;
                        //this.BillTableOutPut_tComboEditor.Visible = true;
                        break;
                    }
                case START_MODE_DEMANDTOTAL:	// 合計請求書
                    {
                        this.Main_ExplorerBar.Groups[EXPLORERBAR_HISTORYLIST].Visible = false;

                        //this.TotalBillOutputTitle_Label.Visible = true;
                        //this.TotalBillOutput_tComboEditor.Visible = true;

                        //// 表示位置を先頭に
                        //this.TotalBillOutputTitle_Label.Location = this.BillTableOutPut_Label.Location;
                        //this.TotalBillOutput_tComboEditor.Location = this.BillTableOutPut_tComboEditor.Location;

                        break;
                    }
                case START_MODE_DEMANDDETAIL:	// 明細請求書
                    {
                        this.Main_ExplorerBar.Groups[EXPLORERBAR_HISTORYLIST].Visible = false;

                        //this.DetailBillOutput_Label.Visible = true;
                        //this.DetailBillOutput_tComboEditor.Visible = true;

                        //// 表示位置を先頭に
                        //this.DetailBillOutput_Label.Location = this.BillTableOutPut_Label.Location;
                        //this.DetailBillOutput_tComboEditor.Location = this.BillTableOutPut_tComboEditor.Location;
                        break;
                    }
                // 2007.10.15 hikita add start ------------------------------------------------>>
                case START_MODE_DEMANDDETAILSLIP:// 明細請求書(伝票)
                    {
                        this.Main_ExplorerBar.Groups[EXPLORERBAR_HISTORYLIST].Visible = false;
                        break;
                    }
                case START_MODE_DEMANDRECEIPT:	// 領収書
                    {
                        this.Main_ExplorerBar.Groups[EXPLORERBAR_HISTORYLIST].Visible = false;
                        break;
                    }
                // 2007.10.15 hikita add end --------------------------------------------------<<
                default:
                    break;
            }

            Initial_Timer.Enabled = true;
        }

        #region ◎ MAKAU02012UA_FormClosing Event
        /// <summary>
        /// MAKAU02012UA_FormClosing Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: ユーザーがフォームを閉じる時に発生する</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2009.01.14</br>
        /// </remarks>
        private void MAKAU02012UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ＵＩ入力保存コンポーネント動作のため追加
        }
        #endregion

        /// <summary>
        /// 初期タイマーイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 初期処理を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // アイコン設定
            this.Select_Button.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.PRINTOUT];
            this.UnSelect_Button.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.NOTPRINTOUT];

            // 初期設定データ読込
            int status = this.InitalDataRead();
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.Close();
                return;
            }

            // 拠点オプション有無チェック
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
            {
                this._isOptSection = true;
            }
            else
            {
                this._isOptSection = false;
#if CHG20060421
                this._demandSectionCode = DemandPrintAcs.CT_AllSectionCode;
#else
#if CHG20060418
				this._demandSectionCode = this._loginEmployee.BelongSectionCode;
#else
				this._demandSectionCode = this._loginEmployee.BelongSectionCode.TrimEnd();
#endif
#endif
            }

            mDemandPrintAcs.SectionOption = this._isOptSection;
#if CHG20060418
            mDemandPrintAcs.OwnSectionCd = this._loginEmployee.BelongSectionCode;
#else
			mDemandPrintAcs.OwnSectionCd  = this._loginEmployee.BelongSectionCode.TrimEnd();
#endif

            // 拠点情報設定
            if (this._isOptSection)
            {
                // 請求設定拠点取得
                string billsettingSecCode;
#if CHG20060418
                mDemandPrintAcs.GetOwnSeCtrlCode(_loginEmployee.BelongSectionCode, SecInfoAcs.CtrlFuncCode.BillSettingSecCd, out billsettingSecCode);
                this._demandSectionCode = billsettingSecCode;
#else
				mDemandPrintAcs.GetOwnSeCtrlCode(_loginEmployee.BelongSectionCode.TrimEnd(),SecInfoAcs.CtrlFuncCode.BillSettingSecCd,out billsettingSecCode);
				this._demandSectionCode = billsettingSecCode.Trim(); 
#endif
                // --- UPD m.suzuki 2010/07/22 ---------->>>>>
                //// 本社機能有無
                //this._isMainOfficeFunc = mDemandPrintAcs.CheckMainOfficeFunc(_loginEmployee.BelongSectionCode);
                this._isMainOfficeFunc = true;
                // --- UPD m.suzuki 2010/07/22 ----------<<<<<

                if (this._isMainOfficeFunc)
                {
                    this.Main_ExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = true;
                    this.SettingSectonListForm();

                    // DEL 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ---------->>>>>
                    //// 請求設定拠点にデフォルトチェック？
                    //if (this.mDemandPrintAcs.SectionTable.ContainsKey(this._demandSectionCode))
                    //{
                    //    this.Section_Tree.Nodes[this._demandSectionCode].CheckedState = System.Windows.Forms.CheckState.Checked;
                    //}
                    // DEL 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ----------<<<<<
                    // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ---------->>>>>
                    // 前回選択していた拠点を設定　※請求一覧で起動している場合のみ
                    if (!SectionTreeHelper.ImportCheckedSectionCode(this.Section_Tree, IsDemandListMode()))
                    {
                        // 請求設定拠点にデフォルトチェック？
                        if (this.mDemandPrintAcs.SectionTable.ContainsKey(this._demandSectionCode))
                        {
                            this.Section_Tree.Nodes[this._demandSectionCode].CheckedState = System.Windows.Forms.CheckState.Checked;
                        }
                    }
                    // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ----------<<<<<
                }
            }

            // 拠点範囲指定を初期化
            InitSectionRange(); // ADD 2008/02/27 請求書系フレーム対応：拠点範囲指定の追加

            // ドックマネージャー初期設定
            if (this._isOptSection)
            {
                this.Main_DockManager.ControlPanes[DOCK_PANE0_KEY].Text = "拠点設定・帳票履歴";
            }
            else
            {
                this.Main_DockManager.ControlPanes[DOCK_PANE0_KEY].Text = "帳票履歴";
            }

            // PDF履歴情報設定
            this.SettingRecentPdfList();

            // 出力区分コンポボックス設定
            this.InitialSettingOutCombo(this.OutPutPriceCond_tComboEditor);

            // 画面初期情報設定
            this.InitialScreenSetting();

            // グリッドのデータソースを、請求書印刷アクセスクラスのデータビューに設定する。
            DEMANDLISTVIEW.DataSource = mDemandPrintAcs.CustDmdPrcDataView;

            // エクスプローラーバー調節
            // this.AdjustExplorerBarExpand(); // 2007.10.15 hikita del

            // フォーカス初期設定
            this.AddUpDate_tDateEdit.Focus();
        }

        /// <summary>
        /// 締日変更イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : 締日の値が変更された際に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void AddUpDate_tDateEdit_ValueChanged(object sender, System.EventArgs e)
        {
            if (!this._eventDoFlag) return;
            if (this._eventDateChange) return;

            this._eventDateChange = true;

            try
            {
                int dd = this.AddUpDate_tDateEdit.GetDateDay();

                // 出力帳票年月有効性チェック
                if ((dd <= 0) || (dd >= 32) || (!InputDateEditCheack(this.AddUpDate_tDateEdit)))
                {
                    this.AddUpDate_tDateEdit.Clear();
                    // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                    //this.TotalDay_tNedit.Clear();
                    // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                    return;
                }

                int yy = this.AddUpDate_tDateEdit.GetDateYear();
                int mm = this.AddUpDate_tDateEdit.GetDateMonth();

                // 28日以降は締日を末日とする
                if (dd >= 28)
                {
                    dd = TDateTime.GetLastDate(yy, mm);
                    // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                    //LastDay_CheckEditor.Enabled = true;
                    // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                }
                else
                {
                    // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                    //LastDay_CheckEditor.Enabled = false;
                    // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
                }

                int date = yy * 10000 + mm * 100 + dd;
                this.AddUpDate_tDateEdit.SetLongDate(date);
                // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                //this.TotalDay_tNedit.SetInt(dd);
                // 2008.09.05 30413 犬飼 削除項目 <<<<<<END

            }
            finally
            {
                this._eventDateChange = false;
            }

        }

        // 2008.09.05 30413 犬飼 未使用メソッド削除 >>>>>>START
        #region 得意先締日変更イベント
        ///// <summary>
        ///// 得意先締日変更イベント
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        ///// <remarks>
        ///// <br>Note        : 得意先締日の値が変更された際に発生します。</br>
        ///// <br>Programmer : 980023 飯谷 耕平</br>
        ///// <br>Date       : 2007.06.30</br>
        ///// </remarks>
        //private void TotalDay_tNedit_ValueChanged(object sender, System.EventArgs e)
        //{
        //    if (!this._eventDoFlag) return;
        //    if (this._eventDateChange) return;

        //    this._eventDateChange = true;

        //    try
        //    {
        //        int dd = TotalDay_tNedit.GetInt();

        //        // 出力帳票年月有効性チェック
        //        if (!InputDateEditCheack(this.AddUpDate_tDateEdit))
        //        {
        //            return;
        //        }

        //        int date = this.AddUpDate_tDateEdit.GetLongDate();
        //        int yy = date / 10000;
        //        int mm = date / 100 % 100;

        //        // 28日以降は締日を末日とする
        //        if (dd >= 28)
        //        {
        //            dd = TDateTime.GetLastDate(yy, mm);
        //        }
        //        else
        //        {
        //            LastDay_CheckEditor.Enabled = false;

        //        }
        //    }
        //    finally
        //    {
        //        this._eventDateChange = false;
        //    }
        //}
        #endregion
        // 2008.09.05 30413 犬飼 未使用メソッド削除 <<<<<<END

        // 2008.10.17 30413 犬飼 未使用メソッド削除 >>>>>>START
        #region 得意先コードフォーカス喪失イベント
        ///// <summary>
        ///// 得意先コードフォーカス喪失イベント
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        ///// <remarks>
        ///// <br>Note        : </br>
        ///// <br>Programmer : 980023 飯谷 耕平</br>
        ///// <br>Date       : 2007.06.30</br>
        ///// </remarks>
        //private void CustomerCode_Nedit_Leave(object sender, System.EventArgs e)
        //{
        //    // 空白か0の場合は初期値をセット
        //    if ((((TNedit)sender).DataText == "") || (((TNedit)sender).GetInt() == 0))
        //    {
        //        if (((TNedit)sender).Equals(this.tNedit_CustomerCode_St))
        //        {
        //            ((TNedit)sender).SetInt(0);
        //        }
        //        else if (((TNedit)sender).Equals(this.tNedit_CustomerCode_Ed))
        //        {
        //            ((TNedit)sender).SetInt(0);
        //        }
        //    }
        //}
        #endregion
        // 2008.10.17 30413 犬飼 未使用メソッド削除 <<<<<<END

        /// <summary>
        /// 出力順コンボ選択変更イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : </br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void PrintOder_tComboEditor_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            int printOder = Convert.ToInt32(PrintOder_tComboEditor.SelectedItem.DataValue);

            // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
            //if (printOder == 2 || printOder == 3)
            //{
            //    EmployeeNext_CheckEditor.Enabled = true;
            //}
            //else
            //{
            //    EmployeeNext_CheckEditor.Enabled = false;
            //}
            // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
        }

        // DEL 2009/03/03 請求書系フレーム対応：拠点範囲指定の追加 ---------->>>>>
        #region 削除コード
        ///// <summary>
        ///// フォーカス制御イベント
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        ///// <remarks>
        ///// <br>Note        : </br>
        ///// <br>Programmer : 980023 飯谷 耕平</br>
        ///// <br>Date       : 2007.06.30</br>
        ///// </remarks>
        //private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        //{

        //}
        #endregion
        // DEL 2008/03/03 請求書系フレーム対応：拠点範囲指定の追加 ----------<<<<<

        /// <summary>
        /// 拠点選択チェックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : checkedStateプロパティが変更された後に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void Section_Tree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            if (this._nodeCheckEventDo) return;

            // イベント中フラグON
            this._nodeCheckEventDo = true;

            try
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode utnAll =
                  this.Section_Tree.GetNodeByKey(DemandPrintAcs.CT_AllSectionCode);

                // ”全社”指定された
                if (e.TreeNode.Key.ToString().Equals(DemandPrintAcs.CT_AllSectionCode))
                {
                    // 選択
                    if (utnAll.CheckedState == CheckState.Checked)
                    {
                        // その他の項目のチェックをはずす
                        foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_Tree.Nodes)
                        {
                            if (utn.Key.Equals(DemandPrintAcs.CT_AllSectionCode) == false)
                            {
                                utn.CheckedState = CheckState.Unchecked;
                            }
                        }
                    }
                }
                // その他拠点
                else
                {
                    if (utnAll.CheckedState == CheckState.Checked)
                    {
                        utnAll.CheckedState = CheckState.Unchecked;

                    }
                }
            }
            finally
            {
                e.TreeNode.Selected = true;
                this._nodeCheckEventDo = false;
            }
        }

        /// <summary>
        /// タブコントロールアクティブタブ変更イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note        : ActiveなTabが変更された後に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void Main_TabControl_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            switch (e.Tab.Key)
            {
                case TABCONTROL_EXTRAINFOSCREEN_KEY:
                    {
                        if (!this.Main_DockManager.ControlPanes[0].Pinned)
                            this.Main_DockManager.ControlPanes[0].Pin();
                        break;
                    }
                case TABCONTROL_EXTRADATASCREEN_KEY:
                    {
                        if (this.Main_DockManager.ControlPanes[0].Pinned)
                            this.Main_DockManager.ControlPanes[0].Unpin();

                        if (!this.Main_DockManager.ControlPanes[0].Pinned && this.Main_DockManager.ControlPanes[0].Manager.FlyoutPane != null)
                            this.Main_DockManager.ControlPanes[0].Manager.FlyIn(true);

                        break;
                    }
            }
        }

        /// <summary>
        /// 列サイズチェックボックスチェックチェンジイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : 列サイズチェックボックスのチェック状態の変更イベント処理を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void AutoFillToGridColumn_CheckEditor_CheckedChanged(object sender, System.EventArgs e)
        {

#if CLR2
            if (this.AutoFillToGridColumn_CheckEditor.Checked)
            {
                // 列幅をオートに設定
                this.DEMANDLISTVIEW.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.DEMANDLISTVIEW.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            }
#else
			this.DEMANDLISTVIEW.DisplayLayout.AutoFitColumns = this.AutoFillToGridColumn_CheckEditor.Checked;
#endif

            this.DEMANDLISTVIEW.Refresh();
            this.ColumnPerformAutoResize();
        }

        /// <summary>
        /// グリッドレイアウト初期化 イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : データソースからコントロールにデータがロードされるときなど、
        ///                   表示レイアウトが初期化されるときに発生します。 </br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void DEMANDLISTVIEW_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // グリッド設定
            this.SettingGrid();
            // スクロールヒントの表示フィールド
            //e.Layout.Bands[0].ScrollTipField = DemandPrintAcs.CT_CsDmd_Name;
            e.Layout.Bands[0].ScrollTipField = DemandPrintAcs.CT_CsDmd_AddUpSecCode;
        }

        /// <summary>
        /// グリッドクリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : 一覧グリッドがクリックされた際に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void DEMANDLISTVIEW_Click(object sender, System.EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // マウスポインタがグリッドのどの位置にあるかを判定する
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElementを取得する。
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // マウスポインターが列のヘッダ上にあるかチェック。
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // マウスポインターが行の上にあるかチェック。
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow != null)
            {
                //          int uniqueID = (int)objRow.Cells[DemandPrintAcs.CT_CsDmd_UniqueID].Value;
                //          this.mDemandPrintAcs.SelectedPrintRow(uniqueID);
                // マウスポインターが印刷有無セル上にあるか？
                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                  (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
                if (objCell != null)
                {
                    // 印刷フラグ列
                    if (objCell.Column.Key == DemandPrintAcs.CT_CsDmd_PrintFlag)
                    {
                        int uniqueID = (int)objRow.Cells[DemandPrintAcs.CT_CsDmd_UniqueID].Value;
                        this.mDemandPrintAcs.SelectedPrintRow(uniqueID);
                    }
                }

            }
        }

        /// <summary>
        /// グリッド内でのキーダウンイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : データグリッドキーダウンイベント処理を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void DEMANDLISTVIEW_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                // スペースキー
                case Keys.Space:
                    Infragistics.Win.UltraWinGrid.UltraGridRow _row = this.DEMANDLISTVIEW.ActiveRow;

                    if (_row != null)
                    {
                        int uniqueID = (int)_row.Cells[DemandPrintAcs.CT_CsDmd_UniqueID].Value;
                        this.mDemandPrintAcs.SelectedPrintRow(uniqueID);
                        e.Handled = true;

                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// グリッド行フィルター変更イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : グリッドの行処理を行います。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void DEMANDLISTVIEW_AfterRowFilterChanged(object sender, Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs e)
        {
            // 合計金額計算
            this.CalculationTotalViewRow();
        }

        /// <summary>
        /// 選択・解除ボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : 選択・解除ボタンがクリックされた際に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void Select_Button_Click(object sender, System.EventArgs e)
        {
            bool selected = false;

            if (sender == UnSelect_Button)
            {
                selected = false;
            }
            else if (sender == Select_Button)
            {
                selected = true; ;
            }

            // フィルター除外行を取得      
            Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
                this.DEMANDLISTVIEW.Rows.GetFilteredInNonGroupByRows();

            // 表示行は存在するか？
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
            {
                int uniqueID = (int)_row.Cells[DemandPrintAcs.CT_CsDmd_UniqueID].Value;
                this.mDemandPrintAcs.SelectedPrintRow(uniqueID, selected);
            }
        }

        /// <summary>
        /// 行フィルタードロップダウン前イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : 行フィルタードロップダウンをされる前に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void DEMANDLISTVIEW_BeforeRowFilterDropDown(object sender, Infragistics.Win.UltraWinGrid.BeforeRowFilterDropDownEventArgs e)
        {
            switch (e.Column.Key)
            {
                case DemandPrintAcs.CT_CsDmd_PrintFlag:
                    {

                        // フィルタードロップダウンから、「True」「False」を「印刷する」「印刷しない」に変更します
                        for (int i = e.ValueList.ValueListItems.Count - 1; i >= 0; i--)
                        {
                            if (e.ValueList.ValueListItems[i].DisplayText.Equals("True"))
                                e.ValueList.ValueListItems[i].DisplayText = "印刷する";

                            if (e.ValueList.ValueListItems[i].DisplayText.Equals("False"))
                                e.ValueList.ValueListItems[i].DisplayText = "印刷しない";
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        /// <summary>
        /// エクスプローラーバーグループ縮小前イベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : UltraExplorerBarGroupが縮小される前にに発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (this._explorerBarExpanding) return;

            this._explorerBarExpanding = true;

            try
            {
                e.Cancel = true;
                // 2008.09.05 30413 犬飼 削除項目 >>>>>>START
                //if (!e.Group.Key.Equals(EXPLORERBAR_GROUP4_KEY))
                //{
                //    e.Cancel = true;
                //}
                // 2008.09.05 30413 犬飼 削除項目 <<<<<<END
            }
            finally
            {
                this._explorerBarExpanding = false;
            }
        }

        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroupが展開される前に発生する。</br>
        /// <br>Programmer	: 30413 犬飼</br>
        /// <br>Date		: 2008.11.14</br>
        /// </remarks>
        private void Extra_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// スケジュールガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : スケジュールガイドボタンがクリックされた際に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void ScheduleGide_Button_Click(object sender, System.EventArgs e)
        {
            //Broadleaf.Windows.Forms.SFUKK06210UA scheduleGuide = new SFUKK06210UA();
            //DialogResult dr;

            //// 選択日付
            //int selectedDate = 0;

            //if (AddUpDate_tDateEdit.GetLongDate() != 0)
            //{
            //    // 表示開始期間
            //    int targetStart = TDateTime.DateTimeToLongDate(this.AddUpDate_tDateEdit.GetDateTime().AddMonths(-1));
            //    targetStart = targetStart / 100;
            //    // 表示終了期間
            //    int targetEnd = TDateTime.DateTimeToLongDate(this.AddUpDate_tDateEdit.GetDateTime());
            //    targetEnd = targetEnd / 100;

            //    // ガイド起動
            //    dr = scheduleGuide.ScheduleGuideShow(this._enterpriseCoode, targetStart, targetEnd, this.AddUpDate_tDateEdit.GetLongDate(), ref selectedDate);
            //}
            //else
            //{
            //    // ガイド起動
            //    dr = scheduleGuide.ScheduleGuideShow(this._enterpriseCoode, ref selectedDate);
            //}

            //if (dr == DialogResult.OK && selectedDate != 0)
            //{
            //    this.AddUpDate_tDateEdit.SetLongDate(selectedDate);
            //}
        }
        /// <summary>
        /// 出力履歴ツリーMouseMoveイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : 出力履歴ツリー上でマウス移動された際に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void History_Tree_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.History_Tree != null)
            {
                Infragistics.Win.UltraWinTree.UltraTree ut = (Infragistics.Win.UltraWinTree.UltraTree)sender;
                //マウスポインタのあるアイテムを取得
                Infragistics.Win.UltraWinTree.UltraTreeNode Utn = ut.GetNodeFromPoint(e.X, e.Y);
                //ポイントされているアイテムが変わった時
                if (Utn != _lastUltraTreeNode)
                {
                    // ToolTipがActiveな場合、Active解除
                    if (History_ToolTip.Active)
                        History_ToolTip.Active = false;
                    if (Utn != null)
                    {
                        // ポイントされているノードの情報をコレクションから取得
                        PrintInfoItem Itm = new PrintInfoItem();
                        Itm = NodeKeyToItem(Utn.Key);
                        if (Itm != null)
                        {
                            //ToolTipのテキストを設定する
                            History_ToolTip.SetToolTip(ut, Itm.PrintDetailName + "  発行者：" + Itm.LoginWorkerName);
                            //ToolTipを再びアクティブにする
                            History_ToolTip.Active = true;
                        }
                    }
                    // ポイントされているノードを記憶する
                    _lastUltraTreeNode = Utn;
                }
            }

        }

        /// <summary>
        /// 出力履歴コンテキストメニューアイテムクリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : コンテキストメニューアイテムがクリックされた際に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void menuItem1_Click(object sender, System.EventArgs e)
        {

            if (this._lastUltraTreeNode != null)
            {
                PrintInfoItem itm = new PrintInfoItem();
                itm = NodeKeyToItem(this._lastUltraTreeNode.Key);

                if (itm != null)
                {

                    string message = "";
                    if (!mPdfHistoryControl.DeletePrintHistoryList(itm.PrintKey, itm.PdfFileName, out message))
                    {
                        TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        "履歴の削除に失敗しました。\r\n" + message,
                                        -1,
                          MessageBoxButtons.OK,
                          MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        /// <summary>
        /// 出力履歴コンテキストメニューアイテムクリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント引数</param>
        /// <remarks>
        /// <br>Note       : コンテキストメニューアイテムがクリックされた際に発生します。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            if (this._lastUltraTreeNode != null)
            {
                PrintInfoItem itm = new PrintInfoItem();
                itm = NodeKeyToItem(this._lastUltraTreeNode.Key);

                if (itm != null)
                {
                    PdfHistoryControlFuncParam param = new PdfHistoryControlFuncParam();
                    param.Keys = new string[] { itm.PrintKey };
                    param.LoginEmployeeCode = this._loginEmployee.EmployeeCode;
                    param.StartDate = DateTime.MinValue;
                    param.EndDate = itm.PrintOutDateTime;

                    string message = "";
                    if (!this.mPdfHistoryControl.DeletePrintHistoryList(param, out message))
                    {
                        TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            "履歴の削除に失敗しました。\r\n" + message,
                            -1,
                            MessageBoxButtons.OK,
                            MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        /// <summary>
        /// 出力履歴ツリークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 出力履歴ツリーのノードがクリックされた時に発生するイベントです。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void History_Tree_MouseClick(object sender, MouseEventArgs e)
        {
            // 右クリック時にノードを選択してコンテキストメニューを表示する
            if (e.Button == MouseButtons.Right)
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode wkNode = this.History_Tree.GetNodeFromPoint(e.Location);

                // ノードを取得？
                if (wkNode != null)
                {
                    wkNode.Selected = true;
                    this.History_Tree.ActiveNode = wkNode;

                    // 帳票種別ノード(親グループノード)の場合はコンテキストメニューを表示しない
                    if (wkNode.Level > 0)
                    {
                        // コンテキストメニュー表示
                        this.contextMenu1.Show(this.History_Tree, e.Location);
                    }
                }
            }
        }

        /// <summary>
        /// 出力履歴ツリーダブルクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 出力履歴ツリーのノードがダブルクリックされた時に発生するイベントです。</br>
        /// <br>Programmer : 980023 飯谷 耕平</br>
        /// <br>Date       : 2007.06.30</br>
        /// </remarks>
        private void History_Tree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PrintInfoItem Itm = new PrintInfoItem();

            // 左ダブルクリックのみ対応
            if (e.Button != MouseButtons.Left) return;

            // ノードを１個以上、選択しているか？
            if (this.History_Tree.SelectedNodes.Count > 0)
            {
                // ダブルクリック位置にノードがあるか？
                if (this.History_Tree.GetNodeFromPoint(e.Location) == null) return;

                // 選択されたノードの情報をコレクションから取得する
                Itm = NodeKeyToItem(this.History_Tree.SelectedNodes[0].Key);
                if (Itm != null)
                {
                    // デリゲート登録されているか？
                    if (SelectedPdfNodeEvent != null)
                    {
                        // デリゲートされているイベントを起動する
                        SelectedPdfNodeEvent(Itm.PrintKey, Itm.PrintName, Itm.PdfFileName);
                    }
                }
            }
        }

        // 2007.10.15 hikita del start --------------------------------------------->>
        ///// <summary>
        ///// 分析コードフォーカス喪失イベント
        ///// </summary>
        ///// <param name="sender">イベントオブジェクト</param>
        ///// <param name="e">イベント引数</param>
        ///// <remarks>
        ///// <br>Note        : </br>
        ///// <br>Programmer : 980023 飯谷 耕平</br>
        ///// <br>Date       : 2007.06.30</br>
        ///// </remarks>
        //private void AnalysCode_tNedit_Leave(object sender, EventArgs e)
        //{
        //    // 空白か0の場合は初期値をセット
        //    if ((((TNedit)sender).DataText == "") || (((TNedit)sender).GetInt() == 0))
        //    {
        //        if (((TNedit)sender).Equals(this.CustAnalysCode1St_tNedit) ||
        //            ((TNedit)sender).Equals(this.CustAnalysCode2St_tNedit) ||
        //            ((TNedit)sender).Equals(this.CustAnalysCode3St_tNedit) ||
        //            ((TNedit)sender).Equals(this.CustAnalysCode4St_tNedit) ||
        //            ((TNedit)sender).Equals(this.CustAnalysCode5St_tNedit) ||
        //            ((TNedit)sender).Equals(this.CustAnalysCode6St_tNedit))
        //        {
        //            ((TNedit)sender).SetInt(0);
        //        }
        //        else if (((TNedit)sender).Equals(this.CustAnalysCode1Ed_tNedit) ||
        //            ((TNedit)sender).Equals(this.CustAnalysCode2Ed_tNedit) ||
        //            ((TNedit)sender).Equals(this.CustAnalysCode3Ed_tNedit) ||
        //            ((TNedit)sender).Equals(this.CustAnalysCode4Ed_tNedit) ||
        //            ((TNedit)sender).Equals(this.CustAnalysCode5Ed_tNedit) ||
        //            ((TNedit)sender).Equals(this.CustAnalysCode6Ed_tNedit))
        //        {
        //            if ((((TNedit)sender).DataText == ""))
        //            {
        //                ((TNedit)sender).SetInt(999);
        //            }
        //        }
        //    }

        //}
        // 2007.10.15 hikita del end -----------------------------------------------<<
        #endregion

        /// <summary>
        /// 得意先コード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            // 2008.10.17 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_St.GetInt();
            // 2008.10.17 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END

            // 2008.09.09 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.09.09 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END

            // 2008.10.17 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode_St.GetInt())) && (this.tNedit_CustomerCode_St.Text != ""))
            {
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.10.17 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
        }

        /// <summary>
        /// 得意先コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            // 2008.10.17 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            // フォーカス制御用、ガイド呼出前の得意先コード
            int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();
            // 2008.10.17 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END

            // 2008.09.09 30413 犬飼 得意先ガイドのクラスを変更 >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.07.04 30413 犬飼 得意先ガイドのクラスを変更 <<<<<<END

            // 2008.10.17 30413 犬飼 ガイドボタンのフォーカス制御を変更 >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode_Ed.GetInt())) && (this.tNedit_CustomerCode_Ed.Text != ""))
            {
                // ガイド呼出前と違う、クリアされていない場合
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.10.17 30413 犬飼 ガイドボタンのフォーカス制御を変更 <<<<<<END
        }

        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得した得意先コード(開始)を画面に表示する
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "得意先情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先車両検索戻り値クラス</param>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 取得した得意先コード(終了)を画面に表示する
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "選択した得意先は既に削除されています。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "得意先情報の取得に失敗しました。",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }

        /// <summary>
        /// 従業員コード(開始)ガイド起動ボタン起動イベント
        /// </summary>
        private void EmployeeCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // 項目に展開
            if (status == 0)
            {
                this.tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();

                // 2008.10.17 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.17 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }

        }

        /// <summary>
        /// 従業員コード(終了)ガイド起動ボタン起動イベント
        /// </summary>
        private void EmployeeCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // 項目に展開
            if (status == 0)
            {
                this.tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();

                // 2008.10.17 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.17 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }

        /// <summary>
        /// Control.Click イベント(ub_SalesAreaCodeStGuid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 地区（開始）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.09.09</br>
        /// </remarks>
        private void ub_SalesAreaCodeStGuid_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);

                // 2008.10.17 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.17 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }

        /// <summary>
        /// Control.Click イベント(ub_SalesAreaCodeEdGuid)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note 　　  : 地区（終了）ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.09.09</br>
        /// </remarks>
        private void ub_SalesAreaCodeEdGuid_Click(object sender, EventArgs e)
        {
            int status = -1;

            // ガイド起動
            UserGdBd userGdBd = new UserGdBd();
            UserGdHd userGdHd = new UserGdHd();
            status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            // 項目に展開
            if (status == 0)
            {
                this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);

                // 2008.10.17 30413 犬飼 フォーカス制御を追加 >>>>>>START
                // 次のコントロールへフォーカスを移動
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.17 30413 犬飼 フォーカス制御を追加 <<<<<<END
            }
        }

        /// <summary>
        /// 自由帳票呼出処理
        /// </summary>
        /// <remarks>
        /// <br>Note 　　  : 自由帳票を呼び出し印字処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.09.26</br>
        /// <br>Update Note: 2011/02/16 鄧潘ハン</br>                       
        /// <br>           : 印刷処理の速度アップ対応</br>	
        /// <br>---------------------------------------------</br>
        /// <br>Update Note: 2011/12/27 李小路</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分</br>
        /// <br>             Redmine#27270　請求書/メモリ領域のオーバーフローエラーの発生の修正</br>
        /// </remarks>
        // --- UPD m.suzuki 2010/07/22 ---------->>>>>
        //private int FreePrintPaper(SFCMN06002C printInfo)   // ADD 2008/03/09 請求書系フレーム対応：PDFを一括表示…printInfoを追加
        private int FreePrintPaper( SFCMN06002C printInfo, string sectionCode )   // ADD 2008/03/09 請求書系フレーム対応：PDFを一括表示…printInfoを追加
        // --- UPD m.suzuki 2010/07/22 ----------<<<<<
        {
            PreviewPDFPathList.Clear(); //ADD 2008/03/06 請求書系フレーム対応：PDFを一括表示

            int status = 0;

            // DEL 2009/03/09 請求書系フレーム対応↓：PDFを一括表示
            //SFCMN06002C printInfo = new SFCMN06002C();       // 印刷情報パラメータ
            // ADD 2009/03/09 請求書系フレーム対応：PDFを一括表示 ---------->>>>>
            // 印刷情報パラメータ
            if (printInfo == null)
            {
                printInfo = new SFCMN06002C();
            }
            // ADD 2009/03/09 請求書系フレーム対応：PDFを一括表示 ----------<<<<<

            // 企業コード
            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // 抽出条件の設定
            printInfo.jyoken = this._extraInfo_DemandTotal;
            // --- ADD m.suzuki 2010/07/22 ---------->>>>>
            // 抽出条件の拠点を１拠点のみに書き換える
            (printInfo.jyoken as ExtrInfo_DemandTotal).ResultsAddUpSecList = CreateResultsAddUpSecList( sectionCode );
            // --- ADD m.suzuki 2010/07/22 ----------<<<<<

            // --- DEL 2011/02/16--------------------------->>>>>
            // 印刷用DataView設定
            //printInfo.rdData = this.mDemandPrintAcs.CustDmdPrcDataViewPrint;
            // --- DEL 2011/02/16---------------------------<<<<<<

            // --- UPD m.suzuki 2010/07/22 ---------->>>>>
            # region // DEL
            //// 抽出呼び出し
            //PMKAU08000EA freePrint = new PMKAU08000EA(printInfo);
            //status = freePrint.ExtrPrintData();

            //if ( status == 0 )
            //{
            //    // 印刷呼び出し
            //    // --- UPD m.suzuki 2010/07/22 ---------->>>>>
            ////#if EARLY_BINDING
            ////    object prtObj = new PMKAU08001PA();
            ////#else
            ////    object prtObj = LoadAssemblyFrom("PMKAU08001P", "Broadleaf.Drawing.Printing.PMKAU08001PA");
            ////#endif
            //    object prtObj = new PMKAU08001PA();
            //    // --- UPD m.suzuki 2010/07/22 ----------<<<<<
            //    if (prtObj is IPrintProc)
            //    {
            //        (prtObj as IPrintProc).Printinfo = freePrint.Printinfo;
            //        // --- UPD m.suzuki 2010/07/22 ---------->>>>>
            //        //(prtObj as IPrintProc).StartPrint();
            //        status = (prtObj as IPrintProc).StartPrint();
            //        // --- UPD m.suzuki 2010/07/22 ----------<<<<<
            //    }

            //    // --- UPD m.suzuki 2010/07/22 ---------->>>>>
            //    //// ADD 2009/03/09 請求書系フレーム対応：PDFを一括表示 ---------->>>>> // Printメソッドへ移動
            //    //// 出力PDF情報を設定
            //    //_outputPDF = new PDFManager(
            //    //    ((PMKAU08001PA)prtObj).PreviewPdfPathList,  // 表示用PDFフルパス
            //    //    ((PMKAU08001PA)prtObj).PdfPathList          // 請求書単位PDFフルパス
            //    //);
            //    //if (OutputPDF.PreviewPDFPathList.Count > 1)
            //    //{
            //    //    printInfo.pdftemppath = OutputPDF.PreviewPDFPathList[0];
            //    //}
            //    // ADD 2009/03/09 請求書系フレーム対応：PDFを一括表示 ----------<<<<<

            //    // 請求書単位のPDFパスリストに追加
            //    List<string> pdfPathList = ((PMKAU08001PA)prtObj).PdfPathList;
            //    if (pdfPathList != null && pdfPathList .Count > 0)
            //    {
            //        _billPdfPathList.AddRange( pdfPathList  );
            //    }

            //    // タイプ別ドキュメントディクショナリへ格納
            //    Dictionary<string, Document> docDic = ((PMKAU08001PA)prtObj).DocumentByTypeDic;
            //    foreach ( string key in docDic.Keys )
            //    {
            //        // マージする
            //        if ( _documentsDic.ContainsKey( key ) )
            //        {
            //            // 既存keyなら、pagesを追加する。
            //            _documentsDic[key].Pages.AddRange( docDic[key].Pages );
            //        }
            //        else
            //        {
            //            // keyがdicに無ければ追加する
            //            _documentsDic.Add( key, docDic[key] );
            //        }
            //    }

            //    // PMKAU08001Pを解放する為,nullにしておく。(但しガベージコレクタ任せ)
            //    prtObj = null;
            //    // --- UPD m.suzuki 2010/07/22 ----------<<<<<
            //}

            //// --- ADD m.suzuki 2010/07/22 ---------->>>>>
            //if ( printInfo != null && printInfo.rdData != null && printInfo.rdData is DataSet )
            //{

            //    (printInfo.rdData as DataSet).Dispose();
            //}
            //printInfo = null;
            //freePrint = null;
            //// --- ADD m.suzuki 2010/07/22 ----------<<<<<
            # endregion
            // --- ADD 2011/02/16--------------------------->>>>>
            if (printInfo.printmode == 1 && printInfo.prevkbn == 0)
            {
                for (int i = 0; i < this.mDemandPrintAcs.CustDmdPrcDataViewPrint.Count; i++)
                {
                   string nexAddUpSecCode = (string)this.mDemandPrintAcs.CustDmdPrcDataViewPrint[i].Row["AddUpSecCode"].ToString().Trim();
                   if (nexAddUpSecCode == sectionCode)
                   {
                       DataTable table = new DataTable();
                       DataView custView = table.DefaultView;
                       table = this.mDemandPrintAcs.CustDmdPrcDataViewPrint.Table.Clone();
                       table.ImportRow(this.mDemandPrintAcs.CustDmdPrcDataViewPrint[i].Row);
                       custView = new DataView(table);
                       printInfo.rdData = custView;

                       // 抽出
                       status = _freePrintController.Extract(ref printInfo);

                       // 印刷
                       if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                       {
                           List<string> pdfPathList; // PdfPathList
                           Dictionary<string, Document> docDic; // DocumentByTypeDic

                           // 印刷実行
                           status = _freePrintController.Print(out pdfPathList, out docDic);
                           # region [印刷後処理]
                           // 請求書単位のPDFパスリストに追加
                           if (pdfPathList != null && pdfPathList.Count > 0)
                           {
                               _billPdfPathList.AddRange(pdfPathList);
                           }

                           if (docDic != null)
                           {
                               // 今回処理分をPDF出力して、ファイル名をリストに追加
                               if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL &&
                                    (printInfo.printmode == 2 || printInfo.printmode == 3))
                               {
                                   _previewPdfPathList.AddRange(PMKAU08001PA.PrintPDF(ref printInfo, docDic, _extraInfo_DemandTotal.SlipPrtKind, null));
                               }
                           }
                           # endregion
                       }
                       _freePrintController.Dispose2();              //ADD　李小路 2011/12/27 Redmine#27270
               
                   }

                }

            }
            else
            {
                // 印刷用DataView設定
                printInfo.rdData = this.mDemandPrintAcs.CustDmdPrcDataViewPrint;
            
                // 抽出
                status = _freePrintController.Extract(ref printInfo);

                // 印刷
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    List<string> pdfPathList; // PdfPathList
                    Dictionary<string, Document> docDic; // DocumentByTypeDic

                    // 印刷実行
                    status = _freePrintController.Print(out pdfPathList, out docDic);

                    # region [印刷後処理]
                    // 請求書単位のPDFパスリストに追加
                    if (pdfPathList != null && pdfPathList.Count > 0)
                    {
                        _billPdfPathList.AddRange(pdfPathList);
                    }

                    if (docDic != null)
                    {
                        // 今回処理分をPDF出力して、ファイル名をリストに追加
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL &&
                             (printInfo.printmode == 2 || printInfo.printmode == 3))
                        {
                            _previewPdfPathList.AddRange(PMKAU08001PA.PrintPDF(ref printInfo, docDic, _extraInfo_DemandTotal.SlipPrtKind, null));
                        }
                    }
                    # endregion
                }
                _freePrintController.Dispose2();              //ADD　李小路 2011/12/27 Redmine#27270
            }
            // --- ADD 2011/02/16---------------------------<<<<<

            // --- DEL 2011/02/16--------------------------->>>>>
            //// 抽出
            //status = _freePrintController.Extract(ref printInfo);

            //// 印刷
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    List<string> pdfPathList; // PdfPathList
            //    Dictionary<string, Document> docDic; // DocumentByTypeDic

            //    // 印刷実行
            //    status = _freePrintController.Print(out pdfPathList, out docDic);

            //    # region [印刷後処理]
            //    // 請求書単位のPDFパスリストに追加
            //    if (pdfPathList != null && pdfPathList.Count > 0)
            //    {
            //        _billPdfPathList.AddRange(pdfPathList);
            //    }

            //    if (docDic != null)
            //    {
            //        // 今回処理分をPDF出力して、ファイル名をリストに追加
            //        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL &&
            //             (printInfo.printmode == 2 || printInfo.printmode == 3))
            //        {
            //            _previewPdfPathList.AddRange(PMKAU08001PA.PrintPDF(ref printInfo, docDic, _extraInfo_DemandTotal.SlipPrtKind, null));
            //        }
            //    }
            //    # endregion
            //}
            // --- DEL 2011/02/16---------------------------<<<<<

            // 印刷情報の解放
            if ( printInfo != null && printInfo.rdData != null && printInfo.rdData is DataSet )
            {
                (printInfo.rdData as DataSet).Dispose();
            }
            printInfo = null;
            // --- UPD m.suzuki 2010/07/22 ----------<<<<<

            return status;
        }

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// 拠点コードリスト生成（１拠点コードを拠点コード配列にセット）
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private string[] CreateResultsAddUpSecList( string sectionCode )
        {
            return new string[] { sectionCode };
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        /// <summary>
        /// 指定されたアセンブリ及びクラス名より、クラスをインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note 　　  : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.09.26</br>
        /// </remarks>
        private object LoadAssemblyFrom(string asmname, string classname)
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
                Type objType = asm.GetType(classname);
                if (objType != null)
                {
                    obj = Activator.CreateInstance(objType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return obj;
        }

        /// <summary>
        /// 矢印キーでのフォーカス移動イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note 　　  : 矢印キーでのフォーカス移動イベントを処理します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.10.17</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ADD 2009/03/03 請求書系フレーム対応：拠点範囲指定の追加 ---------->>>>>
            _currentResultCode = ResultCode.Normal;

            // 拠点を選択する処理
            if ((e.PrevCtrl == this.tEdit_SectionCode_St) || (e.PrevCtrl == this.tEdit_SectionCode_Ed))
            {
                int resultCode = CheckSectionTreeNode(this.tEdit_SectionCode_St.Text.Trim(), this.tEdit_SectionCode_Ed.Text.Trim());

                // HACK:開始拠点コードへ戻る
                //if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                //{
                //    _focusStartRangeFlag = true;
                //}

                if (resultCode.Equals((int)ResultCode.StartSectionCodeHasError))
                {
                    if (e.PrevCtrl == this.tEdit_SectionCode_Ed)// ADD 2008/03/18 不具合対応[12420]：出力拠点の入力チェックの不正
                    {
                        _currentResultCode = ResultCode.StartSectionCodeHasError;
                        this.tEdit_SectionCode_St.Focus();
                        return;
                    }
                    // ADD 2009/03/18 不具合対応[12420]：出力拠点の入力チェックの不正 ---------->>>>>
                    else if (e.PrevCtrl == this.tEdit_SectionCode_St)
                    {
                        // 開始拠点の入力の段階では入力エラーを無視
                        StatusBarInfoPrinted(this, new PrintStatusBarEventArgs());
                    }
                    // ADD 2009/03/18 不具合対応[12420]：出力拠点の入力チェックの不正 ----------<<<<<
                }

                _currentResultCode = ResultCode.Normal;
                if (e.PrevCtrl == this.tEdit_SectionCode_Ed)    // ADD 2008/03/18 不具合対応[12420]：出力拠点の入力チェックの不正
                {
                    this.AddUpDate_tDateEdit.Focus();
                }
                return;
            }
            // ADD 2008/03/03 請求書系フレーム対応：拠点範囲指定の追加 ----------<<<<<

            if (!e.ShiftKey)
            {
                // SHIFTキー未押下
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
                    {
                        // 担当者(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者(終了)→地区(開始)
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        // 地区(開始)→地区(終了)
                        e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // 地区(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        switch (this._callMode)
                        {
                            case START_MODE_DEFAULT_LIST:           // 請求一覧表
                                {
                                    // 得意先(終了)→回収率印字
                                    //e.NextCtrl = this.CollectRatePrtDiv_tComboEditor;
                                    // 得意先(終了)→売掛区分
                                    e.NextCtrl = this.AccRecDivCd_tComboEditor;
                                    break;
                                }
                            case START_MODE_DEFAULT_TOTAL:          // 請求書(鑑)
                            case START_MODE_DEFAULT_RECEIPT:        // 領収書
                                {
                                    // 得意先(終了)→発行日
                                    e.NextCtrl = this.IssueDay_tDateEdit;
                                    break;
                                }
                        }
                    }
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    //if (e.PrevCtrl == this.CollectRatePrtDiv_tComboEditor)
                    if (e.PrevCtrl == this.AccRecDivCd_tComboEditor)
                    {
                        //// 回収率印字→得意先(終了)
                        // 売掛区分→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.IssueDay_tDateEdit)
                    {
                        // 発行日→得意先(終了)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // 得意先(終了)→得意先(開始)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // 得意先(開始)→地区(終了)
                        e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                    {
                        // 地区(終了)→地区(開始)
                        e.NextCtrl = this.tNedit_SalesAreaCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                    {
                        // 地区(開始)→担当者(終了)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // 担当者(終了)→担当者(開始)
                        e.NextCtrl = this.tEdit_EmployeeCode_St;
                    }
                }
            }
        }

        /// <summary>
        /// 請求内訳のテキスト変更イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note 　　  : 請求内訳のテキスト変更イベントを処理します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009.01.19</br>
        /// </remarks>
        private void DmdDtl_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            int value = (int)((TComboEditor)sender).Value;

            if (value == 1)
            {
                // 請求内訳が請求先
                this.PrCustDtl_tComboEditor.Value = 0;
                this.PrCustDtl_tComboEditor.Enabled = false;
            }
            else
            {
                // 請求内訳が請求先以外
                this.PrCustDtl_tComboEditor.Enabled = true;
            }
        }

        // --- ADD 2020/04/13 陳艶丹 軽減税率対応---------->>>>>
        # region [印刷用税率情報XML]
        /// <summary>
        /// 印刷用税率情報
        /// </summary>
        /// <remarks>
        /// <br>Note       : 印刷用税率情報を取得する。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        public class TaxRatePrintInfo
        {
            /// <summary>印刷用税率設定情報税率１</summary>
            private string _taxRate1;

            /// <summary>印刷用税率設定情報税率２</summary>
            private string _taxRate2;

            /// <summary>印刷用税率設定情報税率１</summary>
            public string TaxRate1
            {
                get { return _taxRate1; }
                set { _taxRate1 = value; }
            }

            /// <summary>印刷用税率設定情報税率２</summary>
            public string TaxRate2
            {
                get { return _taxRate2; }
                set { _taxRate2 = value; }
            }
        }

        # region
        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        /// <returns>デシリアライズ結果</returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        public static int Deserialize(out TaxRatePrintInfo taxRatePrintInfo, out string errmsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;

            errmsg = string.Empty;
            taxRatePrintInfo = null;

            // 印刷用税率情報XMLファイル存在の判断
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CtPrintXmlFileName)))
            {
                try
                {
                    taxRatePrintInfo = UserSettingController.DeserializeUserSetting<TaxRatePrintInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CtPrintXmlFileName));
                    // 税率設定情報税率１
                    double dTaxRate1 = -1;
                    Boolean bTaxRate1 = double.TryParse(taxRatePrintInfo.TaxRate1, out dTaxRate1);
                    // 税率設定情報税率２
                    double dTaxRate2 = -1;
                    Boolean bTaxRate2 = double.TryParse(taxRatePrintInfo.TaxRate2, out dTaxRate2);

                    // 税率未設定の場合、
                    if ((taxRatePrintInfo.TaxRate1 == string.Empty) || (taxRatePrintInfo.TaxRate2 == string.Empty) ||
                        // 同じ税率値の場合
                        (taxRatePrintInfo.TaxRate1 == taxRatePrintInfo.TaxRate2) ||
                        // 数字以外の場合、
                        (!bTaxRate1) || (!bTaxRate2) ||
                        // 税率値は0以下の場合
                        (dTaxRate1 <= 0) || (dTaxRate2 <= 0) ||
                        // 税率値は10以上の場合
                        (dTaxRate1 >= 10) || (dTaxRate2 >= 10))
                    {
                        errmsg = "税率設定情報が正しく設定されていません。";
                        return status;
                    }

                }
                catch (System.InvalidOperationException)
                {
                    errmsg = "税率設定情報が正しく設定されていません。";
                    return status;
                }
            }
            else
            {
                errmsg = "税率設定情報ファイル(" + CtPrintXmlFileName + ")が存在しません。";
                return status;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        # endregion
        # endregion

        #region パラメータセット
        /// <summary>
        /// パラメータにセットする処理
        /// </summary>
        /// <param name="instance">ワーク対象</param>
        /// <param name="propertyName">パラメータ名</param>
        /// <param name="settingValue">設定値</param>
        /// <remarks>
        /// <br>Note       : 11570208-00 軽減税率対応</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/04/13</br>
        /// </remarks>
        private void SetPropertyValue(object instance, string propertyName, object settingValue)
        {
            foreach (PropertyInfo p in instance.GetType().GetProperties())
            {
                if (propertyName.Equals(p.Name))
                {
                    p.SetValue(instance, settingValue, null);
                    break;
                }
            }
        }
        #endregion
        // --- ADD 2020/04/13 陳艶丹 軽減税率対応----------<<<<<
    }

    // ADD 2009/03/03 請求書系フレーム対応：拠点範囲指定の追加 ---------->>>>>
    #region ◎ステータスバーへ出力

    /// <summary>
    /// ステータスバーに出力するイベントパラメータクラス
    /// </summary>
    public sealed class PrintStatusBarEventArgs : EventArgs
    {
        #region <メッセージ/>

        /// <summary>メッセージ</summary>
        private string _message;
        /// <summary>
        /// メッセージのアクセサ
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        #endregion  // <メッセージ/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="message">メッセージ</param>
        public PrintStatusBarEventArgs(string message)
        {
            _message = message;
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public PrintStatusBarEventArgs() : this(string.Empty) { }

        #endregion  // <Constructor/>
    }

    /// <summary>
    /// ステータスバーに出力するイベントハンドラ
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="e">イベントパラメータ</param>
    public delegate void PrintStatusBar(object sender, PrintStatusBarEventArgs e);

    #endregion  // ◎ステータスバーへ出力
    // ADD 2008/03/03 請求書系フレーム対応：拠点範囲指定の追加 ----------<<<<<
    // ADD 2009/03/06 請求書系フレーム対応：PDFを一括表示 ---------->>>>>
    /// <summary>
    /// PDFの管理者クラス
    /// </summary>
    public sealed class PDFManager
    {
        #region <PDFの出力パス（表示用）/>

        /// <summary>PDFの出力フルパスのリスト（表示用）</summary>
        private readonly List<string> _previewPDFPathList;
        /// <summary>
        /// PDFの出力フルパスのリスト（表示用）を取得します。
        /// </summary>
        public List<string> PreviewPDFPathList { get { return _previewPDFPathList; } }

        #endregion  // <PDFの出力パス（表示用）/>

        #region <PDFの出力パス（請求書単位）/>

        /// <summary>PDFの出力フルパスのリスト（請求書単位）</summary>
        private readonly List<string> _pdfPathList;
        /// <summary>
        /// PDFの出力フルパスのリスト（請求書単位）を取得します。
        /// </summary>
        private List<string> PDFPathList { get { return _pdfPathList; } }

        #endregion  // <PDFの出力パス（請求書単位）/>

        #region <表示用PDFパス（キー）と請求書パス（値：リスト）のマップ/>

        /// <summary>表示用PDFパス（キー）と請求書パス（値：リスト）のマップ</summary>
        private readonly IDictionary<string, IList<string>> _pdfPathListMap;
        /// <summary>
        /// 表示用PDFパス（キー）と請求書パス（値：リスト）のマップを取得します。
        /// </summary>
        private IDictionary<string, IList<string>> PDFPathListMap { get { return _pdfPathListMap; } }

        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// ＜static＞　表示用PDFパス（キー）と請求書パス（値：リスト）のマップ
        /// </summary>
        private static IDictionary<string, IList<string>> stc_pdfPathListMap;
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        #endregion  // <表示用PDFパス（キー）と請求書パス（値：リスト）のマップ/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="previewPDFPathList">PDFの出力パス（表示用）</param>
        /// <param name="pdfPathList">PDFの出力パス（請求書単位）</param>
        public PDFManager(
            List<string> previewPDFPathList, 
            List<string> pdfPathList
        )
        {
            // PDFの出力パス（請求書単位）
            if (pdfPathList != null)
            {
                _pdfPathList = pdfPathList;
            }
            else
            {
                _pdfPathList = new List<string>();
            }

            // PDFの出力パス（表示用）
            if (previewPDFPathList != null)
            {
                _previewPDFPathList = previewPDFPathList;
            }
            else
            {
                _previewPDFPathList = new List<string>();
            }

            // 表示用PDFパス（キー）と請求書パス（値：リスト）のマップを初期化
            _pdfPathListMap = CreatePDFListMap( previewPDFPathList, pdfPathList );

            // --- ADD m.suzuki 2010/07/22 ---------->>>>>
            // staticフィールドに退避（PG終了時に全て削除する為）
            if ( stc_pdfPathListMap == null )
            {
                stc_pdfPathListMap = new Dictionary<string, IList<string>>(); 
            }
            AddTargetInfo( ref stc_pdfPathListMap, previewPDFPathList, pdfPathList );
            // --- ADD m.suzuki 2010/07/22 ----------<<<<<
        }
        /// <summary>
        /// 表示用PDFパス（キー）と請求書パス（値：リスト）のマップを生成します。
        /// </summary>
        /// <param name="previewPDFPathList">PDFの出力パス（表示用）のリスト</param>
        /// <param name="pdfPathList">PDFの出力パス（請求書単位）のリスト</param>
        /// <returns>表示用PDFパス（キー）と請求書パス（値：リスト）のマップ</returns>
        private static IDictionary<string, IList<string>> CreatePDFListMap(
            List<string> previewPDFPathList,
            List<string> pdfPathList
        )
        {
            IDictionary<string, IList<string>> pdfPathListMap = new Dictionary<string, IList<string>>();
            {
                if ( previewPDFPathList != null && previewPDFPathList.Count > 0 )
                {
                    foreach ( string previewPDFPath in previewPDFPathList )
                    {
                        if ( !pdfPathListMap.ContainsKey( previewPDFPath ) )
                        {
                            pdfPathListMap.Add( previewPDFPath, pdfPathList );
                        }
                    }
                }
            }
            return pdfPathListMap;
        }
        // --- ADD m.suzuki 2010/07/22 ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="previewPDFPathList"></param>
        /// <param name="pdfPathList"></param>
        private static void AddTargetInfo( ref IDictionary<string, IList<string>> pdfPathListDic, List<string> previewPDFPathList, List<string> pdfPathList )
        {
            if ( pdfPathList == null )
            {
                // このメソッドの引数のリスト
                pdfPathList = new List<string>();
            }

            // ディクショナリに追加
            if ( previewPDFPathList != null && previewPDFPathList.Count > 0 )
            {
                foreach ( string previewPDFPath in previewPDFPathList )
                {
                    if ( !pdfPathListDic.ContainsKey( previewPDFPath ) )
                    {
                        pdfPathListDic.Add( previewPDFPath, pdfPathList );
                    }
                    else
                    {
                        (pdfPathListDic[previewPDFPath] as List<string>).AddRange( pdfPathList );
                    }
                }
            }
        }
        // --- ADD m.suzuki 2010/07/22 ----------<<<<<

        #endregion  // <Constructor/>

        /// <summary>
        /// 関連するPDFファイルを全て削除します。
        /// </summary>
        /// <remarks>指定された表示用PDFファイルと関連する請求書単位のPDFファイルを削除します。</remarks>
        /// <param name="previewPDFPath">PDFの出力パス（表示用）</param>
        public void DeleteFiles(string previewPDFPath)
        {
            // --- UPD m.suzuki 2010/07/22 ---------->>>>>
            //if ( !PDFPathListMap.ContainsKey( previewPDFPath ) ) return;

            //// 表示用PDFファイルを削除
            //if (File.Exists(previewPDFPath))
            //{
            //    File.Delete(previewPDFPath);
            //}

            //// 関連する請求書単位のPDFファイルを削除
            //IList<string> deletingPDFFileList = PDFPathListMap[previewPDFPath];
            //foreach (string deletingPDFPath in deletingPDFFileList)
            //{
            //    if (File.Exists(deletingPDFPath))
            //    {
            //        File.Delete(deletingPDFPath);
            //    }
            //}


            if ( !stc_pdfPathListMap.ContainsKey( previewPDFPath ) ) return;

            // 表示用PDFファイルを削除
            try
            {
                if ( File.Exists( previewPDFPath ) )
                {
                    File.Delete( previewPDFPath );
                }
            }
            catch
            {
            }

            // 関連する請求書単位のPDFファイルを削除
            IList<string> deletingPDFFileList = stc_pdfPathListMap[previewPDFPath];
            foreach ( string deletingPDFPath in deletingPDFFileList )
            {
                try
                {
                    if ( File.Exists( deletingPDFPath ) )
                    {
                        File.Delete( deletingPDFPath );
                    }
                }
                catch
                { 
                }
            }
            // --- UPD m.suzuki 2010/07/22 ----------<<<<<
        }

        /// <summary>
        /// 関連するPDFファイルを全て削除します。
        /// </summary>
        /// <remarks>指定された表示用PDFファイルと関連する請求書単位のPDFファイルを削除します。</remarks>
        public void DeleteFiles()
        {
            foreach (string previewPDFPath in PDFPathListMap.Keys)
            {
                DeleteFiles(previewPDFPath);
            }
        }

        /// <summary>
        /// 複数の表示用PDFが存在するか判定します。
        /// </summary>
        /// <value><c>true</c> :存在します。<br/><c>false</c>:存在しません。</value>
        public bool ExistsOtherPDFPreview
        {
            get { return PreviewPDFPathList.Count > 1; }
        }
    }
    // ADD 2009/03/06 請求書系フレーム対応：PDFを一括表示 ----------<<<<<

    // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ---------->>>>>
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
                return @".\UISettings\MAKAU02012U_SectionSetting.xml";
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
    // ADD 2010/03/11 MANTIS対応[15131]：印字条件を保持可能へ変更 ----------<<<<<

    // ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
    # region　請求書ログ出力データのクラスのクラス
    internal class RequestLogData
    {
        # region ■ private field ■
        /// <summary>LOGﾌｧｲﾙ得意先CD</summary>
        private int customerCode;
        /// <summary>前回請求処理日</summary>
        private DateTime addupDate;
        /// <summary>今回金額</summary>
        private long thisTimeSalesPrice;
        /// <summary>明細合計金額</summary>
        private long totalPrice;
        /// <summary>差額</summary>
        private long differentPrice;
        // add 2012/06/04 >>>
        /// <summary>今回入金額</summary>
        private long thisTimeDemandPrice;
        /// <summary>明細合計金額（入金</summary>
        private long totalDemandPrice;
        /// <summary>入金差額</summary>
        private long differentDemandPrice;
        // add 2012/06/04 <<<

        # endregion ■ private field ■

        # region ■ public propaty ■

        /// public propaty name  :  CustomerCode
        /// <summary>LOGﾌｧｲﾙ得意先CDプロパティ</summary>
        public int CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value; }
        }

        /// public propaty name  :  AddupDate
        /// <summary>前回請求処理日プロパティ</summary>
        public DateTime　AddupDate
        {
            get { return addupDate; }
            set { addupDate = value; }
        }

        /// public propaty name  :  ThisTimeSalesPrice
        /// <summary>今回金額プロパティ</summary>
        public long ThisTimeSalesPrice
        {
            get { return thisTimeSalesPrice; }
            set { thisTimeSalesPrice = value; }
        }

        /// public propaty name  :  TotalPrice
        /// <summary>明細合計金額プロパティ</summary>
        public long TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        /// public propaty name  :  DifferentPrice
        /// <summary>差額プロパティ</summary>
        public long DifferentPrice
        {
            get { return differentPrice; }
            set { differentPrice = value; }
        }

        // add 2012/06/04 >>>
        /// public propaty name  :  ThisTimeDemandPrice
        /// <summary>今回入金額プロパティ</summary>
        public long ThisTimeDemandPrice
        {
            get { return thisTimeDemandPrice; }
            set { thisTimeDemandPrice = value; }
        }

        /// public propaty name  :  TotalDemandPrice
        /// <summary>明細合計金額（入金）プロパティ</summary>
        public long TotalDemandPrice
        {
            get { return totalDemandPrice; }
            set { totalDemandPrice = value; }
        }

        /// public propaty name  :  DifferentDemandPrice
        /// <summary>入金差額プロパティ</summary>
        public long DifferentDemandPrice
        {
            get { return differentDemandPrice; }
            set { differentDemandPrice = value; }
        }
        // add 2012/06/04 <<<
        
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// 請求書出力データのクラス
        /// </summary>
        /// <returns>RequestInfoクラスのインスタンス</returns>
        /// <remarks>
        public RequestLogData()
        {
        }
        # endregion ■ Constructor ■
    }
    # endregion
    // ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<

    // --- ADD m.suzuki 2010/07/22 ---------->>>>>
    /// <summary>
    /// 自由帳票印刷制御クラス
    /// </summary>
    /// <remarks>自由帳票の抽出・印刷クラスを呼び出して制御するクラスです。処理中ダイアログも制御します。</remarks>
    internal class FreePrintController : IDisposable
    {
        # region [enum]
        /// <summary>
        /// 処理モード列挙型
        /// </summary>
        private enum ProcMode : int
        {
            /// <summary>なし</summary>
            None = 0,
            /// <summary>抽出</summary>
            Extract = 1,
            /// <summary>印刷</summary>
            Print = 2,
        }
        # endregion

        # region [private const]
        private const string ct_Message_Extract = "現在、印刷準備中です。";
        private const string ct_Message_BeforePrint = "現在、印刷準備中です。";
        private const string ct_Message_Print = "現在、印刷処理中です。";
        private const string ct_Message_Cancel = "中断します。";
        # endregion

        # region [private フィールド]
        // 抽出処理オブジェクト
        private object _extractObj;
        // 印刷処理オブジェクト
        private object _printObj;

        // 印刷情報
        private SFCMN06002C _printInfo;

        // 印刷ダイアログ
        private SFCMN00299CA _progressDialog;
        private bool _progressDialogDisposed;

        // 現在処理モード(0:なし/1:抽出/2:印刷)
        private ProcMode _mode;
        private bool _cancel;
        internal int _logCnt; // ADD 2012/02/06 xupz for redmine#28258
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FreePrintController()
        {
            this.Clear();
        }
        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Clear()
        {
            _cancel = false;
            _mode = ProcMode.None;
            _progressDialog = null;
        }
        # endregion

        # region [処理中ダイアログ]
        /// <summary>
        /// 処理中ダイアログ表示
        /// </summary>
        public void ShowProgressDialog()
        {
            _progressDialogDisposed = false;

            if ( _progressDialog == null )
            {
                _progressDialog = new SFCMN00299CA();
                _progressDialog.Title = "印刷処理";
                _progressDialog.DispCancelButton = true;
                _progressDialog.CancelButtonClick += new EventHandler( ProgressDialog_CancelButtonClick );
            }
            _progressDialog.Message = ct_Message_Extract;
            _progressDialog.Show();
        }
        /// <summary>
        /// 処理中ダイアログキャンセル時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressDialog_CancelButtonClick( object sender, EventArgs e )
        {
            // キャンセル処理呼び出し
            this.Cancel();
        }
        /// <summary>
        /// 処理中ダイアログ終了
        /// </summary>
        public void HideProgressDialog()
        {
            if ( _progressDialog != null )
            {
                if ( !_progressDialogDisposed )
                {
                    _progressDialog.Dispose();
                    _progressDialog = null;
                    _progressDialogDisposed = true;
                }
            }
        }
        /// <summary>
        /// 再開用・処理ダイアログ表示（印刷プレビューでダイアログを隠した後に再表示する為の処理）
        /// </summary>
        public void RestartShowProgressDialog()
        {
            if ( _progressDialogDisposed )
            {
                // 解放済みならば、ShowProgressDialogを再実行する
                this.ShowProgressDialog();
            }
            else
            {
                // 未解放なら表示続行中なので何もしない
            }
        }
        # endregion

        # region [抽出・印刷]
        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="printInfo"></param>
        /// <returns></returns>
        public int Extract( ref SFCMN06002C printInfo )
        {
            // mode=抽出
            _mode = ProcMode.Extract;

            // 抽出時の印刷情報オブジェクトを退避(結果)
            _printInfo = printInfo;

            try
            {
                _progressDialog.Message = ct_Message_Extract;

                // 抽出
                _extractObj = new PMKAU08000EA( printInfo );
                int status = (_extractObj as PMKAU08000EA).ExtrPrintData();

                if ( _cancel )
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
                return status;
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }
        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns></returns>
        public int Print( out List<string> pdfPathList, out Dictionary<string, Document> documentByTypeDic )
        {
            // mode=印刷
            _mode = ProcMode.Print;

            // 初期化
            pdfPathList = null;
            documentByTypeDic = null;

            try
            {
                _progressDialog.Message = ct_Message_BeforePrint;

                _printObj = new PMKAU08001PA();
                (_printObj as PMKAU08001PA).Printinfo = _printInfo;
                (_printObj as PMKAU08001PA).MessageChange += new EventHandler( FreePrintController_MessageChange );

                // ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
                int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                DataSet ds = (DataSet)_printInfo.rdData;
                DataTable dt = ds.Tables[0];
                // 請求書ログ情報リスト
                List<RequestLogData> requestLogDataList = new List<RequestLogData>();
                // ログフラグ初始値
                int logCnt = 0; // ADD 2012/03/05 xupz for redmine#28258

                // 請求書に印刷情報を再処理
                DataTable dtNew = dt.Clone();
                dtNew.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // 得意先の今回売上金額
                    Int64 thisTimeSalesPrice = 0;
                    // 明細合計金額（入金を含まない）
                    Int64 totalPrice = 0;
                    // 差額
                    Int64 differencePrice = 0;

                    // add 2012/06/04 >>>
                    // 得意先の今回入金額
                    Int64 thisTimeDmdNrml = 0;
                    // 明細合計金額（入金のみ）
                    Int64 demandTotalPrice = 0;
                    // add 2012/06/04 <<<

                    // ログフラグ初始値
                    //_logCnt = 0; // DEL 2012/03/05 xupz for redmine#28258

                    // 自由帳票請求書ヘッダ（ヘッダ）
                    FrePBillHeadWork frePBillHeadWork = new FrePBillHeadWork();

                    if ((FrePBillHeadWork)dt.Rows[i]["FrePBillHead"] != null)
                    {
                        frePBillHeadWork = (FrePBillHeadWork)dt.Rows[i]["FrePBillHead"];
                    }

                    // 自由帳票請求書明細（売上）
                    List<FrePBillDetailWork> frePBillSalesDetailWorkList = new List<FrePBillDetailWork>();

                    if ((List<FrePBillDetailWork>)dt.Rows[i]["FrePBillSalesList"] != null)
                    {
                        frePBillSalesDetailWorkList = (List<FrePBillDetailWork>)dt.Rows[i]["FrePBillSalesList"];
                    }

                    // add 2012/06/04 >>>
                    // 自由帳票請求書明細（入金）
                    List<FrePBillDetailWork> frePBillDemandDetailWorkList = new List<FrePBillDetailWork>();

                    if ((List<FrePBillDetailWork>)dt.Rows[i]["FrePBillDepositList"] != null)
                    {
                        frePBillDemandDetailWorkList = (List<FrePBillDetailWork>)dt.Rows[i]["FrePBillDepositList"];
                    }
                    // add 2012/06/04 <<<
                    
                    // 得意先の今回売上金額(今回売上金額-今回返品金額-今回値引金金額)
                    thisTimeSalesPrice = frePBillHeadWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;

                    // 明細合計金額（入金を含まない）
                    foreach (FrePBillDetailWork frePBillDetailWork in frePBillSalesDetailWorkList)
                    {
                        totalPrice += frePBillDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF;
                    }

                    // add 2012/06/04 >>>
                    // 得意先の今回入金額（今回入金額（通常））
                    thisTimeDmdNrml = frePBillHeadWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;

                    // 明細合計金額（入金のみ）
                    if (frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim() == "00" &&
                        frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0)
                    {
                        if (frePBillDemandDetailWorkList.Count != 0)
                        {
                            // add 2012/06/21 >>>
                            // 手数料・値引加算のキー
                            List<string> keyList = new List<string>();
                            // add 2012/06/21 <<<
                            foreach (FrePBillDetailWork frePBillDemandWork in frePBillDemandDetailWorkList)
                            {
                                demandTotalPrice += frePBillDemandWork.DEPSITDTLRF_DEPOSITRF;
                                // add 2012/06/21 >>>
                                string depKey = string.Format("{0}{1}", frePBillDemandWork.DEPSITMAINRF_ACPTANODRSTATUSRF, frePBillDemandWork.DEPSITMAINRF_DEPOSITSLIPNORF);
                                if (!keyList.Contains(depKey))
                                {
                                    demandTotalPrice += frePBillDemandWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
                                    demandTotalPrice += frePBillDemandWork.DEPSITMAINRF_FEEDEPOSITRF;
                                    // キー更新
                                    keyList.Add(depKey);
                                }
                                // add 2012/06/21 <<<
                            }
                            // del 2012/06/21 >>>
                            //demandTotalPrice += frePBillDemandDetailWorkList[0].DEPSITMAINRF_DISCOUNTDEPOSITRF;
                            //demandTotalPrice += frePBillDemandDetailWorkList[0].DEPSITMAINRF_FEEDEPOSITRF;
                            // del 2012/06/21 <<<
                        }
                    }
                    else
                    {
                        // 集計レコード以外は0
                        demandTotalPrice = 0;
                    }
                    // add 2012/06/04 <<<

                    // updt 2012/06/04 >>>
                    //if (thisTimeSalesPrice == totalPrice)
                    if (thisTimeSalesPrice == totalPrice && thisTimeDmdNrml == demandTotalPrice)
                    // updt 2012/06/04 <<<
                    {
                        dtNew.ImportRow(dt.Rows[i]);
                    }
                    // 得意先の今回売上金額と、明細合計（入金を含まない）を比較して、ＬＯＧ出力する。
                    // add 2012/06/04 >>>
                    // かつ得意先の今回入金額と明細合計（入金のみ）を比較して、違いがあった場合、LOG出力する。
                    // add 2012/06/04 <<<
                    else
                    {
                        // LOGが有る
                        //_logCnt++; // DEL 2012/03/05 xupz for redmine#28258
                        logCnt++; // ADD 2012/03/05 xupz for redmine#28258

                        RequestLogData requestLogData = new RequestLogData();

                        // 得意先CD
                        int customerCode = frePBillHeadWork.CADD_CUSTOMERCODERF;
                        requestLogData.CustomerCode = customerCode;
                        if (customerCode == 0)
                        {
                            requestLogData.CustomerCode = frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF;
                        }

                        //前回請求処理日
                        requestLogData.AddupDate = (_printInfo.jyoken as ExtrInfo_DemandTotal).AddUpDate;

                        //今回売上金額
                        requestLogData.ThisTimeSalesPrice = thisTimeSalesPrice;

                        //明細合計金額
                        requestLogData.TotalPrice = totalPrice;

                        //差額
                        differencePrice = totalPrice - thisTimeSalesPrice;
                        requestLogData.DifferentPrice = differencePrice;

                        // add 2012/06/04 >>>
                        //今回入金額
                        requestLogData.ThisTimeDemandPrice = thisTimeDmdNrml;

                        //明細合計金額（入金）
                        requestLogData.TotalDemandPrice = demandTotalPrice;

                        // 入金差額
                        differencePrice = demandTotalPrice - thisTimeDmdNrml;
                        requestLogData.DifferentDemandPrice = differencePrice;
                        // add 2012/06/04 <<<

                        requestLogDataList.Add(requestLogData);
                    }
                }

                //得意先の今回売上金額と、明細合計（入金を含まない）を比較して、違いがあった場合は請求書の印刷情報を除去する
                ds.Tables.RemoveAt(0);
                ds.Tables.Add(dtNew);
                _printInfo.rdData = ds;

                // LOGが有る
                //if (_logCnt > 0) // DEL 2012/03/05 xupz for redmine#28258
                if (logCnt > 0) // ADD 2012/03/05 xupz for redmine#28258
                {
                    LogWrite(requestLogDataList);
                    _logCnt++; // ADD 2012/03/05 xupz for redmine#28258
                }

                //印刷実行
                if (_printInfo.rdData != null)
                {
                    status = (_printObj as PMKAU08001PA).StartPrint();
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                // ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<

                // 印刷実行
                //int status = (_printObj as PMKAU08001PA).StartPrint(); // DEL 2012/02/06 xupz for redmine#28258

                // 結果格納
                pdfPathList = (_printObj as PMKAU08001PA).PdfPathList;
                documentByTypeDic = (_printObj as PMKAU08001PA).DocumentByTypeDic;

                if ( _cancel )
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
                Thread.Sleep( 10 ); // 0.01sec (PDFのファイル名が確実に変わるよう)
                return status;
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        // ----- ADD 2012/02/06 xupz for redmine#28258---------->>>>>
        /// <summary>
        /// ログ出力処理
        /// </summary>
        /// <param name="requestinfoList">請求書エラー情報リスト</param>
        private void LogWrite(List<RequestLogData> requestLogDataList)
        {
            try
            {
                FileStream _fs;										// ファイルストリーム
                StreamWriter _sw;                                     // ストリームwriter

                //ファイルのパスを取得する(regedit表から)
                string registData;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey broadleaf = software.OpenSubKey("BroadLeaf", true);
                RegistryKey product = broadleaf.OpenSubKey("Product", true);
                RegistryKey partsMan = product.OpenSubKey("Partsman", true);
                registData = partsMan.GetValue("InstallDirectory").ToString();

                DateTime edt = DateTime.Now;

                //フォーだあるのかの判断
                string folderPath = registData + "\\LOG\\";
                if (!Directory.Exists(folderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath);
                    DirectoryInfo dis = di.CreateSubdirectory("MAKAU02012U\\");
                }
                else 
                {

                    if (!Directory.Exists(folderPath + "MAKAU02012U\\"))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(folderPath + "MAKAU02012U\\");
                    }
                }

                //ファイルを作成する
                _fs = new FileStream( registData + "\\LOG\\" + "MAKAU02012U\\" + "MAKAU02012U_" + edt.ToString("yyyyMMdd") + ".Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));

                //ファイルにログを書くことがあるのかの判断
                FileInfo fi = new FileInfo(@_fs.Name);
                if (fi.Length == 0)
                {
                    // updt 2012/06/04 >>>
                    //_sw.WriteLine("\"LOGﾌｧｲﾙ得意先CD\"," + "\"前回請求処理日\"," + "\"今回金額\"," + "\"明細合計金額\"," + "\"差額\"");
                    _sw.WriteLine("\"LOGﾌｧｲﾙ得意先CD\"," + "\"前回請求処理日\"," + "\"今回金額\"," + "\"明細合計金額\"," + "\"売上差額\"," + "\"今回入金額\"," + "\"明細合計金額（入金）\"," + "\"入金差額\"");
                    // updt 2012/06/04 <<<
                }

                //ファイルにログを書きます
                foreach (RequestLogData item in requestLogDataList)
                {
                    // updt 2012/06/04 >>>
                    //_sw.WriteLine("\"" + item.CustomerCode + "\",\"" + TDateTime.DateTimeToString("YYYY/MM/DD", item.AddupDate) + "\",\"" + item.ThisTimeSalesPrice + "\",\"" + item.TotalPrice + "\",\"" + item.DifferentPrice + "\"");
                    _sw.WriteLine("\"" + item.CustomerCode + "\",\"" + TDateTime.DateTimeToString("YYYY/MM/DD", item.AddupDate) + "\",\"" + item.ThisTimeSalesPrice + "\",\"" + item.TotalPrice + "\",\"" + item.DifferentPrice + "\",\"" + item.ThisTimeDemandPrice + "\",\"" + item.TotalDemandPrice + "\",\"" + item.DifferentDemandPrice + "\"");
                    // updt 2012/06/04 <<<
                }

                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // ----- ADD 2012/02/06 xupz for redmine#28258----------<<<<<

        /// <summary>
        /// 印刷処理でメッセージ変更する処理（印刷準備⇒印刷処理）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePrintController_MessageChange( object sender, EventArgs e )
        {
            if ( _printInfo.prevkbn == 0 )
            {
                //----------------------------------------
                // プレビューなし
                //----------------------------------------
                // メッセージ変更
                _progressDialog.Message = ct_Message_Print;
            }
            else
            {
                //----------------------------------------
                // プレビューあり
                //----------------------------------------
                // ダイアログ自体を終了⇒再開するにはRestartShowProgressDialogの呼び出しが必要！
                this.HideProgressDialog();
            }
        }
        /// <summary>
        /// キャンセル処理
        /// </summary>
        public void Cancel()
        {
            _cancel = true;

            switch ( _mode )
            {
                default:
                case ProcMode.None:
                    break;
                case ProcMode.Extract:
                    {
                        // 抽出キャンセル
                        if ( _extractObj != null )
                        {
                            (_extractObj as PMKAU08000EA).Cancel();
                        }
                    }
                    break;
                case ProcMode.Print:
                    {
                        // 印刷キャンセル
                        if ( _printObj != null )
                        {
                            (_printObj as PMKAU08001PA).Cancel();
                        }
                    }
                    break;
            }

            // キャンセルメッセージ表示
            if ( _progressDialog != null )
            {
                _progressDialog.Message = ct_Message_Cancel;
            }
        }
        # endregion

        # region [Dispose]
        /// <summary>
        /// 解放処理
        /// </summary>
        public void Dispose()
        {
            // 印刷オブジェクト解放
            if ( _printObj != null )
            {
                (_printObj as PMKAU08001PA).Dispose();
            }

            // ガベージコレクションを期待してnullにしておく
            _extractObj = null;
            _printObj = null;
            // メインＰＧにより別途DataTableの解放を行うので、保持しないようnullにする。
            _printInfo = null;

            // ダイアログ解放
            this.HideProgressDialog();

            // 初期化
            this.Clear();
        }

        /// <summary>
        /// 解放処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 解放処理ス</br>
        /// <br>Programmer : 李小路</br>
        /// <br>Date       : 2011/12/27</br>
        /// <br>管理番号   : 10707327-00 2012/01/25配信分 Redmine#27270
        /// <br>                           請求書/メモリ領域のオーバーフローエラーの発生の修正修</br>
        public void Dispose2()
        {
            // 印刷オブジェクト解放
            if (_printObj != null)
            {
                (_printObj as PMKAU08001PA).Dispose();
            }

            // ガベージコレクションを期待してnullにしておく
            _extractObj = null;
            _printObj = null;
            // メインＰＧにより別途DataTableの解放を行うので、保持しないようnullにする。
            _printInfo = null;

        }

        # endregion
    }
# if DEBUG
    internal class LogWriter
    {
        public static void Write(string msg)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\MAKAU02012U_log.txt", true);
            sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  " + msg);
            sw.Close();
        }
    }
# endif
    // --- ADD m.suzuki 2010/07/22 ----------<<<<<
}

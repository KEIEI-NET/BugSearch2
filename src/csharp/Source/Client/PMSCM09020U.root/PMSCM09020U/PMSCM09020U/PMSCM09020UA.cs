//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM全体設定マスタ
// プログラム概要   : SCM全体設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024 佐々木 健
// 作 成 日  2010/05/21  修正内容 : 自動回答区分のオプション化
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/08/03  修正内容 : 項目追加(レジ番号、受信処理起動間隔)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2011/01/14  修正内容 : 受信処理起動間隔の最短を1分に変更する。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2011/01/14  修正内容 : 受信処理起動間隔の最短を1分に変更する。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/07/13  修正内容 : 自動回答できる品目を委託在庫分以外も処理
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2011/07/27  修正内容 : Redmine#23227:自動回答区分の設定とグリッドの表示不統一
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当：田建委
// 修正日    2011/09/08  修正内容：障害報告 #24169　拠点設定を行おうと拠点ガイドをすると全社共通の編集を行おうとしてしまう。
//　　　　　　　　　　　　　　　　　　　　　　　　　　 拠点コードと拠点ガイドのフォーカス移動はメッセージ表示を行わないように修正
// ---------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当：wangf
// 修正日    2011/09/14  修正内容：障害報告 #24169#13の対応
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 修正日    2011/09/16  修正内容 : Redmine 25177 PCCUOE／PM側　PCC全体設定マスタの仕様変更                            
// ---------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修正日    2012/04/20  修正内容 : 販売区分設定、販売区分コードの追加 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30747 三戸 伸悟
// 作 成 日  2012/08/31  修正内容 : 2012/10月配信予定 SCM障害№76の対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341対応
//                                : 自動回答区分（問合せ）、自動回答区分（発注）、受付従業員コード、受付従業員名称、納品区分、納品区分名称の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/20  修正内容 : 2012/12/12配信予定 システムテスト障害№28,29対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/20  修正内容 : 2012/12/12配信予定 システムテスト障害№45対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/13  修正内容 : SCM障害追加②対応
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : qijh
// 作 成 日  2013/02/27  修正内容 : 2013/06/18配信 Redmine#34752 「PMSCMのNo.10385」BLPの対応
//----------------------------------------------------------------------------//
//管理番号  10801804-00  作成担当 : wangl2
//作 成 日  2013/04/11   修正内容 : 2013/06/18配信 No.73 見積自動回答サービス　#35269
//----------------------------------------------------------------------------//
//管理番号               作成担当 : 30745 吉岡 孝憲
//作 成 日  2013/06/11   修正内容 : 2013/06/18配信 システムテスト障害№36、№37（SCM障害No.73）
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
// 2010/05/21 Add >>>
using Broadleaf.Application.Resources;  
using Broadleaf.Application.Remoting.ParamData;
// 2010/05/21 Add <<<
using Broadleaf.Library.Text; // 2010/08/03

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// SCM全体設定フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: SCM全体設定を行います。
    ///					  IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Update Note : 2011/09/08 田建委</br>
    /// <br>              障害報告 #24169 全社共通の編集　</br>   
    /// <br>Update Note : 2011/09/16 鄧潘ハン</br>
    /// <br>              障害報告 #25177 PCCUOE／PM側　PCC全体設定マスタの仕様変更</br>
    /// </remarks>
	public class PMSCM09020UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel AutoCooperatDis_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit AutoCooperatDis_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel DiscountApplyCd_uLabel;
		private Broadleaf.Library.Windows.Forms.TComboEditor DiscountApplyCd_tComEditor;
		private Infragistics.Win.Misc.UltraLabel AcpOdrrSlipPrtDiv_uLabel;
        private Broadleaf.Library.Windows.Forms.TComboEditor AcpOdrrSlipPrtDiv_tComEditor;
		private Infragistics.Win.Misc.UltraLabel OldSysCooperatDiv_uLabel;
		private Infragistics.Win.Misc.UltraLabel Section_uLabel;
		private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel SalesSlipPrtDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel OldSysCoopFolder_uLabel;
        private Infragistics.Win.Misc.UltraLabel BLCodeChgDiv_uLabel;
        private TComboEditor BLCodeChgDiv_tComboEditor;
        private TComboEditor SalesSlipPrtDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private TEdit tEdit_SectionCodeAllowZero2;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private TEdit tEdit_OldSysCoopFolder;
        private Infragistics.Win.Misc.UltraButton OldSysCoopFolder_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TComboEditor AutoAnswerDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AutoAnswerDiv_uLabel;
        private TComboEditor EstimatePrtDiv_tComEditor;
        private Infragistics.Win.Misc.UltraLabel EstimatePrtDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private TEdit tEdit_RcvProcStInterval;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private TEdit tEdit_CashRegisterNo;
        private TEdit tEdit_CashRegisterNoNm;
        private TComboEditor SalesCdStAutoAns_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private TNedit SalesCode_tNedit;
        private Infragistics.Win.Misc.UltraButton uButton_SalesCode;
        private TComboEditor AutoAnsHourDspDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AutoAnsHourDspDiv_uLabel;
        private TComboEditor DeliveredGoodsDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DeliveredGoodsDiv_Label;
        private TNedit tEdit_FrontEmployeeCd;
        private TEdit tEdit_FrontEmployeeNm;
        private Infragistics.Win.Misc.UltraButton uButtonFrontEmployeeCdGuid;
        private Infragistics.Win.Misc.UltraLabel FrontEmployee_Label;
        private TComboEditor AutoAnsInquiryDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AutoAnsInquiryDiv_uLabel;
        private TComboEditor AutoAnsOrderDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AutoAnsOrderDiv_uLabel;
        private TComboEditor FuwioutAutoAnsDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private TComboEditor DataUpdWarehouseDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DataUpdWarehouseDiv_uLabel;
        private TNedit tEdit_SalesInputCode;
        private TEdit tEdit_SalesInputNm;
        private Infragistics.Win.Misc.UltraButton uButtonSalesInputCodeGuid;
        private Infragistics.Win.Misc.UltraLabel SalesInputCode_Label;
		private Broadleaf.Library.Windows.Forms.TComboEditor OldSysCooperatDiv_tComEditor;
		#endregion

		#region -- Constructor --
		/// <summary>
        /// SCM全体設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: SCM全体設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br></br>
		/// </remarks>
        public PMSCM09020UA()
        {
            InitializeComponent();

            // データセット列情報構築処理
            DataSetColumnConstruction();

            // プロパティ初期値設定
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //　企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 変数初期化
            this._dataIndex = -1;
            this._scmTtlStAcs = new SCMTtlStAcs();
            this._totalCount = 0;
            this._scmTtlStTable = new Hashtable();

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 拠点設定アクセスクラス
            this._secInfoAcs = new SecInfoAcs();
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this._userGuideAcs = new UserGuideAcs();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            //>>>2010/08/03
            // 端末管理情報キャッシュ
            this._scmTtlStAcs.CachePosTerminalMg(this._enterpriseCode);
            //<<<2010/08/03
        }
		#endregion

		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region -- Windows フォーム デザイナで生成されたコード --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("従業員ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("従業員ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM09020UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AutoCooperatDis_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.AutoCooperatDis_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.DiscountApplyCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DiscountApplyCd_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AcpOdrrSlipPrtDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.AcpOdrrSlipPrtDiv_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.OldSysCooperatDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.OldSysCooperatDiv_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.uButtonFrontEmployeeCdGuid = new Infragistics.Win.Misc.UltraButton();
            this.uButtonSalesInputCodeGuid = new Infragistics.Win.Misc.UltraButton();
            this.SalesSlipPrtDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.OldSysCoopFolder_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BLCodeChgDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SalesSlipPrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BLCodeChgDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_OldSysCoopFolder = new Broadleaf.Library.Windows.Forms.TEdit();
            this.OldSysCoopFolder_Button = new Infragistics.Win.Misc.UltraButton();
            this.AutoAnswerDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.AutoAnswerDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.EstimatePrtDiv_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.EstimatePrtDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_CashRegisterNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_CashRegisterNoNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_RcvProcStInterval = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesCdStAutoAns_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SalesCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_SalesCode = new Infragistics.Win.Misc.UltraButton();
            this.AutoAnsHourDspDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoAnsHourDspDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.AutoAnsInquiryDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoAnsInquiryDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.AutoAnsOrderDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AutoAnsOrderDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DeliveredGoodsDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DeliveredGoodsDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_FrontEmployeeCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_FrontEmployeeNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.FrontEmployee_Label = new Infragistics.Win.Misc.UltraLabel();
            this.FuwioutAutoAnsDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.DataUpdWarehouseDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DataUpdWarehouseDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SalesInputCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_SalesInputNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SalesInputCode_Label = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.AutoCooperatDis_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountApplyCd_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrrSlipPrtDiv_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldSysCooperatDiv_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipPrtDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLCodeChgDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OldSysCoopFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnswerDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatePrtDiv_tComEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CashRegisterNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CashRegisterNoNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_RcvProcStInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCdStAutoAns_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnsHourDspDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnsInquiryDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnsOrderDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveredGoodsDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuwioutAutoAnsDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataUpdWarehouseDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputNm)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(579, 703);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 30;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(448, 703);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 2;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 743);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(713, 23);
            this.ultraStatusBar1.TabIndex = 61;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(559, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 31;
            this.Mode_Label.Text = "更新モード";
            // 
            // AutoCooperatDis_uLabel
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.AutoCooperatDis_uLabel.Appearance = appearance29;
            this.AutoCooperatDis_uLabel.Location = new System.Drawing.Point(16, 356);
            this.AutoCooperatDis_uLabel.Name = "AutoCooperatDis_uLabel";
            this.AutoCooperatDis_uLabel.Size = new System.Drawing.Size(165, 24);
            this.AutoCooperatDis_uLabel.TabIndex = 48;
            this.AutoCooperatDis_uLabel.Text = "自動連携値引率";
            // 
            // AutoCooperatDis_tNedit
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance56.ForeColor = System.Drawing.Color.Black;
            appearance56.TextHAlignAsString = "Right";
            this.AutoCooperatDis_tNedit.ActiveAppearance = appearance56;
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance57.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance57.ForeColor = System.Drawing.Color.Black;
            appearance57.ForeColorDisabled = System.Drawing.Color.Black;
            appearance57.TextHAlignAsString = "Right";
            appearance57.TextVAlignAsString = "Middle";
            this.AutoCooperatDis_tNedit.Appearance = appearance57;
            this.AutoCooperatDis_tNedit.AutoSelect = true;
            this.AutoCooperatDis_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AutoCooperatDis_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.AutoCooperatDis_tNedit.DataText = "";
            this.AutoCooperatDis_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AutoCooperatDis_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.AutoCooperatDis_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.AutoCooperatDis_tNedit.Location = new System.Drawing.Point(221, 356);
            this.AutoCooperatDis_tNedit.MaxLength = 6;
            this.AutoCooperatDis_tNedit.Name = "AutoCooperatDis_tNedit";
            this.AutoCooperatDis_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.AutoCooperatDis_tNedit.Size = new System.Drawing.Size(74, 24);
            this.AutoCooperatDis_tNedit.TabIndex = 11;
            // 
            // ultraLabel1
            // 
            appearance35.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance35;
            this.ultraLabel1.Location = new System.Drawing.Point(319, 356);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel1.TabIndex = 12;
            this.ultraLabel1.Text = "％";
            // 
            // DiscountApplyCd_uLabel
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.DiscountApplyCd_uLabel.Appearance = appearance18;
            this.DiscountApplyCd_uLabel.Location = new System.Drawing.Point(16, 326);
            this.DiscountApplyCd_uLabel.Name = "DiscountApplyCd_uLabel";
            this.DiscountApplyCd_uLabel.Size = new System.Drawing.Size(165, 24);
            this.DiscountApplyCd_uLabel.TabIndex = 47;
            this.DiscountApplyCd_uLabel.Text = "値引適用区分";
            // 
            // DiscountApplyCd_tComEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.DiscountApplyCd_tComEditor.ActiveAppearance = appearance19;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            this.DiscountApplyCd_tComEditor.Appearance = appearance20;
            this.DiscountApplyCd_tComEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DiscountApplyCd_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DiscountApplyCd_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DiscountApplyCd_tComEditor.ItemAppearance = appearance21;
            this.DiscountApplyCd_tComEditor.Location = new System.Drawing.Point(221, 326);
            this.DiscountApplyCd_tComEditor.Name = "DiscountApplyCd_tComEditor";
            this.DiscountApplyCd_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.DiscountApplyCd_tComEditor.TabIndex = 10;
            this.DiscountApplyCd_tComEditor.ValueChanged += new System.EventHandler(this.DiscountApplyCd_tComEditor_ValueChanged);
            // 
            // AcpOdrrSlipPrtDiv_uLabel
            // 
            appearance66.TextVAlignAsString = "Middle";
            this.AcpOdrrSlipPrtDiv_uLabel.Appearance = appearance66;
            this.AcpOdrrSlipPrtDiv_uLabel.Location = new System.Drawing.Point(16, 111);
            this.AcpOdrrSlipPrtDiv_uLabel.Name = "AcpOdrrSlipPrtDiv_uLabel";
            this.AcpOdrrSlipPrtDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.AcpOdrrSlipPrtDiv_uLabel.TabIndex = 36;
            this.AcpOdrrSlipPrtDiv_uLabel.Text = "受注伝票発行区分";
            // 
            // AcpOdrrSlipPrtDiv_tComEditor
            // 
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance67.ForeColor = System.Drawing.Color.Black;
            appearance67.TextVAlignAsString = "Middle";
            this.AcpOdrrSlipPrtDiv_tComEditor.ActiveAppearance = appearance67;
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            this.AcpOdrrSlipPrtDiv_tComEditor.Appearance = appearance27;
            this.AcpOdrrSlipPrtDiv_tComEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AcpOdrrSlipPrtDiv_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AcpOdrrSlipPrtDiv_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AcpOdrrSlipPrtDiv_tComEditor.ItemAppearance = appearance28;
            this.AcpOdrrSlipPrtDiv_tComEditor.Location = new System.Drawing.Point(221, 111);
            this.AcpOdrrSlipPrtDiv_tComEditor.Name = "AcpOdrrSlipPrtDiv_tComEditor";
            this.AcpOdrrSlipPrtDiv_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.AcpOdrrSlipPrtDiv_tComEditor.TabIndex = 4;
            // 
            // OldSysCooperatDiv_uLabel
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.OldSysCooperatDiv_uLabel.Appearance = appearance30;
            this.OldSysCooperatDiv_uLabel.Location = new System.Drawing.Point(12, 709);
            this.OldSysCooperatDiv_uLabel.Name = "OldSysCooperatDiv_uLabel";
            this.OldSysCooperatDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.OldSysCooperatDiv_uLabel.TabIndex = 59;
            this.OldSysCooperatDiv_uLabel.Text = "旧システム連携区分";
            this.OldSysCooperatDiv_uLabel.Visible = false;
            // 
            // OldSysCooperatDiv_tComEditor
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.TextVAlignAsString = "Middle";
            this.OldSysCooperatDiv_tComEditor.ActiveAppearance = appearance31;
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.OldSysCooperatDiv_tComEditor.Appearance = appearance32;
            this.OldSysCooperatDiv_tComEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.OldSysCooperatDiv_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.OldSysCooperatDiv_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OldSysCooperatDiv_tComEditor.ItemAppearance = appearance69;
            this.OldSysCooperatDiv_tComEditor.Location = new System.Drawing.Point(287, 709);
            this.OldSysCooperatDiv_tComEditor.Name = "OldSysCooperatDiv_tComEditor";
            this.OldSysCooperatDiv_tComEditor.Size = new System.Drawing.Size(52, 24);
            this.OldSysCooperatDiv_tComEditor.TabIndex = 25;
            this.OldSysCooperatDiv_tComEditor.Visible = false;
            this.OldSysCooperatDiv_tComEditor.ValueChanged += new System.EventHandler(this.OldSysCooperatDiv_tComEditor_ValueChanged);
            // 
            // Section_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance4;
            this.Section_uLabel.Location = new System.Drawing.Point(16, 42);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(165, 24);
            this.Section_uLabel.TabIndex = 32;
            this.Section_uLabel.Text = "拠点";
            // 
            // SectionName_tEdit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance36.ForeColor = System.Drawing.Color.Black;
            this.SectionName_tEdit.ActiveAppearance = appearance36;
            appearance37.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.ForeColorDisabled = System.Drawing.Color.Black;
            appearance37.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance37;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionName_tEdit.Location = new System.Drawing.Point(255, 42);
            this.SectionName_tEdit.MaxLength = 10;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.ReadOnly = true;
            this.SectionName_tEdit.Size = new System.Drawing.Size(159, 24);
            this.SectionName_tEdit.TabIndex = 1;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(456, 42);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 2;
            ultraToolTipInfo3.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo3);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // uButtonFrontEmployeeCdGuid
            // 
            appearance45.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.uButtonFrontEmployeeCdGuid.Appearance = appearance45;
            this.uButtonFrontEmployeeCdGuid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uButtonFrontEmployeeCdGuid.Location = new System.Drawing.Point(287, 574);
            this.uButtonFrontEmployeeCdGuid.Name = "uButtonFrontEmployeeCdGuid";
            this.uButtonFrontEmployeeCdGuid.Size = new System.Drawing.Size(25, 25);
            this.uButtonFrontEmployeeCdGuid.TabIndex = 22;
            this.uButtonFrontEmployeeCdGuid.Tag = "1";
            ultraToolTipInfo2.ToolTipText = "従業員ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButtonFrontEmployeeCdGuid, ultraToolTipInfo2);
            this.uButtonFrontEmployeeCdGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButtonFrontEmployeeCdGuid.Click += new System.EventHandler(this.uButtonFrontEmployeeCdGuid_Click);
            // 
            // uButtonSalesInputCodeGuid
            // 
            appearance87.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.uButtonSalesInputCodeGuid.Appearance = appearance87;
            this.uButtonSalesInputCodeGuid.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.uButtonSalesInputCodeGuid.Location = new System.Drawing.Point(287, 632);
            this.uButtonSalesInputCodeGuid.Name = "uButtonSalesInputCodeGuid";
            this.uButtonSalesInputCodeGuid.Size = new System.Drawing.Size(25, 25);
            this.uButtonSalesInputCodeGuid.TabIndex = 288;
            this.uButtonSalesInputCodeGuid.Tag = "1";
            ultraToolTipInfo1.ToolTipText = "従業員ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.uButtonSalesInputCodeGuid, ultraToolTipInfo1);
            this.uButtonSalesInputCodeGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButtonSalesInputCodeGuid.Click += new System.EventHandler(this.uButtonSalesInputCodeGuid_Click);
            // 
            // SalesSlipPrtDiv_uLabel
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.SalesSlipPrtDiv_uLabel.Appearance = appearance68;
            this.SalesSlipPrtDiv_uLabel.Location = new System.Drawing.Point(16, 81);
            this.SalesSlipPrtDiv_uLabel.Name = "SalesSlipPrtDiv_uLabel";
            this.SalesSlipPrtDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.SalesSlipPrtDiv_uLabel.TabIndex = 35;
            this.SalesSlipPrtDiv_uLabel.Text = "売上伝票発行区分";
            // 
            // OldSysCoopFolder_uLabel
            // 
            appearance62.TextVAlignAsString = "Middle";
            this.OldSysCoopFolder_uLabel.Appearance = appearance62;
            this.OldSysCoopFolder_uLabel.Location = new System.Drawing.Point(72, 710);
            this.OldSysCoopFolder_uLabel.Name = "OldSysCoopFolder_uLabel";
            this.OldSysCoopFolder_uLabel.Size = new System.Drawing.Size(199, 24);
            this.OldSysCoopFolder_uLabel.TabIndex = 60;
            this.OldSysCoopFolder_uLabel.Text = "旧システム連携用フォルダ";
            this.OldSysCoopFolder_uLabel.Visible = false;
            // 
            // BLCodeChgDiv_uLabel
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.BLCodeChgDiv_uLabel.Appearance = appearance17;
            this.BLCodeChgDiv_uLabel.Location = new System.Drawing.Point(16, 184);
            this.BLCodeChgDiv_uLabel.Name = "BLCodeChgDiv_uLabel";
            this.BLCodeChgDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.BLCodeChgDiv_uLabel.TabIndex = 39;
            this.BLCodeChgDiv_uLabel.Text = "BLコード変換";
            // 
            // SalesSlipPrtDiv_tComboEditor
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.SalesSlipPrtDiv_tComboEditor.ActiveAppearance = appearance58;
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.SalesSlipPrtDiv_tComboEditor.Appearance = appearance59;
            this.SalesSlipPrtDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SalesSlipPrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SalesSlipPrtDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SalesSlipPrtDiv_tComboEditor.ItemAppearance = appearance60;
            this.SalesSlipPrtDiv_tComboEditor.Location = new System.Drawing.Point(221, 81);
            this.SalesSlipPrtDiv_tComboEditor.Name = "SalesSlipPrtDiv_tComboEditor";
            this.SalesSlipPrtDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.SalesSlipPrtDiv_tComboEditor.TabIndex = 3;
            // 
            // BLCodeChgDiv_tComboEditor
            // 
            appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance76.ForeColor = System.Drawing.Color.Black;
            appearance76.TextVAlignAsString = "Middle";
            this.BLCodeChgDiv_tComboEditor.ActiveAppearance = appearance76;
            appearance77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance77.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance77.ForeColorDisabled = System.Drawing.Color.Black;
            this.BLCodeChgDiv_tComboEditor.Appearance = appearance77;
            this.BLCodeChgDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BLCodeChgDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BLCodeChgDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLCodeChgDiv_tComboEditor.ItemAppearance = appearance78;
            this.BLCodeChgDiv_tComboEditor.Location = new System.Drawing.Point(221, 184);
            this.BLCodeChgDiv_tComboEditor.Name = "BLCodeChgDiv_tComboEditor";
            this.BLCodeChgDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.BLCodeChgDiv_tComboEditor.TabIndex = 6;
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(16, 72);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(645, 3);
            this.DivideLine_Label.TabIndex = 34;
            // 
            // ultraLabel6
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance34;
            this.ultraLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(487, 42);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(223, 24);
            this.ultraLabel6.TabIndex = 33;
            this.ultraLabel6.Text = "※ゼロで共通設定になります";
            // 
            // Revive_Button
            // 
            this.Revive_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(449, 703);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 3;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(319, 703);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 0;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance41.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance41;
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance42.ForeColorDisabled = System.Drawing.Color.Black;
            appearance42.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance42;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCodeAllowZero2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(221, 42);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 0;
            this.tEdit_SectionCodeAllowZero2.Leave += new System.EventHandler(this.tEdit_SectionCodeAllowZero2_Leave);
            this.tEdit_SectionCodeAllowZero2.Enter += new System.EventHandler(this.tEdit_SectionCodeAllowZero2_Enter);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(320, 703);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 1;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel5.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel5.Location = new System.Drawing.Point(16, 175);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(645, 3);
            this.ultraLabel5.TabIndex = 38;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel8.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel8.Location = new System.Drawing.Point(12, 565);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(645, 3);
            this.ultraLabel8.TabIndex = 56;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel2.Location = new System.Drawing.Point(16, 317);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(645, 3);
            this.ultraLabel2.TabIndex = 46;
            // 
            // tEdit_OldSysCoopFolder
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.TextHAlignAsString = "Left";
            this.tEdit_OldSysCoopFolder.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Left";
            this.tEdit_OldSysCoopFolder.Appearance = appearance6;
            this.tEdit_OldSysCoopFolder.AutoSelect = true;
            this.tEdit_OldSysCoopFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_OldSysCoopFolder.DataText = "";
            this.tEdit_OldSysCoopFolder.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_OldSysCoopFolder.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 128, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_OldSysCoopFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_OldSysCoopFolder.Location = new System.Drawing.Point(351, 710);
            this.tEdit_OldSysCoopFolder.MaxLength = 128;
            this.tEdit_OldSysCoopFolder.Name = "tEdit_OldSysCoopFolder";
            this.tEdit_OldSysCoopFolder.Size = new System.Drawing.Size(51, 24);
            this.tEdit_OldSysCoopFolder.TabIndex = 26;
            this.tEdit_OldSysCoopFolder.Visible = false;
            // 
            // OldSysCoopFolder_Button
            // 
            this.OldSysCoopFolder_Button.Location = new System.Drawing.Point(685, 709);
            this.OldSysCoopFolder_Button.Name = "OldSysCoopFolder_Button";
            this.OldSysCoopFolder_Button.Size = new System.Drawing.Size(25, 24);
            this.OldSysCoopFolder_Button.TabIndex = 27;
            this.OldSysCoopFolder_Button.Visible = false;
            this.OldSysCoopFolder_Button.Click += new System.EventHandler(this.OldSysCoopFolder_Button_Click);
            // 
            // AutoAnswerDiv_uLabel
            // 
            appearance79.TextVAlignAsString = "Middle";
            this.AutoAnswerDiv_uLabel.Appearance = appearance79;
            this.AutoAnswerDiv_uLabel.Location = new System.Drawing.Point(506, 257);
            this.AutoAnswerDiv_uLabel.Name = "AutoAnswerDiv_uLabel";
            this.AutoAnswerDiv_uLabel.Size = new System.Drawing.Size(53, 24);
            this.AutoAnswerDiv_uLabel.TabIndex = 44;
            this.AutoAnswerDiv_uLabel.Text = "自動回答区分";
            this.AutoAnswerDiv_uLabel.Visible = false;
            // 
            // AutoAnswerDiv_tComboEditor
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance73.ForeColor = System.Drawing.Color.Black;
            appearance73.TextVAlignAsString = "Middle";
            this.AutoAnswerDiv_tComboEditor.ActiveAppearance = appearance73;
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance74.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance74.ForeColorDisabled = System.Drawing.Color.Black;
            this.AutoAnswerDiv_tComboEditor.Appearance = appearance74;
            this.AutoAnswerDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AutoAnswerDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AutoAnswerDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoAnswerDiv_tComboEditor.ItemAppearance = appearance75;
            this.AutoAnswerDiv_tComboEditor.Location = new System.Drawing.Point(565, 257);
            this.AutoAnswerDiv_tComboEditor.Name = "AutoAnswerDiv_tComboEditor";
            this.AutoAnswerDiv_tComboEditor.Size = new System.Drawing.Size(69, 24);
            this.AutoAnswerDiv_tComboEditor.TabIndex = 45;
            this.AutoAnswerDiv_tComboEditor.Visible = false;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel4.Location = new System.Drawing.Point(16, 214);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(645, 3);
            this.ultraLabel4.TabIndex = 40;
            // 
            // EstimatePrtDiv_tComEditor
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.EstimatePrtDiv_tComEditor.ActiveAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            this.EstimatePrtDiv_tComEditor.Appearance = appearance24;
            this.EstimatePrtDiv_tComEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.EstimatePrtDiv_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.EstimatePrtDiv_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.EstimatePrtDiv_tComEditor.ItemAppearance = appearance25;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "する";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "しない";
            this.EstimatePrtDiv_tComEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.EstimatePrtDiv_tComEditor.Location = new System.Drawing.Point(221, 141);
            this.EstimatePrtDiv_tComEditor.Name = "EstimatePrtDiv_tComEditor";
            this.EstimatePrtDiv_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.EstimatePrtDiv_tComEditor.TabIndex = 5;
            // 
            // EstimatePrtDiv_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.EstimatePrtDiv_uLabel.Appearance = appearance22;
            this.EstimatePrtDiv_uLabel.Location = new System.Drawing.Point(16, 141);
            this.EstimatePrtDiv_uLabel.Name = "EstimatePrtDiv_uLabel";
            this.EstimatePrtDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.EstimatePrtDiv_uLabel.TabIndex = 37;
            this.EstimatePrtDiv_uLabel.Text = "見積書発行区分";
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel3.Location = new System.Drawing.Point(16, 388);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(645, 3);
            this.ultraLabel3.TabIndex = 50;
            // 
            // tEdit_CashRegisterNo
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance39.TextHAlignAsString = "Right";
            this.tEdit_CashRegisterNo.ActiveAppearance = appearance39;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance40.ForeColorDisabled = System.Drawing.Color.Black;
            appearance40.TextHAlignAsString = "Right";
            this.tEdit_CashRegisterNo.Appearance = appearance40;
            this.tEdit_CashRegisterNo.AutoSelect = true;
            this.tEdit_CashRegisterNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_CashRegisterNo.DataText = "";
            this.tEdit_CashRegisterNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CashRegisterNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, false, false, true));
            this.tEdit_CashRegisterNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_CashRegisterNo.Location = new System.Drawing.Point(221, 399);
            this.tEdit_CashRegisterNo.MaxLength = 3;
            this.tEdit_CashRegisterNo.Name = "tEdit_CashRegisterNo";
            this.tEdit_CashRegisterNo.Size = new System.Drawing.Size(28, 24);
            this.tEdit_CashRegisterNo.TabIndex = 13;
            // 
            // tEdit_CashRegisterNoNm
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.tEdit_CashRegisterNoNm.ActiveAppearance = appearance2;
            appearance72.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance72.ForeColor = System.Drawing.Color.Black;
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            appearance72.TextHAlignAsString = "Left";
            this.tEdit_CashRegisterNoNm.Appearance = appearance72;
            this.tEdit_CashRegisterNoNm.AutoSelect = true;
            this.tEdit_CashRegisterNoNm.DataText = "";
            this.tEdit_CashRegisterNoNm.Enabled = false;
            this.tEdit_CashRegisterNoNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CashRegisterNoNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CashRegisterNoNm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_CashRegisterNoNm.Location = new System.Drawing.Point(270, 399);
            this.tEdit_CashRegisterNoNm.MaxLength = 10;
            this.tEdit_CashRegisterNoNm.Name = "tEdit_CashRegisterNoNm";
            this.tEdit_CashRegisterNoNm.ReadOnly = true;
            this.tEdit_CashRegisterNoNm.Size = new System.Drawing.Size(144, 24);
            this.tEdit_CashRegisterNoNm.TabIndex = 14;
            // 
            // ultraLabel7
            // 
            appearance71.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance71;
            this.ultraLabel7.Location = new System.Drawing.Point(16, 399);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel7.TabIndex = 49;
            this.ultraLabel7.Text = "受信処理起動端末番号";
            // 
            // ultraLabel9
            // 
            appearance49.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance49;
            this.ultraLabel9.Location = new System.Drawing.Point(16, 429);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel9.TabIndex = 51;
            this.ultraLabel9.Text = "受信処理起動間隔";
            // 
            // tEdit_RcvProcStInterval
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance50.TextHAlignAsString = "Right";
            this.tEdit_RcvProcStInterval.ActiveAppearance = appearance50;
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            appearance51.TextHAlignAsString = "Right";
            this.tEdit_RcvProcStInterval.Appearance = appearance51;
            this.tEdit_RcvProcStInterval.AutoSelect = true;
            this.tEdit_RcvProcStInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_RcvProcStInterval.DataText = "";
            this.tEdit_RcvProcStInterval.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_RcvProcStInterval.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, false, false, true));
            this.tEdit_RcvProcStInterval.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_RcvProcStInterval.Location = new System.Drawing.Point(221, 429);
            this.tEdit_RcvProcStInterval.MaxLength = 3;
            this.tEdit_RcvProcStInterval.Name = "tEdit_RcvProcStInterval";
            this.tEdit_RcvProcStInterval.Size = new System.Drawing.Size(28, 24);
            this.tEdit_RcvProcStInterval.TabIndex = 15;
            // 
            // ultraLabel10
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance13;
            this.ultraLabel10.Location = new System.Drawing.Point(271, 429);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel10.TabIndex = 16;
            this.ultraLabel10.Text = "分";
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel11.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel11.Location = new System.Drawing.Point(16, 459);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(645, 3);
            this.ultraLabel11.TabIndex = 52;
            // 
            // ultraLabel12
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance48;
            this.ultraLabel12.Location = new System.Drawing.Point(16, 471);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(199, 24);
            this.ultraLabel12.TabIndex = 53;
            this.ultraLabel12.Text = "販売区分設定(自動回答時)";
            // 
            // ultraLabel13
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance10;
            this.ultraLabel13.Location = new System.Drawing.Point(16, 501);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel13.TabIndex = 54;
            this.ultraLabel13.Text = "販売区分コード";
            // 
            // SalesCdStAutoAns_tComboEditor
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.SalesCdStAutoAns_tComboEditor.ActiveAppearance = appearance43;
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance44.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.SalesCdStAutoAns_tComboEditor.Appearance = appearance44;
            this.SalesCdStAutoAns_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SalesCdStAutoAns_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SalesCdStAutoAns_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SalesCdStAutoAns_tComboEditor.ItemAppearance = appearance70;
            this.SalesCdStAutoAns_tComboEditor.Location = new System.Drawing.Point(221, 471);
            this.SalesCdStAutoAns_tComboEditor.Name = "SalesCdStAutoAns_tComboEditor";
            this.SalesCdStAutoAns_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.SalesCdStAutoAns_tComboEditor.TabIndex = 17;
            this.SalesCdStAutoAns_tComboEditor.ValueChanged += new System.EventHandler(this.SalesCdStAutoAns_tComboEditor_ValueChanged);
            // 
            // SalesCode_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.SalesCode_tNedit.ActiveAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.SalesCode_tNedit.Appearance = appearance9;
            this.SalesCode_tNedit.AutoSelect = true;
            this.SalesCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SalesCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SalesCode_tNedit.DataText = "";
            this.SalesCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SalesCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.SalesCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SalesCode_tNedit.Location = new System.Drawing.Point(221, 501);
            this.SalesCode_tNedit.MaxLength = 4;
            this.SalesCode_tNedit.Name = "SalesCode_tNedit";
            this.SalesCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.SalesCode_tNedit.Size = new System.Drawing.Size(66, 24);
            this.SalesCode_tNedit.TabIndex = 18;
            // 
            // uButton_SalesCode
            // 
            appearance127.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance127.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_SalesCode.Appearance = appearance127;
            this.uButton_SalesCode.Location = new System.Drawing.Point(319, 502);
            this.uButton_SalesCode.Name = "uButton_SalesCode";
            this.uButton_SalesCode.Size = new System.Drawing.Size(24, 23);
            this.uButton_SalesCode.TabIndex = 19;
            this.uButton_SalesCode.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesCode.Click += new System.EventHandler(this.uButton_SalesCode_Click);
            // 
            // AutoAnsHourDspDiv_tComboEditor
            // 
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance89.ForeColor = System.Drawing.Color.Black;
            appearance89.TextVAlignAsString = "Middle";
            this.AutoAnsHourDspDiv_tComboEditor.ActiveAppearance = appearance89;
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance90.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance90.ForeColorDisabled = System.Drawing.Color.Black;
            this.AutoAnsHourDspDiv_tComboEditor.Appearance = appearance90;
            this.AutoAnsHourDspDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AutoAnsHourDspDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AutoAnsHourDspDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoAnsHourDspDiv_tComboEditor.ItemAppearance = appearance91;
            this.AutoAnsHourDspDiv_tComboEditor.Location = new System.Drawing.Point(221, 531);
            this.AutoAnsHourDspDiv_tComboEditor.Name = "AutoAnsHourDspDiv_tComboEditor";
            this.AutoAnsHourDspDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.AutoAnsHourDspDiv_tComboEditor.TabIndex = 20;
            // 
            // AutoAnsHourDspDiv_uLabel
            // 
            appearance92.TextVAlignAsString = "Middle";
            this.AutoAnsHourDspDiv_uLabel.Appearance = appearance92;
            this.AutoAnsHourDspDiv_uLabel.Location = new System.Drawing.Point(16, 531);
            this.AutoAnsHourDspDiv_uLabel.Name = "AutoAnsHourDspDiv_uLabel";
            this.AutoAnsHourDspDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.AutoAnsHourDspDiv_uLabel.TabIndex = 55;
            this.AutoAnsHourDspDiv_uLabel.Text = "自動回答時表示区分";
            // 
            // AutoAnsInquiryDiv_tComboEditor
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance55.ForeColor = System.Drawing.Color.Black;
            appearance55.TextVAlignAsString = "Middle";
            this.AutoAnsInquiryDiv_tComboEditor.ActiveAppearance = appearance55;
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance61.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            this.AutoAnsInquiryDiv_tComboEditor.Appearance = appearance61;
            this.AutoAnsInquiryDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AutoAnsInquiryDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AutoAnsInquiryDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoAnsInquiryDiv_tComboEditor.ItemAppearance = appearance64;
            this.AutoAnsInquiryDiv_tComboEditor.Location = new System.Drawing.Point(221, 223);
            this.AutoAnsInquiryDiv_tComboEditor.Name = "AutoAnsInquiryDiv_tComboEditor";
            this.AutoAnsInquiryDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.AutoAnsInquiryDiv_tComboEditor.TabIndex = 7;
            // 
            // AutoAnsInquiryDiv_uLabel
            // 
            appearance65.TextVAlignAsString = "Middle";
            this.AutoAnsInquiryDiv_uLabel.Appearance = appearance65;
            this.AutoAnsInquiryDiv_uLabel.Location = new System.Drawing.Point(16, 223);
            this.AutoAnsInquiryDiv_uLabel.Name = "AutoAnsInquiryDiv_uLabel";
            this.AutoAnsInquiryDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.AutoAnsInquiryDiv_uLabel.TabIndex = 41;
            this.AutoAnsInquiryDiv_uLabel.Text = "自動回答区分(問合せ)";
            // 
            // AutoAnsOrderDiv_tComboEditor
            // 
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance80.ForeColor = System.Drawing.Color.Black;
            appearance80.TextVAlignAsString = "Middle";
            this.AutoAnsOrderDiv_tComboEditor.ActiveAppearance = appearance80;
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance81.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance81.ForeColorDisabled = System.Drawing.Color.Black;
            this.AutoAnsOrderDiv_tComboEditor.Appearance = appearance81;
            this.AutoAnsOrderDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AutoAnsOrderDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AutoAnsOrderDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance82.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AutoAnsOrderDiv_tComboEditor.ItemAppearance = appearance82;
            this.AutoAnsOrderDiv_tComboEditor.Location = new System.Drawing.Point(221, 253);
            this.AutoAnsOrderDiv_tComboEditor.Name = "AutoAnsOrderDiv_tComboEditor";
            this.AutoAnsOrderDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.AutoAnsOrderDiv_tComboEditor.TabIndex = 8;
            // 
            // AutoAnsOrderDiv_uLabel
            // 
            appearance83.TextVAlignAsString = "Middle";
            this.AutoAnsOrderDiv_uLabel.Appearance = appearance83;
            this.AutoAnsOrderDiv_uLabel.Location = new System.Drawing.Point(16, 253);
            this.AutoAnsOrderDiv_uLabel.Name = "AutoAnsOrderDiv_uLabel";
            this.AutoAnsOrderDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.AutoAnsOrderDiv_uLabel.TabIndex = 42;
            this.AutoAnsOrderDiv_uLabel.Text = "自動回答区分(発注)";
            // 
            // DeliveredGoodsDiv_tComboEditor
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DeliveredGoodsDiv_tComboEditor.ActiveAppearance = appearance14;
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance33.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.ForeColorDisabled = System.Drawing.Color.Black;
            this.DeliveredGoodsDiv_tComboEditor.Appearance = appearance33;
            this.DeliveredGoodsDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DeliveredGoodsDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DeliveredGoodsDiv_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DeliveredGoodsDiv_tComboEditor.ItemAppearance = appearance15;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "0:しない ";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "1:する";
            this.DeliveredGoodsDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.DeliveredGoodsDiv_tComboEditor.LimitToList = true;
            this.DeliveredGoodsDiv_tComboEditor.Location = new System.Drawing.Point(221, 604);
            this.DeliveredGoodsDiv_tComboEditor.Name = "DeliveredGoodsDiv_tComboEditor";
            this.DeliveredGoodsDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.DeliveredGoodsDiv_tComboEditor.TabIndex = 24;
            // 
            // DeliveredGoodsDiv_Label
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.DeliveredGoodsDiv_Label.Appearance = appearance12;
            this.DeliveredGoodsDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DeliveredGoodsDiv_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.DeliveredGoodsDiv_Label.Location = new System.Drawing.Point(16, 604);
            this.DeliveredGoodsDiv_Label.Name = "DeliveredGoodsDiv_Label";
            this.DeliveredGoodsDiv_Label.Size = new System.Drawing.Size(124, 23);
            this.DeliveredGoodsDiv_Label.TabIndex = 58;
            this.DeliveredGoodsDiv_Label.Text = "納品区分";
            // 
            // tEdit_FrontEmployeeCd
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance26.TextHAlignAsString = "Right";
            this.tEdit_FrontEmployeeCd.ActiveAppearance = appearance26;
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance38.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextHAlignAsString = "Right";
            this.tEdit_FrontEmployeeCd.Appearance = appearance38;
            this.tEdit_FrontEmployeeCd.AutoSelect = true;
            this.tEdit_FrontEmployeeCd.AutoSize = false;
            this.tEdit_FrontEmployeeCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_FrontEmployeeCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tEdit_FrontEmployeeCd.DataText = "";
            this.tEdit_FrontEmployeeCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FrontEmployeeCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_FrontEmployeeCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.tEdit_FrontEmployeeCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tEdit_FrontEmployeeCd.Location = new System.Drawing.Point(221, 575);
            this.tEdit_FrontEmployeeCd.MaxLength = 4;
            this.tEdit_FrontEmployeeCd.Name = "tEdit_FrontEmployeeCd";
            this.tEdit_FrontEmployeeCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tEdit_FrontEmployeeCd.Size = new System.Drawing.Size(60, 24);
            this.tEdit_FrontEmployeeCd.TabIndex = 21;
            // 
            // tEdit_FrontEmployeeNm
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_FrontEmployeeNm.ActiveAppearance = appearance16;
            this.tEdit_FrontEmployeeNm.AutoSelect = true;
            this.tEdit_FrontEmployeeNm.DataText = "";
            this.tEdit_FrontEmployeeNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_FrontEmployeeNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_FrontEmployeeNm.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.tEdit_FrontEmployeeNm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_FrontEmployeeNm.Location = new System.Drawing.Point(318, 575);
            this.tEdit_FrontEmployeeNm.MaxLength = 12;
            this.tEdit_FrontEmployeeNm.Name = "tEdit_FrontEmployeeNm";
            this.tEdit_FrontEmployeeNm.ReadOnly = true;
            this.tEdit_FrontEmployeeNm.Size = new System.Drawing.Size(211, 24);
            this.tEdit_FrontEmployeeNm.TabIndex = 23;
            // 
            // FrontEmployee_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.FrontEmployee_Label.Appearance = appearance3;
            this.FrontEmployee_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FrontEmployee_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.FrontEmployee_Label.Location = new System.Drawing.Point(16, 575);
            this.FrontEmployee_Label.Name = "FrontEmployee_Label";
            this.FrontEmployee_Label.Size = new System.Drawing.Size(144, 23);
            this.FrontEmployee_Label.TabIndex = 57;
            this.FrontEmployee_Label.Text = "受注者";
            // 
            // FuwioutAutoAnsDiv_tComboEditor
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.FuwioutAutoAnsDiv_tComboEditor.ActiveAppearance = appearance7;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.FuwioutAutoAnsDiv_tComboEditor.Appearance = appearance11;
            this.FuwioutAutoAnsDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.FuwioutAutoAnsDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FuwioutAutoAnsDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FuwioutAutoAnsDiv_tComboEditor.ItemAppearance = appearance46;
            this.FuwioutAutoAnsDiv_tComboEditor.Location = new System.Drawing.Point(221, 283);
            this.FuwioutAutoAnsDiv_tComboEditor.Name = "FuwioutAutoAnsDiv_tComboEditor";
            this.FuwioutAutoAnsDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.FuwioutAutoAnsDiv_tComboEditor.TabIndex = 9;
            // 
            // ultraLabel14
            // 
            appearance47.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance47;
            this.ultraLabel14.Location = new System.Drawing.Point(16, 283);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel14.TabIndex = 43;
            this.ultraLabel14.Text = "該当なし自動回答";
            // 
            // DataUpdWarehouseDiv_tComboEditor
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance52.ForeColor = System.Drawing.Color.Black;
            appearance52.TextVAlignAsString = "Middle";
            this.DataUpdWarehouseDiv_tComboEditor.ActiveAppearance = appearance52;
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance53.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            this.DataUpdWarehouseDiv_tComboEditor.Appearance = appearance53;
            this.DataUpdWarehouseDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DataUpdWarehouseDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DataUpdWarehouseDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DataUpdWarehouseDiv_tComboEditor.ItemAppearance = appearance54;
            this.DataUpdWarehouseDiv_tComboEditor.Location = new System.Drawing.Point(221, 663);
            this.DataUpdWarehouseDiv_tComboEditor.Name = "DataUpdWarehouseDiv_tComboEditor";
            this.DataUpdWarehouseDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.DataUpdWarehouseDiv_tComboEditor.TabIndex = 290;
            // 
            // DataUpdWarehouseDiv_uLabel
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.DataUpdWarehouseDiv_uLabel.Appearance = appearance63;
            this.DataUpdWarehouseDiv_uLabel.Location = new System.Drawing.Point(16, 663);
            this.DataUpdWarehouseDiv_uLabel.Name = "DataUpdWarehouseDiv_uLabel";
            this.DataUpdWarehouseDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.DataUpdWarehouseDiv_uLabel.TabIndex = 292;
            this.DataUpdWarehouseDiv_uLabel.Text = "データ更新倉庫区分";
            // 
            // tEdit_SalesInputCode
            // 
            appearance84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance84.TextHAlignAsString = "Right";
            this.tEdit_SalesInputCode.ActiveAppearance = appearance84;
            appearance85.BackColor = System.Drawing.Color.White;
            appearance85.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance85.ForeColor = System.Drawing.Color.Black;
            appearance85.ForeColorDisabled = System.Drawing.Color.Black;
            appearance85.TextHAlignAsString = "Right";
            this.tEdit_SalesInputCode.Appearance = appearance85;
            this.tEdit_SalesInputCode.AutoSelect = true;
            this.tEdit_SalesInputCode.AutoSize = false;
            this.tEdit_SalesInputCode.BackColor = System.Drawing.Color.White;
            this.tEdit_SalesInputCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tEdit_SalesInputCode.DataText = "";
            this.tEdit_SalesInputCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesInputCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SalesInputCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.tEdit_SalesInputCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tEdit_SalesInputCode.Location = new System.Drawing.Point(221, 633);
            this.tEdit_SalesInputCode.MaxLength = 4;
            this.tEdit_SalesInputCode.Name = "tEdit_SalesInputCode";
            this.tEdit_SalesInputCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tEdit_SalesInputCode.Size = new System.Drawing.Size(60, 24);
            this.tEdit_SalesInputCode.TabIndex = 287;
            // 
            // tEdit_SalesInputNm
            // 
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SalesInputNm.ActiveAppearance = appearance86;
            this.tEdit_SalesInputNm.AutoSelect = true;
            this.tEdit_SalesInputNm.DataText = "";
            this.tEdit_SalesInputNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SalesInputNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SalesInputNm.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.tEdit_SalesInputNm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SalesInputNm.Location = new System.Drawing.Point(318, 633);
            this.tEdit_SalesInputNm.MaxLength = 12;
            this.tEdit_SalesInputNm.Name = "tEdit_SalesInputNm";
            this.tEdit_SalesInputNm.ReadOnly = true;
            this.tEdit_SalesInputNm.Size = new System.Drawing.Size(211, 24);
            this.tEdit_SalesInputNm.TabIndex = 289;
            // 
            // SalesInputCode_Label
            // 
            appearance88.TextVAlignAsString = "Middle";
            this.SalesInputCode_Label.Appearance = appearance88;
            this.SalesInputCode_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SalesInputCode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F);
            this.SalesInputCode_Label.Location = new System.Drawing.Point(16, 633);
            this.SalesInputCode_Label.Name = "SalesInputCode_Label";
            this.SalesInputCode_Label.Size = new System.Drawing.Size(144, 23);
            this.SalesInputCode_Label.TabIndex = 291;
            this.SalesInputCode_Label.Text = "発行者";
            // 
            // PMSCM09020UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(713, 766);
            this.Controls.Add(this.DataUpdWarehouseDiv_tComboEditor);
            this.Controls.Add(this.DataUpdWarehouseDiv_uLabel);
            this.Controls.Add(this.tEdit_SalesInputCode);
            this.Controls.Add(this.tEdit_SalesInputNm);
            this.Controls.Add(this.uButtonSalesInputCodeGuid);
            this.Controls.Add(this.SalesInputCode_Label);
            this.Controls.Add(this.FuwioutAutoAnsDiv_tComboEditor);
            this.Controls.Add(this.ultraLabel14);
            this.Controls.Add(this.DeliveredGoodsDiv_tComboEditor);
            this.Controls.Add(this.DeliveredGoodsDiv_Label);
            this.Controls.Add(this.tEdit_FrontEmployeeCd);
            this.Controls.Add(this.tEdit_FrontEmployeeNm);
            this.Controls.Add(this.uButtonFrontEmployeeCdGuid);
            this.Controls.Add(this.FrontEmployee_Label);
            this.Controls.Add(this.AutoAnsInquiryDiv_tComboEditor);
            this.Controls.Add(this.AutoAnsInquiryDiv_uLabel);
            this.Controls.Add(this.AutoAnsOrderDiv_tComboEditor);
            this.Controls.Add(this.AutoAnsOrderDiv_uLabel);
            this.Controls.Add(this.AutoAnsHourDspDiv_tComboEditor);
            this.Controls.Add(this.AutoAnsHourDspDiv_uLabel);
            this.Controls.Add(this.uButton_SalesCode);
            this.Controls.Add(this.SalesCode_tNedit);
            this.Controls.Add(this.SalesCdStAutoAns_tComboEditor);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.ultraLabel11);
            this.Controls.Add(this.ultraLabel10);
            this.Controls.Add(this.ultraLabel9);
            this.Controls.Add(this.tEdit_RcvProcStInterval);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.tEdit_CashRegisterNo);
            this.Controls.Add(this.tEdit_CashRegisterNoNm);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.EstimatePrtDiv_tComEditor);
            this.Controls.Add(this.EstimatePrtDiv_uLabel);
            this.Controls.Add(this.tEdit_OldSysCoopFolder);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.OldSysCoopFolder_Button);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.AutoAnswerDiv_tComboEditor);
            this.Controls.Add(this.BLCodeChgDiv_tComboEditor);
            this.Controls.Add(this.SalesSlipPrtDiv_tComboEditor);
            this.Controls.Add(this.OldSysCoopFolder_uLabel);
            this.Controls.Add(this.AutoAnswerDiv_uLabel);
            this.Controls.Add(this.BLCodeChgDiv_uLabel);
            this.Controls.Add(this.SalesSlipPrtDiv_uLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.Section_uLabel);
            this.Controls.Add(this.OldSysCooperatDiv_tComEditor);
            this.Controls.Add(this.OldSysCooperatDiv_uLabel);
            this.Controls.Add(this.AcpOdrrSlipPrtDiv_tComEditor);
            this.Controls.Add(this.AcpOdrrSlipPrtDiv_uLabel);
            this.Controls.Add(this.DiscountApplyCd_tComEditor);
            this.Controls.Add(this.DiscountApplyCd_uLabel);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.AutoCooperatDis_tNedit);
            this.Controls.Add(this.AutoCooperatDis_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMSCM09020UA";
            this.Text = "PCC全体設定";
            this.Load += new System.EventHandler(this.PMSCM09020UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMSCM09020UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMSCM09020UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.AutoCooperatDis_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountApplyCd_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcpOdrrSlipPrtDiv_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OldSysCooperatDiv_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipPrtDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLCodeChgDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OldSysCoopFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnswerDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstimatePrtDiv_tComEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CashRegisterNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CashRegisterNoNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_RcvProcStInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCdStAutoAns_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnsHourDspDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnsInquiryDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoAnsOrderDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveredGoodsDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_FrontEmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FuwioutAutoAnsDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataUpdWarehouseDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SalesInputNm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region -- Events --
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region -- Private Members --
		private SCMTtlStAcs _scmTtlStAcs;
        private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _scmTtlStTable;
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        private UserGuideAcs _userGuideAcs = null;			// ユーザーガイドアクセスクラス
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        private SecInfoAcs _secInfoAcs;

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        // 従業員マスタアクセスクラス
        private EmployeeAcs _employeeAcs;
        private Hashtable _employeeTb = null;
        private Hashtable _userGdBdTb;
        /// <summary>
        /// ガイド区分=48:納品区分
        /// </summary>
        private const int USERGUIDEDIVCD = 48;
        private int _preFrontEmployeeCd = 0;
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        private int _preSalesInputCode = 0;//ADD 2013/04/11 wangl2 FOR RedMine#35269 

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        
		// 保存比較用Clone
		private SCMTtlSt _scmTtlStClone;

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;

        // 新規モードからモード変更対応
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;

        private const string PROGRAM_ID = "PMSCM09020U";    // プログラムID

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";

		// FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";

        private const string VIEW_SECTION_CODE_TITLE = "拠点コード";
        private const string VIEW_SECTION_NAME_TITLE = "拠点名称";

        private const string VIEW_SALES_SLIP_PRT_DIV_TITLE = "売上伝票発行区分";
        private const string VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE = "受注伝票発行区分";
        private const string VIEW_ESTIMATE_PRT_DIV_TITLE = "見積書発行区分";
        //---DEL 2011/09/16 --------------------------->>>>>
        //private const string VIEW_OLD_SYS_COOPERAT_DIV_TITLE = "旧システム連携区分";
        //private const string VIEW_OLD_SYS_COOP_FOLDER_TITLE = "旧システム連携用フォルダ";
        //---DEL 2011/09/16 ---------------------------<<<<<
        private const string VIEW_BL_CODE_CHG_DIV_TITLE = "BLコード変換";
        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        //private const string VIEW_AUTO_ANSWER_DIV = "自動回答区分";
        private const string VIEW_AUTO_ANSINQUIRY_DIV = "自動回答区分(問合せ)";
        private const string VIEW_AUTO_ANSORDER_DIV = "自動回答区分(発注)";
        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
        private const string VIEW_DISCOUNT_APPLY_CD_TITLE = "値引適用区分";
        private const string VIEW_AUTO_COOPERAT_DIS_TITLE = "自動連携値引";
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        private const string VIEW_SALESCD_ST_AUTO_ANS_TITLE = "販売区分設定";
        private const string VIEW_SALES_CODE_TITLE = "販売区分";
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        private const string VIEW_AUTO_ANSWER_PRICE_DIV = "自動回答時表示区分";
        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        private const string VIEW_FRONTEMPLOYEECD_TITLE = "受付従業員コード";
        private const string VIEW_FRONTEMPLOYEENM_TITLE = "受付従業員名称";
        private const string VIEW_DELIVEREDGOODSDIV_TITLE = "納品区分";
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
        private const string VIEW_FUWIOUTAUTOANSDIV_TITLE = "該当無自動回答区分";
        // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

        private const string VIEW_DATA_UPD_WAREHOUSE_DIV = "データ更新倉庫区分"; // ADD 2013/02/27 qijh #34752

        private const string VIEW_GUID_KEY_TITLE = "Guid";
        // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
        private const string VIEW_SALESINPUTCODE_TITLE = "発行者コード";
        private const string VIEW_SALESINPUTCODENM_TITLE = "発行者名称";
        // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
		
		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";	   
		private const string DELETE_MODE = "削除モード";

        // 全社共通
        private const string ALL_SECTIONCODE = "00";

        private bool isError = false; // ADD 2011/09/08

		#endregion

		#region -- Main --
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMSCM09020UA());
		}
		# endregion

		#region -- Properties --
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get
			{ 
				return this._canPrint; 
			}
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{ 
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get
			{
				return this._canClose;
			}
			set
			{ 
				this._canClose = value; 
			}
		}

		/// <summary>新規登録可能設定プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get
			{
				return this._canNew;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
			}
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DataIndex
		{
			get
			{ 
				return this._dataIndex;
			}
			set
			{
				this._dataIndex = value;
			}
		}

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{ 
				return this._defaultAutoFillToColumn;
			}
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}
		#endregion

		#region -- Public Methods --
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note		: フレーム側のグリッドにバインドさせるデータセットを取得します。</br>
		/// <br></br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = VIEW_TABLE;
		}
		
		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
		///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br></br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList retList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._scmTtlStTable.Clear();

            // 全検索
            status = this._scmTtlStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

			switch(status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    int index = 0;

                    foreach (SCMTtlSt scmTtlSt in retList)
					{
                        // SCM全体設定情報クラスのデータセット展開処理
                        SCMTtlStToDataSet(scmTtlSt.Clone(), index);
						++index;
					}
					break;
				}

				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}

				default:
				{
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                        PROGRAM_ID,							    // アセンブリID
                        this.Text,              　　            // プログラム名称
						"Search",                               // 処理名称
						TMsgDisp.OPE_GET,                       // オペレーション
						"読み込みに失敗しました。",				// 表示するメッセージ
						status,									// ステータス値
						this._scmTtlStAcs,					    // エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン

					break;
				}
			}
			return status;
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定した件数分のネクストデータを検索します。</br>
		/// <br></br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
            // 実装なし
            return 9;
        }

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note        : 選択中のデータを削除します。</br>
		/// <br></br>
		/// </remarks>
		public int Delete()
		{
            // 保持しているデータセットより修正前情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMTtlSt scmTtlSt = (SCMTtlSt)this._scmTtlStTable[guid];

            // 全社共通データは削除不可
            if (scmTtlSt.SectionCode.Trim() == ALL_SECTIONCODE)
            {
                TMsgDisp.Show(this,                             // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
                        PROGRAM_ID,							    // アセンブリID
                        "全社共通データは削除できません。",	    // 表示するメッセージ
                        0,									    // ステータス値
                        MessageBoxButtons.OK);					// 表示するボタン
                return (0);
            }
            
            int status;

            // SCM全体設定情報の論理削除処理
            status = this._scmTtlStAcs.LogicalDelete(ref scmTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // 論理削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete", 							// 処理名称
                            TMsgDisp.OPE_HIDE, 					// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmTtlStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // SCM全体設定情報クラスのデータセット展開処理
            SCMTtlStToDataSet(scmTtlSt.Clone(), this.DataIndex);

            return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note        : 印刷処理を実行します。(未実装)</br>
		/// <br></br>
		/// </remarks>
		public int Print()
		{
			return 0;
		}

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note        : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Update Note : 2011/09/16 鄧潘ハン</br>
        /// <br>              障害報告 #25177 PCCUOE／PM側　PCC全体設定マスタの仕様変更</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            // 削除日
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // 拠点コード
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 拠点名称
			appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // 売上伝票発行区分
            appearanceTable.Add(VIEW_SALES_SLIP_PRT_DIV_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // 受注伝票発行区分
            appearanceTable.Add(VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 見積書発行区分
            appearanceTable.Add(VIEW_ESTIMATE_PRT_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //---DEL 2011/09/16 --------------------------->>>>>
            //// 旧システム連携区分
            //appearanceTable.Add(VIEW_OLD_SYS_COOPERAT_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //// 旧システム連携用フォルダ
            //appearanceTable.Add(VIEW_OLD_SYS_COOP_FOLDER_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //---DEL 2011/09/16 ---------------------------<<<<<
            // BLコード変換
            appearanceTable.Add(VIEW_BL_CODE_CHG_DIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 2010/05/21 Add >>>
            // 自動回答区分
            //appearanceTable.Add(VIEW_AUTO_ANSWER_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自動回答区分は、SCM自動回答オプションが契約されている場合のみ表示する
            PurchaseStatus psAutoAnswer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCMAutoAnswer);
            if (psAutoAnswer == PurchaseStatus.Contract || psAutoAnswer == PurchaseStatus.Trial_Contract)
            {
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                //appearanceTable.Add(VIEW_AUTO_ANSWER_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(VIEW_AUTO_ANSINQUIRY_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(VIEW_AUTO_ANSORDER_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
            }
            else
            {
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                //appearanceTable.Add(VIEW_AUTO_ANSWER_DIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(VIEW_AUTO_ANSINQUIRY_DIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(VIEW_AUTO_ANSORDER_DIV, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
                // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
            }
            // 2010/05/21 Add <<<

            // 値引適用区分
            appearanceTable.Add(VIEW_DISCOUNT_APPLY_CD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 自動連携値引
            appearanceTable.Add(VIEW_AUTO_COOPERAT_DIS_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // 販売区分設定
            appearanceTable.Add(VIEW_SALESCD_ST_AUTO_ANS_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 販売区分コード
            appearanceTable.Add(VIEW_SALES_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            appearanceTable.Add(VIEW_AUTO_ANSWER_PRICE_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            // 受付従業員コード
            appearanceTable.Add(VIEW_FRONTEMPLOYEECD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 受付従業員名称
            appearanceTable.Add(VIEW_FRONTEMPLOYEENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 納品区分
            appearanceTable.Add(VIEW_DELIVEREDGOODSDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            // 該当無自動回答区分
            appearanceTable.Add(VIEW_FUWIOUTAUTOANSDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
            // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
            // 売上入力者コード
            appearanceTable.Add(VIEW_SALESINPUTCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 売上入力者名称
            appearanceTable.Add(VIEW_SALESINPUTCODENM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            //自動回答時表示区分
            appearanceTable.Add(VIEW_DATA_UPD_WAREHOUSE_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

			return appearanceTable;
		}
		# endregion

		#region -- Private Methods --
        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : モードに基づいて画面の再構築を行います。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            this.SetDelivereds(this._enterpriseCode);
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            if (this.DataIndex < 0)
            {
                SCMTtlSt scmTtlSt = new SCMTtlSt();
                //クローン作成
                this._scmTtlStClone = scmTtlSt.Clone();
                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                ScreenToSCMTtlSt(ref this._scmTtlStClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.tEdit_SectionCodeAllowZero2.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SCMTtlSt scmTtlSt = (SCMTtlSt)this._scmTtlStTable[guid];

                // SCM全体設定クラス画面展開処理
                SCMTtlStToScreen(scmTtlSt);

                if (scmTtlSt.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.SalesSlipPrtDiv_tComboEditor.Focus();

                    // クローン作成
                    this._scmTtlStClone = scmTtlSt.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    ScreenToSCMTtlSt(ref this._scmTtlStClone);
                }
                else
                {
                    // 削除状態の時
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(DELETE_MODE);

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// 画面入力許可制御処理
        /// </summary>
        /// <param name="mode">モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;
                        this.SectionName_tEdit.Enabled = false;
                        this.SalesSlipPrtDiv_tComboEditor.Enabled = true;
                        this.AcpOdrrSlipPrtDiv_tComEditor.Enabled = true;
                        this.EstimatePrtDiv_tComEditor.Enabled = true;
                        this.OldSysCooperatDiv_tComEditor.Enabled = true;

                        if (OldSysCooperatDiv_tComEditor.SelectedIndex == 0)
                        {
                            this.tEdit_OldSysCoopFolder.Enabled = false;
                        }
                        else
                        {
                            this.tEdit_OldSysCoopFolder.Enabled = true;
                        }

                        this.OldSysCoopFolder_Button.Enabled = true;
                        this.BLCodeChgDiv_tComboEditor.Enabled = true;
                        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                        //this.AutoAnswerDiv_tComboEditor.Enabled = true;
                        this.AutoAnsInquiryDiv_tComboEditor.Enabled = true;
                        this.AutoAnsOrderDiv_tComboEditor.Enabled = true;
                        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
                        this.DiscountApplyCd_tComEditor.Enabled = true;

                        if (DiscountApplyCd_tComEditor.SelectedIndex == 0)
                        {
                            this.AutoCooperatDis_tNedit.Enabled = false;
                        }
                        else
                        {
                            this.AutoCooperatDis_tNedit.Enabled = true;
                        }
                        //2012/04/20 ADD T.Nishi >>>>>>>>>>
                        this.SalesCdStAutoAns_tComboEditor.Enabled = true;
                        if (SalesCdStAutoAns_tComboEditor.SelectedIndex == 0)
                        {
                            this.SalesCode_tNedit.Enabled = false;
                            this.uButton_SalesCode.Enabled = false;
                        }
                        else
                        {
                            this.SalesCode_tNedit.Enabled = true;
                            this.uButton_SalesCode.Enabled = true;
                        }
                        //2012/04/20 ADD T.Nishi <<<<<<<<<<
                        
                        if (mode == INSERT_MODE)
                        {
                            // 新規モード
                            this.tEdit_SectionCodeAllowZero2.Enabled = true;
                            this.SectionGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // 更新モード
                            this.tEdit_SectionCodeAllowZero2.Enabled = false;
                            this.SectionGuide_Button.Enabled = false;
                        }
                        this.tEdit_CashRegisterNo.Enabled = true;
                        this.tEdit_RcvProcStInterval.Enabled = true;

                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        this.AutoAnsHourDspDiv_tComboEditor.Enabled = true;
                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                        this.tEdit_FrontEmployeeCd.Enabled = true;
                        this.uButtonFrontEmployeeCdGuid.Enabled = true;
                        this.DeliveredGoodsDiv_tComboEditor.Enabled = true;
                        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                        // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                        this.FuwioutAutoAnsDiv_tComboEditor.Enabled = true;
                        // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                        // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
                        this.tEdit_SalesInputCode.Enabled = true;
                        this.uButtonSalesInputCodeGuid.Enabled = true;
                        // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
                        this.DataUpdWarehouseDiv_tComboEditor.Enabled = true; // ADD 2013/02/27 qijh #34752

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;
                        this.tEdit_SectionCodeAllowZero2.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.SectionName_tEdit.Enabled = false;
                        this.SalesSlipPrtDiv_tComboEditor.Enabled = false;
                        this.AcpOdrrSlipPrtDiv_tComEditor.Enabled = false;
                        this.EstimatePrtDiv_tComEditor.Enabled = false;
                        this.OldSysCooperatDiv_tComEditor.Enabled = false;
                        this.tEdit_OldSysCoopFolder.Enabled = false;
                        this.OldSysCoopFolder_Button.Enabled = false;
                        this.BLCodeChgDiv_tComboEditor.Enabled = false;
                        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                        //this.AutoAnswerDiv_tComboEditor.Enabled = false;
                        this.AutoAnsInquiryDiv_tComboEditor.Enabled = false;
                        this.AutoAnsOrderDiv_tComboEditor.Enabled = false;
                        // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
                        this.DiscountApplyCd_tComEditor.Enabled = false;
                        this.AutoCooperatDis_tNedit.Enabled = false;
                        //>>>2010/08/03
                        this.tEdit_CashRegisterNo.Enabled = false;
                        this.tEdit_CashRegisterNoNm.Enabled = false;
                        this.tEdit_RcvProcStInterval.Enabled = false;
                        //<<<2010/08/03
                        //2012/04/20 ADD T.Nishi >>>>>>>>>>
                        this.SalesCode_tNedit.Enabled = false;
                        this.uButton_SalesCode.Enabled = false;
                        this.SalesCdStAutoAns_tComboEditor.Enabled = false;
                        //2012/04/20 ADD T.Nishi <<<<<<<<<<

                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        this.AutoAnsHourDspDiv_tComboEditor.Enabled = false;
                        // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                        this.tEdit_FrontEmployeeCd.Enabled = false;
                        this.uButtonFrontEmployeeCdGuid.Enabled = false;
                        this.DeliveredGoodsDiv_tComboEditor.Enabled = false;
                        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

                        // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                        this.FuwioutAutoAnsDiv_tComboEditor.Enabled = false;
                        // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
                        // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
                        this.tEdit_SalesInputCode.Enabled = false;
                        this.uButtonSalesInputCodeGuid.Enabled = false;
                        // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
                        this.DataUpdWarehouseDiv_tComboEditor.Enabled = false; // ADD 2013/02/27 qijh #34752

                        break;
                    }
            }
        }

		/// <summary>
		/// SCM全体設定オブジェクトデータセット展開処理
		/// </summary>
        /// <param name="scmTtlSt">SCM全体設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : SCM全体設定クラスをデータセットに格納します。</br>
        /// <br>Update Note: 2011/09/16 鄧潘ハン</br>
        /// <br>             障害報告 #25177 PCCUOE／PM側　PCC全体設定マスタの仕様変更</br>
		/// </remarks>
		private void SCMTtlStToDataSet(SCMTtlSt scmTtlSt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

            if (scmTtlSt.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = scmTtlSt.UpdateDateTimeJpInFormal;
            }

			// 拠点コード
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = scmTtlSt.SectionCode;
            // 拠点名称
            string sectionName = GetSectionName(scmTtlSt.SectionCode);
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;

            // 売上伝票発行区分
            switch (scmTtlSt.SalesSlipPrtDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_SLIP_PRT_DIV_TITLE] = "しない";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_SLIP_PRT_DIV_TITLE] = "する";
                    break;
            }

            // 受注伝票発行区分
            switch (scmTtlSt.AcpOdrrSlipPrtDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE] = "しない";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE] = "する";
                    break;
            }

            // 見積書発行区分
            switch (scmTtlSt.EstimatePrtDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ESTIMATE_PRT_DIV_TITLE] = "する";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ESTIMATE_PRT_DIV_TITLE] = "しない";
                    break;
            }

            //---DEL 2011/09/16 --------------------------->>>>>
            //// 旧システム連携区分
            //switch (scmTtlSt.OldSysCooperatDiv)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOPERAT_DIV_TITLE] = "しない(PM.NS)";
            //        break;
            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOPERAT_DIV_TITLE] = "する(PM7SP)";
            //        break;
            //}

            //// 旧システム連携用フォルダ
            //switch (scmTtlSt.OldSysCooperatDiv)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOP_FOLDER_TITLE] = string.Empty;
            //        break;
            //    case 1:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_OLD_SYS_COOP_FOLDER_TITLE] = scmTtlSt.OldSysCoopFolder;
            //        break;
            //}
            //---DEL 2011/09/16 ---------------------------<<<<<

            // BLコード変換
			switch(scmTtlSt.BLCodeChgDiv)
			{
				case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BL_CODE_CHG_DIV_TITLE] = "する";
					break;
				case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_BL_CODE_CHG_DIV_TITLE] = "しない";
					break;
			}

            // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>

            //// 自動回答区分
            //switch (scmTtlSt.AutoAnswerDiv)
            //{
            //    case 0:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "しない";
            //        break;
            //    case 1:
            //        //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "する";// Del 2011/07/27 duzg for Redmine#23227
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "する(委託在庫分のみ)";// Add 2011/07/27 duzg for Redmine#23227
            //        break;
            //    // --- Add 2011/07/27 duzg for Redmine#23227 --->>>
            //    case 2:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "する(在庫分のみ)";
            //        break;
            //    case 3:
            //        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_DIV] = "する(全て)";
            //        break;
            //    // --- Add 2011/07/27 duzg for Redmine#23227 ---<<<
            //}

            // 自動回答区分（問合せ）
            switch (scmTtlSt.AutoAnsInquiryDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSINQUIRY_DIV] = "しない";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSINQUIRY_DIV] = "する(全て自動回答)";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSINQUIRY_DIV] = "する(絞込み時自動回答)";
                    break;
            }

            // 自動回答区分（発注）
            switch (scmTtlSt.AutoAnsOrderDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSORDER_DIV] = "しない";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSORDER_DIV] = "する(全て自動回答)";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSORDER_DIV] = "する(委託在庫分のみ自動回答)";
                    break;
            }
            // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            switch (scmTtlSt.FuwioutAutoAnsDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FUWIOUTAUTOANSDIV_TITLE] = "しない";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FUWIOUTAUTOANSDIV_TITLE] = "する";
                    break;
            }
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

            // 値引適用区分
			switch(scmTtlSt.DiscountApplyCd)
			{
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "しない";
                    break;
				case 1:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "全て";
					break;
				case 2:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "外装品除く";
					break;
				case 3:
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DISCOUNT_APPLY_CD_TITLE] = "重点品目";
					break;
			}

            // 自動連携値引
            switch (scmTtlSt.DiscountApplyCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_COOPERAT_DIS_TITLE] = string.Empty;
                    break;
                case 1:
                case 2:
                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_COOPERAT_DIS_TITLE] = scmTtlSt.AutoCooperatDis.ToString("#0.00");
                    break;
            }
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //販売区分設定(自動回答時)
            switch (scmTtlSt.SalesCdStAutoAns)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALESCD_ST_AUTO_ANS_TITLE] = "しない";
                    //販売区分
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_CODE_TITLE] = "";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALESCD_ST_AUTO_ANS_TITLE] = "する";
                    //販売区分
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALES_CODE_TITLE] = String.Format("{0:0000}", scmTtlSt.SalesCode);
                    break;
            }
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            switch (scmTtlSt.AutoAnsHourDspDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "使用しない";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "PM設定に従う";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "優良";
                    break;
                case 3:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "純正";
                    break;
                case 4:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "高い方(1:N)";
                    break;
                case 5:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_AUTO_ANSWER_PRICE_DIV] = "高い方(1:1)";
                    break;
            }
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>

            // 受付従業員コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FRONTEMPLOYEECD_TITLE] = scmTtlSt.FrontEmployeeCd;
            // 受付従業員名称
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FRONTEMPLOYEENM_TITLE] = GetFrontEmployeeNm(scmTtlSt.FrontEmployeeCd);
            // 納品区分
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DELIVEREDGOODSDIV_TITLE] = scmTtlSt.DeliveredGoodsNm;

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
            // 売上入力者コード
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALESINPUTCODE_TITLE] = scmTtlSt.SalesInputCode;
            // 売上入力者名称
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SALESINPUTCODENM_TITLE] = GetFrontEmployeeNm(scmTtlSt.SalesInputCode);
            // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            // データ更新倉庫区分
            switch (scmTtlSt.DataUpDateWareHDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DATA_UPD_WAREHOUSE_DIV] = "委託倉庫";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_DATA_UPD_WAREHOUSE_DIV] = "主管倉庫";
                    break;
            }
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

            // Guid
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = scmTtlSt.FileHeaderGuid;
			
			if (this._scmTtlStTable.ContainsKey(scmTtlSt.FileHeaderGuid) == true)
			{
				this._scmTtlStTable.Remove(scmTtlSt.FileHeaderGuid);
			}
			this._scmTtlStTable.Add(scmTtlSt.FileHeaderGuid, scmTtlSt);
		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Update Note: 2011/09/16 鄧潘ハン</br>
        /// <br>             障害報告 #25177 PCCUOE／PM側　PCC全体設定マスタの仕様変更</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable scmTtlStTable = new DataTable(VIEW_TABLE);

			// Addを行う順番が、列の表示順位となります。

            scmTtlStTable.Columns.Add(DELETE_DATE, typeof(string));			                // 削除日
            
            scmTtlStTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));             // 拠点コード
			scmTtlStTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));             // 拠点名称

            scmTtlStTable.Columns.Add(VIEW_SALES_SLIP_PRT_DIV_TITLE, typeof(string));       // 売上伝票発行区分
            scmTtlStTable.Columns.Add(VIEW_ACP_ODRR_SLIP_PRT_DIV_TITLE, typeof(string));    // 受注伝票発行区分
            scmTtlStTable.Columns.Add(VIEW_ESTIMATE_PRT_DIV_TITLE, typeof(string));         // 見積書発行区分
            //---DEL 2011/09/16 --------------------------->>>>>
            //scmTtlStTable.Columns.Add(VIEW_OLD_SYS_COOPERAT_DIV_TITLE, typeof(string));     // 旧システム連携区分
            //scmTtlStTable.Columns.Add(VIEW_OLD_SYS_COOP_FOLDER_TITLE, typeof(string));      // 旧システム連携用フォルダ
            //---DEL 2011/09/16 ---------------------------<<<<<
            scmTtlStTable.Columns.Add(VIEW_BL_CODE_CHG_DIV_TITLE, typeof(string));          // BLコード変換
            // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            //scmTtlStTable.Columns.Add(VIEW_AUTO_ANSWER_DIV, typeof(string));                // 自動回答区分
            scmTtlStTable.Columns.Add(VIEW_AUTO_ANSINQUIRY_DIV, typeof(string));              // 自動回答区分（問合せ）
            scmTtlStTable.Columns.Add(VIEW_AUTO_ANSORDER_DIV, typeof(string));                // 自動回答区分（発注）
            // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
            scmTtlStTable.Columns.Add(VIEW_DISCOUNT_APPLY_CD_TITLE, typeof(string));        // 値引適用区分
            scmTtlStTable.Columns.Add(VIEW_AUTO_COOPERAT_DIS_TITLE, typeof(string));        // 自動連携値引
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            scmTtlStTable.Columns.Add(VIEW_SALESCD_ST_AUTO_ANS_TITLE, typeof(string));        // 販売区分設定
            scmTtlStTable.Columns.Add(VIEW_SALES_CODE_TITLE, typeof(string));        // 販売区分コード
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            scmTtlStTable.Columns.Add(VIEW_AUTO_ANSWER_PRICE_DIV, typeof(string));          // 自動回答時表示区分
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            scmTtlStTable.Columns.Add(VIEW_FRONTEMPLOYEECD_TITLE, typeof(string));          // 受付従業員コード
            scmTtlStTable.Columns.Add(VIEW_FRONTEMPLOYEENM_TITLE, typeof(string));          // 受付従業員名称
            scmTtlStTable.Columns.Add(VIEW_DELIVEREDGOODSDIV_TITLE, typeof(string));        // 納品区分
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            scmTtlStTable.Columns.Add(VIEW_FUWIOUTAUTOANSDIV_TITLE, typeof(string));        // 該当無自動回答区分
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

            scmTtlStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));                   // Guid
            // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
            scmTtlStTable.Columns.Add(VIEW_SALESINPUTCODE_TITLE, typeof(string));          　// 売上入力者コード
            scmTtlStTable.Columns.Add(VIEW_SALESINPUTCODENM_TITLE, typeof(string));          // 売上入力者名称
            // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
            scmTtlStTable.Columns.Add(VIEW_DATA_UPD_WAREHOUSE_DIV, typeof(string)); // データ更新倉庫区分 // ADD 2013/02/27 qijh #34752

			this.Bind_DataSet.Tables.Add(scmTtlStTable);
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br></br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            // 売上伝票発行区分
            SalesSlipPrtDiv_tComboEditor.Items.Clear();
            SalesSlipPrtDiv_tComboEditor.Items.Add(0, "しない");
            SalesSlipPrtDiv_tComboEditor.Items.Add(1, "する");
            SalesSlipPrtDiv_tComboEditor.MaxDropDownItems = SalesSlipPrtDiv_tComboEditor.Items.Count;

            // 受注伝票発行区分
            AcpOdrrSlipPrtDiv_tComEditor.Items.Clear();
            AcpOdrrSlipPrtDiv_tComEditor.Items.Add(0, "しない");
            AcpOdrrSlipPrtDiv_tComEditor.Items.Add(1, "する");
            AcpOdrrSlipPrtDiv_tComEditor.MaxDropDownItems = AcpOdrrSlipPrtDiv_tComEditor.Items.Count;

            // 見積書発行区分
            EstimatePrtDiv_tComEditor.Items.Clear();
            EstimatePrtDiv_tComEditor.Items.Add(0, "する");
            EstimatePrtDiv_tComEditor.Items.Add(1, "しない");
            EstimatePrtDiv_tComEditor.MaxDropDownItems = EstimatePrtDiv_tComEditor.Items.Count;

            // 旧システム連携区分
            OldSysCooperatDiv_tComEditor.Items.Clear();
            OldSysCooperatDiv_tComEditor.Items.Add(0, "しない(PM.NS)");
            OldSysCooperatDiv_tComEditor.Items.Add(1, "する(PM7SP)");
            OldSysCooperatDiv_tComEditor.SelectedIndex = 0;
            OldSysCooperatDiv_tComEditor.MaxDropDownItems = OldSysCooperatDiv_tComEditor.Items.Count;

            // BLコード変換
            BLCodeChgDiv_tComboEditor.Items.Clear();
            BLCodeChgDiv_tComboEditor.Items.Add(0, "する");
            BLCodeChgDiv_tComboEditor.Items.Add(1, "しない");
            BLCodeChgDiv_tComboEditor.MaxDropDownItems = BLCodeChgDiv_tComboEditor.Items.Count;

            // 自動回答区分
            AutoAnswerDiv_tComboEditor.Items.Clear();
            AutoAnswerDiv_tComboEditor.Items.Add(0, "しない");
            //AutoAnswerDiv_tComboEditor.Items.Add(1, "する");// Del 2011/07/13 duzg for 自動回答できる品目を委託在庫分以外も処理可能とする
            // --- Add 2011/07/13 duzg for 自動回答できる品目を委託在庫分以外も処理可能とする --->>>
            AutoAnswerDiv_tComboEditor.Items.Add(1, "する(委託在庫分のみ)");
            AutoAnswerDiv_tComboEditor.Items.Add(2, "する(在庫分のみ)");
            AutoAnswerDiv_tComboEditor.Items.Add(3, "する(全て)");
            // --- Add 2011/07/13 duzg for 自動回答できる品目を委託在庫分以外も処理可能とする ---<<<
            AutoAnswerDiv_tComboEditor.MaxDropDownItems = AutoAnswerDiv_tComboEditor.Items.Count;

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            // 自動回答区分（問合せ）
            AutoAnsInquiryDiv_tComboEditor.Items.Clear();
            AutoAnsInquiryDiv_tComboEditor.Items.Add(0, "しない");
            AutoAnsInquiryDiv_tComboEditor.Items.Add(1, "する(すべて自動回答)");
            AutoAnsInquiryDiv_tComboEditor.Items.Add(2, "する(絞込み時自動回答)");
            AutoAnsInquiryDiv_tComboEditor.MaxDropDownItems = AutoAnsInquiryDiv_tComboEditor.Items.Count;

            // 自動回答区分（発注）
            AutoAnsOrderDiv_tComboEditor.Items.Clear();
            AutoAnsOrderDiv_tComboEditor.Items.Add(0, "しない");
            AutoAnsOrderDiv_tComboEditor.Items.Add(1, "する(すべて自動回答)");
            AutoAnsOrderDiv_tComboEditor.Items.Add(2, "する(委託在庫分のみ自動回答)");
            AutoAnsOrderDiv_tComboEditor.MaxDropDownItems = AutoAnsInquiryDiv_tComboEditor.Items.Count;
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            FuwioutAutoAnsDiv_tComboEditor.Items.Clear();
            FuwioutAutoAnsDiv_tComboEditor.Items.Add(0, "しない");
            FuwioutAutoAnsDiv_tComboEditor.Items.Add(1, "する");
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

            // 値引適用区分
			DiscountApplyCd_tComEditor.Items.Clear();
            DiscountApplyCd_tComEditor.Items.Add(0, "しない");
			DiscountApplyCd_tComEditor.Items.Add(1, "全て");
			DiscountApplyCd_tComEditor.Items.Add(2, "外装品除く");
            DiscountApplyCd_tComEditor.Items.Add(3, "重点品目");
            DiscountApplyCd_tComEditor.MaxDropDownItems = DiscountApplyCd_tComEditor.Items.Count;


            // 2010/05/21 Add >>>
            // 自動回答区分は、SCM自動回答オプションが契約されている場合のみ表示する
            PurchaseStatus psAutoAnswer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCMAutoAnswer);
            if (psAutoAnswer != PurchaseStatus.Contract && psAutoAnswer != PurchaseStatus.Trial_Contract)
            {
                this.ultraLabel4.Visible = false;
                this.AutoAnswerDiv_uLabel.Visible = false;
                this.AutoAnswerDiv_tComboEditor.Visible = false;
                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
                this.AutoAnsInquiryDiv_uLabel.Visible = false;
                this.AutoAnsInquiryDiv_tComboEditor.Visible = false;
                this.AutoAnsOrderDiv_uLabel.Visible = false;
                this.AutoAnsOrderDiv_tComboEditor.Visible = false;
                // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
                // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
                this.ultraLabel14.Visible = false;
                this.FuwioutAutoAnsDiv_tComboEditor.Visible = false;
                // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            }
            // 2010/05/21 Add <<<

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //販売区分設定(自動回答時)
            SalesCdStAutoAns_tComboEditor.Items.Clear();
            SalesCdStAutoAns_tComboEditor.Items.Add(0, "しない");
            SalesCdStAutoAns_tComboEditor.Items.Add(1, "する");
            SalesCdStAutoAns_tComboEditor.MaxDropDownItems = SalesCdStAutoAns_tComboEditor.Items.Count;
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            AutoAnsHourDspDiv_tComboEditor.Items.Clear();
            AutoAnsHourDspDiv_tComboEditor.Items.Add(0, "使用しない");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(1, "PM設定に従う");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(2, "優良");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(3, "純正");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(4, "高い方(1:N)");
            AutoAnsHourDspDiv_tComboEditor.Items.Add(5, "高い方(1:1)");
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            // データ更新倉庫区分
            DataUpdWarehouseDiv_tComboEditor.Items.Clear();
            DataUpdWarehouseDiv_tComboEditor.Items.Add(0, "委託倉庫");
            DataUpdWarehouseDiv_tComboEditor.Items.Add(1, "主管倉庫");
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            // 納品区分
            this.SetDelivereds(this._enterpriseCode);
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        }
		
       	/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note        : 画面をクリアします。</br>
		/// <br></br>
		/// </remarks>
		private void ScreenClear()
		{
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.SectionName_tEdit.DataText = "";

            this.SalesSlipPrtDiv_tComboEditor.SelectedIndex = 0;        // 売上伝票発行区分
            this.AcpOdrrSlipPrtDiv_tComEditor.SelectedIndex = 0;        // 受注伝票発行区分
            this.EstimatePrtDiv_tComEditor.SelectedIndex = 0;           // 見積書発行区分
            this.OldSysCooperatDiv_tComEditor.SelectedIndex = 0;        // 旧システム連携区分
            this.tEdit_OldSysCoopFolder.DataText = "";                  // 旧システム連携用フォルダ
            this.BLCodeChgDiv_tComboEditor.SelectedIndex = 0;           // BLコード変換
            this.AutoAnswerDiv_tComboEditor.SelectedIndex = 0;          // 自動回答区分
            this.DiscountApplyCd_tComEditor.SelectedIndex = 0;          // 値引適用区分
            this.AutoCooperatDis_tNedit.DataText = "";                  // 自動連携値引率			
            //>>>2010/08/03
            this.tEdit_CashRegisterNo.DataText = string.Empty;          // 受信処理起動端末番号
            this.tEdit_CashRegisterNoNm.DataText = string.Empty;        // 受信処理起動端末番号名称
            this.tEdit_RcvProcStInterval.DataText = string.Empty;       // 受信処理起動間隔
            //<<<2010/08/03
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this.SalesCdStAutoAns_tComboEditor.SelectedIndex = 0;          // 販売区分設定(自動回答時)
            this.SalesCode_tNedit.DataText = "";               // 販売区分コード
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this.AutoAnsHourDspDiv_tComboEditor.SelectedIndex = 0;     //自動回答時表示区分
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            this.AutoAnsInquiryDiv_tComboEditor.SelectedIndex = 0;       // 自動回答区分（問合せ）
            this.AutoAnsOrderDiv_tComboEditor.SelectedIndex = 0;         // 自走回答区分（発注）
            this.tEdit_FrontEmployeeCd.DataText = "";                    // 受付従業員コード
            this.tEdit_FrontEmployeeNm.DataText = "";                    // 受付従業員名称
            this.DeliveredGoodsDiv_tComboEditor.SelectedIndex = 0;       // 納品区分
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
            this.tEdit_SalesInputCode.DataText = "";                     // 売上入力者コード
            this.tEdit_SalesInputNm.DataText = "";　　　　　　　　　　　 // 売上入力者名称　　
            // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            this.FuwioutAutoAnsDiv_tComboEditor.SelectedIndex = 0;       // 該当無自動回答区分
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            this.DataUpdWarehouseDiv_tComboEditor.SelectedIndex = 0; // データ更新倉庫区分 // ADD 2013/02/27 qijh #34752

        }

		/// <summary>
        /// SCM全体設定クラス画面展開処理
		/// </summary>
        /// <param name="scmTtlSt">SCM全体設定オブジェクト</param>
		/// <remarks>
        /// <br>Note       : SCM全体設定オブジェクトから画面にデータを展開します。</br>
		/// <br></br>
		/// </remarks>
		private void SCMTtlStToScreen(SCMTtlSt scmTtlSt)
		{
            // 拠点コード
            this.tEdit_SectionCodeAllowZero2.DataText = scmTtlSt.SectionCode;
            // 拠点名称
            string sectionName = string.Empty;
            if (scmTtlSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            {
                sectionName = "全社共通";
            }
            else
            {
                sectionName = this.GetSectionName(scmTtlSt.SectionCode);
            }
            this.SectionName_tEdit.DataText = sectionName;

            // 売上伝票発行区分
            this.SalesSlipPrtDiv_tComboEditor.SelectedIndex = scmTtlSt.SalesSlipPrtDiv;

            // 受注伝票発行区分
            this.AcpOdrrSlipPrtDiv_tComEditor.SelectedIndex = scmTtlSt.AcpOdrrSlipPrtDiv;

            // 見積書発行区分
            this.EstimatePrtDiv_tComEditor.SelectedIndex = scmTtlSt.EstimatePrtDiv;

            // 旧システム連携区分
            this.OldSysCooperatDiv_tComEditor.SelectedIndex = scmTtlSt.OldSysCooperatDiv;

            // 旧システム連携用フォルダ
            this.tEdit_OldSysCoopFolder.DataText = scmTtlSt.OldSysCoopFolder;

            // BLコード変換
            this.BLCodeChgDiv_tComboEditor.SelectedIndex = scmTtlSt.BLCodeChgDiv;

            // 自動回答区分
            this.AutoAnswerDiv_tComboEditor.SelectedIndex = scmTtlSt.AutoAnswerDiv;
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            // 自動回答区分（問合せ）
            this.AutoAnsInquiryDiv_tComboEditor.SelectedIndex = scmTtlSt.AutoAnsInquiryDiv;
            // 自動回答区分（発注）
            this.AutoAnsOrderDiv_tComboEditor.SelectedIndex = scmTtlSt.AutoAnsOrderDiv;
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // 値引適用区分
            this.DiscountApplyCd_tComEditor.SelectedIndex = scmTtlSt.DiscountApplyCd;

            // 自動連携値引率
			this.AutoCooperatDis_tNedit.DataText = scmTtlSt.AutoCooperatDis.ToString();

            //>>>2010/08/03
            // 受信処理起動端末番号
            if (scmTtlSt.CashRegisterNo != 0) this.tEdit_CashRegisterNo.DataText = scmTtlSt.CashRegisterNo.ToString();
            PosTerminalMg posTerminalMg = this._scmTtlStAcs.GetPosTerminalMg(this._enterpriseCode, scmTtlSt.CashRegisterNo);
            if (posTerminalMg != null) this.tEdit_CashRegisterNoNm.Text = posTerminalMg.MachineName;

            // 受信処理起動間隔
            this.tEdit_RcvProcStInterval.DataText = scmTtlSt.RcvProcStInterval.ToString();
            //<<<2010/08/03

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // 販売区分設定(自動回答時)
            this.SalesCdStAutoAns_tComboEditor.SelectedIndex = scmTtlSt.SalesCdStAutoAns;

            // 販売区分コード
            this.SalesCode_tNedit.DataText = scmTtlSt.SalesCode.ToString();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            this.AutoAnsHourDspDiv_tComboEditor.SelectedIndex = scmTtlSt.AutoAnsHourDspDiv;
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            //受付従業員コード
            this.tEdit_FrontEmployeeCd.Text = scmTtlSt.FrontEmployeeCd.Trim().PadLeft(4, '0');

            //受付従業員名称
            this.tEdit_FrontEmployeeNm.Text = GetFrontEmployeeNm(scmTtlSt.FrontEmployeeCd);

            // DEL 2013/06/11 吉岡 2013/06/18配信 システムテスト障害№36 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region
            // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
            //this.tEdit_SalesInputCode.Text = scmTtlSt.SalesInputCode.Trim().PadLeft(4, '0');
            //this.tEdit_SalesInputNm.Text = GetFrontEmployeeNm(scmTtlSt.SalesInputCode); ;//todo
            // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
            #endregion
            // DEL 2013/06/11 吉岡 2013/06/18配信 システムテスト障害№36 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/06/11 吉岡 2013/06/18配信 システムテスト障害№36 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 発行者
            if (scmTtlSt.SalesInputCode.Trim().Equals(string.Empty))
            {
                this.tEdit_SalesInputCode.Text = string.Empty;
                this.tEdit_SalesInputNm.Text = string.Empty;
            }
            else
            {
                this.tEdit_SalesInputCode.Text = scmTtlSt.SalesInputCode.Trim().PadLeft(4, '0');
                this.tEdit_SalesInputNm.Text = GetFrontEmployeeNm(scmTtlSt.SalesInputCode); 
            }
            // ADD 2013/06/11 吉岡 2013/06/18配信 システムテスト障害№36 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            //納品区分
            if (scmTtlSt.DeliveredGoodsDiv == 0)
            {
                this.DeliveredGoodsDiv_tComboEditor.SelectedIndex = 0;
            }
            else
            {
                this.DeliveredGoodsDiv_tComboEditor.Value = scmTtlSt.DeliveredGoodsDiv;
            }
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            this.FuwioutAutoAnsDiv_tComboEditor.SelectedIndex = scmTtlSt.FuwioutAutoAnsDiv;
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            // データ倉庫更新区分
            this.DataUpdWarehouseDiv_tComboEditor.SelectedIndex = scmTtlSt.DataUpDateWareHDiv;
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        }

		/// <summary>
        /// 画面情報SCM全体設定クラス格納処理
		/// </summary>
        /// <param name="scmTtlSt">SCM全体設定オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面情報からSCM全体設定オブジェクトにデータを格納します。</br>
		/// <br></br>
		/// </remarks>
		private void ScreenToSCMTtlSt(ref SCMTtlSt scmTtlSt)
		{
			if (scmTtlSt == null)
			{
				// 新規の場合
                scmTtlSt = new SCMTtlSt();
			}

            //企業コード
            scmTtlSt.EnterpriseCode = this._enterpriseCode; 
            // 拠点コード
            scmTtlSt.SectionCode = this.tEdit_SectionCodeAllowZero2.DataText;

            // 売上伝票発行区分
            scmTtlSt.SalesSlipPrtDiv = (int)this.SalesSlipPrtDiv_tComboEditor.Value;

            // 受注伝票発行区分
            scmTtlSt.AcpOdrrSlipPrtDiv = (int)this.AcpOdrrSlipPrtDiv_tComEditor.Value;

            // 見積書発行区分
            scmTtlSt.EstimatePrtDiv = (int)this.EstimatePrtDiv_tComEditor.Value;

            // 旧システム連携区分
            scmTtlSt.OldSysCooperatDiv = (int)this.OldSysCooperatDiv_tComEditor.Value;

            // 旧システム連携用フォルダ
            scmTtlSt.OldSysCoopFolder = this.tEdit_OldSysCoopFolder.DataText;

            // BLコード変換
            scmTtlSt.BLCodeChgDiv = (int)this.BLCodeChgDiv_tComboEditor.Value;

            // 自動回答区分
            scmTtlSt.AutoAnswerDiv = (int)this.AutoAnswerDiv_tComboEditor.Value;

            // 値引適用区分
            scmTtlSt.DiscountApplyCd = (int)this.DiscountApplyCd_tComEditor.Value;

            // 自動連携値引率
            scmTtlSt.AutoCooperatDis = this.AutoCooperatDis_tNedit.GetValue();

            //>>>2010/08/03
            // 受信処理起動端末番号
            scmTtlSt.CashRegisterNo = TStrConv.StrToIntDef(this.tEdit_CashRegisterNo.DataText, 0);
            // 受信処理起動間隔
            scmTtlSt.RcvProcStInterval = TStrConv.StrToIntDef(this.tEdit_RcvProcStInterval.DataText, 0);
            //<<<2010/08/03
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            // 販売区分設定(自動回答時)
            scmTtlSt.SalesCdStAutoAns = (int)this.SalesCdStAutoAns_tComboEditor.Value;
            // 販売区分コード
            scmTtlSt.SalesCode = this.SalesCode_tNedit.GetInt();
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //自動回答時表示区分
            scmTtlSt.AutoAnsHourDspDiv = (int)this.AutoAnsHourDspDiv_tComboEditor.Value;
            // --- ADD 2012/08/31 三戸 2012/10月配信予定 SCM障害№76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            // 自動回答区分（問合せ）
            scmTtlSt.AutoAnsInquiryDiv = (int)this.AutoAnsInquiryDiv_tComboEditor.Value;
            // 自動回答区分（発注）
            scmTtlSt.AutoAnsOrderDiv = (int)this.AutoAnsOrderDiv_tComboEditor.Value;
            //受付従業員       
            if (tEdit_FrontEmployeeCd.GetInt() == 0)
            {
                tEdit_FrontEmployeeCd.Text = "";
            }
            else
            {
                scmTtlSt.FrontEmployeeCd = tEdit_FrontEmployeeCd.GetInt().ToString().PadLeft(4, '0');
            }
            //受付従業員名称
            scmTtlSt.FrontEmployeeNm = tEdit_FrontEmployeeNm.Text.TrimEnd();
            //納品区分
            if (this.DeliveredGoodsDiv_tComboEditor.SelectedItem == null)
            {
                scmTtlSt.DeliveredGoodsDiv = 0;
            }
            else
            {
                if (this.DeliveredGoodsDiv_tComboEditor.SelectedItem.DataValue.ToString() != string.Empty)
                {
                    scmTtlSt.DeliveredGoodsDiv = (int)this.DeliveredGoodsDiv_tComboEditor.SelectedItem.DataValue;
                }
            }
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            // ADD 2013/02/13 SCM障害追加②対応 -------------------------------------------->>>>>
            scmTtlSt.FuwioutAutoAnsDiv = (int)this.FuwioutAutoAnsDiv_tComboEditor.Value;
            // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

            // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
            if (tEdit_SalesInputCode.GetInt() == 0)
            {
                scmTtlSt.SalesInputCode = "";
            }
            else
            {
                scmTtlSt.SalesInputCode = tEdit_SalesInputCode.GetInt().ToString().PadLeft(4, '0');
            }
            // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            // データ倉庫更新区分
            scmTtlSt.DataUpDateWareHDiv = (int)this.DataUpdWarehouseDiv_tComboEditor.Value;
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br></br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndexバッファ初期化（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 比較用クローンクリア
            this._scmTtlStClone = null;

            // フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
		{
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
		}

		/// <summary>
		///	SCM全体設定画面入力チェック処理
		/// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : SCM全体設定画面の入力チェックをします。</br>
        /// <br>Update Note : 2011/09/14 wangf</br>
        /// <br>              障害報告 #24169 #13の対応</br>   
		/// <br></br>
		/// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
		{
            bool result = true;

            // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            #region 削除(SCM改良の為)
            //// 拠点コード
            //if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            //{
            //    message = this.Section_uLabel.Text + "を設定して下さい。";
            //    control = this.tEdit_SectionCodeAllowZero2;
            //    result = false;
            //}

            //// 旧システム連携用フォルダ
            //if (this.OldSysCooperatDiv_tComEditor.SelectedIndex == 1)
            //{
            //    // 旧システム連携区分：する
            //    if (this.tEdit_OldSysCoopFolder.DataText == "")
            //    {
            //        message = this.OldSysCoopFolder_uLabel.Text + "を設定して下さい。";
            //        control = this.tEdit_OldSysCoopFolder;
            //        result = false;
            //    }
            //}

            //// 自動連携値引率
            //if (this.DiscountApplyCd_tComEditor.SelectedIndex != 0)
            //{
            //    // 値引適用区分：しない以外
            //    if (this.AutoCooperatDis_tNedit.GetValue() == 0.00)
            //    {
            //        message = this.AutoCooperatDis_uLabel.Text + "を設定して下さい。";
            //        control = this.AutoCooperatDis_tNedit;
            //        result = false;
            //    }
            //    else if (this.AutoCooperatDis_tNedit.GetValue() >= 100.00)
            //    {
            //        message = this.AutoCooperatDis_uLabel.Text + "は、【100.00%】以内で設定して下さい。";
            //        control = this.AutoCooperatDis_tNedit;
            //        result = false;
            //    }
            //}
            //// -- ADD wangf 2011/09/14 ---------->>>>>
            //// 受信処理起動端末番号
            //if (string.IsNullOrEmpty(this.tEdit_CashRegisterNo.DataText.Trim()))
            //{
            //    message = this.ultraLabel7.Text + "を設定して下さい。";
            //    control = this.tEdit_CashRegisterNo;
            //    result = false;
            //}
            //// -- ADD wangf 2011/09/14 ----------<<<<<

            ////ADD START BY wujun FOR Redmine#25181 ON 2011.09.20
            //// 受信処理起動間隔
            //else if (string.IsNullOrEmpty(this.tEdit_RcvProcStInterval.DataText.Trim()))
            //{
            //    message = this.ultraLabel9.Text + "を設定して下さい。";
            //    control = this.tEdit_RcvProcStInterval;
            //    result = false;
            //}
            ////ADD END BY wujun FOR Redmine#25181 ON 2011.09.20

            ////2012/04/20 ADD T.Nishi >>>>>>>>>>
            ////販売区分設定(自動回答時)
            //if (this.SalesCdStAutoAns_tComboEditor.SelectedIndex != 0)
            //{
            //    //販売区分コード
            //    if (this.SalesCode_tNedit.GetValue() == 0)
            //    {
            //        message = this.ultraLabel13.Text + "を設定して下さい。";
            //        control = this.SalesCode_tNedit;
            //        result = false;
            //    }
            //}
            ////2012/04/20 ADD T.Nishi <<<<<<<<<<
            #endregion // 削除(SCM改良の為)

            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero2.DataText == "")
            {
                message = this.Section_uLabel.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero2;
                result = false;
            }
            // --------------- DEL START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
            //// 自動連携値引率
            //else if (this.DiscountApplyCd_tComEditor.SelectedIndex != 0)
            //{
            //    // 値引適用区分：しない以外
            //    if (this.AutoCooperatDis_tNedit.GetValue() == 0.00)
            //    {
            //        message = this.AutoCooperatDis_uLabel.Text + "を設定して下さい。";
            //        control = this.AutoCooperatDis_tNedit;
            //        result = false;
            //    }
            //    else if (this.AutoCooperatDis_tNedit.GetValue() >= 100.00)
            //    {
            //        message = this.AutoCooperatDis_uLabel.Text + "は、【100.00%】以内で設定して下さい。";
            //        control = this.AutoCooperatDis_tNedit;
            //        result = false;
            //    }
            //}
            // --------------- DEL END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
            // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
            // 自動連携値引率
            else if (this.DiscountApplyCd_tComEditor.SelectedIndex != 0 && this.AutoCooperatDis_tNedit.GetValue() == 0.00)
            {
                message = this.AutoCooperatDis_uLabel.Text + "を設定して下さい。";
                control = this.AutoCooperatDis_tNedit;
                result = false;
            }
            else if (this.DiscountApplyCd_tComEditor.SelectedIndex != 0 && this.AutoCooperatDis_tNedit.GetValue() >= 100.00)
            {
                message = this.AutoCooperatDis_uLabel.Text + "は、【100.00%】以内で設定して下さい。";
                control = this.AutoCooperatDis_tNedit;
                result = false;
            }
            // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
            // -- ADD wangf 2011/09/14 ---------->>>>>
            // 受信処理起動端末番号
            else if (string.IsNullOrEmpty(this.tEdit_CashRegisterNo.DataText.Trim()))
            {
                message = this.ultraLabel7.Text + "を設定して下さい。";
                control = this.tEdit_CashRegisterNo;
                result = false;
            }
            // -- ADD wangf 2011/09/14 ----------<<<<<

            //ADD START BY wujun FOR Redmine#25181 ON 2011.09.20
            // 受信処理起動間隔
            else if (string.IsNullOrEmpty(this.tEdit_RcvProcStInterval.DataText.Trim()))
            {
                message = this.ultraLabel9.Text + "を設定して下さい。";
                control = this.tEdit_RcvProcStInterval;
                result = false;
            }
            //ADD END BY wujun FOR Redmine#25181 ON 2011.09.20

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            //販売区分設定(自動回答時)
            // UPD 2012/11/20 2012/12/12配信予定システムテスト障害№45対応 --------------------------------->>>>>
            //else if (this.SalesCdStAutoAns_tComboEditor.SelectedIndex != 0)
            //{
            //    //販売区分コード
            //    if (this.SalesCode_tNedit.GetValue() == 0)
            //    {
            //        message = this.ultraLabel13.Text + "を設定して下さい。";
            //        control = this.SalesCode_tNedit;
            //        result = false;
            //    }
            //}
            else if (this.SalesCdStAutoAns_tComboEditor.SelectedIndex != 0 && this.SalesCode_tNedit.GetValue() == 0)
            {
                message = this.ultraLabel13.Text + "を設定して下さい。";
                control = this.SalesCode_tNedit;
                result = false;
            }
            // UPD 2012/11/20 2012/12/12配信予定システムテスト障害№45対応 ---------------------------------<<<<<
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // 受付従業員コード 未入力はエラー
            // UPD 2012/11/20 2012/12/12配信予定システムテスト障害№45対応 --------------------------------->>>>>
            //else if (this.tEdit_FrontEmployeeCd.Text == "")
            else if (string.IsNullOrEmpty(this.tEdit_FrontEmployeeCd.DataText.Trim()))
            // UPD 2012/11/20 2012/12/12配信予定システムテスト障害№45対応 ---------------------------------<<<<<
            {
                message = this.FrontEmployee_Label.Text + "を設定して下さい。";
                control = this.tEdit_FrontEmployeeCd;
                result = false;
            }
            // 受付従業員コード　マスタ未登録はエラー
            // UPD 2012/11/20 2012/12/12配信予定システムテスト障害№45対応 --------------------------------->>>>>
            //else if (this.tEdit_FrontEmployeeNm.Text == "")
            else if (string.IsNullOrEmpty(this.tEdit_FrontEmployeeNm.DataText.Trim()))
            // UPD 2012/11/20 2012/12/12配信予定システムテスト障害№45対応 ---------------------------------<<<<<
            {
                message = this.FrontEmployee_Label.Text + "がマスタに登録されていません。";
                control = this.tEdit_FrontEmployeeCd;
                result = false;
            }
            // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
            // DEL 2013/06/11 吉岡 2013/06/18配信 システムテスト障害№36 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region
            // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
            //else if (string.IsNullOrEmpty(tEdit_SalesInputCode.DataText.Trim()))
            //{
            //    message = this.SalesInputCode_Label.Text + "を設定して下さい";
            //    control = this.tEdit_SalesInputCode;
            //    result = false;
            //}
            //else if (!string.IsNullOrEmpty(tEdit_SalesInputCode.DataText.Trim()))
            //{
            //    int salesInputCode = tEdit_SalesInputCode.GetInt();
            //    if (this._employeeAcs == null)
            //    {
            //        this._employeeAcs = new EmployeeAcs();
            //    }
            //    string salesInputCodeNm = GetFrontEmployeeNm(salesInputCode.ToString().PadLeft(4, '0'));
            //    if (string.IsNullOrEmpty(salesInputCodeNm))
            //    {
            //        message = "発行者が存在しません。";
            //        tEdit_SalesInputCode.Clear();
            //        tEdit_SalesInputNm.Clear();
            //        _preSalesInputCode = 0;
            //        // 入力チェック
            //        control = this.tEdit_SalesInputCode;
            //        result = false;
            //    }
            //    else
            //    {
            //        this.tEdit_SalesInputNm.Text = salesInputCodeNm;
            //    }
            //}
            // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
            #endregion
            // DEL 2013/06/11 吉岡 2013/06/18配信 システムテスト障害№36 ---------<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return result;
		}
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        #region 販売区分
        /// <summary>
        /// 販売区分ガイドボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Update Note : 2012/04/20 西 毅</br>
        /// <br>              抽出条件を入力後の表示はコード＋名称で表示する。</br>
        private void uButton_SalesCode_Click(object sender, EventArgs e)
        {
            int userGuideDivCd_SalesCode = 71;  // 販売区分：71

            // コードから名称へ変換
            UserGdHd userGuideHdInfo;
            UserGdBd userGuideBdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, userGuideDivCd_SalesCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (userGuideBdInfo.GuideCode != 0)
                {
                    this.SalesCode_tNedit.DataText = String.Format("{0:0000}", userGuideBdInfo.GuideCode);
                }
                //最新情報にフォーカスセット
                Renewal_Button.Focus();

            }
        }

        #endregion // 販売区分
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

		/// <summary>
        ///　保存処理(SaveProc())
		/// </summary>
		/// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Update Note : 2011/09/08 田建委</br>
        /// <br>              障害報告 #24169 全社共通の編集　</br>   
        /// <br>Update Note : 2011/09/14 wangf</br>
        /// <br>              障害報告 #24169 #13の対応</br>     
		/// <br></br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
            // -- ADD wangf 2011/09/14 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // -- ADD wangf 2011/09/14 ----------<<<<<
            
			//画面データ入力チェック処理
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                    message, 							// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }

            /* -- DEL wangf 2011/09/14 ---------->>>>>
            // ----- ADD 2011/09/08 ---------->>>>>
            // 拠点
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/08 ----------<<<<<
            // -- DEL wangf 2011/09/14 ----------<<<<<*/

			SCMTtlSt scmTtlSt = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                scmTtlSt = ((SCMTtlSt)this._scmTtlStTable[guid]).Clone();
			}

            // 画面情報を取得
			ScreenToSCMTtlSt(ref scmTtlSt);
            // 登録・更新処理
			int status = this._scmTtlStAcs.Write(ref scmTtlSt);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                {
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                }
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    // 排他処理
                    ExclusiveTransaction(status, true);					
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return false;
				}
				default:
				{
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
                        PROGRAM_ID,							    // アセンブリID
						this.Text,  　　                        // プログラム名称
                        "SaveProc",                             // 処理名称
						TMsgDisp.OPE_UPDATE,                    // オペレーション
						"登録に失敗しました。",				    // 表示するメッセージ
						status,									// ステータス値
						this._scmTtlStAcs,				    	// エラーが発生したオブジェクト
						MessageBoxButtons.OK,			  		// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                    CloseForm(DialogResult.Cancel);
					return false;
				}
			}

            // SCM全体設定情報クラスのデータセット展開処理
			SCMTtlStToDataSet(scmTtlSt, this.DataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			this.DialogResult = DialogResult.OK;
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
			result = true;
			return result;
		}


        /// <summary>
        ///　競合中メッセージ表示
        /// </summary>
        /// <remarks>
        /// <br>Note　　　  : 該当コードが使用されている場合にメッセージを表示します。</br>
        /// <br></br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                "このコードは既に使用されています" ,// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
                tEdit_SectionCodeAllowZero2.Focus();

                control = tEdit_SectionCodeAllowZero2;
        }

        /// <summary>
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールのサイズ設定処理を行います。</br>
        /// <br></br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(190, 24);
            this.AutoCooperatDis_tNedit.Size = new System.Drawing.Size(92, 24);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称 ※存在しない場合、<c>null</c>を返します。</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Update Note : 2011/09/08 田建委</br>
        /// <br>              障害報告 #24169 全社共通の編集　</br>   
        /// <br>Update Note : 2011/09/14 wangf</br>
        /// <br>              障害報告 #24169 #13の対応</br>     
        /// <br></br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // 全社共通チェック
            if (string.IsNullOrEmpty(sectionCode)) return sectionName; // ADD wangf 2011/09/14
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                //sectionName = "全社共通"; // DEL 2011/09/08
                sectionName = "全社共通"; // ADD wangf 2011/09/14
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
                sectionName = null;
            }
            catch
            {
                sectionName = null;
            }

            return sectionName;
        }

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        /// <summary>
        /// 受付従業員名称の取得
        /// </summary>
        /// <param name="employeeCode"> 受付従業員コード</param>
        /// <returns>受付従業員名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称の取得を行います。</br>
        /// <br>Programmer : 湯上 千加子</br>
        /// <br>Date       : 2012.08.29</br>
        /// </remarks>
        private string GetFrontEmployeeNm(string employeeCode)
        {

            string frontEmployeeNm = string.Empty;
            if (_employeeTb == null)
            {
                GetAllEmployeeNm();
            }
            if (_employeeTb != null && _employeeTb.ContainsKey(employeeCode.PadLeft(4, '0').TrimEnd()))
            {
                frontEmployeeNm = (string)_employeeTb[employeeCode.PadLeft(4, '0').TrimEnd()];
            }
            return frontEmployeeNm;
        }

        /// <summary>
        /// 受付従業員名称の取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点名称の取得を行います。</br>
        /// <br>Programmer : 湯上 千加子</br>
        /// <br>Date       : 2012.08.29</br>
        /// </remarks>
        private void GetAllEmployeeNm()
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }
            if (this._employeeTb == null)
            {
                _employeeTb = new Hashtable();
            }
            else
            {
                _employeeTb.Clear();
            }

            ArrayList employeeList;
            ArrayList employeeDtlList;
            int status = this._employeeAcs.SearchAll(out employeeList, out employeeDtlList, this._enterpriseCode);
            if (status == (int)(int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                foreach (Employee employee in employeeList)
                {
                    if (employee.LogicalDeleteCode == 0)
                    {
                        _employeeTb.Add(employee.EmployeeCode.TrimEnd(), employee.Name);
                    }
                }
            }
        }
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        /// <summary>
        /// モード変更処理
        /// </summary>
        /// <br>Update Note : 2011/09/08 田建委</br>
        /// <br>              障害報告 #24169 全社共通の編集　</br>   
        private bool ModeChangeProc()
        {
            // --- ADD 2011/09/08 -------------------------------->>>>>
            if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
            {
                this.SectionName_tEdit.Clear();
                return false;
            }
            // --- ADD 2011/09/08 --------------------------------<<<<<

            string msg = "入力されたコードのSCM全体設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのSCM全体設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        isError = true; // ADD 2011/09/08
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == ALL_SECTIONCODE)
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードのSCM全体設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    isError = true; // ADD 2011/09/08
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 拠点コード、名称のクリア
                                tEdit_SectionCodeAllowZero2.Clear();
                                SectionName_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        # endregion

        # region -- Control Events --
       	/// <summary>
        ///	Form.Load イベント(PMSCM09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09020UA_Load(object sender, System.EventArgs e)
		{
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.OldSysCoopFolder_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this.uButton_SalesCode.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            this.uButtonFrontEmployeeCdGuid.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

            this.uButtonSalesInputCodeGuid.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];// ADD 2013/04/11 wangl2 FOR RedMine#35269 

            // コントロールサイズ設定
            SetControlSize();
            
			// 画面初期設定処理
			ScreenInitialSetting();
		}

		/// <summary>
        ///	Form.Closing イベント(PMSCM09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
		///					  ようとしたときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09020UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;
			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			//（フォームの「×」をクリックされた場合の対応です。）
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}		
		}

		/// <summary>
        ///	Form.VisibleChanged イベント(PMSCM09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォームの表示・非表示が切り替えられ
		///					  たときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09020UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				// メインフレームアクティブ化
				this.Owner.Activate();
				return;
			}

			// 自分自身が非表示になった場合、
			// またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}
			
            // 画面クリア
			ScreenClear();

            Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            // 登録・更新処理
			if (!SaveProc())
			{
				return;
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // 削除モード・参照モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // 画面のデータを取得する
                SCMTtlSt compareSCMTtlSt = new SCMTtlSt();

                compareSCMTtlSt = this._scmTtlStClone.Clone();
                ScreenToSCMTtlSt(ref compareSCMTtlSt);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._scmTtlStClone.Equals(compareSCMTtlSt))))
                {
                    // 画面情報が変更されていた場合は、保存確認メッセージを表示
                    DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
                        PROGRAM_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                        null, 					                              // 表示するメッセージ
                        0, 					                                  // ステータス値
                        MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                return;
                            }
                        case DialogResult.No:
                            {
                                // 画面非表示イベント
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }
                                break;
                            }
                        default:
                            {
                                // 新規モードからモード変更対応
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero2.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                return;
                            }
                    }
                }
            }
            
            this.DialogResult = DialogResult.Cancel;
			this._indexBuf = -2;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>
		/// Timer.Tick イベント(timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
		///					  スレッドで実行されます。</br>
		/// <br></br>
		/// </remarks>
		private void Timer_Tick(object sender, System.EventArgs e)
		{
			Timer.Enabled = false;
            _preSalesInputCode = 0;//ADD 2013/04/11 wangl2 FOR RedMine#35269 

            // 画面表示処理
			ScreenReconstruction();
		}

        /// <summary>
        /// Control.Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 拠点ガイドボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.SalesSlipPrtDiv_tComboEditor.Focus();

                    // 新規モードからモード変更対応
                    if (this.DataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            SectionGuide_Button.Focus();
                        }
                    }
                }
                else if (status == 1)
                {
                    // [戻る]の場合
                    if (ModeChangeProc())
                    {
                        SectionGuide_Button.Focus();
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        /// <summary>
        /// uButtonFrontEmployeeCdGuid_Click
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 抽出する範囲を指定する。</br>
        /// <br>Programmer	: 湯上 千加子</br>
        /// <br>Date		: 2012/11/09 </br>
        /// </remarks>
        private void uButtonFrontEmployeeCdGuid_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                tEdit_FrontEmployeeCd.Value = employee.EmployeeCode.TrimEnd();
                tEdit_FrontEmployeeNm.Text = employee.Name;
                _preFrontEmployeeCd = tEdit_FrontEmployeeCd.GetInt();
            }

        }
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

        // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
        /// <summary>
        /// uButtonSalesInputCodeGuid_Click
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		: 抽出する範囲を指定する。</br>
        /// <br>Programmer	: wangl2</br>
        /// <br>Date		: 2013/04/11 </br>
        /// </remarks>
        private void uButtonSalesInputCodeGuid_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                tEdit_SalesInputCode.Value = employee.EmployeeCode.TrimEnd();
                tEdit_SalesInputNm.Text = employee.Name;
                _preSalesInputCode = tEdit_SalesInputCode.GetInt();
            }
        }
        // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<

        /// <summary>
        /// Control.Click イベント(Delete_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // 完全削除確認
            DialogResult result = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" +
                "よろしいですか？", 				// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// 表示するボタン

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // 保持しているデータセットより情報取得
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMTtlSt scmTtlSt = (SCMTtlSt)this._scmTtlStTable[guid];

            // 完全削除処理
            int status = this._scmTtlStAcs.Delete(scmTtlSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._scmTtlStTable.Remove(scmTtlSt.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        // 完全削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            PROGRAM_ID, 						// アセンブリＩＤまたはクラスＩＤ
                            this.Text, 				            // プログラム名称
                            "Delete_Button_Click", 				// 処理名称
                            TMsgDisp.OPE_DELETE, 				// オペレーション
                            "削除に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._scmTtlStAcs, 				    // エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click イベント(Revive_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // 復活対象データ取得
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SCMTtlSt scmTtlSt = ((SCMTtlSt)this._scmTtlStTable[guid]).Clone();

            // 復活処理
            status = this._scmTtlStAcs.Revival(ref scmTtlSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // SCM全体設定情報クラスのデータセット展開処理
                        SCMTtlStToDataSet(scmTtlSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
                            PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Revive_Button_Click",				// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            "復活に失敗しました。",			    // 表示するメッセージ 
                            status,								// ステータス値
                            this._scmTtlStAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <br>Update Note : 2011/09/08 田建委</br>
        /// <br>              障害報告 #24169 全社共通の編集　</br>   
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 新規モードからモード変更対応
            _modeFlg = false;

            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero2)
            {
                // 拠点コード取得
                string sectionCode = this.tEdit_SectionCodeAllowZero2.DataText;

                // 拠点名称取得
                string sectionName = GetSectionName(sectionCode);
                // ----- // ADD 2011/09/08 ------------------->>>>>
                if (sectionCode == "0" || sectionCode == "00")
                {
                    sectionName = "全社共通";
                }
                isError = false;
                if (!string.IsNullOrEmpty(sectionCode))
                {
                    this.tEdit_SectionCodeAllowZero2.Text = sectionCode.PadLeft(2, '0');
                }
                // ----- // ADD 2011/09/08 -------------------<<<<<
                if (sectionName == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "拠点が存在しません。",
                        -1,
                        MessageBoxButtons.OK
                    );
                    isError = true; // ADD 2011/09/08
                    this.tEdit_SectionCodeAllowZero2.Clear();
                    this.SectionName_tEdit.Clear();
                    //e.NextCtrl = SectionGuide_Button;
                    e.NextCtrl = this.tEdit_SectionCodeAllowZero2;
                    e.NextCtrl.Select();
                    return;
                }
                this.SectionName_tEdit.DataText = sectionName;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // フォーカス設定
                            e.NextCtrl = this.SalesSlipPrtDiv_tComboEditor;
                        }
                    }
                }

                // 新規モードからモード変更対応
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // 最新情報ボタンは更新チェックから外す
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (
                        e.PrevCtrl == this.tEdit_SectionCodeAllowZero2
                            &&
                        e.NextCtrl == this.SectionGuide_Button
                            &&
                        string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text.Trim())
                    )
                    {
                        // 何もしない ∵新規モードで起動直後に拠点のガイドボタンをクリックした場合に相当
                    }
                    else
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
            }
            else if (e.PrevCtrl == Renewal_Button)
            {
                // 最新情報ボタンからの遷移時、更新チェックを追加
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // 遷移先が閉じるボタン
                    _modeFlg = true;
                }
                // ----- UPD 2011/09/08 -------------------->>>>>
                //else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero")
                else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero2")
                // ----- UPD 2011/09/08 --------------------<<<<<
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
            }
            else if (e.PrevCtrl == SalesSlipPrtDiv_tComboEditor)
            {
                if ((e.ShiftKey) && (e.Key == Keys.Tab))
                {
                    // SHIFT+TAB制御
                    if (!tEdit_SectionCodeAllowZero2.Enabled)
                    {
                        e.NextCtrl = Cancel_Button;
                    }
                    else
                    {
                        if (SectionName_tEdit.DataText != "")
                        {
                            e.NextCtrl = tEdit_SectionCodeAllowZero2;
                        }
                    }
                }
            }
            //>>>2010/08/03
            // 受信処理起動端末
            else if (e.PrevCtrl == tEdit_CashRegisterNo)
            {
                int cashRegisterno = TStrConv.StrToIntDef(tEdit_CashRegisterNo.DataText, 0);
                if (cashRegisterno != 0)
                {
                    PosTerminalMg pos = this._scmTtlStAcs.GetPosTerminalMg(this._enterpriseCode, cashRegisterno);
                    if (pos == null)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_INFO,
                            this.Name,
                            "該当する端末番号が存在しません",
                            -1,
                            MessageBoxButtons.OK
                        );
                        this.tEdit_CashRegisterNo.Clear();
                        this.tEdit_CashRegisterNoNm.Clear();
                        e.NextCtrl = this.tEdit_CashRegisterNo;
                        e.NextCtrl.Select();
                        return;
                    }
                    else
                    {
                        this.tEdit_CashRegisterNoNm.DataText = pos.MachineName;
                    }
                }
                else
                {
                    this.tEdit_CashRegisterNo.Clear();
                    this.tEdit_CashRegisterNoNm.Clear();
                }
            }
            // 受信処理起動間隔
            else if (e.PrevCtrl == tEdit_RcvProcStInterval)
            {
                int rcvProcStInterval = TStrConv.StrToIntDef(tEdit_RcvProcStInterval.DataText, 0);
                // 2011/01/14 >>>
                //if (rcvProcStInterval < 5)
                if (rcvProcStInterval < 1)
                // 2011/01/14 <<<
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        // 2011/01/14 >>>
                        //"5分以上で設定して下さい",
                        "1分以上で設定して下さい",
                        // 2011/01/14 <<<
                        -1,
                        MessageBoxButtons.OK
                    );
                    this.tEdit_RcvProcStInterval.Clear();
                    e.NextCtrl = this.tEdit_RcvProcStInterval;
                    e.NextCtrl.Select();
                    return;
                }
            }
            //<<<2010/08/03
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            else if (e.PrevCtrl == SalesCode_tNedit)
            {
                //販売区分設定(自動回答時)
                if (this.SalesCdStAutoAns_tComboEditor.SelectedIndex != 0)
                {
                    //販売区分コード
                    if (this.SalesCode_tNedit.GetValue() != 0)
                    {
                        //マスタ存在チェック
                        int SalesCode = this.SalesCode_tNedit.GetInt();
                        UserGdBd userGdBd = null;
                        UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                        int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 71, SalesCode, ref acsDataType);

                        if (userGdBd == null || status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || userGdBd.LogicalDeleteCode != 0)
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                this.ultraLabel13.Text + "[" + SalesCode + "] に該当するデータが存在しません。",
                                -1,
                                MessageBoxButtons.OK
                            );
                            this.SalesCode_tNedit.Clear();
                            e.NextCtrl = this.SalesCode_tNedit;
                            e.NextCtrl.Select();
                            return;
                        }
                    }
                }

            }
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
            // 受付従業員コード
            else if (e.PrevCtrl == tEdit_FrontEmployeeCd)
            {
                int frontEmployeeCd = tEdit_FrontEmployeeCd.GetInt();
                if (frontEmployeeCd != 0)
                {
                    if (frontEmployeeCd != _preFrontEmployeeCd)
                    {
                        if (this._employeeAcs == null)
                        {
                            this._employeeAcs = new EmployeeAcs();
                        }
                        string employeeNm = GetFrontEmployeeNm(frontEmployeeCd.ToString().PadLeft(4, '0'));
                        if (string.IsNullOrEmpty(employeeNm))
                        {
                            // DEL 2012/11/20 2012/12/12配信予定 システムテスト障害№29対応 ---------------------->>>>>
                            //this.tEdit_FrontEmployeeCd.SetInt(_preFrontEmployeeCd);
                            // DEL 2012/11/20 2012/12/12配信予定 システムテスト障害№29対応 ----------------------<<<<<
                            // 入力チェック
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "従業員が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            tEdit_FrontEmployeeCd.Clear();
                            // ADD 2012/11/20 2012/12/12配信予定 システムテスト障害№29対応 ---------------------->>>>>
                            tEdit_FrontEmployeeNm.Clear();
                            _preFrontEmployeeCd = 0;
                            // ADD 2012/11/20 2012/12/12配信予定 システムテスト障害№29対応 ----------------------<<<<<
                            e.NextCtrl = tEdit_FrontEmployeeCd;
                            e.NextCtrl.Select();
                            return;
                        }
                        else
                        {
                            this.tEdit_FrontEmployeeNm.Text = employeeNm;
                            _preFrontEmployeeCd = frontEmployeeCd;
                        }
                    }
                }
                else
                {
                    this.tEdit_FrontEmployeeNm.Text = string.Empty;
                    _preFrontEmployeeCd = 0;
                }
            }
            // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<
            // --------------- ADD START 2013/04/11 wangl2 FOR RedMine#35269------>>>> 
            // 売上入力者コード
            else if (e.PrevCtrl == tEdit_SalesInputCode)
            {
                int salesInputCode = tEdit_SalesInputCode.GetInt();
                if (salesInputCode != 0)
                {
                    if (salesInputCode != _preSalesInputCode)
                    {
                        if (this._employeeAcs == null)
                        {
                            this._employeeAcs = new EmployeeAcs();
                        }
                        string salesInputCodeNm = GetFrontEmployeeNm(salesInputCode.ToString().PadLeft(4, '0'));
                        if (string.IsNullOrEmpty(salesInputCodeNm))
                        {
                            // 入力チェック
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "発行者が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            tEdit_SalesInputCode.Clear();
                            tEdit_SalesInputNm.Clear();
                            _preSalesInputCode = 0;
                            e.NextCtrl = tEdit_SalesInputCode;
                            e.NextCtrl.Select();
                            return;
                        }
                        else
                        {
                            this.tEdit_SalesInputNm.Text = salesInputCodeNm;
                            _preSalesInputCode = salesInputCode;
                        }
                    }
                }
                else
                {
                    this.tEdit_SalesInputNm.Text = string.Empty;
                    _preSalesInputCode = 0;
                }
            }
            // --------------- ADD END 2013/04/11 wangl2 FOR RedMine#35269------<<<<<
            // ADD 2013/06/11 吉岡 2013/06/18配信 システムテスト障害№37 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region フォーカス制御のみ
            // マウスクリックの場合と、↑↓←→キーの場合は処理無し
            if (e.Key.Equals(Keys.LButton)
                || e.Key.Equals(Keys.RButton)
                || e.Key.Equals(Keys.Up)
                || e.Key.Equals(Keys.Down)
                || e.Key.Equals(Keys.Left)
                || e.Key.Equals(Keys.Right)
                )
            {
                return;
            }

            if (e.PrevCtrl == tEdit_SectionCodeAllowZero2)
            {
                if (e.ShiftKey)
                {
                    e.NextCtrl = Cancel_Button;
                }
                else
                {
                    e.NextCtrl = SectionGuide_Button;
                }
            }
            else if (e.PrevCtrl == SalesSlipPrtDiv_tComboEditor)
            {
                if (e.ShiftKey)
                {
                    if (tEdit_SectionCodeAllowZero2.Enabled)
                    {
                        e.NextCtrl = SectionGuide_Button;
                    }
                    else
                    {
                        e.NextCtrl = Cancel_Button;
                    }
                }
            }
            else if (e.PrevCtrl == SectionGuide_Button)
            {
                if (e.ShiftKey)
                {
                    e.NextCtrl = tEdit_SectionCodeAllowZero2;
                }
                else
                {
                    e.NextCtrl = SalesSlipPrtDiv_tComboEditor;
                }
            }
            else if (e.PrevCtrl == DeliveredGoodsDiv_tComboEditor)
            {
                if (!e.ShiftKey)
                {
                    e.NextCtrl = tEdit_SalesInputCode;
                }
            }
            else if (e.PrevCtrl == Cancel_Button)
            {
                if (this.Mode_Label.Text == DELETE_MODE) return;

                if (e.ShiftKey)
                {
                    e.NextCtrl = Ok_Button;
                }
                else
                {
                    if (tEdit_SectionCodeAllowZero2.Enabled)
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                    else
                    {
                        e.NextCtrl = SalesSlipPrtDiv_tComboEditor;
                    }
                }
            }
            else if (e.PrevCtrl == Ok_Button)
            {
                if (e.ShiftKey)
                {
                    if (Renewal_Button.Visible)
                    {
                        e.NextCtrl = Renewal_Button;
                    }
                    else
                    {
                        e.NextCtrl = Delete_Button;
                    }
                }
                else
                {
                    e.NextCtrl = Cancel_Button;
                }
            }
            else if (e.PrevCtrl == tEdit_SalesInputCode)
            {
                if (e.ShiftKey)
                {
                    e.NextCtrl = DeliveredGoodsDiv_tComboEditor;
                }
            }
            else if (e.PrevCtrl == DataUpdWarehouseDiv_tComboEditor)
            {
                if (!e.ShiftKey)
                {
                    if (Renewal_Button.Visible)
                    {
                        e.NextCtrl = Renewal_Button;
                    }
                    else
                    {
                        e.NextCtrl = Delete_Button;
                    }
                }
            }
            else if (e.PrevCtrl == Renewal_Button)
            {
                if (e.ShiftKey)
                {
                    e.NextCtrl = DataUpdWarehouseDiv_tComboEditor;
                }
                else
                {
                    e.NextCtrl = Ok_Button;
                }
            }
            #endregion
            // ADD 2013/06/11 吉岡 2013/06/18配信 システムテスト障害№37 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// 最新情報ボタンクリック
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            // ADD 2012/11/20 2012/12/12配信予定 システムテスト障害№28対応 ------------------------------------>>>>>
            // 従業員マスタ再取得
            this._employeeAcs = null;
            this._employeeTb = null;
            GetAllEmployeeNm();
            //受付従業員名称
            this.tEdit_FrontEmployeeNm.Text = GetFrontEmployeeNm(this.tEdit_FrontEmployeeCd.Text);
            // ADD 2012/11/20 2012/12/12配信予定 システムテスト障害№28対応 ------------------------------------<<<<<

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        /// <summary>
        /// 旧システム連携フォルダボタンクリック
        /// </summary>
        private void OldSysCoopFolder_Button_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            //RootFolder以下にあるフォルダである必要がある
            fbd.SelectedPath = @"C:\SCMSHARE";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = false;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                tEdit_OldSysCoopFolder.Text = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// 旧システム連携区分 値変更
        /// </summary>
        private void OldSysCooperatDiv_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (OldSysCooperatDiv_tComEditor.SelectedIndex == 0)
            {
                // 旧システム連携をしない
                tEdit_OldSysCoopFolder.DataText = "";
                tEdit_OldSysCoopFolder.Enabled = false;
                OldSysCoopFolder_Button.Enabled = false;
            }
            else
            {
                // 旧システム連携をする
                tEdit_OldSysCoopFolder.Enabled = true;
                OldSysCoopFolder_Button.Enabled = true;
            }
        }

        /// <summary>
        /// 値引適用区分 値変更
        /// </summary>
        private void DiscountApplyCd_tComEditor_ValueChanged(object sender, EventArgs e)
        {
            if (DiscountApplyCd_tComEditor.SelectedIndex == 0)
            {
                // 値引適用をしない
                AutoCooperatDis_tNedit.DataText = "";
                AutoCooperatDis_tNedit.Enabled = false;
            }
            else
            {
                // 値引適用が上記以外
                AutoCooperatDis_tNedit.Enabled = true;
            }
        }

		#endregion

        // -------------------- ADD 2011/09/08 ------------------- >>>>>
        /// <summary>
        /// tEdit_SectionCodeAllowZero2_Enter イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : tEdit_SectionCodeAllowZero2_Enter イベント</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/09/08</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero2_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text))
            {
                tEdit_SectionCodeAllowZero2.Text = Convert.ToInt32(tEdit_SectionCodeAllowZero2.Text).ToString();
            }
        }

        /// <summary>
        /// tEdit_SectionCodeAllowZero2_Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : tEdit_SectionCodeAllowZero2_Leave イベント</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/09/08</br>
        /// </remarks>
        private void tEdit_SectionCodeAllowZero2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text))
            {
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
            }
        }

        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        private void SalesCdStAutoAns_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (SalesCdStAutoAns_tComboEditor.SelectedIndex == 0)
            {
                // 販売区分設定をしない
                SalesCode_tNedit.DataText = "";
                SalesCode_tNedit.Enabled = false;
                uButton_SalesCode.Enabled = false;
            }
            else
            {
                // 販売区分設定が上記以外
                SalesCode_tNedit.Enabled = true;
                uButton_SalesCode.Enabled = true;
            }
        }

        //2012/04/20 ADD T.Nishi <<<<<<<<<<
        // -------------------- ADD 2011/09/08 ------------------- <<<<<
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ---------------------------------->>>>>
        /// <summary>
        /// ユーザーガイド設定の納品区分の取得
        /// </summary>
        /// <remarks>
        /// <param name="enterpriseCode"> 企業コード</param>
        /// <br>Note       : ユーザーガイド設定の納品区分を取得します。</br>
        /// <br>Programmer : 湯上 千加子</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void SetDelivereds(string enterpriseCode)
        {
            //ユーザーガイド設定の納品区分の取得
            ArrayList userGuidList = null;
            //納品区分の項目
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            this._userGuideAcs.SearchAllDivCodeBody(out userGuidList, enterpriseCode, USERGUIDEDIVCD, UserGuideAcsData.UserBodyData);
            _userGdBdTb = new Hashtable();
            DeliveredGoodsDiv_tComboEditor.Items.Clear();
            if (userGuidList != null || userGuidList.Count > 0)
            {
                foreach (UserGdBd userGdBd in userGuidList)
                {

                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        DeliveredGoodsDiv_tComboEditor.Items.Add(userGdBd.GuideCode, userGdBd.GuideName);
                        _userGdBdTb.Add(userGdBd.GuideCode, userGdBd.GuideName);
                    }
                }
            }
            if (this.DeliveredGoodsDiv_tComboEditor.SelectedItem == null && this.DeliveredGoodsDiv_tComboEditor.Items.Count == 0)
            {
                DeliveredGoodsDiv_tComboEditor.Items.Add(string.Empty, string.Empty);
                _userGdBdTb.Add(string.Empty, string.Empty);
            }
            this.DeliveredGoodsDiv_tComboEditor.SelectedIndex = 0;

        }
        /// <summary>
        /// 納品区分名称の取得
        /// </summary>
        /// <param name="deliveredGoodsDiv"> 納品区分</param>
        /// <remarks>
        /// <returns>納品区分名称</returns>
        /// <br>Note       : 納品区分名称を取得します。</br>
        /// <br>Programmer : 湯上 千加子</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private string GetDeliveredName(int deliveredGoodsDiv)
        {
            string deliveredName = string.Empty;
            if (this._userGdBdTb != null && this._userGdBdTb.ContainsKey(deliveredGoodsDiv))
            {
                deliveredName = (string)this._userGdBdTb[deliveredGoodsDiv];
            }
            return deliveredName;
        }
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341対応 ----------------------------------<<<<<

	}
}

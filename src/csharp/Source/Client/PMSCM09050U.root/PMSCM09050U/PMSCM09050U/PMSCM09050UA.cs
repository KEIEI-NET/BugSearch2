//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : SCM相場価格設定マスタ
// プログラム概要   : SCM相場価格設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/08/26  修正内容 : チケット[14168]対応
//----------------------------------------------------------------------------//
// 管理番号 10601193-00  作成担当 : 21024　佐々木 健
// 作 成 日  2010/04/12  修正内容 : 相場価格品質コード２、相場価格品質コード３の追加
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.RCDS.Web.Services;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// SCM相場価格設定フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: SCM相場価格設定を行います。
	///					  IMasterMaintenanceMultiTypeを実装しています。</br>   
	/// <br></br>
    /// </remarks>
	public class PMSCM09050UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel MarketPriceSalesRate_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_MarketPriceSalesRate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel MarketPriceKindCd2_uLabel;
		private Broadleaf.Library.Windows.Forms.TComboEditor MarketPriceKindCd2_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel MarketPriceAreaCd_uLabel;
        private Broadleaf.Library.Windows.Forms.TComboEditor MarketPriceAreaCd_tComEditor;
		private Infragistics.Win.Misc.UltraLabel MarketPriceQualityCd_uLabel;
		private Infragistics.Win.Misc.UltraLabel Section_uLabel;
		private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel MarketPriceAnswerDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel AddPaymntAmbit_uLabel;
        private Infragistics.Win.Misc.UltraLabel MarketPriceKindCd1_uLabel;
        private TComboEditor MarketPriceKindCd1_tComboEditor;
        private TComboEditor MarketPriceAnswerDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private TEdit tEdit_SectionCodeAllowZero;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private TComboEditor MarketPriceKindCd3_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel MarketPriceKindCd3_uLabel;
        private TNedit tNedit_AddPaymnt10;
        private TNedit tNedit_AddPaymntAmbit10;
        private TNedit tNedit_AddPaymnt9;
        private TNedit tNedit_AddPaymntAmbit9;
        private TNedit tNedit_AddPaymnt8;
        private TNedit tNedit_AddPaymntAmbit8;
        private TNedit tNedit_AddPaymnt7;
        private TNedit tNedit_AddPaymntAmbit7;
        private TNedit tNedit_AddPaymnt6;
        private TNedit tNedit_AddPaymntAmbit6;
        private TNedit tNedit_AddPaymnt5;
        private TNedit tNedit_AddPaymntAmbit5;
        private TNedit tNedit_AddPaymnt4;
        private TNedit tNedit_AddPaymntAmbit4;
        private TNedit tNedit_AddPaymnt3;
        private TNedit tNedit_AddPaymntAmbit3;
        private TNedit tNedit_AddPaymnt2;
        private TNedit tNedit_AddPaymntAmbit2;
        private TNedit tNedit_AddPaymnt1;
        private TNedit tNedit_AddPaymntAmbit1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel34;
        private Infragistics.Win.Misc.UltraLabel ultraLabel30;
        private Infragistics.Win.Misc.UltraLabel ultraLabel33;
        private Infragistics.Win.Misc.UltraLabel ultraLabel32;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private Infragistics.Win.Misc.UltraLabel ultraLabel29;
        private Infragistics.Win.Misc.UltraLabel ultraLabel31;
        private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private Infragistics.Win.Misc.UltraLabel ultraLabel28;
        private Infragistics.Win.Misc.UltraLabel ultraLabel35;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Infragistics.Win.Misc.UltraLabel ultraLabel44;
        private Infragistics.Win.Misc.UltraLabel ultraLabel42;
        private Infragistics.Win.Misc.UltraLabel ultraLabel38;
        private Infragistics.Win.Misc.UltraLabel ultraLabel41;
        private Infragistics.Win.Misc.UltraLabel ultraLabel36;
        private Infragistics.Win.Misc.UltraLabel ultraLabel43;
        private Infragistics.Win.Misc.UltraLabel ultraLabel40;
        private Infragistics.Win.Misc.UltraLabel ultraLabel37;
        private Infragistics.Win.Misc.UltraLabel ultraLabel39;
        private Infragistics.Win.Misc.UltraLabel FractionProcCd_uLabel;
        private TComboEditor FractionProcCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AddPaymnt_uLabel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private TComboEditor MarketPriceQualityCd3_tComEditor;
        private TComboEditor MarketPriceQualityCd2_tComEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Broadleaf.Library.Windows.Forms.TComboEditor MarketPriceQualityCd_tComEditor;
		#endregion

		#region -- Constructor --
		/// <summary>
        /// SCM相場価格設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note		: SCM相場価格設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br></br>
		/// </remarks>
        public PMSCM09050UA()
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
            this._scmMrktPriStAcs = new SCMMrktPriStAcs();
            this._totalCount = 0;
            this._scmMrktPriStTable = new Hashtable();

            //_dataIndexバッファ（メインフレーム最小化対応）
            this._indexBuf = -2;

            // 拠点設定アクセスクラス
            this._secInfoAcs = new SecInfoAcs();

            // 相場情報取得
            GetSobaInfo();
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
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM09050UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceSalesRate_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_MarketPriceSalesRate = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceKindCd2_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceKindCd2_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MarketPriceAreaCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceAreaCd_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MarketPriceQualityCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceQualityCd_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.MarketPriceAnswerDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.AddPaymntAmbit_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceKindCd1_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceAnswerDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MarketPriceKindCd1_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceKindCd3_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceKindCd3_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tNedit_AddPaymntAmbit1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit4 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit5 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit6 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit7 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit8 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit9 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit10 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt4 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt5 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt6 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt7 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt8 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt9 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt10 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel35 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel36 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel37 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel38 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel41 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel43 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel44 = new Infragistics.Win.Misc.UltraLabel();
            this.FractionProcCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.FractionProcCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AddPaymnt_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceQualityCd2_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MarketPriceQualityCd3_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_MarketPriceSalesRate ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd2_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceAreaCd_tComEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd_tComEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.SectionName_tEdit ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.Bind_DataSet ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceAnswerDiv_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd1_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_SectionCodeAllowZero ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd3_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit2 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit3 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit4 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit5 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit6 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit7 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit8 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit9 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit10 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt2 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt3 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt4 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt5 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt6 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt7 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt8 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt9 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt10 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.FractionProcCd_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd2_tComEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd3_tComEditor ) ).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(573, 667);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 35;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(445, 667);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 32;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 711);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(713, 23);
            this.ultraStatusBar1.TabIndex = 11;
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
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "更新モード";
            // 
            // MarketPriceSalesRate_uLabel
            // 
            appearance137.TextVAlignAsString = "Middle";
            this.MarketPriceSalesRate_uLabel.Appearance = appearance137;
            this.MarketPriceSalesRate_uLabel.Location = new System.Drawing.Point(16, 279);
            this.MarketPriceSalesRate_uLabel.Name = "MarketPriceSalesRate_uLabel";
            this.MarketPriceSalesRate_uLabel.Size = new System.Drawing.Size(165, 24);
            this.MarketPriceSalesRate_uLabel.TabIndex = 171;
            this.MarketPriceSalesRate_uLabel.Text = "相場価格売価率";
            // 
            // tNedit_MarketPriceSalesRate
            // 
            appearance138.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance138.ForeColor = System.Drawing.Color.Black;
            appearance138.TextHAlignAsString = "Right";
            this.tNedit_MarketPriceSalesRate.ActiveAppearance = appearance138;
            appearance139.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance139.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance139.ForeColor = System.Drawing.Color.Black;
            appearance139.ForeColorDisabled = System.Drawing.Color.Black;
            appearance139.TextHAlignAsString = "Right";
            appearance139.TextVAlignAsString = "Middle";
            this.tNedit_MarketPriceSalesRate.Appearance = appearance139;
            this.tNedit_MarketPriceSalesRate.AutoSelect = true;
            this.tNedit_MarketPriceSalesRate.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.tNedit_MarketPriceSalesRate.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MarketPriceSalesRate.DataText = "";
            this.tNedit_MarketPriceSalesRate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MarketPriceSalesRate.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_MarketPriceSalesRate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MarketPriceSalesRate.Location = new System.Drawing.Point(221, 279);
            this.tNedit_MarketPriceSalesRate.MaxLength = 6;
            this.tNedit_MarketPriceSalesRate.Name = "tNedit_MarketPriceSalesRate";
            this.tNedit_MarketPriceSalesRate.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MarketPriceSalesRate.Size = new System.Drawing.Size(82, 24);
            this.tNedit_MarketPriceSalesRate.TabIndex = 11;
            this.tNedit_MarketPriceSalesRate.Leave += new System.EventHandler(this.tNedit_MarketPriceSalesRate_Leave);
            // 
            // ultraLabel1
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance13;
            this.ultraLabel1.Location = new System.Drawing.Point(327, 279);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel1.TabIndex = 173;
            this.ultraLabel1.Text = "％";
            // 
            // MarketPriceKindCd2_uLabel
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd2_uLabel.Appearance = appearance12;
            this.MarketPriceKindCd2_uLabel.Location = new System.Drawing.Point(187, 201);
            this.MarketPriceKindCd2_uLabel.Name = "MarketPriceKindCd2_uLabel";
            this.MarketPriceKindCd2_uLabel.Size = new System.Drawing.Size(28, 24);
            this.MarketPriceKindCd2_uLabel.TabIndex = 177;
            this.MarketPriceKindCd2_uLabel.Text = "2";
            // 
            // MarketPriceKindCd2_tComboEditor
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd2_tComboEditor.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceKindCd2_tComboEditor.Appearance = appearance15;
            this.MarketPriceKindCd2_tComboEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceKindCd2_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceKindCd2_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance16.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceKindCd2_tComboEditor.ItemAppearance = appearance16;
            this.MarketPriceKindCd2_tComboEditor.Location = new System.Drawing.Point(221, 201);
            this.MarketPriceKindCd2_tComboEditor.Name = "MarketPriceKindCd2_tComboEditor";
            this.MarketPriceKindCd2_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceKindCd2_tComboEditor.TabIndex = 7;
            this.MarketPriceKindCd2_tComboEditor.ValueChanged += new System.EventHandler(this.MarketPriceKindCd2_tComboEditor_ValueChanged);
            // 
            // MarketPriceAreaCd_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.MarketPriceAreaCd_uLabel.Appearance = appearance22;
            this.MarketPriceAreaCd_uLabel.Location = new System.Drawing.Point(16, 120);
            this.MarketPriceAreaCd_uLabel.Name = "MarketPriceAreaCd_uLabel";
            this.MarketPriceAreaCd_uLabel.Size = new System.Drawing.Size(165, 24);
            this.MarketPriceAreaCd_uLabel.TabIndex = 179;
            this.MarketPriceAreaCd_uLabel.Text = "相場価格地域";
            // 
            // MarketPriceAreaCd_tComEditor
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.MarketPriceAreaCd_tComEditor.ActiveAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceAreaCd_tComEditor.Appearance = appearance24;
            this.MarketPriceAreaCd_tComEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceAreaCd_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceAreaCd_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance25.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceAreaCd_tComEditor.ItemAppearance = appearance25;
            this.MarketPriceAreaCd_tComEditor.Location = new System.Drawing.Point(221, 120);
            this.MarketPriceAreaCd_tComEditor.Name = "MarketPriceAreaCd_tComEditor";
            this.MarketPriceAreaCd_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceAreaCd_tComEditor.TabIndex = 4;
            // 
            // MarketPriceQualityCd_uLabel
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.MarketPriceQualityCd_uLabel.Appearance = appearance30;
            this.MarketPriceQualityCd_uLabel.Location = new System.Drawing.Point(451, 150);
            this.MarketPriceQualityCd_uLabel.Name = "MarketPriceQualityCd_uLabel";
            this.MarketPriceQualityCd_uLabel.Size = new System.Drawing.Size(165, 24);
            this.MarketPriceQualityCd_uLabel.TabIndex = 183;
            this.MarketPriceQualityCd_uLabel.Text = "品質";
            // 
            // MarketPriceQualityCd_tComEditor
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance55.ForeColor = System.Drawing.Color.Black;
            appearance55.TextVAlignAsString = "Middle";
            this.MarketPriceQualityCd_tComEditor.ActiveAppearance = appearance55;
            appearance56.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance56.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance56.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceQualityCd_tComEditor.Appearance = appearance56;
            this.MarketPriceQualityCd_tComEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceQualityCd_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceQualityCd_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance62.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceQualityCd_tComEditor.ItemAppearance = appearance62;
            this.MarketPriceQualityCd_tComEditor.Location = new System.Drawing.Point(451, 174);
            this.MarketPriceQualityCd_tComEditor.Name = "MarketPriceQualityCd_tComEditor";
            this.MarketPriceQualityCd_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceQualityCd_tComEditor.TabIndex = 6;
            // 
            // Section_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance4;
            this.Section_uLabel.Location = new System.Drawing.Point(16, 42);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(165, 24);
            this.Section_uLabel.TabIndex = 184;
            this.Section_uLabel.Text = "拠点";
            // 
            // SectionName_tEdit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.SectionName_tEdit.ActiveAppearance = appearance2;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance3;
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
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // MarketPriceAnswerDiv_uLabel
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.MarketPriceAnswerDiv_uLabel.Appearance = appearance68;
            this.MarketPriceAnswerDiv_uLabel.Location = new System.Drawing.Point(16, 81);
            this.MarketPriceAnswerDiv_uLabel.Name = "MarketPriceAnswerDiv_uLabel";
            this.MarketPriceAnswerDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.MarketPriceAnswerDiv_uLabel.TabIndex = 253;
            this.MarketPriceAnswerDiv_uLabel.Text = "相場価格回答区分";
            // 
            // AddPaymntAmbit_uLabel
            // 
            appearance51.TextVAlignAsString = "Middle";
            this.AddPaymntAmbit_uLabel.Appearance = appearance51;
            this.AddPaymntAmbit_uLabel.Location = new System.Drawing.Point(16, 339);
            this.AddPaymntAmbit_uLabel.Name = "AddPaymntAmbit_uLabel";
            this.AddPaymntAmbit_uLabel.Size = new System.Drawing.Size(199, 24);
            this.AddPaymntAmbit_uLabel.TabIndex = 259;
            this.AddPaymntAmbit_uLabel.Text = "料金テーブル";
            // 
            // MarketPriceKindCd1_uLabel
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd1_uLabel.Appearance = appearance73;
            this.MarketPriceKindCd1_uLabel.Location = new System.Drawing.Point(16, 150);
            this.MarketPriceKindCd1_uLabel.Name = "MarketPriceKindCd1_uLabel";
            this.MarketPriceKindCd1_uLabel.Size = new System.Drawing.Size(165, 24);
            this.MarketPriceKindCd1_uLabel.TabIndex = 258;
            this.MarketPriceKindCd1_uLabel.Text = "相場価格情報";
            // 
            // MarketPriceAnswerDiv_tComboEditor
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.MarketPriceAnswerDiv_tComboEditor.ActiveAppearance = appearance58;
            appearance59.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceAnswerDiv_tComboEditor.Appearance = appearance59;
            this.MarketPriceAnswerDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceAnswerDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceAnswerDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance60.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceAnswerDiv_tComboEditor.ItemAppearance = appearance60;
            this.MarketPriceAnswerDiv_tComboEditor.Location = new System.Drawing.Point(221, 81);
            this.MarketPriceAnswerDiv_tComboEditor.Name = "MarketPriceAnswerDiv_tComboEditor";
            this.MarketPriceAnswerDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceAnswerDiv_tComboEditor.TabIndex = 3;
            this.MarketPriceAnswerDiv_tComboEditor.ValueChanged += new System.EventHandler(this.MarketPriceAnswerDiv_tComboEditor_ValueChanged);
            // 
            // MarketPriceKindCd1_tComboEditor
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd1_tComboEditor.ActiveAppearance = appearance43;
            appearance44.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance44.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceKindCd1_tComboEditor.Appearance = appearance44;
            this.MarketPriceKindCd1_tComboEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceKindCd1_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceKindCd1_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance45.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceKindCd1_tComboEditor.ItemAppearance = appearance45;
            this.MarketPriceKindCd1_tComboEditor.Location = new System.Drawing.Point(221, 174);
            this.MarketPriceKindCd1_tComboEditor.Name = "MarketPriceKindCd1_tComboEditor";
            this.MarketPriceKindCd1_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceKindCd1_tComboEditor.TabIndex = 5;
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(16, 72);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(675, 3);
            this.DivideLine_Label.TabIndex = 261;
            // 
            // ultraLabel6
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance34;
            this.ultraLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ultraLabel6.Location = new System.Drawing.Point(487, 42);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(223, 24);
            this.ultraLabel6.TabIndex = 262;
            this.ultraLabel6.Text = "※ゼロで共通設定になります";
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(445, 667);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 34;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(316, 667);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 31;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance7.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance7;
            appearance11.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.Appearance = appearance11;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(221, 42);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 0;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(316, 667);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 33;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel5.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel5.Location = new System.Drawing.Point(16, 111);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(675, 3);
            this.ultraLabel5.TabIndex = 261;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel2.Location = new System.Drawing.Point(16, 270);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(675, 3);
            this.ultraLabel2.TabIndex = 261;
            // 
            // MarketPriceKindCd3_uLabel
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd3_uLabel.Appearance = appearance18;
            this.MarketPriceKindCd3_uLabel.Location = new System.Drawing.Point(187, 228);
            this.MarketPriceKindCd3_uLabel.Name = "MarketPriceKindCd3_uLabel";
            this.MarketPriceKindCd3_uLabel.Size = new System.Drawing.Size(28, 24);
            this.MarketPriceKindCd3_uLabel.TabIndex = 177;
            this.MarketPriceKindCd3_uLabel.Text = "3";
            // 
            // MarketPriceKindCd3_tComboEditor
            // 
            appearance140.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance140.ForeColor = System.Drawing.Color.Black;
            appearance140.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd3_tComboEditor.ActiveAppearance = appearance140;
            appearance141.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance141.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance141.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceKindCd3_tComboEditor.Appearance = appearance141;
            this.MarketPriceKindCd3_tComboEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceKindCd3_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceKindCd3_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance142.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceKindCd3_tComboEditor.ItemAppearance = appearance142;
            this.MarketPriceKindCd3_tComboEditor.Location = new System.Drawing.Point(221, 228);
            this.MarketPriceKindCd3_tComboEditor.Name = "MarketPriceKindCd3_tComboEditor";
            this.MarketPriceKindCd3_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceKindCd3_tComboEditor.TabIndex = 9;
            this.MarketPriceKindCd3_tComboEditor.ValueChanged += new System.EventHandler(this.MarketPriceKindCd3_tComboEditor_ValueChanged);
            // 
            // tNedit_AddPaymntAmbit1
            // 
            appearance95.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance95.ForeColor = System.Drawing.Color.Black;
            appearance95.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit1.ActiveAppearance = appearance95;
            appearance96.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance96.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance96.ForeColor = System.Drawing.Color.Black;
            appearance96.ForeColorDisabled = System.Drawing.Color.Black;
            appearance96.TextHAlignAsString = "Right";
            appearance96.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit1.Appearance = appearance96;
            this.tNedit_AddPaymntAmbit1.AutoSelect = true;
            this.tNedit_AddPaymntAmbit1.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.tNedit_AddPaymntAmbit1.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit1.DataText = "";
            this.tNedit_AddPaymntAmbit1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit1.Location = new System.Drawing.Point(47, 368);
            this.tNedit_AddPaymntAmbit1.MaxLength = 10;
            this.tNedit_AddPaymntAmbit1.Name = "tNedit_AddPaymntAmbit1";
            this.tNedit_AddPaymntAmbit1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit1.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit1.TabIndex = 13;
            // 
            // tNedit_AddPaymntAmbit2
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance91.ForeColor = System.Drawing.Color.Black;
            appearance91.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit2.ActiveAppearance = appearance91;
            appearance92.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance92.ForeColor = System.Drawing.Color.Black;
            appearance92.ForeColorDisabled = System.Drawing.Color.Black;
            appearance92.TextHAlignAsString = "Right";
            appearance92.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit2.Appearance = appearance92;
            this.tNedit_AddPaymntAmbit2.AutoSelect = true;
            this.tNedit_AddPaymntAmbit2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit2.DataText = "";
            this.tNedit_AddPaymntAmbit2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit2.Location = new System.Drawing.Point(47, 395);
            this.tNedit_AddPaymntAmbit2.MaxLength = 10;
            this.tNedit_AddPaymntAmbit2.Name = "tNedit_AddPaymntAmbit2";
            this.tNedit_AddPaymntAmbit2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit2.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit2.TabIndex = 15;
            // 
            // tNedit_AddPaymntAmbit3
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance87.ForeColor = System.Drawing.Color.Black;
            appearance87.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit3.ActiveAppearance = appearance87;
            appearance88.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance88.ForeColor = System.Drawing.Color.Black;
            appearance88.ForeColorDisabled = System.Drawing.Color.Black;
            appearance88.TextHAlignAsString = "Right";
            appearance88.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit3.Appearance = appearance88;
            this.tNedit_AddPaymntAmbit3.AutoSelect = true;
            this.tNedit_AddPaymntAmbit3.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit3.DataText = "";
            this.tNedit_AddPaymntAmbit3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit3.Location = new System.Drawing.Point(47, 422);
            this.tNedit_AddPaymntAmbit3.MaxLength = 10;
            this.tNedit_AddPaymntAmbit3.Name = "tNedit_AddPaymntAmbit3";
            this.tNedit_AddPaymntAmbit3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit3.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit3.TabIndex = 17;
            // 
            // tNedit_AddPaymntAmbit4
            // 
            appearance83.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance83.ForeColor = System.Drawing.Color.Black;
            appearance83.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit4.ActiveAppearance = appearance83;
            appearance84.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance84.ForeColor = System.Drawing.Color.Black;
            appearance84.ForeColorDisabled = System.Drawing.Color.Black;
            appearance84.TextHAlignAsString = "Right";
            appearance84.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit4.Appearance = appearance84;
            this.tNedit_AddPaymntAmbit4.AutoSelect = true;
            this.tNedit_AddPaymntAmbit4.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit4.DataText = "";
            this.tNedit_AddPaymntAmbit4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit4.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit4.Location = new System.Drawing.Point(47, 449);
            this.tNedit_AddPaymntAmbit4.MaxLength = 10;
            this.tNedit_AddPaymntAmbit4.Name = "tNedit_AddPaymntAmbit4";
            this.tNedit_AddPaymntAmbit4.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit4.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit4.TabIndex = 19;
            // 
            // tNedit_AddPaymntAmbit5
            // 
            appearance79.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance79.ForeColor = System.Drawing.Color.Black;
            appearance79.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit5.ActiveAppearance = appearance79;
            appearance80.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance80.ForeColor = System.Drawing.Color.Black;
            appearance80.ForeColorDisabled = System.Drawing.Color.Black;
            appearance80.TextHAlignAsString = "Right";
            appearance80.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit5.Appearance = appearance80;
            this.tNedit_AddPaymntAmbit5.AutoSelect = true;
            this.tNedit_AddPaymntAmbit5.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit5.DataText = "";
            this.tNedit_AddPaymntAmbit5.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit5.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit5.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit5.Location = new System.Drawing.Point(47, 476);
            this.tNedit_AddPaymntAmbit5.MaxLength = 10;
            this.tNedit_AddPaymntAmbit5.Name = "tNedit_AddPaymntAmbit5";
            this.tNedit_AddPaymntAmbit5.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit5.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit5.TabIndex = 21;
            // 
            // tNedit_AddPaymntAmbit6
            // 
            appearance75.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance75.ForeColor = System.Drawing.Color.Black;
            appearance75.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit6.ActiveAppearance = appearance75;
            appearance76.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance76.ForeColor = System.Drawing.Color.Black;
            appearance76.ForeColorDisabled = System.Drawing.Color.Black;
            appearance76.TextHAlignAsString = "Right";
            appearance76.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit6.Appearance = appearance76;
            this.tNedit_AddPaymntAmbit6.AutoSelect = true;
            this.tNedit_AddPaymntAmbit6.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit6.DataText = "";
            this.tNedit_AddPaymntAmbit6.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit6.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit6.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit6.Location = new System.Drawing.Point(47, 503);
            this.tNedit_AddPaymntAmbit6.MaxLength = 10;
            this.tNedit_AddPaymntAmbit6.Name = "tNedit_AddPaymntAmbit6";
            this.tNedit_AddPaymntAmbit6.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit6.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit6.TabIndex = 23;
            // 
            // tNedit_AddPaymntAmbit7
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance71.ForeColor = System.Drawing.Color.Black;
            appearance71.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit7.ActiveAppearance = appearance71;
            appearance72.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance72.ForeColor = System.Drawing.Color.Black;
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            appearance72.TextHAlignAsString = "Right";
            appearance72.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit7.Appearance = appearance72;
            this.tNedit_AddPaymntAmbit7.AutoSelect = true;
            this.tNedit_AddPaymntAmbit7.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit7.DataText = "";
            this.tNedit_AddPaymntAmbit7.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit7.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit7.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit7.Location = new System.Drawing.Point(47, 530);
            this.tNedit_AddPaymntAmbit7.MaxLength = 10;
            this.tNedit_AddPaymntAmbit7.Name = "tNedit_AddPaymntAmbit7";
            this.tNedit_AddPaymntAmbit7.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit7.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit7.TabIndex = 25;
            // 
            // tNedit_AddPaymntAmbit8
            // 
            appearance66.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance66.ForeColor = System.Drawing.Color.Black;
            appearance66.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit8.ActiveAppearance = appearance66;
            appearance67.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance67.ForeColor = System.Drawing.Color.Black;
            appearance67.ForeColorDisabled = System.Drawing.Color.Black;
            appearance67.TextHAlignAsString = "Right";
            appearance67.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit8.Appearance = appearance67;
            this.tNedit_AddPaymntAmbit8.AutoSelect = true;
            this.tNedit_AddPaymntAmbit8.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit8.DataText = "";
            this.tNedit_AddPaymntAmbit8.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit8.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit8.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit8.Location = new System.Drawing.Point(47, 557);
            this.tNedit_AddPaymntAmbit8.MaxLength = 10;
            this.tNedit_AddPaymntAmbit8.Name = "tNedit_AddPaymntAmbit8";
            this.tNedit_AddPaymntAmbit8.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit8.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit8.TabIndex = 27;
            // 
            // tNedit_AddPaymntAmbit9
            // 
            appearance57.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance57.ForeColor = System.Drawing.Color.Black;
            appearance57.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit9.ActiveAppearance = appearance57;
            appearance61.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance61.ForeColor = System.Drawing.Color.Black;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            appearance61.TextHAlignAsString = "Right";
            appearance61.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit9.Appearance = appearance61;
            this.tNedit_AddPaymntAmbit9.AutoSelect = true;
            this.tNedit_AddPaymntAmbit9.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit9.DataText = "";
            this.tNedit_AddPaymntAmbit9.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit9.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit9.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit9.Location = new System.Drawing.Point(47, 584);
            this.tNedit_AddPaymntAmbit9.MaxLength = 10;
            this.tNedit_AddPaymntAmbit9.Name = "tNedit_AddPaymntAmbit9";
            this.tNedit_AddPaymntAmbit9.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit9.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit9.TabIndex = 29;
            // 
            // tNedit_AddPaymntAmbit10
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance53.ForeColor = System.Drawing.Color.Black;
            appearance53.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit10.ActiveAppearance = appearance53;
            appearance54.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance54.ForeColor = System.Drawing.Color.Black;
            appearance54.ForeColorDisabled = System.Drawing.Color.Black;
            appearance54.TextHAlignAsString = "Right";
            appearance54.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit10.Appearance = appearance54;
            this.tNedit_AddPaymntAmbit10.AutoSelect = true;
            this.tNedit_AddPaymntAmbit10.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit10.DataText = "";
            this.tNedit_AddPaymntAmbit10.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit10.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit10.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit10.Location = new System.Drawing.Point(47, 611);
            this.tNedit_AddPaymntAmbit10.MaxLength = 10;
            this.tNedit_AddPaymntAmbit10.Name = "tNedit_AddPaymntAmbit10";
            this.tNedit_AddPaymntAmbit10.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit10.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit10.TabIndex = 31;
            // 
            // tNedit_AddPaymnt1
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt1.ActiveAppearance = appearance49;
            appearance50.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance50.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance50.ForeColor = System.Drawing.Color.Black;
            appearance50.ForeColorDisabled = System.Drawing.Color.Black;
            appearance50.TextHAlignAsString = "Right";
            appearance50.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt1.Appearance = appearance50;
            this.tNedit_AddPaymnt1.AutoSelect = true;
            this.tNedit_AddPaymnt1.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.tNedit_AddPaymnt1.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt1.DataText = "";
            this.tNedit_AddPaymnt1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt1.Location = new System.Drawing.Point(236, 368);
            this.tNedit_AddPaymnt1.MaxLength = 10;
            this.tNedit_AddPaymnt1.Name = "tNedit_AddPaymnt1";
            this.tNedit_AddPaymnt1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt1.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt1.TabIndex = 14;
            // 
            // tNedit_AddPaymnt2
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt2.ActiveAppearance = appearance17;
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Right";
            appearance26.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt2.Appearance = appearance26;
            this.tNedit_AddPaymnt2.AutoSelect = true;
            this.tNedit_AddPaymnt2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt2.DataText = "";
            this.tNedit_AddPaymnt2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt2.Location = new System.Drawing.Point(236, 395);
            this.tNedit_AddPaymnt2.MaxLength = 10;
            this.tNedit_AddPaymnt2.Name = "tNedit_AddPaymnt2";
            this.tNedit_AddPaymnt2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt2.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt2.TabIndex = 16;
            // 
            // tNedit_AddPaymnt3
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt3.ActiveAppearance = appearance40;
            appearance41.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            appearance41.TextHAlignAsString = "Right";
            appearance41.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt3.Appearance = appearance41;
            this.tNedit_AddPaymnt3.AutoSelect = true;
            this.tNedit_AddPaymnt3.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt3.DataText = "";
            this.tNedit_AddPaymnt3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt3.Location = new System.Drawing.Point(236, 422);
            this.tNedit_AddPaymnt3.MaxLength = 10;
            this.tNedit_AddPaymnt3.Name = "tNedit_AddPaymnt3";
            this.tNedit_AddPaymnt3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt3.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt3.TabIndex = 18;
            // 
            // tNedit_AddPaymnt4
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt4.ActiveAppearance = appearance27;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            appearance28.TextHAlignAsString = "Right";
            appearance28.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt4.Appearance = appearance28;
            this.tNedit_AddPaymnt4.AutoSelect = true;
            this.tNedit_AddPaymnt4.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt4.DataText = "";
            this.tNedit_AddPaymnt4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt4.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt4.Location = new System.Drawing.Point(236, 449);
            this.tNedit_AddPaymnt4.MaxLength = 10;
            this.tNedit_AddPaymnt4.Name = "tNedit_AddPaymnt4";
            this.tNedit_AddPaymnt4.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt4.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt4.TabIndex = 20;
            // 
            // tNedit_AddPaymnt5
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt5.ActiveAppearance = appearance42;
            appearance46.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance46.ForeColor = System.Drawing.Color.Black;
            appearance46.ForeColorDisabled = System.Drawing.Color.Black;
            appearance46.TextHAlignAsString = "Right";
            appearance46.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt5.Appearance = appearance46;
            this.tNedit_AddPaymnt5.AutoSelect = true;
            this.tNedit_AddPaymnt5.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt5.DataText = "";
            this.tNedit_AddPaymnt5.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt5.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt5.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt5.Location = new System.Drawing.Point(236, 476);
            this.tNedit_AddPaymnt5.MaxLength = 10;
            this.tNedit_AddPaymnt5.Name = "tNedit_AddPaymnt5";
            this.tNedit_AddPaymnt5.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt5.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt5.TabIndex = 22;
            // 
            // tNedit_AddPaymnt6
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt6.ActiveAppearance = appearance29;
            appearance35.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance35.ForeColor = System.Drawing.Color.Black;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            appearance35.TextHAlignAsString = "Right";
            appearance35.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt6.Appearance = appearance35;
            this.tNedit_AddPaymnt6.AutoSelect = true;
            this.tNedit_AddPaymnt6.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt6.DataText = "";
            this.tNedit_AddPaymnt6.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt6.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt6.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt6.Location = new System.Drawing.Point(236, 503);
            this.tNedit_AddPaymnt6.MaxLength = 10;
            this.tNedit_AddPaymnt6.Name = "tNedit_AddPaymnt6";
            this.tNedit_AddPaymnt6.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt6.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt6.TabIndex = 24;
            // 
            // tNedit_AddPaymnt7
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt7.ActiveAppearance = appearance47;
            appearance48.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance48.ForeColor = System.Drawing.Color.Black;
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            appearance48.TextHAlignAsString = "Right";
            appearance48.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt7.Appearance = appearance48;
            this.tNedit_AddPaymnt7.AutoSelect = true;
            this.tNedit_AddPaymnt7.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt7.DataText = "";
            this.tNedit_AddPaymnt7.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt7.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt7.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt7.Location = new System.Drawing.Point(236, 530);
            this.tNedit_AddPaymnt7.MaxLength = 10;
            this.tNedit_AddPaymnt7.Name = "tNedit_AddPaymnt7";
            this.tNedit_AddPaymnt7.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt7.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt7.TabIndex = 26;
            // 
            // tNedit_AddPaymnt8
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt8.ActiveAppearance = appearance38;
            appearance39.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance39.ForeColor = System.Drawing.Color.Black;
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            appearance39.TextHAlignAsString = "Right";
            appearance39.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt8.Appearance = appearance39;
            this.tNedit_AddPaymnt8.AutoSelect = true;
            this.tNedit_AddPaymnt8.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt8.DataText = "";
            this.tNedit_AddPaymnt8.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt8.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt8.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt8.Location = new System.Drawing.Point(236, 557);
            this.tNedit_AddPaymnt8.MaxLength = 10;
            this.tNedit_AddPaymnt8.Name = "tNedit_AddPaymnt8";
            this.tNedit_AddPaymnt8.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt8.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt8.TabIndex = 28;
            // 
            // tNedit_AddPaymnt9
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance36.ForeColor = System.Drawing.Color.Black;
            appearance36.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt9.ActiveAppearance = appearance36;
            appearance37.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.ForeColorDisabled = System.Drawing.Color.Black;
            appearance37.TextHAlignAsString = "Right";
            appearance37.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt9.Appearance = appearance37;
            this.tNedit_AddPaymnt9.AutoSelect = true;
            this.tNedit_AddPaymnt9.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt9.DataText = "";
            this.tNedit_AddPaymnt9.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt9.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt9.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt9.Location = new System.Drawing.Point(236, 584);
            this.tNedit_AddPaymnt9.MaxLength = 10;
            this.tNedit_AddPaymnt9.Name = "tNedit_AddPaymnt9";
            this.tNedit_AddPaymnt9.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt9.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt9.TabIndex = 30;
            // 
            // tNedit_AddPaymnt10
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt10.ActiveAppearance = appearance8;
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt10.Appearance = appearance9;
            this.tNedit_AddPaymnt10.AutoSelect = true;
            this.tNedit_AddPaymnt10.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt10.DataText = "";
            this.tNedit_AddPaymnt10.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt10.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt10.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt10.Location = new System.Drawing.Point(236, 611);
            this.tNedit_AddPaymnt10.MaxLength = 10;
            this.tNedit_AddPaymnt10.Name = "tNedit_AddPaymnt10";
            this.tNedit_AddPaymnt10.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt10.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt10.TabIndex = 32;
            // 
            // ultraLabel3
            // 
            appearance101.TextHAlignAsString = "Right";
            appearance101.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance101;
            this.ultraLabel3.Location = new System.Drawing.Point(16, 369);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel3.TabIndex = 263;
            this.ultraLabel3.Text = "1";
            // 
            // ultraLabel4
            // 
            appearance105.TextHAlignAsString = "Right";
            appearance105.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance105;
            this.ultraLabel4.Location = new System.Drawing.Point(16, 396);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel4.TabIndex = 263;
            this.ultraLabel4.Text = "2";
            // 
            // ultraLabel7
            // 
            appearance104.TextHAlignAsString = "Right";
            appearance104.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance104;
            this.ultraLabel7.Location = new System.Drawing.Point(16, 423);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel7.TabIndex = 263;
            this.ultraLabel7.Text = "3";
            // 
            // ultraLabel8
            // 
            appearance103.TextHAlignAsString = "Right";
            appearance103.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance103;
            this.ultraLabel8.Location = new System.Drawing.Point(16, 450);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel8.TabIndex = 263;
            this.ultraLabel8.Text = "4";
            // 
            // ultraLabel9
            // 
            appearance102.TextHAlignAsString = "Right";
            appearance102.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance102;
            this.ultraLabel9.Location = new System.Drawing.Point(16, 477);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel9.TabIndex = 263;
            this.ultraLabel9.Text = "5";
            // 
            // ultraLabel10
            // 
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance5;
            this.ultraLabel10.Location = new System.Drawing.Point(16, 504);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel10.TabIndex = 263;
            this.ultraLabel10.Text = "6";
            // 
            // ultraLabel11
            // 
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance6;
            this.ultraLabel11.Location = new System.Drawing.Point(16, 531);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel11.TabIndex = 263;
            this.ultraLabel11.Text = "7";
            // 
            // ultraLabel12
            // 
            appearance99.TextHAlignAsString = "Right";
            appearance99.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance99;
            this.ultraLabel12.Location = new System.Drawing.Point(16, 558);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel12.TabIndex = 263;
            this.ultraLabel12.Text = "8";
            // 
            // ultraLabel13
            // 
            appearance100.TextHAlignAsString = "Right";
            appearance100.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance100;
            this.ultraLabel13.Location = new System.Drawing.Point(16, 585);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel13.TabIndex = 263;
            this.ultraLabel13.Text = "9";
            // 
            // ultraLabel14
            // 
            appearance90.TextHAlignAsString = "Right";
            appearance90.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance90;
            this.ultraLabel14.Location = new System.Drawing.Point(16, 612);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel14.TabIndex = 263;
            this.ultraLabel14.Text = "10";
            // 
            // ultraLabel25
            // 
            appearance125.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance125;
            this.ultraLabel25.Location = new System.Drawing.Point(168, 368);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel25.TabIndex = 259;
            this.ultraLabel25.Text = "円まで";
            // 
            // ultraLabel26
            // 
            appearance123.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance123;
            this.ultraLabel26.Location = new System.Drawing.Point(168, 395);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel26.TabIndex = 259;
            this.ultraLabel26.Text = "円まで";
            // 
            // ultraLabel27
            // 
            appearance121.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance121;
            this.ultraLabel27.Location = new System.Drawing.Point(168, 422);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel27.TabIndex = 259;
            this.ultraLabel27.Text = "円まで";
            // 
            // ultraLabel28
            // 
            appearance124.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance124;
            this.ultraLabel28.Location = new System.Drawing.Point(168, 449);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel28.TabIndex = 259;
            this.ultraLabel28.Text = "円まで";
            // 
            // ultraLabel29
            // 
            appearance122.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance122;
            this.ultraLabel29.Location = new System.Drawing.Point(168, 476);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel29.TabIndex = 259;
            this.ultraLabel29.Text = "円まで";
            // 
            // ultraLabel30
            // 
            appearance120.TextVAlignAsString = "Middle";
            this.ultraLabel30.Appearance = appearance120;
            this.ultraLabel30.Location = new System.Drawing.Point(168, 503);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel30.TabIndex = 259;
            this.ultraLabel30.Text = "円まで";
            // 
            // ultraLabel31
            // 
            appearance111.TextVAlignAsString = "Middle";
            this.ultraLabel31.Appearance = appearance111;
            this.ultraLabel31.Location = new System.Drawing.Point(168, 557);
            this.ultraLabel31.Name = "ultraLabel31";
            this.ultraLabel31.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel31.TabIndex = 259;
            this.ultraLabel31.Text = "円まで";
            // 
            // ultraLabel32
            // 
            appearance112.TextVAlignAsString = "Middle";
            this.ultraLabel32.Appearance = appearance112;
            this.ultraLabel32.Location = new System.Drawing.Point(168, 584);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel32.TabIndex = 259;
            this.ultraLabel32.Text = "円まで";
            // 
            // ultraLabel33
            // 
            appearance113.TextVAlignAsString = "Middle";
            this.ultraLabel33.Appearance = appearance113;
            this.ultraLabel33.Location = new System.Drawing.Point(168, 530);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel33.TabIndex = 259;
            this.ultraLabel33.Text = "円まで";
            // 
            // ultraLabel34
            // 
            appearance110.TextVAlignAsString = "Middle";
            this.ultraLabel34.Appearance = appearance110;
            this.ultraLabel34.Location = new System.Drawing.Point(168, 611);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel34.TabIndex = 259;
            this.ultraLabel34.Text = "円まで";
            // 
            // ultraLabel35
            // 
            appearance136.TextVAlignAsString = "Middle";
            this.ultraLabel35.Appearance = appearance136;
            this.ultraLabel35.Location = new System.Drawing.Point(357, 368);
            this.ultraLabel35.Name = "ultraLabel35";
            this.ultraLabel35.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel35.TabIndex = 259;
            this.ultraLabel35.Text = "円";
            // 
            // ultraLabel36
            // 
            appearance133.TextVAlignAsString = "Middle";
            this.ultraLabel36.Appearance = appearance133;
            this.ultraLabel36.Location = new System.Drawing.Point(357, 395);
            this.ultraLabel36.Name = "ultraLabel36";
            this.ultraLabel36.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel36.TabIndex = 259;
            this.ultraLabel36.Text = "円";
            // 
            // ultraLabel37
            // 
            appearance135.TextVAlignAsString = "Middle";
            this.ultraLabel37.Appearance = appearance135;
            this.ultraLabel37.Location = new System.Drawing.Point(357, 422);
            this.ultraLabel37.Name = "ultraLabel37";
            this.ultraLabel37.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel37.TabIndex = 259;
            this.ultraLabel37.Text = "円";
            // 
            // ultraLabel38
            // 
            appearance132.TextVAlignAsString = "Middle";
            this.ultraLabel38.Appearance = appearance132;
            this.ultraLabel38.Location = new System.Drawing.Point(357, 449);
            this.ultraLabel38.Name = "ultraLabel38";
            this.ultraLabel38.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel38.TabIndex = 259;
            this.ultraLabel38.Text = "円";
            // 
            // ultraLabel39
            // 
            appearance129.TextVAlignAsString = "Middle";
            this.ultraLabel39.Appearance = appearance129;
            this.ultraLabel39.Location = new System.Drawing.Point(357, 476);
            this.ultraLabel39.Name = "ultraLabel39";
            this.ultraLabel39.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel39.TabIndex = 259;
            this.ultraLabel39.Text = "円";
            // 
            // ultraLabel40
            // 
            appearance134.TextVAlignAsString = "Middle";
            this.ultraLabel40.Appearance = appearance134;
            this.ultraLabel40.Location = new System.Drawing.Point(357, 530);
            this.ultraLabel40.Name = "ultraLabel40";
            this.ultraLabel40.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel40.TabIndex = 259;
            this.ultraLabel40.Text = "円";
            // 
            // ultraLabel41
            // 
            appearance130.TextVAlignAsString = "Middle";
            this.ultraLabel41.Appearance = appearance130;
            this.ultraLabel41.Location = new System.Drawing.Point(357, 503);
            this.ultraLabel41.Name = "ultraLabel41";
            this.ultraLabel41.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel41.TabIndex = 259;
            this.ultraLabel41.Text = "円";
            // 
            // ultraLabel42
            // 
            appearance131.TextVAlignAsString = "Middle";
            this.ultraLabel42.Appearance = appearance131;
            this.ultraLabel42.Location = new System.Drawing.Point(357, 557);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel42.TabIndex = 259;
            this.ultraLabel42.Text = "円";
            // 
            // ultraLabel43
            // 
            appearance128.TextVAlignAsString = "Middle";
            this.ultraLabel43.Appearance = appearance128;
            this.ultraLabel43.Location = new System.Drawing.Point(357, 584);
            this.ultraLabel43.Name = "ultraLabel43";
            this.ultraLabel43.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel43.TabIndex = 259;
            this.ultraLabel43.Text = "円";
            // 
            // ultraLabel44
            // 
            appearance114.TextVAlignAsString = "Middle";
            this.ultraLabel44.Appearance = appearance114;
            this.ultraLabel44.Location = new System.Drawing.Point(357, 611);
            this.ultraLabel44.Name = "ultraLabel44";
            this.ultraLabel44.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel44.TabIndex = 259;
            this.ultraLabel44.Text = "円";
            // 
            // FractionProcCd_uLabel
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.FractionProcCd_uLabel.Appearance = appearance52;
            this.FractionProcCd_uLabel.Location = new System.Drawing.Point(16, 309);
            this.FractionProcCd_uLabel.Name = "FractionProcCd_uLabel";
            this.FractionProcCd_uLabel.Size = new System.Drawing.Size(165, 24);
            this.FractionProcCd_uLabel.TabIndex = 171;
            this.FractionProcCd_uLabel.Text = "端数処理単位";
            // 
            // FractionProcCd_tComboEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.FractionProcCd_tComboEditor.ActiveAppearance = appearance19;
            appearance20.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            this.FractionProcCd_tComboEditor.Appearance = appearance20;
            this.FractionProcCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.FractionProcCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FractionProcCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance21.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.FractionProcCd_tComboEditor.ItemAppearance = appearance21;
            this.FractionProcCd_tComboEditor.Location = new System.Drawing.Point(221, 309);
            this.FractionProcCd_tComboEditor.Name = "FractionProcCd_tComboEditor";
            this.FractionProcCd_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.FractionProcCd_tComboEditor.TabIndex = 12;
            // 
            // AddPaymnt_uLabel
            // 
            appearance127.TextVAlignAsString = "Middle";
            this.AddPaymnt_uLabel.Appearance = appearance127;
            this.AddPaymnt_uLabel.Location = new System.Drawing.Point(236, 339);
            this.AddPaymnt_uLabel.Name = "AddPaymnt_uLabel";
            this.AddPaymnt_uLabel.Size = new System.Drawing.Size(199, 24);
            this.AddPaymnt_uLabel.TabIndex = 259;
            this.AddPaymnt_uLabel.Text = "加算額";
            // 
            // ultraLabel15
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance10;
            this.ultraLabel15.Location = new System.Drawing.Point(16, 641);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(403, 24);
            this.ultraLabel15.TabIndex = 171;
            this.ultraLabel15.Text = "※ 設定値を超えた場合、加算額は0円になります";
            // 
            // MarketPriceQualityCd2_tComEditor
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance64.ForeColor = System.Drawing.Color.Black;
            appearance64.TextVAlignAsString = "Middle";
            this.MarketPriceQualityCd2_tComEditor.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance65.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceQualityCd2_tComEditor.Appearance = appearance65;
            this.MarketPriceQualityCd2_tComEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceQualityCd2_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceQualityCd2_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance69.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceQualityCd2_tComEditor.ItemAppearance = appearance69;
            this.MarketPriceQualityCd2_tComEditor.Location = new System.Drawing.Point(451, 201);
            this.MarketPriceQualityCd2_tComEditor.Name = "MarketPriceQualityCd2_tComEditor";
            this.MarketPriceQualityCd2_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceQualityCd2_tComEditor.TabIndex = 8;
            // 
            // MarketPriceQualityCd3_tComEditor
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.TextVAlignAsString = "Middle";
            this.MarketPriceQualityCd3_tComEditor.ActiveAppearance = appearance31;
            appearance32.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceQualityCd3_tComEditor.Appearance = appearance32;
            this.MarketPriceQualityCd3_tComEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceQualityCd3_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceQualityCd3_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance33.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceQualityCd3_tComEditor.ItemAppearance = appearance33;
            this.MarketPriceQualityCd3_tComEditor.Location = new System.Drawing.Point(451, 228);
            this.MarketPriceQualityCd3_tComEditor.Name = "MarketPriceQualityCd3_tComEditor";
            this.MarketPriceQualityCd3_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceQualityCd3_tComEditor.TabIndex = 10;
            // 
            // ultraLabel16
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance63;
            this.ultraLabel16.Location = new System.Drawing.Point(221, 150);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel16.TabIndex = 266;
            this.ultraLabel16.Text = "種別";
            // 
            // ultraLabel17
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance70;
            this.ultraLabel17.Location = new System.Drawing.Point(187, 174);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(28, 24);
            this.ultraLabel17.TabIndex = 267;
            this.ultraLabel17.Text = "1";
            // 
            // PMSCM09050UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(713, 734);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.ultraLabel16);
            this.Controls.Add(this.MarketPriceQualityCd3_tComEditor);
            this.Controls.Add(this.MarketPriceQualityCd2_tComEditor);
            this.Controls.Add(this.ultraLabel14);
            this.Controls.Add(this.ultraLabel9);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.ultraLabel11);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel10);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.MarketPriceKindCd1_tComboEditor);
            this.Controls.Add(this.MarketPriceAnswerDiv_tComboEditor);
            this.Controls.Add(this.ultraLabel34);
            this.Controls.Add(this.ultraLabel30);
            this.Controls.Add(this.ultraLabel33);
            this.Controls.Add(this.ultraLabel32);
            this.Controls.Add(this.ultraLabel27);
            this.Controls.Add(this.ultraLabel29);
            this.Controls.Add(this.ultraLabel31);
            this.Controls.Add(this.ultraLabel26);
            this.Controls.Add(this.ultraLabel28);
            this.Controls.Add(this.ultraLabel44);
            this.Controls.Add(this.ultraLabel42);
            this.Controls.Add(this.ultraLabel38);
            this.Controls.Add(this.ultraLabel41);
            this.Controls.Add(this.ultraLabel36);
            this.Controls.Add(this.ultraLabel43);
            this.Controls.Add(this.ultraLabel40);
            this.Controls.Add(this.ultraLabel37);
            this.Controls.Add(this.ultraLabel39);
            this.Controls.Add(this.ultraLabel35);
            this.Controls.Add(this.ultraLabel25);
            this.Controls.Add(this.AddPaymnt_uLabel);
            this.Controls.Add(this.AddPaymntAmbit_uLabel);
            this.Controls.Add(this.MarketPriceKindCd1_uLabel);
            this.Controls.Add(this.MarketPriceAnswerDiv_uLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.Section_uLabel);
            this.Controls.Add(this.MarketPriceQualityCd_tComEditor);
            this.Controls.Add(this.MarketPriceQualityCd_uLabel);
            this.Controls.Add(this.MarketPriceAreaCd_tComEditor);
            this.Controls.Add(this.MarketPriceAreaCd_uLabel);
            this.Controls.Add(this.FractionProcCd_tComboEditor);
            this.Controls.Add(this.MarketPriceKindCd3_tComboEditor);
            this.Controls.Add(this.MarketPriceKindCd2_tComboEditor);
            this.Controls.Add(this.MarketPriceKindCd3_uLabel);
            this.Controls.Add(this.MarketPriceKindCd2_uLabel);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.tNedit_AddPaymnt10);
            this.Controls.Add(this.tNedit_AddPaymntAmbit10);
            this.Controls.Add(this.tNedit_AddPaymnt9);
            this.Controls.Add(this.tNedit_AddPaymntAmbit9);
            this.Controls.Add(this.tNedit_AddPaymnt8);
            this.Controls.Add(this.tNedit_AddPaymntAmbit8);
            this.Controls.Add(this.tNedit_AddPaymnt7);
            this.Controls.Add(this.tNedit_AddPaymntAmbit7);
            this.Controls.Add(this.tNedit_AddPaymnt6);
            this.Controls.Add(this.tNedit_AddPaymntAmbit6);
            this.Controls.Add(this.tNedit_AddPaymnt5);
            this.Controls.Add(this.tNedit_AddPaymntAmbit5);
            this.Controls.Add(this.tNedit_AddPaymnt4);
            this.Controls.Add(this.tNedit_AddPaymntAmbit4);
            this.Controls.Add(this.tNedit_AddPaymnt3);
            this.Controls.Add(this.tNedit_AddPaymntAmbit3);
            this.Controls.Add(this.tNedit_AddPaymnt2);
            this.Controls.Add(this.tNedit_AddPaymntAmbit2);
            this.Controls.Add(this.tNedit_AddPaymnt1);
            this.Controls.Add(this.tNedit_AddPaymntAmbit1);
            this.Controls.Add(this.tNedit_MarketPriceSalesRate);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.FractionProcCd_uLabel);
            this.Controls.Add(this.MarketPriceSalesRate_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
            this.Name = "PMSCM09050UA";
            this.Text = "SCM相場価格設定";
            this.Load += new System.EventHandler(this.PMSCM09050UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMSCM09050UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMSCM09050UA_Closing);
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_MarketPriceSalesRate ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd2_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceAreaCd_tComEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd_tComEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.SectionName_tEdit ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.Bind_DataSet ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceAnswerDiv_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd1_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_SectionCodeAllowZero ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd3_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit2 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit3 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit4 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit5 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit6 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit7 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit8 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit9 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit10 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt2 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt3 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt4 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt5 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt6 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt7 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt8 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt9 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt10 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.FractionProcCd_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd2_tComEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd3_tComEditor ) ).EndInit();
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
		private SCMMrktPriStAcs _scmMrktPriStAcs;
        private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _scmMrktPriStTable;

        private SecInfoAcs _secInfoAcs;

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        
		// 保存比較用Clone
		private SCMMrktPriSt _scmMrktPriStClone;

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

        // 相場情報
        GetAreaListResType _getAreaListResType;         // 相場価格地域
        GetQualityListResType _getQualityListResType;   // 相場価格品質
        GetKindListResType _getKindListResType;         // 相場価格種別

        private const string PROGRAM_ID = "PMSCM09050U";    // プログラムID

        // View用Gridに表示させるテーブル名
        private const string VIEW_TABLE = "VIEW_TABLE";
        
		// FrameのView用Grid列のKEY情報 (HeaderのTitle部となります)
        private const string DELETE_DATE = "削除日";

        private const string VIEW_SECTION_CODE_TITLE = "拠点コード";
        private const string VIEW_SECTION_NAME_TITLE = "拠点名称";

        private const string VIEW_MARKET_PRICE_AREA_CD = "相場価格地域";
        // 2010/04/12 >>>
        //private const string VIEW_MARKET_PRICE_QUALITY_CD = "相場価格品質";
        private const string VIEW_MARKET_PRICE_QUALITY_CD = "相場価格品質１";
        private const string VIEW_MARKET_PRICE_QUALITY_CD2 = "相場価格品質２";
        private const string VIEW_MARKET_PRICE_QUALITY_CD3 = "相場価格品質３";
        // 2010/04/12 <<<
        private const string VIEW_MARKET_PRICE_KIND_CD1 = "相場価格種別１";
        private const string VIEW_MARKET_PRICE_KIND_CD2 = "相場価格種別２";
        private const string VIEW_MARKET_PRICE_KIND_CD3 = "相場価格種別３";
        private const string VIEW_MARKET_PRICE_ANSWER_DIV = "相場価格回答区分";
        private const string VIEW_MARKET_PRICE_SALES_RATE = "相場価格売価率";
        private const string VIEW_FRACTION_PROC_CD = "端数処理単位";
        
        private const string VIEW_ADD_PAYMNT_AMBIT1 = "料金テーブル１";
        private const string VIEW_ADD_PAYMNT_AMBIT2 = "料金テーブル２";
        private const string VIEW_ADD_PAYMNT_AMBIT3 = "料金テーブル３";
        private const string VIEW_ADD_PAYMNT_AMBIT4 = "料金テーブル４";
        private const string VIEW_ADD_PAYMNT_AMBIT5 = "料金テーブル５";
        private const string VIEW_ADD_PAYMNT_AMBIT6 = "料金テーブル６";
        private const string VIEW_ADD_PAYMNT_AMBIT7 = "料金テーブル７";
        private const string VIEW_ADD_PAYMNT_AMBIT8 = "料金テーブル８";
        private const string VIEW_ADD_PAYMNT_AMBIT9 = "料金テーブル９";
        private const string VIEW_ADD_PAYMNT_AMBIT10 = "料金テーブル１０";

        private const string VIEW_ADD_PAYMNT_1 = "加算額１";
        private const string VIEW_ADD_PAYMNT_2 = "加算額２";
        private const string VIEW_ADD_PAYMNT_3 = "加算額３";
        private const string VIEW_ADD_PAYMNT_4 = "加算額４";
        private const string VIEW_ADD_PAYMNT_5 = "加算額５";
        private const string VIEW_ADD_PAYMNT_6 = "加算額６";
        private const string VIEW_ADD_PAYMNT_7 = "加算額７";
        private const string VIEW_ADD_PAYMNT_8 = "加算額８";
        private const string VIEW_ADD_PAYMNT_9 = "加算額９";
        private const string VIEW_ADD_PAYMNT_10 = "加算額１０";

        private const string VIEW_GUID_KEY_TITLE = "Guid";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";	   
		private const string DELETE_MODE = "削除モード";

        // 全社共通
        private const string ALL_SECTIONCODE = "00";
        
        // 最大金額
        private const int MAX_PAYMNT = 99999999;

		#endregion

		#region -- Main --
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMSCM09050UA());
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

        /// <summary>
        /// 企業コードを取得します。
        /// </summary>
        private static string EnterpriseCode
        {
            get { return LoginInfoAcquisition.EnterpriseCode; }
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
            this._scmMrktPriStTable.Clear();

            // 全検索
            status = this._scmMrktPriStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

			switch(status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    int index = 0;

                    foreach (SCMMrktPriSt scmMrktPriSt in retList)
					{
                        // SCM相場価格設定情報クラスのデータセット展開処理
                        SCMMrktPriStToDataSet(scmMrktPriSt.Clone(), index);
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
						this._scmMrktPriStAcs,					    // エラーが発生したオブジェクト
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
            SCMMrktPriSt scmMrktPriSt = (SCMMrktPriSt)this._scmMrktPriStTable[guid];

            // 全社共通データは削除不可
            if (scmMrktPriSt.SectionCode.Trim() == ALL_SECTIONCODE)
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

            // SCM相場価格設定情報の論理削除処理
            status = this._scmMrktPriStAcs.LogicalDelete(ref scmMrktPriSt);
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
                            this._scmMrktPriStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        return status;
                    }
            }

            // SCM相場価格設定情報クラスのデータセット展開処理
            SCMMrktPriStToDataSet(scmMrktPriSt.Clone(), this.DataIndex);

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
		/// <br></br>
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

            // 相場価格回答区分
            appearanceTable.Add(VIEW_MARKET_PRICE_ANSWER_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 相場価格地域
            appearanceTable.Add(VIEW_MARKET_PRICE_AREA_CD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Del >>>
            //// 相場価格品質
            //appearanceTable.Add(VIEW_MARKET_PRICE_QUALITY_CD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Del <<<
            // 相場価格種別１
            appearanceTable.Add(VIEW_MARKET_PRICE_KIND_CD1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add >>>
            // 相場価格品質１
            appearanceTable.Add(VIEW_MARKET_PRICE_QUALITY_CD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add <<<
            // 相場価格種別２
            appearanceTable.Add(VIEW_MARKET_PRICE_KIND_CD2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add >>>
            // 相場価格品質２
            appearanceTable.Add(VIEW_MARKET_PRICE_QUALITY_CD2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add <<<
            // 相場価格種別３
            appearanceTable.Add(VIEW_MARKET_PRICE_KIND_CD3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add >>>
            // 相場価格品質３
            appearanceTable.Add(VIEW_MARKET_PRICE_QUALITY_CD3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add <<<
            // 相場価格売価率
            appearanceTable.Add(VIEW_MARKET_PRICE_SALES_RATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 端数処理単位
            appearanceTable.Add(VIEW_FRACTION_PROC_CD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            
            // 料金テーブル１
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 料金テーブル２
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 料金テーブル３
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 料金テーブル４
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 料金テーブル５
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 料金テーブル６
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 料金テーブル７
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT7, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 料金テーブル８
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT8, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 料金テーブル９
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT9, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 料金テーブル１０
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT10, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // 加算額１
            appearanceTable.Add(VIEW_ADD_PAYMNT_1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 加算額２
            appearanceTable.Add(VIEW_ADD_PAYMNT_2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 加算額３
            appearanceTable.Add(VIEW_ADD_PAYMNT_3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 加算額４
            appearanceTable.Add(VIEW_ADD_PAYMNT_4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 加算額５
            appearanceTable.Add(VIEW_ADD_PAYMNT_5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 加算額６
            appearanceTable.Add(VIEW_ADD_PAYMNT_6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 加算額７
            appearanceTable.Add(VIEW_ADD_PAYMNT_7, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 加算額８
            appearanceTable.Add(VIEW_ADD_PAYMNT_8, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 加算額９
            appearanceTable.Add(VIEW_ADD_PAYMNT_9, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // 加算額１０
            appearanceTable.Add(VIEW_ADD_PAYMNT_10, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            
            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			
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
            if (this.DataIndex < 0)
            {
                SCMMrktPriSt scmMrktPriSt = new SCMMrktPriSt();
                //クローン作成
                this._scmMrktPriStClone = scmMrktPriSt.Clone();
                this._indexBuf = this._dataIndex;

                // 画面情報を比較用クローンにコピーします
                ScreenToSCMMrktPriSt(ref this._scmMrktPriStClone);

                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // 画面入力許可制御処理
                ScreenInputPermissionControl(INSERT_MODE);

                // フォーカス設定
                this.tEdit_SectionCodeAllowZero.Focus();
            }
            else
            {
                // 保持しているデータセットより修正前情報取得
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SCMMrktPriSt scmMrktPriSt = (SCMMrktPriSt)this._scmMrktPriStTable[guid];

                // SCM相場価格設定クラス画面展開処理
                SCMMrktPriStToScreen(scmMrktPriSt);

                if (scmMrktPriSt.LogicalDeleteCode == 0)
                {
                    // 更新可能状態の時
                    this.Mode_Label.Text = UPDATE_MODE;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // フォーカス設定
                    this.MarketPriceAnswerDiv_tComboEditor.Focus();

                    // クローン作成
                    this._scmMrktPriStClone = scmMrktPriSt.Clone();

                    // 画面情報を比較用クローンにコピーします　   
                    ScreenToSCMMrktPriSt(ref this._scmMrktPriStClone);
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
                        this.MarketPriceAnswerDiv_tComboEditor.Enabled = true;

                        // 相場価格回答区分による入力許可制御
                        MarketPriceAnswerDivPermissionControl();
                        
                        if (mode == INSERT_MODE)
                        {
                            // 新規モード
                            this.tEdit_SectionCodeAllowZero.Enabled = true;
                            this.SectionGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // 更新モード
                            this.tEdit_SectionCodeAllowZero.Enabled = false;
                            this.SectionGuide_Button.Enabled = false;
                        }

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;
                        this.tEdit_SectionCodeAllowZero.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.SectionName_tEdit.Enabled = false;
                        this.MarketPriceAnswerDiv_tComboEditor.Enabled = false;
                        this.MarketPriceAreaCd_tComEditor.Enabled = false;
                        this.MarketPriceQualityCd_tComEditor.Enabled = false;
                        this.MarketPriceKindCd1_tComboEditor.Enabled = false;
                        this.MarketPriceKindCd2_tComboEditor.Enabled = false;
                        this.MarketPriceKindCd3_tComboEditor.Enabled = false;
                        // 2010/04/12 Add >>>
                        this.MarketPriceQualityCd2_tComEditor.Enabled = false;
                        this.MarketPriceQualityCd3_tComEditor.Enabled = false;
                        // 2010/04/12 Add <<<
                        this.tNedit_MarketPriceSalesRate.Enabled = false;
                        
                        break;
                    }
            }
        }

        /// <summary>
        /// 相場価格回答区分制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 相場価格回答区分による入力許可を制御します。</br>
        /// <br></br>
        /// </remarks>
        private void MarketPriceAnswerDivPermissionControl()
        {
            if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 0)
            {
                // しない
                MarketPriceAreaCd_tComEditor.Enabled = false;
                MarketPriceQualityCd_tComEditor.Enabled = false;
                MarketPriceKindCd1_tComboEditor.Enabled = false;
                MarketPriceKindCd2_tComboEditor.Enabled = false;
                MarketPriceKindCd3_tComboEditor.Enabled = false;
                // 2010/04/12 Add >>>
                MarketPriceQualityCd2_tComEditor.Enabled = false;
                MarketPriceQualityCd3_tComEditor.Enabled = false;
                // 2010/04/12 Add <<<
                tNedit_MarketPriceSalesRate.Enabled = false;
                FractionProcCd_tComboEditor.Enabled = false;

                tNedit_AddPaymntAmbit1.Enabled = false;
                tNedit_AddPaymntAmbit2.Enabled = false;
                tNedit_AddPaymntAmbit3.Enabled = false;
                tNedit_AddPaymntAmbit4.Enabled = false;
                tNedit_AddPaymntAmbit5.Enabled = false;
                tNedit_AddPaymntAmbit6.Enabled = false;
                tNedit_AddPaymntAmbit7.Enabled = false;
                tNedit_AddPaymntAmbit8.Enabled = false;
                tNedit_AddPaymntAmbit9.Enabled = false;
                tNedit_AddPaymntAmbit10.Enabled = false;

                tNedit_AddPaymnt1.Enabled = false;
                tNedit_AddPaymnt2.Enabled = false;
                tNedit_AddPaymnt3.Enabled = false;
                tNedit_AddPaymnt4.Enabled = false;
                tNedit_AddPaymnt5.Enabled = false;
                tNedit_AddPaymnt6.Enabled = false;
                tNedit_AddPaymnt7.Enabled = false;
                tNedit_AddPaymnt8.Enabled = false;
                tNedit_AddPaymnt9.Enabled = false;
                tNedit_AddPaymnt10.Enabled = false;
            }
            else if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 1)
            {
                // する（売価率）
                MarketPriceAreaCd_tComEditor.Enabled = true;
                MarketPriceQualityCd_tComEditor.Enabled = true;
                MarketPriceKindCd1_tComboEditor.Enabled = true;
                MarketPriceKindCd2_tComboEditor.Enabled = true;
                MarketPriceKindCd3_tComboEditor.Enabled = true;
                // 2010/04/12 Add >>>
                MarketPriceQualityCd2_tComEditor.Enabled = true;
                MarketPriceQualityCd3_tComEditor.Enabled = true;
                // 2010/04/12 Add <<<
                tNedit_MarketPriceSalesRate.Enabled = true;
                FractionProcCd_tComboEditor.Enabled = true;

                tNedit_AddPaymntAmbit1.Enabled = false;
                tNedit_AddPaymntAmbit2.Enabled = false;
                tNedit_AddPaymntAmbit3.Enabled = false;
                tNedit_AddPaymntAmbit4.Enabled = false;
                tNedit_AddPaymntAmbit5.Enabled = false;
                tNedit_AddPaymntAmbit6.Enabled = false;
                tNedit_AddPaymntAmbit7.Enabled = false;
                tNedit_AddPaymntAmbit8.Enabled = false;
                tNedit_AddPaymntAmbit9.Enabled = false;
                tNedit_AddPaymntAmbit10.Enabled = false;

                tNedit_AddPaymnt1.Enabled = false;
                tNedit_AddPaymnt2.Enabled = false;
                tNedit_AddPaymnt3.Enabled = false;
                tNedit_AddPaymnt4.Enabled = false;
                tNedit_AddPaymnt5.Enabled = false;
                tNedit_AddPaymnt6.Enabled = false;
                tNedit_AddPaymnt7.Enabled = false;
                tNedit_AddPaymnt8.Enabled = false;
                tNedit_AddPaymnt9.Enabled = false;
                tNedit_AddPaymnt10.Enabled = false;
            }
            else if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 2)
            {
                // する（加算テーブル）
                MarketPriceAreaCd_tComEditor.Enabled = true;
                MarketPriceQualityCd_tComEditor.Enabled = true;
                MarketPriceKindCd1_tComboEditor.Enabled = true;
                MarketPriceKindCd2_tComboEditor.Enabled = true;
                MarketPriceKindCd3_tComboEditor.Enabled = true;
                // 2010/04/12 Add >>>
                MarketPriceQualityCd2_tComEditor.Enabled = true;
                MarketPriceQualityCd3_tComEditor.Enabled = true;
                // 2010/04/12 Add <<<
                tNedit_MarketPriceSalesRate.Enabled = false;
                FractionProcCd_tComboEditor.Enabled = true;

                tNedit_AddPaymntAmbit1.Enabled = true;
                tNedit_AddPaymntAmbit2.Enabled = true;
                tNedit_AddPaymntAmbit3.Enabled = true;
                tNedit_AddPaymntAmbit4.Enabled = true;
                tNedit_AddPaymntAmbit5.Enabled = true;
                tNedit_AddPaymntAmbit6.Enabled = true;
                tNedit_AddPaymntAmbit7.Enabled = true;
                tNedit_AddPaymntAmbit8.Enabled = true;
                tNedit_AddPaymntAmbit9.Enabled = true;
                tNedit_AddPaymntAmbit10.Enabled = true;

                tNedit_AddPaymnt1.Enabled = true;
                tNedit_AddPaymnt2.Enabled = true;
                tNedit_AddPaymnt3.Enabled = true;
                tNedit_AddPaymnt4.Enabled = true;
                tNedit_AddPaymnt5.Enabled = true;
                tNedit_AddPaymnt6.Enabled = true;
                tNedit_AddPaymnt7.Enabled = true;
                tNedit_AddPaymnt8.Enabled = true;
                tNedit_AddPaymnt9.Enabled = true;
                tNedit_AddPaymnt10.Enabled = true;
            }

            // 2010/04/12 Add >>>
            if (MarketPriceKindCd2_tComboEditor.SelectedIndex == 0)
            {
                MarketPriceQualityCd2_tComEditor.Value = null;
                MarketPriceQualityCd2_tComEditor.Enabled = false;
            }

            if (MarketPriceKindCd3_tComboEditor.SelectedIndex == 0)
            {
                MarketPriceQualityCd3_tComEditor.Value = null;
                MarketPriceQualityCd3_tComEditor.Enabled = false;
            }
            // 2010/04/12 Add <<<
        }

		/// <summary>
		/// SCM相場価格設定オブジェクトデータセット展開処理
		/// </summary>
        /// <param name="scmMrktPriSt">SCM相場価格設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : SCM相場価格設定クラスをデータセットに格納します。</br>
		/// <br></br>
		/// </remarks>
		private void SCMMrktPriStToDataSet(SCMMrktPriSt scmMrktPriSt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

            if (scmMrktPriSt.LogicalDeleteCode == 0)
            {
                // 更新可能状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // 削除状態の時
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = scmMrktPriSt.UpdateDateTimeJpInFormal;
            }

			// 拠点コード
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = scmMrktPriSt.SectionCode;
            // 拠点名称
            string sectionName = GetSectionName(scmMrktPriSt.SectionCode);
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;

            // 相場価格回答区分
            switch (scmMrktPriSt.MarketPriceAnswerDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_ANSWER_DIV] = "しない";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_ANSWER_DIV] = "する(売価率)";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_ANSWER_DIV] = "する(加算テーブル)";
                    break;
            }

            // 相場価格地域
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_AREA_CD] = GetMarketPriceAreaName(scmMrktPriSt.MarketPriceAreaCd);

            // 2010/04/12 Del >>>
            //// 相場価格品質
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_QUALITY_CD] = GetMarketPriceQualityName(scmMrktPriSt.MarketPriceQualityCd);
            // 2010/04/12 Del <<<

            // 相場価格種別１
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_KIND_CD1] = GetMarketPriceKindName(scmMrktPriSt.MarketPriceKindCd1);

            // 2010/04/12 Add >>>
            // 相場価格品質１
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_QUALITY_CD] = GetMarketPriceQualityName(scmMrktPriSt.MarketPriceQualityCd);
            // 2010/04/12 Add <<<

            // 相場価格種別２
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_KIND_CD2] = GetMarketPriceKindName(scmMrktPriSt.MarketPriceKindCd2);

            // 2010/04/12 Add >>>
            // 相場価格品質２
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_QUALITY_CD2] = GetMarketPriceQualityName(scmMrktPriSt.MarketPriceQualityCd2);
            // 2010/04/12 Add <<<

            // 相場価格種別３
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_KIND_CD3] = GetMarketPriceKindName(scmMrktPriSt.MarketPriceKindCd3);

            // 2010/04/12 Add >>>
            // 相場価格品質３
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_QUALITY_CD3] = GetMarketPriceQualityName(scmMrktPriSt.MarketPriceQualityCd3);
            // 2010/04/12 Add <<<

            // 相場価格売価率
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_SALES_RATE] = scmMrktPriSt.MarketPriceSalesRate;

            // 端数処理単位
            switch (scmMrktPriSt.FractionProcCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FRACTION_PROC_CD] = "１０円単位(四捨五入)";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FRACTION_PROC_CD] = "１００円単位(四捨五入)";
                    break;
            }

            // 料金テーブル１
            if (scmMrktPriSt.AddPaymntAmbit1 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT1] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT1] = scmMrktPriSt.AddPaymntAmbit1.ToString("#,##0");
            }
            // 料金テーブル２
            if (scmMrktPriSt.AddPaymntAmbit2 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT2] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT2] = scmMrktPriSt.AddPaymntAmbit2.ToString("#,##0");
            }
            // 料金テーブル３
            if (scmMrktPriSt.AddPaymntAmbit3 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT3] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT3] = scmMrktPriSt.AddPaymntAmbit3.ToString("#,##0");
            }
            // 料金テーブル４
            if (scmMrktPriSt.AddPaymntAmbit4 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT4] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT4] = scmMrktPriSt.AddPaymntAmbit4.ToString("#,##0");
            }
            // 料金テーブル５
            if (scmMrktPriSt.AddPaymntAmbit5 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT5] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT5] = scmMrktPriSt.AddPaymntAmbit5.ToString("#,##0");
            }
            // 料金テーブル６
            if (scmMrktPriSt.AddPaymntAmbit6 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT6] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT6] = scmMrktPriSt.AddPaymntAmbit6.ToString("#,##0");
            }
            // 料金テーブル７
            if (scmMrktPriSt.AddPaymntAmbit7 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT7] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT7] = scmMrktPriSt.AddPaymntAmbit7.ToString("#,##0");
            }
            // 料金テーブル８
            if (scmMrktPriSt.AddPaymntAmbit8 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT8] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT8] = scmMrktPriSt.AddPaymntAmbit8.ToString("#,##0");
            }
            // 料金テーブル９
            if (scmMrktPriSt.AddPaymntAmbit9 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT9] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT9] = scmMrktPriSt.AddPaymntAmbit9.ToString("#,##0");
            }
            // 料金テーブル１０
            if (scmMrktPriSt.AddPaymntAmbit10 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT10] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT10] = scmMrktPriSt.AddPaymntAmbit10.ToString("#,##0");
            }

            // 加算額１
            if (scmMrktPriSt.AddPaymnt1 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_1] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_1] = scmMrktPriSt.AddPaymnt1.ToString("#,##0");
            }
            // 加算額２
            if (scmMrktPriSt.AddPaymnt2 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_2] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_2] = scmMrktPriSt.AddPaymnt2.ToString("#,##0");
            }
            // 加算額３
            if (scmMrktPriSt.AddPaymnt3 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_3] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_3] = scmMrktPriSt.AddPaymnt3.ToString("#,##0");
            }
            // 加算額４
            if (scmMrktPriSt.AddPaymnt4 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_4] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_4] = scmMrktPriSt.AddPaymnt4.ToString("#,##0");
            }
            // 加算額５
            if (scmMrktPriSt.AddPaymnt5 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_5] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_5] = scmMrktPriSt.AddPaymnt5.ToString("#,##0");
            }
            // 加算額６
            if (scmMrktPriSt.AddPaymnt6 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_6] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_6] = scmMrktPriSt.AddPaymnt6.ToString("#,##0");
            }
            // 加算額７
            if (scmMrktPriSt.AddPaymnt7 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_7] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_7] = scmMrktPriSt.AddPaymnt7.ToString("#,##0");
            }
            // 加算額８
            if (scmMrktPriSt.AddPaymnt8 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_8] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_8] = scmMrktPriSt.AddPaymnt8.ToString("#,##0");
            }
            // 加算額９
            if (scmMrktPriSt.AddPaymnt9 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_9] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_9] = scmMrktPriSt.AddPaymnt9.ToString("#,##0");
            }
            // 加算額１０
            if (scmMrktPriSt.AddPaymnt10 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_10] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_10] = scmMrktPriSt.AddPaymnt10.ToString("#,##0");
            }

            // Guid
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = scmMrktPriSt.FileHeaderGuid;
			
			if (this._scmMrktPriStTable.ContainsKey(scmMrktPriSt.FileHeaderGuid) == true)
			{
				this._scmMrktPriStTable.Remove(scmMrktPriSt.FileHeaderGuid);
			}
			this._scmMrktPriStTable.Add(scmMrktPriSt.FileHeaderGuid, scmMrktPriSt);
		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br></br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable scmMrktPriStTable = new DataTable(VIEW_TABLE);

			// Addを行う順番が、列の表示順位となります。

            scmMrktPriStTable.Columns.Add(DELETE_DATE, typeof(string));			                // 削除日
            
            scmMrktPriStTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));             // 拠点コード
			scmMrktPriStTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));             // 拠点名称

            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_ANSWER_DIV, typeof(string));        // 相場価格回答区分
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_AREA_CD, typeof(string));           // 相場価格地域
            // 2010/04/12 Del >>>
            //scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_QUALITY_CD, typeof(string));        // 相場価格品質
            // 2010/04/12 Del <<<
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_KIND_CD1, typeof(string));          // 相場価格種別１
            // 2010/04/12 Add >>>
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_QUALITY_CD, typeof(string));        // 相場価格品質１
            // 2010/04/12 Add <<<
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_KIND_CD2, typeof(string));          // 相場価格種別２
            // 2010/04/12 Add >>>
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_QUALITY_CD2, typeof(string));       // 相場価格品質２
            // 2010/04/12 Add <<<
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_KIND_CD3, typeof(string));          // 相場価格種別３
            // 2010/04/12 Add >>>
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_QUALITY_CD3, typeof(string));       // 相場価格品質３
            // 2010/04/12 Add <<<
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_SALES_RATE, typeof(string));        // 相場価格売価率
            scmMrktPriStTable.Columns.Add(VIEW_FRACTION_PROC_CD, typeof(string));               // 端数処理単位

            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT1, typeof(string));              // 料金テーブル１
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT2, typeof(string));              // 料金テーブル２
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT3, typeof(string));              // 料金テーブル３
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT4, typeof(string));              // 料金テーブル４
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT5, typeof(string));              // 料金テーブル５
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT6, typeof(string));              // 料金テーブル６
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT7, typeof(string));              // 料金テーブル７
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT8, typeof(string));              // 料金テーブル８
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT9, typeof(string));              // 料金テーブル９
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT10, typeof(string));             // 料金テーブル１０

            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_1, typeof(string));                   // 加算額１
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_2, typeof(string));                   // 加算額２
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_3, typeof(string));                   // 加算額３
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_4, typeof(string));                   // 加算額４
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_5, typeof(string));                   // 加算額５
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_6, typeof(string));                   // 加算額６
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_7, typeof(string));                   // 加算額７
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_8, typeof(string));                   // 加算額８
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_9, typeof(string));                   // 加算額９
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_10, typeof(string));                  // 加算額１０

            scmMrktPriStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));                   // Guid

			this.Bind_DataSet.Tables.Add(scmMrktPriStTable);
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
            // 相場価格回答区分
            MarketPriceAnswerDiv_tComboEditor.Items.Clear();
            MarketPriceAnswerDiv_tComboEditor.Items.Add(0, "しない");
            MarketPriceAnswerDiv_tComboEditor.Items.Add(1, "する(売価率)");
            MarketPriceAnswerDiv_tComboEditor.Items.Add(2, "する(加算テーブル)");
            MarketPriceAnswerDiv_tComboEditor.MaxDropDownItems = MarketPriceAnswerDiv_tComboEditor.Items.Count;

            // 相場価格地域
            SetMarketPriceAreaCd_tComEditor();
            
            // 相場価格品質
            SetMarketPriceQualityCd_tComEditor();
            
            // 相場価格種別１
            SetMarketPriceKindCd1_tComboEditor();
            
            // 相場価格種別２
            SetMarketPriceKindCd2_tComboEditor();
            
            // 相場価格種別３
            SetMarketPriceKindCd3_tComboEditor();
            
            // 端数処理単位
            FractionProcCd_tComboEditor.Items.Clear();
            FractionProcCd_tComboEditor.Items.Add(0, "１０円単位(四捨五入)");
            FractionProcCd_tComboEditor.Items.Add(1, "１００円単位(四捨五入)");
            FractionProcCd_tComboEditor.MaxDropDownItems = FractionProcCd_tComboEditor.Items.Count;
            
        }

        /// <summary>
        /// 相場情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 相場情報の取得を行います。</br>
        /// <br></br>
        /// </remarks>
        private void GetSobaInfo()
        {
            // 相場価格地域の情報取得
            AreaService areaService = new AreaService();
            GetAreaListReqType getAreaListReqType = new GetAreaListReqType();
            {
                getAreaListReqType.UC = EnterpriseCode;
            }
            this._getAreaListResType = areaService.GetAreaList(getAreaListReqType);
            if (this._getAreaListResType == null)
            {
                this._getAreaListResType = new GetAreaListResType();
            }

            // 相場価格品質の情報取得
            QualityService qualityService = new QualityService();
            GetQualityListReqType getQualityListReqType = new GetQualityListReqType();
            {
                getQualityListReqType.UC = EnterpriseCode;
            }
            this._getQualityListResType = qualityService.GetQualityList(getQualityListReqType);
            if (this._getQualityListResType == null)
            {
                this._getQualityListResType = new GetQualityListResType();
            }

            // 相場価格種別の情報取得
            KindService kindService = new KindService();
            GetKindListReqType getKindListReqType = new GetKindListReqType();
            {
                getKindListReqType.UC = EnterpriseCode;
            }
            this._getKindListResType = kindService.GetKindList(getKindListReqType);
            if (this._getKindListResType == null)
            {
                this._getKindListResType = new GetKindListResType();
            }
        }

        /// <summary>
        /// 相場価格地域名称取得処理
        /// </summary>
        /// <param name="marketPriceAreaCd">相場価格地域コード</param>
        /// <returns>相場価格地域名称</returns>
        /// <remarks>
        /// <br>Note       : 相場価格地域名称の取得を行います。</br>
        /// <br></br>
        /// </remarks>
        private string GetMarketPriceAreaName(int marketPriceAreaCd)
        {
            string name = string.Empty;

            foreach (AreaType areaListType in this._getAreaListResType.AreaList)
            {
                if (marketPriceAreaCd == areaListType.AreaCode)
                {
                    name = areaListType.AreaName;
                    break;
                }
            }

            return name;
        }

        /// <summary>
        /// 相場価格品質名称取得処理
        /// </summary>
        /// <param name="marketPriceQualityCd">相場価格品質コード</param>
        /// <returns>相場価格品質名称</returns>
        /// <remarks>
        /// <br>Note       : 相場価格品質名称の取得を行います。</br>
        /// <br></br>
        /// </remarks>
        private string GetMarketPriceQualityName(int marketPriceQualityCd)
        {
            string name = string.Empty;

            foreach (QualityType qualityListType in this._getQualityListResType.QualityList)
            {
                if (marketPriceQualityCd == qualityListType.QualityCode)
                {
                    name = qualityListType.QualityName;
                    break;
                }
            }

            return name;
        }

        /// <summary>
        /// 相場価格種別名称取得処理
        /// </summary>
        /// <param name="marketPriceQualityCd">相場価格種別コード</param>
        /// <returns>相場価格種別名称</returns>
        /// <remarks>
        /// <br>Note       : 相場価格種別名称の取得を行います。</br>
        /// <br></br>
        /// </remarks>
        private string GetMarketPriceKindName(int marketPriceKindCd)
        {
            string name = string.Empty;

            if (marketPriceKindCd == -1)
            {
                name = "なし";
            }
            else
            {
                foreach (KindType kindListType in this._getKindListResType.KindList)
                {
                    if (marketPriceKindCd == kindListType.KindCode)
                    {
                        name = kindListType.KindName;
                        break;
                    }
                }
            }

            return name;
        }

        /// <summary>
        /// 相場価格地域コンボエディタ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 相場価格地域コンボエディタの設定を行います。</br>
        /// <br></br>
        /// </remarks>
        private void SetMarketPriceAreaCd_tComEditor()
        {
            MarketPriceAreaCd_tComEditor.Items.Clear();

            foreach (AreaType areaListType in this._getAreaListResType.AreaList)
            {
                MarketPriceAreaCd_tComEditor.Items.Add(areaListType.AreaCode, areaListType.AreaName);
            }

            MarketPriceAreaCd_tComEditor.MaxDropDownItems = MarketPriceAreaCd_tComEditor.Items.Count;
        }

        /// <summary>
        /// 相場価格品質コンボエディタ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 相場価格品質コンボエディタの設定を行います。</br>
        /// <br></br>
        /// </remarks>
        private void SetMarketPriceQualityCd_tComEditor()
        {
            MarketPriceQualityCd_tComEditor.Items.Clear();
            // 2010/04/12 Add >>>
            MarketPriceQualityCd2_tComEditor.Items.Clear();
            MarketPriceQualityCd3_tComEditor.Items.Clear();
            // 2010/04/12 Add <<<

            foreach (QualityType qualityListType in this._getQualityListResType.QualityList)
            {
                MarketPriceQualityCd_tComEditor.Items.Add(qualityListType.QualityCode, qualityListType.QualityName);
                // 2010/04/12 >>>
                MarketPriceQualityCd2_tComEditor.Items.Add(qualityListType.QualityCode, qualityListType.QualityName);
                MarketPriceQualityCd3_tComEditor.Items.Add(qualityListType.QualityCode, qualityListType.QualityName);
                // 2010/04/12 <<<
            }


            MarketPriceQualityCd_tComEditor.MaxDropDownItems = MarketPriceQualityCd_tComEditor.Items.Count;
            // 2010/04/12 Add >>>
            MarketPriceQualityCd2_tComEditor.MaxDropDownItems = MarketPriceQualityCd2_tComEditor.Items.Count;
            MarketPriceQualityCd3_tComEditor.MaxDropDownItems = MarketPriceQualityCd3_tComEditor.Items.Count;
            // 2010/04/12 Add <<<
        }
       
        /// <summary>
        /// 相場価格種別１コンボエディタ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 相場価格種別１コンボエディタの設定を行います。</br>
        /// <br></br>
        /// </remarks>
        private void SetMarketPriceKindCd1_tComboEditor()
        {
            MarketPriceKindCd1_tComboEditor.Items.Clear();

            foreach (KindType kindListType in this._getKindListResType.KindList)
            {
                MarketPriceKindCd1_tComboEditor.Items.Add(kindListType.KindCode, kindListType.KindName);
            }
            
            MarketPriceKindCd1_tComboEditor.MaxDropDownItems = MarketPriceKindCd1_tComboEditor.Items.Count;
        }

        /// <summary>
        /// 相場価格種別コンボエディタ２設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 相場価格種別２コンボエディタの設定を行います。</br>
        /// <br></br>
        /// </remarks>
        private void SetMarketPriceKindCd2_tComboEditor()
        {
            MarketPriceKindCd2_tComboEditor.Items.Clear();
            MarketPriceKindCd2_tComboEditor.Items.Add(-1, "なし");

            foreach (KindType kindListType in this._getKindListResType.KindList)
            {
                MarketPriceKindCd2_tComboEditor.Items.Add(kindListType.KindCode, kindListType.KindName);
            }

            MarketPriceKindCd2_tComboEditor.MaxDropDownItems = MarketPriceKindCd2_tComboEditor.Items.Count;
        }

        /// <summary>
        /// 相場価格種別３コンボエディタ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 相場価格種別３コンボエディタの設定を行います。</br>
        /// <br></br>
        /// </remarks>
        private void SetMarketPriceKindCd3_tComboEditor()
        {
            MarketPriceKindCd3_tComboEditor.Items.Clear();
            MarketPriceKindCd3_tComboEditor.Items.Add(-1, "なし");

            foreach (KindType kindListType in this._getKindListResType.KindList)
            {
                MarketPriceKindCd3_tComboEditor.Items.Add(kindListType.KindCode, kindListType.KindName);
            }

            MarketPriceKindCd3_tComboEditor.MaxDropDownItems = MarketPriceKindCd3_tComboEditor.Items.Count;
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
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.SectionName_tEdit.DataText = "";

            this.MarketPriceAnswerDiv_tComboEditor.SelectedIndex = 0;   // 相場価格回答区分
            this.MarketPriceAreaCd_tComEditor.SelectedIndex = 0;        // 相場価格地域
            this.MarketPriceQualityCd_tComEditor.SelectedIndex = 0;     // 相場価格品質
            // 2010/04/12 Add >>>
            this.MarketPriceQualityCd2_tComEditor.SelectedIndex = -1;    // 相場価格品質２
            this.MarketPriceQualityCd3_tComEditor.SelectedIndex = -1;    // 相場価格品質３
            // 2010/04/12 Add <<<
            this.MarketPriceKindCd1_tComboEditor.SelectedIndex = 0;     // 相場価格種別１
            this.MarketPriceKindCd2_tComboEditor.SelectedIndex = 0;     // 相場価格種別２
            this.MarketPriceKindCd3_tComboEditor.SelectedIndex = 0;     // 相場価格種別３
            this.tNedit_MarketPriceSalesRate.DataText = "";             // 相場価格売価率
            this.FractionProcCd_tComboEditor.SelectedIndex = 0;         // 端数処理単位

            this.tNedit_AddPaymntAmbit1.Clear();                        // 料金テーブル１
            this.tNedit_AddPaymntAmbit2.Clear();                        // 料金テーブル２
            this.tNedit_AddPaymntAmbit3.Clear();                        // 料金テーブル３
            this.tNedit_AddPaymntAmbit4.Clear();                        // 料金テーブル４
            this.tNedit_AddPaymntAmbit5.Clear();                        // 料金テーブル５
            this.tNedit_AddPaymntAmbit6.Clear();                        // 料金テーブル６
            this.tNedit_AddPaymntAmbit7.Clear();                        // 料金テーブル７
            this.tNedit_AddPaymntAmbit8.Clear();                        // 料金テーブル８
            this.tNedit_AddPaymntAmbit9.Clear();                        // 料金テーブル９
            this.tNedit_AddPaymntAmbit10.Clear();                       // 料金テーブル１０

            this.tNedit_AddPaymnt1.Clear();                             // 加算額１
            this.tNedit_AddPaymnt2.Clear();                             // 加算額２
            this.tNedit_AddPaymnt3.Clear();                             // 加算額３
            this.tNedit_AddPaymnt4.Clear();                             // 加算額４
            this.tNedit_AddPaymnt5.Clear();                             // 加算額５
            this.tNedit_AddPaymnt6.Clear();                             // 加算額６
            this.tNedit_AddPaymnt7.Clear();                             // 加算額７
            this.tNedit_AddPaymnt8.Clear();                             // 加算額８
            this.tNedit_AddPaymnt9.Clear();                             // 加算額９
            this.tNedit_AddPaymnt10.Clear();                            // 加算額１０
        }

		/// <summary>
        /// SCM相場価格設定クラス画面展開処理
		/// </summary>
        /// <param name="scmMrktPriSt">SCM相場価格設定オブジェクト</param>
		/// <remarks>
        /// <br>Note       : SCM相場価格設定オブジェクトから画面にデータを展開します。</br>
		/// <br></br>
		/// </remarks>
		private void SCMMrktPriStToScreen(SCMMrktPriSt scmMrktPriSt)
		{
            // 拠点コード
            this.tEdit_SectionCodeAllowZero.DataText = scmMrktPriSt.SectionCode;
            // 拠点名称
            string sectionName = string.Empty;
            if (scmMrktPriSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            {
                sectionName = "全社共通";
            }
            else
            {
                sectionName = this.GetSectionName(scmMrktPriSt.SectionCode);
            }
            this.SectionName_tEdit.DataText = sectionName;

            // 相場価格回答区分
            this.MarketPriceAnswerDiv_tComboEditor.SelectedIndex = scmMrktPriSt.MarketPriceAnswerDiv;

            // 相場価格地域
            this.MarketPriceAreaCd_tComEditor.Value = scmMrktPriSt.MarketPriceAreaCd;

            // 相場価格品質
            this.MarketPriceQualityCd_tComEditor.Value = scmMrktPriSt.MarketPriceQualityCd;

            // 2010/04/12 Add >>>
            // 相場価格品質２
            this.MarketPriceQualityCd2_tComEditor.Value = scmMrktPriSt.MarketPriceQualityCd2;

            // 相場価格品質３
            this.MarketPriceQualityCd3_tComEditor.Value = scmMrktPriSt.MarketPriceQualityCd3;
            // 2010/04/12 Add <<<

            // 相場価格種別１
            this.MarketPriceKindCd1_tComboEditor.Value = scmMrktPriSt.MarketPriceKindCd1;

            // 相場価格種別２
            this.MarketPriceKindCd2_tComboEditor.Value = scmMrktPriSt.MarketPriceKindCd2;

            // 相場価格種別３
            this.MarketPriceKindCd3_tComboEditor.Value = scmMrktPriSt.MarketPriceKindCd3;

            // 相場価格売価率
			this.tNedit_MarketPriceSalesRate.DataText = scmMrktPriSt.MarketPriceSalesRate.ToString();

            // 端数処理単位
            this.FractionProcCd_tComboEditor.Value = scmMrktPriSt.FractionProcCd;

            // 

            // 料金テーブル１
            this.tNedit_AddPaymntAmbit1.SetInt(scmMrktPriSt.AddPaymntAmbit1);
            // 料金テーブル２
            this.tNedit_AddPaymntAmbit2.SetInt(scmMrktPriSt.AddPaymntAmbit2);
            // 料金テーブル３
            this.tNedit_AddPaymntAmbit3.SetInt(scmMrktPriSt.AddPaymntAmbit3);
            // 料金テーブル４
            this.tNedit_AddPaymntAmbit4.SetInt(scmMrktPriSt.AddPaymntAmbit4);
            // 料金テーブル５
            this.tNedit_AddPaymntAmbit5.SetInt(scmMrktPriSt.AddPaymntAmbit5);
            // 料金テーブル６
            this.tNedit_AddPaymntAmbit6.SetInt(scmMrktPriSt.AddPaymntAmbit6);
            // 料金テーブル７
            this.tNedit_AddPaymntAmbit7.SetInt(scmMrktPriSt.AddPaymntAmbit7);
            // 料金テーブル８
            this.tNedit_AddPaymntAmbit8.SetInt(scmMrktPriSt.AddPaymntAmbit8);
            // 料金テーブル９
            this.tNedit_AddPaymntAmbit9.SetInt(scmMrktPriSt.AddPaymntAmbit9);
            // 料金テーブル１０
            this.tNedit_AddPaymntAmbit10.SetInt(scmMrktPriSt.AddPaymntAmbit10);

            // 加算額１
            this.tNedit_AddPaymnt1.SetInt(scmMrktPriSt.AddPaymnt1);
            // 加算額２
            this.tNedit_AddPaymnt2.SetInt(scmMrktPriSt.AddPaymnt2);
            // 加算額３
            this.tNedit_AddPaymnt3.SetInt(scmMrktPriSt.AddPaymnt3);
            // 加算額４
            this.tNedit_AddPaymnt4.SetInt(scmMrktPriSt.AddPaymnt4);
            // 加算額５
            this.tNedit_AddPaymnt5.SetInt(scmMrktPriSt.AddPaymnt5);
            // 加算額６
            this.tNedit_AddPaymnt6.SetInt(scmMrktPriSt.AddPaymnt6);
            // 加算額７
            this.tNedit_AddPaymnt7.SetInt(scmMrktPriSt.AddPaymnt7);
            // 加算額８
            this.tNedit_AddPaymnt8.SetInt(scmMrktPriSt.AddPaymnt8);
            // 加算額９
            this.tNedit_AddPaymnt9.SetInt(scmMrktPriSt.AddPaymnt9);
            // 加算額１０
            this.tNedit_AddPaymnt10.SetInt(scmMrktPriSt.AddPaymnt10);

        }

		/// <summary>
        /// 画面情報SCM相場価格設定クラス格納処理
		/// </summary>
        /// <param name="scmMrktPriSt">SCM相場価格設定オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面情報からSCM相場価格設定オブジェクトにデータを格納します。</br>
		/// <br></br>
		/// </remarks>
		private void ScreenToSCMMrktPriSt(ref SCMMrktPriSt scmMrktPriSt)
		{
			if (scmMrktPriSt == null)
			{
				// 新規の場合
                scmMrktPriSt = new SCMMrktPriSt();
			}

            //企業コード
            scmMrktPriSt.EnterpriseCode = this._enterpriseCode; 
            // 拠点コード
            scmMrktPriSt.SectionCode = this.tEdit_SectionCodeAllowZero.DataText;

            // 相場価格回答区分
            scmMrktPriSt.MarketPriceAnswerDiv = (int)this.MarketPriceAnswerDiv_tComboEditor.Value;

            // 相場価格地域
            if (this.MarketPriceAreaCd_tComEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceAreaCd = (int)this.MarketPriceAreaCd_tComEditor.Value;
            }

            // 相場価格品質
            if (this.MarketPriceQualityCd_tComEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceQualityCd = (int)this.MarketPriceQualityCd_tComEditor.Value;
            }

            // 2010/04/12 Add >>>
            // 相場価格品質２
            if (this.MarketPriceQualityCd2_tComEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceQualityCd2 = (int)this.MarketPriceQualityCd2_tComEditor.Value;
            }
            else
            {
                scmMrktPriSt.MarketPriceQualityCd2 = -1;
            }

            // 相場価格品質３
            if (this.MarketPriceQualityCd3_tComEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceQualityCd3 = (int)this.MarketPriceQualityCd3_tComEditor.Value;
            }
            else
            {
                scmMrktPriSt.MarketPriceQualityCd3 = -1;
            }
            // 2010/04/12 Add <<<

            // 相場価格種別１
            if (this.MarketPriceKindCd1_tComboEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceKindCd1 = (int)this.MarketPriceKindCd1_tComboEditor.Value;
            }

            // 相場価格種別２
            if (this.MarketPriceKindCd2_tComboEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceKindCd2 = (int)this.MarketPriceKindCd2_tComboEditor.Value;
            }

            // 相場価格種別３
            if (this.MarketPriceKindCd3_tComboEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceKindCd3 = (int)this.MarketPriceKindCd3_tComboEditor.Value;
            }

            // 相場価格売価率
            scmMrktPriSt.MarketPriceSalesRate =  this.tNedit_MarketPriceSalesRate.GetValue();

            // 端数処理単位
            scmMrktPriSt.FractionProcCd = (int)this.FractionProcCd_tComboEditor.Value;

            // 加算額範囲
            scmMrktPriSt.AddPaymntAmbit1 = this.tNedit_AddPaymntAmbit1.GetInt();
            scmMrktPriSt.AddPaymntAmbit2 = this.tNedit_AddPaymntAmbit2.GetInt();
            scmMrktPriSt.AddPaymntAmbit3 = this.tNedit_AddPaymntAmbit3.GetInt();
            scmMrktPriSt.AddPaymntAmbit4 = this.tNedit_AddPaymntAmbit4.GetInt();
            scmMrktPriSt.AddPaymntAmbit5 = this.tNedit_AddPaymntAmbit5.GetInt();
            scmMrktPriSt.AddPaymntAmbit6 = this.tNedit_AddPaymntAmbit6.GetInt();
            scmMrktPriSt.AddPaymntAmbit7 = this.tNedit_AddPaymntAmbit7.GetInt();
            scmMrktPriSt.AddPaymntAmbit8 = this.tNedit_AddPaymntAmbit8.GetInt();
            scmMrktPriSt.AddPaymntAmbit9 = this.tNedit_AddPaymntAmbit9.GetInt();
            scmMrktPriSt.AddPaymntAmbit10 = this.tNedit_AddPaymntAmbit10.GetInt();

            // 加算額
            scmMrktPriSt.AddPaymnt1 = this.tNedit_AddPaymnt1.GetInt();
            scmMrktPriSt.AddPaymnt2 = this.tNedit_AddPaymnt2.GetInt();
            scmMrktPriSt.AddPaymnt3 = this.tNedit_AddPaymnt3.GetInt();
            scmMrktPriSt.AddPaymnt4 = this.tNedit_AddPaymnt4.GetInt();
            scmMrktPriSt.AddPaymnt5 = this.tNedit_AddPaymnt5.GetInt();
            scmMrktPriSt.AddPaymnt6 = this.tNedit_AddPaymnt6.GetInt();
            scmMrktPriSt.AddPaymnt7 = this.tNedit_AddPaymnt7.GetInt();
            scmMrktPriSt.AddPaymnt8 = this.tNedit_AddPaymnt8.GetInt();
            scmMrktPriSt.AddPaymnt9 = this.tNedit_AddPaymnt9.GetInt();
            scmMrktPriSt.AddPaymnt10 = this.tNedit_AddPaymnt10.GetInt();
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
            this._scmMrktPriStClone = null;

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
		///	SCM相場価格設定画面入力チェック処理
		/// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <param name="message">メッセージ</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : SCM相場価格設定画面の入力チェックをします。</br>
		/// <br></br>
		/// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
		{
            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero.DataText == "")
            {
                message = this.Section_uLabel.Text + "を設定して下さい。";
                control = this.tEdit_SectionCodeAllowZero;
                return false;
            }

            // 相場価格回答区分
            if (this.MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 1)
            {
                // する(売価率)
                if (this.tNedit_MarketPriceSalesRate.DataText == "")
                {
                    message = this.MarketPriceSalesRate_uLabel.Text + "を設定して下さい。";
                    control = this.tNedit_MarketPriceSalesRate;
                    return false;
                }
            }
            else if (this.MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 2)
            {
                int maxPaymnt = 0;
                // する(売価額)
                // 料金テーブル１
                if (tNedit_AddPaymntAmbit1.GetInt() == 0)
                {
                    message = "料金テーブル１を設定して下さい。";
                    control = this.tNedit_AddPaymntAmbit1;
                    return false;
                }
                else if (tNedit_AddPaymnt1.GetInt() == 0)
                {
                    message = "加算額１を設定して下さい。";
                    control = this.tNedit_AddPaymntAmbit1;
                    return false;
                }

                if (!InputDataSeqCheck(ref control))
                {
                    message = "料金テーブル１から順に設定して下さい。";
                    return false;
                }

                // 料金テーブル２
                maxPaymnt = tNedit_AddPaymntAmbit1.GetInt();
                if (tNedit_AddPaymntAmbit2.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt2.GetInt() == 0)
                    {
                        message = "加算額２を設定して下さい。";
                        control = this.tNedit_AddPaymnt2;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit2.GetInt() <= maxPaymnt)
                    {
                        message = "料金テーブル２は、料金テーブル１より大きい金額を設定して下さい。";
                        control = this.tNedit_AddPaymntAmbit2;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt2.GetInt() != 0)
                    {
                        message = "料金テーブル２を設定して下さい。";
                        control = this.tNedit_AddPaymnt2;
                        return false;
                    }
                }

                // 料金テーブル３
                maxPaymnt = tNedit_AddPaymntAmbit2.GetInt();
                if (tNedit_AddPaymntAmbit3.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt3.GetInt() == 0)
                    {
                        message = "加算額３を設定して下さい。";
                        control = this.tNedit_AddPaymnt3;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit3.GetInt() <= maxPaymnt)
                    {
                        message = "料金テーブル３は、料金テーブル２より大きい金額を設定して下さい。";
                        control = this.tNedit_AddPaymntAmbit3;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt3.GetInt() != 0)
                    {
                        message = "料金テーブル３を設定して下さい。";
                        control = this.tNedit_AddPaymnt3;
                        return false;
                    }
                }

                // 料金テーブル４
                maxPaymnt = tNedit_AddPaymntAmbit3.GetInt();
                if (tNedit_AddPaymntAmbit4.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt4.GetInt() == 0)
                    {
                        message = "加算額４を設定して下さい。";
                        control = this.tNedit_AddPaymnt4;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit4.GetInt() <= maxPaymnt)
                    {
                        message = "料金テーブル４は、料金テーブル３より大きい金額を設定して下さい。";
                        control = this.tNedit_AddPaymntAmbit4;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt4.GetInt() != 0)
                    {
                        message = "料金テーブル４を設定して下さい。";
                        control = this.tNedit_AddPaymnt4;
                        return false;
                    }
                }

                // 料金テーブル５
                maxPaymnt = tNedit_AddPaymntAmbit4.GetInt();
                if (tNedit_AddPaymntAmbit5.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt5.GetInt() == 0)
                    {
                        message = "加算額５を設定して下さい。";
                        control = this.tNedit_AddPaymnt5;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit5.GetInt() <= maxPaymnt)
                    {
                        message = "料金テーブル５は、料金テーブル４より大きい金額を設定して下さい。";
                        control = this.tNedit_AddPaymntAmbit5;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt5.GetInt() != 0)
                    {
                        message = "料金テーブル５を設定して下さい。";
                        control = this.tNedit_AddPaymnt5;
                        return false;
                    }
                }

                // 料金テーブル６
                maxPaymnt = tNedit_AddPaymntAmbit5.GetInt();
                if (tNedit_AddPaymntAmbit6.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt6.GetInt() == 0)
                    {
                        message = "加算額６を設定して下さい。";
                        control = this.tNedit_AddPaymnt6;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit6.GetInt() <= maxPaymnt)
                    {
                        message = "料金テーブル６は、料金テーブル５より大きい金額を設定して下さい。";
                        control = this.tNedit_AddPaymntAmbit6;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt6.GetInt() != 0)
                    {
                        message = "料金テーブル６を設定して下さい。";
                        control = this.tNedit_AddPaymnt6;
                        return false;
                    }
                }

                // 料金テーブル７
                maxPaymnt = tNedit_AddPaymntAmbit6.GetInt();
                if (tNedit_AddPaymntAmbit7.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt7.GetInt() == 0)
                    {
                        message = "加算額７を設定して下さい。";
                        control = this.tNedit_AddPaymnt7;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit7.GetInt() <= maxPaymnt)
                    {
                        message = "料金テーブル７は、料金テーブル６より大きい金額を設定して下さい。";
                        control = this.tNedit_AddPaymntAmbit7;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt7.GetInt() != 0)
                    {
                        message = "料金テーブル７を設定して下さい。";
                        control = this.tNedit_AddPaymnt7;
                        return false;
                    }
                }

                // 料金テーブル８
                maxPaymnt = tNedit_AddPaymntAmbit7.GetInt();
                if (tNedit_AddPaymntAmbit8.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt8.GetInt() == 0)
                    {
                        message = "加算額８を設定して下さい。";
                        control = this.tNedit_AddPaymnt8;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit8.GetInt() <= maxPaymnt)
                    {
                        message = "料金テーブル８は、料金テーブル７より大きい金額を設定して下さい。";
                        control = this.tNedit_AddPaymntAmbit8;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt8.GetInt() != 0)
                    {
                        message = "料金テーブル８を設定して下さい。";
                        control = this.tNedit_AddPaymnt8;
                        return false;
                    }
                }

                // 料金テーブル９
                maxPaymnt = tNedit_AddPaymntAmbit8.GetInt();
                if (tNedit_AddPaymntAmbit9.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt9.GetInt() == 0)
                    {
                        message = "加算額９を設定して下さい。";
                        control = this.tNedit_AddPaymnt9;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit9.GetInt() <= maxPaymnt)
                    {
                        message = "料金テーブル９は、料金テーブル８より大きい金額を設定して下さい。";
                        control = this.tNedit_AddPaymntAmbit9;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt9.GetInt() != 0)
                    {
                        message = "料金テーブル９を設定して下さい。";
                        control = this.tNedit_AddPaymnt9;
                        return false;
                    }
                }

                // 料金テーブル１０
                maxPaymnt = tNedit_AddPaymntAmbit9.GetInt();
                if (tNedit_AddPaymntAmbit10.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt10.GetInt() == 0)
                    {
                        message = "加算額１０を設定して下さい。";
                        control = this.tNedit_AddPaymnt10;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit10.GetInt() <= maxPaymnt)
                    {
                        message = "料金テーブル１０は、料金テーブル９より大きい金額を設定して下さい。";
                        control = this.tNedit_AddPaymntAmbit10;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt10.GetInt() != 0)
                    {
                        message = "料金テーブル１０を設定して下さい。";
                        control = this.tNedit_AddPaymnt10;
                        return false;
                    }
                }
            }

            return true;
		}

        /// <summary>
        ///	料金テーブル入力順チェック処理
        /// </summary>
        /// <param name="control">不正対象コントロール</param>
        /// <returns>チェック結果(true:OK／false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : 料金テーブルの入力順チェックをします。</br>
        /// <br></br>
        /// </remarks>
        private bool InputDataSeqCheck(ref Control control)
        {
            bool input = true;

            // 料金テーブル２
            if ((tNedit_AddPaymntAmbit2.GetInt() == 0) && (tNedit_AddPaymnt2.GetInt() == 0))
            {
                input = false;
            }

            // 料金テーブル３
            if ((tNedit_AddPaymntAmbit3.GetInt() == 0) && (tNedit_AddPaymnt3.GetInt() == 0))
            {
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit3;
                    return false;
                }
            }

            // 料金テーブル４
            if ((tNedit_AddPaymntAmbit4.GetInt() == 0) && (tNedit_AddPaymnt4.GetInt() == 0))
            {
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit4;
                    return false;
                }
            }

            // 料金テーブル５
            if ((tNedit_AddPaymntAmbit5.GetInt() == 0) && (tNedit_AddPaymnt5.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit5;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit5;
                    return false;
                }
            }

            // 料金テーブル６
            if ((tNedit_AddPaymntAmbit6.GetInt() == 0) && (tNedit_AddPaymnt6.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit6;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit6;
                    return false;
                }
            }

            // 料金テーブル７
            if ((tNedit_AddPaymntAmbit7.GetInt() == 0) && (tNedit_AddPaymnt7.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit7;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit7;
                    return false;
                }
            }

            // 料金テーブル８
            if ((tNedit_AddPaymntAmbit8.GetInt() == 0) && (tNedit_AddPaymnt8.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit8;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit8;
                    return false;
                }
            }

            // 料金テーブル９
            if ((tNedit_AddPaymntAmbit9.GetInt() == 0) && (tNedit_AddPaymnt9.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit9;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit9;
                    return false;
                }
            }

            // 料金テーブル１０
            if ((tNedit_AddPaymntAmbit10.GetInt() == 0) && (tNedit_AddPaymnt10.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit10;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit10;
                    return false;
                }
            }




            //// 料金テーブル２
            //if ((tNedit_AddPaymntAmbit2.GetInt() == 0) && (tNedit_AddPaymnt2.GetInt() == 0))
            //{
            //    input = false;
            //}

            //// 料金テーブル３
            //if ((tNedit_AddPaymntAmbit3.GetInt() == 0) && (tNedit_AddPaymnt3.GetInt() == 0))
            //{
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit3;
            //        return false;
            //    }
            //}

            //// 料金テーブル４
            //if ((tNedit_AddPaymntAmbit4.GetInt() == 0) && (tNedit_AddPaymnt4.GetInt() == 0))
            //{
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit4;
            //        return false;
            //    }
            //}

            //// 料金テーブル５
            //if ((tNedit_AddPaymntAmbit5.GetInt() == 0) && (tNedit_AddPaymnt5.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit5;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit5;
            //        return false;
            //    }
            //}

            //// 料金テーブル６
            //if ((tNedit_AddPaymntAmbit6.GetInt() == 0) && (tNedit_AddPaymnt6.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit6;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit6;
            //        return false;
            //    }
            //}

            //// 料金テーブル７
            //if ((tNedit_AddPaymntAmbit7.GetInt() == 0) && (tNedit_AddPaymnt7.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit7;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit7;
            //        return false;
            //    }
            //}

            //// 料金テーブル８
            //if ((tNedit_AddPaymntAmbit8.GetInt() == 0) && (tNedit_AddPaymnt8.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit8;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit8;
            //        return false;
            //    }
            //}

            //// 料金テーブル９
            //if ((tNedit_AddPaymntAmbit9.GetInt() == 0) && (tNedit_AddPaymnt9.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit9;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit9;
            //        return false;
            //    }
            //}

            //// 料金テーブル１０
            //if ((tNedit_AddPaymntAmbit10.GetInt() == 0) && (tNedit_AddPaymnt10.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit10;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit10;
            //        return false;
            //    }
            //}

            return true;
        }

		/// <summary>
        ///　保存処理(SaveProc())
		/// </summary>
		/// <remarks>
		/// <br>Note　　　  : 保存処理を行います。</br>
		/// <br></br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
            
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
	
			SCMMrktPriSt scmMrktPriSt = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                scmMrktPriSt = ((SCMMrktPriSt)this._scmMrktPriStTable[guid]).Clone();
			}

            // 画面情報を取得
			ScreenToSCMMrktPriSt(ref scmMrktPriSt);
            // 登録・更新処理
			int status = this._scmMrktPriStAcs.Write(ref scmMrktPriSt);

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
						this._scmMrktPriStAcs,				    	// エラーが発生したオブジェクト
						MessageBoxButtons.OK,			  		// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
                    CloseForm(DialogResult.Cancel);
					return false;
				}
			}

            // SCM相場価格設定情報クラスのデータセット展開処理
			SCMMrktPriStToDataSet(scmMrktPriSt, this.DataIndex);

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
                tEdit_SectionCodeAllowZero.Focus();

                control = tEdit_SectionCodeAllowZero;
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
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(190, 24);
            this.tNedit_MarketPriceSalesRate.Size = new System.Drawing.Size(100, 24);
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br></br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // 全社共通チェック
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "全社共通";
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
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            string msg = "入力されたコードのSCM相場価格設定情報が既に登録されています。\n編集を行いますか？";

            // 拠点コード
            string sectionCd = tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');

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
                          "入力されたコードのSCM相場価格設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 拠点コード、名称のクリア
                        tEdit_SectionCodeAllowZero.Clear();
                        SectionName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == ALL_SECTIONCODE)
                    {
                        // 全社共通のメッセージ変更
                        msg = "入力されたコードのSCM相場価格設定情報が既に登録されています。\n　【拠点名称：全社共通】\n編集を行いますか？";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PROGRAM_ID,                             // アセンブリＩＤまたはクラスＩＤ
                        msg,                                    // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
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
                                tEdit_SectionCodeAllowZero.Clear();
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
        ///	Form.Load イベント(PMSCM09050UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09050UA_Load(object sender, System.EventArgs e)
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
            
            // コントロールサイズ設定
            SetControlSize();
            
			// 画面初期設定処理
			ScreenInitialSetting();
		}

		/// <summary>
        ///	Form.Closing イベント(PMSCM09050UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じ
		///					  ようとしたときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09050UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        ///	Form.VisibleChanged イベント(PMSCM09050UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: フォームの表示・非表示が切り替えられ
		///					  たときに発生します。</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09050UA_VisibleChanged(object sender, System.EventArgs e)
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
                SCMMrktPriSt compareSCMMrktPriSt = new SCMMrktPriSt();

                compareSCMMrktPriSt = this._scmMrktPriStClone.Clone();
                ScreenToSCMMrktPriSt(ref compareSCMMrktPriSt);

                // 画面情報と起動時のクローンと比較し変更を監視する
                if ((!(this._scmMrktPriStClone.Equals(compareSCMMrktPriSt))))
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
                                    tEdit_SectionCodeAllowZero.Focus();
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
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.MarketPriceAnswerDiv_tComboEditor.Focus();

                    // 新規モードからモード変更対応
                    if (this.DataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            SectionGuide_Button.Focus();
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

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
                PROGRAM_ID,						// アセンブリＩＤまたはクラスＩＤ
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
            SCMMrktPriSt scmMrktPriSt = (SCMMrktPriSt)this._scmMrktPriStTable[guid];

            // 完全削除処理
            int status = this._scmMrktPriStAcs.Delete(scmMrktPriSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._scmMrktPriStTable.Remove(scmMrktPriSt.FileHeaderGuid);

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
                            this._scmMrktPriStAcs, 				    // エラーが発生したオブジェクト
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
            SCMMrktPriSt scmMrktPriSt = ((SCMMrktPriSt)this._scmMrktPriStTable[guid]).Clone();

            // 復活処理
            status = this._scmMrktPriStAcs.Revival(ref scmMrktPriSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // SCM相場価格設定情報クラスのデータセット展開処理
                        SCMMrktPriStToDataSet(scmMrktPriSt, this._dataIndex);
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
                            this._scmMrktPriStAcs,					// エラーが発生したオブジェクト
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
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 新規モードからモード変更対応
            _modeFlg = false;

            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                // 拠点コード取得
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;

                // 拠点名称取得
                this.SectionName_tEdit.DataText = GetSectionName(sectionCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // フォーカス設定
                            e.NextCtrl = this.MarketPriceAnswerDiv_tComboEditor;
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
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero;
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
                else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero")
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero;
                    }
                }
            }
            else if (e.PrevCtrl == MarketPriceAnswerDiv_tComboEditor)
            {
                if ((e.ShiftKey) && (e.Key == Keys.Tab))
                {
                    // SHIFT+TAB制御
                    if (!tEdit_SectionCodeAllowZero.Enabled)
                    {
                        e.NextCtrl = Cancel_Button;
                    }
                    else
                    {
                        if (SectionName_tEdit.DataText != "")
                        {
                            e.NextCtrl = tEdit_SectionCodeAllowZero;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 最新情報ボタンクリック
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PROGRAM_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }

        /// <summary>
        /// MarketPriceAnswerDiv_tComboEditor_ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　 : 値が変更された時に発生します。</br>
        /// <br></br>
        /// </remarks>
        private void MarketPriceAnswerDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 相場価格回答区分による入力許可制御
            MarketPriceAnswerDivPermissionControl();

            // クリア処理
            if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 0)
            {
                // しない
                MarketPriceAreaCd_tComEditor.SelectedIndex = 0;
                MarketPriceQualityCd_tComEditor.SelectedIndex = 0;
                // 2010/04/12 Add >>>
                MarketPriceQualityCd2_tComEditor.SelectedIndex = -1;
                MarketPriceQualityCd3_tComEditor.SelectedIndex = -1;
                // 2010/04/12 Add <<<
                MarketPriceKindCd1_tComboEditor.SelectedIndex = 0;
                MarketPriceKindCd2_tComboEditor.SelectedIndex = 0;
                MarketPriceKindCd3_tComboEditor.SelectedIndex = 0;
                tNedit_MarketPriceSalesRate.Clear();
                FractionProcCd_tComboEditor.SelectedIndex = 0;

                tNedit_AddPaymntAmbit1.Clear();
                tNedit_AddPaymntAmbit2.Clear();
                tNedit_AddPaymntAmbit3.Clear();
                tNedit_AddPaymntAmbit4.Clear();
                tNedit_AddPaymntAmbit5.Clear();
                tNedit_AddPaymntAmbit6.Clear();
                tNedit_AddPaymntAmbit7.Clear();
                tNedit_AddPaymntAmbit8.Clear();
                tNedit_AddPaymntAmbit9.Clear();
                tNedit_AddPaymntAmbit10.Clear();

                tNedit_AddPaymnt1.Clear();
                tNedit_AddPaymnt2.Clear();
                tNedit_AddPaymnt3.Clear();
                tNedit_AddPaymnt4.Clear();
                tNedit_AddPaymnt5.Clear();
                tNedit_AddPaymnt6.Clear();
                tNedit_AddPaymnt7.Clear();
                tNedit_AddPaymnt8.Clear();
                tNedit_AddPaymnt9.Clear();
                tNedit_AddPaymnt10.Clear();
            }
            else if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 1)
            {
                // する（売価率）
                tNedit_AddPaymntAmbit1.Clear();
                tNedit_AddPaymntAmbit2.Clear();
                tNedit_AddPaymntAmbit3.Clear();
                tNedit_AddPaymntAmbit4.Clear();
                tNedit_AddPaymntAmbit5.Clear();
                tNedit_AddPaymntAmbit6.Clear();
                tNedit_AddPaymntAmbit7.Clear();
                tNedit_AddPaymntAmbit8.Clear();
                tNedit_AddPaymntAmbit9.Clear();
                tNedit_AddPaymntAmbit10.Clear();

                tNedit_AddPaymnt1.Clear();
                tNedit_AddPaymnt2.Clear();
                tNedit_AddPaymnt3.Clear();
                tNedit_AddPaymnt4.Clear();
                tNedit_AddPaymnt5.Clear();
                tNedit_AddPaymnt6.Clear();
                tNedit_AddPaymnt7.Clear();
                tNedit_AddPaymnt8.Clear();
                tNedit_AddPaymnt9.Clear();
                tNedit_AddPaymnt10.Clear();
            }
            else if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 2)
            {
                // する（加算テーブル）
                tNedit_MarketPriceSalesRate.Clear();
                FractionProcCd_tComboEditor.SelectedIndex = 0;
            }
        }

        // ADD 2009/08/26 チケット[14168]対応：相場価格売価率は100%以上 ---------->>>>>
        /// <summary>
        /// 相場価格売価率テキストのLeaveイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void tNedit_MarketPriceSalesRate_Leave(object sender, EventArgs e)
        {
            double marketPriceSalesRate = 0.0;
            if (!string.IsNullOrEmpty(this.tNedit_MarketPriceSalesRate.Text.Trim()))
            {
                marketPriceSalesRate = double.Parse(this.tNedit_MarketPriceSalesRate.Text.Trim());
            }
            if (marketPriceSalesRate < 100.0)
            {
                TMsgDisp.Show(
                    this,                                           // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,			        // エラーレベル
                    PROGRAM_ID,							            // アセンブリID
                    this.Text,              　　                    // プログラム名称
                    "tNedit_MarketPriceSalesRate_Leave",            // 処理名称
                    TMsgDisp.OPE_GET,                               // オペレーション
                    "相場価格売価率は 100%以上 を設定して下さい。", // 表示するメッセージ
                    0,							                    // ステータス値
                    this,			                                // エラーが発生したオブジェクト
                    MessageBoxButtons.OK,			                // 表示するボタン
                    MessageBoxDefaultButton.Button1                 // 初期表示ボタン
                );
                this.tNedit_MarketPriceSalesRate.Focus();
            }
        }

        // ADD 2009/08/26 チケット[14168]対応：相場価格売価率は100%以上 ----------<<<<<

        // 2010/04/12 Add >>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarketPriceKindCd2_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if ((int)MarketPriceKindCd2_tComboEditor.Value == -1)
            {
                MarketPriceQualityCd2_tComEditor.Value = null;
                MarketPriceQualityCd2_tComEditor.Enabled = false;
            }
            else
            {
                MarketPriceQualityCd2_tComEditor.Enabled = true;
                if (MarketPriceQualityCd2_tComEditor.Value == null)
                {
                    this.MarketPriceQualityCd2_tComEditor.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarketPriceKindCd3_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if ((int)MarketPriceKindCd3_tComboEditor.Value == -1)
            {
                MarketPriceQualityCd3_tComEditor.Value = null;
                MarketPriceQualityCd3_tComEditor.Enabled = false;
            }
            else
            {
                MarketPriceQualityCd3_tComEditor.Enabled = true;
                if (MarketPriceQualityCd3_tComEditor.Value == null)
                {
                    this.MarketPriceQualityCd3_tComEditor.SelectedIndex = 0;
                }
            }
        }
        // 2010/04/12 Add <<<

		#endregion
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Windows.Forms;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 掛率マスタ一括登録 抽出条件入力画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 掛率マスタ一括登録 抽出条件入力画面クラス</br>
	/// <br>Programmer	: 30167 上野　弘貴</br>
	/// <br>Date		: 2007.11.08</br>
	/// <br>Update Note: 2008.03.03 30167 上野　弘貴</br>
	/// <br>			・項目ゼロ埋め対応（画面デザインにコンポーネント追加、
	///					　Tedit、TNeditの設定変更）</br>
	/// <br>Update Note: 2008.03.04 30167 上野　弘貴</br>
	/// <br>			　商品検索画面にメーカーコードを引き継ぐよう修正</br>
	/// <br>Update Note: 2008.03.05 30167 上野　弘貴</br>
	///	<br>			・メーカーコード設定時の商品コード検索・設定修正</br>
	/// <br>Update Note: 2008.03.07 30167 上野　弘貴</br>
	///	<br>			・項目クリア後エンターキーで次項目へ移動するよう修正</br>
    /// <br></br>
    /// <br>Update Note : 2008.04.24 20056 對馬 大輔</br>
    ///	<br>			・PM.NS 共通修正 得意先・仕入先分離対応</br>
    /// </remarks>
	public class DCKHN09180UA : Form, IInventInputMdiChild
	{
		# region Private Members (Component)

		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel DispDiv_uLabel;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet2;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet3;
		private Infragistics.Win.UltraWinTree.UltraTree ultraTree2;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
		private System.Windows.Forms.Timer tm_InitialTimer;
		private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
		private Infragistics.Win.Misc.UltraLabel UnitPriceKind_Label;
		private Broadleaf.Library.Windows.Forms.TComboEditor UnitPriceKindWay_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel UnitPriceKindWay_Label;
		private Broadleaf.Library.Windows.Forms.TComboEditor UnitPriceKind_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TEdit RateMngCustNm_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit RateMngGoodsNm_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit RateMngCustCd_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit RateMngGoodsCd_tEdit;
		private Infragistics.Win.Misc.UltraLabel RateMngCust_Label;
		private Infragistics.Win.Misc.UltraLabel RateMngGoods_Label;
		private Broadleaf.Library.Windows.Forms.TEdit RateSettingDivide_tEdit;
		private Infragistics.Win.Misc.UltraLabel RateSettingDivide_Label;
		private Broadleaf.Library.Windows.Forms.TComboEditor DispDiv_tComboEditor;
		private System.Windows.Forms.Panel Grp_panel;
		private Broadleaf.Library.Windows.Forms.TComboEditor EnterpriseGanreCode_Grp_tComboEditor;
		private Infragistics.Win.Misc.UltraButton DetailGoodsGanreCode_Grp_uButton;
		private Infragistics.Win.Misc.UltraButton MediumGoodsGanreCode_Grp_uButton;
		private Infragistics.Win.Misc.UltraButton LargeGoodsGanreCode_Grp_uButton;
		private Broadleaf.Library.Windows.Forms.TEdit DetailGoodsGanreCodeNm_Grp_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit MediumGoodsGanreCodeNm_Grp_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit LargeGoodsGanreCodeNm_Grp_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit DetailGoodsGanreCode_Grp_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit MediumGoodsGanreCode_Grp_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit LargeGoodsGanreCode_Grp_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit GoodsRateRankCd_Grp_tEdit;
		private Infragistics.Win.Misc.UltraButton BLGoodsCode_Grp_uButton;
		private Broadleaf.Library.Windows.Forms.TEdit BLGoodsCodeNm_Grp_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit BLGoodsCode_Grp_tNedit;
		private Infragistics.Win.Misc.UltraLabel BLGoodsCode_Grp_Label;
		private Infragistics.Win.Misc.UltraLabel EnterpriseGanreCode_Grp_Label;
		private Infragistics.Win.Misc.UltraLabel DetailGoodsGanreCode_Grp_Label;
		private Infragistics.Win.Misc.UltraLabel MediumGoodsGanreCode_Grp_Label;
		private Infragistics.Win.Misc.UltraLabel LargeGoodsGanreCode_Grp_Label;
		private Infragistics.Win.Misc.UltraButton GoodsMakerCd_Grp_uButton;
		private Broadleaf.Library.Windows.Forms.TEdit GoodsMakerCdNm_Grp_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit GoodsMakerCd_Grp_tNedit;
		private Infragistics.Win.Misc.UltraLabel GoodsRateRank_Grp_Label;
		private Infragistics.Win.Misc.UltraLabel GoodsMakerCd_Grp_Label;
		private System.Windows.Forms.Panel Customer_panel;
		private Infragistics.Win.Misc.UltraButton SupplierCd_uButton;
		private Broadleaf.Library.Windows.Forms.TNedit SupplierCd_tNedit;
		private Broadleaf.Library.Windows.Forms.TEdit CustomerCodeNm_tEdit;
		private Infragistics.Win.Misc.UltraLabel SuppRateGrpCodeLabel;
		private Infragistics.Win.Misc.UltraLabel SupplierCd_Label;
		private Infragistics.Win.Misc.UltraButton CustomerCode_uButton;
		private Broadleaf.Library.Windows.Forms.TEdit SupplierCdNm_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit CustomerCode_tNedit;
		private Infragistics.Win.Misc.UltraLabel CustomerCode_Label;
		private Infragistics.Win.Misc.UltraLabel CustRateGrpCode_Label;
		private System.Windows.Forms.Panel Single_panel;
		private Infragistics.Win.Misc.UltraButton GoodsMakerCd_uButton;
		private Infragistics.Win.Misc.UltraButton GoodsNo_uButton;
		private Broadleaf.Library.Windows.Forms.TEdit GoodsNoNm_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit GoodsNoCd_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit GoodsMakerCdNm_tEdit;
		private Infragistics.Win.Misc.UltraLabel DetailGoodsGanreCode_Label;
		private Broadleaf.Library.Windows.Forms.TNedit GoodsMakerCd_tNedit;
		private Infragistics.Win.Misc.UltraLabel GoodsMakerCd_Label;
		private Infragistics.Win.Misc.UltraLabel CustomerInfo_Title_uLabel;
		private Infragistics.Win.Misc.UltraLabel GoodsInfo_Title_uLabel;
		private Infragistics.Win.Misc.UltraButton RateSettingDivide_uButton;
		private TComboEditor SuppRateGrpCode_tComboEditor;
		private TComboEditor CustRateGrpCode_tComboEditor;
		private UiSetControl uiSetControl1;
		private System.ComponentModel.IContainer components = null;

		#endregion
		
		#region Constructor
		/// <summary>
		/// 掛率マスタ一括登録 抽出条件入力画面クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 掛率マスタ一括登録 抽出条件入力画面クラスのインスタンスを作成</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// <br>Update Note: </br>
		/// </remarks>
		public DCKHN09180UA ()
		{
			InitializeComponent();

			//--------------------
			// 各種アクセスクラス
			//--------------------
			this._rateBlanketAcs = new RateBlanketAcs();		// 掛率一括アクセスクラス
			this._userGuideAcs = new UserGuideAcs();			// ユーザーガイドアクセスクラス
			this._customerInfoAcs = new CustomerInfoAcs();		// 得意先アクセスクラス
            this._supplierAcs = new SupplierAcs();              // 仕入先アクセスクラス // ADD 2008.04.24
			this._rateProtyMngAcs = new RateProtyMngAcs();		// 掛率優先管理アクセスクラス
			this._goodsAcs = new GoodsAcs();					// 商品アクセスクラス
			this._makerAcs = new MakerAcs();					// メーカーアクセスクラス
			this._lGoodsGanreAcs = new LGoodsGanreAcs();		// 商品区分グループアクセスクラス
			this._mGoodsGanreAcs = new MGoodsGanreAcs();		// 商品区分アクセスクラス
			this._dGoodsGanreAcs = new DGoodsGanreAcs();		// 商品区分詳細アクセスクラス
			this._blGoodsCdAcs = new BLGoodsCdAcs();			// BLアクセスクラス
			
			//----------------------
			// 各データ格納用リスト
			//----------------------
			this._custRateGrpCodeSList = new SortedList();		// 得意先掛率グループ
			this._suppRateGrpCodeSList = new SortedList();		// 仕入先掛率グループ
			this._enterpriseGanreCodeSList = new SortedList();	// 自社分類
			this._priceDivSList = new SortedList();				// 価格区分 -グリッド画面用
			this._bargainCdSList = new SortedList();			// 特売区分 -グリッド画面用

			//--------------------
			// コンボボックス設定
			//--------------------
			// コンボボックス用データテーブル
			this._dataTableUnitPriceKind = new DataTable();
			this._dataTableUnitPriceKindWay = new DataTable();
			this._dataTableCustRateGrpCode = new DataTable();
			this._dataTableSuppRateGrpCode = new DataTable();
			this._dataTableDispDiv = new DataTable();
			this._dataTableEnterpriseGanreCode = new DataTable();

			DataTblColumnConstComboList(ref this._dataTableUnitPriceKind);
			DataTblColumnConstComboList(ref this._dataTableUnitPriceKindWay);
			DataTblColumnConstComboList(ref this._dataTableDispDiv);
			DataTblColumnConstComboList(ref this._dataTableCustRateGrpCode);
			DataTblColumnConstComboList(ref this._dataTableSuppRateGrpCode);
			DataTblColumnConstComboList(ref this._dataTableEnterpriseGanreCode);

			//--------------
			// 各種条件設定
			//--------------
			// 入力条件用データテーブル
			this._dataTableInpCond = new DataTable();
			DataTblColumnConstInpCond(ref this._dataTableInpCond);

			// 商品掛率条件用データテーブル
			this._dataTableRateGoodsCond = new DataTable();
			DataTblColumnConstGoodsRateCond(ref this._dataTableRateGoodsCond);

			// 得意先掛率条件用データテーブル
			this._dataTableRateCustCond = new DataTable();
			DataTblColumnConstCustRateCond(ref this._dataTableRateCustCond);

			// 文字列結合用
			this._stringBuilder = new StringBuilder();
		}
		#endregion

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
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
			Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
			Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKHN09180UA));
			this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
			this.RateSettingDivide_uButton = new Infragistics.Win.Misc.UltraButton();
			this.DispDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.RateMngCustNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.RateMngGoodsNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.RateMngCustCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.RateMngGoodsCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.RateMngCust_Label = new Infragistics.Win.Misc.UltraLabel();
			this.RateMngGoods_Label = new Infragistics.Win.Misc.UltraLabel();
			this.RateSettingDivide_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.RateSettingDivide_Label = new Infragistics.Win.Misc.UltraLabel();
			this.UnitPriceKindWay_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.UnitPriceKindWay_Label = new Infragistics.Win.Misc.UltraLabel();
			this.UnitPriceKind_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.UnitPriceKind_Label = new Infragistics.Win.Misc.UltraLabel();
			this.DispDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
			this.Single_panel = new System.Windows.Forms.Panel();
			this.GoodsMakerCd_uButton = new Infragistics.Win.Misc.UltraButton();
			this.GoodsNo_uButton = new Infragistics.Win.Misc.UltraButton();
			this.GoodsNoNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.GoodsNoCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.GoodsMakerCdNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.DetailGoodsGanreCode_Label = new Infragistics.Win.Misc.UltraLabel();
			this.GoodsMakerCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.GoodsMakerCd_Label = new Infragistics.Win.Misc.UltraLabel();
			this.CustomerInfo_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.GoodsInfo_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.Customer_panel = new System.Windows.Forms.Panel();
			this.SupplierCd_uButton = new Infragistics.Win.Misc.UltraButton();
			this.SuppRateGrpCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.SupplierCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.CustRateGrpCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.CustomerCodeNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.SuppRateGrpCodeLabel = new Infragistics.Win.Misc.UltraLabel();
			this.SupplierCd_Label = new Infragistics.Win.Misc.UltraLabel();
			this.CustomerCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.CustomerCode_uButton = new Infragistics.Win.Misc.UltraButton();
			this.SupplierCdNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.CustomerCode_Label = new Infragistics.Win.Misc.UltraLabel();
			this.CustRateGrpCode_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Grp_panel = new System.Windows.Forms.Panel();
			this.EnterpriseGanreCode_Grp_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.DetailGoodsGanreCode_Grp_uButton = new Infragistics.Win.Misc.UltraButton();
			this.MediumGoodsGanreCode_Grp_uButton = new Infragistics.Win.Misc.UltraButton();
			this.LargeGoodsGanreCode_Grp_uButton = new Infragistics.Win.Misc.UltraButton();
			this.DetailGoodsGanreCodeNm_Grp_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.MediumGoodsGanreCodeNm_Grp_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.LargeGoodsGanreCodeNm_Grp_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.DetailGoodsGanreCode_Grp_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.MediumGoodsGanreCode_Grp_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.LargeGoodsGanreCode_Grp_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.GoodsRateRankCd_Grp_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.BLGoodsCode_Grp_uButton = new Infragistics.Win.Misc.UltraButton();
			this.BLGoodsCodeNm_Grp_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.BLGoodsCode_Grp_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.BLGoodsCode_Grp_Label = new Infragistics.Win.Misc.UltraLabel();
			this.EnterpriseGanreCode_Grp_Label = new Infragistics.Win.Misc.UltraLabel();
			this.DetailGoodsGanreCode_Grp_Label = new Infragistics.Win.Misc.UltraLabel();
			this.MediumGoodsGanreCode_Grp_Label = new Infragistics.Win.Misc.UltraLabel();
			this.LargeGoodsGanreCode_Grp_Label = new Infragistics.Win.Misc.UltraLabel();
			this.GoodsMakerCd_Grp_uButton = new Infragistics.Win.Misc.UltraButton();
			this.GoodsMakerCdNm_Grp_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.GoodsMakerCd_Grp_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.GoodsRateRank_Grp_Label = new Infragistics.Win.Misc.UltraLabel();
			this.GoodsMakerCd_Grp_Label = new Infragistics.Win.Misc.UltraLabel();
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
			this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
			this.ultraOptionSet2 = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
			this.ultraOptionSet3 = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
			this.ultraTree2 = new Infragistics.Win.UltraWinTree.UltraTree();
			this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
			this.tm_InitialTimer = new System.Windows.Forms.Timer(this.components);
			this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
			this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
			this.ultraExplorerBarContainerControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DispDiv_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RateMngCustNm_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RateMngGoodsNm_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RateMngCustCd_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RateMngGoodsCd_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RateSettingDivide_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UnitPriceKindWay_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UnitPriceKind_tComboEditor)).BeginInit();
			this.ultraExplorerBarContainerControl1.SuspendLayout();
			this.Single_panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GoodsNoNm_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsNoCd_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCdNm_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_tNedit)).BeginInit();
			this.Customer_panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SuppRateGrpCode_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SupplierCd_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CustRateGrpCode_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CustomerCodeNm_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CustomerCode_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SupplierCdNm_tEdit)).BeginInit();
			this.Grp_panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.EnterpriseGanreCode_Grp_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DetailGoodsGanreCodeNm_Grp_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MediumGoodsGanreCodeNm_Grp_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LargeGoodsGanreCodeNm_Grp_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DetailGoodsGanreCode_Grp_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MediumGoodsGanreCode_Grp_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LargeGoodsGanreCode_Grp_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsRateRankCd_Grp_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BLGoodsCodeNm_Grp_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Grp_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCdNm_Grp_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_Grp_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
			this.Main_ultraExplorerBar.SuspendLayout();
			this.ultraExplorerBarContainerControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraTree2)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraExplorerBarContainerControl2
			// 
			this.ultraExplorerBarContainerControl2.Controls.Add(this.RateSettingDivide_uButton);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.DispDiv_tComboEditor);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.RateMngCustNm_tEdit);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.RateMngGoodsNm_tEdit);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.RateMngCustCd_tEdit);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.RateMngGoodsCd_tEdit);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.RateMngCust_Label);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.RateMngGoods_Label);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.RateSettingDivide_tEdit);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.RateSettingDivide_Label);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.UnitPriceKindWay_tComboEditor);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.UnitPriceKindWay_Label);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.UnitPriceKind_tComboEditor);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.UnitPriceKind_Label);
			this.ultraExplorerBarContainerControl2.Controls.Add(this.DispDiv_uLabel);
			this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(18, 46);
			this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
			this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(970, 106);
			this.ultraExplorerBarContainerControl2.TabIndex = 0;
			// 
			// RateSettingDivide_uButton
			// 
			appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.RateSettingDivide_uButton.Appearance = appearance1;
			this.RateSettingDivide_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.RateSettingDivide_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.RateSettingDivide_uButton.Location = new System.Drawing.Point(409, 10);
			this.RateSettingDivide_uButton.Name = "RateSettingDivide_uButton";
			this.RateSettingDivide_uButton.Size = new System.Drawing.Size(24, 24);
			this.RateSettingDivide_uButton.TabIndex = 4;
			this.RateSettingDivide_uButton.Click += new System.EventHandler(this.RateSettingDivide_uButton_Click);
			// 
			// DispDiv_tComboEditor
			// 
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.DispDiv_tComboEditor.ActiveAppearance = appearance2;
			appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.DispDiv_tComboEditor.Appearance = appearance3;
			this.DispDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.DispDiv_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.DispDiv_tComboEditor.ItemAppearance = appearance4;
			this.DispDiv_tComboEditor.Location = new System.Drawing.Point(814, 9);
			this.DispDiv_tComboEditor.Name = "DispDiv_tComboEditor";
			this.DispDiv_tComboEditor.Size = new System.Drawing.Size(153, 24);
			this.DispDiv_tComboEditor.TabIndex = 9;
			// 
			// RateMngCustNm_tEdit
			// 
			appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.RateMngCustNm_tEdit.ActiveAppearance = appearance5;
			appearance6.BackColor = System.Drawing.Color.Gainsboro;
			appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.RateMngCustNm_tEdit.Appearance = appearance6;
			this.RateMngCustNm_tEdit.AutoSelect = true;
			this.RateMngCustNm_tEdit.DataText = "";
			this.RateMngCustNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.RateMngCustNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 32, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.RateMngCustNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.RateMngCustNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.RateMngCustNm_tEdit.Location = new System.Drawing.Point(400, 71);
			this.RateMngCustNm_tEdit.MaxLength = 32;
			this.RateMngCustNm_tEdit.Name = "RateMngCustNm_tEdit";
			this.RateMngCustNm_tEdit.ReadOnly = true;
			this.RateMngCustNm_tEdit.Size = new System.Drawing.Size(516, 24);
			this.RateMngCustNm_tEdit.TabIndex = 8;
			this.RateMngCustNm_tEdit.TabStop = false;
			// 
			// RateMngGoodsNm_tEdit
			// 
			appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.RateMngGoodsNm_tEdit.ActiveAppearance = appearance7;
			appearance8.BackColor = System.Drawing.Color.Gainsboro;
			appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.RateMngGoodsNm_tEdit.Appearance = appearance8;
			this.RateMngGoodsNm_tEdit.AutoSelect = true;
			this.RateMngGoodsNm_tEdit.DataText = "ﾒｰｶｰ＋商品区分詳細＋商品区分＋商品区分ｸﾞﾙｰﾌﾟ";
			this.RateMngGoodsNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.RateMngGoodsNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 32, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.RateMngGoodsNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.RateMngGoodsNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.RateMngGoodsNm_tEdit.Location = new System.Drawing.Point(400, 41);
			this.RateMngGoodsNm_tEdit.MaxLength = 32;
			this.RateMngGoodsNm_tEdit.Name = "RateMngGoodsNm_tEdit";
			this.RateMngGoodsNm_tEdit.ReadOnly = true;
			this.RateMngGoodsNm_tEdit.Size = new System.Drawing.Size(516, 24);
			this.RateMngGoodsNm_tEdit.TabIndex = 6;
			this.RateMngGoodsNm_tEdit.TabStop = false;
			this.RateMngGoodsNm_tEdit.Text = "ﾒｰｶｰ＋商品区分詳細＋商品区分＋商品区分ｸﾞﾙｰﾌﾟ";
			// 
			// RateMngCustCd_tEdit
			// 
			this.RateMngCustCd_tEdit.ActiveAppearance = appearance9;
			this.RateMngCustCd_tEdit.AutoSelect = true;
			this.RateMngCustCd_tEdit.DataText = "1";
			this.RateMngCustCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.RateMngCustCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.RateMngCustCd_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.RateMngCustCd_tEdit.Location = new System.Drawing.Point(379, 71);
			this.RateMngCustCd_tEdit.MaxLength = 1;
			this.RateMngCustCd_tEdit.Name = "RateMngCustCd_tEdit";
			this.RateMngCustCd_tEdit.ReadOnly = true;
			this.RateMngCustCd_tEdit.Size = new System.Drawing.Size(20, 24);
			this.RateMngCustCd_tEdit.TabIndex = 7;
			this.RateMngCustCd_tEdit.TabStop = false;
			this.RateMngCustCd_tEdit.Text = "1";
			// 
			// RateMngGoodsCd_tEdit
			// 
			this.RateMngGoodsCd_tEdit.ActiveAppearance = appearance10;
			this.RateMngGoodsCd_tEdit.AutoSelect = true;
			this.RateMngGoodsCd_tEdit.DataText = "E";
			this.RateMngGoodsCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.RateMngGoodsCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, false));
			this.RateMngGoodsCd_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.RateMngGoodsCd_tEdit.Location = new System.Drawing.Point(379, 41);
			this.RateMngGoodsCd_tEdit.MaxLength = 1;
			this.RateMngGoodsCd_tEdit.Name = "RateMngGoodsCd_tEdit";
			this.RateMngGoodsCd_tEdit.ReadOnly = true;
			this.RateMngGoodsCd_tEdit.Size = new System.Drawing.Size(20, 24);
			this.RateMngGoodsCd_tEdit.TabIndex = 5;
			this.RateMngGoodsCd_tEdit.TabStop = false;
			this.RateMngGoodsCd_tEdit.Text = "E";
			// 
			// RateMngCust_Label
			// 
			appearance11.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance11.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.RateMngCust_Label.Appearance = appearance11;
			this.RateMngCust_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.RateMngCust_Label.Location = new System.Drawing.Point(261, 70);
			this.RateMngCust_Label.Name = "RateMngCust_Label";
			this.RateMngCust_Label.Size = new System.Drawing.Size(111, 22);
			this.RateMngCust_Label.TabIndex = 1138;
			this.RateMngCust_Label.Text = "取引先設定区分";
			// 
			// RateMngGoods_Label
			// 
			appearance12.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance12.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.RateMngGoods_Label.Appearance = appearance12;
			this.RateMngGoods_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.RateMngGoods_Label.Location = new System.Drawing.Point(261, 42);
			this.RateMngGoods_Label.Name = "RateMngGoods_Label";
			this.RateMngGoods_Label.Size = new System.Drawing.Size(111, 22);
			this.RateMngGoods_Label.TabIndex = 1137;
			this.RateMngGoods_Label.Text = "商品設定区分";
			// 
			// RateSettingDivide_tEdit
			// 
			appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.RateSettingDivide_tEdit.ActiveAppearance = appearance13;
			appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.RateSettingDivide_tEdit.Appearance = appearance14;
			this.RateSettingDivide_tEdit.AutoSelect = true;
			this.RateSettingDivide_tEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.RateSettingDivide_tEdit.DataText = "";
			this.RateSettingDivide_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.RateSettingDivide_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
			this.RateSettingDivide_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.RateSettingDivide_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.RateSettingDivide_tEdit.Location = new System.Drawing.Point(378, 10);
			this.RateSettingDivide_tEdit.MaxLength = 2;
			this.RateSettingDivide_tEdit.Name = "RateSettingDivide_tEdit";
			this.RateSettingDivide_tEdit.Size = new System.Drawing.Size(28, 24);
			this.RateSettingDivide_tEdit.TabIndex = 3;
			// 
			// RateSettingDivide_Label
			// 
			appearance15.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance15.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.RateSettingDivide_Label.Appearance = appearance15;
			this.RateSettingDivide_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.RateSettingDivide_Label.Location = new System.Drawing.Point(261, 12);
			this.RateSettingDivide_Label.Name = "RateSettingDivide_Label";
			this.RateSettingDivide_Label.Size = new System.Drawing.Size(106, 22);
			this.RateSettingDivide_Label.TabIndex = 1135;
			this.RateSettingDivide_Label.Text = "掛率設定区分";
			// 
			// UnitPriceKindWay_tComboEditor
			// 
			appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.UnitPriceKindWay_tComboEditor.ActiveAppearance = appearance16;
			appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.UnitPriceKindWay_tComboEditor.Appearance = appearance17;
			this.UnitPriceKindWay_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.UnitPriceKindWay_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.UnitPriceKindWay_tComboEditor.ItemAppearance = appearance18;
			this.UnitPriceKindWay_tComboEditor.Location = new System.Drawing.Point(86, 68);
			this.UnitPriceKindWay_tComboEditor.Name = "UnitPriceKindWay_tComboEditor";
			this.UnitPriceKindWay_tComboEditor.Size = new System.Drawing.Size(153, 24);
			this.UnitPriceKindWay_tComboEditor.TabIndex = 2;
			this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);
			// 
			// UnitPriceKindWay_Label
			// 
			appearance19.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance19.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.UnitPriceKindWay_Label.Appearance = appearance19;
			this.UnitPriceKindWay_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.UnitPriceKindWay_Label.Location = new System.Drawing.Point(7, 68);
			this.UnitPriceKindWay_Label.Name = "UnitPriceKindWay_Label";
			this.UnitPriceKindWay_Label.Size = new System.Drawing.Size(73, 22);
			this.UnitPriceKindWay_Label.TabIndex = 1133;
			this.UnitPriceKindWay_Label.Text = "設定方法";
			// 
			// UnitPriceKind_tComboEditor
			// 
			appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.UnitPriceKind_tComboEditor.ActiveAppearance = appearance20;
			appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.UnitPriceKind_tComboEditor.Appearance = appearance21;
			this.UnitPriceKind_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.UnitPriceKind_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.UnitPriceKind_tComboEditor.ItemAppearance = appearance22;
			this.UnitPriceKind_tComboEditor.Location = new System.Drawing.Point(87, 10);
			this.UnitPriceKind_tComboEditor.Name = "UnitPriceKind_tComboEditor";
			this.UnitPriceKind_tComboEditor.Size = new System.Drawing.Size(152, 24);
			this.UnitPriceKind_tComboEditor.TabIndex = 1;
			this.UnitPriceKind_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
			// 
			// UnitPriceKind_Label
			// 
			appearance23.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance23.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.UnitPriceKind_Label.Appearance = appearance23;
			this.UnitPriceKind_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.UnitPriceKind_Label.Location = new System.Drawing.Point(7, 11);
			this.UnitPriceKind_Label.Name = "UnitPriceKind_Label";
			this.UnitPriceKind_Label.Size = new System.Drawing.Size(76, 21);
			this.UnitPriceKind_Label.TabIndex = 1131;
			this.UnitPriceKind_Label.Text = "単価種類";
			// 
			// DispDiv_uLabel
			// 
			appearance24.FontData.Name = "ＭＳ ゴシック";
			appearance24.FontData.SizeInPoints = 11.25F;
			appearance24.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.DispDiv_uLabel.Appearance = appearance24;
			this.DispDiv_uLabel.Location = new System.Drawing.Point(726, 10);
			this.DispDiv_uLabel.Name = "DispDiv_uLabel";
			this.DispDiv_uLabel.Size = new System.Drawing.Size(82, 23);
			this.DispDiv_uLabel.TabIndex = 85;
			this.DispDiv_uLabel.Text = "表示区分";
			// 
			// ultraExplorerBarContainerControl1
			// 
			this.ultraExplorerBarContainerControl1.Controls.Add(this.Single_panel);
			this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerInfo_Title_uLabel);
			this.ultraExplorerBarContainerControl1.Controls.Add(this.GoodsInfo_Title_uLabel);
			this.ultraExplorerBarContainerControl1.Controls.Add(this.Customer_panel);
			this.ultraExplorerBarContainerControl1.Controls.Add(this.Grp_panel);
			this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 192);
			this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
			this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(970, 397);
			this.ultraExplorerBarContainerControl1.TabIndex = 1;
			// 
			// Single_panel
			// 
			this.Single_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
			this.Single_panel.Controls.Add(this.GoodsMakerCd_uButton);
			this.Single_panel.Controls.Add(this.GoodsNo_uButton);
			this.Single_panel.Controls.Add(this.GoodsNoNm_tEdit);
			this.Single_panel.Controls.Add(this.GoodsNoCd_tEdit);
			this.Single_panel.Controls.Add(this.GoodsMakerCdNm_tEdit);
			this.Single_panel.Controls.Add(this.DetailGoodsGanreCode_Label);
			this.Single_panel.Controls.Add(this.GoodsMakerCd_tNedit);
			this.Single_panel.Controls.Add(this.GoodsMakerCd_Label);
			this.Single_panel.Location = new System.Drawing.Point(5, 45);
			this.Single_panel.Name = "Single_panel";
			this.Single_panel.Size = new System.Drawing.Size(479, 117);
			this.Single_panel.TabIndex = 1;
			// 
			// GoodsMakerCd_uButton
			// 
			appearance25.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance25.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.GoodsMakerCd_uButton.Appearance = appearance25;
			this.GoodsMakerCd_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.GoodsMakerCd_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.GoodsMakerCd_uButton.Location = new System.Drawing.Point(392, 7);
			this.GoodsMakerCd_uButton.Name = "GoodsMakerCd_uButton";
			this.GoodsMakerCd_uButton.Size = new System.Drawing.Size(24, 24);
			this.GoodsMakerCd_uButton.TabIndex = 22;
			this.GoodsMakerCd_uButton.Click += new System.EventHandler(this.GoodsMakerCd_uButton_Click);
			// 
			// GoodsNo_uButton
			// 
			appearance26.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance26.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.GoodsNo_uButton.Appearance = appearance26;
			this.GoodsNo_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.GoodsNo_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.GoodsNo_uButton.Location = new System.Drawing.Point(392, 67);
			this.GoodsNo_uButton.Name = "GoodsNo_uButton";
			this.GoodsNo_uButton.Size = new System.Drawing.Size(24, 24);
			this.GoodsNo_uButton.TabIndex = 25;
			this.GoodsNo_uButton.Click += new System.EventHandler(this.GoodsNo_uButton_Click);
			// 
			// GoodsNoNm_tEdit
			// 
			appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.GoodsNoNm_tEdit.ActiveAppearance = appearance27;
			appearance28.BackColor = System.Drawing.Color.Gainsboro;
			appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.GoodsNoNm_tEdit.Appearance = appearance28;
			this.GoodsNoNm_tEdit.AutoSelect = true;
			this.GoodsNoNm_tEdit.DataText = "";
			this.GoodsNoNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.GoodsNoNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 18, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.GoodsNoNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.GoodsNoNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.GoodsNoNm_tEdit.Location = new System.Drawing.Point(90, 67);
			this.GoodsNoNm_tEdit.MaxLength = 18;
			this.GoodsNoNm_tEdit.Name = "GoodsNoNm_tEdit";
			this.GoodsNoNm_tEdit.ReadOnly = true;
			this.GoodsNoNm_tEdit.Size = new System.Drawing.Size(299, 24);
			this.GoodsNoNm_tEdit.TabIndex = 24;
			this.GoodsNoNm_tEdit.TabStop = false;
			// 
			// GoodsNoCd_tEdit
			// 
			appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.GoodsNoCd_tEdit.ActiveAppearance = appearance29;
			this.GoodsNoCd_tEdit.AutoSelect = true;
			this.GoodsNoCd_tEdit.DataText = "0123456789012345678901234567890123456789";
			this.GoodsNoCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.GoodsNoCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
			this.GoodsNoCd_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.GoodsNoCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.GoodsNoCd_tEdit.Location = new System.Drawing.Point(90, 37);
			this.GoodsNoCd_tEdit.MaxLength = 40;
			this.GoodsNoCd_tEdit.Name = "GoodsNoCd_tEdit";
			this.GoodsNoCd_tEdit.Size = new System.Drawing.Size(330, 24);
			this.GoodsNoCd_tEdit.TabIndex = 23;
			this.GoodsNoCd_tEdit.Text = "0123456789012345678901234567890123456789";
			// 
			// GoodsMakerCdNm_tEdit
			// 
			appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.GoodsMakerCdNm_tEdit.ActiveAppearance = appearance30;
			appearance31.BackColor = System.Drawing.Color.Gainsboro;
			appearance31.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.GoodsMakerCdNm_tEdit.Appearance = appearance31;
			this.GoodsMakerCdNm_tEdit.AutoSelect = true;
			this.GoodsMakerCdNm_tEdit.DataText = "";
			this.GoodsMakerCdNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.GoodsMakerCdNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.GoodsMakerCdNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.GoodsMakerCdNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.GoodsMakerCdNm_tEdit.Location = new System.Drawing.Point(152, 7);
			this.GoodsMakerCdNm_tEdit.MaxLength = 14;
			this.GoodsMakerCdNm_tEdit.Name = "GoodsMakerCdNm_tEdit";
			this.GoodsMakerCdNm_tEdit.ReadOnly = true;
			this.GoodsMakerCdNm_tEdit.Size = new System.Drawing.Size(237, 24);
			this.GoodsMakerCdNm_tEdit.TabIndex = 21;
			this.GoodsMakerCdNm_tEdit.TabStop = false;
			// 
			// DetailGoodsGanreCode_Label
			// 
			appearance32.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance32.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.DetailGoodsGanreCode_Label.Appearance = appearance32;
			this.DetailGoodsGanreCode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.DetailGoodsGanreCode_Label.Location = new System.Drawing.Point(13, 38);
			this.DetailGoodsGanreCode_Label.Name = "DetailGoodsGanreCode_Label";
			this.DetailGoodsGanreCode_Label.Size = new System.Drawing.Size(72, 22);
			this.DetailGoodsGanreCode_Label.TabIndex = 136;
			this.DetailGoodsGanreCode_Label.Text = "商品ｺｰﾄﾞ";
			// 
			// GoodsMakerCd_tNedit
			// 
			appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.GoodsMakerCd_tNedit.ActiveAppearance = appearance33;
			appearance34.TextHAlign = Infragistics.Win.HAlign.Right;
			this.GoodsMakerCd_tNedit.Appearance = appearance34;
			this.GoodsMakerCd_tNedit.AutoSelect = true;
			this.GoodsMakerCd_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
			this.GoodsMakerCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.GoodsMakerCd_tNedit.DataText = "123456";
			this.GoodsMakerCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.GoodsMakerCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.GoodsMakerCd_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.GoodsMakerCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.GoodsMakerCd_tNedit.Location = new System.Drawing.Point(90, 7);
			this.GoodsMakerCd_tNedit.MaxLength = 6;
			this.GoodsMakerCd_tNedit.Name = "GoodsMakerCd_tNedit";
			this.GoodsMakerCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
			this.GoodsMakerCd_tNedit.Size = new System.Drawing.Size(59, 24);
			this.GoodsMakerCd_tNedit.TabIndex = 20;
			this.GoodsMakerCd_tNedit.Text = "123456";
			// 
			// GoodsMakerCd_Label
			// 
			appearance35.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance35.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.GoodsMakerCd_Label.Appearance = appearance35;
			this.GoodsMakerCd_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.GoodsMakerCd_Label.Location = new System.Drawing.Point(13, 9);
			this.GoodsMakerCd_Label.Name = "GoodsMakerCd_Label";
			this.GoodsMakerCd_Label.Size = new System.Drawing.Size(72, 22);
			this.GoodsMakerCd_Label.TabIndex = 138;
			this.GoodsMakerCd_Label.Text = "メーカー";
			// 
			// CustomerInfo_Title_uLabel
			// 
			appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			appearance36.BackColor2 = System.Drawing.Color.CornflowerBlue;
			appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance36.BorderColor = System.Drawing.Color.Blue;
			appearance36.FontData.BoldAsString = "True";
			appearance36.ForeColor = System.Drawing.Color.Black;
			appearance36.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance36.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.CustomerInfo_Title_uLabel.Appearance = appearance36;
			this.CustomerInfo_Title_uLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.CustomerInfo_Title_uLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
			this.CustomerInfo_Title_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.CustomerInfo_Title_uLabel.Location = new System.Drawing.Point(489, 14);
			this.CustomerInfo_Title_uLabel.Name = "CustomerInfo_Title_uLabel";
			this.CustomerInfo_Title_uLabel.Size = new System.Drawing.Size(478, 24);
			this.CustomerInfo_Title_uLabel.TabIndex = 1141;
			this.CustomerInfo_Title_uLabel.Text = "取引先情報";
			// 
			// GoodsInfo_Title_uLabel
			// 
			appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			appearance37.BackColor2 = System.Drawing.Color.CornflowerBlue;
			appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance37.BorderColor = System.Drawing.Color.Blue;
			appearance37.FontData.BoldAsString = "True";
			appearance37.ForeColor = System.Drawing.Color.Black;
			appearance37.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance37.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.GoodsInfo_Title_uLabel.Appearance = appearance37;
			this.GoodsInfo_Title_uLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.GoodsInfo_Title_uLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
			this.GoodsInfo_Title_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.GoodsInfo_Title_uLabel.Location = new System.Drawing.Point(5, 14);
			this.GoodsInfo_Title_uLabel.Name = "GoodsInfo_Title_uLabel";
			this.GoodsInfo_Title_uLabel.Size = new System.Drawing.Size(478, 24);
			this.GoodsInfo_Title_uLabel.TabIndex = 1140;
			this.GoodsInfo_Title_uLabel.Text = "商品情報";
			// 
			// Customer_panel
			// 
			this.Customer_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
			this.Customer_panel.Controls.Add(this.SupplierCd_uButton);
			this.Customer_panel.Controls.Add(this.SuppRateGrpCode_tComboEditor);
			this.Customer_panel.Controls.Add(this.SupplierCd_tNedit);
			this.Customer_panel.Controls.Add(this.CustRateGrpCode_tComboEditor);
			this.Customer_panel.Controls.Add(this.CustomerCodeNm_tEdit);
			this.Customer_panel.Controls.Add(this.SuppRateGrpCodeLabel);
			this.Customer_panel.Controls.Add(this.SupplierCd_Label);
			this.Customer_panel.Controls.Add(this.CustomerCode_tNedit);
			this.Customer_panel.Controls.Add(this.CustomerCode_uButton);
			this.Customer_panel.Controls.Add(this.SupplierCdNm_tEdit);
			this.Customer_panel.Controls.Add(this.CustomerCode_Label);
			this.Customer_panel.Controls.Add(this.CustRateGrpCode_Label);
			this.Customer_panel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.Customer_panel.Location = new System.Drawing.Point(489, 45);
			this.Customer_panel.Name = "Customer_panel";
			this.Customer_panel.Size = new System.Drawing.Size(478, 130);
			this.Customer_panel.TabIndex = 2;
			// 
			// SupplierCd_uButton
			// 
			appearance38.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance38.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.SupplierCd_uButton.Appearance = appearance38;
			this.SupplierCd_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.SupplierCd_uButton.Location = new System.Drawing.Point(434, 63);
			this.SupplierCd_uButton.Name = "SupplierCd_uButton";
			this.SupplierCd_uButton.Size = new System.Drawing.Size(24, 24);
			this.SupplierCd_uButton.TabIndex = 56;
			this.SupplierCd_uButton.Click += new System.EventHandler(this.SupplierCd_uButton_Click);
			// 
			// SuppRateGrpCode_tComboEditor
			// 
			appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.SuppRateGrpCode_tComboEditor.ActiveAppearance = appearance39;
			appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.SuppRateGrpCode_tComboEditor.Appearance = appearance40;
			this.SuppRateGrpCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.SuppRateGrpCode_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.SuppRateGrpCode_tComboEditor.ItemAppearance = appearance41;
			this.SuppRateGrpCode_tComboEditor.Location = new System.Drawing.Point(152, 93);
			this.SuppRateGrpCode_tComboEditor.Name = "SuppRateGrpCode_tComboEditor";
			this.SuppRateGrpCode_tComboEditor.Size = new System.Drawing.Size(280, 24);
			this.SuppRateGrpCode_tComboEditor.TabIndex = 1143;
			this.SuppRateGrpCode_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.SuppRateGrpCode_tComboEditor_SelectionChangeCommitted);
			// 
			// SupplierCd_tNedit
			// 
			appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.SupplierCd_tNedit.ActiveAppearance = appearance42;
			appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance43.TextHAlign = Infragistics.Win.HAlign.Right;
			this.SupplierCd_tNedit.Appearance = appearance43;
			this.SupplierCd_tNedit.AutoSelect = true;
			this.SupplierCd_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
			this.SupplierCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.SupplierCd_tNedit.DataText = "";
			this.SupplierCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.SupplierCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.SupplierCd_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.SupplierCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.SupplierCd_tNedit.Location = new System.Drawing.Point(152, 63);
			this.SupplierCd_tNedit.MaxLength = 9;
			this.SupplierCd_tNedit.Name = "SupplierCd_tNedit";
			this.SupplierCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
			this.SupplierCd_tNedit.Size = new System.Drawing.Size(82, 24);
			this.SupplierCd_tNedit.TabIndex = 54;
			// 
			// CustRateGrpCode_tComboEditor
			// 
			appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.CustRateGrpCode_tComboEditor.ActiveAppearance = appearance44;
			appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.CustRateGrpCode_tComboEditor.Appearance = appearance45;
			this.CustRateGrpCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.CustRateGrpCode_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.CustRateGrpCode_tComboEditor.ItemAppearance = appearance46;
			this.CustRateGrpCode_tComboEditor.Location = new System.Drawing.Point(152, 35);
			this.CustRateGrpCode_tComboEditor.Name = "CustRateGrpCode_tComboEditor";
			this.CustRateGrpCode_tComboEditor.Size = new System.Drawing.Size(280, 24);
			this.CustRateGrpCode_tComboEditor.TabIndex = 1142;
			this.CustRateGrpCode_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.CustRateGrpCode_tComboEditor_SelectionChangeCommitted);
			// 
			// CustomerCodeNm_tEdit
			// 
			appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.CustomerCodeNm_tEdit.ActiveAppearance = appearance47;
			appearance48.BackColor = System.Drawing.Color.Gainsboro;
			appearance48.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.CustomerCodeNm_tEdit.Appearance = appearance48;
			this.CustomerCodeNm_tEdit.AutoSelect = true;
			this.CustomerCodeNm_tEdit.DataText = "";
			this.CustomerCodeNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.CustomerCodeNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 11, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.CustomerCodeNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.CustomerCodeNm_tEdit.Location = new System.Drawing.Point(237, 4);
			this.CustomerCodeNm_tEdit.MaxLength = 11;
			this.CustomerCodeNm_tEdit.Name = "CustomerCodeNm_tEdit";
			this.CustomerCodeNm_tEdit.ReadOnly = true;
			this.CustomerCodeNm_tEdit.Size = new System.Drawing.Size(195, 24);
			this.CustomerCodeNm_tEdit.TabIndex = 51;
			this.CustomerCodeNm_tEdit.TabStop = false;
			// 
			// SuppRateGrpCodeLabel
			// 
			appearance49.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance49.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SuppRateGrpCodeLabel.Appearance = appearance49;
			this.SuppRateGrpCodeLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.SuppRateGrpCodeLabel.Location = new System.Drawing.Point(13, 93);
			this.SuppRateGrpCodeLabel.Name = "SuppRateGrpCodeLabel";
			this.SuppRateGrpCodeLabel.Size = new System.Drawing.Size(129, 22);
			this.SuppRateGrpCodeLabel.TabIndex = 173;
			this.SuppRateGrpCodeLabel.Text = "仕入先掛率ｸﾞﾙｰﾌﾟ";
			// 
			// SupplierCd_Label
			// 
			appearance50.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance50.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SupplierCd_Label.Appearance = appearance50;
			this.SupplierCd_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.SupplierCd_Label.Location = new System.Drawing.Point(13, 65);
			this.SupplierCd_Label.Name = "SupplierCd_Label";
			this.SupplierCd_Label.Size = new System.Drawing.Size(83, 22);
			this.SupplierCd_Label.TabIndex = 172;
			this.SupplierCd_Label.Text = "仕入先ｺｰﾄﾞ";
			// 
			// CustomerCode_tNedit
			// 
			appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.CustomerCode_tNedit.ActiveAppearance = appearance51;
			appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance52.TextHAlign = Infragistics.Win.HAlign.Right;
			this.CustomerCode_tNedit.Appearance = appearance52;
			this.CustomerCode_tNedit.AutoSelect = true;
			this.CustomerCode_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
			this.CustomerCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.CustomerCode_tNedit.DataText = "";
			this.CustomerCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.CustomerCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.CustomerCode_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.CustomerCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.CustomerCode_tNedit.Location = new System.Drawing.Point(152, 4);
			this.CustomerCode_tNedit.MaxLength = 9;
			this.CustomerCode_tNedit.Name = "CustomerCode_tNedit";
			this.CustomerCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
			this.CustomerCode_tNedit.Size = new System.Drawing.Size(82, 24);
			this.CustomerCode_tNedit.TabIndex = 50;
			// 
			// CustomerCode_uButton
			// 
			appearance53.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance53.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.CustomerCode_uButton.Appearance = appearance53;
			this.CustomerCode_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.CustomerCode_uButton.Location = new System.Drawing.Point(434, 3);
			this.CustomerCode_uButton.Name = "CustomerCode_uButton";
			this.CustomerCode_uButton.Size = new System.Drawing.Size(24, 24);
			this.CustomerCode_uButton.TabIndex = 52;
			this.CustomerCode_uButton.Click += new System.EventHandler(this.CustomerCode_uButton_Click);
			// 
			// SupplierCdNm_tEdit
			// 
			appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.SupplierCdNm_tEdit.ActiveAppearance = appearance54;
			appearance55.BackColor = System.Drawing.Color.Gainsboro;
			appearance55.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.SupplierCdNm_tEdit.Appearance = appearance55;
			this.SupplierCdNm_tEdit.AutoSelect = true;
			this.SupplierCdNm_tEdit.DataText = "";
			this.SupplierCdNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.SupplierCdNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 11, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.SupplierCdNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.SupplierCdNm_tEdit.Location = new System.Drawing.Point(237, 63);
			this.SupplierCdNm_tEdit.MaxLength = 11;
			this.SupplierCdNm_tEdit.Name = "SupplierCdNm_tEdit";
			this.SupplierCdNm_tEdit.ReadOnly = true;
			this.SupplierCdNm_tEdit.Size = new System.Drawing.Size(195, 24);
			this.SupplierCdNm_tEdit.TabIndex = 55;
			this.SupplierCdNm_tEdit.TabStop = false;
			// 
			// CustomerCode_Label
			// 
			appearance56.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance56.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.CustomerCode_Label.Appearance = appearance56;
			this.CustomerCode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.CustomerCode_Label.Location = new System.Drawing.Point(13, 10);
			this.CustomerCode_Label.Name = "CustomerCode_Label";
			this.CustomerCode_Label.Size = new System.Drawing.Size(98, 22);
			this.CustomerCode_Label.TabIndex = 136;
			this.CustomerCode_Label.Text = "得意先ｺｰﾄﾞ";
			// 
			// CustRateGrpCode_Label
			// 
			appearance57.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance57.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.CustRateGrpCode_Label.Appearance = appearance57;
			this.CustRateGrpCode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.CustRateGrpCode_Label.Location = new System.Drawing.Point(13, 36);
			this.CustRateGrpCode_Label.Name = "CustRateGrpCode_Label";
			this.CustRateGrpCode_Label.Size = new System.Drawing.Size(129, 22);
			this.CustRateGrpCode_Label.TabIndex = 138;
			this.CustRateGrpCode_Label.Text = "得意先掛率ｸﾞﾙｰﾌﾟ";
			// 
			// Grp_panel
			// 
			this.Grp_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
			this.Grp_panel.Controls.Add(this.EnterpriseGanreCode_Grp_tComboEditor);
			this.Grp_panel.Controls.Add(this.DetailGoodsGanreCode_Grp_uButton);
			this.Grp_panel.Controls.Add(this.MediumGoodsGanreCode_Grp_uButton);
			this.Grp_panel.Controls.Add(this.LargeGoodsGanreCode_Grp_uButton);
			this.Grp_panel.Controls.Add(this.DetailGoodsGanreCodeNm_Grp_tEdit);
			this.Grp_panel.Controls.Add(this.MediumGoodsGanreCodeNm_Grp_tEdit);
			this.Grp_panel.Controls.Add(this.LargeGoodsGanreCodeNm_Grp_tEdit);
			this.Grp_panel.Controls.Add(this.DetailGoodsGanreCode_Grp_tEdit);
			this.Grp_panel.Controls.Add(this.MediumGoodsGanreCode_Grp_tEdit);
			this.Grp_panel.Controls.Add(this.LargeGoodsGanreCode_Grp_tEdit);
			this.Grp_panel.Controls.Add(this.GoodsRateRankCd_Grp_tEdit);
			this.Grp_panel.Controls.Add(this.BLGoodsCode_Grp_uButton);
			this.Grp_panel.Controls.Add(this.BLGoodsCodeNm_Grp_tEdit);
			this.Grp_panel.Controls.Add(this.BLGoodsCode_Grp_tNedit);
			this.Grp_panel.Controls.Add(this.BLGoodsCode_Grp_Label);
			this.Grp_panel.Controls.Add(this.EnterpriseGanreCode_Grp_Label);
			this.Grp_panel.Controls.Add(this.DetailGoodsGanreCode_Grp_Label);
			this.Grp_panel.Controls.Add(this.MediumGoodsGanreCode_Grp_Label);
			this.Grp_panel.Controls.Add(this.LargeGoodsGanreCode_Grp_Label);
			this.Grp_panel.Controls.Add(this.GoodsMakerCd_Grp_uButton);
			this.Grp_panel.Controls.Add(this.GoodsMakerCdNm_Grp_tEdit);
			this.Grp_panel.Controls.Add(this.GoodsMakerCd_Grp_tNedit);
			this.Grp_panel.Controls.Add(this.GoodsRateRank_Grp_Label);
			this.Grp_panel.Controls.Add(this.GoodsMakerCd_Grp_Label);
			this.Grp_panel.Location = new System.Drawing.Point(5, 45);
			this.Grp_panel.Name = "Grp_panel";
			this.Grp_panel.Size = new System.Drawing.Size(469, 206);
			this.Grp_panel.TabIndex = 1;
			// 
			// EnterpriseGanreCode_Grp_tComboEditor
			// 
			appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EnterpriseGanreCode_Grp_tComboEditor.ActiveAppearance = appearance58;
			this.EnterpriseGanreCode_Grp_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.EnterpriseGanreCode_Grp_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EnterpriseGanreCode_Grp_tComboEditor.ItemAppearance = appearance59;
			this.EnterpriseGanreCode_Grp_tComboEditor.Location = new System.Drawing.Point(185, 136);
			this.EnterpriseGanreCode_Grp_tComboEditor.Name = "EnterpriseGanreCode_Grp_tComboEditor";
			this.EnterpriseGanreCode_Grp_tComboEditor.Size = new System.Drawing.Size(144, 24);
			this.EnterpriseGanreCode_Grp_tComboEditor.TabIndex = 43;
			this.EnterpriseGanreCode_Grp_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.EnterpriseGanreCode_Grp_tComboEditor_SelectionChangeCommitted);
			// 
			// DetailGoodsGanreCode_Grp_uButton
			// 
			appearance60.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance60.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.DetailGoodsGanreCode_Grp_uButton.Appearance = appearance60;
			this.DetailGoodsGanreCode_Grp_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.DetailGoodsGanreCode_Grp_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.DetailGoodsGanreCode_Grp_uButton.Location = new System.Drawing.Point(423, 110);
			this.DetailGoodsGanreCode_Grp_uButton.Name = "DetailGoodsGanreCode_Grp_uButton";
			this.DetailGoodsGanreCode_Grp_uButton.Size = new System.Drawing.Size(24, 24);
			this.DetailGoodsGanreCode_Grp_uButton.TabIndex = 42;
			this.DetailGoodsGanreCode_Grp_uButton.Click += new System.EventHandler(this.DetailGoodsGanreCode_Grp_uButton_Click);
			// 
			// MediumGoodsGanreCode_Grp_uButton
			// 
			appearance61.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance61.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.MediumGoodsGanreCode_Grp_uButton.Appearance = appearance61;
			this.MediumGoodsGanreCode_Grp_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MediumGoodsGanreCode_Grp_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.MediumGoodsGanreCode_Grp_uButton.Location = new System.Drawing.Point(423, 82);
			this.MediumGoodsGanreCode_Grp_uButton.Name = "MediumGoodsGanreCode_Grp_uButton";
			this.MediumGoodsGanreCode_Grp_uButton.Size = new System.Drawing.Size(24, 24);
			this.MediumGoodsGanreCode_Grp_uButton.TabIndex = 39;
			this.MediumGoodsGanreCode_Grp_uButton.Click += new System.EventHandler(this.MediumGoodsGanreCode_Grp_uButton_Click);
			// 
			// LargeGoodsGanreCode_Grp_uButton
			// 
			appearance62.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance62.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.LargeGoodsGanreCode_Grp_uButton.Appearance = appearance62;
			this.LargeGoodsGanreCode_Grp_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LargeGoodsGanreCode_Grp_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.LargeGoodsGanreCode_Grp_uButton.Location = new System.Drawing.Point(423, 57);
			this.LargeGoodsGanreCode_Grp_uButton.Name = "LargeGoodsGanreCode_Grp_uButton";
			this.LargeGoodsGanreCode_Grp_uButton.Size = new System.Drawing.Size(24, 24);
			this.LargeGoodsGanreCode_Grp_uButton.TabIndex = 36;
			this.LargeGoodsGanreCode_Grp_uButton.Click += new System.EventHandler(this.LargeGoodsGanreCode_Grp_uButton_Click);
			// 
			// DetailGoodsGanreCodeNm_Grp_tEdit
			// 
			appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.DetailGoodsGanreCodeNm_Grp_tEdit.ActiveAppearance = appearance63;
			appearance64.BackColor = System.Drawing.Color.Gainsboro;
			appearance64.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.DetailGoodsGanreCodeNm_Grp_tEdit.Appearance = appearance64;
			this.DetailGoodsGanreCodeNm_Grp_tEdit.AutoSelect = true;
			this.DetailGoodsGanreCodeNm_Grp_tEdit.DataText = "";
			this.DetailGoodsGanreCodeNm_Grp_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.DetailGoodsGanreCodeNm_Grp_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.DetailGoodsGanreCodeNm_Grp_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.DetailGoodsGanreCodeNm_Grp_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.DetailGoodsGanreCodeNm_Grp_tEdit.Location = new System.Drawing.Point(277, 110);
			this.DetailGoodsGanreCodeNm_Grp_tEdit.MaxLength = 8;
			this.DetailGoodsGanreCodeNm_Grp_tEdit.Name = "DetailGoodsGanreCodeNm_Grp_tEdit";
			this.DetailGoodsGanreCodeNm_Grp_tEdit.ReadOnly = true;
			this.DetailGoodsGanreCodeNm_Grp_tEdit.Size = new System.Drawing.Size(144, 24);
			this.DetailGoodsGanreCodeNm_Grp_tEdit.TabIndex = 41;
			this.DetailGoodsGanreCodeNm_Grp_tEdit.TabStop = false;
			// 
			// MediumGoodsGanreCodeNm_Grp_tEdit
			// 
			appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.MediumGoodsGanreCodeNm_Grp_tEdit.ActiveAppearance = appearance65;
			appearance66.BackColor = System.Drawing.Color.Gainsboro;
			appearance66.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.MediumGoodsGanreCodeNm_Grp_tEdit.Appearance = appearance66;
			this.MediumGoodsGanreCodeNm_Grp_tEdit.AutoSelect = true;
			this.MediumGoodsGanreCodeNm_Grp_tEdit.DataText = "";
			this.MediumGoodsGanreCodeNm_Grp_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.MediumGoodsGanreCodeNm_Grp_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.MediumGoodsGanreCodeNm_Grp_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MediumGoodsGanreCodeNm_Grp_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.MediumGoodsGanreCodeNm_Grp_tEdit.Location = new System.Drawing.Point(261, 83);
			this.MediumGoodsGanreCodeNm_Grp_tEdit.MaxLength = 8;
			this.MediumGoodsGanreCodeNm_Grp_tEdit.Name = "MediumGoodsGanreCodeNm_Grp_tEdit";
			this.MediumGoodsGanreCodeNm_Grp_tEdit.ReadOnly = true;
			this.MediumGoodsGanreCodeNm_Grp_tEdit.Size = new System.Drawing.Size(160, 24);
			this.MediumGoodsGanreCodeNm_Grp_tEdit.TabIndex = 38;
			this.MediumGoodsGanreCodeNm_Grp_tEdit.TabStop = false;
			// 
			// LargeGoodsGanreCodeNm_Grp_tEdit
			// 
			appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.LargeGoodsGanreCodeNm_Grp_tEdit.ActiveAppearance = appearance67;
			appearance68.BackColor = System.Drawing.Color.Gainsboro;
			appearance68.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.LargeGoodsGanreCodeNm_Grp_tEdit.Appearance = appearance68;
			this.LargeGoodsGanreCodeNm_Grp_tEdit.AutoSelect = true;
			this.LargeGoodsGanreCodeNm_Grp_tEdit.DataText = "";
			this.LargeGoodsGanreCodeNm_Grp_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.LargeGoodsGanreCodeNm_Grp_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.LargeGoodsGanreCodeNm_Grp_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LargeGoodsGanreCodeNm_Grp_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.LargeGoodsGanreCodeNm_Grp_tEdit.Location = new System.Drawing.Point(261, 56);
			this.LargeGoodsGanreCodeNm_Grp_tEdit.MaxLength = 8;
			this.LargeGoodsGanreCodeNm_Grp_tEdit.Name = "LargeGoodsGanreCodeNm_Grp_tEdit";
			this.LargeGoodsGanreCodeNm_Grp_tEdit.ReadOnly = true;
			this.LargeGoodsGanreCodeNm_Grp_tEdit.Size = new System.Drawing.Size(160, 24);
			this.LargeGoodsGanreCodeNm_Grp_tEdit.TabIndex = 35;
			this.LargeGoodsGanreCodeNm_Grp_tEdit.TabStop = false;
			// 
			// DetailGoodsGanreCode_Grp_tEdit
			// 
			appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.DetailGoodsGanreCode_Grp_tEdit.ActiveAppearance = appearance69;
			this.DetailGoodsGanreCode_Grp_tEdit.AutoSelect = true;
			this.DetailGoodsGanreCode_Grp_tEdit.DataText = "1234567890";
			this.DetailGoodsGanreCode_Grp_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.DetailGoodsGanreCode_Grp_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
			this.DetailGoodsGanreCode_Grp_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.DetailGoodsGanreCode_Grp_tEdit.Location = new System.Drawing.Point(185, 110);
			this.DetailGoodsGanreCode_Grp_tEdit.MaxLength = 10;
			this.DetailGoodsGanreCode_Grp_tEdit.Name = "DetailGoodsGanreCode_Grp_tEdit";
			this.DetailGoodsGanreCode_Grp_tEdit.Size = new System.Drawing.Size(90, 24);
			this.DetailGoodsGanreCode_Grp_tEdit.TabIndex = 40;
			this.DetailGoodsGanreCode_Grp_tEdit.Text = "1234567890";
			// 
			// MediumGoodsGanreCode_Grp_tEdit
			// 
			appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.MediumGoodsGanreCode_Grp_tEdit.ActiveAppearance = appearance70;
			this.MediumGoodsGanreCode_Grp_tEdit.AutoSelect = true;
			this.MediumGoodsGanreCode_Grp_tEdit.DataText = "12345";
			this.MediumGoodsGanreCode_Grp_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.MediumGoodsGanreCode_Grp_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
			this.MediumGoodsGanreCode_Grp_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.MediumGoodsGanreCode_Grp_tEdit.Location = new System.Drawing.Point(185, 83);
			this.MediumGoodsGanreCode_Grp_tEdit.MaxLength = 5;
			this.MediumGoodsGanreCode_Grp_tEdit.Name = "MediumGoodsGanreCode_Grp_tEdit";
			this.MediumGoodsGanreCode_Grp_tEdit.Size = new System.Drawing.Size(74, 24);
			this.MediumGoodsGanreCode_Grp_tEdit.TabIndex = 37;
			this.MediumGoodsGanreCode_Grp_tEdit.Text = "12345";
			// 
			// LargeGoodsGanreCode_Grp_tEdit
			// 
			appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.LargeGoodsGanreCode_Grp_tEdit.ActiveAppearance = appearance71;
			this.LargeGoodsGanreCode_Grp_tEdit.AutoSelect = true;
			this.LargeGoodsGanreCode_Grp_tEdit.DataText = "123456";
			this.LargeGoodsGanreCode_Grp_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.LargeGoodsGanreCode_Grp_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
			this.LargeGoodsGanreCode_Grp_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.LargeGoodsGanreCode_Grp_tEdit.Location = new System.Drawing.Point(185, 57);
			this.LargeGoodsGanreCode_Grp_tEdit.MaxLength = 5;
			this.LargeGoodsGanreCode_Grp_tEdit.Name = "LargeGoodsGanreCode_Grp_tEdit";
			this.LargeGoodsGanreCode_Grp_tEdit.Size = new System.Drawing.Size(74, 24);
			this.LargeGoodsGanreCode_Grp_tEdit.TabIndex = 34;
			this.LargeGoodsGanreCode_Grp_tEdit.Text = "123456";
			// 
			// GoodsRateRankCd_Grp_tEdit
			// 
			appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.GoodsRateRankCd_Grp_tEdit.ActiveAppearance = appearance72;
			this.GoodsRateRankCd_Grp_tEdit.AutoSelect = true;
			this.GoodsRateRankCd_Grp_tEdit.DataText = "";
			this.GoodsRateRankCd_Grp_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.GoodsRateRankCd_Grp_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
			this.GoodsRateRankCd_Grp_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.GoodsRateRankCd_Grp_tEdit.Location = new System.Drawing.Point(185, 32);
			this.GoodsRateRankCd_Grp_tEdit.MaxLength = 6;
			this.GoodsRateRankCd_Grp_tEdit.Name = "GoodsRateRankCd_Grp_tEdit";
			this.GoodsRateRankCd_Grp_tEdit.Size = new System.Drawing.Size(74, 24);
			this.GoodsRateRankCd_Grp_tEdit.TabIndex = 33;
			// 
			// BLGoodsCode_Grp_uButton
			// 
			appearance73.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance73.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.BLGoodsCode_Grp_uButton.Appearance = appearance73;
			this.BLGoodsCode_Grp_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BLGoodsCode_Grp_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.BLGoodsCode_Grp_uButton.Location = new System.Drawing.Point(407, 162);
			this.BLGoodsCode_Grp_uButton.Name = "BLGoodsCode_Grp_uButton";
			this.BLGoodsCode_Grp_uButton.Size = new System.Drawing.Size(24, 24);
			this.BLGoodsCode_Grp_uButton.TabIndex = 46;
			this.BLGoodsCode_Grp_uButton.Click += new System.EventHandler(this.BLGoodsCode_Grp_uButton_Click);
			// 
			// BLGoodsCodeNm_Grp_tEdit
			// 
			appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.BLGoodsCodeNm_Grp_tEdit.ActiveAppearance = appearance74;
			appearance75.BackColor = System.Drawing.Color.Gainsboro;
			appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.BLGoodsCodeNm_Grp_tEdit.Appearance = appearance75;
			this.BLGoodsCodeNm_Grp_tEdit.AutoSelect = true;
			this.BLGoodsCodeNm_Grp_tEdit.DataText = "";
			this.BLGoodsCodeNm_Grp_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.BLGoodsCodeNm_Grp_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.BLGoodsCodeNm_Grp_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.BLGoodsCodeNm_Grp_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.BLGoodsCodeNm_Grp_tEdit.Location = new System.Drawing.Point(261, 162);
			this.BLGoodsCodeNm_Grp_tEdit.MaxLength = 8;
			this.BLGoodsCodeNm_Grp_tEdit.Name = "BLGoodsCodeNm_Grp_tEdit";
			this.BLGoodsCodeNm_Grp_tEdit.ReadOnly = true;
			this.BLGoodsCodeNm_Grp_tEdit.Size = new System.Drawing.Size(144, 24);
			this.BLGoodsCodeNm_Grp_tEdit.TabIndex = 45;
			this.BLGoodsCodeNm_Grp_tEdit.TabStop = false;
			// 
			// BLGoodsCode_Grp_tNedit
			// 
			appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.BLGoodsCode_Grp_tNedit.ActiveAppearance = appearance76;
			appearance77.TextHAlign = Infragistics.Win.HAlign.Right;
			this.BLGoodsCode_Grp_tNedit.Appearance = appearance77;
			this.BLGoodsCode_Grp_tNedit.AutoSelect = true;
			this.BLGoodsCode_Grp_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
			this.BLGoodsCode_Grp_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.BLGoodsCode_Grp_tNedit.DataText = "";
			this.BLGoodsCode_Grp_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.BLGoodsCode_Grp_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.BLGoodsCode_Grp_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.BLGoodsCode_Grp_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.BLGoodsCode_Grp_tNedit.Location = new System.Drawing.Point(185, 162);
			this.BLGoodsCode_Grp_tNedit.MaxLength = 8;
			this.BLGoodsCode_Grp_tNedit.Name = "BLGoodsCode_Grp_tNedit";
			this.BLGoodsCode_Grp_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
			this.BLGoodsCode_Grp_tNedit.Size = new System.Drawing.Size(74, 24);
			this.BLGoodsCode_Grp_tNedit.TabIndex = 44;
			// 
			// BLGoodsCode_Grp_Label
			// 
			appearance78.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance78.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.BLGoodsCode_Grp_Label.Appearance = appearance78;
			this.BLGoodsCode_Grp_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.BLGoodsCode_Grp_Label.Location = new System.Drawing.Point(13, 160);
			this.BLGoodsCode_Grp_Label.Name = "BLGoodsCode_Grp_Label";
			this.BLGoodsCode_Grp_Label.Size = new System.Drawing.Size(137, 22);
			this.BLGoodsCode_Grp_Label.TabIndex = 177;
			this.BLGoodsCode_Grp_Label.Text = "BL商品ｺｰﾄﾞ";
			// 
			// EnterpriseGanreCode_Grp_Label
			// 
			appearance79.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance79.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.EnterpriseGanreCode_Grp_Label.Appearance = appearance79;
			this.EnterpriseGanreCode_Grp_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.EnterpriseGanreCode_Grp_Label.Location = new System.Drawing.Point(13, 137);
			this.EnterpriseGanreCode_Grp_Label.Name = "EnterpriseGanreCode_Grp_Label";
			this.EnterpriseGanreCode_Grp_Label.Size = new System.Drawing.Size(139, 22);
			this.EnterpriseGanreCode_Grp_Label.TabIndex = 176;
			this.EnterpriseGanreCode_Grp_Label.Text = "自社分類ｺｰﾄﾞ";
			// 
			// DetailGoodsGanreCode_Grp_Label
			// 
			appearance80.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance80.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.DetailGoodsGanreCode_Grp_Label.Appearance = appearance80;
			this.DetailGoodsGanreCode_Grp_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.DetailGoodsGanreCode_Grp_Label.Location = new System.Drawing.Point(13, 110);
			this.DetailGoodsGanreCode_Grp_Label.Name = "DetailGoodsGanreCode_Grp_Label";
			this.DetailGoodsGanreCode_Grp_Label.Size = new System.Drawing.Size(139, 22);
			this.DetailGoodsGanreCode_Grp_Label.TabIndex = 175;
			this.DetailGoodsGanreCode_Grp_Label.Text = "商品区分詳細ｺｰﾄﾞ";
			// 
			// MediumGoodsGanreCode_Grp_Label
			// 
			appearance81.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance81.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.MediumGoodsGanreCode_Grp_Label.Appearance = appearance81;
			this.MediumGoodsGanreCode_Grp_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.MediumGoodsGanreCode_Grp_Label.Location = new System.Drawing.Point(13, 82);
			this.MediumGoodsGanreCode_Grp_Label.Name = "MediumGoodsGanreCode_Grp_Label";
			this.MediumGoodsGanreCode_Grp_Label.Size = new System.Drawing.Size(139, 22);
			this.MediumGoodsGanreCode_Grp_Label.TabIndex = 174;
			this.MediumGoodsGanreCode_Grp_Label.Text = "商品区分ｺｰﾄﾞ";
			// 
			// LargeGoodsGanreCode_Grp_Label
			// 
			appearance82.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance82.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.LargeGoodsGanreCode_Grp_Label.Appearance = appearance82;
			this.LargeGoodsGanreCode_Grp_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.LargeGoodsGanreCode_Grp_Label.Location = new System.Drawing.Point(13, 57);
			this.LargeGoodsGanreCode_Grp_Label.Name = "LargeGoodsGanreCode_Grp_Label";
			this.LargeGoodsGanreCode_Grp_Label.Size = new System.Drawing.Size(166, 22);
			this.LargeGoodsGanreCode_Grp_Label.TabIndex = 173;
			this.LargeGoodsGanreCode_Grp_Label.Text = "商品区分ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
			// 
			// GoodsMakerCd_Grp_uButton
			// 
			appearance83.ImageHAlign = Infragistics.Win.HAlign.Center;
			appearance83.ImageVAlign = Infragistics.Win.VAlign.Middle;
			this.GoodsMakerCd_Grp_uButton.Appearance = appearance83;
			this.GoodsMakerCd_Grp_uButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.GoodsMakerCd_Grp_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.GoodsMakerCd_Grp_uButton.Location = new System.Drawing.Point(423, 6);
			this.GoodsMakerCd_Grp_uButton.Name = "GoodsMakerCd_Grp_uButton";
			this.GoodsMakerCd_Grp_uButton.Size = new System.Drawing.Size(24, 24);
			this.GoodsMakerCd_Grp_uButton.TabIndex = 32;
			this.GoodsMakerCd_Grp_uButton.Click += new System.EventHandler(this.GoodsMakerCd_Grp_uButton_Click);
			// 
			// GoodsMakerCdNm_Grp_tEdit
			// 
			appearance84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.GoodsMakerCdNm_Grp_tEdit.ActiveAppearance = appearance84;
			appearance85.BackColor = System.Drawing.Color.Gainsboro;
			appearance85.BackColorDisabled = System.Drawing.SystemColors.Control;
			this.GoodsMakerCdNm_Grp_tEdit.Appearance = appearance85;
			this.GoodsMakerCdNm_Grp_tEdit.AutoSelect = true;
			this.GoodsMakerCdNm_Grp_tEdit.DataText = "";
			this.GoodsMakerCdNm_Grp_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.GoodsMakerCdNm_Grp_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.GoodsMakerCdNm_Grp_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.GoodsMakerCdNm_Grp_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.GoodsMakerCdNm_Grp_tEdit.Location = new System.Drawing.Point(261, 7);
			this.GoodsMakerCdNm_Grp_tEdit.MaxLength = 8;
			this.GoodsMakerCdNm_Grp_tEdit.Name = "GoodsMakerCdNm_Grp_tEdit";
			this.GoodsMakerCdNm_Grp_tEdit.ReadOnly = true;
			this.GoodsMakerCdNm_Grp_tEdit.Size = new System.Drawing.Size(160, 24);
			this.GoodsMakerCdNm_Grp_tEdit.TabIndex = 31;
			this.GoodsMakerCdNm_Grp_tEdit.TabStop = false;
			// 
			// GoodsMakerCd_Grp_tNedit
			// 
			appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.GoodsMakerCd_Grp_tNedit.ActiveAppearance = appearance86;
			appearance87.TextHAlign = Infragistics.Win.HAlign.Right;
			this.GoodsMakerCd_Grp_tNedit.Appearance = appearance87;
			this.GoodsMakerCd_Grp_tNedit.AutoSelect = true;
			this.GoodsMakerCd_Grp_tNedit.CalcDisp = Broadleaf.Library.Windows.Forms.emCalcDisp.nclcNone;
			this.GoodsMakerCd_Grp_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.GoodsMakerCd_Grp_tNedit.DataText = "123456";
			this.GoodsMakerCd_Grp_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.GoodsMakerCd_Grp_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.GoodsMakerCd_Grp_tNedit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.GoodsMakerCd_Grp_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.GoodsMakerCd_Grp_tNedit.Location = new System.Drawing.Point(185, 7);
			this.GoodsMakerCd_Grp_tNedit.MaxLength = 6;
			this.GoodsMakerCd_Grp_tNedit.Name = "GoodsMakerCd_Grp_tNedit";
			this.GoodsMakerCd_Grp_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
			this.GoodsMakerCd_Grp_tNedit.Size = new System.Drawing.Size(74, 24);
			this.GoodsMakerCd_Grp_tNedit.TabIndex = 30;
			this.GoodsMakerCd_Grp_tNedit.Text = "123456";
			// 
			// GoodsRateRank_Grp_Label
			// 
			appearance88.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance88.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.GoodsRateRank_Grp_Label.Appearance = appearance88;
			this.GoodsRateRank_Grp_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.GoodsRateRank_Grp_Label.Location = new System.Drawing.Point(13, 32);
			this.GoodsRateRank_Grp_Label.Name = "GoodsRateRank_Grp_Label";
			this.GoodsRateRank_Grp_Label.Size = new System.Drawing.Size(139, 22);
			this.GoodsRateRank_Grp_Label.TabIndex = 136;
			this.GoodsRateRank_Grp_Label.Text = "商品掛率ﾗﾝｸ(層別)";
			// 
			// GoodsMakerCd_Grp_Label
			// 
			appearance89.TextHAlign = Infragistics.Win.HAlign.Left;
			appearance89.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.GoodsMakerCd_Grp_Label.Appearance = appearance89;
			this.GoodsMakerCd_Grp_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
			this.GoodsMakerCd_Grp_Label.Location = new System.Drawing.Point(13, 8);
			this.GoodsMakerCd_Grp_Label.Name = "GoodsMakerCd_Grp_Label";
			this.GoodsMakerCd_Grp_Label.Size = new System.Drawing.Size(139, 22);
			this.GoodsMakerCd_Grp_Label.TabIndex = 138;
			this.GoodsMakerCd_Grp_Label.Text = "メーカー";
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
			// Main_ultraExplorerBar
			// 
			this.Main_ultraExplorerBar.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
			appearance90.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			appearance90.FontData.Name = "ＭＳ ゴシック";
			appearance90.FontData.SizeInPoints = 11.25F;
			this.Main_ultraExplorerBar.Appearance = appearance90;
			this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
			this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
			this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl2);
			this.Main_ultraExplorerBar.Dock = System.Windows.Forms.DockStyle.Fill;
			ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl2;
			ultraExplorerBarGroup1.Key = "ViewConditionGroup";
			appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance91;
			ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
			ultraExplorerBarGroup1.Settings.ContainerHeight = 108;
			ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
			ultraExplorerBarGroup1.Text = "表示条件";
			ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl1;
			ultraExplorerBarGroup2.Key = "CustomerConditionGroup";
			appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance92;
			ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
			ultraExplorerBarGroup2.Settings.ContainerHeight = 399;
			ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
			ultraExplorerBarGroup2.Text = "抽出条件";
			this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2});
			this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
			this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
			appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			appearance93.BackColor2 = System.Drawing.Color.CornflowerBlue;
			appearance93.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			appearance93.Cursor = System.Windows.Forms.Cursors.Default;
			this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance93;
			appearance94.Cursor = System.Windows.Forms.Cursors.Default;
			this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance94;
			this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
			this.Main_ultraExplorerBar.GroupSpacing = 6;
			this.Main_ultraExplorerBar.Location = new System.Drawing.Point(0, 0);
			this.Main_ultraExplorerBar.Name = "Main_ultraExplorerBar";
			this.Main_ultraExplorerBar.ShowDefaultContextMenu = false;
			this.Main_ultraExplorerBar.Size = new System.Drawing.Size(1006, 614);
			this.Main_ultraExplorerBar.TabIndex = 4;
			this.Main_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
			this.Main_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing);
			this.Main_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Main_ultraExplorerBar_GroupExpanding);
			// 
			// ultraExplorerBarContainerControl3
			// 
			this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraOptionSet2);
			this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraOptionSet3);
			this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraTree2);
			this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(17, 233);
			this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
			this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(953, 0);
			this.ultraExplorerBarContainerControl3.TabIndex = 0;
			this.ultraExplorerBarContainerControl3.Visible = false;
			// 
			// ultraOptionSet2
			// 
			this.ultraOptionSet2.ItemAppearance = appearance95;
			this.ultraOptionSet2.Location = new System.Drawing.Point(0, 0);
			this.ultraOptionSet2.Name = "ultraOptionSet2";
			this.ultraOptionSet2.Size = new System.Drawing.Size(96, 32);
			this.ultraOptionSet2.TabIndex = 0;
			// 
			// ultraOptionSet3
			// 
			this.ultraOptionSet3.ItemAppearance = appearance96;
			this.ultraOptionSet3.Location = new System.Drawing.Point(0, 0);
			this.ultraOptionSet3.Name = "ultraOptionSet3";
			this.ultraOptionSet3.Size = new System.Drawing.Size(96, 32);
			this.ultraOptionSet3.TabIndex = 1;
			// 
			// ultraTree2
			// 
			this.ultraTree2.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
			this.ultraTree2.Location = new System.Drawing.Point(0, 0);
			this.ultraTree2.Name = "ultraTree2";
			this.ultraTree2.Size = new System.Drawing.Size(121, 97);
			this.ultraTree2.TabIndex = 2;
			// 
			// ultraExplorerBarContainerControl4
			// 
			this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(17, 45);
			this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
			this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(972, 150);
			this.ultraExplorerBarContainerControl4.TabIndex = 1;
			// 
			// tm_InitialTimer
			// 
			this.tm_InitialTimer.Interval = 1;
			this.tm_InitialTimer.Tick += new System.EventHandler(this.tm_InitialTimer_Tick);
			// 
			// ultraToolTipManager1
			// 
			this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
			// 
			// uiSetControl1
			// 
			this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
			this.uiSetControl1.OwnerForm = this;
			this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
			// 
			// DCKHN09180UA
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.ClientSize = new System.Drawing.Size(1006, 614);
			this.Controls.Add(this.Main_ultraExplorerBar);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "DCKHN09180UA";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.DCKHN09180UA_Load);
			this.ultraExplorerBarContainerControl2.ResumeLayout(false);
			this.ultraExplorerBarContainerControl2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DispDiv_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RateMngCustNm_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RateMngGoodsNm_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RateMngCustCd_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RateMngGoodsCd_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RateSettingDivide_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UnitPriceKindWay_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UnitPriceKind_tComboEditor)).EndInit();
			this.ultraExplorerBarContainerControl1.ResumeLayout(false);
			this.Single_panel.ResumeLayout(false);
			this.Single_panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.GoodsNoNm_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsNoCd_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCdNm_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_tNedit)).EndInit();
			this.Customer_panel.ResumeLayout(false);
			this.Customer_panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SuppRateGrpCode_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SupplierCd_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CustRateGrpCode_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CustomerCodeNm_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CustomerCode_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SupplierCdNm_tEdit)).EndInit();
			this.Grp_panel.ResumeLayout(false);
			this.Grp_panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.EnterpriseGanreCode_Grp_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DetailGoodsGanreCodeNm_Grp_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MediumGoodsGanreCodeNm_Grp_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LargeGoodsGanreCodeNm_Grp_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DetailGoodsGanreCode_Grp_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MediumGoodsGanreCode_Grp_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LargeGoodsGanreCode_Grp_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsRateRankCd_Grp_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BLGoodsCodeNm_Grp_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BLGoodsCode_Grp_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCdNm_Grp_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.GoodsMakerCd_Grp_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).EndInit();
			this.Main_ultraExplorerBar.ResumeLayout(false);
			this.ultraExplorerBarContainerControl3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ultraTree2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Events
		/// <summary>
		/// ツールバー設定
		/// </summary>
		public event ParentToolbarInventSettingEventHandler ParentToolbarInventSettingEvent;
		#endregion

		#region Private Member
		// IInventInputMdiChild メンバ用 変数 ---------------------------------------
		private string _enterpriseCode	= "";		// 企業コード
		private string _sectionCode		= "";		// 拠点コード
		private string _sectionName		= "";		// 拠点名称
		private bool _isCansel			= false;	// 取消ボタンEnabled
		private bool _isSave			= false;	// 保存ボタンEnabled
		private bool _isExtract			= true;		// 抽出ボタンEnabled
		private bool _isNewInvent		= false;	// 新規ボタンEnabled
		private bool _isDetail			= false;	// 詳細ボタンEnabled
		private bool _isBarcodeRead		= false;	// バーコード読込ボタンEnabled
		private bool _isDataEdit		= false;	// 編集ボタンEnabled

		//------------------------
		// 各種アクセスクラス定義
		//------------------------
		internal RateBlanketAcs _rateBlanketAcs = null;		// 掛率マスタ一括アクセスクラス
		private UserGuideAcs _userGuideAcs = null;			// ユーザーガイドアクセスクラス
		private CustomerInfoAcs _customerInfoAcs = null;	// 得意先アクセスクラス
        private SupplierAcs _supplierAcs = null;            // 仕入先アクセスクラス // ADD 2008.04.24
		private RateProtyMngAcs _rateProtyMngAcs = null;	// 掛率優先管理アクセスクラス
		private GoodsAcs _goodsAcs = null;					// 商品アクセスクラス
		private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
		private LGoodsGanreAcs _lGoodsGanreAcs = null;		// 商品区分グループアクセスクラス
		private MGoodsGanreAcs _mGoodsGanreAcs = null;		// 商品区分アクセスクラス
		private DGoodsGanreAcs _dGoodsGanreAcs = null;		// 商品区分詳細アクセスクラス
		private BLGoodsCdAcs _blGoodsCdAcs = null;			// BLアクセスクラス
		
		// データ変更比較用
		private RateBlanket _tempRateBlanket = null;		// 掛率マスタ一括登録データ比較用

		// 文字列結合用
		private StringBuilder _stringBuilder = null;

		// 現在の入力状況フラグ
		private AllCtrlInputStatus _AllCtrlInputStatus;

 		// 画面イメージコントロール部品
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
		
		//--------------------
		// ユーザーガイド関連
		//--------------------
		private SortedList _custRateGrpCodeSList = null;		// 得意先掛率グループ
		private SortedList _suppRateGrpCodeSList = null;		// 仕入先掛率グループ
		private SortedList _enterpriseGanreCodeSList = null;	// 自社分類
		private SortedList _priceDivSList = null;				// 価格区分 -グリッド画面用
		private SortedList _bargainCdSList = null;				// 特売区分 -グリッド画面用
		
		//------------------
		// コンボボックス用
		//------------------
		private int _unitPriceKindtComboEditorValue = -1;		// 単価種類コンボボックスデータ
		private int _unitPriceKindWaytComboEditorValue = -1;	// 設定方法コンボボックスデータ
		private DataTable _dataTableCustRateGrpCode = null;		// 得意先掛率グループコンボボックス用
		private DataTable _dataTableSuppRateGrpCode = null;		// 仕入先掛率グループコンボボックス用
		private DataTable _dataTableUnitPriceKind = null;		// 単価種類コンボボックス用
		private DataTable _dataTableUnitPriceKindWay = null;	// 設定方法コンボボックス用
		private DataTable _dataTableDispDiv = null;				// 表示区分コンボボックス用
		private DataTable _dataTableEnterpriseGanreCode = null;	// 自社分類コンボボックス用

		//------------------------------
		// 各種条件設定用データテーブル
		//------------------------------
		private DataTable _dataTableInpCond = null;				// 入力条件設定用データテーブル
		private DataTable _dataTableRateGoodsCond = null;		// 商品掛率条件用データテーブル
		private DataTable _dataTableRateCustCond = null;		// 得意先掛率条件用データテーブル

		// Message関連定義
		private const string ASSEMBLY_ID = "DCKHN09180U";			// アセンブリＩＤまたはクラスＩＤ
		private const string ALL_DEL_MSG = "全てのデータが初期化されますがよろしいですか？";
		private const string EXTRA_DEL_MSG = "抽出条件が初期化されますがよろしいですか？";
		private const string RATE_INPUT_MSG = "掛率設定区分を入力してください。";
		private const string GRP_INPUT_MSG = "商品情報を1つ以上設定してください。";
		private const string GOODSMAKERCD_INPUT_MSG = "メーカーコードを入力してください。";
		
		//------------
		// 入力条件用
		//------------
		private const string COND_UNITPRICEKIND = "単価種類";
		private const string COND_UNITPRICEKINDWAYCD = "設定方法";
		private const string COND_GOODSNO = "商品番号";
		private const string COND_GOODSMAKERCD = "商品メーカーコード";
		private const string COND_GOODSRATERANK = "商品掛率ランク";
		private const string COND_LARGEGOODSGANRECODE = "商品区分グループコード";
		private const string COND_MEDIUMGOODSGANRECODE = "商品区分コード";
		private const string COND_DETAILGOODSGANRECODE = "商品区分詳細コード";
		private const string COND_ENTERPRISEGANRECODE = "自社分類コード";
		private const string COND_BLGOODSCODE = "BL商品コード";
		private const string COND_CUSTOMERCODE = "得意先コード";
		private const string COND_CUSTRATEGRPCODE = "得意先掛率グループコード";
		private const string COND_SUPPLIERCD = "仕入先コード";
		private const string COND_SUPPRATEGRPCODE = "仕入先掛率グループコード";
		private const string COND_RATESTARTDATE = "掛率開始日";
		private const string COND_PRICE = "価格";
		private const string COND_PRICEDIV = "価格区分";
		private const string COND_UNPRCCALCDIV = "単価算出区分";
		private const string COND_RATEMNGGOODSCD = "掛率設定区分（商品）";
		private const string COND_RATEMNGCUSTCD = "掛率設定区分（得意先）";

		// ファイルレイアウト関連
		private const string OLDNEWDIVCD_NEW = "0";	// 新旧フラグ（新）
		private const string OLDNEWDIVCD_OLD = "1";	// 新旧フラグ（旧）

		// ユーザーガイドデータ関連
		private const int GUIDEDIVCD_CUSTRATEGRPCODE		= 43;	// ガイド区分（得意先掛率グループ）
		private const int GUIDEDIVCD_SUPPRATEGRPCODE		= 44;	// ガイド区分（仕入先掛率グループ）
		private const int GUIDEDIVCD_ENTERPRISEGANRECODE	= 41;	// ガイド区分（自社分類）
		private const int GUIDEDIVCD_PRICEDIV				= 47;	// ガイド区分（価格区分）
		private const int GUIDEDIVCD_BARGAINCD				= 42;	// ガイド区分（特売区分）

		// コンボボックス用
		private const string COMBO_CODE = "COMBO_CODE";
		private const string COMBO_NAME = "COMBO_NAME";
		
		#endregion

		#region enum
		/// <summary>
		/// 全体画面入力状況
		/// </summary>
		private enum AllCtrlInputStatus
		{
			// 初期(掛率設定)
			New = 0,

			// 条件設定
			InputCondition = 1
		}

		/// <summary>
		/// 画面データ設定ステータス
		/// </summary>
		private enum DispSetStatus
		{
			// クリア
			Clear = 0,
			// 更新
			Update = 1,
			// 元に戻す
			Back = 2
		}
		
		/// <summary>
		/// 入力エラーチェックステータス
		/// </summary>
		private enum InputChkStatus
		{
			// 未入力
			NotInput = -1,
			// 存在しない
			NotExist = -2,
			// 入力ミス
			InputErr = -3,
			// 正常
			Normal = 0
		}
		#endregion
       
		#region Public Property
		/// <summary> 企業コードプロパティ </summary>
		public string EnterpriseCode
		{
			set { this._enterpriseCode = value; }
		}

		/// <summary> 拠点コードプロパティ </summary>
		public string SectionCode
		{
			set { this._sectionCode = value; }
		}

		/// <summary> 拠点名称プロパティ </summary>
		public string SectionName
		{
			set { this._sectionName = value; }
		}

		/// <summary> 取消ボタンEnabledプロパティ </summary>
		public bool IsCansel
		{
			get { return this._isCansel; }
		}

		/// <summary> 保存ボタンEnabledプロパティ </summary>
		public bool IsSave
		{
			get { return this._isSave; }
		}

		/// <summary> 抽出ボタンEnabledプロパティ </summary>
		public bool IsExtract
		{
			get { return this._isExtract; }
		}

		/// <summary> 新規ボタンEnabledプロパティ </summary>
		public bool IsNewInvent
		{
			get { return this._isNewInvent; }
		}

		/// <summary> 詳細ボタンEnabledプロパティ </summary>
		public bool IsDetail
		{
			get { return this._isDetail; }
		}

		/// <summary> バーコード読込ボタンEnabledプロパティ </summary>
		public bool IsBarcodeRead
		{
			get { return this._isBarcodeRead; }
		}

		/// <summary> 詳細ボタンEnabledプロパティ </summary>
		public bool IsDataEdit
		{
			get { return this._isDataEdit; }
		}
		#endregion

		#region Public Method

		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : タブが変更される前に実行される</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int ShowData ( object parameter )
		{
			return 0;
		}
		/// <summary>
		/// タブ変更前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : タブが変更される前に実行される</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BeforeTabChange ( object parameter )
		{
			return 0;
		}
		/// <summary>
		/// 終了前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 終了前処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BeforeClose ( object parameter )
		{
			return 0;
		}
		/// <summary>
		/// 取消前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取消前処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BeforeCansel ( object parameter )
		{
			return 0;
		}
		/// <summary>
		/// 取消処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取消処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int Cansel ( object parameter )
		{
			return 0;
		}
		/// <summary>
		/// 抽出前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 抽出前処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BeforeExtract ( object parameter )
		{
			// 表示条件エリアの場合
			if(this._AllCtrlInputStatus == AllCtrlInputStatus.New)
			{
				// 掛率設定区分チェックを行う
				if (this.RateSettingDivide_tEdit.Text == "")
				{
					// 名称クリア
					this.RateMngCustCd_tEdit.Clear();
					this.RateMngCustNm_tEdit.Clear();
					this.RateMngGoodsCd_tEdit.Clear();
					this.RateMngGoodsNm_tEdit.Clear();

					// 現在データクリア
					this._tempRateBlanket.RateSettingDivide = "";
					this._tempRateBlanket.RateMngCustCd = "";
					this._tempRateBlanket.RateMngCustNm = "";
					this._tempRateBlanket.RateMngGoodsCd = "";
					this._tempRateBlanket.RateMngGoodsNm = "";
					
					ShowInpErrMsg(RATE_INPUT_MSG);
					this.RateSettingDivide_tEdit.Focus();
					
					return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
			}
			// 抽出条件エリアの場合
			else
			{
				Control errComponent = null;
				string errMessage = "";

				// 掛率設定区分チェックを行う
				if (this.RateSettingDivide_tEdit.Text == "")
				{
					// 名称クリア
					this.RateMngCustCd_tEdit.Clear();
					this.RateMngCustNm_tEdit.Clear();
					this.RateMngGoodsCd_tEdit.Clear();
					this.RateMngGoodsNm_tEdit.Clear();

					// 現在データクリア
					this._tempRateBlanket.RateSettingDivide = "";
					this._tempRateBlanket.RateMngCustCd = "";
					this._tempRateBlanket.RateMngCustNm = "";
					this._tempRateBlanket.RateMngGoodsCd = "";
					this._tempRateBlanket.RateMngGoodsNm = "";

					ShowInpErrMsg(RATE_INPUT_MSG);
					this.RateSettingDivide_tEdit.Focus();

					return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				}
				
				// 取引先エリア必須項目チェック
				if (CustInfoInpDataCheck(ref errComponent, ref errMessage) != 0)
				{
					if (errComponent != null)
					{
						ShowInpErrMsg(errMessage);
						errComponent.Focus();

						return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
					}
				}
				else
				{
					// 単品設定の場合
					if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
					{
						// メーカーコード必須入力
						if (this.GoodsMakerCd_tNedit.Text == "")
						{
							// 名称クリア
							this.GoodsMakerCdNm_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.GoodsMakerCd = 0;

							ShowInpErrMsg(GOODSMAKERCD_INPUT_MSG);
							this.GoodsMakerCd_tNedit.Focus();

							return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
						}
					}
					// 商品Ｇ設定の場合
					else
					{
						// 掛率設定区分が「Ｏ：指定無し」以外で、商品情報エリア条件必須項目チェック
						if ((this.RateMngGoodsCd_tEdit.Text != "O")&&(GoodsInfoInpDataCheck(ref errComponent) != 0))
						{
							if (errComponent != null)
							{
								ShowInpErrMsg(GRP_INPUT_MSG);
								errComponent.Focus();

								return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							}
						}
					}

				}
			}

			// 全項目入力チェック
			if (InpCondDataCheck() == false)
			{
				return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}
		/// <summary>
		/// 抽出処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 抽出処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int Extract ( object parameter )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			string errMsg = "";
			RateBlanket rateBlanket = new RateBlanket();
			
			try
			{
				// 画面→抽出条件クラス
				SetExtraInfo(rateBlanket);

				// アクセスクラスの抽出処理を実行
				status = this._rateBlanketAcs.Search(ref rateBlanket, RateBlanketAcs.NullChgInt(this.DispDiv_tComboEditor.Value), out errMsg);
				
				switch ( status )
				{
					case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
						parameter = rateBlanket;
						break;
					case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
						this.MsgDispProc( emErrorLevel.ERR_LEVEL_INFO, errMsg, status );
						break;
					case (int)ConstantManagement.MethodResult.ctFNC_CANCEL:
						this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
						break;
				}
			}
			catch ( Exception ex )
			{
				this.MsgDispProc( "抽出処理に失敗しました", (int)ConstantManagement.MethodResult.ctFNC_CANCEL, "Extract", ex );
			}
			finally
			{
				//msgForm.Close();
			}
			return status;
		}
		/// <summary>
		/// 新規処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 新規処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int NewInvent ( object parameter )
		{
			return 0;
		}
		/// <summary>
		/// 保存前処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 保存前処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BeforeSave(object parameter)
		{
			return 0;
		}
		/// <summary>
		/// 保存処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 保存処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int Save ( object parameter )
		{
			return 0;
		}
		/// <summary>
		/// 詳細表示処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 詳細表示処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int ShowDetail ( object parameter )
		{
			return 0;
		}
		/// <summary>
		/// バーコード読込処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : バーコード読込処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int BarcodeRead ( object parameter )
		{
			return 0;
		}
		/// <summary>
		/// 編集処理
		/// </summary>
		/// <param name="parameter">パラメータ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 編集処理を行う</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.07.25</br>
		/// </remarks>
		public int DataEdit ( object parameter )
		{
			return 0;
		}

		#endregion ◆ Public Method

		#region Private Method
		/// <summary>
		/// 初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : UIの初期化処理を行う。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			//--------------------------
			// ユーザーガイドデータ取得
			//--------------------------
			ArrayList userGdBdList;

			// 得意先掛率グループ
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_CUSTRATEGRPCODE);
			SetUserGdBd(ref this._custRateGrpCodeSList, ref userGdBdList);

			// 仕入先掛率グループ
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_SUPPRATEGRPCODE);
			SetUserGdBd(ref this._suppRateGrpCodeSList, ref userGdBdList);

			// 自社分類コード取得
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_ENTERPRISEGANRECODE);
			SetUserGdBd(ref this._enterpriseGanreCodeSList, ref userGdBdList);

			// 価格区分取得（抽出結果グリッド表示用）
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_PRICEDIV);
			SetUserGdBd(ref this._priceDivSList, ref userGdBdList);
			
			// データクラスへ保存
			RateBlanket._priceDivSList = this._priceDivSList;
			
			// 特売区分取得（抽出結果グリッド表示用）
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_BARGAINCD);
			SetUserGdBd(ref this._bargainCdSList, ref userGdBdList);
			
			// データクラスへ保存
			RateBlanket._bargainCdSList = this._bargainCdSList;
			
			//--------------
			// 入力条件設定
			//--------------
			SetDataTableCond(ref RateBlanket._setDataInpCond, ref this._dataTableInpCond);
			SetDataTableCond(ref RateBlanket._setDataGoodsRateCond, ref this._dataTableRateGoodsCond);
			SetDataTableCond(ref RateBlanket._setDataCustRateCond, ref this._dataTableRateCustCond);

			//------------------------------------
			// コンボボックス用データテーブル設定
			//------------------------------------
			SetComboData(ref RateBlanket._unitPriceKindTable, ref this._dataTableUnitPriceKind);
			SetComboData(ref RateBlanket._unitPriceKindWayTable, ref this._dataTableUnitPriceKindWay);
			SetComboData(ref RateBlanket._dispDivTable, ref this._dataTableDispDiv);
			SetComboDataDefault(ref this._custRateGrpCodeSList, ref this._dataTableCustRateGrpCode);
			SetComboDataDefault(ref this._suppRateGrpCodeSList, ref this._dataTableSuppRateGrpCode);
			SetComboDataDefault(ref this._enterpriseGanreCodeSList, ref this._dataTableEnterpriseGanreCode);

			//--------------------
			// コンボボックス設定
			//--------------------
			BindCombo(ref this.UnitPriceKind_tComboEditor, ref this._dataTableUnitPriceKind);
			BindCombo(ref this.UnitPriceKindWay_tComboEditor, ref this._dataTableUnitPriceKindWay);
			BindCombo(ref this.DispDiv_tComboEditor, ref this._dataTableDispDiv);
			BindCombo(ref this.CustRateGrpCode_tComboEditor, ref this._dataTableCustRateGrpCode);
			BindCombo(ref this.SuppRateGrpCode_tComboEditor, ref this._dataTableSuppRateGrpCode);
			BindCombo(ref this.EnterpriseGanreCode_Grp_tComboEditor, ref this._dataTableEnterpriseGanreCode);
		}

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void ScreenClear()
		{
			//----------------
			// 各フラグ初期化
			//----------------
			// パネル表示可否初期化
			this.Single_panel.Show();
			this.Grp_panel.Hide();

			// 入力状況フラグ初期化
			this._AllCtrlInputStatus = AllCtrlInputStatus.New;

			//------------------
			// 設定データクリア
			//------------------
			this._tempRateBlanket = new RateBlanket();

			this._unitPriceKindtComboEditorValue	= RateBlanketAcs.NullChgInt(RateBlanket._unitPriceKindTable.GetKey(0));	// 単価種類コンボボックス
			this._unitPriceKindWaytComboEditorValue = RateBlanketAcs.NullChgInt(RateBlanket._unitPriceKindWayTable.GetKey(0));	// 設定方法コンボボックス

			// コンボボックス初期化
			this.UnitPriceKind_tComboEditor.Value		= RateBlanket._unitPriceKindTable.GetKey(0);		// 単価種類
			this.UnitPriceKindWay_tComboEditor.Value	= RateBlanket._unitPriceKindWayTable.GetKey(0);		// 設定方法
			this.CustRateGrpCode_tComboEditor.Clear();														// 得意先掛率グループ
			this.SuppRateGrpCode_tComboEditor.Clear();														// 仕入先掛率グループ
			this.DispDiv_tComboEditor.Value				= RateBlanket._dispDivTable.GetKey(0);				// 表示区分
			this.EnterpriseGanreCode_Grp_tComboEditor.Clear();												// 自社分類
			
			this.EnterpriseGanreCode_Grp_tComboEditor.Enabled = false;	// 自社分類
			
			// ヘッダ項目
			this.RateSettingDivide_tEdit.Clear();	// 掛率設定区分
			this.RateMngGoodsCd_tEdit.Clear();		// 商品設定区分（コード）
			this.RateMngGoodsNm_tEdit.Clear();		// 商品設定区分（名称）
			this.RateMngCustCd_tEdit.Clear();		// 取引先設定区分（コード）
			this.RateMngCustNm_tEdit.Clear();		// 取引先設定区分（名称）

			// 単品設定項目
			this.GoodsNoCd_tEdit.Clear();					// 商品コード
			this.GoodsNoNm_tEdit.Clear();					// 商品名称
			this.GoodsMakerCd_tNedit.Clear();				// 商品メーカーコード
			this.GoodsMakerCdNm_tEdit.Clear();				// 商品メーカーコード（名称）

			// グループ設定項目
			this.GoodsMakerCd_Grp_tNedit.Clear();			// 商品メーカーコード
			this.GoodsMakerCdNm_Grp_tEdit.Clear();			// 商品メーカーコード（名称）
			this.GoodsRateRankCd_Grp_tEdit.Clear();			// 商品掛率ランク
			this.LargeGoodsGanreCode_Grp_tEdit.Clear();		// 商品区分グループコード
			this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();	// 商品区分グループコード（名称）
			this.MediumGoodsGanreCode_Grp_tEdit.Clear();	// 商品区分コード
			this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();	// 商品区分コード（名称）
			this.DetailGoodsGanreCode_Grp_tEdit.Clear();	// 商品区分詳細コード
			this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();	// 商品区分詳細コード（名称）
			this.BLGoodsCode_Grp_tNedit.Clear();			// ＢＬ商品コード
			this.BLGoodsCodeNm_Grp_tEdit.Clear();			// ＢＬ商品コード（名称）

			// 取引先設定項目
			this.CustomerCode_tNedit.Clear();				// 得意先コード
			this.CustomerCodeNm_tEdit.Clear();				// 得意先名称
			this.SupplierCd_tNedit.Clear();					// 仕入先コード
			this.SupplierCdNm_tEdit.Clear();				// 仕入先名称
			
			//----------
			// 入力制御
			//----------
			// パネル設定
			this.Single_panel.Enabled = false;						// 単品設定パネル
			this.Grp_panel.Enabled = false;							// 商品Ｇ設定パネル
			this.Customer_panel.Enabled = false;					// 得意先設定パネル
			
			// 項目ボタン設定
			this.GoodsNo_uButton.Enabled = false;					// 商品番号（単品）
			this.GoodsMakerCd_uButton.Enabled = false;				// 商品メーカー（単品）
			this.GoodsMakerCd_Grp_uButton.Enabled = false;			// 商品メーカー
			this.LargeGoodsGanreCode_Grp_uButton.Enabled = false;	// 商品区分Ｇ
			this.MediumGoodsGanreCode_Grp_uButton.Enabled = false;	// 商品区分
			this.DetailGoodsGanreCode_Grp_uButton.Enabled = false;	// 商品区分詳細
			this.BLGoodsCode_Grp_uButton.Enabled = false;			// ＢＬ商品
			this.CustomerCode_uButton.Enabled = false;				// 得意先
			this.SupplierCd_uButton.Enabled = false;				// 仕入先

			// 単品設定
			this.GoodsNoCd_tEdit.Enabled = false;					// 商品コード
			this.GoodsMakerCd_tNedit.Enabled = false;				// 商品メーカーコード

			// グループ設定
			this.GoodsMakerCd_Grp_tNedit.Enabled = false;			// 商品メーカーコード
			this.GoodsRateRankCd_Grp_tEdit.Enabled = false;			// 商品掛率ランク
			this.LargeGoodsGanreCode_Grp_tEdit.Enabled = false;		// 商品区分グループコード
			this.MediumGoodsGanreCode_Grp_tEdit.Enabled = false;	// 商品区分コード
			this.DetailGoodsGanreCode_Grp_tEdit.Enabled = false;	// 商品区分詳細コード
			this.BLGoodsCode_Grp_tNedit.Enabled = false;			// ＢＬ商品コード

			// 取引先設定
			this.CustomerCode_tNedit.Enabled = false;				// 得意先コード
			this.CustRateGrpCode_tComboEditor.Enabled = false;		// 得意先掛率グループ
			this.SupplierCd_tNedit.Enabled = false;					// 仕入先コード
			this.SuppRateGrpCode_tComboEditor.Enabled = false;		// 仕入先掛率グループ
		}

		/// <summary>
		/// 入力条件設定用データセット列情報構築処理
		/// </summary>
		/// <param name="wkTable">データテーブル</param>
		/// <remarks>
		/// <br>Note       : 入力条件設定用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void DataTblColumnConstInpCond(ref DataTable wkTable)
		{
			//----------
			// 条件部分
			//----------
			// 単価種類
			wkTable.Columns.Add(COND_UNITPRICEKIND, typeof(string));

			// 設定方法
			wkTable.Columns.Add(COND_UNITPRICEKINDWAYCD, typeof(string));

			//---------------------------
			// 設定可否（0：不可, 1：可）
			//---------------------------
			// 商品番号
			wkTable.Columns.Add(COND_GOODSNO, typeof(string));

			// 商品メーカーコード
			wkTable.Columns.Add(COND_GOODSMAKERCD, typeof(string));

			// 商品掛率ランク
			wkTable.Columns.Add(COND_GOODSRATERANK, typeof(string));

			// 商品区分グループコード
			wkTable.Columns.Add(COND_LARGEGOODSGANRECODE, typeof(string));

			// 商品区分コード
			wkTable.Columns.Add(COND_MEDIUMGOODSGANRECODE, typeof(string));

			// 商品区分詳細コード
			wkTable.Columns.Add(COND_DETAILGOODSGANRECODE, typeof(string));

			// 自社分類コード
			wkTable.Columns.Add(COND_ENTERPRISEGANRECODE, typeof(string));

			// BL商品コード
			wkTable.Columns.Add(COND_BLGOODSCODE, typeof(string));

			// 得意先コード
			wkTable.Columns.Add(COND_CUSTOMERCODE, typeof(string));

			// 得意先掛率グループコード
			wkTable.Columns.Add(COND_CUSTRATEGRPCODE, typeof(string));

			// 仕入先コード
			wkTable.Columns.Add(COND_SUPPLIERCD, typeof(string));

			// 仕入先掛率グループコード
			wkTable.Columns.Add(COND_SUPPRATEGRPCODE, typeof(string));

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_UNITPRICEKIND], wkTable.Columns[COND_UNITPRICEKINDWAYCD] };
		}

		/// <summary>
		/// 商品掛率条件設定用データセット列情報構築処理
		/// </summary>
		/// <param name="wkTable">データテーブル</param>
		/// <remarks>
		/// <br>Note       : 商品掛率条件設定用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void DataTblColumnConstGoodsRateCond(ref DataTable wkTable)
		{
			//----------
			// 条件部分
			//----------
			// 区分
			wkTable.Columns.Add(COND_RATEMNGGOODSCD, typeof(string));

			//---------------------------
			// 設定可否（0：不可, 1：可）
			//---------------------------
			// 商品番号
			wkTable.Columns.Add(COND_GOODSNO, typeof(string));

			// 商品メーカーコード
			wkTable.Columns.Add(COND_GOODSMAKERCD, typeof(string));

			// 商品掛率ランク
			wkTable.Columns.Add(COND_GOODSRATERANK, typeof(string));

			// 商品区分グループコード
			wkTable.Columns.Add(COND_LARGEGOODSGANRECODE, typeof(string));

			// 商品区分コード
			wkTable.Columns.Add(COND_MEDIUMGOODSGANRECODE, typeof(string));

			// 商品区分詳細コード
			wkTable.Columns.Add(COND_DETAILGOODSGANRECODE, typeof(string));

			// 自社分類コード
			wkTable.Columns.Add(COND_ENTERPRISEGANRECODE, typeof(string));

			// BL商品コード
			wkTable.Columns.Add(COND_BLGOODSCODE, typeof(string));

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_RATEMNGGOODSCD] };
		}

		/// <summary>
		/// 得意先掛率条件設定用データセット列情報構築処理
		/// </summary>
		/// <param name="wkTable">データテーブル</param>
		/// <remarks>
		/// <br>Note       : 得意先掛率条件設定用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void DataTblColumnConstCustRateCond(ref DataTable wkTable)
		{
			//----------
			// 条件部分
			//----------
			// 区分
			wkTable.Columns.Add(COND_RATEMNGCUSTCD, typeof(string));

			//---------------------------
			// 設定可否（0：不可, 1：可）
			//---------------------------
			// 得意先コード
			wkTable.Columns.Add(COND_CUSTOMERCODE, typeof(string));

			// 得意先掛率グループコード
			wkTable.Columns.Add(COND_CUSTRATEGRPCODE, typeof(string));

			// 仕入先コード
			wkTable.Columns.Add(COND_SUPPLIERCD, typeof(string));

			// 仕入先掛率グループコード
			wkTable.Columns.Add(COND_SUPPRATEGRPCODE, typeof(string));

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_RATEMNGCUSTCD] };
		}

		/// <summary>
		/// 条件設定用データ設定
		/// </summary>
		/// <param name="al">条件設定ArrayList</param>
		/// <param name="dataTable">データテーブル</param>
		/// <remarks>
		/// <br>Note       : 条件設定用データを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void SetDataTableCond(ref ArrayList al, ref DataTable dataTable)
		{
			try
			{
				foreach (string[] wkAl in (ArrayList)al)
				{
					if (dataTable.Columns.Count == wkAl.Length)
					{
						DataRow dr = dataTable.NewRow();

						for (int i = 0; i < dataTable.Columns.Count; i++)
						{
							dr[i] = wkAl[i];
						}
						dataTable.Rows.Add(dr);
					}
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// 入力条件制御処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入力条件入力域を制御します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void SettingInpCond()
		{
			string inpUnitPriceKind = RateBlanketAcs.NullChgStr(this.UnitPriceKind_tComboEditor.Value);
			string inpUnitPriceKindWay = RateBlanketAcs.NullChgStr(this.UnitPriceKindWay_tComboEditor.Value);
			string inpRateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
			string inpRateMngCustCd = this.RateMngCustCd_tEdit.Text;

			string inpChkStr = "";
			string rateChkStr = "";

			//--------------
			// 商品コード
			//--------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSNO, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_GOODSNO, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.GoodsNoCd_tEdit.Enabled = true;
				this.GoodsNoNm_tEdit.Enabled = true;
				this.GoodsNo_uButton.Enabled = true;
				
				RateBlanket._gridHdnGoodsNo = false;
			}
			else
			{
				this.GoodsNoCd_tEdit.Enabled = false;
				this.GoodsNoNm_tEdit.Enabled = false;
				this.GoodsNo_uButton.Enabled = false;
				
				this.GoodsNoCd_tEdit.Clear();
				this.GoodsNoNm_tEdit.Clear();
				
				RateBlanket._gridHdnGoodsNo = true;
			}

			//--------------------
			// 商品メーカーコード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSMAKERCD, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_GOODSMAKERCD, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.GoodsMakerCd_tNedit.Enabled = true;
				this.GoodsMakerCdNm_tEdit.Enabled = true;
				this.GoodsMakerCd_Grp_tNedit.Enabled = true;
				this.GoodsMakerCdNm_Grp_tEdit.Enabled = true;
				this.GoodsMakerCd_uButton.Enabled = true;
				this.GoodsMakerCd_Grp_uButton.Enabled = true;
				
				RateBlanket._gridHdnGoodsMakerCd = false;
			}
			else
			{
				this.GoodsMakerCd_tNedit.Enabled = false;
				this.GoodsMakerCdNm_tEdit.Enabled = false;
				this.GoodsMakerCd_Grp_tNedit.Enabled = false;
				this.GoodsMakerCdNm_Grp_tEdit.Enabled = false;
				this.GoodsMakerCd_uButton.Enabled = false;
				this.GoodsMakerCd_Grp_uButton.Enabled = false;
				
				this.GoodsMakerCd_tNedit.Clear();
				this.GoodsMakerCdNm_tEdit.Clear();
				this.GoodsMakerCd_Grp_tNedit.Clear();
				this.GoodsMakerCdNm_Grp_tEdit.Clear();
				
				RateBlanket._gridHdnGoodsMakerCd = true;
			}

			//------------------
			// 商品掛率ランク
			//------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSRATERANK, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_GOODSRATERANK, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.GoodsRateRankCd_Grp_tEdit.Enabled = true;
				
				RateBlanket._gridHdnGoodsRateRankCd = false;
			}
			else
			{
				this.GoodsRateRankCd_Grp_tEdit.Enabled = false;

				this.GoodsRateRankCd_Grp_tEdit.Clear();
				
				RateBlanket._gridHdnGoodsRateRankCd = true;
			}

			//------------------
			// 商品区分グループコード
			//------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_LARGEGOODSGANRECODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_LARGEGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.LargeGoodsGanreCode_Grp_tEdit.Enabled = true;
				this.LargeGoodsGanreCodeNm_Grp_tEdit.Enabled = true;
				this.LargeGoodsGanreCode_Grp_uButton.Enabled = true;
				
				RateBlanket._gridHdnLargeGoodsGanreCode = false;
			}
			else
			{
				this.LargeGoodsGanreCode_Grp_tEdit.Enabled = false;
				this.LargeGoodsGanreCodeNm_Grp_tEdit.Enabled = false;
				this.LargeGoodsGanreCode_Grp_uButton.Enabled = false;
				
				this.LargeGoodsGanreCode_Grp_tEdit.Clear();
				this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();
				
				RateBlanket._gridHdnLargeGoodsGanreCode = true;
			}

			//------------------
			// 商品区分コード
			//------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_MEDIUMGOODSGANRECODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_MEDIUMGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.MediumGoodsGanreCode_Grp_tEdit.Enabled = true;
				this.MediumGoodsGanreCodeNm_Grp_tEdit.Enabled = true;
				this.MediumGoodsGanreCode_Grp_uButton.Enabled = true;
				
				RateBlanket._gridHdnMediumGoodsGanreCode = false;
			}
			else
			{
				this.MediumGoodsGanreCode_Grp_tEdit.Enabled = false;
				this.MediumGoodsGanreCodeNm_Grp_tEdit.Enabled = false;
				this.MediumGoodsGanreCode_Grp_uButton.Enabled = false;

				this.MediumGoodsGanreCode_Grp_tEdit.Clear();
				this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();
				
				RateBlanket._gridHdnMediumGoodsGanreCode = true;
			}

			//--------------------
			// 商品区分詳細コード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_DETAILGOODSGANRECODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_DETAILGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.DetailGoodsGanreCode_Grp_tEdit.Enabled = true;
				this.DetailGoodsGanreCodeNm_Grp_tEdit.Enabled = true;
				this.DetailGoodsGanreCode_Grp_uButton.Enabled = true;
				
				RateBlanket._gridHdnDetailGoodsGanreCode = false;
			}
			else
			{
				this.DetailGoodsGanreCode_Grp_tEdit.Enabled = false;
				this.DetailGoodsGanreCodeNm_Grp_tEdit.Enabled = false;
				this.DetailGoodsGanreCode_Grp_uButton.Enabled = false;

				this.DetailGoodsGanreCode_Grp_tEdit.Clear();
				this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();
				
				RateBlanket._gridHdnDetailGoodsGanreCode = true;
			}

			//--------------------
			// 自社分類コード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_ENTERPRISEGANRECODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_ENTERPRISEGANRECODE, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.EnterpriseGanreCode_Grp_tComboEditor.Enabled = true;
				
				RateBlanket._gridHdnEnterpriseGanreCode = false;
			}
			else
			{
				this.EnterpriseGanreCode_Grp_tComboEditor.Enabled = false;
				this.EnterpriseGanreCode_Grp_tComboEditor.Clear();
				
				RateBlanket._gridHdnEnterpriseGanreCode = true;
			}

			//--------------------
			// ＢＬ商品コード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_BLGOODSCODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_BLGOODSCODE, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.BLGoodsCode_Grp_tNedit.Enabled = true;
				this.BLGoodsCodeNm_Grp_tEdit.Enabled = true;
				this.BLGoodsCode_Grp_uButton.Enabled = true;
				
				RateBlanket._gridHdnBLGoodsCode = false;
			}
			else
			{
				this.BLGoodsCode_Grp_tNedit.Enabled = false;
				this.BLGoodsCodeNm_Grp_tEdit.Enabled = false;
				this.BLGoodsCode_Grp_uButton.Enabled = false;

				this.BLGoodsCode_Grp_tNedit.Clear();
				this.BLGoodsCodeNm_Grp_tEdit.Clear();
				
				RateBlanket._gridHdnBLGoodsCode = true;
			}

			//--------------------
			// 得意先コード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_CUSTOMERCODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_CUSTOMERCODE, ref this._dataTableRateCustCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.CustomerCode_tNedit.Enabled = true;
				this.CustomerCodeNm_tEdit.Enabled = true;
				this.CustomerCode_uButton.Enabled = true;
				
				RateBlanket._gridHdnCustomerCode = false;
			}
			else
			{
				this.CustomerCode_tNedit.Enabled = false;
				this.CustomerCodeNm_tEdit.Enabled = false;
				this.CustomerCode_uButton.Enabled = false;

				this.CustomerCode_tNedit.Clear();
				this.CustomerCodeNm_tEdit.Clear();
				
				RateBlanket._gridHdnCustomerCode = true;
			}

			//--------------------
			// 得意先掛率コード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_CUSTRATEGRPCODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_CUSTRATEGRPCODE, ref this._dataTableRateCustCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.CustRateGrpCode_tComboEditor.Enabled = true;
				
				RateBlanket._gridHdnCustRateGrpCode = false;
			}
			else
			{
				this.CustRateGrpCode_tComboEditor.Enabled = false;
				this.CustRateGrpCode_tComboEditor.Clear();
				
				RateBlanket._gridHdnCustRateGrpCode = true;
			}

			//--------------------
			// 仕入先コード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_SUPPLIERCD, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_SUPPLIERCD, ref this._dataTableRateCustCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.SupplierCd_tNedit.Enabled = true;
				this.SupplierCdNm_tEdit.Enabled = true;
				this.SupplierCd_uButton.Enabled = true;
				
				RateBlanket._gridHdnSupplierCd = false;
			}
			else
			{
				this.SupplierCd_tNedit.Enabled = false;
				this.SupplierCdNm_tEdit.Enabled = false;
				this.SupplierCd_uButton.Enabled = false;

				this.SupplierCd_tNedit.Clear();
				this.SupplierCdNm_tEdit.Clear();
				
				RateBlanket._gridHdnSupplierCd = true;
			}

			//--------------------
			// 仕入先掛率コード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_SUPPRATEGRPCODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_SUPPRATEGRPCODE, ref this._dataTableRateCustCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				this.SuppRateGrpCode_tComboEditor.Enabled = true;
				
				RateBlanket._gridHdnSuppRateGrpCode = false;
			}
			else
			{
				this.SuppRateGrpCode_tComboEditor.Enabled = false;
				this.SuppRateGrpCode_tComboEditor.Clear();
				
				RateBlanket._gridHdnSuppRateGrpCode = true;
			}
		}

		/// <summary>
		/// 入力条件データ取得
		/// </summary>
		/// <param name="primaryKey1">プライマリキー１</param>
		/// <param name="primaryKey2">プライマリキー２</param>
		/// <param name="chkStr">チェック文字列</param>
		/// <param name="dataTable">データテーブル</param>
		/// <returns>結果文字列</returns>
		/// <remarks>
		/// <br>Note       : 入力条件データを取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private string GetDataInpCond(string primaryKey1, string primaryKey2, string chkStr, ref DataTable dataTable)
		{
			string retStr = "0";

			DataRow chkRow = dataTable.Rows.Find(new object[] { primaryKey1, primaryKey2 });
			if (chkRow != null)
			{
				retStr = (string)chkRow[chkStr];
			}
			return retStr;
		}

		/// <summary>
		/// 掛率条件データ取得
		/// </summary>
		/// <param name="code">コード</param>
		/// <param name="chkStr">名称</param>
		/// <param name="dataTable">データテーブル</param>
		/// <returns>結果文字列</returns>
		/// <remarks>
		/// <br>Note       : 掛率条件データを取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private string GetDataRateSettingCond(string code, string chkStr, ref DataTable dataTable)
		{
			string retStr = "0";

			DataRow chkRow = dataTable.Rows.Find(code);
			if (chkRow != null)
			{
				retStr = (string)chkRow[chkStr];
			}
			return retStr;
		}

		/// <summary>
		/// ボタンアイコン設定処理
		/// </summary>
		/// <param name="settingButton">アイコンをセットするコントロール</param>
		/// <param name="iconIndex">アイコンインデックス</param>
		/// <remarks>
		/// <br>Note       : ボタンのアイコンを設定する</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void SetButtonImage ( UltraButton settingButton, Size16_Index iconIndex )
		{
			settingButton.ImageList = IconResourceManagement.ImageList16;
			settingButton.Appearance.Image = iconIndex;
		}
		
		/// <summary>
		/// 初期タイマー処理
		/// </summary>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 初期タイマー内で行う初期化処理を実行</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.09</br>
        /// </remarks>
		private int InitializeTimerSetting( out string errMsg )
		{
			// 初期化処理の中でも時間がかかるものを行う。
			// また、DBアクセスが走る初期化もここで処理を行う。
			
			// キャリアツリー初期化処理
			errMsg = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}
		/// <summary>
		/// 抽出条件設定処理
		/// </summary>
		/// <param name="rateBlanket">掛率マスタ一括登録抽出条件クラス</param>
		/// <remarks>
		/// <br>Note       : 掛率マスタ一括登録の抽出条件を設定する</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void SetExtraInfo(RateBlanket rateBlanket)
		{
			rateBlanket.EnterpriseCode			= this._enterpriseCode;											// 企業コード
			rateBlanket.SectionCode				= this._sectionCode;											// 拠点コード
			rateBlanket.UnitPriceKind			= RateBlanketAcs.NullChgStr(this.UnitPriceKind_tComboEditor.Value);	// 単価種類
			rateBlanket.RateSettingDivide		= this.RateSettingDivide_tEdit.Text;							// 掛率設定区分
			rateBlanket.RateMngGoodsCd			= this.RateMngGoodsCd_tEdit.Text;								// 掛率設定区分（商品）
			rateBlanket.RateMngGoodsNm			= this.RateMngGoodsNm_tEdit.Text;								// 掛率設定名称（商品）
			rateBlanket.RateMngCustCd			= this.RateMngCustCd_tEdit.Text;								// 掛率設定区分（得意先）
			rateBlanket.RateMngCustNm			= this.RateMngCustNm_tEdit.Text;								// 掛率設定名称（得意先）
			
			// 単品設定の場合
			if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
			{
				rateBlanket.GoodsMakerCd		= this.GoodsMakerCd_tNedit.GetInt();							// 商品メーカーコード（単品）
			}
			// 商品Ｇ設定の場合
			else
			{
				rateBlanket.GoodsMakerCd		= this.GoodsMakerCd_Grp_tNedit.GetInt();						// 商品メーカーコード（商品Ｇ）
			}
			
			rateBlanket.GoodsNo					= this.GoodsNoCd_tEdit.Text;									// 商品番号
			rateBlanket.GoodsRateRank			= this.GoodsRateRankCd_Grp_tEdit.Text;							// 商品掛率ランク
			rateBlanket.LargeGoodsGanreCode		= this.LargeGoodsGanreCode_Grp_tEdit.Text;						// 商品区分グループコード
			rateBlanket.MediumGoodsGanreCode	= this.MediumGoodsGanreCode_Grp_tEdit.Text;						// 商品区分コード
			rateBlanket.DetailGoodsGanreCode	= this.DetailGoodsGanreCode_Grp_tEdit.Text;						// 商品区分詳細コード
			rateBlanket.EnterpriseGanreCode		= RateBlanketAcs.NullChgInt(this.EnterpriseGanreCode_Grp_tComboEditor.Value);	// 自社分類コード
			rateBlanket.BLGoodsCode				= this.BLGoodsCode_Grp_tNedit.GetInt();							// ＢＬ商品コード
			rateBlanket.CustomerCode			= this.CustomerCode_tNedit.GetInt();							// 得意先コード
			rateBlanket.CustRateGrpCode			= RateBlanketAcs.NullChgInt(this.CustRateGrpCode_tComboEditor.Value);		// 得意先掛率グループコード
			rateBlanket.SupplierCd				= this.SupplierCd_tNedit.GetInt();								// 仕入先コード
			rateBlanket.SuppRateGrpCode			= RateBlanketAcs.NullChgInt(this.SuppRateGrpCode_tComboEditor.Value);		// 仕入先掛率グループコード
			
			rateBlanket.LotCount				= 0;															// ロット数（掛率データのみ取得）
			
		}

		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="iLevel">エラーレベル</param>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : メッセージの表示を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message,int status )
		{
			TMsgDisp.Show( 
				iLevel, 							// エラーレベル
				ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
				this.Text,							// プログラム名称
				"", 								// 処理名称
				"",									// オペレーション
				message,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
		}
		/// <summary>
		/// エラーメッセージ表示処理
		/// </summary>
		/// <param name="message">表示メッセージ</param>
		/// <param name="status">ステータス</param>
		/// <param name="procnm">発生メソッドID</param>
		/// <param name="ex">例外情報</param>
		/// <remarks>
		/// <br>Note       : 例外メッセージの表示を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void MsgDispProc( string message,int status, string procnm, Exception ex )
		{
			string errMessage = message + "\r\n" + ex.Message;

			TMsgDisp.Show( 
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
				ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
				this.Text,							// プログラム名称
				procnm, 							// 処理名称
				"",									// オペレーション
				errMessage,							// 表示するメッセージ
				status, 							// ステータス値
				null, 								// エラーが発生したオブジェクト
				MessageBoxButtons.OK, 				// 表示するボタン
				MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
		}

		/// <summary>
		/// 入力エラーメッセージ出力処理
		/// </summary>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <remarks>
		/// <br>Note       : 入力エラーメッセージを出力します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void ShowInpErrMsg(string errMsg)
		{
			DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_INFO,		                  // エラーレベル
				ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
				errMsg,									              // 表示するメッセージ
				0, 					                                  // ステータス値
				MessageBoxButtons.OK);			                      // 表示するボタン
		}

		/// <summary>
		/// データ無しエラーメッセージ出力処理
		/// </summary>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <remarks>
		/// <br>Note       : データ無しのエラーメッセージを出力します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void ShowNotFoundErrMsg(string errMsg)
		{
			_stringBuilder.Remove(0, _stringBuilder.Length);
			_stringBuilder.Append("指定された条件で、");
			_stringBuilder.Append(errMsg);
			_stringBuilder.Append("は存在しませんでした。");
			errMsg = _stringBuilder.ToString();

			DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_INFO,		                  // エラーレベル
				ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
				errMsg,									              // 表示するメッセージ
				0, 					                                  // ステータス値
				MessageBoxButtons.OK);			                      // 表示するボタン
		}

		/// <summary>
		/// ユーザーガイドマスタボディ部リスト取得処理
		/// </summary>
		/// <param name="userGdBdList">ユーザーガイドボディリスト</param>
		/// <param name="guideDivCode">ガイド区分</param>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドマスタボディ部のリストを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public int GetUserGdBdList(out ArrayList userGdBdList, int guideDivCode)
		{
			userGdBdList = null;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				status = this._userGuideAcs.SearchAllDivCodeBody(out userGdBdList, this._enterpriseCode, guideDivCode, UserGuideAcsData.UserBodyData);
			}
			catch (Exception e)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.ToString(),
					"ユーザーガイド（ヘッダ）情報の取得に失敗しました。" + "\r\n" + e.Message,
					-1,
					MessageBoxButtons.OK);

				status = -1;
			}
			return status;
		}

		/// <summary>
		/// ユーザーガイドボディデータ設定処理
		/// </summary>
		/// <param name="sList">ソートリスト</param>
		/// <param name="userGdBdList">ユーザーガイドボディリスト</param>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドボディデータを設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		public void SetUserGdBd(ref SortedList sList, ref ArrayList userGdBdList)
		{
			foreach (UserGdBd userGdBd in userGdBdList)
			{
				sList.Add(userGdBd.GuideCode, userGdBd.GuideName);
			}
		}

		/// <summary>
		/// コンボボックス用データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <param name="wkTable">データテーブル</param>
		/// <br>Note       : コンボボックス用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void DataTblColumnConstComboList(ref DataTable wkTable)
		{
			wkTable.Columns.Add(COMBO_CODE, typeof(Int32));		// コード
			wkTable.Columns.Add(COMBO_NAME, typeof(string));	// 名称

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
		}

		/// <summary>
		/// コンボボックスデフォルトデータ設定
		/// </summary>
		/// <remarks>
		/// <param name="sList">ソートリスト</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスデフォルトデータを先頭に設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void SetComboDataDefault(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				DataRow dr = dataTable.NewRow();

				dr[COMBO_CODE] = 0;
				dr[COMBO_NAME] = " ";
				
				dataTable.Rows.Add(dr);
				
				SetComboData(ref sList, ref dataTable);
			}
			catch
			{
			}
		}

		/// <summary>
		/// コンボボックスデータ設定
		/// </summary>
		/// <remarks>
		/// <param name="sList">ソートリスト</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスデータを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void SetComboData(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				foreach (DictionaryEntry de in sList)
				{
					DataRow dr = dataTable.NewRow();

					dr[COMBO_CODE] = (Int32)de.Key;
					dr[COMBO_NAME] = de.Value.ToString();

					dataTable.Rows.Add(dr);
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// コンボボックスバインド
		/// </summary>
		/// <remarks>
		/// <param name="tCombo">TComboEditor</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスにバインドします。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void BindCombo(ref TComboEditor tCombo, ref DataTable dataTable)
		{
			tCombo.DisplayMember = COMBO_NAME;
			tCombo.DataSource = dataTable.DefaultView;
		}

		/// <summary>
		/// 単価種類変更
		/// </summary>
		/// <param name="unitPriceKind">設定方法コード</param>
		/// <remarks>
		/// <br>Note　     : 単価種類の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void UnitPriceKindVisibleChange(int unitPriceKind)
		{
			if (this._unitPriceKindtComboEditorValue == unitPriceKind) return;

			// 入力エリアが掛率条件設定エリア以外は全て初期化する
			if (_AllCtrlInputStatus != AllCtrlInputStatus.New)
			{
				DialogResult res = TMsgDisp.Show(
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_INFO,		// エラーレベル
					ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
					ALL_DEL_MSG,						// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.YesNo, 		// 表示するボタン
					MessageBoxDefaultButton.Button2);	// 初期表示ボタン

				if (res == DialogResult.Yes)
				{
					ScreenClear();
					this.UnitPriceKind_tComboEditor.Value = unitPriceKind;
				}
				else
				{
					// 選択状態を戻す
					this.UnitPriceKind_tComboEditor.Value = _unitPriceKindtComboEditorValue;
					unitPriceKind = this._unitPriceKindtComboEditorValue;
				}
			}
			// 選択番号保持
			this._unitPriceKindtComboEditorValue = unitPriceKind;
		}

		/// <summary>
		/// 設定方法変更
		/// </summary>
		/// <param name="unitPriceKindWay">設定方法コード</param>
		/// <remarks>
		/// <br>Note　     : 設定方法の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void UnitPriceKindWayVisibleChange(int unitPriceKindWay)
		{
			if (this._unitPriceKindWaytComboEditorValue == unitPriceKindWay) return;

			// 入力エリアが掛率条件設定エリア以外は全て初期化する
			if (_AllCtrlInputStatus != AllCtrlInputStatus.New)
			{
				DialogResult res = TMsgDisp.Show(
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_INFO,		// エラーレベル
					ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
					ALL_DEL_MSG,						// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.YesNo, 		// 表示するボタン
					MessageBoxDefaultButton.Button2);	// 初期表示ボタン

				if (res == DialogResult.Yes)
				{
					ScreenClear();
					this.UnitPriceKindWay_tComboEditor.Value = unitPriceKindWay;
				}
				else
				{
					// 選択状態を戻す
					this.UnitPriceKindWay_tComboEditor.Value = _unitPriceKindWaytComboEditorValue;
					unitPriceKindWay = _unitPriceKindWaytComboEditorValue;
				}
			}

			if (unitPriceKindWay == 0)
			{
				// 単品設定
				this.Single_panel.Show();
				this.Grp_panel.Hide();
			}
			else
			{
				// 商品グループ設定
				this.Single_panel.Hide();
				this.Grp_panel.Show();
			}

			// 選択番号保持
			_unitPriceKindWaytComboEditorValue = unitPriceKindWay;
		}

		/// <summary>
		/// 自社分類変更
		/// </summary>
		/// <param name="enterpriseGanreCode">自社分類コード</param>
		/// <remarks>
		/// <br>Note　     : 自社分類の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void EnterpriseGanreCodeVisibleChange(int enterpriseGanreCode)
		{
			if(this._tempRateBlanket.EnterpriseGanreCode == enterpriseGanreCode) return;
			
			this._tempRateBlanket.EnterpriseGanreCode = enterpriseGanreCode;
		}

		/// <summary>
		/// 得意先掛率変更
		/// </summary>
		/// <param name="custRateGrpCode">得意先掛率コード</param>
		/// <remarks>
		/// <br>Note　     : 得意先掛率の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void CustRateGrpCodeVisibleChange(int custRateGrpCode)
		{
			if(this._tempRateBlanket.CustRateGrpCode == custRateGrpCode) return;
			
			this._tempRateBlanket.CustRateGrpCode = custRateGrpCode;
		}

		/// <summary>
		/// 仕入先掛率変更
		/// </summary>
		/// <param name="suppRateGrpCode">仕入先掛率コード</param>
		/// <remarks>
		/// <br>Note　     : 仕入先掛率の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void SuppRateGrpCodeVisibleChanger(int suppRateGrpCode)
		{
			if (this._tempRateBlanket.SuppRateGrpCode == suppRateGrpCode) return;

			this._tempRateBlanket.SuppRateGrpCode = suppRateGrpCode;
		}

		/// <summary>得意先情報入力データエラーチェック処理</summary>
		/// <param name="errComponent">エラー発生コンポーネント（最初のエラー位置を設定）</param>
		/// <param name="errMessage">エラーメッセージ</param>
		/// <returns>チェック結果(0:NG, 1:OK)</returns>
		/// <remarks>
		/// <br>Note       : 得意先情報入力データのエラーチェックを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private int CustInfoInpDataCheck(ref Control errComponent, ref string errMessage)
		{
			int ret = 0;

			_stringBuilder.Remove(0, _stringBuilder.Length);
			_stringBuilder.Append("以下項目は必須入力です。\n");

			// 条件部分未入力チェック

			//--------------------
			// 得意先コード
			//--------------------
			if ((this.CustomerCode_tNedit.Enabled == true)&&(this.CustomerCode_tNedit.Text == ""))
			{
				// 名称クリア
				this.CustomerCodeNm_tEdit.Clear();

				// 現在データクリア
				this._tempRateBlanket.CustomerCode = 0;
				
				_stringBuilder.Append("得意先コード\n");
				errComponent = errComponent == null ? this.CustomerCode_tNedit : errComponent;
				ret = 1;
			}

			//--------------------
			// 得意先掛率コード
			//--------------------
			// 画面上に「0」を表示させないため半角空白を設定しているので、空白削除する
			if ((this.CustRateGrpCode_tComboEditor.Enabled == true)
				&& (this.CustRateGrpCode_tComboEditor.Text.Trim() == ""))
			{
				_stringBuilder.Append("得意先掛率コード\n");
				errComponent = errComponent == null ? this.CustRateGrpCode_tComboEditor : errComponent;
				ret = 1;
			}

			//--------------------
			// 仕入先コード
			//--------------------
			if ((this.SupplierCd_tNedit.Enabled == true)&&(this.SupplierCd_tNedit.Text == ""))
			{
				// 名称クリア
				this.SupplierCdNm_tEdit.Clear();

				// 現在データクリア
				this._tempRateBlanket.SupplierCd = 0;

				_stringBuilder.Append("仕入先コード\n");
				errComponent = errComponent == null ? this.SupplierCd_tNedit : errComponent;
				ret = 1;
			}

			//--------------------
			// 仕入先掛率コード
			//--------------------
			// 画面上に「0」を表示させないため半角空白を設定しているので空白削除する
			if ((this.SuppRateGrpCode_tComboEditor.Enabled == true)
				&& (this.SuppRateGrpCode_tComboEditor.Text.Trim() == ""))
			{
				_stringBuilder.Append("仕入先掛率コード\n");
				errComponent = errComponent == null ? this.SuppRateGrpCode_tComboEditor : errComponent;
				ret = 1;
			}
			
			// エラーメッセージ設定
			errMessage = _stringBuilder.ToString();
			
			return ret;
		}

		/// <summary>商品情報設定入力データエラーチェック処理</summary>
		/// <param name="errComponent">エラー発生コンポーネント（最初のエラー位置を設定）</param>
		/// <returns>チェック結果(0:NG, 1:OK)</returns>
		/// <remarks>
		/// <br>Note       : 商品情報設定入力データのエラーチェックを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private int GoodsInfoInpDataCheck(ref Control errComponent)
		{
			int ret = 0;
			int setCnt = 0;

			string inpUnitPriceKind = RateBlanketAcs.NullChgStr(this.UnitPriceKind_tComboEditor.Value);
			string inpUnitPriceKindWay = RateBlanketAcs.NullChgStr(this.UnitPriceKindWay_tComboEditor.Value);
			string inpRateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
			string inpRateMngCustCd = this.RateMngCustCd_tEdit.Text;

			string inpChkStr = "";
			string rateChkStr = "";

			// 条件部分未入力チェック

			//--------------------
			// 商品メーカーコード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSMAKERCD, ref this._dataTableInpCond).ToString();
			rateChkStr = "";

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				if (this.GoodsMakerCd_Grp_tNedit.Text == "")
				{
					errComponent = errComponent == null ? this.GoodsMakerCd_Grp_tNedit : errComponent;
				}
				else
				{
					// 設定有り
					setCnt++;
				}
			}

			//--------------
			// 商品コード
			//--------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSNO, ref this._dataTableInpCond).ToString();
			rateChkStr = "";

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				// 必須入力
				if (this.GoodsNoCd_tEdit.Text == "")
				{
					errComponent = errComponent == null ? this.GoodsNoCd_tEdit : errComponent;
				}
				else
				{
					// 設定有り
					setCnt++;
				}
			}

			//------------------
			// 商品掛率ランク
			//------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSRATERANK, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_GOODSRATERANK, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				// 必須入力
				if (this.GoodsRateRankCd_Grp_tEdit.Text == "")
				{
					errComponent = errComponent == null ? this.GoodsRateRankCd_Grp_tEdit : errComponent;
				}
				else
				{
					// 設定有り
					setCnt++;
				}
			}

			//------------------
			// 商品区分グループコード
			//------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_LARGEGOODSGANRECODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_LARGEGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				// 必須入力
				if (this.LargeGoodsGanreCode_Grp_tEdit.Text == "")
				{
					errComponent = errComponent == null ? this.LargeGoodsGanreCode_Grp_tEdit : errComponent;
				}
				else
				{
					// 設定有り
					setCnt++;
				}
			}

			//------------------
			// 商品区分コード
			//------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_MEDIUMGOODSGANRECODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_MEDIUMGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				// 必須入力
				if (this.MediumGoodsGanreCode_Grp_tEdit.Text == "")
				{
					errComponent = errComponent == null ? this.MediumGoodsGanreCode_Grp_tEdit : errComponent;
				}
				else
				{
					// 設定有り
					setCnt++;
				}
			}

			//--------------------
			// 商品区分詳細コード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_DETAILGOODSGANRECODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_DETAILGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				// 必須入力
				if (this.DetailGoodsGanreCode_Grp_tEdit.Text == "")
				{
					errComponent = errComponent == null ? this.DetailGoodsGanreCode_Grp_tEdit : errComponent;
				}
				else
				{
					// 設定有り
					setCnt++;
				}
			}

			//--------------------
			// 自社分類コード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_ENTERPRISEGANRECODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_ENTERPRISEGANRECODE, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				// 必須入力（画面上に「0」を表示させないため半角空白を設定しているので、他とは判定方法が異なる）
				if (this.EnterpriseGanreCode_Grp_tComboEditor.Text.Trim() == "")
				{
					errComponent = errComponent == null ? this.EnterpriseGanreCode_Grp_tComboEditor : errComponent;
				}
				else
				{
					// 設定有り
					setCnt++;
				}
			}
			
			//--------------------
			// ＢＬ商品コード
			//--------------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_BLGOODSCODE, ref this._dataTableInpCond).ToString();
			rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_BLGOODSCODE, ref this._dataTableRateGoodsCond).ToString();

			// 判定
			if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
			{
				// 必須入力
				if (this.BLGoodsCode_Grp_tNedit.Text == "")
				{
					errComponent = errComponent == null ? this.BLGoodsCode_Grp_tNedit : errComponent;
				}
				else
				{
					// 設定有り
					setCnt++;
				}
			}
			
			if(setCnt == 0)
			{
				ret = 1;
			}
			
			return ret;
		}

		/// <summary>
		/// 条件チェック処理
		/// </summary>
		/// <param name="inpChkStr">入力チェック文字列</param>
		/// <param name="rateChkStr">掛率チェック文字列</param>
		/// <returns>結果文字列</returns>
		/// <remarks>
		/// <br>Note       : 条件をチェックします。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private string CheckCond(string inpChkStr, string rateChkStr)
		{
			string retStr = "0";
			
			// 入力制御チェック
			if (string.Equals(inpChkStr, "0") == false)
			{
				// 掛率チェック
				if (string.Equals(rateChkStr, "") == true)
				{
					retStr = inpChkStr;
				}
				else
				{
					if (string.Equals(rateChkStr, "0") == false)
					{
						retStr = rateChkStr;
					}
				}
			}
			return retStr;
		}

		/// <summary>掛率設定条件入力状態確認設定処理</summary>
		/// <remarks>
		/// <br>Note       : 掛率設定条件入力入力の状態確認し、現在の状態を設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void InpRateCondCheck()
		{
			// 掛率設定区分が入力されている場合
			if (this.RateSettingDivide_tEdit.Text != "")
			{
				// 入力条件制御
				SettingInpCond();

				// パネル設定
				this.Single_panel.Enabled = true;		// 単品設定パネル
				this.Grp_panel.Enabled = true;			// 商品Ｇ設定パネル
				this.Customer_panel.Enabled = true;		// 得意先設定パネル
				
				this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;
			}
			else
			{
				// パネル設定
				this.Single_panel.Enabled = false;		// 単品設定パネル
				this.Grp_panel.Enabled = false;			// 商品Ｇ設定パネル
				this.Customer_panel.Enabled = false;	// 得意先設定パネル

				this._AllCtrlInputStatus = AllCtrlInputStatus.New;
			}
		}

		#region ＜各種エラーチェック処理＞

		#region 掛率設定区分コードエラーチェック処理
		/// <summary>
		/// 掛率設定区分コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 掛率設定区分コードのエラーチェックを行います。
		///					 条件オブジェクト:拠点コード, 単価種類, 設定方法, 掛率設定区分
		///					 結果オブジェクト:掛率マスタ検索結果ステータス,
		///									  掛率設定区分コード（商品）, 掛率設定区分名称（商品）, 掛率設定区分コード（得意先）, 掛率設定区分名称（得意先）</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckRateSettingDivide(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			ArrayList inParamList = null;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is ArrayList) == false) return ret;

				inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

				if ((inParamList == null) || (inParamList.Count != 4)) return ret;
				if ((inParamList[0] is string) == false) return ret;
				if ((inParamList[1] is int) == false) return ret;
				if ((inParamList[2] is int) == false) return ret;
				if ((inParamList[3] is string) == false) return ret;
				if ((string)inParamList[3] == "") return ret;

				//--------------
				// 存在チェック
				//--------------
				RateProtyMng rateProtyMng = null;

				this.Cursor = Cursors.WaitCursor;
				status = this._rateProtyMngAcs.Read(out rateProtyMng, this._enterpriseCode,
												(string)inParamList[0], (int)inParamList[1], (int)inParamList[2], (string)inParamList[3]);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// 掛率優先管理マスタステータス設定

				if (rateProtyMng == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;

					outParamList.Add(rateProtyMng.RateMngGoodsCd.Trim());	// 掛率設定区分コード（商品）設定
					outParamList.Add(rateProtyMng.RateMngGoodsNm.Trim());	// 掛率設定区分名称（商品）設定
					outParamList.Add(rateProtyMng.RateMngCustCd.Trim());	// 掛率設定区分コード（得意先）設定
					outParamList.Add(rateProtyMng.RateMngCustNm.Trim());	// 掛率設定区分名称（得意先）設定
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion 掛率設定区分コードエラーチェック処理

		#region 商品コードエラーチェック処理
		/// <summary>
		/// 商品コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 商品コードのエラーチェックを行います。
		///					 条件オブジェクト:メーカーコード, 商品コード
		///					 結果オブジェクト:商品マスタ検索結果ステータス, 曖昧有無(0:無, 1:有), 商品名称, メーカーコード, メーカー名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckGoodsNoCd(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
			ArrayList inParamList = new ArrayList();
			
			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is ArrayList) == false) return ret;

				inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

				if ((inParamList == null) || (inParamList.Count != 2)) return ret;
				if ((inParamList[0] is int) == false) return ret;
				if ((inParamList[1] is string) == false) return ret;
				if ((string)inParamList[1] == "") return ret;

				//--------------
				// 存在チェック
				//--------------
				List<GoodsUnitData> goodsUnitDataList = null;

				// 検索の種類を取得
				string searchCode;
				int searchType = RateBlanketAcs.GetSearchType((string)inParamList[1], out searchCode);

				// 完全一致
				if (searchType == 0)
				{
					//----- ueno add ---------- start 2008.03.05
					MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

					GoodsCndtn goodsCndtn = new GoodsCndtn();

					// 商品検索条件設定
					goodsCndtn.EnterpriseCode = this._enterpriseCode;
					goodsCndtn.SectionCode = this._sectionCode;
					goodsCndtn.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
					goodsCndtn.MakerName = this.GoodsMakerCdNm_tEdit.Text;
					goodsCndtn.GoodsNo = searchCode.TrimEnd();
					goodsCndtn.GoodsNoSrchTyp = searchType;

					string message;

					// データ存在チェック
					this.Cursor = Cursors.WaitCursor;
					status = goodsSelectGuide.ReadGoods(this, false, goodsCndtn, out goodsUnitDataList, out message);
					//status = this._goodsAcs.Read(this._enterpriseCode, searchCode, out goodsUnitDataList);
					this.Cursor = Cursors.Default;
					//----- ueno add ---------- end 2008.03.05
				}
				
				outParamList.Add(status);	// 商品マスタステータス設定

				//----- ueno add ---------- start 2008.03.05
				// 曖昧フラグ設定（0:無し, 1:有り）
				int searchFlag = (searchType == 0) ? 0 : 1;
				outParamList.Add(searchFlag);
								
				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
				{
					// 商品マスタデータクラス
					GoodsUnitData goodsUnitData = new GoodsUnitData();
					goodsUnitData = goodsUnitDataList[0];
					
					outParamList.Add(goodsUnitData.GoodsName);		// 商品名称設定
					outParamList.Add(goodsUnitData.GoodsMakerCd);	// メーカーコード設定
					outParamList.Add(goodsUnitData.MakerName);		// メーカー名称設定

					ret = (int)InputChkStatus.Normal;
				}
				else if (status == -1)
				{
					// 選択ダイアログでキャンセル
					ret = (int)InputChkStatus.NotInput;
				}
				else
				{
					// 検索タイプ判定
					switch (searchType)
					{
						case 0: // 完全一致
							{
								ret = (int)InputChkStatus.NotExist;
								break;
							}
						case 1:	// 前方一致（「*」を含んだ場合正常とする）
							{
								ret = (int)InputChkStatus.Normal;
								break;
							}
						default: // その他
							{
								ret = (int)InputChkStatus.InputErr;
								break;
							}
					}
				}
				//----- ueno add ---------- end 2008.03.05

				//----- ueno del ---------- start 2008.03.05
				//if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
				//{
				//    outParamList.Add(1);	// 曖昧フラグ有り
					
				//    switch(searchType)
				//    {
				//        case 0: // 完全一致
				//            {
				//                ret = (int)InputChkStatus.NotExist;
				//                break;
				//            }
				//        case 1:	// 前方一致
				//            {
				//                ret = (int)InputChkStatus.Normal;
				//                break;
				//            }
				//        default: // その他
				//            {
				//                ret = (int)InputChkStatus.InputErr;
				//                break;
				//            }
				//    }
				//}
				//else
				//{
				//    outParamList.Add(0);	// 曖昧フラグ無し

				//    ret = (int)InputChkStatus.NotExist;

				//    foreach (GoodsUnitData wkGoodsUnitData in goodsUnitDataList)
				//    {
				//        // メーカーコードで検索
				//        if (wkGoodsUnitData.GoodsMakerCd == (int)inParamList[0])
				//        {
				//            ret = (int)InputChkStatus.Normal;

				//            outParamList.Add(wkGoodsUnitData.GoodsName);	// 商品名称設定
				//            outParamList.Add(wkGoodsUnitData.GoodsMakerCd);	// メーカーコード設定
				//            outParamList.Add(wkGoodsUnitData.MakerName);	// メーカー名称設定

				//            break;
				//        }
				//    }
				//}
				//----- ueno del ---------- end 2008.03.05
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion 商品コードエラーチェック処理

		#region メーカーコードエラーチェック処理
		/// <summary>
		/// メーカーコードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : メーカーコードのエラーチェックを行います。
		///					 条件オブジェクト:メーカーコード
		///					 結果オブジェクト:メーカーマスタ検索結果ステータス, メーカー名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckGoodsMakerCd(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is int) == false) return ret;
				if ((int)inParamObj == 0) return ret;

				//--------------
				// 存在チェック
				//--------------
				MakerUMnt makerUMnt = null;

				this.Cursor = Cursors.WaitCursor;
				status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, (int)inParamObj);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// メーカーマスタステータス設定

				if (makerUMnt == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(makerUMnt.MakerName);	// メーカー名称設定
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion メーカーコードエラーチェック処理

		#region 商品区分グループコードエラーチェック処理
		/// <summary>
		/// 商品区分グループコードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 商品区分グループコードエラーチェックを行います。
		///					 条件オブジェクト:商品区分グループコード
		///					 結果オブジェクト:商品区分グループマスタ検索結果ステータス, 商品区分グループ名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckLargeGoodsGanreCodeGrp(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is string) == false) return ret;
				if ((string)inParamObj == "") return ret;

				//--------------
				// 存在チェック
				//--------------
				LGoodsGanre lGoodsGanre = null;

				this.Cursor = Cursors.WaitCursor;
				status = this._lGoodsGanreAcs.Read(out lGoodsGanre, this._enterpriseCode, (string)inParamObj);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// 商品区分グループマスタステータス設定

				if (lGoodsGanre == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(lGoodsGanre.LargeGoodsGanreName);	// 商品区分グループ名称設定
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion 商品区分グループコードエラーチェック処理

		#region 商品区分コードエラーチェック処理
		/// <summary>
		/// 商品区分コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 商品区分コードエラーチェックを行います。
		///					 条件オブジェクト:商品区分グループコード, 商品区分コード
		///					 結果オブジェクト:商品区分マスタ検索結果ステータス, 商品区分名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckMediumGoodsGanreCodeGrp(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			ArrayList inParamList = null;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is ArrayList) == false) return ret;

				inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

				if ((inParamList == null) || (inParamList.Count != 2)) return ret;
				if ((inParamList[0] is string) == false) return ret;
				if ((inParamList[1] is string) == false) return ret;
				if ((string)inParamList[1] == "") return ret;

				//--------------
				// 存在チェック
				//--------------
				MGoodsGanre mGoodsGanre = null;

				this.Cursor = Cursors.WaitCursor;
				status = this._mGoodsGanreAcs.Read(out mGoodsGanre, this._enterpriseCode, (string)inParamList[0], (string)inParamList[1]);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// 商品区分マスタステータス設定

				if (mGoodsGanre == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(mGoodsGanre.MediumGoodsGanreName);	// 商品区分名称設定
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion 商品区分コードエラーチェック処理

		#region 商品区分詳細コードエラーチェック処理
		/// <summary>
		/// 商品区分詳細コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 商品区分詳細コードエラーチェックを行います。
		///					 条件オブジェクト:商品区分グループコード, 商品区分コード, 商品区分詳細コード
		///					 結果オブジェクト:商品区分詳細マスタ検索結果ステータス, 商品区分詳細名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckDetailGoodsGanreCodeGrp(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			ArrayList inParamList = null;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is ArrayList) == false) return ret;

				inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

				if ((inParamList == null) || (inParamList.Count != 3)) return ret;
				if ((inParamList[0] is string) == false) return ret;
				if ((inParamList[1] is string) == false) return ret;
				if ((inParamList[2] is string) == false) return ret;
				if ((string)inParamList[2] == "") return ret;

				//--------------
				// 存在チェック
				//--------------
				DGoodsGanre dGoodsGanre = null;

				this.Cursor = Cursors.WaitCursor;
				ret = this._dGoodsGanreAcs.Read(out dGoodsGanre, this._enterpriseCode, (string)inParamList[0], (string)inParamList[1], (string)inParamList[2]);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// 商品区分詳細マスタステータス設定

				if (dGoodsGanre == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(dGoodsGanre.DetailGoodsGanreName);	// 商品区分詳細名称設定
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion 商品区分詳細コードエラーチェック処理

		#region 自社分類コードエラーチェック処理
		// ユーザーガイドエラーチェック処理で行う
		#endregion 自社分類コードエラーチェック処理

		#region ＢＬ商品コードエラーチェック処理
		/// <summary>
		/// ＢＬ商品コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : ＢＬ商品コードエラーチェックを行います。
		///					 条件オブジェクト:ＢＬ商品コード
		///					 結果オブジェクト:ＢＬ商品マスタ検索結果ステータス, ＢＬ商品名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckBLGoodsCodeGrp(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is int) == false) return ret;
				if ((int)inParamObj == 0) return ret;

				//--------------
				// 存在チェック
				//--------------
				BLGoodsCdUMnt bLGoodsCdUMnt = null;

				// データ存在チェック
				this.Cursor = Cursors.WaitCursor;
				ret = this._blGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, (int)inParamObj, 0);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// ＢＬ商品マスタステータス設定

				if (bLGoodsCdUMnt == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(bLGoodsCdUMnt.BLGoodsFullName);	// ＢＬ商品名称設定
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion ＢＬ商品コードエラーチェック処理

		#region 得意先コードエラーチェック処理
		/// <summary>
		/// 得意先コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 得意先コードエラーチェックを行います。
		///					 条件オブジェクト:得意先コード
		///					 結果オブジェクト:得意先マスタ検索結果ステータス, 得意先名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckCustomerCode(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is int) == false) return ret;
				if ((int)inParamObj == 0) return ret;

				//--------------
				// 存在チェック
				//--------------
				CustomerInfo customerInfo = null;

				this.Cursor = Cursors.WaitCursor;
				ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
								(int)inParamObj, out customerInfo);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// 得意先マスタステータス設定

				// 入力データが得意先か判定
				if ((customerInfo != null) && (customerInfo.IsCustomer == true))
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(customerInfo.Name);	// 得意先名称設定
				}
				else
				{
					ret = (int)InputChkStatus.NotExist;
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion 得意先コードエラーチェック処理

		#region 得意先掛率グループエラーチェック処理
		// ユーザーガイドエラーチェック処理で行う
		#endregion 得意先掛率グループエラーチェック処理

		#region 仕入先コードエラーチェック処理
		/// <summary>
		/// 仕入先コードエラーチェック処理
		/// </summary>
		/// <param name="inParamObj">条件オブジェクト</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 仕入先コードエラーチェックを行います。
		///					 条件オブジェクト:仕入先コード
		///					 結果オブジェクト:仕入先マスタ検索結果ステータス, 仕入先名称</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckSupplierCd(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is int) == false) return ret;
				if ((int)inParamObj == 0) return ret;

                // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                ////--------------
                //// 存在チェック
                ////--------------
                //CustomerInfo customerInfo = null;

                //this.Cursor = Cursors.WaitCursor;
                //ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
                //                this.SupplierCd_tNedit.GetInt(), out customerInfo);
                //this.Cursor = Cursors.Default;

                //outParamList.Add(status);	// 仕入先マスタステータス設定

                //// 入力データが得意先か判定
                //if ((customerInfo != null) && (customerInfo.IsSupplier == true))
                //{
                //    ret = (int)InputChkStatus.Normal;
                //    outParamList.Add(customerInfo.Name);	// 仕入先名称設定
                //}
                //else
                //{
                //    ret = (int)InputChkStatus.NotExist;
                //}

                //--------------
                // 存在チェック
                //--------------
                Supplier supplier = null;

                this.Cursor = Cursors.WaitCursor;
                ret = this._supplierAcs.Read(out supplier, this._enterpriseCode, this.SupplierCd_tNedit.GetInt());
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// 仕入先マスタステータス設定

                // 入力データが得意先か判定
                if (supplier != null)
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(supplier.SupplierNm1);	// 仕入先名称設定
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion 仕入先コードエラーチェック処理

		#region 仕入先掛率グループエラーチェック処理
		// ユーザーガイドエラーチェック処理で行う
		#endregion 仕入先掛率グループエラーチェック処理

		#region 掛率開始日エラーチェック処理
		/// <summary>
		/// 掛率開始日エラーチェック処理
		/// </summary>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : 掛率開始日エラーチェックを行います。
		///					 条件オブジェクト:掛率開始日
		///					 結果オブジェクト:無し</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckRateStartDate(object inParamObj, out object outParamObj)
		{
			outParamObj = 0;	// 結果オブジェクトは未使用
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;

			ArrayList inParamList = null;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is ArrayList) == false) return ret;

				inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

				if ((inParamList == null) || (inParamList.Count != 3)) return ret;
				if ((inParamList[0] is int) == false) return ret;
				if ((inParamList[1] is int) == false) return ret;
				if ((inParamList[2] is int) == false) return ret;

				if (((int)inParamList[0] > 0) && ((int)inParamList[1] > 0) && ((int)inParamList[2] > 0))
				{
					// 入力が正しい日付か？
					int inputDate_int = ((int)inParamList[0] * 10000) + ((int)inParamList[1] * 100) + ((int)inParamList[2]);
					DateTime inputDate = TDateTime.LongDateToDateTime(inputDate_int);

					// 正しい
					if (inputDate != DateTime.MinValue)
					{
						ret = (int)InputChkStatus.Normal;
					}
					else
					{
						ret = (int)InputChkStatus.InputErr;	// 不正データ
					}
				}
			}
			catch (Exception)
			{
			}
			return ret;
		}
		#endregion 掛率開始日エラーチェック処理

		#region ユーザーガイドエラーチェック処理
		/// <summary>
		/// ユーザーガイドエラーチェック処理
		/// </summary>
		/// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
		/// <remarks>
		/// <br>Note       : ユーザーガイドのエラーチェックを行います。
		///					 条件オブジェクト:ユーザーガイドコード
		///					 結果オブジェクト:未使用</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private int CheckUserGuide(object inParamObj, out object outParamObj)
		{
			outParamObj = 0;
			int ret = (int)InputChkStatus.NotInput;

			ArrayList inParamList = null;

			try
			{
				//------------------
				// 必須入力チェック
				//------------------
				if (inParamObj == null) return ret;
				if ((inParamObj is ArrayList) == false) return ret;

				inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

				if ((inParamList == null) || (inParamList.Count != 2)) return ret;
				if ((inParamList[0] is SortedList) == false) return ret;
				if ((inParamList[1] is int) == false) return ret;

				//--------------
				// 存在チェック
				//--------------
				// 該当データが存在するか確認
				ret = (int)InputChkStatus.NotExist;

				foreach (DictionaryEntry de in (SortedList)inParamList[0])
				{
					if ((Int32)de.Key == (int)inParamList[1])
					{
						ret = (int)InputChkStatus.Normal;
						break;
					}
				}
			}
			catch (Exception)
			{
			}

			return ret;
		}
		#endregion ユーザーガイドエラーチェック処理

		#endregion ＜各種エラーチェック処理＞

		#region ＜項目データ設定処理＞

		#region 掛率設定区分設定処理
		/// <summary>
		/// 掛率設定区分設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 掛率設定区分を画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetRateSettingDivide(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							//----------------------------
							// 抽出条件初期化
							//----------------------------
							// 一時退避
							int wkUnitPriceKind = (Int32)this.UnitPriceKind_tComboEditor.Value;
							int wkUnitPriceKindWay = (Int32)this.UnitPriceKindWay_tComboEditor.Value;

							// 掛率設定区分は変更されると抽出条件が変更されるので、抽出条件を削除する
							ScreenClear();

							// ワークを設定
							this.UnitPriceKind_tComboEditor.Value = wkUnitPriceKind;
							this.UnitPriceKindWay_tComboEditor.Value = wkUnitPriceKindWay;

							// イベント停止
							this.UnitPriceKind_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
							this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);

							// コンボボックス設定
							UnitPriceKindVisibleChange((Int32)this.UnitPriceKind_tComboEditor.Value);
							UnitPriceKindWayVisibleChange((Int32)this.UnitPriceKindWay_tComboEditor.Value);

							// イベント発動
							this.UnitPriceKind_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
							this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);

							this.RateSettingDivide_tEdit.Clear();
							this.RateMngGoodsCd_tEdit.Clear();
							this.RateMngGoodsNm_tEdit.Clear();
							this.RateMngCustCd_tEdit.Clear();
							this.RateMngCustNm_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.RateSettingDivide = "";
							this._tempRateBlanket.RateMngGoodsCd = "";
							this._tempRateBlanket.RateMngGoodsNm = "";
							this._tempRateBlanket.RateMngCustCd = "";
							this._tempRateBlanket.RateMngCustNm = "";

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.RateSettingDivide_tEdit.Text = this._tempRateBlanket.RateSettingDivide;
							this.RateMngGoodsCd_tEdit.Text = this._tempRateBlanket.RateMngGoodsCd;
							this.RateMngCustCd_tEdit.Text = this._tempRateBlanket.RateMngCustCd;

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 5)
									&& (outParamList[1] is string)
									&& (outParamList[2] is string)
									&& (outParamList[3] is string)
									&& (outParamList[4] is string))
								{
									this.RateMngGoodsCd_tEdit.Text = (string)outParamList[1];	// 掛率設定区分コード（商品）
									this.RateMngGoodsNm_tEdit.Text = (string)outParamList[2];	// 掛率設定区分名称（商品）
									this.RateMngCustCd_tEdit.Text = (string)outParamList[3];	// 掛率設定区分コード（得意先）
									this.RateMngCustNm_tEdit.Text = (string)outParamList[4];	// 掛率設定区分名称（得意先）

									// 現在データ保存
									this._tempRateBlanket.RateSettingDivide = this.RateSettingDivide_tEdit.Text;
									this._tempRateBlanket.RateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
									this._tempRateBlanket.RateMngGoodsNm = this.RateMngGoodsNm_tEdit.Text;
									this._tempRateBlanket.RateMngCustCd = this.RateMngCustCd_tEdit.Text;
									this._tempRateBlanket.RateMngCustNm = this.RateMngCustNm_tEdit.Text;
								}
							}

							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 掛率設定区分設定処理

		#region 商品コード設定処理
		/// <summary>
		/// 商品コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 商品コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetGoodsNoCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.GoodsNoCd_tEdit.Clear();
							this.GoodsNoNm_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.GoodsNo = "";

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// 元に戻す
						{
							this.GoodsNoCd_tEdit.Text = this._tempRateBlanket.GoodsNo;

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;
								
								if ((outParamList != null)
									&& (outParamList.Count == 5)
									&& (outParamList[1] is int)	// 曖昧フラグ
									&& (outParamList[2] is string)
									&& (outParamList[3] is int)
									&& (outParamList[4] is string))
								{
									this.GoodsNoNm_tEdit.Text = (string)outParamList[2];		// 商品名称
									this.GoodsMakerCd_tNedit.SetInt((int)outParamList[3]);		// メーカーコード
									this.GoodsMakerCdNm_tEdit.Text = (string)outParamList[4];	// メーカー名称

									// 現在データ保存
									this._tempRateBlanket.GoodsNo = this.GoodsNoCd_tEdit.Text;
									this._tempRateBlanket.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
								}
								
								// 曖昧フラグ有無チェック
								if ((outParamList != null)&&(outParamList.Count >= 2)&&(outParamList[1] is int))
								{
									if((int)outParamList[1] == 1)
									{
										// 商品名称クリア
										this.GoodsNoNm_tEdit.Clear();
									}
								}
								
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 商品コード設定処理

		#region メーカーコード（単品）設定処理
		/// <summary>
		/// メーカーコード（単品）設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : メーカーコード（単品）を画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetGoodsMakerCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.GoodsMakerCd_tNedit.Clear();
							this.GoodsMakerCdNm_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.GoodsMakerCd = 0;

							//----- ueno add ---------- start 2008.03.05
							// 商品コードクリア
							this.GoodsNoCd_tEdit.Clear();
							this.GoodsNoNm_tEdit.Clear();
							this._tempRateBlanket.GoodsNo = "";
							//----- ueno add ---------- end 2008.03.05

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// 元に戻す
						{
							this.GoodsMakerCd_tNedit.SetInt(this._tempRateBlanket.GoodsMakerCd);

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.GoodsMakerCdNm_tEdit.Text = (string)outParamList[1];	// メーカー名称

									//----- ueno add ---------- start 2008.03.05
									//----------------------------
									// メーカーコード変更チェック
									//----------------------------
									if (this._tempRateBlanket.GoodsMakerCd != this.GoodsMakerCd_tNedit.GetInt())
									{
										// メーカーコード変更時は、商品コードクリア
										this.GoodsNoCd_tEdit.Clear();
										this.GoodsNoNm_tEdit.Clear();
										this._tempRateBlanket.GoodsNo = "";
									}
									//----- ueno add ---------- start 2008.03.05

									// 現在データ保存
									this._tempRateBlanket.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();

									//----- ueno mov ---------- start 2008.03.05
									//// メーカーに紐づく商品コード, 商品名称クリア
									//this.GoodsNoCd_tEdit.Clear();
									//this.GoodsNoNm_tEdit.Clear();
									//this._tempRateBlanket.GoodsNo = "";
									//----- ueno mov ---------- end 2008.03.05
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion メーカーコード（単品）設定処理

		#region メーカーコード設定処理
		/// <summary>
		/// メーカーコード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : メーカーコードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetGoodsMakerCdGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.GoodsMakerCd_Grp_tNedit.Clear();
							this.GoodsMakerCdNm_Grp_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.GoodsMakerCd = 0;

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// 元に戻す
						{
							this.GoodsMakerCd_Grp_tNedit.SetInt(this._tempRateBlanket.GoodsMakerCd);

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.GoodsMakerCdNm_Grp_tEdit.Text = (string)outParamList[1];	// メーカー名称

									// 現在データ保存
									this._tempRateBlanket.GoodsMakerCd = this.GoodsMakerCd_Grp_tNedit.GetInt();
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion メーカーコード設定処理

		#region 商品区分グループコード設定処理
		/// <summary>
		/// 商品区分グループコード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 商品区分グループコードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetLargeGoodsGanreCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.LargeGoodsGanreCode_Grp_tEdit.Clear();
							this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.LargeGoodsGanreCode = "";

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.LargeGoodsGanreCode_Grp_tEdit.Text = this._tempRateBlanket.LargeGoodsGanreCode;

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.LargeGoodsGanreCodeNm_Grp_tEdit.Text = (string)outParamList[1];	// 商品区分グループ名称

									// 現在データ保存
									this._tempRateBlanket.LargeGoodsGanreCode = this.LargeGoodsGanreCode_Grp_tEdit.Text;
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 商品区分グループコード設定処理

		#region 商品区分コード設定処理
		/// <summary>
		/// 商品区分コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 商品区分コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetMediumGoodsGanreCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.MediumGoodsGanreCode_Grp_tEdit.Clear();
							this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.MediumGoodsGanreCode = "";

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.MediumGoodsGanreCode_Grp_tEdit.Text = this._tempRateBlanket.MediumGoodsGanreCode;

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.MediumGoodsGanreCodeNm_Grp_tEdit.Text = (string)outParamList[1];	// 商品区分名称

									// 現在データ保存
									this._tempRateBlanket.MediumGoodsGanreCode = this.MediumGoodsGanreCode_Grp_tEdit.Text;
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 商品区分コード設定処理

		#region 商品区分詳細コード設定処理
		/// <summary>
		/// 商品区分詳細コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 商品区分詳細コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetDetailGoodsGanreCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.DetailGoodsGanreCode_Grp_tEdit.Clear();
							this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.DetailGoodsGanreCode = "";

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.DetailGoodsGanreCode_Grp_tEdit.Text = this._tempRateBlanket.DetailGoodsGanreCode;

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.DetailGoodsGanreCodeNm_Grp_tEdit.Text = (string)outParamList[1];	// 商品区分詳細名称

									// 現在データ保存
									this._tempRateBlanket.DetailGoodsGanreCode = this.DetailGoodsGanreCode_Grp_tEdit.Text;
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 商品区分詳細コード設定処理

		#region 自社分類コード設定処理
		/// <summary>
		/// 自社分類コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 自社分類コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetEnterpriseGanreCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.EnterpriseGanreCode_Grp_tComboEditor.Clear();

							// 現在データクリア
							this._tempRateBlanket.EnterpriseGanreCode = 0;

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.EnterpriseGanreCode_Grp_tComboEditor.Value = this._tempRateBlanket.EnterpriseGanreCode;

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							// 現在データ保存
							this._tempRateBlanket.EnterpriseGanreCode = (int)this.EnterpriseGanreCode_Grp_tComboEditor.Value;
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}

		#endregion 自社分類コード設定処理

		#region ＢＬ商品コード設定処理
		/// <summary>
		/// ＢＬ商品コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : ＢＬ商品コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetBLGoodsCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.BLGoodsCode_Grp_tNedit.Clear();
							this.BLGoodsCodeNm_Grp_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.BLGoodsCode = 0;

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.BLGoodsCode_Grp_tNedit.SetInt(this._tempRateBlanket.BLGoodsCode);

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.BLGoodsCodeNm_Grp_tEdit.Text = (string)outParamList[1];

									// 現在データ保存
									this._tempRateBlanket.BLGoodsCode = this.BLGoodsCode_Grp_tNedit.GetInt();
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion ＢＬ商品コード設定処理

		#region 得意先コード設定処理
		/// <summary>
		/// 得意先コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 得意先コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetCustomerCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.CustomerCode_tNedit.Clear();
							this.CustomerCodeNm_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.CustomerCode = 0;

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.CustomerCode_tNedit.SetInt(this._tempRateBlanket.CustomerCode);

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.CustomerCodeNm_tEdit.Text = (string)outParamList[1];

									// 現在データ保存
									this._tempRateBlanket.CustomerCode = this.CustomerCode_tNedit.GetInt();
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 得意先コード設定処理

		#region 得意先掛率グループ設定処理
		/// <summary>
		/// 得意先掛率グループ設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 得意先掛率グループを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetCustRateGrpCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.CustRateGrpCode_tComboEditor.Clear();

							// 現在データクリア
							this._tempRateBlanket.CustRateGrpCode = 0;

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.CustRateGrpCode_tComboEditor.Value = this._tempRateBlanket.CustRateGrpCode;

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							// 現在データ保存
							this._tempRateBlanket.CustRateGrpCode = (int)this.CustRateGrpCode_tComboEditor.Value;
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 得意先掛率グループ設定処理

		#region 仕入先コード設定処理
		/// <summary>
		/// 仕入先コード設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 仕入先コードを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetSupplierCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.SupplierCd_tNedit.Clear();
							this.SupplierCdNm_tEdit.Clear();

							// 現在データクリア
							this._tempRateBlanket.SupplierCd = 0;

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.SupplierCd_tNedit.SetInt(this._tempRateBlanket.SupplierCd);

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.SupplierCdNm_tEdit.Text = (string)outParamList[1];

									// 現在データ保存
									this._tempRateBlanket.SupplierCd = this.SupplierCd_tNedit.GetInt();
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 仕入先コード設定処理

		#region 仕入先掛率グループ設定処理
		/// <summary>
		/// 仕入先掛率グループ設定処理
		/// </summary>
		/// <param name="dispSetStatus">入力チェックフラグ</param>
		/// <param name="canChangeFocus">フォーカスフラグ</param>
		/// <param name="outParamObj">結果オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 仕入先掛率グループを画面に設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void DispSetSuppRateGrpCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// データクリア
						{
							this.SuppRateGrpCode_tComboEditor.Clear();

							// 現在データクリア
							this._tempRateBlanket.SuppRateGrpCode = 0;

							//----- ueno upd ---------- start 2008.03.07
							// フォーカス
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// 元に戻す
						{
							this.SuppRateGrpCode_tComboEditor.Value = this._tempRateBlanket.SuppRateGrpCode;

							//----- ueno add ---------- start 2008.03.07
							// フォーカス移動しない
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// 更新
						{
							// 現在データ保存
							this._tempRateBlanket.SuppRateGrpCode = (int)this.SuppRateGrpCode_tComboEditor.Value;
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion 仕入先掛率グループ設定処理

		#endregion ＜項目データ設定処理＞

		#region 条件項目チェック処理
		/// <summary>
		/// 条件項目チェック処理
		/// </summary>
		/// <returns>チェック結果(true:OK, false:NG)</returns>
		/// <remarks>
		/// <br>Note       : 条件項目に対して過不足が無いがチェックします。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private bool InpCondDataCheck()
		{
			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = null;

			bool canChangeFocus = false;
			DispSetStatus dispSetStatus = DispSetStatus.Clear;
			int status = (int)InputChkStatus.NotExist;

			//--------------
			// 掛率設定区分
			//--------------
			if ((this.RateSettingDivide_tEdit.Enabled == true) && (this.RateSettingDivide_tEdit.Text != ""))
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
				status = (int)InputChkStatus.NotExist;

				// 条件設定
				inParamList.Add(this._sectionCode);
				inParamList.Add(RateBlanketAcs.NullChgInt(this.UnitPriceKind_tComboEditor.Value));
				inParamList.Add(RateBlanketAcs.NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
				inParamList.Add(this.RateSettingDivide_tEdit.Text);
				inParamObj = inParamList;
				
				// 存在チェック
				status = CheckRateSettingDivide(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							// 値変更チェック
							if (this.RateSettingDivide_tEdit.Text != this._tempRateBlanket.RateSettingDivide)
							{
								DialogResult res = TMsgDisp.Show(
									this, 								// 親ウィンドウフォーム
									emErrorLevel.ERR_LEVEL_INFO,		// エラーレベル
									ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
									EXTRA_DEL_MSG,						// 表示するメッセージ
									0, 									// ステータス値
									MessageBoxButtons.YesNo, 			// 表示するボタン
									MessageBoxDefaultButton.Button2);	// 初期表示ボタン

								if (res == DialogResult.Yes)
								{
									//----------------------------
									// 掛率設定区分以外設定初期化
									//----------------------------
									// 一時退避
									int wkUnitPriceKind = (Int32)this.UnitPriceKind_tComboEditor.Value;
									int wkUnitPriceKindWay = (Int32)this.UnitPriceKindWay_tComboEditor.Value;
									string wkRateSettingDivide = this.RateSettingDivide_tEdit.Text;
									
									// 掛率設定区分は変更されると抽出条件が変更されるので、抽出条件を削除する
									ScreenClear();
									
									// ワークを設定
									this.UnitPriceKind_tComboEditor.Value = wkUnitPriceKind;
									this.UnitPriceKindWay_tComboEditor.Value = wkUnitPriceKindWay;
									this.RateSettingDivide_tEdit.Text = wkRateSettingDivide;

									// イベント停止
									this.UnitPriceKind_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
									this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);
									
									// コンボボックス設定
									UnitPriceKindVisibleChange((Int32)this.UnitPriceKind_tComboEditor.Value);
									UnitPriceKindWayVisibleChange((Int32)this.UnitPriceKindWay_tComboEditor.Value);
									
									// イベント発動
									this.UnitPriceKind_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
									this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);

									// データ設定（更新する）
									DispSetRateSettingDivide(DispSetStatus.Update, ref canChangeFocus, outParamObj);

									// 掛率条件入力エラーチェック（パネル入力可否設定）
									InpRateCondCheck();

									return false;
								}
								// 値を戻す
								else
								{
									// 値を戻す
									this.RateSettingDivide_tEdit.Text = this._tempRateBlanket.RateSettingDivide;
								}
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("掛率設定区分");
							dispSetStatus = this._tempRateBlanket.RateSettingDivide == "" ? DispSetStatus.Clear : DispSetStatus.Back;

							// データ設定
							DispSetRateSettingDivide(dispSetStatus, ref canChangeFocus, outParamObj);
							return false;
						}
				}
				// 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}

			//----------------
			// メーカーコード
			//----------------
			//----- ueno add ---------- start 2008.03.05
			// 商品コードチェックフラグ
			bool goodsNoCdCheckFlag = false;
			//----- ueno add ---------- end 2008.03.05
			
			// 単品設定時
			if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
			{
				if ((this.GoodsMakerCd_tNedit.Enabled == true)&&(this.GoodsMakerCd_tNedit.Text != ""))
				{
					// 条件設定クリア
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();
					dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
					status = (int)InputChkStatus.NotExist;

					// 条件設定
					inParamObj = this.GoodsMakerCd_tNedit.GetInt();

					// 存在チェック
					status = CheckGoodsMakerCd(inParamObj, out outParamObj);
					switch (status)
					{
						case (int)InputChkStatus.Normal:
						case (int)InputChkStatus.NotInput:
							{
								// 値変更チェック
								if (this.GoodsMakerCd_tNedit.GetInt() != this._tempRateBlanket.GoodsMakerCd)
								{
									dispSetStatus = editChgDataChk("メーカーコード（単品）", this.GoodsMakerCd_tNedit.GetInt(), this._tempRateBlanket.GoodsMakerCd);

									//----- ueno add ---------- start 2008.03.05
									// メーカーコードが変更されたら商品コードが削除されるため、商品コードチェックフラグＯＮ
									goodsNoCdCheckFlag = true;
									//----- ueno add ---------- end 2008.03.05									
								}
								break;
							}
						default:
							{
								ShowNotFoundErrMsg("メーカーコード（単品）");
								dispSetStatus = this._tempRateBlanket.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}

					// データ設定
					DispSetGoodsMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);

					// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
					if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
					{
						return false;
					}
				}
			}
			// グループ設定時
			else
			{
				if ((this.GoodsMakerCd_Grp_tNedit.Enabled == true)&&(GoodsMakerCd_Grp_tNedit.Text != ""))
				{
					// 条件設定クリア
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();
					dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
					status = (int)InputChkStatus.NotExist;

					// 条件設定
					inParamObj = this.GoodsMakerCd_Grp_tNedit.GetInt();

					// 存在チェック
					status = CheckGoodsMakerCd(inParamObj, out outParamObj);
					switch (status)
					{
						case (int)InputChkStatus.Normal:
						case (int)InputChkStatus.NotInput:
							{
								// 値変更チェック
								if (this.GoodsMakerCd_Grp_tNedit.GetInt() != this._tempRateBlanket.GoodsMakerCd)
								{
									dispSetStatus = editChgDataChk("メーカーコード", this.GoodsMakerCd_Grp_tNedit.GetInt(), this._tempRateBlanket.GoodsMakerCd);
								}
								break;
							}
						default:
							{
								ShowNotFoundErrMsg("メーカーコード");
								dispSetStatus = this._tempRateBlanket.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// データ設定
					DispSetGoodsMakerCdGrp(dispSetStatus, ref canChangeFocus, outParamObj);

					// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
					if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
					{
						return false;
					}
				}
			}

			//------------
			// 商品コード
			//------------
			//----- ueno upd ---------- start 2008.03.05
			if (((this.GoodsNoCd_tEdit.Enabled == true) && (this.GoodsNoCd_tEdit.Text != ""))
				|| (goodsNoCdCheckFlag == true))
			//if ((this.GoodsNoCd_tEdit.Enabled == true)&&(this.GoodsNoCd_tEdit.Text != ""))
			//----- ueno upd ---------- end 2008.03.05
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
				status = (int)InputChkStatus.NotExist;

				// 条件設定
				inParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
				inParamList.Add(this.GoodsNoCd_tEdit.Text);
				inParamObj = inParamList;

				// 存在チェック
				status = CheckGoodsNoCd(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							//----------------
							// 曖昧フラグ取得
							//----------------
							int flag = 0;
							
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								ArrayList wkOutParamList = outParamObj as ArrayList;

								if ((wkOutParamList != null) && (wkOutParamList.Count >= 2) && (wkOutParamList[1] is int))
								{
									flag = (int)wkOutParamList[1];
								}
							}
							
							// 曖昧で無い場合のみ
							if (flag == 0)
							{
								// 値変更チェック
								if (this.GoodsNoCd_tEdit.Text != this._tempRateBlanket.GoodsNo)
								{
									dispSetStatus = editChgDataChk("商品コード", this.GoodsNoCd_tEdit.Text, this._tempRateBlanket.GoodsNo);
								}
							}
							else
							{
								dispSetStatus = DispSetStatus.Update;
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("商品コード");
							dispSetStatus = this._tempRateBlanket.GoodsNo == "" ? DispSetStatus.Clear : DispSetStatus.Back;
							break;
						}
				}
				// データ設定
				DispSetGoodsNoCd(dispSetStatus, ref canChangeFocus, outParamObj);

				// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}

			//------------------------
			// 商品区分グループコード
			//------------------------
			if ((this.LargeGoodsGanreCode_Grp_tEdit.Enabled == true) && (this.LargeGoodsGanreCode_Grp_tEdit.Text != ""))
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
				status = (int)InputChkStatus.NotExist;

				// 条件設定
				inParamObj = this.LargeGoodsGanreCode_Grp_tEdit.Text;

				// 存在チェック
				status = CheckLargeGoodsGanreCodeGrp(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							// 値変更チェック
							if (this.LargeGoodsGanreCode_Grp_tEdit.Text != this._tempRateBlanket.LargeGoodsGanreCode)
							{
								dispSetStatus = editChgDataChk("商品区分グループコード", this.LargeGoodsGanreCode_Grp_tEdit.Text, this._tempRateBlanket.LargeGoodsGanreCode);
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("商品区分グループコード");
							dispSetStatus = this._tempRateBlanket.LargeGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
							break;
						}
				}
				// データ設定
				DispSetLargeGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);

				// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}

			//----------------
			// 商品区分コード
			//----------------
			if ((this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true) && (this.MediumGoodsGanreCode_Grp_tEdit.Text != ""))
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用

				// 条件設定
				inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
				inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
				inParamObj = inParamList;
				status = (int)InputChkStatus.NotExist;

				// 存在チェック
				status = CheckMediumGoodsGanreCodeGrp(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							// 値変更チェック
							if (this.MediumGoodsGanreCode_Grp_tEdit.Text != this._tempRateBlanket.MediumGoodsGanreCode)
							{
								dispSetStatus = editChgDataChk("商品区分コード", this.MediumGoodsGanreCode_Grp_tEdit.Text, this._tempRateBlanket.MediumGoodsGanreCode);
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("商品区分コード");
							dispSetStatus = this._tempRateBlanket.MediumGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
							break;

						}
				}
				// データ設定
				DispSetMediumGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);

				// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}

			//--------------------
			// 商品区分詳細コード
			//--------------------
			if ((this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true) && (this.DetailGoodsGanreCode_Grp_tEdit.Text != ""))
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
				status = (int)InputChkStatus.NotExist;

				// 条件設定
				inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
				inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
				inParamList.Add(this.DetailGoodsGanreCode_Grp_tEdit.Text);
				inParamObj = inParamList;

				// 存在チェック
				status = CheckDetailGoodsGanreCodeGrp(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							// 値変更チェック
							if (this.DetailGoodsGanreCode_Grp_tEdit.Text != this._tempRateBlanket.DetailGoodsGanreCode)
							{
								dispSetStatus = editChgDataChk("商品区分詳細コード", this.DetailGoodsGanreCode_Grp_tEdit.Text, this._tempRateBlanket.DetailGoodsGanreCode);
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("商品区分詳細コード");
							dispSetStatus = this._tempRateBlanket.DetailGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
							break;
						}
				}
				// データ設定
				DispSetDetailGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);

				// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}

			//----------------
			// 自社分類コード
			//----------------
			if ((this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true) && (this.EnterpriseGanreCode_Grp_tComboEditor.Value != null))
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
				status = (int)InputChkStatus.NotExist;

				// 条件設定
				inParamList.Add(this._enterpriseGanreCodeSList);
				inParamList.Add((int)this.EnterpriseGanreCode_Grp_tComboEditor.Value);
				inParamObj = inParamList;

				// 存在チェック
				status = CheckUserGuide(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							// 値変更チェック
							if ((int)this.EnterpriseGanreCode_Grp_tComboEditor.Value != this._tempRateBlanket.EnterpriseGanreCode)
							{
								dispSetStatus = editChgDataChk("自社分類コード", this.EnterpriseGanreCode_Grp_tComboEditor.Value.ToString(), this._tempRateBlanket.EnterpriseGanreCode);
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("自社分類コード");
							dispSetStatus = this._tempRateBlanket.EnterpriseGanreCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
							break;
						}
				}
				// データ設定
				DispSetEnterpriseGanreCode(dispSetStatus, ref canChangeFocus, outParamObj);

				// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}

			//----------------
			// ＢＬ商品コード
			//----------------
			if ((this.BLGoodsCode_Grp_tNedit.Enabled == true) && (this.BLGoodsCode_Grp_tNedit.Text != ""))
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
				status = (int)InputChkStatus.NotExist;

				// 条件設定
				inParamObj = this.BLGoodsCode_Grp_tNedit.GetInt();

				// 存在チェック
				status = CheckBLGoodsCodeGrp(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							// 値変更チェック
							if (this.BLGoodsCode_Grp_tNedit.GetInt() != this._tempRateBlanket.BLGoodsCode)
							{
								dispSetStatus = editChgDataChk("ＢＬ商品コード", this.BLGoodsCode_Grp_tNedit.GetInt(), this._tempRateBlanket.BLGoodsCode);
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("ＢＬ商品コード");
							dispSetStatus = this._tempRateBlanket.BLGoodsCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
							break;
						}
				}
				// データ設定
				DispSetBLGoodsCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);

				// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}

			//----------------
			// 得意先コード
			//----------------
			if ((this.CustomerCode_tNedit.Enabled == true) && (this.CustomerCode_tNedit.Text != ""))
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
				status = (int)InputChkStatus.NotExist;

				// 条件設定
				inParamObj = this.CustomerCode_tNedit.GetInt();

				// 存在チェック
				status = CheckCustomerCode(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							// 値変更チェック
							if (this.CustomerCode_tNedit.GetInt() != this._tempRateBlanket.CustomerCode)
							{
								dispSetStatus = editChgDataChk("得意先コード", this.CustomerCode_tNedit.GetInt(), this._tempRateBlanket.CustomerCode);
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("得意先コード");
							dispSetStatus = this._tempRateBlanket.CustomerCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
							break;
						}
				}
				// データ設定
				DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);

				// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}

			//--------------------
			// 得意先掛率グループ
			//--------------------
			if ((this.CustRateGrpCode_tComboEditor.Enabled == true) && (this.CustRateGrpCode_tComboEditor.Value != null))
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
				status = (int)InputChkStatus.NotExist;

				// 条件設定
				inParamList.Add(this._custRateGrpCodeSList);
				inParamList.Add((int)this.CustRateGrpCode_tComboEditor.Value);
				inParamObj = inParamList;

				// 存在チェック
				status = CheckUserGuide(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							// 値変更チェック
							if ((int)this.CustRateGrpCode_tComboEditor.Value != this._tempRateBlanket.CustRateGrpCode)
							{
								dispSetStatus = editChgDataChk("得意先掛率グループ", this.CustRateGrpCode_tComboEditor.Value.ToString(), this._tempRateBlanket.CustRateGrpCode);
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("得意先掛率グループ");
							dispSetStatus = this._tempRateBlanket.CustRateGrpCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
							break;
						}
				}
				// データ設定
				DispSetCustRateGrpCode(dispSetStatus, ref canChangeFocus, outParamObj);

				// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}

			//----------------
			// 仕入先コード
			//----------------
			if ((this.SupplierCd_tNedit.Enabled == true) && (this.SupplierCd_tNedit.Text != ""))
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
				status = (int)InputChkStatus.NotExist;

				// 条件設定
				inParamObj = this.SupplierCd_tNedit.GetInt();

				// 存在チェック
				status = CheckSupplierCd(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							// 値変更チェック
							if (this.SupplierCd_tNedit.GetInt() != this._tempRateBlanket.SupplierCd)
							{
								dispSetStatus = editChgDataChk("仕入先コード", this.SupplierCd_tNedit.GetInt(), this._tempRateBlanket.SupplierCd);
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("仕入先コード");
							dispSetStatus = this._tempRateBlanket.SupplierCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
							break;
						}
				}
				// データ設定
				DispSetSupplierCd(dispSetStatus, ref canChangeFocus, outParamObj);

				// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}

			//--------------------
			// 仕入先掛率グループ
			//--------------------
			if ((this.SuppRateGrpCode_tComboEditor.Enabled == true) && (this.SuppRateGrpCode_tComboEditor.Value != null))
			{
				// 条件設定クリア
				inParamObj = null;
				outParamObj = null;
				inParamList = new ArrayList();
				dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
				status = (int)InputChkStatus.NotExist;

				// 条件設定
				inParamList.Add(this._suppRateGrpCodeSList);
				inParamList.Add((int)this.SuppRateGrpCode_tComboEditor.Value);
				inParamObj = inParamList;

				// 存在チェック
				status = CheckUserGuide(inParamObj, out outParamObj);
				switch (status)
				{
					case (int)InputChkStatus.Normal:
					case (int)InputChkStatus.NotInput:
						{
							// 値変更チェック
							if ((int)this.SuppRateGrpCode_tComboEditor.Value != this._tempRateBlanket.SuppRateGrpCode)
							{
								dispSetStatus = editChgDataChk("仕入先掛率グループ", this.SuppRateGrpCode_tComboEditor.Value.ToString(), this._tempRateBlanket.SuppRateGrpCode);
							}
							break;
						}
					default:
						{
							ShowNotFoundErrMsg("仕入先掛率グループ");
							dispSetStatus = this._tempRateBlanket.SuppRateGrpCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
							break;
						}
				}
				// データ設定
				DispSetSuppRateGrpCode(dispSetStatus, ref canChangeFocus, outParamObj);

				// 値を削除する場合、または、存在チェックがエラーの場合は以下の処理に進まない
				if ((dispSetStatus == DispSetStatus.Clear) || (status != (int)InputChkStatus.Normal))
				{
					return false;
				}
			}
		    return true;
		}

		#endregion 条件項目チェック処理


		#region エディット項目データ変更チェック
		/// <summary>
		/// エディット項目データ変更チェック
		/// </summary>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <param name="editText">項目オブジェクト</param>
		/// <param name="preObj">前回項目文字列</param>
		/// <returns>チェック結果（0:変更無し, 1:存在しない, 2:変更有り）</returns>
		/// <remarks>
		/// <br>Note		: 画面項目テキストのデータ変更チェックを行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.11.02</br>
		/// </remarks>
		private DispSetStatus editChgDataChk(string errMsg, object editText, object preObj)
		{
			DispSetStatus inputChkRet = DispSetStatus.Clear;

			// 入力有無で返却値変更
			if (editText is string)
			{
				inputChkRet = (string)editText == "" ? DispSetStatus.Clear : DispSetStatus.Update;
			}
			else if (editText is int)
			{
				inputChkRet = (int)editText == 0 ? DispSetStatus.Clear : DispSetStatus.Update;
			}
			return inputChkRet;
		}
		#endregion エディット項目データ変更チェック

		#region ガイドメソッド

		/// <summary>
		/// メーカーコードガイド起動処理
		/// </summary>
		/// <param name="wkGoodsMakerCd_tNedit">メーカーコード</param>
		/// <param name="wkGoodsMakerCdNm_tEdit">メーカーコード名称</param>
		/// <remarks>
		/// <br>Note       : メーカーコードガイドを起動します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GoodsMakerCdGuide(ref TNedit wkGoodsMakerCd_tNedit, ref TEdit wkGoodsMakerCdNm_tEdit)
		{
			MakerUMnt makerUMnt = null;

			//----------------------
			// メーカーコードガイド
			//----------------------
			if (this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
			{
				wkGoodsMakerCd_tNedit.SetInt(makerUMnt.GoodsMakerCd);
				wkGoodsMakerCdNm_tEdit.Text = makerUMnt.MakerShortName;

				// 現在データ保存
				this._tempRateBlanket.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
			}
		}

		/// <summary>
		/// メーカーコードガイド（商品コード検索有）起動処理
		/// </summary>
		/// <param name="wkGoodsMakerCd_tNedit">メーカーコード</param>
		/// <param name="wkGoodsMakerCdNm_tEdit">メーカーコード名称</param>
		/// <param name="wkGoodsNoCd_tEdit">商品コード</param>
		/// <param name="wkGoodsNoNm_tEdit">商品コード名称</param>
		/// <remarks>
		/// <br>Note       : メーカーコードガイドを起動します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GoodsMakerCdGuide(	ref TNedit wkGoodsMakerCd_tNedit,	ref TEdit wkGoodsMakerCdNm_tEdit,
										ref TEdit wkGoodsNoCd_tEdit,		ref TEdit wkGoodsNoNm_tEdit)
		{
			MakerUMnt makerUMnt = null;
			
			//----------------------
			// メーカーコードガイド
			//----------------------
			if (this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
			{
				// 変更が有る場合
				if (makerUMnt.GoodsMakerCd != this._tempRateBlanket.GoodsMakerCd)
				{
					// メーカーに紐づく商品コード, 商品名称クリア
					this.GoodsNoCd_tEdit.Clear();
					this.GoodsNoNm_tEdit.Clear();
					this._tempRateBlanket.GoodsNo = "";
				}

				wkGoodsMakerCd_tNedit.SetInt(makerUMnt.GoodsMakerCd);
				wkGoodsMakerCdNm_tEdit.Text = makerUMnt.MakerShortName;

				// 現在データ保存
				this._tempRateBlanket.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();

				// 商品コードガイド
				GoodsNoGuide(	ref wkGoodsMakerCd_tNedit,	ref wkGoodsMakerCdNm_tEdit,
								ref wkGoodsNoCd_tEdit,		ref wkGoodsNoNm_tEdit);
			}
		}

		/// <summary>
		/// 商品コードガイド起動処理
		/// </summary>
		/// <param name="wkGoodsMakerCd_tNedit">メーカーコード</param>
		/// <param name="wkGoodsMakerCdNm_tEdit">メーカーコード名称</param>
		/// <param name="wkGoodsNoCd_tEdit">商品コード</param>
		/// <param name="wkGoodsNoNm_tEdit">商品コード名称</param>
		/// <remarks>
		/// <br>Note       : 商品コードガイドを起動します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GoodsNoGuide(	ref TNedit wkGoodsMakerCd_tNedit,	ref TEdit wkGoodsMakerCdNm_tEdit,
									ref TEdit wkGoodsNoCd_tEdit,		ref TEdit wkGoodsNoNm_tEdit)
		{
			MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
			GoodsUnitData goodsUnitData = null;
			GoodsCndtn goodsCndtn = new GoodsCndtn();
			goodsCndtn.EnterpriseCode = this._enterpriseCode;

			//----- ueno add ---------- start 2008.03.04
			bool autoSearch = false;
			//----- ueno add ---------- end 2008.03.04

			//------------------
			// 商品コードガイド
			//------------------
			if (wkGoodsMakerCd_tNedit.Text != "")
			{
				// メーカーコード設定
				goodsCndtn.GoodsMakerCd = wkGoodsMakerCd_tNedit.GetInt();

				//----- ueno add ---------- start 2008.03.04
				// メーカー名称設定
				goodsCndtn.MakerName = wkGoodsMakerCdNm_tEdit.Text.TrimEnd();
				autoSearch = true;
				//----- ueno add ---------- end 2008.03.04
			}

			//----- ueno add ---------- start 2008.03.04
			// 検索条件に拠点をセット
			if (this._sectionCode != "")
			{
				goodsCndtn.SectionCode = this._sectionCode;
			}
			//----- ueno add ---------- end 2008.03.04

			//----- ueno upd ---------- start 2008.03.04
			// 自動検索はメーカーコードが存在する場合のみとする
			DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, autoSearch, goodsCndtn, out goodsUnitData);
			//DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, goodsCndtn, out goodsUnitData);
			//----- ueno upd ---------- end 2008.03.04

			if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
			{
				// 変更が無ければ処理しない
				if (string.Equals(goodsUnitData.GoodsNo, this._tempRateBlanket.GoodsNo) == true)
				{
					return;
				}

				// 商品コード設定
				wkGoodsNoCd_tEdit.Text = goodsUnitData.GoodsNo;
				wkGoodsNoNm_tEdit.Text = goodsUnitData.GoodsName;

				// 現在データ保存
				this._tempRateBlanket.GoodsNo = this.GoodsNoCd_tEdit.Text;

				//--------------------------------------
				// 商品コードに対するメーカーコード設定
				//--------------------------------------
				MakerUMnt makerUMnt = null;

				// データ存在チェック
				int ret = this._goodsAcs.GetMaker(this._enterpriseCode, goodsUnitData.GoodsMakerCd, out makerUMnt);

				if (ret == 0)
				{
					// メーカーコード設定
					wkGoodsMakerCd_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
					wkGoodsMakerCdNm_tEdit.Text = makerUMnt.MakerName;

					// 現在データ保存
					this._tempRateBlanket.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
				}
			}
		}

		/// <summary>
		/// 商品区分Ｇガイド起動処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 商品区分Ｇガイドを起動します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void LargeGoodsGanreCodeGuide()
		{
			LGoodsGanre lGoodsGanre = null;

			if (this._lGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out lGoodsGanre, 1) == 0)
			{
				// 変更が無ければ処理しない
				if (string.Equals(lGoodsGanre.LargeGoodsGanreCode, this._tempRateBlanket.LargeGoodsGanreCode) == true)
				{
					return;
				}

				// 商品区分Ｇ
				this.LargeGoodsGanreCode_Grp_tEdit.Text = lGoodsGanre.LargeGoodsGanreCode;
				this.LargeGoodsGanreCodeNm_Grp_tEdit.Text = lGoodsGanre.LargeGoodsGanreName;

				// 現在データ保存
				this._tempRateBlanket.LargeGoodsGanreCode = this.LargeGoodsGanreCode_Grp_tEdit.Text;

				// 商品区分が入力可の場合
				if(this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true)
				{
					// 商品区分ガイド起動
					MediumGoodsGanreCodeGuide();
				}
			}
			else
			{
				// 商品区分Ｇクリア
				this.LargeGoodsGanreCode_Grp_tEdit.Clear();
				this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();

				// 現在データクリア
				this._tempRateBlanket.LargeGoodsGanreCode = "";
			}
		}

		/// <summary>
		/// 商品区分ガイド起動処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 商品区分ガイドを起動します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void MediumGoodsGanreCodeGuide()
		{
			MGoodsGanre mGoodsGanre = null;
			string lGoodsGanre = this.LargeGoodsGanreCode_Grp_tEdit.Text;	// 大分類設定

			if (this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, lGoodsGanre, out mGoodsGanre, 1) == 0)
			{
				// 変更が無ければ処理しない
				if (string.Equals(mGoodsGanre.MediumGoodsGanreCode, this._tempRateBlanket.MediumGoodsGanreCode) == true)
				{
					return;
				}

				// 商品区分
				this.MediumGoodsGanreCode_Grp_tEdit.Text = mGoodsGanre.MediumGoodsGanreCode;
				this.MediumGoodsGanreCodeNm_Grp_tEdit.Text = mGoodsGanre.MediumGoodsGanreName;

				// 現在データ保存
				this._tempRateBlanket.MediumGoodsGanreCode = this.MediumGoodsGanreCode_Grp_tEdit.Text;

				// 商品区分詳細コードが入力可の場合
				if(this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true)
				{
					// 商品区分詳細ガイド起動
					DetailGoodsGanreCodeGuide();
				}
			}
			else
			{
				// 商品区分クリア
				this.MediumGoodsGanreCode_Grp_tEdit.Clear();
				this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();

				// 商品区分詳細クリア
				this.DetailGoodsGanreCode_Grp_tEdit.Clear();
				this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();

				// 現在データクリア
				this._tempRateBlanket.MediumGoodsGanreCode = "";
				this._tempRateBlanket.DetailGoodsGanreCode = "";
			}
		}

		/// <summary>
		/// 商品区分詳細ガイド起動処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 商品区分詳細ガイドを起動します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void DetailGoodsGanreCodeGuide()
		{
			DGoodsGanre dGoodsGanre = null;

			if (this._dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre, 1) == 0)
			{
				// 変更が無ければ処理しない
				if (string.Equals(dGoodsGanre.DetailGoodsGanreCode, this._tempRateBlanket.DetailGoodsGanreCode) == true)
				{
					return;
				}

				// 商品区分Ｇ
				this.LargeGoodsGanreCode_Grp_tEdit.Text = dGoodsGanre.LargeGoodsGanreCode;
				this.LargeGoodsGanreCodeNm_Grp_tEdit.Text = dGoodsGanre.LargeGoodsGanreName;
				// 商品区分
				this.MediumGoodsGanreCode_Grp_tEdit.Text = dGoodsGanre.MediumGoodsGanreCode;
				this.MediumGoodsGanreCodeNm_Grp_tEdit.Text = dGoodsGanre.MediumGoodsGanreName;
				// 商品区分詳細
				this.DetailGoodsGanreCode_Grp_tEdit.Text = dGoodsGanre.DetailGoodsGanreCode;
				this.DetailGoodsGanreCodeNm_Grp_tEdit.Text = dGoodsGanre.DetailGoodsGanreName;

				// 現在データ保存
				this._tempRateBlanket.LargeGoodsGanreCode = this.LargeGoodsGanreCode_Grp_tEdit.Text;
				this._tempRateBlanket.MediumGoodsGanreCode = this.MediumGoodsGanreCode_Grp_tEdit.Text;
				this._tempRateBlanket.DetailGoodsGanreCode = this.DetailGoodsGanreCode_Grp_tEdit.Text;
			}
			else
			{
				// 商品区分詳細クリア
				this.DetailGoodsGanreCode_Grp_tEdit.Clear();
				this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();

				// 現在データクリア
				this._tempRateBlanket.DetailGoodsGanreCode = "";
			}
		}
		
		#endregion ガイドメソッド

		#endregion Private Method

		// ===================================================================================== //
		// コントロールイベント
		// ===================================================================================== //
		#region Control Events
		/// <summary>
		/// DCKHN09180UA_Load
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note       : ユーザーがフォームを読み込むときに発生する</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void DCKHN09180UA_Load ( object sender, EventArgs e )
		{
			//----------------
			// ボタン関連設定
			//----------------
			// ボタンアイコン設定
			this.SetButtonImage(this.RateSettingDivide_uButton, Size16_Index.STAR1);
			this.SetButtonImage(this.GoodsMakerCd_uButton, Size16_Index.STAR1);
			this.SetButtonImage(this.GoodsNo_uButton, Size16_Index.STAR1);
			this.SetButtonImage(this.GoodsMakerCd_Grp_uButton, Size16_Index.STAR1);
			this.SetButtonImage(this.LargeGoodsGanreCode_Grp_uButton, Size16_Index.STAR1);
			this.SetButtonImage(this.MediumGoodsGanreCode_Grp_uButton, Size16_Index.STAR1);
			this.SetButtonImage(this.DetailGoodsGanreCode_Grp_uButton, Size16_Index.STAR1);
			this.SetButtonImage(this.BLGoodsCode_Grp_uButton, Size16_Index.STAR1);
			this.SetButtonImage(this.CustomerCode_uButton, Size16_Index.STAR1);
			this.SetButtonImage(this.SupplierCd_uButton, Size16_Index.STAR1);

			// 画面イメージ統一
			this._controlScreenSkin.LoadSkin();						// 画面スキンファイルの読込(デフォルトスキン指定)
			this._controlScreenSkin.SettingScreenSkin(this);		// 画面スキン変更
			
			// 画面初期設定
			ScreenInitialSetting();
			
			// 画面クリア
			ScreenClear();
			
			tm_InitialTimer.Enabled = true;
		}

		/// <summary>Control.ChangeFocus イベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォーカス移動時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
		    if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

			Control NextCtrl = e.NextCtrl;
			ControlChangeFocus(sender, e.PrevCtrl, ref NextCtrl, e.Key, e.ShiftKey);
			e.NextCtrl = NextCtrl;
		}

		/// <summary>ControlChangeFocus</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="prevCtrl">前のコントロール</param>
		/// <param name="nextCtrl">次のコントロール</param>
		/// <param name="key">キー</param>
		/// <param name="shiftKey">シフトキー</param>
		/// <remarks>
		/// <br>Note       : Control.ChangeFocusイベント発生時に処理します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.09</br>
		/// </remarks>
		private void ControlChangeFocus(object sender, Control prevCtrl, ref Control nextCtrl, Keys key, bool shiftKey)
		{
		    bool canChangeFocus = true;
			DispSetStatus dispSetStatus = DispSetStatus.Clear;
			
			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = new ArrayList();
			
			switch (prevCtrl.Name)
			{
				//------------------
				// 掛率設定条件部分
				//------------------
				#region case 単価種類
				case "UnitPriceKind_tComboEditor":
					{
						if (this.UnitPriceKind_tComboEditor.Value != null)
						{
							// イベント停止
							this.UnitPriceKind_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);

							UnitPriceKindVisibleChange((Int32)this.UnitPriceKind_tComboEditor.Value);

							// イベント発動
							this.UnitPriceKind_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
						}

						// 掛率条件入力エラーチェック
						InpRateCondCheck();
						break;
					}
				#endregion

				#region case 設定方法
				case "UnitPriceKindWay_tComboEditor":
					{
						if (this.UnitPriceKindWay_tComboEditor.Value != null)
						{
							// イベント停止
							this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);

							UnitPriceKindWayVisibleChange((Int32)this.UnitPriceKindWay_tComboEditor.Value);

							// イベント発動
							this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);
						}

						// 掛率条件入力エラーチェック
						InpRateCondCheck();
						break;
					}
				#endregion

				#region case 掛率設定区分
				case "RateSettingDivide_tEdit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.RateSettingDivide_tEdit.Text == "") && (this._tempRateBlanket.RateSettingDivide == ""))
						{
							break;
						}
					
						//// 変更が無ければ処理しない
						//if (string.Equals(this.RateSettingDivide_tEdit.Text, this._tempRateBlanket.RateSettingDivide) == true)
						//{
						//    break;
						//}

						// 条件設定
						inParamList.Add(this._sectionCode);
						inParamList.Add(RateBlanketAcs.NullChgInt(this.UnitPriceKind_tComboEditor.Value));
						inParamList.Add(RateBlanketAcs.NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
						inParamList.Add(this.RateSettingDivide_tEdit.Text);
						inParamObj = inParamList;

						// 存在チェック
						switch (CheckRateSettingDivide(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("掛率設定区分");
									dispSetStatus = this._tempRateBlanket.RateSettingDivide == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetRateSettingDivide(dispSetStatus, ref canChangeFocus, outParamObj);

						// 掛率条件入力エラーチェック
						InpRateCondCheck();
						break;
					}
				#endregion

				//------------------------------
				// 単品, Ｇ商品, 取引先条件部分
				//------------------------------
				#region case メーカーコード（単品）
				case "GoodsMakerCd_tNedit":
					{
						// ゼロデータチェック処理
						if ((this.GoodsMakerCd_tNedit.Text != "") && (this.GoodsMakerCd_tNedit.GetInt() == 0))
						{
							if (this._tempRateBlanket.GoodsMakerCd == 0)
							{
								this.GoodsMakerCd_tNedit.Clear();
								canChangeFocus = false;
							}
							else
							{
								this.GoodsMakerCd_tNedit.SetInt(this._tempRateBlanket.GoodsMakerCd);
							}
							break;
						}

						// 変更が無ければ処理しない
						if (this.GoodsMakerCd_tNedit.GetInt() == this._tempRateBlanket.GoodsMakerCd)
						{
							break;
						}

						// 条件設定
						inParamObj = this.GoodsMakerCd_tNedit.GetInt();

						// 存在チェック
						switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("メーカーコード（単品）");
									dispSetStatus = this._tempRateBlanket.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetGoodsMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case メーカーコード
				case "GoodsMakerCd_Grp_tNedit":
					{
						// ゼロデータチェック処理
						if ((this.GoodsMakerCd_Grp_tNedit.Text != "") && (this.GoodsMakerCd_Grp_tNedit.GetInt() == 0))
						{
							if (this._tempRateBlanket.GoodsMakerCd == 0)
							{
								this.GoodsMakerCd_Grp_tNedit.Clear();
								canChangeFocus = false;
							}
							else
							{
								this.GoodsMakerCd_Grp_tNedit.SetInt(this._tempRateBlanket.GoodsMakerCd);
							}
							break;
						}

						// 変更が無ければ処理しない
						if (this.GoodsMakerCd_Grp_tNedit.GetInt() == this._tempRateBlanket.GoodsMakerCd)
						{
							break;
						}

						// 条件設定
						inParamObj = this.GoodsMakerCd_Grp_tNedit.GetInt();

						// 存在チェック
						switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("メーカーコード");
									dispSetStatus = this._tempRateBlanket.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetGoodsMakerCdGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 商品コード
				case "GoodsNoCd_tEdit":
					{
						// 変更が無ければ処理しない
						if (string.Equals(this.GoodsNoCd_tEdit.Text, this._tempRateBlanket.GoodsNo) == true)
						{
							break;
						}

						// 条件設定
						inParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
						inParamList.Add(this.GoodsNoCd_tEdit.Text);
						inParamObj = inParamList;

						// 存在チェック
						switch (CheckGoodsNoCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							case (int)InputChkStatus.InputErr:
								{
									dispSetStatus = DispSetStatus.Clear;
									ShowInpErrMsg("商品コードに'*'を付ける場合は、前方一致で設定してください。");
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("商品コード");
									dispSetStatus = this._tempRateBlanket.GoodsNo == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetGoodsNoCd(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 商品掛率ランク エラーチェック不要
				#endregion

				#region case 商品区分グループコード
				case "LargeGoodsGanreCode_Grp_tEdit":
					{
						// 変更が無ければ処理しない
						if (string.Equals(this.LargeGoodsGanreCode_Grp_tEdit.Text, this._tempRateBlanket.LargeGoodsGanreCode) == true)
						{
							break;
						}

						// 条件設定
						inParamObj = this.LargeGoodsGanreCode_Grp_tEdit.Text;

						// 存在チェック
						switch (CheckLargeGoodsGanreCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("商品区分グループコード");
									dispSetStatus = this._tempRateBlanket.LargeGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetLargeGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 商品区分コード
				case "MediumGoodsGanreCode_Grp_tEdit":
					{
						// 変更が無ければ処理しない
						if (string.Equals(this.MediumGoodsGanreCode_Grp_tEdit.Text, this._tempRateBlanket.MediumGoodsGanreCode) == true)
						{
							break;
						}

						// 条件設定
						inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
						inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
						inParamObj = inParamList;

						// 存在チェック
						switch (CheckMediumGoodsGanreCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("商品区分コード");
									dispSetStatus = this._tempRateBlanket.MediumGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetMediumGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 商品区分詳細コード
				case "DetailGoodsGanreCode_Grp_tEdit":
					{
						// 変更が無ければ処理しない
						if (string.Equals(this.DetailGoodsGanreCode_Grp_tEdit.Text, this._tempRateBlanket.DetailGoodsGanreCode) == true)
						{
							break;
						}

						// 条件設定
						inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
						inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
						inParamList.Add(this.DetailGoodsGanreCode_Grp_tEdit.Text);
						inParamObj = inParamList;

						// 存在チェック
						switch (CheckDetailGoodsGanreCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("商品区分詳細コード");
									dispSetStatus = this._tempRateBlanket.DetailGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetDetailGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 自社分類コード（エラーチェック無し）
				case "EnterpriseGanreCode_Grp_tComboEditor":
					{
						if (this.EnterpriseGanreCode_Grp_tComboEditor.Value != null)
						{
							EnterpriseGanreCodeVisibleChange((Int32)this.EnterpriseGanreCode_Grp_tComboEditor.Value);
						}
						break;
					}
				#endregion

				#region case ＢＬ商品コード
				case "BLGoodsCode_Grp_tNedit":
					{
						// ゼロデータチェック処理
						if ((this.BLGoodsCode_Grp_tNedit.Text != "") && (this.BLGoodsCode_Grp_tNedit.GetInt() == 0))
						{
							if (this._tempRateBlanket.BLGoodsCode == 0)
							{
								this.BLGoodsCode_Grp_tNedit.Clear();
								canChangeFocus = false;
							}
							else
							{
								this.BLGoodsCode_Grp_tNedit.SetInt(this._tempRateBlanket.BLGoodsCode);
							}
							break;
						}

						// 変更が無ければ処理しない
						if (this.BLGoodsCode_Grp_tNedit.GetInt() == this._tempRateBlanket.BLGoodsCode)
						{
							break;
						}

						// 条件設定
						inParamObj = this.BLGoodsCode_Grp_tNedit.GetInt();

						// 存在チェック
						switch (CheckBLGoodsCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("ＢＬ商品コード");
									dispSetStatus = this._tempRateBlanket.BLGoodsCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetBLGoodsCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 得意先コード
				case "CustomerCode_tNedit":
					{
						// ゼロデータチェック処理
						if ((this.CustomerCode_tNedit.Text != "") && (this.CustomerCode_tNedit.GetInt() == 0))
						{
							if (this._tempRateBlanket.CustomerCode == 0)
							{
								this.CustomerCode_tNedit.Clear();
								canChangeFocus = false;
							}
							else
							{
								this.CustomerCode_tNedit.SetInt(this._tempRateBlanket.CustomerCode);
							}
							break;
						}

						// 変更が無ければ処理しない
						if (this.CustomerCode_tNedit.GetInt() == this._tempRateBlanket.CustomerCode)
						{
							break;
						}

						// 条件設定
						inParamObj = this.CustomerCode_tNedit.GetInt();

						// 存在チェック
						switch (CheckCustomerCode(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("得意先コード");
									dispSetStatus = this._tempRateBlanket.CustomerCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 得意先掛率グループコード
				case "CustRateGrpCode_tComboEditor":
					{
						if (this.CustRateGrpCode_tComboEditor.Value != null)
						{
							CustRateGrpCodeVisibleChange((Int32)this.CustRateGrpCode_tComboEditor.Value);
						}
						break;
					}
				#endregion

				#region case 仕入先コード
				case "SupplierCd_tNedit":
					{
						// ゼロデータチェック処理
						if ((this.SupplierCd_tNedit.Text != "") && (this.SupplierCd_tNedit.GetInt() == 0))
						{
							if (this._tempRateBlanket.SupplierCd == 0)
							{
								this.SupplierCd_tNedit.Clear();
								canChangeFocus = false;
							}
							else
							{
								this.SupplierCd_tNedit.SetInt(this._tempRateBlanket.SupplierCd);
							}
							break;
						}

						// 変更が無ければ処理しない
						if (this.SupplierCd_tNedit.GetInt() == this._tempRateBlanket.SupplierCd)
						{
							break;
						}

						// 条件設定
						inParamObj = this.SupplierCd_tNedit.GetInt();

						// 存在チェック
						switch (CheckSupplierCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("仕入先コード");
									dispSetStatus = this._tempRateBlanket.SupplierCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetSupplierCd(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 仕入先掛率グループコード
				case "SuppRateGrpCode_tComboEditor":
					{
						if (this.SuppRateGrpCode_tComboEditor.Value != null)
						{
							SuppRateGrpCodeVisibleChanger((Int32)this.SuppRateGrpCode_tComboEditor.Value);
						}
						break;
					}
				#endregion
			}

			// フォーカス制御
			if (canChangeFocus == false)
			{
				nextCtrl = prevCtrl;

				//----- ueno add ---------- start 2008.03.07
				// 現在の項目から移動せず、テキスト全選択状態とする
				nextCtrl.Select();
				//----- ueno add ---------- end 2008.03.07
			}
		}

		/// <summary>
		/// UnitPriceKind_tComboEditor_SelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 単価種類コンボボックスが変化ときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void UnitPriceKind_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (UnitPriceKind_tComboEditor.Value != null)
			{
				UnitPriceKindVisibleChange((Int32)UnitPriceKind_tComboEditor.Value);
			}
		}

		/// <summary>
		/// UnitPriceKindWay_tComboEditor_SelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 設定方法コンボボックスが変化ときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void UnitPriceKindWay_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (UnitPriceKindWay_tComboEditor.Value != null)
			{
				UnitPriceKindWayVisibleChange((Int32)UnitPriceKindWay_tComboEditor.Value);
			}
		}

		/// <summary>
		/// EnterpriseGanreCode_Grp_tComboEditor_SelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 自社分類コンボボックスが変化ときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void EnterpriseGanreCode_Grp_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if(this.EnterpriseGanreCode_Grp_tComboEditor.Value != null)
			{
				EnterpriseGanreCodeVisibleChange((Int32)this.EnterpriseGanreCode_Grp_tComboEditor.Value);
			}
		}

		/// <summary>
		/// CustRateGrpCode_tComboEditor_SelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 得意先掛率コンボボックスが変化ときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void CustRateGrpCode_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if(this.CustRateGrpCode_tComboEditor.Value != null)
			{
				CustRateGrpCodeVisibleChange((Int32)this.CustRateGrpCode_tComboEditor.Value);
			}
		}

		/// <summary>
		/// SuppRateGrpCode_tComboEditor_SelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 仕入先掛率コンボボックスが変化ときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void SuppRateGrpCode_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if(this.SuppRateGrpCode_tComboEditor.Value != null)
			{
				SuppRateGrpCodeVisibleChanger((Int32)this.SuppRateGrpCode_tComboEditor.Value);
			}
		}
		
		/// <summary>
		/// 初期化タイマー起動処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 指定した時間が経過したとき発生する</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		private void tm_InitialTimer_Tick ( object sender, EventArgs e )
		{
			this.tm_InitialTimer.Enabled = false;
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			string errMsg = "";
			try
			{
				// タイマー初期処理起動
				status = this.InitializeTimerSetting( out errMsg );

				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
				}
				
				// 初期フォーカスセット
				this.UnitPriceKind_tComboEditor.Focus();
			}
			catch ( Exception ex )
			{
				this.MsgDispProc( "初期化処理に失敗しました", (int)ConstantManagement.MethodResult.ctFNC_CANCEL, "Load", ex );
			}
		}

		/// <summary>
		/// Main_ultraExplorerBar_GroupExpanding
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Main_ultraExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			// 展開をキャンセル
			e.Cancel = true;
		}

		/// <summary>
		/// Main_ultraExplorerBar_GroupCollapsing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Main_ultraExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			// 縮小をキャンセル
			e.Cancel = true;
		}

		#endregion Control Events

		#region ガイド
		/// <summary>RateSettingDivide_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 掛率設定区分ガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void RateSettingDivide_uButton_Click(object sender, EventArgs e)
		{
			RateProtyMng rateProtyMng = null;

			if (this._rateProtyMngAcs.ExecuteGuid(this._enterpriseCode, this._sectionCode, RateBlanketAcs.NullChgInt(this.UnitPriceKind_tComboEditor.Value),
				RateBlanketAcs.NullChgInt(this.UnitPriceKindWay_tComboEditor.Value), out rateProtyMng) == 0)
			{
				// 変更が無ければ処理しない
				if (string.Equals(rateProtyMng.RateSettingDivide, this._tempRateBlanket.RateSettingDivide) == true)
				{
					return;
				}

				this.RateSettingDivide_tEdit.Text = rateProtyMng.RateSettingDivide;
				this.RateMngGoodsCd_tEdit.Text = rateProtyMng.RateMngGoodsCd;
				this.RateMngGoodsNm_tEdit.Text = rateProtyMng.RateMngGoodsNm;
				this.RateMngCustCd_tEdit.Text = rateProtyMng.RateMngCustCd;
				this.RateMngCustNm_tEdit.Text = rateProtyMng.RateMngCustNm;

				// 現在データ保存
				this._tempRateBlanket.RateSettingDivide = this.RateSettingDivide_tEdit.Text;
				this._tempRateBlanket.RateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
				this._tempRateBlanket.RateMngGoodsNm = this.RateMngGoodsNm_tEdit.Text;
				this._tempRateBlanket.RateMngCustCd = this.RateMngCustCd_tEdit.Text;
				this._tempRateBlanket.RateMngCustNm = this.RateMngCustNm_tEdit.Text;

				// 掛率条件入力エラーチェック
				InpRateCondCheck();
			}
		}

		/// <summary>GoodsMakerCd_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 商品メーカー（単品）ガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GoodsMakerCd_uButton_Click(object sender, EventArgs e)
		{
			GoodsMakerCdGuide(	ref this.GoodsMakerCd_tNedit,	ref this.GoodsMakerCdNm_tEdit,
								ref this.GoodsNoCd_tEdit,		ref this.GoodsNoNm_tEdit);
		}

		/// <summary>GoodsNo_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 商品番号（単品）ガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GoodsNo_uButton_Click(object sender, EventArgs e)
		{
			GoodsNoGuide(	ref this.GoodsMakerCd_tNedit,	ref this.GoodsMakerCdNm_tEdit,
							ref this.GoodsNoCd_tEdit,		ref this.GoodsNoNm_tEdit);
		}

		/// <summary>GoodsMakerCd_Grp_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 商品メーカーガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void GoodsMakerCd_Grp_uButton_Click(object sender, EventArgs e)
		{
			GoodsMakerCdGuide(ref this.GoodsMakerCd_Grp_tNedit, ref this.GoodsMakerCdNm_Grp_tEdit);
		}

		/// <summary>LargeGoodsGanreCode_Grp_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 商品区分Ｇガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void LargeGoodsGanreCode_Grp_uButton_Click(object sender, EventArgs e)
		{
			// 商品区分Ｇガイド起動
			LargeGoodsGanreCodeGuide();
		}

		/// <summary>MediumGoodsGanreCode_Grp_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 商品区分ガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void MediumGoodsGanreCode_Grp_uButton_Click(object sender, EventArgs e)
		{
			// 商品区分ガイド起動
			MediumGoodsGanreCodeGuide();
		}

		/// <summary>DetailGoodsGanreCode_Grp_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 商品区分詳細ガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void DetailGoodsGanreCode_Grp_uButton_Click(object sender, EventArgs e)
		{
			// 商品区分詳細ガイド起動
			DetailGoodsGanreCodeGuide();
		}

		/// <summary>BLGoodsCode_Grp_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ＢＬガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void BLGoodsCode_Grp_uButton_Click(object sender, EventArgs e)
		{
			BLGoodsCdUMnt blGoodsCdUMnt = null;

			if (this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt) == 0)
			{
				// 変更が無ければ処理しない
				if (blGoodsCdUMnt.BLGoodsCode == this._tempRateBlanket.BLGoodsCode)
				{
					return;
				}

				this.BLGoodsCode_Grp_tNedit.SetInt(blGoodsCdUMnt.BLGoodsCode);
				this.BLGoodsCodeNm_Grp_tEdit.Text = blGoodsCdUMnt.BLGoodsFullName;

				// 現在データ保存
				this._tempRateBlanket.BLGoodsCode = this.BLGoodsCode_Grp_tNedit.GetInt();
			}
		}

		/// <summary>CustomerCode_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 得意先ガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void CustomerCode_uButton_Click(object sender, EventArgs e)
		{
            PMKHN04001UA customerSearchForm = new PMKHN04001UA(PMKHN04001UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04001UA.EXECUTEMODE_GUIDE_AND_EDIT);	// 得意先検索アクセスクラス
			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
			customerSearchForm.ShowDialog(this);
		}

		/// <summary>SupplierCd_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 仕入先ガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void SupplierCd_uButton_Click(object sender, EventArgs e)
		{
            // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //SFTOK01370UA supplierSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);	// 仕入先検索アクセスクラス
            //supplierSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.SupplierSearchForm_CustomerSelect);
            //supplierSearchForm.ShowDialog(this);
            Supplier supplier;
            this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, string.Empty);
            this.SupplierSearchForm_SupplierSelect(supplier);
            // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		}

		/// <summary>
		/// 得意先選択時発生イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="customerSearchRet">得意先検索戻り値クラス</param>
		/// <remarks>
		/// <br>Note       : 得意先選択時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.11.08</br>
		/// </remarks>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			// 変更が無ければ処理しない
			if (customerSearchRet.CustomerCode == this._tempRateBlanket.CustomerCode)
			{
				return;
			}

			CustomerInfo customerInfo;
			
			//選択された得意先の状態をチェック
			int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode,
									customerSearchRet.CustomerCode, out customerInfo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 選択データが得意先でない場合
				if (customerInfo.IsCustomer == false)
				{
					// エラー
					MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "指定された条件で、得意先は存在しませんでした。", status);
					return;
				}
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "選択した得意先は既に削除されています。", status);
				return;
			}
			else
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "得意先情報の取得に失敗しました。", status);
				return;
			}
			
			this.CustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
			this.CustomerCodeNm_tEdit.Text = customerSearchRet.Name;

			// 現在データ保存
			this._tempRateBlanket.CustomerCode = this.CustomerCode_tNedit.GetInt();
		}

        // UPD 2008.04.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 仕入先選択時発生イベント
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="customerSearchRet">仕入先検索戻り値クラス</param>
        ///// <remarks>
        ///// <br>Note       : 仕入先選択時に発生します。</br>
        ///// <br>Programmer : 30167 上野　弘貴</br>
        ///// <br>Date       : 2007.10.11</br>
        ///// </remarks>
        //private void SupplierSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    // 変更が無ければ処理しない
        //    if (customerSearchRet.CustomerCode == this._tempRateBlanket.SupplierCd)
        //    {
        //        return;
        //    }

        //    CustomerInfo customerInfo;

        //    //選択された得意先の状態をチェック
        //    int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode,
        //                            customerSearchRet.CustomerCode, out customerInfo);
			
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // 選択データが仕入先でない場合
        //        if (customerInfo.IsSupplier == false)
        //        {
        //            // エラー
        //            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "指定された条件で、仕入先は存在しませんでした。", status);
        //            return;
        //        }
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "選択した仕入先は既に削除されています。", status);
        //        return;
        //    }
        //    else
        //    {
        //        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "仕入先情報の取得に失敗しました。", status);
        //        return;
        //    }

        //    this.SupplierCd_tNedit.SetInt(customerSearchRet.CustomerCode);
        //    this.SupplierCdNm_tEdit.Text = customerSearchRet.Name;

        //    // 現在データ保存
        //    this._tempRateBlanket.SupplierCd = this.SupplierCd_tNedit.GetInt();
        //}
        /// <summary>
        /// 仕入先情報設定処理
        /// </summary>
        /// <param name="supplier">仕入先情報</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 20056 對馬 大輔</br>
        /// <br>Date       : 2008.04.24</br>
        /// </remarks>
        private void SupplierSearchForm_SupplierSelect(Supplier supplier)
        {
            //---------------------------------------------
            // 設定チェック
            //---------------------------------------------
            if (supplier == null) return;                                           // nullの場合、処理なし
            if (supplier.SupplierCd == this._tempRateBlanket.SupplierCd) return;    // 変更が無ければ処理なし

            //---------------------------------------------
            // 仕入先情報再読込
            //---------------------------------------------
            Supplier tempSupplier;
            // 仕入先情報読込
            int status = this._supplierAcs.Read(out tempSupplier, this._enterpriseCode, supplier.SupplierCd);

            //---------------------------------------------
            // チェック処理
            //---------------------------------------------
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "選択した仕入先は既に削除されています。", status);
                return;
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "仕入先情報の取得に失敗しました。", status);
                return;
            }

            //---------------------------------------------
            // 仕入先情報設定
            //---------------------------------------------
            this.SupplierCd_tNedit.SetInt(tempSupplier.SupplierCd);
            this.SupplierCdNm_tEdit.Text = tempSupplier.SupplierNm1;

            // 現在データ保存
            this._tempRateBlanket.SupplierCd = this.SupplierCd_tNedit.GetInt();
        }
        // UPD 2008.04.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		#endregion ガイド
	}
}
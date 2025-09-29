//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 仕入先マスタ
// プログラム概要   : 仕入先の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2008/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2008/12/12  修正内容 : 障害ID:8248,9161対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2008/12/24  修正内容 : 障害ID:9452対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2009/01/20  修正内容 : 障害ID:9164,9163対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30414 忍 幸史
// 作 成 日  2009/01/29  修正内容 : 障害ID:10723対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/27  修正内容 : MANTIS【13319】 子仕入先の支払情報が更新されない不具合を修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/26  修正内容 : MANTIS【13296】 仕入先名と仕入先略称の必須チェックから除外
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王君
// 作 成 日  2012/10/22  修正内容 : 2012/11/14配信分、Redmine#32861 
//                                  仕入先ガイドは、仕入伝票入力と同様のガイドを使用するように修正
//----------------------------------------------------------------------------//

# region ※using
using Infragistics.Win.Misc;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using System.Collections.Generic;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 仕入先マスタ フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note         : 仕入先マスタ情報の設定を行います。</br>
	/// <br>               IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer   : 22018 鈴木正臣</br>
	/// <br>Date         : 2008.04.28</br>
    /// <br>Update Note  : 2008/12/12 30414 忍 幸史　障害ID:8248,9161対応</br>
    /// <br>Update Note  : 2008/12/24 30414 忍 幸史　障害ID:9452対応</br>
    /// <br>Update Note  : 2009/01/20 30414 忍 幸史　障害ID:9164,9163対応</br>
    /// <br>Update Note  : 2009/01/29 30414 忍 幸史　障害ID:10723対応</br>
    /// <br>Update Note  : 2012/10/22  王君</br>
    /// <br>管理番号     : 2012/11/14配信分</br>
    /// <br>               Redmine#32861 仕入先ガイドは、仕入伝票入力と同様のガイドを使用するように修正</br>
    /// </remarks>
    public class PMKHN09020UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region ※Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private System.Windows.Forms.Timer Initial_Timer;
        private Broadleaf.Library.Windows.Forms.TImeControl tImeControl1;
        private TEdit tEdit_SupplierName1;
        private Infragistics.Win.Misc.UltraLabel BLGoodsFullName_Title_Label;
        private Infragistics.Win.Misc.UltraLabel BLGoodsCode_Title_Label;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TNedit tNedit_SupplierCd;
		private UiSetControl uiSetControl1;
        private UltraLabel uLabel_CustomerNameTitle;
        private UltraLabel ultraLabel61;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl SubInfo_UTabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage SubInfo_UTabSharedControlsPage;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo2_UTabPageControl;
        private Panel SubInfo2_Panel;
        private UltraButton uButton_Note4Guide;
        private TEdit tEdit_SupplierNote4;
        private UltraButton uButton_Note3Guide;
        private TEdit tEdit_SupplierNote3;
        private UltraButton uButton_Note2Guide;
        private TEdit tEdit_SupplierNote2;
        private UltraLabel Note2Title_ULabel;
        private UltraButton uButton_Note1Guide;
        private TEdit tEdit_SupplierNote1;
        private UltraLabel Note1Title_ULabel;
        private UltraLabel Note4Title_ULabel;
        private UltraLabel Note3Title_ULabel;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo0_UTabPageControl;
        private Panel SubInfo0_Panel;
        private UltraLabel ultraLabel25;
        private UltraLabel ultraLabel24;
        private TEdit tEdit_SupplierPostNo;
        private UltraLabel ultraLabel14;
        private TEdit tEdit_SupplierAddr1;
        private TEdit tEdit_SupplierAddr3;
        private TEdit tEdit_SupplierAddr4;
        private UltraLabel ultraLabel5;
        private UltraButton uButton_AddressGuide;
        private TEdit tEdit_SupplierTelNo;
        private UltraLabel HomeTelNoDspName_ULabel;
        private TEdit tEdit_SupplierTelNo1;
        private UltraLabel MobileTelNoDspName_ULabel;
        private TEdit tEdit_SupplierTelNo2;
        private UltraLabel uLabel_Payment;
        private UltraLabel uLabel_Detail;
        private UltraLabel ultraLabel2;
        private UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo5_UTabPageControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo4_UTabPageControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SubInfo1_UTabPageControl;
        private UltraLabel ultraLabel8;
        private UltraButton uButton_StockAgentGuide;
        private TEdit tEdit_StockAgentNm;
        private UltraButton uButton_MngSectionNmGuide;
        private TEdit tEdit_MngSectionNm;
        private UltraLabel ultraLabel57;
        private UltraLabel ultraLabel39;
        private TComboEditor tComboEditor_PureCode;
        private TComboEditor tComboEditor_SupplierAttributeDiv;
        private UltraLabel ultraLabel28;
        private TComboEditor tComboEditor_SalesAreaCode;
        private UltraLabel ultraLabel7;
        private TComboEditor tComboEditor_BusinessTypeCode;
        private UltraLabel BusinessTypeCodeTitle_ULabel;
        private UltraLabel ultraLabel6;
        private UltraLabel ultraLabel27;
        private TEdit tEdit_SupplierSnm;
        private UltraLabel ultraLabel34;
        private UltraLabel ultraLabel12;
        private TEdit tEdit_SupplierKana;
        private TEdit tEdit_SupplierName2;
        private TNedit tNedit_StockCnsTaxFrcProcCd;
        private TNedit tNedit_StockMoneyFrcProcCd;
        private TNedit tNedit_StockUnPrcFrcProcCd;
        private UltraButton uButton_SalesCnsTaxFrcProcCdGuide;
        private UltraButton uButton_SalesMoneyFrcProcCdGuide;
        private UltraButton uButton_SalesUnPrcFrcProcCdGuide;
        private UltraLabel ultraLabel44;
        private UltraLabel ultraLabel47;
        private UltraLabel ultraLabel45;
        private UltraLabel ultraLabel46;
        private UltraLabel ultraLabel18;
        private UltraLabel ultraLabel19;
        private UltraLabel ultraLabel54;
        private UltraLabel ultraLabel52;
        private TComboEditor tComboEditor_SuppCTaXLayRefCd;
        private UltraLabel ultraLabel13;
        private TComboEditor tComboEditor_SuppTaxLayMethod;
        private UltraLabel ultraLabel17;
        private UltraLabel ultraLabel9;
        private UltraButton uButton_PaymentSectionGuide;
        private TEdit tEdit_PaymentSectionCode;
        private UltraLabel ultraLabel60;
        private TNedit tNedit_NTimeCalcStDate;
        private UltraLabel ultraLabel58;
        private UltraLabel uLabel_PayeeName1;
        private TNedit tNedit_PayeeCode;
        private UltraLabel ultraLabel55;
        private UltraLabel ultraLabel53;
        private UltraLabel uLabel_PayeeSnm;
        private TNedit tNedit_PaymentSight;
        private UltraLabel ultraLabel29;
        private TComboEditor tComboEditor_PaymentCond;
        private UltraLabel uLabel_PayeeName2;
        private TComboEditor tComboEditor_PaymentMonthCode;
        private UltraButton uButton_PayeeNameGuide;
        private UltraLabel ultraLabel59;
        private TNedit tNedit_PaymentDay;
        private UltraLabel CollectMoneyCodeTitle_ULabel;
        private UltraLabel CollectMoneyDayTitle_ULabel;
        private TNedit tNedit_PaymentTotalDay;
        private UltraLabel TotalDayTitle_ULabel;
        private UltraLabel ultraLabel20;
        private TImeControl NameToKana_TImeControl;
        private ContextMenuStrip contextMenuStrip1;
        private TEdit tEdit_SuppHonorificTitle;
        private TEdit tEdit_OrderHonorificTtl;
        private UltraButton uButton_OfrSupplierGuide;
        private UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		# endregion

		# region ■Constructor
		/// <summary>
        /// 仕入先マスタ フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 仕入先マスタ フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2008.04.30</br>
		/// </remarks>
        public PMKHN09020UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint = false;
			this._canClose = false;
			this._canNew = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose = true;		// デフォルト:true固定
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;

            if ( _paraEnterpriseCode == string.Empty )
            {
                //　企業コード取得
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

			// 変数初期化
			this._dataIndex = -1;
			this._secInfoAcs = new SecInfoAcs();
			this._supplierAcs = new SupplierAcs();
            this._ofrSupplierAcs = new OfrSupplierAcs();
            //this._userGuideAcs = new UserGuideAcs();  // iitani d 2007.05.18
			 
			this._totalCount = 0;
            this._supplierDic = new Dictionary<Guid, Supplier>();

			//_dataIndexバッファ（メインフレーム最小化対応）
			this._indexBuf = -2;

			// 拠点OPの判定
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // UI非表示データ
            _noDispData = new NoDispData();

            // 全体初期値設定マスタ読み込み（全体設定参照の対応）
            // (拠点=00：共通設定を含めて取得)
            _allDefSetDic = new Dictionary<string, AllDefSet>();
            AllDefSetAcs addDefSetAcs = new AllDefSetAcs();
            ArrayList retList;
            addDefSetAcs.Search( out retList, this._enterpriseCode );
            if (retList != null)
            {
                foreach (AllDefSet allDefSet in retList)
	            {
                    _allDefSetDic.Add( allDefSet.SectionCode.TrimEnd(), allDefSet );
	            }
            }

            // 税率設定マスタ読み込み（全体設定参照の対応）
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            taxRateSetAcs.Read( out _taxRateSet, this._enterpriseCode, 0 ); // 0:一般
            if ( _taxRateSet == null ) _taxRateSet = new TaxRateSet();

            // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
            this._paymentSetAcs = new PaymentSetAcs();
            this._moneyKindAcs = new MoneyKindAcs();
            // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<
		}
        /// <summary>
        /// 仕入先マスタ フォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : スライダからのマスメン単独起動機能を提供します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        /// <param name="mode">(※未使用)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierCode">仕入先コード</param>
        public PMKHN09020UA( int mode, string enterpriseCode, int supplierCode )
            : this()
        {
            // 単独起動モード=true
            _singleExecute = true;
            // 企業コード
            _paraEnterpriseCode = enterpriseCode;
            // 仕入先コード
            _paraSupplierCode = supplierCode;

            // --- ADD 2008/12/11 --------------------------------------------------------------------->>>>>
            this._paymentSetAcs = new PaymentSetAcs();
            this._moneyKindAcs = new MoneyKindAcs();
            // --- ADD 2008/12/11 ---------------------------------------------------------------------<<<<<
        }
		# endregion

        # region ※Dispose
        /// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		#region ※Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance219 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance220 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance221 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance165 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance166 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance167 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance241 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance242 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance243 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance237 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance162 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance163 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance164 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance182 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance183 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance184 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance201 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance202 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance261 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance151 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance152 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance153 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance154 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance155 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance197 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance209 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance210 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance218 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance227 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance228 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance229 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance231 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance232 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance233 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance172 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance173 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance174 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance181 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance168 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance169 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance230 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance244 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09020UA));
            this.SubInfo0_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubInfo0_Panel = new System.Windows.Forms.Panel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierPostNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierAddr1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SupplierAddr3 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SupplierAddr4 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_AddressGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SupplierTelNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.HomeTelNoDspName_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierTelNo1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MobileTelNoDspName_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierTelNo2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SubInfo2_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubInfo2_Panel = new System.Windows.Forms.Panel();
            this.uButton_Note4Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SupplierNote4 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note3Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SupplierNote3 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_Note2Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SupplierNote2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Note2Title_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_Note1Guide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SupplierNote1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Note1Title_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Note4Title_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Note3Title_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.tEdit_SupplierName1 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.BLGoodsCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsFullName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uLabel_CustomerNameTitle = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel61 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_Detail = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_Payment = new Infragistics.Win.Misc.UltraLabel();
            this.SubInfo5_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubInfo4_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubInfo1_UTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.SubInfo_UTabSharedControlsPage = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.SubInfo_UTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierSnm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SupplierKana = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SupplierName2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.uButton_MngSectionNmGuide = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_MngSectionNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel57 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PureCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tComboEditor_SupplierAttributeDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SalesAreaCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_BusinessTypeCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BusinessTypeCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_StockAgentNm = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_StockAgentGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel60 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_NTimeCalcStDate = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel58 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_PayeeName1 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PayeeCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel55 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel53 = new Infragistics.Win.Misc.UltraLabel();
            this.uLabel_PayeeSnm = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PaymentSight = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PaymentCond = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uLabel_PayeeName2 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PaymentMonthCode = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.uButton_PayeeNameGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel59 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PaymentDay = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CollectMoneyCodeTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.CollectMoneyDayTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_PaymentTotalDay = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TotalDayTitle_ULabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_PaymentSectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_PaymentSectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel54 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel52 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SuppCTaXLayRefCd = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_SuppTaxLayMethod = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_StockCnsTaxFrcProcCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_StockMoneyFrcProcCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_StockUnPrcFrcProcCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_SalesCnsTaxFrcProcCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_SalesMoneyFrcProcCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.uButton_SalesUnPrcFrcProcCdGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel44 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel47 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel45 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel46 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.NameToKana_TImeControl = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tEdit_SuppHonorificTitle = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_OrderHonorificTtl = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_OfrSupplierGuide = new Infragistics.Win.Misc.UltraButton();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.SubInfo0_UTabPageControl.SuspendLayout();
            this.SubInfo0_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierPostNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo2)).BeginInit();
            this.SubInfo2_UTabPageControl.SuspendLayout();
            this.SubInfo2_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubInfo_UTabControl)).BeginInit();
            this.SubInfo_UTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierKana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MngSectionNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PureCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierAttributeDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesAreaCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_BusinessTypeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_NTimeCalcStDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PayeeCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentSight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PaymentCond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PaymentMonthCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentTotalDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PaymentSectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SuppCTaXLayRefCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SuppTaxLayMethod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockCnsTaxFrcProcCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockMoneyFrcProcCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockUnPrcFrcProcCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SuppHonorificTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OrderHonorificTtl)).BeginInit();
            this.SuspendLayout();
            // 
            // SubInfo0_UTabPageControl
            // 
            this.SubInfo0_UTabPageControl.Controls.Add(this.SubInfo0_Panel);
            this.SubInfo0_UTabPageControl.Location = new System.Drawing.Point(1, 1);
            this.SubInfo0_UTabPageControl.Name = "SubInfo0_UTabPageControl";
            this.SubInfo0_UTabPageControl.Size = new System.Drawing.Size(1009, 126);
            // 
            // SubInfo0_Panel
            // 
            this.SubInfo0_Panel.Controls.Add(this.ultraLabel25);
            this.SubInfo0_Panel.Controls.Add(this.ultraLabel24);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierPostNo);
            this.SubInfo0_Panel.Controls.Add(this.ultraLabel14);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierAddr1);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierAddr3);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierAddr4);
            this.SubInfo0_Panel.Controls.Add(this.ultraLabel5);
            this.SubInfo0_Panel.Controls.Add(this.uButton_AddressGuide);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierTelNo);
            this.SubInfo0_Panel.Controls.Add(this.HomeTelNoDspName_ULabel);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierTelNo1);
            this.SubInfo0_Panel.Controls.Add(this.MobileTelNoDspName_ULabel);
            this.SubInfo0_Panel.Controls.Add(this.tEdit_SupplierTelNo2);
            this.SubInfo0_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubInfo0_Panel.Location = new System.Drawing.Point(0, 0);
            this.SubInfo0_Panel.Name = "SubInfo0_Panel";
            this.SubInfo0_Panel.Size = new System.Drawing.Size(1009, 126);
            this.SubInfo0_Panel.TabIndex = 0;
            // 
            // ultraLabel25
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance3;
            this.ultraLabel25.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel25.Location = new System.Drawing.Point(584, 4);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(105, 22);
            this.ultraLabel25.TabIndex = 1128;
            this.ultraLabel25.Text = "電話番号・FAX";
            // 
            // ultraLabel24
            // 
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel24.Appearance = appearance4;
            this.ultraLabel24.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel24.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel24.Location = new System.Drawing.Point(38, 3);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel24.TabIndex = 1127;
            this.ultraLabel24.Text = "住　所";
            // 
            // tEdit_SupplierPostNo
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierPostNo.ActiveAppearance = appearance5;
            appearance57.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierPostNo.Appearance = appearance57;
            this.tEdit_SupplierPostNo.AutoSelect = true;
            this.tEdit_SupplierPostNo.DataText = "";
            this.tEdit_SupplierPostNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierPostNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SupplierPostNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierPostNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SupplierPostNo.Location = new System.Drawing.Point(115, 26);
            this.tEdit_SupplierPostNo.MaxLength = 10;
            this.tEdit_SupplierPostNo.Name = "tEdit_SupplierPostNo";
            this.tEdit_SupplierPostNo.Size = new System.Drawing.Size(80, 22);
            this.tEdit_SupplierPostNo.TabIndex = 0;
            // 
            // ultraLabel14
            // 
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance6;
            this.ultraLabel14.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel14.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel14.Location = new System.Drawing.Point(27, 26);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel14.TabIndex = 328;
            this.ultraLabel14.Text = "郵便番号";
            // 
            // tEdit_SupplierAddr1
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierAddr1.ActiveAppearance = appearance7;
            appearance58.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierAddr1.Appearance = appearance58;
            this.tEdit_SupplierAddr1.AutoSelect = true;
            this.tEdit_SupplierAddr1.DataText = "";
            this.tEdit_SupplierAddr1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierAddr1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierAddr1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierAddr1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierAddr1.Location = new System.Drawing.Point(115, 50);
            this.tEdit_SupplierAddr1.MaxLength = 30;
            this.tEdit_SupplierAddr1.Name = "tEdit_SupplierAddr1";
            this.tEdit_SupplierAddr1.Size = new System.Drawing.Size(430, 22);
            this.tEdit_SupplierAddr1.TabIndex = 2;
            // 
            // tEdit_SupplierAddr3
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierAddr3.ActiveAppearance = appearance10;
            appearance59.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierAddr3.Appearance = appearance59;
            this.tEdit_SupplierAddr3.AutoSelect = true;
            this.tEdit_SupplierAddr3.DataText = "";
            this.tEdit_SupplierAddr3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierAddr3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 22, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierAddr3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierAddr3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierAddr3.Location = new System.Drawing.Point(115, 74);
            this.tEdit_SupplierAddr3.MaxLength = 22;
            this.tEdit_SupplierAddr3.Name = "tEdit_SupplierAddr3";
            this.tEdit_SupplierAddr3.Size = new System.Drawing.Size(321, 22);
            this.tEdit_SupplierAddr3.TabIndex = 3;
            // 
            // tEdit_SupplierAddr4
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierAddr4.ActiveAppearance = appearance11;
            appearance60.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierAddr4.Appearance = appearance60;
            this.tEdit_SupplierAddr4.AutoSelect = true;
            this.tEdit_SupplierAddr4.DataText = "";
            this.tEdit_SupplierAddr4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierAddr4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierAddr4.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierAddr4.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierAddr4.Location = new System.Drawing.Point(115, 98);
            this.tEdit_SupplierAddr4.MaxLength = 30;
            this.tEdit_SupplierAddr4.Name = "tEdit_SupplierAddr4";
            this.tEdit_SupplierAddr4.Size = new System.Drawing.Size(430, 22);
            this.tEdit_SupplierAddr4.TabIndex = 4;
            // 
            // ultraLabel5
            // 
            appearance12.TextHAlignAsString = "Center";
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance12;
            this.ultraLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel5.Location = new System.Drawing.Point(27, 50);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel5.TabIndex = 326;
            this.ultraLabel5.Text = "住　所";
            // 
            // uButton_AddressGuide
            // 
            this.uButton_AddressGuide.Location = new System.Drawing.Point(197, 25);
            this.uButton_AddressGuide.Name = "uButton_AddressGuide";
            this.uButton_AddressGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_AddressGuide.TabIndex = 1;
            this.uButton_AddressGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_AddressGuide.Click += new System.EventHandler(this.uButton_AddressGuide_Click);
            // 
            // tEdit_SupplierTelNo
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierTelNo.ActiveAppearance = appearance14;
            appearance64.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierTelNo.Appearance = appearance64;
            this.tEdit_SupplierTelNo.AutoSelect = true;
            this.tEdit_SupplierTelNo.DataText = "";
            this.tEdit_SupplierTelNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierTelNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SupplierTelNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierTelNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SupplierTelNo.Location = new System.Drawing.Point(678, 26);
            this.tEdit_SupplierTelNo.MaxLength = 16;
            this.tEdit_SupplierTelNo.Name = "tEdit_SupplierTelNo";
            this.tEdit_SupplierTelNo.Size = new System.Drawing.Size(121, 22);
            this.tEdit_SupplierTelNo.TabIndex = 5;
            // 
            // HomeTelNoDspName_ULabel
            // 
            appearance15.TextHAlignAsString = "Center";
            appearance15.TextVAlignAsString = "Middle";
            this.HomeTelNoDspName_ULabel.Appearance = appearance15;
            this.HomeTelNoDspName_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HomeTelNoDspName_ULabel.Location = new System.Drawing.Point(584, 26);
            this.HomeTelNoDspName_ULabel.Name = "HomeTelNoDspName_ULabel";
            this.HomeTelNoDspName_ULabel.Size = new System.Drawing.Size(88, 22);
            this.HomeTelNoDspName_ULabel.TabIndex = 337;
            this.HomeTelNoDspName_ULabel.Text = "電話";
            // 
            // tEdit_SupplierTelNo1
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierTelNo1.ActiveAppearance = appearance17;
            appearance63.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierTelNo1.Appearance = appearance63;
            this.tEdit_SupplierTelNo1.AutoSelect = true;
            this.tEdit_SupplierTelNo1.DataText = "";
            this.tEdit_SupplierTelNo1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierTelNo1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SupplierTelNo1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierTelNo1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SupplierTelNo1.Location = new System.Drawing.Point(678, 50);
            this.tEdit_SupplierTelNo1.MaxLength = 16;
            this.tEdit_SupplierTelNo1.Name = "tEdit_SupplierTelNo1";
            this.tEdit_SupplierTelNo1.Size = new System.Drawing.Size(121, 22);
            this.tEdit_SupplierTelNo1.TabIndex = 6;
            // 
            // MobileTelNoDspName_ULabel
            // 
            appearance18.TextHAlignAsString = "Center";
            appearance18.TextVAlignAsString = "Middle";
            this.MobileTelNoDspName_ULabel.Appearance = appearance18;
            this.MobileTelNoDspName_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MobileTelNoDspName_ULabel.Location = new System.Drawing.Point(584, 74);
            this.MobileTelNoDspName_ULabel.Name = "MobileTelNoDspName_ULabel";
            this.MobileTelNoDspName_ULabel.Size = new System.Drawing.Size(88, 22);
            this.MobileTelNoDspName_ULabel.TabIndex = 339;
            this.MobileTelNoDspName_ULabel.Text = "ＦＡＸ";
            // 
            // tEdit_SupplierTelNo2
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierTelNo2.ActiveAppearance = appearance20;
            appearance62.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierTelNo2.Appearance = appearance62;
            this.tEdit_SupplierTelNo2.AutoSelect = true;
            this.tEdit_SupplierTelNo2.DataText = "";
            this.tEdit_SupplierTelNo2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierTelNo2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SupplierTelNo2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierTelNo2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SupplierTelNo2.Location = new System.Drawing.Point(678, 74);
            this.tEdit_SupplierTelNo2.MaxLength = 16;
            this.tEdit_SupplierTelNo2.Name = "tEdit_SupplierTelNo2";
            this.tEdit_SupplierTelNo2.Size = new System.Drawing.Size(121, 22);
            this.tEdit_SupplierTelNo2.TabIndex = 7;
            // 
            // SubInfo2_UTabPageControl
            // 
            this.SubInfo2_UTabPageControl.Controls.Add(this.SubInfo2_Panel);
            this.SubInfo2_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo2_UTabPageControl.Name = "SubInfo2_UTabPageControl";
            this.SubInfo2_UTabPageControl.Size = new System.Drawing.Size(1009, 126);
            // 
            // SubInfo2_Panel
            // 
            this.SubInfo2_Panel.Controls.Add(this.uButton_Note4Guide);
            this.SubInfo2_Panel.Controls.Add(this.tEdit_SupplierNote4);
            this.SubInfo2_Panel.Controls.Add(this.uButton_Note3Guide);
            this.SubInfo2_Panel.Controls.Add(this.tEdit_SupplierNote3);
            this.SubInfo2_Panel.Controls.Add(this.uButton_Note2Guide);
            this.SubInfo2_Panel.Controls.Add(this.tEdit_SupplierNote2);
            this.SubInfo2_Panel.Controls.Add(this.Note2Title_ULabel);
            this.SubInfo2_Panel.Controls.Add(this.uButton_Note1Guide);
            this.SubInfo2_Panel.Controls.Add(this.tEdit_SupplierNote1);
            this.SubInfo2_Panel.Controls.Add(this.Note1Title_ULabel);
            this.SubInfo2_Panel.Controls.Add(this.Note4Title_ULabel);
            this.SubInfo2_Panel.Controls.Add(this.Note3Title_ULabel);
            this.SubInfo2_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubInfo2_Panel.Location = new System.Drawing.Point(0, 0);
            this.SubInfo2_Panel.Name = "SubInfo2_Panel";
            this.SubInfo2_Panel.Size = new System.Drawing.Size(1009, 126);
            this.SubInfo2_Panel.TabIndex = 1110;
            // 
            // uButton_Note4Guide
            // 
            appearance32.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance32.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note4Guide.Appearance = appearance32;
            this.uButton_Note4Guide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note4Guide.Location = new System.Drawing.Point(440, 85);
            this.uButton_Note4Guide.Name = "uButton_Note4Guide";
            this.uButton_Note4Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note4Guide.TabIndex = 7;
            this.uButton_Note4Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note4Guide.Visible = false;
            // 
            // tEdit_SupplierNote4
            // 
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierNote4.ActiveAppearance = appearance34;
            appearance68.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierNote4.Appearance = appearance68;
            this.tEdit_SupplierNote4.AutoSelect = true;
            this.tEdit_SupplierNote4.AutoSize = false;
            this.tEdit_SupplierNote4.DataText = "";
            this.tEdit_SupplierNote4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierNote4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierNote4.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierNote4.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierNote4.Location = new System.Drawing.Point(115, 86);
            this.tEdit_SupplierNote4.MaxLength = 20;
            this.tEdit_SupplierNote4.Name = "tEdit_SupplierNote4";
            this.tEdit_SupplierNote4.Size = new System.Drawing.Size(321, 22);
            this.tEdit_SupplierNote4.TabIndex = 6;
            // 
            // uButton_Note3Guide
            // 
            appearance37.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance37.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note3Guide.Appearance = appearance37;
            this.uButton_Note3Guide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note3Guide.Location = new System.Drawing.Point(440, 59);
            this.uButton_Note3Guide.Name = "uButton_Note3Guide";
            this.uButton_Note3Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note3Guide.TabIndex = 5;
            this.uButton_Note3Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note3Guide.Visible = false;
            // 
            // tEdit_SupplierNote3
            // 
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierNote3.ActiveAppearance = appearance39;
            appearance67.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierNote3.Appearance = appearance67;
            this.tEdit_SupplierNote3.AutoSelect = true;
            this.tEdit_SupplierNote3.AutoSize = false;
            this.tEdit_SupplierNote3.DataText = "";
            this.tEdit_SupplierNote3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierNote3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierNote3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierNote3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierNote3.Location = new System.Drawing.Point(115, 60);
            this.tEdit_SupplierNote3.MaxLength = 20;
            this.tEdit_SupplierNote3.Name = "tEdit_SupplierNote3";
            this.tEdit_SupplierNote3.Size = new System.Drawing.Size(321, 22);
            this.tEdit_SupplierNote3.TabIndex = 4;
            // 
            // uButton_Note2Guide
            // 
            appearance42.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance42.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note2Guide.Appearance = appearance42;
            this.uButton_Note2Guide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note2Guide.Location = new System.Drawing.Point(440, 33);
            this.uButton_Note2Guide.Name = "uButton_Note2Guide";
            this.uButton_Note2Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note2Guide.TabIndex = 3;
            this.uButton_Note2Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note2Guide.Visible = false;
            // 
            // tEdit_SupplierNote2
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierNote2.ActiveAppearance = appearance44;
            appearance66.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierNote2.Appearance = appearance66;
            this.tEdit_SupplierNote2.AutoSelect = true;
            this.tEdit_SupplierNote2.AutoSize = false;
            this.tEdit_SupplierNote2.DataText = "";
            this.tEdit_SupplierNote2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierNote2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierNote2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierNote2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierNote2.Location = new System.Drawing.Point(115, 34);
            this.tEdit_SupplierNote2.MaxLength = 20;
            this.tEdit_SupplierNote2.Name = "tEdit_SupplierNote2";
            this.tEdit_SupplierNote2.Size = new System.Drawing.Size(321, 22);
            this.tEdit_SupplierNote2.TabIndex = 2;
            // 
            // Note2Title_ULabel
            // 
            appearance47.TextHAlignAsString = "Center";
            appearance47.TextVAlignAsString = "Middle";
            this.Note2Title_ULabel.Appearance = appearance47;
            this.Note2Title_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note2Title_ULabel.Location = new System.Drawing.Point(7, 32);
            this.Note2Title_ULabel.Name = "Note2Title_ULabel";
            this.Note2Title_ULabel.Size = new System.Drawing.Size(100, 24);
            this.Note2Title_ULabel.TabIndex = 494;
            this.Note2Title_ULabel.Text = "仕入先備考２";
            // 
            // uButton_Note1Guide
            // 
            appearance48.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance48.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_Note1Guide.Appearance = appearance48;
            this.uButton_Note1Guide.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_Note1Guide.Location = new System.Drawing.Point(440, 7);
            this.uButton_Note1Guide.Name = "uButton_Note1Guide";
            this.uButton_Note1Guide.Size = new System.Drawing.Size(24, 24);
            this.uButton_Note1Guide.TabIndex = 1;
            this.uButton_Note1Guide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_Note1Guide.Visible = false;
            // 
            // tEdit_SupplierNote1
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierNote1.ActiveAppearance = appearance50;
            appearance65.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierNote1.Appearance = appearance65;
            this.tEdit_SupplierNote1.AutoSelect = true;
            this.tEdit_SupplierNote1.AutoSize = false;
            this.tEdit_SupplierNote1.DataText = "";
            this.tEdit_SupplierNote1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierNote1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierNote1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierNote1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierNote1.Location = new System.Drawing.Point(115, 8);
            this.tEdit_SupplierNote1.MaxLength = 20;
            this.tEdit_SupplierNote1.Name = "tEdit_SupplierNote1";
            this.tEdit_SupplierNote1.Size = new System.Drawing.Size(321, 22);
            this.tEdit_SupplierNote1.TabIndex = 0;
            // 
            // Note1Title_ULabel
            // 
            appearance51.TextHAlignAsString = "Center";
            appearance51.TextVAlignAsString = "Middle";
            this.Note1Title_ULabel.Appearance = appearance51;
            this.Note1Title_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note1Title_ULabel.Location = new System.Drawing.Point(7, 6);
            this.Note1Title_ULabel.Name = "Note1Title_ULabel";
            this.Note1Title_ULabel.Size = new System.Drawing.Size(100, 24);
            this.Note1Title_ULabel.TabIndex = 493;
            this.Note1Title_ULabel.Text = "仕入先備考１";
            // 
            // Note4Title_ULabel
            // 
            appearance53.TextHAlignAsString = "Center";
            appearance53.TextVAlignAsString = "Middle";
            this.Note4Title_ULabel.Appearance = appearance53;
            this.Note4Title_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note4Title_ULabel.Location = new System.Drawing.Point(7, 84);
            this.Note4Title_ULabel.Name = "Note4Title_ULabel";
            this.Note4Title_ULabel.Size = new System.Drawing.Size(100, 24);
            this.Note4Title_ULabel.TabIndex = 499;
            this.Note4Title_ULabel.Text = "仕入先備考４";
            // 
            // Note3Title_ULabel
            // 
            appearance54.TextHAlignAsString = "Center";
            appearance54.TextVAlignAsString = "Middle";
            this.Note3Title_ULabel.Appearance = appearance54;
            this.Note3Title_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Note3Title_ULabel.Location = new System.Drawing.Point(7, 58);
            this.Note3Title_ULabel.Name = "Note3Title_ULabel";
            this.Note3Title_ULabel.Size = new System.Drawing.Size(100, 24);
            this.Note3Title_ULabel.TabIndex = 495;
            this.Note3Title_ULabel.Text = "仕入先備考３";
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(756, 605);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 9993;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 648);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(1018, 23);
            this.ultraStatusBar1.TabIndex = 46;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Mode_Label
            // 
            appearance43.ForeColor = System.Drawing.Color.White;
            appearance43.TextHAlignAsString = "Center";
            appearance43.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance43;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(915, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 58;
            this.Mode_Label.Text = "更新モード";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(631, 605);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 9990;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(756, 605);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 9991;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(882, 605);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 9999;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tImeControl1
            // 
            this.tImeControl1.InControl = this.tEdit_SupplierName1;
            this.tImeControl1.OutControl = null;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 30;
            // 
            // tEdit_SupplierName1
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierName1.ActiveAppearance = appearance45;
            appearance88.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance88.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierName1.Appearance = appearance88;
            this.tEdit_SupplierName1.AutoSelect = true;
            this.tEdit_SupplierName1.DataText = "";
            this.tEdit_SupplierName1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierName1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SupplierName1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierName1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierName1.Location = new System.Drawing.Point(120, 72);
            this.tEdit_SupplierName1.MaxLength = 30;
            this.tEdit_SupplierName1.Name = "tEdit_SupplierName1";
            this.tEdit_SupplierName1.Size = new System.Drawing.Size(430, 22);
            this.tEdit_SupplierName1.TabIndex = 2;
            this.tEdit_SupplierName1.ValueChanged += new System.EventHandler(this.tEdit_Name_ValueChanged);
            // 
            // BLGoodsCode_Title_Label
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.BLGoodsCode_Title_Label.Appearance = appearance52;
            this.BLGoodsCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsCode_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGoodsCode_Title_Label.Location = new System.Drawing.Point(30, 46);
            this.BLGoodsCode_Title_Label.Name = "BLGoodsCode_Title_Label";
            this.BLGoodsCode_Title_Label.Size = new System.Drawing.Size(87, 24);
            this.BLGoodsCode_Title_Label.TabIndex = 10;
            this.BLGoodsCode_Title_Label.Text = "仕入先コード";
            // 
            // BLGoodsFullName_Title_Label
            // 
            appearance49.TextHAlignAsString = "Center";
            appearance49.TextVAlignAsString = "Middle";
            this.BLGoodsFullName_Title_Label.Appearance = appearance49;
            this.BLGoodsFullName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BLGoodsFullName_Title_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGoodsFullName_Title_Label.Location = new System.Drawing.Point(32, 74);
            this.BLGoodsFullName_Title_Label.Name = "BLGoodsFullName_Title_Label";
            this.BLGoodsFullName_Title_Label.Size = new System.Drawing.Size(87, 24);
            this.BLGoodsFullName_Title_Label.TabIndex = 11;
            this.BLGoodsFullName_Title_Label.Text = "仕入先名";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // tNedit_SupplierCd
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance38.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd.ActiveAppearance = appearance38;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance40.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance40.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance40.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd.Appearance = appearance40;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(120, 46);
            this.tNedit_SupplierCd.MaxLength = 6;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(53, 22);
            this.tNedit_SupplierCd.TabIndex = 0;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // uLabel_CustomerNameTitle
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance35.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance35.ForeColor = System.Drawing.Color.White;
            appearance35.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance35.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance35.TextHAlignAsString = "Center";
            appearance35.TextVAlignAsString = "Middle";
            this.uLabel_CustomerNameTitle.Appearance = appearance35;
            this.uLabel_CustomerNameTitle.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_CustomerNameTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_CustomerNameTitle.Location = new System.Drawing.Point(4, 41);
            this.uLabel_CustomerNameTitle.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_CustomerNameTitle.Name = "uLabel_CustomerNameTitle";
            this.uLabel_CustomerNameTitle.Size = new System.Drawing.Size(25, 172);
            this.uLabel_CustomerNameTitle.TabIndex = 1128;
            this.uLabel_CustomerNameTitle.Text = "名前";
            // 
            // ultraLabel61
            // 
            this.ultraLabel61.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel61.Location = new System.Drawing.Point(29, 41);
            this.ultraLabel61.Margin = new System.Windows.Forms.Padding(0);
            this.ultraLabel61.Name = "ultraLabel61";
            this.ultraLabel61.Size = new System.Drawing.Size(535, 172);
            this.ultraLabel61.TabIndex = 0;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel1.Location = new System.Drawing.Point(29, 219);
            this.ultraLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(535, 229);
            this.ultraLabel1.TabIndex = 1;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel2.Location = new System.Drawing.Point(591, 41);
            this.ultraLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(424, 407);
            this.ultraLabel2.TabIndex = 2;
            // 
            // uLabel_Detail
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance61.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.ForeColor = System.Drawing.Color.White;
            appearance61.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance61.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance61.TextHAlignAsString = "Center";
            appearance61.TextVAlignAsString = "Middle";
            this.uLabel_Detail.Appearance = appearance61;
            this.uLabel_Detail.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_Detail.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Detail.Location = new System.Drawing.Point(4, 219);
            this.uLabel_Detail.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_Detail.Name = "uLabel_Detail";
            this.uLabel_Detail.Size = new System.Drawing.Size(25, 229);
            this.uLabel_Detail.TabIndex = 1132;
            this.uLabel_Detail.Text = "詳細情報";
            // 
            // uLabel_Payment
            // 
            appearance219.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance219.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance219.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance219.ForeColor = System.Drawing.Color.White;
            appearance219.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance219.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance219.TextHAlignAsString = "Center";
            appearance219.TextVAlignAsString = "Middle";
            this.uLabel_Payment.Appearance = appearance219;
            this.uLabel_Payment.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.uLabel_Payment.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_Payment.Location = new System.Drawing.Point(566, 41);
            this.uLabel_Payment.Margin = new System.Windows.Forms.Padding(0);
            this.uLabel_Payment.Name = "uLabel_Payment";
            this.uLabel_Payment.Size = new System.Drawing.Size(25, 407);
            this.uLabel_Payment.TabIndex = 1133;
            this.uLabel_Payment.Text = "支払情報";
            // 
            // SubInfo5_UTabPageControl
            // 
            this.SubInfo5_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo5_UTabPageControl.Name = "SubInfo5_UTabPageControl";
            this.SubInfo5_UTabPageControl.Size = new System.Drawing.Size(977, 149);
            // 
            // SubInfo4_UTabPageControl
            // 
            this.SubInfo4_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo4_UTabPageControl.Name = "SubInfo4_UTabPageControl";
            this.SubInfo4_UTabPageControl.Size = new System.Drawing.Size(977, 149);
            // 
            // SubInfo1_UTabPageControl
            // 
            this.SubInfo1_UTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo1_UTabPageControl.Name = "SubInfo1_UTabPageControl";
            this.SubInfo1_UTabPageControl.Size = new System.Drawing.Size(977, 149);
            // 
            // SubInfo_UTabSharedControlsPage
            // 
            this.SubInfo_UTabSharedControlsPage.Location = new System.Drawing.Point(-10000, -10000);
            this.SubInfo_UTabSharedControlsPage.Name = "SubInfo_UTabSharedControlsPage";
            this.SubInfo_UTabSharedControlsPage.Size = new System.Drawing.Size(1009, 126);
            // 
            // SubInfo_UTabControl
            // 
            appearance220.BackColor = System.Drawing.Color.White;
            appearance220.BackColor2 = System.Drawing.Color.Pink;
            this.SubInfo_UTabControl.ActiveTabAppearance = appearance220;
            appearance221.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            appearance221.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.SubInfo_UTabControl.ClientAreaAppearance = appearance221;
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo_UTabSharedControlsPage);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo2_UTabPageControl);
            this.SubInfo_UTabControl.Controls.Add(this.SubInfo0_UTabPageControl);
            this.SubInfo_UTabControl.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SubInfo_UTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(2);
            this.SubInfo_UTabControl.Location = new System.Drawing.Point(4, 451);
            this.SubInfo_UTabControl.Name = "SubInfo_UTabControl";
            this.SubInfo_UTabControl.SharedControlsPage = this.SubInfo_UTabSharedControlsPage;
            this.SubInfo_UTabControl.Size = new System.Drawing.Size(1011, 148);
            this.SubInfo_UTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.SubInfo_UTabControl.TabIndex = 1134;
            this.SubInfo_UTabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.BottomLeft;
            ultraTab1.Key = "SubInfo0";
            ultraTab1.TabPage = this.SubInfo0_UTabPageControl;
            ultraTab1.Text = "(&1)連絡先情報";
            ultraTab2.Key = "SubInfo2";
            ultraTab2.TabPage = this.SubInfo2_UTabPageControl;
            ultraTab2.Text = "(&2)備考情報";
            this.SubInfo_UTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.SubInfo_UTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            // 
            // ultraLabel27
            // 
            appearance165.TextHAlignAsString = "Center";
            appearance165.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance165;
            this.ultraLabel27.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel27.Location = new System.Drawing.Point(31, 127);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel27.TabIndex = 1225;
            this.ultraLabel27.Text = "仕入先略称";
            // 
            // tEdit_SupplierSnm
            // 
            appearance166.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierSnm.ActiveAppearance = appearance166;
            appearance167.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierSnm.Appearance = appearance167;
            this.tEdit_SupplierSnm.AutoSelect = true;
            this.tEdit_SupplierSnm.DataText = "";
            this.tEdit_SupplierSnm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierSnm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierSnm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierSnm.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierSnm.Location = new System.Drawing.Point(120, 128);
            this.tEdit_SupplierSnm.MaxLength = 20;
            this.tEdit_SupplierSnm.Name = "tEdit_SupplierSnm";
            this.tEdit_SupplierSnm.Size = new System.Drawing.Size(293, 22);
            this.tEdit_SupplierSnm.TabIndex = 4;
            this.tEdit_SupplierSnm.ValueChanged += new System.EventHandler(this.tEdit_Name_ValueChanged);
            // 
            // ultraLabel34
            // 
            appearance33.TextHAlignAsString = "Center";
            appearance33.TextVAlignAsString = "Middle";
            this.ultraLabel34.Appearance = appearance33;
            this.ultraLabel34.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel34.Location = new System.Drawing.Point(33, 181);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel34.TabIndex = 1223;
            this.ultraLabel34.Text = "敬　称";
            // 
            // ultraLabel12
            // 
            appearance241.TextHAlignAsString = "Center";
            appearance241.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance241;
            this.ultraLabel12.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel12.Location = new System.Drawing.Point(31, 152);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel12.TabIndex = 1222;
            this.ultraLabel12.Text = "仕入先名(ｶﾅ)";
            // 
            // tEdit_SupplierKana
            // 
            appearance242.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierKana.ActiveAppearance = appearance242;
            appearance243.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance243.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierKana.Appearance = appearance243;
            this.tEdit_SupplierKana.AutoSelect = true;
            this.tEdit_SupplierKana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SupplierKana.DataText = "";
            this.tEdit_SupplierKana.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierKana.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_SupplierKana.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierKana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.tEdit_SupplierKana.Location = new System.Drawing.Point(120, 153);
            this.tEdit_SupplierKana.MaxLength = 30;
            this.tEdit_SupplierKana.Name = "tEdit_SupplierKana";
            this.tEdit_SupplierKana.Size = new System.Drawing.Size(217, 22);
            this.tEdit_SupplierKana.TabIndex = 5;
            this.tEdit_SupplierKana.ValueChanged += new System.EventHandler(this.tEdit_SupplierKana_ValueChanged);
            // 
            // tEdit_SupplierName2
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SupplierName2.ActiveAppearance = appearance2;
            appearance31.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SupplierName2.Appearance = appearance31;
            this.tEdit_SupplierName2.AutoSelect = true;
            this.tEdit_SupplierName2.DataText = "";
            this.tEdit_SupplierName2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SupplierName2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SupplierName2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SupplierName2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SupplierName2.Location = new System.Drawing.Point(120, 100);
            this.tEdit_SupplierName2.MaxLength = 30;
            this.tEdit_SupplierName2.Name = "tEdit_SupplierName2";
            this.tEdit_SupplierName2.Size = new System.Drawing.Size(430, 22);
            this.tEdit_SupplierName2.TabIndex = 3;
            this.tEdit_SupplierName2.ValueChanged += new System.EventHandler(this.tEdit_Name_ValueChanged);
            // 
            // ultraLabel6
            // 
            appearance237.TextHAlignAsString = "Center";
            appearance237.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance237;
            this.ultraLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel6.Location = new System.Drawing.Point(221, 181);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel6.TabIndex = 1227;
            this.ultraLabel6.Text = "発注書敬称";
            // 
            // uButton_MngSectionNmGuide
            // 
            this.uButton_MngSectionNmGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_MngSectionNmGuide.Location = new System.Drawing.Point(485, 225);
            this.uButton_MngSectionNmGuide.Name = "uButton_MngSectionNmGuide";
            this.uButton_MngSectionNmGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_MngSectionNmGuide.TabIndex = 9;
            this.uButton_MngSectionNmGuide.Tag = "0";
            this.uButton_MngSectionNmGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_MngSectionNmGuide.Click += new System.EventHandler(this.uButton_MngSectionNmGuide_Click);
            // 
            // tEdit_MngSectionNm
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_MngSectionNm.ActiveAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance24.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_MngSectionNm.Appearance = appearance24;
            this.tEdit_MngSectionNm.AutoSelect = true;
            this.tEdit_MngSectionNm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_MngSectionNm.DataText = "";
            this.tEdit_MngSectionNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_MngSectionNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_MngSectionNm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_MngSectionNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_MngSectionNm.Location = new System.Drawing.Point(120, 226);
            this.tEdit_MngSectionNm.MaxLength = 30;
            this.tEdit_MngSectionNm.Name = "tEdit_MngSectionNm";
            this.tEdit_MngSectionNm.Size = new System.Drawing.Size(362, 22);
            this.tEdit_MngSectionNm.TabIndex = 8;
            // 
            // ultraLabel57
            // 
            appearance26.TextHAlignAsString = "Center";
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel57.Appearance = appearance26;
            this.ultraLabel57.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel57.Location = new System.Drawing.Point(30, 226);
            this.ultraLabel57.Name = "ultraLabel57";
            this.ultraLabel57.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel57.TabIndex = 1290;
            this.ultraLabel57.Text = "管理拠点";
            // 
            // ultraLabel39
            // 
            appearance132.TextHAlignAsString = "Center";
            appearance132.TextVAlignAsString = "Middle";
            this.ultraLabel39.Appearance = appearance132;
            this.ultraLabel39.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel39.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel39.Location = new System.Drawing.Point(30, 280);
            this.ultraLabel39.Name = "ultraLabel39";
            this.ultraLabel39.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel39.TabIndex = 1289;
            this.ultraLabel39.Text = "純正区分";
            // 
            // tComboEditor_PureCode
            // 
            appearance138.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PureCode.ActiveAppearance = appearance138;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_PureCode.Appearance = appearance16;
            this.tComboEditor_PureCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PureCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_PureCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance139.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PureCode.ItemAppearance = appearance139;
            this.tComboEditor_PureCode.Location = new System.Drawing.Point(120, 281);
            this.tComboEditor_PureCode.Name = "tComboEditor_PureCode";
            this.tComboEditor_PureCode.Size = new System.Drawing.Size(100, 22);
            this.tComboEditor_PureCode.TabIndex = 12;
            // 
            // tComboEditor_SupplierAttributeDiv
            // 
            appearance162.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierAttributeDiv.ActiveAppearance = appearance162;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_SupplierAttributeDiv.Appearance = appearance19;
            this.tComboEditor_SupplierAttributeDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SupplierAttributeDiv.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SupplierAttributeDiv.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance163.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SupplierAttributeDiv.ItemAppearance = appearance163;
            this.tComboEditor_SupplierAttributeDiv.Location = new System.Drawing.Point(120, 309);
            this.tComboEditor_SupplierAttributeDiv.Name = "tComboEditor_SupplierAttributeDiv";
            this.tComboEditor_SupplierAttributeDiv.Size = new System.Drawing.Size(185, 22);
            this.tComboEditor_SupplierAttributeDiv.TabIndex = 13;
            // 
            // ultraLabel28
            // 
            appearance164.TextHAlignAsString = "Center";
            appearance164.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance164;
            this.ultraLabel28.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel28.Location = new System.Drawing.Point(30, 309);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(84, 22);
            this.ultraLabel28.TabIndex = 1287;
            this.ultraLabel28.Text = "仕入先属性";
            // 
            // tComboEditor_SalesAreaCode
            // 
            appearance182.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesAreaCode.ActiveAppearance = appearance182;
            appearance56.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_SalesAreaCode.Appearance = appearance56;
            this.tComboEditor_SalesAreaCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SalesAreaCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance183.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SalesAreaCode.ItemAppearance = appearance183;
            this.tComboEditor_SalesAreaCode.Location = new System.Drawing.Point(120, 365);
            this.tComboEditor_SalesAreaCode.Name = "tComboEditor_SalesAreaCode";
            this.tComboEditor_SalesAreaCode.Size = new System.Drawing.Size(185, 22);
            this.tComboEditor_SalesAreaCode.TabIndex = 15;
            // 
            // ultraLabel7
            // 
            appearance184.TextHAlignAsString = "Center";
            appearance184.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance184;
            this.ultraLabel7.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel7.Location = new System.Drawing.Point(30, 365);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel7.TabIndex = 1284;
            this.ultraLabel7.Text = "地　区";
            // 
            // tComboEditor_BusinessTypeCode
            // 
            appearance201.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_BusinessTypeCode.ActiveAppearance = appearance201;
            appearance46.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_BusinessTypeCode.Appearance = appearance46;
            this.tComboEditor_BusinessTypeCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_BusinessTypeCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance202.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_BusinessTypeCode.ItemAppearance = appearance202;
            this.tComboEditor_BusinessTypeCode.Location = new System.Drawing.Point(120, 337);
            this.tComboEditor_BusinessTypeCode.Name = "tComboEditor_BusinessTypeCode";
            this.tComboEditor_BusinessTypeCode.Size = new System.Drawing.Size(185, 22);
            this.tComboEditor_BusinessTypeCode.TabIndex = 14;
            // 
            // BusinessTypeCodeTitle_ULabel
            // 
            appearance261.TextHAlignAsString = "Center";
            appearance261.TextVAlignAsString = "Middle";
            this.BusinessTypeCodeTitle_ULabel.Appearance = appearance261;
            this.BusinessTypeCodeTitle_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BusinessTypeCodeTitle_ULabel.Location = new System.Drawing.Point(30, 337);
            this.BusinessTypeCodeTitle_ULabel.Name = "BusinessTypeCodeTitle_ULabel";
            this.BusinessTypeCodeTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.BusinessTypeCodeTitle_ULabel.TabIndex = 1282;
            this.BusinessTypeCodeTitle_ULabel.Text = "業　種";
            // 
            // tEdit_StockAgentNm
            // 
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentNm.ActiveAppearance = appearance85;
            appearance86.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance86.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_StockAgentNm.Appearance = appearance86;
            this.tEdit_StockAgentNm.AutoSelect = true;
            this.tEdit_StockAgentNm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_StockAgentNm.DataText = "";
            this.tEdit_StockAgentNm.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentNm.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_StockAgentNm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_StockAgentNm.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_StockAgentNm.Location = new System.Drawing.Point(120, 254);
            this.tEdit_StockAgentNm.MaxLength = 30;
            this.tEdit_StockAgentNm.Name = "tEdit_StockAgentNm";
            this.tEdit_StockAgentNm.Size = new System.Drawing.Size(362, 22);
            this.tEdit_StockAgentNm.TabIndex = 10;
            // 
            // uButton_StockAgentGuide
            // 
            this.uButton_StockAgentGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_StockAgentGuide.Location = new System.Drawing.Point(485, 253);
            this.uButton_StockAgentGuide.Name = "uButton_StockAgentGuide";
            this.uButton_StockAgentGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_StockAgentGuide.TabIndex = 11;
            this.uButton_StockAgentGuide.Tag = "0";
            this.uButton_StockAgentGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_StockAgentGuide.Click += new System.EventHandler(this.uButton_StockAgentGuide_Click);
            // 
            // ultraLabel8
            // 
            appearance87.TextHAlignAsString = "Center";
            appearance87.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance87;
            this.ultraLabel8.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel8.Location = new System.Drawing.Point(30, 254);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel8.TabIndex = 1295;
            this.ultraLabel8.Text = "仕入担当";
            // 
            // ultraLabel60
            // 
            appearance80.TextHAlignAsString = "Center";
            appearance80.TextVAlignAsString = "Middle";
            this.ultraLabel60.Appearance = appearance80;
            this.ultraLabel60.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel60.Location = new System.Drawing.Point(711, 228);
            this.ultraLabel60.Name = "ultraLabel60";
            this.ultraLabel60.Size = new System.Drawing.Size(62, 22);
            this.ultraLabel60.TabIndex = 1316;
            this.ultraLabel60.Text = "日～締日";
            // 
            // tNedit_NTimeCalcStDate
            // 
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_NTimeCalcStDate.ActiveAppearance = appearance81;
            appearance82.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance82.TextHAlignAsString = "Right";
            this.tNedit_NTimeCalcStDate.Appearance = appearance82;
            this.tNedit_NTimeCalcStDate.AutoSelect = true;
            this.tNedit_NTimeCalcStDate.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_NTimeCalcStDate.DataText = "";
            this.tNedit_NTimeCalcStDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_NTimeCalcStDate.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_NTimeCalcStDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_NTimeCalcStDate.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_NTimeCalcStDate.Location = new System.Drawing.Point(683, 228);
            this.tNedit_NTimeCalcStDate.MaxLength = 2;
            this.tNedit_NTimeCalcStDate.Name = "tNedit_NTimeCalcStDate";
            this.tNedit_NTimeCalcStDate.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_NTimeCalcStDate.Size = new System.Drawing.Size(25, 22);
            this.tNedit_NTimeCalcStDate.TabIndex = 28;
            // 
            // ultraLabel58
            // 
            appearance83.TextHAlignAsString = "Center";
            appearance83.TextVAlignAsString = "Middle";
            this.ultraLabel58.Appearance = appearance83;
            this.ultraLabel58.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel58.Location = new System.Drawing.Point(593, 228);
            this.ultraLabel58.Name = "ultraLabel58";
            this.ultraLabel58.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel58.TabIndex = 1314;
            this.ultraLabel58.Text = "次回勘定";
            // 
            // uLabel_PayeeName1
            // 
            appearance84.BackColor = System.Drawing.Color.Gainsboro;
            appearance84.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance84.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance84.TextHAlignAsString = "Left";
            appearance84.TextVAlignAsString = "Middle";
            this.uLabel_PayeeName1.Appearance = appearance84;
            this.uLabel_PayeeName1.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_PayeeName1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_PayeeName1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_PayeeName1.Location = new System.Drawing.Point(683, 100);
            this.uLabel_PayeeName1.Name = "uLabel_PayeeName1";
            this.uLabel_PayeeName1.Size = new System.Drawing.Size(326, 22);
            this.uLabel_PayeeName1.TabIndex = 20;
            this.uLabel_PayeeName1.WrapText = false;
            // 
            // tNedit_PayeeCode
            // 
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_PayeeCode.ActiveAppearance = appearance89;
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance90.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance90.TextHAlignAsString = "Right";
            this.tNedit_PayeeCode.Appearance = appearance90;
            this.tNedit_PayeeCode.AutoSelect = true;
            this.tNedit_PayeeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_PayeeCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PayeeCode.DataText = "";
            this.tNedit_PayeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PayeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PayeeCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_PayeeCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_PayeeCode.Location = new System.Drawing.Point(683, 76);
            this.tNedit_PayeeCode.MaxLength = 6;
            this.tNedit_PayeeCode.Name = "tNedit_PayeeCode";
            this.tNedit_PayeeCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_PayeeCode.Size = new System.Drawing.Size(53, 22);
            this.tNedit_PayeeCode.TabIndex = 18;
            // 
            // ultraLabel55
            // 
            appearance91.TextHAlignAsString = "Center";
            appearance91.TextVAlignAsString = "Middle";
            this.ultraLabel55.Appearance = appearance91;
            this.ultraLabel55.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel55.Location = new System.Drawing.Point(592, 78);
            this.ultraLabel55.Name = "ultraLabel55";
            this.ultraLabel55.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel55.TabIndex = 1311;
            this.ultraLabel55.Text = "支払先コード";
            // 
            // ultraLabel53
            // 
            appearance102.TextHAlignAsString = "Center";
            appearance102.TextVAlignAsString = "Middle";
            this.ultraLabel53.Appearance = appearance102;
            this.ultraLabel53.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel53.Location = new System.Drawing.Point(593, 148);
            this.ultraLabel53.Name = "ultraLabel53";
            this.ultraLabel53.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel53.TabIndex = 1310;
            this.ultraLabel53.Text = "支払先略称";
            // 
            // uLabel_PayeeSnm
            // 
            appearance103.BackColor = System.Drawing.Color.Gainsboro;
            appearance103.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance103.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance103.TextHAlignAsString = "Left";
            appearance103.TextVAlignAsString = "Middle";
            this.uLabel_PayeeSnm.Appearance = appearance103;
            this.uLabel_PayeeSnm.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_PayeeSnm.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_PayeeSnm.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_PayeeSnm.Location = new System.Drawing.Point(683, 148);
            this.uLabel_PayeeSnm.Name = "uLabel_PayeeSnm";
            this.uLabel_PayeeSnm.Size = new System.Drawing.Size(326, 22);
            this.uLabel_PayeeSnm.TabIndex = 22;
            this.uLabel_PayeeSnm.WrapText = false;
            // 
            // tNedit_PaymentSight
            // 
            appearance151.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_PaymentSight.ActiveAppearance = appearance151;
            appearance152.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance152.TextHAlignAsString = "Right";
            this.tNedit_PaymentSight.Appearance = appearance152;
            this.tNedit_PaymentSight.AutoSelect = true;
            this.tNedit_PaymentSight.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PaymentSight.DataText = "";
            this.tNedit_PaymentSight.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PaymentSight.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PaymentSight.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_PaymentSight.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_PaymentSight.Location = new System.Drawing.Point(976, 203);
            this.tNedit_PaymentSight.MaxLength = 3;
            this.tNedit_PaymentSight.Name = "tNedit_PaymentSight";
            this.tNedit_PaymentSight.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_PaymentSight.Size = new System.Drawing.Size(32, 22);
            this.tNedit_PaymentSight.TabIndex = 27;
            // 
            // ultraLabel29
            // 
            appearance153.TextHAlignAsString = "Center";
            appearance153.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance153;
            this.ultraLabel29.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel29.Location = new System.Drawing.Point(593, 203);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel29.TabIndex = 1307;
            this.ultraLabel29.Text = "支払条件";
            // 
            // tComboEditor_PaymentCond
            // 
            appearance154.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PaymentCond.ActiveAppearance = appearance154;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance29.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_PaymentCond.Appearance = appearance29;
            this.tComboEditor_PaymentCond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PaymentCond.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_PaymentCond.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tComboEditor_PaymentCond.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            appearance155.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PaymentCond.ItemAppearance = appearance155;
            this.tComboEditor_PaymentCond.Location = new System.Drawing.Point(683, 203);
            this.tComboEditor_PaymentCond.Name = "tComboEditor_PaymentCond";
            this.tComboEditor_PaymentCond.Size = new System.Drawing.Size(204, 22);
            this.tComboEditor_PaymentCond.TabIndex = 26;
            // 
            // uLabel_PayeeName2
            // 
            appearance197.BackColor = System.Drawing.Color.Gainsboro;
            appearance197.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            appearance197.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance197.TextHAlignAsString = "Left";
            appearance197.TextVAlignAsString = "Middle";
            this.uLabel_PayeeName2.Appearance = appearance197;
            this.uLabel_PayeeName2.BackColorInternal = System.Drawing.Color.White;
            this.uLabel_PayeeName2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uLabel_PayeeName2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uLabel_PayeeName2.Location = new System.Drawing.Point(683, 124);
            this.uLabel_PayeeName2.Name = "uLabel_PayeeName2";
            this.uLabel_PayeeName2.Size = new System.Drawing.Size(326, 22);
            this.uLabel_PayeeName2.TabIndex = 21;
            this.uLabel_PayeeName2.WrapText = false;
            // 
            // tComboEditor_PaymentMonthCode
            // 
            appearance209.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PaymentMonthCode.ActiveAppearance = appearance209;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance30.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_PaymentMonthCode.Appearance = appearance30;
            this.tComboEditor_PaymentMonthCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PaymentMonthCode.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_PaymentMonthCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance210.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PaymentMonthCode.ItemAppearance = appearance210;
            this.tComboEditor_PaymentMonthCode.Location = new System.Drawing.Point(796, 177);
            this.tComboEditor_PaymentMonthCode.Name = "tComboEditor_PaymentMonthCode";
            this.tComboEditor_PaymentMonthCode.Size = new System.Drawing.Size(91, 22);
            this.tComboEditor_PaymentMonthCode.TabIndex = 24;
            // 
            // uButton_PayeeNameGuide
            // 
            this.uButton_PayeeNameGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_PayeeNameGuide.Location = new System.Drawing.Point(738, 75);
            this.uButton_PayeeNameGuide.Name = "uButton_PayeeNameGuide";
            this.uButton_PayeeNameGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_PayeeNameGuide.TabIndex = 19;
            this.uButton_PayeeNameGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_PayeeNameGuide.Click += new System.EventHandler(this.uButton_PayeeNameGuide_Click);
            // 
            // ultraLabel59
            // 
            appearance218.TextHAlignAsString = "Center";
            appearance218.TextVAlignAsString = "Middle";
            this.ultraLabel59.Appearance = appearance218;
            this.ultraLabel59.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel59.Location = new System.Drawing.Point(593, 100);
            this.ultraLabel59.Name = "ultraLabel59";
            this.ultraLabel59.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel59.TabIndex = 1305;
            this.ultraLabel59.Text = "支払先名";
            // 
            // tNedit_PaymentDay
            // 
            appearance227.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_PaymentDay.ActiveAppearance = appearance227;
            appearance228.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance228.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance228.TextHAlignAsString = "Right";
            this.tNedit_PaymentDay.Appearance = appearance228;
            this.tNedit_PaymentDay.AutoSelect = true;
            this.tNedit_PaymentDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_PaymentDay.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PaymentDay.DataText = "";
            this.tNedit_PaymentDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PaymentDay.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PaymentDay.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_PaymentDay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_PaymentDay.Location = new System.Drawing.Point(976, 177);
            this.tNedit_PaymentDay.MaxLength = 2;
            this.tNedit_PaymentDay.Name = "tNedit_PaymentDay";
            this.tNedit_PaymentDay.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_PaymentDay.Size = new System.Drawing.Size(25, 22);
            this.tNedit_PaymentDay.TabIndex = 25;
            // 
            // CollectMoneyCodeTitle_ULabel
            // 
            appearance229.TextHAlignAsString = "Center";
            appearance229.TextVAlignAsString = "Middle";
            this.CollectMoneyCodeTitle_ULabel.Appearance = appearance229;
            this.CollectMoneyCodeTitle_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CollectMoneyCodeTitle_ULabel.Location = new System.Drawing.Point(743, 177);
            this.CollectMoneyCodeTitle_ULabel.Name = "CollectMoneyCodeTitle_ULabel";
            this.CollectMoneyCodeTitle_ULabel.Size = new System.Drawing.Size(50, 22);
            this.CollectMoneyCodeTitle_ULabel.TabIndex = 1304;
            this.CollectMoneyCodeTitle_ULabel.Text = "支払月";
            // 
            // CollectMoneyDayTitle_ULabel
            // 
            appearance55.TextHAlignAsString = "Center";
            appearance55.TextVAlignAsString = "Middle";
            this.CollectMoneyDayTitle_ULabel.Appearance = appearance55;
            this.CollectMoneyDayTitle_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CollectMoneyDayTitle_ULabel.Location = new System.Drawing.Point(921, 177);
            this.CollectMoneyDayTitle_ULabel.Name = "CollectMoneyDayTitle_ULabel";
            this.CollectMoneyDayTitle_ULabel.Size = new System.Drawing.Size(50, 22);
            this.CollectMoneyDayTitle_ULabel.TabIndex = 1303;
            this.CollectMoneyDayTitle_ULabel.Text = "支払日";
            // 
            // tNedit_PaymentTotalDay
            // 
            appearance231.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_PaymentTotalDay.ActiveAppearance = appearance231;
            appearance232.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance232.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance232.TextHAlignAsString = "Right";
            this.tNedit_PaymentTotalDay.Appearance = appearance232;
            this.tNedit_PaymentTotalDay.AutoSelect = true;
            this.tNedit_PaymentTotalDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_PaymentTotalDay.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_PaymentTotalDay.DataText = "";
            this.tNedit_PaymentTotalDay.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_PaymentTotalDay.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_PaymentTotalDay.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_PaymentTotalDay.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_PaymentTotalDay.Location = new System.Drawing.Point(683, 176);
            this.tNedit_PaymentTotalDay.MaxLength = 2;
            this.tNedit_PaymentTotalDay.Name = "tNedit_PaymentTotalDay";
            this.tNedit_PaymentTotalDay.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_PaymentTotalDay.Size = new System.Drawing.Size(25, 22);
            this.tNedit_PaymentTotalDay.TabIndex = 23;
            // 
            // TotalDayTitle_ULabel
            // 
            appearance233.TextHAlignAsString = "Center";
            appearance233.TextVAlignAsString = "Middle";
            this.TotalDayTitle_ULabel.Appearance = appearance233;
            this.TotalDayTitle_ULabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalDayTitle_ULabel.Location = new System.Drawing.Point(593, 176);
            this.TotalDayTitle_ULabel.Name = "TotalDayTitle_ULabel";
            this.TotalDayTitle_ULabel.Size = new System.Drawing.Size(85, 22);
            this.TotalDayTitle_ULabel.TabIndex = 1302;
            this.TotalDayTitle_ULabel.Text = "締　日";
            // 
            // tEdit_PaymentSectionCode
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PaymentSectionCode.ActiveAppearance = appearance9;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance13.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_PaymentSectionCode.Appearance = appearance13;
            this.tEdit_PaymentSectionCode.AutoSelect = true;
            this.tEdit_PaymentSectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_PaymentSectionCode.DataText = "";
            this.tEdit_PaymentSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PaymentSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_PaymentSectionCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_PaymentSectionCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_PaymentSectionCode.Location = new System.Drawing.Point(683, 48);
            this.tEdit_PaymentSectionCode.MaxLength = 30;
            this.tEdit_PaymentSectionCode.Name = "tEdit_PaymentSectionCode";
            this.tEdit_PaymentSectionCode.Size = new System.Drawing.Size(293, 22);
            this.tEdit_PaymentSectionCode.TabIndex = 16;
            // 
            // uButton_PaymentSectionGuide
            // 
            this.uButton_PaymentSectionGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_PaymentSectionGuide.Location = new System.Drawing.Point(979, 47);
            this.uButton_PaymentSectionGuide.Name = "uButton_PaymentSectionGuide";
            this.uButton_PaymentSectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_PaymentSectionGuide.TabIndex = 17;
            this.uButton_PaymentSectionGuide.Tag = "0";
            this.uButton_PaymentSectionGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_PaymentSectionGuide.Click += new System.EventHandler(this.uButton_MngSectionNmGuide_Click);
            // 
            // ultraLabel9
            // 
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance1;
            this.ultraLabel9.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel9.Location = new System.Drawing.Point(592, 48);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(85, 22);
            this.ultraLabel9.TabIndex = 1319;
            this.ultraLabel9.Text = "支払拠点";
            // 
            // ultraLabel54
            // 
            appearance98.TextHAlignAsString = "Center";
            appearance98.TextVAlignAsString = "Middle";
            this.ultraLabel54.Appearance = appearance98;
            this.ultraLabel54.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel54.Location = new System.Drawing.Point(592, 305);
            this.ultraLabel54.Name = "ultraLabel54";
            this.ultraLabel54.Size = new System.Drawing.Size(88, 20);
            this.ultraLabel54.TabIndex = 1331;
            this.ultraLabel54.Text = "参照区分";
            // 
            // ultraLabel52
            // 
            appearance99.TextHAlignAsString = "Center";
            appearance99.TextVAlignAsString = "Middle";
            this.ultraLabel52.Appearance = appearance99;
            this.ultraLabel52.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel52.Location = new System.Drawing.Point(592, 288);
            this.ultraLabel52.Name = "ultraLabel52";
            this.ultraLabel52.Size = new System.Drawing.Size(87, 20);
            this.ultraLabel52.TabIndex = 1330;
            this.ultraLabel52.Text = "転嫁方式";
            // 
            // tComboEditor_SuppCTaXLayRefCd
            // 
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SuppCTaXLayRefCd.ActiveAppearance = appearance100;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_SuppCTaXLayRefCd.Appearance = appearance21;
            this.tComboEditor_SuppCTaXLayRefCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SuppCTaXLayRefCd.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SuppCTaXLayRefCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tComboEditor_SuppCTaXLayRefCd.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SuppCTaXLayRefCd.ItemAppearance = appearance101;
            this.tComboEditor_SuppCTaXLayRefCd.Location = new System.Drawing.Point(683, 295);
            this.tComboEditor_SuppCTaXLayRefCd.MaxDropDownItems = 18;
            this.tComboEditor_SuppCTaXLayRefCd.Name = "tComboEditor_SuppCTaXLayRefCd";
            this.tComboEditor_SuppCTaXLayRefCd.Size = new System.Drawing.Size(120, 22);
            this.tComboEditor_SuppCTaXLayRefCd.TabIndex = 31;
            this.tComboEditor_SuppCTaXLayRefCd.SelectionChangeCommitted += new System.EventHandler(this.tComboEditor_SuppCTaXLayRefCd_SelectionChangeCommitted);
            // 
            // ultraLabel13
            // 
            appearance172.TextHAlignAsString = "Center";
            appearance172.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance172;
            this.ultraLabel13.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel13.Location = new System.Drawing.Point(804, 307);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(81, 20);
            this.ultraLabel13.TabIndex = 1326;
            this.ultraLabel13.Text = "転嫁方式";
            // 
            // tComboEditor_SuppTaxLayMethod
            // 
            appearance173.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SuppTaxLayMethod.ActiveAppearance = appearance173;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance28.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tComboEditor_SuppTaxLayMethod.Appearance = appearance28;
            this.tComboEditor_SuppTaxLayMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_SuppTaxLayMethod.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_SuppTaxLayMethod.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tComboEditor_SuppTaxLayMethod.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance174.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_SuppTaxLayMethod.ItemAppearance = appearance174;
            this.tComboEditor_SuppTaxLayMethod.Location = new System.Drawing.Point(889, 296);
            this.tComboEditor_SuppTaxLayMethod.MaxDropDownItems = 18;
            this.tComboEditor_SuppTaxLayMethod.Name = "tComboEditor_SuppTaxLayMethod";
            this.tComboEditor_SuppTaxLayMethod.Size = new System.Drawing.Size(120, 22);
            this.tComboEditor_SuppTaxLayMethod.TabIndex = 32;
            // 
            // ultraLabel17
            // 
            appearance181.TextHAlignAsString = "Center";
            appearance181.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance181;
            this.ultraLabel17.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel17.Location = new System.Drawing.Point(804, 290);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(81, 20);
            this.ultraLabel17.TabIndex = 1320;
            this.ultraLabel17.Text = "消費税";
            // 
            // tNedit_StockCnsTaxFrcProcCd
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance92.TextHAlignAsString = "Right";
            this.tNedit_StockCnsTaxFrcProcCd.ActiveAppearance = appearance92;
            appearance93.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance93.TextHAlignAsString = "Right";
            this.tNedit_StockCnsTaxFrcProcCd.Appearance = appearance93;
            this.tNedit_StockCnsTaxFrcProcCd.AutoSelect = true;
            this.tNedit_StockCnsTaxFrcProcCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_StockCnsTaxFrcProcCd.DataText = "";
            this.tNedit_StockCnsTaxFrcProcCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_StockCnsTaxFrcProcCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_StockCnsTaxFrcProcCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_StockCnsTaxFrcProcCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_StockCnsTaxFrcProcCd.Location = new System.Drawing.Point(683, 402);
            this.tNedit_StockCnsTaxFrcProcCd.MaxLength = 8;
            this.tNedit_StockCnsTaxFrcProcCd.Name = "tNedit_StockCnsTaxFrcProcCd";
            this.tNedit_StockCnsTaxFrcProcCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_StockCnsTaxFrcProcCd.Size = new System.Drawing.Size(66, 22);
            this.tNedit_StockCnsTaxFrcProcCd.TabIndex = 37;
            // 
            // tNedit_StockMoneyFrcProcCd
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance94.TextHAlignAsString = "Right";
            this.tNedit_StockMoneyFrcProcCd.ActiveAppearance = appearance94;
            appearance95.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance95.TextHAlignAsString = "Right";
            this.tNedit_StockMoneyFrcProcCd.Appearance = appearance95;
            this.tNedit_StockMoneyFrcProcCd.AutoSelect = true;
            this.tNedit_StockMoneyFrcProcCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_StockMoneyFrcProcCd.DataText = "";
            this.tNedit_StockMoneyFrcProcCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_StockMoneyFrcProcCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_StockMoneyFrcProcCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_StockMoneyFrcProcCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_StockMoneyFrcProcCd.Location = new System.Drawing.Point(683, 365);
            this.tNedit_StockMoneyFrcProcCd.MaxLength = 8;
            this.tNedit_StockMoneyFrcProcCd.Name = "tNedit_StockMoneyFrcProcCd";
            this.tNedit_StockMoneyFrcProcCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_StockMoneyFrcProcCd.Size = new System.Drawing.Size(66, 22);
            this.tNedit_StockMoneyFrcProcCd.TabIndex = 35;
            // 
            // tNedit_StockUnPrcFrcProcCd
            // 
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance96.TextHAlignAsString = "Right";
            this.tNedit_StockUnPrcFrcProcCd.ActiveAppearance = appearance96;
            appearance97.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            appearance97.TextHAlignAsString = "Right";
            this.tNedit_StockUnPrcFrcProcCd.Appearance = appearance97;
            this.tNedit_StockUnPrcFrcProcCd.AutoSelect = true;
            this.tNedit_StockUnPrcFrcProcCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_StockUnPrcFrcProcCd.DataText = "";
            this.tNedit_StockUnPrcFrcProcCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_StockUnPrcFrcProcCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_StockUnPrcFrcProcCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_StockUnPrcFrcProcCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_StockUnPrcFrcProcCd.Location = new System.Drawing.Point(683, 329);
            this.tNedit_StockUnPrcFrcProcCd.MaxLength = 8;
            this.tNedit_StockUnPrcFrcProcCd.Name = "tNedit_StockUnPrcFrcProcCd";
            this.tNedit_StockUnPrcFrcProcCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_StockUnPrcFrcProcCd.Size = new System.Drawing.Size(66, 22);
            this.tNedit_StockUnPrcFrcProcCd.TabIndex = 33;
            // 
            // uButton_SalesCnsTaxFrcProcCdGuide
            // 
            this.uButton_SalesCnsTaxFrcProcCdGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesCnsTaxFrcProcCdGuide.Location = new System.Drawing.Point(752, 401);
            this.uButton_SalesCnsTaxFrcProcCdGuide.Name = "uButton_SalesCnsTaxFrcProcCdGuide";
            this.uButton_SalesCnsTaxFrcProcCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesCnsTaxFrcProcCdGuide.TabIndex = 38;
            this.uButton_SalesCnsTaxFrcProcCdGuide.Tag = "1";
            this.uButton_SalesCnsTaxFrcProcCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesCnsTaxFrcProcCdGuide.Click += new System.EventHandler(this.uButton_SalesUnPrcFrcProcCdGuide_Click);
            // 
            // uButton_SalesMoneyFrcProcCdGuide
            // 
            this.uButton_SalesMoneyFrcProcCdGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesMoneyFrcProcCdGuide.Location = new System.Drawing.Point(752, 364);
            this.uButton_SalesMoneyFrcProcCdGuide.Name = "uButton_SalesMoneyFrcProcCdGuide";
            this.uButton_SalesMoneyFrcProcCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesMoneyFrcProcCdGuide.TabIndex = 36;
            this.uButton_SalesMoneyFrcProcCdGuide.Tag = "0";
            this.uButton_SalesMoneyFrcProcCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesMoneyFrcProcCdGuide.Click += new System.EventHandler(this.uButton_SalesUnPrcFrcProcCdGuide_Click);
            // 
            // uButton_SalesUnPrcFrcProcCdGuide
            // 
            this.uButton_SalesUnPrcFrcProcCdGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_SalesUnPrcFrcProcCdGuide.Location = new System.Drawing.Point(752, 328);
            this.uButton_SalesUnPrcFrcProcCdGuide.Name = "uButton_SalesUnPrcFrcProcCdGuide";
            this.uButton_SalesUnPrcFrcProcCdGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SalesUnPrcFrcProcCdGuide.TabIndex = 34;
            this.uButton_SalesUnPrcFrcProcCdGuide.Tag = "2";
            this.uButton_SalesUnPrcFrcProcCdGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_SalesUnPrcFrcProcCdGuide.Click += new System.EventHandler(this.uButton_SalesUnPrcFrcProcCdGuide_Click);
            // 
            // ultraLabel44
            // 
            appearance119.TextHAlignAsString = "Center";
            appearance119.TextVAlignAsString = "Middle";
            this.ultraLabel44.Appearance = appearance119;
            this.ultraLabel44.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel44.Location = new System.Drawing.Point(592, 341);
            this.ultraLabel44.Name = "ultraLabel44";
            this.ultraLabel44.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel44.TabIndex = 1340;
            this.ultraLabel44.Text = "端数処理";
            // 
            // ultraLabel47
            // 
            appearance120.TextHAlignAsString = "Center";
            appearance120.TextVAlignAsString = "Middle";
            this.ultraLabel47.Appearance = appearance120;
            this.ultraLabel47.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel47.Location = new System.Drawing.Point(592, 324);
            this.ultraLabel47.Name = "ultraLabel47";
            this.ultraLabel47.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ultraLabel47.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel47.TabIndex = 1339;
            this.ultraLabel47.Text = "単価";
            // 
            // ultraLabel45
            // 
            appearance121.TextHAlignAsString = "Center";
            appearance121.TextVAlignAsString = "Middle";
            this.ultraLabel45.Appearance = appearance121;
            this.ultraLabel45.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel45.Location = new System.Drawing.Point(592, 374);
            this.ultraLabel45.Name = "ultraLabel45";
            this.ultraLabel45.Size = new System.Drawing.Size(85, 20);
            this.ultraLabel45.TabIndex = 1338;
            this.ultraLabel45.Text = "端数処理";
            // 
            // ultraLabel46
            // 
            appearance122.TextHAlignAsString = "Center";
            appearance122.TextVAlignAsString = "Middle";
            this.ultraLabel46.Appearance = appearance122;
            this.ultraLabel46.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel46.Location = new System.Drawing.Point(593, 359);
            this.ultraLabel46.Name = "ultraLabel46";
            this.ultraLabel46.Size = new System.Drawing.Size(84, 20);
            this.ultraLabel46.TabIndex = 1337;
            this.ultraLabel46.Text = "金額";
            // 
            // ultraLabel18
            // 
            appearance168.TextHAlignAsString = "Center";
            appearance168.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance168;
            this.ultraLabel18.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel18.Location = new System.Drawing.Point(592, 408);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(84, 20);
            this.ultraLabel18.TabIndex = 1333;
            this.ultraLabel18.Text = "端数処理";
            // 
            // ultraLabel19
            // 
            appearance169.TextHAlignAsString = "Center";
            appearance169.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance169;
            this.ultraLabel19.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.ultraLabel19.Location = new System.Drawing.Point(592, 392);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(84, 20);
            this.ultraLabel19.TabIndex = 1332;
            this.ultraLabel19.Text = "消費税";
            // 
            // ultraLabel20
            // 
            appearance230.TextHAlignAsString = "Center";
            appearance230.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance230;
            this.ultraLabel20.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel20.Location = new System.Drawing.Point(893, 203);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(77, 22);
            this.ultraLabel20.TabIndex = 1347;
            this.ultraLabel20.Text = "支払サイト";
            this.ultraLabel20.Click += new System.EventHandler(this.ultraLabel20_Click);
            // 
            // NameToKana_TImeControl
            // 
            this.NameToKana_TImeControl.InControl = this.tEdit_SupplierName1;
            this.NameToKana_TImeControl.OutControl = this.tEdit_SupplierKana;
            this.NameToKana_TImeControl.OwnerForm = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tEdit_SuppHonorificTitle
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SuppHonorificTitle.ActiveAppearance = appearance8;
            appearance36.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_SuppHonorificTitle.Appearance = appearance36;
            this.tEdit_SuppHonorificTitle.AutoSelect = true;
            this.tEdit_SuppHonorificTitle.DataText = "";
            this.tEdit_SuppHonorificTitle.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SuppHonorificTitle.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_SuppHonorificTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_SuppHonorificTitle.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_SuppHonorificTitle.Location = new System.Drawing.Point(120, 181);
            this.tEdit_SuppHonorificTitle.MaxLength = 4;
            this.tEdit_SuppHonorificTitle.Name = "tEdit_SuppHonorificTitle";
            this.tEdit_SuppHonorificTitle.Size = new System.Drawing.Size(73, 22);
            this.tEdit_SuppHonorificTitle.TabIndex = 6;
            // 
            // tEdit_OrderHonorificTtl
            // 
            appearance244.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_OrderHonorificTtl.ActiveAppearance = appearance244;
            appearance41.ForeColorDisabled = System.Drawing.SystemColors.WindowText;
            this.tEdit_OrderHonorificTtl.Appearance = appearance41;
            this.tEdit_OrderHonorificTtl.AutoSelect = true;
            this.tEdit_OrderHonorificTtl.DataText = "";
            this.tEdit_OrderHonorificTtl.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_OrderHonorificTtl.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_OrderHonorificTtl.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_OrderHonorificTtl.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_OrderHonorificTtl.Location = new System.Drawing.Point(312, 181);
            this.tEdit_OrderHonorificTtl.MaxLength = 4;
            this.tEdit_OrderHonorificTtl.Name = "tEdit_OrderHonorificTtl";
            this.tEdit_OrderHonorificTtl.Size = new System.Drawing.Size(73, 22);
            this.tEdit_OrderHonorificTtl.TabIndex = 7;
            // 
            // uButton_OfrSupplierGuide
            // 
            this.uButton_OfrSupplierGuide.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_OfrSupplierGuide.Location = new System.Drawing.Point(175, 45);
            this.uButton_OfrSupplierGuide.Name = "uButton_OfrSupplierGuide";
            this.uButton_OfrSupplierGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_OfrSupplierGuide.TabIndex = 1;
            this.uButton_OfrSupplierGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_OfrSupplierGuide.Click += new System.EventHandler(this.uButton_OfrSupplierGuide_Click);
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(631, 605);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 9990;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // PMKHN09020UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1018, 671);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.uButton_OfrSupplierGuide);
            this.Controls.Add(this.tEdit_OrderHonorificTtl);
            this.Controls.Add(this.tEdit_SuppHonorificTitle);
            this.Controls.Add(this.ultraLabel20);
            this.Controls.Add(this.tNedit_StockCnsTaxFrcProcCd);
            this.Controls.Add(this.tNedit_StockMoneyFrcProcCd);
            this.Controls.Add(this.tNedit_StockUnPrcFrcProcCd);
            this.Controls.Add(this.ultraLabel44);
            this.Controls.Add(this.ultraLabel47);
            this.Controls.Add(this.uButton_SalesCnsTaxFrcProcCdGuide);
            this.Controls.Add(this.uButton_SalesMoneyFrcProcCdGuide);
            this.Controls.Add(this.uButton_SalesUnPrcFrcProcCdGuide);
            this.Controls.Add(this.ultraLabel45);
            this.Controls.Add(this.ultraLabel46);
            this.Controls.Add(this.ultraLabel18);
            this.Controls.Add(this.ultraLabel19);
            this.Controls.Add(this.ultraLabel54);
            this.Controls.Add(this.ultraLabel52);
            this.Controls.Add(this.tComboEditor_SuppCTaXLayRefCd);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.tComboEditor_SuppTaxLayMethod);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.ultraLabel9);
            this.Controls.Add(this.tEdit_PaymentSectionCode);
            this.Controls.Add(this.uButton_PaymentSectionGuide);
            this.Controls.Add(this.ultraLabel60);
            this.Controls.Add(this.tNedit_NTimeCalcStDate);
            this.Controls.Add(this.ultraLabel58);
            this.Controls.Add(this.uLabel_PayeeName1);
            this.Controls.Add(this.tNedit_PayeeCode);
            this.Controls.Add(this.ultraLabel55);
            this.Controls.Add(this.ultraLabel53);
            this.Controls.Add(this.uLabel_PayeeSnm);
            this.Controls.Add(this.tNedit_PaymentSight);
            this.Controls.Add(this.ultraLabel29);
            this.Controls.Add(this.tComboEditor_PaymentCond);
            this.Controls.Add(this.uLabel_PayeeName2);
            this.Controls.Add(this.tComboEditor_PaymentMonthCode);
            this.Controls.Add(this.uButton_PayeeNameGuide);
            this.Controls.Add(this.ultraLabel59);
            this.Controls.Add(this.tNedit_PaymentDay);
            this.Controls.Add(this.CollectMoneyCodeTitle_ULabel);
            this.Controls.Add(this.CollectMoneyDayTitle_ULabel);
            this.Controls.Add(this.tNedit_PaymentTotalDay);
            this.Controls.Add(this.TotalDayTitle_ULabel);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.ultraLabel57);
            this.Controls.Add(this.uButton_StockAgentGuide);
            this.Controls.Add(this.tEdit_StockAgentNm);
            this.Controls.Add(this.uButton_MngSectionNmGuide);
            this.Controls.Add(this.tEdit_MngSectionNm);
            this.Controls.Add(this.ultraLabel39);
            this.Controls.Add(this.ultraLabel28);
            this.Controls.Add(this.tComboEditor_PureCode);
            this.Controls.Add(this.tComboEditor_SupplierAttributeDiv);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.tComboEditor_SalesAreaCode);
            this.Controls.Add(this.BusinessTypeCodeTitle_ULabel);
            this.Controls.Add(this.tComboEditor_BusinessTypeCode);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ultraLabel27);
            this.Controls.Add(this.tEdit_SupplierSnm);
            this.Controls.Add(this.ultraLabel34);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.tEdit_SupplierKana);
            this.Controls.Add(this.tEdit_SupplierName2);
            this.Controls.Add(this.SubInfo_UTabControl);
            this.Controls.Add(this.uLabel_Payment);
            this.Controls.Add(this.uLabel_Detail);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.uLabel_CustomerNameTitle);
            this.Controls.Add(this.tNedit_SupplierCd);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.BLGoodsFullName_Title_Label);
            this.Controls.Add(this.tEdit_SupplierName1);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.BLGoodsCode_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.ultraLabel61);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.ultraLabel2);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09020UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仕入先マスタ";
            this.Load += new System.EventHandler(this.PMKHN09020UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09020UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09020UA_Closing);
            this.SubInfo0_UTabPageControl.ResumeLayout(false);
            this.SubInfo0_Panel.ResumeLayout(false);
            this.SubInfo0_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierPostNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierAddr4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierTelNo2)).EndInit();
            this.SubInfo2_UTabPageControl.ResumeLayout(false);
            this.SubInfo2_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierNote1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubInfo_UTabControl)).EndInit();
            this.SubInfo_UTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierKana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SupplierName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_MngSectionNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PureCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SupplierAttributeDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SalesAreaCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_BusinessTypeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_NTimeCalcStDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PayeeCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentSight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PaymentCond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PaymentMonthCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_PaymentTotalDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PaymentSectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SuppCTaXLayRefCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_SuppTaxLayMethod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockCnsTaxFrcProcCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockMoneyFrcProcCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_StockUnPrcFrcProcCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SuppHonorificTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OrderHonorificTtl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region ■IMasterMaintenanceArrayTypeメンバー

		# region ▼Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ▼Properties
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
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
		# endregion

		# region ▼Public Methods
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
        /// <returns>なし</returns>
        /// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2008.04.30</br>
		/// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
            bindDataSet = this._dataSet;
            tableName = _supplierDataTable.TableName;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList retList = null;


            // 抽出対象件数が0の場合は全件抽出を実行する
            status = this._supplierAcs.SearchAll( out retList, this._enterpriseCode );

            this._totalCount = retList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;
                        foreach ( Supplier supplier in retList )
                        {
                            if ( ExistsInCache( supplier ) == false )
                            {
                                CopyToDataSet( supplier, index );
                                ++index;
                            }
                        }

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Search",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_READ_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._supplierAcs,				  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        break;
                    }
            }

            totalCount = this._totalCount;
            
            return status;
		}

        /// <summary>
        /// ネクストデータ検索処理
        /// </summary>
        /// <param name="readCount">抽出対象件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        public int SearchNext( int readCount )
        {
            // ネクストデータ検索処理（未実装）
            return 0;
        }

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		public int Delete()
		{
			int status = 0;

            // 指定されたDataTableレコードに対応するデータを取得
            Supplier supplier = GetFromCache( _supplierDataTable.Rows[this._dataIndex] );
            if ( supplier == null ) return 0;

            // --- ADD 2008/12/24 [障害ID:9452対応]----------------------------------------------------------->>>>>
            for (int index = 0; index < _supplierDataTable.Rows.Count; index++)
            {
                Supplier supplierWk = GetFromCache(_supplierDataTable.Rows[index]);

                // 削除対象の仕入先と同じレコードの場合
                if (supplier.Equals(supplierWk))
                {
                    continue;
                }

                // 削除対象の仕入先が親仕入先として設定されている場合
                if (supplier.SupplierCd == supplierWk.PayeeCode)
                {
                    TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "このレコードは親仕入先として設定されているため削除できません",
                            status,
                            MessageBoxButtons.OK);
                    return (-1);
                }
            }
            // --- ADD 2008/12/24 [障害ID:9452対応]-----------------------------------------------------------<<<<<

            status = this._supplierAcs.LogicalDelete( ref supplier );
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction( status, TMsgDisp.OPE_DELETE, this._supplierAcs );
                        return status;
                    }
                case -2:
                    {
                        //主作業設定で使用中
                        TMsgDisp.Show( this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            ASSEMBLY_ID,
                            "このレコードは主作業設定で使用されているため削除できません",
                            status,
                            MessageBoxButtons.OK );
                        this.Hide();

                        return status;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "Delete",							// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_RDEL_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._supplierAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

                        return status;
                    }
            }

            // データセット展開処理
            CopyToDataSet( supplier, this._dataIndex );
			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
		{
            string supplierFormat = GetSupplierCdFormat();

			Hashtable appearanceTable = new Hashtable();

            appearanceTable.Add( DELETE_DATE, new GridColAppearance( MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red ) ); // 削除日
            appearanceTable.Add( GUID_TITLE, new GridColAppearance( MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black ) ); // GUID
            appearanceTable.Add( SUPPLIERCD_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleRight, supplierFormat, Color.Black ) ); // 仕入先コード
            appearanceTable.Add( SUPPLIERNM1_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // 仕入先名1
            appearanceTable.Add( SUPPLIERNM2_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // 仕入先名2
            appearanceTable.Add( SUPPHONORIFICTITLE_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // 仕入先敬称
            appearanceTable.Add( SUPPLIERKANA_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // 仕入先カナ
            appearanceTable.Add( SUPPLIERSNM_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // 仕入先略称
            appearanceTable.Add( MNGSECTIONCODE_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black ) ); // 管理拠点コード
            appearanceTable.Add( MNGSECTIONNAME_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // 管理拠点名称
            appearanceTable.Add( PURECODE_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // 純正区分
            appearanceTable.Add( PAYMENTSECTIONCODE_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black ) ); // 支払拠点コード
            appearanceTable.Add( PAYMENTSECTIONNAME_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // 支払拠点名称
            appearanceTable.Add( PAYEECODE_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleRight, supplierFormat, Color.Black ) ); // 支払先コード
            appearanceTable.Add( PAYEESNM_TITLE, new GridColAppearance( MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black ) ); // 支払先略称

            return appearanceTable;
		}
        /// <summary>
        /// 仕入先コードフォーマット取得
        /// </summary>
        /// <returns></returns>
        private string GetSupplierCdFormat()
        {
            UiSet uiset;
            uiSetControl1.ReadUISet( out uiset, this.tNedit_SupplierCd.Name );

            if ( uiset != null )
            {
                return new string( '0', uiset.Column );
            }
            else
            {
                return string.Empty;
            }
        }
		# endregion

		# endregion

		#region ■Private Menbers
        private DataSet _dataSet;
        private DataTable _supplierDataTable;
		private SupplierAcs _supplierAcs;
        private OfrSupplierAcs _ofrSupplierAcs;
		private SecInfoAcs _secInfoAcs;
		private int _totalCount;
		private string _enterpriseCode;
        private Dictionary<Guid, Supplier> _supplierDic;
        private NoDispData _noDispData;
        // ガイド・読み込み
        private SecInfoSetAcs _secInfoSetAcs;
        private EmployeeAcs _employeeAcs;
        private StockProcMoneyAcs _stockProcMoneyAcs;
        List<StockProcMoneyKey> _stockProcMoneyCdList;
        private AddressGuide _addressGuide;
        private static List<UserGdBd> _userGdBdListStc;
        private UserGuideAcs _userGuideAcs;
        private Dictionary<string, AllDefSet> _allDefSetDic;
        private TaxRateSet _taxRateSet;
        // プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private Supplier _supplier;

        // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
        PaymentSetAcs _paymentSetAcs;
        MoneyKindAcs _moneyKindAcs;
        // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<

		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;
		/// <summary>拠点オプションフラグ</summary>
		private bool _optSection = false;

        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		# endregion

		# region ■Consts
		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //private const string DELETE_DATE = "削除日";
        //private const string SECTIONNAME_TITLE = "所属拠点";
		
        //private const string BLGoodsCode_TITLE			= "BL商品コード";
        //private const string BLGoodsCdDerivedNo_TITLE	= "枝番";
        //private const string BLGoodsFullName_TITLE		= "BL商品名称";
        //private const string BLGoodsHalfName_TITLE		= "BL商品名称(カナ)";
        //private const string BLGoodsGenreCode_TITLE	= "BL商品分類";
        //private const string LargeGoodsGanreCode_TITLE	= "商品区分グループ";
        //private const string LargeGoodsGanreName_TITLE	= "商品区分グループ名称";
        //private const string MediumGoodsGanreCode_TITLE	= "商品区分";
        //private const string MediumGoodsGanreName_TITLE	= "商品区分名称";
        //private const string DetailGoodsGanreCode_TITLE	= "商品区分詳細";
        //private const string DetailGoodsGanreName_TITLE	= "商品区分詳細名称";
        //private const string DIVISION_TITLE = "データ区分コード";
        //private const string DIVISIONNAME_TITLE = "データ区分";

        //private const string GUID_TITLE = "GUID";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        // テーブル名
        private const string SUPPLIER_TABLE = "SUPPLIER";

        // テーブルカラム名
        private const string DELETE_DATE = "削除日　　　　　";
        private const string GUID_TITLE = "GUID";

        private const string SUPPLIERCD_TITLE = "仕入先コード";
        private const string SUPPLIERNM1_TITLE = "仕入先名1";
        private const string SUPPLIERNM2_TITLE = "仕入先名2";
        private const string SUPPHONORIFICTITLE_TITLE = "仕入先敬称";
        private const string SUPPLIERKANA_TITLE = "仕入先名(ｶﾅ)";
        private const string SUPPLIERSNM_TITLE = "仕入先略称";

        private const string MNGSECTIONCODE_TITLE = "管理拠点コード";
        private const string MNGSECTIONNAME_TITLE = "管理拠点名";

        private const string PURECODE_TITLE = "純正区分";

        private const string PAYMENTSECTIONCODE_TITLE = "支払拠点コード";
        private const string PAYMENTSECTIONNAME_TITLE = "支払拠点名";
        private const string PAYEECODE_TITLE = "支払先コード";
        private const string PAYEESNM_TITLE = "支払先略称";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //private const string MAKERU_TABLE = "LGOODSGANRE";

		//データ区分
		private const int DIVISION_USR = 0;
		private const int DIVISION_OFR = 1;

		private const string DIVISION_USR_NAME = "0";
		private const string DIVISION_OFR_NAME = "1";

		private const string DIVISION_USR_NAME_TITLE = "ユーザーデータ";
		private const string DIVISION_OFR_NAME_TITLE = "提供データ";	

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";
		private const string REFERENCE_MODE = "参照モード";

		// コントロール名称
		private const string TAB1_NAME = "GeneralTab";
		private const string TAB2_NAME = "SecurityTab";

		// Message関連定義
		private const string ASSEMBLY_ID	= "PMKHN09020U";
		private const string PG_NM			= "仕入先マスタ";
		private const string ERR_READ_MSG	= "読み込みに失敗しました。";
		private const string ERR_DPR_MSG	= "このコードは既に使用されています。";
		private const string ERR_RDEL_MSG	= "削除に失敗しました。";
		private const string ERR_UPDT_MSG	= "登録に失敗しました。";
		private const string ERR_RVV_MSG	= "復活に失敗しました。";
		private const string ERR_800_MSG	= "既に他端末より更新されています";
		private const string ERR_801_MSG	= "既に他端末より削除されています";
		private const string SDC_RDEL_MSG	= "マスタから削除されています";
		#endregion
    
		# region ※Main
		/// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMKHN09020UA());
		}
		# endregion

		#region ■IMasterMaintenanceInputStart Members
		/// <summary>
		/// 
		/// </summary>
		/// <param name="paraTable"></param>
		/// <returns></returns>
		public DialogResult ShowDialog(Hashtable paraTable)
		{
			this.ShowDialog();
			return this.DialogResult;
		}
		#endregion

		# region ■Private Methods

        // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 支払設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 支払設定マスタを取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/12/12</br>
        /// </remarks>
        private int ReadPaymentSet(out PaymentSet paymentSet)
        {
            paymentSet = new PaymentSet();
            int status = this._paymentSetAcs.Read(out paymentSet, this._enterpriseCode, 0);

            return (status);
        }

        /// <summary>
        /// 金額種別設定マスタ処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 金額種別設定マスタを取得します。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/12/12</br>
        /// </remarks>
        private int ReadMoneyKind(out Dictionary<int, MoneyKind> moneyKindDic)
        {
            moneyKindDic = new Dictionary<int, MoneyKind>();

            int status;
            ArrayList retList = new ArrayList();

            status = this._moneyKindAcs.SearchAll(out retList, this._enterpriseCode);
            if (status == 0)
            {
                foreach (MoneyKind moneyKind in retList)
                {
                    // 金額設定区分が「0:入金」を使用
                    if ((moneyKind.LogicalDeleteCode == 0) && (moneyKind.PriceStCode == 0))
                    {
                        moneyKindDic.Add(moneyKind.MoneyKindCode, moneyKind);
                    }
                }
            }

            return (status);
        }
        // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<

        # region [スライダからの単独起動対応]
        /// <summary>単独起動フラグ</summary>
        private bool _singleExecute = false;
        /// <summary>企業コード</summary>
        private string _paraEnterpriseCode = string.Empty;
        /// <summary>仕入先コード</summary>
        private int _paraSupplierCode = 0;
        # endregion

        # region [キャッシュ制御]
        /// <summary>
        /// キャッシュからの対応データ取得処理
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Supplier GetFromCache( DataRow row )
        {
            try
            {
                Guid key = (Guid)row[GUID_TITLE];

                if ( _supplierDic.ContainsKey( key ) )
                {
                    return _supplierDic[key];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// キャッシュ用ディクショナリ内存在判定処理
        /// </summary>
        /// <param name="supplier"></param>
        private bool ExistsInCache( Supplier supplier )
        {
            // GUIDをキーにして存在判定
            return this._supplierDic.ContainsKey( supplier.FileHeaderGuid );
        }
        /// <summary>
        /// キャッシュ用ディクショナリ更新処理
        /// </summary>
        /// <param name="supplier"></param>
        private void UpdateCache( Supplier supplier )
        {
            // GUIDをキーにして存在判定
            if ( this._supplierDic.ContainsKey( supplier.FileHeaderGuid ) )
            {
                // 既存なら旧データを削除
                this._supplierDic.Remove( supplier.FileHeaderGuid );
            }
            // ディクショナリに追加
            this._supplierDic.Add( supplier.FileHeaderGuid, supplier );
        }
        /// <summary>
        /// キャッシュ用ディクショナリ内削除処理
        /// </summary>
        /// <param name="supplier"></param>
        private void DeleteFromCache( Supplier supplier )
        {
            // GUIDをキーにして存在判定
            if ( this._supplierDic.ContainsKey( supplier.FileHeaderGuid ) )
            {
                // 削除
                this._supplierDic.Remove( supplier.FileHeaderGuid );
            }
        }
        # endregion
        # region [データクラス→データテーブル行]
        /// <summary>
        /// 仕入先マスタ オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="supplier">仕入先マスタ オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : 仕入先マスタ クラスをデータセットに格納します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void CopyToDataSet(Supplier supplier, int index)
		{
            DataRow row;

            if ( (index < 0) || (_supplierDataTable.Rows.Count <= index) )
            {
                // 新規と判断して、行を追加する
                _supplierDataTable.Rows.Add( _supplierDataTable.NewRow() );

                // indexを行の最終行番号する
                index = _supplierDataTable.Rows.Count - 1;
            }
            // 行取得
            row = _supplierDataTable.Rows[index];


            // 削除日付
            if ( supplier.LogicalDeleteCode == 0 )
            {
                row[DELETE_DATE] = "";
            }
            else
            {
                row[DELETE_DATE] = supplier.UpdateDateTimeJpInFormal;
            }

            row[GUID_TITLE] = supplier.FileHeaderGuid; // GUID
            row[SUPPLIERCD_TITLE] = supplier.SupplierCd; // 仕入先コード
            row[SUPPLIERNM1_TITLE] = supplier.SupplierNm1; // 仕入先名1
            row[SUPPLIERNM2_TITLE] = supplier.SupplierNm2; // 仕入先名2
            row[SUPPHONORIFICTITLE_TITLE] = supplier.SuppHonorificTitle; // 仕入先敬称
            row[SUPPLIERKANA_TITLE] = supplier.SupplierKana; // 仕入先カナ
            row[SUPPLIERSNM_TITLE] = supplier.SupplierSnm; // 仕入先略称
            row[MNGSECTIONCODE_TITLE] = supplier.MngSectionCode; // 管理拠点コード
            row[MNGSECTIONNAME_TITLE] = supplier.MngSectionName; // 管理拠点名称
            row[PURECODE_TITLE] = GetPureCodeName( supplier.PureCode ); // 純正区分
            row[PAYMENTSECTIONCODE_TITLE] = supplier.PaymentSectionCode; // 支払拠点コード
            row[PAYMENTSECTIONNAME_TITLE] = supplier.PaymentSectionName; // 支払拠点名称
            row[PAYEECODE_TITLE] = supplier.PayeeCode; // 支払先コード
            row[PAYEESNM_TITLE] = supplier.PayeeSnm; // 支払先略称

            // キャッシュ更新
            UpdateCache( supplier );
        }

        // ADD 2009/05/27 ------>>>
        /// <summary>
        /// 子仕入先マスタ オブジェクトデータセット更新処理
        /// </summary>
        /// <param name="childSupplier">子仕入先マスタ オブジェクト</param>
        /// <param name="parentSupplier">親仕入先マスタ オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ クラスをデータセットに格納します。</br>
        /// </remarks>
        private void ReflectChildSupplierToDataSet(Supplier childSupplier, Supplier parentSupplier)
        {
            DataRow row;

            int index;
            for (index = 0; index < _supplierDataTable.Rows.Count; index++)
            {
                if ((int)_supplierDataTable.Rows[index][SUPPLIERCD_TITLE] == childSupplier.SupplierCd)
                {
                    break;
                }
            }

            if (index == _supplierDataTable.Rows.Count)
            {
                return;
            }

            // 行取得
            row = _supplierDataTable.Rows[index];

            // 削除日付
            if (childSupplier.LogicalDeleteCode == 0)
            {
                row[DELETE_DATE] = "";
            }
            else
            {
                row[DELETE_DATE] = childSupplier.UpdateDateTimeJpInFormal;
            }

            row[GUID_TITLE] = childSupplier.FileHeaderGuid; // GUID
            row[SUPPLIERCD_TITLE] = childSupplier.SupplierCd; // 仕入先コード
            row[SUPPLIERNM1_TITLE] = childSupplier.SupplierNm1; // 仕入先名1
            row[SUPPLIERNM2_TITLE] = childSupplier.SupplierNm2; // 仕入先名2
            row[SUPPHONORIFICTITLE_TITLE] = childSupplier.SuppHonorificTitle; // 仕入先敬称
            row[SUPPLIERKANA_TITLE] = childSupplier.SupplierKana; // 仕入先カナ
            row[SUPPLIERSNM_TITLE] = childSupplier.SupplierSnm; // 仕入先略称
            row[MNGSECTIONCODE_TITLE] = childSupplier.MngSectionCode; // 管理拠点コード
            row[MNGSECTIONNAME_TITLE] = childSupplier.MngSectionName; // 管理拠点名称
            row[PURECODE_TITLE] = GetPureCodeName(childSupplier.PureCode); // 純正区分
            row[PAYMENTSECTIONCODE_TITLE] = childSupplier.PaymentSectionCode; // 支払拠点コード
            row[PAYMENTSECTIONNAME_TITLE] = childSupplier.PaymentSectionName; // 支払拠点名称
            row[PAYEECODE_TITLE] = childSupplier.PayeeCode; // 支払先コード
            row[PAYEESNM_TITLE] = parentSupplier.SupplierSnm; // 親仕入先の仕入先略称

            // キャッシュ更新
            UpdateCache(childSupplier);
        }
        // ADD 2009/05/27 ------<<<

        /// <summary>
        /// 純正区分名称
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetPureCodeName( int p )
        {
            switch ( p )
            {
                case 0: return "純正";
                case 1: return "優良";
            }
            return string.Empty;
        }
        # endregion
        # region [テーブル生成]
        /// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
            // DataSetが無ければ生成
            if ( _dataSet == null )
            {
                _dataSet = new DataSet();
            }
            // DataTableが無ければ生成
            if ( _supplierDataTable == null )
            {
                _supplierDataTable = new DataTable( SUPPLIER_TABLE );

                _supplierDataTable.Columns.Add( DELETE_DATE, typeof( string ) ); // 削除日
                _supplierDataTable.Columns.Add( GUID_TITLE, typeof( Guid ) ); // GUID
                _supplierDataTable.Columns.Add( SUPPLIERCD_TITLE, typeof( Int32 ) ); // 仕入先コード
                _supplierDataTable.Columns.Add( SUPPLIERNM1_TITLE, typeof( string ) ); // 仕入先名1
                _supplierDataTable.Columns.Add( SUPPLIERNM2_TITLE, typeof( string ) ); // 仕入先名2
                _supplierDataTable.Columns.Add( SUPPHONORIFICTITLE_TITLE, typeof( string ) ); // 仕入先敬称
                _supplierDataTable.Columns.Add( SUPPLIERKANA_TITLE, typeof( string ) ); // 仕入先カナ
                _supplierDataTable.Columns.Add( SUPPLIERSNM_TITLE, typeof( string ) ); // 仕入先略称
                _supplierDataTable.Columns.Add( MNGSECTIONCODE_TITLE, typeof( string ) ); // 管理拠点コード
                _supplierDataTable.Columns.Add( MNGSECTIONNAME_TITLE, typeof( string ) ); // 管理拠点名称
                _supplierDataTable.Columns.Add( PURECODE_TITLE, typeof( string ) ); // 純正区分
                _supplierDataTable.Columns.Add( PAYMENTSECTIONCODE_TITLE, typeof( string ) ); // 支払拠点コード
                _supplierDataTable.Columns.Add( PAYMENTSECTIONNAME_TITLE, typeof( string ) ); // 支払拠点名称
                _supplierDataTable.Columns.Add( PAYEECODE_TITLE, typeof( Int32 ) ); // 支払先コード
                _supplierDataTable.Columns.Add( PAYEESNM_TITLE, typeof( string ) ); // 支払先略称

                _dataSet.Tables.Add( _supplierDataTable );
            }
        }
        # endregion
        # region [画面制御]
        /// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void ScreenInitialSetting()
        {
            # region [コンボボックスアイテム（固定値）]
            //// 敬称
            //AddComboEditorItem( tComboEditor_SuppHonorificTitle, 0, Supplier.CST_HonorificTitle_0 );
            //AddComboEditorItem( tComboEditor_SuppHonorificTitle, 1, Supplier.CST_HonorificTitle_1 );
            //AddComboEditorItem( tComboEditor_SuppHonorificTitle, 2, Supplier.CST_HonorificTitle_2 );
            //// 発注書敬称
            //AddComboEditorItem( tComboEditor_OrderHonorificTtl, 0, Supplier.CST_HonorificTitle_0 );
            //AddComboEditorItem( tComboEditor_OrderHonorificTtl, 1, Supplier.CST_HonorificTitle_1 );
            //AddComboEditorItem( tComboEditor_OrderHonorificTtl, 2, Supplier.CST_HonorificTitle_2 );
            // 純正区分
            AddComboEditorItem( tComboEditor_PureCode, 0, Supplier.CST_PureCode_0 );
            AddComboEditorItem( tComboEditor_PureCode, 1, Supplier.CST_PureCode_1 );
            // 支払月区分
            AddComboEditorItem( tComboEditor_PaymentMonthCode, 0, Supplier.CST_PaymentMonthCode_0 );
            AddComboEditorItem( tComboEditor_PaymentMonthCode, 1, Supplier.CST_PaymentMonthCode_1 );
            AddComboEditorItem( tComboEditor_PaymentMonthCode, 2, Supplier.CST_PaymentMonthCode_2 );
            AddComboEditorItem( tComboEditor_PaymentMonthCode, 3, Supplier.CST_PaymentMonthCode_3 );
            // 消費税転嫁方式参照区分
            AddComboEditorItem( tComboEditor_SuppCTaXLayRefCd, 0, Supplier.CST_SuppCTaxLayRefCd_0 );
            AddComboEditorItem( tComboEditor_SuppCTaXLayRefCd, 1, Supplier.CST_SuppCTaxLayRefCd_1 );
            // 消費税転嫁方式区分
            AddComboEditorItem( tComboEditor_SuppTaxLayMethod, 0, Supplier.CST_SuppCTaxLayCd_0 );
            AddComboEditorItem( tComboEditor_SuppTaxLayMethod, 1, Supplier.CST_SuppCTaxLayCd_1 );
            AddComboEditorItem( tComboEditor_SuppTaxLayMethod, 2, Supplier.CST_SuppCTaxLayCd_2 );
            AddComboEditorItem( tComboEditor_SuppTaxLayMethod, 3, Supplier.CST_SuppCTaxLayCd_3 );
            AddComboEditorItem( tComboEditor_SuppTaxLayMethod, 9, Supplier.CST_SuppCTaxLayCd_9 );
            // 仕入先属性区分
            AddComboEditorItem( tComboEditor_SupplierAttributeDiv, 0, Supplier.CST_SupplierAttributeDiv_0 );
            AddComboEditorItem( tComboEditor_SupplierAttributeDiv, 8, Supplier.CST_SupplierAttributeDiv_8 );
            AddComboEditorItem( tComboEditor_SupplierAttributeDiv, 9, Supplier.CST_SupplierAttributeDiv_9 );

            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            // 総額表示区分
            AddComboEditorItem( tComboEditor_SuppTtlAmountDispWayCd, 0, Supplier.CST_SuppTtlAmntDspWayCd_0 );
            AddComboEditorItem( tComboEditor_SuppTtlAmountDispWayCd, 1, Supplier.CST_SuppTtlAmntDspWayCd_1 );
            // 総額表示参照区分
            AddComboEditorItem( tComboEditor_StckTtlAmntDspWayRef, 0, Supplier.CST_StckTtlAmntDspWayRef_0 );
            AddComboEditorItem( tComboEditor_StckTtlAmntDspWayRef, 1, Supplier.CST_StckTtlAmntDspWayRef_1 );
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

            // 支払条件
            // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
            //AddComboEditorItem( tComboEditor_PaymentCond, 10, Supplier.CST_PaymentCond_10 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 20, Supplier.CST_PaymentCond_20 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 30, Supplier.CST_PaymentCond_30 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 40, Supplier.CST_PaymentCond_40 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 50, Supplier.CST_PaymentCond_50 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 60, Supplier.CST_PaymentCond_60 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 70, Supplier.CST_PaymentCond_70 );
            //AddComboEditorItem( tComboEditor_PaymentCond, 80, Supplier.CST_PaymentCond_80 );

            // 支払設定マスタ読込
            PaymentSet paymentSet;
            int status = ReadPaymentSet(out paymentSet);
            if (status == 0)
            {
                // 金額種別設定マスタ読込
                Dictionary<int, MoneyKind> moneyKindDic;
                status = ReadMoneyKind(out moneyKindDic);
                if (status == 0)
                {
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd1))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd1, moneyKindDic[paymentSet.PayStMoneyKindCd1].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd2))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd2, moneyKindDic[paymentSet.PayStMoneyKindCd2].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd3))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd3, moneyKindDic[paymentSet.PayStMoneyKindCd3].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd4))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd4, moneyKindDic[paymentSet.PayStMoneyKindCd4].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd5))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd5, moneyKindDic[paymentSet.PayStMoneyKindCd5].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd6))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd6, moneyKindDic[paymentSet.PayStMoneyKindCd6].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd7))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd7, moneyKindDic[paymentSet.PayStMoneyKindCd7].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd8))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd8, moneyKindDic[paymentSet.PayStMoneyKindCd8].MoneyKindName);
                    }
                }
            }
            // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
            # endregion

            # region [コンボボックスアイテム（ユーザーガイド）]
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            int status;
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            ArrayList retList;

            // 業種（ユーザーガイドマスタより取得）
            status = this.GetDivCodeBodyList( 33, out retList );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                retList.Sort();

                AddComboEditorItem( this.tComboEditor_BusinessTypeCode, 0, " " );
                int count = 1;
                foreach ( ComboEditorItemSupplier ci in retList )
                {
                    count++;
                    AddComboEditorItem( this.tComboEditor_BusinessTypeCode, ci.Code, ci.Name );
                }
            }
            // 販売エリア（ユーザーガイドマスタより取得）
            status = this.GetDivCodeBodyList( 21, out retList );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                retList.Sort();

                AddComboEditorItem( this.tComboEditor_SalesAreaCode, 0, " " );
                int count = 1;
                foreach ( ComboEditorItemSupplier ci in retList )
                {
                    count++;
                    AddComboEditorItem( this.tComboEditor_SalesAreaCode, ci.Code, ci.Name );
                }
            }

            # endregion

        }
        /// <summary>
        /// 新レコード作成時初期入力処理
        /// </summary>
        private void SetNewRecordFirstInput( ref Supplier supplier)
        {
            // 敬称
            tEdit_SuppHonorificTitle.Text = "様";
            tEdit_OrderHonorificTtl.Text = "様";

            // 管理拠点
            SecInfoSet secInfoSet;
            if ( _secInfoAcs == null )
            {
                _secInfoAcs = new SecInfoAcs();
            }
            secInfoSet = _secInfoAcs.SecInfoSet;

            _noDispData.MngSectionCode = secInfoSet.SectionCode;
            _noDispData.PrevMngSectionName = secInfoSet.SectionGuideNm;
            tEdit_MngSectionNm.Text = secInfoSet.SectionGuideNm;

            // 仕入担当者
            _noDispData.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;
            _noDispData.PrevStockAgentName = LoginInfoAcquisition.Employee.Name;
            tEdit_StockAgentNm.Text = LoginInfoAcquisition.Employee.Name;

            // 支払拠点
            _noDispData.PaymentSectionCode = secInfoSet.SectionCode;
            _noDispData.PrevPaymentSectionName = secInfoSet.SectionGuideNm;
            tEdit_PaymentSectionCode.Text = secInfoSet.SectionGuideNm;

            // 退避用データも更新する
            supplier.SuppHonorificTitle = "様";
            supplier.OrderHonorificTtl = "様";
            supplier.MngSectionCode = secInfoSet.SectionCode;
            supplier.MngSectionName = secInfoSet.SectionGuideNm;
            supplier.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;
            supplier.StockAgentName = LoginInfoAcquisition.Employee.Name;
            supplier.PaymentSectionCode = secInfoSet.SectionCode;
            supplier.PaymentSectionName = secInfoSet.SectionGuideNm;
        }
        /// <summary>
        /// コンボエディタアイテム追加処理
        /// </summary>
        /// <param name="sender">対象コンボエディタ</param>
        /// <param name="dataValue">アイテムデータ</param>
        /// <param name="displayText">アイテム表示テキスト</param>
        private static void AddComboEditorItem( TComboEditor sender, int dataValue, string displayText )
        {
            Infragistics.Win.ValueListItem item = new Infragistics.Win.ValueListItem();
            item.DataValue = dataValue;
            item.DisplayText = displayText;

            sender.Items.Add( item );
        }
        /// <summary>
        /// コンボエディタアイテムインデックス設定処理
        /// </summary>
        /// <param name="sender">対象となるコンボエディタ</param>
        /// <param name="dataValue">設定値</param>
        private static void SetComboEditorItemIndex( TComboEditor sender, int dataValue )
        {
            int index = -1;

            if ( dataValue != 0 )
            {
                for ( int i = 0; i < sender.Items.Count; i++ )
                {
                    if ( (sender.Items[i].DataValue is int) && ((int)sender.Items[i].DataValue == dataValue) )
                    {
                        index = i;
                        break;
                    }
                }
            }
            else
            {
                //if ( (sender.Items.Count > 0) && ((int)sender.Items[0].DataValue == 0) )
                if ( sender.Items.Count > 0 )
                {
                    index = dataValue;
                }
            }
            sender.SelectedIndex = index;
        }


		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void ScreenClear()
		{
            // 名前
            tNedit_SupplierCd.SetInt( 0 );
            tEdit_SupplierName1.Clear();
            tEdit_SupplierName2.Clear();
            tEdit_SupplierSnm.Clear();
            tEdit_SupplierKana.Clear();
            //tComboEditor_SuppHonorificTitle.SelectedIndex = 0;
            //tComboEditor_OrderHonorificTtl.SelectedIndex = 0;
            tEdit_SuppHonorificTitle.Text = string.Empty;
            tEdit_OrderHonorificTtl.Text = string.Empty;

            // 詳細情報
            tEdit_MngSectionNm.Clear();
            tEdit_StockAgentNm.Clear();
            tComboEditor_PureCode.SelectedIndex = 0;
            tComboEditor_SupplierAttributeDiv.SelectedIndex = 0;
            tComboEditor_BusinessTypeCode.SelectedIndex = 0;
            tComboEditor_SalesAreaCode.SelectedIndex = 0;

            // 支払情報
            tEdit_PaymentSectionCode.Clear();
            tNedit_PayeeCode.SetInt( 0 );
            uLabel_PayeeName1.Text = string.Empty;
            uLabel_PayeeName2.Text = string.Empty;
            uLabel_PayeeSnm.Text = string.Empty;
            tNedit_PaymentTotalDay.SetInt( 0 );
            tComboEditor_PaymentMonthCode.SelectedIndex = 0;
            tNedit_PaymentDay.SetInt( 0 );
            tComboEditor_PaymentCond.SelectedIndex = 0;
            tNedit_PaymentSight.SetInt( 0 );
            tNedit_NTimeCalcStDate.SetInt( 0 );
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            tComboEditor_StckTtlAmntDspWayRef.SelectedIndex = 0;
            tComboEditor_SuppTtlAmountDispWayCd.SelectedIndex = 0;
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            tComboEditor_SuppCTaXLayRefCd.SelectedIndex = 0;
            tComboEditor_SuppTaxLayMethod.SelectedIndex = 0;
            tNedit_StockUnPrcFrcProcCd.SetInt( 0 );
            tNedit_StockMoneyFrcProcCd.SetInt( 0 );
            tNedit_StockCnsTaxFrcProcCd.SetInt( 0 );

            // 連絡先情報
            tEdit_SupplierPostNo.Clear();
            tEdit_SupplierAddr1.Clear();
            tEdit_SupplierAddr3.Clear();
            tEdit_SupplierAddr4.Clear();
            tEdit_SupplierTelNo.Clear();
            tEdit_SupplierTelNo1.Clear();
            tEdit_SupplierTelNo2.Clear();
            
            // 備考情報
            tEdit_SupplierNote1.Clear();
            tEdit_SupplierNote2.Clear();
            tEdit_SupplierNote3.Clear();
            tEdit_SupplierNote4.Clear();

            // UI非表示データ
            _noDispData.Clear();
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
            Supplier supplier = null;

            if ( this.DataIndex >= 0 )
            {
                supplier = GetFromCache( _supplierDataTable.Rows[this._dataIndex] );
                // (※キャッシュ内に対応するデータが無ければnullが返される)
            }

            if ( supplier == null )
            {
                // 新規モード
                this.Mode_Label.Text = INSERT_MODE;

                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = true;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

                //_dataIndexバッファ保持
                this._indexBuf = this._dataIndex;

                // 画面入力許可制御処理
                ScreenInputPermissionControl( INSERT_MODE );

                // 新規データ初期入力処理
                this._supplier = new Supplier();
                SetNewRecordFirstInput( ref this._supplier );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                // 画面展開処理
                DataToScreen( this._supplier );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD

                // フォーカス設定
                this.tNedit_SupplierCd.Focus();
            }
            else
            {
                if ( supplier.LogicalDeleteCode == 0 )
                {
                    // 更新モード
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ボタン設定
                    this.Ok_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    this.Revive_Button.Visible = false;
                    // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = true;
                    // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl( UPDATE_MODE );

                    // 画面展開処理
                    DataToScreen( supplier );

                    //クローン作成
                    this._supplier = supplier.Clone();
                    DispToSupplier( ref this._supplier );
                    //_dataIndexバッファ保持
                    this._indexBuf = this._dataIndex;

                    // フォーカス設定
                    this.tEdit_SupplierName1.Focus();
                    this.tEdit_SupplierName1.SelectAll();
                }
                else
                {
                    // 削除モード
                    this.Mode_Label.Text = DELETE_MODE;

                    // ボタン設定
                    this.Ok_Button.Visible = false;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;
                    // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                    this.Renewal_Button.Visible = false;
                    // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

                    //_dataIndexバッファ保持
                    this._indexBuf = this._dataIndex;

                    // 画面入力許可制御処理
                    ScreenInputPermissionControl( DELETE_MODE );

                    // 画面展開処理
                    DataToScreen( supplier );

                    // フォーカス設定
                    this.Delete_Button.Focus();
                }

            }
            //終了時の比較のため、現在のフォーム入力状態を保持
            this._supplier = new Supplier();
            DispToSupplier(ref this._supplier);
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="mode">編集モード</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void ScreenInputPermissionControl(string mode)
		{
            // 全コントロールリスト
            # region [allControlList]
            List<Control> allControlList = new List<Control>( new Control[]
                {
                    tNedit_SupplierCd,
                    tEdit_SupplierName1,
                    tEdit_SupplierName2,
                    tEdit_SupplierSnm,
                    tEdit_SupplierKana,
                    //tComboEditor_SuppHonorificTitle,
                    tEdit_SuppHonorificTitle,
                    //tComboEditor_OrderHonorificTtl,
                    tEdit_OrderHonorificTtl,
                    tEdit_MngSectionNm,
                    tEdit_StockAgentNm,
                    tComboEditor_PureCode,
                    tComboEditor_SupplierAttributeDiv,
                    tComboEditor_BusinessTypeCode,
                    tComboEditor_SalesAreaCode,
                    tEdit_PaymentSectionCode,
                    tNedit_PayeeCode,
                    tNedit_PaymentTotalDay,
                    tComboEditor_PaymentMonthCode,
                    tNedit_PaymentDay,
                    tComboEditor_PaymentCond,
                    tNedit_PaymentSight,
                    tNedit_NTimeCalcStDate,
                    /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                    tComboEditor_StckTtlAmntDspWayRef,
                    tComboEditor_SuppTtlAmountDispWayCd,
                       --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                    tComboEditor_SuppCTaXLayRefCd,
                    tComboEditor_SuppTaxLayMethod,
                    tNedit_StockUnPrcFrcProcCd,
                    tNedit_StockMoneyFrcProcCd,
                    tNedit_StockCnsTaxFrcProcCd,
                    tEdit_SupplierPostNo,
                    tEdit_SupplierAddr1,
                    tEdit_SupplierAddr3,
                    tEdit_SupplierAddr4,
                    tEdit_SupplierTelNo,
                    tEdit_SupplierTelNo1,
                    tEdit_SupplierTelNo2,
                    tEdit_SupplierNote1,
                    tEdit_SupplierNote2,
                    tEdit_SupplierNote3,
                    tEdit_SupplierNote4,
                    uButton_OfrSupplierGuide,
                    uButton_MngSectionNmGuide,
                    uButton_StockAgentGuide,
                    uButton_PaymentSectionGuide,
                    uButton_PayeeNameGuide,
                    uButton_SalesUnPrcFrcProcCdGuide,
                    uButton_SalesMoneyFrcProcCdGuide,
                    uButton_SalesCnsTaxFrcProcCdGuide,
                    uButton_AddressGuide,
                    uButton_Note1Guide,
                    uButton_Note2Guide,
                    uButton_Note3Guide,
                    uButton_Note4Guide
                } );
            # endregion

            // 入力可能コントロールリスト
            List<Control> enableControlList = new List<Control>();

			switch(mode)
			{
				case INSERT_MODE:		// 新規
                    {
                        # region [enableControlList]
                        enableControlList.AddRange( new Control[]
                            {
                                tNedit_SupplierCd,
                                tEdit_SupplierName1,
                                tEdit_SupplierName2,
                                tEdit_SupplierSnm,
                                tEdit_SupplierKana,
                                //tComboEditor_SuppHonorificTitle,
                                tEdit_SuppHonorificTitle,
                                //tComboEditor_OrderHonorificTtl,
                                tEdit_OrderHonorificTtl,
                                tEdit_MngSectionNm,
                                tEdit_StockAgentNm,
                                tComboEditor_PureCode,
                                tComboEditor_SupplierAttributeDiv,
                                tComboEditor_BusinessTypeCode,
                                tComboEditor_SalesAreaCode,
                                tEdit_PaymentSectionCode,
                                tNedit_PayeeCode,
                                tNedit_PaymentTotalDay,
                                tComboEditor_PaymentMonthCode,
                                tNedit_PaymentDay,
                                tComboEditor_PaymentCond,
                                tNedit_PaymentSight,
                                tNedit_NTimeCalcStDate,
                                /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                tComboEditor_StckTtlAmntDspWayRef,
                                tComboEditor_SuppTtlAmountDispWayCd,
                                   --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                tComboEditor_SuppCTaXLayRefCd,
                                tComboEditor_SuppTaxLayMethod,
                                tNedit_StockUnPrcFrcProcCd,
                                tNedit_StockMoneyFrcProcCd,
                                tNedit_StockCnsTaxFrcProcCd,
                                tEdit_SupplierPostNo,
                                tEdit_SupplierAddr1,
                                tEdit_SupplierAddr3,
                                tEdit_SupplierAddr4,
                                tEdit_SupplierTelNo,
                                tEdit_SupplierTelNo1,
                                tEdit_SupplierTelNo2,
                                tEdit_SupplierNote1,
                                tEdit_SupplierNote2,
                                tEdit_SupplierNote3,
                                tEdit_SupplierNote4,
                                uButton_OfrSupplierGuide,
                                uButton_MngSectionNmGuide,
                                uButton_StockAgentGuide,
                                uButton_PaymentSectionGuide,
                                uButton_PayeeNameGuide,
                                uButton_SalesUnPrcFrcProcCdGuide,
                                uButton_SalesMoneyFrcProcCdGuide,
                                uButton_SalesCnsTaxFrcProcCdGuide,
                                uButton_AddressGuide,
                                uButton_Note1Guide,
                                uButton_Note2Guide,
                                uButton_Note3Guide,
                                uButton_Note4Guide
                            } );
                        # endregion
                        break;
					}
				case UPDATE_MODE:		// 更新
					{
                        # region [enableControlList]
                        enableControlList.AddRange( new Control[]
                            {
                                //tNedit_SupplierCd,
                                tEdit_SupplierName1,
                                tEdit_SupplierName2,
                                tEdit_SupplierSnm,
                                tEdit_SupplierKana,
                                //tComboEditor_SuppHonorificTitle,
                                tEdit_SuppHonorificTitle,
                                //tComboEditor_OrderHonorificTtl,
                                tEdit_OrderHonorificTtl,
                                tEdit_MngSectionNm,
                                tEdit_StockAgentNm,
                                tComboEditor_PureCode,
                                tComboEditor_SupplierAttributeDiv,
                                tComboEditor_BusinessTypeCode,
                                tComboEditor_SalesAreaCode,
                                tEdit_PaymentSectionCode,
                                tNedit_PayeeCode,
                                tNedit_PaymentTotalDay,
                                tComboEditor_PaymentMonthCode,
                                tNedit_PaymentDay,
                                tComboEditor_PaymentCond,
                                tNedit_PaymentSight,
                                tNedit_NTimeCalcStDate,
                                /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                tComboEditor_StckTtlAmntDspWayRef,
                                tComboEditor_SuppTtlAmountDispWayCd,
                                   --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                tComboEditor_SuppCTaXLayRefCd,
                                tComboEditor_SuppTaxLayMethod,
                                tNedit_StockUnPrcFrcProcCd,
                                tNedit_StockMoneyFrcProcCd,
                                tNedit_StockCnsTaxFrcProcCd,
                                tEdit_SupplierPostNo,
                                tEdit_SupplierAddr1,
                                tEdit_SupplierAddr3,
                                tEdit_SupplierAddr4,
                                tEdit_SupplierTelNo,
                                tEdit_SupplierTelNo1,
                                tEdit_SupplierTelNo2,
                                tEdit_SupplierNote1,
                                tEdit_SupplierNote2,
                                tEdit_SupplierNote3,
                                tEdit_SupplierNote4,
                                //uButton_OfrSupplierGuide,
                                uButton_MngSectionNmGuide,
                                uButton_StockAgentGuide,
                                uButton_PaymentSectionGuide,
                                uButton_PayeeNameGuide,
                                uButton_SalesUnPrcFrcProcCdGuide,
                                uButton_SalesMoneyFrcProcCdGuide,
                                uButton_SalesCnsTaxFrcProcCdGuide,
                                uButton_AddressGuide,
                                uButton_Note1Guide,
                                uButton_Note2Guide,
                                uButton_Note3Guide,
                                uButton_Note4Guide
                            } );
                        # endregion
						break;
					}
				case DELETE_DATE:		// 削除
				case REFERENCE_MODE:	// 参照
					{
                        # region [enableControlList]
                        //enableControlList.Clear();
                        # endregion
                        break;
					}
			}

            // 各コントロールのenabledを適用
            foreach ( Control control in allControlList )
            {
                if ( enableControlList.Contains( control ) )
                {
                    control.Enabled = true;
                }
                else
                {
                    control.Enabled = false;
                }
            }
        }
        #endregion

        # region [画面←→データ　相互変換]
        /// <summary>
        /// 仕入先マスタ クラス画面展開処理
		/// </summary>
		/// <param name="supplier">仕入先マスタ オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 仕入先マスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void DataToScreen(Supplier supplier)
        {
            # region [Supplier→Screen]
            // 名前
            tNedit_SupplierCd.SetInt( supplier.SupplierCd );
            tEdit_SupplierName1.Text = supplier.SupplierNm1;
            tEdit_SupplierName2.Text = supplier.SupplierNm2;
            tEdit_SupplierSnm.Text = supplier.SupplierSnm;
            tEdit_SupplierKana.Text = supplier.SupplierKana;
            //tComboEditor_SuppHonorificTitle.Text = supplier.SuppHonorificTitle;
            tEdit_SuppHonorificTitle.Text = supplier.SuppHonorificTitle;
            //tComboEditor_OrderHonorificTtl.Text = supplier.OrderHonorificTtl;
            tEdit_OrderHonorificTtl.Text = supplier.OrderHonorificTtl;

            // 詳細情報
            tEdit_MngSectionNm.Text = supplier.MngSectionName;
            tEdit_StockAgentNm.Text = supplier.StockAgentName;
            SetComboEditorItemIndex( tComboEditor_PureCode, supplier.PureCode );
            SetComboEditorItemIndex( tComboEditor_SupplierAttributeDiv, supplier.SupplierAttributeDiv );
            SetComboEditorItemIndex( tComboEditor_BusinessTypeCode, supplier.BusinessTypeCode );
            SetComboEditorItemIndex( tComboEditor_SalesAreaCode, supplier.SalesAreaCode );

            // 支払情報
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            tEdit_PaymentSectionCode.Text = supplier.PaymentSectionName;
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            tNedit_PayeeCode.SetInt( supplier.PayeeCode );
            uLabel_PayeeName1.Text = supplier.PayeeName;
            uLabel_PayeeName2.Text = supplier.PayeeName2;
            uLabel_PayeeSnm.Text = supplier.PayeeSnm;
            tNedit_PaymentTotalDay.SetInt( supplier.PaymentTotalDay );
            SetComboEditorItemIndex( tComboEditor_PaymentMonthCode, supplier.PaymentMonthCode );
            tNedit_PaymentDay.SetInt( supplier.PaymentDay );
            SetComboEditorItemIndex( tComboEditor_PaymentCond, supplier.PaymentCond );
            tNedit_PaymentSight.SetInt( supplier.PaymentSight );
            tNedit_NTimeCalcStDate.SetInt( supplier.NTimeCalcStDate );
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            SetComboEditorItemIndex( tComboEditor_StckTtlAmntDspWayRef, supplier.StckTtlAmntDspWayRef );
            SetComboEditorItemIndex( tComboEditor_SuppTtlAmountDispWayCd, supplier.SuppTtlAmntDspWayCd );
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            SetComboEditorItemIndex( tComboEditor_SuppCTaXLayRefCd, supplier.SuppCTaxLayRefCd );
            SetComboEditorItemIndex( tComboEditor_SuppTaxLayMethod, supplier.SuppCTaxLayCd );
            tNedit_StockUnPrcFrcProcCd.SetInt( supplier.StockUnPrcFrcProcCd );
            tNedit_StockMoneyFrcProcCd.SetInt( supplier.StockMoneyFrcProcCd );
            tNedit_StockCnsTaxFrcProcCd.SetInt( supplier.StockCnsTaxFrcProcCd );

            // 連絡先情報
            tEdit_SupplierPostNo.Text = supplier.SupplierPostNo;
            tEdit_SupplierAddr1.Text = supplier.SupplierAddr1;
            tEdit_SupplierAddr3.Text = supplier.SupplierAddr3;
            tEdit_SupplierAddr4.Text = supplier.SupplierAddr4;
            tEdit_SupplierTelNo.Text = supplier.SupplierTelNo;
            tEdit_SupplierTelNo1.Text = supplier.SupplierTelNo1;
            tEdit_SupplierTelNo2.Text = supplier.SupplierTelNo2;

            // 備考情報
            tEdit_SupplierNote1.Text = supplier.SupplierNote1;
            tEdit_SupplierNote2.Text = supplier.SupplierNote2;
            tEdit_SupplierNote3.Text = supplier.SupplierNote3;
            tEdit_SupplierNote4.Text = supplier.SupplierNote4;

            // UI非表示データ
            _noDispData.SetFromData( supplier );


            // 支払先情報更新
            if (supplier.SupplierCd != supplier.PayeeCode)
            {
                Supplier payee;
                if (ReadSupplier(supplier.PayeeCode, out payee))
                {
                    SettingPayeeToScreen(payee);
                }

                // --- ADD 2008/12/24 [障害ID:9452対応]----------------------------------------------------------->>>>>
                SettingEnableBySuppTtlAmountDispWayCd(payee.SuppTtlAmntDspWayCd);
                SettingEnableBySuppCTaXLayRefCd(payee.SuppCTaxLayRefCd);
                // --- ADD 2008/12/24 [障害ID:9452対応]-----------------------------------------------------------<<<<<
            }
            // --- ADD 2008/12/24 [障害ID:9452対応]----------------------------------------------------------->>>>>
            else
            {
                SettingEnableBySuppTtlAmountDispWayCd(supplier.SuppTtlAmntDspWayCd);
                SettingEnableBySuppCTaXLayRefCd(supplier.SuppCTaxLayRefCd);
            }
            // --- ADD 2008/12/24 [障害ID:9452対応]-----------------------------------------------------------<<<<<

            // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
            tEdit_PaymentSectionCode.Text = supplier.PaymentSectionName;
            // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<

            // 全体設定参照区分系
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            SettingEnableByStckTtlAmntDspWayRef( supplier.StckTtlAmntDspWayRef );
            SettingEnableBySuppTtlAmountDispWayCd( supplier.SuppTtlAmntDspWayCd );
            SettingEnableBySuppCTaXLayRefCd( supplier.SuppCTaxLayRefCd );
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

            # endregion
        }

        /// <summary>
		/// Valueチェック処理（int）
		/// </summary>
		/// <param name="sorce">tComboのValue</param>
		/// <returns>チェック後の値</returns>
		/// <remarks>
		/// <br>Note       : tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
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
        /// 画面情報仕入先マスタ クラス格納処理
		/// </summary>
		/// <param name="supplier">仕入先マスタ オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 画面情報から仕入先マスタ オブジェクトにデータを格納します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void DispToSupplier(ref Supplier supplier)
		{
            if ( supplier == null )
            {
                // 新規の場合
                supplier = new Supplier();
            }

            # region [Screen→Supplier]

            // UI非表示データをセット
            _noDispData.SetToData( ref supplier );

            // 名前
            supplier.SupplierCd = tNedit_SupplierCd.GetInt();
            supplier.SupplierNm1 = tEdit_SupplierName1.Text;
            supplier.SupplierNm2 = tEdit_SupplierName2.Text;
            supplier.SupplierSnm = tEdit_SupplierSnm.Text;
            supplier.SupplierKana = tEdit_SupplierKana.Text;
            //supplier.SuppHonorificTitle = tComboEditor_SuppHonorificTitle.Text;
            supplier.SuppHonorificTitle = tEdit_SuppHonorificTitle.Text;
            //supplier.OrderHonorificTtl = tComboEditor_OrderHonorificTtl.Text;
            supplier.OrderHonorificTtl = tEdit_OrderHonorificTtl.Text;

            // 詳細情報
            supplier.MngSectionName = tEdit_MngSectionNm.Text;
            supplier.StockAgentName = tEdit_StockAgentNm.Text;
            supplier.PureCode = GetValue( tComboEditor_PureCode );
            supplier.SupplierAttributeDiv = GetValue( tComboEditor_SupplierAttributeDiv );
            supplier.BusinessTypeCode = GetValue( tComboEditor_BusinessTypeCode );
            supplier.BusinessTypeName = tComboEditor_BusinessTypeCode.Text;
            supplier.SalesAreaCode = GetValue( tComboEditor_SalesAreaCode );
            supplier.SalesAreaName = tComboEditor_SalesAreaCode.Text;

            // 支払情報
            supplier.PaymentSectionName = tEdit_PaymentSectionCode.Text;
            supplier.PayeeCode = tNedit_PayeeCode.GetInt();
            supplier.PayeeName = uLabel_PayeeName1.Text;
            supplier.PayeeName2 = uLabel_PayeeName2.Text;
            supplier.PayeeSnm = uLabel_PayeeSnm.Text;
            supplier.PaymentTotalDay = tNedit_PaymentTotalDay.GetInt();
            supplier.PaymentMonthCode = GetValue( tComboEditor_PaymentMonthCode );
            supplier.PaymentMonthName = tComboEditor_PaymentMonthCode.Text;
            supplier.PaymentDay = tNedit_PaymentDay.GetInt();
            supplier.PaymentCond = GetValue( tComboEditor_PaymentCond );
            supplier.PaymentSight = tNedit_PaymentSight.GetInt();
            supplier.NTimeCalcStDate = tNedit_NTimeCalcStDate.GetInt();
            // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
            //supplier.StckTtlAmntDspWayRef = GetValue( tComboEditor_StckTtlAmntDspWayRef );
            //supplier.SuppTtlAmntDspWayCd = GetValue( tComboEditor_SuppTtlAmountDispWayCd );
            supplier.StckTtlAmntDspWayRef = 0;
            supplier.SuppTtlAmntDspWayCd = 0;
            // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
            supplier.SuppCTaxLayRefCd = GetValue(tComboEditor_SuppCTaXLayRefCd);
            supplier.SuppCTaxLayCd = GetValue( tComboEditor_SuppTaxLayMethod );
            supplier.SuppCTaxLayMethodNm = tComboEditor_SuppTaxLayMethod.Text;
            supplier.StockUnPrcFrcProcCd = tNedit_StockUnPrcFrcProcCd.GetInt();
            supplier.StockMoneyFrcProcCd = tNedit_StockMoneyFrcProcCd.GetInt();
            supplier.StockCnsTaxFrcProcCd = tNedit_StockCnsTaxFrcProcCd.GetInt();

            // 連絡先情報
            supplier.SupplierPostNo = tEdit_SupplierPostNo.Text;
            supplier.SupplierAddr1 = tEdit_SupplierAddr1.Text;
            supplier.SupplierAddr3 = tEdit_SupplierAddr3.Text;
            supplier.SupplierAddr4 = tEdit_SupplierAddr4.Text;
            supplier.SupplierTelNo = tEdit_SupplierTelNo.Text;
            supplier.SupplierTelNo1 = tEdit_SupplierTelNo1.Text;
            supplier.SupplierTelNo2 = tEdit_SupplierTelNo2.Text;

            // 備考情報
            supplier.SupplierNote1 = tEdit_SupplierNote1.Text;
            supplier.SupplierNote2 = tEdit_SupplierNote2.Text;
            supplier.SupplierNote3 = tEdit_SupplierNote3.Text;
            supplier.SupplierNote4 = tEdit_SupplierNote4.Text;

            // 課税区分（転嫁方式に依存）
            if ( supplier.SuppCTaxLayCd == 9 )
            {
                supplier.SuppCTaxationCd = 1;   // 1:非課税
            }
            else
            {
                supplier.SuppCTaxationCd = 0;   // 0:課税
            }


            # endregion
        }
        /// <summary>
        /// コンボエディタ値取得処理
        /// </summary>
        /// <param name="tComboEditor"></param>
        /// <returns></returns>
        private static int GetValue( TComboEditor tComboEditor )
        {
            try
            {
                return (int)tComboEditor.SelectedItem.DataValue;
            }
            catch
            {
                try
                {
                    return (int)tComboEditor.Items[0].DataValue;
                }
                catch
                {
                    return 0;
                }
            }
        }
        # endregion
        # region [入力チェック]
        /// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <param name="loginID">ログインID</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
 		private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
		{
			bool result = true;

            // 仕入先コード
            if ( this.tNedit_SupplierCd.GetInt() == 0 )
            {
                control = this.tNedit_SupplierCd;
                message = "仕入先コードを入力して下さい。";
                result = false;
            }
            // DEL 2009/06/26 ------>>>
            //// 仕入先名称１
            //else if ( this.tEdit_SupplierName1.Text.Trim() == string.Empty )
            //{
            //    control = this.tEdit_SupplierName1;
            //    message = "仕入先名を入力して下さい。";
            //    result = false;
            //}
            //// 仕入先略称
            //else if ( this.tEdit_SupplierSnm.Text.Trim() == string.Empty )
            //{
            //    control = this.tEdit_SupplierSnm;
            //    message = "仕入先略称を入力して下さい。";
            //    result = false;
            //}
            // DEL 2009/06/26 ------<<<
            // 仕入先カナ
            else if ( this.tEdit_SupplierKana.Text.Trim() == string.Empty )
            {
                control = this.tEdit_SupplierKana;
                message = "仕入先名(ｶﾅ)を入力して下さい。";
                result = false;
            }
            else if ( !uiSetControl1.CheckMatchingSet( tEdit_SupplierKana ) )
            {
                control = this.tEdit_SupplierKana;
                message = "仕入先名(ｶﾅ)が不正です。";
                result = false;
            }
            // 管理拠点
            else if ( _noDispData.MngSectionCode == string.Empty )
            {
                control = this.tEdit_MngSectionNm;
                message = "管理拠点を入力して下さい。";
                result = false;
            }
            // 仕入担当者
            else if ( _noDispData.StockAgentCode == string.Empty )
            {
                control = this.tEdit_StockAgentNm;
                message = "仕入担当者を入力して下さい。";
                result = false;
            }
            // 支払拠点
            else if ( _noDispData.PaymentSectionCode == string.Empty )
            {
                control = this.tEdit_PaymentSectionCode;
                message = "支払拠点を入力して下さい。";
                result = false;
            }
            // 支払先
            else if ( this.tNedit_PayeeCode.GetInt() == 0 )
            {
                control = this.tNedit_PayeeCode;
                message = "支払先を入力して下さい。";
                result = false;
            }
            // 支払締日
            else if ( this.tNedit_PaymentTotalDay.GetInt() == 0 )
            {
                control = this.tNedit_PaymentTotalDay;
                message = "支払締日を入力して下さい。";
                result = false;
            }
            else if ( !uiSetControl1.CheckMatchingSet( tNedit_PaymentTotalDay ) || this.tNedit_PaymentTotalDay.GetInt() > 31 )
            {
                control = this.tNedit_PaymentTotalDay;
                message = "支払締日が不正です。";
                result = false;
            }
            // 支払日
            else if ( this.tNedit_PaymentDay.GetInt() == 0 )
            {
                control = this.tNedit_PaymentDay;
                message = "支払日を入力して下さい。";
                result = false;
            }
            else if ( !uiSetControl1.CheckMatchingSet( tNedit_PaymentDay ) || this.tNedit_PaymentDay.GetInt() > 31 )
            {
                control = this.tNedit_PaymentDay;
                message = "支払日が不正です。";
                result = false;
            }
            // 次回勘定開始日
            else if ( !uiSetControl1.CheckMatchingSet( tNedit_NTimeCalcStDate ) || this.tNedit_NTimeCalcStDate.GetInt() > 31 )
            {
                control = this.tNedit_NTimeCalcStDate;
                message = "次回勘定開始日が不正です。";
                result = false;
            }
            // 支払サイト
            else if ( !uiSetControl1.CheckMatchingSet( tNedit_PaymentSight ) )
            {
                control = this.tNedit_PaymentSight;
                message = "支払サイトが不正です。";
                result = false;
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
            // 単価端数処理コード
            else if ( !ExistsStockProcMoney( 2, tNedit_StockUnPrcFrcProcCd.GetInt() ) )
            {
                control = this.tNedit_StockUnPrcFrcProcCd;
                message = "単価端数処理コードが不正です。";
                result = false;
            }
            // 金額端数処理コード
            else if ( !ExistsStockProcMoney( 0, tNedit_StockMoneyFrcProcCd.GetInt() ) )
            {
                control = this.tNedit_StockMoneyFrcProcCd;
                message = "金額端数処理コードが不正です。";
                result = false;
            }
            // 消費税端数処理コード
            else if ( !ExistsStockProcMoney( 1, tNedit_StockCnsTaxFrcProcCd.GetInt() ) )
            {
                control = this.tNedit_StockCnsTaxFrcProcCd;
                message = "消費税端数処理コードが不正です。";
                result = false;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD

			return result;
        }
        # endregion

        # region [排他処理関連]
        /// <summary>
		/// 排他処理（メッセージ表示のみ）
		/// </summary>
		/// <param name="operation">オペレーション</param>
		/// <param name="erObject">エラーオブジェクト</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理メッセージを表示します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void ExclusiveTransaction(int status, string operation, object erObject)
		{				   
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ExclusiveTransaction",				// 処理名称
						operation,							// オペレーション
						ERR_800_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ExclusiveTransaction",				// 処理名称
						operation,							// オペレーション
						ERR_801_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
			}
        }
        # endregion
        # endregion

        #region ■Control Events
        /// <summary>
		/// Form.Load イベント(PMKHN09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        private void PMKHN09020UA_Load(object sender, System.EventArgs e)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/26 ADD
            // 単独起動の場合の処理
            # region [スライダからの単独起動対応]
            if ( _singleExecute )
            {
                // 表示前の検索処理
                int totalCount = 0;
                int readCount = 0;
                this.Search( ref totalCount, readCount );

                // 表示する行index取得
                this.DataIndex = -1;
                for ( int index = 0; index < _supplierDataTable.Rows.Count; index++ )
                {
                    if ( (int)_supplierDataTable.Rows[index][SUPPLIERCD_TITLE] == _paraSupplierCode )
                    {
                        this.DataIndex = index;
                        break;
                    }
                }

                // プロパティ設定
                //fm.CanClose = false;
                this.StartPosition = FormStartPosition.CenterScreen;

                // 画面Skin設定
                ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
                _controlScreenSkin.LoadSkin();
                _controlScreenSkin.SettingScreenSkin( this );

            }
            # endregion
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/26 ADD

            //---------------------------------------------
            // ボタンアイコン
            //---------------------------------------------
            // アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
            this.Renewal_Button.ImageList = imageList16;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;
            // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

            //---------------------------------------------
            // ガイドボタン
            //---------------------------------------------
            UltraButton[] guideButtons = new UltraButton[]
                {
                    uButton_OfrSupplierGuide,
                    uButton_MngSectionNmGuide,
                    uButton_StockAgentGuide,
                    uButton_PaymentSectionGuide,
                    uButton_PayeeNameGuide,
                    uButton_SalesUnPrcFrcProcCdGuide,
                    uButton_SalesMoneyFrcProcCdGuide,
                    uButton_SalesCnsTaxFrcProcCdGuide,
                    uButton_AddressGuide,
                    uButton_Note1Guide,
                    uButton_Note2Guide,
                    uButton_Note3Guide,
                    uButton_Note4Guide
                };
            foreach ( UltraButton button in guideButtons )
            {
                button.ImageList = imageList16;
                button.Appearance.Image = Size16_Index.STAR1;
            }
            //---------------------------------------------
            // タブアイコン
            //---------------------------------------------
            this.SubInfo_UTabControl.ImageList = imageList16;
            this.SubInfo_UTabControl.Tabs[0].Appearance.Image = (int)Size16_Index.MAIN;
            this.SubInfo_UTabControl.Tabs[1].Appearance.Image = (int)Size16_Index.CUSTOMERNOTE;


			// 画面初期設定処理
			ScreenInitialSetting();
		}

		/// <summary>
        /// Form.Closing イベント(PMKHN09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        private void PMKHN09020UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;

			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
        /// Control.VisibleChanged イベント(PMKHN09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
        private void PMKHN09020UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}

			// 自分自身が非表示になった場合、
			// またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (SaveProc() == false)
			{
				return;
			}
			// 新規モードの場合は画面を終了せずに連続入力を可能とする
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				// データインデックスを初期化する
				this.DataIndex = -1;

				// 画面クリア処理
				ScreenClear();

				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
                this.Renewal_Button.Visible = true;
                // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

				ScreenInputPermissionControl(INSERT_MODE);

				// 新規データ作成
                this._supplier = new Supplier();
                // 新規データ初期入力処理
                SetNewRecordFirstInput( ref this._supplier );
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                // 画面展開処理
                DataToScreen( this._supplier );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
				DispToSupplier(ref this._supplier);

				this.tNedit_SupplierCd.Focus();
			}
			else
			{
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
			}
		}

		/// <summary>
        /// 仕入先マスタ 情報登録処理
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
        /// <br>Note       : 仕入先マスタ 情報登録を行います。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private bool SaveProc()
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Control control = null;
            string message = null;
            string loginID = "";

            Supplier supplier = null;

            // 既存修正ならばキャッシュから旧データを一度取得
            if ( this.DataIndex >= 0 )
            {
                supplier = GetFromCache( _supplierDataTable.Rows[_dataIndex] );
            }

            // 入力チェック
            if ( !ScreenDataCheck( ref control, ref message, loginID ) )
            {
                TMsgDisp.Show(
                    this,								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                    ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                    message,							// 表示するメッセージ 
                    0,									// ステータス値
                    MessageBoxButtons.OK );				// 表示するボタン

                control.Focus();
                return false;
            }

            // 画面入力からデータ取得
            this.DispToSupplier( ref supplier );

            // ADD 2009/05/27 ------>>>
            // 子仕入先情報が返ってくるのでリストの変更
            ArrayList supplierList = new ArrayList();
            supplierList.Add(supplier);
            // ADD 2009/05/27 ------<<<
            
            // 書き込み
            //status = this._supplierAcs.Write( ref supplier );     // DEL 2009/05/27
            status = this._supplierAcs.Write(ref supplierList);     // ADD 2009/05/27

            // 結果分岐
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            ERR_DPR_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            MessageBoxButtons.OK );				// 表示するボタン

                        this.tNedit_SupplierCd.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction( status, TMsgDisp.OPE_UPDATE, this._supplierAcs );

                        if ( UnDisplaying != null )
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                            UnDisplaying( this, me );
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if ( CanClose == true )
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
                        TMsgDisp.Show(
                            this,								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
                            ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                            this.Text,							// プログラム名称
                            "SaveProc",							// 処理名称
                            TMsgDisp.OPE_UPDATE,				// オペレーション
                            ERR_UPDT_MSG,						// 表示するメッセージ 
                            status,								// ステータス値
                            this._supplierAcs,					// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

                        if ( UnDisplaying != null )
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                            UnDisplaying( this, me );
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if ( CanClose == true )
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return false;
                    }
            }

            // DataSet展開処理
            //CopyToDataSet( supplier, this.DataIndex );    // DEL 2009/05/27

            // ADD 2009/05/27 ------>>>
            // 親の仕入先情報をDataSet展開処理
            Supplier parentSupplier = supplierList[0] as Supplier;
            CopyToDataSet(parentSupplier, this.DataIndex);

            // 子の仕入先情報をDataSet更新処理
            for (int i = 1; i < supplierList.Count; i++)
            {
                Supplier childSupplier = supplierList[i] as Supplier;
                ReflectChildSupplierToDataSet(childSupplier, parentSupplier);
            }
            // ADD 2009/05/27 ------<<<
            
			return true;
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{   
            // 削除モード以外の場合は保存確認処理を行う
            if (this.Mode_Label.Text != DELETE_MODE)
			{
				//保存確認
				Supplier compareSupplier = new Supplier();
				compareSupplier = this._supplier.Clone();
                //現在の画面情報を取得する
                DispToSupplier(ref compareSupplier);

				//最初に取得した画面情報と比較
				if (!(this._supplier.Equals(compareSupplier)))	
				{
					//画面情報が変更されていた場合は、保存確認メッセージを表示する
					DialogResult res = TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						"",									// 表示するメッセージ 
						0,									// ステータス値
						MessageBoxButtons.YesNoCancel);		// 表示するボタン

					switch(res)
					{
						case DialogResult.Yes:
						{
							if (SaveProc() == false)
							{
								return;
							}

							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
								UnDisplaying(this, me);
							}

							break;
						}
						case DialogResult.No:
						{
							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
								UnDisplaying(this, me);
							}

							break;
						}
						default:
						{
                            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tNedit_SupplierCd.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                            return;
						}
					}
				}
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
		}

		/// <summary>
		/// Control.Click イベント(Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
            int status = 0;
            DialogResult result = TMsgDisp.Show(
                this,													// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_QUESTION,						// エラーレベル
                ASSEMBLY_ID,											// アセンブリＩＤまたはクラスＩＤ
                "データを削除します。" + "\r\n" + "よろしいですか？",	// 表示するメッセージ 
                0,														// ステータス値
                MessageBoxButtons.OKCancel,								// 表示するボタン
                MessageBoxDefaultButton.Button2 );						// 初期表示ボタン


            if ( result == DialogResult.OK )
            {
                // 選択レコードに対応するデータを取得
                Supplier supplier = GetFromCache( _supplierDataTable.Rows[this._dataIndex] );

                // 完全削除
                status = this._supplierAcs.Delete( supplier );

                // 結果分岐
                switch ( status )
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // テーブルから削除
                            _supplierDataTable.Rows[this._dataIndex].Delete();
                            // キャッシュから削除
                            DeleteFromCache( supplier );

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction( status, TMsgDisp.OPE_DELETE, this._supplierAcs );

                            if ( UnDisplaying != null )
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                                UnDisplaying( this, me );
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if ( CanClose == true )
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,								  // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                                ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                                this.Text,							  // プログラム名称
                                "Delete_Button_Click",				  // 処理名称
                                TMsgDisp.OPE_DELETE,				  // オペレーション
                                ERR_RDEL_MSG,						  // 表示するメッセージ 
                                status,								  // ステータス値
                                this._supplierAcs,					  // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				  // 表示するボタン
                                MessageBoxDefaultButton.Button1 );	  // 初期表示ボタン

                            if ( UnDisplaying != null )
                            {
                                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                                UnDisplaying( this, me );
                            }

                            this.DialogResult = DialogResult.Cancel;
                            this._indexBuf = -2;

                            if ( CanClose == true )
                            {
                                this.Close();
                            }
                            else
                            {
                                this.Hide();
                            }

                            return;
                        }
                }
            }
            else
            {
                this.Delete_Button.Focus();
                return;
            }

            if ( UnDisplaying != null )
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                UnDisplaying( this, me );
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
		}

		/// <summary>
		/// Control.Click イベント(Revive_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note 　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2008.04.30</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 選択レコードに対応するデータを取得
            Supplier supplier = GetFromCache( _supplierDataTable.Rows[this._dataIndex] );
            if ( supplier == null ) return;

            // 復旧
            status = this._supplierAcs.Revival( ref supplier );

            // 結果分岐
            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction( status, TMsgDisp.OPE_UPDATE, this._supplierAcs );

                        if ( UnDisplaying != null )
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                            UnDisplaying( this, me );
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if ( CanClose == true )
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Revive_Button_Click",				  // 処理名称
                            TMsgDisp.OPE_UPDATE,				  // オペレーション
                            ERR_RVV_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._supplierAcs,					  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1 );	  // 初期表示ボタン

                        if ( UnDisplaying != null )
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                            UnDisplaying( this, me );
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if ( CanClose == true )
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }

                        return;
                    }
            }

            // DataSet展開処理
            CopyToDataSet( supplier, this.DataIndex );

            if ( UnDisplaying != null )
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
                UnDisplaying( this, me );
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
		}

		/// <summary>
		/// Timer.Tick イベント イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
		///					  スレッドで実行されます。</br>
        /// <br>Programmer  : 22018 鈴木正臣</br>
        /// <br>Date        : 2008.04.30</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

		/// <summary>
		/// TRetKeyControl.ChangeFocus イベント イベント(tRetKeyControl1)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォーカスが遷移する際に発生します。</br>
        /// <br>Programmer  : 22018 鈴木正臣</br>
        /// <br>Date        : 2008.04.30</br>
        /// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            if ( e == null || e.PrevCtrl == null ) return;

            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            
            # region [OnChangeFocus]
            switch ( e.PrevCtrl.Name )
            {
                // 仕入先コード
                case "tNedit_SupplierCd":
                    {
                        bool status = true;
                        int supplierCode = tNedit_SupplierCd.GetInt();

                        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                        //if ( supplierCode != _noDispData.PrevSupplierCd )
                        //{
                        //    int code;
                        //    string name1;
                        //    string name2;
                        //    string snm;

                        //    if ( supplierCode == 0 )
                        //    {
                        //    }
                        //    else if ( ReadSupplier( supplierCode, out code, out name1, out name2, out snm ) )
                        //    {
                        //        TMsgDisp.Show(
                        //            this,
                        //            emErrorLevel.ERR_LEVEL_INFO,
                        //            this.Name,
                        //            "入力されたコードの仕入先情報が既に登録されています。",
                        //            -1,
                        //            MessageBoxButtons.OK );
                        //        e.NextCtrl = e.PrevCtrl;
                        //        tNedit_SupplierCd.SetInt( 0 );
                        //        _noDispData.PrevSupplierCd = 0;
                                
                        //        status = false;
                        //    }
                        //    else
                        //    {
                        //        // 支払先コード格納
                        //        if ( tNedit_PayeeCode.GetInt() == 0 || tNedit_PayeeCode.GetInt() == supplierCode )
                        //        {
                        //            tNedit_PayeeCode.SetInt( supplierCode );
                        //            _noDispData.PrevSupplierCd = supplierCode;
                        //        }

                        //        // 提供仕入先読み込み
                        //        OfrSupplier ofrSupplier;
                        //        if ( _ofrSupplierAcs.Read( out ofrSupplier, supplierCode ) == 0 )
                        //        {
                        //            // 内容セット
                        //            tNedit_SupplierCd.SetInt( ofrSupplier.SupplierCd );
                        //            tEdit_SupplierName1.Text = ofrSupplier.SupplierNm1;
                        //            tEdit_SupplierSnm.Text = ofrSupplier.SupplierSnm;
                        //            tEdit_SupplierKana.Text = ofrSupplier.SupplierKana;

                        //            // 支払先にもコピー
                        //            # region [支払先]
                        //            tNedit_PayeeCode.SetInt( ofrSupplier.SupplierCd );
                        //            uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                        //            uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                        //            uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                        //            _noDispData.PrevPayeeCode = ofrSupplier.SupplierCd;

                        //            SettingScreenEnableForChild( false );

                        //            // 全体設定は支払拠点依存
                        //            // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                        //            //SettingEnableByStckTtlAmntDspWayRef((int)tComboEditor_StckTtlAmntDspWayRef.Value);
                        //            //SettingEnableBySuppTtlAmountDispWayCd((int)tComboEditor_SuppTtlAmountDispWayCd.Value);
                        //            SettingEnableBySuppTtlAmountDispWayCd(0);
                        //            // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                        //            SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                        //            # endregion
                        //        }
                        //    }
                        //}
                        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                        
                        if ( status )
                        {
                            if ( !e.ShiftKey )
                            {
                                switch ( e.Key )
                                {
                                    case Keys.Tab:
                                    case Keys.Return:
                                        {
                                            if ( supplierCode == 0 )
                                            {
                                                e.NextCtrl = uButton_OfrSupplierGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_SupplierName1;
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }

                        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = tNedit_SupplierCd;
                            }
                            else
                            {
                                // 提供仕入先読み込み
                                OfrSupplier ofrSupplier;
                                if (_ofrSupplierAcs.Read(out ofrSupplier, supplierCode) == 0)
                                {
                                    // 内容セット
                                    tNedit_SupplierCd.SetInt(ofrSupplier.SupplierCd);
                                    tEdit_SupplierName1.Text = ofrSupplier.SupplierNm1;
                                    tEdit_SupplierSnm.Text = ofrSupplier.SupplierSnm;
                                    tEdit_SupplierKana.Text = ofrSupplier.SupplierKana;

                                    // 支払先にもコピー
                                    # region [支払先]
                                    tNedit_PayeeCode.SetInt(ofrSupplier.SupplierCd);
                                    uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                                    uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                                    uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                                    _noDispData.PrevPayeeCode = ofrSupplier.SupplierCd;

                                    SettingScreenEnableForChild(false);

                                    // 全体設定は支払拠点依存
                                    SettingEnableBySuppTtlAmountDispWayCd(0);
                                    SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                                    # endregion
                                }
                            }
                        }
                        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
                    }
                    break;
                // 仕入先名称１
                case "tEdit_SupplierName1":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        if ( tNedit_SupplierCd.Enabled )
                                        {
                                            e.NextCtrl = tNedit_SupplierCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                            }
                        }

                        //tNedit_SupplierCd
                    }
                    break;
                // 敬称
                case "tComboEditor_SuppHonorificTitle":
                    {
                        //string inputText = tComboEditor_SuppHonorificTitle.Text;
                        //// コンボエディタアイテム選択
                        //if ( SelectComboEdit( tComboEditor_SuppHonorificTitle, inputText ) )
                        //{
                        //}
                        //else
                        //{
                        //    // 該当なければ直接入力とみなす
                        //    tComboEditor_SuppHonorificTitle.SelectedIndex = -1;
                        //    tComboEditor_SuppHonorificTitle.Text = inputText;
                        //}
                    }
                    break;
                // 発注書敬称
                case "tComboEditor_OrderHonorificTtl":
                    {
                        //string inputText = tComboEditor_OrderHonorificTtl.Text;
                        //// コンボエディタアイテム選択
                        //if ( SelectComboEdit( tComboEditor_OrderHonorificTtl, inputText ) )
                        //{
                        //}
                        //else
                        //{
                        //    // 該当なければ直接入力とみなす
                        //    tComboEditor_OrderHonorificTtl.SelectedIndex = -1;
                        //    tComboEditor_OrderHonorificTtl.Text = inputText;
                        //}
                    }
                    break;
                // 管理拠点コード
                case "tEdit_MngSectionNm":
                    {
                        bool status;

                        if ( tEdit_MngSectionNm.Text == _noDispData.PrevMngSectionName )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            string msgSectionCode = this.GetInputCode( tEdit_MngSectionNm );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // 拠点読み込み
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                            //status = ReadSection( tEdit_MngSectionNm.Text, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            status = ReadSection( msgSectionCode, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // コード・名称を更新
                            _noDispData.MngSectionCode = code;
                            _noDispData.PrevMngSectionName = name;
                            tEdit_MngSectionNm.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl制御
                                switch ( e.Key )
                                {
                                    case Keys.Up:
                                        {
                                            e.NextCtrl = tEdit_SuppHonorificTitle;
                                            break;
                                        }
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _noDispData.MngSectionCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_MngSectionNmGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tEdit_StockAgentNm;
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
                    break;
                // 管理拠点ボタン
                case "uButton_MngSectionNmGuide":
                    {
                        // NextCtrl制御
                        switch ( e.Key )
                        {
                            case Keys.Up:
                                {
                                    e.NextCtrl = tEdit_SuppHonorificTitle;
                                    break;
                                }
                        }
                    }
                    break;
                // 仕入担当者コード
                case "tEdit_StockAgentNm":
                    {
                        bool status;

                        if ( tEdit_StockAgentNm.Text == _noDispData.PrevStockAgentName )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            // 入力コード取得
                            string stockAgentCode = GetInputCode( tEdit_StockAgentNm );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // 従業員読み込み
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                            //status = ReadEmployee( tEdit_StockAgentNm.Text, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            status = ReadEmployee( stockAgentCode, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // コード・名称を更新
                            _noDispData.StockAgentCode = code;
                            _noDispData.PrevStockAgentName = name;
                            tEdit_StockAgentNm.Text = name;
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl制御
                                switch ( e.Key )
                                {
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _noDispData.StockAgentCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_StockAgentGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tComboEditor_PureCode;
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
                    break;
                // 仕入担当者ガイドボタン
                case "uButton_StockAgentGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tComboEditor_PureCode;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 純正区分
                case "tComboEditor_PureCode":
                    {
                        // コンボ選択
                        SelectComboEdit( tComboEditor_PureCode, tComboEditor_PureCode.Text );
                    }
                    break;
                // 仕入先属性
                case "tComboEditor_SupplierAttributeDiv":
                    {
                        // コンボ選択
                        SelectComboEdit( tComboEditor_SupplierAttributeDiv, tComboEditor_SupplierAttributeDiv.Text );
                    }
                    break;
                // 業種
                case "tComboEditor_BusinessTypeCode":
                    {
                        // コンボ選択
                        SelectComboEdit( tComboEditor_BusinessTypeCode, tComboEditor_BusinessTypeCode.Text );
                    }
                    break;
                // 販売エリア
                case "tComboEditor_SalesAreaCode":
                    {
                        // コンボ選択
                        SelectComboEdit( tComboEditor_SalesAreaCode, tComboEditor_SalesAreaCode.Text );
                    }
                    break;
                // 支払拠点コード
                case "tEdit_PaymentSectionCode":
                    {
                        bool status;

                        if ( tEdit_PaymentSectionCode.Text == _noDispData.PrevPaymentSectionName )
                        {
                            status = true;
                        }
                        else
                        {
                            string code;
                            string name;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            // 入力コード取得
                            string paymentSectionCode = GetInputCode( tEdit_PaymentSectionCode );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // 拠点読み込み
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
                            //status = ReadSection( tEdit_PaymentSectionCode.Text, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
                            status = ReadSection( paymentSectionCode, out code, out name );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

                            // コード・名称を更新
                            _noDispData.PaymentSectionCode = code;
                            _noDispData.PrevPaymentSectionName = name;
                            tEdit_PaymentSectionCode.Text = name;

                            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                            // 全体設定は支払拠点依存
                            SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
                               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl制御
                                switch ( e.Key )
                                {
                                    case Keys.Down:
                                        {
                                            e.NextCtrl = tNedit_PayeeCode;
                                            break;
                                        }
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _noDispData.PaymentSectionCode == string.Empty )
                                            {
                                                e.NextCtrl = this.uButton_PaymentSectionGuide;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.tNedit_PayeeCode;
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
                    break;
                // 支払拠点ガイドボタン
                case "uButton_PaymentSectionGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tNedit_PayeeCode;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 支払先コード
                case "tNedit_PayeeCode":
                    {
                        bool status;

                        int payeeCode = tNedit_PayeeCode.GetInt();
                        if ( payeeCode == _noDispData.PrevPayeeCode )
                        {
                            status = true;
                        }
                        else
                        {
                            // 仕入先＝支払先の場合
                            if ( payeeCode == tNedit_SupplierCd.GetInt() )
                            {
                                tNedit_PayeeCode.SetInt( payeeCode );
                                uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                                uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                                uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                                _noDispData.PrevPayeeCode = payeeCode;

                                status = true;

                                SettingScreenEnableForChild( false );

                                // 全体設定は支払拠点依存
                                // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                                //SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
                                //SettingEnableBySuppTtlAmountDispWayCd((int)tComboEditor_SuppTtlAmountDispWayCd.Value);
                                SettingEnableBySuppTtlAmountDispWayCd(0);
                                // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                                SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                            }
                            else
                            {
                                // 支払先読み込み
                                Supplier payee;
                                bool bStatus = ReadSupplier( payeeCode, out payee );
                                if (bStatus)
                                {
                                    _noDispData.PrevPayeeCode = payee.SupplierCd;

                                    // 画面に表示
                                    status = SettingPayeeToScreen(payee);
                                }
                                // --- ADD 2009/01/20 障害ID:9164対応------------------------------------------------------>>>>>
                                else
                                {
                                    payeeCode = this.tNedit_SupplierCd.GetInt();
                                    tNedit_PayeeCode.SetInt(payeeCode);
                                    uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                                    uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                                    uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                                    _noDispData.PrevPayeeCode = payeeCode;

                                    status = true;

                                    SettingScreenEnableForChild(false);

                                    // 全体設定は支払拠点依存
                                    SettingEnableBySuppTtlAmountDispWayCd(0);
                                    SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                                }
                                // --- ADD 2009/01/20 障害ID:9164対応------------------------------------------------------<<<<<
                            }
                        }

                        if ( status == true )
                        {
                            if ( !e.ShiftKey )
                            {
                                // NextCtrl制御
                                switch ( e.Key )
                                {
                                    case Keys.Down:
                                        {
                                            if ( tNedit_PaymentTotalDay.Enabled == false )
                                            {
                                                e.NextCtrl = tEdit_SupplierTelNo;
                                            }
                                            break;
                                        }
                                    case Keys.Return:
                                    case Keys.Tab:
                                        {
                                            if ( _noDispData.PrevPayeeCode == 0 )
                                            {
                                                e.NextCtrl = this.uButton_PayeeNameGuide;
                                            }
                                            else
                                            {
                                                if ( tNedit_PaymentTotalDay.Enabled )
                                                {
                                                    e.NextCtrl = this.tNedit_PaymentTotalDay;
                                                }
                                                else
                                                {
                                                    if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                                    {
                                                        e.NextCtrl = tEdit_SupplierPostNo;
                                                    }
                                                    else
                                                    {
                                                        e.NextCtrl = tEdit_SupplierNote1;
                                                    }
                                                }
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
                    break;
                // 支払先ガイドボタン
                case "uButton_PayeeNameGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Right:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if ( tNedit_PaymentTotalDay.Enabled )
                                        {
                                            e.NextCtrl = tNedit_PaymentTotalDay;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_SupplierTelNo;
                                        }
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( tNedit_PaymentTotalDay.Enabled )
                                        {
                                            e.NextCtrl = tNedit_PaymentTotalDay;
                                        }
                                        else
                                        {
                                            if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                            {
                                                e.NextCtrl = tEdit_SupplierPostNo;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_SupplierNote1;
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 締日
                case "tNedit_PaymentTotalDay":
                    {
                        int date = tNedit_PaymentTotalDay.GetInt();
                        if ( date < 1 ) tNedit_PaymentTotalDay.SetInt( 1 );
                        if ( date >= 28 ) tNedit_PaymentTotalDay.SetInt( 31 );
                    }
                    break;
                // 支払月区分
                case "tComboEditor_PaymentMonthCode":
                    {
                        // コンボ選択
                        SelectComboEdit( tComboEditor_PaymentMonthCode, tComboEditor_PaymentMonthCode.Text );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tNedit_PayeeCode;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 支払日
                case "tNedit_PaymentDay":
                    {
                        int date = tNedit_PaymentDay.GetInt();
                        if ( date < 1 ) tNedit_PaymentDay.SetInt( 1 );
                        if ( date >= 28 ) tNedit_PaymentDay.SetInt( 31 );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tNedit_PayeeCode;
                                    }
                                    break;
                                case Keys.Right:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tNedit_PaymentSight;
                                    }
                                    break;
                            }
                        }
                        
                    }
                    break;
                // --- ADD 2008/12/12 --------------------------------------------------------------------->>>>>
                // 支払条件
                case "tComboEditor_PaymentCond":
                    {
                        if (!e.ShiftKey)
                        {
                            switch (e.Key)
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tNedit_PaymentTotalDay;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // --- ADD 2008/12/12 ---------------------------------------------------------------------<<<<<
                // 支払サイト
                case "tNedit_PaymentSight":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tNedit_NTimeCalcStDate;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 次回勘定開始日
                case "tNedit_NTimeCalcStDate":
                    {
                        int date = tNedit_NTimeCalcStDate.GetInt();
                        //if ( date < 1 ) tNedit_NTimeCalcStDate.SetInt( 1 );
                        // --- CHG 2009/01/29 障害ID:10723対応------------------------------------------------------>>>>>
                        //if ( date >= 28 ) tNedit_NTimeCalcStDate.SetInt( 31 );
                        if (date > 31)
                        {
                            DialogResult res = TMsgDisp.Show(this,								
                                                             emErrorLevel.ERR_LEVEL_EXCLAMATION,	
                                                             ASSEMBLY_ID,						
                                                             "次回勘定は 1～31 の範囲で入力してください。",									
                                                             0,									
                                                             MessageBoxButtons.OK);
                            e.NextCtrl = tNedit_NTimeCalcStDate;
                        }
                        // --- CHG 2009/01/29 障害ID:10723対応------------------------------------------------------<<<<<
                    }
                    break;
                /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                // 総額表示参照
                case "tComboEditor_StckTtlAmntDspWayRef":
                    {
                        // コンボ選択
                        SelectComboEdit( tComboEditor_StckTtlAmntDspWayRef, tComboEditor_StckTtlAmntDspWayRef.Text );
                        SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Right:
                                    {
                                        if ( tComboEditor_SuppTtlAmountDispWayCd.Enabled == false )
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if ( tComboEditor_SuppCTaXLayRefCd.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppCTaXLayRefCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                        }
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( tComboEditor_SuppTtlAmountDispWayCd.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppTtlAmountDispWayCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tComboEditor_SuppCTaXLayRefCd;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 総額表示方法
                case "tComboEditor_SuppTtlAmountDispWayCd":
                    {
                        // コンボ選択
                        SelectComboEdit( tComboEditor_SuppTtlAmountDispWayCd, tComboEditor_SuppTtlAmountDispWayCd.Text );
                        SettingEnableBySuppTtlAmountDispWayCd( (int)tComboEditor_SuppTtlAmountDispWayCd.Value );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tNedit_NTimeCalcStDate;
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        if ( tComboEditor_SuppTaxLayMethod.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppTaxLayMethod;
                                        }
                                        else if (tComboEditor_SuppCTaXLayRefCd.Enabled)
                                        {
                                            e.NextCtrl = tComboEditor_SuppCTaXLayRefCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                        }
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( tComboEditor_SuppCTaXLayRefCd.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppCTaXLayRefCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                   --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                // 転嫁方式参照
                case "tComboEditor_SuppCTaXLayRefCd":
                    {
                        // コンボ選択
                        SelectComboEdit( tComboEditor_SuppCTaXLayRefCd, tComboEditor_SuppCTaXLayRefCd.Text );
                        SettingEnableBySuppCTaXLayRefCd( (int)tComboEditor_SuppCTaXLayRefCd.Value );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Right:
                                    {
                                        if ( tComboEditor_SuppTaxLayMethod.Enabled == false )
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if (tComboEditor_SuppTaxLayMethod.Enabled)
                                        {
                                            e.NextCtrl = tComboEditor_SuppTaxLayMethod;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 転嫁方式
                case "tComboEditor_SuppTaxLayMethod":
                    {
                        // コンボ選択
                        SelectComboEdit( tComboEditor_SuppTaxLayMethod, tComboEditor_SuppTaxLayMethod.Text );

                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                        if ( tComboEditor_SuppTtlAmountDispWayCd.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppTtlAmountDispWayCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tComboEditor_StckTtlAmntDspWayRef;
                                        }
                                           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                    }
                                    break;
                                case Keys.Down:
                                    {
                                        e.NextCtrl = tNedit_StockUnPrcFrcProcCd;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 仕入単価端数処理
                case "tNedit_StockUnPrcFrcProcCd":
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
                        //if ( ExistsStockProcMoney( 1, tNedit_StockUnPrcFrcProcCd.GetInt() ) )
                        //{
                        //}
                        //else
                        //{
                        //    tNedit_StockUnPrcFrcProcCd.SetInt( 0 );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                        if ( tNedit_StockUnPrcFrcProcCd.GetInt() == 0 )
                        {
                            tNedit_StockUnPrcFrcProcCd.DataText = string.Format( "{0}", 0 );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // フォーカス
                                        if ( tNedit_StockUnPrcFrcProcCd.Text != string.Empty )
                                        {
                                            e.NextCtrl = tNedit_StockMoneyFrcProcCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = uButton_SalesUnPrcFrcProcCdGuide;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 仕入単価端数処理ガイドボタン
                case "uButton_SalesUnPrcFrcProcCdGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        if ( tComboEditor_SuppCTaXLayRefCd.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_SuppCTaXLayRefCd;
                                        }
                                        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                                        else if ( tComboEditor_StckTtlAmntDspWayRef.Enabled )
                                        {
                                            e.NextCtrl = tComboEditor_StckTtlAmntDspWayRef;
                                        }
                                           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                                        else
                                        {
                                            e.NextCtrl = tNedit_PayeeCode;
                                        }
                                    }
                                    break;
                                case Keys.Right:
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 仕入金額端数処理
                case "tNedit_StockMoneyFrcProcCd":
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
                        //if ( ExistsStockProcMoney( 0, tNedit_StockMoneyFrcProcCd.GetInt() ) )
                        //{
                        //}
                        //else
                        //{
                        //    tNedit_StockMoneyFrcProcCd.SetInt( 0 );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                        if ( tNedit_StockMoneyFrcProcCd.GetInt() == 0 )
                        {
                            tNedit_StockMoneyFrcProcCd.DataText = string.Format( "{0}", 0 );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // フォーカス
                                        if ( tNedit_StockMoneyFrcProcCd.Text != string.Empty )
                                        {
                                            e.NextCtrl = tNedit_StockCnsTaxFrcProcCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = uButton_SalesMoneyFrcProcCdGuide;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 仕入消費税端数処理
                case "tNedit_StockCnsTaxFrcProcCd":
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
                        //if ( ExistsStockProcMoney( 0, tNedit_StockCnsTaxFrcProcCd.GetInt() ) )
                        //{
                        //}
                        //else
                        //{
                        //    tNedit_StockCnsTaxFrcProcCd.SetInt( 0 );
                        //}
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                        if ( tNedit_StockCnsTaxFrcProcCd.GetInt() == 0 )
                        {
                            tNedit_StockCnsTaxFrcProcCd.DataText = string.Format( "{0}", 0 );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                        {
                                            e.NextCtrl = tEdit_SupplierTelNo;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_SupplierNote1;
                                        }
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        // フォーカス
                                        if ( tNedit_StockCnsTaxFrcProcCd.Text != string.Empty )
                                        {
                                            if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                            {
                                                e.NextCtrl = tEdit_SupplierPostNo;
                                            }
                                            else
                                            {
                                                e.NextCtrl = tEdit_SupplierNote1;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = uButton_SalesCnsTaxFrcProcCdGuide;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 仕入消費税端数処理ガイドボタン
                case "uButton_SalesCnsTaxFrcProcCdGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Down:
                                    {
                                        if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                        {
                                            e.NextCtrl = tEdit_SupplierTelNo;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_SupplierNote1;
                                        }
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                                        {
                                            e.NextCtrl = tEdit_SupplierPostNo;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tEdit_SupplierNote1;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 郵便番号
                case "tEdit_SupplierPostNo":
                    {
                        if ( tEdit_SupplierPostNo.Text != _noDispData.PrevPostNo )
                        {
                            ReadAddress( tEdit_SupplierPostNo.Text );
                        }
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tComboEditor_SalesAreaCode;
                                    }
                                    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        if ( tEdit_SupplierPostNo.Text != string.Empty )
                                        {
                                            // フォーカス
                                            e.NextCtrl = tEdit_SupplierAddr1;
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                    {
                                        if ( uButton_SalesCnsTaxFrcProcCdGuide.Enabled )
                                        {
                                            e.NextCtrl = uButton_SalesCnsTaxFrcProcCdGuide;
                                        }
                                        else
                                        {
                                            e.NextCtrl = uButton_PayeeNameGuide;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 郵便番号ガイド
                case "uButton_AddressGuide":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tComboEditor_SalesAreaCode;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 住所１
                case "tEdit_SupplierAddr1":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tEdit_SupplierPostNo;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 電話番号１
                case "tEdit_SupplierTelNo":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        if ( tNedit_StockCnsTaxFrcProcCd.Enabled )
                                        {
                                            e.NextCtrl = tNedit_StockCnsTaxFrcProcCd;
                                        }
                                        else
                                        {
                                            e.NextCtrl = tNedit_PayeeCode;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // ＦＡＸ番号
                case "tEdit_SupplierTelNo2":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                //case Keys.Down:
                                //    {
                                //        e.NextCtrl = Ok_Button;
                                //    }
                                //    break;
                                case Keys.Tab:
                                case Keys.Return:
                                    {
                                        SubInfo_UTabControl.SelectedTab = SubInfo_UTabControl.Tabs[1];
                                        e.NextCtrl = tEdit_SupplierNote1;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 備考１
                case "tEdit_SupplierNote1":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                case Keys.Up:
                                    {
                                        e.NextCtrl = tComboEditor_SalesAreaCode;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch ( e.Key )
                            {
                                case Keys.Tab:
                                    {
                                        SubInfo_UTabControl.SelectedTab = SubInfo_UTabControl.Tabs[0];
                                        e.NextCtrl = tEdit_SupplierTelNo2;
                                    }
                                    break;
                            }
                        }
                    }
                    break;
                // 備考４
                case "tEdit_SupplierNote4":
                    {
                        if ( !e.ShiftKey )
                        {
                            switch ( e.Key )
                            {
                                //case Keys.Down:
                                //    {
                                //        e.NextCtrl = Ok_Button;
                                //    }
                                //    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                // その他
                default:
                    {
                    }
                    break;
            }
            # endregion
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
        /// <summary>
        /// 文字列項目のコード変換処理(ｾﾞﾛ詰め対応)
        /// </summary>
        /// <param name="targetEdit"></param>
        /// <returns></returns>
        private string GetInputCode( TEdit targetEdit )
        {
            UiSet uiset;
            if ( uiSetControl1.ReadUISet( out uiset, targetEdit.Name ) == 0 )
            {
                // 設定に基づきゼロ詰め
                // （本来この処理を不要にする為のコンポーネントだが、入力方式が特殊なので手動対応する）

                return targetEdit.Text.TrimEnd().PadLeft( uiset.Column, '0' );
            }
            else
            {
                // 設定を取得できなかった場合はそのまま返す。
                return targetEdit.Text.TrimEnd();
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD

        /// <summary>
        /// 名称Value変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_Name_ValueChanged( object sender, System.EventArgs e )
        {
            if ( !(sender is TEdit) )
            {
                return;
            }

            if ( ((TEdit)sender).Modified == false )
            {
                return;
            }

            if ( ((TEdit)sender) == this.tEdit_SupplierName1 )
            {
                if ( ((TEdit)sender).Text == "" )
                {
                    this.tEdit_SupplierKana.Clear();
                }
            }

            if ( (TEdit)sender != tEdit_SupplierSnm )
            {
                // 略称の入力補助対応
                if ( _noDispData.PrevSupplierName.Length < this.tEdit_SupplierName1.DataText.Length )
                {
                    if ( this.tEdit_SupplierName1.DataText.StartsWith( _noDispData.PrevSupplierName ) )
                    {
                        this.tEdit_SupplierSnm.DataText += this.tEdit_SupplierName1.DataText.Substring( _noDispData.PrevSupplierName.Length );
                    }
                }
                _noDispData.PrevSupplierName = this.tEdit_SupplierName1.DataText;
                if ( this.tEdit_SupplierName1.Text == string.Empty )
                {
                    this.tEdit_SupplierSnm.DataText = string.Empty;
                }
                // 略称補正
                this.tEdit_SupplierSnm.DataText = this.tEdit_SupplierSnm.DataText.Substring( 0, Math.Min( tEdit_SupplierSnm.ExtEdit.Column, tEdit_SupplierSnm.Text.Length ) );
            }

            // 支払先＝仕入先ならば、支払先名称欄をリアルで更新する
            if ( this.tNedit_SupplierCd.GetInt() == this.tNedit_PayeeCode.GetInt())
            {
                this.uLabel_PayeeName1.Text = this.tEdit_SupplierName1.DataText;
                this.uLabel_PayeeName2.Text = this.tEdit_SupplierName2.DataText;
                this.uLabel_PayeeSnm.Text = this.tEdit_SupplierSnm.DataText;
            }
        }

        # region [ユーザーガイド関連]
        /// <summary>
        /// ユーザーガイドマスタボディ部リスト取得処理
        /// </summary>
        /// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
        private int GetUserGdBdListToStatic()
        {
            if ( _userGdBdListStc != null )
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            
            _userGdBdListStc = new List<UserGdBd>();

            ArrayList userGdBdList = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                // ユーザーガイド（ヘッダ）情報全検索処理（論理削除除く）
                if ( _userGuideAcs == null )
                {
                    _userGuideAcs = new UserGuideAcs();
                }
                status = this._userGuideAcs.SearchBody( out userGdBdList, this._enterpriseCode, UserGuideAcsData.MergeBodyData );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    _userGdBdListStc.AddRange( (UserGdBd[])userGdBdList.ToArray( typeof( UserGdBd ) ) );
                }
            }
            catch ( Exception e )
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.ToString(),
                    "ユーザーガイド（ヘッダ）情報の取得に失敗しました。" + "\r\n" + e.Message,
                    -1,
                    MessageBoxButtons.OK );

                status = -1;
            }


            return status;
        }

        /// <summary>
        /// ユーザーガイドマスタリスト取得処理
        /// </summary>
        /// <param name="guideDivCode">ユーザーガイド区分</param>
        /// <param name="retList">戻り値リスト</param>
        /// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
        private int GetDivCodeBodyList( int guideDivCode, out ArrayList retList )
        {
            if ( _userGdBdListStc == null )
            {
                // ユーザーガイドマスタボディ部リスト取得処理
                this.GetUserGdBdListToStatic();
            }

            retList = new ArrayList();

            foreach ( UserGdBd ugb in _userGdBdListStc )
            {
                if (( ugb.UserGuideDivCd == guideDivCode ) && (ugb.LogicalDeleteCode == 0))
                {
                    ComboEditorItemSupplier comboEditorItem = new ComboEditorItemSupplier( ugb.GuideCode, ugb.GuideName );
                    retList.Add( comboEditorItem );
                }
            }

            if ( retList.Count > 0 )
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        # region [コンボエディタアイテムクラス]
        private class ComboEditorItemSupplier : IComparable
        {
            # region [private フィールド]
            /// <summary>コード</summary>
            private int _code = 0;
            /// <summary>名称</summary>
            private string _name = "";
            # endregion

            # region [public プロパティ]
            /// <summary>
            /// コード　プロパティ
            /// </summary>
            public int Code
            {
                get { return this._code; }
                set { this._code = value; }
            }
            /// <summary>
            /// 名称　プロパティ
            /// </summary>
            public string Name
            {
                get { return this._name; }
                set { this._name = value; }
            }
            # endregion

            # region [コンストラクタ]
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ComboEditorItemSupplier()
            {
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="code"></param>
            /// <param name="name"></param>
            public ComboEditorItemSupplier( int code, string name )
            {
                this._code = code;
                this._name = name;
            }
            # endregion

            # region [Comparable]
            /// <summary>
            /// 比較処理
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public int CompareTo( object obj )
            {
                if ( obj == null ) return 1;

                ComboEditorItemSupplier comboEditorItemCustomer = obj as ComboEditorItemSupplier;
                if ( comboEditorItemCustomer == null ) return 1;

                return this.Code.CompareTo( comboEditorItemCustomer.Code );
            }
            # endregion
        }
        # endregion

        # endregion

        # region [ChangeFocus時読み込み処理]
        /// <summary>
        /// コンボエディット選択処理
        /// </summary>
        /// <param name="tComboEditor"></param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        private bool SelectComboEdit( TComboEditor tComboEditor, string inputText )
        {
            // 表示Textで探す
            for ( int index = 0; index < tComboEditor.Items.Count; index++ )
            {
                if ( tComboEditor.Items[index].DisplayText.Trim() == inputText.Trim() )
                {
                    // 選択する
                    tComboEditor.SelectedIndex = index;
                    return true;
                }
            }

            // 無ければアイテム番号とみなして探す
            int inputIndex = ToInt( inputText );
            if ( 0 < inputIndex && inputIndex <= tComboEditor.Items.Count )
            {
                tComboEditor.SelectedIndex = inputIndex - 1;
                return true;
            }

            // それでもなければ最初のアイテムをデフォルト表示する(但し結果=falseにする)
            if ( tComboEditor.Items.Count > 0 )
            {
                tComboEditor.SelectedIndex = 0;
            }
            else
            {
                // アイテムが１つもなければ空白に戻す
                tComboEditor.Text = string.Empty;
            }

            return false;
        }
        /// <summary>
        /// 数値変換処理
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int ToInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 管理拠点読み込み
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="code">(出力)コード</param>
        /// <param name="name">(出力)名称</param>
        /// <returns>入力後フォーカス移動許可</returns>
        private bool ReadSection( string sectionCode, out string code, out string name )
        {
            bool result = false;

            // 未入力判定
            if ( sectionCode != string.Empty )
            {
                // 読み込み
                if ( _secInfoSetAcs == null )
                {
                    _secInfoSetAcs = new SecInfoSetAcs();
                }
                SecInfoSet secInfoSet;
                int status = _secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, sectionCode );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //if ( status == 0 && secInfoSet != null )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                if ( status == 0 && secInfoSet != null && secInfoSet.LogicalDeleteCode == 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                {
                    // 該当あり→表示
                    code = secInfoSet.SectionCode;
                    name = secInfoSet.SectionGuideNm;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = string.Empty;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }

        /// <summary>
        /// 仕入担当者読み込み
        /// </summary>
        /// <param name="employeeCode">担当者コード</param>
        /// <param name="code">(出力)コード</param>
        /// <param name="name">(出力)名称</param>
        /// <returns></returns>
        private bool ReadEmployee( string employeeCode, out string code, out string name )
        {
            bool result = false;

            // 未入力判定
            if ( employeeCode != string.Empty )
            {
                // 読み込み
                if ( _employeeAcs == null )
                {
                    _employeeAcs = new EmployeeAcs();
                }
                Employee employee;
                int status = _employeeAcs.Read( out employee, this._enterpriseCode, employeeCode );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //if ( status == 0 && employee != null )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                if ( status == 0 && employee != null && employee.LogicalDeleteCode == 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                {
                    // 該当あり→表示
                    code = employee.EmployeeCode;
                    name = employee.Name;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = string.Empty;
                    name = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = string.Empty;
                name = string.Empty;

                result = true;
            }

            return result;
        }
        /// <summary>
        /// 仕入先読み込み
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="code">(出力)コード</param>
        /// <param name="name1">(出力)名称1</param>
        /// <param name="name2">(出力)名称2</param>
        /// <param name="snm">(出力)略称</param>
        /// <returns>入力後フォーカス移動許可</returns>
        private bool ReadSupplier( int supplierCode, out int code, out string name1, out string name2, out string snm )
        {
            bool result = false;

            // 未入力判定
            if ( supplierCode != 0 )
            {
                // 読み込み
                Supplier supplier;
                int status = _supplierAcs.Read( out supplier, this._enterpriseCode, supplierCode );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //if ( status == 0 && supplier != null )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                // 2008.11.21 modify start [8199]
                // 論理削除区分で使用しているのは0=有効, 1=論理削除のみ(2,9は勘案の必要なし)
                //if (status == 0 && supplier != null && supplier.LogicalDeleteCode == 0 )
                if ( status == 0 && supplier != null && (supplier.LogicalDeleteCode == 0 || supplier.LogicalDeleteCode == 1))
                // 2008.11.21 modify end [8199]
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                {
                    // 該当あり→表示
                    code = supplier.SupplierCd;
                    name1 = supplier.SupplierNm1;
                    name2 = supplier.SupplierNm2;
                    snm = supplier.SupplierSnm;

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    code = 0;
                    name1 = string.Empty;
                    name2 = string.Empty;
                    snm = string.Empty;

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                code = 0;
                name1 = string.Empty;
                name2 = string.Empty;
                snm = string.Empty;

                result = true;
            }

            return result;
        }
        /// <summary>
        /// 仕入先読み込み
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="supplier">仕入先</param>
        /// <returns>入力後フォーカス移動許可</returns>
        private bool ReadSupplier( int supplierCode, out Supplier supplier )
        {
            bool result = false;

            // 未入力判定
            if ( supplierCode != 0 )
            {
                // 読み込み
                int status = _supplierAcs.Read( out supplier, this._enterpriseCode, supplierCode );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 DEL
                //if ( status == 0 && supplier != null )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
                if ( status == 0 && supplier != null && supplier.LogicalDeleteCode == 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
                {
                    // 該当あり→表示

                    result = true;
                }
                else
                {
                    // 該当なし→クリア
                    supplier = new Supplier();

                    // ＮＧにする
                    result = false;
                }
            }
            else
            {
                // 未入力→クリア
                supplier = new Supplier();

                result = true;
            }

            return result;
        }

        /// <summary>
        /// 仕入金額端数処理存在チェック
        /// </summary>
        /// <param name="fracProcMoneyDiv"></param>
        /// <param name="fractionProcCode"></param>
        /// <returns></returns>
        private bool ExistsStockProcMoney( int fracProcMoneyDiv, int fractionProcCode )
        {
            if ( _stockProcMoneyCdList == null )
            {
                _stockProcMoneyCdList = new List<StockProcMoneyKey>();

                ArrayList stockProcMoneyList;
                if ( _stockProcMoneyAcs == null )
                {
                    _stockProcMoneyAcs = new StockProcMoneyAcs();
                }
                this._stockProcMoneyAcs.Search( out stockProcMoneyList, this._enterpriseCode );
                foreach ( object obj in stockProcMoneyList )
                {
                    if ( obj is StockProcMoney )
                    {
                        StockProcMoney stockProcMoney = (obj as StockProcMoney);
                        _stockProcMoneyCdList.Add( new StockProcMoneyKey( stockProcMoney.FracProcMoneyDiv, stockProcMoney.FractionProcCode ) );
                    }
                }
            }

            return _stockProcMoneyCdList.Contains( new StockProcMoneyKey( fracProcMoneyDiv, fractionProcCode ) );
        }
        /// <summary>
        /// 住所検索
        /// </summary>
        /// <param name="postNo"></param>
        private void ReadAddress( string postNo )
        {
            AddressGuideResult agResult;
            int status = GetAddressFromPostNo( postNo, out agResult );
            if ( status == 0 )
            {
                // 郵便番号
                tEdit_SupplierPostNo.Text = agResult.PostNo.TrimEnd();
                _noDispData.PrevPostNo = agResult.PostNo.TrimEnd();

                // 住所名称分割処理
                string address1;
                string address2;
                DivisionAddressName( 30, agResult.AddressName, out address1, out address2 );
                tEdit_SupplierAddr1.Text = address1.TrimEnd();
                tEdit_SupplierAddr3.Text = address2.TrimEnd();

                // フォーカス
                tEdit_SupplierAddr1.Focus();
            }
        }

        # endregion
        # endregion

        # region ガイド処理
        /// <summary>
        /// 拠点ガイドボタン　クリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_MngSectionNmGuide_Click( object sender, EventArgs e )
        {
            if ( _secInfoSetAcs == null )
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }

            SecInfoSet secInfoSet;
            int status = _secInfoSetAcs.ExecuteGuid( this._enterpriseCode, false, out secInfoSet );

            if ( status == 0 && secInfoSet != null )
            {
                if ( sender == uButton_MngSectionNmGuide )
                {
                    // 管理拠点をセット
                    _noDispData.MngSectionCode = secInfoSet.SectionCode;
                    _noDispData.PrevMngSectionName = secInfoSet.SectionGuideNm;
                    tEdit_MngSectionNm.Text = secInfoSet.SectionGuideNm;

                    // フォーカス
                    tEdit_StockAgentNm.Focus();
                }
                else if ( sender == uButton_PaymentSectionGuide )
                {
                    // 支払拠点をセット
                    _noDispData.PaymentSectionCode = secInfoSet.SectionCode;
                    _noDispData.PrevPaymentSectionName = secInfoSet.SectionGuideNm;
                    tEdit_PaymentSectionCode.Text = secInfoSet.SectionGuideNm;

                    /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                    // 支払拠点が変わったら全体設定も変わる
                    SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
                       --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

                    // フォーカス
                    tNedit_PayeeCode.Focus();
                }
            }
        }
        /// <summary>
        /// 担当者ガイドボタン　クリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_StockAgentGuide_Click( object sender, EventArgs e )
        {
            if ( _employeeAcs == null )
            {
                _employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = _employeeAcs.ExecuteGuid( this._enterpriseCode, true, _noDispData.MngSectionCode, out employee );

            if ( status == 0 && employee != null )
            {
                // 仕入担当者をセット
                _noDispData.StockAgentCode = employee.EmployeeCode;
                _noDispData.PrevStockAgentName = employee.Name;
                tEdit_StockAgentNm.Text = employee.Name;

                // フォーカス
                tComboEditor_PureCode.Focus();
            }
        }
        /// <summary>
        /// 支払先ガイドボタン　クリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_PayeeNameGuide_Click( object sender, EventArgs e )
        {
            Supplier supplier;
            int status = _supplierAcs.ExecuteGuid( out supplier, this._enterpriseCode, _noDispData.PaymentSectionCode );

            if ( status == 0 && supplier != null )
            {
                // 画面に支払先を適用
                if ( SettingPayeeToScreen( supplier ) == true )
                {
                    // フォーカス
                    if ( tNedit_PaymentTotalDay.Enabled )
                    {
                        // 親のとき
                        tNedit_PaymentTotalDay.Focus();
                    }
                    else
                    {
                        // 子のとき
                        if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                        {
                            tEdit_SupplierPostNo.Focus();
                        }
                        else
                        {
                            tEdit_SupplierNote1.Focus();
                        }
                    }
                }
                else
                {
                    tNedit_PayeeCode.Focus();
                }
            }
        }
        /// <summary>
        /// 支払先設定処理
        /// </summary>
        /// <param name="payee"></param>
        private bool SettingPayeeToScreen( Supplier payee )
        {
            bool status = false;

            if ( payee.SupplierCd == 0 || payee.SupplierCd == payee.PayeeCode || payee.SupplierCd == this.tNedit_SupplierCd.GetInt() )
            {
                try
                {
                    // 描画停止　＞＞
                    this.SuspendLayout();

                    // --- ADD 2009/01/20 障害ID:9163対応------------------------------------------------------>>>>>
                    //// 支払拠点をセット
                    //_noDispData.PaymentSectionCode = payee.MngSectionCode.TrimEnd();
                    //_noDispData.PrevPaymentSectionName = payee.MngSectionName.TrimEnd();
                    //tEdit_PaymentSectionCode.Text = payee.MngSectionName.TrimEnd();
                    // --- ADD 2009/01/20 障害ID:9163対応------------------------------------------------------<<<<<

                    // 支払先をセット
                    _noDispData.PrevPayeeCode = payee.SupplierCd;
                    tNedit_PayeeCode.SetInt( payee.SupplierCd );
                    uLabel_PayeeName1.Text = payee.SupplierNm1;
                    uLabel_PayeeName2.Text = payee.SupplierNm2;
                    uLabel_PayeeSnm.Text = payee.SupplierSnm;

                    tNedit_PaymentTotalDay.SetInt( payee.PaymentTotalDay );
                    SetComboEditorItemIndex( tComboEditor_PaymentMonthCode, payee.PaymentMonthCode );
                    tNedit_PaymentDay.SetInt( payee.PaymentDay );
                    SetComboEditorItemIndex( tComboEditor_PaymentCond, payee.PaymentCond );
                    tNedit_PaymentSight.SetInt( payee.PaymentSight );
                    tNedit_NTimeCalcStDate.SetInt( payee.NTimeCalcStDate );

                    /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
                    SetComboEditorItemIndex( tComboEditor_StckTtlAmntDspWayRef, payee.StckTtlAmntDspWayRef );

                    SetComboEditorItemIndex( tComboEditor_SuppTtlAmountDispWayCd, payee.SuppTtlAmntDspWayCd );
                       --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
                    SetComboEditorItemIndex( tComboEditor_SuppCTaXLayRefCd, payee.SuppCTaxLayRefCd );
                    SetComboEditorItemIndex( tComboEditor_SuppTaxLayMethod, payee.SuppCTaxLayCd );

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
                    tNedit_StockUnPrcFrcProcCd.SetInt( payee.StockUnPrcFrcProcCd );
                    tNedit_StockMoneyFrcProcCd.SetInt( payee.StockMoneyFrcProcCd );
                    tNedit_StockCnsTaxFrcProcCd.SetInt( payee.StockCnsTaxFrcProcCd );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD

                    if ( payee.SupplierCd != 0 )
                    {
                        // 支払先入力 → 仕入先が親/子決定するので、画面に反映
                        SettingScreenEnableForChild( payee.SupplierCd != this.tNedit_SupplierCd.GetInt() );
                    }
                    else
                    {
                        // 支払先未入力 → 支払情報は入力可
                        SettingScreenEnableForChild( false );
                    }

                    // 全体設定は支払拠点依存
                    // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                    //SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
                    //SettingEnableBySuppTtlAmountDispWayCd((int)tComboEditor_SuppTtlAmountDispWayCd.Value);
                    SettingEnableBySuppTtlAmountDispWayCd(0);
                    // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                    SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);

                    status = true;
                }
                finally
                {
                    // 描画開始　＜＜
                    this.ResumeLayout();
                }
                return status;
            }
            else
            {
                // クリアする
                payee = new Supplier();
                SettingPayeeToScreen( payee );

                TMsgDisp.Show( this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    ASSEMBLY_ID,
                    "選択された仕入先は支払先コードが異なる為、支払先として選択できません",
                    0,
                    MessageBoxButtons.OK );

                // 次フォーカス
                tNedit_PayeeCode.Focus();

                return status;
            }
        }

        /// <summary>
        /// 画面表示設定
        /// </summary>
        /// <param name="isChild"></param>
        private void SettingScreenEnableForChild( bool isChild )
        {
            // 子のとき入力不可項目の制御
            tNedit_PaymentTotalDay.Enabled = !isChild;
            tComboEditor_PaymentMonthCode.Enabled = !isChild;
            tNedit_PaymentDay.Enabled = !isChild;
            tComboEditor_PaymentCond.Enabled = !isChild;
            tNedit_PaymentSight.Enabled = !isChild;
            tNedit_NTimeCalcStDate.Enabled = !isChild;
            /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
            tComboEditor_StckTtlAmntDspWayRef.Enabled = !isChild;
            tComboEditor_SuppTtlAmountDispWayCd.Enabled = !isChild;
               --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/
            tComboEditor_SuppCTaXLayRefCd.Enabled = !isChild;
            tComboEditor_SuppTaxLayMethod.Enabled = !isChild;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/07 ADD
            tNedit_StockUnPrcFrcProcCd.Enabled = !isChild;
            uButton_SalesUnPrcFrcProcCdGuide.Enabled = !isChild;
            tNedit_StockMoneyFrcProcCd.Enabled = !isChild;
            uButton_SalesMoneyFrcProcCdGuide.Enabled = !isChild;
            tNedit_StockCnsTaxFrcProcCd.Enabled = !isChild;
            uButton_SalesCnsTaxFrcProcCdGuide.Enabled = !isChild;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/07 ADD
        }
        /// <summary>
        /// 仕入端数処理ガイドボタン　クリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SalesUnPrcFrcProcCdGuide_Click( object sender, EventArgs e )
        {
            // 仕入端数処理アクセスクラスがnullなら生成
            if ( _stockProcMoneyAcs == null )
            {
                _stockProcMoneyAcs = new StockProcMoneyAcs();
            }

            // 対象Nedit
            TNedit targetNedit = null;
            // 対象となる処理区分
            int procDiv = 0;

            if ( sender == uButton_SalesMoneyFrcProcCdGuide )
            {
                // 仕入金額
                targetNedit = tNedit_StockMoneyFrcProcCd;
                procDiv = 0;
            }
            else if ( sender == uButton_SalesCnsTaxFrcProcCdGuide )
            {
                // 消費税
                targetNedit = tNedit_StockCnsTaxFrcProcCd;
                procDiv = 1;
            }
            else if ( sender == uButton_SalesUnPrcFrcProcCdGuide )
            {
                // 仕入単価
                targetNedit = tNedit_StockUnPrcFrcProcCd;
                procDiv = 2;
            }

            // ガイド起動
            StockProcMoney stockProcMoney;
            int status = _stockProcMoneyAcs.ExecuteGuid( this._enterpriseCode, procDiv, -1, out stockProcMoney );

            // 対象Editに格納
            if ( targetNedit != null && status == 0 )
            {
                targetNedit.SetInt( stockProcMoney.FractionProcCode );

                // フォーカス
                switch ( targetNedit.Name )
                {
                    case "tNedit_StockUnPrcFrcProcCd":
                        {
                            tNedit_StockMoneyFrcProcCd.Focus();
                        }
                        break;
                    case "tNedit_StockMoneyFrcProcCd":
                        {
                            tNedit_StockCnsTaxFrcProcCd.Focus();
                        }
                        break;
                    case "tNedit_StockCnsTaxFrcProcCd":
                        {
                            if ( SubInfo_UTabControl.SelectedTab.Index == 0 )
                            {
                                tEdit_SupplierPostNo.Focus();
                            }
                            else
                            {
                                tEdit_SupplierNote1.Focus();
                            }

                        }
                        break;
                }
            }
        }
        /// <summary>
        /// 郵便番号ガイド
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_AddressGuide_Click( object sender, EventArgs e )
        {
            ReadAddress( tEdit_SupplierPostNo.Text );
        }
        /// <summary>
        /// 住所検索処理(郵便番号より)(SFTKD00426U.DLL)
        /// </summary>
        /// <param name="strPostNo">郵便番号</param>
        /// <param name="agResult">住所情報戻り値クラス</param>
        /// <returns>STATUS [0:取得完了 0以外:取得失敗]</returns>
        private int GetAddressFromPostNo( string strPostNo, out AddressGuideResult agResult )
        {
            if ( _addressGuide == null )
            {
                _addressGuide = new AddressGuide();
            }

            System.Windows.Forms.DialogResult result = this._addressGuide.ShowPostNoSearchGuide( strPostNo, out agResult );

            if ( (result == DialogResult.OK) || (result == DialogResult.Yes) )
            {
                if ( agResult.AddressName != "" )
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// 住所名称分割処理
        /// </summary>
        /// <param name="length">分割文字数</param>
        /// <param name="addressName">住所名称</param>
        /// <param name="addressName1">住所名称分割結果１</param>
        /// <param name="addressName2">住所名称分割結果２</param>
        private static void DivisionAddressName( int length, string addressName, out string addressName1, out string addressName2 )
        {
            addressName1 = addressName;
            addressName2 = "";

            if ( addressName.Length > length )
            {
                addressName1 = addressName.Substring( 0, length );
                addressName2 = addressName.Substring( length, addressName.Length - length );
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 全角→半角 変換
        /// </summary>
        /// <param name="text"></param>
        private static string ToHalf( string text )
        {
            return Microsoft.VisualBasic.Strings.StrConv( text, Microsoft.VisualBasic.VbStrConv.Narrow, 0 );
        }
		# endregion

        # region [UI非表示データ]
        /// <summary>
        /// UI非表示データ
        /// </summary>
        private struct NoDispData
        {
            # region [private フィールド]
            /// <summary>管理拠点コード</summary>
            private string _mngSectionCode;
            /// <summary>仕入担当者コード</summary>
            private string _stockAgentCode;
            /// <summary>支払拠点コード</summary>
            private string _paymentSectionCode;
            /// <summary>前回入力 管理拠点名称</summary>
            private string _prevMngSectionName;
            /// <summary>前回入力 仕入担当者名称</summary>
            private string _prevStockAgentName;
            /// <summary>前回入力 支払拠点名称</summary>
            private string _prevPaymentSectionName;
            /// <summary>前回入力 仕入先コード</summary>
            private int _prevSupplierCd;
            /// <summary>前回入力 支払先コード</summary>
            private int _prevPayeeCode;
            /// <summary>前回入力 郵便番号</summary>
            private string _prevPostNo;
            /// <summary>前回入力 仕入先名称１</summary>
            private string _prevSupplierName;
            # endregion

            # region [public プロパティ]
            /// <summary>
            /// 管理拠点コード
            /// </summary>
            public string MngSectionCode
            {
                get { return _mngSectionCode; }
                set { _mngSectionCode = value; }
            }
            /// <summary>
            /// 仕入担当者コード
            /// </summary>
            public string StockAgentCode
            {
                get { return _stockAgentCode; }
                set { _stockAgentCode = value; }
            }
            /// <summary>
            /// 支払拠点コード
            /// </summary>
            public string PaymentSectionCode
            {
                get { return _paymentSectionCode; }
                set { _paymentSectionCode = value; }
            }
            /// <summary>
            /// 前回入力 管理拠点名称
            /// </summary>
            public string PrevMngSectionName
            {
                get { return _prevMngSectionName; }
                set { _prevMngSectionName = value; }
            }
            /// <summary>
            /// 前回入力 仕入担当者名称
            /// </summary>
            public string PrevStockAgentName
            {
                get { return _prevStockAgentName; }
                set { _prevStockAgentName = value; }
            }
            /// <summary>
            /// 前回入力 支払拠点
            /// </summary>
            public string PrevPaymentSectionName
            {
                get { return _prevPaymentSectionName; }
                set { _prevPaymentSectionName = value; }
            }
            /// <summary>
            /// 前回入力 仕入先コード
            /// </summary>
            public int PrevSupplierCd
            {
                get { return _prevSupplierCd; }
                set { _prevSupplierCd = value; }
            }
            /// <summary>
            /// 前回入力 支払先コード
            /// </summary>
            public int PrevPayeeCode
            {
                get { return _prevPayeeCode; }
                set { _prevPayeeCode = value; }
            }
            /// <summary>
            /// 前回入力 郵便番号
            /// </summary>
            public string PrevPostNo
            {
                get { return _prevPostNo; }
                set { _prevPostNo = value; }
            }
            /// <summary>
            /// 前回入力 仕入先名称１
            /// </summary>
            public string PrevSupplierName
            {
                get { return _prevSupplierName; }
                set { _prevSupplierName = value; }
            }
            # endregion

            # region [public メソッド]
            /// <summary>
            /// データ取得処理（Supplier→NoDispData）
            /// </summary>
            /// <param name="supplier"></param>
            public void SetFromData( Supplier supplier )
            {
                // コード
                MngSectionCode = supplier.MngSectionCode.TrimEnd();
                StockAgentCode = supplier.StockAgentCode.TrimEnd();
                PaymentSectionCode = supplier.PaymentSectionCode.TrimEnd();
                // 前回入力
                PrevMngSectionName = supplier.MngSectionName.TrimEnd();
                PrevStockAgentName = supplier.StockAgentName.TrimEnd();
                PrevPaymentSectionName = supplier.PaymentSectionName.TrimEnd();
                PrevSupplierCd = supplier.SupplierCd;
                PrevPayeeCode = supplier.PayeeCode;
                PrevSupplierName = supplier.SupplierNm1.TrimEnd();
                PrevPostNo = supplier.SupplierPostNo.TrimEnd();
            }
            /// <summary>
            /// データ格納処理（NoDispData→Supplier）
            /// </summary>
            /// <param name="supplier"></param>
            public void SetToData( ref Supplier supplier )
            {
                // コード
                supplier.MngSectionCode = MngSectionCode;
                supplier.StockAgentCode = StockAgentCode;
                supplier.PaymentSectionCode = PaymentSectionCode;
            }
            /// <summary>
            /// データクリア処理
            /// </summary>
            public void Clear()
            {
                // コード
                MngSectionCode = string.Empty;
                StockAgentCode = string.Empty;
                PaymentSectionCode = string.Empty;
                // 前回入力
                PrevMngSectionName = string.Empty;
                PrevStockAgentName = string.Empty;
                PrevPaymentSectionName = string.Empty;
                PrevSupplierCd = 0;
                PrevPayeeCode = 0;
                PrevSupplierName = string.Empty;
                PrevPostNo = string.Empty;
            }
            # endregion
        }
        # endregion

        # region [仕入金額端数処理キー]
        /// <summary>
        /// 仕入金額端数処理キー構造体
        /// </summary>
        private struct StockProcMoneyKey
        {
            private int _fracProcMoneyDiv;
            private int _fractionProcCode;

            /// <summary>端数処理区分</summary>
            public int FracProcMoneyDiv
            {
                get { return _fracProcMoneyDiv; }
                set { _fracProcMoneyDiv = value; }
            }
            /// <summary>端数処理コード</summary>
            public int FractionProcCode
            {
                get { return _fractionProcCode; }
                set { _fractionProcCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="fracProcMoneyDiv"></param>
            /// <param name="fractionProcCode"></param>
            public StockProcMoneyKey( int fracProcMoneyDiv, int fractionProcCode )
            {
                this._fracProcMoneyDiv = fracProcMoneyDiv;
                this._fractionProcCode = fractionProcCode;
            }
        }
        # endregion

        /// <summary>
        /// ｶﾅ内容変更時イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tEdit_SupplierKana_ValueChanged( object sender, EventArgs e )
        {
            // TImeControl(福岡のコンポーネント)では全角カナになる為、値変更時に半角ｶﾅに変換する＋規定の桁数で切る
            string kana = ToHalf( tEdit_SupplierKana.Text );
            tEdit_SupplierKana.Text = kana.Substring( 0, Math.Min( tEdit_SupplierKana.ExtEdit.Column, kana.Length ) );
        }

        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 総額表示参照区分変更時イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_StckTtlAmntDspWayRef_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
        }
           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// 転嫁方式参照区分変更時イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SuppCTaXLayRefCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SettingEnableBySuppCTaXLayRefCd( (int)tComboEditor_SuppCTaXLayRefCd.Value );
        }

        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 総額表示Enable設定
        /// </summary>
        /// <param name="value"></param>
        private void SettingEnableByStckTtlAmntDspWayRef( int value )
        {
            if ( value == 0 )
            {
                // 0:全体設定
                tComboEditor_SuppTtlAmountDispWayCd.Enabled = false;
                // 全体初期値設定で置き換える(支払拠点依存)
                AllDefSet allDefSet = GetAllDefSet( _noDispData.PaymentSectionCode );
                SetComboEditorItemIndex( tComboEditor_SuppTtlAmountDispWayCd, allDefSet.TotalAmountDispWayCd );
                // セットした値に従いEnable制御
                SettingEnableBySuppTtlAmountDispWayCd( (int)tComboEditor_SuppTtlAmountDispWayCd.Value );
            }
            else
            {
                // 1:仕入先
                if ( tNedit_PaymentTotalDay.Enabled )
                {
                    tComboEditor_SuppTtlAmountDispWayCd.Enabled = true;
                }
            }
        }
           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// 転嫁方式Enable設定
        /// </summary>
        /// <param name="value"></param>
        private void SettingEnableBySuppCTaXLayRefCd( int value )
        {
            if ( value == 0 )
            {
                // 0:全体設定
                tComboEditor_SuppTaxLayMethod.Enabled = false;
                // 税率設定で置き換える
                SetComboEditorItemIndex( tComboEditor_SuppTaxLayMethod, _taxRateSet.ConsTaxLayMethod );
            }
            else
            {
                // 1:仕入先
                if ( tNedit_PaymentTotalDay.Enabled && tComboEditor_SuppCTaXLayRefCd.Enabled )
                {
                    tComboEditor_SuppTaxLayMethod.Enabled = true;
                }
            }
        }
        /// <summary>
        /// 総額表示方法区分Enable設定
        /// </summary>
        /// <param name="value"></param>
        private void SettingEnableBySuppTtlAmountDispWayCd( int value )
        {
            if ( value == 0 )
            {
                // 0:しない（税抜き）
                // →転嫁方式を入力可能にする
                if ( tNedit_PaymentTotalDay.Enabled )
                {
                    tComboEditor_SuppCTaXLayRefCd.Enabled = true;
                }
                SettingEnableBySuppCTaXLayRefCd( (int)tComboEditor_SuppCTaXLayRefCd.Value );
            }
            else
            {
                // 1:する（税込み）
                // →転嫁方式を入力不可にして、「1:仕入先参照」「1:明細単位」固定にする
                tComboEditor_SuppCTaXLayRefCd.Enabled = false;
                tComboEditor_SuppTaxLayMethod.Enabled = false;
                tComboEditor_SuppCTaXLayRefCd.Value = 1;
                tComboEditor_SuppTaxLayMethod.Value = 1;
            }
        }
        /// <summary>
        /// 全体初期値設定取得処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private AllDefSet GetAllDefSet( string sectionCode )
        {
            const string allSection = "00";

            
            // 補正
            sectionCode = sectionCode.TrimEnd();

            if ( _allDefSetDic.ContainsKey( sectionCode ) )
            {
                // 拠点に対する設定
                return _allDefSetDic[sectionCode];
            }
            else if ( _allDefSetDic.ContainsKey( allSection ) )
            {
                // 全社設定
                return _allDefSetDic[allSection];
            }
            else
            {
                // 空の設定
                return new AllDefSet(); 
            }
        }

        /* --- DEL 2008/12/12 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 総額表示区分変更イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SuppTtlAmountDispWayCd_SelectionChangeCommitted( object sender, EventArgs e )
        {
            SettingEnableBySuppTtlAmountDispWayCd( (int)tComboEditor_SuppTtlAmountDispWayCd.Value );
        }
           --- DEL 2008/12/12 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// 提供仕入先ガイドボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2012/10/22  王君</br>
        /// <br>管理番号   : 2012/11/14配信分</br>
        /// <br>             Redmine#32861 仕入先ガイドは、仕入伝票入力と同様のガイドを使用するように修正</br>
        /// </remarks>
        private void uButton_OfrSupplierGuide_Click( object sender, EventArgs e )
        {
            // --------- DEL 王君 2012/10/22 Redmine#32861----------->>>>>
            //if ( _ofrSupplierAcs == null )
            //{
            //    _ofrSupplierAcs = new OfrSupplierAcs();
            //}
            //OfrSupplier ofrSupplier;
            //int status = _ofrSupplierAcs.ExecuteGuid( out ofrSupplier );
            // --------- DEL 王君 2012/10/22 Redmine#32861-----------<<<<<
            // --------- ADD 王君 2012/10/22 Redmine#32861----------->>>>>
            if (_supplierAcs == null)
            {
                _supplierAcs = new SupplierAcs();
            }
            Supplier supplierInfo;
            int status = _supplierAcs.ExecuteGuid(out supplierInfo,this._enterpriseCode,string.Empty);
            // --------- ADD 王君 2012/10/22 Redmine#32861-----------<<<<<
            // ガイド結果セット
            //if (status == 0 && _ofrSupplierAcs != null) // DEL 王君 2012/10/22 Redmine#32861
            if (status == 0 && supplierInfo != null) // ADD 王君 2012/10/22 Redmine#32861
            {
                // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                // 仕入先登録済みチェック
                //int supplierCode = ofrSupplier.SupplierCd;

                //if ( supplierCode != _noDispData.PrevSupplierCd )
                //{
                //    int code;
                //    string name1;
                //    string name2;
                //    string snm;

                //    if (ReadSupplier(supplierCode, out code, out name1, out name2, out snm))
                //    {
                //        TMsgDisp.Show(
                //            this,
                //            emErrorLevel.ERR_LEVEL_INFO,
                //            this.Name,
                //            "入力されたコードの仕入先情報が既に登録されています。",
                //            -1,
                //            MessageBoxButtons.OK);

                //        tNedit_SupplierCd.SetInt(0);
                //        _noDispData.PrevSupplierCd = 0;

                //        // 次フォーカス
                //        uButton_OfrSupplierGuide.Focus();
                //    }
                //    else
                //    {
                //        // 選択結果セット
                //        tNedit_SupplierCd.SetInt( ofrSupplier.SupplierCd );
                //        tEdit_SupplierName1.Text = ofrSupplier.SupplierNm1;
                //        tEdit_SupplierSnm.Text = ofrSupplier.SupplierSnm;
                //        tEdit_SupplierKana.Text = ofrSupplier.SupplierKana;

                //        // 支払先にもコピー
                //        # region [支払先]
                //        tNedit_PayeeCode.SetInt( ofrSupplier.SupplierCd );
                //        uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                //        uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                //        uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                //        _noDispData.PrevPayeeCode = ofrSupplier.SupplierCd;

                //        SettingScreenEnableForChild( false );

                //        // 全体設定は支払拠点依存
                //        // --- CHG 2008/12/12 --------------------------------------------------------------------->>>>>
                //        //SettingEnableByStckTtlAmntDspWayRef( (int)tComboEditor_StckTtlAmntDspWayRef.Value );
                //        //SettingEnableBySuppTtlAmountDispWayCd((int)tComboEditor_SuppTtlAmountDispWayCd.Value);
                //        SettingEnableBySuppTtlAmountDispWayCd(0);
                //        // --- CHG 2008/12/12 ---------------------------------------------------------------------<<<<<
                //        SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                //        # endregion

                //        // 次フォーカス
                //        tEdit_SupplierName1.Focus();
                //    }
                //}

                //tNedit_SupplierCd.SetInt(ofrSupplier.SupplierCd); // DEL 王君 2012/10/22 Redmine#32861
                tNedit_SupplierCd.SetInt(supplierInfo.SupplierCd);   // ADD 王君 2012/10/22 Redmine#32861
                if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        ((Control)sender).Focus();
                    }
                    else
                    {
                        // --------- DEL 王君 2012/10/22 Redmine#32861------------------>>>>>
                        // 選択結果セット
                        //tNedit_SupplierCd.SetInt(ofrSupplier.SupplierCd);
                        //tEdit_SupplierName1.Text = ofrSupplier.SupplierNm1;
                        //tEdit_SupplierSnm.Text = ofrSupplier.SupplierSnm;
                        //tEdit_SupplierKana.Text = ofrSupplier.SupplierKana;

                        //// 支払先にもコピー
                        //# region [支払先]
                        //tNedit_PayeeCode.SetInt(ofrSupplier.SupplierCd);
                        //uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                        //uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                        //uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;

                        //_noDispData.PrevPayeeCode = ofrSupplier.SupplierCd;
                        // --------- DEL 王君 2012/10/22 Redmine#32861------------------<<<<<
                        // --------- ADD 王君 2012/10/22 Redmine#32861------------------>>>>>
                        // 選択結果セット
                        tNedit_SupplierCd.SetInt(supplierInfo.SupplierCd);
                        tEdit_SupplierName1.Text = supplierInfo.SupplierNm1;
                        tEdit_SupplierSnm.Text = supplierInfo.SupplierSnm;
                        tEdit_SupplierKana.Text = supplierInfo.SupplierKana;

                        // 支払先にもコピー
                        # region [支払先]
                        tNedit_PayeeCode.SetInt(supplierInfo.SupplierCd);  
                        uLabel_PayeeName1.Text = tEdit_SupplierName1.Text;
                        uLabel_PayeeName2.Text = tEdit_SupplierName2.Text;
                        uLabel_PayeeSnm.Text = tEdit_SupplierSnm.Text;
                        _noDispData.PrevPayeeCode = supplierInfo.SupplierCd;
                        // --------- ADD 王君 2012/10/22 Redmine#32861------------------<<<<<
                        SettingScreenEnableForChild(false);

                        // 全体設定は支払拠点依存
                        SettingEnableBySuppTtlAmountDispWayCd(0);
                        SettingEnableBySuppCTaXLayRefCd((int)tComboEditor_SuppCTaXLayRefCd.Value);
                        # endregion

                        // 次フォーカス
                        tEdit_SupplierName1.Focus();
                    }
                }
                // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
            }
        }

        private void ultraLabel20_Click(object sender, EventArgs e)
        {

        }

        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------>>>>>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            _userGdBdListStc = null;

            ArrayList retList;

            // 業種（ユーザーガイドマスタより取得）
            int status = this.GetDivCodeBodyList(33, out retList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retList.Sort();

                int index = 0;
                if (tComboEditor_BusinessTypeCode.Value != null)
                {
                    index = (int)tComboEditor_BusinessTypeCode.Value;
                }

                tComboEditor_BusinessTypeCode.Items.Clear();
                AddComboEditorItem(this.tComboEditor_BusinessTypeCode, 0, " ");
                int count = 1;
                foreach (ComboEditorItemSupplier ci in retList)
                {
                    count++;
                    AddComboEditorItem(this.tComboEditor_BusinessTypeCode, ci.Code, ci.Name);
                }

                tComboEditor_BusinessTypeCode.Value = index;
            }

            // 販売エリア（ユーザーガイドマスタより取得）
            status = this.GetDivCodeBodyList(21, out retList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                retList.Sort();

                int index = 0;
                if (tComboEditor_SalesAreaCode.Value != null)
                {
                    index = (int)tComboEditor_SalesAreaCode.Value;
                }

                tComboEditor_SalesAreaCode.Items.Clear();
                AddComboEditorItem(this.tComboEditor_SalesAreaCode, 0, " ");
                int count = 1;
                foreach (ComboEditorItemSupplier ci in retList)
                {
                    count++;
                    AddComboEditorItem(this.tComboEditor_SalesAreaCode, ci.Code, ci.Name);
                }

                tComboEditor_SalesAreaCode.Value = index;
            }

            // 支払設定マスタ読込
            PaymentSet paymentSet;
            status = ReadPaymentSet(out paymentSet);
            if (status == 0)
            {
                // 金額種別設定マスタ読込
                Dictionary<int, MoneyKind> moneyKindDic;
                status = ReadMoneyKind(out moneyKindDic);
                if (status == 0)
                {
                    int index = 0;
                    if (tComboEditor_PaymentCond.Value != null)
                    {
                        index = (int)tComboEditor_PaymentCond.Value;
                    }

                    tComboEditor_PaymentCond.Items.Clear();

                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd1))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd1, moneyKindDic[paymentSet.PayStMoneyKindCd1].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd2))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd2, moneyKindDic[paymentSet.PayStMoneyKindCd2].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd3))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd3, moneyKindDic[paymentSet.PayStMoneyKindCd3].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd4))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd4, moneyKindDic[paymentSet.PayStMoneyKindCd4].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd5))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd5, moneyKindDic[paymentSet.PayStMoneyKindCd5].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd6))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd6, moneyKindDic[paymentSet.PayStMoneyKindCd6].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd7))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd7, moneyKindDic[paymentSet.PayStMoneyKindCd7].MoneyKindName);
                    }
                    if (moneyKindDic.ContainsKey(paymentSet.PayStMoneyKindCd8))
                    {
                        AddComboEditorItem(tComboEditor_PaymentCond, paymentSet.PayStMoneyKindCd8, moneyKindDic[paymentSet.PayStMoneyKindCd8].MoneyKindName);
                    }

                    tComboEditor_PaymentCond.Value = index;
                }
            }

            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            taxRateSetAcs.Read(out _taxRateSet, this._enterpriseCode, 0); // 0:一般
            if (_taxRateSet == null) _taxRateSet = new TaxRateSet();

            this._stockProcMoneyAcs = new StockProcMoneyAcs();

            this._stockProcMoneyCdList = null;

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // --- ADD 2009/03/23 残案件No.14対応------------------------------------------------------<<<<<

        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 仕入先コード
            int supplierCd = tNedit_SupplierCd.GetInt();

            for (int i = 0; i < this._supplierDataTable.Rows.Count; i++)
            {
                // データセットと比較
                int dsSupplierCd = (int)this._supplierDataTable.Rows[i][SUPPLIERCD_TITLE];
                if (supplierCd == dsSupplierCd)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this._supplierDataTable.Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの仕入先情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 仕入先コードのクリア
                        tNedit_SupplierCd.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの仕入先情報が既に登録されています。\n編集を行いますか？",                                    // 表示するメッセージ
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
                                // 仕入先コードのクリア
                                tNedit_SupplierCd.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.31 30413 犬飼 新規モードからモード変更対応 <<<<<<END
    }
}

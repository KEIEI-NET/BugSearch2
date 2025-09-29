//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 売上・仕入データアクセスクラス
// プログラム概要   : 売上・仕入データアクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//           2009/05/25  修正内容 : 96186 立花 裕輔 ホンダ UOE WEB対応
//           2010/05/10  修正内容 : #7146 PM1007C 三菱UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/07/05  修正内容 : Mantis.15654　SCMではない得意先で送信処理をした場合でもSCM送信画面が表示されてしまう件の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2011/07/28  修正内容 : 自動回答区分追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/11/08  修正内容 : Redmine#26275 UOE仕入データ作成処理　回答データに伝票番号がセットされていないデータについての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内 数馬
// 作 成 日  2011/12/02  修正内容 : ゼロ伝の場合に原価がセットされ、粗利が不正となる現象の修正
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : shij
// 作 成 日  K2011/12/31 修正内容 : 2012/01/25配信分対応 Redmine#27558 UOE送信処理/ゼロ伝の印字
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 鄧潘ハ
// 作 成 日  2012/02/10  修正内容 : 2012/03/28配信分、Redmine#28406 発注送信後のデータ作成不具合についての対応
//----------------------------------------------------------------------------//
// 管理番号  10802197-00 作成担当 : 30517 夏野 駿希
// 作 成 日  K2012/06/20 修正内容 : 山形部品個別対応
//                                  手入力発注の場合、仕入データを作成しない様に修正
//----------------------------------------------------------------------------//
// 管理番号  10802197-01 作成担当 : FSI佐々木 貴英
// 作 成 日  K2012/12/11 修正内容 : 山形部品個別対応
//                                  山形部品完全個別オプション判定追加
//----------------------------------------------------------------------------//
// 管理番号  10802197-01 作成担当 : 西 毅
// 作 成 日  2013/03/01  修正内容 : 単価算出時に売上金額処理区分が正しく参照できるように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : chenw
// 作 成 日  2013/03/07  修正内容 : 2013/04/03配信分
//                                  Redmine#34989の対応 日産UOEWEBの改良(ＯＰＥＮ価格対応)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2013/12/16  修正内容 : Redmine#41551の対応 消費税8%増税に伴って、発見された障害の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪権来
// 作 成 日  2014/01/24  修正内容 : Redmine#41551の対応 UOE消費税対応
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : xupz
// 作 成 日  2014/09/02  修正内容 : Redmine#43365の対応 UOE送信処理 品名カナに対して回答結果の品名がセットされない件
//----------------------------------------------------------------------------//
// 管理番号  11100068-00 作成担当 : 陳艶丹
// 作 成 日  2015/07/24  修正内容 : Redmine#46880の対応 e-Partsメーカーフォロー分が売上仕入連携されない障害の解除
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 陳艶丹
// 作 成 日  2020/11/20  修正内容 : PMKOBETSU-4097 TSPインライン機能追加対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
// ADD K2012/12/11 START >>>>>>
using Broadleaf.Application.Resources;
// ADD K2012/12/11 END <<<<<<

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 売上・仕入データアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上・仕入データアクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UOESalesStockAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UOESalesStockAcs()
		{
			//企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//ログイン拠点コード
			this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

			//ＵＯＥ送受信ＪＮＬアクセスクラス
			this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

            //アクセスクラス インスタンス
            this._uOEOrderDtlAcs = UOEOrderDtlAcs.GetInstance();

            //締日算出モジュールアクセスクラス
            this._totalDayCalculator = TotalDayCalculator.GetInstance();

            //ＵＯＥ送受信制御初期化クラス
            this._uoeSndRcvCtlInitAcs = UoeSndRcvCtlInitAcs.GetInstance();

			//売上・仕入制御アクセスクラス
			this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();

			//仕入先情報アクセスクラス
			this._customerInfoAcs = new CustomerInfoAcs();
			//this._customerInfoAcs.IsLocalDBRead = SalesSlipInputInitDataAcs.ctIsLocalDBRead;

            //売上・仕入更新アクセスクラス
            this._uOESalesStockDataAcs = new UOESalesStockDataAcs();

            // 共通伝票番号のDictionary
            this._commonSlipNoDictionary = new Dictionary<string, StockSlipWork>();

            //HONDA専用BO検索用Dictionary
            this._hondaSlipNoDictionary = new Dictionary<string, string>();

            // 売上仕入連携のDictionary
            // OnlineNo(9)+OnlineRowNo(4)+BOSlipNo
            this._linkSalesStockDictionary = new Dictionary<string,Guid>();

            // (売上金額処理設定)
            this._salesProcMoneyAcs = new SalesProcMoneyAcs();
            this.CacheSalesProcMoney();

            // (売上金額算出モジュール)
            this._salesPriceCalculate = new SalesPriceCalculate();
            _salesPriceCalculate.CacheSalesProcMoneyList(_salesProcMoneyList);

            this._stockPriceCalculate = new StockPriceCalculate();

            this._unitPriceCalculation = new UnitPriceCalculation();
            // --- ADD 2013/03/01 T.Nishi ---------->>>>>
            this._unitPriceCalculation.CacheSalesProcMoneyList(_salesProcMoneyList);
            // --- ADD 2013/03/01 T.Nishi ----------<<<<<
            this._supplierAcs = new SupplierAcs();

            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();

            // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
            #region ●TSPオプション
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_Tsp);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                _uOESalesStockDataAcs.Opt_TSP = (int)Broadleaf.Application.Controller.UOEOrderDtlAcs.Option.ON;
            }
            else
            {
                _uOESalesStockDataAcs.Opt_TSP = (int)Broadleaf.Application.Controller.UOEOrderDtlAcs.Option.OFF;
            }
            #endregion
        }
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		//企業コード
		private string _enterpriseCode = "";

		//ログイン拠点コード
		private string _loginSectionCd = "";

		//ＵＯＥ送受信ＪＮＬアクセスクラス
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

        //アクセスクラス インスタンス
        private UOEOrderDtlAcs _uOEOrderDtlAcs = null;

        //ＵＯＥ送受信制御初期化クラス
        private UoeSndRcvCtlInitAcs _uoeSndRcvCtlInitAcs = null;

        private UOESalesStockDataAcs _uOESalesStockDataAcs = null;

		//売上・仕入制御アクセスクラス
		private IIOWriteControlDB _iIOWriteControlDB = null;

		//仕入先情報アクセスクラス
		private CustomerInfoAcs _customerInfoAcs;

		// 仕入伝票削除区分
		private int _supplierSlipDelDiv;

        // 共通伝票番号のDictionary
        private Dictionary<string, StockSlipWork> _commonSlipNoDictionary;

        // HONDA専用BO検索用Dictionary
        private Dictionary<string, string> _hondaSlipNoDictionary;

        // 共通伝票番号のDictionary
        // OnlineNo(9)+OnlineRowNo(4)+BOSlipNo
        private Dictionary<string, Guid> _linkSalesStockDictionary;

        // ＵＯＥ送信制御条件クラス
        private UoeSndRcvCtlPara _uoeSndRcvCtlPara = null;

        // 締日算出モジュール
        private TotalDayCalculator _totalDayCalculator = null;

        private SalesProcMoneyAcs _salesProcMoneyAcs = null;

        private SalesPriceCalculate _salesPriceCalculate;

        private List<SalesProcMoney> _salesProcMoneyList;

        private UnitPriceCalculation _unitPriceCalculation;

        private StockPriceCalculate _stockPriceCalculate;

        private SupplierAcs _supplierAcs;

        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        # endregion

		// ===================================================================================== //
		// 定数群
		// ===================================================================================== //
		#region Public Const Member
		// メッセージ
		private const string MESSAGE_NoResult = "条件に一致するデータは存在しません。";
		private const string MESSAGE_ErrResult = "データの取得に失敗しました。";
		private const string MESSAGE_NotFound = "処理対象のデータが存在しません。";
        private const string OPENFLAG = "OPEN価格"; // ADD chenw 2013/03/07 Redmine#34989

        //伝票出力区分のチェックのパラメータ
        private const int ctZeroSlip = 0;   //ゼロ伝票
        private const int ctZeroDtl = 1;    //ゼロ明細
        private const int ctAddingUp = 2;   //合算

        //-----------------------------------------------------------
        // 端数処理対象金額区分
        //-----------------------------------------------------------
        # region 端数処理対象金額区分
        /// <summary>端数処理対象金額区分（売上金額）</summary>
        internal const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>端数処理対象金額区分（消費税）</summary>
        internal const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（売上単価）</summary>
        internal const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        ///// <summary>端数処理対象金額区分（原価単価）</summary>
        //internal const int ctFracProcMoneyDiv_SalesUnitCost = 3;
        ///// <summary>端数処理対象金額区分（原価金額）</summary>
        //internal const int ctFracProcMoneyDiv_Cost = 4;
        # endregion

        /// <summary>
        /// 商品区分
        /// </summary>
        public enum SalesGoodsCd : int
        {
            /// <summary>商品</summary>
            Goods = 0,
            /// <summary>商品外</summary>
            NonGoods = 1,
            /// <summary>消費税調整</summary>
            ConsTaxAdjust = 2,
            /// <summary>残高調整</summary>
            BalanceAdjust = 3,
            /// <summary>売掛用消費税調整</summary>
            AccRecConsTaxAdjust = 4,
            /// <summary>売掛用残高調整</summary>
            AccRecBalanceAdjust = 5,
        }

        /// <summary>
        /// 売上単価入力モード列挙型
        /// </summary>
        public enum SalesUnitPriceInputType : int
        {
            /// <summary>売上単価（税抜き）入力</summary>
            SalesUnitPrice = 0,
            /// <summary>売上単価（税込み）入力</summary>
            SalesUnitTaxPrice = 1,
            /// <summary>売上単価（表示用）入力</summary>
            SalesUnitPriceDisplay = 2,
        }

        /// <summary>
        /// 総額表示方法区分
        /// </summary>
        internal enum TotalAmountDispWayCd : int
        {
            /// <summary>総額表示しない</summary>
            NoTotalAmount = 0,
            /// <summary>総額表示する</summary>
            TotalAmount = 1,
        }

        /// <summary>
        /// 消費税転嫁方式
        /// </summary>
        internal enum ConsTaxLayMethod : int
        {
            /// <summary>伝票転嫁</summary>
            SlipLay = 0,
            /// <summary>明細転嫁</summary>
            DetailLay = 1,
            /// <summary>請求親</summary>
            DemandParentLay = 2,
            /// <summary>請求子</summary>
            DemandChildLay = 3,
            /// <summary>非課税</summary>
            TaxExempt = 9,
        }

        /// <summary>
        /// 売上伝票区分（明細）
        /// </summary>
        internal enum SalesSlipCdDtl : int
        {
            /// <summary>売上</summary>
            Sales = 0,
            /// <summary>返品</summary>
            RetGoods = 1,
            /// <summary>値引</summary>
            Discount = 2,
            /// <summary>注釈</summary>
            Annotation = 3,
            /// <summary>小計</summary>
            Subtotal = 4,
            /// <summary>作業</summary>
            Work = 5,
        }

        /// <summary>
        /// 売上伝票区分
        /// </summary>
        public enum SalesSlipCd : int
        {
            /// <summary>売上</summary>
            Sales = 0,
            /// <summary>返品</summary>
            RetGoods = 1,
        }

        // 2010/07/05 Add SCMの得意先がいるかのチェック >>>
        public bool scmFlg = false;
        // 2010/07/05 Add <<<

		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
        # region 仕入伝票削除区分
        /// <summary>仕入伝票削除区分</summary>
		public int SupplierSlipDelDiv
		{
			set { this._supplierSlipDelDiv = value; }
			get { return this._supplierSlipDelDiv; }
		}
        # endregion

        # region 送受信ＪＮＬ＜DataSet＞
        /// <summary>
        /// 送受信ＪＮＬ＜DataSet＞
        /// </summary>
        public DataSet UoeJnlDataSet
        {
            get { return this._uoeSndRcvJnlAcs.UoeJnlDataSet; }
        }
        # endregion

        # region 送受信ＪＮＬ(発注)＜DataTable＞
        /// <summary>
        /// 送受信ＪＮＬ(発注)＜DataTable＞
        /// </summary>
        public DataTable OrderTable
        {
            get { return UoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
        }
        # endregion

        # region 仕入データ＜DataTable＞
        /// <summary>
        /// 仕入データ＜DataTable＞
        /// </summary>
        public DataTable StockSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[StockSlipSchema.CT_StockSlipDataTable]; }
        }
        # endregion

        # region 仕入明細＜DataTable＞
        /// <summary>
        /// 仕入明細＜DataTable＞
        /// </summary>
        public DataTable StockDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[StockDetailSchema.CT_StockDetailDataTable]; }
        }
        # endregion

        # region 売上データ＜DataTable＞
        /// <summary>
        /// 売上データ＜DataTable＞
        /// </summary>
        public DataTable SalesSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesSlipSchema.CT_SalesSlipDataTable]; }
        }
        # endregion

        # region 売上明細＜DataTable＞
        /// <summary>
        /// 売上明細＜DataTable＞
        /// </summary>
        public DataTable SalesDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesDetailSchema.CT_SalesDetailDataTable]; }
        }
        # endregion

        # region 受注データ＜DataTable＞
        /// <summary>
        /// 受注データ＜DataTable＞
        /// </summary>
        public DataTable AcptSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesSlipSchema.CT_AcptSlipDataTable]; }
        }
        # endregion

        # region 受注明細＜DataTable＞
        /// <summary>
        /// 受注明細＜DataTable＞
        /// </summary>
        public DataTable AcptDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesDetailSchema.CT_AcptDetailDataTable]; }
        }
        # endregion

        # region Uoe仕入データ＜DataTable＞
        /// <summary>
        /// Uoe仕入データ＜DataTable＞
        /// </summary>
        public DataTable UoeStockSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[StockSlipSchema.CT_UoeStockSlipDataTable]; }
        }
        # endregion

        # region Uoe仕入明細＜DataTable＞
        /// <summary>
        /// Uoe仕入明細＜DataTable＞
        /// </summary>
        public DataTable UoeStockDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[StockDetailSchema.CT_UoeStockDetailDataTable]; }
        }
        # endregion

        # region 商品マスタ アクセスクラス
        /// <summary>
        /// 商品マスタ アクセスクラス
        /// </summary>
        public GoodsAcs _goodsAcs
        {
            get { return _uoeSndRcvJnlAcs.goodsAcs; }
            set { _uoeSndRcvJnlAcs.goodsAcs = value; }
        }
        # endregion
        # endregion

        // ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
        # region 売上・仕入データの更新処理
		/// <summary>
		/// 売上・仕入データ更新処理
		/// </summary>
        /// <param name="uoeSndRcvCtlPara">ＵＯＥ送信制御条件クラス</param>
        /// <param name="message">エラーメッセージ</param>
		/// <returns>0:正常 0以外:エラー</returns>
        public int UpDtSalesStock(UoeSndRcvCtlPara uoeSndRcvCtlPara, out List<UoeSales> uoeSalesList, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
            uoeSalesList = null;

			try
			{
                // 売上仕入連携のDictionaryの初期化
                _linkSalesStockDictionary.Clear();

                // ＵＯＥ送信制御条件クラスの保存
                _uoeSndRcvCtlPara = uoeSndRcvCtlPara;

                // データテーブルの初期化
                this.SalesSlipTable.Clear();
                this.SalesDetailTable.Clear();
                this.AcptSlipTable.Clear();
                this.AcptDetailTable.Clear();
                this.UoeStockSlipTable.Clear();
                this.UoeStockDetailTable.Clear();

                // 売上・仕入データ更新処理
                status = UpDtSalesStockProc(out message);
                if (status == (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    // UOE売上伝票クラスの作成
                    status = UoeSalesFromTableCreate(out uoeSalesList, out message);
                }
			}
			catch (Exception ex)
			{
                uoeSalesList = null;
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        #region UOE売上伝票クラスの作成
        /// <summary>
        /// UOE売上伝票クラスの作成
        /// </summary>
        /// <param name="uoeSalesList">UOE売上伝票クラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <br>Update Note: 2011/12/31 shij</br>
        /// <br>管理番号   ：10707327-00 2012/01/25配信分対応</br>
        /// <br>             Redmine#27558   UOE送信処理/ゼロ伝の印字の修正</br>
        /// <returns>ステータス</returns>
        private int UoeSalesFromTableCreate(out List<UoeSales> uoeSalesList, out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            uoeSalesList = new List<UoeSales>();

            try
            {
                //伝発のみ動作
                if (_uoeSndRcvCtlPara.SystemDivCd != (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                {
                    return (status);
                }

                # region 売上データDataViewの作成
                Int32 acptAnOdrStatus = 30;   //10:見積,20:受注,30:売上,40:出荷（受注ステータス）

                string rowFilterText = "";
                // UOE自社設定ﾏｽﾀのﾒｰｶｰﾌｫﾛｰ計上区分が売上の場合には、ＥＯ伝票・メーカーフォロー伝票対象
                if (_uoeSndRcvJnlAcs.uOESetting.MakerFollowAddUpDiv != (int)EnumUoeConst.ctMakerFollowAddUpDiv.ct_Order)
                {
                    //ゼロ伝票印刷あり
                    if (CheckZeroSlip() == true)
                    {
                        rowFilterText = string.Format("{0} = {1}",
                                                        SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus);
                    }
                    //ゼロ伝票印刷なし
                    else
                    {
                        rowFilterText = string.Format("{0} = {1} AND {2} <> {3}",
                                                        SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Zero);
                    }
                }
                // UOE自社設定ﾏｽﾀのﾒｰｶｰﾌｫﾛｰ計上区分が受注の場合には、ＥＯ伝票・メーカーフォロー伝票対象外
                else
                {
                    /* --------------- DEL 2011.12.31 shij FOR Redmine#27558-------->>>>
                    //ゼロ伝票印刷なし
                    rowFilterText = string.Format("{0} = {1} AND {2} <> {3} AND {4} <> {5} AND {6} <> {7}",
                                                    SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                    SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_EO,
                                                    SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Maker,
                                                    SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Zero);
                    --------------- DEL 2011.12.31 shij FOR Redmine#27558----------<<<<*/
                    // --------------- ADD START 2011.12.31 shij FOR Redmine#27558 -------->>>>
                    //ゼロ伝票印刷あり
                    if (CheckZeroSlip() == true)
                    {
                        rowFilterText = string.Format("{0} = {1} AND {2} <> {3} AND {4} <> {5}",
                                                        SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_EO,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Maker);
                    }
                    //ゼロ伝票印刷なし
                    else
                    {
                        rowFilterText = string.Format("{0} = {1} AND {2} <> {3} AND {4} <> {5} AND {6} <> {7}",
                                                        SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_EO,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Maker,
                                                        SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Zero);
                    }
                    // --------------- ADD END 2011.12.31 shij FOR Redmine#27558 ----------<<<<
                }
                string sortText = string.Format("{0}, {1}",
                                                SalesSlipSchema.ct_Col_AcptAnOdrStatus,
                                                SalesSlipSchema.ct_Col_TempSalesSlipNum);
                DataView viewSalesSlip = new DataView(SalesSlipTable);
                viewSalesSlip.Sort = sortText;
                viewSalesSlip.RowFilter = rowFilterText;

                if (viewSalesSlip == null) return (-1);
                if (viewSalesSlip.Count == 0) return (-1);
                # endregion

                foreach (DataRowView rowUoeSalesSlip in viewSalesSlip)
                {
                    //-----------------------------------------------------------
                    // 伝票クラスの未作成判定
                    //-----------------------------------------------------------
                    # region 伝票クラスの未作成判定
                    // ゼロ伝票なしの場合、伝票クラスを作成しない
                    if ((CheckZeroSlip() != true)
                    && ((Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd] == (Int32)UoeSales.ctSlipCd.ct_Zero))
                    {
                        continue;
                    }

                    // 確認伝票で、売上伝票番号が未設定の場合は、印刷クラスを作成しない
                    if (((string)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SalesSlipNum] == "")
                    && ((Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd] == (Int32)UoeSales.ctSlipCd.ct_Section))
                    {
                        continue;
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // 売上データクラスの取得
                    //-----------------------------------------------------------
                    # region 売上データクラスの取得
                    SalesSlipWork salesSlipWork = _uoeSndRcvJnlAcs.CreateSalesSlipWorkFromSchema(rowUoeSalesSlip.Row);
                    string tempSalesSlipNum = (string)rowUoeSalesSlip[SalesSlipSchema.ct_Col_TempSalesSlipNum];
                    # endregion

                    //------------------------------------------------------
                    // 売上明細データに行番号を設定
                    //------------------------------------------------------
                    # region 売上明細データに行番号を設定
                    _uoeSndRcvJnlAcs.SetRowNoFromSalesDetail(
                                                    salesSlipWork.AcptAnOdrStatus,
                                                    tempSalesSlipNum,
                                                    0,
                                                    out message
                                                    );
                    # endregion

                    //-----------------------------------------------------------
                    // 売上明細クラスの取得
                    //-----------------------------------------------------------
                    # region 売上明細クラスの取得
                    List<UoeSalesDetail> uoeSalesDetailList = _uoeSndRcvJnlAcs.SearchUoeSalesDetailDataTable(
                                                    SalesDetailTable,
                                                    salesSlipWork.AcptAnOdrStatus,
                                                    tempSalesSlipNum,
                                                    (int)PrtSalesDetail.ctDetailCd.ct_Normal
                                                    );
                    if (uoeSalesDetailList == null) continue;
                    if (uoeSalesDetailList.Count == 0) continue;
                    # endregion

                    //-----------------------------------------------------------
                    // UOE売上伝票クラスの格納
                    //-----------------------------------------------------------
                    #region UOE売上伝票クラスの格納
                    UoeSales uoeSales = new UoeSales();

                    // UOE売上明細クラスの設定
                    int slipDtlZeroMode = 0; //0:ゼロ明細不可 1:ゼロ明細可
                    if(((Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd] == (Int32)UoeSales.ctSlipCd.ct_Section)
                    || ((Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd] == (Int32)UoeSales.ctSlipCd.ct_Zero))
                    {
                        slipDtlZeroMode = 1; //1:ゼロ明細可
                    }

                    foreach (UoeSalesDetail uoeSalesDetail in uoeSalesDetailList)
                    {
                        //ゼロ明細を作成しない条件
                        //  ゼロ明細なしの設定
                        //  ゼロ伝票ではない
                        //  ゼロ明細ではない
                        //  ゼロ明細可(確認伝票・ゼロ伝票の場合)
                        PrtSalesDetail prtSalesDetail = uoeSalesDetail.prtSalesDetail;
                        if((CheckZeroDtl() != true)
                        && ((Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd] != (Int32)UoeSales.ctSlipCd.ct_Zero)
                        && (slipDtlZeroMode == 1)
                        && (prtSalesDetail.detailCd == (int)PrtSalesDetail.ctDetailCd.ct_Zero))
                        {
                            continue;
                        }
                        uoeSales.uoeSalesDetailList.Add(uoeSalesDetail);
                    }

                    //売上データクラスの設定
                    uoeSales.salesSlipWork = salesSlipWork;
                    uoeSales.salesSlipWork.DetailRowCount = uoeSales.uoeSalesDetailList.Count;  //明細行数

                    //UOE売上伝票クラス・他情報の設定
                    uoeSales.totalCnt = (int)rowUoeSalesSlip[SalesSlipSchema.ct_Col_TotalCnt];                  //出庫数合計
                    uoeSales.slipCd = (Int32)rowUoeSalesSlip[SalesSlipSchema.ct_Col_SlipCd];                    //UOE伝票種別
                    uoeSalesList.Add(uoeSales);
            		# endregion
                }
            }
            catch (Exception ex)
            {
                uoeSalesList = null;
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
		# endregion

        #region 売上・仕入データ更新メイン処理
        /// <summary>
        /// 売上・仕入データ更新メイン処理
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: 山形部品完全個別オプション判定追加</br>
        /// <br>Programmer : FSI佐々木 貴英</br>
        /// <br>Date       : K2012/12/11 </br>
        /// <br>Update Note: 2020/11/20 陳艶丹</br>
        /// <br>管理番号   : 11670305-00</br>
        /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
        /// </remarks>
        private int UpDtSalesStockProc(out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //売上データ更新
                status = UpDtSalesProc(out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }

                //仕入データ更新
                int systemDivCd = 0;    // add K2012/06/20
                // upd K2012/06/20 >>>
                //status = UpDtStockProc(out message);
                status = UpDtStockProc(out message, ref systemDivCd);
                // upd K2012/06/20 <<<
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }

                //売上・仕入データ保存
                // add K2012/06/20 >>>
                // DEL K2012/12/11 START >>>>>>
                //// 手入力発注の場合は仕入データを作成しない
                //if (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                // DEL K2012/12/11 END <<<<<<
                // ADD K2012/12/11 START >>>>>>
                // 山形部品完全個別オプション判定
                PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                    ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);

                // 山形部品完全個別オプションが有効で、かつ手入力発注の場合は仕入データを作成しない
                if ((PurchaseStatus.Contract == ps ) && (systemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input))
                // ADD K2012/12/11 END <<<<<<
                {
                    return (status);
                }
                // add K2012/06/20 <<<

                // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
                // TSPインラインオプションが立っている時
                if (_uOESalesStockDataAcs.Opt_TSP == (int)Broadleaf.Application.Controller.UOEOrderDtlAcs.Option.ON)
                {
                    _uOESalesStockDataAcs.UoeSndRcvCtlPara = _uoeSndRcvCtlPara;
                }
                // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
                status = _uOESalesStockDataAcs.SaveDBData(out message);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        #region 売上データ更新処理
        /// <summary>
        /// 売上データ更新処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>0:正常 0以外:エラー</returns>
        /// <br>Update Note: 2012/02/10 鄧潘ハン</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28406 発注送信後のデータ作成不具合についての対応</br>
        private int UpDtSalesProc(out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //伝発のみ動作
                if (_uoeSndRcvCtlPara.SystemDivCd != (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                {
                    return (status);
                }

                //------------------------------------------------------
                // 受注データの取得
                //------------------------------------------------------
                # region 受注データの取得
                status = _uOESalesStockDataAcs.GetAcptProc(out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                // 2010/07/05 Add >>>
                this.scmFlg = _uOESalesStockDataAcs.scmFlg;
                // 2010/07/05 Add <<<
                # endregion

                //------------------------------------------------------
                // 送受信JNLのDataViewの作成
                //------------------------------------------------------
                # region 送受信JNLのDataViewの作成
                //送受信JNLのDataViewの作成
                //データ送信区分「9:正常終了」
                //システム区分 0:手入力 1:伝発 2:検索
                string rowFilterText = string.Format("{0} = {1} AND {2} = {3}",
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_OK,
                                                OrderSndRcvJnlSchema.ct_Col_SystemDivCd, (int)EnumUoeConst.ctSystemDivCd.ct_Slip);

                //ソート：オンライン番号・オンライン行番号
                string sortText = string.Format("{0}, {1}",
                                                OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                                OrderSndRcvJnlSchema.ct_Col_OnlineRowNo);

                DataView viewOrder = new DataView(OrderTable);
                viewOrder.Sort = sortText;
                viewOrder.RowFilter = rowFilterText;

                if (viewOrder == null) return (-1);
                if (viewOrder.Count == 0) return (-1);
                # endregion

                //------------------------------------------------------
                // 変数の初期化
                //------------------------------------------------------
                #region 変数の初期化
                int savOnlineNo = 0;            //現在処理中のオンライン番号
                Int64 tempSalesSlipDtlNum = 1;  //売上明細通番（仮）
                _hondaSlipNoDictionary.Clear(); // HONDA専用BO検索用Dictionaryクリア
                #endregion

                foreach (DataRowView rowOrder in viewOrder)
                {
                    //DataRow → OrderSndRcvJnlへ変換
                    OrderSndRcvJnl jnl = _uoeSndRcvJnlAcs.CreateOrderJnlFromSchema(rowOrder.Row);

                    //------------------------------------------------------
                    // 発注先マスタ取得
                    //------------------------------------------------------
                    #region 発注先マスタ値の取得のチェック
                    UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(jnl.UOESupplierCd);
                    if (uOESupplier == null) continue;
                    string commAssemblyId = uOESupplier.CommAssemblyId;		//通信アセンブリID
                    #endregion

                    //------------------------------------------------------
                    // オンライン番号の変化時処理
                    //------------------------------------------------------
                    #region UOE売上クラスの格納処理
                    if (savOnlineNo != jnl.OnlineNo)
                    {
                        #region フラグ初期化
                        //現在処理中のUOE発注番号を保存
                        savOnlineNo = jnl.OnlineNo;
                        tempSalesSlipDtlNum = 1;

                        _hondaSlipNoDictionary.Clear(); // HONDA専用BO検索用Dictionaryクリア
                        #endregion
                    }
                    #endregion

                    //------------------------------------------------------
                    // 売上データ分割処理
                    //------------------------------------------------------
                    #region 売上データ分割処理
                    // 伝票出力形骸（合算）＝ 3 or 6
                    if (CheckAddingUp() == true)
                    {
                        status = slipOutPutAddCalculate(jnl, ref tempSalesSlipDtlNum, out message);
                    }
                    // フォロー(合算)
                    else if (_uoeSndRcvJnlAcs.uOESetting.FollowSlipOutputDiv == (int)EnumUoeConst.ctFollowSlipOutputDiv.ct_Add)
                    {
                        status = salesSlipAddCalculate(jnl, ref tempSalesSlipDtlNum, out message);
                    }
                    // フォロー(別々)
                    else
                    {
                        //ホンダ専用
                        // 2009/05/25 START >>>>>>
                        //if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501)

                        if((uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501)
                        || (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502))
                        // 2009/05/25 END   <<<<<<
                        {
                            //status = salesSlipSeparateForHonda(jnl, ref tempSalesSlipDtlNum, out message);// DEL 2015/07/24 陳艶丹 For Redmine #46880
                            status = salesSlipSeparateForHonda(jnl, ref tempSalesSlipDtlNum, out message, uOESupplier);// ADD 2015/07/24 陳艶丹 For Redmine #46880
                        }
                        //共通
                        else
                        {
                            status = salesSlipSeparate(jnl, ref tempSalesSlipDtlNum, out message);
                        }
                    }
                    //---ADD 鄧潘ハン 2012/02/10 Redmine#28406------>>>>>
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    //---ADD 鄧潘ハン 2012/02/10 Redmine#28406------<<<<<

                    #endregion
                }

                //------------------------------------------------------
                // 売上明細データに行番号を設定
                //------------------------------------------------------
                # region 売上明細データに行番号を設定
                status = SettingRowNoFromSales(out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                # endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region 売上明細データに行番号を設定
        /// <summary>
        /// 売上明細データに行番号を設定
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SettingRowNoFromSales(out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //------------------------------------------------------
                // 売上データDataViewの作成
                //------------------------------------------------------
                # region 売上データDataViewの作成
                Int32 acptAnOdrStatus = 30;   //10:見積,20:受注,30:売上,40:出荷（受注ステータス）

                string rowFilterText = string.Format("{0} = {1}",
                                                        SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus);
                string sortText = string.Format("{0}, {1}",
                                                SalesSlipSchema.ct_Col_AcptAnOdrStatus,
                                                SalesSlipSchema.ct_Col_SalesSlipNum);
                DataView viewSalesSlip = new DataView(SalesSlipTable);
                viewSalesSlip.Sort = sortText;
                viewSalesSlip.RowFilter = rowFilterText;

                if (viewSalesSlip == null) return (status);
                if (viewSalesSlip.Count == 0) return (status);
                # endregion

                foreach (DataRowView rowUoeSalesSlip in viewSalesSlip)
                {
                    //------------------------------------------------------
                    // 売上データ合計金額設定処理
                    //------------------------------------------------------
                    # region 合計金額設定処理
                    //売上データクラスの取得
                    SalesSlipWork salesSlipWork = _uoeSndRcvJnlAcs.CreateSalesSlipWorkFromSchema(rowUoeSalesSlip.Row);

                    //------------------------------------------------------
                    // 売上明細データに行番号を設定
                    //------------------------------------------------------
                    string tempSalesSlipNum = (string)rowUoeSalesSlip[SalesSlipSchema.ct_Col_TempSalesSlipNum];
                    _uoeSndRcvJnlAcs.SetRowNoFromSalesDetail(
                                                    salesSlipWork.AcptAnOdrStatus,
                                                    tempSalesSlipNum,
                                                    1,
                                                    out message
                                                    );

                    //------------------------------------------------------
                    // 売上明細クラスの取得
                    //------------------------------------------------------
                    List<UoeSalesDetail> uoeSalesDetailList = _uoeSndRcvJnlAcs.SearchUoeSalesDetailDataTable(
                                                    SalesDetailTable,
                                                    salesSlipWork.AcptAnOdrStatus,
                                                    tempSalesSlipNum,
                                                    (int)PrtSalesDetail.ctDetailCd.ct_Normal
                                                    );
                    if (uoeSalesDetailList == null) continue;
                    if (uoeSalesDetailList.Count == 0) continue;


                    List<SalesDetailWork> salesDetailList = new List<SalesDetailWork>();

                    foreach (UoeSalesDetail uoeSalesDetail in uoeSalesDetailList)
                    {
                        salesDetailList.Add(uoeSalesDetail.salesDetailWork);
                    }

                    TotalPriceSetting(ref salesSlipWork, salesDetailList);
                    # endregion

                    //------------------------------------------------------
                    // 売上データ設定処理
                    //------------------------------------------------------
                    # region 売上データ設定処理
                    _uoeSndRcvJnlAcs.UpdateTableFromSalesSlipWork(SalesSlipTable, salesSlipWork, tempSalesSlipNum, out message);

                    # endregion
                }

            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region 売上データ合計金額設定処理
        /// <summary>
        /// 合計金額設定処理
        /// </summary>
        /// <param name="salesSlip">売上データオブジェクト</param>
        /// <param name="salesDetailList">売上明細データリスト</param>
        private void TotalPriceSetting(ref SalesSlipWork salesSlip, List<SalesDetailWork> salesDetailList)
        {
            if (salesSlip == null) return;
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// 消費税端数処理コード

            long salesTotalTaxInc = 0;      // 売上伝票合計（税込）
            long salesTotalTaxExc = 0;      // 売上伝票合計（税抜）
            long salesSubtotalTax = 0;      // 売上小計（税）
            long itdedSalesOutTax = 0;      // 売上外税対象額
            long itdedSalesInTax = 0;       // 売上内税対象額
            long salSubttlSubToTaxFre = 0;  // 売上小計非課税対象額
            long salesOutTax = 0;           // 売上金額消費税額（外税）
            long salAmntConsTaxInclu = 0;   // 売上金額消費税額（内税）
            long salesDisTtlTaxExc = 0;     // 売上値引金額計（税抜）
            long itdedSalesDisOutTax = 0;   // 売上値引外税対象額合計
            long itdedSalesDisInTax = 0;    // 売上値引内税対象額合計
            long itdedSalesDisTaxFre = 0;   // 売上値引非課税対象額合計
            long salesDisOutTax = 0;        // 売上値引消費税額（外税）
            long salesDisTtlTaxInclu = 0;   // 売上値引消費税額（内税）
            long totalCost = 0;             // 原価金額計
            long stockGoodsTtlTaxExc = 0;   // 在庫商品合計金額（税抜）
            long pureGoodsTtlTaxExc = 0;    // 純正商品合計金額（税抜）
            long taxAdjust = 0;             // 消費税調整額
            long balanceAdjust = 0;         // 残高調整額
            long salesPrtSubttlInc = 0;     // 売上部品小計（税込）
            long salesPrtSubttlExc = 0;     // 売上部品小計（税抜）
            long salesWorkSubttlInc = 0;    // 売上作業小計（税込）
            long salesWorkSubttlExc = 0;    // 売上作業小計（税抜）
            long itdedPartsDisInTax = 0;    // 部品値引対象額合計（税込）
            long itdedPartsDisOutTax = 0;   // 部品値引対象額合計（税抜）
            long itdedWorkDisInTax = 0;     // 作業値引対象額合計（税込）
            long itdedWorkDisOutTax = 0;    // 作業値引対象額合計（税抜）
            long totalMoneyForGrossProfit = 0; // 粗利計算用売上金額

            this.CalculationSalesTotalPrice(
                salesDetailList,
                salesSlip.ConsTaxRate,
                salesTaxFrcProcCd,
                salesSlip.TotalAmountDispWayCd,
                salesSlip.ConsTaxLayMethod,
                out salesTotalTaxInc,
                out salesTotalTaxExc,
                out salesSubtotalTax,
                out itdedSalesOutTax,
                out itdedSalesInTax,
                out salSubttlSubToTaxFre,
                out salesOutTax,
                out salAmntConsTaxInclu,
                out salesDisTtlTaxExc,
                out itdedSalesDisOutTax,
                out itdedSalesDisInTax,
                out itdedSalesDisTaxFre,
                out salesDisOutTax,
                out salesDisTtlTaxInclu,
                out totalCost,
                out stockGoodsTtlTaxExc,
                out pureGoodsTtlTaxExc,
                out balanceAdjust,
                out taxAdjust,
                out salesPrtSubttlInc,
                out salesPrtSubttlExc,
                out salesWorkSubttlInc,
                out salesWorkSubttlExc,
                out itdedPartsDisInTax,
                out itdedPartsDisOutTax,
                out itdedWorkDisInTax,
                out itdedWorkDisOutTax,
                out totalMoneyForGrossProfit);


            salesSlip.SalesSubtotalTaxInc = salesTotalTaxInc;       // 売上小計（税込）
            salesSlip.SalesSubtotalTaxExc = salesTotalTaxExc;       // 売上小計（税抜）
            salesSlip.SalesSubtotalTax = salesSubtotalTax;          // 売上小計（税）
            salesSlip.ItdedSalesOutTax = itdedSalesOutTax;          // 売上外税対象額
            salesSlip.ItdedSalesInTax = itdedSalesInTax;            // 売上内税対象額
            salesSlip.SalSubttlSubToTaxFre = salSubttlSubToTaxFre;  // 売上小計非課税対象額
            salesSlip.SalesOutTax = salesOutTax;                    // 売上金額消費税額（外税）
            salesSlip.SalAmntConsTaxInclu = salAmntConsTaxInclu;    // 売上金額消費税額（内税）
            salesSlip.SalesDisTtlTaxExc = salesDisTtlTaxExc;        // 売上値引金額計（税抜）
            salesSlip.ItdedSalesDisOutTax = itdedSalesDisOutTax;    // 売上値引外税対象額合計
            salesSlip.ItdedSalesDisInTax = itdedSalesDisInTax;      // 売上値引内税対象額合計
            salesSlip.ItdedSalesDisTaxFre = itdedSalesDisTaxFre;    // 売上値引非課税対象額合計
            salesSlip.SalesDisOutTax = salesDisOutTax;              // 売上値引消費税額（外税）
            salesSlip.SalesDisTtlTaxInclu = salesDisTtlTaxInclu;    // 売上値引消費税額（内税）
            salesSlip.TotalCost = totalCost;                        // 原価金額計
            salesSlip.StockGoodsTtlTaxExc = stockGoodsTtlTaxExc;    // 在庫商品合計金額（税抜）
            salesSlip.PureGoodsTtlTaxExc = pureGoodsTtlTaxExc;      // 純正商品合計金額（税抜）
            salesSlip.SalesPrtSubttlInc = salesPrtSubttlInc;                // 売上部品小計（税込）
            salesSlip.SalesPrtSubttlExc = salesPrtSubttlExc;                // 売上部品小計（税抜）
            salesSlip.SalesWorkSubttlInc = salesWorkSubttlInc;              // 売上作業小計（税込）
            salesSlip.SalesWorkSubttlExc = salesWorkSubttlExc;              // 売上作業小計（税抜）
            salesSlip.ItdedPartsDisInTax = itdedPartsDisInTax;              // 部品値引対象額合計（税込）
            salesSlip.ItdedPartsDisOutTax = itdedPartsDisOutTax;            // 部品値引対象額合計（税抜）
            salesSlip.ItdedWorkDisInTax = itdedWorkDisInTax;                // 作業値引対象額合計（税込）
            salesSlip.ItdedWorkDisOutTax = itdedWorkDisOutTax;              // 作業値引対象額合計（税抜）
            //salesSlip.TotalMoneyForGrossProfit = totalMoneyForGrossProfit; // 粗利計算用売上金額

            salesSlip.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;                   // 売上伝票合計（税込）= 売上伝票合計（税込） + 売上小計非課税対象額
            salesSlip.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;                   // 売上伝票合計（税抜）= 売上伝票合計（税抜） + 売上小計非課税対象額
            salesSlip.SalesNetPrice = itdedSalesOutTax + itdedSalesInTax + salSubttlSubToTaxFre;    // 売上正価金額 = 売上外税対象額 + 売上内税対象額 + 売上小計非課税対象額
            salesSlip.AccRecConsTax = salesSubtotalTax;                                             // 売掛消費税
            salesSlip.SalesPrtTotalTaxInc = salesPrtSubttlInc + itdedPartsDisInTax;                 // 売上部品合計（税込）
            salesSlip.SalesPrtTotalTaxExc = salesPrtSubttlExc + itdedPartsDisOutTax;                // 売上部品合計（税抜）
            salesSlip.SalesWorkTotalTaxInc = salesWorkSubttlInc + itdedWorkDisInTax;                // 売上作業合計（税込）
            salesSlip.SalesWorkTotalTaxExc = salesWorkSubttlExc + itdedWorkDisOutTax;               // 売上作業合計（税抜）
        }

        /// <summary>
        /// 売上金額の合計を計算します。
        /// </summary>
        /// <param name="salesDetailList">売上明細データリスト</param>
        /// <param name="pureGoodsTtlTaxExc">純正商品合計金額(税抜)</param>
        /// <param name="stockGoodsTtlTaxExc">在庫商品合計金額(税抜)</param>
        /// <param name="consTaxRate">消費税税率</param>
        /// <param name="salesTaxFrcProcCd">消費税端数処理コード</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式</param>
        /// <param name="salesTotalTaxInc">売上伝票合計（税込）</param>
        /// <param name="salesTotalTaxExc">売上伝票合計（税抜）</param>
        /// <param name="salesSubtotalTax">売上小計（税）</param>
        /// <param name="itdedSalesOutTax">売上外税対象額</param>
        /// <param name="itdedSalesInTax">売上内税対象額</param>
        /// <param name="salSubttlSubToTaxFre">売上小計非課税対象額</param>
        /// <param name="salesOutTax">売上金額消費税額（外税）</param>
        /// <param name="salAmntConsTaxInclu">売上金額消費税額（内税）</param>
        /// <param name="salesDisTtlTaxExc">売上値引金額計（税抜）</param>
        /// <param name="itdedSalesDisOutTax">売上値引外税対象額合計</param>
        /// <param name="itdedSalesDisInTax">売上値引内税対象額合計</param>
        /// <param name="itdedSalesDisTaxFre">売上値引非課税対象額合計</param>
        /// <param name="salesDisOutTax">売上値引消費税額（外税）</param>
        /// <param name="salesDisTtlTaxInclu">売上値引消費税額（内税）</param>
        /// <param name="totalCost">原価金額計</param>
        /// <param name="balanceAdjust">消費税調整額</param>
        /// <param name="taxAdjust">残高調整額</param>
        /// <param name="salesPrtSubttlInc">売上部品小計（税込）</param>
        /// <param name="salesPrtSubttlExc">売上部品小計（税抜）</param>
        /// <param name="salesWorkSubttlInc">売上作業小計（税込）</param>
        /// <param name="salesWorkSubttlExc">売上作業小計（税抜）</param>
        /// <param name="itdedPartsDisInTax">部品値引対象額合計（税込）</param>
        /// <param name="itdedPartsDisOutTax">部品値引対象額合計（税抜）</param>
        /// <param name="itdedWorkDisInTax">作業値引対象額合計（税込）</param>
        /// <param name="itdedWorkDisOutTax">作業値引対象額合計（税抜）</param>
        /// <param name="totalMoneyForGrossProfit">粗利計算用売上金額</param>
        private void CalculationSalesTotalPrice(List<SalesDetailWork> salesDetailList, double consTaxRate, int salesTaxFrcProcCd, int totalAmountDispWayCd, int consTaxLayMethod, out long salesTotalTaxInc, out long salesTotalTaxExc, out long salesSubtotalTax, out long itdedSalesOutTax, out long itdedSalesInTax, out long salSubttlSubToTaxFre, out long salesOutTax, out long salAmntConsTaxInclu, out long salesDisTtlTaxExc, out long itdedSalesDisOutTax, out long itdedSalesDisInTax, out long itdedSalesDisTaxFre, out long salesDisOutTax, out long salesDisTtlTaxInclu, out long totalCost, out long stockGoodsTtlTaxExc, out long pureGoodsTtlTaxExc, out long balanceAdjust, out long taxAdjust, out long salesPrtSubttlInc, out long salesPrtSubttlExc, out long salesWorkSubttlInc, out long salesWorkSubttlExc, out long itdedPartsDisInTax, out long itdedPartsDisOutTax, out long itdedWorkDisInTax, out long itdedWorkDisOutTax, out long totalMoneyForGrossProfit)
        {
            // 消費税端数処理単位、端数処理区分を取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            //this.GetFractionProcInfo(ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            salesTotalTaxInc = 0;       // 売上伝票合計（税込）
            salesTotalTaxExc = 0;       // 売上伝票合計（税抜）
            salesSubtotalTax = 0;       // 売上小計（税）
            itdedSalesOutTax = 0;       // 売上外税対象額
            itdedSalesInTax = 0;        // 売上内税対象額
            salSubttlSubToTaxFre = 0;   // 売上小計非課税対象額
            salesOutTax = 0;            // 売上金額消費税額（外税）
            salAmntConsTaxInclu = 0;    // 売上金額消費税額（内税）
            salesDisTtlTaxExc = 0;      // 売上値引金額計（税抜）
            itdedSalesDisOutTax = 0;    // 売上値引外税対象額合計
            itdedSalesDisInTax = 0;     // 売上値引内税対象額合計
            itdedSalesDisTaxFre = 0;    // 売上値引非課税対象額合計
            salesDisOutTax = 0;         // 売上値引消費税額（外税）
            salesDisTtlTaxInclu = 0;    // 売上値引消費税額（内税）
            stockGoodsTtlTaxExc = 0;    // 在庫商品合計金額（税抜）
            pureGoodsTtlTaxExc = 0;     // 純正商品合計金額（税抜）
            totalCost = 0;              // 原価金額計
            taxAdjust = 0;              // 消費税調整額
            balanceAdjust = 0;          // 残高調整額
            salesPrtSubttlInc = 0;      // 売上部品小計（税込）
            salesPrtSubttlExc = 0;      // 売上部品小計（税抜）
            salesWorkSubttlInc = 0;     // 売上作業小計（税込）
            salesWorkSubttlExc = 0;     // 売上作業小計（税抜）
            itdedPartsDisInTax = 0;     // 部品値引対象額合計（税込）
            itdedPartsDisOutTax = 0;    // 部品値引対象額合計（税抜）
            itdedWorkDisInTax = 0;      // 作業値引対象額合計（税込）
            itdedWorkDisOutTax = 0;     // 作業値引対象額合計（税抜）
            totalMoneyForGrossProfit = 0; // 粗利計算用売上金額

            long itdedSalesInTax_TaxInc = 0;    // 売上内税対象額（税込）
            long itdedSalesDisInTax_TaxInc = 0; // 売上値引内税対象額合計（税込）
            long totalMoney_TaxInc_ForGrossProfitMoney = 0;     // 粗利計算用売上金額計（内税商品分）
            long totalMoney_TaxExc_ForGrossProfitMoney = 0;     // 粗利計算用売上金額計（外税商品分）
            long totalMoney_TaxNone_ForGrossProfitMoney = 0;    // 粗利計算用売上金額計（非課税商品分）
            long stockGoodsTtlTaxExc_TaxInc = 0;                // 在庫商品合計金額（税抜）（内税商品分）
            long stockGoodsTtlTaxExc_TaxExc = 0;                // 在庫商品合計金額（税抜）（外税商品分）
            long stockGoodsTtlTaxExc_TaxNone = 0;               // 在庫商品合計金額（税抜）（非課税商品分）
            long pureGoodsTtlTaxExc_TaxInc = 0;                 // 純正商品合計金額（税抜）（内税商品分）
            long pureGoodsTtlTaxExc_TaxExc = 0;                 // 純正商品合計金額（税抜）（外税商品分）
            long pureGoodsTtlTaxExc_TaxNone = 0;                // 純正商品合計金額（税抜）（非課税商品分）

            //-----------------------------------------------------------------------------
            // 計算に必要な金額の計算
            //-----------------------------------------------------------------------------
            #region ●計算に必要な金額の計算

            foreach (SalesDetailWork salesDetail in salesDetailList)
            {
                // 売上伝票区分（明細）によって集計方法が変わる分
                switch (salesDetail.SalesSlipCdDtl)
                {
                    // 売上、返品
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales:
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods:
                        {
                            // 税区分：外税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // 売上外税対象額
                                itdedSalesOutTax += salesDetail.SalesMoneyTaxExc;

                                // 売上金額消費税額（外税）
                                salesOutTax += salesDetail.SalesPriceConsTax;

                                // 在庫商品合計金額（税抜）（外税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（外税商品分）
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                            }
                            // 税区分：内税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // 売上内税対象額
                                itdedSalesInTax += salesDetail.SalesMoneyTaxExc;

                                // 売上内税対象額（税込）
                                itdedSalesInTax_TaxInc += salesDetail.SalesMoneyTaxInc;

                                // 売上金額消費税額（内税）
                                salAmntConsTaxInclu += salesDetail.SalesPriceConsTax;

                                // 在庫商品合計金額（税抜）（内税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（内税商品分）
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                            }
                            // 税区分：非課税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // 売上小計非課税対象額
                                salSubttlSubToTaxFre += salesDetail.SalesMoneyTaxInc;

                                // 在庫商品合計金額（税抜）（非課税商品分）
                                if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                    stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                // 純正商品合計金額（税抜）（非課税商品分）
                                if (salesDetail.GoodsKindCode == 0)
                                    pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;
                            }

                            // 売上部品小計（税込）
                            salesPrtSubttlInc += salesDetail.SalesMoneyTaxInc;
                            // 売上部品小計（税抜）
                            salesPrtSubttlExc += salesDetail.SalesMoneyTaxExc;

                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // 値引き
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount:
                        {
                            // 税区分：外税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                // 売上値引外税対象額合計
                                itdedSalesDisOutTax += salesDetail.SalesMoneyTaxExc;
                                // 売上値引消費税額（外税）
                                salesDisOutTax += salesDetail.SalesPriceConsTax;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（外税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（外税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxExc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // 税区分：内税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                // 売上値引内税対象額合計
                                itdedSalesDisInTax += salesDetail.SalesMoneyTaxExc;
                                // 売上値引内税対象額合計（税込）
                                itdedSalesDisInTax_TaxInc += salesDetail.SalesMoneyTaxInc;
                                // 売上値引消費税額（内税）
                                salesDisTtlTaxInclu += salesDetail.SalesPriceConsTax;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（内税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（内税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxInc += salesDetail.SalesMoneyTaxExc;
                                }
                            }
                            // 税区分：非課税
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                // 売上値引非課税対象額合計
                                itdedSalesDisTaxFre += salesDetail.SalesMoneyTaxInc;

                                // 商品値引きの場合
                                if (salesDetail.ShipmentCnt != 0)
                                {
                                    // 在庫商品合計金額（税抜）（非課税商品分）
                                    if (salesDetail.SalesOrderDivCd == (int)SalesSlipInputAcs.SalesOrderDivCd.Stock)
                                        stockGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                    // 純正商品合計金額（税抜）（非課税商品分）
                                    if (salesDetail.GoodsKindCode == 0)
                                        pureGoodsTtlTaxExc_TaxNone += salesDetail.SalesMoneyTaxExc;

                                }
                            }

                            // 部品値引対象額合計（税込）
                            itdedPartsDisInTax += salesDetail.SalesMoneyTaxInc;

                            // 部品値引対象額合計（税抜）
                            itdedPartsDisOutTax += salesDetail.SalesMoneyTaxExc;

                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            break;
                        }
                    // 注釈
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Annotation:
                        {
                            break;
                        }
                    // 作業
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Work:
                        {
                            // 原価金額計
                            totalCost += salesDetail.Cost;

                            // 粗利計算用売上金額計（内税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                            {
                                totalMoney_TaxInc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxInc;
                            }

                            // 粗利計算用売上金額計（外税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                            {
                                totalMoney_TaxExc_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }

                            // 粗利計算用売上金額計（非課税商品分）
                            if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
                            {
                                totalMoney_TaxNone_ForGrossProfitMoney += salesDetail.SalesMoneyTaxExc;
                            }
                            break;
                        }
                    // 小計
                    case (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal:
                        {
                            break;
                        }
                }

                if (salesDetail.SalesSlipCdDtl != (int)SalesSlipInputAcs.SalesSlipCdDtl.Subtotal)
                {
                    // 残高調整額
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.BalanceAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecBalanceAdjust))
                    {
                        balanceAdjust += salesDetail.SalesMoneyTaxInc;
                    }

                    // 消費税調整額
                    if ((salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.ConsTaxAdjust) ||
                        (salesDetail.SalesGoodsCd == (int)SalesSlipInputAcs.SalesGoodsCd.AccRecConsTaxAdjust))
                    {
                        taxAdjust += salesDetail.SalesPriceConsTax;
                    }
                }

            }

            // 売上値引金額計（税抜）
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // 粗利計算用売上金額計
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // 在庫商品合計金額（税抜）
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone;

            // 純正商品合計金額（税抜）
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone;

            #endregion

            #region ●転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            // 転嫁方式：非課税の場合に金額を調整する
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == 9)
            {
                // 売上金額消費税額（外税）
                salesOutTax = 0;

                // 売上金額消費税額（内税）
                salAmntConsTaxInclu = 0;

                // 売上小計非課税対象額
                salSubttlSubToTaxFre += itdedSalesOutTax + itdedSalesInTax;

                // 売上外税対象額
                itdedSalesOutTax = 0;

                // 売上内税対象額
                itdedSalesInTax = 0;

                // 売上内税対象額（税込）
                itdedSalesInTax_TaxInc = 0;

                // 売上値引消費税額（外税）
                salesDisOutTax = 0;

                // 売上値引消費税額（内税）
                salesDisTtlTaxInclu = 0;

                // 売上値引非課税対象額合計
                itdedSalesDisTaxFre += itdedSalesDisOutTax + itdedSalesDisInTax;

                // 売上値引外税対象額合計
                itdedSalesDisOutTax = 0;

                // 売上値引内税対象額合計
                itdedSalesDisInTax = 0;

                // 売上値引内税対象額合計（税込）
                itdedSalesDisInTax_TaxInc = 0;

                // 売上値引金額計（税抜）
                salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;
            }
            #endregion

            #region ●各種金額算出
            //-----------------------------------------------------------------------------
            // 各種金額算出
            //-----------------------------------------------------------------------------

            // 明細転嫁以外
            if (consTaxLayMethod != 1)
            {
                //-----------------------------------------------------------------------------
                // ① 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計 + 売上値引非課税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税込）： 売上内税対象額（税込） + 売上外税対象額 + 売上値引内税対象額合計（税込） + 売上値引外税対象額合計 + 売上値引非課税対象額合計 + (売上外税対象額 + 売上値引外税対象額合計)×税率)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ③ 売上小計（税）：② - ①
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // ④ 売上金額消費税額（外税）：売上外税対象額 × 税率
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // ⑤ 売上金額消費税額（外税）(税抜、値引き含む) ：(売上外税対象額 + 売上値引外税対象額合計) × 税率
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // ⑥ 売上値引消費税額（外税）：④ - ⑤
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;
            }
            // 明細転嫁
            else
            {
                //-----------------------------------------------------------------------------
                // ① 売上小計（税）：売上金額消費税額（外税） + 売上金額消費税額（内税） +  売上値引消費税額（外税） + 売上値引消費税額（内税）
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

                //-----------------------------------------------------------------------------
                // ② 売上伝票合計（税抜）：売上外税対象額 + 売上内税対象額 + 売上値引外税対象額合計 + 売上値引内税対象額合計
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax;

                //-----------------------------------------------------------------------------
                // ③ 売上伝票合計（税込）：① + ②
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }
            #endregion
        }
        # endregion

        # region 端数処理単位、端数処理区分取得処理
        /// <summary>
        /// 端数処理単位、端数処理区分取得処理
        /// </summary>
        /// <param name="fracProcMoneyDiv">端数処理対象金額区分</param>
        /// <param name="fractionProcCode">端数処理コード</param>
        /// <param name="targetPrice">対象金額</param>
        /// <param name="fractionProcUnit">端数処理単位</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        public void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
        {
            //-----------------------------------------------------------------------------
            // 初期値
            //-----------------------------------------------------------------------------
            switch (fracProcMoneyDiv)
            {
                case ctFracProcMoneyDiv_SalesUnitPrice: // 単価は0.01円単位
                    fractionProcUnit = 0.01;
                    break;
                default:
                    fractionProcUnit = 1;               // 単価以外は1円単位
                    break;
            }
            fractionProcCd = 1;     // 切捨て

            //-----------------------------------------------------------------------------
            // コード該当レコード取得
            //-----------------------------------------------------------------------------
            List<SalesProcMoney> salesProcMoneyList = this._salesProcMoneyList.FindAll(
                delegate(SalesProcMoney sProcMoney)
                {
                    if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                        (sProcMoney.FractionProcCode == fractionProcCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // ソート（上限金額（昇順））
            //-----------------------------------------------------------------------------
            salesProcMoneyList.Sort(new SalesProcMoneyComparer());

            //-----------------------------------------------------------------------------
            // 上限金額該当レコード取得
            //-----------------------------------------------------------------------------
            SalesProcMoney salesProcMoney = salesProcMoneyList.Find(
                delegate(SalesProcMoney spm)
                {
                    if (spm.UpperLimitPrice >= targetPrice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            //-----------------------------------------------------------------------------
            // 戻り値設定
            //-----------------------------------------------------------------------------
            if (salesProcMoney != null)
            {
                fractionProcUnit = salesProcMoney.FractionProcUnit;
                fractionProcCd = salesProcMoney.FractionProcCd;
            }
        }

        /// <summary>
        /// 売上金額処理区分マスタ比較クラス(上限金額(降順))
        /// </summary>
        private class SalesProcMoneyComparer : Comparer<SalesProcMoney>
        {
            public override int Compare(SalesProcMoney x, SalesProcMoney y)
            {
                int result = y.UpperLimitPrice.CompareTo(x.UpperLimitPrice);
                return result;
            }
        }

        /// <summary>
        /// 売上金額処理区分設定マスタキャッシュ処理
        /// </summary>
        private void CacheSalesProcMoney()
        {
            _salesProcMoneyList = null;
            ArrayList al = null;
            int status = this._salesProcMoneyAcs.Search(out al, _enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (al != null)
                {
                    _salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])al.ToArray(typeof(SalesProcMoney)));
                }
            }
        }

        /// <summary>
        /// 売上金額を計算します。（明細部金額）（オーバーロード）
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailRow"></param>
        /// <param name="salesMoneyTaxInc"></param>
        /// <param name="salesMoneyTaxExc"></param>
        /// <param name="salesMoneyDisplay"></param>
        /// <returns></returns>
        public bool CalculationSalesMoney(SalesSlipWork salesSlip, SalesDetailWork salesDetail, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out long salesMoneyDisplay, out int fractionProcCd)
        {
            fractionProcCd = -1;

            // 売上金額を算定
            double taxRate = salesSlip.ConsTaxRate;

            // 売上金額端数処理コード(得意先マスタより取得)
            int salesMoneyFrcProcCode = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            salesSlip.FractionProcCd = taxFracProcCd;

            // 課税区分
            int taxationCode = salesDetail.TaxationDivCd;

            double salesUnPrc = 0;// 売上単価(税抜)
            if ((salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) || // 内税
                (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)) // 総額表示する(総額表示する場合、内税計算を行う)
            {
                // 内税
                salesUnPrc = salesDetail.SalesUnPrcTaxIncFl;
            }
            else
            {
                // 外税/非課税
                salesUnPrc = salesDetail.SalesUnPrcTaxExcFl;
            }

            // 非課税
            if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // 総額表示時は内税で計算する
            else if (salesSlip.TotalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.TotalAmount)
            {
                // 総額表示する
                if (salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                }
            }
            bool ret = true;
            if (((salesDetail.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount) && (salesDetail.ShipmentCnt == 0))) // 行値引き
            {
                salesMoneyTaxInc = salesDetail.SalesMoneyTaxInc;
                salesMoneyTaxExc = salesDetail.SalesMoneyTaxExc;
            }
            else
            {
                ret = this.CalculationSalesMoney(
                    salesSlip,
                    salesDetail.ShipmentCnt,
                    salesUnPrc,
                    taxationCode,
                    taxRate,
                    salesMoneyFrcProcCode,
                    salesCnsTaxFrcProcCd,
                    out salesMoneyTaxInc,
                    out salesMoneyTaxExc,
                    out fractionProcCd);
            }

            if ((salesDetail.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) ||
                (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
            {
                salesMoneyDisplay = salesMoneyTaxInc; // 表示金額→税込
            }
            else
            {
                salesMoneyDisplay = salesMoneyTaxExc; // 表示金額→税抜
            }

            return ret;
        }

        /// <summary>
        /// 売上金額を計算します。
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="shipmentCnt">数量</param>
        /// <param name="salesUnPrcTaxExcFl">売単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="salesMoneyFrcProcCd">売上端数処理区分(数量*単価に使用)</param>
        /// <param name="taxFrac">消費税端数処理区分</param>
        /// <param name="salesMoneyTaxInc">売上金額（税込み）</param>
        /// <param name="salesMoneyTaxExc">売上金額（税抜き）</param>
        /// <returns>true:算定完了 false:算定失敗</returns>
        /// <remarks>
        /// <br>Call：商品検索／定価／売単価／売価率／原単価／原価率／売上金額 変更時</br>
        /// </remarks>
        private bool CalculationSalesMoney(SalesSlipWork salesSlip, double shipmentCnt, double salesUnPrcTaxExcFl, int taxationCode, double taxRate, int salesMoneyFrcProcCd, int taxFrac, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out int fractionProcCd)
        {
            fractionProcCd = -1;

            salesMoneyTaxInc = 0;
            salesMoneyTaxExc = 0;

            double unitPriceExc = 0;    // 単価（税抜き）
            double unitPriceInc = 0;	// 単価（税込み）
            double unitPriceTax = 0;	// 単価（消費税）
            long priceExc = 0;			// 価格（税抜き）
            long priceInc = 0;			// 価格（税込み）
            long priceTax = 0;			// 価格（消費税）

            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;

            // 出荷数が0または売上単価が0の場合はすべて0で終了
            if ((shipmentCnt == 0) || (salesUnPrcTaxExcFl == 0)) return true;

            switch ((CalculateTax.TaxationCode)taxationCode)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // 外税
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    salesMoneyTaxInc = priceInc;		        // 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		        // 売上金額（税抜き）		
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // 内税
                    //---------------------------------
                    unitPriceInc = salesUnPrcTaxExcFl;	// 単価（税込み）
                    priceInc = 0;					        // 価格（税込み）

                    this._salesPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    salesMoneyTaxInc = priceInc;		        // 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		        // 売上金額（税抜き）
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // 非課税
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    salesMoneyTaxInc = priceExc;		// 売上金額（税込み）
                    salesMoneyTaxExc = priceExc;		// 売上金額（税込み）
                    break;
            }

            fractionProcCd = taxFracProcCd;
            return true;
        }

        # endregion

        # region 売上データの設定
        /// <summary>
        /// 売上データの設定
        /// </summary>
        /// <param name="jnl">送受信JNLクラス</param>
        /// <param name="tempSalesSlipNum">売上伝票番号（仮）</param>
        /// <param name="prtShipmentCnt">出庫数加算</param>
        /// <param name="slipCd">UOE伝票種別</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int WriteDtTblSalesSlip(OrderSndRcvJnl jnl, string tempSalesSlipNum, Int32 prtShipmentCnt, Int32 slipCd, out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //------------------------------------------------------
                // 売上データの取得
                //------------------------------------------------------
                #region 売上データの取得
                Int32 acptAnOdrStatus = 30;
                DataRow salesSlipDr = _uoeSndRcvJnlAcs.ReadSalesSlipDataTable(acptAnOdrStatus, tempSalesSlipNum);

                //売上データ更新処理
                if (salesSlipDr != null)
                {
                    //出庫数合計
                    salesSlipDr[SalesSlipSchema.ct_Col_TotalCnt] = (Int32)salesSlipDr[SalesSlipSchema.ct_Col_TotalCnt] + prtShipmentCnt;
                    
                    //明細行数
                    salesSlipDr[SalesSlipSchema.ct_Col_DetailRowCount] = (Int32)salesSlipDr[SalesSlipSchema.ct_Col_DetailRowCount] + 1;

                    return(status);
                }
                #endregion

                //------------------------------------------------------
                // 受注データの取得
                //------------------------------------------------------
                #region 受注データの取得
                status = (int)EnumUoeConst.Status.ct_NORMAL;
                acptAnOdrStatus = 20;
                SalesSlipWork salesSlipWork = _uoeSndRcvJnlAcs.ReadAcptSlipDataTable(acptAnOdrStatus, jnl.SalesSlipNum);
                #endregion

                //------------------------------------------------------
                // 売上データの設定
                //------------------------------------------------------
                #region 売上データの設定
                //ヘッダー項目初期化
                salesSlipWork.CreateDateTime = DateTime.MinValue;
                salesSlipWork.UpdateDateTime = DateTime.MinValue;
                salesSlipWork.FileHeaderGuid = Guid.Empty;
                salesSlipWork.UpdEmployeeCode = "";
                salesSlipWork.UpdAssemblyId1 = "";
                salesSlipWork.UpdAssemblyId2 = "";
                salesSlipWork.LogicalDeleteCode = 0;

                salesSlipWork.AcptAnOdrStatus = 30;                 //受注ステータス
                salesSlipWork.SalesSlipNum = String.Empty;          //売上伝票番号
                salesSlipWork.DetailRowCount = 1;                   //明細行数

                //売上日付
                //UOE自社設定ﾏｽﾀの計上日付区分:システム日付
                if (_uoeSndRcvJnlAcs.uOESetting.AddUpADateDiv == (int)EnumUoeConst.ctAddUpADateDiv.ct_System)
                {
                    salesSlipWork.SalesDate = DateTime.Now;
                }
                //UOE自社設定ﾏｽﾀの計上日付区分:売上日付
                else
                {
                    salesSlipWork.SalesDate = jnl.SalesDate;
                }

                // --------- ADD 譚洪 2013/12/16 -------------- >>>>>>>
                //仕入先消費税税率
                salesSlipWork.ConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(salesSlipWork.SalesDate);
                // --------- ADD 譚洪 2013/12/16 -------------- <<<<<<<

                //請求先コードにて売上月次及び売上締次の締日チェック処理
                //売上締次の締日取得処理
                if ((salesSlipWork.ResultsAddUpSecCd.Trim() != "") && (salesSlipWork.ClaimCode != 0))
                {
                    if (_totalDayCalculator.CheckDmdC(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, salesSlipWork.SalesDate) != false)
                    {
                        DateTime prevTotalDay = DateTime.MinValue;
                        DateTime currentTotalDay = DateTime.MinValue;

                        if (_totalDayCalculator.GetTotalDayDmdC(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, out prevTotalDay, out currentTotalDay) == 0)
                        {
                            DateTime setDateTime = prevTotalDay.AddDays(1);
                            salesSlipWork.SalesDate = setDateTime;
                        }
                    }

                    //売上月次の締日取得処理
                    if (_totalDayCalculator.CheckMonthlyAccRec(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, salesSlipWork.SalesDate) != false)
                    {
                        DateTime prevTotalDay = DateTime.MinValue;
                        DateTime currentTotalDay = DateTime.MinValue;

                        if (_totalDayCalculator.GetTotalDayMonthlyAccRec(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, out prevTotalDay, out currentTotalDay) == 0)
                        {
                            DateTime setDateTime = prevTotalDay.AddDays(1);
                            salesSlipWork.SalesDate = setDateTime;
                        }
                    }
                }

                //計上日付
                salesSlipWork.AddUpADate = salesSlipWork.SalesDate;

                //リマーク
                salesSlipWork.UoeRemark1 = jnl.UoeRemark1;
                salesSlipWork.UoeRemark2 = jnl.UoeRemark2;
                #endregion

                //------------------------------------------------------
                // 売上データの追加処理
                //------------------------------------------------------
                #region 売上データの追加処理
                status = _uoeSndRcvJnlAcs.InsertSalesSlipDataTable(salesSlipWork, tempSalesSlipNum, prtShipmentCnt, slipCd, out message);
                #endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }

        /// <summary>
        /// 指定した売単価の値を元に売上明細行オブジェクトの単価情報を設定します
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesUnitPriceInputType">売上単価入力モード</param>
        /// <param name="salesUnitPrice">売単価</param>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">受注明細データテーブルオブジェクト</param>
        public void SalesDetailRowSalesUnitPriceSetting(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, SalesUnitPriceInputType salesUnitPriceInputType, double salesUnitPrice)
        {

            #region ●初期処理
            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            salesSlip.FractionProcCd = taxFracProcCd;

            // 変更前情報保持
            double svUnitPriceTaxInc = salesDetailWork.SalesUnPrcTaxIncFl;
            double svUnitPriceTaxExc = salesDetailWork.SalesUnPrcTaxExcFl;
            #endregion

            #region ●売上情報
            if (salesDetailWork != null)
            {
                // 非課税
                int taxationDivCd = salesDetailWork.TaxationDivCd;
                if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

                switch (salesUnitPriceInputType)
                {
                    // 売単価(税抜き)--->>>売価率入力から総額表示しない時のみコール
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    //salesDetailWork.SalesUnPrcDisplay = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    //salesDetailWork.SalesUnPrcDisplay = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    //salesDetailWork.SalesUnPrcDisplay = salesUnitPrice; // 売単価(税抜)表示
                                    salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;// 売単価単価(税抜)
                                    salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;// 売単価単価(税込)
                                    break;
                            }
                            break;
                        }
                    // 売単価(税込み)--->>>売価率入力から総額表示する時のみコール
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                case CalculateTax.TaxationCode.TaxInc:
                                    //salesDetailWork.SalesUnPrcDisplay = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    //salesDetailWork.SalesUnPrcDisplay = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                            }
                            break;
                        }
                    // 売単価(表示用)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                            {
                                //-----------------------------------------------------
                                // 総額表示しない
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // 総額表示する
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        salesDetailWork.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        salesDetailWork.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                }
                            }
                            break;
                        }
                }

                // 売上単価変更区分設定
                if (salesDetailWork.SalesUnPrcTaxExcFl != salesDetailWork.BfSalesUnitPrice)
                {
                    salesDetailWork.SalesUnPrcChngCd = 1; // 変更あり
                }
                else
                {
                    salesDetailWork.SalesUnPrcChngCd = 0; // 変更なし
                }
            }
            #endregion

        }


        /// <summary>
        /// 掛率情報クリア処理
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        private void ClearRateInfo(ref SalesDetailWork salesDetailWork, string unitPriceKind)
        {
            // 定価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_ListPrice)
            {
                salesDetailWork.RateSectPriceUnPrc = string.Empty;
                salesDetailWork.RateDivLPrice = string.Empty;
                salesDetailWork.UnPrcCalcCdLPrice = 0;
                salesDetailWork.PriceCdLPrice = 0;
                salesDetailWork.StdUnPrcLPrice = 0;
                salesDetailWork.FracProcUnitLPrice = 0;
                salesDetailWork.FracProcLPrice = 0;

                salesDetailWork.BfListPrice = 0;
            }
            // 原価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
            {
                salesDetailWork.RateSectCstUnPrc = string.Empty;
                salesDetailWork.RateDivUnCst = string.Empty;
                salesDetailWork.UnPrcCalcCdUnCst = 0;
                salesDetailWork.PriceCdUnCst = 0;
                salesDetailWork.StdUnPrcUnCst = 0;
                salesDetailWork.FracProcUnitUnCst = 0;
                salesDetailWork.FracProcUnCst = 0;

                salesDetailWork.BfUnitCost = 0;
            }
            // 売価情報
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice)
            {
                salesDetailWork.RateSectSalUnPrc = string.Empty;
                salesDetailWork.RateDivSalUnPrc = string.Empty;
                salesDetailWork.UnPrcCalcCdSalUnPrc = 0;
                salesDetailWork.PriceCdSalUnPrc = 0;
                salesDetailWork.StdUnPrcSalUnPrc = 0;
                salesDetailWork.FracProcUnitSalUnPrc = 0;
                salesDetailWork.FracProcSalUnPrc = 0;

                salesDetailWork.BfSalesUnitPrice = 0;
            }
        }

        /// <summary>
        /// 指定した売価率の値を元に売上明細行オブジェクトの売単価情報を設定します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesRate">売価率</param>
        /// <param name="clearCalculateUnitInfoFlg">掛率算出情報クリアフラグ(true:クリアする false:クリアしない)</param>
        /// <remarks>
        /// <br>Call：定価／売価率 変更時</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitPriceSettingbyRate(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, double salesRate, bool clearCalculateUnitInfoFlg)
        {
            double salesUnPrcTaxExcFl;
            double salesUnPrcTaxIncFl;
            double salesUnPrcDisplay;

            #region ●売上情報
            if (salesDetailWork == null) return;

            salesDetailWork.SalesRate = salesRate;

            if (clearCalculateUnitInfoFlg == true)
            {
                // 掛率算出情報クリア
                this.ClearRateInfo(ref salesDetailWork, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
            }
            this.CalclateSalesUnitPrice(ref salesDetailWork, salesSlip, out salesUnPrcDisplay, out salesUnPrcTaxIncFl, out salesUnPrcTaxExcFl);

            salesDetailWork.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            salesDetailWork.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;
            #endregion
        }

        /// <summary>
        /// 売価率を使用して定価から売単価情報を算出します。
        /// </summary>
        /// <param name="row">売上明細行オブジェクト</param>
        /// <param name="unitPriceDisplay">売単価(表示)</param>
        /// <param name="unitPriceTaxInc">売単価(税込)</param>
        /// <param name="unitPriceTaxExc">売単価(税抜)</param>
        private void CalclateSalesUnitPrice(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, out double unitPriceDisplay, out double unitPriceTaxInc, out double unitPriceTaxExc)
        {
            unitPriceDisplay = 0;
            unitPriceTaxInc = 0;
            unitPriceTaxExc = 0;
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd); // 売上消費税端数処理コード
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            this.CalculateUnitPriceByRate(ref salesDetailWork, salesSlip, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);
        }
        #endregion

        /// <summary>
        /// 掛率を使用して単価を算出します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        private void CalculateUnitPriceByRate(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, UnitPriceCalculation.UnitPriceKind unitPriceKind, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            int frcProcCd = 0;          // 端数処理コード
            int fracProcDiv = 0;        // 端数処理区分
            double fracProcUnit = 0;    // 端数処理単位
            double rate = 0;            // 掛率
            double price = 0;           // 基準価格

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            salesSlip.FractionProcCd = taxFracProcCd;

            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                #region ●原単価
                //------------------------------------------------------
                // 原単価
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    //------------------------------------------------------
                    // 基準価格×掛率
                    //------------------------------------------------------
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdUnCst)
                    {
                        //------------------------------------------------------
                        // 基準価格×掛率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = salesDetailWork.FracProcUnitUnCst;
                            fracProcDiv = salesDetailWork.FracProcUnCst;
                            rate = salesDetailWork.CostRate;
                            price = salesDetailWork.StdUnPrcUnCst;
                            break;
                        default:
                            frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_SalesUnitCost, frcProcCd, 0, out fracProcUnit, out fracProcDiv);
                            rate = salesDetailWork.CostRate;
                            switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // 外税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                                //------------------------------------------------------
                                // 内税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = salesDetailWork.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // 非課税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion

                #region ●売単価
                //------------------------------------------------------
                // 売単価
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdSalUnPrc)
                    {
                        //------------------------------------------------------
                        // 基準価格×掛率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = salesDetailWork.FracProcUnitSalUnPrc;
                            fracProcDiv = salesDetailWork.FracProcSalUnPrc;
                            rate = salesDetailWork.SalesRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 原単価×原価ＵＰ率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = salesDetailWork.FracProcUnitSalUnPrc;
                            fracProcDiv = salesDetailWork.FracProcSalUnPrc;
                            //rate = salesDetailWork.CostUpRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 原単価×(１－粗利率)
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = salesDetailWork.FracProcUnitSalUnPrc;
                            fracProcDiv = salesDetailWork.FracProcSalUnPrc;
                            //rate = salesDetailWork.GrossProfitSecureRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 単価直接指定
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                            //    frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            //    fracProcUnit = row.FracProcUnitSalUnPrc;
                            //    fracProcDiv = row.FracProcSalUnPrc;
                            //    rate = 0;
                            //    price = 0;
                            //    break;
                            //default:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = salesDetailWork.FracProcUnitSalUnPrc;
                            fracProcDiv = salesDetailWork.FracProcSalUnPrc;
                            rate = salesDetailWork.SalesRate;
                            switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // 外税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                                //------------------------------------------------------
                                // 内税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = salesDetailWork.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // 非課税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion
            }

            // 非課税
            int taxationDivCd = salesDetailWork.TaxationDivCd;
            if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            int unPrcCalcCd = 0;
            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    unPrcCalcCd = salesDetailWork.UnPrcCalcCdUnCst;
                    break;
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    unPrcCalcCd = salesDetailWork.UnPrcCalcCdSalUnPrc;
                    break;
            }

            if (unPrcCalcCd != (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate)
            {
                this._unitPriceCalculation.CalculateUnitPriceByRate(unitPriceKind,
                                                                    (UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdSalUnPrc,
                                                                    salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }
            else
            {
                this._unitPriceCalculation.CalculateUnitPriceByMarginRate(unitPriceKind,
                    //(UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                    salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }
            if ((UnitPriceCalculation.UnitPriceKind)unitPriceKind != UnitPriceCalculation.UnitPriceKind.UnitCost)
            {
                // 「総額表示する」か、「内税商品」の場合は税込み単価を表示単価に設定
                if ((salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount) || (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc))
                {
                    unitPriceDisplay = unitPriceTaxInc;
                }
                else
                {
                    unitPriceDisplay = unitPriceTaxExc;
                }
            }
            else
            {
                if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    unitPriceDisplay = unitPriceTaxInc;
                }
                else
                {
                    unitPriceDisplay = unitPriceTaxExc;
                }
            }
        }


        /// <summary>
        /// 掛率を使用して単価を算出します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="fracProcDiv"></param>
        /// <param name="fracProcUnit"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        private void CalculateUnitPriceByRate(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, UnitPriceCalculation.UnitPriceKind unitPriceKind, ref int fracProcDiv, ref double fracProcUnit, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            int frcProcCd = 0;          // 端数処理コード
            double rate = 0;            // 掛率
            double price = 0;           // 基準価格

            // 消費税端数処理コード(得意先マスタより取得)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            salesSlip.FractionProcCd = taxFracProcCd;

            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                #region ●原単価
                //------------------------------------------------------
                // 原単価
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    //------------------------------------------------------
                    // 端数処理区分、単位取得
                    //------------------------------------------------------
                    frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                    //------------------------------------------------------
                    // 基準価格×掛率
                    //------------------------------------------------------
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdUnCst)
                    {
                        //------------------------------------------------------
                        // 基準価格×掛率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            rate = salesDetailWork.CostRate;
                            price = salesDetailWork.StdUnPrcUnCst;
                            break;
                        default:
                            rate = salesDetailWork.CostRate;
                            price = salesDetailWork.ListPriceTaxExcFl;
                            break;
                    }
                    break;
                #endregion

                #region ●売単価
                //------------------------------------------------------
                // 売単価
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    //------------------------------------------------------
                    // 端数処理区分、単位取得
                    //------------------------------------------------------
                    frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdSalUnPrc)
                    {
                        //------------------------------------------------------
                        // 基準価格×掛率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            rate = salesDetailWork.SalesRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 原単価×原価ＵＰ率
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            //rate = salesDetailWork.CostUpRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 原単価×(１－粗利率)
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            //rate = salesDetailWork.GrossProfitSecureRate;
                            price = salesDetailWork.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // 単価直接指定
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                            //    rate = 0;
                            //    price = 0;
                            //    break;
                            //default:
                            rate = salesDetailWork.SalesRate;
                            switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // 外税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                                //------------------------------------------------------
                                // 内税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = salesDetailWork.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // 非課税
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = salesDetailWork.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion
            }

            // 非課税
            int taxationDivCd = salesDetailWork.TaxationDivCd;
            if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            int unPrcCalcCd = 0;
            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    unPrcCalcCd = salesDetailWork.UnPrcCalcCdUnCst;
                    break;
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    unPrcCalcCd = salesDetailWork.UnPrcCalcCdSalUnPrc;
                    break;
            }

            if (unPrcCalcCd != (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate)
            {
                this._unitPriceCalculation.CalculateUnitPriceByRate(unitPriceKind,
                                                                    (UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdSalUnPrc,
                                                                    salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }
            else
            {
                this._unitPriceCalculation.CalculateUnitPriceByMarginRate(unitPriceKind,
                    //(UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                    salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }

            // 「総額表示する」か、「内税商品」の場合は税込み単価を表示単価に設定
            if ((salesSlip.TotalAmountDispWayCd == 1) || (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc))
            {
                unitPriceDisplay = unitPriceTaxInc;
            }
            else
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
        }

        /// <summary>
        /// 指定した定価の値を元に売上明細行オブジェクトの定価情報を設定します
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="salesUnitPriceInputType">売上単価入力モード</param>
        /// <param name="listPrice">定価</param>
        /// <param name="salesDetailDataTable">売上明細データテーブルオブジェクト</param>
        private void SalesDetailRowListPriceSetting(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip, SalesUnitPriceInputType salesUnitPriceInputType, double listPrice)
        {
            #region ●初期処理
            // 消費税端数処理コード(ゼロ固定)
            int salesCnsTaxFrcProcCd = 0;

            // 消費税端数処理単位、区分取得
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            //this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            double svListPriceTaxInc = salesDetailWork.ListPriceTaxIncFl;
            double svListPriceTaxExc = salesDetailWork.ListPriceTaxExcFl;
            #endregion

            #region ●売上情報
            if (salesDetailWork != null)
            {
                switch (salesUnitPriceInputType)
                {
                    // 売単価(税抜き)
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // 定価表示
                                    salesDetailWork.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // 定価表示
                                    salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // 定価表示
                                    salesDetailWork.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                            }
                            break;
                        }
                    // 売単価(税込み)
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // 定価表示
                                    salesDetailWork.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // 定価表示
                                    salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    //salesDetailWork.ListPriceDisplay = listPrice;      // 定価表示
                                    salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                    salesDetailWork.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                    break;
                            }
                            break;
                        }
                    // 売単価(表示用)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (salesSlip.TotalAmountDispWayCd == 0)
                            {
                                //-----------------------------------------------------
                                // 総額表示しない
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // 総額表示する
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // 定価(税抜)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        salesDetailWork.ListPriceTaxExcFl = listPrice;     // 定価(税抜)
                                        salesDetailWork.ListPriceTaxIncFl = listPrice;     // 定価(税込)
                                        break;
                                }
                            }
                            break;
                        }
                }

                // 基準単価(定価)設定
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdLPrice)
                {
                    // 掛率
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        salesDetailWork.StdUnPrcLPrice = listPrice;
                        break;
                    // 原価ＵＰ率
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // 粗利確保率
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // 単価手入力or画面手入力
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        salesDetailWork.StdUnPrcLPrice = 0;
                        break;
                }

                // 基準単価(売上単価)設定
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdSalUnPrc)
                {
                    // 掛率
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        salesDetailWork.StdUnPrcSalUnPrc = listPrice;
                        break;
                    // 原価ＵＰ率
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // 粗利確保率
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // 単価手入力or画面手入力
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        salesDetailWork.StdUnPrcSalUnPrc = 0;
                        break;
                }

                // 基準単価(原価単価)設定
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)salesDetailWork.UnPrcCalcCdUnCst)
                {
                    // 掛率
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        salesDetailWork.StdUnPrcUnCst = listPrice;
                        break;
                    // 原価ＵＰ率
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // 粗利確保率
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // 単価手入力or画面手入力
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        salesDetailWork.StdUnPrcUnCst = 0;
                        break;
                }

                // 定価変更区分設定
                if (salesDetailWork.ListPriceTaxExcFl != salesDetailWork.BfListPrice)
                {
                    salesDetailWork.ListPriceChngCd = 1; // 変更あり
                }
                else
                {
                    salesDetailWork.ListPriceChngCd = 0; // 変更なし
                }

            }
            #endregion
        }

        /// <summary>
        /// 原価金額を計算します。
        /// </summary>
        /// <param name="salesDetailWork">売上明細データオブジェクト</param>
        /// <param name="salesSlip">売上データオブジェクト</param>
        private void CalculationCost(ref SalesDetailWork salesDetailWork, SalesSlipWork salesSlip)
        {
            #region ●初期処理
            if (salesSlip == null) return;
            #endregion

            #region ●金額算定
            switch ((SalesGoodsCd)salesDetailWork.SalesGoodsCd)
            {
                // 商品
                case SalesGoodsCd.Goods:

                    // 原価金額を算定
                    long costTaxInc;
                    long costTaxExc;
                    long costDisplay;
                    double taxRate = salesSlip.ConsTaxRate;

                    // 課税区分
                    int taxationCode = salesDetailWork.TaxationDivCd;

                    double salesUnitCost = salesDetailWork.SalesUnitCost;

                    //switch ((CalculateTax.TaxationCode)salesDetailWork.TaxationDivCd)
                    //{
                    //    case CalculateTax.TaxationCode.TaxExc:
                    //        salesUnitCost = salesDetailWork.SalesUnitCostTaxExc;
                    //        break;
                    //    case CalculateTax.TaxationCode.TaxInc:
                    //        salesUnitCost = salesDetailWork.SalesUnitCostTaxInc;
                    //        break;
                    //    case CalculateTax.TaxationCode.TaxNone:
                    //        salesUnitCost = salesDetailWork.SalesUnitCostTaxExc;
                    //        break;
                    //}

                    // 非課税
                    if (salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    // 内税
                    else if ((taxationCode != (int)CalculateTax.TaxationCode.TaxNone) &&
                             (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                    }

                    #region ●売上情報
                    int sign = (salesSlip.SalesSlipCd == (int)SalesSlipCd.RetGoods) ? -1 : 1;
                    if (this.CalculationCost(
                        ref salesDetailWork,
                        salesDetailWork.ShipmentCnt * sign,
                        salesUnitCost,
                        taxationCode,
                        taxRate,
                        out costTaxInc,
                        out costTaxExc,
                        out costDisplay))
                    {
                        //salesDetailWork.CostTaxExc = costTaxExc;        // 外税
                        //salesDetailWork.CostTaxInc = costTaxInc;        // 内税
                        salesDetailWork.Cost = costDisplay;
                    }
                    #endregion

                    break;
                // 消費税調整
                // 残高調整
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    break;
            }
            #endregion
        }

        /// <summary>
        /// 原価金額を計算します。
        /// </summary>
        /// <param name="salesRowNo">売上行番号</param>
        /// <param name="shipmentCnt">数量</param>
        /// <param name="SalesUnitCostTaxExc">原価単価</param>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="taxRate">消費税率</param>
        /// <param name="costTaxInc">原価金額（税込み）</param>
        /// <param name="costTaxExc">原価金額（税抜き）</param>
        /// <param name="costDisplay">原価金額（表示）</param>
        /// <returns>true:算定完了 false:算定失敗</returns>
        /// <remarks>
        /// <br>Call：商品検索／定価／売単価／売価率／原単価／原価率／売上金額 変更時</br>
        /// </remarks>
        private bool CalculationCost(ref SalesDetailWork salesDetailWork, double shipmentCnt, double SalesUnitCostTaxExc, int taxationCode, double taxRate, out long costInc, out long costExc, out long costDisplay)
        {
            costInc = 0;
            costExc = 0;
            costDisplay = 0;
            double unitPriceExc = 0;	                // 単価（税抜き）
            double unitPriceInc = 0;				    // 単価（税込み）
            double unitPriceTax = 0;					// 単価（消費税）
            long priceExc = 0;					        // 価格（税抜き）
            long priceInc = 0;						    // 価格（税込み）
            long priceTax = 0;						    // 価格（消費税）

            // 原価金額端数処理コード
            int costFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);

            // 消費税端数処理単位、区分取得
            int taxFrac = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailWork.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;

            // 出荷数が0または売上単価が0の場合はすべて0で終了
            if ((shipmentCnt == 0) || (SalesUnitCostTaxExc == 0)) return true;

            switch ((CalculateTax.TaxationCode)taxationCode)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // 外税
                    //---------------------------------
                    unitPriceExc = SalesUnitCostTaxExc;	    // 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    //this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxRate, taxFrac, out taxFracProcUnit, out taxFracProcCd);
                    costInc = priceInc;		        // 売上金額（税込み）
                    costExc = priceExc;		        // 売上金額（税抜き）		
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // 内税
                    //---------------------------------
                    unitPriceInc = SalesUnitCostTaxExc;	    // 単価（税込み）
                    priceInc = 0;					        // 価格（税込み）

                    //this._salesPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    costInc = priceInc;		        // 売上金額（税込み）
                    costExc = priceExc;		        // 売上金額（税抜き）
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // 非課税
                    //---------------------------------
                    unitPriceExc = SalesUnitCostTaxExc;	    // 単価（税抜き）
                    priceExc = 0;					        // 価格（税抜き）

                    //this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxRate, taxFrac, out taxFracProcUnit, out taxFracProcCd);

                    costInc = priceExc;		// 売上金額（税込み）
                    costExc = priceExc;		// 売上金額（税込み）
                    break;
            }

            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc) // 課税区分 // 原価は総額表示区分によらない
            {
                costDisplay = costInc;
            }
            else
            {
                costDisplay = costExc;
            }

            return true;
        }

        # region 売上明細の設定
        /// <summary>
        /// 売上明細の設定
        /// </summary>
        /// <param name="jnl">送受信JNLクラス</param>
        /// <param name="tempSalesSlipNum">売上伝票番号（仮）</param>
        /// <param name="tempSalesSlipDtlNum">売上明細通番（仮）</param>
        /// <param name="prtSalesDetail">(印刷用)UOE売上明細クラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int WriteDtTblSalesDetail(OrderSndRcvJnl jnl, string tempSalesSlipNum, Int64 tempSalesSlipDtlNum, string partySaleSlipNum, PrtSalesDetail prtSalesDetail, out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //------------------------------------------------------
                // UOE発注先マスタの取得
                //------------------------------------------------------
                #region UOE発注先マスタの取得
                UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(jnl.UOESupplierCd);
                if (uOESupplier == null)
                {
                    message = "UOE発注先マスタの読み込みに失敗しました。";
                    return (-1);
                }
                #endregion

                //------------------------------------------------------
                // 受注明細の取得
                //------------------------------------------------------
                #region 受注明細の取得
                //受注データの取得
	            Int32 acptAnOdrStatus = 20;
                SalesSlipWork salesSlipWork = _uoeSndRcvJnlAcs.ReadAcptSlipDataTable(acptAnOdrStatus, jnl.SalesSlipNum);

	            //受注明細の取得
	            SalesDetailWork salesDetailWork = _uoeSndRcvJnlAcs.ReadSalesDetailDataTable(acptAnOdrStatus, jnl.SalesSlipDtlNum);
                #endregion

                //------------------------------------------------------
                // 売上明細の設定
                //------------------------------------------------------
                #region 売上明細の設定
                    
                //------------------------------------------------------
                // リモート項目の設定
                //------------------------------------------------------
                #region リモート項目の設定
                //ヘッダー項目初期化
                salesDetailWork.CreateDateTime = DateTime.MinValue;
                salesDetailWork.UpdateDateTime = DateTime.MinValue;
                salesDetailWork.FileHeaderGuid = Guid.Empty;
  
                salesDetailWork.UpdEmployeeCode = "";
                salesDetailWork.UpdAssemblyId1 = "";
                salesDetailWork.UpdAssemblyId2 = "";
                salesDetailWork.LogicalDeleteCode = 0;

                //出荷数
                salesDetailWork.ShipmentCnt = (double)prtSalesDetail.prtShipmentCnt;

                //受注数量
                salesDetailWork.AcceptAnOrderCnt = prtSalesDetail.prtAcceptAnOrderCnt;

                //受注調整数
                salesDetailWork.AcptAnOdrAdjustCnt = 0;

                //受注残数
                salesDetailWork.AcptAnOdrRemainCnt =  salesDetailWork.AcceptAnOrderCnt
                                                    + salesDetailWork.AcptAnOdrAdjustCnt
                                                    - salesDetailWork.ShipmentCnt;
                //受注ステータス（元）
                salesDetailWork.AcptAnOdrStatusSrc = salesDetailWork.AcptAnOdrStatus;

                //売上明細通番（元）
                salesDetailWork.SalesSlipDtlNumSrc = salesDetailWork.SalesSlipDtlNum;

                //仕入形式（同時）
                salesDetailWork.SupplierFormalSync = 0;
                
                //仕入明細通番（同時）
                salesDetailWork.StockSlipDtlNumSync = 0;

                //明細関連付けGUID
                if (this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().SalesStockDiv != 0)
                {
                    salesDetailWork.DtlRelationGuid = SetGuidSalesStock(jnl.OnlineNo, jnl.OnlineRowNo, partySaleSlipNum, prtSalesDetail.detailCd);
                }
                else
                {
                    salesDetailWork.DtlRelationGuid = Guid.NewGuid();
                }

                salesDetailWork.AcptAnOdrStatus = 30;           //受注ステータス
                salesDetailWork.SalesSlipNum = String.Empty;    //売上伝票番号
                salesDetailWork.SalesRowNo = 0;                 //売上行番号
                salesDetailWork.SalesRowDerivNo = 0;            //売上行番号枝番
                salesDetailWork.SalesSlipDtlNum = 0;            //売上明細通番
                //add 2011/07/28
                CustomerInfo customerInfo;
                status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, salesSlipWork.CustomerCode);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, salesSlipWork.CustomerCode, out customerInfo);
                }
                if (status == (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    // PCC連携有り
                    if (customerInfo.OnlineKindDiv != 0)
                    {
                        salesDetailWork.AutoAnswerDivSCM = 1;           //自動回答区分(SCM) 
                    }
                    else
                    {
                        salesDetailWork.AutoAnswerDivSCM = 0;           //通常
                    }
                }
                //add 2011/07/28
                #endregion

                //-----------------------------------------------------------
                // 売上日付
                //-----------------------------------------------------------
                #region 売上日付
                //UOE自社設定ﾏｽﾀの計上日付区分:システム日付
                if (_uoeSndRcvJnlAcs.uOESetting.AddUpADateDiv == (int)EnumUoeConst.ctAddUpADateDiv.ct_System)
                {
                    salesDetailWork.SalesDate = DateTime.Now;
                }
                //UOE自社設定ﾏｽﾀの計上日付区分:売上日付
                else
                {
                    salesDetailWork.SalesDate = jnl.SalesDate;
                }

                // --------- ADD 譚洪 2013/12/16 -------------- >>>>>>>
                //仕入先消費税税率
                salesSlipWork.ConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(salesDetailWork.SalesDate);
                // --------- ADD 譚洪 2013/12/16 -------------- <<<<<<<

                //請求先コードにて売上月次及び売上締次の締日チェック処理
                //売上締次の締日取得処理
                if ((salesSlipWork.ResultsAddUpSecCd.Trim() != "") && (salesSlipWork.ClaimCode != 0))
                {
                    if (_totalDayCalculator.CheckDmdC(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, salesDetailWork.SalesDate) != false)
                    {
                        DateTime prevTotalDay = DateTime.MinValue;
                        DateTime currentTotalDay = DateTime.MinValue;

                        if (_totalDayCalculator.GetTotalDayDmdC(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, out prevTotalDay, out currentTotalDay) == 0)
                        {
                            DateTime setDateTime = prevTotalDay.AddDays(1);
                            salesDetailWork.SalesDate = setDateTime;
                        }
                    }

                    //売上月次の締日取得処理
                    if (_totalDayCalculator.CheckMonthlyAccRec(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, salesDetailWork.SalesDate) != false)
                    {
                        DateTime prevTotalDay = DateTime.MinValue;
                        DateTime currentTotalDay = DateTime.MinValue;

                        if (_totalDayCalculator.GetTotalDayMonthlyAccRec(salesSlipWork.ResultsAddUpSecCd, salesSlipWork.ClaimCode, out prevTotalDay, out currentTotalDay) == 0)
                        {
                            DateTime setDateTime = prevTotalDay.AddDays(1);
                            salesDetailWork.SalesDate = setDateTime;
                        }
                    }
                }
                #endregion

                //-----------------------------------------------------------
                // 定価の算出
                //-----------------------------------------------------------
                #region 定価の算出
                double dstPrice = 0;
                double srcPrice = salesDetailWork.ListPriceTaxExcFl;
                switch (uOESupplier.ListPriceUseDiv)
                {
                    //0:高い方
                    case (int)EnumUoeConst.ctListPriceUseDiv.ct_Hight:
                        dstPrice = jnl.AnswerListPrice <= srcPrice ? srcPrice : jnl.AnswerListPrice;
                        break;
                    //1:入力優先
                    case (int)EnumUoeConst.ctListPriceUseDiv.ct_Input:
                        dstPrice = srcPrice;
                        break;
                    //2:オンライン優先
                    default:
                        dstPrice = jnl.AnswerListPrice;
                        break;
                }

                //送受信JNL上の定価を採用
                if (dstPrice != srcPrice)
                {
                    SalesDetailRowListPriceSetting(ref salesDetailWork, salesSlipWork, SalesUnitPriceInputType.SalesUnitPrice, dstPrice);

                    //クリア項目
                    salesDetailWork.RateSectPriceUnPrc = string.Empty;
                    salesDetailWork.RateDivLPrice = string.Empty;
                    salesDetailWork.UnPrcCalcCdLPrice = 0;
                    salesDetailWork.PriceCdLPrice = 0;
                    salesDetailWork.StdUnPrcLPrice = 0;
                    //salesDetailWork.FracProcUnitLPrice = 0;
                    //salesDetailWork.FracProcLPrice = 0;
                }
                #endregion

                //-----------------------------------------------------------
                // 原価の算出
                //-----------------------------------------------------------
                #region 原価の算出
                // -- UPD 2011/12/02 ------------------------>>>>>
                //if (jnl.AnswerSalesUnitCost != 0)
                if (jnl.AnswerSalesUnitCost != 0 || salesDetailWork.ShipmentCnt == 0)
                // -- UPD 2011/12/02 ------------------------<<<<<
                {
                    //原価単価
                    salesDetailWork.SalesUnitCost = jnl.AnswerSalesUnitCost;

                    //原価率
                    salesDetailWork.CostRate = 0;

                    //原価
                    CalculationCost(ref salesDetailWork, salesSlipWork);

                    //仕入単価変更区分
                    if (salesDetailWork.BfUnitCost != jnl.AnswerSalesUnitCost)
                    {
                        salesDetailWork.SalesUnitCostChngDiv = 1;   //1:変更あり
                    }

                    //クリア項目
                    salesDetailWork.RateSectCstUnPrc = string.Empty;
                    salesDetailWork.RateDivUnCst = string.Empty;
                    salesDetailWork.UnPrcCalcCdUnCst = 0;
                    salesDetailWork.PriceCdUnCst = 0;
                    salesDetailWork.StdUnPrcUnCst = 0;
                    //salesDetailWork.FracProcUnitUnCst = 0;
                    //salesDetailWork.FracProcUnCst = 0;
                }  
                #endregion

                //-----------------------------------------------------------
                // 売価の算出
                //-----------------------------------------------------------
                #region 売価の算出
                if ((dstPrice != srcPrice) && (salesDetailWork.SalesRate != 0))
                {
                    SalesDetailRowSalesUnitPriceSetting(ref salesDetailWork, salesSlipWork, SalesUnitPriceInputType.SalesUnitPrice, dstPrice);

                    SalesDetailRowSalesUnitPriceSettingbyRate(ref salesDetailWork, salesSlipWork, salesDetailWork.SalesRate, true);

                    //クリア項目
                    salesDetailWork.RateSectSalUnPrc = string.Empty;
                    salesDetailWork.RateDivSalUnPrc = string.Empty;
                    salesDetailWork.UnPrcCalcCdSalUnPrc = 0;
                    salesDetailWork.PriceCdSalUnPrc = 0;
                    salesDetailWork.StdUnPrcSalUnPrc = 0;
                    //salesDetailWork.FracProcUnitSalUnPrc = 0;
                    //salesDetailWork.FracProcSalUnPrc = 0;
                }
                #endregion

                //-----------------------------------------------------------
                // 売上金額の算出
                //-----------------------------------------------------------
                #region 売上金額の算出
                //売上金額（税抜き）
                salesDetailWork.SalesMoneyTaxExc = (long)(salesDetailWork.SalesUnPrcTaxExcFl * salesDetailWork.ShipmentCnt);

                // 売上金額再計算
                long salesMoneyTaxExc;
                long salesMoneyTaxInc;
                long salesMoneyDisplay;
                int fractionProcCd;
                this.CalculationSalesMoney(salesSlipWork, salesDetailWork, out salesMoneyTaxInc, out salesMoneyTaxExc, out salesMoneyDisplay, out fractionProcCd);

                //売上金額（税抜き）
                salesDetailWork.SalesMoneyTaxExc = salesMoneyTaxExc;

                //売上金額（税込み）
                salesDetailWork.SalesMoneyTaxInc = salesMoneyTaxInc;

                //売上金額消費税額
                salesDetailWork.SalesPriceConsTax = salesMoneyTaxInc - salesMoneyTaxExc;
                #endregion

                //-----------------------------------------------------------
                // 印刷品番の算出
                //-----------------------------------------------------------
                #region 印刷品番の算出
                if ((uOESupplier.PartsNoPrtCd == (int)EnumUoeConst.ctSubstPartsNoDiv.ct_SubstParts)
                && (jnl.SubstPartsNo.Trim() != ""))
                {
                    salesDetailWork.PrtGoodsNo = jnl.SubstPartsNo;  //印刷用品番

                    MakerUMnt makerUMnt = null;
                    status = this._uoeSndRcvCtlInitAcs.GetMakerInf(jnl.AnswerMakerCd, out makerUMnt);
                    if (status == 0)
                    {
                        salesDetailWork.PrtMakerCode = makerUMnt.GoodsMakerCd;    //印刷用メーカーコード
                        salesDetailWork.PrtMakerName = makerUMnt.MakerKanaName;   //印刷用メーカー名称
                    }
                    else
                    {
                        salesDetailWork.PrtMakerCode = 0;    //印刷用メーカーコード
                        salesDetailWork.PrtMakerName = "";   //印刷用メーカー名称
                    }
                }
                //発注品番採用
                else
                {
                    salesDetailWork.PrtGoodsNo = salesDetailWork.GoodsNo;       //印刷用品番
                    salesDetailWork.PrtMakerCode = salesDetailWork.GoodsMakerCd;//印刷用メーカーコード
                    salesDetailWork.PrtMakerName = salesDetailWork.MakerName;   //印刷用メーカー名称
                }
                #endregion

                //-----------------------------------------------------------
                // 品番の算出
                //-----------------------------------------------------------
                #region 品番の算出
                //代替品番採用
                if((uOESupplier.SubstPartsNoDiv == (int)EnumUoeConst.ctSubstPartsNoDiv.ct_SubstParts)
                && (jnl.SubstPartsNo.Trim() != ""))
                {
                    salesDetailWork.GoodsNo = jnl.SubstPartsNo;     //品番
                    salesDetailWork.GoodsMakerCd = jnl.AnswerMakerCd;	// 回答メーカーコード

                    MakerUMnt makerUMnt = null;
                    status = this._uoeSndRcvCtlInitAcs.GetMakerInf(jnl.AnswerMakerCd, out makerUMnt);
                    if (status == 0)
                    {
                        salesDetailWork.MakerName = makerUMnt.MakerName;          //メーカー名称
                        salesDetailWork.MakerKanaName = makerUMnt.MakerKanaName;  //メーカーカナ名称
                    }
                    else
                    {
                        salesDetailWork.MakerName = "";      //メーカー名称
                        salesDetailWork.MakerKanaName = "";  //メーカーカナ名称
                    }
                }
                #endregion

                //-----------------------------------------------------------
                // 品名の算出
                //-----------------------------------------------------------
                #region 品名
                if ((salesDetailWork.GoodsName.Trim() == "*") && (jnl.AnswerPartsName.Trim() != ""))
                {
                    salesDetailWork.GoodsName = jnl.AnswerPartsName;
                    //---ADD xupz 2014/09/02 Redmine#43365 UOE送信処理 品名カナに対して回答結果の品名がセットされない件---->>>>>
                    string goodsNameKana = GetKanaString(jnl.AnswerPartsName);
                    // ガ(1文字)⇒ｶﾞ(2文字)のような変換もあるので、長さをチェックする。
                    // 品名MAX桁数40
                    if (goodsNameKana.Length > 40)
                    {
                        goodsNameKana = goodsNameKana.Substring(0, 40);
                    }
                    salesDetailWork.GoodsNameKana = goodsNameKana;
                    //---ADD xupz 2014/09/02 Redmine#43365 UOE送信処理 品名カナに対して回答結果の品名がセットされない件----<<<<<
                }

                // --- ADD chenw 2013/03/07 Redmine#34989 ------------>>>>>
                //-----------------------------------------------------------
                // オープン価格区分
                //-----------------------------------------------------------
                if (OPENFLAG.Equals(jnl.LineErrorMassage.Trim()))
                {
                    salesDetailWork.OpenPriceDiv = 1;
                }
                // --- ADD chenw 2013/03/07 Redmine#34989 ------------<<<<<
                #endregion
                #endregion

                //------------------------------------------------------
                // 売上明細の追加処理
                //------------------------------------------------------
                #region 売上明細の追加処理
                status = _uoeSndRcvJnlAcs.InsertSalesDetailDataTable(salesDetailWork, tempSalesSlipNum, tempSalesSlipDtlNum, prtSalesDetail, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                #endregion

            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        //---ADD xupz 2014/09/02 Redmine#43365 UOE送信処理 品名カナに対して回答結果の品名がセットされない件---->>>>>
        #region 全角⇒半角変換
        /// <summary>
        /// 全角⇒半角変換
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private string GetKanaString(string orgString)
        {
            // 全角⇒半角変換（途中に含まれる変換できない文字はそのまま）
            return Microsoft.VisualBasic.Strings.StrConv(orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
        }
        #endregion
        //---ADD xupz 2014/09/02 Redmine#43365 UOE送信処理 品名カナに対して回答結果の品名がセットされない件----<<<<<

        # region 伝票合算
        /// <summary>
        /// 伝票合算
        /// </summary>
        /// <param name="jnl">送受信JNL</param>
        /// <param name="tempSalesSlipDtlNum">売上明細通番（仮）</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        private int slipOutPutAddCalculate(OrderSndRcvJnl jnl, ref Int64 tempSalesSlipDtlNum, out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //------------------------------------------------------
                // ＫＥＹ項目値の算出
                //------------------------------------------------------
                # region ＫＥＹ項目値の算出
                //売上伝票番号（仮）← <jnl>売上伝票番号
                string tempSalesSlipNum = jnl.SalesSlipNum;

                //相手先伝票番号
                string partySaleSlipNum = jnl.UOESectionSlipNo;
                #endregion

                //------------------------------------------------------
                // 売上データ部(追加項目)の算出
                //------------------------------------------------------
                # region 売上データ部(追加項目)の算出
                //UOE伝票種別
                Int32 slipCd = (Int32)UoeSales.ctSlipCd.ct_Section; //0:確認伝票
                #endregion

                //------------------------------------------------------
                // 売上明細部(追加項目)の算出
                //------------------------------------------------------
                # region 売上明細部(追加項目)の算出
                //BO出庫数合計
                int bOShipmentCnt = GetBOShipmentCnt(jnl);

                PrtSalesDetail prtSalesDetail = new PrtSalesDetail();

                //(印刷用)受信時間
                prtSalesDetail.prtReceiveTime = jnl.ReceiveTime;

                //(印刷用)BO区分
                prtSalesDetail.prtBoCode = jnl.BoCode;

                //(印刷用)UOE納品区分
                prtSalesDetail.prtUOEDeliGoodsDiv = jnl.UOEDeliGoodsDiv;

                // (印刷用)納品区分名称
                prtSalesDetail.prtDeliveredGoodsDivNm = jnl.DeliveredGoodsDivNm;

                // (印刷用)フォロー納品区分
                prtSalesDetail.prtFollowDeliGoodsDiv = jnl.FollowDeliGoodsDiv;

                // (印刷用)フォロー納品区分名称
                prtSalesDetail.prtFollowDeliGoodsDivNm = jnl.FollowDeliGoodsDivNm;

                //(印刷用)受注数
                prtSalesDetail.prtAcceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                //(印刷用)拠点出庫数
                prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                //(印刷用)BO出庫数
                prtSalesDetail.prtBOShipmentCnt = bOShipmentCnt;

                //(印刷用)出庫数
                prtSalesDetail.prtShipmentCnt = jnl.UOESectOutGoodsCnt + bOShipmentCnt;

                //明細種別
                prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                #endregion

                //------------------------------------------------------
                // 売上明細の設定
                //------------------------------------------------------
                # region 売上明細の設定
                //売上明細の更新処理
                status = WriteDtTblSalesDetail(
                                jnl,                //送受信JNLクラス
                                tempSalesSlipNum,   //売上伝票番号（仮）
                                tempSalesSlipDtlNum,//売上明細通番（仮）
                                partySaleSlipNum,   //相手先伝票番号
                                prtSalesDetail,     //(印刷用)UOE売上明細クラス
                                out message);

                if(status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return(status);
                }
                #endregion

                //------------------------------------------------------
                // 売上データの設定
                //------------------------------------------------------
                # region 売上データの設定
                //売上データの更新処理
                status = WriteDtTblSalesSlip(
                                jnl,                //送受信JNLクラス
                                tempSalesSlipNum,   //売上伝票番号（仮）
                                prtSalesDetail.prtShipmentCnt,        //出庫数合計
                                slipCd,             //UOE伝票種別
                                out message);
                if(status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return(status);
                }
                #endregion

                //売上明細通番（仮）のインクリメント
                tempSalesSlipDtlNum++;
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region フォロー(合算)
        /// <summary>
        /// フォロー(合算)
        /// </summary>
        /// <param name="jnl">送受信JNL</param>
        /// <param name="tempSalesSlipDtlNum">売上明細通番（仮）</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        private int salesSlipAddCalculate(OrderSndRcvJnl jnl, ref Int64 tempSalesSlipDtlNum, out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //BO出庫数合計
                int bOShipmentCnt = GetBOShipmentCnt(jnl);

                //受注数
                double acceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                //確認伝票・フォロー合算・ゼロ伝票
                for(int i=0; i<3; i++)
                {
                    # region 変数の初期化
                    //変数の初期化
                    string tempSalesSlipNum = "";   //売上伝票番号（仮）
                    string partySaleSlipNum = "";   //相手先伝票番号
                    Int32 slipCd = 0;               //UOE伝票種別

                    PrtSalesDetail prtSalesDetail = new PrtSalesDetail();
                    //(印刷用)受信時間
                    prtSalesDetail.prtReceiveTime = jnl.ReceiveTime;

                    //(印刷用)BO区分
                    prtSalesDetail.prtBoCode = jnl.BoCode;

                    //(印刷用)UOE納品区分
                    prtSalesDetail.prtUOEDeliGoodsDiv = jnl.UOEDeliGoodsDiv;

                    // (印刷用)納品区分名称
                    prtSalesDetail.prtDeliveredGoodsDivNm = jnl.DeliveredGoodsDivNm;

                    // (印刷用)フォロー納品区分
                    prtSalesDetail.prtFollowDeliGoodsDiv = jnl.FollowDeliGoodsDiv;

                    // (印刷用)フォロー納品区分名称
                    prtSalesDetail.prtFollowDeliGoodsDivNm = jnl.FollowDeliGoodsDivNm;
                    #endregion

                    switch(i)
                    {
                        //------------------------------------------------------
                        // 確認伝票
                        //------------------------------------------------------
                        case 0:
                            # region 確認伝票 
                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strSection;

                            //相手先伝票番号
                            partySaleSlipNum = jnl.UOESectionSlipNo;
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Section; //0:確認伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = bOShipmentCnt;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = jnl.UOESectOutGoodsCnt;

                            //明細種別
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion

                            #endregion
                            break;

                        //------------------------------------------------------
                        // フォロー合算
                        //------------------------------------------------------
                        case 1:
                            # region フォロー合算
                            //------------------------------------------------------
                            // フォロー合算の未作成判定
                            //------------------------------------------------------
                            # region フォロー合算の未作成判定
                            if (bOShipmentCnt == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strBO1;

                            //相手先伝票番号
                            partySaleSlipNum = jnl.BOSlipNo1;
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_BO1; //1:BO1伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = bOShipmentCnt;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = bOShipmentCnt;

                            //明細種別
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero: (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // ゼロ伝票
                        //------------------------------------------------------
                        case 2:
                            # region ゼロ伝票
                            //------------------------------------------------------
                            // ゼロ伝票の未作成判定
                            //------------------------------------------------------
                            # region ゼロ伝票の未作成判定
                            if ((CheckZeroSlip() != true)
                            || (bOShipmentCnt != 0)
                            || (jnl.UOESectOutGoodsCnt != 0))
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strZero;

                            //相手先伝票番号
                            partySaleSlipNum = "";
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Zero; //9:ゼロ伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = 0;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = 0;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = 0;

                            //明細種別
                            prtSalesDetail.detailCd = (int)PrtSalesDetail.ctDetailCd.ct_Zero;
                            #endregion
                            #endregion
                            break;
                    }

                    //------------------------------------------------------
                    // 売上明細の設定
                    //------------------------------------------------------
                    # region 売上明細の設定
                    //売上明細の更新処理
                    status = WriteDtTblSalesDetail(
                                    jnl,                //送受信JNLクラス
                                    tempSalesSlipNum,   //売上伝票番号（仮）
                                    tempSalesSlipDtlNum,//売上明細通番（仮）
                                    partySaleSlipNum,   //相手先伝票番号
                                    prtSalesDetail,     //(印刷用)UOE売上明細クラス
                                    out message);
                    if(status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return(status);
                    }
                    #endregion

                    //------------------------------------------------------
                    // 売上データの設定
                    //------------------------------------------------------
                    # region 売上データの設定
                    //売上データの更新処理
                    status = WriteDtTblSalesSlip(
                                    jnl,                //送受信JNLクラス
                                    tempSalesSlipNum,   //売上伝票番号（仮）
                                    prtSalesDetail.prtShipmentCnt,        //出庫数合計
                                    slipCd,             //UOE伝票種別
                                    out message);
                    if(status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return(status);
                    }
                    #endregion

                    //売上明細通番（仮）のインクリメント
                    tempSalesSlipDtlNum++;

                    //受注数の算出
                    acceptAnOrderCnt = acceptAnOrderCnt - prtSalesDetail.prtShipmentCnt;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region フォロー(別々)
        /// <summary>
        /// フォロー(別々)
        /// </summary>
        /// <param name="jnl">送受信JNL</param>
        /// <param name="tempSalesSlipDtlNum">売上明細通番（仮）</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        private int salesSlipSeparate(OrderSndRcvJnl jnl, ref Int64 tempSalesSlipDtlNum, out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //BO出庫数合計
                int bOShipmentCnt = GetBOShipmentCnt(jnl);

                //受注数
                double acceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                //確認伝票・フォロー別々・ゼロ伝票
                for (int i = 0; i < 7; i++)
                {
                    # region 変数の初期化
                    //変数の初期化
                    string tempSalesSlipNum = "";   //売上伝票番号（仮）
                    string partySaleSlipNum = "";   //相手先伝票番号
                    Int32 slipCd = 0;               //UOE伝票種別

                    PrtSalesDetail prtSalesDetail = new PrtSalesDetail();
                    //(印刷用)受信時間
                    prtSalesDetail.prtReceiveTime = jnl.ReceiveTime;

                    //(印刷用)BO区分
                    prtSalesDetail.prtBoCode = jnl.BoCode;

                    //(印刷用)UOE納品区分
                    prtSalesDetail.prtUOEDeliGoodsDiv = jnl.UOEDeliGoodsDiv;

                    // (印刷用)納品区分名称
                    prtSalesDetail.prtDeliveredGoodsDivNm = jnl.DeliveredGoodsDivNm;

                    // (印刷用)フォロー納品区分
                    prtSalesDetail.prtFollowDeliGoodsDiv = jnl.FollowDeliGoodsDiv;

                    // (印刷用)フォロー納品区分名称
                    prtSalesDetail.prtFollowDeliGoodsDivNm = jnl.FollowDeliGoodsDivNm;
                    #endregion

                    switch (i)
                    {
                        //------------------------------------------------------
                        // 確認伝票
                        //------------------------------------------------------
                        case 0:
                            # region 確認伝票
                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strSection;

                            //相手先伝票番号
                            partySaleSlipNum = jnl.UOESectionSlipNo;
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Section; //0:確認伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = GetBOShipmentCnt(jnl);

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = jnl.UOESectOutGoodsCnt;

                            //明細種別
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion

                            #endregion
                            break;

                        //------------------------------------------------------
                        // BO1伝票
                        //------------------------------------------------------
                        case 1:
                            # region BO1伝票
                            //------------------------------------------------------
                            // BO1伝票の未作成判定
                            //------------------------------------------------------
                            # region BO1伝票の未作成判定
                            if (jnl.BOShipmentCnt1 == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strBO1;

                            //相手先伝票番号
                            partySaleSlipNum = jnl.BOSlipNo1;
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_BO1; //1:BO1伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = jnl.BOShipmentCnt1;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = jnl.BOShipmentCnt1;

                            //明細種別
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // BO2伝票
                        //------------------------------------------------------
                        case 2:
                            # region BO2伝票
                            //------------------------------------------------------
                            // BO2伝票の未作成判定
                            //------------------------------------------------------
                            # region BO2伝票の未作成判定
                            if (jnl.BOShipmentCnt2 == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strBO2;

                            //相手先伝票番号
                            partySaleSlipNum = jnl.BOSlipNo2;
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_BO2; //2:BO2伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = jnl.BOShipmentCnt2;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = jnl.BOShipmentCnt2;

                            //明細種別
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // BO3伝票
                        //------------------------------------------------------
                        case 3:
                            # region BO3伝票
                            //------------------------------------------------------
                            // BO3伝票の未作成判定
                            //------------------------------------------------------
                            # region BO3伝票の未作成判定
                            if (jnl.BOShipmentCnt3 == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strBO3;

                            //相手先伝票番号
                            partySaleSlipNum = jnl.BOSlipNo3;
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_BO3; //3:BO3伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = jnl.BOShipmentCnt3;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = jnl.BOShipmentCnt3;

                            //明細種別
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // EO伝票
                        //------------------------------------------------------
                        case 4:
                            # region EO伝票
                            //------------------------------------------------------
                            // EO伝票の未作成判定
                            //------------------------------------------------------
                            # region EO伝票の未作成判定
                            if (jnl.EOAlwcCount == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // UOE自社設定ﾏｽﾀのﾒｰｶｰﾌｫﾛｰ計上区分が受注の場合には対象外
                            //------------------------------------------------------
                            # region UOE自社設定ﾏｽﾀのﾒｰｶｰﾌｫﾛｰ計上区分が受注の場合には対象外
                            if (_uoeSndRcvJnlAcs.uOESetting.MakerFollowAddUpDiv == (int)EnumUoeConst.ctMakerFollowAddUpDiv.ct_Order)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strEO;

                            //相手先伝票番号
                            partySaleSlipNum = "";
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_EO; //4:EO伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = jnl.EOAlwcCount;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = jnl.EOAlwcCount;

                            //明細種別
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // メーカーフォロー伝票
                        //------------------------------------------------------
                        case 5:
                            # region メーカーフォロー伝票
                            //------------------------------------------------------
                            // メーカーフォロー伝票の未作成判定
                            //------------------------------------------------------
                            # region メーカーフォロー伝票の未作成判定
                            if (jnl.MakerFollowCnt == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // UOE自社設定ﾏｽﾀのﾒｰｶｰﾌｫﾛｰ計上区分が受注の場合には対象外
                            //------------------------------------------------------
                            # region UOE自社設定ﾏｽﾀのﾒｰｶｰﾌｫﾛｰ計上区分が受注の場合には対象外
                            if (_uoeSndRcvJnlAcs.uOESetting.MakerFollowAddUpDiv == (int)EnumUoeConst.ctMakerFollowAddUpDiv.ct_Order)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strMaker;

                            //相手先伝票番号
                            partySaleSlipNum = "";
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Maker; //5:メーカーフォロー伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = jnl.MakerFollowCnt;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = jnl.MakerFollowCnt;

                            //明細種別
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // ゼロ伝票
                        //------------------------------------------------------
                        case 6:
                            # region ゼロ伝票
                            //------------------------------------------------------
                            // ゼロ伝票の未作成判定
                            //------------------------------------------------------
                            # region ゼロ伝票の未作成判定
                            if ((CheckZeroSlip() != true)
                            || (bOShipmentCnt != 0)
                            || (jnl.UOESectOutGoodsCnt != 0))
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strZero;

                            //相手先伝票番号
                            partySaleSlipNum = "";
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Zero; //9:ゼロ伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = 0;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = 0;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = 0;

                            //明細種別
                            prtSalesDetail.detailCd = (int)PrtSalesDetail.ctDetailCd.ct_Zero;
                            #endregion
                            #endregion
                            break;
                    }

                    //------------------------------------------------------
                    // 売上明細の設定
                    //------------------------------------------------------
                    # region 売上明細の設定
                    //売上明細の更新処理
                    status = WriteDtTblSalesDetail(
                                    jnl,                //送受信JNLクラス
                                    tempSalesSlipNum,   //売上伝票番号（仮）
                                    tempSalesSlipDtlNum,//売上明細通番（仮）
                                    partySaleSlipNum,   //相手先伝票番号
                                    prtSalesDetail,     //(印刷用)UOE売上明細クラス
                                    out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    //------------------------------------------------------
                    // 売上データの設定
                    //------------------------------------------------------
                    # region 売上データの設定
                    //売上データの更新処理
                    status = WriteDtTblSalesSlip(
                                    jnl,                //送受信JNLクラス
                                    tempSalesSlipNum,   //売上伝票番号（仮）
                                    prtSalesDetail.prtShipmentCnt,        //出庫数合計
                                    slipCd,             //UOE伝票種別
                                    out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    //売上明細通番（仮）のインクリメント
                    tempSalesSlipDtlNum++;

                    //受注数の算出
                    acceptAnOrderCnt = acceptAnOrderCnt - prtSalesDetail.prtShipmentCnt;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region ＜ホンダ専用＞フォロー(別々)
        /// <summary>
        /// ＜ホンダ専用＞フォロー(別々)
        /// </summary>
        /// <param name="jnl">送受信JNL</param>
        /// <param name="tempSalesSlipDtlNum">売上明細通番（仮）</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Update Note: e-Partsで発注する際に、メーカーフォローの場合は相手先伝票番号１に「-F」を付足す。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2015/07/24</br>
        /// </remarks>
        //private int salesSlipSeparateForHonda(OrderSndRcvJnl jnl, ref Int64 tempSalesSlipDtlNum, out string message)// DEL 2015/07/24 陳艶丹 For Redmine #46880
        private int salesSlipSeparateForHonda(OrderSndRcvJnl jnl, ref Int64 tempSalesSlipDtlNum, out string message, UOESupplier uOESupplier)// ADD 2015/07/24 陳艶丹 For Redmine #46880
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //BO出庫数合計
                int bOShipmentCnt = GetBOShipmentCnt(jnl);

                //受注数
                double acceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                //確認伝票・フォロー別々・ゼロ伝票
                for (int i = 0; i < 3; i++)
                {
                    # region 変数の初期化
                    //変数の初期化
                    string tempSalesSlipNum = "";   //売上伝票番号（仮）
                    string partySaleSlipNum = "";   //相手先伝票番号
                    Int32 slipCd = 0;               //UOE伝票種別

                    PrtSalesDetail prtSalesDetail = new PrtSalesDetail();
                    //(印刷用)受信時間
                    prtSalesDetail.prtReceiveTime = jnl.ReceiveTime;

                    //(印刷用)BO区分
                    prtSalesDetail.prtBoCode = jnl.BoCode;

                    //(印刷用)UOE納品区分
                    prtSalesDetail.prtUOEDeliGoodsDiv = jnl.UOEDeliGoodsDiv;

                    // (印刷用)納品区分名称
                    prtSalesDetail.prtDeliveredGoodsDivNm = jnl.DeliveredGoodsDivNm;

                    // (印刷用)フォロー納品区分
                    prtSalesDetail.prtFollowDeliGoodsDiv = jnl.FollowDeliGoodsDiv;

                    // (印刷用)フォロー納品区分名称
                    prtSalesDetail.prtFollowDeliGoodsDivNm = jnl.FollowDeliGoodsDivNm;
                    #endregion

                    switch (i)
                    {
                        //------------------------------------------------------
                        // 確認伝票
                        //------------------------------------------------------
                        case 0:
                            # region 確認伝票
                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strSection;

                            //相手先伝票番号
                            partySaleSlipNum = jnl.UOESectionSlipNo;
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Section; //0:確認伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = GetBOShipmentCnt(jnl);

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = jnl.UOESectOutGoodsCnt;

                            //明細種別
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion

                            #endregion
                            break;

                        //------------------------------------------------------
                        // BO1-3伝票
                        //------------------------------------------------------
                        case 1:
                            # region BO1-3伝票
                            //------------------------------------------------------
                            // BO1伝票の未作成判定
                            //------------------------------------------------------
                            # region BO伝票の未作成判定
                            if (jnl.BOShipmentCnt1 == 0)
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            string slipCdString = GetHondaBoSlipString(jnl.SourceShipment);
                            tempSalesSlipNum = jnl.SalesSlipNum + slipCdString;

                            //相手先伝票番号
                            partySaleSlipNum = jnl.BOSlipNo1;
                            // ADD 2015/07/24 陳艶丹 For Redmine #46880---------------------->>>>>
                            // e-Partsで発注する際に、メーカーフォローの場合は相手先伝票番号１に「-F」を付足す。
                            if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502
                                && !string.IsNullOrEmpty(jnl.BOSlipNo1))
                            {
                                partySaleSlipNum = jnl.BOSlipNo1 + "-F";
                            }
                            // ADD 2015/07/24 陳艶丹 For Redmine #46880----------------------<<<<<

                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = GetSlipCdFromBoSlipString(slipCdString);
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = acceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = jnl.UOESectOutGoodsCnt;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = jnl.BOShipmentCnt1;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = jnl.BOShipmentCnt1;

                            //明細種別
                            prtSalesDetail.detailCd = prtSalesDetail.prtShipmentCnt == 0 ? (int)PrtSalesDetail.ctDetailCd.ct_Zero : (int)PrtSalesDetail.ctDetailCd.ct_Normal;
                            #endregion
                            #endregion
                            break;

                        //------------------------------------------------------
                        // ゼロ伝票
                        //------------------------------------------------------
                        case 2:
                            # region ゼロ伝票
                            //------------------------------------------------------
                            // ゼロ伝票の未作成判定
                            //------------------------------------------------------
                            # region ゼロ伝票の未作成判定
                            if ((CheckZeroSlip() != true)
                            || (bOShipmentCnt != 0)
                            || (jnl.UOESectOutGoodsCnt != 0))
                            {
                                continue;
                            }
                            #endregion

                            //------------------------------------------------------
                            // ＫＥＹ項目値の算出
                            //------------------------------------------------------
                            # region ＫＥＹ項目値の算出
                            //売上伝票番号（仮）← <jnl>売上伝票番号
                            tempSalesSlipNum = jnl.SalesSlipNum + (string)UoeSales.ct_strZero;

                            //相手先伝票番号
                            partySaleSlipNum = "";
                            #endregion

                            //------------------------------------------------------
                            // 売上データ部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上データ部(追加項目)の算出
                            //UOE伝票種別
                            slipCd = (Int32)UoeSales.ctSlipCd.ct_Zero; //9:ゼロ伝票
                            #endregion

                            //------------------------------------------------------
                            // 売上明細部(追加項目)の算出
                            //------------------------------------------------------
                            # region 売上明細部(追加項目)の算出
                            //(印刷用)受注数
                            prtSalesDetail.prtAcceptAnOrderCnt = jnl.AcceptAnOrderCnt;

                            //(印刷用)拠点出庫数
                            prtSalesDetail.prtUOESectOutGoodsCnt = 0;

                            //(印刷用)BO出庫数
                            prtSalesDetail.prtBOShipmentCnt = 0;

                            //(印刷用)出庫数
                            prtSalesDetail.prtShipmentCnt = 0;

                            //明細種別
                            prtSalesDetail.detailCd = (int)PrtSalesDetail.ctDetailCd.ct_Zero;
                            #endregion
                            #endregion
                            break;
                    }

                    //------------------------------------------------------
                    // 売上明細の設定
                    //------------------------------------------------------
                    # region 売上明細の設定
                    //売上明細の更新処理
                    status = WriteDtTblSalesDetail(
                                    jnl,                //送受信JNLクラス
                                    tempSalesSlipNum,   //売上伝票番号（仮）
                                    tempSalesSlipDtlNum,//売上明細通番（仮）
                                    partySaleSlipNum,   //相手先伝票番号
                                    prtSalesDetail,     //(印刷用)UOE売上明細クラス
                                    out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    //------------------------------------------------------
                    // 売上データの設定
                    //------------------------------------------------------
                    # region 売上データの設定
                    //売上データの更新処理
                    status = WriteDtTblSalesSlip(
                                    jnl,                //送受信JNLクラス
                                    tempSalesSlipNum,   //売上伝票番号（仮）
                                    prtSalesDetail.prtShipmentCnt,        //出庫数合計
                                    slipCd,             //UOE伝票種別
                                    out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    //売上明細通番（仮）のインクリメント
                    tempSalesSlipDtlNum++;

                    //受注数の算出
                    acceptAnOrderCnt = acceptAnOrderCnt - prtSalesDetail.prtShipmentCnt;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region (ＨＯＮＤＡ用)ＢＯ伝票区分取得処理
        /// <summary>
        /// (ＨＯＮＤＡ用)ＢＯ伝票区分取得処理
        /// </summary>
        /// <param name="sourceShipment">出荷元</param>
        /// <returns>BO1,BO2,BO3,＜出荷元文字列＞</returns>
        private string GetHondaBoSlipString(string sourceShipment)
        {
            string returnString = "";

            //(分割用)仕入データのDictionary追加
            if (_hondaSlipNoDictionary.ContainsKey(sourceShipment) == true)
            {
                returnString = _hondaSlipNoDictionary[sourceShipment];
            }
            else
            {
                switch (_hondaSlipNoDictionary.Count)
                {
                    case 0:
                        returnString = (string)UoeSales.ct_strBO1;
                        break;
                    case 1:
                        returnString = (string)UoeSales.ct_strBO2;
                        break;
                    case 2:
                        returnString = (string)UoeSales.ct_strBO3;
                        break;
                    default:
                        returnString = sourceShipment;
                        break;
                }
                _hondaSlipNoDictionary.Add(sourceShipment, returnString);
            }
            return (returnString);
        }
        #endregion

        # region UOE伝票種別文字列の取得
        /// <summary>
        /// UOE伝票種別文字列の取得
        /// </summary>
        /// <param name="cd"></param>
        /// <returns></returns>
        private string GetSlipString(int cd)
        {
            string returnString = "";

            switch (cd)
            {
                case (int)UoeSales.ctSlipCd.ct_Section: //確認伝票
                    returnString = (string)UoeSales.ct_strSection;
                    break;
                case (int)UoeSales.ctSlipCd.ct_BO1:     //BO1伝票
                    returnString = (string)UoeSales.ct_strBO1;
                    break;
                case (int)UoeSales.ctSlipCd.ct_BO2:     //BO2伝票
                    returnString = (string)UoeSales.ct_strBO2;
                    break;
                case (int)UoeSales.ctSlipCd.ct_BO3:     //BO3伝票
                    returnString = (string)UoeSales.ct_strBO3;
                    break;
                case (int)UoeSales.ctSlipCd.ct_EO:      //EO伝票
                    returnString = (string)UoeSales.ct_strEO;
                    break;
                case (int)UoeSales.ctSlipCd.ct_Maker:   //メーカーフォロー伝票
                    returnString = (string)UoeSales.ct_strMaker;
                    break;
                case (int)UoeSales.ctSlipCd.ct_OtherBO: //他BO伝票
                    returnString = (string)UoeSales.ct_strOtherBO;
                    break;
                case (int)UoeSales.ctSlipCd.ct_Zero:    //ゼロ伝票
                    returnString = (string)UoeSales.ct_strZero;
                    break;
                default:
                    returnString = "";
                    break;
            }
            return (returnString);
        }
        #endregion

        # region UOE伝票種別取得
        /// <summary>
        /// UOE伝票種別取得
        /// </summary>
        /// <param name="slipCdString">BO1,BO2,BO3</param>
        /// <returns>UOE伝票種別</returns>
        private int GetSlipCdFromBoSlipString(string slipCdString)
        {
            int cd = (int)UoeSales.ctSlipCd.ct_Section;

            switch (slipCdString)
            {
                case (string)UoeSales.ct_strSection:
                    cd = (int)UoeSales.ctSlipCd.ct_Section;
                    break;
                case (string)UoeSales.ct_strBO1:
                    cd = (int)UoeSales.ctSlipCd.ct_BO1;
                    break;
                case (string)UoeSales.ct_strBO2:
                    cd = (int)UoeSales.ctSlipCd.ct_BO2;
                    break;
                case (string)UoeSales.ct_strBO3:
                    cd = (int)UoeSales.ctSlipCd.ct_BO3;
                    break;
                case (string)UoeSales.ct_strEO:
                    cd = (int)UoeSales.ctSlipCd.ct_EO;
                    break;
                case (string)UoeSales.ct_strMaker:
                    cd = (int)UoeSales.ctSlipCd.ct_Maker;
                    break;
                case (string)UoeSales.ct_strZero:
                    cd = (int)UoeSales.ctSlipCd.ct_Zero;
                    break;
                default:
                    cd = (int)UoeSales.ctSlipCd.ct_OtherBO;
                    break;
            }
            return (cd);
        }
        #endregion

        # region 伝票出力区分のチェック
        /// <summary>
        /// ゼロ伝票チェック
        /// </summary>
        /// <returns>true:あり false:なし</returns>
        private bool CheckZeroSlip()
        {
            return (CheckSlipOutputDivCd(0));
        }

        /// <summary>
        /// ゼロ明細チェック
        /// </summary>
        /// <returns>true:あり false:なし</returns>
        private bool CheckZeroDtl()
        {
            return (CheckSlipOutputDivCd(1));
        }
        /// <summary>
        /// 合算チェック
        /// </summary>
        /// <returns>true:あり false:なし</returns>
        private bool CheckAddingUp()
        {
            return (CheckSlipOutputDivCd(2));
        }

        /// <summary>
        /// 伝票出力区分のチェック
        /// </summary>
        /// <param name="cd">0:ゼロ伝票 1:ゼロ明細 2:合算</param>
        /// <returns>true:あり false:なし</returns>
        private bool CheckSlipOutputDivCd(int cd)
        {
            # region 変数の初期化
            //変数の初期化
            bool returnBool = true;
            bool zeroSlip = true;
            bool zeroDtl = true;
            bool AddingUp = true;
            #endregion

            # region 伝票出力区分
            //伝票出力区分
            switch (_uoeSndRcvJnlAcs.uOESetting.SlipOutputDivCd)
            {
                //1:確認伝票・ﾌｫﾛｰ伝票・ｾﾞﾛ伝票有り
                case 1:
                    zeroSlip = true;
                    zeroDtl = true;
                    AddingUp = false;
                    break;
                //2:確認伝票・ﾌｫﾛｰ伝票有り
                case 2:
                    zeroSlip = false;
                    zeroDtl = true;
                    AddingUp = false;
                    break;
                //3:確認伝票・ﾌｫﾛｰ伝票(合算）
                case 3:
                    zeroSlip = false;
                    zeroDtl = true;
                    AddingUp = true;
                    break;
                //4:確認伝票(ｾﾞﾛ明細印字なし)・ﾌｫﾛｰ伝票・ｾﾞﾛ伝票有り
                case 4:
                    zeroSlip = true;
                    zeroDtl = false;
                    AddingUp = false;
                    break;
                //5:確認伝票(ｾﾞﾛ明細印字なし)・ﾌｫﾛｰ伝票有り
                case 5:
                    zeroSlip = false;
                    zeroDtl = false;
                    AddingUp = false;
                    break;
                //6:確認伝票(ｾﾞﾛ明細印字なし)・ﾌｫﾛｰ伝票（合算）
                case 6:
                    zeroSlip = false;
                    zeroDtl = false;
                    AddingUp = true;
                    break;
            }
            #endregion

            # region 戻り値の設定
            //戻り値の設定
            switch (cd)
            {
                //ゼロ伝票
                case 0:
                    returnBool = zeroSlip;
                    break;
                //ゼロ明細
                case 1:
                    returnBool = zeroDtl;
                    break;
                //合算
                case 2:
                    returnBool = AddingUp;
                    break;
            }
            #endregion

            return (returnBool);
        }
        #endregion

        # region ＢＯ合計数の算出
        /// <summary>
        /// ＢＯ合計数の算出
        /// </summary>
        /// <param name="jnl">送受信ＪＮＬクラス</param>
        /// <returns>ＢＯ合計数</returns>
        private int GetBOShipmentCnt(OrderSndRcvJnl jnl)
        {
            int returnCount = 
                  jnl.BOShipmentCnt1
                + jnl.BOShipmentCnt2
                + jnl.BOShipmentCnt3;

            //UOE自社設定ﾏｽﾀのﾒｰｶｰﾌｫﾛｰ計上区分が受注の場合には加算しない
            if (_uoeSndRcvJnlAcs.uOESetting.MakerFollowAddUpDiv != (int)EnumUoeConst.ctMakerFollowAddUpDiv.ct_Order)
            {
                returnCount = returnCount + jnl.EOAlwcCount + jnl.MakerFollowCnt;
            }

            return (returnCount);
        }
        #endregion

        # region ■ 仕入関連設定処理
        #region 仕入データの更新設定処理
        /// <summary>
        /// 仕入データの更新設定処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        // upd K2012/06/20 >>>
        //private int UpDtStockProc(out string message)
        private int UpDtStockProc(out string message, ref int systemDivCd)
        // upd K2012/06/20 <<<
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //-----------------------------------------------------------
                // フラグ初期化
                //-----------------------------------------------------------
                #region フラグ初期化
                //現在処理中のオンライン番号
                int savOnlineNo = 0;

                //共通伝票番号Dictionaryのクリア
                _commonSlipNoDictionary.Clear();

                //共通伝票行番号
                int commonSlipRowNo = 0;
                #endregion

                //-----------------------------------------------------------
                // 送受信JNLの処理対象レコードの絞込処理
                //-----------------------------------------------------------
                #region 送受信JNLの処理対象レコードの絞込処理
                //送受信JNLの処理対象レコードの絞込処理
                //送受信JNL上の送信FLGが"9:正常終了"のﾚｺｰﾄﾞが処理対象
                string filterString = "DataSendCode = '9'";
                string sortString = "OnlineNo ASC, OnlineRowNo ASC";

                DataRow[] rows = OrderTable.Select(filterString, sortString);
                #endregion

                foreach (DataRow dataRow in rows)
                {
                    //-----------------------------------------------------------
                    // 更新対象のチェック
                    //-----------------------------------------------------------
                    #region 更新対象のチェック
                    //DataRow → OrderSndRcvJnlの取得
                    OrderSndRcvJnl jnl = _uoeSndRcvJnlAcs.CreateOrderJnlFromSchema(dataRow);

                    systemDivCd = jnl.SystemDivCd;  // add K2012/06/20

                    //システム区分 0:手入力 1:伝発 2:検索
                    //取寄
                    if ((jnl.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                    || ((jnl.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input) && (jnl.WarehouseCode == ""))
                    || ((jnl.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search) && (jnl.WarehouseCode == "")))
                    {
                    }
                    else
                    {
                        continue;
                    }
                    //データ送信区分「9:正常終了」ではない
                    if (jnl.DataSendCode != (int)EnumUoeConst.ctDataSendCode.ct_OK) continue;

                    //発注先マスタ値の取得
                    UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(jnl.UOESupplierCd);
                    if (uOESupplier == null) continue;
                    string commAssemblyId = uOESupplier.CommAssemblyId;		//通信アセンブリID

                    //明治産業の判定
                    if (_uoeSndRcvJnlAcs.ChkMeiji(jnl.UOESupplierCd) == true) continue;
                    #endregion

                    //-----------------------------------------------------------
                    // (展開元)仕入情報の取得
                    //-----------------------------------------------------------
                    #region (展開元)仕入情報の取得
                    //(展開元)仕入明細の取得
                    int supplierFormal = 2;
                    Guid dtlRelationGuid = jnl.DtlRelationGuid;
                    StockDetailWork stockDetailWork = null;
                    string commonSlipNo = "";

                    status = _uoeSndRcvJnlAcs.ReadStockDetailWork(StockDetailTable, supplierFormal, dtlRelationGuid, out stockDetailWork, out commonSlipNo, out message);
                    if((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    || (stockDetailWork == null)
                    || (commonSlipNo == ""))
                    {
                        continue;
                    }

                    //(展開元)仕入データの取得
                    StockSlipWork srcStockSlipWork = _uoeSndRcvJnlAcs.ReadStockSlipWork(StockSlipTable, supplierFormal, commonSlipNo, out message);
                    if (srcStockSlipWork == null)
                    {
                        continue;
                    }
                    #endregion

                    #region オンライン番号が変更された場合
                    //UOE発注番号が変更された場合
                    if (savOnlineNo != jnl.OnlineNo)
                    {
                        #region (分割用)仕入データの追加作成
                        //(分割用)仕入データの追加作成
                        status = uoeStockSlipCreate(out message);
                        if(status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            return(status);
                        }
                        #endregion

                        #region フラグ初期化
                        //現在処理中のオンライン番号を保存
                        savOnlineNo = jnl.OnlineNo;

                        //共通伝票番号Dictionaryのクリア
                        _commonSlipNoDictionary.Clear();

                        //共通伝票行番号のクリア
                        commonSlipRowNo = 0;
                        #endregion
                    }
                    #endregion

                    //-----------------------------------------------------------
                    // 拠点伝票・ＢＯ伝票処理
                    //-----------------------------------------------------------
                    #region 拠点伝票・ＢＯ伝票処理
                    string keyPartySaleSlipNum = "";    //相手先伝票番号ＫＥＹ情報

                    //処理対象伝票最大数の設定
                    int loopMax = 0;
                    // 2009/05/25 START >>>>>>
                    //if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501) loopMax = 2;//ホンダ専用処理
                    //else                                                                            loopMax = 4;//共通処理(ホンダ以外)

                    if((uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501)
                    || (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502))
                    {
                        loopMax = 2;//ホンダ専用処理
                    }
                    else
                    {
                        loopMax = 4;//共通処理(ホンダ以外)
                    }
                    // 2009/05/25 END   <<<<<<
                    
                    //拠点伝票・ＢＯ伝票処理
                    //boDiv:BO区分 0:拠点出庫 1:BO1 2:BO2 3:BO3
                    for (int boDiv = 0; boDiv < loopMax; boDiv++)
                    {
                        #region 出庫数判定処理
                        //出庫数判定処理
                        //ホンダ専用処理
                        // 2009/05/25 START >>>>>>
                        //if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501)

                        if ((uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0501)
                        || (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502))
                        // 2009/05/25 END   <<<<<<
                        {
                            #region 出庫数判定(ホンダ専用処理)
                            //出庫数判定
                            switch (boDiv)
                            {
                                //拠点出庫分
                                case 0:
                                    if (jnl.UOESectOutGoodsCnt == 0) continue;
                                    // 2009/05/25 START >>>>>>
                                    //keyPartySaleSlipNum = jnl.UOESectionSlipNo + "-" + uOESupplier.HondaSectionCode;

                                    if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502)
                                    {
                                        keyPartySaleSlipNum = jnl.UOESectionSlipNo;
                                    }
                                    else
                                    {
                                        keyPartySaleSlipNum = jnl.UOESectionSlipNo + "-" + uOESupplier.HondaSectionCode;
                                    }
                                    // 2009/05/25 END   <<<<<<
                                    break;
                                //ＢＯ出庫分
                                case 1:
                                    if (jnl.BOShipmentCnt1 == 0) continue;
                                    string sourceShipment = jnl.SourceShipment.Trim() == "" ? "F" : jnl.SourceShipment;

                                    // 2009/05/25 START >>>>>>
                                    if (uOESupplier.CommAssemblyId == (string)EnumUoeConst.ctCommAssemblyId_0502)
                                    {
                                        sourceShipment = "F";
                                    }
                                    // 2009/05/25 END   <<<<<<
                                    //---ADD 2011/11/08 ---------------------->>>>>
                                    if (!string.IsNullOrEmpty(jnl.BOSlipNo1))
                                    {
                                        keyPartySaleSlipNum = jnl.BOSlipNo1 + "-" + sourceShipment;
                                    }
                                    //---ADD 2011/11/08 ----------------------<<<<
                                    //keyPartySaleSlipNum = jnl.BOSlipNo1 + "-" + sourceShipment; // DEL 2011/11/08
                                    break;
                                default:
                                    continue;
                            }
                            #endregion
                        }
                        //共通処理(ホンダ以外)
                        else
                        {
                            #region 出庫数判定(ホンダ以外の共通処理)
                            //出庫数判定
                            switch (boDiv)
                            {
                                //拠点出庫分
                                case 0:
                                    if (jnl.UOESectOutGoodsCnt == 0) continue;
                                    // ----- ADD 2010/05/10 --------------------------->>>>>
                                    if (string.IsNullOrEmpty(jnl.UOESectionSlipNo)) continue;
                                    if (jnl.UOESectionSlipNo.Trim() == string.Empty) continue;
                                    // ----- ADD 2010/05/10 ---------------------------<<<<<
                                    keyPartySaleSlipNum = jnl.UOESectionSlipNo;
                                    break;
                                //BO1出庫分
                                case 1:
                                    if (jnl.BOShipmentCnt1 == 0) continue;
                                    // ----- ADD 2010/05/10 --------------------------->>>>>
                                    if (string.IsNullOrEmpty(jnl.BOSlipNo1)) continue;
                                    if (jnl.BOSlipNo1.Trim() == string.Empty) continue;
                                    // ----- ADD 2010/05/10 ---------------------------<<<<<
                                    keyPartySaleSlipNum = jnl.BOSlipNo1;
                                    break;
                                //BO2出庫分
                                case 2:
                                    if (jnl.BOShipmentCnt2 == 0) continue;
                                    // ----- ADD 2010/05/10 --------------------------->>>>>
                                    if (string.IsNullOrEmpty(jnl.BOSlipNo2)) continue;
                                    if (jnl.BOSlipNo2.Trim() == string.Empty) continue;
                                    // ----- ADD 2010/05/10 ---------------------------<<<<<
                                    keyPartySaleSlipNum = jnl.BOSlipNo2;
                                    break;
                                //BO3出庫分
                                case 3:
                                    if (jnl.BOShipmentCnt3 == 0) continue;
                                    // ----- ADD 2010/05/10 --------------------------->>>>>
                                    if (string.IsNullOrEmpty(jnl.BOSlipNo3)) continue;
                                    if (jnl.BOSlipNo3.Trim() == string.Empty) continue;
                                    // ----- ADD 2010/05/10 ---------------------------<<<<<
                                    keyPartySaleSlipNum = jnl.BOSlipNo3;
                                    break;
                                default:
                                    continue;
                            }
                            #endregion
                        }
                        #endregion

                        //-----------------------------------------------------------
                        // (分割用)仕入明細の追加作成
                        //-----------------------------------------------------------
                        #region (分割用)仕入明細の追加作成
                        //更新クラスの算出
                        StockDetailWork uoeStockDetailWork = GetStockDetailWork(
                                                                    stockDetailWork,
                                                                    jnl,
                                                                    boDiv,
                                                                    uOESupplier,
                                                                    keyPartySaleSlipNum);

                        //仕入明細の追加＜StockDetailWork→データーテーブル＞
                        string uoeCommonSlipNo = jnl.OnlineNo.ToString("d9") + keyPartySaleSlipNum;
                        commonSlipRowNo++;

                        status = _uoeSndRcvJnlAcs.InsertTableFromStockDetailWork(
                                                UoeStockDetailTable,
                                                uoeStockDetailWork,
                                                uoeCommonSlipNo,
                                                commonSlipRowNo,
                                                out message);
                        #endregion

                        # region (分割用)仕入データのDictionary追加
                        //(分割用)仕入データのDictionary追加
                        if (_commonSlipNoDictionary.ContainsKey(uoeCommonSlipNo) != true)
                        {
                            StockSlipWork stockSlipWork = srcStockSlipWork.Clone();
                            SetStockSlip(ref stockSlipWork, jnl, keyPartySaleSlipNum);
                            _commonSlipNoDictionary.Add(uoeCommonSlipNo, stockSlipWork);
                        }
                        #endregion
                    }
                    #endregion
                }

                //-----------------------------------------------------------
                // (分割用)仕入データの追加作成
                //-----------------------------------------------------------
                #region (分割用)仕入データの追加作成
                status = uoeStockSlipCreate(out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                #endregion

                //-----------------------------------------------------------
                // 仕入明細データに行番号を設定
                //-----------------------------------------------------------
                #region 仕入明細データに行番号を設定
                status = SettingRowNoFromStock(out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                #endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region 仕入明細データに行番号を設定
        /// <summary>
        /// 仕入明細データに行番号を設定
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SettingRowNoFromStock(out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                //-----------------------------------------------------------
                // 仕入データDataViewの作成
                //-----------------------------------------------------------
                # region 仕入データDataViewの作成
                Int32 supplierFormal = 0;   //0:仕入,1:入荷,2:発注　（受注ステータス）
                string rowFilterText = string.Format("{0} = {1}",
                                                StockSlipSchema.ct_Col_SupplierFormal, supplierFormal);
                string sortText = string.Format("{0}, {1}",
                                                StockSlipSchema.ct_Col_SupplierFormal,
                                                StockSlipSchema.ct_Col_CommonSlipNo
                                                );
                DataView viewUoeStockSlip = new DataView(UoeStockSlipTable);
                viewUoeStockSlip.Sort = sortText;
                viewUoeStockSlip.RowFilter = rowFilterText;

                if (viewUoeStockSlip == null) return (status);
                if (viewUoeStockSlip.Count == 0) return (status);
                # endregion

                //------------------------------------------------------
                // 仕入明細データに行番号を設定
                //------------------------------------------------------
                # region 仕入明細データに行番号を設定
                foreach (DataRowView rowUoeStockSlip in viewUoeStockSlip)
                {
                    string commonSlipNo = (string)rowUoeStockSlip[StockSlipSchema.ct_Col_CommonSlipNo];
                    status = _uoeSndRcvJnlAcs.SetRowNoFromStockDetail(UoeStockDetailTable, supplierFormal, commonSlipNo, out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                }
                # endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        # region (分割用)仕入データの追加作成処理
        /// <summary>
        /// (分割用)仕入データの追加作成処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2014/01/24  汪権来</br>
        /// <br>              Redmine#41551の対応 UOE消費税対応</br>
        /// </remarks>
        private int uoeStockSlipCreate(out string message)
        {
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";

            try
            {
                if (_commonSlipNoDictionary.Count == 0)
                {
                    return(status);
                }

                foreach (KeyValuePair<string, StockSlipWork> item in _commonSlipNoDictionary)
                {
                    //-----------------------------------------------------------
                    // 仕入取得
                    //-----------------------------------------------------------
                    string commonSlipNo = item.Key;
                    StockSlipWork stockSlipWork = item.Value;
                    Int32 supplierFormal = stockSlipWork.SupplierFormal;

                    Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(stockSlipWork.SupplierCd);

                    //仕入端数処理区分
                    //1:切捨て,2:四捨五入,3:切上げ　（消費税）
                    //端数処理単位
                    StockProcMoney stockProcMoney = this._uOEOrderDtlAcs.GetStockProcMoney(
                                                                1,
                                                                supplier.StockCnsTaxFrcProcCd,
                                                                999999999);

                    stockSlipWork.StockFractionProcCd = stockProcMoney.FractionProcCd;
                    
                    //-----------------------------------------------------------
                    // 仕入明細取得
                    //-----------------------------------------------------------
                    //ArrayList uoeStockDetailWorkAry = _uoeSndRcvJnlAcs.SearchStockDetailDataTable(UoeStockDetailTable, supplierFormal, commonSlipNo);//DEL 汪権来 2014/01/24 for Redmine#41551 
                    ArrayList uoeStockDetailWorkAry = CalculateDetailPrice(UoeStockDetailTable, supplierFormal, commonSlipNo, stockSlipWork); //ADD 汪権来 2014/01/24 for Redmine#41551 
                    List<StockDetailWork> uoeStockDetailWorkList = new List<StockDetailWork>();
                    foreach (StockDetailWork stockDetailWork in uoeStockDetailWorkAry)
                    {
                        uoeStockDetailWorkList.Add(stockDetailWork);
                    }

                    //-----------------------------------------------------------
                    // 仕入データの情報算出
                    //-----------------------------------------------------------
                    StockSlipPriceCalculator.TotalPriceSetting(
                                                ref stockSlipWork,
                                                uoeStockDetailWorkList,
                                                stockProcMoney.FractionProcUnit,
                                                stockProcMoney.FractionProcCd);

                    //明細行数
                    stockSlipWork.DetailRowCount = uoeStockDetailWorkAry.Count;

                    //-----------------------------------------------------------
                    // 仕入データテーブルの更新処理
                    //-----------------------------------------------------------
                    status = _uoeSndRcvJnlAcs.InsertTableFromStockSlipWork(UoeStockSlipTable, stockSlipWork, commonSlipNo, out message);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        return (status);
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        #endregion

        // --------- ADD 汪権来 2014/01/24 for Redmine#41551 -------------- >>>>>>>
        # region 仕入明細リストの取得：ArrayList<StockDetailWork>
        /// <summary>
        /// 仕入明細リストの取得：ArrayList
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="commonSlipNo">仕入伝票番号</param>
        /// <param name="stockSlipWork">仕入Work</param>
        /// <returns></returns>
        public ArrayList CalculateDetailPrice(DataTable tbl, Int32 supplierFormal, string commonSlipNo, StockSlipWork stockSlipWork)
        {
            ArrayList returnStockDetailAry = new ArrayList();
            try
            {
                string rowFilterText = string.Format("{0} = {1} AND {2} = '{3}'",
                                                StockDetailSchema.ct_Col_SupplierFormal, supplierFormal,
                                                StockDetailSchema.ct_Col_CommonSlipNo, commonSlipNo);

                string sortText = string.Format("{0}, {1}, {2}, {3}",
                    StockDetailSchema.ct_Col_EnterpriseCode,
                    StockDetailSchema.ct_Col_SupplierFormal,
                    StockDetailSchema.ct_Col_CommonSlipNo,
                    StockDetailSchema.ct_Col_CommonSlipRowNo);

                DataView viewStockDetail = new DataView(tbl);
                viewStockDetail.Sort = sortText;
                viewStockDetail.RowFilter = rowFilterText;

                if (viewStockDetail.Count > 0)
                {
                    foreach (DataRowView rowStockDetail in viewStockDetail)
                    {
                        CalculatePrice(stockSlipWork, rowStockDetail);

                        StockDetailWork stockDetailWork = _uoeSndRcvJnlAcs.CreateStockDetailWorkFromSchema(rowStockDetail.Row);
                        returnStockDetailAry.Add(stockDetailWork);
                    }
                }
            }
            catch (Exception)
            {
                returnStockDetailAry = null;
            }
            return (returnStockDetailAry);
        }
        # endregion

        # region
        /// <summary>
        /// 仕入明細の税込価格再計算
        /// </summary>
        /// <param name="stockSlipWork">仕入Work</param>
        /// <param name="rowStockDetail">仕入明細Detail</param>
        /// <returns></returns>
        private void CalculatePrice(StockSlipWork stockSlipWork, DataRowView rowStockDetail)
        {   //-----------------------------------------------------------
            // 定価の算出
            //-----------------------------------------------------------
            //税込み
            rowStockDetail.Row[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(
                (double)rowStockDetail.Row[StockDetailSchema.ct_Col_ListPriceTaxExcFl],
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_TaxationCode],
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_FracProcStckUnPrc],
                stockSlipWork.StockDate);

            //-----------------------------------------------------------
            // 仕入単価の算出
            //----------------------------------------------------------- 
            #region 仕入単価

            //仕入単価（税込，浮動） 
            rowStockDetail.Row[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = _uOEOrderDtlAcs.GetStockPriceTaxInc(
                (double)rowStockDetail.Row[StockDetailSchema.ct_Col_StockUnitPriceFl],
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_TaxationCode],
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_FracProcStckUnPrc],
                stockSlipWork.StockDate);
            #endregion

            //-----------------------------------------------------------
            // 仕入金額の算出
            //-----------------------------------------------------------
            #region 仕入金額
            long stockPriceTaxInc = 0;
            long stockPriceTaxExc = 0;
            long stockPriceConsTax = 0;
            bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                (double)rowStockDetail.Row[StockDetailSchema.ct_Col_StockCount],
                (double)rowStockDetail.Row[StockDetailSchema.ct_Col_StockUnitPriceFl],
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_TaxationCode],
                stockSlipWork.StockFractionProcCd,
                (Int32)rowStockDetail.Row[StockDetailSchema.ct_Col_FracProcStckUnPrc],
                stockSlipWork.StockDate,
                out stockPriceTaxInc,
                out stockPriceTaxExc,
                out stockPriceConsTax);

            if (bStatus == true)
            {
                //仕入金額（税抜き）
                rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxExc] = stockPriceTaxExc;

                //仕入金額（税込み）
                rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxInc] = stockPriceTaxInc;
            }
            else
            {
                rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxExc] = 0;
                rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxInc] = 0;
            }
            #endregion

            //-----------------------------------------------------------
            // 消費税の算出
            //-----------------------------------------------------------
            #region 消費税
            //仕入金額消費税額
            rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceConsTax] =
                (long)rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxInc] -
                (long)rowStockDetail.Row[StockDetailSchema.ct_Col_StockPriceTaxExc];
            #endregion
        }
        # endregion
        // --------- ADD 汪権来 2014/01/24 for Redmine#41551 -------------- <<<<<<

        # region 送受信ＪＮＬより仕入データクラスを取得する(送受信ＪＮＬ→仕入クラス)
        /// <summary>
        /// 送受信ＪＮＬより仕入クラスを取得する(送受信ＪＮＬ→仕入クラス)
        /// </summary>
        /// <param name="stockSlipWork">仕入データ</param>
        /// <param name="jnl">送受信ＪＮＬ</param>
        /// <param name="partySaleSlipNum">相手先伝票番号</param>
        /// <remarks>
        /// <br>Update Note : 2014/01/24  汪権来</br>
        /// <br>              Redmine#41551の対応 UOE消費税対応</br>
        /// </remarks>
        private void SetStockSlip(ref StockSlipWork stockSlipWork, OrderSndRcvJnl jnl, string partySaleSlipNum)
        {
            //-----------------------------------------------------------
            // 仕入データＫＥＹ項目の設定
            //-----------------------------------------------------------
            # region 仕入データＫＥＹ項目の設定
            stockSlipWork.SupplierFormal = 0;   //仕入形式 0:仕入,1:入荷,2:発注　（受注ステータス）
            stockSlipWork.SupplierSlipNo = 0;   //仕入伝票番号

            //ヘッダー項目初期化
            stockSlipWork.CreateDateTime = DateTime.MinValue;
            stockSlipWork.UpdateDateTime = DateTime.MinValue;
            stockSlipWork.FileHeaderGuid = Guid.Empty;
            stockSlipWork.UpdEmployeeCode = "";
            stockSlipWork.UpdAssemblyId1 = "";
            stockSlipWork.UpdAssemblyId2 = "";
            stockSlipWork.LogicalDeleteCode = 0;
            # endregion

            //-----------------------------------------------------------
            // 仕入計上日付
            //-----------------------------------------------------------
            #region 仕入計上日付
            stockSlipWork.InputDay = DateTime.Now;          //入力日
            stockSlipWork.ArrivalGoodsDay = DateTime.Now;   //入荷日

            //手入力・検索
            //UOE自社設定ﾏｽﾀの計上日付区分:システム日付
            if((_uoeSndRcvJnlAcs.uOESetting.AddUpADateDiv == (int)EnumUoeConst.ctAddUpADateDiv.ct_System)
            || (jnl.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search)
            || (jnl.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input))
            {
                stockSlipWork.StockDate = DateTime.Now;
            }
            //伝発
            //UOE自社設定ﾏｽﾀの計上日付区分:売上日付
            else
            {
                stockSlipWork.StockDate = jnl.SalesDate;
            }

            //支払先コードにて仕入月次及び仕入締次の締日チェック
            //締済の場合には今回締処理日+1日をｾｯﾄする
            //仕入締次の締日取得処理
            if ((stockSlipWork.StockAddUpSectionCd.Trim() != "") && (stockSlipWork.PayeeCode != 0))
            {
                if (_totalDayCalculator.CheckPayment(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, stockSlipWork.StockDate) != false)
                {
                    DateTime prevTotalDay = DateTime.MinValue;
                    DateTime currentTotalDay = DateTime.MinValue;

                    if (_totalDayCalculator.GetTotalDayPayment(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, out prevTotalDay, out currentTotalDay) == 0)
                    {
                        DateTime setDateTime = prevTotalDay.AddDays(1);
                        stockSlipWork.StockDate = setDateTime;
                    }
                }

                //仕入月次の締日取得処理
                if (_totalDayCalculator.CheckMonthlyAccPay(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, stockSlipWork.StockDate) != false)
                {
                    DateTime prevTotalDay = DateTime.MinValue;
                    DateTime currentTotalDay = DateTime.MinValue;

                    if (_totalDayCalculator.GetTotalDayMonthlyAccPay(stockSlipWork.StockAddUpSectionCd, stockSlipWork.PayeeCode, out prevTotalDay, out currentTotalDay) == 0)
                    {
                        DateTime setDateTime = prevTotalDay.AddDays(1);
                        stockSlipWork.StockDate = setDateTime;
                    }
                }
            }

            //仕入計上日付
            stockSlipWork.StockAddUpADate = stockSlipWork.StockDate;
            #endregion

            //-----------------------------------------------------------
            // 仕入先情報の設定
            //-----------------------------------------------------------
            #region 仕入先情報の設定
            Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(jnl.SupplierCd);

            stockSlipWork.SupplierCd = jnl.SupplierCd;
            if(supplier == null)
            {
                stockSlipWork.SupplierNm1 = "";
                stockSlipWork.SupplierNm2 = "";
                stockSlipWork.SupplierSnm = "";
                stockSlipWork.SuppCTaxLayCd = 0;
                stockSlipWork.SuppTtlAmntDspWayCd = 0;
            }
            else
            {
                //仕入先名称
                stockSlipWork.SupplierNm1 = supplier.SupplierNm1;
                stockSlipWork.SupplierNm2 = supplier.SupplierNm2;
                stockSlipWork.SupplierSnm = supplier.SupplierSnm;

                //仕入先消費税転嫁方式コード
                //0:伝票単位1:明細単位2:支払親 3:支払子 9:非課税
                stockSlipWork.SuppCTaxLayCd = supplier.SuppCTaxLayCd;

                //仕入先総額表示方法区分
                //0:総額表示しない（税抜き）,1:総額表示する（税込み）
                stockSlipWork.SuppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd;
            }
            #endregion

            //仕入先消費税税率
            //stockSlipWork.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(DateTime.Now);// DEL 汪権来 2014/01/24 for Redmine#41551 

            stockSlipWork.SupplierConsTaxRate = this._uOEOrderDtlAcs.GetTaxRate(stockSlipWork.StockAddUpADate);// ADD 汪権来 2014/01/24 for Redmine#41551 

            //仕入商品区分
            //0:商品,1:商品外,2:消費税調整,3:残高調整,4:買掛用消費税調整,
            //5:買掛用残高調整,6:合計入力,10:買用消費税調整(自動),11:相殺,12:相殺(自動)
            stockSlipWork.StockGoodsCd = 0;

            //-----------------------------------------------------------
            // 相手先伝票番号
            //-----------------------------------------------------------
            #region 相手先伝票番号
            stockSlipWork.PartySaleSlipNum = partySaleSlipNum;
            #endregion
        }
        #endregion

        # region 送受信ＪＮＬより仕入明細クラスを取得する(送受信ＪＮＬ→仕入明細クラス)
        /// <summary>
        /// 仕入明細クラスを取得する(送受信ＪＮＬ→仕入明細クラス)
        /// </summary>
        /// <param name="jnl">送受信ＪＮＬ</param>
        /// <param name="boDiv">ＢＯ区分 0:拠点出庫 1:BO1出庫 2:BO2出庫 3:BO3出庫</param>
        /// <param name="uOESupplier">発注先マスタ</param>
        /// <param name="tempSalesSlipNum">伝票番号</param>
        /// <returns>仕入明細クラス</returns>
        private StockDetailWork GetStockDetailWork(StockDetailWork srcStockDetailWork, OrderSndRcvJnl jnl, int boDiv, UOESupplier uOESupplier, string partySaleSlipNum)
        {
            StockDetailWork dstStockDetailWork = srcStockDetailWork.Clone();

            //-----------------------------------------------------------
            // 仕入明細ＫＥＹ項目の設定
            //-----------------------------------------------------------
            #region 仕入明細ＫＥＹ項目の設定
            //仕入形式（元）0:仕入,1:入荷,2:発注　（受注ステータス）
            dstStockDetailWork.SupplierFormalSrc = dstStockDetailWork.SupplierFormal;

            //仕入明細通番（元）
            dstStockDetailWork.StockSlipDtlNumSrc = dstStockDetailWork.StockSlipDtlNum;

            //仕入形式 0:仕入,1:入荷,2:発注　（受注ステータス）
            dstStockDetailWork.SupplierFormal = 0;

            //仕入伝票番号
            dstStockDetailWork.SupplierSlipNo = 0;

            //仕入明細通番
            dstStockDetailWork.StockSlipDtlNum = 0;

            //発注書発行済区分
            dstStockDetailWork.OrderFormIssuedDiv = 0;

            //受注ステータス（同時）
            dstStockDetailWork.AcptAnOdrStatusSync = 30;

            //売上明細通番（同時）
            dstStockDetailWork.SalesSlipDtlNumSync = 0;

            //明細関連付けGUID
            //if (this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().SalesStockDiv != 0)
            //{
                dstStockDetailWork.DtlRelationGuid = GetLinkGuidSalesStock(jnl.OnlineNo, jnl.OnlineRowNo, partySaleSlipNum);
            //}

            //ヘッダー項目初期化
            dstStockDetailWork.CreateDateTime = DateTime.MinValue;
            dstStockDetailWork.UpdateDateTime = DateTime.MinValue;
            dstStockDetailWork.FileHeaderGuid = Guid.Empty;
            dstStockDetailWork.UpdEmployeeCode = "";
            dstStockDetailWork.UpdAssemblyId1 = "";
            dstStockDetailWork.UpdAssemblyId2 = "";
            dstStockDetailWork.LogicalDeleteCode = 0;
            #endregion
            
            //-----------------------------------------------------------
            // 仕入先情報の設定
            //-----------------------------------------------------------
            #region 仕入先情報の設定
            Supplier supplier = _uoeSndRcvCtlInitAcs.GetSupplier(jnl.SupplierCd);
            dstStockDetailWork.SupplierCd = jnl.SupplierCd;
            dstStockDetailWork.SupplierSnm = jnl.SupplierSnm;
            #endregion

            //-----------------------------------------------------------
            // 品番の算出
            //-----------------------------------------------------------
            #region 品番
            //代替品番採用
            if((uOESupplier.SubstPartsNoDiv == (int)EnumUoeConst.ctSubstPartsNoDiv.ct_SubstParts)
            && (jnl.SubstPartsNo.Trim() != ""))
            {
                dstStockDetailWork.GoodsNo = jnl.SubstPartsNo;
                dstStockDetailWork.GoodsMakerCd = jnl.AnswerMakerCd;	// 回答メーカーコード

                //メーカー検索
                MakerUMnt makerUMnt = new MakerUMnt();
                int status = this._uoeSndRcvCtlInitAcs.GetMakerInf(jnl.AnswerMakerCd, out makerUMnt);
                if(status == 0)
                {
                    dstStockDetailWork.MakerName = makerUMnt.MakerName;             //メーカー名称
                    dstStockDetailWork.MakerKanaName = makerUMnt.MakerKanaName;     //メーカーカナ名称
                    dstStockDetailWork.CmpltMakerKanaName = "";                     //メーカーカナ名称（一式）

                    //品番検索
                    List<GoodsUnitData> list = null;

                    status = this._uoeSndRcvCtlInitAcs.SearchPartsFromGoodsNoForMstInf(
                        dstStockDetailWork.GoodsMakerCd,
                        dstStockDetailWork.GoodsNo,
                        out list);

                    if ((status == 0) && (list != null))
                    {
                        dstStockDetailWork.GoodsNameKana = list[0].GoodsNameKana;               //商品名称カナ
                        dstStockDetailWork.GoodsLGroup = list[0].GoodsLGroup;                   //商品大分類コード
                        dstStockDetailWork.GoodsLGroupName = list[0].GoodsLGroupName;           //商品大分類名称
                        dstStockDetailWork.GoodsMGroup = list[0].GoodsMGroup;                   //商品中分類コード
                        dstStockDetailWork.GoodsMGroupName = list[0].GoodsMGroupName;           //商品中分類名称
                        dstStockDetailWork.BLGroupCode = list[0].BLGroupCode;                   //BLグループコード
                        dstStockDetailWork.BLGroupName = list[0].BLGroupName;                   //BLグループコード名称
                        dstStockDetailWork.BLGoodsCode = list[0].BLGoodsCode;                   //BL商品コード
                        dstStockDetailWork.BLGoodsFullName = list[0].BLGoodsFullName;           //BL商品コード名称（全角）

                        dstStockDetailWork.EnterpriseGanreCode = list[0].EnterpriseGanreCode;   //自社分類コード
                        dstStockDetailWork.EnterpriseGanreName = list[0].EnterpriseGanreName;   //自社分類名称
                        dstStockDetailWork.TaxationCode = list[0].TaxationDivCd;
                    }
                    else
                    {
                        dstStockDetailWork.GoodsNameKana = "";        //商品名称カナ
                        dstStockDetailWork.GoodsLGroup = 0;           //商品大分類コード
                        dstStockDetailWork.GoodsLGroupName = "";      //商品大分類名称
                        dstStockDetailWork.GoodsMGroup = 0;           //商品中分類コード
                        dstStockDetailWork.GoodsMGroupName = "";      //商品中分類名称
                        dstStockDetailWork.BLGroupCode = 0;           //BLグループコード
                        dstStockDetailWork.BLGroupName = "";          //BLグループコード名称
                        dstStockDetailWork.BLGoodsCode = 0;           //BL商品コード
                        dstStockDetailWork.BLGoodsFullName = "";      //BL商品コード名称（全角）
                        dstStockDetailWork.EnterpriseGanreCode = 0;   //自社分類コード
                        dstStockDetailWork.EnterpriseGanreName = "";  //自社分類名称
                    }
                }
                else
                {
                    dstStockDetailWork.MakerName = "";            //メーカー名称
                    dstStockDetailWork.MakerKanaName = "";        //メーカーカナ名称

                    dstStockDetailWork.GoodsNameKana = "";        //商品名称カナ
                    dstStockDetailWork.GoodsLGroup = 0;           //商品大分類コード
                    dstStockDetailWork.GoodsLGroupName = "";      //商品大分類名称
                    dstStockDetailWork.GoodsMGroup = 0;           //商品中分類コード
                    dstStockDetailWork.GoodsMGroupName = "";      //商品中分類名称
                    dstStockDetailWork.BLGroupCode = 0;           //BLグループコード
                    dstStockDetailWork.BLGroupName = "";          //BLグループコード名称
                    dstStockDetailWork.BLGoodsCode = 0;           //BL商品コード
                    dstStockDetailWork.BLGoodsFullName = "";      //BL商品コード名称（全角）
                    dstStockDetailWork.EnterpriseGanreCode = 0;   //自社分類コード
                    dstStockDetailWork.EnterpriseGanreName = "";  //自社分類名称
                }
            }
            //発注品番採用
            else
            {
                dstStockDetailWork.GoodsNo = jnl.GoodsNo;
            }
            #endregion

            //-----------------------------------------------------------
            // 品名の算出
            //-----------------------------------------------------------
            #region 品名
            if ((jnl.GoodsName.Trim() == "*") && (jnl.AnswerPartsName.Trim() != ""))
            {
                dstStockDetailWork.GoodsName = jnl.AnswerPartsName;
            }
            #endregion

            //-----------------------------------------------------------
            // 出庫数の算出
            //-----------------------------------------------------------
            #region 出庫数の算出
            int count = 0;  //(算出用)出庫数
            switch (boDiv)
            {
                //拠点出庫
                case 0:
                    count = jnl.UOESectOutGoodsCnt;
                    break;
                //ＢＯ１出庫
                case 1:
                    count = jnl.BOShipmentCnt1;
                    break;
                //ＢＯ２出庫
                case 2:
                    count = jnl.BOShipmentCnt2;
                    break;
                //ＢＯ３出庫
                case 3:
                    count = jnl.BOShipmentCnt3;
                    break;
            }

            //仕入数
            dstStockDetailWork.StockCount = count;

            //発注数量
            dstStockDetailWork.OrderCnt = count;

            //発注残数
            dstStockDetailWork.OrderRemainCnt = count;
            #endregion

            //-----------------------------------------------------------
            // 課税区分の算出(0:課税,1:非課税,2:課税（内税）)
            //-----------------------------------------------------------
            #region 課税区分の算出
            int taxationCode = dstStockDetailWork.TaxationCode;

            if ((supplier.SuppCTaxLayCd == 9)
            || (supplier.SuppCTaxationCd == 1)
            || (dstStockDetailWork.TaxationCode == (int)CalculateTax.TaxationCode.TaxNone))
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            #endregion

            //-----------------------------------------------------------
            // 定価の算出
            //-----------------------------------------------------------
            #region 定価の算出
            double dstPrice = 0;
            double srcPrice = jnl.ListPrice;

            switch(uOESupplier.ListPriceUseDiv)
            {
                //0:高い方
                case (int)EnumUoeConst.ctListPriceUseDiv.ct_Hight:
                    dstPrice = jnl.AnswerListPrice <= srcPrice ? srcPrice : jnl.AnswerListPrice; 
                    break;
                //1:入力優先
                case (int)EnumUoeConst.ctListPriceUseDiv.ct_Input:
                    dstPrice = srcPrice;
                    break;
                //2:オンライン優先
                default:
                    dstPrice = jnl.AnswerListPrice;
                    break;
            }

            //税抜き
            dstStockDetailWork.ListPriceTaxExcFl = dstPrice;

            //税込み
            dstStockDetailWork.ListPriceTaxIncFl = _uOEOrderDtlAcs.GetStockPriceTaxInc(dstPrice, taxationCode, supplier.StockCnsTaxFrcProcCd);
            #endregion

            //-----------------------------------------------------------
            // 仕入単価の算出
            //-----------------------------------------------------------
            #region 仕入単価変更区分
            //仕入単価変更区分
            //変更前原価と回答原価が異なる
            if(dstStockDetailWork.BfStockUnitPriceFl != jnl.AnswerSalesUnitCost)
            {
                dstStockDetailWork.StockUnitChngDiv = 1;
            }
            //変更前原価と回答原価が同一
            else
            {
                dstStockDetailWork.StockUnitChngDiv = 0;
            }
            #endregion

            #region 仕入単価
            //仕入単価（税抜，浮動）
            dstStockDetailWork.StockUnitPriceFl = jnl.AnswerSalesUnitCost;

            //仕入単価（税込，浮動）
            dstStockDetailWork.StockUnitTaxPriceFl = _uOEOrderDtlAcs.GetStockPriceTaxInc(jnl.AnswerSalesUnitCost, taxationCode, supplier.StockCnsTaxFrcProcCd);
            #endregion

            //-----------------------------------------------------------
            // 仕入金額の算出
            //-----------------------------------------------------------
            #region 仕入金額
            long stockPriceTaxInc = 0;
            long stockPriceTaxExc = 0;
            long stockPriceConsTax = 0;

            bool bStatus = _uOEOrderDtlAcs.CalculationStockPrice(
                (double)count,
                dstStockDetailWork.StockUnitPriceFl,
                taxationCode,
                supplier.StockMoneyFrcProcCd,
                supplier.StockCnsTaxFrcProcCd,
                out stockPriceTaxInc,
                out stockPriceTaxExc,
                out stockPriceConsTax);

            if(bStatus == true)
            {
                //仕入金額（税抜き）
                dstStockDetailWork.StockPriceTaxExc = stockPriceTaxExc;

                //仕入金額（税込み）
                dstStockDetailWork.StockPriceTaxInc = stockPriceTaxInc;
            }
            else
            {
                dstStockDetailWork.StockPriceTaxExc = 0;
                dstStockDetailWork.StockPriceTaxInc = 0;
            }
            #endregion

            //-----------------------------------------------------------
            // 消費税の算出
            //-----------------------------------------------------------
            #region 消費税
            //仕入金額消費税額
            dstStockDetailWork.StockPriceConsTax = dstStockDetailWork.StockPriceTaxInc - dstStockDetailWork.StockPriceTaxExc;
            #endregion

            //-----------------------------------------------------------
            // クリア項目
            //-----------------------------------------------------------
            #region クリア項目
            dstStockDetailWork.RateSectStckUnPrc = "";      // 掛率設定拠点（仕入単価）
            dstStockDetailWork.RateDivStckUnPrc = "";       // 掛率設定区分（仕入単価）
            dstStockDetailWork.UnPrcCalcCdStckUnPrc = 0;    // 単価算出区分（仕入単価）
            dstStockDetailWork.PriceCdStckUnPrc = 0;        // 価格区分（仕入単価）
            dstStockDetailWork.StdUnPrcStckUnPrc = 0;       // 基準単価（仕入単価）
            //dstStockDetailWork.FracProcUnitStcUnPrc = 0;    // 端数処理単位（仕入単価）
            //dstStockDetailWork.FracProcStckUnPrc = 0;       // 端数処理（仕入単価）

            dstStockDetailWork.RateBLGoodsCode = 0;         // BL商品コード（掛率）
            dstStockDetailWork.RateBLGoodsName = "";        // BL商品コード名称（掛率）
            dstStockDetailWork.RateGoodsRateGrpCd = 0;      // 商品掛率グループコード（掛率）
            dstStockDetailWork.RateGoodsRateGrpNm = "";     // 商品掛率グループ名称（掛率）
            dstStockDetailWork.RateBLGroupCode = 0;         // BLグループコード（掛率）
            dstStockDetailWork.RateBLGroupName = "";        // BLグループ名称（掛率）
            #endregion

            return (dstStockDetailWork);
        }
        #endregion
        #endregion

        # region 売上仕入連動用GUIDの取得
        /// <summary>
        /// 売上仕入連動用GUIDの取得
        /// </summary>
        /// <param name="no">オンライン番号</param>
        /// <param name="rowNo">オンライン行番号</param>
        /// <param name="partySaleSlipNum">相手先伝票番号</param>
        /// <returns>Guid</returns>
        private Guid GetLinkGuidSalesStock(Int32 no, Int32 rowNo, string partySaleSlipNum)
        {
            Guid guid = Guid.NewGuid();

            //伝票合算・フォロー伝票合算
            if ((_uoeSndRcvJnlAcs.uOESetting.FollowSlipOutputDiv == (int)EnumUoeConst.ctFollowSlipOutputDiv.ct_Add)
            || (CheckAddingUp() == true)
            || (partySaleSlipNum.Trim() == ""))
            {
            }
            else
            {
                string keyNo = no.ToString("d9") + rowNo.ToString("d4") + partySaleSlipNum.Trim();
                if (_linkSalesStockDictionary.ContainsKey(keyNo) == true)
                {
                    guid = _linkSalesStockDictionary[keyNo];
                }
            }
            return (guid);
        }
        # endregion

        # region 売上仕入連動用GUIDの設定
        /// <summary>
        /// 売上仕入連動用GUIDの設定・取得
        /// </summary>
        /// <param name="no">オンライン番号</param>
        /// <param name="rowNo">オンライン行番号</param>
        /// <param name="partySaleSlipNum">相手先伝票番号</param>
        /// <param name="detailCd">明細種別　0:通常明細 9;ゼロ明細</param>
        /// <returns>Guid</returns>
        private Guid SetGuidSalesStock(Int32 no, Int32 rowNo, string partySaleSlipNum, int detailCd)
        {
            Guid guid = Guid.NewGuid();

            //伝票合算・フォロー伝票合算・ゼロ明細・ゼロ伝票・メーカーフォロー・ＥＯの場合
            if ((_uoeSndRcvJnlAcs.uOESetting.FollowSlipOutputDiv == (int)EnumUoeConst.ctFollowSlipOutputDiv.ct_Add)
            || (CheckAddingUp() == true)
            || (detailCd == (int)PrtSalesDetail.ctDetailCd.ct_Zero)
            || (partySaleSlipNum.Trim() == ""))
            {
            }
            //通常明細の場合
            else
            {
                string keyNo = no.ToString("d9") + rowNo.ToString("d4") + partySaleSlipNum.Trim();

                if (_linkSalesStockDictionary.ContainsKey(keyNo) != true)
                {
                    _linkSalesStockDictionary.Add(keyNo, guid);
                }
            }
            return(guid);
        }
        # endregion

        # endregion
    }

}

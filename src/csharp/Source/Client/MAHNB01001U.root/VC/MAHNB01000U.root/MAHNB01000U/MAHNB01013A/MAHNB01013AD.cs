using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上伝票入力(Delphi)初期値取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上伝票入力(Delphi)の初期値取得データ制御を行います。</br>
    /// <br>Programmer : LDNS</br>
    /// <br>Date       : 2010/05/29</br>
    /// <br></br>
    /// <br>Update Note : 2010/05/30 20056 對馬 大輔 </br>
    /// <br>              成果物統合(６次改良＋７次改良＋自由検索＋SCM)</br>
    /// <br>Update Note : 2010/06/26 李占川 </br>
    /// <br>              BLコード変換処理のロジックの削除</br>
    /// <br>Update Note : 2011/01/31 21024 佐々木 健</br>
    /// <br>              ①納期設定マスタのレイアウト変更対応</br>
    /// <br>              ②納期設定マスタの検索条件から拠点コードを削除</br>
    /// <br>Update Note: 2011/05/25 20056 對馬 大輔</br>
    /// <br>             SCM改良</br>
    /// <br>              1)送信確認画面に指示書番号の入力を追加</br>
    /// <br>              2)フッタ部に指示書番号の入力を追加</br>
    /// <br>              3)販売区分の入力を販売区分表示区分で制御</br>
    /// <br>Update Note : 2011/07/19  豆昌紅</br>
    /// <br>               伝票印刷設定マスタのレイアウト変更対応</br>
    /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
    /// <br>Update Note : 2011/09/27 20056 對馬 大輔</br>
    /// <br>              在庫数表示区分を参照し、現在庫数の表示制御を行う</br>
    /// <br>Update Note: 2012/05/02 20056 對馬 大輔</br>
    /// <br>管理番号   : 10801804-00 障害対応</br>
    /// <br>             改良：貸出仕入同時入力対応</br>
    /// <br>Update Note: 2012/09/13 30747 三戸　伸悟</br>
    /// <br>管理番号   : 10801804-00 2012/10/17配信分 障害一覧 №2</br>
    /// <br>             回答納期の取得を追加（SCM障害№10345修正漏れ）</br>
    /// <br>Update Note: 2012/11/13 宮本 利明</br>
    /// <br>管理番号   : 10801804-00 №1668</br>
    /// <br>             売上過去日付制御を個別オプション化（イスコまたはオプションありで日付制御）</br>
    /// <br>Update Note: 2012/12/19 西 毅</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             MAHNB01001U.Logが存在する場合ログを出力するように変更</br>
    /// <br>Update Note: 2013/01/18 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : Redmine#33797 自動入金備考区分の追加</br>
    /// <br>Update Note: 2013/02/05 脇田 靖之</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>           : BLコード０対応</br>
    /// <br>Update Note: K2013/09/20 宮本 利明</br>
    /// <br>             ㈱フタバオプション対応（個別）</br>
    /// <br>Update Note: 鄧潘ハン 2014/07/23</br>
    /// <br>管理番号   : 11070147-00</br>
    /// <br>           : SCM仕掛一覧№10659の3SCM受発注明細データに在庫状況区分のセットの対応</br>
    /// <br>Update Note: 2015/02/10  30745 吉岡</br>
    /// <br>管理番号   : 11070266-00</br>
    /// <br>           : SCM高速化 回答納期区分対応</br>
    /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
    /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
    /// <br>Update Note: 2020/11/20 陳艶丹</br>
    /// <br>管理番号   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataThirdAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiSalesSlipInputInitDataThirdAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiSalesSlipInputInitDataThirdAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataThirdAcs == null)
            {
                _delphiSalesSlipInputInitDataThirdAcs = new DelphiSalesSlipInputInitDataThirdAcs();
            }
            return _delphiSalesSlipInputInitDataThirdAcs;
        }
        # endregion

        #region ■プライベート変数
        private static DelphiSalesSlipInputInitDataThirdAcs _delphiSalesSlipInputInitDataThirdAcs;

        //private UserGuideAcs _userGuideAcs; // 2010/05/30
        private List<SubSection> _subSectionList = null;       // 部門マスタリスト
        private List<UserGdBd> _userGdBdList = null;           // ユーザーガイドマスタリスト
        private List<RateProtyMng> _rateProtyMngList = null;
        private List<SalesProcMoney> _salesProcMoneyList = null;
        private List<StockProcMoney> _stockProcMoneyList = null;
        private List<SlipPrtSet> _slipPrtSetList = null;
        private List<CustSlipMng> _custSlipMngList = null;
        private List<UOEGuideName> _uoeGuideNameList = null;
        private AcptAnOdrTtlSt _acptAnOdrTtlSt = null;         // 受発注全体管理設定マスタ
        private SalesTtlSt _salesTtlSt = null;                 // 売上全体設定マスタ
        private EstimateDefSet _estimateDefSet = null;         // 見積初期値設定マスタ
        private StockTtlSt _stockTtlSt = null;                 // 仕入在庫全体設定マスタ
        private AllDefSet _allDefSet = null;                   // 全体初期値設定マスタ
        private CompanyInf _companyInf = null;                 // 自社情報
        //>>>2010/05/30
        private SCMTtlSt _scmTtlSt = null;                     // SCM全体設定マスタ
        private List<SCMDeliDateSt> _scmDeliDateStList = null; // SCM納期設定マスタリスト
        //private List<TbsPartsCdChgWork> _tbsPartsCdChgWorkList = null; // BLコード変換マスタリスト // DEL 2010/06/26
        //<<<2010/05/30
        private StockMngTtlSt _stockMngTtlSt = null; // 在庫管理全体設定マスタ // 2011/09/27

        /// <summary>オプション情報</summary>
        private int _opt_CarMng;
        private int _opt_FreeSearch;
        private int _opt_PCC;
        private int _opt_RCLink;
        private int _opt_UOE;
        private int _opt_StockingPayment;
        private int _opt_SCM; // 2010/05/30
        private int _opt_QRMail; // 2010/05/30
        private int _opt_DateCtrl; // ADD T.Miyamoto 2012/11/13
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        private int _opt_Cpm_FutabaSlipPrtCtl; // フタバ伝票印刷制御オプション（個別）：OPT-CPM0090
        private int _opt_Cpm_FutabaWarehAlloc; // フタバ倉庫引当てオプション  （個別）：OPT-CPM0100
        private int _opt_Cpm_FutabaUOECtl;     // フタバUOEオプション         （個別）：OPT-CPM0110
        private int _opt_Cpm_FutabaOutSlipCtl; // フタバ出力済伝票制御        （個別）：OPT-CPM0120

        private int _opt_BLPRefWarehouse;   // BLP参照倉庫追加オプション：OPT-PM00230
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        private int _opt_TSP;
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<

        #endregion

        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効</summary>
            OFF = 0,
            /// <summary>有効</summary>
            ON = 1,
        }
        #endregion

        #region ■パブリック変数
        /// <summary>ローカルDB読み込み判定</summary>
        /// <br>Update Note: 2009/09/08 張凱 車輌管理機能対応</br>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif
        /// <summary>ユーザーガイド区分コード（返品理由）</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_RetGoodsReason = 91;
        /// <summary>ユーザーガイド区分コード（納品区分）</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_DeliveredGoodsDiv = 48;
        /// <summary>ユーザーガイド区分コード（販売区分）</summary>
        public static readonly int ctDIVCODE_UserGuideDivCd_SalesCode = 71;

        #endregion

        #region ■イベント
        /// <summary>売上金額処理区分設定キャッシュイベント</summary>
        public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
        /// <summary>仕入金額処理区分設定セットイベント</summary>
        public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;
        /// <summary>掛率優先管理マスタセットイベント</summary>
        public event CacheRateProtyMngListEventHandler CacheRateProtyMngList;
        #endregion

        #region ■デリゲート
        /// <summary>売上金額処理区分設定キャッシュデリゲート</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>仕入金額処理区分設定キャッシュデリゲート</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        /// <summary>掛率優先管理マスタキャッシュデリゲート</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);
        #endregion

        /// <summary>拠点コード(全体)</summary>
        public const string ctSectionCode = "00";

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        /// <br>Update Note: 2011/07/25 譚洪 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応</br>
        /// <br>管理番号   : 11370030-00 2017/04/13 譚洪</br>
        /// <br>             Redmine#49283 仕入担当参照区分を追加</br>
        public int ReadInitDataThird(string enterpriseCode, string sectionCode)
        {
            #region ●オプション情報
            LogWrite("３オプション情報を取得");
            this.CacheOptionInfo();
            #endregion

            CustomSerializeArrayList workList = new CustomSerializeArrayList();
            object retObj;
            workList.Clear();
            retObj = workList;

            this._subSectionList = new List<SubSection>(); // 部門マスタ
            SubSectionWork subSectionWork = new SubSectionWork();
            subSectionWork.EnterpriseCode = enterpriseCode;

            this._rateProtyMngList = new List<RateProtyMng>(); // 掛率優先管理マスタ
            RateProtyMngWork rateProtyMngWork = new RateProtyMngWork();
            rateProtyMngWork.EnterpriseCode = enterpriseCode;

            this._userGdBdList = new List<UserGdBd>(); // ユーザーガイド
            UserGdBdUWork userGdBdUWork = new UserGdBdUWork();
            userGdBdUWork.EnterpriseCode = enterpriseCode;

            this._salesProcMoneyList = new List<SalesProcMoney>(); // 売上金額処理区分マスタ
            SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();
            salesProcMoneyWork.EnterpriseCode = enterpriseCode;
            salesProcMoneyWork.FracProcMoneyDiv = -1;
            salesProcMoneyWork.FractionProcCode = -1;

            this._stockProcMoneyList = new List<StockProcMoney>(); // 仕入金額処理区分マスタ
            StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();
            stockProcMoneyWork.EnterpriseCode = enterpriseCode;
            stockProcMoneyWork.FracProcMoneyDiv = -1;
            stockProcMoneyWork.FractionProcCode = -1;

            AcptAnOdrTtlStWork acptAnOdrTtlStWork = new AcptAnOdrTtlStWork();
            acptAnOdrTtlStWork.EnterpriseCode = enterpriseCode;

            SalesTtlStWork salesTtlStWork = new SalesTtlStWork();
            salesTtlStWork.EnterpriseCode = enterpriseCode;

            EstimateDefSetWork estimateDefSetWork = new EstimateDefSetWork();
            estimateDefSetWork.EnterpriseCode = enterpriseCode;

            StockTtlStWork stockTtlStWork = new StockTtlStWork();
            stockTtlStWork.EnterpriseCode = enterpriseCode;

            AllDefSetWork allDefSetWork = new AllDefSetWork();
            allDefSetWork.EnterpriseCode = enterpriseCode;

            CompanyInfWork companyInfWork = new CompanyInfWork();
            companyInfWork.EnterpriseCode = enterpriseCode;

            TaxRateSetWork taxRateSetWork = new TaxRateSetWork();
            taxRateSetWork.EnterpriseCode = enterpriseCode;

            this._slipPrtSetList = new List<SlipPrtSet>();
            SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();
            slipPrtSetWork.EnterpriseCode = enterpriseCode;

            this._custSlipMngList = new List<CustSlipMng>();
            CustSlipMngWork custSlipMngWork = new CustSlipMngWork();
            custSlipMngWork.EnterpriseCode = enterpriseCode;

            this._uoeGuideNameList = new List<UOEGuideName>();
            UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
            uoeGuideNameWork.EnterpriseCode = enterpriseCode;
            uoeGuideNameWork.SectionCode = sectionCode.Trim();

            UOESettingWork uoeSettingWork = new UOESettingWork();
            uoeSettingWork.EnterpriseCode = enterpriseCode;
            uoeSettingWork.SectionCode = sectionCode.Trim();

            //>>>2010/05/30
            SCMDeliDateStWork scmDeliDateStWork = new SCMDeliDateStWork();
            scmDeliDateStWork.EnterpriseCode = enterpriseCode;
            //scmDeliDateStWork.SectionCode = sectionCode.Trim();   // 2011/01/31 Del

            SCMTtlStWork scmTtlStWork = new SCMTtlStWork();
            scmTtlStWork.EnterpriseCode = enterpriseCode;
            //scmTtlStWork.SectionCode = sectionCode.Trim();

            TbsPartsCdChgWork tbsPartsCdChgWork = new TbsPartsCdChgWork();
            //<<<2010/05/30

            // 2011/01/31 Add >>>
            this._scmDeliDateStList = new List<SCMDeliDateSt>();
            // 2011/01/31 Add <<<

            //>>>2011/09/27
            StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork();
            stockMngTtlStWork.EnterpriseCode = enterpriseCode;
            //<<<2011/09/27

            workList.Add(subSectionWork);
            workList.Add(rateProtyMngWork);
            workList.Add(userGdBdUWork);
            workList.Add(salesProcMoneyWork);
            workList.Add(stockProcMoneyWork);

            workList.Add(acptAnOdrTtlStWork);
            workList.Add(salesTtlStWork);
            workList.Add(estimateDefSetWork);
            workList.Add(stockTtlStWork);
            workList.Add(allDefSetWork);
            workList.Add(companyInfWork);
            workList.Add(taxRateSetWork);
            workList.Add(slipPrtSetWork);
            workList.Add(custSlipMngWork);
            workList.Add(uoeGuideNameWork);
            workList.Add(uoeSettingWork);

            //>>>2010/05/30
            workList.Add(scmTtlStWork);
            workList.Add(scmDeliDateStWork);
            workList.Add(tbsPartsCdChgWork);
            //<<<2010/05/30

            workList.Add(stockMngTtlStWork); // 2011/09/27

            IVariousMasterSearchDB _iVariousMasterSearchDB = MediationVariousMasterSearchDB.GetRemoteObject();
            int ist = 0;
            try
            {
                ist = _iVariousMasterSearchDB.Search(ref retObj, null, 0, ConstantManagement.LogicalMode.GetData0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (ist == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                workList = retObj as CustomSerializeArrayList;

                if (workList[0] is ArrayList)
                {
                    foreach (ArrayList arList in workList)
                    {
                        if (arList != null && arList.Count > 0)
                        {
                            #region 受発注管理全体設定
                            if (arList[0] is AcptAnOdrTtlStWork)
                            {
                                this._acptAnOdrTtlSt = new AcptAnOdrTtlSt();
                                AcptAnOdrTtlStWork svWork = new AcptAnOdrTtlStWork();
                                foreach (AcptAnOdrTtlStWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == sectionCode.Trim()))
                                    {
                                        svWork = work;
                                        break;
                                    }
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region 項目セット
                                this._acptAnOdrTtlSt.AcpOdrrSlipPrtDiv = svWork.AcpOdrrSlipPrtDiv;
                                this._acptAnOdrTtlSt.CreateDateTime = svWork.CreateDateTime;
                                this._acptAnOdrTtlSt.EnterpriseCode = svWork.EnterpriseCode;
                                this._acptAnOdrTtlSt.EstmCountReflectDiv = svWork.EstmCountReflectDiv;
                                this._acptAnOdrTtlSt.FaxOrderDiv = svWork.FaxOrderDiv;
                                this._acptAnOdrTtlSt.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._acptAnOdrTtlSt.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._acptAnOdrTtlSt.SectionCode = svWork.SectionCode;
                                this._acptAnOdrTtlSt.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._acptAnOdrTtlSt.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._acptAnOdrTtlSt.UpdateDateTime = svWork.UpdateDateTime;
                                this._acptAnOdrTtlSt.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                #endregion
                            }
                            #endregion

                            #region 売上全体設定
                            if (arList[0] is SalesTtlStWork)
                            {
                                this._salesTtlSt = new SalesTtlSt();
                                SalesTtlStWork svWork = new SalesTtlStWork();
                                foreach (SalesTtlStWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == sectionCode.Trim()))
                                    {
                                        svWork = work;
                                        break;
                                    }
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region 項目セット
                                this._salesTtlSt.CreateDateTime = svWork.CreateDateTime; // 作成日時
                                this._salesTtlSt.UpdateDateTime = svWork.UpdateDateTime; // 更新日時
                                this._salesTtlSt.EnterpriseCode = svWork.EnterpriseCode; // 企業コード
                                this._salesTtlSt.FileHeaderGuid = svWork.FileHeaderGuid; // GUID
                                this._salesTtlSt.UpdEmployeeCode = svWork.UpdEmployeeCode; // 更新従業員コード
                                this._salesTtlSt.UpdAssemblyId1 = svWork.UpdAssemblyId1; // 更新アセンブリID1
                                this._salesTtlSt.UpdAssemblyId2 = svWork.UpdAssemblyId2; // 更新アセンブリID2
                                this._salesTtlSt.LogicalDeleteCode = svWork.LogicalDeleteCode; // 論理削除区分
                                this._salesTtlSt.SectionCode = svWork.SectionCode; // 拠点コード
                                this._salesTtlSt.SalesSlipPrtDiv = svWork.SalesSlipPrtDiv; // 売上伝票発行区分
                                this._salesTtlSt.ShipmSlipPrtDiv = svWork.ShipmSlipPrtDiv; // 出荷伝票発行区分
                                this._salesTtlSt.ShipmSlipUnPrcPrtDiv = svWork.ShipmSlipUnPrcPrtDiv; // 出荷伝票単価印刷区分
                                this._salesTtlSt.GrsProfitCheckLower = svWork.GrsProfitCheckLower; // 粗利チェック下限
                                this._salesTtlSt.GrsProfitCheckBest = svWork.GrsProfitCheckBest; // 粗利チェック適正
                                this._salesTtlSt.GrsProfitCheckUpper = svWork.GrsProfitCheckUpper; // 粗利チェック上限
                                this._salesTtlSt.GrsProfitChkLowSign = svWork.GrsProfitChkLowSign; // 粗利チェック下限記号
                                this._salesTtlSt.GrsProfitChkBestSign = svWork.GrsProfitChkBestSign; // 粗利チェック適正記号
                                this._salesTtlSt.GrsProfitChkUprSign = svWork.GrsProfitChkUprSign; // 粗利チェック上限記号
                                this._salesTtlSt.GrsProfitChkMaxSign = svWork.GrsProfitChkMaxSign; // 粗利チェック最大記号
                                this._salesTtlSt.SalesAgentChngDiv = svWork.SalesAgentChngDiv; // 売上担当変更区分
                                this._salesTtlSt.AcpOdrAgentDispDiv = svWork.AcpOdrAgentDispDiv; // 受注者表示区分
                                this._salesTtlSt.BrSlipNote2DispDiv = svWork.BrSlipNote2DispDiv; // 伝票備考２表示区分
                                this._salesTtlSt.DtlNoteDispDiv = svWork.DtlNoteDispDiv; // 明細備考表示区分
                                this._salesTtlSt.UnPrcNonSettingDiv = svWork.UnPrcNonSettingDiv; // 売価未設定時区分
                                this._salesTtlSt.EstmateAddUpRemDiv = svWork.EstmateAddUpRemDiv; // 見積データ計上残区分
                                this._salesTtlSt.AcpOdrrAddUpRemDiv = svWork.AcpOdrrAddUpRemDiv; // 受注データ計上残区分
                                this._salesTtlSt.ShipmAddUpRemDiv = svWork.ShipmAddUpRemDiv; // 出荷データ計上残区分
                                this._salesTtlSt.RetGoodsStockEtyDiv = svWork.RetGoodsStockEtyDiv; // 返品時在庫登録区分
                                this._salesTtlSt.ListPriceSelectDiv = svWork.ListPriceSelectDiv; // 定価選択区分
                                this._salesTtlSt.MakerInpDiv = svWork.MakerInpDiv; // メーカー入力区分
                                this._salesTtlSt.BLGoodsCdInpDiv = svWork.BLGoodsCdInpDiv; // BL商品コード入力区分
                                this._salesTtlSt.SupplierInpDiv = svWork.SupplierInpDiv; // 仕入先入力区分
                                this._salesTtlSt.SupplierSlipDelDiv = svWork.SupplierSlipDelDiv; // 仕入伝票削除区分
                                this._salesTtlSt.CustGuideDispDiv = svWork.CustGuideDispDiv; // 得意先ガイド初期表示区分
                                this._salesTtlSt.SlipChngDivDate = svWork.SlipChngDivDate; // 伝票修正区分（日付）
                                this._salesTtlSt.SlipChngDivCost = svWork.SlipChngDivCost; // 伝票修正区分（原価）
                                this._salesTtlSt.SlipChngDivUnPrc = svWork.SlipChngDivUnPrc; // 伝票修正区分（売価）
                                this._salesTtlSt.SlipChngDivLPrice = svWork.SlipChngDivLPrice; // 伝票修正区分（定価）
                                this._salesTtlSt.RetSlipChngDivCost = svWork.RetSlipChngDivCost; // 返品伝票修正区分（原価）
                                this._salesTtlSt.RetSlipChngDivUnPrc = svWork.RetSlipChngDivUnPrc; // 返品伝票修正区分（売価）
                                this._salesTtlSt.AutoDepoKindCode = svWork.AutoDepoKindCode; // 自動入金金種コード
                                this._salesTtlSt.AutoDepoKindName = svWork.AutoDepoKindName; // 自動入金金種名称
                                this._salesTtlSt.AutoDepoKindDivCd = svWork.AutoDepoKindDivCd; // 自動入金金種区分
                                this._salesTtlSt.DiscountName = svWork.DiscountName; // 値引名称
                                this._salesTtlSt.InpAgentDispDiv = svWork.InpAgentDispDiv; // 発行者表示区分
                                this._salesTtlSt.CustOrderNoDispDiv = svWork.CustOrderNoDispDiv; // 得意先注番表示区分
                                this._salesTtlSt.CarMngNoDispDiv = svWork.CarMngNoDispDiv; // 車両管理番号表示区分
                                this._salesTtlSt.BrSlipNote3DispDiv = svWork.BrSlipNote3DispDiv; // 伝票備考３表示区分
                                this._salesTtlSt.SlipDateClrDivCd = svWork.SlipDateClrDivCd; // 伝票日付クリア区分
                                this._salesTtlSt.AutoEntryGoodsDivCd = svWork.AutoEntryGoodsDivCd; // 商品自動登録区分
                                this._salesTtlSt.CostCheckDivCd = svWork.CostCheckDivCd; // 原価チェック区分
                                this._salesTtlSt.JoinInitDispDiv = svWork.JoinInitDispDiv; // 結合初期表示区分
                                this._salesTtlSt.AutoDepositCd = svWork.AutoDepositCd; // 自動入金区分
                                this._salesTtlSt.SubstCondDivCd = svWork.SubstCondDivCd; // 代替条件区分
                                this._salesTtlSt.SlipCreateProcess = svWork.SlipCreateProcess; // 伝票作成方法
                                this._salesTtlSt.WarehouseChkDiv = svWork.WarehouseChkDiv; // 倉庫チェック区分
                                this._salesTtlSt.PartsSearchDivCd = svWork.PartsSearchDivCd; // 部品検索区分
                                this._salesTtlSt.GrsProfitDspCd = svWork.GrsProfitDspCd; // 粗利表示区分
                                this._salesTtlSt.PartsSearchPriDivCd = svWork.PartsSearchPriDivCd; // 部品検索優先順区分
                                this._salesTtlSt.SalesStockDiv = svWork.SalesStockDiv; // 売上仕入区分
                                this._salesTtlSt.PrtBLGoodsCodeDiv = svWork.PrtBLGoodsCodeDiv; // 印刷用BL商品コード区分
                                this._salesTtlSt.SectDspDivCd = svWork.SectDspDivCd; // 拠点表示区分
                                this._salesTtlSt.GoodsNmReDispDivCd = svWork.GoodsNmReDispDivCd; // 商品名再表示区分
                                this._salesTtlSt.CostDspDivCd = svWork.CostDspDivCd; // 原価表示区分
                                this._salesTtlSt.DepoSlipDateClrDiv = svWork.DepoSlipDateClrDiv; // 入金伝票日付クリア区分
                                this._salesTtlSt.DepoSlipDateAmbit = svWork.DepoSlipDateAmbit; // 入金伝票日付範囲区分
                                this._salesTtlSt.InpGrsProfChkLower = svWork.InpGrsProfChkLower; // 入力粗利チェック下限
                                this._salesTtlSt.InpGrsProfChkUpper = svWork.InpGrsProfChkUpper; // 入力粗利チェック上限
                                this._salesTtlSt.InpGrsProfChkLowDiv = svWork.InpGrsPrfChkLowDiv; // 入力粗利チェック下限区分
                                this._salesTtlSt.InpGrsProfChkUppDiv = svWork.InpGrsPrfChkUppDiv; // 入力粗利チェック上限区分
                                this._salesTtlSt.PrmSubstCondDivCd = svWork.PrmSubstCondDivCd; // 優良代替条件区分
                                this._salesTtlSt.SubstApplyDivCd = svWork.SubstApplyDivCd; // 代替適用区分
                                this._salesTtlSt.PartsNameDspDivCd = svWork.PartsNameDspDivCd; // 品名表示区分
                                this._salesTtlSt.BLGoodsCdDerivNoDiv = svWork.BLGoodsCdDerivNoDiv; // BLコード枝番区分
                                this._salesTtlSt.PriceSelectDispDiv = svWork.PriceSelectDispDiv; // 標準価格選択表示区分
                                this._salesTtlSt.AcpOdrInputDiv = svWork.AcpOdrInputDiv; // 受注数入力区分
                                this._salesTtlSt.InpAgentChkDiv = svWork.InpAgentChkDiv; // 発行者チェック区分
                                this._salesTtlSt.InpWarehChkDiv = svWork.InpWarehChkDiv; // 入力倉庫チェック区分
                                this._salesTtlSt.FrSrchPrtAutoEntDiv = svWork.FrSrchPrtAutoEntDiv; // 自由検索部品自動登録区分 // 2010/05/30
                                //>>>2010/07/01
                                this._salesTtlSt.BLCdPrtsNmDspDivCd1 = svWork.BLCdPrtsNmDspDivCd1; // BLコード検索品名表示区分１
                                this._salesTtlSt.BLCdPrtsNmDspDivCd2 = svWork.BLCdPrtsNmDspDivCd2; // BLコード検索品名表示区分２
                                this._salesTtlSt.BLCdPrtsNmDspDivCd3 = svWork.BLCdPrtsNmDspDivCd3; // BLコード検索品名表示区分３
                                this._salesTtlSt.BLCdPrtsNmDspDivCd4 = svWork.BLCdPrtsNmDspDivCd4; // BLコード検索品名表示区分４
                                this._salesTtlSt.GdNoPrtsNmDspDivCd1 = svWork.GdNoPrtsNmDspDivCd1; // 品番検索品名表示区分１
                                this._salesTtlSt.GdNoPrtsNmDspDivCd2 = svWork.GdNoPrtsNmDspDivCd2; // 品番検索品名表示区分２
                                this._salesTtlSt.GdNoPrtsNmDspDivCd3 = svWork.GdNoPrtsNmDspDivCd3; // 品番検索品名表示区分３
                                this._salesTtlSt.GdNoPrtsNmDspDivCd4 = svWork.GdNoPrtsNmDspDivCd4; // 品番検索品名表示区分４
                                this._salesTtlSt.PrmPrtsNmUseDivCd = svWork.PrmPrtsNmUseDivCd; // 優良部品検索品名使用区分
                                //<<<2010/07/01

                                this._salesTtlSt.DwnPLCdSpDivCd = svWork.DwnPLCdSpDivCd; // ADD 2010/08/13
                                this._salesTtlSt.SalesCdDspDivCd = svWork.SalesCdDspDivCd; // 2011/05/25

                                //>>>2012/05/02
                                this._salesTtlSt.RentStockDiv = svWork.RentStockDiv;
                                //<<<2012/05/02

                                this._salesTtlSt.AutoDepositNoteDiv = svWork.AutoDepositNoteDiv; // 自動入金備考区分(0:売上伝票番号 1:売上伝票備考 2:無し) // ADD 2013/01/18 田建委 Redmine#33797

                                // --- ADD 2013/02/05 Y.Wakita ---------->>>>>
                                this._salesTtlSt.BLGoodsCdZeroSuprt = svWork.BLGoodsCdZeroSuprt;    // BLコード０対応
                                this._salesTtlSt.BLGoodsCdChange = svWork.BLGoodsCdChange;          // 変換コード
                                // --- ADD 2013/02/05 Y.Wakita ----------<<<<<

                                this._salesTtlSt.StockEmpRefDiv = svWork.StockEmpRefDiv; // ADD 2017/04/13 譚洪 Redmine#49283

                                #endregion
                            }
                            #endregion

                            #region 見積初期値設定
                            if (arList[0] is EstimateDefSetWork)
                            {
                                this._estimateDefSet = new EstimateDefSet();
                                EstimateDefSetWork svWork = new EstimateDefSetWork();
                                foreach (EstimateDefSetWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == sectionCode.Trim()))
                                    {
                                        svWork = work;
                                        break;
                                    }
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region 項目セット
                                this._estimateDefSet.ConsTaxPrintDiv = svWork.ConsTaxPrintDiv;
                                this._estimateDefSet.CreateDateTime = svWork.CreateDateTime;
                                this._estimateDefSet.EnterpriseCode = svWork.EnterpriseCode;
                                this._estimateDefSet.EstimateDtCreateDiv = svWork.EstimateDtCreateDiv;
                                this._estimateDefSet.EstimateNote1 = svWork.EstimateNote1;
                                this._estimateDefSet.EstimateNote2 = svWork.EstimateNote2;
                                this._estimateDefSet.EstimateNote3 = svWork.EstimateNote3;
                                this._estimateDefSet.EstimatePrtDiv = svWork.EstimatePrtDiv;
                                this._estimateDefSet.EstimateTitle1 = svWork.EstimateTitle1;
                                this._estimateDefSet.EstimateValidityTerm = svWork.EstimateValidityTerm;
                                this._estimateDefSet.EstmFormNoPickDiv = svWork.EstmFormNoPickDiv;
                                this._estimateDefSet.FaxEstimatetDiv = svWork.FaxEstimatetDiv;
                                this._estimateDefSet.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._estimateDefSet.ListPricePrintDiv = svWork.ListPricePrintDiv;
                                this._estimateDefSet.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._estimateDefSet.OptionPringDivCd = svWork.OptionPringDivCd;
                                this._estimateDefSet.PartsNoPrtCd = svWork.PartsNoPrtCd;
                                this._estimateDefSet.PartsSearchDivCd = svWork.PartsSearchDivCd;
                                this._estimateDefSet.PartsSelectDivCd = svWork.PartsSelectDivCd;
                                this._estimateDefSet.RateUseCode = svWork.RateUseCode;
                                this._estimateDefSet.SectionCode = svWork.SectionCode;
                                this._estimateDefSet.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._estimateDefSet.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._estimateDefSet.UpdateDateTime = svWork.UpdateDateTime;
                                this._estimateDefSet.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                #endregion
                            }
                            #endregion

                            #region 仕入在庫全体
                            if (arList[0] is StockTtlStWork)
                            {
                                this._stockTtlSt = new StockTtlSt();
                                StockTtlStWork svWork = new StockTtlStWork();
                                foreach (StockTtlStWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == sectionCode.Trim()))
                                    {
                                        svWork = work;
                                        break;
                                    }
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region 項目セット
                                this._stockTtlSt.AutoEntryGoodsDivCd = svWork.AutoEntryGoodsDivCd;
                                this._stockTtlSt.AutoPayment = svWork.AutoPayment;
                                this._stockTtlSt.AutoPayMoneyKindCode = svWork.AutoPayMoneyKindCode;
                                this._stockTtlSt.AutoPayMoneyKindDiv = svWork.AutoPayMoneyKindDiv;
                                this._stockTtlSt.AutoPayMoneyKindName = svWork.AutoPayMoneyKindName;
                                this._stockTtlSt.CreateDateTime = svWork.CreateDateTime;
                                this._stockTtlSt.DtlNoteDispDiv = svWork.DtlNoteDispDiv;
                                this._stockTtlSt.EnterpriseCode = svWork.EnterpriseCode;
                                this._stockTtlSt.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._stockTtlSt.GoodsNmReDispDivCd = svWork.GoodsNmReDispDivCd;
                                this._stockTtlSt.ListPriceInpDiv = svWork.ListPriceInpDiv;
                                this._stockTtlSt.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._stockTtlSt.PaySlipDateAmbit = svWork.PaySlipDateAmbit;
                                this._stockTtlSt.PaySlipDateClrDiv = svWork.PaySlipDateClrDiv;
                                this._stockTtlSt.PriceCheckDivCd = svWork.PriceCheckDivCd;
                                this._stockTtlSt.PriceCostUpdtDiv = svWork.PriceCostUpdtDiv;
                                this._stockTtlSt.RgdsSlipPrtDiv = svWork.RgdsSlipPrtDiv;
                                this._stockTtlSt.RgdsUnPrcPrtDiv = svWork.RgdsUnPrcPrtDiv;
                                this._stockTtlSt.RgdsZeroPrtDiv = svWork.RgdsZeroPrtDiv;
                                this._stockTtlSt.SectDspDivCd = svWork.SectDspDivCd;
                                this._stockTtlSt.SectionCode = svWork.SectionCode;
                                this._stockTtlSt.SlipDateClrDivCd = svWork.SlipDateClrDivCd;
                                this._stockTtlSt.StockDiscountName = svWork.StockDiscountName;
                                this._stockTtlSt.StockSearchDiv = svWork.StockSearchDiv;
                                this._stockTtlSt.StockUnitChgDivCd = svWork.StockUnitChgDivCd;
                                this._stockTtlSt.UnitPriceInpDiv = svWork.UnitPriceInpDiv;
                                this._stockTtlSt.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._stockTtlSt.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._stockTtlSt.UpdateDateTime = svWork.UpdateDateTime;
                                this._stockTtlSt.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                #endregion
                            }
                            #endregion

                            #region 全体初期値
                            if (arList[0] is AllDefSetWork)
                            {
                                this._allDefSet = new AllDefSet();
                                AllDefSetWork svWork = new AllDefSetWork();
                                foreach (AllDefSetWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == sectionCode.Trim()))
                                    {
                                        svWork = work;
                                        break;
                                    }
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region 項目セット
                                this._allDefSet.CnsTaxAutoCorrDiv = svWork.CnsTaxAutoCorrDiv;
                                this._allDefSet.CreateDateTime = svWork.CreateDateTime;
                                this._allDefSet.DefDspBillPrtDivCd = svWork.DefDspBillPrtDivCd;
                                this._allDefSet.DefDspClctMnyMonthCd = svWork.DefDspClctMnyMonthCd;
                                this._allDefSet.DefDspCustClctMnyDay = svWork.DefDspCustClctMnyDay;
                                this._allDefSet.DefDspCustTtlDay = svWork.DefDspCustTtlDay;
                                this._allDefSet.DefDtlBillOutput = svWork.DefDtlBillOutput;
                                this._allDefSet.DefSlTtlBillOutput = svWork.DefSlTtlBillOutput;
                                this._allDefSet.DefTtlBillOutput = svWork.DefTtlBillOutput;
                                this._allDefSet.EnterpriseCode = svWork.EnterpriseCode;
                                this._allDefSet.EraNameDispCd1 = svWork.EraNameDispCd1;
                                this._allDefSet.EraNameDispCd2 = svWork.EraNameDispCd2;
                                this._allDefSet.EraNameDispCd3 = svWork.EraNameDispCd3;
                                this._allDefSet.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._allDefSet.GoodsNoInpDiv = svWork.GoodsNoInpDiv;
                                this._allDefSet.IniDspPrslOrCorpCd = svWork.IniDspPrslOrCorpCd;
                                this._allDefSet.InitDspDmDiv = svWork.InitDspDmDiv;
                                this._allDefSet.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._allDefSet.MemoMoveDiv = svWork.MemoMoveDiv;
                                this._allDefSet.RemainCntMngDiv = svWork.RemainCntMngDiv;
                                this._allDefSet.RemCntAutoDspDiv = svWork.RemCntAutoDspDiv;
                                this._allDefSet.SectionCode = svWork.SectionCode;
                                this._allDefSet.TotalAmountDispWayCd = svWork.TotalAmountDispWayCd;
                                this._allDefSet.TtlAmntDspRateDivCd = svWork.TtlAmntDspRateDivCd;
                                this._allDefSet.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._allDefSet.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._allDefSet.UpdateDateTime = svWork.UpdateDateTime;
                                this._allDefSet.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                this._allDefSet.DtlCalcStckCntDsp = svWork.DtlCalcStckCntDsp;  // ADD 2011/07/20
                                #endregion
                            }
                            #endregion

                            #region 自社情報
                            if (arList[0] is CompanyInfWork)
                            {
                                this._companyInf = new CompanyInf();
                                CompanyInfWork svWork = new CompanyInfWork();
                                svWork = (CompanyInfWork)arList[0];

                                #region 項目セット
                                this._companyInf.Address1 = svWork.Address1;
                                this._companyInf.Address3 = svWork.Address3;
                                this._companyInf.Address4 = svWork.Address4;
                                this._companyInf.CompanyBiginDate = svWork.CompanyBiginDate;
                                this._companyInf.CompanyBiginMonth = svWork.CompanyBiginMonth;
                                this._companyInf.CompanyBiginMonth2 = svWork.CompanyBiginMonth2;
                                this._companyInf.CompanyCode = svWork.CompanyCode;
                                this._companyInf.CompanyName1 = svWork.CompanyName1;
                                this._companyInf.CompanyName2 = svWork.CompanyName2;
                                this._companyInf.CompanyTelNo1 = svWork.CompanyTelNo1;
                                this._companyInf.CompanyTelNo2 = svWork.CompanyTelNo2;
                                this._companyInf.CompanyTelNo3 = svWork.CompanyTelNo3;
                                this._companyInf.CompanyTelTitle1 = svWork.CompanyTelTitle1;
                                this._companyInf.CompanyTelTitle2 = svWork.CompanyTelTitle2;
                                this._companyInf.CompanyTelTitle3 = svWork.CompanyTelTitle3;
                                this._companyInf.CompanyTotalDay = svWork.CompanyTotalDay;
                                this._companyInf.CreateDateTime = svWork.CreateDateTime;
                                this._companyInf.EnterpriseCode = svWork.EnterpriseCode;
                                this._companyInf.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._companyInf.FinancialYear = svWork.FinancialYear;
                                this._companyInf.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._companyInf.PostNo = svWork.PostNo;
                                this._companyInf.SecMngDiv = svWork.SecMngDiv;
                                this._companyInf.StartMonthDiv = svWork.StartMonthDiv;
                                this._companyInf.StartYearDiv = svWork.StartYearDiv;
                                this._companyInf.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._companyInf.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._companyInf.UpdateDateTime = svWork.UpdateDateTime;
                                this._companyInf.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                this._companyInf.RatePriorityDiv = svWork.RatePriorityDiv;  // ADD 2011/07/25
                                #endregion
                            }
                            #endregion

                            #region 伝票印刷設定マスタ
                            if (arList[0] is SlipPrtSetWork)
                            {
                                foreach (SlipPrtSetWork work in arList)
                                {
                                    SlipPrtSet slipPrtSet = new SlipPrtSet();

                                    #region 項目セット
                                    slipPrtSet.CreateDateTime = work.CreateDateTime; // 作成日時
                                    slipPrtSet.UpdateDateTime = work.UpdateDateTime; // 更新日時
                                    slipPrtSet.EnterpriseCode = work.EnterpriseCode; // 企業コード
                                    slipPrtSet.FileHeaderGuid = work.FileHeaderGuid; // GUID
                                    slipPrtSet.UpdEmployeeCode = work.UpdEmployeeCode; // 更新従業員コード
                                    slipPrtSet.UpdAssemblyId1 = work.UpdAssemblyId1; // 更新アセンブリID1
                                    slipPrtSet.UpdAssemblyId2 = work.UpdAssemblyId2; // 更新アセンブリID2
                                    slipPrtSet.LogicalDeleteCode = work.LogicalDeleteCode; // 論理削除区分
                                    slipPrtSet.DataInputSystem = work.DataInputSystem; // データ入力システム
                                    slipPrtSet.SlipPrtKind = work.SlipPrtKind; // 伝票印刷種別
                                    slipPrtSet.SlipPrtSetPaperId = work.SlipPrtSetPaperId; // 伝票印刷設定用帳票ID
                                    slipPrtSet.SlipComment = work.SlipComment; // 伝票コメント
                                    slipPrtSet.OutputPgId = work.OutputPgId; // 出力プログラムID
                                    slipPrtSet.OutputPgClassId = work.OutputPgClassId; // 出力プログラムクラスID
                                    slipPrtSet.OutputFormFileName = work.OutputFormFileName; // 出力ファイル名
                                    slipPrtSet.EnterpriseNamePrtCd = work.EnterpriseNamePrtCd; // 自社名印刷区分
                                    slipPrtSet.PrtCirculation = work.PrtCirculation; // 印刷部数
                                    slipPrtSet.SlipFormCd = work.SlipFormCd; // 伝票用紙区分
                                    slipPrtSet.OutConfimationMsg = work.OutConfimationMsg; // 出力確認メッセージ
                                    slipPrtSet.OptionCode = work.OptionCode; // オプションコード
                                    slipPrtSet.TopMargin = work.TopMargin; // 上余白
                                    slipPrtSet.LeftMargin = work.LeftMargin; // 左余白
                                    slipPrtSet.RightMargin = work.RightMargin; // 右余白
                                    slipPrtSet.BottomMargin = work.BottomMargin; // 下余白
                                    slipPrtSet.PrtPreviewExistCode = work.PrtPreviewExistCode; // 印刷プレビュ有無区分
                                    slipPrtSet.OutputPurpose = work.OutputPurpose; // 出力用途
                                    slipPrtSet.EachSlipTypeColId1 = work.EachSlipTypeColId1; // 伝票タイプ別列ID1
                                    slipPrtSet.EachSlipTypeColNm1 = work.EachSlipTypeColNm1; // 伝票タイプ別列名称
                                    slipPrtSet.EachSlipTypeColPrt1 = work.EachSlipTypeColPrt1; // 伝票タイプ別列印字区分
                                    slipPrtSet.EachSlipTypeColId2 = work.EachSlipTypeColId2; // 伝票タイプ別列ID2
                                    slipPrtSet.EachSlipTypeColNm2 = work.EachSlipTypeColNm2; // 伝票タイプ別列名称
                                    slipPrtSet.EachSlipTypeColPrt2 = work.EachSlipTypeColPrt2; // 伝票タイプ別列印字区分
                                    slipPrtSet.EachSlipTypeColId3 = work.EachSlipTypeColId3; // 伝票タイプ別列ID3
                                    slipPrtSet.EachSlipTypeColNm3 = work.EachSlipTypeColNm3; // 伝票タイプ別列名称
                                    slipPrtSet.EachSlipTypeColPrt3 = work.EachSlipTypeColPrt3; // 伝票タイプ別列印字区分
                                    slipPrtSet.EachSlipTypeColId4 = work.EachSlipTypeColId4; // 伝票タイプ別列ID4
                                    slipPrtSet.EachSlipTypeColNm4 = work.EachSlipTypeColNm4; // 伝票タイプ別列名称
                                    slipPrtSet.EachSlipTypeColPrt4 = work.EachSlipTypeColPrt4; // 伝票タイプ別列印字区分
                                    slipPrtSet.EachSlipTypeColId5 = work.EachSlipTypeColId5; // 伝票タイプ別列ID5
                                    slipPrtSet.EachSlipTypeColNm5 = work.EachSlipTypeColNm5; // 伝票タイプ別列名称
                                    slipPrtSet.EachSlipTypeColPrt5 = work.EachSlipTypeColPrt5; // 伝票タイプ別列印字区分
                                    slipPrtSet.EachSlipTypeColId6 = work.EachSlipTypeColId6; // 伝票タイプ別列ID6
                                    slipPrtSet.EachSlipTypeColNm6 = work.EachSlipTypeColNm6; // 伝票タイプ別列名称
                                    slipPrtSet.EachSlipTypeColPrt6 = work.EachSlipTypeColPrt6; // 伝票タイプ別列印字区分
                                    slipPrtSet.EachSlipTypeColId7 = work.EachSlipTypeColId7; // 伝票タイプ別列ID7
                                    slipPrtSet.EachSlipTypeColNm7 = work.EachSlipTypeColNm7; // 伝票タイプ別列名称
                                    slipPrtSet.EachSlipTypeColPrt7 = work.EachSlipTypeColPrt7; // 伝票タイプ別列印字区分
                                    slipPrtSet.EachSlipTypeColId8 = work.EachSlipTypeColId8; // 伝票タイプ別列ID8
                                    slipPrtSet.EachSlipTypeColNm8 = work.EachSlipTypeColNm8; // 伝票タイプ別列名称
                                    slipPrtSet.EachSlipTypeColPrt8 = work.EachSlipTypeColPrt8; // 伝票タイプ別列印字区分
                                    slipPrtSet.EachSlipTypeColId9 = work.EachSlipTypeColId9; // 伝票タイプ別列ID9
                                    slipPrtSet.EachSlipTypeColNm9 = work.EachSlipTypeColNm9; // 伝票タイプ別列名称
                                    slipPrtSet.EachSlipTypeColPrt9 = work.EachSlipTypeColPrt9; // 伝票タイプ別列印字区分
                                    slipPrtSet.EachSlipTypeColId10 = work.EachSlipTypeColId10; // 伝票タイプ別列ID10
                                    slipPrtSet.EachSlipTypeColNm10 = work.EachSlipTypeColNm10; // 伝票タイプ別列名称
                                    slipPrtSet.EachSlipTypeColPrt10 = work.EachSlipTypeColPrt10; // 伝票タイプ別列印字区分
                                    slipPrtSet.SlipFontName = work.SlipFontName; // 伝票フォント名称
                                    slipPrtSet.SlipFontSize = work.SlipFontSize; // 伝票フォントサイズ
                                    slipPrtSet.SlipFontStyle = work.SlipFontStyle; // 伝票フォントスタイル
                                    slipPrtSet.SlipBaseColorRed1 = work.SlipBaseColorRed1; // 伝票基準色赤
                                    slipPrtSet.SlipBaseColorGrn1 = work.SlipBaseColorGrn1; // 伝票基準色緑
                                    slipPrtSet.SlipBaseColorBlu1 = work.SlipBaseColorBlu1; // 伝票基準色青
                                    slipPrtSet.SlipBaseColorRed2 = work.SlipBaseColorRed2; // 伝票基準色赤
                                    slipPrtSet.SlipBaseColorGrn2 = work.SlipBaseColorGrn2; // 伝票基準色緑
                                    slipPrtSet.SlipBaseColorBlu2 = work.SlipBaseColorBlu2; // 伝票基準色青
                                    slipPrtSet.SlipBaseColorRed3 = work.SlipBaseColorRed3; // 伝票基準色赤
                                    slipPrtSet.SlipBaseColorGrn3 = work.SlipBaseColorGrn3; // 伝票基準色緑
                                    slipPrtSet.SlipBaseColorBlu3 = work.SlipBaseColorBlu3; // 伝票基準色青
                                    slipPrtSet.SlipBaseColorRed4 = work.SlipBaseColorRed4; // 伝票基準色赤
                                    slipPrtSet.SlipBaseColorGrn4 = work.SlipBaseColorGrn4; // 伝票基準色緑
                                    slipPrtSet.SlipBaseColorBlu4 = work.SlipBaseColorBlu4; // 伝票基準色青
                                    slipPrtSet.SlipBaseColorRed5 = work.SlipBaseColorRed5; // 伝票基準色赤
                                    slipPrtSet.SlipBaseColorGrn5 = work.SlipBaseColorGrn5; // 伝票基準色緑
                                    slipPrtSet.SlipBaseColorBlu5 = work.SlipBaseColorBlu5; // 伝票基準色青
                                    slipPrtSet.CopyCount = work.CopyCount; // 複写枚数
                                    slipPrtSet.TitleName1 = work.TitleName1; // タイトル
                                    slipPrtSet.TitleName2 = work.TitleName2; // タイトル
                                    slipPrtSet.TitleName3 = work.TitleName3; // タイトル
                                    slipPrtSet.TitleName4 = work.TitleName4; // タイトル
                                    slipPrtSet.SpecialPurpose1 = work.SpecialPurpose1; // 特殊用途
                                    slipPrtSet.SpecialPurpose2 = work.SpecialPurpose2; // 特殊用途
                                    slipPrtSet.SpecialPurpose3 = work.SpecialPurpose3; // 特殊用途
                                    slipPrtSet.SpecialPurpose4 = work.SpecialPurpose4; // 特殊用途
                                    slipPrtSet.TitleName102 = work.TitleName102; // タイトル-2
                                    slipPrtSet.TitleName103 = work.TitleName103; // タイトル-3
                                    slipPrtSet.TitleName104 = work.TitleName104; // タイトル-4
                                    slipPrtSet.TitleName105 = work.TitleName105; // タイトル-5
                                    slipPrtSet.TitleName202 = work.TitleName202; // タイトル-2
                                    slipPrtSet.TitleName203 = work.TitleName203; // タイトル-3
                                    slipPrtSet.TitleName204 = work.TitleName204; // タイトル-4
                                    slipPrtSet.TitleName205 = work.TitleName205; // タイトル-5
                                    slipPrtSet.TitleName302 = work.TitleName302; // タイトル-2
                                    slipPrtSet.TitleName303 = work.TitleName303; // タイトル-3
                                    slipPrtSet.TitleName304 = work.TitleName304; // タイトル-4
                                    slipPrtSet.TitleName305 = work.TitleName305; // タイトル-5
                                    slipPrtSet.TitleName402 = work.TitleName402; // タイトル-2
                                    slipPrtSet.TitleName403 = work.TitleName403; // タイトル-3
                                    slipPrtSet.TitleName404 = work.TitleName404; // タイトル-4
                                    slipPrtSet.TitleName405 = work.TitleName405; // タイトル-5
                                    slipPrtSet.Note1 = work.Note1; // 備考
                                    slipPrtSet.Note2 = work.Note2; // 備考
                                    slipPrtSet.Note3 = work.Note3; // 備考
                                    slipPrtSet.QRCodePrintDivCd = work.QRCodePrintDivCd; // QRコード印字区分
                                    slipPrtSet.TimePrintDivCd = work.TimePrintDivCd; // 時刻印字区分
                                    slipPrtSet.ReissueMark = work.ReissueMark; // 再発行マーク
                                    slipPrtSet.RefConsTaxDivCd = work.RefConsTaxDivCd; // 参考消費税区分
                                    slipPrtSet.RefConsTaxPrtNm = work.RefConsTaxPrtNm; // 参考消費税印字名称
                                    slipPrtSet.DetailRowCount = work.DetailRowCount; // 明細行数
                                    slipPrtSet.HonorificTitle = work.HonorificTitle; // 敬称
                                    slipPrtSet.ConsTaxPrtCd = work.ConsTaxPrtCd; // 消費税印字区分
                                    slipPrtSet.SlipNoteCharCnt = work.SlipNoteCharCnt; // 伝票備考桁数
                                    slipPrtSet.SlipNote2CharCnt = work.SlipNote2CharCnt; // 伝票備考２桁数
                                    slipPrtSet.SlipNote3CharCnt = work.SlipNote3CharCnt; // 伝票備考３桁数
                                    //-------ADD 2011/07/19 ------->>>>>>>
                                    slipPrtSet.SCMAnsMarkPrtDiv = work.SCMAnsMarkPrtDiv; // SCM回答マーク印字区分
                                    slipPrtSet.NormalPrtMark = work.NormalPrtMark; // 通常発行マーク
                                    slipPrtSet.SCMAutoAnsMark = work.SCMAutoAnsMark; // SCM手動回答マーク
                                    slipPrtSet.SCMManualAnsMark = work.SCMManualAnsMark; // SCM自動回答マーク
                                    //-------ADD 2011/07/19 -------<<<<<<<
                                    #endregion

                                    this._slipPrtSetList.Add(slipPrtSet);
                                }
                            }
                            #endregion

                            #region 得意先マスタ(伝票管理)
                            if (arList[0] is CustSlipMngWork)
                            {
                                foreach (CustSlipMngWork work in arList)
                                {
                                    CustSlipMng custSlipMng = new CustSlipMng();

                                    #region 項目セット
                                    custSlipMng.CreateDateTime = work.CreateDateTime; // 作成日時
                                    custSlipMng.UpdateDateTime = work.UpdateDateTime; // 更新日時
                                    custSlipMng.EnterpriseCode = work.EnterpriseCode; // 企業コード
                                    custSlipMng.FileHeaderGuid = work.FileHeaderGuid; // GUID
                                    custSlipMng.UpdEmployeeCode = work.UpdEmployeeCode; // 更新従業員コード
                                    custSlipMng.UpdAssemblyId1 = work.UpdAssemblyId1; // 更新アセンブリID1
                                    custSlipMng.UpdAssemblyId2 = work.UpdAssemblyId2; // 更新アセンブリID2
                                    custSlipMng.LogicalDeleteCode = work.LogicalDeleteCode; // 論理削除区分
                                    custSlipMng.DataInputSystem = work.DataInputSystem; // データ入力システム
                                    custSlipMng.SlipPrtKind = work.SlipPrtKind; // 伝票印刷種別
                                    custSlipMng.SectionCode = work.SectionCode; // 拠点コード
                                    custSlipMng.CustomerCode = work.CustomerCode; // 得意先コード
                                    custSlipMng.SlipPrtSetPaperId = work.SlipPrtSetPaperId; // 伝票印刷設定用帳票ID
                                    #endregion

                                    this._custSlipMngList.Add(custSlipMng);
                                }
                            }
                            #endregion

                            #region UOEガイド名称マスタ
                            if (arList[0] is UOEGuideNameWork)
                            {
                                foreach (UOEGuideNameWork work in arList)
                                {
                                    UOEGuideName uoeGuideName = new UOEGuideName();

                                    #region 項目セット
                                    uoeGuideName.CreateDateTime = work.CreateDateTime; // 作成日時
                                    uoeGuideName.UpdateDateTime = work.UpdateDateTime; // 更新日時
                                    uoeGuideName.EnterpriseCode = work.EnterpriseCode; // 企業コード
                                    uoeGuideName.FileHeaderGuid = work.FileHeaderGuid; // GUID
                                    uoeGuideName.UpdEmployeeCode = work.UpdEmployeeCode; // 更新従業員コード
                                    uoeGuideName.UpdAssemblyId1 = work.UpdAssemblyId1; // 更新アセンブリID1
                                    uoeGuideName.UpdAssemblyId2 = work.UpdAssemblyId2; // 更新アセンブリID2
                                    uoeGuideName.LogicalDeleteCode = work.LogicalDeleteCode; // 論理削除区分
                                    uoeGuideName.SectionCode = work.SectionCode; // 拠点コード
                                    uoeGuideName.UOEGuideDivCd = work.UOEGuideDivCd; // UOEガイド区分
                                    uoeGuideName.UOESupplierCd = work.UOESupplierCd; // UOE発注先コード
                                    uoeGuideName.UOEGuideCode = work.UOEGuideCode; // UOEガイドコード
                                    uoeGuideName.UOEGuideNm = work.UOEGuideName; // UOEガイド名称
                                    #endregion

                                    this._uoeGuideNameList.Add(uoeGuideName);
                                }
                            }
                            #endregion

                            #region 部門
                            if (arList[0] is SubSectionWork)
                            {
                                foreach (SubSectionWork work in arList)
                                {
                                    SubSection subSection = new SubSection();
                                    subSection.CreateDateTime = work.CreateDateTime;
                                    subSection.EnterpriseCode = work.EnterpriseCode;
                                    subSection.FileHeaderGuid = work.FileHeaderGuid;
                                    subSection.LogicalDeleteCode = work.LogicalDeleteCode;
                                    subSection.SectionCode = work.SectionCode;
                                    subSection.SubSectionCode = work.SubSectionCode;
                                    subSection.SubSectionName = work.SubSectionName;
                                    subSection.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    subSection.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    subSection.UpdateDateTime = work.UpdateDateTime;
                                    subSection.UpdEmployeeCode = work.UpdEmployeeCode;
                                    this._subSectionList.Add(subSection);
                                }
                            }
                            #endregion

                            #region 掛率優先管理マスタ
                            if (arList[0] is RateProtyMngWork)
                            {
                                foreach (RateProtyMngWork work in arList)
                                {
                                    RateProtyMng rateProtyMng = new RateProtyMng();
                                    rateProtyMng.CreateDateTime = work.CreateDateTime;
                                    rateProtyMng.EnterpriseCode = work.EnterpriseCode;
                                    rateProtyMng.FileHeaderGuid = work.FileHeaderGuid;
                                    rateProtyMng.LogicalDeleteCode = work.LogicalDeleteCode;
                                    rateProtyMng.RateMngCustCd = work.RateMngCustCd;
                                    rateProtyMng.RateMngCustNm = work.RateMngCustNm;
                                    rateProtyMng.RateMngGoodsCd = work.RateMngGoodsCd;
                                    rateProtyMng.RateMngGoodsNm = work.RateMngGoodsNm;
                                    rateProtyMng.RatePriorityOrder = work.RatePriorityOrder;
                                    rateProtyMng.RateSettingDivide = work.RateSettingDivide;
                                    rateProtyMng.SectionCode = work.SectionCode;
                                    rateProtyMng.UnitPriceKind = work.UnitPriceKind;
                                    rateProtyMng.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    rateProtyMng.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    rateProtyMng.UpdateDateTime = work.UpdateDateTime;
                                    rateProtyMng.UpdEmployeeCode = work.UpdEmployeeCode;
                                    this._rateProtyMngList.Add(rateProtyMng);
                                }

                                this.CacheRateProtyMngListCall();
                            }
                            #endregion

                            #region 売上金額処理区分マスタ
                            if (arList[0] is SalesProcMoneyWork)
                            {
                                foreach (SalesProcMoneyWork work in arList)
                                {
                                    SalesProcMoney salesProcMoney = new SalesProcMoney();
                                    salesProcMoney.CreateDateTime = work.CreateDateTime;
                                    salesProcMoney.EnterpriseCode = work.EnterpriseCode;
                                    salesProcMoney.FileHeaderGuid = work.FileHeaderGuid;
                                    salesProcMoney.FracProcMoneyDiv = work.FracProcMoneyDiv;
                                    salesProcMoney.FractionProcCd = work.FractionProcCd;
                                    salesProcMoney.FractionProcCode = work.FractionProcCode;
                                    salesProcMoney.FractionProcUnit = work.FractionProcUnit;
                                    salesProcMoney.LogicalDeleteCode = work.LogicalDeleteCode;
                                    salesProcMoney.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    salesProcMoney.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    salesProcMoney.UpdateDateTime = work.UpdateDateTime;
                                    salesProcMoney.UpdEmployeeCode = work.UpdEmployeeCode;
                                    salesProcMoney.UpperLimitPrice = work.UpperLimitPrice;
                                    this._salesProcMoneyList.Add(salesProcMoney);
                                }

                                this.CacheSalesProcMoneyListCall();
                            }
                            #endregion

                            #region 仕入金額処理区分マスタ
                            if (arList[0] is StockProcMoneyWork)
                            {
                                foreach (StockProcMoneyWork work in arList)
                                {
                                    StockProcMoney stockProcMoney = new StockProcMoney();
                                    stockProcMoney.CreateDateTime = work.CreateDateTime;
                                    stockProcMoney.EnterpriseCode = work.EnterpriseCode;
                                    stockProcMoney.FileHeaderGuid = work.FileHeaderGuid;
                                    stockProcMoney.FracProcMoneyDiv = work.FracProcMoneyDiv;
                                    stockProcMoney.FractionProcCd = work.FractionProcCd;
                                    stockProcMoney.FractionProcCode = work.FractionProcCode;
                                    stockProcMoney.FractionProcUnit = work.FractionProcUnit;
                                    stockProcMoney.LogicalDeleteCode = work.LogicalDeleteCode;
                                    stockProcMoney.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    stockProcMoney.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    stockProcMoney.UpdateDateTime = work.UpdateDateTime;
                                    stockProcMoney.UpdEmployeeCode = work.UpdEmployeeCode;
                                    stockProcMoney.UpperLimitPrice = work.UpperLimitPrice;
                                    this._stockProcMoneyList.Add(stockProcMoney);
                                }

                                this.CacheStockProcMoneyListCall();
                            }
                            #endregion

                            #region ユーザーガイド
                            if (arList[0] is UserGdBdUWork)
                            {
                                foreach (UserGdBdUWork work in arList)
                                {
                                    UserGdBd userGdBd = new UserGdBd();
                                    userGdBd.CreateDateTime = work.CreateDateTime;
                                    userGdBd.EnterpriseCode = work.EnterpriseCode;
                                    userGdBd.FileHeaderGuid = work.FileHeaderGuid;
                                    userGdBd.GuideCode = work.GuideCode;
                                    userGdBd.GuideName = work.GuideName;
                                    userGdBd.GuideType = work.GuideType;
                                    userGdBd.LogicalDeleteCode = work.LogicalDeleteCode;
                                    userGdBd.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    userGdBd.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    userGdBd.UpdateDateTime = work.UpdateDateTime;
                                    userGdBd.UpdEmployeeCode = work.UpdEmployeeCode;
                                    userGdBd.UserGuideDivCd = work.UserGuideDivCd;
                                    this._userGdBdList.Add(userGdBd);
                                }
                            }
                            #endregion

                            //>>>2010/05/30
                            #region SCM全体設定
                            if (arList[0] is SCMTtlStWork)
                            {
                                SCMTtlStWork work = this.GetScmTtlStFromList(sectionCode, arList);
                                SCMTtlSt scmTtlSt = new SCMTtlSt();
                                scmTtlSt.AcpOdrrSlipPrtDiv = work.AcpOdrrSlipPrtDiv;
                                scmTtlSt.AutoAnswerDiv = work.AutoAnswerDiv;
                                scmTtlSt.AutoCooperatDis = work.AutoCooperatDis;
                                scmTtlSt.BLCodeChgDiv = work.BLCodeChgDiv;
                                scmTtlSt.CreateDateTime = work.CreateDateTime;
                                scmTtlSt.DiscountApplyCd = work.DiscountApplyCd;
                                scmTtlSt.EnterpriseCode = work.EnterpriseCode;
                                scmTtlSt.EstimatePrtDiv = work.EstimatePrtDiv;
                                scmTtlSt.FileHeaderGuid = work.FileHeaderGuid;
                                scmTtlSt.LogicalDeleteCode = work.LogicalDeleteCode;
                                scmTtlSt.OldSysCooperatDiv = work.OldSysCooperatDiv;
                                scmTtlSt.OldSysCoopFolder = work.OldSysCoopFolder;
                                scmTtlSt.SalesSlipPrtDiv = work.SalesSlipPrtDiv;
                                scmTtlSt.SectionCode = work.SectionCode;
                                scmTtlSt.UpdAssemblyId1 = work.UpdAssemblyId1;
                                scmTtlSt.UpdAssemblyId2 = work.UpdAssemblyId2;
                                scmTtlSt.UpdateDateTime = work.UpdateDateTime;
                                scmTtlSt.UpdEmployeeCode = work.UpdEmployeeCode;
                                scmTtlSt.FuwioutAutoAnsDiv = work.FuwioutAutoAnsDiv;// ADD 2014/07/23 Redmine#43080の3SCM受発注明細データに在庫状況区分のセット
                                this._scmTtlSt = scmTtlSt;
                            }
                            #endregion

                            #region SCM納期設定マスタ
                            if (arList[0] is SCMDeliDateStWork)
                            {
                                foreach (SCMDeliDateStWork work in arList)
                                {
                                    SCMDeliDateSt scmDeliDateSt = new SCMDeliDateSt();
                                    scmDeliDateSt.AnswerDeadTime1 = work.AnswerDeadTime1;
                                    scmDeliDateSt.AnswerDeadTime2 = work.AnswerDeadTime2;
                                    scmDeliDateSt.AnswerDeadTime3 = work.AnswerDeadTime3;
                                    scmDeliDateSt.AnswerDeadTime4 = work.AnswerDeadTime4;
                                    scmDeliDateSt.AnswerDeadTime5 = work.AnswerDeadTime5;
                                    scmDeliDateSt.AnswerDeadTime6 = work.AnswerDeadTime6;
                                    scmDeliDateSt.AnswerDelivDate1 = work.AnswerDelivDate1;
                                    scmDeliDateSt.AnswerDelivDate2 = work.AnswerDelivDate2;
                                    scmDeliDateSt.AnswerDelivDate3 = work.AnswerDelivDate3;
                                    scmDeliDateSt.AnswerDelivDate4 = work.AnswerDelivDate4;
                                    scmDeliDateSt.AnswerDelivDate5 = work.AnswerDelivDate5;
                                    scmDeliDateSt.AnswerDelivDate6 = work.AnswerDelivDate6;
                                    scmDeliDateSt.CreateDateTime = work.CreateDateTime;
                                    scmDeliDateSt.CustomerCode = work.CustomerCode;
                                    scmDeliDateSt.EnterpriseCode = work.EnterpriseCode;
                                    scmDeliDateSt.FileHeaderGuid = work.FileHeaderGuid;
                                    scmDeliDateSt.LogicalDeleteCode = work.LogicalDeleteCode;
                                    scmDeliDateSt.SectionCode = work.SectionCode;
                                    scmDeliDateSt.UpdAssemblyId1 = work.UpdAssemblyId1;
                                    scmDeliDateSt.UpdAssemblyId2 = work.UpdAssemblyId2;
                                    scmDeliDateSt.UpdateDateTime = work.UpdateDateTime;
                                    scmDeliDateSt.UpdEmployeeCode = work.UpdEmployeeCode;
                                    // 2011/01/31 Add >>>
                                    scmDeliDateSt.AnswerDeadTime1Stc = work.AnswerDeadTime1Stc;
                                    scmDeliDateSt.AnswerDeadTime2Stc = work.AnswerDeadTime2Stc;
                                    scmDeliDateSt.AnswerDeadTime3Stc = work.AnswerDeadTime3Stc;
                                    scmDeliDateSt.AnswerDeadTime4Stc = work.AnswerDeadTime4Stc;
                                    scmDeliDateSt.AnswerDeadTime5Stc = work.AnswerDeadTime5Stc;
                                    scmDeliDateSt.AnswerDeadTime6Stc = work.AnswerDeadTime6Stc;
                                    scmDeliDateSt.AnswerDelivDate1Stc = work.AnswerDelivDate1Stc;
                                    scmDeliDateSt.AnswerDelivDate2Stc = work.AnswerDelivDate2Stc;
                                    scmDeliDateSt.AnswerDelivDate3Stc = work.AnswerDelivDate3Stc;
                                    scmDeliDateSt.AnswerDelivDate4Stc = work.AnswerDelivDate4Stc;
                                    scmDeliDateSt.AnswerDelivDate5Stc = work.AnswerDelivDate5Stc;
                                    scmDeliDateSt.AnswerDelivDate6Stc = work.AnswerDelivDate6Stc;
                                    scmDeliDateSt.EntStckAnsDeliDtDiv = work.EntStckAnsDeliDtDiv;
                                    scmDeliDateSt.EntStckAnsDeliDate = work.EntStckAnsDeliDate;
                                    // 2011/01/31 Add <<<
                                    // --- ADD 2012/09/13 三戸 2012/10/17配信分 障害一覧 №2 --------->>>>>>>>>>>>>>>>>>>>>>>>
                                    scmDeliDateSt.PriStckAnsDeliDtDiv = work.PriStckAnsDeliDtDiv;   // 優先在庫回答納期区分
                                    scmDeliDateSt.PriStckAnsDeliDate = work.PriStckAnsDeliDate;     // 優先在庫回答納期
                                    scmDeliDateSt.AnsDelDatShortOfStc = work.AnsDelDatShortOfStc;   // 回答納期（在庫不足）
                                    scmDeliDateSt.AnsDelDatWithoutStc = work.AnsDelDatWithoutStc;   // 回答納期（在庫数無し）
                                    scmDeliDateSt.EntStcAnsDelDatShort = work.EntStcAnsDelDatShort; // 委託在庫回答納期（在庫不足）
                                    scmDeliDateSt.EntStcAnsDelDatWiout = work.EntStcAnsDelDatWiout; // 委託在庫回答納期（在庫数無し）
                                    scmDeliDateSt.PriStcAnsDelDatShort = work.PriStcAnsDelDatShort; // 参照在庫回答納期（在庫不足）
                                    scmDeliDateSt.PriStcAnsDelDatWiout = work.PriStcAnsDelDatWiout; // 参照在庫回答納期（在庫数無し）
                                    // --- ADD 2012/09/13 三戸 2012/10/17配信分 障害一覧 №2 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                                    // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                                    scmDeliDateSt.AnsDelDtDiv1 = work.AnsDelDtDiv1; //        回答納期区分１
                                    scmDeliDateSt.AnsDelDtDiv2 = work.AnsDelDtDiv2; //        回答納期区分２
                                    scmDeliDateSt.AnsDelDtDiv3 = work.AnsDelDtDiv3; //        回答納期区分３
                                    scmDeliDateSt.AnsDelDtDiv4 = work.AnsDelDtDiv4; //        回答納期区分４
                                    scmDeliDateSt.AnsDelDtDiv5 = work.AnsDelDtDiv5; //        回答納期区分５
                                    scmDeliDateSt.AnsDelDtDiv6 = work.AnsDelDtDiv6; //        回答納期区分６
                                    scmDeliDateSt.AnsDelDtDiv1Stc = work.AnsDelDtDiv1Stc; //     回答納期区分１（在庫）
                                    scmDeliDateSt.AnsDelDtDiv2Stc = work.AnsDelDtDiv2Stc; //     回答納期区分２（在庫）
                                    scmDeliDateSt.AnsDelDtDiv3Stc = work.AnsDelDtDiv3Stc; //     回答納期区分３（在庫）
                                    scmDeliDateSt.AnsDelDtDiv4Stc = work.AnsDelDtDiv4Stc; //     回答納期区分４（在庫）
                                    scmDeliDateSt.AnsDelDtDiv5Stc = work.AnsDelDtDiv5Stc; //     回答納期区分５（在庫）
                                    scmDeliDateSt.AnsDelDtDiv6Stc = work.AnsDelDtDiv6Stc; //     回答納期区分６（在庫）
                                    scmDeliDateSt.EntAnsDelDtStcDiv = work.EntAnsDelDtStcDiv; //    委託在庫回答納期区分（在庫）
                                    scmDeliDateSt.PriAnsDelDtStcDiv = work.PriAnsDelDtStcDiv; //    優先在庫回答納期区分（在庫）
                                    scmDeliDateSt.AnsDelDtShoStcDiv = work.AnsDelDtShoStcDiv; //    回答納期区分（在庫不足）
                                    scmDeliDateSt.AnsDelDtWioStcDiv = work.AnsDelDtWioStcDiv; //    回答納期区分（在庫数無し）
                                    scmDeliDateSt.EntAnsDelDtShoDiv = work.EntAnsDelDtShoDiv; //    委託在庫回答納期区分（在庫不足）
                                    scmDeliDateSt.EntAnsDelDtWioDiv = work.EntAnsDelDtWioDiv; //    委託在庫回答納期区分（在庫数無し）
                                    scmDeliDateSt.PriAnsDelDtShoDiv = work.PriAnsDelDtShoDiv; //    優先在庫回答納期区分（在庫不足）
                                    scmDeliDateSt.PriAnsDelDtWioDiv = work.PriAnsDelDtWioDiv; //    優先在庫回答納期区分（在庫数無し）
                                    // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                                    this._scmDeliDateStList.Add(scmDeliDateSt);
                                }
                            }
                            #endregion

                            // --- DEL 2010/06/26 ---------->>>>>
                            //#region BLコード変換マスタ
                            //if (arList[0] is TbsPartsCdChgWork)
                            //{
                            //    this._tbsPartsCdChgWorkList = new List<TbsPartsCdChgWork>((TbsPartsCdChgWork[])arList.ToArray(typeof(TbsPartsCdChgWork)));
                            //}
                            //#endregion
                            // --- DEL 2010/06/26 ----------<<<<<
                            //<<<2010/05/30

                            //>>>2011/09/27
                            #region 在庫管理全体設定
                            if (arList[0] is StockMngTtlStWork)
                            {
                                this._stockMngTtlSt = new StockMngTtlSt();
                                StockMngTtlStWork svWork = new StockMngTtlStWork();
                                foreach (StockMngTtlStWork work in arList)
                                {
                                    if ((work.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                                        (work.SectionCode.Trim() == ctSectionCode.Trim()))
                                    {
                                        svWork = work;
                                    }
                                }
                                #region 項目セット
                                this._stockMngTtlSt.CreateDateTime = svWork.CreateDateTime;
                                this._stockMngTtlSt.UpdateDateTime = svWork.UpdateDateTime;
                                this._stockMngTtlSt.EnterpriseCode = svWork.EnterpriseCode;
                                this._stockMngTtlSt.FileHeaderGuid = svWork.FileHeaderGuid;
                                this._stockMngTtlSt.UpdEmployeeCode = svWork.UpdEmployeeCode;
                                this._stockMngTtlSt.UpdAssemblyId1 = svWork.UpdAssemblyId1;
                                this._stockMngTtlSt.UpdAssemblyId2 = svWork.UpdAssemblyId2;
                                this._stockMngTtlSt.LogicalDeleteCode = svWork.LogicalDeleteCode;
                                this._stockMngTtlSt.SectionCode = svWork.SectionCode;
                                this._stockMngTtlSt.StockMoveFixCode = svWork.StockMoveFixCode;
                                this._stockMngTtlSt.StockPointWay = svWork.StockPointWay;
                                this._stockMngTtlSt.FractionProcCd = svWork.FractionProcCd;
                                this._stockMngTtlSt.StockTolerncShipmDiv = svWork.StockTolerncShipmDiv;
                                this._stockMngTtlSt.InvntryPrtOdrIniDiv = svWork.InvntryPrtOdrIniDiv;
                                this._stockMngTtlSt.MaxStkCntOverOderDiv = svWork.MaxStkCntOverOderDiv;
                                this._stockMngTtlSt.ShelfNoDuplDiv = svWork.ShelfNoDuplDiv;
                                this._stockMngTtlSt.LotUseDivCd = svWork.LotUseDivCd;
                                this._stockMngTtlSt.SectDspDivCd = svWork.SectDspDivCd;
                                this._stockMngTtlSt.InventoryMngDiv = svWork.InventoryMngDiv;
                                this._stockMngTtlSt.PreStckCntDspDiv = svWork.PreStckCntDspDiv; // 現在庫数表示区分(0:受注分含む 1:受注分含まない)
                                #endregion
                            }
                            #endregion
                            //<<<2011/09/27
                        }
                    }
                }
            }
            return 0;  
        }

        # region ■売上金額処理区分設定マスタ制御処理
        /// <summary>
        /// 売上金額処理区分設定キャッシュデリゲート コール処理
        /// </summary>
        public void CacheSalesProcMoneyListCall()
        {
            if (this.CacheSalesProcMoneyList != null) this.CacheSalesProcMoneyList(this._salesProcMoneyList);
        }
        # endregion

        # region ■仕入金額処理区分設定マスタ制御処理
        /// <summary>
        /// 仕入金額処理区分設定キャッシュデリゲート コール処理
        /// </summary>
        public void CacheStockProcMoneyListCall()
        {
            if (this.CacheStockProcMoneyList != null) this.CacheStockProcMoneyList(this._stockProcMoneyList);
        }
        # endregion

        # region ■掛率優先管理マスタ制御処理
        /// <summary>
        /// 掛率優先管理マスタキャッシュデリゲート コール処理
        /// </summary>
        public void CacheRateProtyMngListCall()
        {
            if (this.CacheRateProtyMngList != null) this.CacheRateProtyMngList(this._rateProtyMngList);
        }
        # endregion

        #region ■DEBUGログ出力
        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (SalesSlipInputInitDataAcs._Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    SalesSlipInputInitDataAcs._Log_Check = 1;
                }
                else
                {
                    SalesSlipInputInitDataAcs._Log_Check = 2;
                }

            }

            if (SalesSlipInputInitDataAcs._Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
        // --- UPD T.Nishi 2012/12/19 ---------->>>>>
        //#endif
        }
        // --- UPD T.Nishi 2012/12/19 ----------<<<<<
    }

        #endregion

        #region ■オプション情報制御処理
        /// <summary>
        /// オプション情報キャッシュ
        /// </summary>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ●車両管理オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_CarMng);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_CarMng = (int)Option.ON;
            }
            else
            {
                this._opt_CarMng = (int)Option.OFF;
            }
            #endregion

            #region ●自由検索オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FreeSearch = (int)Option.ON;
            }
            else
            {
                this._opt_FreeSearch = (int)Option.OFF;
            }
            #endregion

            #region ●ＰＣＣオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_PCC);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PCC = (int)Option.ON;
            }
            else
            {
                this._opt_PCC = (int)Option.OFF;
            }
            #endregion

            #region ●リサイクル連動オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_RCLink);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_RCLink = (int)Option.ON;
            }
            else
            {
                this._opt_RCLink = (int)Option.OFF;
            }
            #endregion

            #region ●ＵＯＥオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_UOE);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_UOE = (int)Option.ON;
            }
            else
            {
                this._opt_UOE = (int)Option.OFF;
            }
            #endregion

            #region ●仕入支払管理オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockingPayment = (int)Option.ON;
            }
            else
            {
                this._opt_StockingPayment = (int)Option.OFF;
            }
            #endregion

            //>>>2010/05/30
            #region ●SCMオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_SCM = (int)Option.ON;
            }
            else
            {
                this._opt_SCM = (int)Option.OFF;
            }
            #endregion
            //<<<2010/05/30

            // --- ADD 2010/06/26 ---- >>>>>
            #region ●QRオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_QRMail);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_QRMail = (int)Option.ON;
            }
            else
            {
                this._opt_QRMail = (int)Option.OFF;
            }
            #endregion
            // --- ADD 2010/06/26 ---- <<<<<
            // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
            #region ●売上日付制御オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SalesDateControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_DateCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_DateCtrl = (int)Option.OFF;
            }
            #endregion
            // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
            #region ●㈱フタバオプション（個別）
            // フタバ伝票印刷制御オプション（個別）：OPT-CPM0090
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaSlipPrtCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaSlipPrtCtl = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaSlipPrtCtl = (int)Option.OFF;
            }
            // フタバ伝票印刷制御オプション（個別）：OPT-CPM0100
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaWarehAlloc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaWarehAlloc = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaWarehAlloc = (int)Option.OFF;
            }
            // フタバUOEオプション（個別）：OPT-CPM0110
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaUOECtl = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaUOECtl = (int)Option.OFF;
            }
            // フタバ出力済伝票制御オプション（個別）：OPT-CPM0120
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaOutSlipCtl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Cpm_FutabaOutSlipCtl = (int)Option.ON;
            }
            else
            {
                this._opt_Cpm_FutabaOutSlipCtl = (int)Option.OFF;
            }
            #endregion

            #region ●BLP参照倉庫追加オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BLPRefWarehouse);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_BLPRefWarehouse = (int)Option.ON;
            }
            else
            {
                this._opt_BLPRefWarehouse = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

            // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
            #region ●TSPオプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_Tsp);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_TSP = (int)Option.ON;
            }
            else
            {
                this._opt_TSP = (int)Option.OFF;
            }
            #endregion
            // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<<
        }
        #endregion

        //受発注管理全体設定
        public AcptAnOdrTtlSt GetAcptAnOdrTtlSt()
        {
            return this._acptAnOdrTtlSt;
        }
        //売上全体設定
        public SalesTtlSt GetSalesTtlSt()
        {
            return this._salesTtlSt;
        }
        //見積初期値設定
        public EstimateDefSet GetEstimateDefSet()
        {
            return this._estimateDefSet;
        }
        //仕入在庫全体
        public StockTtlSt GetStockTtlSt()
        {
            return this._stockTtlSt;
        }
        //全体初期値
        public AllDefSet GetAllDefSet()
        {
            return this._allDefSet;
        }
        //自社情報
        public CompanyInf GetCompanyInf()
        {
            return this._companyInf;
        }
        //伝票印刷設定マスタ
        public List<SlipPrtSet> GetSlipPrtSetList()
        {
            return this._slipPrtSetList;
        }
        //得意先マスタ(伝票管理
        public List<CustSlipMng> GetCustSlipMngList()
        {
            return this._custSlipMngList;
        }
        //UOEガイド名称マスタ
        public List<UOEGuideName> GetUoeGuideNameList()
        {
            return this._uoeGuideNameList;
        }
        //部門
        public List<SubSection> GetSubSectionList()
        {
            return this._subSectionList;
        }
        //掛率優先管理マスタ
        public List<RateProtyMng> GetRateProtyMngList()
        {
            return this._rateProtyMngList;
        }
        //売上金額処理区分マスタ
        public List<SalesProcMoney> GetSalesProcMoneyList()
        {
            return this._salesProcMoneyList;
        }
        //仕入金額処理区分マスタ
        public List<StockProcMoney> GetStockProcMoneyList()
        {
            return this._stockProcMoneyList;
        }
        //ユーザーガイド
        public List<UserGdBd> GetUserGdBdList()
        {
            return this._userGdBdList;
        }

        //>>>2010/05/30
        # region ■SCM全体設定制御処理
        /// <summary>
        /// SCM全体設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="allDefSetArrayList">全体初期値設定マスタオブジェクトリスト</param>
        /// <returns>全体初期値設定マスタオブジェクト</returns>
        private SCMTtlStWork GetScmTtlStFromList(string sectionCode, ArrayList scmTtlStArrayList)
        {
            if (scmTtlStArrayList == null) return null;

            List<SCMTtlStWork> list = new List<SCMTtlStWork>((SCMTtlStWork[])scmTtlStArrayList.ToArray(typeof(SCMTtlStWork)));

            SCMTtlStWork scmTtlSt = list.Find(
                delegate(SCMTtlStWork scmTtl)
                {
                    if (scmTtl.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (scmTtlSt != null) return scmTtlSt;

            scmTtlSt = list.Find(
                delegate(SCMTtlStWork scmTtl)
                {
                    if (scmTtl.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return scmTtlSt;
        }

        /// <summary>
        /// SCM全体設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        public SCMTtlSt GetScmTtlSt()
        {
            return this._scmTtlSt;
        }
        # endregion

        #region ■SCM納期設定マスタ
        /// <summary>
        /// SCM納期設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        public List<SCMDeliDateSt> GetScmDeliDateStList()
        {
            return this._scmDeliDateStList;
        }
        # endregion

        // --- DEL 2010/06/26 ---------->>>>>
        //#region ■BLコード変換マスタ
        ///// <summary>
        ///// BLコード変換マスタ取得処理
        ///// </summary>
        ///// <returns></returns>
        //public List<TbsPartsCdChgWork> GetTbsPartsCdChgWorkList()
        //{
        //    return this._tbsPartsCdChgWorkList;
        //}
        //# endregion
        // --- DEL 2010/06/26 ----------<<<<<
        //<<<2010/05/30

        //>>>2011/09/27
        #region ■在庫管理全体設定
        public StockMngTtlSt GetStockMngTtlSt()
        {
            return this._stockMngTtlSt;
        }
        #endregion
        //<<<2011/09/27


        /// <summary>
        /// 車両管理オプション
        /// </summary>
        public int OptCarMng()
        {
            return this._opt_CarMng;
        }
        /// <summary>
        /// 自由検索オプション
        /// </summary>
        public int OptFreeSearch()
        {
            return this._opt_FreeSearch;
        }
        /// <summary>
        /// ＰＣＣオプション
        /// </summary>
        public int OptPCC()
        {
            return this._opt_PCC;
        }
        /// <summary>
        /// リサイクル連動オプション
        /// </summary>
        public int OptRCLink()
        {
            return this._opt_RCLink;
        }
        /// <summary>
        /// ＵＯＥオプション
        /// </summary>
        public int OptUOE()
        {
            return this._opt_UOE;
        }
        /// <summary>
        /// 仕入支払管理オプション
        /// </summary>
        public int OptStockingPayment()
        {
            return this._opt_StockingPayment;
        }

        //>>>2010/05/30
        /// <summary>
        /// SCMオプション
        /// </summary>
        /// <returns></returns>
        public int OptSCM()
        {
            return this._opt_SCM;
        }
        //<<<2010/05/30

        // --- ADD 2010/06/26 ---- >>>>>
        /// <summary>
        /// QRオプション
        /// </summary>
        /// <returns></returns>
        public int OptQRMail()
        {
            return this._opt_QRMail;
        }
        // --- ADD 2010/06/26 ---- <<<<<
        // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
        /// <summary>
        /// 売上日付制御オプション
        /// </summary>
        /// <returns></returns>
        public int OptDateCtrl()
        {
            return this._opt_DateCtrl;
        }
        // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// フタバ伝票印刷制御オプション（個別）：OPT-CPM0090
        /// </summary>
        /// <returns></returns>
        public int Opt_Cpm_FutabaSlipPrtCtl()
        {
            return this._opt_Cpm_FutabaSlipPrtCtl;
        }
        /// <summary>
        /// フタバ倉庫引当てオプション（個別）：OPT-CPM0100
        /// </summary>
        /// <returns></returns>
        public int Opt_Cpm_FutabaWarehAlloc()
        {
            return this._opt_Cpm_FutabaWarehAlloc;
        }
        /// <summary>
        /// フタバUOEオプション（個別）：OPT-CPM0110
        /// </summary>
        /// <returns></returns>
        public int Opt_Cpm_FutabaUOECtl()
        {
            return this._opt_Cpm_FutabaUOECtl;
        }
        /// <summary>
        /// フタバ出力済伝票制御オプション（個別）：OPT-CPM0120
        /// </summary>
        /// <returns></returns>
        public int Opt_Cpm_FutabaOutSlipCtl()
        {
            return this._opt_Cpm_FutabaOutSlipCtl;
        }

        // BLP参照倉庫追加オプション
        public int Opt_BLPRefWarehouse()
        {
            return this._opt_BLPRefWarehouse;
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        /// <summary>
        /// TSPオプション
        /// </summary>
        public int OptTSP()
        {
           return this._opt_TSP;
        }
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
        # endregion

    }
}

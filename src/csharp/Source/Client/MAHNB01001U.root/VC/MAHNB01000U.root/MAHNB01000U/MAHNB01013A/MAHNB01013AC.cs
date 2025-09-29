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
using System.Reflection;// ADD 鄧潘ハン K2014/02/17

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
    /// <br>Update Note: 2012/11/13 宮本 利明</br>
    /// <br>管理番号   : 10801804-00 №1668</br>
    /// <br>             売上過去日付制御を個別オプション化（イスコまたはオプションありで日付制御）</br>
    /// <br>Update Note: 2012/12/19 西 毅</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             MAHNB01001U.Logが存在する場合ログを出力するように変更</br>
    /// <br>Update Note: 2012/12/21 宮本 利明</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             山形部品オプション対応</br>
    /// <br>Update Note: K2013/09/20 宮本 利明</br>
    /// <br>             ㈱フタバオプション対応（個別）</br>
    /// <br>Update Note: K2014/01/22 譚洪</br>
    /// <br>管理番号   : 10970602-00</br>
    /// <br>             登戸個別特販区分の変更対応</br>
    /// <br>Update Note: K2014/02/17 鄧潘ハン</br>
    /// <br>管理番号   : 10970602-00</br>
    /// <br>             ＵＳＢ登戸個別オプションＯＮ ＡＮＤ 特販管理マスタの個別</br>
    /// <br>             アセンブリが動作環境に存在する場合 ⇒オプションＯＮの対応</br>
    /// <br>Update Note: K2015/04/01 高騁 </br>
    /// <br>管理番号   : 11100713-00</br>
    /// <br>           : 森川部品個別依頼の改良作業全拠点在庫情報一覧機能追加</br>
    /// <br>Update Note: K2015/04/29 黄興貴</br>
    /// <br>管理番号   : 11100543-00 富士ジーワイ商事㈱ UOE取込対応</br>
    /// <br>Update Note: K2015/06/18 紀飛</br>
    /// <br>管理番号   : 11100543-00 ㈱メイゴ　WebUOE発注回答取込対応</br>
    /// <br>Update Note: K2016/11/01 譚洪</br>
    /// <br>管理番号   : 11202099-00 売上伝票入力から外部PGを起動して売単価を算出の対応</br>
    /// <br>             ㈱コーエイオプション（個別）</br>
    /// <br>Update Note: K2016/12/14  時シン</br>
    /// <br>管理番号   : 11202330-00</br>
    /// <br>           : 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応</br>
    /// <br>Update Note: K2016/12/26 譚洪</br>
    /// <br>管理番号   : 11270116-00 売上伝票入力パッケージ出荷用ソースのマージ</br>
    /// <br>             ㈱福田部品オプション（個別）</br>
    /// <br>Update Note: K2016/12/30 譚洪</br>
    /// <br>管理番号   : 11202452-00</br>
    /// <br>             水野商工様個別変更内容をPM.NSにて実現するため、第二売価の対応行います。</br>
    /// <br>Update Note: 2020/11/20 陳艶丹</br>
    /// <br>管理番号   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
    /// <br>Update Note: 2021/08/23 陳艶丹</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : PMKOBETSU-4178 税率のログ追加</br> 
    /// <br>Update Note: 2021/10/09 田建委</br>
    /// <br>管理番号   : 11601223-00</br>
    /// <br>           : PMKOBETSU-4192 伝票入力後の処理が遅い件の調査</br>
    /// <br>Update Note: 2022/01/05 陳艶丹</br>
    /// <br>管理番号   : 11800082-00</br>
    /// <br>           : PMKOBETSU-4148 メーカー名と仕入先名チェック追加</br> 
    /// </remarks>
    public class DelphiSalesSlipInputInitDataSecondAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiSalesSlipInputInitDataSecondAcs()
        {
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiSalesSlipInputInitDataSecondAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataSecondAcs == null)
            {
                _delphiSalesSlipInputInitDataSecondAcs = new DelphiSalesSlipInputInitDataSecondAcs();
            }
            return _delphiSalesSlipInputInitDataSecondAcs;
        }
        # endregion

        #region ■プライベート変数
        private static DelphiSalesSlipInputInitDataSecondAcs _delphiSalesSlipInputInitDataSecondAcs;

        private List<Employee> _employeeList = null;           // 従業員マスタリスト
        private List<EmployeeDtl> _employeeDtlList = null;     // 従業員詳細マスタリスト
        private UOESetting _uoeSetting = null;                 // UOE自社マスタ
        private PosTerminalMg _posTerminalMg = null;
        private TaxRateSet _taxRateSet = null;                 // 税率設定マスタ
        private double _taxRate = 0;
        //private List<TbsPartsCdChgWork> _tbsPartsCdChgWorkList = null; // BLコード変換マスタリスト // 2010/05/30 // 2010/06/26

        /// <summary> 入力モード</summary>
        //private int _inputMode; // 2010/05/30
        /// <summary>オプション情報</summary>
        private int _opt_CarMng;
        private int _opt_FreeSearch;
        private int _opt_PCC;
        private int _opt_RCLink;
        private int _opt_UOE;
        private int _opt_StockingPayment;
        private int _opt_SCM; // 2010/05/30
        private int _opt_QRMail; // 2010/05/30
        private int _opt_DateCtrl; // 2012/11/13 T.Miyamoto ADD
        private int _opt_NoBuTo; // ADD 譚洪 K2014/01/22
        // ---ADD 鄧潘ハン K2014/02/17--------------->>>>>
        private MethodInfo _myMethodNobuto; // 参照用方法コール
        private object _objNobuto;          // 参照用object
        // ---ADD 鄧潘ハン K2014/02/17---------------<<<<<
        private int _opt_FuJi; // 富士ジーワイ商事㈱オプション（個別）// ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱
        private int _opt_MeiGo; // ㈱メイゴオプション（個別）// ADD K2015/06/18 紀飛 ㈱メイゴ　WebUOE発注回答取込
        private int _opt_Mizuno2ndSellPriceCtl;　　// ADD K2016/12/30 譚洪 水野商工㈱
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        private int _opt_StockEntCtrl;  // 売仕入同時入力制御オプション    (OPT-CPM0050)
        private int _opt_StockDateCtrl; // 仕入日付フォーカス制御オプション(OPT-CPM0060)
        private int _opt_SalesCostCtrl; // 原価修正制御オプション          (OPT-CPM0070)
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        private int _opt_Cpm_FutabaSlipPrtCtl; // フタバ伝票印刷制御オプション（個別）：OPT-CPM0090
        private int _opt_Cpm_FutabaWarehAlloc; // フタバ倉庫引当てオプション  （個別）：OPT-CPM0100
        private int _opt_Cpm_FutabaUOECtl;     // フタバUOEオプション         （個別）：OPT-CPM0110
        private int _opt_Cpm_FutabaOutSlipCtl; // フタバ出力済伝票制御        （個別）：OPT-CPM0120

        private int _opt_BLPRefWarehouse;   // BLP参照倉庫追加オプション：OPT-PM00230
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
        private int _opt_MoriKawa; // 森川部品オプション（個別）// ADD K2015/04/01 高騁 森川部品個別依頼
        private int _opt_YamagataCustom; // 山形部品㈱ 売上伝票入力(価格・売価変更ロック)(個別) // ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応
        private int _opt_PermitForKoei; // ㈱コーエイオプション（個別）  // ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ

        private int _opt_FukudaCustom; // ㈱福田部品オプション（個別）  // ADD 譚洪 K2016/12/26 ㈱福田部品
        private int _opt_PM_EBooks;   // 電子帳簿連携オプション // ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        private int _opt_TSP;
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
        // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加--->>>>
        // ログ出力部品
        OutLogCommon LogCommon;
        //private const string PGID_Log = "MAHNB01001U";//DEL 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査
        private const string CtRateLogSetting = "MAHNB01001URateLog";//ADD 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査
        private const string CtStGetTaxRateStatus = "画面起動 税率取得 status:{0}";
        private const string CtStGetTaxRateNull = "画面起動 税率取得Null";
        // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加---<<<<
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;//ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応
        // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 --->>>>>
        private SupplierAcs _supplierAcs;
        private List<Supplier> _supplierList = null;
        private const string LOGWRITESUPPLIER = "仕入先リストを取得";
        // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 ---<<<<<
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

        /// <summary>備考ガイド区分コード１</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_1 = 101;//伝票備考１
        /// <summary>備考ガイド区分コード２</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_2 = 102;//伝票備考２
        /// <summary>備考ガイド区分コード３</summary>
        public static readonly int ctDIVCODE_NoteGuideDivCd_3 = 106;//伝票備考２

        /// <summary>車輌備考ガイド区分コード</summary>
        public static readonly int ctDIVCODE_CarNoteGuideDivCd = 201;//車輌備考

        /// <summary>品番必須モード</summary>
        public static readonly int ctINPUTMODE_NecessaryGoodsNo = 1;
        /// <summary>品番任意モード</summary>
        //public static readonly int ctINPUTMODE_VoluntaryGoodsNo = 2;
        public static readonly int ctINPUTMODE_VoluntaryGoodsNo = 0;
        /// <summary>端数処理対象金額区分（売上金額）</summary>
        public const int ctFracProcMoneyDiv_SalesMoney = 0;
        /// <summary>端数処理対象金額区分（消費税）</summary>
        public const int ctFracProcMoneyDiv_Tax = 1;
        /// <summary>端数処理対象金額区分（売上単価）</summary>
        public const int ctFracProcMoneyDiv_SalesUnitPrice = 2;
        /// <summary>端数処理対象金額区分（原価単価）</summary>
        public const int ctFracProcMoneyDiv_SalesUnitCost = 2;
        /// <summary>端数処理対象金額区分（原価金額）</summary>
        public const int ctFracProcMoneyDiv_Cost = 0;

        /// <summary>拠点コード(全体)</summary>
        public const string ctSectionCode = "00";
        # endregion

        #region ■デリゲート
        /// <summary>売上金額処理区分設定キャッシュデリゲート</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>仕入金額処理区分設定キャッシュデリゲート</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        /// <summary>掛率優先管理マスタキャッシュデリゲート</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);

        #endregion

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2021/08/23 陳艶丹</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : PMKOBETSU-4178 税率のログ追加</br> 
        /// <br>Update Note: 2021/10/09 田建委</br>
        /// <br>管理番号   : 11601223-00</br>
        /// <br>           : PMKOBETSU-4192 伝票入力後の処理が遅い件の調査</br>
        /// </remarks>
        public int ReadInitDataSecond(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            ArrayList aList2;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            #region ●税率設定マスタSFUKK09002A
            LogWrite("２消費税を取得");
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            TaxRateSetAcs.SearchMode taxRateSearchMode = (ctIsLocalDBRead == true) ? TaxRateSetAcs.SearchMode.Local : TaxRateSetAcs.SearchMode.Remote;
            status = taxRateSetAcs.Search(out aList, enterpriseCode, taxRateSearchMode);
            

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                this._taxRateSet = (TaxRateSet)aList[0];
                this._taxRate = this.GetTaxRate(DateTime.Today);
                // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加--->>>>
                if (_taxRateSet == null)
                {
                    // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
                    this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
                    if (_salesSlipInputInitDataAcs.ProcessControlSetting.RateLogOutFlg == (int)SalesSlipInputInitDataAcs.OutFlgType.Output)
                    {
                    // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<
                        try
                        {
                            // ログ出力
                            if (LogCommon == null)
                            {
                                LogCommon = new OutLogCommon();
                            }
                            //LogCommon.OutputClientLog(PGID_Log, CtStGetTaxRateNull, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//DEL 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査
                            LogCommon.OutputClientLog(CtRateLogSetting, CtStGetTaxRateNull, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//ADD 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査
                        }
                        catch
                        {
                            // 既存ロジックに影響無し
                        }
                    }//ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応
                }
                // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加---<<<<
            }
            // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加--->>>>
            else
            {
                // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応--->>>>>
                this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
                if (_salesSlipInputInitDataAcs.ProcessControlSetting.RateLogOutFlg == (int)SalesSlipInputInitDataAcs.OutFlgType.Output)
                {
                // --- ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応---<<<<<
                    try
                    {
                        //メッセージ
                        string logMsg = string.Format(CtStGetTaxRateStatus, status.ToString());

                        // ログ出力
                        if (LogCommon == null)
                        {
                            LogCommon = new OutLogCommon();
                        }
                        //LogCommon.OutputClientLog(PGID_Log, logMsg, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//DEL 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査
                        LogCommon.OutputClientLog(CtRateLogSetting, logMsg, enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);//ADD 2021/10/09 田建委 PMKOBETSU-4192 伝票入力後の処理が遅い件の調査
                    }
                    catch
                    {
                        // 既存ロジックに影響無し
                    }
                }//ADD 2021/09/10 呉元嘯 PMKOBETSU-4172 原単価チェックと税率ログの制御ファイルの対応
            }
            // --- ADD K2021/08/23 陳艶丹 PMKOBETSU-4178 税率のログ追加---<<<<
            #endregion

            #region ●ＵＯＥ自社マスタPMUOE09042A
            LogWrite("２UOE自社マスタを取得");
            UOESettingAcs uoeSettingAcs = new UOESettingAcs();
            uoeSettingAcs.Read(out this._uoeSetting, enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            #endregion

            #region ●端末管理マスタMAPOS09152A(キャッシュなし)
            LogWrite("２端末管理マスタを取得インスタンス生成　開始");
            PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
            LogWrite("２端末管理マスタを取得さーち　開始");
            posTerminalMgAcs.Search(out this._posTerminalMg, enterpriseCode);
            LogWrite("２端末管理マスタを取得終了");
            #endregion

            #region ●全従業員／従業員詳細情報を取得SFTOK09382A
            LogWrite("２全従業員／従業員詳細情報を取得");
            EmployeeAcs employeeAcs = new EmployeeAcs();
            employeeAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = employeeAcs.SearchOnlyEmployeeInfo(out aList, out aList2, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._employeeList = new List<Employee>((Employee[])aList.ToArray(typeof(Employee)));
                if (aList2 != null) this._employeeDtlList = new List<EmployeeDtl>((EmployeeDtl[])aList2.ToArray(typeof(EmployeeDtl)));
            }
            #endregion

            #region ●オプション情報
            this.CacheOptionInfo();
            #endregion

            //>>>2010/06/26
            //#region ●BLコード変換マスタ
            //LogWrite("３ BLコード変換マスタを取得");
            //BLCodeChangeAcs blCodeChangeAcs = new BLCodeChangeAcs();
            //TbsPartsCdChgWork paraTbsPartsCdChgWork = new TbsPartsCdChgWork();
            //status = blCodeChangeAcs.Search(out this._tbsPartsCdChgWorkList, paraTbsPartsCdChgWork);
            //#endregion
            //<<<2010/06/26
            // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 --->>>>>
            #region ●仕入先リスト
            LogWrite(LOGWRITESUPPLIER);
            _supplierAcs = new SupplierAcs();
            ArrayList supplierList;
            status = this._supplierAcs.SearchAll(out supplierList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (supplierList != null)
                {
                    _supplierList = new List<Supplier>((Supplier[])supplierList.ToArray(typeof(Supplier)));
                }
            }
            #endregion
            // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 ---<<<<<

            return 0;
        }

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

            // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
            #region ●山形部品オプション
            // 売仕入同時入力制御オプション(OPT-CPM0050)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockEntControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockEntCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_StockEntCtrl = (int)Option.OFF;
            }
            // 仕入日付フォーカス制御オプション(OPT-CPM0060)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockDateControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_StockDateCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_StockDateCtrl = (int)Option.OFF;
            }
            // 原価修正制御オプション(OPT-CPM0070)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SalesCostControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_SalesCostCtrl = (int)Option.ON;
            }
            else
            {
                this._opt_SalesCostCtrl = (int)Option.OFF;
            }
            #endregion
            // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
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

            // --- ADD 譚洪 K2014/01/22 ---------->>>>>
            #region ●登戸個別専門用のキーにオプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_NobutoCustom);
   
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                // ---ADD 鄧潘ハン K2014/02/17--------------->>>>>
                // インスタンス生成
                this._objNobuto = this.LoadAssemblyNobuto("PMHNB09312AC", "Broadleaf.Application.Controller.NobutoSpecSalesAcs");
                this._myMethodNobuto = null;
                if (this._objNobuto != null)
                {
                    // メソッド取得
                    this._myMethodNobuto = this._objNobuto.GetType().GetMethod("ReadSpecSalesDetailUriAge", new Type[] { typeof(string), typeof(string), typeof(int) });
                }

                if (this._myMethodNobuto != null)
                {
                    this._opt_NoBuTo = (int)Option.ON;
                }
                else
                {
                    this._opt_NoBuTo = (int)Option.OFF;
                }
                // ---ADD 鄧潘ハン K2014/02/17---------------<<<<<
                //this._opt_NoBuTo = (int)Option.ON;// DEL 鄧潘ハン K2014/02/17
            }
            else
            {
                this._opt_NoBuTo = (int)Option.OFF;
            }
            #endregion
            // --- ADD 譚洪 K2014/01/22 ----------<<<<<
            // --- ADD K2015/04/01 高騁 森川部品個別依頼 ---------->>>>>
            #region ●森川部品オプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MorikawaCustom);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_MoriKawa = (int)Option.ON;
            }
            else
            {
                this._opt_MoriKawa = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2015/04/01 高騁 森川部品個別依頼 ----------<<<<<

            // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
            #region ●㈱コーエイオプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_KoeiCallExtProgCtl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PermitForKoei = (int)Option.ON;
            }
            else
            {
                this._opt_PermitForKoei = (int)Option.OFF;
            }
            #endregion

            // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

            // --- ADD 譚洪 K2016/12/26 ㈱福田部品 --- >>>>>
            #region ●㈱福田部品オプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FukudaCustom);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FukudaCustom = (int)Option.ON;
            }
            else
            {
                this._opt_FukudaCustom = (int)Option.OFF;
            }
            #endregion
            // --- ADD 譚洪 K2016/12/26 ㈱福田部品 --- <<<<<

            // --- ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱ ---------->>>>>
            #region ●富士ジーワイ商事㈱オプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FujiGYSubaruWebUoeCtl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuJi = (int)Option.ON;
            }
            else
            {
                this._opt_FuJi = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱ ----------<<<<<

           // --- ADD K2015/06/18 紀飛 ㈱メイゴ　WebUOE発注回答取込 ---------->>>>>
            #region ●㈱メイゴオプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MeigoWebUOECtrl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_MeiGo = (int)Option.ON;
            }
            else
            {
                this._opt_MeiGo = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2015/06/18 紀飛 ㈱メイゴ　WebUOE発注回答取込 ----------<<<<<

            // --- ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応 ---------->>>>>
            // 山形部品㈱ 売上伝票入力(価格・売価変更ロック)(個別)
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_YamagataCustomControl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_YamagataCustom = (int)Option.ON;
            }
            else
            {
                this._opt_YamagataCustom = (int)Option.OFF;
            }
            // --- ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応 ----------<<<<<

            // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
            #region ●水野商工㈱オプション（個別）
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_Mizuno2ndSellPriceCtl);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_Mizuno2ndSellPriceCtl = (int)Option.ON;
            }
            else
            {
                this._opt_Mizuno2ndSellPriceCtl = (int)Option.OFF;
            }
            #endregion
            // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

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
            // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
            #region ●電子帳簿連携オプション
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_EBooks);

            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_PM_EBooks = (int)Option.ON;
            }
            else
            {
                this._opt_PM_EBooks = (int)Option.OFF;
            }
            #endregion
            // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
        }
        #endregion

        // 車両管理オプション
        public int GetOptCarMng()
        {
            return this._opt_CarMng;
        }
        // 自由検索オプション
        public int GetOptFreeSearch()
        {
            return this._opt_FreeSearch;
        }
        // ＰＣＣオプション
        public int GetOptPCC()
        {
            return this._opt_PCC;
        }
        // リサイクル連動オプション
        public int GetOpt_RCLink()
        {
            return this._opt_RCLink;
        }
        // ＵＯＥオプション
        public int GetOptUOE()
        {
            return this._opt_UOE;
        }
        // 仕入支払管理オプション
        public int GetOptStockingPayment()
        {
            return this._opt_StockingPayment;
        }

        //>>>2010/05/30
        // SCMオプション
        public int GetOptSCM()
        {
            return this._opt_SCM;
        }

        // QRオプション
        public int GetOptQRMail()
        {
            return this._opt_QRMail;
        }

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        // TSPオプション
        public int GetOptTSP()
        {
            return this._opt_TSP;
        }
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
        // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
        // 電子帳簿連携オプション
        public int GetOptEBooks()
        {
            return this._opt_PM_EBooks;
        }
        // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

        // --- ADD T.Miyamoto 2012/11/13 ---------->>>>>
        // 売上日付制御オプション
        public int GetOptDateCtrl()
        {
            return this._opt_DateCtrl;
        }
        // --- ADD T.Miyamoto 2012/11/13 ----------<<<<<

        // --- ADD 譚洪 K2014/01/22 ---------->>>>>
        // 登戸個別専門用のキーにオプション（個別）
        public int GetOptNoBuTo()
        {
            return this._opt_NoBuTo;
        }
        // --- ADD 譚洪 K2014/01/22 ----------<<<<<

        // ---ADD 鄧潘ハン K2014/02/17--------------->>>>>
        /// <summary>参照用方法コール</summary>
        public MethodInfo MyMethodNobuto
        {
            get { return this._myMethodNobuto; }
        }

        /// <summary>参照用object</summary>
        public object ObjNobuto
        {
            get { return this._objNobuto; }
        }
        // ---ADD 鄧潘ハン K2014/02/17---------------<<<<<

        // --- ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱ ---------->>>>>
        // 富士ジーワイ商事㈱オプション（個別）
        public int GetOptForFuJi()
        {
            return this._opt_FuJi;
        }
        // --- ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱ ----------<<<<<

        // --- ADD K2015/06/18 紀飛 ㈱メイゴ　WebUOE発注回答取込 ---------->>>>>
        // ㈱メイゴオプション（個別）
        public int GetOptForMeiGo()
        {
            return this._opt_MeiGo;
        }
        // --- ADD K2015/06/18 紀飛 ㈱メイゴ　WebUOE発注回答取込 ----------<<<<<

        // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
        // 水野商工㈱オプション（個別）
        public int GetOptForMizuno2ndSellPriceCtl()
        {
            return this._opt_Mizuno2ndSellPriceCtl;
        }
        // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

        // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
        // 売仕入同時入力制御オプション(OPT-CPM0050)
        public int GetOptStockEntCtrl()
        {
            return this._opt_StockEntCtrl;
        }
        // 仕入日付フォーカス制御オプション(OPT-CPM0060)
        public int GetOptStockDateCtrl()
        {
            return this._opt_StockDateCtrl;
        }
        // 原価修正制御オプション(OPT-CPM0070)
        public int GetOptSalesCostCtrl()
        {
            return this._opt_SalesCostCtrl;
        }
        // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        public int GetOptFutabaSlipPrtCtl()
        {
            return this._opt_Cpm_FutabaSlipPrtCtl;
        }
        public int GetOptFutabaWarehAlloc()
        {
            return this._opt_Cpm_FutabaWarehAlloc;
        }
        public int GetOptFutabaUOECtl()
        {
            return this._opt_Cpm_FutabaUOECtl;
        }
        public int GetOptFutabaOutSlipCtl()
        {
            return this._opt_Cpm_FutabaOutSlipCtl;
        }
        // BLP参照倉庫追加オプション
        public int GetOptBLPRefWarehouse()
        {
            return this._opt_BLPRefWarehouse;
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
        // --- ADD K2015/04/01 高騁 森川部品個別依頼 ---------->>>>>
        // 森川部品オプション（個別）
        public int GetOptMoriKawa()
        {
            return this._opt_MoriKawa;
        }
        // --- ADD K2015/04/01 高騁 森川部品個別依頼 ----------<<<<<

        // --- ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応 ---------->>>>>
        // 山形部品㈱ 売上伝票入力(価格・売価変更ロック)(個別)
        public int GetOptYamagataCustom()
        {
            return this._opt_YamagataCustom;
        }
        // --- ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応 ----------<<<<<

        // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
        // ㈱コーエイオプション（個別）
        public int GetOptPermitForKoei()
        {
            return this._opt_PermitForKoei;
        }
        // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

        // --- ADD 譚洪 K2016/12/26 ㈱福田部品 --- >>>>>
        // ㈱福田部品オプション（個別）
        public int GetOptFukudaCustom()
        {
            return this._opt_FukudaCustom;
        }
        // --- ADD 譚洪 K2016/12/26 ㈱福田部品 --- <<<<<

        // --- DEL 2010/06/26 ---------->>>>>
        ///// <summary>
        ///// BLコード変換マスタ取得処理(提供)
        ///// </summary>
        ///// <returns></returns>
        //public List<TbsPartsCdChgWork> GetTbsPartsCdChgWorkList()
        //{
        //    return this._tbsPartsCdChgWorkList;
        //}
        // --- DEL 2010/06/26 ----------<<<<<
        //<<<2010/05/30

        /// <summary>
        /// 税率取得処理
        /// </summary>
        /// <param name="addUpADate"></param>
        /// <returns></returns>
        public double GetTaxRate(DateTime addUpADate)
        {
            if (_taxRateSet == null)
            {
                this._taxRate = 0;
            }
            else
            {
                this._taxRate = 0;

                if ((addUpADate >= _taxRateSet.TaxRateStartDate) &&
                    (addUpADate <= _taxRateSet.TaxRateEndDate))
                {
                    this._taxRate = _taxRateSet.TaxRate;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate2) &&
                         (addUpADate <= _taxRateSet.TaxRateEndDate2))
                {
                    this._taxRate = _taxRateSet.TaxRate2;
                }
                else if ((addUpADate >= _taxRateSet.TaxRateStartDate3) &&
                         (addUpADate <= _taxRateSet.TaxRateEndDate3))
                {
                    this._taxRate = _taxRateSet.TaxRate3;
                }
            }
            return this._taxRate;
        }

        //税率設定マスタ
        public TaxRateSet GetTaxRateSet()
        {
            return this._taxRateSet;
        }
        public double GetTaxRate()
        {
            return this._taxRate;
        }
        //ＵＯＥ自社マスタ
        public UOESetting GetUoeSetting()
        {
            return this._uoeSetting;
        }
        //端末管理マスタ
        public PosTerminalMg GetPosTerminalMg()
        {
            return this._posTerminalMg;
        }
        //全従業員／従業員詳細情報
        public List<Employee> GetEmployeeList()
        {
            return this._employeeList;
        }
        public List<EmployeeDtl> GetEmployeeDtlList()
        {
            return this._employeeDtlList;
        }
        # endregion


        // --- ADD 鄧潘ハン K2014/02/17 -------------------->>>>>
        #region 登戸個別対応
        /// <summary>
        /// アセンブリインスタンス化
        /// </summary>
        /// <param name="asmname">アセンブリ名称</param>
        /// <param name="classname">クラス名称</param>
        /// <returns>インスタンス化されたクラス</returns>
        /// <remarks>
        /// <br>Note       : 指定されたアセンブリ及びクラス名より、クラスをインスタンス化します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : K2014/02/17</br>
        /// </remarks>
        private object LoadAssemblyNobuto(string asmname, string classname)
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
                ex.Message.ToString();
            }
            return obj;
        }
        #endregion
        // --- ADD 鄧潘ハン K2014/02/17 --------------------<<<<<

        // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 --->>>>>
        //仕入先マスタ
        public List<Supplier> GetSupplierList()
        {
            return this._supplierList;
        }
        // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 ---<<<<<

    }
}

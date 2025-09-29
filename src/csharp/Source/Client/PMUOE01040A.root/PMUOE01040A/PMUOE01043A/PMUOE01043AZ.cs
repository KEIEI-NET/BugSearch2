//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信制御初期化アクセスクラス
// プログラム概要   : ＵＯＥ送受信制御初期化を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 劉超 
// 修 正 日  2014/09/19  修正内容 : Redmine#43265 イスコ　UOE送信処理回答画面にてメーカー違いの同一品番選択ウィンドウが表示される
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading; 
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// ＵＯＥ送受信制御初期化アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : ＵＯＥ送受信制御初期化アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
    /// <br>Update Note: 2014/09/19 劉超</br>
    /// <br>管理番号   : 11070149-00</br>
    /// <br>             Redmine#43265の対応 イスコ　UOE送信処理回答画面にてメーカー違いの同一品番選択ウィンドウが表示される</br>
	/// </remarks>
	public partial class UoeSndRcvCtlInitAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
        public UoeSndRcvCtlInitAcs()
		{
            try
            {
                //企業コードを取得する
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                //ログイン拠点コード
                this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

                //ＵＯＥ送受信ＪＮＬアクセスクラス
                this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

                this._acptAnOdrTtlStAcs = new AcptAnOdrTtlStAcs();  // 受発注全体設定マスタ
                this._taxRateSetAcs = new TaxRateSetAcs();          // 税率設定マスタ
                this._allDefSetAcs = new AllDefSetAcs();            // 全体初期値設定マスタ
                this._salesTtlStAcs = new SalesTtlStAcs();          // 売上全体設定マスタ
                this._estimateDefSetAcs = new EstimateDefSetAcs();  // 見積初期値設定マスタ
                this._slipPrtSetAcs = new SlipPrtSetAcs();          // 伝票印刷設定マスタ
                this._custSlipMngAcs = new CustSlipMngAcs();        // 得意先マスタ（伝票管理）
                this._supplierAcs = new SupplierAcs();              // 仕入先マスタ
                this._userGuideAcs = new UserGuideAcs();            // ユーザーガイド

                this._acptAnOdrTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
                this._salesTtlStAcs.IsLocalDBRead = ctIsLocalDBRead;
                this._slipPrtSetAcs.IsLocalDBRead = ctIsLocalDBRead;
                this._custSlipMngAcs.IsLocalDBRead = ctIsLocalDBRead;

                ReadInitData(_enterpriseCode, _loginSectionCd);
            }
            catch (Exception)
            {
                throw;
            }
		}

        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns></returns>
        public static UoeSndRcvCtlInitAcs GetInstance()
        {
            if (_uoeSndRcvCtlInitAcs == null)
            {
                _uoeSndRcvCtlInitAcs = new UoeSndRcvCtlInitAcs();
            }
            return _uoeSndRcvCtlInitAcs;
        }
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members

		# region アクセスクラス
        /// <summary>
        /// アクセスクラス
        /// </summary>

        //アクセスクラス インスタンス
        private static UoeSndRcvCtlInitAcs _uoeSndRcvCtlInitAcs = null;

        //アクセスクラス インスタンス
        private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

        private AcptAnOdrTtlStAcs _acptAnOdrTtlStAcs = null;
        private TaxRateSetAcs _taxRateSetAcs = null;
        private AllDefSetAcs _allDefSetAcs = null;
        private SalesTtlStAcs _salesTtlStAcs = null;
        private EstimateDefSetAcs _estimateDefSetAcs = null;
        private SlipPrtSetAcs _slipPrtSetAcs = null;
        private CustSlipMngAcs _custSlipMngAcs = null;
        private SupplierAcs _supplierAcs = null;           // 仕入先 アクセスクラス
        private UserGuideAcs _userGuideAcs = null;

        # endregion

		# region 取得クラス
        /// <summary>
        /// 取得クラス
        /// </summary>
        private string _enterpriseCode = String.Empty;  //企業コード
        private string _loginSectionCd = String.Empty;  //ログイン拠点コード
        private EstimateDefSet _estimateDefSet;     // 見積初期値設定マスタ
        private TaxRateSet _taxRateSet = null;      // 税率設定マスタ
        private AllDefSet _allDefSet;               // 全体初期値設定マスタ
        private AcptAnOdrTtlSt _acptAnOdrTtlSt;     // 受発注全体管理設定マスタ
        private CompanyInf _companyInf;             // 自社情報
        private double _taxRate = 0;
        private ArrayList _acptAnOdrTtlStList;      // 受発注全体管理設定マスタリスト
        private SalesTtlSt _salesTtlSt;             // 売上全体設定マスタ
        private ArrayList _estimateDefSetList;      // 見積初期値設定マスタリスト
        private ArrayList _salesTtlStList;          // 売上全体設定マスタリスト
        
        private Dictionary<int, Supplier> _supplierDictionary = null;// 仕入先マスタ
        private Dictionary<string, UserGdBd> _userGdBdDictionary = null;// ユーザーガイド

        # endregion

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
        /// <summary>ローカルDB読み込み判定</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#else
        public static readonly bool ctIsLocalDBRead = false; // true:ローカル参照 false:サーバー参照
#endif

        /// <summary>拠点コード(全体)</summary>
        public const string ctSectionCode = "00";
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

        /// <summary>税率</summary>
        public double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }
        # endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
        # region ■初期データをＤＢより取得
        /// <summary>
        /// 初期データをＤＢより取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        public void ReadInitData(string enterpriseCode, string sectionCode)
        {
            try
            {
                ArrayList al;
                int status = 0;

                #region ●受発注管理全体設定マスタ
                //-----------------------------------------------------------
                // 受発注管理全体設定マスタ
                //-----------------------------------------------------------
                al = null;
                status = _acptAnOdrTtlStAcs.SearchAll(out al, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (al != null)
                    {
                        this.CacheAcptAnOdrTtlSt(al);
                        this.CacheAcptAnOdrTtlSt(enterpriseCode, sectionCode);
                    }
                }
                #endregion

                #region ●売上全体設定マスタ
                //-----------------------------------------------------------
                // 売上全体設定マスタ
                //-----------------------------------------------------------
                al = null;
                status = _salesTtlStAcs.SearchAll(out al, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (al != null)
                    {
                        this.CacheSalesTtlSt(al);
                        this.CacheSalesTtlSt(enterpriseCode, sectionCode);
                    }
                }
                #endregion

                #region ●見積初期値設定マスタ
                //-----------------------------------------------------------
                // 見積初期値設定マスタ
                //-----------------------------------------------------------
                al = null;
                status = _estimateDefSetAcs.Search(out al, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (al != null)
                    {
                        this.CacheEstimateDefSet(al);
                        this.CacheEstimateDefSet(enterpriseCode, sectionCode);
                    }
                }
                #endregion

                #region ●全体初期値設定マスタ
                //-----------------------------------------------------------
                // 全体初期値設定マスタ
                //-----------------------------------------------------------
                AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
                AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                if (ctIsLocalDBRead == true)
                {
                    allDefSetSearchMode = AllDefSetAcs.SearchMode.Local;
                }
                else
                {
                    allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                }
                ArrayList retAllDefSetList;
                status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ログイン担当者の所属拠点もしくは全社設定を取得
                    this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
                }
                else
                {
                    this._allDefSet = null;
                }
                #endregion

                #region ●自社情報設定マスタ
                //-----------------------------------------------------------
                // 自社情報設定マスタ
                //-----------------------------------------------------------
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.Read(out this._companyInf, enterpriseCode);
                #endregion

                #region ●税率設定マスタ
                //-----------------------------------------------------------
                // 税率設定マスタ
                //-----------------------------------------------------------
                TaxRateSet taxRateSet;
                if (ctIsLocalDBRead == true)
                {
                    status = this._taxRateSetAcs.Search(out al, enterpriseCode, TaxRateSetAcs.SearchMode.Local);
                }
                else
                {
                    status = this._taxRateSetAcs.Search(out al, enterpriseCode, TaxRateSetAcs.SearchMode.Remote);
                }
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        taxRateSet = (TaxRateSet)al[0];
                        this.CacheTaxRateSet(taxRateSet);

                        _taxRate = taxRateSet.TaxRate;

                        DateTime today = DateTime.Today;

                        if ((today > taxRateSet.TaxRateStartDate) &&
                            (today <= taxRateSet.TaxRateEndDate))
                        {
                            _taxRate = taxRateSet.TaxRate;
                        }
                        else if ((today > taxRateSet.TaxRateStartDate2) &&
                            (today <= taxRateSet.TaxRateEndDate2))
                        {
                            _taxRate = taxRateSet.TaxRate2;
                        }
                        else if ((today > taxRateSet.TaxRateStartDate3) &&
                       (today <= taxRateSet.TaxRateEndDate3))
                        {
                            _taxRate = taxRateSet.TaxRate3;
                        }
                        else
                        {
                            //TMsgDisp.Show(
                            //null,
                            //emErrorLevel.ERR_LEVEL_INFO,
                            //ctPGID,
                            //"税率設定の日付範囲内に対象日が該当しません。\n税率設定を行ってください。",
                            //status,   
                            //MessageBoxButtons.OK);
                            //break;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        break;
                }
                #endregion

                //-----------------------------------------------------------
                // 仕入先情報キャッシュ制御処理
                //-----------------------------------------------------------
                CacheSupplier();

                //-----------------------------------------------------------
                // ユーザーガイドマスタボディ部リスト取得処理
                //-----------------------------------------------------------
                CacheUserGdBdList();
            }
            finally
            {
            }
        }
        # endregion

        # region ■ユーザーガイド関連
        /// <summary>
        /// ユーザーガイドマスタボディ部キャッシュ処理
        /// </summary>
        /// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
        private int CacheUserGdBdList()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                _userGdBdDictionary = new Dictionary<string, UserGdBd>();
                ArrayList userGdBdList = null;
                status = this._userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.MergeBodyData);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //_userGdBdListStc.AddRange((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd)));

                    foreach (UserGdBd userGdBd in userGdBdList)
                    {
                        string keyUserGdB = userGdBd.UserGuideDivCd.ToString("d3") + userGdBd.GuideCode.ToString("d4");

                        if (_userGdBdDictionary.ContainsKey(keyUserGdB) != true)
                        {
                            _userGdBdDictionary.Add(keyUserGdB, userGdBd);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.ToString(),
                    "ユーザーガイド（ヘッダ）情報の取得に失敗しました。" + "\r\n" + e.Message,
                    -1,
                    MessageBoxButtons.OK);

                _userGdBdDictionary = null;
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// ユーザーガイドマスタボディ部の取得
        /// </summary>
        /// <param name="userGuideDivCd">ユーザーガイド区分</param>
        /// <param name="guideCode">ガイドコード</param>
        /// <returns>ユーザーガイドマスタボディ部</returns>
        public UserGdBd GetUserGdBdList(int userGuideDivCd, int guideCode)
        {
            UserGdBd userGdBd = null;

            try
            {
                string keyUserGdB = userGuideDivCd.ToString("d3") + guideCode.ToString("d4");

                if (_userGdBdDictionary.ContainsKey(keyUserGdB))
                {
                    userGdBd = _userGdBdDictionary[keyUserGdB];
                }
            
            }
            catch (Exception)
            {
                userGdBd = null;
            }
            return userGdBd;
        }

        /// <summary>
        /// ユーザーガイドマスタボディ部名称の取得
        /// </summary>
        /// <param name="userGuideDivCd">ユーザーガイド区分</param>
        /// <param name="guideCode">ガイドコード</param>
        /// <returns>ガイド名称</returns>
        public string GetUserGdBdString(int userGuideDivCd, int guideCode)
        {
            string userGdBdString = "";

            try
            {
                UserGdBd userGdBd = GetUserGdBdList(userGuideDivCd, guideCode);
                if (userGdBd != null)
                {
                    userGdBdString = userGdBd.GuideName.Trim();
                }
            }
            catch (Exception)
            {
                userGdBdString = "";
            }
            return userGdBdString;
        }
        # endregion

        # region ■仕入先情報キャッシュ制御処理
        /// <summary>
        /// 仕入先情報キャッシュ制御処理
        /// </summary>
        public void CacheSupplier()
        {
            try
            {
                ArrayList retList = null;

                int status = _supplierAcs.Search(out retList, _enterpriseCode);
                if (status != 0) return;

                _supplierDictionary = new Dictionary<int, Supplier>();
                foreach (Supplier supplier in retList)
                {
                    if (_supplierDictionary.ContainsKey(supplier.SupplierCd) != true)
                    {
                        _supplierDictionary.Add(supplier.SupplierCd, supplier);
                    }
                }
            }
            catch (ConstraintException)
            {
                _supplierDictionary = null;
            }
        }

        /// <summary>
        /// 仕入先クラス取得
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <returns>仕入先クラス</returns>
        public Supplier GetSupplier(int supplierCd)
        {
            Supplier supplier = null;
            try
            {
                if (_supplierDictionary.ContainsKey(supplierCd))
                {
                    supplier = _supplierDictionary[supplierCd];
                }
            }
            catch (ConstraintException)
            {
                supplier = null;
            }
            return supplier;
        }

        /// <summary>
        /// 仕入先存在チェック
        /// </summary>
        /// <param name="supplierCd">仕入先コード</param>
        /// <returns>ステータス</returns>
        public bool SupplierExists(int supplierCd)
        {
            Supplier supplier = GetSupplier(supplierCd);
            return (supplier != null);
        }
        # endregion

        # region ■受発注管理全体設定マスタキャッシュ制御処理
        /// <summary>
        /// 受発注管理全体設定マスタリストキャッシュ
        /// </summary>
        /// <param name="acptAnOdrTtlStList"></param>
        internal void CacheAcptAnOdrTtlSt(ArrayList acptAnOdrTtlStList)
        {
            this._acptAnOdrTtlStList = acptAnOdrTtlStList;
        }

        /// <summary>
        /// 受発注管理全体設定マスタキャッシュ
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        internal void CacheAcptAnOdrTtlSt(string enterpriseCode, string sectionCode)
        {
            if (_acptAnOdrTtlStList != null)
            {
                // 指定企業コード＆拠点コードで一致
                foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in _acptAnOdrTtlStList)
                {
                    if ((acptAnOdrTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                        (acptAnOdrTtlSt.SectionCode.Trim() == sectionCode.Trim()))
                    {
                        this._acptAnOdrTtlSt = acptAnOdrTtlSt;
                        return;
                    }
                }
                // 指定コードで一致しない場合、全体設定キャッシュ
                foreach (AcptAnOdrTtlSt acptAnOdrTtlSt in _acptAnOdrTtlStList)
                {
                    if ((acptAnOdrTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                        (acptAnOdrTtlSt.SectionCode.Trim() == ctSectionCode.Trim()))
                    {
                        this._acptAnOdrTtlSt = acptAnOdrTtlSt;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 受発注管理全体設定マスタオブジェクト取得処理
        /// </summary>
        /// <returns></returns>
        public AcptAnOdrTtlSt GetAcptAnOdrTtlSt()
        {
            return this._acptAnOdrTtlSt;
        }
        # endregion

        # region ■売上全体設定マスタキャッシュ制御処理
        /// <summary>
        /// 売上全体設定マスタリストキャッシュ
        /// </summary>
        /// <param name="salesTtlStList"></param>
        internal void CacheSalesTtlSt(ArrayList salesTtlStList)
        {
            this._salesTtlStList = salesTtlStList;
        }

        /// <summary>
        /// 売上全体設定マスタキャッシュ
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheSalesTtlSt(string enterpriseCode, string sectionCode)
        {
            if (_salesTtlStList != null)
            {
                // 指定企業コード＆拠点コードで一致
                foreach (SalesTtlSt salesTtlSt in _salesTtlStList)
                {
                    if ((salesTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                        (salesTtlSt.SectionCode.Trim() == sectionCode.Trim()))
                    {
                        this._salesTtlSt = salesTtlSt;
                        return;
                    }
                }
                // 指定コードで一致しない場合、全体設定キャッシュ
                foreach (SalesTtlSt salesTtlSt in _salesTtlStList)
                {
                    if ((salesTtlSt.EnterpriseCode.Trim() == enterpriseCode.Trim()) &&
                        (salesTtlSt.SectionCode.Trim() == ctSectionCode.Trim()))
                    {
                        this._salesTtlSt = salesTtlSt;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 売上全体設定マスタオブジェクト取得処理
        /// </summary>
        /// <returns></returns>
        public SalesTtlSt GetSalesTtlSt()
        {
            return this._salesTtlSt;
        }
        # endregion

        # region ■見積初期値設定マスタキャッシュ制御処理
        /// <summary>
        /// 見積初期値設定マスタリストキャッシュ
        /// </summary>
        /// <param name="estimateDefSetList"></param>
        internal void CacheEstimateDefSet(ArrayList estimateDefSetList)
        {
            this._estimateDefSetList = estimateDefSetList;
        }

        /// <summary>
        /// 見積初期値設定マスタキャッシュ
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        internal void CacheEstimateDefSet(string enterpriseCode, string sectionCode)
        {
            if (_estimateDefSetList != null)
            {
                // 指定企業コード＆拠点コードで一致
                foreach (EstimateDefSet estimateDefSet in _estimateDefSetList)
                {
                    if ((estimateDefSet.EnterpriseCode.Trim() == enterpriseCode) &&
                        (estimateDefSet.SectionCode.Trim() == sectionCode))
                    {
                        this._estimateDefSet = estimateDefSet;
                        return;
                    }
                }
                // 指定コードで一致しない場合、全体設定キャッシュ
                foreach (EstimateDefSet estimateDefSet in _estimateDefSetList)
                {
                    if ((estimateDefSet.EnterpriseCode.Trim() == enterpriseCode) &&
                        (estimateDefSet.SectionCode.Trim() == ctSectionCode))
                    {
                        this._estimateDefSet = estimateDefSet;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 見積初期値設定マス  タ取得処理
        /// </summary>
        /// <returns></returns>
        public EstimateDefSet GetEstimateDefSet()
        {
            return this._estimateDefSet;
        }
        # endregion

        # region ■全体初期値設定マスタキャッシュ制御処理
        /// <summary>
        /// 全体初期値設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="allDefSetArrayList">全体初期値設定マスタオブジェクトリスト</param>
        /// <returns>全体初期値設定マスタオブジェクト</returns>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            AllDefSet allSecAllDefSet = null;

            foreach (AllDefSet allDefSet in allDefSetArrayList)
            {
                if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
                {
                    return allDefSet;
                }
                else if (allDefSet.SectionCode.Trim() == ctSectionCode.Trim())
                {
                    allSecAllDefSet = allDefSet;
                }
            }

            return allSecAllDefSet;
        }

        /// <summary>
        /// 全体初期値設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        public AllDefSet GetAllDefSet()
        {
            return this._allDefSet;
        }
        # endregion

        # region ■税率設定マスタキャッシュ制御処理
        /// <summary>
        /// 税率設定マスタキャッシュ処理
        /// </summary>
        /// <param name="taxRateSetWork">税率設定マスタワーククラス</param>
        internal void CacheTaxRateSet(TaxRateSet taxRateSet)
        {
#if False
            try
            {
                this._taxRateSet = taxRateSet;
                _dataSet.TaxRateSet.AddTaxRateSetRow(this.RowFromUIData(taxRateSet));
            }
            catch (ConstraintException)
            {
                SalesInputInitialDataSet.TaxRateSetRow row = this._dataSet.TaxRateSet.FindByTaxRateCode(taxRateSet.TaxRateCode);
                this.SetRowFromUIData(ref row, taxRateSet);
            }
#endif
        }


        /// <summary>
        /// 税率設定マスタ取得処理
        /// </summary>
        /// <returns></returns>
        public TaxRateSet GetTaxRateSet()
        {
            return this._taxRateSet;
        }

        # endregion

        # region ■品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
        /// <summary>
        /// 品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="uOESupplier">UOE発注先オブジェクト</param>
        /// <param name="list">検索結果クラス</param>
        /// <returns>0:該当あり -1:選択なし 1:該当なし</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, UOESupplier uOESupplier, out List<GoodsUnitData> list)
        {
            List<Int32> makerCdList = GetMakerCdList(uOESupplier);
            return (SearchPartsFromGoodsNoForMstInf(goodsNo, makerCdList, out list, true));
        }
        /// <summary>
        /// 品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="uOESupplier">UOE発注先オブジェクト</param>
        /// <param name="list">検索結果クラス</param>
        /// <param name="samePartsNoWindowDiv">同一品番選択あり・なし</param>
        /// <returns>0:該当あり -1:選択なし 1:該当なし</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, UOESupplier uOESupplier, out List<GoodsUnitData> list, bool samePartsNoWindowDiv)
        {
            List<Int32> makerCdList = GetMakerCdList(uOESupplier);
            return (SearchPartsFromGoodsNoForMstInf(goodsNo, makerCdList, out list, samePartsNoWindowDiv));
        }

        /// <summary>
        /// 品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="uOESupplier">UOE発注先オブジェクト</param>
        /// <param name="list">検索結果クラス</param>
        /// <returns>0:該当あり -1:選択なし 1:該当なし</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, int uOESupplierCd, out List<GoodsUnitData> list)
        {
            UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uOESupplierCd);
            List<Int32> makerCdList = GetMakerCdList(uOESupplier);
            return (SearchPartsFromGoodsNoForMstInf(goodsNo, makerCdList, out list, true));
        }
        /// <summary>
        /// 品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="uOESupplier">UOE発注先オブジェクト</param>
        /// <param name="list">検索結果クラス</param>
        /// <param name="samePartsNoWindowDiv">同一品番選択あり・なし</param>
        /// <returns>0:該当あり -1:選択なし 1:該当なし</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, int uOESupplierCd, out List<GoodsUnitData> list, bool samePartsNoWindowDiv)
        {
            UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uOESupplierCd);
            List<Int32> makerCdList = GetMakerCdList(uOESupplier);
            return (SearchPartsFromGoodsNoForMstInf(goodsNo, makerCdList, out list, samePartsNoWindowDiv));
        }

        // ------ ADD START 2014/09/19 劉超 FOR Redmine#43265 ------>>>>>
        /// <summary>
        /// 品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="uOESupplier">UOE発注先オブジェクト</param>
        /// <param name="list">検索結果クラス</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <returns>0:該当あり -1:選択なし 1:該当なし</returns>
        public int SearchPartsFromGoodsNoForMstInf(string goodsNo, UOESupplier uOESupplier, out List<GoodsUnitData> list, int goodsMakerCd)
        {
            List<Int32> makerCdList = new List<int>();
            makerCdList.Add(goodsMakerCd);
            return (SearchPartsFromGoodsNoForMstInf(goodsNo, makerCdList, out list, true));
        }
        // ------ ADD END 2014/09/19 劉超 FOR Redmine#43265 ------<<<<<
        # endregion

        /// <summary>
        /// 品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
        /// </summary>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="list">検索結果クラス</param>
        /// <returns>0:該当あり -1:選択なし 1:該当なし</returns>
        public int SearchPartsFromGoodsNoForMstInf(int goodsMakerCd, string goodsNo, out List<GoodsUnitData> list)
        {
            string msg = "";
            int status = 0;
            list = null;

            try
            {
                GoodsCndtn cndtn = new GoodsCndtn();

                cndtn.EnterpriseCode = _enterpriseCode;
                cndtn.SectionCode = _loginSectionCd;
                cndtn.GoodsNo = goodsNo;
                cndtn.GoodsMakerCd = goodsMakerCd;

                status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, false, out list, out msg);
            }
            catch (ConstraintException)
            {
                status = -1;
            }
            return (status);
        }

        /// <summary>
        /// メーカー情報取得
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="makerUMnt">メーカー情報クラス</param>
        /// <returns>0:正常終了 0以外:エラー終了</returns>
        public int GetMakerInf(int makerCode, out MakerUMnt makerUMnt)
        {
            int status = 0;
            makerUMnt = null;   

            try
            {
                status = _goodsAcs.GetMaker(_enterpriseCode, makerCode, out makerUMnt);
            }
            catch (ConstraintException)
            {
                status = -1;
            }
            return (status);
        }

        // ------ ADD START 2014/09/19 劉超 FOR Redmine#43265 ------>>>>>
        /// <summary>
        /// 検索対象メーカーリストの取得
        /// </summary>
        /// <param name="uOESupplier">ＵＯＥ発注先クラス</param>
        /// <returns>検索対象メーカーリスト</returns>
        public List<Int32> GetMakerCdLt(UOESupplier uOESupplier)
        {
            return GetMakerCdList(uOESupplier);
        }
        // ------ ADD END 2014/09/19 劉超 FOR Redmine#43265 ------<<<<<
        # endregion

        // ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region 検索対象メーカーリストの取得
        /// <summary>
        /// 検索対象メーカーリストの取得
        /// </summary>
        /// <param name="uOESupplier">1ＵＯＥ発注先クラス</param>
        /// <returns>検索対象メーカーリスト</returns>
        private List<Int32> GetMakerCdList(UOESupplier uOESupplier)
        {
            List<Int32> makerCdList = new List<int>();

            try
            {
                makerCdList.Clear();
                int enableOdrMakerCd = 0;
                for (int i = 0; i < 6; i++)
                {
                    switch (i)
                    {
                        case 0:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd1;
                            break;
                        case 1:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd2;
                            break;
                        case 2:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd3;
                            break;
                        case 3:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd4;
                            break;
                        case 4:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd5;
                            break;
                        case 5:
                            enableOdrMakerCd = uOESupplier.EnableOdrMakerCd6;
                            break;
                    }
                    if (enableOdrMakerCd == 0) continue;
                    makerCdList.Add(enableOdrMakerCd);
                }
            }
            catch (Exception)
            {
                makerCdList = null;
            }

            return (makerCdList);
        }
        # endregion

        # region 品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
        /// <summary>
        /// 品番検索 結合検索無し(マスメン用)(ユーザー＋提供)
        /// </summary>
        /// <param name="goodsNo">品番</param>
        /// <param name="makerCdList">検索対象のメーカーコードリスト</param>
        /// <param name="list">検索結果クラス</param>
        /// <param name="samePartsNoWindowDiv">同一品番選択あり・なし</param>
        /// <returns>0:該当あり -1:選択なし 1:該当なし</returns>
        private int SearchPartsFromGoodsNoForMstInf(string goodsNo, List<Int32> makerCdList, out List<GoodsUnitData> list, bool samePartsNoWindowDiv)
        {
            string msg = "";
            int status = 0;
            list = null;

            try
            {
                GoodsCndtn cndtn = new GoodsCndtn();

                cndtn.EnterpriseCode = this._enterpriseCode;
                cndtn.SectionCode = this._loginSectionCd;
                cndtn.GoodsNo = goodsNo;

                int serchMode = 0;
                if (makerCdList != null)
                {
                    if (makerCdList.Count != 0)
                    {
                        serchMode = 1;
                    }
                }

                if (serchMode == 0)
                {
                    status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, true, out list, out msg);
                }
                else
                {
                    status = _goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, true, makerCdList, out list, out msg);
                }
            }
            catch (ConstraintException)
            {
                status = -1;
            }
            return (status);
        }
        # endregion

        # endregion
	}
}

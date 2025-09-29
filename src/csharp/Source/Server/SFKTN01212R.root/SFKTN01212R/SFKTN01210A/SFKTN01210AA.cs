using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Runtime.Serialization;
//----- ueno upd---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno upd---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 拠点情報取得部品アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 拠点情報テーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 21015  金巻　芳則</br>
    /// <br>Date       : 2004.03.22</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>UpDateNote  : 2006.06.21 kane </br>
    /// <br>            : リモートからではなく生成親から拠点系情報を渡される処理の追加</br>
    /// <br>            : 2007.01.24 noguchi 拠点コードがトリムされて扱われる場合とトリムされないで扱われる場合があったので</br>
    /// <br>              トリムしないで扱うように修正。リースの障害報告書対応です。</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>UpdateNote	: Read、ガイドのSearch の処理をローカルDBからの読込に変更</br>
    /// <br>Programmer	: 980023　飯谷 耕平</br>
    /// <br>Date		: 2007.04.04</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>UpdateNote	: ガイドのSearchの処理を、引数指定でリモート読込にできるよう変更</br>
    /// <br>Programmer	: 980023　飯谷 耕平</br>
    /// <br>Date		: 2007.05.07</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note : 自社名称マスタレイアウト変更対応</br>
    /// <br>Programmer  : 20036　斉藤　雅明</br>
    /// <br>Date        : 2007.05.16</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note : DC.NS用にローカルDB非対応に修正</br>
    /// <br>Programmer  : 21024　佐々木　健</br>
    /// <br>Date        : 2007.09.12</br>
	/// <br>-------------------------------------------------------</br>
    /// <br>Update Note : ローカルDB対応</br>
    /// <br>			: 30167 上野　弘貴</br>
    /// <br>			: 2008.01.31</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note : PM.NS対応 拠点制御設定マスタを使用しないように変更</br>
    /// <br>			: 20056 對馬 大輔</br>
    /// <br>			: 2008.05.01</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note : PM.NS対応 </br>
    /// <br>			: 20081 疋田 勇人</br>
    /// <br>			: 2008.06.05</br>
    /// <br>-------------------------------------------------------</br>
    /// <br>Update Note : オフライン対応 </br>
    /// <br>			: 22008 長内 数馬</br>
    /// <br>			: 2010/05/25</br>
    /// <br>-------------------------------------------------------</br>
    /// </remarks>
    public class SecInfoAcs
    {
        private static SecInfoSet _SecInfoSet = null;

        private static SecInfoSet[] _secInfoSetList;
        //private static SecCtrlSet[] _secCtrlSetList; // DEL 2008.05.01
        private static CompanyNm[] _companyNmList;

        private static Hashtable _secInfoSetHT = null;
        //private static Hashtable _secCtrlSetHT = null; // DEL 2008.05.01
        private static Hashtable _companyNmHT = null;

        //ログイン情報系メンバ
        private static Employee _Employee;
        private static string _EnterPriseCode;
        private static string _EnterPriseName;

		/// <summary>ローカルＤＢモード</summary>
		private static bool _isLocalDBRead;

        private const string _DefCode = "000000";

        //非同期実行用メンバ
        /// <summary>
        /// 
        /// </summary>
        protected delegate void GetDataEventHandler();
        /// <summary>
        /// 
        /// </summary>
        protected GetDataEventHandler GetData;
        //private Thread GetDataThread = null;

        /// <summary>リモートオブジェクト格納バッファ</summary>
        private ISectionInfo _iSectionInfo = null;

		//----- ueno upd ---------- start 2008.01.31
		/// <summary>ローカルDBオブジェクト格納バッファ</summary>
		private SectionInfoLcDB _sectionInfoLcDB = null;  // iitani a
		//----- ueno upd ---------- end 2008.01.31

        /// <summary>
        /// 拠点情報取得部品アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報取得部品アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>           : ログイン情報の拠点情報をプロパティに設定します。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        public SecInfoAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iSectionInfo = (ISectionInfo)MediationSectionInfo.GetSectionInfo();

				//----- ueno del ---------- start 2008.01.31
                // ローカルDBアクセスオブジェクト取得
                //this._sectionInfoLcDB = new SectionInfoLcDB();   // iitani a
				//----- ueno del ---------- end 2008.01.31
			}
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSectionInfo = null;
            }

            if ((_SecInfoSet == null) ||
                (_secInfoSetList == null) ||
                //(_secCtrlSetList == null) || // DEL 2008.05.01
                (_companyNmList == null) ||
                (_secInfoSetHT == null) ||
                //(_secCtrlSetHT == null) || // DEL 2008.05.01
                (_companyNmHT == null))
                //初期設定処理
                IniProc();

			//----- ueno upd ---------- start 2008.01.31
			// 引数なしでコンストラクタ作成時はリモートとする
			_isLocalDBRead = false; 
			//_isLocalDBRead = true;   // iitani a 2007.05.07 ローカルDBでの読み込み
			//----- ueno upd ---------- end 2008.01.31
		}

        // ----- iitani a ---------- start 5007.05.07
        /// <summary>
        /// 拠点情報取得部品アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報取得部品アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>           : ログイン情報の拠点情報をプロパティに設定します。</br>
        /// <br>Programmer : 980023  飯谷　耕平</br>
        /// <br>Date       : 2007.05.07</br>
        /// </remarks>
        public SecInfoAcs(int searchMode)
        {
            try
            {
                // リモートオブジェクト取得
                this._iSectionInfo = (ISectionInfo)MediationSectionInfo.GetSectionInfo();

				//----- ueno upd ---------- start 2008.01.31
				// ローカルDBアクセスオブジェクト取得
                this._sectionInfoLcDB = new SectionInfoLcDB();
				//----- ueno upd ---------- end 2008.01.31
			}
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iSectionInfo = null;
            }

            if ((_SecInfoSet == null) ||
                (_secInfoSetList == null) ||
                //(_secCtrlSetList == null) || // DEL 2008.05.01
                (_companyNmList == null) ||
                (_secInfoSetHT == null) ||
                //(_secCtrlSetHT == null) || // DEL 2008.05.01
                (_companyNmHT == null))
                //初期設定処理
                IniProc(searchMode);

			//----- ueno upd ---------- start 2008.01.31
			// 引数有りでコンストラクタ作成時はサーチモードで判定する
			// ローカル
			if (searchMode == (int)SearchMode.Local)
			{
				_isLocalDBRead = true;
            }
            // リモート
            else
            {
				_isLocalDBRead = false;
            }
            //_isLocalDBRead = false;  // iitani a 2007.05.07 リモートからの読込
			//----- ueno upd ---------- end 2008.01.31
        }
        // ----- iitani a ---------- end 5007.05.07

		//----- ueno add ---------- end 2008.01.31
		/// <summary> 検索モード </summary>
		public enum SearchMode
		{
			/// <summary> ローカルアクセス </summary>
			Local = 0,
			/// <summary> リモートアクセス </summary>
			Remote = 1
		}
		//----- ueno add ---------- end 2008.01.31

        /// <summary>オンラインモードの列挙型です。</summary>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }

        /// <summary>
        /// 制御機能コード定数
        /// </summary>
        public enum CtrlFuncCode
        {
            /// <summary>自拠点設定</summary>
            OwnSecSetting = 10,
            /// <summary>請求計上拠点</summary>
            DemandAddUpSecCd = 20,
            /// <summary>実績計上拠点</summary>
            ResultsAddUpSecCd = 30,
            /// <summary>請求設定拠点</summary>
            BillSettingSecCd = 40,
            /// <summary>残高表示拠点</summary>
            BalanceDispSecCd = 50,
            /// <summary>支払計上拠点</summary>
            PayAddUpSecCd = 60,
            /// <summary>支払設定拠点</summary>
            PayAddUpSetSecCd = 70,
            /// <summary>支払残高表示拠点</summary>
            PayBlcDispSecCd = 80,
            /// <summary>在庫更新拠点</summary>
            StockUpdateSecCd = 90
        }

        /// <summary>
        /// 自社名称定数
        /// </summary>
        public enum CompanyNameCd
        {
            /// <summary>自社名称１</summary>
            CompanyNameCd1 = 1,
            /// <summary>自社名称２</summary>
            CompanyNameCd2 = 2,
            /// <summary>自社名称３</summary>
            CompanyNameCd3 = 3,
            /// <summary>自社名称４</summary>
            CompanyNameCd4 = 4,
            /// <summary>自社名称５</summary>
            CompanyNameCd5 = 5,
            /// <summary>自社名称６</summary>
            CompanyNameCd6 = 6,
            /// <summary>自社名称７</summary>
            CompanyNameCd7 = 7,
            /// <summary>自社名称８</summary>
            CompanyNameCd8 = 8,
            /// <summary>自社名称９</summary>
            CompanyNameCd9 = 9,
            /// <summary>自社名称１０</summary>
            CompanyNameCd10 = 10
        }

        /// <summary>
        /// 自拠点情報
        /// </summary>
        public SecInfoSet SecInfoSet
        {
            get { return _SecInfoSet; }
        }

        /// <summary>
        /// 拠点情報設定リスト
        /// </summary>
        public SecInfoSet[] SecInfoSetList
        {
            get { return _secInfoSetList; }
        }

        // DEL 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 拠点制御設定リスト
        ///// </summary>
        //public SecCtrlSet[] SecCtrlSetList
        //{
        //    get { return _secCtrlSetList; }
        //}
        // DEL 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 自社名称リスト
        /// </summary>
        public CompanyNm[] CompanyNmList
        {
            get { return _companyNmList; }
        }


        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iSectionInfo == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }

        // ----- iitani a ---------- start 2007.05.07
        /// <summary>
        /// 初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期設定を行います。</br>
        /// <br>Programmer : 980023  飯谷　耕平</br>
        /// <br>Date       : 2007.05.07</br>
        /// </remarks>
        private int IniProc()
        {
			//----- ueno upd ---------- start 2008.01.31
			// 引数なしはリモートとする
			return IniProc((int)SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}
        // ----- iitani a ---------- end 2007.05.07

        /// <summary>
        /// 初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期設定を行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        // ----- iitani c ---------- start 2007.05.07
        //private int IniProc()
        private int IniProc(int searchMode)
        // ----- iitani c ---------- end 2007.05.07
        {
            //ログイン情報の取得
            _Employee = LoginInfoAcquisition.Employee;
            _EnterPriseCode = LoginInfoAcquisition.EnterpriseCode;
            _EnterPriseName = LoginInfoAcquisition.EnterpriseName;

            _secInfoSetHT = null;
            // _secCtrlSetHT = null; // DEL 2008.05.01
            _companyNmHT = null;

            ArrayList wkSecInfoSetList;
            //ArrayList wkSecCtrlSetList; // DEL 2008.05.01
            ArrayList wkCompanyNmList;
            //リモートから情報取得
            // UPD 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ----- iitani c ---------- start 2007.05.07
            ////int status = SearchProc(_Employee.BelongSectionCode, out wkSecInfoSetList, out wkSecCtrlSetList, out wkCompanyNmList);
            //int status = SearchProc(_Employee.BelongSectionCode, out wkSecInfoSetList, out wkSecCtrlSetList, out wkCompanyNmList, searchMode);
            //// ----- iitani c ---------- start 2007.05.07
            int status = SearchProc(_Employee.BelongSectionCode, out wkSecInfoSetList, out wkCompanyNmList, searchMode);
            // UPD 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //スタティックメンバに格納
            if (wkSecInfoSetList != null) _secInfoSetList = (SecInfoSet[])wkSecInfoSetList.ToArray(typeof(SecInfoSet));
            // if (wkSecCtrlSetList != null) _secCtrlSetList = (SecCtrlSet[])wkSecCtrlSetList.ToArray(typeof(SecCtrlSet)); // DEL 2008.05.01
            if (wkCompanyNmList != null) _companyNmList = (CompanyNm[])wkCompanyNmList.ToArray(typeof(CompanyNm));

            return status;
        }

        /// <summary>
        /// 拠点情報設定処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の拠点情報をプロパティに設定します。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        public static int SetSecInfo(ArrayList SecInfoSetWorkList, ArrayList SecCtrlSetWorkList, ArrayList CompanyNmWorkList)
        {
            return SetStaticData(SecInfoSetWorkList, SecCtrlSetWorkList, CompanyNmWorkList);
        }

        /// <summary>
        /// 拠点情報再取得処理(自拠点)
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の拠点情報をプロパティに設定します。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        public int ResetSectionInfo()
        {
            _secInfoSetHT = null;
            // _secCtrlSetHT = null; // DEL 2008.05.01
            _companyNmHT = null;
            return SetStaticData(_Employee.BelongSectionCode);
        }

        /// <summary>
        /// 拠点情報再取得処理(拠点指定)
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された拠点コードの拠点情報をプロパティに設定します。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        public int ResetSectionInfo(string sectionCode)
        {
            _secInfoSetHT = null;
            // _secCtrlSetHT = null; // DEL 2008.05.01
            _companyNmHT = null;
            return SetStaticData(sectionCode);
        }

        // DEL 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 拠点情報取得処理(指定された拠点コードから拠点情報設定クラス・拠点情報リストを返します)
        ///// </summary>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="secInfoSet">拠点情報クラス</param>
        ///// <param name="secCtrlSetList">拠点制御リスト</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定された拠点コードから拠点情報設定クラス・拠点情報リストを返します。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //public int GetSecInfo(string sectionCode, out SecInfoSet secInfoSet, out ArrayList secCtrlSetList)
        //{
        //    //int status = 0;     //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //2006.05.18 kane add

        //    secInfoSet = null;
        //    secCtrlSetList = null;

        //    //status = SetStaticData(sectionCode);
        //    //SetSecData(sectionCode, _secInfoSetHT, _secCtrlSetHT, out secInfoSet, out secCtrlSetList);        //2006.05.18 kane del
        //    status = SetSecData(sectionCode, _secInfoSetHT, _secCtrlSetHT, out secInfoSet, out secCtrlSetList); //2006.05.18 kane add

        //    return status;
        //}

        ///// <summary>
        ///// 拠点情報取得処理(自拠点の拠点情報設定クラス・拠点制御リストを返します)
        ///// </summary>
        ///// <param name="secInfoSet">拠点情報設定クラス</param>
        ///// <param name="secCtrlSetList">拠点制御リスト</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 自拠点の拠点情報設定クラス・拠点制御リストを取得します。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //public int GetSecInfo(out SecInfoSet secInfoSet, out ArrayList secCtrlSetList)
        //{
        //    //int status = 0;     //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //2006.05.18 kane add

        //    secInfoSet = null;
        //    secCtrlSetList = null;

        //    //SetSecData(_Employee.BelongSectionCode, _secInfoSetHT, _secCtrlSetHT, out secInfoSet, out secCtrlSetList);        //2006.05.18 kane del
        //    status = SetSecData(_Employee.BelongSectionCode, _secInfoSetHT, _secCtrlSetHT, out secInfoSet, out secCtrlSetList); //2006.05.18 kane add

        //    return status;
        //}

        ///// <summary>
        ///// 拠点情報取得処理(指定された拠点コード・自社名称コードから拠点情報クラス・自社名称クラスを返します)
        ///// </summary>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="companyNameCd">自社名称コード</param>
        ///// <param name="secInfoSet">拠点情報クラス</param>
        ///// <param name="companyNm">自社名称クラス</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定された拠点コード・自社名称コードから拠点情報クラス・自社名称クラスを返します。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //public int GetSecInfo(string sectionCode, CompanyNameCd companyNameCd, out SecInfoSet secInfoSet, out CompanyNm companyNm)
        //{
        //    //int status = 0;     //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //2006.05.18 kane add

        //    secInfoSet = null;
        //    companyNm = null;

        //    if ((_secInfoSetHT == null) || (_companyNmHT == null))
        //    {
        //        //SetStaticData(sectionCode);   //2006.05.18 kane del
        //        status = SetStaticData(sectionCode);
        //    }
        //    //secInfoSet = (SecInfoSet)_secInfoSetHT[sectionCode];  //2006.05.23 kane del
        //    //secInfoSet = (SecInfoSet)_secInfoSetHT[sectionCode.Trim()];    //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //    secInfoSet = (SecInfoSet)_secInfoSetHT[sectionCode];    // 2007.01.24 noguchi 修正
        //    //if (secInfoSet == null) return status;    //2006.05.18 kane del
        //    if (secInfoSet == null) return (int)ConstantManagement.DB_Status.ctDB_EOF;  //2006.05.18 kane add

        //    companyNm = GetCompanyNm(secInfoSet, companyNameCd);
        //    return status;
        //}

        ///// <summary>
        ///// 拠点情報取得処理(指定された自社名称コードから自拠点の拠点情報クラス・自社名称クラスを返します)
        ///// </summary>
        ///// <param name="companyNameCd">自社名称コード</param>
        ///// <param name="secInfoSet">拠点情報クラス</param>
        ///// <param name="companyNm">自社名称クラス</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定された自社名称コードから自拠点の拠点情報クラス・自社名称クラスを返します。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //public int GetSecInfo(CompanyNameCd companyNameCd, out SecInfoSet secInfoSet, out CompanyNm companyNm)
        //{
        //    //int status = 0;     //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //2006.05.18 kane add

        //    secInfoSet = null;
        //    companyNm = null;

        //    //Hashtableがnullの場合サーバーから再取得
        //    if ((_secInfoSetHT == null) || (_companyNmHT == null))
        //    {
        //        //SetStaticData(_Employee.BelongSectionCode);   //2006.05.18 kane del
        //        status = SetStaticData(_Employee.BelongSectionCode);
        //    }
        //    //if (_secInfoSetHT != null) secInfoSet = _secInfoSetHT[_Employee.BelongSectionCode] as SecInfoSet; //2006.05.23 kane del
        //    //if (_secInfoSetHT != null) secInfoSet = _secInfoSetHT[_Employee.BelongSectionCode.Trim()] as SecInfoSet;   //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //    if (_secInfoSetHT != null) secInfoSet = _secInfoSetHT[_Employee.BelongSectionCode] as SecInfoSet; // 2007.01.24 noguchi 修正
        //    //if (secInfoSet == null) return status;    //2006.05.18 kane del
        //    if (secInfoSet == null) return (int)ConstantManagement.DB_Status.ctDB_EOF;  //2006.05.18 kane add

        //    companyNm = GetCompanyNm(secInfoSet, companyNameCd);
        //    return status;
        //}

        ///// <summary>
        ///// 拠点情報取得処理(指定された自社名称コードから自拠点の拠点情報クラス・自社名称クラスを返します)
        ///// </summary>
        ///// <param name="companyNameCd">自社名称コード</param>
        ///// <param name="secInfoSet">拠点情報クラス</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定された自社名称コードから自拠点の拠点情報クラス・自社名称クラスを返します。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //public int GetSecInfo(CompanyNameCd companyNameCd, out SecInfoSet secInfoSet)
        //{
        //    //int status = 0;     //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //2006.05.18 kane add

        //    secInfoSet = null;

        //    //Hashtableがnullの場合サーバーから再取得
        //    if (_secInfoSetHT == null)
        //    {
        //        //SetStaticData(_Employee.BelongSectionCode);   //2006.05.18 kane del
        //        status = SetStaticData(_Employee.BelongSectionCode);     //2006.05.18 kane add
        //    }
        //    //if (_secInfoSetHT != null) secInfoSet = _secInfoSetHT[_Employee.BelongSectionCode] as SecInfoSet;     //2006.05.23 kane del
        //    //if (_secInfoSetHT != null) secInfoSet = _secInfoSetHT[_Employee.BelongSectionCode.Trim()] as SecInfoSet;       //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //    if (_secInfoSetHT != null) secInfoSet = _secInfoSetHT[_Employee.BelongSectionCode] as SecInfoSet; // 2007.01.24 noguchi 修正
        //    //if (secInfoSet == null) return status;    //2006.05.18 kane del
        //    if (secInfoSet == null) return (int)ConstantManagement.DB_Status.ctDB_EOF;  //2006.05.18 kane add

        //    return status;
        //}

        ///// <summary>
        ///// 拠点情報取得処理(指定された拠点コード・制御機能コード・自社名称コードから拠点情報クラス・自社名称クラスを返します)
        ///// </summary>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="ctrlFuncCode">制御機能コード</param>
        ///// <param name="companyNameCd">自社名称コード</param>
        ///// <param name="secInfoSet">拠点情報設定クラス</param>
        ///// <param name="companyNm">自社名称クラス</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定された拠点コード・制御機能コード・自社名称コードから拠点情報クラス・自社名称クラスを返します。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //public int GetSecInfo(string sectionCode, CtrlFuncCode ctrlFuncCode, CompanyNameCd companyNameCd, out SecInfoSet secInfoSet, out CompanyNm companyNm)
        //{
        //    //int status = 0;     //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //2006.05.18 kane add

        //    secInfoSet = null;
        //    companyNm = null;

        //    //Hashtableがnullの場合サーバーから再取得
        //    if ((_secInfoSetHT == null) || (_secCtrlSetHT == null))
        //    {
        //        //SetStaticData(sectionCode);   //2006.05.18 kane del
        //        status = SetStaticData(sectionCode);     //2006.05.18 kane add
        //    }

        //    if ((_secInfoSetHT != null) && (_secCtrlSetHT != null))
        //    {
        //        //SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[sectionCode + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;    //2006.05.23 kane del
        //        //SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[sectionCode.Trim() + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;      //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //        SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[sectionCode + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;// 2007.01.24 noguchi 修正
        //        if (wkSecCtrlSet != null)
        //        {
        //            //if (wkSecCtrlSet.CtrlFuncSectionCode == _DefCode)     //2006.05.23 kane del
        //            //if (wkSecCtrlSet.CtrlFuncSectionCode.Trim() == _DefCode.Trim())       //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //            if (wkSecCtrlSet.CtrlFuncSectionCode == _DefCode) // 2007.01.24 noguchi 修正
        //            {
        //                secInfoSet = new SecInfoSet();
        //                secInfoSet.SectionCode = _DefCode;
        //            }
        //            else
        //                //secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode] as SecInfoSet;   //2006.05.23 kane del
        //                //secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode.Trim()] as SecInfoSet;     //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //                secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode] as SecInfoSet; // 2007.01.24 noguchi 修正
        //            if (secInfoSet != null)
        //                companyNm = GetCompanyNm(secInfoSet, companyNameCd);
        //        }
        //        else status = (int)ConstantManagement.DB_Status.ctDB_EOF;   //2006.05.24 kane add
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// 拠点情報取得処理(指定された拠点コード・制御機能コードから拠点情報クラスを返します)
        ///// </summary>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="ctrlFuncCode">制御機能コード</param>
        ///// <param name="secInfoSet">拠点情報設定クラス</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定された拠点コード・制御機能コードから拠点情報クラスを返します。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //public int GetSecInfo(string sectionCode, CtrlFuncCode ctrlFuncCode, out SecInfoSet secInfoSet)
        //{
        //    //int status = 0;     //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //2006.05.18 kane add

        //    secInfoSet = null;

        //    //Hashtableがnullの場合サーバーから再取得
        //    if ((_secInfoSetHT == null) || (_secCtrlSetHT == null))
        //    {
        //        //SetStaticData(sectionCode);   //2006.05.18 kane del
        //        status = SetStaticData(sectionCode);    //2006.05.18 kane add
        //    }

        //    if ((_secInfoSetHT != null) && (_secCtrlSetHT != null))
        //    {
        //        //SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[sectionCode + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;    //2006.05.24 kane del
        //        //SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[sectionCode.Trim() + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;      //2006.05.24 kane add // 2007.01.24 noguchi 修正
        //        SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[sectionCode + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;      // 2007.01.24 noguchi 修正
        //        if (wkSecCtrlSet != null)
        //        {
        //            if (wkSecCtrlSet.CtrlFuncSectionCode == _DefCode)
        //            {
        //                secInfoSet = new SecInfoSet();
        //                secInfoSet.SectionCode = _DefCode;
        //            }
        //            else
        //                //secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode] as SecInfoSet;   //2006.05.24 kane del
        //                //secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode.Trim()] as SecInfoSet;     //2006.05.24 kane add // 2007.01.24 noguchi 修正
        //                secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode] as SecInfoSet;     // 2007.01.24 noguchi 修正
        //        }
        //        else status = (int)ConstantManagement.DB_Status.ctDB_EOF;   //2006.05.24 kane add
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// 拠点情報取得処理(制御機能コードから自拠点の拠点情報クラスを返します)
        ///// </summary>
        ///// <param name="ctrlFuncCode">制御機能コード</param>
        ///// <param name="secInfoSet">拠点情報設定クラス</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定された拠点コード・制御機能コードから拠点情報クラスを返します。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //public int GetSecInfo(CtrlFuncCode ctrlFuncCode, out SecInfoSet secInfoSet)
        //{
        //    //int status = 0;     //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //2006.05.18 kane add

        //    secInfoSet = null;

        //    //Hashtableがnullの場合サーバーから再取得
        //    if ((_secInfoSetHT == null) || (_secCtrlSetHT == null))
        //    {
        //        //SetStaticData(_Employee.BelongSectionCode);   //2006.05.18 kane del
        //        status = SetStaticData(_Employee.BelongSectionCode);     //2006.05.18 kane add
        //    }

        //    if ((_secInfoSetHT != null) && (_secCtrlSetHT != null))
        //    {
        //        //SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[_Employee.BelongSectionCode + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;    //2006.05.24 kane del
        //        //SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[_Employee.BelongSectionCode.Trim() + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;      //2006.05.24 kane add // 2007.01.24 noguchi 修正
        //        SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[_Employee.BelongSectionCode + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;      // 2007.01.24 noguchi 修正
        //        if (wkSecCtrlSet != null)
        //        {
        //            if (wkSecCtrlSet.CtrlFuncSectionCode == _DefCode)
        //            {
        //                secInfoSet = new SecInfoSet();
        //                secInfoSet.SectionCode = _DefCode;
        //            }
        //            else
        //                //secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode] as SecInfoSet;   //2006.05.24 kane del
        //                //secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode.Trim()] as SecInfoSet;     //2006.05.24 kaen add // 2007.01.24 noguchi 修正
        //                secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode] as SecInfoSet;     //2006.05.24 kaen add // 2007.01.24 noguchi 修正
        //        }
        //        else status = (int)ConstantManagement.DB_Status.ctDB_EOF;   //2006.05.24 kane add
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// 拠点情報取得処理(指定された制御機能コード・自社名称コードから自拠点の拠点情報クラス・自社名称クラスを返します)
        ///// </summary>
        ///// <param name="ctrlFuncCode">制御機能コード</param>
        ///// <param name="companyNameCd">自社名称コード</param>
        ///// <param name="secInfoSet">拠点情報設定クラス</param>
        ///// <param name="companyNm">自社名称クラス</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定された制御機能コード・自社名称コードから自拠点の拠点情報クラス・自社名称クラスを返します。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //public int GetSecInfo(CtrlFuncCode ctrlFuncCode, CompanyNameCd companyNameCd, out SecInfoSet secInfoSet, out CompanyNm companyNm)
        //{
        //    //int status = 0;     //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //2006.05.18 kane add

        //    secInfoSet = null;
        //    companyNm = null;

        //    //Hashtableがnullの場合サーバーから再取得
        //    if ((_secInfoSetHT == null) || (_secCtrlSetHT == null))
        //    {
        //        //SetStaticData(_Employee.BelongSectionCode);   //2006.05.18 kane del
        //        status = SetStaticData(_Employee.BelongSectionCode);    //2006.05.18 kane add
        //    }

        //    //SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[_Employee.BelongSectionCode + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;    //2006.05.24 kane del
        //    //SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[_Employee.BelongSectionCode.Trim() + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;      //2006.05.24 kane add // 2007.01.24 noguchi 修正
        //    SecCtrlSet wkSecCtrlSet = _secCtrlSetHT[_Employee.BelongSectionCode + "-" + ((int)ctrlFuncCode).ToString()] as SecCtrlSet;      // 2007.01.24 noguchi 修正
        //    if (wkSecCtrlSet != null)
        //    {
        //        if (wkSecCtrlSet.CtrlFuncSectionCode == _DefCode)
        //        {
        //            secInfoSet = new SecInfoSet();
        //            secInfoSet.SectionCode = _DefCode;
        //        }
        //        else
        //            //secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode] as SecInfoSet;   //2006.05.24 kane del
        //            //secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode.Trim()] as SecInfoSet;     //2006.05.24 kane add // 2007.01.24 noguchi 修正
        //            secInfoSet = _secInfoSetHT[wkSecCtrlSet.CtrlFuncSectionCode] as SecInfoSet;    // 2007.01.24 noguchi 修正
        //        if (secInfoSet != null)
        //            companyNm = GetCompanyNm(secInfoSet, companyNameCd);
        //    }
        //    else status = (int)ConstantManagement.DB_Status.ctDB_EOF;   //2006.05.24 kane add

        //    return status;
        //}
        // DEL 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 拠点情報取得処理(指定された拠点コードから拠点情報設定クラスを取得します)
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="secInfoSet">拠点情報設定クラス</param>
        /// <returns>該当あり：ConstantManagement.DB_Status.ctDB_NORMAL 該当なし：ConstantManagement.DB_Status.ctDB_EOF</returns>
        /// <remarks>指定された拠点コードから拠点情報設定クラスを取得します</remarks>
        public int GetSecInfo(string sectionCode, out SecInfoSet secInfoSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            secInfoSet = null;
            status = SetSecData(sectionCode, _secInfoSetHT, out secInfoSet);

            return status;
        }

        /// <summary>
        /// 拠点情報取得処理(自拠点の拠点情報設定クラスを取得します)
        /// </summary>
        /// <param name="secInfoSet">拠点情報設定クラス</param>
        /// <returns>該当あり：ConstantManagement.DB_Status.ctDB_NORMAL 該当なし：ConstantManagement.DB_Status.ctDB_EOF</returns>
        /// <remarks>自拠点の拠点情報設定クラスを取得します</remarks>
        public int GetSecInfo(out SecInfoSet secInfoSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            secInfoSet = null;
            status = SetSecData(_Employee.BelongSectionCode, _secInfoSetHT, out secInfoSet);

            return status;
        }

        /// <summary>
        /// 拠点情報取得処理(指定された拠点コード、自社名称コードから拠点情報設定クラス、自社名称クラスを取得します)
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="companyNameCd">自社名称コード</param>
        /// <param name="secInfoSet">拠点情報設定クラス</param>
        /// <param name="companyNm">自社名称クラス</param>
        /// <returns>該当あり：ConstantManagement.DB_Status.ctDB_NORMAL 該当なし：ConstantManagement.DB_Status.ctDB_EOF</returns>
        /// <remarks>指定された拠点コード、自社名称コードから拠点情報設定クラス、自社名称クラスを取得します</remarks>
        public int GetSecInfo(string sectionCode, CompanyNameCd companyNameCd, out SecInfoSet secInfoSet, out CompanyNm companyNm)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            secInfoSet = null;
            companyNm = null;

            if ((_secInfoSetHT == null) || (_companyNmHT == null))
            {
                status = SetStaticData(sectionCode);
            }
            secInfoSet = (SecInfoSet)_secInfoSetHT[sectionCode];
            if (secInfoSet == null) return (int)ConstantManagement.DB_Status.ctDB_EOF;

            companyNm = GetCompanyNm(secInfoSet, companyNameCd);
            return status;
        }

        /// <summary>
        /// 拠点情報取得処理(指定された自社名称コードから自拠点の拠点情報設定クラス、自社名称クラスを取得します)
        /// </summary>
        /// <param name="companyNameCd">自社名称コード</param>
        /// <param name="secInfoSet">拠点情報設定クラス</param>
        /// <param name="companyNm">自社名称クラス</param>
        /// <returns>該当あり：ConstantManagement.DB_Status.ctDB_NORMAL 該当なし：ConstantManagement.DB_Status.ctDB_EOF</returns>
        /// <remarks>指定された自社名称コードから自拠点の拠点情報設定クラス、自社名称クラスを取得します</remarks>
        public int GetSecInfo(CompanyNameCd companyNameCd, out SecInfoSet secInfoSet, out CompanyNm companyNm)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            secInfoSet = null;
            companyNm = null;

            //Hashtableがnullの場合サーバーから再取得
            if ((_secInfoSetHT == null) || (_companyNmHT == null))
            {
                status = SetStaticData(_Employee.BelongSectionCode);
            }
            if (_secInfoSetHT != null) secInfoSet = _secInfoSetHT[_Employee.BelongSectionCode] as SecInfoSet;
            if (secInfoSet == null) return (int)ConstantManagement.DB_Status.ctDB_EOF;

            companyNm = GetCompanyNm(secInfoSet, companyNameCd);
            return status;
        }

        /// <summary>
        /// 拠点情報取得処理(指定された自社名称コードから自拠点の拠点情報設定クラスを取得します)
        /// </summary>
        /// <param name="companyNameCd">自社名称コード</param>
        /// <param name="secInfoSet">拠点情報設定クラス</param>
        /// <returns>該当あり：ConstantManagement.DB_Status.ctDB_NORMAL 該当なし：ConstantManagement.DB_Status.ctDB_EOF</returns>
        /// <remarks>指定された自社名称コードから自拠点の拠点情報設定クラスを取得します</remarks>
        public int GetSecInfo(CompanyNameCd companyNameCd, out SecInfoSet secInfoSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            secInfoSet = null;

            //Hashtableがnullの場合サーバーから再取得
            if (_secInfoSetHT == null)
            {
                status = SetStaticData(_Employee.BelongSectionCode);
            }
            if (_secInfoSetHT != null) secInfoSet = _secInfoSetHT[_Employee.BelongSectionCode] as SecInfoSet;
            if (secInfoSet == null) return (int)ConstantManagement.DB_Status.ctDB_EOF;

            return status;
        }
        // ADD 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// 本社機能判定フラグ取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>STATUS　-1:エラー(拠点コード無し)、0:拠点、1:本社</returns>
        /// <remarks>
        /// <br>Note       : 指定された拠点コードの本社機能フラグを返します。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        public int GetMainOfficeFuncFlag(string sectionCode)
        {
            int status = -1;

            //SecInfoSet wkSecInfoSet = (SecInfoSet)_secInfoSetHT[sectionCode]; //2006.08.31 kane del
            //SecInfoSet wkSecInfoSet = (SecInfoSet)_secInfoSetHT[sectionCode.Trim()];   //2006.08.31 kane add // 2007.01.24 noguchi 修正
            SecInfoSet wkSecInfoSet = (SecInfoSet)_secInfoSetHT[sectionCode]; // 2007.01.24 noguchi 修正
            if (wkSecInfoSet != null)
                status = wkSecInfoSet.MainOfficeFuncFlag;

            return status;
        }

        /// <summary>
        /// オフラインデータの書き込み
        /// </summary>
        /// <param name="sender">object</param>
        /// <returns>STATUS</returns>
        public int WriteOfflineData(object sender)
        {
            //カスタムシリアライズアレイリストに設定
            CustomSerializeArrayList CSAL = new CustomSerializeArrayList();
            if (_secInfoSetList != null) CSAL.Add(CopyToSecInfoSetWorkFromSecInfoSet(_secInfoSetList));
            //if (_secCtrlSetList != null) CSAL.Add(CopyToSecCtrlSetWorkFromSecCtrlSet(_secCtrlSetList)); // DEL 2008.05.01
            if (_companyNmList != null) CSAL.Add(CopyToCompanyNmWorkFromCompanyNm(_companyNmList));

            OfflineDataSerializer _OfflineDataSerializer = new OfflineDataSerializer();
            int status = _OfflineDataSerializer.Serialize(this.ToString(), new string[] { _EnterPriseCode }, CSAL);

            return status;
        }

        /// <summary>
        /// オフラインデータの読み込み
        /// </summary>
        private int ReadOfflineData(out object retobj, string enterPriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retobj = null;
            try
            {
                OfflineDataSerializer _OfflineDataSerializer = new OfflineDataSerializer();
                retobj = _OfflineDataSerializer.DeSerialize(this.ToString(), new string[] { enterPriseCode }) as CustomSerializeArrayList;
                if (retobj != null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 自社名称取得
        /// </summary>
        /// <param name="secInfoSet"></param>
        /// <param name="companyNameCd"></param>
        /// <returns></returns>
        private CompanyNm GetCompanyNm(SecInfoSet secInfoSet, CompanyNameCd companyNameCd)
        {
            int wkCompanyNameCd = 0;
            switch (companyNameCd)
            {
                case CompanyNameCd.CompanyNameCd1:
                    wkCompanyNameCd = secInfoSet.CompanyNameCd1;
                    break;
                // 2008.06.05 del start ---------------------------->>
                //case CompanyNameCd.CompanyNameCd2:
                //    wkCompanyNameCd = secInfoSet.CompanyNameCd2;
                //    break;
                //case CompanyNameCd.CompanyNameCd3:
                //    wkCompanyNameCd = secInfoSet.CompanyNameCd3;
                //    break;
                //case CompanyNameCd.CompanyNameCd4:
                //    wkCompanyNameCd = secInfoSet.CompanyNameCd4;
                //    break;
                //case CompanyNameCd.CompanyNameCd5:
                //    wkCompanyNameCd = secInfoSet.CompanyNameCd5;
                //    break;
                //case CompanyNameCd.CompanyNameCd6:
                //    wkCompanyNameCd = secInfoSet.CompanyNameCd6;
                //    break;
                //case CompanyNameCd.CompanyNameCd7:
                //    wkCompanyNameCd = secInfoSet.CompanyNameCd7;
                //    break;
                //case CompanyNameCd.CompanyNameCd8:
                //    wkCompanyNameCd = secInfoSet.CompanyNameCd8;
                //    break;
                //case CompanyNameCd.CompanyNameCd9:
                //    wkCompanyNameCd = secInfoSet.CompanyNameCd9;
                //    break;
                //case CompanyNameCd.CompanyNameCd10:
                //    wkCompanyNameCd = secInfoSet.CompanyNameCd10;
                //    break;
                // 2008.06.05 del end -----------------------------<<
            }
            return (CompanyNm)_companyNmHT[wkCompanyNameCd.ToString()];
        }

        // UPD 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //// ----- iitani a ---------- start 2007.05.07
        ///// <summary>
        ///// 拠点情報取得処理
        ///// </summary>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 拠点情報の検索処理を行います。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //private int SearchProc(string sectionCode, out ArrayList secInfoSetList, out ArrayList secCtrlSetList, out ArrayList companyNmList)
        //{
        //    return SearchProc(sectionCode, out secInfoSetList, out secCtrlSetList, out companyNmList, 0);
        //}
        // ----- iitani a ---------- end 2007.05.07

        /// <summary>
        /// 拠点情報取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="secInfoSetList">拠点情報設定クラスリスト</param>
        /// <param name="companyNmList">自社名称クラスリスト</param>
        /// <returns></returns>
        private int SearchProc(string sectionCode, out ArrayList secInfoSetList, out ArrayList companyNmList)
        {
            return SearchProc(sectionCode, out secInfoSetList, out companyNmList, 0);
        }
        // UPD 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        #region [削除]
        // DEL 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 拠点情報取得処理
        ///// </summary>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 拠点情報の検索処理を行います。</br>
        ///// <br>Programmer : 21015  金巻　芳則</br>
        ///// <br>Date       : 2005.10.03</br>
        ///// </remarks>
        //// ----- iitani c ---------- start 2007.05.07
        ////private int SearchProc(string sectionCode, out ArrayList secInfoSetList, out ArrayList secCtrlSetList, out ArrayList companyNmList)
        //private int SearchProc(string sectionCode, out ArrayList secInfoSetList, out ArrayList secCtrlSetList, out ArrayList companyNmList, int searchMode)
        //// ----- iitani c ---------- end 2007.05.07
        //{
        //    //int status = 0;   //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;    //2006.05.18 kane add

        //    secInfoSetList = null;
        //    secCtrlSetList = null;
        //    companyNmList = null;

        //    SecInfoSetWork secInfoSetWork = new SecInfoSetWork();

        //    //キーの設定
        //    secInfoSetWork.EnterpriseCode = _EnterPriseCode;
        //    secInfoSetWork.SectionCode = sectionCode;

        //    object paraobj = secInfoSetWork;
        //    object retobj = null;

        //    int errorLevel;
        //    string errorCode;
        //    string errorMessage;

        //    ArrayList wkSecInfoSetWorkList = null;
        //    ArrayList wkSecCtrlSetWorkList = null;
        //    ArrayList wkCompanyNmWorkList = null;

        //    secInfoSetList = new ArrayList();
        //    secCtrlSetList = new ArrayList();
        //    companyNmList = new ArrayList();

        //    // 2007.09.12 sasaki >>
        //    //// iitani c start
        //    ////if (LoginInfoAcquisition.OnlineFlag)
        //    ////    status = this._iSectionInfo.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
        //    ////else
        //    ////    status = this.ReadOfflineData(out retobj, secInfoSetWork.EnterpriseCode);
        //    //// ----- iitani c ---------- start 2007.05.07
        //    ////status = this._sectionInfoLcDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
        //    //if (searchMode == 1)
        //    //{
        //    //    if (LoginInfoAcquisition.OnlineFlag)
        //    //        status = this._iSectionInfo.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
        //    //    else
        //    //        status = this.ReadOfflineData(out retobj, secInfoSetWork.EnterpriseCode);
        //    //}
        //    //else
        //    //{
        //    //    status = this._sectionInfoLcDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
        //    //}
        //    //// ----- iitani c ---------- end 2007.05.07
        //    //// iitani c end

        //    if (LoginInfoAcquisition.OnlineFlag)
        //    {
        //        //----- ueno upd ---------- start 2008.01.31
        //        // ローカル
        //        if (searchMode == (int)SearchMode.Local)
        //        {
        //            status = this._sectionInfoLcDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
        //        }
        //        // リモート
        //        else
        //        {
        //            status = this._iSectionInfo.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
        //        }
        //        //----- ueno upd ---------- end 2008.01.31
        //    }
        //    else
        //    {
        //        status = this.ReadOfflineData(out retobj, secInfoSetWork.EnterpriseCode);
        //    }
        //    // 2007.09.12 sasaki <<

        //    if (status == 0)
        //    {
        //        // ----- iitani c ---------- start 2007.05.07
        //        //CustomSerializeArrayList CSAList = retobj as CustomSerializeArrayList;
        //        //foreach (object obj in CSAList)
        //        ArrayList AList = retobj as ArrayList;
        //        foreach (object obj in AList)
        //        // ----- iitani c ---------- end 2007.05.07
        //        {
        //            ArrayList wkal = obj as ArrayList;
        //            if (wkal.Count > 0)
        //            {
        //                if (wkal[0] is SecInfoSetWork) wkSecInfoSetWorkList = wkal;
        //                else if (wkal[0] is SecCtrlSetWork) wkSecCtrlSetWorkList = wkal;
        //                else if (wkal[0] is CompanyNmWork) wkCompanyNmWorkList = wkal;
        //            }

        //        }

        //        //ワーククラスからUIクラスへ変換
        //        //拠点情報設定
        //        if (wkSecInfoSetWorkList != null)
        //            foreach (SecInfoSetWork wkSecInfoSetWork in wkSecInfoSetWorkList)
        //            {
        //                SecInfoSet wkSecInfoSet = CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork);
        //                if (_secInfoSetHT == null) _secInfoSetHT = new Hashtable();
        //                //拠点コードをキーにHashtableに格納
        //                //if (null == _secInfoSetHT[wkSecInfoSet.SectionCode])  //2006.05.23 kane del
        //                //if (null == _secInfoSetHT[wkSecInfoSet.SectionCode.Trim()])    //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //                if (null == _secInfoSetHT[wkSecInfoSet.SectionCode])    // 2007.01.24 noguchi 修正
        //                {
        //                    //_secInfoSetHT.Add(wkSecInfoSet.SectionCode, wkSecInfoSet);    //2006.05.23 kane del
        //                    //_secInfoSetHT.Add(wkSecInfoSet.SectionCode.Trim(), wkSecInfoSet);      //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //                    _secInfoSetHT.Add(wkSecInfoSet.SectionCode, wkSecInfoSet);      // 2007.01.24 noguchi 修正
        //                    secInfoSetList.Add(wkSecInfoSet);
        //                }
        //                //自拠点情報の格納
        //                //if (sectionCode.Trim() == wkSecInfoSet.SectionCode.Trim()) // 2007.01.24 noguchi 修正
        //                if (sectionCode == wkSecInfoSet.SectionCode)
        //                {
        //                    _SecInfoSet = wkSecInfoSet;
        //                }
        //            }

        //        // DEL 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //        ////拠点制御設定
        //        //if (wkSecCtrlSetWorkList != null)
        //        //    foreach (SecCtrlSetWork wkSecCtrlSetWork in wkSecCtrlSetWorkList)
        //        //    {
        //        //        SecCtrlSet wkSecCtrlSet = CopyToSecCtrlSetFromSecCtrlSetWork(wkSecCtrlSetWork);
        //        //        if (_secCtrlSetHT == null) _secCtrlSetHT = new Hashtable();
        //        //        //if (null == _secCtrlSetHT[wkSecCtrlSet.SectionCode + "-" + wkSecCtrlSet.CtrlFuncCode.ToString()]) //2006.05.23 kane del
        //        //        //if (null == _secCtrlSetHT[wkSecCtrlSet.SectionCode.Trim() + "-" + wkSecCtrlSet.CtrlFuncCode.ToString()])   //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //        //        if (null == _secCtrlSetHT[wkSecCtrlSet.SectionCode + "-" + wkSecCtrlSet.CtrlFuncCode.ToString()])  // 2007.01.24 noguchi 修正 
        //        //        {
        //        //            //拠点コード-制御機能コードをキーにHashtableに格納
        //        //            //_secCtrlSetHT.Add(wkSecCtrlSet.SectionCode + "-" + wkSecCtrlSet.CtrlFuncCode.ToString(), wkSecCtrlSet);   //2006.05.23 kane del
        //        //            //_secCtrlSetHT.Add(wkSecCtrlSet.SectionCode.Trim() + "-" + wkSecCtrlSet.CtrlFuncCode.ToString(), wkSecCtrlSet);     //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //        //            _secCtrlSetHT.Add(wkSecCtrlSet.SectionCode + "-" + wkSecCtrlSet.CtrlFuncCode.ToString(), wkSecCtrlSet); // 2007.01.24 noguchi 修正
        //        //            secCtrlSetList.Add(wkSecCtrlSet);
        //        //        }
        //        //    }
        //        // DEL 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        //        //自社名称
        //        if (wkCompanyNmWorkList != null)
        //            foreach (CompanyNmWork wkCompanyNmWork in wkCompanyNmWorkList)
        //            {
        //                CompanyNm wkCompanyNm = CopyToCompanyNmFromCompanyNmWork(wkCompanyNmWork);
        //                if (_companyNmHT == null) _companyNmHT = new Hashtable();
        //                if (null == _companyNmHT[wkCompanyNm.CompanyNameCd.ToString()])
        //                {
        //                    //自社名称コードをキーにHashtableに格納
        //                    _companyNmHT.Add(wkCompanyNm.CompanyNameCd.ToString(), wkCompanyNm);
        //                    companyNmList.Add(wkCompanyNm);
        //                }
        //            }
        //    }

        //    return status;
        //}
        // DEL 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        // ADD 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 拠点情報取得処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報の検索処理を行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        private int SearchProc(string sectionCode, out ArrayList secInfoSetList, out ArrayList companyNmList, int searchMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            secInfoSetList = null;
            companyNmList = null;

            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();

            //キーの設定
            secInfoSetWork.EnterpriseCode = _EnterPriseCode;
            secInfoSetWork.SectionCode = sectionCode;

            object paraobj = secInfoSetWork;
            object retobj = null;

            int errorLevel;
            string errorCode;
            string errorMessage;

            ArrayList wkSecInfoSetWorkList = null;
            ArrayList wkCompanyNmWorkList = null;

            secInfoSetList = new ArrayList();
            companyNmList = new ArrayList();

            // -- UPD 2010/05/25 ----------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    // ローカル
            //    if (searchMode == (int)SearchMode.Local)
            //    {
            //        status = this._sectionInfoLcDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
            //    }
            //    // リモート
            //    else
            //    {
            //        status = this._iSectionInfo.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
            //    }
            //}
            //else
            //{
            //    status = this.ReadOfflineData(out retobj, secInfoSetWork.EnterpriseCode);
            //}

            // ローカル
            if (searchMode == (int)SearchMode.Local)
            {
                status = this._sectionInfoLcDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
            }
            // リモート
            else
            {
                status = this._iSectionInfo.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
            }
            // -- UPD 2010/05/25 -----------------------<<<

            if (status == 0)
            {
                ArrayList AList = retobj as ArrayList;
                foreach (object obj in AList)
                {
                    ArrayList wkal = obj as ArrayList;
                    if (wkal.Count > 0)
                    {
                        if (wkal[0] is SecInfoSetWork) wkSecInfoSetWorkList = wkal;
                        else if (wkal[0] is CompanyNmWork) wkCompanyNmWorkList = wkal;
                    }

                }

                //ワーククラスからUIクラスへ変換
                //拠点情報設定
                if (wkSecInfoSetWorkList != null)
                    foreach (SecInfoSetWork wkSecInfoSetWork in wkSecInfoSetWorkList)
                    {
                        SecInfoSet wkSecInfoSet = CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork);
                        if (_secInfoSetHT == null) _secInfoSetHT = new Hashtable();
                        //拠点コードをキーにHashtableに格納
                        if (null == _secInfoSetHT[wkSecInfoSet.SectionCode])
                        {
                            _secInfoSetHT.Add(wkSecInfoSet.SectionCode, wkSecInfoSet);
                            secInfoSetList.Add(wkSecInfoSet);
                        }
                        //自拠点情報の格納
                        if (sectionCode == wkSecInfoSet.SectionCode)
                        {
                            _SecInfoSet = wkSecInfoSet;
                        }
                    }

                //自社名称
                if (wkCompanyNmWorkList != null)
                    foreach (CompanyNmWork wkCompanyNmWork in wkCompanyNmWorkList)
                    {
                        CompanyNm wkCompanyNm = CopyToCompanyNmFromCompanyNmWork(wkCompanyNmWork);
                        if (_companyNmHT == null) _companyNmHT = new Hashtable();
                        if (null == _companyNmHT[wkCompanyNm.CompanyNameCd.ToString()])
                        {
                            //自社名称コードをキーにHashtableに格納
                            _companyNmHT.Add(wkCompanyNm.CompanyNameCd.ToString(), wkCompanyNm);
                            companyNmList.Add(wkCompanyNm);
                        }
                    }
            }

            return status;
        }
        // ADD 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // DEL 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sectionCode"></param>
        ///// <param name="secInfoSetList"></param>
        ///// <param name="secCtrlSetList"></param>
        ///// <param name="secInfoSet"></param>
        ///// <param name="secCtrlSetArrayList"></param>
        ///// <br>UpDateNote  ; 2006.05.18 kane </br>
        ///// <br>            : データが取得できなかった場合のステータスを設定</br>
        ////private void SetSecData(string sectionCode, Hashtable secInfoSetList, Hashtable secCtrlSetList, out SecInfoSet secInfoSet, out ArrayList secCtrlSetArrayList)     //2006.05.18 kane del
        //private static int SetSecData(string sectionCode, Hashtable secInfoSetList, Hashtable secCtrlSetList, out SecInfoSet secInfoSet, out ArrayList secCtrlSetArrayList)       //2006.05.18 kane add
        //{
        //    secCtrlSetArrayList = null;     //2006.05.18 kane add
        //    //自拠点情報設定プロパティへ設定
        //    //secInfoSet = (SecInfoSet)secInfoSetList[sectionCode];     //2006.05.23 kane del
        //    //secInfoSet = (SecInfoSet)secInfoSetList[sectionCode.Trim()];       //2006.05.23 kane add // 2007.01.24 noguchi 修正
        //    secInfoSet = (SecInfoSet)secInfoSetList[sectionCode]; // 2007.01.24 noguchi 修正

        //    if (secInfoSet == null) return (int)ConstantManagement.DB_Status.ctDB_EOF;    //2006.05.18 kane add

        //    secCtrlSetArrayList = new ArrayList();
        //    //2006.05.23 kane del start >>>
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.OwnSecSetting).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.DemandAddUpSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.ResultsAddUpSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.BillSettingSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.BalanceDispSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.PayAddUpSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.PayAddUpSetSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.PayBlcDispSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.StockUpdateSecCd).ToString()]);
        //    //2006.05.23 kane del end  <<<

        //    // 2007.01.24 noguchi 修正
        //    ////2006.05.23 kane add start >>>
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode.Trim() + "-" + ((int)CtrlFuncCode.OwnSecSetting).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode.Trim() + "-" + ((int)CtrlFuncCode.DemandAddUpSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode.Trim() + "-" + ((int)CtrlFuncCode.ResultsAddUpSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode.Trim() + "-" + ((int)CtrlFuncCode.BillSettingSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode.Trim() + "-" + ((int)CtrlFuncCode.BalanceDispSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode.Trim() + "-" + ((int)CtrlFuncCode.PayAddUpSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode.Trim() + "-" + ((int)CtrlFuncCode.PayAddUpSetSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode.Trim() + "-" + ((int)CtrlFuncCode.PayBlcDispSecCd).ToString()]);
        //    //secCtrlSetArrayList.Add(secCtrlSetList[sectionCode.Trim() + "-" + ((int)CtrlFuncCode.StockUpdateSecCd).ToString()]);
        //    ////2006.05.23 kane add end  <<<

        //    // 2007.01.24 noguchi 修正
        //    secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.OwnSecSetting).ToString()]);
        //    secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.DemandAddUpSecCd).ToString()]);
        //    secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.ResultsAddUpSecCd).ToString()]);
        //    secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.BillSettingSecCd).ToString()]);
        //    secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.BalanceDispSecCd).ToString()]);
        //    secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.PayAddUpSecCd).ToString()]);
        //    secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.PayAddUpSetSecCd).ToString()]);
        //    secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.PayBlcDispSecCd).ToString()]);
        //    secCtrlSetArrayList.Add(secCtrlSetList[sectionCode + "-" + ((int)CtrlFuncCode.StockUpdateSecCd).ToString()]);

        //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;   //2006.05.18 kane add
        //}
        // DEL 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 拠点情報設定マスタ情報セット処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="secInfoSetList">拠点情報リスト</param>
        /// <param name="secInfoSet">拠点情報</param>
        /// <returns></returns>
        private static int SetSecData(string sectionCode, Hashtable secInfoSetList, out SecInfoSet secInfoSet)
        {
            //自拠点情報設定プロパティへ設定
            secInfoSet = (SecInfoSet)secInfoSetList[sectionCode];

            if (secInfoSet == null) return (int)ConstantManagement.DB_Status.ctDB_EOF;

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
        // ADD 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // UPD 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// スタティック格納処理
        ///// </summary>
        //private int SetStaticData(string sectionCode)
        //{
        //    ArrayList wkSecInfoSetList = new ArrayList();
        //    ArrayList wkSecCtrlSetList = new ArrayList();
        //    ArrayList wkCompanyNmList = new ArrayList();
        //    //int status = 0;     //2006.05.18 kane del
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //2006.05.18 kane add

        //    //if (_secInfoSetHT == null)    //2006.09.01 kane del
        //    // ----- iitani c ---------- start 2007.05.07
        //    //status = SearchProc(sectionCode, out wkSecInfoSetList, out wkSecCtrlSetList, out wkCompanyNmList);
        //    if (_isLocalDBRead)
        //    {
        //        // ローカル
        //        status = SearchProc(sectionCode, out wkSecInfoSetList, out wkSecCtrlSetList, out wkCompanyNmList, 0);
        //    }
        //    else
        //    {
        //        // リモート
        //        status = SearchProc(sectionCode, out wkSecInfoSetList, out wkSecCtrlSetList, out wkCompanyNmList, 1);
        //    }
        //    // ----- iitani c ---------- end 2007.05.07

        //    SecInfoSet wkSecInfoSet = null;
        //    //ArrayList wkSecCtrlSetList = null;
        //    //SetSecData(sectionCode, _secInfoSetHT, _secCtrlSetHT, out wkSecInfoSet, out wkSecCtrlSetList);    //2006.05.18 kane del
        //    status = SetSecData(sectionCode, _secInfoSetHT, _secCtrlSetHT, out wkSecInfoSet, out wkSecCtrlSetList);
        //    _SecInfoSet = wkSecInfoSet;
        //    //スタティックメンバに格納
        //    if (wkSecInfoSetList != null) _secInfoSetList = (SecInfoSet[])wkSecInfoSetList.ToArray(typeof(SecInfoSet));
        //    //if (wkSecCtrlSetList != null) _secCtrlSetList = (SecCtrlSet[])wkSecCtrlSetList.ToArray(typeof(SecCtrlSet)); // DEL 2008.05.01
        //    if (wkCompanyNmList != null) _companyNmList = (CompanyNm[])wkCompanyNmList.ToArray(typeof(CompanyNm));

        //    return status;
        //}
        /// <summary>
        /// スタティック格納処理
        /// </summary>
        private int SetStaticData(string sectionCode)
        {
            ArrayList wkSecInfoSetList = new ArrayList();
            ArrayList wkCompanyNmList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_isLocalDBRead)
            {
                // ローカル
                status = SearchProc(sectionCode, out wkSecInfoSetList, out wkCompanyNmList, 0);
            }
            else
            {
                // リモート
                status = SearchProc(sectionCode, out wkSecInfoSetList, out wkCompanyNmList, 1);
            }

            SecInfoSet wkSecInfoSet = null;
            status = SetSecData(sectionCode, _secInfoSetHT, out wkSecInfoSet);
            _SecInfoSet = wkSecInfoSet;
            //スタティックメンバに格納
            if (wkSecInfoSetList != null) _secInfoSetList = (SecInfoSet[])wkSecInfoSetList.ToArray(typeof(SecInfoSet));
            if (wkCompanyNmList != null) _companyNmList = (CompanyNm[])wkCompanyNmList.ToArray(typeof(CompanyNm));

            return status;
        }
        // UPD 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// スタティック格納処理
        /// </summary>
        /// <param name="wkSecInfoSetWorkList"></param>
        /// <param name="wkSecCtrlSetWorkList"></param>
        /// <param name="wkCompanyNmWorkList"></param>
        /// <returns></returns>
        private static int SetStaticData(ArrayList wkSecInfoSetWorkList, ArrayList wkSecCtrlSetWorkList, ArrayList wkCompanyNmWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (wkSecInfoSetWorkList == null ||
                wkSecCtrlSetWorkList == null ||
                wkCompanyNmWorkList == null)
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //ログイン情報の取得
            _Employee = LoginInfoAcquisition.Employee;
            _EnterPriseCode = LoginInfoAcquisition.EnterpriseCode;
            _EnterPriseName = LoginInfoAcquisition.EnterpriseName;

            _secInfoSetHT = null;
            //_secCtrlSetHT = null; // DEL 2008.05.01
            _companyNmHT = null;

            ArrayList wkSecInfoSetList = null;
            ArrayList wkSecCtrlSetList = null;
            ArrayList wkCompanyNmList = null;

            TransSecInfoData(_Employee.BelongSectionCode, wkSecInfoSetWorkList, wkSecCtrlSetWorkList, wkCompanyNmWorkList, out wkSecInfoSetList, out wkSecCtrlSetList, out wkCompanyNmList);

            //スタティックメンバに格納
            if (wkSecInfoSetList != null) _secInfoSetList = (SecInfoSet[])wkSecInfoSetList.ToArray(typeof(SecInfoSet));
            //if (wkSecCtrlSetList != null) _secCtrlSetList = (SecCtrlSet[])wkSecCtrlSetList.ToArray(typeof(SecCtrlSet)); // DEL 2008.05.01
            if (wkCompanyNmList != null) _companyNmList = (CompanyNm[])wkCompanyNmList.ToArray(typeof(CompanyNm));

            return status;
        }

        /// <summary>
        /// 拠点情報変換処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="wkSecInfoSetWorkList">拠点設定ワーク</param>
        /// <param name="wkSecCtrlSetWorkList">拠点制御ワーク</param>
        /// <param name="wkCompanyNmWorkList">自社名称ワーク</param>
        /// <param name="wkSecInfoSetList">拠点設定</param>
        /// <param name="wkSecCtrlSetList">拠点制御</param>
        /// <param name="wkCompanyNmList">自社名称</param>
        /// <remarks>
        /// <br>Note       : 拠点情報の変換処理を行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2006.06.21</br>
        /// </remarks>
        private static void TransSecInfoData(string sectionCode,ArrayList wkSecInfoSetWorkList, ArrayList wkSecCtrlSetWorkList, ArrayList wkCompanyNmWorkList, out ArrayList wkSecInfoSetList, out ArrayList wkSecCtrlSetList, out ArrayList wkCompanyNmList)
        {
            wkSecInfoSetList = new ArrayList();
            wkSecCtrlSetList = new ArrayList();
            wkCompanyNmList = new ArrayList();

            //ワーククラスからUIクラスへ変換
            //拠点情報設定
            if (wkSecInfoSetWorkList != null)
                foreach (SecInfoSetWork wkSecInfoSetWork in wkSecInfoSetWorkList)
                {
                    SecInfoSet wkSecInfoSet = CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork);
                    if (_secInfoSetHT == null) _secInfoSetHT = new Hashtable();
                    //拠点コードをキーにHashtableに格納
                    //if (null == _secInfoSetHT[wkSecInfoSet.SectionCode.Trim()]) // 2007.01.24 noguchi 修正
                    if (null == _secInfoSetHT[wkSecInfoSet.SectionCode])
                    {
                        //_secInfoSetHT.Add(wkSecInfoSet.SectionCode.Trim(), wkSecInfoSet); // 2007.01.24 noguchi 修正
                        _secInfoSetHT.Add(wkSecInfoSet.SectionCode, wkSecInfoSet);
                        wkSecInfoSetList.Add(wkSecInfoSet);
                    }
                    //自拠点情報の格納
                    //if (sectionCode.Trim() == wkSecInfoSet.SectionCode.Trim()) // 2007.01.24 noguchi 修正
                    if (sectionCode == wkSecInfoSet.SectionCode)
                    {
                        _SecInfoSet = wkSecInfoSet;
                    }
                }

            // DEL 2008.05.01 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ////拠点制御設定
            //if (wkSecCtrlSetWorkList != null)
            //    foreach (SecCtrlSetWork wkSecCtrlSetWork in wkSecCtrlSetWorkList)
            //    {
            //        SecCtrlSet wkSecCtrlSet = CopyToSecCtrlSetFromSecCtrlSetWork(wkSecCtrlSetWork);
            //        if (_secCtrlSetHT == null) _secCtrlSetHT = new Hashtable();
            //        //if (null == _secCtrlSetHT[wkSecCtrlSet.SectionCode.Trim() + "-" + wkSecCtrlSet.CtrlFuncCode.ToString()])// 2007.01.24 noguchi 修正
            //        if (null == _secCtrlSetHT[wkSecCtrlSet.SectionCode + "-" + wkSecCtrlSet.CtrlFuncCode.ToString()])
            //        {
            //            //拠点コード-制御機能コードをキーにHashtableに格納
            //            //_secCtrlSetHT.Add(wkSecCtrlSet.SectionCode.Trim() + "-" + wkSecCtrlSet.CtrlFuncCode.ToString(), wkSecCtrlSet); // 2007.01.24 noguchi 修正
            //            _secCtrlSetHT.Add(wkSecCtrlSet.SectionCode + "-" + wkSecCtrlSet.CtrlFuncCode.ToString(), wkSecCtrlSet);
            //            wkSecCtrlSetList.Add(wkSecCtrlSet);
            //        }
            //    }
            // DEL 2008.05.01 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //自社名称
            if (wkCompanyNmWorkList != null)
                foreach (CompanyNmWork wkCompanyNmWork in wkCompanyNmWorkList)
                {
                    CompanyNm wkCompanyNm = CopyToCompanyNmFromCompanyNmWork(wkCompanyNmWork);
                    if (_companyNmHT == null) _companyNmHT = new Hashtable();
                    if (null == _companyNmHT[wkCompanyNm.CompanyNameCd.ToString()])
                    {
                        //自社名称コードをキーにHashtableに格納
                        _companyNmHT.Add(wkCompanyNm.CompanyNameCd.ToString(), wkCompanyNm);
                        wkCompanyNmList.Add(wkCompanyNm);
                    }
                }
        }

        #region ■ クラスコピー処理 ■
        /// <summary>
        /// クラスメンバーコピー処理（拠点情報設定ワーククラス⇒拠点情報設定クラス）
        /// </summary>
        /// <param name="_SecInfoSetWork">拠点情報設定ワーククラス</param>
        /// <returns>拠点情報設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報設定ワーククラスから拠点情報設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        private static SecInfoSet CopyToSecInfoSetFromSecInfoSetWork(SecInfoSetWork _SecInfoSetWork)
        {
            SecInfoSet wkSecInfoSet = new SecInfoSet();

            #region SecInfoSetWork → SecInfoSet
            wkSecInfoSet.CreateDateTime = _SecInfoSetWork.CreateDateTime;
            wkSecInfoSet.UpdateDateTime = _SecInfoSetWork.UpdateDateTime;
            wkSecInfoSet.EnterpriseCode = _SecInfoSetWork.EnterpriseCode;
            wkSecInfoSet.FileHeaderGuid = _SecInfoSetWork.FileHeaderGuid;
            wkSecInfoSet.UpdEmployeeCode = _SecInfoSetWork.UpdEmployeeCode;
            wkSecInfoSet.UpdAssemblyId1 = _SecInfoSetWork.UpdAssemblyId1;
            wkSecInfoSet.UpdAssemblyId2 = _SecInfoSetWork.UpdAssemblyId2;
            wkSecInfoSet.LogicalDeleteCode = _SecInfoSetWork.LogicalDeleteCode;
            wkSecInfoSet.SectionCode = _SecInfoSetWork.SectionCode;
            //wkSecInfoSet.OthrSlipCompanyNmCd = _SecInfoSetWork.OthrSlipCompanyNmCd; // 2008.06.05 del
            wkSecInfoSet.SectionGuideNm = _SecInfoSetWork.SectionGuideNm;
            wkSecInfoSet.SectionGuideSnm = _SecInfoSetWork.SectionGuideSnm;           // 2008.06.05 add
            wkSecInfoSet.CompanyNameCd1 = _SecInfoSetWork.CompanyNameCd1;
            wkSecInfoSet.MainOfficeFuncFlag = _SecInfoSetWork.MainOfficeFuncFlag;
            //wkSecInfoSet.SecCdForNumbering = _SecInfoSetWork.SecCdForNumbering;     // 2008.06.05 del
            wkSecInfoSet.IntroductionDate = _SecInfoSetWork.IntroductionDate;         // 2008.06.05 add
            // 2008.06.05 del start ------------------------------------------>>
            //wkSecInfoSet.CompanyNameCd2 = _SecInfoSetWork.CompanyNameCd2;
            //wkSecInfoSet.CompanyNameCd3 = _SecInfoSetWork.CompanyNameCd3;
            //wkSecInfoSet.CompanyNameCd4 = _SecInfoSetWork.CompanyNameCd4;
            //wkSecInfoSet.CompanyNameCd5 = _SecInfoSetWork.CompanyNameCd5;
            //wkSecInfoSet.CompanyNameCd6 = _SecInfoSetWork.CompanyNameCd6;
            //wkSecInfoSet.CompanyNameCd7 = _SecInfoSetWork.CompanyNameCd7;
            //wkSecInfoSet.CompanyNameCd8 = _SecInfoSetWork.CompanyNameCd8;
            //wkSecInfoSet.CompanyNameCd9 = _SecInfoSetWork.CompanyNameCd9;
            //wkSecInfoSet.CompanyNameCd10 = _SecInfoSetWork.CompanyNameCd10;
			// 2008.06.05 del end --------------------------------------------<<
            // sasaki >>
			wkSecInfoSet.SectWarehouseCd1 = _SecInfoSetWork.SectWarehouseCd1;
			wkSecInfoSet.SectWarehouseCd2 = _SecInfoSetWork.SectWarehouseCd2;
			wkSecInfoSet.SectWarehouseCd3 = _SecInfoSetWork.SectWarehouseCd3;
            // 2008.06.05 del start ------------------------------------------>>
            //wkSecInfoSet.SectWarehouseNm1 = _SecInfoSetWork.SectWarehouseNm1;
            //wkSecInfoSet.SectWarehouseNm2 = _SecInfoSetWork.SectWarehouseNm2;
            //wkSecInfoSet.SectWarehouseNm3 = _SecInfoSetWork.SectWarehouseNm3;
            // 2008.06.05 del end --------------------------------------------<<
			// sasaki <<
            #endregion

            //			//自拠点情報の格納
            //			if(_Employee.BelongSectionCode == wkSecInfoSet.SectionCode)
            //			{
            ////				if(_secInfoSetHT == null)_secInfoSetHT = new Hashtable();
            ////
            ////				_secInfoSetHT.Add(wkSecInfoSet.SectionCode,wkSecInfoSet);
            //				_SecInfoSet = wkSecInfoSet;
            //			}

            return wkSecInfoSet;
        }

        /// <summary>
        /// クラスメンバーコピー処理（拠点情報設定クラス⇒拠点情報設定ワーククラス）
        /// </summary>
        /// <param name="_SecInfoSet">拠点情報設定クラス</param>
        /// <returns>拠点情報設定ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報設定クラスから拠点情報設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        private static SecInfoSetWork CopyToSecInfoSetWorkFromSecInfoSet(SecInfoSet _SecInfoSet)
        {
            SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();

            #region SecInfoSet → SecInfoSetWork
            wkSecInfoSetWork.CreateDateTime = _SecInfoSet.CreateDateTime;
            wkSecInfoSetWork.UpdateDateTime = _SecInfoSet.UpdateDateTime;
            wkSecInfoSetWork.EnterpriseCode = _SecInfoSet.EnterpriseCode;
            wkSecInfoSetWork.FileHeaderGuid = _SecInfoSet.FileHeaderGuid;
            wkSecInfoSetWork.UpdEmployeeCode = _SecInfoSet.UpdEmployeeCode;
            wkSecInfoSetWork.UpdAssemblyId1 = _SecInfoSet.UpdAssemblyId1;
            wkSecInfoSetWork.UpdAssemblyId2 = _SecInfoSet.UpdAssemblyId2;
            wkSecInfoSetWork.LogicalDeleteCode = _SecInfoSet.LogicalDeleteCode;
            //wkSecInfoSetWork.SectionCode = _SecInfoSet.SectionCode.Trim();// 2007.01.24 noguchi 修正
            wkSecInfoSetWork.SectionCode = _SecInfoSet.SectionCode;
            //wkSecInfoSetWork.OthrSlipCompanyNmCd = _SecInfoSet.OthrSlipCompanyNmCd;  // 2008.06.05 del
            wkSecInfoSetWork.SectionGuideNm = _SecInfoSet.SectionGuideNm;
            wkSecInfoSetWork.SectionGuideSnm = _SecInfoSet.SectionGuideSnm;            // 2008.06.05 add 
            wkSecInfoSetWork.CompanyNameCd1 = _SecInfoSet.CompanyNameCd1;
            wkSecInfoSetWork.MainOfficeFuncFlag = _SecInfoSet.MainOfficeFuncFlag;
            wkSecInfoSetWork.IntroductionDate = _SecInfoSet.IntroductionDate;          // 2008.06.05 add 
            //wkSecInfoSetWork.SecCdForNumbering = _SecInfoSet.SecCdForNumbering;      // 2008.06.05 del
            // 2008.06.05 del start ------------------------------------------>>
            //wkSecInfoSetWork.CompanyNameCd2 = _SecInfoSet.CompanyNameCd2;
            //wkSecInfoSetWork.CompanyNameCd3 = _SecInfoSet.CompanyNameCd3;
            //wkSecInfoSetWork.CompanyNameCd4 = _SecInfoSet.CompanyNameCd4;
            //wkSecInfoSetWork.CompanyNameCd5 = _SecInfoSet.CompanyNameCd5;
            //wkSecInfoSetWork.CompanyNameCd6 = _SecInfoSet.CompanyNameCd6;
            //wkSecInfoSetWork.CompanyNameCd7 = _SecInfoSet.CompanyNameCd7;
            //wkSecInfoSetWork.CompanyNameCd8 = _SecInfoSet.CompanyNameCd8;
            //wkSecInfoSetWork.CompanyNameCd9 = _SecInfoSet.CompanyNameCd9;
            //wkSecInfoSetWork.CompanyNameCd10 = _SecInfoSet.CompanyNameCd10;
            // 2008.06.05 del end --------------------------------------------<<
			// sasaki >>
			wkSecInfoSetWork.SectWarehouseCd1 = _SecInfoSet.SectWarehouseCd1;
			wkSecInfoSetWork.SectWarehouseCd2 = _SecInfoSet.SectWarehouseCd2;
			wkSecInfoSetWork.SectWarehouseCd3 = _SecInfoSet.SectWarehouseCd3;
            // 2008.06.05 del start ------------------------------------------>>
            //wkSecInfoSetWork.SectWarehouseNm1 = _SecInfoSet.SectWarehouseNm1;
            //wkSecInfoSetWork.SectWarehouseNm2 = _SecInfoSet.SectWarehouseNm2;
            //wkSecInfoSetWork.SectWarehouseNm3 = _SecInfoSet.SectWarehouseNm3;
            // 2008.06.05 del end --------------------------------------------<<
			// sasaki <<
            #endregion

            return wkSecInfoSetWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（拠点情報設定クラス⇒拠点情報設定ワーククラス）
        /// </summary>
        /// <param name="_SecInfoSetArray">拠点情報設定クラス</param>
        /// <returns>拠点情報設定ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点情報設定クラスから拠点情報設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        private static ArrayList CopyToSecInfoSetWorkFromSecInfoSet(SecInfoSet[] _SecInfoSetArray)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < _SecInfoSetArray.Length; i++)
            {
                SecInfoSet _SecInfoSet = _SecInfoSetArray[i] as SecInfoSet;
                SecInfoSetWork wkSecInfoSetWork = new SecInfoSetWork();

                #region SecInfoSet → SecInfoSetWork
                wkSecInfoSetWork.CreateDateTime = _SecInfoSet.CreateDateTime;
                wkSecInfoSetWork.UpdateDateTime = _SecInfoSet.UpdateDateTime;
                wkSecInfoSetWork.EnterpriseCode = _SecInfoSet.EnterpriseCode;
                wkSecInfoSetWork.FileHeaderGuid = _SecInfoSet.FileHeaderGuid;
                wkSecInfoSetWork.UpdEmployeeCode = _SecInfoSet.UpdEmployeeCode;
                wkSecInfoSetWork.UpdAssemblyId1 = _SecInfoSet.UpdAssemblyId1;
                wkSecInfoSetWork.UpdAssemblyId2 = _SecInfoSet.UpdAssemblyId2;
                wkSecInfoSetWork.LogicalDeleteCode = _SecInfoSet.LogicalDeleteCode;
                //wkSecInfoSetWork.SectionCode = _SecInfoSet.SectionCode.Trim();// 2007.01.24 noguchi 修正
                wkSecInfoSetWork.SectionCode = _SecInfoSet.SectionCode;
                //wkSecInfoSetWork.OthrSlipCompanyNmCd = _SecInfoSet.OthrSlipCompanyNmCd; // 2008.06.05 del
                wkSecInfoSetWork.SectionGuideNm = _SecInfoSet.SectionGuideNm;
                wkSecInfoSetWork.SectionGuideSnm = _SecInfoSet.SectionGuideSnm;           // 2008.06.05 add
                wkSecInfoSetWork.CompanyNameCd1 = _SecInfoSet.CompanyNameCd1;
                wkSecInfoSetWork.MainOfficeFuncFlag = _SecInfoSet.MainOfficeFuncFlag;
                wkSecInfoSetWork.IntroductionDate = _SecInfoSet.IntroductionDate;         // 2008.06.05 add
                //wkSecInfoSetWork.SecCdForNumbering = _SecInfoSet.SecCdForNumbering;     // 2008.06.05 del
                // 2008.06.05 del start ------------------------------------------>>
                //wkSecInfoSetWork.CompanyNameCd2 = _SecInfoSet.CompanyNameCd2;
                //wkSecInfoSetWork.CompanyNameCd3 = _SecInfoSet.CompanyNameCd3;
                //wkSecInfoSetWork.CompanyNameCd4 = _SecInfoSet.CompanyNameCd4;
                //wkSecInfoSetWork.CompanyNameCd5 = _SecInfoSet.CompanyNameCd5;
                //wkSecInfoSetWork.CompanyNameCd6 = _SecInfoSet.CompanyNameCd6;
                //wkSecInfoSetWork.CompanyNameCd7 = _SecInfoSet.CompanyNameCd7;
                //wkSecInfoSetWork.CompanyNameCd8 = _SecInfoSet.CompanyNameCd8;
                //wkSecInfoSetWork.CompanyNameCd9 = _SecInfoSet.CompanyNameCd9;
                //wkSecInfoSetWork.CompanyNameCd10 = _SecInfoSet.CompanyNameCd10;
                // 2008.06.05 del end --------------------------------------------<<
				// sasaki >>
				wkSecInfoSetWork.SectWarehouseCd1 = _SecInfoSet.SectWarehouseCd1;
				wkSecInfoSetWork.SectWarehouseCd2 = _SecInfoSet.SectWarehouseCd2;
				wkSecInfoSetWork.SectWarehouseCd3 = _SecInfoSet.SectWarehouseCd3;
                // 2008.06.05 del start ------------------------------------------>>
                //wkSecInfoSetWork.SectWarehouseNm1 = _SecInfoSet.SectWarehouseNm1;
                //wkSecInfoSetWork.SectWarehouseNm2 = _SecInfoSet.SectWarehouseNm2;
                //wkSecInfoSetWork.SectWarehouseNm3 = _SecInfoSet.SectWarehouseNm3;
                // 2008.06.05 del end --------------------------------------------<<
				// sasaki <<
				#endregion
                al.Add(wkSecInfoSetWork);
            }
            return al;
        }

        /// <summary>
        /// クラスメンバーコピー処理（拠点制御設定ワーククラス⇒拠点制御定クラス）
        /// </summary>
        /// <param name="_SecCtrlSetWork">拠点制御設定ワーククラス</param>
        /// <returns>拠点制御設定クラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点制御設定ワーククラスから拠点制御設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        private static SecCtrlSet CopyToSecCtrlSetFromSecCtrlSetWork(SecCtrlSetWork _SecCtrlSetWork)
        {
            SecCtrlSet wkSecCtrlSet = new SecCtrlSet();

            #region SecCtrlSetWork → SecCtrlSet
            wkSecCtrlSet.CreateDateTime = _SecCtrlSetWork.CreateDateTime;
            wkSecCtrlSet.UpdateDateTime = _SecCtrlSetWork.UpdateDateTime;
            wkSecCtrlSet.EnterpriseCode = _SecCtrlSetWork.EnterpriseCode;
            wkSecCtrlSet.FileHeaderGuid = _SecCtrlSetWork.FileHeaderGuid;
            wkSecCtrlSet.UpdEmployeeCode = _SecCtrlSetWork.UpdEmployeeCode;
            wkSecCtrlSet.UpdAssemblyId1 = _SecCtrlSetWork.UpdAssemblyId1;
            wkSecCtrlSet.UpdAssemblyId2 = _SecCtrlSetWork.UpdAssemblyId2;
            wkSecCtrlSet.LogicalDeleteCode = _SecCtrlSetWork.LogicalDeleteCode;
            //wkSecCtrlSet.SectionCode = _SecCtrlSetWork.SectionCode.Trim();// 2007.01.24 noguchi 修正
            wkSecCtrlSet.SectionCode = _SecCtrlSetWork.SectionCode;
            wkSecCtrlSet.CtrlFuncCode = _SecCtrlSetWork.CtrlFuncCode;
            wkSecCtrlSet.CtrlFuncSectionCode = _SecCtrlSetWork.CtrlFuncSectionCode;
            wkSecCtrlSet.CtrlFuncName = _SecCtrlSetWork.CtrlFuncName;
            #endregion

            //			//自拠点情報の格納
            //			if((_Employee.BelongSectionCode == wkSecCtrlSet.SectionCode) && (_secInfoSetHT != null))
            //			{
            //				if(_secCtrlSetHT == null)_secCtrlSetHT = new Hashtable();
            //				_secCtrlSetHT.Add(wkSecCtrlSet.CtrlFuncCode.ToString(),_secInfoSetHT[wkSecCtrlSet.CtrlFuncCode.ToString()]);
            //			}

            return wkSecCtrlSet;
        }

        /// <summary>
        /// クラスメンバーコピー処理（拠点制御設定クラス⇒拠点制御設定ワーククラス）
        /// </summary>
        /// <param name="_SecCtrlSet">拠点制御設定クラス</param>
        /// <returns>拠点制御設定ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点制御設定クラスから拠点制御設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        private static SecCtrlSetWork CopyToSecCtrlSetWorkFromSecCtrlSet(SecCtrlSet _SecCtrlSet)
        {
            SecCtrlSetWork wkSecCtrlSetWork = new SecCtrlSetWork();

            #region SecCtrlSet → SecCtrlSetWork
            wkSecCtrlSetWork.CreateDateTime = _SecCtrlSet.CreateDateTime;
            wkSecCtrlSetWork.UpdateDateTime = _SecCtrlSet.UpdateDateTime;
            wkSecCtrlSetWork.EnterpriseCode = _SecCtrlSet.EnterpriseCode;
            wkSecCtrlSetWork.FileHeaderGuid = _SecCtrlSet.FileHeaderGuid;
            wkSecCtrlSetWork.UpdEmployeeCode = _SecCtrlSet.UpdEmployeeCode;
            wkSecCtrlSetWork.UpdAssemblyId1 = _SecCtrlSet.UpdAssemblyId1;
            wkSecCtrlSetWork.UpdAssemblyId2 = _SecCtrlSet.UpdAssemblyId2;
            wkSecCtrlSetWork.LogicalDeleteCode = _SecCtrlSet.LogicalDeleteCode;
            //wkSecCtrlSetWork.SectionCode = _SecCtrlSet.SectionCode.Trim();// 2007.01.24 noguchi 修正
            wkSecCtrlSetWork.SectionCode = _SecCtrlSet.SectionCode;
            wkSecCtrlSetWork.CtrlFuncCode = _SecCtrlSet.CtrlFuncCode;
            wkSecCtrlSetWork.CtrlFuncSectionCode = _SecCtrlSet.CtrlFuncSectionCode;
            wkSecCtrlSetWork.CtrlFuncName = _SecCtrlSet.CtrlFuncName;
            #endregion

            return wkSecCtrlSetWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（拠点制御設定クラス⇒拠点制御設定ワーククラス）
        /// </summary>
        /// <param name="_SecCtrlSetArray">拠点制御設定クラス</param>
        /// <returns>拠点制御設定ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 拠点制御設定クラスから拠点制御設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        private static ArrayList CopyToSecCtrlSetWorkFromSecCtrlSet(SecCtrlSet[] _SecCtrlSetArray)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < _SecCtrlSetArray.Length; i++)
            {
                SecCtrlSet _SecCtrlSet = _SecCtrlSetArray[i] as SecCtrlSet;
                SecCtrlSetWork wkSecCtrlSetWork = new SecCtrlSetWork();

                #region SecCtrlSet → SecCtrlSetWork
                wkSecCtrlSetWork.CreateDateTime = _SecCtrlSet.CreateDateTime;
                wkSecCtrlSetWork.UpdateDateTime = _SecCtrlSet.UpdateDateTime;
                wkSecCtrlSetWork.EnterpriseCode = _SecCtrlSet.EnterpriseCode;
                wkSecCtrlSetWork.FileHeaderGuid = _SecCtrlSet.FileHeaderGuid;
                wkSecCtrlSetWork.UpdEmployeeCode = _SecCtrlSet.UpdEmployeeCode;
                wkSecCtrlSetWork.UpdAssemblyId1 = _SecCtrlSet.UpdAssemblyId1;
                wkSecCtrlSetWork.UpdAssemblyId2 = _SecCtrlSet.UpdAssemblyId2;
                wkSecCtrlSetWork.LogicalDeleteCode = _SecCtrlSet.LogicalDeleteCode;
                wkSecCtrlSetWork.SectionCode = _SecCtrlSet.SectionCode;
                wkSecCtrlSetWork.CtrlFuncCode = _SecCtrlSet.CtrlFuncCode;
                wkSecCtrlSetWork.CtrlFuncSectionCode = _SecCtrlSet.CtrlFuncSectionCode;
                wkSecCtrlSetWork.CtrlFuncName = _SecCtrlSet.CtrlFuncName;
                #endregion
                al.Add(wkSecCtrlSetWork);
            }
            return al;
        }

        /// <summary>
        /// クラスメンバーコピー処理（自社名称ワーククラス⇒自社名称クラス）
        /// </summary>
        /// <param name="_CompanyNmWork">自社名称ワーククラス</param>
        /// <returns>自社名称クラス</returns>
        /// <remarks>
        /// <br>Note       : 自社名称ワーククラスから自社名称クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        private static CompanyNm CopyToCompanyNmFromCompanyNmWork(CompanyNmWork _CompanyNmWork)
        {
            CompanyNm wkCompanyNm = new CompanyNm();

            #region CompanyNmWork → CompanyNm
            wkCompanyNm.CreateDateTime = _CompanyNmWork.CreateDateTime;
            wkCompanyNm.UpdateDateTime = _CompanyNmWork.UpdateDateTime;
            wkCompanyNm.EnterpriseCode = _CompanyNmWork.EnterpriseCode;
            wkCompanyNm.FileHeaderGuid = _CompanyNmWork.FileHeaderGuid;
            wkCompanyNm.UpdEmployeeCode = _CompanyNmWork.UpdEmployeeCode;
            wkCompanyNm.UpdAssemblyId1 = _CompanyNmWork.UpdAssemblyId1;
            wkCompanyNm.UpdAssemblyId2 = _CompanyNmWork.UpdAssemblyId2;
            wkCompanyNm.LogicalDeleteCode = _CompanyNmWork.LogicalDeleteCode;
            wkCompanyNm.CompanyNameCd = _CompanyNmWork.CompanyNameCd;
            wkCompanyNm.CompanyPr = _CompanyNmWork.CompanyPr;
            wkCompanyNm.CompanyName1 = _CompanyNmWork.CompanyName1;
            wkCompanyNm.CompanyName2 = _CompanyNmWork.CompanyName2;
            wkCompanyNm.PostNo = _CompanyNmWork.PostNo;
            wkCompanyNm.Address1 = _CompanyNmWork.Address1;
            //wkCompanyNm.Address2 = _CompanyNmWork.Address2; // 2008.06.05 del
            wkCompanyNm.Address3 = _CompanyNmWork.Address3;
            wkCompanyNm.Address4 = _CompanyNmWork.Address4;
            wkCompanyNm.CompanyTelNo1 = _CompanyNmWork.CompanyTelNo1;
            wkCompanyNm.CompanyTelNo2 = _CompanyNmWork.CompanyTelNo2;
            wkCompanyNm.CompanyTelNo3 = _CompanyNmWork.CompanyTelNo3;
            wkCompanyNm.CompanyTelTitle1 = _CompanyNmWork.CompanyTelTitle1;
            wkCompanyNm.CompanyTelTitle2 = _CompanyNmWork.CompanyTelTitle2;
            wkCompanyNm.CompanyTelTitle3 = _CompanyNmWork.CompanyTelTitle3;
            wkCompanyNm.TransferGuidance = _CompanyNmWork.TransferGuidance;
            wkCompanyNm.AccountNoInfo1 = _CompanyNmWork.AccountNoInfo1;
            wkCompanyNm.AccountNoInfo2 = _CompanyNmWork.AccountNoInfo2;
            wkCompanyNm.AccountNoInfo3 = _CompanyNmWork.AccountNoInfo3;
            wkCompanyNm.CompanySetNote1 = _CompanyNmWork.CompanySetNote1;
            wkCompanyNm.CompanySetNote2 = _CompanyNmWork.CompanySetNote2;
            //wkCompanyNm.TakeInImageGroupCd = _CompanyNmWork.TakeInImageGroupCd;// del 2007.05.16 Saitoh
            wkCompanyNm.ImageInfoDiv = _CompanyNmWork.ImageInfoDiv;// add 2007.05.16 Saitoh
            wkCompanyNm.ImageInfoCode = _CompanyNmWork.ImageInfoCode;// add 2007.05.16 Saitoh
            wkCompanyNm.CompanyUrl = _CompanyNmWork.CompanyUrl;
            wkCompanyNm.CompanyPrSentence2 = _CompanyNmWork.CompanyPrSentence2;
            wkCompanyNm.ImageCommentForPrt1 = _CompanyNmWork.ImageCommentForPrt1;
            wkCompanyNm.ImageCommentForPrt2 = _CompanyNmWork.ImageCommentForPrt2;
            #endregion

            return wkCompanyNm;
        }

        /// <summary>
        /// クラスメンバーコピー処理（自社名称クラス⇒自社名称ワーククラス）
        /// </summary>
        /// <param name="_CompanyNm">自社名称クラス</param>
        /// <returns>自社名称ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 自社名称クラスから自社名称ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        private static CompanyNmWork CopyToCompanyNmWorkFromCompanyNm(CompanyNm _CompanyNm)
        {
            CompanyNmWork wkCompanyNmWork = new CompanyNmWork();

            #region CompanyNm → CompanyNmWork
            wkCompanyNmWork.CreateDateTime = _CompanyNm.CreateDateTime;
            wkCompanyNmWork.UpdateDateTime = _CompanyNm.UpdateDateTime;
            wkCompanyNmWork.EnterpriseCode = _CompanyNm.EnterpriseCode;
            wkCompanyNmWork.FileHeaderGuid = _CompanyNm.FileHeaderGuid;
            wkCompanyNmWork.UpdEmployeeCode = _CompanyNm.UpdEmployeeCode;
            wkCompanyNmWork.UpdAssemblyId1 = _CompanyNm.UpdAssemblyId1;
            wkCompanyNmWork.UpdAssemblyId2 = _CompanyNm.UpdAssemblyId2;
            wkCompanyNmWork.LogicalDeleteCode = _CompanyNm.LogicalDeleteCode;
            wkCompanyNmWork.CompanyNameCd = _CompanyNm.CompanyNameCd;
            wkCompanyNmWork.CompanyPr = _CompanyNm.CompanyPr;
            wkCompanyNmWork.CompanyName1 = _CompanyNm.CompanyName1;
            wkCompanyNmWork.CompanyName2 = _CompanyNm.CompanyName2;
            wkCompanyNmWork.PostNo = _CompanyNm.PostNo;
            wkCompanyNmWork.Address1 = _CompanyNm.Address1;
            //wkCompanyNmWork.Address2 = _CompanyNm.Address2; // 2008.06.05 del
            wkCompanyNmWork.Address3 = _CompanyNm.Address3;
            wkCompanyNmWork.Address4 = _CompanyNm.Address4;
            wkCompanyNmWork.CompanyTelNo1 = _CompanyNm.CompanyTelNo1;
            wkCompanyNmWork.CompanyTelNo2 = _CompanyNm.CompanyTelNo2;
            wkCompanyNmWork.CompanyTelNo3 = _CompanyNm.CompanyTelNo3;
            wkCompanyNmWork.CompanyTelTitle1 = _CompanyNm.CompanyTelTitle1;
            wkCompanyNmWork.CompanyTelTitle2 = _CompanyNm.CompanyTelTitle2;
            wkCompanyNmWork.CompanyTelTitle3 = _CompanyNm.CompanyTelTitle3;
            wkCompanyNmWork.TransferGuidance = _CompanyNm.TransferGuidance;
            wkCompanyNmWork.AccountNoInfo1 = _CompanyNm.AccountNoInfo1;
            wkCompanyNmWork.AccountNoInfo2 = _CompanyNm.AccountNoInfo2;
            wkCompanyNmWork.AccountNoInfo3 = _CompanyNm.AccountNoInfo3;
            wkCompanyNmWork.CompanySetNote1 = _CompanyNm.CompanySetNote1;
            wkCompanyNmWork.CompanySetNote2 = _CompanyNm.CompanySetNote2;
            //wkCompanyNmWork.TakeInImageGroupCd = _CompanyNm.TakeInImageGroupCd;// del 2007.05.16 Saitoh
            wkCompanyNmWork.ImageInfoDiv = _CompanyNm.ImageInfoDiv;// add 2007.05.16 Saitoh
            wkCompanyNmWork.ImageInfoCode = _CompanyNm.ImageInfoCode;// add 2007.05.16 Saitoh
            wkCompanyNmWork.CompanyUrl = _CompanyNm.CompanyUrl;
            wkCompanyNmWork.CompanyPrSentence2 = _CompanyNm.CompanyPrSentence2;
            wkCompanyNmWork.ImageCommentForPrt1 = _CompanyNm.ImageCommentForPrt1;
            wkCompanyNmWork.ImageCommentForPrt2 = _CompanyNm.ImageCommentForPrt2;
            #endregion

            return wkCompanyNmWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（自社名称クラス⇒自社名称ワーククラス）
        /// </summary>
        /// <param name="_CompanyNmArray">自社名称クラス</param>
        /// <returns>自社名称ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 自社名称クラスから自社名称ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 21015  金巻　芳則</br>
        /// <br>Date       : 2005.10.03</br>
        /// </remarks>
        private static ArrayList CopyToCompanyNmWorkFromCompanyNm(CompanyNm[] _CompanyNmArray)
        {
            ArrayList al = new ArrayList();
            for (int i = 0; i < _CompanyNmArray.Length; i++)
            {
                CompanyNm _CompanyNm = _CompanyNmArray[i] as CompanyNm;
                CompanyNmWork wkCompanyNmWork = new CompanyNmWork();

                #region CompanyNm → CompanyNmWork
                wkCompanyNmWork.CreateDateTime = _CompanyNm.CreateDateTime;
                wkCompanyNmWork.UpdateDateTime = _CompanyNm.UpdateDateTime;
                wkCompanyNmWork.EnterpriseCode = _CompanyNm.EnterpriseCode;
                wkCompanyNmWork.FileHeaderGuid = _CompanyNm.FileHeaderGuid;
                wkCompanyNmWork.UpdEmployeeCode = _CompanyNm.UpdEmployeeCode;
                wkCompanyNmWork.UpdAssemblyId1 = _CompanyNm.UpdAssemblyId1;
                wkCompanyNmWork.UpdAssemblyId2 = _CompanyNm.UpdAssemblyId2;
                wkCompanyNmWork.LogicalDeleteCode = _CompanyNm.LogicalDeleteCode;
                wkCompanyNmWork.CompanyNameCd = _CompanyNm.CompanyNameCd;
                wkCompanyNmWork.CompanyPr = _CompanyNm.CompanyPr;
                wkCompanyNmWork.CompanyName1 = _CompanyNm.CompanyName1;
                wkCompanyNmWork.CompanyName2 = _CompanyNm.CompanyName2;
                wkCompanyNmWork.PostNo = _CompanyNm.PostNo;
                wkCompanyNmWork.Address1 = _CompanyNm.Address1;
                //wkCompanyNmWork.Address2 = _CompanyNm.Address2; // 2008.06.05 del
                wkCompanyNmWork.Address3 = _CompanyNm.Address3;
                wkCompanyNmWork.Address4 = _CompanyNm.Address4;
                wkCompanyNmWork.CompanyTelNo1 = _CompanyNm.CompanyTelNo1;
                wkCompanyNmWork.CompanyTelNo2 = _CompanyNm.CompanyTelNo2;
                wkCompanyNmWork.CompanyTelNo3 = _CompanyNm.CompanyTelNo3;
                wkCompanyNmWork.CompanyTelTitle1 = _CompanyNm.CompanyTelTitle1;
                wkCompanyNmWork.CompanyTelTitle2 = _CompanyNm.CompanyTelTitle2;
                wkCompanyNmWork.CompanyTelTitle3 = _CompanyNm.CompanyTelTitle3;
                wkCompanyNmWork.TransferGuidance = _CompanyNm.TransferGuidance;
                wkCompanyNmWork.AccountNoInfo1 = _CompanyNm.AccountNoInfo1;
                wkCompanyNmWork.AccountNoInfo2 = _CompanyNm.AccountNoInfo2;
                wkCompanyNmWork.AccountNoInfo3 = _CompanyNm.AccountNoInfo3;
                wkCompanyNmWork.CompanySetNote1 = _CompanyNm.CompanySetNote1;
                wkCompanyNmWork.CompanySetNote2 = _CompanyNm.CompanySetNote2;
                //wkCompanyNmWork.TakeInImageGroupCd = _CompanyNm.TakeInImageGroupCd;// del 2007.05.16 Saitoh
                wkCompanyNmWork.ImageInfoDiv = _CompanyNm.ImageInfoDiv;// add 2007.05.16 Saitoh
                wkCompanyNmWork.ImageInfoCode = _CompanyNm.ImageInfoCode;// add 2007.05.16 Saitoh
                wkCompanyNmWork.CompanyUrl = _CompanyNm.CompanyUrl;
                wkCompanyNmWork.CompanyPrSentence2 = _CompanyNm.CompanyPrSentence2;
                wkCompanyNmWork.ImageCommentForPrt1 = _CompanyNm.ImageCommentForPrt1;
                wkCompanyNmWork.ImageCommentForPrt2 = _CompanyNm.ImageCommentForPrt2;
                #endregion
                al.Add(wkCompanyNmWork);
            }
            return al;
        }

    }

        #endregion


}

//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 入金伝票入力
// プログラム概要   : 入金伝票入力の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/06/26  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/05/15  修正内容 : MANTIS【13286、13287】請求全体設定の最新情報取得
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 修 正 日  2009/07/21  修正内容 : MANTIS【13286、13287】フィードバック対応
//----------------------------------------------------------------------------//
// 管理番号  10802197-00 作成担当 : FSI今野
// 修 正 日  K2012/07/13 修正内容 : 山形部品個別依頼
//                                : 振込金額入力時は独自の銀行コードの入力を可能に修正
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Data;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 入金伝票入力設定系データアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金伝票入力設定系データの取得を行います。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br>Update Note: 18322 T.Kimura 携帯.NS用に変更</br>
    /// <br>Update Note: 2008/06/26 30414 忍 幸史 Partsman用に変更</br>
    /// <br>UpdateNote : K2012/07/13 FSI今野 山形部品個別依頼</br>
    /// <br>             振込金額入力時は独自の銀行コードの入力を可能に修正</br>
    /// <br></br>
	/// </remarks>
	public class DepositRelDataAcs
	{
		# region Constructor
		/// <summary>
		/// 入金伝票入力設定系データアクセスクラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用するメンバの初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		static DepositRelDataAcs()
		{
			try
			{
				// 拠点情報アクセスクラス
				_secInfoAcs = new SecInfoAcs();

                // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
                // 売上全体設定マスタアクセスクラス
                _salesTtlStAcs = new SalesTtlStAcs();
                // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

                // ADD 2009/05/15 ------>>>
                // 請求全体設定マスタアクセスクラス
                _billAllStAcs = new BillAllStAcs();
                // ADD 2009/05/15 ------<<<
                
				// リモートオブジェクト取得
				_iDepBillMonSecDB = (IDepBillMonSecDB)MediationDepBillMonSecDB.GetDepBillMonSecDB();
			}
			catch (Exception)
			{				
				// オフライン時はnullをセット
				_iDepBillMonSecDB = null;
			}
		}
		# endregion

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        # region public const Members

        //***************************************************************
        // 入金内訳情報DataSet用定数宣言
        //***************************************************************
        /// <summary>入金内訳情報Table名称</summary>
        public const string ctDepositKindDataTable = "DepositKindTable";

        /// <summary>金種区分</summary>
        public const string ctDepositKindDiv = "DepositKindDiv";

        /// <summary>金種コード</summary>
        public const string ctDepositKindCode = "DepositKindCode";

        /// <summary>金種名称(入金内訳)</summary>
        public const string ctDepositKindName = "DepositKindName";

        /// <summary>入金金額</summary>
        public const string ctDeposit = "Deposit";

        /// <summary>年(期日)</summary>
        public const string ctYear = "Year";

        /// <summary>月(期日)</summary>
        public const string ctMonth = "Month";

        /// <summary>日(期日)</summary>
        public const string ctDay = "Day";

        // --- ADD K2012/07/13 ---------->>>>>
        /// <summary>銀行コード</summary>
        public const string ctBank = "Bank";
        // --- ADD K2012/07/13 ----------<<<<<

        #endregion public const Members
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        # region Private Menbers
        //***************************************************************
		// 他アセンブリクラスメンバー
		//***************************************************************
		/// <summary>拠点情報アクセスクラス</summary>
		private static SecInfoAcs _secInfoAcs;

		/// <summary>入金設定系リモーティングオブジェクト</summary>
		private static IDepBillMonSecDB _iDepBillMonSecDB = null;

		//***************************************************************
		// 保持用メンバ 入金伝票入力で使用する共通項目など
		//***************************************************************
		/// <summary>画面タイプリスト</summary>
		private static SortedList _slDispType = new SortedList();

		/// <summary>デフォルト画面タイプ</summary>
		private static int _defaultDispType = 0;

        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>入金金種コードリスト</summary>
        //private static SortedList _slMoneyKindCode = new SortedList();
        private static Dictionary<int, string> _dicMoneyKindCode = new Dictionary<int, string>();

        /// <summary>入金行番号リスト</summary>
        private static Dictionary<int, int> _dicDepositRowNo = new Dictionary<int, int>();

        private static DepositSt _depositSt = new DepositSt();

        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>入金金種区分リスト</summary>
		private static Hashtable _htMoneyKindDiv = new Hashtable();

		/// <summary>入金金種名称リスト</summary>
		private static Hashtable _htMoneyKindName = new Hashtable();

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>デフォルト入金金種コード</summary>
		private static int _initSelMoneyKindCd = 0;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>売掛金種コードリスト</summary>
		private static SortedList _slSalesKindCode = new SortedList();

		/// <summary>売掛金種区分リスト</summary>
		private static Hashtable _htSalesKindDiv = new Hashtable();

		/// <summary>売掛金種名称リスト</summary>
		private static Hashtable _htSalesKindName = new Hashtable();

		/// <summary>拠点情報リスト</summary>
		private static SortedList _slSection = new SortedList();

		/// <summary>基準拠点コード</summary>
		private static string _sectionCode = "";

		/// <summary>請求計上拠点コード(ログイン拠点)</summary>
		private static string _demandAddUpSecCd = "";

		/// <summary>本社機能フラグ(ログイン拠点)</summary>
		public static int _mainOfficeFuncFlag = 0;
			
		/// <summary>入金伝票呼出月数</summary>
		private static int _depositCallMonths = 0;

		/// <summary>引当済入金伝票呼出区分</summary>
		private static int _alwcDepositCall = 0;

		/// <summary>引当処理区分</summary>
		private static int _allowanceProc = 0;

		/// <summary>入金伝票修正区分</summary>
		private static int _depositSlipMnt = 0;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>諸費用別入金オプション</summary>
		private static bool _optSeparateCost = false;

		/// <summary>SFシステム導入フラグ</summary>
		private static bool _introducedSystemSF = false;

		/// <summary>BKシステム導入フラグ</summary>
		private static bool _introducedSystemBK = false;
		
		/// <summary>CSシステム導入フラグ</summary>
		private static bool _introducedSystemCS = false;

        // ↓ 20070116 18322 a
        /// <summary>MAシステム導入フラグ</summary>
        private static bool _introducedSystemMA = false;
        // ↑ 20070116 18322 a
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>入金伝票日付クリア区分</summary>
        /// <value>0:システム日付に戻す　1:入力日付のまま</value>
        private int _depoSlipDateClrDiv;

        /// <value>0:制限なし　1:入力不可</value>
        private int _depoSlipDateAmbit;

        /// <summary>売上全体設定マスタアクセスクラス</summary>
        private static SalesTtlStAcs _salesTtlStAcs;
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        // ADD 2009/05/15 ------>>>
        /// <summary>請求全体設定マスタアクセスクラス</summary>
        private static BillAllStAcs _billAllStAcs;
        // ADD 2009/05/15 ------<<<
        
        # endregion

		# region public property
		/// <summary>画面タイプリスト(get)</summary>
		public SortedList SlDispType
		{
			get{return _slDispType;}
		}
		/// <summary>デフォルト画面タイプ(get)(set)</summary>
		public int DefaultDispType
		{
			get{return _defaultDispType;}
			set{_defaultDispType = value;}
		}

        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>入金金種コードリスト(get)</summary>
        //public SortedList SlMoneyKindCode
        //{
        //    get{return _slMoneyKindCode;}
        //}
        public Dictionary<int, string> DicMoneyKindCode
        {
            get { return _dicMoneyKindCode; }
        }

        /// <summary>入金設定マスタ(get)</summary>
        public DepositSt DepositMaster
        {
            get { return _depositSt; }
        }
        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>入金金種区分リスト(get)</summary>
		public Hashtable HtMoneyKindDiv
		{
			get{return _htMoneyKindDiv;}
		}
		/// <summary>入金金種名称リスト(get)</summary>
		public Hashtable HtMoneyKindName
		{
			get{return _htMoneyKindName;}
		}

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>デフォルト入金金種コード(get)</summary>
		public int InitSelMoneyKindCd
		{
			get{return _initSelMoneyKindCd;}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>売掛金種コードリスト(get)</summary>
		public SortedList SlSalesKindCode
		{
			get{return _slSalesKindCode;}
		}
		/// <summary>売掛金種区分リスト(get)</summary>
		public Hashtable HtSalesKindDiv
		{
			get{return _htSalesKindDiv;}
		}
		/// <summary>売掛金種名称リスト(get)</summary>
		public Hashtable HtSalesKindName
		{
			get{return _htSalesKindName;}
		}
		/// <summary>拠点情報リスト(get)</summary>
		public SortedList SlSection
		{
			get{return _slSection;}
		}
		/// <summary>請求計上拠点コード(ログイン拠点)(get)(set)</summary>
		public string DemandAddUpSecCd
		{
			get{return _demandAddUpSecCd;}
			set{_demandAddUpSecCd = value;}
		}
		/// <summary>本社機能フラグ(ログイン拠点)(get)</summary>
		public int MainOfficeFuncFlag
		{
			get{return _mainOfficeFuncFlag;}
		}
		/// <summary>入金伝票呼出月数(get)</summary>
		public int DepositCallMonths
		{
			get{return _depositCallMonths;}
		}
		/// <summary>引当済入金伝票呼出区分(get)</summary>
		public int AlwcDepositCall
		{
			get{return _alwcDepositCall;}
		}
		/// <summary>引当処理区分(get)</summary>
		public int AllowanceProc
		{
			get{return _allowanceProc;}
		}
		/// <summary>入金伝票修正区分(get)</summary>
		public int DepositSlipMnt
		{
			get{return _depositSlipMnt;}
		}
        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
		/// <summary>諸費用別入金オプション(get)</summary>
		public bool OptSeparateCost
		{
			get{return _optSeparateCost;}
		}
		/// <summary>SFシステム導入チェック(get)</summary>
		public bool IntroducedSystemSF
		{
			get{return _introducedSystemSF;}
		}
		/// <summary>BKシステム導入チェック(get)</summary>
		public bool IntroducedSystemBK
		{
			get{return _introducedSystemBK;}
		}
		/// <summary>CSシステム導入チェック(get)</summary>
		public bool IntroducedSystemCS
		{
			get{return _introducedSystemCS;}
		}

        // ↓ 20070116 18322 a
        /// <summary>MAシステム導入チェック(get)</summary>
        public bool IntroducedSystemMA
        {
            get { return _introducedSystemMA; }
        }
        // ↑ 20070116 18322 a

        /// <summary>システム導入数(get)</summary>
		public int IntroducedSystemCount
		{
			get{
				int cnt = 0;
				if (IntroducedSystemSF) ++cnt;
				if (IntroducedSystemBK) ++cnt;
				if (IntroducedSystemCS) ++cnt;
                // ↓ 20070116 18322 a
                if (IntroducedSystemMA) ++cnt;
                // ↑ 20070116 18322 a
                return cnt;
			}
		}
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>入金伝票日付クリア区分</summary>
        /// <value>0:システム日付に戻す　1:入力日付のまま</value>
        public int DepoSlipDateClrDiv
        {
            get { return _depoSlipDateClrDiv; }
        }

        /// <summary>入金伝票日付範囲区分</summary>
        /// <value>0:制限なし　1:入力不可</value>
        public int DepoSlipDateAmbit
        {
            get { return _depoSlipDateAmbit; }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		# endregion

		# region public Methods

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 売上全体設定マスタ取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 売上全体設定マスタを取得します。
        ///         　　　    拠点が変更される度にこの処理を行う必要があります。</br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int GetSalesTtlSt(string enterpriseCode, string sectionCode)
        {
            int status = 0;
            ArrayList retList = new ArrayList();

            // ADD 2009/05/15 ------>>>
            // 初期設定
            this._depoSlipDateClrDiv = 0;
            this._depoSlipDateAmbit = 0;
            // ADD 2009/05/15 ------<<<
            
            try
            {
                status = _salesTtlStAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (SalesTtlSt salesTtlSt in retList)
                    {
                        // ADD 2009/05/15 ------>>>
                        if ((salesTtlSt.LogicalDeleteCode == 0) && (salesTtlSt.SectionCode.Trim() == "00"))
                        {
                            // 入金伝票日付クリア区分
                            this._depoSlipDateClrDiv = salesTtlSt.DepoSlipDateClrDiv;

                            // 入金伝票日付範囲区分
                            this._depoSlipDateAmbit = salesTtlSt.DepoSlipDateAmbit;

                            continue;
                        }
                        // ADD 2009/05/15 ------<<<
            
                        if ((salesTtlSt.LogicalDeleteCode == 0) && (salesTtlSt.SectionCode.Trim() == sectionCode.Trim()))
                        {
                            // 入金伝票日付クリア区分
                            this._depoSlipDateClrDiv = salesTtlSt.DepoSlipDateClrDiv;
                            
                            // 入金伝票日付範囲区分
                            this._depoSlipDateAmbit = salesTtlSt.DepoSlipDateAmbit;

                            return status;
                        }
                    }
                }
            }
            catch
            {

            }

            return status;
        }

        // ADD 2009/05/15 ------>>>
        /// <summary>
        /// 請求全体設定マスタ取得処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note　　　  : 請求全体設定マスタを取得します。
        ///         　　　    拠点が変更される度にこの処理を行う必要があります。</br>
        /// <br></br>
        /// </remarks>
        public int GetBillAllSt(string enterpriseCode, string sectionCode)
        {
            int status = 0;
            ArrayList retList = new ArrayList();

            // 初期設定
            _depositSlipMnt = 0;
            
            try
            {
                status = _billAllStAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (BillAllSt billAllSt in retList)
                    {
                        if ((billAllSt.LogicalDeleteCode == 0) && (billAllSt.SectionCode.Trim() == "00"))
                        {
                            // 入金伝票修正区分
                            _depositSlipMnt = billAllSt.DepositSlipMntCd;

                            // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                            //引当処理区分
                            _allowanceProc = billAllSt.AllowanceProcCd;
                            // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            continue;
                        }
                        
                        if ((billAllSt.LogicalDeleteCode == 0) && (billAllSt.SectionCode.Trim() == sectionCode.Trim()))
                        {
                            // 入金伝票修正区分
                            _depositSlipMnt = billAllSt.DepositSlipMntCd;

                            // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>> 
                            //引当処理区分
                            _allowanceProc = billAllSt.AllowanceProcCd;
                            // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<

                            return status;
                        }
                    }
                }
            }
            catch
            {

            }

            return status;
        }
        // ADD 2009/05/15 ------<<<

        /// <summary>
        /// 入金行番号取得処理
        /// </summary>
        /// <param name="moneyKindCode">金種コード</param>
        /// <returns>入金行番号</returns>
        /// <remarks>
        /// <br>Note　　　  : 入金行番号を取得します。</br>
        /// <br>Programmer  : 30414 忍　幸史</br>
        /// <br>Date        : 2008/06/26</br>
        /// </remarks>
        public int GetDepositRowNo(int moneyKindCode)
        {
            int depositRowNo = 0;

            if (_dicDepositRowNo.ContainsKey(moneyKindCode))
            {
                depositRowNo = _dicDepositRowNo[moneyKindCode];
            }

            return depositRowNo;
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 入金伝票入力関連設定データ取得処理
		/// </summary>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 設定データ関連を取得します。
		///         　　　    ログイン拠点を軸にして動きます。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int GetInitialSettingData(out string errmsg)
		{
			// ログイン拠点コード取得
			_sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

			return this.InitialSettingData(_sectionCode, out errmsg);
		}

		/// <summary>
		/// 入金伝票入力関連設定データ取得処理
		/// </summary>
		/// <param name="sectionCode">基準拠点コード</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 設定データ関連を取得します。
		///         　　　    ログイン拠点ではなくパラメータの基準拠点コードを軸にして動きます。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		public int GetInitialSettingData(string sectionCode, out string errmsg)
		{
			if ((sectionCode == null) || (sectionCode == ""))
			{
				// ログイン拠点コード取得
				_sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
			}
			else
			{
				// 基準拠点コード取得
				_sectionCode = sectionCode;
			}

			return this.InitialSettingData(_sectionCode, out errmsg);
		}

		# endregion

		# region private Methods
		/// <summary>
		/// 入金伝票入力関連設定データ取得処理
		/// </summary>
		/// <param name="sectionCode">基準拠点コード</param>
		/// <param name="errmsg">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note　　　  : 設定データ関連を取得します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private int InitialSettingData(string sectionCode, out string errmsg)
		{
			int st = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			errmsg = "";
			int count;
			byte[] depositStWorkByte = null;
			byte[] billAllStWorkByte = null;
			object moneyKindWorkListObj = null;
            ArrayList test = new ArrayList();
            moneyKindWorkListObj = test;
			try
			{
				// 入金設定系データ読込み
                st = _iDepBillMonSecDB.Search(out count, 0, LoginInfoAcquisition.EnterpriseCode, out depositStWorkByte, out billAllStWorkByte, out moneyKindWorkListObj);
				if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					errmsg = "入金設定データ取得処理に失敗しました。";
					return st;
				}
			}
			catch (Exception ex)
			{
				errmsg = ex.Message;
				st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				return st;
			}

			// 取得データのデシリアライズ
			DepositStWork depositStWork = (DepositStWork)XmlByteSerializer.Deserialize(depositStWorkByte, typeof(DepositStWork));
			BillAllStWork billAllStWork = (BillAllStWork)XmlByteSerializer.Deserialize(billAllStWorkByte, typeof(BillAllStWork));
			ArrayList moneyKindWorkList = (ArrayList)moneyKindWorkListObj;

            // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>
            //_iDepBillMonSecDB.Searchでは全社設定しか取得されていないため、請求全体設定抽出メソッドを呼び出す
            GetBillAllSt(LoginInfoAcquisition.EnterpriseCode, _sectionCode);
            // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<
            
			// 画面タイプリストの作成
			_slDispType.Clear();
			_slDispType.Add(1, "入金伝票入力(入金型)");
            
            // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if (billAllStWork.AllowanceProcCd != 2)				// 引当不可タイプの時は受注指定型は無し
            if (_allowanceProc != 2)				// 引当不可タイプの時は受注指定型は無し
            // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                // ↓ 20070130 18322 c MA.NS用に変更
				//_slDispType.Add(2, "入金伝票入力(受注指定型)");

				_slDispType.Add(2, "入金伝票入力(売上指定型)");
                // ↑ 20070130 18322 c
			}
			
			// -------------------------- //
			// --- 入金設定マスタより --- //
			// -------------------------- //
			// デフォルト画面タイプ
			_defaultDispType = depositStWork.DepositInitDspNo;

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            // デフォルト入金金種コード
            _initSelMoneyKindCd = depositStWork.InitSelMoneyKindCd;

            // 入金伝票呼出月数
            _depositCallMonths = depositStWork.DepositCallMonths;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            
            // 引当済入金伝票呼出区分
			_alwcDepositCall = depositStWork.AlwcDepoCallMonthsCd;

			// 入金金種名称リスト/入金金種区分リスト
			_htMoneyKindName.Clear();
			_htMoneyKindDiv.Clear();
			foreach (MoneyKindWork moneyKindWork in moneyKindWorkList)
			{
                if ((moneyKindWork.LogicalDeleteCode == 0) && (moneyKindWork.PriceStCode == 0))
                {
                    _htMoneyKindName.Add(moneyKindWork.MoneyKindCode, moneyKindWork.MoneyKindName);
                    _htMoneyKindDiv.Add(moneyKindWork.MoneyKindCode, moneyKindWork.MoneyKindDiv);
                }
			}

			// 入金設定金種コード
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //_slMoneyKindCode.Clear();
            //if ((depositStWork.DepositStKindCd1 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd1] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd1, _htMoneyKindName[depositStWork.DepositStKindCd1]);
            //if ((depositStWork.DepositStKindCd2 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd2] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd2, _htMoneyKindName[depositStWork.DepositStKindCd2]);
            //if ((depositStWork.DepositStKindCd3 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd3] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd3, _htMoneyKindName[depositStWork.DepositStKindCd3]);
            //if ((depositStWork.DepositStKindCd4 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd4] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd4, _htMoneyKindName[depositStWork.DepositStKindCd4]);
            //if ((depositStWork.DepositStKindCd5 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd5] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd5, _htMoneyKindName[depositStWork.DepositStKindCd5]);
            //if ((depositStWork.DepositStKindCd6 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd6] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd6, _htMoneyKindName[depositStWork.DepositStKindCd6]);
            //if ((depositStWork.DepositStKindCd7 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd7] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd7, _htMoneyKindName[depositStWork.DepositStKindCd7]);
            //if ((depositStWork.DepositStKindCd8 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd8] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd8, _htMoneyKindName[depositStWork.DepositStKindCd8]);
            //if ((depositStWork.DepositStKindCd9 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd9] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd9, _htMoneyKindName[depositStWork.DepositStKindCd9]);
            //if ((depositStWork.DepositStKindCd10 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd10] != null))
            //    _slMoneyKindCode.Add(depositStWork.DepositStKindCd10, _htMoneyKindName[depositStWork.DepositStKindCd10]);

            _dicMoneyKindCode.Clear();
            _dicDepositRowNo.Clear();
            if ((depositStWork.DepositStKindCd1 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd1] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd1, (string)_htMoneyKindName[depositStWork.DepositStKindCd1]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd1, 1);
            }
            if ((depositStWork.DepositStKindCd2 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd2] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd2, (string)_htMoneyKindName[depositStWork.DepositStKindCd2]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd2, 2);
            }
            if ((depositStWork.DepositStKindCd3 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd3] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd3, (string)_htMoneyKindName[depositStWork.DepositStKindCd3]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd3, 3);
            }
            if ((depositStWork.DepositStKindCd4 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd4] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd4, (string)_htMoneyKindName[depositStWork.DepositStKindCd4]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd4, 4);
            }
            if ((depositStWork.DepositStKindCd5 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd5] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd5, (string)_htMoneyKindName[depositStWork.DepositStKindCd5]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd5, 5);
            }
            if ((depositStWork.DepositStKindCd6 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd6] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd6, (string)_htMoneyKindName[depositStWork.DepositStKindCd6]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd6, 6);
            }
            if ((depositStWork.DepositStKindCd7 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd7] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd7, (string)_htMoneyKindName[depositStWork.DepositStKindCd7]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd7, 7);
            }
            if ((depositStWork.DepositStKindCd8 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd8] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd8, (string)_htMoneyKindName[depositStWork.DepositStKindCd8]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd8, 8);
            }
            if ((depositStWork.DepositStKindCd9 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd9] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd9, (string)_htMoneyKindName[depositStWork.DepositStKindCd9]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd9, 9);
            }
            if ((depositStWork.DepositStKindCd10 != 0) && (_htMoneyKindName[depositStWork.DepositStKindCd10] != null))
            {
                _dicMoneyKindCode.Add(depositStWork.DepositStKindCd10, (string)_htMoneyKindName[depositStWork.DepositStKindCd10]);
                _dicDepositRowNo.Add(depositStWork.DepositStKindCd10, 10);
            }

            _depositSt.DepositStKindCd1 = depositStWork.DepositStKindCd1;
            _depositSt.DepositStKindCd2 = depositStWork.DepositStKindCd2;
            _depositSt.DepositStKindCd3 = depositStWork.DepositStKindCd3;
            _depositSt.DepositStKindCd4 = depositStWork.DepositStKindCd4;
            _depositSt.DepositStKindCd5 = depositStWork.DepositStKindCd5;
            _depositSt.DepositStKindCd6 = depositStWork.DepositStKindCd6;
            _depositSt.DepositStKindCd7 = depositStWork.DepositStKindCd7;
            _depositSt.DepositStKindCd8 = depositStWork.DepositStKindCd8;
            _depositSt.DepositStKindCd9 = depositStWork.DepositStKindCd9;
            _depositSt.DepositStKindCd10 = depositStWork.DepositStKindCd10;

            _depositSt.DepositStKindCdNm1 = (string)_htMoneyKindName[depositStWork.DepositStKindCd1];
            _depositSt.DepositStKindCdNm2 = (string)_htMoneyKindName[depositStWork.DepositStKindCd2];
            _depositSt.DepositStKindCdNm3 = (string)_htMoneyKindName[depositStWork.DepositStKindCd3];
            _depositSt.DepositStKindCdNm4 = (string)_htMoneyKindName[depositStWork.DepositStKindCd4];
            _depositSt.DepositStKindCdNm5 = (string)_htMoneyKindName[depositStWork.DepositStKindCd5];
            _depositSt.DepositStKindCdNm6 = (string)_htMoneyKindName[depositStWork.DepositStKindCd6];
            _depositSt.DepositStKindCdNm7 = (string)_htMoneyKindName[depositStWork.DepositStKindCd7];
            _depositSt.DepositStKindCdNm8 = (string)_htMoneyKindName[depositStWork.DepositStKindCd8];
            _depositSt.DepositStKindCdNm9 = (string)_htMoneyKindName[depositStWork.DepositStKindCd9];
            _depositSt.DepositStKindCdNm10 = (string)_htMoneyKindName[depositStWork.DepositStKindCd10];

            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<

			// -------------------------- //
			// --- 請求設定マスタより --- //
			// -------------------------- //
			// 引当処理区分
			//_allowanceProc = billAllStWork.AllowanceProcCd; // DEL 2009/07/21

			// 入金伝票修正区分
            //_depositSlipMnt = billAllStWork.DepositSlipMntCd;     // DEL 2009/05/15

			// -------------------------- //
			// --- 拠点情報マスタより --- //
			// -------------------------- //
			_slSection.Clear();
			// アクセスクラスより拠点データを取得する
			foreach (SecInfoSet dt in _secInfoAcs.SecInfoSetList)
			{
				_slSection.Add(dt.SectionCode, dt.SectionGuideNm);

                if (dt.SectionCode.Trim() == sectionCode.Trim())
                {
                    _demandAddUpSecCd = sectionCode;
                }
			}

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// 基準拠点の請求計上拠点の取得
			SecInfoSet secInfoSet;
			_secInfoAcs.GetSecInfo(sectionCode, SecInfoAcs.CtrlFuncCode.DemandAddUpSecCd, out secInfoSet);
			_demandAddUpSecCd = secInfoSet.SectionCode;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            // 本社機能のみ使用 [9577]
            _mainOfficeFuncFlag = 1;

            //// 導入オプション/システムチェック
            //PurchaseStatus purchaseSt;

            //// 拠点オプション未導入時
            //purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION);
            //if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
            //{
            //    // 本社機能フラグ
            //    _mainOfficeFuncFlag = _secInfoAcs.GetMainOfficeFuncFlag(sectionCode);
            //}
            //else
            //{
            //    // 本社機能フラグ
            //    _mainOfficeFuncFlag = 0;
            //}

            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
			// 諸費用別入金オプションはあるか
			purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SeparatePayment);
			if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
				_optSeparateCost = true;
			// 整備システムあるか？
			purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF);
			if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
				_introducedSystemSF = true;
			// 鈑金システムあるか？
			purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK);
			if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
				_introducedSystemBK = true;
			// 車販システムあるか？
			purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS);
			if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
				_introducedSystemCS = true;

            // ↓ 20070116 18322 a
            // 携帯.NS有無
            purchaseSt = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_KT);
            if ((purchaseSt == PurchaseStatus.Contract) || (purchaseSt == PurchaseStatus.Trial_Contract))
            {
                // 契約済みか試用版のとき
                _introducedSystemMA = true;
            }
            // ↑ 20070116 18322 a
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

            return st;
		}
		# endregion
	}
}

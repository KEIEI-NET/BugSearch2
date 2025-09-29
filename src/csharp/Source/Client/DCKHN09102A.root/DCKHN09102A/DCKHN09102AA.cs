//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率優先管理マスタ
// プログラム概要   ：掛率優先管理の登録・変更・削除を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/06/16     修正内容：ローカルDB対応削除
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/10     修正内容：Mantis【13168】ガイドで全社共通を取得を考慮するように修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：20056 對馬 大輔
// 修正日    2009.08.11     修正内容：サーバーのサービス起動対応(SCM)
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22008 長内 数馬
// 修正日    2010/05/25     修正内容：オフライン対応
// ---------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// 掛率優先管理マスタアクセスクラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : 掛率優先管理マスタのアクセス制御を行います。</br>
	/// <br>Programmer : 30167 上野　弘貴</br>
	/// <br>Date       : 2007.09.12</br>
	/// <br>Update Note: 2008.01.31 30167 上野　弘貴</br>
	/// <br>			 ローカルＤＢ対応</br>
    /// <br>Update Note: 2008/06/16 30414 忍　幸史</br>
    /// <br>             ローカルDB対応削除</br>
	/// </remarks>
	public class RateProtyMngAcs : IGeneralGuideData
    {
		// 掛率優先管理設定マスタ定数定義
		/// <summary>作成日付</summary>
		public const string CREATEDATETIME = "CreateDateTime";
		/// <summary>更新日付</summary>
		public const string UPDATEDATETIME = "UpdateDateTime";
		/// <summary>企業コード</summary>
		public const string ENTERPRISECODE = "EnterpriseCode";
		/// <summary>GUID</summary>
		public const string FILEHEADERGUID = "FileHeaderGuid";
		/// <summary>更新従業員コード</summary>
		public const string UPDEMPLOYEECODE = "UpdEmployeeCode";
		/// <summary>更新アセンブリID1</summary>
		public const string UPDASSEMBLYID1 = "UpdAssemblyId1";
		/// <summary>更新アセンブリID2</summary>
		public const string UPDASSEMBLYID2 = "UpdAssemblyId2";
		/// <summary>論理削除区分</summary>
		public const string LOGICALDELETECODE = "LogicalDeleteCode";
		/// <summary>拠点コード</summary>
		public const string SECTIONCODE = "拠点コード";
		/// <summary>拠点名称</summary>
		public const string SECTIONNAME = "拠点名称";
		/// <summary>単価種類</summary>
		public const string UNITPRICEKIND = "単価種類";
		/// <summary>単価種類名称</summary>
		public const string UNITPRICEKINDNM = "単価種類名称";	// ビュー表示用
		/// <summary>使用区分</summary>
		public const string UTILITYDIV_TITLE = "使用区分";		// 全社共通or拠点設定
		/// <summary>掛率設定区分</summary>
		public const string RATESETTINGDIVIDE = "掛率設定区分";
		/// <summary>掛率優先順位</summary>
		public const string RATEPRIORITYORDER = "掛率優先順位";
		/// <summary>掛率設定区分（商品）</summary>
		public const string RATEMNGGOODSCD = "掛率設定区分（商品）";
		/// <summary>掛率設定名称（商品）</summary>
		public const string RATEMNGGOODSNM = "掛率設定名称（商品）";
		/// <summary>掛率設定区分（得意先）</summary>
		public const string RATEMNGCUSTCD = "掛率設定区分（得意先）";
		/// <summary>掛率設定名称（得意先）</summary>
		public const string RATEMNGCUSTNM = "掛率設定名称（得意先）";
		/// <summary>削除日</summary>
		public const string DELETE_DATE_TITLE = "削除日";
		
		// テーブル名
		/// <summary>拠点テーブル</summary>
		public const string SECTION_TABLE = "SectionTable";
		/// <summary>単価種類テーブル</summary>
		public const string UNITPRICEKIND_TABLE = "UnitPriceKindTable";
		/// <summary>掛率優先管理テーブル</summary>
		public const string RATEPROTYMNG_TABLE = "RateProtyMngTable";

		// 全社共通拠点
        // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
		/// <summary>全社共通拠点コード</summary>
        //public const string ALL_SECTION_CODE = "000000";
        public const string ALL_SECTION_CODE = "00";
        // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<
		/// <summary>全社共通拠点名称</summary>
		public const string ALL_SECTION_NAME = "全社共通";
		/// <summary>使用区分（全社共通拠点名称）</summary>
		public const string ALL_UTILITYDIV = "全社共通";
		/// <summary>使用区分（自拠点名称）</summary>
		public const string SEC_UTILITYDIV = "自拠点";
		
        #region  private member
        // リモートオブジェクト格納バッファ
        private IRateProtyMngDB _iRateProtyMngDB = null;    // 掛率優先管理設定リモート

        /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
        //----- ueno add ---------- start 2008.01.31
        private RateProtyMngLcDB _rateProtyMngLcDB = null;
        //----- ueno add ---------- end 2008.01.31
           --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
        
        // ビュー用テーブル
        private DataSet _dataTableList = null;
		
		// 拠点マスタアクセス
		private SecInfoAcs _secInfoAcs = null;
		
		// 全社共通拠点コードフラグ
		private bool allSectionFlag = false;

        // 全社共通表示フラグ
        private static bool _comonShowFlg = true;

		//----------------
		// キャッシュ関係
		//----------------
		// Static格納用HashTable
		private static Hashtable _static_RateProtyMngTable = null;

		// 掛率優先管理設定マスタクラスSearchフラグ
		private static bool _searchFlg;

		//----------------
		// ガイド関係
		//----------------
		// ガイド絞込み用
		private static string _static_sectionCodeGuide;
		private static int _static_unitPriceKindGuide;
		private static int _static_unitPriceKindWayGuide;

		// ガイド検索用
		private static SortedList _static_rateProtyMngSortedListGuide = null;		
		
		// 文字列結合用
		private StringBuilder _stringBuilder = null;

		// ガイド設定ファイル名
		private const string GUIDE_XML_FILENAME = "RATEPROTYMNGGUIDEPARENT.XML";	// XMLファイル名
		
		// ガイドパラメータ
		private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";			// 企業コード
		
		// ガイド項目タイプ
		private const string GUIDE_TYPE_STR = "System.String";						// String型
		
		// ガイド項目名
		private const string GUIDE_SECTIONCODE_TITLE	= "SectionCode";			// 拠点コード
		private const string RATEPRIORITYORDER_TITLE	= "RatePriorityOrder";		// 掛率優先順位
		private const string UNITPRICEKIND_TITLE		= "UnitPriceKind";			// 単価種類
		private const string RATESETTINGDIVIDE_TITLE	= "RateSettingDivide";		// 掛率設定区分
		private const string RATESETTINGDIVIDENM_TITLE	= "RateSettingDivideNm";	// 掛率設定内容
		private const string RATEMNGGOODSCD_TITLE		= "RateMngGoodsCd";			// 掛率設定区分（商品）
		private const string RATEMNGCUSTCD_TITLE		= "RateMngCustCd";			// 掛率設定区分（得意先）

        /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
		//----- ueno add ---------- start 2008.01.31
		private static bool _isLocalDBRead = false;	// デフォルトはリモート
		//----- ueno add ---------- end 2008.01.31
           --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
        
        #endregion

        /// <summary>
		/// 掛率優先管理マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
		/// <br>Note       : 掛率優先管理マスタアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.12</br>
		/// </remarks>
		public RateProtyMngAcs()
        {
            try
            {
				// メモリ生成処理
				MemoryCreate();

                // リモートオブジェクト取得
                this._iRateProtyMngDB = (IRateProtyMngDB)MediationRateProtyMngDB.GetRateProtyMngDB();				
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRateProtyMngDB = null;
            }

            /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
			//----- ueno add ---------- start 2008.01.31
			// ローカルDBアクセスオブジェクト取得
			this._rateProtyMngLcDB = new RateProtyMngLcDB();
			//----- ueno add ---------- end 2008.01.31
               --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/
            
            //----- ueno del ---------- start 2008.01.31
			// ローカルＤＢ対応により取得位置変更
			// 拠点マスタアクセスクラス
			//this._secInfoAcs = new SecInfoAcs();
			//----- ueno del ---------- end 2008.01.31

            // データセット列情報構築処理
            this._dataTableList = new DataSet();
            DataSetColumnConstruction(ref this._dataTableList);

			// ガイド検索用
			_static_rateProtyMngSortedListGuide = new SortedList();

			// 文字列結合用
			_stringBuilder = new StringBuilder();
        }

        /// <summary>
		/// 掛率優先管理テーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
		/// <br>Note       : 掛率優先管理テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		static RateProtyMngAcs()
        {
            // Static格納用HashTable
			_static_RateProtyMngTable = new Hashtable();
        }

        /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
		//----- ueno add ---------- start 2008.01.31
		#region Public Property

		//================================================================================
		//  プロパティ
		//================================================================================
		/// <summary>
		/// ローカルＤＢReadモード
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
		#endregion
		//----- ueno add ---------- end 2008.01.31
           --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/

        /// <summary>オンラインモードの列挙型です。</summary>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.12</br>
		/// </remarks>
        public int GetOnlineMode()
        {
            if (this._iRateProtyMngDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
        }

		/// <summary>
		/// 掛率優先管理 Staticメモリ全件取得処理
		/// </summary>
		/// <param name="retList">掛率優先管理マスタ クラスList</param>
		/// <returns>ステータス(0:正常終了, -1:エラー, 9:データ無し)</returns>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <remarks>
		/// <br>Note       : 掛率優先管理マスタ Staticメモリの全件を取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		public int SearchStaticMemory(out ArrayList retList, string enterpriseCode, string sectionCode)
		{
			retList = new ArrayList();
			retList.Clear();
			SortedList sortedList = new SortedList();

			if ((_static_RateProtyMngTable == null) || (_static_RateProtyMngTable.Count == 0))
			{
				int totalCount;
				bool nextData;
				string message;

				SearchAll(out retList, out totalCount, out nextData, enterpriseCode, sectionCode, out message);
				return 0;
			}
			else if (_static_RateProtyMngTable.Count == 0)
			{
				return 9;
			}

			foreach (RateProtyMng rateProtyMng in _static_RateProtyMngTable.Values)
			{
				sortedList.Add(CreateHashKey(rateProtyMng), rateProtyMng);
			}
			retList.AddRange(sortedList.Values);

			return 0;
		}

		/// <summary>
		/// 掛率優先管理設定読み込み処理
		/// </summary>
		/// <param name="rateProtyMng">掛率優先管理設定オブジェクト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="unitPriceKindWay">設定方法（0:単品設定, 1:商品ｸﾞﾙｰﾌﾟ設定）</param>
		/// <param name="rateSettingDivide">掛率設定区分</param>
		/// <returns>掛率優先管理設定クラス</returns>
		/// <remarks>
		/// <br>Note       : 掛率優先管理設定情報を読み込みます。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.29</br>
		/// </remarks>
		public int Read(out RateProtyMng rateProtyMng, string enterpriseCode, string sectionCode, Int32 unitPriceKind, int unitPriceKindWay, string rateSettingDivide)
		{
			try
			{
				int status = 0;
				rateProtyMng = null;
				RateProtyMngWork rateProtyMngWork = new RateProtyMngWork();

				// キー項目設定
				rateProtyMngWork.EnterpriseCode		= enterpriseCode;
				rateProtyMngWork.SectionCode		= sectionCode;
				rateProtyMngWork.UnitPriceKind		= unitPriceKind;
				rateProtyMngWork.RateSettingDivide	= rateSettingDivide;

                /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
                //----- ueno upd ---------- start 2008.01.31
                // ローカル
                if (_isLocalDBRead)
                {
                    // 掛率優先管理設定読み込み
                    status = this._rateProtyMngLcDB.Read(ref rateProtyMngWork, 0);
					
                    //--------------------------------------------
                    // データが存在しない場合、全社設定を検索する
                    //--------------------------------------------
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        rateProtyMng = null;
                        rateProtyMngWork = new RateProtyMngWork();
						
                        // キー項目設定
                        rateProtyMngWork.EnterpriseCode = enterpriseCode;
                        rateProtyMngWork.SectionCode = ALL_SECTION_CODE;
                        rateProtyMngWork.UnitPriceKind = unitPriceKind;
                        rateProtyMngWork.RateSettingDivide = rateSettingDivide;
						
                        // 掛率優先管理設定読み込み
                        status = this._rateProtyMngLcDB.Read(ref rateProtyMngWork, 0);
                    }
                }
                // リモート
                else
                {
                    // XMLへ変換し、文字列のバイナリ化
                    byte[] parabyte = XmlByteSerializer.Serialize(rateProtyMngWork);

                    // 掛率優先管理設定読み込み
                    status = this._iRateProtyMngDB.Read(ref parabyte, 0);

                    //--------------------------------------------
                    // データが存在しない場合、全社設定を検索する
                    //--------------------------------------------
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        rateProtyMng = null;
                        rateProtyMngWork = new RateProtyMngWork();
						
                        // キー項目設定
                        rateProtyMngWork.EnterpriseCode = enterpriseCode;
                        rateProtyMngWork.SectionCode = ALL_SECTION_CODE;
                        rateProtyMngWork.UnitPriceKind = unitPriceKind;
                        rateProtyMngWork.RateSettingDivide = rateSettingDivide;
						
                        // XMLへ変換し、文字列のバイナリ化
                        parabyte = XmlByteSerializer.Serialize(rateProtyMngWork);

                        // 掛率優先管理設定読み込み
                        status = this._iRateProtyMngDB.Read(ref parabyte, 0);
                    }

                    if (status == 0)
                    {
                        // XMLの読み込み
                        rateProtyMngWork = (RateProtyMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(RateProtyMngWork));
                    }
                }
                   --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(rateProtyMngWork);

                // 掛率優先管理設定読み込み
                status = this._iRateProtyMngDB.Read(ref parabyte, 0);
                
                //--------------------------------------------
                // データが存在しない場合、全社設定を検索する
                //--------------------------------------------
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    rateProtyMng = null;
                    rateProtyMngWork = new RateProtyMngWork();

                    // キー項目設定
                    rateProtyMngWork.EnterpriseCode = enterpriseCode;
                    rateProtyMngWork.SectionCode = ALL_SECTION_CODE;
                    rateProtyMngWork.UnitPriceKind = unitPriceKind;
                    rateProtyMngWork.RateSettingDivide = rateSettingDivide;

                    // XMLへ変換し、文字列のバイナリ化
                    parabyte = XmlByteSerializer.Serialize(rateProtyMngWork);

                    // 掛率優先管理設定読み込み
                    status = this._iRateProtyMngDB.Read(ref parabyte, 0);
                }

                if (status == 0)
                {
                    // XMLの読み込み
                    rateProtyMngWork = (RateProtyMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(RateProtyMngWork));
                }
                // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<

				if (status == 0)
				{
					//// XMLの読み込み
					//rateProtyMngWork = (RateProtyMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(RateProtyMngWork));

					// 単品設定時
					if (unitPriceKindWay == 0)
					{
						if (string.Equals(rateProtyMngWork.RateMngGoodsCd.Trim(), "A") == false)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
						}
					
					}
					// 商品グループ設定時
					else
					{
						if (string.Equals(rateProtyMngWork.RateMngGoodsCd.Trim(), "A") == true)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
						}
					}
					
					if(status == 0)
					{
						// クラス内メンバコピー
						rateProtyMng = CopyToRateProtyMngFromRateProtyMngWork(rateProtyMngWork);
						
						// Staticに保持
						_static_RateProtyMngTable[CreateHashKey(rateProtyMng)] = rateProtyMng;
					}
				}
				//----- ueno upd ---------- start 2008.01.31

				return status;
			}
			catch (Exception)
			{
				// 通信エラーは-1を戻す
				rateProtyMng = null;
				// オフライン時はnullをセット
				this._iRateProtyMngDB = null;
				return -1;
			}
		}

        public int Read(out RateProtyMng rateProtyMng, string enterpriseCode, string sectionCode, Int32 unitPriceKind, int unitPriceKindWay, string rateSettingDivide, bool comonShowFlg)
        {
            try
            {
                int status = 0;
                rateProtyMng = null;

                // DEL 2009/04/10 ------>>>
                //RateProtyMngWork rateProtyMngWork = new RateProtyMngWork();

                //// キー項目設定
                //rateProtyMngWork.EnterpriseCode = enterpriseCode;
                //rateProtyMngWork.SectionCode = sectionCode;
                //rateProtyMngWork.UnitPriceKind = unitPriceKind;
                //rateProtyMngWork.RateSettingDivide = rateSettingDivide;

                //// XMLへ変換し、文字列のバイナリ化
                //byte[] parabyte = XmlByteSerializer.Serialize(rateProtyMngWork);

                //// 掛率優先管理設定読み込み
                //status = this._iRateProtyMngDB.Read(ref parabyte, 0);

                //if (comonShowFlg)
                //{
                //    //--------------------------------------------
                //    // データが存在しない場合、全社設定を検索する
                //    //--------------------------------------------
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                //    {
                //        rateProtyMng = null;
                //        rateProtyMngWork = new RateProtyMngWork();

                //        // キー項目設定
                //        rateProtyMngWork.EnterpriseCode = enterpriseCode;
                //        rateProtyMngWork.SectionCode = ALL_SECTION_CODE;
                //        rateProtyMngWork.UnitPriceKind = unitPriceKind;
                //        rateProtyMngWork.RateSettingDivide = rateSettingDivide;

                //        // XMLへ変換し、文字列のバイナリ化
                //        parabyte = XmlByteSerializer.Serialize(rateProtyMngWork);

                //        // 掛率優先管理設定読み込み
                //        status = this._iRateProtyMngDB.Read(ref parabyte, 0);
                //    }
                //}

                //if (status == 0)
                //{
                //    // XMLの読み込み
                //    rateProtyMngWork = (RateProtyMngWork)XmlByteSerializer.Deserialize(parabyte, typeof(RateProtyMngWork));
                //}

                //if (status == 0)
                //{
                //    // 単品設定時
                //    if (unitPriceKindWay == 0)
                //    {
                //        if (string.Equals(rateProtyMngWork.RateMngGoodsCd.Trim(), "A") == false)
                //        {
                //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //        }

                //    }
                //    // 商品グループ設定時
                //    else
                //    {
                //        if (string.Equals(rateProtyMngWork.RateMngGoodsCd.Trim(), "A") == true)
                //        {
                //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //        }
                //    }

                //    if (status == 0)
                //    {
                //        // クラス内メンバコピー
                //        rateProtyMng = CopyToRateProtyMngFromRateProtyMngWork(rateProtyMngWork);

                //        // Staticに保持
                //        _static_RateProtyMngTable[CreateHashKey(rateProtyMng)] = rateProtyMng;
                //    }
                //}
                // DEL 2009/04/10 ------<<<

                // ADD 2009/04/10 ------>>>
                int unitPriceKindCnt = 0;
                ArrayList retList;
                int retTotalCnt;
                bool nextData;
                string message;
                string sectionCodeZero = sectionCode.TrimEnd().PadLeft(2, '0');
                // 全社共通の取得を考慮
                status = this.Search(out retList, out retTotalCnt, out nextData, enterpriseCode, sectionCodeZero, out message);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (RateProtyMng wkRateProtyMng in retList)
                    {
                        // 拠点＋単価種類でチェック
                        if ((wkRateProtyMng.SectionCode.TrimEnd() == sectionCodeZero) &&
                            (wkRateProtyMng.UnitPriceKind == unitPriceKind))
                        {
                            unitPriceKindCnt++;

                            // 掛率設定区分でチェック
                            if (wkRateProtyMng.RateSettingDivide != rateSettingDivide)
                            {
                                continue;
                            }

                            // 単品設定時
                            if (unitPriceKindWay == 0)
                            {
                                if (string.Equals(wkRateProtyMng.RateMngGoodsCd.Trim(), "A") == false)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                }

                            }
                            // 商品グループ設定時
                            else
                            {
                                if (string.Equals(wkRateProtyMng.RateMngGoodsCd.Trim(), "A") == true)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                }
                            }

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                rateProtyMng = wkRateProtyMng.Clone();
                            }
                            return status;
                        }
                        // 全社共通でチェック
                        else if ((wkRateProtyMng.SectionCode.TrimEnd() == ALL_SECTION_CODE) &&
                                 (wkRateProtyMng.UnitPriceKind == unitPriceKind) &&
                                 (wkRateProtyMng.RateSettingDivide == rateSettingDivide))
                        {
                            // 単品設定時
                            if (unitPriceKindWay == 0)
                            {
                                if (string.Equals(wkRateProtyMng.RateMngGoodsCd.Trim(), "A") == false)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                }

                            }
                            // 商品グループ設定時
                            else
                            {
                                if (string.Equals(wkRateProtyMng.RateMngGoodsCd.Trim(), "A") == true)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                }
                            }

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                rateProtyMng = wkRateProtyMng.Clone();
                            }
                        }
                    }

                    if (rateProtyMng == null)
                    {
                        // 該当する掛率設定区分無し
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else if (unitPriceKindCnt > 0)
                    {
                        // 自拠点設定で該当する掛率設定区分無し
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        rateProtyMng = null;
                    }
                }
                // ADD 2009/04/10 ------<<<
                
                return status;
            }
            catch (Exception)
            {
                // 通信エラーは-1を戻す
                rateProtyMng = null;
                // オフライン時はnullをセット
                this._iRateProtyMngDB = null;
                return -1;
            }
        }

		#region ガイド
		/// <summary>
		/// 掛率優先管理設定ガイド起動処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="unitPriceKind">単価種類</param>
		/// <param name="unitPriceKindWay">設定方法（0:単品設定, 1:商品ｸﾞﾙｰﾌﾟ設定）</param>
		/// <param name="rateProtyMng">取得データ</param>
		/// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
		/// <remarks>
		/// <br>Note		: 掛率優先管理設定の一覧表示機能を持つガイドを起動します。</br>
		/// <br>Programmer	: 30167 上野 弘貴</br>
		/// <br>Date		: 2007.10.26</br>
		/// </remarks>
		public int ExecuteGuid(string enterpriseCode, string sectionCode, int unitPriceKind, int unitPriceKindWay, out RateProtyMng rateProtyMng)
		{
            _comonShowFlg = true;
            _searchFlg = false;

			int status = -1;
			rateProtyMng = new RateProtyMng();
			
			TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
			Hashtable inObj = new Hashtable();
			Hashtable retObj = new Hashtable();

			inObj.Add(GUIDE_ENTERPRISECODE_PARA, enterpriseCode);	// 企業コード
			inObj.Add(GUIDE_SECTIONCODE_TITLE, sectionCode);		// 拠点コード
			inObj.Add(UNITPRICEKIND_TITLE, unitPriceKind);			// 単価種類
			
			// 絞込み表示用に保存
			_static_sectionCodeGuide = sectionCode;
			_static_unitPriceKindGuide = unitPriceKind;
			_static_unitPriceKindWayGuide = unitPriceKindWay;
			
			// ガイド起動
			if (tableGuideParent.Execute(0, inObj, ref retObj))
			{
				// 選択データの取得
				rateProtyMng = CopyToRateProtyMngFromGuideData(retObj);
				status = 0;
			}
			// キャンセル
			else
			{
				status = 1;
			}
			return status;
		}

        public int ExecuteGuid(string enterpriseCode, string sectionCode, int unitPriceKind, int unitPriceKindWay, out RateProtyMng rateProtyMng, bool comonShowFlg)
        {
            _comonShowFlg = comonShowFlg;
            _searchFlg = false;

            int status = -1;
            rateProtyMng = new RateProtyMng();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            inObj.Add(GUIDE_ENTERPRISECODE_PARA, enterpriseCode);	// 企業コード
            inObj.Add(GUIDE_SECTIONCODE_TITLE, sectionCode);		// 拠点コード
            inObj.Add(UNITPRICEKIND_TITLE, unitPriceKind);			// 単価種類

            // 絞込み表示用に保存
            _static_sectionCodeGuide = sectionCode;
            _static_unitPriceKindGuide = unitPriceKind;
            _static_unitPriceKindWayGuide = unitPriceKindWay;

            // ガイド起動
            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // 選択データの取得
                rateProtyMng = CopyToRateProtyMngFromGuideData(retObj);
                status = 0;
            }
            // キャンセル
            else
            {
                status = 1;
            }
            return status;
        }

		/// <summary>
		/// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="inParm"></param>
		/// <param name="guideList"></param>
		/// <returns>STATUS[0:取得成功,1:キャンセル,4:レコード無し]</returns>
		/// <remarks>
		/// <br>Note		: 汎用ガイド設定用データを取得します。</br>
		/// <br>Programmer	: 30167 上野 弘貴</br>
		/// <br>Date		: 2007.10.26</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status = -1;
			string enterpriseCode = "";
			string sectionCode = "";
			string unitPriceKind = "";

			// 企業コード設定有り
			if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_PARA))
			{
				enterpriseCode = inParm[GUIDE_ENTERPRISECODE_PARA].ToString();
			}
			// 企業コード設定無し
			else
			{
				// 有り得ないのでエラー
				return status;
			}
			
            // 拠点コード設定有り
			if (inParm.ContainsKey(GUIDE_SECTIONCODE_TITLE))
            {
				sectionCode = inParm[GUIDE_SECTIONCODE_TITLE].ToString();
            }
			
			// 単価種類有り
			if (inParm.ContainsKey(UNITPRICEKIND_TITLE))
			{
				unitPriceKind = inParm[UNITPRICEKIND_TITLE].ToString();
			}

			DataSet retList = null;
			string message = "";
			
			// データ取得
			status = Search(out retList, enterpriseCode, sectionCode, out message);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// ガイド初期起動時
						if (guideList.Tables.Count == 0)
						{
							// ガイド用データセット列情報構築
							this.GuideDataSetColumnConstruction(ref guideList);
						}

                        // ADD 2009/04/10 ------>>>
                        string rowFilter = SECTIONCODE + " = " + _static_sectionCodeGuide + " AND " + UNITPRICEKIND + " = " + _static_unitPriceKindGuide;
                        retList.Tables[RATEPROTYMNG_TABLE].DefaultView.RowFilter = rowFilter;
                        if (retList.Tables[RATEPROTYMNG_TABLE].DefaultView.Count == 0)
                        {
                            // 該当拠点のデータセットが０件なら全社共通を取得
                            _static_sectionCodeGuide = ALL_SECTION_CODE;
                            retList.Tables[RATEPROTYMNG_TABLE].DefaultView.RowFilter = "";
                        }
                        // ADD 2009/04/10 ------<<<

						// ガイド用データセットの作成
						this.GetGuideDataSet(ref guideList, retList, inParm);

						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						status = 4;
						break;
					}
				default:
					{
						status = -1;
						break;
					}
			}
			return status;
		}

		/// <summary>
		/// ガイド用データセット作成処理
		/// </summary>
		/// <param name="retDataSet">結果取得データセット</param>>
		/// <param name="inParm">絞込条件</param>>
		/// <remarks>
		/// <br>Note	   : ガイド用データセット処理を行なう</br>
		/// <br>Programmer	: 30167 上野 弘貴</br>
		/// <br>Date		: 2007.10.26</br>
		/// </remarks>
		private void GetGuideDataSet(ref DataSet retDataSet, DataSet retList, Hashtable inParm)
		{
			DataRow guideRow = null;

			// 行を初期化して新しいデータを追加
			retDataSet.Tables[0].Rows.Clear();
			retDataSet.Tables[0].BeginLoadData();

			int rowCount = retList.Tables[RATEPROTYMNG_TABLE].Rows.Count;

			bool guideFlag = false;	// true:ガイド表示データ, false:ガイド非表示データ

			SortedList rowSortedList = new SortedList();	// データテーブルソート用

			for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
			{
				// 拠点コードと単価種類が一致したときのみ設定
				if ((string.Equals(_static_sectionCodeGuide.Trim(), retList.Tables[RATEPROTYMNG_TABLE].Rows[rowIndex][SECTIONCODE].ToString().Trim()) == true)
					&& (_static_unitPriceKindGuide == NullChgInt(retList.Tables[RATEPROTYMNG_TABLE].Rows[rowIndex][UNITPRICEKIND])))
				{
					// 設定方法判定（単品設定時:Aのみ選択可, 商品ｸﾞﾙｰﾌﾟ設定時:A以外可）
					// 単品設定時
					if (_static_unitPriceKindWayGuide == 0)
					{
						guideFlag = string.Equals(NullChgStr(retList.Tables[RATEPROTYMNG_TABLE].Rows[rowIndex][RATEMNGGOODSCD]).Trim(), "A");
					}
					// 商品グループ設定時
					else
					{
						guideFlag = !(string.Equals(NullChgStr(retList.Tables[RATEPROTYMNG_TABLE].Rows[rowIndex][RATEMNGGOODSCD]).Trim(), "A"));
					}

					if (guideFlag == true)
					{
						guideRow = retDataSet.Tables[0].NewRow();
						// データコピー処理
						CopyToGuideRowFromRateProtyMng(ref guideRow, retList.Tables[RATEPROTYMNG_TABLE].Rows[rowIndex]);

						// ソート用リストに追加（掛率優先順位をキーにしてソート）
						rowSortedList.Add(guideRow[RATEPRIORITYORDER_TITLE], guideRow);
					}
				}
			}

            //--------------------------------------------------------------------
            // ソート用リストからガイドデータへ追加
            //     ※掛率優先順位に空きができる場合があるのを考慮
            //     ex. 1.C1 2.A1 3.C1 のとき、ｸﾞﾙｰﾌﾟでは 1.C1 3.C1 しか表示しない  
            //--------------------------------------------------------------------
            int num = 1;
            foreach (DictionaryEntry de in rowSortedList)
            {
                DataRow guideRowSort = (DataRow)de.Value;

                //// 掛率優先順位番号振り直し
                //guideRowSort[RATEPRIORITYORDER_TITLE] = num;

                // データ追加
                retDataSet.Tables[0].Rows.Add(guideRowSort);
                num++;
            }

			retDataSet.Tables[0].EndLoadData();
		}

		/// <summary>
		/// ガイド用データセット列情報構築処理
		/// </summary>
		/// <param name="guideList">ガイド用データセット</param>>
		/// <remarks>
		/// <br>Note       : ガイド用データセットの列情報を構築します。</br>
		/// <br>Programmer	: 30167 上野 弘貴</br>
		/// <br>Date		: 2007.10.26</br>
		/// </remarks>
		private void GuideDataSetColumnConstruction(ref DataSet guideList)
		{
			DataTable table = new DataTable();
			DataColumn column;

			// 拠点コード
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = GUIDE_SECTIONCODE_TITLE;
			table.Columns.Add(column);
			
			// 単価種類
			column = new DataColumn();
			column.DataType = typeof(Int32);
			column.ColumnName = UNITPRICEKIND_TITLE;
			table.Columns.Add(column);
			
			// 掛率優先順位
			column = new DataColumn();
			column.DataType = typeof(Int32);
			column.ColumnName = RATEPRIORITYORDER_TITLE;
			table.Columns.Add(column);
			
			// 掛率設定区分
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = RATESETTINGDIVIDE_TITLE;
			table.Columns.Add(column);

			// 掛率設定内容
			column = new DataColumn();
			column.DataType = typeof(string);
			column.ColumnName = RATESETTINGDIVIDENM_TITLE;
			table.Columns.Add(column);
			
			// テーブルコピー
			guideList.Tables.Add(table.Clone());
		}

		/// <summary>
		/// クラスメンバコピー処理 (ガイド選択データ⇒掛率優先管理設定マスタクラス)
		/// </summary>
		/// <param name="guideData">ガイド選択データ</param>
		/// <returns>掛率優先管理設定マスタクラス</returns>
		/// <remarks>
		/// <br>Note       : ガイド選択データから掛率優先管理設定マスタクラスへメンバコピーを行います。</br>
		/// <br>Programmer	: 30167 上野 弘貴</br>
		/// <br>Date		: 2007.10.26</br>
		/// </remarks>
		private RateProtyMng CopyToRateProtyMngFromGuideData(Hashtable guideData)
		{
			RateProtyMng rateProtyMng = new RateProtyMng();
			rateProtyMng.RateSettingDivide = (string)guideData[RATESETTINGDIVIDE_TITLE];
			
			DataRow dr = null;
			dr = GetRateSettingDivideInfo((string)guideData[RATESETTINGDIVIDE_TITLE]);
			
			if(dr != null)
			{
				rateProtyMng.RateMngGoodsCd = NullChgStr(dr[RATEMNGGOODSCD]);
				rateProtyMng.RateMngGoodsNm = NullChgStr(dr[RATEMNGGOODSNM]);
				rateProtyMng.RateMngCustCd = NullChgStr(dr[RATEMNGCUSTCD]);
				rateProtyMng.RateMngCustNm = NullChgStr(dr[RATEMNGCUSTNM]);
                rateProtyMng.RatePriorityOrder = (int)dr[RATEPRIORITYORDER];
			}
			return rateProtyMng;
		}

		/// <summary>
		/// DataRowコピー処理（掛率優先管理設定クラス⇒ガイド用DataRow）
		/// </summary>
		/// <param name="guideRow">ガイド用DataRow</param>
		/// <param name="minsection">掛率優先管理設定クラス</param>
		/// <remarks>
		/// <br>Note       : 掛率優先管理設定クラスからガイド用DataRowへコピーを行います。</br>
		/// <br>Programmer	: 30167 上野 弘貴</br>
		/// <br>Date		: 2007.10.26</br>
		/// </remarks>
		private void CopyToGuideRowFromRateProtyMng(ref DataRow guideRow, DataRow rateProtyMngRow)
		{
			guideRow[GUIDE_SECTIONCODE_TITLE]	= rateProtyMngRow[SECTIONCODE];				// 拠点コード
			guideRow[UNITPRICEKIND_TITLE]		= rateProtyMngRow[UNITPRICEKIND];			// 単価種類
			guideRow[RATEPRIORITYORDER_TITLE]	= rateProtyMngRow[RATEPRIORITYORDER];		// 掛率優先順位
			guideRow[RATESETTINGDIVIDE_TITLE]	= rateProtyMngRow[RATESETTINGDIVIDE];		// 掛率設定区分
			
			// 掛率設定内容作成
			string wkStr = "";
			_stringBuilder.Remove(0, _stringBuilder.Length);

            string rateSettingDiveide = rateProtyMngRow[RATESETTINGDIVIDE].ToString().Trim();
            _stringBuilder.Append(rateProtyMngRow[RATEMNGCUSTNM]);
            _stringBuilder.Append(" + ");
            _stringBuilder.Append(rateProtyMngRow[RATEMNGGOODSNM]);
			wkStr = _stringBuilder.ToString();
			
			guideRow[RATESETTINGDIVIDENM_TITLE] = wkStr;									// 掛率設定内容
		}

		/// <summary>
		/// メモリ生成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 掛率優先管理設定アクセスクラスが保持するメモリを生成します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void MemoryCreate()
		{
			// 掛率優先管理設定マスタクラスStatic
			if ( _static_RateProtyMngTable == null)
			{
				_static_RateProtyMngTable = new Hashtable();
			}
		}

		/// <summary>
		/// 掛率優先管理設定ワーカークラス（List） ⇒ UIクラス変換処理
		/// </summary>
		/// <param name="rateProtyMngWorkList">掛率優先管理設定マスタワーカークラスのArrayList</param>
		/// <remarks>
		/// <br>Note       : 掛率優先管理設定マスタワーカークラスをUIのクラスに変換して、
		///					 Search用Staticメモリに保持します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void CopyToStaticFromWorker(List<RateProtyMngWork> rateProtyMngWorkList)
		{
			ArrayList rateProtyMngWorkArray = new ArrayList();
			rateProtyMngWorkArray.AddRange(rateProtyMngWorkList);

			CopyToStaticFromWorker(rateProtyMngWorkArray);
		}

		/// <summary>
		/// 掛率優先管理設定ワーカークラス（ArrayList） ⇒ UIクラス変換処理
		/// </summary>
		/// <param name="stockProcMoneyWorkList">掛率優先管理設定マスタワーカークラスのArrayList</param>
		/// <remarks>
		/// <br>Note       : 掛率優先管理設定ワーカークラスをUIのクラスに変換して、
		///					 Search用Staticメモリに保持します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void CopyToStaticFromWorker(ArrayList rateProtyMngWorkList)
		{
			string hashKey;
			foreach (RateProtyMngWork wkRateProtyMngWork in rateProtyMngWorkList)
			{
				RateProtyMng rateProtyMng = CopyToRateProtyMngFromRateProtyMngWork(wkRateProtyMngWork);

				// HashKey:拠点コード, 単価種類, 掛率設定区分
				hashKey = CreateHashKey(rateProtyMng);

				_static_RateProtyMngTable[hashKey] = rateProtyMng;
			}
		}

		/// <summary>
		/// HashTable用Key作成
		/// </summary>
		/// <param name="rateProtyMng">掛率優先管理設定クラス</param>
		/// <returns>Hash用Key</returns>
		/// <remarks>
		/// <br>Note       : 掛率優先管理設定クラスからハッシュテーブル用の
		///					 キーを作成します。</br>
		/// <br>Programer  : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private string CreateHashKey(RateProtyMng rateProtyMng)
		{
			return	rateProtyMng.SectionCode.ToString() +
					rateProtyMng.UnitPriceKind.ToString("d1") +
					rateProtyMng.RateSettingDivide.ToString();
		}

		#endregion

		#region Property
		/// <summary>第１テーブル（拠点テーブル）</summary>
		public DataTable DtFirstTable
		{
			get { return this._dataTableList.Tables[SECTION_TABLE]; }
		}
		/// <summary>第２テーブル（単価種類テーブル）</summary>
		public DataTable DtSecondTable
		{
			get { return this._dataTableList.Tables[UNITPRICEKIND_TABLE]; }
		}
		/// <summary>第３テーブル（掛率優先順位設定テーブル）</summary>
		public DataTable DtThirdTable
		{
			get { return this._dataTableList.Tables[RATEPROTYMNG_TABLE]; }
		}
        #endregion

        #region public member
        /// <summary>
        /// テーブル取得
        /// </summary>
        /// <param name="tableName">テーブル名</param>
        /// <returns>DataTable</returns>
        /// <remarks>
        /// <br>Note       : 指定されたテーブルのオブジェクトを返します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.12</br>
		/// </remarks>
        public DataTable GetTable(string tableName)
        {
            if (this._dataTableList.Tables.Contains(tableName))
            {
                return this._dataTableList.Tables[tableName];
            }
            return null;
        }
		
		#region Search 検索処理
		/// <summary>
		/// 検索処理（論理削除含まない）
		/// </summary>
		/// <param name="retArrayList">読込結果コレクション(ArrayList)</param>
		/// <param name="retTotalCnt">読込対象データ総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="sectionCode">拠点コード</param>		
		/// <param name="message">メッセージ</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 掛率優先管理の拠点単位の全検索処理を行います。論理削除データは抽出対象外</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		public int Search(out ArrayList retArrayList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, out string message)
		{
			DataSet dmyDataSet = null;	// データセットは使用しない

			// 検索
			int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, sectionCode, 0, out message);
			return status;
		}

		/// <summary>
		/// 検索処理（論理削除含まない）
		/// </summary>
		/// <param name="retList">読込結果コレクション(DataSet)</param>
		/// <param name="retTotalCnt">読込対象データ総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="sectionCode">拠点コード</param>		
		/// <param name="message">メッセージ</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 掛率優先管理の拠点単位の全検索処理を行います。論理削除データは抽出対象外</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		public int Search(out DataSet retList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, out string message)
		{
			ArrayList dmyArrayList = null;	// ArrayListは使用しない

			// 検索
			int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, sectionCode, 0, out message);
			return status;
		}
		#endregion Search

		#region SearchAll 検索処理
		/// <summary>
		/// 検索処理（論理削除含む）
		/// </summary>
		/// <param name="retArrayList">読込結果コレクション(ArrayList)</param>
		/// <param name="retTotalCnt">読込対象データ総件数</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <param name="sectionCode">拠点コード</param>		
		/// <param name="message">メッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 掛率優先管理の拠点単位の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		public int SearchAll(out ArrayList retArrayList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, out string message)
		{
			DataSet dmyDataSet = null;	// データセットは使用しない
			
			// 検索
			int status = SearchProc(out retArrayList, out dmyDataSet, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetDataAll, out message);
			return status;
		}
		
        /// <summary>
        /// 検索処理（論理削除含む）
        /// </summary>
		/// <param name="retList">読込結果コレクション(DataSet)</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="sectionCode">拠点コード</param>		
        /// <param name="message">メッセージ</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 掛率優先管理の拠点単位の全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
        public int SearchAll(out DataSet retList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, out string message)
        {
			ArrayList dmyArrayList = null;	// ArrayListは使用しない

            // 検索
			int status = SearchProc(out dmyArrayList, out retList, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetDataAll, out message);
            return status;
        }
		#endregion SearchAll
		
		/// <summary>
		/// 書き込み処理
		/// </summary>
		/// <param name="rateProtyMngArray">保存データ</param>
		/// <param name="message">メッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 書き込み処理を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.20</br>
		/// </remarks>
		public int Write(ref ArrayList rateProtyMngArray, out string message)
		{
			RateProtyMng rateProtyMng = new RateProtyMng();
			
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = "";

			try
			{
				// データ数分ループ
				ArrayList paraRateProtyMngWorkList = new ArrayList();
				RateProtyMngWork rateProtyMngWork = null;
				
				for (int i = 0; i < rateProtyMngArray.Count; i++)
				{
					// クラスデータをワーククラスデータに変換
					rateProtyMngWork = CopyToRateProtyMngWorkFromRateProtyMng((RateProtyMng)rateProtyMngArray[i]);
					
					paraRateProtyMngWorkList.Add(rateProtyMngWork);
				}
				
				object paraObj = (object)paraRateProtyMngWorkList;

				// 書き込み処理
				status = this._iRateProtyMngDB.Write(ref paraObj);
				
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 何かしらのエラー発生
					message = "登録に失敗しました。";
					return status;
				}
				
				DataRow dr;

				// 全社共通データ全削除（先に削除しないとデータ登録済チェックで存在してしまう）
				AllCmnDelete();

				// ワークデータをクラスデータに変換
				for(int i = 0; i < ((ArrayList)paraObj).Count; i++)
				{
					rateProtyMngWork = (RateProtyMngWork)((ArrayList)paraObj)[i];
					
					// クラス内メンバコピー
					rateProtyMng = CopyToRateProtyMngFromRateProtyMngWork(rateProtyMngWork);

					// Staticに更新
					_static_RateProtyMngTable[CreateHashKey(rateProtyMng)] = rateProtyMng;
					
					// データ登録済みチェック
					dr = this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows.Find(new object[] { rateProtyMngWork.SectionCode, rateProtyMngWork.UnitPriceKind, rateProtyMngWork.RateSettingDivide });
					if (dr == null)
					{
						// 未登録の場合はワークデータをDataRowに変換
						dr = CopyToDataRowFromRateProtyMngWork(ref rateProtyMngWork);
						
						// 未登録の場合はレコードを追加
						this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows.Add(dr);
					}
					else
					{
						// 登録済みの場合は更新
						dr[UPDATEDATETIME] = rateProtyMngWork.UpdateDateTime;
						dr[UPDEMPLOYEECODE] = rateProtyMngWork.UpdEmployeeCode;
						dr[UPDASSEMBLYID1] = rateProtyMngWork.UpdAssemblyId1;
						dr[UPDASSEMBLYID2] = rateProtyMngWork.UpdAssemblyId2;
						
						// 拠点コード
						dr[SECTIONCODE] = rateProtyMngWork.SectionCode;
						// 拠点名称
						dr[SECTIONNAME] = this.GetSectionNm(rateProtyMngWork.SectionCode);
						// 単価種類
						dr[UNITPRICEKIND] = rateProtyMngWork.UnitPriceKind;
						// 掛率設定区分
						dr[RATESETTINGDIVIDE] = rateProtyMngWork.RateSettingDivide;
						// 掛率優先順位
						dr[RATEPRIORITYORDER] = rateProtyMngWork.RatePriorityOrder;
						// 掛率設定区分（商品）
						dr[RATEMNGGOODSCD] = rateProtyMngWork.RateMngGoodsCd;
						// 掛率設定名称（商品）
						dr[RATEMNGGOODSNM] = rateProtyMngWork.RateMngGoodsNm;
						// 掛率設定区分（得意先）
						dr[RATEMNGCUSTCD] = rateProtyMngWork.RateMngCustCd;
						// 掛率設定名称（得意先）
						dr[RATEMNGCUSTNM] = rateProtyMngWork.RateMngCustNm;						
					}
				}

				// 使用区分設定
				UtilityDivSet();

				// 全社共通データ設定
				AllCmnDispSet();

				this._dataTableList.AcceptChanges();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				// オフライン時はnullをセット
				this._iRateProtyMngDB = null;
				// 通信エラー
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 削除処理
		/// </summary>
		/// <param name="deleteMode">削除モード（1:集計単位、2:明細項目）</param>
		/// <param name="rateProtyMngArray">削除データ</param>
		/// <param name="message">メッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 削除処理（物理削除）を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.20</br>
		/// </remarks>
		public int Delete(int deleteMode, ref ArrayList rateProtyMngArray, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = "";

			try
			{
				byte[] paraRateProtyMngWork = null;
				RateProtyMngWork rateProtyMngWork = null;
				ArrayList rateProtyMngWorkArray = new ArrayList();	// ワーククラス格納用ArrayList

				// ワーククラス格納用ArrayListへ詰め替え
				for (int i = 0; i < rateProtyMngArray.Count; i++)
				{
					// クラスデータをワーククラスデータに変換
					rateProtyMngWork = CopyToRateProtyMngWorkFromRateProtyMng((RateProtyMng)rateProtyMngArray[i]);
					rateProtyMngWorkArray.Add(rateProtyMngWork);
				}
				// ArrayListから配列を生成
				RateProtyMngWork[] rateProtyMngWorks = (RateProtyMngWork[])rateProtyMngWorkArray.ToArray(typeof(RateProtyMngWork));
				
				// シリアライズ
				paraRateProtyMngWork = XmlByteSerializer.Serialize(rateProtyMngWorks);

				// 削除処理
				status = this._iRateProtyMngDB.Delete(paraRateProtyMngWork);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 何かしらのエラー発生
					message = "削除に失敗しました。";
					return status;
				}

				// 全社共通データ全削除（先に削除しないとデータ登録済チェックで存在してしまう）
				AllCmnDelete();

				for(int i = 0; i < rateProtyMngArray.Count; i++)
				{
					// データ登録済みチェック
					DataRow dr = this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows.Find(new object[] { ((RateProtyMng)rateProtyMngArray[i]).SectionCode, ((RateProtyMng)rateProtyMngArray[i]).UnitPriceKind, ((RateProtyMng)rateProtyMngArray[i]).RateSettingDivide });
					if (dr != null)
					{
						// 物理削除したデータを削除
						this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows.Remove(dr);
					}

					// Staticに更新
					_static_RateProtyMngTable.Remove(CreateHashKey((RateProtyMng)rateProtyMngArray[i]));
				}

				// 使用区分設定
				UtilityDivSet();

				// 全社共通データ設定
				AllCmnDispSet();

				this._dataTableList.AcceptChanges();
				
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				message = ex.Message;
				// オフライン時はnullをセット
				this._iRateProtyMngDB = null;
				// 通信エラー
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}
        
        #endregion

        #region private member

        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
		/// <param name="ds">データセット</param>
		/// <remarks>
        /// <br>Note       : データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.17</br>
		/// </remarks>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
			//----------------------------------------------------------------
			// 拠点テーブル列定義
			//----------------------------------------------------------------
			DataTable sectionTable = new DataTable(SECTION_TABLE);

			// 拠点コード
			sectionTable.Columns.Add(SECTIONCODE, typeof(string));
			// 拠点名称
			sectionTable.Columns.Add(SECTIONNAME, typeof(string));

			sectionTable.PrimaryKey = new DataColumn[] { sectionTable.Columns[SECTIONCODE] };
			this._dataTableList.Tables.Add(sectionTable);


			//----------------------------------------------------------------
			// 単価種類テーブル列定義
			//----------------------------------------------------------------
			DataTable unitPriceKindTable = new DataTable(UNITPRICEKIND_TABLE);

			// 拠点コード
			unitPriceKindTable.Columns.Add(SECTIONCODE, typeof(string));
			// 拠点名称
			unitPriceKindTable.Columns.Add(SECTIONNAME, typeof(string));
			// 単価種類（コード）
			unitPriceKindTable.Columns.Add(UNITPRICEKIND, typeof(int));
			// 単価種類（名称）表示用
			unitPriceKindTable.Columns.Add(UNITPRICEKINDNM, typeof(string));
			// 使用区分
			unitPriceKindTable.Columns.Add(UTILITYDIV_TITLE, typeof(string));

			unitPriceKindTable.PrimaryKey = new DataColumn[] {
													unitPriceKindTable.Columns[SECTIONCODE], 
													unitPriceKindTable.Columns[UNITPRICEKIND] };
													this._dataTableList.Tables.Add(unitPriceKindTable);

			//----------------------------------------------------------------
			// 掛率優先順位設定テーブル列定義
			//----------------------------------------------------------------
			DataTable rateProtyMngTable = new DataTable(RATEPROTYMNG_TABLE);

			// 作成日時
			rateProtyMngTable.Columns.Add(CREATEDATETIME, typeof(DateTime));
			// 更新日時
			rateProtyMngTable.Columns.Add(UPDATEDATETIME, typeof(DateTime));
			// 企業コード
			rateProtyMngTable.Columns.Add(ENTERPRISECODE, typeof(string));
			// GUID
			rateProtyMngTable.Columns.Add(FILEHEADERGUID, typeof(Guid));
			// 更新従業員コード
			rateProtyMngTable.Columns.Add(UPDEMPLOYEECODE, typeof(string));
			// 更新アセンブリID1
			rateProtyMngTable.Columns.Add(UPDASSEMBLYID1, typeof(string));
			// 更新アセンブリID2
			rateProtyMngTable.Columns.Add(UPDASSEMBLYID2, typeof(string));
			// 論理削除区分
			rateProtyMngTable.Columns.Add(LOGICALDELETECODE, typeof(Int32));
			// 拠点コード
			rateProtyMngTable.Columns.Add(SECTIONCODE, typeof(string));
			// 拠点名称
			rateProtyMngTable.Columns.Add(SECTIONNAME, typeof(string));
			// 単価種類
			rateProtyMngTable.Columns.Add(UNITPRICEKIND, typeof(int));
			// 単価種類（名称）
			rateProtyMngTable.Columns.Add(UNITPRICEKINDNM, typeof(string));
			// 使用区分
			rateProtyMngTable.Columns.Add(UTILITYDIV_TITLE, typeof(string));
			// 掛率優先順位
			rateProtyMngTable.Columns.Add(RATEPRIORITYORDER, typeof(int));
			// 掛率設定区分
			rateProtyMngTable.Columns.Add(RATESETTINGDIVIDE, typeof(string));
			// 掛率設定区分（商品）
			rateProtyMngTable.Columns.Add(RATEMNGGOODSCD, typeof(string));
			// 掛率設定名称（商品）
			rateProtyMngTable.Columns.Add(RATEMNGGOODSNM, typeof(string));
			// 掛率設定区分（得意先）
			rateProtyMngTable.Columns.Add(RATEMNGCUSTCD, typeof(string));
			// 掛率設定名称（得意先）
			rateProtyMngTable.Columns.Add(RATEMNGCUSTNM, typeof(string));
			// 削除日
			rateProtyMngTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));

			rateProtyMngTable.PrimaryKey = new DataColumn[] { 
                                                rateProtyMngTable.Columns[SECTIONCODE],
                                                rateProtyMngTable.Columns[UNITPRICEKIND],
                                                rateProtyMngTable.Columns[RATESETTINGDIVIDE] };
			this._dataTableList.Tables.Add(rateProtyMngTable);
        }

        /// <summary>
		/// クラスメンバーコピー処理（掛率優先管理設定クラス⇒掛率優先管理設定ワーククラス）
        /// </summary>
		/// <param name="rateProtyMng">掛率優先管理設定クラス</param>
        /// <returns>RateProtyMngWork</returns>
        /// <remarks>
		/// <br>Note       : 掛率優先管理設定クラスから掛率優先管理設定ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.17</br>
		/// </remarks>
		private RateProtyMngWork CopyToRateProtyMngWorkFromRateProtyMng(RateProtyMng rateProtyMng)
        {
			RateProtyMngWork rateProtyMngWork = new RateProtyMngWork();

			// 作成日時
			rateProtyMngWork.CreateDateTime		= rateProtyMng.CreateDateTime;
			// 更新日時
			rateProtyMngWork.UpdateDateTime		= rateProtyMng.UpdateDateTime;
			//// 企業コード
			rateProtyMngWork.EnterpriseCode		= rateProtyMng.EnterpriseCode;
			// GUID
			rateProtyMngWork.FileHeaderGuid		= rateProtyMng.FileHeaderGuid;
			// 更新従業員コード
			rateProtyMngWork.UpdEmployeeCode	= rateProtyMng.UpdEmployeeCode;
			// 更新アセンブリID1
			rateProtyMngWork.UpdAssemblyId1		= rateProtyMng.UpdAssemblyId1;
			// 更新アセンブリID2
			rateProtyMngWork.UpdAssemblyId2		= rateProtyMng.UpdAssemblyId2;
            // 論理削除区分
            rateProtyMngWork.LogicalDeleteCode	= rateProtyMng.LogicalDeleteCode;
            // 拠点コード
            rateProtyMngWork.SectionCode		= rateProtyMng.SectionCode;
			// 単価種類
			rateProtyMngWork.UnitPriceKind		= rateProtyMng.UnitPriceKind;
			// 掛率設定区分
			rateProtyMngWork.RateSettingDivide	= rateProtyMng.RateSettingDivide;
			// 掛率優先順位
			rateProtyMngWork.RatePriorityOrder	= rateProtyMng.RatePriorityOrder;
			// 掛率設定区分（商品）
			rateProtyMngWork.RateMngGoodsCd		= rateProtyMng.RateMngGoodsCd;
			// 掛率設定名称（商品）
			rateProtyMngWork.RateMngGoodsNm		= rateProtyMng.RateMngGoodsNm;
			// 掛率設定区分（得意先）
			rateProtyMngWork.RateMngCustCd		= rateProtyMng.RateMngCustCd;
			// 掛率設定名称（得意先）
			rateProtyMngWork.RateMngCustNm		= rateProtyMng.RateMngCustNm;
			
            return rateProtyMngWork;
        }

        /// <summary>
		/// クラスメンバーコピー処理（掛率優先管理設定ワーククラス⇒掛率優先管理設定クラス）
        /// </summary>
		/// <param name="rateProtyMngWork">掛率優先管理設定ワーククラス</param>
        /// <returns>RateProtyMngWork</returns>
        /// <remarks>
		/// <br>Note       : 掛率優先管理設定ワーククラスから掛率優先管理設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.17</br>
		/// </remarks>
        private RateProtyMng CopyToRateProtyMngFromRateProtyMngWork(RateProtyMngWork rateProtyMngWork)
        {
            RateProtyMng rateProtyMng = new RateProtyMng();

            // 作成日時
            rateProtyMng.CreateDateTime		= rateProtyMngWork.CreateDateTime;
            // 更新日時
            rateProtyMng.UpdateDateTime		= rateProtyMngWork.UpdateDateTime;
            // 企業コード
            rateProtyMng.EnterpriseCode		= rateProtyMngWork.EnterpriseCode;
            // GUID
            rateProtyMng.FileHeaderGuid		= rateProtyMngWork.FileHeaderGuid;
            // 更新従業員コード
            rateProtyMng.UpdEmployeeCode	= rateProtyMngWork.UpdEmployeeCode;
            // 更新アセンブリID1
            rateProtyMng.UpdAssemblyId1		= rateProtyMngWork.UpdAssemblyId1;
            // 更新アセンブリID2
            rateProtyMng.UpdAssemblyId2		= rateProtyMngWork.UpdAssemblyId2;
            // 論理削除区分
            rateProtyMng.LogicalDeleteCode	= rateProtyMngWork.LogicalDeleteCode;
            // 拠点コード
            // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
            //rateProtyMng.SectionCode = rateProtyMngWork.SectionCode;
            rateProtyMng.SectionCode = rateProtyMngWork.SectionCode.Trim();
            // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<
			// 単価種類
			rateProtyMng.UnitPriceKind		= rateProtyMngWork.UnitPriceKind;
			// 掛率設定区分
			rateProtyMng.RateSettingDivide	= rateProtyMngWork.RateSettingDivide;
			// 掛率優先順位
			rateProtyMng.RatePriorityOrder	= rateProtyMngWork.RatePriorityOrder;
			// 掛率設定区分（商品）
			rateProtyMng.RateMngGoodsCd		= rateProtyMngWork.RateMngGoodsCd;
			// 掛率設定名称（商品）
			rateProtyMng.RateMngGoodsNm		= rateProtyMngWork.RateMngGoodsNm;
			// 掛率設定区分（得意先）
			rateProtyMng.RateMngCustCd		= rateProtyMngWork.RateMngCustCd;
			// 掛率設定名称（得意先）
			rateProtyMng.RateMngCustNm		= rateProtyMngWork.RateMngCustNm;
			
            return rateProtyMng;
        }

        /// <summary>
		/// クラスメンバーコピー処理（掛率優先管理設定クラス⇒DataRow）
        /// </summary>
		/// <param name="rateProtyMngWork">掛率優先管理設定ワーククラス</param>
        /// <returns>DataRow</returns>
        /// <remarks>
		/// <br>Note       : 掛率優先管理設定ワーククラスから掛率優先管理設定クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.17</br>
		/// </remarks>
        private DataRow CopyToDataRowFromRateProtyMngWork(ref RateProtyMngWork rateProtyMngWork)
        {
			RateProtyMng rateProtyMng = this.CopyToRateProtyMngFromRateProtyMngWork(rateProtyMngWork);

			DataRow dr = null;

			dr = this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows.Find(new object[] {rateProtyMng.SectionCode, rateProtyMng.UnitPriceKind, rateProtyMng.RateSettingDivide});

			if (dr == null)
			{
				dr = this._dataTableList.Tables[RATEPROTYMNG_TABLE].NewRow();
			}
			
			// 作成日時
			dr[CREATEDATETIME] = rateProtyMng.CreateDateTime;
			// 更新日時
			dr[UPDATEDATETIME] = rateProtyMng.UpdateDateTime;
			// 企業コード
			dr[ENTERPRISECODE] = rateProtyMng.EnterpriseCode;
			
			if (rateProtyMng.FileHeaderGuid == Guid.Empty)
			{
				// GUID
				dr[FILEHEADERGUID] = Guid.NewGuid();
			}
			else
			{
				// GUID
				dr[FILEHEADERGUID] = rateProtyMng.FileHeaderGuid;
			}
			// 更新従業員コード
			dr[UPDEMPLOYEECODE] = rateProtyMng.UpdEmployeeCode;
			// 更新アセンブリID1
			dr[UPDASSEMBLYID1] = rateProtyMng.UpdAssemblyId1;
			// 更新アセンブリID2
			dr[UPDASSEMBLYID2] = rateProtyMng.UpdAssemblyId2;
			// 論理削除区分
			dr[LOGICALDELETECODE] = rateProtyMng.LogicalDeleteCode;
			// 拠点コード
			dr[SECTIONCODE] = rateProtyMng.SectionCode;
			// 拠点名称
			dr[SECTIONNAME] = this.GetSectionNm(rateProtyMng.SectionCode);
			// 単価種類
			dr[UNITPRICEKIND] = rateProtyMng.UnitPriceKind;
			// 掛率設定区分
			dr[RATESETTINGDIVIDE] = rateProtyMng.RateSettingDivide;
			// 掛率優先順位
			dr[RATEPRIORITYORDER] = rateProtyMng.RatePriorityOrder;
			// 掛率設定区分（商品）
			dr[RATEMNGGOODSCD] = rateProtyMng.RateMngGoodsCd.Trim();
			// 掛率設定名称（商品）
			dr[RATEMNGGOODSNM] = rateProtyMng.RateMngGoodsNm;
			// 掛率設定区分（得意先）
			dr[RATEMNGCUSTCD] = rateProtyMng.RateMngCustCd.Trim();
			// 掛率設定名称（得意先）
			dr[RATEMNGCUSTNM] = rateProtyMng.RateMngCustNm;
			
			// 削除日
			if (rateProtyMng.LogicalDeleteCode == 0)
			{
				dr[DELETE_DATE_TITLE] = "";
			}
			else
			{
				dr[DELETE_DATE_TITLE] = rateProtyMng.UpdateDateTimeJpInFormal;
			}
			
			//----------------------------
			// ガイド用に掛率設定関連保存
			//----------------------------
			if (_static_rateProtyMngSortedListGuide.ContainsKey(rateProtyMng.RateSettingDivide) == false)
			{
				_static_rateProtyMngSortedListGuide.Add(rateProtyMng.RateSettingDivide, dr);
			}
			
			return dr;
		}

        /// <summary>
        /// 検索処理メイン（論理削除含む）
        /// </summary>
		/// <param name="retArrayList">読込結果コレクション(ArrayList)</param>
		/// <param name="retList">読込結果コレクション(DataSet)</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.12</br>
		/// </remarks>
		private int SearchProc(out ArrayList retArrayList
								,out DataSet   retList
								,out int       retTotalCnt
								,out bool      nextData
								,string    enterpriseCode
								,string    sectionCode
								,ConstantManagement.LogicalMode logicalMode
								,out string    message)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			retList = null;
			retTotalCnt = 0;
			nextData    = false;
			message     = "";

			retArrayList = new ArrayList();

			//各テーブル行クリア
			this._dataTableList.Tables[SECTION_TABLE].Rows.Clear();
			this._dataTableList.Tables[UNITPRICEKIND_TABLE].Rows.Clear();
			this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows.Clear();

			// 拠点コードソートリスト初期化
			RateProtyMng._sectionCodeTable = new SortedList();

			try
			{
                // 2009.08.11 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // -- UPD 2010/05/25 ----------------------->>>
                //if (LoginInfoAcquisition.OnlineFlag)
                if (LoginInfoAcquisition.Employee != null && !string.IsNullOrEmpty(LoginInfoAcquisition.Employee.BelongSectionCode))
                // -- UPD 2010/05/25 -----------------------<<<
                {
                    //==========================================
                    // 拠点マスタ読み込み
                    //==========================================
                    //----- ueno add ---------- start 2008.01.31
                    // ローカルＤＢ拠点対応
                    ConstructSecInfoAcs();
                    //----- ueno add ---------- end 2008.01.31

                    if (this._secInfoAcs.SecInfoSetList.Length > 0)
                    {
                        foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                        {
                            AddRowFromSection(secInfoSet);
                        }
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    //==========================================
                    // 単価種類データ読み込み
                    //==========================================
                    AddRowFromUnitPriceKind();
                }
                // 2009.08.11 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				//==========================================
				// 掛率優先管理マスタ読み込み
				//==========================================
				// 抽出条件パラメータ
				RateProtyMngWork paraWork = new RateProtyMngWork();
				paraWork.EnterpriseCode = enterpriseCode;
				
				ArrayList paraList = new ArrayList();
				paraList.Add(paraWork);

				// リモート戻りリスト
				object rateProtyMngWorkList = null;

                // 2009.08.11 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// オフラインの場合はキャッシュから読む
                //if (LoginInfoAcquisition.OnlineFlag == false)
                //{
                //    status = SearchStaticMemory(out retArrayList, enterpriseCode, sectionCode);
					
                //    // 一度ワーククラスへ変更する
                //    ArrayList retArrayListWorkList = new ArrayList();
                //    foreach (RateProtyMng rateProtyMng in (ArrayList)retArrayList)
                //    {
                //        retArrayListWorkList.Add(CopyToRateProtyMngWorkFromRateProtyMng(rateProtyMng));
                //    }
					
                //    // データテーブルにセット
                //    foreach (RateProtyMngWork rateProtyMngWork in (ArrayList)retArrayListWorkList)
                //    {
                //        AddRowFromRateProtyMngWork(rateProtyMngWork);
                //    }
                //}
                //else
                //{
                //    /* --- DEL 2008/06/16 --------------------------------------------------------------------->>>>>
                //    //----- ueno upd ---------- start 2008.01.31	
                //    _isLocalDBRead = false;
                //    //ローカル
                //    if (_isLocalDBRead)
                //    {
                //        List<RateProtyMngWork> wkRateProtyMngWorkList = new List<RateProtyMngWork>();
                //        status = this._rateProtyMngLcDB.Search(out wkRateProtyMngWorkList, paraWork, 0, logicalMode);
						
                //        if(status == 0)
                //        {
                //            ArrayList al = new ArrayList();
                //            al.AddRange(wkRateProtyMngWorkList);
                //            rateProtyMngWorkList = (object)al;
                //        }
                //    }
                //    //リモート
                //    else
                //    {
                //        // 掛率優先管理マスタ検索
                //        status = this._iRateProtyMngDB.Search(out rateProtyMngWorkList, paraList, 0, logicalMode);
                //    }
                //    //----- ueno upd ---------- end 2008.01.31
                //       --- DEL 2008/06/16 ---------------------------------------------------------------------<<<<<*/

                //    // --- ADD 2008/06/16 --------------------------------------------------------------------->>>>>
                //    // 掛率優先管理マスタ検索
                //    status = this._iRateProtyMngDB.Search(out rateProtyMngWorkList, paraList, 0, logicalMode);
                //    // --- ADD 2008/06/16 ---------------------------------------------------------------------<<<<<

                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        // 掛率優先管理設定マスタワーカークラス⇒UIクラスStatic転記処理
                //        CopyToStaticFromWorker(rateProtyMngWorkList as ArrayList);

                //        // データテーブルにセット
                //        foreach (RateProtyMngWork rateProtyMngWork in (ArrayList)rateProtyMngWorkList)
                //        {
                //            AddRowFromRateProtyMngWork(rateProtyMngWork);

                //            // ArrayListへ格納
                //            retArrayList.Add(CopyToRateProtyMngFromRateProtyMngWork(rateProtyMngWork));
                //        }

                //        // SearchFlg ON
                //        _searchFlg = true;
                //    }
                //}

                // 掛率優先管理マスタ検索
                status = this._iRateProtyMngDB.Search(out rateProtyMngWorkList, paraList, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 掛率優先管理設定マスタワーカークラス⇒UIクラスStatic転記処理
                    CopyToStaticFromWorker(rateProtyMngWorkList as ArrayList);

                    // データテーブルにセット
                    foreach (RateProtyMngWork rateProtyMngWork in (ArrayList)rateProtyMngWorkList)
                    {
                        AddRowFromRateProtyMngWork(rateProtyMngWork);

                        // ArrayListへ格納
                        retArrayList.Add(CopyToRateProtyMngFromRateProtyMngWork(rateProtyMngWork));
                    }

                    // SearchFlg ON
                    _searchFlg = true;
                }
                // 2009.08.11 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				//=============================================
				// 使用区分設定（掛率優先管理未設定時使用）
				//=============================================
				UtilityDivSet();

                if (_comonShowFlg)
                {
                    //===================================================
                    // 拠点データが無い場合、全社共通データを設定する
                    //  	※ガイドでも使用する
                    //===================================================
                    AllCmnDispSet();
                }
				
				//==========================================
				// データセットを返す
				//==========================================
				retList = this._dataTableList;
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return status;
        }

		/// <summary>
		/// 検索処理メイン（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション(DataSet)</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 検索処理を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private int Search(	 out DataSet retList
							,string enterpriseCode
							,string sectionCode
							,out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			ArrayList retArrayList = new ArrayList();
			retList = null;
			message = "";

			try
			{
				// オンライン且つ、Searchが行われていない場合（オフラインの場合はコンストラクタでStatic展開済み）
                //if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag)) // 2009.08.11
                if (!_searchFlg) // 2009.08.11
                {
					int retTotalCnt;
					bool nextData;
					status = SearchAll(out retList, out retTotalCnt, out nextData, enterpriseCode, sectionCode, out message);
				}
				else
				{
					//==========================================
					// 拠点マスタ読み込み
					//==========================================
					//----- ueno add ---------- start 2008.01.31
					// ローカルＤＢ拠点対応
					ConstructSecInfoAcs();
					//----- ueno add ---------- end 2008.01.31

					if (this._secInfoAcs.SecInfoSetList.Length > 0)
					{
					    foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
					    {
					        AddRowFromSection(secInfoSet);
						}
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}

					//==========================================
					// 単価種類データ読み込み
					//==========================================
					AddRowFromUnitPriceKind();
					
					//==========================================
					// 掛率優先管理をキャッシュから読み込み
					//==========================================
					status = SearchStaticMemory(out retArrayList, enterpriseCode, sectionCode);

					// 一度ワーククラスへ変更する
					ArrayList retArrayListWorkList = new ArrayList();
					foreach (RateProtyMng rateProtyMng in (ArrayList)retArrayList)
					{
						retArrayListWorkList.Add(CopyToRateProtyMngWorkFromRateProtyMng(rateProtyMng));
					}

					// データテーブルにセット
					foreach (RateProtyMngWork rateProtyMngWork in (ArrayList)retArrayListWorkList)
					{
						AddRowFromRateProtyMngWork(rateProtyMngWork);
					}

					//=============================================
					// 使用区分設定（掛率優先管理未設定時使用）
					//=============================================
					UtilityDivSet();

                    if (_comonShowFlg)
                    {
                        //===================================================
                        // 拠点データが無い場合、全社共通データを設定する
                        //  	※ガイドでも使用する
                        //===================================================
                        AllCmnDispSet();
                    }
				}
				//==========================================
				// データセットを返す
				//==========================================
				retList = this._dataTableList;
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return status;
		}

		/// <summary>
		/// 掛率優先順位マスタ　→　データテーブル　追加処理
		/// </summary>
		/// <param name="rateProtyMngWork">掛率優先管理設定ワーククラス</param>
		/// <remarks>
		/// <br>Note       : 掛率優先順位マスタのデータをデータテーブルに追加します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void AddRowFromRateProtyMngWork(RateProtyMngWork rateProtyMngWork)
		{
			DataRow dr;
			try
			{
				// 第１グリッド（拠点）
				if (this._dataTableList.Tables[SECTION_TABLE].Rows.Find(rateProtyMngWork.SectionCode) == null)
				{
					dr = this._dataTableList.Tables[SECTION_TABLE].NewRow();
					dr[SECTIONCODE] = rateProtyMngWork.SectionCode;
					dr[SECTIONNAME] = this.GetSectionNm(rateProtyMngWork.SectionCode);
					this._dataTableList.Tables[SECTION_TABLE].Rows.Add(dr);
				}
				
				// 第２グリッド（単価種類）
				if (this._dataTableList.Tables[UNITPRICEKIND_TABLE].Rows.Find(new object[] { rateProtyMngWork.SectionCode, rateProtyMngWork.UnitPriceKind }) == null)
				{
					dr = this._dataTableList.Tables[UNITPRICEKIND_TABLE].NewRow();
					dr[SECTIONCODE]			= rateProtyMngWork.SectionCode;
					dr[SECTIONNAME]			= this.GetSectionNm(rateProtyMngWork.SectionCode);
					dr[UNITPRICEKIND]		= rateProtyMngWork.UnitPriceKind;
					dr[UNITPRICEKINDNM]		= RateProtyMng.GetUnitPriceKindNm(rateProtyMngWork.UnitPriceKind);
					dr[UTILITYDIV_TITLE]	= ALL_UTILITYDIV;	// 拠点設定
					this._dataTableList.Tables[UNITPRICEKIND_TABLE].Rows.Add(dr);
				}
				
				// 第３グリッド（掛率優先順位設定）
				if (this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows.Find(new object[] { rateProtyMngWork.SectionCode, rateProtyMngWork.UnitPriceKind, rateProtyMngWork.RateSettingDivide }) == null)
				{
					dr = CopyToDataRowFromRateProtyMngWork(ref rateProtyMngWork);
					this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows.Add(dr);
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// 単価種類データ　→　データテーブル　追加処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 単価種類データをデータテーブルに追加します</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.26</br>
		/// </remarks>
		private void AddRowFromUnitPriceKind()
		{
			DataRow dr;
			
			try
			{
				// 拠点コード数分作成
				foreach (DictionaryEntry sectionCodeDc in RateProtyMng._sectionCodeTable)
				{
					// 単価種類分作成
					foreach (DictionaryEntry unitPriceKindDc in RateProtyMng._unitPriceKindTable)
					{
						if (this._dataTableList.Tables[UNITPRICEKIND_TABLE].Rows.Find(new object[] { sectionCodeDc.Key.ToString(), (Int32)unitPriceKindDc.Key }) == null)
						{
							// 第２グリッド（単価種類）
							dr = this._dataTableList.Tables[UNITPRICEKIND_TABLE].NewRow();
							dr[SECTIONCODE] = sectionCodeDc.Key.ToString();
							dr[SECTIONNAME] = sectionCodeDc.Value.ToString();
							dr[UNITPRICEKIND] = (Int32)unitPriceKindDc.Key;
							dr[UNITPRICEKINDNM] = RateProtyMng.GetUnitPriceKindNm((Int32)unitPriceKindDc.Key);
							dr[UTILITYDIV_TITLE] = ALL_UTILITYDIV;
							this._dataTableList.Tables[UNITPRICEKIND_TABLE].Rows.Add(dr);
						}
					}
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// 拠点マスタ　→　データテーブル追加処理
		/// </summary>
		/// <param name="secInfoSet">拠点オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 拠点マスタのデータをデータテーブルに追加します</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		private void AddRowFromSection(SecInfoSet secInfoSet)
		{
			DataRow dr;

			try
			{
				// 全社共通設定
				if (allSectionFlag == false)
				{
					allSectionFlag = true;

					// 第１グリッド（拠点）
					if (this._dataTableList.Tables[SECTION_TABLE].Rows.Find(ALL_SECTION_CODE) == null)
					{
						dr = this._dataTableList.Tables[SECTION_TABLE].NewRow();
						dr[SECTIONCODE] = ALL_SECTION_CODE;
						dr[SECTIONNAME] = ALL_SECTION_NAME;

						this._dataTableList.Tables[SECTION_TABLE].Rows.Add(dr);

						// 拠点コードと名称を保存
						if (RateProtyMng._sectionCodeTable.ContainsKey(ALL_SECTION_CODE) == false)
						{
							RateProtyMng._sectionCodeTable.Add(ALL_SECTION_CODE, ALL_SECTION_NAME);
						}
					}
				}
				
				// 第１グリッド（拠点）
				if (this._dataTableList.Tables[SECTION_TABLE].Rows.Find(secInfoSet.SectionCode) == null)
				{
					dr = this._dataTableList.Tables[SECTION_TABLE].NewRow();
					dr[SECTIONCODE] = secInfoSet.SectionCode;
					dr[SECTIONNAME] = secInfoSet.SectionGuideNm;
					
					this._dataTableList.Tables[SECTION_TABLE].Rows.Add(dr);

					// 拠点コードと名称を保存
					if (RateProtyMng._sectionCodeTable.ContainsKey(secInfoSet.SectionCode) == false)
					{
						RateProtyMng._sectionCodeTable.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideNm);
					}
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// 使用区分設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用区分を設定します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.26</br>
		/// </remarks>
		private void UtilityDivSet()
		{
			// 第２グリッド使用区分を全社共通に設定
			foreach(DataRow dr in this._dataTableList.Tables[UNITPRICEKIND_TABLE].Rows)
			{
				dr[UTILITYDIV_TITLE] = ALL_UTILITYDIV;
			}

			// 第３グリッド使用区分を全社共通に設定
			foreach (DataRow dr in this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows)
			{
				dr[UTILITYDIV_TITLE] = ALL_UTILITYDIV;
			}
			
			// 拠点コード数分
			foreach (DictionaryEntry sectionCodeDc in RateProtyMng._sectionCodeTable)
			{
				// 拠点コード「000000」は全社共通なので処理しない
				if (string.Equals(sectionCodeDc.Key.ToString(), ALL_SECTION_CODE) == true)
				{
					continue;
				}
				
				// 単価種類分
				foreach (DictionaryEntry unitPriceKindDc in RateProtyMng._unitPriceKindTable)
				{
					// 第３データテーブル検索
					DataRow[] foundRow = ThirdDataTableSearch(sectionCodeDc.Key.ToString(), unitPriceKindDc.Key.ToString());
					
					// 第３グリッド有り
					foreach (DataRow fRow in foundRow)
					{
						// 第３グリッド
						fRow[UTILITYDIV_TITLE] = SEC_UTILITYDIV;

						DataRow foundRowSecond = this._dataTableList.Tables[UNITPRICEKIND_TABLE].Rows.Find(new object[] { sectionCodeDc.Key.ToString(), unitPriceKindDc.Key.ToString() });
						
						//第２グリッド
						if (foundRowSecond != null)
						{
							foundRowSecond[UTILITYDIV_TITLE] = SEC_UTILITYDIV;
						}
					}
				}
			}
		}

		/// <summary>
		/// 全社共通データ表示設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 全社共通データ表示を設定します。（拠点未設定時対応）</br>
		/// <br>			 この処理は必ずUtilityDivSet()のあとに行う必要があります。</br>
		/// <br>			 （第２グリッドの「全社共通」、「拠点利用」文言を使用するため）</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void AllCmnDispSet()
		{
			// 拠点数分
			foreach (DictionaryEntry sectionCodeDc in RateProtyMng._sectionCodeTable)
			{
				// 拠点コード「000000」は全社共通なので処理しない
				if (string.Equals(sectionCodeDc.Key.ToString(), ALL_SECTION_CODE) == true)
				{
					continue;
				}
				
				// 単価種類分
				foreach (DictionaryEntry unitPriceKindDc in RateProtyMng._unitPriceKindTable)
				{
					DataRow foundRowSecond = this._dataTableList.Tables[UNITPRICEKIND_TABLE].Rows.Find(new object[] { sectionCodeDc.Key.ToString(), unitPriceKindDc.Key.ToString() });
					
					if(foundRowSecond != null)
					{
						// 全社共通の場合
						if (foundRowSecond[UTILITYDIV_TITLE].ToString() == ALL_UTILITYDIV)
						{
							// 第３データテーブル検索
							DataRow[] foundRow = ThirdDataTableSearch(ALL_SECTION_CODE, unitPriceKindDc.Key.ToString());
							
							// 存在すれば弟３グリッドに設定
							foreach (DataRow fRow in foundRow)
							{
								DataRow dr = this._dataTableList.Tables[RATEPROTYMNG_TABLE].NewRow();

								// アイテムコピー
								for (int i = 0; i < dr.ItemArray.Length; i++)
								{
									// 拠点コードは各拠点コードを設定する
									if (string.Equals(fRow[i].ToString(), ALL_SECTION_CODE) == true)
									{
										dr[i] = sectionCodeDc.Key.ToString();
									}
									else
									{
										dr[i] = fRow[i];
									}
								}
                                this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows.Add(dr);
							}
						}
					}			
				}
			}
		}

		/// <summary>
		/// 全社共通データ削除処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データビュー表示用の全社共通データを削除します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private void AllCmnDelete()
		{
			string wkStr = "";
			_stringBuilder.Remove(0, _stringBuilder.Length);
			_stringBuilder.Append(SECTIONCODE);
			_stringBuilder.Append(" <> '");
			_stringBuilder.Append(ALL_SECTION_CODE);
			_stringBuilder.Append("' and ");
			_stringBuilder.Append(UTILITYDIV_TITLE);
			_stringBuilder.Append(" = '");
			_stringBuilder.Append(ALL_UTILITYDIV);
			_stringBuilder.Append("'");
			
			wkStr = _stringBuilder.ToString();
			
			// 拠点コード「000000」以外で全社共通のデータを検索
			DataRow[] foundRowThird = this._dataTableList.Tables[RATEPROTYMNG_TABLE].Select(wkStr);
			
			// 第３グリッドの全社共通データを削除する
			foreach (DataRow fRowThird in foundRowThird)
			{
				this._dataTableList.Tables[RATEPROTYMNG_TABLE].Rows.Remove(fRowThird);
			}
		}

		/// <summary>
		/// 第３データテーブル検索処理
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="unitPriceKind">単価種類</param>
		/// <remarks>
		/// <returns>検索結果</returns>
		/// <br>Note       : 条件に該当する第３データテーブルロウを取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.25</br>
		/// </remarks>
		private DataRow[] ThirdDataTableSearch(string sectionCode, string unitPriceKind)
		{
			string wkStr = "";
			_stringBuilder.Remove(0, _stringBuilder.Length);
			_stringBuilder.Append(SECTIONCODE);
			_stringBuilder.Append(" = '");
			_stringBuilder.Append(sectionCode);
			_stringBuilder.Append("' and ");
			_stringBuilder.Append(UNITPRICEKIND);
			_stringBuilder.Append(" = '");
			_stringBuilder.Append(unitPriceKind);
			_stringBuilder.Append("'");
			wkStr = _stringBuilder.ToString();
			
			DataRow[] foundRow = this._dataTableList.Tables[RATEPROTYMNG_TABLE].Select(wkStr);
			
			return foundRow;
		}

		/// <summary>
		/// 拠点名称取得処理
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <remarks>
		/// <br>Note       : 拠点コードから拠点名称を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.09.26</br>
		/// </remarks>
		private string GetSectionNm(string sectionCode)
		{
			string retStr = "";

			if (RateProtyMng._sectionCodeTable.ContainsKey((object)sectionCode))
			{
				retStr = RateProtyMng._sectionCodeTable[sectionCode].ToString();
			}
			return retStr;
		}

		/// <summary>
		/// 掛率設定情報取得処理
		/// </summary>
		/// <param name="rateSettingDivide">掛率設定区分</param>
		/// <remarks>
		/// <br>Note       : 掛率設定区分から掛率設定情報を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.29</br>
		/// </remarks>
		private DataRow GetRateSettingDivideInfo(string rateSettingDivide)
		{
			DataRow dr = null;

			if (_static_rateProtyMngSortedListGuide.ContainsKey(rateSettingDivide) == true)
			{
				dr = (DataRow)_static_rateProtyMngSortedListGuide[rateSettingDivide];
			}
			return dr;
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// ローカルＤＢ対応拠点情報クラス作成処理
		/// </summary>
		/// <returns>Boolean</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報クラス作成を未作成時に作成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		private Boolean ConstructSecInfoAcs()
		{
			if (this._secInfoAcs == null)
			{
                // --- CHG 2008/06/16 --------------------------------------------------------------------->>>>>
                //this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
                this._secInfoAcs = new SecInfoAcs();
                // --- CHG 2008/06/16 ---------------------------------------------------------------------<<<<<
				if (this._secInfoAcs != null)
				{
					return true;
				}
			}
			return false;
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// NULL文字変換処理
		/// </summary>
		/// <param name="obj">オブジェクト</param>
		/// <returns>string型データ</returns>
		/// <remarks>
		/// <br>Note       : NULL文字が含まれている場合ダブルクォートへ変換する</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.29</br>
		/// </remarks>
		private string NullChgStr(object obj)
		{
			string ret;
			try
			{
				if (obj == null)
				{
					ret = "";
				}
				else
				{
					ret = obj.ToString();
				}
			}
			catch
			{
				ret = "";
			}
			return ret;
		}

		/// <summary>
		/// NULL文字変換処理
		/// </summary>
		/// <param name="obj">オブジェクト</param>
		/// <returns>int型データ</returns>
		/// <remarks>
		/// <br>Note       : NULL文字が含まれている場合「0」へ変換する</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.29</br>
		/// </remarks>
		private int NullChgInt(object obj)
		{
			int ret;
			try
			{
				if ((obj == null) || (string.Equals(obj.ToString(), "") == true))
				{
					ret = 0;
				}
				else
				{
					ret = Convert.ToInt32(obj);
				}
			}
			catch
			{
				ret = 0;
			}
			return ret;
		}

		#endregion
    }
}

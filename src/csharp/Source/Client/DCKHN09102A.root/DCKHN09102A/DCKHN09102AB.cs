using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// 掛率設定管理マスタアクセスクラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : 掛率設定管理マスタのアクセス制御を行います。</br>
	/// <br>Programmer : 30167 上野　弘貴</br>
	/// <br>Date       : 2007.09.12</br>
	/// <br>Update Note: 2008.01.31 30167 上野　弘貴</br>
	/// <br>			 ローカルＤＢ対応</br>
	/// <br>Update Note: 2008.02.27 30167 上野　弘貴</br>
	/// <br>			 ローカルＤＢ対応（提供データ読込をローカル固定に修正）</br>
    /// <br>Update Note: 2008/10/20       照田　貴志</br>
    /// <br>			 バグ修正、仕様変更対応</br>
    /// </remarks>
	public class RateMngGoodsCust
	{
		// テーブル名
		/// <summary>掛率優先マスタ（提供）</summary>
		public const string RATEMNGGOODSCUST_TABLE = "RateMngGoodsCustTable";

		/// <summary>掛率優先マスタ保存用</summary>
		public const string RATEMNGGOODSCUST_SAVE_TABLE = "RateMngGoodsCustSaveTable";
		
		// データテーブル項目名
		/// <summary>作成日付</summary>
		public const string CREATEDATETIME = "CreateDateTime";
		/// <summary>更新日付</summary>
		public const string UPDATEDATETIME = "UpdateDateTime";
		/// <summary>拠点コード</summary>
		public const string SECTIONCODE	= "SectionCode";
		/// <summary>単価種類</summary>
		public const string UNITPRICEKIND = "UnitPriceKind";
		/// <summary>掛率優先順位</summary>
        public const string RATEPRIORITYORDER = "RatePriorityOrder";
        /// <summary>掛率設定区分</summary>
		public const string RATESETTINGDIVIDE = "RateSettingDivide";
		/// <summary>掛率設定区分（商品）</summary>
		public const string RATEMNGGOODSCD = "RateMngGoodsCD";
		/// <summary>掛率設定名称（商品）</summary>
		public const string RATEMNGGOODSNM = "RateMngGoodsNM";
		/// <summary>掛率設定区分（得意先）</summary>
		public const string RATEMNGCUSTCD = "RateMngCustCD";
		/// <summary>掛率設定名称（得意先）</summary>
		public const string RATEMNGCUSTNM = "RateMngCustNM";
		/// <summary>選択フラグ</summary>
		public const string SELECT_FLAG = "SelectFlag";
		/// <summary>選択（グリッド表示用）</summary>
		public const string SELECT = "選択";
		/// <summary>結合掛率設定区分（グリッド表示用）</summary>
		public const string RATEMNGALLNM = "掛率設定区分";
		/// <summary>確定グリッド有無フラグ（0:無し, 1:有り）</summary>
		public const string DATAEXIST_FLAG = "DataExistFlag";
		/// <summary>非表示フラグ（0:表示, 1:非表示）</summary>
		public const string HIDDEN_FLAG = "HiddenFlag";
		/// <summary>GUID</summary>
		public const string FILEHEADERGUID = "FileHeaderGuid";
		
		# region Private Member

		//----- ueno del ---------- start 2008.02.27
		///// <summary>リモートオブジェクト格納バッファ</summary>
		//private	IRateMngGoodsDB _iRateMngGoodsDB = null;
		//private IRateMngCustDB _iRateMngCustDB = null;
		//----- ueno del ---------- end 2008.02.27

		//----- ueno add ---------- start 2008.01.31
		private RateMngGoodsLcDB _rateMngGoodsLcDB = null;
		private RateMngCustLcDB _rateMngCustLcDB = null;

		private static bool _isLocalDBRead = false;	// デフォルトはリモート
		//----- ueno add ---------- end 2008.01.31

		// 掛率設定管理マスタ（商品・得意先）情報格納用
		private DataTable _dateTableList = null;
		
		// 掛率優先管理マスタ確定情報格納用
		private DataTable _dateTableSaveList = null;
		
		// 掛率設定管理マスタリスト編集用
		private StringBuilder _stringBuilder = null;

		// UIグリッド用HashTable
		private Hashtable _gridHashTable = null;
				
		# endregion

		/// <summary>
		/// 掛率設定管理マスタアクセスクラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 掛率設定管理マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.12</br>
		/// </remarks>
		public RateMngGoodsCust()
		{
			//----- ueno del ---------- start 2008.02.27
			//try
			//{
			//    // リモートオブジェクト取得
			//    this._iRateMngGoodsDB = (IRateMngGoodsDB)MediationRateMngGoodsDB.GetRateMngGoodsDB();
			//    this._iRateMngCustDB = (IRateMngCustDB)MediationRateMngCustDB.GetRateMngCustDB();
			//}
			//catch (Exception)
			//{
			//    // オフライン時はnullをセット
			//    this._iRateMngGoodsDB = null;
			//    this._iRateMngCustDB = null;
			//}
			//----- ueno del ---------- end 2008.02.27

			//----- ueno add ---------- start 2008.01.31
			// ローカルDBアクセスオブジェクト取得
			this._rateMngGoodsLcDB = new RateMngGoodsLcDB();
			this._rateMngCustLcDB = new RateMngCustLcDB();
			//----- ueno add ---------- end 2008.01.31

			// データセット列情報構築処理
			this._dateTableList = new DataTable();
			DataTableColumnConstruction(ref this._dateTableList);

			this._dateTableSaveList = new DataTable();
			DataTableColumnConstruction(ref this._dateTableSaveList);
			
			// 文字列編集用
			_stringBuilder = new StringBuilder();
			
			// HashTable
			_gridHashTable = new Hashtable();
		}

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

		/// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online
		}

		//----- ueno del ---------- start 2008.02.27
		///// <summary>
		///// オンラインモード取得処理
		///// </summary>
		///// <returns>OnlineMode</returns>
		///// <remarks>
		///// <br>Note       : オンラインモードを取得します。</br>
		///// <br>Programmer : 30167 上野 弘貴</br>
		///// <br>Date       : 2007.09.12</br>
		///// </remarks>
		//public int GetOnlineMode()
		//{
		//    if (this._iRateMngGoodsDB == null)
		//    {
		//        return (int)ConstantManagement.OnlineMode.Offline;
		//    }
		//    else
		//    {
		//        return (int)ConstantManagement.OnlineMode.Online;
		//    }
		//}
		//----- ueno del ---------- end 2008.02.27

        /// <summary>
        /// 検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="sectionCode">拠点コード</param>		
        /// <param name="message">メッセージ</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.12</br>
        /// </remarks>
        public int SearchAll(out DataTable retList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, out string message)
        {
            // 検索
            int status = 0;
			status = SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetDataAll, out message);
            return status;
        }

		/// <summary>
		/// 確定グリッド用データテーブルメモリ取得処理
		/// </summary>
		/// <param name="retDataTable">確定グリッド用データテーブル</param>		
		/// <remarks>
		/// <br>Note       : 確定グリッド用データテーブルメモリを取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.13</br>
		/// </remarks>
		public void GetListSaveDataTable(out DataTable retDataTable)
		{
			// データセットメモリを返す
			retDataTable = this._dateTableSaveList;
		}

		/// <summary>
		/// UIグリッド用ハッシュテーブル取得処理
		/// </summary>
		/// <param name="retHashTable">UIグリッド用ハッシュテーブル</param>		
		/// <remarks>
		/// <br>Note       : UIグリッド用ハッシュテーブルを取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.21</br>
		/// </remarks>
		public void GetUiGridHashTable(out Hashtable retHashTable)
		{
			// ハッシュテーブルを返す
			retHashTable = this._gridHashTable;
		}

        // --- DEL 2009/01/14 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// 掛率設定管理マスタ読み込み処理
        ///// </summary>
        ///// <param name="retList">読込結果コレクション</param>
        ///// <param name="retTotalCnt">読込対象データ総件数</param>
        ///// <param name="nextData">次データ有無</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        ///// <param name="message">エラーメッセージ</param>
        ///// <returns>掛率設定管理マスタクラス</returns>
        ///// <remarks>
        ///// <br>Note       : 掛率設定管理マスタ情報を読み込みます。</br>
        ///// <br>Programmer : 30167 上野 弘貴</br>
        ///// <br>Date       : 2007.09.12</br>
        ///// </remarks>
        //private int SearchProc(out DataTable  retList
        //                     ,out int retTotalCnt
        //                     ,out bool nextData
        //                     ,string enterpriseCode
        //                     ,string sectionCode
        //                     ,ConstantManagement.LogicalMode logicalMode
        //                     ,out string message)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    retList = null;
        //    retTotalCnt = 0;
        //    nextData = false;
        //    message = "";
        //    ArrayList paraList = null;

        //    try
        //    {
        //        //------------------------------
        //        // コンボボックスデータ初期化
        //        //------------------------------
        //        RateProtyMng._rateSettingDivideGoodsTable = new SortedList();
        //        RateProtyMng._rateSettingDivideCustTable = new SortedList();
				
        //        //==========================================
        //        // 掛率設定管理（商品）マスタ読み込み
        //        //==========================================
        //        // 抽出条件パラメータ
        //        RateMngGoodsWork rateMngGoodsParaWork = new RateMngGoodsWork();
        //        paraList = new ArrayList();
				
        //        rateMngGoodsParaWork.LogicalDeleteCode = 0;
        //        paraList.Add(rateMngGoodsParaWork);
				
        //        // リモート戻りリスト
        //        object rateMngGoodsWorkList = null;

        //        //----- ueno upd ---------- start 2008.02.27
        //        // 提供データはローカル固定
        //        List<RateMngGoodsWork> wkRateMngGoodsWorkList = new List<RateMngGoodsWork>();
        //        status = this._rateMngGoodsLcDB.Search(out wkRateMngGoodsWorkList, rateMngGoodsParaWork, 0, logicalMode);
				
        //        if(status == 0)
        //        {
        //            ArrayList al = new ArrayList();
        //            al.AddRange(wkRateMngGoodsWorkList);
        //            rateMngGoodsWorkList = (object)al;
        //        }
        //        //----- ueno upd ---------- end 2008.02.27
				
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            // データテーブルにセット
        //            foreach (RateMngGoodsWork wkRateMngGoodsWork in (ArrayList)rateMngGoodsWorkList)
        //            {
        //                //--------------------------------
        //                // 掛率設定管理（商品）データ設定
        //                //--------------------------------
        //                // 文字列結合(例:A ﾒｰｶｰ＋商品)				
        //                _stringBuilder.Remove(0, _stringBuilder.Length);	//初期化
        //                _stringBuilder.Append(wkRateMngGoodsWork.RateMngGoodsCd.Trim());
        //                _stringBuilder.Append(" ");
        //                _stringBuilder.Append(wkRateMngGoodsWork.RateMngGoodsNm);

        //                string goodsAllName = _stringBuilder.ToString();		// コンボボックス表示用

        //                // 未登録なら設定する
        //                if (RateProtyMng._rateSettingDivideGoodsTable.ContainsKey(wkRateMngGoodsWork.RateMngGoodsCd.Trim()) == false)
        //                {
        //                    RateProtyMng._rateSettingDivideGoodsTable.Add(wkRateMngGoodsWork.RateMngGoodsCd.Trim(), goodsAllName);
        //                }

        //                //==========================================
        //                // 掛率設定管理（得意先）マスタ読み込み
        //                //==========================================
        //                // 抽出条件パラメータ
        //                RateMngCustWork rateMngCustParaWork = new RateMngCustWork();
        //                paraList = new ArrayList();
        //                paraList.Add(rateMngCustParaWork);
						
        //                // リモート戻りリスト
        //                object rateMngCustWorkList = null;

        //                //----- ueno upd ---------- start 2008.02.27
        //                // 提供データはローカル固定
        //                List<RateMngCustWork> wkRateMngCustWorkList = new List<RateMngCustWork>();
        //                status = this._rateMngCustLcDB.Search(out wkRateMngCustWorkList, rateMngCustParaWork, 0, logicalMode);
						
        //                if(status == 0)
        //                {
        //                    ArrayList al = new ArrayList();
        //                    al.AddRange(wkRateMngCustWorkList);
        //                    rateMngCustWorkList = (object)al;
        //                }
        //                //----- ueno upd ---------- end 2008.01.31

        //                // データテーブルにセット
        //                foreach (RateMngCustWork wkRateMngCustWork in (ArrayList)rateMngCustWorkList)
        //                {
        //                    // データテーブルセット
        //                    AddRowFromGoodsCustWork(wkRateMngGoodsWork, wkRateMngCustWork);

        //                    //----------------------------------
        //                    // 掛率設定管理（得意先）データ設定
        //                    //----------------------------------
        //                    // 文字列結合(例:1 得意先＋仕入先)				
        //                    _stringBuilder.Remove(0, _stringBuilder.Length);	//初期化
        //                    _stringBuilder.Append(wkRateMngCustWork.RateMngCustCd.Trim());
        //                    _stringBuilder.Append(" ");
        //                    _stringBuilder.Append(wkRateMngCustWork.RateMngCustNm);

        //                    string custAllName = _stringBuilder.ToString();		// コンボボックス表示用

        //                    // 未登録なら設定する
        //                    if (RateProtyMng._rateSettingDivideCustTable.ContainsKey(wkRateMngCustWork.RateMngCustCd.Trim()) == false)
        //                    {
        //                        RateProtyMng._rateSettingDivideCustTable.Add(wkRateMngCustWork.RateMngCustCd.Trim(), custAllName);
        //                    }
        //                }
        //            }
        //            // データテーブルを返す
        //            retList = this._dateTableList;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message;
        //    }
        //    return status;
        //}
        // --- DEL 2009/01/14 ---------------------------------------------------------------------<<<<<

        // --- ADD 2009/01/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 掛率設定管理マスタ読み込み処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>掛率設定管理マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定管理マスタ情報を読み込みます。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/14</br>
        /// </remarks>
        private int SearchProc(out DataTable retList
                             , out int retTotalCnt
                             , out bool nextData
                             , string enterpriseCode
                             , string sectionCode
                             , ConstantManagement.LogicalMode logicalMode
                             , out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = null;
            retTotalCnt = 0;
            nextData = false;
            message = "";
            ArrayList paraList = null;

            try
            {
                //------------------------------
                // コンボボックスデータ初期化
                //------------------------------
                RateProtyMng._rateSettingDivideGoodsTable = new SortedList();
                RateProtyMng._rateSettingDivideCustTable = new SortedList();

                //==========================================
                // 掛率設定管理（商品）マスタ読み込み
                //==========================================
                // 抽出条件パラメータ
                RateMngGoodsWork rateMngGoodsParaWork = new RateMngGoodsWork();
                paraList = new ArrayList();

                rateMngGoodsParaWork.LogicalDeleteCode = 0;
                paraList.Add(rateMngGoodsParaWork);

                // 提供データはローカル固定
                List<RateMngGoodsWork> wkRateMngGoodsWorkList;
                status = this._rateMngGoodsLcDB.Search(out wkRateMngGoodsWorkList, rateMngGoodsParaWork, 0, logicalMode);
                if (status == 0)
                {
                    //ArrayList al = new ArrayList();
                    //al.AddRange(wkRateMngGoodsWorkList);
                    //rateMngGoodsWorkList = (object)al;
                }

                //==========================================
                // 掛率設定管理（得意先）マスタ読み込み
                //==========================================
                // 抽出条件パラメータ
                RateMngCustWork rateMngCustParaWork = new RateMngCustWork();
                paraList = new ArrayList();
                paraList.Add(rateMngCustParaWork);

                // 提供データはローカル固定
                List<RateMngCustWork> wkRateMngCustWorkList;
                status = this._rateMngCustLcDB.Search(out wkRateMngCustWorkList, rateMngCustParaWork, 0, logicalMode);
                if (status == 0)
                {
                    //ArrayList al = new ArrayList();
                    //al.AddRange(wkRateMngCustWorkList);
                    //rateMngCustWorkList = (object)al;
                }

                foreach (RateMngGoodsWork rateMngGoodsWork in wkRateMngGoodsWorkList)
                {
                    //--------------------------------
                    // 掛率設定管理（商品）データ設定
                    //--------------------------------
                    // 文字列結合(例:A ﾒｰｶｰ＋商品)				
                    _stringBuilder.Remove(0, _stringBuilder.Length);	// 初期化
                    _stringBuilder.Append(rateMngGoodsWork.RateMngGoodsCd.Trim());
                    _stringBuilder.Append(" ");
                    _stringBuilder.Append(rateMngGoodsWork.RateMngGoodsNm);

                    // コンボボックス表示用
                    string goodsAllName = _stringBuilder.ToString();		

                    // 未登録なら設定する
                    if (RateProtyMng._rateSettingDivideGoodsTable.ContainsKey(rateMngGoodsWork.RateMngGoodsCd.Trim()) == false)
                    {
                        RateProtyMng._rateSettingDivideGoodsTable.Add(rateMngGoodsWork.RateMngGoodsCd.Trim(), goodsAllName);
                    }
                }

                foreach (RateMngCustWork rateMngCustWork in wkRateMngCustWorkList)
                {
                    //----------------------------------
                    // 掛率設定管理（得意先）データ設定
                    //----------------------------------
                    // 文字列結合(例:1 得意先＋仕入先)				
                    _stringBuilder.Remove(0, _stringBuilder.Length);	// 初期化
                    _stringBuilder.Append(rateMngCustWork.RateMngCustCd.Trim());
                    _stringBuilder.Append(" ");
                    _stringBuilder.Append(rateMngCustWork.RateMngCustNm);

                    // コンボボックス表示用
                    string custAllName = _stringBuilder.ToString();		

                    // 未登録なら設定する
                    if (RateProtyMng._rateSettingDivideCustTable.ContainsKey(rateMngCustWork.RateMngCustCd.Trim()) == false)
                    {
                        RateProtyMng._rateSettingDivideCustTable.Add(rateMngCustWork.RateMngCustCd.Trim(), custAllName);
                    }
                }

                foreach (RateMngGoodsWork rateMngGoodsWork in wkRateMngGoodsWorkList)
                {
                    if (rateMngGoodsWork.RateMngGoodsCd.Trim() == "A")
                    {
                        foreach (RateMngCustWork rateMngCustWork in wkRateMngCustWorkList)
                        {
                            // データテーブルセット
                            AddRowFromGoodsCustWork(rateMngGoodsWork, rateMngCustWork);
                        }
                    }
                }

                foreach (RateMngCustWork rateMngCustWork in wkRateMngCustWorkList)
                {
                    foreach (RateMngGoodsWork rateMngGoodsWork in wkRateMngGoodsWorkList)
                    {
                        if (rateMngGoodsWork.RateMngGoodsCd.Trim() != "A")
                        {
                            // データテーブルセット
                            AddRowFromGoodsCustWork(rateMngGoodsWork, rateMngCustWork);
                        }
                    }
                }

                // データテーブルを返す
                retList = this._dateTableList;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        // --- ADD 2009/01/14 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 掛率設定管理（商品・得意先）マスタ　→　データテーブル追加処理
		/// </summary>
		/// <param name="rateMngGoodsWork">読込結果コレクション（商品）</param>
		/// <param name="rateMngCustWork">読込結果コレクション（得意先）</param>
		/// <remarks>
		/// <br>Note       : 掛率設定管理（商品・得意先）マスタのデータをマージしてデータテーブルに追加します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.17</br>
		/// </remarks>
		private void AddRowFromGoodsCustWork(RateMngGoodsWork rateMngGoodsWork, RateMngCustWork rateMngCustWork)
		{
			DataRow dr;
			string listSearchStr = "";
			try
			{
                //// --- ADD 2008/10/20 --------------------------------------------------------------------------->>>>>
                // 掛率設定区分に"6L:指定なし 指定なし"を表示しない
                if ((rateMngGoodsWork.RateMngGoodsCd.Trim() == "L") && (rateMngCustWork.RateMngCustCd.Trim() == "6"))
                {
                    return;
                }
                //// --- ADD 2008/10/20 ---------------------------------------------------------------------------<<<<<

				dr = this._dateTableList.NewRow();

				dr[CREATEDATETIME] = rateMngGoodsWork.CreateDateTime;	// 商品情報をとりあえず設定しておく
				dr[UPDATEDATETIME] = rateMngGoodsWork.UpdateDateTime;	// 商品情報をとりあえず設定しておく

				dr[SECTIONCODE] = "";		// 書き込み時使用
				dr[UNITPRICEKIND] = 0;		// 書き込み時使用

                string rateSetting = rateMngCustWork.RateMngCustCd.Trim() + rateMngGoodsWork.RateMngGoodsCd.Trim();
                if (RateProtyMng._ratePriorityOrderDic.ContainsKey(rateSetting))
                {
                    dr[RATEPRIORITYORDER] = RateProtyMng._ratePriorityOrderDic[rateSetting];	// 書き込み時使用
                }
                else
                {
                    dr[RATEPRIORITYORDER] = 0;	// 書き込み時使用
                }
				dr[RATEMNGGOODSCD] = rateMngGoodsWork.RateMngGoodsCd.Trim();
				dr[RATEMNGCUSTCD]  = rateMngCustWork.RateMngCustCd.Trim();
				dr[RATEMNGGOODSNM] = rateMngGoodsWork.RateMngGoodsNm;
				dr[RATEMNGCUSTNM]  = rateMngCustWork.RateMngCustNm;

                // 文字列結合(例:A1 ﾒｰｶｰ＋商品 得意先＋仕入先)
                // 文字列結合(例:1B 得意先＋仕入先 ﾒｰｶｰ＋層別+BLｺｰﾄﾞ)
				_stringBuilder.Remove(0, _stringBuilder.Length);	//初期化
                _stringBuilder.Append(rateMngCustWork.RateMngCustCd.Trim());
                _stringBuilder.Append(rateMngGoodsWork.RateMngGoodsCd.Trim());
                listSearchStr = _stringBuilder.ToString();
                _stringBuilder.Append(" ");
                _stringBuilder.Append(rateMngCustWork.RateMngCustNm);
                _stringBuilder.Append("+");
                _stringBuilder.Append(rateMngGoodsWork.RateMngGoodsNm);

				dr[RATEMNGALLNM] = _stringBuilder.ToString();	// グリッド表示用
				dr[RATESETTINGDIVIDE] = listSearchStr;			// 掛率設定区分(例:A1)
				dr[DATAEXIST_FLAG] = 0;							// 確定グリッド有無フラグ
				dr[HIDDEN_FLAG] = 0;							// 表示フラグ
				
				dr[SELECT_FLAG] = false;						// 選択フラグ（false:未選択状態, true:選択状態）
				dr[SELECT] = "";								// 選択（"":未選択状態, 選択:選択状態）

				dr[FILEHEADERGUID] = Guid.NewGuid();			// 新規GUID作成

				this._dateTableList.Rows.Add(dr);

				// ハッシュテーブル更新
				if (this._gridHashTable.ContainsKey(dr[FILEHEADERGUID]) == true)
				{
					this._gridHashTable.Remove(dr[FILEHEADERGUID]);
				}
				this._gridHashTable.Add(dr[FILEHEADERGUID], dr);
			}
			catch
			{
			}
		}
		
		/// <summary>
		/// データテーブル列情報構築処理
		/// </summary>
		/// <remarks>
		/// <param name="wkTable">データテーブル</param>
		/// <br>Note       : データテーブルの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.09.13</br>
		/// </remarks>
		private void DataTableColumnConstruction(ref DataTable wkTable)
		{
			// 作成日付（書き込み時使用）
			wkTable.Columns.Add(CREATEDATETIME, typeof(DateTime));

			// 更新日付（書き込み時使用）
			wkTable.Columns.Add(UPDATEDATETIME, typeof(DateTime));
			
			// 拠点コード（書き込み時使用）
			wkTable.Columns.Add(SECTIONCODE, typeof(string));
			
			// 単価種類（書き込み時使用）
			wkTable.Columns.Add(UNITPRICEKIND, typeof(Int32));

            // --- DEL 2009/01/13 --------------------------------------------------------------------->>>>>
            //// 掛率優先順位
            //wkTable.Columns.Add(RATEPRIORITYORDER, typeof(Int32));
            // --- DEL 2009/01/13 ---------------------------------------------------------------------<<<<<

			// 掛率設定区分
			wkTable.Columns.Add(RATESETTINGDIVIDE, typeof(string));
			
			// 掛率設定区分（商品）
			wkTable.Columns.Add(RATEMNGGOODSCD, typeof(string));

			// 掛率設定区分（得意先）
			wkTable.Columns.Add(RATEMNGCUSTCD, typeof(string));
			
			// 掛率設定名称（商品）
			wkTable.Columns.Add(RATEMNGGOODSNM, typeof(string));

			// 掛率設定名称（得意先）
			wkTable.Columns.Add(RATEMNGCUSTNM, typeof(string));
			
			// 選択フラグ
			wkTable.Columns.Add(SELECT_FLAG, typeof(bool));
			
			// 選択（グリッド表示用）
			wkTable.Columns.Add(SELECT, typeof(string));

            // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
            // 掛率優先順位
            wkTable.Columns.Add(RATEPRIORITYORDER, typeof(Int32));
            // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<
			
			// 掛率設定リスト表示用文字列
			wkTable.Columns.Add(RATEMNGALLNM, typeof(string));

			// 確定グリッド有無フラグ
			wkTable.Columns.Add(DATAEXIST_FLAG, typeof(int));
			
			// 表示フラグ
			wkTable.Columns.Add(HIDDEN_FLAG, typeof(int));
			
			// GUID
			wkTable.Columns.Add(FILEHEADERGUID, typeof(Guid));
		}
	}
}

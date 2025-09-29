﻿using System;
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
    /// 掛率マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタのアクセス制御を行います。</br>
    /// <br>Programmer : 30167 上野　弘貴</br>
    /// <br>Date       : 2007.10.03</br>
	/// <br>Update Note: 2008.01.31 30167 上野　弘貴</br>
	/// <br>			 ローカルＤＢ対応</br>
	/// <br>Update Note: 2008.02.20 30167 上野　弘貴</br>
	/// <br>			 Search()複数版のステータス対応（1件でもヒットすればステータス「0」にする）</br>
	/// </remarks>
    public class RateAcs
	{
		#region Public Members
		// ===================================================================================== //
		// パブリックメンバー
		// ===================================================================================== //
		//----------------------------------------
        // 掛率設定マスタ定数定義
        //----------------------------------------
		/// <summary>作成日付</summary>
        public const string CREATEDATETIME			= "CreateDateTime";
		/// <summary>更新日付</summary>
		public const string UPDATEDATETIME			= "UpdateDateTime";
		/// <summary>企業コード</summary>
		public const string ENTERPRISECODE			= "EnterpriseCode";
		/// <summary>GUID</summary>
		public const string FILEHEADERGUID			= "FileHeaderGuid";
		/// <summary>更新従業員コード</summary>
		public const string UPDEMPLOYEECODE			= "UpdEmployeeCode";
		/// <summary>更新アセンブリID1</summary>
		public const string UPDASSEMBLYID1			= "UpdAssemblyId1";
		/// <summary>更新アセンブリID2</summary>
		public const string UPDASSEMBLYID2			= "UpdAssemblyId2";
		/// <summary>論理削除区分</summary>
		public const string LOGICALDELETECODE		= "LogicalDeleteCode";
		/// <summary>拠点コード</summary>
		public const string SECTIONCODE				= "拠点コード";
		/// <summary>単価掛率設定区分</summary>
		public const string UNITRATESETDIVCD 		= "単価掛率設定区分";
        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// <summary>新旧区分</summary>
		public const string OLDNEWDIVCD 			= "新旧区分";
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        /// <summary>単価種類</summary>
		public const string UNITPRICEKIND			= "単価種類";
		/// <summary>掛率設定区分</summary>
		public const string RATESETTINGDIVIDE		= "掛率設定区分";
		/// <summary>掛率設定区分（商品）</summary>
		public const string RATEMNGGOODSCD			= "掛率設定区分（商品）";
		/// <summary>掛率設定名称（商品）</summary>
		public const string RATEMNGGOODSNM			= "掛率設定名称（商品）";
		/// <summary>掛率設定区分（得意先）</summary>
		public const string RATEMNGCUSTCD			= "掛率設定区分（得意先）";
		/// <summary>掛率設定名称（得意先）</summary>
		public const string RATEMNGCUSTNM			= "掛率設定名称（得意先）";	
		/// <summary>商品メーカーコード</summary>
		public const string GOODSMAKERCD			= "商品メーカーコード";
		/// <summary>商品番号</summary>
		public const string GOODSNO					= "商品番号";
		/// <summary>商品掛率ランク</summary>
		public const string GOODSRATERANK			= "商品掛率ランク";
        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// <summary>商品区分グループコード</summary>
		public const string LARGEGOODSGANRECODE		= "商品区分グループコード";
		/// <summary>商品区分コード</summary>
		public const string MEDIUMGOODSGANRECODE	= "商品区分コード";
		/// <summary>商品区分詳細コード</summary>
		public const string DETAILGOODSGANRECODE	= "商品区分詳細コード";
		/// <summary>自社分類コード</summary>
		public const string ENTERPRISEGANRECODE		= "自社分類コード";
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        /// <summary>BL商品コード</summary>
		public const string BLGOODSCODE				= "BL商品コード";
		/// <summary>得意先コード</summary>
		public const string CUSTOMERCODE			= "得意先コード";
		/// <summary>得意先掛率グループコード</summary>
		public const string CUSTRATEGRPCODE			= "得意先掛率グループコード";
		/// <summary>仕入先コード</summary>
		public const string SUPPLIERCD				= "仕入先コード";
        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// <summary>仕入先掛率グループコード</summary>
		public const string SUPPRATEGRPCODE			= "仕入先掛率グループコード";
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        /// <summary>ロット数</summary>
		public const string LOTCOUNT				= "ロット数";
		/// <summary>単価算出区分</summary>
		public const string UNITPRCCALCDIV			= "単価算出区分";
		/// <summary>価格区分</summary>
		public const string PRICEDIV				= "価格区分";
		/// <summary>価格</summary>
		public const string PRICEFL					= "価格";
		/// <summary>掛率</summary>
		public const string RATEVAL					= "掛率";
		/// <summary>単価端数処理単位</summary>
		public const string UNPRCFRACPROCUNIT		= "単価端数処理単位";
		/// <summary>単価端数処理区分</summary>
		public const string UNPRCFRACPROCDIV		= "単価端数処理区分";
        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		/// <summary>掛率開始日</summary>
		public const string RATESTARTDATE			= "掛率開始日";
		/// <summary>特売区分コード</summary>
		public const string BARGAINCD				= "特売区分コード";
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        /// <summary>削除日</summary>
		public const string DELETE_DATE_TITLE		= "削除日";
        // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
        /// <summary>商品掛率グループコード</summary>
        public const string GOODSRATEGRPCODE = "商品中分類";
        /// <summary>BLグループコード</summary>
        public const string BLGLOUPCODE = "BLグループコード";
        /// <summary>UP率</summary>
        public const string UPRATE = "UP率";
        /// <summary>粗利確保率</summary>
        public const string GRSPROFITSECURERATE = "粗利確保率";
        // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<

        // テーブル名
		/// <summary>掛率テーブル</summary>
		public const string RATE_TABLE = "RateTable";
		
		#endregion

		#region Private Members
		// ===================================================================================== //
		// プライベートメンバー
		// ===================================================================================== //
        // private member定義
        // リモートオブジェクト格納バッファ
        private IRateDB _rateDB = null;    // 課設定リモート

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		//----- ueno add ---------- start 2008.01.31
		private RateLcDB _rateLcDB = null;

		private static bool _isLocalDBRead = false;	// デフォルトはリモート
		//----- ueno add ---------- end 2008.01.31
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

        private DataSet _dataTableList = null;

		// 文字列結合用
		private StringBuilder _stringBuilder = null;

        // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
        /// <summary>掛率設定区分（メーカー表示区分値）</summary>
        private static readonly List<string> ctRATEDIVVALUE_Maker = new List<string>(new string[] { "A", "B", "C", "D", "E", "F" });
        /// <summary>掛率設定区分（商品コード,商品名表示区分値）</summary>
        private static readonly List<string> ctRATEDIVVALUE_Goods = new List<string>(new string[] { "A" });
        /// <summary>掛率設定区分（層別表示区分値）</summary>
        private static readonly List<string> ctRATEDIVVALUE_GoodsRateRank = new List<string>(new string[] { "D", "I" });
        /// <summary>掛率設定区分（商品掛率グループ表示区分値）</summary>
        private static readonly List<string> ctRATEDIVVALUE_GoodsRateGrpCode = new List<string>(new string[] { "C", "H" });
        /// <summary>掛率設定区分（BLグループコード）</summary>
        private static readonly List<string> ctRATEDIVVALUE_BLGroupCode = new List<string>(new string[] { "E", "J" });
        /// <summary>掛率設定区分（BL商品表示区分値）</summary>
        private static readonly List<string> ctRATEDIVVALUE_BLGoods = new List<string>(new string[] { "B", "G" });
        /// <summary>掛率設定区分（得意先表示区分値）</summary>
        private static readonly List<string> ctRATEDIVVALUE_Customer = new List<string>(new string[] { "1", "2" });
        /// <summary>掛率設定区分（得意先掛率GR表示区分値）</summary>
        private static readonly List<string> ctRATEDIVVALUE_CustRateGrp = new List<string>(new string[] { "3", "4" });
        /// <summary>掛率設定区分（仕入先表示区分値）</summary>
        private static readonly List<string> ctRATEDIVVALUE_SupplierCd = new List<string>(new string[] { "1", "3", "5" });
        // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
		
		#endregion
		
        #region Construcstor
        /// <summary>
        /// 掛率マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        public RateAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._rateDB = (IRateDB)MediationRateDB.GetRateDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._rateDB = null;
            }

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			//----- ueno add ---------- start 2008.01.31
			// ローカルDBアクセスオブジェクト取得
			this._rateLcDB = new RateLcDB();
			//----- ueno add ---------- end 2008.01.31
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

            // データセット列情報構築処理
            this._dataTableList = new DataSet();
            DataSetColumnConstruction(ref this._dataTableList);

			// 文字列結合用
			_stringBuilder = new StringBuilder();
        }
        #endregion

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

        // 列挙型
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
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        public int GetOnlineMode()
        {
			if (this._rateDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
        }

        #region Property
        /// <summary>掛率テーブル</summary>
        public DataTable DtThirdTable
        {
            get { return this._dataTableList.Tables[RATE_TABLE]; }
        }
        #endregion

        // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
        #region ■Static Methods
        /// <summary>
        /// 得意先が掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public static bool IsCustomerSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_Customer);
        }

        /// <summary>
        /// 得意先掛率設定GRが掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public static bool IsCustRateGrpSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_CustRateGrp);
        }

        /// <summary>
        /// 仕入先が掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public static bool IsSupplierSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_SupplierCd);
        }

        /// <summary>
        /// 商品コードが掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public static bool IsGoodsNoSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_Goods);
        }

        /// <summary>
        /// メーカーが掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public static bool IsMakerSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_Maker);
        }

        /// <summary>
        /// 層別が掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public static bool IsGoodsRateRankSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_GoodsRateRank);
        }

        /// <summary>
        /// 商品掛率グループコードが掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public static bool IsGoodsRateGrpCodeSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_GoodsRateGrpCode);
        }

        /// <summary>
        /// BLグループコードが掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public static bool IsBLGroupCodeSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_BLGroupCode);
        }

        /// <summary>
        /// BL商品が掛率設定区分の設定対象かを取得します。
        /// </summary>
        /// <param name="rateDiv">掛率設定区分</param>
        /// <returns>true:設定有り</returns>
        public static bool IsBLGoodsSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_BLGoods);
        }

        /// <summary>
        /// 対象文字列中に、比較対象リストに含まれる文字列が存在するかを取得します。
        /// </summary>
        /// <param name="target">対象文字列</param>
        /// <param name="startIndex">文字列中の比較文字開始位置</param>
        /// <param name="length">比較文字列の長さ</param>
        /// <param name="judgmentList">比較対象リスト</param>
        /// <returns>true:存在する</returns>
        private static bool IsSetting(string target, int startIndex, int length, List<string> judgmentList)
        {
            bool ret = false;
            if (target.Length >= (startIndex + length))
            {
                if (judgmentList.Contains(target.Substring(startIndex, length))) ret = true;
            }
            return ret;
        }
        #endregion ■Static Methods
        // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<

        #region Search 検索処理
        /// <summary>
		/// 検索処理（論理削除含まない）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="rate">掛率クラス</param>
		/// <param name="message">メッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 掛率マスタの条件に一致したデータを検索します。論理削除データは抽出対象外</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.15</br>
		/// </remarks>
		public int Search(out DataTable retList, ref Rate rate, out string message)
		{
			// 検索
			int status = SearchProc(out retList, ref rate, 0, out message);
			return status;
		}

		/// <summary>
		/// 掛率マスタ複数検索処理（論理削除含まない）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="rateList">掛率オブジェクトリスト</param>
		/// <param name="message">メッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 掛率マスタリストの条件に一致したデータを検索します。論理削除データは抽出対象外</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2007.11.14</br>
		/// </remarks>
		public int Search( out DataTable retList, List<Rate> rateList, out string message )
		{
			// 検索
			int status = SearchProc(out retList, rateList, 0, out message);
			return status;
		}
		#endregion

		#region SearchAll 検索処理
		/// <summary>
		/// 検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="rate">掛率クラス</param>
		/// <param name="message">メッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 掛率マスタの条件に一致したデータを検索します。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.15</br>
		/// </remarks>
		public int SearchAll(out DataTable retList, ref Rate rate, out string message)
		{
			// 検索
			int status = SearchProc(out retList, ref rate, ConstantManagement.LogicalMode.GetData01, out message);
			return status;
		}
		#endregion

		#region SearchAll 検索処理
		/// <summary>
		/// 検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果アレイリスト</param>
		/// <param name="rate">掛率クラス</param>
		/// <param name="message">メッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 掛率マスタの条件に一致したデータを検索します。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.15</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList, ref Rate rate, out string message)
		{
			// ロット数設定（掛率、ロットデータ全て取得）
			rate.LotCount = -1;	// ロット数（-1:絞込み無し, -1以外:該当ロット数で絞り込み）
			
			// 検索
			int status = SearchProc(out retList, ref rate, ConstantManagement.LogicalMode.GetData01, out message);
			return status;
		}
		#endregion

		#region SearchRate 検索処理
		/// <summary>
		/// 検索処理（ロット設定以外取得）
		/// </summary>
		/// <param name="retList">読込結果アレイリスト</param>
		/// <param name="rate">掛率クラス</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="message">メッセージ</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 掛率マスタの条件に一致したデータを検索します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.15</br>
		/// </remarks>
		public int SearchRate(out ArrayList retList, ref Rate rate, ConstantManagement.LogicalMode logicalMode, out string message)
		{
			// ロット数設定（ロット設定以外を取得）
			rate.LotCount = 0;	// ロット数（-1:絞込み無し, -1以外:該当ロット数で絞り込み）
			
			// 検索
			int status = SearchProc(out retList, ref rate, logicalMode, out message);
			return status;
		}
		#endregion
		
        #region Write 書き込み処理
        /// <summary>
        /// 書き込み処理
        /// </summary>
		/// <param name="rateList">保存データリスト</param>
		/// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 書き込み処理を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
		public int Write(ref ArrayList rateList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
			
            try
            {
				// データ数分ループ
				ArrayList paraRateList = new ArrayList();
				RateWork rateWork = null;

				for (int i = 0; i < rateList.Count; i++)
				{
					// クラスデータをワーククラスデータに変換
					rateWork = CopyToRateWorkFromRate((Rate)rateList[i]);

					paraRateList.Add(rateWork);
				}

				object paraObj = (object)paraRateList;

				// 書き込み処理
				status = this._rateDB.Write(ref paraObj);
				
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 何かしらのエラー発生
                    message = "登録に失敗しました。";
                    return status;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._rateDB  = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region LogicalDelete 論理削除処理
        /// <summary>
        /// 論理削除処理
        /// </summary>
		/// <param name="rateList">論理削除データリスト</param>
        /// <param name="message">メッセージ</param>
		/// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
		public int LogicalDelete(ref ArrayList rateList, out string message)
        {
            int status = ( int ) ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
				// データ数分ループ
				ArrayList paraRateList = new ArrayList();
				RateWork rateWork = null;

				for (int i = 0; i < rateList.Count; i++)
				{
					// クラスデータをワーククラスデータに変換
					rateWork = CopyToRateWorkFromRate((Rate)rateList[i]);

					paraRateList.Add(rateWork);
				}
				object paraObj = (object)paraRateList;

				// 論理削除処理
				status = this._rateDB.LogicalDelete(ref paraObj);

                if ( status != ( int ) ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }

                status = ( int ) ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( Exception ex ) {
                message = ex.Message;
                // オフライン時はnullをセット
                this._rateDB = null;
                // 通信エラー
                status = ( int ) ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region Revival 復旧処理
        /// <summary>
        /// 復旧処理
        /// </summary>
		/// <param name="rateList">論理削除データリスト</param>
		/// <param name="message">メッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
        /// <br>Note       : 復旧処理（論理削除復旧）を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
		public int Revival(ref ArrayList rateList, out string message)
        {
            int status = ( int ) ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
				// データ数分ループ
				ArrayList paraRateList = new ArrayList();
				RateWork rateWork = null;

				for (int i = 0; i < rateList.Count; i++)
				{
					// クラスデータをワーククラスデータに変換
					rateWork = CopyToRateWorkFromRate((Rate)rateList[i]);

					paraRateList.Add(rateWork);
				}

				object paraObj = (object)paraRateList;

                // 書き込み処理
                status = this._rateDB.RevivalLogicalDelete(ref paraObj);

                if ( status != ( int ) ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }
                status = ( int ) ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch ( Exception ex ) {
                message = ex.Message;
                // オフライン時はnullをセット
                this._rateDB = null;
                // 通信エラー
                status = ( int ) ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region Delete 削除処理
        /// <summary>
        /// 削除処理
        /// </summary>
		/// <param name="rateList">削除データリスト</param>
		/// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 削除処理（物理削除）を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int Delete (ref ArrayList rateList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
				byte[] paraRateWork = null;
				RateWork rateWork = null;
				ArrayList rateWorkList = new ArrayList();	// ワーククラス格納用ArrayList

				// ワーククラス格納用ArrayListへ詰め替え
				for (int i = 0; i < rateList.Count; i++)
				{
					// クラスデータをワーククラスデータに変換
					rateWork = CopyToRateWorkFromRate((Rate)rateList[i]);
					rateWorkList.Add(rateWork);
				}
				// ArrayListから配列を生成
				RateWork[] rateWorks = (RateWork[])rateWorkList.ToArray(typeof(RateWork));

				// シリアライズ
				paraRateWork = XmlByteSerializer.Serialize(rateWorks);

				// 物理削除処理
				status = this._rateDB.Delete( paraRateWork );

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }
				
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._rateDB  = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR ;
            }
            return status;
        }
        #endregion

        #region データセット列情報構築処理
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
		/// <param name="ds">データセット</param>
		/// <remarks>
        /// <br>Note       : データセットの列情報を構築します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            //----------------------------------------------------------------
            // 掛率テーブル列定義
            //----------------------------------------------------------------
            DataTable rateTable = new DataTable(RATE_TABLE);

            // 作成日時
            rateTable.Columns.Add(CREATEDATETIME, typeof(DateTime));
            // 更新日時
            rateTable.Columns.Add(UPDATEDATETIME, typeof(DateTime));
            // 企業コード
            rateTable.Columns.Add(ENTERPRISECODE, typeof(string));
            // GUID
            rateTable.Columns.Add(FILEHEADERGUID, typeof(Guid));
            // 更新従業員コード
            rateTable.Columns.Add(UPDEMPLOYEECODE, typeof(string));
            // 更新アセンブリID1
            rateTable.Columns.Add(UPDASSEMBLYID1, typeof(string));
            // 更新アセンブリID2
            rateTable.Columns.Add(UPDASSEMBLYID2, typeof(string));
            // 論理削除区分
            rateTable.Columns.Add(LOGICALDELETECODE, typeof(Int32));
            // 拠点コード
            rateTable.Columns.Add(SECTIONCODE, typeof(string));
			// 単価掛率設定区分
            rateTable.Columns.Add(UNITRATESETDIVCD, typeof(string));
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 新旧区分
            rateTable.Columns.Add(OLDNEWDIVCD, typeof(string));
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // 単価種類（コード）
			rateTable.Columns.Add(UNITPRICEKIND, typeof(string));
			// 掛率設定区分
			rateTable.Columns.Add(RATESETTINGDIVIDE, typeof(string));
			// 掛率設定区分（商品）
			rateTable.Columns.Add(RATEMNGGOODSCD, typeof(string));
			// 掛率設定名称（商品）
			rateTable.Columns.Add(RATEMNGGOODSNM, typeof(string));
			// 掛率設定区分（得意先）
			rateTable.Columns.Add(RATEMNGCUSTCD, typeof(string));
			// 掛率設定名称（得意先）
			rateTable.Columns.Add(RATEMNGCUSTNM, typeof(string));	
			// 商品メーカーコード
			rateTable.Columns.Add(GOODSMAKERCD, typeof(Int32));
			// 商品番号
			rateTable.Columns.Add(GOODSNO,typeof(string));
			// 商品掛率ランク
			rateTable.Columns.Add(GOODSRATERANK, typeof(string));
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 商品区分グループコード
			rateTable.Columns.Add(LARGEGOODSGANRECODE, typeof(string));
			// 商品区分コード
			rateTable.Columns.Add(MEDIUMGOODSGANRECODE, typeof(string));
			// 商品区分詳細コード
			rateTable.Columns.Add(DETAILGOODSGANRECODE, typeof(string));
			// 自社分類コード
			rateTable.Columns.Add(ENTERPRISEGANRECODE, typeof(Int32));
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // BL商品コード
			rateTable.Columns.Add(BLGOODSCODE, typeof(Int32));
			// 得意先コード
			rateTable.Columns.Add(CUSTOMERCODE, typeof(Int32));
			// 得意先掛率グループコード
			rateTable.Columns.Add(CUSTRATEGRPCODE, typeof(Int32));
			// 仕入先コード
			rateTable.Columns.Add(SUPPLIERCD, typeof(Int32));
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 仕入先掛率グループコード
			rateTable.Columns.Add(SUPPRATEGRPCODE, typeof(Int32));
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // ロット数
			rateTable.Columns.Add(LOTCOUNT, typeof(double));
			// 単価算出区分
			rateTable.Columns.Add(UNITPRCCALCDIV, typeof(Int32));
			// 価格区分
			rateTable.Columns.Add(PRICEDIV, typeof(Int32));
			// 価格
			rateTable.Columns.Add(PRICEFL, typeof(double));
			// 掛率
			rateTable.Columns.Add(RATEVAL, typeof(double));
			// 単価端数処理単位
			rateTable.Columns.Add(UNPRCFRACPROCUNIT, typeof(double));
			// 単価端数処理区分
			rateTable.Columns.Add(UNPRCFRACPROCDIV, typeof(Int32));
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 掛率開始日
			rateTable.Columns.Add(RATESTARTDATE, typeof(DateTime));
			// 特売区分コード
			rateTable.Columns.Add(BARGAINCD, typeof(Int32));
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // 削除日
            rateTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));

            // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
            // 商品掛率グループコード
            rateTable.Columns.Add(GOODSRATEGRPCODE, typeof(Int32));
            // BLグループコード
            rateTable.Columns.Add(BLGLOUPCODE, typeof(Int32));
            // UP率
            rateTable.Columns.Add(UPRATE, typeof(Double));
            // 粗利確保率
            rateTable.Columns.Add(GRSPROFITSECURERATE, typeof(Double));
            // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<

			this._dataTableList.Tables.Add(rateTable);
        }
        #endregion

        #region クラスメンバコピー処理
        /// <summary>
		/// クラスメンバーコピー処理（掛率設定クラス⇒掛率設定ワーククラス）
        /// </summary>
		/// <param name="rate">掛率設定クラス</param>
        /// <returns>RateWork</returns>
        /// <remarks>
		/// <br>Note       : 掛率設定クラスから掛率設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromRate(Rate rate)
        {
            RateWork rateWork = new RateWork();

            // 作成日時
            rateWork.CreateDateTime			= rate.CreateDateTime;
            // 更新日時
            rateWork.UpdateDateTime			= rate.UpdateDateTime;
            // 企業コード
            rateWork.EnterpriseCode			= rate.EnterpriseCode;
            // GUID
            rateWork.FileHeaderGuid			= rate.FileHeaderGuid;
            // 更新従業員コード
            rateWork.UpdEmployeeCode		= rate.UpdEmployeeCode;
            // 更新アセンブリID1
            rateWork.UpdAssemblyId1			= rate.UpdAssemblyId1;
            // 更新アセンブリID2
            rateWork.UpdAssemblyId2			= rate.UpdAssemblyId2;
            // 論理削除区分
            rateWork.LogicalDeleteCode		= rate.LogicalDeleteCode;
            // 拠点コード
            rateWork.SectionCode            = rate.SectionCode;
			// 単価掛率設定区分
			rateWork.UnitRateSetDivCd		= rate.UnitRateSetDivCd;

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 新旧区分
			rateWork.OldNewDivCd			= rate.OldNewDivCd;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

            // 単価種類
			rateWork.UnitPriceKind			= rate.UnitPriceKind;
			// 掛率設定区分
			rateWork.RateSettingDivide		= rate.RateSettingDivide;
			// 掛率設定区分（商品）
			rateWork.RateMngGoodsCd			= rate.RateMngGoodsCd;
			// 掛率設定名称（商品）
			rateWork.RateMngGoodsNm			= rate.RateMngGoodsNm;
			// 掛率設定区分（得意先）
			rateWork.RateMngCustCd			= rate.RateMngCustCd;
			// 掛率設定名称（得意先）
			rateWork.RateMngCustNm			= rate.RateMngCustNm;	
			// 商品メーカーコード
			rateWork.GoodsMakerCd			= rate.GoodsMakerCd;
			// 商品番号
			rateWork.GoodsNo				= rate.GoodsNo;
			// 商品掛率ランク
			rateWork.GoodsRateRank			= rate.GoodsRateRank;

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 商品区分グループコード
			rateWork.LargeGoodsGanreCode	= rate.LargeGoodsGanreCode;
			// 商品区分コード
			rateWork.MediumGoodsGanreCode	= rate.MediumGoodsGanreCode;
			// 商品区分詳細コード
			rateWork.DetailGoodsGanreCode	= rate.DetailGoodsGanreCode;
			// 自社分類コード
			rateWork.EnterpriseGanreCode	= rate.EnterpriseGanreCode;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

            // BL商品コード
			rateWork.BLGoodsCode			= rate.BLGoodsCode;
			// 得意先コード
			rateWork.CustomerCode			= rate.CustomerCode;
			// 得意先掛率グループコード
			rateWork.CustRateGrpCode		= rate.CustRateGrpCode;
			// 仕入先コード
			rateWork.SupplierCd				= rate.SupplierCd;

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 仕入先掛率グループコード
			rateWork.SuppRateGrpCode		= rate.SuppRateGrpCode;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

            // ロット数
			rateWork.LotCount				= rate.LotCount;

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 単価算出区分
			rateWork.UnitPrcCalcDiv			= rate.UnitPrcCalcDiv;
			// 価格区分
			rateWork.PriceDiv				= rate.PriceDiv;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

            // 価格
			rateWork.PriceFl				= rate.PriceFl;
			// 掛率
			rateWork.RateVal				= rate.RateVal;
			// 単価端数処理単位
			rateWork.UnPrcFracProcUnit		= rate.UnPrcFracProcUnit;
			// 単価端数処理区分
			rateWork.UnPrcFracProcDiv		= rate.UnPrcFracProcDiv;

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 掛率開始日
			rateWork.RateStartDate			= rate.RateStartDate;
			// 特売区分コード
			rateWork.BargainCd				= rate.BargainCd;
			   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
            // 商品掛率グループコード
            rateWork.GoodsRateGrpCode       = rate.GoodsRateGrpCode;
            // BLグループコード
            rateWork.BLGroupCode            = rate.BLGroupCode;
            // UP率
            rateWork.UpRate                 = rate.UpRate;
            // 粗利確保率
            rateWork.GrsProfitSecureRate    = rate.GrsProfitSecureRate;
            // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<

            return rateWork;
        }

        /// <summary>
		/// クラスメンバーコピー処理（掛率設定ワーククラス⇒掛率設定クラス）
        /// </summary>
		/// <param name="rateWork">掛率設定ワーククラス</param>
        /// <returns>Rate</returns>
        /// <remarks>
		/// <br>Note       : 掛率設定ワーククラスから掛率設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        private Rate CopyToRateFromRateWork(RateWork rateWork)
        {
            Rate rate = new Rate();

			// 作成日時
			rate.CreateDateTime			= rateWork.CreateDateTime;
			// 更新日時
			rate.UpdateDateTime			= rateWork.UpdateDateTime;
			// 企業コード
			rate.EnterpriseCode			= rateWork.EnterpriseCode;
			// GUID
			rate.FileHeaderGuid			= rateWork.FileHeaderGuid;
			// 更新従業員コード
			rate.UpdEmployeeCode		= rateWork.UpdEmployeeCode;
			// 更新アセンブリID1
			rate.UpdAssemblyId1			= rateWork.UpdAssemblyId1;
			// 更新アセンブリID2
			rate.UpdAssemblyId2			= rateWork.UpdAssemblyId2;
			// 論理削除区分
			rate.LogicalDeleteCode		= rateWork.LogicalDeleteCode;
			// 拠点コード
			rate.SectionCode			= rateWork.SectionCode.Trim();
			// 単価掛率設定区分
			rate.UnitRateSetDivCd		= rateWork.UnitRateSetDivCd.Trim();

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 新旧区分
			rate.OldNewDivCd			= rateWork.OldNewDivCd;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            
            // 単価種類
			rate.UnitPriceKind			= rateWork.UnitPriceKind.Trim();
			// 掛率設定区分
			rate.RateSettingDivide		= rateWork.RateSettingDivide.Trim();
			// 掛率設定区分（商品）
			rate.RateMngGoodsCd			= rateWork.RateMngGoodsCd.Trim();
			// 掛率設定名称（商品）
			rate.RateMngGoodsNm			= rateWork.RateMngGoodsNm.Trim();
			// 掛率設定区分（得意先）
			rate.RateMngCustCd			= rateWork.RateMngCustCd.Trim();
			// 掛率設定名称（得意先）
			rate.RateMngCustNm			= rateWork.RateMngCustNm.Trim();
			// 商品メーカーコード
			rate.GoodsMakerCd			= rateWork.GoodsMakerCd;
			// 商品番号
			rate.GoodsNo				= rateWork.GoodsNo.Trim();
			// 商品掛率ランク
			rate.GoodsRateRank			= rateWork.GoodsRateRank.Trim();

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 商品区分グループコード
			rate.LargeGoodsGanreCode	= rateWork.LargeGoodsGanreCode;
			// 商品区分コード
			rate.MediumGoodsGanreCode	= rateWork.MediumGoodsGanreCode;
			// 商品区分詳細コード
			rate.DetailGoodsGanreCode	= rateWork.DetailGoodsGanreCode;
			// 自社分類コード
			rate.EnterpriseGanreCode	= rateWork.EnterpriseGanreCode;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            
            // BL商品コード
			rate.BLGoodsCode			= rateWork.BLGoodsCode;
			// 得意先コード
			rate.CustomerCode			= rateWork.CustomerCode;
			// 得意先掛率グループコード
			rate.CustRateGrpCode		= rateWork.CustRateGrpCode;
			// 仕入先コード
			rate.SupplierCd				= rateWork.SupplierCd;

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 仕入先掛率グループコード
			rate.SuppRateGrpCode		= rateWork.SuppRateGrpCode;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            
            // ロット数
			rate.LotCount				= rateWork.LotCount;

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 単価算出区分
			rate.UnitPrcCalcDiv			= rateWork.UnitPrcCalcDiv;
			// 価格区分
			rate.PriceDiv				= rateWork.PriceDiv;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            
            // 価格
			rate.PriceFl				= rateWork.PriceFl;
			// 掛率
			rate.RateVal				= rateWork.RateVal;
			// 単価端数処理単位
			rate.UnPrcFracProcUnit		= rateWork.UnPrcFracProcUnit;
			// 単価端数処理区分
			rate.UnPrcFracProcDiv		= rateWork.UnPrcFracProcDiv;

            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 掛率開始日
			rate.RateStartDate			= rateWork.RateStartDate;
			// 特売区分コード
			rate.BargainCd				= rateWork.BargainCd;
			   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
            // 商品掛率グループコード
            rate.GoodsRateGrpCode       = rateWork.GoodsRateGrpCode;
            // BLグループコード
            rate.BLGroupCode            = rateWork.BLGroupCode;
            // UP率
            rate.UpRate                 = rateWork.UpRate;
            // 粗利確保率
            rate.GrsProfitSecureRate    = rateWork.GrsProfitSecureRate;
            // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
            return rate;
        }

        /// <summary>
        /// クラスメンバーコピー処理（掛率設定クラス⇒DataRow）
        /// </summary>
		/// <param name="rateWork">掛率設定クラス</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定ワーククラスから掛率設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        private DataRow CopyToDataRowFromRateWork(ref RateWork rateWork)
        {
            Rate rate = this.CopyToRateFromRateWork(rateWork);

            // 掛率設定マスタへの登録
            DataRow dr = null;

            dr = this._dataTableList.Tables[RATE_TABLE].NewRow();
			
            // 作成日時
            dr[CREATEDATETIME]			= rate.CreateDateTime;
            // 更新日時
            dr[UPDATEDATETIME]			= rate.UpdateDateTime;
            // 企業コード
            dr[ENTERPRISECODE]			= rate.EnterpriseCode;
			
            if (rate.FileHeaderGuid == Guid.Empty)
            {
                // GUID
                dr[FILEHEADERGUID]		= Guid.NewGuid();
            }
            else
            {
                // GUID
                dr[FILEHEADERGUID]		= rate.FileHeaderGuid;
            }
            // 更新従業員コード
            dr[UPDEMPLOYEECODE]			= rate.UpdEmployeeCode;
            // 更新アセンブリID1
            dr[UPDASSEMBLYID1]			= rate.UpdAssemblyId1;
            // 更新アセンブリID2
            dr[UPDASSEMBLYID2]			= rate.UpdAssemblyId2;
            // 論理削除区分
            dr[LOGICALDELETECODE]		= rate.LogicalDeleteCode;
            // 拠点コード
            dr[SECTIONCODE]				= rate.SectionCode;
			// 単価掛率設定区分
			dr[UNITRATESETDIVCD]		= rate.UnitRateSetDivCd;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 新旧区分
			dr[OLDNEWDIVCD]				= rate.OldNewDivCd;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // 単価種類
			dr[UNITPRICEKIND]			= rate.UnitPriceKind;
			// 掛率設定区分
			dr[RATESETTINGDIVIDE]		= rate.RateSettingDivide;
			// 掛率設定区分（商品）
			dr[RATEMNGGOODSCD]			= rate.RateMngGoodsCd;
			// 掛率設定名称（商品）
			dr[RATEMNGGOODSNM]			= rate.RateMngGoodsNm;
			// 掛率設定区分（得意先）
			dr[RATEMNGCUSTCD]			= rate.RateMngCustCd;
			// 掛率設定名称（得意先）
			dr[RATEMNGCUSTNM]			= rate.RateMngCustNm;
			// 商品メーカーコード
			dr[GOODSMAKERCD]			= rate.GoodsMakerCd;
			// 商品番号
			dr[GOODSNO]					= rate.GoodsNo;
			// 商品掛率ランク
			dr[GOODSRATERANK]			= rate.GoodsRateRank;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 商品区分グループコード
			dr[LARGEGOODSGANRECODE]		= rate.LargeGoodsGanreCode;
			// 商品区分コード
			dr[MEDIUMGOODSGANRECODE]	= rate.MediumGoodsGanreCode;
			// 商品区分詳細コード
			dr[DETAILGOODSGANRECODE]	= rate.DetailGoodsGanreCode;
			// 自社分類コード
			dr[ENTERPRISEGANRECODE]		= rate.EnterpriseGanreCode;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // BL商品コード
			dr[BLGOODSCODE]				= rate.BLGoodsCode;
			// 得意先コード
			dr[CUSTOMERCODE]			= rate.CustomerCode;
			// 得意先掛率グループコード
			dr[CUSTRATEGRPCODE]			= rate.CustRateGrpCode;
			// 仕入先コード
			dr[SUPPLIERCD]				= rate.SupplierCd;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 仕入先掛率グループコード
			dr[SUPPRATEGRPCODE]			= rate.SuppRateGrpCode;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // ロット数
			dr[LOTCOUNT]				= rate.LotCount;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 単価算出区分
			dr[UNITPRCCALCDIV]			= rate.UnitPrcCalcDiv;
			// 価格区分
			dr[PRICEDIV]				= rate.PriceDiv;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // 価格
			dr[PRICEFL]					= rate.PriceFl;
			// 掛率
			dr[RATEVAL]					= rate.RateVal;
			// 単価端数処理単位
			dr[UNPRCFRACPROCUNIT]		= rate.UnPrcFracProcUnit;
			// 単価端数処理区分
			dr[UNPRCFRACPROCDIV]		= rate.UnPrcFracProcDiv;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 掛率開始日
			dr[RATESTARTDATE]			= rate.RateStartDate;
			// 特売区分コード
			dr[BARGAINCD]				= rate.BargainCd;
			   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
            // 商品掛率グループコード
            dr[GOODSRATEGRPCODE]        = rate.GoodsRateGrpCode;
            // BLグループコード
            dr[BLGLOUPCODE]             = rate.BLGroupCode;
            // UP率
            dr[UPRATE]                  = rate.UpRate;
            // 粗利確保率
            dr[GRSPROFITSECURERATE]     = rate.GrsProfitSecureRate;
            // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<

            // 削除日
            if (rate.LogicalDeleteCode == 0) {
                dr[DELETE_DATE_TITLE] = "";
            }
            else {
                dr[DELETE_DATE_TITLE]	= rate.UpdateDateTimeJpInFormal;
            }
			
            return dr ;
        }
        #endregion

        /// <summary>
        /// クラスメンバー設定処理（掛率設定クラス⇒DataRow）
        /// </summary>
		/// <param name="rateWork">掛率設定クラス</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定ワーククラスから掛率設定クラスへメンバーへの設定を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        private DataRow SetDataRowFromRateWork(DataRow dr, Rate rate)
        {
            // 作成日時
            dr[CREATEDATETIME]			= rate.CreateDateTime;
            // 更新日時
            dr[UPDATEDATETIME]			= rate.UpdateDateTime;
            // 企業コード
            dr[ENTERPRISECODE]			= rate.EnterpriseCode;
			// GUID
            dr[FILEHEADERGUID]			= rate.FileHeaderGuid;
            // 更新従業員コード
            dr[UPDEMPLOYEECODE]			= rate.UpdEmployeeCode;
            // 更新アセンブリID1
            dr[UPDASSEMBLYID1]			= rate.UpdAssemblyId1;
            // 更新アセンブリID2
            dr[UPDASSEMBLYID2]			= rate.UpdAssemblyId2;
            // 論理削除区分
            dr[LOGICALDELETECODE]		= rate.LogicalDeleteCode;
            // 拠点コード
            dr[SECTIONCODE]				= rate.SectionCode;
			// 単価掛率設定区分
			dr[UNITRATESETDIVCD]		= rate.UnitRateSetDivCd;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 新旧区分
			dr[OLDNEWDIVCD]				= rate.OldNewDivCd;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // 単価種類
			dr[UNITPRICEKIND]			= rate.UnitPriceKind;
			// 掛率設定区分
			dr[RATESETTINGDIVIDE]		= rate.RateSettingDivide;
			// 掛率設定区分（商品）
			dr[RATEMNGGOODSCD]			= rate.RateMngGoodsCd;
			// 掛率設定名称（商品）
			dr[RATEMNGGOODSNM]			= rate.RateMngGoodsNm;
			// 掛率設定区分（得意先）
			dr[RATEMNGCUSTCD]			= rate.RateMngCustCd;
			// 掛率設定名称（得意先）
			dr[RATEMNGCUSTNM]			= rate.RateMngCustNm;
			// 商品メーカーコード
			dr[GOODSMAKERCD]			= rate.GoodsMakerCd;
			// 商品番号
			dr[GOODSNO]					= rate.GoodsNo;
			// 商品掛率ランク
			dr[GOODSRATERANK]			= rate.GoodsRateRank;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 商品区分グループコード
			dr[LARGEGOODSGANRECODE]		= rate.LargeGoodsGanreCode;
			// 商品区分コード
			dr[MEDIUMGOODSGANRECODE]	= rate.MediumGoodsGanreCode;
			// 商品区分詳細コード
			dr[DETAILGOODSGANRECODE]	= rate.DetailGoodsGanreCode;
			// 自社分類コード
			dr[ENTERPRISEGANRECODE]		= rate.EnterpriseGanreCode;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // BL商品コード
			dr[BLGOODSCODE]				= rate.BLGoodsCode;
			// 得意先コード
			dr[CUSTOMERCODE]			= rate.CustomerCode;
			// 得意先掛率グループコード
			dr[CUSTRATEGRPCODE]			= rate.CustRateGrpCode;
			// 仕入先コード
			dr[SUPPLIERCD]				= rate.SupplierCd;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 仕入先掛率グループコード
			dr[SUPPRATEGRPCODE]			= rate.SuppRateGrpCode;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // ロット数
			dr[LOTCOUNT]				= rate.LotCount;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 単価算出区分
			dr[UNITPRCCALCDIV]			= rate.UnitPrcCalcDiv;
			// 価格区分
			dr[PRICEDIV]				= rate.PriceDiv;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // 価格
			dr[PRICEFL]					= rate.PriceFl;
			// 掛率
			dr[RATEVAL]					= rate.RateVal;
			// 単価端数処理単位
			dr[UNPRCFRACPROCUNIT]		= rate.UnPrcFracProcUnit;
			// 単価端数処理区分
			dr[UNPRCFRACPROCDIV]		= rate.UnPrcFracProcDiv;
            /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
			// 掛率開始日
			dr[RATESTARTDATE]			= rate.RateStartDate;
			// 特売区分コード
			dr[BARGAINCD]				= rate.BargainCd;
               --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
            // 削除日
			dr[DELETE_DATE_TITLE]		= rate.LogicalDeleteCode;

            // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
            // 商品掛率グループコード
            dr[GOODSRATEGRPCODE]        = rate.GoodsRateGrpCode;
            // BLグループコード
            dr[BLGLOUPCODE]             = rate.BLGroupCode;
            // UP率
            dr[UPRATE]                  = rate.UpRate;
            // 粗利確保率
            dr[GRSPROFITSECURERATE]     = rate.GrsProfitSecureRate;
            // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
			
            return dr ;
        }

        #region SearchProc 検索処理メイン（論理削除含む）
        /// <summary>
        /// 検索処理メイン（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="rate">掛率クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
		private int SearchProc( out DataTable retList
							  , ref Rate rate
							  , ConstantManagement.LogicalMode logicalMode
							  , out string message )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			retList = null;
			message = "";

			try
			{
				//==========================================
				// 掛率マスタ読み込み
				//==========================================
				//------------------------------------------------------------------
				// 単価掛率設定区分作成(単価種類＋掛率設定区分＋新旧区分)
				//   新旧区分を問わず両方取得する場合、単価種類＋掛率設定区分となる
				//------------------------------------------------------------------
				string wkStr = "";
				_stringBuilder.Remove(0, _stringBuilder.Length);
				_stringBuilder.Append(rate.UnitPriceKind);
				_stringBuilder.Append(rate.RateSettingDivide);
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				_stringBuilder.Append(rate.OldNewDivCd);
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                wkStr = _stringBuilder.ToString();

				// 抽出条件パラメータ
				RateWork paraWork = new RateWork();

				paraWork.EnterpriseCode = rate.EnterpriseCode;				// 企業コード
				paraWork.SectionCode = rate.SectionCode;					// 拠点コード
				paraWork.UnitRateSetDivCd = wkStr;							// 単価掛率設定区分
				paraWork.UnitPriceKind = rate.UnitPriceKind;				// 単価種類
				paraWork.RateSettingDivide = rate.RateSettingDivide;		// 掛率設定区分
				paraWork.RateMngGoodsCd = rate.RateMngGoodsCd;				// 掛率設定区分（商品）
				paraWork.RateMngGoodsNm = rate.RateMngGoodsNm;				// 掛率設定名称（商品）
				paraWork.RateMngCustCd = rate.RateMngCustCd;				// 掛率設定区分（得意先）
				paraWork.RateMngCustNm = rate.RateMngCustNm;				// 掛率設定名称（得意先）
				paraWork.GoodsMakerCd = rate.GoodsMakerCd;					// 商品メーカーコード
				paraWork.GoodsNo = rate.GoodsNo;							// 商品番号
				paraWork.GoodsRateRank = rate.GoodsRateRank;				// 商品掛率ランク

                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				paraWork.LargeGoodsGanreCode = rate.LargeGoodsGanreCode;	// 商品区分Ｇコード
				paraWork.MediumGoodsGanreCode = rate.MediumGoodsGanreCode;	// 商品区分コード
				paraWork.DetailGoodsGanreCode = rate.DetailGoodsGanreCode;	// 商品区分詳細コード
				paraWork.EnterpriseGanreCode = rate.EnterpriseGanreCode;	// 自社分類コード
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                
                paraWork.BLGoodsCode = rate.BLGoodsCode;					// ＢＬ商品コード
				paraWork.CustomerCode = rate.CustomerCode;					// 得意先コード
				paraWork.CustRateGrpCode = rate.CustRateGrpCode;			// 得意先掛率Ｇコード
				paraWork.SupplierCd = rate.SupplierCd;						// 仕入先コード

                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				paraWork.SuppRateGrpCode = rate.SuppRateGrpCode;			// 仕入先掛率Ｇコード
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
                paraWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;			// 商品掛率グループコード
                paraWork.BLGroupCode = rate.BLGroupCode;					// BLグループコード
                // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
                
                paraWork.LotCount = -1;										// ロット数（-1:絞込み無し, -1以外:該当ロット数で絞り込み）
				paraWork.LogicalDeleteCode = (int)logicalMode;				// 論理削除区分

				ArrayList paraList = new ArrayList();
				paraList.Add(paraWork);

				// リモート戻りリスト
				object rateWorkList = null;

                // --- CHG 2008/06/18 --------------------------------------------------------------------->>>>>
                ////----- ueno upd ---------- start 2008.01.31
                //// ローカル
                //if (_isLocalDBRead)
                //{
                //    List<RateWork> wkRateWorkList = new List<RateWork>();
                //    status = this._rateLcDB.Search(out wkRateWorkList, paraWork, 0, logicalMode);

                //    if (status == 0)
                //    {
                //        ArrayList al = new ArrayList();
                //        al.AddRange(wkRateWorkList);
                //        rateWorkList = (object)al;
                //    }
                //}
                //// リモート
                //else
                //{
                //    // 掛率マスタ検索
                //    status = this._rateDB.Search(out rateWorkList, paraList, 0, logicalMode);
                //}
                ////----- ueno upd ---------- end 2008.01.31

                // 掛率マスタ検索
                status = this._rateDB.Search(out rateWorkList, paraList, 0, logicalMode);
                // --- CHG 2008/06/18 ---------------------------------------------------------------------<<<<<

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// データテーブルにセット
					foreach (RateWork rateWork in (ArrayList)rateWorkList)
					{
						AddRowFromRateWork(rateWork);
					}
				}

				//==========================================
				// データセットを返す
				//==========================================
				retList = this._dataTableList.Tables[RATE_TABLE];

			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return status;
		}
        #endregion

		#region SearchProc 検索処理メイン（論理削除含む）
		/// <summary>
		/// 検索処理メイン（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果アレイリスト</param>
		/// <param name="rate">掛率クラス</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 検索処理を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.15</br>
		/// </remarks>
		private int SearchProc(out ArrayList retList
							  , ref Rate rate
							  , ConstantManagement.LogicalMode logicalMode
							  , out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			retList = new ArrayList();
			message = "";
			
			try
			{
				ArrayList wkList = new ArrayList();
				
				//==========================================
				// 掛率マスタ読み込み
				//==========================================
				//------------------------------------------------------------------
				// 単価掛率設定区分作成(単価種類＋掛率設定区分＋新旧区分)
				//   新旧区分を問わず両方取得する場合、単価種類＋掛率設定区分となる
				//------------------------------------------------------------------
				string wkStr = "";
				_stringBuilder.Remove(0, _stringBuilder.Length);
				_stringBuilder.Append(rate.UnitPriceKind);
				_stringBuilder.Append(rate.RateSettingDivide);
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				_stringBuilder.Append(rate.OldNewDivCd);
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                wkStr = _stringBuilder.ToString();

				// 抽出条件パラメータ
				RateWork paraWork = new RateWork();

				paraWork.EnterpriseCode = rate.EnterpriseCode;				// 企業コード
				paraWork.SectionCode = rate.SectionCode;					// 拠点コード
				paraWork.UnitRateSetDivCd = wkStr;							// 単価掛率設定区分
				paraWork.UnitPriceKind = rate.UnitPriceKind;				// 単価種類
				paraWork.RateSettingDivide = rate.RateSettingDivide;		// 掛率設定区分
				paraWork.RateMngGoodsCd = rate.RateMngGoodsCd;				// 掛率設定区分（商品）
				paraWork.RateMngGoodsNm = rate.RateMngGoodsNm;				// 掛率設定名称（商品）
				paraWork.RateMngCustCd = rate.RateMngCustCd;				// 掛率設定区分（得意先）
				paraWork.RateMngCustNm = rate.RateMngCustNm;				// 掛率設定名称（得意先）
				paraWork.GoodsMakerCd = rate.GoodsMakerCd;					// 商品メーカーコード
				paraWork.GoodsNo = rate.GoodsNo;							// 商品番号
				paraWork.GoodsRateRank = rate.GoodsRateRank;				// 商品掛率ランク

                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				paraWork.LargeGoodsGanreCode = rate.LargeGoodsGanreCode;	// 商品区分Ｇコード
				paraWork.MediumGoodsGanreCode = rate.MediumGoodsGanreCode;	// 商品区分コード
				paraWork.DetailGoodsGanreCode = rate.DetailGoodsGanreCode;	// 商品区分詳細コード
				paraWork.EnterpriseGanreCode = rate.EnterpriseGanreCode;	// 自社分類コード
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                
                paraWork.BLGoodsCode = rate.BLGoodsCode;					// ＢＬ商品コード
				paraWork.CustomerCode = rate.CustomerCode;					// 得意先コード
				paraWork.CustRateGrpCode = rate.CustRateGrpCode;			// 得意先掛率Ｇコード
				paraWork.SupplierCd = rate.SupplierCd;						// 仕入先コード

                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				paraWork.SuppRateGrpCode = rate.SuppRateGrpCode;			// 仕入先掛率Ｇコード
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
                paraWork.GoodsRateGrpCode= rate.GoodsRateGrpCode;			// 商品掛率グループコード
                paraWork.BLGroupCode = rate.BLGroupCode;					// BLグループコード
                // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
                
                paraWork.LotCount = rate.LotCount;							// ロット数（-1:絞込み無し, -1以外:該当ロット数で絞り込み）
				
				ArrayList paraList = new ArrayList();
				paraList.Add(paraWork);

				// リモート戻りリスト
				object rateWorkList = null;

                // --- CHG 2008/06/18 --------------------------------------------------------------------->>>>>
                ////----- ueno upd ---------- start 2008.01.31
                //// ローカル
                //if (_isLocalDBRead)
                //{
                //    List<RateWork> wkRateWorkList = new List<RateWork>();
                //    status = this._rateLcDB.Search(out wkRateWorkList, paraWork, 0, logicalMode);

                //    if (status == 0)
                //    {
                //        ArrayList al = new ArrayList();
                //        al.AddRange(wkRateWorkList);
                //        rateWorkList = (object)al;
                //    }
                //}
                //// リモート
                //else
                //{
                //    // 掛率マスタ検索
                //    status = this._rateDB.Search(out rateWorkList, paraList, 0, logicalMode);
                //}
                ////----- ueno upd ---------- end 2008.01.31

                // 掛率マスタ検索
                status = this._rateDB.Search(out rateWorkList, paraList, 0, logicalMode);
                // --- CHG 2008/06/18 ---------------------------------------------------------------------<<<<<

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					wkList = rateWorkList as ArrayList;
					if(wkList != null)
					{
						foreach(RateWork wkRateWork in wkList)
						{
							// メンバコピー
							retList.Add(CopyToRateFromRateWork(wkRateWork));
						}
					}
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return status;
		}
		#endregion

		#region SearchProc 検索処理メイン（論理削除含む）
		/// <summary>
		/// 検索処理メイン（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果テーブル</param>
		/// <param name="rateList">掛率オブジェクトリスト</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 掛率マスタの複数検索処理を行います。</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2007.11.17</br>
		/// </remarks>
		private int SearchProc( out DataTable retList
							 , List<Rate> rateList
							 , ConstantManagement.LogicalMode logicalMode
							 , out string message )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			retList = null;
			message = "";

			try
			{
				ArrayList paraList = new ArrayList();
				//==========================================
				// 掛率マスタ読み込み
				//==========================================
				foreach (Rate rate in rateList)
				{
					//------------------------------------------------------------------
					// 単価掛率設定区分作成(単価種類＋掛率設定区分＋新旧区分)
					//   新旧区分を問わず両方取得する場合、単価種類＋掛率設定区分となる
					//------------------------------------------------------------------
					string wkStr = "";
					_stringBuilder.Remove(0, _stringBuilder.Length);
					_stringBuilder.Append(rate.UnitPriceKind);
					_stringBuilder.Append(rate.RateSettingDivide);
                    /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
					_stringBuilder.Append(rate.OldNewDivCd);
                       --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                    wkStr = _stringBuilder.ToString();

					// 抽出条件パラメータ
					RateWork paraWork = new RateWork();

					paraWork.EnterpriseCode = rate.EnterpriseCode;				// 企業コード
					paraWork.SectionCode = rate.SectionCode;					// 拠点コード
					paraWork.UnitRateSetDivCd = wkStr;							// 単価掛率設定区分
					paraWork.UnitPriceKind = rate.UnitPriceKind;				// 単価種類
					paraWork.RateSettingDivide = rate.RateSettingDivide;		// 掛率設定区分
					paraWork.RateMngGoodsCd = rate.RateMngGoodsCd;				// 掛率設定区分（商品）
					paraWork.RateMngGoodsNm = rate.RateMngGoodsNm;				// 掛率設定名称（商品）
					paraWork.RateMngCustCd = rate.RateMngCustCd;				// 掛率設定区分（得意先）
					paraWork.RateMngCustNm = rate.RateMngCustNm;				// 掛率設定名称（得意先）
					paraWork.GoodsMakerCd = rate.GoodsMakerCd;					// 商品メーカーコード
					paraWork.GoodsNo = rate.GoodsNo;							// 商品番号
					paraWork.GoodsRateRank = rate.GoodsRateRank;				// 商品掛率ランク

                    /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
					paraWork.LargeGoodsGanreCode = rate.LargeGoodsGanreCode;	// 商品区分Ｇコード
					paraWork.MediumGoodsGanreCode = rate.MediumGoodsGanreCode;	// 商品区分コード
					paraWork.DetailGoodsGanreCode = rate.DetailGoodsGanreCode;	// 商品区分詳細コード
					paraWork.EnterpriseGanreCode = rate.EnterpriseGanreCode;	// 自社分類コード
                       --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                    
                    paraWork.BLGoodsCode = rate.BLGoodsCode;					// ＢＬ商品コード
					paraWork.CustomerCode = rate.CustomerCode;					// 得意先コード
					paraWork.CustRateGrpCode = rate.CustRateGrpCode;			// 得意先掛率Ｇコード
					paraWork.SupplierCd = rate.SupplierCd;						// 仕入先コード

                    /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
                    paraWork.SuppRateGrpCode = rate.SuppRateGrpCode;			// 仕入先掛率Ｇコード
                       --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

                    // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
                    paraWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;			// 商品掛率グループコード
                    paraWork.BLGroupCode = rate.BLGroupCode;					// BLグループコード
                    // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
                    
                    paraWork.LotCount = -1;										// ロット数（-1:絞込み無し, -1以外:該当ロット数で絞り込み）

					paraList.Add(paraWork);
				}

				// リモート戻りリスト
				object rateWorkList = null;

                // --- CHG 2008/06/18 --------------------------------------------------------------------->>>>>
                ////----- ueno upd ---------- start 2008.01.31
                //// ローカル
                //if (_isLocalDBRead)
                //{
                //    List<RateWork> wkRateWorkList = new List<RateWork>();

                //    ArrayList al = new ArrayList();

                //    int wkStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
					
                //    foreach(RateWork rateWork in paraList)
                //    {
                //        wkStatus = this._rateLcDB.Search(out wkRateWorkList, rateWork, 0, logicalMode);

                //        if (wkStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //        {
                //            al.AddRange(wkRateWorkList);
                //        }
                //        //----- ueno add ---------- start 2008.02.18
                //        // エラーの場合、ステータスをエラーを設定し、処理を抜ける
                //        else if(wkStatus == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                //        {
                //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //            break;
                //        }
                //        //----- ueno add ---------- end 2008.02.18
                //    }
					
                //    //----- ueno upd ---------- start 2008.02.18
                //    if(wkStatus != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                //    {
                //        // 1件以上ヒットする場合
                //        if (al.Count > 0)
                //        {
                //            rateWorkList = (object)al;
                //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //        }
                //        // 0件の場合
                //        else
                //        {
                //            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //        }
                //    }
                //    //----- ueno upd ---------- end 2008.02.18
                //}
                //// リモート
                //else
                //{
                //    // 掛率マスタ検索
                //    status = this._rateDB.Search(out rateWorkList, paraList, 0, logicalMode);
                //}
                ////----- ueno upd ---------- end 2008.01.31

                // 掛率マスタ検索
                status = this._rateDB.Search(out rateWorkList, paraList, 0, logicalMode);
                // --- CHG 2008/06/18 ---------------------------------------------------------------------<<<<<

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// データテーブルにセット
					foreach (RateWork rateWork in (ArrayList)rateWorkList)
					{
						AddRowFromRateWork(rateWork);
					}
				}

				//==========================================
				// データセットを返す
				//==========================================
				retList = this._dataTableList.Tables[RATE_TABLE];

			}
			catch (Exception ex)
			{
				message = ex.Message;
			}
			return status;
		}
		#endregion

		/// <summary>
        /// 掛率マスタ　→　データテーブル　追加処理
        /// </summary>
        /// <param name="rateWork"></param>
        private void AddRowFromRateWork( RateWork rateWork )
        {
            DataRow dr;

            try
			{
				// 掛率グリッド
				dr = CopyToDataRowFromRateWork(ref rateWork);
				this._dataTableList.Tables[RATE_TABLE].Rows.Add(dr);
            }
            catch(Exception)
            {
            }
		}

		#region Read 検索処理
		/// <summary>
        /// 掛率レコード取得処理
        /// </summary>
        /// <param name="rate">掛率データ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 検索処理を行います。
		///                  rateクラスに検索データを設定し、結果もrateクラスに格納します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.31</br>
		/// </remarks>
        public int Read( ref Rate rate ) 
        {
            try
            {
				int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                RateWork rateWork = new RateWork();

				// 検索データ加工(単価種類＋掛率設定区分＋新旧区分)
				string wkStr = "";
				_stringBuilder.Remove(0, _stringBuilder.Length);
				_stringBuilder.Append(rate.UnitPriceKind);
				_stringBuilder.Append(rate.RateSettingDivide);
                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				_stringBuilder.Append(rate.OldNewDivCd);
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                wkStr = _stringBuilder.ToString();
				
				// 抽出条件パラメータ
				rateWork.EnterpriseCode			= rate.EnterpriseCode;			// 企業コード
				rateWork.SectionCode			= rate.SectionCode;				// 拠点コード
				rateWork.UnitRateSetDivCd		= wkStr;						// 単価掛率設定区分

                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				rateWork.OldNewDivCd			= rate.OldNewDivCd;				// 新旧区分
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                
                rateWork.UnitPriceKind			= rate.UnitPriceKind;			// 単価種類
				rateWork.RateSettingDivide		= rate.RateSettingDivide;		// 掛率設定区分
				rateWork.RateMngGoodsCd			= rate.RateMngGoodsCd;			// 掛率設定区分（商品）
				rateWork.RateMngGoodsNm			= rate.RateMngGoodsNm;			// 掛率設定名称（商品）
				rateWork.RateMngCustCd			= rate.RateMngCustCd;			// 掛率設定区分（得意先）
				rateWork.RateMngCustNm			= rate.RateMngCustNm;			// 掛率設定名称（得意先）
				rateWork.GoodsMakerCd			= rate.GoodsMakerCd;			// 商品メーカーコード
				rateWork.GoodsNo				= rate.GoodsNo;					// 商品番号
				rateWork.GoodsRateRank			= rate.GoodsRateRank;			// 商品掛率ランク

                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				rateWork.LargeGoodsGanreCode	= rate.LargeGoodsGanreCode;		// 商品区分Ｇコード
				rateWork.MediumGoodsGanreCode	= rate.MediumGoodsGanreCode;	// 商品区分コード
				rateWork.DetailGoodsGanreCode	= rate.DetailGoodsGanreCode;	// 商品区分詳細コード
				rateWork.EnterpriseGanreCode	= rate.EnterpriseGanreCode;		// 自社分類コード
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
                
                rateWork.BLGoodsCode			= rate.BLGoodsCode;				// ＢＬ商品コード
				rateWork.CustomerCode			= rate.CustomerCode;			// 得意先コード
				rateWork.CustRateGrpCode		= rate.CustRateGrpCode;			// 得意先掛率Ｇコード
				rateWork.SupplierCd				= rate.SupplierCd;				// 仕入先コード

                /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
				rateWork.SuppRateGrpCode		= rate.SuppRateGrpCode;			// 仕入先掛率Ｇコード
                   --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

                // --- ADD 2008/06/18 --------------------------------------------------------------------->>>>>
                rateWork.GoodsRateGrpCode       = rate.GoodsRateGrpCode;		// 商品掛率グループコード
                rateWork.BLGroupCode            = rate.BLGroupCode;				// BLグループコード
                // --- ADD 2008/06/18 ---------------------------------------------------------------------<<<<<
                
                // --- CHG 2008/06/18 --------------------------------------------------------------------->>>>>
                ////----- ueno upd ---------- start 2008.01.31
                //// ローカル
                //if (_isLocalDBRead)
                //{
                //    status = this._rateLcDB.Read(ref rateWork, 0);
                //}
                //// リモート
                //else
                //{
                //    // XMLへ変換し、文字列のバイナリ化
                //    byte[] parabyte = XmlByteSerializer.Serialize(rateWork);
                //    status = this._rateDB.Read(ref parabyte, 0);

                //    if ( status == 0 )
                //    {
                //        // XMLの読み込み
                //        rateWork = ( RateWork ) XmlByteSerializer.Deserialize(parabyte, typeof(RateWork));

                //        //// クラス内メンバコピー
                //        //rate = CopyToRateFromRateWork(rateWork);
                //    }
                //}

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(rateWork);
                status = this._rateDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XMLの読み込み
                    rateWork = (RateWork)XmlByteSerializer.Deserialize(parabyte, typeof(RateWork));
                }
                // --- CHG 2008/06/18 ---------------------------------------------------------------------<<<<<

				if ( status == 0 )
				{
					// クラス内メンバコピー
					rate = CopyToRateFromRateWork(rateWork);
				}
				//----- ueno upd ---------- end 2008.01.31

                return status;
            }
            catch ( Exception ) {
                //通信エラーは-1を戻す
                rate = null;
                //オフライン時はnullをセット
                this._rateDB = null;
                return -1;
            }
        }
        #endregion
    }
}

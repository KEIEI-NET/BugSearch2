using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 結合マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 結合マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class JoinPartsSetAcs 
	{
        #region public関連
        /// <summary>商品連結データ保持用</summary>
        public struct F_DATA_GOODSUNIT
        {
            /// <summary>結合先メーカーコード</summary>
            public int joinDestMakerCd;
            /// <summary>結合先品番</summary>
            public string joinDestPartsNo;
        }

        /// <summary>
        /// 商品マスタアクセスを取得します。
        /// </summary>
        /// <value>商品マスタアクセス</value>
        public GoodsAcsProxy GoodsAccess
        {
            get { return (GoodsAcsProxy)_goodsAcs; }
        }
        #endregion

        private static bool _isLocalDBRead = false;

        /// <summary>商品セットリモートオブジェクト格納バッファ</summary>
        private IJoinPartsUDB _iGoodsSetDB;

        private Dictionary<int, MakerUMnt> _MakerDic;
        private MakerAcs _makerAcs;

        /// <summary>商品マスタアクセス</summary>
        private readonly GoodsAcs _goodsAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 結合マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 結合マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public JoinPartsSetAcs()
		{
            this._iGoodsSetDB = (IJoinPartsUDB)MediationJoinPartsUDB.GetJoinPartsUDB();
            this._makerAcs = new MakerAcs();
            this._goodsAcs = new GoodsAcsProxy();
        }

        

        /// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}

	

		/// <summary>
		/// 結合マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 結合マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, JoinPartsPrintWork joinPartsPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, joinPartsPrintWork);
		}

		/// <summary>
		/// 結合マスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 結合マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, JoinPartsPrintWork joinPartsPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, joinPartsPrintWork);
		}

		

		/// <summary>
		/// 結合マスタ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="sectionPrintWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 結合マスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, JoinPartsPrintWork joinPartsPrintWork)
		{

            JoinPartsUWork goodsSetWork = new JoinPartsUWork();
            goodsSetWork.EnterpriseCode = enterpriseCode;

            int status = 0;
            int checkstatus = 0;
            nextData = false;
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList paraList = new ArrayList();
            paraList.Clear();

            object paraobj = goodsSetWork;
            object retobj = new ArrayList();

            status = this._iGoodsSetDB.Search(ref retobj, paraobj, 0, logicalMode);

            paraList = retobj as ArrayList;

            // [[結合情報キャッシュ]]
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            List<GoodsUnitData> goodsUnitDataList;
            string strMsg;
            string goodName;

            foreach (JoinPartsUWork joinPartsUWork in paraList)
            {
                // 抽出処理
                checkstatus = DataCheck(joinPartsUWork, joinPartsPrintWork);
                if (checkstatus == 0)
                {
                    goodName ="";
                    goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;  // 企業コード
                    goodsCndtn.GoodsMakerCd = joinPartsUWork.JoinDestMakerCd;         // 結合先メーカーコード
                    goodsCndtn.GoodsNo = joinPartsUWork.JoinDestPartsNo;              // 結合先品番

                    // 商品連結データを検索
                    int parStatus = GoodsAccess.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out strMsg);

                    if (parStatus == 0)
                    {
                        goodName = goodsUnitDataList[0].GoodsName;
                    }

                    //結合情報クラスへメンバコピー
                    retList.Add(CopyToJoinPartsSetFromSecInfoSetWork(joinPartsUWork, enterpriseCode, goodName));
                }

            }

           
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（結合マスタワーククラス⇒結合マスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">結合マスタワーククラス</param>
        /// <returns>結合マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 結合マスタワーククラスから結合マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private JoinPartsSet CopyToJoinPartsSetFromSecInfoSetWork(JoinPartsUWork joinPartsUWork, string enterpriseCode, string goodName)
        {

            JoinPartsSet joinPartsSet = new JoinPartsSet();

            joinPartsSet.JoinSourceMakerCode = joinPartsUWork.JoinSourceMakerCode;
            joinPartsSet.JoinSourceMakerName = GetMakerName(joinPartsUWork.JoinSourceMakerCode, enterpriseCode);
            joinPartsSet.JoinSourPartsNoWithH = joinPartsUWork.JoinSourPartsNoWithH;
            joinPartsSet.GoodsNameKana = goodName;
            joinPartsSet.JoinDispOrder = joinPartsUWork.JoinDispOrder;
            joinPartsSet.JoinDestPartsNo = joinPartsUWork.JoinDestPartsNo;
            joinPartsSet.JoinDestMakerCd = joinPartsUWork.JoinDestMakerCd;
            joinPartsSet.JoinDestMakerName = GetMakerName(joinPartsUWork.JoinDestMakerCd, enterpriseCode);
            joinPartsSet.JoinQty = joinPartsUWork.JoinQty;

            return joinPartsSet;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// </remarks>
        private string GetMakerName(int makerCode, string enterpriseCode)
        {
            string makerName = "";
            ReadMaker(enterpriseCode);
            if (this._MakerDic.ContainsKey(makerCode))
            {
                makerName = this._MakerDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// メーカー読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカー一覧を読み込みます。</br>
        /// </remarks>
        private void ReadMaker(string enterpriseCode)
        {
            try
            {
                if (this._MakerDic.Count == 0)
                {
                    this._MakerDic = new Dictionary<int, MakerUMnt>();

                    ArrayList retList;

                    int status = this._makerAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (MakerUMnt mkerUMnt in retList)
                        {
                            if (mkerUMnt.LogicalDeleteCode == 0)
                            {
                                this._MakerDic.Add(mkerUMnt.GoodsMakerCd, mkerUMnt);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._MakerDic = new Dictionary<int, MakerUMnt>();

                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt mkerUMnt in retList)
                    {
                        if (mkerUMnt.LogicalDeleteCode == 0)
                        {
                            this._MakerDic.Add(mkerUMnt.GoodsMakerCd, mkerUMnt);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(JoinPartsUWork joinPartsUWork, JoinPartsPrintWork joinPartsPrintWork)
        {
            int status = 0;

            if (joinPartsUWork.LogicalDeleteCode != joinPartsPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = joinPartsUWork.UpdateDateTime.Year.ToString("0000") +
                                joinPartsUWork.UpdateDateTime.Month.ToString("00") +
                                joinPartsUWork.UpdateDateTime.Day.ToString("00");

            if (joinPartsPrintWork.LogicalDeleteCode == 1 &&
                joinPartsPrintWork.DeleteDateTimeSt != 0 &&
                joinPartsPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < joinPartsPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > joinPartsPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.LogicalDeleteCode == 1 &&
                        joinPartsPrintWork.DeleteDateTimeSt != 0 &&
                        joinPartsPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < joinPartsPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.LogicalDeleteCode == 1 &&
                joinPartsPrintWork.DeleteDateTimeSt == 0 &&
                joinPartsPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > joinPartsPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (joinPartsPrintWork.JoinSourceMakerCodeSt != 0 &&
                joinPartsPrintWork.JoinSourceMakerCodeEd != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode < joinPartsPrintWork.JoinSourceMakerCodeSt ||
                   joinPartsUWork.JoinSourceMakerCode > joinPartsPrintWork.JoinSourceMakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.JoinSourceMakerCodeSt != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode < joinPartsPrintWork.JoinSourceMakerCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (joinPartsPrintWork.JoinSourceMakerCodeEd != 0)
            {
                if (joinPartsUWork.JoinSourceMakerCode > joinPartsPrintWork.JoinSourceMakerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            if (!joinPartsPrintWork.JoinSourPartsNoWithHSt.Trim().Equals(string.Empty) &&
                !joinPartsPrintWork.JoinSourPartsNoWithHEd.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHSt.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) > 0 ||
                    joinPartsPrintWork.JoinSourPartsNoWithHEd.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!joinPartsPrintWork.JoinSourPartsNoWithHSt.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHSt.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!joinPartsPrintWork.JoinSourPartsNoWithHEd.Trim().Equals(string.Empty))
            {
                if (joinPartsPrintWork.JoinSourPartsNoWithHEd.CompareTo(joinPartsUWork.JoinSourPartsNoWithH) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
    }


    #region <商品連結データアクセスのプロキシ/>

    /// <summary>
    /// 商品連結データアクセスクラスのプロキシクラス
    /// </summary>
    public sealed class GoodsAcsProxy : GoodsAcs
    {
        #region <本物の商品連結データアクセス/>

        /// <summary>本物の商品連結データアクセス</summary>
        private GoodsAcs _realGoodsAcs;
        /// <summary>
        /// 本物の商品連結データアクセスを取得します。
        /// </summary>
        /// <value>本物の商品連結データアクセス</value>
        public GoodsAcs RealGoodsAcs
        {
            get
            {
                if (_realGoodsAcs == null)
                {
                    _realGoodsAcs = new GoodsAcs();
                }
                return _realGoodsAcs;
            }
        }

        #endregion  // <本物の商品連結データアクセス/>

        #region <商品連結データのキャッシュ/>

        /// <summary>商品連結データハッシュテーブル</summary>
        private readonly Hashtable _goodsUnitDataHashTable = new Hashtable();
        /// <summary>
        /// 商品連結データハッシュテーブルを取得します。
        /// </summary>
        /// <remarks>
        /// key：<c>JoinPartsUAcs.F_DATA_GOODSUNIT</c>
        /// val：<c>GoodsUnitData</c>
        /// </remarks>
        /// <value>商品連結データハッシュテーブル</value>
        public Hashtable GoodsUnitDataHashTable
        {
            get { return _goodsUnitDataHashTable; }
        }

        #endregion  // <商品連結データのキャッシュ/>

        #region <Constructor/>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public GoodsAcsProxy() : base() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 結合検索無しで品番を検索します。
        /// </summary>
        /// <remarks>
        /// 商品連結データHashtable登録処理も同時に行います。
        /// </remarks>
        /// <param name="goodsCondition">検索条件</param>
        /// <param name="goodsUnitDataList">検索された商品連結データリスト</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>結果コード</returns>
        new public int SearchPartsFromGoodsNoNonVariousSearch(
            GoodsCndtn goodsCondition,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg
        )
        {
            int status = RealGoodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCondition, out goodsUnitDataList, out msg);

            // 商品情報キャッシュ
            if (goodsUnitDataList != null && goodsUnitDataList.Count > 0)
            {
                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    SetGoodsUnitData(goodsUnitData);
                }
            }

            return status;
        }

        /// <summary>
        /// 商品連結データHashtable登録処理
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <see cref="JoinPartsUAcs"/>
        private void SetGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            JoinPartsSetAcs.F_DATA_GOODSUNIT dataGoodsUnit = new JoinPartsSetAcs.F_DATA_GOODSUNIT();

            dataGoodsUnit.joinDestMakerCd = goodsUnitData.GoodsMakerCd;  // 結合先メーカーコード
            dataGoodsUnit.joinDestPartsNo = goodsUnitData.GoodsNo;       // 結合先品番

            if (GoodsUnitDataHashTable.ContainsKey(dataGoodsUnit))
            {
                GoodsUnitDataHashTable.Remove(dataGoodsUnit);    // MEMO:削除する理由は？on操作で更新等があるため？
            }

            // 商品連結データ登録
            GoodsUnitDataHashTable.Add(dataGoodsUnit, goodsUnitData);
        }

        /// <summary>値が選択されなかったときの結果コード</summary>
        public const int DB_RESULT_OF_NOT_SELECTED_VALUE = -1;

        /// <summary>
        /// 結合マスタにおける品番の種別の列挙体
        /// </summary>
        public enum JoinedGoodsNoType : int
        {
            /// <summary>親（結合元）</summary>
            Parent,
            /// <summary>子（結合先）</summary>
            Child
        }

        /// <summary>
        /// 品番検索（結合検索有り完全一致）を実行し、結合・セット・代替情報を取得します。
        /// </summary>
        /// <remarks>
        /// 品番検索（結合検索無し）を実行し、品番・メーカーを確定した後に、結合検索有り完全一致の検索を行います。
        /// </remarks>
        /// <param name="goodsCondition">検索条件</param>
        /// <param name="partsInfoDataSet">検索された部品情報のデータセット</param>
        /// <param name="goodsUnitDataList">検索された商品連結データのリスト</param>
        /// <param name="message">メッセージ</param>
        /// <param name="joinedGoodsNoType">結合マスタにおける品番の種別</param>
        /// <returns>結果コード</returns>
        public int SearchPartsFromGoodsNoWholeWordBeforeSearchingPartsFromGoodsNoNonVariousSearch(
            GoodsCndtn goodsCondition,
            out PartsInfoDataSet partsInfoDataSet,
            out List<GoodsUnitData> goodsUnitDataList,
            out string message,
            JoinedGoodsNoType joinedGoodsNoType
        )
        {
            partsInfoDataSet = new PartsInfoDataSet();

            // 品番検索（結合検索無し）を実行し、品番・メーカーを確定する。
            int status = this.SearchPartsFromGoodsNoNonVariousSearch(goodsCondition, out goodsUnitDataList, out message);
            if (!status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL)) return status;

            if (joinedGoodsNoType.Equals(JoinedGoodsNoType.Child) && goodsUnitDataList != null && goodsUnitDataList.Count > 0)
            {
                return status;  // 子（結合先）の場合、ここで処理は終了
            }

            // 品番検索（結合検索有り完全一致）を実行し、結合・セット・代替情報を取得する。
            GoodsCndtn goodsConditionOfWholeWord = goodsCondition.Clone();
            if (goodsUnitDataList != null && goodsUnitDataList.Count > 0)
            {
                goodsConditionOfWholeWord.GoodsNo = goodsUnitDataList[0].GoodsNo;
            }

            return RealGoodsAcs.SearchPartsFromGoodsNoWholeWord(
                goodsConditionOfWholeWord,
                out partsInfoDataSet,
                out goodsUnitDataList,
                out message
            );
        }
    }

    #endregion  // <商品連結データアクセスのプロキシ/>
}

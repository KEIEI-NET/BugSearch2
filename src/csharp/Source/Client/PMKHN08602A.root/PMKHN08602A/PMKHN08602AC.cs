using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＢＬグループマスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＢＬグループマスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class BLGroupSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private BLGroupUAcs _bLGroupUAcs;

        private Dictionary<int, UserGdBd> _salesCodeDic;
        private Dictionary<int, UserGdBd> _goodsLGroupDic;
        private UserGuideAcs _userGuideAcs;

        private Dictionary<int, GoodsGroupU> _goodsGroupDic;
        private GoodsGroupUAcs _goodsGroupUAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// ＢＬグループマスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : ＢＬグループマスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public BLGroupSetAcs()
		{
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
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
		/// ＢＬグループマスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ＢＬグループマスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, BLGroupPrintWork bLGroupPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, bLGroupPrintWork);
		}

		/// <summary>
		/// ＢＬグループマスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ＢＬグループマスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, BLGroupPrintWork bLGroupPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, bLGroupPrintWork);
		}

		

		/// <summary>
		/// ＢＬグループマスタ検索処理
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
		/// <br>Note       : ＢＬグループマスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, BLGroupPrintWork bLGroupPrintWork)
		{

            this._bLGroupUAcs = new BLGroupUAcs();

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList bLGroupUs = null;

            status = this._bLGroupUAcs.SearchAll(
                                out bLGroupUs,
                                enterpriseCode);

            foreach (BLGroupU bLGroupU in bLGroupUs)
            {
                // 抽出処理
                checkstatus = DataCheck(bLGroupU, bLGroupPrintWork);
                if (checkstatus == 0)
                {

                    //ＢＬグループ情報クラスへメンバコピー
                    retList.Add(CopyToMakerSetFromSecInfoSetWork(bLGroupU, enterpriseCode));

                }
            }


            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（ＢＬグループマスタワーククラス⇒ＢＬグループマスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">ＢＬグループマスタワーククラス</param>
        /// <returns>ＢＬグループマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : ＢＬグループマスタワーククラスからＢＬグループマスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private BLGroupSet CopyToMakerSetFromSecInfoSetWork(BLGroupU bLGroupU, string enterpriseCode)
        {

            BLGroupSet bLGroupSet = new BLGroupSet();

            bLGroupSet.BLGroupCode = bLGroupU.BLGroupCode;
            bLGroupSet.BLGroupName = bLGroupU.BLGroupName;
            bLGroupSet.BLGroupKanaName = bLGroupU.BLGroupKanaName;
            bLGroupSet.SalesCode = bLGroupU.SalesCode;
            bLGroupSet.SalesCodeName = GetSalesCodeName(bLGroupU.SalesCode, enterpriseCode);
            bLGroupSet.GoodsLGroup = bLGroupU.GoodsLGroup;
            bLGroupSet.GoodsLGroupName = GetGoodsLGroupName(bLGroupU.GoodsLGroup, enterpriseCode);
            bLGroupSet.GoodsMGroup = bLGroupU.GoodsMGroup;
            bLGroupSet.GoodsMGroupName = GetGoodsMGroupName(bLGroupU.GoodsMGroup, enterpriseCode);


            return bLGroupSet;
        }

        /// <summary>
        /// 販売区分名称取得処理
        /// </summary>
        /// <param name="salesCode">販売区分コード</param>
        /// <remarks>
        /// <br>Note       : 販売区分名称を取得します。</br>
        /// </remarks>
        private string GetSalesCodeName(int salesCode, string enterpriseCode)
        {
            string salesCodeName = "";
            ReadSalesCode(enterpriseCode);
            if (this._salesCodeDic.ContainsKey(salesCode))
            {
                salesCodeName = this._salesCodeDic[salesCode].GuideName.Trim();
            }

            return salesCodeName;
        }


        /// <summary>
        /// 販売区分読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 販売区分一覧を読み込みます。</br>
        /// </remarks>
        private void ReadSalesCode(string enterpriseCode)
        {
            try
            {
                if (this._salesCodeDic.Count == 0)
                {
                    this._salesCodeDic = new Dictionary<int, UserGdBd>();

                    ArrayList retList;

                    // ユーザーガイドデータ取得(販売区分)
                    int status = GetUserGuideBd(out retList, 71, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (UserGdBd userGdBd in retList)
                        {
                            if (userGdBd.LogicalDeleteCode == 0)
                            {
                                this._salesCodeDic.Add(userGdBd.GuideCode, userGdBd);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._salesCodeDic = new Dictionary<int, UserGdBd>();

                ArrayList retList;

                // ユーザーガイドデータ取得(販売区分)
                int status = GetUserGuideBd(out retList, 71, enterpriseCode);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._salesCodeDic.Add(userGdBd.GuideCode, userGdBd);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// 商品大分類名称取得処理
        /// </summary>
        /// <param name="goodsLGroupCode">商品大分類コード</param>
        /// <remarks>
        /// <br>Note       : 商品大分類名称を取得します。</br>
        /// </remarks>
        private string GetGoodsLGroupName(int goodsLGroupCode, string enterpriseCode)
        {
            string goodsLGroupName = "";
            ReadGoodsLGroup(enterpriseCode);
            if (this._goodsLGroupDic.ContainsKey(goodsLGroupCode))
            {
                goodsLGroupName = this._goodsLGroupDic[goodsLGroupCode].GuideName.Trim();
            }

            return goodsLGroupName;
        }

        /// <summary>
        /// 商品大分類読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品大分類一覧を読み込みます。</br>
        /// </remarks>
        private void ReadGoodsLGroup(string enterpriseCode)
        {
            try
            {
                if (this._goodsLGroupDic.Count == 0)
                {
                    this._goodsLGroupDic = new Dictionary<int, UserGdBd>();

                    ArrayList retList;

                    // ユーザーガイドデータ取得(商品大分類)
                    int status = GetUserGuideBd(out retList, 70, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (UserGdBd userGdBd in retList)
                        {
                            if (userGdBd.LogicalDeleteCode == 0)
                            {
                                this._goodsLGroupDic.Add(userGdBd.GuideCode, userGdBd);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._goodsLGroupDic = new Dictionary<int, UserGdBd>();

                ArrayList retList;

                // ユーザーガイドデータ取得(商品大分類)
                int status = GetUserGuideBd(out retList, 70, enterpriseCode);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._goodsLGroupDic.Add(userGdBd.GuideCode, userGdBd);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// ユーザーガイドデータ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ユーザーガイドデータを取得します。</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd, string enterpriseCode)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, enterpriseCode,
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// 商品中分類名称取得処理
        /// </summary>
        /// <param name="goodsMGroupCode">商品中分類コード</param>
        /// <remarks>
        /// <br>Note       : 商品中分類名称を取得します。</br>
        /// </remarks>
        private string GetGoodsMGroupName(int goodsMGroupCode, string enterpriseCode)
        {
            string goodsMGroupName = "";
            ReadGoodsMGroup(enterpriseCode);
            if (this._goodsGroupDic.ContainsKey(goodsMGroupCode))
            {
                goodsMGroupName = this._goodsGroupDic[goodsMGroupCode].GoodsMGroupName.Trim();
            }

            return goodsMGroupName;
        }

        /// <summary>
        /// 商品中分類読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品中分類一覧を読み込みます。</br>
        /// </remarks>
        private void ReadGoodsMGroup(string enterpriseCode)
        {
            try
            {
                if (this._goodsGroupDic.Count == 0)
                {
                    this._goodsGroupDic = new Dictionary<int, GoodsGroupU>();

                    ArrayList retList;

                    int status = this._goodsGroupUAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (GoodsGroupU goodsGroupU in retList)
                        {
                            if (goodsGroupU.LogicalDeleteCode == 0)
                            {
                                this._goodsGroupDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupDic = new Dictionary<int, GoodsGroupU>();

                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
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
        private int DataCheck(BLGroupU bLGroupU, BLGroupPrintWork bLGroupPrintWork)
        {
            int status = 0;

            if (bLGroupU.LogicalDeleteCode != bLGroupPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = bLGroupU.UpdateDateTime.Year.ToString("0000") +
                                bLGroupU.UpdateDateTime.Month.ToString("00") +
                                bLGroupU.UpdateDateTime.Day.ToString("00");

            if (bLGroupPrintWork.LogicalDeleteCode == 1 &&
                bLGroupPrintWork.DeleteDateTimeSt != 0 &&
                bLGroupPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < bLGroupPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > bLGroupPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGroupPrintWork.LogicalDeleteCode == 1 &&
                        bLGroupPrintWork.DeleteDateTimeSt != 0 &&
                        bLGroupPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < bLGroupPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGroupPrintWork.LogicalDeleteCode == 1 &&
                       bLGroupPrintWork.DeleteDateTimeSt == 0 &&
                       bLGroupPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > bLGroupPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (bLGroupPrintWork.BLGroupCodeSt != 0 &&
                bLGroupPrintWork.BLGroupCodeEd != 0)
            {
                if (bLGroupU.BLGroupCode < bLGroupPrintWork.BLGroupCodeSt ||
                   bLGroupU.BLGroupCode > bLGroupPrintWork.BLGroupCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGroupPrintWork.BLGroupCodeSt != 0)
            {
                if (bLGroupU.BLGroupCode < bLGroupPrintWork.BLGroupCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGroupPrintWork.BLGroupCodeEd != 0)
            {
                if (bLGroupU.BLGroupCode > bLGroupPrintWork.BLGroupCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}

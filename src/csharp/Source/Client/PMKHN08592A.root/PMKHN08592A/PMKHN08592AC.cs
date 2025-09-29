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
	/// 商品中分類マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品中分類マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class GoodsGroupSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private GoodsGroupUAcs _goodsGroupUAcs;
        

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 商品中分類マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 商品中分類マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public GoodsGroupSetAcs()
		{

			
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
		/// 商品中分類マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 商品中分類マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, GoodsGroupPrintWork goodsGroupPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, goodsGroupPrintWork);
		}

		/// <summary>
		/// 商品中分類マスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 商品中分類マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, GoodsGroupPrintWork goodsGroupPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, goodsGroupPrintWork);
		}

		

		/// <summary>
		/// 商品中分類マスタ検索処理
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
		/// <br>Note       : 商品中分類マスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsGroupPrintWork goodsGroupPrintWork)
		{

            this._goodsGroupUAcs = new GoodsGroupUAcs();

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList goodsGroupUs = null;

            status = this._goodsGroupUAcs.SearchAll(
                                out goodsGroupUs,
                                enterpriseCode);

            foreach (GoodsGroupU goodsGroupU in goodsGroupUs)
            {
                // 抽出処理
                checkstatus = DataCheck(goodsGroupU, goodsGroupPrintWork);
                if (checkstatus == 0)
                {

                    //商品中分類情報クラスへメンバコピー
                    retList.Add(CopyToMakerSetFromSecInfoSetWork(goodsGroupU, enterpriseCode));

                }
            }


            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（商品中分類マスタワーククラス⇒商品中分類マスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">商品中分類マスタワーククラス</param>
        /// <returns>商品中分類マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 商品中分類マスタワーククラスから商品中分類マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private GoodsGroupSet CopyToMakerSetFromSecInfoSetWork(GoodsGroupU goodsGroupU, string enterpriseCode)
        {

            GoodsGroupSet goodsGroupSet = new GoodsGroupSet();

            goodsGroupSet.GoodsMGroup = goodsGroupU.GoodsMGroup;
            goodsGroupSet.GoodsMGroupName = goodsGroupU.GoodsMGroupName;

            return goodsGroupSet;
        }


        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(GoodsGroupU goodsGroupU, GoodsGroupPrintWork goodsGroupPrintWork)
        {
            int status = 0;

            if (goodsGroupU.LogicalDeleteCode != goodsGroupPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = goodsGroupU.UpdateDateTime.Year.ToString("0000") +
                                goodsGroupU.UpdateDateTime.Month.ToString("00") +
                                goodsGroupU.UpdateDateTime.Day.ToString("00");

            if (goodsGroupPrintWork.LogicalDeleteCode == 1 &&
                goodsGroupPrintWork.DeleteDateTimeSt != 0 &&
                goodsGroupPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < goodsGroupPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > goodsGroupPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsGroupPrintWork.LogicalDeleteCode == 1 &&
                        goodsGroupPrintWork.DeleteDateTimeSt != 0 &&
                        goodsGroupPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < goodsGroupPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsGroupPrintWork.LogicalDeleteCode == 1 &&
                   goodsGroupPrintWork.DeleteDateTimeSt == 0 &&
                   goodsGroupPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > goodsGroupPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (goodsGroupPrintWork.GoodsMGroupSt != 0 &&
                goodsGroupPrintWork.GoodsMGroupEd != 0)
            {
                if (goodsGroupU.GoodsMGroup < goodsGroupPrintWork.GoodsMGroupSt ||
                   goodsGroupU.GoodsMGroup > goodsGroupPrintWork.GoodsMGroupEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsGroupPrintWork.GoodsMGroupSt != 0)
            {
                if (goodsGroupU.GoodsMGroup < goodsGroupPrintWork.GoodsMGroupSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsGroupPrintWork.GoodsMGroupEd != 0)
            {
                if (goodsGroupU.GoodsMGroup > goodsGroupPrintWork.GoodsMGroupEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}

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
	/// メーカーマスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : メーカーマスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class MakerSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private MakerAcs _makerAcs;
        

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// メーカーマスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : メーカーマスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public MakerSetAcs()
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
		/// メーカーマスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : メーカーマスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, MakerPrintWork makerPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, makerPrintWork);
		}

		/// <summary>
		/// メーカーマスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : メーカーマスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, MakerPrintWork makerPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, makerPrintWork);
		}

		

		/// <summary>
		/// メーカーマスタ検索処理
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
		/// <br>Note       : メーカーマスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MakerPrintWork makerPrintWork)
		{

            this._makerAcs = new MakerAcs();

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList makerUMnts = null;

            status = this._makerAcs.SearchAll(
                                out makerUMnts,
                                enterpriseCode);

            foreach (MakerUMnt makerUMnt in makerUMnts)
            {
                // 抽出処理
                checkstatus = DataCheck(makerUMnt, makerPrintWork);
                if (checkstatus == 0)
                {

                    //メーカー情報クラスへメンバコピー
                    retList.Add(CopyToMakerSetFromSecInfoSetWork(makerUMnt, enterpriseCode));

                }
            }


            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（メーカーマスタワーククラス⇒メーカーマスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">メーカーマスタワーククラス</param>
        /// <returns>メーカーマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : メーカーマスタワーククラスからメーカーマスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private MakerSet CopyToMakerSetFromSecInfoSetWork(MakerUMnt makerUMnt, string enterpriseCode)
        {

            MakerSet makerSet = new MakerSet();

            makerSet.GoodsMakerCd = makerUMnt.GoodsMakerCd;
            makerSet.MakerName = makerUMnt.MakerName;
            makerSet.MakerShortName = makerUMnt.MakerShortName;
            makerSet.MakerKanaName = makerUMnt.MakerKanaName;
            makerSet.DisplayOrder = makerUMnt.DisplayOrder;

            return makerSet;
        }


        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(MakerUMnt makerUMnt, MakerPrintWork makerPrintWork)
        {
            int status = 0;

            if (makerUMnt.LogicalDeleteCode != makerPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = makerUMnt.UpdateDateTime.Year.ToString("0000") +
                                makerUMnt.UpdateDateTime.Month.ToString("00") +
                                makerUMnt.UpdateDateTime.Day.ToString("00");

            if (makerPrintWork.LogicalDeleteCode == 1 &&
                makerPrintWork.DeleteDateTimeSt != 0 &&
                makerPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < makerPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > makerPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerPrintWork.LogicalDeleteCode == 1 &&
                        makerPrintWork.DeleteDateTimeSt != 0 &&
                        makerPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < makerPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerPrintWork.LogicalDeleteCode == 1 &&
                makerPrintWork.DeleteDateTimeSt == 0 &&
                makerPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > makerPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (makerPrintWork.GoodsMakerCdSt != 0 &&
                makerPrintWork.GoodsMakerCdEd != 0)
            {
                if (makerUMnt.GoodsMakerCd < makerPrintWork.GoodsMakerCdSt ||
                   makerUMnt.GoodsMakerCd > makerPrintWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerPrintWork.GoodsMakerCdSt != 0)
            {
                if (makerUMnt.GoodsMakerCd < makerPrintWork.GoodsMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerPrintWork.GoodsMakerCdEd != 0)
            {
                if (makerUMnt.GoodsMakerCd > makerPrintWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}

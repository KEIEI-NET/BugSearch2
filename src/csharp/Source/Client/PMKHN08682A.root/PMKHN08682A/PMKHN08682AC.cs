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
	/// 部位マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 部位マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class PartsPosCodeSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private PartsPosCodeUAcs _partsPosCodeUAcs;
        

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 部位マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 部位マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public PartsPosCodeSetAcs()
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
		/// 部位マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 部位マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, PartsPosCodePrintWork partsPosCodePrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, partsPosCodePrintWork);
		}

		/// <summary>
		/// 部位マスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 部位マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, PartsPosCodePrintWork partsPosCodePrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, partsPosCodePrintWork);
		}

		

		/// <summary>
		/// 部位マスタ検索処理
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
		/// <br>Note       : 部位マスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PartsPosCodePrintWork partsPosCodePrintWork)
		{

            this._partsPosCodeUAcs = new PartsPosCodeUAcs();

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList partsPosCodeUs = null;
            string strname = "";

            status = this._partsPosCodeUAcs.SearchAll(
                                out partsPosCodeUs,
                                enterpriseCode);

            foreach (PartsPosCodeU partsPosCodeU in partsPosCodeUs)
            {
                // 抽出処理
                checkstatus = DataCheck(partsPosCodeU, partsPosCodePrintWork);
                if (checkstatus == 0)
                {
                    if (partsPosCodeU.TbsPartsCode != 0)
                    {
                        //部位情報クラスへメンバコピー
                        retList.Add(CopyToMakerSetFromSecInfoSetWork(partsPosCodeU, enterpriseCode, strname));
                    }
                    else
                    {
                        strname = partsPosCodeU.SearchPartsPosName;
                    }

                }
            }


            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（部位マスタワーククラス⇒部位マスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">部位マスタワーククラス</param>
        /// <returns>部位マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 部位マスタワーククラスから部位マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private PartsPosCodeSet CopyToMakerSetFromSecInfoSetWork(PartsPosCodeU partsPosCodeU, string enterpriseCode, string name)
        {

            PartsPosCodeSet partsPosCodeSet = new PartsPosCodeSet();

            partsPosCodeSet.CustomerCode = partsPosCodeU.CustomerCode;
            if (partsPosCodeU.CustomerCode == 0)
            {
                partsPosCodeSet.CustomerSnm = "共通設定";
            }
            else
            {
                partsPosCodeSet.CustomerSnm = partsPosCodeU.CustomerSnm;
            }
            partsPosCodeSet.SearchPartsPosCode = partsPosCodeU.SearchPartsPosCode;
            partsPosCodeSet.SearchPartsPosName = name;
            partsPosCodeSet.PosDispOrder = partsPosCodeU.PosDispOrder;
            partsPosCodeSet.TbsPartsCode = partsPosCodeU.TbsPartsCode;
            partsPosCodeSet.BLGoodsHalfName = partsPosCodeU.TbsPartsName;

            return partsPosCodeSet;
        }


        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(PartsPosCodeU partsPosCodeU, PartsPosCodePrintWork partsPosCodePrintWork)
        {
            int status = 0;

            if (partsPosCodeU.LogicalDeleteCode != partsPosCodePrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = partsPosCodeU.UpdateDateTime.Year.ToString("0000") +
                                partsPosCodeU.UpdateDateTime.Month.ToString("00") +
                                partsPosCodeU.UpdateDateTime.Day.ToString("00");

            if (partsPosCodePrintWork.LogicalDeleteCode == 1 &&
                partsPosCodePrintWork.DeleteDateTimeSt != 0 &&
                partsPosCodePrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < partsPosCodePrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > partsPosCodePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.LogicalDeleteCode == 1 &&
                        partsPosCodePrintWork.DeleteDateTimeSt != 0 &&
                        partsPosCodePrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < partsPosCodePrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.LogicalDeleteCode == 1 &&
                partsPosCodePrintWork.DeleteDateTimeSt == 0 &&
                partsPosCodePrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > partsPosCodePrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (partsPosCodePrintWork.SearchPartsPosCodeSt != 0 &&
                partsPosCodePrintWork.SearchPartsPosCodeEd != 0)
            {
                if (partsPosCodeU.SearchPartsPosCode < partsPosCodePrintWork.SearchPartsPosCodeSt ||
                   partsPosCodeU.SearchPartsPosCode > partsPosCodePrintWork.SearchPartsPosCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.SearchPartsPosCodeSt != 0)
            {
                if (partsPosCodeU.SearchPartsPosCode < partsPosCodePrintWork.SearchPartsPosCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.SearchPartsPosCodeEd != 0)
            {
                if (partsPosCodeU.SearchPartsPosCode > partsPosCodePrintWork.SearchPartsPosCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            if (partsPosCodePrintWork.CustomerCodeSt != 0 &&
                partsPosCodePrintWork.CustomerCodeEd != 0)
            {
                if (partsPosCodeU.CustomerCode < partsPosCodePrintWork.CustomerCodeSt ||
                   partsPosCodeU.CustomerCode > partsPosCodePrintWork.CustomerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.CustomerCodeSt != 0)
            {
                if (partsPosCodeU.CustomerCode < partsPosCodePrintWork.CustomerCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsPosCodePrintWork.CustomerCodeEd != 0)
            {
                if (partsPosCodeU.CustomerCode > partsPosCodePrintWork.CustomerCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}

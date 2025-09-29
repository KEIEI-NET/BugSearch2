using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
//using Broadleaf.Library.Globarization;
//using Broadleaf.Application.Remoting;
//using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
//using Broadleaf.Windows.Forms;
//using Broadleaf.Application.Controller.Agent;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 仕入先マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入先マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class SupplierSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private SupplierAcs _supplierAcs;
        

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 仕入先マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入先マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public SupplierSetAcs()
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
		/// 仕入先マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 仕入先マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, SupplierPrintWork supplierPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, supplierPrintWork);
		}

		/// <summary>
		/// 仕入先マスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 仕入先マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SupplierPrintWork supplierPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, supplierPrintWork);
		}

		

		/// <summary>
		/// 仕入先マスタ検索処理
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
		/// <br>Note       : 仕入先マスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SupplierPrintWork supplierPrintWork)
		{

            this._supplierAcs = new SupplierAcs();

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList suppliers = null;

            if (logicalMode == ConstantManagement.LogicalMode.GetData01)
            {
                status = this._supplierAcs.SearchAll(
                                out suppliers,
                                enterpriseCode);
            }
            else
            {
                status = this._supplierAcs.Search(
                                out suppliers,
                                enterpriseCode);
            }

            foreach (Supplier supplier in suppliers)
            {
                // 抽出処理
                checkstatus = DataCheck(supplier, supplierPrintWork);
                if (checkstatus == 0)
                {

                    //仕入先情報クラスへメンバコピー
                    retList.Add(CopyToSupplierSetFromSecInfoSetWork(supplier, enterpriseCode));

                }
            }


            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（仕入先マスタワーククラス⇒仕入先マスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">仕入先マスタワーククラス</param>
        /// <returns>仕入先マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタワーククラスから仕入先マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private SupplierSet CopyToSupplierSetFromSecInfoSetWork(Supplier supplier, string enterpriseCode)
        {

            SupplierSet supplierSet = new SupplierSet();

            supplierSet.SupplierCd = supplier.SupplierCd;
            supplierSet.SupplierSnm = supplier.SupplierSnm;
            supplierSet.SupplierKana = supplier.SupplierKana;
            supplierSet.SupplierTelNo = supplier.SupplierTelNo;
            supplierSet.SupplierTelNo1 = supplier.SupplierTelNo1;
            supplierSet.SupplierTelNo2 = supplier.SupplierTelNo2;
            supplierSet.SupplierPostNo = supplier.SupplierPostNo;
            supplierSet.SupplierAddr1 = supplier.SupplierAddr1;
            supplierSet.SupplierAddr3 = supplier.SupplierAddr3;
            supplierSet.SupplierAddr4 = supplier.SupplierAddr4;
            supplierSet.PaymentTotalDay = supplier.PaymentTotalDay;
            supplierSet.PaymentCond = supplier.PaymentCond;
            supplierSet.PaymentMonthName = supplier.PaymentMonthName;
            supplierSet.PaymentDay = supplier.PaymentDay;
            supplierSet.StockAgentCode = supplier.StockAgentCode;
            supplierSet.StockAgentName = supplier.StockAgentName;
            supplierSet.MngSectionCode = supplier.MngSectionCode;
            supplierSet.SectionGuideNm = supplier.MngSectionName;
            supplierSet.PaymentSectionCode = supplier.PaymentSectionCode;
            supplierSet.PayeeCode = supplier.PayeeCode;
            supplierSet.PayeeSnm = supplier.PayeeSnm;


            return supplierSet;
        }


        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(Supplier supplier, SupplierPrintWork supplierPrintWork)
        {
            int status = 0;

            if (supplier.LogicalDeleteCode != supplierPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = supplier.UpdateDateTime.Year.ToString("0000") +
                                supplier.UpdateDateTime.Month.ToString("00") +
                                supplier.UpdateDateTime.Day.ToString("00");

            if (supplierPrintWork.LogicalDeleteCode == 1 &&
                supplierPrintWork.DeleteDateTimeSt != 0 &&
                supplierPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < supplierPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > supplierPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (supplierPrintWork.LogicalDeleteCode == 1 &&
                        supplierPrintWork.DeleteDateTimeSt != 0 &&
                        supplierPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < supplierPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (supplierPrintWork.LogicalDeleteCode == 1 &&
                     supplierPrintWork.DeleteDateTimeSt == 0 &&
                     supplierPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > supplierPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (supplierPrintWork.SupplierCdSt != 0 &&
                supplierPrintWork.SupplierCdEd != 0)
            {
                if (supplier.SupplierCd < supplierPrintWork.SupplierCdSt ||
                   supplier.SupplierCd > supplierPrintWork.SupplierCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (supplierPrintWork.SupplierCdSt != 0)
            {
                if (supplier.SupplierCd < supplierPrintWork.SupplierCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (supplierPrintWork.SupplierCdEd != 0)
            {
                if (supplier.SupplierCd > supplierPrintWork.SupplierCdEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (!supplierPrintWork.SupplierKanaSt.Trim().Equals(string.Empty) &&
                !supplierPrintWork.SupplierKanaEd.Trim().Equals(string.Empty))
            {
                if (supplierPrintWork.SupplierKanaSt.CompareTo(supplier.SupplierKana) > 0 ||
                    supplierPrintWork.SupplierKanaEd.CompareTo(supplier.SupplierKana) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!supplierPrintWork.SupplierKanaSt.Trim().Equals(string.Empty))
            {
                if (supplierPrintWork.SupplierKanaSt.CompareTo(supplier.SupplierKana) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!supplierPrintWork.SupplierKanaEd.Trim().Equals(string.Empty))
            {
                if (supplierPrintWork.SupplierKanaEd.CompareTo(supplier.SupplierKana) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
    }
}

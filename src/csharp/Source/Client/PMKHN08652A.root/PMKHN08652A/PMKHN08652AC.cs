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
	/// 代替マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 代替マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class PartsSubstSetAcs 
	{

        private static bool _isLocalDBRead = false;

        private PartsSubstUAcs _partsSubstUAcs;

        private Dictionary<int, MakerUMnt> _MakerDic;
        private MakerAcs _makerAcs;
        

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 代替マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 代替マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public PartsSubstSetAcs()
		{
            this._makerAcs = new MakerAcs();
			
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
		/// 代替マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 代替マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, PartsSubstPrintWork partsSubstPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, partsSubstPrintWork);
		}

		/// <summary>
		/// 代替マスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 代替マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, PartsSubstPrintWork partsSubstPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, partsSubstPrintWork);
		}

		

		/// <summary>
		/// 代替マスタ検索処理
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
		/// <br>Note       : 代替マスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PartsSubstPrintWork partsSubstPrintWork)
		{

            this._partsSubstUAcs = new PartsSubstUAcs();

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList partsSubstUs = null;

            status = this._partsSubstUAcs.SearchAll(
                                out partsSubstUs,
                                enterpriseCode);

            foreach (PartsSubstU partsSubstU in partsSubstUs)
            {
                // 抽出処理
                checkstatus = DataCheck(partsSubstU, partsSubstPrintWork);
                if (checkstatus == 0)
                {

                    //代替情報クラスへメンバコピー
                    retList.Add(CopyToMakerSetFromSecInfoSetWork(partsSubstU, enterpriseCode));

                }
            }


            //全件リードの場合は戻り値の件数をセット
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（代替マスタワーククラス⇒代替マスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">代替マスタワーククラス</param>
        /// <returns>代替マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 代替マスタワーククラスから代替マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private PartsSubstSet CopyToMakerSetFromSecInfoSetWork(PartsSubstU partsSubstU, string enterpriseCode)
        {

            PartsSubstSet partsSubstSet = new PartsSubstSet();

            partsSubstSet.ChgSrcMakerCd = partsSubstU.ChgSrcMakerCd;
            partsSubstSet.ChgSrcMakerName = GetMakerName(partsSubstU.ChgSrcMakerCd,enterpriseCode);
            partsSubstSet.ChgSrcGoodsNo = partsSubstU.ChgSrcGoodsNo;
            partsSubstSet.ChgDestMakerCd = partsSubstU.ChgDestMakerCd;
            partsSubstSet.ChgDestMakerName = GetMakerName(partsSubstU.ChgDestMakerCd, enterpriseCode);
            partsSubstSet.ChgDestGoodsNo = partsSubstU.ChgDestGoodsNo;
            partsSubstSet.ApplyStaDate = partsSubstU.ApplyStaDate;
            partsSubstSet.ApplyEndDate = partsSubstU.ApplyEndDate;


            return partsSubstSet;
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
        private int DataCheck(PartsSubstU partsSubstU, PartsSubstPrintWork partsSubstPrintWork)
        {
            int status = 0;

            if (partsSubstU.LogicalDeleteCode != partsSubstPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = partsSubstU.UpdateDateTime.Year.ToString("0000") +
                                partsSubstU.UpdateDateTime.Month.ToString("00") +
                                partsSubstU.UpdateDateTime.Day.ToString("00");

            if (partsSubstPrintWork.LogicalDeleteCode == 1 &&
                partsSubstPrintWork.DeleteDateTimeSt != 0 &&
                partsSubstPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < partsSubstPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > partsSubstPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsSubstPrintWork.LogicalDeleteCode == 1 &&
                        partsSubstPrintWork.DeleteDateTimeSt != 0 &&
                        partsSubstPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < partsSubstPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsSubstPrintWork.LogicalDeleteCode == 1 &&
                partsSubstPrintWork.DeleteDateTimeSt == 0 &&
                partsSubstPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > partsSubstPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (partsSubstPrintWork.ChgSrcMakerCdSt != 0 &&
                partsSubstPrintWork.ChgSrcMakerCdEd != 0)
            {
                if (partsSubstU.ChgSrcMakerCd < partsSubstPrintWork.ChgSrcMakerCdSt ||
                   partsSubstU.ChgSrcMakerCd > partsSubstPrintWork.ChgSrcMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsSubstPrintWork.ChgSrcMakerCdSt != 0)
            {
                if (partsSubstU.ChgSrcMakerCd < partsSubstPrintWork.ChgSrcMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (partsSubstPrintWork.ChgSrcMakerCdEd != 0)
            {
                if (partsSubstU.ChgSrcMakerCd > partsSubstPrintWork.ChgSrcMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            if (!partsSubstPrintWork.ChgSrcGoodsNoSt.Trim().Equals(string.Empty) &&
                !partsSubstPrintWork.ChgSrcGoodsNoEd.Trim().Equals(string.Empty))
            {
                if (partsSubstPrintWork.ChgSrcGoodsNoSt.CompareTo(partsSubstU.ChgSrcGoodsNo) > 0 ||
                    partsSubstPrintWork.ChgSrcGoodsNoEd.CompareTo(partsSubstU.ChgSrcGoodsNo) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!partsSubstPrintWork.ChgSrcGoodsNoSt.Trim().Equals(string.Empty))
            {
                if (partsSubstPrintWork.ChgSrcGoodsNoSt.CompareTo(partsSubstU.ChgSrcGoodsNo) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!partsSubstPrintWork.ChgSrcGoodsNoEd.Trim().Equals(string.Empty))
            {
                if (partsSubstPrintWork.ChgSrcGoodsNoEd.CompareTo(partsSubstU.ChgSrcGoodsNo) < 0)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}

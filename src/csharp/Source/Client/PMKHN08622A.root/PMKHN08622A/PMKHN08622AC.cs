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
	/// 離島価格マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 離島価格マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class IsolIslandPrcSetAcs 
	{

        private static bool _isLocalDBRead = false;

        /// <summary>離島価格マスタリモートオブジェクト格納バッファ</summary>
        private IIsolIslandPrcDB _iIsolIslandPrcDB = null;

        private Dictionary<int, SecInfoSet> _secInfoDic;
        private SecInfoSetAcs _secInfoAcs;

        private Dictionary<int, MakerUMnt> _MakerDic; 
        private MakerAcs _makerAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// 離島価格マスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 離島価格マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public IsolIslandPrcSetAcs()
		{
            // リモートオブジェクト取得
            this._iIsolIslandPrcDB = (IIsolIslandPrcDB)MediationIsolIslandPrcDB.GetIsolIslandPrcDB();

			this._makerAcs = new MakerAcs();
            this._secInfoAcs = new SecInfoSetAcs();
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
		/// 離島価格マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 離島価格マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, IsolIslandPrcPrintWork isolIslandPrcPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, isolIslandPrcPrintWork);
		}

		/// <summary>
		/// 離島価格マスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 離島価格マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, IsolIslandPrcPrintWork isolIslandPrcPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, isolIslandPrcPrintWork);
		}

		

		/// <summary>
		/// 離島価格マスタ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="isolIslandPrcPrintWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 離島価格マスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, IsolIslandPrcPrintWork isolIslandPrcPrintWork)
		{
            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            // キー情報をセット
            IsolIslandPrcWork paramIsolIslandPrcWork = new IsolIslandPrcWork();
            paramIsolIslandPrcWork.EnterpriseCode = enterpriseCode;    // 企業コード

            ArrayList retArray = new ArrayList();
            object retobj = (object)retArray;

            // 離島価格マスタ検索
            status = this._iIsolIslandPrcDB.Search(ref retobj, paramIsolIslandPrcWork, 0, logicalMode);

            retArray = retobj as ArrayList;

            foreach (IsolIslandPrcWork isolIslandPrcWork in retArray)
            {
                // 抽出処理
                checkstatus = DataCheck(isolIslandPrcWork, isolIslandPrcPrintWork);
                if (checkstatus == 0)
                {

                    //離島価格情報クラスへメンバコピー
                    retList.Add(CopyToIsolIslandPrcSetFromSecInfoSetWork(isolIslandPrcWork, enterpriseCode));

                }
            }

            //全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（離島価格マスタワーククラス⇒離島価格マスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">離島価格マスタワーククラス</param>
        /// <returns>離島価格マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 離島価格マスタワーククラスから離島価格マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private IsolIslandPrcSet CopyToIsolIslandPrcSetFromSecInfoSetWork(IsolIslandPrcWork isolIslandPrcWork, string enterpriseCode)
        {

            IsolIslandPrcSet isolIslandPrcSet = new IsolIslandPrcSet();

            isolIslandPrcSet.SectionCode = isolIslandPrcWork.SectionCode;
            isolIslandPrcSet.SectionGuideSnm = GetSectionName(isolIslandPrcWork.SectionCode.Trim(), enterpriseCode);
            isolIslandPrcSet.MakerCode = isolIslandPrcWork.MakerCode;
            isolIslandPrcSet.MakerShortName = GetMakerName(isolIslandPrcWork.MakerCode, enterpriseCode);
            isolIslandPrcSet.UpperLimitPrice = isolIslandPrcWork.UpperLimitPrice;
            isolIslandPrcSet.FractionProcUnit = isolIslandPrcWork.FractionProcUnit;
            isolIslandPrcSet.FractionProcCd = isolIslandPrcWork.FractionProcCd;
            isolIslandPrcSet.UpRate = isolIslandPrcWork.UpRate;


            return isolIslandPrcSet;
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// </remarks>
        private string GetSectionName(string sectionCode, string enterpriseCode)
        {
            string sectionName = "";
            ReadSecInfo(enterpriseCode);
            if (this._secInfoDic.ContainsKey(Int32.Parse(sectionCode)))
            {
                sectionName = this._secInfoDic[Int32.Parse(sectionCode)].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 拠点情報読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報一覧を読み込みます。</br>
        /// </remarks>
        private void ReadSecInfo(string enterpriseCode)
        {
            try
            {
                if (this._secInfoDic.Count == 0)
                {
                    this._secInfoDic = new Dictionary<int, SecInfoSet>();

                    ArrayList retList;

                    int status = this._secInfoAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (SecInfoSet secInfoSet in retList)
                        {
                            if (secInfoSet.LogicalDeleteCode == 0)
                            {
                                this._secInfoDic.Add(Int32.Parse(secInfoSet.SectionCode), secInfoSet);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._secInfoDic = new Dictionary<int, SecInfoSet>();

                ArrayList retList;

                int status = this._secInfoAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (SecInfoSet secInfoSet in retList)
                    {
                        if (secInfoSet.LogicalDeleteCode == 0)
                        {
                            this._secInfoDic.Add(Int32.Parse(secInfoSet.SectionCode), secInfoSet);
                        }
                    }
                }
            }
            return;
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
        /// <param name="isolIslandPrcPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(IsolIslandPrcWork isolIslandPrcWork, IsolIslandPrcPrintWork isolIslandPrcPrintWork)
        {
            int status = 0;

            if (isolIslandPrcWork.LogicalDeleteCode != isolIslandPrcPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = isolIslandPrcWork.UpdateDateTime.Year.ToString("0000") +
                                isolIslandPrcWork.UpdateDateTime.Month.ToString("00") +
                                isolIslandPrcWork.UpdateDateTime.Day.ToString("00");

            if (isolIslandPrcPrintWork.LogicalDeleteCode == 1 &&
                isolIslandPrcPrintWork.DeleteDateTimeSt != 0 &&
                isolIslandPrcPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < isolIslandPrcPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > isolIslandPrcPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (isolIslandPrcPrintWork.LogicalDeleteCode == 1 &&
                        isolIslandPrcPrintWork.DeleteDateTimeSt != 0 &&
                        isolIslandPrcPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < isolIslandPrcPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (isolIslandPrcPrintWork.LogicalDeleteCode == 1 &&
                isolIslandPrcPrintWork.DeleteDateTimeSt == 0 &&
                isolIslandPrcPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > isolIslandPrcPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (!isolIslandPrcPrintWork.SectionCodeSt.Trim().Equals(string.Empty) &&
                !isolIslandPrcPrintWork.SectionCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(isolIslandPrcWork.SectionCode) < Int32.Parse(isolIslandPrcPrintWork.SectionCodeSt) ||
                   Int32.Parse(isolIslandPrcWork.SectionCode) > Int32.Parse(isolIslandPrcPrintWork.SectionCodeEd))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!isolIslandPrcPrintWork.SectionCodeSt.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(isolIslandPrcWork.SectionCode) < Int32.Parse(isolIslandPrcPrintWork.SectionCodeSt))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!isolIslandPrcPrintWork.SectionCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(isolIslandPrcWork.SectionCode) > Int32.Parse(isolIslandPrcPrintWork.SectionCodeEd))
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}

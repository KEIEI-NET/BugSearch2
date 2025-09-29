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
	/// セットマスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : セットマスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class GoodsSetSetAcs 
	{

        private static bool _isLocalDBRead = false;

        /// <summary>商品セットリモートオブジェクト格納バッファ</summary>
        private IGoodsSetDB _iGoodsSetDB = null;

        private Dictionary<int, MakerUMnt> _MakerDic;
        private MakerAcs _makerAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// セットマスタテーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : セットマスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public GoodsSetSetAcs()
		{
            // 商品セットマスタリモートオブジェクト取得
            this._iGoodsSetDB = (IGoodsSetDB)MediationGoodsSetDB.GetGoodsSetDB();
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
		/// セットマスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : セットマスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, GoodsSetPrintWork goodsSetPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, goodsSetPrintWork);
		}

		/// <summary>
		/// セットマスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : セットマスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, GoodsSetPrintWork goodsSetPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, goodsSetPrintWork);
		}

		

		/// <summary>
		/// セットマスタ検索処理
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
		/// <br>Note       : セットマスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsSetPrintWork goodsSetPrintWork)
		{
            GoodsSetWork goodsSetWork = new GoodsSetWork();
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
            object retobj = paraList;

            status = this._iGoodsSetDB.Search(out retobj, paraobj, 0, logicalMode);

            paraList = (ArrayList)retobj;

            foreach (GoodsSetWork goodsSetWorkdata in paraList)
            {
                // 抽出処理
                checkstatus = DataCheck(goodsSetWorkdata, goodsSetPrintWork);
                if (checkstatus == 0)
                {
                    //セット情報クラスへメンバコピー
                    retList.Add(CopyToMakerSetFromSecInfoSetWork(goodsSetWorkdata, enterpriseCode));
                }
            }
            //this._makerAcs = new MakerAcs();

            //int status = 0;
            //int checkstatus = 0;

            ////次データ有無初期化
            //nextData = false;
            ////0で初期化
            //retTotalCnt = 0;

            //retList = new ArrayList();
            //retList.Clear();

            //ArrayList makerUMnts = null;

            //status = this._makerAcs.SearchAll(
            //                    out makerUMnts,
            //                    enterpriseCode);

            //foreach (MakerUMnt makerUMnt in makerUMnts)
            //{
            //    // 抽出処理
            //    checkstatus = DataCheck(makerUMnt, goodsSetPrintWork);
            //    if (checkstatus == 0)
            //    {

            //        //セット情報クラスへメンバコピー
            //        retList.Add(CopyToMakerSetFromSecInfoSetWork(makerUMnt, enterpriseCode));

            //    }
            //}


            ////全件リードの場合は戻り値の件数をセット
            //if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        /// <summary>
        /// クラスメンバーコピー処理（セットマスタワーククラス⇒セットマスタクラス）
        /// </summary>
        /// <param name="secInfoSetWork">セットマスタワーククラス</param>
        /// <returns>セットマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : セットマスタワーククラスからセットマスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private GoodsSetSet CopyToMakerSetFromSecInfoSetWork(GoodsSetWork goodsSetWorkdata, string enterpriseCode)
        {

            GoodsSetSet goodsSetSet = new GoodsSetSet();

            goodsSetSet.ParentGoodsMakerCd = goodsSetWorkdata.ParentGoodsMakerCd;
            goodsSetSet.ParentGoodsMakerName = GetMakerName(goodsSetWorkdata.ParentGoodsMakerCd, enterpriseCode);
            goodsSetSet.ParentGoodsNo = goodsSetWorkdata.ParentGoodsNo;
            goodsSetSet.DisplayOrder = goodsSetWorkdata.DisplayOrder;
            goodsSetSet.SubGoodsNo = goodsSetWorkdata.SubGoodsNo;
            goodsSetSet.GoodsNameKana = goodsSetWorkdata.SubGoodsName;
            goodsSetSet.SubGoodsMakerCd = goodsSetWorkdata.SubGoodsMakerCd;
            goodsSetSet.SubGoodsMakerName = goodsSetWorkdata.SubMakerName;
            goodsSetSet.CntFl = goodsSetWorkdata.CntFl;
            goodsSetSet.SetSpecialNote = goodsSetWorkdata.SetSpecialNote;



            return goodsSetSet;
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
        private int DataCheck(GoodsSetWork goodsSetWorkdata, GoodsSetPrintWork goodsSetPrintWork)
        {
            int status = 0;

            if (goodsSetWorkdata.LogicalDeleteCode != goodsSetPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = goodsSetWorkdata.UpdateDateTime.Year.ToString("0000") +
                                goodsSetWorkdata.UpdateDateTime.Month.ToString("00") +
                                goodsSetWorkdata.UpdateDateTime.Day.ToString("00");

            if (goodsSetPrintWork.LogicalDeleteCode == 1 &&
                goodsSetPrintWork.DeleteDateTimeSt != 0 &&
                goodsSetPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < goodsSetPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > goodsSetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsSetPrintWork.LogicalDeleteCode == 1 &&
                        goodsSetPrintWork.DeleteDateTimeSt != 0 &&
                        goodsSetPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < goodsSetPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsSetPrintWork.LogicalDeleteCode == 1 &&
                goodsSetPrintWork.DeleteDateTimeSt == 0 &&
                goodsSetPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > goodsSetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (goodsSetPrintWork.ParentGoodsMakerCdSt != 0 &&
                goodsSetPrintWork.ParentGoodsMakerCdEd != 0)
            {
                if (goodsSetWorkdata.ParentGoodsMakerCd < goodsSetPrintWork.ParentGoodsMakerCdSt ||
                   goodsSetWorkdata.ParentGoodsMakerCd > goodsSetPrintWork.ParentGoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsSetPrintWork.ParentGoodsMakerCdSt != 0)
            {
                if (goodsSetWorkdata.ParentGoodsMakerCd < goodsSetPrintWork.ParentGoodsMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (goodsSetPrintWork.ParentGoodsMakerCdEd != 0)
            {
                if (goodsSetWorkdata.ParentGoodsMakerCd > goodsSetPrintWork.ParentGoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            if (!goodsSetPrintWork.ParentGoodsNoSt.Trim().Equals(string.Empty) &&
                !goodsSetPrintWork.ParentGoodsNoEd.Trim().Equals(string.Empty))
            {
                if (goodsSetPrintWork.ParentGoodsNoSt.CompareTo(goodsSetWorkdata.ParentGoodsNo) > 0 ||
                    goodsSetPrintWork.ParentGoodsNoEd.CompareTo(goodsSetWorkdata.ParentGoodsNo) < 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!goodsSetPrintWork.ParentGoodsNoSt.Trim().Equals(string.Empty))
            {
                if (goodsSetPrintWork.ParentGoodsNoSt.CompareTo(goodsSetWorkdata.ParentGoodsNo) > 0)
                {
                    status = -1;
                    return status;
                }
            }
            else if (!goodsSetPrintWork.ParentGoodsNoEd.Trim().Equals(string.Empty))
            {
                if (goodsSetPrintWork.ParentGoodsNoEd.CompareTo(goodsSetWorkdata.ParentGoodsNo) < 0)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}

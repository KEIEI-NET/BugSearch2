//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   IOWriteGoodsPriceUserリモートオブジェクト
//                  :   PMKHN09111R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112 久保田
// Date             :   2008/06/06
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    public class IOWriteGoodsPriceUser : RemoteWithAppLockDB
    {
        # region [Write]

        /// <summary>
        /// 売上・仕入明細を元に、商品価格マスタ(ユーザー)のデータを作成・更新します。
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="addListPos">商品価格情報リスト インデックス</param>
        /// <param name="sqlConnection">データベース接続情報オブジェクト</param>
        /// <param name="sqlTransaction">トランザクション情報オブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報オブジェクト</param>
        /// <returns>STATUS</returns>
        public int Write(ref CustomSerializeArrayList paraList, out int addListPos, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            ArrayList list = paraList as ArrayList;
            return Write(ref list, out addListPos, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
        }

        /// <summary>
        /// 売上・仕入明細を元に、商品価格マスタ(ユーザー)のデータを作成・更新します。
        /// </summary>
        /// <param name="paraList"></param>
        /// <param name="addListPos">商品価格情報リスト インデックス</param>
        /// <param name="sqlConnection">データベース接続情報オブジェクト</param>
        /// <param name="sqlTransaction">トランザクション情報オブジェクト</param>
        /// <param name="sqlEncryptInfo">暗号化情報オブジェクト</param>
        /// <returns>STATUS</returns>
        public int Write(ref ArrayList paraList, out int addListPos, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlEncryptInfo sqlEncryptInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            addListPos = -1;

            try
            {
                ArrayList godsPrcUsrList = new ArrayList();

                // 伝票明細追加情報を分離
                SlipDetailAddInfoDtlRelationGuidComparer DtlRelationGuidComp = new SlipDetailAddInfoDtlRelationGuidComparer();
                ArrayList slpDtlAdInfList = ListUtils.Find(paraList, typeof(SlipDetailAddInfoWork), ListUtils.FindType.Array) as ArrayList;

                if (ListUtils.IsNotEmpty(slpDtlAdInfList))
                {
                    slpDtlAdInfList.Sort(DtlRelationGuidComp);

                    GoodsPriceUComparer goodsPriceUComp = new GoodsPriceUComparer();

                    # region [売上明細データ → 商品価格マスタ(ユーザー)データ作成]

                    // 売上明細データを分離
                    ArrayList slsDtlList = ListUtils.Find(paraList, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                    if (ListUtils.IsNotEmpty(slsDtlList))
                    {
                        foreach (SalesDetailWork slsDtlWrk in slsDtlList)
                        {
                            // 売上明細に紐付く伝票明細追加情報を取得
                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch(slsDtlWrk.DtlRelationGuid, DtlRelationGuidComp);

                            SlipDetailAddInfoWork slpDtlAdInfWrk = null;

                            if (slpDtlAdInfPos > -1)
                            {
                                slpDtlAdInfWrk = slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork;
                            }

                            // 伝票明細追加情報が存在し、且つ価格更新区分が 1:更新 の場合
                            if (slpDtlAdInfWrk != null && slpDtlAdInfWrk.GoodsEntryDiv == 0 && slpDtlAdInfWrk.PriceUpdateDiv == 1)
                            {
                                GoodsPriceUWork godsPrcUsrWrk = new GoodsPriceUWork();

                                godsPrcUsrWrk.EnterpriseCode = slsDtlWrk.EnterpriseCode;        // 企業コード
                                godsPrcUsrWrk.LogicalDeleteCode = slsDtlWrk.LogicalDeleteCode;  // 論理削除フラグ
                                godsPrcUsrWrk.GoodsMakerCd = slsDtlWrk.GoodsMakerCd;            // 商品メーカーコード
                                godsPrcUsrWrk.GoodsNo = slsDtlWrk.GoodsNo;                      // 商品番号
                                godsPrcUsrWrk.PriceStartDate = slpDtlAdInfWrk.PriceStartDate;   // 価格開始日
                                godsPrcUsrWrk.ListPrice = slsDtlWrk.ListPriceTaxExcFl;          // 定価(税抜)
                                godsPrcUsrWrk.SalesUnitCost = slsDtlWrk.SalesUnitCost;          // 原価単価
                                godsPrcUsrWrk.StockRate = 0;                                    // 仕入率
                                godsPrcUsrWrk.OpenPriceDiv = slsDtlWrk.OpenPriceDiv;            // オープン価格区分
                                godsPrcUsrWrk.OfferDate = slpDtlAdInfWrk.PriceOfferDate;        // 提供日付
                                godsPrcUsrWrk.UpdateDate = DateTime.Now;                        // 更新日付

                                godsPrcUsrList.Sort(goodsPriceUComp);

                                int idx = godsPrcUsrList.BinarySearch(godsPrcUsrWrk, goodsPriceUComp);

                                if (idx < 0)
                                {
                                    // 重複していない商品価格データのみを追加する
                                    godsPrcUsrList.Add(godsPrcUsrWrk);
                                }
                            }
                        }
                    }

                    # endregion

                    # region [仕入明細データ → 商品価格マスタ(ユーザー)データ作成]

                    // 仕入明細データ を分離

                    ArrayList stkDtlList = ListUtils.Find(paraList, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                    if (ListUtils.IsNotEmpty(stkDtlList))
                    {

                        foreach (StockDetailWork stkDtlWrk in stkDtlList)
                        {
                            // 仕入明細に紐付く伝票明細追加情報を取得
                            int slpDtlAdInfPos = slpDtlAdInfList.BinarySearch(stkDtlWrk.DtlRelationGuid, DtlRelationGuidComp);

                            SlipDetailAddInfoWork slpDtlAdInfWrk = null;

                            if (slpDtlAdInfPos > -1)
                            {
                                slpDtlAdInfWrk = slpDtlAdInfList[slpDtlAdInfPos] as SlipDetailAddInfoWork;
                            }

                            // 伝票明細追加情報が存在し、且つ価格更新区分が 1:更新 の場合
                            if (slpDtlAdInfWrk != null && slpDtlAdInfWrk.GoodsEntryDiv == 0 && slpDtlAdInfWrk.PriceUpdateDiv == 1)
                            {
                                GoodsPriceUWork godsPrcUsrWrk = new GoodsPriceUWork();

                                godsPrcUsrWrk.EnterpriseCode = stkDtlWrk.EnterpriseCode;        // 企業コード
                                godsPrcUsrWrk.LogicalDeleteCode = stkDtlWrk.LogicalDeleteCode;  // 論理削除フラグ
                                godsPrcUsrWrk.GoodsMakerCd = stkDtlWrk.GoodsMakerCd;            // 商品メーカーコード
                                godsPrcUsrWrk.GoodsNo = stkDtlWrk.GoodsNo;                      // 商品番号
                                godsPrcUsrWrk.PriceStartDate = slpDtlAdInfWrk.PriceStartDate;   // 価格開始日
                                godsPrcUsrWrk.ListPrice = stkDtlWrk.ListPriceTaxExcFl;          // 定価(税抜)

                                if (stkDtlWrk.StockRate == 0)
                                {
                                    godsPrcUsrWrk.SalesUnitCost = stkDtlWrk.StockUnitPriceFl;   // 原価単価
                                    godsPrcUsrWrk.StockRate = 0;                                // 仕入率
                                }
                                else
                                {
                                    godsPrcUsrWrk.SalesUnitCost = 0;                            // 原価単価
                                    godsPrcUsrWrk.StockRate = stkDtlWrk.StockRate;              // 仕入率
                                }

                                godsPrcUsrWrk.OpenPriceDiv = stkDtlWrk.OpenPriceDiv;            // オープン価格区分
                                godsPrcUsrWrk.OfferDate = slpDtlAdInfWrk.PriceOfferDate;        // 提供日付
                                godsPrcUsrWrk.UpdateDate = DateTime.Now;                        // 更新日付

                                godsPrcUsrList.Sort(goodsPriceUComp);

                                int idx = godsPrcUsrList.BinarySearch(godsPrcUsrWrk, goodsPriceUComp);

                                if (idx < 0)
                                {
                                    // 重複していない商品価格データのみを追加する
                                    godsPrcUsrList.Add(godsPrcUsrWrk);
                                }
                            }
                        }
                    }

                    # endregion

                }

                if (ListUtils.IsNotEmpty(godsPrcUsrList))
                {
                    // 商品価格マスタ(ユーザー)に更新
                    ArrayList errList = null;
                    GoodsPriceUDB goodsPriceUDB = new GoodsPriceUDB();

                    status = goodsPriceUDB.UpDatePrice(ref godsPrcUsrList, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && ListUtils.IsEmpty(errList))
                    {
                        // 登録処理に成功した場合にのみ、パラメータリストに商品価格情報を追加する
                        addListPos = paraList.Add(godsPrcUsrList);
                    }
                }
                else
                {
                    // 更新対象の商品価格データが１件も存在しない場合、エラーとはしない。
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            return status;
        }

        # endregion

        /// <summary>
        /// 商品価格データ比較クラス
        /// </summary>
        private class GoodsPriceUComparer : IComparer
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public int Compare(object x, object y)
            {
                GoodsPriceUWork xPrice = x as GoodsPriceUWork;
                GoodsPriceUWork yPrice = y as GoodsPriceUWork;

                int ret = (xPrice == null ? 0 : 1) - (yPrice == null ? 0 : 1);

                if (ret == 0 && xPrice != null)
                {
                    // 企業コードで比較
                    ret = xPrice.EnterpriseCode.CompareTo(yPrice.EnterpriseCode);

                    // 商品メーカーコードで比較
                    if (ret == 0)
                    {
                        ret = xPrice.GoodsMakerCd - yPrice.GoodsMakerCd;
                    }

                    // 商品番号で比較
                    if (ret == 0)
                    {
                        ret = xPrice.GoodsNo.CompareTo(yPrice.GoodsNo);
                    }

                    // 価格更新日
                    if (ret == 0)
                    {
                        ret = xPrice.PriceStartDate.CompareTo(yPrice.PriceStartDate);
                    }
                }

                return ret;
            }
        }
    }
}

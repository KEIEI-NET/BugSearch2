//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : S&E売上データテキスト出力
// プログラム概要   : S&E売上データテキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 李占川 連番691
// 修 正 日  2011/08/16  修正内容 :【PM要望改良9月配信分】Redmine#23598 連番691の対応
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 李占川 連番691
// 修 正 日  2011/09/19  修正内容 :【PM要望改良9月配信分】Redmine#25246 連番691の対応
//----------------------------------------------------------------------------//
// 管理番号  XXXXXXXX-00 作成担当 : 22008 長内 数馬
// 修 正 日  2011/10/19  修正内容 : 抽出時のタイムアウト時間延長
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh
// 作 成 日  2013/02/25  修正内容 : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhuhh  
// 修 正 日  2013/03/18  修正内容 : redmine #35044 管理№で変換マスタを読み商品コードを取得
//----------------------------------------------------------------------------//
// 管理番号 10901034-00  作成担当 : 田建委  
// 修 正 日  2013/06/26  修正内容 : 送信ログの登録
//----------------------------------------------------------------------------//
// 管理番号 11670121-00  作成担当 : 石崎  
// 修 正 日  2020/03/17  修正内容 : S&E改良対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SE売上データテキストDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : SE売上データテキストの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.08.14</br>
    /// <br>UpdateNote : 2013/02/25 zhuhh</br>
    /// <br>           : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
    /// <br>UpdateNote : 2013/03/18 zhuhh</br>
    /// <br>           : Redmine#35044 管理№で変換マスタを読み商品コードを取得</br>
    /// <br>UpdateNote : 2013/06/26 田建委</br>
    /// <br>           : 送信ログの登録</br>
    /// </remarks>
    [Serializable]
    public class SalesHistoryJoinDB : RemoteDB, ISalesHistoryJoinWorkDB
    {
        /// <summary>
        /// SE売上データテキストコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.14</br>
        /// </remarks>
        public SalesHistoryJoinDB()
            :
        base("PMSAE02016D", "Broadleaf.Application.Remoting.ParamData.SalesHistoryJoinWork", "SALESHISTORYRF") //基底クラスのコンストラクタ
        {
        }

        #region Search
        /// <summary>
        /// 指定された企業コードのSE売上データテキストの全て戻る処理（論理削除除く）
        /// </summary>
        /// <param name="salesHistoryResultWork">検索結果</param>
        /// <param name="salesHistoryCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのSE売上データLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.14</br>
        public int Search(out object salesHistoryResultWork, object salesHistoryCndtnWork)
        {
            SqlConnection sqlConnection = null;
            salesHistoryResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection(true);

                return SearchProc(out salesHistoryResultWork, salesHistoryCndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.Search");
                salesHistoryResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (null != sqlConnection)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された企業コードのSE売上データテキストを全て戻る処理
        /// </summary>
        /// <param name="salesHistoryResultWork">検索結果</param>
        /// <param name="salesHistoryCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの仕入データLISTを全て戻します</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.14</br>
        /// <br>Update Note: 2011/08/16 李占川</br>
        /// <br>             【PM要望改良9月配信分】Redmine#23598 連番691の対応</br> 
        /// <br>UpdateNote : 2013/02/25 zhuhh</br>
        /// <br>           : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更</br>
        /// <br>UpdateNote : 2013/03/18 zhuhh</br>
        /// <br>           : Redmine#35044 管理№で変換マスタを読み商品コードを取得</br>
        /// <br>UpdateNote  : 2020/03/17 石崎</br>
        /// <br>            : Ｓ＆Ｅ改良対応</br>
        /// </remarks>
        private int SearchProc(out object salesHistoryResultWork, object salesHistoryCndtnWork, ref SqlConnection sqlConnection)
        {
            SalesHistoryCndtnWork cndtnWork = salesHistoryCndtnWork as SalesHistoryCndtnWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            salesHistoryResultWork = null;
            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT ");
                sb.Append(" A.CREATEDATETIMERF, ");
                sb.Append(" A.ENTERPRISECODERF, ");
                sb.Append(" A.ACPTANODRSTATUSRF, ");
                sb.Append(" A.SALESSLIPNUMRF, ");
                sb.Append(" A.SALESSLIPCDRF, ");
                sb.Append(" A.RESULTSADDUPSECCDRF, ");
                sb.Append(" A.SEARCHSLIPDATERF, ");
                sb.Append(" A.ADDUPADATERF, ");
                sb.Append(" A.CUSTOMERCODERF, ");
                sb.Append(" B.SALESROWNORF, ");
                sb.Append(" B.GOODSMAKERCDRF, ");
                //update 石崎 2020/03/17 Ｓ＆Ｅ改良対応  ----->>>>>
                sb.Append(" B.PRTGOODSNORF, ");
               // sb.Append(" B.GOODSNORF, ");
                //update 石崎 2020/03/17 Ｓ＆Ｅ改良対応  -----<<<<<
                sb.Append(" B.GOODSNAMEKANARF, ");
                sb.Append(" B.BLGOODSCODERF, ");
                sb.Append(" B.SALESUNPRCTAXEXCFLRF, ");
                sb.Append(" B.SHIPMENTCNTRF, ");
                sb.Append(" B.SALESMONEYTAXEXCRF, ");
                sb.Append(" B.LISTPRICETAXEXCFLRF, "); // ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
                sb.Append(" B.SUPPLIERCDRF, ");
                sb.Append(" B.PRTBLGOODSCODERF, ");
                sb.Append(" C.ABGOODSCODERF AS SETABGOODSCODERF, ");
                sb.Append(" C.ADDRESSEESHOPCDRF, ");
                sb.Append(" C.EXPENSEDIVCDRF, ");
                sb.Append(" C.PURETRADCOMPCDRF, ");
                sb.Append(" C.PURETRADCOMPRATERF, ");
                sb.Append(" C.PRITRADCOMPCDRF, ");
                sb.Append(" C.PRITRADCOMPRATERF, ");
                sb.Append(" C.SANDEMNGCODERF, ");
                sb.Append(" C.GOODSMAKERCD1RF, ");
                sb.Append(" C.GOODSMAKERCD2RF, ");
                sb.Append(" C.GOODSMAKERCD3RF, ");
                sb.Append(" C.GOODSMAKERCD4RF, ");
                sb.Append(" C.GOODSMAKERCD5RF, ");
                sb.Append(" C.GOODSMAKERCD6RF, ");
                sb.Append(" C.GOODSMAKERCD7RF, ");
                sb.Append(" C.GOODSMAKERCD8RF, ");
                sb.Append(" C.GOODSMAKERCD9RF, ");
                sb.Append(" C.GOODSMAKERCD10RF, ");
                sb.Append(" C.GOODSMAKERCD11RF, ");
                sb.Append(" C.GOODSMAKERCD12RF, ");
                sb.Append(" C.GOODSMAKERCD13RF, ");
                sb.Append(" C.GOODSMAKERCD14RF, ");
                sb.Append(" C.GOODSMAKERCD15RF, ");
                sb.Append(" D.CUSTOMERSNMRF, ");
                sb.Append(" E.SECTIONGUIDESNMRF, ");
                sb.Append(" F.ABGOODSCODERF, ");
                sb.Append(" G.ENTERPRISECODERF AS SEENTERPRISECODERF, ");
                sb.Append(" G.ACPTANODRSTATUSRF AS SEACPTANODRSTATUSRF, ");
                sb.Append(" G.SALESSLIPNUMRF AS SESALESSLIPNUMRF, ");
                sb.Append(" G.SALESCREATEDATETIMERF AS SESALESCREATEDATETIMERF ");

                sb.Append(" FROM SALESHISTORYRF A WITH (READUNCOMMITTED)");

                sb.Append(" INNER JOIN SALESHISTDTLRF B ");
                sb.Append(" ON A.ENTERPRISECODERF =  B.ENTERPRISECODERF ");
                sb.Append(" AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ");
                sb.Append(" AND A.SALESSLIPNUMRF =  B.SALESSLIPNUMRF ");

                sb.Append(" INNER JOIN SANDESETTINGRF C ");
                sb.Append(" ON A.ENTERPRISECODERF =  C.ENTERPRISECODERF ");
                sb.Append(" AND A.RESULTSADDUPSECCDRF = C.SECTIONCODERF ");
                sb.Append(" AND A.CUSTOMERCODERF =  C.CUSTOMERCODERF ");

                sb.Append(" LEFT JOIN CUSTOMERRF D ");
                sb.Append(" ON A.ENTERPRISECODERF =  D.ENTERPRISECODERF ");
                sb.Append(" AND A.CUSTOMERCODERF =  D.CUSTOMERCODERF ");
                sb.Append(" AND D.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN SECINFOSETRF E ");
                sb.Append(" ON A.ENTERPRISECODERF =  E.ENTERPRISECODERF ");
                sb.Append(" AND A.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                sb.Append(" AND E.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN SANDESALEXTRDTRF G ");
                sb.Append(" ON A.ENTERPRISECODERF =  G.ENTERPRISECODERF ");
                sb.Append(" AND A.ACPTANODRSTATUSRF = G.ACPTANODRSTATUSRF ");
                sb.Append(" AND A.SALESSLIPNUMRF = G.SALESSLIPNUMRF ");
                //sb.Append(" AND A.CREATEDATETIMERF = G.SALESCREATEDATETIMERF "); // DEL 2011/08/16

                sb.Append(" LEFT JOIN SANDEGOODSCDCHGRF F ");
                sb.Append(" ON B.ENTERPRISECODERF =  F.ENTERPRISECODERF ");
                //sb.Append(" AND B.BLGOODSCODERF = F.BLGOODSCODERF ");// DEL zhuhh 2013/03/18 for Redmine#35044
                sb.Append(" AND B.PRTBLGOODSCODERF = F.BLGOODSCODERF ");// ADD zhuhh 2013/03/18 for Redmine#35044
                sb.Append(" AND F.LOGICALDELETECODERF = 0 ");

                // 検索条件
                sb.Append(MakeWhereString(ref sqlCommand, cndtnWork));

                sb.Append(" ORDER BY ");
                sb.Append(" A.ADDUPADATERF,A.RESULTSADDUPSECCDRF,A.SALESSLIPNUMRF,B.SALESROWNORF ");

                sqlCommand.CommandText = sb.ToString();

                sqlCommand.CommandTimeout = 3600;  // ADD 2011/10/19

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    SalesHistoryJoinWork wkSalesHistoryJoinWork = new SalesHistoryJoinWork();

                    //データ結果取得内容格納
                    wkSalesHistoryJoinWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkSalesHistoryJoinWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkSalesHistoryJoinWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    wkSalesHistoryJoinWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    wkSalesHistoryJoinWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                    wkSalesHistoryJoinWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    wkSalesHistoryJoinWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
                    wkSalesHistoryJoinWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    wkSalesHistoryJoinWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkSalesHistoryJoinWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    //update 石崎 2020/03/17 Ｓ＆Ｅ改良対応  ----->>>>>
                    wkSalesHistoryJoinWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTGOODSNORF"));
//                    wkSalesHistoryJoinWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    //update 石崎 2020/03/17 Ｓ＆Ｅ改良対応  -----<<<<<
                    wkSalesHistoryJoinWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    wkSalesHistoryJoinWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkSalesHistoryJoinWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    wkSalesHistoryJoinWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
                    wkSalesHistoryJoinWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkSalesHistoryJoinWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    wkSalesHistoryJoinWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));// ADD zhuhh 2013/02/25 Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更
                    wkSalesHistoryJoinWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkSalesHistoryJoinWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkSalesHistoryJoinWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkSalesHistoryJoinWork.ABGoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ABGOODSCODERF"));
                    wkSalesHistoryJoinWork.AddresseeShopCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEESHOPCDRF"));
                    wkSalesHistoryJoinWork.SAndEMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SANDEMNGCODERF"));
                    wkSalesHistoryJoinWork.ExpenseDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXPENSEDIVCDRF"));
                    wkSalesHistoryJoinWork.PureTradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PURETRADCOMPCDRF"));
                    wkSalesHistoryJoinWork.PureTradCompRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PURETRADCOMPRATERF"));
                    wkSalesHistoryJoinWork.PriTradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRITRADCOMPCDRF"));
                    wkSalesHistoryJoinWork.PriTradCompRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRITRADCOMPRATERF"));
                    wkSalesHistoryJoinWork.SetABGoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SETABGOODSCODERF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD1RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD2RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD3RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD4RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD5RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD6RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD7RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD8RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD9RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD10RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd11 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD11RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd12 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD12RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd13 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD13RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd14 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD14RF"));
                    wkSalesHistoryJoinWork.GoodsMakerCd15 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD15RF"));
                    wkSalesHistoryJoinWork.SEEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEENTERPRISECODERF"));
                    wkSalesHistoryJoinWork.SEAcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEACPTANODRSTATUSRF"));
                    wkSalesHistoryJoinWork.SESalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SESALESSLIPNUMRF"));
                    wkSalesHistoryJoinWork.SESalesCreateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SESALESCREATEDATETIMERF"));

                    #endregion

                    al.Add(wkSalesHistoryJoinWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "SalesHistoryJoinDB.SearchProc", status);
            }
            finally
            {
                if (null != myReader && !myReader.IsClosed)
                {
                    myReader.Close();
                }

                if (null != sqlCommand)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            salesHistoryResultWork = al;

            return status;
        }
        #endregion

        #region Update
        /// <summary>
        /// SE売上抽出データ情報を追加更新処理。
        /// </summary>
        /// <param name="objectsalesHistoryJoinWorkList">追加・更新するSE売上抽出データ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : salesHistoryJoinWorkList に格納されているSE売上抽出データ情報を追加・更新します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.14</br>
        public int Write(ref object objectsalesHistoryJoinWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList salesHistoryJoinWorkList = objectsalesHistoryJoinWorkList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                foreach (SalesHistoryJoinWork detailWork in salesHistoryJoinWorkList)
                {
                    // 削除処理実行
                    status = this.DeleteProc(detailWork, ref sqlConnection, ref sqlTransaction);

                    //追加処理実行
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = this.InsertProc(detailWork, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.Write(ref object)", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        ///SE売上抽出データ情報を物理削除処理
        /// </summary>
        /// <param name="salesHistoryJoinWork">SE売上抽出データ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SalesHistoryJoinWork に格納されているSE売上抽出データ情報を物理削除します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.14</br>
        /// <br>Update Note: 2011/09/19 李占川</br>
        /// <br>             【PM要望改良9月配信分】Redmine##25246 連番691の対応</br> 
        private int DeleteProc(SalesHistoryJoinWork salesHistoryJoinWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                if (salesHistoryJoinWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [DELETE文]
                    sqlText += "DELETE " + Environment.NewLine;
                    sqlText += "FROM " + Environment.NewLine;
                    sqlText += "SANDESALEXTRDTRF " + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    //sqlText += " AND SALESCREATEDATETIMERF = @FINDSALESCREATEDATETIME" + Environment.NewLine; // DEL 2011/09/19
                    sqlCommand.CommandText = sqlText;
                    # endregion


                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter findSalesCreateDateTime = sqlCommand.Parameters.Add("@FINDSALESCREATEDATETIME", SqlDbType.BigInt);

                    // KEYコマンドを設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesHistoryJoinWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.SalesSlipNum);
                    findSalesCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesHistoryJoinWork.CreateDateTime);

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SalesHistoryJoinDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.DeleteProc" , status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        ///SE売上抽出データ情報を追加処理
        /// </summary>
        /// <param name="salesHistoryJoinWork">SE売上抽出データ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SalesHistoryJoinWork に格納されているSE売上抽出データ情報を追加します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.14</br>
        private int InsertProc(SalesHistoryJoinWork salesHistoryJoinWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                if (salesHistoryJoinWork != null)
                {
                    string sqlText = string.Empty;

                    //売上抽出データ. 売上データ作成日時
                    DateTime salesCreateDateTime = salesHistoryJoinWork.CreateDateTime; 

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [INSERT文]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO SANDESALEXTRDTRF" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,SALESCREATEDATETIMERF" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlText += "VALUES" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                    sqlText += " ,@SALESCREATEDATETIME" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // 登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)salesHistoryJoinWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    # region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter paraSalesCreateDateTime = sqlCommand.Parameters.Add("@SALESCREATEDATETIME", SqlDbType.BigInt);
                    # endregion

                    # region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesHistoryJoinWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesHistoryJoinWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesHistoryJoinWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesHistoryJoinWork.LogicalDeleteCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesHistoryJoinWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesHistoryJoinWork.SalesSlipNum);
                    paraSalesCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesCreateDateTime);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SalesHistoryJoinDB.InsertProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.InsertProc" , status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="salesHistoryCndtnWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.14</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesHistoryCndtnWork salesHistoryCndtnWork)
        {
            #region WHERE文作成
            string retstring = " WHERE ";

            //企業コード
            retstring += " A.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(salesHistoryCndtnWork.EnterpriseCode);

            //売上履歴データ.論理削除区分
            retstring += " AND A.LOGICALDELETECODERF=@ALOGICALDELETECODERF";
            SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODERF", SqlDbType.Int);
            paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //受注ステータス
            retstring += " AND A.ACPTANODRSTATUSRF=@ACPTANODRSTATUSRF";
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUSRF", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);

            //オートバックス設定マスタ .論理削除区分
            retstring += " AND C.LOGICALDELETECODERF=@CLOGICALDELETECODERF";
            SqlParameter paraCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODERF", SqlDbType.Int);
            paraCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //売上履歴明細データ.論理削除区分
            retstring += " AND B.LOGICALDELETECODERF=@BLOGICALDELETECODERF";
            SqlParameter paraBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODERF", SqlDbType.Int);
            paraBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //拠点コード    ※配列で複数指定される
            if (salesHistoryCndtnWork.SectionCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in salesHistoryCndtnWork.SectionCodeList)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND A.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") ";
                }
            }

            // AND 計上日>＝パラメータ.計上日の開始日																																	
            if (!DateTime.MinValue.Equals(salesHistoryCndtnWork.AddUpADateSt))
            {
                retstring += " AND A.ADDUPADATERF>=@ST_SCVDAY ";
                SqlParameter Para_St_csvDate = sqlCommand.Parameters.Add("@ST_SCVDAY", SqlDbType.Int);
                Para_St_csvDate.Value = SqlDataMediator.SqlSetInt32(salesHistoryCndtnWork.AddUpADateSt);
            }

            // AND 計上日<＝パラメータ.計上日の終了日
            if (!DateTime.MinValue.Equals(salesHistoryCndtnWork.AddUpADateEd))
            {
                retstring += " AND A.ADDUPADATERF<=@ED_SCVDAY ";
                SqlParameter Para_Ed_csvDate = sqlCommand.Parameters.Add("@ED_SCVDAY", SqlDbType.Int);
                Para_Ed_csvDate.Value = SqlDataMediator.SqlSetInt32(salesHistoryCndtnWork.AddUpADateEd);
            }

            // AND 得意先コード>＝パラメータ.得意先コードの開始																																	
            if (0 != salesHistoryCndtnWork.CustomerCodeSt)
            {
                retstring += " AND A.CUSTOMERCODERF>=@ST_CUSTOMERCODE ";
                SqlParameter Para_St_customerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                Para_St_customerCode.Value = SqlDataMediator.SqlSetInt32(salesHistoryCndtnWork.CustomerCodeSt);
            }

            // AND 得意先コード<＝パラメータ.得意先コードの終了
            if (0 != salesHistoryCndtnWork.CustomerCodeEd)
            {
                retstring += " AND A.CUSTOMERCODERF<=@ED_CUSTOMERCODE ";
                SqlParameter Para_Ed_customerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE", SqlDbType.Int);
                Para_Ed_customerCode.Value = SqlDataMediator.SqlSetInt32(salesHistoryCndtnWork.CustomerCodeEd);
            }

            retstring += " AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1 OR (B.SALESSLIPCDDTLRF = 2 AND B.SHIPMENTCNTRF = 0)) ";

            #endregion
            return retstring;
        }

        // ----- ADD 田建委 2013/06/26 ----->>>>>
        /// <summary>
        /// SE売上データテキスト送信ログ情報の登録処理。
        /// </summary>
        /// <param name="objectSAndESalSndLogWork">登録するSE売上データテキスト送信ログ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : objectSAndESalSndLogWork に格納されているSE売上データテキスト送信ログ情報を登録します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/06/26</br>
        public int WriteLog(ref object objectSAndESalSndLogWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                SAndESalSndLogListResultWork sAndESalSndLogWork = objectSAndESalSndLogWork as SAndESalSndLogListResultWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteLogProc(sAndESalSndLogWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.WriteLog(ref object)", status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        ///SE売上データテキスト送信ログ情報の登録処理
        /// </summary>
        /// <param name="sAndESalSndLogWork">登録するSE売上データテキスト送信ログ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sAndESalSndLogWork に格納されているSE売上データテキスト送信ログ情報を登録します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/06/26</br>
        private int WriteLogProc(SAndESalSndLogListResultWork sAndESalSndLogWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (sAndESalSndLogWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();

                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText.Append(" SELECT UPDATEDATETIMERF").Append( Environment.NewLine);
                    sqlText.Append(" FROM SANDESALSNDLOGRF").Append( Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append( Environment.NewLine);
                    sqlText.Append("   AND SECTIONCODERF=@FINDSECTIONCODE").Append( Environment.NewLine);
                    sqlText.Append("   AND SANDEAUTOSENDDIVRF=@FINDSANDEAUTOSENDDIV").Append( Environment.NewLine);
                    sqlText.Append("   AND SENDDATETIMESTARTRF=@FINDSENDDATETIMESTART").Append( Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameterオブジェクトの作成
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);
                    SqlParameter findParaSAndEAutoSendDiv = sqlCommand.Parameters.Add("@FINDSANDEAUTOSENDDIV", SqlDbType.NChar);
                    SqlParameter findParaSendDateTimeStart = sqlCommand.Parameters.Add("@FINDSENDDATETIMESTART", SqlDbType.BigInt);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.SectionCode);
                    findParaSAndEAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SAndEAutoSendDiv);
                    findParaSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(sAndESalSndLogWork.SendDateTimeStart);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != sAndESalSndLogWork.UpdateDateTime)
                        {
                            if (sAndESalSndLogWork.UpdateDateTime == DateTime.MinValue)
                            {
                                // 新規登録で該当データ有りの場合には重複
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            else
                            {
                                // 既存データで更新日時違いの場合には排他
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            return status;
                        }
                    }
                    else
                    {
                        // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        if (sAndESalSndLogWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT文]
                        sqlText = new StringBuilder();
                        sqlText.Append("INSERT INTO SANDESALSNDLOGRF").Append( Environment.NewLine);
                        sqlText.Append("(").Append( Environment.NewLine);
                        sqlText.Append("  CREATEDATETIMERF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDATEDATETIMERF").Append( Environment.NewLine);
                        sqlText.Append(" ,ENTERPRISECODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,FILEHEADERGUIDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDEMPLOYEECODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID1RF").Append( Environment.NewLine);
                        sqlText.Append(" ,UPDASSEMBLYID2RF").Append( Environment.NewLine);
                        sqlText.Append(" ,LOGICALDELETECODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,SECTIONCODERF").Append( Environment.NewLine);
                        sqlText.Append(" ,SANDEAUTOSENDDIVRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDDATETIMESTARTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDDATETIMEENDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJDATESTARTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJDATEENDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJCUSTSTARTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJCUSTENDRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDOBJDIVRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDRESULTSRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDERRORCONTENTSRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDSLIPCOUNTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDSLIPDTLCNTRF").Append( Environment.NewLine);
                        sqlText.Append(" ,SENDSLIPTOTALMNYRF").Append( Environment.NewLine);
                        sqlText.Append(")").Append( Environment.NewLine);
                        sqlText.Append("VALUES").Append( Environment.NewLine);
                        sqlText.Append("(").Append( Environment.NewLine);
                        sqlText.Append("  @CREATEDATETIME").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDATEDATETIME").Append( Environment.NewLine);
                        sqlText.Append(" ,@ENTERPRISECODE").Append( Environment.NewLine);
                        sqlText.Append(" ,@FILEHEADERGUID").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDEMPLOYEECODE").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDASSEMBLYID1").Append( Environment.NewLine);
                        sqlText.Append(" ,@UPDASSEMBLYID2").Append( Environment.NewLine);
                        sqlText.Append(" ,@LOGICALDELETECODE").Append(Environment.NewLine);
                        sqlText.Append(" ,@SECTIONCODE").Append(Environment.NewLine);
                        sqlText.Append(" ,@SANDEAUTOSENDDIV").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDDATETIMESTART").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDDATETIMEEND").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJDATESTART").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJDATEEND").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJCUSTSTART").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJCUSTEND").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDOBJDIV").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDRESULTS").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDERRORCONTENTS").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDSLIPCOUNT").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDSLIPDTLCNT").Append(Environment.NewLine);
                        sqlText.Append(" ,@SENDSLIPTOTALMNY").Append(Environment.NewLine);
                        sqlText.Append(")").Append( Environment.NewLine);
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // 登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sAndESalSndLogWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    # region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSAndEAutoSendDiv = sqlCommand.Parameters.Add("@SANDEAUTOSENDDIV", SqlDbType.Int);
                    SqlParameter paraSendDateTimeStart = sqlCommand.Parameters.Add("@SENDDATETIMESTART", SqlDbType.BigInt);
                    SqlParameter paraSendDateTimeEnd = sqlCommand.Parameters.Add("@SENDDATETIMEEND", SqlDbType.BigInt);
                    SqlParameter paraSendObjDateStart = sqlCommand.Parameters.Add("@SENDOBJDATESTART", SqlDbType.Int);
                    SqlParameter paraSendObjDateEnd = sqlCommand.Parameters.Add("@SENDOBJDATEEND", SqlDbType.Int);
                    SqlParameter paraSendObjCustStart = sqlCommand.Parameters.Add("@SENDOBJCUSTSTART", SqlDbType.Int);
                    SqlParameter paraSendObjCustEnd = sqlCommand.Parameters.Add("@SENDOBJCUSTEND", SqlDbType.Int);
                    SqlParameter paraSendObjDiv = sqlCommand.Parameters.Add("@SENDOBJDIV", SqlDbType.Int);
                    SqlParameter paraSendResults = sqlCommand.Parameters.Add("@SENDRESULTS", SqlDbType.Int);
                    SqlParameter paraSendErrorContents = sqlCommand.Parameters.Add("@SENDERRORCONTENTS", SqlDbType.NVarChar);
                    SqlParameter paraSendSlipCount = sqlCommand.Parameters.Add("@SENDSLIPCOUNT", SqlDbType.Int);
                    SqlParameter paraSendSlipDtlCnt = sqlCommand.Parameters.Add("@SENDSLIPDTLCNT", SqlDbType.Int);
                    SqlParameter paraSendSlipTotalMny = sqlCommand.Parameters.Add("@SENDSLIPTOTALMNY", SqlDbType.BigInt);
                    # endregion

                    # region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndESalSndLogWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sAndESalSndLogWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sAndESalSndLogWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.SectionCode);
                    paraSAndEAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SAndEAutoSendDiv);
                    paraSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(sAndESalSndLogWork.SendDateTimeStart);
                    paraSendDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(sAndESalSndLogWork.SendDateTimeEnd);
                    paraSendObjDateStart.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendObjDateStart);
                    paraSendObjDateEnd.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendObjDateEnd);
                    paraSendObjCustStart.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendObjCustStart);
                    paraSendObjCustEnd.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendObjCustEnd);
                    paraSendObjDiv.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendObjDiv);
                    paraSendResults.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendResults);
                    paraSendErrorContents.Value = SqlDataMediator.SqlSetString(sAndESalSndLogWork.SendErrorContents);
                    paraSendSlipCount.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendSlipCount);
                    paraSendSlipDtlCnt.Value = SqlDataMediator.SqlSetInt32(sAndESalSndLogWork.SendSlipDtlCnt);
                    paraSendSlipTotalMny.Value = SqlDataMediator.SqlSetInt64(sAndESalSndLogWork.SendSlipTotalMny);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SalesHistoryJoinDB.WriteLogProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesHistoryJoinDB.WriteLogProc", status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        // ----- ADD 田建委 2013/06/26 -----<<<<<

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.14</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            //SqlConnection生成
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            //SqlConnection接続
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            //SqlConnection返す
            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.14</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        #endregion  //コネクション生成処理
    }
}

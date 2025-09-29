//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上連携テキスト出力
// プログラム概要   : 売上連携テキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00     作成担当 : 田建委
// 作 成 日 2019/12/02       修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570219-00     作成担当 : 寺田義啓
// 更 新 日 2020/02/04       修正内容 : （修正内容一覧No.２）備考出力設定項目変更対応
//----------------------------------------------------------------------------//
// 管理番号 11670214-00    作成担当 : 3H 尹安
// 更 新 日 2020/09/15     修正内容 : 売上データ出力文字種拡張対応 商品名称項目追加
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
    /// 売上連携テキストDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上連携テキストの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/02</br>
    /// </remarks>
    [Serializable]
    public class SalesCprtDB : RemoteDB, ISalesCprtWorkDB
    {
        /// <summary>
        /// 売上連携テキストコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public SalesCprtDB()
            :
        base("PMSDC02016D", "Broadleaf.Application.Remoting.ParamData.SalesCprtWork", "SALESHISTORYRF") //基底クラスのコンストラクタ
        {
        }

        #region Search
        /// <summary>
        /// 指定された企業コードの売上連携テキストの全て戻る処理（論理削除除く）
        /// </summary>
        /// <param name="salesCprtWork">検索結果</param>
        /// <param name="salesCprtCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの売上データLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public int Search(out object salesCprtWork, object salesCprtCndtnWork)
        {
            SqlConnection sqlConnection = null;
            salesCprtWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection(true);

                return SearchProc(out salesCprtWork, salesCprtCndtnWork, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesCprtDB.Search");
                salesCprtWork = new ArrayList();
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
        /// 指定された企業コードの売上連携テキストを全て戻る処理
        /// </summary>
        /// <param name="salesCprtWork">検索結果</param>
        /// <param name="salesCprtCndtnWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの仕入データLISTを全て戻します</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// <br>Update Note: 2020/02/04 寺田 義啓</br>
        /// <br>管理番号   : 11570219-00</br>
        /// <br>           :（修正内容一覧No.2）備考設定変更項目追加</br>
        /// <br>Update Note: 2020/09/15 3H 尹安</br>
        /// <br>管理番号   : 11670214-00</br>
        /// <br>           : 売上データ出力文字種拡張対応 商品名称項目追加</br>
        /// </remarks>
        private int SearchProc(out object salesCprtWork, object salesCprtCndtnWork, ref SqlConnection sqlConnection)
        {
            SalesCprtCndtnWork cndtnWork = salesCprtCndtnWork as SalesCprtCndtnWork;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            salesCprtWork = null;
            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                StringBuilder sb = new StringBuilder();
                sb.Append(" SELECT ");
                sb.Append(" A.CREATEDATETIMERF, ");
                sb.Append(" A.UPDATEDATETIMERF, ");
                sb.Append(" A.ENTERPRISECODERF, ");
                sb.Append(" A.ACPTANODRSTATUSRF, ");
                sb.Append(" A.SALESSLIPNUMRF, ");
                sb.Append(" C.SALESSLIPNUMRF AS DEBITNLNKSALESSLNUMRF, ");
                sb.Append(" A.SALESSLIPCDRF, ");
                sb.Append(" A.RESULTSADDUPSECCDRF, ");
                sb.Append(" A.SEARCHSLIPDATERF, ");
                sb.Append(" A.ADDUPADATERF, ");
                sb.Append(" A.CUSTOMERCODERF, ");
                sb.Append(" A.SLIPNOTERF, ");
                sb.Append(" A.SLIPNOTE2RF, ");
                sb.Append(" A.SLIPNOTE3RF, ");
                sb.Append(" B.SALESROWNORF, ");
                sb.Append(" B.GOODSMAKERCDRF, ");
                sb.Append(" B.GOODSNORF, ");
                sb.Append(" B.GOODSNAMERF, ");     // 商品名称  // 2020/09/15 3H 尹安 ADD
                sb.Append(" B.GOODSNAMEKANARF, ");
                sb.Append(" B.PRTBLGOODSCODERF AS BLGOODSCODERF, ");
                sb.Append(" B.SALESUNPRCTAXEXCFLRF, ");
                sb.Append(" B.SHIPMENTCNTRF, ");
                sb.Append(" B.SALESMONEYTAXEXCRF, ");
                sb.Append(" B.LISTPRICETAXEXCFLRF, ");
                sb.Append(" B.SUPPLIERCDRF, ");
                sb.Append(" B.PRTBLGOODSCODERF, ");
                sb.Append(" D.CUSTOMERSNMRF, ");
                sb.Append(" E.SECTIONGUIDESNMRF, ");
                sb.Append(" G.ENTERPRISECODERF AS SEENTERPRISECODERF, ");
                sb.Append(" G.ACPTANODRSTATUSRF AS SEACPTANODRSTATUSRF, ");
                sb.Append(" G.SALESSLIPNUMRF AS SESALESSLIPNUMRF, ");
                sb.Append(" G.SALESCREATEDATETIMERF AS SESALESCREATEDATETIMERF ");
                //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                sb.Append(" ,A.PARTYSALESLIPNUMRF ");
                //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2

                sb.Append(" FROM SALESHISTORYRF A WITH (READUNCOMMITTED)");

                sb.Append(" INNER JOIN SALESHISTDTLRF B ");
                sb.Append(" ON A.ENTERPRISECODERF =  B.ENTERPRISECODERF ");
                sb.Append(" AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ");
                sb.Append(" AND A.SALESSLIPNUMRF =  B.SALESSLIPNUMRF ");

                sb.Append(" LEFT JOIN SALESHISTDTLRF C ");
                sb.Append(" ON C.ENTERPRISECODERF =  B.ENTERPRISECODERF ");
                sb.Append(" AND C.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ");
                sb.Append(" AND C.SALESSLIPDTLNUMRF =  B.SALESSLIPDTLNUMSRCRF ");

                sb.Append(" LEFT JOIN CUSTOMERRF D ");
                sb.Append(" ON A.ENTERPRISECODERF =  D.ENTERPRISECODERF ");
                sb.Append(" AND A.CUSTOMERCODERF =  D.CUSTOMERCODERF ");
                sb.Append(" AND D.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN SECINFOSETRF E ");
                sb.Append(" ON A.ENTERPRISECODERF =  E.ENTERPRISECODERF ");
                sb.Append(" AND A.RESULTSADDUPSECCDRF = E.SECTIONCODERF ");
                sb.Append(" AND E.LOGICALDELETECODERF = 0 ");

                sb.Append(" LEFT JOIN SALCPRTEXTRDTRF G ");
                sb.Append(" ON A.ENTERPRISECODERF =  G.ENTERPRISECODERF ");
                sb.Append(" AND A.ACPTANODRSTATUSRF = G.ACPTANODRSTATUSRF ");
                sb.Append(" AND A.SALESSLIPNUMRF = G.SALESSLIPNUMRF ");
                //送信区分(0:手動;1:自動)
                if (cndtnWork.SendDataDiv == 1)
                {
                    sb.Append(" AND A.CREATEDATETIMERF = G.SALESCREATEDATETIMERF ");
                    sb.Append(" AND A.UPDATEDATETIMERF = G.SALESUPDATEDATETIMERF ");
                }

                // 検索条件
                sb.Append(MakeWhereString(ref sqlCommand, cndtnWork));

                sb.Append(" ORDER BY ");
                sb.Append(" A.ADDUPADATERF,A.RESULTSADDUPSECCDRF,A.SALESSLIPNUMRF,B.SALESROWNORF ");

                sqlCommand.CommandText = sb.ToString();

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    SalesCprtWork wkSalesHistoryJoinWork = new SalesCprtWork();

                    //データ結果取得内容格納
                    wkSalesHistoryJoinWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkSalesHistoryJoinWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
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
                    wkSalesHistoryJoinWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkSalesHistoryJoinWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));　// 商品名称　// 2020/09/15 3H 尹安 ADD 
                    wkSalesHistoryJoinWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    wkSalesHistoryJoinWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkSalesHistoryJoinWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    wkSalesHistoryJoinWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
                    wkSalesHistoryJoinWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    wkSalesHistoryJoinWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    wkSalesHistoryJoinWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    wkSalesHistoryJoinWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkSalesHistoryJoinWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkSalesHistoryJoinWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkSalesHistoryJoinWork.SEEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEENTERPRISECODERF"));
                    wkSalesHistoryJoinWork.SEAcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEACPTANODRSTATUSRF"));
                    wkSalesHistoryJoinWork.SESalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SESALESSLIPNUMRF"));
                    wkSalesHistoryJoinWork.SESalesCreateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SESALESCREATEDATETIMERF"));
                    wkSalesHistoryJoinWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                    wkSalesHistoryJoinWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                    wkSalesHistoryJoinWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                    wkSalesHistoryJoinWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
                    wkSalesHistoryJoinWork.SalesCreateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkSalesHistoryJoinWork.SalesUpdateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    //↓ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
                    wkSalesHistoryJoinWork.PartySalesLipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                    //↑ ADD 2020/02/04 Y.Terada  修正内容一覧No.2
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
                status = base.WriteSQLErrorLog(ex, "SalesCprtDB.SearchProc", status);
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

            salesCprtWork = al;

            return status;
        }
        #endregion

        #region Update
        /// <summary>
        /// 売上抽出データ情報を追加更新処理。
        /// </summary>
        /// <param name="salesCprtWorkList">追加・更新する売上抽出データ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : salesCprtWorkList に格納されている売上抽出データ情報を追加・更新します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        public int Write(ref object salesCprtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList salesHistoryWorkList = salesCprtWorkList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                foreach (SalesCprtWork detailWork in salesHistoryWorkList)
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
                base.WriteErrorLog(ex, "SalesCprtDB.Write(ref object)", status);
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
        ///売上抽出データ情報を物理削除処理
        /// </summary>
        /// <param name="salesCprtWork">売上抽出データ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SalesCprtWork に格納されているSE売上抽出データ情報を物理削除します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br> 
        /// </remarks>
        private int DeleteProc(SalesCprtWork salesCprtWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                if (salesCprtWork != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [DELETE文]
                    sqlText += "DELETE " + Environment.NewLine;
                    sqlText += "FROM " + Environment.NewLine;
                    sqlText += "SALCPRTEXTRDTRF " + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += " ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += " AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += " AND SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion


                    // Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                    SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter findSalesCreateDateTime = sqlCommand.Parameters.Add("@FINDSALESCREATEDATETIME", SqlDbType.BigInt);

                    // KEYコマンドを設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesCprtWork.EnterpriseCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesCprtWork.AcptAnOdrStatus);
                    findSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesCprtWork.SalesSlipNum);
                    findSalesCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesCprtWork.CreateDateTime);

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SalesCprtDB.DeleteProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesCprtDB.DeleteProc" , status);
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
        ///売上抽出データ情報を追加処理
        /// </summary>
        /// <param name="salesCprtWork">売上抽出データ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : SalesCprtWork に格納されているSE売上抽出データ情報を追加します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private int InsertProc(SalesCprtWork salesCprtWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            try
            {
                if (salesCprtWork != null)
                {
                    string sqlText = string.Empty;

                    //売上抽出データ. 売上データ作成日時
                    long salesCreateDateTime = salesCprtWork.SalesCreateDateTime;
                    long salesUpdateDateTime = salesCprtWork.SalesUpdateDateTime; 

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [INSERT文]
                    sqlText = string.Empty;
                    sqlText += "INSERT INTO SALCPRTEXTRDTRF" + Environment.NewLine;
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
                    sqlText += " ,SALESUPDATEDATETIMERF" + Environment.NewLine;
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
                    sqlText += " ,@SALESUPDATEDATETIME" + Environment.NewLine;
                    sqlText += ")" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;
                    # endregion

                    // 登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)salesCprtWork;
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
                    SqlParameter paraSalesUpdateDateTime = sqlCommand.Parameters.Add("@SALESUPDATEDATETIME", SqlDbType.BigInt);
                    # endregion

                    # region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesCprtWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesCprtWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salesCprtWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salesCprtWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salesCprtWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salesCprtWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salesCprtWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salesCprtWork.LogicalDeleteCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(salesCprtWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(salesCprtWork.SalesSlipNum);
                    paraSalesCreateDateTime.Value = SqlDataMediator.SqlSetInt64(salesCreateDateTime);
                    paraSalesUpdateDateTime.Value = SqlDataMediator.SqlSetInt64(salesUpdateDateTime);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SalesCprtDB.InsertProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesCprtDB.InsertProc" , status);
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
        /// <param name="salesCprtCndtnWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesCprtCndtnWork salesCprtCndtnWork)
        {
            #region WHERE文作成
            string retstring = " WHERE ";

            //企業コード
            retstring += " A.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(salesCprtCndtnWork.EnterpriseCode);

            //売上履歴データ.論理削除区分
            retstring += " AND A.LOGICALDELETECODERF=@ALOGICALDELETECODERF";
            SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODERF", SqlDbType.Int);
            paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //受注ステータス
            retstring += " AND A.ACPTANODRSTATUSRF=@ACPTANODRSTATUSRF";
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUSRF", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(30);

            //売上履歴明細データ.論理削除区分
            retstring += " AND B.LOGICALDELETECODERF=@BLOGICALDELETECODERF";
            SqlParameter paraBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODERF", SqlDbType.Int);
            paraBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //拠点コード 
            if (!string.IsNullOrEmpty(salesCprtCndtnWork.SectionCode) && !salesCprtCndtnWork.SectionCode.Equals("00"))
            {
                retstring += " AND A.RESULTSADDUPSECCDRF = @RESULTSADDUPSECCD";
                SqlParameter ParaSectionCode = sqlCommand.Parameters.Add("@RESULTSADDUPSECCD", SqlDbType.NChar);
                ParaSectionCode.Value = SqlDataMediator.SqlSetString(salesCprtCndtnWork.SectionCode);
            }

            //送信区分(0:手動;1:自動)
            if (salesCprtCndtnWork.SendDataDiv == 0)
            {
                // AND 計上日>＝パラメータ.計上日の開始日																																	
                if (!DateTime.MinValue.Equals(salesCprtCndtnWork.AddUpADateSt))
                {
                    retstring += " AND A.ADDUPADATERF>=@ST_SCVDAY ";
                    SqlParameter Para_St_csvDate = sqlCommand.Parameters.Add("@ST_SCVDAY", SqlDbType.Int);
                    Para_St_csvDate.Value = SqlDataMediator.SqlSetInt32(salesCprtCndtnWork.AddUpADateSt);
                }

                // AND 計上日<＝パラメータ.計上日の終了日
                if (!DateTime.MinValue.Equals(salesCprtCndtnWork.AddUpADateEd))
                {
                    retstring += " AND A.ADDUPADATERF<=@ED_SCVDAY ";
                    SqlParameter Para_Ed_csvDate = sqlCommand.Parameters.Add("@ED_SCVDAY", SqlDbType.Int);
                    Para_Ed_csvDate.Value = SqlDataMediator.SqlSetInt32(salesCprtCndtnWork.AddUpADateEd);
                }
            }
            else
            {
                // AND 更新日時>＝パラメータ.検索開始時間																																
                if (!DateTime.MinValue.Equals(salesCprtCndtnWork.SearchTimeSt))
                {
                    retstring += " AND A.UPDATEDATETIMERF>=@ST_SECTIME ";
                    SqlParameter Para_St_secTime = sqlCommand.Parameters.Add("@ST_SECTIME", SqlDbType.BigInt);
                    Para_St_secTime.Value = SqlDataMediator.SqlSetInt64(salesCprtCndtnWork.SearchTimeSt.Ticks);
                }

                // 自動送信接続区分 0:未送信,2:全て
                if (salesCprtCndtnWork.AutoDataSendDiv == 0)
                {
                    retstring += " AND G.ENTERPRISECODERF IS NULL ";
                }
            }

            // AND 得意先コード>＝パラメータ.得意先コードの開始																																	
            if (0 != salesCprtCndtnWork.CustomerCode)
            {
                retstring += " AND A.CUSTOMERCODERF=@ST_CUSTOMERCODE ";
                SqlParameter Para_St_customerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                Para_St_customerCode.Value = SqlDataMediator.SqlSetInt32(salesCprtCndtnWork.CustomerCode);
            }

            retstring += " AND (B.SALESSLIPCDDTLRF = 0 OR B.SALESSLIPCDDTLRF = 1 OR (B.SALESSLIPCDDTLRF = 2 AND B.SHIPMENTCNTRF = 0)) ";

            #endregion
            return retstring;
        }

        /// <summary>
        /// 売上連携テキスト送信ログ情報の登録処理。
        /// </summary>
        /// <param name="objectSalCprtSndLogWork">登録する売上連携テキスト送信ログ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : objectSalCprtSndLogWork に格納されている売上連携テキスト送信ログ情報を登録します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/06/26</br>
        public int WriteLog(ref object objectSalCprtSndLogWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                SalCprtSndLogListResultWork salCprtSndLogWork = objectSalCprtSndLogWork as SalCprtSndLogListResultWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteLogProc(salCprtSndLogWork, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesCprtDB.WriteLog(ref object)", status);
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
        ///売上連携テキスト送信ログ情報の登録処理
        /// </summary>
        /// <param name="salCprtSndLogWork">登録する売上連携テキスト送信ログ情報</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : salCprtSndLogWork に格納されている売上連携テキスト送信ログ情報を登録します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        private int WriteLogProc(SalCprtSndLogListResultWork salCprtSndLogWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (salCprtSndLogWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();

                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    # region [SELECT文]
                    sqlText.Append(" SELECT UPDATEDATETIMERF").Append( Environment.NewLine);
                    sqlText.Append(" FROM SALCPRTSNDLOGRF").Append(Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append( Environment.NewLine);
                    sqlText.Append("   AND SECTIONCODERF=@FINDSECTIONCODE").Append( Environment.NewLine);
                    sqlText.Append("   AND AUTOSENDDIVRF=@FINDAUTOSENDDIV").Append(Environment.NewLine);
                    sqlText.Append("   AND SENDDATETIMESTARTRF=@FINDSENDDATETIMESTART").Append( Environment.NewLine);
                    sqlText.Append("   AND SENDOBJCUSTSTARTRF=@FINDSENDOBJCUSTSTART").Append(Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameterオブジェクトの作成
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);
                    SqlParameter findParaAutoSendDiv = sqlCommand.Parameters.Add("@FINDAUTOSENDDIV", SqlDbType.NChar);
                    SqlParameter findParaSendDateTimeStart = sqlCommand.Parameters.Add("@FINDSENDDATETIMESTART", SqlDbType.BigInt);
                    SqlParameter findParaSendObjCustStart = sqlCommand.Parameters.Add("@FINDSENDOBJCUSTSTART", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.SectionCode);
                    findParaAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SAndEAutoSendDiv);
                    findParaSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendDateTimeStart);
                    findParaSendObjCustStart.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendObjCustStart);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                        if (_updateDateTime != salCprtSndLogWork.UpdateDateTime)
                        {
                            if (salCprtSndLogWork.UpdateDateTime == DateTime.MinValue)
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
                        if (salCprtSndLogWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        # region [INSERT文]
                        sqlText = new StringBuilder();
                        sqlText.Append("INSERT INTO SALCPRTSNDLOGRF").Append(Environment.NewLine);
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
                        sqlText.Append(" ,AUTOSENDDIVRF").Append( Environment.NewLine);
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
                        sqlText.Append(" ,@AUTOSENDDIV").Append(Environment.NewLine);
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
                        IFileHeader flhd = (IFileHeader)salCprtSndLogWork;
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
                    SqlParameter paraAutoSendDiv = sqlCommand.Parameters.Add("@AUTOSENDDIV", SqlDbType.Int);
                    SqlParameter paraSendDateTimeStart = sqlCommand.Parameters.Add("@SENDDATETIMESTART", SqlDbType.BigInt);
                    SqlParameter paraSendDateTimeEnd = sqlCommand.Parameters.Add("@SENDDATETIMEEND", SqlDbType.BigInt);
                    SqlParameter paraSendObjDateStart = sqlCommand.Parameters.Add("@SENDOBJDATESTART", SqlDbType.BigInt);
                    SqlParameter paraSendObjDateEnd = sqlCommand.Parameters.Add("@SENDOBJDATEEND", SqlDbType.BigInt);
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
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salCprtSndLogWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salCprtSndLogWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(salCprtSndLogWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.SectionCode);
                    paraAutoSendDiv.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SAndEAutoSendDiv);
                    paraSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendDateTimeStart);
                    paraSendDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendDateTimeEnd);
                    paraSendObjDateStart.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendObjDateStart);
                    paraSendObjDateEnd.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendObjDateEnd);
                    paraSendObjCustStart.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendObjCustStart);
                    paraSendObjCustEnd.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendObjCustEnd);
                    paraSendObjDiv.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendObjDiv);
                    paraSendResults.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendResults);
                    paraSendErrorContents.Value = SqlDataMediator.SqlSetString(salCprtSndLogWork.SendErrorContents);
                    paraSendSlipCount.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendSlipCount);
                    paraSendSlipDtlCnt.Value = SqlDataMediator.SqlSetInt32(salCprtSndLogWork.SendSlipDtlCnt);
                    paraSendSlipTotalMny.Value = SqlDataMediator.SqlSetInt64(salCprtSndLogWork.SendSlipTotalMny);

                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "SalesCprtDB.WriteLogProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SalesCprtDB.WriteLogProc", status);
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

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
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
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
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

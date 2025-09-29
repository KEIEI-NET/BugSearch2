//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト出力リモートオブジェクト
// プログラム概要   : 売上データテキスト出力を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11370098-00  作成担当 : 陳艶丹
// 作 成 日  2017/11/20   修正内容 : 新規作成
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上データテキストDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データテキストの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/11/20</br>
    /// </remarks>
    [Serializable]
    public class EDISalesResultDB : RemoteDB, IEDISalesResultDB
    {
        #region
        /// <summary>
        /// 売上データテキストコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        public EDISalesResultDB()
            :
        base("PMEDI02016D", "Broadleaf.Application.Remoting.ParamData.EDISalesResultWork", "SALESHISTORYRF") //基底クラスのコンストラクタ
        {
        }
        #endregion

        #region const
        /// <summary>受注ステータス（30：売上）</summary>
        private const int SalesAcptAnOdrStatus = 30;
        /// <summary>赤伝区分(0:黒伝)</summary>
        private const int DebitNoteDiv = 0;
        /// <summary>受注マスタ（車両）.受注ステータス（7：売上）</summary>
        private const int SalesAcceptStatusCar = 7;
        /// <summary>受注マスタ（車両）.データ入力システム（10：PM）</summary>
        private const int DataInputSystemPm = 10;
        // 売上伝票区分（明細）(0:売上)
        private const int SalesSlipCdDtl = 0;
        // 売上伝票区分（明細）(1:返品)
        private const int RetSlipCdDtl = 1;
        #endregion

        #region Search
        /// <summary>
        /// 指定された企業コードの売上データテキストの全て戻る処理（論理削除除く）
        /// </summary>
        /// <param name="eDISalesResultObj">検索結果</param>
        /// <param name="eDISalesCndtnObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの売上データLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        public int Search(out object eDISalesResultObj, object eDISalesCndtnObj)
        {
            SqlConnection sqlConnection = null;
            eDISalesResultObj = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    status = SearchProc(out eDISalesResultObj, eDISalesCndtnObj, ref sqlConnection);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDISalesResultDB.Search Exception=" + ex.Message, status);
                }
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの売上データテキストを全て戻る処理
        /// </summary>
        /// <param name="eDISalesResultObj">検索結果</param>
        /// <param name="eDISalesCndtnObj">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの仕入データLISTを全て戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        private int SearchProc(out object eDISalesResultObj, object eDISalesCndtnObj, ref SqlConnection sqlConnection)
        {
            EDISalesCndtnWork cndtnWork = eDISalesCndtnObj as EDISalesCndtnWork;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList al = new ArrayList();   //抽出結果
            eDISalesResultObj = null;
            SqlCommand sqlCommand = null;
            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(" SELECT ");
                    sb.AppendLine(" A.CREATEDATETIMERF, ");
                    sb.AppendLine(" A.ENTERPRISECODERF, ");
                    sb.AppendLine(" A.ACPTANODRSTATUSRF, ");
                    sb.AppendLine(" A.SALESSLIPNUMRF, ");
                    sb.AppendLine(" A.SALESSLIPCDRF, ");
                    sb.AppendLine(" A.RESULTSADDUPSECCDRF, ");
                    sb.AppendLine(" A.SALESDATERF, ");
                    sb.AppendLine(" A.CUSTOMERCODERF, ");
                    sb.AppendLine(" A.SALESEMPLOYEENMRF, ");
                    sb.AppendLine(" A.SLIPNOTERF, ");
                    sb.AppendLine(" B.SALESROWNORF, ");
                    sb.AppendLine(" B.GOODSMAKERCDRF, ");
                    sb.AppendLine(" B.GOODSNORF, ");
                    sb.AppendLine(" B.GOODSNAMEKANARF, ");
                    sb.AppendLine(" B.BLGOODSCODERF, ");
                    sb.AppendLine(" B.SALESUNPRCTAXEXCFLRF, ");
                    sb.AppendLine(" B.SHIPMENTCNTRF, ");
                    sb.AppendLine(" B.SALESMONEYTAXEXCRF, ");
                    sb.AppendLine(" B.LISTPRICETAXEXCFLRF, ");
                    sb.AppendLine(" C.FULLMODELRF, ");
                    sb.AppendLine(" C.MODELHALFNAMERF, ");
                    sb.AppendLine(" D.ENTERPRISECODERF AS EDIENTERPRISECODERF, ");
                    sb.AppendLine(" D.ACPTANODRSTATUSRF AS EDIACPTANODRSTATUSRF, ");
                    sb.AppendLine(" D.SALESSLIPNUMRF AS EDISALESSLIPNUMRF, ");
                    sb.AppendLine(" D.SALESCREATEDATETIMERF AS EDISALESCREATEDATETIMERF, ");
                    sb.AppendLine(" E.SECTIONCODERF, ");         // 拠点コード
                    sb.AppendLine(" E.CUSTOMERCODERF AS  EDICUSTOMERCODERF, ");        // 得意先コード
                    sb.AppendLine(" E.COOPERATOFFICECODERF, ");  // 連携事業所コード
                    sb.AppendLine(" E.COOPERATCUSTCODERF,");     // 連携得意先コード
                    sb.AppendLine(" E.TRADCOMPCDRF, ");          // 部品商コード
                    sb.AppendLine(" E.TRADCOMPNAMERF, ");        // 部品商名称
                    sb.AppendLine(" E.GOODSCODERF, ");           // 商品コード
                    sb.AppendLine(" E.INCREASEBLGOODSCODERF, ");    // 値増BL商品コード
                    sb.AppendLine(" E.DISCOUNTBLGOODSCODERF ");    // 値引BL商品コード

                    sb.AppendLine(" FROM SALESHISTORYRF A WITH (READUNCOMMITTED)");

                    sb.AppendLine(" INNER JOIN SALESHISTDTLRF B WITH (READUNCOMMITTED) ");
                    sb.AppendLine(" ON A.ENTERPRISECODERF =  B.ENTERPRISECODERF ");
                    sb.AppendLine(" AND A.ACPTANODRSTATUSRF = B.ACPTANODRSTATUSRF ");
                    sb.AppendLine(" AND A.SALESSLIPNUMRF =  B.SALESSLIPNUMRF ");
                    sb.AppendLine(" AND A.LOGICALDELETECODERF = B.LOGICALDELETECODERF ");

                    sb.AppendLine(" INNER JOIN ACCEPTODRCARRF C WITH (READUNCOMMITTED)");
                    sb.AppendLine(" ON A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                    sb.AppendLine(" AND B.ACCEPTANORDERNORF = C.ACCEPTANORDERNORF ");
                    sb.AppendLine(" AND A.ACPTANODRSTATUSRF = " + SalesAcptAnOdrStatus);
                    sb.AppendLine(" AND C.ACPTANODRSTATUSRF = " + SalesAcceptStatusCar);
                    sb.AppendLine(" AND C.DATAINPUTSYSTEMRF = " + DataInputSystemPm);
                    sb.AppendLine(" AND C.LOGICALDELETECODERF = " + (int)ConstantManagement.LogicalMode.GetData0);

                    sb.AppendLine(" INNER JOIN EDICOOPERATSTRF E WITH (READUNCOMMITTED)");
                    sb.AppendLine(" ON A.ENTERPRISECODERF =  E.ENTERPRISECODERF ");
                    sb.AppendLine(" AND A.RESULTSADDUPSECCDRF =  E.SECTIONCODERF ");
                    sb.AppendLine(" AND A.CUSTOMERCODERF =  E.CUSTOMERCODERF ");
                    sb.AppendLine(" AND E.LOGICALDELETECODERF = " + (int)ConstantManagement.LogicalMode.GetData0);

                    sb.AppendLine(" LEFT JOIN EDISALEXTRDTRF D WITH (READUNCOMMITTED)");
                    sb.AppendLine(" ON A.ENTERPRISECODERF =  D.ENTERPRISECODERF ");
                    sb.AppendLine(" AND A.ACPTANODRSTATUSRF = D.ACPTANODRSTATUSRF ");
                    sb.AppendLine(" AND A.SALESSLIPNUMRF = D.SALESSLIPNUMRF ");
                    sb.AppendLine(" AND D.LOGICALDELETECODERF = " + (int)ConstantManagement.LogicalMode.GetData0);

                    // 検索条件
                    sb.AppendLine(MakeWhereString(ref sqlCommand, cndtnWork));

                    sb.AppendLine(" ORDER BY ");
                    sb.AppendLine(" A.RESULTSADDUPSECCDRF,A.CUSTOMERCODERF,A.SALESSLIPNUMRF,B.SALESROWNORF ");

                    sqlCommand.CommandText = sb.ToString();

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            EDISalesResultWork eDISalesResultWork = new EDISalesResultWork();
                            eDISalesResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            eDISalesResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            eDISalesResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                            eDISalesResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                            eDISalesResultWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                            eDISalesResultWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                            eDISalesResultWork.SalesDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESDATERF"));
                            eDISalesResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                            eDISalesResultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                            eDISalesResultWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                            eDISalesResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                            eDISalesResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                            eDISalesResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                            eDISalesResultWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                            eDISalesResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                            eDISalesResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                            eDISalesResultWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                            eDISalesResultWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                            eDISalesResultWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                            eDISalesResultWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                            eDISalesResultWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
                            eDISalesResultWork.EDIEnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDIENTERPRISECODERF"));
                            eDISalesResultWork.EDIAcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDIACPTANODRSTATUSRF"));
                            eDISalesResultWork.EDISalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDISALESSLIPNUMRF"));
                            eDISalesResultWork.EDISalesCreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("EDISALESCREATEDATETIMERF"));
                            eDISalesResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                            eDISalesResultWork.EDICustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDICUSTOMERCODERF"));
                            eDISalesResultWork.CooperatOfficeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COOPERATOFFICECODERF"));
                            eDISalesResultWork.CooperatCustCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COOPERATCUSTCODERF"));
                            eDISalesResultWork.TradCompCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPCDRF"));
                            eDISalesResultWork.TradCompName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TRADCOMPNAMERF"));
                            eDISalesResultWork.GoodsCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCODERF"));
                            eDISalesResultWork.IncreaseBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INCREASEBLGOODSCODERF"));
                            eDISalesResultWork.DiscountBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISCOUNTBLGOODSCODERF"));
                            al.Add(eDISalesResultWork);

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }

                        if (al.Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }

                }
                catch (SqlException ex)
                {
                    // 基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.SearchProc Exception=" + ex.Message, status);
                }
            }
            eDISalesResultObj = al;
            return status;
        }
        #endregion

        #region Update
        /// <summary>
        /// 売上抽出データ情報を追加更新処理。
        /// </summary>
        /// <param name="eDISalesResultWorkObj">追加・更新する売上抽出データ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDISalesResultWorkObj に格納されている売上抽出データ情報を追加・更新します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        public int Write(ref object eDISalesResultWorkObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            // コネクション生成
            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    ArrayList eDISalesResultList = eDISalesResultWorkObj as ArrayList;
                    // トランザクション開始
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    foreach (EDISalesResultWork detailWork in eDISalesResultList)
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
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.Write Exception=" + ex.Message, status);
                }
                finally
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // コミット
                        sqlTransaction.Commit();
                    }
                    else
                    {
                        // ロールバック
                        if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    }

                    if (sqlTransaction != null) sqlTransaction.Dispose();
                }
            }
            return status;

        }

        /// <summary>
        ///売上抽出データ情報を物理削除処理
        /// </summary>
        /// <param name="eDISalesResultWork">売上抽出データ情報を格納する</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDISalesResultWork に格納されている売上抽出データ情報を物理削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        private int DeleteProc(EDISalesResultWork eDISalesResultWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    StringBuilder sqlTextDel = new StringBuilder();
                    #region
                    sqlTextDel.AppendLine(" DELETE ");
                    sqlTextDel.AppendLine(" FROM ");
                    sqlTextDel.AppendLine(" EDISALEXTRDTRF");
                    sqlTextDel.AppendLine(" WHERE ");
                    sqlTextDel.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    sqlTextDel.AppendLine(" AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS ");
                    sqlTextDel.AppendLine(" AND SALESSLIPNUMRF=@FINDSALESSLIPNUM ");
                    #endregion
                    sqlCommand.CommandText = sqlTextDel.ToString();

                    // Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                    SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.EnterpriseCode);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.SalesSlipNum);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(eDISalesResultWork.AcptAnOdrStatus);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException sqlex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(sqlex, "EDISalesResultDB.DeleteProc", status);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.DeleteProc Exception=" + ex.Message, status);
                }
            }

            return status;
        }

        /// <summary>
        ///売上抽出データ情報を追加処理
        /// </summary>
        /// <param name="eDISalesResultWork">売上抽出データ情報を格納する</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDISalesResultWork に格納されている売上抽出データ情報を追加します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        private int InsertProc(EDISalesResultWork eDISalesResultWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    //売上抽出データ. 売上データ作成日時
                    DateTime salesCreateDateTime = eDISalesResultWork.CreateDateTime; 
                    StringBuilder sqlText = new StringBuilder();
                    #region
                    sqlText.AppendLine(" INSERT INTO ");
                    sqlText.AppendLine(" EDISALEXTRDTRF");
                    sqlText.AppendLine(" (CREATEDATETIMERF, ");
                    sqlText.AppendLine(" UPDATEDATETIMERF, ");
                    sqlText.AppendLine(" ENTERPRISECODERF, ");
                    sqlText.AppendLine(" FILEHEADERGUIDRF, ");
                    sqlText.AppendLine(" UPDEMPLOYEECODERF, ");
                    sqlText.AppendLine(" UPDASSEMBLYID1RF, ");
                    sqlText.AppendLine(" UPDASSEMBLYID2RF, ");
                    sqlText.AppendLine(" LOGICALDELETECODERF, ");
                    sqlText.AppendLine(" ACPTANODRSTATUSRF, ");
                    sqlText.AppendLine(" SALESSLIPNUMRF, ");
                    sqlText.AppendLine(" SALESCREATEDATETIMERF) ");

                    sqlText.AppendLine(" VALUES ");
                    sqlText.AppendLine(" (@CREATEDATETIME, ");
                    sqlText.AppendLine(" @UPDATEDATETIME, ");
                    sqlText.AppendLine(" @ENTERPRISECODE, ");
                    sqlText.AppendLine(" @FILEHEADERGUID, ");
                    sqlText.AppendLine(" @UPDEMPLOYEECODE, ");
                    sqlText.AppendLine(" @UPDASSEMBLYID1, ");
                    sqlText.AppendLine(" @UPDASSEMBLYID2, ");
                    sqlText.AppendLine(" @LOGICALDELETECODE, ");
                    sqlText.AppendLine(" @ACPTANODRSTATUS, ");
                    sqlText.AppendLine(" @SALESSLIPNUM, ");
                    sqlText.AppendLine(" @SALESCREATEDATETIME) ");

                    #endregion
                    sqlCommand.CommandText = sqlText.ToString();

                    // 登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)eDISalesResultWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //Prameterオブジェクトの作成
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

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(eDISalesResultWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(eDISalesResultWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(eDISalesResultWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(eDISalesResultWork.LogicalDeleteCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(eDISalesResultWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(eDISalesResultWork.SalesSlipNum);
                    paraSalesCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(salesCreateDateTime);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException sqlex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(sqlex, "EDISalesResultDB.InsertProc", status);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "EDICooperatStDB.InsertProc Exception==" + ex.Message, status);
                }
            }

            return status;
        }

        #endregion

        #region
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="eDISalesCndtnWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 検索条件文字列生成＋条件値設定を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, EDISalesCndtnWork eDISalesCndtnWork)
        {
            #region WHERE文作成
            string retstring = " WHERE ";

            // 企業コード
            retstring += " A.ENTERPRISECODERF=@ENTERPRISECODERF";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODERF", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(eDISalesCndtnWork.EnterpriseCode);

            // 売上履歴データ.論理削除区分
            retstring += " AND A.LOGICALDELETECODERF=@ALOGICALDELETECODERF";
            SqlParameter paraALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODERF", SqlDbType.Int);
            paraALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);

            // 受注ステータス
            retstring += " AND A.ACPTANODRSTATUSRF=@ACPTANODRSTATUSRF";
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUSRF", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(SalesAcptAnOdrStatus);

            // 拠点コード    ※配列で複数指定される
            if (eDISalesCndtnWork.SectionCodeList != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in eDISalesCndtnWork.SectionCodeList)
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

            // AND 売上日付>＝パラメータ.売上日付の開始日
            if (!DateTime.MinValue.Equals(eDISalesCndtnWork.AddUpADateSt))
            {
                retstring += " AND A.SALESDATERF>=@ST_SCVDAY ";
                SqlParameter paraStCsvDate = sqlCommand.Parameters.Add("@ST_SCVDAY", SqlDbType.Int);
                paraStCsvDate.Value = SqlDataMediator.SqlSetInt32(eDISalesCndtnWork.AddUpADateSt);
            }

            // AND 売上日付<＝パラメータ.売上日付の終了日
            if (!DateTime.MinValue.Equals(eDISalesCndtnWork.AddUpADateEd))
            {
                retstring += " AND A.SALESDATERF<=@ED_SCVDAY ";
                SqlParameter paraEdCsvDate = sqlCommand.Parameters.Add("@ED_SCVDAY", SqlDbType.Int);
                paraEdCsvDate.Value = SqlDataMediator.SqlSetInt32(eDISalesCndtnWork.AddUpADateEd);
            }

            // AND 得意先コード>＝パラメータ.得意先コードの開始
            if (0 != eDISalesCndtnWork.CustomerCodeSt)
            {
                retstring += " AND A.CUSTOMERCODERF>=@ST_CUSTOMERCODE ";
                SqlParameter ParaStCustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                ParaStCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDISalesCndtnWork.CustomerCodeSt);
            }

            // AND 得意先コード<＝パラメータ.得意先コードの終了
            if (0 != eDISalesCndtnWork.CustomerCodeEd)
            {
                retstring += " AND A.CUSTOMERCODERF<=@ED_CUSTOMERCODE ";
                SqlParameter ParaEdCustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE", SqlDbType.Int);
                ParaEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(eDISalesCndtnWork.CustomerCodeEd);
            }
            // 赤伝区分
            retstring += " AND A.DEBITNOTEDIVRF=@DEBITNOTEDIVRF";
            SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@DEBITNOTEDIVRF", SqlDbType.Int);
            paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(DebitNoteDiv);

            // 売上伝票区分（明細）(0:売上,1:返品)
            retstring += " AND B.SALESSLIPCDDTLRF IN (@SALESSLIPCDDTL, @RETSLIPCDDTL)";
            SqlParameter paraSalesSlipCdDtl = sqlCommand.Parameters.Add("@SALESSLIPCDDTL", SqlDbType.Int);
            paraSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(SalesSlipCdDtl);
            SqlParameter paraRetSlipCdDtl = sqlCommand.Parameters.Add("@RETSLIPCDDTL", SqlDbType.Int);
            paraRetSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(RetSlipCdDtl);

            #endregion
            return retstring;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection生成処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
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
        #endregion  //コネクション生成処理
    }
}

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受注マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受注マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.09.12</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.28　採番処理の共通部品化に伴う修正</br>
    /// </remarks>
    [Serializable]
    public class AcceptOdrDB : RemoteWithAppLockDB, IAcceptOdrDB
    {
        /// <summary>
        /// 受注マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        /// </remarks>
        public AcceptOdrDB()
            :
            base("DCCMN00106D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrWork", "ACCEPTODRRF")
        {
        }

        #region [採番処理]
        /// <summary>
        /// 受注番号を採番します。
        /// </summary>
        /// <param name="enterprisecode">企業コードを指定します。</param>
        /// <param name="sectioncode">拠点コードを指定します。</param>
        /// <param name="acceptanorderno">採番した受注番号を返します。</param>
        /// <returns>STATUS</returns>
        public int GetAcceptAnOrderNo(string enterprisecode, string sectioncode, out Int32 acceptanorderno)
        {
            // 受注番号を採番する
            Int64 acceptanorderno64;
            
            int status = GetSerialNumber(enterprisecode, sectioncode, SerialNumberCode.AcceptAnOrderNo, out acceptanorderno64);

            acceptanorderno = (Int32)acceptanorderno64;
            
            return status;
        }

        /// <summary>
        /// 共通通番を採番します。
        /// </summary>
        /// <param name="enterprisecode">企業コードを指定します。</param>
        /// <param name="sectioncode">拠点コードを指定します。</param>
        /// <param name="commonseqno">採番した共通通番を返します。</param>
        /// <returns>STATUS</returns>
        public int GetCommonSeqNo(string enterprisecode, string sectioncode, out Int64 commonseqno)
        {
            // 共通通番を採番する
            return GetSerialNumber(enterprisecode, sectioncode, SerialNumberCode.CommonNo, out commonseqno);
        }

        /// <summary>
        /// 伝票明細通番を採番します。
        /// </summary>
        /// <param name="enterprisecode">企業コードを指定します。</param>
        /// <param name="sectioncode">拠点コードを指定します。</param>
        /// <param name="slipdatadivide">伝票データ区分を指定します。</param>
        /// <param name="slipdetailno">採番した伝票明細通番を返します。</param>
        /// <returns>STATUS</returns>
        public int GetSlipDetailNo(string enterprisecode, string sectioncode, int slipdatadivide, out Int64 slipdetailno)
        {
            SerialNumberCode serialnumcd = SerialNumberCode.Empty;

            // 伝票データ区分に応じた番号コードを設定する
            switch (slipdatadivide)
            {
                case (int)SlipDataDivide.Estimate:              // 見積                
                case (int)SlipDataDivide.Sales:                 // 売上
                case (int)SlipDataDivide.AcceptAnOrder:         // 受注
                case (int)SlipDataDivide.Shipment:              // 出荷
                //case (int)SlipDataDivide.ShipmentReturnedGoods: // 出荷返品
                //case (int)SlipDataDivide.SalesReturnedGoods:    // 売上返品
                    {
                        serialnumcd = SerialNumberCode.SailsDtlNo;
                        break;
                    }
                case (int)SlipDataDivide.Stock:                 // 仕入
                case (int)SlipDataDivide.SalesOrder:            // 発注
                case (int)SlipDataDivide.ArrivalGoods:          // 入荷
                //case (int)SlipDataDivide.ArrivalReturnedGoods:  // 入荷返品
                //case (int)SlipDataDivide.StockReturnedGoods:    // 仕入返品
                    {
                        serialnumcd = SerialNumberCode.StockDtlNo;
                        break;
                    }
                case (int)SlipDataDivide.Deposit:               // 入金
                    {
                        serialnumcd = SerialNumberCode.DepositDtlNo;
                        break;
                    }

                case (int)SlipDataDivide.Payment:               // 支払
                    {
                        serialnumcd = SerialNumberCode.PaymentDtlNo;
                        break;
                    }
            }

            return GetSerialNumber(enterprisecode, sectioncode, serialnumcd, out slipdetailno);
        }

        /// <summary>
        /// 通番を採番します。
        /// </summary>
        /// <param name="enterprisecode">企業コードを指定します。</param>
        /// <param name="sectioncode">拠点コードを指定します。</param>
        /// <param name="serialnumcd">通番コードを指定します。</param>
        /// <param name="serialnumber">番号コードに基いて採番された通番を返します。</param>
        /// <returns>STATUS</returns>
        private int GetSerialNumber(string enterprisecode, string sectioncode, SerialNumberCode serialnumcd, out Int64 serialnumber)
        {
            // 処理の実現部を共通クラス化して PMCMN00005 に移動しました。
            NumberingManager numberingMng = new NumberingManager();
            return numberingMng.GetSerialNumber(enterprisecode, sectioncode, serialnumcd, out serialnumber);
        }

        #endregion

        #region [Search]
        /// <summary>
        /// 指定された条件の受注マスタ情報LISTを戻します
        /// </summary>
        /// <param name="acceptOdrWork">検索結果</param>
        /// <param name="paraacceptOdrWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受注マスタ情報LISTを戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        public int Search(out object acceptOdrWork, object paraacceptOdrWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction dummyTransaction = null;
            acceptOdrWork = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else
                {
                    sqlConnection.Open();
                    status = SearchAcceptOdrProc(out acceptOdrWork, paraacceptOdrWork, readMode, logicalMode, ref sqlConnection, ref dummyTransaction);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AcceptOdrDB.Search");
                acceptOdrWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の受注マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objacceptOdrWork">検索結果</param>
        /// <param name="paraacceptOdrWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受注マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        public int SearchAcceptOdrProc(out object objacceptOdrWork, object paraacceptOdrWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            AcceptOdrWork acceptodrWork = null;

            ArrayList acceptodrWorkList = paraacceptOdrWork as ArrayList;

            if (acceptodrWorkList == null)
            {
                acceptodrWork = paraacceptOdrWork as AcceptOdrWork;
            }
            else
            {
                if (acceptodrWorkList.Count > 0)
                {
                    acceptodrWork = acceptodrWorkList[0] as AcceptOdrWork;
                }
            }

            int status = SearchAcceptOdrProc(out acceptodrWorkList, acceptodrWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

            objacceptOdrWork = acceptodrWorkList;

            return status;
        }

        /// <summary>
        /// 指定された条件の受注マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acceptodrWorkList">検索結果</param>
        /// <param name="acceptodrWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受注マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        public int SearchAcceptOdrProc(out ArrayList acceptodrWorkList, AcceptOdrWork acceptodrWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList retList = new ArrayList();

            if (acceptodrWork != null && sqlConnection != null)
            {
                SqlDataReader myReader = null;
                SqlCommand sqlCommand = null;

                try
                {
                    # region [SELECT句]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  ACC1.CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ACC1.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ACC1.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,ACC1.FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,ACC1.UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,ACC1.UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,ACC1.UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,ACC1.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACC1.SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,ACC1.ACCEPTANORDERNORF" + Environment.NewLine;
                    sqlText += " ,ACC1.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,ACC1.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,ACC1.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += " ,ACC1.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += " ,ACC1.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,ACC1.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                    sqlText += " ,ACC1.SRCLINKDATACODERF" + Environment.NewLine;
                    sqlText += " ,ACC1.SRCSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  ACCEPTODRRF AS ACC1 INNER JOIN" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "    SELECT" + Environment.NewLine;
                    sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "     ,MAX(SUB.SLIPDTLNUMDERIVNORF) AS SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                    sqlText += "    FROM" + Environment.NewLine;
                    sqlText += "      ACCEPTODRRF AS SUB" + Environment.NewLine;
                    sqlText += "    WHERE" + Environment.NewLine;
                    sqlText += "      SUB.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "    GROUP BY" + Environment.NewLine;
                    sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "  )  AS ACC2" + Environment.NewLine;
                    sqlText += "  ON  ACC1.ENTERPRISECODERF = ACC2.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND ACC1.SECTIONCODERF = ACC2.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "  AND ACC1.ACPTANODRSTATUSRF = ACC2.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = ACC2.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "  AND ACC1.COMMONSEQNORF = ACC2.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "  AND ACC1.SLIPDTLNUMRF = ACC2.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "  AND ACC1.SLIPDTLNUMDERIVNORF = ACC2.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [WHERE句]
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ACC1.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ACC1.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlText += "  AND ACC1.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;

                    // 固定絞込み条件
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);        // 拠点コード
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);  // 受注ステータス
                    SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);  // データ入力システム

                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                    findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);

                    // 可変絞込み条件
                    if (string.IsNullOrEmpty(acceptodrWork.SalesSlipNum) || acceptodrWork.SalesSlipNum == "0")
                    {
                        // 通常は共通通番と明細通番を検索条件として絞込みを行う
                        sqlText += "  AND ACC1.COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                        sqlText += "  AND ACC1.SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;
                        SqlParameter findCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                        SqlParameter findSlipDtlNum = sqlCommand.Parameters.Add("@FINDSLIPDTLNUM", SqlDbType.BigInt);
                        findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                        findSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                    }
                    else
                    {
                        // 伝票番号が検索条件に設定されている場合は、そちらを優先して絞込み条件とする
                        sqlText += "  AND ACC1.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                        SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                        findSalesSlipNum.Value = SqlDataMediator.SqlSetString(acceptodrWork.SalesSlipNum);
                    }

                    // 論理削除区分
                    string wkstring = "";
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "  AND ACC1.LOGICALDELETECODERF = @FINDLOGICALDELETECODE";
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                             (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "  AND ACC1.LOGICALDELETECODERF < @FINDLOGICALDELETECODE";
                    }

                    if (wkstring != "")
                    {
                        sqlText += wkstring;
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    #endregion

#if DEBUG
                    Console.Clear();
                    Console.WriteLine("--- 変数 ---");

                    foreach (SqlParameter param in sqlCommand.Parameters)
                    {
                        string sqlDbType = param.SqlDbType.ToString();
                        if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                        {
                            sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                        }

                        string value = param.Value.ToString();
                        if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                        {
                            value = string.Format("'{0}'", param.Value);
                        }

                        Console.WriteLine(string.Format("DECLARE {0} {1}", param.ParameterName, sqlDbType));
                        Console.WriteLine(string.Format("SET {0} = {1}", param.ParameterName, value));
                        Console.WriteLine("");
                    }

                    Console.WriteLine("--- SQL ---");
                    Console.WriteLine(sqlText);
#endif

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        retList.Add(CopyToAcceptOdrWorkFromReader(ref myReader));

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
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
            }

            acceptodrWorkList = retList;
            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 受注マスタ情報を登録、更新します
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ情報を登録、更新します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        public int Write(ref object acceptOdrWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(acceptOdrWork);

                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null) return status;

                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteAcceptOdrProc(ref paraList, ref sqlConnection, ref sqlTransaction);

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

                //戻り値セット
                acceptOdrWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AcceptOdrDB.Write(ref object acceptOdrWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
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
        /// 受注マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="acceptOdrWorkList">AcceptOdrWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        public int WriteAcceptOdrProc(ref ArrayList acceptOdrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (acceptOdrWorkList != null && acceptOdrWorkList.Count > 0)
                {
                    string sqlText = "";

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    
                    foreach (object item in acceptOdrWorkList)
                    {
                        AcceptOdrWork acceptodrWork = item as AcceptOdrWork;

                        if (string.IsNullOrEmpty(acceptodrWork.SalesSlipNum))
                        {
                            // 伝票番号が未設定(空白 or NULL)の場合は "0" とする
                            acceptodrWork.SalesSlipNum = "0";
                        }
                        
                        if (acceptodrWork != null)
                        {
                            try
                            {
                                # region [最大明細通番枝番取得処理]
                                // 企業コード + 拠点コード + 受注ステータス + データ入力システム + 共通通番 + 明細通番 で絞込み、最大の明細通番枝番を取得する
                                // ※ 論理削除されていても集計の対象とする。
                                sqlText = string.Empty;
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  ACC1.SALESSLIPNUMRF" + Environment.NewLine;       // 伝票番号
                                sqlText += " ,ACC1.ACCEPTANORDERNORF" + Environment.NewLine;    // 受注番号
                                sqlText += " ,ACC1.SRCLINKDATACODERF" + Environment.NewLine;    // 連携元データ区分
                                sqlText += " ,ACC1.SRCSLIPDTLNUMRF" + Environment.NewLine;      // 連携元明細通番
                                sqlText += " ,ACC1.SLIPDTLNUMDERIVNORF" + Environment.NewLine;  // 明細通番枝番
                                sqlText += "FROM" + Environment.NewLine;
                                sqlText += "  ACCEPTODRRF AS ACC1 INNER JOIN" + Environment.NewLine;
                                sqlText += "  (" + Environment.NewLine;
                                sqlText += "    SELECT" + Environment.NewLine;
                                sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                                sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                                sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                                sqlText += "     ,MAX(SUB.SLIPDTLNUMDERIVNORF) AS SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                                sqlText += "    FROM" + Environment.NewLine;
                                sqlText += "      ACCEPTODRRF AS SUB" + Environment.NewLine;
                                sqlText += "    WHERE" + Environment.NewLine;
                                sqlText += "      SUB.LOGICALDELETECODERF = 0" + Environment.NewLine;
                                sqlText += "    GROUP BY" + Environment.NewLine;
                                sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                                sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                                sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                                sqlText += "  )  AS ACC2" + Environment.NewLine;
                                sqlText += "  ON  ACC1.ENTERPRISECODERF = ACC2.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "  AND ACC1.SECTIONCODERF = ACC2.SECTIONCODERF" + Environment.NewLine;
                                sqlText += "  AND ACC1.ACPTANODRSTATUSRF = ACC2.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = ACC2.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlText += "  AND ACC1.COMMONSEQNORF = ACC2.COMMONSEQNORF" + Environment.NewLine;
                                sqlText += "  AND ACC1.SLIPDTLNUMRF = ACC2.SLIPDTLNUMRF" + Environment.NewLine;
                                sqlText += "  AND ACC1.SLIPDTLNUMDERIVNORF = ACC2.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ACC1.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND ACC1.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                                sqlText += "  AND ACC1.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                                sqlText += "  AND ACC1.COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                                sqlText += "  AND ACC1.SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;

                                sqlCommand.CommandText = sqlText;

                                //Prameterオブジェクトの作成
                                sqlCommand.Parameters.Clear();
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                                SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                                SqlParameter findParaCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                                SqlParameter findParaSlipDtlNum = sqlCommand.Parameters.Add("@FINDSLIPDTLNUM", SqlDbType.BigInt);

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                                findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                                findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                                findParaCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                                findParaSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);

#if DEBUG
                                Console.Clear();
                                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                                int RetryCount = 5;  // 問い合わせリトライ回数

                                while (true)  // リトライ用のループ
                                {
                                    try
                                    {
                                        myReader = sqlCommand.ExecuteReader();
                                        break;
                                    }
                                    catch (SqlException sqlEx)
                                    {
                                        // ロックタイムアウト以外の SqlException が発生した場合、又は
                                        // ロックタイムアウトによるリトライ回数を既に超えている場合は
                                        // 例外をそのままスローする。
                                        if (sqlEx.Number != 1222 || RetryCount <= 0)
                                        {
                                            throw sqlEx;
                                        }
                                        RetryCount--;
                                    }
                                }

                                int NextSlipDtlNumDerivNo = 0;

                                if (myReader.Read())
                                {
                                    // 共通ヘッダ、並びにキー以外の項目に変更がある場合にのみ変更を行う

                                    AcceptOdrWork tmpacceptOdrWork = new AcceptOdrWork();

                                    tmpacceptOdrWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                                    tmpacceptOdrWork.SrcLinkDataCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCLINKDATACODERF"));
                                    tmpacceptOdrWork.SrcSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SRCSLIPDTLNUMRF"));

                                    if (tmpacceptOdrWork.AcceptAnOrderNo == acceptodrWork.AcceptAnOrderNo &&
                                        tmpacceptOdrWork.SrcLinkDataCode == acceptodrWork.SrcLinkDataCode &&
                                        tmpacceptOdrWork.SrcSlipDtlNum == acceptodrWork.SrcSlipDtlNum &&
                                        tmpacceptOdrWork.LogicalDeleteCode == acceptodrWork.LogicalDeleteCode)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        // 枝番を＋１して追加処理を行う。
                                        NextSlipDtlNumDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDTLNUMDERIVNORF"));
                                    }
                                }

                                acceptodrWork.SlipDtlNumDerivNo = ++NextSlipDtlNumDerivNo;
                                # endregion

                                # region [書き込み処理]
                                sqlText = string.Empty;
                                sqlText += "INSERT INTO ACCEPTODRRF" + Environment.NewLine;
                                sqlText += "(" + Environment.NewLine;
                                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                                sqlText += " ,ACCEPTANORDERNORF" + Environment.NewLine;
                                sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                                sqlText += " ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlText += " ,COMMONSEQNORF" + Environment.NewLine;
                                sqlText += " ,SLIPDTLNUMRF" + Environment.NewLine;
                                sqlText += " ,SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                                sqlText += " ,SRCLINKDATACODERF" + Environment.NewLine;
                                sqlText += " ,SRCSLIPDTLNUMRF" + Environment.NewLine;
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
                                sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                                sqlText += " ,@ACCEPTANORDERNO" + Environment.NewLine;
                                sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                                sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                                sqlText += " ,@DATAINPUTSYSTEM" + Environment.NewLine;
                                sqlText += " ,@COMMONSEQNO" + Environment.NewLine;
                                sqlText += " ,@SLIPDTLNUM" + Environment.NewLine;
                                sqlText += " ,@SLIPDTLNUMDERIVNO" + Environment.NewLine;
                                sqlText += " ,@SRCLINKDATACODE" + Environment.NewLine;
                                sqlText += " ,@SRCSLIPDTLNUM" + Environment.NewLine;
                                sqlText += ")" + Environment.NewLine;

                                sqlCommand.CommandText = sqlText;

                                //登録ヘッダ情報を設定
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)acceptodrWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);

                                #region Parameterオブジェクトの作成(更新用)
                                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                                SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                                SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                                SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                                SqlParameter paraSlipDtlNum = sqlCommand.Parameters.Add("@SLIPDTLNUM", SqlDbType.BigInt);
                                SqlParameter paraSlipDtlNumDerivNo = sqlCommand.Parameters.Add("@SLIPDTLNUMDERIVNO", SqlDbType.Int);
                                SqlParameter paraSrcLinkDataCode = sqlCommand.Parameters.Add("@SRCLINKDATACODE", SqlDbType.Int);
                                SqlParameter paraSrcSlipDtlNum = sqlCommand.Parameters.Add("@SRCSLIPDTLNUM", SqlDbType.BigInt);
                                #endregion

                                #region Parameterオブジェクトへ値設定(更新用)
                                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptodrWork.CreateDateTime);
                                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptodrWork.UpdateDateTime);
                                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(acceptodrWork.FileHeaderGuid);
                                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdEmployeeCode);
                                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdAssemblyId1);
                                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdAssemblyId2);
                                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.LogicalDeleteCode);
                                paraSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcceptAnOrderNo);
                                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(acceptodrWork.SalesSlipNum);
                                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                                paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                                paraSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                                paraSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SlipDtlNumDerivNo);
                                paraSrcLinkDataCode.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SrcLinkDataCode);
                                paraSrcSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SrcSlipDtlNum);
                                #endregion

                                if (!myReader.IsClosed)
                                {
                                    myReader.Close();
                                }

                                sqlCommand.ExecuteNonQuery();

                                al.Add(acceptodrWork);
                                # endregion
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
                                    myReader = null;
                                }
                            }
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            acceptOdrWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 受注マスタ情報を論理削除します
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ情報を論理削除します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        public int LogicalDelete(ref object acceptOdrWork)
        {
            return LogicalDeleteAcceptOdr(ref acceptOdrWork, 0);
        }

        /// <summary>
        /// 論理削除受注マスタ情報を復活します
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除受注マスタ情報を復活します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        public int RevivalLogicalDelete(ref object acceptOdrWork)
        {
            return LogicalDeleteAcceptOdr(ref acceptOdrWork, 1);
        }

        /// <summary>
        /// 受注マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        private int LogicalDeleteAcceptOdr(ref object acceptOdrWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(acceptOdrWork);

                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteAcceptOdrProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
            }
            catch (Exception ex)
            {
                string procModestr = "";

                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";

                base.WriteErrorLog(ex, "AcceptOdrDB.LogicalDeleteAcceptOdr :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
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
        /// 受注マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="acceptOdrWorkList">AcceptOdrWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 受注マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        public int LogicalDeleteAcceptOdrProc(ref ArrayList acceptOdrWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (acceptOdrWorkList != null && sqlConnection != null)
                {
                    string sqlText = "";

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    foreach (object item in acceptOdrWorkList)
                    {
                        AcceptOdrWork acceptodrWork = item as AcceptOdrWork;

                        if (acceptodrWork != null)
                        {
                            # region [SELECT文]
                            sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  ACC1.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ACC1.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,ACC1.LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,ACC1.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  ACCEPTODRRF AS ACC1 INNER JOIN" + Environment.NewLine;
                            sqlText += "  (" + Environment.NewLine;
                            sqlText += "    SELECT" + Environment.NewLine;
                            sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                            sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                            sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                            sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "     ,MAX(SUB.SLIPDTLNUMDERIVNORF) AS SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                            sqlText += "    FROM" + Environment.NewLine;
                            sqlText += "      ACCEPTODRRF AS SUB" + Environment.NewLine;
                            sqlText += "    WHERE" + Environment.NewLine;
                            sqlText += "      SUB.LOGICALDELETECODERF = 0" + Environment.NewLine;
                            sqlText += "    GROUP BY" + Environment.NewLine;
                            sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                            sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                            sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                            sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "  )  AS ACC2" + Environment.NewLine;
                            sqlText += "  ON  ACC1.ENTERPRISECODERF = ACC2.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  AND ACC1.SECTIONCODERF = ACC2.SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  AND ACC1.ACPTANODRSTATUSRF = ACC2.ACPTANODRSTATUSRF" + Environment.NewLine;
                            sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = ACC2.DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlText += "  AND ACC1.COMMONSEQNORF = ACC2.COMMONSEQNORF" + Environment.NewLine;
                            sqlText += "  AND ACC1.SLIPDTLNUMRF = ACC2.SLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "  AND ACC1.SLIPDTLNUMDERIVNORF = ACC2.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ACC1.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACC1.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND ACC1.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlText += "  AND ACC1.COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                            sqlText += "  AND ACC1.SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;

                            # endregion

                            //Prameterオブジェクトの作成
                            sqlCommand.Parameters.Clear();
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                            SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                            SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                            SqlParameter findCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                            SqlParameter findSlipDtlNum = sqlCommand.Parameters.Add("@FINDSLIPDTLNUM", SqlDbType.BigInt);
                            SqlParameter findSlipDtlNumDerivNo = sqlCommand.Parameters.Add("@FINDSLIPDTLNUMDERIVNO", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                            findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                            findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                            findSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                            findSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SlipDtlNumDerivNo);

                            myReader = sqlCommand.ExecuteReader();
                            
                            try
                            {
                                if (myReader.Read())
                                {
                                    if (acceptodrWork.UpdateDateTime != DateTime.MinValue)
                                    {
                                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                        if (_updateDateTime != acceptodrWork.UpdateDateTime)
                                        {
                                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                            return status;
                                        }
                                    }

                                    //現在の論理削除区分を取得
                                    logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                                    # region [UPDATE文]
                                    sqlText = "";
                                    sqlText += "UPDATE" + Environment.NewLine;
                                    sqlText += "  ACCEPTODRRF" + Environment.NewLine;
                                    sqlText += "SET" + Environment.NewLine;
                                    sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += "WHERE" + Environment.NewLine;
                                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                                    sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                    sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                                    sqlText += "  AND COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                                    sqlText += "  AND SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;
                                    sqlText += "  AND SLIPDTLNUMDERIVNORF = @FINDSLIPDTLNUMDERIVNO" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    # endregion

                                    //更新ヘッダ情報を設定
                                    object obj = (object)this;
                                    IFileHeader flhd = (IFileHeader)acceptodrWork;
                                    FileHeader fileHeader = new FileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                    //論理削除モードの場合
                                    if (procMode == 0)
                                    {
                                        if (logicalDelCd == 3)
                                        {
                                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                            continue;
                                        }
                                        else if (logicalDelCd == 0) acceptodrWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                                        else acceptodrWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                                    }
                                    else
                                    {
                                        if (logicalDelCd == 1)
                                        {
                                            acceptodrWork.LogicalDeleteCode = 0; //論理削除フラグを解除
                                        }
                                        else
                                        {
                                            if (logicalDelCd == 0)
                                            {
                                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //既に復活している場合はそのまま正常を戻す
                                            }
                                            else
                                            {
                                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //完全削除はデータなしを戻す
                                            }

                                            continue;
                                        }
                                    }

                                    // 明細通番枝番を取得
                                    acceptodrWork.SlipDtlNumDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDTLNUMDERIVNORF"));

                                    //KEYコマンドを再設定
                                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                                    findSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                                    findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                                    findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                                    findSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                                    findSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SlipDtlNumDerivNo);

                                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptodrWork.UpdateDateTime);
                                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdEmployeeCode);
                                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdAssemblyId1);
                                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdAssemblyId2);
                                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.LogicalDeleteCode);

                                    sqlCommand.Cancel();

                                    if (!myReader.IsClosed)
                                    {
                                        myReader.Close();
                                    }

                                    sqlCommand.ExecuteNonQuery();
                                }
                                else
                                {
                                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    return status;
                                }
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
                                    myReader = null;
                                }
                            }
                        }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
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

        #region [Delete]
        /// <summary>
        /// 受注マスタ情報を物理削除します
        /// </summary>
        /// <param name="acceptOdrWork">受注マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 受注マスタ情報を物理削除します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        public int Delete(object acceptOdrWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(acceptOdrWork);

                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null) return status;

                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteAcceptOdrProc(paraList, ref sqlConnection, ref sqlTransaction);

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
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AcceptOdrDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
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
        /// 受注マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="acceptodrWorkList">受注マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 受注マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        public int DeleteAcceptOdrProc(ArrayList acceptodrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (acceptodrWorkList != null && sqlConnection != null)
            {
                SqlDataReader myReader = null;
                SqlCommand sqlCommand = null;
                string sqlText = "";

                try
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    foreach (object item in acceptodrWorkList)
                    {
                        AcceptOdrWork acceptodrWork = item as AcceptOdrWork;

                        if (acceptodrWork != null)
                        {
                            # region [SELECT文]
                            sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  ACC.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ACC.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,ACC.LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  ACCEPTODRRF AS ACC" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ACC.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACC.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND ACC.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND ACC.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlText += "  AND ACC.COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                            sqlText += "  AND ACC.SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;
                            sqlText += "  AND ACC.SLIPDTLNUMDERIVNORF = @FINDSLIPDTLNUMDERIVNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;                            
                            # endregion

                            //Prameterオブジェクトの作成
                            sqlCommand.Parameters.Clear();
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                            SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                            SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                            SqlParameter findCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                            SqlParameter findSlipDtlNum = sqlCommand.Parameters.Add("@FINDSLIPDTLNUM", SqlDbType.BigInt);
                            SqlParameter findSlipDtlNumDerivNo = sqlCommand.Parameters.Add("@FINDSLIPDTLNUMDERIVNO", SqlDbType.Int);

                            //Parameterオブジェクトへ値設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                            findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                            findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                            findSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                            findSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SlipDtlNumDerivNo);

                            myReader = sqlCommand.ExecuteReader();

                            try
                            {
                                if (myReader.Read())
                                {
                                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                                    if (_updateDateTime != acceptodrWork.UpdateDateTime)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                        return status;
                                    }

                                    # region [UPDATE文]
                                    sqlText = "";
                                    sqlText += "DELETE" + Environment.NewLine;
                                    sqlText += "FROM" + Environment.NewLine;
                                    sqlText += "  ACCEPTODRRF" + Environment.NewLine;
                                    sqlText += "WHERE" + Environment.NewLine;
                                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                                    sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                    sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                                    sqlText += "  AND COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                                    sqlText += "  AND SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;
                                    sqlText += "  AND SLIPDTLNUMDERIVNORF = @FINDSLIPDTLNUMDERIVNO" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    # endregion

                                    //KEYコマンドを再設定
                                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                                    findSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                                    findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                                    findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                                    findSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                                    findSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SlipDtlNumDerivNo);

                                    if (!myReader.IsClosed)
                                    {
                                        myReader.Close();
                                    }

                                    sqlCommand.ExecuteNonQuery();
                                }
                                else
                                {
                                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    return status;
                                }
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
                                    myReader = null;
                                }
                            }
                        }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
                finally
                {
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }
            }

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → AcceptOdrWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AcceptOdrWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        /// </remarks>
        private AcceptOdrWork CopyToAcceptOdrWorkFromReader(ref SqlDataReader myReader)
        {
            AcceptOdrWork retWork = new AcceptOdrWork();

            #region クラスへ格納
            retWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            retWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            retWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            retWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            retWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            retWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            retWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            retWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            retWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            retWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            retWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            retWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            retWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
            retWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            retWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPDTLNUMRF"));
            retWork.SlipDtlNumDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDTLNUMDERIVNORF"));
            retWork.SrcLinkDataCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCLINKDATACODERF"));
            retWork.SrcSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SRCSLIPDTLNUMRF"));
            #endregion

            return retWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            AcceptOdrWork[] AcceptOdrWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is AcceptOdrWork)
                    {
                        AcceptOdrWork wkAcceptOdrWork = paraobj as AcceptOdrWork;
                        if (wkAcceptOdrWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkAcceptOdrWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            AcceptOdrWorkArray = (AcceptOdrWork[])XmlByteSerializer.Deserialize(byteArray, typeof(AcceptOdrWork[]));
                        }
                        catch (Exception) { }
                        if (AcceptOdrWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(AcceptOdrWorkArray);
                        }
                        else
                        {
                            try
                            {
                                AcceptOdrWork wkAcceptOdrWork = (AcceptOdrWork)XmlByteSerializer.Deserialize(byteArray, typeof(AcceptOdrWork));
                                if (wkAcceptOdrWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkAcceptOdrWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.09.12</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}

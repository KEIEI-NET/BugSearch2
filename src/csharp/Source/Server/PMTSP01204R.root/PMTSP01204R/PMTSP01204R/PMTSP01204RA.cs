//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSP送信データ作成 リモートオブジェクト
// プログラム概要   : TSP送信データ作成 リモートオブジェクトです
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 陳艶丹
// 作 成 日  2020/11/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// TSP送信データ作成 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       :TSP送信データ作成を行うクラスです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/11/20</br>
    /// </remarks>
    public class TspSdRvDataDB : RemoteDB, ITspSdRvDataDB
    {
        /// <summary>
        /// 採番処理の共通部品DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public TspSdRvDataDB()
            : base()
        {
        }

        #region [採番処理]
        /// <summary>
        /// 共通通番を採番します。
        /// </summary>
        /// <param name="enterprisecode">企業コードを指定します。</param>
        /// <param name="sectioncode">拠点コードを指定します。</param>
        /// <param name="commonSeqNo">採番した共通通番を返します。</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 共通通番を採番します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public int GetTspCommonSeqNo(string enterprisecode, string sectioncode, out Int64 commonSeqNo)
        {
            // 共通通番を採番する
            return GetSerialNumber(enterprisecode, sectioncode, (SerialNumberCode)5000, out commonSeqNo);
        }

        /// <summary>
        /// 通番を採番します。
        /// </summary>
        /// <param name="enterprisecode">企業コードを指定します。</param>
        /// <param name="sectioncode">拠点コードを指定します。</param>
        /// <param name="serialnumcd">通番コードを指定します。</param>
        /// <param name="serialnumber">番号コードに基いて採番された通番を返します。</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 通番を採番します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private int GetSerialNumber(string enterprisecode, string sectioncode, SerialNumberCode serialnumcd, out Int64 serialnumber)
        {
            // 処理の実現部を共通クラス化して PMCMN00005 に移動しました。
            NumberingManager numberingMng = new NumberingManager();
            return numberingMng.GetSerialNumber(enterprisecode, sectioncode, serialnumcd, out serialnumber);
        }
        #endregion

        #region [Search処理]
        /// <summary>
        /// 指定された条件のTSP明細データLISTの件数を戻します。
        /// </summary>
        /// <param name="tspDtlWorkPara">検索条件</param>
        /// <param name="tspDtlWorkList">TSP明細データLIST</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のTSP明細データLISTの件数を戻します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public int Search(TspDtlWork tspDtlWorkPara, out object tspDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            tspDtlWorkList = null;
            ArrayList retList = null;
            SqlConnection sqlConnection = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                try
                {
                    // 検索条件
                    TspDtlWork param = tspDtlWorkPara as TspDtlWork;

                    // 検索
                    status = SearchProc(param, out retList, ref sqlConnection);
                    // 戻り値セット
                    tspDtlWorkList = retList;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "TspSdRvDataDB.Search", status);
                }
            }

            return status;
        }

        /// <summary>
        /// 指定された条件のTSP明細データLISTの件数を戻します。
        /// </summary>
        /// <param name="param">検索条件</param>
        /// <param name="TspDtlWorkList">TSP明細データLIST</param>
        /// <param name="sqlConnection">クエリコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のTSP明細データLISTの件数を戻します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private int SearchProc(TspDtlWork param, out ArrayList TspDtlWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            TspDtlWorkList = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            ArrayList al = new ArrayList();
            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    // 検索クエリの作成
                    StringBuilder sqlText = new StringBuilder();
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine("  CREATEDATETIMERF ");                      // 作成日時
                    sqlText.AppendLine("  ,UPDATEDATETIMERF ");                     // 更新日時
                    sqlText.AppendLine("  ,ENTERPRISECODERF ");                     // 企業コード
                    sqlText.AppendLine("  ,FILEHEADERGUIDRF ");                     // GUID
                    sqlText.AppendLine("  ,UPDEMPLOYEECODERF ");                    // 更新従業員コード
                    sqlText.AppendLine("  ,UPDASSEMBLYID1RF ");                     // 更新アセンブリID1
                    sqlText.AppendLine("  ,UPDASSEMBLYID2RF ");                     // 更新アセンブリID2
                    sqlText.AppendLine("  ,LOGICALDELETECODERF ");                  // 論理削除区分
                    sqlText.AppendLine("  ,SALESSLIPNUMRF ");                       // 売上伝票番号
                    sqlText.AppendLine("  ,ACPTANODRSTATUSRF ");                    // 受注ステータス
                    sqlText.AppendLine("  ,SALESSLIPDTLNUMRF ");                    // 売上明細通番
                    sqlText.AppendLine("  ,TSPONLINENORF ");                        // TSPオンライン番号
                    sqlText.AppendLine("  ,TSPONLINEROWNORF ");                     // TSPオンライン行番号
                    sqlText.AppendLine(" FROM TSPDTLRF WITH (READUNCOMMITTED) ");
                    // 検索条件
                    sqlText.AppendLine(MakeWhereString(param, 0, ref sqlCommand));

                    sqlCommand.CommandText = sqlText.ToString();
                    // 検索タイムアウトの設定(60秒)
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                    using (myReader = sqlCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // 検索結果の格納
                            al.Add(CopyToTspDtlWorkFromReader(ref myReader));
                        }
                    }

                    // 検索結果がある場合
                    if (al.Count > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                catch (SqlException sqlex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(sqlex, "TspSdRvDataDB.SearchProc", status);
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "TspSdRvDataDB.SearchProc Exception=" + ex.Message);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            TspDtlWorkList = al;

            return status;
        }

        /// <summary>
        /// 検索Where文の作成
        /// </summary>
        /// <param name="param">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <param name="sqlCommand">クエリコマンド</param>
        /// <returns>検索Where文</returns>
        /// <remarks>
        /// <br>Note       : 検索Where文の作成</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private string MakeWhereString(TspDtlWork param, ConstantManagement.LogicalMode logicalMode, ref SqlCommand sqlCommand)
        {
            StringBuilder sqlText = new StringBuilder();

            sqlText.AppendLine(" WHERE ");

            // 企業コード
            sqlText.AppendLine(" ENTERPRISECODERF=@FINDENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(param.EnterpriseCode);

            // 論理削除区分
            sqlText.AppendLine(" AND LOGICALDELETECODERF=@LOGICALDELETECODE ");
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            // 受注ステータス
            sqlText.AppendLine(" AND ACPTANODRSTATUSRF=@ACPTANODRSTATUSRF ");
            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUSRF", SqlDbType.Int);
            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(param.AcptAnOdrStatus);

            // 売上伝票番号
            sqlText.AppendLine(" AND SALESSLIPNUMRF=@FINDSALESSLIPNUM ");
            SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
            paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(param.SalesSlipNum);

            return sqlText.ToString();
        }

        /// <summary>
        /// 検索結果の格納
        /// </summary>
        /// <param name="myReader">結果リーダ</param>
        /// <returns>検索結果</returns>
        /// <remarks>
        /// <br>Note       : 検索結果の格納</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private TspDtlWork CopyToTspDtlWorkFromReader(ref SqlDataReader myReader)
        {
            TspDtlWork resultWork = new TspDtlWork();
            resultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));      // 作成日時
            resultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));      // 更新日時
            resultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));                 // 企業コード
            resultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                   // GUID
            resultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));               // 更新従業員コード
            resultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));                 // 更新アセンブリID1
            resultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));                 // 更新アセンブリID2
            resultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));            // 論理削除区分
            resultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));                     // 売上伝票番号
            resultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));                // 受注ステータス
            resultWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));                // 売上明細通番
            resultWork.TspOnlineNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TSPONLINENORF"));                        // TSPオンライン番号
            resultWork.TspOnlineRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TSPONLINEROWNORF"));                  // TSPオンライン行番号

            return resultWork;
        }
        #endregion

        #region [Write処理]
        /// <summary>
        /// TSP明細データを登録、更新します。
        /// </summary>
        /// <param name="tspDtlWorkObj">TSP明細データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP明細データを登録、更新します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public int Write(ref object tspDtlWorkObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            using (sqlConnection = CreateSqlConnection(true))
            {
                using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                {
                    try
                    {
                        // 登録データ
                        ArrayList writeList = tspDtlWorkObj as ArrayList;
                        for (int i = 0; i < writeList.Count;i++ )
                        {
                            TspDtlWork tspDtlWork = (TspDtlWork)writeList[i];
                            if (i == 0)
                            {
                                // 削除処理実行
                                status = this.DeleteProc(tspDtlWork, ref sqlConnection, ref sqlTransaction);
                            }
                            //追加処理実行
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = this.InsertProc(tspDtlWork, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        base.WriteErrorLog(ex, "TspSdRvDataDB.Write", status);
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
                            if (sqlTransaction.Connection != null)
                            {
                                sqlTransaction.Rollback();
                            }
                        }
                        if (sqlTransaction != null) sqlTransaction.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// TSP明細データを登録します。
        /// </summary>
        /// <param name="tspDtlWork">登録データ</param>
        /// <param name="sqlConnection">クエリコネクション</param>
        /// <param name="sqlTransaction">クエリトランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP明細データを登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private int InsertProc(TspDtlWork tspDtlWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlText.AppendLine(" INSERT INTO TSPDTLRF ( ");
                    sqlText.AppendLine(" CREATEDATETIMERF ");                  // 作成日時
                    sqlText.AppendLine(" ,UPDATEDATETIMERF ");                 // 更新日時
                    sqlText.AppendLine(" ,ENTERPRISECODERF ");                 // 企業コード
                    sqlText.AppendLine(" ,FILEHEADERGUIDRF ");                 // GUID
                    sqlText.AppendLine(" ,UPDEMPLOYEECODERF ");                // 更新従業員コード
                    sqlText.AppendLine(" ,UPDASSEMBLYID1RF ");                 // 更新アセンブリID1
                    sqlText.AppendLine(" ,UPDASSEMBLYID2RF ");                 // 更新アセンブリID2
                    sqlText.AppendLine(" ,LOGICALDELETECODERF ");              // 論理削除区分
                    sqlText.AppendLine(" ,SALESSLIPNUMRF ");                   // 売上伝票番号
                    sqlText.AppendLine(" ,ACPTANODRSTATUSRF ");                // 受注ステータス
                    sqlText.AppendLine(" ,SALESSLIPDTLNUMRF ");                // 売上明細通番
                    sqlText.AppendLine(" ,TSPONLINENORF ");                    // TSPオンライン番号
                    sqlText.AppendLine(" ,TSPONLINEROWNORF ");                 // TSPオンライン行番号
                    sqlText.AppendLine(" ) VALUES ( ");
                    sqlText.AppendLine(" @CREATEDATETIME ");                   // 作成日時
                    sqlText.AppendLine(" ,@UPDATEDATETIME ");                  // 更新日時
                    sqlText.AppendLine(" ,@ENTERPRISECODE ");                  // 企業コード
                    sqlText.AppendLine(" ,@FILEHEADERGUID ");                  // GUID
                    sqlText.AppendLine(" ,@UPDEMPLOYEECODE ");                 // 更新従業員コード
                    sqlText.AppendLine(" ,@UPDASSEMBLYID1 ");                  // 更新アセンブリID1
                    sqlText.AppendLine(" ,@UPDASSEMBLYID2 ");                  // 更新アセンブリID2
                    sqlText.AppendLine(" ,@LOGICALDELETECODE ");               // 論理削除区分
                    sqlText.AppendLine(" ,@SALESSLIPNUM ");                    // 売上伝票番号
                    sqlText.AppendLine(" ,@ACPTANODRSTATUS ");                 // 受注ステータス
                    sqlText.AppendLine(" ,@SALESSLIPDTLNUM ");                 // 売上明細通番
                    sqlText.AppendLine(" ,@TSPONLINENO ");                     // TSPオンライン番号
                    sqlText.AppendLine(" ,@TSPONLINEROWNO ");                  // TSPオンライン行番号
                    sqlText.AppendLine(" ) ");

                    sqlCommand.CommandText = sqlText.ToString();

                    // 登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)tspDtlWork;
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
                    SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
                    SqlParameter paraTspOnlineNo = sqlCommand.Parameters.Add("@TSPONLINENO", SqlDbType.Int);
                    SqlParameter paraTspOnlineRowNo = sqlCommand.Parameters.Add("@TSPONLINEROWNO", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tspDtlWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tspDtlWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(tspDtlWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(tspDtlWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(tspDtlWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(tspDtlWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(tspDtlWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(tspDtlWork.LogicalDeleteCode);
                    paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(tspDtlWork.AcptAnOdrStatus);
                    paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(tspDtlWork.SalesSlipNum);
                    paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(tspDtlWork.SalesSlipDtlNum);
                    paraTspOnlineNo.Value = SqlDataMediator.SqlSetInt32(tspDtlWork.TspOnlineNo);
                    paraTspOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(tspDtlWork.TspOnlineRowNo);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                }
                catch (SqlException sqlex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(sqlex, "TspSdRvDataDB.InsertProc", status);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "TspSdRvDataDB.InsertProc Exception==" + ex.Message, status);
                }
            }

            return status;
        }
        #endregion

        #region [Delete処理]
        /// <summary>
        /// TSP明細データを完全削除します。
        /// </summary>
        /// <param name="tspDtlWorkObj">TSP明細データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP明細データを完全削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public int Delete(object tspDtlWorkObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //コネクション生成
                using (sqlConnection = CreateSqlConnection(true))
                {
                    // トランザクション開始
                    using (sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default))
                    {
                        try
                        {
                            TspDtlWork deleteTspDtl = tspDtlWorkObj as TspDtlWork;
                            // 削除処理実行
                            status = this.DeleteProc(deleteTspDtl, ref sqlConnection, ref sqlTransaction);
                            
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                // コミット
                                sqlTransaction.Commit();
                            else
                            {
                                // ロールバック
                                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                            }
                        }
                        catch (Exception ex)
                        {
                            base.WriteErrorLog(ex, "TspSdRvDataDB.Delete");
                            // ロールバック
                            if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TspSdRvDataDB.Delete Exception==" + ex.Message, status);

                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// TSP明細データを完全削除します。
        /// </summary>
        /// <param name="tspDtlWork">削除データ</param>
        /// <param name="sqlConnection">クエリコネクション</param>
        /// <param name="sqlTransaction">クエリトランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP明細データを完全削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private int DeleteProc(TspDtlWork tspDtlWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                    sqlTextDel.AppendLine(" TSPDTLRF");
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
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tspDtlWork.EnterpriseCode);
                    findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(tspDtlWork.SalesSlipNum);
                    findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(tspDtlWork.AcptAnOdrStatus);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException sqlex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(sqlex, "TspSdRvDataDB.DeleteProc", status);
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "TspSdRvDataDB.DeleteProc Exception=" + ex.Message, status);
                }
            }
            return status;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note       : SqlConnection生成処理</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }
            return retSqlConnection;
        }
        #endregion
    }
}

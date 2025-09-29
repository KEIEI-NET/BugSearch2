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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先別売上目標設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先別売上目標設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 横川昌令</br>
    /// <br>Date       : 2007.12.04</br>
    /// <br></br>
    /// <br>Update Note: 2010/12/20 曹文傑</br>
    /// <br>             障害改良対応１２月</br>
    /// </remarks>
    [Serializable]
    public class CustSalesTargetDB : RemoteDB, ICustSalesTargetDB
    {
        /// <summary>
        /// 得意先別売上目標設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        /// </remarks>
        public CustSalesTargetDB()
            :
            base("DCKHN09206D", "Broadleaf.Application.Remoting.ParamData.CustSalesTargetWork", "CUSTSALESTARGETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の得意先別売上目標設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="custSalesTargetWork">検索結果</param>
        /// <param name="paracustSalesTargetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先別売上目標設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        public int Search(out object custSalesTargetWork, object paracustSalesTargetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            custSalesTargetWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchCustSalesTargetProc(out custSalesTargetWork, paracustSalesTargetWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSalesTargetDB.Search");
                custSalesTargetWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の得意先別売上目標設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objcustSalesTargetWork">検索結果</param>
        /// <param name="searchCustSalesTargetParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        public int SearchCustSalesTargetProc(out object objcustSalesTargetWork, object searchCustSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SearchCustSalesTargetParaWork custSalesTargetParaWork = null;

            ArrayList custSalesTargetWorkList = searchCustSalesTargetParaWork as ArrayList;
            if (custSalesTargetWorkList == null)
            {
                custSalesTargetParaWork = searchCustSalesTargetParaWork as SearchCustSalesTargetParaWork;
            }
            else
            {
                if (custSalesTargetWorkList.Count > 0)
                    custSalesTargetParaWork = custSalesTargetWorkList[0] as SearchCustSalesTargetParaWork;
            }

            int status = SearchCustSalesTargetProc(out custSalesTargetWorkList, custSalesTargetParaWork, readMode, logicalMode, ref sqlConnection);
            objcustSalesTargetWork = custSalesTargetWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の得意先別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="custSalesTargetWorkList">検索結果</param>
        /// <param name="searchCustSalesTargetParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        public int SearchCustSalesTargetProc(out ArrayList custSalesTargetWorkList, SearchCustSalesTargetParaWork searchCustSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM CUSTSALESTARGETRF AS A LEFT JOIN CUSTOMERRF AS B ON A.ENTERPRISECODERF=B.ENTERPRISECODERF AND A.CUSTOMERCODERF=B.CUSTOMERCODERF ", sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchCustSalesTargetParaWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToCustSalesTargetWorkFromReader(ref myReader));

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
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            custSalesTargetWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の得意先別売上目標設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">CustSalesTargetWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先別売上目標設定マスタを戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                CustSalesTargetWork custSalesTargetWork = new CustSalesTargetWork();

                // XMLの読み込み
                custSalesTargetWork = (CustSalesTargetWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustSalesTargetWork));
                if (custSalesTargetWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref custSalesTargetWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(custSalesTargetWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSalesTargetDB.Read");
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
        /// 指定された条件の得意先別売上目標設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先別売上目標設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int ReadProc(ref CustSalesTargetWork custSalesTargetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaBusinessTypeCode = sqlCommand.Parameters.Add("@FINDBUSINESSTYPECODE", SqlDbType.Int);
                    SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                    findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                    findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        custSalesTargetWork = CopyToCustSalesTargetWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 得意先別売上目標設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        public int Write(ref object custSalesTargetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(custSalesTargetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteCustSalesTargetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                custSalesTargetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSalesTargetDB.Write(ref object custSalesTargetWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }


        /// <summary>
        /// 得意先別売上目標設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="custSalesTargetWorkList">CustSalesTargetWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int WriteCustSalesTargetProc(ref ArrayList custSalesTargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (custSalesTargetWorkList != null)
                {
                    for (int i = 0; i < custSalesTargetWorkList.Count; i++)
                    {
                        CustSalesTargetWork custSalesTargetWork = custSalesTargetWorkList[i] as CustSalesTargetWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaBusinessTypeCode = sqlCommand.Parameters.Add("@FINDBUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                        findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != custSalesTargetWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (custSalesTargetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE CUSTSALESTARGETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , TARGETSETCDRF=@TARGETSETCD , TARGETCONTRASTCDRF=@TARGETCONTRASTCD , TARGETDIVIDECODERF=@TARGETDIVIDECODE , TARGETDIVIDENAMERF=@TARGETDIVIDENAME , BUSINESSTYPECODERF=@BUSINESSTYPECODE , SALESAREACODERF=@SALESAREACODE , CUSTOMERCODERF=@CUSTOMERCODE , APPLYSTADATERF=@APPLYSTADATE , APPLYENDDATERF=@APPLYENDDATE , SALESTARGETMONEYRF=@SALESTARGETMONEY , SALESTARGETPROFITRF=@SALESTARGETPROFIT , SALESTARGETCOUNTRF=@SALESTARGETCOUNT WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                            findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                            findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSalesTargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (custSalesTargetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO CUSTSALESTARGETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, TARGETSETCDRF, TARGETCONTRASTCDRF, TARGETDIVIDECODERF, TARGETDIVIDENAMERF, BUSINESSTYPECODERF, SALESAREACODERF, CUSTOMERCODERF, APPLYSTADATERF, APPLYENDDATERF, SALESTARGETMONEYRF, SALESTARGETPROFITRF, SALESTARGETCOUNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @TARGETSETCD, @TARGETCONTRASTCD, @TARGETDIVIDECODE, @TARGETDIVIDENAME, @BUSINESSTYPECODE, @SALESAREACODE, @CUSTOMERCODE, @APPLYSTADATE, @APPLYENDDATE, @SALESTARGETMONEY, @SALESTARGETPROFIT, @SALESTARGETCOUNT)";
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSalesTargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

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
                        SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                        SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
                        SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);

                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSalesTargetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSalesTargetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custSalesTargetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                        paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                        paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                        paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                        paraTargetDivideName.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideName);
                        paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);
                        paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custSalesTargetWork.ApplyStaDate);
                        paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(custSalesTargetWork.ApplyEndDate);
                        paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(custSalesTargetWork.SalesTargetMoney);
                        paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(custSalesTargetWork.SalesTargetProfit);
                        paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(custSalesTargetWork.SalesTargetCount);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(custSalesTargetWork);
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
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            custSalesTargetWorkList = al;

            return status;
        }
        #endregion

        // ---ADD 2010/12/20--------->>>>>
        #region [WriteProc]
        /// <summary>
        /// 得意先別売上目標設定マスタ情報を更新します
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWorkオブジェクト(write用)</param>
        /// <param name="parabyte">CustSalesTargetWorkオブジェクト(delete用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を更新します</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/20</br>
        public int WriteProc(ref object custSalesTargetWork, byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraWriteList = CastToArrayListFromPara(custSalesTargetWork);
                if (paraWriteList == null) return status;

                ArrayList　paraDeleteList = CastToArrayListFromPara(parabyte);
                if (paraDeleteList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //delete実行
                status = DeleteCustSalesTargetProc(paraDeleteList, ref sqlConnection, ref sqlTransaction);

                //write実行
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteCustSalesTargetProc(ref paraWriteList, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    //なし。
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                custSalesTargetWork = paraWriteList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSalesTargetDB.Write(ref object custSalesTargetWork)");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion
        // ---ADD 2010/12/20---------<<<<<

        #region [LogicalDelete]
        /// <summary>
        /// 得意先別売上目標設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        public int LogicalDelete(ref object custSalesTargetWork)
        {
            return LogicalDeleteCustSalesTarget(ref custSalesTargetWork, 0);
        }

        /// <summary>
        /// 論理削除得意先別売上目標設定マスタ情報を復活します
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除得意先別売上目標設定マスタ情報を復活します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        public int RevivalLogicalDelete(ref object custSalesTargetWork)
        {
            return LogicalDeleteCustSalesTarget(ref custSalesTargetWork, 1);
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="custSalesTargetWork">CustSalesTargetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        private int LogicalDeleteCustSalesTarget(ref object custSalesTargetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(custSalesTargetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteCustSalesTargetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "CustSalesTargetDB.LogicalDeleteCustSalesTarget :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="custSalesTargetWorkList">CustSalesTargetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int LogicalDeleteCustSalesTargetProc(ref ArrayList custSalesTargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (custSalesTargetWorkList != null)
                {
                    for (int i = 0; i < custSalesTargetWorkList.Count; i++)
                    {
                        CustSalesTargetWork custSalesTargetWork = custSalesTargetWorkList[i] as CustSalesTargetWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaBusinessTypeCode = sqlCommand.Parameters.Add("@FINDBUSINESSTYPECODE", SqlDbType.Int);
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                        findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != custSalesTargetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE CUSTSALESTARGETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                            findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                            findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSalesTargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//既に削除済みの場合正常
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) custSalesTargetWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else custSalesTargetWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) custSalesTargetWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSalesTargetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(custSalesTargetWork);
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
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            custSalesTargetWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 得意先別売上目標設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">得意先別売上目標設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteCustSalesTargetProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "CustSalesTargetDB.Delete");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }


        /// <summary>
        /// 得意先別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="custSalesTargetWorkList">得意先別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: </br>
        public int DeleteCustSalesTargetProc(ArrayList custSalesTargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < custSalesTargetWorkList.Count; i++)
                {
                    CustSalesTargetWork custSalesTargetWork = custSalesTargetWorkList[i] as CustSalesTargetWork;

                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaBusinessTypeCode = sqlCommand.Parameters.Add("@FINDBUSINESSTYPECODE", SqlDbType.Int);
                    SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                    findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                    findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != custSalesTargetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE AND SALESAREACODERF=@FINDSALESAREACODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE";

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);
                        findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
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
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="searchCustSalesTargetParaWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br>Update Note: 2010/12/20  曹文傑</br>
        /// <br>           : 自社締日を変更後に、呼び出しを行うと取得出来ないレコードがある現象の修正</br>
        /// <br></br>
        /// <br>Update Note: </br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchCustSalesTargetParaWork searchCustSalesTargetParaWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "A.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchCustSalesTargetParaWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND A.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND A.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (searchCustSalesTargetParaWork.AllSecSelEpUnit == false && searchCustSalesTargetParaWork.AllSecSelSecUnit == false)
            {
                if (searchCustSalesTargetParaWork.SelectSectCd != null)
                {
                    wkstring = "";
                    foreach (string seccdstr in searchCustSalesTargetParaWork.SelectSectCd)
                    {
                        if (wkstring != "") wkstring += ",";
                        wkstring += "'" + seccdstr + "'";
                    }
                    if (wkstring != "")
                    {
                        retstring += "AND A.SECTIONCODERF IN (" + wkstring + ") ";
                    }
                }
            }

            //目標設定区分
            if (searchCustSalesTargetParaWork.TargetSetCd > 0)
            {
                retstring += "AND A.TARGETSETCDRF=@TARGETSETCD ";
                SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(searchCustSalesTargetParaWork.TargetSetCd);
            }

            //目標対比区分
            if (searchCustSalesTargetParaWork.TargetContrastCd > 0)
            {
                retstring += "AND A.TARGETCONTRASTCDRF=@TARGETCONTRASTCD ";
                SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(searchCustSalesTargetParaWork.TargetContrastCd);
            }
            // ---UPD 2010/12/20--------->>>>>
            ////目標区分コード
            //if (searchCustSalesTargetParaWork.TargetDivideCode != "")
            //{
            //    retstring += "AND A.TARGETDIVIDECODERF=@TARGETDIVIDECODE ";
            //    SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
            //    paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(searchCustSalesTargetParaWork.TargetDivideCode);
            //}

            //目標区分コード
            if (searchCustSalesTargetParaWork.TargetDivideCode != "")
            {
                retstring += "AND A.TARGETDIVIDECODERF>=@TARGETDIVIDECODE1 ";
                retstring += "AND A.TARGETDIVIDECODERF<=@TARGETDIVIDECODE2 ";
                SqlParameter paraTargetDivideCode1 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE1", SqlDbType.NChar);
                SqlParameter paraTargetDivideCode2 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE2", SqlDbType.NChar);
                paraTargetDivideCode1.Value = SqlDataMediator.SqlSetString(searchCustSalesTargetParaWork.TargetDivideCode);
                int endYearMonth = Convert.ToInt32(searchCustSalesTargetParaWork.TargetDivideCode) + 99;
                if (endYearMonth % 100 == 0)
                {
                    endYearMonth = Convert.ToInt32(searchCustSalesTargetParaWork.TargetDivideCode) + 11;
                }
                paraTargetDivideCode2.Value = SqlDataMediator.SqlSetString(endYearMonth.ToString());
            }
            // ---UPD 2010/12/20---------<<<<<
            //目標区分名称
            if (searchCustSalesTargetParaWork.TargetDivideName != "")
            {
                retstring += "AND A.TARGETDIVIDENAMERF LIKE @TARGETDIVIDENAME ";
                SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
                paraTargetDivideName.Value = SqlDataMediator.SqlSetString("%" + searchCustSalesTargetParaWork.TargetDivideName + "%");
            }

            //業種コード
            if (searchCustSalesTargetParaWork.BusinessTypeCode > 0)
            {
                retstring += "AND A.BUSINESSTYPECODERF=@BUSINESSTYPECODE ";
                SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(searchCustSalesTargetParaWork.BusinessTypeCode);
            }

            //販売エリアコード
            if (searchCustSalesTargetParaWork.SalesAreaCode > 0)
            {
                retstring += "AND A.SALESAREACODERF=@SALESAREACODE ";
                SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(searchCustSalesTargetParaWork.SalesAreaCode);
            }

            //得意先コード
            if (searchCustSalesTargetParaWork.CustomerCode > 0)
            {
                retstring += "AND A.CUSTOMERCODERF=@CUSTOMERCODE ";
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(searchCustSalesTargetParaWork.CustomerCode);
            }
            // ---DEL 2010/12/20--------->>>>>
            ////適用開始日（開始）
            //if (searchCustSalesTargetParaWork.StartApplyStaDate > DateTime.MinValue)
            //{
            //    retstring += "AND A.APPLYSTADATERF>=@APPLYSTADATE ";
            //    SqlParameter paraStartApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            //    paraStartApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchCustSalesTargetParaWork.StartApplyStaDate);
            //}

            ////適用開始日（終了）
            //if (searchCustSalesTargetParaWork.EndApplyStaDate > DateTime.MinValue)
            //{
            //    retstring += "AND A.APPLYSTADATERF<=@APPLYSTADATE ";
            //    SqlParameter paraEndApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            //    paraEndApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchCustSalesTargetParaWork.EndApplyStaDate);
            //}

            ////適用終了日（開始）
            //if (searchCustSalesTargetParaWork.StartApplyEndDate > DateTime.MinValue)
            //{
            //    retstring += "AND A.APPLYENDDATERF>=@APPLYENDDATE ";
            //    SqlParameter paraStartApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            //    paraStartApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchCustSalesTargetParaWork.StartApplyEndDate);
            //}

            ////適用終了日（終了）
            //if (searchCustSalesTargetParaWork.EndApplyEndDate > DateTime.MinValue)
            //{
            //    retstring += "AND A.APPLYENDDATERF<=@APPLYENDDATE ";
            //    SqlParameter paraEndApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            //    paraEndApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchCustSalesTargetParaWork.EndApplyEndDate);
            //}
            // ---DEL 2010/12/20---------<<<<<
            //ソート順位
            retstring += "ORDER BY A.SECTIONCODERF,A.APPLYSTADATERF,A.APPLYENDDATERF,A.BUSINESSTYPECODERF,A.SALESAREACODERF,A.CUSTOMERCODERF ";

            return retstring;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CustSalesTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustSalesTargetWork</returns>
        /// <remarks>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// </remarks>
        private CustSalesTargetWork CopyToCustSalesTargetWorkFromReader(ref SqlDataReader myReader)
        {
            CustSalesTargetWork wkCustSalesTargetWork = new CustSalesTargetWork();

            #region クラスへ格納
            wkCustSalesTargetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustSalesTargetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustSalesTargetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustSalesTargetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustSalesTargetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustSalesTargetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustSalesTargetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustSalesTargetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustSalesTargetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkCustSalesTargetWork.TargetSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETSETCDRF"));
            wkCustSalesTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
            wkCustSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
            wkCustSalesTargetWork.TargetDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDENAMERF"));
            wkCustSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
            wkCustSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            wkCustSalesTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustSalesTargetWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            wkCustSalesTargetWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            wkCustSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
            wkCustSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
            wkCustSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));
            #endregion

            return wkCustSalesTargetWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CustSalesTargetWork[] CustSalesTargetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is CustSalesTargetWork)
                    {
                        CustSalesTargetWork wkCustSalesTargetWork = paraobj as CustSalesTargetWork;
                        if (wkCustSalesTargetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCustSalesTargetWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CustSalesTargetWorkArray = (CustSalesTargetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CustSalesTargetWork[]));
                        }
                        catch (Exception) { }
                        if (CustSalesTargetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CustSalesTargetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CustSalesTargetWork wkCustSalesTargetWork = (CustSalesTargetWork)XmlByteSerializer.Deserialize(byteArray, typeof(CustSalesTargetWork));
                                if (wkCustSalesTargetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCustSalesTargetWork);
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
        /// <br>Programmer : 横川昌令</br>
        /// <br>Date       : 2007.12.04</br>
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

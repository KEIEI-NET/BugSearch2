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
    /// 従業員別売上目標設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 従業員別売上目標設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.04.13</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
    /// <br>           : 流通基幹対応</br>
    /// <br></br>
    /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
    /// <br>           : 従業員区分追加</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.06  横川</br>
    /// <br>           : 従業員コード null対策</br>
    /// <br>Update Note: 2008.06.17  長内</br>
    /// <br>           : PM.NS用に修正</br>
    /// <br>Update Note: 2010/12/20 曹文傑</br>
    /// <br>             障害改良対応１２月</br>
    /// </remarks>
    [Serializable]
    public class EmpSalesTargetDB : RemoteDB, IEmpSalesTargetDB
    {
        /// <summary>
        /// 従業員別売上目標設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        public EmpSalesTargetDB()
            :
            base("MAMOK09116D", "Broadleaf.Application.Remoting.ParamData.EmpSalesTargetWork", "EMPSALESTARGETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の従業員別売上目標設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="empsalestargetWork">検索結果</param>
        /// <param name="paraempsalestargetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員別売上目標設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        public int Search(out object empsalestargetWork, object paraempsalestargetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            empsalestargetWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchEmpSalesTargetProc(out empsalestargetWork, paraempsalestargetWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Search");
                empsalestargetWork = new ArrayList();
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
        /// 指定された条件の従業員別売上目標設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objempsalestargetWork">検索結果</param>
        /// <param name="searchEmpSalesTargetParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        public int SearchEmpSalesTargetProc(out object objempsalestargetWork, object searchEmpSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SearchEmpSalesTargetParaWork empSalesTargetParaWork = null;

            ArrayList empsalestargetWorkList = searchEmpSalesTargetParaWork as ArrayList;
            if (empsalestargetWorkList == null)
            {
                empSalesTargetParaWork = searchEmpSalesTargetParaWork as SearchEmpSalesTargetParaWork;
            }
            else
            {
                if (empsalestargetWorkList.Count > 0)
                    empSalesTargetParaWork = empsalestargetWorkList[0] as SearchEmpSalesTargetParaWork;
            }

            int status = SearchEmpSalesTargetProc(out empsalestargetWorkList, empSalesTargetParaWork, readMode, logicalMode, ref sqlConnection);
            objempsalestargetWork = empsalestargetWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の従業員別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="empsalestargetWorkList">検索結果</param>
        /// <param name="searchEmpSalesTargetParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        public int SearchEmpSalesTargetProc(out ArrayList empsalestargetWorkList, SearchEmpSalesTargetParaWork searchEmpSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchEmpSalesTargetProcProc(out empsalestargetWorkList, searchEmpSalesTargetParaWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の従業員別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="empsalestargetWorkList">検索結果</param>
        /// <param name="searchEmpSalesTargetParaWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員別売上目標設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        private int SearchEmpSalesTargetProcProc( out ArrayList empsalestargetWorkList, SearchEmpSalesTargetParaWork searchEmpSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            string selectTxt = string.Empty;

            try
            {
                selectTxt += "SELECT ESG.* , SEC.SECTIONGUIDENMRF, EMP.NAMERF AS EMPLOYEENAMERF, SUB.SUBSECTIONNAMERF FROM EMPSALESTARGETRF AS ESG" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPLOYEERF AS EMP" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=EMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.EMPLOYEECODERF=EMP.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SUBSECTIONRF AS SUB" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=SUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchEmpSalesTargetParaWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToEmpSalesTargetWorkFromReader(ref myReader));

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

            empsalestargetWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の従業員別売上目標設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">EmpSalesTargetWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員別売上目標設定マスタを戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                EmpSalesTargetWork empsalestargetWork = new EmpSalesTargetWork();

                // XMLの読み込み
                empsalestargetWork = (EmpSalesTargetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmpSalesTargetWork));
                if (empsalestargetWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref empsalestargetWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(empsalestargetWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Read");
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
        /// 指定された条件の従業員別売上目標設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員別売上目標設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
        /// <br>           : 従業員区分追加</br>
        public int ReadProc(ref EmpSalesTargetWork empsalestargetWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref empsalestargetWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件の従業員別売上目標設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の従業員別売上目標設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
        /// <br>           : 従業員区分追加</br>
        private int ReadProcProc( ref EmpSalesTargetWork empsalestargetWork, int readMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string selectTxt = string.Empty;

            try
            {
                selectTxt += "SELECT ESG.* , SEC.SECTIONGUIDENMRF, EMP.NAMERF AS EMPLOYEENAMERF, SUB.SUBSECTIONNAMERF FROM EMPSALESTARGETRF AS ESG" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPLOYEERF AS EMP" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=EMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.EMPLOYEECODERF=EMP.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SUBSECTIONRF AS SUB" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=SUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                selectTxt += " AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD" + Environment.NewLine;
                selectTxt += " AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                    SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                    findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                    findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                    findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        empsalestargetWork = CopyToEmpSalesTargetWorkFromReader(ref myReader);
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
        /// 従業員別売上目標設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        public int Write(ref object empsalestargetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(empsalestargetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteEmpSalesTargetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                empsalestargetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Write(ref object empsalestargetWork)");
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
        /// 従業員別売上目標設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="empsalestargetWorkList">EmpSalesTargetWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
        /// <br>           : 従業員区分追加</br>
        public int WriteEmpSalesTargetProc(ref ArrayList empsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteEmpSalesTargetProcProc(ref empsalestargetWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="empsalestargetWorkList">EmpSalesTargetWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
        /// <br>           : 従業員区分追加</br>
        private int WriteEmpSalesTargetProcProc( ref ArrayList empsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;
            try
            {
                if (empsalestargetWorkList != null)
                {
                    for (int i = 0; i < empsalestargetWorkList.Count; i++)
                    {
                        EmpSalesTargetWork empsalestargetWork = empsalestargetWorkList[i] as EmpSalesTargetWork;

                        selectTxt = string.Empty;
                        selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM EMPSALESTARGETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                        selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                        selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                        selectTxt += " AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD" + Environment.NewLine;
                        selectTxt += " AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                        selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                        findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                        findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != empsalestargetWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (empsalestargetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            selectTxt = string.Empty;
                            selectTxt += "UPDATE EMPSALESTARGETRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += " , TARGETSETCDRF=@TARGETSETCD" + Environment.NewLine;
                            selectTxt += " , TARGETCONTRASTCDRF=@TARGETCONTRASTCD" + Environment.NewLine;
                            selectTxt += " , TARGETDIVIDECODERF=@TARGETDIVIDECODE" + Environment.NewLine;
                            selectTxt += " , TARGETDIVIDENAMERF=@TARGETDIVIDENAME" + Environment.NewLine;
                            selectTxt += " , EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD" + Environment.NewLine;
                            selectTxt += " , SUBSECTIONCODERF=@SUBSECTIONCODE" + Environment.NewLine;
                            selectTxt += " , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , APPLYSTADATERF=@APPLYSTADATE" + Environment.NewLine;
                            selectTxt += " , APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine;
                            selectTxt += " , SALESTARGETMONEYRF=@SALESTARGETMONEY" + Environment.NewLine;
                            selectTxt += " , SALESTARGETPROFITRF=@SALESTARGETPROFIT" + Environment.NewLine;
                            selectTxt += " , SALESTARGETCOUNTRF=@SALESTARGETCOUNT" + Environment.NewLine;
                            selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                            selectTxt += "  AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                            selectTxt += "  AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                            selectTxt += "  AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD" + Environment.NewLine;
                            selectTxt += "  AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                            findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                            findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                            findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)empsalestargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (empsalestargetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            selectTxt = string.Empty;
                            selectTxt += "INSERT INTO EMPSALESTARGETRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,TARGETSETCDRF" + Environment.NewLine;
                            selectTxt += "  ,TARGETCONTRASTCDRF" + Environment.NewLine;
                            selectTxt += "  ,TARGETDIVIDECODERF" + Environment.NewLine;
                            selectTxt += "  ,TARGETDIVIDENAMERF" + Environment.NewLine;
                            selectTxt += "  ,EMPLOYEEDIVCDRF" + Environment.NewLine;
                            selectTxt += "  ,SUBSECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,EMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,APPLYSTADATERF" + Environment.NewLine;
                            selectTxt += "  ,APPLYENDDATERF" + Environment.NewLine;
                            selectTxt += "  ,SALESTARGETMONEYRF" + Environment.NewLine;
                            selectTxt += "  ,SALESTARGETPROFITRF" + Environment.NewLine;
                            selectTxt += "  ,SALESTARGETCOUNTRF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@TARGETSETCD" + Environment.NewLine;
                            selectTxt += "  ,@TARGETCONTRASTCD" + Environment.NewLine;
                            selectTxt += "  ,@TARGETDIVIDECODE" + Environment.NewLine;
                            selectTxt += "  ,@TARGETDIVIDENAME" + Environment.NewLine;
                            selectTxt += "  ,@EMPLOYEEDIVCD" + Environment.NewLine;
                            selectTxt += "  ,@SUBSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@EMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@APPLYSTADATE" + Environment.NewLine;
                            selectTxt += "  ,@APPLYENDDATE" + Environment.NewLine;
                            selectTxt += "  ,@SALESTARGETMONEY" + Environment.NewLine;
                            selectTxt += "  ,@SALESTARGETPROFIT" + Environment.NewLine;
                            selectTxt += "  ,@SALESTARGETCOUNT" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = selectTxt;
                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)empsalestargetWork;
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
                        SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);

                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empsalestargetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empsalestargetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(empsalestargetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                        paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                        paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                        paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                        paraTargetDivideName.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideName);
                        paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                        paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                        paraEmployeeCode.Value = empsalestargetWork.EmployeeCode;
                        paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(empsalestargetWork.ApplyStaDate);
                        paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(empsalestargetWork.ApplyEndDate);
                        paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(empsalestargetWork.SalesTargetMoney);
                        paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(empsalestargetWork.SalesTargetProfit);
                        paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(empsalestargetWork.SalesTargetCount);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(empsalestargetWork);
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

            empsalestargetWorkList = al;

            return status;
        }
        #endregion

        // ---ADD 2010/12/20--------->>>>>
        #region [WriteProc]
        /// <summary>
        /// 従業員別売上目標設定マスタ情報を更新します
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWorkオブジェクト(write用)</param>
        /// <param name="parabyte">EmpSalesTargetWorkオブジェクト(delete用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報を更新します</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/20</br>
        public int WriteProc(ref object empsalestargetWork, byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraWriteList = CastToArrayListFromPara(empsalestargetWork);
                if (paraWriteList == null) return status;

                ArrayList paraDeleteList = CastToArrayListFromPara(parabyte);
                if (paraDeleteList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //delete実行
                status = DeleteEmpSalesTargetProcProc(paraDeleteList, ref sqlConnection, ref sqlTransaction);

                //write実行
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteEmpSalesTargetProcProc(ref paraWriteList, ref sqlConnection, ref sqlTransaction);
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
                empsalestargetWork = paraWriteList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Write(ref object empsalestargetWork)");
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
        /// 従業員別売上目標設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        public int LogicalDelete(ref object empsalestargetWork)
        {
            return LogicalDeleteEmpSalesTarget(ref empsalestargetWork, 0);
        }

        /// <summary>
        /// 論理削除従業員別売上目標設定マスタ情報を復活します
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除従業員別売上目標設定マスタ情報を復活します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        public int RevivalLogicalDelete(ref object empsalestargetWork)
        {
            return LogicalDeleteEmpSalesTarget(ref empsalestargetWork, 1);
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        private int LogicalDeleteEmpSalesTarget(ref object empsalestargetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(empsalestargetWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteEmpSalesTargetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "EmpSalesTargetDB.LogicalDeleteEmpSalesTarget :" + procModestr);

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
        /// 従業員別売上目標設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="empsalestargetWorkList">EmpSalesTargetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
        /// <br>           : 従業員区分追加</br>
        public int LogicalDeleteEmpSalesTargetProc(ref ArrayList empsalestargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteEmpSalesTargetProcProc(ref empsalestargetWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="empsalestargetWorkList">EmpSalesTargetWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
        /// <br>           : 従業員区分追加</br>
        private int LogicalDeleteEmpSalesTargetProcProc( ref ArrayList empsalestargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;
            try
            {
                if (empsalestargetWorkList != null)
                {
                    for (int i = 0; i < empsalestargetWorkList.Count; i++)
                    {
                        EmpSalesTargetWork empsalestargetWork = empsalestargetWorkList[i] as EmpSalesTargetWork;

                        //Selectコマンドの生成
                        selectTxt = string.Empty;
                        selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM EMPSALESTARGETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                        selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                        selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                        selectTxt += " AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD" + Environment.NewLine;
                        selectTxt += " AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                        selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                        findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                        findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != empsalestargetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE EMPSALESTARGETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                            findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                            findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                            findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)empsalestargetWork;
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
                            else if (logicalDelCd == 0) empsalestargetWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else empsalestargetWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) empsalestargetWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empsalestargetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(empsalestargetWork);
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

            empsalestargetWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 従業員別売上目標設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">従業員別売上目標設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
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

                status = DeleteEmpSalesTargetProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Delete");
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
        /// 従業員別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="empsalestargetWorkList">従業員別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
        /// <br>           : 従業員区分追加</br>
        public int DeleteEmpSalesTargetProc(ArrayList empsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteEmpSalesTargetProcProc(empsalestargetWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="empsalestargetWorkList">従業員別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
        /// <br>           : 従業員区分追加</br>
        private int DeleteEmpSalesTargetProcProc( ArrayList empsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string selectTxt = string.Empty;
            try
            {

                for (int i = 0; i < empsalestargetWorkList.Count; i++)
                {
                    EmpSalesTargetWork empsalestargetWork = empsalestargetWorkList[i] as EmpSalesTargetWork;

                    selectTxt = string.Empty;
                    selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM EMPSALESTARGETRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                    selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                    selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                    selectTxt += " AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD" + Environment.NewLine;
                    selectTxt += " AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                    selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                    SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                    findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                    findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                    findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != empsalestargetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM EMPSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                        findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                        findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;
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
        /// <param name="searchEmpSalesTargetParaWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
        /// <br>           : 従業員区分追加</br>
        /// <br>Update Note: 2010/12/20  曹文傑</br>
        /// <br>           : 自社締日を変更後に、呼び出しを行うと取得出来ないレコードがある現象の修正</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchEmpSalesTargetParaWork searchEmpSalesTargetParaWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "ESG.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchEmpSalesTargetParaWork.EnterpriseCode);

		    //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND ESG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND ESG.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            //拠点コード
            if (searchEmpSalesTargetParaWork.AllSecSelEpUnit == false && searchEmpSalesTargetParaWork.AllSecSelSecUnit == false)
            {
                if (searchEmpSalesTargetParaWork.SelectSectCd != null)
                {
                    wkstring = "";
                    foreach (string seccdstr in searchEmpSalesTargetParaWork.SelectSectCd)
                    {
                        if (wkstring != "") wkstring += ",";
                        wkstring += "'" + seccdstr + "'";
                    }
                    if (wkstring != "")
                    {
                        retstring += "AND ESG.SECTIONCODERF IN (" + wkstring + ") ";
                    }
                }
            }

            //目標設定区分
            if (searchEmpSalesTargetParaWork.TargetSetCd > 0)
            {
                retstring += "AND ESG.TARGETSETCDRF=@TARGETSETCD ";
                SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(searchEmpSalesTargetParaWork.TargetSetCd);
            }

            //目標対比区分
            if (searchEmpSalesTargetParaWork.TargetContrastCd > 0)
            {
                retstring += "AND ESG.TARGETCONTRASTCDRF=@TARGETCONTRASTCD ";
                SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(searchEmpSalesTargetParaWork.TargetContrastCd);
            }
            // ---UPD 2010/12/20--------->>>>>
            ////目標区分コード
            //if (searchEmpSalesTargetParaWork.TargetDivideCode != "")
            //{
            //    retstring += "AND ESG.TARGETDIVIDECODERF=@TARGETDIVIDECODE ";
            //    SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
            //    paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(searchEmpSalesTargetParaWork.TargetDivideCode);
            //}

            //目標区分コード
            if (searchEmpSalesTargetParaWork.TargetDivideCode != "")
            {
                retstring += "AND ESG.TARGETDIVIDECODERF>=@TARGETDIVIDECODE1 ";
                retstring += "AND ESG.TARGETDIVIDECODERF<=@TARGETDIVIDECODE2 ";
                SqlParameter paraTargetDivideCode1 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE1", SqlDbType.NChar);
                SqlParameter paraTargetDivideCode2 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE2", SqlDbType.NChar);
                paraTargetDivideCode1.Value = SqlDataMediator.SqlSetString(searchEmpSalesTargetParaWork.TargetDivideCode);
                int endYearMonth = Convert.ToInt32(searchEmpSalesTargetParaWork.TargetDivideCode) + 99;
                if (endYearMonth % 100 == 0)
                {
                    endYearMonth = Convert.ToInt32(searchEmpSalesTargetParaWork.TargetDivideCode) + 11;
                }
                paraTargetDivideCode2.Value = SqlDataMediator.SqlSetString(endYearMonth.ToString());
            }
            // ---UPD 2010/12/20---------<<<<<
            //目標区分名称
            if (searchEmpSalesTargetParaWork.TargetDivideName != "")
            {
                retstring += "AND ESG.TARGETDIVIDENAMERF LIKE @TARGETDIVIDENAME ";
                SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
                paraTargetDivideName.Value = SqlDataMediator.SqlSetString("%" + searchEmpSalesTargetParaWork.TargetDivideName + "%");
            }

            //従業員区分
            if (searchEmpSalesTargetParaWork.EmployeeDivCd > 0)
            {
                retstring += "AND ESG.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ";
                SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(searchEmpSalesTargetParaWork.EmployeeDivCd);
            }

            //部門コード
            if (searchEmpSalesTargetParaWork.SubSectionCode > 0)
            {
                retstring += "AND ESG.SUBSECTIONCODERF=@SUBSECTIONCODE ";
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(searchEmpSalesTargetParaWork.SubSectionCode);
            }

            //従業員コード
            if (searchEmpSalesTargetParaWork.EmployeeCode != "")
            {
                retstring += "AND ESG.EMPLOYEECODERF=@EMPLOYEECODE ";
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                paraEmployeeCode.Value = searchEmpSalesTargetParaWork.EmployeeCode;
            }
            // ---DEL 2010/12/20--------->>>>>
            ////適用開始日（開始）
            //if (searchEmpSalesTargetParaWork.StartApplyStaDate > DateTime.MinValue)
            //{
            //    retstring += "AND ESG.APPLYSTADATERF>=@APPLYSTADATE ";
            //    SqlParameter paraStartApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            //    paraStartApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchEmpSalesTargetParaWork.StartApplyStaDate);
            //}

            ////適用開始日（終了）
            //if (searchEmpSalesTargetParaWork.EndApplyStaDate > DateTime.MinValue)
            //{
            //    retstring += "AND ESG.APPLYSTADATERF<=@APPLYSTADATE ";
            //    SqlParameter paraEndApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            //    paraEndApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchEmpSalesTargetParaWork.EndApplyStaDate);
            //}

            ////適用終了日（開始）
            //if (searchEmpSalesTargetParaWork.StartApplyEndDate > DateTime.MinValue)
            //{
            //    retstring += "AND ESG.APPLYENDDATERF>=@APPLYENDDATE ";
            //    SqlParameter paraStartApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            //    paraStartApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchEmpSalesTargetParaWork.StartApplyEndDate);
            //}

            ////適用終了日（終了）
            //if (searchEmpSalesTargetParaWork.EndApplyEndDate > DateTime.MinValue)
            //{
            //    retstring += "AND ESG.APPLYENDDATERF<=@APPLYENDDATE ";
            //    SqlParameter paraEndApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            //    paraEndApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchEmpSalesTargetParaWork.EndApplyEndDate);
            //}
            // ---DEL 2010/12/20---------<<<<<
            //ソート順位
            retstring += "ORDER BY ESG.SECTIONCODERF,ESG.APPLYSTADATERF,ESG.APPLYENDDATERF,ESG.EMPLOYEEDIVCDRF,ESG.SUBSECTIONCODERF,ESG.EMPLOYEECODERF ";

		    return retstring;
		}
	    #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → EmpSalesTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EmpSalesTargetWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 山田 明友</br>
        /// <br>           : 流通基幹対応</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 山田 明友</br>
        /// <br>           : 従業員区分追加</br>
        /// </remarks>
        private EmpSalesTargetWork CopyToEmpSalesTargetWorkFromReader(ref SqlDataReader myReader)
        {
            EmpSalesTargetWork wkEmpSalesTargetWork = new EmpSalesTargetWork();

            #region クラスへ格納
            wkEmpSalesTargetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkEmpSalesTargetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkEmpSalesTargetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkEmpSalesTargetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkEmpSalesTargetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkEmpSalesTargetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkEmpSalesTargetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkEmpSalesTargetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkEmpSalesTargetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkEmpSalesTargetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkEmpSalesTargetWork.TargetSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETSETCDRF"));
            wkEmpSalesTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
            wkEmpSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
            wkEmpSalesTargetWork.TargetDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDENAMERF"));
            wkEmpSalesTargetWork.EmployeeDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYEEDIVCDRF"));
            wkEmpSalesTargetWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            wkEmpSalesTargetWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            wkEmpSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            wkEmpSalesTargetWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEENAMERF"));
            wkEmpSalesTargetWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            wkEmpSalesTargetWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            wkEmpSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
            wkEmpSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
            wkEmpSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));
            #endregion

            return wkEmpSalesTargetWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            EmpSalesTargetWork[] EmpSalesTargetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is EmpSalesTargetWork)
                    {
                        EmpSalesTargetWork wkEmpSalesTargetWork = paraobj as EmpSalesTargetWork;
                        if (wkEmpSalesTargetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkEmpSalesTargetWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            EmpSalesTargetWorkArray = (EmpSalesTargetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(EmpSalesTargetWork[]));
                        }
                        catch (Exception) { }
                        if (EmpSalesTargetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(EmpSalesTargetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                EmpSalesTargetWork wkEmpSalesTargetWork = (EmpSalesTargetWork)XmlByteSerializer.Deserialize(byteArray, typeof(EmpSalesTargetWork));
                                if (wkEmpSalesTargetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkEmpSalesTargetWork);
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
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.04.13</br>
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

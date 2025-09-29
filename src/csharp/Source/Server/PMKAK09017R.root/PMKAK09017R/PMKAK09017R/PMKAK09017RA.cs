//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先総括マスタ一覧表DBリモートオブジェクト
// プログラム概要   : 仕入先総括マスタ一覧表実データ操作を行うクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI菅原　要
// 作 成 日  2012/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Data.SqlTypes;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先総括マスタ一覧表 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先総括マスタ一覧表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : FSI菅原　要</br>
    /// <br>Date       : 2012/09/07</br>
    /// </remarks>
    [Serializable]
    public class SumSuppStPrintResultDB : RemoteDB, ISumSuppStPrintResultDB
    {
       #region [クラスコンストラクタ]
       /// <summary>
       /// 仕入先総括マスタ一覧表コンストラクタ
       /// </summary>
       /// <remarks>
       /// <br>Note       : なし</br>
       /// <br>Programmer : FSI菅原　要</br>
       /// <br>Date       : 2012/09/07</br>
       /// </remarks>
       public SumSuppStPrintResultDB()
            : base("PMKAK09019D", "Broadleaf.Application.Remoting.ParamData.SumSuppStPrintResultWork", "SumSuppStPrintResult")
       {

       }
       #endregion

       #region [Search]

       /// <summary>
       /// 指定された条件の仕入先総括マスタ一覧表情報LISTを戻します
       /// </summary>
       /// <param name="sumSuppStPrintResultWork">検索結果</param>
       /// <param name="sumSuppStPrintParaWork">検索パラメータ</param>
       /// <returns>STATUS</returns>
       /// <remarks>
       /// <br>Note       : 指定された条件の仕入先総括マスタ一覧表情報LISTを戻します</br>
       /// <br>Programmer : FSI菅原　要</br>
       /// <br>Date       : 2012/09/07</br>
       /// </remarks>
       public int Search(out object sumSuppStPrintResultWork, object sumSuppStPrintParaWork)
       {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            sumSuppStPrintResultWork = new ArrayList();
            try
            {
                //コレクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // 検索を行う
                status = SearchProc(out sumSuppStPrintResultWork, sumSuppStPrintParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "SumSuppStResultDB.Search");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SumSuppStResultDB.Search");
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
            return status;
        }

        #endregion

       #region [SearchProc -- Searchメイン処理]
       /// <summary>
       /// 指定された条件の仕入先総括マスタ一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)
       /// </summary>
       /// <param name="retList">検索結果検索パラメータ</param>
       /// <param name="paraObj">検索パラメータ</param>
       /// <param name="sqlConnection">sqlConnection</param>
       /// <returns>STATUS</returns>
       /// <remarks>
       /// <br>Note       : 指定された条件の仕入先総括マスタ一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)</br>
       /// <br>Programmer : FSI菅原　要</br>
       /// <br>Date       : 2012/09/07</br>
       /// </remarks>
       private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
       {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            SumSuppStPrintParaWork paraWork = null;
            paraWork = paraObj as SumSuppStPrintParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            // SQL
            StringBuilder sqlString = new StringBuilder(string.Empty);
            
            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlCommand.CommandTimeout = 600;

                # region SQL文
                sqlString.AppendLine("SELECT DISTINCT");
                sqlString.AppendLine("	 SUMSECTIONCDRF");
                sqlString.AppendLine("	,SUMSUPPLIERCDRF");
                sqlString.AppendLine("	,SECTIONCODERF");
                sqlString.AppendLine("	,SUPPLIERCDRF");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("	SUMSUPPSTRF WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("		ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("	AND LOGICALDELETECODERF = 0");

                // 以降の条件は、パラメータとして指定された場合のみ条件に追加する
                if(paraWork.SectionCodeSt != string.Empty)
                {
                    sqlString.AppendLine("	AND SUMSECTIONCDRF >= @FINDSUMSECTIONCDST");
                }
                if (paraWork.SectionCodeEd != string.Empty)
                {
                    sqlString.AppendLine("	AND SUMSECTIONCDRF <= @FINDSUMSECTIONCDED");
                }
                if (paraWork.SupplierCodeSt != 0)
                {
                    sqlString.AppendLine("	AND SUMSUPPLIERCDRF >= @FINDSUMSUPPLIERCDST");
                }
                if (paraWork.SupplierCodeEd != 0)
                {
                    sqlString.AppendLine("	AND SUMSUPPLIERCDRF <= @FINDSUMSUPPLIERCDED");
                }
                sqlString.AppendLine("ORDER BY");
                sqlString.AppendLine("	SUMSECTIONCDRF,SUMSUPPLIERCDRF,SECTIONCODERF,SUPPLIERCDRF ASC");
                sqlCommand.CommandText = sqlString.ToString();
                # endregion SQL文

                # region Parameterオブジェクト作成・値格納
                SqlParameter findEnterpriseCode  = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

                if (paraWork.SectionCodeSt != string.Empty)
                {
                    SqlParameter findSumSectionCdSt = sqlCommand.Parameters.Add("@FINDSUMSECTIONCDST", SqlDbType.NChar);
                    findSumSectionCdSt.Value = SqlDataMediator.SqlSetString(paraWork.SectionCodeSt);
                }
                if (paraWork.SectionCodeEd != string.Empty)
                {
                    SqlParameter findSumSectionCdEd = sqlCommand.Parameters.Add("@FINDSUMSECTIONCDED", SqlDbType.NChar);
                    findSumSectionCdEd.Value = SqlDataMediator.SqlSetString(paraWork.SectionCodeEd);
                }
                if (paraWork.SupplierCodeSt != 0)
                {
                    SqlParameter findSumSupplierCdSt = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCDST", SqlDbType.Int);
                    findSumSupplierCdSt.Value = SqlDataMediator.SqlSetInt(paraWork.SupplierCodeSt);
                }
                if (paraWork.SupplierCodeEd != 0)
                {
                    SqlParameter findSumSupplierCdEd = sqlCommand.Parameters.Add("@FINDSUMSUPPLIERCDED", SqlDbType.Int);
                    findSumSupplierCdEd.Value = SqlDataMediator.SqlSetInt(paraWork.SupplierCodeEd);
                }

                # endregion Parameterオブジェクト作成・値格納

                // クエリ発行
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // 検索結果格納
                    al.Add(CopyToSumSuppStResultWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "SumSuppStResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SumSuppStResultDB.SearchProc" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }
            retList = al;
            return status;
       }

       #endregion

       #region [クラス格納処理]
       /// <summary>
       /// クラス格納処理 Reader → SumSuppStPrintResultWork
       /// </summary>
       /// <param name="myReader">SqlDataReader</param>
       /// <returns>Result</returns>
       /// <remarks>
       /// <br>Note       : ReaderからSumSuppStPrintResultWorkへ変換します。</br>
       /// <br>Programmer : FSI菅原　要</br>
       /// <br>Date       : 2012/09/07</br>
       /// </remarks>
       private SumSuppStPrintResultWork CopyToSumSuppStResultWorkFromReader(ref SqlDataReader myReader)
       {
           SumSuppStPrintResultWork listWork = new SumSuppStPrintResultWork();

           // 総括拠点コード
           listWork.SumSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMSECTIONCDRF"));

           // 総括仕入先コード
           listWork.SumSupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMSUPPLIERCDRF"));

           // 拠点コード
           listWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

           // 仕入先コード
           listWork.SupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));

           return listWork;

       }
       #endregion  クラス格納処理

       #region [コネクション生成処理]
       /// <summary>
       /// SqlConnection生成処理
       /// </summary>
       /// <returns>SqlConnection</returns>
       /// <remarks>
       /// <br>Programmer : FSI菅原　要</br>
       /// <br>Date       : 2012/09/07</br>
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

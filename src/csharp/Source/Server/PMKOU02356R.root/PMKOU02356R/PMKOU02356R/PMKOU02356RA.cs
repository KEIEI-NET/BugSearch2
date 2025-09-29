//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 入荷差異表DBリモートオブジェクト
// プログラム概要   : 入荷差異表実データ操作を行うクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570136-00  作成担当 : 譚洪
// 作 成 日  K2019/08/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
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
    /// 入荷差異表 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 入荷差異表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : K2019/08/14</br>
    /// </remarks>
    [Serializable]
    public class ArrGoodsDiffResultDB : RemoteDB, IArrGoodsDiffResultDB
    {
       #region [クラスコンストラクタ]
       /// <summary>
       /// 入荷差異表コンストラクタ
       /// </summary>
       /// <remarks>
       /// <br>Note       : なし</br>
       /// <br>Programmer : 譚洪</br>
       /// <br>Date       : K2019/08/14</br>
       /// </remarks>
       public ArrGoodsDiffResultDB()
           : base("PMKOU02358D", "Broadleaf.Application.Remoting.ParamData.ArrGoodsDiffResultWork", "ArrGoodsDiffResult")
       {

       }
       #endregion

       #region [Search]

       /// <summary>
       /// 指定された条件の入荷差異表情報LISTを戻します
       /// </summary>
       /// <param name="arrGoodsDiffResultWork">検索結果</param>
       /// <param name="arrGoodsDiffCndtnWork">検索パラメータ</param>
       /// <returns>STATUS</returns>
       /// <remarks>
       /// <br>Note       : 指定された条件の入荷差異表情報LISTを戻します</br>
       /// <br>Programmer : 譚洪</br>
       /// <br>Date       : K2019/08/14</br>
       /// </remarks>
        public int Search(out object arrGoodsDiffResultWork, object arrGoodsDiffCndtnWork)
       {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            arrGoodsDiffResultWork = new ArrayList();
            try
            {
                //コレクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // 検索を行う
                status = SearchProc(out arrGoodsDiffResultWork, arrGoodsDiffCndtnWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "ArrGoodsDiffResultDB.Search");
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ArrGoodsDiffResultDB.Search");
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
       /// 指定された条件の入荷差異表情報LISTを全て戻します(外部からのSqlConnectionを使用)
       /// </summary>
       /// <param name="retList">検索結果検索パラメータ</param>
       /// <param name="paraObj">検索パラメータ</param>
       /// <param name="sqlConnection">sqlConnection</param>
       /// <returns>STATUS</returns>
       /// <remarks>
       /// <br>Note       : 指定された条件の入荷差異表情報LISTを全て戻します(外部からのSqlConnectionを使用)</br>
       /// <br>Programmer : 譚洪</br>
       /// <br>Date       : K2019/08/14</br>
       /// </remarks>
       private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
       {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrGoodsDiffCndtnWork paraWork = null;
            paraWork = paraObj as ArrGoodsDiffCndtnWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();
            ArrGoodsDiffResultWork resultWork = new ArrGoodsDiffResultWork();

            // SQL
            StringBuilder sqlString = new StringBuilder(string.Empty);
            
            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlCommand.CommandTimeout = 600;

                # region SQL文
                sqlString.AppendLine("SELECT");
                sqlString.AppendLine("	 UOE.UOESUPPLIERCDRF");
                sqlString.AppendLine("	,UOS.UOESUPPLIERNAMERF");
                sqlString.AppendLine("	,STD.SUPPLIERSLIPNORF");
                sqlString.AppendLine("	,STD.GOODSNORF");
                sqlString.AppendLine("	,STD.GOODSNAMERF");
                sqlString.AppendLine("	,STD.GOODSMAKERCDRF");
                sqlString.AppendLine("	,MAK.MAKERNAMERF");
                sqlString.AppendLine("	,UOE.ACCEPTANORDERCNTRF");
                sqlString.AppendLine("	,UOE.ACCEPTANORDERCNTRF-STDUOE.ORDERCNTRF AS ORDERREMAINCNTRF");
                sqlString.AppendLine("	,INP.INSPECTCNTRF");
                sqlString.AppendLine("	,STD.WAREHOUSECODERF");
                sqlString.AppendLine("	,WAR.WAREHOUSENAMERF");
                sqlString.AppendLine("	,STS.STOCKAGENTCODERF"); 
                sqlString.AppendLine("	,EMP.NAMERF");
                sqlString.AppendLine("FROM");
                sqlString.AppendLine("	STOCKDETAILRF AS STD WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	INNER JOIN STOCKSLIPRF AS STS WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON STS.ENTERPRISECODERF=STD.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND STS.SUPPLIERFORMALRF=STD.SUPPLIERFORMALRF ");
                sqlString.AppendLine("	AND STS.SUPPLIERSLIPNORF=STD.SUPPLIERSLIPNORF ");
                sqlString.AppendLine("	AND STS.LOGICALDELETECODERF=STD.LOGICALDELETECODERF ");

                //仕入明細データ(発注)
                sqlString.AppendLine("	INNER JOIN STOCKDETAILRF AS STDUOE WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON STD.ENTERPRISECODERF = STDUOE.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND STD.SUPPLIERFORMALSRCRF = STDUOE.SUPPLIERFORMALRF ");
                sqlString.AppendLine("	AND STD.STOCKSLIPDTLNUMSRCRF = STDUOE.STOCKSLIPDTLNUMRF ");
                sqlString.AppendLine("	AND STD.LOGICALDELETECODERF = STDUOE.LOGICALDELETECODERF ");
                 
                //UOE発注データ
                sqlString.AppendLine("	INNER JOIN UOEORDERDTLRF AS UOE WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON STDUOE.ENTERPRISECODERF=UOE.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND STDUOE.COMMONSEQNORF=UOE.COMMONSEQNORF ");
                sqlString.AppendLine("	AND STDUOE.LOGICALDELETECODERF = UOE.LOGICALDELETECODERF ");
                sqlString.AppendLine("	AND UOE.UOEKINDRF =0 ");

                //検品データ
                sqlString.AppendLine("	INNER JOIN INSPECTDATARF AS INP WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON STD.ENTERPRISECODERF = INP.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND STD.SUPPLIERSLIPNORF = INP.ACPAYSLIPNUMRF ");
                sqlString.AppendLine("	AND STD.STOCKROWNORF = INP.ACPAYSLIPROWNORF ");
                sqlString.AppendLine("	AND STD.LOGICALDELETECODERF = INP.LOGICALDELETECODERF ");
                sqlString.AppendLine("	AND INP.ACPAYSLIPCDRF =10 ");

                //メーカーマスタ
                sqlString.AppendLine("	LEFT JOIN MAKERURF AS MAK WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON MAK.ENTERPRISECODERF = STD.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND MAK.GOODSMAKERCDRF = STD.GOODSMAKERCDRF ");
                sqlString.AppendLine("	AND MAK.LOGICALDELETECODERF = STD.LOGICALDELETECODERF ");

                //倉庫マスタ
                sqlString.AppendLine("	LEFT JOIN WAREHOUSERF AS WAR WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON WAR.ENTERPRISECODERF = STD.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND WAR.WAREHOUSECODERF = STD.WAREHOUSECODERF ");
                sqlString.AppendLine("	AND WAR.LOGICALDELETECODERF = STD.LOGICALDELETECODERF ");

                //従業員マスタ
                sqlString.AppendLine("	LEFT JOIN EMPLOYEERF AS EMP WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON EMP.ENTERPRISECODERF = STS.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND EMP.EMPLOYEECODERF = STS.STOCKAGENTCODERF ");
                sqlString.AppendLine("	AND EMP.LOGICALDELETECODERF = STS.LOGICALDELETECODERF ");


                //UOE発注先マスタ
                sqlString.AppendLine("	LEFT JOIN UOESUPPLIERRF AS UOS WITH (READUNCOMMITTED) ");
                sqlString.AppendLine("	ON UOS.ENTERPRISECODERF = UOE.ENTERPRISECODERF ");
                sqlString.AppendLine("	AND UOS.UOESUPPLIERCDRF = UOE.UOESUPPLIERCDRF ");
                sqlString.AppendLine("	AND UOS.LOGICALDELETECODERF = UOE.LOGICALDELETECODERF ");
                sqlString.AppendLine("	AND UOS.SECTIONCODERF = @FINDSECTIONCODE ");

                sqlString.AppendLine("WHERE");
                sqlString.AppendLine("	STS.ENTERPRISECODERF = @FINDENTERPRISECODE");
                sqlString.AppendLine("	AND STS.LOGICALDELETECODERF = 0");
                sqlString.AppendLine("	AND STS.SUPPLIERFORMALRF = 0");

                //検品日
                sqlString.AppendLine("	AND INP.INSPECTDATETIMERF >= @FINDINSPECTDATETIMEST");
                sqlString.AppendLine("	AND INP.INSPECTDATETIMERF < @FINDINSPECTDATETIMEED");

                // 発注先コード指定した場合
                if(paraWork.UOESupplierCd != 0)
                {
                    sqlString.AppendLine("	AND UOE.UOESUPPLIERCDRF = @FINDUOESUPPLIERCD");
                }
                
                sqlString.AppendLine("ORDER BY");
                sqlString.AppendLine("	UOE.UOESUPPLIERCDRF,STD.SUPPLIERSLIPNORF,STD.GOODSNORF ASC");
                sqlCommand.CommandText = sqlString.ToString();
                # endregion SQL文

                # region Parameterオブジェクト作成・値格納

                //拠点コード
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(paraWork.LoginSectionCode);

                //企業コード
                SqlParameter findEnterpriseCode  = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

                //検品日
                SqlParameter findInspectDateTimeSt = sqlCommand.Parameters.Add("@FINDINSPECTDATETIMEST", SqlDbType.BigInt);
                findInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paraWork.InspectDate);

                SqlParameter findInspectDateTimeEd = sqlCommand.Parameters.Add("@FINDINSPECTDATETIMEED", SqlDbType.BigInt);
                findInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paraWork.InspectDate.AddDays(1));

                //発注先
                if (paraWork.UOESupplierCd != 0)
                {
                    SqlParameter findSupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                    findSupplierCd.Value = SqlDataMediator.SqlSetInt(paraWork.UOESupplierCd);
                }
                # endregion Parameterオブジェクト作成・値格納

                // クエリ発行
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // 検索結果格納
                    resultWork = CopyToArrGoodsDiffResultWorkFromReader(ref myReader);
                    if (resultWork.DiffCnt == 0) continue;
                    al.Add(resultWork);
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
                status = base.WriteSQLErrorLog(sqlex, "ArrGoodsDiffResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ArrGoodsDiffResultDB.SearchProc" + status);
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
       /// クラス格納処理 Reader → ArrGoodsDiffResultWork
       /// </summary>
       /// <param name="myReader">SqlDataReader</param>
       /// <returns>Result</returns>
       /// <remarks>
       /// <br>Note       : ReaderからArrGoodsDiffResultWorkへ変換します。</br>
       /// <br>Programmer : 譚洪</br>
       /// <br>Date       : K2019/08/14</br>
       /// </remarks>
        private ArrGoodsDiffResultWork CopyToArrGoodsDiffResultWorkFromReader(ref SqlDataReader myReader)
       {
           ArrGoodsDiffResultWork listWork = new ArrGoodsDiffResultWork();

           // 発注先コード
           listWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));

           // 発注先名
           listWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));

           // 伝票番号
           listWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));

           // 品番
           listWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));

           // 品名
           listWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));

           // メーカーコード
           listWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));

           // メーカー名
           listWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));

           // 発注数
           listWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));

           // 発注残
           listWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));

           // 検品数
           listWork.InspectCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INSPECTCNTRF"));

           // 差異数
           listWork.DiffCnt = listWork.OrderCnt - listWork.OrderRemainCnt - listWork.InspectCnt;

           // 倉庫コード
           listWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));

           // 倉庫名
           listWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));

           // 発注者コード
           listWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));

           // 発注者名
           listWork.EmployeeName= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));

           return listWork;

       }
       #endregion  クラス格納処理

       #region [コネクション生成処理]
       /// <summary>
       /// SqlConnection生成処理
       /// </summary>
       /// <returns>SqlConnection</returns>
       /// <remarks>
       /// <br>Programmer : 譚洪</br>
       /// <br>Date       : K2019/08/14</br>
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

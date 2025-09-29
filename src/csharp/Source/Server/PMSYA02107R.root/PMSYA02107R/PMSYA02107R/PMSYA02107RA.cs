//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 当月車検車両一覧表DBリモートオブジェクト
// プログラム概要   : 当月車検車両一覧表実データ操作を行うクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 薛祺
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
    /// 当月車検車両一覧表 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 当月車検車両一覧表の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 薛祺</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    [Serializable]
    public class MonthCarInspectListResultDB : RemoteDB, IMonthCarInspectListResultDB
    {
       #region クラスコンストラクタ
        /// <summary>
        /// 当月車検車両一覧表コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public MonthCarInspectListResultDB()
            : base("PMSYA02109D", "Broadleaf.Application.Remoting.ParamData.MonthCarInspectListResultWork", "MONTHCARINSPECTLISTRESULT")
        {

        }
        #endregion

       #region [Search]
        #region 指定された条件の当月車検車両一覧表一覧表情報LISTの取得処理
        /// <summary>
        /// 指定された条件の当月車検車両一覧表一覧表情報LISTを戻します
        /// </summary>
        /// <param name="monthCarInspectListResultWork">検索結果</param>
        /// <param name="monthCarInspectListParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の当月車検車両一覧表情報LISTを戻します</br>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public int Search(out object monthCarInspectListResultWork, object monthCarInspectListParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            monthCarInspectListResultWork = new ArrayList();
            try
            {
                //コレクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // 検索を行う
                status = SearchProc(out monthCarInspectListResultWork, monthCarInspectListParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "MonthCarInspectListResultDB.Search");
                monthCarInspectListResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MonthCarInspectListResultDB.Search");
                monthCarInspectListResultWork = new ArrayList();
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

        #region 指定された条件の当月車検車両一覧表一覧表情報LIST(外部からのSqlConnectionを使用)
        /// <summary>
        /// 指定された条件の当月車検車両一覧表一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="retList">検索結果検索パラメータ</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の当月車検車両一覧表一覧表情報LISTを全て戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            MonthCarInspectListParaWork paraWork = null;
            paraWork = paraObj as MonthCarInspectListParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            try
            {
                sqlCommand = new SqlCommand(String.Empty, sqlConnection);

                selectTxt.Append("SELECT ");
                selectTxt.Append("  A.CUSTOMERSNMRF, ");        // 得意先略称
                selectTxt.Append("  A.MNGSECTIONCODERF, ");     // 管理拠点コード
                selectTxt.Append("  B.ENTERPRISECODERF, ");     // 企業コード
                selectTxt.Append("  B.LOGICALDELETECODERF, ");  // 論理削除区分
                selectTxt.Append("  B.CUSTOMERCODERF, ");       // 得意先コード
                selectTxt.Append("  B.CARMNGNORF, ");           // 車両管理番号
                selectTxt.Append("  B.CARMNGCODERF, ");         // 車輌管理コード
                selectTxt.Append("  B.NUMBERPLATE1NAMERF, ");   // 陸運事務局名称
                selectTxt.Append("  B.NUMBERPLATE2RF, ");       // 車両登録番号（種別）
                selectTxt.Append("  B.NUMBERPLATE3RF, ");       // 車両登録番号（カナ）
                selectTxt.Append("  B.NUMBERPLATE4RF, ");       // 車両登録番号（プレート番号）
                selectTxt.Append("  B.FIRSTENTRYDATERF, ");     // 初年度
                selectTxt.Append("  B.MAKERCODERF, ");          // メーカーコード
                selectTxt.Append("  B.MODELCODERF, ");          // 車種コード
                selectTxt.Append("  B.MODELSUBCODERF, ");       // 車種サブコード
                selectTxt.Append("  B.MODELHALFNAMERF, ");      // 車種半角名称
                selectTxt.Append("  B.FULLMODELRF, ");          // 型式（フル型）
                selectTxt.Append("  B.FRAMENORF, ");            // 車台番号
                selectTxt.Append("  B.INSPECTMATURITYDATERF, ");// 車検満期日
                selectTxt.Append("  B.CARINSPECTYEARRF ");      // 車検期間
                selectTxt.Append("FROM ");
                selectTxt.Append("  CUSTOMERRF A, ");           // 得意先マスタ
                selectTxt.Append("  CARMANAGEMENTRF B ");       // 車輌管理マスタ
                selectTxt.Append("WHERE ");
                selectTxt.Append("  A.CUSTOMERCODERF = B.CUSTOMERCODERF ");
                selectTxt.Append("  AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                // 論理削除区分
                selectTxt.Append("  AND B.LOGICALDELETECODERF = 0 ");
                // 企業コード
                selectTxt.Append("  AND B.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);
                
                // 車検満期日
                if (paraWork.InspectMaturityDate != DateTime.MinValue)
                {
                    selectTxt.Append("  AND LEFT(B.INSPECTMATURITYDATERF, 6) = @FINDINSPECTMATURITYDATE ");
                    SqlParameter paraInspectMaturityDate = sqlCommand.Parameters.Add("@FINDINSPECTMATURITYDATE", SqlDbType.Int);
                    paraInspectMaturityDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(paraWork.InspectMaturityDate);
                }

                // 得意先(開始)が入力された場合
                if (!String.IsNullOrEmpty(paraWork.StCustomerCode))
                {
                    selectTxt.Append("  AND B.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ");
                    SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                    paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.StCustomerCode));
                }
                // 得意先(終了)が入力された場合
                if (!String.IsNullOrEmpty(paraWork.EdCustomerCode))
                {
                    selectTxt.Append("  AND B.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE ");
                    SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                    paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.EdCustomerCode));
                }

                // 拠点コード
                if (paraWork.MngSectionCode != null)
                {
                    string sectionString = "";
                    foreach (string sectionCode in paraWork.MngSectionCode)
                    {
                        if (!string.Empty.Equals(sectionCode))
                        {
                            if (!string.Empty.Equals(sectionString))
                            {
                                sectionString += ",";
                            }
                            sectionString += "'" + sectionCode + "'";
                        }
                    }
                    if (!string.Empty.Equals(sectionString))
                    {
                        // 拠点コード
                        selectTxt.Append(" AND A.MNGSECTIONCODERF IN (" + sectionString + ")  ");

                    }
                }

                // 車輌管理コード
                if (!string.IsNullOrEmpty(paraWork.StCarMngCode))
                {
                    selectTxt.Append(" AND B.CARMNGCODERF>=@FINDSTCARMNGCODE ");
                    SqlParameter paraStCarMngCode = sqlCommand.Parameters.Add("@FINDSTCARMNGCODE", SqlDbType.NChar);
                    paraStCarMngCode.Value = SqlDataMediator.SqlSetString(paraWork.StCarMngCode);
                }
                if (!string.IsNullOrEmpty(paraWork.EdCarMngCode))
                {
                    selectTxt.Append(" AND B.CARMNGCODERF<=@FINDEDCARMNGCODE ");
                    SqlParameter paraEdCarMngCode = sqlCommand.Parameters.Add("@FINDEDCARMNGCODE", SqlDbType.NChar);
                    paraEdCarMngCode.Value = SqlDataMediator.SqlSetString(paraWork.EdCarMngCode);
                }

                // 得意先
                selectTxt.Append("ORDER BY B.CUSTOMERCODERF, ");
                // 管理番号
                selectTxt.Append("B.CARMNGNORF, B.CARMNGCODERF ");// Chg 2010.05.18 zhangsf FOR Redmine #7784

                sqlCommand.CommandText= selectTxt.ToString();
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyResultWorkFromReader(ref myReader, paraWork));
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
                status = base.WriteSQLErrorLog(sqlex, "MonthCarInspectListResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "MonthCarInspectListResultDB.SearchProc" + status);
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


        #endregion

        #region クラス格納処理 Reader → MonthCarInspectListResultWork
        /// <summary>
        /// クラス格納処理 Reader → MonthCarInspectListResultWork
        /// </summary>
        /// <param name="paraWork">検索条件格納クラス</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// <br>Note       : ReaderからMonthCarInspectListResultWorkへ変換します。</br>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private MonthCarInspectListResultWork CopyResultWorkFromReader(ref SqlDataReader myReader, MonthCarInspectListParaWork paraWork)
        {
            MonthCarInspectListResultWork listWork = new MonthCarInspectListResultWork();
            #region クラスへ格納
            // 得意先略称
            listWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            // 管理拠点コード
            listWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
            // 企業コード
            listWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            // 論理削除区分
            listWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            // 得意先コード
            listWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // 車両管理番号
            listWork.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
            // 車輌管理コード   
            listWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
            // 陸運事務局名称
            listWork.NumberPlate1Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE1NAMERF"));
            // 車両登録番号（種別）
            listWork.NumberPlate2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE2RF"));
            // 車両登録番号（カナ）
            listWork.NumberPlate3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NUMBERPLATE3RF"));
            // 車両登録番号（プレート番号）
            listWork.NumberPlate4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NUMBERPLATE4RF"));
            // 初年度
            listWork.FirstEntryDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FIRSTENTRYDATERF")).ToString();
            // メーカーコード
            listWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
            // 車種コード
            listWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
            // 車種サブコード
            listWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
            // 車種半角名称
            listWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
            // 型式（フル型）
            listWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
            // 車台番号
            listWork.FrameNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRAMENORF"));
            // 車検満期日
            listWork.InspectMaturityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INSPECTMATURITYDATERF"));
            // 車検期間
            listWork.CarInspectYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINSPECTYEARRF"));
            return listWork;
            #endregion
        }
        #endregion  クラス格納処理 Reader → MonthCarInspectListResultWork

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
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

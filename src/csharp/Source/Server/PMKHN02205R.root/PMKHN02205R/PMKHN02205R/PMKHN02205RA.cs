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
    /// メニュー制御設定印刷DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : メニュー制御設定印刷の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30747 三戸　伸悟</br>
    /// <br>Date       : 2013/02/07</br>
    /// </remarks>
    [Serializable]
    public class MenueStDB : RemoteDB, IMenueStDB
    {
        /// <summary>
        /// メニュー制御設定印刷DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        public MenueStDB()
            :
            base("PMKHN02207D", "Broadleaf.Application.Remoting.ParamData.MenueStWork", "MENUEST")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件のメニュー制御設定印刷情報LISTを戻します
        /// </summary>
        /// <param name="menueStWork">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sortCode">印刷順</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメニュー制御設定印刷情報LISTを戻します</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int Search(out object menueStWork, String enterpriseCode, Int32 sortCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            menueStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchMenueStProc(out menueStWork, enterpriseCode, sortCode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MenueStDB.Search");
                menueStWork = new ArrayList();
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
        /// 指定された条件のメニュー制御設定印刷情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objmenueStWork">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sortCode">印刷順</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメニュー制御設定印刷情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int SearchMenueStProc(out object objmenueStWork, string enterpriseCode, Int32 sortCode, ref SqlConnection sqlConnection)
        {
            ArrayList menueStWorkList = null;

            int status = SearchMenueStProc(out menueStWorkList, enterpriseCode, sortCode, ref sqlConnection);
            objmenueStWork = menueStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のメニュー制御設定印刷情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="menueStWorkList">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sortCode">印刷順</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメニュー制御設定印刷情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        public int SearchMenueStProc(out ArrayList menueStWorkList, string enterpriseCode, Int32 sortCode, ref SqlConnection sqlConnection)
        {
            return this.SearchMenueStProcProc(out menueStWorkList, enterpriseCode, sortCode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のメニュー制御設定印刷情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="menueStWorkList">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sortCode">印刷順</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のメニュー制御設定印刷情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        private int SearchMenueStProcProc(out ArrayList menueStWorkList, string enterpriseCode, Int32 sortCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "    RGNS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  , RGNS.ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += "  , RGNS.ROLEGROUPNAMERF" + Environment.NewLine;
                selectTxt += "  , ISNULL(RGAS.ROLECATEGORYIDRF,0) ROLECATEGORYIDRF" + Environment.NewLine;
                selectTxt += "  , ISNULL(RGAS.ROLECATEGORYSUBIDRF,0) ROLECATEGORYSUBIDRF" + Environment.NewLine;
                selectTxt += "  , ISNULL(RGAS.ROLEITEMIDRF,0) ROLEITEMIDRF" + Environment.NewLine;
                selectTxt += "  , '' SYSTEMNAMERF" + Environment.NewLine;
                selectTxt += "  , ERS.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  , E.NAMERF EMPLOYEENAMERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  ROLEGRPNAMESTRF RGNS " + Environment.NewLine;
                selectTxt += "  LEFT JOIN ROLEGRPAUTHRTSTRF RGAS " + Environment.NewLine;
                selectTxt += "    ON RGNS.ENTERPRISECODERF = RGAS.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "    AND RGNS.ROLEGROUPCODERF = RGAS.ROLEGROUPCODERF " + Environment.NewLine;
                selectTxt += "    AND RGAS.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += "  LEFT JOIN EMPLOYEEROLESTRF ERS " + Environment.NewLine;
                selectTxt += "    ON RGNS.ENTERPRISECODERF = ERS.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "    AND RGNS.ROLEGROUPCODERF = ERS.ROLEGROUPCODERF " + Environment.NewLine;
                selectTxt += "    AND ERS.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += "  LEFT JOIN EMPLOYEERF E " + Environment.NewLine;
                selectTxt += "    ON ERS.ENTERPRISECODERF = E.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "    AND ERS.EMPLOYEECODERF = E.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    AND E.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += "WHERE RGNS.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += "  AND RGNS.ENTERPRISECODERF = '" + enterpriseCode + "'" + Environment.NewLine;
                selectTxt += "ORDER BY" + Environment.NewLine;
                switch (sortCode)
                {
                    case 0:
                        {
                            selectTxt += "    ROLEGROUPCODERF" + Environment.NewLine;       // ロールグループ
                            selectTxt += "  , ROLECATEGORYIDRF" + Environment.NewLine;      // カテゴリ
                            selectTxt += "  , ROLECATEGORYSUBIDRF" + Environment.NewLine;   // サブカテゴリ
                            selectTxt += "  , ROLEITEMIDRF" + Environment.NewLine;          // アイテム
                            selectTxt += "  , EMPLOYEECODERF" + Environment.NewLine;        // 従業員
                            break;
                        }
                    case 1:
                        {
                            selectTxt += "    ROLECATEGORYIDRF" + Environment.NewLine;      // カテゴリ
                            selectTxt += "  , ROLECATEGORYSUBIDRF" + Environment.NewLine;   // サブカテゴリ
                            selectTxt += "  , ROLEITEMIDRF" + Environment.NewLine;          // アイテム
                            selectTxt += "  , ROLEGROUPCODERF" + Environment.NewLine;       // ロールグループ
                            selectTxt += "  , EMPLOYEECODERF" + Environment.NewLine;        // 従業員
                            break;
                        }
                    default:
                        {
                            selectTxt += "    EMPLOYEECODERF" + Environment.NewLine;        // 従業員
                            selectTxt += "  , ROLECATEGORYIDRF" + Environment.NewLine;      // カテゴリ
                            selectTxt += "  , ROLECATEGORYSUBIDRF" + Environment.NewLine;   // サブカテゴリ
                            selectTxt += "  , ROLEITEMIDRF" + Environment.NewLine;          // アイテム
                            selectTxt += "  , ROLEGROUPCODERF" + Environment.NewLine;       // ロールグループ
                            break;
                        }
                }


                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToMenueStWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            menueStWorkList = al;

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → MenueStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>MenueStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        private MenueStWork CopyToMenueStWorkFromReader(ref SqlDataReader myReader)
        {
            MenueStWork wkMenueStWork = new MenueStWork();

            #region クラスへ格納
            wkMenueStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));         // 企業コード
            wkMenueStWork.RoleGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEGROUPCODERF"));            // ロールグループコード
            wkMenueStWork.RoleGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ROLEGROUPNAMERF"));           // ロールグループ名称
            wkMenueStWork.RoleCategoryId = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLECATEGORYIDRF"));          // カテゴリ
            wkMenueStWork.RoleCategorySubId = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLECATEGORYSUBIDRF"));    // サブカテゴリ
            wkMenueStWork.RoleItemId = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEITEMIDRF"));                  // アイテム
            wkMenueStWork.SystemName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SYSTEMNAMERF"));                 // システム機能名称
            wkMenueStWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));             // 従業員コード
            wkMenueStWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEENAMERF"));             // 従業員名称
            #endregion

            return wkMenueStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            MenueStWork[] MenueStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is MenueStWork)
                    {
                        MenueStWork wkMenueStWork = paraobj as MenueStWork;
                        if (wkMenueStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkMenueStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            MenueStWorkArray = (MenueStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(MenueStWork[]));
                        }
                        catch (Exception) { }
                        if (MenueStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(MenueStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                MenueStWork wkMenueStWork = (MenueStWork)XmlByteSerializer.Deserialize(byteArray, typeof(MenueStWork));
                                if (wkMenueStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkMenueStWork);
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
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
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

//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車種名称マスタDBリモートオブジェクト
//                  :   PMTKD09071R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.06.10
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 車種名称マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車種名称マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class ModelNameDB : RemoteDB, IModelNameDB
    {
        /// <summary>
        /// 車種名称マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public ModelNameDB()
            : base("PMTKD09073D", "Broadleaf.Application.Remoting.ParamData.ModelNameWork", "MODELNAMERF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の車種名称マスタ情報を取得します。
        /// </summary>
        /// <param name="modelNameObj">ModelNameWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する車種名称マスタ情報を取得します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ref object modelNameObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            try
            {
                ModelNameWork ModelNameWork = modelNameObj as ModelNameWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null)
                    return status;

                status = this.Read(ModelNameWork, sqlConnection, null);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 単一の車種名称マスタ情報を取得します。
        /// </summary>
        /// <param name="modelNameWork">ModelNameWorkオブジェクト</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する車種名称マスタ情報を取得します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ModelNameWork modelNameWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return ReadProc(modelNameWork, sqlConnection, sqlTransaction);
        }

        private int ReadProc(ModelNameWork modelNameWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT " + Environment.NewLine;
                sqlText += "OFFERDATERF, " + Environment.NewLine;
                sqlText += "MODELUNIQUECODERF, " + Environment.NewLine;
                sqlText += "MAKERCODERF, " + Environment.NewLine;
                sqlText += "MODELCODERF, " + Environment.NewLine;
                sqlText += "MODELSUBCODERF, " + Environment.NewLine;
                sqlText += "MODELFULLNAMERF, " + Environment.NewLine;
                sqlText += "MODELHALFNAMERF, " + Environment.NewLine;
                sqlText += "MODELALIASNAMERF " + Environment.NewLine;
                sqlText += "FROM " + Environment.NewLine;
                sqlText += "MODELNAMERF " + Environment.NewLine;
                sqlText += "WHERE MODELUNIQUECODERF=@FINDMODELUNIQUECODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);

                //ユニークコード設定
                GetModelUniqueCode(modelNameWork);
                findParaModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameWork.ModelUniqueCode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToModelNameWorkFromReader(myReader, modelNameWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
            }

            return status;
        }
        # endregion

        # region [Search]
        /// <summary>
        /// 車種名称マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="modelNameList">検索結果</param>
        /// <param name="modelNameObj">検索条件</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する、全ての車種名称マスタ情報を取得します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ref object modelNameList, object modelNameObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            try
            {
                if (modelNameList == null)
                {
                    modelNameList = new ArrayList();
                }
                ArrayList modelNameArray = modelNameList as ArrayList;
                ModelNameWork ModelNameWork = modelNameObj as ModelNameWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null)
                    return status;

                status = this.Search(modelNameArray, ModelNameWork, sqlConnection, null);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 車種名称マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="modelNameList">車種名称マスタ情報を格納する ArrayList</param>
        /// <param name="ModelNameWork">検索条件</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する、全ての車種名称マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ArrayList modelNameList, ModelNameWork ModelNameWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            return SearchProc(modelNameList, ModelNameWork, sqlConnection, sqlTransaction);
        }

        private int SearchProc(ArrayList modelNameList, ModelNameWork ModelNameWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "OFFERDATERF, " + Environment.NewLine;
                sqlText += "MODELUNIQUECODERF, " + Environment.NewLine;
                sqlText += "MAKERCODERF, " + Environment.NewLine;
                sqlText += "MODELCODERF, " + Environment.NewLine;
                sqlText += "MODELSUBCODERF, " + Environment.NewLine;
                sqlText += "MODELFULLNAMERF, " + Environment.NewLine;
                sqlText += "MODELHALFNAMERF, " + Environment.NewLine;
                sqlText += "MODELALIASNAMERF " + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  MODELNAMERF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(sqlCommand, ModelNameWork);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    modelNameList.Add(this.CopyToModelNameWorkFromReader(myReader));
                }

                if (modelNameList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
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
            }

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="modelNameWork">検索条件格納クラス</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        private string MakeWhereString(SqlCommand sqlCommand, ModelNameWork modelNameWork)
        {
            string retstring = string.Empty;

            //車種コード
            int stunique, edunique = 0;

            GetModelUniqueCode(modelNameWork);

            if (modelNameWork.OfferDate != 0)
            {
                retstring = " OFFERDATERF > @FINDOFFERDATE" + Environment.NewLine;
                SqlParameter findOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);
                findOfferDate.Value = SqlDataMediator.SqlSetInt32(modelNameWork.OfferDate);
            }
            if (modelNameWork.MakerCode != 0)
            {
                if (retstring != string.Empty)
                    retstring += "AND ";

                if (modelNameWork.ModelSubCode == -1)
                {
                    retstring += "  MODELUNIQUECODERF >= @STMODELUNIQUECODE" + Environment.NewLine;
                    retstring += "  AND MODELUNIQUECODERF <= @EDMODELUNIQUECODE" + Environment.NewLine;

                    if (modelNameWork.ModelCode == 0)
                    {
                        //メーカーコードのみの指定
                        stunique = modelNameWork.MakerCode * 1000000;
                        edunique = stunique + 999999;
                    }
                    else
                    {
                        //メーカーコード＆モデルコードの指定
                        stunique = modelNameWork.MakerCode * 1000000 + modelNameWork.ModelCode * 1000;
                        edunique = stunique + 999;
                    }

                    SqlParameter findStModelUniqueCode = sqlCommand.Parameters.Add("@STMODELUNIQUECODE", SqlDbType.Int);
                    SqlParameter findEdModelUniqueCode = sqlCommand.Parameters.Add("@EDMODELUNIQUECODE", SqlDbType.Int);

                    findStModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(stunique);
                    findEdModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(edunique);

                }
                else
                {
                    //メーカーコード＆モデルコード＆サブコードの指定
                    retstring += "  MODELUNIQUECODERF = @FINDMODELUNIQUECODE" + Environment.NewLine;
                    SqlParameter findModelUniqueCode = sqlCommand.Parameters.Add("@FINDMODELUNIQUECODE", SqlDbType.Int);
                    findModelUniqueCode.Value = SqlDataMediator.SqlSetInt32(modelNameWork.ModelUniqueCode);
                }
            }
            if (retstring != string.Empty)
                retstring = "WHERE " + retstring;

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → ModelNameWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ModelNameWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private ModelNameWork CopyToModelNameWorkFromReader(SqlDataReader myReader)
        {
            ModelNameWork ModelNameWork = new ModelNameWork();

            this.CopyToModelNameWorkFromReader(myReader, ModelNameWork);

            return ModelNameWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → ModelNameWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="modelNameWork">ModelNameWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private void CopyToModelNameWorkFromReader(SqlDataReader myReader, ModelNameWork modelNameWork)
        {
            if (myReader != null && modelNameWork != null)
            {
                # region クラスへ格納
                modelNameWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                modelNameWork.ModelUniqueCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELUNIQUECODERF"));
                modelNameWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERCODERF"));
                modelNameWork.ModelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELCODERF"));
                modelNameWork.ModelSubCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELSUBCODERF"));
                modelNameWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
                modelNameWork.ModelHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELHALFNAMERF"));
                modelNameWork.ModelAliasName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELALIASNAMERF"));
                # endregion
            }
        }
        # endregion

        # region [ユニークコード設定処理]
        private void GetModelUniqueCode(ModelNameWork ModelNameWork)
        {
            ModelNameWork.ModelUniqueCode = ModelNameWork.MakerCode * 1000000
                                             + ModelNameWork.ModelCode * 1000
                                             + ModelNameWork.ModelSubCode;
        }

        # endregion

        #region [コネクション作成]
        private SqlConnection CreateSqlConnection()
        {
            //ＳＱＬ初期処理
            SqlConnectionInfo sqlConnectioninfo = new SqlConnectionInfo();
            string connectionText = sqlConnectioninfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }
            SqlConnection sqlConnection = new SqlConnection(connectionText);
            sqlConnection.Open();
            return sqlConnection;
        }
        #endregion
    }
}

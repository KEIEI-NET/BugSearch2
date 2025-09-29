//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象バージョン管理マスタメンテナンス
// プログラム概要   : コンバート対象バージョン管理マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using System.Data;
using Broadleaf.Xml.Serialization;
using System.Text;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// コンバート対象バージョン管理マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象バージョン管理マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ConvObjVerMngDB : RemoteDB, IConvObjVerMngDB
    {
        /// <summary>
        /// コンバート対象バージョン管理マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjVerMngDB()
            : base("PMCMN00136D", "Broadleaf.Application.Remoting.ParamData.ConvObjVerMngWork", "CONVOBJVERMNGRF")
        {

        }

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → ConvObjVerMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ConvObjVerMngWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private ConvObjVerMngWork CopyToConvObjVerMngWorkFromReader(ref SqlDataReader myReader)
        {
            ConvObjVerMngWork convObjVerMngWork = new ConvObjVerMngWork();

            this.CopyToConvObjVerMngWorkFromReader(ref myReader, ref convObjVerMngWork);

            return convObjVerMngWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → ConvObjVerMngWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="convObjVerMngWork">ConvObjVerMngWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private void CopyToConvObjVerMngWorkFromReader(ref SqlDataReader myReader, ref ConvObjVerMngWork convObjVerMngWork)
        {
            if (myReader != null && convObjVerMngWork != null)
            {
                # region クラスへ格納
                convObjVerMngWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                convObjVerMngWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                convObjVerMngWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                convObjVerMngWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                convObjVerMngWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                convObjVerMngWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                convObjVerMngWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                convObjVerMngWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                convObjVerMngWork.ConvertObjVer = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CONVERTOBJVERRF"));
                # endregion
            }
        }

        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
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

        # endregion [コネクション生成処理]

        #region IConvObjVerMngDB メンバ

        #region Search
        /// <summary>
        /// 指定された企業コードのコンバート対象バージョン管理LISTを全て戻します。
        /// </summary>
        /// <param name="outConvObjVerMng">検索結果</param>
        /// <param name="paraConvObjVerMngWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードのコンバート対象バージョン管理LISTを全て戻します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int Search(out object outConvObjVerMng, object paraConvObjVerMngWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList convObjVerMngList = null;
            ConvObjVerMngWork convObjVerMngWork = null;

            outConvObjVerMng = new CustomSerializeArrayList();

            try
            {
                convObjVerMngWork = paraConvObjVerMngWork as ConvObjVerMngWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                status = this.SearchProc(out convObjVerMngList, convObjVerMngWork, ref sqlConnection);

                if (convObjVerMngList != null && convObjVerMngList.Count != 0)
                {
                    (outConvObjVerMng as CustomSerializeArrayList).AddRange(convObjVerMngList);
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "ConvObjVerMngDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ConvObjVerMngDB.Search", status);
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
        /// 指定された企業コードのコンバート対象バージョン管理LISTを全て戻します。
        /// </summary>
        /// <param name="convObjVerMngList">検索結果</param>
        /// <param name="convObjVerMngWork">検索パラメータ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードのコンバート対象バージョン管理LISTを全て戻します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList convObjVerMngList, ConvObjVerMngWork convObjVerMngWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append("    ,CONVERTOBJVERRF" + Environment.NewLine);
                sqlText.Append(" FROM CONVOBJVERMNGRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                sqlText.Append(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODERF " + Environment.NewLine);
                sqlText.Append(" ORDER BY ENTERPRISECODERF " + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODERF", SqlDbType.Int);

                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.EnterpriseCode);
                findParaLogicalDeleteCode.Value = 0;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(this.CopyToConvObjVerMngWorkFromReader(ref myReader));
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
                status = base.WriteSQLErrorLog(sqlex, "ConvObjVerMngDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ConvObjVerMngDB.SearchProc", status);
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

            convObjVerMngList = al;

            return status;
        }

        #endregion

        #endregion IConvObjVerMngDB メンバ

    }
}

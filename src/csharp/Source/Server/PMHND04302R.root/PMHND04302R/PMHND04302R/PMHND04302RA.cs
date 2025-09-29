//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル発注先ガイドリモートオブジェクト
// プログラム概要   : ハンディターミナル発注先ガイドを行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル発注先ガイドリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル発注先ガイドリモートオブジェクトです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class HandySupplierGuideDB : RemoteDB, IHandySupplierGuideDB
    {
        #region [コンストラクタ]
        /// <summary>
        /// ハンディターミナル発注先ガイドリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public HandySupplierGuideDB()
        {
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// ハンディターミナル発注先ガイド情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル発注先ガイド情報を検索します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int Search(byte[] condByte, out object retListObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retListObj = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // sqlConnectionがnullの場合、エラーを戻ります。
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                SupplierGuideParamWork condWork = (SupplierGuideParamWork)XmlByteSerializer.Deserialize(condByte, typeof(SupplierGuideParamWork));
                // 検索条件がnullの場合、
                if (condWork == null)
                {
                    base.WriteErrorLog("HandySupplierGuideDB.Search" + "カスタムシリアライザ失敗");
                    return status;
                }

                ArrayList handySupplierGuideList = null;
                status = SearchProc(condWork, out handySupplierGuideList, ref sqlConnection);
                // 検索結果ステータスが正常の場合、
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retListObj = (object)handySupplierGuideList;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandySupplierGuideDB.Search" + ex.Message, status);
            }
            finally
            {
                // sqlConnectionがnullではない場合、
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Private Methods]
        /// <summary>
        /// ハンディターミナル発注先ガイド情報を戻します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="handySupplierGuideList">検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>検索結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル発注先ガイド情報を戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private int SearchProc(SupplierGuideParamWork condWork, out ArrayList handySupplierGuideList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handySupplierGuideList = new ArrayList();
            StringBuilder sb = null;

            try
            {
                # region SELECT句生成
                // SQL文を生成
                sb = new StringBuilder();
                sb.AppendLine("SELECT ");
                sb.AppendLine(" UOESUPPLIERRF.UOESUPPLIERCDRF, ");
                sb.AppendLine(" UOESUPPLIERRF.UOESUPPLIERNAMERF ");
                sb.AppendLine(" FROM UOESUPPLIERRF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" INNER JOIN");
                sb.AppendLine(" EMPLOYEERF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" ON UOESUPPLIERRF.ENTERPRISECODERF = EMPLOYEERF.ENTERPRISECODERF ");
                sb.AppendLine(" AND UOESUPPLIERRF.SECTIONCODERF = EMPLOYEERF.BELONGSECTIONCODERF ");
                sb.AppendLine(" AND UOESUPPLIERRF.LOGICALDELETECODERF = EMPLOYEERF.LOGICALDELETECODERF ");
                sb.AppendLine(" AND EMPLOYEERF.EMPLOYEECODERF = @FINDEMPLOYEECODE ");
                sb.AppendLine(" WHERE");
                sb.AppendLine(" UOESUPPLIERRF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                sb.AppendLine(" AND UOESUPPLIERRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                # endregion

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 従業員コード
                SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                findEmployeeCode.Value = SqlDataMediator.SqlSetString(condWork.EmployeeCode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                # region 検索結果設定
                while (myReader.Read())
                {
                    handySupplierGuideList.Add(CopyToHandySupplierGuideWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                #endregion
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandySupplierGuideDB.SearchProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合、
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
                // sqlCommandがnullではない場合、
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → HandyStockWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ハンディターミナル発注先ガイド情報ワーク</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private SupplierGuideResultWork CopyToHandySupplierGuideWorkFromReader(ref SqlDataReader myReader)
        {
            SupplierGuideResultWork supplierGuideResultWork = new SupplierGuideResultWork();

            #region クラスへ格納
            supplierGuideResultWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));
            supplierGuideResultWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));
            #endregion

            return supplierGuideResultWork;
        }

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnectionを生成します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            // SQLコネクション文字列が空場合、
            if (connectionText == null || connectionText == "")
            {
                base.WriteErrorLog("HandySupplierGuideDB.CreateSqlConnection" + "コネクション取得失敗");
                return null;
            } 

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}

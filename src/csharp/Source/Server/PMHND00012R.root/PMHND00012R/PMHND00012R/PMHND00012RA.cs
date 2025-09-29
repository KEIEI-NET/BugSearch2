//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナルログイン情報取得リモートオブジェクト
// プログラム概要   : ハンディターミナルログイン情報取得を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 朱宝軍
// 作 成 日  2017/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : ハンディターミナル二次開発の対応
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
    /// ハンディターミナルログイン情報取得リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナルログイン情報取得リモートオブジェクトです。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2017/06/05</br>
    /// <br>Update Note: 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br>管理番号   : 11370074-00</br>
    /// <br>           : ハンディターミナル二次開発の対応</br>
    /// </remarks>
    [Serializable]
    public class HandyLoginInfoDB : RemoteDB, IHandyLoginInfoDB
    {
        #region [定数]
        // ------ DEL 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>ロール(循環棚卸)「0:OFF(使用不可)」</summary>
        private const int CycleCountRollData0 = 0;
        /// <summary>ロール(循環棚卸)「1:ON(使用可)」</summary>
        private const int CycleCountRollData1 = 1;
        /// <summary>オペレーション設定区分「0:権限レベル1」</summary>
        private const int OperationStDivData0 = 0;
        /// <summary>オペレーション設定区分「2:従業員コード」</summary>
        private const int OperationStDivData2 = 2;
        /// <summary>カテゴリーコード</summary>
        private const int CategoryCodeData1 = 1;
        /// <summary>プログラムＩＤ</summary>
        private const string PgId = "PMHND05500A";
        // ------ DEL 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<
        #endregion

        #region [コンストラクタ]
        /// <summary>
        /// ハンディターミナルログイン情報取得リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        public HandyLoginInfoDB()
        {
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// ハンディターミナルログイン情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retByte">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナルログイン情報を検索します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        public int Search(byte[] condByte, out byte[] retByte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            retByte = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                // sqlConnectionがnullの場合
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                HandyLoginInfoCondWork condWork = (HandyLoginInfoCondWork)XmlByteSerializer.Deserialize(condByte, typeof(HandyLoginInfoCondWork));
                // condWorkがnullの場合
                if (condWork == null)
                {
                    base.WriteErrorLog("HandyLoginInfoDB.Search" + "カスタムシリアライザ失敗");
                    return status;
                }

                HandyLoginInfoWork handyLoginInfoWork = null;
                status = SearchProc(condWork, out handyLoginInfoWork, ref sqlConnection);
                // ステータスが正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retByte = XmlByteSerializer.Serialize(handyLoginInfoWork);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyLoginInfoDB.Search" + ex.Message, status);
            }
            finally
            {
                // sqlConnectionがnullではない場合
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
        /// 指定された条件の掛率優先管理マスタ情報LISTを戻します
        /// </summary>
        /// <param name="condWork">検索条件</param>
        /// <param name="handyLoginInfoWork">検索結果</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の掛率優先管理マスタ情報LISTを戻します</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// <br>Update Note: 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// <br>管理番号   : 11370074-00</br>
        /// <br>           : ハンディターミナル二次開発の対応</br>
        /// </remarks>
        private int SearchProc(HandyLoginInfoCondWork condWork, out HandyLoginInfoWork handyLoginInfoWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            handyLoginInfoWork = null;

            try
            {
                // SQL文を生成
                StringBuilder sb = new StringBuilder();

                // ------ DEL 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
                #region DEL 2017/08/11
                //# region SELECT句生成
                //sb.Append("SELECT");
                //sb.Append(" E.EMPLOYEECODERF,");
                //sb.Append(" E.NAMERF,");
                //sb.Append(" E.BELONGSECTIONCODERF,");
                //sb.Append(" S.SECTIONGUIDENMRF BELONGSECTIONNAMERF,");
                //sb.Append(" S.SECTWAREHOUSECD1RF,");
                //sb.Append(" E.RETIREMENTDATERF,");
                //sb.Append(" E.ENTERCOMPANYDATERF,");
                //sb.Append(" E.AUTHORITYLEVEL1RF,");
                //sb.Append(" E.AUTHORITYLEVEL2RF ");
                //sb.Append("FROM (");
                //sb.Append(" SELECT");
                //sb.Append("  ENTERPRISECODERF,");
                //sb.Append("  LOGICALDELETECODERF,");
                //sb.Append("  EMPLOYEECODERF,");
                //sb.Append("  NAMERF,");
                //sb.Append("  BELONGSECTIONCODERF,");
                //sb.Append("  RETIREMENTDATERF,");
                //sb.Append("  ENTERCOMPANYDATERF,");
                //sb.Append("  AUTHORITYLEVEL1RF,");
                //sb.Append("  AUTHORITYLEVEL2RF");
                //sb.Append(" FROM");
                //sb.Append("  EMPLOYEERF WITH (READUNCOMMITTED)");
                //sb.Append(" WHERE");
                //sb.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE");
                //sb.Append("  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE");
                //sb.Append("  AND LOGINIDRF = @FINDLOGINID) E");
                //sb.Append(" LEFT JOIN");
                //sb.Append(" SECINFOSETRF S WITH (READUNCOMMITTED)");
                //sb.Append(" ON E.ENTERPRISECODERF = S.ENTERPRISECODERF");
                //sb.Append(" AND E.LOGICALDELETECODERF = S.LOGICALDELETECODERF");
                //sb.Append(" AND E.BELONGSECTIONCODERF = S.SECTIONCODERF ");
                //# endregion
                #endregion
                // ------ DEL 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<

                // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
                # region SELECT句生成
                sb.AppendLine("SELECT");
                sb.AppendLine(" EMPLOYEERF.EMPLOYEECODERF, ");
                sb.AppendLine(" EMPLOYEERF.NAMERF, ");
                sb.AppendLine(" EMPLOYEERF.BELONGSECTIONCODERF, ");
                sb.AppendLine(" SECINFOSETRF.SECTIONGUIDENMRF BELONGSECTIONNAMERF, ");
                sb.AppendLine(" SECINFOSETRF.SECTWAREHOUSECD1RF, ");
                sb.AppendLine(" EMPLOYEERF.RETIREMENTDATERF, ");
                sb.AppendLine(" EMPLOYEERF.ENTERCOMPANYDATERF, ");
                sb.AppendLine(" EMPLOYEERF.AUTHORITYLEVEL1RF, ");
                sb.AppendLine(" EMPLOYEERF.AUTHORITYLEVEL2RF, ");
                sb.AppendLine(" CASE WHEN (OPERATIONSTRF1.LIMITDIVRF IS NOT NULL AND OPERATIONSTRF1.LIMITDIVRF = 1) OR (OPERATIONSTRF2.LIMITDIVRF IS NOT NULL AND OPERATIONSTRF2.LIMITDIVRF = 1) THEN @FINDCYCLECOUNTROLL1 ELSE @FINDCYCLECOUNTROLL2 END CYCLECOUNTROLLRF ");
                sb.AppendLine("FROM ");
                sb.AppendLine(" EMPLOYEERF WITH (READUNCOMMITTED) ");
                sb.AppendLine("LEFT JOIN");
                sb.AppendLine(" SECINFOSETRF WITH (READUNCOMMITTED) ");
                sb.AppendLine(" ON EMPLOYEERF.ENTERPRISECODERF = SECINFOSETRF.ENTERPRISECODERF ");
                sb.AppendLine(" AND EMPLOYEERF.LOGICALDELETECODERF = SECINFOSETRF.LOGICALDELETECODERF ");
                sb.AppendLine(" AND EMPLOYEERF.BELONGSECTIONCODERF = SECINFOSETRF.SECTIONCODERF ");
                sb.AppendLine("LEFT JOIN");
                sb.AppendLine(" OPERATIONSTRF OPERATIONSTRF1 WITH (READUNCOMMITTED) ");
                sb.AppendLine(" ON EMPLOYEERF.ENTERPRISECODERF = OPERATIONSTRF1.ENTERPRISECODERF ");
                sb.AppendLine(" AND EMPLOYEERF.LOGICALDELETECODERF = OPERATIONSTRF1.LOGICALDELETECODERF ");
                sb.AppendLine(" AND EMPLOYEERF.AUTHORITYLEVEL1RF = OPERATIONSTRF1.AUTHORITYLEVEL1RF ");
                sb.AppendLine(" AND OPERATIONSTRF1.OPERATIONSTDIVRF = @FINDOPERATIONSTDIV0 ");
                sb.AppendLine(" AND OPERATIONSTRF1.CATEGORYCODERF = @FINDCATEGORYCODE ");
                sb.AppendLine(" AND OPERATIONSTRF1.PGIDRF = @FINDPGID ");
                sb.AppendLine("LEFT JOIN");
                sb.AppendLine(" OPERATIONSTRF OPERATIONSTRF2 WITH (READUNCOMMITTED) ");
                sb.AppendLine(" ON EMPLOYEERF.ENTERPRISECODERF = OPERATIONSTRF2.ENTERPRISECODERF ");
                sb.AppendLine(" AND EMPLOYEERF.LOGICALDELETECODERF = OPERATIONSTRF2.LOGICALDELETECODERF ");
                sb.AppendLine(" AND EMPLOYEERF.EMPLOYEECODERF = OPERATIONSTRF2.EMPLOYEECODERF ");
                sb.AppendLine(" AND OPERATIONSTRF2.OPERATIONSTDIVRF = @FINDOPERATIONSTDIV2 ");
                sb.AppendLine(" AND OPERATIONSTRF2.CATEGORYCODERF = @FINDCATEGORYCODE ");
                sb.AppendLine(" AND OPERATIONSTRF2.PGIDRF = @FINDPGID ");
                sb.AppendLine("WHERE");
                sb.AppendLine("  EMPLOYEERF.ENTERPRISECODERF = @FINDENTERPRISECODE ");
                sb.AppendLine("  AND EMPLOYEERF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                sb.AppendLine("  AND EMPLOYEERF.LOGINIDRF = @FINDLOGINID ");
                # endregion
                // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<

                sqlCommand = new SqlCommand(sb.ToString(), sqlConnection);
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                #region パラメータ設定
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(condWork.EnterpriseCode);
                // 論理削除区分
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = 0;
                // ログインID
                SqlParameter findLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NVarChar);
                findLoginId.Value = SqlDataMediator.SqlSetString(condWork.LoginId);

                // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- >>>>
                // ロール(循環棚卸) 「0:OFF(使用不可)」
                SqlParameter findCycleCountRoll1 = sqlCommand.Parameters.Add("@FINDCYCLECOUNTROLL1", SqlDbType.Int);
                findCycleCountRoll1.Value = SqlDataMediator.SqlSetInt32(CycleCountRollData0);
                // ロール(循環棚卸) 「 1:ON(使用可)」
                SqlParameter findCycleCountRoll2 = sqlCommand.Parameters.Add("@FINDCYCLECOUNTROLL2", SqlDbType.Int);
                findCycleCountRoll2.Value = SqlDataMediator.SqlSetInt32(CycleCountRollData1);
                // オペレーション設定区分「0:権限レベル1」
                SqlParameter findOperationStDiv0 = sqlCommand.Parameters.Add("@FINDOPERATIONSTDIV0", SqlDbType.Int);
                findOperationStDiv0.Value = SqlDataMediator.SqlSetInt32(OperationStDivData0);
                // カテゴリーコード
                SqlParameter findCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                findCategoryCode.Value = SqlDataMediator.SqlSetInt32(CategoryCodeData1);
                // オペレーション設定区分「2:従業員コード」
                SqlParameter findOperationStDiv2 = sqlCommand.Parameters.Add("@FINDOPERATIONSTDIV2", SqlDbType.Int);
                findOperationStDiv2.Value = SqlDataMediator.SqlSetInt32(OperationStDivData2);
                // プログラムＩＤ
                SqlParameter findPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                findPgId.Value = SqlDataMediator.SqlSetString(PgId);
                // ------ ADD 2017/08/11 譚洪 ハンディターミナル二次開発 --------- <<<<

                #endregion

                myReader = sqlCommand.ExecuteReader();

                //int[] indexs = new int[9]; // DEL 2017/08/11 譚洪 ハンディターミナル二次開発
                int[] indexs = new int[10];  // ADD 2017/08/11 譚洪 ハンディターミナル二次開発
                // データが存在する場合
                if (myReader.HasRows)
                {
                    int i = -1;
                    indexs[++i] = myReader.GetOrdinal("EMPLOYEECODERF");
                    indexs[++i] = myReader.GetOrdinal("NAMERF");
                    indexs[++i] = myReader.GetOrdinal("BELONGSECTIONCODERF");
                    indexs[++i] = myReader.GetOrdinal("BELONGSECTIONNAMERF");
                    indexs[++i] = myReader.GetOrdinal("SECTWAREHOUSECD1RF");
                    indexs[++i] = myReader.GetOrdinal("RETIREMENTDATERF");
                    indexs[++i] = myReader.GetOrdinal("ENTERCOMPANYDATERF");
                    indexs[++i] = myReader.GetOrdinal("AUTHORITYLEVEL1RF");
                    indexs[++i] = myReader.GetOrdinal("AUTHORITYLEVEL2RF");
                    indexs[++i] = myReader.GetOrdinal("CYCLECOUNTROLLRF");  // ADD 2017/08/11 譚洪 ハンディターミナル二次開発
                }

                while (myReader.Read())
                {
                    handyLoginInfoWork = CopyToHandyLoginInfoWorkFromReader(indexs, ref myReader);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyLoginInfoDB.SearchProc" + ex.Message, status);
            }
            finally
            {
                // myReaderがnullではない場合
                if (myReader != null)
                {
                    // myReaderが閉じていない場合、
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                // sqlCommandがnullではない場合
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// クラス格納処理 Reader → HandyLoginInfoWork
        /// </summary>
        /// <param name="indexs">列の序数配列</param>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>HandyLoginInfoWork</returns>
        /// <remarks>
        /// <br>Note       : クラス格納処理を行います。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// <br>Update Note: 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        /// <br>管理番号   : 11370074-00</br>
        /// <br>           : ハンディターミナル二次開発の対応</br>
        /// </remarks>
        private HandyLoginInfoWork CopyToHandyLoginInfoWorkFromReader(int[] indexs, ref SqlDataReader myReader)
        {
            HandyLoginInfoWork handyLoginInfoWork = new HandyLoginInfoWork();

            #region クラスへ格納
            int i = -1;
            handyLoginInfoWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyLoginInfoWork.Name = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyLoginInfoWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyLoginInfoWork.BelongSectionName = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyLoginInfoWork.SectWarehouseCd1 = SqlDataMediator.SqlGetString(myReader, indexs[++i]);
            handyLoginInfoWork.RetirementDate = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyLoginInfoWork.EnterCompanyDate = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyLoginInfoWork.AuthorityLevel1 = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyLoginInfoWork.AuthorityLevel2 = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);
            handyLoginInfoWork.CycleCountRoll = SqlDataMediator.SqlGetInt32(myReader, indexs[++i]);  // ADD 2017/08/11 譚洪 ハンディターミナル二次開発
            #endregion

            return handyLoginInfoWork;
        }

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Note       : SqlConnectionを生成します。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "")
            {
                base.WriteErrorLog("HandyLoginInfoDB.CreateSqlConnection" + "コネクション取得失敗");
                return null;
            } 

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}

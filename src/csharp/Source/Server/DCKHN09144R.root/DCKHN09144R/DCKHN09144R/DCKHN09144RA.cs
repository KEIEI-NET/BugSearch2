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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
using Microsoft.Win32;
using System.Xml;
using System.IO;
// --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先(変動情報)マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先(変動情報)マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081　疋田　勇人</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: PM.NS用に変更</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.16</br>
    /// <br>Update Note: 2020/08/28 田建委</br>
    /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
    /// </remarks>
    [Serializable]
    public class CustomerChangeDB : RemoteDB, ICustomerChangeDB, IGetSyncdataList
    {
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>> 
        // 伝票更新タイムアウト時間設定ファイル
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XMLファイルが無い時のデフォルト値
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
        /// <summary>
        /// 得意先(変動情報)マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public CustomerChangeDB()
            :
            base("DCKHN09146D", "Broadleaf.Application.Remoting.ParamData.CustomerChangeWork", "CUSTOMERCHANGERF")
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の得意先(変動情報)マスタ情報LISTを戻します
        /// </summary>
        /// <param name="objCustomerChangeWork">検索結果</param>
        /// <param name="paraCustomerChangeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先(変動情報)マスタ情報LISTを戻します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        public int Search(out object objCustomerChangeWork, object paraCustomerChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            objCustomerChangeWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchProc(out objCustomerChangeWork, paraCustomerChangeWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerChangeDB.Search");
                objCustomerChangeWork = new ArrayList();
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
        /// 指定された条件の得意先(変動情報)マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objCustomerChangeWork">検索結果</param>
        /// <param name="paraCustomerChangeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先(変動情報)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        public int SearchProc(out object objCustomerChangeWork, object paraCustomerChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            CustomerChangeWork wrkCustomerChangeWork = null;

            ArrayList CustomerChangeWorkList = paraCustomerChangeWork as ArrayList;
            if (CustomerChangeWorkList == null)
            {
                wrkCustomerChangeWork = paraCustomerChangeWork as CustomerChangeWork;
            }
            else
            {
                if (CustomerChangeWorkList.Count > 0)
                    wrkCustomerChangeWork = CustomerChangeWorkList[0] as CustomerChangeWork;
            }

            int status = SearchProc(out CustomerChangeWorkList, wrkCustomerChangeWork, readMode, logicalMode, ref sqlConnection);
            objCustomerChangeWork = CustomerChangeWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件の得意先(変動情報)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="customerChangeWorkList">検索結果</param>
        /// <param name="paraCustomerChangeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先(変動情報)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
		public int SearchProc(out ArrayList customerChangeWorkList, CustomerChangeWork paraCustomerChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
		{
			return this.SearchProcProc(out customerChangeWorkList, paraCustomerChangeWork, readMode, logicalMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の得意先(変動情報)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="customerChangeWorkList">検索結果</param>
        /// <param name="paraCustomerChangeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先(変動情報)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
		private int SearchProcProc(out ArrayList customerChangeWorkList, CustomerChangeWork paraCustomerChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                // SQL文を生成
                string sqlText = string.Empty;
                # region SELECT句生成
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUSTCNG.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.CREDITMONEYRF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.WARNINGCREDITMONEYRF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.PRSNTACCRECBALANCERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERCHANGERF AS CUSTCNG" + Environment.NewLine;
                sqlText += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTCNG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERCODERF=CUSTCNG.CUSTOMERCODERF" + Environment.NewLine;

                # endregion

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region WHERE句生成

                sqlText += "WHERE" + Environment.NewLine;

                // 企業コード
                sqlText += "  CUSTCNG.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraCustomerChangeWork.EnterpriseCode);

                // 得意コード
                if (paraCustomerChangeWork.CustomerCode == 0)
                {
                    sqlText += "  AND CUSTCNG.CUSTOMERCODERF = CUSTCNG.CUSTOMERCODERF" + Environment.NewLine;
                }
                else
                {
                    sqlText += "  AND CUSTCNG.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraCustomerChangeWork.CustomerCode);
                }

                // 論理削除区分
                string wkstring = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND CUSTCNG.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                         (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND CUSTCNG.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlText += wkstring;
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                #endregion

                sqlCommand.CommandText = sqlText;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToCustomerChangeWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            customerChangeWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の得意先(変動情報)マスタを戻します
        /// </summary>
        /// <param name="parabyte">CustomerChangeWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先(変動情報)マスタを戻します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                CustomerChangeWork wrkCustomerChangeWork = new CustomerChangeWork();

                // XMLの読み込み
                wrkCustomerChangeWork = (CustomerChangeWork)XmlByteSerializer.Deserialize(parabyte, typeof(CustomerChangeWork));
                if (wrkCustomerChangeWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref wrkCustomerChangeWork, readMode, ref sqlConnection);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(wrkCustomerChangeWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerChangeDB.Read");
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
        /// 指定された条件の得意先(変動情報)マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraCustomerChangeWork">CustomerChangeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>        
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先(変動情報)マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
		public int ReadProc(ref CustomerChangeWork paraCustomerChangeWork, int readMode, ref SqlConnection sqlConnection)
		{
			return this.ReadProcProc(ref paraCustomerChangeWork, readMode, ref sqlConnection);
		}

        /// <summary>
        /// 指定された条件の得意先(変動情報)マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraCustomerChangeWork">CustomerChangeWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>        
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先(変動情報)マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081 疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
		private int ReadProcProc(ref CustomerChangeWork paraCustomerChangeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   CUSTCNG.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.CREDITMONEYRF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.WARNINGCREDITMONEYRF" + Environment.NewLine;
                sqlText += "  ,CUSTCNG.PRSNTACCRECBALANCERF" + Environment.NewLine;
                sqlText += "  ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERCHANGERF AS CUSTCNG" + Environment.NewLine;
                sqlText += "LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTCNG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND CUST.CUSTOMERCODERF=CUSTCNG.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUSTCNG.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUSTCNG.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraCustomerChangeWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraCustomerChangeWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        paraCustomerChangeWork = CopyToCustomerChangeWorkFromReader(ref myReader);
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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先(変動情報)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
		public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
		{
			return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
		}
		
		/// <summary>
        /// ローカルシンク用のデータを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="arraylistdata">検索結果</param>
        /// <param name="syncServiceWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の得意先(変動情報)マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                # region SELECT句生成
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUSTCNG.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.CREDITMONEYRF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.WARNINGCREDITMONEYRF" + Environment.NewLine;
                sqlText += " ,CUSTCNG.PRSNTACCRECBALANCERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTCNGPROTYMNGRF AS CUSTCNG" + Environment.NewLine;
                sqlText += "LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTCNG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND CUST.CUSTOMERCODERF=CUSTCNG.CUSTOMERCODERF" + Environment.NewLine;

                # endregion

                # region WHERE句生成
                sqlText += "WHERE" + Environment.NewLine;

                // 企業コード
                sqlText += "  CUSTCNG.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

                // 差分シンクの場合は更新日付の範囲指定
                if (syncServiceWork.Syncmode == 0)
                {
                    sqlText += "  AND CUSTCNG.UPDATEDATETIMERF >= @FINDUPDATEDATETIMEST ";
                    SqlParameter findUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                    findUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                    sqlText += "  AND CUSTCNG.UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED ";
                    SqlParameter findUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                    findUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
                }
                else
                {
                    sqlText += "  AND CUSTCNG.UPDATEDATETIMERF <= @FINDUPDATEDATETIMEED ";
                    SqlParameter findUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                    findUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
                }
                # endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToCustomerChangeWorkFromReader(ref myReader));

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
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            arraylistdata = al;

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// 得意先(変動情報)マスタを登録、更新します
        /// </summary>
        /// <param name="objCustomerChangeWork">CustomerChangeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(変動情報)マスタを登録、更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.08.10</br>
        public int Write(ref object objCustomerChangeWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(objCustomerChangeWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                objCustomerChangeWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerChangeDB.Write(ref object objCustomerChangeWork)");
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
        /// 得意先(変動情報)マスタ情報を登録、更新します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="customerChangeWorkList">CustomerChangeWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(変動情報)マスタ情報を登録、更新します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		public int WriteProc(ref ArrayList customerChangeWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.WriteProcProc(ref customerChangeWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 得意先(変動情報)マスタ情報を登録、更新します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="customerChangeWorkList">CustomerChangeWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(変動情報)マスタ情報を登録、更新します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.09.14</br>
		private int WriteProcProc(ref ArrayList customerChangeWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = string.Empty;
            try
            {
                if (customerChangeWorkList != null)
                {
                    for (int i = 0; i < customerChangeWorkList.Count; i++)
                    {
                        CustomerChangeWork wrkCustomerChangeWork = customerChangeWorkList[i] as CustomerChangeWork;
                        //Selectコマンドの生成
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CUSTCNG.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTOMERCHANGERF AS CUSTCNG" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CUSTCNG.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTCNG.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
 
                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(wrkCustomerChangeWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();

                        sqlText = string.Empty;

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != wrkCustomerChangeWork.UpdateDateTime)
                            {
                                if (wrkCustomerChangeWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    //新規登録で該当データ有りの場合には重複
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    //既存データで更新日時違いの場合には排他
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            // 更新時のSQL文を生成
                            sqlText = string.Empty; // 2008.05.26 add
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  CUSTOMERCHANGERF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,CREDITMONEYRF = @CREDITMONEY" + Environment.NewLine;
                            sqlText += " ,WARNINGCREDITMONEYRF = @WARNINGCREDITMONEY" + Environment.NewLine;
                            sqlText += " ,PRSNTACCRECBALANCERF = @PRSNTACCRECBALANCE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(wrkCustomerChangeWork.CustomerCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)wrkCustomerChangeWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (wrkCustomerChangeWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            //新規作成時のSQL文を生成
                            sqlText = string.Empty; // 2008.05.26 add
                            sqlText += "INSERT INTO CUSTOMERCHANGERF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += " ,CREDITMONEYRF" + Environment.NewLine;
                            sqlText += " ,WARNINGCREDITMONEYRF" + Environment.NewLine;
                            sqlText += " ,PRSNTACCRECBALANCERF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " ,@CREDITMONEY" + Environment.NewLine;
                            sqlText += " ,@WARNINGCREDITMONEY" + Environment.NewLine;
                            sqlText += " ,@PRSNTACCRECBALANCE" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)wrkCustomerChangeWork;
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCreditMoney = sqlCommand.Parameters.Add("@CREDITMONEY", SqlDbType.BigInt);
                        SqlParameter paraWarningCreditMoney = sqlCommand.Parameters.Add("@WARNINGCREDITMONEY", SqlDbType.BigInt);
                        SqlParameter paraPrsntAccRecBalance = sqlCommand.Parameters.Add("@PRSNTACCRECBALANCE", SqlDbType.BigInt);
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(wrkCustomerChangeWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(wrkCustomerChangeWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(wrkCustomerChangeWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(wrkCustomerChangeWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(wrkCustomerChangeWork.CustomerCode);
                        paraCreditMoney.Value = SqlDataMediator.SqlSetInt64(wrkCustomerChangeWork.CreditMoney);
                        paraWarningCreditMoney.Value = SqlDataMediator.SqlSetInt64(wrkCustomerChangeWork.WarningCreditMoney);
                        paraPrsntAccRecBalance.Value = SqlDataMediator.SqlSetInt64(wrkCustomerChangeWork.PrsntAccRecBalance);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(wrkCustomerChangeWork);
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
                {
                    if (myReader.IsClosed == false)
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

            customerChangeWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// 得意先(変動情報)マスタ情報を論理削除します
        /// </summary>
        /// <param name="objCustomerChangeWork">CustomerChangeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(変動情報)マスタ情報を論理削除します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        public int LogicalDelete(ref object objCustomerChangeWork)
        {
            return LogicalDeleteProc(ref objCustomerChangeWork, 0);
        }

        /// <summary>
        /// 論理削除得意先(変動情報)マスタ情報を復活します
        /// </summary>
        /// <param name="objCustomerChangeWork">CustomerChangeWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除得意先(変動情報)マスタ情報を復活します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        public int RevivalLogicalDelete(ref object objCustomerChangeWork)
        {
            return LogicalDeleteProc(ref objCustomerChangeWork, 1);
        }

        /// <summary>
        /// 得意先(変動情報)マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="objCustomerChangeWork">得意先(変動情報)Workオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(変動情報)マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        private int LogicalDeleteProc(ref object objCustomerChangeWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(objCustomerChangeWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "CustomerChangeDB.LogicalDeleteEjibaiRtDt :" + procModestr);

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
        /// 得意先(変動情報)マスタ情報の論理削除を操作します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="customerChangeWorkList">CustomerChangeWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(変動情報)マスタ情報の論理削除を操作します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
		public int LogicalDeleteProc(ref ArrayList customerChangeWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.LogicalDeleteProcProc(ref customerChangeWorkList, procMode, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 得意先(変動情報)マスタ情報の論理削除を操作します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="customerChangeWorkList">CustomerChangeWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(変動情報)マスタ情報の論理削除を操作します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
		private int LogicalDeleteProcProc(ref ArrayList customerChangeWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            string sqlText = string.Empty;

            try
            {
                if (customerChangeWorkList != null)
                {
                    for (int i = 0; i < customerChangeWorkList.Count; i++)
                    {
                        CustomerChangeWork wrkCustomerChangeWork = customerChangeWorkList[i] as CustomerChangeWork;

                        //Selectコマンドの生成
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CUSTCNG.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CUSTCNG.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTOMERCHANGERF AS CUSTCNG" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CUSTCNG.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTCNG.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(wrkCustomerChangeWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時

                            if (_updateDateTime != wrkCustomerChangeWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  CUSTOMERCHANGERF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            
                            sqlCommand.CommandText = sqlText;

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(wrkCustomerChangeWork.CustomerCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)wrkCustomerChangeWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
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
                                return status;
                            }
                            else if (logicalDelCd == 0) wrkCustomerChangeWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else wrkCustomerChangeWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) wrkCustomerChangeWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//完全削除はデータなしを戻す
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(wrkCustomerChangeWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(wrkCustomerChangeWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(wrkCustomerChangeWork);
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

            customerChangeWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 得意先(変動情報)マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">得意先(変動情報)マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : 得意先(変動情報)マスタ情報を物理削除します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
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

                status = DeleteProc(paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerChangeDB.Delete");
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
        /// 得意先(変動情報)マスタ情報を物理削除します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="customerChangeWorkList">得意先(変動情報)マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 得意先(変動情報)マスタ情報を物理削除します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
		public int DeleteProc(ArrayList customerChangeWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.DeleteProcProc(customerChangeWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 得意先(変動情報)マスタ情報を物理削除します(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="customerChangeWorkList">得意先(変動情報)マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 得意先(変動情報)マスタ情報を物理削除します(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
		private int DeleteProcProc(ArrayList customerChangeWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;
            try
            {

                for (int i = 0; i < customerChangeWorkList.Count; i++)
                {
                    CustomerChangeWork wrkCustomerChangeWork = customerChangeWorkList[i] as CustomerChangeWork;

                    //Selectコマンドの生成
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  CUSTCNG.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  CUSTOMERCHANGERF AS CUSTCNG" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  CUSTCNG.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CUSTCNG.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(wrkCustomerChangeWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != wrkCustomerChangeWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTOMERCHANGERF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(wrkCustomerChangeWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(wrkCustomerChangeWork.CustomerCode);
                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
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
                {
                    if (!myReader.IsClosed == false)
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

            return status;
        }
        #endregion

        #region [PrsntAccRecBalanceUpdate]
        /// <summary>
        /// 指定された得意先の現在売掛残高を更新します
        /// </summary>
        /// <param name="objCustomerChangeWork">CustomerChangeWorkオブジェクト</param>
        /// <param name="differenceValue">差額(更新額をセット:マイナスの場合はマイナス値でセット)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先の現在売掛残高を更新します</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.05.26</br>
        public int PrsntAccRecBalanceUpdate(ref object objCustomerChangeWork, Int64 differenceValue)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                CustomerChangeWork wkCustomerChangeWork = objCustomerChangeWork as CustomerChangeWork;
                if (wkCustomerChangeWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //現在売掛残高の更新を実行
                status = PrsntAccRecBalanceUpdateProc(ref wkCustomerChangeWork, differenceValue, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                objCustomerChangeWork = wkCustomerChangeWork;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerChangeDB.PrsntAccRecBalanceUpdate(ref object objCustomerChangeWork)");
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
        /// 指定された得意先の現在売掛残高を更新します。(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="paraCustomerChangeWork">CustomerChangeWorkオブジェクト</param>
        /// <param name="differenceValue">差額(更新額をセット:マイナスの場合はマイナス値でセット)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先の現在売掛残高を更新します。(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.05.26</br>
		public int PrsntAccRecBalanceUpdateProc(ref CustomerChangeWork paraCustomerChangeWork, Int64 differenceValue, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			return this.PrsntAccRecBalanceUpdateProcProc(ref paraCustomerChangeWork, differenceValue, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// 指定された得意先の現在売掛残高を更新します。(外部からのSqlConnection と SqlTranactionを使用)
        /// </summary>
        /// <param name="paraCustomerChangeWork">CustomerChangeWorkオブジェクト</param>
        /// <param name="differenceValue">差額(更新額をセット:マイナスの場合はマイナス値でセット)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された得意先の現在売掛残高を更新します。(外部からのSqlConnection と SqlTranactionを使用)</br>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2008.05.26</br>
        /// <br>Update Note: 2020/08/28 田建委</br>
        /// <br>             PMKOBETSU-4076 タイムアウト設定</br>
        private int PrsntAccRecBalanceUpdateProcProc(ref CustomerChangeWork paraCustomerChangeWork, Int64 differenceValue, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = string.Empty;
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // コマンドタイムアウト（秒）//ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 
            try
            {
                //Selectコマンドの生成
                sqlText = string.Empty;
                sqlText += "SELECT *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERCHANGERF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraCustomerChangeWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraCustomerChangeWork.CustomerCode);

                // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
                this.GetXmlInfo(ref dbCommandTimeout);
                sqlCommand.CommandTimeout = dbCommandTimeout;
                // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    paraCustomerChangeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    paraCustomerChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    paraCustomerChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    paraCustomerChangeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    paraCustomerChangeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    paraCustomerChangeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    paraCustomerChangeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    paraCustomerChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    paraCustomerChangeWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    paraCustomerChangeWork.CreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREDITMONEYRF"));
                    paraCustomerChangeWork.WarningCreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("WARNINGCREDITMONEYRF"));
                    paraCustomerChangeWork.PrsntAccRecBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRSNTACCRECBALANCERF"));

                    // 更新のSQL文を生成
                    sqlText = string.Empty;
                    sqlText += "UPDATE CUSTOMERCHANGERF" + Environment.NewLine;
                    sqlText += "SET" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                    sqlText += " ,PRSNTACCRECBALANCERF = (" + Environment.NewLine;
                    sqlText += "                          SELECT" + Environment.NewLine;
                    sqlText += "                            SUB.PRSNTACCRECBALANCERF + @DIFFERENCEVALUE" + Environment.NewLine;
                    sqlText += "                          FROM" + Environment.NewLine;
                    sqlText += "                            CUSTOMERCHANGERF AS SUB" + Environment.NewLine;
                    sqlText += "                          WHERE" + Environment.NewLine;
                    sqlText += "                            SUB.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "                            AND SUB.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "                          )" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraCustomerChangeWork.EnterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraCustomerChangeWork.CustomerCode);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)paraCustomerChangeWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存データが無い場合では何もせず終了
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
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
                SqlParameter paraDifferenceValue = sqlCommand.Parameters.Add("@DIFFERENCEVALUE", SqlDbType.BigInt);
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paraCustomerChangeWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(paraCustomerChangeWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraCustomerChangeWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(paraCustomerChangeWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(paraCustomerChangeWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(paraCustomerChangeWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(paraCustomerChangeWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(paraCustomerChangeWork.LogicalDeleteCode);
                paraDifferenceValue.Value = SqlDataMediator.SqlSetInt64(differenceValue); 
                #endregion

                sqlCommand.ExecuteNonQuery();
                        
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                paraCustomerChangeWork.PrsntAccRecBalance += differenceValue; 
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false)
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

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CustomerChangeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CUSTCNGProtyMngWork</returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private CustomerChangeWork CopyToCustomerChangeWorkFromReader(ref SqlDataReader myReader)
        {
            CustomerChangeWork wkCustomerChangeWork = new CustomerChangeWork();

            #region クラスへ格納
            wkCustomerChangeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkCustomerChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkCustomerChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkCustomerChangeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkCustomerChangeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkCustomerChangeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkCustomerChangeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkCustomerChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkCustomerChangeWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkCustomerChangeWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustomerChangeWork.CreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREDITMONEYRF"));
            wkCustomerChangeWork.WarningCreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("WARNINGCREDITMONEYRF"));
            wkCustomerChangeWork.PrsntAccRecBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRSNTACCRECBALANCERF"));
            #endregion

            return wkCustomerChangeWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CustomerChangeWork[] CustomerChangeWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is CustomerChangeWork)
                    {
                        CustomerChangeWork wkCustomerChangeWork = paraobj as CustomerChangeWork;
                        if (wkCustomerChangeWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCustomerChangeWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CustomerChangeWorkArray = (CustomerChangeWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CustomerChangeWork[]));
                        }
                        catch (Exception) { }
                        if (CustomerChangeWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CustomerChangeWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CustomerChangeWork wkCustomerChangeWork = (CustomerChangeWork)XmlByteSerializer.Deserialize(byteArray, typeof(CustomerChangeWork));
                                if (wkCustomerChangeWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCustomerChangeWork);
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
        /// <br>Programmer : 20081　疋田　勇人</br>
        /// <br>Date       : 2007.11.26</br>
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

        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------>>>>>
        #region 設定ファイル取得
        /// <summary>
        /// 設定ファイル取得
        /// </summary>
        /// <param name="dbCommandTimeout">タイムアウト時間</param>
        /// <remarks>
        /// <br>Note         : 設定ファイル取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // 初期値設定
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //タイムアウト時間を取得
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "設定ファイル取得エラー");
                }
            }

        }
        #endregion // 設定ファイル取得

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル名取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : XML情報取得処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダ取得
        /// </summary>
        /// <returns>XMLファイル名</returns>
        /// <remarks>
        /// <br>Note         : カレントフォルダ処理を行う</br>
        /// <br>Programmer   : 田建委</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ // 運用上ありえないケース
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_APのLOGフォルダにログ出力
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // カレントフォルダ
        // --- ADD 田建委 2020/08/28 PMKOBETSU-4076の対応 ------<<<<<
    }
}

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
    /// SCM相場価格設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM相場価格設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.05.08</br>
    /// <br></br>
    /// <br>Update Note: 相場価格品質コード２、相場価格品質コード３の追加</br>
    /// <br>Programmer : 21024 佐々木</br>
    /// <br>Date       : 2010/04/12</br>
    /// </remarks>
    [Serializable]
    public class SCMMrktPriStDB : RemoteDB, ISCMMrktPriStDB
    {
        /// <summary>
        /// SCM相場価格設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        /// </remarks>
        public SCMMrktPriStDB()
            :
            base("PMSCM09056D", "Broadleaf.Application.Remoting.ParamData.SCMMrktPriStWork", "SCMMRKTPRISTRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// 指定された条件のSCM相場価格設定マスタ情報LISTを戻します
        /// </summary>
        /// <param name="scmMrktPriStWork">検索結果</param>
        /// <param name="parascmMrktPriStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM相場価格設定マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int Search(out object scmMrktPriStWork, object parascmMrktPriStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            scmMrktPriStWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSCMMrktPriStProc(out scmMrktPriStWork, parascmMrktPriStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMMrktPriStDB.Search");
                scmMrktPriStWork = new ArrayList();
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
        /// 指定された条件のSCM相場価格設定マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objscmMrktPriStWork">検索結果</param>
        /// <param name="parascmMrktPriStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM相場価格設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int SearchSCMMrktPriStProc(out object objscmMrktPriStWork, object parascmMrktPriStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SCMMrktPriStWork scmMrktPriStWork = null; 

            ArrayList scmMrktPriStWorkList = parascmMrktPriStWork as ArrayList;
            if (scmMrktPriStWorkList == null)
            {
                scmMrktPriStWork = parascmMrktPriStWork as SCMMrktPriStWork;
            }
            else
            {
                if (scmMrktPriStWorkList.Count > 0)
                    scmMrktPriStWork = scmMrktPriStWorkList[0] as SCMMrktPriStWork;
            }

            int status = SearchSCMMrktPriStProc(out scmMrktPriStWorkList, scmMrktPriStWork, readMode, logicalMode, ref sqlConnection);
            objscmMrktPriStWork = scmMrktPriStWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のSCM相場価格設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">検索結果</param>
        /// <param name="scmMrktPriStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の在庫管理全体設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int SearchSCMMrktPriStProc(out ArrayList scmMrktPriStWorkList, SCMMrktPriStWork scmMrktPriStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchSCMMrktPriStProcProc(out scmMrktPriStWorkList, scmMrktPriStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のSCM相場価格設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">検索結果</param>
        /// <param name="scmMrktPriStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM相場価格設定マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        private int SearchSCMMrktPriStProcProc(out ArrayList scmMrktPriStWorkList, SCMMrktPriStWork scmMrktPriStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += " SELECT   CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEAREACDRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEQUALITYCDRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD1RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD2RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD3RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICESALESRATERF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT1RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT2RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT3RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT4RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT5RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT6RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT7RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT8RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT9RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT10RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT1RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT2RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT3RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT4RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT5RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT6RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT7RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT8RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT9RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT10RF " + Environment.NewLine;
                selectTxt += "         ,FRACTIONPROCCDRF" + Environment.NewLine;
                // 2010/04/12 Add >>>
                selectTxt += "         ,MARKETPRICEQUALITYCD2RF" + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEQUALITYCD3RF" + Environment.NewLine;
                // 2010/04/12 Add <<<
                selectTxt += "  FROM SCMMRKTPRISTRF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, scmMrktPriStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToSCMMrktPriStWorkFromReader(ref myReader));

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

            scmMrktPriStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のSCM相場価格設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM相場価格設定マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                SCMMrktPriStWork scmMrktPriStWork = new SCMMrktPriStWork();

                // XMLの読み込み
                scmMrktPriStWork = (SCMMrktPriStWork)XmlByteSerializer.Deserialize(parabyte, typeof(SCMMrktPriStWork));
                if (scmMrktPriStWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref scmMrktPriStWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(scmMrktPriStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMMrktPriStDB.Read");
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
        /// 指定された条件のSCM相場価格設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmMrktPriStWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM相場価格設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int ReadProc(ref SCMMrktPriStWork scmMrktPriStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref scmMrktPriStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件のSCM相場価格設定マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="scmMrktPriStWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のSCM相場価格設定マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        private int ReadProcProc(ref SCMMrktPriStWork scmMrktPriStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT文
                selectTxt += " SELECT   CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,SECTIONCODERF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEAREACDRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEQUALITYCDRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD1RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD2RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEKINDCD3RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEANSWERDIVRF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICESALESRATERF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT1RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT2RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT3RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT4RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT5RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT6RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT7RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT8RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT9RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNTAMBIT10RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT1RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT2RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT3RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT4RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT5RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT6RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT7RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT8RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT9RF " + Environment.NewLine;
                selectTxt += "         ,ADDPAYMNT10RF " + Environment.NewLine;
                selectTxt += "         ,FRACTIONPROCCDRF" + Environment.NewLine;
                // 2010/04/12 Add >>>
                selectTxt += "         ,MARKETPRICEQUALITYCD2RF " + Environment.NewLine;
                selectTxt += "         ,MARKETPRICEQUALITYCD3RF " + Environment.NewLine;
                // 2010/04/12 Add <<<
                selectTxt += "  FROM SCMMRKTPRISTRF " + Environment.NewLine;
                selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;
                #endregion

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        scmMrktPriStWork = CopyToSCMMrktPriStWorkFromReader(ref myReader);
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

        #region [Write]
        /// <summary>
        /// SCM相場価格設定マスタ情報を登録、更新します
        /// </summary>
        /// <param name="scmMrktPriStWork">scmMrktPriStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM相場価格設定マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int Write(ref object scmMrktPriStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(scmMrktPriStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSCMMrktPriStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                SCMMrktPriStWork paraWork = paraList[0] as SCMMrktPriStWork;
                
                //全社設定を更新した場合は、他の項目にも反映させる
                if (paraWork.SectionCode == _allSecCode)
                {
                    UpdateAllSecSCMMrktPriSt(ref paraList, ref sqlConnection, ref sqlTransaction);
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
                scmMrktPriStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SCMMrktPriStDB.Write(ref object scmMrktPriStWork)");
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
        /// SCM相場価格設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM相場価格設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int WriteSCMMrktPriStProc(ref ArrayList scmMrktPriStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteSCMMrktPriStProcProc(ref scmMrktPriStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM相場価格設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM相場価格設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        private int WriteSCMMrktPriStProcProc(ref ArrayList scmMrktPriStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmMrktPriStWorkList != null)
                {
                    for (int i = 0; i < scmMrktPriStWorkList.Count; i++)
                    {
                        SCMMrktPriStWork scmMrktPriStWork = scmMrktPriStWorkList[i] as SCMMrktPriStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM SCMMRKTPRISTRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != scmMrktPriStWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (scmMrktPriStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += " UPDATE SCMMRKTPRISTRF SET  " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEAREACDRF = @MARKETPRICEAREACD " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEQUALITYCDRF = @MARKETPRICEQUALITYCD " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEKINDCD1RF = @MARKETPRICEKINDCD1 " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEKINDCD2RF = @MARKETPRICEKINDCD2 " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEKINDCD3RF = @MARKETPRICEKINDCD3 " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEANSWERDIVRF = @MARKETPRICEANSWERDIV " + Environment.NewLine;
                            sqlText += "  , MARKETPRICESALESRATERF = @MARKETPRICESALESRATE " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT1RF = @ADDPAYMNTAMBIT1 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT2RF = @ADDPAYMNTAMBIT2 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT3RF = @ADDPAYMNTAMBIT3 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT4RF = @ADDPAYMNTAMBIT4 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT5RF = @ADDPAYMNTAMBIT5 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT6RF = @ADDPAYMNTAMBIT6 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT7RF = @ADDPAYMNTAMBIT7 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT8RF = @ADDPAYMNTAMBIT8 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT9RF = @ADDPAYMNTAMBIT9 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNTAMBIT10RF = @ADDPAYMNTAMBIT10 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT1RF = @ADDPAYMNT1 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT2RF = @ADDPAYMNT2 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT3RF = @ADDPAYMNT3 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT4RF = @ADDPAYMNT4 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT5RF = @ADDPAYMNT5 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT6RF = @ADDPAYMNT6 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT7RF = @ADDPAYMNT7 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT8RF = @ADDPAYMNT8 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT9RF = @ADDPAYMNT9 " + Environment.NewLine;
                            sqlText += "  , ADDPAYMNT10RF = @ADDPAYMNT10 " + Environment.NewLine;
                            sqlText += "  , FRACTIONPROCCDRF = @FRACTIONPROCCD" + Environment.NewLine;
                            // 2010/04/12 Add >>>
                            sqlText += "  , MARKETPRICEQUALITYCD2RF = @MARKETPRICEQUALITYCD2 " + Environment.NewLine;
                            sqlText += "  , MARKETPRICEQUALITYCD3RF = @MARKETPRICEQUALITYCD3 " + Environment.NewLine;
                            // 2010/04/12 Add <<<
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND SECTIONCODERF = @FINDSECTIONCODE " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmMrktPriStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (scmMrktPriStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO SCMMRKTPRISTRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,SECTIONCODERF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEAREACDRF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEQUALITYCDRF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEKINDCD1RF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEKINDCD2RF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEKINDCD3RF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEANSWERDIVRF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICESALESRATERF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT1RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT2RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT3RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT4RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT5RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT6RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT7RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT8RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT9RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNTAMBIT10RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT1RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT2RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT3RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT4RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT5RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT6RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT7RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT8RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT9RF " + Environment.NewLine;
                            sqlText += "         ,ADDPAYMNT10RF " + Environment.NewLine;
                            sqlText += "         ,FRACTIONPROCCDRF" + Environment.NewLine;
                            // 2010/04/12 Add >>>
                            sqlText += "         ,MARKETPRICEQUALITYCD2RF " + Environment.NewLine;
                            sqlText += "         ,MARKETPRICEQUALITYCD3RF " + Environment.NewLine;
                            // 2010/04/12 Add <<<
                            sqlText += "  ) " + Environment.NewLine;
                            sqlText += "  VALUES " + Environment.NewLine;
                            sqlText += "  (@CREATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "         ,@ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         ,@FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "         ,@UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "         ,@UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "         ,@LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "         ,@SECTIONCODE " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEAREACD " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEQUALITYCD " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEKINDCD1 " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEKINDCD2 " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEKINDCD3 " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEANSWERDIV " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICESALESRATE " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT1 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT2 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT3 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT4 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT5 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT6 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT7 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT8 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT9 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNTAMBIT10 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT1 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT2 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT3 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT4 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT5 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT6 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT7 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT8 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT9 " + Environment.NewLine;
                            sqlText += "         ,@ADDPAYMNT10 " + Environment.NewLine;
                            sqlText += "         ,@FRACTIONPROCCD" + Environment.NewLine;
                            // 2010/04/12 Add >>>
                            sqlText += "         ,@MARKETPRICEQUALITYCD2 " + Environment.NewLine;
                            sqlText += "         ,@MARKETPRICEQUALITYCD3 " + Environment.NewLine;
                            // 2010/04/12 Add <<<
                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmMrktPriStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter paraMarketPriceAreaCd = sqlCommand.Parameters.Add("@MARKETPRICEAREACD", SqlDbType.Int);  // 相場価格地域コード
                        SqlParameter paraMarketPriceQualityCd = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD", SqlDbType.Int);  // 相場価格品質コード
                        SqlParameter paraMarketPriceKindCd1 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD1", SqlDbType.Int);  // 相場価格種別コード１
                        SqlParameter paraMarketPriceKindCd2 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD2", SqlDbType.Int);  // 相場価格種別コード２
                        SqlParameter paraMarketPriceKindCd3 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD3", SqlDbType.Int);  // 相場価格種別コード３
                        SqlParameter paraMarketPriceAnswerDiv = sqlCommand.Parameters.Add("@MARKETPRICEANSWERDIV", SqlDbType.Int);  // 相場価格回答区分
                        SqlParameter paraMarketPriceSalesRate = sqlCommand.Parameters.Add("@MARKETPRICESALESRATE", SqlDbType.Float);  // 相場価格売価率
                        SqlParameter paraAddPaymntAmbit1 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT1", SqlDbType.Int);  // 加算額範囲1
                        SqlParameter paraAddPaymntAmbit2 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT2", SqlDbType.Int);  // 加算額範囲2
                        SqlParameter paraAddPaymntAmbit3 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT3", SqlDbType.Int);  // 加算額範囲3
                        SqlParameter paraAddPaymntAmbit4 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT4", SqlDbType.Int);  // 加算額範囲4
                        SqlParameter paraAddPaymntAmbit5 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT5", SqlDbType.Int);  // 加算額範囲5
                        SqlParameter paraAddPaymntAmbit6 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT6", SqlDbType.Int);  // 加算額範囲6
                        SqlParameter paraAddPaymntAmbit7 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT7", SqlDbType.Int);  // 加算額範囲7
                        SqlParameter paraAddPaymntAmbit8 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT8", SqlDbType.Int);  // 加算額範囲8
                        SqlParameter paraAddPaymntAmbit9 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT9", SqlDbType.Int);  // 加算額範囲9
                        SqlParameter paraAddPaymntAmbit10 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT10", SqlDbType.Int);  // 加算額範囲10
                        SqlParameter paraAddPaymnt1 = sqlCommand.Parameters.Add("@ADDPAYMNT1", SqlDbType.Int);  // 加算額1
                        SqlParameter paraAddPaymnt2 = sqlCommand.Parameters.Add("@ADDPAYMNT2", SqlDbType.Int);  // 加算額2
                        SqlParameter paraAddPaymnt3 = sqlCommand.Parameters.Add("@ADDPAYMNT3", SqlDbType.Int);  // 加算額3
                        SqlParameter paraAddPaymnt4 = sqlCommand.Parameters.Add("@ADDPAYMNT4", SqlDbType.Int);  // 加算額4
                        SqlParameter paraAddPaymnt5 = sqlCommand.Parameters.Add("@ADDPAYMNT5", SqlDbType.Int);  // 加算額5
                        SqlParameter paraAddPaymnt6 = sqlCommand.Parameters.Add("@ADDPAYMNT6", SqlDbType.Int);  // 加算額6
                        SqlParameter paraAddPaymnt7 = sqlCommand.Parameters.Add("@ADDPAYMNT7", SqlDbType.Int);  // 加算額7
                        SqlParameter paraAddPaymnt8 = sqlCommand.Parameters.Add("@ADDPAYMNT8", SqlDbType.Int);  // 加算額8
                        SqlParameter paraAddPaymnt9 = sqlCommand.Parameters.Add("@ADDPAYMNT9", SqlDbType.Int);  // 加算額9
                        SqlParameter paraAddPaymnt10 = sqlCommand.Parameters.Add("@ADDPAYMNT10", SqlDbType.Int);  // 加算額10
                        SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);  // 端数処理区分
                        // 2010/04/12 Add >>>
                        SqlParameter paraMarketPriceQualityCd2 = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD2", SqlDbType.Int);  // 相場価格品質コード２
                        SqlParameter paraMarketPriceQualityCd3 = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD3", SqlDbType.Int);  // 相場価格品質コード３
                        // 2010/04/12 Add <<<
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmMrktPriStWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmMrktPriStWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmMrktPriStWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.LogicalDeleteCode);  // 論理削除区分
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);  // 拠点コード
                        paraMarketPriceAreaCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceAreaCd);  // 相場価格地域コード
                        paraMarketPriceQualityCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd);  // 相場価格品質コード
                        paraMarketPriceKindCd1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd1);  // 相場価格種別コード１
                        paraMarketPriceKindCd2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd2);  // 相場価格種別コード２
                        paraMarketPriceKindCd3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd3);  // 相場価格種別コード３
                        paraMarketPriceAnswerDiv.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceAnswerDiv);  // 相場価格回答区分
                        paraMarketPriceSalesRate.Value = SqlDataMediator.SqlSetDouble(scmMrktPriStWork.MarketPriceSalesRate);  // 相場価格売価率
                        paraAddPaymntAmbit1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit1);  // 加算額範囲1
                        paraAddPaymntAmbit2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit2);  // 加算額範囲2
                        paraAddPaymntAmbit3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit3);  // 加算額範囲3
                        paraAddPaymntAmbit4.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit4);  // 加算額範囲4
                        paraAddPaymntAmbit5.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit5);  // 加算額範囲5
                        paraAddPaymntAmbit6.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit6);  // 加算額範囲6
                        paraAddPaymntAmbit7.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit7);  // 加算額範囲7
                        paraAddPaymntAmbit8.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit8);  // 加算額範囲8
                        paraAddPaymntAmbit9.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit9);  // 加算額範囲9
                        paraAddPaymntAmbit10.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit10);  // 加算額範囲10
                        paraAddPaymnt1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt1);  // 加算額1
                        paraAddPaymnt2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt2);  // 加算額2
                        paraAddPaymnt3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt3);  // 加算額3
                        paraAddPaymnt4.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt4);  // 加算額4
                        paraAddPaymnt5.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt5);  // 加算額5
                        paraAddPaymnt6.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt6);  // 加算額6
                        paraAddPaymnt7.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt7);  // 加算額7
                        paraAddPaymnt8.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt8);  // 加算額8
                        paraAddPaymnt9.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt9);  // 加算額9
                        paraAddPaymnt10.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt10);  // 加算額10
                        paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.FractionProcCd);  // 端数処理区分
                        // 2010/04/12 Add >>>
                        paraMarketPriceQualityCd2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd2);  // 相場価格品質コード２
                        paraMarketPriceQualityCd3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd3);  // 相場価格品質コード３
                        // 2010/04/12 Add <<<
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmMrktPriStWork);
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
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            scmMrktPriStWorkList = al;

            return status;
        }

        /// <summary>
        /// 全社共通項目を更新する
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM相場価格設定マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        private int UpdateAllSecSCMMrktPriSt(ref ArrayList scmMrktPriStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (scmMrktPriStWorkList != null)
                {
                    SCMMrktPriStWork scmMrktPriStWork = scmMrktPriStWorkList[0] as SCMMrktPriStWork;

                    sqlCommand = new SqlCommand("",sqlConnection,sqlTransaction);
                    # region 更新時のSQL文生成
                    string sqlText = string.Empty;
                    sqlText += " UPDATE SCMMRKTPRISTRF SET  " + Environment.NewLine;
                    sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                    sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                    sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                    sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                    sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                    sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                    sqlText += "  , SECTIONCODERF = @SECTIONCODE " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEAREACDRF = @MARKETPRICEAREACD " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEQUALITYCDRF = @MARKETPRICEQUALITYCD " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEKINDCD1RF = @MARKETPRICEKINDCD1 " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEKINDCD2RF = @MARKETPRICEKINDCD2 " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEKINDCD3RF = @MARKETPRICEKINDCD3 " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEANSWERDIVRF = @MARKETPRICEANSWERDIV " + Environment.NewLine;
                    sqlText += "  , MARKETPRICESALESRATERF = @MARKETPRICESALESRATE " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT1RF = @ADDPAYMNTAMBIT1 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT2RF = @ADDPAYMNTAMBIT2 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT3RF = @ADDPAYMNTAMBIT3 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT4RF = @ADDPAYMNTAMBIT4 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT5RF = @ADDPAYMNTAMBIT5 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT6RF = @ADDPAYMNTAMBIT6 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT7RF = @ADDPAYMNTAMBIT7 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT8RF = @ADDPAYMNTAMBIT8 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT9RF = @ADDPAYMNTAMBIT9 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNTAMBIT10RF = @ADDPAYMNTAMBIT10 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT1RF = @ADDPAYMNT1 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT2RF = @ADDPAYMNT2 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT3RF = @ADDPAYMNT3 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT4RF = @ADDPAYMNT4 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT5RF = @ADDPAYMNT5 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT6RF = @ADDPAYMNT6 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT7RF = @ADDPAYMNT7 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT8RF = @ADDPAYMNT8 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT9RF = @ADDPAYMNT9 " + Environment.NewLine;
                    sqlText += "  , ADDPAYMNT10RF = @ADDPAYMNT10 " + Environment.NewLine;
                    sqlText += "  , FRACTIONPROCCDRF = @FRACTIONPROCCD" + Environment.NewLine;
                    // 2010/04/12 Add >>>
                    sqlText += "  , MARKETPRICEQUALITYCD2RF = @MARKETPRICEQUALITYCD2 " + Environment.NewLine;
                    sqlText += "  , MARKETPRICEQUALITYCD3RF = @MARKETPRICEQUALITYCD3 " + Environment.NewLine;
                    // 2010/04/12 Add <<<
                    sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                    sqlText += "  　AND SECTIONCODERF<>'00'" + Environment.NewLine;
                    sqlCommand.CommandText = sqlText;

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)scmMrktPriStWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                    #endregion

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                    SqlParameter paraMarketPriceAreaCd = sqlCommand.Parameters.Add("@MARKETPRICEAREACD", SqlDbType.Int);  // 相場価格地域コード
                    SqlParameter paraMarketPriceQualityCd = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD", SqlDbType.Int);  // 相場価格品質コード
                    SqlParameter paraMarketPriceKindCd1 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD1", SqlDbType.Int);  // 相場価格種別コード１
                    SqlParameter paraMarketPriceKindCd2 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD2", SqlDbType.Int);  // 相場価格種別コード２
                    SqlParameter paraMarketPriceKindCd3 = sqlCommand.Parameters.Add("@MARKETPRICEKINDCD3", SqlDbType.Int);  // 相場価格種別コード３
                    SqlParameter paraMarketPriceAnswerDiv = sqlCommand.Parameters.Add("@MARKETPRICEANSWERDIV", SqlDbType.Int);  // 相場価格回答区分
                    SqlParameter paraMarketPriceSalesRate = sqlCommand.Parameters.Add("@MARKETPRICESALESRATE", SqlDbType.Float);  // 相場価格売価率
                    SqlParameter paraAddPaymntAmbit1 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT1", SqlDbType.Int);  // 加算額範囲1
                    SqlParameter paraAddPaymntAmbit2 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT2", SqlDbType.Int);  // 加算額範囲2
                    SqlParameter paraAddPaymntAmbit3 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT3", SqlDbType.Int);  // 加算額範囲3
                    SqlParameter paraAddPaymntAmbit4 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT4", SqlDbType.Int);  // 加算額範囲4
                    SqlParameter paraAddPaymntAmbit5 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT5", SqlDbType.Int);  // 加算額範囲5
                    SqlParameter paraAddPaymntAmbit6 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT6", SqlDbType.Int);  // 加算額範囲6
                    SqlParameter paraAddPaymntAmbit7 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT7", SqlDbType.Int);  // 加算額範囲7
                    SqlParameter paraAddPaymntAmbit8 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT8", SqlDbType.Int);  // 加算額範囲8
                    SqlParameter paraAddPaymntAmbit9 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT9", SqlDbType.Int);  // 加算額範囲9
                    SqlParameter paraAddPaymntAmbit10 = sqlCommand.Parameters.Add("@ADDPAYMNTAMBIT10", SqlDbType.Int);  // 加算額範囲10
                    SqlParameter paraAddPaymnt1 = sqlCommand.Parameters.Add("@ADDPAYMNT1", SqlDbType.Int);  // 加算額1
                    SqlParameter paraAddPaymnt2 = sqlCommand.Parameters.Add("@ADDPAYMNT2", SqlDbType.Int);  // 加算額2
                    SqlParameter paraAddPaymnt3 = sqlCommand.Parameters.Add("@ADDPAYMNT3", SqlDbType.Int);  // 加算額3
                    SqlParameter paraAddPaymnt4 = sqlCommand.Parameters.Add("@ADDPAYMNT4", SqlDbType.Int);  // 加算額4
                    SqlParameter paraAddPaymnt5 = sqlCommand.Parameters.Add("@ADDPAYMNT5", SqlDbType.Int);  // 加算額5
                    SqlParameter paraAddPaymnt6 = sqlCommand.Parameters.Add("@ADDPAYMNT6", SqlDbType.Int);  // 加算額6
                    SqlParameter paraAddPaymnt7 = sqlCommand.Parameters.Add("@ADDPAYMNT7", SqlDbType.Int);  // 加算額7
                    SqlParameter paraAddPaymnt8 = sqlCommand.Parameters.Add("@ADDPAYMNT8", SqlDbType.Int);  // 加算額8
                    SqlParameter paraAddPaymnt9 = sqlCommand.Parameters.Add("@ADDPAYMNT9", SqlDbType.Int);  // 加算額9
                    SqlParameter paraAddPaymnt10 = sqlCommand.Parameters.Add("@ADDPAYMNT10", SqlDbType.Int);  // 加算額10
                    SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);  // 端数処理区分
                    // 2010/04/12 Add >>>
                    SqlParameter paraMarketPriceQualityCd2 = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD2", SqlDbType.Int);  // 相場価格品質コード２
                    SqlParameter paraMarketPriceQualityCd3 = sqlCommand.Parameters.Add("@MARKETPRICEQUALITYCD3", SqlDbType.Int);  // 相場価格品質コード３
                    // 2010/04/12 Add <<<
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmMrktPriStWork.CreateDateTime);  // 作成日時
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmMrktPriStWork.UpdateDateTime);  // 更新日時
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);  // 企業コード
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(scmMrktPriStWork.FileHeaderGuid);  // GUID
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdEmployeeCode);  // 更新従業員コード
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId1);  // 更新アセンブリID1
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId2);  // 更新アセンブリID2
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.LogicalDeleteCode);  // 論理削除区分
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);  // 拠点コード
                    paraMarketPriceAreaCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceAreaCd);  // 相場価格地域コード
                    paraMarketPriceQualityCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd);  // 相場価格品質コード
                    paraMarketPriceKindCd1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd1);  // 相場価格種別コード１
                    paraMarketPriceKindCd2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd2);  // 相場価格種別コード２
                    paraMarketPriceKindCd3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceKindCd3);  // 相場価格種別コード３
                    paraMarketPriceAnswerDiv.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceAnswerDiv);  // 相場価格回答区分
                    paraMarketPriceSalesRate.Value = SqlDataMediator.SqlSetDouble(scmMrktPriStWork.MarketPriceSalesRate);  // 相場価格売価率
                    paraAddPaymntAmbit1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit1);  // 加算額範囲1
                    paraAddPaymntAmbit2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit2);  // 加算額範囲2
                    paraAddPaymntAmbit3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit3);  // 加算額範囲3
                    paraAddPaymntAmbit4.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit4);  // 加算額範囲4
                    paraAddPaymntAmbit5.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit5);  // 加算額範囲5
                    paraAddPaymntAmbit6.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit6);  // 加算額範囲6
                    paraAddPaymntAmbit7.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit7);  // 加算額範囲7
                    paraAddPaymntAmbit8.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit8);  // 加算額範囲8
                    paraAddPaymntAmbit9.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit9);  // 加算額範囲9
                    paraAddPaymntAmbit10.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymntAmbit10);  // 加算額範囲10
                    paraAddPaymnt1.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt1);  // 加算額1
                    paraAddPaymnt2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt2);  // 加算額2
                    paraAddPaymnt3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt3);  // 加算額3
                    paraAddPaymnt4.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt4);  // 加算額4
                    paraAddPaymnt5.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt5);  // 加算額5
                    paraAddPaymnt6.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt6);  // 加算額6
                    paraAddPaymnt7.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt7);  // 加算額7
                    paraAddPaymnt8.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt8);  // 加算額8
                    paraAddPaymnt9.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt9);  // 加算額9
                    paraAddPaymnt10.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.AddPaymnt10);  // 加算額10
                    paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.FractionProcCd);  // 端数処理区分
                    // 2010/04/12 Add >>>
                    paraMarketPriceQualityCd2.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd2);  // 相場価格品質コード２
                    paraMarketPriceQualityCd3.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.MarketPriceQualityCd3);  // 相場価格品質コード３
                    // 2010/04/12 Add <<<
                    #endregion

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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// SCM相場価格設定マスタ情報を論理削除します
        /// </summary>
        /// <param name="scmMrktPriStWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM相場価格設定マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int LogicalDelete(ref object scmMrktPriStWork)
        {
            return LogicalDeleteSCMMrktPriSt(ref scmMrktPriStWork, 0);
        }

        /// <summary>
        /// 論理削除SCM相場価格設定マスタ情報を復活します
        /// </summary>
        /// <param name="scmMrktPriStWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除SCM相場価格設定マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int RevivalLogicalDelete(ref object scmMrktPriStWork)
        {
            return LogicalDeleteSCMMrktPriSt(ref scmMrktPriStWork, 1);
        }

        /// <summary>
        /// SCM相場価格設定マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="scmMrktPriStWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM相場価格設定マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        private int LogicalDeleteSCMMrktPriSt(ref object scmMrktPriStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(scmMrktPriStWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteSCMMrktPriStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SCMMrktPriStDB.LogicalDeleteSCMMrktPriSt :" + procModestr);

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
        /// SCM相場価格設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM相場価格設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int LogicalDeleteSCMMrktPriStProc(ref ArrayList scmMrktPriStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteSCMMrktPriStProcProc(ref scmMrktPriStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM相場価格設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM相場価格設定マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        private int LogicalDeleteSCMMrktPriStProcProc(ref ArrayList scmMrktPriStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (scmMrktPriStWorkList != null)
                {
                    for (int i = 0; i < scmMrktPriStWorkList.Count; i++)
                    {
                        SCMMrktPriStWork scmMrktPriStWork = scmMrktPriStWorkList[i] as SCMMrktPriStWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMMRKTPRISTRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != scmMrktPriStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE SCMMRKTPRISTRF  SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)scmMrktPriStWork;
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
                            else if (logicalDelCd == 0) scmMrktPriStWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else scmMrktPriStWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) scmMrktPriStWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(scmMrktPriStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(scmMrktPriStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(scmMrktPriStWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            scmMrktPriStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// SCM相場価格設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">SCM相場価格設定マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : SCM相場価格設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
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

                status = DeleteSCMMrktPriStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "SCMMrktPriStDB.Delete");
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
        /// SCM相場価格設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">SCM相場価格設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM相場価格設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        public int DeleteSCMMrktPriStProc(ArrayList scmMrktPriStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteSCMMrktPriStProcProc(scmMrktPriStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// SCM相場価格設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="scmMrktPriStWorkList">SCM相場価格設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : SCM相場価格設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        private int DeleteSCMMrktPriStProcProc(ArrayList scmMrktPriStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < scmMrktPriStWorkList.Count; i++)
                {
                    SCMMrktPriStWork scmMrktPriStWork = scmMrktPriStWorkList[i] as SCMMrktPriStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM SCMMRKTPRISTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != scmMrktPriStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM SCMMRKTPRISTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);
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
                {
                    if (myReader.IsClosed == false) myReader.Close();
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

	    #region [Where文作成処理]
	    /// <summary>
	    /// 検索条件文字列生成＋条件値設定
	    /// </summary>
	    /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="scmMrktPriStWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SCMMrktPriStWork scmMrktPriStWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.EnterpriseCode);

            //拠点コード
            if (string.IsNullOrEmpty(scmMrktPriStWork.SectionCode) == false)
            {
                retstring += "AND SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(scmMrktPriStWork.SectionCode);
            }
            
            //論理削除区分
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
			    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

		    return retstring;
		}
	    #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → StockMngTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        /// </remarks>
        private SCMMrktPriStWork CopyToSCMMrktPriStWorkFromReader(ref SqlDataReader myReader)
        {
            SCMMrktPriStWork wkSCMMrktPriStWork = new SCMMrktPriStWork();

            #region クラスへ格納
            wkSCMMrktPriStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkSCMMrktPriStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkSCMMrktPriStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkSCMMrktPriStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkSCMMrktPriStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkSCMMrktPriStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkSCMMrktPriStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkSCMMrktPriStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkSCMMrktPriStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
            wkSCMMrktPriStWork.MarketPriceAreaCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEAREACDRF"));  // 相場価格地域コード
            wkSCMMrktPriStWork.MarketPriceQualityCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEQUALITYCDRF"));  // 相場価格品質コード
            wkSCMMrktPriStWork.MarketPriceKindCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEKINDCD1RF"));  // 相場価格種別コード１
            wkSCMMrktPriStWork.MarketPriceKindCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEKINDCD2RF"));  // 相場価格種別コード２
            wkSCMMrktPriStWork.MarketPriceKindCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEKINDCD3RF"));  // 相場価格種別コード３
            wkSCMMrktPriStWork.MarketPriceAnswerDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEANSWERDIVRF"));  // 相場価格回答区分
            wkSCMMrktPriStWork.MarketPriceSalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MARKETPRICESALESRATERF"));  // 相場価格売価率
            wkSCMMrktPriStWork.AddPaymntAmbit1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT1RF"));  // 加算額範囲1
            wkSCMMrktPriStWork.AddPaymntAmbit2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT2RF"));  // 加算額範囲2
            wkSCMMrktPriStWork.AddPaymntAmbit3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT3RF"));  // 加算額範囲3
            wkSCMMrktPriStWork.AddPaymntAmbit4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT4RF"));  // 加算額範囲4
            wkSCMMrktPriStWork.AddPaymntAmbit5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT5RF"));  // 加算額範囲5
            wkSCMMrktPriStWork.AddPaymntAmbit6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT6RF"));  // 加算額範囲6
            wkSCMMrktPriStWork.AddPaymntAmbit7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT7RF"));  // 加算額範囲7
            wkSCMMrktPriStWork.AddPaymntAmbit8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT8RF"));  // 加算額範囲8
            wkSCMMrktPriStWork.AddPaymntAmbit9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT9RF"));  // 加算額範囲9
            wkSCMMrktPriStWork.AddPaymntAmbit10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNTAMBIT10RF"));  // 加算額範囲10
            wkSCMMrktPriStWork.AddPaymnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT1RF"));  // 加算額1
            wkSCMMrktPriStWork.AddPaymnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT2RF"));  // 加算額2
            wkSCMMrktPriStWork.AddPaymnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT3RF"));  // 加算額3
            wkSCMMrktPriStWork.AddPaymnt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT4RF"));  // 加算額4
            wkSCMMrktPriStWork.AddPaymnt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT5RF"));  // 加算額5
            wkSCMMrktPriStWork.AddPaymnt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT6RF"));  // 加算額6
            wkSCMMrktPriStWork.AddPaymnt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT7RF"));  // 加算額7
            wkSCMMrktPriStWork.AddPaymnt8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT8RF"));  // 加算額8
            wkSCMMrktPriStWork.AddPaymnt9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT9RF"));  // 加算額9
            wkSCMMrktPriStWork.AddPaymnt10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDPAYMNT10RF"));  // 加算額9
            wkSCMMrktPriStWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));  //端数処理区分
            // 2010/04/12 Add >>>
            wkSCMMrktPriStWork.MarketPriceQualityCd2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEQUALITYCD2RF"));  // 相場価格品質コード２
            wkSCMMrktPriStWork.MarketPriceQualityCd3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MARKETPRICEQUALITYCD3RF"));  // 相場価格品質コード３
            // 2010/04/12 Add <<<
            #endregion

            return wkSCMMrktPriStWork;
        }
        #endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            SCMMrktPriStWork[] SCMMrktPriStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is SCMMrktPriStWork)
                    {
                        SCMMrktPriStWork wkSCMMrktPriStWork = paraobj as SCMMrktPriStWork;
                        if (wkSCMMrktPriStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkSCMMrktPriStWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            SCMMrktPriStWorkArray = (SCMMrktPriStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(SCMMrktPriStWork[]));
                        }
                        catch (Exception) { }
                        if (SCMMrktPriStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(SCMMrktPriStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                SCMMrktPriStWork wkSCMMrktPriStWork = (SCMMrktPriStWork)XmlByteSerializer.Deserialize(byteArray, typeof(SCMMrktPriStWork));
                                if (wkSCMMrktPriStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkSCMMrktPriStWork);
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
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.08</br>
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

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
    /// キャンペーン関連マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン関連マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    [Serializable]
    public class CampaignLinkDB : RemoteDB, ICampaignLinkDB
    {
        /// <summary>
        /// キャンペーン関連マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public CampaignLinkDB()
            :
            base("PMKHN09576D", "Broadleaf.Application.Remoting.ParamData.CampaignLinkWork", "CAMPAIGNLINKRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// 指定された条件のキャンペーン関連マスタ情報LISTを戻します
        /// </summary>
        /// <param name="campaignLinkWork">検索結果</param>
        /// <param name="paracampaignLinkWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン関連マスタ情報LISTを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int Search(out object campaignLinkWork, object paracampaignLinkWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            campaignLinkWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchCampaignLinkProc(out campaignLinkWork, paracampaignLinkWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLinkDB.Search");
                campaignLinkWork = new ArrayList();
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
        /// 指定された条件のキャンペーン関連マスタ情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objcampaignLinkWork">検索結果</param>
        /// <param name="paracampaignLinkWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン関連マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int SearchCampaignLinkProc(out object objcampaignLinkWork, object paracampaignLinkWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            CampaignLinkWork campaignLinkWork = null; 

            ArrayList campaignLinkWorkList = paracampaignLinkWork as ArrayList;
            if (campaignLinkWorkList == null)
            {
                campaignLinkWork = paracampaignLinkWork as CampaignLinkWork;
            }
            else
            {
                if (campaignLinkWorkList.Count > 0)
                    campaignLinkWork = campaignLinkWorkList[0] as CampaignLinkWork;
            }

            int status = SearchCampaignLinkProc(out campaignLinkWorkList, campaignLinkWork, readMode, logicalMode, ref sqlConnection);
            objcampaignLinkWork = campaignLinkWorkList;
            return status;
        }

        /// <summary>
        /// 指定された条件のキャンペーン関連マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="campaignLinkWorkList">検索結果</param>
        /// <param name="campaignLinkWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン関連マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int SearchCampaignLinkProc(out ArrayList campaignLinkWorkList, CampaignLinkWork campaignLinkWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchCampaignLinkProcProc(out campaignLinkWorkList, campaignLinkWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// 指定された条件のキャンペーン関連マスタ情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">検索結果</param>
        /// <param name="stockmngttlstWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン関連マスタ情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        private int SearchCampaignLinkProcProc(out ArrayList campaignLinkWorkList, CampaignLinkWork campaignLinkWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;
                #region SELECT文
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,CAMPAIGNCODERF " + Environment.NewLine;
                selectTxt += "         ,CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,SALESAREACODERF " + Environment.NewLine;
                selectTxt += "         ,CUSTOMERAGENTCDRF " + Environment.NewLine;
                selectTxt += "         ,INFOSENDCODERF " + Environment.NewLine;
                selectTxt += "  FROM CAMPAIGNLINKRF " + Environment.NewLine;
                #endregion
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, campaignLinkWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToCampaignLinkWorkFromReader(ref myReader));

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

            campaignLinkWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件のキャンペーン関連マスタを戻します
        /// </summary>
        /// <param name="parabyte">CampaignLinkWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン関連マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                CampaignLinkWork campaignLinkWork = new CampaignLinkWork();

                // XMLの読み込み
                campaignLinkWork = (CampaignLinkWork)XmlByteSerializer.Deserialize(parabyte, typeof(CampaignLinkWork));
                if (campaignLinkWork == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref campaignLinkWork, readMode, ref sqlConnection,ref sqlTransaction);

                // XMLへ変換し、文字列のバイナリ化
                parabyte = XmlByteSerializer.Serialize(campaignLinkWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLinkDB.Read");
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
        /// 指定された条件のキャンペーン関連マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWork">CampaignLinkWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン関連マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int ReadProc(ref CampaignLinkWork campaignLinkWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref campaignLinkWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 指定された条件のキャンペーン関連マスタを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockmngttlstWork">CampaignLinkWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン関連マスタを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        private int ReadProcProc(ref CampaignLinkWork campaignLinkWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region　SELECT文
                selectTxt += " SELECT CREATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                selectTxt += "         ,ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                selectTxt += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                selectTxt += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                selectTxt += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                selectTxt += "         ,CAMPAIGNCODERF " + Environment.NewLine;
                selectTxt += "         ,CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "         ,SALESAREACODERF " + Environment.NewLine;
                selectTxt += "         ,CUSTOMERAGENTCDRF " + Environment.NewLine;
                selectTxt += "         ,INFOSENDCODERF " + Environment.NewLine;
                selectTxt += "  FROM CAMPAIGNLINKRF " + Environment.NewLine;
                selectTxt += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "         AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE " + Environment.NewLine;
                selectTxt += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                selectTxt += "         AND SALESAREACODERF = @FINDSALESAREACODE " + Environment.NewLine;
                selectTxt += "         AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD " + Environment.NewLine;
                #endregion

                //Selectコマンドの生成
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);  // キャンペーンコード
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // 得意先コード
                    SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);  // 販売エリアコード
                    SqlParameter findCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);  // 顧客担当従業員コード

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // 企業コード
                    findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // キャンペーンコード
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // 得意先コード
                    findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // 販売エリアコード
                    findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim(); // 顧客担当従業員コード

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        campaignLinkWork = CopyToCampaignLinkWorkFromReader(ref myReader);
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
        /// キャンペーン関連マスタ情報を登録、更新します
        /// </summary>
        /// <param name="stockmngttlstWork">CampaignLinkWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン関連マスタ情報を登録、更新します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int Write(ref object campaignLinkWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(campaignLinkWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteCampaignLinkProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                CampaignLinkWork paraWork = paraList[0] as CampaignLinkWork;
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //戻り値セット
                campaignLinkWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignLinkDB.Write(ref object campaignLinkWork)");
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
        /// キャンペーン関連マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン関連マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int WriteCampaignLinkProc(ref ArrayList campaignLinkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteCampaignLinkProcProc(ref campaignLinkWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// キャンペーン関連マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン関連マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        private int WriteCampaignLinkProcProc(ref ArrayList campaignLinkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (campaignLinkWorkList != null)
                {
                    foreach (CampaignLinkWork campaignLinkWork in campaignLinkWorkList)
                    {
                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM CAMPAIGNLINKRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND SALESAREACODERF = @FINDSALESAREACODE AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);  // キャンペーンコード
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // 得意先コード
                        SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);  // 販売エリアコード
                        SqlParameter findCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);  // 顧客担当従業員コード

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // 企業コード
                        findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // キャンペーンコード
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // 得意先コード
                        findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // 販売エリアコード
                        findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim();  // 顧客担当従業員コード

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != campaignLinkWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (campaignLinkWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 更新時のSQL文生成
                            string sqlText = string.Empty;
                            sqlText += " UPDATE CAMPAIGNLINKRF SET " + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF = @CREATEDATETIME " + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF = @UPDATEDATETIME " + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF = @FILEHEADERGUID " + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 " + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 " + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine;
                            sqlText += "  , CAMPAIGNCODERF = @CAMPAIGNCODE " + Environment.NewLine;
                            sqlText += "  , CUSTOMERCODERF = @CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "  , SALESAREACODERF = @SALESAREACODE " + Environment.NewLine;
                            sqlText += "  , CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD " + Environment.NewLine;
                            sqlText += "  , INFOSENDCODERF = @INFOSENDCODE " + Environment.NewLine;
                            sqlText += "  WHERE ENTERPRISECODERF = @FINDENTERPRISECODE " + Environment.NewLine;
                            sqlText += "         AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE " + Environment.NewLine;
                            sqlText += "         AND CUSTOMERCODERF = @FINDCUSTOMERCODE " + Environment.NewLine;
                            sqlText += "         AND SALESAREACODERF = @FINDSALESAREACODE " + Environment.NewLine;
                            sqlText += "         AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD " + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // 企業コード
                            findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // キャンペーンコード
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // 得意先コード
                            findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // 販売エリアコード
                            findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim(); // 顧客担当従業員コード


                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignLinkWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (campaignLinkWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region 新規作成時のSQL文を生成
                            string sqlText = string.Empty;
                            sqlText += " INSERT INTO CAMPAIGNLINKRF " + Environment.NewLine;
                            sqlText += "  (CREATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,UPDATEDATETIMERF " + Environment.NewLine;
                            sqlText += "         ,ENTERPRISECODERF " + Environment.NewLine;
                            sqlText += "         ,FILEHEADERGUIDRF " + Environment.NewLine;
                            sqlText += "         ,UPDEMPLOYEECODERF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID1RF " + Environment.NewLine;
                            sqlText += "         ,UPDASSEMBLYID2RF " + Environment.NewLine;
                            sqlText += "         ,LOGICALDELETECODERF " + Environment.NewLine;
                            sqlText += "         ,CAMPAIGNCODERF " + Environment.NewLine;
                            sqlText += "         ,CUSTOMERCODERF " + Environment.NewLine;
                            sqlText += "         ,SALESAREACODERF " + Environment.NewLine;
                            sqlText += "         ,CUSTOMERAGENTCDRF " + Environment.NewLine;
                            sqlText += "         ,INFOSENDCODERF " + Environment.NewLine;
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
                            sqlText += "         ,@CAMPAIGNCODE " + Environment.NewLine;
                            sqlText += "         ,@CUSTOMERCODE " + Environment.NewLine;
                            sqlText += "         ,@SALESAREACODE " + Environment.NewLine;
                            sqlText += "         ,@CUSTOMERAGENTCD " + Environment.NewLine;
                            sqlText += "         ,@INFOSENDCODE " + Environment.NewLine;
                            sqlText += "  ) " + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignLinkWork;
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
                        SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);  // キャンペーンコード
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // 得意先コード
                        SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);  // 販売エリアコード
                        SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);  // 顧客担当従業員コード
                        SqlParameter paraInfoSendCode = sqlCommand.Parameters.Add("@INFOSENDCODE", SqlDbType.Int);  // 情報送信区分
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(campaignLinkWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.LogicalDeleteCode);  // 論理削除区分
                        paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // キャンペーンコード
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // 得意先コード
                        paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // 販売エリアコード
                        paraCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim();  // 顧客担当従業員コード
                        paraInfoSendCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.InfoSendCode);  // 情報送信区分
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignLinkWork);
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

            campaignLinkWorkList = al;

            return status;
        }

        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// キャンペーン関連マスタ情報を論理削除します
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン関連マスタ情報を論理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int LogicalDelete(ref object campaignLinkWork)
        {
            return LogicalDeleteCampaignLink(ref campaignLinkWork, 0);
        }

        /// <summary>
        /// 論理削除キャンペーン関連マスタ情報を復活します
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除キャンペーン関連マスタ情報を復活します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int RevivalLogicalDelete(ref object campaignLinkWork)
        {
            return LogicalDeleteCampaignLink(ref campaignLinkWork, 1);
        }

        /// <summary>
        /// キャンペーン関連マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="stockmngttlstWork">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン関連マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        private int LogicalDeleteCampaignLink(ref object campaignLinkWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(campaignLinkWork);
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteCampaignLinkProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "CampaignLinkDB.LogicalDeleteCampaignLink :" + procModestr);

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
        /// キャンペーン関連マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン関連マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int LogicalDeleteCampaignLinkProc(ref ArrayList campaignLinkWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteCampaignLinkProcProc(ref campaignLinkWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// キャンペーン関連マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">StockMngTtlStWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : キャンペーン関連マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        private int LogicalDeleteCampaignLinkProcProc(ref ArrayList campaignLinkWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (campaignLinkWorkList != null)
                {
                    for (int i = 0; i < campaignLinkWorkList.Count; i++)
                    {
                        CampaignLinkWork campaignLinkWork = campaignLinkWorkList[i] as CampaignLinkWork;

                        //Selectコマンドの生成
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM CAMPAIGNLINKRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND SALESAREACODERF = @FINDSALESAREACODE AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD", sqlConnection, sqlTransaction);

                        //Prameterオブジェクトの作成
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);  // キャンペーンコード
                        SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // 得意先コード
                        SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);  // 販売エリアコード
                        SqlParameter findCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);  // 顧客担当従業員コード

                        //Parameterオブジェクトへ値設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // 企業コード
                        findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // キャンペーンコード
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // 得意先コード
                        findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // 販売エリアコード
                        findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim();  // 顧客担当従業員コード

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != campaignLinkWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE CAMPAIGNLINKRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND SALESAREACODERF = @FINDSALESAREACODE AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD";
                            //KEYコマンドを再設定
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // 企業コード
                            findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // キャンペーンコード
                            findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // 得意先コード
                            findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // 販売エリアコード
                            findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim(); // 顧客担当従業員コード

                            //更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)campaignLinkWork;
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
                            else if (logicalDelCd == 0) campaignLinkWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                            else campaignLinkWork.LogicalDeleteCode = 3;//完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1) campaignLinkWork.LogicalDeleteCode = 0;//論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(campaignLinkWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(campaignLinkWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(campaignLinkWork);
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

            campaignLinkWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// キャンペーン関連マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">キャンペーン関連マスタ情報オブジェクト</param>
        /// <returns></returns>
        /// <br>Note       : キャンペーン関連マスタ情報を物理削除します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
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

                status = DeleteCampaignLinkProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "CampaignLinkDB.Delete");
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
        /// キャンペーン関連マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">キャンペーン関連マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : キャンペーン関連マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        public int DeleteCampaignLinkProc(ArrayList campaignLinkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteCampaignLinkProcProc(campaignLinkWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// キャンペーン関連マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="stockmngttlstWorkList">キャンペーン関連マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : キャンペーン関連マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        private int DeleteCampaignLinkProcProc(ArrayList campaignLinkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                foreach (CampaignLinkWork campaignLinkWork in campaignLinkWorkList)
                {
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM CAMPAIGNLINKRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND SALESAREACODERF = @FINDSALESAREACODE AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                    SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);  // キャンペーンコード
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  // 得意先コード
                    SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);  // 販売エリアコード
                    SqlParameter findCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);  // 顧客担当従業員コード

                    //Parameterオブジェクトへ値設定
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // 企業コード
                    findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // キャンペーンコード
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // 得意先コード
                    findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // 販売エリアコード
                    findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim(); // 顧客担当従業員コード

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                        if (_updateDateTime != campaignLinkWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM CAMPAIGNLINKRF WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE AND CUSTOMERCODERF = @FINDCUSTOMERCODE AND SALESAREACODERF = @FINDSALESAREACODE AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTCD";
                        //KEYコマンドを再設定
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);  // 企業コード
                        findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  // キャンペーンコード
                        findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  // 得意先コード
                        findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);  // 販売エリアコード
                        findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim(); // 顧客担当従業員コード

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
	    /// <param name="stockmngttlstWork">検索条件格納クラス</param>
	    /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
	    /// <returns>Where条件文字列</returns>
	    /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.13</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignLinkWork campaignLinkWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //企業コード
		    retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(campaignLinkWork.EnterpriseCode);
           
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

            // キャンペーンコード
            if(campaignLinkWork.CampaignCode != 0)
            {
                retstring += "AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE ";
                SqlParameter findCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int); 
                findCampaignCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CampaignCode);  
            }

            // 得意先コード
            if(campaignLinkWork.CustomerCode != 0)
            {
                retstring += "AND CUSTOMERCODERF = @FINDCUSTOMERCODE ";
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);  
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.CustomerCode);  
            }

            // 販売エリアコード
            if(campaignLinkWork.SalesAreaCode != 0)
            {
                retstring += "AND SALESAREACODERF = @FINDSALESAREACODE ";
                SqlParameter findSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);  
                findSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(campaignLinkWork.SalesAreaCode);
            }
            
            // 顧客担当従業員コード
            if(string.IsNullOrEmpty(campaignLinkWork.CustomerAgentCd) == false)
            {
                retstring += "AND CUSTOMERAGENTCDRF = @FINDCUSTOMERAGENTC ";
                SqlParameter findCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);
                findCustomerAgentCd.Value = campaignLinkWork.CustomerAgentCd.Trim();
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
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private CampaignLinkWork CopyToCampaignLinkWorkFromReader(ref SqlDataReader myReader)
        {
            CampaignLinkWork wkCampaignLinkWork = new CampaignLinkWork();

            #region クラスへ格納
            wkCampaignLinkWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
            wkCampaignLinkWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
            wkCampaignLinkWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
            wkCampaignLinkWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
            wkCampaignLinkWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
            wkCampaignLinkWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
            wkCampaignLinkWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
            wkCampaignLinkWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
            wkCampaignLinkWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));  // キャンペーンコード
            wkCampaignLinkWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // 得意先コード
            wkCampaignLinkWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));  // 販売エリアコード
            wkCampaignLinkWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));  // 顧客担当従業員コード
            wkCampaignLinkWork.InfoSendCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INFOSENDCODERF")); // 情報送信区分
            #endregion

            return wkCampaignLinkWork;
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
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CampaignLinkWork[] CampaignLinkWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is CampaignLinkWork)
                    {
                        CampaignLinkWork wkCampaignLinkWork = paraobj as CampaignLinkWork;
                        if (wkCampaignLinkWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCampaignLinkWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CampaignLinkWorkArray = (CampaignLinkWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CampaignLinkWork[]));
                        }
                        catch (Exception) { }
                        if (CampaignLinkWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CampaignLinkWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CampaignLinkWork wkCampaignLinkWork = (CampaignLinkWork)XmlByteSerializer.Deserialize(byteArray, typeof(CampaignLinkWork));
                                if (wkCampaignLinkWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCampaignLinkWork);
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
        /// <br>Date       : 2009.05.13</br>
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

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
using System.Diagnostics;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ユーザーガイドDBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : ユーザーガイドの実データ操作を行うクラスです。</br>
	/// <br>Programmer : 21015　金巻　芳則</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    [Serializable]
    public class UserGdBdDB : RemoteDB, IUserGdBdDB
    {
        /// <summary>
        /// ユーザーガイドDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2005.03.24</br>
        /// </remarks>
        public UserGdBdDB()
            :
            base("SFTKD08044D", "Broadleaf.Application.Remoting.ParamData.UserGdBdWork", "USERGDBDURF")
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.WriteLine(this.ToString() + " Constructer");
        }

        #region ガイドヘッダー用メソッド
        /// <summary>
        /// ユーザーガイドヘッダーLISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定されたマスタののガイドLISTを全て戻します。</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2005.03.24</br>
        /// </remarks>
        public int SearchHeader(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            return SearchGuideHeaderProc(out retobj, paraobj, readMode, logicalMode);
        }

        /// <summary>
        /// ユーザーガイドヘッダーLISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定されたマスタののガイドLISTを全て戻します。</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2005.03.24</br>
        /// </remarks>
        private int SearchGuideHeaderProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            UserGdHdWork usergdhdWork = new UserGdHdWork();
            usergdhdWork = null;

            retobj = null;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                // XMLの読み込み
                usergdhdWork = paraobj as UserGdHdWork;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //データ読込
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDHDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDHDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDHDRF WHERE ORDER BY USERGUIDEDIVCDRF", sqlConnection);
                }

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (myReader.Read())
                {
                    UserGdHdWork wkUserGdHdWork = new UserGdHdWork();

                    wkUserGdHdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUserGdHdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUserGdHdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUserGdHdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    wkUserGdHdWork.UserGuideDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USERGUIDEDIVNMRF"));
                    wkUserGdHdWork.MasterOfferCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTEROFFERCDRF"));

                    al.Add(wkUserGdHdWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchGuideHeaderProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            retobj = al;

            return status;
        }

        #endregion

        #region ユーザーガイドマスタ(提供)
        /// <summary>
        /// ユーザーガイドボディ(提供分)LISTの件数を戻します
        /// </summary>
        /// <param name="retCnt">該当データ件数</param>
        /// <param name="parabyte">検索パラメータ(readMode=0:UserGdBdWorkクラス：企業コード)</param>		
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのユーザーガイドLISTの件数を戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2005.03.24</br>
        public int SearchCnt(out int retCnt, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

            UserGdBdWork usergdbdWork = null;

            retCnt = 0;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                // XMLの読み込み
                usergdbdWork = (UserGdBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(UserGdBdWork));

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                    //論理削除区分設定
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                    //論理削除区分設定
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF", sqlConnection);
                }

                //データリード
                retCnt = (int)sqlCommand.ExecuteScalar();
                if (retCnt > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchCnt:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// ユーザーガイドボディ(提供分)LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2005.03.24</br>
        public int SearchBody(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            retobj = null;
            return SearchUserGdBdProc(out retobj, out retTotalCnt, out nextData, paraobj, readMode, logicalMode, 0);
        }

        /// <summary>
        /// ユーザーガイドボディ(提供分)LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2005.03.24</br>
        public int SearchGuideDivCode(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            retobj = null;
            return SearchUserGdBdGuideDivCodeProc(out retobj, out retTotalCnt, out nextData, paraobj, readMode, logicalMode, 0);
        }

        /// <summary>
        /// ユーザーガイドボディ(提供分)LISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>		
        /// <param name="nextData">次データ有無</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2005.03.24</br>
        private int SearchUserGdBdProc(out object retobj, out int retTotalCnt, out bool nextData, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommandCount = null;
            SqlCommand sqlCommand = null;

            UserGdBdWork usergdbdWork = new UserGdBdWork();
            usergdbdWork = null;

            retobj = null;

            //総件数を0で初期化
            retTotalCnt = 0;

            //件数指定リードの場合には指定件数＋１件リードする
            int _readCnt = readCnt;
            if (_readCnt > 0) _readCnt += 1;
            //次レコード無しで初期化
            nextData = false;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                // XMLの読み込み
                usergdbdWork = paraobj as UserGdBdWork;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //件数指定リードで一件目リードの場合データ総件数を取得
                if ((readCnt > 0) && (usergdbdWork.UserGuideDivCd == 0) && (usergdbdWork.GuideCode == 0))
                {
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                        //論理削除区分設定
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                        //論理削除区分設定
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF", sqlConnection);
                    }

                    retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                }

                //データ読込
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                    }
                    else
                    {
                        //一件目リードの場合
                        if ((readCnt > 0) && (usergdbdWork.UserGuideDivCd == 0) && (usergdbdWork.GuideCode == 0))
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                        }
                        //Nextリードの場合
                        else
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                            SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                            SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

                            paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.UserGuideDivCd);
                            paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.GuideCode);
                        }
                    }
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                    }
                    else
                    {
                        //一件目リードの場合
                        if ((readCnt > 0) && (usergdbdWork.UserGuideDivCd == 0) && (usergdbdWork.GuideCode == 0))
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                        }
                        //Nextリードの場合
                        else
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                            SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                            SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

                            paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.UserGuideDivCd);
                            paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.GuideCode);
                        }
                    }
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    //件数指定無しの場合
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                    }
                    else
                    {
                        //一件目リードの場合
                        if ((readCnt > 0) && (usergdbdWork.UserGuideDivCd == 0) && (usergdbdWork.GuideCode == 0))
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                        }
                        else
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF WHERE  USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                            SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                            SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

                            paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.UserGuideDivCd);
                            paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.GuideCode);
                        }
                    }
                }

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int retCnt = 0;
                while (myReader.Read())
                {
                    //戻り値カウンタカウント
                    retCnt += 1;
                    if (readCnt > 0)
                    {
                        //戻り値の件数が取得指示件数を超えた場合終了
                        if (readCnt < retCnt)
                        {
                            nextData = true;
                            break;
                        }
                    }
                    UserGdBdWork wkUserGdBdWork = new UserGdBdWork();

                    wkUserGdBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUserGdBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUserGdBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUserGdBdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    wkUserGdBdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                    wkUserGdBdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                    wkUserGdBdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                    al.Add(wkUserGdBdWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchUserGdBdProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommandCount != null)
                {
                    sqlCommandCount.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            retobj = al;

            return status;

        }

        /// <summary>
        /// ユーザーガイドボディ(提供分)LISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="retTotalCnt">検索対象総件数</param>		
        /// <param name="nextData">次データ有無</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="readCnt">READ件数（0の場合はALL）</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2005.03.24</br>
        private int SearchUserGdBdGuideDivCodeProc(out object retobj, out int retTotalCnt, out bool nextData, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            UserGdBdWork usergdbdWork = new UserGdBdWork();
            usergdbdWork = null;

            retobj = null;

            //総件数を0で初期化
            retTotalCnt = 0;

            //件数指定リードの場合には指定件数＋１件リードする
            int _readCnt = readCnt;
            if (_readCnt > 0) _readCnt += 1;
            //次レコード無しで初期化
            nextData = false;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                // XMLの読み込み
                usergdbdWork = paraobj as UserGdBdWork;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //データ読込
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF " +
                        "WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                }

                SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.UserGuideDivCd);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int retCnt = 0;
                while (myReader.Read())
                {
                    //戻り値カウンタカウント
                    retCnt += 1;
                    if (readCnt > 0)
                    {
                        //戻り値の件数が取得指示件数を超えた場合終了
                        if (readCnt < retCnt)
                        {
                            nextData = true;
                            break;
                        }
                    }
                    UserGdBdWork wkUserGdBdWork = new UserGdBdWork();

                    wkUserGdBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUserGdBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUserGdBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUserGdBdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    wkUserGdBdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                    wkUserGdBdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                    wkUserGdBdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                    al.Add(wkUserGdBdWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchUserGdBdGuideDivCodeProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            retobj = al;

            return status;

        }

        /// <summary>
        /// ユーザーガイドボディ(提供分)LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retobject">検索結果</param>
        /// <param name="paraobject">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 21052 山田　圭</br>
        /// <br>Date       : 2005.03.24</br>
        public int SearchUserGdBdGuideDivCode(out object retobject, object paraobject, ConstantManagement.LogicalMode logicalMode)
        {
            ArrayList userGdBdWorkList = paraobject as ArrayList;
            return SearchUserGdBdGuideDivCodeProc(out retobject, userGdBdWorkList, logicalMode);
        }

        /// <summary>
        /// ユーザーガイドボディ(提供分)LISTを全て戻します
        /// </summary>
        /// <param name="retobject">検索結果</param>
        /// <param name="userGdBdWorkList">検索パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのユーザーガイドLISTを全て戻します</br>
        /// <br>Programmer : 21052 山田　圭</br>
        /// <br>Date       : 2005.03.24</br>
        private int SearchUserGdBdGuideDivCodeProc(out object retobject, ArrayList userGdBdWorkList, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            UserGdBdWork usergdbdWork = new UserGdBdWork();
            usergdbdWork = null;

            retobject = null;

            ArrayList al = new ArrayList();
            try
            {
                if ((userGdBdWorkList != null) && (userGdBdWorkList.Count > 0))
                {
                    string strsql = "";
                    for (int iCnt = 0; iCnt < userGdBdWorkList.Count; iCnt++)
                    {
                        if (iCnt == 0)
                        {
                            strsql = "SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
                        }
                        else
                        {
                            strsql = strsql + " UNION SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
                        }

                        //データ読込
                        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData3))
                        {
                            strsql = strsql + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                        }
                        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData012))
                        {
                            strsql = strsql + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                        }
                    }

                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                    if (connectionText == null || connectionText == "") return status;

                    //SQL文生成
                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    usergdbdWork = userGdBdWorkList[0] as UserGdBdWork;

                    //データ読込
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                    }

                    SqlParameter[] paraGuideDivCode = new SqlParameter[userGdBdWorkList.Count];
                    for (int iCnt = 0; iCnt < userGdBdWorkList.Count; iCnt++)
                    {
                        paraGuideDivCode[iCnt] = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD" + iCnt.ToString(), SqlDbType.Int);
                        paraGuideDivCode[iCnt].Value = SqlDataMediator.SqlSetInt32(((UserGdBdWork)userGdBdWorkList[iCnt]).UserGuideDivCd);
                    }

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    while (myReader.Read())
                    {
                        UserGdBdWork wkUserGdBdWork = new UserGdBdWork();

                        wkUserGdBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkUserGdBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkUserGdBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkUserGdBdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                        wkUserGdBdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                        wkUserGdBdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                        wkUserGdBdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                        al.Add(wkUserGdBdWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchUserGdBdGuideDivCodeProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            retobject = al;

            return status;

        }

        /// <summary>
        /// 指定されたキーのユーザーガイドボディ(提供分)を戻します
        /// </summary>
        /// <param name="parabyte">UserGdBdWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードのユーザーガイドを戻します</br>
        /// <br>Programmer : 21015　金巻　芳則</br>
        /// <br>Date       : 2005.03.24</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            UserGdBdWork usergdbdWork = new UserGdBdWork();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                // XMLの読み込み
                usergdbdWork = (UserGdBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(UserGdBdWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //Selectコマンドの生成
                sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE", sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.UserGuideDivCd);
                findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.GuideCode);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read())
                {
                    usergdbdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    usergdbdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    usergdbdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    usergdbdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    usergdbdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                    usergdbdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                    usergdbdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.Read:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            // XMLへ変換し、文字列のバイナリ化
            parabyte = XmlByteSerializer.Serialize(usergdbdWork);

            return status;
        }
        #endregion

        #region インターフェースで公開しないメソッド
        /// <summary>
        /// ユーザーガイドボディ(提供分)LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="userGdBdWorkList">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.12.28</br>
        public int Search(out ArrayList retList, UserGdBdWork[] userGdBdWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            UserGdBdWork usergdbdWork = null;

            retList = null;

            ArrayList al = new ArrayList();
            try
            {
                if ((userGdBdWorkList != null) && (userGdBdWorkList.Length > 0))
                {
                    string strsql = "";
                    for (int iCnt = 0; iCnt < userGdBdWorkList.Length; iCnt++)
                    {
                        if (iCnt == 0)
                        {
                            strsql = "SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
                        }
                        else
                        {
                            strsql = strsql + " UNION SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
                        }

                        //データ読込
                        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData3))
                        {
                            strsql = strsql + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                        }
                        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData012))
                        {
                            strsql = strsql + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                        }
                    }

                    usergdbdWork = userGdBdWorkList[0] as UserGdBdWork;

                    //データ読込
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                    }

                    SqlParameter[] paraGuideDivCode = new SqlParameter[userGdBdWorkList.Length];
                    for (int iCnt = 0; iCnt < userGdBdWorkList.Length; iCnt++)
                    {
                        paraGuideDivCode[iCnt] = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD" + iCnt.ToString(), SqlDbType.Int);
                        paraGuideDivCode[iCnt].Value = SqlDataMediator.SqlSetInt32(((UserGdBdWork)userGdBdWorkList[iCnt]).UserGuideDivCd);
                    }

                    UserGdBdWork wkUserGdBdWork = new UserGdBdWork();
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        wkUserGdBdWork = new UserGdBdWork();
                        wkUserGdBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkUserGdBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkUserGdBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkUserGdBdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                        wkUserGdBdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                        wkUserGdBdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                        wkUserGdBdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                        al.Add(wkUserGdBdWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchUserGdBdGuideDivCodeProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            retList = al;

            return status;
        }

        /// <summary>
        /// ユーザーガイドボディ(提供分)LISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="userGdBdWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21052　山田　圭</br>
        /// <br>Date       : 2005.12.28</br>
        public int Search(out ArrayList retList, UserGdBdWork userGdBdWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            retList = null;

            ArrayList al = new ArrayList();
            try
            {
                //データ読込
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                }

                UserGdBdWork wkUserGdBdWork = new UserGdBdWork();
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    wkUserGdBdWork = new UserGdBdWork();
                    wkUserGdBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUserGdBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUserGdBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUserGdBdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    wkUserGdBdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                    wkUserGdBdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                    wkUserGdBdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                    al.Add(wkUserGdBdWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.Search:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            retList = al;

            return status;
        }
        #endregion
    }
}

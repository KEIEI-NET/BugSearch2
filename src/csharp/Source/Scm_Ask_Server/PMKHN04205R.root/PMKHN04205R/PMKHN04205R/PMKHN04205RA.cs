//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 他社部品検索履歴照会 
// プログラム概要   : 他社部品検索履歴照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/19  修正内容 : Redmine#17394
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/24  修正内容 : Redmine#17451
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using System.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 他社部品検索履歴照会DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 他社部品検索履歴照会の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 朱 猛</br>
    /// <br>Date       : 2010/11/11</br>
    /// </remarks>
    public class ScmInqLogInquiryDB : RemoteDB, IScmInqLogInquiryDB
    {
        /// <summary>
        /// 他社部品検索履歴照会DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        public ScmInqLogInquiryDB()
        {

        }

        # region [Search]
        /// <summary>
        /// SCM問合せログテーブルのリストを取得します。
        /// </summary>
        /// <param name="outScmInqLogDBList">検索結果</param>
        /// <param name="scmInqLogInquirySearchPara">検索条件</param>
        /// <param name="readMode">検索区分</param>        /// <returns>STATUS</returns>
        /// <br>Note       : SCM問合せログテーブルを取得します。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        //public int Search(out object outScmInqLogDBList, ScmInqLogInquirySearchPara scmInqLogInquirySearchPara, int readMode) // DEL 2010/11/19
        public int Search(out object outScmInqLogDBList, ref object scmInqLogInquirySearchPara, int readMode) // ADD 2010/11/19
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            ArrayList _scmInqLogDBList = null;

            outScmInqLogDBList = new CustomSerializeArrayList();

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // 検索
                //status = this.SearchProc(out _scmInqLogDBList, scmInqLogInquirySearchPara, readMode, ref sqlConnection); // DEL 2010/11/19
                status = this.SearchProc(out _scmInqLogDBList, ref scmInqLogInquirySearchPara, readMode, ref sqlConnection); // ADD 2010/11/19

                if (_scmInqLogDBList != null)
                {
                    (outScmInqLogDBList as CustomSerializeArrayList).AddRange(_scmInqLogDBList);
                }

            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "ScmInqLogInquiryDB.Search", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ScmInqLogInquiryDB.Search", status);
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
        /// SCM問合せログテーブルのリストを取得します。
        /// </summary>
        /// <param name="scmInqLogDBList">検索結果</param>
        /// <param name="scmInqLogInquirySearchPara">検索条件</param>
        /// <param name="readMode">検索区分</param>        
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM問合せログテーブルのリストを取得します。</br>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        //private int SearchProc(out ArrayList scmInqLogDBList, ScmInqLogInquirySearchPara scmInqLogInquirySearchPara, int readMode, ref SqlConnection sqlConnection) // DEL 2010/11/19
        private int SearchProc(out ArrayList scmInqLogDBList, ref object scmInqLogInquirySearchPara, int readMode, ref SqlConnection sqlConnection) // ADD 2010/11/19
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                StringBuilder sqlText = new StringBuilder();
                // コネクション生成
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Selectコマンドの生成
                //sqlText.Append(" SELECT CREATEDATETIMERF, CNECTORIGINALEPNMRF, INQDATAINPUTSYSTEMRF, SCMINQCONTENTSRF FROM SCMINQLOGRF WITH (READUNCOMMITTED) WHERE CREATEDATETIMERF>=@FINDPARABEGINDATETIME AND CREATEDATETIMERF<=@FINDPARAENDDATETIME AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND CNECTOTHEREPCDRF=@FINDCNECTOTHEREPCD ORDER BY CREATEDATETIMERF ASC");        // SCM問合せログテーブル // DEL 2010/11/24
                sqlText.Append(" SELECT TOP (@MAXSEARCHCT) CREATEDATETIMERF, CNECTORIGINALEPNMRF, INQDATAINPUTSYSTEMRF, SCMINQCONTENTSRF FROM SCMINQLOGRF WITH (READUNCOMMITTED) WHERE CREATEDATETIMERF>=@FINDPARABEGINDATETIME AND CREATEDATETIMERF<=@FINDPARAENDDATETIME AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND CNECTOTHEREPCDRF=@FINDCNECTOTHEREPCD ORDER BY CREATEDATETIMERF ASC");        // SCM問合せログテーブル // ADD 2010/11/24
                sqlCommand.CommandText += sqlText.ToString();

                //Prameterオブジェクトの作成
                SqlParameter findParaMaxSearchCt = sqlCommand.Parameters.Add("@MAXSEARCHCT", SqlDbType.Int); // ADD 2010/11/24
                SqlParameter findParaBeginDateTime = sqlCommand.Parameters.Add("@FINDPARABEGINDATETIME", SqlDbType.BigInt);
                SqlParameter findParaEndDateTime = sqlCommand.Parameters.Add("@FINDPARAENDDATETIME", SqlDbType.BigInt);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findParaCnectOtherEpCd = sqlCommand.Parameters.Add("@FINDCNECTOTHEREPCD", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                // ---UPD 2010/11/19 -------------------------->>>
                //findParaBeginDateTime.Value = beginningTime;
                //findParaEndDateTime.Value = endingTime;
                //findParaLogicalDeleteCode.Value = 0;
                //findParaCnectOtherEpCd.Value = enterpriseCode;

                findParaMaxSearchCt.Value = ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).MaxSearchCt; // ADD 2010/11/24
                findParaBeginDateTime.Value = ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).BeginDateTime;
                findParaEndDateTime.Value = ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).EndDateTime;
                findParaLogicalDeleteCode.Value = ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).LogicalDeleteCode;
                findParaCnectOtherEpCd.Value = ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).CnectOtherEpCd;
                // ---UPD 2010/11/19 --------------------------<<<

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    // ---UPD 2010/11/19 -------------------------->>>
                    //al.Add(this.CopyToScmInqLogWorkFromReader(ref myReader));
                    //if (al.Count < ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).MaxSearchCt) // DEL 2010/11/24
                    if (al.Count < ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).MaxSearchCt - 1) // ADD 2010/11/24
                    {
                        al.Add(this.CopyToScmInqLogWorkFromReader(ref myReader));
                    }
                    else
                    {
                        ((ScmInqLogInquirySearchPara)scmInqLogInquirySearchPara).SearchOverFlg = true;
                        break;
                    }
                    // ---UPD 2010/11/19 --------------------------<<<
                    
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
                status = base.WriteSQLErrorLog(sqlex, "ScmInqLogInquiryDB.SearchProc", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "ScmInqLogInquiryDB.SearchProc", status);
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

            scmInqLogDBList = al;

            return status;

        }

        # endregion

        # region [クラス格納処理]

        /// <summary>
        /// クラス格納処理 Reader → ScmInqLogWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>ScmInqLogWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        private ScmInqLogInquiryWork CopyToScmInqLogWorkFromReader(ref SqlDataReader myReader)
        {
            ScmInqLogInquiryWork scmInqLogWork = new ScmInqLogInquiryWork();

            # region クラスへ格納
            // ---UPD 2010/11/19 -------------------------->>>
            //scmInqLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            ////scmInqLogWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            ////scmInqLogWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            ////scmInqLogWork.CnectOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTORIGINALEPCDRF"));
            //scmInqLogWork.CnectOriginalEpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTORIGINALEPNMRF"));
            ////scmInqLogWork.CnectOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTOTHEREPCDRF"));
            ////scmInqLogWork.CnectOtherEpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTOTHEREPNMRF"));
            //scmInqLogWork.InqDataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQDATAINPUTSYSTEMRF"));
            ////scmInqLogWork.LogDataGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("LOGDATAGUIDRF"));
            //scmInqLogWork.ScmInqContents = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMINQCONTENTSRF"));
            ////scmInqLogWork.AnswerPartsCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERPARTSCNTRF"));

            scmInqLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            scmInqLogWork.CnectOriginalEpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CNECTORIGINALEPNMRF"));
            scmInqLogWork.InqDataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INQDATAINPUTSYSTEMRF"));
            scmInqLogWork.ScmInqContents = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SCMINQCONTENTSRF"));
            // ---UPD 2010/11/19 --------------------------<<<
            # endregion

            return scmInqLogWork;
        }
        # endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 朱 猛</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_NS_DB);

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
        # endregion
    }
}

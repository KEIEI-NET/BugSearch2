using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

//using System.IO;  //TEST用
//using System.Windows.Forms;  //TEST用

namespace Broadleaf.Application.Control
{
	/// <summary>
	/// 変更PG案内DBアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 各マスタへのアクセス&リモートを行います。</br>
	/// <br>Programmer : 30025  山﨑　元輝</br>
	/// <br>Date       : 2007.03.06</br>
	/// <br>Update     : 2007.12.10  Kouguchi  新レイアウト対応</br>
    /// <br>           :                ・プログラム配信案内マスタ　　　　→　更案内マスタ　へ変更</br>
    /// <br>           :                ・プログラム配信案内明細マスタ　　→　変更案内明細マスタ　へ変更</br>
    /// <br>           :                ・サーバーメンテナンス情報マスタ　→　変更案内マスタ　へ統合</br>
	/// <br>           : 2008.02.20  Kouguchi  条件項目追加</br>
	/// </remarks>
    public class ChangePgGuideDBAcs
    {

        #region コンストラクタ
        public ChangePgGuideDBAcs()
        {
        }
        #endregion



        #region Del  2007.12.10  Kouguchi

        //#region サーバーメンテナンス情報マスタ

        //#region SearchSvrMntInf(out List<SvrMntInfoWork> svrMntInfoWorklist, SvrMntInfoWork svrMntInfoWork, int stNumber, int count, out int maxCount, out string errMessage)
        ///// <summary>
        ///// サーバーメンテナンス情報マスタLISTを全て戻します
        ///// </summary>
        ///// <param name="svrMntInfoWorklist">検索結果</param>
        ///// <param name="svrMntInfoWork">検索パラメータ</param>
        ///// <param name="stNumber">開始番号</param>
        ///// <param name="count">件数</param>
        ///// <param name="errMessage">エラーメッセージ</param>
        ///// <returns>status</returns>
        ///// <br>Note       : 指定されたパッケージ区分、サーバーメンテナンス区分のサーバーメンテナンス情報マスタを全て戻します</br>
        ///// <br>Programmer : 30025　山﨑　元輝</br>
        ///// <br>Date       : 2007.03.07</br>
        //public int SearchSvrMntInf(out List<SvrMntInfoWork> svrMntInfoWorklist, SvrMntInfoWork svrMntInfoWork, int stNumber, int count, out int maxCount, out string errMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlConnection sqlConnection = null;
        //    SqlCommand sqlCommand = null;
        //    SqlDataReader myReader = null;
        //    svrMntInfoWorklist = new List<SvrMntInfoWork>();
        //    maxCount = 0;
        //    errMessage = "";
        //    ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();
        //    if ((svrMntInfoWork.ProductCode == null) || (svrMntInfoWork.ServerMainteDivCd == null))
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //        return status;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            //変更ＰＧ案内用の接続文字列取得
        //            ChangePgGuideSqlInfo changePgGuideSqlInfo = new ChangePgGuideSqlInfo();
        //            string connectionText = changePgGuideSqlInfo.GetConnectionText();//(ConstantManagement_SF_PRO.IndexCode_OfferDB);
        //            if (connectionText == null || connectionText == "") return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //            //コネクションオープン
        //            sqlConnection = new SqlConnection(connectionText);
        //            sqlConnection.Open();

        //            sqlCommand = new SqlCommand(" SELECT COUNT (*) FROM SVRMNTINFORF WHERE PRODUCTCODERF=@FINDPRODUCTCODE ", sqlConnection);//AND SERVERMAINTEDIVCD=@FINDSERVERMAINTEDIVCD ", sqlConnection);
        //            if ((svrMntInfoWork.ServerMainteDivCd != null) && (svrMntInfoWork.ServerMainteDivCd != -1))
        //            {
        //                sqlCommand.CommandText += "AND SERVERMAINTEDIVCDRF=@FINDSERVERMAINTEDIVCD";
        //                SqlParameter findParaServerMainteDivCd = sqlCommand.Parameters.Add("@FINDSERVERMAINTEDIVCD", SqlDbType.Int);
        //                findParaServerMainteDivCd.Value = SqlDataMediator.SqlSetInt32(svrMntInfoWork.ServerMainteDivCd);
        //            }

        //            SqlParameter findParaProductCode = sqlCommand.Parameters.Add("@FINDPRODUCTCODE", SqlDbType.NVarChar);
        //            findParaProductCode.Value = SqlDataMediator.SqlSetString(svrMntInfoWork.ProductCode);
        //            //データリード
        //            maxCount = (int)sqlCommand.ExecuteScalar();

        //            //SQL文生成
        //            //if (count == 0)
        //            //{
        //            //    sqlCommand = new SqlCommand(" SELECT * FROM SVRMNTINFORF "
        //            //        + " WHERE PRODUCTCODERF=@FINDPRODUCTCODE AND SERVERMAINTEDIVCD=@FINDSERVERMAINTEDIVCD ", sqlConnection);
        //            //}
        //            if (count > 0)
        //            {
        //                if (svrMntInfoWork.ServerMainteDivCd == -1)
        //                {
        //                    sqlCommand = new SqlCommand(" SELECT TOP " + count.ToString() + " * "
        //                        + " FROM SVRMNTINFORF WHERE PRODUCTCODERF=@FINDPRODUCTCODE "
        //                        + " AND NOT EXISTS "
        //                        + " (SELECT * FROM (SELECT TOP " + stNumber.ToString() + " * FROM SVRMNTINFORF "
        //                        + " WHERE PRODUCTCODERF=@FINDPRODUCTCODE ORDER BY PRODUCTCODERF,SERVERMAINTECONSNORF) "
        //                        + " AS SVRMNTINFOEF2 "
        //                        + " WHERE SVRMNTINFORF.PRODUCTCODERF=SVRMNTINFOEF2.PRODUCTCODERF AND SVRMNTINFORF.SERVERMAINTECONSNORF=SVRMNTINFOEF2.SERVERMAINTECONSNORF) "
        //                        + " ORDER BY SVRMNTINFORF.PRODUCTCODERF, SVRMNTINFORF.SERVERMAINTECONSNORF DESC", sqlConnection);
        //                }
        //                else
        //                {
        //                    sqlCommand = new SqlCommand(" SELECT TOP " + count.ToString() + " * "
        //                        + " FROM SVRMNTINFORF WHERE PRODUCTCODERF=@FINDPRODUCTCODE AND SERVERMAINTEDIVCDRF=@FINDSERVERMAINTEDIVCD "
        //                        + " AND NOT EXISTS "
        //                        + " (SELECT * FROM (SELECT TOP " + stNumber.ToString() + " * FROM SVRMNTINFORF "
        //                        + " WHERE PRODUCTCODERF=@FINDPRODUCTCODE AND SERVERMAINTEDIVCDRF=@FINDSERVERMAINTEDIVCD ORDER BY PRODUCTCODERF,SERVERMAINTECONSNORF) "
        //                        + " AS SVRMNTINFOEF2 "
        //                        + " WHERE SVRMNTINFORF.PRODUCTCODERF=SVRMNTINFOEF2.PRODUCTCODERF AND SVRMNTINFORF.SERVERMAINTECONSNORF=SVRMNTINFOEF2.SERVERMAINTECONSNORF) "
        //                        + " ORDER BY SVRMNTINFORF.PRODUCTCODERF, SVRMNTINFORF.SERVERMAINTECONSNORF DESC", sqlConnection);
        //                }
        //            }

        //            //Prameterオブジェクトの作成
        //            SqlParameter findParaProductCode2 = sqlCommand.Parameters.Add("@FINDPRODUCTCODE", SqlDbType.NVarChar);
        //            SqlParameter findParaServerMainteDivCd2 = sqlCommand.Parameters.Add("@FINDSERVERMAINTEDIVCD", SqlDbType.Int);

        //            //Parameterオブジェクトへ値設定
        //            findParaProductCode2.Value = SqlDataMediator.SqlSetString(svrMntInfoWork.ProductCode);
        //            findParaServerMainteDivCd2.Value = SqlDataMediator.SqlSetInt32(svrMntInfoWork.ServerMainteDivCd);

        //            myReader = sqlCommand.ExecuteReader();
        //            while (myReader.Read())
        //            {
        //                svrMntInfoWork = new SvrMntInfoWork();

        //                svrMntInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //                svrMntInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                svrMntInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //                svrMntInfoWork.ProductCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCTCODERF"));
        //                svrMntInfoWork.ServerMainteConsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SERVERMAINTECONSNORF"));
        //                svrMntInfoWork.ServerMainteDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SERVERMAINTEDIVCDRF"));
        //                svrMntInfoWork.ServerMainteStScdl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERVERMAINTESTSCDLRF"));
        //                svrMntInfoWork.ServerMainteEdScdl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERVERMAINTEEDSCDLRF"));
        //                svrMntInfoWork.ServerMainteStTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERVERMAINTESTTIMERF"));
        //                svrMntInfoWork.ServerMainteEdTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERVERMAINTEEDTIMERF"));
        //                svrMntInfoWork.ServerMainteCntnts = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERVERMAINTECNTNTSRF"));
        //                svrMntInfoWork.ServerMainteGidnc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERVERMAINTEGIDNCRF"));

        //                svrMntInfoWorklist.Add(svrMntInfoWork);

        //                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            changePgGuideLogOutPut.WriteLog(ChangePgGuideLogOutPut.MessageLevel.Error, ex);
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            errMessage = ex.ToString();
        //        }
        //        catch (Exception e)
        //        {
        //            changePgGuideLogOutPut.WriteLog(ChangePgGuideLogOutPut.MessageLevel.Error, e);
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            errMessage = e.ToString();
        //        }
        //        finally
        //        {
        //            if ((myReader != null) && (!myReader.IsClosed)) myReader.Close();
        //            if (sqlCommand != null) sqlCommand.Dispose();
        //            if (sqlConnection != null)
        //            {
        //                sqlConnection.Close();
        //            }
        //        }
        //    }
        //    return status;
        //}
        //#endregion

        //#region ReadSvrMntInf(ref SvrMntInfoWork svrMntInfoWork, out string errMessage)//(ref List<SvrMntInfoWork> svrMntInfoWorklist, out string errMessage)
        ///// <summary>
        ///// 指定されたパッケージ区分、サーバーメンテナンス連番のサーバーメンテナンス情報マスタを戻します
        ///// </summary>
        ///// <param name="SvrMntInfoWorklist">SvrMntInfoWorkオブジェクト</param>
        ///// <param name="errMessage">エラーメッセージ</param>
        ///// <returns>status</returns>
        ///// <br>Note       : 指定された企業コードのサーバーメンテナンス情報マスタを全て戻します</br>
        ///// <br>Programmer : 30025　山﨑　元輝</br>
        ///// <br>Date       : 2007.03.07</br>
        //public int ReadSvrMntInf(SvrMntInfoWork parasvrMntInfoWork, out SvrMntInfoWork retsvrMntInfoWork, out string errMessage)//(ref List<SvrMntInfoWork> svrMntInfoWorklist, out string errMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //    SqlConnection sqlConnection = null;
        //    SqlDataReader myReader = null;
        //    retsvrMntInfoWork = new SvrMntInfoWork();
        //    //SvrMntInfoWork _svrMntInfoWork = new SvrMntInfoWork();
        //    //SvrMntInfoWork wksvrMntInfoWork = new SvrMntInfoWork();
        //    errMessage = "";
        //    ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

        //    if ((parasvrMntInfoWork.ProductCode == null) || (parasvrMntInfoWork.ServerMainteConsNo == null))
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
        //        return status;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            //ジェネリックリストからデータクラスへ変換
        //            //_svrMntInfoWork = svrMntInfoWorklist as SvrMntInfoWork;
        //            //変更ＰＧ案内用の接続文字列取得
        //            ChangePgGuideSqlInfo changePgGuideSqlInfo = new ChangePgGuideSqlInfo();
        //            string connectionText = changePgGuideSqlInfo.GetConnectionText();//(ConstantManagement_SF_PRO.IndexCode_OfferDB);
        //            if (connectionText == null || connectionText == "") return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //            //コネクションオープン
        //            sqlConnection = new SqlConnection(connectionText);
        //            sqlConnection.Open();

        //            //Selectコマンドの生成
        //            using (SqlCommand sqlCommand = new SqlCommand(" SELECT * FROM SVRMNTINFORF "
        //                + " WHERE PRODUCTCODERF=@FINDPRODUCTCODE AND SERVERMAINTECONSNORF=@FINDSERVERMAINTECONSNO ", sqlConnection))
        //            {
        //                //Prameterオブジェクトの作成
        //                SqlParameter findParaProductCode = sqlCommand.Parameters.Add("@FINDPRODUCTCODE", SqlDbType.NVarChar);
        //                SqlParameter findParaServerMainteConsNo = sqlCommand.Parameters.Add("@FINDSERVERMAINTECONSNO", SqlDbType.Int);

        //                //Parameterオブジェクトへ値設定
        //                findParaProductCode.Value = SqlDataMediator.SqlSetString(parasvrMntInfoWork.ProductCode);
        //                findParaServerMainteConsNo.Value = SqlDataMediator.SqlSetInt32(parasvrMntInfoWork.ServerMainteConsNo);

        //                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        //                if (myReader.Read())
        //                {
        //                    retsvrMntInfoWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //                    retsvrMntInfoWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //                    retsvrMntInfoWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //                    retsvrMntInfoWork.ProductCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCTCODERF"));
        //                    retsvrMntInfoWork.ServerMainteConsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SERVERMAINTECONSNORF"));
        //                    retsvrMntInfoWork.ServerMainteDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SERVERMAINTEDIVCDRF"));
        //                    retsvrMntInfoWork.ServerMainteStScdl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERVERMAINTESTSCDLRF"));
        //                    retsvrMntInfoWork.ServerMainteEdScdl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERVERMAINTEEDSCDLRF"));
        //                    retsvrMntInfoWork.ServerMainteStTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERVERMAINTESTTIMERF"));
        //                    retsvrMntInfoWork.ServerMainteEdTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SERVERMAINTEEDTIMERF"));
        //                    retsvrMntInfoWork.ServerMainteCntnts = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERVERMAINTECNTNTSRF"));
        //                    retsvrMntInfoWork.ServerMainteGidnc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SERVERMAINTEGIDNCRF"));

        //                    //svrMntInfoWorklist = new List<SvrMntInfoWork>();
        //                    //svrMntInfoWorklist.Add(wksvrMntInfoWork);

        //                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //                }
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            changePgGuideLogOutPut.WriteLog(ChangePgGuideLogOutPut.MessageLevel.Error, ex);
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            errMessage = ex.ToString();
        //        }
        //        catch (Exception e)
        //        {
        //            changePgGuideLogOutPut.WriteLog(ChangePgGuideLogOutPut.MessageLevel.Error, e);
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            errMessage = e.ToString();
        //        }
        //        finally
        //        {
        //            if ((myReader != null) && (!myReader.IsClosed)) myReader.Close();
        //            if (sqlConnection != null)
        //            {
        //                sqlConnection.Close();
        //            }
        //        }
        //    }
        //    return status;
        //}
        //#endregion

        //#region WriteSvrMntInf(ref SvrMntInfoWork svrMntInfoWork, out string errMessage)
        ///// <summary>
        ///// サーバーメンテナンス情報マスタ情報を登録・更新します
        ///// </summary>
        ///// <param name="svrMntInfoWork">SvrMntInfoWorkオブジェクト</param>
        ///// <param name="errMessage">エラーメッセージ</param>
        ///// <returns>status</returns>
        ///// <br>Note       : サーバーメンテナンス情報マスタ情報を登録、更新します</br>
        ///// <br>Programmer : 30025　山﨑　元輝</br>
        ///// <br>Date       : 2007.03.07</br>
        //public int WriteSvrMntInf(ref SvrMntInfoWork svrMntInfoWork, out string errMessage)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    SqlConnection sqlConnection = null;
        //    SqlCommand sqlCommand = null;
        //    SqlDataReader myReader = null;
        //    errMessage = "";

        //    try
        //    {
        //        //変更ＰＧ案内用の接続文字列取得
        //        ChangePgGuideSqlInfo changePgGuideSqlInfo = new ChangePgGuideSqlInfo();
        //        string connectionText = changePgGuideSqlInfo.GetConnectionText();//(ConstantManagement_SF_PRO.IndexCode_OfferDB);
        //        if (connectionText == null || connectionText == "") return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
        //        //コネクションオープン
        //        sqlConnection = new SqlConnection(connectionText);
        //        sqlConnection.Open();

        //        sqlCommand = new SqlCommand();
        //        sqlCommand.Connection = sqlConnection;

        //        // 論理削除区分を更新して排他ロックをかけます
        //        // ロックのタイムアウトを0秒に指定して、別トランザクションで排他ロックが掛かっていればすぐにタイムアウトするようにします。
        //        sqlCommand.CommandText = "SET LOCK_TIMEOUT 0 UPDATE SVRMNTINFORF SET LOGICALDELETECODERF=0 "
        //        + " WHERE PRODUCTCODERF=@FINDPRODUCTCODE AND SERVERMAINTECONSNORF=@FINDSERVERMAINTECONSNO ";

        //        //Prameterオブジェクトの作成
        //        SqlParameter findParaProductCode = sqlCommand.Parameters.Add("@FINDPRODUCTCODE", SqlDbType.NVarChar);
        //        SqlParameter findParaServerMainteConsNo = sqlCommand.Parameters.Add("@FINDSERVERMAINTECONSNO", SqlDbType.Int);

        //        //Parameterオブジェクトへ値設定
        //        findParaProductCode.Value = SqlDataMediator.SqlSetString(svrMntInfoWork.ProductCode);
        //        findParaServerMainteConsNo.Value = SqlDataMediator.SqlSetInt32(svrMntInfoWork.ServerMainteConsNo);

        //        //UPDATE LOCKをかける
        //        sqlCommand.ExecuteNonQuery();

        //        sqlCommand.CommandText = " SELECT * FROM SVRMNTINFORF "
        //                + " WHERE PRODUCTCODERF=@FINDPRODUCTCODE AND SERVERMAINTECONSNORF=@FINDSERVERMAINTECONSNO ";

        //        myReader = sqlCommand.ExecuteReader();
        //        if (myReader.Read())
        //        {
        //            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //            if (_updateDateTime != svrMntInfoWork.UpdateDateTime)
        //            {
        //                //新規登録で該当データ有りの場合には重複
        //                if (svrMntInfoWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
        //                //既存データで更新日時違いの場合には排他
        //                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                sqlCommand.Cancel();
        //                if (!myReader.IsClosed) myReader.Close();
        //                return status;
        //            }

        //            sqlCommand.CommandText = " UPDATE SVRMNTINFORF SET "
        //            + " CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , LOGICALDELETECODERF=@LOGICALDELETECODE ,"
        //            + " PRODUCTCODERF=@PRODUCTCODE , SERVERMAINTECONSNORF=@SERVERMAINTECONSNO , SERVERMAINTEDIVCDRF=@SERVERMAINTEDIVCD ,"
        //            + " SERVERMAINTESTSCDLRF=@SERVERMAINTESTSCDL , SERVERMAINTEEDSCDLRF=@SERVERMAINTEEDSCDL , SERVERMAINTESTTIMERF=@SERVERMAINTESTTIME ,"
        //            + " SERVERMAINTEEDTIMERF=@SERVERMAINTEEDTIME , SERVERMAINTECNTNTSRF=@SERVERMAINTECNTNTS , SERVERMAINTEGIDNCRF=@SERVERMAINTEGIDNC "
        //            + " WHERE PRODUCTCODERF=@FINDPRODUCTCODE AND SERVERMAINTECONSNORF=@FINDSERVERMAINTECONSNO ";

        //            //更新ヘッダ情報を設定
        //            //object obj = (object)this;
        //            //IFileHeader flhd = (IFileHeader)svrMntInfoWork;
        //            //FileHeader fileHeader = new FileHeader(obj);
        //            //fileHeader.SetUpdateHeader(ref flhd, obj);
        //            svrMntInfoWork.UpdateDateTime = TDateTime.GetSFDateNow();
        //        }
        //        else
        //        {
        //            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
        //            if (svrMntInfoWork.UpdateDateTime > DateTime.MinValue)
        //            {
        //                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
        //                sqlCommand.Cancel();
        //                if (!myReader.IsClosed) myReader.Close();
        //                return status;
        //            }

        //            //新規作成時のSQL文を生成
        //            sqlCommand.CommandText = " INSERT INTO SVRMNTINFORF "
        //                + " (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, PRODUCTCODERF, SERVERMAINTECONSNORF, SERVERMAINTEDIVCDRF, "
        //                + " SERVERMAINTESTSCDLRF, SERVERMAINTEEDSCDLRF, SERVERMAINTESTTIMERF, SERVERMAINTEEDTIMERF, SERVERMAINTECNTNTSRF, SERVERMAINTEGIDNCRF) "
        //                + " VALUES "
        //                + " (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @PRODUCTCODE, @SERVERMAINTECONSNO, @SERVERMAINTEDIVCD, "
        //                + " @SERVERMAINTESTSCDL, @SERVERMAINTEEDSCDL, @SERVERMAINTESTTIME, @SERVERMAINTEEDTIME, @SERVERMAINTECNTNTS, @SERVERMAINTEGIDNC) ";

        //            //登録ヘッダ情報を設定
        //            //object obj = (object)this;
        //            //IFileHeader flhd = (IFileHeader)svrMntInfoWork;
        //            //FileHeader fileHeader = new FileHeader(obj);
        //            //fileHeader.SetInsertHeader(ref flhd, obj);
        //            svrMntInfoWork.CreateDateTime = TDateTime.GetSFDateNow();
        //            svrMntInfoWork.UpdateDateTime = TDateTime.GetSFDateNow();
        //        }
        //        if (!myReader.IsClosed) myReader.Close();

        //        //Prameterオブジェクトの作成
        //        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
        //        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
        //        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
        //        SqlParameter paraProductCode = sqlCommand.Parameters.Add("@PRODUCTCODE", SqlDbType.NVarChar);
        //        SqlParameter paraServerMainteConsNo = sqlCommand.Parameters.Add("@SERVERMAINTECONSNO", SqlDbType.Int);
        //        SqlParameter paraServerMainteDivCd = sqlCommand.Parameters.Add("@SERVERMAINTEDIVCD", SqlDbType.Int);
        //        SqlParameter paraServerMainteStScdl = sqlCommand.Parameters.Add("@SERVERMAINTESTSCDL", SqlDbType.BigInt);
        //        SqlParameter paraServerMainteEdScdl = sqlCommand.Parameters.Add("@SERVERMAINTEEDSCDL", SqlDbType.BigInt);
        //        SqlParameter paraServerMainteStTime = sqlCommand.Parameters.Add("@SERVERMAINTESTTIME", SqlDbType.BigInt);
        //        SqlParameter paraServerMainteEdTime = sqlCommand.Parameters.Add("@SERVERMAINTEEDTIME", SqlDbType.BigInt);
        //        SqlParameter paraServerMainteCntnts = sqlCommand.Parameters.Add("@SERVERMAINTECNTNTS", SqlDbType.NVarChar);
        //        SqlParameter paraServerMainteGidnc = sqlCommand.Parameters.Add("@SERVERMAINTEGIDNC", SqlDbType.NVarChar);

        //        //Parameterオブジェクトへ値設定
        //        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(svrMntInfoWork.CreateDateTime);
        //        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(svrMntInfoWork.UpdateDateTime);
        //        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(svrMntInfoWork.LogicalDeleteCode);
        //        paraProductCode.Value = SqlDataMediator.SqlSetString(svrMntInfoWork.ProductCode);
        //        paraServerMainteConsNo.Value = SqlDataMediator.SqlSetInt32(svrMntInfoWork.ServerMainteConsNo);
        //        paraServerMainteDivCd.Value = SqlDataMediator.SqlSetInt32(svrMntInfoWork.ServerMainteDivCd);
        //        paraServerMainteStScdl.Value = SqlDataMediator.SqlSetInt64(svrMntInfoWork.ServerMainteStScdl);
        //        paraServerMainteEdScdl.Value = SqlDataMediator.SqlSetInt64(svrMntInfoWork.ServerMainteEdScdl);
        //        paraServerMainteStTime.Value = SqlDataMediator.SqlSetInt64(svrMntInfoWork.ServerMainteStTime);
        //        paraServerMainteEdTime.Value = SqlDataMediator.SqlSetInt64(svrMntInfoWork.ServerMainteEdTime);
        //        paraServerMainteCntnts.Value = SqlDataMediator.SqlSetString(svrMntInfoWork.ServerMainteCntnts);
        //        paraServerMainteGidnc.Value = SqlDataMediator.SqlSetString(svrMntInfoWork.ServerMainteGidnc);

        //        sqlCommand.ExecuteNonQuery();

        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //        return status;
        //    }
        //    catch (SqlException ex)
        //    {
        //        // ロック要求がTimeOutの場合、排他エラーを返す
        //        if (ex.Number == 1222)
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //            errMessage = "排他エラーが発生しました。" + ex.ToString();
        //        }
        //        else
        //        {
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //            errMessage = "更新・登録でエラーが発生しました。" + ex.ToString();
        //        }
        //    }
        //    finally
        //    {
        //        if ((myReader != null) && (!myReader.IsClosed)) myReader.Close();
        //        if (sqlCommand != null) sqlCommand.Dispose();
        //        if (sqlConnection != null)
        //        {
        //            sqlConnection.Close();
        //        }
        //    }
        //    return status;
        //}
        //#endregion

        //#region public int DeleteSvrMntInfo( SvrMntInfoWork svrMntInfoWork, out string errMessage )

        ///// <summary>
        ///// サーバーメンテナンス情報マスタ削除処理
        ///// </summary>
        ///// <param name="svrMntInfoWork">サーバーメンテナンス情報ワーククラス</param>
        ///// <param name="errMessage">エラーメッセージ</param>
        ///// <returns>STATUS</returns>
        //public int DeleteSvrMntInfo( SvrMntInfoWork svrMntInfoWork, out string errMessage )
        //{
        //    int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

        //    ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

        //    SqlConnection sqlConnection = null;
        //    SqlTransaction sqlTransaction = null;
        //    SqlDataReader myReader = null;
        //    errMessage = "";

        //    try {
        //        // 変更PG案内DB接続文字列取得部品より、接続文字列を取得
        //        ChangePgGuideSqlInfo changePgGuideSqlInfo = new ChangePgGuideSqlInfo();
        //        string connectionText = changePgGuideSqlInfo.GetConnectionText();
        //        if( String.IsNullOrEmpty( connectionText ) ) {
        //            // 接続文字列の取得に失敗
        //            return status;
        //        }

        //        // コネクションオープン
        //        sqlConnection = new SqlConnection( connectionText );
        //        sqlConnection.Open();

        //        // トランザクション開始
        //        sqlTransaction = sqlConnection.BeginTransaction( ( IsolationLevel )ConstantManagement.DB_IsolationLevel.ctDB_Default );

        //        using( SqlCommand sqlCommand = new SqlCommand( 
        //            " SELECT UPDATEDATETIMERF FROM SVRMNTINFORF " + 
        //            "WHERE PRODUCTCODERF=@FINDPRODUCTCODE AND SERVERMAINTECONSNORF=@FINDSERVERMAINTECONSNO ", 
        //            sqlConnection, sqlTransaction ) ) {

        //            // Parameterオブジェクトの作成
        //            SqlParameter findParaProductCode = sqlCommand.Parameters.Add( "@FINDPRODUCTCODE", SqlDbType.NVarChar );
        //            SqlParameter findParaServerMainteConsNo = sqlCommand.Parameters.Add( "@FINDSERVERMAINTECONSNO", SqlDbType.Int );

        //            // Parameterオブジェクトへ値をセット
        //            findParaProductCode.Value = SqlDataMediator.SqlSetString( svrMntInfoWork.ProductCode );
        //            findParaServerMainteConsNo.Value = SqlDataMediator.SqlSetInt32( svrMntInfoWork.ServerMainteConsNo );

        //            myReader = sqlCommand.ExecuteReader();
        //            if( myReader.Read() ) {
        //                // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで返す
        //                DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) );
        //                if( updateDateTime != svrMntInfoWork.UpdateDateTime ) {
        //                    status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                    if( ! myReader.IsClosed ) {
        //                        myReader.Close();
        //                    }
        //                    return status;
        //                }

        //                sqlCommand.CommandText = "DELETE FROM SVRMNTINFORF " + 
        //                    "WHERE PRODUCTCODERF=@FINDPRODUCTCODE AND SERVERMAINTECONSNORF=@FINDSERVERMAINTECONSNO ";

        //                // KEYコマンドを再設定
        //                findParaProductCode.Value = SqlDataMediator.SqlSetString( svrMntInfoWork.ProductCode );
        //                findParaServerMainteConsNo.Value = SqlDataMediator.SqlSetInt32( svrMntInfoWork.ServerMainteConsNo );
        //            }
        //            else {
        //                // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合は既に削除されている意味で排他を返す
        //                status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
        //                if( ! myReader.IsClosed ) {
        //                    myReader.Close();
        //                }
        //                return status;
        //            }

        //            if( ! myReader.IsClosed ) {
        //                myReader.Close();
        //            }

        //            sqlCommand.ExecuteNonQuery();

        //            status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
        //        }
        //    }
        //    catch( Exception ex ) {
        //        // ログを出力
        //        changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, ex );
        //        status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
        //        errMessage = ex.Message;
        //    }
        //    finally {
        //        // コネクション破棄
        //        if( sqlConnection != null ) {
        //            // コミットorロールバック
        //            if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
        //                sqlTransaction.Commit();
        //            }
        //            else {
        //                sqlTransaction.Rollback();
        //            }

        //            sqlTransaction.Dispose();
        //            sqlConnection.Close();
        //        }
        //    }

        //    return status;
        //}

        //#endregion

        //#endregion

        #endregion



        #region 変更案内マスタ・変更案内明細マスタ

        #region public int ChangGidnc(ChangGidncParaWork changGidncParaWork, out List<ChangGidncWork> changGidncList, out List<ChgGidncDtWork> chgGidncDtList, int stNumber, int count, out int maxCount, out string errMessage)
        /// <summary>
        /// 変更案内・明細マスタLISTを全て戻します
        /// </summary>
        /// <param name="changGidncParaWork">検索パラメータ</param>
        /// <param name="changGidncList">変更案内マスタ結果</param>
        /// <param name="chgGidncDtList">変更案内明細マスタ結果</param>
        /// <param name="stNumber">検索開始値</param>
        /// <param name="count">検索数</param>
        /// <param name="maxCount">最大件数</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>status</returns>
        public int ChangGidnc(ChangGidncParaWork changGidncParaWork, out List<ChangGidncWork> changGidncList, out List<ChgGidncDtWork> chgGidncDtList, int stNumber, int count, out int maxCount, out string errMessage)
        {

//TEST用
//using (StreamWriter sw = new StreamWriter("WkLog.txt", true))
//{
//    sw.WriteLine("ChangGidnc-1 : ");
//}
//
//System.Windows.Forms.MessageBox.Show("ChangGidnc-1 : ");
//TEST用

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            maxCount = 0;
            ArrayList keyArray = new ArrayList();
            errMessage = "";
            changGidncList = null;
            chgGidncDtList = null;
            ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

            try
            {
                //変更案内用の接続文字列取得
                ChangePgGuideSqlInfo changePgGuideSqlInfo = new ChangePgGuideSqlInfo();
                string connectionText = changePgGuideSqlInfo.GetConnectionText();//(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                //コネクションオープン
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();
                //トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = SearchCntProc(out maxCount, changGidncParaWork, ref sqlConnection, ref sqlTransaction, out errMessage);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                    {
                        //errMessage = "検索条件が不正です";
                    }
                    else if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //errMessage = "変更案内マスタ：件数取得中にエラーが発生しました";
                    }
                    
                    return status;
                }

                status = SearchKey(changGidncParaWork, out keyArray, ref sqlConnection, ref sqlTransaction, stNumber, count, out errMessage);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //errMessage = "変更案内マスタ：キー情報取得中にエラーが発生しました";
                    }
                    return status;
                }

                status = SearchChangGidnc(keyArray, changGidncParaWork, out changGidncList, ref sqlConnection, ref sqlTransaction, out errMessage);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //errMessage = "変更案内マスタ：データ取得中にエラーが発生しました";
                    }
                    return status;
                }

                status = SearchChgGidncDt(keyArray, changGidncParaWork, out chgGidncDtList, ref sqlConnection, ref sqlTransaction, out errMessage);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //errMessage = "変更案内明細マスタ：データ取得中にエラーが発生しました";
                    }
                    return status;
                }
            }
            catch(Exception e)
            {
                changePgGuideLogOutPut.WriteLog(ChangePgGuideLogOutPut.MessageLevel.Error, e);
                // ロールバック
                if (sqlTransaction != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = e.ToString();
            }
            finally
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    //ロールバック
                    if (sqlTransaction != null) sqlTransaction.Rollback();
                }
                if (sqlTransaction != null)
                {
                    sqlTransaction.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion



        #region private int SearchCntProc(out int maxCount, ChangGidncParaWork changGidncParaWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string errMessage)
        /// <summary>
        /// 変更案内・明細マスタの件数を戻します
        /// </summary>
        /// <param name="maxCount">件数</param>
        /// <param name="changGidncParaWork">検索条件</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>status</returns>
        private int SearchCntProc(out int maxCount, ChangGidncParaWork changGidncParaWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            maxCount = 0;
            errMessage = "";
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

            if ((changGidncParaWork.ProductCode == null) || (changGidncParaWork.McastOfferDivCd == null) || (changGidncParaWork.OpenDtTmDiv == null) || (changGidncParaWork.MulticastSystemDivCd == null))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                return status;
            }
            else
            {
                try
                {
                    sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Transaction = sqlTransaction;

                    string whereString = KeyWhereString(ref sqlCommand, changGidncParaWork,1);


                    //sqlCommand.CommandText = " SELECT  COUNT (DISTINCT CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF) "  //Del 2007.12.10 Kouguchi
                    sqlCommand.CommandText = " SELECT  COUNT (CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF) "  //Add 2007.12.10 Kouguchi
                        + " FROM CHANGGIDNCRF "
                        + " LEFT OUTER JOIN CHGGIDNCDTRF "
                        + "  ON CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=CHGGIDNCDTRF.MCASTGIDNCCNTNTSCDRF "
                        + " AND CHANGGIDNCRF.PRODUCTCODERF=CHGGIDNCDTRF.PRODUCTCODERF "
                        + " AND CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF=CHGGIDNCDTRF.MCASTGIDNCVERSIONCDRF "
                        + " AND CHANGGIDNCRF.MCASTOFFERDIVCDRF=CHGGIDNCDTRF.MCASTOFFERDIVCDRF "
                        + " AND CHANGGIDNCRF.UPDATEGROUPCODERF=CHGGIDNCDTRF.UPDATEGROUPCODERF "
                        + " AND CHANGGIDNCRF.ENTERPRISECODERF=CHGGIDNCDTRF.ENTERPRISECODERF "
                        + " AND CHANGGIDNCRF.MULTICASTCONSNORF=CHGGIDNCDTRF.MULTICASTCONSNORF "
                        + " WHERE " + whereString;

                    //データリード
                    maxCount = (int)sqlCommand.ExecuteScalar();

                    if (maxCount > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    changePgGuideLogOutPut.WriteLog(ChangePgGuideLogOutPut.MessageLevel.Error, ex);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    errMessage = ex.ToString();
                }
                catch (Exception e)
                {
                    changePgGuideLogOutPut.WriteLog(ChangePgGuideLogOutPut.MessageLevel.Error,e);
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    errMessage = e.ToString();
                }
                finally
                {
                    if ((myReader != null) && (!myReader.IsClosed)) myReader.Close();
                    if (sqlCommand != null) sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region private int SearchKey(ChangGidncParaWork changGidncParaWork, out ArrayList keyList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int stNumber, int count, out string errMessage)
        /// <summary>
        /// 変更案内・明細マスタのキー情報を全て戻します
        /// </summary>
        /// <param name="changGidncParaWork">検索条件</param>
        /// <param name="keyList">キー情報</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="stNumber">検索開始数</param>
        /// <param name="count">検索件数</param>
        /// <param name="maxCount">最大件数</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>status</returns>
        private int SearchKey(ChangGidncParaWork changGidncParaWork, out ArrayList keyList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int stNumber, int count, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = "";

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ChangGidncWork wkCls = null;
            keyList = new ArrayList();

            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = sqlTransaction;
                string whereString = KeyWhereString(ref sqlCommand, changGidncParaWork, 1);
                string whereString2 = KeyWhereString(ref sqlCommand, changGidncParaWork, 2);

                sqlCommand.CommandText = " SELECT TOP " + count.ToString()
                    //+ " CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTCONSNORF, CHANGGIDNCRF.MULTICASTDATERF, CHANGGIDNCRF.MCASTGIDNCMAINTECDRF ";
                    //+ " CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF , CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTDATERF "
                    + " CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTDATERF, "
                    + " CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF ";

                sqlCommand.CommandText += " FROM CHANGGIDNCRF "
                    + " LEFT OUTER JOIN CHGGIDNCDTRF "
                    + "  ON CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=CHGGIDNCDTRF.MCASTGIDNCCNTNTSCDRF "
                    + " AND CHANGGIDNCRF.PRODUCTCODERF=CHGGIDNCDTRF.PRODUCTCODERF "
                    + " AND CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF=CHGGIDNCDTRF.MCASTGIDNCVERSIONCDRF "
                    + " AND CHANGGIDNCRF.MCASTOFFERDIVCDRF=CHGGIDNCDTRF.MCASTOFFERDIVCDRF "
                    + " AND CHANGGIDNCRF.UPDATEGROUPCODERF=CHGGIDNCDTRF.UPDATEGROUPCODERF "
                    + " AND CHANGGIDNCRF.ENTERPRISECODERF=CHGGIDNCDTRF.ENTERPRISECODERF ";
                    //+ " AND CHANGGIDNCRF.MULTICASTCONSNORF=CHGGIDNCDTRF.MULTICASTCONSNORF ";

                sqlCommand.CommandText += " WHERE " + whereString
                    + " AND NOT EXISTS "
                    + " (SELECT "
                    //+ " CHANGGIDNCRF3.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF3.PRODUCTCODERF, CHANGGIDNCRF3.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF3.MCASTOFFERDIVCDRF, CHANGGIDNCRF3.UPDATEGROUPCODERF, CHANGGIDNCRF3.ENTERPRISECODERF, CHANGGIDNCRF3.MULTICASTCONSNORF,CHANGGIDNCRF3.MULTICASTDATERF, CHANGGIDNCRF3.MCASTGIDNCMAINTECDRF "
                    //+ " CHANGGIDNCRF3.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF3.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF3.MCASTOFFERDIVCDRF, CHANGGIDNCRF3.UPDATEGROUPCODERF, CHANGGIDNCRF3.ENTERPRISECODERF, CHANGGIDNCRF3.MULTICASTCONSNORF,CHANGGIDNCRF3.MULTICASTDATERF "
                    + " CHANGGIDNCRF3.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF3.PRODUCTCODERF, CHANGGIDNCRF3.MCASTOFFERDIVCDRF, CHANGGIDNCRF3.UPDATEGROUPCODERF, CHANGGIDNCRF3.ENTERPRISECODERF, CHANGGIDNCRF3.MULTICASTDATERF, "
                    + " CHANGGIDNCRF3.MCASTGIDNCVERSIONCDRF "
                    + " FROM "

                        + " (SELECT TOP " + stNumber.ToString()
                        //+ " CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTCONSNORF, CHANGGIDNCRF2.MULTICASTDATERF, CHANGGIDNCRF2.MCASTGIDNCMAINTECDRF "
                        //+ " CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTCONSNORF, CHANGGIDNCRF2.MULTICASTDATERF, "
                        + " CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTDATERF, "
                        + " CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF "

                        + " FROM CHANGGIDNCRF AS CHANGGIDNCRF2 "
                        + " LEFT OUTER JOIN CHGGIDNCDTRF AS CHGGIDNCDTRF2 "
                        + "  ON CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF=CHGGIDNCDTRF2.MCASTGIDNCCNTNTSCDRF "
                        + " AND CHANGGIDNCRF2.PRODUCTCODERF=CHGGIDNCDTRF2.PRODUCTCODERF "
                        + " AND CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF=CHGGIDNCDTRF2.MCASTGIDNCVERSIONCDRF "
                        + " AND CHANGGIDNCRF2.MCASTOFFERDIVCDRF=CHGGIDNCDTRF2.MCASTOFFERDIVCDRF "
                        + " AND CHANGGIDNCRF2.UPDATEGROUPCODERF=CHGGIDNCDTRF2.UPDATEGROUPCODERF "
                        + " AND CHANGGIDNCRF2.ENTERPRISECODERF=CHGGIDNCDTRF2.ENTERPRISECODERF ";
                        //+ " AND CHANGGIDNCRF2.MULTICASTCONSNORF=CHGGIDNCDTRF2.MULTICASTCONSNORF ";

                    sqlCommand.CommandText += " WHERE " + whereString2
                    //+ " GROUP BY CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTCONSNORF, CHANGGIDNCRF2.MULTICASTDATERF "
                    //+ " ORDER BY CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTCONSNORF DESC, CHANGGIDNCRF2.MULTICASTDATERF "
                    //+ " GROUP BY CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.MCASTGIDNCMAINTECDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTCONSNORF, CHANGGIDNCRF2.MULTICASTDATERF "
                    //+ " ORDER BY CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.MCASTGIDNCMAINTECDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF DESC, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTCONSNORF DESC, CHANGGIDNCRF2.MULTICASTDATERF "
                    //+ " GROUP BY CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTCONSNORF, CHANGGIDNCRF2.MULTICASTDATERF "
                    //+ " ORDER BY CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF DESC, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTCONSNORF DESC, CHANGGIDNCRF2.MULTICASTDATERF "
                    + " GROUP BY CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTDATERF "
                    + " ORDER BY CHANGGIDNCRF2.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF2.PRODUCTCODERF, CHANGGIDNCRF2.MCASTGIDNCVERSIONCDRF DESC, CHANGGIDNCRF2.MCASTOFFERDIVCDRF, CHANGGIDNCRF2.UPDATEGROUPCODERF, CHANGGIDNCRF2.ENTERPRISECODERF, CHANGGIDNCRF2.MULTICASTDATERF "
                    + " ) AS CHANGGIDNCRF3"
                       
                    + " WHERE CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=CHANGGIDNCRF3.MCASTGIDNCCNTNTSCDRF "
                    + " AND CHANGGIDNCRF.PRODUCTCODERF=CHANGGIDNCRF3.PRODUCTCODERF "
                    + " AND CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF=CHANGGIDNCRF3.MCASTGIDNCVERSIONCDRF "
                    + " AND CHANGGIDNCRF.MCASTOFFERDIVCDRF=CHANGGIDNCRF3.MCASTOFFERDIVCDRF "
                    + " AND CHANGGIDNCRF.UPDATEGROUPCODERF=CHANGGIDNCRF3.UPDATEGROUPCODERF "
                    + " AND CHANGGIDNCRF.ENTERPRISECODERF=CHANGGIDNCRF3.ENTERPRISECODERF "
                    //+ " AND CHANGGIDNCRF.MULTICASTCONSNORF=CHANGGIDNCRF3.MULTICASTCONSNORF "

                    + " ) ";

                    //sqlCommand.CommandText += " GROUP BY CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTCONSNORF, CHANGGIDNCRF.MULTICASTDATERF ";
                    //sqlCommand.CommandText += " ORDER BY CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTCONSNORF DESC, CHANGGIDNCRF.MULTICASTDATERF ";
                    //sqlCommand.CommandText += " GROUP BY CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.MCASTGIDNCMAINTECDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTCONSNORF, CHANGGIDNCRF.MULTICASTDATERF ";
                    //sqlCommand.CommandText += " ORDER BY CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.MCASTGIDNCMAINTECDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF DESC, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTCONSNORF DESC, CHANGGIDNCRF.MULTICASTDATERF ";
                    //sqlCommand.CommandText += " GROUP BY CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTCONSNORF, CHANGGIDNCRF.MULTICASTDATERF ";
                    //sqlCommand.CommandText += " ORDER BY CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF DESC, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTCONSNORF DESC, CHANGGIDNCRF.MULTICASTDATERF ";
                    sqlCommand.CommandText += " GROUP BY CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTDATERF ";
                    sqlCommand.CommandText += " ORDER BY CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF DESC, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTDATERF ";

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    wkCls = new ChangGidncWork();

                    wkCls.McastGidncCntntsCd  = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal("MCASTGIDNCCNTNTSCDRF"));
                    wkCls.ProductCode         = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRODUCTCODERF"));
                    wkCls.McastGidncVersionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MCASTGIDNCVERSIONCDRF"));
                    wkCls.McastOfferDivCd     = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal("MCASTOFFERDIVCDRF"));
                    wkCls.UpdateGroupCode     = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATEGROUPCODERF"));
                    wkCls.EnterpriseCode      = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    //wkCls.MulticastConsNo     = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MULTICASTCONSNORF"));
                    wkCls.MulticastDate       = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal("MULTICASTDATERF"));

                    keyList.Add(wkCls);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch(SqlException ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.ToString();
            }
            catch (Exception e)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = e.ToString();
            }
            finally
            {
                if ((myReader != null) && (!myReader.IsClosed)) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();                
            }

            return status;
        }
        #endregion

        #region private int SearchChangGidnc(ArrayList keyList, out List<ChangGidncWork> ChangGidncWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string errMessage)
        /// <summary>
        /// 変更案内マスタLISTを全て戻します
        /// </summary>
        /// <param name="keyList">検索キーリスト</param>
        /// <param name="ChangGidncWorkList">検索結果</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>status</returns>
        private int SearchChangGidnc(ArrayList keyList, ChangGidncParaWork paradata, out List<ChangGidncWork> ChangGidncWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = "";

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ChangGidncWork wkCls = null;
            ChangGidncWorkList = null;

            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = sqlTransaction;
                ChangGidncWorkList = new List<ChangGidncWork>();

                //検索条件に「変更内容」がある
                if ((paradata.ChangeContents != null) && (paradata.ChangeContents.Length > 0))
                {
                    foreach (ChangGidncWork _ChangGidncWork in keyList)
                    {
                        string wkstr = "";

                        sqlCommand = new SqlCommand(" SELECT "
                            + " CHANGGIDNCRF.CREATEDATETIMERF, CHANGGIDNCRF.UPDATEDATETIMERF, CHANGGIDNCRF.LOGICALDELETECODERF, CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.PRODUCTCODERF, "
                            + " CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTCONSNORF, "
                            + " CHANGGIDNCRF.MULTICASTDATERF, CHANGGIDNCRF.SUPPORTOPENTIMERF, CHANGGIDNCRF.CUSTOMEROPENTIMERF, CHANGGIDNCRF.SERVERMAINTESTSCDLRF, CHANGGIDNCRF.SERVERMAINTEEDSCDLRF, "
                            + " CHANGGIDNCRF.SERVERMAINTESTTIMERF, CHANGGIDNCRF.SERVERMAINTEEDTIMERF, CHANGGIDNCRF.MCASTGIDNCNEWCUSTMCDRF, CHANGGIDNCRF.MCASTGIDNCMAINTECDRF, CHANGGIDNCRF.SYSTEMDIVCDRF, CHANGGIDNCRF.GUIDANCE1RF, CHANGGIDNCRF.AREARF "
                            + " FROM CHANGGIDNCRF "
                            + " LEFT OUTER JOIN CHGGIDNCDTRF "
                            + "  ON CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=CHGGIDNCDTRF.MCASTGIDNCCNTNTSCDRF "
                            + " AND CHANGGIDNCRF.PRODUCTCODERF=CHGGIDNCDTRF.PRODUCTCODERF "
                            + " AND CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF=CHGGIDNCDTRF.MCASTGIDNCVERSIONCDRF "
                            + " AND CHANGGIDNCRF.MCASTOFFERDIVCDRF=CHGGIDNCDTRF.MCASTOFFERDIVCDRF "
                            + " AND CHANGGIDNCRF.UPDATEGROUPCODERF=CHGGIDNCDTRF.UPDATEGROUPCODERF "
                            + " AND CHANGGIDNCRF.ENTERPRISECODERF=CHGGIDNCDTRF.ENTERPRISECODERF "
                            + " AND CHANGGIDNCRF.MULTICASTCONSNORF=CHGGIDNCDTRF.MULTICASTCONSNORF "

                            + " WHERE ", sqlConnection, sqlTransaction);

                        #region 条件追加
                        //Add ↓↓↓ 2007.12.10 Kouguchi
                        //案内区分
                        //if (_ChangGidncWork.McastGidncCntntsCd >= 0)
                        if (paradata.McastGidncCntntsCd >= 0)
                        {
                            wkstr += " CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD ";
                            SqlParameter findParaMcastGidncCntntsCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCCNTNTSCD", SqlDbType.Int);
                            findParaMcastGidncCntntsCd.Value = SqlDataMediator.SqlSetInt32(_ChangGidncWork.McastGidncCntntsCd);
                        }
                        //Add ↑↑↑ 2007.12.10 Kouguchi
                        //パッケージ区分
                        //if (_ChangGidncWork.ProductCode != null)  //Del 2007.12.10 Kouguchi
                        if ((_ChangGidncWork.ProductCode != null) && (_ChangGidncWork.ProductCode != ""))  //Add 2007.12.10 Kouguchi
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.PRODUCTCODERF=@FINDPRODUCTCODE ";
                            SqlParameter findParaProductCode = sqlCommand.Parameters.Add("@FINDPRODUCTCODE", SqlDbType.NVarChar);
                            findParaProductCode.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.ProductCode);
                        }
                        //配信提供区分
                        if (_ChangGidncWork.McastOfferDivCd >= 0)
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD ";
                            SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD", SqlDbType.Int);
                            findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(_ChangGidncWork.McastOfferDivCd);
                        }
                        //配信提供区分=1 and 更新グループコード
                        if ((_ChangGidncWork.McastOfferDivCd == 1) && (_ChangGidncWork.UpdateGroupCode != ""))
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE ";
                            SqlParameter findParaUpdateGroupCode = sqlCommand.Parameters.Add("@FINDUPDATEGROUPCODE", SqlDbType.NVarChar);
                            findParaUpdateGroupCode.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.UpdateGroupCode);
                        }
                        //配信提供区分=1 and 企業コード
                        if ((_ChangGidncWork.McastOfferDivCd == 1) && (_ChangGidncWork.EnterpriseCode != ""))
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.ENTERPRISECODERF=@FINDENTERPRISECODE ";
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.EnterpriseCode);
                        }
                        //配信案内　バージョン区分
                        //if (_ChangGidncWork.McastGidncVersionCd != null)  //Del 2007.12.10 Kouguchi
                        if ((_ChangGidncWork.McastGidncVersionCd != null) && (_ChangGidncWork.McastGidncVersionCd != ""))  //Add 2007.12.10 Kouguchi
                        {
                            if (wkstr != "") wkstr += "AND";
                            //wkstr += " CHANGGIDNCRF.MULTICASTVERSIONRF=@FINDMULTICASTVERSION ";
                            wkstr += " CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF=@FINDMULTICASTVERSION ";
                            SqlParameter findParaMulticastVersion = sqlCommand.Parameters.Add("@FINDMULTICASTVERSION", SqlDbType.NVarChar);
                            findParaMulticastVersion.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.McastGidncVersionCd);
                        }
                        //連番
                        if (_ChangGidncWork.MulticastConsNo > 0)
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.MULTICASTCONSNORF=@FINDMULTICASTCONSNO ";
                            SqlParameter findParaMulticastConsNon = sqlCommand.Parameters.Add("@FINDMULTICASTCONSNO", SqlDbType.Int);
                            findParaMulticastConsNon.Value = SqlDataMediator.SqlSetInt32(_ChangGidncWork.MulticastConsNo);
                        }


                        //Add ↓↓↓ 2007.12.10 Kouguchi
                        //地域
                        //if ((_ChangGidncWork.Area != null) && (_ChangGidncWork.Area != ""))
                        if ((paradata.Area != null) && (paradata.Area != ""))
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.AREARF LIKE @FINDAREA ";
                            SqlParameter findParaArea = sqlCommand.Parameters.Add("@FINDAREA", SqlDbType.NVarChar);
                            findParaArea.Value = SqlDataMediator.SqlSetString("%" + _ChangGidncWork.Area + "%");
                        }
                        //システム区分
                        if (paradata.MulticastSystemDivCd >= 0)
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.SYSTEMDIVCDRF=@FINDMULTICASTSYSTEMDIVCD ";
                            SqlParameter findParaMulticastSystemDivCd = sqlCommand.Parameters.Add("@FINDMULTICASTSYSTEMDIVCD", SqlDbType.Int);
                            findParaMulticastSystemDivCd.Value = SqlDataMediator.SqlSetInt32(paradata.MulticastSystemDivCd);
                        }
                        //案内文１(プログラム名称)
                        if ((paradata.MulticastProgramName != null) && (paradata.MulticastProgramName != ""))
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.GUIDANCE1RF LIKE @FINDMULTICASTPROGRAMNAME ";
                            SqlParameter findParaMulticastProgramName = sqlCommand.Parameters.Add("@FINDMULTICASTPROGRAMNAME", SqlDbType.NVarChar);
                            findParaMulticastProgramName.Value = SqlDataMediator.SqlSetString("%" + paradata.MulticastProgramName + "%");
                        }

                        //メンテ区分
                        //if (paradata.McastGidncMainteCd > 0)
                        //{
                        //    if (wkstr != "") wkstr += "AND";
                        //    wkstr += " CHANGGIDNCRF.MCASTGIDNCMAINTECDRF=@FINDMCASTGIDNCMAINTECD ";
                        //    SqlParameter findParaMcastGidncMainteCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCMAINTECD", SqlDbType.Int);
                        //    findParaMcastGidncMainteCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastGidncMainteCd);
                        //}
                        //if ((_ChangGidncWork.McastGidncCntntsCd == -1) && (paradata.McastGidncMainteCd == 2))
                        if ((paradata.McastGidncCntntsCd == -1) && (paradata.McastGidncMainteCd == 2))
                        {
                            if (wkstr != "") wkstr += "AND";

                            //wkstr  += " CHANGGIDNCRF.MCASTGIDNCMAINTECDRF<>1 AND CHANGGIDNCRF.MCASTGIDNCMAINTECDRF<>9 ";
                            wkstr += " ( ";
                            wkstr += " CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=1 OR CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=3 OR ";
                            wkstr += " ( CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=2 AND CHANGGIDNCRF.MCASTGIDNCMAINTECDRF=2 ) ";
                            wkstr += " ) ";
                        }
                        else
                        if ((paradata.McastGidncCntntsCd == 2) && (paradata.McastGidncMainteCd == -1))
                        {
                            if (wkstr != "") wkstr += "AND";

                            wkstr += " ( ";
                            wkstr += " ( CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=2 AND CHANGGIDNCRF.MCASTGIDNCMAINTECDRF=1 ) OR ";
                            wkstr += " ( CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=2 AND CHANGGIDNCRF.MCASTGIDNCMAINTECDRF=9 ) ";
                            wkstr += " ) ";
                        }
                        else
                        {
                            if (paradata.McastGidncMainteCd > 0)
                            {
                                if (wkstr != "") wkstr += "AND";
                                wkstr += " CHANGGIDNCRF.MCASTGIDNCMAINTECDRF=@FINDMCASTGIDNCMAINTECD ";
                                SqlParameter findParaMcastGidncMainteCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCMAINTECD", SqlDbType.Int);
                                findParaMcastGidncMainteCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastGidncMainteCd);
                            }
                        }
                        //Add ↑↑↑ 2007.12.10 Kouguchi
                        #endregion


                        //wkstr += PgMulcasWhereString(ref sqlCommand, paradata);  //Del 2007.12.10 Kouguchi


                        wkstr += " AND (";

                        StringBuilder wkstbil = new StringBuilder();
                        foreach (string wkst in paradata.ChangeContents)
                        {
                            if (wkstbil.Length != 0)  wkstbil.Append(" AND");
                            wkstbil.Append(" CHGGIDNCDTRF.CHANGECONTENTSRF LIKE '%" + wkst + "%'");
                        }
                        wkstbil.Append(") ");

                        wkstr += wkstbil.ToString();

                        //wkstr += " ORDER BY CHANGGIDNCRF.MULTICASTDATERF DESC, PRODUCTCODERF, MCASTOFFERDIVCDRF, UPDATEGROUPCODERF, ENTERPRISECODERF, MULTICASTVERSIONRF DESC, MULTICASTCONSNORF ";
                        wkstr += " ORDER BY CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.MULTICASTDATERF DESC, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF DESC, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTCONSNORF ";

                        sqlCommand.CommandText += wkstr;

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            wkCls = new ChangGidncWork();

                            wkCls.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            wkCls.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            wkCls.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            wkCls.McastGidncCntntsCd   = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTGIDNCCNTNTSCDRF"));
                            wkCls.ProductCode          = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("PRODUCTCODERF"));
                            wkCls.McastGidncVersionCd  = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("MCASTGIDNCVERSIONCDRF"));
                            wkCls.McastOfferDivCd      = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTOFFERDIVCDRF"));
                            wkCls.UpdateGroupCode      = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("UPDATEGROUPCODERF"));
                            wkCls.EnterpriseCode       = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            wkCls.MulticastConsNo      = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MULTICASTCONSNORF"));
                            wkCls.MulticastDate        = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MULTICASTDATERF"));
                            wkCls.SupportOpenTime      = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("SUPPORTOPENTIMERF"));
                            wkCls.CustomerOpenTime     = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("CUSTOMEROPENTIMERF"));
                            wkCls.ServerMainteStScdl   = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("SERVERMAINTESTSCDLRF"));
                            wkCls.ServerMainteEdScdl   = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("SERVERMAINTEEDSCDLRF"));
                            wkCls.ServerMainteStTime   = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("SERVERMAINTESTTIMERF"));
                            wkCls.ServerMainteEdTime   = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("SERVERMAINTEEDTIMERF"));
                            wkCls.McastGidncNewCustmCd = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTGIDNCNEWCUSTMCDRF"));
                            wkCls.McastGidncMainteCd   = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTGIDNCMAINTECDRF"));
                            wkCls.SystemDivCd          = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("SYSTEMDIVCDRF"));
                            wkCls.Guidance1            = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("GUIDANCE1RF"));
                            wkCls.Area                 = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("AREARF"));

                            ChangGidncWorkList.Add(wkCls);

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        if ((myReader != null) && (!myReader.IsClosed)) myReader.Close();
                    }
                }
                //検索内容に「変更内容」がない
                else
                {
                    foreach (ChangGidncWork _ChangGidncWork in keyList)
                    {
                        string wkstr = "";

                        sqlCommand = new SqlCommand(" SELECT * FROM CHANGGIDNCRF WHERE ", sqlConnection, sqlTransaction);//PRODUCTCODERF=@FINDPRODUCTCODE AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD "

                        #region 条件追加
                        //案内区分
                        //if (_ChangGidncWork.McastGidncCntntsCd >= 0)
                        if (paradata.McastGidncCntntsCd >= 0)
                        {
                            wkstr += " CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD ";
                            SqlParameter findParaMcastGidncCntntsCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCCNTNTSCD", SqlDbType.Int);
                            findParaMcastGidncCntntsCd.Value = SqlDataMediator.SqlSetInt32(_ChangGidncWork.McastGidncCntntsCd);
                        }
                        //パッケージ区分
                        //if (_ChangGidncWork.ProductCode != null)  //Del 2007.12.10 Kouguchi
                        if ((_ChangGidncWork.ProductCode != null) && (_ChangGidncWork.ProductCode != ""))  //Add 2007.12.10 Kouguchi
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " PRODUCTCODERF=@FINDPRODUCTCODE ";
                            SqlParameter findParaProductCode = sqlCommand.Parameters.Add("@FINDPRODUCTCODE", SqlDbType.NVarChar);
                            findParaProductCode.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.ProductCode);
                        }
                        //配信提供区分
                        if (_ChangGidncWork.McastOfferDivCd >= 0)
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD ";
                            SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD", SqlDbType.Int);
                            findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(_ChangGidncWork.McastOfferDivCd);
                        }
                        //配信提供区分=1 and 更新グループコード
                        if ((_ChangGidncWork.McastOfferDivCd == 1) && (_ChangGidncWork.UpdateGroupCode != ""))
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE ";
                            SqlParameter findParaUpdateGroupCode = sqlCommand.Parameters.Add("@FINDUPDATEGROUPCODE", SqlDbType.NVarChar);
                            findParaUpdateGroupCode.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.UpdateGroupCode);
                        }
                        //配信提供区分=1 and 企業コード
                        if ((_ChangGidncWork.McastOfferDivCd == 1) && (_ChangGidncWork.EnterpriseCode != ""))
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " ENTERPRISECODERF=@FINDENTERPRISECODE ";
                            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.EnterpriseCode);
                        }
                        //配信案内　バージョン区分
                        //if (_ChangGidncWork.McastGidncVersionCd != null)  //Del 2007.12.10 Kouguchi
                        if ((_ChangGidncWork.McastGidncVersionCd != null) && (_ChangGidncWork.McastGidncVersionCd != ""))  //Add 2007.12.10 Kouguchi
                        {
                            if (wkstr != "") wkstr += "AND";
                            //wkstr += " MULTICASTVERSIONRF=@FINDMULTICASTVERSION ";
                            wkstr += " MCASTGIDNCVERSIONCDRF=@FINDMULTICASTVERSION ";
                            SqlParameter findParaMulticastVersion = sqlCommand.Parameters.Add("@FINDMULTICASTVERSION", SqlDbType.NVarChar);
                            findParaMulticastVersion.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.McastGidncVersionCd);
                        }
                        //連番
                        if (_ChangGidncWork.MulticastConsNo > 0)
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " MULTICASTCONSNORF=@FINDMULTICASTCONSNO ";
                            SqlParameter findParaMulticastConsNon = sqlCommand.Parameters.Add("@FINDMULTICASTCONSNO", SqlDbType.Int);
                            findParaMulticastConsNon.Value = SqlDataMediator.SqlSetInt32(_ChangGidncWork.MulticastConsNo);
                        }


                        //Add ↓↓↓ 2007.12.10 Kouguchi
                        //地域
                        //if ((_ChangGidncWork.Area != null) && (_ChangGidncWork.Area != ""))
                        if ((paradata.Area != null) && (paradata.Area != ""))
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.AREARF LIKE @FINDAREA ";
                            SqlParameter findParaArea = sqlCommand.Parameters.Add("@FINDAREA", SqlDbType.NVarChar);
                            findParaArea.Value = SqlDataMediator.SqlSetString("%" + _ChangGidncWork.Area + "%");
                        }
                        //システム区分
                        if (paradata.MulticastSystemDivCd >= 0)
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.SYSTEMDIVCDRF=@FINDMULTICASTSYSTEMDIVCD ";
                            SqlParameter findParaMulticastSystemDivCd = sqlCommand.Parameters.Add("@FINDMULTICASTSYSTEMDIVCD", SqlDbType.Int);
                            findParaMulticastSystemDivCd.Value = SqlDataMediator.SqlSetInt32(paradata.MulticastSystemDivCd);
                        }
                        //案内文１(プログラム名称)
                        if ((paradata.MulticastProgramName != null) && (paradata.MulticastProgramName != ""))
                        {
                            if (wkstr != "") wkstr += "AND";
                            wkstr += " CHANGGIDNCRF.GUIDANCE1RF LIKE @FINDMULTICASTPROGRAMNAME ";
                            SqlParameter findParaMulticastProgramName = sqlCommand.Parameters.Add("@FINDMULTICASTPROGRAMNAME", SqlDbType.NVarChar);
                            findParaMulticastProgramName.Value = SqlDataMediator.SqlSetString("%" + paradata.MulticastProgramName + "%");
                        }

                        //メンテ区分
                        //if (paradata.McastGidncMainteCd > 0)
                        //{
                        //    if (wkstr != "") wkstr += "AND";
                        //    wkstr += " CHANGGIDNCRF.MCASTGIDNCMAINTECDRF=@FINDMCASTGIDNCMAINTECD ";
                        //    SqlParameter findParaMcastGidncMainteCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCMAINTECD", SqlDbType.Int);
                        //    findParaMcastGidncMainteCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastGidncMainteCd);
                        //}
                        //if ((_ChangGidncWork.McastGidncCntntsCd == -1) && (paradata.McastGidncMainteCd == 2))
                        if ((paradata.McastGidncCntntsCd == -1) && (paradata.McastGidncMainteCd == 2))
                        {
                            if (wkstr != "") wkstr += "AND";

                            //wkstr += " CHANGGIDNCRF.MCASTGIDNCMAINTECDRF<>1 AND CHANGGIDNCRF.MCASTGIDNCMAINTECDRF<>9 ";
                            wkstr += " ( ";
                            wkstr += " CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=1 OR CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=3 OR ";
                            wkstr += " ( CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=2 AND CHANGGIDNCRF.MCASTGIDNCMAINTECDRF=2 ) ";
                            wkstr += " ) ";
                        }
                        else
                        if ((paradata.McastGidncCntntsCd == 2) && (paradata.McastGidncMainteCd == -1))
                        {
                            if (wkstr != "") wkstr += "AND";

                            wkstr += " ( ";
                            wkstr += " ( CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=2 AND CHANGGIDNCRF.MCASTGIDNCMAINTECDRF=1 ) OR ";
                            wkstr += " ( CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF=2 AND CHANGGIDNCRF.MCASTGIDNCMAINTECDRF=9 ) ";
                            wkstr += " ) ";
                        }
                        else
                        {
                            if (paradata.McastGidncMainteCd > 0)
                            {
                                if (wkstr != "") wkstr += "AND";
                                wkstr += " CHANGGIDNCRF.MCASTGIDNCMAINTECDRF=@FINDMCASTGIDNCMAINTECD ";
                                SqlParameter findParaMcastGidncMainteCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCMAINTECD", SqlDbType.Int);
                                findParaMcastGidncMainteCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastGidncMainteCd);
                            }
                        }
                        //Add ↑↑↑ 2007.12.10 Kouguchi
                        #endregion


                        //wkstr += PgMulcasWhereString(ref sqlCommand, paradata);  //Del 2007.12.10 Kouguchi


                        //wkstr += " ORDER BY CHANGGIDNCRF.MULTICASTDATERF DESC,PRODUCTCODERF,MCASTOFFERDIVCDRF,UPDATEGROUPCODERF,ENTERPRISECODERF,MULTICASTVERSIONRF DESC,MULTICASTCONSNORF ";
                        wkstr += " ORDER BY CHANGGIDNCRF.MCASTGIDNCCNTNTSCDRF, CHANGGIDNCRF.MULTICASTDATERF DESC, CHANGGIDNCRF.PRODUCTCODERF, CHANGGIDNCRF.MCASTGIDNCVERSIONCDRF DESC, CHANGGIDNCRF.MCASTOFFERDIVCDRF, CHANGGIDNCRF.UPDATEGROUPCODERF, CHANGGIDNCRF.ENTERPRISECODERF, CHANGGIDNCRF.MULTICASTCONSNORF ";

                        sqlCommand.CommandText += wkstr;

                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            wkCls = new ChangGidncWork();

                            wkCls.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            wkCls.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            wkCls.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            wkCls.McastGidncCntntsCd   = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTGIDNCCNTNTSCDRF"));
                            wkCls.ProductCode          = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("PRODUCTCODERF"));
                            wkCls.McastGidncVersionCd  = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("MCASTGIDNCVERSIONCDRF"));
                            wkCls.McastOfferDivCd      = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTOFFERDIVCDRF"));
                            wkCls.UpdateGroupCode      = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("UPDATEGROUPCODERF"));
                            wkCls.EnterpriseCode       = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            wkCls.MulticastConsNo      = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MULTICASTCONSNORF"));
                            wkCls.MulticastDate        = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MULTICASTDATERF"));
                            wkCls.SupportOpenTime      = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("SUPPORTOPENTIMERF"));
                            wkCls.CustomerOpenTime     = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("CUSTOMEROPENTIMERF"));
                            wkCls.ServerMainteStScdl   = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("SERVERMAINTESTSCDLRF"));
                            wkCls.ServerMainteEdScdl   = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("SERVERMAINTEEDSCDLRF"));
                            wkCls.ServerMainteStTime   = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("SERVERMAINTESTTIMERF"));
                            wkCls.ServerMainteEdTime   = SqlDataMediator.SqlGetInt64(               myReader, myReader.GetOrdinal("SERVERMAINTEEDTIMERF"));
                            wkCls.McastGidncNewCustmCd = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTGIDNCNEWCUSTMCDRF"));
                            wkCls.McastGidncMainteCd   = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTGIDNCMAINTECDRF"));
                            wkCls.SystemDivCd          = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("SYSTEMDIVCDRF"));
                            wkCls.Guidance1            = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("GUIDANCE1RF"));
                            wkCls.Area                 = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("AREARF"));

                            ChangGidncWorkList.Add(wkCls);

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        if ((myReader != null) && (!myReader.IsClosed)) myReader.Close();
                    
                    }
                }
            }
            catch(SqlException ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.ToString();
            }
            catch (Exception e)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = e.ToString();
            }
            finally
            {
                if ((myReader != null) && (!myReader.IsClosed)) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
            }
            return status;
        }
        #endregion

        #region private int SearchChgGidncDt(ArrayList keyList, out List<ChgGidncDtWork> ChgGidncDtWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string errMessage)
        /// <summary>
        /// 変更案内明細マスタLISTを全て戻します
        /// </summary>
        /// <param name="keyList">検索キーリスト</param>
        /// <param name="ChgGidncDtWorkList">検索結果</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>status</returns>
        private int SearchChgGidncDt(ArrayList keyList, ChangGidncParaWork paradata, out List<ChgGidncDtWork> ChgGidncDtWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = "";

            SqlDataReader myReader = null;            
            ChgGidncDtWork wkCls = null;
            ChgGidncDtWorkList = null;
            SqlCommand sqlCommand = null;

            ArrayList wkDt = new ArrayList();   //Add 2007.12.10 Kouguchi
            ArrayList wkDt2 = new ArrayList();   //Add 2007.12.10 Kouguchi

            try
            {
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Transaction = sqlTransaction;
                ChgGidncDtWorkList = new List<ChgGidncDtWork>();
                List<ChgGidncDtWork> ChgGidncDtWorkList2 = new List<ChgGidncDtWork>();  //Add 2007.12.10 Kouguchi

                foreach (ChangGidncWork _ChangGidncWork in keyList)
                {
                    string wkstr = "";

                    //Selectコマンドの生成
                    sqlCommand = new SqlCommand("SELECT * FROM CHGGIDNCDTRF WHERE ",sqlConnection,sqlTransaction);

                    #region 条件追加
                    //案内区分
                    if (_ChangGidncWork.McastGidncCntntsCd >= 0)
                    {
                        wkstr += " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD ";
                        SqlParameter findParaMcastGidncCntntsCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCCNTNTSCD", SqlDbType.Int);
                        findParaMcastGidncCntntsCd.Value = SqlDataMediator.SqlSetInt32(_ChangGidncWork.McastGidncCntntsCd);
                    }
                    //パッケージ区分
                    //if (_ChangGidncWork.ProductCode != null)  //Del 2007.12.10 Kouguchi
                    if ((_ChangGidncWork.ProductCode != null) && (_ChangGidncWork.ProductCode != ""))  //Add 2007.12.10 Kouguchi
                    {
                        if (wkstr != "") wkstr += "AND";
                        wkstr += " PRODUCTCODERF=@FINDPRODUCTCODE ";
                        SqlParameter findParaProductCode = sqlCommand.Parameters.Add("@FINDPRODUCTCODE", SqlDbType.NVarChar);
                        findParaProductCode.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.ProductCode);
                    }
                    //配信提供区分
                    if (_ChangGidncWork.McastOfferDivCd >= 0)
                    {
                        if (wkstr != "") wkstr += "AND";
                        wkstr += " MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD ";
                        SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD", SqlDbType.Int);
                        findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(_ChangGidncWork.McastOfferDivCd);
                    }
                    //配信提供区分=1 and 更新グループコード
                    if ((_ChangGidncWork.McastOfferDivCd == 1) && (_ChangGidncWork.UpdateGroupCode != ""))
                    {
                        if (wkstr != "") wkstr += "AND";
                        wkstr += " UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE ";
                        SqlParameter findParaUpdateGroupCode = sqlCommand.Parameters.Add("@FINDUPDATEGROUPCODE", SqlDbType.NVarChar);
                        findParaUpdateGroupCode.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.UpdateGroupCode);
                    }
                    //配信提供区分=1 and 企業コード
                    if ((_ChangGidncWork.McastOfferDivCd == 1) && (_ChangGidncWork.EnterpriseCode != ""))
                    {
                        if (wkstr != "") wkstr += "AND";
                        wkstr += " ENTERPRISECODERF=@FINDENTERPRISECODE ";
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.EnterpriseCode);
                    }
                    //配信案内　バージョン区分
                    //if (_ChangGidncWork.McastGidncVersionCd != null)  //Del 2007.12.10 Kouguchi
                    if ((_ChangGidncWork.McastGidncVersionCd != null) && (_ChangGidncWork.McastGidncVersionCd != ""))  //Add 2007.12.10 Kouguchi
                    {
                        if (wkstr != "") wkstr += "AND";
                        //wkstr += " MULTICASTVERSIONRF=@FINDMULTICASTVERSION ";
                        wkstr += " MCASTGIDNCVERSIONCDRF=@FINDMULTICASTVERSION ";
                        SqlParameter findParaMulticastVersion = sqlCommand.Parameters.Add("@FINDMULTICASTVERSION", SqlDbType.NVarChar);
                        findParaMulticastVersion.Value = SqlDataMediator.SqlSetString(_ChangGidncWork.McastGidncVersionCd);
                    }
                    //連番
                    if (_ChangGidncWork.MulticastConsNo > 0)
                    {
                        if (wkstr != "") wkstr += "AND";
                        wkstr += " MULTICASTCONSNORF=@FINDMULTICASTCONSNO ";
                        SqlParameter findParaMulticastConsNon = sqlCommand.Parameters.Add("@FINDMULTICASTCONSNO", SqlDbType.Int);
                        findParaMulticastConsNon.Value = SqlDataMediator.SqlSetInt32(_ChangGidncWork.MulticastConsNo);
                    }
                    //変更内容
                    if ((paradata.ChangeContents != null) && (paradata.ChangeContents.Length != 0))
                    {
                        StringBuilder wkstbil = new StringBuilder();

                        foreach (string wkcontents in paradata.ChangeContents)
                        {
                            if (wkstbil.Length != 0)
                            {
                                wkstbil.Append(" AND ");
                            }
                            else if (wkstbil.Length == 0)
                            {
                                wkstbil.Append(" AND (");
                            }

                            wkstbil.Append(" CHANGECONTENTSRF LIKE '%" + wkcontents + "%' ");
                        }
                        wkstbil.Append(")");

                        wkstr += wkstbil.ToString();
                    }
                    #endregion
                    
                    //wkstr += " ORDER BY PRODUCTCODERF,MCASTOFFERDIVCDRF,UPDATEGROUPCODERF,ENTERPRISECODERF,MULTICASTVERSIONRF DESC,MULTICASTCONSNORF,MULTICASTSUBCODERF ";
                    wkstr += " ORDER BY MCASTGIDNCCNTNTSCDRF, PRODUCTCODERF, MCASTGIDNCVERSIONCDRF DESC, MCASTOFFERDIVCDRF, UPDATEGROUPCODERF, ENTERPRISECODERF, MULTICASTCONSNORF, MULTICASTSUBCODERF ";

                    sqlCommand.CommandText += wkstr;

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        wkCls = new ChgGidncDtWork();

                        wkCls.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkCls.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkCls.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkCls.McastGidncCntntsCd   = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTGIDNCCNTNTSCDRF"));
                        wkCls.ProductCode          = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("PRODUCTCODERF"));
                        wkCls.McastGidncVersionCd  = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("MCASTGIDNCVERSIONCDRF"));
                        wkCls.McastOfferDivCd      = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTOFFERDIVCDRF"));
                        wkCls.UpdateGroupCode      = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("UPDATEGROUPCODERF"));
                        wkCls.EnterpriseCode       = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                        wkCls.MulticastConsNo      = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MULTICASTCONSNORF"));
                        wkCls.MulticastSubCode     = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MULTICASTSUBCODERF"));
                        wkCls.ChangeContents       = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("CHANGECONTENTSRF"));
                        wkCls.AnothersheetFileExst = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("ANOTHERSHEETFILEEXSTRF"));
                        wkCls.AnothersheetFileName = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("ANOTHERSHEETFILENAMERF"));

                        //ChgGidncDtWorkList.Add(wkCls);  //Del 2007.12.10 Kouguchi
                        //Add ↓↓↓ 2007.12.10 Kouguchi
                        string wkDtDM = "";
                        if ((wkCls.McastGidncVersionCd != "") && (wkCls.McastGidncVersionCd != null))
                        {
                            wkDtDM += wkCls.McastGidncVersionCd.ToString();
                            int myIndexDt = wkDt.IndexOf(wkDtDM);
                            if (myIndexDt < 0)
                            {
                                wkDt.Add(wkDtDM);
                                ChgGidncDtWorkList2.Add(wkCls);
                            }
                        }
                        //Add ↑↑↑ 2007.12.10 Kouguchi

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if ((myReader != null) && (!myReader.IsClosed)) myReader.Close();




                    //Add ↓↓↓ 2007.12.10 Kouguchi
                    //上のSELECTでHITしたデータの「連番」に該当する明細データを追加する。
                    //  (※同一の「連番」でHITしなかった「連番サブコード」分のデータを追加する)

                    // Parameterオブジェクトの作成
                    SqlParameter findParaMcastGidncVersionCd = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCVERSIONCD", SqlDbType.NVarChar );

                    foreach( ChgGidncDtWork wkChgGidncDtWork in ChgGidncDtWorkList2)
                    {    
                        sqlCommand.CommandText = "SELECT * FROM CHGGIDNCDTRF WHERE MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD";
                        wkstr = " ORDER BY MCASTGIDNCCNTNTSCDRF, PRODUCTCODERF, MCASTGIDNCVERSIONCDRF DESC, MCASTOFFERDIVCDRF, UPDATEGROUPCODERF, ENTERPRISECODERF, MULTICASTCONSNORF, MULTICASTSUBCODERF ";
                        sqlCommand.CommandText += wkstr;

                        //Parameterオブジェクトへ値設定
                        findParaMcastGidncVersionCd.Value = SqlDataMediator.SqlSetString(wkChgGidncDtWork.McastGidncVersionCd);


                        myReader = sqlCommand.ExecuteReader();

                        while (myReader.Read())
                        {
                            wkCls = new ChgGidncDtWork();

                            wkCls.CreateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                            wkCls.UpdateDateTime       = SqlDataMediator.SqlGetDateTimeFromTicks(   myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                            wkCls.LogicalDeleteCode    = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                            wkCls.McastGidncCntntsCd   = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTGIDNCCNTNTSCDRF"));
                            wkCls.ProductCode          = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("PRODUCTCODERF"));
                            wkCls.McastGidncVersionCd  = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("MCASTGIDNCVERSIONCDRF"));
                            wkCls.McastOfferDivCd      = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MCASTOFFERDIVCDRF"));
                            wkCls.UpdateGroupCode      = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("UPDATEGROUPCODERF"));
                            wkCls.EnterpriseCode       = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                            wkCls.MulticastConsNo      = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MULTICASTCONSNORF"));
                            wkCls.MulticastSubCode     = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("MULTICASTSUBCODERF"));
                            wkCls.ChangeContents       = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("CHANGECONTENTSRF"));
                            wkCls.AnothersheetFileExst = SqlDataMediator.SqlGetInt32(               myReader, myReader.GetOrdinal("ANOTHERSHEETFILEEXSTRF"));
                            wkCls.AnothersheetFileName = SqlDataMediator.SqlGetString(              myReader, myReader.GetOrdinal("ANOTHERSHEETFILENAMERF"));

                            //ChgGidncDtWorkList.Add(wkCls);
                            string wkDtDM2 = "";
                            if ((wkCls.McastGidncVersionCd != "") && (wkCls.McastGidncVersionCd != null))
                            {
                                // 2008/02/16 Maki Add ↓↓
                                if (wkCls.McastGidncCntntsCd == 1) {
                                    wkDtDM2 += wkCls.McastGidncVersionCd.ToString() + "-"
                                        + wkCls.MulticastConsNo.ToString() + "-" + wkCls.MulticastSubCode.ToString();
                                }
                                else {
                                    wkDtDM2 += wkCls.McastGidncVersionCd.ToString() + "-" + wkCls.MulticastSubCode.ToString();
                                }
                                // Add ↑↑
                                int myIndexDt2 = wkDt2.IndexOf(wkDtDM2);
                                if (myIndexDt2 < 0)
                                {
                                    wkDt2.Add(wkDtDM2);
                                    ChgGidncDtWorkList.Add(wkCls);
                                }
                            }

                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        if((myReader != null) && (myReader.IsClosed == false)) myReader.Close();
                    }
                    if((myReader != null) && (myReader.IsClosed == false)) myReader.Close();
                    //Add ↑↑↑ 2007.12.10 Kouguchi

                }
            }
            catch (SqlException ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = ex.ToString();
            }
            catch (Exception e)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                errMessage = e.ToString();
            }
            finally
            {
                if ((myReader != null) && (!myReader.IsClosed)) myReader.Close();
                if (sqlCommand != null) sqlCommand.Dispose();
            }
            return status;
        }
        #endregion

        #region private string KeyWhereString(ref SqlCommand sqlCommand, ChangGidncParaWork paradata)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="paradata"></param>
        /// <returns></returns>
        private string KeyWhereString(ref SqlCommand sqlCommand, ChangGidncParaWork paradata, int tablejudge)
        {
            string retstring = "";
            string CHANGGIDNCRF = "";
            string CHGGIDNCDTRF = "";

            if (tablejudge == 1)
            {
                CHANGGIDNCRF = "CHANGGIDNCRF";
                CHGGIDNCDTRF = "CHGGIDNCDTRF";
            }
            else
            {
                CHANGGIDNCRF = "CHANGGIDNCRF2";
                CHGGIDNCDTRF = "CHGGIDNCDTRF2";
            }

            #region 案内区分
            //if (paradata.McastGidncCntntsCd >= 0)
            if (paradata.McastGidncCntntsCd > 0)
            {
                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD ";
                    SqlParameter findParaMcastGidncCntntsCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCCNTNTSCD", SqlDbType.Int);
                    findParaMcastGidncCntntsCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastGidncCntntsCd);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD2 ";
                    SqlParameter findParaMcastGidncCntntsCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCCNTNTSCD2", SqlDbType.Int);
                    findParaMcastGidncCntntsCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastGidncCntntsCd);
                }
            }
            #endregion

            # region パッケージ区分
            if ((paradata.ProductCode != null) && (paradata.ProductCode != ""))
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".PRODUCTCODERF=@FINDPRODUCTCODE ";
                    SqlParameter findParaProductCode = sqlCommand.Parameters.Add("@FINDPRODUCTCODE", SqlDbType.NVarChar);
                    findParaProductCode.Value = SqlDataMediator.SqlSetString(paradata.ProductCode);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".PRODUCTCODERF=@FINDPRODUCTCODE2 ";
                    SqlParameter findParaProductCode = sqlCommand.Parameters.Add("@FINDPRODUCTCODE2", SqlDbType.NVarChar);
                    findParaProductCode.Value = SqlDataMediator.SqlSetString(paradata.ProductCode);
                }
            }
            #endregion

            #region 配信提供区分
            if (paradata.McastOfferDivCd == 0)  //標準
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD ";
                    SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD", SqlDbType.Int);
                    findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastOfferDivCd);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD2 ";
                    SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD2", SqlDbType.Int);
                    findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastOfferDivCd);
                }
            }
            else 
            if (paradata.McastOfferDivCd == 1)  //個別
            {
                if (retstring != "") retstring += " AND ";

                if ((paradata.UpdateGroupCode != null) && (paradata.McastOfferDivCd != 0))  retstring += "(";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD ";
                    SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD", SqlDbType.Int);
                    findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastOfferDivCd);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD2 ";
                    SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD2", SqlDbType.Int);
                    findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastOfferDivCd);
                }

                #region 更新グループコード（配列）
                if (((paradata.UpdateGroupCode != null)&&(paradata.UpdateGroupCode.Length > 0)) && (paradata.McastOfferDivCd != 0))
                {
                    if (retstring != "") retstring += " AND ";

                    retstring += CHANGGIDNCRF + ".UPDATEGROUPCODERF IN( ";
                    StringBuilder UpGrCdArag = new StringBuilder("");
                    foreach (string wkstr in paradata.UpdateGroupCode)
                    {
                        if (UpGrCdArag.Length > 0)
                        {
                            UpGrCdArag.Append(",");
                        }
                        UpGrCdArag.Append("'" + wkstr + "'");
                    }
                    retstring += UpGrCdArag.ToString() + ")";
                    retstring += ")";
                }
                #endregion

                #region 企業コード
                if ((paradata.EnterpriseCode != null) && (paradata.EnterpriseCode != ""))
                {
                    if ((paradata.UpdateGroupCode != null) && (paradata.McastOfferDivCd != 0))  retstring += " OR (";  else  retstring += " AND ";

                    if (tablejudge == 1)
                    {
                        retstring += CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD AND " + CHANGGIDNCRF + ".ENTERPRISECODERF=@FINDENTERPRISECODE ";
                        if ((paradata.UpdateGroupCode != null) && (paradata.McastOfferDivCd != 0))  retstring += ")";
                        SqlParameter findParaMcastOfferDivCd1 = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD", SqlDbType.Int);
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaMcastOfferDivCd1.Value = SqlDataMediator.SqlSetInt32(paradata.McastOfferDivCd);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paradata.EnterpriseCode);
                    }
                    else
                    {
                        retstring += CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD2 AND " + CHANGGIDNCRF + ".ENTERPRISECODERF=@FINDENTERPRISECODE2 ";
                        if ((paradata.UpdateGroupCode != null) && (paradata.McastOfferDivCd != 0))  retstring += ")";
                        SqlParameter findParaMcastOfferDivCd1 = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD2", SqlDbType.Int);
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE2", SqlDbType.NChar);
                        findParaMcastOfferDivCd1.Value = SqlDataMediator.SqlSetInt32(paradata.McastOfferDivCd);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paradata.EnterpriseCode);
                    }
                }
                #endregion

            }
            else 
            if (paradata.McastOfferDivCd == -1)  //マージ
            {
                #region 更新グループコード（有）＆　企業コード（有）の場合
                if (((paradata.UpdateGroupCode != null)&&(paradata.UpdateGroupCode.Length > 0)) && ((paradata.EnterpriseCode != null) && (paradata.EnterpriseCode != "")))
                {
                    if (retstring != "") retstring += " AND ";

                    if (tablejudge == 1)
                    {
                        retstring += " (" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD) OR ";
                        
                        retstring += "(";
                        
                        retstring += "(" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD2 AND ";

                        retstring += CHANGGIDNCRF + ".UPDATEGROUPCODERF IN( ";
                        StringBuilder UpGrCdArag = new StringBuilder("");
                        foreach (string wkstr in paradata.UpdateGroupCode)
                        {
                            if (UpGrCdArag.Length > 0)
                            {
                                UpGrCdArag.Append(",");
                            }
                            UpGrCdArag.Append("'" + wkstr + "'");
                        }
                        retstring += UpGrCdArag.ToString() + ")";

                        retstring += ") OR ";
                        
                        retstring += "(" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD2 AND " + CHANGGIDNCRF + ".ENTERPRISECODERF=@FINDENTERPRISECODE)";
                        
                        retstring += ")";

                        SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD", SqlDbType.Int);
                        SqlParameter findParaMcastOfferDivCd2 = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD2", SqlDbType.Int);
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                        findParaMcastOfferDivCd2.Value = SqlDataMediator.SqlSetInt32(1);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paradata.EnterpriseCode);
                    }
                    else
                    {
                        retstring += " (" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD2) OR ";
                        
                        retstring += "(";
                        
                        retstring += "(" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD3 AND ";

                        retstring += CHANGGIDNCRF + ".UPDATEGROUPCODERF IN( ";
                        StringBuilder UpGrCdArag = new StringBuilder("");
                        foreach (string wkstr in paradata.UpdateGroupCode)
                        {
                            if (UpGrCdArag.Length > 0)
                            {
                                UpGrCdArag.Append(",");
                            }
                            UpGrCdArag.Append("'" + wkstr + "'");
                        }
                        retstring += UpGrCdArag.ToString() + ")";
                        
                        retstring += ") OR ";
                        
                        retstring += "(" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD3 AND " + CHANGGIDNCRF + ".ENTERPRISECODERF=@FINDENTERPRISECODE2)";
                        
                        retstring += ")";

                        SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD2", SqlDbType.Int);
                        SqlParameter findParaMcastOfferDivCd2 = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD3", SqlDbType.Int);
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE2", SqlDbType.NChar);
                        findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                        findParaMcastOfferDivCd2.Value = SqlDataMediator.SqlSetInt32(1);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paradata.EnterpriseCode);
                    }
                }
                #endregion

                #region 更新グループコード（有）＆　企業コード（無）の場合
                if (((paradata.UpdateGroupCode != null)&&(paradata.UpdateGroupCode.Length > 0)) && ((paradata.EnterpriseCode == null) || (paradata.EnterpriseCode == "")))
                {
                    if (retstring != "") retstring += " AND ";

                    if (tablejudge == 1)
                    {
                        retstring += " (" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD) OR ";
                        
                        retstring += "(";
                        
                        retstring += "(" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD2 AND ";

                        retstring += CHANGGIDNCRF + ".UPDATEGROUPCODERF IN(";
                        StringBuilder UpGrCdArag = new StringBuilder("");
                        foreach (string wkstr in paradata.UpdateGroupCode)
                        {
                            if (UpGrCdArag.Length > 0)
                            {
                                UpGrCdArag.Append(",");
                            }
                            UpGrCdArag.Append("'" + wkstr + "'");
                        }
                        retstring += UpGrCdArag.ToString() + ")";
                        
                        retstring += ")";
                        
                        retstring += ")";

                        SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD", SqlDbType.Int);
                        SqlParameter findParaMcastOfferDivCd2 = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD2", SqlDbType.Int);
                        findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                        findParaMcastOfferDivCd2.Value = SqlDataMediator.SqlSetInt32(1);
                    }
                    else
                    {
                        retstring += " (" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD2) OR ";
                        
                        retstring += "(";
                        
                        retstring += "(" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD3 AND ";

                        retstring += CHANGGIDNCRF + ".UPDATEGROUPCODERF IN(";
                        StringBuilder UpGrCdArag = new StringBuilder("");
                        foreach (string wkstr in paradata.UpdateGroupCode)
                        {
                            if (UpGrCdArag.Length > 0)
                            {
                                UpGrCdArag.Append(",");
                            }
                            UpGrCdArag.Append("'" + wkstr + "'");
                        }
                        retstring += UpGrCdArag.ToString() + ")";
                        
                        retstring += ")";
                        
                        retstring += ")";

                        SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD2", SqlDbType.Int);
                        SqlParameter findParaMcastOfferDivCd2 = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD3", SqlDbType.Int);
                        findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                        findParaMcastOfferDivCd2.Value = SqlDataMediator.SqlSetInt32(1);
                    }
                }
                #endregion

                #region 更新グループコード（無）＆　企業コード（有）の場合
                if (((paradata.UpdateGroupCode != null)&&(paradata.UpdateGroupCode.Length == 0)) && ((paradata.EnterpriseCode != null) && (paradata.EnterpriseCode != "")))
                {
                    if (retstring != "") retstring += " AND ";

                    if (tablejudge == 1)
                    {
                        retstring += " (";
                        
                        retstring += "(" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD) OR ";
                        
                        retstring += "(" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD2 AND " + CHANGGIDNCRF + ".ENTERPRISECODERF=@FINDENTERPRISECODE)";
                        
                        retstring += ")";

                        SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD", SqlDbType.Int);
                        SqlParameter findParaMcastOfferDivCd2 = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD2", SqlDbType.Int);
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                        findParaMcastOfferDivCd2.Value = SqlDataMediator.SqlSetInt32(1);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paradata.EnterpriseCode);
                    }
                    else
                    {
                        retstring += " (";
                        
                        retstring += "(" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD2) OR ";

                        retstring += "(" + CHANGGIDNCRF + ".MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD3 AND " + CHANGGIDNCRF + ".ENTERPRISECODERF=@FINDENTERPRISECODE2)";
                        
                        retstring += ")";

                        SqlParameter findParaMcastOfferDivCd = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD2", SqlDbType.Int);
                        SqlParameter findParaMcastOfferDivCd2 = sqlCommand.Parameters.Add("@FINDMCASTOFFERDIVCD3", SqlDbType.Int);
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE2", SqlDbType.NChar);
                        findParaMcastOfferDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                        findParaMcastOfferDivCd2.Value = SqlDataMediator.SqlSetInt32(1);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(paradata.EnterpriseCode);
                    }
                }
                #endregion

            }
            #endregion

            #region 公開日時（サポート公開日時）
            if ((paradata.OpenDtTmDiv == 1) && (paradata.StdDate != 0))
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".SUPPORTOPENTIMERF <= @FINDSUPPORTOPENTIME ";
                    SqlParameter findParaSupportOpenTime = sqlCommand.Parameters.Add("@FINDSUPPORTOPENTIME", SqlDbType.BigInt);
                    findParaSupportOpenTime.Value = SqlDataMediator.SqlSetInt64(paradata.StdDate);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".SUPPORTOPENTIMERF <= @FINDSUPPORTOPENTIME2 ";
                    SqlParameter findParaSupportOpenTime = sqlCommand.Parameters.Add("@FINDSUPPORTOPENTIME2", SqlDbType.BigInt);
                    findParaSupportOpenTime.Value = SqlDataMediator.SqlSetInt64(paradata.StdDate);
                }
            }
            #endregion

            #region 公開日時（ユーザー公開日時）
            if ((paradata.OpenDtTmDiv == 2) && (paradata.StdDate != 0))
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".CUSTOMEROPENTIMERF <= @FINDCUSTOMEROPENTIME ";
                    SqlParameter findParaCustomerOpenTime = sqlCommand.Parameters.Add("@FINDCUSTOMEROPENTIME", SqlDbType.BigInt);
                    findParaCustomerOpenTime.Value = SqlDataMediator.SqlSetInt64(paradata.StdDate);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".CUSTOMEROPENTIMERF <= @FINDCUSTOMEROPENTIME2 ";
                    SqlParameter findParaCustomerOpenTime = sqlCommand.Parameters.Add("@FINDCUSTOMEROPENTIME2", SqlDbType.BigInt);
                    findParaCustomerOpenTime.Value = SqlDataMediator.SqlSetInt64(paradata.StdDate);
                }
            }
            #endregion

            #region 配信バージョン
            if ((paradata.MulticastVersion != null) && (paradata.MulticastVersion != ""))
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    //retstring += CHANGGIDNCRF + ".MULTICASTVERSIONRF=@FINDMULTICASTVERSION ";
                    retstring += CHANGGIDNCRF + ".MCASTGIDNCVERSIONCDRF=@FINDMULTICASTVERSION ";
                    SqlParameter findParaMulticastVersion = sqlCommand.Parameters.Add("@FINDMULTICASTVERSION", SqlDbType.NVarChar);
                    findParaMulticastVersion.Value = SqlDataMediator.SqlSetString(paradata.MulticastVersion);
                }
                else
                {
                    //retstring += CHANGGIDNCRF + ".MULTICASTVERSIONRF=@FINDMULTICASTVERSION2 ";
                    retstring += CHANGGIDNCRF + ".MCASTGIDNCVERSIONCDRF=@FINDMULTICASTVERSION2 ";
                    SqlParameter findParaMulticastVersion = sqlCommand.Parameters.Add("@FINDMULTICASTVERSION2", SqlDbType.NVarChar);
                    findParaMulticastVersion.Value = SqlDataMediator.SqlSetString(paradata.MulticastVersion);
                }
            }
            #endregion

            #region 配信連番
            if (paradata.MulticastConsNo > 0)
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".MULTICASTCONSNORF=@FINDMULTICASTCONSNO ";
                    SqlParameter findParaMulticastConsNo = sqlCommand.Parameters.Add("@FINDMULTICASTCONSNO", SqlDbType.Int);
                    findParaMulticastConsNo.Value = SqlDataMediator.SqlSetInt32(paradata.MulticastConsNo);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".MULTICASTCONSNORF=@FINDMULTICASTCONSNO2 ";
                    SqlParameter findParaMulticastConsNo = sqlCommand.Parameters.Add("@FINDMULTICASTCONSNO2", SqlDbType.Int);
                    findParaMulticastConsNo.Value = SqlDataMediator.SqlSetInt32(paradata.MulticastConsNo);
                }
            }
            #endregion

            #region 配信日開始
            if ((paradata.StMulticastDate != null) && (paradata.StMulticastDate != DateTime.MinValue))
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".MULTICASTDATERF >= @FINDSTMULTICASTDATE ";
                    SqlParameter findParaStMulticastDate = sqlCommand.Parameters.Add("@FINDSTMULTICASTDATE", SqlDbType.Int);
                    findParaStMulticastDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paradata.StMulticastDate);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".MULTICASTDATERF >= @FINDSTMULTICASTDATE2 ";
                    SqlParameter findParaStMulticastDate = sqlCommand.Parameters.Add("@FINDSTMULTICASTDATE2", SqlDbType.Int);
                    findParaStMulticastDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paradata.StMulticastDate);
                }
            }
            #endregion

            #region 配信日終了
            if ((paradata.EdMulticastDate != null) && (paradata.EdMulticastDate != DateTime.MinValue))
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".MULTICASTDATERF <= @FINDEDMULTICASTDATE ";
                    SqlParameter findParaEdMulticastDate = sqlCommand.Parameters.Add("@FINDEDMULTICASTDATE", SqlDbType.Int);
                    findParaEdMulticastDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paradata.EdMulticastDate);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".MULTICASTDATERF <= @FINDEDMULTICASTDATE2 ";
                    SqlParameter findParaStMulticastDate = sqlCommand.Parameters.Add("@FINDEDMULTICASTDATE2", SqlDbType.Int);
                    findParaStMulticastDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paradata.StMulticastDate);
                }
            }
            #endregion

            #region 配信バージョン開始
            if ((paradata.StMulticastVersion != null) && (paradata.StMulticastVersion != ""))
            { 
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    //retstring += CHANGGIDNCRF + ".MULTICASTVERSIONRF >= @FINDSTMULTICASTVERSION ";
                    retstring += CHANGGIDNCRF + ".MCASTGIDNCVERSIONCDRF >= @FINDSTMULTICASTVERSION ";
                    SqlParameter findParaStMulticastVersion = sqlCommand.Parameters.Add("@FINDSTMULTICASTVERSION", SqlDbType.NVarChar);
                    findParaStMulticastVersion.Value = SqlDataMediator.SqlSetString(paradata.StMulticastVersion);
                }
                else
                {
                    //retstring += CHANGGIDNCRF + ".MULTICASTVERSIONRF >= @FINDSTMULTICASTVERSION2 ";
                    retstring += CHANGGIDNCRF + ".MCASTGIDNCVERSIONCDRF >= @FINDSTMULTICASTVERSION2 ";
                    SqlParameter findParaStMulticastVersion = sqlCommand.Parameters.Add("@FINDSTMULTICASTVERSION2", SqlDbType.NVarChar);
                    findParaStMulticastVersion.Value = SqlDataMediator.SqlSetString(paradata.StMulticastVersion);
                }
            }
            #endregion

            #region 配信バージョン終了
            if ((paradata.EdMulticastVersion != null) && (paradata.EdMulticastVersion != ""))
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    //retstring += CHANGGIDNCRF + ".MULTICASTVERSIONRF <= @FINDEDMULTICASTVERSION ";
                    retstring += CHANGGIDNCRF + ".MCASTGIDNCVERSIONCDRF <= @FINDEDMULTICASTVERSION ";
                    SqlParameter findParaEdMulticastVersion = sqlCommand.Parameters.Add("@FINDEDMULTICASTVERSION", SqlDbType.NVarChar);
                    findParaEdMulticastVersion.Value = SqlDataMediator.SqlSetString(paradata.EdMulticastVersion);
                }
                else
                {
                    //retstring += CHANGGIDNCRF + ".MULTICASTVERSIONRF <= @FINDEDMULTICASTVERSION2 ";
                    retstring += CHANGGIDNCRF + ".MCASTGIDNCVERSIONCDRF <= @FINDEDMULTICASTVERSION2 ";
                    SqlParameter findParaEdMulticastVersion = sqlCommand.Parameters.Add("@FINDEDMULTICASTVERSION2", SqlDbType.NVarChar);
                    findParaEdMulticastVersion.Value = SqlDataMediator.SqlSetString(paradata.EdMulticastVersion);
                }
            }
            #endregion

            #region 配信システム区分
            if (paradata.MulticastSystemDivCd >= 0)
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    //retstring += CHANGGIDNCRF + ".MULTICASTSYSTEMDIVCDRF=@FINDMULTICASTSYSTEMDIVCD ";
                    retstring += CHANGGIDNCRF + ".SYSTEMDIVCDRF=@FINDMULTICASTSYSTEMDIVCD ";
                    SqlParameter findParaMulticastSystemDivCd = sqlCommand.Parameters.Add("@FINDMULTICASTSYSTEMDIVCD", SqlDbType.Int);
                    findParaMulticastSystemDivCd.Value = SqlDataMediator.SqlSetInt32(paradata.MulticastSystemDivCd);
                }
                else
                {
                    //retstring += CHANGGIDNCRF + ".MULTICASTSYSTEMDIVCDRF=@FINDMULTICASTSYSTEMDIVCD2 ";
                    retstring += CHANGGIDNCRF + ".SYSTEMDIVCDRF=@FINDMULTICASTSYSTEMDIVCD2 ";
                    SqlParameter findParaMulticastSystemDivCd = sqlCommand.Parameters.Add("@FINDMULTICASTSYSTEMDIVCD2", SqlDbType.Int);
                    findParaMulticastSystemDivCd.Value = SqlDataMediator.SqlSetInt32(paradata.MulticastSystemDivCd);
                }
            }
            #endregion

            #region 配信プログラム名称
            if ((paradata.MulticastProgramName != null) && (paradata.MulticastProgramName != ""))
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    //retstring += CHANGGIDNCRF + ".MULTICASTPROGRAMNAMERF LIKE @FINDMULTICASTPROGRAMNAME ";
                    retstring += CHANGGIDNCRF + ".GUIDANCE1RF LIKE @FINDMULTICASTPROGRAMNAME ";
                    SqlParameter findParaMulticastProgramName = sqlCommand.Parameters.Add("@FINDMULTICASTPROGRAMNAME", SqlDbType.NVarChar);
                    findParaMulticastProgramName.Value = SqlDataMediator.SqlSetString("%" + paradata.MulticastProgramName + "%");
                }
                else
                {
                    //retstring += CHANGGIDNCRF + ".MULTICASTPROGRAMNAMERF LIKE @FINDMULTICASTPROGRAMNAME2 ";
                    retstring += CHANGGIDNCRF + ".GUIDANCE1RF LIKE @FINDMULTICASTPROGRAMNAME2 ";
                    SqlParameter findParaMulticastProgramName = sqlCommand.Parameters.Add("@FINDMULTICASTPROGRAMNAME2", SqlDbType.NVarChar);
                    findParaMulticastProgramName.Value = SqlDataMediator.SqlSetString("%" + paradata.MulticastProgramName + "%");
                }
            }
            #endregion

            #region 変更内容
            if ((paradata.ChangeContents != null) && (paradata.ChangeContents.Length != 0))
            {
                if (retstring != "")  retstring += " AND(";

                StringBuilder wkstbil = new StringBuilder();
                foreach (string wkstr in paradata.ChangeContents)
                {
                    if (wkstbil.Length != 0)
                    {
                        wkstbil.Append(" AND ");
                    }

                    wkstbil.Append(CHGGIDNCDTRF);
                    wkstbil.Append(".CHANGECONTENTSRF LIKE '%" + wkstr + "%'");
                }
                wkstbil.Append(")");

                retstring += wkstbil.ToString();
            }
            #endregion

            # region 地域
            if ((paradata.Area != null) && (paradata.Area != ""))
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".AREARF LIKE @FINDAREA ";
                    SqlParameter findParaArea = sqlCommand.Parameters.Add("@FINDAREA", SqlDbType.NVarChar);
                    findParaArea.Value = SqlDataMediator.SqlSetString("%" + paradata.Area + "%");
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".AREARF LIKE @FINDAREA2 ";
                    SqlParameter findParaArea = sqlCommand.Parameters.Add("@FINDAREA2", SqlDbType.NVarChar);
                    findParaArea.Value = SqlDataMediator.SqlSetString("%" + paradata.Area + "%");
                }
            }
            #endregion

            #region メンテ区分
            //if (paradata.McastGidncMainteCd > 0)
            //{
            //    if (retstring != "") retstring += " AND ";

            //    if (tablejudge == 1)
            //    {
            //        retstring += CHANGGIDNCRF + ".MCASTGIDNCMAINTECDRF=@FINDMCASTGIDNCMAINTECD ";
            //        SqlParameter findParaMcastGidncMainteCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCMAINTECD", SqlDbType.Int);
            //        findParaMcastGidncMainteCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastGidncMainteCd);
            //    }
            //    else
            //    {
            //        retstring += CHANGGIDNCRF + ".MCASTGIDNCMAINTECDRF=@FINDMCASTGIDNCMAINTECD2 ";
            //        SqlParameter findParaMcastGidncMainteCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCMAINTECD2", SqlDbType.Int);
            //        findParaMcastGidncMainteCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastGidncMainteCd);
            //    }
            //}
            if ((paradata.McastGidncCntntsCd == -1) && (paradata.McastGidncMainteCd == 2))
            {
                if (retstring != "") retstring += " AND ";

                retstring += " ( ";
                retstring += CHANGGIDNCRF + ".MCASTGIDNCCNTNTSCDRF=1 OR " + CHANGGIDNCRF + ".MCASTGIDNCCNTNTSCDRF=3 OR ";
                retstring += " ( " + CHANGGIDNCRF + ".MCASTGIDNCCNTNTSCDRF=2 AND " + CHANGGIDNCRF + ".MCASTGIDNCMAINTECDRF=2 ) ";
                retstring += " ) ";
            }
            else
            if ((paradata.McastGidncCntntsCd == 2) && (paradata.McastGidncMainteCd == -1))
            {
                if (retstring != "") retstring += " AND ";

                retstring += " ( ";
                retstring += " ( " + CHANGGIDNCRF + ".MCASTGIDNCCNTNTSCDRF=2 AND " + CHANGGIDNCRF + ".MCASTGIDNCMAINTECDRF=1 ) OR ";
                retstring += " ( " + CHANGGIDNCRF + ".MCASTGIDNCCNTNTSCDRF=2 AND " + CHANGGIDNCRF + ".MCASTGIDNCMAINTECDRF=9 ) ";
                retstring += " ) ";
            }
            else
            {
                if (paradata.McastGidncMainteCd > 0)
                {
                    if (retstring != "") retstring += " AND ";

                    if (tablejudge == 1)
                    {
                        retstring += CHANGGIDNCRF + ".MCASTGIDNCMAINTECDRF=@FINDMCASTGIDNCMAINTECD ";
                        SqlParameter findParaMcastGidncMainteCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCMAINTECD", SqlDbType.Int);
                        findParaMcastGidncMainteCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastGidncMainteCd);
                    }
                    else
                    {
                        retstring += CHANGGIDNCRF + ".MCASTGIDNCMAINTECDRF=@FINDMCASTGIDNCMAINTECD2 ";
                        SqlParameter findParaMcastGidncMainteCd = sqlCommand.Parameters.Add("@FINDMCASTGIDNCMAINTECD2", SqlDbType.Int);
                        findParaMcastGidncMainteCd.Value = SqlDataMediator.SqlSetInt32(paradata.McastGidncMainteCd);
                    }
                }
            }
            #endregion


            #region メンテナンス予定日　開始 (メンテンンス予定日時 "開始" でチェック)
            //↓↓↓ 2008.02.20  Add Kouguchi
            if  (paradata.StServerMainteScdl > 0)
//          if  ((paradata.EdServerMainteScdl != null) && (paradata.EdServerMainteScdl != DateTime.MinValue))
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".SERVERMAINTESTSCDLRF >= @FINDSTSERVERMAINTESCDL ";
                    SqlParameter findParaStServerMainteScdl = sqlCommand.Parameters.Add("@FINDSTSERVERMAINTESCDL", SqlDbType.BigInt);
                    findParaStServerMainteScdl.Value = SqlDataMediator.SqlSetInt64(paradata.StServerMainteScdl);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".SERVERMAINTESTSCDLRF >= @FINDSTSERVERMAINTESCDL2 ";
                    SqlParameter findParaStServerMainteScdl = sqlCommand.Parameters.Add("@FINDSTSERVERMAINTESCDL2", SqlDbType.BigInt);
                    findParaStServerMainteScdl.Value = SqlDataMediator.SqlSetInt64(paradata.StServerMainteScdl);
                }
            }
            //↑↑↑ 2008.02.20  Add Kouguchi
            #endregion

            #region メンテナンス予定日　終了 (メンテンンス予定日時 "開始" でチェック)
            //↓↓↓ 2008.02.20  Add Kouguchi
            if  (paradata.EdServerMainteScdl > 0)
            {
                if (retstring != "") retstring += " AND ";

                if (tablejudge == 1)
                {
                    retstring += CHANGGIDNCRF + ".SERVERMAINTESTSCDLRF <= @FINDEDSERVERMAINTESCDL ";
                    SqlParameter findParaEdServerMainteScdl = sqlCommand.Parameters.Add("@FINDEDSERVERMAINTESCDL", SqlDbType.BigInt);
                    findParaEdServerMainteScdl.Value = SqlDataMediator.SqlSetInt64(paradata.EdServerMainteScdl);
                }
                else
                {
                    retstring += CHANGGIDNCRF + ".SERVERMAINTESTSCDLRF <= @FINDEDSERVERMAINTESCDL2 ";
                    SqlParameter findParaEdServerMainteScdl = sqlCommand.Parameters.Add("@FINDEDSERVERMAINTESCDL2", SqlDbType.BigInt);
                    findParaEdServerMainteScdl.Value = SqlDataMediator.SqlSetInt64(paradata.EdServerMainteScdl);
                }
            }
            //↑↑↑ 2008.02.20  Add Kouguchi
            #endregion

            return retstring;
        }
        #endregion

        #region private string PgMulcasWhereString(ref SqlCommand sqlCommand, ChangGidncParaWork paradata)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="paradata"></param>
        /// <returns></returns>
        private string PgMulcasWhereString(ref SqlCommand sqlCommand, ChangGidncParaWork paradata)
        {
            string retstring = "";

            ////公開日時（サポート公開日時）
            //if ((paradata.OpenDtTmDiv == 1) && (paradata.StdDate != 0))
            //{
            //    retstring += " AND SUPPORTOPENTIMERF <= @FINDSUPPORTOPENTIME ";
            //    SqlParameter findParaSupportOpenTime = sqlCommand.Parameters.Add("@FINDSUPPORTOPENTIME", SqlDbType.BigInt);
            //    findParaSupportOpenTime.Value = SqlDataMediator.SqlSetInt64(paradata.StdDate);
            //}
            ////公開日時（ユーザー公開日時）
            //if ((paradata.OpenDtTmDiv == 2) && (paradata.StdDate != 0))
            //{
            //    retstring += " AND CUSTOMEROPENTIMERF <= @FINDCUSTOMEROPENTIME ";
            //    SqlParameter findParaCustomerOpenTime = sqlCommand.Parameters.Add("@FINDCUSTOMEROPENTIME", SqlDbType.Int);
            //    findParaCustomerOpenTime.Value = SqlDataMediator.SqlSetInt64(paradata.StdDate);
            //}
            //配信連番
            if (paradata.MulticastConsNo > 0)
            {
                retstring += " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO ";
                SqlParameter findParaMulticastConsNo = sqlCommand.Parameters.Add("@FINDMULTICASTCONSNO", SqlDbType.Int);
                findParaMulticastConsNo.Value = SqlDataMediator.SqlSetInt32(paradata.MulticastConsNo);
            }
            ////配信日開始
            //if ((paradata.StMulticastDate != null) && (paradata.StMulticastDate != DateTime.MinValue))
            //{
            //    retstring += " AND MULTICASTDATERF >= @FINDSTMULTICASTDATE ";
            //    SqlParameter findParaStMulticastDate = sqlCommand.Parameters.Add("@FINDSTMULTICASTDATE", SqlDbType.Int);
            //    findParaStMulticastDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paradata.StMulticastDate);
            //}
            ////配信日終了
            //if ((paradata.EdMulticastDate != null) && (paradata.EdMulticastDate != DateTime.MinValue))
            //{
            //    retstring += " AND MULTICASTDATERF <= @FINDEDMULTICASTDATE ";
            //    SqlParameter findParaEdMulticastDate = sqlCommand.Parameters.Add("@FINDEDMULTICASTDATE", SqlDbType.Int);
            //    findParaEdMulticastDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paradata.EdMulticastDate);
            //}
            ////配信バージョン開始
            //if ((paradata.StMulticastVersion != null) && (paradata.StMulticastVersion != ""))
            //{
            ////    retstring += " AND MULTICASTVERSIONRF >= @FINDSTMULTICASTVERSION ";
            //    retstring += " AND MCASTGIDNCVERSIONCDRF >= @FINDSTMULTICASTVERSION ";
            //    SqlParameter findParaStMulticastVersion = sqlCommand.Parameters.Add("@FINDSTMULTICASTVERSION", SqlDbType.NVarChar);
            //    findParaStMulticastVersion.Value = SqlDataMediator.SqlSetString(paradata.StMulticastVersion);
            //}
            ////配信バージョン終了
            //if ((paradata.EdMulticastVersion != null) && (paradata.EdMulticastVersion != ""))
            //{
            ////    retstring += " AND MULTICASTVERSIONRF <= @FINDEDMULTICASTVERSION ";
            //    retstring += " AND MCASTGIDNCVERSIONCDRF <= @FINDEDMULTICASTVERSION ";
            //    SqlParameter findParaEdMulticastVersion = sqlCommand.Parameters.Add("@FINDEDMULTICASTVERSION", SqlDbType.NVarChar);
            //    findParaEdMulticastVersion.Value = SqlDataMediator.SqlSetString(paradata.EdMulticastVersion);
            //}
            //配信システム区分
            if (paradata.MulticastSystemDivCd >= 0)
            {
                //retstring += " AND MULTICASTSYSTEMDIVCDRF=@FINDMULTICASTSYSTEMDIVCD ";
                retstring += " AND SYSTEMDIVCDRF=@FINDMULTICASTSYSTEMDIVCD ";
                SqlParameter findParaMulticastSystemDivCd = sqlCommand.Parameters.Add("@FINDMULTICASTSYSTEMDIVCD", SqlDbType.Int);
                findParaMulticastSystemDivCd.Value = SqlDataMediator.SqlSetInt32(paradata.MulticastSystemDivCd);
            }
            //配信プログラム名称
            if ((paradata.MulticastProgramName != null) && (paradata.MulticastProgramName != ""))
            {
                //retstring += " AND MULTICASTPROGRAMNAMERF LIKE @FINDMULTICASTPROGRAMNAME ";
                retstring += " AND GUIDANCE1RF LIKE @FINDMULTICASTPROGRAMNAME ";
                SqlParameter findParaMulticastProgramName = sqlCommand.Parameters.Add("@FINDMULTICASTPROGRAMNAME", SqlDbType.NVarChar);
                findParaMulticastProgramName.Value = SqlDataMediator.SqlSetString("%" + paradata.MulticastProgramName + "%");
            }

            return retstring;
        }
        #endregion



		#region public int WriteChangGidnc( ref List<ChangGidncWork> changGidncWorkList, ref List<ChgGidncDtWork> chgGidncDtWorkList, List<ChgGidncDtWork> chgGidncDtWorkDelList, out string errMessage )

		/// <summary>
		/// 
		/// </summary>
		/// <param name="changGidncWork"></param>
		/// <param name="chgGidncDtWorkList"></param>
		/// <param name="chgGidncDtWorkDelList"></param>
		/// <param name="errMessage"></param>
		/// <returns></returns>
		public int WriteChangGidnc( ref ChangGidncWork changGidncWork, ref List<ChgGidncDtWork> chgGidncDtWorkList, List<ChgGidncDtWork> chgGidncDtWorkDelList, out string errMessage )
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            errMessage = "";

            ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

			if( changGidncWork == null ) 
            {
				return ( int )ConstantManagement.DB_Status.ctDB_WARNING;
			}
			List<ChangGidncWork> changGidncWorkList = new List<ChangGidncWork>();
			changGidncWorkList.Add( changGidncWork );

			try 
            {
				// 変更PG案内DB接続文字列取得部品より、接続文字列を取得
				ChangePgGuideSqlInfo changePgGuideSqlInfo = new ChangePgGuideSqlInfo();
				string connectionText = changePgGuideSqlInfo.GetConnectionText();
				if( String.IsNullOrEmpty( connectionText ) ) 
                {
					// 接続文字列の取得に失敗
					return status;
				}

				// コネクションオープン
				sqlConnection = new SqlConnection( connectionText );
				sqlConnection.Open();

				// トランザクション開始
				sqlTransaction = sqlConnection.BeginTransaction( ( IsolationLevel )ConstantManagement.DB_IsolationLevel.ctDB_Default );

				// 削除対象のプログラム配信案内明細リストを削除
				status = this.DeleteChgGidncDt( chgGidncDtWorkDelList, out errMessage, ref sqlConnection, ref sqlTransaction );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) 
                {
					// プログラム配信案内リストを登録
					status = this.WriteChangGidnc( ref changGidncWorkList, out errMessage, ref sqlConnection, ref sqlTransaction );
				}

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) 
                {
					if( ( changGidncWorkList != null ) && ( changGidncWorkList.Count > 0 ) ) 
                    {
						changGidncWork = changGidncWorkList[ 0 ];
					}

					// プログラム配信案内明細リストを登録
					status = this.WriteChgGidncDt( ref chgGidncDtWorkList, out errMessage, ref sqlConnection, ref sqlTransaction );
				}


			}
			catch( Exception ex ) 
            {
				// ログを出力
                changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, ex );
				status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
				errMessage = ex.Message;
			}
			finally {
				// コネクション破棄
				if( sqlConnection != null ) 
                {
					// コミットorロールバック
					if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) 
                    {
						sqlTransaction.Commit();
					}
					else 
                    {
						sqlTransaction.Rollback();
					}

					sqlTransaction.Dispose();
					sqlConnection.Close();
				}
			}

			return status;
		}

		#endregion

		#region private int WriteChangGidnc( ref List<ChangGidncWork> changGidncWorkList, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )

		private int WriteChangGidnc( ref List<ChangGidncWork> changGidncWorkList, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
			SqlDataReader myReader = null;
			List<ChangGidncWork> list = new List<ChangGidncWork>();
			errMessage = "";

            ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

			if( changGidncWorkList.Count == 0 ) 
            {
				return ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			try 
            {
				for( int ix = 0; ix < changGidncWorkList.Count; ix++ ) 
                {
					using( SqlCommand sqlCommand = new SqlCommand( "SELECT UPDATEDATETIMERF  FROM CHANGGIDNCRF  WHERE " + 
                    " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD AND PRODUCTCODERF=@FINDPRODUCTCODE " +
                    " AND MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD " +
                    " AND UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE " +
                    " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO ",
                    
                    sqlConnection, sqlTransaction ) ) 
                    {
						ChangGidncWork changGidncWork = changGidncWorkList[ ix ];

						// Parameterオブジェクトの作成
						SqlParameter findParaMcastGidncCntntsCd  = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCCNTNTSCD", SqlDbType.Int );
						SqlParameter findParaProductCode         = sqlCommand.Parameters.Add( "@FINDPRODUCTCODE", SqlDbType.NVarChar );
						SqlParameter findParaMcastGidncVersionCd = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCVERSIONCD", SqlDbType.NVarChar );
						SqlParameter findParaMcastOfferDivCd     = sqlCommand.Parameters.Add( "@FINDMCASTOFFERDIVCD", SqlDbType.Int );
						SqlParameter findParaUpdateGroupCode     = sqlCommand.Parameters.Add( "@FINDUPDATEGROUPCODE", SqlDbType.NVarChar );
						SqlParameter findParaEnterpriseCode      = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
						SqlParameter findParaMulticastConsNo     = sqlCommand.Parameters.Add( "@FINDMULTICASTCONSNO", SqlDbType.Int );

						// Parameterオブジェクトへ値をセット
						findParaMcastGidncCntntsCd.Value  = SqlDataMediator.SqlSetInt32( changGidncWork.McastGidncCntntsCd );
                        findParaProductCode.Value         = SqlDataMediator.SqlSetString( changGidncWork.ProductCode );
						findParaMcastGidncVersionCd.Value = SqlDataMediator.SqlSetString( changGidncWork.McastGidncVersionCd );
						findParaMcastOfferDivCd.Value     = SqlDataMediator.SqlSetInt32( changGidncWork.McastOfferDivCd );
						findParaUpdateGroupCode.Value     = changGidncWork.UpdateGroupCode;  //SqlDataMediator.SqlSetString( changGidncWork.UpdateGroupCode );
						findParaEnterpriseCode.Value      = changGidncWork.EnterpriseCode;  //SqlDataMediator.SqlSetString( changGidncWork.EnterpriseCode );
						findParaMulticastConsNo.Value     = SqlDataMediator.SqlSetInt32( changGidncWork.MulticastConsNo );

						myReader = sqlCommand.ExecuteReader();

						if( myReader.Read() ) 
                        {
							// 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで返す
							DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) );
							if( updateDateTime != changGidncWork.UpdateDateTime ) 
                            {
								// 新規登録で既存データ有りの場合は重複
								if( changGidncWork.UpdateDateTime == DateTime.MinValue ) 
                                {
									status = ( int )ConstantManagement.DB_Status.ctDB_DUPLICATE;
								}
								// 既存データで更新日時が異なる場合は排他
								else 
                                {
									status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
								}
								if( ! myReader.IsClosed ) 
                                {
									myReader.Close();
								}
								return status;
							}

							sqlCommand.CommandText = "UPDATE CHANGGIDNCRF SET " + 
                                "CREATEDATETIMERF=@CREATEDATETIME, UPDATEDATETIMERF=@UPDATEDATETIME, " + 
                                "LOGICALDELETECODERF=@LOGICALDELETECODE, MCASTGIDNCCNTNTSCDRF=@MCASTGIDNCCNTNTSCD, " +
                                "PRODUCTCODERF=@PRODUCTCODE, MCASTGIDNCVERSIONCDRF=@MCASTGIDNCVERSIONCD, " +
                                "MCASTOFFERDIVCDRF=@MCASTOFFERDIVCD, UPDATEGROUPCODERF=@UPDATEGROUPCODE, " +
                                "ENTERPRISECODERF=@ENTERPRISECODE, MULTICASTCONSNORF=@MULTICASTCONSNO, " +
                                "MULTICASTDATERF=@MULTICASTDATE, SUPPORTOPENTIMERF=@SUPPORTOPENTIME, " +
                                "CUSTOMEROPENTIMERF=@CUSTOMEROPENTIME, SERVERMAINTESTSCDLRF=@SERVERMAINTESTSCDL, " +
                                "SERVERMAINTEEDSCDLRF=@SERVERMAINTEEDSCDL, SERVERMAINTESTTIMERF=@SERVERMAINTESTTIME, " +
                                "SERVERMAINTEEDTIMERF=@SERVERMAINTEEDTIME, MCASTGIDNCNEWCUSTMCDRF=@MCASTGIDNCNEWCUSTMCD, " +
                                "MCASTGIDNCMAINTECDRF=@MCASTGIDNCMAINTECD, SYSTEMDIVCDRF=@SYSTEMDIVCD, " +
                                "GUIDANCE1RF=@GUIDANCE1, AREARF=@AREA " +
								"WHERE " +
                                " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD AND PRODUCTCODERF=@FINDPRODUCTCODE " +
                                " AND MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD " +
                                " AND UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE " +
                                " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO ";

							// 更新ヘッダ情報を設定
							changGidncWork.UpdateDateTime = TDateTime.GetSFDateNow();
						}
						else 
                        {
							// 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合は既に削除されている意味で排他を返す
							if( changGidncWork.UpdateDateTime > DateTime.MinValue ) 
                            {
								status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
								if( ! myReader.IsClosed ) 
                                {
									myReader.Close();
								}
								return status;
							}

							sqlCommand.CommandText = "INSERT INTO CHANGGIDNCRF " + 
                                "( CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, MCASTGIDNCCNTNTSCDRF, PRODUCTCODERF, " +
                                "MCASTGIDNCVERSIONCDRF, MCASTOFFERDIVCDRF, UPDATEGROUPCODERF, ENTERPRISECODERF, MULTICASTCONSNORF, " +
                                "MULTICASTDATERF, SUPPORTOPENTIMERF, CUSTOMEROPENTIMERF, SERVERMAINTESTSCDLRF, SERVERMAINTEEDSCDLRF, " +
                                "SERVERMAINTESTTIMERF, SERVERMAINTEEDTIMERF, MCASTGIDNCNEWCUSTMCDRF, MCASTGIDNCMAINTECDRF, SYSTEMDIVCDRF, " +
                                "GUIDANCE1RF, AREARF ) " +
                                "VALUES " + 
                                "( @CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @MCASTGIDNCCNTNTSCD, @PRODUCTCODE, " +
                                "@MCASTGIDNCVERSIONCD, @MCASTOFFERDIVCD, @UPDATEGROUPCODE, @ENTERPRISECODE, @MULTICASTCONSNO, " +
                                "@MULTICASTDATE, @SUPPORTOPENTIME, @CUSTOMEROPENTIME, @SERVERMAINTESTSCDL, @SERVERMAINTEEDSCDL, " +
                                "@SERVERMAINTESTTIME, @SERVERMAINTEEDTIME, @MCASTGIDNCNEWCUSTMCD, @MCASTGIDNCMAINTECD, @SYSTEMDIVCD, " +
                                "@GUIDANCE1, @AREA ) ";

							// 更新ヘッダ情報を設定
							DateTime nowDateTime = TDateTime.GetSFDateNow();
							changGidncWork.CreateDateTime = nowDateTime;
							changGidncWork.UpdateDateTime = nowDateTime;
						}

						if( ! myReader.IsClosed ) 
                        {
							myReader.Close();
                        }

                        #region Parameterオブジェクトの作成
                        SqlParameter paraCreateDateTime       = sqlCommand.Parameters.Add( "@CREATEDATETIME", SqlDbType.BigInt );
						SqlParameter paraUpdateDateTime       = sqlCommand.Parameters.Add( "@UPDATEDATETIME", SqlDbType.BigInt );
						SqlParameter paraLogicalDeleteCode    = sqlCommand.Parameters.Add( "@LOGICALDELETECODE", SqlDbType.Int );
						SqlParameter paraMcastGidncCntntsCd   = sqlCommand.Parameters.Add( "@MCASTGIDNCCNTNTSCD", SqlDbType.Int );
						SqlParameter paraProductCode          = sqlCommand.Parameters.Add( "@PRODUCTCODE", SqlDbType.NVarChar );
						SqlParameter paraMcastGidncVersionCd  = sqlCommand.Parameters.Add( "@MCASTGIDNCVERSIONCD", SqlDbType.NVarChar );
                        SqlParameter paraMcastOfferDivCd      = sqlCommand.Parameters.Add( "@MCASTOFFERDIVCD", SqlDbType.Int );
						SqlParameter paraUpdateGroupCode      = sqlCommand.Parameters.Add( "@UPDATEGROUPCODE", SqlDbType.NVarChar );
						SqlParameter paraEnterpriseCode       = sqlCommand.Parameters.Add( "@ENTERPRISECODE", SqlDbType.NChar );
						SqlParameter paraMulticastConsNo      = sqlCommand.Parameters.Add( "@MULTICASTCONSNO", SqlDbType.Int );
						SqlParameter paraMulticastDate        = sqlCommand.Parameters.Add( "@MULTICASTDATE", SqlDbType.Int );
						SqlParameter paraSupportOpenTime      = sqlCommand.Parameters.Add( "@SUPPORTOPENTIME", SqlDbType.BigInt );
						SqlParameter paraCustomerOpenTime     = sqlCommand.Parameters.Add( "@CUSTOMEROPENTIME", SqlDbType.BigInt );
						SqlParameter paraServerMainteStScdl   = sqlCommand.Parameters.Add( "@SERVERMAINTESTSCDL", SqlDbType.BigInt );
						SqlParameter paraServerMainteEdScdl   = sqlCommand.Parameters.Add( "@SERVERMAINTEEDSCDL", SqlDbType.BigInt );
						SqlParameter paraServerMainteStTime   = sqlCommand.Parameters.Add( "@SERVERMAINTESTTIME", SqlDbType.BigInt );
						SqlParameter paraServerMainteEdTime   = sqlCommand.Parameters.Add( "@SERVERMAINTEEDTIME", SqlDbType.BigInt );
						SqlParameter paraMcastGidncNewCustmCd = sqlCommand.Parameters.Add( "@MCASTGIDNCNEWCUSTMCD", SqlDbType.Int );
						SqlParameter paraMcastGidncMainteCd   = sqlCommand.Parameters.Add( "@MCASTGIDNCMAINTECD", SqlDbType.Int );
						SqlParameter paraSystemDivCd          = sqlCommand.Parameters.Add( "@SYSTEMDIVCD", SqlDbType.Int );
						SqlParameter paraGuidance1            = sqlCommand.Parameters.Add( "@GUIDANCE1", SqlDbType.NVarChar );
						SqlParameter paraArea                 = sqlCommand.Parameters.Add( "@AREA", SqlDbType.NVarChar );
                        #endregion

                        #region Parameterオブジェクトへ値をセット
                        paraCreateDateTime.Value       = SqlDataMediator.SqlSetDateTimeFromTicks(    changGidncWork.CreateDateTime );
						paraUpdateDateTime.Value       = SqlDataMediator.SqlSetDateTimeFromTicks(    changGidncWork.UpdateDateTime );
						paraLogicalDeleteCode.Value    = SqlDataMediator.SqlSetInt32(                changGidncWork.LogicalDeleteCode );
						paraMcastGidncCntntsCd.Value   = SqlDataMediator.SqlSetInt32(                changGidncWork.McastGidncCntntsCd );
						paraProductCode.Value          = SqlDataMediator.SqlSetString(               changGidncWork.ProductCode );
						paraMcastGidncVersionCd.Value  = SqlDataMediator.SqlSetString(               changGidncWork.McastGidncVersionCd );
						paraMcastOfferDivCd.Value      = SqlDataMediator.SqlSetInt32(                changGidncWork.McastOfferDivCd );
						paraUpdateGroupCode.Value      = changGidncWork.UpdateGroupCode;  //SqlDataMediator.SqlSetString( changGidncWork.UpdateGroupCode );
						paraEnterpriseCode.Value       = changGidncWork.EnterpriseCode;  //SqlDataMediator.SqlSetString( changGidncWork.EnterpriseCode );
						paraMulticastConsNo.Value      = SqlDataMediator.SqlSetInt32(                changGidncWork.MulticastConsNo );
						paraMulticastDate.Value        = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD( changGidncWork.MulticastDate );
						paraSupportOpenTime.Value      = SqlDataMediator.SqlSetInt64(                changGidncWork.SupportOpenTime );
						paraCustomerOpenTime.Value     = SqlDataMediator.SqlSetInt64(                changGidncWork.CustomerOpenTime );
						paraServerMainteStScdl.Value   = SqlDataMediator.SqlSetInt64(                changGidncWork.ServerMainteStScdl );
						paraServerMainteEdScdl.Value   = SqlDataMediator.SqlSetInt64(                changGidncWork.ServerMainteEdScdl );
						paraServerMainteStTime.Value   = SqlDataMediator.SqlSetInt64(                changGidncWork.ServerMainteStTime );
						paraServerMainteEdTime.Value   = SqlDataMediator.SqlSetInt64(                changGidncWork.ServerMainteEdTime );
						paraMcastGidncNewCustmCd.Value = SqlDataMediator.SqlSetInt32(                changGidncWork.McastGidncNewCustmCd );
						paraMcastGidncMainteCd.Value   = SqlDataMediator.SqlSetInt32(                changGidncWork.McastGidncMainteCd );
						paraSystemDivCd.Value          = SqlDataMediator.SqlSetInt32(                changGidncWork.SystemDivCd );
						paraGuidance1.Value            = SqlDataMediator.SqlSetString(               changGidncWork.Guidance1 );
						paraArea.Value                 = SqlDataMediator.SqlSetString(               changGidncWork.Area );
                        #endregion

                        sqlCommand.ExecuteNonQuery();

						list.Add( changGidncWork );
					}
					status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch( Exception ex ) 
            {
				// ログを出力
                changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, ex );
				status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
				errMessage = ex.Message;
			}

			changGidncWorkList = list;

			return status;
		}

		#endregion

		#region private int WriteChgGidncDt( ref List<ChgGidncDtWork> chgGidncDtWorkList, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )

		private int WriteChgGidncDt( ref List<ChgGidncDtWork> chgGidncDtWorkList, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
			SqlDataReader myReader = null;
			List<ChgGidncDtWork> list = new List<ChgGidncDtWork>();
			errMessage = "";

            ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

			if( chgGidncDtWorkList.Count == 0 ) 
            {
				return ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			try 
            {
				for( int ix = 0; ix < chgGidncDtWorkList.Count; ix++ ) 
                {
					using( SqlCommand sqlCommand = new SqlCommand( "SELECT UPDATEDATETIMERF FROM CHGGIDNCDTRF  WHERE " + 
                    " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD AND PRODUCTCODERF=@FINDPRODUCTCODE " +
                    " AND MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD " +
                    " AND UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE " +
                    " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO AND MULTICASTSUBCODERF=@FINDMULTICASTSUBCODE ",
					sqlConnection, sqlTransaction ) ) 
                    {
						ChgGidncDtWork chgGidncDtWork = chgGidncDtWorkList[ ix ];

						// Parameterオブジェクトの作成
						SqlParameter findParaMcastGidncCntntsCd  = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCCNTNTSCD", SqlDbType.Int );
						SqlParameter findParaProductCode         = sqlCommand.Parameters.Add( "@FINDPRODUCTCODE", SqlDbType.NVarChar );
						SqlParameter findParaMcastGidncVersionCd = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCVERSIONCD", SqlDbType.NVarChar );
						SqlParameter findParaMcastOfferDivCd     = sqlCommand.Parameters.Add( "@FINDMCASTOFFERDIVCD", SqlDbType.Int );
						SqlParameter findParaUpdateGroupCode     = sqlCommand.Parameters.Add( "@FINDUPDATEGROUPCODE", SqlDbType.NVarChar );
						SqlParameter findParaEnterpriseCode      = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
						SqlParameter findParaMulticastConsNo     = sqlCommand.Parameters.Add( "@FINDMULTICASTCONSNO", SqlDbType.Int );
						SqlParameter findParaMulticastSubCode    = sqlCommand.Parameters.Add( "@FINDMULTICASTSUBCODE", SqlDbType.Int );

						// Parameterオブジェクトへ値をセット
						findParaMcastGidncCntntsCd.Value  = SqlDataMediator.SqlSetInt32( chgGidncDtWork.McastGidncCntntsCd );
                        findParaProductCode.Value         = SqlDataMediator.SqlSetString( chgGidncDtWork.ProductCode );
						findParaMcastGidncVersionCd.Value = SqlDataMediator.SqlSetString( chgGidncDtWork.McastGidncVersionCd );
						findParaMcastOfferDivCd.Value     = SqlDataMediator.SqlSetInt32( chgGidncDtWork.McastOfferDivCd );
						findParaUpdateGroupCode.Value     = chgGidncDtWork.UpdateGroupCode;  //SqlDataMediator.SqlSetString( chgGidncDtWork.UpdateGroupCode );
						findParaEnterpriseCode.Value      = chgGidncDtWork.EnterpriseCode;  //SqlDataMediator.SqlSetString( chgGidncDtWork.EnterpriseCode );
						findParaMulticastConsNo.Value     = SqlDataMediator.SqlSetInt32( chgGidncDtWork.MulticastConsNo );
						findParaMulticastSubCode.Value    = SqlDataMediator.SqlSetInt32( chgGidncDtWork.MulticastSubCode );

						myReader = sqlCommand.ExecuteReader();

						if( myReader.Read() ) 
                        {
							// 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで返す
							DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) );
							if( updateDateTime != chgGidncDtWork.UpdateDateTime ) 
                            {
								// 新規登録で既存データ有りの場合は重複
								if( chgGidncDtWork.UpdateDateTime == DateTime.MinValue ) 
                                {
									status = ( int )ConstantManagement.DB_Status.ctDB_DUPLICATE;
								}
								// 既存データで更新日時が異なる場合は排他
								else 
                                {
									status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
								}
								if( ! myReader.IsClosed ) 
                                {
									myReader.Close();
								}
								return status;
							}

							sqlCommand.CommandText = "UPDATE CHGGIDNCDTRF SET " + 
                                "CREATEDATETIMERF=@CREATEDATETIME, UPDATEDATETIMERF=@UPDATEDATETIME, " +
                                "LOGICALDELETECODERF=@LOGICALDELETECODE, MCASTGIDNCCNTNTSCDRF=@MCASTGIDNCCNTNTSCD, " +
                                "PRODUCTCODERF=@PRODUCTCODE, MCASTGIDNCVERSIONCDRF=@MCASTGIDNCVERSIONCD, " +
                                "MCASTOFFERDIVCDRF=@MCASTOFFERDIVCD, UPDATEGROUPCODERF=@UPDATEGROUPCODE, " +
                                "ENTERPRISECODERF=@ENTERPRISECODE, MULTICASTCONSNORF=@MULTICASTCONSNO, " +
                                "MULTICASTSUBCODERF=@MULTICASTSUBCODE, CHANGECONTENTSRF=@CHANGECONTENTS, " +
                                "ANOTHERSHEETFILEEXSTRF=@ANOTHERSHEETFILEEXST, ANOTHERSHEETFILENAMERF=@ANOTHERSHEETFILENAME " +
								"WHERE " +
                                " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD AND PRODUCTCODERF=@FINDPRODUCTCODE " +
                                " AND MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD " +
                                " AND UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE " +
                                " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO AND MULTICASTSUBCODERF=@MULTICASTSUBCODE ";

							// 更新ヘッダ情報を設定
							chgGidncDtWork.UpdateDateTime = TDateTime.GetSFDateNow();
						}
						else 
                        {
							// 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合は既に削除されている意味で排他を返す
							if( chgGidncDtWork.UpdateDateTime > DateTime.MinValue ) 
                            {
								status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
								if( ! myReader.IsClosed ) 
                                {
									myReader.Close();
								}
								return status;
							}

							sqlCommand.CommandText = "INSERT INTO CHGGIDNCDTRF " + 
                                "( CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, MCASTGIDNCCNTNTSCDRF, PRODUCTCODERF, " +
                                "MCASTGIDNCVERSIONCDRF, MCASTOFFERDIVCDRF, UPDATEGROUPCODERF, ENTERPRISECODERF, MULTICASTCONSNORF, " +
                                "MULTICASTSUBCODERF, CHANGECONTENTSRF, ANOTHERSHEETFILEEXSTRF, ANOTHERSHEETFILENAMERF ) " +
                                "VALUES " + 
                                "( @CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @MCASTGIDNCCNTNTSCD, @PRODUCTCODE, " +
                                "@MCASTGIDNCVERSIONCD, @MCASTOFFERDIVCD, @UPDATEGROUPCODE, @ENTERPRISECODE, @MULTICASTCONSNO, " +
                                "@MULTICASTSUBCODE, @CHANGECONTENTS, @ANOTHERSHEETFILEEXST, @ANOTHERSHEETFILENAME ) ";

							// 更新ヘッダ情報を設定
							DateTime nowDateTime = TDateTime.GetSFDateNow();
							chgGidncDtWork.CreateDateTime = nowDateTime;
							chgGidncDtWork.UpdateDateTime = nowDateTime;
						}

						if( ! myReader.IsClosed ) 
                        {
							myReader.Close();
                        }

                        #region Parameterオブジェクトの作成
                        SqlParameter paraCreateDateTime       = sqlCommand.Parameters.Add( "@CREATEDATETIME", SqlDbType.BigInt );
						SqlParameter paraUpdateDateTime       = sqlCommand.Parameters.Add( "@UPDATEDATETIME", SqlDbType.BigInt );
						SqlParameter paraLogicalDeleteCode    = sqlCommand.Parameters.Add( "@LOGICALDELETECODE", SqlDbType.Int );
						SqlParameter paraMcastGidncCntntsCd   = sqlCommand.Parameters.Add( "@MCASTGIDNCCNTNTSCD", SqlDbType.Int );
                        SqlParameter paraProductCode          = sqlCommand.Parameters.Add( "@PRODUCTCODE", SqlDbType.NVarChar );
						SqlParameter paraMcastGidncVersionCd  = sqlCommand.Parameters.Add( "@MCASTGIDNCVERSIONCD", SqlDbType.NVarChar );
                        SqlParameter paraMcastOfferDivCd      = sqlCommand.Parameters.Add( "@MCASTOFFERDIVCD", SqlDbType.Int );
						SqlParameter paraUpdateGroupCode      = sqlCommand.Parameters.Add( "@UPDATEGROUPCODE", SqlDbType.NVarChar );
						SqlParameter paraEnterpriseCode       = sqlCommand.Parameters.Add( "@ENTERPRISECODE", SqlDbType.NChar );
						SqlParameter paraMulticastConsNo      = sqlCommand.Parameters.Add( "@MULTICASTCONSNO", SqlDbType.Int );
						SqlParameter paraMulticastSubCode     = sqlCommand.Parameters.Add( "@MULTICASTSUBCODE", SqlDbType.Int );
						SqlParameter paraChangeContents       = sqlCommand.Parameters.Add( "@CHANGECONTENTS", SqlDbType.NVarChar );
						SqlParameter paraAnothersheetFileExst = sqlCommand.Parameters.Add( "@ANOTHERSHEETFILEEXST", SqlDbType.Int );
						SqlParameter paraAnothersheetFileName = sqlCommand.Parameters.Add( "@ANOTHERSHEETFILENAME", SqlDbType.NVarChar );
                        #endregion

                        #region Parameterオブジェクトへ値をセット
                        paraCreateDateTime.Value       = SqlDataMediator.SqlSetDateTimeFromTicks(chgGidncDtWork.CreateDateTime );
						paraUpdateDateTime.Value       = SqlDataMediator.SqlSetDateTimeFromTicks(chgGidncDtWork.UpdateDateTime );
						paraLogicalDeleteCode.Value    = SqlDataMediator.SqlSetInt32(            chgGidncDtWork.LogicalDeleteCode );
						paraMcastGidncCntntsCd.Value   = SqlDataMediator.SqlSetInt32(            chgGidncDtWork.McastGidncCntntsCd );
						paraProductCode.Value          = SqlDataMediator.SqlSetString(           chgGidncDtWork.ProductCode );
						paraMcastGidncVersionCd.Value  = SqlDataMediator.SqlSetString(           chgGidncDtWork.McastGidncVersionCd );
                        paraMcastOfferDivCd.Value      = SqlDataMediator.SqlSetInt32(            chgGidncDtWork.McastOfferDivCd );
						paraUpdateGroupCode.Value      = chgGidncDtWork.UpdateGroupCode;  //SqlDataMediator.SqlSetString( chgGidncDtWork.UpdateGroupCode );
						paraEnterpriseCode.Value       = chgGidncDtWork.EnterpriseCode;  //SqlDataMediator.SqlSetString( chgGidncDtWork.EnterpriseCode );
						paraMulticastConsNo.Value      = SqlDataMediator.SqlSetInt32(            chgGidncDtWork.MulticastConsNo );
						paraMulticastSubCode.Value     = SqlDataMediator.SqlSetInt32(            chgGidncDtWork.MulticastSubCode );
						paraChangeContents.Value       = SqlDataMediator.SqlSetString(           chgGidncDtWork.ChangeContents );
						paraAnothersheetFileExst.Value = SqlDataMediator.SqlSetInt32(            chgGidncDtWork.AnothersheetFileExst );
						paraAnothersheetFileName.Value = SqlDataMediator.SqlSetString(           chgGidncDtWork.AnothersheetFileName );
                        #endregion

                        sqlCommand.ExecuteNonQuery();

						list.Add( chgGidncDtWork );
					}
					status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
            catch( SqlException ex ) 
            {
                // ロック要求がTimeOutの場合、排他エラーを返す
                if( ex.Number == 1222 ) 
                {
                    status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    errMessage = "排他エラーが発生しました。" + ex.Message;
                }
                else 
                {
					// ログを出力
					changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, ex );
                    status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
                    errMessage = "更新・登録でエラーが発生しました。" + ex.Message;
                }
            }
			catch( Exception ex ) 
            {
				// ログを出力
                changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, ex );
				status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
				errMessage = ex.Message;
			}

			chgGidncDtWorkList = list;

			return status;
		}

		#endregion



		#region public int DeleteChangGidnc( ChangGidncWork changGidncWork, out string errMessage )

		/// <summary>
		/// 変更案内マスタ削除処理
		/// </summary>
		/// <param name="changGidncWork">変更案内ワーククラス</param>
		/// <param name="errMessage">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		public int DeleteChangGidnc( ChangGidncWork changGidncWork, out string errMessage )
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            errMessage = "";

            ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

			try 
            {
				// 変更PG案内DB接続文字列取得部品より、接続文字列を取得
				ChangePgGuideSqlInfo changePgGuideSqlInfo = new ChangePgGuideSqlInfo();
				string connectionText = changePgGuideSqlInfo.GetConnectionText();
				if( String.IsNullOrEmpty( connectionText ) ) 
                {
					// 接続文字列の取得に失敗
					return status;
				}

				// コネクションオープン
				sqlConnection = new SqlConnection( connectionText );
				sqlConnection.Open();

				// トランザクション開始
				sqlTransaction = sqlConnection.BeginTransaction( ( IsolationLevel )ConstantManagement.DB_IsolationLevel.ctDB_Default );

				// プログラム配信案内明細リストを削除
				status = this.DeleteChgGidncDtProc( changGidncWork, out errMessage, ref sqlConnection, ref sqlTransaction );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) 
                {
					// プログラム配信案内データを削除
					status = this.DeleteChangGidncProc( changGidncWork, out errMessage, ref sqlConnection, ref sqlTransaction );
				}
			}
			catch( Exception ex ) 
            {
				// ログを出力
                changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, ex );
				status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
				errMessage = ex.Message;
			}
			finally 
            {
				// コネクション破棄
				if( sqlConnection != null ) 
                {
					// コミットorロールバック
					if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) 
                    {
						sqlTransaction.Commit();
					}
					else 
                    {
						sqlTransaction.Rollback();
					}

					sqlTransaction.Dispose();
					sqlConnection.Close();
				}
			}

			return status;
		}

		#endregion

		#region private int DeleteChgGidncDt( List<ChgGidncDtWork> chgGidncDtWorkDelList, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )

		private int DeleteChgGidncDt( List<ChgGidncDtWork> chgGidncDtWorkDelList, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
			SqlDataReader myReader = null;
			errMessage = "";

			if( ( chgGidncDtWorkDelList == null ) || ( chgGidncDtWorkDelList.Count == 0 ) ) 
            {
				status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
				return status;
			}

            ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

			try 
            {
				for( int ix = 0; ix < chgGidncDtWorkDelList.Count; ix++ ) 
                {
					using( SqlCommand sqlCommand = new SqlCommand( 
					"SELECT UPDATEDATETIMERF FROM CHGGIDNCDTRF  WHERE " +
                    " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD AND PRODUCTCODERF=@FINDPRODUCTCODE " +
                    " AND MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD " +
                    " AND UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE " +
                    " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO AND MULTICASTSUBCODERF=@FINDMULTICASTSUBCODE ",
					sqlConnection, sqlTransaction ) ) 
                    {
			    		ChgGidncDtWork chgGidncDtWork = chgGidncDtWorkDelList[ ix ];

						// Parameterオブジェクトの作成
						SqlParameter findParaMcastGidncCntntsCd  = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCCNTNTSCD", SqlDbType.Int );
						SqlParameter findParaProductCode         = sqlCommand.Parameters.Add( "@FINDPRODUCTCODE", SqlDbType.NVarChar );
						SqlParameter findParaMcastGidncVersionCd = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCVERSIONCD", SqlDbType.NVarChar );
						SqlParameter findParaMcastOfferDivCd     = sqlCommand.Parameters.Add( "@FINDMCASTOFFERDIVCD", SqlDbType.Int );
						SqlParameter findParaUpdateGroupCode     = sqlCommand.Parameters.Add( "@FINDUPDATEGROUPCODE", SqlDbType.NVarChar );
						SqlParameter findParaEnterpriseCode      = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
						SqlParameter findParaMulticastConsNo     = sqlCommand.Parameters.Add( "@FINDMULTICASTCONSNO", SqlDbType.Int );
						SqlParameter findParaMulticastSubCode    = sqlCommand.Parameters.Add( "@FINDMULTICASTSUBCODE", SqlDbType.Int );

						// Parameterオブジェクトへ値をセット
   						findParaMcastGidncCntntsCd.Value  = SqlDataMediator.SqlSetInt32( chgGidncDtWork.McastGidncCntntsCd );
                        findParaProductCode.Value         = SqlDataMediator.SqlSetString( chgGidncDtWork.ProductCode );
	    				findParaMcastGidncVersionCd.Value = SqlDataMediator.SqlSetString( chgGidncDtWork.McastGidncVersionCd );
		    			findParaMcastOfferDivCd.Value     = SqlDataMediator.SqlSetInt32( chgGidncDtWork.McastOfferDivCd );
			    		findParaUpdateGroupCode.Value     = chgGidncDtWork.UpdateGroupCode;  //SqlDataMediator.SqlSetString( changGidncWork.UpdateGroupCode );
				    	findParaEnterpriseCode.Value      = chgGidncDtWork.EnterpriseCode;  //SqlDataMediator.SqlSetString( changGidncWork.EnterpriseCode );
					    findParaMulticastConsNo.Value     = SqlDataMediator.SqlSetInt32( chgGidncDtWork.MulticastConsNo );
				    	findParaMulticastSubCode.Value    = SqlDataMediator.SqlSetInt32( chgGidncDtWork.MulticastSubCode );

						myReader = sqlCommand.ExecuteReader();

                        if( myReader.Read() ) 
                        {
							// 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで返す
							DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) );
							if( updateDateTime != chgGidncDtWork.UpdateDateTime ) 
                            {
								status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
								if( ! myReader.IsClosed ) 
                                {
									myReader.Close();
								}
								return status;
							}

							sqlCommand.CommandText = "DELETE FROM CHGGIDNCDTRF " + 
								"WHERE " +
                                " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD AND PRODUCTCODERF=@FINDPRODUCTCODE " +
                                " AND MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD " +
                                " AND UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE " +
                                " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO AND MULTICASTSUBCODERF=@FINDMULTICASTSUBCODE ";

							// KEYコマンドを再設定
    						findParaMcastGidncCntntsCd.Value  = SqlDataMediator.SqlSetInt32( chgGidncDtWork.McastGidncCntntsCd );
                            findParaProductCode.Value         = SqlDataMediator.SqlSetString( chgGidncDtWork.ProductCode );
		    				findParaMcastGidncVersionCd.Value = SqlDataMediator.SqlSetString( chgGidncDtWork.McastGidncVersionCd );
			    			findParaMcastOfferDivCd.Value     = SqlDataMediator.SqlSetInt32( chgGidncDtWork.McastOfferDivCd );
				    		findParaUpdateGroupCode.Value     = chgGidncDtWork.UpdateGroupCode;  //SqlDataMediator.SqlSetString( changGidncWork.UpdateGroupCode );
					    	findParaEnterpriseCode.Value      = chgGidncDtWork.EnterpriseCode;  //SqlDataMediator.SqlSetString( changGidncWork.EnterpriseCode );
						    findParaMulticastConsNo.Value     = SqlDataMediator.SqlSetInt32( chgGidncDtWork.MulticastConsNo );
					    	findParaMulticastSubCode.Value    = SqlDataMediator.SqlSetInt32( chgGidncDtWork.MulticastSubCode );
                        
                        }
						else 
                        {
							// 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合は既に削除されている意味で排他を返す
							status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
							if( ! myReader.IsClosed ) 
                            {
								myReader.Close();
							}
							return status;
						}

						if( ! myReader.IsClosed ) 
                        {
							myReader.Close();
						}

						sqlCommand.ExecuteNonQuery();
					}
					status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch( Exception ex ) 
            {
				// ログを出力
                changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, ex );
				status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
				errMessage = ex.Message;
			}

			return status;
		}

		#endregion

		#region private int DeleteChangGidncProc( ChangGidncWork changGidncWork, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )

		/// <summary>
		/// 変更案内マスタ削除処理
		/// </summary>
		/// <param name="changGidncWork">変更案内ワーククラス</param>
		/// <param name="errMessage">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		private int DeleteChangGidncProc( ChangGidncWork changGidncWork, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

            ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

			SqlDataReader myReader = null;
            errMessage = "";

			try 
            {
				using( SqlCommand sqlCommand = new SqlCommand( "SELECT UPDATEDATETIMERF  FROM CHANGGIDNCRF  WHERE " + 
                " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD AND PRODUCTCODERF=@FINDPRODUCTCODE " +
                " AND MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD " +
                " AND UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE " +
                " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO ",
				sqlConnection, sqlTransaction ) ) 
                {
					// Parameterオブジェクトの作成
					SqlParameter findParaMcastGidncCntntsCd  = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCCNTNTSCD", SqlDbType.Int );
					SqlParameter findParaProductCode         = sqlCommand.Parameters.Add( "@FINDPRODUCTCODE", SqlDbType.NVarChar );
					SqlParameter findParaMcastGidncVersionCd = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCVERSIONCD", SqlDbType.NVarChar );
					SqlParameter findParaMcastOfferDivCd     = sqlCommand.Parameters.Add( "@FINDMCASTOFFERDIVCD", SqlDbType.Int );
					SqlParameter findParaUpdateGroupCode     = sqlCommand.Parameters.Add( "@FINDUPDATEGROUPCODE", SqlDbType.NVarChar );
					SqlParameter findParaEnterpriseCode      = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
					SqlParameter findParaMulticastConsNo     = sqlCommand.Parameters.Add( "@FINDMULTICASTCONSNO", SqlDbType.Int );

					// Parameterオブジェクトへ値をセット
					findParaMcastGidncCntntsCd.Value  = SqlDataMediator.SqlSetInt32( changGidncWork.McastGidncCntntsCd );
                    findParaProductCode.Value         = SqlDataMediator.SqlSetString( changGidncWork.ProductCode );
					findParaMcastGidncVersionCd.Value = SqlDataMediator.SqlSetString( changGidncWork.McastGidncVersionCd );
					findParaMcastOfferDivCd.Value     = SqlDataMediator.SqlSetInt32( changGidncWork.McastOfferDivCd );
					findParaUpdateGroupCode.Value     = changGidncWork.UpdateGroupCode;  //SqlDataMediator.SqlSetString( changGidncWork.UpdateGroupCode );
					findParaEnterpriseCode.Value      = changGidncWork.EnterpriseCode;  //SqlDataMediator.SqlSetString( changGidncWork.EnterpriseCode );
					findParaMulticastConsNo.Value     = SqlDataMediator.SqlSetInt32( changGidncWork.MulticastConsNo );

					myReader = sqlCommand.ExecuteReader();

					if( myReader.Read() ) 
                    {
						// 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで返す
						DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) );
						if( updateDateTime != changGidncWork.UpdateDateTime ) 
                        {
							status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							if( ! myReader.IsClosed ) 
                            {
								myReader.Close();
							}
							return status;
						}

						sqlCommand.CommandText = "DELETE FROM CHANGGIDNCRF  WHERE " + 
                            " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD AND PRODUCTCODERF=@FINDPRODUCTCODE " +
                            " AND MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD " +
                            " AND UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE " +
                            " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO ";

						// KEYコマンドを再設定
                        findParaMcastGidncCntntsCd.Value  = SqlDataMediator.SqlSetInt32( changGidncWork.McastGidncCntntsCd );
                        findParaProductCode.Value         = SqlDataMediator.SqlSetString( changGidncWork.ProductCode );
	    				findParaMcastGidncVersionCd.Value = SqlDataMediator.SqlSetString( changGidncWork.McastGidncVersionCd );
		    			findParaMcastOfferDivCd.Value     = SqlDataMediator.SqlSetInt32( changGidncWork.McastOfferDivCd );
			    		findParaUpdateGroupCode.Value     = changGidncWork.UpdateGroupCode;  //SqlDataMediator.SqlSetString( changGidncWork.UpdateGroupCode );
				    	findParaEnterpriseCode.Value      = changGidncWork.EnterpriseCode;  //SqlDataMediator.SqlSetString( changGidncWork.EnterpriseCode );
					    findParaMulticastConsNo.Value     = SqlDataMediator.SqlSetInt32( changGidncWork.MulticastConsNo );

					}
					else 
                    {
						// 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合は既に削除されている意味で排他を返す
						status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						if( ! myReader.IsClosed ) 
                        {
							myReader.Close();
						}
						return status;
					}

					if( ! myReader.IsClosed ) 
                    {
						myReader.Close();
					}

					sqlCommand.ExecuteNonQuery();

					status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch( Exception ex ) 
            {
				// ログを出力
                changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, ex );
				status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
				errMessage = ex.Message;
			}

			return status;
		}

		#endregion

		#region private int DeleteChgGidncDtProc( ChangGidncWork changGidncWork, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )

		/// <summary>
		/// 変更案内マスタ削除処理
		/// </summary>
		/// <param name="changGidncWork">変更案内ワーククラス</param>
		/// <param name="errMessage">エラーメッセージ</param>
		/// <returns>STATUS</returns>
		private int DeleteChgGidncDtProc( ChangGidncWork changGidncWork, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
		{
			int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

            ChangePgGuideLogOutPut changePgGuideLogOutPut = new ChangePgGuideLogOutPut();

			SqlDataReader myReader = null;
            errMessage = "";

			try 
            {
				using( SqlCommand sqlCommand = new SqlCommand( "SELECT UPDATEDATETIMERF FROM CHANGGIDNCRF  WHERE " + 
                " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD AND PRODUCTCODERF=@FINDPRODUCTCODE " +
                " AND MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD " +
                " AND UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE " +
                " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO ",
                sqlConnection, sqlTransaction ) ) 
                {
					// Parameterオブジェクトの作成
					SqlParameter findParaMcastGidncCntntsCd  = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCCNTNTSCD", SqlDbType.Int );
					SqlParameter findParaProductCode         = sqlCommand.Parameters.Add( "@FINDPRODUCTCODE", SqlDbType.NVarChar );
					SqlParameter findParaMcastGidncVersionCd = sqlCommand.Parameters.Add( "@FINDMCASTGIDNCVERSIONCD", SqlDbType.NVarChar );
					SqlParameter findParaMcastOfferDivCd     = sqlCommand.Parameters.Add( "@FINDMCASTOFFERDIVCD", SqlDbType.Int );
					SqlParameter findParaUpdateGroupCode     = sqlCommand.Parameters.Add( "@FINDUPDATEGROUPCODE", SqlDbType.NVarChar );
					SqlParameter findParaEnterpriseCode      = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
					SqlParameter findParaMulticastConsNo     = sqlCommand.Parameters.Add( "@FINDMULTICASTCONSNO", SqlDbType.Int );

					// Parameterオブジェクトへ値をセット
					findParaMcastGidncCntntsCd.Value  = SqlDataMediator.SqlSetInt32( changGidncWork.McastGidncCntntsCd );
                    findParaProductCode.Value         = SqlDataMediator.SqlSetString( changGidncWork.ProductCode );
					findParaMcastGidncVersionCd.Value = SqlDataMediator.SqlSetString( changGidncWork.McastGidncVersionCd );
					findParaMcastOfferDivCd.Value     = SqlDataMediator.SqlSetInt32( changGidncWork.McastOfferDivCd );
					findParaUpdateGroupCode.Value     = changGidncWork.UpdateGroupCode;  //SqlDataMediator.SqlSetString( changGidncWork.UpdateGroupCode );
					findParaEnterpriseCode.Value      = changGidncWork.EnterpriseCode;  //SqlDataMediator.SqlSetString( changGidncWork.EnterpriseCode );
					findParaMulticastConsNo.Value     = SqlDataMediator.SqlSetInt32( changGidncWork.MulticastConsNo );

					myReader = sqlCommand.ExecuteReader();

					if( myReader.Read() ) 
                    {
						// 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで返す
						DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) );
						if( updateDateTime != changGidncWork.UpdateDateTime ) 
                        {
							status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
							if( ! myReader.IsClosed ) 
                            {
								myReader.Close();
							}
							return status;
						}

						sqlCommand.CommandText = "DELETE FROM CHGGIDNCDTRF  WHERE " + 
                            " MCASTGIDNCCNTNTSCDRF=@FINDMCASTGIDNCCNTNTSCD AND PRODUCTCODERF=@FINDPRODUCTCODE " +
                            " AND MCASTGIDNCVERSIONCDRF=@FINDMCASTGIDNCVERSIONCD AND MCASTOFFERDIVCDRF=@FINDMCASTOFFERDIVCD " +
                            " AND UPDATEGROUPCODERF=@FINDUPDATEGROUPCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE " +
                            " AND MULTICASTCONSNORF=@FINDMULTICASTCONSNO ";

						// KEYコマンドを再設定
    					findParaMcastGidncCntntsCd.Value  = SqlDataMediator.SqlSetInt32( changGidncWork.McastGidncCntntsCd );
                        findParaProductCode.Value         = SqlDataMediator.SqlSetString( changGidncWork.ProductCode );
		    			findParaMcastGidncVersionCd.Value = SqlDataMediator.SqlSetString( changGidncWork.McastGidncVersionCd );
			    		findParaMcastOfferDivCd.Value     = SqlDataMediator.SqlSetInt32( changGidncWork.McastOfferDivCd );
				    	findParaUpdateGroupCode.Value     = changGidncWork.UpdateGroupCode;  //SqlDataMediator.SqlSetString( changGidncWork.UpdateGroupCode );
					    findParaEnterpriseCode.Value      = changGidncWork.EnterpriseCode;  //SqlDataMediator.SqlSetString( changGidncWork.EnterpriseCode );
					    findParaMulticastConsNo.Value     = SqlDataMediator.SqlSetInt32( changGidncWork.MulticastConsNo );
					}
					else {
						// 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合は既に削除されている意味で排他を返す
						status = ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						if( ! myReader.IsClosed ) {
							myReader.Close();
						}
						return status;
					}

					if( ! myReader.IsClosed ) {
						myReader.Close();
					}

					sqlCommand.ExecuteNonQuery();

					status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch( Exception ex ) {
				// ログを出力
                changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, ex );
				status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;
				errMessage = ex.Message;
			}

			return status;
		}

		#endregion

		#endregion

    }
}

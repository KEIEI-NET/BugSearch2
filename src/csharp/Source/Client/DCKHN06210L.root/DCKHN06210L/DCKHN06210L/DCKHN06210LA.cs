using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;


namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// 伝票印刷設定マスタLCローカルDBオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 伝票印刷設定マスタLCのローカルDB実データ操作を行うクラスです。</br>
    /// <br>Programmer : 980081 山田 明友</br>
    /// <br>Date       : 2008.02.08</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.28 20081 疋田 勇人</br>
    /// <br>           : PM.NS用に変更</br>
    /// </remarks>
    public class SlipPrtSetLcDB : IWriteSyncLocalData
    {
        /// <summary>
        /// 伝票印刷設定マスタLCローカルDBオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        /// </remarks>
        public SlipPrtSetLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// 指定された条件の伝票印刷設定マスタLC情報LISTを戻します
        /// </summary>
        /// <param name="slipPrtSetWorkList">検索結果</param>
        /// <param name="paraSlipPrtSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票印刷設定マスタLC情報LISTを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        public int Search(out List<SlipPrtSetWork> slipPrtSetWorkList, SlipPrtSetWork paraSlipPrtSetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            slipPrtSetWorkList = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchSlipPrtSetProcProc(out slipPrtSetWorkList, paraSlipPrtSetWork, readMode, logicalMode, ref sqlConnection);
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "SlipPrtSetLcDB.Search", 0);
                slipPrtSetWorkList = new List<SlipPrtSetWork>();
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
        /// 指定された条件の伝票印刷設定マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="slipPrtSetWorkList">検索結果</param>
        /// <param name="slipPrtSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票印刷設定マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        public int SearchSlipPrtSetProc(out List<SlipPrtSetWork> slipPrtSetWorkList, SlipPrtSetWork slipPrtSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            status = SearchSlipPrtSetProcProc(out slipPrtSetWorkList, slipPrtSetWork, readMode, logicalMode, ref sqlConnection);
            return status;

        }

        /// <summary>
        /// 指定された条件の伝票印刷設定マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="slipPrtSetWorkList">検索結果</param>
        /// <param name="slipPrtSetWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票印刷設定マスタLC情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        private int SearchSlipPrtSetProcProc(out List<SlipPrtSetWork> slipPrtSetWorkList, SlipPrtSetWork slipPrtSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<SlipPrtSetWork> listdata = new List<SlipPrtSetWork>();
            try
            {
                // 2008.05.28 upd start ----------------------------->>
                //sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF  ", sqlConnection);
                string sqlTxt = string.Empty; 
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
                // 2008.05.28 upd end -------------------------------<<

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, slipPrtSetWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    listdata.Add(CopyToSlipPrtSetWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "SlipPrtSetLcDB.Search", 0);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            slipPrtSetWorkList = listdata;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// 指定された条件の伝票印刷設定マスタLCを戻します
        /// </summary>
        /// <param name="slipPrtSetWork">slipPrtSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票印刷設定マスタLCを戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        public int Read(ref SlipPrtSetWork slipPrtSetWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProcProc(ref slipPrtSetWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "SlipPrtSetLcDB.Read", 0);
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
        /// 指定された条件の伝票印刷設定マスタLCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="slipPrtSetWork">slipPrtSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票印刷設定マスタLCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        public int ReadProc(ref SlipPrtSetWork slipPrtSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = ReadProcProc(ref slipPrtSetWork, readMode, ref sqlConnection);
            return status;
        }

        /// <summary>
        /// 指定された条件の伝票印刷設定マスタLCを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="slipPrtSetWork">slipPrtSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の伝票印刷設定マスタLCを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        private int ReadProcProc(ref SlipPrtSetWork slipPrtSetWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                // 2008.05.28 upd start ----------------------------------->>
                //using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection))
                string sqlTxt = string.Empty;
                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                using (SqlCommand sqlCommand = new SqlCommand(sqlTxt, sqlConnection))
                // 2008.05.28 upd end -------------------------------------<<
                {

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                    SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
                    findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        slipPrtSetWork = CopyToSlipPrtSetWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "SlipPrtSetLcDB.Read", 0);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [WriteSyncLocalData]
        /// <summary>
        /// ユーザデータシンク管理マスタ情報を登録、更新します
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        public int WriteSyncLocalData(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList syncDataList = new ArrayList();
            try
            {
                if (syncServiceWork == null) return status;
                if (paraSyncDataList == null) return status;

                //使用するパラメータのキャスト
                SlipPrtSetWork slipPrtSetWork = new SlipPrtSetWork();

                for (int i = 0; i < paraSyncDataList.Count; i++)
                {
                    syncDataList = (ArrayList)paraSyncDataList[i];
                    if (syncDataList[0].GetType() == slipPrtSetWork.GetType())
                    {
                        break;
                    }
                }

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write実行
                status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);

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
                WriteErrorLog(ex, "SlipPrtSetLcDB.WriteSyncLocalData", 0);
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
        /// ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        public int WriteSyncLocalDataProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList syncDataList = new ArrayList();
            status = WriteSyncLocalDataProcProc(syncServiceWork, syncDataList, readMode, ref sqlConnection, ref sqlTransaction);
            return status;
        }

        /// <summary>
        /// ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="syncServiceWork">syncLocalDataWorkオブジェクト</param>
        /// <param name="paraSyncDataList">paraSyncDataListオブジェクト</param>
        /// <param name="readMode">readMode(未使用)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ユーザデータシンク管理マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        private int WriteSyncLocalDataProcProc(SyncServiceWork syncServiceWork, ArrayList paraSyncDataList, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList listdata = new ArrayList();
            string sqlTxt = string.Empty; // 2008.05.28 add
            try
            {
                if (paraSyncDataList != null)
                {
                    if (syncServiceWork.Syncmode == 1)
                    {
                        // 2008.05.28 upd start -------------------------------->>
                        //sqlCommand = new SqlCommand("DELETE FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@DELENTERPRISECODE", sqlConnection, sqlTransaction);
                        sqlTxt += "DELETE" + Environment.NewLine;
                        sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                        sqlTxt += " WHERE ENTERPRISECODERF=@DELENTERPRISECODE" + Environment.NewLine;
                        sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                        // 2008.05.28 upd end ----------------------------------<<
                        SqlParameter delEnterpriseCode = sqlCommand.Parameters.Add("@DELENTERPRISECODE", SqlDbType.NChar);
                        delEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
                        sqlCommand.ExecuteNonQuery();
                    }

                    for (int i = 0; i < paraSyncDataList.Count; i++)
                    {
                        SlipPrtSetWork slipPrtSetWork = paraSyncDataList[i] as SlipPrtSetWork;
                        object obj;
                        IFileHeader flhd;
                        ClientFileHeader fileHeader;

                        switch (syncServiceWork.Syncmode)
                        {
                            //差分モードのシンク処理
                            case 0:
                                //Selectコマンドの生成
                                // 2008.05.28 upd start -------------------------------->>
                                //sqlCommand = new SqlCommand("SELECT * FROM SLIPPRTSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection, sqlTransaction);
                                sqlTxt = string.Empty;
                                sqlTxt += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                                sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                                sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                                sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                                sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                                sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                                sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                                sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                                sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                                sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                                sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                                sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                                sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                                sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                                sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                                sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                                sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                                sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                                sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                                sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                                sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                                sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                                sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                                sqlTxt += " FROM SLIPPRTSETRF" + Environment.NewLine;
                                sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                                sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                                sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.28 upd end ----------------------------------<<

                                //Prameterオブジェクトの作成
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                                SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                                SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

                                //Parameterオブジェクトへ値設定
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
                                findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
                                findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
                                findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);

                                myReader = sqlCommand.ExecuteReader();
                                if (myReader.Read())
                                {
                                    // 2008.05.28 upd start -------------------------------->>
                                    //Updateコマンドの生成
                                    //sqlCommand.CommandText = "UPDATE SLIPPRTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID , SLIPCOMMENTRF=@SLIPCOMMENT , OUTPUTPGIDRF=@OUTPUTPGID , OUTPUTPGCLASSIDRF=@OUTPUTPGCLASSID , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , ENTERPRISENAMEPRTCDRF=@ENTERPRISENAMEPRTCD , PRTCIRCULATIONRF=@PRTCIRCULATION , SLIPFORMCDRF=@SLIPFORMCD , OUTCONFIMATIONMSGRF=@OUTCONFIMATIONMSG , OPTIONCODERF=@OPTIONCODE , PRINTERMNGNORF=@PRINTERMNGNO , TOPMARGINRF=@TOPMARGIN , LEFTMARGINRF=@LEFTMARGIN , RIGHTMARGINRF=@RIGHTMARGIN , BOTTOMMARGINRF=@BOTTOMMARGIN , PRTPREVIEWEXISTCODERF=@PRTPREVIEWEXISTCODE , OUTPUTPURPOSERF=@OUTPUTPURPOSE , EACHSLIPTYPECOLID1RF=@EACHSLIPTYPECOLID1 , EACHSLIPTYPECOLNM1RF=@EACHSLIPTYPECOLNM1 , EACHSLIPTYPECOLPRT1RF=@EACHSLIPTYPECOLPRT1 , EACHSLIPTYPECOLID2RF=@EACHSLIPTYPECOLID2 , EACHSLIPTYPECOLNM2RF=@EACHSLIPTYPECOLNM2 , EACHSLIPTYPECOLPRT2RF=@EACHSLIPTYPECOLPRT2 , EACHSLIPTYPECOLID3RF=@EACHSLIPTYPECOLID3 , EACHSLIPTYPECOLNM3RF=@EACHSLIPTYPECOLNM3 , EACHSLIPTYPECOLPRT3RF=@EACHSLIPTYPECOLPRT3 , EACHSLIPTYPECOLID4RF=@EACHSLIPTYPECOLID4 , EACHSLIPTYPECOLNM4RF=@EACHSLIPTYPECOLNM4 , EACHSLIPTYPECOLPRT4RF=@EACHSLIPTYPECOLPRT4 , EACHSLIPTYPECOLID5RF=@EACHSLIPTYPECOLID5 , EACHSLIPTYPECOLNM5RF=@EACHSLIPTYPECOLNM5 , EACHSLIPTYPECOLPRT5RF=@EACHSLIPTYPECOLPRT5 , EACHSLIPTYPECOLID6RF=@EACHSLIPTYPECOLID6 , EACHSLIPTYPECOLNM6RF=@EACHSLIPTYPECOLNM6 , EACHSLIPTYPECOLPRT6RF=@EACHSLIPTYPECOLPRT6 , EACHSLIPTYPECOLID7RF=@EACHSLIPTYPECOLID7 , EACHSLIPTYPECOLNM7RF=@EACHSLIPTYPECOLNM7 , EACHSLIPTYPECOLPRT7RF=@EACHSLIPTYPECOLPRT7 , EACHSLIPTYPECOLID8RF=@EACHSLIPTYPECOLID8 , EACHSLIPTYPECOLNM8RF=@EACHSLIPTYPECOLNM8 , EACHSLIPTYPECOLPRT8RF=@EACHSLIPTYPECOLPRT8 , EACHSLIPTYPECOLID9RF=@EACHSLIPTYPECOLID9 , EACHSLIPTYPECOLNM9RF=@EACHSLIPTYPECOLNM9 , EACHSLIPTYPECOLPRT9RF=@EACHSLIPTYPECOLPRT9 , EACHSLIPTYPECOLID10RF=@EACHSLIPTYPECOLID10 , EACHSLIPTYPECOLNM10RF=@EACHSLIPTYPECOLNM10 , EACHSLIPTYPECOLPRT10RF=@EACHSLIPTYPECOLPRT10 , SLIPFONTNAMERF=@SLIPFONTNAME , SLIPFONTSIZERF=@SLIPFONTSIZE , SLIPFONTSTYLERF=@SLIPFONTSTYLE , SLIPBASECOLORRED1RF=@SLIPBASECOLORRED1 , SLIPBASECOLORGRN1RF=@SLIPBASECOLORGRN1 , SLIPBASECOLORBLU1RF=@SLIPBASECOLORBLU1 , SLIPBASECOLORRED2RF=@SLIPBASECOLORRED2 , SLIPBASECOLORGRN2RF=@SLIPBASECOLORGRN2 , SLIPBASECOLORBLU2RF=@SLIPBASECOLORBLU2 , SLIPBASECOLORRED3RF=@SLIPBASECOLORRED3 , SLIPBASECOLORGRN3RF=@SLIPBASECOLORGRN3 , SLIPBASECOLORBLU3RF=@SLIPBASECOLORBLU3 , SLIPBASECOLORRED4RF=@SLIPBASECOLORRED4 , SLIPBASECOLORGRN4RF=@SLIPBASECOLORGRN4 , SLIPBASECOLORBLU4RF=@SLIPBASECOLORBLU4 , SLIPBASECOLORRED5RF=@SLIPBASECOLORRED5 , SLIPBASECOLORGRN5RF=@SLIPBASECOLORGRN5 , SLIPBASECOLORBLU5RF=@SLIPBASECOLORBLU5 , CUSTTELNOPRTDIVCDRF=@CUSTTELNOPRTDIVCD , COPYCOUNTRF=@COPYCOUNT , TITLENAME1RF=@TITLENAME1 , TITLENAME2RF=@TITLENAME2 , TITLENAME3RF=@TITLENAME3 , TITLENAME4RF=@TITLENAME4 , SPECIALPURPOSE1RF=@SPECIALPURPOSE1 , SPECIALPURPOSE2RF=@SPECIALPURPOSE2 , SPECIALPURPOSE3RF=@SPECIALPURPOSE3 , SPECIALPURPOSE4RF=@SPECIALPURPOSE4 , BARCODEACPODRNOPRTCDRF=@BARCODEACPODRNOPRTCD , BARCODECUSTCODEPRTCDRF=@BARCODECUSTCODEPRTCD , TITLENAME102RF=@TITLENAME102 , TITLENAME103RF=@TITLENAME103 , TITLENAME104RF=@TITLENAME104 , TITLENAME105RF=@TITLENAME105 , TITLENAME202RF=@TITLENAME202 , TITLENAME203RF=@TITLENAME203 , TITLENAME204RF=@TITLENAME204 , TITLENAME205RF=@TITLENAME205 , TITLENAME302RF=@TITLENAME302 , TITLENAME303RF=@TITLENAME303 , TITLENAME304RF=@TITLENAME304 , TITLENAME305RF=@TITLENAME305 , TITLENAME402RF=@TITLENAME402 , TITLENAME403RF=@TITLENAME403 , TITLENAME404RF=@TITLENAME404 , TITLENAME405RF=@TITLENAME405 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "UPDATE SLIPPRTSETRF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += " , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM" + Environment.NewLine;
                                    sqlTxt += " , SLIPPRTKINDRF=@SLIPPRTKIND" + Environment.NewLine;
                                    sqlTxt += " , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID" + Environment.NewLine;
                                    sqlTxt += " , SLIPCOMMENTRF=@SLIPCOMMENT" + Environment.NewLine;
                                    sqlTxt += " , OUTPUTPGIDRF=@OUTPUTPGID" + Environment.NewLine;
                                    sqlTxt += " , OUTPUTPGCLASSIDRF=@OUTPUTPGCLASSID" + Environment.NewLine;
                                    sqlTxt += " , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME" + Environment.NewLine;
                                    sqlTxt += " , ENTERPRISENAMEPRTCDRF=@ENTERPRISENAMEPRTCD" + Environment.NewLine;
                                    sqlTxt += " , PRTCIRCULATIONRF=@PRTCIRCULATION" + Environment.NewLine;
                                    sqlTxt += " , SLIPFORMCDRF=@SLIPFORMCD" + Environment.NewLine;
                                    sqlTxt += " , OUTCONFIMATIONMSGRF=@OUTCONFIMATIONMSG" + Environment.NewLine;
                                    sqlTxt += " , OPTIONCODERF=@OPTIONCODE" + Environment.NewLine;
                                    sqlTxt += " , TOPMARGINRF=@TOPMARGIN" + Environment.NewLine;
                                    sqlTxt += " , LEFTMARGINRF=@LEFTMARGIN" + Environment.NewLine;
                                    sqlTxt += " , RIGHTMARGINRF=@RIGHTMARGIN" + Environment.NewLine;
                                    sqlTxt += " , BOTTOMMARGINRF=@BOTTOMMARGIN" + Environment.NewLine;
                                    sqlTxt += " , PRTPREVIEWEXISTCODERF=@PRTPREVIEWEXISTCODE" + Environment.NewLine;
                                    sqlTxt += " , OUTPUTPURPOSERF=@OUTPUTPURPOSE" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLID1RF=@EACHSLIPTYPECOLID1" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLNM1RF=@EACHSLIPTYPECOLNM1" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLPRT1RF=@EACHSLIPTYPECOLPRT1" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLID2RF=@EACHSLIPTYPECOLID2" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLNM2RF=@EACHSLIPTYPECOLNM2" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLPRT2RF=@EACHSLIPTYPECOLPRT2" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLID3RF=@EACHSLIPTYPECOLID3" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLNM3RF=@EACHSLIPTYPECOLNM3" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLPRT3RF=@EACHSLIPTYPECOLPRT3" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLID4RF=@EACHSLIPTYPECOLID4" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLNM4RF=@EACHSLIPTYPECOLNM4" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLPRT4RF=@EACHSLIPTYPECOLPRT4" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLID5RF=@EACHSLIPTYPECOLID5" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLNM5RF=@EACHSLIPTYPECOLNM5" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLPRT5RF=@EACHSLIPTYPECOLPRT5" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLID6RF=@EACHSLIPTYPECOLID6" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLNM6RF=@EACHSLIPTYPECOLNM6" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLPRT6RF=@EACHSLIPTYPECOLPRT6" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLID7RF=@EACHSLIPTYPECOLID7" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLNM7RF=@EACHSLIPTYPECOLNM7" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLPRT7RF=@EACHSLIPTYPECOLPRT7" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLID8RF=@EACHSLIPTYPECOLID8" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLNM8RF=@EACHSLIPTYPECOLNM8" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLPRT8RF=@EACHSLIPTYPECOLPRT8" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLID9RF=@EACHSLIPTYPECOLID9" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLNM9RF=@EACHSLIPTYPECOLNM9" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLPRT9RF=@EACHSLIPTYPECOLPRT9" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLID10RF=@EACHSLIPTYPECOLID10" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLNM10RF=@EACHSLIPTYPECOLNM10" + Environment.NewLine;
                                    sqlTxt += " , EACHSLIPTYPECOLPRT10RF=@EACHSLIPTYPECOLPRT10" + Environment.NewLine;
                                    sqlTxt += " , SLIPFONTNAMERF=@SLIPFONTNAME" + Environment.NewLine;
                                    sqlTxt += " , SLIPFONTSIZERF=@SLIPFONTSIZE" + Environment.NewLine;
                                    sqlTxt += " , SLIPFONTSTYLERF=@SLIPFONTSTYLE" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORRED1RF=@SLIPBASECOLORRED1" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORGRN1RF=@SLIPBASECOLORGRN1" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORBLU1RF=@SLIPBASECOLORBLU1" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORRED2RF=@SLIPBASECOLORRED2" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORGRN2RF=@SLIPBASECOLORGRN2" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORBLU2RF=@SLIPBASECOLORBLU2" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORRED3RF=@SLIPBASECOLORRED3" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORGRN3RF=@SLIPBASECOLORGRN3" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORBLU3RF=@SLIPBASECOLORBLU3" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORRED4RF=@SLIPBASECOLORRED4" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORGRN4RF=@SLIPBASECOLORGRN4" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORBLU4RF=@SLIPBASECOLORBLU4" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORRED5RF=@SLIPBASECOLORRED5" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORGRN5RF=@SLIPBASECOLORGRN5" + Environment.NewLine;
                                    sqlTxt += " , SLIPBASECOLORBLU5RF=@SLIPBASECOLORBLU5" + Environment.NewLine;
                                    sqlTxt += " , COPYCOUNTRF=@COPYCOUNT" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME1RF=@TITLENAME1" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME2RF=@TITLENAME2" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME3RF=@TITLENAME3" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME4RF=@TITLENAME4" + Environment.NewLine;
                                    sqlTxt += " , SPECIALPURPOSE1RF=@SPECIALPURPOSE1" + Environment.NewLine;
                                    sqlTxt += " , SPECIALPURPOSE2RF=@SPECIALPURPOSE2" + Environment.NewLine;
                                    sqlTxt += " , SPECIALPURPOSE3RF=@SPECIALPURPOSE3" + Environment.NewLine;
                                    sqlTxt += " , SPECIALPURPOSE4RF=@SPECIALPURPOSE4" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME102RF=@TITLENAME102" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME103RF=@TITLENAME103" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME104RF=@TITLENAME104" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME105RF=@TITLENAME105" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME202RF=@TITLENAME202" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME203RF=@TITLENAME203" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME204RF=@TITLENAME204" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME205RF=@TITLENAME205" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME302RF=@TITLENAME302" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME303RF=@TITLENAME303" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME304RF=@TITLENAME304" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME305RF=@TITLENAME305" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME402RF=@TITLENAME402" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME403RF=@TITLENAME403" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME404RF=@TITLENAME404" + Environment.NewLine;
                                    sqlTxt += " , TITLENAME405RF=@TITLENAME405" + Environment.NewLine;
                                    sqlTxt += " , NOTE1RF=@NOTE1" + Environment.NewLine;
                                    sqlTxt += " , NOTE2RF=@NOTE2" + Environment.NewLine;
                                    sqlTxt += " , NOTE3RF=@NOTE3" + Environment.NewLine;
                                    sqlTxt += " , QRCODEPRINTDIVCDRF=@QRCODEPRINTDIVCD" + Environment.NewLine;
                                    sqlTxt += " , TIMEPRINTDIVCDRF=@TIMEPRINTDIVCD" + Environment.NewLine;
                                    sqlTxt += " , REISSUEMARKRF=@REISSUEMARK" + Environment.NewLine;
                                    sqlTxt += " , REFCONSTAXDIVCDRF=@REFCONSTAXDIVCD" + Environment.NewLine;
                                    sqlTxt += " , REFCONSTAXPRTNMRF=@REFCONSTAXPRTNM" + Environment.NewLine;
                                    sqlTxt += " , DETAILROWCOUNTRF=@DETAILROWCOUNT" + Environment.NewLine;
                                    sqlTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                                    sqlTxt += "    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND" + Environment.NewLine;
                                    sqlTxt += "    AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.28 upd end ----------------------------------<<
                                    //KEYコマンドを再設定
                                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
                                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
                                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
                                    findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);
                                    //更新ヘッダ情報を設定
                                    //FileHeaderGuidはSelect結果から取得
                                    slipPrtSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                                    obj = (object)this;
                                    flhd = (IFileHeader)slipPrtSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                }
                                else
                                {
                                    //Insertコマンドの生成
                                    // 2008.05.28 upd start -------------------------------->>
                                    //sqlCommand.CommandText = "INSERT INTO SLIPPRTSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, SLIPCOMMENTRF, OUTPUTPGIDRF, OUTPUTPGCLASSIDRF, OUTPUTFORMFILENAMERF, ENTERPRISENAMEPRTCDRF, PRTCIRCULATIONRF, SLIPFORMCDRF, OUTCONFIMATIONMSGRF, OPTIONCODERF, PRINTERMNGNORF, TOPMARGINRF, LEFTMARGINRF, RIGHTMARGINRF, BOTTOMMARGINRF, PRTPREVIEWEXISTCODERF, OUTPUTPURPOSERF, EACHSLIPTYPECOLID1RF, EACHSLIPTYPECOLNM1RF, EACHSLIPTYPECOLPRT1RF, EACHSLIPTYPECOLID2RF, EACHSLIPTYPECOLNM2RF, EACHSLIPTYPECOLPRT2RF, EACHSLIPTYPECOLID3RF, EACHSLIPTYPECOLNM3RF, EACHSLIPTYPECOLPRT3RF, EACHSLIPTYPECOLID4RF, EACHSLIPTYPECOLNM4RF, EACHSLIPTYPECOLPRT4RF, EACHSLIPTYPECOLID5RF, EACHSLIPTYPECOLNM5RF, EACHSLIPTYPECOLPRT5RF, EACHSLIPTYPECOLID6RF, EACHSLIPTYPECOLNM6RF, EACHSLIPTYPECOLPRT6RF, EACHSLIPTYPECOLID7RF, EACHSLIPTYPECOLNM7RF, EACHSLIPTYPECOLPRT7RF, EACHSLIPTYPECOLID8RF, EACHSLIPTYPECOLNM8RF, EACHSLIPTYPECOLPRT8RF, EACHSLIPTYPECOLID9RF, EACHSLIPTYPECOLNM9RF, EACHSLIPTYPECOLPRT9RF, EACHSLIPTYPECOLID10RF, EACHSLIPTYPECOLNM10RF, EACHSLIPTYPECOLPRT10RF, SLIPFONTNAMERF, SLIPFONTSIZERF, SLIPFONTSTYLERF, SLIPBASECOLORRED1RF, SLIPBASECOLORGRN1RF, SLIPBASECOLORBLU1RF, SLIPBASECOLORRED2RF, SLIPBASECOLORGRN2RF, SLIPBASECOLORBLU2RF, SLIPBASECOLORRED3RF, SLIPBASECOLORGRN3RF, SLIPBASECOLORBLU3RF, SLIPBASECOLORRED4RF, SLIPBASECOLORGRN4RF, SLIPBASECOLORBLU4RF, SLIPBASECOLORRED5RF, SLIPBASECOLORGRN5RF, SLIPBASECOLORBLU5RF, CUSTTELNOPRTDIVCDRF, COPYCOUNTRF, TITLENAME1RF, TITLENAME2RF, TITLENAME3RF, TITLENAME4RF, SPECIALPURPOSE1RF, SPECIALPURPOSE2RF, SPECIALPURPOSE3RF, SPECIALPURPOSE4RF, BARCODEACPODRNOPRTCDRF, BARCODECUSTCODEPRTCDRF, TITLENAME102RF, TITLENAME103RF, TITLENAME104RF, TITLENAME105RF, TITLENAME202RF, TITLENAME203RF, TITLENAME204RF, TITLENAME205RF, TITLENAME302RF, TITLENAME303RF, TITLENAME304RF, TITLENAME305RF, TITLENAME402RF, TITLENAME403RF, TITLENAME404RF, TITLENAME405RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DATAINPUTSYSTEM, @SLIPPRTKIND, @SLIPPRTSETPAPERID, @SLIPCOMMENT, @OUTPUTPGID, @OUTPUTPGCLASSID, @OUTPUTFORMFILENAME, @ENTERPRISENAMEPRTCD, @PRTCIRCULATION, @SLIPFORMCD, @OUTCONFIMATIONMSG, @OPTIONCODE, @PRINTERMNGNO, @TOPMARGIN, @LEFTMARGIN, @RIGHTMARGIN, @BOTTOMMARGIN, @PRTPREVIEWEXISTCODE, @OUTPUTPURPOSE, @EACHSLIPTYPECOLID1, @EACHSLIPTYPECOLNM1, @EACHSLIPTYPECOLPRT1, @EACHSLIPTYPECOLID2, @EACHSLIPTYPECOLNM2, @EACHSLIPTYPECOLPRT2, @EACHSLIPTYPECOLID3, @EACHSLIPTYPECOLNM3, @EACHSLIPTYPECOLPRT3, @EACHSLIPTYPECOLID4, @EACHSLIPTYPECOLNM4, @EACHSLIPTYPECOLPRT4, @EACHSLIPTYPECOLID5, @EACHSLIPTYPECOLNM5, @EACHSLIPTYPECOLPRT5, @EACHSLIPTYPECOLID6, @EACHSLIPTYPECOLNM6, @EACHSLIPTYPECOLPRT6, @EACHSLIPTYPECOLID7, @EACHSLIPTYPECOLNM7, @EACHSLIPTYPECOLPRT7, @EACHSLIPTYPECOLID8, @EACHSLIPTYPECOLNM8, @EACHSLIPTYPECOLPRT8, @EACHSLIPTYPECOLID9, @EACHSLIPTYPECOLNM9, @EACHSLIPTYPECOLPRT9, @EACHSLIPTYPECOLID10, @EACHSLIPTYPECOLNM10, @EACHSLIPTYPECOLPRT10, @SLIPFONTNAME, @SLIPFONTSIZE, @SLIPFONTSTYLE, @SLIPBASECOLORRED1, @SLIPBASECOLORGRN1, @SLIPBASECOLORBLU1, @SLIPBASECOLORRED2, @SLIPBASECOLORGRN2, @SLIPBASECOLORBLU2, @SLIPBASECOLORRED3, @SLIPBASECOLORGRN3, @SLIPBASECOLORBLU3, @SLIPBASECOLORRED4, @SLIPBASECOLORGRN4, @SLIPBASECOLORBLU4, @SLIPBASECOLORRED5, @SLIPBASECOLORGRN5, @SLIPBASECOLORBLU5, @CUSTTELNOPRTDIVCD, @COPYCOUNT, @TITLENAME1, @TITLENAME2, @TITLENAME3, @TITLENAME4, @SPECIALPURPOSE1, @SPECIALPURPOSE2, @SPECIALPURPOSE3, @SPECIALPURPOSE4, @BARCODEACPODRNOPRTCD, @BARCODECUSTCODEPRTCD, @TITLENAME102, @TITLENAME103, @TITLENAME104, @TITLENAME105, @TITLENAME202, @TITLENAME203, @TITLENAME204, @TITLENAME205, @TITLENAME302, @TITLENAME303, @TITLENAME304, @TITLENAME305, @TITLENAME402, @TITLENAME403, @TITLENAME404, @TITLENAME405)";
                                    sqlTxt = string.Empty;
                                    sqlTxt += "INSERT INTO SLIPPRTSETRF" + Environment.NewLine;
                                    sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                    sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                                    sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                                    sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                                    sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                                    sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                                    sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                                    sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                                    sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                                    sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                                    sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                                    sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                                    sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                                    sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                                    sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                                    sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                                    sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                                    sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                                    sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                                    sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                                    sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                                    sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                                    sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                                    sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                                    sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlTxt += " VALUES" + Environment.NewLine;
                                    sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                                    sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                                    sqlTxt += "    ,@DATAINPUTSYSTEM" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPPRTKIND" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPPRTSETPAPERID" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPCOMMENT" + Environment.NewLine;
                                    sqlTxt += "    ,@OUTPUTPGID" + Environment.NewLine;
                                    sqlTxt += "    ,@OUTPUTPGCLASSID" + Environment.NewLine;
                                    sqlTxt += "    ,@OUTPUTFORMFILENAME" + Environment.NewLine;
                                    sqlTxt += "    ,@ENTERPRISENAMEPRTCD" + Environment.NewLine;
                                    sqlTxt += "    ,@PRTCIRCULATION" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPFORMCD" + Environment.NewLine;
                                    sqlTxt += "    ,@OUTCONFIMATIONMSG" + Environment.NewLine;
                                    sqlTxt += "    ,@OPTIONCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@TOPMARGIN" + Environment.NewLine;
                                    sqlTxt += "    ,@LEFTMARGIN" + Environment.NewLine;
                                    sqlTxt += "    ,@RIGHTMARGIN" + Environment.NewLine;
                                    sqlTxt += "    ,@BOTTOMMARGIN" + Environment.NewLine;
                                    sqlTxt += "    ,@PRTPREVIEWEXISTCODE" + Environment.NewLine;
                                    sqlTxt += "    ,@OUTPUTPURPOSE" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLID1" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLNM1" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLPRT1" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLID2" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLNM2" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLPRT2" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLID3" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLNM3" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLPRT3" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLID4" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLNM4" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLPRT4" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLID5" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLNM5" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLPRT5" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLID6" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLNM6" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLPRT6" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLID7" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLNM7" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLPRT7" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLID8" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLNM8" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLPRT8" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLID9" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLNM9" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLPRT9" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLID10" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLNM10" + Environment.NewLine;
                                    sqlTxt += "    ,@EACHSLIPTYPECOLPRT10" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPFONTNAME" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPFONTSIZE" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPFONTSTYLE" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORRED1" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORGRN1" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORBLU1" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORRED2" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORGRN2" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORBLU2" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORRED3" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORGRN3" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORBLU3" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORRED4" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORGRN4" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORBLU4" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORRED5" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORGRN5" + Environment.NewLine;
                                    sqlTxt += "    ,@SLIPBASECOLORBLU5" + Environment.NewLine;
                                    sqlTxt += "    ,@COPYCOUNT" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME1" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME2" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME3" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME4" + Environment.NewLine;
                                    sqlTxt += "    ,@SPECIALPURPOSE1" + Environment.NewLine;
                                    sqlTxt += "    ,@SPECIALPURPOSE2" + Environment.NewLine;
                                    sqlTxt += "    ,@SPECIALPURPOSE3" + Environment.NewLine;
                                    sqlTxt += "    ,@SPECIALPURPOSE4" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME102" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME103" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME104" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME105" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME202" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME203" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME204" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME205" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME302" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME303" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME304" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME305" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME402" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME403" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME404" + Environment.NewLine;
                                    sqlTxt += "    ,@TITLENAME405" + Environment.NewLine;
                                    sqlTxt += "    ,@NOTE1" + Environment.NewLine;
                                    sqlTxt += "    ,@NOTE2" + Environment.NewLine;
                                    sqlTxt += "    ,@NOTE3" + Environment.NewLine;
                                    sqlTxt += "    ,@QRCODEPRINTDIVCD" + Environment.NewLine;
                                    sqlTxt += "    ,@TIMEPRINTDIVCD" + Environment.NewLine;
                                    sqlTxt += "    ,@REISSUEMARK" + Environment.NewLine;
                                    sqlTxt += "    ,@REFCONSTAXDIVCD" + Environment.NewLine;
                                    sqlTxt += "    ,@REFCONSTAXPRTNM" + Environment.NewLine;
                                    sqlTxt += "    ,@DETAILROWCOUNT" + Environment.NewLine;
                                    sqlTxt += " )" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlTxt;
                                    // 2008.05.28 upd end ----------------------------------<<
                                    //登録ヘッダ情報を設定
                                    obj = (object)this;
                                    flhd = (IFileHeader)slipPrtSetWork;
                                    fileHeader = new ClientFileHeader(obj);
                                    fileHeader.SetInsertHeader(ref flhd, obj);
                                }
                                if (myReader.IsClosed == false) myReader.Close();
                                break;

                            //全件登録のシンク処理
                            case 1:
                                //Insertコマンドの生成
                                //sqlCommand = new SqlCommand("INSERT INTO SLIPPRTSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, SLIPCOMMENTRF, OUTPUTPGIDRF, OUTPUTPGCLASSIDRF, OUTPUTFORMFILENAMERF, ENTERPRISENAMEPRTCDRF, PRTCIRCULATIONRF, SLIPFORMCDRF, OUTCONFIMATIONMSGRF, OPTIONCODERF, PRINTERMNGNORF, TOPMARGINRF, LEFTMARGINRF, RIGHTMARGINRF, BOTTOMMARGINRF, PRTPREVIEWEXISTCODERF, OUTPUTPURPOSERF, EACHSLIPTYPECOLID1RF, EACHSLIPTYPECOLNM1RF, EACHSLIPTYPECOLPRT1RF, EACHSLIPTYPECOLID2RF, EACHSLIPTYPECOLNM2RF, EACHSLIPTYPECOLPRT2RF, EACHSLIPTYPECOLID3RF, EACHSLIPTYPECOLNM3RF, EACHSLIPTYPECOLPRT3RF, EACHSLIPTYPECOLID4RF, EACHSLIPTYPECOLNM4RF, EACHSLIPTYPECOLPRT4RF, EACHSLIPTYPECOLID5RF, EACHSLIPTYPECOLNM5RF, EACHSLIPTYPECOLPRT5RF, EACHSLIPTYPECOLID6RF, EACHSLIPTYPECOLNM6RF, EACHSLIPTYPECOLPRT6RF, EACHSLIPTYPECOLID7RF, EACHSLIPTYPECOLNM7RF, EACHSLIPTYPECOLPRT7RF, EACHSLIPTYPECOLID8RF, EACHSLIPTYPECOLNM8RF, EACHSLIPTYPECOLPRT8RF, EACHSLIPTYPECOLID9RF, EACHSLIPTYPECOLNM9RF, EACHSLIPTYPECOLPRT9RF, EACHSLIPTYPECOLID10RF, EACHSLIPTYPECOLNM10RF, EACHSLIPTYPECOLPRT10RF, SLIPFONTNAMERF, SLIPFONTSIZERF, SLIPFONTSTYLERF, SLIPBASECOLORRED1RF, SLIPBASECOLORGRN1RF, SLIPBASECOLORBLU1RF, SLIPBASECOLORRED2RF, SLIPBASECOLORGRN2RF, SLIPBASECOLORBLU2RF, SLIPBASECOLORRED3RF, SLIPBASECOLORGRN3RF, SLIPBASECOLORBLU3RF, SLIPBASECOLORRED4RF, SLIPBASECOLORGRN4RF, SLIPBASECOLORBLU4RF, SLIPBASECOLORRED5RF, SLIPBASECOLORGRN5RF, SLIPBASECOLORBLU5RF, CUSTTELNOPRTDIVCDRF, COPYCOUNTRF, TITLENAME1RF, TITLENAME2RF, TITLENAME3RF, TITLENAME4RF, SPECIALPURPOSE1RF, SPECIALPURPOSE2RF, SPECIALPURPOSE3RF, SPECIALPURPOSE4RF, BARCODEACPODRNOPRTCDRF, BARCODECUSTCODEPRTCDRF, TITLENAME102RF, TITLENAME103RF, TITLENAME104RF, TITLENAME105RF, TITLENAME202RF, TITLENAME203RF, TITLENAME204RF, TITLENAME205RF, TITLENAME302RF, TITLENAME303RF, TITLENAME304RF, TITLENAME305RF, TITLENAME402RF, TITLENAME403RF, TITLENAME404RF, TITLENAME405RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DATAINPUTSYSTEM, @SLIPPRTKIND, @SLIPPRTSETPAPERID, @SLIPCOMMENT, @OUTPUTPGID, @OUTPUTPGCLASSID, @OUTPUTFORMFILENAME, @ENTERPRISENAMEPRTCD, @PRTCIRCULATION, @SLIPFORMCD, @OUTCONFIMATIONMSG, @OPTIONCODE, @PRINTERMNGNO, @TOPMARGIN, @LEFTMARGIN, @RIGHTMARGIN, @BOTTOMMARGIN, @PRTPREVIEWEXISTCODE, @OUTPUTPURPOSE, @EACHSLIPTYPECOLID1, @EACHSLIPTYPECOLNM1, @EACHSLIPTYPECOLPRT1, @EACHSLIPTYPECOLID2, @EACHSLIPTYPECOLNM2, @EACHSLIPTYPECOLPRT2, @EACHSLIPTYPECOLID3, @EACHSLIPTYPECOLNM3, @EACHSLIPTYPECOLPRT3, @EACHSLIPTYPECOLID4, @EACHSLIPTYPECOLNM4, @EACHSLIPTYPECOLPRT4, @EACHSLIPTYPECOLID5, @EACHSLIPTYPECOLNM5, @EACHSLIPTYPECOLPRT5, @EACHSLIPTYPECOLID6, @EACHSLIPTYPECOLNM6, @EACHSLIPTYPECOLPRT6, @EACHSLIPTYPECOLID7, @EACHSLIPTYPECOLNM7, @EACHSLIPTYPECOLPRT7, @EACHSLIPTYPECOLID8, @EACHSLIPTYPECOLNM8, @EACHSLIPTYPECOLPRT8, @EACHSLIPTYPECOLID9, @EACHSLIPTYPECOLNM9, @EACHSLIPTYPECOLPRT9, @EACHSLIPTYPECOLID10, @EACHSLIPTYPECOLNM10, @EACHSLIPTYPECOLPRT10, @SLIPFONTNAME, @SLIPFONTSIZE, @SLIPFONTSTYLE, @SLIPBASECOLORRED1, @SLIPBASECOLORGRN1, @SLIPBASECOLORBLU1, @SLIPBASECOLORRED2, @SLIPBASECOLORGRN2, @SLIPBASECOLORBLU2, @SLIPBASECOLORRED3, @SLIPBASECOLORGRN3, @SLIPBASECOLORBLU3, @SLIPBASECOLORRED4, @SLIPBASECOLORGRN4, @SLIPBASECOLORBLU4, @SLIPBASECOLORRED5, @SLIPBASECOLORGRN5, @SLIPBASECOLORBLU5, @CUSTTELNOPRTDIVCD, @COPYCOUNT, @TITLENAME1, @TITLENAME2, @TITLENAME3, @TITLENAME4, @SPECIALPURPOSE1, @SPECIALPURPOSE2, @SPECIALPURPOSE3, @SPECIALPURPOSE4, @BARCODEACPODRNOPRTCD, @BARCODECUSTCODEPRTCD, @TITLENAME102, @TITLENAME103, @TITLENAME104, @TITLENAME105, @TITLENAME202, @TITLENAME203, @TITLENAME204, @TITLENAME205, @TITLENAME302, @TITLENAME303, @TITLENAME304, @TITLENAME305, @TITLENAME402, @TITLENAME403, @TITLENAME404, @TITLENAME405)", sqlConnection, sqlTransaction);
                                // 2008.05.28 upd start ------------------------------------->>
                                sqlTxt = string.Empty;
                                sqlTxt += "INSERT INTO SLIPPRTSETRF" + Environment.NewLine;
                                sqlTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlTxt += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlTxt += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlTxt += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlTxt += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlTxt += "    ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPPRTKINDRF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPCOMMENTRF" + Environment.NewLine;
                                sqlTxt += "    ,OUTPUTPGIDRF" + Environment.NewLine;
                                sqlTxt += "    ,OUTPUTPGCLASSIDRF" + Environment.NewLine;
                                sqlTxt += "    ,OUTPUTFORMFILENAMERF" + Environment.NewLine;
                                sqlTxt += "    ,ENTERPRISENAMEPRTCDRF" + Environment.NewLine;
                                sqlTxt += "    ,PRTCIRCULATIONRF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPFORMCDRF" + Environment.NewLine;
                                sqlTxt += "    ,OUTCONFIMATIONMSGRF" + Environment.NewLine;
                                sqlTxt += "    ,OPTIONCODERF" + Environment.NewLine;
                                sqlTxt += "    ,TOPMARGINRF" + Environment.NewLine;
                                sqlTxt += "    ,LEFTMARGINRF" + Environment.NewLine;
                                sqlTxt += "    ,RIGHTMARGINRF" + Environment.NewLine;
                                sqlTxt += "    ,BOTTOMMARGINRF" + Environment.NewLine;
                                sqlTxt += "    ,PRTPREVIEWEXISTCODERF" + Environment.NewLine;
                                sqlTxt += "    ,OUTPUTPURPOSERF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID1RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM1RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT1RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID2RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM2RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT2RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID3RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM3RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT3RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID4RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM4RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT4RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID5RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM5RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT5RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID6RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM6RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT6RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID7RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM7RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT7RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID8RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM8RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT8RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID9RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM9RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT9RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLID10RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLNM10RF" + Environment.NewLine;
                                sqlTxt += "    ,EACHSLIPTYPECOLPRT10RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPFONTNAMERF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPFONTSIZERF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPFONTSTYLERF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORRED1RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORGRN1RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORBLU1RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORRED2RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORGRN2RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORBLU2RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORRED3RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORGRN3RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORBLU3RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORRED4RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORGRN4RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORBLU4RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORRED5RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORGRN5RF" + Environment.NewLine;
                                sqlTxt += "    ,SLIPBASECOLORBLU5RF" + Environment.NewLine;
                                sqlTxt += "    ,COPYCOUNTRF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME1RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME2RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME3RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME4RF" + Environment.NewLine;
                                sqlTxt += "    ,SPECIALPURPOSE1RF" + Environment.NewLine;
                                sqlTxt += "    ,SPECIALPURPOSE2RF" + Environment.NewLine;
                                sqlTxt += "    ,SPECIALPURPOSE3RF" + Environment.NewLine;
                                sqlTxt += "    ,SPECIALPURPOSE4RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME102RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME103RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME104RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME105RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME202RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME203RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME204RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME205RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME302RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME303RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME304RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME305RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME402RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME403RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME404RF" + Environment.NewLine;
                                sqlTxt += "    ,TITLENAME405RF" + Environment.NewLine;
                                sqlTxt += "    ,NOTE1RF" + Environment.NewLine;
                                sqlTxt += "    ,NOTE2RF" + Environment.NewLine;
                                sqlTxt += "    ,NOTE3RF" + Environment.NewLine;
                                sqlTxt += "    ,QRCODEPRINTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,TIMEPRINTDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,REISSUEMARKRF" + Environment.NewLine;
                                sqlTxt += "    ,REFCONSTAXDIVCDRF" + Environment.NewLine;
                                sqlTxt += "    ,REFCONSTAXPRTNMRF" + Environment.NewLine;
                                sqlTxt += "    ,DETAILROWCOUNTRF" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlTxt += " VALUES" + Environment.NewLine;
                                sqlTxt += " (@CREATEDATETIME" + Environment.NewLine;
                                sqlTxt += "    ,@UPDATEDATETIME" + Environment.NewLine;
                                sqlTxt += "    ,@ENTERPRISECODE" + Environment.NewLine;
                                sqlTxt += "    ,@FILEHEADERGUID" + Environment.NewLine;
                                sqlTxt += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                                sqlTxt += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                                sqlTxt += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                                sqlTxt += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                                sqlTxt += "    ,@DATAINPUTSYSTEM" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPPRTKIND" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPPRTSETPAPERID" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPCOMMENT" + Environment.NewLine;
                                sqlTxt += "    ,@OUTPUTPGID" + Environment.NewLine;
                                sqlTxt += "    ,@OUTPUTPGCLASSID" + Environment.NewLine;
                                sqlTxt += "    ,@OUTPUTFORMFILENAME" + Environment.NewLine;
                                sqlTxt += "    ,@ENTERPRISENAMEPRTCD" + Environment.NewLine;
                                sqlTxt += "    ,@PRTCIRCULATION" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPFORMCD" + Environment.NewLine;
                                sqlTxt += "    ,@OUTCONFIMATIONMSG" + Environment.NewLine;
                                sqlTxt += "    ,@OPTIONCODE" + Environment.NewLine;
                                sqlTxt += "    ,@TOPMARGIN" + Environment.NewLine;
                                sqlTxt += "    ,@LEFTMARGIN" + Environment.NewLine;
                                sqlTxt += "    ,@RIGHTMARGIN" + Environment.NewLine;
                                sqlTxt += "    ,@BOTTOMMARGIN" + Environment.NewLine;
                                sqlTxt += "    ,@PRTPREVIEWEXISTCODE" + Environment.NewLine;
                                sqlTxt += "    ,@OUTPUTPURPOSE" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLID1" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLNM1" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLPRT1" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLID2" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLNM2" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLPRT2" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLID3" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLNM3" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLPRT3" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLID4" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLNM4" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLPRT4" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLID5" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLNM5" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLPRT5" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLID6" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLNM6" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLPRT6" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLID7" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLNM7" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLPRT7" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLID8" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLNM8" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLPRT8" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLID9" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLNM9" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLPRT9" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLID10" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLNM10" + Environment.NewLine;
                                sqlTxt += "    ,@EACHSLIPTYPECOLPRT10" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPFONTNAME" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPFONTSIZE" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPFONTSTYLE" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORRED1" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORGRN1" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORBLU1" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORRED2" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORGRN2" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORBLU2" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORRED3" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORGRN3" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORBLU3" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORRED4" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORGRN4" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORBLU4" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORRED5" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORGRN5" + Environment.NewLine;
                                sqlTxt += "    ,@SLIPBASECOLORBLU5" + Environment.NewLine;
                                sqlTxt += "    ,@COPYCOUNT" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME1" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME2" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME3" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME4" + Environment.NewLine;
                                sqlTxt += "    ,@SPECIALPURPOSE1" + Environment.NewLine;
                                sqlTxt += "    ,@SPECIALPURPOSE2" + Environment.NewLine;
                                sqlTxt += "    ,@SPECIALPURPOSE3" + Environment.NewLine;
                                sqlTxt += "    ,@SPECIALPURPOSE4" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME102" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME103" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME104" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME105" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME202" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME203" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME204" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME205" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME302" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME303" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME304" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME305" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME402" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME403" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME404" + Environment.NewLine;
                                sqlTxt += "    ,@TITLENAME405" + Environment.NewLine;
                                sqlTxt += "    ,@NOTE1" + Environment.NewLine;
                                sqlTxt += "    ,@NOTE2" + Environment.NewLine;
                                sqlTxt += "    ,@NOTE3" + Environment.NewLine;
                                sqlTxt += "    ,@QRCODEPRINTDIVCD" + Environment.NewLine;
                                sqlTxt += "    ,@TIMEPRINTDIVCD" + Environment.NewLine;
                                sqlTxt += "    ,@REISSUEMARK" + Environment.NewLine;
                                sqlTxt += "    ,@REFCONSTAXDIVCD" + Environment.NewLine;
                                sqlTxt += "    ,@REFCONSTAXPRTNM" + Environment.NewLine;
                                sqlTxt += "    ,@DETAILROWCOUNT" + Environment.NewLine;
                                sqlTxt += " )" + Environment.NewLine;
                                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);
                                // 2008.05.28 upd end ---------------------------------------<<
                                //登録ヘッダ情報を設定
                                obj = (object)this;
                                flhd = (IFileHeader)slipPrtSetWork;
                                fileHeader = new ClientFileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);
                                break;
                        }

                        #region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                        SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                        SqlParameter paraSlipComment = sqlCommand.Parameters.Add("@SLIPCOMMENT", SqlDbType.NVarChar);
                        SqlParameter paraOutputPgId = sqlCommand.Parameters.Add("@OUTPUTPGID", SqlDbType.NVarChar);
                        SqlParameter paraOutputPgClassId = sqlCommand.Parameters.Add("@OUTPUTPGCLASSID", SqlDbType.NVarChar);
                        SqlParameter paraOutputFormFileName = sqlCommand.Parameters.Add("@OUTPUTFORMFILENAME", SqlDbType.NVarChar);
                        SqlParameter paraEnterpriseNamePrtCd = sqlCommand.Parameters.Add("@ENTERPRISENAMEPRTCD", SqlDbType.Int);
                        SqlParameter paraPrtCirculation = sqlCommand.Parameters.Add("@PRTCIRCULATION", SqlDbType.Int);
                        SqlParameter paraSlipFormCd = sqlCommand.Parameters.Add("@SLIPFORMCD", SqlDbType.Int);
                        SqlParameter paraOutConfimationMsg = sqlCommand.Parameters.Add("@OUTCONFIMATIONMSG", SqlDbType.NVarChar);
                        SqlParameter paraOptionCode = sqlCommand.Parameters.Add("@OPTIONCODE", SqlDbType.NVarChar);
                        SqlParameter paraTopMargin = sqlCommand.Parameters.Add("@TOPMARGIN", SqlDbType.Float);
                        SqlParameter paraLeftMargin = sqlCommand.Parameters.Add("@LEFTMARGIN", SqlDbType.Float);
                        SqlParameter paraRightMargin = sqlCommand.Parameters.Add("@RIGHTMARGIN", SqlDbType.Float);
                        SqlParameter paraBottomMargin = sqlCommand.Parameters.Add("@BOTTOMMARGIN", SqlDbType.Float);
                        SqlParameter paraPrtPreviewExistCode = sqlCommand.Parameters.Add("@PRTPREVIEWEXISTCODE", SqlDbType.Int);
                        SqlParameter paraOutputPurpose = sqlCommand.Parameters.Add("@OUTPUTPURPOSE", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId1 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID1", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm1 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM1", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt1 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT1", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId2 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID2", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm2 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM2", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt2 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT2", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId3 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID3", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm3 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM3", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt3 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT3", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId4 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID4", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm4 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM4", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt4 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT4", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId5 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID5", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm5 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM5", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt5 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT5", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId6 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID6", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm6 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM6", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt6 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT6", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId7 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID7", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm7 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM7", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt7 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT7", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId8 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID8", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm8 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM8", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt8 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT8", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId9 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID9", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm9 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM9", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt9 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT9", SqlDbType.Int);
                        SqlParameter paraEachSlipTypeColId10 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLID10", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColNm10 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLNM10", SqlDbType.NVarChar);
                        SqlParameter paraEachSlipTypeColPrt10 = sqlCommand.Parameters.Add("@EACHSLIPTYPECOLPRT10", SqlDbType.Int);
                        SqlParameter paraSlipFontName = sqlCommand.Parameters.Add("@SLIPFONTNAME", SqlDbType.NVarChar);
                        SqlParameter paraSlipFontSize = sqlCommand.Parameters.Add("@SLIPFONTSIZE", SqlDbType.Int);
                        SqlParameter paraSlipFontStyle = sqlCommand.Parameters.Add("@SLIPFONTSTYLE", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorRed1 = sqlCommand.Parameters.Add("@SLIPBASECOLORRED1", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorGrn1 = sqlCommand.Parameters.Add("@SLIPBASECOLORGRN1", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorBlu1 = sqlCommand.Parameters.Add("@SLIPBASECOLORBLU1", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorRed2 = sqlCommand.Parameters.Add("@SLIPBASECOLORRED2", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorGrn2 = sqlCommand.Parameters.Add("@SLIPBASECOLORGRN2", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorBlu2 = sqlCommand.Parameters.Add("@SLIPBASECOLORBLU2", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorRed3 = sqlCommand.Parameters.Add("@SLIPBASECOLORRED3", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorGrn3 = sqlCommand.Parameters.Add("@SLIPBASECOLORGRN3", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorBlu3 = sqlCommand.Parameters.Add("@SLIPBASECOLORBLU3", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorRed4 = sqlCommand.Parameters.Add("@SLIPBASECOLORRED4", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorGrn4 = sqlCommand.Parameters.Add("@SLIPBASECOLORGRN4", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorBlu4 = sqlCommand.Parameters.Add("@SLIPBASECOLORBLU4", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorRed5 = sqlCommand.Parameters.Add("@SLIPBASECOLORRED5", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorGrn5 = sqlCommand.Parameters.Add("@SLIPBASECOLORGRN5", SqlDbType.Int);
                        SqlParameter paraSlipBaseColorBlu5 = sqlCommand.Parameters.Add("@SLIPBASECOLORBLU5", SqlDbType.Int);
                        //SqlParameter paraCustTelNoPrtDivCd = sqlCommand.Parameters.Add("@CUSTTELNOPRTDIVCD", SqlDbType.Int); // 2008.05.28 del
                        SqlParameter paraCopyCount = sqlCommand.Parameters.Add("@COPYCOUNT", SqlDbType.Int);
                        SqlParameter paraTitleName1 = sqlCommand.Parameters.Add("@TITLENAME1", SqlDbType.NVarChar);
                        SqlParameter paraTitleName2 = sqlCommand.Parameters.Add("@TITLENAME2", SqlDbType.NVarChar);
                        SqlParameter paraTitleName3 = sqlCommand.Parameters.Add("@TITLENAME3", SqlDbType.NVarChar);
                        SqlParameter paraTitleName4 = sqlCommand.Parameters.Add("@TITLENAME4", SqlDbType.NVarChar);
                        SqlParameter paraSpecialPurpose1 = sqlCommand.Parameters.Add("@SPECIALPURPOSE1", SqlDbType.NVarChar);
                        SqlParameter paraSpecialPurpose2 = sqlCommand.Parameters.Add("@SPECIALPURPOSE2", SqlDbType.NVarChar);
                        SqlParameter paraSpecialPurpose3 = sqlCommand.Parameters.Add("@SPECIALPURPOSE3", SqlDbType.NVarChar);
                        SqlParameter paraSpecialPurpose4 = sqlCommand.Parameters.Add("@SPECIALPURPOSE4", SqlDbType.NVarChar);
                        //SqlParameter paraBarCodeAcpOdrNoPrtCd = sqlCommand.Parameters.Add("@BARCODEACPODRNOPRTCD", SqlDbType.Int); // 2008.05.28 del
                        //SqlParameter paraBarCodeCustCodePrtCd = sqlCommand.Parameters.Add("@BARCODECUSTCODEPRTCD", SqlDbType.Int); // 2008.05.28 del
                        SqlParameter paraTitleName102 = sqlCommand.Parameters.Add("@TITLENAME102", SqlDbType.NVarChar);
                        SqlParameter paraTitleName103 = sqlCommand.Parameters.Add("@TITLENAME103", SqlDbType.NVarChar);
                        SqlParameter paraTitleName104 = sqlCommand.Parameters.Add("@TITLENAME104", SqlDbType.NVarChar);
                        SqlParameter paraTitleName105 = sqlCommand.Parameters.Add("@TITLENAME105", SqlDbType.NVarChar);
                        SqlParameter paraTitleName202 = sqlCommand.Parameters.Add("@TITLENAME202", SqlDbType.NVarChar);
                        SqlParameter paraTitleName203 = sqlCommand.Parameters.Add("@TITLENAME203", SqlDbType.NVarChar);
                        SqlParameter paraTitleName204 = sqlCommand.Parameters.Add("@TITLENAME204", SqlDbType.NVarChar);
                        SqlParameter paraTitleName205 = sqlCommand.Parameters.Add("@TITLENAME205", SqlDbType.NVarChar);
                        SqlParameter paraTitleName302 = sqlCommand.Parameters.Add("@TITLENAME302", SqlDbType.NVarChar);
                        SqlParameter paraTitleName303 = sqlCommand.Parameters.Add("@TITLENAME303", SqlDbType.NVarChar);
                        SqlParameter paraTitleName304 = sqlCommand.Parameters.Add("@TITLENAME304", SqlDbType.NVarChar);
                        SqlParameter paraTitleName305 = sqlCommand.Parameters.Add("@TITLENAME305", SqlDbType.NVarChar);
                        SqlParameter paraTitleName402 = sqlCommand.Parameters.Add("@TITLENAME402", SqlDbType.NVarChar);
                        SqlParameter paraTitleName403 = sqlCommand.Parameters.Add("@TITLENAME403", SqlDbType.NVarChar);
                        SqlParameter paraTitleName404 = sqlCommand.Parameters.Add("@TITLENAME404", SqlDbType.NVarChar);
                        SqlParameter paraTitleName405 = sqlCommand.Parameters.Add("@TITLENAME405", SqlDbType.NVarChar);
                        // 2008.05.28 add start ---------------------------------------------------------------->>
                        SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                        SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                        SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                        SqlParameter paraQRCodePrintDivCd = sqlCommand.Parameters.Add("@QRCODEPRINTDIVCD", SqlDbType.Int);
                        SqlParameter paraTimePrintDivCd = sqlCommand.Parameters.Add("@TIMEPRINTDIVCD", SqlDbType.Int);
                        SqlParameter paraReissueMark = sqlCommand.Parameters.Add("@REISSUEMARK", SqlDbType.NVarChar);
                        SqlParameter paraRefConsTaxDivCd = sqlCommand.Parameters.Add("@REFCONSTAXDIVCD", SqlDbType.Int);
                        SqlParameter paraRefConsTaxPrtNm = sqlCommand.Parameters.Add("@REFCONSTAXPRTNM", SqlDbType.NVarChar);
                        SqlParameter paraDetailRowCount = sqlCommand.Parameters.Add("@DETAILROWCOUNT", SqlDbType.Int);
                        // 2008.05.28 add end ------------------------------------------------------------------<<
                        #endregion

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(slipPrtSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(slipPrtSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(slipPrtSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.LogicalDeleteCode);
                        paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DataInputSystem);
                        paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipPrtKind);
                        paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipPrtSetPaperId);
                        paraSlipComment.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipComment);
                        paraOutputPgId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.OutputPgId);
                        paraOutputPgClassId.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.OutputPgClassId);
                        paraOutputFormFileName.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.OutputFormFileName);
                        paraEnterpriseNamePrtCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EnterpriseNamePrtCd);
                        paraPrtCirculation.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.PrtCirculation);
                        paraSlipFormCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipFormCd);
                        paraOutConfimationMsg.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.OutConfimationMsg);
                        paraOptionCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.OptionCode);
                        paraTopMargin.Value = SqlDataMediator.SqlSetDouble(slipPrtSetWork.TopMargin);
                        paraLeftMargin.Value = SqlDataMediator.SqlSetDouble(slipPrtSetWork.LeftMargin);
                        paraRightMargin.Value = SqlDataMediator.SqlSetDouble(slipPrtSetWork.RightMargin);
                        paraBottomMargin.Value = SqlDataMediator.SqlSetDouble(slipPrtSetWork.BottomMargin);
                        paraPrtPreviewExistCode.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.PrtPreviewExistCode);
                        paraOutputPurpose.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.OutputPurpose);
                        paraEachSlipTypeColId1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId1);
                        paraEachSlipTypeColNm1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm1);
                        paraEachSlipTypeColPrt1.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt1);
                        paraEachSlipTypeColId2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId2);
                        paraEachSlipTypeColNm2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm2);
                        paraEachSlipTypeColPrt2.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt2);
                        paraEachSlipTypeColId3.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId3);
                        paraEachSlipTypeColNm3.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm3);
                        paraEachSlipTypeColPrt3.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt3);
                        paraEachSlipTypeColId4.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId4);
                        paraEachSlipTypeColNm4.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm4);
                        paraEachSlipTypeColPrt4.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt4);
                        paraEachSlipTypeColId5.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId5);
                        paraEachSlipTypeColNm5.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm5);
                        paraEachSlipTypeColPrt5.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt5);
                        paraEachSlipTypeColId6.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId6);
                        paraEachSlipTypeColNm6.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm6);
                        paraEachSlipTypeColPrt6.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt6);
                        paraEachSlipTypeColId7.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId7);
                        paraEachSlipTypeColNm7.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm7);
                        paraEachSlipTypeColPrt7.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt7);
                        paraEachSlipTypeColId8.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId8);
                        paraEachSlipTypeColNm8.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm8);
                        paraEachSlipTypeColPrt8.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt8);
                        paraEachSlipTypeColId9.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId9);
                        paraEachSlipTypeColNm9.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm9);
                        paraEachSlipTypeColPrt9.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt9);
                        paraEachSlipTypeColId10.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColId10);
                        paraEachSlipTypeColNm10.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EachSlipTypeColNm10);
                        paraEachSlipTypeColPrt10.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.EachSlipTypeColPrt10);
                        paraSlipFontName.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SlipFontName);
                        paraSlipFontSize.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipFontSize);
                        paraSlipFontStyle.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipFontStyle);
                        paraSlipBaseColorRed1.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorRed1);
                        paraSlipBaseColorGrn1.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorGrn1);
                        paraSlipBaseColorBlu1.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorBlu1);
                        paraSlipBaseColorRed2.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorRed2);
                        paraSlipBaseColorGrn2.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorGrn2);
                        paraSlipBaseColorBlu2.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorBlu2);
                        paraSlipBaseColorRed3.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorRed3);
                        paraSlipBaseColorGrn3.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorGrn3);
                        paraSlipBaseColorBlu3.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorBlu3);
                        paraSlipBaseColorRed4.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorRed4);
                        paraSlipBaseColorGrn4.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorGrn4);
                        paraSlipBaseColorBlu4.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorBlu4);
                        paraSlipBaseColorRed5.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorRed5);
                        paraSlipBaseColorGrn5.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorGrn5);
                        paraSlipBaseColorBlu5.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.SlipBaseColorBlu5);
                        //paraCustTelNoPrtDivCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.CustTelNoPrtDivCd); // 2008.05.28 del
                        paraCopyCount.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.CopyCount);
                        paraTitleName1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName1);
                        paraTitleName2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName2);
                        paraTitleName3.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName3);
                        paraTitleName4.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName4);
                        paraSpecialPurpose1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SpecialPurpose1);
                        paraSpecialPurpose2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SpecialPurpose2);
                        paraSpecialPurpose3.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SpecialPurpose3);
                        paraSpecialPurpose4.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.SpecialPurpose4);
                        //paraBarCodeAcpOdrNoPrtCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.BarCodeAcpOdrNoPrtCd); // 2008.05.28 del
                        //paraBarCodeCustCodePrtCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.BarCodeCustCodePrtCd); // 2008.05.28 del
                        paraTitleName102.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName102);
                        paraTitleName103.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName103);
                        paraTitleName104.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName104);
                        paraTitleName105.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName105);
                        paraTitleName202.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName202);
                        paraTitleName203.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName203);
                        paraTitleName204.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName204);
                        paraTitleName205.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName205);
                        paraTitleName302.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName302);
                        paraTitleName303.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName303);
                        paraTitleName304.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName304);
                        paraTitleName305.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName305);
                        paraTitleName402.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName402);
                        paraTitleName403.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName403);
                        paraTitleName404.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName404);
                        paraTitleName405.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.TitleName405);
                        // 2008.05.28 add start ---------------------------------------------------------------->>
                        paraNote1.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.Note1);
                        paraNote2.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.Note2);
                        paraNote3.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.Note3);
                        paraQRCodePrintDivCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.QRCodePrintDivCd);
                        paraTimePrintDivCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.TimePrintDivCd);
                        paraReissueMark.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.ReissueMark);
                        paraRefConsTaxDivCd.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.RefConsTaxDivCd);
                        paraRefConsTaxPrtNm.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.RefConsTaxPrtNm);
                        paraDetailRowCount.Value = SqlDataMediator.SqlSetInt32(slipPrtSetWork.DetailRowCount);
                        // 2008.05.28 add end ------------------------------------------------------------------<<
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                    //ユーザデータシンク管理マスタへ更新
                    DataSyncMngWork dataSyncMngWork = new DataSyncMngWork();
                    DataSyncMngLcDB dataSyncMngLcDB = new DataSyncMngLcDB();
                    List<DataSyncMngWork> dataSyncMngWorkList = new List<DataSyncMngWork>();
                    dataSyncMngWork.EnterpriseCode = syncServiceWork.EnterpriseCode;
                    dataSyncMngWork.LastDataUpdDate = syncServiceWork.SyncDateTimeEd;
                    dataSyncMngWork.SyncExecDate = syncServiceWork.SyncExecDate;
                    dataSyncMngWork.ManagementTableName = syncServiceWork.ManagementTableName;
                    dataSyncMngWork.DataDeleteDateTime = syncServiceWork.DataDeleteDateTime;
                    dataSyncMngWorkList.Add(dataSyncMngWork);
                    status = dataSyncMngLcDB.WriteDataSyncMngProc(ref dataSyncMngWorkList, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "SlipPrtSetLcDB.WriteSyncLocalDataProc", 0);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
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
        /// <param name="slipPrtSetWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SlipPrtSetWork slipPrtSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //企業コード
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(slipPrtSetWork.EnterpriseCode);

            //論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if (wkstring != "")
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
        /// クラス格納処理 Reader → SlipPrtSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SlipPrtSetWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        /// </remarks>
        private SlipPrtSetWork CopyToSlipPrtSetWorkFromReader(ref SqlDataReader myReader)
        {
            SlipPrtSetWork wkSlipPrtSetWork = new SlipPrtSetWork();

            #region クラスへ格納
            wkSlipPrtSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkSlipPrtSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSlipPrtSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkSlipPrtSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSlipPrtSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSlipPrtSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSlipPrtSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSlipPrtSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSlipPrtSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
            wkSlipPrtSetWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
            wkSlipPrtSetWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            wkSlipPrtSetWork.SlipComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPCOMMENTRF"));
            wkSlipPrtSetWork.OutputPgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
            wkSlipPrtSetWork.OutputPgClassId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
            wkSlipPrtSetWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
            wkSlipPrtSetWork.EnterpriseNamePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISENAMEPRTCDRF"));
            wkSlipPrtSetWork.PrtCirculation = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTCIRCULATIONRF"));
            wkSlipPrtSetWork.SlipFormCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFORMCDRF"));
            wkSlipPrtSetWork.OutConfimationMsg = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTCONFIMATIONMSGRF"));
            wkSlipPrtSetWork.OptionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
            wkSlipPrtSetWork.TopMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOPMARGINRF"));
            wkSlipPrtSetWork.LeftMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LEFTMARGINRF"));
            wkSlipPrtSetWork.RightMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RIGHTMARGINRF"));
            wkSlipPrtSetWork.BottomMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BOTTOMMARGINRF"));
            wkSlipPrtSetWork.PrtPreviewExistCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTPREVIEWEXISTCODERF"));
            wkSlipPrtSetWork.OutputPurpose = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTPURPOSERF"));
            wkSlipPrtSetWork.EachSlipTypeColId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID1RF"));
            wkSlipPrtSetWork.EachSlipTypeColNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM1RF"));
            wkSlipPrtSetWork.EachSlipTypeColPrt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT1RF"));
            wkSlipPrtSetWork.EachSlipTypeColId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID2RF"));
            wkSlipPrtSetWork.EachSlipTypeColNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM2RF"));
            wkSlipPrtSetWork.EachSlipTypeColPrt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT2RF"));
            wkSlipPrtSetWork.EachSlipTypeColId3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID3RF"));
            wkSlipPrtSetWork.EachSlipTypeColNm3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM3RF"));
            wkSlipPrtSetWork.EachSlipTypeColPrt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT3RF"));
            wkSlipPrtSetWork.EachSlipTypeColId4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID4RF"));
            wkSlipPrtSetWork.EachSlipTypeColNm4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM4RF"));
            wkSlipPrtSetWork.EachSlipTypeColPrt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT4RF"));
            wkSlipPrtSetWork.EachSlipTypeColId5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID5RF"));
            wkSlipPrtSetWork.EachSlipTypeColNm5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM5RF"));
            wkSlipPrtSetWork.EachSlipTypeColPrt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT5RF"));
            wkSlipPrtSetWork.EachSlipTypeColId6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID6RF"));
            wkSlipPrtSetWork.EachSlipTypeColNm6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM6RF"));
            wkSlipPrtSetWork.EachSlipTypeColPrt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT6RF"));
            wkSlipPrtSetWork.EachSlipTypeColId7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID7RF"));
            wkSlipPrtSetWork.EachSlipTypeColNm7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM7RF"));
            wkSlipPrtSetWork.EachSlipTypeColPrt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT7RF"));
            wkSlipPrtSetWork.EachSlipTypeColId8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID8RF"));
            wkSlipPrtSetWork.EachSlipTypeColNm8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM8RF"));
            wkSlipPrtSetWork.EachSlipTypeColPrt8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT8RF"));
            wkSlipPrtSetWork.EachSlipTypeColId9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID9RF"));
            wkSlipPrtSetWork.EachSlipTypeColNm9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM9RF"));
            wkSlipPrtSetWork.EachSlipTypeColPrt9 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT9RF"));
            wkSlipPrtSetWork.EachSlipTypeColId10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLID10RF"));
            wkSlipPrtSetWork.EachSlipTypeColNm10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLNM10RF"));
            wkSlipPrtSetWork.EachSlipTypeColPrt10 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EACHSLIPTYPECOLPRT10RF"));
            wkSlipPrtSetWork.SlipFontName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPFONTNAMERF"));
            wkSlipPrtSetWork.SlipFontSize = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFONTSIZERF"));
            wkSlipPrtSetWork.SlipFontStyle = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPFONTSTYLERF"));
            wkSlipPrtSetWork.SlipBaseColorRed1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED1RF"));
            wkSlipPrtSetWork.SlipBaseColorGrn1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN1RF"));
            wkSlipPrtSetWork.SlipBaseColorBlu1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU1RF"));
            wkSlipPrtSetWork.SlipBaseColorRed2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED2RF"));
            wkSlipPrtSetWork.SlipBaseColorGrn2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN2RF"));
            wkSlipPrtSetWork.SlipBaseColorBlu2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU2RF"));
            wkSlipPrtSetWork.SlipBaseColorRed3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED3RF"));
            wkSlipPrtSetWork.SlipBaseColorGrn3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN3RF"));
            wkSlipPrtSetWork.SlipBaseColorBlu3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU3RF"));
            wkSlipPrtSetWork.SlipBaseColorRed4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED4RF"));
            wkSlipPrtSetWork.SlipBaseColorGrn4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN4RF"));
            wkSlipPrtSetWork.SlipBaseColorBlu4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU4RF"));
            wkSlipPrtSetWork.SlipBaseColorRed5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORRED5RF"));
            wkSlipPrtSetWork.SlipBaseColorGrn5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORGRN5RF"));
            wkSlipPrtSetWork.SlipBaseColorBlu5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPBASECOLORBLU5RF"));
            //wkSlipPrtSetWork.CustTelNoPrtDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTTELNOPRTDIVCDRF")); // 2008.05.28 del
            wkSlipPrtSetWork.CopyCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COPYCOUNTRF"));
            wkSlipPrtSetWork.TitleName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME1RF"));
            wkSlipPrtSetWork.TitleName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME2RF"));
            wkSlipPrtSetWork.TitleName3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME3RF"));
            wkSlipPrtSetWork.TitleName4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME4RF"));
            wkSlipPrtSetWork.SpecialPurpose1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE1RF"));
            wkSlipPrtSetWork.SpecialPurpose2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE2RF"));
            wkSlipPrtSetWork.SpecialPurpose3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE3RF"));
            wkSlipPrtSetWork.SpecialPurpose4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SPECIALPURPOSE4RF"));
            //wkSlipPrtSetWork.BarCodeAcpOdrNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BARCODEACPODRNOPRTCDRF")); // 2008.05.28 del
            //wkSlipPrtSetWork.BarCodeCustCodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BARCODECUSTCODEPRTCDRF")); // 2008.05.28 del
            wkSlipPrtSetWork.TitleName102 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME102RF"));
            wkSlipPrtSetWork.TitleName103 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME103RF"));
            wkSlipPrtSetWork.TitleName104 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME104RF"));
            wkSlipPrtSetWork.TitleName105 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME105RF"));
            wkSlipPrtSetWork.TitleName202 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME202RF"));
            wkSlipPrtSetWork.TitleName203 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME203RF"));
            wkSlipPrtSetWork.TitleName204 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME204RF"));
            wkSlipPrtSetWork.TitleName205 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME205RF"));
            wkSlipPrtSetWork.TitleName302 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME302RF"));
            wkSlipPrtSetWork.TitleName303 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME303RF"));
            wkSlipPrtSetWork.TitleName304 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME304RF"));
            wkSlipPrtSetWork.TitleName305 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME305RF"));
            wkSlipPrtSetWork.TitleName402 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME402RF"));
            wkSlipPrtSetWork.TitleName403 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME403RF"));
            wkSlipPrtSetWork.TitleName404 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME404RF"));
            wkSlipPrtSetWork.TitleName405 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TITLENAME405RF"));
            // 2008.05.28 add start ---------------------------------------------------------------->>
            wkSlipPrtSetWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
            wkSlipPrtSetWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
            wkSlipPrtSetWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
            wkSlipPrtSetWork.QRCodePrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRINTDIVCDRF"));
            wkSlipPrtSetWork.TimePrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TIMEPRINTDIVCDRF"));
            wkSlipPrtSetWork.ReissueMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REISSUEMARKRF"));
            wkSlipPrtSetWork.RefConsTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("REFCONSTAXDIVCDRF"));
            wkSlipPrtSetWork.RefConsTaxPrtNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("REFCONSTAXPRTNMRF"));
            wkSlipPrtSetWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
            // 2008.05.28 add end ------------------------------------------------------------------<<
            #endregion

            return wkSlipPrtSetWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 山田 明友</br>
        /// <br>Date       : 2008.02.08</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            ClientSqlConnectionInfo clientSqlConnectionInfo = new ClientSqlConnectionInfo();
            string connectionText = clientSqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Local_UserDB);
            if (connectionText == null || connectionText == "") return null;
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion

        #region [エラーログ出力処理]
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                if (ex is SqlException)
                {
                    this.WriteSQLErrorLog((SqlException)ex, errorText, status);
                }
                else
                {
                    message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                    new ClientLogTextOut().Output(ex.Source, message, status, ex);
                }
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }

        private int WriteSQLErrorLog(SqlException ex, string errorText, int status)
        {
            string message = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                object obj2 = message;
                message = string.Concat(new object[] { obj2, "Index #", i, "\nMessage: ", ex.Errors[i].Message, "\nLineNumber: ", ex.Errors[i].LineNumber, "\nSource: ", ex.Errors[i].Source, "\nProcedure: ", ex.Errors[i].Procedure, "\n" });
            }
            if (!errorText.Trim().Equals(""))
            {
                message = message + errorText + "\n";
            }
            message = message + "Status = " + status.ToString() + "\n";
            new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, message, status);
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
            {
                return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
            }
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        #endregion

    }
}

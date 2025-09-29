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
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 締日算出モジュールDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 締日算出モジュールの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2008.07.28</br>
    /// <br></br>
    /// <br>Update Note: 2009.03.26  22018 鈴木 正臣</br>
    /// <br>           : 履歴・支払、金額・買掛で開始日～終了日の判定が不正だった為、修正。</br>
    /// <br>           : (例えばシステム日付の6か月前の日付でレコードがあると,先に当たってしまう。)</br>
    /// <br></br>
    /// <br>Update Note: 2009.05.14  22018 鈴木 正臣</br>
    /// <br>           : 締次更新開始年月日を追加。</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public partial class TtlDayCalcDB : RemoteDB, ITtlDayCalcDB
    {
        /// <summary>
        /// 締日算出モジュールDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2008.07.28</br>
        /// </remarks>
        public TtlDayCalcDB()
            :
        base( "PMCMN00106D", "Broadleaf.Application.Remoting.ParamData.TtlDayCalcRetWork", "MONTHLYADDUPHISRF" ) //基底クラスのコンストラクタ
        {
        }

        # region [履歴月次]
        #region 取得処理・履歴月次
        /// <summary>
        /// 取得処理・履歴月次
        /// </summary>
        /// <param name="retWorkList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 月次締更新履歴マスタからデータ取得します</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public int SearchHisMonthly( out object retWorkList, object paraWork )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retWorkList = null;

            TtlDayCalcParaWork para = (paraWork as TtlDayCalcParaWork);

            try
            {
                status = SearchHisMonthlyProc( out retWorkList, para );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisMonthly Exception=" + ex.Message );
                retWorkList = new CustomSerializeArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        /// <summary>
        /// 取得処理メイン・履歴月次
        /// </summary>
        /// <param name="retWorkList"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchHisMonthlyProc( out object retWorkList, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            retWorkList = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();  //抽出結果(全て)
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( connectionText == null || connectionText == "" ) return status;

                //SQL文生成
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                status = SearchHisMonthlyProcAct( ref list, ref sqlConnection, para );
                retList.Add( list );

                //マスタ取得
                status = SearchStProc( out list, para, ref sqlConnection );
                retList.Add( list );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisMonthlyProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    //@//暗号化キークローズ
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retWorkList = retList;

            return status;
        }
        #endregion

        #region 取得処理（実行部）・履歴月次
        /// <summary>
        /// 取得処理（実行部）・履歴月次
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchHisMonthlyProcAct( ref CustomSerializeArrayList list, ref SqlConnection sqlConnection, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand( selectTxt, sqlConnection );

                #region Select文作成
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  RES.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  RES.ACCRECACCPAYDIVRF," + Environment.NewLine;
                selectTxt += "  RES.ADDUPSECCODERF," + Environment.NewLine;
                selectTxt += "  RES.MAXMONTHLYADDUPDATERF," + Environment.NewLine;
                selectTxt += "  HIS.CONVERTPROCESSDIVCDRF " + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [RES]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  ACCRECACCPAYDIVRF," + Environment.NewLine;
                selectTxt += "  ADDUPSECCODERF," + Environment.NewLine;
                selectTxt += "  MAX(MONTHLYADDUPDATERF) AS MAXMONTHLYADDUPDATERF " + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  MONTHLYADDUPHISRF" + Environment.NewLine;

                //WHERE文の作成
                selectTxt += MakeWhereStringForHisMonthly( ref sqlCommand, para );

                //GROUPBY句の作成
                selectTxt += "GROUP BY " + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  ACCRECACCPAYDIVRF," + Environment.NewLine; ;
                selectTxt += "  ADDUPSECCODERF" + Environment.NewLine; ;
                # endregion

                selectTxt += ") AS RES" + Environment.NewLine;

                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "  MONTHLYADDUPHISRF AS HIS" + Environment.NewLine;

                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  RES.ENTERPRISECODERF = HIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND RES.ACCRECACCPAYDIVRF = HIS.ACCRECACCPAYDIVRF" + Environment.NewLine;
                selectTxt += "  AND RES.ADDUPSECCODERF = HIS.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  AND RES.MAXMONTHLYADDUPDATERF = HIS.MONTHLYADDUPDATERF" + Environment.NewLine;
                #endregion

                sqlCommand.CommandText = selectTxt;
                myReader = sqlCommand.ExecuteReader();

                while ( myReader.Read() )
                {
                    #region 抽出結果-値セット
                    TtlDayCalcRetWork retWork = new TtlDayCalcRetWork();

                    retWork.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );
                    retWork.ProcDiv = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCRECACCPAYDIVRF" ) );
                    retWork.SectionCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDUPSECCODERF" ) );
                    retWork.CustomerCode = 0;
                    retWork.SupplierCd = 0;
                    retWork.TotalDay = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAXMONTHLYADDUPDATERF" ) );
                    retWork.ConvertProcessDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONVERTPROCESSDIVCDRF" ) );
                    #endregion

                    list.Add( retWork );

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisMonthlyProcAct Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlCommand != null ) sqlCommand.Dispose();
                if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        #endregion

        # region WHERE文生成・履歴月次
        /// <summary>
        /// WHERE文作成・履歴月次
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private string MakeWhereStringForHisMonthly( ref SqlCommand sqlCommand, TtlDayCalcParaWork para )
        {
            StringBuilder retstring = new StringBuilder();

            #region WHERE文作成
            retstring.Append( "WHERE" + Environment.NewLine );

            //企業コード
            retstring.Append( "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );

            // 売掛買掛区分
            if ( para.ProcDiv >= 0 )
            {
                retstring.Append( "  AND ACCRECACCPAYDIVRF=@FINDACCRECACCPAYDIV " + Environment.NewLine );
                SqlParameter findParaAccRecAccPayDiv = sqlCommand.Parameters.Add( "@FINDACCRECACCPAYDIV", SqlDbType.Int );
                findParaAccRecAccPayDiv.Value = SqlDataMediator.SqlSetInt32( para.ProcDiv );
            }

            // 拠点コード
            if ( !String.IsNullOrEmpty( para.SectionCode ) )
            {
                //retstring.Append( "  AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine );
                retstring.Append( "  AND (ADDUPSECCODERF=@FINDADDUPSECCODE OR ADDUPSECCODERF='') " + Environment.NewLine );
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
            }

            // 論理削除コード＝0のみを対象とする
            retstring.Append( "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine );
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
            findParaLogicalDeleteCode.Value = 0;

            // 開始締処理日(>=)
            if ( para.St_Date > 0 )
            {
                retstring.Append( "  AND MONTHLYADDUPDATERF>=@FINDMONTHLYADDUPDATEST " + Environment.NewLine );
                SqlParameter findParaMonthlyAddUpDateST = sqlCommand.Parameters.Add( "@FINDMONTHLYADDUPDATEST", SqlDbType.Int );
                findParaMonthlyAddUpDateST.Value = SqlDataMediator.SqlSetInt32( para.St_Date );
            }

            // 終了締処理日(<=)
            if ( para.Ed_Date > 0 )
            {
                retstring.Append( "  AND MONTHLYADDUPDATERF>=@FINDMONTHLYADDUPDATEED " + Environment.NewLine );
                SqlParameter findParaMonthlyAddUpDateED = sqlCommand.Parameters.Add( "@FINDMONTHLYADDUPDATEED", SqlDbType.Int );
                findParaMonthlyAddUpDateED.Value = SqlDataMediator.SqlSetInt32( para.Ed_Date );
            }

            // その他・区分系の項目は固定
            retstring.Append( "  AND PROCDIVCDRF=@FINDPROCDIVCD " + Environment.NewLine );
            retstring.Append( "  AND ERRORSTATUSRF=@FINDERRORSTATUS  " + Environment.NewLine );
            retstring.Append( "  AND HISTCTLCDRF=@FINDHISTCTLCD  " + Environment.NewLine );
            SqlParameter findParaProcDivCd = sqlCommand.Parameters.Add( "@FINDPROCDIVCD", SqlDbType.Int );
            SqlParameter findParaErrorStatus = sqlCommand.Parameters.Add( "@FINDERRORSTATUS", SqlDbType.Int );
            SqlParameter findParaHistCtlCd = sqlCommand.Parameters.Add( "@FINDHISTCTLCD", SqlDbType.Int );
            findParaProcDivCd.Value = 0;
            findParaErrorStatus.Value = 0;
            findParaHistCtlCd.Value = 0;

            #endregion

            return retstring.ToString();
        }
        # endregion
        # endregion

        # region [履歴請求]
        #region 取得処理・履歴請求
        /// <summary>
        /// 取得処理・履歴請求
        /// </summary>
        /// <param name="retWorkList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 請求締更新履歴マスタからデータ取得します</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public int SearchHisDmdC( out object retWorkList, object paraWork )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retWorkList = null;

            TtlDayCalcParaWork para = (paraWork as TtlDayCalcParaWork);

            try
            {
                status = SearchHisDmdCProc( out retWorkList, para );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisDmdC Exception=" + ex.Message );
                retWorkList = new CustomSerializeArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        /// <summary>
        /// 取得処理メイン・履歴請求
        /// </summary>
        /// <param name="retWorkList"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchHisDmdCProc( out object retWorkList, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            retWorkList = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();  //抽出結果(全て)
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( connectionText == null || connectionText == "" ) return status;

                //SQL文生成
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                status = SearchHisDmdCProcAct( ref list, ref sqlConnection, para );
                retList.Add( list );

                //マスタ取得
                status = SearchStProc( out list, para, ref sqlConnection );
                retList.Add( list );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisDmdCProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    //@//暗号化キークローズ
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retWorkList = retList;

            return status;
        }
        #endregion

        #region 取得処理（実行部）・履歴請求
        /// <summary>
        /// 取得処理（実行部）・履歴請求
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchHisDmdCProcAct( ref CustomSerializeArrayList list, ref SqlConnection sqlConnection, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand( selectTxt, sqlConnection );

                #region Select文作成
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  RES.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  RES.ADDUPSECCODERF," + Environment.NewLine;
                selectTxt += "  RES.MAXCADDUPUPDDATERF, " + Environment.NewLine;
                selectTxt += "  HIS.CONVERTPROCESSDIVCDRF, " + Environment.NewLine;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                selectTxt += "  HIS.STARTCADDUPUPDDATERF " + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [RES]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  ADDUPSECCODERF," + Environment.NewLine;
                selectTxt += "  MAX(CADDUPUPDDATERF) AS MAXCADDUPUPDDATERF " + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  DMDCADDUPHISRF" + Environment.NewLine;

                //WHERE文の作成
                selectTxt += MakeWhereStringForHisDmdC( ref sqlCommand, para );

                //GROUPBY句の作成
                selectTxt += "GROUP BY " + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  ADDUPSECCODERF" + Environment.NewLine;
                # endregion

                selectTxt += ") AS RES" + Environment.NewLine;

                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "  DMDCADDUPHISRF AS HIS" + Environment.NewLine;

                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  RES.ENTERPRISECODERF = HIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND RES.ADDUPSECCODERF = HIS.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  AND RES.MAXCADDUPUPDDATERF = HIS.CADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += "  AND HIS.CUSTOMERCODERF = '0'" + Environment.NewLine;    // 0:一括
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                selectTxt += "  AND HIS.PROCDIVCDRF='0'" + Environment.NewLine;
                selectTxt += "  AND HIS.ERRORSTATUSRF='0'" + Environment.NewLine;
                selectTxt += "  AND HIS.HISTCTLCDRF='0'" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                #endregion

                sqlCommand.CommandText = selectTxt;
                myReader = sqlCommand.ExecuteReader();

                while ( myReader.Read() )
                {
                    #region 抽出結果-値セット
                    TtlDayCalcRetWork retWork = new TtlDayCalcRetWork();

                    retWork.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );
                    retWork.ProcDiv = 0;    // 0:請求売掛
                    retWork.SectionCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDUPSECCODERF" ) );
                    retWork.CustomerCode = 0;
                    retWork.SupplierCd = 0;
                    retWork.TotalDay = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAXCADDUPUPDDATERF" ) );
                    retWork.ConvertProcessDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONVERTPROCESSDIVCDRF" ) );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                    retWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "STARTCADDUPUPDDATERF" ) );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                    #endregion

                    list.Add( retWork );

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisDmdCProcAct Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlCommand != null ) sqlCommand.Dispose();
                if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        #endregion

        # region WHERE文生成・履歴請求
        /// <summary>
        /// WHERE文作成・履歴請求
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private string MakeWhereStringForHisDmdC( ref SqlCommand sqlCommand, TtlDayCalcParaWork para )
        {
            StringBuilder retstring = new StringBuilder();

            #region WHERE文作成
            retstring.Append( "WHERE" + Environment.NewLine );

            //企業コード
            retstring.Append( "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );

            // 拠点コード
            if ( !String.IsNullOrEmpty( para.SectionCode ) )
            {
                //retstring.Append( "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine );
                retstring.Append( "  AND (ADDUPSECCODERF=@FINDADDUPSECCODE OR ADDUPSECCODERF='') " + Environment.NewLine );
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
            }

            // 得意先コード＝「0:一括」のみを対象とする
            retstring.Append( "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine );
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
            findParaCustomerCode.Value = 0;

            // 論理削除コード＝0のみを対象とする
            retstring.Append( "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine );
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
            findParaLogicalDeleteCode.Value = 0;

            // 開始締処理日(>=)
            if ( para.St_Date > 0 )
            {
                retstring.Append( "  AND CADDUPUPDDATERF>=@FINDCADDUPUPDDATEST" + Environment.NewLine );
                SqlParameter findParaCAddUpUpdDateST = sqlCommand.Parameters.Add( "@FINDCADDUPUPDDATEST", SqlDbType.Int );
                findParaCAddUpUpdDateST.Value = SqlDataMediator.SqlSetInt32( para.St_Date );
            }

            // 終了締処理日(<=)
            if ( para.Ed_Date > 0 )
            {
                retstring.Append( "  AND CADDUPUPDDATERF<=@FINDCADDUPUPDDATEED" + Environment.NewLine );
                SqlParameter findParaCAddUpUpdDateED = sqlCommand.Parameters.Add( "@FINDCADDUPUPDDATEED", SqlDbType.Int );
                findParaCAddUpUpdDateED.Value = SqlDataMediator.SqlSetInt32( para.Ed_Date );
            }

            // その他・区分系の項目は固定
            retstring.Append( "  AND PROCDIVCDRF=@FINDPROCDIVCD" + Environment.NewLine );
            retstring.Append( "  AND ERRORSTATUSRF=@FINDERRORSTATUS" + Environment.NewLine );
            retstring.Append( "  AND HISTCTLCDRF=@FINDHISTCTLCD" + Environment.NewLine );
            SqlParameter findParaProcDivCd = sqlCommand.Parameters.Add( "@FINDPROCDIVCD", SqlDbType.Int );
            SqlParameter findParaErrorStatus = sqlCommand.Parameters.Add( "@FINDERRORSTATUS", SqlDbType.Int );
            SqlParameter findParaHistCtlCd = sqlCommand.Parameters.Add( "@FINDHISTCTLCD", SqlDbType.Int );
            findParaProcDivCd.Value = 0;
            findParaErrorStatus.Value = 0;
            findParaHistCtlCd.Value = 0;

            #endregion

            return retstring.ToString();
        }
        # endregion
        # endregion

        # region [履歴支払]
        #region 取得処理・履歴支払
        /// <summary>
        /// 取得処理・履歴支払
        /// </summary>
        /// <param name="retWorkList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 支払締更新履歴マスタからデータ取得します</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public int SearchHisPayment( out object retWorkList, object paraWork )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retWorkList = null;

            TtlDayCalcParaWork para = (paraWork as TtlDayCalcParaWork);

            try
            {
                status = SearchHisPaymentProc( out retWorkList, para );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisPayment Exception=" + ex.Message );
                retWorkList = new CustomSerializeArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        /// <summary>
        /// 取得処理メイン・履歴支払
        /// </summary>
        /// <param name="retWorkList"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchHisPaymentProc( out object retWorkList, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            retWorkList = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();  //抽出結果(全て)
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( connectionText == null || connectionText == "" ) return status;

                //SQL文生成
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                status = SearchHisPaymentProcAct( ref list, ref sqlConnection, para );
                retList.Add( list );

                //マスタ取得
                status = SearchStProc( out list, para, ref sqlConnection );
                retList.Add( list );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisPaymentProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    //@//暗号化キークローズ
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retWorkList = retList;

            return status;
        }
        #endregion

        #region 取得処理（実行部）・履歴支払
        /// <summary>
        /// 取得処理（実行部）・履歴支払
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchHisPaymentProcAct( ref CustomSerializeArrayList list, ref SqlConnection sqlConnection, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand( selectTxt, sqlConnection );

                #region Select文作成
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  RES.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  RES.ADDUPSECCODERF," + Environment.NewLine;
                selectTxt += "  RES.MAXCADDUPUPDDATERF," + Environment.NewLine;
                selectTxt += "  HIS.CONVERTPROCESSDIVCDRF, " + Environment.NewLine;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/00/00 ADD
                selectTxt += "  HIS.STARTCADDUPUPDDATERF " + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/00/00 ADD
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [RES]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  ADDUPSECCODERF," + Environment.NewLine;
                selectTxt += "  MAX(CADDUPUPDDATERF) AS MAXCADDUPUPDDATERF " + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  PAYMENTADDUPHISRF" + Environment.NewLine;

                //WHERE文の作成
                selectTxt += MakeWhereStringForHisPayment( ref sqlCommand, para );

                //GROUPBY句の作成
                selectTxt += "GROUP BY " + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  ADDUPSECCODERF" + Environment.NewLine; ;
                # endregion

                selectTxt += ") AS RES" + Environment.NewLine;

                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "  PAYMENTADDUPHISRF AS HIS" + Environment.NewLine;

                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  RES.ENTERPRISECODERF = HIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND RES.ADDUPSECCODERF = HIS.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  AND RES.MAXCADDUPUPDDATERF = HIS.CADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += "  AND HIS.SUPPLIERCDRF = '0'" + Environment.NewLine;  // 0:一括
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                selectTxt += "  AND HIS.PROCDIVCDRF='0'" + Environment.NewLine;
                selectTxt += "  AND HIS.ERRORSTATUSRF='0'" + Environment.NewLine;
                selectTxt += "  AND HIS.HISTCTLCDRF='0'" + Environment.NewLine;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                #endregion

                sqlCommand.CommandText = selectTxt;
                myReader = sqlCommand.ExecuteReader();

                while ( myReader.Read() )
                {
                    #region 抽出結果-値セット
                    TtlDayCalcRetWork retWork = new TtlDayCalcRetWork();

                    retWork.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );
                    retWork.ProcDiv = 1;    // 1:支払買掛
                    retWork.SectionCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDUPSECCODERF" ) );
                    retWork.CustomerCode = 0;
                    retWork.SupplierCd = 0;
                    retWork.TotalDay = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAXCADDUPUPDDATERF" ) );
                    retWork.ConvertProcessDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONVERTPROCESSDIVCDRF" ) );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
                    retWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD( myReader, myReader.GetOrdinal( "STARTCADDUPUPDDATERF" ) );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
                    #endregion

                    list.Add( retWork );

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisPaymentProcAct Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlCommand != null ) sqlCommand.Dispose();
                if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        #endregion

        # region WHERE文生成・履歴支払
        /// <summary>
        /// WHERE文作成・履歴支払
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private string MakeWhereStringForHisPayment( ref SqlCommand sqlCommand, TtlDayCalcParaWork para )
        {
            StringBuilder retstring = new StringBuilder();

            #region WHERE文作成
            retstring.Append( "WHERE" + Environment.NewLine );

            //企業コード
            retstring.Append( "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );

            // 拠点コード
            if ( !String.IsNullOrEmpty( para.SectionCode ) )
            {
                //retstring.Append( "  AND ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine );
                retstring.Append( "  AND (ADDUPSECCODERF=@FINDADDUPSECCODE OR ADDUPSECCODERF='') " + Environment.NewLine );
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
            }

            // 仕入先コード＝「0:一括」のみを対象とする
            retstring.Append( "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine );
            SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
            findParaSupplierCd.Value = 0;

            // 論理削除コード＝0のみを対象とする
            retstring.Append( "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine );
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
            findParaLogicalDeleteCode.Value = 0;

            // 開始締処理日(>=)
            if ( para.St_Date > 0 )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 DEL
                //retstring.Append( "  AND CADDUPUPDDATERF=@FINDCADDUPUPDDATEST" + Environment.NewLine );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                retstring.Append( "  AND CADDUPUPDDATERF>=@FINDCADDUPUPDDATEST" + Environment.NewLine );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                SqlParameter findParaCAddUpUpdDateST = sqlCommand.Parameters.Add( "@FINDCADDUPUPDDATEST", SqlDbType.Int );
                findParaCAddUpUpdDateST.Value = SqlDataMediator.SqlSetInt32( para.St_Date );
            }

            // 終了締処理日(<=)
            if ( para.Ed_Date > 0 )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 DEL
                //retstring.Append( "  AND CADDUPUPDDATERF=@FINDCADDUPUPDDATEED" + Environment.NewLine );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                retstring.Append( "  AND CADDUPUPDDATERF<=@FINDCADDUPUPDDATEED" + Environment.NewLine );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                SqlParameter findParaCAddUpUpdDateED = sqlCommand.Parameters.Add( "@FINDCADDUPUPDDATEED", SqlDbType.Int );
                findParaCAddUpUpdDateED.Value = SqlDataMediator.SqlSetInt32( para.Ed_Date );
            }

            // その他・区分系の項目は固定
            retstring.Append( "  AND PROCDIVCDRF=@FINDPROCDIVCD" + Environment.NewLine );
            retstring.Append( "  AND ERRORSTATUSRF=@FINDERRORSTATUS" + Environment.NewLine );
            retstring.Append( "  AND HISTCTLCDRF=@FINDHISTCTLCD" + Environment.NewLine );
            SqlParameter findParaProcDivCd = sqlCommand.Parameters.Add( "@FINDPROCDIVCD", SqlDbType.Int );
            SqlParameter findParaErrorStatus = sqlCommand.Parameters.Add( "@FINDERRORSTATUS", SqlDbType.Int );
            SqlParameter findParaHistCtlCd = sqlCommand.Parameters.Add( "@FINDHISTCTLCD", SqlDbType.Int );
            findParaProcDivCd.Value = 0;
            findParaErrorStatus.Value = 0;
            findParaHistCtlCd.Value = 0;

            #endregion

            return retstring.ToString();
        }
        # endregion
        # endregion

        # region [金額月次売掛]
        #region 取得処理・金額月次売掛
        /// <summary>
        /// 取得処理・金額月次売掛
        /// </summary>
        /// <param name="retWorkList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先売掛金額マスタからデータ取得します</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public int SearchPrcMonthlyAccRec( out object retWorkList, object paraWork )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retWorkList = null;

            TtlDayCalcParaWork para = (paraWork as TtlDayCalcParaWork);

            try
            {
                status = SearchPrcMonthlyAccRecProc( out retWorkList, para );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcMonthlyAccRec Exception=" + ex.Message );
                retWorkList = new CustomSerializeArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        /// <summary>
        /// 取得処理メイン・金額月次売掛
        /// </summary>
        /// <param name="retWorkList"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchPrcMonthlyAccRecProc( out object retWorkList, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            retWorkList = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();  //抽出結果(全て)
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( connectionText == null || connectionText == "" ) return status;

                //SQL文生成
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                status = SearchPrcMonthlyAccRecProcAct( ref list, ref sqlConnection, para );
                retList.Add( list );

                //マスタ取得
                status = SearchStProc( out list, para, ref sqlConnection );
                retList.Add( list );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcMonthlyAccRecProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    //@//暗号化キークローズ
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retWorkList = retList;

            return status;
        }
        #endregion

        #region 取得処理（実行部）・金額月次売掛
        /// <summary>
        /// 取得処理（実行部）・金額月次売掛
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchPrcMonthlyAccRecProcAct( ref CustomSerializeArrayList list, ref SqlConnection sqlConnection, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand( selectTxt, sqlConnection );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 DEL
                # region // DEL
                //# region [SELECT]
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  ACCREC1.*," + Environment.NewLine;
                //selectTxt += "  MAX(ACCREC2.ADDUPDATERF) AS CLAIMMAXADDUPDATERF" + Environment.NewLine;
                //selectTxt += "FROM" + Environment.NewLine;
                //selectTxt += "(" + Environment.NewLine;

                //# region [ACCREC1]
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  CLAIMCODERF," + Environment.NewLine;
                //selectTxt += "  CUSTOMERCODERF," + Environment.NewLine;
                //selectTxt += "  MAX(ADDUPDATERF) AS MAXADDUPDATERF" + Environment.NewLine;
                //selectTxt += "FROM" + Environment.NewLine;
                //selectTxt += "  CUSTACCRECRF" + Environment.NewLine;

                ////WHERE文の作成
                //selectTxt += MakeWhereStringForPrcMonthlyAccRec( ref sqlCommand, para );

                ////GROUPBY句の作成
                //selectTxt += "GROUP BY " + Environment.NewLine;
                //selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  CLAIMCODERF," + Environment.NewLine;
                //selectTxt += "  CUSTOMERCODERF" + Environment.NewLine;
                //# endregion

                //selectTxt += ") AS ACCREC1" + Environment.NewLine;

                //// LEFT JOIN
                //selectTxt += "LEFT JOIN" + Environment.NewLine;
                //selectTxt += "  CUSTACCRECRF AS ACCREC2" + Environment.NewLine;
                //selectTxt += "ON" + Environment.NewLine;
                //selectTxt += "  ACCREC1.ENTERPRISECODERF=ACCREC2.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "  AND ACCREC1.CLAIMCODERF=ACCREC2.CLAIMCODERF" + Environment.NewLine;
                //selectTxt += "  AND ACCREC2.CUSTOMERCODERF='0'" + Environment.NewLine;
                //selectTxt += "  AND ACCREC2.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                //if ( para.St_Date > 0 )
                //{
                //    selectTxt += "  AND ACCREC2.ADDUPDATERF>=@FINDADDUPDATEST" + Environment.NewLine;
                //}
                //if ( para.Ed_Date > 0 )
                //{
                //    selectTxt += "  AND ACCREC2.ADDUPDATERF<=@FINDADDUPDATEED" + Environment.NewLine;
                //}

                //// GROUP BY
                //selectTxt += "GROUP BY" + Environment.NewLine;
                //selectTxt += "  ACCREC1.ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  ACCREC1.CLAIMCODERF," + Environment.NewLine;
                //selectTxt += "  ACCREC1.CUSTOMERCODERF," + Environment.NewLine;
                //selectTxt += "  ACCREC1.MAXADDUPDATERF" + Environment.NewLine;
                
                //# endregion
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 ADD
                # region [SELECT]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  CUST.CLAIMSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  CUST.CLAIMCODERF," + Environment.NewLine;
                selectTxt += "  CUST.CUSTOMERCODERF," + Environment.NewLine;
                selectTxt += "  ACCREC1.MAXADDUPDATERF," + Environment.NewLine;
                selectTxt += "  MAX(ACCREC2.ADDUPDATERF) AS CLAIMMAXADDUPDATERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [CUST]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CLAIMSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  CUSTOMERCODERF," + Environment.NewLine;
                selectTxt += "  CLAIMCODERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  CUSTOMERRF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                if ( para.CustomerCode != 0 )
                {
                    selectTxt += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                }
                # endregion

                selectTxt += ") AS CUST" + Environment.NewLine;
                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [ACCREC1]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  CUSTOMERCODERF," + Environment.NewLine;
                selectTxt += "  MAX(ADDUPDATERF) AS MAXADDUPDATERF" + Environment.NewLine;
                selectTxt += "FROM " + Environment.NewLine;
                selectTxt += "  CUSTACCRECRF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                //if ( !string.IsNullOrEmpty( para.SectionCode ) )
                //{
                //    selectTxt += "  AND RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                //}
                if ( para.CustomerCode != 0 )
                {
                    selectTxt += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                }
                else
                {
                    selectTxt += "  AND CUSTOMERCODERF<>'0'" + Environment.NewLine;
                }
                selectTxt += "GROUP BY" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  CUSTOMERCODERF" + Environment.NewLine;
                # endregion

                selectTxt += ") AS ACCREC1" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  CUST.ENTERPRISECODERF=ACCREC1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND CUST.CUSTOMERCODERF=ACCREC1.CUSTOMERCODERF" + Environment.NewLine;

                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "CUSTACCRECRF AS ACCREC2" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  CUST.ENTERPRISECODERF=ACCREC2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND CUST.CLAIMCODERF=ACCREC2.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  AND ACCREC2.CUSTOMERCODERF='0'" + Environment.NewLine;
                selectTxt += "  AND ACCREC2.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                selectTxt += "GROUP BY" + Environment.NewLine;
                selectTxt += "  CUST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  CUST.CLAIMSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  CUST.CLAIMCODERF," + Environment.NewLine;
                selectTxt += "  CUST.CUSTOMERCODERF," + Environment.NewLine;
                selectTxt += "  ACCREC1.MAXADDUPDATERF" + Environment.NewLine;
                # endregion

                # region [PARAMS]
                // 企業コード
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );
                // 得意先コード
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32( para.CustomerCode );
                //// 実績拠点コード
                //SqlParameter findParaResultSectCd = sqlCommand.Parameters.Add( "@FINDRESULTSSECTCD", SqlDbType.NChar );
                //findParaResultSectCd.Value = SqlDataMediator.SqlSetString( para.SectionCode );
                // 論理削除コード
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
                findParaLogicalDeleteCode.Value = 0;
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 ADD

                sqlCommand.CommandText = selectTxt;
                myReader = sqlCommand.ExecuteReader();

                Dictionary<int, TtlDayCalcRetWork> retWorkDic = new Dictionary<int, TtlDayCalcRetWork>();

                while ( myReader.Read() )
                {
                    #region 抽出結果-値セット
                    TtlDayCalcRetWork retWork = new TtlDayCalcRetWork();

                    retWork.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );
                    retWork.ProcDiv = 0;    // 0:請求売掛
                    retWork.SectionCode = string.Empty;
                    retWork.CustomerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
                    if ( retWork.CustomerCode == 0 )
                    {
                        retWork.CustomerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
                    }
                    retWork.SupplierCd = 0;
                    retWork.TotalDay = Math.Max( SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAXADDUPDATERF" ) ),
                                                 SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMMAXADDUPDATERF" ) ) );
                    if ( retWork.TotalDay == 0 ) continue;
                    #endregion

                    if ( retWorkDic.ContainsKey( retWork.CustomerCode ) )
                    {
                        if ( retWorkDic[retWork.CustomerCode].TotalDay < retWork.TotalDay )
                        {
                            retWorkDic[retWork.CustomerCode] = retWork;
                        }
                    }
                    else
                    {
                        retWorkDic.Add( retWork.CustomerCode, retWork );
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                foreach ( TtlDayCalcRetWork retWork in retWorkDic.Values )
                {
                    list.Add( retWork );
                }

            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcMonthlyAccRecProcAct Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlCommand != null ) sqlCommand.Dispose();
                if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        #endregion

        # region WHERE文生成・金額月次売掛
        ///// <summary>
        ///// WHERE文作成・金額月次売掛
        ///// </summary>
        ///// <param name="sqlCommand"></param>
        ///// <param name="para"></param>
        ///// <returns></returns>
        //private string MakeWhereStringForPrcMonthlyAccRec( ref SqlCommand sqlCommand, TtlDayCalcParaWork para )
        //{
        //    StringBuilder retstring = new StringBuilder();

        //    #region WHERE文作成
        //    retstring.Append( "WHERE" + Environment.NewLine );

        //    //企業コード
        //    retstring.Append( "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine );
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
        //    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );

        //    ////// 拠点コード
        //    ////if ( !String.IsNullOrEmpty( para.SectionCode ) )
        //    ////{
        //    ////    retstring.Append( "  AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine );
        //    ////    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
        //    ////    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
        //    ////}

        //    ////// 得意先コード
        //    ////if ( para.CustomerCode != 0 )
        //    ////{
        //    ////    // 指定されたコードのみ
        //    ////    retstring.Append( "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE " + Environment.NewLine );
        //    ////    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
        //    ////    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32( para.CustomerCode );
        //    ////}
        //    ////else
        //    ////{
        //    ////    // ゼロを除く
        //    ////    retstring.Append( "  AND CUSTOMERCODERF<>@FINDCUSTOMERCODE " + Environment.NewLine );
        //    ////    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
        //    ////    findParaCustomerCode.Value = 0;
        //    ////}

        //    // 得意先コード
        //    if ( para.CustomerCode != 0 )
        //    {
        //        retstring.Append( " AND ( " + Environment.NewLine );

        //        // 指定されたコードのみ
        //        retstring.Append( "  CUSTOMERCODERF=@FINDCUSTOMERCODE " + Environment.NewLine );
        //        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
        //        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32( para.CustomerCode );

        //        retstring.Append( " OR ( " + Environment.NewLine );

        //        // 請求先コード
        //        retstring.Append( " CLAIMCODERF=@FINDCLAIMCODE AND CUSTOMERCODERF='0' " + Environment.NewLine );
        //        SqlParameter findParaClaimCode = sqlCommand.Parameters.Add( "@FINDCLAIMCODE", SqlDbType.Int );
        //        findParaClaimCode.Value = SqlDataMediator.SqlSetInt32( para.CustomerCode );

        //        // 拠点コード
        //        if ( !String.IsNullOrEmpty( para.SectionCode ) )
        //        {
        //            retstring.Append( " AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine );
        //            SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
        //            findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
        //        }
        //        retstring.Append( " )) " + Environment.NewLine );
        //    }
        //    else
        //    {
        //        // ゼロを除く
        //        retstring.Append( " AND CUSTOMERCODERF<>@FINDCUSTOMERCODE " + Environment.NewLine );
        //        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
        //        findParaCustomerCode.Value = 0;
        //    }

        //    // 論理削除コード＝0のみを対象とする
        //    retstring.Append( "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine );
        //    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
        //    findParaLogicalDeleteCode.Value = 0;

        //    // 開始締処理日(>=)
        //    if ( para.St_Date > 0 )
        //    {
        //        retstring.Append( "  AND ADDUPDATERF>=@FINDADDUPDATEST" + Environment.NewLine );
        //        SqlParameter findParaAddUpDateST = sqlCommand.Parameters.Add( "@FINDADDUPDATEST", SqlDbType.Int );
        //        findParaAddUpDateST.Value = SqlDataMediator.SqlSetInt32( para.St_Date );
        //    }

        //    // 終了締処理日(<=)
        //    if ( para.Ed_Date > 0 )
        //    {
        //        retstring.Append( "  AND ADDUPDATERF<=@FINDADDUPDATEED" + Environment.NewLine );
        //        SqlParameter findParaAddUpDateED = sqlCommand.Parameters.Add( "@FINDADDUPDATEED", SqlDbType.Int );
        //        findParaAddUpDateED.Value = SqlDataMediator.SqlSetInt32( para.Ed_Date );
        //    }

        //    #endregion

        //    return retstring.ToString();
        //}
        # endregion
        # endregion

        # region [金額月次買掛]
        #region 取得処理・金額月次買掛
        /// <summary>
        /// 取得処理・金額月次買掛
        /// </summary>
        /// <param name="retWorkList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先買掛金額マスタからデータ取得します</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public int SearchPrcMonthlyAccPay( out object retWorkList, object paraWork )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retWorkList = null;

            TtlDayCalcParaWork para = (paraWork as TtlDayCalcParaWork);

            try
            {
                status = SearchPrcMonthlyAccPayProc( out retWorkList, para );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcMonthlyAccPay Exception=" + ex.Message );
                retWorkList = new CustomSerializeArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        /// <summary>
        /// 取得処理メイン・金額月次買掛
        /// </summary>
        /// <param name="retWorkList"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchPrcMonthlyAccPayProc( out object retWorkList, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            retWorkList = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();  //抽出結果(全て)
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( connectionText == null || connectionText == "" ) return status;

                //SQL文生成
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                status = SearchPrcMonthlyAccPayProcAct( ref list, ref sqlConnection, para );
                retList.Add( list );

                //マスタ取得
                status = SearchStProc( out list, para, ref sqlConnection );
                retList.Add( list );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcMonthlyAccPayProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    //@//暗号化キークローズ
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retWorkList = retList;

            return status;
        }
        #endregion

        #region 取得処理（実行部）・金額月次買掛
        /// <summary>
        /// 取得処理（実行部）・金額月次買掛
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchPrcMonthlyAccPayProcAct( ref CustomSerializeArrayList list, ref SqlConnection sqlConnection, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand( selectTxt, sqlConnection );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 DEL
                # region // DEL
                //# region [SELECT]
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  ACCPAY1.*," + Environment.NewLine;
                //selectTxt += "  MAX(ACCPAY2.ADDUPDATERF) AS PAYEEMAXADDUPDATERF" + Environment.NewLine;
                //selectTxt += "FROM" + Environment.NewLine;
                //selectTxt += "(" + Environment.NewLine;

                //# region [ACCPAY1]
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  PAYEECODERF," + Environment.NewLine;
                //selectTxt += "  SUPPLIERCDRF," + Environment.NewLine;
                //selectTxt += "  MAX(ADDUPDATERF) AS MAXADDUPDATERF" + Environment.NewLine;
                //selectTxt += "FROM" + Environment.NewLine;
                //selectTxt += "  SUPLACCPAYRF" + Environment.NewLine;

                ////WHERE文の作成
                //selectTxt += MakeWhereStringForPrcMonthlyAccPay( ref sqlCommand, para );

                ////GROUPBY句の作成
                //selectTxt += "GROUP BY " + Environment.NewLine;
                //selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  PAYEECODERF," + Environment.NewLine;
                //selectTxt += "  SUPPLIERCDRF" + Environment.NewLine; ;
                //# endregion

                //selectTxt += ") AS ACCPAY1" + Environment.NewLine;

                //// LEFT JOIN
                //selectTxt += "LEFT JOIN" + Environment.NewLine;
                //selectTxt += "  SUPLACCPAYRF AS ACCPAY2" + Environment.NewLine;
                //selectTxt += "ON" + Environment.NewLine;
                //selectTxt += "  ACCPAY1.ENTERPRISECODERF=ACCPAY2.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "  AND ACCPAY1.PAYEECODERF=ACCPAY2.PAYEECODERF" + Environment.NewLine;
                //selectTxt += "  AND ACCPAY2.SUPPLIERCDRF='0'" + Environment.NewLine;
                //selectTxt += "  AND ACCPAY2.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                //if ( para.St_Date > 0 )
                //{
                //    selectTxt += "  AND ACCPAY2.ADDUPDATERF=@FINDADDUPDATEST" + Environment.NewLine;
                //}
                //if ( para.Ed_Date > 0 )
                //{
                //    selectTxt += "  AND ACCPAY2.ADDUPDATERF=@FINDADDUPDATEED" + Environment.NewLine;
                //}

                //// GROUP BY
                //selectTxt += "GROUP BY" + Environment.NewLine;
                //selectTxt += "  ACCPAY1.ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  ACCPAY1.PAYEECODERF," + Environment.NewLine;
                //selectTxt += "  ACCPAY1.SUPPLIERCDRF," + Environment.NewLine;
                //selectTxt += "  ACCPAY1.MAXADDUPDATERF" + Environment.NewLine;
                //# endregion
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 ADD
                # region [SELECT]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  SUP.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  SUP.PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  SUP.PAYEECODERF," + Environment.NewLine;
                selectTxt += "  SUP.SUPPLIERCDRF," + Environment.NewLine;
                selectTxt += "  ACCPAY1.MAXADDUPDATERF," + Environment.NewLine;
                selectTxt += "  MAX(ACCPAY2.ADDUPDATERF) AS PAYEEMAXADDUPDATERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [SUP]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  PAYEECODERF," + Environment.NewLine;
                selectTxt += "  SUPPLIERCDRF  " + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  SUPPLIERRF " + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                if ( para.SupplierCd != 0 )
                {
                    selectTxt += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                }
                # endregion

                selectTxt += ") AS SUP " + Environment.NewLine;
                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [ACCPAY1]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  SUPPLIERCDRF," + Environment.NewLine;
                selectTxt += "  MAX(ADDUPDATERF) AS MAXADDUPDATERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  SUPLACCPAYRF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                if ( para.SupplierCd != 0 )
                {
                    selectTxt += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                }
                else
                {
                    selectTxt += "  AND SUPPLIERCDRF<>'0'" + Environment.NewLine;
                }
                selectTxt += "GROUP BY" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  SUPPLIERCDRF" + Environment.NewLine;
                # endregion

                selectTxt += ") AS ACCPAY1" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  SUP.ENTERPRISECODERF=ACCPAY1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SUP.SUPPLIERCDRF=ACCPAY1.SUPPLIERCDRF" + Environment.NewLine;

                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "SUPLACCPAYRF AS ACCPAY2" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  SUP.ENTERPRISECODERF=ACCPAY2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SUP.PAYEECODERF=ACCPAY2.PAYEECODERF" + Environment.NewLine;
                selectTxt += "  AND ACCPAY2.SUPPLIERCDRF='0'" + Environment.NewLine;
                

                selectTxt += "GROUP BY" + Environment.NewLine;
                selectTxt += "  SUP.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  SUP.PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  SUP.PAYEECODERF," + Environment.NewLine;
                selectTxt += "  SUP.SUPPLIERCDRF," + Environment.NewLine;
                selectTxt += "  ACCPAY1.MAXADDUPDATERF" + Environment.NewLine;
                # endregion
                
                # region [PARAMS]
                // 企業コード
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );
                //// 実績拠点コード
                //SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add( "@FINDRESULTSSECTCD", SqlDbType.NChar );
                //findParaResultsSectCd.Value = SqlDataMediator.SqlSetString( para.SectionCode );
                // 仕入先コード
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32( para.SupplierCd );
                // 論理削除コード
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
                findParaLogicalDeleteCode.Value = 0;
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 ADD

                sqlCommand.CommandText = selectTxt;
                myReader = sqlCommand.ExecuteReader();

                Dictionary<int, TtlDayCalcRetWork> retWorkDic = new Dictionary<int, TtlDayCalcRetWork>();

                while ( myReader.Read() )
                {
                    #region 抽出結果-値セット
                    TtlDayCalcRetWork retWork = new TtlDayCalcRetWork();

                    retWork.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );
                    retWork.ProcDiv = 1;    // 1:支払買掛
                    retWork.SectionCode = string.Empty;
                    retWork.CustomerCode = 0;
                    retWork.SupplierCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERCDRF" ) );
                    if ( retWork.SupplierCd == 0 )
                    {
                        retWork.SupplierCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PAYEECODERF" ) );
                    }
                    retWork.TotalDay = Math.Max( SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAXADDUPDATERF" ) ),
                                                 SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PAYEEMAXADDUPDATERF" ) ) );
                    if ( retWork.TotalDay == 0 ) continue;
                    #endregion

                    if ( retWorkDic.ContainsKey( retWork.SupplierCd ) )
                    {
                        if ( retWorkDic[retWork.SupplierCd].TotalDay < retWork.TotalDay )
                        {
                            retWorkDic[retWork.SupplierCd] = retWork;
                        }
                    }
                    else
                    {
                        retWorkDic.Add( retWork.SupplierCd, retWork );
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                foreach ( TtlDayCalcRetWork retWork in retWorkDic.Values )
                {
                    list.Add( retWork );    
                }
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcMonthlyAccPayProcAct Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlCommand != null ) sqlCommand.Dispose();
                if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        #endregion

        # region WHERE文生成・金額月次買掛
        /// <summary>
        /// WHERE文作成・金額月次買掛
        /// </summary>
        /// <param name="sqlCommand"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private string MakeWhereStringForPrcMonthlyAccPay( ref SqlCommand sqlCommand, TtlDayCalcParaWork para )
        {
            StringBuilder retstring = new StringBuilder();

            #region WHERE文作成
            retstring.Append( "WHERE" + Environment.NewLine );

            //企業コード
            retstring.Append( "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );


            ////// 拠点コード
            ////if ( !String.IsNullOrEmpty( para.SectionCode ) )
            ////{
            ////    retstring.Append( "  AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine );
            ////    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
            ////    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
            ////}

            ////// 仕入先コード
            ////if ( para.CustomerCode != 0 )
            ////{
            ////    // 指定されたコードのみ
            ////    retstring.Append( "  AND SUPPLIERCDRF=@FINDSUPPLIERCD " + Environment.NewLine );
            ////    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
            ////    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32( para.SupplierCd );
            ////}
            ////else
            ////{
            ////    // ゼロを除く
            ////    retstring.Append( "  AND SUPPLIERCDRF<>@FINDSUPPLIERCD " + Environment.NewLine );
            ////    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
            ////    findParaSupplierCd.Value = 0;
            ////}

            // 仕入先コード
            if ( para.SupplierCd != 0 )
            {
                retstring.Append( " AND ( " + Environment.NewLine );

                // 指定されたコードのみ
                retstring.Append( "  SUPPLIERCDRF=@FINDSUPPLIERCD " + Environment.NewLine );
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32( para.SupplierCd );

                retstring.Append( " OR ( " + Environment.NewLine );
                // 支払先コード
                retstring.Append( "  PAYEECODERF=@FINDPAYEECODE AND SUPPLIERCDRF='0' " + Environment.NewLine );
                SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add( "@FINDPAYEECODE", SqlDbType.Int );
                findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32( para.SupplierCd );

                // 拠点コード
                if ( !String.IsNullOrEmpty( para.SectionCode ) )
                {
                    retstring.Append( "  AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine );
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
                }
                retstring.Append( " )) " + Environment.NewLine );
            }
            else
            {
                // ゼロを除く
                retstring.Append( "  AND SUPPLIERCDRF<>@FINDSUPPLIERCD " + Environment.NewLine );
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
                findParaSupplierCd.Value = 0;
            }

            // 論理削除コード＝0のみを対象とする
            retstring.Append( "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine );
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
            findParaLogicalDeleteCode.Value = 0;

            // 開始締処理日(>=)
            if ( para.St_Date > 0 )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 DEL
                //retstring.Append( "  AND ADDUPDATERF=@FINDADDUPDATEST" + Environment.NewLine );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                retstring.Append( "  AND ADDUPDATERF>=@FINDADDUPDATEST" + Environment.NewLine );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                SqlParameter findParaAddUpDateST = sqlCommand.Parameters.Add( "@FINDADDUPDATEST", SqlDbType.Int );
                findParaAddUpDateST.Value = SqlDataMediator.SqlSetInt32( para.St_Date );
            }

            // 終了締処理日(<=)
            if ( para.Ed_Date > 0 )
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 DEL
                //retstring.Append( "  AND ADDUPDATERF=@FINDADDUPDATEED" + Environment.NewLine );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/26 ADD
                retstring.Append( "  AND ADDUPDATERF<=@FINDADDUPDATEED" + Environment.NewLine );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/26 ADD
                SqlParameter findParaAddUpDateED = sqlCommand.Parameters.Add( "@FINDADDUPDATEED", SqlDbType.Int );
                findParaAddUpDateED.Value = SqlDataMediator.SqlSetInt32( para.Ed_Date );
            }

            #endregion

            return retstring.ToString();
        }
        # endregion
        # endregion

        # region [金額請求]
        #region 取得処理・金額請求
        /// <summary>
        /// 取得処理・金額請求
        /// </summary>
        /// <param name="retWorkList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 得意先請求金額マスタからデータ取得します</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public int SearchPrcDmdC( out object retWorkList, object paraWork )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retWorkList = null;

            TtlDayCalcParaWork para = (paraWork as TtlDayCalcParaWork);

            try
            {
                status = SearchPrcDmdCProc( out retWorkList, para );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcDmdC Exception=" + ex.Message );
                retWorkList = new CustomSerializeArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        /// <summary>
        /// 取得処理メイン・金額請求
        /// </summary>
        /// <param name="retWorkList"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchPrcDmdCProc( out object retWorkList, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            retWorkList = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();  //抽出結果(全て)
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( connectionText == null || connectionText == "" ) return status;

                //SQL文生成
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                status = SearchPrcDmdCProcAct( ref list, ref sqlConnection, para );
                retList.Add( list );

                //マスタ取得
                status = SearchStProc( out list, para, ref sqlConnection );
                retList.Add( list );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcDmdCProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    //@//暗号化キークローズ
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retWorkList = retList;

            return status;
        }
        #endregion

        #region 取得処理（実行部）・金額請求
        /// <summary>
        /// 取得処理（実行部）・金額請求
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchPrcDmdCProcAct( ref CustomSerializeArrayList list, ref SqlConnection sqlConnection, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;

                sqlCommand = new SqlCommand( selectTxt, sqlConnection );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 DEL
                # region // DEL
                //# region [SELECT]
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  CDMD1.*," + Environment.NewLine;
                //selectTxt += "  MAX(CDMD2.ADDUPDATERF) AS CLAIMMAXADDUPDATERF" + Environment.NewLine;
                //selectTxt += "FROM " + Environment.NewLine;
                //selectTxt += "( " + Environment.NewLine;

                //# region [CDMD1]
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  CLAIMCODERF," + Environment.NewLine;
                //selectTxt += "  CUSTOMERCODERF," + Environment.NewLine;
                //selectTxt += "  MAX(ADDUPDATERF) AS MAXADDUPDATERF" + Environment.NewLine;
                //selectTxt += "FROM" + Environment.NewLine;
                //selectTxt += "  CUSTDMDPRCRF" + Environment.NewLine;

                ////WHERE文の作成
                //selectTxt += MakeWhereStringForPrcDmdC( ref sqlCommand, para );

                ////GROUPBY句の作成
                //selectTxt += "GROUP BY " + Environment.NewLine;
                //selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  CLAIMCODERF," + Environment.NewLine;
                //selectTxt += "  CUSTOMERCODERF" + Environment.NewLine; ;
                //# endregion

                //selectTxt += ") AS CDMD1" + Environment.NewLine;

                //// LEFT JOIN
                //selectTxt += "LEFT JOIN" + Environment.NewLine;
                //selectTxt += "  CUSTDMDPRCRF AS CDMD2" + Environment.NewLine;
                //selectTxt += "ON" + Environment.NewLine;
                //selectTxt += "  CDMD1.ENTERPRISECODERF=CDMD2.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "  AND CDMD1.CLAIMCODERF=CDMD2.CLAIMCODERF" + Environment.NewLine;
                //selectTxt += "  AND CDMD2.CUSTOMERCODERF='0'" + Environment.NewLine;
                //selectTxt += "  AND CDMD2.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                //if ( para.St_Date != 0 )
                //{
                //    selectTxt += "  AND CDMD2.ADDUPDATERF>=@FINDADDUPDATEST" + Environment.NewLine;
                //}
                //if ( para.Ed_Date != 0 )
                //{
                //    selectTxt += "  AND CDMD2.ADDUPDATERF<=@FINDADDUPDATEED" + Environment.NewLine;
                //}

                //// GROUP BY
                //selectTxt += "GROUP BY" + Environment.NewLine;
                //selectTxt += "  CDMD1.ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  CDMD1.CLAIMCODERF," + Environment.NewLine;
                //selectTxt += "  CDMD1.CUSTOMERCODERF," + Environment.NewLine;
                //selectTxt += "  CDMD1.MAXADDUPDATERF" + Environment.NewLine;
                //# endregion
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 ADD
                # region [SELECT]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  CUST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  CUST.CLAIMSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  CUST.CLAIMCODERF," + Environment.NewLine;
                selectTxt += "  CUST.CUSTOMERCODERF," + Environment.NewLine;
                selectTxt += "  DMD1.MAXADDUPDATERF," + Environment.NewLine;
                selectTxt += "  MAX(DMD2.ADDUPDATERF) AS CLAIMMAXADDUPDATERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [CUST]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  CLAIMSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  CLAIMCODERF," + Environment.NewLine;
                selectTxt += "  CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  CUSTOMERRF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                if ( para.CustomerCode != 0 )
                {
                    selectTxt += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                }
                # endregion

                selectTxt += ") AS CUST" + Environment.NewLine;
                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [DMD1]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  CUSTOMERCODERF," + Environment.NewLine;
                selectTxt += "  MAX(ADDUPDATERF) AS MAXADDUPDATERF" + Environment.NewLine;
                selectTxt += "FROM " + Environment.NewLine;
                selectTxt += "  CUSTDMDPRCRF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                if ( !string.IsNullOrEmpty( para.SectionCode ) )
                {
                    selectTxt += "  AND RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                }
                if ( para.CustomerCode != 0 )
                {
                    selectTxt += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                }
                else
                {
                    selectTxt += "  AND CUSTOMERCODERF<>'0'" + Environment.NewLine;
                }
                //if ( para.St_Date != 0 )
                //{
                //    selectTxt += "  AND ADDUPDATERF>=@FINDADDUPDATEST" + Environment.NewLine;
                //}
                //if ( para.Ed_Date != 0 )
                //{
                //    selectTxt += "  AND ADDUPDATERF<=@FINDADDUPDATEED" + Environment.NewLine;
                //}
                selectTxt += "GROUP BY" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  CUSTOMERCODERF" + Environment.NewLine;
                # endregion

                selectTxt += ") AS DMD1" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  CUST.ENTERPRISECODERF=DMD1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND CUST.CUSTOMERCODERF=DMD1.CUSTOMERCODERF" + Environment.NewLine;

                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "CUSTDMDPRCRF AS DMD2" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  CUST.ENTERPRISECODERF=DMD2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND CUST.CLAIMCODERF=DMD2.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  AND DMD2.CUSTOMERCODERF='0'" + Environment.NewLine;
                selectTxt += "  AND DMD2.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;

                selectTxt += "GROUP BY" + Environment.NewLine;
                selectTxt += "  CUST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  CUST.CLAIMSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  CUST.CLAIMCODERF," + Environment.NewLine;
                selectTxt += "  CUST.CUSTOMERCODERF," + Environment.NewLine;
                selectTxt += "  DMD1.MAXADDUPDATERF" + Environment.NewLine;
                # endregion

                # region [PARAMS]
                // 企業コード
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );
                // 得意先コード
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32( para.CustomerCode );
                // 実績拠点コード
                SqlParameter findParaResultSectCd = sqlCommand.Parameters.Add( "@FINDRESULTSSECTCD", SqlDbType.NChar );
                findParaResultSectCd.Value = SqlDataMediator.SqlSetString( para.SectionCode );
                //// 開始日
                //SqlParameter findParaAddUpDateST = sqlCommand.Parameters.Add( "@FINDADDUPDATEST", SqlDbType.Int );
                //findParaAddUpDateST.Value = SqlDataMediator.SqlSetInt32( para.St_Date );
                //// 終了日
                //SqlParameter findParaAddUpDateED = sqlCommand.Parameters.Add( "@FINDADDUPDATEED", SqlDbType.Int );
                //findParaAddUpDateED.Value = SqlDataMediator.SqlSetInt32( para.Ed_Date );
                // 論理削除コード
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
                findParaLogicalDeleteCode.Value = 0;
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 ADD

                sqlCommand.CommandText = selectTxt;
                myReader = sqlCommand.ExecuteReader();

                Dictionary<int, TtlDayCalcRetWork> retWorkDic = new Dictionary<int, TtlDayCalcRetWork>();

                while ( myReader.Read() )
                {
                    #region 抽出結果-値セット
                    TtlDayCalcRetWork retWork = new TtlDayCalcRetWork();

                    retWork.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );
                    retWork.ProcDiv = 0;    // 0:請求売掛
                    retWork.SectionCode = string.Empty;
                    retWork.CustomerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
                    if ( retWork.CustomerCode == 0 )
                    {
                        retWork.CustomerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
                    }
                    retWork.SupplierCd = 0;
                    retWork.TotalDay = Math.Max( SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAXADDUPDATERF" ) ),
                                                 SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMMAXADDUPDATERF" ) ) );
                    if ( retWork.TotalDay == 0 ) continue;
                    #endregion

                    if ( retWorkDic.ContainsKey( retWork.CustomerCode ) )
                    {
                        if ( retWorkDic[retWork.CustomerCode].TotalDay < retWork.TotalDay )
                        {
                            retWorkDic[retWork.CustomerCode] = retWork;
                        }
                    }
                    else
                    {
                        retWorkDic.Add( retWork.CustomerCode, retWork );
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                foreach ( TtlDayCalcRetWork retWork in retWorkDic.Values )
                {
                    list.Add( retWork );
                }
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcDmdCProcAct Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlCommand != null ) sqlCommand.Dispose();
                if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        #endregion

        # region WHERE文生成・金額請求
        ///// <summary>
        ///// WHERE文作成・金額請求
        ///// </summary>
        ///// <param name="sqlCommand"></param>
        ///// <param name="para"></param>
        ///// <returns></returns>
        //private string MakeWhereStringForPrcDmdC( ref SqlCommand sqlCommand, TtlDayCalcParaWork para )
        //{
        //    StringBuilder retstring = new StringBuilder();

        //    #region WHERE文作成
        //    retstring.Append( "WHERE" + Environment.NewLine );

        //    //企業コード
        //    retstring.Append( "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine );
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
        //    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
        //    //// 拠点コード
        //    //if ( !String.IsNullOrEmpty( para.SectionCode ) )
        //    //{
        //    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
        //    //    //retstring.Append( "  AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine );
        //    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL
        //    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
        //    //    retstring.Append( "  AND RESULTSSECTCDRF=@FINDADDUPSECCODE " + Environment.NewLine );
        //    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD
        //    //    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
        //    //    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
        //    //}

        //    //// 得意先コード
        //    //if ( para.CustomerCode != 0 )
        //    //{
        //    //    // 指定されたコードのみ
        //    //    retstring.Append( "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE " + Environment.NewLine );
        //    //    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
        //    //    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32( para.CustomerCode );
        //    //}
        //    //else
        //    //{
        //    //    // ゼロを除く
        //    //    retstring.Append( "  AND CUSTOMERCODERF<>@FINDCUSTOMERCODE " + Environment.NewLine );
        //    //    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
        //    //    findParaCustomerCode.Value = 0;
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
        //    retstring.Append( " AND ( ( " + Environment.NewLine );

        //    // 得意先コード
        //    if ( para.CustomerCode != 0 )
        //    {
        //        // 指定されたコードのみ
        //        retstring.Append( "  CUSTOMERCODERF=@FINDCUSTOMERCODE " + Environment.NewLine );
        //        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
        //        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32( para.CustomerCode );
        //    }
        //    else
        //    {
        //        // ゼロを除く
        //        retstring.Append( "  CUSTOMERCODERF<>@FINDCUSTOMERCODE " + Environment.NewLine );
        //        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
        //        findParaCustomerCode.Value = 0;
        //    }
        //    // 拠点コード
        //    if ( !String.IsNullOrEmpty( para.SectionCode ) )
        //    {
        //        retstring.Append( "  AND RESULTSSECTCDRF=@FINDRESULTSSECTCD " + Environment.NewLine );
        //        SqlParameter findParaResultSectCd = sqlCommand.Parameters.Add( "@FINDRESULTSSECTCD", SqlDbType.NChar );
        //        findParaResultSectCd.Value = SqlDataMediator.SqlSetString( para.SectionCode );
        //    }
        //    retstring.Append( ")" + Environment.NewLine );

        //    if ( para.CustomerCode != 0 )
        //    {
        //        // 請求先
        //        retstring.Append( "  OR ( CLAIMCODERF=@FINDCLAIMCODE AND CUSTOMERCODERF='0' " );
        //        SqlParameter findParaClaimCode = sqlCommand.Parameters.Add( "@FINDCLAIMCODE", SqlDbType.Int );
        //        findParaClaimCode.Value = SqlDataMediator.SqlSetInt32( para.CustomerCode );

        //        // 拠点コード
        //        if ( !String.IsNullOrEmpty( para.SectionCode ) )
        //        {
        //            retstring.Append( " AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine );
        //            SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
        //            findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
        //        }
        //        retstring.Append( ")" + Environment.NewLine );
        //    }

        //    retstring.Append( ")" + Environment.NewLine );
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD

        //    // 論理削除コード＝0のみを対象とする
        //    retstring.Append( "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine );
        //    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
        //    findParaLogicalDeleteCode.Value = 0;

        //    // 開始締処理日(>=)
        //    if ( para.St_Date > 0 )
        //    {
        //        retstring.Append( "  AND ADDUPDATERF>=@FINDADDUPDATEST" + Environment.NewLine );
        //        SqlParameter findParaAddUpDateST = sqlCommand.Parameters.Add( "@FINDADDUPDATEST", SqlDbType.Int );
        //        findParaAddUpDateST.Value = SqlDataMediator.SqlSetInt32( para.St_Date );
        //    }

        //    // 終了締処理日(<=)
        //    if ( para.Ed_Date > 0 )
        //    {
        //        retstring.Append( "  AND ADDUPDATERF<=@FINDADDUPDATEED" + Environment.NewLine );
        //        SqlParameter findParaAddUpDateED = sqlCommand.Parameters.Add( "@FINDADDUPDATEED", SqlDbType.Int );
        //        findParaAddUpDateED.Value = SqlDataMediator.SqlSetInt32( para.Ed_Date );
        //    }

        //    #endregion

        //    return retstring.ToString();
        //}
        # endregion

        # endregion

        # region [金額支払]
        #region 取得処理・金額支払
        /// <summary>
        /// 取得処理・金額支払
        /// </summary>
        /// <param name="retWorkList">検索結果</param>
        /// <param name="paraWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 仕入先支払金額マスタからデータ取得します</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.03.06</br>
        /// </remarks>
        public int SearchPrcPayment( out object retWorkList, object paraWork )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retWorkList = null;

            TtlDayCalcParaWork para = (paraWork as TtlDayCalcParaWork);

            try
            {
                status = SearchPrcPaymentProc( out retWorkList, para );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcPayment Exception=" + ex.Message );
                retWorkList = new CustomSerializeArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        /// <summary>
        /// 取得処理メイン・金額支払
        /// </summary>
        /// <param name="retWorkList"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchPrcPaymentProc( out object retWorkList, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //@SqlEncryptInfo sqlEncryptInfo = null;

            retWorkList = null;

            CustomSerializeArrayList retList = new CustomSerializeArrayList();  //抽出結果(全て)
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( connectionText == null || connectionText == "" ) return status;

                //SQL文生成
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                status = SearchPrcPaymentProcAct( ref list, ref sqlConnection, para );
                retList.Add( list );

                //マスタ取得
                status = SearchStProc( out list, para, ref sqlConnection );
                retList.Add( list );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcPaymentProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlConnection != null )
                {
                    //@//暗号化キークローズ
                    //@if (sqlEncryptInfo != null && sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retWorkList = retList;

            return status;
        }
        #endregion

        #region 取得処理（実行部）・金額支払
        /// <summary>
        /// 取得処理（実行部）・金額支払
        /// </summary>
        /// <param name="list"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        private int SearchPrcPaymentProcAct( ref CustomSerializeArrayList list, ref SqlConnection sqlConnection, TtlDayCalcParaWork para )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            Dictionary<int, TtlDayCalcRetWork> retWorkDic = new Dictionary<int, TtlDayCalcRetWork>();

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand( selectTxt, sqlConnection );

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 DEL
                # region // DEL
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  SPL1.*," + Environment.NewLine;
                //selectTxt += "  MAX(SPL2.ADDUPDATERF) AS PAYEEMAXADDUPDATERF" + Environment.NewLine;
                //selectTxt += "FROM" + Environment.NewLine;
                //selectTxt += "(" + Environment.NewLine;

                //# region SPL1
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  PAYEECODERF," + Environment.NewLine;
                //selectTxt += "  SUPPLIERCDRF," + Environment.NewLine;
                //selectTxt += "  MAX(ADDUPDATERF) AS MAXADDUPDATERF" + Environment.NewLine;
                //selectTxt += "FROM" + Environment.NewLine;
                //selectTxt += "  SUPLIERPAYRF" + Environment.NewLine;

                ////WHERE文の作成
                //sqlCommand.CommandText += MakeWhereStringForPrcPayment( ref sqlCommand, para );

                ////GROUPBY句の作成
                //selectTxt += "GROUP BY " + Environment.NewLine;
                //selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  PAYEECODERF," + Environment.NewLine;
                //selectTxt += "  SUPPLIERCDRF" + Environment.NewLine; ;
                //# endregion

                //selectTxt += ") AS SPL1" + Environment.NewLine;

                //// LEFT JOIN
                //selectTxt += "LEFT JOIN" + Environment.NewLine;
                //selectTxt += "  SUPLIERPAYRF AS SPL2" + Environment.NewLine;
                //selectTxt += "ON" + Environment.NewLine;
                //selectTxt += "  SPL1.ENTERPRISECODERF=SPL2.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "  AND SPL1.PAYEECODERF=SPL2.PAYEECODERF" + Environment.NewLine;
                //selectTxt += "  AND SPL2.SUPPLIERCDRF='0'" + Environment.NewLine;
                //selectTxt += "  AND SPL2.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                //if ( para.St_Date > 0 )
                //{
                //    selectTxt += "  AND SPL2.ADDUPDATERF>=@FINDADDUPDATEST" + Environment.NewLine;
                //}
                //if ( para.Ed_Date > 0 )
                //{
                //    selectTxt +=  "  AND SPL2.ADDUPDATERF<=@FINDADDUPDATEED" + Environment.NewLine;
                //}

                //// GROUP BY
                //selectTxt += "GROUP BY" + Environment.NewLine;
                //selectTxt += "  SPL1.ENTERPRISECODERF," + Environment.NewLine;
                //selectTxt += "  SPL1.PAYEECODERF," + Environment.NewLine;
                //selectTxt += "  SPL1.SUPPLIERCDRF," + Environment.NewLine;
                //selectTxt += "  SPL1.MAXADDUPDATERF" + Environment.NewLine;
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/13 ADD
                # region [SELECT]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  SUP.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  SUP.PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  SUP.PAYEECODERF," + Environment.NewLine;
                selectTxt += "  SUP.SUPPLIERCDRF," + Environment.NewLine;
                selectTxt += "  SPL1.MAXADDUPDATERF," + Environment.NewLine;
                selectTxt += "  MAX(SPL2.ADDUPDATERF) AS PAYEEMAXADDUPDATERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [SUP]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += "PAYEECODERF," + Environment.NewLine;
                selectTxt += "  SUPPLIERCDRF  " + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  SUPPLIERRF " + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                if ( para.SupplierCd != 0 )
                {
                    selectTxt += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                }
                # endregion

                selectTxt += ") AS SUP" + Environment.NewLine;
                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;

                # region [SPL1]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  SUPPLIERCDRF," + Environment.NewLine;
                selectTxt += "  MAX(ADDUPDATERF) AS MAXADDUPDATERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "  SUPLIERPAYRF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                if ( !string.IsNullOrEmpty( para.SectionCode ) )
                {
                    selectTxt += "  AND RESULTSSECTCDRF=@FINDRESULTSSECTCD" + Environment.NewLine;
                }
                if ( para.SupplierCd != 0 )
                {
                    selectTxt += "  AND SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                }
                else
                {
                    selectTxt += "  AND SUPPLIERCDRF<>'0'" + Environment.NewLine;
                }
                selectTxt += "GROUP BY" + Environment.NewLine;
                selectTxt += "  ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  SUPPLIERCDRF" + Environment.NewLine;
                # endregion

                selectTxt += ") AS SPL1" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  SUP.ENTERPRISECODERF=SPL1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SUP.SUPPLIERCDRF=SPL1.SUPPLIERCDRF" + Environment.NewLine;

                selectTxt += "LEFT JOIN" + Environment.NewLine;
                selectTxt += "SUPLIERPAYRF AS SPL2" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "  SUP.ENTERPRISECODERF=SPL2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SUP.PAYEECODERF=SPL2.PAYEECODERF" + Environment.NewLine;
                selectTxt += "  AND SPL2.SUPPLIERCDRF='0'" + Environment.NewLine;
                selectTxt += "  AND SPL2.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                selectTxt += "GROUP BY" + Environment.NewLine;
                selectTxt += "  SUP.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "  SUP.PAYMENTSECTIONCODERF," + Environment.NewLine;
                selectTxt += "  SUP.PAYEECODERF," + Environment.NewLine;
                selectTxt += "  SUP.SUPPLIERCDRF," + Environment.NewLine;
                selectTxt += "  SPL1.MAXADDUPDATERF" + Environment.NewLine;
                # endregion

                # region[PARAMS]
                // 企業コード
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );
                // 実績拠点コード
                SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add( "@FINDRESULTSSECTCD", SqlDbType.NChar );
                findParaResultsSectCd.Value = SqlDataMediator.SqlSetString( para.SectionCode );
                // 仕入先コード
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32( para.SupplierCd );
                // 論理削除コード
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
                findParaLogicalDeleteCode.Value = 0;
                # endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/13 ADD

                sqlCommand.CommandText = selectTxt;
                myReader = sqlCommand.ExecuteReader();

                while ( myReader.Read() )
                {
                    #region 抽出結果-値セット
                    TtlDayCalcRetWork retWork = new TtlDayCalcRetWork();

                    retWork.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );
                    retWork.ProcDiv = 1;    // 1:支払買掛
                    retWork.SectionCode = string.Empty;
                    retWork.CustomerCode = 0;
                    retWork.SupplierCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERCDRF" ) );
                    if ( retWork.SupplierCd == 0 )
                    {
                        retWork.SupplierCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PAYEECODERF" ) );
                    }
                    retWork.TotalDay = Math.Max( SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAXADDUPDATERF" ) ),
                                                 SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PAYEEMAXADDUPDATERF" ) ) );
                    if ( retWork.TotalDay == 0 ) continue;
                    #endregion

                    if ( retWorkDic.ContainsKey( retWork.SupplierCd ) )
                    {
                        if ( retWorkDic[retWork.SupplierCd].TotalDay < retWork.TotalDay )
                        {
                            retWorkDic[retWork.SupplierCd] = retWork;
                        }
                    }
                    else
                    {
                        retWorkDic.Add( retWork.SupplierCd, retWork );
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                foreach ( TtlDayCalcRetWork retWork in retWorkDic.Values )
                {
                    list.Add( retWork );
                }
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcPaymentProcAct Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if ( sqlCommand != null ) sqlCommand.Dispose();
                if ( !myReader.IsClosed ) myReader.Close();
            }

            return status;
        }

        #endregion

        # region WHERE文生成・金額支払
        ///// <summary>
        ///// WHERE文作成・金額支払
        ///// </summary>
        ///// <param name="sqlCommand"></param>
        ///// <param name="para"></param>
        ///// <returns></returns>
        //private string MakeWhereStringForPrcPayment( ref SqlCommand sqlCommand, TtlDayCalcParaWork para )
        //{
        //    StringBuilder retstring = new StringBuilder();

        //    #region WHERE文作成
        //    retstring.Append( "WHERE" + Environment.NewLine );

        //    //企業コード
        //    retstring.Append( "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine );
        //    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
        //    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString( para.EnterpriseCode );

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
        //    //// 拠点コード
        //    //if ( !String.IsNullOrEmpty( para.SectionCode ) )
        //    //{
        //    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 DEL
        //    //    //retstring.Append( "  AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine );
        //    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL
        //    //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
        //    //    retstring.Append( "  AND RESULTSSECTCDRF=@FINDADDUPSECCODE " + Environment.NewLine );
        //    //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD
        //    //    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
        //    //    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
        //    //}

        //    //// 仕入先コード
        //    //if ( para.CustomerCode != 0 )
        //    //{
        //    //    // 指定されたコードのみ
        //    //    retstring.Append( "  AND SUPPLIERCDRF=@FINDSUPPLIERCD " + Environment.NewLine );
        //    //    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
        //    //    findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32( para.SupplierCd );
        //    //}
        //    //else
        //    //{
        //    //    // ゼロを除く
        //    //    retstring.Append( "  AND SUPPLIERCDRF<>@FINDSUPPLIERCD " + Environment.NewLine );
        //    //    SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
        //    //    findParaSupplierCd.Value = 0;
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 DEL
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/02 ADD
        //    retstring.Append( " AND ( ( " + Environment.NewLine );

        //    // 仕入先コード
        //    if ( para.SupplierCd != 0 )
        //    {
        //        // 指定されたコードのみ
        //        retstring.Append( "  SUPPLIERCDRF=@FINDSUPPLIERCD " + Environment.NewLine );
        //        SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
        //        findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32( para.SupplierCd );
        //    }
        //    else
        //    {
        //        // ゼロを除く
        //        retstring.Append( "  SUPPLIERCDRF<>@FINDSUPPLIERCD " + Environment.NewLine );
        //        SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add( "@FINDSUPPLIERCD", SqlDbType.Int );
        //        findParaSupplierCd.Value = 0;
        //    }
        //    // 拠点コード
        //    if ( !String.IsNullOrEmpty( para.SectionCode ) )
        //    {
        //        retstring.Append( "  AND RESULTSSECTCDRF=@FINDRESULTSSECTCD " + Environment.NewLine );
        //        SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add( "@FINDRESULTSSECTCD", SqlDbType.NChar );
        //        findParaResultsSectCd.Value = SqlDataMediator.SqlSetString( para.SectionCode );
        //    }
        //    retstring.Append( " ) " + Environment.NewLine );

        //    if ( para.SupplierCd != 0 )
        //    {
        //        // 支払先
        //        retstring.Append( "  OR ( PAYEECODERF=@FINDPAYEECODE AND SUPPLIERCDRF='0' " + Environment.NewLine );
        //        SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add( "@FINDPAYEECODE", SqlDbType.Int );
        //        findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32( para.SupplierCd );

        //        // 拠点コード
        //        if ( !String.IsNullOrEmpty( para.SectionCode ) )
        //        {
        //            retstring.Append( " AND ADDUPSECCODERF=@FINDADDUPSECCODE " + Environment.NewLine );
        //            SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
        //            findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString( para.SectionCode );
        //        }
        //        retstring.Append( " ) " + Environment.NewLine );
        //    }

        //    retstring.Append( " ) " + Environment.NewLine );
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/02 ADD

        //    // 論理削除コード＝0のみを対象とする
        //    retstring.Append( "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine );
        //    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
        //    findParaLogicalDeleteCode.Value = 0;

        //    // 開始締処理日(>=)
        //    if ( para.St_Date > 0 )
        //    {
        //        retstring.Append( "  AND ADDUPDATERF>=@FINDADDUPDATEST" + Environment.NewLine );
        //        SqlParameter findParaAddUpDateST = sqlCommand.Parameters.Add( "@FINDADDUPDATEST", SqlDbType.Int );
        //        findParaAddUpDateST.Value = SqlDataMediator.SqlSetInt32( para.St_Date );
        //    }

        //    // 終了締処理日(<=)
        //    if ( para.Ed_Date > 0 )
        //    {
        //        retstring.Append( "  AND ADDUPDATERF<=@FINDADDUPDATEED" + Environment.NewLine );
        //        SqlParameter findParaAddUpDateED = sqlCommand.Parameters.Add( "@FINDADDUPDATEED", SqlDbType.Int );
        //        findParaAddUpDateED.Value = SqlDataMediator.SqlSetInt32( para.Ed_Date );
        //    }

        //    #endregion

        //    return retstring.ToString();
        //}
        # endregion

        # endregion

        # region [マスタ取得Ｒ呼び出し]
        /// <summary>
        /// マスタ取得リモート呼び出し処理
        /// </summary>
        /// <param name="retWorkList">返却リスト</param>
        /// <param name="para">抽出条件パラメータ</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <returns></returns>
        private int SearchStProc( out CustomSerializeArrayList retWorkList, TtlDayCalcParaWork para, ref SqlConnection sqlConnection )
        {
            retWorkList = new CustomSerializeArrayList();

            if ( para.WithMasterDiv > 0 )
            {
                //------------------------------------------------
                // マスタ取得する
                //------------------------------------------------
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // 自社情報マスタ
                status = SearchCompanyInf( para, ref retWorkList, ref sqlConnection );
                if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // 請求全体設定マスタ
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    status = SearchBillAllSt( para, ref retWorkList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                return status;
            }
            else
            {
                //------------------------------------------------
                // マスタ取得しない
                //------------------------------------------------
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
        }
        /// <summary>
        /// Search 自社情報
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="retList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchCompanyInf( TtlDayCalcParaWork para, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            // 抽出条件
            CompanyInfWork paraWork = new CompanyInfWork();
            paraWork.EnterpriseCode = para.EnterpriseCode;

            // 抽出
            ArrayList retList;
            CompanyInfDB companyInfDB = new CompanyInfDB();
            int status = companyInfDB.Search( out retList, paraWork, ref sqlConnection );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( CompanyInfWork ) ) );
            }
            return status;
        }

        /// <summary>
        /// Search 請求全体設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="retList"></param>
        /// <param name="sqlConnection"></param>
        private int SearchBillAllSt( TtlDayCalcParaWork para, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            // 抽出条件
            BillAllStWork paraWork = new BillAllStWork();
            paraWork.EnterpriseCode = para.EnterpriseCode;

            // 抽出
            ArrayList retList = new ArrayList();
            SqlTransaction sqlTransaction = null;
            BillAllStDB billAllStDB = new BillAllStDB();
            int status = billAllStDB.Search( ref retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( BillAllStWork ) ) );
            }
            return status;
        }

        # endregion

        # region [別Ｒからの呼び出し用]
        # region [R→R 金額請求]
        /// <summary>
        /// 締日算出処理（金額・請求）R→R用
        /// </summary>
        /// <param name="retList">(出力)締日算出retWork</param>
        /// <param name="para">締日算出paraWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        public int SearchPrcDmdC( out List<TtlDayCalcRetWork> retList, TtlDayCalcParaWork para, ref SqlConnection sqlConnection )
        {
            return SearchPrcDmdCProc( out retList, para, ref sqlConnection );
        }
        /// <summary>
        /// 締日算出処理（金額・請求）R→R用
        /// </summary>
        /// <param name="retList">(出力)締日算出retWork</param>
        /// <param name="para">締日算出paraWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        private int SearchPrcDmdCProc( out List<TtlDayCalcRetWork> retList, TtlDayCalcParaWork para, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retList = null;
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                status = SearchPrcDmdCProcAct( ref list, ref sqlConnection, para );
                retList = new List<TtlDayCalcRetWork>( (TtlDayCalcRetWork[])list.ToArray( typeof( TtlDayCalcRetWork ) ) );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcDmdCProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }

            if ( retList == null )
            {
                retList = new List<TtlDayCalcRetWork>();
            }

            return status;
        }
        # endregion
        
        # region [R→R 金額支払]
        /// <summary>
        /// 締日算出処理（金額・支払）R→R用
        /// </summary>
        /// <param name="retList">(出力)締日算出retWork</param>
        /// <param name="para">締日算出paraWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        public int SearchPrcPayment( out List<TtlDayCalcRetWork> retList, TtlDayCalcParaWork para, ref SqlConnection sqlConnection )
        {
            return SearchPrcPaymentProc( out retList, para, ref sqlConnection );
        }
        /// <summary>
        /// 締日算出処理（金額・支払）R→R用
        /// </summary>
        /// <param name="retList">(出力)締日算出retWork</param>
        /// <param name="para">締日算出paraWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        private int SearchPrcPaymentProc( out List<TtlDayCalcRetWork> retList, TtlDayCalcParaWork para, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retList = null;
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                status = SearchPrcPaymentProcAct( ref list, ref sqlConnection, para );
                retList = new List<TtlDayCalcRetWork>( (TtlDayCalcRetWork[])list.ToArray( typeof( TtlDayCalcRetWork ) ) );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchPrcPaymentProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }

            if ( retList == null )
            {
                retList = new List<TtlDayCalcRetWork>();
            }

            return status;
        }
        # endregion

        # region [R→R 履歴売掛]
        /// <summary>
        /// 締日算出処理（履歴・売掛）R→R用
        /// </summary>
        /// <param name="retList">(出力)締日算出retWork</param>
        /// <param name="para">締日算出paraWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        public int SearchHisMonthlyAccRec( out List<TtlDayCalcRetWork> retList, TtlDayCalcParaWork para, ref SqlConnection sqlConnection )
        {
            return SearchHisMonthlyAccRecProc( out retList, para, ref sqlConnection );
        }
        /// <summary>
        /// 締日算出処理（履歴・売掛）R→R用
        /// </summary>
        /// <param name="retList">(出力)締日算出retWork</param>
        /// <param name="para">締日算出paraWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        private int SearchHisMonthlyAccRecProc( out List<TtlDayCalcRetWork> retList, TtlDayCalcParaWork para, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retList = null;
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                para.ProcDiv = 0;   // 0:売掛
                status = SearchHisMonthlyProcAct( ref list, ref sqlConnection, para );
                retList = new List<TtlDayCalcRetWork>( (TtlDayCalcRetWork[])list.ToArray( typeof( TtlDayCalcRetWork ) ) );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisMonthlyAccRecProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }

            if ( retList == null )
            {
                retList = new List<TtlDayCalcRetWork>();
            }

            return status;
        }
        # endregion

        # region [R→R 履歴買掛]
        /// <summary>
        /// 締日算出処理（履歴・買掛）R→R用
        /// </summary>
        /// <param name="retList">(出力)締日算出retWork</param>
        /// <param name="para">締日算出paraWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        public int SearchHisMonthlyAccPay( out List<TtlDayCalcRetWork> retList, TtlDayCalcParaWork para, ref SqlConnection sqlConnection )
        {
            return SearchHisMonthlyAccPayProc( out retList, para, ref sqlConnection );
        }
        /// <summary>
        /// 締日算出処理（履歴・買掛）R→R用
        /// </summary>
        /// <param name="retList">(出力)締日算出retWork</param>
        /// <param name="para">締日算出paraWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        private int SearchHisMonthlyAccPayProc( out List<TtlDayCalcRetWork> retList, TtlDayCalcParaWork para, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retList = null;
            CustomSerializeArrayList list = new CustomSerializeArrayList();     //抽出結果

            try
            {
                //@//●暗号化部品準備処理
                //@sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                //@//暗号化キーOPEN（SQLExceptionの可能性有り）
                //@sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //取得実行部
                para.ProcDiv = 1;   // 1:買掛
                status = SearchHisMonthlyProcAct( ref list, ref sqlConnection, para );
                retList = new List<TtlDayCalcRetWork>( (TtlDayCalcRetWork[])list.ToArray( typeof( TtlDayCalcRetWork ) ) );
            }
            catch ( SqlException ex )
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog( ex );
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "TtlDayCalcDB.SearchHisMonthlyAccPayProc Exception=" + ex.Message );
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }

            if ( retList == null )
            {
                retList = new List<TtlDayCalcRetWork>();
            }

            return status;
        }
        # endregion
        # endregion
    }
}

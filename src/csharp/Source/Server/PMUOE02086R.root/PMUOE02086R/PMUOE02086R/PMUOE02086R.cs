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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 発注送信エラーリストDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注送信エラーリストの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 30350 櫻井 亮太</br>
    /// <br>Date       : 2008.9.22</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class SupplierSendErOrderWorkDB : RemoteDB, ISupplierSendErOrderWorkDB
    {
        /// <summary>
        /// 発注送信エラーリストDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.9.22</br>
        /// </remarks>
        public SupplierSendErOrderWorkDB()
            :
        base("PMUOE02088D", "Broadleaf.Application.Remoting.ParamData.SupplierSendErResultWork", "UOEORDERDTLRF") //基底クラスのコンストラクタ
        {
        }

        #region 発注送信エラーリスト
        /// <summary>
        /// 指定された企業コードの発注送信エラーリストのLISTを全て戻します（論理削除除く）
        /// </summary>
        /// <param name="supplierUnmResultWork">検索結果</param>
        /// <param name="supplierUnmOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの復旧データ一覧表LISTを全て戻します（論理削除除く）</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.9.22</br>
        public int Search(out object supplierSendErResultWork, object supplierSendErOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            supplierSendErResultWork = null;

            SupplierSendErOrderCndtnWork _supplierSendErOrderCndtnWork = supplierSendErOrderCndtnWork as SupplierSendErOrderCndtnWork;

            try
            {
                status = SearchProc(out supplierSendErResultWork, _supplierSendErOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierSendErOrderWork.Search Exception=" + ex.Message);
                supplierSendErResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// 指定された企業コードの発注送信エラーリストのLISTを全て戻します
        /// </summary>
        /// <param name="supplierSendErResultWork">検索結果</param>
        /// <param name="_supplierSendErOrderCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された企業コードの発注送信エラーリストのLISTを全て戻します</br>
        /// <br>Programmer : 30350 櫻井 亮太</br>
        /// <br>Date       : 2008.9.18</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.15 長内 DC.NS用に修正</br>
        private int SearchProc(out object supplierSendErResultWork, SupplierSendErOrderCndtnWork _supplierSendErOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            supplierSendErResultWork = null;

            ArrayList al = new ArrayList();   //抽出結果

            try
            {
                //メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL文生成
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                status = SearchOrderProc(ref al, ref sqlConnection, _supplierSendErOrderCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SupplierSendErOrderWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            supplierSendErResultWork = al;

            return status;
        }

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="al">検索結果ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_supplierSendErOrderCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SupplierSendErOrderCndtnWork _supplierSendErOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select文作成

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "	       UOD.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.SYSTEMDIVCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESALESORDERNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESALESORDERROWNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.SENDTERMINALNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESUPPLIERNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.COMMASSEMBLYIDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ONLINENORF" + Environment.NewLine;
                selectTxt += "        ,UOD.ONLINEROWNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.SALESDATERF" + Environment.NewLine;
                selectTxt += "        ,UOD.INPUTDAYRF" + Environment.NewLine;
                selectTxt += "        ,UOD.DATAUPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEKINDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SALESSLIPNUMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SALESSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUBSECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.CUSTOMERSNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.CASHREGISTERNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.COMMONSEQNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERFORMALRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERSLIPNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.STOCKSLIPDTLNUMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEDELIGOODSDIVRF" + Environment.NewLine;
                selectTxt += "        ,UOD.DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.FOLLOWDELIGOODSDIVRF" + Environment.NewLine;
                selectTxt += "        ,UOD.FOLLOWDELIGOODSDIVNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOERESVDSECTIONRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOERESVDSECTIONNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.EMPLOYEENAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "        ,UOD.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.ACCEPTANORDERCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.LISTPRICERF" + Environment.NewLine;
                selectTxt += "        ,UOD.SALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEREMARK1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEREMARK2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.RECEIVEDATERF" + Environment.NewLine;
                selectTxt += "        ,UOD.RECEIVETIMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERPARTSNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERPARTSNAMERF" + Environment.NewLine;
                selectTxt += "        ,UOD.SUBSTPARTSNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSHIPMENTCNT3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAKERFOLLOWCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.NONSHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSTOCKCOUNT1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSTOCKCOUNT2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSTOCKCOUNT3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESECTIONSLIPNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOSLIPNO3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.EOALWCCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOMANAGEMENTNORF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERLISTPRICERF" + Environment.NewLine;
                selectTxt += "        ,UOD.ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESUBSTMARKRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOESTOCKMARKRF" + Environment.NewLine;
                selectTxt += "        ,UOD.PARTSLAYERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESHIPSECTCD1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESHIPSECTCD2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESHIPSECTCD3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD4RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD5RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD6RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESECTCD7RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT4RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT5RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT6RF" + Environment.NewLine;
                selectTxt += "        ,UOD.MAZDAUOESTOCKCNT7RF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEDISTRIBUTIONCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEOTHERCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEHMCDRF" + Environment.NewLine;
                selectTxt += "        ,UOD.BOCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOEMARKCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.SOURCESHIPMENTRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ITEMCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.UOECHECKCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.HEADERRORMASSAGERF" + Environment.NewLine;
                selectTxt += "        ,UOD.LINEERRORMASSAGERF" + Environment.NewLine;
                selectTxt += "        ,UOD.DATASENDCODERF" + Environment.NewLine;
                selectTxt += "        ,UOD.DATARECOVERDIVRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVSECRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVBO1RF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVBO2RF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVBO3RF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVMAKERRF" + Environment.NewLine;
                selectTxt += "        ,UOD.ENTERUPDDIVEORF" + Environment.NewLine;
                selectTxt += "FROM UOEORDERDTLRF AS UOD" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "     SEC.ENTERPRISECODERF=UOD.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND  SEC.SECTIONCODERF=UOD.SECTIONCODERF" + Environment.NewLine;

                
                //WHERE文の作成
                selectTxt += MakeWhereString(ref sqlCommand, _supplierSendErOrderCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region 抽出結果-値セット
                    SupplierSendErResultWork wkSupplierSendErResultWork = new SupplierSendErResultWork();
                    
                    //格納項目
                    wkSupplierSendErResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkSupplierSendErResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkSupplierSendErResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkSupplierSendErResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    wkSupplierSendErResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    wkSupplierSendErResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    wkSupplierSendErResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    wkSupplierSendErResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkSupplierSendErResultWork.SystemDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMDIVCDRF"));
                    wkSupplierSendErResultWork.UOESalesOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESALESORDERNORF"));
                    wkSupplierSendErResultWork.UOESalesOrderRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESALESORDERROWNORF"));
                    wkSupplierSendErResultWork.SendTerminalNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SENDTERMINALNORF"));
                    wkSupplierSendErResultWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));
                    wkSupplierSendErResultWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));
                    wkSupplierSendErResultWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                    wkSupplierSendErResultWork.OnlineNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINENORF"));
                    wkSupplierSendErResultWork.OnlineRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEROWNORF"));
                    wkSupplierSendErResultWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                    wkSupplierSendErResultWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                    wkSupplierSendErResultWork.DataUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("DATAUPDATEDATETIMERF"));
                    wkSupplierSendErResultWork.UOEKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOEKINDRF"));
                    wkSupplierSendErResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                    wkSupplierSendErResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                    wkSupplierSendErResultWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                    wkSupplierSendErResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkSupplierSendErResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkSupplierSendErResultWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    wkSupplierSendErResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    wkSupplierSendErResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    wkSupplierSendErResultWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                    wkSupplierSendErResultWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    wkSupplierSendErResultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    wkSupplierSendErResultWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    wkSupplierSendErResultWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    wkSupplierSendErResultWork.BoCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOCODERF"));
                    wkSupplierSendErResultWork.UOEDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDELIGOODSDIVRF"));
                    wkSupplierSendErResultWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
                    wkSupplierSendErResultWork.FollowDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOLLOWDELIGOODSDIVRF"));
                    wkSupplierSendErResultWork.FollowDeliGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOLLOWDELIGOODSDIVNMRF"));
                    wkSupplierSendErResultWork.UOEResvdSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONRF"));
                    wkSupplierSendErResultWork.UOEResvdSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONNMRF"));
                    wkSupplierSendErResultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    wkSupplierSendErResultWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEENAMERF"));
                    wkSupplierSendErResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkSupplierSendErResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkSupplierSendErResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkSupplierSendErResultWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    wkSupplierSendErResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkSupplierSendErResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkSupplierSendErResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkSupplierSendErResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkSupplierSendErResultWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                    wkSupplierSendErResultWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                    wkSupplierSendErResultWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                    wkSupplierSendErResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkSupplierSendErResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkSupplierSendErResultWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                    wkSupplierSendErResultWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                    wkSupplierSendErResultWork.ReceiveDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECEIVEDATERF"));
                    wkSupplierSendErResultWork.ReceiveTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIVETIMERF"));
                    wkSupplierSendErResultWork.AnswerMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERMAKERCDRF"));
                    wkSupplierSendErResultWork.AnswerPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERPARTSNORF"));
                    wkSupplierSendErResultWork.AnswerPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERPARTSNAMERF"));
                    wkSupplierSendErResultWork.SubstPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSTPARTSNORF"));
                    wkSupplierSendErResultWork.UOESectOutGoodsCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTOUTGOODSCNTRF"));
                    wkSupplierSendErResultWork.BOShipmentCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT1RF"));
                    wkSupplierSendErResultWork.BOShipmentCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT2RF"));
                    wkSupplierSendErResultWork.BOShipmentCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT3RF"));
                    wkSupplierSendErResultWork.MakerFollowCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERFOLLOWCNTRF"));
                    wkSupplierSendErResultWork.NonShipmentCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NONSHIPMENTCNTRF"));
                    wkSupplierSendErResultWork.UOESectStockCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTSTOCKCNTRF"));
                    wkSupplierSendErResultWork.BOStockCount1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT1RF"));
                    wkSupplierSendErResultWork.BOStockCount2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT2RF"));
                    wkSupplierSendErResultWork.BOStockCount3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT3RF"));
                    wkSupplierSendErResultWork.UOESectionSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESECTIONSLIPNORF"));
                    wkSupplierSendErResultWork.BOSlipNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO1RF"));
                    wkSupplierSendErResultWork.BOSlipNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO2RF"));
                    wkSupplierSendErResultWork.BOSlipNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO3RF"));
                    wkSupplierSendErResultWork.EOAlwcCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EOALWCCOUNTRF"));
                    wkSupplierSendErResultWork.BOManagementNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOMANAGEMENTNORF"));
                    wkSupplierSendErResultWork.AnswerListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERLISTPRICERF"));
                    wkSupplierSendErResultWork.AnswerSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERSALESUNITCOSTRF"));
                    wkSupplierSendErResultWork.UOESubstMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUBSTMARKRF"));
                    wkSupplierSendErResultWork.UOEStockMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESTOCKMARKRF"));
                    wkSupplierSendErResultWork.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                    wkSupplierSendErResultWork.MazdaUOEShipSectCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD1RF"));
                    wkSupplierSendErResultWork.MazdaUOEShipSectCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD2RF"));
                    wkSupplierSendErResultWork.MazdaUOEShipSectCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD3RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD1RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD2RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD3RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD4RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD5RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD6RF"));
                    wkSupplierSendErResultWork.MazdaUOESectCd7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD7RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT1RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT2RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT3RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT4RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT5RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT6RF"));
                    wkSupplierSendErResultWork.MazdaUOEStockCnt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT7RF"));
                    wkSupplierSendErResultWork.UOEDistributionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDISTRIBUTIONCDRF"));
                    wkSupplierSendErResultWork.UOEOtherCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEOTHERCDRF"));
                    wkSupplierSendErResultWork.UOEHMCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEHMCDRF"));
                    wkSupplierSendErResultWork.BOCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOCOUNTRF"));
                    wkSupplierSendErResultWork.UOEMarkCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEMARKCODERF"));
                    wkSupplierSendErResultWork.SourceShipment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SOURCESHIPMENTRF"));
                    wkSupplierSendErResultWork.ItemCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ITEMCODERF"));
                    wkSupplierSendErResultWork.UOECheckCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOECHECKCODERF"));
                    wkSupplierSendErResultWork.HeadErrorMassage = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HEADERRORMASSAGERF"));
                    wkSupplierSendErResultWork.LineErrorMassage = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LINEERRORMASSAGERF"));
                    wkSupplierSendErResultWork.DataSendCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATASENDCODERF"));
                    wkSupplierSendErResultWork.DataRecoverDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATARECOVERDIVRF"));
                    wkSupplierSendErResultWork.EnterUpdDivSec = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVSECRF"));
                    wkSupplierSendErResultWork.EnterUpdDivBO1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO1RF"));
                    wkSupplierSendErResultWork.EnterUpdDivBO2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO2RF"));
                    wkSupplierSendErResultWork.EnterUpdDivBO3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO3RF"));
                    wkSupplierSendErResultWork.EnterUpdDivMaker = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVMAKERRF"));
                    wkSupplierSendErResultWork.EnterUpdDivEO = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVEORF"));
                    #endregion

                    al.Add(wkSupplierSendErResultWork);

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
                base.WriteErrorLog(ex, "SupplierSendErOrderWorkDB.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="_supplierSendErOrderCndtnWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SupplierSendErOrderCndtnWork _supplierSendErOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = "WHERE" + Environment.NewLine;


            //企業コード
            retstring += " UOD.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_supplierSendErOrderCndtnWork.EnterpriseCode);

            //UOE種別(0:UOE)
            retstring += " AND UOD.UOEKINDRF=0" + Environment.NewLine;

            //拠点コード
            if (_supplierSendErOrderCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _supplierSendErOrderCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND UOD.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            // 送信端末番号
            retstring += "AND UOD.SENDTERMINALNORF !=0" + Environment.NewLine;

            //発注先コード
            if (_supplierSendErOrderCndtnWork.St_UOESupplierCd != 0)
            {
                retstring += " AND UOD.UOESUPPLIERCDRF>=@STUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter paraStUOESupplierCd = sqlCommand.Parameters.Add("@STUOESUPPLIERCD", SqlDbType.Int);
                paraStUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_supplierSendErOrderCndtnWork.St_UOESupplierCd);
            }
            if (_supplierSendErOrderCndtnWork.Ed_UOESupplierCd != 0)
            {
                retstring += " AND UOD.UOESUPPLIERCDRF<=@EDUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter paraEdUOESupplierCd = sqlCommand.Parameters.Add("@EDUOESUPPLIERCD", SqlDbType.Int);
                paraEdUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(_supplierSendErOrderCndtnWork.Ed_UOESupplierCd);
            }

            //受信日付
            if (_supplierSendErOrderCndtnWork.St_ReceiveDate != DateTime.MinValue)
            {
                retstring += " AND UOD.RECEIVEDATERF>=@STRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraStReceiveDate = sqlCommand.Parameters.Add("@STRECEIVEDATE", SqlDbType.Int);
                paraStReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_supplierSendErOrderCndtnWork.St_ReceiveDate);
            }
            if (_supplierSendErOrderCndtnWork.Ed_ReceiveDate != DateTime.MinValue)
            {
                retstring += " AND UOD.RECEIVEDATERF<=@EDRECEIVEDATE" + Environment.NewLine;
                SqlParameter paraEdReceiveDate = sqlCommand.Parameters.Add("@EDRECEIVEDATE", SqlDbType.Int);
                paraEdReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_supplierSendErOrderCndtnWork.Ed_ReceiveDate);
            }

            //送信フラグ
            retstring += " AND (UOD.DATASENDCODERF=1)" + Environment.NewLine;

            //復旧フラグ
            retstring += " AND (UOD.DATARECOVERDIVRF=0)" + Environment.NewLine;

            #endregion
            return retstring;
        }
    }
}

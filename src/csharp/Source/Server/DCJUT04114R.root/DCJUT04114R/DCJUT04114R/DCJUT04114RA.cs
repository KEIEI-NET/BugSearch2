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
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受注残照会DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受注残照会の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 21112　久保田　誠</br>
    /// <br>Date       : 2007.11.15</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 数馬 PM.NS用に修正</br>
    /// <br>Date       : 2008.07.01</br>
    /// <br></br>
    /// <br>Update Note: 22008 長内 数馬 MANTIS 13291</br>
    /// <br>Date       : 2009.05.22</br>
    /// <br>Update Note: 鄧潘ハン</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             照会プログラムのログ出力対応</br>
    /// </remarks>
    [Serializable]
    public class AcptAnOdrRemainRefDB : RemoteDB, IAcptAnOdrRemainRefDB
    {
        /// <summary>
        /// 受注残照会DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.15</br>
        /// </remarks>
        public AcptAnOdrRemainRefDB()
            :
            base("DCJUT04116D", "Broadleaf.Application.Remoting.ParamData.AcptAnOdrRemainRefDataWork", "ACPTANODRREMAINREFDATAWORK")
        {

        }

        #region [Search]
        /// <summary>
        /// 指定された条件の受注残照会情報LISTを戻します
        /// </summary>
        /// <param name="acptanodrremainrefdataList">検索結果</param>
        /// <param name="acptanodrremainrefCndtn">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受注残照会情報LISTを戻します</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.15</br>
        /// <br>Update Note: 鄧潘ハン</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             照会プログラムのログ出力対応</br>
        public int Search(out object acptanodrremainrefdataList, object acptanodrremainrefCndtn, int readMode,ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            acptanodrremainrefdataList = null;
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB(); // ADD 2011/03/22
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null) return status;

                sqlConnection.Open();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((AcptAnOdrRemainRefCndtnWork)acptanodrremainrefCndtn).EnterpriseCode, "受注残照会", "抽出開始");// ADD 2011/03/22
                return SearchProc(out acptanodrremainrefdataList, acptanodrremainrefCndtn, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AcptAnOdrRemainRefDB.Search");
                acptanodrremainrefdataList = new CustomSerializeArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, ((AcptAnOdrRemainRefCndtnWork)acptanodrremainrefCndtn).EnterpriseCode, "受注残照会", "抽出終了");// ADD 2011/03/22
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の受注残照会情報LISTを全て戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acptanodrremainrefdataList">検索結果</param>
        /// <param name="acptanodrremainrefCndtn">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受注残照会情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.15</br>
        public int SearchProc(out object acptanodrremainrefdataList, object acptanodrremainrefCndtn, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            AcptAnOdrRemainRefCndtnWork paramWork = acptanodrremainrefCndtn as AcptAnOdrRemainRefCndtnWork;

            CustomSerializeArrayList dataList = null;

            int status = this.SearchProc(out dataList, paramWork, readMode, logicalMode, ref sqlConnection);

            acptanodrremainrefdataList = (object)dataList;
            return status;
        }

        /// <summary>
        /// 指定された条件の受注残照会情報LISTを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="acptanodrremainrefdataList">検索結果</param>
        /// <param name="acptanodrremainrefCndtn">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件の受注残照会情報LISTを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.15</br>
        public int SearchProc(out CustomSerializeArrayList acptanodrremainrefdataList, AcptAnOdrRemainRefCndtnWork acptanodrremainrefCndtn, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            CustomSerializeArrayList al = new CustomSerializeArrayList();
            try
            {
                # region [SELECT文]
                string sqlText = "";
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   USLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,USLIP.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += "  ,USLIP.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.ACCEPTANORDERNORF" + Environment.NewLine;
                sqlText += "  ,UDTIL.COMMONSEQNORF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SALESSLIPDTLNUMRF" + Environment.NewLine;
                sqlText += "  ,USLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,USLIP.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += "  ,USLIP.SALESEMPLOYEECDRF" + Environment.NewLine;
                sqlText += "  ,USLIP.SALESEMPLOYEENMRF" + Environment.NewLine;
                sqlText += "  ,USLIP.ADDRESSEENAMERF" + Environment.NewLine;
                sqlText += "  ,USLIP.ADDRESSEENAME2RF" + Environment.NewLine;
                sqlText += "  ,USLIP.FRONTEMPLOYEECDRF" + Environment.NewLine;
                sqlText += "  ,USLIP.FRONTEMPLOYEENMRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SALESDATERF" + Environment.NewLine;
                sqlText += "  ,UDTIL.GOODSNORF" + Environment.NewLine;
                sqlText += "  ,UDTIL.GOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,UDTIL.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.MAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,UDTIL.ACCEPTANORDERCNTRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.ACPTANODRREMAINCNTRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SALESUNPRCTAXEXCFLRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.PARTYSLIPNUMDTLRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.STDUNPRCSALUNPRCRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SALESUNITCOSTRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.DTLNOTERF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SUPPLIERSNMRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  ,UDTIL.WAREHOUSENAMERF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SLIPMEMO1RF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SLIPMEMO2RF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SLIPMEMO3RF" + Environment.NewLine;
                sqlText += "  ,UDTIL.INSIDEMEMO1RF" + Environment.NewLine;
                sqlText += "  ,UDTIL.INSIDEMEMO2RF" + Environment.NewLine;
                sqlText += "  ,UDTIL.INSIDEMEMO3RF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SALESSLIPCDDTLRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,UDTIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SHIPMENTCNTRF" + Environment.NewLine;
                sqlText += "  ,ACCAR.CARMNGCODERF" + Environment.NewLine;
                sqlText += "  ,ACCAR.MODELDESIGNATIONNORF" + Environment.NewLine;
                sqlText += "  ,ACCAR.CATEGORYNORF" + Environment.NewLine;
                sqlText += "  ,ACCAR.MODELFULLNAMERF" + Environment.NewLine;
                sqlText += "  ,ACCAR.FULLMODELRF" + Environment.NewLine;
                sqlText += "  ,USLIP.SEARCHSLIPDATERF" + Environment.NewLine;
                sqlText += "  ,USLIP.ADDUPADATERF" + Environment.NewLine;
                sqlText += "  ,USLIP.CLAIMCODERF" + Environment.NewLine;
                sqlText += "  ,USLIP.CLAIMSNMRF" + Environment.NewLine;
                sqlText += "  ,USLIP.RESULTSADDUPSECCDRF" + Environment.NewLine;
                sqlText += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SALESPRICECONSTAXRF" + Environment.NewLine;
                sqlText += "  ,USLIP.SHIPMENTDAYRF" + Environment.NewLine;
                sqlText += "  ,USLIP.SALESINPUTCODERF" + Environment.NewLine;
                sqlText += "  ,USLIP.SALESINPUTNAMERF" + Environment.NewLine;
                sqlText += "  ,USLIP.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += "  ,USLIP.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.TAXATIONDIVCDRF" + Environment.NewLine;
                sqlText += "  ,UDTIL.SALESROWNORF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  SALESSLIPRF AS USLIP" + Environment.NewLine;
                sqlText += "INNER JOIN SALESDETAILRF AS UDTIL" + Environment.NewLine;
                sqlText += "  ON  USLIP.ENTERPRISECODERF = UDTIL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND USLIP.ACPTANODRSTATUSRF = UDTIL.ACPTANODRSTATUSRF" + Environment.NewLine;
                sqlText += "  AND USLIP.SALESSLIPNUMRF = UDTIL.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += "LEFT JOIN ACCEPTODRCARRF AS ACCAR" + Environment.NewLine;
                sqlText += "  ON  ACCAR.ENTERPRISECODERF = UDTIL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND ACCAR.ACCEPTANORDERNORF = UDTIL.ACCEPTANORDERNORF" + Environment.NewLine;
                sqlText += "  AND ACCAR.ACPTANODRSTATUSRF = 3" + Environment.NewLine;
                sqlText += "  AND ACCAR.DATAINPUTSYSTEMRF = 10" + Environment.NewLine;
                sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlText += "  ON  SEC.ENTERPRISECODERF = USLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND SEC.SECTIONCODERF = USLIP.RESULTSADDUPSECCDRF" + Environment.NewLine;
                # endregion
                
                # region [可変絞り込み条件] 
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  USLIP.ACPTANODRSTATUSRF = 20" + Environment.NewLine;
                sqlText += "  AND USLIP.DEBITNOTEDIVRF = 0" + Environment.NewLine;
                sqlText += "  AND USLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                
                // 企業コード
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acptanodrremainrefCndtn.EnterpriseCode);

                // 論理削除区分
                string wkstring = "";

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring  = "  AND USLIP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                         (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring  = "  AND USLIP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                }

                if(wkstring != "")
                {
                    sqlText += wkstring;
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                
                // 拠点コード
                if (!string.IsNullOrEmpty(acptanodrremainrefCndtn.SectionCode))
                {
                    sqlText += "  AND USLIP.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(acptanodrremainrefCndtn.SectionCode);
                }
                
                // 得意先コード
                if (acptanodrremainrefCndtn.CustomerCode > 0)
                {
                    sqlText += "  AND USLIP.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(acptanodrremainrefCndtn.CustomerCode);
                }

                // 請求先コード
                if (acptanodrremainrefCndtn.ClaimCode > 0)
                {
                    sqlText += "  AND USLIP.CLAIMCODERF = @FINDCLAIMCODE" + Environment.NewLine;
                    SqlParameter findClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                    findClaimCode.Value = SqlDataMediator.SqlSetInt32(acptanodrremainrefCndtn.ClaimCode);
                }

                // 受注状況
                // 2009/05/22 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>.
                //if (acptanodrremainrefCndtn.AcpOdrStateDiv == 1)
                //{
                //    // 計上済み(一部入荷を含む) … 受注数(受注数＋調整数) ≠ 受注残数
                //    sqlText += "  AND ((UDTIL.ACCEPTANORDERCNTRF + UDTIL.ACPTANODRADJUSTCNTRF) != UDTIL.ACPTANODRREMAINCNTRF)" + Environment.NewLine;
                //}
                //else if (acptanodrremainrefCndtn.AcpOdrStateDiv == 2)
                //{
                //    // 未入荷のみ … 受注数(受注数＋調整数) ＝ 受注残数
                //    sqlText += "  AND ((UDTIL.ACCEPTANORDERCNTRF + UDTIL.ACPTANODRADJUSTCNTRF) = UDTIL.ACPTANODRREMAINCNTRF)" + Environment.NewLine;
                //}

                if (acptanodrremainrefCndtn.AcpOdrStateDiv == 1)
                {
                    // 計上済み …  受注残数＝０
                    sqlText += "  AND UDTIL.ACPTANODRREMAINCNTRF = 0" + Environment.NewLine;
                }
                else if (acptanodrremainrefCndtn.AcpOdrStateDiv == 2)
                {
                    // 未計上のみ（一部計上を含む） … 受注残数＞０
                    sqlText += "  AND UDTIL.ACPTANODRREMAINCNTRF > 0" + Environment.NewLine;
                }
                // 2009/05/22 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                
                // 入力日付(開始)
                if (acptanodrremainrefCndtn.St_SearchSlipDate > DateTime.MinValue)
                {
                    sqlText += "  AND USLIP.SEARCHSLIPDATERF >= @FINDST_SEARCHSLIPDATE" + Environment.NewLine;
                    SqlParameter findSt_SearchSlipDate = sqlCommand.Parameters.Add("@FINDST_SEARCHSLIPDATE", SqlDbType.Int);
                    findSt_SearchSlipDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(acptanodrremainrefCndtn.St_SearchSlipDate);
                }

                // 入力日付(終了)
                if (acptanodrremainrefCndtn.Ed_SearchSlipDate > DateTime.MinValue)
                {
                    sqlText += "  AND USLIP.SEARCHSLIPDATERF <= @FINDED_SEARCHSLIPDATE" + Environment.NewLine;
                    SqlParameter findEd_SearchSlipDate = sqlCommand.Parameters.Add("@FINDED_SEARCHSLIPDATE", SqlDbType.Int);
                    findEd_SearchSlipDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(acptanodrremainrefCndtn.Ed_SearchSlipDate);
                }

                // 売上日付(開始)
                if (acptanodrremainrefCndtn.St_SalesDate > DateTime.MinValue)
                {
                    sqlText += "  AND UDTIL.SALESDATERF >= @FINDST_SALESDATE" + Environment.NewLine;
                    SqlParameter findSt_SalesDate = sqlCommand.Parameters.Add("@FINDST_SALESDATE", SqlDbType.Int);
                    findSt_SalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(acptanodrremainrefCndtn.St_SalesDate);
                }

                // 売上日付(終了)
                if (acptanodrremainrefCndtn.Ed_SalesDate > DateTime.MinValue)
                {
                    sqlText += "  AND UDTIL.SALESDATERF <= @FINDED_SALESDATE" + Environment.NewLine;
                    SqlParameter findEd_SalesDate = sqlCommand.Parameters.Add("@FINDED_SALESDATE", SqlDbType.Int);
                    findEd_SalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(acptanodrremainrefCndtn.Ed_SalesDate);
                }

                // 伝票番号(開始)
                if (!string.IsNullOrEmpty(acptanodrremainrefCndtn.St_SalesSlipNum))
                {
                    sqlText += "  AND USLIP.SALESSLIPNUMRF >= @FINDST_SALESSLIPNUM" + Environment.NewLine;
                    SqlParameter findSt_SalesSlipNum = sqlCommand.Parameters.Add("@FINDST_SALESSLIPNUM", SqlDbType.NChar);
                    findSt_SalesSlipNum.Value = SqlDataMediator.SqlSetString(acptanodrremainrefCndtn.St_SalesSlipNum);
                }

                // 伝票番号(終了)
                if (!string.IsNullOrEmpty(acptanodrremainrefCndtn.Ed_SalesSlipNum))
                {
                    sqlText += "  AND USLIP.SALESSLIPNUMRF <= @FINDED_SALESSLIPNUM" + Environment.NewLine;
                    SqlParameter findEd_SalesSlipNum = sqlCommand.Parameters.Add("@FINDED_SALESSLIPNUM", SqlDbType.NChar);
                    findEd_SalesSlipNum.Value = SqlDataMediator.SqlSetString(acptanodrremainrefCndtn.Ed_SalesSlipNum);
                }

                // 売上入力者コード
                if (!string.IsNullOrEmpty(acptanodrremainrefCndtn.SalesInputCode))
                {
                    sqlText += "  AND USLIP.SALESINPUTCODERF = @FINDSALESINPUTCODE" + Environment.NewLine;
                    SqlParameter findSalesInputCode = sqlCommand.Parameters.Add("@FINDSALESINPUTCODE", SqlDbType.NChar);
                    findSalesInputCode.Value = SqlDataMediator.SqlSetString(acptanodrremainrefCndtn.SalesInputCode);
                }

                // 受付従業員コード
                if (!string.IsNullOrEmpty(acptanodrremainrefCndtn.FrontEmployeeCd))
                {
                    sqlText += "  AND USLIP.FRONTEMPLOYEECDRF = @FINDFRONTEMPLOYEECD" + Environment.NewLine;
                    SqlParameter findFrontEmployeeCd = sqlCommand.Parameters.Add("@FINDFRONTEMPLOYEECD", SqlDbType.NChar);
                    findFrontEmployeeCd.Value = SqlDataMediator.SqlSetString(acptanodrremainrefCndtn.FrontEmployeeCd);
                }
                
                // 販売従業員コード
                if (!string.IsNullOrEmpty(acptanodrremainrefCndtn.SalesEmployeeCd))
                {
                    sqlText += "  AND USLIP.SALESEMPLOYEECDRF = @FINDSALESEMPLOYEECD" + Environment.NewLine;
                    SqlParameter findSalesEmployeeCd = sqlCommand.Parameters.Add("@FINDSALESEMPLOYEECD", SqlDbType.NChar);
                    findSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(acptanodrremainrefCndtn.SalesEmployeeCd);
                }

                // 商品メーカーコード
                if (acptanodrremainrefCndtn.GoodsMakerCd > 0)
                {
                    sqlText += "  AND UDTIL.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;  
                    SqlParameter findGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(acptanodrremainrefCndtn.GoodsMakerCd);
                }

                //品番
                if (string.IsNullOrEmpty(acptanodrremainrefCndtn.GoodsNo) == false)
                {
                    sqlText += "AND UDTIL.GOODSNORF LIKE @FINDGOODSNO" + Environment.NewLine;
                    SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    //前方一致検索の場合
                    if (acptanodrremainrefCndtn.GoodsNoSrchTyp == 1) acptanodrremainrefCndtn.GoodsNo = acptanodrremainrefCndtn.GoodsNo + "%";
                    //後方一致検索の場合
                    if (acptanodrremainrefCndtn.GoodsNoSrchTyp == 2) acptanodrremainrefCndtn.GoodsNo = "%" + acptanodrremainrefCndtn.GoodsNo;
                    //曖昧検索の場合
                    if (acptanodrremainrefCndtn.GoodsNoSrchTyp == 3) acptanodrremainrefCndtn.GoodsNo = "%" + acptanodrremainrefCndtn.GoodsNo + "%";

                    paraGoodsNo.Value = SqlDataMediator.SqlSetString(acptanodrremainrefCndtn.GoodsNo);
                }

                //品名
                if (string.IsNullOrEmpty(acptanodrremainrefCndtn.GoodsName) == false)
                {
                    sqlText += "AND UDTIL.GOODSNAMERF LIKE @FINDGOODSNAME" + Environment.NewLine;
                    SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@FINDGOODSNAME", SqlDbType.NVarChar);
                    //前方一致検索の場合
                    if (acptanodrremainrefCndtn.GoodsNameSrchTyp == 1) acptanodrremainrefCndtn.GoodsName = acptanodrremainrefCndtn.GoodsName + "%";
                    //後方一致検索の場合
                    if (acptanodrremainrefCndtn.GoodsNameSrchTyp == 2) acptanodrremainrefCndtn.GoodsName = "%" + acptanodrremainrefCndtn.GoodsName;
                    //曖昧検索の場合
                    if (acptanodrremainrefCndtn.GoodsNameSrchTyp == 3) acptanodrremainrefCndtn.GoodsName = "%" + acptanodrremainrefCndtn.GoodsName + "%";

                    paraGoodsName.Value = SqlDataMediator.SqlSetString(acptanodrremainrefCndtn.GoodsName);
                }

                //型式
                if (string.IsNullOrEmpty(acptanodrremainrefCndtn.FullModel) == false)
                {
                    sqlText += "  AND ACCAR.FULLMODELRF LIKE @FINDFULLMODEL" + Environment.NewLine;
                    SqlParameter paraFullModel = sqlCommand.Parameters.Add("@FINDFULLMODEL", SqlDbType.NVarChar);
                    //前方一致検索の場合
                    if (acptanodrremainrefCndtn.FullModelSrchTyp == 1) acptanodrremainrefCndtn.FullModel = acptanodrremainrefCndtn.FullModel + "%";
                    //後方一致検索の場合
                    if (acptanodrremainrefCndtn.FullModelSrchTyp == 2) acptanodrremainrefCndtn.FullModel = "%" + acptanodrremainrefCndtn.FullModel;
                    //曖昧検索の場合
                    if (acptanodrremainrefCndtn.FullModelSrchTyp == 3) acptanodrremainrefCndtn.FullModel = "%" + acptanodrremainrefCndtn.FullModel + "%";

                    paraFullModel.Value = SqlDataMediator.SqlSetString(acptanodrremainrefCndtn.FullModel);
                }


                # endregion

                # region [並び順]
                sqlText += "ORDER BY" + Environment.NewLine;
                sqlText += "  UDTIL.SALESDATERF" + Environment.NewLine;
                sqlText += " ,USLIP.SALESSLIPNUMRF" + Environment.NewLine;
                sqlText += " ,UDTIL.COMMONSEQNORF" + Environment.NewLine;
                # endregion

                sqlCommand.CommandText = sqlText;

#region DEB
#if DEBUG
                Console.Clear();
                Console.WriteLine("--- 変数 ---");

                foreach (SqlParameter param in sqlCommand.Parameters)
                {
                    string sqlDbType = param.SqlDbType.ToString();
                    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                    {
                        sqlDbType += string.Format("({0})", param.Value.ToString().Length);
                    }

                    string value = param.Value.ToString();
                    if (param.SqlDbType == SqlDbType.Char || param.SqlDbType == SqlDbType.VarChar || param.SqlDbType == SqlDbType.NChar || param.SqlDbType == SqlDbType.NVarChar)
                    {
                        value = string.Format("'{0}'", param.Value);
                    }

                    Console.WriteLine(string.Format("DECLARE {0} {1}", param.ParameterName, sqlDbType));
                    Console.WriteLine(string.Format("SET {0} = {1}", param.ParameterName, value));
                    Console.WriteLine("");
                }

                Console.WriteLine("--- SQL ---");
                Console.WriteLine(sqlText);
#endif
#endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(this.CopyToAcptAnOdrRemainRefDataWorkFromReader(ref myReader));
                }

                if (al.Count > 0)
                {
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

            acptanodrremainrefdataList = al;

            return status;
        }
        #endregion

        #region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → AcptAnOdrRemainRefDataWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AcptAnOdrRemainRefDataWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.15</br>
        /// </remarks>
        private AcptAnOdrRemainRefDataWork CopyToAcptAnOdrRemainRefDataWorkFromReader(ref SqlDataReader myReader)
        {
            AcptAnOdrRemainRefDataWork retWork = new AcptAnOdrRemainRefDataWork();

            #region クラスへ格納
            retWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            retWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            retWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            retWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            retWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            retWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
            retWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            retWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            retWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
            retWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
            retWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
            retWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
            retWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
            retWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
            retWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            retWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            retWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            retWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            retWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            retWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
            retWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));
            retWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
            retWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
            retWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
            retWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
            retWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
            retWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
            retWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            retWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            retWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            retWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
            retWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
            retWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
            retWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
            retWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
            retWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
            retWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
            retWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
            retWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
            retWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            retWork.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF"));
            retWork.ModelDesignationNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MODELDESIGNATIONNORF"));
            retWork.CategoryNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYNORF"));
            retWork.ModelFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MODELFULLNAMERF"));
            retWork.FullModel = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FULLMODELRF"));
            retWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
            retWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
            retWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            retWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            retWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
            retWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            retWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
            retWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
            retWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
            retWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
            retWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
            retWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
            retWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
            retWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));

            #endregion

            return retWork;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21112　久保田　誠</br>
        /// <br>Date       : 2007.11.15</br>
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

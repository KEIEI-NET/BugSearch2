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
    /// ������e���͕\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������e���͕\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.05</br>
    /// <br></br>
    /// <br>Update Note: �d�b�Ή�No.1016 �����Ń^�C���A�E�g��������������C��</br>
    ///                  ������������������������Ă��Ȃ������C��</br>
    ///                  READUNCOMMITTED�̑Ή�</br>
    /// <br>Programmer : 20008 Y.Ito</br>
    /// <br>Date       : 2012.06.14</br>
    /// </remarks>
    [Serializable]
    public class SalesHistAnalyzeResultWorkDB : RemoteDB, ISalesHistAnalyzeResultWorkDB
    {
        /// <summary>
        /// ������e���͕\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.05</br>
        /// </remarks>
        public SalesHistAnalyzeResultWorkDB()
            :
        base("PMHNB02169D", "Broadleaf.Application.Remoting.ParamData.SalesHistAnalyzeResultWork", "SALESHISTDTLRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region ������e���͕\
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔�����e���͕\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="customInqResultWork">��������</param>
        /// <param name="customInqOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔�����e���͕\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.05</br>
        public int Search(out object salesHistAnalyzeResultList, object salesHistAnalyzeCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            salesHistAnalyzeResultList = null;

            SalesHistAnalyzeCndtnWork _salesHistAnalyzeCndtnWork = salesHistAnalyzeCndtnWork as SalesHistAnalyzeCndtnWork;

            try
            {
                status = SearchProc(out salesHistAnalyzeResultList, _salesHistAnalyzeCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesHistAnalyzeResultWorkDB.Search Exception=" + ex.Message);
                salesHistAnalyzeResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔�����e���͕\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="salesHistAnalyzeResultList">��������</param>
        /// <param name="_salesHistAnalyzeCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔�����e���͕\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.05</br>
        private int SearchProc(out object salesHistAnalyzeResultList, SalesHistAnalyzeCndtnWork _salesHistAnalyzeCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            salesHistAnalyzeResultList = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                status = SearchOrderProc(ref al, ref sqlConnection, _salesHistAnalyzeCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesHistAnalyzeResultWorkDB.SearchProc Exception=" + ex.Message);
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

            salesHistAnalyzeResultList = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_salesHistAnalyzeCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SalesHistAnalyzeCndtnWork _salesHistAnalyzeCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt="";

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // 2012.06.14 Y.Ito ADD START �d�b�Ή�No.1016
                sqlCommand.CommandTimeout = 3600;
                // 2012.06.14 Y.Ito ADD END �d�b�Ή�No.1016

                selectTxt = "";

                sqlCommand.Parameters.Clear();
                //SELECT���쐬
                selectTxt += MakeSelectString(ref sqlCommand, _salesHistAnalyzeCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SalesHistAnalyzeResultWork wkSalesHistAnalyzeResultWork = new SalesHistAnalyzeResultWork();
                    //�i�[����
                    wkSalesHistAnalyzeResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkSalesHistAnalyzeResultWork.SecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkSalesHistAnalyzeResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));

                    wkSalesHistAnalyzeResultWork.SalesMoneyOrder = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYORDER"));
                    wkSalesHistAnalyzeResultWork.SalesMoneyStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYSTOCK"));
                    wkSalesHistAnalyzeResultWork.SalesMoneyGenuine = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYGENUINE"));
                    wkSalesHistAnalyzeResultWork.SalesMoneyPrm = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYPRM"));
                    wkSalesHistAnalyzeResultWork.SalesMoneyOutside = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYOUTSIDE"));
                    wkSalesHistAnalyzeResultWork.SalesMoneyOther = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYOTHER"));

                    wkSalesHistAnalyzeResultWork.GrossProfitOrder = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITORDER"));
                    wkSalesHistAnalyzeResultWork.GrossProfitStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITSTOCK"));
                    wkSalesHistAnalyzeResultWork.GrossProfitGenuine = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITGENUINE"));
                    wkSalesHistAnalyzeResultWork.GrossProfitPrm = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITPRM"));
                    wkSalesHistAnalyzeResultWork.GrossProfitOutside = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITOUTSIDE"));
                    wkSalesHistAnalyzeResultWork.GrossProfitOther = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITOTHER"));

                    wkSalesHistAnalyzeResultWork.MonthSalesMoneyOrder = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEYORDER"));
                    wkSalesHistAnalyzeResultWork.MonthSalesMoneyStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEYSTOCK"));
                    wkSalesHistAnalyzeResultWork.MonthSalesMoneyGenuine = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEYGENUINE"));
                    wkSalesHistAnalyzeResultWork.MonthSalesMoneyPrm = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEYPRM"));
                    wkSalesHistAnalyzeResultWork.MonthSalesMoneyOutside = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEYOUTSIDE"));
                    wkSalesHistAnalyzeResultWork.MonthSalesMoneyOther = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEYOTHER"));

                    wkSalesHistAnalyzeResultWork.MonthGrossProfitOrder = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFITORDER"));
                    wkSalesHistAnalyzeResultWork.MonthGrossProfitStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFITSTOCK"));
                    wkSalesHistAnalyzeResultWork.MonthGrossProfitGenuine = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFITGENUINE"));
                    wkSalesHistAnalyzeResultWork.MonthGrossProfitPrm = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFITPRM"));
                    wkSalesHistAnalyzeResultWork.MonthGrossProfitOutside = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFITOUTSIDE"));
                    wkSalesHistAnalyzeResultWork.MonthGrossProfitOther = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHGROSSPROFITOTHER"));


                    switch (_salesHistAnalyzeCndtnWork.PrintDiv)
                    {
                        case 0://���Ӑ�
                            {
                                wkSalesHistAnalyzeResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                                wkSalesHistAnalyzeResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                                break;
                            }
                        case 1://�S����
                            {
                                wkSalesHistAnalyzeResultWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                                wkSalesHistAnalyzeResultWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                                break;
                            }
                        case 2://�n��
                            {
                                wkSalesHistAnalyzeResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                                wkSalesHistAnalyzeResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                                break;
                            }
                    }
                    #endregion

                    al.Add(wkSalesHistAnalyzeResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
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

        #region SELECT������
        /// <summary>
        /// ���s�^�C�v�ʂ�SELECT�����쐬
        /// </summary>
        /// <param name="printDiv">���s�^�C�v</param>
        /// <returns>SELECT��</returns>
        private string MakeSelectString(ref SqlCommand sqlCommand, SalesHistAnalyzeCndtnWork _salesHistAnalyzeCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int printDiv = _salesHistAnalyzeCndtnWork.PrintDiv;

            string codeId = string.Empty;
            string nameId = string.Empty;
            string tblnm1  = string.Empty;
            string tblnm2  = string.Empty;
            switch (printDiv)
            {
                case 0://���Ӑ�
                    {
                        codeId = "CUSTOMERCODERF";
                        nameId = "CUSTOMERSNMRF";
                        tblnm1 = "SALES.";
                        tblnm2 = "CUST.";
                        break;
                    }
                case 1://�S����
                    {
                        codeId = "SALESEMPLOYEECDRF";
                        nameId = "NAMERF";
                        tblnm1 = "SALES.";
                        tblnm2 = "EMP.";
                        break;
                    }
                case 2://�n��
                    {
                        codeId = "SALESAREACODERF";
                        nameId = "GUIDENAMERF";
                        tblnm1 = "CUST.";
                        tblnm2 = "USERGD.";
                        break;
                    }
            }

            string retString = string.Empty;
            if (retString == "")
            {
                retString += "SELECT" + Environment.NewLine;
                retString += "SALESDAY.ENTERPRISECODERF," + Environment.NewLine;
                retString += "SALESDAY.SECTIONCODERF," + Environment.NewLine;
                retString += "SALESDAY.SECTIONGUIDESNMRF," + Environment.NewLine;
                retString += "SALESDAY."+ codeId +"," + Environment.NewLine;
                retString += "SALESDAY."+ nameId +"," + Environment.NewLine;
                retString += "SALESDAY.SALESMONEYORDER," + Environment.NewLine;
                retString += "SALESDAY.SALESMONEYSTOCK," + Environment.NewLine;
                retString += "SALESDAY.SALESMONEYGENUINE," + Environment.NewLine;
                retString += "SALESDAY.SALESMONEYPRM," + Environment.NewLine;
                retString += "SALESDAY.SALESMONEYOUTSIDE," + Environment.NewLine;
                retString += "SALESDAY.SALESMONEYOTHER," + Environment.NewLine;

                retString += "SALESDAY.GROSSPROFITORDER," + Environment.NewLine;
                retString += "SALESDAY.GROSSPROFITSTOCK," + Environment.NewLine;
                retString += "SALESDAY.GROSSPROFITGENUINE," + Environment.NewLine;
                retString += "SALESDAY.GROSSPROFITPRM," + Environment.NewLine;
                retString += "SALESDAY.GROSSPROFITOUTSIDE," + Environment.NewLine;
                retString += "SALESDAY.GROSSPROFITOTHER," + Environment.NewLine;
                retString += "SALESMONTH.MONTHSALESMONEYORDER," + Environment.NewLine;
                retString += "SALESMONTH.MONTHSALESMONEYSTOCK," + Environment.NewLine;
                retString += "SALESMONTH.MONTHSALESMONEYGENUINE," + Environment.NewLine;
                retString += "SALESMONTH.MONTHSALESMONEYPRM," + Environment.NewLine;
                retString += "SALESMONTH.MONTHSALESMONEYOUTSIDE," + Environment.NewLine;
                retString += "SALESMONTH.MONTHSALESMONEYOTHER," + Environment.NewLine;
                retString += "SALESMONTH.MONTHGROSSPROFITORDER," + Environment.NewLine;
                retString += "SALESMONTH.MONTHGROSSPROFITSTOCK," + Environment.NewLine;
                retString += "SALESMONTH.MONTHGROSSPROFITGENUINE," + Environment.NewLine;
                retString += "SALESMONTH.MONTHGROSSPROFITPRM," + Environment.NewLine;
                retString += "SALESMONTH.MONTHGROSSPROFITOUTSIDE," + Environment.NewLine;
                retString += "SALESMONTH.MONTHGROSSPROFITOTHER" + Environment.NewLine;
                retString += "FROM" + Environment.NewLine;
                retString += "(" + Environment.NewLine;

                #region ���v�W�v
                retString += "SELECT" + Environment.NewLine;
                retString += " SALESHIS.ENTERPRISECODERF" + Environment.NewLine;
                retString += " ,SALESHIS.SECTIONCODERF" + Environment.NewLine;
                retString += " ,SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
                retString += " ,SALESHIS." + codeId + Environment.NewLine;
                retString += " ,SALESHIS." + nameId + Environment.NewLine;
                retString += " ,SALESMONEYORDER" + Environment.NewLine;
                retString += " ,SALESMONEYSTOCK" + Environment.NewLine;
                retString += " ,SALESMONEYGENUINE" + Environment.NewLine;
                retString += " ,SALESMONEYPRM" + Environment.NewLine;
                retString += " ,SALESMONEYOUTSIDE" + Environment.NewLine;
                retString += " ,SALESMONEYOTHER" + Environment.NewLine;
                // �e�����z
                retString += " ,GROSSPROFITORDER" + Environment.NewLine;
                retString += " ,GROSSPROFITSTOCK" + Environment.NewLine;
                retString += " ,GROSSPROFITGENUINE" + Environment.NewLine;
                retString += " ,GROSSPROFITPRM" + Environment.NewLine;
                retString += " ,GROSSPROFITOUTSIDE" + Environment.NewLine;
                retString += " ,GROSSPROFITOTHER" + Environment.NewLine;

                retString += "FROM" + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "	SUBSALESHIS.ENTERPRISECODERF," + Environment.NewLine;
                retString += "	SUBSALESHIS.SECTIONCODERF," + Environment.NewLine;
                retString += "	SUBSALESHIS." + codeId +","+ Environment.NewLine;
                retString += "	SUBSALESHIS." + nameId +","+ Environment.NewLine;
                // ������z
                retString += "	SUM(SALESMONEYORDER + RETGOODSANDDISCOUNTPRICEORDER) AS SALESMONEYORDER," + Environment.NewLine;
                retString += "	SUM(SALESMONEYSTOCK + RETGOODSANDDISCOUNTPRICESTOCK) AS SALESMONEYSTOCK," + Environment.NewLine;
                retString += "	SUM(SALESMONEYGENUINE + RETGOODSANDDISCOUNTPRICEGENUINE) AS SALESMONEYGENUINE," + Environment.NewLine;
                retString += "	SUM(SALESMONEYPRM + RETGOODSANDDISCOUNTPRICEPRM) AS SALESMONEYPRM," + Environment.NewLine;
                retString += "	SUM(SALESMONEYOUTSIDE + RETGOODSANDDISCOUNTPRICEOUTSIDE) AS SALESMONEYOUTSIDE," + Environment.NewLine;
                retString += "	SUM(SALESMONEYOTHER + RETGOODSANDDISCOUNTPRICEOTHER) AS SALESMONEYOTHER," + Environment.NewLine;
                // �e�����z               
                retString += "	SUM(SALESMONEYORDER + RETGOODSANDDISCOUNTPRICEORDER - GROSSPROFITORDER +  RETGROSSPROFITORDER) AS GROSSPROFITORDER," + Environment.NewLine;
                retString += "	SUM(SALESMONEYSTOCK + RETGOODSANDDISCOUNTPRICESTOCK - GROSSPROFITSTOCK + RETGROSSPROFITSTOCK) AS GROSSPROFITSTOCK," + Environment.NewLine;
                retString += "	SUM(SALESMONEYGENUINE + RETGOODSANDDISCOUNTPRICEGENUINE - GROSSPROFITGENUINE + RETGROSSPROFITGENUINE) AS GROSSPROFITGENUINE," + Environment.NewLine;
                retString += "	SUM(SALESMONEYPRM + RETGOODSANDDISCOUNTPRICEPRM - GROSSPROFITPRM + RETGROSSPROFITPRM) AS GROSSPROFITPRM," + Environment.NewLine;
                retString += "	SUM(SALESMONEYOUTSIDE + RETGOODSANDDISCOUNTPRICEOUTSIDE - GROSSPROFITOUTSIDE + RETGROSSPROFITOUTSIDE) AS GROSSPROFITOUTSIDE," + Environment.NewLine;
                retString += "	SUM(SALESMONEYOTHER + RETGOODSANDDISCOUNTPRICEOTHER - GROSSPROFITOTHER + RETGROSSPROFITOTHER) AS GROSSPROFITOTHER" + Environment.NewLine;


                retString += "  " + Environment.NewLine;
                retString += "	FROM" + Environment.NewLine;
                retString += "	(" + Environment.NewLine;
                retString += "		SELECT" + Environment.NewLine;
                retString += "		SALESDTL.ENTERPRISECODERF," + Environment.NewLine;
                retString += "		SALES.RESULTSADDUPSECCDRF AS SECTIONCODERF," + Environment.NewLine;
                retString += tblnm1 + codeId + "," + Environment.NewLine;
                retString += tblnm2 + nameId + "," + Environment.NewLine;
                // ������z
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 0)  THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYORDER," + Environment.NewLine;
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 0) THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYSTOCK," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF = 0 AND SALESSLIPCDDTLRF = 0) THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYGENUINE," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF = 1 AND SALESSLIPCDDTLRF = 0) THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYPRM," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 ) OR GOODSMGROUPRF =3000 ) AND SALESSLIPCDDTLRF = 0) THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYOUTSIDE," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND GOODSMGROUPRF !=3000 ) AND SALESSLIPCDDTLRF = 0) THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYOTHER," + Environment.NewLine;
                // �ԕi�{�l����
		        retString += "		CASE WHEN (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 1 ) OR (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICEORDER," + Environment.NewLine;
		        retString += "		CASE WHEN (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 1 ) OR (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICESTOCK," + Environment.NewLine;
		        retString += "		CASE WHEN (GOODSKINDCODERF   = 0 AND SALESSLIPCDDTLRF = 1 ) OR (GOODSKINDCODERF   = 0 AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICEGENUINE," + Environment.NewLine;
		        retString += "		CASE WHEN (GOODSKINDCODERF   = 1 AND SALESSLIPCDDTLRF = 1 ) OR (GOODSKINDCODERF   = 1 AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICEPRM," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 ) OR GOODSMGROUPRF =3000 ) AND SALESSLIPCDDTLRF = 1 ) OR ((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 ) AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICEOUTSIDE," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND GOODSMGROUPRF !=3000 ) AND SALESSLIPCDDTLRF = 1 ) OR ((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICEOTHER," + Environment.NewLine;
                // ����(�e���v�Z�p)
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 0) THEN COSTRF ELSE 0 END  AS GROSSPROFITORDER," + Environment.NewLine;
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 0) THEN COSTRF ELSE 0 END  AS GROSSPROFITSTOCK," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF = 0 AND SALESSLIPCDDTLRF = 0)  THEN COSTRF ELSE 0 END  AS GROSSPROFITGENUINE," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF = 1 AND SALESSLIPCDDTLRF = 0)  THEN COSTRF ELSE 0 END  AS GROSSPROFITPRM," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 ) OR GOODSMGROUPRF =3000 ) AND SALESSLIPCDDTLRF = 0) THEN COSTRF ELSE 0 END  AS GROSSPROFITOUTSIDE," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND GOODSMGROUPRF !=3000 ) AND SALESSLIPCDDTLRF = 0) THEN COSTRF ELSE 0 END  AS GROSSPROFITOTHER," + Environment.NewLine;
                // ����(�e���v�Z�p)�ԕi�{�l����
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 1 ) OR (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITORDER," + Environment.NewLine;
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 1 ) OR (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITSTOCK," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF   = 0 AND SALESSLIPCDDTLRF = 1 ) OR (GOODSKINDCODERF   = 0 AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITGENUINE," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF   = 1 AND SALESSLIPCDDTLRF = 1 ) OR (GOODSKINDCODERF   = 1 AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITPRM," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 )  OR GOODSMGROUPRF =3000 ) AND SALESSLIPCDDTLRF = 1 ) OR ((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 ) AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITOUTSIDE," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND GOODSMGROUPRF !=3000 ) AND SALESSLIPCDDTLRF = 1 ) OR ((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITOTHER" + Environment.NewLine;


                retString += "		FROM" + Environment.NewLine;
                retString += "		SALESHISTDTLRF AS  SALESDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                retString += "		LEFT JOIN SALESHISTORYRF  AS SALES WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                retString += "			SALES.ENTERPRISECODERF =  SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                retString += "		AND SALES.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                retString += "		AND SALES.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine;
                retString += "		LEFT JOIN CUSTOMERRF AS CUST WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                retString += "			SALES.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;
                retString += "			AND SALES.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;
                retString += "		LEFT JOIN EMPLOYEERF AS EMP WITH (READUNCOMMITTED) ON    " + Environment.NewLine;
                retString += "			SALES.ENTERPRISECODERF = EMP.ENTERPRISECODERF" + Environment.NewLine;
                retString += "			AND SALES.SALESEMPLOYEECDRF = EMP.EMPLOYEECODERF    " + Environment.NewLine;
                retString += "		LEFT JOIN USERGDBDURF AS USERGD WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                retString += "			SALES.ENTERPRISECODERF = USERGD.ENTERPRISECODERF" + Environment.NewLine;
                retString += "			AND USERGD.USERGUIDEDIVCDRF = 21" + Environment.NewLine;
                retString += "			AND CUST.SALESAREACODERF = USERGD.GUIDECODERF" + Environment.NewLine;

                // WHERE
                retString += MakeWhereString(ref sqlCommand, _salesHistAnalyzeCndtnWork, logicalMode,0);
                retString += "	) AS SUBSALESHIS" + Environment.NewLine;
                retString += MakeGroupByString(printDiv);

                retString += ") AS SALESHIS" + Environment.NewLine;
                retString += "LEFT JOIN SECINFOSETRF AS SECINF WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                retString += "	SECINF.ENTERPRISECODERF = SALESHIS.ENTERPRISECODERF" + Environment.NewLine;
                retString += "	AND SECINF.SECTIONCODERF = SALESHIS.SECTIONCODERF" + Environment.NewLine;
                retString += "	) AS SALESDAY" + Environment.NewLine;
                #endregion

                #region �݌v�W�v
                retString += " LEFT JOIN (" + Environment.NewLine;
                retString += "SELECT" + Environment.NewLine;
                retString += " SALESHIS.ENTERPRISECODERF" + Environment.NewLine;
                retString += " ,SALESHIS.SECTIONCODERF" + Environment.NewLine;
                // 2012.06.14 Y.Ito DEL START �d�b�Ή�No.1016
                //retString += " ,SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
                // 2012.06.14 Y.Ito DEL END �d�b�Ή�No.1016
                retString += " ,SALESHIS." + codeId + Environment.NewLine;
                retString += " ,SALESHIS." + nameId + Environment.NewLine;
                retString += " ,MONTHSALESMONEYORDER" + Environment.NewLine;
                retString += " ,MONTHSALESMONEYSTOCK" + Environment.NewLine;
                retString += " ,MONTHSALESMONEYGENUINE" + Environment.NewLine;
                retString += " ,MONTHSALESMONEYPRM" + Environment.NewLine;
                retString += " ,MONTHSALESMONEYOUTSIDE" + Environment.NewLine;
                retString += " ,MONTHSALESMONEYOTHER" + Environment.NewLine;
                retString += " ,MONTHGROSSPROFITORDER" + Environment.NewLine;
                retString += " ,MONTHGROSSPROFITSTOCK" + Environment.NewLine;
                retString += " ,MONTHGROSSPROFITGENUINE" + Environment.NewLine;
                retString += " ,MONTHGROSSPROFITPRM" + Environment.NewLine;
                retString += " ,MONTHGROSSPROFITOUTSIDE" + Environment.NewLine;
                retString += " ,MONTHGROSSPROFITOTHER" + Environment.NewLine;

                retString += "FROM" + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "	SUBSALESHIS.ENTERPRISECODERF," + Environment.NewLine;
                retString += "	SUBSALESHIS.SECTIONCODERF," + Environment.NewLine;
                retString += "	SUBSALESHIS." + codeId + "," + Environment.NewLine;
                retString += "	SUBSALESHIS." + nameId + "," + Environment.NewLine;
                // ������z
                retString += "	SUM(SALESMONEYORDER + RETGOODSANDDISCOUNTPRICEORDER) AS MONTHSALESMONEYORDER," + Environment.NewLine;
                retString += "	SUM(SALESMONEYSTOCK + RETGOODSANDDISCOUNTPRICESTOCK) AS MONTHSALESMONEYSTOCK," + Environment.NewLine;
                retString += "	SUM(SALESMONEYGENUINE + RETGOODSANDDISCOUNTPRICEGENUINE) AS MONTHSALESMONEYGENUINE," + Environment.NewLine;
                retString += "	SUM(SALESMONEYPRM + RETGOODSANDDISCOUNTPRICEPRM) AS MONTHSALESMONEYPRM," + Environment.NewLine;
                retString += "	SUM(SALESMONEYOUTSIDE + RETGOODSANDDISCOUNTPRICEOUTSIDE) AS MONTHSALESMONEYOUTSIDE," + Environment.NewLine;
                retString += "	SUM(SALESMONEYOTHER + RETGOODSANDDISCOUNTPRICEOTHER) AS MONTHSALESMONEYOTHER," + Environment.NewLine;
                // �e�����z
                retString += "	SUM(SALESMONEYORDER + RETGOODSANDDISCOUNTPRICEORDER - GROSSPROFITORDER +  RETGROSSPROFITORDER) AS MONTHGROSSPROFITORDER," + Environment.NewLine;
                retString += "	SUM(SALESMONEYSTOCK + RETGOODSANDDISCOUNTPRICESTOCK - GROSSPROFITSTOCK + RETGROSSPROFITSTOCK) AS MONTHGROSSPROFITSTOCK," + Environment.NewLine;
                retString += "	SUM(SALESMONEYGENUINE + RETGOODSANDDISCOUNTPRICEGENUINE - GROSSPROFITGENUINE + RETGROSSPROFITGENUINE) AS MONTHGROSSPROFITGENUINE," + Environment.NewLine;
                retString += "	SUM(SALESMONEYPRM + RETGOODSANDDISCOUNTPRICEPRM - GROSSPROFITPRM + RETGROSSPROFITPRM) AS MONTHGROSSPROFITPRM," + Environment.NewLine;
                retString += "	SUM(SALESMONEYOUTSIDE + RETGOODSANDDISCOUNTPRICEOUTSIDE - GROSSPROFITOUTSIDE + RETGROSSPROFITOUTSIDE) AS MONTHGROSSPROFITOUTSIDE," + Environment.NewLine;
                retString += "	SUM(SALESMONEYOTHER + RETGOODSANDDISCOUNTPRICEOTHER - GROSSPROFITOTHER + RETGROSSPROFITOTHER) AS MONTHGROSSPROFITOTHER" + Environment.NewLine;

                retString += "	FROM" + Environment.NewLine;
                retString += "	(" + Environment.NewLine;
                retString += "		SELECT" + Environment.NewLine;
                retString += "		SALESDTL.ENTERPRISECODERF," + Environment.NewLine;
                retString += "		SALES.RESULTSADDUPSECCDRF AS SECTIONCODERF," + Environment.NewLine;
                retString += tblnm1 + codeId + "," + Environment.NewLine;
                retString += tblnm2 + nameId + "," + Environment.NewLine;
                // ������z
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 0) THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYORDER," + Environment.NewLine;
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 0) THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYSTOCK," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF = 0 AND SALESSLIPCDDTLRF = 0)  THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYGENUINE," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF = 1 AND SALESSLIPCDDTLRF = 0)  THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYPRM," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 )  OR GOODSMGROUPRF =3000 )  AND SALESSLIPCDDTLRF = 0) THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYOUTSIDE," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND GOODSMGROUPRF !=3000 ) AND SALESSLIPCDDTLRF = 0) THEN SALESMONEYTAXEXCRF ELSE 0 END  AS SALESMONEYOTHER," + Environment.NewLine;
                // �ԕi+�l�����z
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 1 ) OR (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICEORDER," + Environment.NewLine;
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 1 ) OR (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICESTOCK," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF   = 0 AND SALESSLIPCDDTLRF = 1 ) OR (GOODSKINDCODERF   = 0 AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICEGENUINE," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF   = 1 AND SALESSLIPCDDTLRF = 1 ) OR (GOODSKINDCODERF   = 1 AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICEPRM," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 )  OR GOODSMGROUPRF =3000 )  AND SALESSLIPCDDTLRF = 1 ) OR ((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 ) AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICEOUTSIDE," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND GOODSMGROUPRF !=3000 ) AND SALESSLIPCDDTLRF = 1 ) OR ((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND SALESSLIPCDDTLRF = 2 )   THEN SALESMONEYTAXEXCRF ELSE 0 END  AS RETGOODSANDDISCOUNTPRICEOTHER," + Environment.NewLine;
                // ����(�e���v�Z�p)
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 0) THEN COSTRF ELSE 0 END  AS GROSSPROFITORDER," + Environment.NewLine;
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 0) THEN COSTRF ELSE 0 END  AS GROSSPROFITSTOCK," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF = 0  AND SALESSLIPCDDTLRF = 0) THEN COSTRF ELSE 0 END  AS GROSSPROFITGENUINE," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF = 1  AND SALESSLIPCDDTLRF = 0) THEN COSTRF ELSE 0 END  AS GROSSPROFITPRM," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 )  OR GOODSMGROUPRF =3000 )  AND SALESSLIPCDDTLRF = 0) THEN COSTRF ELSE 0 END  AS GROSSPROFITOUTSIDE," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND GOODSMGROUPRF !=3000 ) AND SALESSLIPCDDTLRF = 0) THEN COSTRF ELSE 0 END  AS GROSSPROFITOTHER," + Environment.NewLine;
                // ����(�e���v�Z�p)�ԕi�{�l����
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 1 ) OR (SALESORDERDIVCDRF = 0 AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITORDER," + Environment.NewLine;
                retString += "		CASE WHEN (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 1 ) OR (SALESORDERDIVCDRF = 1 AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITSTOCK," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF   = 0 AND SALESSLIPCDDTLRF = 1 ) OR (GOODSKINDCODERF   = 0 AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITGENUINE," + Environment.NewLine;
                retString += "		CASE WHEN (GOODSKINDCODERF   = 1 AND SALESSLIPCDDTLRF = 1 ) OR (GOODSKINDCODERF   = 1 AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITPRM," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 )  OR GOODSMGROUPRF =3000 )  AND SALESSLIPCDDTLRF = 1 ) OR ((BLGOODSCODERF >= 1000 AND BLGOODSCODERF <= 4999 ) AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITOUTSIDE," + Environment.NewLine;
                retString += "		CASE WHEN (((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND GOODSMGROUPRF !=3000 ) AND SALESSLIPCDDTLRF = 1 ) OR ((BLGOODSCODERF < 1000 OR BLGOODSCODERF > 4999 ) AND SALESSLIPCDDTLRF = 2 )   THEN (COSTRF*-1) ELSE 0 END  AS RETGROSSPROFITOTHER" + Environment.NewLine;


                retString += "		FROM" + Environment.NewLine;
                retString += "		SALESHISTDTLRF AS  SALESDTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                retString += "		LEFT JOIN SALESHISTORYRF  AS SALES WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                retString += "			SALES.ENTERPRISECODERF =  SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                retString += "		AND SALES.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                retString += "		AND SALES.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine;
                retString += "		LEFT JOIN CUSTOMERRF AS CUST WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                retString += "			SALES.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;
                retString += "			AND SALES.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;
                retString += "		LEFT JOIN EMPLOYEERF AS EMP WITH (READUNCOMMITTED) ON    " + Environment.NewLine;
                retString += "			SALES.ENTERPRISECODERF = EMP.ENTERPRISECODERF" + Environment.NewLine;
                retString += "			AND SALES.SALESEMPLOYEECDRF = EMP.EMPLOYEECODERF    " + Environment.NewLine;
                retString += "		LEFT JOIN USERGDBDURF AS USERGD WITH (READUNCOMMITTED) ON" + Environment.NewLine;
                retString += "			SALES.ENTERPRISECODERF = USERGD.ENTERPRISECODERF" + Environment.NewLine;
                retString += "			AND USERGD.USERGUIDEDIVCDRF = 21" + Environment.NewLine;
                retString += "			AND CUST.SALESAREACODERF = USERGD.GUIDECODERF" + Environment.NewLine;

                // WHERE
                retString += MakeWhereString(ref sqlCommand, _salesHistAnalyzeCndtnWork, logicalMode,1);
                retString += "	) AS SUBSALESHIS" + Environment.NewLine;
                retString += MakeGroupByString(printDiv);

                retString += ") AS SALESHIS" + Environment.NewLine;
                // 2012.06.14 Y.Ito DEL START �d�b�Ή�No.1016
                //retString += "LEFT JOIN SECINFOSETRF AS SECINF ON" + Environment.NewLine;
                //retString += "	SECINF.ENTERPRISECODERF = SALESHIS.ENTERPRISECODERF" + Environment.NewLine;
                //retString += "	AND SECINF.SECTIONCODERF = SALESHIS.SECTIONCODERF" + Environment.NewLine;
                // 2012.06.14 Y.Ito DEL END �d�b�Ή�No.1016
                retString += "	) AS SALESMONTH" + Environment.NewLine;
                retString += "ON" + Environment.NewLine;
                retString += "SALESDAY.ENTERPRISECODERF = SALESMONTH.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND SALESDAY.SECTIONCODERF = SALESMONTH.SECTIONCODERF" + Environment.NewLine;
                retString += "AND SALESDAY." + codeId + " = SALESMONTH." + codeId + Environment.NewLine;

                #endregion

            }
            

            return retString;
        }
        #endregion

        #region GroupBy�吶��
        /// <summary>
        /// ���s�^�C�v�ʂ�GROUP BY����쐬
        /// </summary>
        /// <param name="printDiv">���s�^�C�v</param>
        /// <returns>GROUP BY��</returns>
        private string MakeGroupByString(Int32 printDiv)
        {
            string retString = string.Empty;

            switch (printDiv)
            {
                case 0://���Ӑ�
                    {
                        retString += "	GROUP BY" + Environment.NewLine;
                        retString += "	SUBSALESHIS.ENTERPRISECODERF," + Environment.NewLine;
                        retString += "	SUBSALESHIS.SECTIONCODERF," + Environment.NewLine;
                        retString += "	SUBSALESHIS.CUSTOMERCODERF," + Environment.NewLine;
                        retString += "	SUBSALESHIS.CUSTOMERSNMRF" + Environment.NewLine;
                        break;
                    }
                case 1://�S����
                    {
                        retString += "	GROUP BY" + Environment.NewLine;
                        retString += "	SUBSALESHIS.ENTERPRISECODERF," + Environment.NewLine;
                        retString += "	SUBSALESHIS.SECTIONCODERF," + Environment.NewLine;
                        retString += "	SUBSALESHIS.SALESEMPLOYEECDRF," + Environment.NewLine;
                        retString += "	SUBSALESHIS.NAMERF" + Environment.NewLine;
                        break;
                    }
                case 2://�n��
                    {
                        retString += "	GROUP BY" + Environment.NewLine;
                        retString += "	SUBSALESHIS.ENTERPRISECODERF," + Environment.NewLine;
                        retString += "	SUBSALESHIS.SECTIONCODERF," + Environment.NewLine;
                        retString += "	SUBSALESHIS.SALESAREACODERF," + Environment.NewLine;
                        retString += "	SUBSALESHIS.GUIDENAMERF" + Environment.NewLine;
                        break;
                    }
            }

            return retString;
        }
        #endregion

        #region Where�吶��
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesHistAnalyzeCndtnWork _salesHistAnalyzeCndtnWork, ConstantManagement.LogicalMode logicalMode, int MakeMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;
            if (MakeMode == 0)
            {
                //��ƃR�[�h
                retstring += " SALESDTL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salesHistAnalyzeCndtnWork.EnterpriseCode);

                //�_���폜�敪
                retstring += "AND SALESDTL.LOGICALDELETECODERF=0 " + Environment.NewLine;

                //�v�㋒�_�R�[�h
                if (_salesHistAnalyzeCndtnWork.SectionCode != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _salesHistAnalyzeCndtnWork.SectionCode)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        retstring += " AND SALES.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") " + Environment.NewLine;
                    }
                }


                //�J�n���Ӑ�R�[�h
                if (_salesHistAnalyzeCndtnWork.St_CustomerCode != 0)
                {
                    retstring += " AND SALES.CUSTOMERCODERF>=@STCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                    paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(_salesHistAnalyzeCndtnWork.St_CustomerCode);
                }

                //�I�����Ӑ�R�[�h
                if ((_salesHistAnalyzeCndtnWork.Ed_CustomerCode != 0) && (_salesHistAnalyzeCndtnWork.Ed_CustomerCode != 99999999))
                {
                    retstring += " AND SALES.CUSTOMERCODERF<=@EDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                    paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(_salesHistAnalyzeCndtnWork.Ed_CustomerCode);
                }
                //�J�n�̔��]�ƈ��R�[�h
                if (_salesHistAnalyzeCndtnWork.St_SalesEmployeeCd != "")
                {
                    retstring += " AND SALES.SALESEMPLOYEECDRF>=@STSALESEMPLOYEECDRF" + Environment.NewLine;
                    SqlParameter paraStSalesEmployeeCd = sqlCommand.Parameters.Add("@STSALESEMPLOYEECDRF", SqlDbType.NChar);
                    paraStSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(_salesHistAnalyzeCndtnWork.St_SalesEmployeeCd);

                }
                //�I���̔��]�ƈ��R�[�h
                if (_salesHistAnalyzeCndtnWork.Ed_SalesEmployeeCd != "")
                {
                    retstring += " AND SALES.SALESEMPLOYEECDRF<=@EDSALESEMPLOYEECDRF" + Environment.NewLine;
                    SqlParameter paraEdSalesEmployeeCd = sqlCommand.Parameters.Add("@EDSALESEMPLOYEECDRF", SqlDbType.NChar);
                    paraEdSalesEmployeeCd.Value = SqlDataMediator.SqlSetString(_salesHistAnalyzeCndtnWork.Ed_SalesEmployeeCd);
                }

                //�J�n�n��R�[�h
                if (_salesHistAnalyzeCndtnWork.St_SalesAreaCode != 0)
                {
                    // 2012.06.14 Y.Ito MOD START �d�b�Ή�No.1016
                    //retstring += " AND CUST.SALESAREACODERF<=@STSALESAREACODERF" + Environment.NewLine;
                    retstring += " AND CUST.SALESAREACODERF>=@STSALESAREACODERF" + Environment.NewLine;
                    // 2012.06.14 Y.Ito MOD END �d�b�Ή�No.1016

                    SqlParameter paraStSalesAreaCode = sqlCommand.Parameters.Add("@STSALESAREACODERF", SqlDbType.Int);
                    paraStSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(_salesHistAnalyzeCndtnWork.St_SalesAreaCode);

                }
                //�I���n��R�[�h
                if ((_salesHistAnalyzeCndtnWork.Ed_SalesAreaCode != 0)&&(_salesHistAnalyzeCndtnWork.Ed_SalesAreaCode != 9999))
                {
                    retstring += " AND CUST.SALESAREACODERF<=@EDSALESAREACODERF" + Environment.NewLine;
                    SqlParameter paraEdSalesAreaCode = sqlCommand.Parameters.Add("@EDSALESAREACODERF", SqlDbType.Int);
                    paraEdSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(_salesHistAnalyzeCndtnWork.Ed_SalesAreaCode);
                }


                //�Ώۓ��t
                if (_salesHistAnalyzeCndtnWork.St_SalesDate != 0)
                {
                    retstring += " AND SALESDTL.SALESDATERF>=@STSALESDATE" + Environment.NewLine;
                    SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                    paraStSalesDate.Value = SqlDataMediator.SqlSetInt32(_salesHistAnalyzeCndtnWork.St_SalesDate);
                }
                if (_salesHistAnalyzeCndtnWork.Ed_SalesDate != 0)
                {
                    retstring += " AND SALESDTL.SALESDATERF<=@EDSALESDATE" + Environment.NewLine;
                    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                    paraEdSalesDate.Value = SqlDataMediator.SqlSetInt32(_salesHistAnalyzeCndtnWork.Ed_SalesDate);
                }
            }
            else
            {
                //��ƃR�[�h
                retstring += " SALESDTL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;

                // 2012.06.14 Y.Ito ADD START �d�b�Ή�No.1016
                //�_���폜�敪
                retstring += "AND SALESDTL.LOGICALDELETECODERF=0 " + Environment.NewLine;
                // 2012.06.14 Y.Ito ADD END �d�b�Ή�No.1016

                //�v�㋒�_�R�[�h
                if (_salesHistAnalyzeCndtnWork.SectionCode != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _salesHistAnalyzeCndtnWork.SectionCode)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }

                    if (sectionCodestr != "")
                    {
                        retstring += " AND SALES.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") " + Environment.NewLine;
                    }
                }
                //�J�n���Ӑ�R�[�h
                if (_salesHistAnalyzeCndtnWork.St_CustomerCode != 0)
                {
                    retstring += " AND SALES.CUSTOMERCODERF>=@STCUSTOMERCODE" + Environment.NewLine;
                }

                //�I�����Ӑ�R�[�h
                if ((_salesHistAnalyzeCndtnWork.Ed_CustomerCode != 0) && (_salesHistAnalyzeCndtnWork.Ed_CustomerCode != 99999999))
                {
                    retstring += " AND SALES.CUSTOMERCODERF<=@EDCUSTOMERCODE" + Environment.NewLine;
                }
                //�J�n�̔��]�ƈ��R�[�h
                if (_salesHistAnalyzeCndtnWork.St_SalesEmployeeCd != "")
                {
                    // 2012.06.14 Y.Ito MOD START �d�b�Ή�No.1016
                    //retstring += " AND SALES.SALESEMPLOYEECDRF<=@STSALESEMPLOYEECDRF" + Environment.NewLine;
                    retstring += " AND SALES.SALESEMPLOYEECDRF>=@STSALESEMPLOYEECDRF" + Environment.NewLine;
                    // 2012.06.14 Y.Ito MOD END �d�b�Ή�No.1016
                }
                //�I���̔��]�ƈ��R�[�h
                if (_salesHistAnalyzeCndtnWork.Ed_SalesEmployeeCd != "")
                {
                    retstring += " AND SALES.SALESEMPLOYEECDRF<=@EDSALESEMPLOYEECDRF" + Environment.NewLine;
                }

                //�J�n�n��R�[�h
                if (_salesHistAnalyzeCndtnWork.St_SalesAreaCode != 0)
                {
                    // 2012.06.14 Y.Ito MOD START �d�b�Ή�No.1016
                    //retstring += " AND CUST.SALESAREACODERF<=@STSALESAREACODERF" + Environment.NewLine;
                    retstring += " AND CUST.SALESAREACODERF>=@STSALESAREACODERF" + Environment.NewLine;
                    // 2012.06.14 Y.Ito MOD END �d�b�Ή�No.1016

                }
                //�I���n��R�[�h
                if ((_salesHistAnalyzeCndtnWork.Ed_SalesAreaCode != 0) && (_salesHistAnalyzeCndtnWork.Ed_SalesAreaCode != 9999))
                {
                    retstring += " AND CUST.SALESAREACODERF<=@EDSALESAREACODERF" + Environment.NewLine;
                }


                //�Ώۓ��t
                if (_salesHistAnalyzeCndtnWork.St_MonthReportDate != 0)
                {
                    retstring += " AND SALESDTL.SALESDATERF>=@STMONTHSALESDATE" + Environment.NewLine;
                    SqlParameter paraStMonthReportDate = sqlCommand.Parameters.Add("@STMONTHSALESDATE", SqlDbType.Int);
                    paraStMonthReportDate.Value = SqlDataMediator.SqlSetInt32(_salesHistAnalyzeCndtnWork.St_MonthReportDate);
                }
                if (_salesHistAnalyzeCndtnWork.Ed_MonthReportDate != 0)
                {
                    retstring += " AND SALESDTL.SALESDATERF<=@EDMONTHSALESDATE" + Environment.NewLine;
                    SqlParameter paraEdMonthReportDate = sqlCommand.Parameters.Add("@EDMONTHSALESDATE", SqlDbType.Int);
                    paraEdMonthReportDate.Value = SqlDataMediator.SqlSetInt32(_salesHistAnalyzeCndtnWork.Ed_MonthReportDate);
                }
            }
            #endregion
            return retstring;
        }
        #endregion
    }
}


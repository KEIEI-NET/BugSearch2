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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���㑬��\��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㑬��\���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2008.10.27</br>
    /// <br></br>
    /// <br>Update Note: ���x�`���[�j���O</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>Update Note: ���N�n��</br>
    /// <br>Date       : 2011/03/22</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: chenyk</br>
    /// <br>Date       : 2014/02/21</br>
    /// <br>             redmine#42135 �ғ����擾���@�̑Ή�</br>
    /// <br>Update Note: chenyk</br>
    /// <br>Date       : 2014/03/06</br>
    /// <br>             redmine#42135 �l�̌ܓ��̏C��</br>
    /// </remarks>
    [Serializable]
    public class SalesReportOrderWorkDB : RemoteDB, ISalesReportOrderWorkDB
    {
        /// <summary>
        /// ���㑬��\��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.2</br>
        /// </remarks>
        public SalesReportOrderWorkDB()
            :
        base("PMHNB04157D", "Broadleaf.Application.Remoting.ParamData.SalesReportOrderWorkDB", "SalesHistoryRF") //���N���X�̃R���X�g���N�^
        {
        }

        private CompanyInfDB _companyInfDB = new CompanyInfDB();

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔��㑬��\����LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="salesReportResultWork">��������</param>
        /// <param name=" salesReportOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��㑬��\��LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.27</br>
        public int Search(out object salesReportResultWork, object salesReportOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            salesReportResultWork = null;

            SalesReportOrderCndtnWork _salesReportOrderCndtnWork = salesReportOrderCndtnWork as SalesReportOrderCndtnWork;

            try
            {
                // ���㑬��\������
                status = SearchProc(out salesReportResultWork, _salesReportOrderCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesReportOrderWorkDB.Search Exception=" + ex.Message);
                salesReportResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔��㑬��\����LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="salesReportResultWork">��������</param>
        /// <param name=" salesReportOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��㑬��\��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.27</br>
        /// <br>Update Note: ���N�n��</br>
        /// <br>Date       : 2011/03/22</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        /// <br>Update Note: chenyk</br>
        /// <br>Date       : 2014/02/21</br>
        /// <br>             redmine#42135 �ғ����擾���@�̑Ή�</br>
        /// <br></br>
        public int SearchProc(out object salesReportResultWork, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            salesReportResultWork = null;
            SqlConnection sqlConnection = null;

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

                ArrayList list = new ArrayList();
                CompanyInfWork companyInfWork = new CompanyInfWork();

                //���ߔ͈͓��t�擾
                companyInfWork.EnterpriseCode = _salesReportOrderCndtnWork.EnterpriseCode;

                // --- ADD 2011/03/22----------------------------------->>>>>
                OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, companyInfWork.EnterpriseCode, "���㑬��\��", "���o�J�n");
                // --- ADD 2011/03/22-----------------------------------<<<<<
                
                status = _companyInfDB.Search(out list, companyInfWork, ref sqlConnection);

                // --- ADD 2011/03/22----------------------------------->>>>>
                oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, companyInfWork.EnterpriseCode, "���㑬��\��", "���o�I��");
                // --- ADD 2011/03/22-----------------------------------<<<<<

                companyInfWork = list[0] as CompanyInfWork;

                int year;
                DateTime yearmonth;
                string strYearMonth;
                DateTime stMonth, edMonth;

                FinYearTableGenerator fin = new FinYearTableGenerator(companyInfWork);
                fin.GetYearMonth(_salesReportOrderCndtnWork.St_SalesDate, out yearmonth, out year);
                if (yearmonth.Month >= 1 && yearmonth.Month <= 9)
                {
                    strYearMonth = yearmonth.Year.ToString() + "0" + yearmonth.Month.ToString();
                }
                else
                {
                    strYearMonth = yearmonth.Year.ToString() + yearmonth.Month.ToString();

                }

                fin.GetDaysFromMonth(yearmonth, out stMonth, out edMonth);

                status = SearchOrderProc(ref al, ref sqlConnection, _salesReportOrderCndtnWork, logicalMode, strYearMonth);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ғ�������
                    status = this.SearchHoliday(ref al, ref sqlConnection, _salesReportOrderCndtnWork, readMode, logicalMode, stMonth, edMonth);
                }
                // --- ADD chenyk 2014/02/21 ------->>>>>
                // ��ʎw��͈͓��̖ڕW���z�ƂȂ�悤�ɏC��
                TargetMoneyUpdate(ref al);
                // --- ADD chenyk 2014/02/21 -------<<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesReportOrderWorkDB.SearchProc Exception=" + ex.Message);
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

            salesReportResultWork = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, ConstantManagement.LogicalMode logicalMode, string strYearMonth)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "         SAL.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "        ,SAL.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,SAL.RESULTSADDUPSECCDRF" + Environment.NewLine;
                selectTxt += "        ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "        ,SUM(SAL.SALESTOTALTAXEXCRF) AS SUMSALESTOTALTAXEXCRF" + Environment.NewLine;
                selectTxt += "        ,EMP.SALESTARGETMONEYRF" + Environment.NewLine;
                selectTxt += "        ,EMP.SALESTARGETPROFITRF" + Environment.NewLine;
                selectTxt += "        ,SUM(SAL.SALESTOTALTAXEXCRF - SAL.TOTALCOSTRF) AS SUMTOTALCOST" + Environment.NewLine;
                selectTxt += " FROM SALESHISTORYRF AS SAL" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "	SEC.ENTERPRISECODERF=SAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND SEC.SECTIONCODERF=SAL.RESULTSADDUPSECCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPSALESTARGETRF AS EMP" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "	EMP.ENTERPRISECODERF=SAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "	AND EMP.SECTIONCODERF=SAL.RESULTSADDUPSECCDRF" + Environment.NewLine;
                selectTxt += "	AND EMP.SUBSECTIONCODERF=0" + Environment.NewLine;
                selectTxt += "	AND EMP.EMPLOYEEDIVCDRF=0" + Environment.NewLine;
              	selectTxt += "	AND EMP.TARGETSETCDRF = 10" + Environment.NewLine;
                selectTxt += "  AND EMP.TARGETCONTRASTCDRF = 10" + Environment.NewLine;
                selectTxt += "  AND EMP.TARGETDIVIDECODERF = @TARGET" + Environment.NewLine;
                selectTxt += "  AND EMP.EMPLOYEECODERF = ''" + Environment.NewLine;

                SqlParameter parastrYearMonth = sqlCommand.Parameters.Add("@TARGET", SqlDbType.NChar);
                parastrYearMonth.Value = SqlDataMediator.SqlSetString(strYearMonth);

                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _salesReportOrderCndtnWork, logicalMode);

                selectTxt += " GROUP BY SAL.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,SAL.RESULTSADDUPSECCDRF" + Environment.NewLine;
                selectTxt += " ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += " ,EMP.SALESTARGETMONEYRF" + Environment.NewLine;
                selectTxt += " ,EMP.SALESTARGETPROFITRF" + Environment.NewLine;


                sqlCommand.CommandText = selectTxt;
                #endregion

                myReader = sqlCommand.ExecuteReader();  
                
                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SalesReportResultWork wkSalesReportResultWork = new SalesReportResultWork();
                    
                    //�i�[����
                    wkSalesReportResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    wkSalesReportResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                    wkSalesReportResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    wkSalesReportResultWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESTOTALTAXEXCRF"));
                    wkSalesReportResultWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
                    if (wkSalesReportResultWork.SalesTargetMoney != 0)
                    {

                        wkSalesReportResultWork.AchievementRateNet = ((double)wkSalesReportResultWork.SalesTotalTaxExc / (double)wkSalesReportResultWork.SalesTargetMoney) *100;
                    } 
                    wkSalesReportResultWork.GrossMargin = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMTOTALCOST"));  
                    wkSalesReportResultWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
                    if (wkSalesReportResultWork.SalesTargetProfit != 0)
                    {
                        
                        wkSalesReportResultWork.AchievementRateGross = ((double)wkSalesReportResultWork.GrossMargin / (double)wkSalesReportResultWork.SalesTargetProfit * 100);
                    }                    
                    #endregion

                    al.Add(wkSalesReportResultWork);

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
                base.WriteErrorLog(ex, "SalesReportOrderWork.SearchOrderProc Exception=" + ex.Message);
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
        /// �w�肳�ꂽ��ƃR�[�h�̔��㑬��\����LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="salesReportResultWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��㑬��\��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.27</br>
        /// <br>Update Note: chenyk</br>
        /// <br>Date       : 2014/02/21</br>
        /// <br>             redmine#42135 �ғ����擾���@�̑Ή�</br>
        /// <br></br>
        public int SearchHoliday(ref ArrayList al, ref SqlConnection sqlConnection, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode,DateTime stMonth, DateTime edMonth)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //status = SearchHolidayProc(ref al, ref sqlConnection, _salesReportOrderCndtnWork, logicalMode, stMonth, edMonth); // DEL chenyk 2014/02/21 for redmine#42135
                // --- ADD chenyk 2014/02/21 for redmine#42135 ------>>>>>
                status = SearchHolidayProc(ref al, ref sqlConnection, _salesReportOrderCndtnWork, logicalMode, stMonth, edMonth, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = SearchHolidayProc(ref al, ref sqlConnection, _salesReportOrderCndtnWork, logicalMode, _salesReportOrderCndtnWork.St_SalesDate, _salesReportOrderCndtnWork.Ed_SalesDate, 1);
                }
                // --- ADD chenyk 2014/02/21 for redmine#42135 ------<<<<<
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesReportOrderWorkDB.SearchHolyday Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="flag">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: chenyk</br>
        /// <br>Date       : 2014/02/21</br>
        /// <br>             redmine#42135 �ғ����擾���@�̑Ή�</br>
        //private int SearchHolidayProc(ref ArrayList al, ref SqlConnection sqlConnection, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, ConstantManagement.LogicalMode logicalMode,DateTime stMonth, DateTime edMonth) // DEL chenyk 2014/02/21
        private int SearchHolidayProc(ref ArrayList al, ref SqlConnection sqlConnection, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, ConstantManagement.LogicalMode logicalMode, DateTime stMonth, DateTime edMonth, int flag) // ADD chenyk 2014/02/21
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList list = new ArrayList();
            ArrayList palaList = new ArrayList();
            
            int holiday;
            int j=0;

            try
            {
                // ���_���̋x������
                foreach (SalesReportResultWork salesReportResultWork in al)
                {
                    //���X�g���狒�_���o
                    string sectionCode = salesReportResultWork.SectionCode;

                    myReader = null;
                    sqlCommand = null;

                    string selectTxt = "";
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                    #region Select���쐬

                    selectTxt += "SELECT " + Environment.NewLine;
                    selectTxt += "COUNT(*) AS HOLIDAYCOUNTRF" + Environment.NewLine;
                    selectTxt += " FROM HOLIDAYSETTINGRF" + Environment.NewLine;

                    selectTxt += MakeHolidayWhereString(ref sqlCommand, _salesReportOrderCndtnWork, logicalMode, sectionCode, stMonth, edMonth);
                    sqlCommand.CommandText = selectTxt;

                    myReader = sqlCommand.ExecuteReader();

                    #endregion
                    while (myReader.Read())
                    {
                        // ���o����
                        holiday = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HOLIDAYCOUNTRF"));
                        list.Add(holiday);
                    }

                    // �w��͈͓��̓����擾
                    TimeSpan i = edMonth - stMonth;

                    int Allday = i.Days;
                    int Opday = Allday+1 - (int)list[j];

                    //�ғ�����ǉ�
                    // salesReportResultWork.OperationDay = Opday; // DEL chenyk 2014/02/21 for redmine#42135
                    // --- ADD chenyk 2014/02/21 for redmine#42135 ------>>>>>
                    if (flag == 0)
                    {
                        salesReportResultWork.OperationDayInRange = Opday;
                    }
                    else
                    {
                        salesReportResultWork.OperationDay = Opday;
                    }
                    // --- ADD chenyk 2014/02/21 for redmine#42135 ------<<<<<

                    palaList.Add(salesReportResultWork);
                    if (!myReader.IsClosed) myReader.Close();
                    j++;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                
                al.Clear();
                al = palaList;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesReportOrderWork.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }


        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE" + Environment.NewLine;
            if (_salesReportOrderCndtnWork.SectionCode != "")
            {
                #region WHERE���쐬
                // ��ƃR�[�h
                retstring += "SAL.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salesReportOrderCndtnWork.EnterpriseCode);

                // ���_�R�[�h
                retstring += " AND SAL.RESULTSADDUPSECCDRF=@SECTIONCODE";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(_salesReportOrderCndtnWork.SectionCode);

                // ������t
                if (_salesReportOrderCndtnWork.St_SalesDate != DateTime.MinValue)
                {
                    retstring += " AND SAL.SALESDATERF>=@STSALESDATE" + Environment.NewLine;
                    SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                    paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_salesReportOrderCndtnWork.St_SalesDate);
                }
                if (_salesReportOrderCndtnWork.Ed_SalesDate != DateTime.MinValue)
                {
                    retstring += " AND SAL.SALESDATERF<=@EDSALESDATE" + Environment.NewLine;
                    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                    paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_salesReportOrderCndtnWork.Ed_SalesDate);
                }

                // ����`�[�敪
                retstring += " AND ((SAL.SALESSLIPCDRF = 0) OR (SAL.SALESSLIPCDRF = 1))" + Environment.NewLine;

                // �_���폜�R�[�h
                retstring += " AND SAL.LOGICALDELETECODERF = 0" + Environment.NewLine;

                // -- ADD 2010/05/10 ---------------------------------->>>
                // �󒍃X�e�[�^�X(30�Œ�)
                retstring += " AND SAL.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
                // -- ADD 2010/05/10 ----------------------------------<<<
            
            }
            if (_salesReportOrderCndtnWork.SectionCode == "")
            {
                // ��ƃR�[�h
                retstring += "SAL.ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salesReportOrderCndtnWork.EnterpriseCode);

                // �_���폜�R�[�h
                retstring += " AND SAL.LOGICALDELETECODERF = 0" + Environment.NewLine;

                // ������t
                if (_salesReportOrderCndtnWork.St_SalesDate != DateTime.MinValue)
                {
                    retstring += " AND SAL.SALESDATERF>=@STSALESDATE" + Environment.NewLine;
                    SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STSALESDATE", SqlDbType.Int);
                    paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_salesReportOrderCndtnWork.St_SalesDate);
                }
                if (_salesReportOrderCndtnWork.Ed_SalesDate != DateTime.MinValue)
                {
                    retstring += " AND SAL.SALESDATERF<=@EDSALESDATE" + Environment.NewLine;
                    SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDSALESDATE", SqlDbType.Int);
                    paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_salesReportOrderCndtnWork.Ed_SalesDate);
                }

                // -- ADD 2010/05/10 ---------------------------------->>>
                // �󒍃X�e�[�^�X(30�Œ�)
                retstring += " AND SAL.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
                // -- ADD 2010/05/10 ----------------------------------<<<

            }
            #endregion
            return retstring;
        }


        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_orderListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeHolidayWhereString(ref SqlCommand sqlCommand, SalesReportOrderCndtnWork _salesReportOrderCndtnWork, ConstantManagement.LogicalMode logicalMode,string sectionCode, DateTime stMonth, DateTime edMonth)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;
            // ��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salesReportOrderCndtnWork.EnterpriseCode);

            // ���_�R�[�h
            retstring += " AND SECTIONCODERF=@SECTIONCODE";
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);

            // �K�p�敪0,1
            retstring += " AND ((APPLYDATECDRF = 0) OR (APPLYDATECDRF = 1))" + Environment.NewLine;
            
            // �K�p�N����
            if (_salesReportOrderCndtnWork.St_SalesDate != DateTime.MinValue)
            {
                retstring += " AND APPLYDATERF>=@STAPPLYDATE" + Environment.NewLine;
                SqlParameter paraStSalesDate = sqlCommand.Parameters.Add("@STAPPLYDATE", SqlDbType.Int);
                paraStSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stMonth);
            }
            if (_salesReportOrderCndtnWork.Ed_SalesDate != DateTime.MinValue)
            {
                retstring += " AND APPLYDATERF<=@EDAPPLYDATE" + Environment.NewLine;
                SqlParameter paraEdSalesDate = sqlCommand.Parameters.Add("@EDAPPLYDATE", SqlDbType.Int);
                paraEdSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(edMonth);
            }

            #endregion
            return retstring;
        }

        // --- ADD chenyk 2014/02/21 ------->>>>>
        /// <summary>
        /// ��ʎw��͈͓��̔���ڕW���z�ƂȂ�悤�ɏC��
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <returns></returns>
        private void TargetMoneyUpdate (ref ArrayList al)
        {
            ArrayList palaList = new ArrayList();
            foreach (SalesReportResultWork resultWork in al)
            {
                long salesTargetMoney = resultWork.SalesTargetMoney;
                long salesTargetProfit = resultWork.SalesTargetProfit;
                int operationDayInRange = resultWork.OperationDayInRange;
                int operationDay = resultWork.OperationDay;
                if (operationDayInRange != 0)
                {
                    // ����ڕW���z
                    //resultWork.SalesTargetMoney = salesTargetMoney * operationDay / operationDayInRange; // DEL chenyk 2014/03/06 Redmine#42135 �l�̌ܓ��̏C��
                    resultWork.SalesTargetMoney = this.GetUnitChangeProc(salesTargetMoney * operationDay, operationDayInRange); // ADD chenyk 2014/03/06 Redmine#42135 �l�̌ܓ��̏C��
                    if (resultWork.SalesTargetMoney != 0)
                    {
                        // �B�����i������j
                        resultWork.AchievementRateNet = ((double)resultWork.SalesTotalTaxExc / (double)resultWork.SalesTargetMoney) * 100;
                    }
                }
                else
                {
                    resultWork.SalesTargetMoney = 0;
                    resultWork.AchievementRateNet = 0.00;
                }
                if (operationDayInRange != 0)
                {
                    // ����ڕW�e���z
                    //resultWork.SalesTargetProfit = salesTargetProfit * operationDay / operationDayInRange; // DEL chenyk 2014/03/06 Redmine#42135 �l�̌ܓ��̏C��
                    resultWork.SalesTargetProfit = this.GetUnitChangeProc(salesTargetProfit * operationDay, operationDayInRange); // ADD chenyk 2014/03/06 Redmine#42135 �l�̌ܓ��̏C��
                    if (resultWork.SalesTargetProfit != 0)
                    {
                        // �B�����i�e���j
                        resultWork.AchievementRateGross = ((double)resultWork.GrossMargin / (double)resultWork.SalesTargetProfit * 100);
                    }
                }
                else
                {
                    resultWork.SalesTargetProfit = 0;
                    resultWork.AchievementRateGross = 0.00;
                }
                palaList.Add(resultWork);
            }
            al.Clear();
            al = palaList;
        }

        // --- ADD chenyk 2014/03/06 Redmine#42135 �l�̌ܓ��̏C�� ----->>>>>
        #region ���P�ʕϊ�����
        /// <summary>
        /// �P�ʕϊ������i�l�̌ܓ��j
        /// </summary>
        /// <param name="numerator">���q</param>
        /// <param name="denominator">����</param>
        internal Int64 GetUnitChangeProc(Int64 numerator, Int64 denominator)
        {
            Int64 retInt;
            Int64 workInt;
            double workdbl;

            retInt = numerator / denominator;
            workdbl = (double)numerator / (double)denominator;

            workInt = (Int64)(workdbl * 10) % 10;
            if (workInt >= 5)
            {
                retInt++;
            }

            return retInt;
        }
        #endregion
        // --- ADD chenyk 2014/03/06 Redmine#42135 �l�̌ܓ��̏C�� -----<<<<<
        // --- ADD chenyk 2014/02/21 -------<<<<<
    }
}


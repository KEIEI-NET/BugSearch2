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
    /// �ߔN�x���v�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ߔN�x���v�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.12.04</br>
    /// <br></br>
    /// <br>UpdateNote : �ԕi���z����d�W�v����Ă���Ή�</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2008.04.02</br>
    /// </remarks>
    [Serializable]
    public class PastYearStatisticsDB : RemoteDB, IPastYearStatisticsDB
    {
        /// <summary>
        /// �ߔN�x���v�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
        /// </remarks>
        public PastYearStatisticsDB()
            :
            base("DCTOK02186D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PastYearStatisticsWork", "CUSTMTTLSALSLIPRF")
        {
        }

        #region [SearchPastYearStatistics]
        /// <summary>
        /// �w�肳�ꂽ�����̉ߔN�x���v�\��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̉ߔN�x���v�\��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
        public int SearchPastYearStatistics(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_PastYearStatisticsWork extrInfo_PastYearStatistics = null;

            ArrayList extrInfo_PastYearStatisticsList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (extrInfo_PastYearStatisticsList == null)
            {
                extrInfo_PastYearStatistics = paraObj as ExtrInfo_PastYearStatisticsWork;
            }
            else
            {
                if (extrInfo_PastYearStatisticsList.Count > 0)
                    extrInfo_PastYearStatistics = extrInfo_PastYearStatisticsList[0] as ExtrInfo_PastYearStatisticsWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //���Í����L�[OPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTMTTLSALSLIPRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //���ߔN�x���v�\�擾
                status = SearchPastYearStatisticsProc(ref retList, extrInfo_PastYearStatistics, ref sqlConnection);

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PastYearStatisticsDB.SearchPastYearStatistics");
                retObj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //���Í����L�[CLOSE
                //if (sqlEncryptInfo.IsOpen) sqlEncryptInfo.CloseSymKey(ref sqlConnection);

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retObj = (object)retList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̉ߔN�x���v�\��߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_PastYearStatistics">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̉ߔN�x���v�\��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        private int SearchPastYearStatisticsProc(ref ArrayList retList, ExtrInfo_PastYearStatisticsWork extrInfo_PastYearStatistics, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 8)
            {
                return status;
            }

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //���񌎂̎擾
            Int32 companyBiginMonth;
            GetCompanyBiginMonth(out companyBiginMonth, extrInfo_PastYearStatistics, ref sqlConnection);

            //�c�Ə���
            string useTable = "MTTLSALESSLIPRF";
            string groupUnit = "GROUP BY TTL.ADDUPSECCODERF, TTL.SECTIONGUIDENMRF ";
            if (extrInfo_PastYearStatistics.ListType == 1)
            {
                //���Ӑ��
                useTable = "CUSTMTTLSALSLIPRF";
                groupUnit = "GROUP BY TTL.ADDUPSECCODERF, TTL.SECTIONGUIDENMRF, TTL.CUSTOMERCODERF, TTL.CUSTOMERSNMRF ";
            }

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //��ƃR�[�h
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_PastYearStatistics.EnterpriseCode);

                //���_�R�[�h
                string whereSecCust = "";
                if (extrInfo_PastYearStatistics.SecCodeList != null)
                {
                    string sectionString = "";
                    foreach (string sectionCode in extrInfo_PastYearStatistics.SecCodeList)
                    {
                        if (sectionCode != "")
                        {
                            if (sectionString != "") sectionString += ",";
                            sectionString += "'" + sectionCode + "'";
                        }
                    }
                    if (sectionString != "")
                    {
                        whereSecCust = "AND TTL.ADDUPSECCODERF IN (" + sectionString + ") ";
                    }
                }

                //���Ӑ�R�[�h
                string whereCustomerCode = "";
                if (extrInfo_PastYearStatistics.ListType == 1)
                {
                    if (extrInfo_PastYearStatistics.St_CustomerCode > 0)
                    {
                        whereCustomerCode += "AND TTL.CUSTOMERCODERF>=@ST_CUSTOMERCODE ";
                        SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCODE", SqlDbType.Int);
                        paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PastYearStatistics.St_CustomerCode);
                    }
                    if (extrInfo_PastYearStatistics.Ed_CustomerCode > 0)
                    {
                        whereCustomerCode += "AND TTL.CUSTOMERCODERF<=@ED_CUSTOMERCODE ";
                        SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCODE", SqlDbType.Int);
                        paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PastYearStatistics.Ed_CustomerCode);
                    }
                }

                #region [SQL��]
                sqlCommand.CommandText = "SELECT ";
                string totalUnit = "";
                if (extrInfo_PastYearStatistics.TotalWay == true)
                {
                    sqlCommand.CommandText += "'000000' ADDUPSECCODERF, "
                                            + "'' SECTIONGUIDENMRF, ";
                    totalUnit += "'000000' ADDUPSECCODERF, '' SECTIONGUIDENMRF, ";
                }
                else
                {
                    sqlCommand.CommandText += "ADDUPSECCODERF, "
                                            + "SECTIONGUIDENMRF, ";
                    totalUnit += "TTL.ADDUPSECCODERF, TTL.SECTIONGUIDENMRF, ";
                }
                if (extrInfo_PastYearStatistics.ListType == 1)
                {
                    //���Ӑ��
                    sqlCommand.CommandText += "CUSTOMERCODERF, "
                                            + "CUSTOMERSNMRF, ";
                    totalUnit += "TTL.CUSTOMERCODERF, TTL.CUSTOMERSNMRF, ";
                }
                else
                {
                    //�c�Ə���
                    sqlCommand.CommandText += "0 CUSTOMERCODERF, "
                                            + "'' CUSTOMERSNMRF, ";
                    totalUnit += "0 CUSTOMERCODERF, '' CUSTOMERSNMRF, ";
                }

                if (extrInfo_PastYearStatistics.MoneyUnit == 1)
                {
                    sqlCommand.CommandText += "(SUM(SALESMONEY1RF) + 500) / 1000 SALESMONEY1RF, "
                                            + "(SUM(GROSSMONEY1RF) + 500) / 1000 GROSSMONEY1RF, "
                                            + "(SUM(SALESMONEY2RF) + 500) / 1000 SALESMONEY2RF, "
                                            + "(SUM(GROSSMONEY2RF) + 500) / 1000 GROSSMONEY2RF, "
                                            + "(SUM(SALESMONEY3RF) + 500) / 1000 SALESMONEY3RF, "
                                            + "(SUM(GROSSMONEY3RF) + 500) / 1000 GROSSMONEY3RF, "
                                            + "(SUM(SALESMONEY4RF) + 500) / 1000 SALESMONEY4RF, "
                                            + "(SUM(GROSSMONEY4RF) + 500) / 1000 GROSSMONEY4RF, "
                                            + "(SUM(SALESMONEY5RF) + 500) / 1000 SALESMONEY5RF, "
                                            + "(SUM(GROSSMONEY5RF) + 500) / 1000 GROSSMONEY5RF, "
                                            + "(SUM(SALESMONEY6RF) + 500) / 1000 SALESMONEY6RF, "
                                            + "(SUM(GROSSMONEY6RF) + 500) / 1000 GROSSMONEY6RF, "
                                            + "(SUM(SALESMONEY7RF) + 500) / 1000 SALESMONEY7RF, "
                                            + "(SUM(GROSSMONEY7RF) + 500) / 1000 GROSSMONEY7RF, "
                                            + "(SUM(SALESMONEY8RF) + 500) / 1000 SALESMONEY8RF, "
                                            + "(SUM(GROSSMONEY8RF) + 500) / 1000 GROSSMONEY8RF "
                                            + "FROM ( SELECT ";
                }
                else
                {
                    sqlCommand.CommandText += "SUM(SALESMONEY1RF) SALESMONEY1RF, "
                                            + "SUM(GROSSMONEY1RF) GROSSMONEY1RF, "
                                            + "SUM(SALESMONEY2RF) SALESMONEY2RF, "
                                            + "SUM(GROSSMONEY2RF) GROSSMONEY2RF, "
                                            + "SUM(SALESMONEY3RF) SALESMONEY3RF, "
                                            + "SUM(GROSSMONEY3RF) GROSSMONEY3RF, "
                                            + "SUM(SALESMONEY4RF) SALESMONEY4RF, "
                                            + "SUM(GROSSMONEY4RF) GROSSMONEY4RF, "
                                            + "SUM(SALESMONEY5RF) SALESMONEY5RF, "
                                            + "SUM(GROSSMONEY5RF) GROSSMONEY5RF, "
                                            + "SUM(SALESMONEY6RF) SALESMONEY6RF, "
                                            + "SUM(GROSSMONEY6RF) GROSSMONEY6RF, "
                                            + "SUM(SALESMONEY7RF) SALESMONEY7RF, "
                                            + "SUM(GROSSMONEY7RF) GROSSMONEY7RF, "
                                            + "SUM(SALESMONEY8RF) SALESMONEY8RF, "
                                            + "SUM(GROSSMONEY8RF) GROSSMONEY8RF "
                                            + "FROM ( SELECT ";
                }
                //1�N�ڏW�v
                string whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 0, companyBiginMonth);
                sqlCommand.CommandText += totalUnit
                                        // �� 2008.04.02 980081 c
                                        //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY1RF, "
                                        + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY1RF, "
                                        // �� 2008.04.02 980081 c
                                        + "SUM(TTL.GROSSPROFITRF) GROSSMONEY1RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                        + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                        + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                        + "FROM " + useTable + " TTL ";
                sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;

                //2�N�ڏW�v
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 1)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 1, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            // �� 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY2RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY2RF, "
                                            // �� 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //3�N�ڏW�v
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 2)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 2, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            // �� 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY3RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY3RF, "
                                            // �� 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //4�N�ڏW�v
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 3)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 3, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            // �� 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY4RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY4RF, "
                                            // �� 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //5�N�ڏW�v
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 4)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 4, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            // �� 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY5RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY5RF, "
                                            // �� 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //6�N�ڏW�v
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 5)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 5, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            // �� 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY6RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY6RF, "
                                            // �� 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //7�N�ڏW�v
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 6)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 6, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            // �� 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY7RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY7RF, "
                                            // �� 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY7RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY8RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                //8�N�ڏW�v
                if (extrInfo_PastYearStatistics.Ed_AddUpYear - extrInfo_PastYearStatistics.St_AddUpYear >= 7)
                {
                    sqlCommand.CommandText += "UNION SELECT ";

                    whereMonthRange = MakeMonthRange(extrInfo_PastYearStatistics.St_AddUpYear, 7, companyBiginMonth);
                    sqlCommand.CommandText += totalUnit
                                            + "CONVERT(BIGINT,0) SALESMONEY1RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY1RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY2RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY2RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY3RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY3RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY4RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY4RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY5RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY5RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY6RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY6RF, "
                                            + "CONVERT(BIGINT,0) SALESMONEY7RF, "
                                            + "CONVERT(BIGINT,0) GROSSMONEY7RF, "
                                            // �� 2008.04.02 980081 c
                                            //+ "SUM(TTL.SALESTOTALTAXEXCRF + TTL.SALESRETGOODSPRICERF) SALESMONEY8RF, "
                                            + "SUM(TTL.SALESTOTALTAXEXCRF) SALESMONEY8RF, "
                                            // �� 2008.04.02 980081 c
                                            + "SUM(TTL.GROSSPROFITRF) GROSSMONEY8RF "
                                            + "FROM " + useTable + " TTL ";
                    sqlCommand.CommandText += "WHERE TTL.ENTERPRISECODERF=@ENTERPRISECODE " + whereSecCust + whereCustomerCode + whereMonthRange + groupUnit;
                }

                sqlCommand.CommandText += " ) AS UNION_DATA ";

                if (extrInfo_PastYearStatistics.ListType == 1)
                {
                    sqlCommand.CommandText += "GROUP BY UNION_DATA.ADDUPSECCODERF, UNION_DATA.SECTIONGUIDENMRF, UNION_DATA.CUSTOMERCODERF, UNION_DATA.CUSTOMERSNMRF ";
                }
                else
                {
                    sqlCommand.CommandText += "GROUP BY UNION_DATA.ADDUPSECCODERF, UNION_DATA.SECTIONGUIDENMRF ";
                }

                #endregion

                myReader = sqlCommand.ExecuteReader();

                RsltInfo_PastYearStatisticsWork pastYearStatisticsResultWork;
                while (myReader.Read())
                {
                    pastYearStatisticsResultWork = CopyToPastYearStatisticsResultFromReader(ref myReader);
                    retList.Add(pastYearStatisticsResultWork);
                }

                if (retList.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        #endregion

        #region [�ߔN�x���v�\���o���ʃN���X�i�[����]
        /// <summary>
        /// �ߔN�x���v�\���o���ʃN���X�i�[���� Reader �� RsltInfo_PastYearStatisticsWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_PastYearStatisticsWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        /// </remarks>
        private RsltInfo_PastYearStatisticsWork CopyToPastYearStatisticsResultFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_PastYearStatisticsWork wkRsltInfo_PastYearStatisticsWork = new RsltInfo_PastYearStatisticsWork();

            wkRsltInfo_PastYearStatisticsWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_PastYearStatisticsWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkRsltInfo_PastYearStatisticsWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            wkRsltInfo_PastYearStatisticsWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY1RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney1 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY1RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY2RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney2 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY2RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY3RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney3 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY3RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY4RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney4 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY4RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY5RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney5 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY5RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY6RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney6 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY6RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY7RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney7 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY7RF"));
            wkRsltInfo_PastYearStatisticsWork.SalesMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY8RF"));
            wkRsltInfo_PastYearStatisticsWork.GrossMoney8 = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSMONEY8RF"));
            return wkRsltInfo_PastYearStatisticsWork;
        }

        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
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

        #region ���̑��̊֐�
        /// <summary>
        /// ���񌎂����߂܂�
        /// </summary>
        /// <param name="companyBiginMonth">�߂�l:����</param>
        /// <param name="extrInfo_PastYearStatistics">�p�����[�^�N���X</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���񌎂����߂܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        private int GetCompanyBiginMonth(out Int32 companyBiginMonth, ExtrInfo_PastYearStatisticsWork extrInfo_PastYearStatistics, ref SqlConnection sqlConnection)
        {
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            companyBiginMonth = 0;
            try
            {
                sqlCommand = new SqlCommand("SELECT COMPANYBIGINMONTHRF FROM COMPANYINFRF WHERE ENTERPRISECODERF=@ENTERPRISECODE ", sqlConnection);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_PastYearStatistics.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    companyBiginMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPANYBIGINMONTHRF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        /// <summary>
        /// �N�x���Ƃ̒��o�͈͂����߂܂�
        /// </summary>
        /// <param name="st_Year">�J�n�N</param>
        /// <param name="addYear">���Z�N</param>
        /// <param name="companyBiginMonth">����</param>
        /// <returns>SQL����WHERE��(�N���x)</returns>
        /// <br>Note       : �N�x���Ƃ̒��o�͈͂����߂܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
        /// <br></br>
        private string MakeMonthRange(Int32 st_Year, Int32 addYear, Int32 companyBiginMonth)
        {
            Int32 startYear = st_Year + addYear;
            Int32 startMonth = companyBiginMonth;
            Int32 endYear = st_Year + addYear + 1;
            Int32 endMonth = companyBiginMonth - 1;
            if (companyBiginMonth == 1)
            {
                endYear = st_Year + addYear;
                endMonth = 12;
            }
            return "AND TTL.ADDUPYEARMONTHRF>=" + Convert.ToString(startYear * 100 + startMonth) + " "
                 + "AND TTL.ADDUPYEARMONTHRF<=" + Convert.ToString(endYear * 100 + endMonth) + " ";

        }

        #endregion

    }
}

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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �x���\��\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �x���\��\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.10.03</br>
    /// <br></br>
    /// <br>Update Note: 2007.11.15  �R�c ���F</br>
    /// <br>             �d����x�����z�}�X�^���C�A�E�g�ύX�̑Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.28  �R�c ���F</br>
    /// <br>             �S���_�I�����ɑS���_�W�v���Ă���̂��C��</br>
    /// <br>             �����w��Ǝx���\����w�肪99�̏ꍇ�͑S�ΏۂɏC��(�ȑO��28���ȍ~������)</br>
    /// <br>             ���������w��E�x���\��������w���ǉ�</br>
    /// <br></br>
    /// <br>Update Note: 2008.08.11  20081</br>
    /// <br>             �o�l.�m�r�p�ɕύX</br>
    /// <br>Update Note: 2009.04.30  22008 ����</br>
    /// <br>             �_���폜�f�[�^�Ή�</br>
    /// </remarks>
    [Serializable]
    public class PaymentProgramDB : RemoteDB, IPaymentProgramDB
    {
        /// <summary>
        /// �x���\��\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        public PaymentProgramDB()
            :
            base("DCKAK02556D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PaymentPlanWork", "SUPLIERPAYRF")
        {
        }

        #region [SearchPaymentProgram]
        /// <summary>
        /// �w�肳�ꂽ�����̎x���\��\��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎x���\��\��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.03</br>
        public int SearchPaymentProgram(out object retObj, object paraObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            //SqlEncryptInfo sqlEncryptInfo = null;
            retObj = null;

            ExtrInfo_PaymentPlanWork ExtrInfo_PaymentPlanWork = null;

            ArrayList ExtrInfo_PaymentPlanWorkList = paraObj as ArrayList;
            ArrayList retList = new ArrayList();

            if (ExtrInfo_PaymentPlanWorkList == null)
            {
                ExtrInfo_PaymentPlanWork = paraObj as ExtrInfo_PaymentPlanWork;
            }
            else
            {
                if (ExtrInfo_PaymentPlanWorkList.Count > 0)
                    ExtrInfo_PaymentPlanWork = ExtrInfo_PaymentPlanWorkList[0] as ExtrInfo_PaymentPlanWork;
            }

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //���Í����L�[OPEN
                //sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF", "SUPLIERPAYRF" });
                //sqlEncryptInfo.OpenSymKey(ref sqlConnection);

                //���x�����z�}�X�^�擾
                status = SearchPaymentProgramProc(ref retList, ExtrInfo_PaymentPlanWork, ref sqlConnection);

                //STATUS
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PaymentProgramDB.SearchPaymentProgram");
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
        /// �w�肳�ꂽ�����̎x���\��\��߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="extrInfo_PaymentPlanWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎x���\��\��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.03</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.15  �R�c ���F</br>
        /// <br>             �d����x�����z�}�X�^���C�A�E�g�ύX�̑Ή�</br>
        private int SearchPaymentProgramProc(ref ArrayList retList, ExtrInfo_PaymentPlanWork extrInfo_PaymentPlanWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SQL��]

                //A:�d����x�����zϽ� B:���_���ݒ�Ͻ� C:�d����Ͻ� D:�]�ƈ��}�X�^ E:�����S�̐ݒ�}�X�^ F:����x���擾�p�x��Ͻ�
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "     A.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,A.ADDUPSECCODERF" + Environment.NewLine;
                sqlText += "    ,B.SECTIONGUIDENMRF AS ADDUPSECNAMERF" + Environment.NewLine;
                sqlText += "    ,A.PAYEECODERF" + Environment.NewLine;
                sqlText += "    ,A.PAYEENAMERF" + Environment.NewLine;
                sqlText += "    ,A.PAYEENAME2RF" + Environment.NewLine;
                sqlText += "    ,A.ADDUPDATERF" + Environment.NewLine;
                sqlText += "    ,A.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "    ,A.STOCKTTL3TMBFBLPAYRF" + Environment.NewLine;
                sqlText += "    ,A.STOCKTTL2TMBFBLPAYRF" + Environment.NewLine;
                sqlText += "    ,A.LASTTIMEPAYMENTRF" + Environment.NewLine;
                sqlText += "    ,A.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                sqlText += "    ,A.THISSTCKPRICRGDSRF" + Environment.NewLine;
                sqlText += "    ,A.THISSTCKPRICDISRF" + Environment.NewLine;
                sqlText += "    ,A.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                sqlText += "    ,A.THISTIMEPAYNRMLRF" + Environment.NewLine;
                sqlText += "    ,C.PAYMENTMONTHCODERF" + Environment.NewLine;
                sqlText += "    ,C.PAYMENTMONTHNAMERF" + Environment.NewLine;
                sqlText += "    ,C.PAYMENTDAYRF" + Environment.NewLine;
                sqlText += "    ,C.PAYMENTCONDRF" + Environment.NewLine;
                sqlText += "    ,C.PAYMENTSIGHTRF" + Environment.NewLine;
                sqlText += "    ,C.STOCKAGENTCODERF" + Environment.NewLine;
                sqlText += "    ,D.NAMERF STOCKAGENTNAMERF" + Environment.NewLine;
                sqlText += "    ,E.COLLECTPLNDIVRF" + Environment.NewLine;
                sqlText += "    ," + Environment.NewLine;
                sqlText += "    (" + Environment.NewLine;
                sqlText += "        SELECT SUM" + Environment.NewLine;
                sqlText += "            (PAYMENTTOTALRF" + Environment.NewLine;
                sqlText += "            )" + Environment.NewLine;
                sqlText += "        FROM PAYMENTSLPRF F" + Environment.NewLine;
                sqlText += "        WHERE A.ENTERPRISECODERF=F.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "            AND A.PAYEECODERF=F.PAYEECODERF" + Environment.NewLine;
                sqlText += "            AND F.PAYMENTDATERF>A.ADDUPDATERF" + Environment.NewLine;
                sqlText += "            AND F.PAYMENTDATERF<=A.PAYMENTSCHEDULERF" + Environment.NewLine;
                sqlText += "            AND F.LOGICALDELETECODERF=0" + Environment.NewLine;  // 2009/04/30
                sqlText += "        GROUP BY F.PAYEECODERF" + Environment.NewLine;
                sqlText += "    ) AS AFTERCLOSEPAYMENTRF" + Environment.NewLine;
                sqlText += " FROM SUPLIERPAYRF A" + Environment.NewLine;
                sqlText += " LEFT JOIN SECINFOSETRF B ON A.ENTERPRISECODERF=B.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND A.ADDUPSECCODERF=B.SECTIONCODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN SUPPLIERRF C ON A.ENTERPRISECODERF=C.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND A.PAYEECODERF=C.SUPPLIERCDRF" + Environment.NewLine;
                sqlText += " LEFT JOIN EMPLOYEERF D ON C.ENTERPRISECODERF=D.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND C.STOCKAGENTCODERF=D.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += " LEFT JOIN BILLALLSTRF E ON A.ENTERPRISECODERF=E.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND A.ADDUPSECCODERF=E.SECTIONCODERF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                #endregion

                //Where��쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, extrInfo_PaymentPlanWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    retList.Add(CopyToRsltInfo_PaymentPlanFromReader(ref myReader));

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

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="extrInfo_PaymentPlanWork">���������i�[�N���X</param>
        /// <returns>�x���\��\���o��SQL������</returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.03</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.15  �R�c ���F</br>
        /// <br>             �d����x�����z�}�X�^���C�A�E�g�ύX�̑Ή�</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, ExtrInfo_PaymentPlanWork extrInfo_PaymentPlanWork)
        {
            //��{WHERE��̍쐬
            StringBuilder retString = new StringBuilder();
            retString.Append("WHERE ");

            //���Œ����
            //��ƃR�[�h
            retString.Append("A.ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_PaymentPlanWork.EnterpriseCode);

            //�_���폜�敪
            retString.Append("AND A.LOGICALDELETECODERF=0 ");

            //�e���R�[�h�݂̂�ΏۂƂ���(�d����R�[�h=0�̂ݑΏ�)
            retString.Append("AND A.SUPPLIERCDRF=0 ");

            //��������p�����[�^�̒l�ɂ�蓮�I�ω��̍���
            //�v�㋒�_�R�[�h
            if (extrInfo_PaymentPlanWork.PaymentAddupSecCodeList != null)
            {
                string sectionString = "";
                foreach (string sectionCode in extrInfo_PaymentPlanWork.PaymentAddupSecCodeList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    retString.Append("AND A.ADDUPSECCODERF IN (" + sectionString + ") ");
                }
            }

            //������
            if (extrInfo_PaymentPlanWork.AddUpDate > DateTime.MinValue)
            {
                retString.Append("AND A.ADDUPDATERF=@ADDUPDATE ");
                SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@ADDUPDATE", SqlDbType.Int);
                paraAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(extrInfo_PaymentPlanWork.AddUpDate);
            }

            //����
            // �� 2007.12.28 980081 c
            //if (extrInfo_PaymentPlanWork.CAddUpUpdExecDate == 99)
            //{
            //    //28�`31���w��
            //    retString.Append("AND D.TOTALDAYRF>=28 ");
            //}
            //else if (extrInfo_PaymentPlanWork.CAddUpUpdExecDate != 0)
            //{
            //    //�����w�肠��
            //    retString.Append("AND D.TOTALDAYRF=@CADDUPUPDEXECDATE ");
            //    SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
            //    paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentPlanWork.CAddUpUpdExecDate);
            //}
            if (extrInfo_PaymentPlanWork.IsLastDayCAddUpUpdExecDate == true)
            {
                //28�`31���w��
                retString.Append("AND D.TOTALDAYRF>=28 ");
            }
            else if (extrInfo_PaymentPlanWork.CAddUpUpdExecDate != 0 && extrInfo_PaymentPlanWork.CAddUpUpdExecDate != 99)
            {
                //�����w�肠��
                retString.Append("AND D.TOTALDAYRF=@CADDUPUPDEXECDATE ");
                SqlParameter paraCAddUpUpdExecDate = sqlCommand.Parameters.Add("@CADDUPUPDEXECDATE", SqlDbType.Int);
                paraCAddUpUpdExecDate.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentPlanWork.CAddUpUpdExecDate);
            }
            // �� 2007.12.28 980081 c

            //�x����R�[�h
            if (extrInfo_PaymentPlanWork.St_PayeeCode > 0)
            {
                retString.Append("AND A.PAYEECODERF>=@ST_PAYEECODE ");
                SqlParameter paraSt_PayeeCode = sqlCommand.Parameters.Add("@ST_PAYEECODE", SqlDbType.Int);
                paraSt_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentPlanWork.St_PayeeCode);
            }
            if (extrInfo_PaymentPlanWork.Ed_PayeeCode > 0)
            {
                retString.Append("AND A.PAYEECODERF<=@ED_PAYEECODE ");
                SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODE", SqlDbType.Int);
                paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentPlanWork.Ed_PayeeCode);
            }

            // 2008.08.11 upd start --------------------------------------->>
            //if (extrInfo_PaymentPlanWork.EmployeeKindDiv == 0)
            //{
            //    //�x���S��(���Ӑ�}�X�^ BillCollecterCdRF)
            //    if (extrInfo_PaymentPlanWork.St_EmployeeCode != "")
            //    {
            //        retString.Append("AND D.BILLCOLLECTERCDRF>=@ST_EMPLOYEECODE ");
            //        SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE", SqlDbType.NChar);
            //        paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PaymentPlanWork.St_EmployeeCode);
            //    }
            //    if (extrInfo_PaymentPlanWork.Ed_EmployeeCode != "")
            //    {
            //        retString.Append("AND D.BILLCOLLECTERCDRF<=@ED_EMPLOYEECODE ");
            //        SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE", SqlDbType.NChar);
            //        paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PaymentPlanWork.Ed_EmployeeCode);
            //    }
            //}
            //else if (extrInfo_PaymentPlanWork.EmployeeKindDiv == 1)
            //{
            //    //�d���S��(���Ӑ�d�����}�X�^ StockAgentCodeRF)
            //    if (extrInfo_PaymentPlanWork.St_EmployeeCode != "")
            //    {
            //        retString.Append("AND C.STOCKAGENTCODERF>=@ST_EMPLOYEECODE ");
            //        SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE", SqlDbType.NChar);
            //        paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PaymentPlanWork.St_EmployeeCode);
            //    }
            //    if (extrInfo_PaymentPlanWork.Ed_EmployeeCode != "")
            //    {
            //        retString.Append("AND C.STOCKAGENTCODERF<=@ED_EMPLOYEECODE ");
            //        SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE", SqlDbType.NChar);
            //        paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PaymentPlanWork.Ed_EmployeeCode);
            //    }
            //}
            //�d���S��
            if (extrInfo_PaymentPlanWork.St_EmployeeCode != "")
            {
                retString.Append("AND C.STOCKAGENTCODERF>=@ST_EMPLOYEECODE ");
                SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_EMPLOYEECODE", SqlDbType.NChar);
                paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PaymentPlanWork.St_EmployeeCode);
            }
            if (extrInfo_PaymentPlanWork.Ed_EmployeeCode != "")
            {
                retString.Append("AND C.STOCKAGENTCODERF<=@ED_EMPLOYEECODE ");
                SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_EMPLOYEECODE", SqlDbType.NChar);
                paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_PaymentPlanWork.Ed_EmployeeCode);
            }
            // 2008.08.11 upd end -----------------------------------------<<

            //�x������
            if (extrInfo_PaymentPlanWork.PaymentCond != null)
            {
                string sectionString = "";
                foreach (Int32 paymentCond in extrInfo_PaymentPlanWork.PaymentCond)
                {
                    if (paymentCond != -1)
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + Convert.ToString(paymentCond) + "'";
                    }
                }
                if (sectionString != "")
                {
                    retString.Append("AND A.PAYMENTCONDRF IN (" + sectionString + ") ");
                }
            }

            //�x���\���
            // �� 2007.12.28 980081 c
            //if (extrInfo_PaymentPlanWork.PaymentSchedule == 99)
            //{
            //    //28�`31���w��
            //    retString.Append("AND C.PAYMENTDAYRF>=28 ");
            //}
            //else if (extrInfo_PaymentPlanWork.PaymentSchedule != 0)
            //{
            //    //�����w�肠��
            //    retString.Append("AND C.PAYMENTDAYRF=@PAYMENTSCHEDULE ");
            //    SqlParameter paraPaymentSchedule = sqlCommand.Parameters.Add("@PAYMENTSCHEDULE", SqlDbType.Int);
            //    paraPaymentSchedule.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentPlanWork.PaymentSchedule);
            //}
            if (extrInfo_PaymentPlanWork.IsLastDayPaymentSchedule == true)
            {
                //28�`31���w��
                retString.Append("AND C.PAYMENTDAYRF>=28 ");
            }
            else if (extrInfo_PaymentPlanWork.PaymentSchedule != 0 && extrInfo_PaymentPlanWork.PaymentSchedule != 99)
            {
                //�x���\����w�肠��
                retString.Append("AND C.PAYMENTDAYRF=@PAYMENTSCHEDULE ");
                SqlParameter paraPaymentSchedule = sqlCommand.Parameters.Add("@PAYMENTSCHEDULE", SqlDbType.Int);
                paraPaymentSchedule.Value = SqlDataMediator.SqlSetInt32(extrInfo_PaymentPlanWork.PaymentSchedule);
            }
            // �� 2007.12.28 980081 c

            //���z���S��\0�͒��o���Ȃ��@�������1�������݂��Ȃ�
            // �� 2007.11.15 980081 c
            //retString.Append("AND (LASTTIMEPAYMENTRF != 0 OR THISTIMEPAYNRMLRF != 0 OR THISTIMEFEEPAYNRMLRF != 0 OR THISTIMEDISPAYNRMLRF != 0 OR THISTIMETTLBLCPAYRF != 0 OR THISNETSTCKPRICERF != 0 OR THISNETSTCPRCTAXRF != 0 OR ITDEDOFFSETOUTTAXRF != 0 OR ITDEDOFFSETINTAXRF != 0 OR ITDEDOFFSETTAXFREERF != 0 OR OFFSETOUTTAXRF != 0 OR OFFSETINTAXRF != 0 OR THISTIMESTOCKPRICERF != 0 OR THISSTCPRCTAXRF != 0 OR TTLITDEDSTCOUTTAXRF != 0 OR TTLITDEDSTCINTAXRF != 0 OR TTLITDEDSTCTAXFREERF != 0 OR TTLSTOCKOUTERTAXRF != 0 OR TTLSTOCKINNERTAXRF != 0 OR THISSTCKPRICRGDSRF != 0 OR THISSTCPRCTAXRGDSRF != 0 OR TTLITDEDRETOUTTAXRF != 0 OR TTLITDEDRETINTAXRF != 0 OR TTLITDEDRETTAXFREERF != 0 OR TTLRETOUTERTAXRF != 0 OR TTLRETINNERTAXRF != 0 OR THISSTCKPRICDISRF != 0 OR THISSTCPRCTAXDISRF != 0 OR TTLITDEDDISOUTTAXRF != 0 OR TTLITDEDDISINTAXRF != 0 OR TTLITDEDDISTAXFREERF != 0 OR TTLDISOUTERTAXRF != 0 OR TTLDISINNERTAXRF != 0 OR BALANCEADJUSTRF != 0) ");
            retString.Append("AND (LASTTIMEPAYMENTRF != 0 OR THISTIMEFEEPAYNRMLRF != 0 OR THISTIMEDISPAYNRMLRF != 0 OR THISTIMEPAYNRMLRF != 0 OR THISTIMETTLBLCPAYRF != 0 OR OFSTHISTIMESTOCKRF != 0 OR OFSTHISSTOCKTAXRF != 0 OR ITDEDOFFSETOUTTAXRF != 0 OR ITDEDOFFSETINTAXRF != 0 OR ITDEDOFFSETTAXFREERF != 0 OR OFFSETOUTTAXRF != 0 OR OFFSETINTAXRF != 0 OR THISTIMESTOCKPRICERF != 0 OR THISSTCPRCTAXRF != 0 OR TTLITDEDSTCOUTTAXRF != 0 OR TTLITDEDSTCINTAXRF != 0 OR TTLITDEDSTCTAXFREERF != 0 OR TTLSTOCKOUTERTAXRF != 0 OR TTLSTOCKINNERTAXRF != 0 OR THISSTCKPRICRGDSRF != 0 OR THISSTCPRCTAXRGDSRF != 0 OR TTLITDEDRETOUTTAXRF != 0 OR TTLITDEDRETINTAXRF != 0 OR TTLITDEDRETTAXFREERF != 0 OR TTLRETOUTERTAXRF != 0 OR TTLRETINNERTAXRF != 0 OR THISSTCKPRICDISRF != 0 OR THISSTCPRCTAXDISRF != 0 OR TTLITDEDDISOUTTAXRF != 0 OR TTLITDEDDISINTAXRF != 0 OR TTLITDEDDISTAXFREERF != 0 OR TTLDISOUTERTAXRF != 0 OR TTLDISINNERTAXRF != 0 OR TAXADJUSTRF != 0 OR BALANCEADJUSTRF != 0 OR STOCKTOTALPAYBALANCERF != 0)");
            // �� 2007.11.15 980081 c

            //�o�͏� 1:�d����R�[�h�� 2:�S���҃R�[�h�� 3:�S���ҕʎx������ 4:�x������ 5:�x�����ʎx��������
            switch (extrInfo_PaymentPlanWork.SortOrderDiv)
            {
                case 1:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, A.PAYEECODERF, A.PAYMENTSCHEDULERF");
                        break;
                    }
                case 2:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, D.BILLCOLLECTERCDRF, A.PAYEECODERF, A.PAYMENTSCHEDULERF");
                        break;
                    }
                case 3:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, D.BILLCOLLECTERCDRF, A.PAYMENTSCHEDULERF, A.PAYEECODERF");
                        break;
                    }
                case 4:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, A.PAYMENTSCHEDULERF, A.PAYEECODERF");
                        break;
                    }
                case 5:
                    {
                        retString.Append("ORDER BY A.ADDUPSECCODERF, A.PAYMENTSCHEDULERF, A.PAYMENTCONDRF, A.PAYEECODERF");
                        break;
                    }
            }

            return retString.ToString();
        }
        #endregion

        #region [�x���\��\���o���ʃN���X�i�[����]
        /// <summary>
        /// �x���\��\���o���ʃN���X�i�[���� Reader �� RsltInfo_PaymentPlanWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RsltInfo_PaymentPlanWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.03</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.15  �R�c ���F</br>
        /// <br>             �d����x�����z�}�X�^���C�A�E�g�ύX�̑Ή�</br>
        /// </remarks>
        private RsltInfo_PaymentPlanWork CopyToRsltInfo_PaymentPlanFromReader(ref SqlDataReader myReader)
        {
            RsltInfo_PaymentPlanWork wkRsltInfo_PaymentPlanWork = new RsltInfo_PaymentPlanWork();

            #region �N���X�֊i�[
            wkRsltInfo_PaymentPlanWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            wkRsltInfo_PaymentPlanWork.AddUpSecName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECNAMERF"));
            wkRsltInfo_PaymentPlanWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            wkRsltInfo_PaymentPlanWork.PayeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAMERF"));
            wkRsltInfo_PaymentPlanWork.PayeeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEENAME2RF"));
            wkRsltInfo_PaymentPlanWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            wkRsltInfo_PaymentPlanWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
            wkRsltInfo_PaymentPlanWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
            wkRsltInfo_PaymentPlanWork.StockTtl3TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL3TMBFBLPAYRF"));
            wkRsltInfo_PaymentPlanWork.StockTtl2TmBfBlPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTL2TMBFBLPAYRF"));
            wkRsltInfo_PaymentPlanWork.LastTimePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEPAYMENTRF"));
            wkRsltInfo_PaymentPlanWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            wkRsltInfo_PaymentPlanWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));
            wkRsltInfo_PaymentPlanWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));
            wkRsltInfo_PaymentPlanWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            wkRsltInfo_PaymentPlanWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            wkRsltInfo_PaymentPlanWork.AfterClosePayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFTERCLOSEPAYMENTRF"));
            wkRsltInfo_PaymentPlanWork.PaymentMonthCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTMONTHCODERF"));
            wkRsltInfo_PaymentPlanWork.PaymentMonthName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTMONTHNAMERF"));
            wkRsltInfo_PaymentPlanWork.PaymentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTDAYRF"));
            wkRsltInfo_PaymentPlanWork.PaymentCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTCONDRF"));
            wkRsltInfo_PaymentPlanWork.PaymentSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYMENTSIGHTRF"));
            wkRsltInfo_PaymentPlanWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
            wkRsltInfo_PaymentPlanWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
            wkRsltInfo_PaymentPlanWork.CollectPlnDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTPLNDIVRF"));
            #endregion
            return wkRsltInfo_PaymentPlanWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.03</br>
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

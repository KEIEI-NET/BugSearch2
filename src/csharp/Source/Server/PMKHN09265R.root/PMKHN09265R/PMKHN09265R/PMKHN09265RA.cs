//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���Ӑ�}�X�^�i�^�M�ݒ�jDB�����[�g�I�u�W�F�N�g
//                  :   PMKHN09265R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.10.14
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

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
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�}�X�^�i�^�M�ݒ�jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�^�M�ݒ�j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CustCreditDB : RemoteWithAppLockDB, ICustCreditDB
    {
        /// <summary>
        /// ���Ӑ�}�X�^�i�^�M�ݒ�jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        public CustCreditDB()
            : base("PMKHN09267D", "Broadleaf.Application.Remoting.ParamData.CustCreditWork", "CUSTCREDITRF")
        {

        }



        # region [Search]
        /// <summary>
        /// ���Ӑ�}�X�^���X�g���擾���܂��B
        /// </summary>
        /// <param name="customerList">���Ӑ�}�X�^�i�^�M�ݒ�j�����i�[���� ArrayList</param>
        /// <param name="paraWork">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�^�M�ݒ�j�̃L�[�l����v����A�S�Ă̓��Ӑ�}�X�^�i�^�M�ݒ�j��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Search(ref ArrayList customerList, CustCreditCndtnWork paraWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref customerList, paraWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�}�X�^���X�g���擾���܂��B
        /// </summary>
        /// <param name="customerList">���Ӑ�}�X�^�i�^�M�ݒ�j�����i�[���� ArrayList</param>
        /// <param name="paraWork">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�i�^�M�ݒ�j�̃L�[�l����v����A�S�Ă̓��Ӑ�}�X�^�i�^�M�ݒ�j��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private int SearchProc(ref ArrayList customerList, CustCreditCndtnWork paraWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF" + Environment.NewLine;
                sqlText += ", CUSTOMERCODERF" + Environment.NewLine;
                sqlText += ", TOTALDAYRF" + Environment.NewLine;
                sqlText += ", CLAIMCODERF" + Environment.NewLine;
                sqlText += ", CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, paraWork);
                # endregion
#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    customerList.Add(this.CopyToCustomerFromReader(ref myReader));
                }

                if (customerList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustCreditCndtnWork paraWork)
        {
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

            // �_���폜�敪
            retstring += "  AND LOGICALDELETECODERF=0" + Environment.NewLine;

            if (paraWork.CustomerCodes == null)
            {
                //���Ӑ�R�[�h�͈͎w��
                if (paraWork.St_CustomerCode != 0)
                {
                    retstring += " AND CUSTOMERCODERF>=@STCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@STCUSTOMERCODE", SqlDbType.Int);
                    paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraWork.St_CustomerCode);
                }
                if (paraWork.Ed_CustomerCode != 0)
                {
                    retstring += " AND CUSTOMERCODERF<=@EDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@EDCUSTOMERCODE", SqlDbType.Int);
                    paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(paraWork.Ed_CustomerCode);
                }
            }
            else
            {
                //���Ӑ�R�[�h�P�Ǝw��
                string customerCodestr = "";
                foreach (Int32 cuscdstr in paraWork.CustomerCodes)
                {
                    if (customerCodestr != "")
                    {
                        customerCodestr += ",";
                    }
                    customerCodestr += "'" + cuscdstr.ToString() + "'";
                }

                if (customerCodestr != "")
                {
                    retstring += " AND CUSTOMERCODERF IN (" + customerCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //����
            if (paraWork.TotalDay != 0)
            {
                retstring += " AND TOTALDAYRF=@TOTALDAY" + Environment.NewLine;
                SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                paraTotalDay.Value = SqlDataMediator.SqlSetInt32(paraWork.TotalDay);
            }

            //���Ӑ�R�[�h��������R�[�h
            retstring += " AND CUSTOMERCODERF=CLAIMCODERF" + Environment.NewLine;

            //�^�M�Ǘ��敪 1:����
            retstring += " AND CREDITMNGCODERF=1" + Environment.NewLine;

            return retstring;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CustomerWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustomerWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        private CustomerWork CopyToCustomerFromReader(ref SqlDataReader myReader)
        {
            CustomerWork customerWork = new CustomerWork();

            this.CopyToCustomerFromReader(ref myReader, ref customerWork);

            return customerWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CustomerWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="customerWork">CustomerWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        /// </remarks>
        private void CopyToCustomerFromReader(ref SqlDataReader myReader, ref CustomerWork customerWork)
        {
            if (myReader != null && customerWork != null)
            {
                # region �N���X�֊i�[
                customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                # endregion
            }
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�^�M�ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="resultList">�ǉ��E�X�V���链�Ӑ�}�X�^�i�^�M�ݒ�j�����i�[���� ArrayList</param>
        /// <param name="customerList">���Ӑ�}�X�^���X�g</param>
        /// <param name="paraWork">���o�����N���X</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : resultList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�^�M�ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private int SearchCustomerChange(ref ArrayList resultList, ArrayList customerList, CustCreditCndtnWork paraWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            CustDmdPrcDB custDmdPrcDB = new CustDmdPrcDB();
            try
            {
                if (customerList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection);

                    for (int i = 0; i < customerList.Count; i++)
                    {
                        CustomerWork customerWork = customerList[i] as CustomerWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CREDITMONEYRF" + Environment.NewLine;
                        sqlText += " ,WARNINGCREDITMONEYRF" + Environment.NewLine;
                        sqlText += " ,PRSNTACCRECBALANCERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTOMERCHANGERF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND LOGICALDELETECODERF=0" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        sqlCommand.Parameters.Clear();
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {

                            CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();
                            //�t�h���ł̑��엚���X�V�ׁ̈A���Ӑ�ϓ����v���������쐬
                            CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                            customerChangeWork.EnterpriseCode = customerWork.EnterpriseCode; //��ƃR�[�h
                            customerChangeWork.CustomerCode = customerWork.ClaimCode;    //������R�[�h

                            if (paraWork.ProcDiv == 0)
                            {
                                //���ݔ��|�c���ݒ�

                                //���ݔ��|�c���̎Z�o���s��
                                custDmdPrcWork.EnterpriseCode = customerWork.EnterpriseCode; //��ƃR�[�h
                                custDmdPrcWork.ClaimCode = customerWork.ClaimCode;           //������
                                custDmdPrcWork.CustomerCode = customerWork.CustomerCode;      //���Ӑ�i��������j
                                custDmdPrcWork.AddUpSecCode = customerWork.ClaimSectionCode; //�������_�R�[�h
                                custDmdPrcWork.AddUpDate = DateTime.MaxValue;  //��ł������l�����čő�l���Z�b�g

                                #region �폜
                                /*
                                CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
                                //���Ӑ�}�X�^�A�ŗ��ݒ�}�X�^�擾
                                status = custDmdPrcDB.GetIndivCustomer(ref custDmdPrcUpdateWork, ref custDmdPrcWork, ref sqlConnection);

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //�O�񐿋��������擾
                                    status = custDmdPrcDB.GetDmdCAddUpHisAndCustDmdPrc(ref custDmdPrcWork, ref sqlConnection);
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    if (custDmdPrcWork.TotalAmntDspWayRef == 0)
                                        status = GetTotalAmount(ref custDmdPrcWork, ref sqlConnection);
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //�����z�擾
                                    status = custDmdPrcDB.GetDepsitMain(ref custDmdPrcWork, ref sqlConnection);
                                }

                                ArrayList custDmdPrcChildWorkList = new ArrayList();
                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //����z�擾
                                    status = custDmdPrcDB.GetSalesSlip(ref custDmdPrcWork, ref custDmdPrcChildWorkList, ref sqlConnection);
                                }

                                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                {
                                    //�������z�}�X�^�Z�o����
                                    custDmdPrcDB.CalculateCustDmdPrc(ref custDmdPrcWork);
                                }

                                else return status;
                                */
                                #endregion

                                object objCustDmdPrcWork = (object)custDmdPrcWork;
                                string retMsg = string.Empty;

                                SqlConnection sqlConnectionDmd = null;
                                try
                                {

                                    sqlConnectionDmd = this.CreateSqlConnection(true);

                                    //���X�V�������\�b�h
                                    status = custDmdPrcDB.ReadCustDmdPrc(ref objCustDmdPrcWork, out retMsg, ref sqlConnectionDmd);
                                }
                                finally
                                {
                                    if (sqlConnectionDmd != null)
                                    {
                                        sqlConnectionDmd.Close();
                                        sqlConnectionDmd.Dispose();
                                    }
                                }

                                customerChangeWork.PrsntAccRecBalance = custDmdPrcWork.AfCalDemandPrice;

                                //�O��l�ƕύX�������ꍇ�̂ݍX�V���X�g�ɒǉ�
                                if (customerChangeWork.PrsntAccRecBalance != SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRSNTACCRECBALANCERF")))
                                {
                                    //�X�V���X�g�ɒǉ�
                                    al.Add(customerChangeWork);
                                }
                            }
                            else
                            {
                                bool changeFlg = false;

                                //�^�M�z�N���A
                                //�^�M�z�N���A�t���O
                                if (paraWork.CreditMoneyFlg)
                                {
                                    customerChangeWork.CreditMoney = 0;
                                    if (SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREDITMONEYRF")) != 0) 
                                    {
                                        changeFlg = true;
                                    }

                                }

                                //�x���^�M�z�N���A�t���O
                                if (paraWork.WarningCrdMnyFrg)
                                {
                                    customerChangeWork.WarningCreditMoney = 0;

                                    if (SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("WARNINGCREDITMONEYRF")) != 0)
                                    {
                                        changeFlg = true;
                                    }
                                }

                                //���ݔ��|�c���t���O
                                if (paraWork.AccRecDiv)
                                {
                                    customerChangeWork.PrsntAccRecBalance = 0;

                                    if (SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRSNTACCRECBALANCERF")) != 0)
                                    {
                                        changeFlg = true;
                                    }
                                }

                                //�O��l�ƕύX�������ꍇ�̂ݍX�V���X�g�ɒǉ�
                                if (changeFlg)
                                {
                                    al.Add(customerChangeWork);
                                }
                            }

                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                        }
                        else
                        {

                            //���݂��Ȃ��ꍇ�͎Z�o���Ȃ�
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                        }
                    }
                }

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            resultList = al;

            return status;
        }

        # endregion

        # region [Write]
        /// <summary>
        /// ���Ӑ�}�X�^�i�^�M�ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="objCustCreditList">�ǉ��E�X�V���链�Ӑ�}�X�^�i�^�M�ݒ�j�����܂� ArrayList</param>
        /// <param name="paraCustCreditCndtn">���o�����N���X CustCreditCndtnWork</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�^�M�ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Write(out object objCustCreditList, object paraCustCreditCndtn)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList resultList = new ArrayList();
            ArrayList customerChangeList = new ArrayList();
            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList customerList = new ArrayList();
                CustCreditCndtnWork paraWork = paraCustCreditCndtn as CustCreditCndtnWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                //���Ӑ�}�X�^���o
                status = this.Search(ref customerList, paraWork,ref sqlConnection, ref sqlTransaction);

                //���Ӑ�ϓ����X�V���X�g���쐬
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.SearchCustomerChange(ref customerChangeList, customerList, paraWork, ref sqlConnection);
                }

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = this.Write(ref resultList, customerChangeList, paraWork, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            objCustCreditList = resultList;
            return status;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�^�M�ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="resultList">�ǉ��E�X�V���链�Ӑ�}�X�^�i�^�M�ݒ�j�����i�[���� ArrayList</param>
        /// <param name="customerList">���Ӑ�}�X�^���X�g</param>
        /// <param name="paraWork">���o�����N���X</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�^�M�ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        public int Write(ref ArrayList resultList,ArrayList customerList, CustCreditCndtnWork paraWork,ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref resultList, customerList, paraWork, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�^�M�ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="resultList">�ǉ��E�X�V���链�Ӑ�}�X�^�i�^�M�ݒ�j�����i�[���� ArrayList</param>
        /// <param name="customerChangeList">���Ӑ�}�X�^���X�g</param>
        /// <param name="paraWork">���o�����N���X</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : resultList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�^�M�ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        private int WriteProc(ref ArrayList resultList, ArrayList customerChangeList, CustCreditCndtnWork paraWork,ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            CustDmdPrcDB custDmdPrcDB = new CustDmdPrcDB();
            
            try
            {
                if (customerChangeList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < customerChangeList.Count; i++)
                    {
                        CustomerChangeWork customerChangeWork = customerChangeList[i] as CustomerChangeWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTOMERCHANGERF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND LOGICALDELETECODERF=0" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        sqlCommand.Parameters.Clear();
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerChangeWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerChangeWork.CustomerCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            # region [UPDATE��]

                            sqlText = string.Empty;

                            sqlText += " UPDATE CUSTOMERCHANGERF SET" + Environment.NewLine;
                            sqlText += "    UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;

                            if (paraWork.ProcDiv == 0)
                            {
                                //���ݔ��|�c���ݒ�
                                sqlText += "  , PRSNTACCRECBALANCERF=@PRSNTACCRECBALANCE" + Environment.NewLine;
                            }
                            else
                            {
                                //�^�M�z�N���A
                                //�^�M�z�N���A�t���O
                                if (paraWork.CreditMoneyFlg)
                                {
                                    sqlText += "  , CREDITMONEYRF=@CREDITMONEY" + Environment.NewLine;
                                }
                                //�x���^�M�z�N���A�t���O
                                if (paraWork.WarningCrdMnyFrg)
                                {
                                    sqlText += "  , WARNINGCREDITMONEYRF=@WARNINGCREDITMONEY" + Environment.NewLine;
                                }
                                //���ݔ��|�c���t���O
                                if (paraWork.AccRecDiv)
                                {
                                    sqlText += "  , PRSNTACCRECBALANCERF=@PRSNTACCRECBALANCE" + Environment.NewLine;
                                }
                            }

                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerChangeWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerChangeWork.CustomerCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)customerChangeWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }

                            # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);

                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerChangeWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerChangeWork.EnterpriseCode);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerChangeWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerChangeWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerChangeWork.UpdAssemblyId2);

                            CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();

                            if (paraWork.ProcDiv == 0)
                            {
                                //���ݔ��|�c���ݒ�
                                SqlParameter paraPrsntAccRecBalance = sqlCommand.Parameters.Add("@PRSNTACCRECBALANCE", SqlDbType.BigInt);
                                paraPrsntAccRecBalance.Value = SqlDataMediator.SqlSetInt64(customerChangeWork.PrsntAccRecBalance); //�v�Z�㐿�����z
                            }
                            else
                            {
                                //�^�M�z�N���A
                                //�^�M�z�N���A�t���O
                                if (paraWork.CreditMoneyFlg)
                                {
                                    SqlParameter paraCreditMoney = sqlCommand.Parameters.Add("@CREDITMONEY", SqlDbType.BigInt);
                                    paraCreditMoney.Value = 0;

                                }
                                //�x���^�M�z�N���A�t���O
                                if (paraWork.WarningCrdMnyFrg)
                                {
                                    SqlParameter paraWarningCreditMoney = sqlCommand.Parameters.Add("@WARNINGCREDITMONEY", SqlDbType.BigInt);
                                    paraWarningCreditMoney.Value = 0;
                                }
                                //���ݔ��|�c���t���O
                                if (paraWork.AccRecDiv)
                                {
                                    SqlParameter paraPrsntAccRecBalance = sqlCommand.Parameters.Add("@PRSNTACCRECBALANCE", SqlDbType.BigInt);
                                    paraPrsntAccRecBalance.Value = 0;
                                }
                            }

                            # endregion

                            sqlCommand.ExecuteNonQuery();
                            al.Add(customerChangeWork);

                        }
                        else
                        {
                            //���݂��Ȃ��ꍇ�̒ǉ��͍s��Ȃ�
                            if (!myReader.IsClosed)
                            {
                                myReader.Close();
                            }
                        }
                    }
                }

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            resultList = al;

            return status;
        }
        # endregion

    }
}

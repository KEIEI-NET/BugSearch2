//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�ꊇ�C��DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ���Ӑ�ꊇ�C���̎��f�[�^������s���N���X�ł��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23012�@���� �[���N
// �� �� ��  2008.11.10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23012�@���� �[���N
// �C �� ��  2008.12.05  �C�����e : ���Ӑ�}�X�^�e�[�u�����C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 23012�@���� �[���N
// �C �� ��  2009.04.10  �C�����e : Write�����폜( MANTIS�Ή� ID:9494 ) 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009.05.22  �C�����e : Write�����폜( PVCS�Ή� ID:102 ) 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2010.01.20  �C�����e : �������^�C�v���̏o�͍��ڋ敪��ǉ��i�R���ځj
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� �F������
// �C �� ��  2012/07/24  �C�����e �F��z�Č��ARedmine#30387
//                                  ���쌟��
//----------------------------------------------------------------------------//

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
    /// ���Ӑ�ꊇ�C��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ꊇ�C���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012�@���� �[���N</br>
    /// <br>Date       : 2008.11.10</br>
    /// <br></br>
    /// <br>Update Note: ���Ӑ�}�X�^�e�[�u�����C�A�E�g�ύX�Ή�</br>
    /// <br>Programmer : 23012�@���� �[���N</br>
    /// <br>Date       : 2008.12.05</br>
    /// <br>Update Note: 2012/07/24 ������</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
    /// <br>             Redmine#30387  ���쌟��</br>
    /// </remarks>
    [Serializable]
    public class CustomerCustomerChangeDB : RemoteWithAppLockDB, ICustomerCustomerChangeDB
    {
        /// <summary>
        /// ���Ӑ�ꊇ�C��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        /// </remarks>
        public CustomerCustomerChangeDB()
            : base("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.CustomerCustomerChangeResultWork", "BLCODEGUIDERF")
        {

        }

        #region [Read]
        /// <summary>
        /// �P��̓��Ӑ�ꊇ�C�������擾���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeObj">customerCustomerChangeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�̃L�[�l����v���链�Ӑ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        public int Read(ref object customerCustomerChangeResultObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            //SqlTransaction sqlTransaction = null;

            try
            {
                CustomerCustomerChangeResultWork customerCustomerChangeResultWork = customerCustomerChangeResultObj as CustomerCustomerChangeResultWork;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref customerCustomerChangeResultWork, readMode, ref sqlConnection/*, ref sqlTransaction*/);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                //if (sqlTransaction != null)
                //{
                //    if (sqlTransaction.Connection != null)
                //    {
                //        sqlTransaction.Commit();
                //    }

                //    sqlTransaction.Dispose();
                //}

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �P��̓��Ӑ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeWork">CustomerCustomerChangeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�̃L�[�l����v���链�Ӑ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        public int Read(ref CustomerCustomerChangeResultWork customerCustomerChangeResultWork, int readMode, ref SqlConnection sqlConnection/*, ref SqlTransaction sqlTransaction*/)
        {
            return this.ReadProc(ref customerCustomerChangeResultWork, readMode, ref sqlConnection/*, ref sqlTransaction*/);
        }

        /// <summary>
        /// �P��̓��Ӑ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeWork">CustomerCustomerChangeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^�̃L�[�l����v���链�Ӑ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        private int ReadProc(ref CustomerCustomerChangeResultWork customerCustomerChangeResultWork, int readMode, ref SqlConnection sqlConnection/*, ref SqlTransaction sqlTransaction*/)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection/*, sqlTransaction*/);

                #region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                // --- ADD 2009/05/22 -------->>>
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                // --- ADD 2009/05/22 -------->>>
                // --- ADD 2009/04/07 -------->>>
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                // --- ADD 2009/04/07 --------<<<
                // --- ADD  ���r��  2010/01/20 ---------->>>>>
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
�@�@�@�@�@�@�@�@sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
�@�@�@�@�@�@�@�@sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/01/20 ----------<<<<<
                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAMERF AS CLAIMNAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2" + Environment.NewLine;
                sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNM" + Environment.NewLine;
                sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,CLSC.SECTIONGUIDENMRF AS CLAIMSECTIONNAME" + Environment.NewLine;
                sqlText += " ,DBNK.GUIDENAMERF AS DEPOBANKNAME" + Environment.NewLine;
                sqlText += " ,WARE.WAREHOUSENAMERF AS CUSTWAREHOUSENAME" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAME" + Environment.NewLine;
                sqlText += " ,JBTP.GUIDENAMERF AS JOBTYPENAME" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAME" + Environment.NewLine;
                sqlText += " ,CHANG.CREDITMONEYRF" + Environment.NewLine;
                sqlText += " ,CHANG.WARNINGCREDITMONEYRF" + Environment.NewLine;
                sqlText += " ,CHANG.PRSNTACCRECBALANCERF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS CLSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMSECTIONCODERF = CLSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTWAREHOUSECDRF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- �̔��G���A�敪" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS DBNK" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = DBNK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.DEPOBANKCODERF = DBNK.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND DBNK.USERGUIDEDIVCDRF = 46  -- ��s�敪" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS JBTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = JBTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.JOBTYPECODERF = JBTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND JBTP.USERGUIDEDIVCDRF = 34  -- �E��敪" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- �Ǝ�敪" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERCHANGERF AS CHANG " + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CHANG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERCODERF = CHANG.CUSTOMERCODERF" + Environment.NewLine;

                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "      CUST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                #endregion  //[SELECT��]

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustomerCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToCustomerCustomerChangeWorkFromReader(ref myReader, ref customerCustomerChangeResultWork,0);
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerCustomerChangeDB.ReadProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        #endregion  //[Read]

        #region [Search]
        /// <summary>
        /// ���Ӑ�ꊇ�C�����̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeList">��������</param>
        /// <param name="customerCustomerChangeObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ꊇ�C���̃L�[�l����v����A�S�Ă̓��Ӑ�ꊇ�C�������擾���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        public int Search(ref object customerCustomerChangeList, object customerCustomerChangeObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList customerCustomerChangeArray = new ArrayList();

            try
            {
                CustomerCustomerChangeParamWork customerCustomerChangeParamWork = customerCustomerChangeObj as CustomerCustomerChangeParamWork;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref customerCustomerChangeArray, customerCustomerChangeParamWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            customerCustomerChangeList = customerCustomerChangeArray;

            return status;
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C�����̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeList">���Ӑ�ꊇ�C�������i�[���� ArrayList</param>
        /// <param name="customerCustomerChangeWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ꊇ�C���̃L�[�l����v����A�S�Ă̓��Ӑ�ꊇ�C����񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        public int Search(ref ArrayList customerCustomerChangeResultList, CustomerCustomerChangeParamWork customerCustomerChangeParamWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref customerCustomerChangeResultList, customerCustomerChangeParamWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C�����̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeList">���Ӑ�ꊇ�C�������i�[���� ArrayList</param>
        /// <param name="customerCustomerChangeWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�ꊇ�C���̃L�[�l����v����A�S�Ă̓��Ӑ�ꊇ�C����񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        /// <br>Update Note: 2012/07/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ���쌟��</br>
        private int SearchProc(ref ArrayList customerCustomerChangeList, CustomerCustomerChangeParamWork customerCustomerChangePramWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += " ,CUST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " ,CUST.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += " ,CUST.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += " ,CUST.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += " ,CUST.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSUBCODERF" + Environment.NewLine;
                sqlText += " ,CUST.NAMERF" + Environment.NewLine;
                sqlText += " ,CUST.NAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
                sqlText += " ,CUST.KANARF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
                sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.JOBTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.BUSINESSTYPECODERF" + Environment.NewLine;
                sqlText += " ,CUST.SALESAREACODERF" + Environment.NewLine;
                sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
                sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
                sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
                sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
                sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.SEARCHTELNORF" + Environment.NewLine;
                sqlText += " ,CUST.MNGSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.INPSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.BILLOUTPUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTCONDRF" + Environment.NewLine;
                sqlText += " ,CUST.COLLECTSIGHTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
                sqlText += " ,CUST.TRANSSTOPDATERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DMOUTNAMERF" + Environment.NewLine;
                sqlText += " ,CUST.MAINSENDMAILADDRCDRF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME1RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRKINDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILADDRESS2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDCODE2RF" + Environment.NewLine;
                sqlText += " ,CUST.MAILSENDNAME2RF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
                sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCEPTWHOLESALERF" + Environment.NewLine;
                sqlText += " ,CUST.CREDITMNGCODERF" + Environment.NewLine;
                sqlText += " ,CUST.DEPODELCODERF" + Environment.NewLine;
                sqlText += " ,CUST.ACCRECDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                sqlText += " ,CUST.PURECODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CONSTAXLAYMETHODRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO1RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO2RF" + Environment.NewLine;
                sqlText += " ,CUST.ACCOUNTNOINFO3RF" + Environment.NewLine;
                sqlText += " ,CUST.SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NTIMECALCSTDATERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERAGENTRF" + Environment.NewLine;
                sqlText += " ,CUST.CLAIMSECTIONCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CARMNGDIVCDRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIPARTSNOPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DEFSALESSLIPCDRF" + Environment.NewLine;
                sqlText += " ,CUST.LAVORRATERANKRF" + Environment.NewLine;
                sqlText += " ,CUST.SLIPTTLPRNRF" + Environment.NewLine;
                sqlText += " ,CUST.DEPOBANKCODERF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTWAREHOUSECDRF" + Environment.NewLine;
                sqlText += " ,CUST.QRCODEPRTCDRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORIFICTTLRF" + Environment.NewLine;
                sqlText += " ,CUST.DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE1RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE2RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE3RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE4RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE5RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE6RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE7RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE8RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE9RF" + Environment.NewLine;
                sqlText += " ,CUST.NOTE10RF" + Environment.NewLine;
                // --- ADD 2009/05/22 -------->>>
                sqlText += " ,CUST.SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,CUST.UOESLIPPRTDIVRF" + Environment.NewLine;
                // --- ADD 2009/05/22 -------->>>
                // --- ADD 2009/04/07 -------->>>
                sqlText += " ,CUST.RECEIPTOUTPUTCODERF" + Environment.NewLine;
                // --- ADD 2009/04/07 --------<<<
                // --- ADD  ���r��  2010/01/20 ---------->>>>>
                sqlText += " ,CUST.TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
�@�@�@�@�@�@�@�@sqlText += " ,CUST.DETAILBILLOUTPUTCODERF" + Environment.NewLine;
�@�@�@�@�@�@�@�@sqlText += " ,CUST.SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                // --- ADD  ���r��  2010/01/20 ----------<<<<<
                sqlText += " ,AREA.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAMERF AS CLAIMNAME" + Environment.NewLine;
                sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2" + Environment.NewLine;
                sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNM" + Environment.NewLine;
                sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNM" + Environment.NewLine;
                sqlText += " ,CLSC.SECTIONGUIDENMRF AS CLAIMSECTIONNAME" + Environment.NewLine;
                sqlText += " ,DBNK.GUIDENAMERF AS DEPOBANKNAME" + Environment.NewLine;
                sqlText += " ,WARE.WAREHOUSENAMERF AS CUSTWAREHOUSENAME" + Environment.NewLine;
                sqlText += " ,MGSC.SECTIONGUIDENMRF AS MNGSECTIONNAME" + Environment.NewLine;
                sqlText += " ,JBTP.GUIDENAMERF AS JOBTYPENAME" + Environment.NewLine;
                sqlText += " ,BSTP.GUIDENAMERF AS BUSINESSTYPENAME" + Environment.NewLine;
                sqlText += " ,CHANG.CREDITMONEYRF" + Environment.NewLine;
                sqlText += " ,CHANG.WARNINGCREDITMONEYRF" + Environment.NewLine;
                sqlText += " ,CHANG.PRSNTACCRECBALANCERF" + Environment.NewLine;

                // �|���O���[�v
                if (customerCustomerChangePramWork.SearchDiv == 1)
                {
                    sqlText += " ,RATEG.PURECODERF AS RATEPURECODERF" + Environment.NewLine;
                    sqlText += " ,RATEG.GOODSMAKERCDRF AS GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,RATEG.CUSTRATEGRPCODERF AS CUSTRATEGRPCODERF" + Environment.NewLine;
                    // ------ ADD START 2012/07/24 Redmine#30393 ������ for ���쌟��-------->>>>
                    sqlText += " ,RATEG.LOGICALDELETECODERF AS CUSTLOGICALDELETECODERF" + Environment.NewLine;
                    // ------ ADD END 2012/07/24 Redmine#30393 ������ for ���쌟��--------<<<<
                }
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS CLSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CLSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CLAIMSECTIONCODERF = CLSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN SECINFOSETRF AS MGSC" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = MGSC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.MNGSECTIONCODERF = MGSC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTWAREHOUSECDRF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS AREA" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = AREA.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.SALESAREACODERF = AREA.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND AREA.USERGUIDEDIVCDRF = 21  -- �̔��G���A�敪" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS DBNK" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = DBNK.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.DEPOBANKCODERF = DBNK.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND DBNK.USERGUIDEDIVCDRF = 46  -- ��s�敪" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS JBTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = JBTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.JOBTYPECODERF = JBTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND JBTP.USERGUIDEDIVCDRF = 34  -- �E��敪" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN USERGDBDURF AS BSTP" + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = BSTP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.BUSINESSTYPECODERF = BSTP.GUIDECODERF" + Environment.NewLine;
                sqlText += "    AND BSTP.USERGUIDEDIVCDRF = 33  -- �Ǝ�敪" + Environment.NewLine;
                sqlText += "  LEFT OUTER JOIN CUSTOMERCHANGERF AS CHANG " + Environment.NewLine;
                sqlText += "    ON  CUST.ENTERPRISECODERF = CHANG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERCODERF = CHANG.CUSTOMERCODERF" + Environment.NewLine;

                // �|���O���[�v
                if (customerCustomerChangePramWork.SearchDiv == 1)
                {
                    sqlText += "  LEFT OUTER JOIN CUSTRATEGROUPRF AS RATEG" + Environment.NewLine;
                    sqlText += "    ON  CUST.ENTERPRISECODERF = RATEG.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND CUST.CUSTOMERCODERF = RATEG.CUSTOMERCODERF" + Environment.NewLine;
                }

                
                # endregion
                sqlText += MakeWhereString(ref sqlCommand, customerCustomerChangePramWork, logicalMode);

                sqlCommand.CommandText = sqlText;

                myReader = sqlCommand.ExecuteReader();
                
                while (myReader.Read())
                {
                    customerCustomerChangeList.Add(this.CopyToCustomerCustomerChangeWorkFromReader(ref myReader, customerCustomerChangePramWork.SearchDiv));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerCustomerChangeDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        #endregion  //[Search]

        #region DEL 2009/04/10 
        #region [Write]
        /*
        /// <summary>
        /// ���Ӑ�ꊇ�C������ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeList">�ǉ��E�X�V���链�Ӑ�ꊇ�C�������܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : customerCustomerChangeList �Ɋi�[����Ă��链�Ӑ�ꊇ�C������ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        public int Write(ref object customerCustomerChangeList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = customerCustomerChangeList as ArrayList;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //write���s
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
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
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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

            return status;
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C������ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeList">�ǉ��E�X�V���链�Ӑ�ꊇ�C�������i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : customerCustomerChangeList �Ɋi�[����Ă��链�Ӑ�ꊇ�C������ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        public int Write(ref ArrayList customerCustomerChangeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref customerCustomerChangeList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C������ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="customerCustomerChangeList">�ǉ��E�X�V���链�Ӑ�ꊇ�C�������i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : customerCustomerChangeList �Ɋi�[����Ă��链�Ӑ�ꊇ�C������ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        private int WriteProc(ref ArrayList customerCustomerChangeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (customerCustomerChangeList != null)
                {
                    string selectTxt = string.Empty;
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    // �o�^�O�̓��Ӑ���p
                    CustomerCustomerChangeResultWork customerCustomerChangeResultWorkBef = new CustomerCustomerChangeResultWork();
                    //���Ӑ�}�X�^(�ϓ����)
                    CustomerChangeDB customerChangeDB = new CustomerChangeDB();
                    CustomerChangeWork customerChangeWork = new CustomerChangeWork();
                    int CusChangestatus = 0;

                    for (int i = 0; i < customerCustomerChangeList.Count; i++)
                    {
                        CustomerCustomerChangeResultWork customerCustomerChangeResultWork = customerCustomerChangeList[i] as CustomerCustomerChangeResultWork;

                        if (customerCustomerChangeResultWork != null)
                        {
                            // Read�p�R�l�N�V�������C���X�^���X��
                            SqlConnection sqlConnection_read = this.CreateSqlConnection(true);
                            //sqlConnection_read.Open();


                            customerCustomerChangeResultWorkBef.EnterpriseCode = customerCustomerChangeResultWork.EnterpriseCode;
                            customerCustomerChangeResultWorkBef.CustomerCode = customerCustomerChangeResultWork.CustomerCode;

                            // 2009/02/26 �N���b�V���Ή�>>>>>
                            //���}���u�Ƃ��Ė��ʂ�Read���폜
                            // ���Ӑ���擾�i�o�^�O�j
                            //status = this.Read(ref customerCustomerChangeResultWorkBef, 0, ref sqlConnection_read);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            // 2009/02/26 <<<<<<<<<<<<<<<<<<<

                            if (customerCustomerChangeResultWork.CreditMngCode == 1)
                            {
                                customerChangeWork.EnterpriseCode = customerCustomerChangeResultWork.EnterpriseCode;
                                customerChangeWork.CustomerCode = customerCustomerChangeResultWork.CustomerCode;
                                // ���Ӑ�}�X�^(�ϓ����)�擾
                                CusChangestatus = customerChangeDB.ReadProc(ref customerChangeWork, 0, ref sqlConnection_read);
                            }
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                            }
                            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                            {
                                // �Y���f�[�^�����̏ꍇ�͏����Ȃ�
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            sqlConnection_read.Close();
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            if (customerCustomerChangeResultWork != null)
                            {
                                status = this.WriteCustomerWork(ref customerCustomerChangeResultWork, ref sqlConnection, ref sqlTransaction);

                                //  ���Ӑ�}�X�^(�ϓ����)�������ݏ��� >>>
                                if (customerCustomerChangeResultWork.CreditMngCode == 1)
                                {
                                    // �X�V����(�����܂�)
                                    if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        //�p�����[�^�̃L���X�g
                                        ArrayList changeWorkparaList = new ArrayList();
                                        customerChangeWork.LogicalDeleteCode = 0;
                                        customerChangeWork.CreditMoney = customerCustomerChangeResultWork.CreditMoney;
                                        customerChangeWork.WarningCreditMoney = customerCustomerChangeResultWork.WarningCreditMoney;
                                        customerChangeWork.PrsntAccRecBalance = customerCustomerChangeResultWork.PrsntAccRecBalance;
                                        changeWorkparaList.Add(customerChangeWork);
                                        CusChangestatus = customerChangeDB.WriteProc(ref changeWorkparaList, ref sqlConnection, ref sqlTransaction);
                                    }

                                    // �V�K�쐬����
                                    if (CusChangestatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                                    {
                                        //�p�����[�^�̃L���X�g
                                        ArrayList changeWorkparaList = new ArrayList();
                                        customerChangeWork.CreditMoney = customerCustomerChangeResultWork.CreditMoney;
                                        customerChangeWork.WarningCreditMoney = customerCustomerChangeResultWork.WarningCreditMoney;
                                        customerChangeWork.PrsntAccRecBalance = customerCustomerChangeResultWork.PrsntAccRecBalance;
                                        changeWorkparaList.Add(customerChangeWork);
                                        CusChangestatus = customerChangeDB.WriteProc(ref changeWorkparaList, ref sqlConnection, ref sqlTransaction);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerCustomerChangeDB.WriteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {               
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            customerCustomerChangeList = al;

            return status;
        }
        # region ���Ӑ�f�[�^�o�^����
        /// <summary>
        /// ���Ӑ�f�[�^�o�^����
        /// </summary>
        /// <param name="customerCustomerChangeWork">�o�^�󓾈Ӑ��</param>
        /// <param name="sqlConnection">sql�R�l�N�V�����I�u�W�F�N�g</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="duplicationItemList">�d���G���[���̏d������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        /// </remarks>
        private int WriteCustomerWork(ref CustomerCustomerChangeResultWork customerCustomerChangeResultWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;

            try
            {
                // Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, CUSTOMERCODERF FROM CUSTOMERRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERCODERF=@FINDCUSTOMERCODE", sqlConnection, sqlTransaction))
                {
                    // Parameter�I�u�W�F�N�g�̃N���A
                    sqlCommand.Parameters.Clear();

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomercode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.EnterpriseCode);
                    findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustomerCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����

                        if (_updateDateTime != customerCustomerChangeResultWork.UpdateDateTime)
                        {
                            // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (customerCustomerChangeResultWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                            }

                            return status;
                        }

                        string sqlText = string.Empty;

                        # region [UPDATE��]
                        sqlText += "UPDATE CUSTOMERRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERSUBCODERF = @CUSTOMERSUBCODE" + Environment.NewLine;
                        sqlText += " ,NAMERF = @NAME" + Environment.NewLine;
                        sqlText += " ,NAME2RF = @NAME2" + Environment.NewLine;
                        sqlText += " ,HONORIFICTITLERF = @HONORIFICTITLE" + Environment.NewLine;
                        sqlText += " ,KANARF = @KANA" + Environment.NewLine;
                        sqlText += " ,CUSTOMERSNMRF = @CUSTOMERSNM" + Environment.NewLine;
                        sqlText += " ,OUTPUTNAMECODERF = @OUTPUTNAMECODE" + Environment.NewLine;
                        sqlText += " ,OUTPUTNAMERF = @OUTPUTNAME" + Environment.NewLine;
                        sqlText += " ,CORPORATEDIVCODERF = @CORPORATEDIVCODE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERATTRIBUTEDIVRF = @CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                        sqlText += " ,JOBTYPECODERF = @JOBTYPECODE" + Environment.NewLine;
                        sqlText += " ,BUSINESSTYPECODERF = @BUSINESSTYPECODE" + Environment.NewLine;
                        sqlText += " ,SALESAREACODERF = @SALESAREACODE" + Environment.NewLine;
                        sqlText += " ,POSTNORF = @POSTNO" + Environment.NewLine;
                        sqlText += " ,ADDRESS1RF = @ADDRESS1" + Environment.NewLine;
                        sqlText += " ,ADDRESS3RF = @ADDRESS3" + Environment.NewLine;
                        sqlText += " ,ADDRESS4RF = @ADDRESS4" + Environment.NewLine;
                        sqlText += " ,HOMETELNORF = @HOMETELNO" + Environment.NewLine;
                        sqlText += " ,OFFICETELNORF = @OFFICETELNO" + Environment.NewLine;
                        sqlText += " ,PORTABLETELNORF = @PORTABLETELNO" + Environment.NewLine;
                        sqlText += " ,HOMEFAXNORF = @HOMEFAXNO" + Environment.NewLine;
                        sqlText += " ,OFFICEFAXNORF = @OFFICEFAXNO" + Environment.NewLine;
                        sqlText += " ,OTHERSTELNORF = @OTHERSTELNO" + Environment.NewLine;
                        sqlText += " ,MAINCONTACTCODERF = @MAINCONTACTCODE" + Environment.NewLine;
                        sqlText += " ,SEARCHTELNORF = @SEARCHTELNO" + Environment.NewLine;
                        sqlText += " ,MNGSECTIONCODERF = @MNGSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,INPSECTIONCODERF = @INPSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE1RF = @CUSTANALYSCODE1" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE2RF = @CUSTANALYSCODE2" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE3RF = @CUSTANALYSCODE3" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE4RF = @CUSTANALYSCODE4" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE5RF = @CUSTANALYSCODE5" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE6RF = @CUSTANALYSCODE6" + Environment.NewLine;
                        sqlText += " ,BILLOUTPUTCODERF = @BILLOUTPUTCODE" + Environment.NewLine;
                        sqlText += " ,BILLOUTPUTNAMERF = @BILLOUTPUTNAME" + Environment.NewLine;
                        sqlText += " ,TOTALDAYRF = @TOTALDAY" + Environment.NewLine;
                        sqlText += " ,COLLECTMONEYCODERF = @COLLECTMONEYCODE" + Environment.NewLine;
                        sqlText += " ,COLLECTMONEYNAMERF = @COLLECTMONEYNAME" + Environment.NewLine;
                        sqlText += " ,COLLECTMONEYDAYRF = @COLLECTMONEYDAY" + Environment.NewLine;
                        sqlText += " ,COLLECTCONDRF = @COLLECTCOND" + Environment.NewLine;
                        sqlText += " ,COLLECTSIGHTRF = @COLLECTSIGHT" + Environment.NewLine;
                        sqlText += " ,CLAIMCODERF = @CLAIMCODE" + Environment.NewLine;
                        sqlText += " ,TRANSSTOPDATERF = @TRANSSTOPDATE" + Environment.NewLine;
                        sqlText += " ,DMOUTCODERF = @DMOUTCODE" + Environment.NewLine;
                        sqlText += " ,DMOUTNAMERF = @DMOUTNAME" + Environment.NewLine;
                        sqlText += " ,MAINSENDMAILADDRCDRF = @MAINSENDMAILADDRCD" + Environment.NewLine;
                        sqlText += " ,MAILADDRKINDCODE1RF = @MAILADDRKINDCODE1" + Environment.NewLine;
                        sqlText += " ,MAILADDRKINDNAME1RF = @MAILADDRKINDNAME1" + Environment.NewLine;
                        sqlText += " ,MAILADDRESS1RF = @MAILADDRESS1" + Environment.NewLine;
                        sqlText += " ,MAILSENDCODE1RF = @MAILSENDCODE1" + Environment.NewLine;
                        sqlText += " ,MAILSENDNAME1RF = @MAILSENDNAME1" + Environment.NewLine;
                        sqlText += " ,MAILADDRKINDCODE2RF = @MAILADDRKINDCODE2" + Environment.NewLine;
                        sqlText += " ,MAILADDRKINDNAME2RF = @MAILADDRKINDNAME2" + Environment.NewLine;
                        sqlText += " ,MAILADDRESS2RF = @MAILADDRESS2" + Environment.NewLine;
                        sqlText += " ,MAILSENDCODE2RF = @MAILSENDCODE2" + Environment.NewLine;
                        sqlText += " ,MAILSENDNAME2RF = @MAILSENDNAME2" + Environment.NewLine;
                        sqlText += " ,CUSTOMERAGENTCDRF = @CUSTOMERAGENTCD" + Environment.NewLine;
                        sqlText += " ,BILLCOLLECTERCDRF = @BILLCOLLECTERCD" + Environment.NewLine;
                        sqlText += " ,OLDCUSTOMERAGENTCDRF = @OLDCUSTOMERAGENTCD" + Environment.NewLine;
                        sqlText += " ,CUSTAGENTCHGDATERF = @CUSTAGENTCHGDATE" + Environment.NewLine;
                        sqlText += " ,ACCEPTWHOLESALERF = @ACCEPTWHOLESALE" + Environment.NewLine;
                        sqlText += " ,CREDITMNGCODERF = @CREDITMNGCODE" + Environment.NewLine;
                        sqlText += " ,DEPODELCODERF = @DEPODELCODE" + Environment.NewLine;
                        sqlText += " ,ACCRECDIVCDRF = @ACCRECDIVCD" + Environment.NewLine;
                        sqlText += " ,CUSTSLIPNOMNGCDRF = @CUSTSLIPNOMNGCD" + Environment.NewLine;
                        sqlText += " ,PURECODERF = @PURECODE" + Environment.NewLine;
                        sqlText += " ,CUSTCTAXLAYREFCDRF = @CUSTCTAXLAYREFCD" + Environment.NewLine;
                        sqlText += " ,CONSTAXLAYMETHODRF = @CONSTAXLAYMETHOD" + Environment.NewLine;
                        sqlText += " ,TOTALAMOUNTDISPWAYCDRF = @TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                        sqlText += " ,TOTALAMNTDSPWAYREFRF = @TOTALAMNTDSPWAYREF" + Environment.NewLine;
                        sqlText += " ,ACCOUNTNOINFO1RF = @ACCOUNTNOINFO1" + Environment.NewLine;
                        sqlText += " ,ACCOUNTNOINFO2RF = @ACCOUNTNOINFO2" + Environment.NewLine;
                        sqlText += " ,ACCOUNTNOINFO3RF = @ACCOUNTNOINFO3" + Environment.NewLine;
                        sqlText += " ,SALESUNPRCFRCPROCCDRF = @SALESUNPRCFRCPROCCD" + Environment.NewLine;
                        sqlText += " ,SALESMONEYFRCPROCCDRF = @SALESMONEYFRCPROCCD" + Environment.NewLine;
                        sqlText += " ,SALESCNSTAXFRCPROCCDRF = @SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                        sqlText += " ,CUSTOMERSLIPNODIVRF = @CUSTOMERSLIPNODIV" + Environment.NewLine;
                        sqlText += " ,NTIMECALCSTDATERF = @NTIMECALCSTDATE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERAGENTRF = @CUSTOMERAGENT" + Environment.NewLine;
                        sqlText += " ,CLAIMSECTIONCODERF = @CLAIMSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,CARMNGDIVCDRF = @CARMNGDIVCD" + Environment.NewLine;
                        sqlText += " ,BILLPARTSNOPRTCDRF = @BILLPARTSNOPRTCD" + Environment.NewLine;
                        sqlText += " ,DELIPARTSNOPRTCDRF = @DELIPARTSNOPRTCD" + Environment.NewLine;
                        sqlText += " ,DEFSALESSLIPCDRF = @DEFSALESSLIPCD" + Environment.NewLine;
                        sqlText += " ,LAVORRATERANKRF = @LAVORRATERANK" + Environment.NewLine;
                        sqlText += " ,SLIPTTLPRNRF = @SLIPTTLPRN" + Environment.NewLine;
                        sqlText += " ,DEPOBANKCODERF = @DEPOBANKCODE" + Environment.NewLine;
                        sqlText += " ,CUSTWAREHOUSECDRF = @CUSTWAREHOUSECD" + Environment.NewLine;
                        sqlText += " ,QRCODEPRTCDRF = @QRCODEPRTCD" + Environment.NewLine;
                        sqlText += " ,DELIHONORIFICTTLRF = @DELIHONORIFICTTL" + Environment.NewLine;
                        sqlText += " ,BILLHONORIFICTTLRF = @BILLHONORIFICTTL" + Environment.NewLine;
                        sqlText += " ,ESTMHONORIFICTTLRF = @ESTMHONORIFICTTL" + Environment.NewLine;
                        sqlText += " ,RECTHONORIFICTTLRF = @RECTHONORIFICTTL" + Environment.NewLine;
                        sqlText += " ,DELIHONORTTLPRTDIVRF = @DELIHONORTTLPRTDIV" + Environment.NewLine;
                        sqlText += " ,BILLHONORTTLPRTDIVRF = @BILLHONORTTLPRTDIV" + Environment.NewLine;
                        sqlText += " ,ESTMHONORTTLPRTDIVRF = @ESTMHONORTTLPRTDIV" + Environment.NewLine;
                        sqlText += " ,RECTHONORTTLPRTDIVRF = @RECTHONORTTLPRTDIV" + Environment.NewLine;
                        sqlText += " ,NOTE1RF = @NOTE1" + Environment.NewLine;
                        sqlText += " ,NOTE2RF = @NOTE2" + Environment.NewLine;
                        sqlText += " ,NOTE3RF = @NOTE3" + Environment.NewLine;
                        sqlText += " ,NOTE4RF = @NOTE4" + Environment.NewLine;
                        sqlText += " ,NOTE5RF = @NOTE5" + Environment.NewLine;
                        sqlText += " ,NOTE6RF = @NOTE6" + Environment.NewLine;
                        sqlText += " ,NOTE7RF = @NOTE7" + Environment.NewLine;
                        sqlText += " ,NOTE8RF = @NOTE8" + Environment.NewLine;
                        sqlText += " ,NOTE9RF = @NOTE9" + Environment.NewLine;
                        sqlText += " ,NOTE10RF = @NOTE10" + Environment.NewLine;
                        // --- ADD 2009/04/07 -------->>>
                        sqlText += " ,RECEIPTOUTPUTCODERF = @RECEIPTOUTPUTCODE" + Environment.NewLine;
                        // --- ADD 2009/04/07 --------<<<
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        // KEY�R�}���h���Đݒ�
                        findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.EnterpriseCode);
                        findParaCustomercode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustomerCode);

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerCustomerChangeResultWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (customerCustomerChangeResultWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                            if ((myReader != null) && (!myReader.IsClosed))
                            {
                                myReader.Close();
                            }

                            return status;
                        }

                        // �V�K�쐬����SQL���𐶐�

                        string sqlText = string.Empty;

                        # region [INSERT��]
                        sqlText += "INSERT INTO CUSTOMERRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERSUBCODERF" + Environment.NewLine;
                        sqlText += " ,NAMERF" + Environment.NewLine;
                        sqlText += " ,NAME2RF" + Environment.NewLine;
                        sqlText += " ,HONORIFICTITLERF" + Environment.NewLine;
                        sqlText += " ,KANARF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                        sqlText += " ,OUTPUTNAMECODERF" + Environment.NewLine;
                        sqlText += " ,OUTPUTNAMERF" + Environment.NewLine;
                        sqlText += " ,CORPORATEDIVCODERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERATTRIBUTEDIVRF" + Environment.NewLine;
                        sqlText += " ,JOBTYPECODERF" + Environment.NewLine;
                        sqlText += " ,BUSINESSTYPECODERF" + Environment.NewLine;
                        sqlText += " ,SALESAREACODERF" + Environment.NewLine;
                        sqlText += " ,POSTNORF" + Environment.NewLine;
                        sqlText += " ,ADDRESS1RF" + Environment.NewLine;
                        sqlText += " ,ADDRESS3RF" + Environment.NewLine;
                        sqlText += " ,ADDRESS4RF" + Environment.NewLine;
                        sqlText += " ,HOMETELNORF" + Environment.NewLine;
                        sqlText += " ,OFFICETELNORF" + Environment.NewLine;
                        sqlText += " ,PORTABLETELNORF" + Environment.NewLine;
                        sqlText += " ,HOMEFAXNORF" + Environment.NewLine;
                        sqlText += " ,OFFICEFAXNORF" + Environment.NewLine;
                        sqlText += " ,OTHERSTELNORF" + Environment.NewLine;
                        sqlText += " ,MAINCONTACTCODERF" + Environment.NewLine;
                        sqlText += " ,SEARCHTELNORF" + Environment.NewLine;
                        sqlText += " ,MNGSECTIONCODERF" + Environment.NewLine;
                        sqlText += " ,INPSECTIONCODERF" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE1RF" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE2RF" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE3RF" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE4RF" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE5RF" + Environment.NewLine;
                        sqlText += " ,CUSTANALYSCODE6RF" + Environment.NewLine;
                        sqlText += " ,BILLOUTPUTCODERF" + Environment.NewLine;
                        sqlText += " ,BILLOUTPUTNAMERF" + Environment.NewLine;
                        sqlText += " ,TOTALDAYRF" + Environment.NewLine;
                        sqlText += " ,COLLECTMONEYCODERF" + Environment.NewLine;
                        sqlText += " ,COLLECTMONEYNAMERF" + Environment.NewLine;
                        sqlText += " ,COLLECTMONEYDAYRF" + Environment.NewLine;
                        sqlText += " ,COLLECTCONDRF" + Environment.NewLine;
                        sqlText += " ,COLLECTSIGHTRF" + Environment.NewLine;
                        sqlText += " ,CLAIMCODERF" + Environment.NewLine;
                        sqlText += " ,TRANSSTOPDATERF" + Environment.NewLine;
                        sqlText += " ,DMOUTCODERF" + Environment.NewLine;
                        sqlText += " ,DMOUTNAMERF" + Environment.NewLine;
                        sqlText += " ,MAINSENDMAILADDRCDRF" + Environment.NewLine;
                        sqlText += " ,MAILADDRKINDCODE1RF" + Environment.NewLine;
                        sqlText += " ,MAILADDRKINDNAME1RF" + Environment.NewLine;
                        sqlText += " ,MAILADDRESS1RF" + Environment.NewLine;
                        sqlText += " ,MAILSENDCODE1RF" + Environment.NewLine;
                        sqlText += " ,MAILSENDNAME1RF" + Environment.NewLine;
                        sqlText += " ,MAILADDRKINDCODE2RF" + Environment.NewLine;
                        sqlText += " ,MAILADDRKINDNAME2RF" + Environment.NewLine;
                        sqlText += " ,MAILADDRESS2RF" + Environment.NewLine;
                        sqlText += " ,MAILSENDCODE2RF" + Environment.NewLine;
                        sqlText += " ,MAILSENDNAME2RF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                        sqlText += " ,BILLCOLLECTERCDRF" + Environment.NewLine;
                        sqlText += " ,OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
                        sqlText += " ,CUSTAGENTCHGDATERF" + Environment.NewLine;
                        sqlText += " ,ACCEPTWHOLESALERF" + Environment.NewLine;
                        sqlText += " ,CREDITMNGCODERF" + Environment.NewLine;
                        sqlText += " ,DEPODELCODERF" + Environment.NewLine;
                        sqlText += " ,ACCRECDIVCDRF" + Environment.NewLine;
                        sqlText += " ,CUSTSLIPNOMNGCDRF" + Environment.NewLine;
                        sqlText += " ,PURECODERF" + Environment.NewLine;
                        sqlText += " ,CUSTCTAXLAYREFCDRF" + Environment.NewLine;
                        sqlText += " ,CONSTAXLAYMETHODRF" + Environment.NewLine;
                        sqlText += " ,TOTALAMOUNTDISPWAYCDRF" + Environment.NewLine;
                        sqlText += " ,TOTALAMNTDSPWAYREFRF" + Environment.NewLine;
                        sqlText += " ,ACCOUNTNOINFO1RF" + Environment.NewLine;
                        sqlText += " ,ACCOUNTNOINFO2RF" + Environment.NewLine;
                        sqlText += " ,ACCOUNTNOINFO3RF" + Environment.NewLine;
                        sqlText += " ,SALESUNPRCFRCPROCCDRF" + Environment.NewLine;
                        sqlText += " ,SALESMONEYFRCPROCCDRF" + Environment.NewLine;
                        sqlText += " ,SALESCNSTAXFRCPROCCDRF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                        sqlText += " ,NTIMECALCSTDATERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERAGENTRF" + Environment.NewLine;
                        sqlText += " ,CLAIMSECTIONCODERF" + Environment.NewLine;
                        sqlText += " ,CARMNGDIVCDRF" + Environment.NewLine;
                        sqlText += " ,BILLPARTSNOPRTCDRF" + Environment.NewLine;
                        sqlText += " ,DELIPARTSNOPRTCDRF" + Environment.NewLine;
                        sqlText += " ,DEFSALESSLIPCDRF" + Environment.NewLine;
                        sqlText += " ,LAVORRATERANKRF" + Environment.NewLine;
                        sqlText += " ,SLIPTTLPRNRF" + Environment.NewLine;
                        sqlText += " ,DEPOBANKCODERF" + Environment.NewLine;
                        sqlText += " ,CUSTWAREHOUSECDRF" + Environment.NewLine;
                        sqlText += " ,QRCODEPRTCDRF" + Environment.NewLine;
                        sqlText += " ,DELIHONORIFICTTLRF" + Environment.NewLine;
                        sqlText += " ,BILLHONORIFICTTLRF" + Environment.NewLine;
                        sqlText += " ,ESTMHONORIFICTTLRF" + Environment.NewLine;
                        sqlText += " ,RECTHONORIFICTTLRF" + Environment.NewLine;
                        sqlText += " ,DELIHONORTTLPRTDIVRF" + Environment.NewLine;
                        sqlText += " ,BILLHONORTTLPRTDIVRF" + Environment.NewLine;
                        sqlText += " ,ESTMHONORTTLPRTDIVRF" + Environment.NewLine;
                        sqlText += " ,RECTHONORTTLPRTDIVRF" + Environment.NewLine;
                        sqlText += " ,NOTE1RF" + Environment.NewLine;
                        sqlText += " ,NOTE2RF" + Environment.NewLine;
                        sqlText += " ,NOTE3RF" + Environment.NewLine;
                        sqlText += " ,NOTE4RF" + Environment.NewLine;
                        sqlText += " ,NOTE5RF" + Environment.NewLine;
                        sqlText += " ,NOTE6RF" + Environment.NewLine;
                        sqlText += " ,NOTE7RF" + Environment.NewLine;
                        sqlText += " ,NOTE8RF" + Environment.NewLine;
                        sqlText += " ,NOTE9RF" + Environment.NewLine;
                        sqlText += " ,NOTE10RF" + Environment.NewLine;
                        // --- ADD 2009/04/07 -------->>>
                        sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                        // --- ADD 2009/04/07 --------<<<
                        sqlText += ")" + Environment.NewLine;
                        sqlText += "VALUES" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERSUBCODE" + Environment.NewLine;
                        sqlText += " ,@NAME" + Environment.NewLine;
                        sqlText += " ,@NAME2" + Environment.NewLine;
                        sqlText += " ,@HONORIFICTITLE" + Environment.NewLine;
                        sqlText += " ,@KANA" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERSNM" + Environment.NewLine;
                        sqlText += " ,@OUTPUTNAMECODE" + Environment.NewLine;
                        sqlText += " ,@OUTPUTNAME" + Environment.NewLine;
                        sqlText += " ,@CORPORATEDIVCODE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERATTRIBUTEDIV" + Environment.NewLine;
                        sqlText += " ,@JOBTYPECODE" + Environment.NewLine;
                        sqlText += " ,@BUSINESSTYPECODE" + Environment.NewLine;
                        sqlText += " ,@SALESAREACODE" + Environment.NewLine;
                        sqlText += " ,@POSTNO" + Environment.NewLine;
                        sqlText += " ,@ADDRESS1" + Environment.NewLine;
                        sqlText += " ,@ADDRESS3" + Environment.NewLine;
                        sqlText += " ,@ADDRESS4" + Environment.NewLine;
                        sqlText += " ,@HOMETELNO" + Environment.NewLine;
                        sqlText += " ,@OFFICETELNO" + Environment.NewLine;
                        sqlText += " ,@PORTABLETELNO" + Environment.NewLine;
                        sqlText += " ,@HOMEFAXNO" + Environment.NewLine;
                        sqlText += " ,@OFFICEFAXNO" + Environment.NewLine;
                        sqlText += " ,@OTHERSTELNO" + Environment.NewLine;
                        sqlText += " ,@MAINCONTACTCODE" + Environment.NewLine;
                        sqlText += " ,@SEARCHTELNO" + Environment.NewLine;
                        sqlText += " ,@MNGSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,@INPSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,@CUSTANALYSCODE1" + Environment.NewLine;
                        sqlText += " ,@CUSTANALYSCODE2" + Environment.NewLine;
                        sqlText += " ,@CUSTANALYSCODE3" + Environment.NewLine;
                        sqlText += " ,@CUSTANALYSCODE4" + Environment.NewLine;
                        sqlText += " ,@CUSTANALYSCODE5" + Environment.NewLine;
                        sqlText += " ,@CUSTANALYSCODE6" + Environment.NewLine;
                        sqlText += " ,@BILLOUTPUTCODE" + Environment.NewLine;
                        sqlText += " ,@BILLOUTPUTNAME" + Environment.NewLine;
                        sqlText += " ,@TOTALDAY" + Environment.NewLine;
                        sqlText += " ,@COLLECTMONEYCODE" + Environment.NewLine;
                        sqlText += " ,@COLLECTMONEYNAME" + Environment.NewLine;
                        sqlText += " ,@COLLECTMONEYDAY" + Environment.NewLine;
                        sqlText += " ,@COLLECTCOND" + Environment.NewLine;
                        sqlText += " ,@COLLECTSIGHT" + Environment.NewLine;
                        sqlText += " ,@CLAIMCODE" + Environment.NewLine;
                        sqlText += " ,@TRANSSTOPDATE" + Environment.NewLine;
                        sqlText += " ,@DMOUTCODE" + Environment.NewLine;
                        sqlText += " ,@DMOUTNAME" + Environment.NewLine;
                        sqlText += " ,@MAINSENDMAILADDRCD" + Environment.NewLine;
                        sqlText += " ,@MAILADDRKINDCODE1" + Environment.NewLine;
                        sqlText += " ,@MAILADDRKINDNAME1" + Environment.NewLine;
                        sqlText += " ,@MAILADDRESS1" + Environment.NewLine;
                        sqlText += " ,@MAILSENDCODE1" + Environment.NewLine;
                        sqlText += " ,@MAILSENDNAME1" + Environment.NewLine;
                        sqlText += " ,@MAILADDRKINDCODE2" + Environment.NewLine;
                        sqlText += " ,@MAILADDRKINDNAME2" + Environment.NewLine;
                        sqlText += " ,@MAILADDRESS2" + Environment.NewLine;
                        sqlText += " ,@MAILSENDCODE2" + Environment.NewLine;
                        sqlText += " ,@MAILSENDNAME2" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERAGENTCD" + Environment.NewLine;
                        sqlText += " ,@BILLCOLLECTERCD" + Environment.NewLine;
                        sqlText += " ,@OLDCUSTOMERAGENTCD" + Environment.NewLine;
                        sqlText += " ,@CUSTAGENTCHGDATE" + Environment.NewLine;
                        sqlText += " ,@ACCEPTWHOLESALE" + Environment.NewLine;
                        sqlText += " ,@CREDITMNGCODE" + Environment.NewLine;
                        sqlText += " ,@DEPODELCODE" + Environment.NewLine;
                        sqlText += " ,@ACCRECDIVCD" + Environment.NewLine;
                        sqlText += " ,@CUSTSLIPNOMNGCD" + Environment.NewLine;
                        sqlText += " ,@PURECODE" + Environment.NewLine;
                        sqlText += " ,@CUSTCTAXLAYREFCD" + Environment.NewLine;
                        sqlText += " ,@CONSTAXLAYMETHOD" + Environment.NewLine;
                        sqlText += " ,@TOTALAMOUNTDISPWAYCD" + Environment.NewLine;
                        sqlText += " ,@TOTALAMNTDSPWAYREF" + Environment.NewLine;
                        sqlText += " ,@ACCOUNTNOINFO1" + Environment.NewLine;
                        sqlText += " ,@ACCOUNTNOINFO2" + Environment.NewLine;
                        sqlText += " ,@ACCOUNTNOINFO3" + Environment.NewLine;
                        sqlText += " ,@SALESUNPRCFRCPROCCD" + Environment.NewLine;
                        sqlText += " ,@SALESMONEYFRCPROCCD" + Environment.NewLine;
                        sqlText += " ,@SALESCNSTAXFRCPROCCD" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERSLIPNODIV" + Environment.NewLine;
                        sqlText += " ,@NTIMECALCSTDATE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERAGENT" + Environment.NewLine;
                        sqlText += " ,@CLAIMSECTIONCODE" + Environment.NewLine;
                        sqlText += " ,@CARMNGDIVCD" + Environment.NewLine;
                        sqlText += " ,@BILLPARTSNOPRTCD" + Environment.NewLine;
                        sqlText += " ,@DELIPARTSNOPRTCD" + Environment.NewLine;
                        sqlText += " ,@DEFSALESSLIPCD" + Environment.NewLine;
                        sqlText += " ,@LAVORRATERANK" + Environment.NewLine;
                        sqlText += " ,@SLIPTTLPRN" + Environment.NewLine;
                        sqlText += " ,@DEPOBANKCODE" + Environment.NewLine;
                        sqlText += " ,@CUSTWAREHOUSECD" + Environment.NewLine;
                        sqlText += " ,@QRCODEPRTCD" + Environment.NewLine;
                        sqlText += " ,@DELIHONORIFICTTL" + Environment.NewLine;
                        sqlText += " ,@BILLHONORIFICTTL" + Environment.NewLine;
                        sqlText += " ,@ESTMHONORIFICTTL" + Environment.NewLine;
                        sqlText += " ,@RECTHONORIFICTTL" + Environment.NewLine;
                        sqlText += " ,@DELIHONORTTLPRTDIV" + Environment.NewLine;
                        sqlText += " ,@BILLHONORTTLPRTDIV" + Environment.NewLine;
                        sqlText += " ,@ESTMHONORTTLPRTDIV" + Environment.NewLine;
                        sqlText += " ,@RECTHONORTTLPRTDIV" + Environment.NewLine;
                        sqlText += " ,@NOTE1" + Environment.NewLine;
                        sqlText += " ,@NOTE2" + Environment.NewLine;
                        sqlText += " ,@NOTE3" + Environment.NewLine;
                        sqlText += " ,@NOTE4" + Environment.NewLine;
                        sqlText += " ,@NOTE5" + Environment.NewLine;
                        sqlText += " ,@NOTE6" + Environment.NewLine;
                        sqlText += " ,@NOTE7" + Environment.NewLine;
                        sqlText += " ,@NOTE8" + Environment.NewLine;
                        sqlText += " ,@NOTE9" + Environment.NewLine;
                        sqlText += " ,@NOTE10" + Environment.NewLine;
                        // --- ADD 2009/04/07 -------->>>
                        sqlText += " ,@RECEIPTOUTPUTCODE" + Environment.NewLine;
                        // --- ADD 2009/04/07 --------<<<
                        sqlText += ")" + Environment.NewLine;
                        # endregion

                        sqlCommand.CommandText = sqlText;

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)customerCustomerChangeResultWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if ((myReader != null) && (!myReader.IsClosed))
                    {
                        myReader.Close();
                    }

                    # region Parameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraCustomerSubCode = sqlCommand.Parameters.Add("@CUSTOMERSUBCODE", SqlDbType.NVarChar);
                    SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                    SqlParameter paraName2 = sqlCommand.Parameters.Add("@NAME2", SqlDbType.NVarChar);
                    SqlParameter paraHonorificTitle = sqlCommand.Parameters.Add("@HONORIFICTITLE", SqlDbType.NVarChar);
                    SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                    SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                    SqlParameter paraOutputNameCode = sqlCommand.Parameters.Add("@OUTPUTNAMECODE", SqlDbType.Int);
                    SqlParameter paraOutputName = sqlCommand.Parameters.Add("@OUTPUTNAME", SqlDbType.NVarChar);
                    SqlParameter paraCorporateDivCode = sqlCommand.Parameters.Add("@CORPORATEDIVCODE", SqlDbType.Int);
                    SqlParameter paraCustomerAttributeDiv = sqlCommand.Parameters.Add("@CUSTOMERATTRIBUTEDIV", SqlDbType.Int);
                    SqlParameter paraJobTypeCode = sqlCommand.Parameters.Add("@JOBTYPECODE", SqlDbType.Int);
                    SqlParameter paraBusinessTypeCode = sqlCommand.Parameters.Add("@BUSINESSTYPECODE", SqlDbType.Int);
                    SqlParameter paraSalesAreaCode = sqlCommand.Parameters.Add("@SALESAREACODE", SqlDbType.Int);
                    SqlParameter paraPostNo = sqlCommand.Parameters.Add("@POSTNO", SqlDbType.NVarChar);
                    SqlParameter paraAddress1 = sqlCommand.Parameters.Add("@ADDRESS1", SqlDbType.NVarChar);
                    SqlParameter paraAddress3 = sqlCommand.Parameters.Add("@ADDRESS3", SqlDbType.NVarChar);
                    SqlParameter paraAddress4 = sqlCommand.Parameters.Add("@ADDRESS4", SqlDbType.NVarChar);
                    SqlParameter paraHomeTelNo = sqlCommand.Parameters.Add("@HOMETELNO", SqlDbType.NVarChar);
                    SqlParameter paraOfficeTelNo = sqlCommand.Parameters.Add("@OFFICETELNO", SqlDbType.NVarChar);
                    SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                    SqlParameter paraHomeFaxNo = sqlCommand.Parameters.Add("@HOMEFAXNO", SqlDbType.NVarChar);
                    SqlParameter paraOfficeFaxNo = sqlCommand.Parameters.Add("@OFFICEFAXNO", SqlDbType.NVarChar);
                    SqlParameter paraOthersTelNo = sqlCommand.Parameters.Add("@OTHERSTELNO", SqlDbType.NVarChar);
                    SqlParameter paraMainContactCode = sqlCommand.Parameters.Add("@MAINCONTACTCODE", SqlDbType.Int);
                    SqlParameter paraSearchTelNo = sqlCommand.Parameters.Add("@SEARCHTELNO", SqlDbType.NChar);
                    SqlParameter paraMngSectionCode = sqlCommand.Parameters.Add("@MNGSECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraInpSectionCode = sqlCommand.Parameters.Add("@INPSECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraCustAnalysCode1 = sqlCommand.Parameters.Add("@CUSTANALYSCODE1", SqlDbType.Int);
                    SqlParameter paraCustAnalysCode2 = sqlCommand.Parameters.Add("@CUSTANALYSCODE2", SqlDbType.Int);
                    SqlParameter paraCustAnalysCode3 = sqlCommand.Parameters.Add("@CUSTANALYSCODE3", SqlDbType.Int);
                    SqlParameter paraCustAnalysCode4 = sqlCommand.Parameters.Add("@CUSTANALYSCODE4", SqlDbType.Int);
                    SqlParameter paraCustAnalysCode5 = sqlCommand.Parameters.Add("@CUSTANALYSCODE5", SqlDbType.Int);
                    SqlParameter paraCustAnalysCode6 = sqlCommand.Parameters.Add("@CUSTANALYSCODE6", SqlDbType.Int);
                    SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@BILLOUTPUTCODE", SqlDbType.Int);
                    SqlParameter paraBillOutputName = sqlCommand.Parameters.Add("@BILLOUTPUTNAME", SqlDbType.NVarChar);
                    SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@TOTALDAY", SqlDbType.Int);
                    SqlParameter paraCollectMoneyCode = sqlCommand.Parameters.Add("@COLLECTMONEYCODE", SqlDbType.Int);
                    SqlParameter paraCollectMoneyName = sqlCommand.Parameters.Add("@COLLECTMONEYNAME", SqlDbType.NVarChar);
                    SqlParameter paraCollectMoneyDay = sqlCommand.Parameters.Add("@COLLECTMONEYDAY", SqlDbType.Int);
                    SqlParameter paraCollectCond = sqlCommand.Parameters.Add("@COLLECTCOND", SqlDbType.Int);
                    SqlParameter paraCollectSight = sqlCommand.Parameters.Add("@COLLECTSIGHT", SqlDbType.Int);
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                    SqlParameter paraTransStopDate = sqlCommand.Parameters.Add("@TRANSSTOPDATE", SqlDbType.Int);
                    SqlParameter paraDmOutCode = sqlCommand.Parameters.Add("@DMOUTCODE", SqlDbType.Int);
                    SqlParameter paraDmOutName = sqlCommand.Parameters.Add("@DMOUTNAME", SqlDbType.NVarChar);
                    SqlParameter paraMainSendMailAddrCd = sqlCommand.Parameters.Add("@MAINSENDMAILADDRCD", SqlDbType.Int);
                    SqlParameter paraMailAddrKindCode1 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE1", SqlDbType.Int);
                    SqlParameter paraMailAddrKindName1 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME1", SqlDbType.NVarChar);
                    SqlParameter paraMailAddress1 = sqlCommand.Parameters.Add("@MAILADDRESS1", SqlDbType.NVarChar);
                    SqlParameter paraMailSendCode1 = sqlCommand.Parameters.Add("@MAILSENDCODE1", SqlDbType.Int);
                    SqlParameter paraMailSendName1 = sqlCommand.Parameters.Add("@MAILSENDNAME1", SqlDbType.NVarChar);
                    SqlParameter paraMailAddrKindCode2 = sqlCommand.Parameters.Add("@MAILADDRKINDCODE2", SqlDbType.Int);
                    SqlParameter paraMailAddrKindName2 = sqlCommand.Parameters.Add("@MAILADDRKINDNAME2", SqlDbType.NVarChar);
                    SqlParameter paraMailAddress2 = sqlCommand.Parameters.Add("@MAILADDRESS2", SqlDbType.NVarChar);
                    SqlParameter paraMailSendCode2 = sqlCommand.Parameters.Add("@MAILSENDCODE2", SqlDbType.Int);
                    SqlParameter paraMailSendName2 = sqlCommand.Parameters.Add("@MAILSENDNAME2", SqlDbType.NVarChar);
                    SqlParameter paraCustomerAgentCd = sqlCommand.Parameters.Add("@CUSTOMERAGENTCD", SqlDbType.NChar);
                    SqlParameter paraBillCollecterCd = sqlCommand.Parameters.Add("@BILLCOLLECTERCD", SqlDbType.NChar);
                    SqlParameter paraOldCustomerAgentCd = sqlCommand.Parameters.Add("@OLDCUSTOMERAGENTCD", SqlDbType.NChar);
                    SqlParameter paraCustAgentChgDate = sqlCommand.Parameters.Add("@CUSTAGENTCHGDATE", SqlDbType.Int);
                    SqlParameter paraAcceptWholeSale = sqlCommand.Parameters.Add("@ACCEPTWHOLESALE", SqlDbType.Int);
                    SqlParameter paraCreditMngCode = sqlCommand.Parameters.Add("@CREDITMNGCODE", SqlDbType.Int);
                    SqlParameter paraDepoDelCode = sqlCommand.Parameters.Add("@DEPODELCODE", SqlDbType.Int);
                    SqlParameter paraAccRecDivCd = sqlCommand.Parameters.Add("@ACCRECDIVCD", SqlDbType.Int);
                    SqlParameter paraCustSlipNoMngCd = sqlCommand.Parameters.Add("@CUSTSLIPNOMNGCD", SqlDbType.Int);
                    SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                    SqlParameter paraCustCTaXLayRefCd = sqlCommand.Parameters.Add("@CUSTCTAXLAYREFCD", SqlDbType.Int);
                    SqlParameter paraConsTaxLayMethod = sqlCommand.Parameters.Add("@CONSTAXLAYMETHOD", SqlDbType.Int);
                    SqlParameter paraTotalAmountDispWayCd = sqlCommand.Parameters.Add("@TOTALAMOUNTDISPWAYCD", SqlDbType.Int);
                    SqlParameter paraTotalAmntDspWayRef = sqlCommand.Parameters.Add("@TOTALAMNTDSPWAYREF", SqlDbType.Int);
                    SqlParameter paraAccountNoInfo1 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO1", SqlDbType.NVarChar);
                    SqlParameter paraAccountNoInfo2 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO2", SqlDbType.NVarChar);
                    SqlParameter paraAccountNoInfo3 = sqlCommand.Parameters.Add("@ACCOUNTNOINFO3", SqlDbType.NVarChar);
                    SqlParameter paraSalesUnPrcFrcProcCd = sqlCommand.Parameters.Add("@SALESUNPRCFRCPROCCD", SqlDbType.Int);
                    SqlParameter paraSalesMoneyFrcProcCd = sqlCommand.Parameters.Add("@SALESMONEYFRCPROCCD", SqlDbType.Int);
                    SqlParameter paraSalesCnsTaxFrcProcCd = sqlCommand.Parameters.Add("@SALESCNSTAXFRCPROCCD", SqlDbType.Int);
                    SqlParameter paraCustomerSlipNoDiv = sqlCommand.Parameters.Add("@CUSTOMERSLIPNODIV", SqlDbType.Int);
                    SqlParameter paraNTimeCalcStDate = sqlCommand.Parameters.Add("@NTIMECALCSTDATE", SqlDbType.Int);
                    SqlParameter paraCustomerAgent = sqlCommand.Parameters.Add("@CUSTOMERAGENT", SqlDbType.NVarChar);
                    SqlParameter paraClaimSectionCode = sqlCommand.Parameters.Add("@CLAIMSECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraCarMngDivCd = sqlCommand.Parameters.Add("@CARMNGDIVCD", SqlDbType.Int);
                    SqlParameter paraBillPartsNoPrtCd = sqlCommand.Parameters.Add("@BILLPARTSNOPRTCD", SqlDbType.Int);
                    SqlParameter paraDeliPartsNoPrtCd = sqlCommand.Parameters.Add("@DELIPARTSNOPRTCD", SqlDbType.Int);
                    SqlParameter paraDefSalesSlipCd = sqlCommand.Parameters.Add("@DEFSALESSLIPCD", SqlDbType.Int);
                    SqlParameter paraLavorRateRank = sqlCommand.Parameters.Add("@LAVORRATERANK", SqlDbType.Int);
                    SqlParameter paraSlipTtlPrn = sqlCommand.Parameters.Add("@SLIPTTLPRN", SqlDbType.Int);
                    SqlParameter paraDepoBankCode = sqlCommand.Parameters.Add("@DEPOBANKCODE", SqlDbType.Int);
                    //SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.Int);// DEL 2008.12.10
                    SqlParameter paraCustWarehouseCd = sqlCommand.Parameters.Add("@CUSTWAREHOUSECD", SqlDbType.NChar); // ADD 2008.12.10
                    SqlParameter paraQrcodePrtCd = sqlCommand.Parameters.Add("@QRCODEPRTCD", SqlDbType.Int);
                    SqlParameter paraDeliHonorificTtl = sqlCommand.Parameters.Add("@DELIHONORIFICTTL", SqlDbType.NVarChar);
                    SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
                    SqlParameter paraEstmHonorificTtl = sqlCommand.Parameters.Add("@ESTMHONORIFICTTL", SqlDbType.NVarChar);
                    SqlParameter paraRectHonorificTtl = sqlCommand.Parameters.Add("@RECTHONORIFICTTL", SqlDbType.NVarChar);
                    SqlParameter paraDeliHonorTtlPrtDiv = sqlCommand.Parameters.Add("@DELIHONORTTLPRTDIV", SqlDbType.Int);
                    SqlParameter paraBillHonorTtlPrtDiv = sqlCommand.Parameters.Add("@BILLHONORTTLPRTDIV", SqlDbType.Int);
                    SqlParameter paraEstmHonorTtlPrtDiv = sqlCommand.Parameters.Add("@ESTMHONORTTLPRTDIV", SqlDbType.Int);
                    SqlParameter paraRectHonorTtlPrtDiv = sqlCommand.Parameters.Add("@RECTHONORTTLPRTDIV", SqlDbType.Int);
                    SqlParameter paraNote1 = sqlCommand.Parameters.Add("@NOTE1", SqlDbType.NVarChar);
                    SqlParameter paraNote2 = sqlCommand.Parameters.Add("@NOTE2", SqlDbType.NVarChar);
                    SqlParameter paraNote3 = sqlCommand.Parameters.Add("@NOTE3", SqlDbType.NVarChar);
                    SqlParameter paraNote4 = sqlCommand.Parameters.Add("@NOTE4", SqlDbType.NVarChar);
                    SqlParameter paraNote5 = sqlCommand.Parameters.Add("@NOTE5", SqlDbType.NVarChar);
                    SqlParameter paraNote6 = sqlCommand.Parameters.Add("@NOTE6", SqlDbType.NVarChar);
                    SqlParameter paraNote7 = sqlCommand.Parameters.Add("@NOTE7", SqlDbType.NVarChar);
                    SqlParameter paraNote8 = sqlCommand.Parameters.Add("@NOTE8", SqlDbType.NVarChar);
                    SqlParameter paraNote9 = sqlCommand.Parameters.Add("@NOTE9", SqlDbType.NVarChar);
                    SqlParameter paraNote10 = sqlCommand.Parameters.Add("@NOTE10", SqlDbType.NVarChar);
                    // --- ADD 2009/04/07 -------->>>
                    SqlParameter paraReceiptOutputCode = sqlCommand.Parameters.Add("@RECEIPTOUTPUTCODE", SqlDbType.Int);
                    // --- ADD 2009/04/07 --------<<<
                    # endregion

                    # region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerCustomerChangeResultWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(customerCustomerChangeResultWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(customerCustomerChangeResultWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.LogicalDeleteCode);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustomerCode);
                    paraCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.CustomerSubCode);
                    paraName.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Name);
                    paraName2.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Name2);
                    paraHonorificTitle.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.HonorificTitle);
                    paraKana.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Kana);
                    paraCustomerSnm.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.CustomerSnm);
                    paraOutputNameCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.OutputNameCode);
                    paraOutputName.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.OutputName);
                    paraCorporateDivCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CorporateDivCode);
                    paraCustomerAttributeDiv.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustomerAttributeDiv);
                    paraJobTypeCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.JobTypeCode);
                    paraBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.BusinessTypeCode);
                    paraSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.SalesAreaCode);
                    paraPostNo.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.PostNo);
                    paraAddress1.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Address1);
                    paraAddress3.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Address3);
                    paraAddress4.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Address4);
                    paraHomeTelNo.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.HomeTelNo);
                    paraOfficeTelNo.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.OfficeTelNo);
                    paraPortableTelNo.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.PortableTelNo);
                    paraHomeFaxNo.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.HomeFaxNo);
                    paraOfficeFaxNo.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.OfficeFaxNo);
                    paraOthersTelNo.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.OthersTelNo);
                    paraMainContactCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.MainContactCode);
                    paraSearchTelNo.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.SearchTelNo);
                    paraMngSectionCode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.MngSectionCode);
                    paraInpSectionCode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.InpSectionCode);
                    paraCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustAnalysCode1);
                    paraCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustAnalysCode2);
                    paraCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustAnalysCode3);
                    paraCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustAnalysCode4);
                    paraCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustAnalysCode5);
                    paraCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustAnalysCode6);
                    paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.BillOutputCode);
                    paraBillOutputName.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.BillOutputName);
                    paraTotalDay.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.TotalDay);
                    paraCollectMoneyCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CollectMoneyCode);
                    paraCollectMoneyName.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.CollectMoneyName);
                    paraCollectMoneyDay.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CollectMoneyDay);
                    paraCollectCond.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CollectCond);
                    paraCollectSight.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CollectSight);
                    paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.ClaimCode);
                    paraTransStopDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerCustomerChangeResultWork.TransStopDate);
                    paraDmOutCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.DmOutCode);
                    paraDmOutName.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.DmOutName);
                    paraMainSendMailAddrCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.MainSendMailAddrCd);
                    paraMailAddrKindCode1.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.MailAddrKindCode1);
                    paraMailAddrKindName1.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.MailAddrKindName1);
                    paraMailAddress1.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.MailAddress1);
                    paraMailSendCode1.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.MailSendCode1);
                    paraMailSendName1.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.MailSendName1);
                    paraMailAddrKindCode2.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.MailAddrKindCode2);
                    paraMailAddrKindName2.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.MailAddrKindName2);
                    paraMailAddress2.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.MailAddress2);
                    paraMailSendCode2.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.MailSendCode2);
                    paraMailSendName2.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.MailSendName2);
                    paraCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.CustomerAgentCd);
                    paraBillCollecterCd.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.BillCollecterCd);
                    paraOldCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.OldCustomerAgentCd);
                    paraCustAgentChgDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(customerCustomerChangeResultWork.CustAgentChgDate);
                    paraAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.AcceptWholeSale);
                    paraCreditMngCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CreditMngCode);
                    paraDepoDelCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.DepoDelCode);
                    paraAccRecDivCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.AccRecDivCd);
                    paraCustSlipNoMngCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustSlipNoMngCd);
                    paraPureCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.PureCode);
                    paraCustCTaXLayRefCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustCTaXLayRefCd);
                    paraConsTaxLayMethod.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.ConsTaxLayMethod);
                    paraTotalAmountDispWayCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.TotalAmountDispWayCd);
                    paraTotalAmntDspWayRef.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.TotalAmntDspWayRef);
                    paraAccountNoInfo1.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.AccountNoInfo1);
                    paraAccountNoInfo2.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.AccountNoInfo2);
                    paraAccountNoInfo3.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.AccountNoInfo3);
                    paraSalesUnPrcFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.SalesUnPrcFrcProcCd);
                    paraSalesMoneyFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.SalesMoneyFrcProcCd);
                    paraSalesCnsTaxFrcProcCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.SalesCnsTaxFrcProcCd);
                    paraCustomerSlipNoDiv.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CustomerSlipNoDiv);
                    paraNTimeCalcStDate.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.NTimeCalcStDate);
                    paraCustomerAgent.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.CustomerAgent);
                    paraClaimSectionCode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.ClaimSectionCode);
                    paraCarMngDivCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.CarMngDivCd);
                    paraBillPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.BillPartsNoPrtCd);
                    paraDeliPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.DeliPartsNoPrtCd);
                    paraDefSalesSlipCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.DefSalesSlipCd);
                    paraLavorRateRank.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.LavorRateRank);
                    paraSlipTtlPrn.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.SlipTtlPrn);
                    paraDepoBankCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.DepoBankCode);
                    paraCustWarehouseCd.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.CustWarehouseCd);
                    paraQrcodePrtCd.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.QrcodePrtCd);
                    paraDeliHonorificTtl.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.DeliHonorificTtl);
                    paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.BillHonorificTtl);
                    paraEstmHonorificTtl.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.EstmHonorificTtl);
                    paraRectHonorificTtl.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.RectHonorificTtl);
                    paraDeliHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.DeliHonorTtlPrtDiv);
                    paraBillHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.BillHonorTtlPrtDiv);
                    paraEstmHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.EstmHonorTtlPrtDiv);
                    paraRectHonorTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.RectHonorTtlPrtDiv);
                    paraNote1.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Note1);
                    paraNote2.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Note2);
                    paraNote3.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Note3);
                    paraNote4.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Note4);
                    paraNote5.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Note5);
                    paraNote6.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Note6);
                    paraNote7.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Note7);
                    paraNote8.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Note8);
                    paraNote9.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Note9);
                    paraNote10.Value = SqlDataMediator.SqlSetString(customerCustomerChangeResultWork.Note10);
                    // --- ADD 2009/04/07 -------->>>
                    paraReceiptOutputCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeResultWork.ReceiptOutputCode);
                    // --- ADD 2009/04/07 --------<<<
                    # endregion

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "���Ӑ�}�X�^�̏����݂Ɏ��s���܂����B", ex.Number);
                sqlTransaction.Rollback();
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                if ((myReader != null) && (!myReader.IsClosed))
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            return status;
        }
        # endregion
        */
        #endregion  //[Write]
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="customerCustomerChangeParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustomerCustomerChangeParamWork customerCustomerChangeParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string wkstring = "";
            string retstring = " WHERE" + Environment.NewLine;;

            //��ƃR�[�h
            retstring += " CUST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeParamWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = " AND CUST.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = " AND CUST.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //�J�n���_�R�[�h
            if ((customerCustomerChangeParamWork.StMngSectionCode != "") && (customerCustomerChangeParamWork.StMngSectionCode != "00"))
            {
                retstring += " AND CUST.MNGSECTIONCODERF>=@STFINDSECTIONCODE";
                SqlParameter paraStSectionCode = sqlCommand.Parameters.Add("@STFINDSECTIONCODE", SqlDbType.NChar);
                paraStSectionCode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeParamWork.StMngSectionCode);
            }
            //�I�����_�R�[�h
            if ((customerCustomerChangeParamWork.EdMngSectionCode != "") && (customerCustomerChangeParamWork.EdMngSectionCode != "00"))
            {
                retstring += " AND CUST.MNGSECTIONCODERF<=@EDFINDSECTIONCODE";
                SqlParameter paraEdSectionCode = sqlCommand.Parameters.Add("@EDFINDSECTIONCODE", SqlDbType.NChar);
                paraEdSectionCode.Value = SqlDataMediator.SqlSetString(customerCustomerChangeParamWork.EdMngSectionCode);
            }

            // �J�n���Ӑ�R�[�h
            if (customerCustomerChangeParamWork.StCustomerCode != 0)
            {
                retstring += "  AND CUST.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE" + Environment.NewLine;
                SqlParameter findParaStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                findParaStCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeParamWork.StCustomerCode);
            }
            // �I�����Ӑ�R�[�h
            if ((customerCustomerChangeParamWork.EdCustomerCode != 0) && (customerCustomerChangeParamWork.EdCustomerCode != 99999999))
            {
                retstring += "  AND CUST.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter findParaEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                findParaEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeParamWork.EdCustomerCode);
            }
            // �J�n�J�i
            if (customerCustomerChangeParamWork.StKana != "")
            {
                if (customerCustomerChangeParamWork.StKana.LastIndexOf("*") >= 0)
                {
                    String[] StKana = customerCustomerChangeParamWork.StKana.Split(new Char[] { '*' });
                    retstring += " AND ( CUST.KANARF>=@STFINDKANA OR CUST.KANARF LIKE @STFINDKANA )" + Environment.NewLine;
                    SqlParameter paraStKana = sqlCommand.Parameters.Add("@STFINDKANA", SqlDbType.NVarChar);
                    paraStKana.Value = SqlDataMediator.SqlSetString(StKana[0] + "%");

                }
                else
                {
                    retstring += " AND CUST.KANARF>=@STFINDKANA";
                    SqlParameter paraStKana = sqlCommand.Parameters.Add("@STFINDKANA", SqlDbType.NChar);
                    paraStKana.Value = SqlDataMediator.SqlSetString(customerCustomerChangeParamWork.StKana);
                }
            }
            // �I���J�i
            if (customerCustomerChangeParamWork.EdKana != "")
            {
                if (customerCustomerChangeParamWork.EdKana.LastIndexOf("*") >= 0)
                {
                    String[] EdKana = customerCustomerChangeParamWork.EdKana.Split(new Char[] { '*' });
                    retstring += " AND ( CUST.KANARF<=@EDFINDKANA OR CUST.KANARF LIKE @EDFINDKANA )" + Environment.NewLine;
                    SqlParameter paraEdKana = sqlCommand.Parameters.Add("@EDFINDKANA", SqlDbType.NVarChar);
                    paraEdKana.Value = SqlDataMediator.SqlSetString(EdKana[0] + "%");
                }
                else
                {
                    retstring += " AND CUST.KANARF<=@EDFINDKANA";
                    SqlParameter paraEdKana = sqlCommand.Parameters.Add("@EDFINDKANA", SqlDbType.NChar);
                    paraEdKana.Value = SqlDataMediator.SqlSetString(customerCustomerChangeParamWork.EdKana);
                }
            }
            //�J�n�ڋq�S���]�ƈ��R�[�h
            if (customerCustomerChangeParamWork.StCustomerAgentCd != "")
            {
                retstring += " AND CUST.CUSTOMERAGENTCDRF>=@STFINDCUSTOMERAGENTCD";
                SqlParameter paraStCustomerAgentCd = sqlCommand.Parameters.Add("@STFINDCUSTOMERAGENTCD", SqlDbType.NChar);
                paraStCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerCustomerChangeParamWork.StCustomerAgentCd);
            }
            //�I���ڋq�S���]�ƈ��R�[�h CUSTOMERAGENTCDRF
            if (customerCustomerChangeParamWork.EdCustomerAgentCd != "")
            {
                retstring += " AND CUST.CUSTOMERAGENTCDRF<=@EDFINDCUSTOMERAGENTCD";
                SqlParameter paraEdCustomerAgentCd = sqlCommand.Parameters.Add("@EDFINDCUSTOMERAGENTCD", SqlDbType.NChar);
                paraEdCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerCustomerChangeParamWork.EdCustomerAgentCd);
            }
            // �J�n�̔��G���A�R�[�h
            if (customerCustomerChangeParamWork.StSalesAreaCode != 0)
            {
                retstring += "  AND CUST.SALESAREACODERF >= @STFINDSALESAREACODERF" + Environment.NewLine;
                SqlParameter findParaStSalesAreaCode = sqlCommand.Parameters.Add("@STFINDSALESAREACODERF", SqlDbType.Int);
                findParaStSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeParamWork.StSalesAreaCode);
            }
            // �I���̔��G���A�R�[�h
            if ((customerCustomerChangeParamWork.EdSalesAreaCode != 0) && (customerCustomerChangeParamWork.EdSalesAreaCode != 9999))
            {
                retstring += "  AND CUST.SALESAREACODERF <= @EDFINDSALESAREACODERF" + Environment.NewLine;
                SqlParameter findParaEdSalesAreaCode = sqlCommand.Parameters.Add("@EDFINDSALESAREACODERF", SqlDbType.Int);
                findParaEdSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeParamWork.EdSalesAreaCode);
            }
            // �J�n�Ǝ�R�[�h
            if (customerCustomerChangeParamWork.StBusinessTypeCode != 0)
            {
                retstring += "  AND CUST.BUSINESSTYPECODERF >= @STFINDBUSINESSTYPECODERF" + Environment.NewLine;
                SqlParameter findParaStBusinessTypeCode = sqlCommand.Parameters.Add("@STFINDBUSINESSTYPECODERF", SqlDbType.Int);
                findParaStBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeParamWork.StBusinessTypeCode);
            }
            // �J�n�Ǝ�R�[�h
            if ((customerCustomerChangeParamWork.EdBusinessTypeCode != 0) && (customerCustomerChangeParamWork.EdBusinessTypeCode != 9999))
            {
                retstring += "  AND CUST.BUSINESSTYPECODERF <= @EDFINDBUSINESSTYPECODERF" + Environment.NewLine;
                SqlParameter findParaEdBusinessTypeCode = sqlCommand.Parameters.Add("@EDFINDBUSINESSTYPECODERF", SqlDbType.Int);
                findParaEdBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(customerCustomerChangeParamWork.EdBusinessTypeCode);
            }

            #endregion  //WHERE���쐬
            return retstring;
        }
        #endregion  //[Where���쐬����]

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CustomerCustomerChangeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustomerCustomerChangeWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        /// </remarks>
        private CustomerCustomerChangeResultWork CopyToCustomerCustomerChangeWorkFromReader(ref SqlDataReader myReader, int SearchDiv)
        {
            CustomerCustomerChangeResultWork customerCustomerChangeResultWork = new CustomerCustomerChangeResultWork();

            this.CopyToCustomerCustomerChangeWorkFromReader(ref myReader, ref customerCustomerChangeResultWork, SearchDiv);

            return customerCustomerChangeResultWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CustomerCustomerChangeWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="customerCustomerChangeWork">CustomerCustomerChangeWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.11.10</br>
        /// <br>Update Note: 2012/07/24 ������</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 ��z�Č�</br>
        /// <br>             Redmine#30387  ���쌟��</br>
        /// </remarks>
        private void CopyToCustomerCustomerChangeWorkFromReader(ref SqlDataReader myReader, ref CustomerCustomerChangeResultWork customerCustomerChangeResultWork, int SearchDiv)
        {
            if (myReader != null && customerCustomerChangeResultWork != null)
            {
                # region [�i�[����]
                customerCustomerChangeResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                customerCustomerChangeResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                customerCustomerChangeResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                customerCustomerChangeResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                customerCustomerChangeResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                customerCustomerChangeResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                customerCustomerChangeResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                customerCustomerChangeResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                customerCustomerChangeResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                customerCustomerChangeResultWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                customerCustomerChangeResultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                customerCustomerChangeResultWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                customerCustomerChangeResultWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                customerCustomerChangeResultWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                customerCustomerChangeResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                customerCustomerChangeResultWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                customerCustomerChangeResultWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                customerCustomerChangeResultWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
                customerCustomerChangeResultWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERATTRIBUTEDIVRF"));
                customerCustomerChangeResultWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOBTYPECODERF"));
                customerCustomerChangeResultWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                customerCustomerChangeResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                customerCustomerChangeResultWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                customerCustomerChangeResultWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                customerCustomerChangeResultWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                customerCustomerChangeResultWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                customerCustomerChangeResultWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
                customerCustomerChangeResultWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
                customerCustomerChangeResultWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                customerCustomerChangeResultWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
                customerCustomerChangeResultWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
                customerCustomerChangeResultWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
                customerCustomerChangeResultWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
                customerCustomerChangeResultWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
                customerCustomerChangeResultWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                customerCustomerChangeResultWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                customerCustomerChangeResultWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                customerCustomerChangeResultWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                customerCustomerChangeResultWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                customerCustomerChangeResultWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                customerCustomerChangeResultWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                customerCustomerChangeResultWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                customerCustomerChangeResultWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));
                customerCustomerChangeResultWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
                customerCustomerChangeResultWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                customerCustomerChangeResultWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
                customerCustomerChangeResultWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
                customerCustomerChangeResultWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
                customerCustomerChangeResultWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
                customerCustomerChangeResultWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
                customerCustomerChangeResultWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                customerCustomerChangeResultWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TRANSSTOPDATERF"));
                customerCustomerChangeResultWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
                customerCustomerChangeResultWork.DmOutName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
                customerCustomerChangeResultWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
                customerCustomerChangeResultWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
                customerCustomerChangeResultWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
                customerCustomerChangeResultWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
                customerCustomerChangeResultWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
                customerCustomerChangeResultWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
                customerCustomerChangeResultWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
                customerCustomerChangeResultWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
                customerCustomerChangeResultWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
                customerCustomerChangeResultWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
                customerCustomerChangeResultWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
                customerCustomerChangeResultWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                customerCustomerChangeResultWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
                customerCustomerChangeResultWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
                customerCustomerChangeResultWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
                customerCustomerChangeResultWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
                customerCustomerChangeResultWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
                customerCustomerChangeResultWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODELCODERF"));
                customerCustomerChangeResultWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                customerCustomerChangeResultWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNOMNGCDRF"));
                customerCustomerChangeResultWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                customerCustomerChangeResultWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));
                customerCustomerChangeResultWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                customerCustomerChangeResultWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                customerCustomerChangeResultWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
                customerCustomerChangeResultWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                customerCustomerChangeResultWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                customerCustomerChangeResultWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                customerCustomerChangeResultWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));
                customerCustomerChangeResultWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));
                customerCustomerChangeResultWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
                customerCustomerChangeResultWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
                customerCustomerChangeResultWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                customerCustomerChangeResultWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTRF"));
                customerCustomerChangeResultWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                customerCustomerChangeResultWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGDIVCDRF"));
                customerCustomerChangeResultWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPARTSNOPRTCDRF"));
                customerCustomerChangeResultWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIPARTSNOPRTCDRF"));
                customerCustomerChangeResultWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSALESSLIPCDRF"));
                customerCustomerChangeResultWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAVORRATERANKRF"));
                customerCustomerChangeResultWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRNRF"));
                customerCustomerChangeResultWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOBANKCODERF"));
                customerCustomerChangeResultWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSECDRF"));
                customerCustomerChangeResultWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));
                customerCustomerChangeResultWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORIFICTTLRF"));
                customerCustomerChangeResultWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
                customerCustomerChangeResultWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORIFICTTLRF"));
                customerCustomerChangeResultWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORIFICTTLRF"));
                customerCustomerChangeResultWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIHONORTTLPRTDIVRF"));
                customerCustomerChangeResultWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLHONORTTLPRTDIVRF"));
                customerCustomerChangeResultWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMHONORTTLPRTDIVRF"));
                customerCustomerChangeResultWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECTHONORTTLPRTDIVRF"));
                customerCustomerChangeResultWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                customerCustomerChangeResultWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                customerCustomerChangeResultWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                customerCustomerChangeResultWork.Note4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                customerCustomerChangeResultWork.Note5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                customerCustomerChangeResultWork.Note6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                customerCustomerChangeResultWork.Note7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                customerCustomerChangeResultWork.Note8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                customerCustomerChangeResultWork.Note9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                customerCustomerChangeResultWork.Note10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                customerCustomerChangeResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAME"));
                customerCustomerChangeResultWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME"));
                customerCustomerChangeResultWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2"));
                customerCustomerChangeResultWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNM"));
                customerCustomerChangeResultWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNM"));
                customerCustomerChangeResultWork.OldCustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTNM"));
                customerCustomerChangeResultWork.ClaimSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONNAME"));
                customerCustomerChangeResultWork.DepoBankName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEPOBANKNAME"));
                customerCustomerChangeResultWork.CustWarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSENAME"));
                customerCustomerChangeResultWork.MngSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONNAME"));
                customerCustomerChangeResultWork.JobTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOBTYPENAME"));
                customerCustomerChangeResultWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAME"));

                // --- ADD 2009/04/07 -------->>>
                customerCustomerChangeResultWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
                // --- ADD 2009/04/07 --------<<<
                // --- ADD 2009/05/22 -------->>>
                customerCustomerChangeResultWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
                customerCustomerChangeResultWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
                customerCustomerChangeResultWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
                customerCustomerChangeResultWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
                customerCustomerChangeResultWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
                // --- ADD 2009/05/22 --------<<<
                // --- ADD  ���r��  2010/01/20 ---------->>>>>
                customerCustomerChangeResultWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));
                customerCustomerChangeResultWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));
                customerCustomerChangeResultWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));
                // --- ADD  ���r��  2010/01/20 ----------<<<<<

                // ���Ӑ�(�ϓ����)
                customerCustomerChangeResultWork.CreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CREDITMONEYRF"));
                customerCustomerChangeResultWork.WarningCreditMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("WARNINGCREDITMONEYRF"));
                customerCustomerChangeResultWork.PrsntAccRecBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRSNTACCRECBALANCERF"));
                if (SearchDiv == 1)
                {
                    // ���Ӑ�(�|��G)
                    customerCustomerChangeResultWork.RateGPureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEPURECODERF"));
                    customerCustomerChangeResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    customerCustomerChangeResultWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    // ------ ADD START 2012/07/24 Redmine#30393 ������ for ���쌟��-------->>>>
                    customerCustomerChangeResultWork.CustLogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTLOGICALDELETECODERF"));
                    // ------ ADD END 2012/07/24 Redmine#30393 ������ for ���쌟��--------<<<<
                }
                # endregion
            }
        }
        #endregion  //[�N���X�i�[����]
    }
}

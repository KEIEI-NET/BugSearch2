using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���Ӑ挟�������[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ�̎��f�[�^�������s���N���X�ł��B</br>
	/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
	/// <br>Date       : 2007.02.13</br>
    /// <br></br>
    /// <br>Update Note: �X�V������߂��悤�ɏC��</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.09.05</br>
    /// <br></br>
    /// <br>Update Note: ���Ӑ�`�[�ԍ��敪��߂��悤�ɏC��</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2009.02.10</br>
    /// <br></br>
    /// <br>Update Note: MANTIS:14720 ���Ӑ於�����ǉ�</br>
    /// <br>             MANTIS:14721 ���Ӑ挟�����ʂ̕\�����ڂɎ���FAX�ƋΖ���FAX��ǉ�</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date       : 2009/12/02</br>
    /// <br></br>
    /// <br>Update Note: �I�����C����ʋ敪 �ǉ�</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2010/04/06</br>
    /// <br></br>
    /// <br>Update Note: �ȒP�⍇���A�J�E���g�O���[�vID �ǉ�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/06/25</br>
    /// <br>Update Note: �d�b�ԍ������ǉ��Ɣ����C��</br>
    /// <br>Programmer : PM1012A �� ��</br>
    /// <br>Date       : 2010/08/06</br>
    /// <br>Update Note: ���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
    /// <br>Programmer : PM1107C ���юR</br>
    /// <br>Date       : 2011/07/22</br>
    /// <br>Update Note: PCC���Зp���Ӑ�K�C�h�ǉ�(#23705)</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011/08/19</br>
	/// <br></br>
	/// <br>Update Note: 2012.04.10 22024 ����@�_�u</br>
	/// <br>           : �P�D�ڋq�S���]�ƈ����̂��擾����悤�ɏC��</br>
    /// <br>Update Note: 2012.04.10 22024 ����@�_�u</br>
    /// <br>           : �P�D�������Ή�</br>
    /// <br>Update Note: 2012/05/10 30517 �Ė� �x��</br>
    /// <br>           : �e�[�u�����̎w��s���ɂ��s��C��</br>
    /// <br>Update Note: PM-Tablet�̉��C</br>
    /// <br>�Ǘ��ԍ�   :10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/05/29</br>
    /// <br>Update Note: �\�[�X�`�F�b�N�m�F�����ꗗNO.19�̑Ή�</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/06/13</br>
    /// <br>Update Note: �\�[�X�`�F�b�N�m�F�����ꗗNO.28�̑Ή�</br>
    /// <br>�Ǘ��ԍ�   : 10902622-01</br>
    /// <br>Programmer : wangl2</br>
    /// <br>Date       : 2013/06/17</br>
    /// </remarks>
	[Serializable]
	public class CustomerSearchDB : RemoteDB, ICustomerSearchDB
	{
		#region const

		//���Ӑ撊�o����
        private string selectStringCUSTOMER = "  CUSTOMERRF.LOGICALDELETECODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.ENTERPRISECODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMERCODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMERSUBCODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.NAMERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.NAME2RF" + Environment.NewLine +
                                              " ,CUSTOMERRF.HONORIFICTITLERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.KANARF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMERSNMRF" + Environment.NewLine +
                                              " ,CUSTOMERRF.SEARCHTELNORF" + Environment.NewLine +
                                              " ,CUSTOMERRF.HOMETELNORF" + Environment.NewLine +
                                              " ,CUSTOMERRF.OFFICETELNORF" + Environment.NewLine +
                                              " ,CUSTOMERRF.PORTABLETELNORF" + Environment.NewLine +
                                              " ,CUSTOMERRF.POSTNORF" + Environment.NewLine +
                                              " ,CUSTOMERRF.ADDRESS1RF" + Environment.NewLine +
                                              " ,CUSTOMERRF.ADDRESS3RF" + Environment.NewLine +
                                              " ,CUSTOMERRF.ADDRESS4RF" + Environment.NewLine +
                                              " ,CUSTOMERRF.ACCEPTWHOLESALERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.TOTALDAYRF" + Environment.NewLine +
                                              // --- ADD 2008/09/05 ---------->>>>>
                                              //" ,CUSTOMERRF.MNGSECTIONCODERF" + Environment.NewLine;
                                              " ,CUSTOMERRF.MNGSECTIONCODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.UPDATEDATETIMERF" + Environment.NewLine +
                                              // --- ADD 2008/09/05 ----------<<<<<
                                              // ADD 2009.02.10 >>>
                                              " ,CUSTOMERRF.CUSTOMERSLIPNODIVRF" + Environment.NewLine +
                                              // ADD 2009.02.10 <<<
                                              // ADD 2009.06.08 >>>
                                              // UPD 2012/05/10 >>>
                                              //" ,CUSTOMEREPCODERF" + Environment.NewLine +
                                              //" ,CUSTOMERSECCODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMEREPCODERF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMERSECCODERF" + Environment.NewLine +
                                              // UPD 2012/05/10 <<<
                                              // ADD 2009.06.08 <<<
                                              // ADD 2009.06.08 >>>
                                              // 2009/12/02 >>>
                                              //" ,CUSTOMERAGENTCDRF" + Environment.NewLine;
                                              // UPD 2012/05/10 >>>
                                              //" ,CUSTOMERAGENTCDRF" + Environment.NewLine +
                                              " ,CUSTOMERRF.CUSTOMERAGENTCDRF" + Environment.NewLine +
                                              // UPD 2012/05/10 <<<
            ////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
											  " ,EMPLOYEERF.NAMERF CUSTOMERAGENTNM" + Environment.NewLine +
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
                                              // 2009/12/02 <<<
                                              // ADD 2009.06.08 <<<
                                              // UPD 2012/05/10 >>>
                                              //" ,ONLINEKINDDIVRF" + Environment.NewLine + // 2010/04/06 Add
                                              //" ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine + // 2010/06/25 Add
                                              " ,CUSTOMERRF.ONLINEKINDDIVRF" + Environment.NewLine + // 2010/04/06 Add
                                              " ,CUSTOMERRF.SIMPLINQACNTACNTGRIDRF" + Environment.NewLine + // 2010/06/25 Add
                                              // UPD 2012/05/10 <<<
                                              // 2009/12/02 Add >>>
                                              ",CUSTOMERRF.HOMEFAXNORF" + Environment.NewLine +
                                              ",CUSTOMERRF.OFFICEFAXNORF" + Environment.NewLine;
                                              // 2009/12/02 Add <<<

        //���Ӑ�A������
		private const string joinStringCUSTOMER = "LEFT OUTER JOIN CUSTOMERRF ON (CARMAINRF.ENTERPRISECODERF = CUSTOMERRF.ENTERPRISECODERF AND CARMAINRF.CUSTOMERCODERF = CUSTOMERRF.CUSTOMERCODERF) ";
		#endregion

		#region constructor

		/// <summary>
		/// ���Ӑ挟�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
		/// <br>Date       : 2007.02.13</br>
		/// </remarks>
		public CustomerSearchDB()
		{
		}

		#endregion

		#region Search
		/// <summary>
		/// �w�肳�ꂽ�����̓��Ӑ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retObj">��������</param>
		/// <param name="paraObj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		public int Search(out object retObj, ref object paraObj, CustomerSearchReadMode readMode, ConstantManagement.LogicalMode logicalMode)
		{
			try
			{
				ArrayList retList = null;
				CustomerSearchParaWork customerSearchParaWork = null;
				customerSearchParaWork = (CustomerSearchParaWork)paraObj;

				int status = this.SearchProc(out retList, customerSearchParaWork, readMode, logicalMode);

				retObj = (object)retList;

				return status;
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "CustomerSearchDB.Search");
				retObj = new ArrayList();
				return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
		}
		#endregion
        // --------------- ADD START 2013/05/29 wangl2 FOR PM-Tablet------>>>>
        #region [SearchForTablet]
        /// <summary>
        /// PMTAB���Ӑ挟�����ʏ���S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        public int SearchForTablet(out object retObj, ref object paraObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            retObj = null;
            try
            {
                ArrayList retList = null;
                CustomerSearchParaWork customerSearchParaWork = null;
                customerSearchParaWork = (CustomerSearchParaWork)paraObj;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // PMTAB���Ӑ挟��
                status = this.SearchForTabletProc(out retList, customerSearchParaWork, ref sqlConnection, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retObj = (object)retList;
                }

                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustomerSearchDB.SearchForTablet");
                retObj = new ArrayList();
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
        /// PMTAB���Ӑ挟�����ʏ��LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="customerSearchParaWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchForTabletProc(out ArrayList retList, CustomerSearchParaWork customerSearchParaWork, ref SqlConnection sqlConnection,ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = null;
            ArrayList arrayList = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
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
                sqlText += " ,SALESSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,SHIPMSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ACPODRRSLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,ESTIMATEPRTDIVRF" + Environment.NewLine;
                sqlText += " ,UOESLIPPRTDIVRF" + Environment.NewLine;
                sqlText += " ,RECEIPTOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,CUSTOMEREPCODERF " + Environment.NewLine;
                sqlText += " ,CUSTOMERSECCODERF " + Environment.NewLine;
                sqlText += " ,ONLINEKINDDIVRF " + Environment.NewLine;
                sqlText += " ,TOTALBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,DETAILBILLOUTPUTCODERF" + Environment.NewLine;
                sqlText += " ,SLIPTTLBILLOUTPUTDIVRF" + Environment.NewLine;
                sqlText += " ,SIMPLINQACNTACNTGRIDRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += " CUSTOMERRF WITH(READUNCOMMITTED)" + Environment.NewLine;
                // Select�R�}���h�̐���
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += "WHERE" + Environment.NewLine;
                sqlCommand.CommandText += "ENTERPRISECODERF =@FINDENTERPRISECODE" + Environment.NewLine;
                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.EnterpriseCode);
                //�f�[�^�Ǎ��i�_���폜�敪�w��^�j
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand.CommandText += "AND  LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }//�f�[�^�Ǎ��i�_���폜�͈͎w��^�j
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand.CommandText += " AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    //�Ȃ�
                }
                // �J�i
                //if (customerSearchParaWork.Kana != string.Empty)// DEL 2013/06/13 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.19�̑Ή�
                if (!string.IsNullOrEmpty(customerSearchParaWork.Kana))// ADD 2013/06/13 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.19�̑Ή�
                {
                    // --------------- DEL START 2013/06/17 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.28�̑Ή� ------>>>>
                    //// ���Ӑ�J�i�����^�C�v(�O����v����)
                    //if (customerSearchParaWork.KanaSearchType == 0)
                    //{
                    //    sqlCommand.CommandText += "AND  KANARF  LIKE @FINDKANA" + Environment.NewLine;
                    //    SqlParameter findParaKana = sqlCommand.Parameters.Add("@FINDKANA", SqlDbType.NVarChar);
                    //    findParaKana.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.Kana + "%");
                    //}
                    //else 
                    //{
                    //    // ���Ӑ�J�i�����^�C�v(�B������)
                    //    sqlCommand.CommandText += "AND  KANARF  LIKE @FINDKANA" + Environment.NewLine;
                    //    SqlParameter findParaKana = sqlCommand.Parameters.Add("@FINDKANA", SqlDbType.NVarChar);
                    //    findParaKana.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.Kana + "%");
                    //}
                    // --------------- DEL END 2013/06/17 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.28�̑Ή� ------<<<<
                    // --------------- ADD START 2013/06/17 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.28�̑Ή� ------>>>>
                    switch (customerSearchParaWork.KanaSearchType)
                    {
                        case 1:
                            {
                                sqlCommand.CommandText += "AND  KANARF  LIKE @FINDKANA" + Environment.NewLine;
                                SqlParameter findParaKana = sqlCommand.Parameters.Add("@FINDKANA", SqlDbType.NVarChar);
                                findParaKana.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.Kana + "%");
                                break;
                            }
                        case 3:
                            {
                                if (customerSearchParaWork.Kana.Equals("�A"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'�A%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�C%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�E%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�G%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�I%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("�J"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'�J%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�L%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�N%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�P%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�R%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�K%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�M%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�O%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�Q%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�S%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�L��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�L��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�L��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�M��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�M��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�M��%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("�T"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'�T%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�V%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�X%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�Z%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�\%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�U%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�W%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�Y%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�[%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�]%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�V��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�V��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�V��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�W��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�W��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�W��%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("�^"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'�^%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�`%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�c%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�e%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�g%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�_%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�a%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�d%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�f%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�h%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�`��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�`��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�`��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�a��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�a��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�a��%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("�i"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'�i%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�j%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�k%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�l%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�m%'" + Environment.NewLine;


                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�j��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�j��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�j��%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("�n"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'�n%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�q%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�t%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�w%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�z%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�o%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�r%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�u%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�x%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�{%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�p%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�s%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�v%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�y%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�|%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�q��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�q��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�q��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�r��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�r��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�r��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�s��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�s��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�s��%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("�}"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'�}%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�~%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�~��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�~��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'�~��%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("��"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("��"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE" + "'��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + Environment.NewLine;

                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'����%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'����%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'����%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("��"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF LIKE " + "'��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF LIKE " + "'��%'" + ") " + Environment.NewLine;
                                }
                                else if (customerSearchParaWork.Kana.Equals("��"))
                                {
                                    sqlCommand.CommandText += "AND (KANARF <" + "'�A'" + Environment.NewLine;
                                    sqlCommand.CommandText += "OR KANARF >" + "'��'" + ") " + Environment.NewLine;
                                    sqlCommand.CommandText += "AND" + "(" + "NOT KANARF LIKE " + "'�A%'" + ") " + Environment.NewLine;
                                    sqlCommand.CommandText += "AND" + "(" + "NOT KANARF LIKE " + "'��%'" + ") " + Environment.NewLine;
                                }

                            }
                            break;
                    }
                    // --------------- ADD END 2013/06/17 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.28�̑Ή� ------<<<<
 
                }
                // ���Ӑ�R�[�h
                if (customerSearchParaWork.CustomerCode != 0)
                {
                    sqlCommand.CommandText += "AND  CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    // Parameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustomerCode);
                }
                // �Ǘ����_
                //if (customerSearchParaWork.MngSectionCode != string.Empty)// DEL 2013/06/13 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.19�̑Ή�
                if (!string.IsNullOrEmpty(customerSearchParaWork.MngSectionCode))// ADD 2013/06/13 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.19�̑Ή�
                {
                    sqlCommand.CommandText += " AND MNGSECTIONCODERF=@FINDMNGSECTIONCODE" + Environment.NewLine;
                    // Parameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaMngSectionCode = sqlCommand.Parameters.Add("@FINDMNGSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaMngSectionCode.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.MngSectionCode);
                }
                # endregion


                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    CustomerWork customerWork = new CustomerWork();
                    this.ReaderToCustomerWork(ref myReader, ref customerWork);
                    arrayList.Add(customerWork);
                }
                retList = arrayList;
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;// DEL 2013/06/13 wangl2 FOR �\�[�X�`�F�b�N�m�F�����ꗗNO.19�̑Ή�
                // --------------- ADD START 2013/06/13 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.19�̑Ή� ------>>>>
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // --------------- ADD END 2013/06/13 wangl2 FOR �\�[�X�`�F�b�N�m�F����NO.19�̑Ή� ------<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "PMTAB���Ӑ挟�����ʏ��̃f�[�^�̎擾�Ɏ��s���܂����B", ex.Number);
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
                    sqlCommand.Dispose();
                }

                // �R�l�N�V�����j��
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;

        }
        #endregion
        // --------------- ADD END 2013/05/29 wangl2 FOR PM-Tablet--------<<<<

        /// <summary>
		/// �w�肳�ꂽ���o�����̓��Ӑ�LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retList">��������</param>
		/// <param name="customerSearchParaWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		private int SearchProc(out ArrayList retList, CustomerSearchParaWork customerSearchParaWork, CustomerSearchReadMode readMode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

			SqlDataReader myReader = null;

			string selectString = "";
			string joinString = "";
			string whereStringADD = "";

			retList = new ArrayList();
			ArrayList al = new ArrayList();
			try
			{
				selectString = selectStringCUSTOMER;
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
				joinString = "LEFT JOIN EMPLOYEERF ON (EMPLOYEERF.ENTERPRISECODERF = CUSTOMERRF.ENTERPRISECODERF AND EMPLOYEERF.EMPLOYEECODERF = CUSTOMERRF.CUSTOMERAGENTCDRF) ";
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (connectionText == null || connectionText == "") return status;

				//SQL������
				sqlConnection = new SqlConnection(connectionText);
				sqlConnection.Open();

				SqlCommand sqlCommand;

				//�f�[�^�Ǎ��i�_���폜�敪�w��^�j
				if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
					(logicalMode == ConstantManagement.LogicalMode.GetData1) ||
					(logicalMode == ConstantManagement.LogicalMode.GetData2) ||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand = new SqlCommand("SELECT "
												+ selectString
												+ "FROM CUSTOMERRF "
												+ joinString
												+ "WHERE CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE "
												+ whereStringADD, sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				//�f�[�^�Ǎ��i�_���폜�͈͎w��^�j
				else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
							(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand = new SqlCommand("SELECT "
						+ selectString
						+ "FROM CUSTOMERRF "
						+ joinString
						+ "WHERE CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERRF.LOGICALDELETECODERF<@FINDLOGICALDELETECODE "
						+ whereStringADD, sqlConnection);

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}
				else
				{
					sqlCommand = new SqlCommand("SELECT"
						+ selectString
						+ "FROM CUSTOMERRF "
						+ joinString
						+ "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
				}
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.EnterpriseCode);
                //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
                //���Ӑ��ƃR�[�h,���Ӑ拒�_�R�[�h
                if (customerSearchParaWork.PccuoeMode != 0)
                {
                    sqlCommand.CommandText += " AND CUSTOMEREPCODERF IS NOT NULL ";
                    sqlCommand.CommandText += " AND CUSTOMERSECCODERF IS NOT NULL ";
                    //�I�����C����ʋ敪��10:SCM
                    sqlCommand.CommandText += " AND ONLINEKINDDIVRF = 10 ";
                }
                //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
				
				//�����������쐬
				sqlCommand.CommandText += MakeWhereString(ref sqlCommand, readMode, customerSearchParaWork);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					//Reader����N���X�𐶐�
					CustomerSearchRetWork wkCustomerSearchRetWork = this.MakeCustomerSearchRetWork(myReader);
                    //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 ----->>>>>
                    if (customerSearchParaWork.PccuoeMode != 0)
                    {
                        if (String.IsNullOrEmpty(wkCustomerSearchRetWork.CustomerEpCode.TrimEnd())
                            || String.IsNullOrEmpty(wkCustomerSearchRetWork.CustomerSecCode.TrimEnd()))
                        {
                            continue;
                        }
                    }
                    //-----ADD PCC���Зp���Ӑ�K�C�h�ǉ� for #23705 on 2011.08.19 -----<<<<<
					
					//ArrayList�֒ǉ�
					al.Add(wkCustomerSearchRetWork);
				}

				sqlCommand.Cancel();
				if (!myReader.IsClosed) myReader.Close();

				//�߂�l�L��Ȃ琳��Status���Z�b�g
				if (al.Count > 0)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (SqlException ex)
			{
				base.WriteSQLErrorLog(ex);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if (myReader != null && myReader.IsClosed == false)
				{
					myReader.Close();
                    myReader.Dispose();
				}

				if (sqlConnection != null)
				{
					sqlConnection.Close();
                    sqlConnection.Dispose();
				}
			}

			retList = al;

			return status;
		}

		#region �ڋq�������ʊi�[
		/// <summary>
		/// �ڋq�������ʊi�[
		/// </summary>
		/// <param name="myReader">DB�Ǎ�����</param>
		/// <returns>�ڋq��������</returns>
		private CustomerSearchRetWork MakeCustomerSearchRetWork(SqlDataReader myReader)
		{
			CustomerSearchRetWork wkCustomerSearchWork = new CustomerSearchRetWork();

			wkCustomerSearchWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
			wkCustomerSearchWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
			wkCustomerSearchWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
			wkCustomerSearchWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
			wkCustomerSearchWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
			wkCustomerSearchWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
			wkCustomerSearchWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
            wkCustomerSearchWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            wkCustomerSearchWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
			wkCustomerSearchWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
			wkCustomerSearchWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
			wkCustomerSearchWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
			wkCustomerSearchWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
			wkCustomerSearchWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
			wkCustomerSearchWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
			wkCustomerSearchWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
			wkCustomerSearchWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
			wkCustomerSearchWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
			wkCustomerSearchWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
            wkCustomerSearchWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
            // --- ADD 2008/09/05 ---------->>>>>
            wkCustomerSearchWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            // --- ADD 2008/09/05 ----------<<<<<
            // ADD 2009.02.10 >>>
            wkCustomerSearchWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
            // ADD 2009.02.10 <<< 
            // ADD 2009.06.09 >>>
            wkCustomerSearchWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));
            wkCustomerSearchWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));
            // ADD 2009.06.09 <<< 
            // ADD 2009.06.16 >>>
            wkCustomerSearchWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
            // ADD 2009.06.16 <<< 
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
			wkCustomerSearchWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNM"));
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
            // 2009/12/02 Add >>>
            wkCustomerSearchWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
            wkCustomerSearchWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
            // 2009/12/02 Add <<<
            wkCustomerSearchWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));    // 2010/04/06 Add
            wkCustomerSearchWork.SimplInqAcntAcntGrId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIMPLINQACNTACNTGRIDRF"));    // 2010/06/25 Add
            return wkCustomerSearchWork;
		}
		#endregion

		#region MakeWhereString
		/// <summary>
		/// �������������񐶐��{�����l�ݒ�
		/// </summary>
		/// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="customerSearchParaWork">���������i�[�N���X</param>
		/// <returns>Where����������</returns>
        /// <br>Update Note: ���Ӑ旪�̕\����ƌ����ǉ�(#826)</br>
        /// <br>Programmer : PM1107C ���юR</br>
        /// <br>Date       : 2011/07/22</br>
		private string MakeWhereString(ref SqlCommand sqlCommand, CustomerSearchReadMode readMode, CustomerSearchParaWork customerSearchParaWork)
		{
			//�߂�l������i�[�p�R���N�V����
			ArrayList ret = new ArrayList();

			//�ő�����������[�v�i���������������烋�[�v�������₷���Ɓj
            // 2009/12/02 >>>
            //for (int i = 0; i < 14; i++)
            // ---UPD 2010/08/06-------------------->>>
            //for (int i = 0; i < 15; i++)
            // 2011/7/22 XUJS EDIT STA>>>>>>
            //for (int i = 0; i < 16; i++)
            for (int i = 0; i < 17; i++)
            // 2011/7/22 XUJS EDIT END<<<<<<
            // ---UPD 2010/08/06--------------------<<<
            // 2009/12/02 <<<
            {
				int readModeWork = 0;
				// ��������
				if (readMode == CustomerSearchReadMode.CustomerSearchMode_All)
				{
					switch (i)
					{
						//���Ӑ�����`�F�b�N
						case 0: // ���Ӑ�R�[�h��0�Ȃ玟�̏�����
						{
							if (customerSearchParaWork.CustomerCode == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Code;
							break;
						}
						case 1: // ���Ӑ�T�u�R�[�h�����������null�Ȃ玟�̏�����
						{
							if ((customerSearchParaWork.CustomerSubCode == "") || (customerSearchParaWork.CustomerSubCode == null)) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_SubCode;
							break;
						}
						case 2: // ���Ӑ�d�b�ԍ�����
						{
							if ((customerSearchParaWork.SearchTelNo == "") || (customerSearchParaWork.SearchTelNo == null)) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Tel;
							break;
						}
						case 3: // ���Ӑ�J�i����
						{
							if ((customerSearchParaWork.Kana == "") || (customerSearchParaWork.Kana == null)) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Kana;
							break;
						}
						case 4: // ���Ӑ�敪����
						{
							readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerDiv;

							//if (customerSearchParaWork.SupplierDiv == 0) continue;
							//else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_SupplierDiv;
							break;
						}
						case 5: // �Ɣ̐�敪����
						{
							//if (customerSearchParaWork.AcceptWholeSale == 0) continue;
							//else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_AcceptWholeSale;
							break;
						}
						case 6: // ���̓R�[�h1����
						{
							if (customerSearchParaWork.CustAnalysCode1 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode1;
							break;
						}
						case 7: // ���̓R�[�h2����
						{
							if (customerSearchParaWork.CustAnalysCode2 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode2;
							break;
						}
						case 8: // ���̓R�[�h3����
						{
							if (customerSearchParaWork.CustAnalysCode3 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode3;
							break;
						}
						case 9: // ���̓R�[�h4����
						{
							if (customerSearchParaWork.CustAnalysCode4 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode4;
							break;
						}
						case 10: // ���̓R�[�h5����
						{
							if (customerSearchParaWork.CustAnalysCode5 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode5;
							break;
						}
						case 11: // ���̓R�[�h6����
						{
							if (customerSearchParaWork.CustAnalysCode6 == 0) continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode6;
							break;
						}
						case 12: // ���Ӑ�S���҃R�[�h����
						{
							if (customerSearchParaWork.CustomerAgentCd == "") continue;
							else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerAgentCd;
							break;
						}
                        case 13: // �Ǘ����_�R�[�h����
                        {
                            if (customerSearchParaWork.MngSectionCode == "") continue;
                            else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_MngSecCode;
                            break;
                        }
                        // 2009/12/02 Add >>>
                        case 14: // ���Ӑ於����
                        {
                            if ((customerSearchParaWork.Name == "") || (customerSearchParaWork.Name == null)) continue;
                            else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Name;
                            break;
                        }
                        // 2009/12/02 Add <<<
                        // ---ADD 2010/08/06-------------------->>>
                        case 15: // �d�b�ԍ�����
                            {
                                if ((customerSearchParaWork.TelNum == "") || (customerSearchParaWork.TelNum == null)) continue;
                                else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_TelNum;
                                break;
                            }
                        // ---ADD 2010/08/06--------------------<<<
                        // 2011/7/22 XUJS ADD STA>>>>>>
                        case 16: // ���Ӑ旪�̌���
                            {
                                if ((customerSearchParaWork.CustomerSnm == "") || (customerSearchParaWork.CustomerSnm == null)) continue;
                                else readModeWork = (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerSnm;
                                break;
                            }
                        // 2011/7/22 XUJS ADD END<<<<<<
                        default:
						{
							continue;
						}
					}
				}
				//���������ł͖����ꍇ�͈ꌏ�݂̂̏����ݒ�
				else
				{
					readModeWork = (int)readMode;
				}

				// ��������������̍쐬
				switch (readModeWork)
				{
					// ���Ӑ�}�X�^����
					// ���Ӑ�R�[�h����
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Code:
					{
						ret.Add("CUSTOMERRF.CUSTOMERCODERF=@FINDCUSTOMERCODE");
						SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
						findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustomerCode);
						break;
					}
					// ���Ӑ�T�u�R�[�h
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_SubCode:
					{
						// ���Ӑ�T�u�R�[�h�����^�C�v��0�̏ꍇ
						if (customerSearchParaWork.CustomerSubCodeSearchType == 0)
						{
							// �O����v����
                            // UPD 2012/05/10 >>>
                            //ret.Add("CUSTOMERSUBCODERF LIKE @FINDCUSTOMERSUBCODE");
                            ret.Add("CUSTOMERRF.CUSTOMERSUBCODERF LIKE @FINDCUSTOMERSUBCODE");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaCustomerSubCode = sqlCommand.Parameters.Add("@FINDCUSTOMERSUBCODE", SqlDbType.NVarChar);
							findParaCustomerSubCode.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.CustomerSubCode + "%");
						}
						// 0�ȊO�̏ꍇ
						else
						{
							// �����܂�����
                            // UPD 2012/05/10 >>>
                            //ret.Add("CUSTOMERSUBCODERF LIKE @FINDCUSTOMERSUBCODE");
                            ret.Add("CUSTOMERRF.CUSTOMERSUBCODERF LIKE @FINDCUSTOMERSUBCODE");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaCustomerSubCode = sqlCommand.Parameters.Add("@FINDCUSTOMERSUBCODE", SqlDbType.NVarChar);
							findParaCustomerSubCode.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.CustomerSubCode + "%");
						}
						break;
					}
					// ���Ӑ�d�b�ԍ�����
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Tel:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("SEARCHTELNORF=@FINDSEARCHTELNO");
                        ret.Add("CUSTOMERRF.SEARCHTELNORF=@FINDSEARCHTELNO");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaSearchTelNo = sqlCommand.Parameters.Add("@FINDSEARCHTELNO", SqlDbType.NChar);
						findParaSearchTelNo.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.SearchTelNo);
						break;
					}
					// ���Ӑ�J�i����
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Kana:
					{
						// �J�i�����^�C�v��0�̏ꍇ
						if (customerSearchParaWork.KanaSearchType == 0)
						{
							// �O����v����
                            // UPD 2012/05/10 >>>
                            //ret.Add("KANARF LIKE @FINDKANA");
                            ret.Add("CUSTOMERRF.KANARF LIKE @FINDKANA");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaKana = sqlCommand.Parameters.Add("@FINDKANA", SqlDbType.NVarChar);
							findParaKana.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.Kana + "%");
						}
						// 0�ȊO�̏ꍇ
						else
						{
							// �����܂�����
                            // UPD 2012/05/10 >>>
                            //ret.Add("KANARF LIKE @FINDKANA");
                            ret.Add("CUSTOMERRF.KANARF LIKE @FINDKANA");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaKana = sqlCommand.Parameters.Add("@FINDKANA", SqlDbType.NVarChar);
							findParaKana.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.Kana + "%");
						}
						break;
					}
					// ���Ӑ�敪
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerDiv:
                        {
                            // �Ɣ̐�敪 -1:�S�� 0:�Ɣ̐�ȊO 1:�Ɣ̐� 2:�[����
                            if (customerSearchParaWork.AcceptWholeSale > -1)
                            {
                                // UPD 2012/05/10 >>>
                                //ret.Add("ACCEPTWHOLESALERF = @FINDACCEPTWHOLESALE" + Environment.NewLine);
                                ret.Add("CUSTOMERRF.ACCEPTWHOLESALERF = @FINDACCEPTWHOLESALE" + Environment.NewLine);
                                // UPD 2012/05/10 <<<
                                sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.AcceptWholeSale);
                            }

                            # region [DELETE 2008.05.08]
                            /*
                            // ���Ӑ�{�d���� �̍i����
                            if (customerSearchParaWork.SupplierDiv == 1 && customerSearchParaWork.AcceptWholeSale == 1)
                            {
                                wrkWhere = "(SUPPLIERDIVRF IN (@FINDSUPPLIERDIV1, @FINDSUPPLIERDIV2) AND ACCEPTWHOLESALERF IN (@FINDACCEPTWHOLESALE1, @FINDACCEPTWHOLESALE2))" + Environment.NewLine;

                                sqlCommand.Parameters.Add("@FINDSUPPLIERDIV1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(0);
                                sqlCommand.Parameters.Add("@FINDSUPPLIERDIV2", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                                sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(0);
                                sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE2", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                            }
                            else
                            {
                                // ���Ӑ� �y�� ����(���Ӑ�{�d����) �̍i����
                                if ((customerSearchParaWork.AcceptWholeSale == 1) ||
                                    (customerSearchParaWork.AcceptWholeSale == 0 && customerSearchParaWork.SupplierDiv == -1))
                                {
                                    wrkWhere = "(SUPPLIERDIVRF IN (@FINDSUPPLIERDIV1, @FINDSUPPLIERDIV2) AND ACCEPTWHOLESALERF = @FINDACCEPTWHOLESALE1)" + Environment.NewLine;

                                    sqlCommand.Parameters.Add("@FINDSUPPLIERDIV1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(0);
                                    sqlCommand.Parameters.Add("@FINDSUPPLIERDIV2", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                                    sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                                }

                                // �d���� �y�� ����(���Ӑ�{�d����) �̍i����
                                if ((customerSearchParaWork.SupplierDiv == 1) ||
                                    (customerSearchParaWork.SupplierDiv == 0 && customerSearchParaWork.AcceptWholeSale == -1))
                                {
                                    wrkWhere = "(SUPPLIERDIVRF = @FINDSUPPLIERDIV1 AND ACCEPTWHOLESALERF IN (@FINDACCEPTWHOLESALE1, @FINDACCEPTWHOLESALE2))" + Environment.NewLine;

                                    sqlCommand.Parameters.Add("@FINDSUPPLIERDIV1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                                    sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE1", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(0);
                                    sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE2", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(1);
                                }

                                // �[���� �̍i����
                                if (customerSearchParaWork.SupplierDiv == -1 || customerSearchParaWork.AcceptWholeSale == -1)
                                {
                                    if (string.IsNullOrEmpty(wrkWhere))
                                    {
                                        wrkWhere += "SUPPLIERDIVRF = @FINDSUPPLIERDIV3 AND ACCEPTWHOLESALERF = @FINDACCEPTWHOLESALE3";
                                    }
                                    else
                                    {
                                        wrkWhere += "OR (SUPPLIERDIVRF = @FINDSUPPLIERDIV3 AND ACCEPTWHOLESALERF = @FINDACCEPTWHOLESALE3)";
                                    }

                                    sqlCommand.Parameters.Add("@FINDSUPPLIERDIV3", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(0);
                                    sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE3", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt32(2);
                                }
                            }

                            if (!string.IsNullOrEmpty(wrkWhere))
                            {
                                ret.Add(wrkWhere);
                            }
                            */
                            # endregion

                            break;
					}
					// �d����敪
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_SupplierDiv:
					{
                        //--- DEL 2008.05.08 --->>>
                        //ret.Add("SUPPLIERDIVRF=@FINDSUPPLIERDIV");
                        //SqlParameter findParaSupplierDiv = sqlCommand.Parameters.Add("@FINDSUPPLIERDIV", SqlDbType.Int);
                        //findParaSupplierDiv.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.SupplierDiv);
						//--- DEL 2008.05.08 ---<<<
                        break;
					}
					// �Ɣ̐�敪
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_AcceptWholeSale:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("ACCEPTWHOLESALERF=@FINDACCEPTWHOLESALE");
                        ret.Add("CUSTOMERRF.ACCEPTWHOLESALERF=@FINDACCEPTWHOLESALE");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaAcceptWholeSale = sqlCommand.Parameters.Add("@FINDACCEPTWHOLESALE", SqlDbType.Int);
						findParaAcceptWholeSale.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.AcceptWholeSale);
						break;
					}
					// ���̓R�[�h1
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode1:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE1RF=@FINDCUSTANALYSCODE1");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE1RF=@FINDCUSTANALYSCODE1");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode1 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE1", SqlDbType.Int);
						findParaCustAnalysCode1.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode1);
						break;
					}
					// ���̓R�[�h2
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode2:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE2RF=@FINDCUSTANALYSCODE2");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE2RF=@FINDCUSTANALYSCODE2");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode2 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE2", SqlDbType.Int);
						findParaCustAnalysCode2.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode2);
						break;
					}
					// ���̓R�[�h3
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode3:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE3RF=@FINDCUSTANALYSCODE3");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE3RF=@FINDCUSTANALYSCODE3");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode3 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE3", SqlDbType.Int);
						findParaCustAnalysCode3.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode3);
						break;
					}
					// ���̓R�[�h4
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode4:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE4RF=@FINDCUSTANALYSCODE4");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE4RF=@FINDCUSTANALYSCODE4");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode4 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE4", SqlDbType.Int);
						findParaCustAnalysCode4.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode4);
						break;
					}
					// ���̓R�[�h5
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode5:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE5RF=@FINDCUSTANALYSCODE5");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE5RF=@FINDCUSTANALYSCODE5");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode5 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE5", SqlDbType.Int);
						findParaCustAnalysCode5.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode5);
						break;
					}
					// ���̓R�[�h6
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustAnalysCode6:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTANALYSCODE6RF=@FINDCUSTANALYSCODE6");
                        ret.Add("CUSTOMERRF.CUSTANALYSCODE6RF=@FINDCUSTANALYSCODE6");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustAnalysCode6 = sqlCommand.Parameters.Add("@FINDCUSTANALYSCODE6", SqlDbType.Int);
						findParaCustAnalysCode6.Value = SqlDataMediator.SqlSetInt32(customerSearchParaWork.CustAnalysCode6);
						break;
					}
					// ���Ӑ�]�ƈ��R�[�h
					case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerAgentCd:
					{
                        // UPD 2012/05/10 >>>
                        //ret.Add("CUSTOMERAGENTCDRF=@FINDCUSTOMERAGENTCD");
                        ret.Add("CUSTOMERRF.CUSTOMERAGENTCDRF=@FINDCUSTOMERAGENTCD");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaCustomerAgentCd = sqlCommand.Parameters.Add("@FINDCUSTOMERAGENTCD", SqlDbType.NChar);
						findParaCustomerAgentCd.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.CustomerAgentCd);
						break;
					}
                    // �Ǘ����_�R�[�h
                    case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_MngSecCode:
                    {
                        // UPD 2012/05/10 >>>
                        //ret.Add("MNGSECTIONCODERF=@FINDMNGSECTIONCODE");
                        ret.Add("CUSTOMERRF.MNGSECTIONCODERF=@FINDMNGSECTIONCODE");
                        // UPD 2012/05/10 <<<
                        SqlParameter findParaMngSectionCode = sqlCommand.Parameters.Add("@FINDMNGSECTIONCODE", SqlDbType.NChar);
                        findParaMngSectionCode.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.MngSectionCode);
                        break;
                    }
					default:
					{
						break;
					}
                    // 2009/12/02 Add >>>
                    // ���Ӑ於����
                    case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_Name:
                    {
                        // ���Ӑ於�����^�C�v��0�̏ꍇ
                        if (customerSearchParaWork.NameSearchType == 0)
                        {
                            // �O����v����
                            // UPD 2012/05/10 >>>
                            //ret.Add("NAMERF LIKE @FINDNAME");
                            ret.Add("CUSTOMERRF.NAMERF LIKE @FINDNAME");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDNAME", SqlDbType.NVarChar);
                            findParaName.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.Name + "%");
                        }
                        // 0�ȊO�̏ꍇ
                        else
                        {
                            // �����܂�����
                            // UPD 2012/05/10 >>>
                            //ret.Add("NAMERF LIKE @FINDNAME");
                            ret.Add("CUSTOMERRF.NAMERF LIKE @FINDNAME");
                            // UPD 2012/05/10 <<<
                            SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDNAME", SqlDbType.NVarChar);
                            findParaName.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.Name + "%");
                        }
                        break;
                    }
                    // 2009/12/02 Add <<<
                    // ---ADD 2010/08/06-------------------->>>
                    // �d�b�ԍ�����
                    case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_TelNum:
                        {
                            // �d�b�ԍ������^�C�v��0�̏ꍇ
                            if (customerSearchParaWork.TelNumSearchType == 0)
                            {
                                // �O����v����

                                // UPD 2012/05/10 >>>
                                //ret.Add("REPLACE(OFFICETELNORF, '-', '') LIKE @FINDTELNUM");
                                ret.Add("REPLACE(CUSTOMERRF.OFFICETELNORF, '-', '') LIKE @FINDTELNUM");
                                // UPD 2012/05/10 <<<
                                SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDTELNUM", SqlDbType.NVarChar);
                                findParaName.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.TelNum.Replace("-", "") + "%");
                            }
                            // 0�ȊO�̏ꍇ
                            else
                            {
                                // �����܂�����
                                // UPD 2012/05/10 >>>
                                //ret.Add("REPLACE(OFFICETELNORF, '-', '') LIKE @FINDTELNUM");
                                ret.Add("REPLACE(CUSTOMERRF.OFFICETELNORF, '-', '') LIKE @FINDTELNUM");
                                // UPD 2012/05/10 <<<
                                SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDTELNUM", SqlDbType.NVarChar);
                                findParaName.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.TelNum.Replace("-", "") + "%");
                            }
                            break;
                        }
                    // ---ADD 2010/08/06--------------------<<<

                    // 2011/7/22 XUJS ADD STA>>>>>>
                    // ���Ӑ旪�̌���
                    case (int)CustomerSearchReadMode.CustomerSearchMode_Customer_CustomerSnm:
                        {
                            // ���Ӑ旪�̌����^�C�v��0�̏ꍇ
                            if (customerSearchParaWork.CustomerSnmSearchType == 0)
                            {
                                // �O����v����
                                // UPD 2012/05/10 >>>
                                //ret.Add("CUSTOMERSNMRF LIKE @FINDSNM");
                                ret.Add("CUSTOMERRF.CUSTOMERSNMRF LIKE @FINDSNM");
                                // UPD 2012/05/10 <<<
                                SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDSNM", SqlDbType.NVarChar);
                                findParaName.Value = SqlDataMediator.SqlSetString(customerSearchParaWork.CustomerSnm + "%");
                            }
                            // 0�ȊO�̏ꍇ
                            else
                            {
                                // �����܂�����
                                // UPD 2012/05/10 >>>
                                //ret.Add("CUSTOMERSNMRF LIKE @FINDSNM");
                                ret.Add("CUSTOMERRF.CUSTOMERSNMRF LIKE @FINDSNM");
                                // UPD 2012/05/10 <<<
                                SqlParameter findParaName = sqlCommand.Parameters.Add("@FINDSNM", SqlDbType.NVarChar);
                                findParaName.Value = SqlDataMediator.SqlSetString("%" + customerSearchParaWork.CustomerSnm + "%");
                            }
                            break;
                        }
                    // 2011/7/22 XUJS ADD END<<<<<<
				}

				//���������w��ł͖����ꍇ�̓��[�v�I��
				if (readMode != CustomerSearchReadMode.CustomerSearchMode_All) break;

			}//for end

			//�߂�l�����񐶐�(�J�n�T�C�Y���Ƃ肠����1024�ŏ�����)
            StringBuilder retString = new StringBuilder(1024);
            for (int ii = 0; ii < ret.Count; ii++)
			{
				retString.Append(" AND ");
				retString.Append(ret[ii]);
			}

			return retString.ToString();
		}

		#endregion
        // --------------- ADD START 2013.05.29 wangl2 FOR PM-Tablet------>>>>
        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : wangl2</br>
        /// <br>Date       : 2013/05/29</br>
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

        /// <summary>
        /// ���Ӑ�}�X�^�̓Ǎ�����(SqlDataReader)�𓾈Ӑ�}�X�^���[�N(CustomerWork)�Ɋi�[���܂��B
        /// </summary>
        /// <param name="myReader">���Ӑ�}�X�^�̓Ǎ�����</param>
        /// <param name="customerWork">���Ӑ�}�X�^���[�N</param>
        private void ReaderToCustomerWork(ref SqlDataReader myReader, ref CustomerWork customerWork)
        {
            if (myReader != null && customerWork != null)
            {
                # region [�i�[����]
                customerWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                customerWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                customerWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                customerWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                customerWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                customerWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                customerWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                customerWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                customerWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                customerWork.CustomerSubCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSUBCODERF"));
                customerWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                customerWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
                customerWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                customerWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                customerWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                customerWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                customerWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                customerWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
                customerWork.CustomerAttributeDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERATTRIBUTEDIVRF"));
                customerWork.JobTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOBTYPECODERF"));
                customerWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                customerWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                customerWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
                customerWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
                customerWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
                customerWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
                customerWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
                customerWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
                customerWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                customerWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
                customerWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
                customerWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
                customerWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
                customerWork.SearchTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHTELNORF"));
                customerWork.MngSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));
                customerWork.InpSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPSECTIONCODERF"));
                customerWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
                customerWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
                customerWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
                customerWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
                customerWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
                customerWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
                customerWork.BillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLOUTPUTCODERF"));
                customerWork.BillOutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLOUTPUTNAMERF"));
                customerWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
                customerWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
                customerWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
                customerWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
                customerWork.CollectCond = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTCONDRF"));
                customerWork.CollectSight = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTSIGHTRF"));
                customerWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                customerWork.TransStopDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("TRANSSTOPDATERF"));
                customerWork.DmOutCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMOUTCODERF"));
                customerWork.DmOutName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMOUTNAMERF"));
                customerWork.MainSendMailAddrCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINSENDMAILADDRCDRF"));
                customerWork.MailAddrKindCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE1RF"));
                customerWork.MailAddrKindName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME1RF"));
                customerWork.MailAddress1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS1RF"));
                customerWork.MailSendCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE1RF"));
                customerWork.MailSendName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME1RF"));
                customerWork.MailAddrKindCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILADDRKINDCODE2RF"));
                customerWork.MailAddrKindName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRKINDNAME2RF"));
                customerWork.MailAddress2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESS2RF"));
                customerWork.MailSendCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDCODE2RF"));
                customerWork.MailSendName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILSENDNAME2RF"));
                customerWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
                customerWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
                customerWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
                customerWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
                customerWork.AcceptWholeSale = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTWHOLESALERF"));
                customerWork.CreditMngCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CREDITMNGCODERF"));
                customerWork.DepoDelCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODELCODERF"));
                customerWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                customerWork.CustSlipNoMngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNOMNGCDRF"));
                customerWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                customerWork.CustCTaXLayRefCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTCTAXLAYREFCDRF"));
                customerWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                customerWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                customerWork.TotalAmntDspWayRef = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMNTDSPWAYREFRF"));
                customerWork.AccountNoInfo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO1RF"));
                customerWork.AccountNoInfo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO2RF"));
                customerWork.AccountNoInfo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCOUNTNOINFO3RF"));
                customerWork.SalesUnPrcFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCFRCPROCCDRF"));
                customerWork.SalesMoneyFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESMONEYFRCPROCCDRF"));
                customerWork.SalesCnsTaxFrcProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCNSTAXFRCPROCCDRF"));
                customerWork.CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));
                customerWork.NTimeCalcStDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NTIMECALCSTDATERF"));
                customerWork.CustomerAgent = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTRF"));
                customerWork.ClaimSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));
                customerWork.CarMngDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGDIVCDRF"));
                customerWork.BillPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLPARTSNOPRTCDRF"));
                customerWork.DeliPartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIPARTSNOPRTCDRF"));
                customerWork.DefSalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEFSALESSLIPCDRF"));
                customerWork.LavorRateRank = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAVORRATERANKRF"));
                customerWork.SlipTtlPrn = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRNRF"));
                customerWork.DepoBankCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOBANKCODERF"));
                customerWork.CustWarehouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTWAREHOUSECDRF"));
                customerWork.QrcodePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("QRCODEPRTCDRF"));
                customerWork.DeliHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIHONORIFICTTLRF"));
                customerWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
                customerWork.EstmHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTMHONORIFICTTLRF"));
                customerWork.RectHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECTHONORIFICTTLRF"));
                customerWork.DeliHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIHONORTTLPRTDIVRF"));
                customerWork.BillHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BILLHONORTTLPRTDIVRF"));
                customerWork.EstmHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTMHONORTTLPRTDIVRF"));
                customerWork.RectHonorTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECTHONORTTLPRTDIVRF"));
                customerWork.Note1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE1RF"));
                customerWork.Note2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE2RF"));
                customerWork.Note3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE3RF"));
                customerWork.Note4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE4RF"));
                customerWork.Note5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE5RF"));
                customerWork.Note6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE6RF"));
                customerWork.Note7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE7RF"));
                customerWork.Note8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE8RF"));
                customerWork.Note9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE9RF"));
                customerWork.Note10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NOTE10RF"));
                customerWork.SalesSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPPRTDIVRF"));
                customerWork.ShipmSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMSLIPPRTDIVRF"));
                customerWork.AcpOdrrSlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPODRRSLIPPRTDIVRF"));
                customerWork.EstimatePrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEPRTDIVRF"));
                customerWork.UOESlipPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESLIPPRTDIVRF"));
                customerWork.ReceiptOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIPTOUTPUTCODERF"));
                customerWork.CustomerEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMEREPCODERF"));
                customerWork.CustomerSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSECCODERF"));
                customerWork.OnlineKindDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEKINDDIVRF"));
                customerWork.TotalBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALBILLOUTPUTDIVRF"));
                customerWork.DetailBillOutputCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILBILLOUTPUTCODERF"));
                customerWork.SlipTtlBillOutputDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLBILLOUTPUTDIVRF"));
                customerWork.SimplInqAcntAcntGrId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SIMPLINQACNTACNTGRIDRF"));
                # endregion
            }
        }
        // --------------- ADD END 2013/05/29 wangl2 FOR PM-Tablet--------<<<<
	}

	#region �ڋq��������Conpare�N���X CustomerSearchRetCompare
	/// <summary>
	/// �ڋq��������Compare�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �ڋq�������ʂ̓��Ӑ�R�[�h���������ǂ������r����N���X�ł�</br>
	/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
	/// <br>Date       : 2007.02.13</br>
	/// <br></br>
	/// </remarks>
	internal class CustomerSearchRetCompare : IComparer
	{
		#region IComparer �����o

		/// <summary>
		/// �ڋq��������Compare���\�b�h
		/// </summary>
		/// <param name="x">CustomerSearchRetWork�I�u�W�F�N�g</param>
		/// <param name="y">CustomerSearchRetWork�I�u�W�F�N�g</param>
		/// <returns>��r����</returns>
		/// <remarks>
		/// <br>Note       : �ڋq�������ʂ̓��Ӑ�R�[�h���������ǂ������r���܂�</br>
		/// <br>Programmer : 980076�@�Ȓ��@����Y</br>
		/// <br>Date       : 2007.02.13</br>
		/// </remarks>
		public int Compare(object x, object y)
		{
			CustomerSearchRetWork customerSearchRetWork1 = (CustomerSearchRetWork)x;
			CustomerSearchRetWork customerSearchRetWork2 = (CustomerSearchRetWork)y;
			int no = customerSearchRetWork1.CustomerCode - customerSearchRetWork2.CustomerCode;
			return no;
		}

		#endregion

	}
	#endregion
}

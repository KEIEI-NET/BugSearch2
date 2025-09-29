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
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �󒍃}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󒍃}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2007.09.12</br>
    /// <br></br>
    /// <br>Update Note: 2008.05.28�@�̔ԏ����̋��ʕ��i���ɔ����C��</br>
    /// </remarks>
    [Serializable]
    public class AcceptOdrDB : RemoteWithAppLockDB, IAcceptOdrDB
    {
        /// <summary>
        /// �󒍃}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        /// </remarks>
        public AcceptOdrDB()
            :
            base("DCCMN00106D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrWork", "ACCEPTODRRF")
        {
        }

        #region [�̔ԏ���]
        /// <summary>
        /// �󒍔ԍ����̔Ԃ��܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h���w�肵�܂��B</param>
        /// <param name="sectioncode">���_�R�[�h���w�肵�܂��B</param>
        /// <param name="acceptanorderno">�̔Ԃ����󒍔ԍ���Ԃ��܂��B</param>
        /// <returns>STATUS</returns>
        public int GetAcceptAnOrderNo(string enterprisecode, string sectioncode, out Int32 acceptanorderno)
        {
            // �󒍔ԍ����̔Ԃ���
            Int64 acceptanorderno64;
            
            int status = GetSerialNumber(enterprisecode, sectioncode, SerialNumberCode.AcceptAnOrderNo, out acceptanorderno64);

            acceptanorderno = (Int32)acceptanorderno64;
            
            return status;
        }

        /// <summary>
        /// ���ʒʔԂ��̔Ԃ��܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h���w�肵�܂��B</param>
        /// <param name="sectioncode">���_�R�[�h���w�肵�܂��B</param>
        /// <param name="commonseqno">�̔Ԃ������ʒʔԂ�Ԃ��܂��B</param>
        /// <returns>STATUS</returns>
        public int GetCommonSeqNo(string enterprisecode, string sectioncode, out Int64 commonseqno)
        {
            // ���ʒʔԂ��̔Ԃ���
            return GetSerialNumber(enterprisecode, sectioncode, SerialNumberCode.CommonNo, out commonseqno);
        }

        /// <summary>
        /// �`�[���גʔԂ��̔Ԃ��܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h���w�肵�܂��B</param>
        /// <param name="sectioncode">���_�R�[�h���w�肵�܂��B</param>
        /// <param name="slipdatadivide">�`�[�f�[�^�敪���w�肵�܂��B</param>
        /// <param name="slipdetailno">�̔Ԃ����`�[���גʔԂ�Ԃ��܂��B</param>
        /// <returns>STATUS</returns>
        public int GetSlipDetailNo(string enterprisecode, string sectioncode, int slipdatadivide, out Int64 slipdetailno)
        {
            SerialNumberCode serialnumcd = SerialNumberCode.Empty;

            // �`�[�f�[�^�敪�ɉ������ԍ��R�[�h��ݒ肷��
            switch (slipdatadivide)
            {
                case (int)SlipDataDivide.Estimate:              // ����                
                case (int)SlipDataDivide.Sales:                 // ����
                case (int)SlipDataDivide.AcceptAnOrder:         // ��
                case (int)SlipDataDivide.Shipment:              // �o��
                //case (int)SlipDataDivide.ShipmentReturnedGoods: // �o�וԕi
                //case (int)SlipDataDivide.SalesReturnedGoods:    // ����ԕi
                    {
                        serialnumcd = SerialNumberCode.SailsDtlNo;
                        break;
                    }
                case (int)SlipDataDivide.Stock:                 // �d��
                case (int)SlipDataDivide.SalesOrder:            // ����
                case (int)SlipDataDivide.ArrivalGoods:          // ����
                //case (int)SlipDataDivide.ArrivalReturnedGoods:  // ���וԕi
                //case (int)SlipDataDivide.StockReturnedGoods:    // �d���ԕi
                    {
                        serialnumcd = SerialNumberCode.StockDtlNo;
                        break;
                    }
                case (int)SlipDataDivide.Deposit:               // ����
                    {
                        serialnumcd = SerialNumberCode.DepositDtlNo;
                        break;
                    }

                case (int)SlipDataDivide.Payment:               // �x��
                    {
                        serialnumcd = SerialNumberCode.PaymentDtlNo;
                        break;
                    }
            }

            return GetSerialNumber(enterprisecode, sectioncode, serialnumcd, out slipdetailno);
        }

        /// <summary>
        /// �ʔԂ��̔Ԃ��܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h���w�肵�܂��B</param>
        /// <param name="sectioncode">���_�R�[�h���w�肵�܂��B</param>
        /// <param name="serialnumcd">�ʔԃR�[�h���w�肵�܂��B</param>
        /// <param name="serialnumber">�ԍ��R�[�h�Ɋ�č̔Ԃ��ꂽ�ʔԂ�Ԃ��܂��B</param>
        /// <returns>STATUS</returns>
        private int GetSerialNumber(string enterprisecode, string sectioncode, SerialNumberCode serialnumcd, out Int64 serialnumber)
        {
            // �����̎����������ʃN���X������ PMCMN00005 �Ɉړ����܂����B
            NumberingManager numberingMng = new NumberingManager();
            return numberingMng.GetSerialNumber(enterprisecode, sectioncode, serialnumcd, out serialnumber);
        }

        #endregion

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̎󒍃}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="acceptOdrWork">��������</param>
        /// <param name="paraacceptOdrWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󒍃}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        public int Search(out object acceptOdrWork, object paraacceptOdrWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction dummyTransaction = null;
            acceptOdrWork = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else
                {
                    sqlConnection.Open();
                    status = SearchAcceptOdrProc(out acceptOdrWork, paraacceptOdrWork, readMode, logicalMode, ref sqlConnection, ref dummyTransaction);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AcceptOdrDB.Search");
                acceptOdrWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎󒍃}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objacceptOdrWork">��������</param>
        /// <param name="paraacceptOdrWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󒍃}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        public int SearchAcceptOdrProc(out object objacceptOdrWork, object paraacceptOdrWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            AcceptOdrWork acceptodrWork = null;

            ArrayList acceptodrWorkList = paraacceptOdrWork as ArrayList;

            if (acceptodrWorkList == null)
            {
                acceptodrWork = paraacceptOdrWork as AcceptOdrWork;
            }
            else
            {
                if (acceptodrWorkList.Count > 0)
                {
                    acceptodrWork = acceptodrWorkList[0] as AcceptOdrWork;
                }
            }

            int status = SearchAcceptOdrProc(out acceptodrWorkList, acceptodrWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);

            objacceptOdrWork = acceptodrWorkList;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎󒍃}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="acceptodrWorkList">��������</param>
        /// <param name="acceptodrWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎󒍃}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        public int SearchAcceptOdrProc(out ArrayList acceptodrWorkList, AcceptOdrWork acceptodrWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList retList = new ArrayList();

            if (acceptodrWork != null && sqlConnection != null)
            {
                SqlDataReader myReader = null;
                SqlCommand sqlCommand = null;

                try
                {
                    # region [SELECT��]
                    string sqlText = "";
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  ACC1.CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ACC1.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ACC1.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,ACC1.FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,ACC1.UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,ACC1.UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,ACC1.UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,ACC1.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,ACC1.SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,ACC1.ACCEPTANORDERNORF" + Environment.NewLine;
                    sqlText += " ,ACC1.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,ACC1.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,ACC1.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += " ,ACC1.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += " ,ACC1.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,ACC1.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                    sqlText += " ,ACC1.SRCLINKDATACODERF" + Environment.NewLine;
                    sqlText += " ,ACC1.SRCSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  ACCEPTODRRF AS ACC1 INNER JOIN" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "    SELECT" + Environment.NewLine;
                    sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "     ,MAX(SUB.SLIPDTLNUMDERIVNORF) AS SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                    sqlText += "    FROM" + Environment.NewLine;
                    sqlText += "      ACCEPTODRRF AS SUB" + Environment.NewLine;
                    sqlText += "    WHERE" + Environment.NewLine;
                    sqlText += "      SUB.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "    GROUP BY" + Environment.NewLine;
                    sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "  )  AS ACC2" + Environment.NewLine;
                    sqlText += "  ON  ACC1.ENTERPRISECODERF = ACC2.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "  AND ACC1.SECTIONCODERF = ACC2.SECTIONCODERF" + Environment.NewLine;
                    sqlText += "  AND ACC1.ACPTANODRSTATUSRF = ACC2.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = ACC2.DATAINPUTSYSTEMRF" + Environment.NewLine;
                    sqlText += "  AND ACC1.COMMONSEQNORF = ACC2.COMMONSEQNORF" + Environment.NewLine;
                    sqlText += "  AND ACC1.SLIPDTLNUMRF = ACC2.SLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += "  AND ACC1.SLIPDTLNUMDERIVNORF = ACC2.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                    # endregion

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    # region [WHERE��]
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ACC1.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND ACC1.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                    sqlText += "  AND ACC1.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                    sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;

                    // �Œ�i���ݏ���
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);        // ���_�R�[�h
                    SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);  // �󒍃X�e�[�^�X
                    SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);  // �f�[�^���̓V�X�e��

                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                    findSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                    findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);

                    // �ύi���ݏ���
                    if (string.IsNullOrEmpty(acceptodrWork.SalesSlipNum) || acceptodrWork.SalesSlipNum == "0")
                    {
                        // �ʏ�͋��ʒʔԂƖ��גʔԂ����������Ƃ��či���݂��s��
                        sqlText += "  AND ACC1.COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                        sqlText += "  AND ACC1.SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;
                        SqlParameter findCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                        SqlParameter findSlipDtlNum = sqlCommand.Parameters.Add("@FINDSLIPDTLNUM", SqlDbType.BigInt);
                        findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                        findSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                    }
                    else
                    {
                        // �`�[�ԍ������������ɐݒ肳��Ă���ꍇ�́A�������D�悵�či���ݏ����Ƃ���
                        sqlText += "  AND ACC1.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                        SqlParameter findSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                        findSalesSlipNum.Value = SqlDataMediator.SqlSetString(acceptodrWork.SalesSlipNum);
                    }

                    // �_���폜�敪
                    string wkstring = "";
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "  AND ACC1.LOGICALDELETECODERF = @FINDLOGICALDELETECODE";
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                             (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "  AND ACC1.LOGICALDELETECODERF < @FINDLOGICALDELETECODE";
                    }

                    if (wkstring != "")
                    {
                        sqlText += wkstring;
                        SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    #endregion

#if DEBUG
                    Console.Clear();
                    Console.WriteLine("--- �ϐ� ---");

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

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        retList.Add(CopyToAcceptOdrWorkFromReader(ref myReader));

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
            }

            acceptodrWorkList = retList;
            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �󒍃}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        public int Write(ref object acceptOdrWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(acceptOdrWork);

                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null) return status;

                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteAcceptOdrProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }

                //�߂�l�Z�b�g
                acceptOdrWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AcceptOdrDB.Write(ref object acceptOdrWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
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
        /// �󒍃}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="acceptOdrWorkList">AcceptOdrWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        public int WriteAcceptOdrProc(ref ArrayList acceptOdrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (acceptOdrWorkList != null && acceptOdrWorkList.Count > 0)
                {
                    string sqlText = "";

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                    
                    foreach (object item in acceptOdrWorkList)
                    {
                        AcceptOdrWork acceptodrWork = item as AcceptOdrWork;

                        if (string.IsNullOrEmpty(acceptodrWork.SalesSlipNum))
                        {
                            // �`�[�ԍ������ݒ�(�� or NULL)�̏ꍇ�� "0" �Ƃ���
                            acceptodrWork.SalesSlipNum = "0";
                        }
                        
                        if (acceptodrWork != null)
                        {
                            try
                            {
                                # region [�ő喾�גʔԎ}�Ԏ擾����]
                                // ��ƃR�[�h + ���_�R�[�h + �󒍃X�e�[�^�X + �f�[�^���̓V�X�e�� + ���ʒʔ� + ���גʔ� �ōi���݁A�ő�̖��גʔԎ}�Ԃ��擾����
                                // �� �_���폜����Ă��Ă��W�v�̑ΏۂƂ���B
                                sqlText = string.Empty;
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  ACC1.SALESSLIPNUMRF" + Environment.NewLine;       // �`�[�ԍ�
                                sqlText += " ,ACC1.ACCEPTANORDERNORF" + Environment.NewLine;    // �󒍔ԍ�
                                sqlText += " ,ACC1.SRCLINKDATACODERF" + Environment.NewLine;    // �A�g���f�[�^�敪
                                sqlText += " ,ACC1.SRCSLIPDTLNUMRF" + Environment.NewLine;      // �A�g�����גʔ�
                                sqlText += " ,ACC1.SLIPDTLNUMDERIVNORF" + Environment.NewLine;  // ���גʔԎ}��
                                sqlText += "FROM" + Environment.NewLine;
                                sqlText += "  ACCEPTODRRF AS ACC1 INNER JOIN" + Environment.NewLine;
                                sqlText += "  (" + Environment.NewLine;
                                sqlText += "    SELECT" + Environment.NewLine;
                                sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                                sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                                sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                                sqlText += "     ,MAX(SUB.SLIPDTLNUMDERIVNORF) AS SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                                sqlText += "    FROM" + Environment.NewLine;
                                sqlText += "      ACCEPTODRRF AS SUB" + Environment.NewLine;
                                sqlText += "    WHERE" + Environment.NewLine;
                                sqlText += "      SUB.LOGICALDELETECODERF = 0" + Environment.NewLine;
                                sqlText += "    GROUP BY" + Environment.NewLine;
                                sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                                sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                                sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                                sqlText += "  )  AS ACC2" + Environment.NewLine;
                                sqlText += "  ON  ACC1.ENTERPRISECODERF = ACC2.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "  AND ACC1.SECTIONCODERF = ACC2.SECTIONCODERF" + Environment.NewLine;
                                sqlText += "  AND ACC1.ACPTANODRSTATUSRF = ACC2.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = ACC2.DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlText += "  AND ACC1.COMMONSEQNORF = ACC2.COMMONSEQNORF" + Environment.NewLine;
                                sqlText += "  AND ACC1.SLIPDTLNUMRF = ACC2.SLIPDTLNUMRF" + Environment.NewLine;
                                sqlText += "  AND ACC1.SLIPDTLNUMDERIVNORF = ACC2.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                                sqlText += "WHERE" + Environment.NewLine;
                                sqlText += "  ACC1.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "  AND ACC1.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                                sqlText += "  AND ACC1.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                                sqlText += "  AND ACC1.COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                                sqlText += "  AND ACC1.SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;

                                sqlCommand.CommandText = sqlText;

                                //Prameter�I�u�W�F�N�g�̍쐬
                                sqlCommand.Parameters.Clear();
                                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                                SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                                SqlParameter findParaCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                                SqlParameter findParaSlipDtlNum = sqlCommand.Parameters.Add("@FINDSLIPDTLNUM", SqlDbType.BigInt);

                                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                                findParaSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                                findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                                findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                                findParaCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                                findParaSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);

#if DEBUG
                                Console.Clear();
                                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                                int RetryCount = 5;  // �₢���킹���g���C��

                                while (true)  // ���g���C�p�̃��[�v
                                {
                                    try
                                    {
                                        myReader = sqlCommand.ExecuteReader();
                                        break;
                                    }
                                    catch (SqlException sqlEx)
                                    {
                                        // ���b�N�^�C���A�E�g�ȊO�� SqlException �����������ꍇ�A����
                                        // ���b�N�^�C���A�E�g�ɂ�郊�g���C�񐔂����ɒ����Ă���ꍇ��
                                        // ��O�����̂܂܃X���[����B
                                        if (sqlEx.Number != 1222 || RetryCount <= 0)
                                        {
                                            throw sqlEx;
                                        }
                                        RetryCount--;
                                    }
                                }

                                int NextSlipDtlNumDerivNo = 0;

                                if (myReader.Read())
                                {
                                    // ���ʃw�b�_�A���тɃL�[�ȊO�̍��ڂɕύX������ꍇ�ɂ̂ݕύX���s��

                                    AcceptOdrWork tmpacceptOdrWork = new AcceptOdrWork();

                                    tmpacceptOdrWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                                    tmpacceptOdrWork.SrcLinkDataCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCLINKDATACODERF"));
                                    tmpacceptOdrWork.SrcSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SRCSLIPDTLNUMRF"));

                                    if (tmpacceptOdrWork.AcceptAnOrderNo == acceptodrWork.AcceptAnOrderNo &&
                                        tmpacceptOdrWork.SrcLinkDataCode == acceptodrWork.SrcLinkDataCode &&
                                        tmpacceptOdrWork.SrcSlipDtlNum == acceptodrWork.SrcSlipDtlNum &&
                                        tmpacceptOdrWork.LogicalDeleteCode == acceptodrWork.LogicalDeleteCode)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        // �}�Ԃ��{�P���Ēǉ��������s���B
                                        NextSlipDtlNumDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDTLNUMDERIVNORF"));
                                    }
                                }

                                acceptodrWork.SlipDtlNumDerivNo = ++NextSlipDtlNumDerivNo;
                                # endregion

                                # region [�������ݏ���]
                                sqlText = string.Empty;
                                sqlText += "INSERT INTO ACCEPTODRRF" + Environment.NewLine;
                                sqlText += "(" + Environment.NewLine;
                                sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                                sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                                sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                                sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                                sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                                sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                                sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                                sqlText += " ,ACCEPTANORDERNORF" + Environment.NewLine;
                                sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                                sqlText += " ,DATAINPUTSYSTEMRF" + Environment.NewLine;
                                sqlText += " ,COMMONSEQNORF" + Environment.NewLine;
                                sqlText += " ,SLIPDTLNUMRF" + Environment.NewLine;
                                sqlText += " ,SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                                sqlText += " ,SRCLINKDATACODERF" + Environment.NewLine;
                                sqlText += " ,SRCSLIPDTLNUMRF" + Environment.NewLine;
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
                                sqlText += " ,@SECTIONCODE" + Environment.NewLine;
                                sqlText += " ,@ACCEPTANORDERNO" + Environment.NewLine;
                                sqlText += " ,@ACPTANODRSTATUS" + Environment.NewLine;
                                sqlText += " ,@SALESSLIPNUM" + Environment.NewLine;
                                sqlText += " ,@DATAINPUTSYSTEM" + Environment.NewLine;
                                sqlText += " ,@COMMONSEQNO" + Environment.NewLine;
                                sqlText += " ,@SLIPDTLNUM" + Environment.NewLine;
                                sqlText += " ,@SLIPDTLNUMDERIVNO" + Environment.NewLine;
                                sqlText += " ,@SRCLINKDATACODE" + Environment.NewLine;
                                sqlText += " ,@SRCSLIPDTLNUM" + Environment.NewLine;
                                sqlText += ")" + Environment.NewLine;

                                sqlCommand.CommandText = sqlText;

                                //�o�^�w�b�_����ݒ�
                                object obj = (object)this;
                                IFileHeader flhd = (IFileHeader)acceptodrWork;
                                FileHeader fileHeader = new FileHeader(obj);
                                fileHeader.SetInsertHeader(ref flhd, obj);

                                #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                                SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                                SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                                SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                                SqlParameter paraSlipDtlNum = sqlCommand.Parameters.Add("@SLIPDTLNUM", SqlDbType.BigInt);
                                SqlParameter paraSlipDtlNumDerivNo = sqlCommand.Parameters.Add("@SLIPDTLNUMDERIVNO", SqlDbType.Int);
                                SqlParameter paraSrcLinkDataCode = sqlCommand.Parameters.Add("@SRCLINKDATACODE", SqlDbType.Int);
                                SqlParameter paraSrcSlipDtlNum = sqlCommand.Parameters.Add("@SRCSLIPDTLNUM", SqlDbType.BigInt);
                                #endregion

                                #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptodrWork.CreateDateTime);
                                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptodrWork.UpdateDateTime);
                                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(acceptodrWork.FileHeaderGuid);
                                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdEmployeeCode);
                                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdAssemblyId1);
                                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdAssemblyId2);
                                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.LogicalDeleteCode);
                                paraSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcceptAnOrderNo);
                                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(acceptodrWork.SalesSlipNum);
                                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                                paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                                paraSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                                paraSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SlipDtlNumDerivNo);
                                paraSrcLinkDataCode.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SrcLinkDataCode);
                                paraSrcSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SrcSlipDtlNum);
                                #endregion

                                if (!myReader.IsClosed)
                                {
                                    myReader.Close();
                                }

                                sqlCommand.ExecuteNonQuery();

                                al.Add(acceptodrWork);
                                # endregion
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
                                    myReader = null;
                                }
                            }
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            acceptOdrWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �󒍃}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        public int LogicalDelete(ref object acceptOdrWork)
        {
            return LogicalDeleteAcceptOdr(ref acceptOdrWork, 0);
        }

        /// <summary>
        /// �_���폜�󒍃}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�󒍃}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        public int RevivalLogicalDelete(ref object acceptOdrWork)
        {
            return LogicalDeleteAcceptOdr(ref acceptOdrWork, 1);
        }

        /// <summary>
        /// �󒍃}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        private int LogicalDeleteAcceptOdr(ref object acceptOdrWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(acceptOdrWork);

                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteAcceptOdrProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";

                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";

                base.WriteErrorLog(ex, "AcceptOdrDB.LogicalDeleteAcceptOdr :" + procModestr);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();

                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
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
        /// �󒍃}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="acceptOdrWorkList">AcceptOdrWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        public int LogicalDeleteAcceptOdrProc(ref ArrayList acceptOdrWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (acceptOdrWorkList != null && sqlConnection != null)
                {
                    string sqlText = "";

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    foreach (object item in acceptOdrWorkList)
                    {
                        AcceptOdrWork acceptodrWork = item as AcceptOdrWork;

                        if (acceptodrWork != null)
                        {
                            # region [SELECT��]
                            sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  ACC1.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ACC1.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,ACC1.LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,ACC1.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  ACCEPTODRRF AS ACC1 INNER JOIN" + Environment.NewLine;
                            sqlText += "  (" + Environment.NewLine;
                            sqlText += "    SELECT" + Environment.NewLine;
                            sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                            sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                            sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                            sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "     ,MAX(SUB.SLIPDTLNUMDERIVNORF) AS SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                            sqlText += "    FROM" + Environment.NewLine;
                            sqlText += "      ACCEPTODRRF AS SUB" + Environment.NewLine;
                            sqlText += "    WHERE" + Environment.NewLine;
                            sqlText += "      SUB.LOGICALDELETECODERF = 0" + Environment.NewLine;
                            sqlText += "    GROUP BY" + Environment.NewLine;
                            sqlText += "      SUB.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "     ,SUB.SECTIONCODERF" + Environment.NewLine;
                            sqlText += "     ,SUB.ACPTANODRSTATUSRF" + Environment.NewLine;
                            sqlText += "     ,SUB.DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlText += "     ,SUB.COMMONSEQNORF" + Environment.NewLine;
                            sqlText += "     ,SUB.SLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "  )  AS ACC2" + Environment.NewLine;
                            sqlText += "  ON  ACC1.ENTERPRISECODERF = ACC2.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  AND ACC1.SECTIONCODERF = ACC2.SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  AND ACC1.ACPTANODRSTATUSRF = ACC2.ACPTANODRSTATUSRF" + Environment.NewLine;
                            sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = ACC2.DATAINPUTSYSTEMRF" + Environment.NewLine;
                            sqlText += "  AND ACC1.COMMONSEQNORF = ACC2.COMMONSEQNORF" + Environment.NewLine;
                            sqlText += "  AND ACC1.SLIPDTLNUMRF = ACC2.SLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "  AND ACC1.SLIPDTLNUMDERIVNORF = ACC2.SLIPDTLNUMDERIVNORF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ACC1.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACC1.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND ACC1.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND ACC1.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlText += "  AND ACC1.COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                            sqlText += "  AND ACC1.SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;

                            # endregion

                            //Prameter�I�u�W�F�N�g�̍쐬
                            sqlCommand.Parameters.Clear();
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                            SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                            SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                            SqlParameter findCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                            SqlParameter findSlipDtlNum = sqlCommand.Parameters.Add("@FINDSLIPDTLNUM", SqlDbType.BigInt);
                            SqlParameter findSlipDtlNumDerivNo = sqlCommand.Parameters.Add("@FINDSLIPDTLNUMDERIVNO", SqlDbType.Int);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                            findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                            findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                            findSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                            findSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SlipDtlNumDerivNo);

                            myReader = sqlCommand.ExecuteReader();
                            
                            try
                            {
                                if (myReader.Read())
                                {
                                    if (acceptodrWork.UpdateDateTime != DateTime.MinValue)
                                    {
                                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                                        if (_updateDateTime != acceptodrWork.UpdateDateTime)
                                        {
                                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                            return status;
                                        }
                                    }

                                    //���݂̘_���폜�敪���擾
                                    logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                                    # region [UPDATE��]
                                    sqlText = "";
                                    sqlText += "UPDATE" + Environment.NewLine;
                                    sqlText += "  ACCEPTODRRF" + Environment.NewLine;
                                    sqlText += "SET" + Environment.NewLine;
                                    sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                                    sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                                    sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                                    sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                                    sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                                    sqlText += "WHERE" + Environment.NewLine;
                                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                                    sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                    sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                                    sqlText += "  AND COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                                    sqlText += "  AND SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;
                                    sqlText += "  AND SLIPDTLNUMDERIVNORF = @FINDSLIPDTLNUMDERIVNO" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    # endregion

                                    //�X�V�w�b�_����ݒ�
                                    object obj = (object)this;
                                    IFileHeader flhd = (IFileHeader)acceptodrWork;
                                    FileHeader fileHeader = new FileHeader(obj);
                                    fileHeader.SetUpdateHeader(ref flhd, obj);

                                    //�_���폜���[�h�̏ꍇ
                                    if (procMode == 0)
                                    {
                                        if (logicalDelCd == 3)
                                        {
                                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                            continue;
                                        }
                                        else if (logicalDelCd == 0) acceptodrWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                                        else acceptodrWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                                    }
                                    else
                                    {
                                        if (logicalDelCd == 1)
                                        {
                                            acceptodrWork.LogicalDeleteCode = 0; //�_���폜�t���O������
                                        }
                                        else
                                        {
                                            if (logicalDelCd == 0)
                                            {
                                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                            }
                                            else
                                            {
                                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //���S�폜�̓f�[�^�Ȃ���߂�
                                            }

                                            continue;
                                        }
                                    }

                                    // ���גʔԎ}�Ԃ��擾
                                    acceptodrWork.SlipDtlNumDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDTLNUMDERIVNORF"));

                                    //KEY�R�}���h���Đݒ�
                                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                                    findSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                                    findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                                    findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                                    findSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                                    findSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SlipDtlNumDerivNo);

                                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(acceptodrWork.UpdateDateTime);
                                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdEmployeeCode);
                                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdAssemblyId1);
                                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(acceptodrWork.UpdAssemblyId2);
                                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.LogicalDeleteCode);

                                    sqlCommand.Cancel();

                                    if (!myReader.IsClosed)
                                    {
                                        myReader.Close();
                                    }

                                    sqlCommand.ExecuteNonQuery();
                                }
                                else
                                {
                                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    return status;
                                }
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
                                    myReader = null;
                                }
                            }
                        }
                    }

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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �󒍃}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="acceptOdrWork">�󒍃}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �󒍃}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        public int Delete(object acceptOdrWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(acceptOdrWork);

                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();

                if (sqlConnection == null) return status;

                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteAcceptOdrProc(paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AcceptOdrDB.Delete");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null)
                {
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
        /// �󒍃}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="acceptodrWorkList">�󒍃}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �󒍃}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        public int DeleteAcceptOdrProc(ArrayList acceptodrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (acceptodrWorkList != null && sqlConnection != null)
            {
                SqlDataReader myReader = null;
                SqlCommand sqlCommand = null;
                string sqlText = "";

                try
                {
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    foreach (object item in acceptodrWorkList)
                    {
                        AcceptOdrWork acceptodrWork = item as AcceptOdrWork;

                        if (acceptodrWork != null)
                        {
                            # region [SELECT��]
                            sqlText = "";
                            sqlText += "SELECT" + Environment.NewLine;
                            sqlText += "  ACC.UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ACC.ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,ACC.LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  ACCEPTODRRF AS ACC" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ACC.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND ACC.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND ACC.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  AND ACC.DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                            sqlText += "  AND ACC.COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                            sqlText += "  AND ACC.SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;
                            sqlText += "  AND ACC.SLIPDTLNUMDERIVNORF = @FINDSLIPDTLNUMDERIVNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;                            
                            # endregion

                            //Prameter�I�u�W�F�N�g�̍쐬
                            sqlCommand.Parameters.Clear();
                            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                            SqlParameter findAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                            SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                            SqlParameter findCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                            SqlParameter findSlipDtlNum = sqlCommand.Parameters.Add("@FINDSLIPDTLNUM", SqlDbType.BigInt);
                            SqlParameter findSlipDtlNumDerivNo = sqlCommand.Parameters.Add("@FINDSLIPDTLNUMDERIVNO", SqlDbType.Int);

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                            findSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                            findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                            findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                            findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                            findSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                            findSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SlipDtlNumDerivNo);

                            myReader = sqlCommand.ExecuteReader();

                            try
                            {
                                if (myReader.Read())
                                {
                                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                                    if (_updateDateTime != acceptodrWork.UpdateDateTime)
                                    {
                                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                        return status;
                                    }

                                    # region [UPDATE��]
                                    sqlText = "";
                                    sqlText += "DELETE" + Environment.NewLine;
                                    sqlText += "FROM" + Environment.NewLine;
                                    sqlText += "  ACCEPTODRRF" + Environment.NewLine;
                                    sqlText += "WHERE" + Environment.NewLine;
                                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                                    sqlText += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                                    sqlText += "  AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS" + Environment.NewLine;
                                    sqlText += "  AND DATAINPUTSYSTEMRF = @FINDDATAINPUTSYSTEM" + Environment.NewLine;
                                    sqlText += "  AND COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                                    sqlText += "  AND SLIPDTLNUMRF = @FINDSLIPDTLNUM" + Environment.NewLine;
                                    sqlText += "  AND SLIPDTLNUMDERIVNORF = @FINDSLIPDTLNUMDERIVNO" + Environment.NewLine;
                                    sqlCommand.CommandText = sqlText;
                                    # endregion

                                    //KEY�R�}���h���Đݒ�
                                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.EnterpriseCode);
                                    findSectionCode.Value = SqlDataMediator.SqlSetString(acceptodrWork.SectionCode);
                                    findAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.AcptAnOdrStatus);
                                    findDataInputSystem.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.DataInputSystem);
                                    findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.CommonSeqNo);
                                    findSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(acceptodrWork.SlipDtlNum);
                                    findSlipDtlNumDerivNo.Value = SqlDataMediator.SqlSetInt32(acceptodrWork.SlipDtlNumDerivNo);

                                    if (!myReader.IsClosed)
                                    {
                                        myReader.Close();
                                    }

                                    sqlCommand.ExecuteNonQuery();
                                }
                                else
                                {
                                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                    return status;
                                }
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
                                    myReader = null;
                                }
                            }
                        }
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                finally
                {
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }
                }
            }

            return status;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� AcceptOdrWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AcceptOdrWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        /// </remarks>
        private AcceptOdrWork CopyToAcceptOdrWorkFromReader(ref SqlDataReader myReader)
        {
            AcceptOdrWork retWork = new AcceptOdrWork();

            #region �N���X�֊i�[
            retWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            retWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            retWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            retWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            retWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            retWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            retWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            retWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            retWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            retWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
            retWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
            retWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
            retWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
            retWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
            retWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPDTLNUMRF"));
            retWork.SlipDtlNumDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPDTLNUMDERIVNORF"));
            retWork.SrcLinkDataCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SRCLINKDATACODERF"));
            retWork.SrcSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SRCSLIPDTLNUMRF"));
            #endregion

            return retWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            AcceptOdrWork[] AcceptOdrWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is AcceptOdrWork)
                    {
                        AcceptOdrWork wkAcceptOdrWork = paraobj as AcceptOdrWork;
                        if (wkAcceptOdrWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkAcceptOdrWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            AcceptOdrWorkArray = (AcceptOdrWork[])XmlByteSerializer.Deserialize(byteArray, typeof(AcceptOdrWork[]));
                        }
                        catch (Exception) { }
                        if (AcceptOdrWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(AcceptOdrWorkArray);
                        }
                        else
                        {
                            try
                            {
                                AcceptOdrWork wkAcceptOdrWork = (AcceptOdrWork)XmlByteSerializer.Deserialize(byteArray, typeof(AcceptOdrWork));
                                if (wkAcceptOdrWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkAcceptOdrWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
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

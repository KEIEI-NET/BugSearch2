//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �C �� ��  2009/06/11  �C�����e : R�N���X��public Method��SQL�������ʖ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/18  �C�����e : Redmine#23746
//                                  �Ⴄ��ƃR�[�h�Ԃ̑���M�ɂ��Ă̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : dingjx
// �C �� ��  2011/11/01 �C�����e :  Redmine#26228���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/30  �C�����e : Redmine#8293 ���_�Ǘ��^�`�[���t���t���o����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �C �� ��  2012/03/16  �C�����e : �^�C���A�E�g�Ή�(30�b��600�b)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : �e�c ���V
// �C �� ��  2014/03/26  �C�����e : �d�|�ꗗ��2292�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌ɒ����f�[�^�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɒ����f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class DCStockAdjustDB : RemoteDB
    {
        /// <summary>
        /// �݌ɒ����f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        public DCStockAdjustDB()
            : base("PMKYO07581D", "Broadleaf.Application.Remoting.ParamData.DCStockAdjustWork", "STOCKADJUSTRF")
        {

        }

        # region [Read]

        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌ɒ����f�[�^�擾
        /// </summary>
        /// <param name="stockAdjustList">�݌ɒ����f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int Search(out ArrayList stockAdjustList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(out  stockAdjustList, receiveDataWork, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ����f�[�^�擾
        /// </summary>
        /// <param name="stockAdjustList">�݌ɒ����f�[�^</param>
        /// <param name="receiveDataWork">��M�f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        private int SearchProc(out ArrayList stockAdjustList, DCReceiveDataWork receiveDataWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            stockAdjustList = new ArrayList();

            string sqlText = string.Empty;
            sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

            //  ADD dingjx  2011/11/01  --------------------------------->>>>>>
            if ((receiveDataWork.Kind == 0) && (receiveDataWork.SndLogExtraCondDiv == 1))
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WITH (READUNCOMMITTED) WHERE ADJUSTDATERF>=@FINDUPDATESTARTDATETIME AND ADJUSTDATERF<=@FINDUPDATEENDDATETIME AND SECTIONCODERF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE";  // DEL 2011/11/30
                // --- UPD 2014/03/26 Y.Wakita ---------->>>>>
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WITH (READUNCOMMITTED) WHERE ((ADJUSTDATERF>=@FINDUPDATESTARTDATETIME AND ADJUSTDATERF<=@FINDUPDATEENDDATETIME) OR ( UPDATEDATETIMERF>=@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  ADJUSTDATERF<=@FINDUPDATEENDDATETIME)) AND SECTIONCODERF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE"; // ADD 2011/11/30
                sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WITH (READUNCOMMITTED) WHERE ((ADJUSTDATERF>=@FINDUPDATESTARTDATETIME AND ADJUSTDATERF<=@FINDUPDATEENDDATETIME) OR ( UPDATEDATETIMERF>@FINDSYNCEXECDATERF AND  UPDATEDATETIMERF<=@FINDENDTIMERF AND  ADJUSTDATERF<=@FINDUPDATEENDDATETIME)) AND SECTIONCODERF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE";
                // --- UPD 2014/03/26 Y.Wakita ----------<<<<<
            else
            //  ADD dingjx  2011/11/01  ---------------------------------<<<<<<
			    // UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
                //sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND ENTERPRISECODERF=@FINDENTERPRISECODE";
			    sqlText = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF FROM STOCKADJUSTRF WITH (READUNCOMMITTED) WHERE UPDATEDATETIMERF>@FINDUPDATESTARTDATETIME AND UPDATEDATETIMERF<=@FINDUPDATEENDDATETIME AND SECTIONCODERF=@FINDSECTIONCODE AND ENTERPRISECODERF=@FINDENTERPRISECODE";
			    // UPD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDUPDATESTARTDATETIME", SqlDbType.BigInt);
            SqlParameter findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDUPDATEENDDATETIME", SqlDbType.BigInt);
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);// ADD 2011/08/18 ���仁@Redmine#23746
			SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j

            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaUpdateEndDateTime.Value = receiveDataWork.StartDateTime;
            findParaUpdateStartDateTime.Value = receiveDataWork.EndDateTime;
			findParaEnterpriseCode.Value = receiveDataWork.PmEnterpriseCode;// ADD 2011/08/18 ���仁@Redmine#23746
			findParaSectionCode.Value = receiveDataWork.PmSectionCode;// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j

            // ----- ADD 2011/11/30 tanh---------->>>>>
            //�f�[�^���M���o�����敪���u�`�[�敪�v�̏ꍇ
            if (receiveDataWork.Kind == 0 && receiveDataWork.SndLogExtraCondDiv == 1)
            {
                SqlParameter findParaSyncExecDate = sqlCommand.Parameters.Add("@FINDSYNCEXECDATERF", SqlDbType.BigInt);
                findParaSyncExecDate.Value = receiveDataWork.SyncExecDate;
                SqlParameter findParaEndTime = sqlCommand.Parameters.Add("@FINDENDTIMERF", SqlDbType.BigInt);
                findParaEndTime.Value = receiveDataWork.EndDateTimeTicks;
            }
            // ----- ADD 2011/11/30 tanh----------<<<<<

            // SQL��
			sqlCommand.CommandText = sqlText;

            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            myReader = sqlCommand.ExecuteReader();

            while (myReader.Read())
            {
                stockAdjustList.Add(this.CopyToStockAdjustWorkFromReader(ref myReader));
            }

            if (stockAdjustList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

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

            return status;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� stockAdjustWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private DCStockAdjustWork CopyToStockAdjustWorkFromReader(ref SqlDataReader myReader)
        {
            DCStockAdjustWork stockAdjustWork = new DCStockAdjustWork();

            this.CopyToStockAdjustWorkFromReader(ref myReader, ref stockAdjustWork);

            return stockAdjustWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� stockAdjustWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="stockAdjustWork">stockAdjustWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private void CopyToStockAdjustWorkFromReader(ref SqlDataReader myReader, ref DCStockAdjustWork stockAdjustWork)
        {
            if (myReader != null && stockAdjustWork != null)
            {
                # region �N���X�֊i�[
                stockAdjustWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                stockAdjustWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                stockAdjustWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                stockAdjustWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                stockAdjustWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                stockAdjustWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                stockAdjustWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                stockAdjustWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                stockAdjustWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                stockAdjustWork.StockAdjustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF"));
                stockAdjustWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                stockAdjustWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
                stockAdjustWork.AdjustDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
                stockAdjustWork.InputDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                stockAdjustWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                stockAdjustWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                stockAdjustWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                stockAdjustWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                stockAdjustWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                stockAdjustWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                stockAdjustWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                # endregion
            }
        }

        #endregion

        # region [Delete]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌ɒ����f�[�^�폜
        /// </summary>
        /// <param name="dcStockAdjustWorkList">�݌ɒ����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Delete(ArrayList dcStockAdjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(dcStockAdjustWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ����f�[�^�폜
        /// </summary>
        /// <param name="dcStockAdjustWorkList">�݌ɒ����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void DeleteProc(ArrayList dcStockAdjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockAdjustWork dcStockAdjustWork in dcStockAdjustWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //Delete�R�}���h�̐���
                sqlCommand.CommandText = "DELETE FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND STOCKADJUSTSLIPNORF=@FINDSTOCKADJUSTSLIPNO";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaStockAdjustSlipNo = sqlCommand.Parameters.Add("@FINDSTOCKADJUSTSLIPNO", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = dcStockAdjustWork.EnterpriseCode;
                findParaStockAdjustSlipNo.Value = dcStockAdjustWork.StockAdjustSlipNo;

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �݌ɒ����f�[�^���폜����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

        # region [Insert]
        // ADD 2009/06/11 --->>>
        // R�N���X��public Method��SQL�������ʖ�
        /// <summary>
        /// �݌ɒ����f�[�^�o�^
        /// </summary>
        /// <param name="dcStockAdjustWorkList">�݌ɒ����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        public void Insert(ArrayList dcStockAdjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(dcStockAdjustWorkList, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// �݌ɒ����f�[�^�o�^
        /// </summary>
        /// <param name="dcStockAdjustWorkList">�݌ɒ����f�[�^</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="sqlCommand">SQL�R�����g</param>
        /// <returns></returns>
        private void InsertProc(ArrayList dcStockAdjustWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (DCStockAdjustWork dcStockAdjustWork in dcStockAdjustWorkList)
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //Insert�R�}���h�̐���
                sqlCommand.CommandText = "INSERT INTO STOCKADJUSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, STOCKADJUSTSLIPNORF, ACPAYSLIPCDRF, ACPAYTRANSCDRF, ADJUSTDATERF, INPUTDAYRF, STOCKSECTIONCDRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, STOCKSUBTTLPRICERF, SLIPNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @STOCKADJUSTSLIPNO, @ACPAYSLIPCD, @ACPAYTRANSCD, @ADJUSTDATE, @INPUTDAY, @STOCKSECTIONCD, @STOCKINPUTCODE, @STOCKINPUTNAME, @STOCKAGENTCODE, @STOCKAGENTNAME, @STOCKSUBTTLPRICE, @SLIPNOTE)";

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraStockAdjustSlipNo = sqlCommand.Parameters.Add("@STOCKADJUSTSLIPNO", SqlDbType.Int);
                SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                SqlParameter paraAdjustDate = sqlCommand.Parameters.Add("@ADJUSTDATE", SqlDbType.Int);
                SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                SqlParameter paraStockSectionCd = sqlCommand.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                SqlParameter paraStockSubttlPrice = sqlCommand.Parameters.Add("@STOCKSUBTTLPRICE", SqlDbType.BigInt);
                SqlParameter paraSlipNote = sqlCommand.Parameters.Add("@SLIPNOTE", SqlDbType.NVarChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockAdjustWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dcStockAdjustWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dcStockAdjustWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.SectionCode);
                paraStockAdjustSlipNo.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustWork.StockAdjustSlipNo);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustWork.AcPaySlipCd);
                paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustWork.AcPayTransCd);
                paraAdjustDate.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustWork.AdjustDate);
                paraInputDay.Value = SqlDataMediator.SqlSetInt32(dcStockAdjustWork.InputDay);
                paraStockSectionCd.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.StockSectionCd);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.StockInputCode);
                paraStockInputName.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.StockInputName);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.StockAgentCode);
                paraStockAgentName.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.StockAgentName);
                paraStockSubttlPrice.Value = SqlDataMediator.SqlSetInt64(dcStockAdjustWork.StockSubttlPrice);
                paraSlipNote.Value = SqlDataMediator.SqlSetString(dcStockAdjustWork.SlipNote);

                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                // �݌ɒ����f�[�^��o�^����
                sqlCommand.ExecuteNonQuery();
            }
        }
        #endregion

		// ADD 2011.08.26 ���� ---------->>>>>
		# region [Clear]
		// R�N���X��public Method��SQL�������ʖ�
		/// <summary>
		/// �f�[�^�N���A
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <param name="sqlCommand">SQL�R�����g</param>
		/// <returns></returns>
        //public void Clear(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                       //DEL by Liangsd     2011/09/06
        public void Clear(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)      //ADD by Liangsd    2011/09/06
		{
            //ClearProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//DEL by Liangsd     2011/09/06
            ClearProc(sectionCode,enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);//ADD by Liangsd    2011/09/06
		}
		/// <summary>
		/// �f�[�^�N���A
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
		/// <param name="sqlTransaction">�g�����U�N�V�������</param>
		/// <param name="sqlCommand">SQL�R�����g</param>
		/// <returns></returns>
        //private void ClearProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                  //DEL by Liangsd     2011/09/06
        private void ClearProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//ADD by Liangsd    2011/09/06
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Delete�R�}���h�̐���
            //sqlCommand.CommandText = "DELETE FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE";                                                                                            //DEL by Liangsd     2011/09/06
            sqlCommand.CommandText = "DELETE FROM STOCKADJUSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF = @FINDSECTIONCODERF";      //ADD by Liangsd    2011/09/06
            
			//Prameter�I�u�W�F�N�g�̍쐬
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
			//Parameter�I�u�W�F�N�g�֒l�ݒ�
			findParaEnterpriseCode.Value = enterpriseCode;
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // ����f�[�^���폜����
			sqlCommand.ExecuteNonQuery();

		}
		#endregion
		// ADD 2011.08.26 ���� ----------<<<<<
    }
}

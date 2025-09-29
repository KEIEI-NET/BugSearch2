//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���M���O�\��
// �v���O�����T�v   : ���M���O�\��DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhaimm
// �� �� ��  2013.06.26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���M���O�\�������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���M���O�\���̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : zhaimm</br>
    /// <br>Date       : 2013.06.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SAndESalSndLogDB : RemoteDB, ISAndESalSndLogDB
    {

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        public SAndESalSndLogDB() : base("PMSAE04007D", "Broadleaf.Application.Remoting.ParamData.SAndESalSndLogListCndtnWork", "SANDESALSNDLOGRF")
        {
        }

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        #region [�g�����U�N�V������������]
        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction��������</br>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //�g�����U�N�V������������

        #region ISAndESalSndLogDB �����o
        /// <summary>
        /// ����f�[�^���M���O�e�[�u���̃��O���擾
        /// </summary>
        /// <param name="sAndESalSndLogListResultWork">����f�[�^���M���O���o����</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sAndESalSndLogListCondPara">����f�[�^���M���O���o�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        public int SearchSAndESalSndLog(out object sAndESalSndLogListResultWork, out string errMessage, ref object sAndESalSndLogListCondPara, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            sAndESalSndLogListResultWork = null;
            errMessage = null;
            SqlConnection sqlConnection = null;
            SAndESalSndLogListCndtnWork _sAndESalSndLogListCndtnWork = sAndESalSndLogListCondPara as SAndESalSndLogListCndtnWork;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchSAndESalSndLogProc(out sAndESalSndLogListResultWork, out errMessage, ref _sAndESalSndLogListCndtnWork, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SAndESalSndLogDB.SearchSAndESalSndLog Exception=" + ex.Message);
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
            return status;
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u���̃��O�����폜����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        public int ResetSAndESalSndLog(out string errMessage, string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = null;
            SqlConnection sqlConnection = null;
            try
            {
                // �R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ResetSAndESalSndLogProc(out errMessage, enterpriseCode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SAndESalSndLogDB.ResetSAndESalSndLog Exception=" + ex.Message);
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
            return status;
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u���̃��O���擾
        /// </summary>
        /// <param name="sAndESalSndLogListResultWork">����f�[�^���M���O���o����</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="sAndESalSndLogListCondPara">����f�[�^���M���O���o�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        private int SearchSAndESalSndLogProc(out object sAndESalSndLogListResultWork, out string errMessage, ref SAndESalSndLogListCndtnWork sAndESalSndLogListCondPara, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            sAndESalSndLogListResultWork = null;
            errMessage = null;
            ArrayList al = new ArrayList(); // ���o����

            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectText = string.Empty;

                #region Select���쐬
                selectText += "SELECT" + Environment.NewLine;
                selectText += " SAESL.CREATEDATETIMERF" + Environment.NewLine;
                selectText += " ,SAESL.UPDATEDATETIMERF" + Environment.NewLine;
                selectText += " ,SAESL.ENTERPRISECODERF" + Environment.NewLine;
                selectText += " ,SAESL.FILEHEADERGUIDRF" + Environment.NewLine;
                selectText += " ,SAESL.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectText += " ,SAESL.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectText += " ,SAESL.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectText += " ,SAESL.LOGICALDELETECODERF" + Environment.NewLine;
                selectText += " ,SAESL.SECTIONCODERF" + Environment.NewLine;
                selectText += " ,SAESL.SANDEAUTOSENDDIVRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDDATETIMESTARTRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDDATETIMEENDRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDOBJDATESTARTRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDOBJDATEENDRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDOBJCUSTSTARTRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDOBJCUSTENDRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDOBJDIVRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDRESULTSRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDERRORCONTENTSRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDSLIPCOUNTRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDSLIPDTLCNTRF" + Environment.NewLine;
                selectText += " ,SAESL.SENDSLIPTOTALMNYRF FROM SANDESALSNDLOGRF AS SAESL" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectText, sqlConnection);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, sAndESalSndLogListCondPara, logicalMode);

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    if (sAndESalSndLogListCondPara.MaxSearchCt == 0)
                    {
                        al.Add(this.CopyToSAndESalSndLogListResultWorkFromReader(ref sqlDataReader));
                    }
                    else
                    {
                        if (al.Count < sAndESalSndLogListCondPara.MaxSearchCt)
                        {
                            al.Add(this.CopyToSAndESalSndLogListResultWorkFromReader(ref sqlDataReader));
                        }
                        else
                        {
                            sAndESalSndLogListCondPara.SearchOverFlg = true;
                            break;
                        }
                    }
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
                {
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
                base.WriteErrorLog(ex, "StockMoveListWorkDB.SearchSAndESalSndLogProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!sqlDataReader.IsClosed) sqlDataReader.Close();
            }

            sAndESalSndLogListResultWork = al;
            return status;
        }

        /// <summary>
        /// ����f�[�^���M���O�e�[�u���̃��O�����폜����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        private int ResetSAndESalSndLogProc(out string errMessage, string enterpriseCode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            errMessage = null;
            SqlCommand sqlCommand = null;
            try
            {
                string selectText = string.Empty;

                #region DELETE���쐬
                selectText += "DELETE FROM SANDESALSNDLOGRF " + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectText, sqlConnection);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereStringForReset(ref sqlCommand, enterpriseCode);
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMoveListWorkDB.ResetSAndESalSndLogProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
            }
            return status;
        }
        #endregion

        #region ��������
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_sAndESalSndLogListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SAndESalSndLogListCndtnWork _sAndESalSndLogListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            // WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            // ��ƃR�[�h
            retstring += " SAESL.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sAndESalSndLogListCndtnWork.EnterpriseCode);

            // �_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND SAESL.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND SAESL.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            // ���_�R�[�h
            if ((_sAndESalSndLogListCndtnWork.SectionCodes != null) && (_sAndESalSndLogListCndtnWork.SectionCodes.Length > 0))
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _sAndESalSndLogListCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND SAESL.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            // �J�n���M����
            if (_sAndESalSndLogListCndtnWork.SendDateTimeStart != 0)
            {
                retstring += " AND SAESL.SENDDATETIMESTARTRF >= @SENDDATETIMESTART" + Environment.NewLine;
                SqlParameter paraSendDateTimeStart = sqlCommand.Parameters.Add("@SENDDATETIMESTART", SqlDbType.BigInt);
                paraSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(_sAndESalSndLogListCndtnWork.SendDateTimeStart);

            }
            // �I�����M����
            if (_sAndESalSndLogListCndtnWork.SendDateTimeEnd != 0)
            {
                if (_sAndESalSndLogListCndtnWork.SendDateTimeStart == 0)
                {
                    retstring += " AND (SAESL.SENDDATETIMESTARTRF IS NULL OR";
                }
                else
                {
                    retstring += " AND (";
                }

                retstring += " SAESL.SENDDATETIMESTARTRF <= @SENDDATETIMEEND)" + Environment.NewLine;
                SqlParameter paraSendDateTimeEnd = sqlCommand.Parameters.Add("@SENDDATETIMEEND", SqlDbType.BigInt);
                paraSendDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(_sAndESalSndLogListCndtnWork.SendDateTimeEnd);
            }

            // S&E�������M�敪(0:�蓮,1:����)
            if (_sAndESalSndLogListCndtnWork.SAndEAutoSendDiv == 0)
            {
                // 0:�蓮
                retstring += " AND SAESL.SANDEAUTOSENDDIVRF=0" + Environment.NewLine;
            }
            else if (_sAndESalSndLogListCndtnWork.SAndEAutoSendDiv == 1)
            {
                // 1:����
                retstring += " AND SAESL.SANDEAUTOSENDDIVRF=1" + Environment.NewLine;
            }

            // �\�[�g���i���M�����i�J�n�j�~���j
            retstring += " ORDER BY SAESL.SENDDATETIMESTARTRF DESC" + Environment.NewLine;

            return retstring;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>Where����������</returns>
        private string MakeWhereStringForReset(ref SqlCommand sqlCommand, string enterpriseCode)
        {
            // WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            // ��ƃR�[�h
            retstring += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

            return retstring;
        }

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� SqlDataReader �� ScmInqLogWork
        /// </summary>
        /// <param name="sqlDataReader">SqlDataReader</param>
        /// <returns>SAndESalSndLogListResultWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        private SAndESalSndLogListResultWork CopyToSAndESalSndLogListResultWorkFromReader(ref SqlDataReader sqlDataReader)
        {
            // ����f�[�^���M���O���[�N
            SAndESalSndLogListResultWork wkSAndESalSndLogListResultWork = new SAndESalSndLogListResultWork();

            # region �N���X�֊i�[
            //����f�[�^���M���O�f�[�^�i�[����
            wkSAndESalSndLogListResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("CREATEDATETIMERF"));
            wkSAndESalSndLogListResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(sqlDataReader, sqlDataReader.GetOrdinal("UPDATEDATETIMERF"));
            wkSAndESalSndLogListResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("ENTERPRISECODERF"));
            wkSAndESalSndLogListResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(sqlDataReader, sqlDataReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkSAndESalSndLogListResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkSAndESalSndLogListResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkSAndESalSndLogListResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkSAndESalSndLogListResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("LOGICALDELETECODERF"));
            wkSAndESalSndLogListResultWork.SectionCode = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SECTIONCODERF"));
            wkSAndESalSndLogListResultWork.SAndEAutoSendDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SANDEAUTOSENDDIVRF"));
            wkSAndESalSndLogListResultWork.SendDateTimeStart = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDDATETIMESTARTRF"));
            wkSAndESalSndLogListResultWork.SendDateTimeEnd = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDDATETIMEENDRF"));
            wkSAndESalSndLogListResultWork.SendObjDateStart = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJDATESTARTRF"));
            wkSAndESalSndLogListResultWork.SendObjDateEnd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJDATEENDRF"));
            wkSAndESalSndLogListResultWork.SendObjCustStart = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJCUSTSTARTRF"));
            wkSAndESalSndLogListResultWork.SendObjCustEnd = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJCUSTENDRF"));
            wkSAndESalSndLogListResultWork.SendObjDiv = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDOBJDIVRF"));
            wkSAndESalSndLogListResultWork.SendResults = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDRESULTSRF"));
            wkSAndESalSndLogListResultWork.SendErrorContents = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("SENDERRORCONTENTSRF"));
            wkSAndESalSndLogListResultWork.SendSlipCount = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDSLIPCOUNTRF"));
            wkSAndESalSndLogListResultWork.SendSlipDtlCnt = SqlDataMediator.SqlGetInt32(sqlDataReader, sqlDataReader.GetOrdinal("SENDSLIPDTLCNTRF"));
            wkSAndESalSndLogListResultWork.SendSlipTotalMny = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("SENDSLIPTOTALMNYRF"));
            # endregion

            return wkSAndESalSndLogListResultWork;
        }
        # endregion
        #endregion

    }
}

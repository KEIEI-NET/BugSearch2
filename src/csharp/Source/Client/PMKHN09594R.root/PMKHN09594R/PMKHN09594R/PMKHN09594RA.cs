//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���[�����ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2010/05/24  �C�����e : �V�K�쐬
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���[�����ݒ�}�X�^�����e�i���XDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�����ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : �����</br>
	/// <br>Date       : 2010/05/24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class MailInfoSettingDB : RemoteDB , IMailInfoSettingDB
	{
		/// <summary>
		/// ���[�����ݒ�}�X�^�����e�i���XDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		/// </remarks>
		public MailInfoSettingDB() :
        base("PMKHN09596D", "Broadleaf.Application.Remoting.ParamData.MailInfoSettingWork", "MAILINFOSETTINGRF")
		{
        }

        # region -- �������� --
        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:MailInfoSettingWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST�̌�����߂��܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		public int SearchCnt(out int retCnt,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retCnt = 0;
            try
            {
                status = SearchCntMailInfoSettingProc(out retCnt, parabyte, readMode, logicalMode);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.SearchCnt Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^(readMode=0:MailInfoSettingWork�N���X�F��ƃR�[�h)</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST�̌�����߂��܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
        private int SearchCntMailInfoSettingProc(out int retCnt, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;

            MailInfoSettingWork mailsndmngWork = null;

			retCnt = 0;

			ArrayList al = new ArrayList();

            try
            {
			    try 
			    {	
				    // XML�̓ǂݍ���
                    mailsndmngWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    //SQL������
				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();

				    SqlCommand sqlCommand;
				    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					    (logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				    {
                        sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
					    //�_���폜�敪�ݒ�
					    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				    }
				    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
					    (logicalMode == ConstantManagement.LogicalMode.GetData012))
				    {
                        sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
					    //�_���폜�敪�ݒ�
					    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					    if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					    else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				    }
				    else 
				    {
                        sqlCommand = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
				    }
				    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);

				    //�f�[�^���[�h
				    retCnt = (int)sqlCommand.ExecuteScalar();
				    if (retCnt > 0)	status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			    }
			    catch (SqlException ex) 
			    {
				    //���N���X�ɗ�O��n���ď������Ă��炤
				    status = base.WriteSQLErrorLog(ex);
			    }
			    sqlConnection.Close();			
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.SearchCntMailSndMngProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		public int Search(out byte[] retbyte,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode)
		{		
			bool nextData;
			int retTotalCnt;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retbyte = null;
            try
            {
                status = SearchMailInfoSettingProc(out retbyte, out retTotalCnt, out nextData, parabyte, readMode, logicalMode, 0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.Search Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		public int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte,int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt)
		{		
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            nextData = false;
            retTotalCnt = 0;
            retbyte = null;
            try
            {
                status = SearchMailInfoSettingProc(out retbyte, out retTotalCnt, out nextData, parabyte, readMode, logicalMode, readCnt);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.SearchSpecification Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>		
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST��S�Ė߂��܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
        private int SearchMailInfoSettingProc(out byte[] retbyte, out int retTotalCnt, out bool nextData, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            MailInfoSettingWork mailInfoSettingWork = new MailInfoSettingWork();
			mailInfoSettingWork = null;

			retbyte = null;

			//��������0�ŏ�����
			retTotalCnt = 0;

			//�����w�胊�[�h�̏ꍇ�ɂ͎w�茏���{�P�����[�h����
			int _readCnt = readCnt;			
			if (_readCnt > 0) _readCnt += 1;
			//�����R�[�h�����ŏ�����
			nextData = false;

			ArrayList al = new ArrayList();

            try
            {
			    try 
			    {	
				    // XML�̓ǂݍ���
                    mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    //SQL������
				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();				

				    //�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
				    if ((readCnt > 0)&&(mailInfoSettingWork.MailSendMngNo == 0))
				    {
					    SqlCommand sqlCommandCount;
					    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
						    (logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
					    {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
						    //�_���폜�敪�ݒ�
						    SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
					    }
					    else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
					    {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
						    //�_���폜�敪�ݒ�
						    SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
						    if (logicalMode == ConstantManagement.LogicalMode.GetData01)	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
						    else															paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
					    }
					    else 
					    {
                            sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM MAILINFOSETTINGRF  WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);
					    }
					    SqlParameter paraEnterpriseCode = sqlCommandCount.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
					    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);

					    retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
				    }

				    SqlCommand sqlCommand;

				    //�f�[�^�Ǎ�
				    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||(logicalMode == ConstantManagement.LogicalMode.GetData1)||
					    (logicalMode == ConstantManagement.LogicalMode.GetData2)||(logicalMode == ConstantManagement.LogicalMode.GetData3))
				    {
					    //�����w�薳���̏ꍇ
					    if (readCnt == 0)
					    {
                            sqlCommand = new SqlCommand("SELECT * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
					    }
					    else
					    {
						    //�ꌏ�ڃ��[�h�̏ꍇ
						    if ((mailInfoSettingWork.MailSendMngNo == 0))
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
						    }
							    //Next���[�h�̏ꍇ
						    else
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF", sqlConnection);
							    SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							    paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendMngNo);
						    }
					    }
					    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				    }
				    else if	((logicalMode == ConstantManagement.LogicalMode.GetData01)||(logicalMode == ConstantManagement.LogicalMode.GetData012))
				    {
					    //�����w�薳���̏ꍇ
					    if (readCnt == 0)
					    {
                            sqlCommand = new SqlCommand("SELECT * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
					    }
					    else
					    {
						    //�ꌏ�ڃ��[�h�̏ꍇ
						    if ((mailInfoSettingWork.MailSendMngNo == 0))
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
						    }
							    //Next���[�h�̏ꍇ
						    else
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF", sqlConnection);
							    SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							    paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendMngNo);
						    }
					    }
					    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					    if	(logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					    else														  paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				    }
				    else
				    {
					    //�����w�薳���̏ꍇ
					    if (readCnt == 0)
					    {
                            sqlCommand = new SqlCommand("SELECT * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
					    }
					    else
					    {
						    //�ꌏ�ڃ��[�h�̏ꍇ
						    if ((mailInfoSettingWork.MailSendMngNo == 0))
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ORDER BY MAILSENDMNGNORF", sqlConnection);
						    }
						    else
						    {
                                sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND MAILSENDMNGNORF>@FINDMAILSENDMNGNO ORDER BY MAILSENDMNGNORF", sqlConnection);
							    SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);
							    paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendMngNo);
						    }
					    }
				    }
				    SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				    paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);

				    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				    int retCnt = 0;
				    while(myReader.Read())
				    {
					    //�߂�l�J�E���^�J�E���g
					    retCnt += 1;
					    if (readCnt > 0)
					    {
						    //�߂�l�̌������擾�w�������𒴂����ꍇ�I��
						    if (readCnt < retCnt) 
						    {
							    nextData = true;
							    break;
						    }
					    }

					    al.Add(CopyToMailInfoSettingWorkFromReader(ref myReader));

					    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				    }
			    }
			    catch (SqlException ex) 
			    {
				    //���N���X�ɗ�O��n���ď������Ă��炤
				    status = base.WriteSQLErrorLog(ex);
			    }

			    if(myReader.IsClosed == false)myReader.Close();
			    sqlConnection.Close();

			    // XML�֕ϊ����A������̃o�C�i����
                MailInfoSettingWork[] MailSndMngWorks = (MailInfoSettingWork[])al.ToArray(typeof(MailInfoSettingWork));
			    retbyte = XmlByteSerializer.Serialize(MailSndMngWorks);

            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "MailInfoSettingDB.SearchMailInfoSettingProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^��߂��܂�
		/// </summary>
        /// <param name="parabyte">MailInfoSettingWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^��߂��܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		public int Read(ref byte[] parabyte , int readMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            MailInfoSettingWork mailInfoSettingWork = new MailInfoSettingWork();

            try
            {
			    try 
			    {			
				    // XML�̓ǂݍ���
                    mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();

				    //Select�R�}���h�̐���
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    //SqlParameter findParaMailSendMngNo = sqlCommand.Parameters.Add("@FINDMAILSENDMNGNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);
                    //findParaMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendMngNo);

				    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				    if(myReader.Read())
				    {
                        mailInfoSettingWork = CopyToMailInfoSettingWorkFromReader(ref myReader);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				    }
			    }
			    catch (SqlException ex) 
			    {
				    //���N���X�ɗ�O��n���ď������Ă��炤
				    status = base.WriteSQLErrorLog(ex);
			    }

			    if(myReader.IsClosed == false)myReader.Close();
			    sqlConnection.Close();

			    // XML�֕ϊ����A������̃o�C�i����
			    parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.Read Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="mailInfoSettingWork">��������</param>
        /// <param name="paraMailInfoSettingWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        public int Search(out object mailInfoSettingWork, object paraMailInfoSettingWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            mailInfoSettingWork = null;
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                return SearchMailInfoSettingProc(out mailInfoSettingWork, paraMailInfoSettingWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MailInfoSettingDB.Search");
                mailInfoSettingWork = new ArrayList();
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
        /// �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST��S�Ė߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="objMailInfoSettingWork">��������</param>
        /// <param name="paraMailInfoSettingWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        private int SearchMailInfoSettingProc(out object objMailInfoSettingWork, object paraMailInfoSettingWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            MailInfoSettingWork mailsndmngWork = new MailInfoSettingWork();
            mailsndmngWork = null;

            objMailInfoSettingWork = null;

            ArrayList al = new ArrayList();
            try
            {
                ArrayList mailsndmngWorkList = paraMailInfoSettingWork as ArrayList;
                if (mailsndmngWorkList == null)
                {
                    mailsndmngWork = paraMailInfoSettingWork as MailInfoSettingWork;
                }
                else
                {
                    if (mailsndmngWorkList.Count > 0)
                    {
                        mailsndmngWork = mailsndmngWorkList[0] as MailInfoSettingWork;
                    }
                }

                sqlCommand = new SqlCommand("SELECT * FROM MAILINFOSETTINGRF WHERE ", sqlConnection);

                //��ƃR�[�h
                sqlCommand.CommandText += "ENTERPRISECODERF=@ENTERPRISECODE ";
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailsndmngWork.EnterpriseCode);

                //�_���폜�敪
                string wkstring = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (wkstring != "")
                {
                    sqlCommand.CommandText += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToMailInfoSettingWorkFromReader(ref myReader));

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
                if (!myReader.IsClosed) myReader.Close();
            }

            objMailInfoSettingWork = al;

            return status;
        }
        # endregion

        # region -- �o�^��X�V���� --
        /// <summary>
		/// ���[�����ݒ�}�X�^����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">MailInfoSettingWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�����ݒ�}�X�^����o�^�A�X�V���܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		public int Write(ref byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			    try 
			    {
				    // XML�̓ǂݍ���
                    MailInfoSettingWork mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();

				    //Select�R�}���h�̐���
                    SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, MAILSENDMNGNORF FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);

				    myReader = sqlCommand.ExecuteReader();
				    if(myReader.Read())
				    {
					    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					    if (_updateDateTime != mailInfoSettingWork.UpdateDateTime)
					    {
						    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (mailInfoSettingWork.UpdateDateTime == DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            }
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            }
						    sqlCommand.Cancel();
						    if(myReader.IsClosed == false)myReader.Close();
						    sqlConnection.Close();
						    return status;
					    }

                        sqlCommand.CommandText = "UPDATE MAILINFOSETTINGRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , MAILSENDMNGNORF=@MAILSENDMNGNO , MAILADDRESSRF=@MAILADDRESS , DIALUPCODERF=@DIALUPCODE , DIALUPCONNECTNAMERF=@DIALUPCONNECTNAME , DIALUPLOGINNAMERF=@DIALUPLOGINNAME , DIALUPPASSWORDRF=@DIALUPPASSWORD , ACCESSTELNORF=@ACCESSTELNO , POP3USERIDRF=@POP3USERID , POP3PASSWORDRF=@POP3PASSWORD , POP3SERVERNAMERF=@POP3SERVERNAME , SMTPSERVERNAMERF=@SMTPSERVERNAME , SMTPUSERIDRF=@SMTPUSERID , SMTPPASSWORDRF=@SMTPPASSWORD , SMTPAUTHUSEDIVRF=@SMTPAUTHUSEDIV , SENDERNAMERF=@SENDERNAME , POPBEFORESMTPUSEDIVRF=@POPBEFORESMTPUSEDIV , POPSERVERPORTNORF=@POPSERVERPORTNO , SMTPSERVERPORTNORF=@SMTPSERVERPORTNO , MAILSERVERTIMEOUTVALRF=@MAILSERVERTIMEOUTVAL , BACKUPSENDDIVCDRF=@BACKUPSENDDIVCD , BACKUPFORMALRF=@BACKUPFORMAL , MAILSENDDIVUNITCNTRF=@MAILSENDDIVUNITCNT , FILEPATHNMRF=@FILEPATHNM WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
					    //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);

					    //�X�V�w�b�_����ݒ�
					    object obj = (object)this;
					    IFileHeader flhd = (IFileHeader)mailInfoSettingWork;
                        FileHeader fileHeader = new FileHeader(obj);
					    fileHeader.SetUpdateHeader(ref flhd,obj);
				    }
				    else
				    {
					    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					    if (mailInfoSettingWork.UpdateDateTime > DateTime.MinValue)
					    {
						    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						    sqlCommand.Cancel();
						    if(myReader.IsClosed == false)myReader.Close();
						    sqlConnection.Close();
						    return status;
					    }

					    //�V�K�쐬����SQL���𐶐�
                        sqlCommand.CommandText = "INSERT INTO MAILINFOSETTINGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, MAILSENDMNGNORF, MAILADDRESSRF, DIALUPCODERF, DIALUPCONNECTNAMERF, DIALUPLOGINNAMERF, DIALUPPASSWORDRF, ACCESSTELNORF, POP3USERIDRF, POP3PASSWORDRF, POP3SERVERNAMERF, SMTPSERVERNAMERF, SMTPUSERIDRF, SMTPPASSWORDRF, SMTPAUTHUSEDIVRF, SENDERNAMERF, POPBEFORESMTPUSEDIVRF, POPSERVERPORTNORF, SMTPSERVERPORTNORF, MAILSERVERTIMEOUTVALRF, BACKUPSENDDIVCDRF, BACKUPFORMALRF, MAILSENDDIVUNITCNTRF, FILEPATHNMRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @MAILSENDMNGNO, @MAILADDRESS, @DIALUPCODE, @DIALUPCONNECTNAME, @DIALUPLOGINNAME, @DIALUPPASSWORD, @ACCESSTELNO, @POP3USERID, @POP3PASSWORD, @POP3SERVERNAME, @SMTPSERVERNAME, @SMTPUSERID, @SMTPPASSWORD, @SMTPAUTHUSEDIV, @SENDERNAME, @POPBEFORESMTPUSEDIV, @POPSERVERPORTNO, @SMTPSERVERPORTNO, @MAILSERVERTIMEOUTVAL, @BACKUPSENDDIVCD, @BACKUPFORMAL, @MAILSENDDIVUNITCNT, @FILEPATHNM)";
					    //�o�^�w�b�_����ݒ�
					    object obj = (object)this;
					    IFileHeader flhd = (IFileHeader)mailInfoSettingWork;
                        FileHeader fileHeader = new FileHeader(obj);
					    fileHeader.SetInsertHeader(ref flhd,obj);
				    }
				    if(myReader.IsClosed == false)myReader.Close();

                    #region �l�Z�b�g
                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraMailSendMngNo = sqlCommand.Parameters.Add("@MAILSENDMNGNO", SqlDbType.Int);
                    SqlParameter paraMailAddress = sqlCommand.Parameters.Add("@MAILADDRESS", SqlDbType.NVarChar);
                    SqlParameter paraDialUpCode = sqlCommand.Parameters.Add("@DIALUPCODE", SqlDbType.Int);
                    SqlParameter paraDialUpConnectName = sqlCommand.Parameters.Add("@DIALUPCONNECTNAME", SqlDbType.NVarChar);
                    SqlParameter paraDialUpLoginName = sqlCommand.Parameters.Add("@DIALUPLOGINNAME", SqlDbType.NVarChar);
                    SqlParameter paraDialUpPassword = sqlCommand.Parameters.Add("@DIALUPPASSWORD", SqlDbType.NVarChar);
                    SqlParameter paraAccessTelNo = sqlCommand.Parameters.Add("@ACCESSTELNO", SqlDbType.NVarChar);
                    SqlParameter paraPop3UserId = sqlCommand.Parameters.Add("@POP3USERID", SqlDbType.NVarChar);
                    SqlParameter paraPop3Password = sqlCommand.Parameters.Add("@POP3PASSWORD", SqlDbType.NVarChar);
                    SqlParameter paraPop3ServerName = sqlCommand.Parameters.Add("@POP3SERVERNAME", SqlDbType.NVarChar);
                    SqlParameter paraSmtpServerName = sqlCommand.Parameters.Add("@SMTPSERVERNAME", SqlDbType.NVarChar);
                    SqlParameter paraSmtpUserId = sqlCommand.Parameters.Add("@SMTPUSERID", SqlDbType.NVarChar);
                    SqlParameter paraSmtpPassword = sqlCommand.Parameters.Add("@SMTPPASSWORD", SqlDbType.NVarChar);
                    SqlParameter paraSmtpAuthUseDiv = sqlCommand.Parameters.Add("@SMTPAUTHUSEDIV", SqlDbType.Int);
                    SqlParameter paraSenderName = sqlCommand.Parameters.Add("@SENDERNAME", SqlDbType.NVarChar);
                    SqlParameter paraPopBeforeSmtpUseDiv = sqlCommand.Parameters.Add("@POPBEFORESMTPUSEDIV", SqlDbType.Int);
                    SqlParameter paraPopServerPortNo = sqlCommand.Parameters.Add("@POPSERVERPORTNO", SqlDbType.Int);
                    SqlParameter paraSmtpServerPortNo = sqlCommand.Parameters.Add("@SMTPSERVERPORTNO", SqlDbType.Int);
                    SqlParameter paraMailServerTimeoutVal = sqlCommand.Parameters.Add("@MAILSERVERTIMEOUTVAL", SqlDbType.Int);
                    SqlParameter paraBackupSendDivCd = sqlCommand.Parameters.Add("@BACKUPSENDDIVCD", SqlDbType.Int);
                    SqlParameter paraBackupFormal = sqlCommand.Parameters.Add("@BACKUPFORMAL", SqlDbType.Int);
                    SqlParameter paraMailSendDivUnitCnt = sqlCommand.Parameters.Add("@MAILSENDDIVUNITCNT", SqlDbType.Int);
                    SqlParameter paraFilePathNm = sqlCommand.Parameters.Add("@FILEPATHNM", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailInfoSettingWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailInfoSettingWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(mailInfoSettingWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);
                    paraMailSendMngNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendMngNo);
                    paraMailAddress.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.MailAddress);
                    paraDialUpCode.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.DialUpCode);
                    paraDialUpConnectName.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.DialUpConnectName);
                    paraDialUpLoginName.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.DialUpLoginName);
                    paraDialUpPassword.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.DialUpPassword);
                    paraAccessTelNo.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.AccessTelNo);
                    paraPop3UserId.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.Pop3UserId);
                    paraPop3Password.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.Pop3Password);
                    paraPop3ServerName.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.Pop3ServerName);
                    paraSmtpServerName.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SmtpServerName);
                    paraSmtpUserId.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SmtpUserId);
                    paraSmtpPassword.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SmtpPassword);
                    paraSmtpAuthUseDiv.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.SmtpAuthUseDiv);
                    paraSenderName.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SenderName);
                    paraPopBeforeSmtpUseDiv.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.PopBeforeSmtpUseDiv);
                    paraPopServerPortNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.PopServerPortNo);
                    paraSmtpServerPortNo.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.SmtpServerPortNo);
                    paraMailServerTimeoutVal.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailServerTimeoutVal);
                    paraBackupSendDivCd.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.BackupSendDivCd);
                    paraBackupFormal.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.BackupFormal);
                    paraMailSendDivUnitCnt.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.MailSendDivUnitCnt);
                    paraFilePathNm.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.FilePathNm);
                    #endregion

				    sqlCommand.ExecuteNonQuery();

				    // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				    parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);

				    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			    }
			    catch (SqlException ex) 
			    {
				    //���N���X�ɗ�O��n���ď������Ă��炤
				    status = base.WriteSQLErrorLog(ex);
			    }

			    if(myReader.IsClosed == false)myReader.Close();
			    sqlConnection.Close();
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.Write Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
        }
        # endregion

        #region -- �폜��������� --
        /// <summary>
		/// ���[�����ݒ�}�X�^��_���폜���܂�
		/// </summary>
        /// <param name="parabyte">MailInfoSettingWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�����ݒ�}�X�^��_���폜���܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		public int LogicalDelete(ref byte[] parabyte)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = LogicalDeleteMailInfoSettingProc(ref parabyte, 0);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.LogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
		}

		/// <summary>
		/// �_���폜���[�����ݒ�}�X�^�𕜊����܂�
		/// </summary>
		/// <param name="parabyte">MailInfoSettingWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���[�����ݒ�}�X�^�𕜊����܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		public int RevivalLogicalDelete(ref byte[] parabyte)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                status = LogicalDeleteMailInfoSettingProc(ref parabyte, 1);
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.RevivalLogicalDelete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

		/// <summary>
		/// ���[�����ݒ�}�X�^�̘_���폜�𑀍삵�܂�
		/// </summary>
        /// <param name="parabyte">MailInfoSettingWork�I�u�W�F�N�g</param>
		/// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�����ݒ�}�X�^�̘_���폜�𑀍삵�܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
        private int LogicalDeleteMailInfoSettingProc(ref byte[] parabyte, int procMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			int logicalDelCd = 0;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			    try		
			    {
				    // XML�̓ǂݍ���
                    MailInfoSettingWork mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);

				    myReader = sqlCommand.ExecuteReader();
				    if(myReader.Read())
				    {
					    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					    if (_updateDateTime != mailInfoSettingWork.UpdateDateTime)
					    {
						    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						    sqlCommand.Cancel();
						    if(myReader.IsClosed == false)myReader.Close();
						    sqlConnection.Close();
						    return status;
					    }
					    //���݂̘_���폜�敪���擾
					    logicalDelCd	=	SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE MAILINFOSETTINGRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
					    //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);

					    //�X�V�w�b�_����ݒ�
					    object obj = (object)this;
					    IFileHeader flhd = (IFileHeader)mailInfoSettingWork;
                        FileHeader fileHeader = new FileHeader(obj);
					    fileHeader.SetUpdateHeader(ref flhd,obj);
				    }
				    else
				    {
					    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					    sqlCommand.Cancel();
					    if(myReader.IsClosed == false)myReader.Close();
					    sqlConnection.Close();
					    return status;
				    }
				    sqlCommand.Cancel();
				    if(myReader.IsClosed == false)myReader.Close();

				    //�_���폜���[�h�̏ꍇ
				    if (procMode == 0)
				    {
					    if (logicalDelCd == 3)
					    {
						    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
						    sqlCommand.Cancel();
						    if(myReader.IsClosed == false)myReader.Close();
						    sqlConnection.Close();
						    return status;
					    }
                        else if (logicalDelCd == 0)
                        {
                            mailInfoSettingWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                        }
                        else
                        {
                            mailInfoSettingWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
				    }
				    else
				    {
                        if (logicalDelCd == 1)
                        {
                            mailInfoSettingWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                        }
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
				    }

				    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
				    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

				    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
				    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(mailInfoSettingWork.UpdateDateTime);
				    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdEmployeeCode);
				    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdAssemblyId1);
				    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.UpdAssemblyId2);
				    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(mailInfoSettingWork.LogicalDeleteCode);

				    sqlCommand.ExecuteNonQuery();

				    // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
				    parabyte = XmlByteSerializer.Serialize(mailInfoSettingWork);

				    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			    }
			    catch (SqlException ex) 
			    {
				    //���N���X�ɗ�O��n���ď������Ă��炤
				    status = base.WriteSQLErrorLog(ex);
			    }

			    if(myReader.IsClosed == false)myReader.Close();
			    sqlConnection.Close();
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.LogicalDeleteMailSndMngProc Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
		}

		/// <summary>
		/// ���[�����ݒ�}�X�^�𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">���[�����ݒ�}�X�^�I�u�W�F�N�g</param>
		/// <returns></returns>
		/// <br>Note       : ���[�����ݒ�}�X�^�𕨗��폜���܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		public int Delete(byte[] parabyte)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;

            try
            {
			    try 
			    {
				    // XML�̓ǂݍ���
                    MailInfoSettingWork mailInfoSettingWork = (MailInfoSettingWork)XmlByteSerializer.Deserialize(parabyte, typeof(MailInfoSettingWork));

                    //���epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

				    sqlConnection = new SqlConnection(connectionText);
				    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);

				    myReader = sqlCommand.ExecuteReader();
				    if(myReader.Read())
				    {
					    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
					    if (_updateDateTime != mailInfoSettingWork.UpdateDateTime)
					    {
						    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						    sqlCommand.Cancel();
						    if(myReader.IsClosed == false)myReader.Close();
						    sqlConnection.Close();
						    return status;
					    }

                        sqlCommand.CommandText = "DELETE FROM MAILINFOSETTINGRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
					    //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(mailInfoSettingWork.SectionCode);
                    }
				    else
				    {
					    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
					    sqlCommand.Cancel();
					    if(myReader.IsClosed == false)myReader.Close();
					    sqlConnection.Close();
					    return status;
				    }
				    if(myReader.IsClosed == false)myReader.Close();

				    sqlCommand.ExecuteNonQuery();

				    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			    }
			    catch (SqlException ex) 
			    {
				    //���N���X�ɗ�O��n���ď������Ă��炤
				    status = base.WriteSQLErrorLog(ex);
			    }

			    if(myReader.IsClosed == false)myReader.Close();
			    sqlConnection.Close();
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex,"MailInfoSettingDB.Delete Exception="+ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

			return status;
        }
        # endregion

        # region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// ���[�����ݒ�}�X�^�N���X�i�[���� Reader �� MailInfoSettingWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>MailInfoSettingWork</returns>
        /// <remarks>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        private MailInfoSettingWork CopyToMailInfoSettingWorkFromReader(ref SqlDataReader myReader)
        {
            MailInfoSettingWork wkMailInfoSettingWork = new MailInfoSettingWork();

            #region �N���X�֊i�[
            wkMailInfoSettingWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkMailInfoSettingWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkMailInfoSettingWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkMailInfoSettingWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkMailInfoSettingWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkMailInfoSettingWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkMailInfoSettingWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkMailInfoSettingWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkMailInfoSettingWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkMailInfoSettingWork.MailSendMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDMNGNORF"));
            wkMailInfoSettingWork.MailAddress = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAILADDRESSRF"));
            wkMailInfoSettingWork.DialUpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIALUPCODERF"));
            wkMailInfoSettingWork.DialUpConnectName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPCONNECTNAMERF"));
            wkMailInfoSettingWork.DialUpLoginName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPLOGINNAMERF"));
            wkMailInfoSettingWork.DialUpPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DIALUPPASSWORDRF"));
            wkMailInfoSettingWork.AccessTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACCESSTELNORF"));
            wkMailInfoSettingWork.Pop3UserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3USERIDRF"));
            wkMailInfoSettingWork.Pop3Password = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3PASSWORDRF"));
            wkMailInfoSettingWork.Pop3ServerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POP3SERVERNAMERF"));
            wkMailInfoSettingWork.SmtpServerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPSERVERNAMERF"));
            wkMailInfoSettingWork.SmtpUserId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPUSERIDRF"));
            wkMailInfoSettingWork.SmtpPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SMTPPASSWORDRF"));
            wkMailInfoSettingWork.SmtpAuthUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SMTPAUTHUSEDIVRF"));
            wkMailInfoSettingWork.SenderName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDERNAMERF"));
            wkMailInfoSettingWork.PopBeforeSmtpUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POPBEFORESMTPUSEDIVRF"));
            wkMailInfoSettingWork.PopServerPortNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POPSERVERPORTNORF"));
            wkMailInfoSettingWork.SmtpServerPortNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SMTPSERVERPORTNORF"));
            wkMailInfoSettingWork.MailServerTimeoutVal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSERVERTIMEOUTVALRF"));
            wkMailInfoSettingWork.BackupSendDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BACKUPSENDDIVCDRF"));
            wkMailInfoSettingWork.BackupFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BACKUPFORMALRF"));
            wkMailInfoSettingWork.MailSendDivUnitCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAILSENDDIVUNITCNTRF"));
            wkMailInfoSettingWork.FilePathNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEPATHNMRF"));
            #endregion

            return wkMailInfoSettingWork;
        }
        #endregion
    }
}


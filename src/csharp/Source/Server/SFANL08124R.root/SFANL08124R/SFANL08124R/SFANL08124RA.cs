using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���R���[�󎚈ʒu�ݒ胊���[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note         : ���R���[�󎚈ʒu�ݒ��IOWrite���s���N���X�ł��B</br>
	/// <br>Programmer   : 22024 ����@�_�u</br>
	/// <br>Date         : 2007.05.10</br>
	/// <br></br>
	/// <br>UpdateNote   : 2008.06.03  22018 ��� ���b</br>
    /// <br>               PM.NS ���R���[�`�[�����ύX�B</br>
    /// <br>UpdateNote   : 2010/08/25  ����</br>
    /// <br>               redmine 13549�̑Ή�</br>
	/// </remarks>
	[Serializable]
	public class FrePrtPSetDB : RemoteDB, IFrePrtPSetDB
	{
		#region Constructor
		/// <summary>
		/// ���R���[�󎚈ʒu�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note		: DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public FrePrtPSetDB()
			: base("SFANL08123D", "Broadleaf.Application.Remoting.ParamData.FrePrtPSetWork", "FREPRTPSETRF")
		{
		}
		#endregion

		#region IFrePrtPSetDB �����o
		#region WriteLog
		/// <summary>
		/// ���O�o�͏���
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="logMessage">���O���b�Z�[�W</param>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���O���b�Z�[�W��ۑ����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
        public void WriteLog( string enterpriseCode, string employeeCode, string logMessage )
        {
            WriteLogProc( enterpriseCode, employeeCode, logMessage );
        }
        /// <summary>
        /// ���O�o�͏���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="logMessage">���O���b�Z�[�W</param>
        private void WriteLogProc( string enterpriseCode, string employeeCode, string logMessage )
		{
			string errMsg = string.Empty;

			SqlConnection sqlConnection = null;
			try
			{
				//SQL������
				sqlConnection = CreateSqlConnection();
				sqlConnection.Open();
			}
			finally
			{
				if (sqlConnection != null) sqlConnection.Close();
			}
		}
		#endregion

		#region GetLastUserPrtPprIdDerivNo
		/// <summary>
		/// �ŏI���[�U�[���[ID�}�ԍ��擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <returns>�ŏI���[�U�[���[ID�}�ԍ�</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu���̍ŏI�}�ԍ����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
        public int GetLastUserPrtPprIdDerivNo( string enterpriseCode, string outputFormFileName )
        {
            return GetLastUserPrtPprIdDerivNoProc( enterpriseCode, outputFormFileName );
        }
        /// <summary>
        /// �ŏI���[�U�[���[ID�}�ԍ��擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <returns>�ŏI���[�U�[���[ID�}�ԍ�</returns>
        private int GetLastUserPrtPprIdDerivNoProc( string enterpriseCode, string outputFormFileName )
		{
			string errMsg = string.Empty;
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			int userPrtPprIdDerivNo = 0;

			SqlConnection sqlConnection = null;
			SqlDataReader myReader = null;
			try
			{
				//SQL������
				sqlConnection = CreateSqlConnection();
				sqlConnection.Open();

				// Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT USERPRTPPRIDDERIVNO=MAX(USERPRTPPRIDDERIVNORF) FROM FREPRTPSETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE  AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME", sqlConnection);
				// ��ƃR�[�h
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				findParaEnterpriseCode.Value = enterpriseCode;
				// �o�̓t�@�C����
				SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
				findParaOutputFormFileName.Value = outputFormFileName;

				// �^�C���A�E�g���Ԑݒ�
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.Common);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					userPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNO"));
				}
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex, "FrePrtPSetDB.GetLastUserPrtPprIdDerivNo", status);
				if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
					errMsg = "���R���[���o�������׃}�X�^�擾�������Ƀ^�C���A�E�g���������܂����B";
				else
					errMsg = ex.Message;
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "FrePrtPSetDB.GetLastUserPrtPprIdDerivNo", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
				errMsg = ex.Message;
			}
			finally
			{
				if (!myReader.IsClosed) myReader.Close();
				if (sqlConnection != null) sqlConnection.Close();
			}

			return userPrtPprIdDerivNo;
		}
		#endregion

		#region Search
		/// <summary>
		/// ���R���[���o�������׃}�X�^�擾�����i�S���j
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="frePExCndDWorkArray">���R���[���o�������׃��[�N�}�X�^�z��</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[���o�������׃��[�N�}�X�^�z���S���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
        public int SearchFrePExCndD( string enterpriseCode, ConstantManagement.LogicalMode logicalMode, out object frePExCndDWorkArray, out bool msgDiv, out string errMsg )
        {
            return SearchFrePExCndDProc( enterpriseCode, logicalMode, out frePExCndDWorkArray, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[���o�������׃}�X�^�擾�����i�S���j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="frePExCndDWorkArray">���R���[���o�������׃��[�N�}�X�^�z��</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchFrePExCndDProc( string enterpriseCode, ConstantManagement.LogicalMode logicalMode, out object frePExCndDWorkArray, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			msgDiv = false;
			errMsg = string.Empty;
			frePExCndDWorkArray = new FrePExCndDWork[0];

			SqlConnection sqlConnection = null;
			try
			{
				List<FrePExCndDWork> frePExCndDWorkList;

				//SQL������
				sqlConnection = CreateSqlConnection();
				sqlConnection.Open();

				status = SearchFrePExCndDProc(enterpriseCode, logicalMode, out frePExCndDWorkList, sqlConnection);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					frePExCndDWorkArray = frePExCndDWorkList.ToArray();
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex, "FrePrtPSetDB.SearchFrePExCndD", status);
				if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				{
					msgDiv = true;
					errMsg = "���R���[���o�������׃}�X�^�擾�������Ƀ^�C���A�E�g���������܂����B";
				}
				else
				{
					errMsg = ex.Message;
				}
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "FrePrtPSetDB.SearchFrePExCndD", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if (sqlConnection != null) sqlConnection.Close();
			}

			return status;
		}
		#endregion

		#region Read
		/// <summary>
		/// ���R���[�󎚈ʒu���擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="retCustomSerializeArrayList">���R���[�󎚈ʒu���J�X�^���V���A���C�YLIST</param>
		/// <param name="printPosClassData">�󎚈ʒu�o�C�i���f�[�^</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu�����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
        public int Read( string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo, out object retCustomSerializeArrayList, out byte[] printPosClassData, out bool msgDiv, out string errMsg )
        {
            return ReadProc( enterpriseCode, outputFormFileName, userPrtPprIdDerivNo, out retCustomSerializeArrayList, out printPosClassData, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[�󎚈ʒu���擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
        /// <param name="retCustomSerializeArrayList">���R���[�󎚈ʒu���J�X�^���V���A���C�YLIST</param>
        /// <param name="printPosClassData">�󎚈ʒu�o�C�i���f�[�^</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int ReadProc( string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo, out object retCustomSerializeArrayList, out byte[] printPosClassData, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			retCustomSerializeArrayList = null;
			printPosClassData = null;
			msgDiv = false;
			errMsg = string.Empty;

			SqlConnection sqlConnection = null;
			try
			{
				//SQL������
				sqlConnection = CreateSqlConnection();
				sqlConnection.Open();

				CustomSerializeArrayList retList;
				status = ReadProc(enterpriseCode, outputFormFileName, userPrtPprIdDerivNo, out retList, out printPosClassData, sqlConnection);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					retCustomSerializeArrayList = retList;
				}
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex, "FrePrtPSetDB.Read", status);
				if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				{
					msgDiv = true;
					errMsg = "���R���[�󎚈ʒu���擾�������Ƀ^�C���A�E�g���������܂����B";
				}
				else
				{
					errMsg = ex.Message;
				}
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "FrePrtPSetDB.Read", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if (sqlConnection != null) sqlConnection.Close();
			}

			return status;
		}
		#endregion

		#region Write
		/// <summary>
		/// ���R���[���ڐݒ�}�X�^��������
		/// </summary>
		/// <param name="saveCustomSerializeArrayList">���R���[�󎚈ʒu���J�X�^���V���A���C�YLIST</param>
		/// <param name="printPosClassData">�󎚈ʒu�o�C�i���f�[�^</param>
		/// <param name="isNewWrite">�V�K�o�^</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu����o�^���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.05.10</br>
		/// </remarks>
        public int Write( ref object saveCustomSerializeArrayList, byte[] printPosClassData, bool isNewWrite, out bool msgDiv, out string errMsg )
        {
            return WriteProc( ref saveCustomSerializeArrayList, printPosClassData, isNewWrite, out msgDiv, out errMsg );
        }
        /// <summary>
        /// ���R���[���ڐݒ�}�X�^��������
        /// </summary>
        /// <param name="saveCustomSerializeArrayList">���R���[�󎚈ʒu���J�X�^���V���A���C�YLIST</param>
        /// <param name="printPosClassData">�󎚈ʒu�o�C�i���f�[�^</param>
        /// <param name="isNewWrite">�V�K�o�^</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: redmine 13549�̑Ή�</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2010/08/25</br>
        /// </remarks>
        private int WriteProc( ref object saveCustomSerializeArrayList, byte[] printPosClassData, bool isNewWrite, out bool msgDiv, out string errMsg )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			msgDiv = false;
			errMsg = string.Empty;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			try
			{
				CustomSerializeArrayList retList = new CustomSerializeArrayList();
				if (saveCustomSerializeArrayList != null)
				{
					CustomSerializeArrayList saveDataList = (CustomSerializeArrayList)saveCustomSerializeArrayList;

					// �J�X�^���V���A���C�YLIST��菑�����ރf�[�^���擾
					FrePrtPSetWork frePrtPSetWork = null;
					FrePprECndWork[] frePprECndWorkArray = null;
					FrePprSrtOWork[] frePprSrtOWorkArray = null;
					SlipPrtSetWork[] slipPrtSetWorkArray = null;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                    DmdPrtPtnWork[] dmdPrtPtnWorkArray = null;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
					for (int ix = 0 ; ix != saveDataList.Count ; ix++)
					{
						ArrayList wkList = (ArrayList)saveDataList[ix];
						if (wkList[0] is FrePrtPSetWork)
						{
							frePrtPSetWork = (FrePrtPSetWork)wkList[0];
							frePrtPSetWork.PrintPosClassData = printPosClassData;
						}
						else if (wkList[0] is FrePprECndWork)
						{
							frePprECndWorkArray = (FrePprECndWork[])wkList.ToArray(typeof(FrePprECndWork));
						}
						else if (wkList[0] is FrePprSrtOWork)
						{
							frePprSrtOWorkArray = (FrePprSrtOWork[])wkList.ToArray(typeof(FrePprSrtOWork));
						}
						else if (wkList[0] is SlipPrtSetWork)
						{
							slipPrtSetWorkArray = (SlipPrtSetWork[])wkList.ToArray(typeof(SlipPrtSetWork));
						}
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                        else if ( wkList[0] is DmdPrtPtnWork )
                        {
                            dmdPrtPtnWorkArray = (DmdPrtPtnWork[])wkList.ToArray( typeof( DmdPrtPtnWork ) );
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
					}

					//�R�l�N�V��������
					sqlConnection = CreateSqlConnection();
					if (sqlConnection == null) return status;
					sqlConnection.Open();

					if (frePrtPSetWork != null)
					{
						// �g�����U�N�V�����J�n
						sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

						// ���R���[�󎚈ʒu�ݒ�ۑ������i���C�����j
						status = WriteFrePrtPSetProc(ref frePrtPSetWork, sqlConnection, sqlTransaction);
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							ArrayList addList = new ArrayList();
							frePrtPSetWork.PrintPosClassData = new byte[0];
							addList.Add(frePrtPSetWork);
							retList.Add(addList);
						}

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							if (frePprECndWorkArray != null && frePprECndWorkArray.Length > 0)
							{
								// ���R���[���o�����ݒ�ۑ������i���C�����j
								status = WriteFrePprECndProc(ref frePprECndWorkArray, sqlConnection, sqlTransaction);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
									retList.Add(new ArrayList(frePprECndWorkArray));
							}
						}

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							// ���R���[�\�[�g���ʕۑ������i���C�����j
							if (frePprSrtOWorkArray != null && frePprSrtOWorkArray.Length > 0)
							{
								status = WriteFrePprSrtOProc(ref frePprSrtOWorkArray, sqlConnection, sqlTransaction);
								if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
									retList.Add(new ArrayList(frePprSrtOWorkArray));
							}
						}

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                        //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && isNewWrite)
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                        if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
                        {
							// ���[�g�p�敪�i1:���[,2:�`�[,5:�������j   //��5:������ m.suzuki ADD
							switch (frePrtPSetWork.PrintPaperUseDivcd)
							{
								case 1:
								{
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                                    if ( !isNewWrite ) break;
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD

									// ���R���[�O���[�v�U�֏���S�O���[�v�iFreePrtPprGroupCd=0�j�ɓo�^
									FreePprGrpDB freePprGrpDB = new FreePprGrpDB();
									status = freePprGrpDB.EntryFrePprGrTr(
										frePrtPSetWork.EnterpriseCode,
										frePrtPSetWork.DisplayName,
										frePrtPSetWork.OutputFormFileName,
										frePrtPSetWork.UserPrtPprIdDerivNo,
										sqlConnection,
										sqlTransaction,
										out msgDiv,
										out errMsg);
									break;
								}
								case 2:
								{
									if (slipPrtSetWorkArray != null)
									{
										List<SlipPrtSetWork> slipPrtSetList = new List<SlipPrtSetWork>(slipPrtSetWorkArray);

										// �`�[����ݒ�}�X�^�ɓo�^
										SlipPrtSetDB slipPrtSetDB = new SlipPrtSetDB();
                                        status = slipPrtSetDB.Write( slipPrtSetList, ref sqlConnection, ref sqlTransaction );
									}
									break;
								}
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                                case 5:
                                {
                                    if ( dmdPrtPtnWorkArray != null )
                                    {
                                        foreach ( DmdPrtPtnWork dmdPrtPtnWork in dmdPrtPtnWorkArray )
                                        {
                                            DmdPrtPtnWork wkDmdPrtPtnWork = dmdPrtPtnWork;

                                            DmdPrtPtnDB dmdPrtPtnDB = new DmdPrtPtnDB();
                                            status = dmdPrtPtnDB.Write( ref wkDmdPrtPtnWork, ref sqlConnection, ref sqlTransaction );
                                            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                }
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
							}
						}
					}

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
                        if (sqlTransaction.Connection != null) // ADD 2010/08/25
						// �R�~�b�g
						sqlTransaction.Commit();

						saveCustomSerializeArrayList = retList;
					}
					else
					{
						// ���[���o�b�N
						if (sqlTransaction.Connection != null)
							sqlTransaction.Rollback();

						saveCustomSerializeArrayList = null;
					}
				}
			}
			catch (SqlException ex)
			{
				// ���[���o�b�N
				if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex, "FrePrtPSetDB.Write", status);
				saveCustomSerializeArrayList = null;
				if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
				{
					msgDiv = true;
					errMsg = "���R���[���ڐݒ�}�X�^�����������Ƀ^�C���A�E�g���������܂����B";
				}
				else
				{
					errMsg = ex.Message;
				}
			}
			catch (Exception ex)
			{
				// ���[���o�b�N
				if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
				base.WriteErrorLog(ex, "FrePrtPSetDB.Write", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
				saveCustomSerializeArrayList = null;
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}
			finally
			{
				if (sqlConnection != null) sqlConnection.Close();
			}

			return status;
		}
		#endregion
		#endregion

		#region PrivateMethod
		#region Search
		/// <summary>
		/// ���R���[���o�������׌��������i���C�����j
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="frePExCndDWorkList">���o�������׃��[�NLIST</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[���o�������׃��[�NLIST��S���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private int SearchFrePExCndDProc(string enterpriseCode, ConstantManagement.LogicalMode logicalMode, out List<FrePExCndDWork> frePExCndDWorkList, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			SqlDataReader myReader = null;

			frePExCndDWorkList = new List<FrePExCndDWork>();
			try
			{
				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EXTRACONDDETAILGRPCDRF, EXTRACONDDETAILCODERF, EXTRACONDDETAILNAMERF FROM FREPEXCNDDRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE", sqlConnection);

				if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
					(logicalMode == ConstantManagement.LogicalMode.GetData1) ||
					(logicalMode == ConstantManagement.LogicalMode.GetData2) ||
					(logicalMode == ConstantManagement.LogicalMode.GetData3))
				{
					sqlCommand.CommandText += " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
				}
				else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
					(logicalMode == ConstantManagement.LogicalMode.GetData012))
				{
					sqlCommand.CommandText += " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";

					SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
					if (logicalMode == ConstantManagement.LogicalMode.GetData01)
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
					else
						paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
				}

				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				findParaEnterpriseCode.Value = enterpriseCode;

				// �^�C���A�E�g���Ԑݒ�
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitInitial);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					FrePExCndDWork frePExCndDWork = new FrePExCndDWork();

					#region �f�[�^�̃R�s�[
					frePExCndDWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
					frePExCndDWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
					frePExCndDWork.EnterpriseCode		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
					frePExCndDWork.FileHeaderGuid		= SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
					frePExCndDWork.UpdEmployeeCode		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					frePExCndDWork.UpdAssemblyId1		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					frePExCndDWork.UpdAssemblyId2		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					frePExCndDWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
					frePExCndDWork.ExtraCondDetailGrpCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRACONDDETAILGRPCDRF"));
					frePExCndDWork.ExtraCondDetailCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRACONDDETAILCODERF"));
					frePExCndDWork.ExtraCondDetailName	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACONDDETAILNAMERF"));
					#endregion

					frePExCndDWorkList.Add(frePExCndDWork);
				}

				if (frePExCndDWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			finally
			{
				if (myReader != null)
				{
					if (!myReader.IsClosed)
						myReader.Close();
				}
			}

			return status;
		}

		/// <summary>
		/// ���R���[�󎚈ʒu���擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="retCustomSerializeArrayList">���R���[�󎚈ʒu���J�X�^���V���A���C�YLIST</param>
		/// <param name="printPosClassData">�󎚈ʒu�o�C�i���f�[�^</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu�����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
        public int ReadProc( string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo, out CustomSerializeArrayList retCustomSerializeArrayList, out byte[] printPosClassData, SqlConnection sqlConnection )
        {
            return ReadProcProc( enterpriseCode, outputFormFileName, userPrtPprIdDerivNo, out retCustomSerializeArrayList, out printPosClassData, sqlConnection );
        }
        /// <summary>
        /// ���R���[�󎚈ʒu���擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
        /// <param name="retCustomSerializeArrayList">���R���[�󎚈ʒu���J�X�^���V���A���C�YLIST</param>
        /// <param name="printPosClassData">�󎚈ʒu�o�C�i���f�[�^</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        private int ReadProcProc( string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo, out CustomSerializeArrayList retCustomSerializeArrayList, out byte[] printPosClassData, SqlConnection sqlConnection )
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			retCustomSerializeArrayList = null;
			printPosClassData = null;
			string errMsg = string.Empty;

			try
			{
				CustomSerializeArrayList retList = new CustomSerializeArrayList();
				FrePrtPSetWork frePrtPSetWork;
				List<FrePprECndWork> frePprECndWorkList;
				List<FrePprSrtOWork> frePprSrtOWorkList;

				// ���R���[�󎚈ʒu�ݒ胏�[�N���擾
				status = ReadFrePrtPSetProc(enterpriseCode, outputFormFileName, userPrtPprIdDerivNo, out frePrtPSetWork, sqlConnection);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					ArrayList addList = new ArrayList();
					printPosClassData = frePrtPSetWork.PrintPosClassData;
					frePrtPSetWork.PrintPosClassData = new byte[0];
					addList.Add(frePrtPSetWork);
					retList.Add(addList);

					// ���R���[���o�����ݒ胏�[�N���擾
					status = SearchFrePprECndProc(enterpriseCode, outputFormFileName, userPrtPprIdDerivNo, out frePprECndWorkList, sqlConnection);
					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						{
							retList.Add(new ArrayList(frePprECndWorkList));
							break;
						}
						case (int)ConstantManagement.DB_Status.ctDB_EOF:
						{
							// ���R���[�󎚈ʒu�ݒ�ȊO�������ꍇ��z��
							if (retList.Count > 0)
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							else
								status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
							break;
						}
					}

					// ���R���[�\�[�g���ʃ��[�N���擾
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						status = SearchFrePprSrtOProc(enterpriseCode, outputFormFileName, userPrtPprIdDerivNo, out frePprSrtOWorkList, sqlConnection);
						switch (status)
						{
							case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							{
								retList.Add(new ArrayList(frePprSrtOWorkList));
								break;
							}
							case (int)ConstantManagement.DB_Status.ctDB_EOF:
							{
								// ���R���[�󎚈ʒu�ݒ�ȊO�������ꍇ��z��
								if (retList.Count > 0)
									status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
								else
									status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
								break;
							}
						}
					}
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					retCustomSerializeArrayList = retList;
			}
			finally
			{
			}

			return status;
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�ݒ�Ǎ������i���C�����j
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="frePrtPSetWork">���R���[�󎚈ʒu�ݒ胏�[�N</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �Y�����鎩�R���[�󎚈ʒu�ݒ胏�[�N���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
        private int ReadFrePrtPSetProc(string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo, out FrePrtPSetWork frePrtPSetWork, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			frePrtPSetWork		= null;

			SqlDataReader myReader = null;
			try
			{
				// Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF, PRINTPAPERUSEDIVCDRF, PRINTPAPERDIVCDRF, EXTRACTIONPGIDRF, EXTRACTIONPGCLASSIDRF, OUTPUTPGIDRF, OUTPUTPGCLASSIDRF, OUTCONFIMATIONMSGRF, DISPLAYNAMERF, PRTPPRUSERDERIVNOCMTRF, PRINTPOSITIONVERRF, MERGEABLEPRINTPOSVERRF, DATAINPUTSYSTEMRF, OPTIONCODERF, FREEPRTPPRITEMGRPCDRF, FORMFEEDLINECOUNTRF, EDGECHARPROCDIVCDRF, PRTPPRBGIMAGEROWPOSRF, PRTPPRBGIMAGECOLPOSRF, TAKEINIMAGEGROUPCDRF, EXTRASECTIONKINDCDRF, EXTRASECTIONSELEXISTRF, RDETAILBACKCOLORRF, GDETAILBACKCOLORRF, BDETAILBACKCOLORRF, CRCHARCNTRF, FREEPRTPPRSPPRPSECDRF, PRINTPOSCLASSDATARF FROM FREPRTPSETRF", sqlConnection);
				// Where���̒ǉ�
				sqlCommand.CommandText += MakeWhereString(ref sqlCommand, enterpriseCode, outputFormFileName, userPrtPprIdDerivNo);

				// �^�C���A�E�g���Ԑݒ�
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					frePrtPSetWork = new FrePrtPSetWork();

					#region �f�[�^�̃R�s�[
					frePrtPSetWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
					frePrtPSetWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
					frePrtPSetWork.EnterpriseCode		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
					frePrtPSetWork.FileHeaderGuid		= SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
					frePrtPSetWork.UpdEmployeeCode		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					frePrtPSetWork.UpdAssemblyId1		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					frePrtPSetWork.UpdAssemblyId2		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					frePrtPSetWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
					frePrtPSetWork.OutputFormFileName	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
					frePrtPSetWork.UserPrtPprIdDerivNo	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
					frePrtPSetWork.PrintPaperUseDivcd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERUSEDIVCDRF"));
					frePrtPSetWork.PrintPaperDivCd		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPAPERDIVCDRF"));
					frePrtPSetWork.ExtractionPgId		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGIDRF"));
					frePrtPSetWork.ExtractionPgClassId	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACTIONPGCLASSIDRF"));
					frePrtPSetWork.OutputPgId			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGIDRF"));
					frePrtPSetWork.OutputPgClassId		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTPGCLASSIDRF"));
					frePrtPSetWork.OutConfimationMsg	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTCONFIMATIONMSGRF"));
					frePrtPSetWork.DisplayName			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DISPLAYNAMERF"));
					frePrtPSetWork.PrtPprUserDerivNoCmt	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTPPRUSERDERIVNOCMTRF"));
					frePrtPSetWork.PrintPositionVer		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRINTPOSITIONVERRF"));
					frePrtPSetWork.MergeablePrintPosVer	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MERGEABLEPRINTPOSVERRF"));
					frePrtPSetWork.DataInputSystem		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
					frePrtPSetWork.OptionCode			= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPTIONCODERF"));
					frePrtPSetWork.FreePrtPprItemGrpCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRITEMGRPCDRF"));
					frePrtPSetWork.FormFeedLineCount	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FORMFEEDLINECOUNTRF"));
					frePrtPSetWork.EdgeCharProcDivCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDGECHARPROCDIVCDRF"));
					frePrtPSetWork.PrtPprBgImageRowPos	= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRTPPRBGIMAGEROWPOSRF"));
					frePrtPSetWork.PrtPprBgImageColPos	= SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRTPPRBGIMAGECOLPOSRF"));
					frePrtPSetWork.TakeInImageGroupCd	= SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("TAKEINIMAGEGROUPCDRF"));
					frePrtPSetWork.ExtraSectionKindCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRASECTIONKINDCDRF"));
					frePrtPSetWork.ExtraSectionSelExist	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRASECTIONSELEXISTRF"));
					frePrtPSetWork.RDetailBackColor		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RDETAILBACKCOLORRF"));
					frePrtPSetWork.GDetailBackColor		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GDETAILBACKCOLORRF"));
					frePrtPSetWork.BDetailBackColor		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BDETAILBACKCOLORRF"));
					frePrtPSetWork.CrCharCnt			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CRCHARCNTRF"));
					frePrtPSetWork.FreePrtPprSpPrpseCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREEPRTPPRSPPRPSECDRF"));
					frePrtPSetWork.PrintPosClassData	= SqlDataMediator.SqlGetBinaly(myReader, myReader.GetOrdinal("PRINTPOSCLASSDATARF"));
					#endregion
					
					break;
				}

				if (frePrtPSetWork != null) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			finally
			{
				if (myReader != null)
				{
					if (!myReader.IsClosed)
						myReader.Close();
				}
			}

			return status;
		}

		/// <summary>
		/// ���R���[���o�����ݒ茟�������i���C�����j
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="frePprECndWorkList">���o�����ݒ胏�[�NLIST</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[���o�����ݒ胏�[�NLIST��S���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private int SearchFrePprECndProc(string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo, out List<FrePprECndWork> frePprECndWorkList, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;

			frePprECndWorkList = new List<FrePprECndWork>();
			try
			{
				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF, FREPRTPPREXTRACONDCDRF, DISPLAYORDERRF, EXTRACONDITIONDIVCDRF, EXTRACONDITIONTYPECDRF, EXTRACONDITIONTITLERF, DDCHARCNTRF, DDNAMERF, STEXTRANUMCODERF, EDEXTRANUMCODERF, STEXTRACHARCODERF, EDEXTRACHARCODERF, STEXTRADATEBASECDRF, STEXTRADATESIGNCDRF, STEXTRADATENUMRF, STEXTRADATEUNITCDRF, STARTEXTRADATERF, EDEXTRADATEBASECDRF, EDEXTRADATESIGNCDRF, EDEXTRADATENUMRF, EDEXTRADATEUNITCDRF, ENDEXTRADATERF, EXTRACONDDETAILGRPCDRF, NECESSARYEXTRACONDCDRF, CHECKITEMCODE1RF, CHECKITEMCODE2RF, CHECKITEMCODE3RF, CHECKITEMCODE4RF, CHECKITEMCODE5RF, CHECKITEMCODE6RF, CHECKITEMCODE7RF, CHECKITEMCODE8RF, CHECKITEMCODE9RF, CHECKITEMCODE10RF, FILENMRF, INPUTCHARCNTRF FROM FREPPRECNDRF", sqlConnection);
				// Where���̒ǉ�
				sqlCommand.CommandText += MakeWhereString(ref sqlCommand, enterpriseCode, outputFormFileName, userPrtPprIdDerivNo);

				// �^�C���A�E�g���Ԑݒ�
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.Common);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					FrePprECndWork frePprECndWork = new FrePprECndWork();

					#region �f�[�^�̃R�s�[
					frePprECndWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
					frePprECndWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
					frePprECndWork.EnterpriseCode		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
					frePprECndWork.FileHeaderGuid		= SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
					frePprECndWork.UpdEmployeeCode		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					frePprECndWork.UpdAssemblyId1		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					frePprECndWork.UpdAssemblyId2		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					frePprECndWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
					frePprECndWork.OutputFormFileName	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
					frePprECndWork.UserPrtPprIdDerivNo	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
					frePprECndWork.FrePrtPprExtraCondCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FREPRTPPREXTRACONDCDRF"));
					frePprECndWork.DisplayOrder			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));
					frePprECndWork.ExtraConditionDivCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRACONDITIONDIVCDRF"));
					frePprECndWork.ExtraConditionTypeCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRACONDITIONTYPECDRF"));
					frePprECndWork.ExtraConditionTitle	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRACONDITIONTITLERF"));
					frePprECndWork.DDCharCnt			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DDCHARCNTRF"));
					frePprECndWork.DDName				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DDNAMERF"));
					frePprECndWork.StExtraNumCode		= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STEXTRANUMCODERF"));
					frePprECndWork.EdExtraNumCode		= SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("EDEXTRANUMCODERF"));
					frePprECndWork.StExtraCharCode		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STEXTRACHARCODERF"));
					frePprECndWork.EdExtraCharCode		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EDEXTRACHARCODERF"));
					frePprECndWork.StExtraDateBaseCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STEXTRADATEBASECDRF"));
					frePprECndWork.StExtraDateSignCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STEXTRADATESIGNCDRF"));
					frePprECndWork.StExtraDateNum		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STEXTRADATENUMRF"));
					frePprECndWork.StExtraDateUnitCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STEXTRADATEUNITCDRF"));
					frePprECndWork.StartExtraDate		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STARTEXTRADATERF"));
					frePprECndWork.EdExtraDateBaseCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDEXTRADATEBASECDRF"));
					frePprECndWork.EdExtraDateSignCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDEXTRADATESIGNCDRF"));
					frePprECndWork.EdExtraDateNum		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDEXTRADATENUMRF"));
					frePprECndWork.EdExtraDateUnitCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EDEXTRADATEUNITCDRF"));
					frePprECndWork.EndExtraDate			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENDEXTRADATERF"));
					frePprECndWork.ExtraCondDetailGrpCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EXTRACONDDETAILGRPCDRF"));
					frePprECndWork.NecessaryExtraCondCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NECESSARYEXTRACONDCDRF"));
					frePprECndWork.CheckItemCode1		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE1RF"));
					frePprECndWork.CheckItemCode2		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE2RF"));
					frePprECndWork.CheckItemCode3		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE3RF"));
					frePprECndWork.CheckItemCode4		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE4RF"));
					frePprECndWork.CheckItemCode5		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE5RF"));
					frePprECndWork.CheckItemCode6		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE6RF"));
					frePprECndWork.CheckItemCode7		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE7RF"));
					frePprECndWork.CheckItemCode8		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE8RF"));
					frePprECndWork.CheckItemCode9		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE9RF"));
					frePprECndWork.CheckItemCode10		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHECKITEMCODE10RF"));
					frePprECndWork.FileNm				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILENMRF"));
					frePprECndWork.InputCharCnt			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTCHARCNTRF"));
					#endregion

					frePprECndWorkList.Add(frePprECndWork);
				}

				if (frePprECndWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			finally
			{
				if (myReader != null)
				{
					if (!myReader.IsClosed)
						myReader.Close();
				}
			}
			
			return status;
		}

		/// <summary>
		/// ���R���[�\�[�g���ʌ��������i���C�����j
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="frePprSrtOWorkList">�\�[�g���ʃ��[�NLIST</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�\�[�g���ʃ��[�NLIST��S���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private int SearchFrePprSrtOProc(string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo, out List<FrePprSrtOWork> frePprSrtOWorkList, SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlDataReader myReader = null;

			frePprSrtOWorkList = new List<FrePprSrtOWork>();
			try
			{
				//Select�R�}���h�̐���
				SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF, SORTINGORDERCODERF, SORTINGORDERRF, FREEPRTPAPERITEMNMRF, DDNAMERF, SORTINGORDERDIVCDRF, FILENMRF FROM FREPPRSRTORF", sqlConnection);
				// Where���̒ǉ�
				sqlCommand.CommandText += MakeWhereString(ref sqlCommand, enterpriseCode, outputFormFileName, userPrtPprIdDerivNo);

				// �^�C���A�E�g���Ԑݒ�
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.Common);

				myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
					FrePprSrtOWork frePprSrtOWork = new FrePprSrtOWork();

					#region �f�[�^�̃R�s�[
					frePprSrtOWork.CreateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
					frePprSrtOWork.UpdateDateTime		= SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
					frePprSrtOWork.EnterpriseCode		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
					frePprSrtOWork.FileHeaderGuid		= SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
					frePprSrtOWork.UpdEmployeeCode		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
					frePprSrtOWork.UpdAssemblyId1		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
					frePprSrtOWork.UpdAssemblyId2		= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
					frePprSrtOWork.LogicalDeleteCode	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
					frePprSrtOWork.OutputFormFileName	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
					frePprSrtOWork.UserPrtPprIdDerivNo	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERPRTPPRIDDERIVNORF"));
					frePprSrtOWork.SortingOrderCode		= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SORTINGORDERCODERF"));
					frePprSrtOWork.SortingOrder			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SORTINGORDERRF"));
					frePprSrtOWork.FreePrtPaperItemNm	= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FREEPRTPAPERITEMNMRF"));
					frePprSrtOWork.DDName				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DDNAMERF"));
					frePprSrtOWork.FileNm				= SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILENMRF"));
					frePprSrtOWork.SortingOrderDivCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SORTINGORDERDIVCDRF"));
					#endregion

					frePprSrtOWorkList.Add(frePprSrtOWork);
				}

				if (frePprSrtOWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			finally
			{
				if (myReader != null)
				{
					if (!myReader.IsClosed)
						myReader.Close();
				}
			}

			return status;
		}
		#endregion

		#region Write
		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�ۑ������i���C�����j
		/// </summary>
		/// <param name="frePrtPSetWork">���R���[�󎚈ʒu�ݒ�ݒ胏�[�N</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�󎚈ʒu�ݒ�̕ۑ��������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private int WriteFrePrtPSetProc(ref FrePrtPSetWork frePrtPSetWork, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader	= null;
			SqlCommand sqlCommand	= null;

			try
			{
				// Select�R�}���h�̐���
				sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM FREPRTPSETRF", sqlConnection, sqlTransaction);
				// Where���̒ǉ�
				sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO";

				// �^�C���A�E�g���Ԑݒ�
				sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

				// ��ƃR�[�h
				SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				findParaEnterpriseCode.Value = frePrtPSetWork.EnterpriseCode;
				// �o�̓t�@�C����
				SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
				findParaOutputFormFileName.Value = frePrtPSetWork.OutputFormFileName;
				// ���[�U�[���[ID�}�ԍ�
				SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);
				findParaUserPrtPprIdDerivNo.Value = frePrtPSetWork.UserPrtPprIdDerivNo;

				myReader = sqlCommand.ExecuteReader();
				if (myReader.Read())
				{
					// ������ �X�V���[�h ������

					// �X�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
					DateTime updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));	// �X�V����
					if (updateDateTime != frePrtPSetWork.UpdateDateTime)
					{
						// �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
						if (frePrtPSetWork.UpdateDateTime == DateTime.MinValue)
							status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
						// �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
						else
							status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
						return status;
					}

					//Update�R�}���h�̐���
					sqlCommand.CommandText = "UPDATE FREPRTPSETRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , USERPRTPPRIDDERIVNORF=@USERPRTPPRIDDERIVNO , PRINTPAPERUSEDIVCDRF=@PRINTPAPERUSEDIVCD , PRINTPAPERDIVCDRF=@PRINTPAPERDIVCD , EXTRACTIONPGIDRF=@EXTRACTIONPGID , EXTRACTIONPGCLASSIDRF=@EXTRACTIONPGCLASSID , OUTPUTPGIDRF=@OUTPUTPGID , OUTPUTPGCLASSIDRF=@OUTPUTPGCLASSID , OUTCONFIMATIONMSGRF=@OUTCONFIMATIONMSG , DISPLAYNAMERF=@DISPLAYNAME , PRTPPRUSERDERIVNOCMTRF=@PRTPPRUSERDERIVNOCMT , PRINTPOSITIONVERRF=@PRINTPOSITIONVER , MERGEABLEPRINTPOSVERRF=@MERGEABLEPRINTPOSVER , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , OPTIONCODERF=@OPTIONCODE , FREEPRTPPRITEMGRPCDRF=@FREEPRTPPRITEMGRPCD , FORMFEEDLINECOUNTRF=@FORMFEEDLINECOUNT , EDGECHARPROCDIVCDRF=@EDGECHARPROCDIVCD , PRTPPRBGIMAGEROWPOSRF=@PRTPPRBGIMAGEROWPOS , PRTPPRBGIMAGECOLPOSRF=@PRTPPRBGIMAGECOLPOS , TAKEINIMAGEGROUPCDRF=@TAKEINIMAGEGROUPCD , EXTRASECTIONKINDCDRF=@EXTRASECTIONKINDCD , EXTRASECTIONSELEXISTRF=@EXTRASECTIONSELEXIST , RDETAILBACKCOLORRF=@RDETAILBACKCOLOR , GDETAILBACKCOLORRF=@GDETAILBACKCOLOR , BDETAILBACKCOLORRF=@BDETAILBACKCOLOR , CRCHARCNTRF=@CRCHARCNT , FREEPRTPPRSPPRPSECDRF=@FREEPRTPPRSPPRPSECD , PRINTPOSCLASSDATARF=@PRINTPOSCLASSDATA";
					// Where���̒ǉ�
					sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO";
					// Key�f�[�^�Đݒ�
					findParaEnterpriseCode.Value		= frePrtPSetWork.EnterpriseCode;		// ��ƃR�[�h
					findParaOutputFormFileName.Value	= frePrtPSetWork.OutputFormFileName;	// �o�̓t�@�C����
					findParaUserPrtPprIdDerivNo.Value	= frePrtPSetWork.UserPrtPprIdDerivNo;	// ���[�U�[���[ID�}�ԍ�

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader iFileHeader	= (IFileHeader)frePrtPSetWork;
					FileHeader fileHeader	= new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref iFileHeader, obj);
				}
				else
				{
					// ������ �V�K���[�h ������

					// �X�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
					if (frePrtPSetWork.UpdateDateTime > DateTime.MinValue)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
						return status;
					}

					//Insert�R�}���h�̐���
					sqlCommand.CommandText = "INSERT INTO FREPRTPSETRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF, PRINTPAPERUSEDIVCDRF, PRINTPAPERDIVCDRF, EXTRACTIONPGIDRF, EXTRACTIONPGCLASSIDRF, OUTPUTPGIDRF, OUTPUTPGCLASSIDRF, OUTCONFIMATIONMSGRF, DISPLAYNAMERF, PRTPPRUSERDERIVNOCMTRF, PRINTPOSITIONVERRF, MERGEABLEPRINTPOSVERRF, DATAINPUTSYSTEMRF, OPTIONCODERF, FREEPRTPPRITEMGRPCDRF, FORMFEEDLINECOUNTRF, EDGECHARPROCDIVCDRF, PRTPPRBGIMAGEROWPOSRF, PRTPPRBGIMAGECOLPOSRF, TAKEINIMAGEGROUPCDRF, EXTRASECTIONKINDCDRF, EXTRASECTIONSELEXISTRF, RDETAILBACKCOLORRF, GDETAILBACKCOLORRF, BDETAILBACKCOLORRF, CRCHARCNTRF, FREEPRTPPRSPPRPSECDRF, PRINTPOSCLASSDATARF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @OUTPUTFORMFILENAME, @USERPRTPPRIDDERIVNO, @PRINTPAPERUSEDIVCD, @PRINTPAPERDIVCD, @EXTRACTIONPGID, @EXTRACTIONPGCLASSID, @OUTPUTPGID, @OUTPUTPGCLASSID, @OUTCONFIMATIONMSG, @DISPLAYNAME, @PRTPPRUSERDERIVNOCMT, @PRINTPOSITIONVER, @MERGEABLEPRINTPOSVER, @DATAINPUTSYSTEM, @OPTIONCODE, @FREEPRTPPRITEMGRPCD, @FORMFEEDLINECOUNT, @EDGECHARPROCDIVCD, @PRTPPRBGIMAGEROWPOS, @PRTPPRBGIMAGECOLPOS, @TAKEINIMAGEGROUPCD, @EXTRASECTIONKINDCD, @EXTRASECTIONSELEXIST, @RDETAILBACKCOLOR, @GDETAILBACKCOLOR, @BDETAILBACKCOLOR, @CRCHARCNT, @FREEPRTPPRSPPRPSECD, @PRINTPOSCLASSDATA)";
					//�o�^�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader iFileHeader	= (IFileHeader)frePrtPSetWork;
					FileHeader fileHeader	= new FileHeader(obj);
					fileHeader.SetInsertHeader(ref iFileHeader, obj);
				}
				if (!myReader.IsClosed) myReader.Close();

				#region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
				SqlParameter paraCreateDateTime			= sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
				SqlParameter paraEnterpriseCode			= sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
				SqlParameter paraFileHeaderGuid			= sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
				SqlParameter paraUpdEmployeeCode		= sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
				SqlParameter paraUpdAssemblyId1			= sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
				SqlParameter paraUpdAssemblyId2			= sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
				SqlParameter paraLogicalDeleteCode		= sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
				SqlParameter paraOutputFormFileName		= sqlCommand.Parameters.Add("@OUTPUTFORMFILENAME", SqlDbType.NVarChar);
				SqlParameter paraUserPrtPprIdDerivNo	= sqlCommand.Parameters.Add("@USERPRTPPRIDDERIVNO", SqlDbType.Int);
				SqlParameter paraPrintPaperUseDivcd		= sqlCommand.Parameters.Add("@PRINTPAPERUSEDIVCD", SqlDbType.Int);
				SqlParameter paraPrintPaperDivCd		= sqlCommand.Parameters.Add("@PRINTPAPERDIVCD", SqlDbType.Int);
				SqlParameter paraExtractionPgId			= sqlCommand.Parameters.Add("@EXTRACTIONPGID", SqlDbType.NVarChar);
				SqlParameter paraExtractionPgClassId	= sqlCommand.Parameters.Add("@EXTRACTIONPGCLASSID", SqlDbType.NVarChar);
				SqlParameter paraOutputPgId				= sqlCommand.Parameters.Add("@OUTPUTPGID", SqlDbType.NVarChar);
				SqlParameter paraOutputPgClassId		= sqlCommand.Parameters.Add("@OUTPUTPGCLASSID", SqlDbType.NVarChar);
				SqlParameter paraOutConfimationMsg		= sqlCommand.Parameters.Add("@OUTCONFIMATIONMSG", SqlDbType.NVarChar);
				SqlParameter paraDisplayName			= sqlCommand.Parameters.Add("@DISPLAYNAME", SqlDbType.NVarChar);
				SqlParameter paraPrtPprUserDerivNoCmt	= sqlCommand.Parameters.Add("@PRTPPRUSERDERIVNOCMT", SqlDbType.NVarChar);
				SqlParameter paraPrintPositionVer		= sqlCommand.Parameters.Add("@PRINTPOSITIONVER", SqlDbType.Int);
				SqlParameter paraMergeablePrintPosVer	= sqlCommand.Parameters.Add("@MERGEABLEPRINTPOSVER", SqlDbType.Int);
				SqlParameter paraDataInputSystem		= sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
				SqlParameter paraOptionCode				= sqlCommand.Parameters.Add("@OPTIONCODE", SqlDbType.NVarChar);
				SqlParameter paraFreePrtPprItemGrpCd	= sqlCommand.Parameters.Add("@FREEPRTPPRITEMGRPCD", SqlDbType.Int);
				SqlParameter paraFormFeedLineCount		= sqlCommand.Parameters.Add("@FORMFEEDLINECOUNT", SqlDbType.Int);
				SqlParameter paraEdgeCharProcDivCd		= sqlCommand.Parameters.Add("@EDGECHARPROCDIVCD", SqlDbType.Int);
				SqlParameter paraPrtPprBgImageRowPos	= sqlCommand.Parameters.Add("@PRTPPRBGIMAGEROWPOS", SqlDbType.Float);
				SqlParameter paraPrtPprBgImageColPos	= sqlCommand.Parameters.Add("@PRTPPRBGIMAGECOLPOS", SqlDbType.Float);
				SqlParameter paraTakeInImageGroupCd		= sqlCommand.Parameters.Add("@TAKEINIMAGEGROUPCD", SqlDbType.UniqueIdentifier);
				SqlParameter paraExtraSectionKindCd		= sqlCommand.Parameters.Add("@EXTRASECTIONKINDCD", SqlDbType.Int);
				SqlParameter paraExtraSectionSelExist	= sqlCommand.Parameters.Add("@EXTRASECTIONSELEXIST", SqlDbType.Int);
				SqlParameter paraRDetailBackColor		= sqlCommand.Parameters.Add("@RDETAILBACKCOLOR", SqlDbType.Int);
				SqlParameter paraGDetailBackColor		= sqlCommand.Parameters.Add("@GDETAILBACKCOLOR", SqlDbType.Int);
				SqlParameter paraBDetailBackColor		= sqlCommand.Parameters.Add("@BDETAILBACKCOLOR", SqlDbType.Int);
				SqlParameter paraCrCharCnt				= sqlCommand.Parameters.Add("@CRCHARCNT", SqlDbType.Int);
				SqlParameter paraFreePrtPprSpPrpseCd	= sqlCommand.Parameters.Add("@FREEPRTPPRSPPRPSECD", SqlDbType.Int);
				SqlParameter paraPrintPosClassData		= sqlCommand.Parameters.Add("@PRINTPOSCLASSDATA", SqlDbType.Image);
				#endregion

				#region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
				paraCreateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(frePrtPSetWork.CreateDateTime);
				paraUpdateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(frePrtPSetWork.UpdateDateTime);
				paraEnterpriseCode.Value		= SqlDataMediator.SqlSetString(frePrtPSetWork.EnterpriseCode);
				paraFileHeaderGuid.Value		= SqlDataMediator.SqlSetGuid(frePrtPSetWork.FileHeaderGuid);
				paraUpdEmployeeCode.Value		= SqlDataMediator.SqlSetString(frePrtPSetWork.UpdEmployeeCode);
				paraUpdAssemblyId1.Value		= SqlDataMediator.SqlSetString(frePrtPSetWork.UpdAssemblyId1);
				paraUpdAssemblyId2.Value		= SqlDataMediator.SqlSetString(frePrtPSetWork.UpdAssemblyId2);
				paraLogicalDeleteCode.Value		= SqlDataMediator.SqlSetInt32(frePrtPSetWork.LogicalDeleteCode);
				paraOutputFormFileName.Value	= SqlDataMediator.SqlSetString(frePrtPSetWork.OutputFormFileName);
				paraUserPrtPprIdDerivNo.Value	= SqlDataMediator.SqlSetInt32(frePrtPSetWork.UserPrtPprIdDerivNo);
				paraPrintPaperUseDivcd.Value	= SqlDataMediator.SqlSetInt32(frePrtPSetWork.PrintPaperUseDivcd);
				paraPrintPaperDivCd.Value		= SqlDataMediator.SqlSetInt32(frePrtPSetWork.PrintPaperDivCd);
				paraExtractionPgId.Value		= SqlDataMediator.SqlSetString(frePrtPSetWork.ExtractionPgId);
				paraExtractionPgClassId.Value	= SqlDataMediator.SqlSetString(frePrtPSetWork.ExtractionPgClassId);
				paraOutputPgId.Value			= SqlDataMediator.SqlSetString(frePrtPSetWork.OutputPgId);
				paraOutputPgClassId.Value		= SqlDataMediator.SqlSetString(frePrtPSetWork.OutputPgClassId);
				paraOutConfimationMsg.Value		= SqlDataMediator.SqlSetString(frePrtPSetWork.OutConfimationMsg);
				paraDisplayName.Value			= SqlDataMediator.SqlSetString(frePrtPSetWork.DisplayName);
				paraPrtPprUserDerivNoCmt.Value	= SqlDataMediator.SqlSetString(frePrtPSetWork.PrtPprUserDerivNoCmt);
				paraPrintPositionVer.Value		= SqlDataMediator.SqlSetInt32(frePrtPSetWork.PrintPositionVer);
				paraMergeablePrintPosVer.Value	= SqlDataMediator.SqlSetInt32(frePrtPSetWork.MergeablePrintPosVer);
				paraDataInputSystem.Value		= SqlDataMediator.SqlSetInt32(frePrtPSetWork.DataInputSystem);
				paraOptionCode.Value			= SqlDataMediator.SqlSetString(frePrtPSetWork.OptionCode);
				paraFreePrtPprItemGrpCd.Value	= SqlDataMediator.SqlSetInt32(frePrtPSetWork.FreePrtPprItemGrpCd);
				paraFormFeedLineCount.Value		= SqlDataMediator.SqlSetInt32(frePrtPSetWork.FormFeedLineCount);
				paraEdgeCharProcDivCd.Value		= SqlDataMediator.SqlSetInt32(frePrtPSetWork.EdgeCharProcDivCd);
				paraPrtPprBgImageRowPos.Value	= SqlDataMediator.SqlSetDouble(frePrtPSetWork.PrtPprBgImageRowPos);
				paraPrtPprBgImageColPos.Value	= SqlDataMediator.SqlSetDouble(frePrtPSetWork.PrtPprBgImageColPos);
				paraTakeInImageGroupCd.Value	= SqlDataMediator.SqlSetGuid(frePrtPSetWork.TakeInImageGroupCd);
				paraExtraSectionKindCd.Value	= SqlDataMediator.SqlSetInt32(frePrtPSetWork.ExtraSectionKindCd);
				paraExtraSectionSelExist.Value	= SqlDataMediator.SqlSetInt32(frePrtPSetWork.ExtraSectionSelExist);
				paraRDetailBackColor.Value		= SqlDataMediator.SqlSetInt32(frePrtPSetWork.RDetailBackColor);
				paraGDetailBackColor.Value		= SqlDataMediator.SqlSetInt32(frePrtPSetWork.GDetailBackColor);
				paraBDetailBackColor.Value		= SqlDataMediator.SqlSetInt32(frePrtPSetWork.BDetailBackColor);
				paraCrCharCnt.Value				= SqlDataMediator.SqlSetInt32(frePrtPSetWork.CrCharCnt);
				paraFreePrtPprSpPrpseCd.Value	= SqlDataMediator.SqlSetInt32(frePrtPSetWork.FreePrtPprSpPrpseCd);
				paraPrintPosClassData.Value		= SqlDataMediator.SqlSetBinary(frePrtPSetWork.PrintPosClassData);
				#endregion

				sqlCommand.ExecuteNonQuery();

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			finally
			{
				if (myReader != null)
				{
					if (!myReader.IsClosed)
						myReader.Close();
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
		/// ���R���[���o�����ݒ�ۑ������i���C�����j
		/// </summary>
		/// <param name="frePprECndWorkArray">���R���[���o�����ݒ胏�[�N�z��</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[���o�����ݒ�̕ۑ��������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private int WriteFrePprECndProc(ref FrePprECndWork[] frePprECndWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader	= null;
			SqlCommand sqlCommand	= null;
			List<FrePprECndWork> frePprECndWorkList = null;

			try
			{
				if (frePprECndWorkArray != null && frePprECndWorkArray.Length > 0)
				{
					DateTime updateDateTime = DateTime.MinValue;
					frePprECndWorkList = new List<FrePprECndWork>();

					for (int ix = 0 ; ix != frePprECndWorkArray.Length ; ix++)
					{
						FrePprECndWork frePprECndWork = frePprECndWorkArray[ix];

						// Select�R�}���h�̐���
						sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM FREPPRECNDRF", sqlConnection, sqlTransaction);
						// Where���̒ǉ�
						sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO AND FREPRTPPREXTRACONDCDRF=@FINDFREPRTPPREXTRACONDCD";

						// ��ƃR�[�h
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						findParaEnterpriseCode.Value = frePprECndWork.EnterpriseCode;
						// �o�̓t�@�C����
						SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
						findParaOutputFormFileName.Value = frePprECndWork.OutputFormFileName;
						// ���[�U�[���[ID�}�ԍ�
						SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);
						findParaUserPrtPprIdDerivNo.Value = frePprECndWork.UserPrtPprIdDerivNo;
						// ���R���[���o�����}��
						SqlParameter findParaFrePrtPprExtraCondCd = sqlCommand.Parameters.Add("@FINDFREPRTPPREXTRACONDCD", SqlDbType.Int);
						findParaFrePrtPprExtraCondCd.Value = frePprECndWork.FrePrtPprExtraCondCd;

						// �^�C���A�E�g���Ԑݒ�
						sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

						myReader = sqlCommand.ExecuteReader();
						if (myReader.Read())
						{
							// ������ �X�V���[�h ������

							// �X�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
							DateTime wkDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));	// �X�V����
							if (wkDateTime != frePprECndWork.UpdateDateTime)
							{
								// �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
								if (frePprECndWork.UpdateDateTime == DateTime.MinValue)
									status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
								// �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
								else
									status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

								sqlCommand.Cancel();

								if (!myReader.IsClosed) myReader.Close();

								return status;
							}

							//Update�R�}���h�̐���
							sqlCommand.CommandText = "UPDATE FREPPRECNDRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , USERPRTPPRIDDERIVNORF=@USERPRTPPRIDDERIVNO , FREPRTPPREXTRACONDCDRF=@FREPRTPPREXTRACONDCD , DISPLAYORDERRF=@DISPLAYORDER , EXTRACONDITIONDIVCDRF=@EXTRACONDITIONDIVCD , EXTRACONDITIONTYPECDRF=@EXTRACONDITIONTYPECD , EXTRACONDITIONTITLERF=@EXTRACONDITIONTITLE , DDCHARCNTRF=@DDCHARCNT , DDNAMERF=@DDNAME , STEXTRANUMCODERF=@STEXTRANUMCODE , EDEXTRANUMCODERF=@EDEXTRANUMCODE , STEXTRACHARCODERF=@STEXTRACHARCODE , EDEXTRACHARCODERF=@EDEXTRACHARCODE , STEXTRADATEBASECDRF=@STEXTRADATEBASECD , STEXTRADATESIGNCDRF=@STEXTRADATESIGNCD , STEXTRADATENUMRF=@STEXTRADATENUM , STEXTRADATEUNITCDRF=@STEXTRADATEUNITCD , STARTEXTRADATERF=@STARTEXTRADATE , EDEXTRADATEBASECDRF=@EDEXTRADATEBASECD , EDEXTRADATESIGNCDRF=@EDEXTRADATESIGNCD , EDEXTRADATENUMRF=@EDEXTRADATENUM , EDEXTRADATEUNITCDRF=@EDEXTRADATEUNITCD , ENDEXTRADATERF=@ENDEXTRADATE , EXTRACONDDETAILGRPCDRF=@EXTRACONDDETAILGRPCD , NECESSARYEXTRACONDCDRF=@NECESSARYEXTRACONDCD , CHECKITEMCODE1RF=@CHECKITEMCODE1 , CHECKITEMCODE2RF=@CHECKITEMCODE2 , CHECKITEMCODE3RF=@CHECKITEMCODE3 , CHECKITEMCODE4RF=@CHECKITEMCODE4 , CHECKITEMCODE5RF=@CHECKITEMCODE5 , CHECKITEMCODE6RF=@CHECKITEMCODE6 , CHECKITEMCODE7RF=@CHECKITEMCODE7 , CHECKITEMCODE8RF=@CHECKITEMCODE8 , CHECKITEMCODE9RF=@CHECKITEMCODE9 , CHECKITEMCODE10RF=@CHECKITEMCODE10 , FILENMRF=@FILENM , INPUTCHARCNTRF=@INPUTCHARCNT";
							// Where���̒ǉ�
							sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO AND FREPRTPPREXTRACONDCDRF=@FINDFREPRTPPREXTRACONDCD";
							// Key�f�[�^�Đݒ�
							findParaEnterpriseCode.Value		= frePprECndWork.EnterpriseCode;		// ��ƃR�[�h
							findParaOutputFormFileName.Value	= frePprECndWork.OutputFormFileName;	// �o�̓t�@�C����
							findParaUserPrtPprIdDerivNo.Value	= frePprECndWork.UserPrtPprIdDerivNo;	// ���[�U�[���[ID�}�ԍ�
							findParaFrePrtPprExtraCondCd.Value	= frePprECndWork.FrePrtPprExtraCondCd;	// ���R���[���o�����}��

							//�X�V�w�b�_����ݒ�
							object obj = (object)this;
							IFileHeader iFileHeader = (IFileHeader)frePprECndWork;
							FileHeader fileHeader = new FileHeader(obj);
							fileHeader.SetUpdateHeader(ref iFileHeader, obj);
							if (updateDateTime == DateTime.MinValue) updateDateTime = frePprECndWork.UpdateDateTime;
						}
						else
						{
							// ������ �V�K���[�h ������

							// �X�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
							if (frePprECndWork.UpdateDateTime > DateTime.MinValue)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
								return status;
							}

							//Insert�R�}���h�̐���
							sqlCommand.CommandText = "INSERT INTO FREPPRECNDRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF, FREPRTPPREXTRACONDCDRF, DISPLAYORDERRF, EXTRACONDITIONDIVCDRF, EXTRACONDITIONTYPECDRF, EXTRACONDITIONTITLERF, DDCHARCNTRF, DDNAMERF, STEXTRANUMCODERF, EDEXTRANUMCODERF, STEXTRACHARCODERF, EDEXTRACHARCODERF, STEXTRADATEBASECDRF, STEXTRADATESIGNCDRF, STEXTRADATENUMRF, STEXTRADATEUNITCDRF, STARTEXTRADATERF, EDEXTRADATEBASECDRF, EDEXTRADATESIGNCDRF, EDEXTRADATENUMRF, EDEXTRADATEUNITCDRF, ENDEXTRADATERF, EXTRACONDDETAILGRPCDRF, NECESSARYEXTRACONDCDRF, CHECKITEMCODE1RF, CHECKITEMCODE2RF, CHECKITEMCODE3RF, CHECKITEMCODE4RF, CHECKITEMCODE5RF, CHECKITEMCODE6RF, CHECKITEMCODE7RF, CHECKITEMCODE8RF, CHECKITEMCODE9RF, CHECKITEMCODE10RF, FILENMRF, INPUTCHARCNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @OUTPUTFORMFILENAME, @USERPRTPPRIDDERIVNO, @FREPRTPPREXTRACONDCD, @DISPLAYORDER, @EXTRACONDITIONDIVCD, @EXTRACONDITIONTYPECD, @EXTRACONDITIONTITLE, @DDCHARCNT, @DDNAME, @STEXTRANUMCODE, @EDEXTRANUMCODE, @STEXTRACHARCODE, @EDEXTRACHARCODE, @STEXTRADATEBASECD, @STEXTRADATESIGNCD, @STEXTRADATENUM, @STEXTRADATEUNITCD, @STARTEXTRADATE, @EDEXTRADATEBASECD, @EDEXTRADATESIGNCD, @EDEXTRADATENUM, @EDEXTRADATEUNITCD, @ENDEXTRADATE, @EXTRACONDDETAILGRPCD, @NECESSARYEXTRACONDCD, @CHECKITEMCODE1, @CHECKITEMCODE2, @CHECKITEMCODE3, @CHECKITEMCODE4, @CHECKITEMCODE5, @CHECKITEMCODE6, @CHECKITEMCODE7, @CHECKITEMCODE8, @CHECKITEMCODE9, @CHECKITEMCODE10, @FILENM, @INPUTCHARCNT)";
							//�o�^�w�b�_����ݒ�
							object obj = (object)this;
							IFileHeader iFileHeader = (IFileHeader)frePprECndWork;
							FileHeader fileHeader = new FileHeader(obj);
							fileHeader.SetInsertHeader(ref iFileHeader, obj);
							if (updateDateTime == DateTime.MinValue) updateDateTime = frePprECndWork.UpdateDateTime;
						}
						if (!myReader.IsClosed) myReader.Close();

						// �X�V���t�𓝈ꂷ��
						frePprECndWork.UpdateDateTime = updateDateTime;

						#region Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter paraCreateDateTime			= sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
						SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
						SqlParameter paraEnterpriseCode			= sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
						SqlParameter paraFileHeaderGuid			= sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
						SqlParameter paraUpdEmployeeCode		= sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
						SqlParameter paraUpdAssemblyId1			= sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
						SqlParameter paraUpdAssemblyId2			= sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
						SqlParameter paraLogicalDeleteCode		= sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
						SqlParameter paraOutputFormFileName		= sqlCommand.Parameters.Add("@OUTPUTFORMFILENAME", SqlDbType.NVarChar);
						SqlParameter paraUserPrtPprIdDerivNo	= sqlCommand.Parameters.Add("@USERPRTPPRIDDERIVNO", SqlDbType.Int);
						SqlParameter paraFrePrtPprExtraCondCd	= sqlCommand.Parameters.Add("@FREPRTPPREXTRACONDCD", SqlDbType.Int);
						SqlParameter paraDisplayOrder			= sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
						SqlParameter paraExtraConditionDivCd	= sqlCommand.Parameters.Add("@EXTRACONDITIONDIVCD", SqlDbType.Int);
						SqlParameter paraExtraConditionTypeCd	= sqlCommand.Parameters.Add("@EXTRACONDITIONTYPECD", SqlDbType.Int);
						SqlParameter paraExtraConditionTitle	= sqlCommand.Parameters.Add("@EXTRACONDITIONTITLE", SqlDbType.NVarChar);
						SqlParameter paraDDCharCnt				= sqlCommand.Parameters.Add("@DDCHARCNT", SqlDbType.Int);
						SqlParameter paraDDName					= sqlCommand.Parameters.Add("@DDNAME", SqlDbType.NVarChar);
						SqlParameter paraStExtraNumCode			= sqlCommand.Parameters.Add("@STEXTRANUMCODE", SqlDbType.BigInt);
						SqlParameter paraEdExtraNumCode			= sqlCommand.Parameters.Add("@EDEXTRANUMCODE", SqlDbType.BigInt);
						SqlParameter paraStExtraCharCode		= sqlCommand.Parameters.Add("@STEXTRACHARCODE", SqlDbType.NVarChar);
						SqlParameter paraEdExtraCharCode		= sqlCommand.Parameters.Add("@EDEXTRACHARCODE", SqlDbType.NVarChar);
						SqlParameter paraStExtraDateBaseCd		= sqlCommand.Parameters.Add("@STEXTRADATEBASECD", SqlDbType.Int);
						SqlParameter paraStExtraDateSignCd		= sqlCommand.Parameters.Add("@STEXTRADATESIGNCD", SqlDbType.Int);
						SqlParameter paraStExtraDateNum			= sqlCommand.Parameters.Add("@STEXTRADATENUM", SqlDbType.Int);
						SqlParameter paraStExtraDateUnitCd		= sqlCommand.Parameters.Add("@STEXTRADATEUNITCD", SqlDbType.Int);
						SqlParameter paraStartExtraDate			= sqlCommand.Parameters.Add("@STARTEXTRADATE", SqlDbType.Int);
						SqlParameter paraEdExtraDateBaseCd		= sqlCommand.Parameters.Add("@EDEXTRADATEBASECD", SqlDbType.Int);
						SqlParameter paraEdExtraDateSignCd		= sqlCommand.Parameters.Add("@EDEXTRADATESIGNCD", SqlDbType.Int);
						SqlParameter paraEdExtraDateNum			= sqlCommand.Parameters.Add("@EDEXTRADATENUM", SqlDbType.Int);
						SqlParameter paraEdExtraDateUnitCd		= sqlCommand.Parameters.Add("@EDEXTRADATEUNITCD", SqlDbType.Int);
						SqlParameter paraEndExtraDate			= sqlCommand.Parameters.Add("@ENDEXTRADATE", SqlDbType.Int);
						SqlParameter paraExtraCondDetailGrpCd	= sqlCommand.Parameters.Add("@EXTRACONDDETAILGRPCD", SqlDbType.Int);
						SqlParameter paraNecessaryExtraCondCd	= sqlCommand.Parameters.Add("@NECESSARYEXTRACONDCD", SqlDbType.Int);
						SqlParameter paraCheckItemCode1			= sqlCommand.Parameters.Add("@CHECKITEMCODE1", SqlDbType.Int);
						SqlParameter paraCheckItemCode2			= sqlCommand.Parameters.Add("@CHECKITEMCODE2", SqlDbType.Int);
						SqlParameter paraCheckItemCode3			= sqlCommand.Parameters.Add("@CHECKITEMCODE3", SqlDbType.Int);
						SqlParameter paraCheckItemCode4			= sqlCommand.Parameters.Add("@CHECKITEMCODE4", SqlDbType.Int);
						SqlParameter paraCheckItemCode5			= sqlCommand.Parameters.Add("@CHECKITEMCODE5", SqlDbType.Int);
						SqlParameter paraCheckItemCode6			= sqlCommand.Parameters.Add("@CHECKITEMCODE6", SqlDbType.Int);
						SqlParameter paraCheckItemCode7			= sqlCommand.Parameters.Add("@CHECKITEMCODE7", SqlDbType.Int);
						SqlParameter paraCheckItemCode8			= sqlCommand.Parameters.Add("@CHECKITEMCODE8", SqlDbType.Int);
						SqlParameter paraCheckItemCode9			= sqlCommand.Parameters.Add("@CHECKITEMCODE9", SqlDbType.Int);
						SqlParameter paraCheckItemCode10		= sqlCommand.Parameters.Add("@CHECKITEMCODE10", SqlDbType.Int);
						SqlParameter paraFileNm					= sqlCommand.Parameters.Add("@FILENM", SqlDbType.NVarChar);
						SqlParameter paraInputCharCnt			= sqlCommand.Parameters.Add("@INPUTCHARCNT", SqlDbType.Int);
						#endregion

						#region Parameter�I�u�W�F�N�g�֒l�ݒ�
						paraCreateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(frePprECndWork.CreateDateTime);
						paraUpdateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(frePprECndWork.UpdateDateTime);
						paraEnterpriseCode.Value		= SqlDataMediator.SqlSetString(frePprECndWork.EnterpriseCode);
						paraFileHeaderGuid.Value		= SqlDataMediator.SqlSetGuid(frePprECndWork.FileHeaderGuid);
						paraUpdEmployeeCode.Value		= SqlDataMediator.SqlSetString(frePprECndWork.UpdEmployeeCode);
						paraUpdAssemblyId1.Value		= SqlDataMediator.SqlSetString(frePprECndWork.UpdAssemblyId1);
						paraUpdAssemblyId2.Value		= SqlDataMediator.SqlSetString(frePprECndWork.UpdAssemblyId2);
						paraLogicalDeleteCode.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.LogicalDeleteCode);
						paraOutputFormFileName.Value	= SqlDataMediator.SqlSetString(frePprECndWork.OutputFormFileName);
						paraUserPrtPprIdDerivNo.Value	= SqlDataMediator.SqlSetInt32(frePprECndWork.UserPrtPprIdDerivNo);
						paraFrePrtPprExtraCondCd.Value	= SqlDataMediator.SqlSetInt32(frePprECndWork.FrePrtPprExtraCondCd);
						paraDisplayOrder.Value			= SqlDataMediator.SqlSetInt32(frePprECndWork.DisplayOrder);
						paraExtraConditionDivCd.Value	= SqlDataMediator.SqlSetInt32(frePprECndWork.ExtraConditionDivCd);
						paraExtraConditionTypeCd.Value	= SqlDataMediator.SqlSetInt32(frePprECndWork.ExtraConditionTypeCd);
						paraExtraConditionTitle.Value	= SqlDataMediator.SqlSetString(frePprECndWork.ExtraConditionTitle);
						paraDDCharCnt.Value				= SqlDataMediator.SqlSetInt32(frePprECndWork.DDCharCnt);
						paraDDName.Value				= SqlDataMediator.SqlSetString(frePprECndWork.DDName);
						paraStExtraNumCode.Value		= SqlDataMediator.SqlSetInt64(frePprECndWork.StExtraNumCode);
						paraEdExtraNumCode.Value		= SqlDataMediator.SqlSetInt64(frePprECndWork.EdExtraNumCode);
						paraStExtraCharCode.Value		= SqlDataMediator.SqlSetString(frePprECndWork.StExtraCharCode);
						paraEdExtraCharCode.Value		= SqlDataMediator.SqlSetString(frePprECndWork.EdExtraCharCode);
						paraStExtraDateBaseCd.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.StExtraDateBaseCd);
						paraStExtraDateSignCd.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.StExtraDateSignCd);
						paraStExtraDateNum.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.StExtraDateNum);
						paraStExtraDateUnitCd.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.StExtraDateUnitCd);
						paraStartExtraDate.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.StartExtraDate);
						paraEdExtraDateBaseCd.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.EdExtraDateBaseCd);
						paraEdExtraDateSignCd.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.EdExtraDateSignCd);
						paraEdExtraDateNum.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.EdExtraDateNum);
						paraEdExtraDateUnitCd.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.EdExtraDateUnitCd);
						paraEndExtraDate.Value			= SqlDataMediator.SqlSetInt32(frePprECndWork.EndExtraDate);
						paraExtraCondDetailGrpCd.Value	= SqlDataMediator.SqlSetInt32(frePprECndWork.ExtraCondDetailGrpCd);
						paraNecessaryExtraCondCd.Value	= SqlDataMediator.SqlSetInt32(frePprECndWork.NecessaryExtraCondCd);
						paraCheckItemCode1.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.CheckItemCode1);
						paraCheckItemCode2.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.CheckItemCode2);
						paraCheckItemCode3.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.CheckItemCode3);
						paraCheckItemCode4.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.CheckItemCode4);
						paraCheckItemCode5.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.CheckItemCode5);
						paraCheckItemCode6.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.CheckItemCode6);
						paraCheckItemCode7.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.CheckItemCode7);
						paraCheckItemCode8.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.CheckItemCode8);
						paraCheckItemCode9.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.CheckItemCode9);
						paraCheckItemCode10.Value		= SqlDataMediator.SqlSetInt32(frePprECndWork.CheckItemCode10);
						paraFileNm.Value				= SqlDataMediator.SqlSetString(frePprECndWork.FileNm);
						paraInputCharCnt.Value			= SqlDataMediator.SqlSetInt32(frePprECndWork.InputCharCnt);
						#endregion

						sqlCommand.ExecuteNonQuery();

						frePprECndWorkList.Add(frePprECndWork);
					}

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			finally
			{
				if (myReader != null)
				{
					if (!myReader.IsClosed)
						myReader.Close();
				}
				if (sqlCommand != null)
				{
					sqlCommand.Cancel();
					sqlCommand.Dispose();
				}
			}

			frePprECndWorkArray = frePprECndWorkList.ToArray();

			return status;
		}

		/// <summary>
		/// ���R���[�\�[�g���ʕۑ������i���C�����j
		/// </summary>
		/// <param name="frePprSrtOWorkArray">���R���[�\�[�g���ʃ��[�N�z��</param>
		/// <param name="sqlConnection">SQL�R�l�N�V����</param>
		/// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�\�[�g���ʂ̕ۑ��������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private int WriteFrePprSrtOProc(ref FrePprSrtOWork[] frePprSrtOWorkArray, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlDataReader myReader	= null;
			SqlCommand sqlCommand	= null;
			List<FrePprSrtOWork> frePprSrtOWorkList = null;

			try
			{
				if (frePprSrtOWorkArray != null && frePprSrtOWorkArray.Length > 0)
				{
					DateTime updateDateTime = DateTime.MinValue;
					frePprSrtOWorkList = new List<FrePprSrtOWork>();

					for (int ix = 0 ; ix != frePprSrtOWorkArray.Length ; ix++)
					{
						FrePprSrtOWork frePprSrtOWork = frePprSrtOWorkArray[ix];

						// Select�R�}���h�̐���
						sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM FREPPRSRTORF", sqlConnection, sqlTransaction);
						// Where���̒ǉ�
						sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO AND SORTINGORDERCODERF=@FINDSORTINGORDERCODE";

						// ��ƃR�[�h
						SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
						findParaEnterpriseCode.Value		= frePprSrtOWork.EnterpriseCode;
						// �o�̓t�@�C����
						SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
						findParaOutputFormFileName.Value	= frePprSrtOWork.OutputFormFileName;
						// ���[�U�[���[ID�}�ԍ�
						SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);
						findParaUserPrtPprIdDerivNo.Value	= frePprSrtOWork.UserPrtPprIdDerivNo;
						// �\�[�g���ʃR�[�h
						SqlParameter findParaSortingOrderCode = sqlCommand.Parameters.Add("@FINDSORTINGORDERCODE", SqlDbType.Int);
						findParaSortingOrderCode.Value		= frePprSrtOWork.SortingOrderCode;

						// �^�C���A�E�g���Ԑݒ�
						sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.Common);

						myReader = sqlCommand.ExecuteReader();
						if (myReader.Read())
						{
							// ������ �X�V���[�h ������

							// �X�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
							DateTime wkDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));	// �X�V����
							if (wkDateTime != frePprSrtOWork.UpdateDateTime)
							{
								// �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
								if (frePprSrtOWork.UpdateDateTime == DateTime.MinValue)
									status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
								// �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
								else
									status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

								sqlCommand.Cancel();

								if (!myReader.IsClosed) myReader.Close();

								return status;
							}

							//Update�R�}���h�̐���
							sqlCommand.CommandText = "UPDATE FREPPRSRTORF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , USERPRTPPRIDDERIVNORF=@USERPRTPPRIDDERIVNO , SORTINGORDERCODERF=@SORTINGORDERCODE , SORTINGORDERRF=@SORTINGORDER , FREEPRTPAPERITEMNMRF=@FREEPRTPAPERITEMNM , DDNAMERF=@DDNAME , FILENMRF=@FILENM , SORTINGORDERDIVCDRF=@SORTINGORDERDIVCD";
							// Where���̒ǉ�
							sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO AND SORTINGORDERCODERF=@FINDSORTINGORDERCODE";
							// Key�f�[�^�Đݒ�
							findParaEnterpriseCode.Value		= frePprSrtOWork.EnterpriseCode;		// ��ƃR�[�h
							findParaOutputFormFileName.Value	= frePprSrtOWork.OutputFormFileName;	// �o�̓t�@�C����
							findParaUserPrtPprIdDerivNo.Value	= frePprSrtOWork.UserPrtPprIdDerivNo;	// ���[�U�[���[ID�}�ԍ�
							findParaSortingOrderCode.Value		= frePprSrtOWork.SortingOrderCode;		//

							//�X�V�w�b�_����ݒ�
							object obj = (object)this;
							IFileHeader iFileHeader = (IFileHeader)frePprSrtOWork;
							FileHeader fileHeader = new FileHeader(obj);
							fileHeader.SetUpdateHeader(ref iFileHeader, obj);
							if (updateDateTime == DateTime.MinValue) updateDateTime = frePprSrtOWork.UpdateDateTime;
						}
						else
						{
							// ������ �V�K���[�h ������

							// �X�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
							if (frePprSrtOWork.UpdateDateTime > DateTime.MinValue)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
								return status;
							}

							//Insert�R�}���h�̐���
							sqlCommand.CommandText = "INSERT INTO FREPPRSRTORF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF, SORTINGORDERCODERF, SORTINGORDERRF, FREEPRTPAPERITEMNMRF, DDNAMERF, FILENMRF, SORTINGORDERDIVCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @OUTPUTFORMFILENAME, @USERPRTPPRIDDERIVNO, @SORTINGORDERCODE, @SORTINGORDER, @FREEPRTPAPERITEMNM, @DDNAME, @FILENM, @SORTINGORDERDIVCD)";
							//�o�^�w�b�_����ݒ�
							object obj = (object)this;
							IFileHeader iFileHeader = (IFileHeader)frePprSrtOWork;
							FileHeader fileHeader = new FileHeader(obj);
							fileHeader.SetInsertHeader(ref iFileHeader, obj);
							if (updateDateTime == DateTime.MinValue) updateDateTime = frePprSrtOWork.UpdateDateTime;
						}
						if (!myReader.IsClosed) myReader.Close();

						// �X�V���t�𓝈ꂷ��
						frePprSrtOWork.UpdateDateTime = updateDateTime;

						#region Prameter�I�u�W�F�N�g�̍쐬
						SqlParameter paraCreateDateTime			= sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
						SqlParameter paraUpdateDateTime			= sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
						SqlParameter paraEnterpriseCode			= sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
						SqlParameter paraFileHeaderGuid			= sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
						SqlParameter paraUpdEmployeeCode		= sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
						SqlParameter paraUpdAssemblyId1			= sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
						SqlParameter paraUpdAssemblyId2			= sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
						SqlParameter paraLogicalDeleteCode		= sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
						SqlParameter paraOutputFormFileName		= sqlCommand.Parameters.Add("@OUTPUTFORMFILENAME", SqlDbType.NVarChar);
						SqlParameter paraUserPrtPprIdDerivNo	= sqlCommand.Parameters.Add("@USERPRTPPRIDDERIVNO", SqlDbType.Int);
						SqlParameter paraSortingOrderCode		= sqlCommand.Parameters.Add("@SORTINGORDERCODE", SqlDbType.Int);
						SqlParameter paraSortingOrder			= sqlCommand.Parameters.Add("@SORTINGORDER", SqlDbType.Int);
						SqlParameter paraFreePrtPaperItemNm		= sqlCommand.Parameters.Add("@FREEPRTPAPERITEMNM", SqlDbType.NVarChar);
						SqlParameter paraDDName					= sqlCommand.Parameters.Add("@DDNAME", SqlDbType.NVarChar);
						SqlParameter paraFileNm					= sqlCommand.Parameters.Add("@FILENM", SqlDbType.NVarChar);
						SqlParameter paraSortingOrderDivCd		= sqlCommand.Parameters.Add("@SORTINGORDERDIVCD", SqlDbType.Int);
						#endregion

						#region Parameter�I�u�W�F�N�g�֒l�ݒ�
						paraCreateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(frePprSrtOWork.CreateDateTime);
						paraUpdateDateTime.Value		= SqlDataMediator.SqlSetDateTimeFromTicks(frePprSrtOWork.UpdateDateTime);
						paraEnterpriseCode.Value		= SqlDataMediator.SqlSetString(frePprSrtOWork.EnterpriseCode);
						paraFileHeaderGuid.Value		= SqlDataMediator.SqlSetGuid(frePprSrtOWork.FileHeaderGuid);
						paraUpdEmployeeCode.Value		= SqlDataMediator.SqlSetString(frePprSrtOWork.UpdEmployeeCode);
						paraUpdAssemblyId1.Value		= SqlDataMediator.SqlSetString(frePprSrtOWork.UpdAssemblyId1);
						paraUpdAssemblyId2.Value		= SqlDataMediator.SqlSetString(frePprSrtOWork.UpdAssemblyId2);
						paraLogicalDeleteCode.Value		= SqlDataMediator.SqlSetInt32(frePprSrtOWork.LogicalDeleteCode);
						paraOutputFormFileName.Value	= SqlDataMediator.SqlSetString(frePprSrtOWork.OutputFormFileName);
						paraUserPrtPprIdDerivNo.Value	= SqlDataMediator.SqlSetInt32(frePprSrtOWork.UserPrtPprIdDerivNo);
						paraSortingOrderCode.Value		= SqlDataMediator.SqlSetInt32(frePprSrtOWork.SortingOrderCode);
						paraSortingOrder.Value			= SqlDataMediator.SqlSetInt32(frePprSrtOWork.SortingOrder);
						paraFreePrtPaperItemNm.Value	= SqlDataMediator.SqlSetString(frePprSrtOWork.FreePrtPaperItemNm);
						paraDDName.Value				= SqlDataMediator.SqlSetString(frePprSrtOWork.DDName);
						paraFileNm.Value				= SqlDataMediator.SqlSetString(frePprSrtOWork.FileNm);
						paraSortingOrderDivCd.Value		= SqlDataMediator.SqlSetInt32(frePprSrtOWork.SortingOrderDivCd);
						#endregion

						sqlCommand.ExecuteNonQuery();

						frePprSrtOWorkList.Add(frePprSrtOWork);
					}
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			finally
			{
				if (myReader != null)
				{
					if (!myReader.IsClosed)
						myReader.Close();
				}
				if (sqlCommand != null)
				{
					sqlCommand.Cancel();
					sqlCommand.Dispose();
				}
			}

			frePprSrtOWorkArray = frePprSrtOWorkList.ToArray();

			return status;
		}
		#endregion

		/// <summary>
		/// �R�l�N�V������񐶐�
		/// </summary>
		/// <returns>�R�l�N�V�������</returns>
		private SqlConnection CreateSqlConnection()
		{
			SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
			if (connectionText == null || connectionText == "") return null;

			return new SqlConnection(connectionText);
		}

		/// <summary>
		/// WHERE���쐬����
		/// </summary>
		/// <param name="sqlCommand">SQL�R�}���h</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <returns>WHERE��</returns>
		private string MakeWhereString(ref SqlCommand sqlCommand, string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo)
		{
			StringBuilder whereString = new StringBuilder();

			// ��ƃR�[�h�͕K�{����
			whereString.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ");
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			findParaEnterpriseCode.Value = enterpriseCode;

			// �o�̓t�@�C����
			if (outputFormFileName != null && !outputFormFileName.Equals(string.Empty))
			{
				whereString.Append(" AND ");
				whereString.Append("OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME");
				SqlParameter findParaOutputFormFileName = sqlCommand.Parameters.Add("@FINDOUTPUTFORMFILENAME", SqlDbType.NVarChar);
				findParaOutputFormFileName.Value = outputFormFileName;
			}

			// ���[�U�[���[ID�}�ԍ�
			if (userPrtPprIdDerivNo != 0)
			{
				whereString.Append(" AND ");
				whereString.Append("USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO");
				SqlParameter findParaUserPrtPprIdDerivNo = sqlCommand.Parameters.Add("@FINDUSERPRTPPRIDDERIVNO", SqlDbType.Int);
				findParaUserPrtPprIdDerivNo.Value = userPrtPprIdDerivNo;
			}

			return whereString.ToString();
        }
        #endregion

        # region [���R���[�`�[�p �ǉ����\�b�h]
        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�ݒ�Ǎ������i���C�����j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="frePrtPSetReadKeyList">���R���[�󎚈ʒu�ݒ�Read�L�[���X�g</param>
        /// <param name="frePrtPSetWorkList">���R���[�󎚈ʒu�ݒ胏�[�N</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note         : �Y�����鎩�R���[�󎚈ʒu�ݒ胏�[�N��(������)�擾���܂��B</br>
        /// <br>               �i������ReadFrePrtPSetProc���\�b�h���x�[�X�ɍ쐬�j</br>
        /// <br>Programmer   : 22018 ��� ���b</br>
        /// <br>Date         : 2008.06.02</br>
        /// </remarks>
        public int SearchFrePrtPSetProc( string enterpriseCode, List<FrePrtPSetReadKey> frePrtPSetReadKeyList, out List<FrePrtPSetWork> frePrtPSetWorkList, ref SqlConnection sqlConnection )
        {
            return SearchFrePrtPSetProcProc( enterpriseCode, frePrtPSetReadKeyList, out frePrtPSetWorkList, ref sqlConnection );
        }
        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�ݒ�Ǎ������i���C�����j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="frePrtPSetReadKeyList">���R���[�󎚈ʒu�ݒ�Read�L�[���X�g</param>
        /// <param name="frePrtPSetWorkList">���R���[�󎚈ʒu�ݒ胏�[�N</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchFrePrtPSetProcProc( string enterpriseCode, List<FrePrtPSetReadKey> frePrtPSetReadKeyList, out List<FrePrtPSetWork> frePrtPSetWorkList, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            frePrtPSetWorkList = null;

            SqlDataReader myReader = null;
            try
            {
                // Select�R�}���h�̐���
                SqlCommand sqlCommand = new SqlCommand( "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, OUTPUTFORMFILENAMERF, USERPRTPPRIDDERIVNORF, PRINTPAPERUSEDIVCDRF, PRINTPAPERDIVCDRF, EXTRACTIONPGIDRF, EXTRACTIONPGCLASSIDRF, OUTPUTPGIDRF, OUTPUTPGCLASSIDRF, OUTCONFIMATIONMSGRF, DISPLAYNAMERF, PRTPPRUSERDERIVNOCMTRF, PRINTPOSITIONVERRF, MERGEABLEPRINTPOSVERRF, DATAINPUTSYSTEMRF, OPTIONCODERF, FREEPRTPPRITEMGRPCDRF, FORMFEEDLINECOUNTRF, EDGECHARPROCDIVCDRF, PRTPPRBGIMAGEROWPOSRF, PRTPPRBGIMAGECOLPOSRF, TAKEINIMAGEGROUPCDRF, EXTRASECTIONKINDCDRF, EXTRASECTIONSELEXISTRF, RDETAILBACKCOLORRF, GDETAILBACKCOLORRF, BDETAILBACKCOLORRF, CRCHARCNTRF, FREEPRTPPRSPPRPSECDRF, PRINTPOSCLASSDATARF FROM FREPRTPSETRF", sqlConnection );
                // Where���̒ǉ�
                sqlCommand.CommandText += MakeWhereString( ref sqlCommand, enterpriseCode, frePrtPSetReadKeyList );

                // �^�C���A�E�g���Ԑݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead );

                myReader = sqlCommand.ExecuteReader();

                frePrtPSetWorkList = new List<FrePrtPSetWork>();
                while ( myReader.Read() )
                {
                    FrePrtPSetWork frePrtPSetWork = new FrePrtPSetWork();

                    #region �f�[�^�̃R�s�[
                    frePrtPSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "CREATEDATETIMERF" ) );
                    frePrtPSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks( myReader, myReader.GetOrdinal( "UPDATEDATETIMERF" ) );
                    frePrtPSetWork.EnterpriseCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISECODERF" ) );
                    frePrtPSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid( myReader, myReader.GetOrdinal( "FILEHEADERGUIDRF" ) );
                    frePrtPSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDEMPLOYEECODERF" ) );
                    frePrtPSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDASSEMBLYID1RF" ) );
                    frePrtPSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UPDASSEMBLYID2RF" ) );
                    frePrtPSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "LOGICALDELETECODERF" ) );
                    frePrtPSetWork.OutputFormFileName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OUTPUTFORMFILENAMERF" ) );
                    frePrtPSetWork.UserPrtPprIdDerivNo = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "USERPRTPPRIDDERIVNORF" ) );
                    frePrtPSetWork.PrintPaperUseDivcd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRINTPAPERUSEDIVCDRF" ) );
                    frePrtPSetWork.PrintPaperDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRINTPAPERDIVCDRF" ) );
                    frePrtPSetWork.ExtractionPgId = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EXTRACTIONPGIDRF" ) );
                    frePrtPSetWork.ExtractionPgClassId = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EXTRACTIONPGCLASSIDRF" ) );
                    frePrtPSetWork.OutputPgId = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OUTPUTPGIDRF" ) );
                    frePrtPSetWork.OutputPgClassId = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OUTPUTPGCLASSIDRF" ) );
                    frePrtPSetWork.OutConfimationMsg = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OUTCONFIMATIONMSGRF" ) );
                    frePrtPSetWork.DisplayName = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DISPLAYNAMERF" ) );
                    frePrtPSetWork.PrtPprUserDerivNoCmt = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTPPRUSERDERIVNOCMTRF" ) );
                    frePrtPSetWork.PrintPositionVer = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRINTPOSITIONVERRF" ) );
                    frePrtPSetWork.MergeablePrintPosVer = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MERGEABLEPRINTPOSVERRF" ) );
                    frePrtPSetWork.DataInputSystem = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DATAINPUTSYSTEMRF" ) );
                    frePrtPSetWork.OptionCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OPTIONCODERF" ) );
                    frePrtPSetWork.FreePrtPprItemGrpCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "FREEPRTPPRITEMGRPCDRF" ) );
                    frePrtPSetWork.FormFeedLineCount = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "FORMFEEDLINECOUNTRF" ) );
                    frePrtPSetWork.EdgeCharProcDivCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "EDGECHARPROCDIVCDRF" ) );
                    frePrtPSetWork.PrtPprBgImageRowPos = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "PRTPPRBGIMAGEROWPOSRF" ) );
                    frePrtPSetWork.PrtPprBgImageColPos = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "PRTPPRBGIMAGECOLPOSRF" ) );
                    frePrtPSetWork.TakeInImageGroupCd = SqlDataMediator.SqlGetGuid( myReader, myReader.GetOrdinal( "TAKEINIMAGEGROUPCDRF" ) );
                    frePrtPSetWork.ExtraSectionKindCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "EXTRASECTIONKINDCDRF" ) );
                    frePrtPSetWork.ExtraSectionSelExist = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "EXTRASECTIONSELEXISTRF" ) );
                    frePrtPSetWork.RDetailBackColor = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "RDETAILBACKCOLORRF" ) );
                    frePrtPSetWork.GDetailBackColor = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GDETAILBACKCOLORRF" ) );
                    frePrtPSetWork.BDetailBackColor = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BDETAILBACKCOLORRF" ) );
                    frePrtPSetWork.CrCharCnt = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CRCHARCNTRF" ) );
                    frePrtPSetWork.FreePrtPprSpPrpseCd = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "FREEPRTPPRSPPRPSECDRF" ) );
                    frePrtPSetWork.PrintPosClassData = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "PRINTPOSCLASSDATARF" ) );
                    #endregion

                    frePrtPSetWorkList.Add( frePrtPSetWork );
                }

                if ( frePrtPSetWorkList.Count > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            finally
            {
                if ( myReader != null )
                {
                    if ( !myReader.IsClosed )
                        myReader.Close();
                }
            }

            return status;
        }
        /// <summary>
        /// WHERE���쐬����
        /// </summary>
        /// <param name="sqlCommand">SQL�R�}���h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="frePrtPSetReadKeyList">���R���[�󎚈ʒu�ݒ�Read�L�[���X�g</param>
        /// <returns>WHERE��</returns>
        private string MakeWhereString( ref SqlCommand sqlCommand, string enterpriseCode, List<FrePrtPSetReadKey> frePrtPSetReadKeyList )
        {
            StringBuilder whereString = new StringBuilder();

            // ��ƃR�[�h�͕K�{����
            whereString.Append( " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE " );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = enterpriseCode;

            // �o�̓t�@�C����/���[�U�[���[ID�}�ԍ�
            if ( frePrtPSetReadKeyList != null && frePrtPSetReadKeyList.Count > 0 )
            {
                whereString.Append( " AND (" );

                List<SqlParameter> findParaOutputFormFileNames = new List<SqlParameter>();
                List<SqlParameter> findParaUserPrtPprIdDerivNos = new List<SqlParameter>();
                for ( int index = 0; index < frePrtPSetReadKeyList.Count; index++ )
                {
                    if ( index != 0 )
                    {
                        whereString.Append( Environment.NewLine + " OR " );
                    }

                    whereString.Append( string.Format( "OUTPUTFORMFILENAMERF=@FINDOUTPUTFORMFILENAME{0} AND USERPRTPPRIDDERIVNORF=@FINDUSERPRTPPRIDDERIVNO{0}", index ) );

                    findParaOutputFormFileNames.Add( sqlCommand.Parameters.Add( string.Format( "@FINDOUTPUTFORMFILENAME{0}", index ), SqlDbType.NVarChar ) );
                    findParaOutputFormFileNames[index].Value = frePrtPSetReadKeyList[index].OutputFormFileName;

                    findParaUserPrtPprIdDerivNos.Add( sqlCommand.Parameters.Add( string.Format( "@FINDUSERPRTPPRIDDERIVNO{0}", index ), SqlDbType.Int ) );
                    findParaUserPrtPprIdDerivNos[index].Value = frePrtPSetReadKeyList[index].UserPrtPprIdDerivNo;
                }

                whereString.Append( " ) " );
            }
            return whereString.ToString();
        }
        # endregion

        # region [���R���[�`�[�p �ǉ������o]
        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�Read�L�[�\����
        /// </summary>
        /// <remarks>���������[�g����{�����[�g���Ăяo���ꍇ�̓ǂݍ��݃L�[���ł��B</remarks>
        public struct FrePrtPSetReadKey
        {
            /// <summary>�o�̓t�H�[���t�@�C����</summary>
            private string _outputFormFileName;
            /// <summary>���[�U�[���[�h�c�}��</summary>
            private int _userPrtPprIdDerivNo;
            /// <summary>
            /// �o�̓t�H�[���t�@�C����
            /// </summary>
            /// <remarks>�����R���[��ٰ��_��ƺ���</remarks>
            public string OutputFormFileName
            {
                get { return _outputFormFileName; }
                set { _outputFormFileName = value; }
            }
            /// <summary>
            /// ���[�U�[���[�h�c�}��
            /// </summary>
            /// <remarks>���A�ԂŎ����̔�</remarks>
            public int UserPrtPprIdDerivNo
            {
                get { return _userPrtPprIdDerivNo; }
                set { _userPrtPprIdDerivNo = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="outputFormFileName">�o�̓t�H�[���t�@�C����</param>
            /// <param name="userPrtPprIdDerivNo">���[�U�[���[�h�c�}��</param>
            public FrePrtPSetReadKey( string outputFormFileName, int userPrtPprIdDerivNo )
            {
                _outputFormFileName = outputFormFileName;
                _userPrtPprIdDerivNo = userPrtPprIdDerivNo;
            }
        }
        # endregion
    }
}

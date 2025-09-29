//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Ԍ������X�V
// �v���O�����T�v   : �Ԍ������X�VDB�����[�g�I�u�W�F�N�g�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �I�M
// �� �� ��  2010/05/25  �C�����e : redmine #8013��Ή�
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
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �Ԍ������X�VREADDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : �Ԍ������X�VREAD�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : ���C��</br>
	/// <br>Date       : 2010/04/21</br>
	/// </remarks>
	[Serializable]
	public class InspectDateUpdDB : RemoteWithAppLockDB, IInspectDateUpdDB
	{
		# region �� Constructor ��
		/// <summary>
		/// �Ԍ������X�V����READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �Ԍ������X�V����READ�̎��f�[�^������s���N���X�ł��B</br>
		/// <br>Programmer : ���C��</br>
		/// <br>Date       : 2010/04/21</br>
		/// </remarks>
		public InspectDateUpdDB()
		{
		}
		#endregion


		#region �� �Ԍ������X�V���� ��
		/// <summary>
		/// �Ԍ������X�V����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="updateDate">�X�V�N��</param>
		/// <param name="searchNum">���o����</param>
		/// <param name="updNum">�X�V����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �Ԍ������X�V�������s���N���X�ł��B</br>
		/// <br>Programmer : ���C��</br>
		/// <br>Date       : 2010/04/21</br>
		/// </remarks>
		public int InspectDateUpdProc(string enterpriseCode, int updateDate, out int searchNum, out int updNum)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			searchNum = 0;
			updNum = 0;
			//--------------------------
			// �f�[�^�x�[�X�I�[�v��
			//--------------------------
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			ShareCheckInfo info = new ShareCheckInfo();

			try
			{
				SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
				string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
				if (_connectionText == null || _connectionText == "")
				{
					return status;
				}

				sqlConnection = new SqlConnection(_connectionText);
				sqlConnection.Open();
				//���g�����U�N�V�����J�n
				sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

				#region �r������
				//�V�X�e�����b�N(���)
				info.Keys.Add(enterpriseCode, ShareCheckType.Enterprise, "", "");
				status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

				if (status != 0)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT;
					return status;
				}
				#endregion

				ArrayList carManagementWorkList = null;

				status = SearchCarManagement(enterpriseCode, updateDate, out carManagementWorkList, ref sqlConnection, ref sqlTransaction);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					searchNum = carManagementWorkList.Count;
					status = UpdateCarManagement(ref updNum, carManagementWorkList, ref sqlConnection, ref sqlTransaction);
				}
			}
			catch (Exception ex)
			{
				// ���N���X�ɗ�O��n���ď������Ă��炤
				base.WriteErrorLog(ex, "InspectDateUpdDB.InspectDateUpdProc Exception=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
				if (sqlConnection != null)
				{
					if (sqlTransaction.Connection != null)
					{
						//�V�X�e�����b�N����
						int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							status = st;
						}

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							sqlTransaction.Commit();
						}
						else
						{
							sqlTransaction.Rollback();
						}
					}
				}

				if (sqlTransaction != null) sqlTransaction.Dispose();
				if (sqlConnection != null)
				{
					sqlConnection.Close();
					sqlConnection.Dispose();
				}
			}
			return status;
		}


		/// <summary>
		/// �w�肳�ꂽ�����̎Ԍ���������߂��܂�(�O�������SqlConnection���g�p)
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="updateDate">�X�V�N��</param>
		/// <param name="carManagementWorkList">���q�Ǘ��}�X�^</param>
		/// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>  
		/// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �Ԍ������X�V�������s���N���X�ł��B</br>
		/// <br>Programmer : ���C��</br>
		/// <br>Date       : 2010/04/21</br>
		/// </remarks>        
		private int SearchCarManagement(string enterpriseCode, int updateDate, out ArrayList carManagementWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			//�ϐ��̐錾
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			//�ϐ��̏�����
			carManagementWorkList = new ArrayList();

			if (sqlConnection == null)
			{
				return status;
			}

			if (sqlTransaction == null)
			{
				return status;
			}

			SqlCommand command = new SqlCommand("", sqlConnection, sqlTransaction);
			SqlDataReader myReader = null;

			try
			{
				//Select�R�}���h�̐���
				StringBuilder sql = new StringBuilder();
				sql.Append("SELECT ");
				sql.Append("  UPDATEDATETIMERF, ");
				sql.Append("  ENTERPRISECODERF, ");
				sql.Append("  LOGICALDELETECODERF, ");
				sql.Append("  CUSTOMERCODERF, ");
				sql.Append("  CARMNGNORF, ");
				sql.Append("  CARMNGCODERF, ");// ADD 2010/05/25 by jiangk for add Primary Key CarMngCode
				sql.Append("  INSPECTMATURITYDATERF, ");
				sql.Append("  CARINSPECTYEARRF ");
				sql.Append("FROM   ");
				sql.Append("  CARMANAGEMENTRF WITH (READUNCOMMITTED) ");
				sql.Append("WHERE  ");
				sql.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE ");
				sql.Append("  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
				sql.Append("  AND INSPECTMATURITYDATERF >= @FINDINSPECTMATURITYDATEMIN ");
				sql.Append("  AND INSPECTMATURITYDATERF <= @FINDINSPECTMATURITYDATEMAX ");

				//�p�����[�^�N���X�̐���������
				SqlParameter findParaEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaLogicalDeleteCode = command.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				SqlParameter findParaInspectMaturityDateMin = command.Parameters.Add("@FINDINSPECTMATURITYDATEMIN", SqlDbType.Int);
				SqlParameter findParaInspectMaturityDateMax = command.Parameters.Add("@FINDINSPECTMATURITYDATEMAX", SqlDbType.Int);

				//�p�����[�^��ݒ肷��
				findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
				findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
				findParaInspectMaturityDateMin.Value = SqlDataMediator.SqlSetInt32(1);
				findParaInspectMaturityDateMax.Value = SqlDataMediator.SqlSetInt32(updateDate);

				command.CommandText = sql.ToString();

				//�ǂݍ���
				myReader = command.ExecuteReader();
				//�ǂݍ��߂��ꍇ
				while (myReader.Read())
				{
					CarManagementWork work = new CarManagementWork();

					//�f�[�^���Z�b�g����
					work.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
					work.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
					work.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
					work.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
					work.CarMngNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARMNGNORF"));
					work.CarMngCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CARMNGCODERF")); // ADD 2010/05/25 by jiangk for add Primary Key CarMngCode
					int inspectMaturityDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTMATURITYDATERF"));
					work.InspectMaturityDate = new DateTime(inspectMaturityDate / 10000, (inspectMaturityDate / 100) % 100, inspectMaturityDate % 100);
					work.CarInspectYear = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINSPECTYEARRF"));

					//���X�g�ɐݒ肷��
					carManagementWorkList.Add(work);
					//�߂�l��ݒ肷��
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
				base.WriteErrorLog(ex, "InspectDateUpdDB.SearchCarManagement");
			}
			finally
			{
				if (myReader != null)
					if (!myReader.IsClosed) myReader.Close();
			}

			return status;
		}


		/// <summary>
		/// �w�肳�ꂽ�����̎Ԍ����������X�V���܂�(�O�������SqlConnection���g�p)
		/// </summary>
		/// <param name="updNum">�X�V����</param>
		/// <param name="carManagementWorkList">���q�Ǘ��}�X�^</param>
		/// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>  
		/// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �Ԍ������X�V�������s���N���X�ł��B</br>
		/// <br>Programmer : ���C��</br>
		/// <br>Date       : 2010/04/21</br>
		/// </remarks>        
		private int UpdateCarManagement(ref int updNum, ArrayList carManagementWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			//�ϐ��̐錾
			int status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

			if (sqlConnection == null)
			{
				return status;
			}

			if (sqlTransaction == null)
			{
				return status;
			}

			SqlCommand command = new SqlCommand("", sqlConnection, sqlTransaction);
			SqlDataReader myReader = null;
			StringBuilder sql = null;

			try
			{
				//�p�����[�^�N���X�̐���������
				SqlParameter findParaEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				SqlParameter findParaLogicalDeleteCode = command.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				SqlParameter findParaCustomerCode = command.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
				SqlParameter findParaCarMngNo = command.Parameters.Add("@FINDCARMNGNO", SqlDbType.Int);
				SqlParameter findParaCarMngCode = command.Parameters.Add("@FINDCARMNGCODE", SqlDbType.NVarChar);// ADD 2010/05/25 by jiangk for add Primary Key CarMngCode

				int cnt = 0;

				#region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
				//Prameter�I�u�W�F�N�g�̍쐬
				//Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
				SqlParameter paraUpdateDateTime = null;
				SqlParameter paraUpdEmployeeCode = null;
				SqlParameter paraUpdAssemblyId1 = null;
				SqlParameter paraUpdAssemblyId2 = null;
				SqlParameter paraInspectMaturityDate = null;
				SqlParameter paraLTimeCiMatDate = null;
				#endregion

				foreach (CarManagementWork item in carManagementWorkList)
				{
					//Select�R�}���h�̐���
					sql = new StringBuilder();
					sql.Append("SELECT ");
					sql.Append("  UPDATEDATETIMERF ");
					sql.Append("FROM   ");
					sql.Append("  CARMANAGEMENTRF WITH (READUNCOMMITTED) ");
					sql.Append("WHERE  ");
					sql.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE ");
					sql.Append("  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
					sql.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE ");
					sql.Append("  AND CARMNGNORF = @FINDCARMNGNO ");
					sql.Append("  AND CARMNGCODERF = @FINDCARMNGCODE ");// ADD 2010/05/25 by jiangk for add Primary Key CarMngCode

					//�p�����[�^��ݒ肷��
					findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);
					findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(item.LogicalDeleteCode);
					findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(item.CustomerCode);
					findParaCarMngNo.Value = SqlDataMediator.SqlSetInt32(item.CarMngNo);
					findParaCarMngCode.Value = SqlDataMediator.SqlSetString(item.CarMngCode); // ADD 2010/05/25 by jiangk for add Primary Key CarMngCode

					command.CommandText = sql.ToString();

					//�ǂݍ���
					myReader = command.ExecuteReader();
					//�ǂݍ��߂��ꍇ
					if (myReader.Read())
					{
						//����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
						DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
						if (_updateDateTime != item.UpdateDateTime)
						{
							//�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
							command.Cancel();
							if (myReader != null)
							{
								if (!myReader.IsClosed) myReader.Close();
								myReader.Dispose();
							}
							continue;
						}
					}

					# region [UPDATE��]
					string sqlText = string.Empty;
					sqlText += "UPDATE CARMANAGEMENTRF" + Environment.NewLine;
					sqlText += "SET" + Environment.NewLine;
					sqlText += " UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
					sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
					sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
					sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
					sqlText += " ,INSPECTMATURITYDATERF = @UPDINSPECTMATURITYDATE" + Environment.NewLine;
					sqlText += " ,LTIMECIMATDATERF = @UPDLTIMECIMATDATE" + Environment.NewLine;
					sqlText += "WHERE" + Environment.NewLine;
					sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
					sqlText += "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
					sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
					sqlText += "  AND CARMNGNORF = @FINDCARMNGNO" + Environment.NewLine;
					sqlText += "  AND CARMNGCODERF = @FINDCARMNGCODE" + Environment.NewLine; // ADD 2010/05/25 by jiangk for adding Primary Key CarMngCode
					command.CommandText = sqlText;
					# endregion

					//�X�V�w�b�_����ݒ�
					object obj = (object)this;
					IFileHeader flhd = (IFileHeader)item;
					FileHeader fileHeader = new FileHeader(obj);
					fileHeader.SetUpdateHeader(ref flhd, obj);

					if (myReader != null)
					{
						if (!myReader.IsClosed) myReader.Close();
						myReader.Dispose();
					}

					if (cnt == 0)
					{
						#region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
						//Prameter�I�u�W�F�N�g�̍쐬
						//Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
						paraUpdateDateTime = command.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
						paraUpdEmployeeCode = command.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
						paraUpdAssemblyId1 = command.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
						paraUpdAssemblyId2 = command.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
						paraInspectMaturityDate = command.Parameters.Add("@UPDINSPECTMATURITYDATE", SqlDbType.Int);
						paraLTimeCiMatDate = command.Parameters.Add("@UPDLTIMECIMATDATE", SqlDbType.Int);
						#endregion

						cnt++;
					}

					#region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
					paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(item.UpdateDateTime);
					paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(item.UpdEmployeeCode);
					paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(item.UpdAssemblyId1);
					paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(item.UpdAssemblyId2);

					//�Ԍ��������̎Z�o
					//�Ԍ�������
					DateTime InspectMaturityDate = item.InspectMaturityDate;
					//�Ԍ�����
					int CarInspectYear = item.CarInspectYear;
					DateTime newInspectMaturityDate = InspectMaturityDate.AddYears(CarInspectYear);

					paraInspectMaturityDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(newInspectMaturityDate.ToString("yyyyMMdd")));
					paraLTimeCiMatDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(InspectMaturityDate.ToString("yyyyMMdd")));
					#endregion

					command.ExecuteNonQuery();

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					updNum++;
				}
			}
			catch (SqlException ex)
			{
				//���N���X�ɗ�O��n���ď������Ă��炤
				status = base.WriteSQLErrorLog(ex);
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "InspectDateUpdDB.UpdateCarManagement");
			}
			finally
			{
				if (myReader != null)
					if (!myReader.IsClosed) myReader.Close();
			}

			return status;
		}
		#endregion
	}
}

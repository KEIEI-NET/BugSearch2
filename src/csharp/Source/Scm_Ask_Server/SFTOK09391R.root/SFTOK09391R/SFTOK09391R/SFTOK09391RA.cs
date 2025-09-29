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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// PM�]�ƈ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : PM�]�ƈ��̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 22011 Kashihara</br>
	/// <br>Date       : 2013.05.28</br>
    /// <br>Note       : ����ꗗ_PM-TAB No.48</br>
    /// <br>Programmer : �A����</br>
    /// <br>Date       : 2013/06/11</br>
    /// <br>Note       : �\�[�X�`�F�b�N�m�F�����ꗗ��No.25�̑Ή�</br>
    /// <br>Programmer : �A����</br>
    /// <br>Date       : 2013/06/14</br>
    /// <br>Note       : �\�[�X�`�F�b�N�m�F�����ꗗ��No.32�̑Ή�</br>
    /// <br>Programmer : �A����</br>
    /// <br>Date       : 2013/06/17</br>
    /// <br>Note       : ��10663 #43465 �^�u���b�g�S���ґΉ�</br>
    /// <br>Programmer : �g�� �F��</br>
    /// <br>Date       : 2014/10/03</br>
    /// <br>Update Note: </br>
	/// </remarks>
	[Serializable]
	public class PMEmployeeDB : RemoteDB , IPMEmployeeDB
	{
		/// <summary>
		/// PM�]�ƈ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Programmer : 22011�@Kashihara</br>
		/// <br>Date       : 2013.05.28</br>
		/// </remarks>
		public PMEmployeeDB() : base("SFTOK09394D","Broadleaf.Application.Remoting.ParamData.PMEmployeeWork", "PMEMPLOYEERF")
		{
		}

        /// <summary>
        /// �w�肳�ꂽPM�]�ƈ�Guid��PM�]�ƈ���߂��܂�
        /// </summary>
        /// <param name="parabyte">PMEmployeeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        public int Read(ref byte[] parabyte, int readMode)
        {
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = GetSCMConnection();
                if (sqlConnection == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                sqlConnection.Open();

                EmployeeWork pmemployeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));

                int status = ReadProc(ref pmemployeeWork, readMode, ref sqlConnection);
                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(pmemployeeWork);

                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMEmployeeDB.Read Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                DisposeSqlConnection(ref sqlConnection);
            }
        }

        /// <summary>
        /// �w�肳�ꂽPM�]�ƈ�Guid��PM�]�ƈ���߂��܂�
        /// </summary>
        /// <param name="parabyte">PMEmployeeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        public int Read(ref object parabyte, int readMode)
        {
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = GetSCMConnection();
                if (sqlConnection == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                sqlConnection.Open();

                EmployeeWork pmemployeeWork = parabyte as EmployeeWork;

                return ReadProc(ref pmemployeeWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMEmployeeDB.Read Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                DisposeSqlConnection(ref sqlConnection);
            }
        }

        /// <summary>
        /// �w�肳�ꂽPM�]�ƈ�Guid��PM�]�ƈ���߂��܂�
        /// </summary>
        /// <param name="parabyte">PMEmployeeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        public int Read(ref EmployeeWork parabyte, int readMode)
        {
            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = GetSCMConnection();
                if (sqlConnection == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                sqlConnection.Open();

                return ReadProc(ref parabyte, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMEmployeeDB.Read Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                DisposeSqlConnection(ref sqlConnection);
            }
        }

        /// <summary>
        /// �w�肳�ꂽPM�]�ƈ�Guid��PM�]�ƈ���߂��܂�
        /// </summary>
        /// <param name="pmemployeeWork">PMEmployeeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        public int Read(ref EmployeeWork pmemployeeWork, int readMode, ref SqlConnection sqlConnection)
        {
            try
            {
                return ReadProc(ref pmemployeeWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMEmployeeDB.Read Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }

        /// <summary>
        /// �w�肳�ꂽPM�]�ƈ�Guid��PM�]�ƈ���߂��܂�
        /// </summary>
        /// <param name="pmemployeeWork">PMEmployeeWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        private int ReadProc(ref EmployeeWork pmemployeeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("SELECT * FROM PMEMPLOYEERF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmemployeeWork.EnterpriseCode);

                //���O�C���h�c�������Ă�����
                if (pmemployeeWork.LoginId != "")
                {
                    sqlCommand.CommandText += "AND LOGINIDRF=@FINDLOGINID";
                    SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);
                    findParaLoginId.Value = SqlDataMediator.SqlSetString(pmemployeeWork.LoginId);
                }
                else
                {
                    sqlCommand.CommandText += "AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    SqlParameter findParaPMEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                    findParaPMEmployeecode.Value = SqlDataMediator.SqlSetString(pmemployeeWork.EmployeeCode);
                }

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read())
                {
                    pmemployeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    pmemployeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    pmemployeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    pmemployeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    pmemployeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    pmemployeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    pmemployeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    pmemployeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    pmemployeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    pmemployeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                    pmemployeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                    pmemployeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                    pmemployeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
                    pmemployeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
                    pmemployeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
                    pmemployeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
                    pmemployeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                    pmemployeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
                    pmemployeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                    pmemployeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
                    pmemployeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
                    pmemployeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
                    pmemployeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
                    pmemployeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
                    pmemployeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
                    pmemployeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
                    pmemployeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
                    pmemployeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
                    pmemployeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
                    pmemployeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
                    pmemployeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
                    pmemployeeWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// PM�]�ƈ�����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">PMEmployeeWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PM�]�ƈ�����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22011 Kashihara</br>
        /// <br>Date       : 2013.05.28</br>
        public int Write(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                sqlConnection = GetSCMConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                foreach (PMEmployeeWork pmemployeeWork in (ArrayList)paraobj)
                {
                    status = Write(pmemployeeWork, ref sqlConnection, ref sqlTransaction);
                    if (status != 0) break;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMEmployeeDB.Write:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // ���R�l�N�V�����j��
                if (sqlConnection.State == ConnectionState.Open)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        // ���R�~�b�gor���[���o�b�N
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            sqlTransaction.Commit();
                        else
                            sqlTransaction.Rollback();
                    }
                    DisposeSqlConnection(ref sqlConnection);
                }
            }
            return status;
        }

        /// <summary>
        /// PM�]�ƈ�����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="pmemployeeWork">pmemployeeWork</param>
        /// <param name="sqlConnection">Sql�ڑ����</param>
        /// <param name="sqlTransaction">��ݻ޸��ݏ��</param>
        /// <returns>STATUS</returns>
        private int Write(PMEmployeeWork pmemployeeWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, EMPLOYEECODERF FROM PMEMPLOYEERF WHERE (ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE) OR (ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGINIDRF=@FINDLOGINID)", sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterprisecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaEmployeecode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter findParaLoginId = sqlCommand.Parameters.Add("@FINDLOGINID", SqlDbType.NChar);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmemployeeWork.EnterpriseCode);
                findParaEmployeecode.Value = SqlDataMediator.SqlSetString(pmemployeeWork.EmployeeCode);
                findParaLoginId.Value = SqlDataMediator.SqlSetString(pmemployeeWork.LoginId);

                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                    if (_updateDateTime != pmemployeeWork.UpdateDateTime)
                    {
                        //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                        if (pmemployeeWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                        else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        myReader.Close();
                        return status;
                    }

                    sqlCommand.CommandText = "UPDATE PMEMPLOYEERF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , EMPLOYEECODERF=@EMPLOYEECODE , NAMERF=@NAME , KANARF=@KANA , SHORTNAMERF=@SHORTNAME , SEXCODERF=@SEXCODE , SEXNAMERF=@SEXNAME , BIRTHDAYRF=@BIRTHDAY , COMPANYTELNORF=@COMPANYTELNO , PORTABLETELNORF=@PORTABLETELNO , POSTCODERF=@POSTCODE , BUSINESSCODERF=@BUSINESSCODE , FRONTMECHACODERF=@FRONTMECHACODE , INOUTSIDECOMPANYCODERF=@INOUTSIDECOMPANYCODE , BELONGSECTIONCODERF=@BELONGSECTIONCODE , LVRRTCSTGENERALRF=@LVRRTCSTGENERAL , LVRRTCSTCARINSPECTRF=@LVRRTCSTCARINSPECT , LVRRTCSTBODYPAINTRF=@LVRRTCSTBODYPAINT , LVRRTCSTBODYREPAIRRF=@LVRRTCSTBODYREPAIR , LOGINIDRF=@LOGINID , LOGINPASSWORDRF=@LOGINPASSWORD , USERADMINFLAGRF=@USERADMINFLAG , ENTERCOMPANYDATERF=@ENTERCOMPANYDATE , RETIREMENTDATERF=@RETIREMENTDATE , DISPLAYORDERRF=@DISPLAYORDER WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                    //KEY�R�}���h���Đݒ�
                    findParaEnterprisecode.Value = SqlDataMediator.SqlSetString(pmemployeeWork.EnterpriseCode);
                    findParaEmployeecode.Value = SqlDataMediator.SqlSetString(pmemployeeWork.EmployeeCode);

                    // �t�@�C���w�b�_�̃Z�b�g
                    if (pmemployeeWork.FileHeaderGuid == Guid.Empty) pmemployeeWork.FileHeaderGuid = Guid.NewGuid();
                    if (string.IsNullOrEmpty(pmemployeeWork.UpdEmployeeCode)) pmemployeeWork.UpdEmployeeCode = "3100";
                    if (string.IsNullOrEmpty(pmemployeeWork.UpdAssemblyId1)) pmemployeeWork.UpdAssemblyId1 = "3100";
                    pmemployeeWork.UpdAssemblyId2 = "SFTOK09391R";
                    pmemployeeWork.UpdateDateTime = DateTime.Now;
                }
                else
                {
                    //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                    if (pmemployeeWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        myReader.Close();
                        return status;
                    }

                    //�V�K�쐬����SQL���𐶐�
                    sqlCommand.CommandText = "INSERT INTO PMEMPLOYEERF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, EMPLOYEECODERF, NAMERF, KANARF, SHORTNAMERF, SEXCODERF, SEXNAMERF, BIRTHDAYRF, COMPANYTELNORF, PORTABLETELNORF, POSTCODERF, BUSINESSCODERF, FRONTMECHACODERF, INOUTSIDECOMPANYCODERF, BELONGSECTIONCODERF, LVRRTCSTGENERALRF, LVRRTCSTCARINSPECTRF, LVRRTCSTBODYPAINTRF, LVRRTCSTBODYREPAIRRF, LOGINIDRF, LOGINPASSWORDRF, USERADMINFLAGRF, ENTERCOMPANYDATERF, RETIREMENTDATERF , DISPLAYORDERRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @EMPLOYEECODE, @NAME, @KANA, @SHORTNAME, @SEXCODE, @SEXNAME, @BIRTHDAY, @COMPANYTELNO, @PORTABLETELNO, @POSTCODE, @BUSINESSCODE, @FRONTMECHACODE, @INOUTSIDECOMPANYCODE, @BELONGSECTIONCODE, @LVRRTCSTGENERAL, @LVRRTCSTCARINSPECT, @LVRRTCSTBODYPAINT, @LVRRTCSTBODYREPAIR, @LOGINID, @LOGINPASSWORD, @USERADMINFLAG, @ENTERCOMPANYDATE, @RETIREMENTDATE, @DISPLAYORDER)";

                    // �t�@�C���w�b�_�̃Z�b�g
                    if (pmemployeeWork.FileHeaderGuid == Guid.Empty) pmemployeeWork.FileHeaderGuid = Guid.NewGuid();
                    if (string.IsNullOrEmpty(pmemployeeWork.UpdEmployeeCode)) pmemployeeWork.UpdEmployeeCode = "3100";
                    if (string.IsNullOrEmpty(pmemployeeWork.UpdAssemblyId1)) pmemployeeWork.UpdAssemblyId1 = "3100";
                    pmemployeeWork.UpdAssemblyId2 = "SFTOK09391R";
                    pmemployeeWork.CreateDateTime = DateTime.Now;
                    pmemployeeWork.UpdateDateTime = pmemployeeWork.CreateDateTime;
                }
                myReader.Close();

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreatedatetime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdatedatetime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterprisecode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileheaderguid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdemployeecode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdassemblyid1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdassemblyid2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicaldeletecode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraEmployeecode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                SqlParameter paraShortname = sqlCommand.Parameters.Add("@SHORTNAME", SqlDbType.NVarChar);
                SqlParameter paraSexcode = sqlCommand.Parameters.Add("@SEXCODE", SqlDbType.Int);
                SqlParameter paraSexname = sqlCommand.Parameters.Add("@SEXNAME", SqlDbType.NVarChar);
                SqlParameter paraBirthday = sqlCommand.Parameters.Add("@BIRTHDAY", SqlDbType.Int);
                SqlParameter paraCompanytelno = sqlCommand.Parameters.Add("@COMPANYTELNO", SqlDbType.NVarChar);
                SqlParameter paraPortabletelno = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                SqlParameter paraPostcode = sqlCommand.Parameters.Add("@POSTCODE", SqlDbType.Int);
                SqlParameter paraBusinesscode = sqlCommand.Parameters.Add("@BUSINESSCODE", SqlDbType.Int);
                SqlParameter paraFrontmechacode = sqlCommand.Parameters.Add("@FRONTMECHACODE", SqlDbType.Int);
                SqlParameter paraInoutsidecompanycode = sqlCommand.Parameters.Add("@INOUTSIDECOMPANYCODE", SqlDbType.Int);
                SqlParameter paraBelongsectioncode = sqlCommand.Parameters.Add("@BELONGSECTIONCODE", SqlDbType.NChar);
                SqlParameter paraLvrRtCstGeneral = sqlCommand.Parameters.Add("@LVRRTCSTGENERAL", SqlDbType.BigInt);
                SqlParameter paraLvrRtCstCarInspect = sqlCommand.Parameters.Add("@LVRRTCSTCARINSPECT", SqlDbType.BigInt);
                SqlParameter paraLvrRtCstBodyPaint = sqlCommand.Parameters.Add("@LVRRTCSTBODYPAINT", SqlDbType.BigInt);
                SqlParameter paraLvrRtCstBodyRepair = sqlCommand.Parameters.Add("@LVRRTCSTBODYREPAIR", SqlDbType.BigInt);
                SqlParameter paraLoginid = sqlCommand.Parameters.Add("@LOGINID", SqlDbType.NVarChar);
                SqlParameter paraLoginpassword = sqlCommand.Parameters.Add("@LOGINPASSWORD", SqlDbType.NVarChar);
                SqlParameter paraUserAdminFlag = sqlCommand.Parameters.Add("@USERADMINFLAG", SqlDbType.Int);
                SqlParameter paraEntercompanydate = sqlCommand.Parameters.Add("@ENTERCOMPANYDATE", SqlDbType.Int);
                SqlParameter paraRetirementdate = sqlCommand.Parameters.Add("@RETIREMENTDATE", SqlDbType.Int);
                SqlParameter paraDisplayorder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);


                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmemployeeWork.CreateDateTime);
                paraUpdatedatetime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmemployeeWork.UpdateDateTime);
                paraEnterprisecode.Value = SqlDataMediator.SqlSetString(pmemployeeWork.EnterpriseCode);
                paraFileheaderguid.Value = SqlDataMediator.SqlSetGuid(pmemployeeWork.FileHeaderGuid);
                paraUpdemployeecode.Value = SqlDataMediator.SqlSetString(pmemployeeWork.UpdEmployeeCode);
                paraUpdassemblyid1.Value = SqlDataMediator.SqlSetString(pmemployeeWork.UpdAssemblyId1);
                paraUpdassemblyid2.Value = SqlDataMediator.SqlSetString(pmemployeeWork.UpdAssemblyId2);
                paraLogicaldeletecode.Value = SqlDataMediator.SqlSetInt32(pmemployeeWork.LogicalDeleteCode);
                paraEmployeecode.Value = SqlDataMediator.SqlSetString(pmemployeeWork.EmployeeCode);
                paraName.Value = SqlDataMediator.SqlSetString(pmemployeeWork.Name);
                paraKana.Value = SqlDataMediator.SqlSetString(pmemployeeWork.Kana);
                paraShortname.Value = SqlDataMediator.SqlSetString(pmemployeeWork.ShortName);
                paraSexcode.Value = SqlDataMediator.SqlSetInt32(pmemployeeWork.SexCode);
                paraSexname.Value = SqlDataMediator.SqlSetString(pmemployeeWork.SexName);
                paraBirthday.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(pmemployeeWork.Birthday);
                paraCompanytelno.Value = SqlDataMediator.SqlSetString(pmemployeeWork.CompanyTelNo);
                paraPortabletelno.Value = SqlDataMediator.SqlSetString(pmemployeeWork.PortableTelNo);
                paraPostcode.Value = SqlDataMediator.SqlSetInt32(pmemployeeWork.PostCode);
                paraBusinesscode.Value = SqlDataMediator.SqlSetInt32(pmemployeeWork.BusinessCode);
                paraFrontmechacode.Value = SqlDataMediator.SqlSetInt32(pmemployeeWork.FrontMechaCode);
                paraInoutsidecompanycode.Value = SqlDataMediator.SqlSetInt32(pmemployeeWork.InOutsideCompanyCode);
                paraBelongsectioncode.Value = SqlDataMediator.SqlSetString(pmemployeeWork.BelongSectionCode);
                paraLvrRtCstGeneral.Value = SqlDataMediator.SqlSetInt64(pmemployeeWork.LvrRtCstGeneral);
                paraLvrRtCstCarInspect.Value = SqlDataMediator.SqlSetInt64(pmemployeeWork.LvrRtCstCarInspect);
                paraLvrRtCstBodyPaint.Value = SqlDataMediator.SqlSetInt64(pmemployeeWork.LvrRtCstBodyPaint);
                paraLvrRtCstBodyRepair.Value = SqlDataMediator.SqlSetInt64(pmemployeeWork.LvrRtCstBodyRepair);
                paraLoginid.Value = SqlDataMediator.SqlSetString(pmemployeeWork.LoginId);
                paraLoginpassword.Value = SqlDataMediator.SqlSetString(pmemployeeWork.LoginPassword);
                paraUserAdminFlag.Value = SqlDataMediator.SqlSetInt32(pmemployeeWork.UserAdminFlag);
                paraEntercompanydate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(pmemployeeWork.EnterCompanyDate);
                paraRetirementdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(pmemployeeWork.RetirementDate);
                paraDisplayorder.Value = SqlDataMediator.SqlSetInt32(pmemployeeWork.DisplayOrder);

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeDB.Write Exception = " + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        #region [2013/06/17 �\�[�X�`�F�b�N�m�F�����ꗗ��No.32  DELETE]
        //---DEL �A���� 2013/06/17 �\�[�X�`�F�b�N�m�F�����ꗗ��No.32�̑Ή�--->>>>>
        ////--ADD �A���� 2013/06/11 ����ꗗ_PM-TAB No.48--->>>>>
        ///// <summary>
        ///// �w�肳�ꂽ�����̋��_���LIST��S�Ė߂��܂�
        ///// </summary>
        ///// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
        ///// <param name="searchPara">��������</param>
        ///// <param name="readMode">�����敪</param>
        ///// <param name="logicalMode">�_���폜�敪</param>
        ///// <returns></returns>
        //public int Search(out object parabyte, PMEmployeeWork searchPara, int readMode, ConstantManagement.LogicalMode logicalMode)
        //{

        //    SqlConnection sqlConnection = null;
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    parabyte = null;
        //    try
        //    {
        //        ArrayList retList = null;

        //        sqlConnection = GetSCMConnection();
        //        if (sqlConnection == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //        sqlConnection.Open();

        //        status = this.SearchForTabletProc(out retList, searchPara, ref sqlConnection, readMode, logicalMode);
        //        parabyte = (object)retList;

        //        return status;
        //    }
        //    catch (Exception ex)
        //    {
        //        base.WriteErrorLog(ex, "PMEmployeeDB.Search Exception = " + ex.Message);
        //        parabyte = new ArrayList();
        //        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    }
        //    finally
        //    {
        //        DisposeSqlConnection(ref sqlConnection);
        //    }
        //}

        ///// <summary>
        ///// �w�肳�ꂽ�����̋��_���LIST��S�Ė߂��܂�
        ///// </summary>
        ///// <param name="retList">WorkerWork�I�u�W�F�N�g</param>
        ///// <param name="searchPara">��������</param>
        ///// <param name="sqlConnection">�R�l�N�V�������</param>
        ///// <param name="readMode">�����敪</param>
        ///// <param name="logicalMode">�_���폜�敪</param>
        ///// <returns></returns>
        //private int SearchForTabletProc(out ArrayList retList, PMEmployeeWork searchPara, ref SqlConnection sqlConnection, int readMode, ConstantManagement.LogicalMode logicalMode)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //    SqlDataReader myReader = null;
        //    SqlCommand sqlCommand = null;
        //    retList = null;

        //    ArrayList arrayList = new ArrayList();

        //    try
        //    {
        //        StringBuilder sqlText = new StringBuilder();

        //        # region [SELECT��]
        //        sqlText.Append("SELECT" + Environment.NewLine);
        //        sqlText.Append("    CREATEDATETIMERF" + Environment.NewLine);
        //        sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
        //        sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
        //        sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
        //        sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
        //        sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
        //        sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
        //        sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
        //        sqlText.Append("    ,EMPLOYEECODERF" + Environment.NewLine);
        //        sqlText.Append("    ,NAMERF" + Environment.NewLine);
        //        sqlText.Append("    ,KANARF" + Environment.NewLine);
        //        sqlText.Append("    ,SHORTNAMERF" + Environment.NewLine);
        //        sqlText.Append("    ,SEXCODERF" + Environment.NewLine);
        //        sqlText.Append("    ,SEXNAMERF" + Environment.NewLine);
        //        sqlText.Append("    ,BIRTHDAYRF" + Environment.NewLine);
        //        sqlText.Append("    ,COMPANYTELNORF" + Environment.NewLine);
        //        sqlText.Append("    ,PORTABLETELNORF" + Environment.NewLine);
        //        sqlText.Append("    ,POSTCODERF" + Environment.NewLine);
        //        sqlText.Append("    ,BUSINESSCODERF" + Environment.NewLine);
        //        sqlText.Append("    ,FRONTMECHACODERF" + Environment.NewLine);
        //        sqlText.Append("    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine);
        //        sqlText.Append("    ,BELONGSECTIONCODERF" + Environment.NewLine);
        //        sqlText.Append("    ,LVRRTCSTGENERALRF" + Environment.NewLine);
        //        sqlText.Append("    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine);
        //        sqlText.Append("    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine);
        //        sqlText.Append("    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine);
        //        sqlText.Append("    ,LOGINIDRF" + Environment.NewLine);
        //        sqlText.Append("    ,LOGINPASSWORDRF" + Environment.NewLine);
        //        sqlText.Append("    ,USERADMINFLAGRF" + Environment.NewLine);
        //        sqlText.Append("    ,ENTERCOMPANYDATERF" + Environment.NewLine);
        //        sqlText.Append("    ,RETIREMENTDATERF" + Environment.NewLine);
        //        sqlText.Append("    ,DISPLAYORDERRF" + Environment.NewLine);
        //        sqlText.Append("FROM" + Environment.NewLine);
        //        sqlText.Append("  PMEMPLOYEERF WITH (READUNCOMMITTED)" + Environment.NewLine);
        //        sqlText.Append("WHERE" + Environment.NewLine);
        //        sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
        //        // -----ADD �A���� 2013/06/14  �\�[�X�`�F�b�N�m�F�����ꗗ��No.25�̑Ή�----->>>>>
        //        // Select�R�}���h�̐���
        //        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);
        //        // -----ADD �A���� 2013/06/14  �\�[�X�`�F�b�N�m�F�����ꗗ��No.25�̑Ή�-----<<<<<
        //        //�_���폜�敪
        //        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
        //            (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
        //            (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
        //            (logicalMode == ConstantManagement.LogicalMode.GetData3))
        //        {
        //            sqlText.Append(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine);
        //        }
        //        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
        //            (logicalMode == ConstantManagement.LogicalMode.GetData012))
        //        {
        //            sqlText.Append(" AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine);
        //        }
        //        //�]�ƈ��R�[�h
        //        if (!string.IsNullOrEmpty(searchPara.EmployeeCode))
        //        {
        //            sqlText.Append(" AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine);
        //            SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
        //            findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(searchPara.EmployeeCode);
        //        }
        //        sqlText.Append(" ORDER BY EMPLOYEECODERF" + Environment.NewLine);
        //        # endregion

        //        // -----DEL �A���� 2013/06/14  �\�[�X�`�F�b�N�m�F�����ꗗ��No.25�̑Ή�----->>>>>
        //        //// Select�R�}���h�̐���
        //        //sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection); 
        //        // -----DEL �A���� 2013/06/14  �\�[�X�`�F�b�N�m�F�����ꗗ��No.25�̑Ή�-----<<<<<
        //        sqlCommand.CommandText = sqlText.ToString();  // ADD �A���� 2013/06/14  �\�[�X�`�F�b�N�m�F�����ꗗ��No.25�̑Ή�

        //        // Parameter�I�u�W�F�N�g�̍쐬
        //        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
        //        SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

        //        //Parameter�I�u�W�F�N�g�֒l�ݒ�
        //        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchPara.EnterpriseCode);
        //        findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)logicalMode);

        //        sqlCommand.CommandTimeout = 3600;
        //        myReader = sqlCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            PMEmployeeWork pmTabEmployeeWork = new PMEmployeeWork();
        //            this.ReaderToEmployeeWork(ref myReader, ref pmTabEmployeeWork);
        //            arrayList.Add(pmTabEmployeeWork);
        //        }
        //        retList = arrayList;
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (SqlException ex)
        //    {
        //        //���N���X�ɗ�O��n���ď������Ă��炤
        //        status = base.WriteSQLErrorLog(ex, "�]�ƈ��}�X�^�̃��[�J���V���N�p�f�[�^�̎擾�Ɏ��s���܂����B", ex.Number);
        //    }
        //    finally
        //    {
        //        if (myReader != null)
        //        {
        //            if (!myReader.IsClosed)
        //            {
        //                myReader.Close();
        //            }
        //            myReader.Dispose();
        //        }

        //        if (sqlCommand != null)
        //        {
        //            sqlCommand.Dispose();
        //        }
        //    }

        //    return status;

        //}

        ///// <summary>
        ///// �]�ƈ��}�X�^�̓Ǎ�����(SqlDataReader)���]�ƈ��}�X�^���[�N(PMEmployeeWork)�Ɋi�[���܂��B
        ///// </summary>
        ///// <param name="myReader">�]�ƈ��}�X�^�̓Ǎ�����</param>
        ///// <param name="pmTabEmployeeWork">�]�ƈ��}�X�^���[�N</param>
        ///// <br>Programmer : �A���� </br>
        ///// <br>Date       : 2013/05/29</br>
        //private void ReaderToEmployeeWork(ref SqlDataReader myReader, ref PMEmployeeWork pmTabEmployeeWork)
        //{
        //    if (myReader != null && pmTabEmployeeWork != null)
        //    {
        //        # region [�i�[����]
        //        pmTabEmployeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
        //        pmTabEmployeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
        //        pmTabEmployeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //        pmTabEmployeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //        pmTabEmployeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
        //        pmTabEmployeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
        //        pmTabEmployeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
        //        pmTabEmployeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
        //        pmTabEmployeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
        //        pmTabEmployeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
        //        pmTabEmployeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
        //        pmTabEmployeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
        //        pmTabEmployeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
        //        pmTabEmployeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
        //        pmTabEmployeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
        //        pmTabEmployeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
        //        pmTabEmployeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
        //        pmTabEmployeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
        //        pmTabEmployeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
        //        pmTabEmployeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
        //        pmTabEmployeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
        //        pmTabEmployeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
        //        pmTabEmployeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
        //        pmTabEmployeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
        //        pmTabEmployeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
        //        pmTabEmployeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
        //        pmTabEmployeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
        //        pmTabEmployeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
        //        pmTabEmployeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
        //        pmTabEmployeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
        //        pmTabEmployeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
        //        pmTabEmployeeWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));


        //        # endregion
        //    }
        //}
        ////--ADD �A���� 2013/06/11 ����ꗗ_PM-TAB No.48---<<<<<
        //---DEL �A���� 2013/06/17 �\�[�X�`�F�b�N�m�F�����ꗗ��No.32�̑Ή�---<<<<<
        #endregion [2013/06/17 �\�[�X�`�F�b�N�m�F�����ꗗ��No.32  DELETE]

        //---ADD �A���� 2013/06/17 �\�[�X�`�F�b�N�m�F�����ꗗ��No.32�̑Ή�--->>>>>
        /// <summary>
        /// PMTAB�]�ƈ������}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="pmTabEmployeeWorkList">pmTabEmployeeWorkList�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�]�ƈ������}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : �A���� </br>
        /// <br>Date       : 2013/06/17</br>
        public int WriteForTablet(ref object pmTabEmployeeWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pmTabEmployeeWorkList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.GetSCMConnection();

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.WriteForTabletProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMEmployeeDB.Write Exception = " + ex.Message);
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

                DisposeSqlConnection(ref sqlConnection);
            }

            return status;
        }

        /// <summary>
        /// PMTAB�]�ƈ������}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="pmTabEmployeeWorkList">pmTabEmployeeWorkList�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�]�ƈ������}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : �A���� </br>
        /// <br>Date       : 2013/06/17</br>
        private int WriteForTabletProc(ref ArrayList pmTabEmployeeWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pmTabEmployeeWorkList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < pmTabEmployeeWorkList.Count; i++)
                    {
                        PMEmployeeWork pmTabEmployeeWork = pmTabEmployeeWorkList[i] as PMEmployeeWork;

                        # region [SELECT��]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF" + Environment.NewLine);
                        sqlText.Append(" FROM PMEMPLOYEERF WITH (READUNCOMMITTED)" + Environment.NewLine);
                        sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                        sqlText.Append("    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine);
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.EnterpriseCode);
                        findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.EmployeeCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            # region [UPDATE��]
                            sqlText = new StringBuilder();
                            sqlText.Append("UPDATE PMEMPLOYEERF" + Environment.NewLine);
                            sqlText.Append(" SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine);
                            sqlText.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine);
                            sqlText.Append(" , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine);
                            sqlText.Append(" , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine);
                            sqlText.Append(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine);
                            sqlText.Append(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine);
                            sqlText.Append(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine);
                            sqlText.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine);
                            sqlText.Append(" , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine);
                            sqlText.Append(" , NAMERF=@NAME" + Environment.NewLine);
                            sqlText.Append(" , KANARF=@KANA" + Environment.NewLine);
                            sqlText.Append(" , SHORTNAMERF=@SHORTNAME" + Environment.NewLine);
                            sqlText.Append(" , SEXCODERF=@SEXCODE" + Environment.NewLine);
                            sqlText.Append(" , SEXNAMERF=@SEXNAME" + Environment.NewLine);
                            sqlText.Append(" , BIRTHDAYRF=@BIRTHDAY" + Environment.NewLine);
                            sqlText.Append(" , COMPANYTELNORF=@COMPANYTELNO" + Environment.NewLine);
                            sqlText.Append(" , PORTABLETELNORF=@PORTABLETELNO" + Environment.NewLine);
                            sqlText.Append(" , POSTCODERF=@POSTCODE" + Environment.NewLine);
                            sqlText.Append(" , BUSINESSCODERF=@BUSINESSCODE" + Environment.NewLine);
                            sqlText.Append(" , FRONTMECHACODERF=@FRONTMECHACODE" + Environment.NewLine);
                            sqlText.Append(" , INOUTSIDECOMPANYCODERF=@INOUTSIDECOMPANYCODE" + Environment.NewLine);
                            sqlText.Append(" , BELONGSECTIONCODERF=@BELONGSECTIONCODE" + Environment.NewLine);
                            sqlText.Append(" , LVRRTCSTGENERALRF=@LVRRTCSTGENERAL" + Environment.NewLine);
                            sqlText.Append(" , LVRRTCSTCARINSPECTRF=@LVRRTCSTCARINSPECT" + Environment.NewLine);
                            sqlText.Append(" , LVRRTCSTBODYPAINTRF=@LVRRTCSTBODYPAINT" + Environment.NewLine);
                            sqlText.Append(" , LVRRTCSTBODYREPAIRRF=@LVRRTCSTBODYREPAIR" + Environment.NewLine);
                            sqlText.Append(" , LOGINIDRF=@LOGINID" + Environment.NewLine);
                            sqlText.Append(" , LOGINPASSWORDRF=@LOGINPASSWORD" + Environment.NewLine);
                            sqlText.Append(" , USERADMINFLAGRF=@USERADMINFLAG" + Environment.NewLine);
                            sqlText.Append(" , ENTERCOMPANYDATERF=@ENTERCOMPANYDATE" + Environment.NewLine);
                            sqlText.Append(" , RETIREMENTDATERF=@RETIREMENTDATE" + Environment.NewLine);
                            sqlText.Append(" , DISPLAYORDERRF=@DISPLAYORDER" + Environment.NewLine);

                            sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                            sqlText.Append("    AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion


                            // Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.EnterpriseCode);
                            findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.EmployeeCode);

                        }
                        else
                        {
                            # region [INSERT��]
                            sqlText = new StringBuilder();
                            sqlText.Append("INSERT INTO PMEMPLOYEERF" + Environment.NewLine);
                            sqlText.Append(" (CREATEDATETIMERF" + Environment.NewLine);
                            sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                            sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                            sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                            sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                            sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                            sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                            sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                            sqlText.Append("    ,EMPLOYEECODERF" + Environment.NewLine);
                            sqlText.Append("    ,NAMERF" + Environment.NewLine);
                            sqlText.Append("    ,KANARF" + Environment.NewLine);
                            sqlText.Append("    ,SHORTNAMERF" + Environment.NewLine);
                            sqlText.Append("    ,SEXCODERF" + Environment.NewLine);
                            sqlText.Append("    ,SEXNAMERF" + Environment.NewLine);
                            sqlText.Append("    ,BIRTHDAYRF" + Environment.NewLine);
                            sqlText.Append("    ,COMPANYTELNORF" + Environment.NewLine);
                            sqlText.Append("    ,PORTABLETELNORF" + Environment.NewLine);
                            sqlText.Append("    ,POSTCODERF" + Environment.NewLine);
                            sqlText.Append("    ,BUSINESSCODERF" + Environment.NewLine);
                            sqlText.Append("    ,FRONTMECHACODERF" + Environment.NewLine);
                            sqlText.Append("    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine);
                            sqlText.Append("    ,BELONGSECTIONCODERF" + Environment.NewLine);
                            sqlText.Append("    ,LVRRTCSTGENERALRF" + Environment.NewLine);
                            sqlText.Append("    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine);
                            sqlText.Append("    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine);
                            sqlText.Append("    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine);
                            sqlText.Append("    ,LOGINIDRF" + Environment.NewLine);
                            sqlText.Append("    ,LOGINPASSWORDRF" + Environment.NewLine);
                            sqlText.Append("    ,USERADMINFLAGRF" + Environment.NewLine);
                            sqlText.Append("    ,ENTERCOMPANYDATERF" + Environment.NewLine);
                            sqlText.Append("    ,RETIREMENTDATERF" + Environment.NewLine);
                            sqlText.Append("    ,DISPLAYORDERRF" + Environment.NewLine);
                            sqlText.Append(" )" + Environment.NewLine);
                            sqlText.Append(" VALUES" + Environment.NewLine);
                            sqlText.Append(" (@CREATEDATETIME" + Environment.NewLine);
                            sqlText.Append("    ,@UPDATEDATETIME" + Environment.NewLine);
                            sqlText.Append("    ,@ENTERPRISECODE" + Environment.NewLine);
                            sqlText.Append("    ,@FILEHEADERGUID" + Environment.NewLine);
                            sqlText.Append("    ,@UPDEMPLOYEECODE" + Environment.NewLine);
                            sqlText.Append("    ,@UPDASSEMBLYID1" + Environment.NewLine);
                            sqlText.Append("    ,@UPDASSEMBLYID2" + Environment.NewLine);
                            sqlText.Append("    ,@LOGICALDELETECODE" + Environment.NewLine);
                            sqlText.Append("    ,@EMPLOYEECODE" + Environment.NewLine);
                            sqlText.Append("    ,@NAME" + Environment.NewLine);
                            sqlText.Append("    ,@KANA" + Environment.NewLine);
                            sqlText.Append("    ,@SHORTNAME" + Environment.NewLine);
                            sqlText.Append("    ,@SEXCODE" + Environment.NewLine);
                            sqlText.Append("    ,@SEXNAME" + Environment.NewLine);
                            sqlText.Append("    ,@BIRTHDAY" + Environment.NewLine);
                            sqlText.Append("    ,@COMPANYTELNO" + Environment.NewLine);
                            sqlText.Append("    ,@PORTABLETELNO" + Environment.NewLine);
                            sqlText.Append("    ,@POSTCODE" + Environment.NewLine);
                            sqlText.Append("    ,@BUSINESSCODE" + Environment.NewLine);
                            sqlText.Append("    ,@FRONTMECHACODE" + Environment.NewLine);
                            sqlText.Append("    ,@INOUTSIDECOMPANYCODE" + Environment.NewLine);
                            sqlText.Append("    ,@BELONGSECTIONCODE" + Environment.NewLine);
                            sqlText.Append("    ,@LVRRTCSTGENERAL" + Environment.NewLine);
                            sqlText.Append("    ,@LVRRTCSTCARINSPECT" + Environment.NewLine);
                            sqlText.Append("    ,@LVRRTCSTBODYPAINT" + Environment.NewLine);
                            sqlText.Append("    ,@LVRRTCSTBODYREPAIR" + Environment.NewLine);
                            sqlText.Append("    ,@LOGINID" + Environment.NewLine);
                            sqlText.Append("    ,@LOGINPASSWORD" + Environment.NewLine);
                            sqlText.Append("    ,@USERADMINFLAG" + Environment.NewLine);
                            sqlText.Append("    ,@ENTERCOMPANYDATE" + Environment.NewLine);
                            sqlText.Append("    ,@RETIREMENTDATE" + Environment.NewLine);
                            sqlText.Append("    ,@DISPLAYORDER" + Environment.NewLine);
                            sqlText.Append(" )" + Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraName = sqlCommand.Parameters.Add("@NAME", SqlDbType.NVarChar);
                        SqlParameter paraKana = sqlCommand.Parameters.Add("@KANA", SqlDbType.NVarChar);
                        SqlParameter paraShortName = sqlCommand.Parameters.Add("@SHORTNAME", SqlDbType.NVarChar);
                        SqlParameter paraSexCode = sqlCommand.Parameters.Add("@SEXCODE", SqlDbType.Int);
                        SqlParameter paraSexName = sqlCommand.Parameters.Add("@SEXNAME", SqlDbType.NVarChar);
                        SqlParameter paraBirthday = sqlCommand.Parameters.Add("@BIRTHDAY", SqlDbType.Int);
                        SqlParameter paraCompanyTelNo = sqlCommand.Parameters.Add("@COMPANYTELNO", SqlDbType.NVarChar);
                        SqlParameter paraPortableTelNo = sqlCommand.Parameters.Add("@PORTABLETELNO", SqlDbType.NVarChar);
                        SqlParameter paraPostCode = sqlCommand.Parameters.Add("@POSTCODE", SqlDbType.Int);
                        SqlParameter paraBusinessCode = sqlCommand.Parameters.Add("@BUSINESSCODE", SqlDbType.Int);
                        SqlParameter paraFrontMechaCode = sqlCommand.Parameters.Add("@FRONTMECHACODE", SqlDbType.Int);
                        SqlParameter paraInOutsideCompanyCode = sqlCommand.Parameters.Add("@INOUTSIDECOMPANYCODE", SqlDbType.Int);
                        SqlParameter paraBelongSectionCode = sqlCommand.Parameters.Add("@BELONGSECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraLvrRtCstGeneral = sqlCommand.Parameters.Add("@LVRRTCSTGENERAL", SqlDbType.BigInt);
                        SqlParameter paraLvrRtCstCarInspect = sqlCommand.Parameters.Add("@LVRRTCSTCARINSPECT", SqlDbType.BigInt);
                        SqlParameter paraLvrRtCstBodyPaint = sqlCommand.Parameters.Add("@LVRRTCSTBODYPAINT", SqlDbType.BigInt);
                        SqlParameter paraLvrRtCstBodyRepair = sqlCommand.Parameters.Add("@LVRRTCSTBODYREPAIR", SqlDbType.BigInt);
                        SqlParameter paraLoginId = sqlCommand.Parameters.Add("@LOGINID", SqlDbType.NVarChar);
                        SqlParameter paraLoginPassword = sqlCommand.Parameters.Add("@LOGINPASSWORD", SqlDbType.NVarChar);
                        SqlParameter paraUserAdminFlag = sqlCommand.Parameters.Add("@USERADMINFLAG", SqlDbType.Int);
                        SqlParameter paraEnterCompanyDate = sqlCommand.Parameters.Add("@ENTERCOMPANYDATE", SqlDbType.Int);
                        SqlParameter paraRetirementDate = sqlCommand.Parameters.Add("@RETIREMENTDATE", SqlDbType.Int);
                        SqlParameter paraDisplayOrder = sqlCommand.Parameters.Add("@DISPLAYORDER", SqlDbType.Int);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabEmployeeWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabEmployeeWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmTabEmployeeWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabEmployeeWork.LogicalDeleteCode);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.EmployeeCode);
                        paraName.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.Name);
                        paraKana.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.Kana);
                        paraShortName.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.ShortName);
                        paraSexCode.Value = SqlDataMediator.SqlSetInt32(pmTabEmployeeWork.SexCode);
                        paraSexName.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.SexName);
                        if (pmTabEmployeeWork.Birthday == DateTime.MinValue)
                        {
                            paraBirthday.Value = DBNull.Value;

                        }
                        else
                        {
                            paraBirthday.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(pmTabEmployeeWork.Birthday);
                        }

                        paraCompanyTelNo.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.CompanyTelNo);
                        paraPortableTelNo.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.PortableTelNo);
                        paraPostCode.Value = SqlDataMediator.SqlSetInt32(pmTabEmployeeWork.PostCode);
                        paraBusinessCode.Value = SqlDataMediator.SqlSetInt32(pmTabEmployeeWork.BusinessCode);
                        paraFrontMechaCode.Value = SqlDataMediator.SqlSetInt32(pmTabEmployeeWork.FrontMechaCode);
                        paraInOutsideCompanyCode.Value = SqlDataMediator.SqlSetInt32(pmTabEmployeeWork.InOutsideCompanyCode);
                        paraBelongSectionCode.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.BelongSectionCode);
                        paraLvrRtCstGeneral.Value = SqlDataMediator.SqlSetInt64(pmTabEmployeeWork.LvrRtCstGeneral);
                        paraLvrRtCstCarInspect.Value = SqlDataMediator.SqlSetInt64(pmTabEmployeeWork.LvrRtCstCarInspect);
                        paraLvrRtCstBodyPaint.Value = SqlDataMediator.SqlSetInt64(pmTabEmployeeWork.LvrRtCstBodyPaint);
                        paraLvrRtCstBodyRepair.Value = SqlDataMediator.SqlSetInt64(pmTabEmployeeWork.LvrRtCstBodyRepair);
                        paraLoginId.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.LoginId);
                        paraLoginPassword.Value = SqlDataMediator.SqlSetString(pmTabEmployeeWork.LoginPassword);
                        paraUserAdminFlag.Value = SqlDataMediator.SqlSetInt32(pmTabEmployeeWork.UserAdminFlag);
                        paraEnterCompanyDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(pmTabEmployeeWork.EnterCompanyDate);
                        paraRetirementDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(pmTabEmployeeWork.RetirementDate);
                        paraDisplayOrder.Value = SqlDataMediator.SqlSetInt32(pmTabEmployeeWork.DisplayOrder);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pmTabEmployeeWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "PMEmployeeDB.Write:" + ex.Message);
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

            pmTabEmployeeWorkList = al;

            return status;
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : �A���� </br>
        /// <br>Date       : 2013/06/17</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        //---ADD �A���� 2013/06/17 �\�[�X�`�F�b�N�m�F�����ꗗ��No.32�̑Ή�---<<<<<

        /// <summary>
        /// SQL�T�[�o�[�ڑ����擾����
        /// </summary>
        /// <returns>SqlConnection�N���X</returns>
        /// <remarks>
        /// <br>Note		: SQL�T�[�o�[�ւ̐ڑ������擾���܂��B</br>
        /// </remarks>
        private SqlConnection GetSCMConnection()
        {
            SCMSqlConnection scmSqlConnection = new SCMSqlConnection();
			return scmSqlConnection.GetSqlConnection(0);
        }

        /// <summary>
        /// SQL�R�l�N�V������j�����܂�
        /// </summary>
        /// <param name="sqlConnection">�j���Ώۂ�SQL�R�l�N�V����</param>
        private void DisposeSqlConnection(ref SqlConnection sqlConnection)
        {
            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }



        // ADD 2014/10/03 ��10663 #43465 �^�u���b�g�S���ґΉ� ---------------------------->>>>>>>>>>>>>>>>>>>>>
        #region [SearchForTablet]
        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        public int SearchForTablet(out object retObj, object paraObj, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retObj = null;

            SqlConnection sqlConnection = null;

            try
            {
                sqlConnection = GetSCMConnection();
                if (sqlConnection == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                sqlConnection.Open();

                ArrayList retList = null;
                PMEmployeeWork employeeSearchParaWork = null;
                employeeSearchParaWork = (PMEmployeeWork)paraObj;

                status = this.SearchForTabletProc(out retList, employeeSearchParaWork, ref sqlConnection, logicalMode);

                retObj = (object)retList;

                return status;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMTabEmployeeDB.SearchForTablet");
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
        /// �w�肳�ꂽ�����̏]�ƈ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="employeeSearchParaWork"></param>
        /// <param name="sqlConnection"></param>
        /// <param name="logicalMode"></param>
        /// <returns></returns>
        private int SearchForTabletProc(out ArrayList retList, PMEmployeeWork employeeSearchParaWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retList = null;

            // �epublic���\�b�h�̊J�n���ɃR�l�N�V������������擾
            // ���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
            if (connectionText == null || connectionText == "")
                return status;

            ArrayList arrayList = new ArrayList();

            try
            {
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                StringBuilder sqlText = new StringBuilder();
                // Select�R�}���h�̐���
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT��]
                sqlText.Append("SELECT" + Environment.NewLine);
                sqlText.Append("    CREATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                sqlText.Append("    ,EMPLOYEECODERF" + Environment.NewLine);
                sqlText.Append("    ,NAMERF" + Environment.NewLine);
                sqlText.Append("    ,KANARF" + Environment.NewLine);
                sqlText.Append("    ,SHORTNAMERF" + Environment.NewLine);
                sqlText.Append("    ,SEXCODERF" + Environment.NewLine);
                sqlText.Append("    ,SEXNAMERF" + Environment.NewLine);
                sqlText.Append("    ,BIRTHDAYRF" + Environment.NewLine);
                sqlText.Append("    ,COMPANYTELNORF" + Environment.NewLine);
                sqlText.Append("    ,PORTABLETELNORF" + Environment.NewLine);
                sqlText.Append("    ,POSTCODERF" + Environment.NewLine);
                sqlText.Append("    ,BUSINESSCODERF" + Environment.NewLine);
                sqlText.Append("    ,FRONTMECHACODERF" + Environment.NewLine);
                sqlText.Append("    ,INOUTSIDECOMPANYCODERF" + Environment.NewLine);
                sqlText.Append("    ,BELONGSECTIONCODERF" + Environment.NewLine);
                sqlText.Append("    ,LVRRTCSTGENERALRF" + Environment.NewLine);
                sqlText.Append("    ,LVRRTCSTCARINSPECTRF" + Environment.NewLine);
                sqlText.Append("    ,LVRRTCSTBODYPAINTRF" + Environment.NewLine);
                sqlText.Append("    ,LVRRTCSTBODYREPAIRRF" + Environment.NewLine);
                sqlText.Append("    ,LOGINIDRF" + Environment.NewLine);
                sqlText.Append("    ,LOGINPASSWORDRF" + Environment.NewLine);
                sqlText.Append("    ,USERADMINFLAGRF" + Environment.NewLine);
                sqlText.Append("    ,ENTERCOMPANYDATERF" + Environment.NewLine);
                sqlText.Append("    ,RETIREMENTDATERF" + Environment.NewLine);
                sqlText.Append("    ,DISPLAYORDERRF" + Environment.NewLine);
                sqlText.Append("FROM" + Environment.NewLine);
                sqlText.Append("  PMEMPLOYEERF WITH (READUNCOMMITTED)" + Environment.NewLine);
                sqlText.Append("WHERE" + Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine);
                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlText.Append(" AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlText.Append(" AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine);
                }
                //�]�ƈ��R�[�h
                if (!string.IsNullOrEmpty(employeeSearchParaWork.EmployeeCode))
                {
                    sqlText.Append(" AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine);
                    SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                    findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeSearchParaWork.EmployeeCode);
                }
                sqlText.Append(" ORDER BY EMPLOYEECODERF" + Environment.NewLine);
                # endregion

                // Select�R�}���h�̐���
                sqlCommand.CommandText = sqlText.ToString();

                // Parameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeSearchParaWork.EnterpriseCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(employeeSearchParaWork.LogicalDeleteCode);

                sqlCommand.CommandTimeout = 3600;
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    PMEmployeeWork pmTabEmployeeWork = new PMEmployeeWork();
                    this.ReaderToEmployeeWork(ref myReader, ref pmTabEmployeeWork);
                    arrayList.Add(pmTabEmployeeWork);
                }
                retList = arrayList;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex, "�]�ƈ��}�X�^�̃��[�J���V���N�p�f�[�^�̎擾�Ɏ��s���܂����B", ex.Number);
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

        /// <summary>
        /// �]�ƈ��}�X�^�̓Ǎ�����(SqlDataReader)���]�ƈ��}�X�^���[�N(PMEmployeeWork)�Ɋi�[���܂��B
        /// </summary>
        /// <param name="myReader">�]�ƈ��}�X�^�̓Ǎ�����</param>
        /// <param name="pmTabEmployeeWork">�]�ƈ��}�X�^���[�N</param>
        private void ReaderToEmployeeWork(ref SqlDataReader myReader, ref PMEmployeeWork pmTabEmployeeWork)
        {
            if (myReader != null && pmTabEmployeeWork != null)
            {
                # region [�i�[����]
                pmTabEmployeeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                pmTabEmployeeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                pmTabEmployeeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                pmTabEmployeeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                pmTabEmployeeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                pmTabEmployeeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                pmTabEmployeeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                pmTabEmployeeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                pmTabEmployeeWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                pmTabEmployeeWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
                pmTabEmployeeWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
                pmTabEmployeeWork.ShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHORTNAMERF"));
                pmTabEmployeeWork.SexCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEXCODERF"));
                pmTabEmployeeWork.SexName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEXNAMERF"));
                pmTabEmployeeWork.Birthday = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("BIRTHDAYRF"));
                pmTabEmployeeWork.CompanyTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMPANYTELNORF"));
                pmTabEmployeeWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
                pmTabEmployeeWork.PostCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSTCODERF"));
                pmTabEmployeeWork.BusinessCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSCODERF"));
                pmTabEmployeeWork.FrontMechaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRONTMECHACODERF"));
                pmTabEmployeeWork.InOutsideCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INOUTSIDECOMPANYCODERF"));
                pmTabEmployeeWork.BelongSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BELONGSECTIONCODERF"));
                pmTabEmployeeWork.LvrRtCstGeneral = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTGENERALRF"));
                pmTabEmployeeWork.LvrRtCstCarInspect = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTCARINSPECTRF"));
                pmTabEmployeeWork.LvrRtCstBodyPaint = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYPAINTRF"));
                pmTabEmployeeWork.LvrRtCstBodyRepair = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LVRRTCSTBODYREPAIRRF"));
                pmTabEmployeeWork.LoginId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINIDRF"));
                pmTabEmployeeWork.LoginPassword = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LOGINPASSWORDRF"));
                pmTabEmployeeWork.UserAdminFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERADMINFLAGRF"));
                pmTabEmployeeWork.EnterCompanyDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ENTERCOMPANYDATERF"));
                pmTabEmployeeWork.RetirementDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RETIREMENTDATERF"));
                pmTabEmployeeWork.DisplayOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DISPLAYORDERRF"));


                # endregion
            }
        }
        #endregion
        // ADD 2014/10/03 ��10663 #43465 �^�u���b�g�S���ґΉ� ----------------------------<<<<<<<<<<<<<<<<<<<<<<<<
    }
}
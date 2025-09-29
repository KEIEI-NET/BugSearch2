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
    /// ���i�S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�S�̐ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 3H �k�P�N</br>
    /// <br>Date       : K2017/06/02</br>
    /// </remarks>
    [Serializable]
    public class InspectTtlStDB : RemoteDB, IInspectTtlStDB
    {
        /// <summary>
        /// ���i�S�̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        public InspectTtlStDB()
            :
            base("PMHND09116D", "Broadleaf.Application.Remoting.ParamData.InspectTtlStWork", "INSPECTTTLSTRF")
        {
        }

        private const string _allSecCode = "00";

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="inspectTtlStWork">��������</param>
        /// <param name="parainspectTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int Search(out object inspectTtlStWork, object parainspectTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            inspectTtlStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchInspectTtlStProc(out inspectTtlStWork, parainspectTtlStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InspectTtlStDB.Search");
                inspectTtlStWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objinspectTtlStWork">��������</param>
        /// <param name="parainspectTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int SearchInspectTtlStProc(out object objinspectTtlStWork, object parainspectTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            InspectTtlStWork inspectTtlStWork = null; 

            ArrayList inspectTtlStWorkList = parainspectTtlStWork as ArrayList;
            if (inspectTtlStWorkList == null)
            {
                inspectTtlStWork = parainspectTtlStWork as InspectTtlStWork;
            }
            else
            {
                if (inspectTtlStWorkList.Count > 0)
                    inspectTtlStWork = inspectTtlStWorkList[0] as InspectTtlStWork;
            }

            int status = SearchInspectTtlStProc(out inspectTtlStWorkList, inspectTtlStWork, readMode, logicalMode, ref sqlConnection);
            objinspectTtlStWork = inspectTtlStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inspectTtlStWorkList">��������</param>
        /// <param name="inspectTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int SearchInspectTtlStProc(out ArrayList inspectTtlStWorkList, InspectTtlStWork inspectTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchInspectTtlStProcProc(out inspectTtlStWorkList, inspectTtlStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inspectTtlStWorkList">��������</param>
        /// <param name="inspectTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        private int SearchInspectTtlStProcProc(out ArrayList inspectTtlStWorkList, InspectTtlStWork inspectTtlStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("SELECT INT.* , SEC.SECTIONGUIDENMRF FROM INSPECTTTLSTRF AS INT LEFT JOIN SECINFOSETRF AS SEC ON INT.ENTERPRISECODERF=SEC.ENTERPRISECODERF AND INT.SECTIONCODERF=SEC.SECTIONCODERF ", sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, inspectTtlStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToInspectTtlStWorkFromReader(ref myReader));

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
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }
            inspectTtlStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            try
            {
                InspectTtlStWork inspectTtlStWork = new InspectTtlStWork();

                // XML�̓ǂݍ���
                inspectTtlStWork = (InspectTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(InspectTtlStWork));
                if (inspectTtlStWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref inspectTtlStWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(inspectTtlStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InspectTtlStDB.Read");
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
        /// �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inspectTtlStWork">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int ReadProc(ref InspectTtlStWork inspectTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref inspectTtlStWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="inspectTtlStWork">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌��i�S�̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        private int ReadProcProc(ref InspectTtlStWork inspectTtlStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                SqlDataReader myReader = null;

                try
                {
                    //Select�R�}���h�̐���
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT INT.* ,SEC.SECTIONGUIDENMRF FROM INSPECTTTLSTRF AS INT "
                                                                   + "LEFT JOIN SECINFOSETRF AS SEC "
                                                                   + "ON "
                                                                   + "INT.ENTERPRISECODERF=SEC.ENTERPRISECODERF "
                                                                   +"AND INT.SECTIONCODERF=SEC.SECTIONCODERF "
                                                                   + "WHERE INT.ENTERPRISECODERF=@FINDENTERPRISECODE AND INT.SECTIONCODERF=@FINDSECTIONCODE", sqlConnection))
                    {

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        inspectTtlStWork = CopyToInspectTtlStWorkFromReader(ref myReader);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
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
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// ���i�S�̐ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="inspectTtlStWork">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int Write(ref object inspectTtlStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(inspectTtlStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteInspectTtlStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                inspectTtlStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InspectTtlStDB.Write(ref object inspectTtlStWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
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
        /// ���i�S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inspectTtlStWorkList">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int WriteInspectTtlStProc(ref ArrayList inspectTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
            return this.WriteInspectTtlStProcProc(ref inspectTtlStWorkList, ref sqlConnection, ref sqlTransaction);
		}

        /// <summary>
        /// ���i�S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inspectTtlStWorkList">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        private int WriteInspectTtlStProcProc(ref ArrayList inspectTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (inspectTtlStWorkList != null)
                {
                    for (int i = 0; i < inspectTtlStWorkList.Count; i++)
                    {
                        InspectTtlStWork inspectTtlStWork = inspectTtlStWorkList[i] as InspectTtlStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM INSPECTTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != inspectTtlStWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (inspectTtlStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            sqlCommand.CommandText = "UPDATE INSPECTTTLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , ORDERINSPECTCODERF=@ORDERINSPECTCODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.SectionCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)inspectTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (inspectTtlStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = "INSERT INTO INSPECTTTLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, ORDERINSPECTCODERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @ORDERINSPECTCODE)";


                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)inspectTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

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
                        SqlParameter paraOrderInspectCode = sqlCommand.Parameters.Add("@ORDERINSPECTCODE",SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inspectTtlStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inspectTtlStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(inspectTtlStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inspectTtlStWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.SectionCode);
                        paraOrderInspectCode.Value = SqlDataMediator.SqlSetInt32(inspectTtlStWork.OrderInspectCode);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(inspectTtlStWork);
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
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            inspectTtlStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// ���i�S�̐ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="inspectTtlStWork">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int LogicalDelete(ref object inspectTtlStWork)
        {
            return LogicalDeleteInspectTtlSt(ref inspectTtlStWork, 0);
        }

        /// <summary>
        /// �_���폜���i�S�̐ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="inspectTtlStWork">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i�S�̐ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int RevivalLogicalDelete(ref object inspectTtlStWork)
        {
            return LogicalDeleteInspectTtlSt(ref inspectTtlStWork, 1);
        }

        /// <summary>
        /// ���i�S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="inspectTtlStWork">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        private int LogicalDeleteInspectTtlSt(ref object inspectTtlStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(inspectTtlStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteInspectTtlStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
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
                base.WriteErrorLog(ex, "InspectTtlStDB.LogicalDeleteInspectTtlSt :" + procModestr);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
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
        /// ���i�S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inspectTtlStWorkList">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int LogicalDeleteInspectTtlStProc(ref ArrayList inspectTtlStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteInspectTtlStProcProc(ref inspectTtlStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="inspectTtlStWorkList">InspectTtlStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        private int LogicalDeleteInspectTtlStProcProc(ref ArrayList inspectTtlStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (inspectTtlStWorkList != null)
                {
                    for (int i = 0; i < inspectTtlStWorkList.Count; i++)
                    {
                        InspectTtlStWork inspectTtlStWork = inspectTtlStWorkList[i] as InspectTtlStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM INSPECTTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != inspectTtlStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE INSPECTTTLSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.SectionCode);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)inspectTtlStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) inspectTtlStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else inspectTtlStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) inspectTtlStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                                sqlCommand.Cancel();
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(inspectTtlStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(inspectTtlStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(inspectTtlStWork);
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
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            inspectTtlStWorkList = al;

            return status;
        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ���i�S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">���i�S�̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteInspectTtlStProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "InspectTtlStDB.Delete");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
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
        /// ���i�S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="inspectTtlStWorkList">���i�S�̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        public int DeleteInspectTtlStProc(ArrayList inspectTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteInspectTtlStProcProc(inspectTtlStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i�S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="inspectTtlStWorkList">���i�S�̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���i�S�̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        private int DeleteInspectTtlStProcProc(ArrayList inspectTtlStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < inspectTtlStWorkList.Count; i++)
                {
                    InspectTtlStWork inspectTtlStWork = inspectTtlStWorkList[i] as InspectTtlStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM INSPECTTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.SectionCode);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != inspectTtlStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM INSPECTTTLSTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.SectionCode);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();                    
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
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
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
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
	    /// <param name="inspectTtlStWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, InspectTtlStWork inspectTtlStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
		    retstring += "INT.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.EnterpriseCode);

            //���_�R�[�h
            if (string.IsNullOrEmpty(inspectTtlStWork.SectionCode) == false)
            {
                retstring += "AND INT.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(inspectTtlStWork.SectionCode);
            }
            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
			    wkstring = "AND INT.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
            }
            else if    (    (logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "AND INT.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
            }
            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� InspectTtlStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>InspectTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private InspectTtlStWork CopyToInspectTtlStWorkFromReader(ref SqlDataReader myReader)
        {
            InspectTtlStWork wkInspectTtlStWork = new InspectTtlStWork();

            #region �N���X�֊i�[
            wkInspectTtlStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkInspectTtlStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkInspectTtlStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkInspectTtlStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkInspectTtlStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkInspectTtlStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkInspectTtlStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkInspectTtlStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkInspectTtlStWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkInspectTtlStWork.OrderInspectCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERINSPECTCODERF"));
            #endregion

            return wkInspectTtlStWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            InspectTtlStWork[] InspectTtlStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is InspectTtlStWork)
                    {
                        InspectTtlStWork wkInspectTtlStWork = paraobj as InspectTtlStWork;
                        if (wkInspectTtlStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkInspectTtlStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            InspectTtlStWorkArray = (InspectTtlStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(InspectTtlStWork[]));
                        }
                        catch (Exception) { }
                        if (InspectTtlStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(InspectTtlStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                InspectTtlStWork wkInspectTtlStWork = (InspectTtlStWork)XmlByteSerializer.Deserialize(byteArray, typeof(InspectTtlStWork));
                                if (wkInspectTtlStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkInspectTtlStWork);
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
        /// <br>Programmer : 3H �k�P�N</br>
        /// <br>Date       : K2017/06/02</br>
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

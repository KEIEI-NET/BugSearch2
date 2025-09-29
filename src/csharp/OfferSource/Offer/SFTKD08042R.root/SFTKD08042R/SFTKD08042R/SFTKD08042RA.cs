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
using System.Diagnostics;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���[�U�[�K�C�hDB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�U�[�K�C�h�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    [Serializable]
    public class UserGdBdDB : RemoteDB, IUserGdBdDB
    {
        /// <summary>
        /// ���[�U�[�K�C�hDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        /// </remarks>
        public UserGdBdDB()
            :
            base("SFTKD08044D", "Broadleaf.Application.Remoting.ParamData.UserGdBdWork", "USERGDBDURF")
        {
            Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            Debug.WriteLine(this.ToString() + " Constructer");
        }

        #region �K�C�h�w�b�_�[�p���\�b�h
        /// <summary>
        /// ���[�U�[�K�C�h�w�b�_�[LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�}�X�^�̂̃K�C�hLIST��S�Ė߂��܂��B</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        /// </remarks>
        public int SearchHeader(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            return SearchGuideHeaderProc(out retobj, paraobj, readMode, logicalMode);
        }

        /// <summary>
        /// ���[�U�[�K�C�h�w�b�_�[LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�}�X�^�̂̃K�C�hLIST��S�Ė߂��܂��B</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        /// </remarks>
        private int SearchGuideHeaderProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            UserGdHdWork usergdhdWork = new UserGdHdWork();
            usergdhdWork = null;

            retobj = null;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                usergdhdWork = paraobj as UserGdHdWork;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDHDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDHDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDHDRF WHERE ORDER BY USERGUIDEDIVCDRF", sqlConnection);
                }

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                while (myReader.Read())
                {
                    UserGdHdWork wkUserGdHdWork = new UserGdHdWork();

                    wkUserGdHdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUserGdHdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUserGdHdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUserGdHdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    wkUserGdHdWork.UserGuideDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("USERGUIDEDIVNMRF"));
                    wkUserGdHdWork.MasterOfferCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MASTEROFFERCDRF"));

                    al.Add(wkUserGdHdWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchGuideHeaderProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            retobj = al;

            return status;
        }

        #endregion

        #region ���[�U�[�K�C�h�}�X�^(��)
        /// <summary>
        /// ���[�U�[�K�C�h�{�f�B(�񋟕�)LIST�̌�����߂��܂�
        /// </summary>
        /// <param name="retCnt">�Y���f�[�^����</param>
        /// <param name="parabyte">�����p�����[�^(readMode=0:UserGdBdWork�N���X�F��ƃR�[�h)</param>		
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST�̌�����߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        public int SearchCnt(out int retCnt, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;

            UserGdBdWork usergdbdWork = null;

            retCnt = 0;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                usergdbdWork = (UserGdBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(UserGdBdWork));

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                    //�_���폜�敪�ݒ�
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                    //�_���폜�敪�ݒ�
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF", sqlConnection);
                }

                //�f�[�^���[�h
                retCnt = (int)sqlCommand.ExecuteScalar();
                if (retCnt > 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchCnt:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�{�f�B(�񋟕�)LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        public int SearchBody(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            retobj = null;
            return SearchUserGdBdProc(out retobj, out retTotalCnt, out nextData, paraobj, readMode, logicalMode, 0);
        }

        /// <summary>
        /// ���[�U�[�K�C�h�{�f�B(�񋟕�)LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        public int SearchGuideDivCode(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            bool nextData;
            int retTotalCnt;
            retobj = null;
            return SearchUserGdBdGuideDivCodeProc(out retobj, out retTotalCnt, out nextData, paraobj, readMode, logicalMode, 0);
        }

        /// <summary>
        /// ���[�U�[�K�C�h�{�f�B(�񋟕�)LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>		
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        private int SearchUserGdBdProc(out object retobj, out int retTotalCnt, out bool nextData, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommandCount = null;
            SqlCommand sqlCommand = null;

            UserGdBdWork usergdbdWork = new UserGdBdWork();
            usergdbdWork = null;

            retobj = null;

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
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                usergdbdWork = paraobj as UserGdBdWork;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�����w�胊�[�h�ňꌏ�ڃ��[�h�̏ꍇ�f�[�^���������擾
                if ((readCnt > 0) && (usergdbdWork.UserGuideDivCd == 0) && (usergdbdWork.GuideCode == 0))
                {
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection);
                        //�_���폜�敪�ݒ�
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE", sqlConnection);
                        //�_���폜�敪�ݒ�
                        SqlParameter paraLogicalDeleteCode = sqlCommandCount.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommandCount = new SqlCommand("SELECT COUNT (*) FROM USERGDBDRF", sqlConnection);
                    }

                    retTotalCnt = (int)sqlCommandCount.ExecuteScalar();
                }

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    //�����w�薳���̏ꍇ
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                    }
                    else
                    {
                        //�ꌏ�ڃ��[�h�̏ꍇ
                        if ((readCnt > 0) && (usergdbdWork.UserGuideDivCd == 0) && (usergdbdWork.GuideCode == 0))
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                        }
                        //Next���[�h�̏ꍇ
                        else
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                            SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                            SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

                            paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.UserGuideDivCd);
                            paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.GuideCode);
                        }
                    }
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    //�����w�薳���̏ꍇ
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                    }
                    else
                    {
                        //�ꌏ�ڃ��[�h�̏ꍇ
                        if ((readCnt > 0) && (usergdbdWork.UserGuideDivCd == 0) && (usergdbdWork.GuideCode == 0))
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                        }
                        //Next���[�h�̏ꍇ
                        else
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE AND USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                            SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                            SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

                            paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.UserGuideDivCd);
                            paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.GuideCode);
                        }
                    }
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    //�����w�薳���̏ꍇ
                    if (readCnt == 0)
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                    }
                    else
                    {
                        //�ꌏ�ڃ��[�h�̏ꍇ
                        if ((readCnt > 0) && (usergdbdWork.UserGuideDivCd == 0) && (usergdbdWork.GuideCode == 0))
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                        }
                        else
                        {
                            sqlCommand = new SqlCommand("SELECT TOP " + _readCnt.ToString() + " * FROM USERGDBDRF WHERE  USERGUIDEDIVCDRF>@FINDUSERGUIDEDIVCD AND GUIDECODERF>@FINDGUIDECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                            SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                            SqlParameter paraGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

                            paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.UserGuideDivCd);
                            paraGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.GuideCode);
                        }
                    }
                }

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int retCnt = 0;
                while (myReader.Read())
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
                    UserGdBdWork wkUserGdBdWork = new UserGdBdWork();

                    wkUserGdBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUserGdBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUserGdBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUserGdBdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    wkUserGdBdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                    wkUserGdBdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                    wkUserGdBdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                    al.Add(wkUserGdBdWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchUserGdBdProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommandCount != null)
                {
                    sqlCommandCount.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            retobj = al;

            return status;

        }

        /// <summary>
        /// ���[�U�[�K�C�h�{�f�B(�񋟕�)LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>		
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        private int SearchUserGdBdGuideDivCodeProc(out object retobj, out int retTotalCnt, out bool nextData, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            UserGdBdWork usergdbdWork = new UserGdBdWork();
            usergdbdWork = null;

            retobj = null;

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
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                usergdbdWork = paraobj as UserGdBdWork;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF " +
                        "WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                }

                SqlParameter paraGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                paraGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.UserGuideDivCd);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int retCnt = 0;
                while (myReader.Read())
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
                    UserGdBdWork wkUserGdBdWork = new UserGdBdWork();

                    wkUserGdBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUserGdBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUserGdBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUserGdBdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    wkUserGdBdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                    wkUserGdBdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                    wkUserGdBdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                    al.Add(wkUserGdBdWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchUserGdBdGuideDivCodeProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            retobj = al;

            return status;

        }

        /// <summary>
        /// ���[�U�[�K�C�h�{�f�B(�񋟕�)LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobject">��������</param>
        /// <param name="paraobject">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 21052 �R�c�@�\</br>
        /// <br>Date       : 2005.03.24</br>
        public int SearchUserGdBdGuideDivCode(out object retobject, object paraobject, ConstantManagement.LogicalMode logicalMode)
        {
            ArrayList userGdBdWorkList = paraobject as ArrayList;
            return SearchUserGdBdGuideDivCodeProc(out retobject, userGdBdWorkList, logicalMode);
        }

        /// <summary>
        /// ���[�U�[�K�C�h�{�f�B(�񋟕�)LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobject">��������</param>
        /// <param name="userGdBdWorkList">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�hLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 21052 �R�c�@�\</br>
        /// <br>Date       : 2005.03.24</br>
        private int SearchUserGdBdGuideDivCodeProc(out object retobject, ArrayList userGdBdWorkList, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            UserGdBdWork usergdbdWork = new UserGdBdWork();
            usergdbdWork = null;

            retobject = null;

            ArrayList al = new ArrayList();
            try
            {
                if ((userGdBdWorkList != null) && (userGdBdWorkList.Count > 0))
                {
                    string strsql = "";
                    for (int iCnt = 0; iCnt < userGdBdWorkList.Count; iCnt++)
                    {
                        if (iCnt == 0)
                        {
                            strsql = "SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
                        }
                        else
                        {
                            strsql = strsql + " UNION SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
                        }

                        //�f�[�^�Ǎ�
                        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData3))
                        {
                            strsql = strsql + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                        }
                        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData012))
                        {
                            strsql = strsql + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                        }
                    }

                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                    if (connectionText == null || connectionText == "") return status;

                    //SQL������
                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    usergdbdWork = userGdBdWorkList[0] as UserGdBdWork;

                    //�f�[�^�Ǎ�
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                    }

                    SqlParameter[] paraGuideDivCode = new SqlParameter[userGdBdWorkList.Count];
                    for (int iCnt = 0; iCnt < userGdBdWorkList.Count; iCnt++)
                    {
                        paraGuideDivCode[iCnt] = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD" + iCnt.ToString(), SqlDbType.Int);
                        paraGuideDivCode[iCnt].Value = SqlDataMediator.SqlSetInt32(((UserGdBdWork)userGdBdWorkList[iCnt]).UserGuideDivCd);
                    }

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    while (myReader.Read())
                    {
                        UserGdBdWork wkUserGdBdWork = new UserGdBdWork();

                        wkUserGdBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkUserGdBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkUserGdBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkUserGdBdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                        wkUserGdBdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                        wkUserGdBdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                        wkUserGdBdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                        al.Add(wkUserGdBdWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchUserGdBdGuideDivCodeProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            retobject = al;

            return status;

        }

        /// <summary>
        /// �w�肳�ꂽ�L�[�̃��[�U�[�K�C�h�{�f�B(�񋟕�)��߂��܂�
        /// </summary>
        /// <param name="parabyte">UserGdBdWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            UserGdBdWork usergdbdWork = new UserGdBdWork();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                usergdbdWork = (UserGdBdWork)XmlByteSerializer.Deserialize(parabyte, typeof(UserGdBdWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD AND GUIDECODERF=@FINDGUIDECODE", sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaGuideDivCode = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findParaGuideCode = sqlCommand.Parameters.Add("@FINDGUIDECODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaGuideDivCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.UserGuideDivCd);
                findParaGuideCode.Value = SqlDataMediator.SqlSetInt32(usergdbdWork.GuideCode);

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read())
                {
                    usergdbdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    usergdbdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    usergdbdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    usergdbdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    usergdbdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                    usergdbdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                    usergdbdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.Read:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }

            // XML�֕ϊ����A������̃o�C�i����
            parabyte = XmlByteSerializer.Serialize(usergdbdWork);

            return status;
        }
        #endregion

        #region �C���^�[�t�F�[�X�Ō��J���Ȃ����\�b�h
        /// <summary>
        /// ���[�U�[�K�C�h�{�f�B(�񋟕�)LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="userGdBdWorkList">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.12.28</br>
        public int Search(out ArrayList retList, UserGdBdWork[] userGdBdWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            UserGdBdWork usergdbdWork = null;

            retList = null;

            ArrayList al = new ArrayList();
            try
            {
                if ((userGdBdWorkList != null) && (userGdBdWorkList.Length > 0))
                {
                    string strsql = "";
                    for (int iCnt = 0; iCnt < userGdBdWorkList.Length; iCnt++)
                    {
                        if (iCnt == 0)
                        {
                            strsql = "SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
                        }
                        else
                        {
                            strsql = strsql + " UNION SELECT * FROM USERGDBDRF WHERE USERGUIDEDIVCDRF=@FINDUSERGUIDEDIVCD" + iCnt.ToString();
                        }

                        //�f�[�^�Ǎ�
                        if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData3))
                        {
                            strsql = strsql + " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE";
                        }
                        else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                            (logicalMode == ConstantManagement.LogicalMode.GetData012))
                        {
                            strsql = strsql + " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE";
                        }
                    }

                    usergdbdWork = userGdBdWorkList[0] as UserGdBdWork;

                    //�f�[�^�Ǎ�
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                        else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                    }
                    else
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM (" + strsql + ") AS USERGDBD ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                    }

                    SqlParameter[] paraGuideDivCode = new SqlParameter[userGdBdWorkList.Length];
                    for (int iCnt = 0; iCnt < userGdBdWorkList.Length; iCnt++)
                    {
                        paraGuideDivCode[iCnt] = sqlCommand.Parameters.Add("@FINDUSERGUIDEDIVCD" + iCnt.ToString(), SqlDbType.Int);
                        paraGuideDivCode[iCnt].Value = SqlDataMediator.SqlSetInt32(((UserGdBdWork)userGdBdWorkList[iCnt]).UserGuideDivCd);
                    }

                    UserGdBdWork wkUserGdBdWork = new UserGdBdWork();
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        wkUserGdBdWork = new UserGdBdWork();
                        wkUserGdBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                        wkUserGdBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                        wkUserGdBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                        wkUserGdBdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                        wkUserGdBdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                        wkUserGdBdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                        wkUserGdBdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                        al.Add(wkUserGdBdWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.SearchUserGdBdGuideDivCodeProc:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            retList = al;

            return status;
        }

        /// <summary>
        /// ���[�U�[�K�C�h�{�f�B(�񋟕�)LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="userGdBdWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.12.28</br>
        public int Search(out ArrayList retList, UserGdBdWork userGdBdWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            retList = null;

            ArrayList al = new ArrayList();
            try
            {
                //�f�[�^�Ǎ�
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE LOGICALDELETECODERF=@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF WHERE LOGICALDELETECODERF<@FINDLOGICALDELETECODE ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }
                else
                {
                    sqlCommand = new SqlCommand("SELECT * FROM USERGDBDRF ORDER BY USERGUIDEDIVCDRF, GUIDECODERF", sqlConnection);
                }

                UserGdBdWork wkUserGdBdWork = new UserGdBdWork();
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    wkUserGdBdWork = new UserGdBdWork();
                    wkUserGdBdWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    wkUserGdBdWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    wkUserGdBdWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    wkUserGdBdWork.UserGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("USERGUIDEDIVCDRF"));
                    wkUserGdBdWork.GuideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDECODERF"));
                    wkUserGdBdWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));
                    wkUserGdBdWork.GuideType = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GUIDETYPERF"));

                    al.Add(wkUserGdBdWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserGdBdDB.Search:" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }

            retList = al;

            return status;
        }
        #endregion
    }
}

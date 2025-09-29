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
    /// ���i���[�J�[���̐ݒ�i�񋟁jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i���[�J�[���̐ݒ�i�񋟁j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22027�@���{�@����</br>
    /// <br>Date       : 2006.06.08</br>
    /// <br></br>
    /// <br>Update Note: 30290 2008/06/03</br>
    /// <br>             �e�[�u�����C�A�E�g�ύX�ɂ��C��</br>
    /// </remarks>
    [Serializable]
    public class PMakerNmDB : RemoteDB, IPMakerNmDB
    {
        #region constructor
        /// <summary>
        /// ���i���[�J�[���̐ݒ�i�񋟁jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22027�@���{�@����</br>
        /// <br>Date       : 2006.06.08</br>
        /// </remarks>
        public PMakerNmDB()
            :
            base("SFTKD02074D", "Broadleaf.Application.Remoting.ParamData.PMakerNmWork", "PMAKERNMRF")
        {
        }
        #endregion

        #region Search(out object retobj, int readMode)

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̕��i���[�J�[���̐ݒ�i�񋟁jLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̕��i���[�J�[���̐ݒ�i�񋟁jLIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22027�@���{�@����</br>
        /// <br>Date       : 2006.06.08</br>
        public int Search(out object retobj, int readMode)
        {
            try
            {
                return SearchProc(out retobj, readMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMakerNmDB.Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)");
                retobj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̕��i���[�J�[���̐ݒ�i�񋟁jLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="readMode">�����敪[����Ɍ�������񋟓��t���w�肵�Ă��炤]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̕��i���[�J�[���̐ݒ�i�񋟁jLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22027�@���{�@����</br>
        /// <br>Date       : 2006.06.08</br>
        private int SearchProc(out object retobj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            PMakerNmWork wkPMakerNmWork = null;

            retobj = null;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (string.IsNullOrEmpty(connectionText))
                    return 99;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand;

                //�f�[�^�Ǎ�
                string query = "SELECT * FROM PMAKERNMRF ";
                sqlCommand = new SqlCommand(query, sqlConnection);
                if (readMode != 0)
                {
                    query += " WHERE OFFERDATERF = @FINDOFFERDATE";
                    ((SqlParameter)sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int)).Value
                            = SqlDataMediator.SqlSetInt(readMode);
                }
                query += " ORDER BY PARTSMAKERCODERF";
                sqlCommand.CommandText = query;

                myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (myReader.Read())
                {
                    wkPMakerNmWork = new PMakerNmWork();
                    #region �l�̃Z�b�g
                    wkPMakerNmWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                    wkPMakerNmWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                    wkPMakerNmWork.PartsMakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERFULLNAMERF"));
                    wkPMakerNmWork.PartsMakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERHALFNAMERF"));
                    #endregion
                    al.Add(wkPMakerNmWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (readMode != 0 && al.Count == 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null && !myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            retobj = al;
            return status;
        }

        #endregion

        #region Search(out ArrayList retArray, int readMode, SqlConnection sqlConnection)

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̕��i���[�J�[���̐ݒ�i�񋟁jLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retArray">��������</param>
        /// <param name="readMode">�����敪[����Ɍ�������񋟓��t���w�肵�Ă��炤]</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̕��i���[�J�[���̐ݒ�i�񋟁jLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22027�@���{�@����</br>
        /// <br>Date       : 2006.06.08</br>
        public int Search(out ArrayList retArray, int readMode, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
                SqlDataReader myReader = null;
                PMakerNmWork wkPMakerNmWork = null;
                retArray = null;

                ArrayList al = new ArrayList();
                try
                {

                    SqlCommand sqlCommand;

                    string query = "SELECT * FROM PMAKERNMRF ";

                    //�f�[�^�Ǎ�
                    sqlCommand = new SqlCommand(query, sqlConnection, sqlTransaction);
                    if (readMode != 0)
                    {
                        query += " WHERE OFFERDATERF > @FINDOFFERDATE";
                        ((SqlParameter)sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int)).Value
                                = SqlDataMediator.SqlSetInt(readMode);
                    }
                    query += " ORDER BY PARTSMAKERCODERF";
                    sqlCommand.CommandText = query;

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        wkPMakerNmWork = new PMakerNmWork();
                        #region �l�̃Z�b�g
                        wkPMakerNmWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                        wkPMakerNmWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                        wkPMakerNmWork.PartsMakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERFULLNAMERF"));
                        wkPMakerNmWork.PartsMakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERHALFNAMERF"));
                        #endregion
                        al.Add(wkPMakerNmWork);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    if (readMode != 0 && al.Count == 0)
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
                }
                finally
                {
                    if (!myReader.IsClosed) myReader.Close();
                }

                retArray = al;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMakerNmDB.Search(out ArrayList retArray,PMakerNmWork pmakernmWork, int readMode,ConstantManagement.LogicalMode logicalMode , ref SqlConnection sqlConnection)");
                retArray = new ArrayList();
            }

            return status;
        }
        #endregion

        #region Read

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̕��i���[�J�[���̐ݒ�i�񋟁j��߂��܂�
        /// </summary>
        /// <param name="parabyte">PMakerNmWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̕��i���[�J�[���̐ݒ�i�񋟁j��߂��܂�</br>
        /// <br>Programmer : 22027�@���{�@����</br>
        /// <br>Date       : 2006.06.08</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                SqlConnection sqlConnection = null;
                SqlDataReader myReader = null;

                PMakerNmWork pmakernmWork = new PMakerNmWork();

                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XML�̓ǂݍ���
                    pmakernmWork = (PMakerNmWork)XmlByteSerializer.Deserialize(parabyte, typeof(PMakerNmWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //Select�R�}���h�̐���
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PMAKERNMRF WHERE PARTSMAKERCODERF=@FINDPARTSMAKERCODE ", sqlConnection))
                    {
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaPartsMakerCode = sqlCommand.Parameters.Add("@FINDPARTSMAKERCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaPartsMakerCode.Value = SqlDataMediator.SqlSetInt32(pmakernmWork.PartsMakerCode);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {
                            #region �l�̃Z�b�g
                            pmakernmWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
                            pmakernmWork.PartsMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCODERF"));
                            pmakernmWork.PartsMakerFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERFULLNAMERF"));
                            pmakernmWork.PartsMakerHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMAKERHALFNAMERF"));
                            #endregion
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
                    if (!myReader.IsClosed) myReader.Close();
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                    }
                }

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(pmakernmWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PMakerNmDB.Read");
            }
            return status;
        }

        #endregion
    }
}

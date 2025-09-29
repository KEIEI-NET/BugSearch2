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
	/// ����������p�^�[���}�X�^�ݒ�DB�����[�g�I�u�W�F�N�g
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����������p�^�[���}�X�^�ݒ�̎��f�[�^������s���N���X�ł��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2007.07.02</br>
	/// <br></br>
	/// <br>Update Note: 20081 �D�c �E�l</br>
    /// <br>Update Note: 2007.09.18 DC.NS�p�ɕύX</br>
    /// <br>Update Note: 2008.06.09 22008 ���� PM.NS�p�ɕύX</br>
    /// <br>Update Note: 2010/02/18 30531 ���r��</br>
    /// <br>           : ���߈󎚋敪�ǉ�
    /// <br>Update Note: 2011/02/16  �{�w�C��<br>																								
    /// <br>           : ���Ж��󎚋敪��ǉ�<br>																								
    /// </remarks>
    [Serializable]
    public class DmdPrtPtnDB : RemoteDB, IDmdPrtPtnDB
    {
        #region constructor
        /// <summary>
        /// ����������p�^�[���}�X�^�ݒ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        /// </remarks>
        public DmdPrtPtnDB()
            :
        base("MAKAU09156D", "Broadleaf.Application.Remoting.ParamData.DmdPrtPtnWork", "DMDPRTPTNRF")
        {
        }
        #endregion

        #region Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���}�X�^�ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���}�X�^�ݒ�LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int Search(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            try
            {
                return SearchProc(out retobj, paraobj, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnDB.Search(out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode)");
                retobj = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���}�X�^�ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���}�X�^�ݒ�LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        private int SearchProc(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            DmdPrtPtnWork dmdPrtPtnWork = null;

            retobj = null;

            ArrayList al = new ArrayList();
            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                dmdPrtPtnWork = paraobj as DmdPrtPtnWork;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                
                string sqlTxt = string.Empty;

                sqlTxt += "SELECT * FROM DMDPRTPTNRF " + Environment.NewLine;

                sqlTxt += "WHERE" + Environment.NewLine;

                sqlTxt += "ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.EnterpriseCode);

                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE " + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlTxt += wkstring;
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                //�f�[�^���̓V�X�e��
                sqlTxt += "AND DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM " + Environment.NewLine;
                SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DataInputSystem);

                //�`�[������
                if (dmdPrtPtnWork.SlipPrtKind != 0)
                {
                    sqlTxt += "AND SLIPPRTKINDRF=@SLIPPRTKIND " + Environment.NewLine;
                    SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                    paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.SlipPrtKind);
                }

                //�`�[����ݒ�p���[ID
                if (string.IsNullOrEmpty(dmdPrtPtnWork.SlipPrtSetPaperId) == false)
                {
                    sqlTxt += "AND SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID " + Environment.NewLine;
                    SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                    paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.SlipPrtSetPaperId);
                }

                sqlCommand.CommandText = sqlTxt;
                
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToDmdPrtPtnWorkFromReader(ref myReader));

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
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            retobj = al;
            return status;
        }
        #endregion
        
        #region Read
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���}�X�^�ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���}�X�^�ݒ��߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            return this.ReadProc(ref parabyte, readMode);
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���}�X�^�ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̐���������p�^�[���}�X�^�ݒ��߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        private int ReadProc(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                SqlConnection sqlConnection = null;
                SqlDataReader myReader = null;

                DmdPrtPtnWork dmdPrtPtnWork = new DmdPrtPtnWork();

                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XML�̓ǂݍ���
                    dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    //Select�R�}���h�̐���
                    using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM DMDPRTPTNRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection))
                    {
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                        SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.SlipPrtKind);
                        findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.SlipPrtSetPaperId);

                        myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        if (myReader.Read())
                        {
                            dmdPrtPtnWork = CopyToDmdPrtPtnWorkFromReader(ref myReader);
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
                parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnDB.Read");
            }
            return status;
        }
        #endregion

        #region Write(ref byte[] parabyte)
        /// <summary>
        /// ����������p�^�[���}�X�^�ݒ����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���}�X�^�ݒ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int Write(ref byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                SqlConnection sqlConnection = null;
                SqlTransaction sqlTransaction = null;
                try
                {
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    // XML�̓ǂݍ���
                    DmdPrtPtnWork dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    status = this.Write(ref dmdPrtPtnWork,ref sqlConnection,ref sqlTransaction);
                    
                    // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                    parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
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

                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnDB.Write");
            }

            return status;
        }

        /// <summary>
        /// ����������p�^�[���}�X�^�ݒ����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���}�X�^�ݒ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.12</br>
        public int Write(ref DmdPrtPtnWork dmdPrtPtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref dmdPrtPtnWork, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// ����������p�^�[���}�X�^�ݒ����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���}�X�^�ݒ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.12</br>
        /// <br>Update Note: 2011/02/16  �{�w�C��<br>																								
        /// <br>           : ���Ж��󎚋敪��ǉ�<br>	
        private int WriteProc(ref DmdPrtPtnWork dmdPrtPtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;

            try 
            {
                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM DMDPRTPTNRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection, sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                    SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.EnterpriseCode);
                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DataInputSystem);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.SlipPrtKind);
                    findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.SlipPrtSetPaperId);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != dmdPrtPtnWork.UpdateDateTime)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (dmdPrtPtnWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }

                        // --- ADD  ���r��  2010/02/18 ---------->>>>>
                        //sqlCommand.CommandText = "UPDATE DMDPRTPTNRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID , SLIPCOMMENTRF=@SLIPCOMMENT , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , TOPMARGINRF=@TOPMARGIN , LEFTMARGINRF=@LEFTMARGIN , RIGHTMARGINRF=@RIGHTMARGIN , BOTTOMMARGINRF=@BOTTOMMARGIN , COPYCOUNTRF=@COPYCOUNT , DMDTTLFORMTITLE1RF=@DMDTTLFORMTITLE1 , DMDTTLFORMTITLE2RF=@DMDTTLFORMTITLE2 , DMDTTLFORMTITLE3RF=@DMDTTLFORMTITLE3 , DMDTTLFORMTITLE4RF=@DMDTTLFORMTITLE4 , DMDTTLFORMTITLE5RF=@DMDTTLFORMTITLE5 , DMDTTLFORMTITLE6RF=@DMDTTLFORMTITLE6 , DMDTTLFORMTITLE7RF=@DMDTTLFORMTITLE7 , DMDTTLFORMTITLE8RF=@DMDTTLFORMTITLE8 , DMDTTLSETITEMDIV1RF=@DMDTTLSETITEMDIV1 , DMDTTLSETITEMDIV2RF=@DMDTTLSETITEMDIV2 , DMDTTLSETITEMDIV3RF=@DMDTTLSETITEMDIV3 , DMDTTLSETITEMDIV4RF=@DMDTTLSETITEMDIV4 , DMDTTLSETITEMDIV5RF=@DMDTTLSETITEMDIV5 , DMDTTLSETITEMDIV6RF=@DMDTTLSETITEMDIV6 , DMDTTLSETITEMDIV7RF=@DMDTTLSETITEMDIV7 , DMDTTLSETITEMDIV8RF=@DMDTTLSETITEMDIV8 , DMDFORMTITLERF=@DMDFORMTITLE , DMDFORMTITLE2RF=@DMDFORMTITLE2 , DMDFORMCOMENT1RF=@DMDFORMCOMENT1 , DMDFORMCOMENT2RF=@DMDFORMCOMENT2 , DMDFORMCOMENT3RF=@DMDFORMCOMENT3 , DMDDTLOUTLINECODERF=@DMDDTLOUTLINECODE , DMDDTLPTNODRDIVRF=@DMDDTLPTNODRDIV , SLIPTTLPRTDIVRF=@SLIPTTLPRTDIV , ADDDAYTTLPRTDIVRF=@ADDDAYTTLPRTDIV , CUSTOMERTTLPRTDIVRF=@CUSTOMERTTLPRTDIV , DTLPRCZEROPRTDIVRF=@DTLPRCZEROPRTDIV , DEPODTLPRCPRTDIVRF=@DEPODTLPRCPRTDIV , BILLHONORIFICTTLRF=@BILLHONORIFICTTL, LISTPRICEPRTCDRF=@LISTPRICEPRTCD , PARTSNOPRTCDRF=@PARTSNOPRTCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";
                        // --- UPD   2011/02/16 ---------->>>>>
                        // sqlCommand.CommandText = "UPDATE DMDPRTPTNRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID , SLIPCOMMENTRF=@SLIPCOMMENT , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , TOPMARGINRF=@TOPMARGIN , LEFTMARGINRF=@LEFTMARGIN , RIGHTMARGINRF=@RIGHTMARGIN , BOTTOMMARGINRF=@BOTTOMMARGIN , COPYCOUNTRF=@COPYCOUNT , DMDTTLFORMTITLE1RF=@DMDTTLFORMTITLE1 , DMDTTLFORMTITLE2RF=@DMDTTLFORMTITLE2 , DMDTTLFORMTITLE3RF=@DMDTTLFORMTITLE3 , DMDTTLFORMTITLE4RF=@DMDTTLFORMTITLE4 , DMDTTLFORMTITLE5RF=@DMDTTLFORMTITLE5 , DMDTTLFORMTITLE6RF=@DMDTTLFORMTITLE6 , DMDTTLFORMTITLE7RF=@DMDTTLFORMTITLE7 , DMDTTLFORMTITLE8RF=@DMDTTLFORMTITLE8 , DMDTTLSETITEMDIV1RF=@DMDTTLSETITEMDIV1 , DMDTTLSETITEMDIV2RF=@DMDTTLSETITEMDIV2 , DMDTTLSETITEMDIV3RF=@DMDTTLSETITEMDIV3 , DMDTTLSETITEMDIV4RF=@DMDTTLSETITEMDIV4 , DMDTTLSETITEMDIV5RF=@DMDTTLSETITEMDIV5 , DMDTTLSETITEMDIV6RF=@DMDTTLSETITEMDIV6 , DMDTTLSETITEMDIV7RF=@DMDTTLSETITEMDIV7 , DMDTTLSETITEMDIV8RF=@DMDTTLSETITEMDIV8 , DMDFORMTITLERF=@DMDFORMTITLE , DMDFORMTITLE2RF=@DMDFORMTITLE2 , DMDFORMCOMENT1RF=@DMDFORMCOMENT1 , DMDFORMCOMENT2RF=@DMDFORMCOMENT2 , DMDFORMCOMENT3RF=@DMDFORMCOMENT3 , DMDDTLOUTLINECODERF=@DMDDTLOUTLINECODE , DMDDTLPTNODRDIVRF=@DMDDTLPTNODRDIV , SLIPTTLPRTDIVRF=@SLIPTTLPRTDIV , ADDDAYTTLPRTDIVRF=@ADDDAYTTLPRTDIV , CUSTOMERTTLPRTDIVRF=@CUSTOMERTTLPRTDIV , DTLPRCZEROPRTDIVRF=@DTLPRCZEROPRTDIV , DEPODTLPRCPRTDIVRF=@DEPODTLPRCPRTDIV , BILLHONORIFICTTLRF=@BILLHONORIFICTTL, LISTPRICEPRTCDRF=@LISTPRICEPRTCD , PARTSNOPRTCDRF=@PARTSNOPRTCD , ANNOTATIONPRTCDRF=@ANNOTATIONPRTCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";
                        sqlCommand.CommandText = "UPDATE DMDPRTPTNRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , DATAINPUTSYSTEMRF=@DATAINPUTSYSTEM , SLIPPRTKINDRF=@SLIPPRTKIND , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID , SLIPCOMMENTRF=@SLIPCOMMENT , OUTPUTFORMFILENAMERF=@OUTPUTFORMFILENAME , TOPMARGINRF=@TOPMARGIN , LEFTMARGINRF=@LEFTMARGIN , RIGHTMARGINRF=@RIGHTMARGIN , BOTTOMMARGINRF=@BOTTOMMARGIN , COPYCOUNTRF=@COPYCOUNT , DMDTTLFORMTITLE1RF=@DMDTTLFORMTITLE1 , DMDTTLFORMTITLE2RF=@DMDTTLFORMTITLE2 , DMDTTLFORMTITLE3RF=@DMDTTLFORMTITLE3 , DMDTTLFORMTITLE4RF=@DMDTTLFORMTITLE4 , DMDTTLFORMTITLE5RF=@DMDTTLFORMTITLE5 , DMDTTLFORMTITLE6RF=@DMDTTLFORMTITLE6 , DMDTTLFORMTITLE7RF=@DMDTTLFORMTITLE7 , DMDTTLFORMTITLE8RF=@DMDTTLFORMTITLE8 , DMDTTLSETITEMDIV1RF=@DMDTTLSETITEMDIV1 , DMDTTLSETITEMDIV2RF=@DMDTTLSETITEMDIV2 , DMDTTLSETITEMDIV3RF=@DMDTTLSETITEMDIV3 , DMDTTLSETITEMDIV4RF=@DMDTTLSETITEMDIV4 , DMDTTLSETITEMDIV5RF=@DMDTTLSETITEMDIV5 , DMDTTLSETITEMDIV6RF=@DMDTTLSETITEMDIV6 , DMDTTLSETITEMDIV7RF=@DMDTTLSETITEMDIV7 , DMDTTLSETITEMDIV8RF=@DMDTTLSETITEMDIV8 , DMDFORMTITLERF=@DMDFORMTITLE , DMDFORMTITLE2RF=@DMDFORMTITLE2 , DMDFORMCOMENT1RF=@DMDFORMCOMENT1 , DMDFORMCOMENT2RF=@DMDFORMCOMENT2 , DMDFORMCOMENT3RF=@DMDFORMCOMENT3 , DMDDTLOUTLINECODERF=@DMDDTLOUTLINECODE , DMDDTLPTNODRDIVRF=@DMDDTLPTNODRDIV , SLIPTTLPRTDIVRF=@SLIPTTLPRTDIV , ADDDAYTTLPRTDIVRF=@ADDDAYTTLPRTDIV , CUSTOMERTTLPRTDIVRF=@CUSTOMERTTLPRTDIV , DTLPRCZEROPRTDIVRF=@DTLPRCZEROPRTDIV , DEPODTLPRCPRTDIVRF=@DEPODTLPRCPRTDIV , BILLHONORIFICTTLRF=@BILLHONORIFICTTL, LISTPRICEPRTCDRF=@LISTPRICEPRTCD , PARTSNOPRTCDRF=@PARTSNOPRTCD , ANNOTATIONPRTCDRF=@ANNOTATIONPRTCD, CONMPRINTOUTCDRF=@CONMPRINTOUTCD WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";
                        // --- UPD  2011/02/16 ----------<<<<<
                        // --- ADD  ���r��  2010/02/18 ----------<<<<<

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.SlipPrtKind);
                        findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.SlipPrtSetPaperId);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)dmdPrtPtnWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (dmdPrtPtnWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        //�V�K�쐬����SQL���𐶐�
                        // --- ADD  ���r��  2010/02/18 ---------->>>>>
                        //sqlCommand.CommandText = "INSERT INTO DMDPRTPTNRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, SLIPCOMMENTRF, OUTPUTFORMFILENAMERF, TOPMARGINRF, LEFTMARGINRF, RIGHTMARGINRF, BOTTOMMARGINRF, COPYCOUNTRF, DMDTTLFORMTITLE1RF, DMDTTLFORMTITLE2RF, DMDTTLFORMTITLE3RF, DMDTTLFORMTITLE4RF, DMDTTLFORMTITLE5RF, DMDTTLFORMTITLE6RF, DMDTTLFORMTITLE7RF, DMDTTLFORMTITLE8RF, DMDTTLSETITEMDIV1RF, DMDTTLSETITEMDIV2RF, DMDTTLSETITEMDIV3RF, DMDTTLSETITEMDIV4RF, DMDTTLSETITEMDIV5RF, DMDTTLSETITEMDIV6RF, DMDTTLSETITEMDIV7RF, DMDTTLSETITEMDIV8RF, DMDFORMTITLERF, DMDFORMTITLE2RF, DMDFORMCOMENT1RF, DMDFORMCOMENT2RF, DMDFORMCOMENT3RF, DMDDTLOUTLINECODERF, DMDDTLPTNODRDIVRF, SLIPTTLPRTDIVRF, ADDDAYTTLPRTDIVRF, CUSTOMERTTLPRTDIVRF, DTLPRCZEROPRTDIVRF, DEPODTLPRCPRTDIVRF, BILLHONORIFICTTLRF, LISTPRICEPRTCDRF, PARTSNOPRTCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DATAINPUTSYSTEM, @SLIPPRTKIND, @SLIPPRTSETPAPERID, @SLIPCOMMENT, @OUTPUTFORMFILENAME, @TOPMARGIN, @LEFTMARGIN, @RIGHTMARGIN, @BOTTOMMARGIN, @COPYCOUNT, @DMDTTLFORMTITLE1, @DMDTTLFORMTITLE2, @DMDTTLFORMTITLE3, @DMDTTLFORMTITLE4, @DMDTTLFORMTITLE5, @DMDTTLFORMTITLE6, @DMDTTLFORMTITLE7, @DMDTTLFORMTITLE8, @DMDTTLSETITEMDIV1, @DMDTTLSETITEMDIV2, @DMDTTLSETITEMDIV3, @DMDTTLSETITEMDIV4, @DMDTTLSETITEMDIV5, @DMDTTLSETITEMDIV6, @DMDTTLSETITEMDIV7, @DMDTTLSETITEMDIV8, @DMDFORMTITLE, @DMDFORMTITLE2, @DMDFORMCOMENT1, @DMDFORMCOMENT2, @DMDFORMCOMENT3, @DMDDTLOUTLINECODE, @DMDDTLPTNODRDIV, @SLIPTTLPRTDIV, @ADDDAYTTLPRTDIV, @CUSTOMERTTLPRTDIV, @DTLPRCZEROPRTDIV, @DEPODTLPRCPRTDIV, @BILLHONORIFICTTL, @LISTPRICEPRTCD, @PARTSNOPRTCD) ";
                        // --- UPD  2011/02/16 ---------->>>>>
                       // sqlCommand.CommandText = "INSERT INTO DMDPRTPTNRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, SLIPCOMMENTRF, OUTPUTFORMFILENAMERF, TOPMARGINRF, LEFTMARGINRF, RIGHTMARGINRF, BOTTOMMARGINRF, COPYCOUNTRF, DMDTTLFORMTITLE1RF, DMDTTLFORMTITLE2RF, DMDTTLFORMTITLE3RF, DMDTTLFORMTITLE4RF, DMDTTLFORMTITLE5RF, DMDTTLFORMTITLE6RF, DMDTTLFORMTITLE7RF, DMDTTLFORMTITLE8RF, DMDTTLSETITEMDIV1RF, DMDTTLSETITEMDIV2RF, DMDTTLSETITEMDIV3RF, DMDTTLSETITEMDIV4RF, DMDTTLSETITEMDIV5RF, DMDTTLSETITEMDIV6RF, DMDTTLSETITEMDIV7RF, DMDTTLSETITEMDIV8RF, DMDFORMTITLERF, DMDFORMTITLE2RF, DMDFORMCOMENT1RF, DMDFORMCOMENT2RF, DMDFORMCOMENT3RF, DMDDTLOUTLINECODERF, DMDDTLPTNODRDIVRF, SLIPTTLPRTDIVRF, ADDDAYTTLPRTDIVRF, CUSTOMERTTLPRTDIVRF, DTLPRCZEROPRTDIVRF, DEPODTLPRCPRTDIVRF, BILLHONORIFICTTLRF, LISTPRICEPRTCDRF, PARTSNOPRTCDRF, ANNOTATIONPRTCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DATAINPUTSYSTEM, @SLIPPRTKIND, @SLIPPRTSETPAPERID, @SLIPCOMMENT, @OUTPUTFORMFILENAME, @TOPMARGIN, @LEFTMARGIN, @RIGHTMARGIN, @BOTTOMMARGIN, @COPYCOUNT, @DMDTTLFORMTITLE1, @DMDTTLFORMTITLE2, @DMDTTLFORMTITLE3, @DMDTTLFORMTITLE4, @DMDTTLFORMTITLE5, @DMDTTLFORMTITLE6, @DMDTTLFORMTITLE7, @DMDTTLFORMTITLE8, @DMDTTLSETITEMDIV1, @DMDTTLSETITEMDIV2, @DMDTTLSETITEMDIV3, @DMDTTLSETITEMDIV4, @DMDTTLSETITEMDIV5, @DMDTTLSETITEMDIV6, @DMDTTLSETITEMDIV7, @DMDTTLSETITEMDIV8, @DMDFORMTITLE, @DMDFORMTITLE2, @DMDFORMCOMENT1, @DMDFORMCOMENT2, @DMDFORMCOMENT3, @DMDDTLOUTLINECODE, @DMDDTLPTNODRDIV, @SLIPTTLPRTDIV, @ADDDAYTTLPRTDIV, @CUSTOMERTTLPRTDIV, @DTLPRCZEROPRTDIV, @DEPODTLPRCPRTDIV, @BILLHONORIFICTTL, @LISTPRICEPRTCD, @PARTSNOPRTCD, @ANNOTATIONPRTCD) ";
                        sqlCommand.CommandText = "INSERT INTO DMDPRTPTNRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, DATAINPUTSYSTEMRF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, SLIPCOMMENTRF, OUTPUTFORMFILENAMERF, TOPMARGINRF, LEFTMARGINRF, RIGHTMARGINRF, BOTTOMMARGINRF, COPYCOUNTRF, DMDTTLFORMTITLE1RF, DMDTTLFORMTITLE2RF, DMDTTLFORMTITLE3RF, DMDTTLFORMTITLE4RF, DMDTTLFORMTITLE5RF, DMDTTLFORMTITLE6RF, DMDTTLFORMTITLE7RF, DMDTTLFORMTITLE8RF, DMDTTLSETITEMDIV1RF, DMDTTLSETITEMDIV2RF, DMDTTLSETITEMDIV3RF, DMDTTLSETITEMDIV4RF, DMDTTLSETITEMDIV5RF, DMDTTLSETITEMDIV6RF, DMDTTLSETITEMDIV7RF, DMDTTLSETITEMDIV8RF, DMDFORMTITLERF, DMDFORMTITLE2RF, DMDFORMCOMENT1RF, DMDFORMCOMENT2RF, DMDFORMCOMENT3RF, DMDDTLOUTLINECODERF, DMDDTLPTNODRDIVRF, SLIPTTLPRTDIVRF, ADDDAYTTLPRTDIVRF, CUSTOMERTTLPRTDIVRF, DTLPRCZEROPRTDIVRF, DEPODTLPRCPRTDIVRF, BILLHONORIFICTTLRF, LISTPRICEPRTCDRF, PARTSNOPRTCDRF, ANNOTATIONPRTCDRF, CONMPRINTOUTCDRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @DATAINPUTSYSTEM, @SLIPPRTKIND, @SLIPPRTSETPAPERID, @SLIPCOMMENT, @OUTPUTFORMFILENAME, @TOPMARGIN, @LEFTMARGIN, @RIGHTMARGIN, @BOTTOMMARGIN, @COPYCOUNT, @DMDTTLFORMTITLE1, @DMDTTLFORMTITLE2, @DMDTTLFORMTITLE3, @DMDTTLFORMTITLE4, @DMDTTLFORMTITLE5, @DMDTTLFORMTITLE6, @DMDTTLFORMTITLE7, @DMDTTLFORMTITLE8, @DMDTTLSETITEMDIV1, @DMDTTLSETITEMDIV2, @DMDTTLSETITEMDIV3, @DMDTTLSETITEMDIV4, @DMDTTLSETITEMDIV5, @DMDTTLSETITEMDIV6, @DMDTTLSETITEMDIV7, @DMDTTLSETITEMDIV8, @DMDFORMTITLE, @DMDFORMTITLE2, @DMDFORMCOMENT1, @DMDFORMCOMENT2, @DMDFORMCOMENT3, @DMDDTLOUTLINECODE, @DMDDTLPTNODRDIV, @SLIPTTLPRTDIV, @ADDDAYTTLPRTDIV, @CUSTOMERTTLPRTDIV, @DTLPRCZEROPRTDIV, @DEPODTLPRCPRTDIV, @BILLHONORIFICTTL, @LISTPRICEPRTCD, @PARTSNOPRTCD, @ANNOTATIONPRTCD, @CONMPRINTOUTCD) ";
                        // --- UPD  2011/02/16 ----------<<<<<
                        // --- ADD  ���r��  2010/02/18 ---------->>>>>

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)dmdPrtPtnWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        
                        //�`�[����h�c�ݒ�(���R���[����̓o�^�ȊO�͍쐬���Ԃ�ݒ�)
                        if (string.IsNullOrEmpty(dmdPrtPtnWork.SlipPrtSetPaperId) == true)
                            dmdPrtPtnWork.SlipPrtSetPaperId = dmdPrtPtnWork.CreateDateTime.Ticks.ToString();
                    }
                    if (!myReader.IsClosed) myReader.Close();

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraDataInputSystem = sqlCommand.Parameters.Add("@DATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                    SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                    SqlParameter paraSlipComment = sqlCommand.Parameters.Add("@SLIPCOMMENT", SqlDbType.NVarChar);
                    SqlParameter paraOutputFormFileName = sqlCommand.Parameters.Add("@OUTPUTFORMFILENAME", SqlDbType.NVarChar);
                    SqlParameter paraTopMargin = sqlCommand.Parameters.Add("@TOPMARGIN", SqlDbType.Float);
                    SqlParameter paraLeftMargin = sqlCommand.Parameters.Add("@LEFTMARGIN", SqlDbType.Float);
                    SqlParameter paraRightMargin = sqlCommand.Parameters.Add("@RIGHTMARGIN", SqlDbType.Float);
                    SqlParameter paraBottomMargin = sqlCommand.Parameters.Add("@BOTTOMMARGIN", SqlDbType.Float);
                    SqlParameter paraCopyCount = sqlCommand.Parameters.Add("@COPYCOUNT", SqlDbType.Int);
                    SqlParameter paraDmdTtlFormTitle1 = sqlCommand.Parameters.Add("@DMDTTLFORMTITLE1", SqlDbType.NVarChar);
                    SqlParameter paraDmdTtlFormTitle2 = sqlCommand.Parameters.Add("@DMDTTLFORMTITLE2", SqlDbType.NVarChar);
                    SqlParameter paraDmdTtlFormTitle3 = sqlCommand.Parameters.Add("@DMDTTLFORMTITLE3", SqlDbType.NVarChar);
                    SqlParameter paraDmdTtlFormTitle4 = sqlCommand.Parameters.Add("@DMDTTLFORMTITLE4", SqlDbType.NVarChar);
                    SqlParameter paraDmdTtlFormTitle5 = sqlCommand.Parameters.Add("@DMDTTLFORMTITLE5", SqlDbType.NVarChar);
                    SqlParameter paraDmdTtlFormTitle6 = sqlCommand.Parameters.Add("@DMDTTLFORMTITLE6", SqlDbType.NVarChar);
                    SqlParameter paraDmdTtlFormTitle7 = sqlCommand.Parameters.Add("@DMDTTLFORMTITLE7", SqlDbType.NVarChar);
                    SqlParameter paraDmdTtlFormTitle8 = sqlCommand.Parameters.Add("@DMDTTLFORMTITLE8", SqlDbType.NVarChar);
                    SqlParameter paraDmdTtlSetItemDiv1 = sqlCommand.Parameters.Add("@DMDTTLSETITEMDIV1", SqlDbType.Int);
                    SqlParameter paraDmdTtlSetItemDiv2 = sqlCommand.Parameters.Add("@DMDTTLSETITEMDIV2", SqlDbType.Int);
                    SqlParameter paraDmdTtlSetItemDiv3 = sqlCommand.Parameters.Add("@DMDTTLSETITEMDIV3", SqlDbType.Int);
                    SqlParameter paraDmdTtlSetItemDiv4 = sqlCommand.Parameters.Add("@DMDTTLSETITEMDIV4", SqlDbType.Int);
                    SqlParameter paraDmdTtlSetItemDiv5 = sqlCommand.Parameters.Add("@DMDTTLSETITEMDIV5", SqlDbType.Int);
                    SqlParameter paraDmdTtlSetItemDiv6 = sqlCommand.Parameters.Add("@DMDTTLSETITEMDIV6", SqlDbType.Int);
                    SqlParameter paraDmdTtlSetItemDiv7 = sqlCommand.Parameters.Add("@DMDTTLSETITEMDIV7", SqlDbType.Int);
                    SqlParameter paraDmdTtlSetItemDiv8 = sqlCommand.Parameters.Add("@DMDTTLSETITEMDIV8", SqlDbType.Int);
                    SqlParameter paraDmdFormTitle = sqlCommand.Parameters.Add("@DMDFORMTITLE", SqlDbType.NVarChar);
                    SqlParameter paraDmdFormTitle2 = sqlCommand.Parameters.Add("@DMDFORMTITLE2", SqlDbType.NVarChar);
                    SqlParameter paraDmdFormComent1 = sqlCommand.Parameters.Add("@DMDFORMCOMENT1", SqlDbType.NVarChar);
                    SqlParameter paraDmdFormComent2 = sqlCommand.Parameters.Add("@DMDFORMCOMENT2", SqlDbType.NVarChar);
                    SqlParameter paraDmdFormComent3 = sqlCommand.Parameters.Add("@DMDFORMCOMENT3", SqlDbType.NVarChar);
                    SqlParameter paraDmdDtlOutlineCode = sqlCommand.Parameters.Add("@DMDDTLOUTLINECODE", SqlDbType.Int);
                    SqlParameter paraDmdDtlPtnOdrDiv = sqlCommand.Parameters.Add("@DMDDTLPTNODRDIV", SqlDbType.Int);
                    SqlParameter paraSlipTtlPrtDiv = sqlCommand.Parameters.Add("@SLIPTTLPRTDIV", SqlDbType.Int);
                    SqlParameter paraAddDayTtlPrtDiv = sqlCommand.Parameters.Add("@ADDDAYTTLPRTDIV", SqlDbType.Int);
                    SqlParameter paraCustomerTtlPrtDiv = sqlCommand.Parameters.Add("@CUSTOMERTTLPRTDIV", SqlDbType.Int);
                    SqlParameter paraDtlPrcZeroPrtDiv = sqlCommand.Parameters.Add("@DTLPRCZEROPRTDIV", SqlDbType.Int);
                    SqlParameter paraDepoDtlPrcPrtDiv = sqlCommand.Parameters.Add("@DEPODTLPRCPRTDIV", SqlDbType.Int);
                    SqlParameter paraBillHonorificTtl = sqlCommand.Parameters.Add("@BILLHONORIFICTTL", SqlDbType.NVarChar);
                    SqlParameter paraListPricePrtCd = sqlCommand.Parameters.Add("@LISTPRICEPRTCD", SqlDbType.Int);
                    SqlParameter paraPartsNoPrtCd = sqlCommand.Parameters.Add("@PARTSNOPRTCD", SqlDbType.Int);
                    // --- ADD  ���r��  2010/02/18 ---------->>>>>
                    SqlParameter paraAnnotationPrtCd = sqlCommand.Parameters.Add("@ANNOTATIONPRTCD", SqlDbType.Int);
                    // --- ADD  ���r��  2010/02/18 ----------<<<<<

                    // --- ADD  2011/02/16 ---------->>>>>
                    SqlParameter paraCoNmPrintOutCd = sqlCommand.Parameters.Add("@CONMPRINTOUTCD", SqlDbType.Int);
                    // --- ADD  2011/02/16 ----------<<<<<

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdPrtPtnWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(dmdPrtPtnWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(dmdPrtPtnWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.LogicalDeleteCode);
                    paraDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DataInputSystem);
                    paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.SlipPrtKind);
                    paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.SlipPrtSetPaperId);
                    paraSlipComment.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.SlipComment);
                    paraOutputFormFileName.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.OutputFormFileName);
                    paraTopMargin.Value = SqlDataMediator.SqlSetDouble(dmdPrtPtnWork.TopMargin);
                    paraLeftMargin.Value = SqlDataMediator.SqlSetDouble(dmdPrtPtnWork.LeftMargin);
                    paraRightMargin.Value = SqlDataMediator.SqlSetDouble(dmdPrtPtnWork.RightMargin);
                    paraBottomMargin.Value = SqlDataMediator.SqlSetDouble(dmdPrtPtnWork.BottomMargin);
                    paraCopyCount.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.CopyCount);
                    paraDmdTtlFormTitle1.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdTtlFormTitle1);
                    paraDmdTtlFormTitle2.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdTtlFormTitle2);
                    paraDmdTtlFormTitle3.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdTtlFormTitle3);
                    paraDmdTtlFormTitle4.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdTtlFormTitle4);
                    paraDmdTtlFormTitle5.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdTtlFormTitle5);
                    paraDmdTtlFormTitle6.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdTtlFormTitle6);
                    paraDmdTtlFormTitle7.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdTtlFormTitle7);
                    paraDmdTtlFormTitle8.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdTtlFormTitle8);
                    paraDmdTtlSetItemDiv1.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DmdTtlSetItemDiv1);
                    paraDmdTtlSetItemDiv2.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DmdTtlSetItemDiv2);
                    paraDmdTtlSetItemDiv3.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DmdTtlSetItemDiv3);
                    paraDmdTtlSetItemDiv4.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DmdTtlSetItemDiv4);
                    paraDmdTtlSetItemDiv5.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DmdTtlSetItemDiv5);
                    paraDmdTtlSetItemDiv6.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DmdTtlSetItemDiv6);
                    paraDmdTtlSetItemDiv7.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DmdTtlSetItemDiv7);
                    paraDmdTtlSetItemDiv8.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DmdTtlSetItemDiv8);
                    paraDmdFormTitle.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdFormTitle);
                    paraDmdFormTitle2.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdFormTitle2);
                    paraDmdFormComent1.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdFormComent1);
                    paraDmdFormComent2.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdFormComent2);
                    paraDmdFormComent3.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.DmdFormComent3);
                    paraDmdDtlOutlineCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DmdDtlOutlineCode);
                    paraDmdDtlPtnOdrDiv.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DmdDtlPtnOdrDiv);
                    paraSlipTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.SlipTtlPrtDiv);
                    paraAddDayTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.AddDayTtlPrtDiv);
                    paraCustomerTtlPrtDiv.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.CustomerTtlPrtDiv);
                    paraDtlPrcZeroPrtDiv.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DtlPrcZeroPrtDiv);
                    paraDepoDtlPrcPrtDiv.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DepoDtlPrcPrtDiv);
                    paraBillHonorificTtl.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.BillHonorificTtl);
                    paraListPricePrtCd.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.ListPricePrtCd);
                    paraPartsNoPrtCd.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.PartsNoPrtCd);
                    // --- ADD  ���r��  2010/02/18 ---------->>>>>
                    paraAnnotationPrtCd.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.AnnotationPrtCd);
                    // --- ADD  ���r��  2010/02/18 ----------<<<<<

                    // --- ADD  2011/02/16 ---------->>>>>
                    paraCoNmPrintOutCd.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.CoNmPrintOutCd);
                    // --- ADD  2011/02/16 ----------<<<<<<

                    sqlCommand.ExecuteNonQuery();

                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnDB.Write");
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
            }
            
            return status;
        }
        
        #endregion

        #region Delete
        /// <summary>
        /// ����������p�^�[���}�X�^�ݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">����������p�^�[���}�X�^�ݒ�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ����������p�^�[���}�X�^�ݒ���𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                SqlConnection sqlConnection = null;
                SqlTransaction sqlTransaction = null;

                try
                {
                    //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                    if (connectionText == null || connectionText == "") return status;

                    DmdPrtPtnWork dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnWork));

                    sqlConnection = new SqlConnection(connectionText);
                    sqlConnection.Open();

                    // �g�����U�N�V�����J�n
                    sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    status = this.Delete(ref dmdPrtPtnWork, ref sqlConnection, ref sqlTransaction);
                }
                catch (SqlException ex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(ex);
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

                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnDB.Delete");
            }
            return status;
        }

        /// <summary>
        /// ����������p�^�[���}�X�^�ݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">����������p�^�[���}�X�^�ݒ�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ����������p�^�[���}�X�^�ݒ���𕨗��폜���܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.12</br>
        public int Delete(ref DmdPrtPtnWork dmdPrtPtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteProc(ref dmdPrtPtnWork, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// ����������p�^�[���}�X�^�ݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">����������p�^�[���}�X�^�ݒ�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ����������p�^�[���}�X�^�ݒ���𕨗��폜���܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.12</br>
        private int DeleteProc(ref DmdPrtPtnWork dmdPrtPtnWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try 
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM DMDPRTPTNRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection,sqlTransaction))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                    SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.EnterpriseCode);
                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DataInputSystem);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.SlipPrtKind);
                    findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.SlipPrtSetPaperId);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != dmdPrtPtnWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            return status;
                        }
                        
                        sqlCommand.CommandText = "DELETE FROM DMDPRTPTNRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";

                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.SlipPrtKind);
                        findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.SlipPrtSetPaperId);

                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }
                    if (!myReader.IsClosed) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }   
            catch (SqlException ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnDB.Delete");
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
            }
            
            return status;
        
        }
        #endregion

        #region LogicalDelete & Revival
        /// <summary>
        /// ����������p�^�[���}�X�^�ݒ����_���폜���܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���}�X�^�ݒ����_���폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int LogicalDelete(ref byte[] parabyte)
        {
            try
            {
                return LogicalDeleteProc(ref parabyte, 0);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnDB.LogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// �_���폜����������p�^�[���}�X�^�ݒ���𕜊����܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜����������p�^�[���}�X�^�ݒ���𕜊����܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        public int Revival(ref byte[] parabyte)
        {
            try
            {
                return LogicalDeleteProc(ref parabyte, 1);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DmdPrtPtnDB.Revival");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// ����������p�^�[���}�X�^�ݒ���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="parabyte">DmdPrtPtnWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����������p�^�[���}�X�^�ݒ���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.07.02</br>
        private int LogicalDeleteProc(ref byte[] parabyte, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // XML�̓ǂݍ���
                DmdPrtPtnWork dmdPrtPtnWork = (DmdPrtPtnWork)XmlByteSerializer.Deserialize(parabyte, typeof(DmdPrtPtnWork));

                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF , LOGICALDELETECODERF FROM DMDPRTPTNRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID", sqlConnection))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                    SqlParameter findParaSlipPrtSetPaperId = sqlCommand.Parameters.Add("@FINDSLIPPRTSETPAPERID", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.EnterpriseCode);
                    findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DataInputSystem);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.SlipPrtKind);
                    findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.SlipPrtSetPaperId);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != dmdPrtPtnWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                        //���݂̘_���폜�敪���擾
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE DMDPRTPTNRF SET UPDATEDATETIMERF=@UPDATEDATETIME, UPDEMPLOYEECODERF=@UPDEMPLOYEECODE, UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM AND SLIPPRTKINDRF=@FINDSLIPPRTKIND AND SLIPPRTSETPAPERIDRF=@FINDSLIPPRTSETPAPERID";

                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.EnterpriseCode);
                        findParaDataInputSystem.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.DataInputSystem);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.SlipPrtKind);
                        findParaSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(dmdPrtPtnWork.SlipPrtSetPaperId);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)dmdPrtPtnWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (!myReader.IsClosed) myReader.Close();
                        sqlConnection.Close();
                        return status;
                    }
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();

                    //�_���폜���[�h�̏ꍇ
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 3)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                        else if (logicalDelCd == 0) dmdPrtPtnWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                        else dmdPrtPtnWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                    }
                    else
                    {
                        if (logicalDelCd == 1) dmdPrtPtnWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                    }

                    //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraUpdateDateTime    = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdEmployeeCode   = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1    = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2    = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                    paraUpdateDateTime.Value    = SqlDataMediator.SqlSetDateTimeFromTicks(dmdPrtPtnWork.UpdateDateTime);
                    paraUpdEmployeeCode.Value   = SqlDataMediator.SqlSetString(dmdPrtPtnWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value    = SqlDataMediator.SqlSetString(dmdPrtPtnWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value    = SqlDataMediator.SqlSetString(dmdPrtPtnWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(dmdPrtPtnWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();

                    // XML�֕ϊ����A������̃o�C�i����(�X�V���ʂ�߂��j
                    parabyte = XmlByteSerializer.Serialize(dmdPrtPtnWork);
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
                if (myReader.IsClosed == false) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }

            return status;

        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� DmdPrtPtnWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockMngTtlStWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.09</br>
        /// <br>Update Note: 2011/02/16  �{�w�C��<br>																								
        /// <br>           : ���Ж��󎚋敪��ǉ�<br>	
        /// </remarks>
        private DmdPrtPtnWork CopyToDmdPrtPtnWorkFromReader(ref SqlDataReader myReader)
        {
            DmdPrtPtnWork wkDmdPrtPtnWork = new DmdPrtPtnWork();

            #region �N���X�֊i�[
            wkDmdPrtPtnWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkDmdPrtPtnWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkDmdPrtPtnWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkDmdPrtPtnWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkDmdPrtPtnWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkDmdPrtPtnWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkDmdPrtPtnWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkDmdPrtPtnWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkDmdPrtPtnWork.DataInputSystem = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATAINPUTSYSTEMRF"));
            wkDmdPrtPtnWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKINDRF"));
            wkDmdPrtPtnWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
            wkDmdPrtPtnWork.SlipComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPCOMMENTRF"));
            wkDmdPrtPtnWork.OutputFormFileName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTFORMFILENAMERF"));
            wkDmdPrtPtnWork.TopMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOPMARGINRF"));
            wkDmdPrtPtnWork.LeftMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LEFTMARGINRF"));
            wkDmdPrtPtnWork.RightMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RIGHTMARGINRF"));
            wkDmdPrtPtnWork.BottomMargin = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BOTTOMMARGINRF"));
            wkDmdPrtPtnWork.CopyCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COPYCOUNTRF"));
            wkDmdPrtPtnWork.DmdTtlFormTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDTTLFORMTITLE1RF"));
            wkDmdPrtPtnWork.DmdTtlFormTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDTTLFORMTITLE2RF"));
            wkDmdPrtPtnWork.DmdTtlFormTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDTTLFORMTITLE3RF"));
            wkDmdPrtPtnWork.DmdTtlFormTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDTTLFORMTITLE4RF"));
            wkDmdPrtPtnWork.DmdTtlFormTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDTTLFORMTITLE5RF"));
            wkDmdPrtPtnWork.DmdTtlFormTitle6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDTTLFORMTITLE6RF"));
            wkDmdPrtPtnWork.DmdTtlFormTitle7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDTTLFORMTITLE7RF"));
            wkDmdPrtPtnWork.DmdTtlFormTitle8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDTTLFORMTITLE8RF"));
            wkDmdPrtPtnWork.DmdTtlSetItemDiv1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDTTLSETITEMDIV1RF"));
            wkDmdPrtPtnWork.DmdTtlSetItemDiv2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDTTLSETITEMDIV2RF"));
            wkDmdPrtPtnWork.DmdTtlSetItemDiv3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDTTLSETITEMDIV3RF"));
            wkDmdPrtPtnWork.DmdTtlSetItemDiv4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDTTLSETITEMDIV4RF"));
            wkDmdPrtPtnWork.DmdTtlSetItemDiv5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDTTLSETITEMDIV5RF"));
            wkDmdPrtPtnWork.DmdTtlSetItemDiv6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDTTLSETITEMDIV6RF"));
            wkDmdPrtPtnWork.DmdTtlSetItemDiv7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDTTLSETITEMDIV7RF"));
            wkDmdPrtPtnWork.DmdTtlSetItemDiv8 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDTTLSETITEMDIV8RF"));
            wkDmdPrtPtnWork.DmdFormTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDFORMTITLERF"));
            wkDmdPrtPtnWork.DmdFormTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDFORMTITLE2RF"));
            wkDmdPrtPtnWork.DmdFormComent1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDFORMCOMENT1RF"));
            wkDmdPrtPtnWork.DmdFormComent2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDFORMCOMENT2RF"));
            wkDmdPrtPtnWork.DmdFormComent3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DMDFORMCOMENT3RF"));
            wkDmdPrtPtnWork.DmdDtlOutlineCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDDTLOUTLINECODERF"));
            wkDmdPrtPtnWork.DmdDtlPtnOdrDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDDTLPTNODRDIVRF"));
            wkDmdPrtPtnWork.SlipTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPTTLPRTDIVRF"));
            wkDmdPrtPtnWork.AddDayTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDDAYTTLPRTDIVRF"));
            wkDmdPrtPtnWork.CustomerTtlPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTTLPRTDIVRF"));
            wkDmdPrtPtnWork.DtlPrcZeroPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DTLPRCZEROPRTDIVRF"));
            wkDmdPrtPtnWork.DepoDtlPrcPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPODTLPRCPRTDIVRF"));
            wkDmdPrtPtnWork.BillHonorificTtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLHONORIFICTTLRF"));
            wkDmdPrtPtnWork.ListPricePrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRTCDRF"));
            wkDmdPrtPtnWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNOPRTCDRF"));
            // --- ADD  ���r��  2010/02/18 ---------->>>>>
            wkDmdPrtPtnWork.AnnotationPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANNOTATIONPRTCDRF"));
            // --- ADD  ���r��  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            wkDmdPrtPtnWork.CoNmPrintOutCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONMPRINTOUTCDRF"));
            // --- ADD  2011/02/16 ----------<<<<<

             #endregion

            return wkDmdPrtPtnWork;
        }
        #endregion
        
        
    }
}


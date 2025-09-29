//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����[�g�`���ݒ�}�X�^�����e
// �v���O�����T�v   : �����[�g�`���ݒ�}�X�^�����eDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011.08.03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// Update Note      :   2011.09.16 wangl2                               //
//                  :   1.PCC-UOE�̑Ή��A��Q�� #24982�Ή�            //
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����[�g�`���ݒ�}�X�^�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011.08.03</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RmSlpPrtStDB : RemoteDB, IRmSlpPrtStDB
    {
        #region [�N���X�R���X�g���N�^]
        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        public RmSlpPrtStDB()
            :
            base("PMKHN09666D", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork", "RMSLPPRTSTRF")
        {
        }
        #endregion

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^���LIST�̖ߏ���
        /// </summary>
        /// <param name="rmSlpPrtStWork">��������</param>
        /// <param name="pararmSlpPrtStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        public int Search(out object rmSlpPrtStWork, RmSlpPrtStWork pararmSlpPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            rmSlpPrtStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchRmSlpPrtStProc(out rmSlpPrtStWork, pararmSlpPrtStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RmSlpPrtStDB.Search");
                rmSlpPrtStWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^���LIST�̑S�Ėߏ���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objrmSlpPrtStWork">��������</param>
        /// <param name="pararmSlpPrtStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        public int SearchRmSlpPrtStProc(out object objrmSlpPrtStWork, RmSlpPrtStWork pararmSlpPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            ArrayList rmSlpPrtStWorkList = new ArrayList();
            int status = SearchRmSlpPrtStProc(out rmSlpPrtStWorkList, pararmSlpPrtStWork, readMode, logicalMode, ref sqlConnection);
            objrmSlpPrtStWork = rmSlpPrtStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^���LIST�̖ߏ���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">��������</param>
        /// <param name="rmSlpPrtStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        public int SearchRmSlpPrtStProc(out ArrayList rmSlpPrtStWorkList, RmSlpPrtStWork rmSlpPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchRmSlpPrtStProcProc(out rmSlpPrtStWorkList, rmSlpPrtStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^���LIST�̖ߏ���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">��������</param>
        /// <param name="rmSlpPrtStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        private int SearchRmSlpPrtStProcProc(out ArrayList rmSlpPrtStWorkList, RmSlpPrtStWork rmSlpPrtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder sqlTxt = new StringBuilder();
                sqlTxt.Append("SELECT RMSLPPRT.CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.PCCCOMPANYCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.SLIPPRTKINDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.SLIPPRTSETPAPERIDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.RMTSLPPRTDIVRF").Append(Environment.NewLine);
                // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                sqlTxt.Append("    ,RMSLPPRT.TOPMARGINRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,RMSLPPRT.LEFTMARGINRF").Append(Environment.NewLine);
                // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
                sqlTxt.Append(" FROM RMSLPPRTSTRF RMSLPPRT WITH (READUNCOMMITTED) ").Append(Environment.NewLine);

                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, rmSlpPrtStWork, logicalMode);
                //�^�C���A�E�g���Ԃ̐ݒ�
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();

                int createDateTime_ColIndex = 0;
                int updateDateTime_ColIndex = 0;
                int logicalDeleteCode_ColIndex = 0;
                int inqOriginalEpCd_ColIndex = 0;
                int inqOriginalSecCd_ColIndex = 0;
                int inqOtherEpCd_ColIndex = 0;
                int inqOtherSecCd_ColIndex = 0;
                int pccCompanyCode_ColIndex = 0;
                int rmtSlpPrtDiv_ColIndex = 0;
                int slipPrtSetPaperId_ColIndex = 0;
                int slipPrtKind_ColIndex = 0;
                // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                int topMargin_ColIndex = 0;
                int leftMargin_ColIndex = 0;
                // Add wangl2 on 2011.09.16 For ��Q�� #24982 END

                if (myReader.HasRows)
                {
                    createDateTime_ColIndex = myReader.GetOrdinal("CREATEDATETIMERF");
                    updateDateTime_ColIndex = myReader.GetOrdinal("UPDATEDATETIMERF");
                    logicalDeleteCode_ColIndex = myReader.GetOrdinal("LOGICALDELETECODERF");
                    inqOriginalEpCd_ColIndex = myReader.GetOrdinal("INQORIGINALEPCDRF");
                    inqOriginalSecCd_ColIndex = myReader.GetOrdinal("INQORIGINALSECCDRF");
                    inqOtherEpCd_ColIndex = myReader.GetOrdinal("INQOTHEREPCDRF");
                    inqOtherSecCd_ColIndex = myReader.GetOrdinal("INQOTHERSECCDRF");
                    pccCompanyCode_ColIndex = myReader.GetOrdinal("PCCCOMPANYCODERF");
                    rmtSlpPrtDiv_ColIndex = myReader.GetOrdinal("RMTSLPPRTDIVRF");
                    slipPrtSetPaperId_ColIndex = myReader.GetOrdinal("SLIPPRTSETPAPERIDRF");
                    slipPrtKind_ColIndex = myReader.GetOrdinal("SLIPPRTKINDRF");
                    // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                    topMargin_ColIndex = myReader.GetOrdinal("TOPMARGINRF");
                    leftMargin_ColIndex = myReader.GetOrdinal("LEFTMARGINRF");
                    // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
                }

                while (myReader.Read())
                {
                    //SqlDataReader�������Y��ƕ��i�W��ݒ胏�[�N�Z�b�g����                   
                    RmSlpPrtStWork wkRmSlpPrtStWork = new RmSlpPrtStWork();

                    wkRmSlpPrtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, createDateTime_ColIndex);   // �쐬����
                    wkRmSlpPrtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, updateDateTime_ColIndex);   // �X�V����
                    wkRmSlpPrtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, logicalDeleteCode_ColIndex);         // �_���폜�敪
                    wkRmSlpPrtStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, inqOriginalEpCd_ColIndex).Trim();     // �⍇������ƃR�[�h//@@@@20230303
                    wkRmSlpPrtStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, inqOriginalSecCd_ColIndex);          // �⍇�������_�R�[�h
                    wkRmSlpPrtStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, inqOtherEpCd_ColIndex);                  // �⍇�����ƃR�[�h
                    wkRmSlpPrtStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, inqOtherSecCd_ColIndex);                // �⍇���拒�_�R�[�h
                    wkRmSlpPrtStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, pccCompanyCode_ColIndex);               // PCC���ЃR�[�h
                    wkRmSlpPrtStWork.RmtSlpPrtDiv = SqlDataMediator.SqlGetInt32(myReader, rmtSlpPrtDiv_ColIndex);                   // �`�[������
                    wkRmSlpPrtStWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, slipPrtSetPaperId_ColIndex);        // �`�[����ݒ�p���[ID
                    wkRmSlpPrtStWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, slipPrtKind_ColIndex);                     // �����[�g�`���敪
                    // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                    wkRmSlpPrtStWork.TopMargin = SqlDataMediator.SqlGetDouble(myReader, topMargin_ColIndex);                        //��]��
                    wkRmSlpPrtStWork.LeftMargin = SqlDataMediator.SqlGetDouble(myReader, leftMargin_ColIndex);                      //���]��
                    // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
                    al.Add(wkRmSlpPrtStWork);

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
                    if (!myReader.IsClosed) myReader.Close();
            }

            rmSlpPrtStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^�̖ߏ���
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        public int Read(ref RmSlpPrtStWork rmSlpPrtStWork, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref rmSlpPrtStWork, readMode, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RmSlpPrtStDB.Read");
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
        /// �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^�̖ߏ���((�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃����[�g�`���ݒ�}�X�^�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        private int ReadProc(ref RmSlpPrtStWork rmSlpPrtStWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, " +
                                                       "INQOTHEREPCDRF, INQOTHERSECCDRF, PCCCOMPANYCODERF, SLIPPRTKINDRF, SLIPPRTSETPAPERIDRF, RMTSLPPRTDIVRF,TOPMARGINRF,LEFTMARGINRF " +
                                                       "FROM RMSLPPRTSTRF WITH (READUNCOMMITTED) WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND " +
                                                       "INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND SLIPPRTKINDRF=@FINDSLIPPRTKIND", sqlConnection))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    int createDateTime_ColIndex = 0;
                    int updateDateTime_ColIndex = 0;
                    int logicalDeleteCode_ColIndex = 0;
                    int inqOriginalEpCd_ColIndex = 0;
                    int inqOriginalSecCd_ColIndex = 0;
                    int inqOtherEpCd_ColIndex = 0;
                    int inqOtherSecCd_ColIndex = 0;
                    int pccCompanyCode_ColIndex = 0;
                    int rmtSlpPrtDiv_ColIndex = 0;
                    int slipPrtSetPaperId_ColIndex = 0;
                    int slipPrtKind_ColIndex = 0;
                    // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                    int topMargin_ColIndex = 0;
                    int leftMargin_ColIndex = 0;
                    // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
                    if (myReader.HasRows)
                    {
                        createDateTime_ColIndex = myReader.GetOrdinal("CREATEDATETIMERF");
                        updateDateTime_ColIndex = myReader.GetOrdinal("UPDATEDATETIMERF");
                        logicalDeleteCode_ColIndex = myReader.GetOrdinal("LOGICALDELETECODERF");
                        inqOriginalEpCd_ColIndex = myReader.GetOrdinal("INQORIGINALEPCDRF");
                        inqOriginalSecCd_ColIndex = myReader.GetOrdinal("INQORIGINALSECCDRF");
                        inqOtherEpCd_ColIndex = myReader.GetOrdinal("INQOTHEREPCDRF");
                        inqOtherSecCd_ColIndex = myReader.GetOrdinal("INQOTHERSECCDRF");
                        pccCompanyCode_ColIndex = myReader.GetOrdinal("PCCCOMPANYCODERF");
                        rmtSlpPrtDiv_ColIndex = myReader.GetOrdinal("RMTSLPPRTDIVRF");
                        slipPrtSetPaperId_ColIndex = myReader.GetOrdinal("SLIPPRTSETPAPERIDRF");
                        slipPrtKind_ColIndex = myReader.GetOrdinal("SLIPPRTKINDRF");
                        // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                        topMargin_ColIndex = myReader.GetOrdinal("TOPMARGINRF");
                        leftMargin_ColIndex = myReader.GetOrdinal("LEFTMARGINRF");
                        // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
                    }

                    if (myReader.Read())
                    {
                        rmSlpPrtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, createDateTime_ColIndex);   // �쐬����
                        rmSlpPrtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, updateDateTime_ColIndex);   // �X�V����
                        rmSlpPrtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, logicalDeleteCode_ColIndex);         // �_���폜�敪
                        rmSlpPrtStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, inqOriginalEpCd_ColIndex).Trim();     // �⍇������ƃR�[�h//@@@@20230303
                        rmSlpPrtStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, inqOriginalSecCd_ColIndex);          // �⍇�������_�R�[�h
                        rmSlpPrtStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, inqOtherEpCd_ColIndex);                  // �⍇�����ƃR�[�h
                        rmSlpPrtStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, inqOtherSecCd_ColIndex);                // �⍇���拒�_�R�[�h
                        rmSlpPrtStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, pccCompanyCode_ColIndex);               // PCC���ЃR�[�h
                        rmSlpPrtStWork.RmtSlpPrtDiv = SqlDataMediator.SqlGetInt32(myReader, rmtSlpPrtDiv_ColIndex);                   // �`�[������
                        rmSlpPrtStWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, slipPrtSetPaperId_ColIndex);        // �`�[����ݒ�p���[ID
                        rmSlpPrtStWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, slipPrtKind_ColIndex);
                        // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                        rmSlpPrtStWork.TopMargin = SqlDataMediator.SqlGetDouble(myReader, topMargin_ColIndex);                        //��]��
                        rmSlpPrtStWork.LeftMargin = SqlDataMediator.SqlGetDouble(myReader, leftMargin_ColIndex);                      //���]��
                        // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�}�X�^���̓o�^�A�X�V����
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        public int Write(ref object rmSlpPrtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(rmSlpPrtStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);


                //write���s
                status = WriteRmSlpPrtStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                rmSlpPrtStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RmSlpPrtStDB.Write(ref object rmSlpPrtStWork)");
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
        /// �����[�g�`���ݒ�}�X�^�}�X�^���̓o�^�A�X�V����(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        public int WriteRmSlpPrtStProc(ref ArrayList rmSlpPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteRmSlpPrtStProcProc(ref rmSlpPrtStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�}�X�^���̓o�^�A�X�V����(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        private int WriteRmSlpPrtStProcProc(ref ArrayList rmSlpPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StringBuilder sqlTxt = new StringBuilder();
            try
            {
                if (rmSlpPrtStWorkList != null)
                {
                    for (int i = 0; i < rmSlpPrtStWorkList.Count; i++)
                    {
                        RmSlpPrtStWork rmSlpPrtStWork = rmSlpPrtStWorkList[i] as RmSlpPrtStWork;



                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF,INQOTHEREPCDRF FROM RMSLPPRTSTRF " +
                                                               "WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND " +
                                                               "INQORIGINALSECCDRF = @FINDINQORIGINALSECCD AND " +
                                                               "INQOTHEREPCDRF = @FINDINQOTHEREPCD AND " +
                                                               "INQOTHERSECCDRF = @FINDINQOTHERSECCD AND " +
                                                               "SLIPPRTKINDRF=@FINDSLIPPRTKIND ", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                        findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != rmSlpPrtStWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (rmSlpPrtStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            //Update�R�}���h�̐���
                            StringBuilder sqlTxtsb = new StringBuilder();
                            sqlTxtsb.Append("UPDATE RMSLPPRTSTRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , INQORIGINALEPCDRF=@INQORIGINALEPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , INQORIGINALSECCDRF=@INQORIGINALSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , PCCCOMPANYCODERF=@PCCCOMPANYCODE").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , SLIPPRTKINDRF=@SLIPPRTKIND").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , SLIPPRTSETPAPERIDRF=@SLIPPRTSETPAPERID").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , RMTSLPPRTDIVRF=@RMTSLPPRTDIV").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                            sqlTxtsb.Append(" , TOPMARGINRF=@TOPMARGIN").Append(Environment.NewLine);
                            sqlTxtsb.Append(" , LEFTMARGINRF=@LEFTMARGIN").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
                            sqlTxtsb.Append(" WHERE ").Append(Environment.NewLine);
                            sqlTxtsb.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("  AND SLIPPRTKINDRF = @FINDSLIPPRTKIND").Append(Environment.NewLine);

                            sqlCommand.CommandText = sqlTxtsb.ToString();


                            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                            rmSlpPrtStWork.UpdateDateTime = DateTime.Now;

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rmSlpPrtStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (rmSlpPrtStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }
                            StringBuilder sqlTxtsb = new StringBuilder();
                            //�V�K�쐬����SQL���𐶐�
                            sqlTxtsb.Append("INSERT INTO RMSLPPRTSTRF").Append(Environment.NewLine);
                            sqlTxtsb.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,PCCCOMPANYCODERF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,SLIPPRTKINDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,SLIPPRTSETPAPERIDRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,RMTSLPPRTDIVRF").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                            sqlTxtsb.Append("    ,TOPMARGINRF").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,LEFTMARGINRF").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
                            sqlTxtsb.Append(" )").Append(Environment.NewLine);
                            sqlTxtsb.Append(" VALUES").Append(Environment.NewLine);
                            sqlTxtsb.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@INQORIGINALEPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@INQORIGINALSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@PCCCOMPANYCODE").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@SLIPPRTKIND").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@SLIPPRTSETPAPERID").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@RMTSLPPRTDIV").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                            sqlTxtsb.Append("    ,@TOPMARGIN").Append(Environment.NewLine);
                            sqlTxtsb.Append("    ,@LEFTMARGIN").Append(Environment.NewLine);
                            // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
                            sqlTxtsb.Append(" )").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlTxtsb.ToString();

                            //�o�^�w�b�_����ݒ�
                            rmSlpPrtStWork.UpdateDateTime = DateTime.Now;
                            rmSlpPrtStWork.CreateDateTime = DateTime.Now;
                            rmSlpPrtStWork.LogicalDeleteCode = 0;

                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rmSlpPrtStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter paraInqOriginalSeCd1 = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter paraInqOtherEpCd1 = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter paraInqOtherSeCd1 = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter paraPccCompanyCode = sqlCommand.Parameters.Add("@PCCCOMPANYCODE", SqlDbType.Int);
                        SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@SLIPPRTKIND", SqlDbType.Int);
                        SqlParameter paraSlipPrtSetPaperId = sqlCommand.Parameters.Add("@SLIPPRTSETPAPERID", SqlDbType.NVarChar);
                        SqlParameter paraRmtSlpPrtDiv = sqlCommand.Parameters.Add("@RMTSLPPRTDIV", SqlDbType.Int);
                        // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                        SqlParameter paraTopMargin = sqlCommand.Parameters.Add("@TOPMARGIN", SqlDbType.Float);
                        SqlParameter paraLeftMargin = sqlCommand.Parameters.Add("@LEFTMARGIN", SqlDbType.Float);
                        // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rmSlpPrtStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rmSlpPrtStWork.UpdateDateTime);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.LogicalDeleteCode);
                        paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                        paraInqOriginalSeCd1.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                        paraInqOtherEpCd1.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                        paraInqOtherSeCd1.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                        paraPccCompanyCode.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.PccCompanyCode);
                        paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);
                        paraSlipPrtSetPaperId.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.SlipPrtSetPaperId);
                        paraRmtSlpPrtDiv.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.RmtSlpPrtDiv);
                        // Add wangl2 on 2011.09.16 For ��Q�� #24982 STA
                        paraTopMargin.Value = SqlDataMediator.SqlSetDouble(rmSlpPrtStWork.TopMargin);
                        paraLeftMargin.Value = SqlDataMediator.SqlSetDouble(rmSlpPrtStWork.LeftMargin);
                        // Add wangl2 on 2011.09.16 For ��Q�� #24982 END
                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);


                        sqlCommand.ExecuteNonQuery();
                        al.Add(rmSlpPrtStWork);
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rmSlpPrtStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�}�X�^���̘_���폜����
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        public int LogicalDelete(ref object rmSlpPrtStWork)
        {
            return LogicalDeleteRmSlpPrtSt(ref rmSlpPrtStWork, 0);
        }

        /// <summary>
        /// �_���폜�����[�g�`���ݒ�}�X�^�}�X�^���̕�������
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�����[�g�`���ݒ�}�X�^�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        public int RevivalLogicalDelete(ref object rmSlpPrtStWork)
        {
            return LogicalDeleteRmSlpPrtSt(ref rmSlpPrtStWork, 1);
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�}�X�^���̘_���폜����
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        private int LogicalDeleteRmSlpPrtSt(ref object rmSlpPrtStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(rmSlpPrtStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteRmSlpPrtStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "RmSlpPrtStDB.LogicalDeleteRmSlpPrtSt :" + procModestr);

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
        /// �����[�g�`���ݒ�}�X�^�}�X�^���̘_���폜����(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        public int LogicalDeleteRmSlpPrtStProc(ref ArrayList rmSlpPrtStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteRmSlpPrtStProcProc(ref rmSlpPrtStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�}�X�^���̘_���폜����(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        private int LogicalDeleteRmSlpPrtStProcProc(ref ArrayList rmSlpPrtStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StringBuilder sqlTxt = new StringBuilder();
            try
            {
                if (rmSlpPrtStWorkList != null)
                {
                    for (int i = 0; i < rmSlpPrtStWorkList.Count; i++)
                    {
                        RmSlpPrtStWork rmSlpPrtStWork = rmSlpPrtStWorkList[i] as RmSlpPrtStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF,LOGICALDELETECODERF FROM RMSLPPRTSTRF " +
                                                               "WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND " +
                                                               "INQORIGINALSECCDRF = @FINDINQORIGINALSECCD AND " +
                                                               "INQOTHEREPCDRF = @FINDINQOTHEREPCD AND " +
                                                               "INQOTHERSECCDRF = @FINDINQOTHERSECCD AND " +
                                                               "SLIPPRTKINDRF=@FINDSLIPPRTKIND ", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);


                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                        findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);


                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != rmSlpPrtStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));


                            sqlTxt = new StringBuilder();
                            sqlTxt.Append("UPDATE RMSLPPRTSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                            sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                            sqlTxt.Append(" WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                            sqlTxt.Append("    AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                            sqlTxt.Append("    AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                            sqlTxt.Append("    AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                            sqlTxt.Append("    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlTxt.ToString();

                            //Parameter�I�u�W�F�N�g�֒l�ݒ�
                            findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                            findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                            findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)rmSlpPrtStWork;
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
                            else if (logicalDelCd == 0) rmSlpPrtStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else rmSlpPrtStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) rmSlpPrtStWork.LogicalDeleteCode = 0;   //�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;   // ���S�폜�̓f�[�^�Ȃ���߂�
                                sqlCommand.Cancel();
                                return status;
                            }
                        }

                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.LogicalDeleteCode);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(rmSlpPrtStWork.UpdateDateTime);

                        //�^�C���A�E�g���Ԃ̐ݒ�
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);


                        sqlCommand.ExecuteNonQuery();
                        al.Add(rmSlpPrtStWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            rmSlpPrtStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�}�X�^���̕����폜����
        /// </summary>
        /// <param name="parabyte">�����[�g�`���ݒ�}�X�^�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
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

                status = DeleteRmSlpPrtStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "RmSlpPrtStDB.Delete");
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
        /// �����[�g�`���ݒ�}�X�^�}�X�^���̕����폜����(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">�����[�g�`���ݒ�}�X�^�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        public int DeleteRmSlpPrtStProc(ArrayList rmSlpPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteRmSlpPrtStProcProc(rmSlpPrtStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^�}�X�^���̕����폜����(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="rmSlpPrtStWorkList">�����[�g�`���ݒ�}�X�^�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        private int DeleteRmSlpPrtStProcProc(ArrayList rmSlpPrtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlTxt = new StringBuilder();
            try
            {
                for (int i = 0; i < rmSlpPrtStWorkList.Count; i++)
                {
                    RmSlpPrtStWork rmSlpPrtStWork = rmSlpPrtStWorkList[i] as RmSlpPrtStWork;

                    //Select�R�}���h�̐���
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF FROM RMSLPPRTSTRF " +
                                                           "WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND " +
                                                           "INQORIGINALSECCDRF = @FINDINQORIGINALSECCD AND " +
                                                           "INQOTHEREPCDRF = @FINDINQOTHEREPCD AND " +
                                                           "INQOTHERSECCDRF = @FINDINQOTHERSECCD AND " +
                                                           "SLIPPRTKINDRF=@FINDSLIPPRTKIND ", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                    findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);


                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != rmSlpPrtStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlTxt.Append("DELETE").Append(Environment.NewLine);
                        sqlTxt.Append(" FROM RMSLPPRTSTRF").Append(Environment.NewLine);
                        sqlTxt.Append(" WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                        sqlTxt.Append("    AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                        sqlTxt.Append("    AND INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                        sqlTxt.Append("    AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                        sqlTxt.Append("    AND SLIPPRTKINDRF=@FINDSLIPPRTKIND").Append(Environment.NewLine);
                        sqlCommand.CommandText = sqlTxt.ToString();
                        sqlTxt = new StringBuilder();

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
                        findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
                        findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);
                        findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
                        findParaSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    //�^�C���A�E�g���Ԃ̐ݒ�
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

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
                    if (myReader.IsClosed == false) myReader.Close();
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
        /// �������������񐶐��{�����l�ݒ菈��
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="rmSlpPrtStWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, RmSlpPrtStWork rmSlpPrtStWork, ConstantManagement.LogicalMode logicalMode)
        {
            StringBuilder retstring = new StringBuilder("WHERE ");

            // �⍇�����ƃR�[�h
            retstring.Append(" RMSLPPRT.INQOTHEREPCDRF=@FINDINQOTHEREPCD ");
            SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherEpCd);


            // �⍇������ƃR�[�h
            if (rmSlpPrtStWork.InqOriginalEpCd.Trim() != string.Empty)	//@@@@20230303
            {
                retstring.Append("AND RMSLPPRT.INQORIGINALEPCDRF=@FINDINQORIGINALEPCD ");
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalEpCd);
            }

            // �⍇�������_�R�[�h
            if (rmSlpPrtStWork.InqOriginalSecCd != string.Empty)
            {
                retstring.Append("AND RMSLPPRT.INQORIGINALSECCDRF=@FINDINQORIGINALSECCD ");
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOriginalSecCd);
            }

            // �⍇���拒�_�R�[�h
            if (rmSlpPrtStWork.InqOtherSecCd != string.Empty)
            {
                retstring.Append("AND RMSLPPRT.INQOTHERSECCDRF=@FINDINQOTHERSECCD ");
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(rmSlpPrtStWork.InqOtherSecCd);
            }

            // �`�[������
            if (rmSlpPrtStWork.SlipPrtKind != 0)
            {
                retstring.Append("AND RMSLPPRT.SLIPPRTKINDRF=@FINDSLIPPRTKIND ");
                SqlParameter paraSlipPrtKind = sqlCommand.Parameters.Add("@FINDSLIPPRTKIND", SqlDbType.Int);
                paraSlipPrtKind.Value = SqlDataMediator.SqlSetInt32(rmSlpPrtStWork.SlipPrtKind);
            }

            if (retstring.ToString().Equals("WHERE "))
            {
                return "";
            }
            else
            {
                return retstring.ToString();
            }
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� RmSlpPrtStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RmSlpPrtStWork</returns>
        /// <remarks>
        /// <br>Note       : �N���X�i�[�������܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private RmSlpPrtStWork CopyToRmSlpPrtStWorkFromReader(ref SqlDataReader myReader)
        {
            RmSlpPrtStWork wkRmSlpPrtStWork = new RmSlpPrtStWork();

            #region �N���X�֊i�[
            wkRmSlpPrtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkRmSlpPrtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkRmSlpPrtStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCD")).Trim();//@@@@20230303
            wkRmSlpPrtStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCD"));
            wkRmSlpPrtStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCD"));
            wkRmSlpPrtStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCD"));
            wkRmSlpPrtStWork.PccCompanyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PCCCOMPANYCODE"));
            wkRmSlpPrtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkRmSlpPrtStWork.RmtSlpPrtDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RMTSLPPRTDIV"));
            wkRmSlpPrtStWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERID"));
            wkRmSlpPrtStWork.SlipPrtKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRTKIND"));
            #endregion

            return wkRmSlpPrtStWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Note       : �p�����[�^�L���X�g�������܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            RmSlpPrtStWork[] RmSlpPrtStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is RmSlpPrtStWork)
                    {
                        RmSlpPrtStWork wkRmSlpPrtStWork = paraobj as RmSlpPrtStWork;
                        if (wkRmSlpPrtStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkRmSlpPrtStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            RmSlpPrtStWorkArray = (RmSlpPrtStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(RmSlpPrtStWork[]));
                        }
                        catch (Exception) { }
                        if (RmSlpPrtStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(RmSlpPrtStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                RmSlpPrtStWork wkRmSlpPrtStWork = (RmSlpPrtStWork)XmlByteSerializer.Deserialize(byteArray, typeof(RmSlpPrtStWork));
                                if (wkRmSlpPrtStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkRmSlpPrtStWork);
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
        /// <br>Note       : SqlConnection�����������܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}

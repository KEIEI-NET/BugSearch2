//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���}�X�^���
// �v���O�����T�v   : �L�����y�[���}�X�^��� �����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00 �쐬�S�� : 杍^
// �C �� ��  2011/07/12  �C�����e : Redmine#22929 �f�[�^�̈�����i�\�[�g���j��ύX�̏C��
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
using Broadleaf.Library.Globarization;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �L�����y�[���}�X�^��� �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���}�X�^��� �����[�g�I�u�W�F�N�g�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>UpdateNote : 2011/07/12 杍^ Redmine#22929 �f�[�^�̈�����i�\�[�g���j��ύX�̏C��</br>
    /// </remarks>
    [Serializable]
    public class CampaignMasterWorkDB : RemoteDB, ICampaignMasterWorkDB
    {
        #region [Constructor]
        /// <summary>
        /// �L�����y�[���}�X�^��� �����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public CampaignMasterWorkDB()
            :
            base("PMKHN08709D", "Broadleaf.Application.Remoting.ParamData.CampaignMasterWork", "CAMPAIGNSTRF")
        {
        }
        #endregion Constructor

        #region [�}�X�^����]

        #region [SearchForMasterType]
        /// <summary>
        /// ��ʂ̔��s�^�C�v���u�}�X�^���X�g�v�̏ꍇ�́A���o�����ɊY������A�f�[�^���擾����B
        /// </summary>
        /// <param name="campaignMasterWork">��������</param>
        /// <param name="campaignMasterPrtWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���������ɊY������\���̃��X�g�𒊏o���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int SearchForMasterType(ref object campaignMasterWork, object campaignMasterPrtWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //������
            campaignMasterWork = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (campaignMasterPrtWork == null) return status;

                #region [�p�����[�^�̃L���X�g]
                //�����p�����[�^
                CampaignMasterPrtWork _campaignMasterPrtWork = campaignMasterPrtWork as CampaignMasterPrtWork;
                ArrayList campaignMasterWorkArray = campaignMasterWork as ArrayList;
                if (campaignMasterWorkArray == null)
                {
                    campaignMasterWorkArray = new ArrayList();
                }
                #endregion

                //�R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //Search���s
                #region

                // �L�����y�[���ݒ�}�X�^�f�[�^����
                status = SearchForMasterTypeProc(ref campaignMasterWorkArray, _campaignMasterPrtWork, readMode, logicalMode, ref sqlConnection);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    //���s���G���[
                    throw new Exception("�������s���G���[�FStatus=" + status.ToString());
                }
                #endregion

                //���s���ʃZ�b�g
                campaignMasterWork = campaignMasterWorkArray;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMasterWorkDB.SearchForMasterType Exception=" + ex.Message);
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
        #endregion  //[SearchForMasterType]

        #region [SearchForMasterTypeProc]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������\���f�[�^�̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="campaignMasterWorkArray">��������</param>
        /// <param name="campaignMasterPrt">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���������ɊY������\���f�[�^�̃��X�g�𒊏o���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int SearchForMasterTypeProc(ref ArrayList campaignMasterWorkArray, CampaignMasterPrtWork campaignMasterPrt, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                sqlCommand.CommandText = MakeMasterSelectString(ref sqlCommand, campaignMasterPrt, logicalMode);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();
                
                while (myReader.Read())
                {
                    object retWork = CopyToResultWorkFromMasterReaderProc(ref myReader, campaignMasterPrt);
                    if (retWork != null)
                    {
                        campaignMasterWorkArray.Add(retWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;                        
                    }
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMasterWorkDB.SearchForMasterTypeProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }
            }

            return status;
        }
        #endregion  //[SearchForMasterTypeProc]

        #region [CampaignMasterWork�p SELECT��]
        /// <summary>
        /// ���X�g���o�N�G���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>���X�g���oSELECT��</returns>
        /// <remarks>
        /// <br>Note       : ���X�g���o�N�G���쐬�B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public string MakeMasterSelectString(ref SqlCommand sqlCommand, object paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            CampaignMasterPrtWork _campaignMasterPrtWork = paramWork as CampaignMasterPrtWork;
            string selectTxt = "";

            // �Ώۃe�[�u��
            #region [Select���쐬]
            selectTxt += " SELECT " + Environment.NewLine;
            selectTxt += "  CAMPST.UPDATEDATETIMERF " + Environment.NewLine;        // �L�����y�[���R�[�h
            selectTxt += " ,CAMPST.CAMPAIGNCODERF " + Environment.NewLine;        // �L�����y�[���R�[�h
            selectTxt += " ,CAMPST.CAMPAIGNNAMERF " + Environment.NewLine;        // �L�����y�[���R�[�h����
            selectTxt += " ,CAMPST.CAMPAIGNOBJDIVRF " + Environment.NewLine;      // �L�����y�[���Ώۋ敪
            selectTxt += " ,CAMPST.APPLYSTADATERF " + Environment.NewLine;        // �K�p�J�n��
            selectTxt += " ,CAMPST.APPLYENDDATERF " + Environment.NewLine;        // �K�p�I����
            selectTxt += " ,CAMPST.CAMPEXECSECCODERF " + Environment.NewLine;     // �L�����y�[�����{���_
            selectTxt += " ,SEC.SECTIONGUIDESNMRF " + Environment.NewLine;         // ���_����
            selectTxt += " ,CAMPLK.CUSTOMERCODERF " + Environment.NewLine;        // ���Ӑ�R�[�h
            selectTxt += " ,CUS.CUSTOMERSNMRF " + Environment.NewLine;            // ���Ӑ旪��          
            selectTxt += " FROM CAMPAIGNSTRF AS CAMPST WITH (READUNCOMMITTED) " + Environment.NewLine;
            // ���_���ݒ�}�X�^.���_�K�C�h���̂��擾����
            selectTxt += " LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
            selectTxt += " ON SEC.ENTERPRISECODERF = CAMPST.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND SEC.SECTIONCODERF = CAMPST.CAMPEXECSECCODERF " + Environment.NewLine;
            selectTxt += " AND SEC.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            // �L�����y�[���֘A�}�X�^.���Ӑ�R�[�h���擾����
            selectTxt += " LEFT JOIN CAMPAIGNLINKRF AS CAMPLK " + Environment.NewLine;
            selectTxt += " ON CAMPLK.ENTERPRISECODERF = CAMPST.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND CAMPLK.CAMPAIGNCODERF = CAMPST.CAMPAIGNCODERF " + Environment.NewLine;
            selectTxt += " AND CAMPLK.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            selectTxt += " AND CAMPST.CAMPAIGNOBJDIVRF = 1 " + Environment.NewLine;
            // ���Ӑ�}�X�^.���Ӑ旪�̂��擾����
            selectTxt += " LEFT JOIN CUSTOMERRF AS CUS " + Environment.NewLine;
            selectTxt += " ON CUS.ENTERPRISECODERF = CAMPLK.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND CUS.CUSTOMERCODERF = CAMPLK.CUSTOMERCODERF " + Environment.NewLine;
            selectTxt += " AND CUS.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            //WHERE���̍쐬
            selectTxt += MakeMasterWhereString(ref sqlCommand, _campaignMasterPrtWork, logicalMode); 
           
            // ORDER BY
            selectTxt += " ORDER BY CAMPST.CAMPAIGNCODERF, CAMPLK.CUSTOMERCODERF " + Environment.NewLine;
            #endregion

            return selectTxt;
        }
        #endregion

        #region [CampaignMasterWork�p WHERE����������]
        /// <summary>
        /// CampaignMasterWork�p WHERE����������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>WHERE��</returns>
        /// <remarks>
        /// <br>Note       : WHERE���쐬�B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string MakeMasterWhereString(ref SqlCommand sqlCommand, CampaignMasterPrtWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " CAMPST.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            // �J�n�L�����y�[���R�[�h
            if (paramWork.CampaignCodeSt != 0)
            {
                retstring += " AND CAMPST.CAMPAIGNCODERF>=@FINDCAMPAIGNCODEST" + Environment.NewLine;
                SqlParameter paraCampaignCodeSt = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODEST", SqlDbType.Int);
                paraCampaignCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CampaignCodeSt);
            }

            // �I���L�����y�[���R�[�h
            if (paramWork.CampaignCodeEd != 0)
            {
                retstring += " AND CAMPST.CAMPAIGNCODERF<=@FINDCAMPAIGNCODEED" + Environment.NewLine;
                SqlParameter paraCampaignCodeEd = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODEED", SqlDbType.Int);
                paraCampaignCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CampaignCodeEd);
            }

            // �J�n���_
            if (!string.IsNullOrEmpty(paramWork.SectionCodeSt))
            {
                retstring += " AND CAMPST.CAMPEXECSECCODERF>=@FINDCAMPEXECSECCODEST" + Environment.NewLine;
                SqlParameter paraCampexecSecCodeSt = sqlCommand.Parameters.Add("@FINDCAMPEXECSECCODEST", SqlDbType.NChar);
                paraCampexecSecCodeSt.Value = SqlDataMediator.SqlSetString(paramWork.SectionCodeSt);
            }

            // �I�����_
            if (!string.IsNullOrEmpty(paramWork.SectionCodeEd))
            {
                retstring += " AND CAMPST.CAMPEXECSECCODERF<=@FINDCAMPEXECSECCODEED" + Environment.NewLine;
                SqlParameter paraCampexecSecCodeEd = sqlCommand.Parameters.Add("@FINDCAMPEXECSECCODEED", SqlDbType.NChar);
                paraCampexecSecCodeEd.Value = SqlDataMediator.SqlSetString(paramWork.SectionCodeEd);
            }

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0))
            {
                retstring += " AND CAMPST.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)0);
            }
            else
            {
                retstring += " AND CAMPST.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)1);
            }
            #endregion

            return retstring;
        }
        #endregion

        #region [CampaignMasterWork����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CampaignMasterWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">��������</param>
        /// <returns>���o����</returns>
        /// <remarks>
        /// <br>Note       : �N���X�i�[���� Reader �� CampaignMasterWork�B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignMasterWork CopyToResultWorkFromMasterReaderProc(ref SqlDataReader myReader, CampaignMasterPrtWork paramWork)
        {
            #region ���o����-�l�Z�b�g
            CampaignMasterWork resultWork = new CampaignMasterWork();
            resultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
            resultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));     // �L�����y�[���R�[�h
            resultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));    // �L�����y�[���R�[�h����
            resultWork.CampaignObjDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNOBJDIVRF")); // �L�����y�[���Ώۋ敪
            resultWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));     // �K�p�J�n��
            resultWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));     // �K�p�I����
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPEXECSECCODERF"));  // �L�����y�[�����{���_
            resultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF")); // ���_����
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));     // ���Ӑ�R�[�h
            resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));      // ���Ӑ旪��
            #endregion

            return resultWork;
        }
        #endregion

        #endregion  //�}�X�^����

        #region [�}�X�^�ȊO����]

        #region [Search]
        /// <summary>
        /// ��ʂ̔��s�^�C�v���u�}�X�^���X�g�v�ȊO�̏ꍇ�́A���o�����ɊY������A�f�[�^���擾����B
        /// </summary>
        /// <param name="campaignMasterWork">��������</param>
        /// <param name="campaignMasterPrtWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���������ɊY������\���̃��X�g�𒊏o���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Search(ref object campaignMasterWork, object campaignMasterPrtWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            //������
            campaignMasterWork = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (campaignMasterPrtWork == null) return status;

                #region [�p�����[�^�̃L���X�g]
                //�����p�����[�^
                CampaignMasterPrtWork _campaignMasterPrtWork = campaignMasterPrtWork as CampaignMasterPrtWork;
                ArrayList campaignMasterWorkArray = campaignMasterWork as ArrayList;
                if (campaignMasterWorkArray == null)
                {
                    campaignMasterWorkArray = new ArrayList();
                }
                #endregion

                //�R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                //Search���s
                #region                
                status = SearchProc(ref campaignMasterWorkArray, _campaignMasterPrtWork, readMode, logicalMode, ref sqlConnection);
                if ((status != (int)ConstantManagement.DB_Status.ctDB_EOF) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
                {
                    //���s���G���[
                    throw new Exception("�������s���G���[�FStatus=" + status.ToString());
                }
                #endregion

                //���s���ʃZ�b�g
                campaignMasterWork = campaignMasterWorkArray;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMasterWorkDB.Search Exception=" + ex.Message);
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
        #endregion  //[SearchForMasterType]

        #region [SearchProc]
        /// <summary>
        /// �w�肳�ꂽ���������ɊY������\���f�[�^�̃��X�g�𒊏o���܂�
        /// </summary>
        /// <param name="campaignMasterWorkArray">��������(����f�[�^)</param>
        /// <param name="campaignMasterPrt">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���������ɊY������\���f�[�^�̃��X�g�𒊏o���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int SearchProc(ref ArrayList campaignMasterWorkArray, CampaignMasterPrtWork campaignMasterPrt, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                sqlCommand.CommandText = MakeSelectString(ref sqlCommand, campaignMasterPrt, logicalMode);

                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();
               
                while (myReader.Read())
                {
                    object retWork = CopyToResultWorkFromReaderProc(ref myReader, campaignMasterPrt);
                    if (retWork != null)
                    {
                        campaignMasterWorkArray.Add(retWork);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CampaignMasterWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }
            }

            return status;
        }
        #endregion  //[SearchRefProc]

        #region [CampaignMasterWork�p SELECT��]
        /// <summary>
        /// ���X�g���o�N�G���쐬
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>���X�g���oSELECT��</returns>
        /// <remarks>
        /// <br>Note       : ���X�g���o�N�G���쐬�B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/12 杍^ Redmine#22929 �f�[�^�̈�����i�\�[�g���j��ύX�̏C��</br>
        /// </remarks>
        public string MakeSelectString(ref SqlCommand sqlCommand, object paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            CampaignMasterPrtWork _campaignMasterPrtWork = paramWork as CampaignMasterPrtWork;
            string selectTxt = "";

            // �Ώۃe�[�u��
            #region [Select���쐬]
            selectTxt += " SELECT " + Environment.NewLine;
            selectTxt += "    CAMPMNG.CREATEDATETIMERF " + Environment.NewLine;       // �쐬����
            selectTxt += "   ,CAMPMNG.UPDATEDATETIMERF " + Environment.NewLine;       // �X�V����
            selectTxt += "   ,CAMPMNG.CAMPAIGNCODERF " + Environment.NewLine;         // �L�����y�[���R�[�h
            selectTxt += "   ,CAMPMNG.SECTIONCODERF " + Environment.NewLine;          // ���_�R�[�h
            selectTxt += "   ,CAMPMNG.BLGOODSCODERF " + Environment.NewLine;          // BL���i�R�[�h
            selectTxt += "   ,CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine;         // ���i���[�J�[�R�[�h
            selectTxt += "   ,CAMPMNG.GOODSNORF " + Environment.NewLine;              // ���i�ԍ�
            selectTxt += "   ,CAMPMNG.BLGROUPCODERF " + Environment.NewLine;          // BL�O���[�v�R�[�h
            selectTxt += "   ,CAMPMNG.SALESCODERF " + Environment.NewLine;            // �̔��敪�R�[�h
            selectTxt += "   ,CAMPMNG.SALESPRICESETDIVRF " + Environment.NewLine;     // �����ݒ�敪
            selectTxt += "   ,CAMPMNG.CUSTOMERCODERF " + Environment.NewLine;         // ���Ӑ�R�[�h
            selectTxt += "   ,CAMPMNG.PRICEFLRF " + Environment.NewLine;              // ���i�i�����j
            selectTxt += "   ,CAMPMNG.RATEVALRF " + Environment.NewLine;              // �|��
            selectTxt += "   ,CAMPMNG.PRICESTARTDATERF " + Environment.NewLine;       // ���i�J�n��
            selectTxt += "   ,CAMPMNG.PRICEENDDATERF " + Environment.NewLine;         // ���i�I����
            selectTxt += "   ,CAMPMNG.DISCOUNTRATERF " + Environment.NewLine;         // �l����
            selectTxt += "   ,CAMPST.CAMPAIGNNAMERF " + Environment.NewLine;          // �L�����y�[���R�[�h����
            selectTxt += "   ,CAMPST.APPLYSTADATERF " + Environment.NewLine;          // �K�p�J�n��
            selectTxt += "   ,CAMPST.APPLYENDDATERF " + Environment.NewLine;          // �K�p�I����
            selectTxt += "   ,SEC.SECTIONGUIDESNMRF " + Environment.NewLine;          // ���_����

            // ���s�^�C�v == �u���[�J�[�{�a�k�R�[�h�v|| ���s�^�C�v ==�u�a�k�R�[�h�v
            if (_campaignMasterPrtWork.PrintType == 1 || _campaignMasterPrtWork.PrintType == 4)
            {
                selectTxt += "   ,BLGOODSCD.BLGOODSHALFNAMERF " + Environment.NewLine; // �a�k�R�[�h���́i���p�j
            }

            // ���s�^�C�v != �u�a�k�R�[�h�v&& ���s�^�C�v !=�u�̔��敪�v
            if (_campaignMasterPrtWork.PrintType != 4 && _campaignMasterPrtWork.PrintType != 5)
            {
                selectTxt += "   ,MAKER.MAKERKANANAMERF " + Environment.NewLine;          // ���[�J�[���́i�Łj 
            }

            // ���s�^�C�v == �u���[�J�[�{�i�ԁv
            if (_campaignMasterPrtWork.PrintType == 0)
            {
                selectTxt += "   ,GOODS.GOODSNAMEKANARF " + Environment.NewLine;          // ���i���́i�Łj 
            }

            // ���s�^�C�v == �u���[�J�[�{�O���[�v�R�[�h�v
            if (_campaignMasterPrtWork.PrintType == 2)
            {
                selectTxt += "   ,BLGROUP.BLGROUPKANANAMERF " + Environment.NewLine;      // �O���[�v�R�[�h���́i�Łj 
            }

            // ���s�^�C�v == �u�̔��敪�v
            if (_campaignMasterPrtWork.PrintType == 5)
            {
                selectTxt += "   ,USERGD.GUIDENAMERF " + Environment.NewLine;         // �K�C�h����
            }
            selectTxt += "   ,CUSTOMER.CUSTOMERSNMRF " + Environment.NewLine;         // ���Ӑ旪��
            selectTxt += " FROM CAMPAIGNMNGRF AS CAMPMNG WITH (READUNCOMMITTED) " + Environment.NewLine;
            // �L�����y�[���ݒ�}�X�^
            selectTxt += " LEFT JOIN CAMPAIGNSTRF AS CAMPST " + Environment.NewLine;
            selectTxt += " ON CAMPST.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND CAMPST.CAMPAIGNCODERF = CAMPMNG.CAMPAIGNCODERF " + Environment.NewLine;
            selectTxt += " AND CAMPST.LOGICALDELETECODERF = 0 " + Environment.NewLine;            
            // ���_���ݒ�}�X�^
            selectTxt += " LEFT JOIN SECINFOSETRF AS SEC " + Environment.NewLine;
            selectTxt += " ON SEC.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND SEC.SECTIONCODERF = CAMPMNG.SECTIONCODERF " + Environment.NewLine;
            selectTxt += " AND SEC.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            // �a�k���i�R�[�h�}�X�^(���[�U�[�E��)
            // ���s�^�C�v == �u���[�J�[�{�a�k�R�[�h�v|| ���s�^�C�v ==�u�a�k�R�[�h�v
            if (_campaignMasterPrtWork.PrintType == 1 || _campaignMasterPrtWork.PrintType == 4)
            {
                selectTxt += " LEFT JOIN BLGOODSCDURF AS BLGOODSCD " + Environment.NewLine;
                selectTxt += " ON BLGOODSCD.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += " AND BLGOODSCD.BLGOODSCODERF = CAMPMNG.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += " AND BLGOODSCD.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            }

            // ���[�J�[�}�X�^�i���[�U�[�E�񋟁j
            // ���s�^�C�v != �u�a�k�R�[�h�v&& ���s�^�C�v !=�u�̔��敪�v
            if (_campaignMasterPrtWork.PrintType != 4 && _campaignMasterPrtWork.PrintType != 5)
            {
                selectTxt += " LEFT JOIN MAKERURF AS MAKER " + Environment.NewLine;
                selectTxt += " ON MAKER.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += " AND MAKER.GOODSMAKERCDRF = CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " AND MAKER.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            }

            // ���i�}�X�^�i���[�U�[�E�񋟁j
            // ���s�^�C�v == �u���[�J�[�{�i�ԁv
            if (_campaignMasterPrtWork.PrintType == 0)
            {
                selectTxt += " LEFT JOIN GOODSURF AS GOODS " + Environment.NewLine;
                selectTxt += " ON GOODS.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += " AND GOODS.GOODSMAKERCDRF = CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " AND GOODS.GOODSNORF = CAMPMNG.GOODSNORF " + Environment.NewLine;
                selectTxt += " AND GOODS.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            }

            // �O���[�v�R�[�h�}�X�^�i���[�U�[�E�񋟁j
            // ���s�^�C�v == �u���[�J�[�{�O���[�v�R�[�h�v
            if (_campaignMasterPrtWork.PrintType == 2)
            {
                selectTxt += " LEFT JOIN BLGROUPURF AS BLGROUP " + Environment.NewLine;
                selectTxt += " ON BLGROUP.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += " AND BLGROUP.BLGROUPCODERF = CAMPMNG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += " AND BLGROUP.LOGICALDELETECODERF = 0 " + Environment.NewLine;
            }

            // ���Ӑ�}�X�^
            selectTxt += " LEFT JOIN CUSTOMERRF AS CUSTOMER " + Environment.NewLine;
            selectTxt += " ON CUSTOMER.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
            selectTxt += " AND CUSTOMER.CUSTOMERCODERF = CAMPMNG.CUSTOMERCODERF " + Environment.NewLine;
            selectTxt += " AND CUSTOMER.LOGICALDELETECODERF = 0 " + Environment.NewLine;

            // ���[�U�[�K�C�h�}�X�^
            // ���s�^�C�v == �u�̔��敪�v
            if (_campaignMasterPrtWork.PrintType == 5)
            {
                selectTxt += " LEFT JOIN USERGDBDURF AS USERGD " + Environment.NewLine;
                selectTxt += " ON USERGD.ENTERPRISECODERF = CAMPMNG.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += " AND USERGD.GUIDECODERF = CAMPMNG.SALESCODERF " + Environment.NewLine;
                selectTxt += " AND USERGD.LOGICALDELETECODERF = 0 " + Environment.NewLine;
                selectTxt += " AND USERGD.USERGUIDEDIVCDRF = 71 " + Environment.NewLine;
            }

            //WHERE���̍쐬
            selectTxt += MakeWhereString(ref sqlCommand, _campaignMasterPrtWork, logicalMode);

            #region ORDER BY
            // �L�����y�[���R�[�h
            selectTxt += " ORDER BY CAMPMNG.CAMPAIGNCODERF " + Environment.NewLine;
            if (_campaignMasterPrtWork.PrintType == 0)
            {
                // �i�ԁA���[�J�[��
                selectTxt += " ,CAMPMNG.GOODSNORF " + Environment.NewLine;
                selectTxt += " ,CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine;
            }
            else if (_campaignMasterPrtWork.PrintType == 1)
            {
                // �a�k�R�[�h�A���[�J�[��
                selectTxt += " ,CAMPMNG.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += " ,CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine; 
            }
            else if (_campaignMasterPrtWork.PrintType == 2)
            {
                // �O���[�v�R�[�h�A���[�J�[��
                selectTxt += " ,CAMPMNG.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += " ,CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine; 
            }
            else if (_campaignMasterPrtWork.PrintType == 3)
            {
                // ���[�J�[��
                selectTxt += " ,CAMPMNG.GOODSMAKERCDRF " + Environment.NewLine;
            }
            else if (_campaignMasterPrtWork.PrintType == 4)
            {
                // �a�k�R�[�h��
                selectTxt += " ,CAMPMNG.BLGOODSCODERF " + Environment.NewLine; 
            }
            else if (_campaignMasterPrtWork.PrintType == 5)
            {
                // �̔��敪��
                selectTxt += " ,CAMPMNG.SALESCODERF " + Environment.NewLine; 
            }
            else
            {
                // ����
            }

            selectTxt += " ,CAMPMNG.SECTIONCODERF ASC,  CAMPMNG.SALESPRICESETDIVRF DESC, CAMPMNG.CUSTOMERCODERF ASC " + Environment.NewLine;  // ADD 2011/07/12 

            #endregion
            #endregion

            return selectTxt;
        }
        #endregion

        #region [CampaignMasterWork�p WHERE����������]
        /// <summary>
        /// CampaignMasterWork�p WHERE����������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="paramWork">��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>WHERE��</returns>
        /// <remarks>
        /// <br>Note       : WHERE���쐬�B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string MakeWhereString(ref SqlCommand sqlCommand, CampaignMasterPrtWork paramWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " CAMPMNG.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);

            // �J�n�L�����y�[���R�[�h
            if (paramWork.CampaignCodeSt != 0)
            {
                retstring += " AND CAMPMNG.CAMPAIGNCODERF>=@FINDCAMPAIGNCODEST" + Environment.NewLine;
                SqlParameter paraCampaignCodeSt = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODEST", SqlDbType.Int);
                paraCampaignCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.CampaignCodeSt);
            }

            // �I���L�����y�[���R�[�h
            if (paramWork.CampaignCodeEd != 0)
            {
                retstring += " AND CAMPMNG.CAMPAIGNCODERF<=@FINDCAMPAIGNCODEED" + Environment.NewLine;
                SqlParameter paraCampaignCodeEd = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODEED", SqlDbType.Int);
                paraCampaignCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.CampaignCodeEd);
            }

            // �J�n���_
            if (!string.IsNullOrEmpty(paramWork.SectionCodeSt))
            {
                retstring += " AND CAMPMNG.SECTIONCODERF>=@FINDSECCODEST" + Environment.NewLine;
                SqlParameter paraSecCodeSt = sqlCommand.Parameters.Add("@FINDSECCODEST", SqlDbType.NChar);
                paraSecCodeSt.Value = SqlDataMediator.SqlSetString(paramWork.SectionCodeSt);
            }

            // �I�����_
            if (!string.IsNullOrEmpty(paramWork.SectionCodeEd))
            {
                retstring += " AND CAMPMNG.SECTIONCODERF<=@FINDSECCODEED" + Environment.NewLine;
                SqlParameter paraSecCodeEd = sqlCommand.Parameters.Add("@FINDSECCODEED", SqlDbType.NChar);
                paraSecCodeEd.Value = SqlDataMediator.SqlSetString(paramWork.SectionCodeEd);
            }

            // ���s�^�C�v
            retstring += " AND CAMPMNG.CAMPAIGNSETTINGKINDRF=@FINDCAMPAIGNSETTINGKIND" + Environment.NewLine;
            SqlParameter paraCampaignSettingKind = sqlCommand.Parameters.Add("@FINDCAMPAIGNSETTINGKIND", SqlDbType.Int);
            paraCampaignSettingKind.Value = SqlDataMediator.SqlSetInt32(paramWork.PrintType + 1);


            // ���s�^�C�v != �u�a�k�R�[�h�v&& ���s�^�C�v !=�u�̔��敪�v
            if (paramWork.PrintType != 4 && paramWork.PrintType != 5)
            {
                // �J�n���[�J�[�R�[�h
                if (paramWork.GoodsMakerCodeSt != 0)
                {
                    retstring += " AND CAMPMNG.GOODSMAKERCDRF>=@FINDGOODSMAKERCDST" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCodeSt = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDST", SqlDbType.Int);
                    paraGoodsMakerCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCodeSt);
                }

                // �I�����[�J�[�R�[�h
                if (paramWork.GoodsMakerCodeEd != 0)
                {
                    retstring += " AND CAMPMNG.GOODSMAKERCDRF<=@FINDGOODSMAKERCDED" + Environment.NewLine;
                    SqlParameter paraGoodsMakerCodeEd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCDED", SqlDbType.Int);
                    paraGoodsMakerCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCodeEd);
                }
            }

            // ���s�^�C�v == �u���[�J�[�{�O���[�v�R�[�h�v
            if (paramWork.PrintType == 2)
            {
                // �J�n�O���[�v�R�[�h
                if (paramWork.BLGroupCodeSt != 0)
                {
                    retstring += " AND CAMPMNG.BLGROUPCODERF>=@FINDBLGROUPCODEST" + Environment.NewLine;
                    SqlParameter paraBLGroupCodeSt = sqlCommand.Parameters.Add("@FINDBLGROUPCODEST", SqlDbType.Int);
                    paraBLGroupCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCodeSt);
                }

                // �I���O���[�v�R�[�h
                if (paramWork.BLGroupCodeEd != 0)
                {
                    retstring += " AND CAMPMNG.BLGROUPCODERF<=@FINDBLGROUPCODEED" + Environment.NewLine;
                    SqlParameter paraBLGroupCodeEd = sqlCommand.Parameters.Add("@FINDBLGROUPCODEED", SqlDbType.Int);
                    paraBLGroupCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGroupCodeEd);
                }
            }

            // ���s�^�C�v == �u���[�J�[�{�a�k�R�[�h�v|| ���s�^�C�v ==�u�a�k�R�[�h�v
            if (paramWork.PrintType == 1 || paramWork.PrintType == 4)
            {
                // �J�n�a�k�R�[�h
                if (paramWork.BLGoodsCodeSt != 0)
                {
                    retstring += " AND CAMPMNG.BLGOODSCODERF>=@FINDBLGOODSCODEST" + Environment.NewLine;
                    SqlParameter paraBLGoodsCodeSt = sqlCommand.Parameters.Add("@FINDBLGOODSCODEST", SqlDbType.Int);
                    paraBLGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGoodsCodeSt);
                }

                // �I���a�k�R�[�h
                if (paramWork.BLGoodsCodeEd != 0)
                {
                    retstring += " AND CAMPMNG.BLGOODSCODERF<=@FINDBLGOODSCODEED" + Environment.NewLine;
                    SqlParameter paraBLGoodsCodeEd = sqlCommand.Parameters.Add("@FINDBLGOODSCODEED", SqlDbType.Int);
                    paraBLGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.BLGoodsCodeEd);
                }
            }

            // ���s�^�C�v == �u�̔��敪�v
            if (paramWork.PrintType == 5)
            {
                // �J�n�̔��敪�R�[�h
                if (paramWork.SalesCodeSt != 0)
                {
                    retstring += " AND CAMPMNG.SALESCODERF>=@FINDSALESCODEST" + Environment.NewLine;
                    SqlParameter paraSalesCodeSt = sqlCommand.Parameters.Add("@FINDSALESCODEST", SqlDbType.Int);
                    paraSalesCodeSt.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesCodeSt);
                }

                // �I���̔��敪�R�[�h
                if (paramWork.SalesCodeEd != 0)
                {
                    retstring += " AND CAMPMNG.SALESCODERF<=@FINDSALESCODEED" + Environment.NewLine;
                    SqlParameter paraSalesCodeEd = sqlCommand.Parameters.Add("@FINDSALESCODEED", SqlDbType.Int);
                    paraSalesCodeEd.Value = SqlDataMediator.SqlSetInt32(paramWork.SalesCodeEd);
                }
            }

            // ���s�^�C�v == �u���[�J�[�{�i�ԁv
            if (paramWork.PrintType == 0)
            {
                // �J�n�i��
                if (!string.IsNullOrEmpty(paramWork.GoodsNoSt))
                {
                    retstring += " AND CAMPMNG.GOODSNORF>=@FINDGOODSNOST" + Environment.NewLine;
                    // SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.Int);// DEL 2011/05/10
                    SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@FINDGOODSNOST", SqlDbType.NChar);// ADD 2011/05/10
                    paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNoSt);
                }

                // �I���i��
                if (!string.IsNullOrEmpty(paramWork.GoodsNoEd))
                {
                    retstring += " AND CAMPMNG.GOODSNORF<=@FINDGOODSNOED" + Environment.NewLine;
                    // SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.Int);// DEL 2011/05/10
                    SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@FINDGOODSNOED", SqlDbType.NChar);// ADD 2011/05/10
                    paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNoEd);
                }

                // �����z
                // ����
                if (paramWork.PriceFlDiv == 1)
                {
                    retstring += " AND CAMPMNG.PRICEFLRF=@FINDPRICEFL" + Environment.NewLine;
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@FINDPRICEFL", SqlDbType.Float);
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(paramWork.PriceFl);
                }
                // �ȏ�
                else if (paramWork.PriceFlDiv == 2)
                {
                    retstring += " AND CAMPMNG.PRICEFLRF>=@FINDPRICEFL" + Environment.NewLine;
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@FINDPRICEFL", SqlDbType.Float);
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(paramWork.PriceFl);
                }
                // �ȉ�
                else if (paramWork.PriceFlDiv == 3)
                {
                    retstring += " AND CAMPMNG.PRICEFLRF<=@FINDPRICEFL" + Environment.NewLine;
                    SqlParameter paraPriceFl = sqlCommand.Parameters.Add("@FINDPRICEFL", SqlDbType.Float);
                    paraPriceFl.Value = SqlDataMediator.SqlSetDouble(paramWork.PriceFl);
                }
            }

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0))
            {
                retstring += " AND CAMPMNG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)0);
            }
            else
            {
                retstring += " AND CAMPMNG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)1);
            }

            // ������
            // ����
            if (paramWork.RateValDiv == 1)
            {
                retstring += " AND CAMPMNG.RATEVALRF=@FINDRATEVAL" + Environment.NewLine;
                SqlParameter paraRateVal = sqlCommand.Parameters.Add("@FINDRATEVAL", SqlDbType.Float);
                paraRateVal.Value = SqlDataMediator.SqlSetDouble(paramWork.RateVal);
            }
            // �ȏ�
            else if (paramWork.RateValDiv == 2)
            {
                retstring += " AND CAMPMNG.RATEVALRF>=@FINDRATEVAL" + Environment.NewLine;
                SqlParameter paraRateVal = sqlCommand.Parameters.Add("@FINDRATEVAL", SqlDbType.Float);
                paraRateVal.Value = SqlDataMediator.SqlSetDouble(paramWork.RateVal);
            }
            // �ȉ�
            else if (paramWork.RateValDiv == 3)
            {
                retstring += " AND CAMPMNG.RATEVALRF<=@FINDRATEVAL" + Environment.NewLine;
                SqlParameter paraRateVal = sqlCommand.Parameters.Add("@FINDRATEVAL", SqlDbType.Float);
                paraRateVal.Value = SqlDataMediator.SqlSetDouble(paramWork.RateVal);
            }

            // ������
            // ����
            if (paramWork.DiscountRateDiv == 1)
            {
                retstring += " AND CAMPMNG.DISCOUNTRATERF=@FINDDISCOUNTRATE" + Environment.NewLine;
                SqlParameter paraDiscountRate = sqlCommand.Parameters.Add("@FINDDISCOUNTRATE", SqlDbType.Float);
                paraDiscountRate.Value = SqlDataMediator.SqlSetDouble(paramWork.DiscountRate);
            }
            // �ȏ�
            else if (paramWork.DiscountRateDiv == 2)
            {
                retstring += " AND CAMPMNG.DISCOUNTRATERF>=@FINDDISCOUNTRATE" + Environment.NewLine;
                SqlParameter paraDiscountRate = sqlCommand.Parameters.Add("@FINDDISCOUNTRATE", SqlDbType.Float);
                paraDiscountRate.Value = SqlDataMediator.SqlSetDouble(paramWork.DiscountRate);
            }
            // �ȉ�
            else if (paramWork.DiscountRateDiv == 3)
            {
                retstring += " AND CAMPMNG.DISCOUNTRATERF<=@FINDDISCOUNTRATE" + Environment.NewLine;
                SqlParameter paraDiscountRate = sqlCommand.Parameters.Add("@FINDDISCOUNTRATE", SqlDbType.Float);
                paraDiscountRate.Value = SqlDataMediator.SqlSetDouble(paramWork.DiscountRate);
            }
            
            #endregion

            return retstring;
        }
        #endregion

        #region [CampaignMasterWork����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CampaignMasterWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">��������</param>
        /// <returns>���o����</returns>
        /// <remarks>
        /// <br>Note       : �N���X�i�[���� Reader �� CampaignMasterWork�B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignMasterWork CopyToResultWorkFromReaderProc(ref SqlDataReader myReader, CampaignMasterPrtWork paramWork)
        {
            #region ���o����-�l�Z�b�g
            CampaignMasterWork resultWork = new CampaignMasterWork();
            if (paramWork.PrintType != 6)
            {
                resultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                resultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));//�쐬����
            }
            resultWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CAMPAIGNCODERF"));     // �L�����y�[���R�[�h
            resultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));    // ���_�R�[�h
            resultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF")); // BL���i�R�[�h
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));     // ���i���[�J�[�R�[�h
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));     // ���i�ԍ�
            resultWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));  // BL�O���[�v�R�[�h
            resultWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF")); // �̔��敪�R�[�h
            resultWork.SalesPriceSetDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICESETDIVRF"));     // �����ݒ�敪
            resultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));      // ���Ӑ�R�[�h
            resultWork.PriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRICEFLRF"));      // ���i�i�����j
            resultWork.RateVal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RATEVALRF"));      // �|��
            resultWork.PriceStartDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICESTARTDATERF"));      // ���i�J�n��
            resultWork.PriceEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICEENDDATERF"));      // ���i�I����
            resultWork.CampaignName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CAMPAIGNNAMERF"));      // �L�����y�[���R�[�h����
            resultWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYSTADATERF"));      // �K�p�J�n��
            resultWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("APPLYENDDATERF"));      // �K�p�I����
            resultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));      // ���_����
            resultWork.DiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("DISCOUNTRATERF"));      // �l����
            // ���s�^�C�v == �u���[�J�[�{�a�k�R�[�h�v|| ���s�^�C�v ==�u�a�k�R�[�h�v
            if (paramWork.PrintType == 1 || paramWork.PrintType == 4)
            {
                resultWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));      // �a�k�R�[�h���́i���p�j
            }

            // ���s�^�C�v != �u�a�k�R�[�h�v&& ���s�^�C�v !=�u�̔��敪�v
            if (paramWork.PrintType != 4 && paramWork.PrintType != 5)
            {
                resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));      // ���[�J�[���́i�Łj
            }

            // ���s�^�C�v == �u���[�J�[�{�i�ԁv
            if (paramWork.PrintType == 0)
            {
                resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));      // ���i���́i�Łj
            }

            // ���s�^�C�v == �u���[�J�[�{�O���[�v�R�[�h�v
            if (paramWork.PrintType == 2)
            {
                resultWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPKANANAMERF"));      // �O���[�v�R�[�h���́i�Łj
            }

            // ���s�^�C�v == �u�̔��敪�v
            if (paramWork.PrintType == 5)
            {
                resultWork.GuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GUIDENAMERF"));      // �K�C�h����
            }

            resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));      // ���Ӑ旪��   
            #endregion

            return resultWork;
        }
        #endregion

        #endregion  //�}�X�^�ȊO����
    }
}
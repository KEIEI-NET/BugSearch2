//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ����O�Q�ƃc�[��
// �v���O�����T�v   : ����M�����̒ǉ��X�V�A���o�A�����폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �� �� ��  2012/07/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �C �� ��  2012/10/08  �C�����e : �\�[�X�̃R�����g��PG���̂̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �� �� ��  2012/10/16  �C�����e : ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���j��
// �� �� ��  2012/12/18  �C�����e :Redmine#33961 ���_�Ǘ����O�Q�ƃc�[���ɂāA
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@����M�敪�Ɂu�S�āv���w�肵�����s���̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �{�{�@����
// �� �� ��  2013/02/20  �C�����e : ���_�Ǘ�DC����M��������INSERT����
//                                  �X�V�]�ƈ��R�[�h����̏ꍇ�͍X�V���Ȃ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DC����M�����@�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�Ǘ�DC����M�����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/07/23</br>
    /// <br></br>
    /// <br>Update Note: 2012/10/08 ������</br>
    ///	<br>			 Redmine#31026 �\�[�X�̃R�����g��PG���̂̏C��</br>
    /// <br>Update Note: 2012/10/16 ������</br>
    ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
    /// <br>Update Note: 2012/12/18 ���j��</br>
    ///	<br>			 Redmine#33961 ���_�Ǘ����O�Q�ƃc�[���ɂāA
    ///�@�@�@�@�@�@�@�@�@����M�敪�Ɂu�S�āv���w�肵�����s���̑Ή�</br>
    /// </remarks>
    [Serializable]
    public class SndRcvHisTableDB : RemoteDB, ISndRcvHisTableDB
    {
        /// <summary>
        /// ���_�Ǘ�DC����M����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        public SndRcvHisTableDB()
            : base("PMKYO09507D", "Broadleaf.Application.Remoting.ParamData.SndRcvHisTableWork", "SndRcvHisConRF")
        {

        }

        # region [Write]
        /// <summary>
        /// ���_�Ǘ�DC����M��������ǉ��E�X�V���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="sndRcvHisTableWorkList">sndRcvHisTableWorkList�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ�DC����M������ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        public int Write(ref object sndRcvHisTableWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList sndRcvHisTableList = new ArrayList();
            sndRcvHisTableList = sndRcvHisTableWorkList as ArrayList;
            try
            {
                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                foreach (SndRcvHisTableWork sndRcvHisTableWork in sndRcvHisTableList)
                {
                    //write���s
                    status = WriteProc(sndRcvHisTableWork, ref sqlConnection, ref sqlTransaction);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SndRcvHisDB.Write(ref object sndRcvHisTableList)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
            return status;
        }

        /// <summary>
        /// ���_�Ǘ�DC����M��������o�^�A�X�V���܂�
        /// </summary>
        /// <remarks>
        /// <param name="sndRcvHisTableWork">���_�Ǘ�DC����M�������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ�DC����M��������o�^�A�X�V���܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        private int WriteProc(SndRcvHisTableWork sndRcvHisTableWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ADD 2013/02/20 T.Miyamoto ------------------------------>>>>>
            //�X�V�w�b�_����ݒ�
            object obj = (object)this;
            IFileHeader flhd = (IFileHeader)sndRcvHisTableWork;
            FileHeader fileHeader = new FileHeader(obj);
            fileHeader.SetInsertHeader(ref flhd, obj);
            if (sndRcvHisTableWork.UpdEmployeeCode.Trim().Equals(""))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                return status;
            }
            // ADD 2013/02/20 T.Miyamoto ------------------------------>>>>>

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder();
            StringBuilder sqlText1 = new StringBuilder();

            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

            int sndRcvHisNoMax = 0;
            sqlText.Append(
                "SELECT MAX(SNDRCVHISSNDRCVNORF) SNDRCVHISSNDRCVNORF FROM SNDRCVHISTABLERF " +
                "WHERE" +
                " ENTERPRISECODERF = @FINDENTERPRISECODERF").Append(Environment.NewLine);
            sqlCommand.CommandText = sqlText.ToString();

            //Prameter�I�u�W�F�N�g�̍쐬
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);
            //Parameter�I�u�W�F�N�g�֒l�ݒ�
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.EnterpriseCode);

            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                sndRcvHisNoMax = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVHISSNDRCVNORF"));
            }

            try
            {
                sndRcvHisTableWork.SndRcvHisSndRcvNo = sndRcvHisNoMax + 1;

                # region [INSERT��]
                sqlText1.Append("INSERT INTO" +
                "  SNDRCVHISTABLERF  " +
                " (" +
                "     CREATEDATETIMERF" +
                "    ,UPDATEDATETIMERF" +
                "    ,ENTERPRISECODERF" +
                "    ,FILEHEADERGUIDRF" +
                "    ,UPDEMPLOYEECODERF" +
                "    ,UPDASSEMBLYID1RF" +
                "    ,UPDASSEMBLYID2RF" +
                "    ,LOGICALDELETECODERF" +
                "    ,SNDRCVHISSNDRCVNORF" +
                "    ,SECTIONCODERF" +
                "    ,SNDRCVHISCONSNORF" +
                "    ,SNDRCVDATETIMERF" +
                "    ,SENDORRECEIVEDIVCDRF" +
                "    ,KINDRF" +
                "    ,SNDLOGEXTRACONDDIVRF" +
                    // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                //"    ,PROCSTARTDATETIMERF" +
                //"    ,PROCENDDATETIMERF" +
                    // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                "    ,SENDDESTEPCODERF" +
                "    ,SENDDESTSECCODERF" +
                "    ,SNDRCVCONDITIONRF" +
                "    ,TEMPRECEIVEDIVRF" +
                "    ,SNDRCVERRCONTENTSRF" +
                "    ,SNDRCVFILEIDRF" +
                    // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                "    ,SNDOBJSTARTDATERF" +
                "    ,SNDOBJENDDATERF" +
                    // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                " )" +
                " VALUES" +
               " (@CREATEDATETIME" +
                "    ,@UPDATEDATETIME" +
                "    ,@ENTERPRISECODE" +
                "    ,@FILEHEADERGUID" +
                "    ,@UPDEMPLOYEECODE" +
                "    ,@UPDASSEMBLYID1" +
                "    ,@UPDASSEMBLYID2" +
                "    ,@LOGICALDELETECODE" +
                "    ,@SNDRCVHISSNDRCVNO" +
                "    ,@SECTIONCODE" +
                "    ,@SNDRCVHISCONSNO" +
                "    ,@SNDRCVDATETIME" +
                "    ,@SENDORRECEIVEDIVCD" +
                "    ,@KIND" +
                "    ,@SNDLOGEXTRACONDDIV" +
                    // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                //"    ,@PROCSTARTDATETIME" +
                //"    ,@PROCENDDATETIME" +
                    // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                "    ,@SENDDESTEPCODE" +
                "    ,@SENDDESTSECCODE" +
                "    ,@SNDRCVCONDITION" +
                "    ,@TEMPRECEIVEDIV" +
                "    ,@SNDRCVERRCONTENTS" +
                "    ,@SNDRCVFILEID" +
                    // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                "    ,@SNDOBJSTARTDATERF" +
                "    ,@SNDOBJENDDATERF" +
                    // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                " )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlText1.ToString();
                # endregion

                // DEL 2013/02/20 T.Miyamoto ------------------------------>>>>>
                ////�X�V�w�b�_����ݒ�
                //object obj = (object)this;
                //IFileHeader flhd = (IFileHeader)sndRcvHisTableWork;
                //FileHeader fileHeader = new FileHeader(obj);
                //fileHeader.SetInsertHeader(ref flhd, obj);
                // DEL 2013/02/20 T.Miyamoto ------------------------------<<<<<
                if (myReader.IsClosed == false) myReader.Close();
                #region Parameter�I�u�W�F�N�g�̍쐬
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSndRcvHisSndRcvNo = sqlCommand.Parameters.Add("@SNDRCVHISSNDRCVNO", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraSndRcvHisConsNo = sqlCommand.Parameters.Add("@SNDRCVHISCONSNO", SqlDbType.Int);
                SqlParameter paraSndRcvDateTime = sqlCommand.Parameters.Add("@SNDRCVDATETIME", SqlDbType.BigInt);
                SqlParameter paraSendOrReceiveDivCd = sqlCommand.Parameters.Add("@SENDORRECEIVEDIVCD", SqlDbType.Int);
                SqlParameter paraKind = sqlCommand.Parameters.Add("@KIND", SqlDbType.Int);
                SqlParameter paraSndLogExtraCondDiv = sqlCommand.Parameters.Add("@SNDLOGEXTRACONDDIV", SqlDbType.Int);
                // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                //SqlParameter paraProcStartDateTime = sqlCommand.Parameters.Add("@PROCSTARTDATETIME", SqlDbType.BigInt);
                //SqlParameter paraProcEndDateTime = sqlCommand.Parameters.Add("@PROCENDDATETIME", SqlDbType.BigInt);
                // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                SqlParameter paraSendDestEpCode = sqlCommand.Parameters.Add("@SENDDESTEPCODE", SqlDbType.NChar);
                SqlParameter paraSendDestSecCode = sqlCommand.Parameters.Add("@SENDDESTSECCODE", SqlDbType.NChar);
                SqlParameter paraSndRcvCondition = sqlCommand.Parameters.Add("@SNDRCVCONDITION", SqlDbType.Int);
                SqlParameter paraTempReceiveDiv = sqlCommand.Parameters.Add("@TEMPRECEIVEDIV", SqlDbType.Int);
                SqlParameter paraSndRcvErrContents = sqlCommand.Parameters.Add("@SNDRCVERRCONTENTS", SqlDbType.NChar);
                SqlParameter paraSndRcvFileID = sqlCommand.Parameters.Add("@SNDRCVFILEID", SqlDbType.NChar);
                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                SqlParameter paraSndObjStartDateTime = sqlCommand.Parameters.Add("@SNDOBJSTARTDATERF", SqlDbType.BigInt);
                SqlParameter paraSndObjEndDateTime = sqlCommand.Parameters.Add("@SNDOBJENDDATERF", SqlDbType.BigInt);
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                #endregion

                #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisTableWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisTableWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sndRcvHisTableWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.LogicalDeleteCode);
                paraSndRcvHisSndRcvNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SndRcvHisSndRcvNo);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SectionCode);
                paraSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SndRcvHisConsNo);
                paraSndRcvDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisTableWork.SndRcvDateTime);
                paraSendOrReceiveDivCd.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SendOrReceiveDivCd);
                paraKind.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.Kind);
                paraSndLogExtraCondDiv.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SndLogExtraCondDiv);
                // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                //paraProcStartDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisTableWork.ProcStartDateTime);
                //paraProcEndDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisTableWork.ProcEndDateTime);
                // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                paraSendDestEpCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SendDestEpCode);
                paraSendDestSecCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SendDestSecCode);
                paraSndRcvCondition.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SndRcvCondition);
                paraTempReceiveDiv.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.TempReceiveDiv);
                //paraSndRcvErrContents.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SndRcvErrContents);//DEL 2012/10/16 ������ for redmine#31026 
                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                if (sndRcvHisTableWork.SndRcvErrContents.Length > 100)
                {
                    paraSndRcvErrContents.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SndRcvErrContents.Substring(0, 100));
                }
                else
                {
                    paraSndRcvErrContents.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SndRcvErrContents);
                }
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                paraSndRcvFileID.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SndRcvFileID);
                // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                paraSndObjStartDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisTableWork.SndObjStartDate);
                paraSndObjEndDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisTableWork.SndObjEndDate);
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
                #endregion
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SndRcvHisTableDB.Write" + status, sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SndRcvHisTableDB.Write" + status);
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
            return status;
        }
        # endregion

        # region [Search]
        /// <summary>
        /// ���_�Ǘ�DC����M�����̃��X�g���擾���܂��B
        /// </summary> 
        /// <remarks>
        /// <param name="sndRcvHisConWork">��������</param>
        /// <param name="objSndRcvHisList">����M������������</param>
        /// <param name="objSndRcvEtrList">����M���o�����������O�f�[�^��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ�DC����M�����̃L�[�l����v����A�S�Ă̋��_�Ǘ�DC����M���������擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        public int Search(SndRcvHisConWork sndRcvHisConWork, out object objSndRcvHisList, out object objSndRcvEtrList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            ArrayList sndRcvHisList = new ArrayList();
            ArrayList sndRcvEtrList = new ArrayList();
            objSndRcvHisList = new ArrayList();
            objSndRcvEtrList = new ArrayList();

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null)
                {

                    return status;
                }

                sqlConnection.Open();

                return SearchHisProc(sndRcvHisConWork, out sndRcvHisList, out sndRcvEtrList, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SndRcvHisTableDB.Search");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                objSndRcvHisList = sndRcvHisList;
                objSndRcvEtrList = sndRcvEtrList;
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̑���M����߂�f�[�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="sndRcvHisConWork">�����p�����[�^</param>
        /// <param name="sndRcvHisWorkList">����M������������</param>
        /// <param name="sndRcvEtrWorkList">����M���o�����������O�f�[�^��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑���M����߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        private int SearchHisProc(SndRcvHisConWork sndRcvHisConWork, out ArrayList sndRcvHisWorkList, out ArrayList sndRcvEtrWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            sndRcvHisWorkList = new ArrayList();
            sndRcvEtrWorkList = new ArrayList();
            ArrayList sndRcvEtrWorkSubList = new ArrayList();


            status = SearchHisProcProc(sndRcvHisConWork, out sndRcvHisWorkList, ref sqlConnection);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (sndRcvHisWorkList != null && sndRcvHisWorkList.Count > 0)
                {
                    Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();//ADD 2012/10/16 ������ for redmine#31026
                    foreach (SndRcvHisTableWork sndRcvHisTableWork in sndRcvHisWorkList)
                    {
                        if (sndRcvHisTableWork.Kind == 1)
                        {
                            //�q�\����
                            //status = this.SearchSubHisProcProc(sndRcvHisTableWork, out sndRcvEtrWorkSubList, ref sqlConnection);//DEL 2012/10/16 ������ for redmine#31026
                            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                            sndRcvEtrWorkSubList = new ArrayList();
                            if (!tempSndRcvDic.ContainsKey(sndRcvHisTableWork.EnterpriseCode + sndRcvHisTableWork.SectionCode + sndRcvHisTableWork.SndRcvHisConsNo.ToString()))
                            {
                                status = this.SearchSubHisProcProc(sndRcvHisTableWork, out sndRcvEtrWorkSubList, ref sqlConnection);
                                tempSndRcvDic.Add(sndRcvHisTableWork.EnterpriseCode + sndRcvHisTableWork.SectionCode + sndRcvHisTableWork.SndRcvHisConsNo.ToString(), sndRcvHisTableWork.EnterpriseCode + sndRcvHisTableWork.SectionCode + sndRcvHisTableWork.SndRcvHisConsNo.ToString());
                            }
                            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else
                            {
                                return status;
                            }

                            foreach (SndRcvEtrWork sndRcvEtrWork in sndRcvEtrWorkSubList)
                            {
                                sndRcvEtrWorkList.Add(sndRcvEtrWork);
                            }
                        }
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̑���M����߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="sndRcvHisConWork">�����p�����[�^</param>
        /// <param name="sndRcvHisWorkList">����M������������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        private int SearchHisProcProc(SndRcvHisConWork sndRcvHisConWork, out ArrayList sndRcvHisWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                StringBuilder sqlTxt = new StringBuilder();
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append(
                    "SELECT " +
                        "HISTAB.CREATEDATETIMERF," +
                        "HISTAB.UPDATEDATETIMERF," +
                        "HISTAB.ENTERPRISECODERF," +
                        "HISTAB.FILEHEADERGUIDRF," +
                        "HISTAB.UPDEMPLOYEECODERF," +
                        "HISTAB.UPDASSEMBLYID1RF," +
                        "HISTAB.UPDASSEMBLYID2RF," +
                        "HISTAB.LOGICALDELETECODERF," +
                        "HISTAB.SNDRCVHISSNDRCVNORF," +
                        "HISTAB.SECTIONCODERF," +
                        "HISTAB.SNDRCVHISCONSNORF," +
                        "HISTAB.SNDRCVDATETIMERF," +
                        "HISTAB.SENDORRECEIVEDIVCDRF," +
                        "HISTAB.KINDRF," +
                        "HISTAB.SNDLOGEXTRACONDDIVRF," +
                    // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                        //"HISTAB.PROCSTARTDATETIMERF," +
                        //"HISTAB.PROCENDDATETIMERF," +
                    // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                        "HISTAB.SENDDESTEPCODERF," +
                        "HISTAB.SENDDESTSECCODERF," +
                        "HISTAB.SNDRCVCONDITIONRF," +
                        "HISTAB.TEMPRECEIVEDIVRF," +
                        "HISTAB.SNDRCVERRCONTENTSRF," +
                        "HISTAB.SNDRCVFILEIDRF," +
                    // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
                        "HISTAB.SNDOBJSTARTDATERF," +
                        "HISTAB.SNDOBJENDDATERF," +
                    // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<

                        "HIS.SENDDATETIMERF," +
                        "HIS.SNDLOGUSEDIVRF," +
                        "HIS.EXTRAOBJSECCODERF," +
                    // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                        //"HIS.SNDOBJSTARTDATERF," +
                        //"HIS.SNDOBJENDDATERF, " +
                    // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                        "HIS.SYNCEXECDATERF " +
                      "FROM SNDRCVHISTABLERF AS HISTAB WITH (READUNCOMMITTED) " +
                      //"INNER JOIN SNDRCVHISRF AS HIS WITH (READUNCOMMITTED) " +//DEL 2012/10/16 ������ for redmine#31026
                      "LEFT JOIN SNDRCVHISRF AS HIS WITH (READUNCOMMITTED) " +//ADD 2012/10/16 ������ for redmine#31026
                      "ON HISTAB.ENTERPRISECODERF = HIS.ENTERPRISECODERF " +
                      "AND HISTAB.SECTIONCODERF = HIS.SECTIONCODERF " +
                      "AND HISTAB.LOGICALDELETECODERF = HIS.LOGICALDELETECODERF "+//ADD 2012/10/16 ������ for redmine#31026
                      "AND HISTAB.SNDRCVHISCONSNORF = HIS.SNDRCVHISCONSNORF ");
                sqlTxt.Append(MakeWhereString(ref sqlCommand, sndRcvHisConWork));
                sqlCommand.CommandText = sqlTxt.ToString();

                myReader = sqlCommand.ExecuteReader();

                int colIndex_CreateDateTime = 0;
                int colIndex_UpdateDateTime = 0;
                int colIndex_EnterpriseCode = 0;
                int colIndex_FileHeaderGuid = 0;
                int colIndex_UpdEmployeeCode = 0;
                int colIndex_UpdAssemblyId1 = 0;
                int colIndex_UpdAssemblyId2 = 0;
                int colIndex_LogicalDeleteCode = 0;
                int colIndex_SndRcvHisSndRcvNo = 0;
                int colIndex_SectionCode = 0;
                int colIndex_SndRcvHisConsNo = 0;
                int colIndex_SndRcvDateTime = 0;
                int colIndex_SendOrReceiveDivCd = 0;
                int colIndex_Kind = 0;
                int colIndex_SndLogExtraCondDiv = 0;
                // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                //int colIndex_ProcStartDateTime = 0;
                //int colIndex_ProcEndDateTime = 0;
                // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                int colIndex_SendDestEpCode = 0;
                int colIndex_SendDestSecCode = 0;
                int colIndex_SndRcvCondition = 0;
                int colIndex_TempReceiveDiv = 0;
                int colIndex_SndRcvErrContents = 0;
                int colIndex_SndRcvFileID = 0;
                int colIndex_SndLogUseDiv = 0;
                int colIndex_ExtraObjSecCode = 0;
                int colIndex_SndObjStartDate = 0;
                int colIndex_SndObjEndDate = 0;
                int colIndex_SyncExecDate = 0;

                if (myReader.HasRows)
                {
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    colIndex_EnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
                    colIndex_FileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
                    colIndex_UpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
                    colIndex_UpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
                    colIndex_UpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    colIndex_SndRcvHisSndRcvNo = myReader.GetOrdinal("SNDRCVHISSNDRCVNORF");
                    colIndex_SectionCode = myReader.GetOrdinal("SECTIONCODERF");
                    colIndex_SndRcvHisConsNo = myReader.GetOrdinal("SNDRCVHISCONSNORF");
                    colIndex_SndRcvDateTime = myReader.GetOrdinal("SNDRCVDATETIMERF");
                    colIndex_SendOrReceiveDivCd = myReader.GetOrdinal("SENDORRECEIVEDIVCDRF");
                    colIndex_Kind = myReader.GetOrdinal("KINDRF");
                    colIndex_SndLogExtraCondDiv = myReader.GetOrdinal("SNDLOGEXTRACONDDIVRF");
                    // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                    //colIndex_ProcStartDateTime = myReader.GetOrdinal("PROCSTARTDATETIMERF");
                    //colIndex_ProcEndDateTime = myReader.GetOrdinal("PROCENDDATETIMERF");
                    // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                    colIndex_SendDestEpCode = myReader.GetOrdinal("SENDDESTEPCODERF");
                    colIndex_SendDestSecCode = myReader.GetOrdinal("SENDDESTSECCODERF");
                    colIndex_SndRcvCondition = myReader.GetOrdinal("SNDRCVCONDITIONRF");
                    colIndex_TempReceiveDiv = myReader.GetOrdinal("TEMPRECEIVEDIVRF");
                    colIndex_SndRcvErrContents = myReader.GetOrdinal("SNDRCVERRCONTENTSRF");
                    colIndex_SndRcvFileID = myReader.GetOrdinal("SNDRCVFILEIDRF");

                    colIndex_SndLogUseDiv = myReader.GetOrdinal("SNDLOGUSEDIVRF");
                    colIndex_ExtraObjSecCode = myReader.GetOrdinal("EXTRAOBJSECCODERF");
                    colIndex_SndObjStartDate = myReader.GetOrdinal("SNDOBJSTARTDATERF");
                    colIndex_SndObjEndDate = myReader.GetOrdinal("SNDOBJENDDATERF");
                    colIndex_SyncExecDate = myReader.GetOrdinal("SYNCEXECDATERF");
                }

                while (myReader.Read())
                {
                    SndRcvHisTableWork wkLogWork = new SndRcvHisTableWork();
                    #region �N���X�֊i�[

                    wkLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    wkLogWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    wkLogWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, colIndex_EnterpriseCode);
                    wkLogWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, colIndex_FileHeaderGuid);
                    wkLogWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, colIndex_UpdEmployeeCode);
                    wkLogWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId1);
                    wkLogWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId2);
                    wkLogWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    wkLogWork.SndRcvHisSndRcvNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndRcvHisSndRcvNo);
                    wkLogWork.SectionCode = SqlDataMediator.SqlGetString(myReader, colIndex_SectionCode);
                    wkLogWork.SndRcvHisConsNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndRcvHisConsNo);
                    wkLogWork.SndRcvDateTime = SqlDataMediator.SqlGetInt64(myReader, colIndex_SndRcvDateTime);
                    wkLogWork.SendOrReceiveDivCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_SendOrReceiveDivCd);
                    wkLogWork.Kind = SqlDataMediator.SqlGetInt32(myReader, colIndex_Kind);
                    wkLogWork.SndLogExtraCondDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndLogExtraCondDiv);
                    // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                    //wkLogWork.ProcStartDateTime = SqlDataMediator.SqlGetInt64(myReader, colIndex_ProcStartDateTime);
                    //wkLogWork.ProcEndDateTime = SqlDataMediator.SqlGetInt64(myReader, colIndex_ProcEndDateTime);
                    // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                    wkLogWork.SendDestEpCode = SqlDataMediator.SqlGetString(myReader, colIndex_SendDestEpCode);
                    wkLogWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, colIndex_SendDestSecCode);
                    wkLogWork.SndRcvCondition = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndRcvCondition);
                    wkLogWork.TempReceiveDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_TempReceiveDiv);
                    wkLogWork.SndRcvErrContents = SqlDataMediator.SqlGetString(myReader, colIndex_SndRcvErrContents);
                    wkLogWork.SndRcvFileID = SqlDataMediator.SqlGetString(myReader, colIndex_SndRcvFileID);

                    wkLogWork.SndLogUseDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndLogUseDiv);
                    wkLogWork.ExtraObjSecCode = SqlDataMediator.SqlGetString(myReader, colIndex_ExtraObjSecCode);
                    wkLogWork.SndObjStartDate = SqlDataMediator.SqlGetInt64(myReader, colIndex_SndObjStartDate);
                    wkLogWork.SndObjEndDate = SqlDataMediator.SqlGetInt64(myReader, colIndex_SndObjEndDate);
                    wkLogWork.SyncExecDate = SqlDataMediator.SqlGetInt64(myReader, colIndex_SyncExecDate);
                    #endregion

                    al.Add(wkLogWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteSQLErrorLog(ex, "SearchHisProcProc(out ArrayList sndRcvHisWorkList, SndRcvHisConWork sndRcvHisConWork, ref SqlConnection sqlConnection)", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SearchHisProcProc(out ArrayList sndRcvHisWorkList, SndRcvHisConWork sndRcvHisConWork, ref SqlConnection sqlConnection)", status);
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
            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
            }

            sndRcvHisWorkList = al;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̑���M���o�����������O�f�[�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="sndRcvHisTableWork">�����p�����[�^</param>
        /// <param name="sndRcvEtrWorkSubList">����M���o�����������O�f�[�^��������</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        private int SearchSubHisProcProc(SndRcvHisTableWork sndRcvHisTableWork, out ArrayList sndRcvEtrWorkSubList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            SndRcvEtrWork wkLogWork = new SndRcvEtrWork();
            sndRcvEtrWorkSubList = new ArrayList();
            try
            {
                StringBuilder sqlTxt = new StringBuilder();
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append(
                    "SELECT " +
                      "CREATEDATETIMERF," +
                      "UPDATEDATETIMERF," +
                      "ENTERPRISECODERF," +
                      "FILEHEADERGUIDRF," +
                      "UPDEMPLOYEECODERF," +
                      "UPDASSEMBLYID1RF," +
                      "UPDASSEMBLYID2RF," +
                      "LOGICALDELETECODERF," +
                      "SECTIONCODERF," +
                      "SNDRCVHISCONSNORF," +
                      "SNDRCVHISCONSDERIVNORF," +
                      "KINDRF," +
                      "FILEIDRF," +
                      "EXTRASTARTDATERF," +
                      "EXTRAENDDATERF," +
                      "STARTCOND1RF," +
                      "ENDCOND1RF," +
                      "STARTCOND2RF," +
                      "ENDCOND2RF," +
                      "STARTCOND3RF," +
                      "ENDCOND3RF," +
                      "STARTCOND4RF," +
                      "ENDCOND4RF," +
                      "STARTCOND5RF," +
                      "ENDCOND5RF," +
                      "STARTCOND6RF," +
                      "ENDCOND6RF," +
                      "STARTCOND7RF," +
                      "ENDCOND7RF," +
                      "STARTCOND8RF," +
                      "ENDCOND8RF," +
                      "STARTCOND9RF," +
                      "ENDCOND9RF," +
                      "STARTCOND10RF," +
                      "ENDCOND10RF " +
                    "FROM SNDRCVETRRF ");
                sqlTxt.Append(MakeWhereStringSub(ref sqlCommand, sndRcvHisTableWork));
                sqlCommand.CommandText = sqlTxt.ToString();

                myReader = sqlCommand.ExecuteReader();

                int colIndex_CreateDateTime = 0;
                int colIndex_UpdateDateTime = 0;
                int colIndex_EnterpriseCode = 0;
                int colIndex_FileHeaderGuid = 0;
                int colIndex_UpdEmployeeCode = 0;
                int colIndex_UpdAssemblyId1 = 0;
                int colIndex_UpdAssemblyId2 = 0;
                int colIndex_LogicalDeleteCode = 0;
                int colIndex_SectionCode = 0;
                int colIndex_SndRcvHisConsNo = 0;
                int colIndex_SndRcvHisConsDerivNo = 0;
                int colIndex_Kind = 0;
                int colIndex_FileId = 0;
                int colIndex_ExtraStartDate = 0;
                int colIndex_ExtraEndDate = 0;
                int colIndex_StartCond1 = 0;
                int colIndex_EndCond1 = 0;
                int colIndex_StartCond2 = 0;
                int colIndex_EndCond2 = 0;
                int colIndex_StartCond3 = 0;
                int colIndex_EndCond3 = 0;
                int colIndex_StartCond4 = 0;
                int colIndex_EndCond4 = 0;
                int colIndex_StartCond5 = 0;
                int colIndex_EndCond5 = 0;
                int colIndex_StartCond6 = 0;
                int colIndex_EndCond6 = 0;
                int colIndex_StartCond7 = 0;
                int colIndex_EndCond7 = 0;
                int colIndex_StartCond8 = 0;
                int colIndex_EndCond8 = 0;
                int colIndex_StartCond9 = 0;
                int colIndex_EndCond9 = 0;
                int colIndex_StartCond10 = 0;
                int colIndex_EndCond10 = 0;

                if (myReader.HasRows)
                {
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    colIndex_EnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
                    colIndex_FileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
                    colIndex_UpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
                    colIndex_UpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
                    colIndex_UpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    colIndex_SectionCode = myReader.GetOrdinal("SECTIONCODERF");
                    colIndex_SndRcvHisConsNo = myReader.GetOrdinal("SNDRCVHISCONSNORF");
                    colIndex_SndRcvHisConsDerivNo = myReader.GetOrdinal("SNDRCVHISCONSDERIVNORF");
                    colIndex_Kind = myReader.GetOrdinal("KINDRF");
                    colIndex_FileId = myReader.GetOrdinal("FILEIDRF");
                    colIndex_ExtraStartDate = myReader.GetOrdinal("EXTRASTARTDATERF");
                    colIndex_ExtraEndDate = myReader.GetOrdinal("EXTRAENDDATERF");
                    colIndex_StartCond1 = myReader.GetOrdinal("STARTCOND1RF");
                    colIndex_EndCond1 = myReader.GetOrdinal("ENDCOND1RF");
                    colIndex_StartCond2 = myReader.GetOrdinal("STARTCOND2RF");
                    colIndex_EndCond2 = myReader.GetOrdinal("ENDCOND2RF");
                    colIndex_StartCond3 = myReader.GetOrdinal("STARTCOND3RF");
                    colIndex_EndCond3 = myReader.GetOrdinal("ENDCOND3RF");
                    colIndex_StartCond4 = myReader.GetOrdinal("STARTCOND4RF");
                    colIndex_EndCond4 = myReader.GetOrdinal("ENDCOND4RF");
                    colIndex_StartCond5 = myReader.GetOrdinal("STARTCOND5RF");
                    colIndex_EndCond5 = myReader.GetOrdinal("ENDCOND5RF");
                    colIndex_StartCond6 = myReader.GetOrdinal("STARTCOND6RF");
                    colIndex_EndCond6 = myReader.GetOrdinal("ENDCOND6RF");
                    colIndex_StartCond7 = myReader.GetOrdinal("STARTCOND7RF");
                    colIndex_EndCond7 = myReader.GetOrdinal("ENDCOND7RF");
                    colIndex_StartCond8 = myReader.GetOrdinal("STARTCOND8RF");
                    colIndex_EndCond8 = myReader.GetOrdinal("ENDCOND8RF");
                    colIndex_StartCond9 = myReader.GetOrdinal("STARTCOND9RF");
                    colIndex_EndCond9 = myReader.GetOrdinal("ENDCOND9RF");
                    colIndex_StartCond10 = myReader.GetOrdinal("STARTCOND10RF");
                    colIndex_EndCond10 = myReader.GetOrdinal("ENDCOND10RF");

                }

                while (myReader.Read())
                {

                    #region �N���X�֊i�[
                    wkLogWork = new SndRcvEtrWork();//ADD 2012/10/16 ������ for redmine#31026
                    wkLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    wkLogWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    wkLogWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, colIndex_EnterpriseCode);
                    wkLogWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, colIndex_FileHeaderGuid);
                    wkLogWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, colIndex_UpdEmployeeCode);
                    wkLogWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId1);
                    wkLogWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId2);
                    wkLogWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    wkLogWork.SectionCode = SqlDataMediator.SqlGetString(myReader, colIndex_SectionCode);
                    wkLogWork.SndRcvHisConsNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndRcvHisConsNo);
                    wkLogWork.SndRcvHisConsDerivNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndRcvHisConsDerivNo);
                    wkLogWork.Kind = SqlDataMediator.SqlGetInt32(myReader, colIndex_Kind);
                    wkLogWork.FileId = SqlDataMediator.SqlGetString(myReader, colIndex_FileId);
                    wkLogWork.ExtraStartDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_ExtraStartDate);
                    wkLogWork.ExtraEndDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_ExtraEndDate);
                    wkLogWork.StartCond1 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond1);
                    wkLogWork.EndCond1 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond1);
                    wkLogWork.StartCond2 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond2);
                    wkLogWork.EndCond2 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond2);
                    wkLogWork.StartCond3 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond3);
                    wkLogWork.EndCond3 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond3);
                    wkLogWork.StartCond4 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond4);
                    wkLogWork.EndCond4 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond4);
                    wkLogWork.StartCond5 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond5);
                    wkLogWork.EndCond5 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond5);
                    wkLogWork.StartCond6 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond6);
                    wkLogWork.EndCond6 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond6);
                    wkLogWork.StartCond7 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond7);
                    wkLogWork.EndCond7 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond7);
                    wkLogWork.StartCond8 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond8);
                    wkLogWork.EndCond8 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond8);
                    wkLogWork.StartCond9 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond9);
                    wkLogWork.EndCond9 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond9);
                    wkLogWork.StartCond10 = SqlDataMediator.SqlGetString(myReader, colIndex_StartCond10);
                    wkLogWork.EndCond10 = SqlDataMediator.SqlGetString(myReader, colIndex_EndCond10);

                    sndRcvEtrWorkSubList.Add(wkLogWork);
                    #endregion

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteSQLErrorLog(ex, "SearchSubHisProcProc(SndRcvHisTableWork sndRcvHisTableWork, out ArrayList sndRcvEtrWorkSubList, ref SqlConnection sqlConnection)", status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SearchSubHisProcProc(SndRcvHisTableWork sndRcvHisTableWork, out ArrayList sndRcvEtrWorkSubList, ref SqlConnection sqlConnection)", status);
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

            return status;
        }

        # endregion

        # region [Delete]
        /// <summary>
        ///  ���_�Ǘ�DC����M�������𕨗��폜���܂�
        /// </summary>
        /// <remarks>
        /// <param name="paraSndRcvHisConList">�폜���鑗��M�����f�[�^���܂�ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ�DC����M�����̃L�[�l����v���� ���_�Ǘ�DC����M�������𕨗��폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        public int Delete(ref object paraSndRcvHisConList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ArrayList delList = paraSndRcvHisConList as ArrayList;

            try
            {
                if (paraSndRcvHisConList == null) return status;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null)
                {
                    return status;
                }

                sqlConnection.Open();

                //delete���s
                status = this.DeleteProc(delList, ref sqlConnection, ref sqlTransaction);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SndRcvHisConDB.Delete(ref object SndRcvHisConWork)", status);
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

            return status;
        }

        /// <summary>
        /// ���_�Ǘ�DC����M�������𕨗��폜���܂�
        /// </summary>
        /// <remarks>
        /// <param name="delList">���_�Ǘ�DC����M�������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ�DC����M�������𕨗��폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// </remarks>
        private int DeleteProc(ArrayList delList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                foreach (SndRcvHisTableWork sndRcvHisTableWork in delList)
                {
                    StringBuilder sqlTxt = new StringBuilder();

                    # region [SELECT��]
                    sqlTxt.Append(
                        "SELECT " +
                        "CREATEDATETIMERF," +
                        "UPDATEDATETIMERF," +
                        "ENTERPRISECODERF," +
                        "FILEHEADERGUIDRF," +
                        "UPDEMPLOYEECODERF," +
                        "UPDASSEMBLYID1RF," +
                        "UPDASSEMBLYID2RF," +
                        "LOGICALDELETECODERF," +
                        "SNDRCVHISSNDRCVNORF," +
                        "SECTIONCODERF," +
                        "SNDRCVHISCONSNORF," +
                        "SNDRCVDATETIMERF," +
                        "SENDORRECEIVEDIVCDRF," +
                        "KINDRF," +
                        "SNDLOGEXTRACONDDIVRF," +
                        // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                        //"PROCSTARTDATETIMERF," +
                        //"PROCENDDATETIMERF," +
                        // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                        "SENDDESTEPCODERF," +
                        "SENDDESTSECCODERF," +
                        "SNDRCVCONDITIONRF," +
                        "TEMPRECEIVEDIVRF," +
                        "SNDRCVERRCONTENTSRF," +
                        "SNDRCVFILEIDRF" +
                        " FROM SNDRCVHISTABLERF " +
                    "WHERE" +
                    "      ENTERPRISECODERF = @FINDENTERPRISECODE" +
                    "  AND SNDRCVHISSNDRCVNORF = @FINDSNDRCVHISNORF").Append(Environment.NewLine);
                    # endregion
                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);
                    sqlCommand.CommandText = sqlTxt.ToString();

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSndRcvHisSndRcvNo = sqlCommand.Parameters.Add("@FINDSNDRCVHISNORF", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = sndRcvHisTableWork.EnterpriseCode;
                    findParaSndRcvHisSndRcvNo.Value = sndRcvHisTableWork.SndRcvHisSndRcvNo;

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        # region [DELETE��]
                        StringBuilder sqlText1 = new StringBuilder();
                        sqlText1.Append(
                            " DELETE FROM SNDRCVHISTABLERF" +
                            " WHERE ENTERPRISECODERF = @FINDENTERPRISECODE" +
                            " AND SNDRCVHISSNDRCVNORF = @FINDSNDRCVHISNORF").Append(Environment.NewLine);
                        sqlCommand.CommandText = sqlText1.ToString();
                        # endregion

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = sndRcvHisTableWork.EnterpriseCode;
                        findParaSndRcvHisSndRcvNo.Value = sndRcvHisTableWork.SndRcvHisSndRcvNo;
                    }
                    else
                    {
                        // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        return status;
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "SndRcvHisConDB.DeleteProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "SndRcvHisConDB.DeleteProc" + status);
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

            return status;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� sndRcvHisConWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>sndRcvHisConWork</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        private SndRcvHisConWork CopyToSecMngSetWorkFromReader(ref SqlDataReader myReader)
        {
            SndRcvHisConWork sndRcvHisConWork = new SndRcvHisConWork();

            if (myReader != null && sndRcvHisConWork != null)
            {
                # region �N���X�֊i�[
                sndRcvHisConWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                sndRcvHisConWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                sndRcvHisConWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                sndRcvHisConWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                sndRcvHisConWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                sndRcvHisConWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                sndRcvHisConWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                sndRcvHisConWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sndRcvHisConWork.SndRcvHisSndRcvNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVHISSNDRCVNORF"));
                sndRcvHisConWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                sndRcvHisConWork.SndRcvHisConsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVHISCONSNORF"));
                sndRcvHisConWork.SndRcvDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SNDRCVDATETIMERF"));
                sndRcvHisConWork.SendOrReceiveDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SENDORRECEIVEDIVCDRF"));
                sndRcvHisConWork.Kind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("KINDRF"));
                sndRcvHisConWork.SndLogExtraCondDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDLOGEXTRACONDDIVRF"));
                // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                //sndRcvHisConWork.ProcStartDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROCSTARTDATETIMERF"));
                //sndRcvHisConWork.ProcEndDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROCENDDATETIMERF"));
                // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                sndRcvHisConWork.SendDestEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTEPCODERF"));
                sndRcvHisConWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTSECCODERF"));
                sndRcvHisConWork.SndRcvCondition = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVCONDITIONRF"));
                sndRcvHisConWork.TempReceiveDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TEMPRECEIVEDIVRF"));
                sndRcvHisConWork.SndRcvErrContents = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SNDRCVERRCONTENTSRF"));
                sndRcvHisConWork.SndRcvFileID = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SNDRCVFILEIDRF"));
                # endregion
            }
            return sndRcvHisConWork;
        }
        # endregion

        #region [Private���\�b�h�쐬]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="sndRcvHisConWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
        /// <br>Update Note: 2012/12/18 ���j��</br>
        ///	<br>			 Redmine#33961 ���_�Ǘ����O�Q�ƃc�[���ɂāA
        ///�@�@�@�@�@�@�@�@�@����M�敪�Ɂu�S�āv���w�肵�����s���̑Ή�</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SndRcvHisConWork sndRcvHisConWork)
        {

            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append(" WHERE ");

            //�_���폜�敪
            sqlTxt.Append("HISTAB.LOGICALDELETECODERF = @FINDLOGICALDELETECODE").Append(Environment.NewLine); //����M���𗚗��f�[�^
            //sqlTxt.Append("AND HIS.LOGICALDELETECODERF = @FINDLOGICALDELETECODE").Append(Environment.NewLine);  //����M�������O�f�[�^//DEL 2012/10/16 ������ for redmine#31026
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            if (sndRcvHisConWork != null)
            {
                if (sndRcvHisConWork.SendOrReceiveDivCd == 0)
                {
                    //�p�����[�^.��ƃR�[�h��Empty�ł͂Ȃ��ꍇ
                    if (sndRcvHisConWork.EnterpriseCode != null && !sndRcvHisConWork.EnterpriseCode.Trim().Equals(""))
                    {
                        //��ƃR�[�h
                        sqlTxt.Append("AND HISTAB.ENTERPRISECODERF = @FINDENTERPRISECODE").Append(Environment.NewLine);
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                    }
                    //�p�����[�^.���_�R�[�h��Empty�ł͂Ȃ��ꍇ
                    if (!sndRcvHisConWork.SectionCode.Trim().Equals("") && !sndRcvHisConWork.SectionCode.Trim().Equals("00"))
                    {
                        //���_�R�[�h
                        sqlTxt.Append("AND HISTAB.SECTIONCODERF = @FINDSECTIONCODE").Append(Environment.NewLine);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                    }
                }
                if (sndRcvHisConWork.SendOrReceiveDivCd == 1)
                {
                    //���������p�����[�^�ɑ��M���ƃR�[�h�w��̎�
                    if (sndRcvHisConWork.EnterpriseCode != null && !sndRcvHisConWork.EnterpriseCode.Trim().Equals(""))
                    {
                        //���M���ƃR�[�h
                        sqlTxt.Append("AND HISTAB.SENDDESTEPCODERF = @FINDSENDDESTEPCODE").Append(Environment.NewLine);
                        SqlParameter findParaSendDestEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
                        findParaSendDestEpCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                    }
                    if (!sndRcvHisConWork.SectionCode.Trim().Equals("") && !sndRcvHisConWork.SectionCode.Trim().Equals("00"))
                    {
                        //���M�拒�_�R�[�h
                        sqlTxt.Append("AND HISTAB.SENDDESTSECCODERF = @FINDSENDDESTSECCODE").Append(Environment.NewLine);
                        SqlParameter findParaSendDestSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
                        findParaSendDestSecCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                    }
                }

                //����M�敪
                    // --- DEL ������ 2012/10/16 for Redmine#31026---------->>>>>
                    //sqlTxt.Append("AND HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVCD").Append(Environment.NewLine);
                    //SqlParameter findParaSendOrReceiveDivCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVCD", SqlDbType.Int);
                    //findParaSendOrReceiveDivCd.Value = SqlDataMediator.SqlSetInt32(sndRcvHisConWork.SendOrReceiveDivCd);
                    // --- DEL ������ 2012/10/16 for Redmine#31026----------<<<<<
                    // --- ADD ������ 2012/10/16 for Redmine#31026---->>>>>
                if (sndRcvHisConWork.SendOrReceiveDivCd != 2)
                {
                    if (sndRcvHisConWork.SendOrReceiveDivCd == 0)
                    {
                        //���M�����i�J�n�j
                        sqlTxt.Append("AND ( HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVSTRCD").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivStrCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVSTRCD", SqlDbType.Int);
                        findParaSendOrReceiveDivStrCd.Value = SqlDataMediator.SqlSetInt32(0);
                        //���M�����i�I���j
                        sqlTxt.Append("OR HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVENDCD").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivEndCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVENDCD", SqlDbType.Int);
                        findParaSendOrReceiveDivEndCd.Value = SqlDataMediator.SqlSetInt32(1);
                        //���M�����i����M�����X�V�j
                        sqlTxt.Append("OR HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVUPDCD )").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivUpdCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVUPDCD", SqlDbType.Int);
                        findParaSendOrReceiveDivUpdCd.Value = SqlDataMediator.SqlSetInt32(2);
                    }
                    else if (sndRcvHisConWork.SendOrReceiveDivCd == 1)
                    {
                        //��M�����i�J�n�j
                        sqlTxt.Append("AND ( HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVSTRCD").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivStrCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVSTRCD", SqlDbType.Int);
                        findParaSendOrReceiveDivStrCd.Value = SqlDataMediator.SqlSetInt32(3);
                        //��M�����i�I���j
                        sqlTxt.Append("OR HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVENDCD").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivEndCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVENDCD", SqlDbType.Int);
                        findParaSendOrReceiveDivEndCd.Value = SqlDataMediator.SqlSetInt32(4);
                        //��M�����i����M�����X�V�j
                        sqlTxt.Append("OR HISTAB.SENDORRECEIVEDIVCDRF = @FINDSENDORRECEIVEDIVUPDCD )").Append(Environment.NewLine);
                        SqlParameter findParaSendOrReceiveDivUpdCd = sqlCommand.Parameters.Add("@FINDSENDORRECEIVEDIVUPDCD", SqlDbType.Int);
                        findParaSendOrReceiveDivUpdCd.Value = SqlDataMediator.SqlSetInt32(5);

                    }
                }
                else
                {
                    if (sndRcvHisConWork.EnterpriseCode != null && !sndRcvHisConWork.EnterpriseCode.Trim().Equals("") && !sndRcvHisConWork.SectionCode.Trim().Equals("") && !sndRcvHisConWork.SectionCode.Trim().Equals("00"))
                    {
                        //�p�����[�^.��ƃR�[�h��Empty�ł͂Ȃ��A�p�����[�^.���_�R�[�h��Empty�ł͂Ȃ��ꍇ
                        //��ƃR�[�h
                        //sqlTxt.Append("AND (HISTAB.ENTERPRISECODERF = @FINDENTERPRISECODE ").Append(Environment.NewLine);//DEL ���j�� 2012/12/18 for Redmine#33961
                        sqlTxt.Append("AND ((HISTAB.ENTERPRISECODERF = @FINDENTERPRISECODE ").Append(Environment.NewLine);//ADD ���j�� 2012/12/18 for Redmine#33961
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                        //���_�R�[�h
                        sqlTxt.Append("AND HISTAB.SECTIONCODERF = @FINDSECTIONCODE) ").Append(Environment.NewLine);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                        //���M���ƃR�[�h
                        sqlTxt.Append("OR (HISTAB.SENDDESTEPCODERF = @FINDSENDDESTEPCODE ").Append(Environment.NewLine);
                        SqlParameter findParaSendDestEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
                        findParaSendDestEpCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                        //���M�拒�_�R�[�h
                        //sqlTxt.Append("AND HISTAB.SENDDESTSECCODERF = @FINDSENDDESTSECCODE) ").Append(Environment.NewLine);//DEL ���j�� 2012/12/18 for Redmine#33961
                        sqlTxt.Append("AND HISTAB.SENDDESTSECCODERF = @FINDSENDDESTSECCODE)) ").Append(Environment.NewLine);//ADD ���j�� 2012/12/18 for Redmine#33961
                        SqlParameter findParaSendDestSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
                        findParaSendDestSecCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                    }
                    else if ((sndRcvHisConWork.EnterpriseCode != null && !sndRcvHisConWork.EnterpriseCode.Trim().Equals("")) && (sndRcvHisConWork.SectionCode.Trim().Equals("") || sndRcvHisConWork.SectionCode.Trim().Equals("00")))
                    {
                        //�p�����[�^.��ƃR�[�h��Empty�ł͂Ȃ��A�p�����[�^.���_�R�[�h��Empty�ꍇ
                        //��ƃR�[�h
                        //sqlTxt.Append("AND HISTAB.ENTERPRISECODERF = @FINDENTERPRISECODE ").Append(Environment.NewLine);//DEL ���j�� 2012/12/18 for Redmine#33961
                        sqlTxt.Append("AND ( HISTAB.ENTERPRISECODERF = @FINDENTERPRISECODE ").Append(Environment.NewLine);//ADD ���j�� 2012/12/18 for Redmine#33961
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                        //���M���ƃR�[�h
                        //sqlTxt.Append("OR HISTAB.SENDDESTEPCODERF = @FINDSENDDESTEPCODE ").Append(Environment.NewLine);//DEL ���j�� 2012/12/18 for Redmine#33961
                        sqlTxt.Append("OR HISTAB.SENDDESTEPCODERF = @FINDSENDDESTEPCODE )").Append(Environment.NewLine);//ADD ���j�� 2012/12/18 for Redmine#33961
                        SqlParameter findParaSendDestEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
                        findParaSendDestEpCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.EnterpriseCode);
                    }
                    else if ((sndRcvHisConWork.EnterpriseCode == null || sndRcvHisConWork.EnterpriseCode.Trim().Equals("")) && (!sndRcvHisConWork.SectionCode.Trim().Equals("") && !sndRcvHisConWork.SectionCode.Trim().Equals("00")))
                    {
                        //�p�����[�^.��ƃR�[�h��Empty�A�p�����[�^.���_�R�[�h��Empty�ł͂Ȃ��ꍇ
                        //���_�R�[�h
                        //sqlTxt.Append("AND HISTAB.SECTIONCODERF = @FINDSECTIONCODE ").Append(Environment.NewLine);//DEL ���j�� 2012/12/18 for Redmine#33961
                        sqlTxt.Append("AND ( HISTAB.SECTIONCODERF = @FINDSECTIONCODE ").Append(Environment.NewLine);//ADD ���j�� 2012/12/18 for Redmine#33961
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                        //���M�拒�_�R�[�h
                        //sqlTxt.Append("OR HISTAB.SENDDESTSECCODERF = @FINDSENDDESTSECCODE ").Append(Environment.NewLine);//DEL ���j�� 2012/12/18 for Redmine#33961
                        sqlTxt.Append("OR HISTAB.SENDDESTSECCODERF = @FINDSENDDESTSECCODE )").Append(Environment.NewLine);//ADD ���j�� 2012/12/18 for Redmine#33961
                        SqlParameter findParaSendDestSecCode = sqlCommand.Parameters.Add("@FINDSENDDESTSECCODE", SqlDbType.NChar);
                        findParaSendDestSecCode.Value = SqlDataMediator.SqlSetString(sndRcvHisConWork.SectionCode);
                    }
                }
                // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<

                //�p�����[�^.����M��(�J�n)>0�̏ꍇ������ǉ�
                if (sndRcvHisConWork.SndRcvStartDateTime > 0)
                {
                    //����M��>=���������p�����[�^�Ŏw�肳�ꂽ����M��(�J�n)
                    sqlTxt.Append("AND HISTAB.SNDRCVDATETIMERF >= @FINDPROCSTARTDATETIME").Append(Environment.NewLine);
                    SqlParameter findParaSndRcvDateTime = sqlCommand.Parameters.Add("@FINDPROCSTARTDATETIME", SqlDbType.BigInt);
                    findParaSndRcvDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisConWork.SndRcvStartDateTime);
                }

                //�p�����[�^.����M��(�I��)>0�̏ꍇ������ǉ�
                if (sndRcvHisConWork.SndRcvEndDateTime > 0)
                {
                    //����M��<=���������p�����[�^�Ŏw�肳�ꂽ����M��(�I��)
                    sqlTxt.Append("AND HISTAB.SNDRCVDATETIMERF <= @FINDPROCENDDATETIME").Append(Environment.NewLine);
                    SqlParameter findParaSndRcvDateTime = sqlCommand.Parameters.Add("@FINDPROCENDDATETIME", SqlDbType.BigInt);
                    findParaSndRcvDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisConWork.SndRcvEndDateTime);
                }
            }
            //sqlTxt.Append(" ORDER BY HISTAB.ENTERPRISECODERF, HISTAB.SECTIONCODERF, HISTAB.SNDRCVHISCONSNORF ").Append(Environment.NewLine);//DEL 2012/10/16 ������ for redmine#31026
            sqlTxt.Append(" ORDER BY HISTAB.ENTERPRISECODERF, HISTAB.SNDRCVHISSNDRCVNORF ").Append(Environment.NewLine);//ADD 2012/10/16 ������ for redmine#31026

            return sqlTxt.ToString();
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="sndRcvHisTableWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/07/23</br>
        private string MakeWhereStringSub(ref SqlCommand sqlCommand, SndRcvHisTableWork sndRcvHisTableWork)
        {

            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append(" WHERE ");

            //��ƃR�[�h
            sqlTxt.Append("ENTERPRISECODERF = @ENTERPRISECODE").Append(Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.EnterpriseCode);

            //�_���폜�敪
            sqlTxt.Append("AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE").Append(Environment.NewLine);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            //���_�R�[�h
            sqlTxt.Append("AND SECTIONCODERF = @SECTIONCODE").Append(Environment.NewLine);
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisTableWork.SectionCode);

            //����M�������O���M�ԍ�
            sqlTxt.Append("AND SNDRCVHISCONSNORF = @SNDRCVHISCONSNO").Append(Environment.NewLine);
            SqlParameter parSndRcvHisConsNo = sqlCommand.Parameters.Add("@SNDRCVHISCONSNO", SqlDbType.Int);
            parSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisTableWork.SndRcvHisConsNo);

            return sqlTxt.ToString();
        }

        #endregion
    }
}

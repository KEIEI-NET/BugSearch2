//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : DC����M�������O�����[�g
// �v���O�����T�v   : DC����M�������O��ΏۂɁA�������ꊇ�œo�^�E�C���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : lushan
// �� �� ��  2011/07/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : sundx
// �� �� ��  2011/08/23  �C�����e : #23826�}�X�^����M�����F������M���ł��Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : sundx
// �� �� ��  2011/08/24  �C�����e : ���W�J�ꗗNO.10 �G���[���O��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/08/24  �C�����e : #23897�@�f�[�^�폜���̕s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/09/02  �C�����e : #23777�@StringBuilder���g�p����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/09/05  �C�����e : #24387�@���M�������O�����e��UI���C�˗�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/09/14  �C�����e : Redmine #25051 #24952 ���M�������O�����e�@�f�[�^�\���̕s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2011/10/06  �C�����e : �T�[�o�[�Ď��c�[���Ή� �F�؏�񂪎擾�ł��Ȃ��ꍇ�AClient�w����e�ŏ㏑������B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/11/30  �C�����e : Redmine #8293 ���_�Ǘ��^�`�[���t���t���o����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �� �� ��  2012/10/16  �C�����e : ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�
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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����M�������O�����e�i���XDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����M�������O�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : lushan</br>
    /// <br>Date       : 2011/07/25</br>
    /// <br></br>
    /// <br>Update Note: 2011/10/06  22018 ��� ���b</br>
    /// <br>           : �T�[�o�[�Ď��c�[���Ή� �F�؏�񂪎擾�ł��Ȃ��ꍇ�AClient�w����e�ŏ㏑������B</br>
    /// <br>Update Note: 2012/10/16 ������</br>
    ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SndRcvHisDB : RemoteDB, ISndRcvHisDB
    {
        /// <summary>
        /// ����M�������O�����e�i���XDB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : lushan</br>														   
        /// <br>Date       : 2011/07/25</br>
        /// </remarks>
        public SndRcvHisDB() { }

        #region [Write]
        /// <summary>
        /// ����M�������O����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="pList">pList�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O����o�^�A�X�V���܂�</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        public int Write(ref object pList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteProc(pList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SndRcvHisDB.Write(ref object sndRcvHisWork)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        else
                        {
                            // ���[���o�b�N
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
        /// ���M�������O��������
        /// </summary>
        /// <param name="pList">�p�����[�^�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns></returns>
        public int WriteProc(object pList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList sndRcvHisWorkList = new ArrayList();
            ArrayList sndRcvEtrWorkList = new ArrayList();
            ArrayList paraList = new ArrayList();
            paraList = pList as ArrayList;

            for (int i = 0; i < paraList.Count; i++)
            {
                ArrayList list = paraList[i] as ArrayList ;

                SndRcvHisWork sndRcvHisWork = list[0] as SndRcvHisWork;
                //����M�������O�f�[�^
                sndRcvHisWorkList.Add(sndRcvHisWork);
                ArrayList subSndRcvEtrWorkList = new ArrayList();

                if (list.Count > 1)
                {
                    subSndRcvEtrWorkList = list[1] as ArrayList;
                    //����M���o�����������O�f�[�^
                    for (int j = 0; j < subSndRcvEtrWorkList.Count; j++)
                    {
                        sndRcvEtrWorkList.Add(subSndRcvEtrWorkList[j] as SndRcvEtrWork);
                    }                   
                }
                //write���s
                status = WriteSndRcvHisProc(ref sndRcvHisWorkList, ref sndRcvEtrWorkList, ref sqlConnection, ref sqlTransaction);
            }            

            return status;
        }

        /// <summary>
        /// ����M�������O����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="sndRcvHisWorkList">pList�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O����o�^�A�X�V���܂�</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        /// <br>Update Note: 2012/10/16 ������</br>
        ///	<br>			 Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�</br> 
        public int WriteRcvHisWork(ref ArrayList sndRcvHisWorkList)
        {
            string retMessage = string.Empty;//ADD 2012/10/16 ������ for redmine#31026
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {

                if (sndRcvHisWorkList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteSndRcvHisProcProc(ref sndRcvHisWorkList, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SndRcvHisDB.Write(ref object sndRcvHisWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                retMessage = ex.Message;//ADD 2012/10/16 ������ for redmine#31026
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

            // --- ADD ������ 2012/10/16 for Redmine#31026---------->>>>>
            ArrayList sndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork sndRcvHisTableWork =null;
            foreach (SndRcvHisWork sndRcvHisWork in sndRcvHisWorkList)
            {
                sndRcvHisTableWork = new SndRcvHisTableWork();
                // ��ƃR�[�h
                sndRcvHisTableWork.EnterpriseCode = sndRcvHisWork.EnterpriseCode;
                // ���_�R�[�h
                sndRcvHisTableWork.SectionCode = sndRcvHisWork.SectionCode;
                // ����M�������O���M�ԍ�
                sndRcvHisTableWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                // ����M�敪:��M�����i����M�����X�V�j
                sndRcvHisTableWork.SendOrReceiveDivCd = 5;
                // ����M����
                sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                // ���
                sndRcvHisTableWork.Kind = sndRcvHisWork.Kind;
                // ����M���O���o�����敪
                sndRcvHisTableWork.SndLogExtraCondDiv = sndRcvHisWork.SndLogExtraCondDiv;
                // ���M���ƃR�[�h
                sndRcvHisTableWork.SendDestEpCode = sndRcvHisWork.SendDestEpCode;
                // ���M�拒�_�R�[�h
                sndRcvHisTableWork.SendDestSecCode = sndRcvHisWork.SendDestSecCode;
                //���M�ΏۊJ�n����
                sndRcvHisTableWork.SndObjStartDate = sndRcvHisWork.SndObjStartDate.Ticks;
                //���M�ΏۏI������
                sndRcvHisTableWork.SndObjEndDate = sndRcvHisWork.SndObjEndDate.Ticks;
                // ����M���
                if (status == 0)
                {
                    sndRcvHisTableWork.SndRcvCondition = 0;
                }
                else
                {
                    sndRcvHisTableWork.SndRcvCondition = 1;
                }
                //����M�敪
                sndRcvHisTableWork.TempReceiveDiv = 1;
                // �G���[���e
                sndRcvHisTableWork.SndRcvErrContents = retMessage;

                sndRcvHisResWorkList.Add(sndRcvHisTableWork);
            }

            SndRcvHisTableDB sndRcvHisTableDB = new SndRcvHisTableDB();
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisTableDB.Write(ref objSndRcvHisResWorkList);
            // --- ADD ������ 2012/10/16 for Redmine#31026----------<<<<<
            return status;
        }

        /// <summary>
        /// ����M�������O�f�[�^��o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="SndRcvHisWorkList">SndRcvHisWork�I�u�W�F�N�g</param>
        /// <param name="SndRcvEtrWorkList">SndRcvEtrWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O�f�[�^��o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        public int WriteSndRcvHisProc(ref ArrayList SndRcvHisWorkList, ref ArrayList SndRcvEtrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = this.WriteSndRcvHisProcProc(ref SndRcvHisWorkList, ref sqlConnection, ref sqlTransaction);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (SndRcvEtrWorkList == null || SndRcvEtrWorkList.Count == 0) return status;
                status = this.WriteSndRcvEtrProcProc(ref SndRcvEtrWorkList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// ����M�������O����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="sndRcvHisWorkList">SndRcvHisWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O����o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int WriteSndRcvHisProcProc(ref ArrayList sndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

			# region [DEL 2011.09.02]
			// DEL 2011.09.02 ------->>>>>
			//string command = string.Empty;
			//command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, SNDRCVHISCONSNORF FROM SNDRCVHISRF " + Environment.NewLine;
			//command += "WHERE" + Environment.NewLine;
			//command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
			//command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
			//command += "  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO" + Environment.NewLine;
			// DEL 2011.09.02 -------<<<<<
			# endregion

			// ADD 2011.09.02 ------->>>>>
			StringBuilder sqlText = new StringBuilder();
			sqlText.Append("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, SNDRCVHISCONSNORF FROM SNDRCVHISRF ").Append(Environment.NewLine);
			sqlText.Append("WHERE").Append(Environment.NewLine);
			sqlText.Append("      ENTERPRISECODERF=@FINDENTERPRISECODE" ).Append(Environment.NewLine);
			sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
			sqlText.Append("  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO").Append(Environment.NewLine);
			// ADD 2011.09.02 -------<<<<<

            try
            {
                for (int i = 0; i < sndRcvHisWorkList.Count; i++)
                {
                    SndRcvHisWork sndRcvHisWork = sndRcvHisWorkList[i] as SndRcvHisWork;

					//Select�R�}���h�̐���
					//sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction); // DEL 2011.09.02
					sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction); // ADD 2011.09.02
					sqlCommand.CommandText = sqlText.ToString(); // ADD 2011.09.02

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaSndRcvHisConsNo = sqlCommand.Parameters.Add("@FINDSNDRCVHISCONSNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                    findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime.Ticks != sndRcvHisWork.UpdateDateTime.Ticks)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (sndRcvHisWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
						}

						# region [DEL 2011.09.02]
						// DEL 2011.09.02 ------->>>>>
						//sqlCommand.CommandText = "UPDATE SNDRCVHISRF" + Environment.NewLine;
						//sqlCommand.CommandText += "SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
						//sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , SNDRCVHISCONSNORF=@SNDRCVHISCONSNO" + Environment.NewLine;
						//sqlCommand.CommandText += " , SENDDATETIMERF=@SENDDATETIME" + Environment.NewLine;
						//sqlCommand.CommandText += " , SNDLOGUSEDIVRF=@SNDLOGUSEDIV" + Environment.NewLine;
						//sqlCommand.CommandText += " , SENDORRECEIVEDIVCDRF=@SENDORRECEIVEDIVCD" + Environment.NewLine;
						//sqlCommand.CommandText += " , KINDRF=@KIND" + Environment.NewLine;
						//sqlCommand.CommandText += " , SNDLOGEXTRACONDDIVRF=@SNDLOGEXTRACONDDIV" + Environment.NewLine;
						//sqlCommand.CommandText += " , EXTRAOBJSECCODERF=@EXTRAOBJSECCODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , SNDOBJSTARTDATERF=@SNDOBJSTARTDATE" + Environment.NewLine;
						//sqlCommand.CommandText += " , SNDOBJENDDATERF=@SNDOBJENDDATE" + Environment.NewLine;
						//sqlCommand.CommandText += " , SENDDESTEPCODERF=@SENDDESTEPCODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , SENDDESTSECCODERF=@SENDDESTSECCODE" + Environment.NewLine;
						//sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " AND SECTIONCODERF=@FINDSECTIONCODE " + Environment.NewLine;
						//sqlCommand.CommandText += " AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO " + Environment.NewLine;
						// DEL 2011.09.02 -------<<<<<
						# endregion

						// ADD 2011.09.02 ------->>>>>
						StringBuilder sqlText1 = new StringBuilder();
						sqlText1.Append("UPDATE SNDRCVHISRF").Append(Environment.NewLine);
						sqlText1.Append("SET CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
						sqlText1.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
						sqlText1.Append(" , ENTERPRISECODERF=@ENTERPRISECODE").Append(Environment.NewLine);
						sqlText1.Append(" , FILEHEADERGUIDRF=@FILEHEADERGUID").Append(Environment.NewLine);
						sqlText1.Append(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE").Append(Environment.NewLine);
						sqlText1.Append(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1").Append(Environment.NewLine);
						sqlText1.Append(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2").Append(Environment.NewLine);
						sqlText1.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
						sqlText1.Append(" , SECTIONCODERF=@SECTIONCODE").Append(Environment.NewLine);
						sqlText1.Append(" , SNDRCVHISCONSNORF=@SNDRCVHISCONSNO").Append(Environment.NewLine);
						sqlText1.Append(" , SENDDATETIMERF=@SENDDATETIME").Append(Environment.NewLine);
						sqlText1.Append(" , SNDLOGUSEDIVRF=@SNDLOGUSEDIV").Append(Environment.NewLine);
						sqlText1.Append(" , SENDORRECEIVEDIVCDRF=@SENDORRECEIVEDIVCD").Append(Environment.NewLine);
						sqlText1.Append(" , KINDRF=@KIND").Append(Environment.NewLine);
						sqlText1.Append(" , SNDLOGEXTRACONDDIVRF=@SNDLOGEXTRACONDDIV").Append(Environment.NewLine);
						sqlText1.Append(" , EXTRAOBJSECCODERF=@EXTRAOBJSECCODE").Append(Environment.NewLine);
						sqlText1.Append(" , SNDOBJSTARTDATERF=@SNDOBJSTARTDATE").Append(Environment.NewLine);
						sqlText1.Append(" , SNDOBJENDDATERF=@SNDOBJENDDATE").Append(Environment.NewLine);
						sqlText1.Append(" , SENDDESTEPCODERF=@SENDDESTEPCODE").Append(Environment.NewLine);
						sqlText1.Append(" , SENDDESTSECCODERF=@SENDDESTSECCODE").Append(Environment.NewLine);
                        sqlText1.Append(" , SYNCEXECDATERF=@SYNCEXECDATE").Append(Environment.NewLine);  // ADD 2011/11/30

						sqlText1.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
						sqlText1.Append(" AND SECTIONCODERF=@FINDSECTIONCODE ").Append(Environment.NewLine);
						sqlText1.Append(" AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO ").Append(Environment.NewLine);
						sqlCommand.CommandText = sqlText1.ToString();
						// ADD 2011.09.02 -------<<<<<

                        //KEY�R�}���h���Đݒ�

                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                        findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

                        //�X�V�w�b�_����ݒ�
                        // --- ADD m.suzuki 2011/10/06 ---------->>>>>
                        string updEmployeeCode = sndRcvHisWork.UpdEmployeeCode;
                        string updAssemblyId1 = sndRcvHisWork.UpdAssemblyId1;
                        // --- ADD m.suzuki 2011/10/06 ----------<<<<<
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sndRcvHisWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                        // --- ADD m.suzuki 2011/10/06 ---------->>>>>
                        if ( string.IsNullOrEmpty( sndRcvHisWork.UpdEmployeeCode ) ) sndRcvHisWork.UpdEmployeeCode = updEmployeeCode;
                        if ( string.IsNullOrEmpty( sndRcvHisWork.UpdAssemblyId1 ) ) sndRcvHisWork.UpdAssemblyId1 = updAssemblyId1;
                        // --- ADD m.suzuki 2011/10/06 ----------<<<<<
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (sndRcvHisWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

						//�V�K�쐬����SQL���𐶐�
						# region [DEL 2011.09.02]
						// DEL 2011.09.02 ------->>>>>
						//sqlCommand.CommandText = "INSERT INTO SNDRCVHISRF" ;
						//sqlCommand.CommandText += " (CREATEDATETIMERF" ;
						//sqlCommand.CommandText += "  , UPDATEDATETIMERF";
						//sqlCommand.CommandText += "  , ENTERPRISECODERF";
						//sqlCommand.CommandText += "  , FILEHEADERGUIDRF";
						//sqlCommand.CommandText += "  , UPDEMPLOYEECODERF";
						//sqlCommand.CommandText += "  , UPDASSEMBLYID1RF";
						//sqlCommand.CommandText += "  , UPDASSEMBLYID2RF";
						//sqlCommand.CommandText += "  , LOGICALDELETECODERF";
						//sqlCommand.CommandText += "  , SECTIONCODERF";
						//sqlCommand.CommandText += "  , SNDRCVHISCONSNORF";
						//sqlCommand.CommandText += "  , SENDDATETIMERF";
						//sqlCommand.CommandText += "  , SNDLOGUSEDIVRF";
						//sqlCommand.CommandText += "  , SENDORRECEIVEDIVCDRF";
						//sqlCommand.CommandText += "  , KINDRF";
						//sqlCommand.CommandText += "  , SNDLOGEXTRACONDDIVRF";
						//sqlCommand.CommandText += "  , EXTRAOBJSECCODERF";
						//sqlCommand.CommandText += "  , SNDOBJSTARTDATERF";
						//sqlCommand.CommandText += "  , SNDOBJENDDATERF";
						//sqlCommand.CommandText += "  , SENDDESTEPCODERF";
						//sqlCommand.CommandText += "  , SENDDESTSECCODERF)";
						//sqlCommand.CommandText += "  VALUES ";
						//sqlCommand.CommandText += "  (@CREATEDATETIME";
						//sqlCommand.CommandText += "  , @UPDATEDATETIME";
						//sqlCommand.CommandText += "  , @ENTERPRISECODE";
						//sqlCommand.CommandText += "  , @FILEHEADERGUID";
						//sqlCommand.CommandText += "  , @UPDEMPLOYEECODE";
						//sqlCommand.CommandText += "  , @UPDASSEMBLYID1";
						//sqlCommand.CommandText += "  , @UPDASSEMBLYID2";
						//sqlCommand.CommandText += "  , @LOGICALDELETECODE";
						//sqlCommand.CommandText += "  , @SECTIONCODE";
						//sqlCommand.CommandText += "  , @SNDRCVHISCONSNO";
						//sqlCommand.CommandText += "  , @SENDDATETIME";
						//sqlCommand.CommandText += "  , @SNDLOGUSEDIV";
						//sqlCommand.CommandText += "  , @SENDORRECEIVEDIVCD";
						//sqlCommand.CommandText += "  , @KIND";
						//sqlCommand.CommandText += "  , @SNDLOGEXTRACONDDIV";
						//sqlCommand.CommandText += "  , @EXTRAOBJSECCODE";
						//sqlCommand.CommandText += "  , @SNDOBJSTARTDATE";
						//sqlCommand.CommandText += "  , @SNDOBJENDDATE";
						//sqlCommand.CommandText += "  , @SENDDESTEPCODE";
						//sqlCommand.CommandText += "  , @SENDDESTSECCODE)";
						// DEL 2011.09.02 -------<<<<<
						# endregion

						// ADD 2011.09.02 ------->>>>>
						StringBuilder sqlText2 = new StringBuilder();
						sqlText2.Append("INSERT INTO SNDRCVHISRF");
						sqlText2.Append(" (CREATEDATETIMERF");
						sqlText2.Append("  , UPDATEDATETIMERF");
						sqlText2.Append("  , ENTERPRISECODERF");
						sqlText2.Append("  , FILEHEADERGUIDRF");
						sqlText2.Append("  , UPDEMPLOYEECODERF");
						sqlText2.Append("  , UPDASSEMBLYID1RF");
						sqlText2.Append("  , UPDASSEMBLYID2RF");
						sqlText2.Append("  , LOGICALDELETECODERF");
						sqlText2.Append("  , SECTIONCODERF");
						sqlText2.Append("  , SNDRCVHISCONSNORF");
						sqlText2.Append("  , SENDDATETIMERF");
						sqlText2.Append("  , SNDLOGUSEDIVRF");
						sqlText2.Append("  , SENDORRECEIVEDIVCDRF");
						sqlText2.Append("  , KINDRF");
						sqlText2.Append("  , SNDLOGEXTRACONDDIVRF");
						sqlText2.Append("  , EXTRAOBJSECCODERF");
						sqlText2.Append("  , SNDOBJSTARTDATERF");
						sqlText2.Append("  , SNDOBJENDDATERF");
						sqlText2.Append("  , SENDDESTEPCODERF");
                        sqlText2.Append("  , SYNCEXECDATERF");   // ADD 2011/11/30
						sqlText2.Append("  , SENDDESTSECCODERF)");
						sqlText2.Append("  VALUES ");
						sqlText2.Append("  (@CREATEDATETIME");
						sqlText2.Append("  , @UPDATEDATETIME");
						sqlText2.Append("  , @ENTERPRISECODE");
						sqlText2.Append("  , @FILEHEADERGUID");
						sqlText2.Append("  , @UPDEMPLOYEECODE");
						sqlText2.Append("  , @UPDASSEMBLYID1");
						sqlText2.Append("  , @UPDASSEMBLYID2");
						sqlText2.Append("  , @LOGICALDELETECODE");
						sqlText2.Append("  , @SECTIONCODE");
						sqlText2.Append("  , @SNDRCVHISCONSNO");
						sqlText2.Append("  , @SENDDATETIME");
						sqlText2.Append("  , @SNDLOGUSEDIV");
						sqlText2.Append("  , @SENDORRECEIVEDIVCD");
						sqlText2.Append("  , @KIND");
						sqlText2.Append("  , @SNDLOGEXTRACONDDIV");
						sqlText2.Append("  , @EXTRAOBJSECCODE");
						sqlText2.Append("  , @SNDOBJSTARTDATE");
						sqlText2.Append("  , @SNDOBJENDDATE");
						sqlText2.Append("  , @SENDDESTEPCODE");
                        sqlText2.Append("  , @SYNCEXECDATE");  // ADD 2011/11/30
						sqlText2.Append("  , @SENDDESTSECCODE)");
						sqlCommand.CommandText = sqlText2.ToString();
						// ADD 2011.09.02 --------<<<<<

                        //�o�^�w�b�_����ݒ�
                        // --- ADD m.suzuki 2011/10/06 ---------->>>>>
                        string updEmployeeCode = sndRcvHisWork.UpdEmployeeCode;
                        string updAssemblyId1 = sndRcvHisWork.UpdAssemblyId1;
                        // --- ADD m.suzuki 2011/10/06 ----------<<<<<
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sndRcvHisWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                        // --- ADD m.suzuki 2011/10/06 ---------->>>>>
                        if ( string.IsNullOrEmpty( sndRcvHisWork.UpdEmployeeCode ) ) sndRcvHisWork.UpdEmployeeCode = updEmployeeCode;
                        if ( string.IsNullOrEmpty( sndRcvHisWork.UpdAssemblyId1 ) ) sndRcvHisWork.UpdAssemblyId1 = updAssemblyId1;
                        // --- ADD m.suzuki 2011/10/06 ----------<<<<<
                    }
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
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSndRcvHisConsNo = sqlCommand.Parameters.Add("@SNDRCVHISCONSNO", SqlDbType.Int);
                    SqlParameter paraSendDateTime = sqlCommand.Parameters.Add("@SENDDATETIME", SqlDbType.BigInt);
                    SqlParameter paraSndLogUseDiv = sqlCommand.Parameters.Add("@SNDLOGUSEDIV", SqlDbType.Int);
                    SqlParameter paraSendOrReceiveDivCd = sqlCommand.Parameters.Add("@SENDORRECEIVEDIVCD", SqlDbType.Int);
                    SqlParameter paraKind = sqlCommand.Parameters.Add("@KIND", SqlDbType.Int);
                    SqlParameter paraSndLogExtraCondDiv = sqlCommand.Parameters.Add("@SNDLOGEXTRACONDDIV", SqlDbType.Int);
                    SqlParameter paraExtraObjSecCode = sqlCommand.Parameters.Add("@EXTRAOBJSECCODE", SqlDbType.NChar);
                    SqlParameter paraSndObjStartDate = sqlCommand.Parameters.Add("@SNDOBJSTARTDATE", SqlDbType.BigInt);
                    SqlParameter paraSndObjEndDate = sqlCommand.Parameters.Add("@SNDOBJENDDATE", SqlDbType.BigInt);
                    SqlParameter paraSendDestEpCode = sqlCommand.Parameters.Add("@SENDDESTEPCODE", SqlDbType.NChar);
                    SqlParameter paraSyncExecDate = sqlCommand.Parameters.Add("@SYNCEXECDATE", SqlDbType.BigInt);  // ADD 2011/11/30
                    SqlParameter paraSendDestSecCode = sqlCommand.Parameters.Add("@SENDDESTSECCODE", SqlDbType.NChar);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sndRcvHisWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                    paraSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);
                    paraSendDateTime.Value = SqlDataMediator.SqlSetInt64(sndRcvHisWork.SendDateTime);
                    paraSndLogUseDiv.Value = SqlDataMediator.SqlSetInt32(0);
                    paraSendOrReceiveDivCd.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SendOrReceiveDivCd);
                    paraKind.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.Kind);
                    paraSndLogExtraCondDiv.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndLogExtraCondDiv);
                    paraExtraObjSecCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.ExtraObjSecCode);
                    paraSndObjStartDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisWork.SndObjStartDate);
                    paraSndObjEndDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisWork.SndObjEndDate);
                    paraSendDestEpCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SendDestEpCode);
                    paraSyncExecDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisWork.SyncExecDate);  // ADD 2011/11/30
                    paraSendDestSecCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SendDestSecCode);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                    al.Add(sndRcvHisWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);//DEL 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                base.WriteSQLErrorLog(ex);//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�--------------------------------------------------------------------------------------------------------------------------------------------->>>>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SndRcvHisDB.WriteSndRcvHisProcProc(ref ArrayList sndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�---------------------------------------------------------------------------------------------------------------------------------------------<<<<<
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

            sndRcvHisWorkList = al;

            return status;
        }

        /// <summary>
        /// ����M���o�����������O�f�[�^��o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="sndRcvEtrWorkList">SndRcvEtrWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M���o�����������O�f�[�^��o�^�A�X�V���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int WriteSndRcvEtrProcProc(ref ArrayList sndRcvEtrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

			# region [DEL 2011.09.02]
			// DEL 2011.09.02 ------->>>>>
			//string command = string.Empty;
			//command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF, SNDRCVHISCONSNORF, SNDRCVHISCONSDERIVNORF FROM SNDRCVETRRF " + Environment.NewLine;
			//command += "WHERE" + Environment.NewLine;
			//command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
			//command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
			//command += "  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO" + Environment.NewLine;
			//command += "  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
			//command += "  AND SNDRCVHISCONSDERIVNORF=@FINDSNDRCVHISCONSDERIVNO" + Environment.NewLine;
			// DEL 2011.09.02 -------<<<<<
			# endregion

			// ADD 2011.09.02 ------->>>>>
			StringBuilder sqlText = new StringBuilder();
			sqlText.Append("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF, SNDRCVHISCONSNORF, SNDRCVHISCONSDERIVNORF FROM SNDRCVETRRF ").Append(Environment.NewLine);
			sqlText.Append("WHERE").Append(Environment.NewLine);
			sqlText.Append("      ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
			sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
			sqlText.Append("  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO").Append(Environment.NewLine);
			sqlText.Append("  AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE").Append(Environment.NewLine);
			sqlText.Append("  AND SNDRCVHISCONSDERIVNORF=@FINDSNDRCVHISCONSDERIVNO").Append(Environment.NewLine);
			// ADD 2011.09.02 -------<<<<<

            try
            {
                for (int i = 0; i < sndRcvEtrWorkList.Count; i++)
                {
                    SndRcvEtrWork sndRcvEtrWork = sndRcvEtrWorkList[i] as SndRcvEtrWork;

					//Select�R�}���h�̐���
					//sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction); // DEL 2011.09.02
					sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction); // ADD 2011.09.02
					sqlCommand.CommandText = sqlText.ToString(); // ADD 2011.09.02

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaSndRcvHisConsNo = sqlCommand.Parameters.Add("@FINDSNDRCVHISCONSNO", SqlDbType.Int);
                    SqlParameter findParaSndRcvHisConsDerivNo = sqlCommand.Parameters.Add("@FINDSNDRCVHISCONSDERIVNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EnterpriseCode);
                    findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sndRcvEtrWork.LogicalDeleteCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.SectionCode);
                    findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvEtrWork.SndRcvHisConsNo);
                    findParaSndRcvHisConsDerivNo.Value = SqlDataMediator.SqlSetInt32(sndRcvEtrWork.SndRcvHisConsDerivNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime.Ticks != sndRcvEtrWork.UpdateDateTime.Ticks)
                        {
                            //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                            if (sndRcvEtrWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                            //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                            else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
						}

						# region [DEL 2011.09.02]
						// DEL 2011.09.02 ------->>>>>
						//sqlCommand.CommandText = "UPDATE SNDRCVETRRF" + Environment.NewLine;
						//sqlCommand.CommandText += "SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
						//sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , SNDRCVHISCONSNORF=@SNDRCVHISCONSNO" + Environment.NewLine;
						//sqlCommand.CommandText += " , SNDRCVHISCONSDERIVNORF=@SNDRCVHISCONSDERIVNO" + Environment.NewLine;
						//sqlCommand.CommandText += " , KINDRF=@KIND" + Environment.NewLine;
						//sqlCommand.CommandText += " , FILEIDRF=@FILEID" + Environment.NewLine;
						//sqlCommand.CommandText += " , EXTRASTARTDATERF=@EXTRASTARTDATE" + Environment.NewLine;
						//sqlCommand.CommandText += " , EXTRAENDDATERF=@EXTRAENDDATE" + Environment.NewLine;
						//sqlCommand.CommandText += " , STARTCOND1RF=@STARTCOND1" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENDCOND1RF=@ENDCOND1" + Environment.NewLine;
						//sqlCommand.CommandText += " , STARTCOND2RF=@STARTCOND2" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENDCOND2RF=@ENDCOND2" + Environment.NewLine;
						//sqlCommand.CommandText += " , STARTCOND3RF=@STARTCOND3" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENDCOND3RF=@ENDCOND3" + Environment.NewLine;
						//sqlCommand.CommandText += " , STARTCOND4RF=@STARTCOND4" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENDCOND4RF=@ENDCOND4" + Environment.NewLine;
						//sqlCommand.CommandText += " , STARTCOND5RF=@STARTCOND5" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENDCOND5RF=@ENDCOND5" + Environment.NewLine;
						//sqlCommand.CommandText += " , STARTCOND6RF=@STARTCOND6" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENDCOND6RF=@ENDCOND6" + Environment.NewLine;
						//sqlCommand.CommandText += " , STARTCOND7RF=@STARTCOND7" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENDCOND7RF=@ENDCOND7" + Environment.NewLine;
						//sqlCommand.CommandText += " , STARTCOND8RF=@STARTCOND8" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENDCOND8RF=@ENDCOND8" + Environment.NewLine;
						//sqlCommand.CommandText += " , STARTCOND9RF=@STARTCOND9" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENDCOND9RF=@ENDCOND9" + Environment.NewLine;
						//sqlCommand.CommandText += " , STARTCOND10RF=@STARTCOND10" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENDCOND10RF=@ENDCOND10" + Environment.NewLine; 
						//sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
						//sqlCommand.CommandText += " AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO" + Environment.NewLine;
						//sqlCommand.CommandText += " AND SNDRCVHISCONSDERIVNORF=@FINDSNDRCVHISCONSDERIVNO" + Environment.NewLine;
						//sqlCommand.CommandText += " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
						// DEL 2011.09.02 -------<<<<<
						# endregion

						// ADD 2011.09.02 ------->>>>>
						StringBuilder sqlText1 = new StringBuilder();
						sqlText1.Append( "UPDATE SNDRCVETRRF").Append(Environment.NewLine);
						sqlText1.Append( "SET CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
						sqlText1.Append( " , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
						sqlText1.Append( " , ENTERPRISECODERF=@ENTERPRISECODE").Append(Environment.NewLine);
						sqlText1.Append( " , FILEHEADERGUIDRF=@FILEHEADERGUID").Append(Environment.NewLine);
						sqlText1.Append( " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE").Append(Environment.NewLine);
						sqlText1.Append( " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1").Append(Environment.NewLine);
						sqlText1.Append( " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2").Append(Environment.NewLine);
						sqlText1.Append( " , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
						sqlText1.Append( " , SECTIONCODERF=@SECTIONCODE").Append(Environment.NewLine);
						sqlText1.Append( " , SNDRCVHISCONSNORF=@SNDRCVHISCONSNO").Append(Environment.NewLine);
						sqlText1.Append( " , SNDRCVHISCONSDERIVNORF=@SNDRCVHISCONSDERIVNO").Append(Environment.NewLine);
						sqlText1.Append( " , KINDRF=@KIND").Append(Environment.NewLine);
						sqlText1.Append( " , FILEIDRF=@FILEID").Append(Environment.NewLine);
						sqlText1.Append( " , EXTRASTARTDATERF=@EXTRASTARTDATE").Append(Environment.NewLine);
						sqlText1.Append( " , EXTRAENDDATERF=@EXTRAENDDATE").Append(Environment.NewLine);
						sqlText1.Append( " , STARTCOND1RF=@STARTCOND1").Append(Environment.NewLine);
						sqlText1.Append( " , ENDCOND1RF=@ENDCOND1").Append(Environment.NewLine);
						sqlText1.Append( " , STARTCOND2RF=@STARTCOND2").Append(Environment.NewLine);
						sqlText1.Append( " , ENDCOND2RF=@ENDCOND2").Append(Environment.NewLine);
						sqlText1.Append( " , STARTCOND3RF=@STARTCOND3").Append(Environment.NewLine);
						sqlText1.Append( " , ENDCOND3RF=@ENDCOND3").Append(Environment.NewLine);
						sqlText1.Append( " , STARTCOND4RF=@STARTCOND4").Append(Environment.NewLine);
						sqlText1.Append( " , ENDCOND4RF=@ENDCOND4").Append(Environment.NewLine);
						sqlText1.Append( " , STARTCOND5RF=@STARTCOND5").Append(Environment.NewLine);
						sqlText1.Append( " , ENDCOND5RF=@ENDCOND5").Append(Environment.NewLine);
						sqlText1.Append( " , STARTCOND6RF=@STARTCOND6").Append(Environment.NewLine);
						sqlText1.Append( " , ENDCOND6RF=@ENDCOND6").Append(Environment.NewLine);
						sqlText1.Append( " , STARTCOND7RF=@STARTCOND7").Append(Environment.NewLine);
						sqlText1.Append( " , ENDCOND7RF=@ENDCOND7").Append(Environment.NewLine);
						sqlText1.Append( " , STARTCOND8RF=@STARTCOND8").Append(Environment.NewLine);
						sqlText1.Append( " , ENDCOND8RF=@ENDCOND8").Append(Environment.NewLine);
						sqlText1.Append( " , STARTCOND9RF=@STARTCOND9").Append(Environment.NewLine);
						sqlText1.Append( " , ENDCOND9RF=@ENDCOND9").Append(Environment.NewLine);
						sqlText1.Append( " , STARTCOND10RF=@STARTCOND10").Append(Environment.NewLine);
						sqlText1.Append( " , ENDCOND10RF=@ENDCOND10").Append(Environment.NewLine);

						sqlText1.Append( " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
						sqlText1.Append( " AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
						sqlText1.Append( " AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO").Append(Environment.NewLine);
						sqlText1.Append( " AND SNDRCVHISCONSDERIVNORF=@FINDSNDRCVHISCONSDERIVNO").Append(Environment.NewLine);
						sqlText1.Append( " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE").Append(Environment.NewLine);
						sqlCommand.CommandText = sqlText1.ToString();
						// ADD 2011.09.02 -------<<<<<

                        //KEY�R�}���h���Đݒ�            
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EnterpriseCode);
                        findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sndRcvEtrWork.LogicalDeleteCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.SectionCode);
                        findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvEtrWork.SndRcvHisConsNo);
                        findParaSndRcvHisConsDerivNo.Value = SqlDataMediator.SqlSetInt32(sndRcvEtrWork.SndRcvHisConsDerivNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sndRcvEtrWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (sndRcvEtrWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }

						//�V�K�쐬����SQL���𐶐�
						# region [DEL 2011.09.02]
						// DEL 2011.09.02 ------->>>>>
						//sqlCommand.CommandText = "INSERT INTO SNDRCVETRRF" + Environment.NewLine;
						//sqlCommand.CommandText += " (CREATEDATETIMERF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , UPDATEDATETIMERF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENTERPRISECODERF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , FILEHEADERGUIDRF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , UPDEMPLOYEECODERF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , UPDASSEMBLYID1RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , UPDASSEMBLYID2RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , LOGICALDELETECODERF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , SECTIONCODERF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , SNDRCVHISCONSNORF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , SNDRCVHISCONSDERIVNORF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , KINDRF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , FILEIDRF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , EXTRASTARTDATERF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , EXTRAENDDATERF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , STARTCOND1RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENDCOND1RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , STARTCOND2RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENDCOND2RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , STARTCOND3RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENDCOND3RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , STARTCOND4RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENDCOND4RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , STARTCOND5RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENDCOND5RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , STARTCOND6RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENDCOND6RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , STARTCOND7RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENDCOND7RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , STARTCOND8RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENDCOND8RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , STARTCOND9RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENDCOND9RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , STARTCOND10RF" + Environment.NewLine;
						//sqlCommand.CommandText += "  , ENDCOND10RF)" + Environment.NewLine;
						//sqlCommand.CommandText += "  VALUES " + Environment.NewLine;
						//sqlCommand.CommandText += "  (@CREATEDATETIME" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @UPDATEDATETIME" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENTERPRISECODE" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @FILEHEADERGUID" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @UPDEMPLOYEECODE" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @UPDASSEMBLYID1" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @UPDASSEMBLYID2" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @LOGICALDELETECODE" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @SECTIONCODE" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @SNDRCVHISCONSNO" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @SNDRCVHISCONSDERIVNO" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @KIND" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @FILEID" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @EXTRASTARTDATE" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @EXTRAENDDATE" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @STARTCOND1" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENDCOND1" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @STARTCOND2" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENDCOND2" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @STARTCOND3" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENDCOND3" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @STARTCOND4" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENDCOND4" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @STARTCOND5" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENDCOND5" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @STARTCOND6" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENDCOND6" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @STARTCOND7" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENDCOND7" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @STARTCOND8" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENDCOND8" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @STARTCOND9" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENDCOND9" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @STARTCOND10" + Environment.NewLine;
						//sqlCommand.CommandText += "  , @ENDCOND10)" + Environment.NewLine;
						// DEL 2011.09.02 -------<<<<<
						# endregion

						// ADD 2011.09.02 ------->>>>>
						StringBuilder sqlText2 = new StringBuilder();
						sqlText2.Append( "INSERT INTO SNDRCVETRRF").Append(Environment.NewLine);
						sqlText2.Append( " (CREATEDATETIMERF").Append(Environment.NewLine);
						sqlText2.Append( "  , UPDATEDATETIMERF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENTERPRISECODERF").Append(Environment.NewLine);
						sqlText2.Append( "  , FILEHEADERGUIDRF").Append(Environment.NewLine);
						sqlText2.Append( "  , UPDEMPLOYEECODERF").Append(Environment.NewLine);
						sqlText2.Append( "  , UPDASSEMBLYID1RF").Append(Environment.NewLine);
						sqlText2.Append( "  , UPDASSEMBLYID2RF").Append(Environment.NewLine);
						sqlText2.Append( "  , LOGICALDELETECODERF").Append(Environment.NewLine);
						sqlText2.Append( "  , SECTIONCODERF").Append(Environment.NewLine);
						sqlText2.Append( "  , SNDRCVHISCONSNORF").Append(Environment.NewLine);
						sqlText2.Append( "  , SNDRCVHISCONSDERIVNORF").Append(Environment.NewLine);
						sqlText2.Append( "  , KINDRF").Append(Environment.NewLine);
						sqlText2.Append( "  , FILEIDRF").Append(Environment.NewLine);
						sqlText2.Append( "  , EXTRASTARTDATERF").Append(Environment.NewLine);
						sqlText2.Append( "  , EXTRAENDDATERF").Append(Environment.NewLine);
						sqlText2.Append( "  , STARTCOND1RF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENDCOND1RF").Append(Environment.NewLine);
						sqlText2.Append( "  , STARTCOND2RF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENDCOND2RF").Append(Environment.NewLine);
						sqlText2.Append( "  , STARTCOND3RF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENDCOND3RF").Append(Environment.NewLine);
						sqlText2.Append( "  , STARTCOND4RF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENDCOND4RF").Append(Environment.NewLine);
						sqlText2.Append( "  , STARTCOND5RF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENDCOND5RF").Append(Environment.NewLine);
						sqlText2.Append( "  , STARTCOND6RF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENDCOND6RF").Append(Environment.NewLine);
						sqlText2.Append( "  , STARTCOND7RF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENDCOND7RF").Append(Environment.NewLine);
						sqlText2.Append( "  , STARTCOND8RF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENDCOND8RF").Append(Environment.NewLine);
						sqlText2.Append( "  , STARTCOND9RF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENDCOND9RF").Append(Environment.NewLine);
						sqlText2.Append( "  , STARTCOND10RF").Append(Environment.NewLine);
						sqlText2.Append( "  , ENDCOND10RF)").Append(Environment.NewLine);
						sqlText2.Append( "  VALUES ").Append(Environment.NewLine);
						sqlText2.Append( "  (@CREATEDATETIME").Append(Environment.NewLine);
						sqlText2.Append( "  , @UPDATEDATETIME").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENTERPRISECODE").Append(Environment.NewLine);
						sqlText2.Append( "  , @FILEHEADERGUID").Append(Environment.NewLine);
						sqlText2.Append( "  , @UPDEMPLOYEECODE").Append(Environment.NewLine);
						sqlText2.Append( "  , @UPDASSEMBLYID1").Append(Environment.NewLine);
						sqlText2.Append( "  , @UPDASSEMBLYID2").Append(Environment.NewLine);
						sqlText2.Append( "  , @LOGICALDELETECODE").Append(Environment.NewLine);
						sqlText2.Append( "  , @SECTIONCODE").Append(Environment.NewLine);
						sqlText2.Append( "  , @SNDRCVHISCONSNO").Append(Environment.NewLine);
						sqlText2.Append( "  , @SNDRCVHISCONSDERIVNO").Append(Environment.NewLine);
						sqlText2.Append( "  , @KIND").Append(Environment.NewLine);
						sqlText2.Append( "  , @FILEID").Append(Environment.NewLine);
						sqlText2.Append( "  , @EXTRASTARTDATE").Append(Environment.NewLine);
						sqlText2.Append( "  , @EXTRAENDDATE").Append(Environment.NewLine);
						sqlText2.Append( "  , @STARTCOND1").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENDCOND1").Append(Environment.NewLine);
						sqlText2.Append( "  , @STARTCOND2").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENDCOND2").Append(Environment.NewLine);
						sqlText2.Append( "  , @STARTCOND3").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENDCOND3").Append(Environment.NewLine);
						sqlText2.Append( "  , @STARTCOND4").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENDCOND4").Append(Environment.NewLine);
						sqlText2.Append( "  , @STARTCOND5").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENDCOND5").Append(Environment.NewLine);
						sqlText2.Append( "  , @STARTCOND6").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENDCOND6").Append(Environment.NewLine);
						sqlText2.Append( "  , @STARTCOND7").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENDCOND7").Append(Environment.NewLine);
						sqlText2.Append( "  , @STARTCOND8").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENDCOND8").Append(Environment.NewLine);
						sqlText2.Append( "  , @STARTCOND9").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENDCOND9").Append(Environment.NewLine);
						sqlText2.Append( "  , @STARTCOND10").Append(Environment.NewLine);
						sqlText2.Append( "  , @ENDCOND10)").Append(Environment.NewLine);
						sqlCommand.CommandText = sqlText2.ToString();
						// ADD 2011.09.02 -------<<<<<

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sndRcvEtrWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }
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
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    SqlParameter paraSndRcvHisConsNo = sqlCommand.Parameters.Add("@SNDRCVHISCONSNO", SqlDbType.Int);
                    SqlParameter paraSndRcvHisConsDerivNo = sqlCommand.Parameters.Add("@SNDRCVHISCONSDERIVNO", SqlDbType.Int);
                    SqlParameter paraKind = sqlCommand.Parameters.Add("@KIND", SqlDbType.Int);
                    SqlParameter paraFileId = sqlCommand.Parameters.Add("@FILEID", SqlDbType.NVarChar);
                    SqlParameter paraExtraStartDate = sqlCommand.Parameters.Add("@EXTRASTARTDATE", SqlDbType.BigInt);
                    SqlParameter paraExtraEndDate = sqlCommand.Parameters.Add("@EXTRAENDDATE", SqlDbType.BigInt);
                    SqlParameter paraStartCond1 = sqlCommand.Parameters.Add("@STARTCOND1", SqlDbType.NVarChar);
                    SqlParameter paraEndCond1 = sqlCommand.Parameters.Add("@ENDCOND1", SqlDbType.NVarChar);
                    SqlParameter paraStartCond2 = sqlCommand.Parameters.Add("@STARTCOND2", SqlDbType.NVarChar);
                    SqlParameter paraEndCond2 = sqlCommand.Parameters.Add("@ENDCOND2", SqlDbType.NVarChar);
                    SqlParameter paraStartCond3 = sqlCommand.Parameters.Add("@STARTCOND3", SqlDbType.NVarChar);
                    SqlParameter paraEndCond3 = sqlCommand.Parameters.Add("@ENDCOND3", SqlDbType.NVarChar);
                    SqlParameter paraStartCond4 = sqlCommand.Parameters.Add("@STARTCOND4", SqlDbType.NVarChar);
                    SqlParameter paraEndCond4 = sqlCommand.Parameters.Add("@ENDCOND4", SqlDbType.NVarChar);
                    SqlParameter paraStartCond5 = sqlCommand.Parameters.Add("@STARTCOND5", SqlDbType.NVarChar);
                    SqlParameter paraEndCond5 = sqlCommand.Parameters.Add("@ENDCOND5", SqlDbType.NVarChar);
                    SqlParameter paraStartCond6 = sqlCommand.Parameters.Add("@STARTCOND6", SqlDbType.NVarChar);
                    SqlParameter paraEndCond6 = sqlCommand.Parameters.Add("@ENDCOND6", SqlDbType.NVarChar);
                    SqlParameter paraStartCond7 = sqlCommand.Parameters.Add("@STARTCOND7", SqlDbType.NVarChar);
                    SqlParameter paraEndCond7 = sqlCommand.Parameters.Add("@ENDCOND7", SqlDbType.NVarChar);
                    SqlParameter paraStartCond8 = sqlCommand.Parameters.Add("@STARTCOND8", SqlDbType.NVarChar);
                    SqlParameter paraEndCond8 = sqlCommand.Parameters.Add("@ENDCOND8", SqlDbType.NVarChar);
                    SqlParameter paraStartCond9 = sqlCommand.Parameters.Add("@STARTCOND9", SqlDbType.NVarChar);
                    SqlParameter paraEndCond9 = sqlCommand.Parameters.Add("@ENDCOND9", SqlDbType.NVarChar);
                    SqlParameter paraStartCond10 = sqlCommand.Parameters.Add("@STARTCOND10", SqlDbType.NVarChar);
                    SqlParameter paraEndCond10 = sqlCommand.Parameters.Add("@ENDCOND10", SqlDbType.NVarChar);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvEtrWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvEtrWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sndRcvEtrWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(sndRcvEtrWork.LogicalDeleteCode);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.SectionCode);
                    paraSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvEtrWork.SndRcvHisConsNo);
                    paraSndRcvHisConsDerivNo.Value = SqlDataMediator.SqlSetInt32(sndRcvEtrWork.SndRcvHisConsDerivNo);
                    paraKind.Value = SqlDataMediator.SqlSetInt32(sndRcvEtrWork.Kind);
                    paraFileId.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.FileId);
                    paraExtraStartDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvEtrWork.ExtraStartDate);
                    paraExtraEndDate.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvEtrWork.ExtraEndDate);
                    paraStartCond1.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.StartCond1);
                    paraEndCond1.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EndCond1);
                    paraStartCond2.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.StartCond2);
                    paraEndCond2.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EndCond2);
                    paraStartCond3.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.StartCond3);
                    paraEndCond3.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EndCond3);
                    paraStartCond4.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.StartCond4);
                    paraEndCond4.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EndCond4);
                    paraStartCond5.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.StartCond5);
                    paraEndCond5.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EndCond5);
                    paraStartCond6.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.StartCond6);
                    paraEndCond6.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EndCond6);
                    paraStartCond7.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.StartCond7);
                    paraEndCond7.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EndCond7);
                    paraStartCond8.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.StartCond8);
                    paraEndCond8.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EndCond8);
                    paraStartCond9.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.StartCond9);
                    paraEndCond9.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EndCond9);
                    paraStartCond10.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.StartCond10);
                    paraEndCond10.Value = SqlDataMediator.SqlSetString(sndRcvEtrWork.EndCond10);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                    al.Add(sndRcvEtrWork);
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);//DEL 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                base.WriteSQLErrorLog(ex);//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�---------------------------------------------------------------------------------------------------------->>>>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "WriteSndRcvEtrProcProc(ref ArrayList sndRcvEtrWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�---------------------------------------------------------------------------------------------------------<<<<<
            
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

            sndRcvEtrWorkList = al;

            return status;
        }
        

        #endregion

        #region [Search]
        /// <summary>
        /// ����M�������O�߂�f�[�^���LIST��߂��܂�
        /// </summary>
        /// <param name="searchResult">��������</param>
        /// <param name="sndRcvHisCondWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O�߂�f�[�^���LIST��߂��܂�</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        public int Search(SndRcvHisCondWork sndRcvHisCondWork, out object searchResult)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null)
                {
                    searchResult = new ArrayList();
                    return status; }

                sqlConnection.Open();

                return SearchHisProc(sndRcvHisCondWork, out searchResult, ref sqlConnection);

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SndRcvHisWorkDB.Search");
                searchResult = new ArrayList();
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
        /// �w�肳�ꂽ�����̑���M�������O�߂�f�[�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objSndRcvHisWork">��������</param>
        /// <param name="sndRcvHisCondWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑���M�������O�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int SearchHisProc(SndRcvHisCondWork sndRcvHisCondWork, out object objSndRcvHisWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList sndRcvHisWorkList = null;
            ArrayList sndRcvEtrWorkList = null;

            CustomSerializeArrayList resultList = new CustomSerializeArrayList();

            ArrayList subResultList = new ArrayList();
            //��\����
            status = SearchHisProcProc(out sndRcvHisWorkList, sndRcvHisCondWork, ref sqlConnection);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (sndRcvHisWorkList != null && sndRcvHisWorkList.Count > 0)
                {
                    for (int i = 0; i < sndRcvHisWorkList.Count; i++)
                    {
                        //�q�\����
                        status = this.SearchSubHisProcProc(out sndRcvEtrWorkList, sndRcvHisWorkList[i] as SndRcvHisWork, ref sqlConnection);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        resultList.Add(sndRcvHisWorkList[i]);
                        resultList.Add(sndRcvEtrWorkList);
                    }
                }
            }

            objSndRcvHisWork = new CustomSerializeArrayList();
            objSndRcvHisWork = resultList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̑���M�������O�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="sndRcvHisWorkList">��������</param>
        /// <param name="sndRcvHisCondWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int SearchHisProcProc(out ArrayList sndRcvHisWorkList, SndRcvHisCondWork sndRcvHisCondWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
				// DEL 2011.09.02 -------->>>>>
				//sqlCommand = new SqlCommand("SELECT * FROM SNDRCVHISRF ", sqlConnection);
				//sqlCommand.CommandText += MakeWhereString(ref sqlCommand, sndRcvHisCondWork);
				//myReader = sqlCommand.ExecuteReader();
				// DEL 2011.09.02 --------<<<<<

				// ADD 2011.09.02 -------->>>>>
				string sqlTxt = "";
				sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT * FROM SNDRCVHISRF ");
				sb.Append(MakeWhereString(ref sqlCommand, sndRcvHisCondWork));
				sqlTxt = sb.ToString();
				sqlCommand.CommandText = sqlTxt;				

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
				int colIndex_SendDateTime = 0;
				int colIndex_SndLogUseDiv = 0;
				int colIndex_SendOrReceiveDivCd = 0;
				int colIndex_Kind = 0;
				int colIndex_SndLogExtraCondDiv = 0;
				int colIndex_ExtraObjSecCode = 0;
				int colIndex_SndObjStartDate = 0;
				int colIndex_SndObjEndDate = 0;
				int colIndex_SendDestEpCode = 0;
				int colIndex_SendDestSecCode = 0;
                int colIndex_SyncExecDate = 0;   // ADD 2011/11/30

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
					colIndex_SendDateTime = myReader.GetOrdinal("SENDDATETIMERF");
					colIndex_SndLogUseDiv = myReader.GetOrdinal("SNDLOGUSEDIVRF");
					colIndex_SendOrReceiveDivCd = myReader.GetOrdinal("SENDORRECEIVEDIVCDRF");
					colIndex_Kind = myReader.GetOrdinal("KINDRF");
					colIndex_SndLogExtraCondDiv = myReader.GetOrdinal("SNDLOGEXTRACONDDIVRF");
					colIndex_ExtraObjSecCode = myReader.GetOrdinal("EXTRAOBJSECCODERF");
					colIndex_SndObjStartDate = myReader.GetOrdinal("SNDOBJSTARTDATERF");
					colIndex_SndObjEndDate = myReader.GetOrdinal("SNDOBJENDDATERF");
					colIndex_SendDestEpCode = myReader.GetOrdinal("SENDDESTEPCODERF");
					colIndex_SendDestSecCode = myReader.GetOrdinal("SENDDESTSECCODERF");
                    colIndex_SyncExecDate = myReader.GetOrdinal("SYNCEXECDATERF");  // ADD 2011/11/30
				}
				// ADD 2011.09.02 --------<<<<<

                while (myReader.Read())
                {
					//al.Add(CopyToSndRcvHisWorkFromReader(ref myReader));// DEL 2011.09.02

					// ADD 2011.09.02 ------- >>>>>>>
					SndRcvHisWork wkLogWork = new SndRcvHisWork();
					#region �N���X�֊i�[
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
					wkLogWork.SendDateTime = SqlDataMediator.SqlGetInt64(myReader, colIndex_SendDateTime);
					wkLogWork.SndLogUseDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndLogUseDiv);
					wkLogWork.SendOrReceiveDivCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_SendOrReceiveDivCd);
					wkLogWork.Kind = SqlDataMediator.SqlGetInt32(myReader, colIndex_Kind);
					wkLogWork.SndLogExtraCondDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_SndLogExtraCondDiv);
					wkLogWork.ExtraObjSecCode = SqlDataMediator.SqlGetString(myReader, colIndex_ExtraObjSecCode);
					wkLogWork.SndObjStartDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_SndObjStartDate);
					wkLogWork.SndObjEndDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_SndObjEndDate);
					wkLogWork.SendDestEpCode = SqlDataMediator.SqlGetString(myReader, colIndex_SendDestEpCode);
					wkLogWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, colIndex_SendDestSecCode);
                    wkLogWork.SyncExecDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_SyncExecDate); // ADD 2011/11/30
					#endregion

					al.Add(wkLogWork);
					// ADD 2011.09.02 ------- <<<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);//DEL 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                base.WriteSQLErrorLog(ex);//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�----------------------------------------------------------------------------------------------->>>>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchHisProc(SndRcvHisCondWork sndRcvHisCondWork, out object objSndRcvHisWork, ref SqlConnection sqlConnection)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�------------------------------------------------------------------------------------------------<<<<<
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            sndRcvHisWorkList = al;

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̑���M���o�����������O�f�[�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="sndRcvEtrWorkList">��������</param>
        /// <param name="sndRcvHisWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int SearchSubHisProcProc(out ArrayList sndRcvEtrWorkList, SndRcvHisWork sndRcvHisWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
				// DEL 2011.09.02 -------->>>>>
				//sqlCommand = new SqlCommand("SELECT * FROM SNDRCVETRRF ", sqlConnection);
				//sqlCommand.CommandText += MakeWhereStringSub(ref sqlCommand, sndRcvHisWork);
				//myReader = sqlCommand.ExecuteReader();
				// DEL 2011.09.02 --------<<<<<

				// ADD 2011.09.02 -------->>>>>
				string sqlTxt = "";
				sqlCommand = new SqlCommand(sqlTxt, sqlConnection);
				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT * FROM SNDRCVETRRF ");
				sb.Append(MakeWhereStringSub(ref sqlCommand, sndRcvHisWork));
				sqlTxt = sb.ToString();
				sqlCommand.CommandText = sqlTxt;
				
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
				// ADD 2011.09.02 --------<<<<<

                while (myReader.Read())
                {
					//al.Add(CopyToSndRcvEtrWorkFromReader(ref myReader)); // DEL 2011.09.02

					// ADD 2011.09.02 -------->>>>>
					SndRcvEtrWork wkLogWork = new SndRcvEtrWork();

					#region �N���X�֊i�[
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

					#endregion
					al.Add(wkLogWork);
					// ADD 2011.09.02 --------<<<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);//DEL 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                base.WriteSQLErrorLog(ex);//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�----------------------------------------------------------------------------------------------->>>>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SearchSubHisProcProc(out ArrayList sndRcvEtrWorkList, SndRcvHisWork sndRcvHisWork, ref SqlConnection sqlConnection)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�------------------------------------------------------------------------------------------------<<<<<
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            sndRcvEtrWorkList = al;

            return status;
        }


        #endregion

        #region [Delete]
        /// <summary>
        /// ����M�������O�f�[�^�𕨗��폜���܂�
        /// </summary>
        /// <param name="sndRcvHisWorkList">�폜���鑗��M�������O�f�[�^���܂�ArrayList</param>
        /// <returns>STATUS</returns>
        public int Delete(ref object sndRcvHisWorkList)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                if (sndRcvHisWorkList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //delete���s
                status = DeleteSndRcvHisProc(sndRcvHisWorkList, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SndRcvHisDB.Delete(ref object sndRcvHisWork)");
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
        /// ����M�������O�f�[�^���폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="SndRcvHisWorkList">SecMngSendLogWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O�f�[�^���폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int DeleteSndRcvHisProc(object SndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList list = SndRcvHisWorkList as ArrayList;

            status = this.DeleteSndRcvEtrProcProc(list, ref sqlConnection, ref sqlTransaction);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.DeleteSndRcvHisProcProcProc(list, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// ����M�������O�����폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="sndRcvHisWorkList">SecMngSendLogWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O�����폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int DeleteSndRcvHisProcProcProc(ArrayList sndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

			# region [DEL 2011.09.02]
			// DEL 2011.09.02 ------->>>>>
			//string command = string.Empty;
			//command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, SNDRCVHISCONSNORF FROM SNDRCVHISRF " + Environment.NewLine;
			//command += "WHERE" + Environment.NewLine;
			//command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
			//command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
			//command += "  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO" + Environment.NewLine;
			// DEL 2011.09.02 -------<<<<<
			# endregion

			// ADD 2011.09.02 ------->>>>>
			StringBuilder sqlText = new StringBuilder();
			sqlText.Append("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, SNDRCVHISCONSNORF FROM SNDRCVHISRF ").Append(Environment.NewLine);
			sqlText.Append("WHERE").Append(Environment.NewLine);
			sqlText.Append("      ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
			sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
			sqlText.Append("  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO").Append(Environment.NewLine);
			// ADD 2011.09.02 -------<<<<<

            try
            {
                for (int i = 0; i < sndRcvHisWorkList.Count; i++)
                {
                    SndRcvHisWork sndRcvHisWork = sndRcvHisWorkList[i] as SndRcvHisWork;

					//Select�R�}���h�̐���
					//sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction); // DEL 2011.09.02
					sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction); // ADD 2011.09.02
					sqlCommand.CommandText = sqlText.ToString(); // ADD 2011.09.02

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaSndRcvHisConsNo = sqlCommand.Parameters.Add("@FINDSNDRCVHISCONSNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                    findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt(sndRcvHisWork.SndRcvHisConsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime.Ticks!=sndRcvHisWork.UpdateDateTime.Ticks)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
						}

						# region [DEL 2011.09.02]
						// DEL 2011.09.02 ------->>>>>
						//sqlCommand.CommandText = "DELETE FROM SNDRCVHISRF" + Environment.NewLine;
						//sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " AND SECTIONCODERF=@FINDSECTIONCODE " + Environment.NewLine;
						//sqlCommand.CommandText += " AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO " + Environment.NewLine;
						// DEL 2011.09.02 -------<<<<<
						# endregion

						// ADD 2011.09.02 ------->>>>>
						StringBuilder sqlText1 = new StringBuilder();
						sqlText1.Append("DELETE FROM SNDRCVHISRF").Append(Environment.NewLine);
						sqlText1.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
						sqlText1.Append(" AND SECTIONCODERF=@FINDSECTIONCODE ").Append(Environment.NewLine);
						sqlText1.Append(" AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO ").Append(Environment.NewLine);
						sqlCommand.CommandText = sqlText1.ToString();
						// ADD 2011.09.02 -------<<<<<

                        //KEY�R�}���h���Đݒ�

                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                        findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

                        if (myReader.IsClosed == false) myReader.Close();
                        sqlCommand.ExecuteNonQuery();

                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (sndRcvHisWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);//DEL 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                base.WriteSQLErrorLog(ex);//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�----------------------------------------------------------------------------------------------->>>>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteSndRcvHisProcProcProc(ArrayList sndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�------------------------------------------------------------------------------------------------<<<<<
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

        /// <summary>
        /// ����M���o�����������O�f�[�^���폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="SndRcvHisWorkList">SecMngSendLogWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M���o�����������O�f�[�^���폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int DeleteSndRcvEtrProcProc(ArrayList SndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

			# region [DEL 2011.09.02]
			// DEL 2011.09.02 ------->>>>>
			//string command = string.Empty;
			//command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF, SNDRCVHISCONSNORF, SNDRCVHISCONSDERIVNORF FROM SNDRCVETRRF " + Environment.NewLine;
			//command += "WHERE" + Environment.NewLine;
			//command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
			//command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
			//command += "  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO" + Environment.NewLine;
			// DEL 2011.09.02 -------<<<<<
			# endregion

			// ADD 2011.09.02 ------->>>>>
			StringBuilder sqlText = new StringBuilder();
			sqlText.Append("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF, SNDRCVHISCONSNORF, SNDRCVHISCONSDERIVNORF FROM SNDRCVETRRF ").Append(Environment.NewLine);
			sqlText.Append("WHERE").Append(Environment.NewLine);
			sqlText.Append("      ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
			sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
			sqlText.Append("  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO").Append(Environment.NewLine);
			// ADD 2011.09.02 -------<<<<<
            try
            {
                for (int i = 0; i < SndRcvHisWorkList.Count; i++)
                {
                    SndRcvHisWork sndRcvHisWork = SndRcvHisWorkList[i] as SndRcvHisWork;

					//Select�R�}���h�̐���
					//sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction); // DEL 2011.09.02
					sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction); // ADD 2011.09.02
					sqlCommand.CommandText = sqlText.ToString(); // ADD 2011.09.02

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);                    
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaSndRcvHisConsNo = sqlCommand.Parameters.Add("@FINDSNDRCVHISCONSNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                    findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        ////����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        //if (_updateDateTime != sndRcvHisWork.UpdateDateTime)
                        //{
                        //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        //    sqlCommand.Cancel();
                        //    return status;
						//}

						# region [DEL 2011.09.02]
						// DEL 2011.09.02 ------->>>>>
						//sqlCommand.CommandText = "DELETE FROM SNDRCVETRRF" + Environment.NewLine;
						//sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
						//sqlCommand.CommandText += " AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO" + Environment.NewLine;
						// DEL 2011.09.02 -------<<<<<
						# endregion

						// ADD 2011.09.02 ------->>>>>
						StringBuilder sqlText1 = new StringBuilder();
						sqlText1.Append("DELETE FROM SNDRCVETRRF").Append(Environment.NewLine);
						sqlText1.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
						sqlText1.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
						sqlText1.Append(" AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO").Append(Environment.NewLine);
						sqlCommand.CommandText = sqlText1.ToString();
						// ADD 2011.09.02 -------<<<<<

                        //KEY�R�}���h���Đݒ�            
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                        findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

                        if (myReader.IsClosed == false) myReader.Close();
                        sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
						//return status;   // DEL 2011.08.24
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);//DEL 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                base.WriteSQLErrorLog(ex);//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�----------------------------------------------------------------------------------------------->>>>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DeleteSndRcvEtrProcProc(ArrayList SndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�------------------------------------------------------------------------------------------------<<<<<
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

        #region [LogicDelete]
        /// <summary>
        /// ����M�������O�f�[�^��Logic�폜���܂�
        /// </summary>
        /// <param name="sndRcvHisWorkList">�폜���鑗��M�������O�f�[�^���܂�ArrayList</param>
        /// <returns>STATUS</returns>
        public int LogicDelete(ref object sndRcvHisWorkList)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                if (sndRcvHisWorkList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //delete���s
                status = LogicDeleteSndRcvHisProc(sndRcvHisWorkList, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "SndRcvHisDB.LogicDelete(ref object sndRcvHisWork)");
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
        /// ����M�������O�f�[�^��Logic�폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="SndRcvHisWorkList">SecMngSendLogWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O�f�[�^���폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int LogicDeleteSndRcvHisProc(object SndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList list = SndRcvHisWorkList as ArrayList;
            status = this.LogicDeleteSndRcvEtrProcProc(list, ref sqlConnection, ref sqlTransaction);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = this.LogicDeleteSndRcvHisProcProc(list, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }

        /// <summary>
        /// ����M�������O����Logic�폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="sndRcvHisWorkList">SecMngSendLogWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O����Logic�폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int LogicDeleteSndRcvHisProcProc(ArrayList sndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

			# region [DEL 2011.09.02]
			//string command = string.Empty;
			//command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, SNDRCVHISCONSNORF FROM SNDRCVHISRF " + Environment.NewLine;
			//command += "WHERE" + Environment.NewLine;
			//command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
			//command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
			//command += "  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO" + Environment.NewLine;
			// DEL 2011.09.02 -------<<<<<
			# endregion

			// ADD 2011.09.02 ------->>>>>
			StringBuilder sqlText = new StringBuilder();
			sqlText.Append("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, SNDRCVHISCONSNORF FROM SNDRCVHISRF ").Append(Environment.NewLine);
			sqlText.Append("WHERE").Append(Environment.NewLine);
			sqlText.Append("      ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
			sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
			sqlText.Append("  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO").Append(Environment.NewLine);
			// ADD 2011.09.02 -------<<<<<
            try
            {
                for (int i = 0; i < sndRcvHisWorkList.Count; i++)
                {
                    SndRcvHisWork sndRcvHisWork = sndRcvHisWorkList[i] as SndRcvHisWork;

					//Select�R�}���h�̐���
					//sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction); // DEL 2011.09.02
					sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction); // ADD 2011.09.02
					sqlCommand.CommandText = sqlText.ToString(); // ADD 2011.09.02

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaSndRcvHisConsNo = sqlCommand.Parameters.Add("@FINDSNDRCVHISCONSNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                    findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime.Ticks != sndRcvHisWork.UpdateDateTime.Ticks)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
						}
						# region [DEL 2011.09.02]
						// DEL 2011.09.02 ------->>>>>
						//sqlCommand.CommandText = "UPDATE SNDRCVHISRF" + Environment.NewLine;
						//sqlCommand.CommandText += "SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
						//sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " AND SECTIONCODERF=@FINDSECTIONCODE " + Environment.NewLine;
						//sqlCommand.CommandText += " AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO " + Environment.NewLine;
						// DEL 2011.09.02 -------<<<<<
						# endregion

						// ADD 2011.09.02 ------->>>>>
						sqlText = new StringBuilder();
						sqlText.Append("UPDATE SNDRCVHISRF").Append(Environment.NewLine);
						sqlText.Append("SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
						sqlText.Append(" , ENTERPRISECODERF=@ENTERPRISECODE").Append(Environment.NewLine);
						sqlText.Append(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE").Append(Environment.NewLine);
						sqlText.Append(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1").Append(Environment.NewLine);
						sqlText.Append(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2").Append(Environment.NewLine);
						sqlText.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
						sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
						sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE ").Append(Environment.NewLine);
						sqlText.Append(" AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO ").Append(Environment.NewLine);
						sqlCommand.CommandText = sqlText.ToString();
						// ADD 2011.09.02 -------<<<<<

                        //KEY�R�}���h���Đݒ�

                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                        findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sndRcvHisWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

                        #region Parameter�I�u�W�F�N�g�̍쐬
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);                   
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(1);
                        #endregion

                        if (myReader.IsClosed == false) myReader.Close();
                        sqlCommand.ExecuteNonQuery();

                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        if (sndRcvHisWork.UpdateDateTime > DateTime.MinValue)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            if (myReader.IsClosed == false) myReader.Close();
                            return status;
                        }
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);//DEL 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                base.WriteSQLErrorLog(ex);//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�----------------------------------------------------------------------------------------------->>>>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LogicDeleteSndRcvHisProcProc(ArrayList sndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�------------------------------------------------------------------------------------------------<<<<<
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

        /// <summary>
        /// ����M���o�����������O�f�[�^��Logic�폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)
        /// </summary>
        /// <param name="SndRcvHisWorkList">SecMngSendLogWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M���o�����������O�f�[�^��Logic�폜���܂�(�O�������SqlConnection and SqlTranaction���g�p)</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private int LogicDeleteSndRcvEtrProcProc(ArrayList SndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

			# region [DEL 2011.09.02]
			//string command = string.Empty;
			//command = "SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF, SNDRCVHISCONSNORF, SNDRCVHISCONSDERIVNORF FROM SNDRCVETRRF " + Environment.NewLine;
			//command += "WHERE" + Environment.NewLine;
			//command += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
			//command += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
			//command += "  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO" + Environment.NewLine;
			// DEL 2011.09.02 -------<<<<<
			# endregion

			// ADD 2011.09.02 ------->>>>>
			StringBuilder sqlText = new StringBuilder();
			sqlText.Append("SELECT UPDATEDATETIMERF, ENTERPRISECODERF, LOGICALDELETECODERF, SECTIONCODERF, SNDRCVHISCONSNORF, SNDRCVHISCONSDERIVNORF FROM SNDRCVETRRF ").Append(Environment.NewLine);
			sqlText.Append("WHERE" ).Append(Environment.NewLine);
			sqlText.Append("      ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
			sqlText.Append("  AND SECTIONCODERF=@FINDSECTIONCODE" ).Append(Environment.NewLine);
			sqlText.Append("  AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO").Append(Environment.NewLine);
			// ADD 2011.09.02 -------<<<<<

            try
            {
                for (int i = 0; i < SndRcvHisWorkList.Count; i++)
                {
                    SndRcvHisWork sndRcvHisWork = SndRcvHisWorkList[i] as SndRcvHisWork;

					//Select�R�}���h�̐���
					// sqlCommand = new SqlCommand(command, sqlConnection, sqlTransaction); // DEL 2011.09.02
					sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction); // ADD 2011.09.02
					sqlCommand.CommandText = sqlText.ToString(); // ADD 2011.09.02

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaSndRcvHisConsNo = sqlCommand.Parameters.Add("@FINDSNDRCVHISCONSNO", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                    findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        ////����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        //DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        //if (_updateDateTime != sndRcvHisWork.UpdateDateTime)
                        //{
                        //    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        //    sqlCommand.Cancel();
                        //    if (myReader.IsClosed == false) myReader.Close();
                        //    return status;
						//}

						# region [DEL 2011.09.02]
						// DEL 2011.09.02 ------->>>>>
						//sqlCommand.CommandText = "UPDATE SNDRCVETRRF" + Environment.NewLine;
						//sqlCommand.CommandText += "SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
						//sqlCommand.CommandText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;                       
						//sqlCommand.CommandText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
						//sqlCommand.CommandText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
						//sqlCommand.CommandText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;                        
						//sqlCommand.CommandText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
						//sqlCommand.CommandText += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
						//sqlCommand.CommandText += " AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO" + Environment.NewLine;
						// DEL 2011.09.02 -------<<<<<
						# endregion

						// ADD 2011.09.02 ------->>>>>
						sqlText = new StringBuilder();
						sqlText.Append("UPDATE SNDRCVETRRF").Append(Environment.NewLine);
						sqlText.Append("SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
						sqlText.Append(" , ENTERPRISECODERF=@ENTERPRISECODE").Append(Environment.NewLine);
						sqlText.Append(" , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE").Append(Environment.NewLine);
						sqlText.Append(" , UPDASSEMBLYID1RF=@UPDASSEMBLYID1").Append(Environment.NewLine);
						sqlText.Append(" , UPDASSEMBLYID2RF=@UPDASSEMBLYID2").Append(Environment.NewLine);
						sqlText.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
						sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE").Append(Environment.NewLine);
						sqlText.Append(" AND SECTIONCODERF=@FINDSECTIONCODE").Append(Environment.NewLine);
						sqlText.Append(" AND SNDRCVHISCONSNORF=@FINDSNDRCVHISCONSNO").Append(Environment.NewLine);
						sqlCommand.CommandText = sqlText.ToString();
						// ADD 2011.09.02 -------<<<<<

                        //KEY�R�}���h���Đݒ�            
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);
                        findParaSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

                        //�X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)sndRcvHisWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);

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
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(sndRcvHisWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(sndRcvHisWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(1);
                        #endregion

                        if (myReader.IsClosed == false) myReader.Close();
                        sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
						//return status;   // DEL 2011.08.24
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                //status = base.WriteSQLErrorLog(ex);//DEL 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                base.WriteSQLErrorLog(ex);//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�----------------------------------------------------------------------------------------------->>>>>
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "LogicDeleteSndRcvEtrProcProc(ArrayList SndRcvHisWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            //ADD 2011.08.24 ���W�J�ꗗNO.10 �G���[���O��ǉ�------------------------------------------------------------------------------------------------<<<<<
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

        #region [Private���\�b�h�쐬]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
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
        /// <param name="sndRcvHisCondWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SndRcvHisCondWork sndRcvHisCondWork)
		{
			# region [DEL 2011.09.02]
			//string retstring = "WHERE ";

			////�_���폜�敪
			//retstring += " LOGICALDELETECODERF = @FINDLOGICALDELETECODE " + Environment.NewLine;
			//SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.NChar);
			//paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

			////�p�����[�^.��ƃR�[�h��Empty�ł͂Ȃ��ꍇ
			//if (sndRcvHisCondWork != null && !sndRcvHisCondWork.EnterpriseCode.Trim().Equals(""))
			//{
			//    //���M�拒�_�R�[�h
			//    retstring += "AND SENDDESTSECCODERF = @SECTIONCODE" + Environment.NewLine;
			//    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
			//    paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisCondWork.SectionCode);

			//    //����M�敪
			//    retstring += "AND SENDORRECEIVEDIVCDRF = @SENDORRECEIVEDIVCD" + Environment.NewLine;
			//    SqlParameter paraSendOrReceiveDivCd = sqlCommand.Parameters.Add("@SENDORRECEIVEDIVCD", SqlDbType.Int);
			//    paraSendOrReceiveDivCd.Value = SqlDataMediator.SqlSetInt32(sndRcvHisCondWork.SendOrReceiveDivCd);
			//    //���
			//    retstring += "AND KINDRF = @KIND " + Environment.NewLine;
			//    SqlParameter paraKind = sqlCommand.Parameters.Add("@KIND", SqlDbType.Int);
			//    paraKind.Value = SqlDataMediator.SqlSetInt32(sndRcvHisCondWork.Kind);

			//    //��ƃR�[�h
			//    retstring += "AND SENDDESTEPCODERF = @ENTERPRISECODE " + Environment.NewLine;
			//    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
			//    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisCondWork.EnterpriseCode);
			//}

			////���������p�����[�^�ɎQ�Ɗ�ƃR�[�h�w��̎�
			//if (sndRcvHisCondWork != null && !sndRcvHisCondWork.ParaEnterpriseCode.Trim().Equals(""))
			//{
			//    //���M���ƃR�[�h
			//    retstring += "AND (SENDDESTEPCODERF = @PARAENTERPRISECODE OR ENTERPRISECODERF = @PARAENTERPRISECODE )" + Environment.NewLine;
			//    SqlParameter paraParaEnterpriseCode = sqlCommand.Parameters.Add("@PARAENTERPRISECODE", SqlDbType.NChar);
			//    paraParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisCondWork.ParaEnterpriseCode);
			//}

			////�p�����[�^.���M��(�J�n)>0�̏ꍇ������ǉ�
			//if (sndRcvHisCondWork != null && sndRcvHisCondWork.SendDateTimeStart > 0)
			//{
			//    //���M��>=���������p�����[�^�Ŏw�肳�ꂽ���M��(�J�n)
			//    retstring += "AND SENDDATETIMERF >= @SENDDATETIMESTART" + Environment.NewLine;
			//    SqlParameter paraSendDateTimeStart = sqlCommand.Parameters.Add("@SENDDATETIMESTART", SqlDbType.BigInt);
			//    paraSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(sndRcvHisCondWork.SendDateTimeStart);
			//}

			////�p�����[�^.���M��(�I��)>0�̏ꍇ������ǉ�
			//if (sndRcvHisCondWork != null && sndRcvHisCondWork.SendDateTimeEnd > 0)
			//{
			//    //���M��<=���������p�����[�^�Ŏw�肳�ꂽ���M��(�I��)
			//    retstring += "AND SENDDATETIMERF <= @SENDDATETIMEEND" + Environment.NewLine;
			//    SqlParameter paraSendDateTimeEnd = sqlCommand.Parameters.Add("@SENDDATETIMEEND", SqlDbType.BigInt);
			//    paraSendDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(sndRcvHisCondWork.SendDateTimeEnd);
			//}

			//retstring += " ORDER BY SENDDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, SNDRCVHISCONSNORF " + Environment.NewLine;

			//return retstring;
			# endregion

			// ADD 2011.09.02------->>>>>
			StringBuilder sb = new StringBuilder();
			sb.Append(" WHERE ");

			//�_���폜�敪
			sb.Append( " LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
			SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.NChar);
			paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

			//�p�����[�^.��ƃR�[�h��Empty�ł͂Ȃ��ꍇ
			if (sndRcvHisCondWork != null && !sndRcvHisCondWork.EnterpriseCode.Trim().Equals(""))
			{
				//���M�拒�_�R�[�h
				sb.Append( "AND SENDDESTSECCODERF = @SECTIONCODE").Append(Environment.NewLine);
				SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
				paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisCondWork.SectionCode);

				//����M�敪
				sb.Append( "AND SENDORRECEIVEDIVCDRF = @SENDORRECEIVEDIVCD").Append(Environment.NewLine);
				SqlParameter paraSendOrReceiveDivCd = sqlCommand.Parameters.Add("@SENDORRECEIVEDIVCD", SqlDbType.Int);
				paraSendOrReceiveDivCd.Value = SqlDataMediator.SqlSetInt32(sndRcvHisCondWork.SendOrReceiveDivCd);
				//���
				sb.Append( "AND KINDRF = @KIND ").Append(Environment.NewLine);
				SqlParameter paraKind = sqlCommand.Parameters.Add("@KIND", SqlDbType.Int);
				paraKind.Value = SqlDataMediator.SqlSetInt32(sndRcvHisCondWork.Kind);

				//��ƃR�[�h
				sb.Append( "AND SENDDESTEPCODERF = @ENTERPRISECODE ").Append(Environment.NewLine);
				SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisCondWork.EnterpriseCode);
			}

			//���������p�����[�^�ɎQ�Ɗ�ƃR�[�h�w��̎�
			if (sndRcvHisCondWork != null && !sndRcvHisCondWork.ParaEnterpriseCode.Trim().Equals(""))
			{
				//���M���ƃR�[�h
				sb.Append( "AND (SENDDESTEPCODERF = @PARAENTERPRISECODE OR ENTERPRISECODERF = @PARAENTERPRISECODE )").Append(Environment.NewLine);
				SqlParameter paraParaEnterpriseCode = sqlCommand.Parameters.Add("@PARAENTERPRISECODE", SqlDbType.NChar);
				paraParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisCondWork.ParaEnterpriseCode);

				// DEL 2011.09.14 --------->>>>>
				//// ADD 2011.09.05 --------->>>>>
				////����M�敪
				//sb.Append("AND SENDORRECEIVEDIVCDRF = @SENDORRECEIVEDIVCD").Append(Environment.NewLine);
				//SqlParameter paraSendOrReceiveDivCd = sqlCommand.Parameters.Add("@SENDORRECEIVEDIVCD", SqlDbType.Int);
				//paraSendOrReceiveDivCd.Value = SqlDataMediator.SqlSetInt32(sndRcvHisCondWork.SendOrReceiveDivCd);
				//// ADD 2011.09.05 ---------<<<<<
				// DEL 2011.09.14 ---------<<<<<

			}

			// ADD 2011.09.14 --------->>>>>
			if (sndRcvHisCondWork != null && !sndRcvHisCondWork.ParaSectionCode.Trim().Equals("00") && !sndRcvHisCondWork.ParaSectionCode.Trim().Equals(""))
			{
				//
				if (sndRcvHisCondWork.ParaSendOrReceiveDivCd == 0)
				{
					//���M�����_�R�[�h
					sb.Append("AND SECTIONCODERF = @SECTIONCODE2").Append(Environment.NewLine);
					SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE2", SqlDbType.NChar);
					paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisCondWork.ParaSectionCode);
				}
				else if (sndRcvHisCondWork.ParaSendOrReceiveDivCd == 1)
				{
					//���M�拒�_�R�[�h
					sb.Append("AND SENDDESTSECCODERF = @SENDDESTSECCODE").Append(Environment.NewLine);
					SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SENDDESTSECCODE", SqlDbType.NChar);
					paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisCondWork.ParaSectionCode);
				}
			}
		    // ADD 2011.09.14 ---------<<<<<

			//�p�����[�^.���M��(�J�n)>0�̏ꍇ������ǉ�
			if (sndRcvHisCondWork != null && sndRcvHisCondWork.SendDateTimeStart > 0)
			{
				//���M��>=���������p�����[�^�Ŏw�肳�ꂽ���M��(�J�n)
				sb.Append( "AND SENDDATETIMERF >= @SENDDATETIMESTART").Append(Environment.NewLine);
				SqlParameter paraSendDateTimeStart = sqlCommand.Parameters.Add("@SENDDATETIMESTART", SqlDbType.BigInt);
				paraSendDateTimeStart.Value = SqlDataMediator.SqlSetInt64(sndRcvHisCondWork.SendDateTimeStart);
			}

			//�p�����[�^.���M��(�I��)>0�̏ꍇ������ǉ�
			if (sndRcvHisCondWork != null && sndRcvHisCondWork.SendDateTimeEnd > 0)
			{
				//���M��<=���������p�����[�^�Ŏw�肳�ꂽ���M��(�I��)
				sb.Append( "AND SENDDATETIMERF <= @SENDDATETIMEEND" ).Append(Environment.NewLine);
				SqlParameter paraSendDateTimeEnd = sqlCommand.Parameters.Add("@SENDDATETIMEEND", SqlDbType.BigInt);
				paraSendDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(sndRcvHisCondWork.SendDateTimeEnd);
			}

			sb.Append(" ORDER BY SENDDATETIMERF, ENTERPRISECODERF, SECTIONCODERF, SNDRCVHISCONSNORF ").Append(Environment.NewLine);

			return sb.ToString();
			// ADD 2011.09.02-------<<<<<
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="sndRcvHisWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        private string MakeWhereStringSub(ref SqlCommand sqlCommand, SndRcvHisWork sndRcvHisWork)
        {
            # region [DEL 2011.09.02]
			//string retstring = "WHERE ";

			////���_�R�[�h
			//retstring += "SECTIONCODERF = @SECTIONCODE" + Environment.NewLine;
			//SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
			//paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);

			////����M�������O���M�ԍ�
			//retstring += "AND SNDRCVHISCONSNORF = @SNDRCVHISCONSNO" + Environment.NewLine;
			//SqlParameter parSndRcvHisConsNo = sqlCommand.Parameters.Add("@SNDRCVHISCONSNO", SqlDbType.Int);
			//parSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

			////��ƃR�[�h
			//retstring += "AND ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
			//SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
			//paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);

			////�_���폜�敪
			//retstring += "AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
			//SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			//paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);            

			//return retstring;
			# endregion

			// ADD 2011.09.02------->>>>>
			StringBuilder sb = new StringBuilder();
			sb.Append(" WHERE ");

			//���_�R�[�h
			sb.Append( "SECTIONCODERF = @SECTIONCODE").Append(Environment.NewLine);
			SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
			paraSectionCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.SectionCode);

			//����M�������O���M�ԍ�
			sb.Append( "AND SNDRCVHISCONSNORF = @SNDRCVHISCONSNO").Append(Environment.NewLine);
			SqlParameter parSndRcvHisConsNo = sqlCommand.Parameters.Add("@SNDRCVHISCONSNO", SqlDbType.Int);
			parSndRcvHisConsNo.Value = SqlDataMediator.SqlSetInt32(sndRcvHisWork.SndRcvHisConsNo);

			//��ƃR�[�h
			sb.Append( "AND ENTERPRISECODERF = @ENTERPRISECODE").Append(Environment.NewLine);
			SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
			paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(sndRcvHisWork.EnterpriseCode);

			//�_���폜�敪
			sb.Append("AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE").Append(Environment.NewLine);
			SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

			return sb.ToString();
			// ADD 2011.09.02-------<<<<<
		}
		
		#region [DEL 2011.09.02]
		/*
		/// <summary>
        /// �N���X�i�[���� Reader �� SndRcvHisWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecMngSendLogWork</returns>
        /// <remarks>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        /// </remarks>
        private SndRcvHisWork CopyToSndRcvHisWorkFromReader(ref SqlDataReader myReader)
        {
            SndRcvHisWork wkLogWork = new SndRcvHisWork();

            #region �N���X�֊i�[
            wkLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkLogWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkLogWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkLogWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkLogWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkLogWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkLogWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkLogWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkLogWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkLogWork.SndRcvHisConsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVHISCONSNORF"));
            wkLogWork.SendDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SENDDATETIMERF"));
            wkLogWork.SndLogUseDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDLOGUSEDIVRF"));
            wkLogWork.SendOrReceiveDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SENDORRECEIVEDIVCDRF"));
            wkLogWork.Kind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("KINDRF"));
            wkLogWork.SndLogExtraCondDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDLOGEXTRACONDDIVRF"));
            wkLogWork.ExtraObjSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EXTRAOBJSECCODERF"));
            wkLogWork.SndObjStartDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SNDOBJSTARTDATERF"));
            wkLogWork.SndObjEndDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("SNDOBJENDDATERF"));
            wkLogWork.SendDestEpCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTEPCODERF"));
            wkLogWork.SendDestSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SENDDESTSECCODERF"));

            #endregion

            return wkLogWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SndRcvEtrWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SecMngSendLogWork</returns>
        /// <remarks>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        /// </remarks>
        private SndRcvEtrWork CopyToSndRcvEtrWorkFromReader(ref SqlDataReader myReader)
        {
            SndRcvEtrWork wkLogWork = new SndRcvEtrWork();

            #region �N���X�֊i�[
            wkLogWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkLogWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkLogWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkLogWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkLogWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkLogWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkLogWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkLogWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkLogWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkLogWork.SndRcvHisConsNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVHISCONSNORF"));
            wkLogWork.SndRcvHisConsDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SNDRCVHISCONSDERIVNORF"));
            wkLogWork.Kind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("KINDRF"));
            wkLogWork.FileId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FILEIDRF"));
            wkLogWork.ExtraStartDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("EXTRASTARTDATERF"));
            wkLogWork.ExtraEndDate = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("EXTRAENDDATERF"));
            wkLogWork.StartCond1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STARTCOND1RF"));
            wkLogWork.EndCond1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENDCOND1RF"));
            wkLogWork.StartCond2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STARTCOND2RF"));
            wkLogWork.EndCond2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENDCOND2RF"));
            wkLogWork.StartCond3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STARTCOND3RF"));
            wkLogWork.EndCond3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENDCOND3RF"));
            wkLogWork.StartCond4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STARTCOND4RF"));
            wkLogWork.EndCond4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENDCOND4RF"));
            wkLogWork.StartCond5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STARTCOND5RF"));
            wkLogWork.EndCond5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENDCOND5RF"));
            wkLogWork.StartCond6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STARTCOND6RF"));
            wkLogWork.EndCond6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENDCOND6RF"));
            wkLogWork.StartCond7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STARTCOND7RF"));
            wkLogWork.EndCond7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENDCOND7RF"));
            wkLogWork.StartCond8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STARTCOND8RF"));
            wkLogWork.EndCond8 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENDCOND8RF"));
            wkLogWork.StartCond9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STARTCOND9RF"));
            wkLogWork.EndCond9 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENDCOND9RF"));
            wkLogWork.StartCond10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STARTCOND10RF"));
            wkLogWork.EndCond10 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENDCOND10RF"));
            #endregion

            return wkLogWork;
        }
		*/
		#endregion
        #endregion

    }
}
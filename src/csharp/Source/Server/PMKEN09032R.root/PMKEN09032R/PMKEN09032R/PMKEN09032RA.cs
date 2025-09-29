//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �D�ǐݒ�}�X�^�i���[�U�[�o�^���jDB�����[�g�I�u�W�F�N�g
//                  :   PMKEN09032R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.11
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30757 ���X�؁@�M�p 							
// �C �� ��  2015/02/24  �C�����e : SCM������ �b������ʑΉ�
//                                  �@�ǉ����ڂ̎擾�ƍX�V
//                                    �E�D�ǐݒ�ڍז��̂Q(�H�����)
//                                    �E�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11770032-00 �쐬�S�� : 30809 ���X�� �j
// �C �� ��  2021/03/25  �C�����e : �R�`���i��Q�Ή��i��s�z�M�j
//                                  �@�I�u�W�F�N�g�Q�ƃG���[�Ή�
//                                    �E���׌y���̂���READUNCOMMITTED�ǉ�
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: ���i�Ǘ����}�X�^�̍폜�����ǉ�</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.31</br>
    /// <br></br>
    /// <br>Update Note: ���i�Ǘ����}�X�^�Ńp�^���u���_+�����ށ{���[�J�[�{BL�R�[�h�v�̒ǉ��ɔ����폜�����̉��C</br>
    /// <br>Programmer : ���� redmine#32367</br>
    /// <br>Date       : 2012/11/23</br>
    /// <br></br>
    /// <br>Update Note: 11070266-00�@SCM������ �b������ʑΉ� </br>
    /// <br>Programmer : 30757 ���X�� �M�p</br>
    /// <br>Date       : 2015/02/24</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class PrmSettingUDB : RemoteWithAppLockDB, IPrmSettingUDB, IGetSyncdataList
    {
        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        public PrmSettingUDB() : base("PMKEN09034D", "Broadleaf.Application.Remoting.ParamData.PrmSettingUWork", "PrmSettingURF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P��̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����擾���܂��B
        /// </summary>
        /// <param name="prmSettingUObj">PrmSettingUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃L�[�l����v����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref object prmSettingUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PrmSettingUWork prmSettingUWork = prmSettingUObj as PrmSettingUWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref prmSettingUWork, readMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// �P��̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����擾���܂��B
        /// </summary>
        /// <param name="prmSettingUWork">PrmSettingUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃L�[�l����v����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref PrmSettingUWork prmSettingUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref prmSettingUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P��̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����擾���܂��B
        /// </summary>
        /// <param name="prmSettingUWork">PrmSettingUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃L�[�l����v����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00�@SCM������ �b������ʑΉ� </br>
        /// <br>             �擾���ڒǉ��i�D�ǐݒ�ڍז��̂Q(�H�����)�A�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�j</br>
        /// <br>Programmer : 30757 ���X�� �M�p</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(ref PrmSettingUWork prmSettingUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<
                sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine; 
                sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);                

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToPrmSettingUWorkFromReader(ref myReader, ref prmSettingUWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�
        /// </summary>
        /// <param name="prmSettingUList">�����폜����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����܂� CustomSerializeArrayList</param>
        /// <param name="goodsMngList">���i�Ǘ���� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃L�[�l����v����D�ǐݒ�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        //public int Delete(object prmSettingUList) // DEL 2008.10.31
        public int Delete(object prmSettingUList, object goodsMngList) // ADD 2008.10.31
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = prmSettingUList as ArrayList;
                ArrayList paraGoodsMngList = goodsMngList as ArrayList; // ADD 2008.10.31

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);

                // ADD 2008.10.31 >>>
                // ���i�Ǘ����폜
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    GoodsMngDB goodsMngDB = new GoodsMngDB();
                    ArrayList wkGoodsMngList = new ArrayList();
                    // �D�ǐݒ�}�X�^�̃p�����[�^List���Ɋ�ƁE���_�EBLCD�E�����ށE���[�J�[������̃��R�[�h���A
                    // �n�����\�������邽�߁A�\���敪:0�ȊO��D��I�ɐ�������B(�������Ȃ���΁A���i�Ǘ����}�X�^�̓o�^�X�V�ŃG���[������)
                    ArrayList workparaList = new ArrayList();
                    Boolean WriteFlg = false;
                    for (int k = 0; k < paraList.Count; k++)
                    {
                        if (workparaList.Count == 0)
                        {
                            workparaList.Add(paraList[k]);
                        }
                        else
                        {
                            WriteFlg = true;
                            for (int l = 0; l < workparaList.Count; l++)
                            {
                                if ((((PrmSettingUWork)paraList[k]).EnterpriseCode.Trim() == ((PrmSettingUWork)workparaList[l]).EnterpriseCode.Trim()) &&
                                    (((PrmSettingUWork)paraList[k]).SectionCode.Trim() == ((PrmSettingUWork)workparaList[l]).SectionCode.Trim()) &&
                                    (((PrmSettingUWork)paraList[k]).TbsPartsCode == ((PrmSettingUWork)workparaList[l]).TbsPartsCode) &&
                                    (((PrmSettingUWork)paraList[k]).GoodsMGroup == ((PrmSettingUWork)workparaList[l]).GoodsMGroup) &&
                                    (((PrmSettingUWork)paraList[k]).PartsMakerCd == ((PrmSettingUWork)workparaList[l]).PartsMakerCd))
                                {
                                    WriteFlg = false;
                                }
                            }
                            if (WriteFlg == true)
                            {
                                workparaList.Add(paraList[k]);
                            }
                        }
                    }

                    for (int i = 0; i < workparaList.Count; i++)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            wkGoodsMngList.Clear();
                            for (int j = 0; j < paraGoodsMngList.Count; j++)
                            {
                                if ((((PrmSettingUWork)workparaList[i]).EnterpriseCode.Trim() == ((GoodsMngWork)paraGoodsMngList[j]).EnterpriseCode.Trim()) &&
                                     (((PrmSettingUWork)workparaList[i]).SectionCode.Trim() == ((GoodsMngWork)paraGoodsMngList[j]).SectionCode.Trim()) &&
                                     (((PrmSettingUWork)workparaList[i]).TbsPartsCode == ((GoodsMngWork)paraGoodsMngList[j]).BLGoodsCode) &&
                                     (((PrmSettingUWork)workparaList[i]).GoodsMGroup == ((GoodsMngWork)paraGoodsMngList[j]).GoodsMGroup) &&
                                     (((PrmSettingUWork)workparaList[i]).PartsMakerCd == ((GoodsMngWork)paraGoodsMngList[j]).GoodsMakerCd))
                                {
                                    wkGoodsMngList.Add(paraGoodsMngList[j]);
                                    break;
                                }
                            }
                            if (wkGoodsMngList.Count > 0)
                            {
                                status = goodsMngDB.DeleteGoodsMngProc(wkGoodsMngList, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                    }

                }
                // ADD 2008.10.31 <<<

            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�
        /// </summary>
        /// <param name="prmSettingUList">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int Delete(ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(prmSettingUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�
        /// </summary>
        /// <param name="prmSettingUList">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        private int DeleteProc(ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine; 
                        sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int); 

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != prmSettingUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine; 
                            sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                            findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                            findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);
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
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="prmSettingUList">��������</param>
        /// <param name="prmSettingUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃L�[�l����v����A�S�Ă̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref object prmSettingUList, object prmSettingUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList prmSettingUArray = prmSettingUList as ArrayList;

                if (prmSettingUArray == null)
                {
                    prmSettingUArray = new ArrayList();
                }

                PrmSettingUWork prmSettingUWork = prmSettingUObj as PrmSettingUWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref prmSettingUArray, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="prmSettingUList">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����i�[���� ArrayList</param>
        /// <param name="prmSettingUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃L�[�l����v����A�S�Ă̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref ArrayList prmSettingUList, PrmSettingUWork prmSettingUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref prmSettingUList, prmSettingUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="prmSettingUList">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����i�[���� ArrayList</param>
        /// <param name="prmSettingUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃L�[�l����v����A�S�Ă̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00�@SCM������ �b������ʑΉ� </br>
        /// <br>             �擾���ڒǉ��i�D�ǐݒ�ڍז��̂Q(�H�����)�A�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�j</br>
        /// <br>Programmer : 30757 ���X�� �M�p</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br>Update Note: 11770032-00 �R�`���i��Q�Ή��i��s�Ή��j �I�u�W�F�N�g�Q�ƃG���[�Ή��i���׌y���̂���READUNCOMMITTED�ǉ��j</br>
        /// <br>Programmer : 30809 ���X�� �j</br>
        /// <br>Date       : 2021/03/25</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(ref ArrayList prmSettingUList, PrmSettingUWork prmSettingUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<
                //---UPD�@30809 ���X�؁@�j�@2021/03/25 11770032-00�@�I�u�W�F�N�g�Q�ƃG���[�Ή� ------>>>>>
                //sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                sqlText += " FROM PRMSETTINGURF  WITH(READUNCOMMITTED) " + Environment.NewLine;
                //---UPD�@30809 ���X�؁@�j�@2021/03/25 11770032-00�@�I�u�W�F�N�g�Q�ƃG���[�Ή� ------<<<<<
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, prmSettingUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    prmSettingUList.Add(this.CopyToPrmSettingUWorkFromReader(ref myReader));
                }

                if (prmSettingUList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

        # region [Write]
        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="prmSettingUList">�ǉ��E�X�V����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����܂� ArrayList</param>
        /// <param name="goodsMngList">�X�V���鏤�i�Ǘ������܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B</br>
        /// <br>Note       : GoodsMngList �Ɋi�[����Ă��鏤�i�Ǘ������X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref object prmSettingUList, ref object goodsMngList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = prmSettingUList as ArrayList;
                ArrayList paraGoodsMngList = goodsMngList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);

                // ADD 2008.11.17 �폜 >>>
                // ���i�Ǘ����X�V
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    GoodsMngDB goodsMngDB = new GoodsMngDB();
                //    status = goodsMngDB.WriteGoodsMngProc(ref paraGoodsMngList, ref sqlConnection, ref sqlTransaction);
                //}
                ArrayList wkGoodsMngList = new ArrayList();
                GoodsMngDB goodsMngDB = new GoodsMngDB();

                // �D�ǐݒ�}�X�^�̃p�����[�^List���Ɋ�ƁE���_�EBLCD�E�����ށE���[�J�[������̃��R�[�h���A
                // �n�����\�������邽�߁A�\���敪:0�ȊO��D��I�ɐ�������B(�������Ȃ���΁A���i�Ǘ����}�X�^�̓o�^�X�V�ŃG���[������)
                ArrayList workparaList = new ArrayList();
                Boolean WriteFlg = false;
                for (int k = 0; k < paraList.Count; k++)
                {
                    if (workparaList.Count==0)
                    {
                        workparaList.Add(paraList[k]);
                    }
                    else
                    {
                        WriteFlg = true;
                        for(int l=0; l<workparaList.Count; l++)
                        {
                            if ((((PrmSettingUWork)paraList[k]).EnterpriseCode.Trim() == ((PrmSettingUWork)workparaList[l]).EnterpriseCode.Trim()) &&
                                (((PrmSettingUWork)paraList[k]).SectionCode.Trim() == ((PrmSettingUWork)workparaList[l]).SectionCode.Trim()) &&
                                (((PrmSettingUWork)paraList[k]).TbsPartsCode == ((PrmSettingUWork)workparaList[l]).TbsPartsCode) &&
                                (((PrmSettingUWork)paraList[k]).GoodsMGroup == ((PrmSettingUWork)workparaList[l]).GoodsMGroup) &&
                                (((PrmSettingUWork)paraList[k]).PartsMakerCd == ((PrmSettingUWork)workparaList[l]).PartsMakerCd))
                            {
                                ((PrmSettingUWork)workparaList[l]).PrimeDisplayCode += ((PrmSettingUWork)paraList[k]).PrimeDisplayCode;
                                WriteFlg = false;
                            }
                        }
                        if (WriteFlg == true)
                        {
                            workparaList.Add(paraList[k]);
                        }
                    }
                }

                for (int i = 0; i < workparaList.Count; i++)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        wkGoodsMngList.Clear();
                        for (int j = 0; j < paraGoodsMngList.Count; j++)
                        {
                            if ((((PrmSettingUWork)workparaList[i]).EnterpriseCode.Trim() == ((GoodsMngWork)paraGoodsMngList[j]).EnterpriseCode.Trim()) &&
                                 (((PrmSettingUWork)workparaList[i]).SectionCode.Trim() == ((GoodsMngWork)paraGoodsMngList[j]).SectionCode.Trim()) &&
                                 (((PrmSettingUWork)workparaList[i]).TbsPartsCode == ((GoodsMngWork)paraGoodsMngList[j]).BLGoodsCode) &&
                                 (((PrmSettingUWork)workparaList[i]).GoodsMGroup == ((GoodsMngWork)paraGoodsMngList[j]).GoodsMGroup) &&
                                 (((PrmSettingUWork)workparaList[i]).PartsMakerCd == ((GoodsMngWork)paraGoodsMngList[j]).GoodsMakerCd))
                            {
                                wkGoodsMngList.Add(paraGoodsMngList[j]);
                                break;
                            }
                        }


                        if (wkGoodsMngList.Count > 0)
                        {
                            if (((PrmSettingUWork)workparaList[i]).PrimeDisplayCode == 0)�@// 0:����,1:���i�ƌ���,2:���i
                            {
                                // �\���Ȃ��̏ꍇ
                                status = goodsMngDB.DeleteGoodsMngProc(wkGoodsMngList, ref sqlConnection, ref sqlTransaction);
                            }
                            else
                            {
                                // �\���Ȃ��ȊO�̏ꍇ
                                status = goodsMngDB.WriteGoodsMngProc(ref wkGoodsMngList, ref sqlConnection, ref sqlTransaction);
                            }
                        }
                    }
                }


                // ADD 2008.11.17 <<<

            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="prmSettingUList">�ǉ��E�X�V����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUList �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref prmSettingUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="prmSettingUList">�ǉ��E�X�V����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : PrmSettingUList �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00�@SCM������ �b������ʑΉ� </br>
        /// <br>             �ݒ荀�ڒǉ��i�D�ǐݒ�ڍז��̂Q(�H�����)�A�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�j</br>
        /// <br>Programmer : 30757 ���X�� �M�p</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private int WriteProc(ref ArrayList prmSettingUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int); 

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != prmSettingUWork.UpdateDateTime)
                            {
                                if (prmSettingUWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE PRMSETTINGURF SET UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , GOODSMGROUPRF=@GOODSMGROUP" + Environment.NewLine;
                            sqlText += " , TBSPARTSCODERF=@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += " , TBSPARTSCDDERIVEDNORF=@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += " , MAKERDISPORDERRF=@MAKERDISPORDER" + Environment.NewLine;
                            sqlText += " , PARTSMAKERCDRF=@PARTSMAKERCD" + Environment.NewLine;
                            sqlText += " , PRIMEDISPORDERRF=@PRIMEDISPORDER" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNO1RF=@PRMSETDTLNO1" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME1RF=@PRMSETDTLNAME1" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNO2RF=@PRMSETDTLNO2" + Environment.NewLine;
                            sqlText += " , PRMSETDTLNAME2RF=@PRMSETDTLNAME2" + Environment.NewLine;
                            sqlText += " , PRIMEDISPLAYCODERF=@PRIMEDISPLAYCODE" + Environment.NewLine;
                            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                            sqlText += " ,PRMSETDTLNAME2FORFACRF=@PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += " ,PRMSETDTLNAME2FORCOWRF=@PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                            findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                            findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (prmSettingUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PRMSETTINGURF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                            sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                            sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                            sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                            sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                            sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                            sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                            sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "    ,@GOODSMGROUP" + Environment.NewLine;
                            sqlText += "    ,@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    ,@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += "    ,@MAKERDISPORDER" + Environment.NewLine;
                            sqlText += "    ,@PARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    ,@PRIMEDISPORDER" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME1" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNO2" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2" + Environment.NewLine;
                            sqlText += "    ,@PRIMEDISPLAYCODE" + Environment.NewLine;
                            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                            sqlText += "    ,@PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                            sqlText += "    ,@PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                            //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
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
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);
                        SqlParameter paraMakerDispOrder = sqlCommand.Parameters.Add("@MAKERDISPORDER", SqlDbType.Int);
                        SqlParameter paraPartsMakerCd = sqlCommand.Parameters.Add("@PARTSMAKERCD", SqlDbType.Int);
                        SqlParameter paraPrimeDispOrder = sqlCommand.Parameters.Add("@PRIMEDISPORDER", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlNo1 = sqlCommand.Parameters.Add("@PRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName1 = sqlCommand.Parameters.Add("@PRMSETDTLNAME1", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlNo2 = sqlCommand.Parameters.Add("@PRMSETDTLNO2", SqlDbType.Int);
                        SqlParameter paraPrmSetDtlName2 = sqlCommand.Parameters.Add("@PRMSETDTLNAME2", SqlDbType.NVarChar);
                        SqlParameter paraPrimeDisplayCode = sqlCommand.Parameters.Add("@PRIMEDISPLAYCODE", SqlDbType.Int);
                        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                        SqlParameter paraPrmSetDtlName2ForFac = sqlCommand.Parameters.Add("@PRMSETDTLNAME2FORFACRF", SqlDbType.NVarChar);
                        SqlParameter paraPrmSetDtlName2ForCOw = sqlCommand.Parameters.Add("@PRMSETDTLNAME2FORCOWRF", SqlDbType.NVarChar);
                        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(prmSettingUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCdDerivedNo);
                        paraMakerDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.MakerDispOrder);
                        paraPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        paraPrimeDispOrder.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDispOrder);
                        paraPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        paraPrmSetDtlName1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName1);
                        paraPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);
                        paraPrmSetDtlName2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2);
                        // �C�� 2009.01.26 >>>
                        //paraPrimeDisplayCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDisplayCode);
                        if (prmSettingUWork.TbsPartsCode == 0)
                        {
                            paraPrimeDisplayCode.Value = 0;
                        }
                        else
                        {
                            paraPrimeDisplayCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDisplayCode);
                        }
                        // �C�� 2009.01.26 <<<
                        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                        paraPrmSetDtlName2ForFac.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2ForFac);
                        paraPrmSetDtlName2ForCOw.Value = SqlDataMediator.SqlSetString(prmSettingUWork.PrmSetDtlName2ForCOw);
                        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(prmSettingUWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            prmSettingUList = al;

            return status;
        }
        # endregion

        #region [GetSyncdataList]
        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������UOE���Аݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int GetSyncdataList(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            return this.GetSyncdataListProc(out arraylistdata, syncServiceWork, ref sqlConnection);
        }

        /// <summary>
        /// ���[�J���V���N�p�̃f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="arraylistdata">��������</param>
        /// <param name="syncServiceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ������UOE���Аݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00�@SCM������ �b������ʑΉ� </br>
        /// <br>             �擾���ڒǉ��i�D�ǐݒ�ڍז��̂Q(�H�����)�A�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�j</br>
        /// <br>Programmer : 30757 ���X�� �M�p</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,GOODSMGROUPRF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "    ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "    ,MAKERDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PARTSMAKERCDRF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPORDERRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME1RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNO2RF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2RF" + Environment.NewLine;
                sqlText += "    ,PRIMEDISPLAYCODERF" + Environment.NewLine;
                //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                sqlText += "    ,PRMSETDTLNAME2FORFACRF" + Environment.NewLine;
                sqlText += "    ,PRMSETDTLNAME2FORCOWRF" + Environment.NewLine;
                //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<
                sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToPrmSettingUWorkFromReader(ref myReader));

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

            arraylistdata = al;

            return status;
        }
        #endregion

        # region [LogicalDelete]
        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j����_���폜���܂��B
        /// </summary>
        /// <param name="prmSettingUList">�_���폜����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref object prmSettingUList)
        {
            return this.LogicalDelete(ref prmSettingUList, 0);
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̘_���폜���������܂��B
        /// </summary>
        /// <param name="prmSettingUList">�_���폜����������D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int RevivalLogicalDelete(ref object prmSettingUList)
        {
            return this.LogicalDelete(ref prmSettingUList, 1);
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="prmSettingUList">�_���폜�𑀍삷��D�ǐݒ�}�X�^�i���[�U�[�o�^���j���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDelete(ref object prmSettingUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = prmSettingUList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="prmSettingUList">�_���폜�𑀍삷��D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref ArrayList prmSettingUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref prmSettingUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="prmSettingUList">�_���폜�𑀍삷��D�ǐݒ�}�X�^�i���[�U�[�o�^���j�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PrmSettingUWork �Ɋi�[����Ă���D�ǐݒ�}�X�^�i���[�U�[�o�^���j���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDeleteProc(ref ArrayList prmSettingUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (prmSettingUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < prmSettingUList.Count; i++)
                    {
                        PrmSettingUWork prmSettingUWork = prmSettingUList[i] as PrmSettingUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM PRMSETTINGURF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                        sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                        sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                        SqlParameter findParaPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                        SqlParameter findParaPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);                

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                        findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                        findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                        findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                        findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != prmSettingUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  PRMSETTINGURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "    AND GOODSMGROUPRF=@FINDGOODSMGROUP" + Environment.NewLine;
                            sqlText += "    AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlText += "    AND PARTSMAKERCDRF=@FINDPARTSMAKERCD" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO1RF=@FINDPRMSETDTLNO1" + Environment.NewLine;
                            sqlText += "    AND PRMSETDTLNO2RF=@FINDPRMSETDTLNO2" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
                            findParaGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
                            findParaPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
                            findParaPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
                            findParaPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)prmSettingUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
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

                        // �_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // ���ɍ폜�ς݂̏ꍇ����
                                return status;
                            }
                            else if (logicalDelCd == 0) prmSettingUWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else prmSettingUWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                prmSettingUWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // ���S�폜�̓f�[�^�Ȃ���߂�
                                }

                                return status;
                            }
                        }

                        // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(prmSettingUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(prmSettingUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(prmSettingUWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            prmSettingUList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="prmSettingUWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br>Note       : ���i�Ǘ����}�X�^�Ńp�^���u���_+�����ށ{���[�J�[�{BL�R�[�h�v�̒ǉ��ɔ����폜�����̉��C</br>
        /// <br>Programmer : ���� redmine#32367</br>
        /// <br>Date       : 2012/11/23</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PrmSettingUWork prmSettingUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // ���_�R�[�h
            if (prmSettingUWork.SectionCode != "")
            {
                retstring += "  AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(prmSettingUWork.SectionCode);
            }

            // ���i�����ރR�[�h
            if (prmSettingUWork.GoodsMGroup != 0)
            {
                retstring += "  AND GOODSMGROUPRF = @FINDGOODSMGROUP" + Environment.NewLine;
                SqlParameter findGoodsMGroup = sqlCommand.Parameters.Add("@FINDGOODSMGROUP", SqlDbType.Int);
                findGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.GoodsMGroup);
            }

            // BL�R�[�h
            //if (prmSettingUWork.GoodsMGroup != 0) // DEL 2012/11/23 ���� for redmine#32367
            if (prmSettingUWork.TbsPartsCode != 0) // ADD 2012/11/23 ���� for redmine#32367
            {
                retstring += "  AND TBSPARTSCODERF = @FINDTBSPARTSCODE" + Environment.NewLine;
                SqlParameter findTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                findTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.TbsPartsCode);
            }
            
            // ���i���[�J�[�R�[�h
            if (prmSettingUWork.PartsMakerCd != 0)
            {
                retstring += "  AND PARTSMAKERCDRF = @FINDPARTSMAKERCD" + Environment.NewLine;
                SqlParameter findPartsMakerCd = sqlCommand.Parameters.Add("@FINDPARTSMAKERCD", SqlDbType.Int);
                findPartsMakerCd.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PartsMakerCd);
            }

            // �D�ǐݒ�ڍ׃R�[�h�P
            if (prmSettingUWork.PrmSetDtlNo1 != 0)
            {
                retstring += "  AND PRMSETDTLNO1RF = @FINDPRMSETDTLNO1" + Environment.NewLine;
                SqlParameter findPrmSetDtlNo1 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO1", SqlDbType.Int);
                findPrmSetDtlNo1.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo1);
            }

            // �D�ǐݒ�ڍ׃R�[�h�Q
            if (prmSettingUWork.PrmSetDtlNo2 != 0)
            {
                retstring += "  AND PRMSETDTLNO2RF = @FINDPRMSETDTLNO2" + Environment.NewLine;
                SqlParameter findPrmSetDtlNo2 = sqlCommand.Parameters.Add("@FINDPRMSETDTLNO2", SqlDbType.Int);
                findPrmSetDtlNo2.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrmSetDtlNo2);
            }

            // �D�Ǖ\���敪�@0��0�F���ȊO -1�ˑS�� 
            if (prmSettingUWork.PrimeDisplayCode == 0)
            {
                retstring += "  AND PRIMEDISPLAYCODERF != @FINDPRIMEDISPLAYCODERF" + Environment.NewLine;
                SqlParameter findPrimeDisplayCode = sqlCommand.Parameters.Add("@FINDPRIMEDISPLAYCODERF", SqlDbType.Int);
                findPrimeDisplayCode.Value = SqlDataMediator.SqlSetInt32(prmSettingUWork.PrimeDisplayCode);
            }

            return retstring;
        }
        # endregion

        #region [�V���N�pWhere���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="syncServiceWork">���������i�[�N���X</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.11</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� PrmSettingUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PrmSettingUWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private PrmSettingUWork CopyToPrmSettingUWorkFromReader(ref SqlDataReader myReader)
        {
            PrmSettingUWork prmSettingUWork = new PrmSettingUWork();

            this.CopyToPrmSettingUWorkFromReader(ref myReader, ref prmSettingUWork);

            return prmSettingUWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� PrmSettingUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="prmSettingUWork">PrmSettingUWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.11</br>
        /// <br></br>
        /// <br>Update Note: 11070266-00�@SCM������ �b������ʑΉ� </br>
        /// <br>             �擾���ڒǉ��i�D�ǐݒ�ڍז��̂Q(�H�����)�A�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�j</br>
        /// <br>Programmer : 30757 ���X�� �M�p</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private void CopyToPrmSettingUWorkFromReader(ref SqlDataReader myReader, ref PrmSettingUWork prmSettingUWork)
        {
            if (myReader != null && prmSettingUWork != null)
            {
                # region �N���X�֊i�[
                prmSettingUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                prmSettingUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                prmSettingUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                prmSettingUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                prmSettingUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                prmSettingUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                prmSettingUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                prmSettingUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                prmSettingUWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                prmSettingUWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                prmSettingUWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));
                prmSettingUWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));
                prmSettingUWork.MakerDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERDISPORDERRF"));
                prmSettingUWork.PartsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSMAKERCDRF"));
                prmSettingUWork.PrimeDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPORDERRF"));
                prmSettingUWork.PrmSetDtlNo1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO1RF"));
                prmSettingUWork.PrmSetDtlName1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME1RF"));
                prmSettingUWork.PrmSetDtlNo2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRMSETDTLNO2RF"));
                prmSettingUWork.PrmSetDtlName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2RF"));
                prmSettingUWork.PrimeDisplayCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRIMEDISPLAYCODERF"));
                //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                prmSettingUWork.PrmSetDtlName2ForFac = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORFACRF"));
                prmSettingUWork.PrmSetDtlName2ForCOw = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRMSETDTLNAME2FORCOWRF"));
                //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<
                # endregion
            }
        }
        # endregion

        # region [�R�l�N�V������������]
        ///// <summary>
        ///// SqlConnection��������
        ///// </summary>
        ///// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        ///// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        ///// <remarks>
        ///// <br>Programmer : 20081 �D�c �E�l</br>
        ///// <br>Date       : 2008.06.11</br>
        ///// </remarks>
        //private SqlConnection CreateSqlConnection(bool open)
        //{
        //    SqlConnection retSqlConnection = null;

        //    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

        //    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

        //    if (!string.IsNullOrEmpty(connectionText))
        //    {
        //        retSqlConnection = new SqlConnection(connectionText);

        //        if (open)
        //        {
        //            retSqlConnection.Open();
        //        }
        //    }

        //    return retSqlConnection;
        //}

        ///// <summary>
        ///// SqlTransaction��������
        ///// </summary>
        ///// <param name="sqlconnection"></param>
        ///// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        ///// <remarks>
        ///// <br>Programmer : 20081 �D�c �E�l</br>
        ///// <br>Date       : 2008.06.11</br>
        ///// </remarks>
        //private SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        //{
        //    SqlTransaction retSqlTransaction = null;

        //    if (sqlconnection != null)
        //    {
        //        // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
        //        if ((sqlconnection.State & ConnectionState.Open) == 0)
        //        {
        //            sqlconnection.Open();
        //        }

        //        // �g�����U�N�V�����̐���(�J�n)
        //        retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
        //    }

        //    return retSqlTransaction;
        //}
        # endregion
    }
}

//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE �K�C�h���̃}�X�^DB�����[�g�I�u�W�F�N�g
//                  :   PMUOE09034R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.06
//----------------------------------------------------------------------
// Update Note      :   2008/12/11 30365 �{�Ë⎟�Y UOEGuideCode�ɂ��ċ󕶎��ł̓o�^�ɑΉ�
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
    /// UOE �K�C�h���̃}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE �K�C�h���̃}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class UOEGuideNameDB : RemoteWithAppLockDB, IUOEGuideNameDB, IGetSyncdataList
    {
        /// <summary>
        /// UOE �K�C�h���̃}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        public UOEGuideNameDB() : base("PMUOE09036D", "Broadleaf.Application.Remoting.ParamData.UOEGuideNameWork", "UOEGuideNameRF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P���UOE �K�C�h���̃}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeGuideNameObj">UOEGuideNameWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE �K�C�h���̃}�X�^�̃L�[�l����v����UOE �K�C�h���̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(ref object uoeGuideNameObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                UOEGuideNameWork uoeGuideNameWork = uoeGuideNameObj as UOEGuideNameWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref uoeGuideNameWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P���UOE �K�C�h���̃}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeGuideNameWork">UOEGuideNameWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE �K�C�h���̃}�X�^�̃L�[�l����v����UOE �K�C�h���̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Read(ref UOEGuideNameWork uoeGuideNameWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref uoeGuideNameWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// �P���UOE �K�C�h���̃}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeGuideNameWork">UOEGuideNameWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE �K�C�h���̃}�X�^�̃L�[�l����v����UOE �K�C�h���̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int ReadProc(ref UOEGuideNameWork uoeGuideNameWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT UOEGUID.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDEDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDENAMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += " FROM UOEGUIDENAMERF UOEGUID" + Environment.NewLine;
                sqlText += " LEFT JOIN UOESUPPLIERRF UOESUP ON UOEGUID.ENTERPRISECODERF=UOESUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOESUPPLIERCDRF=UOESUP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += " WHERE UOEGUID.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                sqlText += "    AND UOEGUID.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUOEGuideDivCd = sqlCommand.Parameters.Add("@FINDUOEGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaUOEGuideCode = sqlCommand.Parameters.Add("@FINDUOEGUIDECODE", SqlDbType.NVarChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToUOEGuideNameWorkFromReader(ref myReader, ref uoeGuideNameWork);
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
        /// UOE �K�C�h���̃}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeGuideNameList">�����폜����UOE �K�C�h���̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE �K�C�h���̃}�X�^�̃L�[�l����v����UOE �K�C�h���̃}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Delete(object uoeGuideNameList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeGuideNameList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
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
        /// UOE �K�C�h���̃}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeGuideNameList">UOE �K�C�h���̃}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeGuideNameList �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Delete(ArrayList uoeGuideNameList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(uoeGuideNameList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE �K�C�h���̃}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeGuideNameList">UOE �K�C�h���̃}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeGuideNameList �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int DeleteProc(ArrayList uoeGuideNameList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (uoeGuideNameList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeGuideNameList.Count; i++)
                    {
                        UOEGuideNameWork uoeGuideNameWork = uoeGuideNameList[i] as UOEGuideNameWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM UOEGUIDENAMERF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOEGuideDivCd = sqlCommand.Parameters.Add("@FINDUOEGUIDEDIVCD", SqlDbType.Int);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaUOEGuideCode = sqlCommand.Parameters.Add("@FINDUOEGUIDECODE", SqlDbType.NVarChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                        findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                        //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                        findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode;
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeGuideNameWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM UOEGUIDENAMERF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                            findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                            //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                            findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode;
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);
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
        /// UOE �K�C�h���̃}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">��������</param>
        /// <param name="uoeGuideNameObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE �K�C�h���̃}�X�^�̃L�[�l����v����A�S�Ă�UOE �K�C�h���̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Search(ref object uoeGuideNameList, object uoeGuideNameObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList uoeGuideNameArray = uoeGuideNameList as ArrayList;

                if (uoeGuideNameArray == null)
                {
                    uoeGuideNameArray = new ArrayList();
                }
                
                UOEGuideNameWork uoeGuideNameWork = uoeGuideNameObj as UOEGuideNameWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref uoeGuideNameArray, uoeGuideNameWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// UOE �K�C�h���̃}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">UOE �K�C�h���̃}�X�^�����i�[���� ArrayList</param>
        /// <param name="uoeGuideNameWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE �K�C�h���̃}�X�^�̃L�[�l����v����A�S�Ă�UOE �K�C�h���̃}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Search(ref ArrayList uoeGuideNameList, UOEGuideNameWork uoeGuideNameWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref uoeGuideNameList, uoeGuideNameWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE �K�C�h���̃}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">UOE �K�C�h���̃}�X�^�����i�[���� ArrayList</param>
        /// <param name="uoeGuideNameWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE �K�C�h���̃}�X�^�̃L�[�l����v����A�S�Ă�UOE �K�C�h���̃}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int SearchProc(ref ArrayList uoeGuideNameList, UOEGuideNameWork uoeGuideNameWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT   UOEGUID.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.SECTIONCODERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UOEGUIDEDIVCDRF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UOEGUIDECODERF" + Environment.NewLine;
                sqlText += "        ,UOEGUID.UOEGUIDENAMERF" + Environment.NewLine;
                sqlText += "        ,UOESUP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += " FROM UOEGUIDENAMERF UOEGUID" + Environment.NewLine;
                sqlText += " LEFT JOIN UOESUPPLIERRF UOESUP ON UOEGUID.ENTERPRISECODERF=UOESUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOESUPPLIERCDRF=UOESUP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    AND UOEGUID.SECTIONCODERF=UOESUP.SECTIONCODERF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, uoeGuideNameWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    uoeGuideNameList.Add(this.CopyToUOEGuideNameWorkFromReader(ref myReader));
                }

                if (uoeGuideNameList.Count > 0)
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
        /// UOE �K�C�h���̃}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�ǉ��E�X�V����UOE �K�C�h���̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameList �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Write(ref object uoeGuideNameList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeGuideNameList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
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
        /// UOE �K�C�h���̃}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�ǉ��E�X�V����UOE �K�C�h���̃}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeGuideNameList �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int Write(ref ArrayList uoeGuideNameList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref uoeGuideNameList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE �K�C�h���̃}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�ǉ��E�X�V����UOE �K�C�h���̃}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeGuideNameList �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int WriteProc(ref ArrayList uoeGuideNameList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeGuideNameList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeGuideNameList.Count; i++)
                    {
                        UOEGuideNameWork uoeGuideNameWork = uoeGuideNameList[i] as UOEGuideNameWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM UOEGUIDENAMERF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOEGuideDivCd = sqlCommand.Parameters.Add("@FINDUOEGUIDEDIVCD", SqlDbType.Int);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaUOEGuideCode = sqlCommand.Parameters.Add("@FINDUOEGUIDECODE", SqlDbType.NVarChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                        findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                        //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode); // 2008/12/11 G.Miyatsu DEL
                        findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode; // 2008/12/11 G.Miyatsu ADD
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeGuideNameWork.UpdateDateTime)
                            {
                                if (uoeGuideNameWork.UpdateDateTime == DateTime.MinValue)
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
              
                            sqlText += "UPDATE UOEGUIDENAMERF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , UOEGUIDEDIVCDRF=@UOEGUIDEDIVCD" + Environment.NewLine;
                            sqlText += " , UOESUPPLIERCDRF=@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += " , UOEGUIDECODERF=@UOEGUIDECODE" + Environment.NewLine;
                            sqlText += " , UOEGUIDENAMERF=@UOEGUIDENAME" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                            findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                            //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                            findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode;
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeGuideNameWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (uoeGuideNameWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO UOEGUIDENAMERF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,UOEGUIDEDIVCDRF" + Environment.NewLine;
                            sqlText += "    ,UOESUPPLIERCDRF" + Environment.NewLine;
                            sqlText += "    ,UOEGUIDECODERF" + Environment.NewLine;
                            sqlText += "    ,UOEGUIDENAMERF" + Environment.NewLine;
                            sqlText += "    ,SECTIONCODERF" + Environment.NewLine;
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
                            sqlText += "    ,@UOEGUIDEDIVCD" + Environment.NewLine;
                            sqlText += "    ,@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    ,@UOEGUIDECODE" + Environment.NewLine;
                            sqlText += "    ,@UOEGUIDENAME" + Environment.NewLine;
                            sqlText += "    ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeGuideNameWork;
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
                        SqlParameter paraUOEGuideDivCd = sqlCommand.Parameters.Add("@UOEGUIDEDIVCD", SqlDbType.Int);
                        SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraUOEGuideCode = sqlCommand.Parameters.Add("@UOEGUIDECODE", SqlDbType.NVarChar);
                        SqlParameter paraUOEGuideName = sqlCommand.Parameters.Add("@UOEGUIDENAME", SqlDbType.NVarChar);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeGuideNameWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeGuideNameWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(uoeGuideNameWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.LogicalDeleteCode);
                        paraUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                        paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                        //paraUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode); // 2008/12/11 G.Miyatsu DEL
                        paraUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode; // 2008/12/11 G.Miyatsu ADD
                        paraUOEGuideName.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideName);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeGuideNameWork);
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

            uoeGuideNameList = al;

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
        /// <br>Note       : �w�肳�ꂽ������UOE�K�C�h���̃}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
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
        /// <br>Note       : �w�肳�ꂽ������UOE�K�C�h���̃}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20081  �D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int GetSyncdataListProc(out ArrayList arraylistdata, SyncServiceWork syncServiceWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string sqlText = string.Empty;
                sqlText += "SELECT UOEGUID.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDEDIVCDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDECODERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.UOEGUIDENAMERF" + Environment.NewLine;
                sqlText += "    ,UOEGUID.SECTIONCODERF" + Environment.NewLine;
                sqlText += "    ,UOESUP.UOESUPPLIERNAMERF" + Environment.NewLine;
                sqlText += " FROM UOEGUIDENAMERF UOEGUID" + Environment.NewLine;
                sqlText += " LEFT JOIN UOESUPPLIERRF UOESUP ON UOEGUID.ENTERPRISECODERF=UOESUP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND UOEGUID.UOESUPPLIERCDRF=UOESUP.UOESUPPLIERCDRF" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeSyncWhereString(ref sqlCommand, syncServiceWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToUOEGuideNameWorkFromReader(ref myReader));

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
        /// UOE �K�C�h���̃}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�_���폜����UOE �K�C�h���̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int LogicalDelete(ref object uoeGuideNameList)
        {
            return this.LogicalDelete(ref uoeGuideNameList, 0);
        }

        /// <summary>
        /// UOE �K�C�h���̃}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�_���폜����������UOE �K�C�h���̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int RevivalLogicalDelete(ref object uoeGuideNameList)
        {
            return this.LogicalDelete(ref uoeGuideNameList, 1);
        }

        /// <summary>
        /// UOE �K�C�h���̃}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�_���폜�𑀍삷��UOE �K�C�h���̃}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int LogicalDelete(ref object uoeGuideNameList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeGuideNameList as ArrayList;

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
        /// UOE �K�C�h���̃}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�_���폜�𑀍삷��UOE �K�C�h���̃}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        public int LogicalDelete(ref ArrayList uoeGuideNameList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref uoeGuideNameList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// UOE �K�C�h���̃}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeGuideNameList">�_���폜�𑀍삷��UOE �K�C�h���̃}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOEGuideNameWork �Ɋi�[����Ă���UOE �K�C�h���̃}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private int LogicalDeleteProc(ref ArrayList uoeGuideNameList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeGuideNameList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeGuideNameList.Count; i++)
                    {
                        UOEGuideNameWork uoeGuideNameWork = uoeGuideNameList[i] as UOEGuideNameWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM UOEGUIDENAMERF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                        sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                        sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                        sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOEGuideDivCd = sqlCommand.Parameters.Add("@FINDUOEGUIDEDIVCD", SqlDbType.Int);
                        SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter findParaUOEGuideCode = sqlCommand.Parameters.Add("@FINDUOEGUIDECODE", SqlDbType.NVarChar);
                        SqlParameter findParaSectioncode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                        findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                        findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                        //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                        findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode;
                        findParaSectioncode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeGuideNameWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                             sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  UOEGUIDENAMERF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDEDIVCDRF=@FINDUOEGUIDEDIVCD" + Environment.NewLine;
                            sqlText += "    AND UOESUPPLIERCDRF=@FINDUOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "    AND UOEGUIDECODERF=@FINDUOEGUIDECODE" + Environment.NewLine;
                            sqlText += "    AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);
                            findParaUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
                            findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
                            //findParaUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
                            findParaUOEGuideCode.Value = uoeGuideNameWork.UOEGuideCode;
                            findParaSectioncode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeGuideNameWork;
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
                            else if (logicalDelCd == 0) uoeGuideNameWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else uoeGuideNameWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                uoeGuideNameWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeGuideNameWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeGuideNameWork);
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

            uoeGuideNameList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="uoeGuideNameWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, UOEGuideNameWork uoeGuideNameWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  UOEGUID.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.EnterpriseCode);

            // ���_�R�[�h
            retstring += " AND UOEGUID.SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
            SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            findSectionCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.SectionCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND UOEGUID.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND UOEGUID.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // UOE�K�C�h�敪
            if (uoeGuideNameWork.UOEGuideDivCd != 0)
            {
                retstring += "  AND UOEGUID.UOEGUIDEDIVCDRF = @FINDUOEGUIDEDIVCD" + Environment.NewLine;
                SqlParameter findUOEGuideDivCd = sqlCommand.Parameters.Add("@FINDUOEGUIDEDIVCD", SqlDbType.Int);
                findUOEGuideDivCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOEGuideDivCd);
            }

            // UOE������R�[�h
            if (uoeGuideNameWork.UOESupplierCd != 0)
            {
                retstring += "  AND UOEGUID.UOESUPPLIERCDRF = @FINDUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter findUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                findUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeGuideNameWork.UOESupplierCd);
            }

            // UOE�K�C�h�敪
            if (uoeGuideNameWork.UOEGuideCode != string.Empty)
            {
                retstring += "  AND UOEGUID.UOEGUIDECODERF = @FINDUOEGUIDECODE" + Environment.NewLine;
                SqlParameter findUOEGuideCode = sqlCommand.Parameters.Add("@FINDUOEGUIDECODE", SqlDbType.NVarChar);
                findUOEGuideCode.Value = SqlDataMediator.SqlSetString(uoeGuideNameWork.UOEGuideCode);
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
        /// <br>Date       : 2008.06.06</br>
        private string MakeSyncWhereString(ref SqlCommand sqlCommand, SyncServiceWork syncServiceWork)
        {
            string wkstring = "";
            string retstring = "WHERE ";

            //��ƃR�[�h
            retstring += "UOEGUID.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.EnterpriseCode);
            
            // ���_�R�[�h
            retstring += "  UOEGUID.SECTIONCODERF = @FINDSECTIONCODOE" + Environment.NewLine;
            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            paraSectionCode.Value = SqlDataMediator.SqlSetString(syncServiceWork.SectionCode);

            //�����V���N�̏ꍇ�͍X�V���t�͈͎̔w��
            if (syncServiceWork.Syncmode == 0)
            {
                wkstring = "AND UOEGUID.UPDATEDATETIMERF>=@FINDUPDATEDATETIMEST ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeSt = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEST", SqlDbType.BigInt);
                paraUpdateDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeSt);

                wkstring = "AND UOEGUID.UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }
            else
            {
                wkstring = "AND UOEGUID.UPDATEDATETIMERF<=@FINDUPDATEDATETIMEED ";
                retstring += wkstring;
                SqlParameter paraUpdateDateTimeEd = sqlCommand.Parameters.Add("@FINDUPDATEDATETIMEED", SqlDbType.BigInt);
                paraUpdateDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(syncServiceWork.SyncDateTimeEd);
            }

            return retstring;
        }
        #endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� UOEGuideNameWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>UOEGuideNameWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private UOEGuideNameWork CopyToUOEGuideNameWorkFromReader(ref SqlDataReader myReader)
        {
            UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();

            this.CopyToUOEGuideNameWorkFromReader(ref myReader, ref uoeGuideNameWork);

            return uoeGuideNameWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� UOEGuideNameWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="uoeGuideNameWork">UOEGuideNameWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private void CopyToUOEGuideNameWorkFromReader(ref SqlDataReader myReader, ref UOEGuideNameWork uoeGuideNameWork)
        {
            if (myReader != null && uoeGuideNameWork != null)
            {
                # region �N���X�֊i�[
                uoeGuideNameWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                uoeGuideNameWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                uoeGuideNameWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                uoeGuideNameWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                uoeGuideNameWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                uoeGuideNameWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                uoeGuideNameWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                uoeGuideNameWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                uoeGuideNameWork.UOEGuideDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOEGUIDEDIVCDRF"));
                uoeGuideNameWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));
                uoeGuideNameWork.UOEGuideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEGUIDECODERF"));
                uoeGuideNameWork.UOEGuideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEGUIDENAMERF"));
                uoeGuideNameWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));
                uoeGuideNameWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                # endregion
            }
        }
        # endregion

        # region [�R�l�N�V������������]
        /*
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.06</br>
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
        */
        # endregion
    }
}

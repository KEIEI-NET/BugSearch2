//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE�����f�[�^DB�����[�g�I�u�W�F�N�g
//                  :   PMUOE01051R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.07.16
//----------------------------------------------------------------------
// Update Note      :   2011/10/28 ������
//�@�@�@�@�@�@�@�@�@:   ��Q�� #26283�Ə�Q�� #26284�̑Ή�
//----------------------------------------------------------------------
// Update Note      :   2012/09/20 yangmj
//�@�@�@�@�@�@�@�@�@:   ��Q�� #32404�̑Ή�
//----------------------------------------------------------------------
// Update Note      :   2012/10/03  FSI���X�� �M�p
//                      �d���悪�D�ǂ̏ꍇ�̎�M�G���[��
//                      ���M�G���[�Ƃ��ď��������s��Ή�
//----------------------------------------------------------------------
// Update Note      :   2018/06/20  miyatsu
//                      �s�v�ɂȂ����ߋ��̔����f�[�^�����x�Ɉ��e����^�����
//                      ���t�w��ňꊇ�����폜���鏈����ǉ�
//                      (PMKHN02060:�����ς݃f�[�^�폜�c�[���Ŏg�p)
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11400910-00  �쐬�S�� : �c����
// �� �� ��  2018/07/26   �C�����e : Redmine#49725 UOE�����f�[�^�폜�����Ή�
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11770032-00  �쐬�S�� : ���X�ؘj
// �� �� ��  2021/04/08   �C�����e : �^�C���A�E�g�ݒ�ǉ�
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11770032-00  �쐬�S�� : �c����
// �� �� ��  2021/06/10   �C�����e : PMKOBETSU-4144 �f�b�h���b�N�Ή�
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
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
// --- ADD 2021/04/08 �^�C���A�E�g�ݒ�ǉ� ------>>>>>
using Broadleaf.Application.Common;
// --- ADD 2021/04/08 �^�C���A�E�g�ݒ�ǉ� ------<<<<<
using System.Threading; //ADD 2021/06/10 �c���� PMKOBETSU-4144


namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// UOE�����f�[�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE�����f�[�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.07.16</br>
    /// <br></br>
    /// <br>Update Note: 22008 ���� e-Parts�Ή�</br>
    /// <br>Date       : 2009.05.25</br>
    /// <br>Update Note: Redmine#49725 UOE�����f�[�^�폜�����Ή�</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2018/07/26</br>
    /// <br>Update Note: 2021/04/08 ���X�ؘj</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>             �^�C���A�E�g�ݒ�ǉ�</br>
    /// <br>Update Note: 2021/06/10 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
    /// </remarks>
    [Serializable]
    public class UOEOrderDtlDB : RemoteWithAppLockDB, IUOEOrderDtlDB
    {
        // --- ADD 2021/06/10 �c���� PMKOBETSU-4144 �f�b�h���b�N�Ή� ----->>>>>
        // ���g���C��-�f�t�H���g�F5��
        private const int RETRY_COUNT_DEFAULT = 5;
        // ���g���C�Ԋu-�f�t�H���g�F60�b
        private const int RETRY_INTERVAL_DEFAULT = 60;
        // ���O�o��PGID
        private const string CURRENT_PGID = "PMUOE01051R";
        // �G���[���b�Z�[�W
        private const string ERR_MEG_D = "DeleteForceProcReTry�f�b�h���b�N���� ���g���C�񐔁F{0}���";
        // �f�b�h���b�N1205
        private const int DEAD_LOCK_VALUE = 1205;
        // SavePoint
        private const string SAVEPPIONT_D = "DeleteForceProcRetry";        
        // �萔(0)
        private const int ZERO_VALUE = 0;
        // --- ADD 2021/06/10 �c���� PMKOBETSU-4144 �f�b�h���b�N�Ή� -----<<<<<

        /// <summary>
        /// UOE�����f�[�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        /// </remarks>
        public UOEOrderDtlDB() : base("PMUOE01053D", "Broadleaf.Application.Remoting.ParamData.UOEOrderDtlWork", "UOEORDERDTLRF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P���UOE�����f�[�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlObj">UOEOrderDtlWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����UOE�����f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int Read(ref object uoeOrderDtlObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                UOEOrderDtlWork uoeOrderDtlWork = uoeOrderDtlObj as UOEOrderDtlWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref uoeOrderDtlWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P���UOE�����f�[�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlWork">UOEOrderDtlWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����UOE�����f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int Read(ref UOEOrderDtlWork uoeOrderDtlWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadProc(ref uoeOrderDtlWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P���UOE�����f�[�^�����擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlWork">UOEOrderDtlWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����UOE�����f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        private int ReadProc(ref UOEOrderDtlWork uoeOrderDtlWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND UOEKINDRF=@FINDUOEKIND" + Environment.NewLine;
                sqlText += "  AND ONLINENORF=@FINDONLINENO" + Environment.NewLine;
                sqlText += "  AND ONLINEROWNORF=@FINDONLINEROWNO" + Environment.NewLine;
                sqlText += "  AND COMMONSEQNORF=@FINDCOMMONSEQNO" + Environment.NewLine;
                sqlText += "  AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL" + Environment.NewLine;
                sqlText += "  AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUOEKind = sqlCommand.Parameters.Add("@FINDUOEKIND", SqlDbType.Int);
                SqlParameter findParaOnlineNo = sqlCommand.Parameters.Add("@FINDONLINENO", SqlDbType.Int);
                SqlParameter findParaOnlineRowNo = sqlCommand.Parameters.Add("@FINDONLINEROWNO", SqlDbType.Int);
                SqlParameter findParaCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                findParaUOEKind.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOEKind);
                findParaOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineNo);
                findParaOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineRowNo);
                findParaCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.CommonSeqNo);
                findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierFormal);
                findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.StockSlipDtlNum);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToUOEOrderDtlWorkFromReader(ref myReader, ref uoeOrderDtlWork);
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
        /// UOE�����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeOrderDtlList">�����폜����UOE�����f�[�^�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����UOE�����f�[�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int Delete(object uoeOrderDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeOrderDtlList as ArrayList;

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
        /// UOE�����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlList �Ɋi�[����Ă���UOE�����f�[�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int Delete(ArrayList uoeOrderDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteProc(uoeOrderDtlList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE�����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlList �Ɋi�[����Ă���UOE�����f�[�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        private int DeleteProc(ArrayList uoeOrderDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (uoeOrderDtlList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeOrderDtlList.Count; i++)
                    {
                        UOEOrderDtlWork uoeOrderDtlWork = uoeOrderDtlList[i] as UOEOrderDtlWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND UOEKINDRF=@FINDUOEKIND" + Environment.NewLine;
                        sqlText += "  AND ONLINENORF=@FINDONLINENO" + Environment.NewLine;
                        sqlText += "  AND ONLINEROWNORF=@FINDONLINEROWNO" + Environment.NewLine;
                        sqlText += "  AND COMMONSEQNORF=@FINDCOMMONSEQNO" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        sqlCommand.Parameters.Clear();
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOEKind = sqlCommand.Parameters.Add("@FINDUOEKIND", SqlDbType.Int);
                        SqlParameter findParaOnlineNo = sqlCommand.Parameters.Add("@FINDONLINENO", SqlDbType.Int);
                        SqlParameter findParaOnlineRowNo = sqlCommand.Parameters.Add("@FINDONLINEROWNO", SqlDbType.Int);
                        SqlParameter findParaCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                        SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                        findParaUOEKind.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOEKind);
                        findParaOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineNo);
                        findParaOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineRowNo);
                        findParaCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.CommonSeqNo);
                        findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierFormal);
                        findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.StockSlipDtlNum);
                        
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeOrderDtlWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND UOEKINDRF=@FINDUOEKIND" + Environment.NewLine;
                            sqlText += "  AND ONLINENORF=@FINDONLINENO" + Environment.NewLine;
                            sqlText += "  AND ONLINEROWNORF=@FINDONLINEROWNO" + Environment.NewLine;
                            sqlText += "  AND COMMONSEQNORF=@FINDCOMMONSEQNO" + Environment.NewLine;
                            sqlText += "  AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                            findParaUOEKind.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOEKind);
                            findParaOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineNo);
                            findParaOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineRowNo);
                            findParaCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.CommonSeqNo);
                            findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierFormal);
                            findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.StockSlipDtlNum);
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

        //2018/06/20 ADD >>>>
        # region [DeleteForce]
        /// <summary>
        /// UOE�����f�[�^�����ꊇ�����폜���܂�
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="inputDay"></param>
        /// <param name="delcnt"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����Ɉ�v����UOE�����f�[�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 30365 miyatsu</br>
        /// <br>Date       : 2018/06/20</br>
        /// <br>Update Note: Redmine#49725 UOE�����f�[�^�폜�����Ή�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2018/07/26</br>
        /// </remarks>
        // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------>>>>>
        //public int DeleteForce(string enterpriseCode, int sectionCode, int inputDay, out int delcnt)
        public int DeleteForce(string enterpriseCode, string sectionCode, int inputDay, out int delcnt)
        // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            delcnt = 0;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.DeleteForce(enterpriseCode, sectionCode, inputDay, out delcnt, ref sqlConnection, ref sqlTransaction);
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
        /// UOE�����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="inputDay"></param>
        /// <param name="delcnt"></param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����Ɉ�v����UOE�����f�[�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 30365 miyatsu</br>
        /// <br>Date       : 2018/06/20</br>
        /// <br>Update Note: Redmine#49725 UOE�����f�[�^�폜�����Ή�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2018/07/26</br>
        /// <br>Update Note: 2021/06/10 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        /// </remarks>
        // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------>>>>>
        //public int DeleteForce(string enterpriseCode, int sectionCode, int inputDay, out int delcnt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        public int DeleteForce(string enterpriseCode, string sectionCode, int inputDay, out int delcnt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------<<<<<
        {
            // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 �f�b�h���b�N�Ή� ----->>>>>
            //return DeleteForceProc(enterpriseCode, sectionCode, inputDay, out delcnt, ref sqlConnection, ref sqlTransaction);
            // ���g���C��
            int retryCnt = ZERO_VALUE;
            // ���O�o�̓N���X
            OutLogCommon outLogCommonObj = new OutLogCommon();
            // ���g���C�ݒ胏�[�N
            RetrySet retrySettingInfo = new RetrySet();
            // ���g���C�ݒ�擾�o�͕��i
            RetryXmlGetCommon retryCommon = new RetryXmlGetCommon();
            retryCommon.GetXmlInfo(CURRENT_PGID, RETRY_COUNT_DEFAULT, RETRY_INTERVAL_DEFAULT, ref retrySettingInfo);

            return this.DeleteForceProcRetry(enterpriseCode, sectionCode, inputDay, out delcnt, ref sqlConnection, ref sqlTransaction, ref retryCnt, outLogCommonObj, retrySettingInfo);
            // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 �f�b�h���b�N�Ή� -----<<<<<
        }

        // --- ADD 2021/06/10 �c���� PMKOBETSU-4144 �f�b�h���b�N�Ή�----->>>>> 
        /// <summary>
        /// UOE�����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_</param>
        /// <param name="inputDay">���͓�</param>
        /// <param name="delcnt">����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="retryCnt">���g���C��</param>
        /// <param name="outLogCommonObj">���O�o�̓N���X</param>
        /// <param name="retrySettingInfo">���g���C�ݒ胏�[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 2021/06/10 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        private int DeleteForceProcRetry(string enterpriseCode, string sectionCode, int inputDay, out int delcnt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref int retryCnt, OutLogCommon outLogCommonObj, RetrySet retrySettingInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();

            // ���g���C��
            retryCnt++;

            // savepiont�ݒ�
            sqlTransaction.Save(SAVEPPIONT_D);

            // UOE�����f�[�^���𕨗��폜���܂�
            status = DeleteForceProc(enterpriseCode, sectionCode, inputDay, out delcnt, ref sqlConnection, ref sqlTransaction);

            //�f�b�h���b�N�̏ꍇ
            if (status == DEAD_LOCK_VALUE)
            {
                // ���O�o��
                outLogCommonObj.OutputServerLog(CURRENT_PGID, string.Format(ERR_MEG_D, retryCnt.ToString()), serverLoginInfoAcquisition.EnterpriseCode, serverLoginInfoAcquisition.EmployeeCode, null);
                // ���g���C�񐔂܂�
                if (retryCnt >= retrySettingInfo.RetryCount)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;//����STATUS�l�𕜌�
                }
                else
                {
                    // �ݒ肵��savepoint�����[���o�b�N
                    sqlTransaction.Rollback(SAVEPPIONT_D);
                    // ���g���C�Ԋu��sleep
                    Thread.Sleep(retrySettingInfo.RetryInterval * 1000);
                    // ���g���C�������s��
                    status = this.DeleteForceProcRetry(enterpriseCode, sectionCode, inputDay, out delcnt, ref sqlConnection, ref sqlTransaction, ref retryCnt, outLogCommonObj, retrySettingInfo);
                }
            }

            return status;
        }
        // --- ADD 2021/06/10 �c���� PMKOBETSU-4144 �f�b�h���b�N�Ή�-----<<<<< 

        /// <summary>
        /// UOE�����f�[�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="inputDay"></param>
        /// <param name="delcnt"></param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����Ɉ�v����UOE�����f�[�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 30365 miyatsu</br>
        /// <br>Date       : 2018/06/20</br>
        /// <br>Update Note: Redmine#49725 UOE�����f�[�^�폜�����Ή�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2018/07/26</br>
        /// <br>Update Note: 2021/04/08 ���X�ؘj</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             �^�C���A�E�g�ݒ�ǉ�</br>
        /// <br>UpdateNote : 2021/06/10 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11770032-00</br>
        /// <br>             PMKOBETSU-4144 �f�b�h���b�N�Ή�</br>
        /// </remarks>
        // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------>>>>>
        //private int DeleteForceProc(string enterpriseCode, int sectionCode, int inputDay, out int delcnt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        private int DeleteForceProc(string enterpriseCode, string sectionCode, int inputDay, out int delcnt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------<<<<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            delcnt = 0;
            SqlCommand sqlCommand = null;

            try
            {
                //�N�G������
                string sqlText = string.Empty;
                sqlText += "DELETE" + Environment.NewLine;
                sqlText += "FROM UOEORDERDTLRF" + Environment.NewLine;
                sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------>>>>>
                //if (sectionCode != 0) //���_�R�[�h:0�Ȃ�S��
                if (!"00".Equals(sectionCode.Trim())) //���_�R�[�h:0�Ȃ�S��
                // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------<<<<<
                {
                    sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "  AND INPUTDAYRF<=@FINDINPUTDAY" + Environment.NewLine;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                
                //�p�����[�^�ݒ�
                sqlCommand.Parameters.Clear();
                //��ƃR�[�h
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                //���_�R�[�h
                SqlParameter findParaSectionCode = null;
                // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------>>>>>
                //if (sectionCode != 0) //���_�R�[�h:0�Ȃ�S��
                //{
                //    findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.Int);
                //    findParaSectionCode.Value = SqlDataMediator.SqlSetInt32(sectionCode);
                //}
                if (!"00".Equals(sectionCode.Trim())) //���_�R�[�h:0�Ȃ�S��
                {
                    findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode.Trim());
                }
                // ---UPD �c���� 2018/07/26 Redmine#49725 UOE�����f�[�^�폜�����Ή� ------<<<<<
                //���͓��t
                SqlParameter findParaInputDay = sqlCommand.Parameters.Add("@FINDINPUTDAY", SqlDbType.Int);
                findParaInputDay.Value = SqlDataMediator.SqlSetInt32(inputDay);


                // --- ADD 2021/04/08 �^�C���A�E�g�ݒ�ǉ� ------>>>>>
                // ���̃R�}���h�^�C���A�E�g�������l�ێ�
                int sqlCmdTimeout = sqlCommand.CommandTimeout;
                try
                {
                    // ���ʕ��i�R�}���h�^�C���A�E�g�ݒ�l���擾�iPMUOE01051R_DbCmdTimeout.xml�j
                    CommTimeoutConf ctc = new CommTimeoutConf();
                    sqlCmdTimeout = ctc.GetDbCommandTimeout("PMUOE01051R");
                }
                catch
                {
                    // ��O�������A���̃R�}���h�^�C���A�E�g�g�p
                    sqlCmdTimeout = sqlCommand.CommandTimeout;
                }
                finally
                {
                    // �R�}���h�^�C���A�E�g��ݒ�
                    sqlCommand.CommandTimeout = sqlCmdTimeout;
                }
                // --- ADD 2021/04/08 �^�C���A�E�g�ݒ�ǉ� ------<<<<<

                //���s�A�폜�������Z�b�g
                delcnt = sqlCommand.ExecuteNonQuery();
                
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 �f�b�h���b�N�Ή�----->>>>>
                //status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);

                //�f�b�g���b�N�̏ꍇ�A�f�b�h���b�N�l��status�ɃZ�b�g�A��̃��g���C�����ɗ��p
                if (ex.Number == DEAD_LOCK_VALUE)
                {
                    status = DEAD_LOCK_VALUE;
                }
                //�f�b�h���b�N�ȊO�̏ꍇ�A���̂܂�
                else
                {
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                // --- UPD 2021/06/10 �c���� PMKOBETSU-4144 �f�b�h���b�N�Ή�-----<<<<<
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        # endregion
        //2018/06/20 ADD <<<<

        # region [Search]
        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">��������</param>
        /// <param name="uoeOrderDtlObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int Search(ref object uoeOrderDtlList, object uoeOrderDtlObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList uoeOrderDtlArray = uoeOrderDtlList as ArrayList;

                if (uoeOrderDtlArray == null)
                {
                    uoeOrderDtlArray = new ArrayList();
                }

                UOEOrderDtlWork uoeOrderDtlWork = uoeOrderDtlObj as UOEOrderDtlWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref uoeOrderDtlArray, uoeOrderDtlWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="uoeOrderDtlWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int Search(ref ArrayList uoeOrderDtlList, UOEOrderDtlWork uoeOrderDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchProc(ref uoeOrderDtlList, uoeOrderDtlWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="uoeOrderDtlWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        private int SearchProc(ref ArrayList uoeOrderDtlList, UOEOrderDtlWork uoeOrderDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, uoeOrderDtlWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    uoeOrderDtlList.Add(this.CopyToUOEOrderDtlWorkFromReader(ref myReader));
                }

                if (uoeOrderDtlList.Count > 0)
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

        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">��������</param>
        /// <param name="uoeOrderDtlObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int SearchUoeSend(ref object uoeOrderDtlList, object uoeOrderDtlObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList uoeOrderDtlArray = uoeOrderDtlList as ArrayList;

                if (uoeOrderDtlArray == null)
                {
                    uoeOrderDtlArray = new ArrayList();
                }

                UOESendProcCndtnWork uoeSendProcCndtnWork = uoeOrderDtlObj as UOESendProcCndtnWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchUoeSend(ref uoeOrderDtlArray, uoeSendProcCndtnWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="uoeSendProcCndtnWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int SearchUoeSend(ref ArrayList uoeOrderDtlList, UOESendProcCndtnWork uoeSendProcCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchUoeSendProc(ref uoeOrderDtlList, uoeSendProcCndtnWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="uoeSendProcCndtnWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        /// <br>Update Note: 2012/09/20 yangmj redmine#23404�̑Ή�</br>
        /// <br>Update Note: 2012/10/03 FSI���X�� �M�p</br>
        /// <br>            �E�d���悪�D�ǂ̏ꍇ�̎�M�G���[��</br>
        /// <br>              ���M�G���[�Ƃ��ď��������s��Ή�</br>
        private int SearchUoeSendProc(ref ArrayList uoeOrderDtlList, UOESendProcCndtnWork uoeSendProcCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  *" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  UOEORDERDTLRF" + Environment.NewLine;

                sqlText += "WHERE" + Environment.NewLine;

                //��ƃR�[�h
                sqlText += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeSendProcCndtnWork.EnterpriseCode);

                //-----ADD YANGMJ 2012/09/20 REDMINE#32404 ----->>>>>
                //���_�R�[�h
                if (!string.IsNullOrEmpty(uoeSendProcCndtnWork.SectionCode))
                {
                    sqlText += " AND SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                    SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(uoeSendProcCndtnWork.SectionCode);
                }
                //-----ADD YANGMJ 2012/09/20 REDMINE#32404 -----<<<<<

                //�_���폜�敪
                sqlText += " AND LOGICALDELETECODERF=0" + Environment.NewLine;

                //�[���ԍ�
                if (uoeSendProcCndtnWork.CashRegisterNo != 0)
                {
                    sqlText += " AND CASHREGISTERNORF=@CASHREGISTERNO" + Environment.NewLine;
                    SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                    paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uoeSendProcCndtnWork.CashRegisterNo);
                }

                //�V�X�e���敪
                if (uoeSendProcCndtnWork.SystemDivCd != -1)
                {
                    sqlText += " AND SYSTEMDIVCDRF=@SYSTEMDIVCD" + Environment.NewLine;
                    SqlParameter paraSystemDivCd = sqlCommand.Parameters.Add("@SYSTEMDIVCD", SqlDbType.Int);
                    paraSystemDivCd.Value = SqlDataMediator.SqlSetInt32(uoeSendProcCndtnWork.SystemDivCd);
                }

                //�J�nUOE�����ԍ�
                if (uoeSendProcCndtnWork.St_UOESalesOrderNo!= 0)
                {
                    sqlText += " AND UOESALESORDERNORF>=@STUOESALESORDERNO" + Environment.NewLine;
                    SqlParameter paraStUOESalesOrderNo = sqlCommand.Parameters.Add("@STUOESALESORDERNO", SqlDbType.Int);
                    paraStUOESalesOrderNo.Value = SqlDataMediator.SqlSetInt32(uoeSendProcCndtnWork.St_UOESalesOrderNo);
                }

                //�I��UOE�����ԍ�
                if (uoeSendProcCndtnWork.Ed_UOESalesOrderNo != 0)
                {
                    sqlText += " AND UOESALESORDERNORF<=@EDUOESALESORDERNO" + Environment.NewLine;
                    SqlParameter paraEdUOESalesOrderNo = sqlCommand.Parameters.Add("@EDUOESALESORDERNO", SqlDbType.Int);
                    paraEdUOESalesOrderNo.Value = SqlDataMediator.SqlSetInt32(uoeSendProcCndtnWork.Ed_UOESalesOrderNo);
                }

                //�J�n���͓�
                if (uoeSendProcCndtnWork.St_InputDay != DateTime.MinValue)
                {
                    sqlText += " AND INPUTDAYRF>=@STINPUTDAY" + Environment.NewLine;
                    SqlParameter paraStInputDay = sqlCommand.Parameters.Add("@STINPUTDAY", SqlDbType.Int);
                    paraStInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(uoeSendProcCndtnWork.St_InputDay);
                }

                //�I�����͓�
                if (uoeSendProcCndtnWork.Ed_InputDay != DateTime.MinValue)
                {
                    sqlText += " AND INPUTDAYRF<=@EDINPUTDAY" + Environment.NewLine;
                    SqlParameter paraEdInputDay = sqlCommand.Parameters.Add("@EDINPUTDAY", SqlDbType.Int);
                    paraEdInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(uoeSendProcCndtnWork.Ed_InputDay);
                }

                //���Ӑ�R�[�h
                if (uoeSendProcCndtnWork.CustomerCode != 0)
                {
                    sqlText += " AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(uoeSendProcCndtnWork.CustomerCode);
                }

                //������R�[�h
                if (uoeSendProcCndtnWork.UOESupplierCd != 0)
                {
                    sqlText += " AND UOESUPPLIERCDRF=@UOESUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                    paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeSendProcCndtnWork.UOESupplierCd);
                }

                //�J�n�I�����C���ԍ�
                if (uoeSendProcCndtnWork.St_OnlineNo != 0)
                {
                    sqlText += " AND ONLINENORF>=@STONLINENO" + Environment.NewLine;
                    SqlParameter paraStOnlineNo = sqlCommand.Parameters.Add("@STONLINENO", SqlDbType.Int);
                    paraStOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeSendProcCndtnWork.St_OnlineNo);
                }

                //�I���I�����C���ԍ�
                if (uoeSendProcCndtnWork.Ed_OnlineNo != 0)
                {
                    sqlText += " AND ONLINENORF<=@EDONLINENO" + Environment.NewLine;
                    SqlParameter paraEdOnlineNo = sqlCommand.Parameters.Add("@EDONLINENO", SqlDbType.Int);
                    paraEdOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeSendProcCndtnWork.Ed_OnlineNo);
                }

                //�f�[�^���M�敪    ���z��ŕ����w�肳���
                if (uoeSendProcCndtnWork.DataSendCodes != null)
                {
                    string sendCodestr = "";
                    foreach (Int32 sendcd in uoeSendProcCndtnWork.DataSendCodes)
                    {
                        if (sendCodestr != "")
                        {
                            sendCodestr += ",";
                        }
                        sendCodestr += sendcd.ToString();
                    }

                    if (sendCodestr != "")
                    {
                        // ----- DEL 2012/10/03 ----->>>>>
                        //sqlText += " AND DATASENDCODERF IN (" + sendCodestr + ") ";
                        // ----- DEL 2012/10/03 -----<<<<<
                        // ----- ADD 2012/10/03 ----->>>>>
                        sqlText += " AND DATASENDCODERF IN (" + sendCodestr + ") " + Environment.NewLine;
                        // ----- ADD 2012/10/03 -----<<<<<
                    }
                }

                // ----- ADD 2012/10/03 ----->>>>>
                //�I�����C���ԍ��{�I�����C���s�ԍ����ɕ��ёւ���
                sqlText += " ORDER BY ONLINENORF, ONLINEROWNORF" + Environment.NewLine;
                // ----- ADD 2012/10/03 -----<<<<<

                sqlCommand.CommandText = sqlText;


                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    uoeOrderDtlList.Add(this.CopyToUOEOrderDtlWorkFromReader(ref myReader));
                }

                if (uoeOrderDtlList.Count > 0)
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

        // 2009/05/25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        # region  [e-Parts�p UoeOdrDtlGodsReadAll]
        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">��������</param>
        /// <param name="paraobj">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int UoeOdrDtlGodsReadAll(ref object uoeOrderDtlList, object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList uoeOrderDtlArray = uoeOrderDtlList as ArrayList;

                if (uoeOrderDtlArray == null)
                {
                    uoeOrderDtlArray = new ArrayList();
                }

                ArrayList paraList = paraobj as ArrayList; //�p�����[�^���X�g

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.UoeOdrDtlGodsReadAll(ref uoeOrderDtlArray, paraList, ref sqlConnection, ref sqlTransaction);
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
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="paraList">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int UoeOdrDtlGodsReadAll(ref ArrayList uoeOrderDtlList, ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UoeOdrDtlGodsReadAllProc(ref uoeOrderDtlList, paraList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="paraList">��������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.05.25</br>
        private int UoeOdrDtlGodsReadAllProc(ref ArrayList uoeOrderDtlList, ArrayList paraList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
                foreach (UOEOdrDtlGodsReadCndtnWork paraWork in paraList)
                {
                    sqlCommand.Parameters.Clear();

                    # region [SELECT��]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,SYSTEMDIVCDRF" + Environment.NewLine;
                    sqlText += " ,UOESALESORDERNORF" + Environment.NewLine;
                    sqlText += " ,UOESALESORDERROWNORF" + Environment.NewLine;
                    sqlText += " ,SENDTERMINALNORF" + Environment.NewLine;
                    sqlText += " ,UOESUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,UOESUPPLIERNAMERF" + Environment.NewLine;
                    sqlText += " ,COMMASSEMBLYIDRF" + Environment.NewLine;
                    sqlText += " ,ONLINENORF" + Environment.NewLine;
                    sqlText += " ,ONLINEROWNORF" + Environment.NewLine;
                    sqlText += " ,SALESDATERF" + Environment.NewLine;
                    sqlText += " ,INPUTDAYRF" + Environment.NewLine;
                    sqlText += " ,DATAUPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,UOEKINDRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += " ,ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += " ,SALESSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,SECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,SUBSECTIONCODERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,CUSTOMERSNMRF" + Environment.NewLine;
                    sqlText += " ,CASHREGISTERNORF" + Environment.NewLine;
                    sqlText += " ,COMMONSEQNORF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += " ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
                    sqlText += " ,BOCODERF" + Environment.NewLine;
                    sqlText += " ,UOEDELIGOODSDIVRF" + Environment.NewLine;
                    sqlText += " ,DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                    sqlText += " ,FOLLOWDELIGOODSDIVRF" + Environment.NewLine;
                    sqlText += " ,FOLLOWDELIGOODSDIVNMRF" + Environment.NewLine;
                    sqlText += " ,UOERESVDSECTIONRF" + Environment.NewLine;
                    sqlText += " ,UOERESVDSECTIONNMRF" + Environment.NewLine;
                    sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,EMPLOYEENAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,MAKERNAMERF" + Environment.NewLine;
                    sqlText += " ,GOODSNORF" + Environment.NewLine;
                    sqlText += " ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                    sqlText += " ,GOODSNAMERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSECODERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSENAMERF" + Environment.NewLine;
                    sqlText += " ,WAREHOUSESHELFNORF" + Environment.NewLine;
                    sqlText += " ,ACCEPTANORDERCNTRF" + Environment.NewLine;
                    sqlText += " ,LISTPRICERF" + Environment.NewLine;
                    sqlText += " ,SALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,SUPPLIERSNMRF" + Environment.NewLine;
                    sqlText += " ,UOEREMARK1RF" + Environment.NewLine;
                    sqlText += " ,UOEREMARK2RF" + Environment.NewLine;
                    sqlText += " ,RECEIVEDATERF" + Environment.NewLine;
                    sqlText += " ,RECEIVETIMERF" + Environment.NewLine;
                    sqlText += " ,ANSWERMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,ANSWERPARTSNORF" + Environment.NewLine;
                    sqlText += " ,ANSWERPARTSNAMERF" + Environment.NewLine;
                    sqlText += " ,SUBSTPARTSNORF" + Environment.NewLine;
                    sqlText += " ,UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                    sqlText += " ,BOSHIPMENTCNT1RF" + Environment.NewLine;
                    sqlText += " ,BOSHIPMENTCNT2RF" + Environment.NewLine;
                    sqlText += " ,BOSHIPMENTCNT3RF" + Environment.NewLine;
                    sqlText += " ,MAKERFOLLOWCNTRF" + Environment.NewLine;
                    sqlText += " ,NONSHIPMENTCNTRF" + Environment.NewLine;
                    sqlText += " ,UOESECTSTOCKCNTRF" + Environment.NewLine;
                    sqlText += " ,BOSTOCKCOUNT1RF" + Environment.NewLine;
                    sqlText += " ,BOSTOCKCOUNT2RF" + Environment.NewLine;
                    sqlText += " ,BOSTOCKCOUNT3RF" + Environment.NewLine;
                    sqlText += " ,UOESECTIONSLIPNORF" + Environment.NewLine;
                    sqlText += " ,BOSLIPNO1RF" + Environment.NewLine;
                    sqlText += " ,BOSLIPNO2RF" + Environment.NewLine;
                    sqlText += " ,BOSLIPNO3RF" + Environment.NewLine;
                    sqlText += " ,EOALWCCOUNTRF" + Environment.NewLine;
                    sqlText += " ,BOMANAGEMENTNORF" + Environment.NewLine;
                    sqlText += " ,ANSWERLISTPRICERF" + Environment.NewLine;
                    sqlText += " ,ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                    sqlText += " ,UOESUBSTMARKRF" + Environment.NewLine;
                    sqlText += " ,UOESTOCKMARKRF" + Environment.NewLine;
                    sqlText += " ,PARTSLAYERCDRF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESHIPSECTCD1RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESHIPSECTCD2RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESHIPSECTCD3RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESECTCD1RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESECTCD2RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESECTCD3RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESECTCD4RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESECTCD5RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESECTCD6RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESECTCD7RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESTOCKCNT1RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESTOCKCNT2RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESTOCKCNT3RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESTOCKCNT4RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESTOCKCNT5RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESTOCKCNT6RF" + Environment.NewLine;
                    sqlText += " ,MAZDAUOESTOCKCNT7RF" + Environment.NewLine;
                    sqlText += " ,UOEDISTRIBUTIONCDRF" + Environment.NewLine;
                    sqlText += " ,UOEOTHERCDRF" + Environment.NewLine;
                    sqlText += " ,UOEHMCDRF" + Environment.NewLine;
                    sqlText += " ,BOCOUNTRF" + Environment.NewLine;
                    sqlText += " ,UOEMARKCODERF" + Environment.NewLine;
                    sqlText += " ,SOURCESHIPMENTRF" + Environment.NewLine;
                    sqlText += " ,ITEMCODERF" + Environment.NewLine;
                    sqlText += " ,UOECHECKCODERF" + Environment.NewLine;
                    sqlText += " ,HEADERRORMASSAGERF" + Environment.NewLine;
                    sqlText += " ,LINEERRORMASSAGERF" + Environment.NewLine;
                    sqlText += " ,DATASENDCODERF" + Environment.NewLine;
                    sqlText += " ,DATARECOVERDIVRF" + Environment.NewLine;
                    sqlText += " ,ENTERUPDDIVSECRF" + Environment.NewLine;
                    sqlText += " ,ENTERUPDDIVBO1RF" + Environment.NewLine;
                    sqlText += " ,ENTERUPDDIVBO2RF" + Environment.NewLine;
                    sqlText += " ,ENTERUPDDIVBO3RF" + Environment.NewLine;
                    sqlText += " ,ENTERUPDDIVMAKERRF" + Environment.NewLine;
                    sqlText += " ,ENTERUPDDIVEORF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  UOEORDERDTLRF" + Environment.NewLine;

                    sqlText += "WHERE" + Environment.NewLine;

                    //��ƃR�[�h
                    sqlText += " ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paraWork.EnterpriseCode);

                    //�_���폜�敪
                    sqlText += " AND LOGICALDELETECODERF=0" + Environment.NewLine;

                    //���_�R�[�h
                    if (string.IsNullOrEmpty(paraWork.SectionCode) == false)
                    {
                        sqlText += " AND SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(paraWork.SectionCode);
                    }

                    //UOE������R�[�h
                    if (paraWork.UOESupplierCd != 0)
                    {
                        sqlText += " AND UOESUPPLIERCDRF=@UOESUPPLIERCD" + Environment.NewLine;
                        SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                        paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(paraWork.UOESupplierCd);
                    }

                    //UOE�����ԍ�
                    if (paraWork.UOESalesOrderNo != 0)
                    {
                        sqlText += " AND UOESALESORDERNORF=@UOESALESORDERNO" + Environment.NewLine;
                        SqlParameter paraUOESalesOrderNo = sqlCommand.Parameters.Add("@UOESALESORDERNO", SqlDbType.Int);
                        paraUOESalesOrderNo.Value = SqlDataMediator.SqlSetInt32(paraWork.UOESalesOrderNo);
                    }

                    //�n�C�t�����i��
                    if (string.IsNullOrEmpty(paraWork.GoodsNoNoneHyphen) == false)
                    {
                        sqlText += " AND GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(paraWork.GoodsNoNoneHyphen);
                    }

                    //�f�[�^���M�敪    ���z��ŕ����w�肳���
                    if (paraWork.DataSendCodes != null)
                    {
                        string sendCodestr = "";
                        foreach (Int32 sendcd in paraWork.DataSendCodes)
                        {
                            if (sendCodestr != "")
                            {
                                sendCodestr += ",";
                            }
                            sendCodestr += sendcd.ToString();
                        }

                        if (sendCodestr != "")
                        {
                            sqlText += " AND DATASENDCODERF IN (" + sendCodestr + ") ";
                        }
                    }

                    sqlCommand.CommandText = sqlText;


                    # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        uoeOrderDtlList.Add(this.CopyToUOEOrderDtlWorkFromReader(ref myReader));
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                }
                if (uoeOrderDtlList.Count > 0)
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
        // 2009/05/25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        #region Search(�r���`�F�b�N�p)
        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="paraUoeOrderDtlList">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.05.25</br>
        public int SearchSendCodeCheck(out ArrayList uoeOrderDtlList, ArrayList paraUoeOrderDtlList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return SearchSendCodeCheckProc(out uoeOrderDtlList, paraUoeOrderDtlList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE�����f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="paraUoeOrderDtlList">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : UOE�����f�[�^�̃L�[�l����v����A�S�Ă�UOE�����f�[�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.05.25</br>
        private int SearchSendCodeCheckProc(out ArrayList uoeOrderDtlList, ArrayList paraUoeOrderDtlList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            uoeOrderDtlList = new ArrayList();
            int mcnt = 0;

            try
            {

                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                //���X�g�̌�������������
                while (mcnt != paraUoeOrderDtlList.Count)
                {
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  *" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND UOEKINDRF=@FINDUOEKIND" + Environment.NewLine;
                    sqlText += "  AND SENDTERMINALNORF<>0" + Environment.NewLine;

                    sqlCommand.CommandText = sqlText;

                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaUOEKind = sqlCommand.Parameters.Add("@FINDUOEKIND", SqlDbType.Int);

                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString((paraUoeOrderDtlList[0] as UOEOrderDtlWork).EnterpriseCode);
                    findParaUOEKind.Value = SqlDataMediator.SqlSetInt32((paraUoeOrderDtlList[0] as UOEOrderDtlWork).UOEKind);

                    sqlText = string.Empty;

                    //���IWhere������
                    for (int i = mcnt; i < paraUoeOrderDtlList.Count; i++)
                    {
                        UOEOrderDtlWork uoeOrderDtlWork = paraUoeOrderDtlList[i] as UOEOrderDtlWork;

                        sqlText += "  AND (COMMONSEQNORF=" + uoeOrderDtlWork.CommonSeqNo.ToString() + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF=" + uoeOrderDtlWork.SupplierFormal.ToString() + Environment.NewLine;
                        sqlText += "  AND STOCKSLIPDTLNUMRF=" + uoeOrderDtlWork.StockSlipDtlNum.ToString() + ")" + Environment.NewLine;

                        mcnt++;
                        //100�����ƂɃN�G�������s����
                        if (mcnt % 100 == 0) break;
                    }


                    //���IWhere���Z�b�g
                    sqlCommand.CommandText = sqlText;

#if DEBUG
                    Console.Clear();
                    Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        uoeOrderDtlList.Add(this.CopyToUOEOrderDtlWorkFromReader(ref myReader));
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }

                if (uoeOrderDtlList.Count > 0)
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
        #endregion

        # region [Write]
        /// <summary>
        /// UOE�����f�[�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�ǉ��E�X�V����UOE�����f�[�^�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlList �Ɋi�[����Ă���UOE�����f�[�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int Write(ref object uoeOrderDtlList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeOrderDtlList as ArrayList;

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
        /// UOE�����f�[�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�ǉ��E�X�V����UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlList �Ɋi�[����Ă���UOE�����f�[�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int Write(ref ArrayList uoeOrderDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref uoeOrderDtlList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE�����f�[�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�ǉ��E�X�V����UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlList �Ɋi�[����Ă���UOE�����f�[�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        private int WriteProc(ref ArrayList uoeOrderDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeOrderDtlList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeOrderDtlList.Count; i++)
                    {
                        UOEOrderDtlWork uoeOrderDtlWork = uoeOrderDtlList[i] as UOEOrderDtlWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND UOEKINDRF=@FINDUOEKIND" + Environment.NewLine;
                        sqlText += "  AND ONLINENORF=@FINDONLINENO" + Environment.NewLine;
                        sqlText += "  AND ONLINEROWNORF=@FINDONLINEROWNO" + Environment.NewLine;
                        sqlText += "  AND COMMONSEQNORF=@FINDCOMMONSEQNO" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOEKind = sqlCommand.Parameters.Add("@FINDUOEKIND", SqlDbType.Int);
                        SqlParameter findParaOnlineNo = sqlCommand.Parameters.Add("@FINDONLINENO", SqlDbType.Int);
                        SqlParameter findParaOnlineRowNo = sqlCommand.Parameters.Add("@FINDONLINEROWNO", SqlDbType.Int);
                        SqlParameter findParaCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                        SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                        findParaUOEKind.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOEKind);
                        findParaOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineNo);
                        findParaOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineRowNo);
                        findParaCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.CommonSeqNo);
                        findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierFormal);
                        findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.StockSlipDtlNum);
    
                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeOrderDtlWork.UpdateDateTime)
                            {
                                if (uoeOrderDtlWork.UpdateDateTime == DateTime.MinValue)
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

                            sqlText += " UPDATE UOEORDERDTLRF SET" + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  , SYSTEMDIVCDRF=@SYSTEMDIVCD" + Environment.NewLine;
                            sqlText += "  , UOESALESORDERNORF=@UOESALESORDERNO" + Environment.NewLine;
                            sqlText += "  , UOESALESORDERROWNORF=@UOESALESORDERROWNO" + Environment.NewLine;
                            sqlText += "  , SENDTERMINALNORF=@SENDTERMINALNO" + Environment.NewLine;
                            sqlText += "  , UOESUPPLIERCDRF=@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "  , UOESUPPLIERNAMERF=@UOESUPPLIERNAME" + Environment.NewLine;
                            sqlText += "  , COMMASSEMBLYIDRF=@COMMASSEMBLYID" + Environment.NewLine;
                            sqlText += "  , ONLINENORF=@ONLINENO" + Environment.NewLine;
                            sqlText += "  , ONLINEROWNORF=@ONLINEROWNO" + Environment.NewLine;
                            sqlText += "  , SALESDATERF=@SALESDATE" + Environment.NewLine;
                            sqlText += "  , INPUTDAYRF=@INPUTDAY" + Environment.NewLine;
                            sqlText += "  , DATAUPDATEDATETIMERF=@DATAUPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  , UOEKINDRF=@UOEKIND" + Environment.NewLine;
                            sqlText += "  , SALESSLIPNUMRF=@SALESSLIPNUM" + Environment.NewLine;
                            sqlText += "  , ACPTANODRSTATUSRF=@ACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  , SALESSLIPDTLNUMRF=@SALESSLIPDTLNUM" + Environment.NewLine;
                            sqlText += "  , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  , SUBSECTIONCODERF=@SUBSECTIONCODE" + Environment.NewLine;
                            sqlText += "  , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  , CUSTOMERSNMRF=@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += "  , CASHREGISTERNORF=@CASHREGISTERNO" + Environment.NewLine;
                            sqlText += "  , COMMONSEQNORF=@COMMONSEQNO" + Environment.NewLine;
                            sqlText += "  , SUPPLIERFORMALRF=@SUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  , SUPPLIERSLIPNORF=@SUPPLIERSLIPNO" + Environment.NewLine;
                            sqlText += "  , STOCKSLIPDTLNUMRF=@STOCKSLIPDTLNUM" + Environment.NewLine;
                            sqlText += "  , BOCODERF=@BOCODE" + Environment.NewLine;
                            sqlText += "  , UOEDELIGOODSDIVRF=@UOEDELIGOODSDIV" + Environment.NewLine;
                            sqlText += "  , DELIVEREDGOODSDIVNMRF=@DELIVEREDGOODSDIVNM" + Environment.NewLine;
                            sqlText += "  , FOLLOWDELIGOODSDIVRF=@FOLLOWDELIGOODSDIV" + Environment.NewLine;
                            sqlText += "  , FOLLOWDELIGOODSDIVNMRF=@FOLLOWDELIGOODSDIVNM" + Environment.NewLine;
                            sqlText += "  , UOERESVDSECTIONRF=@UOERESVDSECTION" + Environment.NewLine;
                            sqlText += "  , UOERESVDSECTIONNMRF=@UOERESVDSECTIONNM" + Environment.NewLine;
                            sqlText += "  , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  , EMPLOYEENAMERF=@EMPLOYEENAME" + Environment.NewLine;
                            sqlText += "  , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += "  , MAKERNAMERF=@MAKERNAME" + Environment.NewLine;
                            sqlText += "  , GOODSNORF=@GOODSNO" + Environment.NewLine;
                            sqlText += "  , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN" + Environment.NewLine;
                            sqlText += "  , GOODSNAMERF=@GOODSNAME" + Environment.NewLine;
                            sqlText += "  , WAREHOUSECODERF=@WAREHOUSECODE" + Environment.NewLine;
                            sqlText += "  , WAREHOUSENAMERF=@WAREHOUSENAME" + Environment.NewLine;
                            sqlText += "  , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO" + Environment.NewLine;
                            sqlText += "  , ACCEPTANORDERCNTRF=@ACCEPTANORDERCNT" + Environment.NewLine;
                            sqlText += "  , LISTPRICERF=@LISTPRICE" + Environment.NewLine;
                            sqlText += "  , SALESUNITCOSTRF=@SALESUNITCOST" + Environment.NewLine;
                            sqlText += "  , SUPPLIERCDRF=@SUPPLIERCD" + Environment.NewLine;
                            sqlText += "  , SUPPLIERSNMRF=@SUPPLIERSNM" + Environment.NewLine;
                            sqlText += "  , UOEREMARK1RF=@UOEREMARK1" + Environment.NewLine;
                            sqlText += "  , UOEREMARK2RF=@UOEREMARK2" + Environment.NewLine;
                            sqlText += "  , RECEIVEDATERF=@RECEIVEDATE" + Environment.NewLine;
                            sqlText += "  , RECEIVETIMERF=@RECEIVETIME" + Environment.NewLine;
                            sqlText += "  , ANSWERMAKERCDRF=@ANSWERMAKERCD" + Environment.NewLine;
                            sqlText += "  , ANSWERPARTSNORF=@ANSWERPARTSNO" + Environment.NewLine;
                            sqlText += "  , ANSWERPARTSNAMERF=@ANSWERPARTSNAME" + Environment.NewLine;
                            sqlText += "  , SUBSTPARTSNORF=@SUBSTPARTSNO" + Environment.NewLine;
                            sqlText += "  , UOESECTOUTGOODSCNTRF=@UOESECTOUTGOODSCNT" + Environment.NewLine;
                            sqlText += "  , BOSHIPMENTCNT1RF=@BOSHIPMENTCNT1" + Environment.NewLine;
                            sqlText += "  , BOSHIPMENTCNT2RF=@BOSHIPMENTCNT2" + Environment.NewLine;
                            sqlText += "  , BOSHIPMENTCNT3RF=@BOSHIPMENTCNT3" + Environment.NewLine;
                            sqlText += "  , MAKERFOLLOWCNTRF=@MAKERFOLLOWCNT" + Environment.NewLine;
                            sqlText += "  , NONSHIPMENTCNTRF=@NONSHIPMENTCNT" + Environment.NewLine;
                            sqlText += "  , UOESECTSTOCKCNTRF=@UOESECTSTOCKCNT" + Environment.NewLine;
                            sqlText += "  , BOSTOCKCOUNT1RF=@BOSTOCKCOUNT1" + Environment.NewLine;
                            sqlText += "  , BOSTOCKCOUNT2RF=@BOSTOCKCOUNT2" + Environment.NewLine;
                            sqlText += "  , BOSTOCKCOUNT3RF=@BOSTOCKCOUNT3" + Environment.NewLine;
                            sqlText += "  , UOESECTIONSLIPNORF=@UOESECTIONSLIPNO" + Environment.NewLine;
                            sqlText += "  , BOSLIPNO1RF=@BOSLIPNO1" + Environment.NewLine;
                            sqlText += "  , BOSLIPNO2RF=@BOSLIPNO2" + Environment.NewLine;
                            sqlText += "  , BOSLIPNO3RF=@BOSLIPNO3" + Environment.NewLine;
                            sqlText += "  , EOALWCCOUNTRF=@EOALWCCOUNT" + Environment.NewLine;
                            sqlText += "  , BOMANAGEMENTNORF=@BOMANAGEMENTNO" + Environment.NewLine;
                            sqlText += "  , ANSWERLISTPRICERF=@ANSWERLISTPRICE" + Environment.NewLine;
                            sqlText += "  , ANSWERSALESUNITCOSTRF=@ANSWERSALESUNITCOST" + Environment.NewLine;
                            sqlText += "  , UOESUBSTMARKRF=@UOESUBSTMARK" + Environment.NewLine;
                            sqlText += "  , UOESTOCKMARKRF=@UOESTOCKMARK" + Environment.NewLine;
                            sqlText += "  , PARTSLAYERCDRF=@PARTSLAYERCD" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESHIPSECTCD1RF=@MAZDAUOESHIPSECTCD1" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESHIPSECTCD2RF=@MAZDAUOESHIPSECTCD2" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESHIPSECTCD3RF=@MAZDAUOESHIPSECTCD3" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESECTCD1RF=@MAZDAUOESECTCD1" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESECTCD2RF=@MAZDAUOESECTCD2" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESECTCD3RF=@MAZDAUOESECTCD3" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESECTCD4RF=@MAZDAUOESECTCD4" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESECTCD5RF=@MAZDAUOESECTCD5" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESECTCD6RF=@MAZDAUOESECTCD6" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESECTCD7RF=@MAZDAUOESECTCD7" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESTOCKCNT1RF=@MAZDAUOESTOCKCNT1" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESTOCKCNT2RF=@MAZDAUOESTOCKCNT2" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESTOCKCNT3RF=@MAZDAUOESTOCKCNT3" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESTOCKCNT4RF=@MAZDAUOESTOCKCNT4" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESTOCKCNT5RF=@MAZDAUOESTOCKCNT5" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESTOCKCNT6RF=@MAZDAUOESTOCKCNT6" + Environment.NewLine;
                            sqlText += "  , MAZDAUOESTOCKCNT7RF=@MAZDAUOESTOCKCNT7" + Environment.NewLine;
                            sqlText += "  , UOEDISTRIBUTIONCDRF=@UOEDISTRIBUTIONCD" + Environment.NewLine;
                            sqlText += "  , UOEOTHERCDRF=@UOEOTHERCD" + Environment.NewLine;
                            sqlText += "  , UOEHMCDRF=@UOEHMCD" + Environment.NewLine;
                            sqlText += "  , BOCOUNTRF=@BOCOUNT" + Environment.NewLine;
                            sqlText += "  , UOEMARKCODERF=@UOEMARKCODE" + Environment.NewLine;
                            sqlText += "  , SOURCESHIPMENTRF=@SOURCESHIPMENT" + Environment.NewLine;
                            sqlText += "  , ITEMCODERF=@ITEMCODE" + Environment.NewLine;
                            sqlText += "  , UOECHECKCODERF=@UOECHECKCODE" + Environment.NewLine;
                            sqlText += "  , HEADERRORMASSAGERF=@HEADERRORMASSAGE" + Environment.NewLine;
                            sqlText += "  , LINEERRORMASSAGERF=@LINEERRORMASSAGE" + Environment.NewLine;
                            sqlText += "  , DATASENDCODERF=@DATASENDCODE" + Environment.NewLine;
                            sqlText += "  , DATARECOVERDIVRF=@DATARECOVERDIV" + Environment.NewLine;
                            sqlText += "  , ENTERUPDDIVSECRF=@ENTERUPDDIVSEC" + Environment.NewLine;
                            sqlText += "  , ENTERUPDDIVBO1RF=@ENTERUPDDIVBO1" + Environment.NewLine;
                            sqlText += "  , ENTERUPDDIVBO2RF=@ENTERUPDDIVBO2" + Environment.NewLine;
                            sqlText += "  , ENTERUPDDIVBO3RF=@ENTERUPDDIVBO3" + Environment.NewLine;
                            sqlText += "  , ENTERUPDDIVMAKERRF=@ENTERUPDDIVMAKER" + Environment.NewLine;
                            sqlText += "  , ENTERUPDDIVEORF=@ENTERUPDDIVEO" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND UOEKINDRF=@FINDUOEKIND" + Environment.NewLine;
                            sqlText += "  AND ONLINENORF=@FINDONLINENO" + Environment.NewLine;
                            sqlText += "  AND ONLINEROWNORF=@FINDONLINEROWNO" + Environment.NewLine;
                            sqlText += "  AND COMMONSEQNORF=@FINDCOMMONSEQNO" + Environment.NewLine;
                            sqlText += "  AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                            
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                            findParaUOEKind.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOEKind);
                            findParaOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineNo);
                            findParaOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineRowNo);
                            findParaCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.CommonSeqNo);
                            findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierFormal);
                            findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.StockSlipDtlNum);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeOrderDtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (uoeOrderDtlWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;

                            sqlText += "INSERT INTO UOEORDERDTLRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "  ,SYSTEMDIVCDRF" + Environment.NewLine;
                            sqlText += "  ,UOESALESORDERNORF" + Environment.NewLine;
                            sqlText += "  ,UOESALESORDERROWNORF" + Environment.NewLine;
                            sqlText += "  ,SENDTERMINALNORF" + Environment.NewLine;
                            sqlText += "  ,UOESUPPLIERCDRF" + Environment.NewLine;
                            sqlText += "  ,UOESUPPLIERNAMERF" + Environment.NewLine;
                            sqlText += "  ,COMMASSEMBLYIDRF" + Environment.NewLine;
                            sqlText += "  ,ONLINENORF" + Environment.NewLine;
                            sqlText += "  ,ONLINEROWNORF" + Environment.NewLine;
                            sqlText += "  ,SALESDATERF" + Environment.NewLine;
                            sqlText += "  ,INPUTDAYRF" + Environment.NewLine;
                            sqlText += "  ,DATAUPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UOEKINDRF" + Environment.NewLine;
                            sqlText += "  ,SALESSLIPNUMRF" + Environment.NewLine;
                            sqlText += "  ,ACPTANODRSTATUSRF" + Environment.NewLine;
                            sqlText += "  ,SALESSLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,SUBSECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERSNMRF" + Environment.NewLine;
                            sqlText += "  ,CASHREGISTERNORF" + Environment.NewLine;
                            sqlText += "  ,COMMONSEQNORF" + Environment.NewLine;
                            sqlText += "  ,SUPPLIERFORMALRF" + Environment.NewLine;
                            sqlText += "  ,SUPPLIERSLIPNORF" + Environment.NewLine;
                            sqlText += "  ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "  ,BOCODERF" + Environment.NewLine;
                            sqlText += "  ,UOEDELIGOODSDIVRF" + Environment.NewLine;
                            sqlText += "  ,DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                            sqlText += "  ,FOLLOWDELIGOODSDIVRF" + Environment.NewLine;
                            sqlText += "  ,FOLLOWDELIGOODSDIVNMRF" + Environment.NewLine;
                            sqlText += "  ,UOERESVDSECTIONRF" + Environment.NewLine;
                            sqlText += "  ,UOERESVDSECTIONNMRF" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEENAMERF" + Environment.NewLine;
                            sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlText += "  ,MAKERNAMERF" + Environment.NewLine;
                            sqlText += "  ,GOODSNORF" + Environment.NewLine;
                            sqlText += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            sqlText += "  ,GOODSNAMERF" + Environment.NewLine;
                            sqlText += "  ,WAREHOUSECODERF" + Environment.NewLine;
                            sqlText += "  ,WAREHOUSENAMERF" + Environment.NewLine;
                            sqlText += "  ,WAREHOUSESHELFNORF" + Environment.NewLine;
                            sqlText += "  ,ACCEPTANORDERCNTRF" + Environment.NewLine;
                            sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                            sqlText += "  ,SALESUNITCOSTRF" + Environment.NewLine;
                            sqlText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += "  ,SUPPLIERSNMRF" + Environment.NewLine;
                            sqlText += "  ,UOEREMARK1RF" + Environment.NewLine;
                            sqlText += "  ,UOEREMARK2RF" + Environment.NewLine;
                            sqlText += "  ,RECEIVEDATERF" + Environment.NewLine;
                            sqlText += "  ,RECEIVETIMERF" + Environment.NewLine;
                            sqlText += "  ,ANSWERMAKERCDRF" + Environment.NewLine;
                            sqlText += "  ,ANSWERPARTSNORF" + Environment.NewLine;
                            sqlText += "  ,ANSWERPARTSNAMERF" + Environment.NewLine;
                            sqlText += "  ,SUBSTPARTSNORF" + Environment.NewLine;
                            sqlText += "  ,UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                            sqlText += "  ,BOSHIPMENTCNT1RF" + Environment.NewLine;
                            sqlText += "  ,BOSHIPMENTCNT2RF" + Environment.NewLine;
                            sqlText += "  ,BOSHIPMENTCNT3RF" + Environment.NewLine;
                            sqlText += "  ,MAKERFOLLOWCNTRF" + Environment.NewLine;
                            sqlText += "  ,NONSHIPMENTCNTRF" + Environment.NewLine;
                            sqlText += "  ,UOESECTSTOCKCNTRF" + Environment.NewLine;
                            sqlText += "  ,BOSTOCKCOUNT1RF" + Environment.NewLine;
                            sqlText += "  ,BOSTOCKCOUNT2RF" + Environment.NewLine;
                            sqlText += "  ,BOSTOCKCOUNT3RF" + Environment.NewLine;
                            sqlText += "  ,UOESECTIONSLIPNORF" + Environment.NewLine;
                            sqlText += "  ,BOSLIPNO1RF" + Environment.NewLine;
                            sqlText += "  ,BOSLIPNO2RF" + Environment.NewLine;
                            sqlText += "  ,BOSLIPNO3RF" + Environment.NewLine;
                            sqlText += "  ,EOALWCCOUNTRF" + Environment.NewLine;
                            sqlText += "  ,BOMANAGEMENTNORF" + Environment.NewLine;
                            sqlText += "  ,ANSWERLISTPRICERF" + Environment.NewLine;
                            sqlText += "  ,ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                            sqlText += "  ,UOESUBSTMARKRF" + Environment.NewLine;
                            sqlText += "  ,UOESTOCKMARKRF" + Environment.NewLine;
                            sqlText += "  ,PARTSLAYERCDRF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESHIPSECTCD1RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESHIPSECTCD2RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESHIPSECTCD3RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD1RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD2RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD3RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD4RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD5RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD6RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD7RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT1RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT2RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT3RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT4RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT5RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT6RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT7RF" + Environment.NewLine;
                            sqlText += "  ,UOEDISTRIBUTIONCDRF" + Environment.NewLine;
                            sqlText += "  ,UOEOTHERCDRF" + Environment.NewLine;
                            sqlText += "  ,UOEHMCDRF" + Environment.NewLine;
                            sqlText += "  ,BOCOUNTRF" + Environment.NewLine;
                            sqlText += "  ,UOEMARKCODERF" + Environment.NewLine;
                            sqlText += "  ,SOURCESHIPMENTRF" + Environment.NewLine;
                            sqlText += "  ,ITEMCODERF" + Environment.NewLine;
                            sqlText += "  ,UOECHECKCODERF" + Environment.NewLine;
                            sqlText += "  ,HEADERRORMASSAGERF" + Environment.NewLine;
                            sqlText += "  ,LINEERRORMASSAGERF" + Environment.NewLine;
                            sqlText += "  ,DATASENDCODERF" + Environment.NewLine;
                            sqlText += "  ,DATARECOVERDIVRF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVSECRF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVBO1RF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVBO2RF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVBO3RF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVMAKERRF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVEORF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,@SYSTEMDIVCD" + Environment.NewLine;
                            sqlText += "  ,@UOESALESORDERNO" + Environment.NewLine;
                            sqlText += "  ,@UOESALESORDERROWNO" + Environment.NewLine;
                            sqlText += "  ,@SENDTERMINALNO" + Environment.NewLine;
                            sqlText += "  ,@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "  ,@UOESUPPLIERNAME" + Environment.NewLine;
                            sqlText += "  ,@COMMASSEMBLYID" + Environment.NewLine;
                            sqlText += "  ,@ONLINENO" + Environment.NewLine;
                            sqlText += "  ,@ONLINEROWNO" + Environment.NewLine;
                            sqlText += "  ,@SALESDATE" + Environment.NewLine;
                            sqlText += "  ,@INPUTDAY" + Environment.NewLine;
                            sqlText += "  ,@DATAUPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UOEKIND" + Environment.NewLine;
                            sqlText += "  ,@SALESSLIPNUM" + Environment.NewLine;
                            sqlText += "  ,@ACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  ,@SALESSLIPDTLNUM" + Environment.NewLine;
                            sqlText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@SUBSECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  ,@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += "  ,@CASHREGISTERNO" + Environment.NewLine;
                            sqlText += "  ,@COMMONSEQNO" + Environment.NewLine;
                            sqlText += "  ,@SUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  ,@SUPPLIERSLIPNO" + Environment.NewLine;
                            sqlText += "  ,@STOCKSLIPDTLNUM" + Environment.NewLine;
                            sqlText += "  ,@BOCODE" + Environment.NewLine;
                            sqlText += "  ,@UOEDELIGOODSDIV" + Environment.NewLine;
                            sqlText += "  ,@DELIVEREDGOODSDIVNM" + Environment.NewLine;
                            sqlText += "  ,@FOLLOWDELIGOODSDIV" + Environment.NewLine;
                            sqlText += "  ,@FOLLOWDELIGOODSDIVNM" + Environment.NewLine;
                            sqlText += "  ,@UOERESVDSECTION" + Environment.NewLine;
                            sqlText += "  ,@UOERESVDSECTIONNM" + Environment.NewLine;
                            sqlText += "  ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@EMPLOYEENAME" + Environment.NewLine;
                            sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += "  ,@MAKERNAME" + Environment.NewLine;
                            sqlText += "  ,@GOODSNO" + Environment.NewLine;
                            sqlText += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            sqlText += "  ,@GOODSNAME" + Environment.NewLine;
                            sqlText += "  ,@WAREHOUSECODE" + Environment.NewLine;
                            sqlText += "  ,@WAREHOUSENAME" + Environment.NewLine;
                            sqlText += "  ,@WAREHOUSESHELFNO" + Environment.NewLine;
                            sqlText += "  ,@ACCEPTANORDERCNT" + Environment.NewLine;
                            sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                            sqlText += "  ,@SALESUNITCOST" + Environment.NewLine;
                            sqlText += "  ,@SUPPLIERCD" + Environment.NewLine;
                            sqlText += "  ,@SUPPLIERSNM" + Environment.NewLine;
                            sqlText += "  ,@UOEREMARK1" + Environment.NewLine;
                            sqlText += "  ,@UOEREMARK2" + Environment.NewLine;
                            sqlText += "  ,@RECEIVEDATE" + Environment.NewLine;
                            sqlText += "  ,@RECEIVETIME" + Environment.NewLine;
                            sqlText += "  ,@ANSWERMAKERCD" + Environment.NewLine;
                            sqlText += "  ,@ANSWERPARTSNO" + Environment.NewLine;
                            sqlText += "  ,@ANSWERPARTSNAME" + Environment.NewLine;
                            sqlText += "  ,@SUBSTPARTSNO" + Environment.NewLine;
                            sqlText += "  ,@UOESECTOUTGOODSCNT" + Environment.NewLine;
                            sqlText += "  ,@BOSHIPMENTCNT1" + Environment.NewLine;
                            sqlText += "  ,@BOSHIPMENTCNT2" + Environment.NewLine;
                            sqlText += "  ,@BOSHIPMENTCNT3" + Environment.NewLine;
                            sqlText += "  ,@MAKERFOLLOWCNT" + Environment.NewLine;
                            sqlText += "  ,@NONSHIPMENTCNT" + Environment.NewLine;
                            sqlText += "  ,@UOESECTSTOCKCNT" + Environment.NewLine;
                            sqlText += "  ,@BOSTOCKCOUNT1" + Environment.NewLine;
                            sqlText += "  ,@BOSTOCKCOUNT2" + Environment.NewLine;
                            sqlText += "  ,@BOSTOCKCOUNT3" + Environment.NewLine;
                            sqlText += "  ,@UOESECTIONSLIPNO" + Environment.NewLine;
                            sqlText += "  ,@BOSLIPNO1" + Environment.NewLine;
                            sqlText += "  ,@BOSLIPNO2" + Environment.NewLine;
                            sqlText += "  ,@BOSLIPNO3" + Environment.NewLine;
                            sqlText += "  ,@EOALWCCOUNT" + Environment.NewLine;
                            sqlText += "  ,@BOMANAGEMENTNO" + Environment.NewLine;
                            sqlText += "  ,@ANSWERLISTPRICE" + Environment.NewLine;
                            sqlText += "  ,@ANSWERSALESUNITCOST" + Environment.NewLine;
                            sqlText += "  ,@UOESUBSTMARK" + Environment.NewLine;
                            sqlText += "  ,@UOESTOCKMARK" + Environment.NewLine;
                            sqlText += "  ,@PARTSLAYERCD" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESHIPSECTCD1" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESHIPSECTCD2" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESHIPSECTCD3" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD1" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD2" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD3" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD4" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD5" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD6" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD7" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT1" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT2" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT3" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT4" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT5" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT6" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT7" + Environment.NewLine;
                            sqlText += "  ,@UOEDISTRIBUTIONCD" + Environment.NewLine;
                            sqlText += "  ,@UOEOTHERCD" + Environment.NewLine;
                            sqlText += "  ,@UOEHMCD" + Environment.NewLine;
                            sqlText += "  ,@BOCOUNT" + Environment.NewLine;
                            sqlText += "  ,@UOEMARKCODE" + Environment.NewLine;
                            sqlText += "  ,@SOURCESHIPMENT" + Environment.NewLine;
                            sqlText += "  ,@ITEMCODE" + Environment.NewLine;
                            sqlText += "  ,@UOECHECKCODE" + Environment.NewLine;
                            sqlText += "  ,@HEADERRORMASSAGE" + Environment.NewLine;
                            sqlText += "  ,@LINEERRORMASSAGE" + Environment.NewLine;
                            sqlText += "  ,@DATASENDCODE" + Environment.NewLine;
                            sqlText += "  ,@DATARECOVERDIV" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVSEC" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVBO1" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVBO2" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVBO3" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVMAKER" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVEO" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeOrderDtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSystemDivCd = sqlCommand.Parameters.Add("@SYSTEMDIVCD", SqlDbType.Int);
                        SqlParameter paraUOESalesOrderNo = sqlCommand.Parameters.Add("@UOESALESORDERNO", SqlDbType.Int);
                        SqlParameter paraUOESalesOrderRowNo = sqlCommand.Parameters.Add("@UOESALESORDERROWNO", SqlDbType.Int);
                        SqlParameter paraSendTerminalNo = sqlCommand.Parameters.Add("@SENDTERMINALNO", SqlDbType.Int);
                        SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraUOESupplierName = sqlCommand.Parameters.Add("@UOESUPPLIERNAME", SqlDbType.NVarChar);
                        SqlParameter paraCommAssemblyId = sqlCommand.Parameters.Add("@COMMASSEMBLYID", SqlDbType.NVarChar);
                        SqlParameter paraOnlineNo = sqlCommand.Parameters.Add("@ONLINENO", SqlDbType.Int);
                        SqlParameter paraOnlineRowNo = sqlCommand.Parameters.Add("@ONLINEROWNO", SqlDbType.Int);
                        SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@SALESDATE", SqlDbType.Int);
                        SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                        SqlParameter paraDataUpdateDateTime = sqlCommand.Parameters.Add("@DATAUPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUOEKind = sqlCommand.Parameters.Add("@UOEKIND", SqlDbType.Int);
                        SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                        SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                        SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                        SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                        SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                        SqlParameter paraStockSlipDtlNum = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUM", SqlDbType.BigInt);
                        SqlParameter paraBoCode = sqlCommand.Parameters.Add("@BOCODE", SqlDbType.NChar);
                        SqlParameter paraUOEDeliGoodsDiv = sqlCommand.Parameters.Add("@UOEDELIGOODSDIV", SqlDbType.NVarChar);
                        SqlParameter paraDeliveredGoodsDivNm = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIVNM", SqlDbType.NVarChar);
                        SqlParameter paraFollowDeliGoodsDiv = sqlCommand.Parameters.Add("@FOLLOWDELIGOODSDIV", SqlDbType.NVarChar);
                        SqlParameter paraFollowDeliGoodsDivNm = sqlCommand.Parameters.Add("@FOLLOWDELIGOODSDIVNM", SqlDbType.NVarChar);
                        SqlParameter paraUOEResvdSection = sqlCommand.Parameters.Add("@UOERESVDSECTION", SqlDbType.NChar);
                        SqlParameter paraUOEResvdSectionNm = sqlCommand.Parameters.Add("@UOERESVDSECTIONNM", SqlDbType.NVarChar);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraEmployeeName = sqlCommand.Parameters.Add("@EMPLOYEENAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                        SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                        SqlParameter paraAcceptAnOrderCnt = sqlCommand.Parameters.Add("@ACCEPTANORDERCNT", SqlDbType.Float);
                        SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                        SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                        SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                        SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.NVarChar);
                        SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.NVarChar);
                        SqlParameter paraReceiveDate = sqlCommand.Parameters.Add("@RECEIVEDATE", SqlDbType.Int);
                        SqlParameter paraReceiveTime = sqlCommand.Parameters.Add("@RECEIVETIME", SqlDbType.Int);
                        SqlParameter paraAnswerMakerCd = sqlCommand.Parameters.Add("@ANSWERMAKERCD", SqlDbType.Int);
                        SqlParameter paraAnswerPartsNo = sqlCommand.Parameters.Add("@ANSWERPARTSNO", SqlDbType.NVarChar);
                        SqlParameter paraAnswerPartsName = sqlCommand.Parameters.Add("@ANSWERPARTSNAME", SqlDbType.NVarChar);
                        SqlParameter paraSubstPartsNo = sqlCommand.Parameters.Add("@SUBSTPARTSNO", SqlDbType.NVarChar);
                        SqlParameter paraUOESectOutGoodsCnt = sqlCommand.Parameters.Add("@UOESECTOUTGOODSCNT", SqlDbType.Int);
                        SqlParameter paraBOShipmentCnt1 = sqlCommand.Parameters.Add("@BOSHIPMENTCNT1", SqlDbType.Int);
                        SqlParameter paraBOShipmentCnt2 = sqlCommand.Parameters.Add("@BOSHIPMENTCNT2", SqlDbType.Int);
                        SqlParameter paraBOShipmentCnt3 = sqlCommand.Parameters.Add("@BOSHIPMENTCNT3", SqlDbType.Int);
                        SqlParameter paraMakerFollowCnt = sqlCommand.Parameters.Add("@MAKERFOLLOWCNT", SqlDbType.Int);
                        SqlParameter paraNonShipmentCnt = sqlCommand.Parameters.Add("@NONSHIPMENTCNT", SqlDbType.Int);
                        SqlParameter paraUOESectStockCnt = sqlCommand.Parameters.Add("@UOESECTSTOCKCNT", SqlDbType.Int);
                        SqlParameter paraBOStockCount1 = sqlCommand.Parameters.Add("@BOSTOCKCOUNT1", SqlDbType.Int);
                        SqlParameter paraBOStockCount2 = sqlCommand.Parameters.Add("@BOSTOCKCOUNT2", SqlDbType.Int);
                        SqlParameter paraBOStockCount3 = sqlCommand.Parameters.Add("@BOSTOCKCOUNT3", SqlDbType.Int);
                        SqlParameter paraUOESectionSlipNo = sqlCommand.Parameters.Add("@UOESECTIONSLIPNO", SqlDbType.NVarChar);
                        SqlParameter paraBOSlipNo1 = sqlCommand.Parameters.Add("@BOSLIPNO1", SqlDbType.NVarChar);
                        SqlParameter paraBOSlipNo2 = sqlCommand.Parameters.Add("@BOSLIPNO2", SqlDbType.NVarChar);
                        SqlParameter paraBOSlipNo3 = sqlCommand.Parameters.Add("@BOSLIPNO3", SqlDbType.NVarChar);
                        SqlParameter paraEOAlwcCount = sqlCommand.Parameters.Add("@EOALWCCOUNT", SqlDbType.Int);
                        SqlParameter paraBOManagementNo = sqlCommand.Parameters.Add("@BOMANAGEMENTNO", SqlDbType.NVarChar);
                        SqlParameter paraAnswerListPrice = sqlCommand.Parameters.Add("@ANSWERLISTPRICE", SqlDbType.Float);
                        SqlParameter paraAnswerSalesUnitCost = sqlCommand.Parameters.Add("@ANSWERSALESUNITCOST", SqlDbType.Float);
                        SqlParameter paraUOESubstMark = sqlCommand.Parameters.Add("@UOESUBSTMARK", SqlDbType.NVarChar);
                        SqlParameter paraUOEStockMark = sqlCommand.Parameters.Add("@UOESTOCKMARK", SqlDbType.NVarChar);
                        SqlParameter paraPartsLayerCd = sqlCommand.Parameters.Add("@PARTSLAYERCD", SqlDbType.NVarChar);
                        SqlParameter paraMazdaUOEShipSectCd1 = sqlCommand.Parameters.Add("@MAZDAUOESHIPSECTCD1", SqlDbType.NChar);
                        SqlParameter paraMazdaUOEShipSectCd2 = sqlCommand.Parameters.Add("@MAZDAUOESHIPSECTCD2", SqlDbType.NChar);
                        SqlParameter paraMazdaUOEShipSectCd3 = sqlCommand.Parameters.Add("@MAZDAUOESHIPSECTCD3", SqlDbType.NChar);
                        SqlParameter paraMazdaUOESectCd1 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD1", SqlDbType.NChar);
                        SqlParameter paraMazdaUOESectCd2 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD2", SqlDbType.NChar);
                        SqlParameter paraMazdaUOESectCd3 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD3", SqlDbType.NChar);
                        SqlParameter paraMazdaUOESectCd4 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD4", SqlDbType.NChar);
                        SqlParameter paraMazdaUOESectCd5 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD5", SqlDbType.NChar);
                        SqlParameter paraMazdaUOESectCd6 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD6", SqlDbType.NChar);
                        SqlParameter paraMazdaUOESectCd7 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD7", SqlDbType.NChar);
                        SqlParameter paraMazdaUOEStockCnt1 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT1", SqlDbType.Int);
                        SqlParameter paraMazdaUOEStockCnt2 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT2", SqlDbType.Int);
                        SqlParameter paraMazdaUOEStockCnt3 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT3", SqlDbType.Int);
                        SqlParameter paraMazdaUOEStockCnt4 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT4", SqlDbType.Int);
                        SqlParameter paraMazdaUOEStockCnt5 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT5", SqlDbType.Int);
                        SqlParameter paraMazdaUOEStockCnt6 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT6", SqlDbType.Int);
                        SqlParameter paraMazdaUOEStockCnt7 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT7", SqlDbType.Int);
                        SqlParameter paraUOEDistributionCd = sqlCommand.Parameters.Add("@UOEDISTRIBUTIONCD", SqlDbType.NVarChar);
                        SqlParameter paraUOEOtherCd = sqlCommand.Parameters.Add("@UOEOTHERCD", SqlDbType.NVarChar);
                        SqlParameter paraUOEHMCd = sqlCommand.Parameters.Add("@UOEHMCD", SqlDbType.NVarChar);
                        SqlParameter paraBOCount = sqlCommand.Parameters.Add("@BOCOUNT", SqlDbType.Int);
                        SqlParameter paraUOEMarkCode = sqlCommand.Parameters.Add("@UOEMARKCODE", SqlDbType.NVarChar);
                        SqlParameter paraSourceShipment = sqlCommand.Parameters.Add("@SOURCESHIPMENT", SqlDbType.NVarChar);
                        SqlParameter paraItemCode = sqlCommand.Parameters.Add("@ITEMCODE", SqlDbType.NVarChar);
                        SqlParameter paraUOECheckCode = sqlCommand.Parameters.Add("@UOECHECKCODE", SqlDbType.NVarChar);
                        SqlParameter paraHeadErrorMassage = sqlCommand.Parameters.Add("@HEADERRORMASSAGE", SqlDbType.NVarChar);
                        SqlParameter paraLineErrorMassage = sqlCommand.Parameters.Add("@LINEERRORMASSAGE", SqlDbType.NVarChar);
                        SqlParameter paraDataSendCode = sqlCommand.Parameters.Add("@DATASENDCODE", SqlDbType.Int);
                        SqlParameter paraDataRecoverDiv = sqlCommand.Parameters.Add("@DATARECOVERDIV", SqlDbType.Int);
                        SqlParameter paraEnterUpdDivSec = sqlCommand.Parameters.Add("@ENTERUPDDIVSEC", SqlDbType.Int);
                        SqlParameter paraEnterUpdDivBO1 = sqlCommand.Parameters.Add("@ENTERUPDDIVBO1", SqlDbType.Int);
                        SqlParameter paraEnterUpdDivBO2 = sqlCommand.Parameters.Add("@ENTERUPDDIVBO2", SqlDbType.Int);
                        SqlParameter paraEnterUpdDivBO3 = sqlCommand.Parameters.Add("@ENTERUPDDIVBO3", SqlDbType.Int);
                        SqlParameter paraEnterUpdDivMaker = sqlCommand.Parameters.Add("@ENTERUPDDIVMAKER", SqlDbType.Int);
                        SqlParameter paraEnterUpdDivEO = sqlCommand.Parameters.Add("@ENTERUPDDIVEO", SqlDbType.Int);

                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeOrderDtlWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeOrderDtlWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(uoeOrderDtlWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.LogicalDeleteCode);
                        paraSystemDivCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SystemDivCd);
                        paraUOESalesOrderNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESalesOrderNo);
                        paraUOESalesOrderRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESalesOrderRowNo);
                        paraSendTerminalNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SendTerminalNo);
                        paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESupplierCd);
                        paraUOESupplierName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOESupplierName);
                        paraCommAssemblyId.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.CommAssemblyId);
                        paraOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineNo);
                        paraOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineRowNo);
                        paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(uoeOrderDtlWork.SalesDate);
                        paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(uoeOrderDtlWork.InputDay);
                        paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeOrderDtlWork.DataUpdateDateTime);
                        paraUOEKind.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOEKind);
                        paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SalesSlipNum);
                        paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.AcptAnOdrStatus);
                        paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.SalesSlipDtlNum);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SectionCode);
                        paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SubSectionCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.CustomerCode);
                        paraCustomerSnm.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.CustomerSnm);
                        paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.CashRegisterNo);
                        paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.CommonSeqNo);
                        paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierFormal);
                        paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierSlipNo);
                        paraStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.StockSlipDtlNum);
                        paraBoCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.BoCode);
                        paraUOEDeliGoodsDiv.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEDeliGoodsDiv);
                        paraDeliveredGoodsDivNm.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.DeliveredGoodsDivNm);
                        paraFollowDeliGoodsDiv.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.FollowDeliGoodsDiv);
                        paraFollowDeliGoodsDivNm.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.FollowDeliGoodsDivNm);
                        paraUOEResvdSection.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEResvdSection);
                        paraUOEResvdSectionNm.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEResvdSectionNm);
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EmployeeCode);
                        paraEmployeeName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EmployeeName);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MakerName);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.GoodsNo);
                        paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.GoodsNoNoneHyphen);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.GoodsName);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.WarehouseName);
                        paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.WarehouseShelfNo);
                        paraAcceptAnOrderCnt.Value = SqlDataMediator.SqlSetDouble(uoeOrderDtlWork.AcceptAnOrderCnt);
                        paraListPrice.Value = SqlDataMediator.SqlSetDouble(uoeOrderDtlWork.ListPrice);
                        paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(uoeOrderDtlWork.SalesUnitCost);
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierCd);
                        paraSupplierSnm.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SupplierSnm);
                        paraUoeRemark1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UoeRemark1);
                        paraUoeRemark2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UoeRemark2);
                        paraReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(uoeOrderDtlWork.ReceiveDate);
                        paraReceiveTime.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.ReceiveTime);
                        paraAnswerMakerCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.AnswerMakerCd);
                        paraAnswerPartsNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.AnswerPartsNo);
                        paraAnswerPartsName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.AnswerPartsName);
                        paraSubstPartsNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SubstPartsNo);
                        paraUOESectOutGoodsCnt.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESectOutGoodsCnt);
                        paraBOShipmentCnt1.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOShipmentCnt1);
                        paraBOShipmentCnt2.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOShipmentCnt2);
                        paraBOShipmentCnt3.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOShipmentCnt3);
                        paraMakerFollowCnt.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MakerFollowCnt);
                        paraNonShipmentCnt.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.NonShipmentCnt);
                        paraUOESectStockCnt.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESectStockCnt);
                        paraBOStockCount1.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOStockCount1);
                        paraBOStockCount2.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOStockCount2);
                        paraBOStockCount3.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOStockCount3);
                        paraUOESectionSlipNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOESectionSlipNo);
                        paraBOSlipNo1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.BOSlipNo1);
                        paraBOSlipNo2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.BOSlipNo2);
                        paraBOSlipNo3.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.BOSlipNo3);
                        paraEOAlwcCount.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EOAlwcCount);
                        paraBOManagementNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.BOManagementNo);
                        paraAnswerListPrice.Value = SqlDataMediator.SqlSetDouble(uoeOrderDtlWork.AnswerListPrice);
                        paraAnswerSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(uoeOrderDtlWork.AnswerSalesUnitCost);
                        paraUOESubstMark.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOESubstMark);
                        paraUOEStockMark.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEStockMark);
                        paraPartsLayerCd.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.PartsLayerCd);
                        paraMazdaUOEShipSectCd1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOEShipSectCd1);
                        paraMazdaUOEShipSectCd2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOEShipSectCd2);
                        paraMazdaUOEShipSectCd3.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOEShipSectCd3);
                        paraMazdaUOESectCd1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd1);
                        paraMazdaUOESectCd2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd2);
                        paraMazdaUOESectCd3.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd3);
                        paraMazdaUOESectCd4.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd4);
                        paraMazdaUOESectCd5.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd5);
                        paraMazdaUOESectCd6.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd6);
                        paraMazdaUOESectCd7.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd7);
                        paraMazdaUOEStockCnt1.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt1);
                        paraMazdaUOEStockCnt2.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt2);
                        paraMazdaUOEStockCnt3.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt3);
                        paraMazdaUOEStockCnt4.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt4);
                        paraMazdaUOEStockCnt5.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt5);
                        paraMazdaUOEStockCnt6.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt6);
                        paraMazdaUOEStockCnt7.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt7);
                        paraUOEDistributionCd.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEDistributionCd);
                        paraUOEOtherCd.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEOtherCd);
                        paraUOEHMCd.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEHMCd);
                        paraBOCount.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOCount);
                        paraUOEMarkCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEMarkCode);
                        paraSourceShipment.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SourceShipment);
                        paraItemCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.ItemCode);
                        paraUOECheckCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOECheckCode);
                        paraHeadErrorMassage.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.HeadErrorMassage);
                        paraLineErrorMassage.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.LineErrorMassage);
                        paraDataSendCode.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.DataSendCode);
                        paraDataRecoverDiv.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.DataRecoverDiv);
                        paraEnterUpdDivSec.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivSec);
                        paraEnterUpdDivBO1.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivBO1);
                        paraEnterUpdDivBO2.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivBO2);
                        paraEnterUpdDivBO3.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivBO3);
                        paraEnterUpdDivMaker.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivMaker);
                        paraEnterUpdDivEO.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivEO);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeOrderDtlWork);
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

            uoeOrderDtlList = al;

            return status;
        }

        # endregion

        #region Write(�����ꗗ�p)
        /// <summary>
        /// �������̃f�[�^���폜���čč쐬���܂�(�����ꗗ�p)
        /// </summary>
        /// <param name="uoeOrderDtlList">�ǉ��E�X�V����UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlList �Ɋi�[����Ă���UOE�����f�[�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int WriteOrderList(ref ArrayList uoeOrderDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteDelInsProc(ref uoeOrderDtlList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����f�[�^���폜���čč쐬���܂�
        /// </summary>
        /// <param name="uoeOrderDtlList">�ǉ��E�X�V����UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlList �Ɋi�[����Ă���UOE�����f�[�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        private int WriteDelInsProc(ref ArrayList uoeOrderDtlList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeOrderDtlList != null)
                {
                    if (uoeOrderDtlList.Count > 0)
                    {
                        UOEOrderDtlWork uoeOrderDtlWork = uoeOrderDtlList[0] as UOEOrderDtlWork;
                        string sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND UOEKINDRF=@FINDUOEKIND" + Environment.NewLine;
                        sqlText += "  AND SYSTEMDIVCDRF=@FINDSYSTEMDIVCD" + Environment.NewLine;
                        sqlText += "  AND DATASENDCODERF=@FINDDATASENDCODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOEKind = sqlCommand.Parameters.Add("@FINDUOEKIND", SqlDbType.Int);
                        SqlParameter findParaSystemDivCd = sqlCommand.Parameters.Add("@FINDSYSTEMDIVCD", SqlDbType.Int);
                        SqlParameter findParaDataSendCode = sqlCommand.Parameters.Add("@FINDDATASENDCODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                        findParaUOEKind.Value = 0;  //0:UOE
                        findParaSystemDivCd.Value = 3;  //3:�ꊇ������
                        findParaDataSendCode.Value = 0;  //0:��������

                        sqlCommand.ExecuteNonQuery();

                        for (int i = 0; i < uoeOrderDtlList.Count; i++)
                        {
                            uoeOrderDtlWork = uoeOrderDtlList[i] as UOEOrderDtlWork;

                            # region [INSERT��]
                            sqlText = string.Empty;

                            sqlText += "INSERT INTO UOEORDERDTLRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "  ,SYSTEMDIVCDRF" + Environment.NewLine;
                            sqlText += "  ,UOESALESORDERNORF" + Environment.NewLine;
                            sqlText += "  ,UOESALESORDERROWNORF" + Environment.NewLine;
                            sqlText += "  ,SENDTERMINALNORF" + Environment.NewLine;
                            sqlText += "  ,UOESUPPLIERCDRF" + Environment.NewLine;
                            sqlText += "  ,UOESUPPLIERNAMERF" + Environment.NewLine;
                            sqlText += "  ,COMMASSEMBLYIDRF" + Environment.NewLine;
                            sqlText += "  ,ONLINENORF" + Environment.NewLine;
                            sqlText += "  ,ONLINEROWNORF" + Environment.NewLine;
                            sqlText += "  ,SALESDATERF" + Environment.NewLine;
                            sqlText += "  ,INPUTDAYRF" + Environment.NewLine;
                            sqlText += "  ,DATAUPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UOEKINDRF" + Environment.NewLine;
                            sqlText += "  ,SALESSLIPNUMRF" + Environment.NewLine;
                            sqlText += "  ,ACPTANODRSTATUSRF" + Environment.NewLine;
                            sqlText += "  ,SALESSLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,SUBSECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERSNMRF" + Environment.NewLine;
                            sqlText += "  ,CASHREGISTERNORF" + Environment.NewLine;
                            sqlText += "  ,COMMONSEQNORF" + Environment.NewLine;
                            sqlText += "  ,SUPPLIERFORMALRF" + Environment.NewLine;
                            sqlText += "  ,SUPPLIERSLIPNORF" + Environment.NewLine;
                            sqlText += "  ,STOCKSLIPDTLNUMRF" + Environment.NewLine;
                            sqlText += "  ,BOCODERF" + Environment.NewLine;
                            sqlText += "  ,UOEDELIGOODSDIVRF" + Environment.NewLine;
                            sqlText += "  ,DELIVEREDGOODSDIVNMRF" + Environment.NewLine;
                            sqlText += "  ,FOLLOWDELIGOODSDIVRF" + Environment.NewLine;
                            sqlText += "  ,FOLLOWDELIGOODSDIVNMRF" + Environment.NewLine;
                            sqlText += "  ,UOERESVDSECTIONRF" + Environment.NewLine;
                            sqlText += "  ,UOERESVDSECTIONNMRF" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,EMPLOYEENAMERF" + Environment.NewLine;
                            sqlText += "  ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlText += "  ,MAKERNAMERF" + Environment.NewLine;
                            sqlText += "  ,GOODSNORF" + Environment.NewLine;
                            sqlText += "  ,GOODSNONONEHYPHENRF" + Environment.NewLine;
                            sqlText += "  ,GOODSNAMERF" + Environment.NewLine;
                            sqlText += "  ,WAREHOUSECODERF" + Environment.NewLine;
                            sqlText += "  ,WAREHOUSENAMERF" + Environment.NewLine;
                            sqlText += "  ,WAREHOUSESHELFNORF" + Environment.NewLine;
                            sqlText += "  ,ACCEPTANORDERCNTRF" + Environment.NewLine;
                            sqlText += "  ,LISTPRICERF" + Environment.NewLine;
                            sqlText += "  ,SALESUNITCOSTRF" + Environment.NewLine;
                            sqlText += "  ,SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += "  ,SUPPLIERSNMRF" + Environment.NewLine;
                            sqlText += "  ,UOEREMARK1RF" + Environment.NewLine;
                            sqlText += "  ,UOEREMARK2RF" + Environment.NewLine;
                            sqlText += "  ,RECEIVEDATERF" + Environment.NewLine;
                            sqlText += "  ,RECEIVETIMERF" + Environment.NewLine;
                            sqlText += "  ,ANSWERMAKERCDRF" + Environment.NewLine;
                            sqlText += "  ,ANSWERPARTSNORF" + Environment.NewLine;
                            sqlText += "  ,ANSWERPARTSNAMERF" + Environment.NewLine;
                            sqlText += "  ,SUBSTPARTSNORF" + Environment.NewLine;
                            sqlText += "  ,UOESECTOUTGOODSCNTRF" + Environment.NewLine;
                            sqlText += "  ,BOSHIPMENTCNT1RF" + Environment.NewLine;
                            sqlText += "  ,BOSHIPMENTCNT2RF" + Environment.NewLine;
                            sqlText += "  ,BOSHIPMENTCNT3RF" + Environment.NewLine;
                            sqlText += "  ,MAKERFOLLOWCNTRF" + Environment.NewLine;
                            sqlText += "  ,NONSHIPMENTCNTRF" + Environment.NewLine;
                            sqlText += "  ,UOESECTSTOCKCNTRF" + Environment.NewLine;
                            sqlText += "  ,BOSTOCKCOUNT1RF" + Environment.NewLine;
                            sqlText += "  ,BOSTOCKCOUNT2RF" + Environment.NewLine;
                            sqlText += "  ,BOSTOCKCOUNT3RF" + Environment.NewLine;
                            sqlText += "  ,UOESECTIONSLIPNORF" + Environment.NewLine;
                            sqlText += "  ,BOSLIPNO1RF" + Environment.NewLine;
                            sqlText += "  ,BOSLIPNO2RF" + Environment.NewLine;
                            sqlText += "  ,BOSLIPNO3RF" + Environment.NewLine;
                            sqlText += "  ,EOALWCCOUNTRF" + Environment.NewLine;
                            sqlText += "  ,BOMANAGEMENTNORF" + Environment.NewLine;
                            sqlText += "  ,ANSWERLISTPRICERF" + Environment.NewLine;
                            sqlText += "  ,ANSWERSALESUNITCOSTRF" + Environment.NewLine;
                            sqlText += "  ,UOESUBSTMARKRF" + Environment.NewLine;
                            sqlText += "  ,UOESTOCKMARKRF" + Environment.NewLine;
                            sqlText += "  ,PARTSLAYERCDRF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESHIPSECTCD1RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESHIPSECTCD2RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESHIPSECTCD3RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD1RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD2RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD3RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD4RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD5RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD6RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESECTCD7RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT1RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT2RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT3RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT4RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT5RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT6RF" + Environment.NewLine;
                            sqlText += "  ,MAZDAUOESTOCKCNT7RF" + Environment.NewLine;
                            sqlText += "  ,UOEDISTRIBUTIONCDRF" + Environment.NewLine;
                            sqlText += "  ,UOEOTHERCDRF" + Environment.NewLine;
                            sqlText += "  ,UOEHMCDRF" + Environment.NewLine;
                            sqlText += "  ,BOCOUNTRF" + Environment.NewLine;
                            sqlText += "  ,UOEMARKCODERF" + Environment.NewLine;
                            sqlText += "  ,SOURCESHIPMENTRF" + Environment.NewLine;
                            sqlText += "  ,ITEMCODERF" + Environment.NewLine;
                            sqlText += "  ,UOECHECKCODERF" + Environment.NewLine;
                            sqlText += "  ,HEADERRORMASSAGERF" + Environment.NewLine;
                            sqlText += "  ,LINEERRORMASSAGERF" + Environment.NewLine;
                            sqlText += "  ,DATASENDCODERF" + Environment.NewLine;
                            sqlText += "  ,DATARECOVERDIVRF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVSECRF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVBO1RF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVBO2RF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVBO3RF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVMAKERRF" + Environment.NewLine;
                            sqlText += "  ,ENTERUPDDIVEORF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,@SYSTEMDIVCD" + Environment.NewLine;
                            sqlText += "  ,@UOESALESORDERNO" + Environment.NewLine;
                            sqlText += "  ,@UOESALESORDERROWNO" + Environment.NewLine;
                            sqlText += "  ,@SENDTERMINALNO" + Environment.NewLine;
                            sqlText += "  ,@UOESUPPLIERCD" + Environment.NewLine;
                            sqlText += "  ,@UOESUPPLIERNAME" + Environment.NewLine;
                            sqlText += "  ,@COMMASSEMBLYID" + Environment.NewLine;
                            sqlText += "  ,@ONLINENO" + Environment.NewLine;
                            sqlText += "  ,@ONLINEROWNO" + Environment.NewLine;
                            sqlText += "  ,@SALESDATE" + Environment.NewLine;
                            sqlText += "  ,@INPUTDAY" + Environment.NewLine;
                            sqlText += "  ,@DATAUPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UOEKIND" + Environment.NewLine;
                            sqlText += "  ,@SALESSLIPNUM" + Environment.NewLine;
                            sqlText += "  ,@ACPTANODRSTATUS" + Environment.NewLine;
                            sqlText += "  ,@SALESSLIPDTLNUM" + Environment.NewLine;
                            sqlText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@SUBSECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  ,@CUSTOMERSNM" + Environment.NewLine;
                            sqlText += "  ,@CASHREGISTERNO" + Environment.NewLine;
                            sqlText += "  ,@COMMONSEQNO" + Environment.NewLine;
                            sqlText += "  ,@SUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  ,@SUPPLIERSLIPNO" + Environment.NewLine;
                            sqlText += "  ,@STOCKSLIPDTLNUM" + Environment.NewLine;
                            sqlText += "  ,@BOCODE" + Environment.NewLine;
                            sqlText += "  ,@UOEDELIGOODSDIV" + Environment.NewLine;
                            sqlText += "  ,@DELIVEREDGOODSDIVNM" + Environment.NewLine;
                            sqlText += "  ,@FOLLOWDELIGOODSDIV" + Environment.NewLine;
                            sqlText += "  ,@FOLLOWDELIGOODSDIVNM" + Environment.NewLine;
                            sqlText += "  ,@UOERESVDSECTION" + Environment.NewLine;
                            sqlText += "  ,@UOERESVDSECTIONNM" + Environment.NewLine;
                            sqlText += "  ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@EMPLOYEENAME" + Environment.NewLine;
                            sqlText += "  ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += "  ,@MAKERNAME" + Environment.NewLine;
                            sqlText += "  ,@GOODSNO" + Environment.NewLine;
                            sqlText += "  ,@GOODSNONONEHYPHEN" + Environment.NewLine;
                            sqlText += "  ,@GOODSNAME" + Environment.NewLine;
                            sqlText += "  ,@WAREHOUSECODE" + Environment.NewLine;
                            sqlText += "  ,@WAREHOUSENAME" + Environment.NewLine;
                            sqlText += "  ,@WAREHOUSESHELFNO" + Environment.NewLine;
                            sqlText += "  ,@ACCEPTANORDERCNT" + Environment.NewLine;
                            sqlText += "  ,@LISTPRICE" + Environment.NewLine;
                            sqlText += "  ,@SALESUNITCOST" + Environment.NewLine;
                            sqlText += "  ,@SUPPLIERCD" + Environment.NewLine;
                            sqlText += "  ,@SUPPLIERSNM" + Environment.NewLine;
                            sqlText += "  ,@UOEREMARK1" + Environment.NewLine;
                            sqlText += "  ,@UOEREMARK2" + Environment.NewLine;
                            sqlText += "  ,@RECEIVEDATE" + Environment.NewLine;
                            sqlText += "  ,@RECEIVETIME" + Environment.NewLine;
                            sqlText += "  ,@ANSWERMAKERCD" + Environment.NewLine;
                            sqlText += "  ,@ANSWERPARTSNO" + Environment.NewLine;
                            sqlText += "  ,@ANSWERPARTSNAME" + Environment.NewLine;
                            sqlText += "  ,@SUBSTPARTSNO" + Environment.NewLine;
                            sqlText += "  ,@UOESECTOUTGOODSCNT" + Environment.NewLine;
                            sqlText += "  ,@BOSHIPMENTCNT1" + Environment.NewLine;
                            sqlText += "  ,@BOSHIPMENTCNT2" + Environment.NewLine;
                            sqlText += "  ,@BOSHIPMENTCNT3" + Environment.NewLine;
                            sqlText += "  ,@MAKERFOLLOWCNT" + Environment.NewLine;
                            sqlText += "  ,@NONSHIPMENTCNT" + Environment.NewLine;
                            sqlText += "  ,@UOESECTSTOCKCNT" + Environment.NewLine;
                            sqlText += "  ,@BOSTOCKCOUNT1" + Environment.NewLine;
                            sqlText += "  ,@BOSTOCKCOUNT2" + Environment.NewLine;
                            sqlText += "  ,@BOSTOCKCOUNT3" + Environment.NewLine;
                            sqlText += "  ,@UOESECTIONSLIPNO" + Environment.NewLine;
                            sqlText += "  ,@BOSLIPNO1" + Environment.NewLine;
                            sqlText += "  ,@BOSLIPNO2" + Environment.NewLine;
                            sqlText += "  ,@BOSLIPNO3" + Environment.NewLine;
                            sqlText += "  ,@EOALWCCOUNT" + Environment.NewLine;
                            sqlText += "  ,@BOMANAGEMENTNO" + Environment.NewLine;
                            sqlText += "  ,@ANSWERLISTPRICE" + Environment.NewLine;
                            sqlText += "  ,@ANSWERSALESUNITCOST" + Environment.NewLine;
                            sqlText += "  ,@UOESUBSTMARK" + Environment.NewLine;
                            sqlText += "  ,@UOESTOCKMARK" + Environment.NewLine;
                            sqlText += "  ,@PARTSLAYERCD" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESHIPSECTCD1" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESHIPSECTCD2" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESHIPSECTCD3" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD1" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD2" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD3" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD4" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD5" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD6" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESECTCD7" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT1" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT2" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT3" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT4" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT5" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT6" + Environment.NewLine;
                            sqlText += "  ,@MAZDAUOESTOCKCNT7" + Environment.NewLine;
                            sqlText += "  ,@UOEDISTRIBUTIONCD" + Environment.NewLine;
                            sqlText += "  ,@UOEOTHERCD" + Environment.NewLine;
                            sqlText += "  ,@UOEHMCD" + Environment.NewLine;
                            sqlText += "  ,@BOCOUNT" + Environment.NewLine;
                            sqlText += "  ,@UOEMARKCODE" + Environment.NewLine;
                            sqlText += "  ,@SOURCESHIPMENT" + Environment.NewLine;
                            sqlText += "  ,@ITEMCODE" + Environment.NewLine;
                            sqlText += "  ,@UOECHECKCODE" + Environment.NewLine;
                            sqlText += "  ,@HEADERRORMASSAGE" + Environment.NewLine;
                            sqlText += "  ,@LINEERRORMASSAGE" + Environment.NewLine;
                            sqlText += "  ,@DATASENDCODE" + Environment.NewLine;
                            sqlText += "  ,@DATARECOVERDIV" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVSEC" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVBO1" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVBO2" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVBO3" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVMAKER" + Environment.NewLine;
                            sqlText += "  ,@ENTERUPDDIVEO" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeOrderDtlWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);

                            # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                            //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                            SqlParameter paraSystemDivCd = sqlCommand.Parameters.Add("@SYSTEMDIVCD", SqlDbType.Int);
                            SqlParameter paraUOESalesOrderNo = sqlCommand.Parameters.Add("@UOESALESORDERNO", SqlDbType.Int);
                            SqlParameter paraUOESalesOrderRowNo = sqlCommand.Parameters.Add("@UOESALESORDERROWNO", SqlDbType.Int);
                            SqlParameter paraSendTerminalNo = sqlCommand.Parameters.Add("@SENDTERMINALNO", SqlDbType.Int);
                            SqlParameter paraUOESupplierCd = sqlCommand.Parameters.Add("@UOESUPPLIERCD", SqlDbType.Int);
                            SqlParameter paraUOESupplierName = sqlCommand.Parameters.Add("@UOESUPPLIERNAME", SqlDbType.NVarChar);
                            SqlParameter paraCommAssemblyId = sqlCommand.Parameters.Add("@COMMASSEMBLYID", SqlDbType.NVarChar);
                            SqlParameter paraOnlineNo = sqlCommand.Parameters.Add("@ONLINENO", SqlDbType.Int);
                            SqlParameter paraOnlineRowNo = sqlCommand.Parameters.Add("@ONLINEROWNO", SqlDbType.Int);
                            SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@SALESDATE", SqlDbType.Int);
                            SqlParameter paraInputDay = sqlCommand.Parameters.Add("@INPUTDAY", SqlDbType.Int);
                            SqlParameter paraDataUpdateDateTime = sqlCommand.Parameters.Add("@DATAUPDATEDATETIME", SqlDbType.BigInt);
                            SqlParameter paraUOEKind = sqlCommand.Parameters.Add("@UOEKIND", SqlDbType.Int);
                            SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                            SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                            SqlParameter paraSalesSlipDtlNum = sqlCommand.Parameters.Add("@SALESSLIPDTLNUM", SqlDbType.BigInt);
                            SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                            SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                            SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                            SqlParameter paraCashRegisterNo = sqlCommand.Parameters.Add("@CASHREGISTERNO", SqlDbType.Int);
                            SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                            SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                            SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                            SqlParameter paraStockSlipDtlNum = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUM", SqlDbType.BigInt);
                            SqlParameter paraBoCode = sqlCommand.Parameters.Add("@BOCODE", SqlDbType.NChar);
                            SqlParameter paraUOEDeliGoodsDiv = sqlCommand.Parameters.Add("@UOEDELIGOODSDIV", SqlDbType.NVarChar);
                            SqlParameter paraDeliveredGoodsDivNm = sqlCommand.Parameters.Add("@DELIVEREDGOODSDIVNM", SqlDbType.NVarChar);
                            SqlParameter paraFollowDeliGoodsDiv = sqlCommand.Parameters.Add("@FOLLOWDELIGOODSDIV", SqlDbType.NVarChar);
                            SqlParameter paraFollowDeliGoodsDivNm = sqlCommand.Parameters.Add("@FOLLOWDELIGOODSDIVNM", SqlDbType.NVarChar);
                            SqlParameter paraUOEResvdSection = sqlCommand.Parameters.Add("@UOERESVDSECTION", SqlDbType.NChar);
                            SqlParameter paraUOEResvdSectionNm = sqlCommand.Parameters.Add("@UOERESVDSECTIONNM", SqlDbType.NVarChar);
                            SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                            SqlParameter paraEmployeeName = sqlCommand.Parameters.Add("@EMPLOYEENAME", SqlDbType.NVarChar);
                            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                            SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                            SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                            SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                            SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                            SqlParameter paraAcceptAnOrderCnt = sqlCommand.Parameters.Add("@ACCEPTANORDERCNT", SqlDbType.Float);
                            SqlParameter paraListPrice = sqlCommand.Parameters.Add("@LISTPRICE", SqlDbType.Float);
                            SqlParameter paraSalesUnitCost = sqlCommand.Parameters.Add("@SALESUNITCOST", SqlDbType.Float);
                            SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                            SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                            SqlParameter paraUoeRemark1 = sqlCommand.Parameters.Add("@UOEREMARK1", SqlDbType.NVarChar);
                            SqlParameter paraUoeRemark2 = sqlCommand.Parameters.Add("@UOEREMARK2", SqlDbType.NVarChar);
                            SqlParameter paraReceiveDate = sqlCommand.Parameters.Add("@RECEIVEDATE", SqlDbType.Int);
                            SqlParameter paraReceiveTime = sqlCommand.Parameters.Add("@RECEIVETIME", SqlDbType.Int);
                            SqlParameter paraAnswerMakerCd = sqlCommand.Parameters.Add("@ANSWERMAKERCD", SqlDbType.Int);
                            SqlParameter paraAnswerPartsNo = sqlCommand.Parameters.Add("@ANSWERPARTSNO", SqlDbType.NVarChar);
                            SqlParameter paraAnswerPartsName = sqlCommand.Parameters.Add("@ANSWERPARTSNAME", SqlDbType.NVarChar);
                            SqlParameter paraSubstPartsNo = sqlCommand.Parameters.Add("@SUBSTPARTSNO", SqlDbType.NVarChar);
                            SqlParameter paraUOESectOutGoodsCnt = sqlCommand.Parameters.Add("@UOESECTOUTGOODSCNT", SqlDbType.Int);
                            SqlParameter paraBOShipmentCnt1 = sqlCommand.Parameters.Add("@BOSHIPMENTCNT1", SqlDbType.Int);
                            SqlParameter paraBOShipmentCnt2 = sqlCommand.Parameters.Add("@BOSHIPMENTCNT2", SqlDbType.Int);
                            SqlParameter paraBOShipmentCnt3 = sqlCommand.Parameters.Add("@BOSHIPMENTCNT3", SqlDbType.Int);
                            SqlParameter paraMakerFollowCnt = sqlCommand.Parameters.Add("@MAKERFOLLOWCNT", SqlDbType.Int);
                            SqlParameter paraNonShipmentCnt = sqlCommand.Parameters.Add("@NONSHIPMENTCNT", SqlDbType.Int);
                            SqlParameter paraUOESectStockCnt = sqlCommand.Parameters.Add("@UOESECTSTOCKCNT", SqlDbType.Int);
                            SqlParameter paraBOStockCount1 = sqlCommand.Parameters.Add("@BOSTOCKCOUNT1", SqlDbType.Int);
                            SqlParameter paraBOStockCount2 = sqlCommand.Parameters.Add("@BOSTOCKCOUNT2", SqlDbType.Int);
                            SqlParameter paraBOStockCount3 = sqlCommand.Parameters.Add("@BOSTOCKCOUNT3", SqlDbType.Int);
                            SqlParameter paraUOESectionSlipNo = sqlCommand.Parameters.Add("@UOESECTIONSLIPNO", SqlDbType.NVarChar);
                            SqlParameter paraBOSlipNo1 = sqlCommand.Parameters.Add("@BOSLIPNO1", SqlDbType.NVarChar);
                            SqlParameter paraBOSlipNo2 = sqlCommand.Parameters.Add("@BOSLIPNO2", SqlDbType.NVarChar);
                            SqlParameter paraBOSlipNo3 = sqlCommand.Parameters.Add("@BOSLIPNO3", SqlDbType.NVarChar);
                            SqlParameter paraEOAlwcCount = sqlCommand.Parameters.Add("@EOALWCCOUNT", SqlDbType.Int);
                            SqlParameter paraBOManagementNo = sqlCommand.Parameters.Add("@BOMANAGEMENTNO", SqlDbType.NVarChar);
                            SqlParameter paraAnswerListPrice = sqlCommand.Parameters.Add("@ANSWERLISTPRICE", SqlDbType.Float);
                            SqlParameter paraAnswerSalesUnitCost = sqlCommand.Parameters.Add("@ANSWERSALESUNITCOST", SqlDbType.Float);
                            SqlParameter paraUOESubstMark = sqlCommand.Parameters.Add("@UOESUBSTMARK", SqlDbType.NVarChar);
                            SqlParameter paraUOEStockMark = sqlCommand.Parameters.Add("@UOESTOCKMARK", SqlDbType.NVarChar);
                            SqlParameter paraPartsLayerCd = sqlCommand.Parameters.Add("@PARTSLAYERCD", SqlDbType.NVarChar);
                            SqlParameter paraMazdaUOEShipSectCd1 = sqlCommand.Parameters.Add("@MAZDAUOESHIPSECTCD1", SqlDbType.NChar);
                            SqlParameter paraMazdaUOEShipSectCd2 = sqlCommand.Parameters.Add("@MAZDAUOESHIPSECTCD2", SqlDbType.NChar);
                            SqlParameter paraMazdaUOEShipSectCd3 = sqlCommand.Parameters.Add("@MAZDAUOESHIPSECTCD3", SqlDbType.NChar);
                            SqlParameter paraMazdaUOESectCd1 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD1", SqlDbType.NChar);
                            SqlParameter paraMazdaUOESectCd2 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD2", SqlDbType.NChar);
                            SqlParameter paraMazdaUOESectCd3 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD3", SqlDbType.NChar);
                            SqlParameter paraMazdaUOESectCd4 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD4", SqlDbType.NChar);
                            SqlParameter paraMazdaUOESectCd5 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD5", SqlDbType.NChar);
                            SqlParameter paraMazdaUOESectCd6 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD6", SqlDbType.NChar);
                            SqlParameter paraMazdaUOESectCd7 = sqlCommand.Parameters.Add("@MAZDAUOESECTCD7", SqlDbType.NChar);
                            SqlParameter paraMazdaUOEStockCnt1 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT1", SqlDbType.Int);
                            SqlParameter paraMazdaUOEStockCnt2 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT2", SqlDbType.Int);
                            SqlParameter paraMazdaUOEStockCnt3 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT3", SqlDbType.Int);
                            SqlParameter paraMazdaUOEStockCnt4 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT4", SqlDbType.Int);
                            SqlParameter paraMazdaUOEStockCnt5 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT5", SqlDbType.Int);
                            SqlParameter paraMazdaUOEStockCnt6 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT6", SqlDbType.Int);
                            SqlParameter paraMazdaUOEStockCnt7 = sqlCommand.Parameters.Add("@MAZDAUOESTOCKCNT7", SqlDbType.Int);
                            SqlParameter paraUOEDistributionCd = sqlCommand.Parameters.Add("@UOEDISTRIBUTIONCD", SqlDbType.NVarChar);
                            SqlParameter paraUOEOtherCd = sqlCommand.Parameters.Add("@UOEOTHERCD", SqlDbType.NVarChar);
                            SqlParameter paraUOEHMCd = sqlCommand.Parameters.Add("@UOEHMCD", SqlDbType.NVarChar);
                            SqlParameter paraBOCount = sqlCommand.Parameters.Add("@BOCOUNT", SqlDbType.Int);
                            SqlParameter paraUOEMarkCode = sqlCommand.Parameters.Add("@UOEMARKCODE", SqlDbType.NVarChar);
                            SqlParameter paraSourceShipment = sqlCommand.Parameters.Add("@SOURCESHIPMENT", SqlDbType.NVarChar);
                            SqlParameter paraItemCode = sqlCommand.Parameters.Add("@ITEMCODE", SqlDbType.NVarChar);
                            SqlParameter paraUOECheckCode = sqlCommand.Parameters.Add("@UOECHECKCODE", SqlDbType.NVarChar);
                            SqlParameter paraHeadErrorMassage = sqlCommand.Parameters.Add("@HEADERRORMASSAGE", SqlDbType.NVarChar);
                            SqlParameter paraLineErrorMassage = sqlCommand.Parameters.Add("@LINEERRORMASSAGE", SqlDbType.NVarChar);
                            SqlParameter paraDataSendCode = sqlCommand.Parameters.Add("@DATASENDCODE", SqlDbType.Int);
                            SqlParameter paraDataRecoverDiv = sqlCommand.Parameters.Add("@DATARECOVERDIV", SqlDbType.Int);
                            SqlParameter paraEnterUpdDivSec = sqlCommand.Parameters.Add("@ENTERUPDDIVSEC", SqlDbType.Int);
                            SqlParameter paraEnterUpdDivBO1 = sqlCommand.Parameters.Add("@ENTERUPDDIVBO1", SqlDbType.Int);
                            SqlParameter paraEnterUpdDivBO2 = sqlCommand.Parameters.Add("@ENTERUPDDIVBO2", SqlDbType.Int);
                            SqlParameter paraEnterUpdDivBO3 = sqlCommand.Parameters.Add("@ENTERUPDDIVBO3", SqlDbType.Int);
                            SqlParameter paraEnterUpdDivMaker = sqlCommand.Parameters.Add("@ENTERUPDDIVMAKER", SqlDbType.Int);
                            SqlParameter paraEnterUpdDivEO = sqlCommand.Parameters.Add("@ENTERUPDDIVEO", SqlDbType.Int);

                            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeOrderDtlWork.CreateDateTime);
                            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeOrderDtlWork.UpdateDateTime);
                            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(uoeOrderDtlWork.FileHeaderGuid);
                            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdEmployeeCode);
                            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdAssemblyId1);
                            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdAssemblyId2);
                            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.LogicalDeleteCode);
                            paraSystemDivCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SystemDivCd);
                            paraUOESalesOrderNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESalesOrderNo);
                            paraUOESalesOrderRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESalesOrderRowNo);
                            paraSendTerminalNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SendTerminalNo);
                            paraUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESupplierCd);
                            paraUOESupplierName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOESupplierName);
                            paraCommAssemblyId.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.CommAssemblyId);
                            paraOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineNo);
                            paraOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineRowNo);
                            paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(uoeOrderDtlWork.SalesDate);
                            paraInputDay.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(uoeOrderDtlWork.InputDay);
                            paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeOrderDtlWork.DataUpdateDateTime);
                            paraUOEKind.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOEKind);
                            paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SalesSlipNum);
                            paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.AcptAnOdrStatus);
                            paraSalesSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.SalesSlipDtlNum);
                            paraSectionCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SectionCode);
                            paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SubSectionCode);
                            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.CustomerCode);
                            paraCustomerSnm.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.CustomerSnm);
                            paraCashRegisterNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.CashRegisterNo);
                            paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.CommonSeqNo);
                            paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierFormal);
                            paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierSlipNo);
                            paraStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.StockSlipDtlNum);
                            paraBoCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.BoCode);
                            paraUOEDeliGoodsDiv.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEDeliGoodsDiv);
                            paraDeliveredGoodsDivNm.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.DeliveredGoodsDivNm);
                            paraFollowDeliGoodsDiv.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.FollowDeliGoodsDiv);
                            paraFollowDeliGoodsDivNm.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.FollowDeliGoodsDivNm);
                            paraUOEResvdSection.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEResvdSection);
                            paraUOEResvdSectionNm.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEResvdSectionNm);
                            paraEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EmployeeCode);
                            paraEmployeeName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EmployeeName);
                            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.GoodsMakerCd);
                            paraMakerName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MakerName);
                            paraGoodsNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.GoodsNo);
                            paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.GoodsNoNoneHyphen);
                            paraGoodsName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.GoodsName);
                            paraWarehouseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.WarehouseCode);
                            paraWarehouseName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.WarehouseName);
                            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.WarehouseShelfNo);
                            paraAcceptAnOrderCnt.Value = SqlDataMediator.SqlSetDouble(uoeOrderDtlWork.AcceptAnOrderCnt);
                            paraListPrice.Value = SqlDataMediator.SqlSetDouble(uoeOrderDtlWork.ListPrice);
                            paraSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(uoeOrderDtlWork.SalesUnitCost);
                            paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierCd);
                            paraSupplierSnm.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SupplierSnm);
                            paraUoeRemark1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UoeRemark1);
                            paraUoeRemark2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UoeRemark2);
                            paraReceiveDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(uoeOrderDtlWork.ReceiveDate);
                            paraReceiveTime.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.ReceiveTime);
                            paraAnswerMakerCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.AnswerMakerCd);
                            paraAnswerPartsNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.AnswerPartsNo);
                            paraAnswerPartsName.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.AnswerPartsName);
                            paraSubstPartsNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SubstPartsNo);
                            paraUOESectOutGoodsCnt.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESectOutGoodsCnt);
                            paraBOShipmentCnt1.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOShipmentCnt1);
                            paraBOShipmentCnt2.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOShipmentCnt2);
                            paraBOShipmentCnt3.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOShipmentCnt3);
                            paraMakerFollowCnt.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MakerFollowCnt);
                            paraNonShipmentCnt.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.NonShipmentCnt);
                            paraUOESectStockCnt.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESectStockCnt);
                            paraBOStockCount1.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOStockCount1);
                            paraBOStockCount2.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOStockCount2);
                            paraBOStockCount3.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOStockCount3);
                            paraUOESectionSlipNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOESectionSlipNo);
                            paraBOSlipNo1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.BOSlipNo1);
                            paraBOSlipNo2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.BOSlipNo2);
                            paraBOSlipNo3.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.BOSlipNo3);
                            paraEOAlwcCount.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EOAlwcCount);
                            paraBOManagementNo.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.BOManagementNo);
                            paraAnswerListPrice.Value = SqlDataMediator.SqlSetDouble(uoeOrderDtlWork.AnswerListPrice);
                            paraAnswerSalesUnitCost.Value = SqlDataMediator.SqlSetDouble(uoeOrderDtlWork.AnswerSalesUnitCost);
                            paraUOESubstMark.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOESubstMark);
                            paraUOEStockMark.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEStockMark);
                            paraPartsLayerCd.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.PartsLayerCd);
                            paraMazdaUOEShipSectCd1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOEShipSectCd1);
                            paraMazdaUOEShipSectCd2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOEShipSectCd2);
                            paraMazdaUOEShipSectCd3.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOEShipSectCd3);
                            paraMazdaUOESectCd1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd1);
                            paraMazdaUOESectCd2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd2);
                            paraMazdaUOESectCd3.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd3);
                            paraMazdaUOESectCd4.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd4);
                            paraMazdaUOESectCd5.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd5);
                            paraMazdaUOESectCd6.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd6);
                            paraMazdaUOESectCd7.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.MazdaUOESectCd7);
                            paraMazdaUOEStockCnt1.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt1);
                            paraMazdaUOEStockCnt2.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt2);
                            paraMazdaUOEStockCnt3.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt3);
                            paraMazdaUOEStockCnt4.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt4);
                            paraMazdaUOEStockCnt5.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt5);
                            paraMazdaUOEStockCnt6.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt6);
                            paraMazdaUOEStockCnt7.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.MazdaUOEStockCnt7);
                            paraUOEDistributionCd.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEDistributionCd);
                            paraUOEOtherCd.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEOtherCd);
                            paraUOEHMCd.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEHMCd);
                            paraBOCount.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.BOCount);
                            paraUOEMarkCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOEMarkCode);
                            paraSourceShipment.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SourceShipment);
                            paraItemCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.ItemCode);
                            paraUOECheckCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UOECheckCode);
                            paraHeadErrorMassage.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.HeadErrorMassage);
                            paraLineErrorMassage.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.LineErrorMassage);
                            paraDataSendCode.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.DataSendCode);
                            paraDataRecoverDiv.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.DataRecoverDiv);
                            paraEnterUpdDivSec.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivSec);
                            paraEnterUpdDivBO1.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivBO1);
                            paraEnterUpdDivBO2.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivBO2);
                            paraEnterUpdDivBO3.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivBO3);
                            paraEnterUpdDivMaker.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivMaker);
                            paraEnterUpdDivEO.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.EnterUpdDivEO);
                            # endregion

                            sqlCommand.ExecuteNonQuery();
                            al.Add(uoeOrderDtlWork);
                        }
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
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            uoeOrderDtlList = al;

            return status;
        }
        #endregion

        # region [LogicalDelete]
        /// <summary>
        /// UOE�����f�[�^����_���폜���܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�_���폜����UOE�����f�[�^�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork �Ɋi�[����Ă���UOE�����f�[�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int LogicalDelete(ref object uoeOrderDtlList)
        {
            return this.LogicalDelete(ref uoeOrderDtlList, 0);
        }

        /// <summary>
        /// UOE�����f�[�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�_���폜����������UOE�����f�[�^�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork �Ɋi�[����Ă���UOE�����f�[�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int RevivalLogicalDelete(ref object uoeOrderDtlList)
        {
            return this.LogicalDelete(ref uoeOrderDtlList, 1);
        }

        /// <summary>
        /// UOE�����f�[�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�_���폜�𑀍삷��UOE�����f�[�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork �Ɋi�[����Ă���UOE�����f�[�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        private int LogicalDelete(ref object uoeOrderDtlList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = uoeOrderDtlList as ArrayList;

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

        //----------START ADD BY lingxiaoqing on 2011.10.28  Redmine#26283��Redmine#26284----------->>>>>>>>>
        /// <summary>
        /// UOE�󒍃f�[�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�_���폜�𑀍삷��UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="procMode">1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork �Ɋi�[����Ă���UOE�󒍃f�[�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.10.28</br>
        public int ReceiptLogicalDelete(ref ArrayList uoeOrderDtlList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReceiptLogicalDeleteProc(ref uoeOrderDtlList, procMode, ref sqlConnection, ref sqlTransaction);
        }


        /// <summary>
        /// UOE�����f�[�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�_���폜�𑀍삷��UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="procMode">1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork �Ɋi�[����Ă���UOE�����f�[�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.10.28</br>
        private int ReceiptLogicalDeleteProc(ref ArrayList uoeOrderDtlList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeOrderDtlList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeOrderDtlList.Count; i++)
                    {
                        UOEOrderDtlWork uoeOrderDtlWork = uoeOrderDtlList[i] as UOEOrderDtlWork;

                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE" + Environment.NewLine;
                        sqlText += "  ACCEPTODRRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = 1" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND COMMONSEQNORF=@FINDCOMMONSEQNO" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND ACPTANODRSTATUSRF=@FINDACPTANODRSTATUS" + Environment.NewLine;
                        sqlText += "  AND DATAINPUTSYSTEMRF=@FINDDATAINPUTSYSTEM" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        sqlCommand.Parameters.Clear();
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter findEnterPriSecode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findAcptanodrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                        SqlParameter findDataInputSystem = sqlCommand.Parameters.Add("@FINDDATAINPUTSYSTEM", SqlDbType.Int);
                        SqlParameter findCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeOrderDtlWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdAssemblyId2);
                        findEnterPriSecode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                        findSectionCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SectionCode).ToString().Trim();
                        findCommonSeqNo.Value = SqlDataMediator.SqlSetLong(uoeOrderDtlWork.CommonSeqNo);
                        findAcptanodrStatus.Value = 2;
                        findDataInputSystem.Value = 10;

                        sqlCommand.ExecuteNonQuery();
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
            return status;
        }
        //----------END ADD BY lingxiaoqing on 2011.10.28 for Redmine#26283��Redmine#26284-----------<<<<<<<<<<<<<

        /// <summary>
        /// UOE�����f�[�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�_���폜�𑀍삷��UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork �Ɋi�[����Ă���UOE�����f�[�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        public int LogicalDelete(ref ArrayList uoeOrderDtlList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteProc(ref uoeOrderDtlList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// UOE�����f�[�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">�_���폜�𑀍삷��UOE�����f�[�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : uoeOrderDtlWork �Ɋi�[����Ă���UOE�����f�[�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        private int LogicalDeleteProc(ref ArrayList uoeOrderDtlList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (uoeOrderDtlList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < uoeOrderDtlList.Count; i++)
                    {
                        UOEOrderDtlWork uoeOrderDtlWork = uoeOrderDtlList[i] as UOEOrderDtlWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND UOEKINDRF=@FINDUOEKIND" + Environment.NewLine;
                        sqlText += "  AND ONLINENORF=@FINDONLINENO" + Environment.NewLine;
                        sqlText += "  AND ONLINEROWNORF=@FINDONLINEROWNO" + Environment.NewLine;
                        sqlText += "  AND COMMONSEQNORF=@FINDCOMMONSEQNO" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL" + Environment.NewLine;
                        sqlText += "  AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        sqlCommand.Parameters.Clear();
                        // Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaUOEKind = sqlCommand.Parameters.Add("@FINDUOEKIND", SqlDbType.Int);
                        SqlParameter findParaOnlineNo = sqlCommand.Parameters.Add("@FINDONLINENO", SqlDbType.Int);
                        SqlParameter findParaOnlineRowNo = sqlCommand.Parameters.Add("@FINDONLINEROWNO", SqlDbType.Int);
                        SqlParameter findParaCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                        SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                        SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                        findParaUOEKind.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOEKind);
                        findParaOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineNo);
                        findParaOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineRowNo);
                        findParaCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.CommonSeqNo);
                        findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierFormal);
                        findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.StockSlipDtlNum);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != uoeOrderDtlWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  UOEORDERDTLRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND UOEKINDRF=@FINDUOEKIND" + Environment.NewLine;
                            sqlText += "  AND ONLINENORF=@FINDONLINENO" + Environment.NewLine;
                            sqlText += "  AND ONLINEROWNORF=@FINDONLINEROWNO" + Environment.NewLine;
                            sqlText += "  AND COMMONSEQNORF=@FINDCOMMONSEQNO" + Environment.NewLine;
                            sqlText += "  AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL" + Environment.NewLine;
                            sqlText += "  AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);
                            findParaUOEKind.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOEKind);
                            findParaOnlineNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineNo);
                            findParaOnlineRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.OnlineRowNo);
                            findParaCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.CommonSeqNo);
                            findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierFormal);
                            findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.StockSlipDtlNum);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)uoeOrderDtlWork;
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
                            else if (logicalDelCd == 0) uoeOrderDtlWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else uoeOrderDtlWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                uoeOrderDtlWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(uoeOrderDtlWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(uoeOrderDtlWork);
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

            uoeOrderDtlList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="uoeOrderDtlWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, UOEOrderDtlWork uoeOrderDtlWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.EnterpriseCode);

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

            //UOE���
            if (uoeOrderDtlWork.UOEKind != -1)
            {
                retstring += " AND UOEKINDRF = @FINDUOEKIND" + Environment.NewLine;
                SqlParameter findParaUOEKind = sqlCommand.Parameters.Add("@FINDUOEKIND", SqlDbType.Int);
                findParaUOEKind.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOEKind);
            }

            //���ʒʔ�
            if (uoeOrderDtlWork.CommonSeqNo != 0)
            {
                retstring += " AND COMMONSEQNORF = @FINDCOMMONSEQNO" + Environment.NewLine;
                SqlParameter findCommonSeqNo = sqlCommand.Parameters.Add("@FINDCOMMONSEQNO", SqlDbType.BigInt);
                findCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.CommonSeqNo);
            }

            //�d���`��
            if (uoeOrderDtlWork.SupplierFormal != -1)
            {
                retstring += " AND SUPPLIERFORMALRF = @FINDSUPPLIERFORMAL" + Environment.NewLine;
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                findParaSupplierFormal.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.SupplierFormal);
            }

            //�d�����גʔ�
            if (uoeOrderDtlWork.StockSlipDtlNum != 0)
            {
                retstring += " AND STOCKSLIPDTLNUMRF = @FINDSTOCKSLIPDTLNUM" + Environment.NewLine;
                SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);
                findParaStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(uoeOrderDtlWork.StockSlipDtlNum);
            }

            //���_�R�[�h
            if (string.IsNullOrEmpty(uoeOrderDtlWork.SectionCode) == false)
            {
                retstring += " AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = SqlDataMediator.SqlSetString(uoeOrderDtlWork.SectionCode);
            }

            //������R�[�h
            if (uoeOrderDtlWork.UOESupplierCd != 0)
            {
                retstring += " AND UOESUPPLIERCDRF = @FINDUOESUPPLIERCD" + Environment.NewLine;
                SqlParameter findParaUOESupplierCd = sqlCommand.Parameters.Add("@FINDUOESUPPLIERCD", SqlDbType.Int);
                findParaUOESupplierCd.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESupplierCd);
            }

            //�����ԍ�
            if (uoeOrderDtlWork.UOESalesOrderNo != 0)
            {
                retstring += " AND UOESALESORDERNORF = @FINDUOESALESORDERNO" + Environment.NewLine;
                SqlParameter findParaUOESalesOrderNo = sqlCommand.Parameters.Add("@FINDUOESALESORDERNO", SqlDbType.Int);
                findParaUOESalesOrderNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESalesOrderNo);
            }

            //�����s�ԍ�
            if (uoeOrderDtlWork.UOESalesOrderRowNo != 0)
            {
                retstring += " AND UOESALESORDERROWNORF = @FINDUOESALESORDERROWNO" + Environment.NewLine;
                SqlParameter findParaUOESalesOrderRowNo = sqlCommand.Parameters.Add("@FINDUOESALESORDERROWNO", SqlDbType.Int);
                findParaUOESalesOrderRowNo.Value = SqlDataMediator.SqlSetInt32(uoeOrderDtlWork.UOESalesOrderRowNo);
            }

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� UOEOrderDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>UOEOrderDtlWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        /// </remarks>
        private UOEOrderDtlWork CopyToUOEOrderDtlWorkFromReader(ref SqlDataReader myReader)
        {
            UOEOrderDtlWork uoeOrderDtlWork = new UOEOrderDtlWork();

            this.CopyToUOEOrderDtlWorkFromReader(ref myReader, ref uoeOrderDtlWork);

            return uoeOrderDtlWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� UOEOrderDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="uoeOrderDtlWork">UOEOrderDtlWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.07.16</br>
        /// </remarks>
        private void CopyToUOEOrderDtlWorkFromReader(ref SqlDataReader myReader, ref UOEOrderDtlWork uoeOrderDtlWork)
        {
            if (myReader != null && uoeOrderDtlWork != null)
            { 
                # region �N���X�֊i�[
                uoeOrderDtlWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                uoeOrderDtlWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                uoeOrderDtlWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                uoeOrderDtlWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                uoeOrderDtlWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                uoeOrderDtlWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                uoeOrderDtlWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                uoeOrderDtlWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                uoeOrderDtlWork.SystemDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SYSTEMDIVCDRF"));
                uoeOrderDtlWork.UOESalesOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESALESORDERNORF"));
                uoeOrderDtlWork.UOESalesOrderRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESALESORDERROWNORF"));
                uoeOrderDtlWork.SendTerminalNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SENDTERMINALNORF"));
                uoeOrderDtlWork.UOESupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESUPPLIERCDRF"));
                uoeOrderDtlWork.UOESupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUPPLIERNAMERF"));
                uoeOrderDtlWork.CommAssemblyId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COMMASSEMBLYIDRF"));
                uoeOrderDtlWork.OnlineNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINENORF"));
                uoeOrderDtlWork.OnlineRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ONLINEROWNORF"));
                uoeOrderDtlWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                uoeOrderDtlWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                uoeOrderDtlWork.DataUpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("DATAUPDATEDATETIMERF"));
                uoeOrderDtlWork.UOEKind = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOEKINDRF"));
                uoeOrderDtlWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                uoeOrderDtlWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                uoeOrderDtlWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                uoeOrderDtlWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                uoeOrderDtlWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                uoeOrderDtlWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                uoeOrderDtlWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                uoeOrderDtlWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));
                uoeOrderDtlWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                uoeOrderDtlWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                uoeOrderDtlWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                uoeOrderDtlWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                uoeOrderDtlWork.BoCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOCODERF"));
                uoeOrderDtlWork.UOEDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDELIGOODSDIVRF"));
                uoeOrderDtlWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
                uoeOrderDtlWork.FollowDeliGoodsDiv = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOLLOWDELIGOODSDIVRF"));
                uoeOrderDtlWork.FollowDeliGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOLLOWDELIGOODSDIVNMRF"));
                uoeOrderDtlWork.UOEResvdSection = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONRF"));
                uoeOrderDtlWork.UOEResvdSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOERESVDSECTIONNMRF"));
                uoeOrderDtlWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                uoeOrderDtlWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEENAMERF"));
                uoeOrderDtlWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                uoeOrderDtlWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                uoeOrderDtlWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                uoeOrderDtlWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                uoeOrderDtlWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                uoeOrderDtlWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                uoeOrderDtlWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                uoeOrderDtlWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                uoeOrderDtlWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));
                uoeOrderDtlWork.ListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERF"));
                uoeOrderDtlWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                uoeOrderDtlWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                uoeOrderDtlWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                uoeOrderDtlWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                uoeOrderDtlWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                uoeOrderDtlWork.ReceiveDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("RECEIVEDATERF"));
                uoeOrderDtlWork.ReceiveTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECEIVETIMERF"));
                uoeOrderDtlWork.AnswerMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ANSWERMAKERCDRF"));
                uoeOrderDtlWork.AnswerPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERPARTSNORF"));
                uoeOrderDtlWork.AnswerPartsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ANSWERPARTSNAMERF"));
                uoeOrderDtlWork.SubstPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSTPARTSNORF"));
                uoeOrderDtlWork.UOESectOutGoodsCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTOUTGOODSCNTRF"));
                uoeOrderDtlWork.BOShipmentCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT1RF"));
                uoeOrderDtlWork.BOShipmentCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT2RF"));
                uoeOrderDtlWork.BOShipmentCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSHIPMENTCNT3RF"));
                uoeOrderDtlWork.MakerFollowCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAKERFOLLOWCNTRF"));
                uoeOrderDtlWork.NonShipmentCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("NONSHIPMENTCNTRF"));
                uoeOrderDtlWork.UOESectStockCnt = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UOESECTSTOCKCNTRF"));
                uoeOrderDtlWork.BOStockCount1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT1RF"));
                uoeOrderDtlWork.BOStockCount2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT2RF"));
                uoeOrderDtlWork.BOStockCount3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOSTOCKCOUNT3RF"));
                uoeOrderDtlWork.UOESectionSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESECTIONSLIPNORF"));
                uoeOrderDtlWork.BOSlipNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO1RF"));
                uoeOrderDtlWork.BOSlipNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO2RF"));
                uoeOrderDtlWork.BOSlipNo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOSLIPNO3RF"));
                uoeOrderDtlWork.EOAlwcCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EOALWCCOUNTRF"));
                uoeOrderDtlWork.BOManagementNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BOMANAGEMENTNORF"));
                uoeOrderDtlWork.AnswerListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERLISTPRICERF"));
                uoeOrderDtlWork.AnswerSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ANSWERSALESUNITCOSTRF"));
                uoeOrderDtlWork.UOESubstMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESUBSTMARKRF"));
                uoeOrderDtlWork.UOEStockMark = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOESTOCKMARKRF"));
                uoeOrderDtlWork.PartsLayerCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSLAYERCDRF"));
                uoeOrderDtlWork.MazdaUOEShipSectCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD1RF"));
                uoeOrderDtlWork.MazdaUOEShipSectCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD2RF"));
                uoeOrderDtlWork.MazdaUOEShipSectCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESHIPSECTCD3RF"));
                uoeOrderDtlWork.MazdaUOESectCd1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD1RF"));
                uoeOrderDtlWork.MazdaUOESectCd2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD2RF"));
                uoeOrderDtlWork.MazdaUOESectCd3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD3RF"));
                uoeOrderDtlWork.MazdaUOESectCd4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD4RF"));
                uoeOrderDtlWork.MazdaUOESectCd5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD5RF"));
                uoeOrderDtlWork.MazdaUOESectCd6 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD6RF"));
                uoeOrderDtlWork.MazdaUOESectCd7 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAZDAUOESECTCD7RF"));
                uoeOrderDtlWork.MazdaUOEStockCnt1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT1RF"));
                uoeOrderDtlWork.MazdaUOEStockCnt2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT2RF"));
                uoeOrderDtlWork.MazdaUOEStockCnt3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT3RF"));
                uoeOrderDtlWork.MazdaUOEStockCnt4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT4RF"));
                uoeOrderDtlWork.MazdaUOEStockCnt5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT5RF"));
                uoeOrderDtlWork.MazdaUOEStockCnt6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT6RF"));
                uoeOrderDtlWork.MazdaUOEStockCnt7 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAZDAUOESTOCKCNT7RF"));
                uoeOrderDtlWork.UOEDistributionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEDISTRIBUTIONCDRF"));
                uoeOrderDtlWork.UOEOtherCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEOTHERCDRF"));
                uoeOrderDtlWork.UOEHMCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEHMCDRF"));
                uoeOrderDtlWork.BOCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BOCOUNTRF"));
                uoeOrderDtlWork.UOEMarkCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEMARKCODERF"));
                uoeOrderDtlWork.SourceShipment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SOURCESHIPMENTRF"));
                uoeOrderDtlWork.ItemCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ITEMCODERF"));
                uoeOrderDtlWork.UOECheckCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOECHECKCODERF"));
                uoeOrderDtlWork.HeadErrorMassage = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HEADERRORMASSAGERF"));
                uoeOrderDtlWork.LineErrorMassage = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LINEERRORMASSAGERF"));
                uoeOrderDtlWork.DataSendCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATASENDCODERF"));
                uoeOrderDtlWork.DataRecoverDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DATARECOVERDIVRF"));
                uoeOrderDtlWork.EnterUpdDivSec = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVSECRF"));
                uoeOrderDtlWork.EnterUpdDivBO1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO1RF"));
                uoeOrderDtlWork.EnterUpdDivBO2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO2RF"));
                uoeOrderDtlWork.EnterUpdDivBO3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVBO3RF"));
                uoeOrderDtlWork.EnterUpdDivMaker = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVMAKERRF"));
                uoeOrderDtlWork.EnterUpdDivEO = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERUPDDIVEORF"));
                # endregion
            }
        }
        # endregion

    }

}

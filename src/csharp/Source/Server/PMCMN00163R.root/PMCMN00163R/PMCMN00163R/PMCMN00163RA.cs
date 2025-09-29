//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώۃo�b�N�A�b�v�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώۃo�b�N�A�b�v���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ����
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11601223-00 �쐬�S�� : ����
// �C �� ��  2021/09/09  �C�����e : ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�
//----------------------------------------------------------------------------//

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �R���o�[�g�Ώۃo�b�N�A�b�vDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�v�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br>Update Note: ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2021/09/09</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ConvObjSingleBkDB : RemoteWithAppLockDB, IConvObjSingleBkDB
    {

        #region �񋓑�

        /// <summary>
        /// �o�b�N�A�b�v�폜�R�[�h
        /// </summary>
        public enum BkDelCode
        {
            /// <summary>�L��</summary>
            Enable = 0
          , /// <summary>����</summary>
            Disable = 1
        };

        #endregion // �񋓑�

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        /// �p�����[�^
        /// </summary>
        private ConvObjSingleBkDBParam cosbdbp = null;

        /// <summary>
        /// ���샍�O�o�^�����[�g
        /// </summary>
        private OprtnHisLogDB operationLoggingDB = null;

        /// <summary>
        /// ���i�}�X�^�o�b�N�A�b�v
        /// </summary>
        private ConvObjBkCreateDB cobdb = null;

        /// <summary>
        /// WebRequest Access Check
        /// </summary>
        private ConvObjSingleBkDBWebRequest codbwr = null;

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        private ConvObjSingleBkCLCLogDB coclcldb = null;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjSingleBkDB()
            : base("PMCMN00165D", "Broadleaf.Application.Remoting.ParamData.ConvObjSingleBkWork", "CONVOBJBKRF")
        {
            try
            {
                // �p�����[�^
                cosbdbp = new ConvObjSingleBkDBParam();

                // CLC���O�o��
                coclcldb = new ConvObjSingleBkCLCLogDB();

            }
            catch (Exception)
            {
            }
        }
        #endregion //�R���X�g���N�^

        #region IConvObjSingleBkDB �����o

        #region �R���o�[�g�Ώۃo�b�N�A�b�v
        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v���܂��B
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�v���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br>Update Note: ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        public int ConvObjSingleBackupExec(ref ConvObjSingleBkWork convObjSingleBkWork)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.BkStart;
            int stAWS = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            int stBkDel = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            int stExDel = (int)ConvObjSingleBkDBParam.StatusCode.Error;

            try
            {
                // ���O�o�͗p��ƃR�[�h�ݒ�
                coclcldb.EnterpriseCode = convObjSingleBkWork.EnterpriseCode;

                // �R���o�[�g�Ώۃo�b�N�A�b�v���s
                status = ConvObjSingleBackupProc(ref convObjSingleBkWork);

                ConvObjSingleBkFileMngDB cosbfmdb = new ConvObjSingleBkFileMngDB();

                // �s���t�@�C���폜
                stExDel = cosbfmdb.LocalExDelete();

                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // AWS�A�b�v���[�h
                    // �㑱�����ɉe�����Ȃ����߁A�A�b�v���[�h���s�����g���C�ΏۊO
                    stAWS = cosbfmdb.AWSUpload(convObjSingleBkWork.BkFileName);
                }
                else if (status == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound)
                {
                    // ------ DEL 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                    //ClcLogOutputProc(string.Format("{0},status:{1}", "INFO PMCMN00163RA ConvObjSingleBackupExec NormalNotFound", status));
                    // ------ DEL 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<
                }
                else
                {
                    ClcLogOutputProc(string.Format("{0},status:{1}", "ERR PMCMN00163RA ConvObjSingleBackupExec Error", status));
                }

                // ���o�b�N�A�b�v�폜
                // �㑱�����ɉe�����Ȃ����߁A�폜���s�����g���C�ΏۊO
                stBkDel = cosbfmdb.OldBkDelete(convObjSingleBkWork);

            }
            catch (Exception ex)
            {
                // ���O�o��
                base.WriteErrorLog(ex, "ConvObjSingleBkDB.ConvObjSingleBackupExec", status);

                // �G���[���O�o��
                ClcLogOutputProc(string.Format("{0}:{1}", "ERR PMCMN00163RA ConvObjSingleBackupExec Exception", ex.Message));
            }
            finally
            {
                // WebRequest Access Check Pt1
                ConvObjSingleBkDBWebRequestProc((int)ConvObjSingleBkDBWebRequest.WebReqChkPrm.UnauthorizedAccessPt1);

            }

            return status;
        }

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v���܂��B
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�v���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int ConvObjSingleBackupProc(ref ConvObjSingleBkWork convObjSingleBkWork)
        {

            int status = (int)ConvObjSingleBkDBParam.StatusCode.Error;       // �{���\�b�h�̖߂�l
            int stConnect = (int)ConvObjSingleBkDBParam.StatusCode.Error;    // DB�ڑ��p�X�e�[�^�X�ێ�
            int stTrans = (int)ConvObjSingleBkDBParam.StatusCode.Error;      // DB�g�����U�N�V�����p�X�e�[�^�X�ێ�
            int stLock = (int)ConvObjSingleBkDBParam.StatusCode.Error;       // DB�A�v���P�[�V�������b�N�p�X�e�[�^�X�ێ�
            int stBackup = (int)ConvObjSingleBkDBParam.StatusCode.Error;     // DB�o�b�N�A�b�v�p�X�e�[�^�X�ێ�
            int stBkMst = (int)ConvObjSingleBkDBParam.StatusCode.Error;      // �o�b�N�A�b�v�����p�X�e�[�^�X�ێ�
            int stBkInfo = (int)ConvObjSingleBkDBParam.StatusCode.Error;      // �o�b�N�A�b�v���X�V�p�X�e�[�^�X�ێ�

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            string resNm = string.Empty;           // ���b�N���\�[�X��

            try
            {
                // �f�[�^�x�[�X�ڑ�������擾
                stConnect = GetDataBaseConnect(ref sqlConnection);
                if (stConnect != (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3001;
                    // ���g���C��G���[�̏ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},stConnect:{1},status:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc GetDataBaseConnect", stConnect.ToString(), status.ToString()));
                    // �㑱�������s��Ȃ��B
                    return status;
                }

                // �g�����U�N�V�����J�n
                stTrans = GetDataBaseTransaction(ref sqlConnection, ref sqlTransaction);
                if (stTrans != (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3002; 
                    // ���g���C��G���[�̏ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},stTrans:{1},status:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc GetDataBaseTransaction", stTrans.ToString(), status.ToString()));
                    // �㑱�������s��Ȃ��B
                    return status;
                }

                // ��ƃR�[�h
                string enterpriseCode = convObjSingleBkWork.EnterpriseCode;

                // �A�v���P�[�V�������b�N�@���\�[�X���擾
                resNm = GetApplicationLockResourceName(ref enterpriseCode);
                if (string.IsNullOrEmpty(resNm) || string.IsNullOrEmpty(enterpriseCode))
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3003;
                    // ���g���C�ナ�\�[�X���A��ƃR�[�h�擾�ł��Ȃ��ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},resNm:{1},enterpriseCode:{2},status:{3}", "ERR PMCMN00163RA ConvObjSingleBackupProc GetApplicationLockResourceName", resNm, enterpriseCode, status.ToString()));
                    // �㑱�������s��Ȃ��B
                    return status;
                }
                
                // �A�v���P�[�V�������b�N
                stLock = GetApplicationLock(resNm, cosbdbp.DbApplicationLockTimeout, ref sqlConnection, ref sqlTransaction);
                if (stLock != (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3004;
                    // ���g���C��G���[�̏ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},stLock:{1},status:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc GetApplicationLock", stLock.ToString(), status.ToString()));
                    // �㑱�������s��Ȃ��B
                    return status;
                }

                // �V�X�e�����t�擾
                string nowDate = DateTime.Now.Year.ToString("0000") +
                    DateTime.Now.Month.ToString("00") +
                    DateTime.Now.Day.ToString("00");

                // �o�b�N�A�b�v�쐬���ݒ�
                convObjSingleBkWork.BkCreateDate = int.Parse(nowDate);

                // �o�b�N�A�b�v�擾���`�F�b�N
                stBackup = EnvBackupInfSearchCheck(convObjSingleBkWork, ref sqlConnection, ref sqlTransaction);
                if (stBackup == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                }
                else if (stBackup == (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupExists)
                {
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},status:{1}", "INFO PMCMN00163RA ConvObjSingleBackupProc BackupExists", stBackup.ToString()));

                    status = (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound;

                    // �Ăѐ�Ń��O�o�͂��Ă���
                    
                    // �o�b�N�A�b�v�擾�ς݂̏ꍇ�㑱�������s��Ȃ��B
                    return status;
                }
                else
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3005;

                    // �Ăѐ�Ń��O�o�͂��Ă���
                    
                    // �㑱�������s��Ȃ�
                    return status;
                }

                // �o�b�N�A�b�v�ŐV����擾
                stBackup = EnvBackupInfSearchProc(ref convObjSingleBkWork, ref sqlConnection, ref sqlTransaction);
                if (stBackup == (int)ConvObjSingleBkDBParam.StatusCode.Normal || stBackup == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound)
                {
                }
                else
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3006;
                    
                    // �Ăѐ�Ń��O�o�͂��Ă���

                    // �㑱�������s��Ȃ�
                    return status;
                }

                // �}�X�^�o�b�N�A�b�v���s
                stBkMst = VerObjMstBkProc(ref convObjSingleBkWork, ref sqlConnection, ref sqlTransaction);

                // �o�b�N�A�b�v�쐬�����ꍇ
                if (stBkMst == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    #region �o�b�N�A�b�v���o�^

                    status = (int)ConvObjSingleBkDBParam.StatusCode.BkInfoEnt;

                    // ��ƃR�[�h�@�ݒ�ς�

                    // �o�b�N�A�b�v����@�ŐV�o�b�N�A�b�v����{�P
                    convObjSingleBkWork.BkCreGeneration += 1;

                    // �o�b�N�A�b�v�J�n���A�o�b�N�A�b�v�t�@�C���� �ݒ�ς�

                    // �o�b�N�A�b�v�폜�敪
                    convObjSingleBkWork.BkDelCode = (int)BkDelCode.Enable;

                    // �R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�o�^
                    stBkInfo = BackupInfoEnt(convObjSingleBkWork, ref sqlConnection, ref sqlTransaction);

                    #endregion // �o�b�N�A�b�v���o�^
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "ConvObjSingleBkDB.ConvObjSingleBackupProc SqlException", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjSingleBkDB.ConvObjSingleBackupProc Exception", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc Exception", status.ToString(), ex.Message));
            }
            finally
            {
                // �A�v���P�[�V�������b�N�����[�X
                stLock = GetApplicationLockRelease(resNm, ref sqlConnection, ref sqlTransaction);
                if (stLock != (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.COAUPError3008;
                    // ���g���C��G���[�̏ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},stLock:{1},status:{2}", "ERR PMCMN00163RA ConvObjSingleBackupProc GetApplicationLockRelease", stLock.ToString(), status.ToString()));
                }

                // �g�����U�N�V�����I��
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if ((stBkMst == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound || stBkInfo == (int)ConvObjSingleBkDBParam.StatusCode.Normal) && stLock == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                            //sqlTransaction.Rollback();

                            // ����
                            status = stBkMst;
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }
                    sqlTransaction.Dispose();
                }

                // �f�[�^�x�[�X�ڑ�����
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion // �R���o�[�g�Ώۃo�b�N�A�b�v

        #region �f�[�^�x�[�X�ڑ�

        /// <summary>
        /// �f�[�^�x�[�X�ڑ�
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�x�[�X�ڑ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDataBaseConnect(ref SqlConnection sqlConnection)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseConnectError;

            sqlConnection = null;
                
            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //������
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseTransactionError;
                }

                try
                {
                    // �R�l�N�V��������
                    // �����̌��ʃZ�b�g���g�p���邽�߁A�ڑ��������MultipleActiveResultSets = true;��ǉ�
                    // �g�����U�N�V�����J�n���ɐڑ������
                    sqlConnection = this.CreateConnection(false);
                    sqlConnection.ConnectionString += ";MultipleActiveResultSets = true";

                    if (sqlConnection != null)
                    {
                        // ����
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                }
                catch (Exception ex)
                {
                    // ��O�G���[
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseConnectExError;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA GetDataBaseConnect Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    // ������
                }
                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //�f�[�^�x�[�X�ڑ�

        #region �g�����U�N�V�����J�n

        /// <summary>
        /// �g�����U�N�V�����J�n
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �g�����U�N�V�����J�n</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDataBaseTransaction(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseTransactionError;

            sqlTransaction = null;

            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //������
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseTransactionError;
                }

                try
                {
                    // �g�����U�N�V�����J�n
                    sqlTransaction = this.CreateTransaction(ref sqlConnection);
                    if ((sqlConnection != null) && (sqlTransaction != null))
                    {
                        // ����
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                }
                catch (Exception ex)
                {
                    // ��O�G���[
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetDataBaseTransactionExError;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA GetDataBaseTransaction Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    // ������
                }

                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //�f�[�^�x�[�X�ڑ�

        #region �A�v���P�[�V�������b�N�@���\�[�X���擾

        /// <summary>
        /// �A�v���P�[�V�������b�N�@���\�[�X���擾
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �A�v���P�[�V�������b�N�@���\�[�X���擾</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private string GetApplicationLockResourceName(ref string enterpriseCode)
        {
            string tmpenterpriseCode = string.Empty;
            string strResourceName = string.Empty;

            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //������
                    tmpenterpriseCode = string.Empty;
                    strResourceName = string.Empty;
                }

                try
                {
                    tmpenterpriseCode = enterpriseCode;
                    if (string.IsNullOrEmpty(tmpenterpriseCode))
                    {
                        try
                        {
                            ServerLoginInfoAcquisition serverLoginInfoAcquisition = new ServerLoginInfoAcquisition();
                            tmpenterpriseCode = serverLoginInfoAcquisition.EnterpriseCode;
                        }
                        catch (Exception ex)
                        {
                            // ���\�[�X���擾�s���ŋ󗓂�ԋp
                            strResourceName = string.Empty;
                            // ��ƃR�[�h�擾�ł��Ȃ��̂Ń��O�o�͌�Ƀ��g���C
                            ClcLogOutputProc(string.Format("{0},[{1}],ex:{2}", "ERR PMCMN00163RA GetApplicationLockResourceName serverLoginInfoAcquisition Exception", retryCnt.ToString(), ex.Message));
                        }
                    }

                    if (!string.IsNullOrEmpty(tmpenterpriseCode))
                    {
                        enterpriseCode = tmpenterpriseCode;
                        strResourceName = this.GetResourceName(tmpenterpriseCode);
                    }
                }
                catch (Exception ex)
                {
                    // ���\�[�X���擾�s���ŋ󗓂�ԋp
                    strResourceName = string.Empty;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],ex:{2}", "ERR PMCMN00163RA GetApplicationLockResourceName Exception", retryCnt.ToString(), ex.Message));
                }
                finally
                {
                    // ������
                }

                if (!string.IsNullOrEmpty(strResourceName))
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }

                retryCnt += 1;
            }

            return strResourceName;
        }

        #endregion //�A�v���P�[�V�������b�N�@���\�[�X���擾

        #region �A�v���P�[�V�������b�N

        /// <summary>
        /// �A�v���P�[�V�������b�N
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �A�v���P�[�V�������b�N</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetApplicationLock(string resNm, int timeout, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.GetApplicationLockError;

            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //������
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetApplicationLockError;
                }

                try
                {
                    // �A�v���P�[�V�������b�N
                    status = this.Lock(resNm, timeout, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ���b�N����
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        // �^�C���A�E�g
                        status = (int)ConvObjSingleBkDBParam.StatusCode.GetApplicationLockTimeout;
                        // ���g���C�Ώ�
                        // ���O�o��
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00163RA GetApplicationLock Timeout", retryCnt.ToString(), status.ToString(), resNm));
                    }
                    else
                    {
                        // ���g���C�Ώ�
                        // ���O�o��
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00163RA GetApplicationLock Error", retryCnt.ToString(), status.ToString(), resNm));
                    }

                }
                catch (Exception ex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.GetApplicationLockExError;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3},ex:{4}", "ERR PMCMN00163RA GetApplicationLock Exception", retryCnt.ToString(), status.ToString(), resNm, ex.Message));
                }
                finally
                {
                    // ������
                }

                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //�A�v���P�[�V�������b�N

        #region �A�v���P�[�V�������b�N�����[�X

        /// <summary>
        /// �A�v���P�[�V�������b�N�����[�X
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �A�v���P�[�V�������b�N�����[�X</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetApplicationLockRelease(string resNm, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.Error;

            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //������
                    status = (int)ConvObjSingleBkDBParam.StatusCode.Error;
                }

                try
                {
                    // �A�v���P�[�V�������b�N�����[�X
                    status = this.Release(resNm, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �����[�X����
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        // ���g���C�Ώ�
                        // ���O�o��
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00163RA GetApplicationLockRelease Timeout", retryCnt.ToString(), status.ToString(), resNm));
                    }
                    else
                    {
                        // ���g���C�Ώ�
                        // ���O�o��
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00163RA GetApplicationLockRelease Error", retryCnt.ToString(), status.ToString(), resNm));
                    }
                }
                catch (Exception ex)
                {
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3},ex:{4}", "ERR PMCMN00163RA GetApplicationLockRelease Exception", retryCnt.ToString(), status.ToString(), resNm, ex.Message));
                }
                finally
                {
                    // ������
                }

                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //�A�v���P�[�V�������b�N�����[�X


        #region �o�b�N�A�b�v�擾���`�F�b�N

        /// <summary>
        /// �o�b�N�A�b�v�擾���`�F�b�N
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �o�b�N�A�b�v�擾���`�F�b�N</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int EnvBackupInfSearchCheck(ConvObjSingleBkWork convObjSingleBkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfError;

            int retryCnt = 0;

            StringBuilder sqlText = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //������
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfError;
                    sqlText = null;
                    sqlCommand = null;
                    myReader = null;
                }

                try
                {
                    sqlText = new StringBuilder();
                    sqlText.Append("SELECT BKCREGENERATIONRF " + Environment.NewLine);
                    sqlText.Append(" FROM CONVOBJBKMNGRF " + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine);
                    sqlText.Append(" AND LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine);
                    sqlText.Append(" AND BKCREATEDATERF = @BKCREATEDATERF " + Environment.NewLine);
                    sqlText.Append(" AND BKDELCODERF = @BKDELCODE " + Environment.NewLine);
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findParaBkCreateDate = sqlCommand.Parameters.Add("@BKCREATEDATERF", SqlDbType.Int);
                    SqlParameter findParaBkDelCls = sqlCommand.Parameters.Add("@BKDELCODE", SqlDbType.Int);

                    findParaEnterPriseCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.EnterpriseCode);
                    findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                    findParaBkCreateDate.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.BkCreateDate);
                    findParaBkDelCls.Value = SqlDataMediator.SqlSetInt32((int)BkDelCode.Enable); // 0:�L��

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // �������ʂ���@�E�E�E�@�o�b�N�A�b�v�擾�ς݂�ԋp
                        status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupExists;
                    }
                    else
                    {
                        // �������ʂȂ��@�E�E�E�@�������s
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                }
                catch (SqlException sqlex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfSqlExError;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA EnvBackupInfSearchCheck SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                }
                catch (Exception ex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfExError;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA EnvBackupInfSearchCheck Exception", retryCnt.ToString(), status.ToString(), ex.Message));
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

                if ((status == (int)ConvObjSingleBkDBParam.StatusCode.Normal) || (status == (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupExists))
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion // �o�b�N�A�b�v�擾���`�F�b�N

        #region ���i�}�X�^�o�b�N�A�b�v
        /// <summary>
        /// ���i�}�X�^�o�b�N�A�b�v
        /// </summary>
        /// <param name="convObjSingleBkWork">�R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�o�b�N�A�b�v</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int VerObjMstBkProc(ref ConvObjSingleBkWork convObjSingleBkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.VerObjMstBkProcError;
            int stBackup = (int)ConvObjSingleBkDBParam.StatusCode.DataTableBackupExError;

            StringBuilder sqlText = null;
            SqlCommand sqlCommand = null;
            DataTable dt = null;
            DataRow dr = null;
            SqlDataReader sdr = null;
            ConvertDoubleRelease convertDoubleRelease = null;

            try
            {
                #region ���i�}�X�^�擾

                status = (int)ConvObjSingleBkDBParam.StatusCode.MstGet;

                try
                {

                    sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    sqlCommand.CommandTimeout = cosbdbp.DbCommandTimeout;

                    // ���i�}�X�^�擾

                    # region [SELECT��]
                    sqlText.Append("SELECT " + Environment.NewLine);
                    sqlText.Append(" * " + Environment.NewLine);
                    sqlText.Append(" FROM GOODSPRICEURF " + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = convObjSingleBkWork.EnterpriseCode;

                    sdr = sqlCommand.ExecuteReader();
                }
                catch (SqlException sqlex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.MstGetSqlExError;
                    ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00163RA MstGet SqlException", status.ToString(), sqlex.Message));
                    // ��O�X���[
                    throw;
                }
                catch (Exception ex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.MstGetExError;
                    ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA MstGet Exception", status.ToString(), ex.Message));
                    // ��O�X���[
                    throw;
                }

                # endregion  // ���i�}�X�^�擾

                // �X�V�Ώۂ�1���ȏ�̏ꍇ
                if (sdr.HasRows)
                {
                    // �R���o�[�g�Ώۃo�[�W�����Ǘ����ʕ��i�@��񏉊����@�Ăяo��
                    // �ϊ����Ăяo��
                    convertDoubleRelease = new ConvertDoubleRelease();

                    // ��ƃR�[�h�ݒ�
                    convertDoubleRelease.EnterpriseCode = convObjSingleBkWork.EnterpriseCode;

                    // �ϊ���񏉊���
                    convertDoubleRelease.ReleaseInitLib();

                    #region DataTable�쐬
                    status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableCreate;

                    sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);
                    dt = CreateSchemaDataTable(sqlCommand);

                    #endregion // DataTable�쐬

                    #region ���i�}�X�^�o�b�N�A�b�v�쐬�C���X�^���X����

                    status = (int)ConvObjSingleBkDBParam.StatusCode.ConvObjBackupCreate;

                    // �o�b�N�A�b�v�t�@�C�����ݒ�
                    // �uConvObjBackup_�쐬�N����_��ƃR�[�h_�[����_GUID�v
                    convObjSingleBkWork.BkFileName = string.Format("ConvObjBackup_{0}_{1}_{2}_{3}.zip", convObjSingleBkWork.BkCreateDate, convObjSingleBkWork.EnterpriseCode, Environment.MachineName, Guid.NewGuid().ToString());

                    cobdb = new ConvObjBkCreateDB(convObjSingleBkWork.BkFileName);

                    #endregion // ���i�}�X�^�o�b�N�A�b�v�쐬�C���X�^���X����

                    while (sdr.Read())
                    {
                        #region ���i�}�X�^�W�J

                        status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableDeploy;

                        try
                        {
                            dr = DeployDataTable(sdr, dt);
                        }
                        catch
                        {
                            // �Ăѐ�ŗ�O���O�o�͂��Ă���
                            throw;
                        }
                        finally
                        {
                        }

                        #endregion // ���i�}�X�^�W�J

                        #region �o�b�N�A�b�v�쐬

                        status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableBackup;

                        try
                        {
                            // �擾�������i�}�X�^��P��o�b�N�A�b�v
                            if (cobdb != null)
                            {
                                if (convertDoubleRelease.ConvertInfParam.ConvertVersionMst != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                                {
                                    // �R���o�[�g�ς݂̏ꍇ�A�������ăo�b�N�A�b�v����
                                    convertDoubleRelease.EnterpriseCode = Convert.ToString(dr["ENTERPRISECODERF"]);
                                    convertDoubleRelease.GoodsMakerCd = Convert.ToInt32(dr["GOODSMAKERCDRF"]);
                                    convertDoubleRelease.GoodsNo = Convert.ToString(dr["GOODSNORF"]);
                                    convertDoubleRelease.ConvertSetParam = Convert.ToDouble(dr["LISTPRICERF"]);

                                    convertDoubleRelease.ReleaseProc();

                                    dr["LISTPRICERF"] = convertDoubleRelease.ConvertInfParam.ConvertGetParam;

                                }

                                stBackup = cobdb.ConvObjBackup(dr);

                                // �g�p�ς݂�DataRow�����
                                if (dr != null)
                                {
                                    dr.Table.Clear();
                                    dr.Table.Dispose();
                                    dr = null;
                                }

                                if (stBackup != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    // �o�b�N�A�b�v�쐬���ɃG���[����
                                    status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableBackupError2027;
                                    // ���O�o��
                                    ClcLogOutputProc(string.Format("{0},status:{1},stBackup:{2}", "ERR PMCMN00163RA DataTableBackup Error", status.ToString(), stBackup.ToString()));
                                    throw new Exception(string.Format("{0},status:{1},stBackup:{2}", "ERR PMCMN00163RA DataTableBackup Error", status.ToString(), stBackup.ToString()));
                                }
                            }
                            else
                            {
                                // �o�b�N�A�b�v�쐬���ɃG���[����
                                status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableBackupError2028;
                                // ���O�o��
                                ClcLogOutputProc(string.Format("{0},status:{1},stBackup:{2}", "ERR PMCMN00163RA DataTableBackup Error null", status.ToString(), stBackup.ToString()));
                                throw new Exception(string.Format("{0},status:{1},stBackup:{2}", "ERR PMCMN00163RA DataTableBackup Error null", status.ToString(), stBackup.ToString()));
                            }
                        }
                        catch (Exception ex)
                        {
                            // �P��o�b�N�A�b�v���ɃG���[����
                            status = (int)ConvObjSingleBkDBParam.StatusCode.DataTableBackupExError;
                            ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA DataTableBackup Exception", status.ToString(), ex.Message));
                            // ��O�X���[
                            throw;
                        }

                        #endregion // �o�b�N�A�b�v�쐬

                        // �����s�����C���N�������g
                        coclcldb.BkMstCnt++;
                    }

                    #region �o�b�N�A�b�v�t�@�C�����k
                    try
                    {
                        status = (int)ConvObjSingleBkDBParam.StatusCode.ConvObjBackupZipEntry;
                        cobdb.BackupZipCreate(convObjSingleBkWork.BkFileName);
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConvObjSingleBkDBParam.StatusCode.ConvObjBackupZipEntryExError;
                        ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA ConvObjBackupZipEntry Exception", status.ToString(), ex.Message));
                        throw;
                    }
                    finally
                    {
                    }

                    #endregion // �o�b�N�A�b�v�t�@�C�����k

                    // ����
                    status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                }
                else
                {
                    // �o�b�N�A�b�v�ΏۂȂ�
                    status = (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "ConvObjSingleBkDB.VerObjMstBkProc SqlException", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00163RA VerObjMstBkProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjSingleBkDB.VerObjMstBkProc ex", status);
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA VerObjMstBkProc Exception", status.ToString(), ex.Message));
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }

                if (dt != null)
                {
                    dt.Clear();
                    dt.Dispose();
                    dt = null;
                }

                if (sdr != null && !sdr.IsClosed)
                {
                    sdr.Close();
                    sdr.Dispose();
                }

                if (cobdb != null)
                {
                    cobdb.Dispose();
                    cobdb = null;
                }

                if (convertDoubleRelease != null)
                {
                    convertDoubleRelease.Dispose();
                    convertDoubleRelease = null;
                }
            }

            return status;
        }
        #endregion  //���i�}�X�^�R���o�[�g

        #region �ŐV�o�b�N�A�b�v����擾

        /// <summary>
        /// �ŐV�o�b�N�A�b�v����擾
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ŐV�o�b�N�A�b�v����擾</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int EnvBackupInfSearchProc(ref ConvObjSingleBkWork convObjSingleBkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfGetError;
            object a = ConstantManagement.DB_Status.ctDB_ADS_LOCK_TIMEOUT;
            int retryCnt = 0;

            StringBuilder sqlText = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt <= cosbdbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(cosbdbp.RetryInterval);

                    //������
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfGetError;
                    sqlText = null;
                    sqlCommand = null;
                    myReader = null;
                }

                try
                {
                    sqlText = new StringBuilder();
                    sqlText.Append("SELECT MAX(BKCREGENERATIONRF) AS BKCREGENERATIONRF_MAX " + Environment.NewLine);
                    sqlText.Append(" FROM CONVOBJBKMNGRF " + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine);
                    sqlText.Append(" AND LOGICALDELETECODERF = @LOGICALDELETECODE " + Environment.NewLine);
                    sqlText.Append(" AND BKDELCODERF = @BKDELCODE " + Environment.NewLine);
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);
                    sqlCommand.CommandTimeout = cosbdbp.DbCommandTimeout;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter findParaBkDelCls = sqlCommand.Parameters.Add("@BKDELCODE", SqlDbType.Int);

                    findParaEnterPriseCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.EnterpriseCode);
                    findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                    findParaBkDelCls.Value = SqlDataMediator.SqlSetInt32((int)BkDelCode.Enable); // 0:�L��

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        // �������ʂ���@�E�E�E�@�ŐV�����ԋp
                        convObjSingleBkWork.BkCreGeneration = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BKCREGENERATIONRF_MAX"));
                        status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    }
                    else
                    {
                        // �������ʂȂ��@�E�E�E�@�����l�̂܂܁i0�j
                        status = (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound;
                    }
                }
                catch (SqlException sqlex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfGetSqlExError;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA EnvBackupInfSearchProc SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                }
                catch (Exception ex)
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.EnvBackupInfGetExError;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00163RA EnvBackupInfSearchProc Exception", retryCnt.ToString(), status.ToString(), ex.Message));
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

                if (status == (int)ConvObjSingleBkDBParam.StatusCode.Normal || status == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound)
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //�ŐV�o�b�N�A�b�v����擾

        #region �o�b�N�A�b�v�J�n����o�^

        /// <summary>
        /// �o�b�N�A�b�v�J�n����o�^
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �o�b�N�A�b�v�J�n����o�^</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int BackupInfoEnt(ConvObjSingleBkWork convObjSingleBkWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.BkInfoEntError;

            SqlCommand sqlCommand = null;

            try
            {
                if (convObjSingleBkWork != null)
                {
                    # region [INSERT��]
                    StringBuilder sqlText_INSERT = new StringBuilder();
                    sqlText_INSERT.Append("INSERT INTO CONVOBJBKMNGRF " + Environment.NewLine);
                    sqlText_INSERT.Append(" (CREATEDATETIMERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,UPDATEDATETIMERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,ENTERPRISECODERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,FILEHEADERGUIDRF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,UPDEMPLOYEECODERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,UPDASSEMBLYID1RF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,UPDASSEMBLYID2RF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,LOGICALDELETECODERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,BKCREGENERATIONRF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,BKCREATEDATERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,BKFILENAMERF " + Environment.NewLine);
                    sqlText_INSERT.Append(" ,BKDELCODERF " + Environment.NewLine);
                    sqlText_INSERT.Append("  ) VALUES ( " + Environment.NewLine);
                    sqlText_INSERT.Append("   @CREATEDATETIME " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@UPDATEDATETIME " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@ENTERPRISECODE " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@FILEHEADERGUID " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@UPDEMPLOYEECODE " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@UPDASSEMBLYID1 " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@UPDASSEMBLYID2 " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@LOGICALDELETECODE " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@BKCREGENERATION " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@BKCREATEDATE " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@BKFILENAME " + Environment.NewLine);
                    sqlText_INSERT.Append("  ,@BKDELCODE " + Environment.NewLine);
                    sqlText_INSERT.Append("  )" + Environment.NewLine);
                    # endregion

                    sqlCommand = new SqlCommand(sqlText_INSERT.ToString(), sqlConnection, sqlTransaction);

                    sqlCommand.CommandTimeout = cosbdbp.DbCommandTimeout;

                    // �o�^�w�b�_����ݒ�
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)convObjSingleBkWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraBkCreGeneration = sqlCommand.Parameters.Add("@BKCREGENERATION", SqlDbType.Int);
                    SqlParameter paraBkCreateDate = sqlCommand.Parameters.Add("@BKCREATEDATE", SqlDbType.Int);
                    SqlParameter paraBkFileName = sqlCommand.Parameters.Add("@BKFILENAME", SqlDbType.NVarChar);
                    SqlParameter paraDelCode = sqlCommand.Parameters.Add("@BKDELCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(convObjSingleBkWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(convObjSingleBkWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(convObjSingleBkWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.LogicalDeleteCode);
                    paraBkCreGeneration.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.BkCreGeneration);
                    paraBkCreateDate.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.BkCreateDate);
                    paraBkFileName.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.BkFileName);
                    paraDelCode.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.BkDelCode);

                    sqlCommand.ExecuteNonQuery();

                    status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                }
                else
                {
                    // �p�����[�^�G���[
                    status = (int)ConvObjSingleBkDBParam.StatusCode.BkInfoEntParamError;
                    base.WriteErrorLog("ConvObjSingleBkDB.BackupStartEnt SqlException", status);
                    ClcLogOutputProc(string.Format("{0},status:{1}", "ERR PMCMN00163RA BackupStartEnt ParamError", status.ToString()));
                }

            }
            catch (SqlException sqlex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.BkInfoEntSqlExError;
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "ConvObjSingleBkDB.BackupStartEnt SqlException", status);
                ClcLogOutputProc(string.Format("{0},status:{1},BkFileName:{2},sqlex:{3}", "ERR PMCMN00163RA BackupStartEnt SqlException", status.ToString(), convObjSingleBkWork.BkFileName, sqlex.ToString()));
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.BkInfoEntExError;
                base.WriteErrorLog(ex, "ConvObjSingleBkDB.BackupStartEnt Exception", status);
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA BackupStartEnt Exception", status.ToString(), ex.ToString()));
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

        #endregion //�ŐV�o�b�N�A�b�v����擾

        #region DataTable�쐬
        /// <summary>
        /// ���i�}�X�^�\����DataTable���쐬���܂��B
        /// </summary>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <returns>DataTable�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : DataTable�쐬</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private DataTable CreateSchemaDataTable(SqlCommand sqlCommand)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();

                # region [SELECT��]
                sqlText.Append("SELECT " + Environment.NewLine);
                sqlText.Append(" * " + Environment.NewLine);
                sqlText.Append(" FROM GOODSPRICEURF " + Environment.NewLine);
                sqlText.Append(" WHERE 1 = 0 " + Environment.NewLine);
                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                sqlCommand.CommandTimeout = cosbdbp.DbCommandTimeout;

                // ���i�}�X�^�e�[�u�����擾
                sda = new SqlDataAdapter();
                sda.SelectCommand = sqlCommand;
                sda.FillSchema(dt, SchemaType.Source);
                
                // �啶������������ʂ���
                dt.CaseSensitive = true;
            }
            catch (SqlException sqlex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RA CreateSchemaDataTable SqlException", sqlex.Message));
                throw;
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RA CreateSchemaDataTable Exception", ex.Message));
                throw;
            }
            finally
            {
                if (sda != null)
                {
                    sda.Dispose();
                    sda = null;
                }
            }

            return dt;
        }
        #endregion // DataTable�쐬

        #region ���i�}�X�^�W�J
        /// <summary>
        /// ���i�}�X�^��DataRow��W�J���܂��B
        /// </summary>
        /// <param name="reader">��������DataReader</param>
        /// <param name="dt">��������Datatable</param>
        /// <returns>DataTable�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : DataTable�쐬</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private DataRow DeployDataTable(SqlDataReader reader, DataTable dt)
        {
            DataRow dr = null;

            try
            {
                // DataRow�쐬
                dr = dt.NewRow();

                // ���݂�DataReader��DataRow�ɐݒ�
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dr[i] = reader.GetValue(i);
                }
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RA DeployDataTable Exception", ex.ToString()));
                throw;
            }
            finally
            {
            }

            return dr;
        }
        #endregion // DataTable�쐬

        #region �R���o�[�g�Ώۃo�b�N�A�b�vWebRequest
        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�vWebRequest
        /// </summary>
        /// <param name="checkParam">�`�F�b�N�p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�vWebRequest</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int ConvObjSingleBkDBWebRequestProc(int checkParam)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            try
            {
                if (cosbdbp.WebAccessCheckControl == (int)ConvObjSingleBkDBParam.CheckObjCode.ON)
                {
                    // WebRequest Access Check
                    if (codbwr == null)
                    {
                        codbwr = new ConvObjSingleBkDBWebRequest();
                    }
                    codbwr.ConvObjSingleBkDBWebReqRes(checkParam);
                }
            }
            catch
            {
            }
            finally
            {
            }

            return status;
        }
        #endregion  //�R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^����ǉ��E�X�V

        #region CLC���O�o��
        /// <summary>
        /// CLC���O�o�͎���
        /// </summary>
        /// <param name="message">���O�o�͏��</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���샍�O�e�[�u���Ƀ��O���o�͂���</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private void ClcLogOutputProc(string message)
        {
            if (cosbdbp.ClcLogOutputInfo == (int)ConvObjSingleBkDBParam.OutputCode.ON)
            {
                try
                {
                    // CLC���O�o��
                    coclcldb.ClcLogOutput(message);
                }
                catch
                {
                }
                finally
                {
                }
            }
        }
        #endregion  // CLC���O�o��

        #region ���샍�O�o��
        /// <summary>
        /// ���샍�O�o��
        /// </summary>
        /// <param name="writeParam">���O�o�͏��</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���샍�O�e�[�u���Ƀ��O���o�͂���</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int WriteOprtnHisLog(OprtnHisLogWork writeParam)
        {
            return this.WriteOprtnHisLogProc(writeParam);
        }

        /// <summary>
        /// ���샍�O�o�͎���
        /// </summary>
        /// <param name="writeParam">���O�o�͏��</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���샍�O�e�[�u���Ƀ��O���o�͂���</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int WriteOprtnHisLogProc(OprtnHisLogWork writeParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if (this.operationLoggingDB == null)
                    this.operationLoggingDB = new OprtnHisLogDB();

                object param = (object)writeParam;
                status = this.operationLoggingDB.Write(ref param);
            }
            catch (SqlException sqlex)
            {
                status = base.WriteSQLErrorLog(sqlex);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00163RA WriteOprtnHisLogProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RA WriteOprtnHisLogProc Exception", status.ToString(), ex.Message));
            }

            return (int)status;
        }
        #endregion  //���샍�O�o��

        #endregion // IConvObjSingleBkDB �����o

    }


}

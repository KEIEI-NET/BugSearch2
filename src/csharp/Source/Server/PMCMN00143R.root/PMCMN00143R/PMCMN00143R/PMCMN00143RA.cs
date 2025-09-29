//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώێ����X�V�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώێ����X�V���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �R���o�[�g�Ώێ����X�VDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώێ����X�V�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���X�ؘj</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ConvObjDB : RemoteWithAppLockDB, IConvObjDB
    {

        #region �萔

        #endregion // �萔

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        /// �p�����[�^
        /// </summary>
        private ConvObjDBParam codbp = null;

        /// <summary>
        /// ���샍�O�o�^�����[�g
        /// </summary>
        private OprtnHisLogDB OperationLoggingDB = null;

        /// <summary>
        /// ���i�}�X�^�o�b�N�A�b�v
        /// </summary>
        private ConvObjBackupDB cobdb = null;

        /// <summary>
        /// WebRequest Access Check
        /// </summary>
        private ConvObjDBWebRequest codbwr = null;

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        private ConvObjCLCLogDB coclcldb = null;

        /// <summary>
        /// ���O�C�����
        /// </summary>
        private ServerLoginInfoAcquisition slia = null;

        /// <summary>
        /// �R���o�[�g�ΏۊO��ƃp�����[�^
        /// </summary>
        private ConvObjEnterpriseParamDB coepdb = null;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �R���o�[�g�Ώێ����X�V�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjDB()
            : base("PMCMN00145D", "Broadleaf.Application.Remoting.ParamData.ConvObjWork", "CONVOBJRF")
        {
            try
            {
                // �p�����[�^
                codbp = new ConvObjDBParam();

                // CLC���O�o��
                coclcldb = new ConvObjCLCLogDB();

            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
            }
        }
        #endregion //�R���X�g���N�^

        #region IConvObjDB �����o

        #region �R���o�[�g�Ώێ����X�V
        /// <summary>
        /// �R���o�[�g�Ώێ����X�V���܂��B
        /// </summary>
        /// <param name="convObjWorkbyte">�����X�V���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώێ����X�V���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int ConvObjAutoUpdate(ref ConvObjWork convObjWorkbyte)
        {
            int status = (int)ConvObjDBParam.StatusCode.Normal;


            try
            {
                // �R���o�[�g�ΏۊO��ƃp�����[�^
                coepdb = new ConvObjEnterpriseParamDB();
            }
            catch (Exception ex)
            {
                // ���O�o��
                base.WriteErrorLog(ex, "ConvObjDB.ConvObjDB Exception");

                // �G���[���O�o��
                ClcLogOutputProc(string.Format("{0}:{1}", "ERR PMCMN00143RA ConvObjDB.ConvObjDB Exception", ex.Message));

                // �ݒ�t�@�C�������݂��Ȃ��܂��͔j�����Ă���ꍇ���f
                throw;
            }

            try
            {
                // WebRequest Access Check Pt0
                ConvObjDBWebRequestProc((int)ConvObjDBWebRequest.WebReqChkPrm.UnauthorizedAccessPt0);

                // �p�����[�^�̃L���X�g
                ConvObjWork convObjWork = convObjWorkbyte as ConvObjWork;

                // ���O�o�͗p��ƃR�[�h�ݒ�
                coclcldb.EnterpriseCode = convObjWork.EnterpriseCode;

                // �R���o�[�g�Ώێ����X�V���s
                status = ConvObjAutoUpdateProc(ref convObjWork);
            }
            catch (Exception ex)
            {
                // ���O�o��
                base.WriteErrorLog(ex, "ConvObjDB.ConvObjAutoUpdate", status);

                // �G���[���O�o��
                ClcLogOutputProc(string.Format("{0}:{1}", "ERR PMCMN00143RA ConvObjAutoUpdate Exception", ex.Message));
            }
            finally
            {
                // WebRequest Access Check Pt1
                ConvObjDBWebRequestProc((int)ConvObjDBWebRequest.WebReqChkPrm.UnauthorizedAccessPt1);

                // ���O�o��
            }

            return status;
        }

        /// <summary>
        /// �R���o�[�g�Ώێ����X�V���܂��B
        /// </summary>
        /// <param name="convObjWorkbyte">�����X�V���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώێ����X�V���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int ConvObjAutoUpdateProc(ref ConvObjWork convObjWorkbyte)
        {

            int status = (int)ConvObjDBParam.StatusCode.Error;       // �{���\�b�h�̖߂�l
            int stConnect = (int)ConvObjDBParam.StatusCode.Error;    // DB�ڑ��p�X�e�[�^�X�ێ�
            int stTrans = (int)ConvObjDBParam.StatusCode.Error;      // DB�g�����U�N�V�����p�X�e�[�^�X�ێ�
            int stLock = (int)ConvObjDBParam.StatusCode.Error;       // DB�A�v���P�[�V�������b�N�p�X�e�[�^�X�ێ�
            int stBackup = (int)ConvObjDBParam.StatusCode.Error;     // DB�o�b�N�A�b�v�p�X�e�[�^�X�ێ�
            int stConvMst = (int)ConvObjDBParam.StatusCode.Error;    // �R���o�[�g�����p�X�e�[�^�X�ێ�
            int stConvObj = (int)ConvObjDBParam.StatusCode.Error;    // �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^�X�V�p�X�e�[�^�X�ێ�

            // �p�����[�^�̃L���X�g
            ConvObjWork convObjWork = convObjWorkbyte as ConvObjWork;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            ConvertDoubleRelease convertDoubleRelease = null;

            string enterpriseCode = string.Empty;  // ��ƃR�[�h
            string resNm = string.Empty;           // ���b�N���\�[�X��

            try
            {
                // �f�[�^�x�[�X�ڑ�������擾
                stConnect = GetDataBaseConnect(ref sqlConnection);
                if (stConnect != (int)ConvObjDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3001;
                    // ���g���C��G���[�̏ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},stConnect:{1},status:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc GetDataBaseConnect", stConnect.ToString(), status.ToString()));
                    // �㑱�������s��Ȃ��B
                    return status;
                }

                // �g�����U�N�V�����J�n
                stTrans = GetDataBaseTransaction(ref sqlConnection, ref sqlTransaction);
                if (stTrans != (int)ConvObjDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3002; 
                    // ���g���C��G���[�̏ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},stTrans:{1},status:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc GetDataBaseTransaction", stTrans.ToString(), status.ToString()));
                    // �㑱�������s��Ȃ��B
                    return status;
                }

                // ��ƃR�[�h
                enterpriseCode = convObjWork.EnterpriseCode;

                // �A�v���P�[�V�������b�N�@���\�[�X���擾
                resNm = GetApplicationLockResourceName(ref enterpriseCode);
                if (string.IsNullOrEmpty(resNm) || string.IsNullOrEmpty(enterpriseCode))
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3003;
                    // ���g���C�ナ�\�[�X���A��ƃR�[�h�擾�ł��Ȃ��ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},resNm:{1},enterpriseCode:{2},status:{3}", "ERR PMCMN00143RA ConvObjAutoUpdateProc GetApplicationLockResourceName", resNm, enterpriseCode, status.ToString()));
                    // �㑱�������s��Ȃ��B
                    return status;
                }
                
                // �A�v���P�[�V�������b�N
                stLock = GetApplicationLock(resNm, codbp.DbApplicationLockTimeout, ref sqlConnection, ref sqlTransaction);
                if (stLock != (int)ConvObjDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3004;
                    // ���g���C��G���[�̏ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},stLock:{1},status:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc GetApplicationLock", stLock.ToString(), status.ToString()));
                    // �㑱�������s��Ȃ��B
                    return status;
                }

                // �R���o�[�g�Ώۃo�[�W�����Ǘ����ʕ��i�@��񏉊����@�Ăяo��
                // �ϊ����Ăяo��
                convertDoubleRelease = new ConvertDoubleRelease();

                // ��ƃR�[�h�ݒ�
                convertDoubleRelease.EnterpriseCode = enterpriseCode;

                // �ϊ���񏉊���
                convertDoubleRelease.ReleaseInitLib();

                // �R���o�[�g�Ώ۔��f
                if (ConvertObjEval(ref convertDoubleRelease) == ConvObjDBParam.CONVOBJ_OFF)
                {
                    // �R���o�[�g�ΏۊO
                    status = (int)ConvObjDBParam.StatusCode.NormalNotFound;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},CVM:{1},CVA:{2},status:{3},msg:{4}", "PMCMN00143RA ConvObjAutoUpdateProc ConvertObjEval", convertDoubleRelease.ConvertInfParam.ConvertVersionMst.ToString(), convertDoubleRelease.ConvertInfParam.ConvertVersionAsm.ToString(), status.ToString(), "�R���o�[�g�ΏۊO"));
                    // �㑱�������s��Ȃ��B
                    return status;
                }

                // USER_DB �S�̃o�b�N�A�b�v���擾
                stBackup = EnvFullBackupInfSearchProc(ref sqlConnection, ref sqlTransaction);
                if (stBackup == (int)ConvObjDBParam.StatusCode.Normal)
                {
                }
                else if (stBackup == (int)ConvObjDBParam.StatusCode.EnvFullBackupInfOutOfRange)
                {
                    // �S�̃o�b�N�A�b�v�͈͊O�i�Â��j
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3005;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},stBackup:{1},status:{2},msg:{3}", "ERR PMCMN00143RA ConvObjAutoUpdateProc EnvFullBackupInfSearchProc", stBackup.ToString(), status.ToString(), "�S�̃o�b�N�A�b�v�͈͊O"));
                    // �㑱�������s��Ȃ��B
                    return status;
                }
                else if (stBackup == (int)ConvObjDBParam.StatusCode.EnvFullBackupInfInterruption)
                {
                    // �S�̃o�b�N�A�b�v����Ă��Ȃ�
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3006;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},stBackup:{1},status:{2},msg:{3}", "ERR PMCMN00143RA ConvObjAutoUpdateProc EnvFullBackupInfSearchProc", stBackup.ToString(), status.ToString(), "�S�̃o�b�N�A�b�v���݂��Ȃ�"));
                    // �㑱�������s��Ȃ�
                    return status;
                }
                else
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3007;
                    // ���g���C��G���[�̏ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},stBackup:{1},status:{2},msg:{3}", "ERR PMCMN00143RA ConvObjAutoUpdateProc EnvFullBackupInfSearchProc", stBackup.ToString(), status.ToString(), "�S�̃o�b�N�A�b�v���擾�G���["));
                    // �㑱�������s��Ȃ�
                    return status;
                }

                // �}�X�^�ϊ����s
                stConvMst = VerObjMstUpdProc(enterpriseCode, convertDoubleRelease, ref sqlConnection, ref sqlTransaction);
                if ((stConvMst == (int)ConvObjDBParam.StatusCode.Normal) || (stConvMst == (int)ConvObjDBParam.StatusCode.NormalNotFound))
                {
                    // �o�[�W�������X�V
                    ConvObjVerMngWork convObjVerMngWork = new ConvObjVerMngWork();

                    // ��ƃR�[�h
                    convObjVerMngWork.EnterpriseCode = enterpriseCode;

                    // �R���o�[�g�Ώۃo�[�W����
                    convObjVerMngWork.ConvertObjVer = convertDoubleRelease.ConvertInfParam.ConvertVersionAsm.ToString();

                    // �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^�X�V
                    stConvObj = ConvObjVerMngWriteProc(ref convObjVerMngWork, convertDoubleRelease, ref sqlConnection, ref sqlTransaction);

                    // �߂�l�Z�b�g
                    convObjWorkbyte = convObjWork;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "ConvObjDB.ConvObjAutoUpdateProc SqlException", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjDB.ConvObjAutoUpdateProc Exception", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc Exception", status.ToString(), ex.Message));
            }
            finally
            {
                // �A�v���P�[�V�������b�N�����[�X
                stLock = GetApplicationLockRelease(resNm, ref sqlConnection, ref sqlTransaction);
                if (stLock != (int)ConvObjDBParam.StatusCode.Normal)
                {
                    status = (int)ConvObjDBParam.StatusCode.COAUPError3008;
                    // ���g���C��G���[�̏ꍇ�A���O�o��
                    ClcLogOutputProc(string.Format("{0},stLock:{1},status:{2}", "ERR PMCMN00143RA ConvObjAutoUpdateProc GetApplicationLockRelease", stLock.ToString(), status.ToString()));
                }

                // �g�����U�N�V�����I��
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (stConvObj == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                            //sqlTransaction.Rollback();

                            // ����
                            status = (int)ConvObjDBParam.StatusCode.Normal;
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

                // �ϊ������
                if (convertDoubleRelease != null)
                {
                    convertDoubleRelease.Dispose();
                }
            }

            return status;
        }
        #endregion // �R���o�[�g�Ώێ����X�V

        #region �f�[�^�x�[�X�ڑ�

        /// <summary>
        /// �f�[�^�x�[�X�ڑ�
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�x�[�X�ڑ�</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDataBaseConnect(ref SqlConnection sqlConnection)
        {
            int status = (int)ConvObjDBParam.StatusCode.GetDataBaseConnectError;

            sqlConnection = null;
                
            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt < codbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

                    //������
                    status = (int)ConvObjDBParam.StatusCode.GetDataBaseConnectError;
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
                        status = (int)ConvObjDBParam.StatusCode.Normal;
                    }
                }
                catch (Exception ex)
                {
                    // ��O�G���[
                    status = (int)ConvObjDBParam.StatusCode.GetDataBaseConnectExError;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA GetDataBaseConnect Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    // ������
                }

                if (status == (int)ConvObjDBParam.StatusCode.Normal)
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
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDataBaseTransaction(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.GetDataBaseTransactionError;

            sqlTransaction = null;

            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt < codbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

                    //������
                    status = (int)ConvObjDBParam.StatusCode.GetDataBaseTransactionError;
                }

                try
                {
                    // �g�����U�N�V�����J�n
                    sqlTransaction = this.CreateTransaction(ref sqlConnection);
                    if ((sqlConnection != null) && (sqlTransaction != null))
                    {
                        // ����
                        status = (int)ConvObjDBParam.StatusCode.Normal;
                    }
                }
                catch (Exception ex)
                {
                    // ��O�G���[
                    status = (int)ConvObjDBParam.StatusCode.GetDataBaseTransactionExError;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA GetDataBaseTransaction Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    // ������
                }

                if (status == (int)ConvObjDBParam.StatusCode.Normal)
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
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private string GetApplicationLockResourceName(ref string enterpriseCode)
        {
            string tmpenterpriseCode = string.Empty;
            string strResourceName = string.Empty;

            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt < codbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

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
                            if (slia == null)
                            {
                                slia = new ServerLoginInfoAcquisition();
                            }
                            tmpenterpriseCode = slia.EnterpriseCode;
                        }
                        catch (Exception ex)
                        {
                            // ���\�[�X���擾�s���ŋ󗓂�ԋp
                            strResourceName = string.Empty;
                            // ��ƃR�[�h�擾�ł��Ȃ��̂Ń��O�o�͌�Ƀ��g���C
                            ClcLogOutputProc(string.Format("{0},[{1}],ex:{2}", "ERR PMCMN00143RA GetApplicationLockResourceName serverLoginInfoAcquisition Exception", retryCnt.ToString(), ex.Message));
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
                    ClcLogOutputProc(string.Format("{0},[{1}],ex:{2}", "ERR PMCMN00143RA GetApplicationLockResourceName Exception", retryCnt.ToString(), ex.Message));
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
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetApplicationLock(string resNm, int timeout, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.GetApplicationLockError;

            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt < codbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

                    //������
                    status = (int)ConvObjDBParam.StatusCode.GetApplicationLockError;
                }

                try
                {
                    // �A�v���P�[�V�������b�N
                    status = this.Lock(resNm, timeout, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ���b�N����
                        status = (int)ConvObjDBParam.StatusCode.Normal;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        // �^�C���A�E�g
                        status = (int)ConvObjDBParam.StatusCode.GetApplicationLockTimeout;
                        // ���g���C�Ώ�
                        // ���O�o��
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00143RA GetApplicationLock Timeout", retryCnt.ToString(), status.ToString(), resNm));
                    }
                    else
                    {
                        // ���g���C�Ώ�
                        // ���O�o��
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00143RA GetApplicationLock Error", retryCnt.ToString(), status.ToString(), resNm));
                    }

                }
                catch (Exception ex)
                {
                    status = (int)ConvObjDBParam.StatusCode.GetApplicationLockExError;
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3},ex:{4}", "ERR PMCMN00143RA GetApplicationLock Exception", retryCnt.ToString(), status.ToString(), resNm, ex.Message));
                }
                finally
                {
                    // ������
                }

                if (status == (int)ConvObjDBParam.StatusCode.Normal)
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
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetApplicationLockRelease(string resNm, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.Error;

            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt < codbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

                    //������
                    status = (int)ConvObjDBParam.StatusCode.Error;
                }

                try
                {
                    // �A�v���P�[�V�������b�N�����[�X
                    status = this.Release(resNm, sqlConnection, sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �����[�X����
                        status = (int)ConvObjDBParam.StatusCode.Normal;
                    }
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        // ���g���C�Ώ�
                        // ���O�o��
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00143RA GetApplicationLockRelease Timeout", retryCnt.ToString(), status.ToString(), resNm));
                    }
                    else
                    {
                        // ���g���C�Ώ�
                        // ���O�o��
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3}", "ERR PMCMN00143RA GetApplicationLockRelease Error", retryCnt.ToString(), status.ToString(), resNm));
                    }
                }
                catch (Exception ex)
                {
                    // ���O�o��
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},resNm:{3},ex:{4}", "ERR PMCMN00143RA GetApplicationLockRelease Exception", retryCnt.ToString(), status.ToString(), resNm, ex.Message));
                }
                finally
                {
                    // ������
                }

                if (status == (int)ConvObjDBParam.StatusCode.Normal)
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }

        #endregion //�A�v���P�[�V�������b�N�����[�X

        #region �R���o�[�g�Ώ۔���

        /// <summary>
        /// �R���o�[�g�Ώ۔���
        /// </summary>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώ۔���</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// </remarks>
        private bool ConvertObjEval(ref ConvertDoubleRelease convertDoubleRelease)
        {

            // �R���o�[�g�Ώ۔���
            bool convStart = ConvObjDBParam.CONVOBJ_OFF;

            // �}�X�^�o�[�W����
            int paramConvVerMst = (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE;

            // �A�Z���u���o�[�W����
            int paramConvVerAsm = (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE;

            // �R���o�[�g�ΏۊO��Ɣ���
            bool isConvertOffEnterprise = false;

            try
            {
                // �R���o�[�g�ΏۊO��Ƃ̏ꍇ�A�������ŃR���o�[�g�ΏۊO�Ƃ���
                if (coepdb.ConvertOffEnterpriseCodeList != null)
                {
                    foreach (string convertOffEnterpriseCode in coepdb.ConvertOffEnterpriseCodeList)
                    {
                        if (convertOffEnterpriseCode == convertDoubleRelease.EnterpriseCode)
                        {
                            isConvertOffEnterprise = true;
                            //���O�o��
                            ClcLogOutputProc(string.Format("{0}", "INFO PMCMN00143RA ConvertObjEval �R���o�[�g�ΏۊO���"));
                        }
                    }
                }

                if (!isConvertOffEnterprise)
                {
                    if (codbp.ConversionTargetControl == (int)ConvObjDBParam.ConvObjCode.Decide)
                    {
                        // ���f����
                        // �}�X�^�o�[�W����
                        paramConvVerMst = convertDoubleRelease.ConvertInfParam.ConvertVersionMst;

                        // �A�Z���u���o�[�W����
                        paramConvVerAsm = convertDoubleRelease.ConvertInfParam.ConvertVersionAsm;

                        // �}�X�^�ƃA�Z���u���o�[�W�������قȂ�
                        if (paramConvVerMst != paramConvVerAsm)
                        {
                            // �R���o�[�g�Ώ�
                            convStart = ConvObjDBParam.CONVOBJ_ON;
                        }
                        // �}�X�^�o�[�W�����Ȃ�
                        else if (paramConvVerMst == (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                        {
                            // �A�Z���u���o�[�W�������� 
                            if (paramConvVerAsm != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                            {
                                // �R���o�[�g�Ώ�
                                convStart = ConvObjDBParam.CONVOBJ_ON;
                            }
                        }
                        // �}�X�^�o�[�W��������
                        else if (paramConvVerMst != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                        {
                            // �A�Z���u���o�[�W�����Ȃ�
                            if (paramConvVerAsm == (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                            {
                                // �R���o�[�g�Ώ�
                                convStart = ConvObjDBParam.CONVOBJ_ON;
                            }
                        }
                    }
                    else if (codbp.ConversionTargetControl == (int)ConvObjDBParam.ConvObjCode.ForceSetting)
                    {
                        // �����I�ɐݒ肷��
                        // �R���o�[�g�Ώ�
                        convStart = ConvObjDBParam.CONVOBJ_ON;
                    }
                    else if (codbp.ConversionTargetControl == (int)ConvObjDBParam.ConvObjCode.ForceCancel)
                    {
                        // �����I�ɉ�������
                        if (convertDoubleRelease.ConvertInfParam.ConvertVersionAsm != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                        {
                            convertDoubleRelease.ConvertInfParam.ConvertVersionAsm = (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE;
                        }

                        // �R���o�[�g�Ώ�
                        convStart = ConvObjDBParam.CONVOBJ_ON;
                    }
                    else
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                //���O�o��
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RA ConvertObjEval Exception", ex.Message));

                // ��O�X���[
                throw ex;
            }
            finally
            {
            } 
            
            return convStart;

        }

        #endregion //�R���o�[�g�Ώ۔���

        #region USER_DB�@�S�̃o�b�N�A�b�v���擾

        /// <summary>
        /// USER_DB�@�S�̃o�b�N�A�b�v���擾
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : USER_DB�@�S�̃o�b�N�A�b�v���擾</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int EnvFullBackupInfSearchProc(ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfError;
            int retryCnt = 0;

            if (codbp.DbFullBackupCheckControl == (int)ConvObjDBParam.CheckObjCode.OFF)
            {
                // �ݒ�t�@�C���ɂ��`�F�b�N���Ȃ�
                status = (int)ConvObjDBParam.StatusCode.Normal;
            }
            else
            {
                // �����^�C�v�m�F
                int statusPurchase = PurchaseInfSearchProc();
                if (statusPurchase == (int)ConvObjDBParam.CheckObjCode.OFF)
                {
                    // �`�F�b�N���Ȃ�
                    status = (int)ConvObjDBParam.StatusCode.Normal;
                }
                else if (statusPurchase == (int)ConvObjDBParam.CheckObjCode.ON)
                {
                    // �ݒ�t�@�C���ɂ��`�F�b�N����

                    StringBuilder sqlText = null;
                    SqlCommand sqlCommand = null;
                    SqlDataReader myReader = null;

                    DateTime backupFinishDate = DateTime.MinValue;
                    DateTime nowDt = DateTime.MinValue;

                    string strDBName = string.Empty;

                    // ����I������܂Ń��g���C�񐔕����g���C����
                    while (retryCnt < codbp.RetryCount)
                    {
                        // ���g���C��wait����
                        if (retryCnt > 0)
                        {
                            Thread.Sleep(codbp.RetryInterval);

                            //������
                            status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfError;
                            sqlText = null;
                            sqlCommand = null;
                            myReader = null;
                            backupFinishDate = DateTime.MinValue;
                            nowDt = DateTime.MinValue;
                            strDBName = string.Empty;
                        }

                        try
                        {
                            sqlText = new StringBuilder();
                            sqlText.Append("SELECT bs.backup_finish_date AS BS_BACKUP_FINISH_DATE " + Environment.NewLine);
                            sqlText.Append(" FROM msdb.dbo.backupset bs " + Environment.NewLine);
                            sqlText.Append(" WHERE bs.database_name = @FINDDATABESENAME " + Environment.NewLine);
                            sqlText.Append(" AND bs.backup_finish_date <= GETDATE() " + Environment.NewLine);
                            sqlText.Append(" AND bs.type = @FINDTYPE " + Environment.NewLine);
                            sqlText.Append(" ORDER BY bs.backup_finish_date DESC " + Environment.NewLine);
                            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                            //Prameter�I�u�W�F�N�g�̍쐬
                            SqlParameter findParaDatabaseName = sqlCommand.Parameters.Add("@FINDDATABESENAME", SqlDbType.NChar);
                            SqlParameter findParaType = sqlCommand.Parameters.Add("@FINDTYPE", SqlDbType.Char);

                            if (string.IsNullOrEmpty(sqlConnection.Database))
                            {
                                strDBName = ConvObjDBParam.PMUSERDBName;
                            }
                            else
                            {
                                strDBName = sqlConnection.Database;
                            }
                            findParaDatabaseName.Value = SqlDataMediator.SqlSetString(strDBName);


                            findParaType.Value = SqlDataMediator.SqlSetString(ConvObjDBParam.PMUSERDBType);

                            myReader = sqlCommand.ExecuteReader();

                            if (myReader.Read())
                            {
                                // �������ʂ���
                                backupFinishDate = SqlDataMediator.SqlGetDateTime(myReader, myReader.GetOrdinal("BS_BACKUP_FINISH_DATE"));
                                nowDt = DateTime.Now;

                                // �ݒ�t�@�C���̃o�b�N�A�b�v�`�F�b�N�͈�
                                if (codbp.DbFullBackupCheckRangeControl == (int)ConvObjDBParam.CheckObjCode.ON)
                                {
                                    // ��������
                                    if (codbp.DbFullBackupCheckRangeTime == 0)
                                    {
                                        // ���s���Ԃ��N�_��48���Ԉȓ�
                                        if (DateTime.Compare(backupFinishDate, nowDt.AddHours(-48)) >= 0)
                                        {
                                            // �`�F�b�N�͈͓�
                                            status = (int)ConvObjDBParam.StatusCode.Normal;
                                        }
                                        else
                                        {
                                            // �`�F�b�N�͈͊O
                                            status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfOutOfRange;
                                        }
                                    }
                                    else
                                    {
                                        // ���s���Ԃ��N�_�Ɏw�莞�Ԉȓ�
                                        if (DateTime.Compare(backupFinishDate, nowDt.AddHours(-1 * codbp.DbFullBackupCheckRangeTime)) >= 0)
                                        {
                                            // �`�F�b�N�͈͓�
                                            status = (int)ConvObjDBParam.StatusCode.Normal;
                                        }
                                        else
                                        {
                                            // �`�F�b�N�͈͊O
                                            status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfOutOfRange;
                                        }
                                    }
                                }
                                else
                                {
                                    // �{�������s�@�E�E�E�@�G���[�ɂ��Ȃ�
                                    status = (int)ConvObjDBParam.StatusCode.Normal;
                                }
                            }
                            else
                            {
                                // �������ʂȂ�
                                // DB�S�̃o�b�N�A�b�v����Ă��Ȃ��ꍇ�A�����𒆒f���邩����i0�F���f����A1�F���f���Ȃ��j
                                if (codbp.DbFullBackupSuspensionControl == (int)ConvObjDBParam.CheckObjCode.ON)
                                {
                                    // �`�F�b�N�͈͊O
                                    status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfInterruption;
                                }
                                else
                                {
                                    // �`�F�b�N�͈͓�
                                    status = (int)ConvObjDBParam.StatusCode.Normal;
                                }
                            }
                        }
                        catch (SqlException sqlex)
                        {
                            status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfSqlExError;
                            // ���O�o��
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA EnvFullBackupInfSearchProc SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                        }
                        catch (Exception ex)
                        {
                            status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfExError;
                            // ���O�o��
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA EnvFullBackupInfSearchProc Exception", retryCnt.ToString(), status.ToString(), ex.Message));
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

                        if ((status == (int)ConvObjDBParam.StatusCode.Normal) || (status == (int)ConvObjDBParam.StatusCode.EnvFullBackupInfOutOfRange) || (status == (int)ConvObjDBParam.StatusCode.EnvFullBackupInfInterruption))
                        {
                            // ����I���̂��߃��g���C���Ȃ�
                            break;
                        }
                        retryCnt += 1;
                    }
                }
                else
                {
                    // �����^�C�v��USB�I�v�V�����擾�G���[
                    status = statusPurchase;
                }
            }

            return status;
        }

        #endregion //USER_DB�@�S�̃o�b�N�A�b�v���擾

        #region �����^�C�v��USB�I�v�V�����擾

        /// <summary>
        /// �����^�C�v��USB�I�v�V�����擾
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����^�C�v��USB�I�v�V�����擾</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int PurchaseInfSearchProc()
        {
            int status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfPurchaseError;
            int retryCnt = 0;

            if (codbp.SearchTypeOptionCheckControl == (int)ConvObjDBParam.CheckObjCode.OFF)
            {
                // �ݒ�t�@�C���ɂ��`�F�b�N���Ȃ�
                status = (int)ConvObjDBParam.CheckObjCode.ON;
            }
            else
            {
                // ����I������܂Ń��g���C�񐔕����g���C����
                while (retryCnt <= codbp.RetryCount)
                {
                    // ���g���C��wait����
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(codbp.RetryInterval);
                    }

                    try
                    {
                        if (slia == null)
                        {
                            slia = new ServerLoginInfoAcquisition();
                        }

                        // �����^�C�v�擾
                        PurchaseStatus psK = slia.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_SUB_K_Type);
                        PurchaseStatus psJ = slia.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_SUB_J_Type);
                        PurchaseStatus psM = slia.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_SUB_M_Type);

                        if ((psK == PurchaseStatus.Contract) && (psJ != PurchaseStatus.Contract) && (psM != PurchaseStatus.Contract))
                        {
                            // �����^�C�v�iK�^�C�v�FON�AJ�^�C�v�FOFF�AM�^�C�v�FOFF�j�̏ꍇ�A�`�F�b�N���Ȃ�
                            status = (int)ConvObjDBParam.CheckObjCode.OFF;
                        }
                        else
                        {
                            status = (int)ConvObjDBParam.CheckObjCode.ON;
                        }
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConvObjDBParam.StatusCode.EnvFullBackupInfPurchaseExError;

                        // ���O�o��
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "PMCMN00143RA PurchaseInfSearchProc Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                    }

                    if ((status == (int)ConvObjDBParam.CheckObjCode.ON) || (status == (int)ConvObjDBParam.CheckObjCode.OFF))
                    {
                        // ����I���̂��߃��g���C���Ȃ�
                        break;
                    }
                    retryCnt += 1;
                }
            }
            return status;
        }

        #endregion //�����^�C�v��USB�I�v�V�����擾


        #region ���i�}�X�^�R���o�[�g
        /// <summary>
        /// ���i�}�X�^�R���o�[�g
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�R���o�[�g</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int VerObjMstUpdProc(string enterpriseCode, ConvertDoubleRelease convertDoubleRelease, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.VerObjMstUpdProcError;
            int stMstConv = (int)ConvObjDBParam.StatusCode.MstUpdExError;
            int stBackup = (int)ConvObjDBParam.StatusCode.DataTableBackupExError;


            StringBuilder sqlText = null;
            SqlCommand sqlCommand = null;
            SqlDataAdapter sda = null;
            DataTable dt = null;
            DataRow dr = null;
            SqlBulkCopy sbc = null;
            int iRowCnt = 0;
            SqlDataReader sdr = null;
            int mstUpdateCnt = 0; // �X�V�p�}�X�^�擾����

            string tmpTable = string.Empty;

            int retryCnt = 0;

            // ����I������܂Ń��g���C�񐔕����g���C����
            while (retryCnt < codbp.RetryCount)
            {
                // ���g���C��wait����
                if (retryCnt > 0)
                {
                    Thread.Sleep(codbp.RetryInterval);

                    //������
                    status = (int)ConvObjDBParam.StatusCode.VerObjMstUpdProcError;
                    stMstConv = (int)ConvObjDBParam.StatusCode.MstUpdExError;
                    stBackup = (int)ConvObjDBParam.StatusCode.DataTableBackupExError;
                    sqlText = null;
                    sqlCommand = null;
                    sda = null;
                    dt = null;
                    dr = null;
                    sbc = null;
                    iRowCnt = 0;
                    sdr = null;
                    mstUpdateCnt = 0; // �X�V�p�}�X�^�擾����
                    tmpTable = string.Empty;
                }

                try
                {
                    // �ꎞ�e�[�u�����쐬
                    tmpTable = "#CONVOBJTMPTBL" + Guid.NewGuid().ToString().Replace("-", string.Empty);

                    #region XACT_ABORT ON
                    
                    status = (int)ConvObjDBParam.StatusCode.XactAbortOn;

                    try
                    {
                        sqlText = new StringBuilder();
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                        // ��O�̑Ή��̂��߃I�v�V������ON�ɂ��Ă���
                        // ��O���b�Z�[�W�F�u�����̌��ʃZ�b�g���܂ވꊇ�}���́AXACT_ABORT ���I���ɂ��Ď��s����K�v������܂��B�v
                        // ��O���FDataReader���[�v����sbc.WriteToServer(dt);
                        // OutOfMemory�Ή���1�s���̏����ɂ������ߔ�������悤�ɂȂ���
                        # region [SELECT��]
                        sqlText.Append("SET XACT_ABORT ON " + Environment.NewLine);
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (SqlException sqlex)
                    {
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA XactAbortOn SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                        // ��O�X���[
                        throw sqlex;
                    }
                    catch (Exception ex)
                    {
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA XactAbortOn Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                        // ��O�X���[
                        throw ex;
                    }
                    finally
                    {
                    }

                    #endregion XACT_ABORT ON

                    #region ���i�}�X�^�����擾

                    status = (int)ConvObjDBParam.StatusCode.MstCntGet;

                    try
                    {

                        sqlText = new StringBuilder();
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                        // ���i�}�X�^�S���擾

                        # region [SELECT��]
                        sqlText.Append("SELECT " + Environment.NewLine);
                        sqlText.Append(" COUNT(*) AS MSTALLCOUNT" + Environment.NewLine);
                        sqlText.Append(" FROM GOODSPRICEURF " + Environment.NewLine);
                        sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = enterpriseCode;

                        sdr = sqlCommand.ExecuteReader();


                        if (sdr.Read())
                        {
                            coclcldb.MstCnt = SqlDataMediator.SqlGetInt32(sdr, sdr.GetOrdinal("MSTALLCOUNT"));
                        }
                        else
                        {
                            coclcldb.MstCnt = 0;
                        }

                        // DataReader�N���A
                        if (sdr != null && !sdr.IsClosed)
                        {
                            sdr.Close();
                        }

                    }
                    catch (SqlException sqlex)
                    {
                        status = (int)ConvObjDBParam.StatusCode.MstCntGetSqlExError;
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA MstCntGet SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                        // ��O�X���[
                        throw sqlex;
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConvObjDBParam.StatusCode.MstCntGetExError;
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA MstCntGet Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                        // ��O�X���[
                        throw ex;
                    }

                    #endregion // ���i�}�X�^�����擾

                    # region ���i�}�X�^�擾

                    status = (int)ConvObjDBParam.StatusCode.MstGet;

                    try
                    {

                        sqlText = new StringBuilder();
                        sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                        sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

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
                        findParaEnterpriseCode.Value = enterpriseCode;

                        sdr = sqlCommand.ExecuteReader();
                    }
                    catch (SqlException sqlex)
                    {
                        status = (int)ConvObjDBParam.StatusCode.MstGetSqlExError;
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA MstGet SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                        // ��O�X���[
                        throw sqlex;
                    }
                    catch (Exception ex)
                    {
                        status = (int)ConvObjDBParam.StatusCode.MstGetExError;
                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA MstGet Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                        // ��O�X���[
                        throw ex;
                    }

                    # endregion  // ���i�}�X�^�擾

                    // �X�V�Ώۂ�1���ȏ�̏ꍇ
                    if (sdr.HasRows)
                    {
                        #region DataTable�쐬
                        status = (int)ConvObjDBParam.StatusCode.DataTableCreate;

                        try
                        {
                            sqlCommand = new SqlCommand(string.Empty, sqlConnection, sqlTransaction);
                            dt = CreateSchemaDataTable(sqlCommand);
                        }
                        catch (Exception ex)
                        {
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA DataTableCreate Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            throw ex;
                        }
                        finally
                        {
                        }
                        #endregion // DataTable�쐬

                        #region �ꎞ�e�[�u���쐬

                        status = (int)ConvObjDBParam.StatusCode.TempTableCreate;

                        try
                        {
                            sqlText = new StringBuilder();
                            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                            sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                            sqlText.Append("SELECT " + Environment.NewLine);
                            sqlText.Append(" * " + Environment.NewLine);
                            sqlText.Append(" INTO " + Environment.NewLine);
                            sqlText.Append(tmpTable + Environment.NewLine);
                            sqlText.Append(" FROM " + Environment.NewLine);
                            sqlText.Append("  GOODSPRICEURF " + Environment.NewLine);
                            sqlText.Append(" WHERE " + Environment.NewLine);
                            sqlText.Append("  1 = 0 " + Environment.NewLine);

                            sqlCommand.CommandText = sqlText.ToString();

                            iRowCnt = sqlCommand.ExecuteNonQuery();

                        }
                        catch (SqlException sqlex)
                        {
                            status = (int)ConvObjDBParam.StatusCode.TempTableCreateSqlExError;
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA TempTableCreate SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                            // ��O�X���[
                            throw sqlex;
                        }
                        catch (Exception ex)
                        {
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA TempTableCreate Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            // ��O�X���[
                            throw ex;
                        }

                        #endregion // �ꎞ�e�[�u���쐬

                        #region ���i�}�X�^�P��o�b�N�A�b�v�C���X�^���X����
                        status = (int)ConvObjDBParam.StatusCode.ConvObjBackupCreate;
                        try
                        {
                            cobdb = new ConvObjBackupDB();
                        }
                        catch (Exception ex)
                        {
                            status = (int)ConvObjDBParam.StatusCode.ConvObjBackupCreateExError;
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA new ConvObjBackupDB Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            // ��O�X���[
                            throw ex;
                        }
                        finally
                        {
                        }
                        #endregion // ���i�}�X�^�P��o�b�N�A�b�v�C���X�^���X����

                        while (sdr.Read())
                        {
                            mstUpdateCnt++;

                            #region ���i�}�X�^�W�J

                            status = (int)ConvObjDBParam.StatusCode.DataTableDeploy;

                            try
                            {
                                dr = DeployDataTable(sdr, dt);
                            }
                            catch (Exception ex)
                            {
                                ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA DataTableDeploy Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            }
                            finally
                            {
                            }

                            #endregion // ���i�}�X�^�W�J

                            #region ���i�}�X�^��P��o�b�N�A�b�v

                            status = (int)ConvObjDBParam.StatusCode.DataTableBackup;

                            try
                            {
                                if (codbp.MstBackupControl == (int)ConvObjDBParam.CheckObjCode.ON)
                                {
                                    // �擾�������i�}�X�^��P��o�b�N�A�b�v
                                    if (cobdb != null)
                                    {
                                        if (convertDoubleRelease.ConvertInfParam.ConvertVersionMst != (int)ConvertVersionManager.ConvertVersion.CT_CONVERT_VERSION_NONE)
                                        {
                                            DataRow drBk = dt.NewRow();
                                            drBk.ItemArray = dr.ItemArray;
                                            // �R���o�[�g�ς݂̏ꍇ�A�������ăo�b�N�A�b�v����
                                            convertDoubleRelease.EnterpriseCode = Convert.ToString(drBk["ENTERPRISECODERF"]);
                                            convertDoubleRelease.GoodsMakerCd = Convert.ToInt32(drBk["GOODSMAKERCDRF"]);
                                            convertDoubleRelease.GoodsNo = Convert.ToString(drBk["GOODSNORF"]);
                                            convertDoubleRelease.ConvertSetParam = Convert.ToDouble(drBk["LISTPRICERF"]);

                                            convertDoubleRelease.ReleaseProc();

                                            drBk["LISTPRICERF"] = convertDoubleRelease.ConvertInfParam.ConvertGetParam;

                                            stBackup = cobdb.ConvObjBackup(drBk);

                                        }
                                        else
                                        {
                                            stBackup = cobdb.ConvObjBackup(dr);
                                        }

                                        if (stBackup != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                                        {
                                            // �P��o�b�N�A�b�v���ɃG���[����
                                            status = (int)ConvObjDBParam.StatusCode.DataTableBackupError2027;
                                            // ���O�o��
                                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},stBackup:{3}", "ERR PMCMN00143RA ConvObjBackupDB Error", retryCnt.ToString(), status.ToString(), stBackup.ToString()));
                                        }
                                    }
                                    else
                                    {
                                        // �P��o�b�N�A�b�v���ɃG���[����
                                        status = (int)ConvObjDBParam.StatusCode.DataTableBackupError2028;
                                        // ���O�o��
                                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},stBackup:{3}", "ERR PMCMN00143RA ConvObjBackupDB Error null", retryCnt.ToString(), status.ToString(), stBackup.ToString()));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // �P��o�b�N�A�b�v���ɃG���[����
                                status = (int)ConvObjDBParam.StatusCode.DataTableBackupExError;
                                ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA ConvObjBackupDB Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                                // ��O�X���[
                                throw ex;
                            }

                            #endregion // ���i�}�X�^��P��o�b�N�A�b�v

                            if (stBackup == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                #region �ϊ�

                                status = (int)ConvObjDBParam.StatusCode.DataTableConv;

                                try
                                {
                                    convertDoubleRelease.EnterpriseCode = Convert.ToString(dr["ENTERPRISECODERF"]);
                                    convertDoubleRelease.GoodsMakerCd = Convert.ToInt32(dr["GOODSMAKERCDRF"]);
                                    convertDoubleRelease.GoodsNo = Convert.ToString(dr["GOODSNORF"]);
                                    convertDoubleRelease.ConvertSetParam = Convert.ToDouble(dr["LISTPRICERF"]);

                                    convertDoubleRelease.ReleaseConvertProc();

                                    dr["LISTPRICERF"] = convertDoubleRelease.ConvertInfParam.ConvertGetParam;

                                    // �ϊ���DataTable�ɒǉ�
                                    dt.Rows.Add(dr);

                                }
                                catch (Exception ex)
                                {
                                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA DataTableConv Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                                    // ��O�X���[
                                    throw ex;
                                }

                                #endregion // �ϊ�

                                #region �ϊ���DataTable���ꎞ�e�[�u����BulkInsert

                                if (mstUpdateCnt >= codbp.MstUpdateBreakCount)
                                {
                                    status = (int)ConvObjDBParam.StatusCode.TempTableIns;

                                    try
                                    {
                                        using (sbc = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, sqlTransaction))
                                        {
                                            sbc.DestinationTableName = tmpTable;
                                            sbc.BulkCopyTimeout = codbp.DbCommandTimeout;
                                            sbc.WriteToServer(dt);
                                            sbc.Close();
                                        }
                                    }
                                    catch (SqlException sqlex)
                                    {
                                        status = (int)ConvObjDBParam.StatusCode.TempTableInsSqlExError;
                                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA BulkInsert SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                                        // ��O�X���[
                                        throw sqlex;
                                    }
                                    catch (Exception ex)
                                    {
                                        ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA BulkInsert Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                                        // ��O�X���[
                                        throw ex;
                                    }

                                    // DataTable���N���A����
                                    if (dt != null)
                                    {
                                        dt.Clear();
                                    }

                                    mstUpdateCnt = 0;
                                }
                                #endregion // �ϊ���DataTable���ꎞ�e�[�u����BulkInsert

                            }

                            // �����s�����C���N�������g
                            coclcldb.UpdateMstCnt++;
                        }

                        if (stBackup == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���[�v�㏈��

                            #region �o�b�N�A�b�vstream���
                            status = (int)ConvObjDBParam.StatusCode.ConvObjBackupDispose;
                            try
                            {
                                cobdb.Dispose();
                                cobdb = null;
                            }
                            catch (Exception ex)
                            {
                                status = (int)ConvObjDBParam.StatusCode.ConvObjBackupDisposeExError;
                                ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA ConvObjBackupDispose Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            }
                            finally
                            {
                            }
                            #endregion // �o�b�N�A�b�vstream���

                            #region �ϊ���DataTable���ꎞ�e�[�u����BulkInsert

                            if (dt.Rows.Count > 0)
                            {
                                status = (int)ConvObjDBParam.StatusCode.TempTableLastIns;

                                try
                                {
                                    using (sbc = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, sqlTransaction))
                                    {
                                        sbc.DestinationTableName = tmpTable;
                                        sbc.BulkCopyTimeout = codbp.DbCommandTimeout;
                                        sbc.WriteToServer(dt);
                                        sbc.Close();
                                    }
                                }
                                catch (SqlException sqlex)
                                {
                                    status = (int)ConvObjDBParam.StatusCode.TempTableLastInsSqlExError;
                                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA LastBulkInsert SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                                    // ��O�X���[
                                    throw sqlex;
                                }
                                catch (Exception ex)
                                {
                                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA LastBulkInsert Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                                    // ��O�X���[
                                    throw ex;
                                }

                                // �s�v�ɂȂ���DataTable���N���A����
                                if (dt != null)
                                {
                                    dt.Clear();
                                    dt.Dispose();
                                    dt = null;
                                }
                            }

                            #endregion // �ϊ���DataTable���ꎞ�e�[�u����BulkInsert

                            #region ���i�}�X�^�X�V

                            status = (int)ConvObjDBParam.StatusCode.MstUpd;

                            try
                            {
                                sqlText = new StringBuilder();
                                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                                sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                                sqlText.Append("UPDATE GPU " + Environment.NewLine);
                                sqlText.Append(" SET " + Environment.NewLine);
                                sqlText.Append(" GPU.LISTPRICERF = UT.LISTPRICERF " + Environment.NewLine);
                                sqlText.Append(" FROM " + Environment.NewLine);
                                sqlText.Append(" GOODSPRICEURF GPU " + Environment.NewLine);
                                sqlText.Append(" JOIN " + tmpTable + " UT " + Environment.NewLine);
                                sqlText.Append(" ON  GPU.ENTERPRISECODERF = UT.ENTERPRISECODERF " + Environment.NewLine);
                                sqlText.Append(" AND GPU.GOODSMAKERCDRF = UT.GOODSMAKERCDRF " + Environment.NewLine);
                                sqlText.Append(" AND GPU.GOODSNORF = UT.GOODSNORF " + Environment.NewLine);
                                sqlText.Append(" AND GPU.PRICESTARTDATERF = UT.PRICESTARTDATERF " + Environment.NewLine);

                                sqlCommand.CommandText = sqlText.ToString();

                                iRowCnt = sqlCommand.ExecuteNonQuery();

                                if (iRowCnt > 0)
                                {
                                    stMstConv = (int)ConvObjDBParam.StatusCode.Normal;
                                }
                                else
                                {
                                    // �X�V�ΏۂȂ�
                                    stMstConv = (int)ConvObjDBParam.StatusCode.NormalNotFound;
                                }

                            }
                            catch (SqlException sqlex)
                            {
                                status = (int)ConvObjDBParam.StatusCode.MstUpdSqlExError;
                                ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA MstUpd SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                                // ��O�X���[
                                throw sqlex;
                            }
                            catch (Exception ex)
                            {
                                ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA MstUpd Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                                // ��O�X���[
                                throw ex;
                            }
                            #endregion // ���i�}�X�^�X�V
                        }

                        #region �ꎞ�e�[�u���폜

                        status = (int)ConvObjDBParam.StatusCode.TempTableDelete;

                        try
                        {
                            sqlText = new StringBuilder();
                            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                            sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                            sqlText.Append("DROP TABLE " + tmpTable + " " + Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();

                            sqlCommand.ExecuteNonQuery();

                            status = (int)ConvObjDBParam.StatusCode.Normal;
                            if (stMstConv == (int)ConvObjDBParam.StatusCode.NormalNotFound)
                            {
                                status = stMstConv;
                            }

                        }
                        catch (SqlException sqlex)
                        {
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA TempTableDelete SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                            status = (int)ConvObjDBParam.StatusCode.TempTableDeleteSqlExError;
                            // ��O�X���[
                            throw sqlex;
                        }
                        catch (Exception ex)
                        {
                            ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA TempTableDelete Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                            // ��O�X���[
                            throw ex;
                        }
                        #endregion // �ꎞ�e�[�u���폜
                    }
                    else
                    {
                        // �X�V�ΏۂȂ�
                        status = (int)ConvObjDBParam.StatusCode.NormalNotFound;
                    }
                }
                catch (SqlException sqlex)
                {
                    //���N���X�ɗ�O��n���ď������Ă��炤
                    status = base.WriteSQLErrorLog(sqlex, "ConvObjDB.VerObjMstUpdProc SqlException", status);
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},sqlex:{3}", "ERR PMCMN00143RA VerObjMstUpdProc SqlException", retryCnt.ToString(), status.ToString(), sqlex.Message));
                }
                catch (Exception ex)
                {
                    base.WriteErrorLog(ex, "ConvObjDB.VerObjMstUpdProc ex", status);
                    ClcLogOutputProc(string.Format("{0},[{1}],status:{2},ex:{3}", "ERR PMCMN00143RA VerObjMstUpdProc Exception", retryCnt.ToString(), status.ToString(), ex.Message));
                }
                finally
                {
                    if (sqlCommand != null)
                    {
                        sqlCommand.Cancel();
                        sqlCommand.Dispose();
                    }

                    if (sda != null)
                    {
                        sda.Dispose();
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
                }

                if ((status == (int)ConvObjDBParam.StatusCode.Normal) || (status == (int)ConvObjDBParam.StatusCode.NormalNotFound))
                {
                    // ����I���̂��߃��g���C���Ȃ�
                    break;
                }
                retryCnt += 1;
            }

            return status;
        }
        #endregion  //���i�}�X�^�R���o�[�g

        #region �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^����ǉ��E�X�V
        /// <summary>
        /// �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="convObjVerMngWork">�ǉ��E�X�V����R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^���</param>
        /// <param name="convertDoubleRelease">���l�ϊ�����</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int ConvObjVerMngWriteProc(ref ConvObjVerMngWork convObjVerMngWork, ConvertDoubleRelease convertDoubleRelease, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConvObjDBParam.StatusCode.VerObjVerMstUpd;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ConvObjVerMngWork al = new ConvObjVerMngWork();

            try
            {
                if (convObjVerMngWork != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                    # region [SELECT��]
                    sqlText.Append("SELECT CREATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDATEDATETIMERF" + Environment.NewLine);
                    sqlText.Append("    ,ENTERPRISECODERF" + Environment.NewLine);
                    sqlText.Append("    ,FILEHEADERGUIDRF" + Environment.NewLine);
                    sqlText.Append("    ,UPDEMPLOYEECODERF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID1RF" + Environment.NewLine);
                    sqlText.Append("    ,UPDASSEMBLYID2RF" + Environment.NewLine);
                    sqlText.Append("    ,LOGICALDELETECODERF" + Environment.NewLine);
                    sqlText.Append("    ,CONVERTOBJVERRF" + Environment.NewLine);
                    sqlText.Append(" FROM CONVOBJVERMNGRF WITH (READUNCOMMITTED)" + Environment.NewLine);
                    sqlText.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODERF " + Environment.NewLine);
                    sqlCommand.CommandText = sqlText.ToString();
                    # endregion

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = convObjVerMngWork.EnterpriseCode;

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        # region [UPDATE��]
                        StringBuilder sqlText_UPDATE = new StringBuilder();
                        sqlText_UPDATE.Append("UPDATE CONVOBJVERMNGRF SET" + Environment.NewLine);
                        sqlText_UPDATE.Append("    UPDATEDATETIMERF=@UPDATEDATETIME," + Environment.NewLine);
                        sqlText_UPDATE.Append("    CONVERTOBJVERRF=@CONVERTOBJVER" + Environment.NewLine);
                        sqlText_UPDATE.Append(" WHERE ENTERPRISECODERF=@ENTERPRISECODE " + Environment.NewLine);
                        sqlCommand.CommandText = sqlText_UPDATE.ToString();
                        # endregion

                        // �X�V�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)convObjVerMngWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetUpdateHeader(ref flhd, obj);
                    }
                    else
                    {

                        # region [INSERT��]
                        StringBuilder sqlText_INSERT = new StringBuilder();
                        sqlText_INSERT.Append("INSERT INTO CONVOBJVERMNGRF " + Environment.NewLine);
                        sqlText_INSERT.Append(" (CREATEDATETIMERF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,UPDATEDATETIMERF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,ENTERPRISECODERF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,FILEHEADERGUIDRF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,UPDEMPLOYEECODERF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,UPDASSEMBLYID1RF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,UPDASSEMBLYID2RF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,LOGICALDELETECODERF " + Environment.NewLine);
                        sqlText_INSERT.Append(" ,CONVERTOBJVERRF " + Environment.NewLine);
                        sqlText_INSERT.Append("  ) VALUES ( " + Environment.NewLine);
                        sqlText_INSERT.Append("   @CREATEDATETIME " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@UPDATEDATETIME " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@ENTERPRISECODE " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@FILEHEADERGUID " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@UPDEMPLOYEECODE " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@UPDASSEMBLYID1 " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@UPDASSEMBLYID2 " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@LOGICALDELETECODE " + Environment.NewLine);
                        sqlText_INSERT.Append("  ,@CONVERTOBJVER " + Environment.NewLine);
                        sqlText_INSERT.Append("  )" + Environment.NewLine);
                        sqlCommand.CommandText = sqlText_INSERT.ToString();
                        # endregion

                        // �o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)convObjVerMngWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraConvertObjVer = sqlCommand.Parameters.Add("@CONVERTOBJVER", SqlDbType.NVarChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(convObjVerMngWork.CreateDateTime);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(convObjVerMngWork.UpdateDateTime);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(convObjVerMngWork.FileHeaderGuid);
                    paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.UpdEmployeeCode);
                    paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.UpdAssemblyId1);
                    paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.UpdAssemblyId2);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(convObjVerMngWork.LogicalDeleteCode);
                    paraConvertObjVer.Value = SqlDataMediator.SqlSetString(convObjVerMngWork.ConvertObjVer);

                    sqlCommand.ExecuteNonQuery();
                    al = convObjVerMngWork;

                }

                status = (int)ConvObjDBParam.StatusCode.Normal;

            }
            catch (SqlException sqlex)
            {
                status = (int)ConvObjDBParam.StatusCode.VerObjVerMstUpdSqlExError;
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "ConvObjDB.ConvObjVerMngWriteProc SqlException", status);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00143RA ConvObjVerMngWriteProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjDB.ConvObjVerMngWriteProc", status);
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00143RA ConvObjVerMngWriteProc Exception", status.ToString(), ex.Message));
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

            convObjVerMngWork = al;

            return status;
        }
        #endregion  //�R���o�[�g�Ώۃo�[�W�����Ǘ��}�X�^����ǉ��E�X�V

        #region DataTable�쐬
        /// <summary>
        /// ���i�}�X�^�\����DataTable���쐬���܂��B
        /// </summary>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <returns>DataTable�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : DataTable�쐬</br>
        /// <br>Programmer : ���X�ؘj</br>
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

                sqlCommand.CommandTimeout = codbp.DbCommandTimeout;

                // ���i�}�X�^�e�[�u�����擾
                sda = new SqlDataAdapter();
                sda.SelectCommand = sqlCommand;
                sda.FillSchema(dt, SchemaType.Source);
                
                // �啶������������ʂ���
                dt.CaseSensitive = true;
            }
            catch (SqlException sqlex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RA CreateSchemaDataTable SqlException", sqlex.Message));
                throw sqlex;
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RA CreateSchemaDataTable Exception", ex.Message));
                throw ex;
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
        /// <br>Programmer : ���X�ؘj</br>
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
            catch (SqlException sqlex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RA DeployDataTable SqlException", sqlex.Message));
                throw sqlex;
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RA DeployDataTable Exception", ex.Message));
                throw ex;
            }
            finally
            {
            }

            return dr;
        }
        #endregion // DataTable�쐬

        #region �R���o�[�g�Ώێ����X�VWebRequest
        /// <summary>
        /// �R���o�[�g�Ώێ����X�VWebRequest
        /// </summary>
        /// <param name="checkParam">�`�F�b�N�p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώێ����X�VWebRequest</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int ConvObjDBWebRequestProc(int checkParam)
        {
            int status = (int)ConvObjDBParam.StatusCode.Normal;
            try
            {
                if (codbp.WebAccessCheckControl == (int)ConvObjDBParam.CheckObjCode.ON)
                {
                    // WebRequest Access Check
                    if (codbwr == null)
                    {
                        codbwr = new ConvObjDBWebRequest();
                    }
                    codbwr.ConvObjDBWebReqRes(checkParam);
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
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private void ClcLogOutputProc(string message)
        {
            if (codbp.ClcLogOutputInfo == (int)ConvObjDBParam.OutputCode.ON)
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
        /// <br>Programmer : ���X�ؘj</br>
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
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int WriteOprtnHisLogProc(OprtnHisLogWork writeParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                if (this.OperationLoggingDB == null)
                    this.OperationLoggingDB = new OprtnHisLogDB();

                object param = (object)writeParam;
                status = this.OperationLoggingDB.Write(ref param);
            }
            catch (SqlException sqlex)
            {
                status = base.WriteSQLErrorLog(sqlex);
                ClcLogOutputProc(string.Format("{0},status:{1},sqlex:{2}", "ERR PMCMN00143RA WriteOprtnHisLogProc SqlException", status.ToString(), sqlex.Message));
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00143RA WriteOprtnHisLogProc Exception", status.ToString(), ex.Message));
            }

            return (int)status;
        }
        #endregion  //���샍�O�o��

        #endregion // IConvObjDB �����o

    }


}

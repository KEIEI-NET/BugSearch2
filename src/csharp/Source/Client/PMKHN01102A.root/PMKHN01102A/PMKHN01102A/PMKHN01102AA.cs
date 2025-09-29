//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �񋟃f�[�^�폜�����A�N�Z�X�N���X
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��č폜�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �񋟃f�[�^�폜�����X�N���X
    /// </summary>
    /// <remarks>
    /// Note       : �񋟃f�[�^�폜�����ł��B<br />
    /// Programmer : ������<br />
    /// Date       : 2009.06.16<br />
    /// </remarks>
    public class OfferDataDeleteAcs
    {
        # region �� Constructor ��
        /// <summary>
        /// �񋟃f�[�^�폜�����A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �񋟃f�[�^�폜�����A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public OfferDataDeleteAcs()
        {
        }
        # endregion �� Constructor ��

        #region �� Const Memebers ��
        // ��ʋ@�\ID
        private const string PROGRAM_ID = "PMKHN01100UA";
        // ��ʋ@�\����
        private const string PROGRAM_NAME = "�񋟃f�[�^�폜����";
        #endregion �� Const Memebers ��

        # region �� Private Members ��

        // �񋟍폜�Ώے�`���(Remote)
        private OfferDataDeleteWork _offerDataDeleteWork;
        // �񋟃f�[�^�폜�����C���^�t�F�[�X
        private IOfferDataDeleteDB _iOfferDataDeleteDB;
        // �f�[�^�N���A�����C���^�t�F�[�X
        private IDataClearDB _iDataClearDB;
        // �񋟍폜�Ώے�`���
        private OfferData _offerDataObj;

        # endregion �� Private Members ��

        #region �� Private Method
        #region �� �񋟃f�[�^�폜����
        #region �� �f�[�^�폜����
        /// <summary>
        /// �񋟃f�[�^�폜����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public int Delete(out string errMsg)
        {
            return this.DeleteProc(out errMsg);
        }

        /// <summary>
        ///�񋟃f�[�^�폜����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        private int DeleteProc(out string errMsg)
        {
            // �S�ăe�[�u��������̏��
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // �ϐ�������
            this._offerDataObj = new OfferData();
            this._offerDataDeleteWork = new OfferDataDeleteWork();

            // �񋟍폜�Ώے�`���擾
            ArrayList _offerDataList = new ArrayList();
            _offerDataList = _offerDataObj.GetOfferDataList();

            // ���엚�����O��`
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();

            // �񋟃f�[�^�폜�����C���^�t�F�[�X
            _iOfferDataDeleteDB = (IOfferDataDeleteDB)MediationOfferDataDeleteDB.GetOfferDataDeleteDB();

            // �f�[�^�N���A�����C���^�t�F�[�X
            _iDataClearDB = (IDataClearDB)MediationDataClearDB.GetDataClearDB();

            errMsg = string.Empty;
            // Remote�폜����
            // �����R�[�h��0�F�������N���A
            try
            {
                object _offerDataListObj = _offerDataList as object;
                int subStatus0 = _iOfferDataDeleteDB.DeleteOfferData(ref _offerDataListObj);
                // �����R�[�h��9�F�f�[�^�N���A�����Ώ�
                int subStatus9 = _iDataClearDB.ClearDataByCode9(LoginInfoAcquisition.EnterpriseCode);
                // �T�[�o�[�̃��W�X�g���X�V����
                int regeditStatus = _iOfferDataDeleteDB.ServerRegeditUpdate();

                // �����R�[�h��0�̃e�[�u���폜�������s
                if (subStatus0 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (OfferDataDeleteWork _offerDataDeleteWork in _offerDataListObj as ArrayList)
                    {
                        if (_offerDataDeleteWork.Result.Equals("NG"))
                        {
                            // �G���[�ƂȂ����ꍇ�A���엚�����O��������
                            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, _offerDataDeleteWork.TableName + " �񋟍폜���� �G���[", string.Empty);

                        }
                    }
                }

                // ���i�����X�V�����f�[�^�X�V�������s
                if (subStatus9 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �T�[�o�[�̃��W�X�g���X�V�������s�A���O���������ށB
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���i�����X�V�����f�[�^ �񋟍폜���� �G���[", string.Empty);
                }

                // �T�[�o�[�̃��W�X�g���X�V�������s
                if (regeditStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �T�[�o�[�̃��W�X�g���X�V�������s�A���O���������ށB
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "���ݒ񋟃o�[�W���� ������ �G���[", string.Empty);
                }

                // �P�e�[�u�����G���[���Ȃ��A�����W�X�g���X�V���G���[�ɂȂ�Ȃ������ꍇ
                if (subStatus0 == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    subStatus9 == (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    regeditStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ����I�������|�A�P���̃��O���������ށB
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "�񋟍폜���� ����I��", string.Empty);
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion
        #endregion �� �񋟃f�[�^�폜����
        #endregion �� Private Method
    }
}

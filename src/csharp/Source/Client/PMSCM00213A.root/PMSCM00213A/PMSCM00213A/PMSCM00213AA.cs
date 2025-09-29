//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����v���Ǘ� �A�N�Z�X�N���X
// �v���O�����T�v   : �����v���Ǘ� �A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright 2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/08/01   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����v���Ǘ� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �����v���Ǘ� �A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2014/08/01</br>
    /// </remarks>
    public class SynchExecuteAcs
    {
        # region ��Private Member
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ISynchExecuteMngDB _iSynchExecuteMngDB;
        # endregion

        # region ��Constracter
        /// <summary>
        /// �����v���Ǘ� �A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����v���Ǘ��A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public SynchExecuteAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                _iSynchExecuteMngDB = (ISynchExecuteMngDB)MediationSynchExecuteMngDB.GetSynchExecuteMngDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                _iSynchExecuteMngDB = null;
            }
        }

        /// <summary>
        /// �ő�Ď��s�񐔂̎擾����
        /// </summary>
        /// <param name="maxRetryCount">�ő�Ď��s��</param>
        /// <remarks>
        /// <br>Note       : �ő�Ď��s�񐔂̎擾�������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public void GetMaxRetryCount(out int maxRetryCount)
        {
            maxRetryCount = 0;

            try
            {
                _iSynchExecuteMngDB.GetMaxRetryCount(out maxRetryCount);
            }
            catch
            {
                maxRetryCount = 0;
            }
        }

        /// <summary>
        /// �w��e�[�u�������v������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableIDList">�e�[�u�����i�����j</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �w��e�[�u�������v�������B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SyncReqExecuteForTable(string enterpriseCode, ArrayList tableIDList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                object param = (object)tableIDList;

                status = _iSynchExecuteMngDB.SyncReqExecuteForTable(enterpriseCode, param);
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �����v���ĊJ����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����v���ĊJ�����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SyncReqReExecute()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                status = _iSynchExecuteMngDB.SyncReqReExecute();
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }


        /// <summary>
        /// �ϊ��v������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public void TranslateExecute()
        {
            _iSynchExecuteMngDB.TranslateExecute();
        }

        /// <summary>
        /// ����N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���C�A���g�ɓo�^����铯�������N����ʂ���Ăяo����܂�</br>
        /// <br>             �I�v�V�������r������ǉ��ɂȂ����ꍇ��A���񓯊����s���</br>
        /// <br>             �������s�N���X��Instance�����A�������������삷��l�ɂ��܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public void RegularStart()
        {
            string url = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCM_PmKvmAP);
            url += LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCM_PmKvmAP, ConstantManagement_SF_PRO.IndexCode_SCM_PmKvm_WebPath);

            _iSynchExecuteMngDB.RegularStart(url);
        }
        # endregion
    }
}

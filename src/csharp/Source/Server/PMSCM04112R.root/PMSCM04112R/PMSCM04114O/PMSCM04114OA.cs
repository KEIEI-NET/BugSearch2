//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �����󋵊m�F DBRemoteObject�C���^�[�t�F�[�X
//                  :   PMSCM04114O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   �c����
// Date             :   2014/08/01
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/08/01   �C�����e : �V�K�쐬
//----------------------------------------------------------------------
// Programmer       :   �g��
//                  :   2014/07/14 SCM������
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11070136-00  �쐬�S�� : �c����
// �� �� ��  2014/09/03   �C�����e : Redmine#43408
//                                   �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����󋵊m�F DBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����󋵊m�F DBRemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISynchConfirmDB
    {
        /// <summary>
        /// �����Ǘ��}�X�^�̌���
        /// </summary>
        /// <param name="syncMngResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="param">��������</param>
        /// <param name="logicalMode">�_���폜�R�[�h</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����Ǘ��}�X�^�̌������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// <br>Update Note: 2014/09/03 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43408</br>
        /// <br>           : �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSyncMngData(
            [CustomSerializationMethodParameterAttribute("PMSCM00217D", "Broadleaf.Application.Remoting.ParamData.SyncMngWork")]
            out object syncMngResultData,
            out string errMessage,
            object param,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �����v���f�[�^�����̌���
        /// </summary>
        /// <param name="syncReqResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="param">��������</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�����̌������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int GetSyncReqDataCount(
            [CustomSerializationMethodParameterAttribute("PMSCM00216D", "Broadleaf.Application.Remoting.ParamData.SyncReqDataWork")]
            out object syncReqResultData,
            out string errMessage,
            object param);

        /// <summary>
        /// �����v���G���[���̎擾
        /// </summary>
        /// <param name="syncReqResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="param">��������</param>
        /// <param name="maxRetryCount">�ő�Ď��s��</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���G���[���̎擾���s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSyncReqErrData(
            [CustomSerializationMethodParameterAttribute("PMSCM00216D", "Broadleaf.Application.Remoting.ParamData.SyncReqDataWork")]
            out object syncReqResultData,
            out string errMessage,
            object param,
            int maxRetryCount);

        /// <summary>
        /// �쐬�����ɂ�蓯���v���G���[���̎擾
        /// </summary>
        /// <param name="syncReqResultData">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="maxRetryCount">�ő�Ď��s��</param> // ADD 2014/09/03 �c���� Redmine#43408
        /// <param name="param">��������</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����v���f�[�^�̌������s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/01</br>
        /// <br>Update Note: 2014/09/03 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11070136-00 Redmine#43408</br>
        /// <br>           : �X�e�[�^�X��2�A�܂�MaxErrorCount�܂œ��B���Ă��Ȃ����̂��擾����Ή�</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSyncReqErrDataByCreateDateTime(
            [CustomSerializationMethodParameterAttribute("PMSCM00216D", "Broadleaf.Application.Remoting.ParamData.SyncReqDataWork")]
            out object syncReqResultData,
            out string errMessage,
            int maxRetryCount, // ADD 2014/09/03 �c���� Redmine#43408
            object param);

        // ADD 2014/07/14 SCM������ �g��  -------------->>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���������������f
        /// </summary>
        /// <returns>true�F�����ς� false�F���������{</returns>
        [MustCustomSerialization]
        bool SyncMngDataExists();
        // ADD 2014/07/14 SCM������ �g��  --------------<<<<<<<<<<<<<<<<<<
    }
}

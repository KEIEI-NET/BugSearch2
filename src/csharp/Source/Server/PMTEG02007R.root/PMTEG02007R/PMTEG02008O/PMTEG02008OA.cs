//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�m�F�\DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : ��`�m�F�\DB RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ��`�m�F�\ �����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`�m�F�\ �����[�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITegataConfirmReportResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �ԕi���R�ꗗ�f�[�^��߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="tegataConfirmReportResultWork">��������</param>
        /// <param name="tegataConfirmReportParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTEG02009D", "Broadleaf.Application.Remoting.ParamData.TegataConfirmReportResultWork")]
			out object tegataConfirmReportResultWork,
           object tegataConfirmReportParaWork);
        #endregion
    }
}

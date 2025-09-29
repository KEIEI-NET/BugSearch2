//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ψꗗ�\DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : ��`���ψꗗ�\DB RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ��`���ψꗗ�\ �����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`���ψꗗ�\ �����[�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITegataKessaiReportResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �ԕi���R�ꗗ�f�[�^��߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="tegataKessaiReportResultWork">��������</param>
        /// <param name="tegataKessaiReportParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTEG02209D", "Broadleaf.Application.Remoting.ParamData.TegataKessaiReportResultWork")]
			out object tegataKessaiReportResultWork,
           object tegataKessaiReportParaWork);
        #endregion
    }
}

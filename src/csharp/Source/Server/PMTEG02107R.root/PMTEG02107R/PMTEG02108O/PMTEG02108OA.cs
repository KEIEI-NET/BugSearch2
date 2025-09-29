//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ו\DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : ��`���ו\DB RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �� �� ��  2010/4/28  �C�����e : �V�K�쐬
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
    /// ��`���ו\ �����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`���ו\ �����[�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010.04.28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITegataMeisaiListReportResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �ԕi���R�ꗗ�f�[�^��߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="tegataMeisaiListReportResultWork">��������</param>
        /// <param name="tegataMeisaiListReportParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTEG02109D", "Broadleaf.Application.Remoting.ParamData.TegataMeisaiListReportResultWork")]
			out object tegataMeisaiListReportResultWork,
           object tegataMeisaiListReportParaWork);
        #endregion
    }
}

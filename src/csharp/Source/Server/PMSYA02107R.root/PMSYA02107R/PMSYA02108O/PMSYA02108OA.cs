//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Ԍ��ԗ��ꗗ�\DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : �����Ԍ��ԗ��ꗗ�\DB RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �L�Q
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
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
    /// �����Ԍ��ԗ��ꗗ �����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����Ԍ��ԗ��ꗗ �����[�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �L�Q</br>
    /// <br>Date       : 2010.04.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMonthCarInspectListResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �����Ԍ��ԗ��ꗗ�f�[�^��߂��܂�:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="monthCarInspectListResultWork">��������</param>
        /// <param name="monthCarInspectListParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : �L�Q</br>
        /// <br>Date       : 2010.04.21</br>

        int Search(
            [CustomSerializationMethodParameterAttribute("PMSYA02109D", "Broadleaf.Application.Remoting.ParamData.MonthCarInspectListResultWork")]
			out object monthCarInspectListResultWork,
            object monthCarInspectListParaWork);
        #endregion
    }
}

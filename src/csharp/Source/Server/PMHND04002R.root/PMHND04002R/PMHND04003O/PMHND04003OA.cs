//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���i�Ώێ擾�����[�g�I�u�W�F�N�g �C���^�[�t�F�[�X
// �v���O�����T�v   : ���i�Ώێ擾RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���R
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�Ώێ擾�����[�g�I�u�W�F�N�g �C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ώێ擾�����[�g�I�u�W�F�N�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyInspectDB
    {
        #region [SearchSlipNum]
        /// <summary>
        /// ���i�Ώۏ��(�`�[�ԍ�)�̎擾����
        /// </summary>
        /// <param name="condByte">��������</param>
        /// <param name="retListObj">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ώۏ��(�`�[�ԍ�)���������܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSlipNum(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND04004D", "Broadleaf.Application.Remoting.ParamData.HandyInspectWork")]
            out object retListObj);
        #endregion

        #region [SearchTotal]
        /// <summary>
        /// ���i�Ώۏ��(�ꊇ���i)�̎擾����
        /// </summary>
        /// <param name="condByte">��������</param>
        /// <param name="retListObj">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ώۏ��(�ꊇ���i)���������܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchTotal(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND04004D", "Broadleaf.Application.Remoting.ParamData.HandyInspectWork")]
            out object retListObj);
        #endregion
    }
}
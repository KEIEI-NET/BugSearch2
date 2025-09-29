//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �D��q�Ƀ}�X�^
// �v���O�����T�v   : �D��q�ɂ̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : huangt
// �� �� ��  K2013/09/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �D��q�Ƀ}�X�^�@DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D��q�Ƀ}�X�^�@DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : K2013/09/10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IProtyWarehouseDB
    {
        /// <summary>
        /// �P��̗D��q�ɐݒ�����擾���܂�
        /// </summary>
        /// <param name="protyWarehouseList">��������</param>
        /// <param name="protyWarehouseObj">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����D��q�ɐݒ�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList,
            object protyWarehouseObj,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// �P��̗D��q�ɐݒ�����擾���܂�(���`����̎w�����������̍ۂɎg�p)
        /// </summary>
        /// <param name="protyWarehouseList">��������</param>
        /// <param name="protyWarehouseObj">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����D��q�ɐݒ�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        int ReadWithWarehouse(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList,
            object protyWarehouseObj,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// �D��q�ɐݒ���𕨗��폜���܂�
        /// </summary>
        /// <param name="protyWarehouseList">�����폜����D��q�ɐݒ�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����D��q�ɐݒ���𕨗��폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            object protyWarehouseList
            );

        /// <summary>
        /// �D��q�ɐݒ���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">��������</param>
        /// <param name="protyWarehouseObj">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �D��q�ɐݒ�̃L�[�l����v����A�S�Ă̗D��q�ɐݒ�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList,
            object protyWarehouseObj
            );

        /// <summary>
        /// �D��q�ɐݒ����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�ǉ��E�X�V����D��q�ɐݒ�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : protyWarehouseList �Ɋi�[����Ă���D��q�ɐݒ����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList
            );

        /// <summary>
        /// �D��q�ɐݒ����_���폜���܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�_���폜����D��q�ɐݒ�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork �Ɋi�[����Ă���D��q�ɐݒ����_���폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList
            );

        /// <summary>
        /// �D��q�ɐݒ���̘_���폜���������܂��B
        /// </summary>
        /// <param name="protyWarehouseList">�_���폜����������D��q�ɐݒ�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ProtyWarehouseWork �Ɋi�[����Ă���D��q�ɐݒ���̘_���폜���������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : K2013/09/10</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09756D", "Broadleaf.Application.Remoting.ParamData.ProtyWarehouseWork")]
            ref object protyWarehouseList
            );
    }
}

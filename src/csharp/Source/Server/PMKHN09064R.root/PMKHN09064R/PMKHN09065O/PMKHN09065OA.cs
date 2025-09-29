//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   BL�O���[�v�}�X�^DB�C���^�[�t�F�[�X
//                  :   PMKHN09065O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.06.05
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// BL�O���[�v�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�O���[�v�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBLGroupUDB
    {
        /// <summary>
        /// �P���BL�O���[�v�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="blGroupUObj">BLGroupUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�O���[�v�}�X�^�̃L�[�l����v����BL�O���[�v�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            ref object blGroupUObj,
            int readMode);

        /// <summary>
        /// BL�O���[�v�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="blGroupUList">�����폜����BL�O���[�v�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�O���[�v�}�X�^�̃L�[�l����v����BL�O���[�v�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            object blGroupUList);

        /// <summary>
        /// BL�O���[�v�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="blGroupUList">��������</param>
        /// <param name="blGroupUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�O���[�v�}�X�^�̃L�[�l����v����A�S�Ă�BL�O���[�v�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            ref object blGroupUList,
            object blGroupUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// BL�O���[�v�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="blGroupUList">�ǉ��E�X�V����BL�O���[�v�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUList �Ɋi�[����Ă���BL�O���[�v�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            ref object blGroupUList);

        /// <summary>
        /// BL�O���[�v�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="blGroupUList">�_���폜����BL�O���[�v�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUWork �Ɋi�[����Ă���BL�O���[�v�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D", "Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            ref object blGroupUList);

        /// <summary>
        /// BL�O���[�v�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="blGroupUList">�_���폜����������BL�O���[�v�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : blGroupUWork �Ɋi�[����Ă���BL�O���[�v�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09066D","Broadleaf.Application.Remoting.ParamData.BLGroupUWork")]
            ref object blGroupUList);
    }
}

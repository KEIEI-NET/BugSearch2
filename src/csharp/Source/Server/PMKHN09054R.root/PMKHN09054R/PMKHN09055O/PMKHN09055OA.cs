//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���ʃ}�X�^DB�C���^�[�t�F�[�X
//                  :   PMKHN09055O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008�@�����@���n
// Date             :   2008.06.11
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
    /// ���ʃ}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ʃ}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008�@�����@���n</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPartsPosCodeUDB
    {
        /// <summary>
        /// �P��̕��ʃ}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="partsPosCodeUObj">PartsPosCodeUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�̃L�[�l����v���镔�ʃ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            ref object partsPosCodeUObj,
            int readMode);

        /// <summary>
        /// ���ʃ}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="partsPosCodeUList">�����폜���镔�ʃ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�̃L�[�l����v���镔�ʃ}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            object partsPosCodeUList);

        /// <summary>
        /// ���ʃ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">��������</param>
        /// <param name="partsPosCodeUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���ʃ}�X�^�̃L�[�l����v����A�S�Ă̕��ʃ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            ref object partsPosCodeUList,
            object partsPosCodeUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���ʃ}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�ǉ��E�X�V���镔�ʃ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList �Ɋi�[����Ă��镔�ʃ}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            ref object partsPosCodeUList);

        /// <summary>
        /// ���ʃ}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�_���폜���镔�ʃ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork �Ɋi�[����Ă��镔�ʃ}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            ref object partsPosCodeUList);

        /// <summary>
        /// ���ʃ}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="partsPosCodeUList">�_���폜���������镔�ʃ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork �Ɋi�[����Ă��镔�ʃ}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.11</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09056D","Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork")]
            ref object partsPosCodeUList);
    }
}

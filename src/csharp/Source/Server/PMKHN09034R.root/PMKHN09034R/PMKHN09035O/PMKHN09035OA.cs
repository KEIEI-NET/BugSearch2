//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �Ԏ햼�̃}�X�^DB�C���^�[�t�F�[�X
//                  :   PMKHN09035O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008�@���� ���n
// Date             :   2008.06.10
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
    /// �Ԏ햼�̃}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ԏ햼�̃}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IModelNameUDB
    {
        /// <summary>
        /// �P��̎Ԏ햼�̃}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="modelNameUObj">ModelNameUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�̃L�[�l����v����Ԏ햼�̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09036D", "Broadleaf.Application.Remoting.ParamData.ModelNameUWork")]
            ref object modelNameUObj,
            int readMode);

        /// <summary>
        /// �Ԏ햼�̃}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="modelNameUList">�����폜����Ԏ햼�̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�̃L�[�l����v����Ԏ햼�̃}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09036D", "Broadleaf.Application.Remoting.ParamData.ModelNameUWork")]
            object modelNameUList);

        /// <summary>
        /// �Ԏ햼�̃}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="modelNameUList">��������</param>
        /// <param name="modelNameUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ԏ햼�̃}�X�^�̃L�[�l����v����A�S�Ă̎Ԏ햼�̃}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09036D", "Broadleaf.Application.Remoting.ParamData.ModelNameUWork")]
            ref object modelNameUList,
            object modelNameUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �Ԏ햼�̃}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="modelNameUList">�ǉ��E�X�V����Ԏ햼�̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUList �Ɋi�[����Ă���Ԏ햼�̃}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09036D", "Broadleaf.Application.Remoting.ParamData.ModelNameUWork")]
            ref object modelNameUList);

        /// <summary>
        /// �Ԏ햼�̃}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="modelNameUList">�_���폜����Ԏ햼�̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork �Ɋi�[����Ă���Ԏ햼�̃}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09036D", "Broadleaf.Application.Remoting.ParamData.ModelNameUWork")]
            ref object modelNameUList);

        /// <summary>
        /// �Ԏ햼�̃}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="modelNameUList">�_���폜����������Ԏ햼�̃}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork �Ɋi�[����Ă���Ԏ햼�̃}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09036D","Broadleaf.Application.Remoting.ParamData.ModelNameUWork")]
            ref object modelNameUList);
    }
}

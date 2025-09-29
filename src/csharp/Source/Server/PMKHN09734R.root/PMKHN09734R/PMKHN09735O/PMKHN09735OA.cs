//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���[���O���[�v�����ݒ�}�X�^                    //
//                      DB RemoteObject Interface                       //
//                  :   PMKHN09735O.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting                  //
// Programmer       :   30746 ���� ��                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

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
    /// ���[���O���[�v�����ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 30746 ���� ��</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRoleGroupAuthDB
    {
        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="roleGroupAuthObj">RoleGroupAuthWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̃L�[�l����v���郍�[���O���[�v�����ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            ref object roleGroupAuthObj,
            int readMode);

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="RoleGroupAuthList">�����폜���郍�[���O���[�v�����ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̃L�[�l����v���郍�[���O���[�v�����ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            object roleGroupAuthList);

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">��������</param>
        /// <param name="roleGroupAuthObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�̃L�[�l����v����A�S�Ẵ��[���O���[�v�����ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            ref object roleGroupAuthList,
            object rolegroupAuthObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�ǉ��E�X�V���郍�[���O���[�v�����ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUList �Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            ref object roleGroupAuthList);

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�_���폜���郍�[���O���[�v�����ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork �Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            ref object roleGroupAuthList);

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="roleGroupAuthList">�_���폜���������郍�[���O���[�v�����ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : modelNameUWork �Ɋi�[����Ă��郍�[���O���[�v�����ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09736D", "Broadleaf.Application.Remoting.ParamData.RoleGroupAuthWork")]
            ref object roleGroupAuthList);
    }
}
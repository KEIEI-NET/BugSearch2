//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���[���O���[�v���̐ݒ�}�X�^                    //
//                      DB RemoteObject Interface                       //
//                  :   PMKHN09726O.DLL                                 //
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
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���[���O���[�v���̐ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30746 ���� ��</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRoleGroupNameStDB
    {

        /// <summary>
        /// �w�肳�ꂽ���[���O���[�v���̐ݒ�}�X�^Guid�̃��[���O���|�v���̐ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">RoleGroupNameStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ���[���O���[�v���̐ݒ�}�X�^Guid�̃��[���O���[�v���̐ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">RoleGroupNameStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        int Delete(byte[] parabyte);

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="roleGroupNameStWork">��������</param>
        /// <param name="pararoleGroupNameStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09727D", "Broadleaf.Application.Remoting.ParamData.RoleGroupNameStWork")]
            out object roleGroupNameStWork,
            object pararoleGroupNameStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09727D", "Broadleaf.Application.Remoting.ParamData.RoleGroupNameStWork")]
            ref object roleGroupNameStWork
            );

        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09727D", "Broadleaf.Application.Remoting.ParamData.RoleGroupNameStWork")]
            ref object roleGroupNameStWork
            );

        /// <summary>
        /// �_���폜���[���O���[�v���̐ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���[���O���[�v���̐ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09727D", "Broadleaf.Application.Remoting.ParamData.RoleGroupNameStWork")]
            ref object roleGroupNameStWork
            );
        #endregion
    }
}
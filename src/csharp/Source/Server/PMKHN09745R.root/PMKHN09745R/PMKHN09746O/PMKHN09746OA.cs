using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �]�ƈ����[���ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �]�ƈ����[���ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30747 �O�ˁ@�L��</br>
    /// <br>Date       : 2013/02/07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEmployeeRoleStDB
    {

        /// <summary>
        /// �w�肳�ꂽ�]�ƈ����[���ݒ�}�X�^Guid�̃��[���O���|�v���̐ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">EmployeeRoleStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�]�ƈ����[���ݒ�}�X�^Guid�̏]�ƈ����[���ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">EmployeeRoleStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        int Delete(byte[] parabyte);

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="employeeRoleStWork">��������</param>
        /// <param name="paraemployeeRoleStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09747D", "Broadleaf.Application.Remoting.ParamData.EmployeeRoleStWork")]
            out object employeeRoleStWork,
            object paraemployeeRoleStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09747D", "Broadleaf.Application.Remoting.ParamData.EmployeeRoleStWork")]
            ref object employeeRoleStWork
            );

        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09747D", "Broadleaf.Application.Remoting.ParamData.EmployeeRoleStWork")]
            ref object employeeRoleStWork
            );

        /// <summary>
        /// �_���폜�]�ƈ����[���ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�]�ƈ����[���ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09747D", "Broadleaf.Application.Remoting.ParamData.EmployeeRoleStWork")]
            ref object employeeRoleStWork
            );
        #endregion
    }
}

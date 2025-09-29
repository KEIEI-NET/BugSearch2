using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �󒍃}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󒍃}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2006.10.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAcceptOdrDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �󒍃}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="acceptOdrWork">��������</param>
        /// <param name="paraacceptOdrWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2006.10.19</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCCMN00106D","Broadleaf.Application.Remoting.ParamData.AcceptOdrWork")]
            out object acceptOdrWork,
            object paraacceptOdrWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �󒍃}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2006.10.19</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCCMN00106D","Broadleaf.Application.Remoting.ParamData.AcceptOdrWork")]
            ref object acceptOdrWork
            );

        /// <summary>
        /// �󒍃}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2006.10.19</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("DCCMN00106D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrWork")]
            object acceptOdrWork
            );

        /// <summary>
        /// �󒍃}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2006.10.19</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCCMN00106D","Broadleaf.Application.Remoting.ParamData.AcceptOdrWork")]
            ref object acceptOdrWork
            );

        /// <summary>
        /// �_���폜�󒍃}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="acceptOdrWork">AcceptOdrWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�󒍃}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2006.10.19</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCCMN00106D","Broadleaf.Application.Remoting.ParamData.AcceptOdrWork")]
            ref object acceptOdrWork
            );
        #endregion
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �󔭒��S�̐ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󔭒��S�̐ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 980081  �R�c ���F</br>
    /// <br>Date       : 2007.12.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAcptAnOdrTtlStDB
    {
        /// <summary>
        /// �w�肳�ꂽ�󔭒��S�̐ݒ�}�X�^Guid�̎󔭒��S�̐ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">AcptAnOdrTtlStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�󔭒��S�̐ݒ�}�X�^Guid�̎󔭒��S�̐ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.11</br>
        int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// �󔭒��S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">AcptAnOdrTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󔭒��S�̐ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.11</br>
        int Delete(byte[] parabyte);

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �󔭒��S�̐ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">��������</param>
        /// <param name="paraacptAnOdrTtlStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09246D","Broadleaf.Application.Remoting.ParamData.AcptAnOdrTtlStWork")]
            out object acptAnOdrTtlStWork,
            object paraacptAnOdrTtlStWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �󔭒��S�̐ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">AcptAnOdrTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󔭒��S�̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09246D","Broadleaf.Application.Remoting.ParamData.AcptAnOdrTtlStWork")]
            ref object acptAnOdrTtlStWork
            );

        /// <summary>
        /// �󔭒��S�̐ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">AcptAnOdrTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󔭒��S�̐ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.11</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09246D","Broadleaf.Application.Remoting.ParamData.AcptAnOdrTtlStWork")]
            ref object acptAnOdrTtlStWork
            );

        /// <summary>
        /// �_���폜�󔭒��S�̐ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="acptAnOdrTtlStWork">AcptAnOdrTtlStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�󔭒��S�̐ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.11</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09246D","Broadleaf.Application.Remoting.ParamData.AcptAnOdrTtlStWork")]
            ref object acptAnOdrTtlStWork
            );
        #endregion
    }
}

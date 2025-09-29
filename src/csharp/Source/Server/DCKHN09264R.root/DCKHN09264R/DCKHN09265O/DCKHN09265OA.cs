using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �`�[�o�͐�ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �`�[�o�͐�ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 980081  �R�c ���F</br>
    /// <br>Date       : 2007.12.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISlipOutputSetDB
    {
        /// <summary>
        /// �w�肳�ꂽ�`�[�o�͐�ݒ�}�X�^Guid�̓`�[�o�͐�ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">SlipOutputSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�`�[�o�͐�ݒ�}�X�^Guid�̓`�[�o�͐�ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.10</br>
        int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// �`�[�o�͐�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SlipOutputSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �`�[�o�͐�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.10</br>
        int Delete(byte[] parabyte);

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �`�[�o�͐�ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="slipOutputSetWork">��������</param>
        /// <param name="paraslipOutputSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09266D","Broadleaf.Application.Remoting.ParamData.SlipOutputSetWork")]
            out object slipOutputSetWork,
            object paraslipOutputSetWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �`�[�o�͐�ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="slipOutputSetWork">SlipOutputSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �`�[�o�͐�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09266D","Broadleaf.Application.Remoting.ParamData.SlipOutputSetWork")]
            ref object slipOutputSetWork
            );

        /// <summary>
        /// �`�[�o�͐�ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="slipOutputSetWork">SlipOutputSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �`�[�o�͐�ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.10</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09266D","Broadleaf.Application.Remoting.ParamData.SlipOutputSetWork")]
            ref object slipOutputSetWork
            );

        /// <summary>
        /// �_���폜�`�[�o�͐�ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="slipOutputSetWork">SlipOutputSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�`�[�o�͐�ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.12.10</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09266D","Broadleaf.Application.Remoting.ParamData.SlipOutputSetWork")]
            ref object slipOutputSetWork
            );
        #endregion
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i���i�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i���i�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 18322  �ؑ� ����</br>
    /// <br>Date       : 2007.04.18</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: DC.NS�Ή�</br>
    /// <br>Programmer : 21024�@���X�؁@��</br>
    /// <br>Date       : 2007.08.13</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 22008 ���� PM.NS�Ή�</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsPriceUDB
    {

        /// <summary>
        /// �w�肳�ꂽ���i���i�}�X�^Guid�̏��i���i�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ���i���i�}�X�^Guid�̏��i���i�}�X�^��߂��܂�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// ���i���i�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        int Delete(byte[] parabyte);

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ���i���i�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="GoodsPriceUWork">��������</param>
        /// <param name="paraGoodsPriceUWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 19026  ���R�@����</br>
        /// <br>Date       : 2007.04.20</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            out object GoodsPriceUWork,
            object paraGoodsPriceUWork,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i���i�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <param name="writeError">�X�V�G���[</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 19026  ���R�@����</br>
        /// <br>Date       : 2007.04.20</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAKHN09176D","Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            ref object GoodsPriceUWork,
            [CustomSerializationMethodParameterAttribute("MAKHN09176D","Broadleaf.Application.Remoting.ParamData.GoodsPriceUWriteErrorWork")]
            out object writeError
            );

        /// <summary>
        /// ���i���i�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i���i�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09176D","Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            ref object GoodsPriceUWork
            );

        /// <summary>
        /// �_���폜���i���i�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="GoodsPriceUWork">GoodsPriceUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i���i�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 18322  �ؑ� ����</br>
        /// <br>Date       : 2007.04.18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09176D","Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            ref object GoodsPriceUWork
            );
        #endregion
    }
}

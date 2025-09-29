using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�Z�b�g�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Z�b�g�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 19026�@���R�@����</br>
    /// <br>Date       : 2007.04.27</br>
    /// <br>Update Note: 20081 �D�c �E�l</br>
    /// <br>           : 2007.09.26 DC.NS�p�ɕύX</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsSetDB
    {

        /// <summary>
        /// �w�肳�ꂽ���i�Z�b�g�}�X�^Guid�̏��i�Z�b�g�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ���i�Z�b�g�}�X�^Guid�̏��i�Z�b�g�}�X�^��߂��܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// ���i�Z�b�g�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">GoodsSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        int Delete(byte[] parabyte);

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ���i�Z�b�g�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="goodsSetWork">��������</param>
        /// <param name="paragoodsSetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("MAKHN09626D","Broadleaf.Application.Remoting.ParamData.GoodsSetWork")]
            out object goodsSetWork,
            object paragoodsSetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i�Z�b�g�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAKHN09626D","Broadleaf.Application.Remoting.ParamData.GoodsSetWork")]
            ref object goodsSetWork
            );

        /// <summary>
        /// <br>���i�Z�b�g�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>���ꏤ�i�Z�b�g�R�[�h�̃f�[�^����������DELETE���A�V�K�œ��e��o�^���܂�</br>
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="parentGoodsMakerCd">�e���[�J�[�R�[�h</param>
        /// <param name="parentGoodsNo">�e���i�Z�b�g�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.05.11</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAKHN09626D", "Broadleaf.Application.Remoting.ParamData.GoodsSetWork")]
            ref object goodsSetWork,
//            string enterpriseCode, string goodsSetCode                           // 2007.09.26 hikita del
            string enterpriseCode, Int32 parentGoodsMakerCd, string parentGoodsNo  // 2007.09.26 hikita add
            );

        /// <summary>
        /// ���i�Z�b�g�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Z�b�g�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09626D","Broadleaf.Application.Remoting.ParamData.GoodsSetWork")]
            ref object goodsSetWork
            );

        /// <summary>
        /// �_���폜���i�Z�b�g�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="goodsSetWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i�Z�b�g�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 19026�@���R�@����</br>
        /// <br>Date       : 2007.04.27</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAKHN09626D","Broadleaf.Application.Remoting.ParamData.GoodsSetWork")]
            ref object goodsSetWork
            );
        #endregion
    }
}

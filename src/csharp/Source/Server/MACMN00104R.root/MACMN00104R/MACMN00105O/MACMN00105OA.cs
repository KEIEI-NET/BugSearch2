using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���i�\���擾DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�\���擾DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2006.12.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGoodsURelationDataDB
	{

		/// <summary>
		/// ���i�\���擾LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="retObj">��������</param>
		/// <param name="paraObj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2006.12.06</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object retObj,
			object paraObj, 
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i�\���擾LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.06</br>
        [MustCustomSerialization]
        int SearchMultiCondition(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retObj,
            object paraObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        #region ���i�n�}�X�^���ꊇ�ŏ�������ׂ̃��\�b�h
        ///// <summary>
        ///// ���i�}�X�^�i���[�U�[�o�^���jLIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        ///// </summary>
        ///// <param name="goodsUWork">��������</param>
        ///// <param name="paragoodsUWork">�����p�����[�^</param>
        ///// <param name="readMode">�����敪</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : </br>
        ///// <br>Programmer : 21015�@�����@�F��</br>
        ///// <br>Date       : 2007.01.24</br>
        //[MustCustomSerialization]
        //int SearchRelation(
        //    [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
        //    out object goodsUWork,
        //    object paragoodsUWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int WriteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����V�K�o�^(���i�}�X�^�ɑ��݂��Ȃ��ꍇ�̂�)
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����V�K�o�^(���i�}�X�^�ɑ��݂��Ȃ��ꍇ�̂�)</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.12</br>
        [MustCustomSerialization]
        int ReadNewWriteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j����_���폜���܂�
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����_���폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int LogicalDeleteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        /// <summary>
        /// �_���폜���i�}�X�^�i���[�U�[�o�^���j���𕜊����܂�
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���i�}�X�^�i���[�U�[�o�^���j���𕜊����܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int RevivalLogicalDeleteRelation(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object goodsUWork
            );

        /// <summary>
        /// ���i�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">���i�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���i�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2006.12.08</br>
        int DeleteRelation(object paraobj);
        #endregion

    }
}

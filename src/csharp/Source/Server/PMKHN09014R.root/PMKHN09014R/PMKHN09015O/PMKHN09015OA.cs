//============================================================================//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Ӑ�}�X�^�����[�g�C���^�[�t�F�[�X
// �v���O�����T�v   : ���Ӑ�}�X�^�����[�g�I�u�W�F�N�g���擾���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10402071-00  �쐬�S�� : 21112
// �� �� ��  2008/04/23  �C�����e : SFTOK01132O ���x�[�X��PM.NS�p���쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10970681-00  �쐬�S���F��
// �C����   K2014/02/06  �C�����e�F�O�����a����� ���Ӑ�}�X�^���ǑΉ�
// -------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���Ӑ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21112</br>
	/// <br>Date       : 2008.04.23</br>
	/// <br></br>
    /// <br>Update Note: �����폜�����ǉ�</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.09.02</br>
    /// <br></br>
    /// <br>Update Note: ���Ӑ���֘A�����}�X�^�̌��������A�o�^�����A�X�V�����A�_���폜�����ǉ�</br>
    /// <br>Programmer : ��</br>
    /// <br>Date       : K2014/02/06</br>
    /// <br></br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ICustomerInfoDB
	{
		/// <summary>
		/// ���Ӑ���֘A�}�X�^�Ǎ�����
		/// </summary>
		/// <param name="paraList">CustomSerializeList</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����p�����[�^�̓��Ӑ���֘A�}�X�^��߂��܂�</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList);						

		/// <summary>
		/// ���Ӑ���֘A�}�X�^�Ǎ�����
		/// </summary>
		/// <param name="logicalMode">�_���폜�敪</param>
		/// <param name="paraList">CustomSerializeList</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����p�����[�^�̓��Ӑ���֘A�}�X�^��߂��܂�</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
        [MustCustomSerialization]
        int Read(
            ConstantManagement.LogicalMode logicalMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList);
        // ADD �� K2014/02/06 ------------------------------------->>>>>
        /// <summary>
        /// ���Ӑ���֘A�}�X�^�����Ǎ�����
        /// </summary>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����p�����[�^�̓��Ӑ���֘A�}�X�^��߂��܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        [MustCustomSerialization]
        int MaehashiRead(
            ConstantManagement.LogicalMode logicalMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList);

        /// <summary>
        /// ���Ӑ���֘A�}�X�^�o�^����
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="duplicationItemList">�d���G���[���̏d������</param>
        /// <param name="carMngNo">���Ӑ�Ǝԗ��𓯎��o�^����ۂ̎ԗ��Ǘ��ԍ�</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ���֘A�}�X�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        [MustCustomSerialization]
        int MaehashiWrite(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList, out ArrayList duplicationItemList, int carMngNo);

        /// <summary>
        /// ���Ӑ���֘A�}�X�^�����_���폜����
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <param name="carDeleteFlg">�ԗ��폜�t���O</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ���֘A�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        [MustCustomSerialization]
        int MaehashiLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList, bool carDeleteFlg);

        /// <summary>
        /// ���Ӑ���֘A�}�X�^���������폜����
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ���֘A�}�X�^�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        int MaehashiDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object paraList);

        /// <summary>
        /// ���Ӑ���֘A�}�X�^�����_���폜��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�Ɠ��Ӑ惁��DB�̘_���폜�f�[�𕜊����܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2014/02/06</br>
        /// </remarks>
        [MustCustomSerialization]
        int MaehashiRevivalLogicalDelete(string enterpriseCode, int customerCode);
        // ADD �� K2014/02/06 -------------------------------------<<<<<

		// ADD 2009.01.19 >>>
        /// <summary>
        /// ���Ӑ���֘A�}�X�^�Ǎ�����
        /// </summary>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����p�����[�^�̓��Ӑ���֘A�}�X�^��߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2009.01.19</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            ConstantManagement.LogicalMode logicalMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList);
        // ADD 2009.01.19 <<<

		/// <summary>
		/// ���Ӑ���֘A�}�X�^�o�^����
		/// </summary>
		/// <param name="paraList">CustomSerializeList(���Ӑ�}�X�^�A���l�}�X�^�A�Ƒ��\���}�X�^)</param>
		/// <param name="duplicationItemList">�d���G���[���̏d������</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ���֘A�}�X�^��o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		[MustCustomSerialization]
		int Write(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList, out ArrayList duplicationItemList);

		/// <summary>
		/// ���Ӑ���֘A�}�X�^�o�^����
		/// </summary>
		/// <param name="paraList">CustomSerializeList</param>
		/// <param name="duplicationItemList">�d���G���[���̏d������</param>
		/// <param name="carMngNo">���Ӑ�Ǝԗ��𓯎��o�^����ۂ̎ԗ��Ǘ��ԍ�</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ���֘A�}�X�^��o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		[MustCustomSerialization]
		int Write(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList, out ArrayList duplicationItemList, int carMngNo);

        // --- ADD 2008/09/02 ---------->>>>>
        /// <summary>
        /// ���Ӑ���֘A�}�X�^�����폜����
        /// </summary>
        /// <param name="paraList">CustomSerializeList</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ���֘A�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object paraList);
        // --- ADD 2008/09/02 ----------<<<<<

		/// <summary>
		/// ���Ӑ���֘A�}�X�^�_���폜����
		/// </summary>
		/// <param name="paraList">CustomSerializeList</param>
		/// <param name="carDeleteFlg">�ԗ��폜�t���O</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ���֘A�}�X�^��_���폜���܂�</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		[MustCustomSerialization]
		int LogicalDelete(			
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object paraList, bool carDeleteFlg);

		/// <summary>
		/// ���Ӑ�}�X�^�폜�`�F�b�N����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="checkFlg">�`�F�b�N����[true:�폜�n�j][false:�폜�m�f]</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�}�X�^�̍폜�`�F�b�N�������s���܂�</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		int DeleteCheck(string enterpriseCode, int customerCode, out string message, out bool checkFlg);

		/// <summary>
		/// ���Ӑ�}�X�^���݃`�F�b�N����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="logicalMode">�_���폜�敪</param>
		/// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^�̑��݃`�F�b�N�������s���܂�</br>
        /// <br>Programmer : 21112</br>
        /// <br>Date       : 2008.04.23</br>
        /// </remarks>
        int ExistData(string enterpriseCode, int customerCode, ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// ���Ӑ�}�X�^�_���폜��������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�}�X�^�̘_���폜�f�[�𕜊����܂�</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2008.04.23</br>
		/// </remarks>
		[MustCustomSerialization]
		int RevivalLogicalDelete(string enterpriseCode, int customerCode);

		/// <summary>
		/// �X�V���`�F�b�N����
		/// </summary>
		/// <param name="updateDateTime">�X�V��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>true:�ύX�L�� false:�ύX����</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�}�X�^�̍X�V�����ύX����Ă��邩�ǂ������`�F�b�N���܂�</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2006.06.15</br>
		/// </remarks>
		bool IsUpdateDateTimeChange(DateTime updateDateTime, string enterpriseCode, int customerCode);

		/// <summary>
		/// ���Ӑ於�̎擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCodeArray">���Ӑ�R�[�h�z��</param>
		/// <param name="nameTable">����Hashtable</param>
		/// <param name="name2Table">����2Hashtable</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�R�[�h�𕡐��w�肵�A���̂Ɩ��̂Q��Hashtable�Ŏ擾���܂�</br>
		/// <br>Programmer : 21112</br>
		/// <br>Date       : 2006.06.28</br>
		/// </remarks>
		int GetName(string enterpriseCode, int[] customerCodeArray, out Hashtable nameTable, out Hashtable name2Table);

        // --- ADD 2010/09/26 ---------->>>>>
		/// <summary>
        /// ���Ӑ�}�X�^��ALL�Ǎ�
        /// </summary>
        /// <param name="paraObj">����Para</param>
        /// <param name="customerWorkList">��������</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�}�X�^��ALL�Ǎ����܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/09/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(object paraObj, out object customerWorkList);
        // --- ADD 2010/09/26 ----------<<<<<
	}
}

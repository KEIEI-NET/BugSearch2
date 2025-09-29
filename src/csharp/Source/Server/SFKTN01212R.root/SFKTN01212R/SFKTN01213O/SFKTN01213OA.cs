using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���_��� RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���_��� RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.08.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// <br>20050704 yamada  �J�X�^���V���A���C�Y�Ή����\�b�h�ǉ� </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface ISectionInfo
	{
		
		/// <summary>
		/// ���_���ݒ�LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="searchRetList">��������</param>
		/// <param name="secInfoSetWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪(�\��p�p�����[�^)</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="errorLevel">�G���[���x��</param>
		/// <param name="errorCode">�G���[�R�[�h</param>
		/// <param name="errorMessage">�G���[���b�Z�[�W</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.07.04</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C","Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object searchRetList,
			object secInfoSetWork,
			int readMode,
			ConstantManagement.LogicalMode logicalMode,
			out int errorLevel,
			out string errorCode,
			out string errorMessage);
		
	}
}

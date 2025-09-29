using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���l�K�C�hDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���l�K�C�hDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.10.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface INoteGuidBdDB
	{
		#region �w�b�_�[���\�b�h
		/// <summary>
		/// ���l�K�C�h�w�b�_�[LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��l�K�C�hLIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int SearchCntHeader(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// ���l�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		[MustCustomSerialization]
		int SearchHeader(
			[CustomSerializationMethodParameterAttribute("SFTOK09406D","Broadleaf.Application.Remoting.ParamData.NoteGuidHdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ�R�[�h�̔��l�K�C�h�w�b�_�[��߂��܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�R�[�h�̔��l�K�C�h��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int ReadHeader(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ���l�K�C�h�w�b�_�[����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h�w�b�_�[����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int WriteHeader(ref byte[] parabyte);

		/// <summary>
		/// ���l�K�C�h���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int DeleteHeader(byte[] parabyte);

		/// <summary>
		/// ���l�K�C�h�{�f�B(���[�U�[�ύX��)����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h����_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int LogicalDeleteHeader(ref byte[] parabyte);

		/// <summary>
		/// �_���폜���l�K�C�h���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���l�K�C�h���𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int RevivalLogicalDeleteHeader(ref byte[] parabyte);

		#endregion

		#region �{�f�B���\�b�h
		/// <summary>
		/// ���l�K�C�h�w�b�_�[LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��l�K�C�hLIST�̌�����߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int SearchCntBody(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// ���l�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		[MustCustomSerialization]
		int SearchBody(
			[CustomSerializationMethodParameterAttribute("SFTOK09406D","Broadleaf.Application.Remoting.ParamData.NoteGuidBdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ�R�[�h�̔��l�K�C�h�w�b�_�[��߂��܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�R�[�h�̔��l�K�C�h��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int ReadBody(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ���l�K�C�h�w�b�_�[����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidHdWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h�w�b�_�[����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int WriteBody(ref byte[] parabyte);

		/// <summary>
		/// ���l�K�C�h���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int DeleteBody(byte[] parabyte);

		/// <summary>
		/// ���l�K�C�h�{�f�B(���[�U�[�ύX��)����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">NoteGuidBdWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h����_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int LogicalDeleteBody(ref byte[] parabyte);

		/// <summary>
		/// �_���폜���l�K�C�h���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���l�K�C�h���𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		int RevivalLogicalDeleteBody(ref byte[] parabyte);

		/// <summary>
		/// ���l�K�C�h�{�f�BLIST���w��敪�R�[�h���߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���l�K�C�h�{�f�BLIST���w��敪�R�[�h���߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.10.13</br>
		[MustCustomSerialization]
		int SearchGuideDivCode(
			[CustomSerializationMethodParameterAttribute("SFTOK09406D","Broadleaf.Application.Remoting.ParamData.NoteGuidBdWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);
		#endregion
		
	}

}

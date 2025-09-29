using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �x���ݒ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �x���ݒ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.04.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IPaymentSetDB
	{
		#region ���N���X���g�������\�b�h
//		/// <summary>
//		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST��S�Ė߂��܂�
//		/// </summary>
//		/// <param name="retbyte">��������</param>
//		/// <param name="parabyte">�����p�����[�^</param>
//		/// <param name="readMode">�����敪</param>
//		/// <param name="readCnt">READ�����i0�̏ꍇ��ALL�j</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��LIST��S�Ė߂��܂�</br>
//		/// <br>Programmer : 21052�@�R�c�@�\</br>
//		/// <br>Date       : 2005.04.13</br>
//		int Search(out byte[] retbyte,byte[] parabyte, int readMode,int readCnt);
//
//		/// <summary>
//		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ��߂��܂�
//		/// </summary>
//		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
//		/// <param name="readMode">�����敪</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ��߂��܂�</br>
//		/// <br>Programmer : 21052�@�R�c�@�\</br>
//		/// <br>Date       : 2005.04.13</br>
//		int Read(ref byte[] parabyte , int readMode);
//
//		/// <summary>
//		/// ���Џ��ݒ����o�^�A�X�V���܂�
//		/// </summary>
//		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
//		/// <param name="writeMode">�o�^�A�X�V���[�h</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : ���Џ��ݒ����o�^�A�X�V���܂�</br>
//		/// <br>Programmer : 21052�@�R�c�@�\</br>
//		/// <br>Date       : 2005.04.13</br>
//		int Write(ref byte[] parabyte, int writeMode);
//
//		/// <summary>
//		/// ���Џ���_���폜���܂�
//		/// </summary>
//		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
//		/// <param name="deleteMode">�폜���[�h</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : ���Џ���_���폜���܂�</br>
//		/// <br>Programmer : 21052�@�R�c�@�\</br>
//		/// <br>Date       : 2005.04.13</br>
//		int LogicalDelete(ref byte[] parabyte, int deleteMode);
//		
//		/// <summary>
//		/// ���Џ��𕨗��폜���܂�
//		/// </summary>
//		/// <param name="parabyte">���Џ��I�u�W�F�N�g</param>
//		/// <param name="deleteMode">�폜���[�h</param>
//		/// <returns></returns>
//		/// <br>Note       : ���Џ��𕨗��폜���܂�</br>
//		/// <br>Programmer : 21052�@�R�c�@�\</br>
//		/// <br>Date       : 2005.04.13</br>
//		int Delete(byte[] parabyte, int deleteMode);
		#endregion
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎x���ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// �x���ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎x���ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);

		/// <summary>
		/// �w�肳�ꂽ�x���ݒ�Guid�̎x���ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�x���ݒ�Guid�̎x���ݒ��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �x���ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �x���ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// �x���ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �x���ݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// �x���ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �x���ݒ����_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// �_���폜�x���ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">PaymentSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�x���ݒ���𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.13</br>
		int RevivalLogicalDelete(ref byte[] parabyte);
	}
}

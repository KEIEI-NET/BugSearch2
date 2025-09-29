using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �d���݌ɑS�̐ݒ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d���݌ɑS�̐ݒ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.04.12</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IStockTtlStDB
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
        
        #region 
        /*
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎d���݌ɑS�̐ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.12</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// �d���݌ɑS�̐ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.12</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎d���݌ɑS�̐ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
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
		/// <br>Date       : 2005.04.12</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);
        */ 
        #endregion

        /// <summary>
        /// �d���S�̐ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008  ���� ���n</br>
        /// <br>Date       : 2008.06.03</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFSIR09006D", "Broadleaf.Application.Remoting.ParamData.StockTtlStWork")]
            out object retList, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode);
        
		/// <summary>
		/// �w�肳�ꂽ�d���݌ɑS�̐ݒ�Guid�̎d���݌ɑS�̐ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">StockTtlStWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�d���݌ɑS�̐ݒ�Guid�̎d���݌ɑS�̐ݒ��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.12</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �d���݌ɑS�̐ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">StockTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �d���݌ɑS�̐ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.12</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// �d���݌ɑS�̐ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">StockTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �d���݌ɑS�̐ݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.12</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// �d���݌ɑS�̐ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">StockTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �d���݌ɑS�̐ݒ����_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.12</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// �_���폜�d���݌ɑS�̐ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">StockTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�d���݌ɑS�̐ݒ���𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.12</br>
		int RevivalLogicalDelete(ref byte[] parabyte);
	}
}

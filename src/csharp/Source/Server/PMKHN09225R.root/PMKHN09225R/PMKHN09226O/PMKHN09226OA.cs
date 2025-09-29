using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���i�����ݒ�}�X�^ RemoteObject Interface
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���i�����ݒ�}�X�^ RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.09.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��

	public interface IPriceChgProcStDB
	{
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="PriceChgProcStWork">���i�����ݒ�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		int Search(ref object PriceChgProcStWork,int readMode,ConstantManagement.LogicalMode logicalMode);
	
		/// <summary>
		/// ���i�����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̉��i�����ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);

		/// <summary>
		/// �w�肳�ꂽ���i�����ݒ�Guid�̉��i�����ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ���i�����ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// ���i�����ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int Delete(byte[] parabyte);

		/// <summary>
		/// ���i�����ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// �_���폜���i�����ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int RevivalLogicalDelete(ref byte[] parabyte);
	}
}

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �����ݒ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����ݒ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 90027�@�����@��</br>
	/// <br>Date       : 2005.07.23</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��

	public interface IDepositStDB
	{
		#region �J�X�^���V���A���C�Y

		/// <summary>
		/// �����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		int Search(
			[CustomSerializationMethodParameterAttribute("SFUKK09066D","Broadleaf.Application.Remoting.ParamData.DepositStWork")]
			out object retobj,
			object paraobj,
			int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
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
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		int SearchSpecification(
			out object retobj,
			out int retTotalCnt,
			out bool nextData,
			[CustomSerializationMethodParameterAttribute("SFUKK09066D","Broadleaf.Application.Remoting.ParamData.DepositStWork")]
			object paraobj,
			int readMode,ConstantManagement.LogicalMode logicalMode,
			int readCnt);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ��߂��܂�
		/// </summary>
		/// <param name="ocrDefSetWork">DepositStWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓����ݒ��߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFUKK09066D","Broadleaf.Application.Remoting.ParamData.DepositStWork")]
			ref object ocrDefSetWork,
			int readMode
			);
			
		#endregion

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// �����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̓����ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
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
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);

		/// <summary>
		/// �w�肳�ꂽ�����ݒ�Guid�̓����ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">DepositStWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�����ݒ�Guid�̓����ݒ��߂��܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �����ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">DepositStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// �����ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">DepositStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����ݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// �����ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">DepositStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �����ݒ����_���폜���܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// �_���폜�����ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">DepositStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�����ݒ���𕜊����܂�</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		int RevivalLogicalDelete(ref byte[] parabyte);

	}
}

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���Џ��ݒ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Џ��ݒ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
        /// <br>Update Note: �f�[�^�N���A���ԏ����ǉ�</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��

	public interface ICompanyInfDB
	{

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// ���Џ��ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��Џ��ݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
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
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);

		/// <summary>
		/// �w�肳�ꂽ���Џ��ݒ�Guid�̎��Џ��ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���Џ��ݒ�Guid�̎��Џ��ݒ��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// �w�肳�ꂽ���Џ��ݒ�Guid�̎��Џ��ݒ��߂��܂�
        /// </summary>
        /// <param name="paraobj">CompanyInfWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ���Џ��ݒ�Guid�̎��Џ��ݒ��߂��܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2005.03.24</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("SFUKN09006D", "Broadleaf.Application.Remoting.ParamData.CompanyInfWork")]
            ref object paraobj, int readMode);
        
        /// <summary>
		/// ���Џ��ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Џ��ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// ���Џ��ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Џ��ݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// ���Џ��ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Џ��ݒ����_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// �_���폜���Џ��ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">CompanyInfWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���Џ��ݒ���𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int RevivalLogicalDelete(ref byte[] parabyte);

        // -- ADD 2011/07/14 ------------------------------------------->>>
        /// <summary>
        /// ���Џ��Ƀf�[�^�N���A���ԍX�V���܂�
        /// </summary>
        /// <param name="paraobj">�X�V����</param>
        /// <param name="DelYMD">�f�[�^�N���A�N����</param>
        /// <param name="DelHMSXXX">�f�[�^�N���A�����b�~���b</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Џ��Ƀf�[�^�N���A���ԍX�V���܂�</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        int WriteClearTime(
            [CustomSerializationMethodParameterAttribute("SFUKN09006D", "Broadleaf.Application.Remoting.ParamData.CompanyInfWork")]
            object paraobj, String DelYMD, String DelHMSXXX, out string errMsg);

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃f�[�^�N���A���Ԃ�߂��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="DelYMD">�f�[�^�N���A�N����</param>
        /// <param name="DelHMSXXX">�f�[�^�N���A�����b�~���b</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃f�[�^�N���A���Ԃ�߂��܂�</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        int ReadClearTime(string enterpriseCode, out Int32 DelYMD, out Int32 DelHMSXXX);
        // -- ADD 2011/07/14 -------------------------------------------<<<
	}
}

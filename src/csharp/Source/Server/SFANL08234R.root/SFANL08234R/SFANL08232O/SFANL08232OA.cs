using System;
using System.Collections;
using System.Data.SqlClient;

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���R���[�󎚈ʒu�ݒ�@DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       :���R���[�󎚈ʒu�ݒ�@DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22011�@�����@���l</br>
	/// <br>Date       : 2007.05.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		// �A�v���P�[�V�����T�[�o�[�̐ڑ���
	public interface IFrePrtPSetDLDB
	{
		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ茟������
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="OutputFormFileName">�o�̓t�@�C����</param>
		/// <param name="frePrtPSetWorkListkByte">�����������R���[�󎚈ʒu�ݒ胊�X�g</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���R���[�󎚈ʒu�ݒ�����������܂�</br>
		/// <br>           : ���o�̓t�@�C�������w�莞�A�S���X�g���擾���܂�</br>
		/// <br>           : �����R���[�󎚈ʒu�ݒ�f�[�^�A�w�i�摜�f�[�^�͎擾���܂���</br>
		/// <br>Programmer : 22011�@�����@���l</br>
		/// <br>Date       : 2007.05.24</br>
		/// </remarks>
        int Search(string EnterpriseCode, string OutputFormFileName, out byte[] frePrtPSetWorkListkByte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg);

        /// <summary>
        /// ���R���[�I���K�C�h��񌟍�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="printPaperUseDivcd">���[�敪�R�[�h(1:���[,2:�`�[)</param>
        /// <param name="printPaperDivCd">���[�敪�R�[�h(1:�������[,2:�������[,3:�N�����[,4:�������[)</param>
        /// <param name="dataInputSystem ">�f�[�^���̓V�X�e��(0:����,1:SF,2:BK,3:SH)</param>
        /// <param name="frePrtPSetSearchRetWork">�󎚈ʒu�ݒ胏�[�N�N���X�z��</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu�ݒ茟�����ʃN���X���[�NLIST���擾���܂��B</br>
        /// <br>Programmer	: 22024 ����@�_�u</br>
        /// <br>Date		: 2007.05.09</br>
        /// <br>Update Note : 22011 �����@���l</br>
        /// <br>            : �K�C�h�̃T�[�`��DL�p�����[�g�ɓ���</br>
        /// </remarks>
        int Search(string enterpriseCode, int printPaperUseDivcd, int printPaperDivCd, int[] dataInputSystem, out byte[] frePrtPSetSearchRetWork, out bool msgDiv, out string errMsg);
        

        /// <summary>
        /// ���R���[�󎚈ʒu�ݒ�E�w�i�摜�̎擾���s���܂��B
        /// </summary>
        /// <param name="frePrtPSetWorkByte">�󎚈ʒu�ݒ�f�[�^�p�����[�^(�L�[�l�݂̂��w��)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[�󎚈ʒu�ݒ�����擾���܂�</br>
        /// <br>Programmer : 22011�@�����@���l</br>
        /// <br>Date       : 2007.05.24</br>
        /// </remarks>
        int Read(ref byte[] frePrtPSetWorkByte, out bool msgDiv, out string errMsg);

        /// <summary>
        /// ���R���[�󎚈ʒu���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">FrePrtPSetWork�I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  ���R���[�󎚈ʒu���𕨗��폜���܂�</br>
        /// <br>Programmer : 22011�@�����@���l</br>
        /// <br>Date       : 2007.05.24</br>
        /// </remarks>
        int DeleteFrePrtPSet(byte[] parabyte, out bool msgDiv, out string errMsg);
    }
}
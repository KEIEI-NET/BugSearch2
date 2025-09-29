//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���[�����ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2010/05/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���[�����ݒ�}�X�^�����e�i���XDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���[�����ݒ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : �����</br>
	/// <br>Date       : 2010/05/24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��

	public interface IMailInfoSettingDB
	{
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
        /// ���[�����ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃��[�����ݒ�}�X�^LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
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
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);

		/// <summary>
        /// �w�肳�ꂽ���[�����ݒ�}�X�^Guid�̃��[�����ݒ�}�X�^��߂��܂�
		/// </summary>
		/// <param name="parabyte">MailSndMngWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���[�����ݒ�}�X�^Guid�̃��[�����ݒ�}�X�^��߂��܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ���[�����ݒ�}�X�^����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">MailSndMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�����ݒ�}�X�^����o�^�A�X�V���܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// ���[�����ݒ�}�X�^���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">MailSndMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�����ݒ�}�X�^���𕨗��폜���܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// ���[�����ݒ�}�X�^����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">MailSndMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�����ݒ�}�X�^����_���폜���܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// �_���폜���[�����ݒ�}�X�^���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">MailSndMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���[�����ݒ�}�X�^���𕜊����܂�</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		int RevivalLogicalDelete(ref byte[] parabyte);

        /// <summary>
        /// ���[�����M�Ǘ�LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="mailInfoSettingWork">��������</param>
        /// <param name="paraMailInfoSettingWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/05/24</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09596D", "Broadleaf.Application.Remoting.ParamData.MailInfoSettingWork")]
			out object mailInfoSettingWork,
           object paraMailInfoSettingWork, int readMode, ConstantManagement.LogicalMode logicalMode);
    }
}

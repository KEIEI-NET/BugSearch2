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
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// MailInfoSettingDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IMailInfoSettingDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���MailInfoSettingDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : �����</br>
	/// <br>Date       : 2010/05/24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationMailInfoSettingDB
	{
		/// <summary>
		/// MailInfoSettingDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : �����</br>
		/// <br>Date       : 2010/05/24</br>
		/// </remarks>
		public MediationMailInfoSettingDB()
		{
		}
        /// <summary>
        /// IMailInfoSettingDB�C���^�[�t�F�[�X�擾
        /// </summary>
        /// <returns>IMailInfoSettingDB�I�u�W�F�N�g</returns>
        public static IMailInfoSettingDB GetMailInfoSettingDB()
		{
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IMailInfoSettingDB)Activator.GetObject(typeof(IMailInfoSettingDB), string.Format("{0}/MyAppMailInfoSetting", wkStr));
        }
	}
}

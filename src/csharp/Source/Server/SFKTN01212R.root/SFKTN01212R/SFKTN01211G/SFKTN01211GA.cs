using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// SectionInfo����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��ISectionInfo�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���SectionInfo��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.08.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationSectionInfo
	{
		/// <summary>
		/// SectionInfo����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		public MediationSectionInfo()
		{
		}
		/// <summary>
		/// ISectionInfo�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>ISectionInfo�I�u�W�F�N�g</returns>
		public static ISectionInfo GetSectionInfo()
		{
			//�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ISectionInfo)Activator.GetObject(typeof(ISectionInfo),string.Format("{0}/MyAppSectionInfo",wkStr));
			//�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
		}
	}
}

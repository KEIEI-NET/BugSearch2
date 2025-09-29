using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// CompanyInfDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��ICompanyInfDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CompanyInfDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCompanyInfDB
	{
		/// <summary>
		/// CompanyInfDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		public MediationCompanyInfDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static ICompanyInfDB GetCompanyInfDB()
		{
//			return (ICompanyInfDB)Activator.GetObject(typeof(ICompanyInfDB),System.Configuration.ConfigurationSettings.AppSettings["CompanyInfDBUrl"]);

            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
//            return (ICompanyInfDB)Activator.GetObject(typeof(ICompanyInfDB),string.Format("{0}/MyAppCompanyInf",wkStr));
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            return (ICompanyInfDB)Activator.GetObject(typeof(ICompanyInfDB),string.Format("{0}/MyCompanyInf",wkStr));
            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
		}

	}
}

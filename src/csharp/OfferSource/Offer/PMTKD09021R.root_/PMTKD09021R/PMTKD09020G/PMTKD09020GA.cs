using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
    /// <summary>
    /// �񋟗D�ǐݒ�DB����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X��IPrimeSettingSearchDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
	public class MediationPrimeSettingDB
	{
		/// <summary>
        /// IPrimeSettingSearchDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// </remarks>
        public MediationPrimeSettingDB()
		{
		}
		/// <summary>
        /// IPrimeSettingSearchDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IPrimeSettingSearchDB�I�u�W�F�N�g</returns>
        public static IPrimeSettingDB GetPrimeSettingDB()
		{
			//�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPrimeSettingDB)Activator.GetObject(typeof(IPrimeSettingDB), string.Format("{0}/MyAppPrimeSetting", wkStr));
			//�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
		}
	}
}

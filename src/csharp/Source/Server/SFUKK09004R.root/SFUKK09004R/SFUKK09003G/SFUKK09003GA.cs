using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// TaxRateSetDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��ITaxRateSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���TaxRateSetDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 95016�@���c���@���F</br>
	/// <br>Date       : 2005.05.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationTaxRateSetDB
	{
		/// <summary>
		/// TaxRateSetDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 95016�@���c���@���F</br>
		/// <br>Date       : 2005.05.06</br>
		/// </remarks>
		public MediationTaxRateSetDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static ITaxRateSetDB GetTaxRateSetDB()
		{
//			return (ITaxRateSetDB)Activator.GetObject(typeof(ITaxRateSetDB),System.Configuration.ConfigurationSettings.AppSettings["TaxRateSetDBUrl"]);

            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ITaxRateSetDB)Activator.GetObject(typeof(ITaxRateSetDB),string.Format("{0}/MyAppTaxRateSet",wkStr));
            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
        }
	}
}

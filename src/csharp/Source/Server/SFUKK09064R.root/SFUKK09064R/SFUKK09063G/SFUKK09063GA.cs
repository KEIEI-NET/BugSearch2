using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// DepositStDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IDepositStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���DepositStDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 90027�@�����@��</br>
	/// <br>Date       : 2005.07.23</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationDepositStDB
	{
		/// <summary>
		/// DepositStDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2005.07.23</br>
		/// </remarks>
		public MediationDepositStDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static IDepositStDB GetDepositStDB()
		{
//			return (IDepositStDB)Activator.GetObject(typeof(IDepositStDB),System.Configuration.ConfigurationSettings.AppSettings["DepositStDBUrl"]);

            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IDepositStDB)Activator.GetObject(typeof(IDepositStDB),string.Format("{0}/MyAppDepositSt",wkStr));
            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
        }
	}
}

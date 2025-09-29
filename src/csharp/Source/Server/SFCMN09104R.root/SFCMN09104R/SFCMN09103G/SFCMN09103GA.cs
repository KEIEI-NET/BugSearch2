using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// NoMngSetDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��INoMngSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���NoMngSetDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 95016�@���c���@���F</br>
	/// <br>Date       : 2005.04.27</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationNoMngSetDB
	{
		/// <summary>
		/// NoMngSetDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 95016�@���c���@���F</br>
		/// <br>Date       : 2005.04.27</br>
		/// </remarks>
		public MediationNoMngSetDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static INoMngSetDB GetNoMngSetDB()
		{
//			return (INoMngSetDB)Activator.GetObject(typeof(INoMngSetDB),System.Configuration.ConfigurationSettings.AppSettings["NoMngSetDBUrl"]);

            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG

#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (INoMngSetDB)Activator.GetObject(typeof(INoMngSetDB),string.Format("{0}/MyAppNoMngSet",wkStr));
            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
        }
	}
}

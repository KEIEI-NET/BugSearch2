using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// FeliCaMngDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IFeliCaMngDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���FeliCaMngDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22011�@�������l</br>
	/// <br>Date       : 2008.10.30</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFeliCaMngDB
	{
		/// <summary>
		/// FeliCaMngDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22011�@�������l</br>
		/// <br>Date       : 2008.10.30</br>
		/// </remarks>
		public MediationFeliCaMngDB()
		{
		}
		/// <summary>
		/// IFeliCaMngDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IFeliCaMngDB�I�u�W�F�N�g</returns>
		public static IFeliCaMngDB GetFeliCaMngDB()
		{
			//�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
#if DEBUG
            string wkStr = "HTTP://localhost:8008";
#else
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#endif
            return (IFeliCaMngDB)Activator.GetObject(typeof(IFeliCaMngDB), string.Format("{0}/MyAppFeliCaMng", wkStr));
            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
		}
	}
}

using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// DepsitMainDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IDepsitMainDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���DepsitMainDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 95089�@���i�@��</br>
	/// <br>Date       : 2005.08.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationDepsitMainDB
	{
		/// <summary>
		/// DepsitMainDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 95089�@���i�@��</br>
		/// <br>Date       : 2005.08.08</br>
		/// </remarks>
		public MediationDepsitMainDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static IDepsitMainDB GetDepsitMainDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";            
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IDepsitMainDB)Activator.GetObject(typeof(IDepsitMainDB),string.Format("{0}/MyAppDepsitMain",wkStr));
		}
	}
}

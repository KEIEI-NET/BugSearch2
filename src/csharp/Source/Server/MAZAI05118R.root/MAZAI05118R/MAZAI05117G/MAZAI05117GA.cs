using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// InventoryExtDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IInventoryExtDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���InventoryExtDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2007.04.04</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationInventoryExtDB
	{
		/// <summary>
		/// InventoryExtDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2007.04.04</br>
		/// </remarks>
		public MediationInventoryExtDB()
		{
		}
		/// <summary>
		/// IInventoryExtDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IInventoryExtDB�I�u�W�F�N�g</returns>
        /// <br>Note       : IPrtsInvemtSearchDB�C���^�[�t�F�[�X���擾���܂��B</br>
        /// <br>Programmer : 22035 �O�� �O���@  </br>
        /// <br>Date       : 2007.04.04</br>
		public static IInventoryExtDB GetInventoryExtDB()
		{
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IInventoryExtDB)Activator.GetObject(typeof(IInventoryExtDB),string.Format("{0}/MyAppInventoryExt",wkStr));

        }
	}
}

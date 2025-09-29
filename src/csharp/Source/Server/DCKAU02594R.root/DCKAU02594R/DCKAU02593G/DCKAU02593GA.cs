using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// DemandBalanceLedgerDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IDemandBalanceLedgerDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���DemandBalanceLedgerDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22008 ���� ���n</br>
	/// <br>Date       : 2007.11.12</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
    public class MediationDemandBalanceLedgerDB
	{
		/// <summary>
        /// DemandBalanceLedgerDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.12</br>
		/// </remarks>
        public MediationDemandBalanceLedgerDB()
		{
		}
		/// <summary>
        /// IDemandBalanceLedgerDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IDemandBalanceLedgerDB�I�u�W�F�N�g</returns>
        public static IDemandBalanceLedgerDB GetDemandBalanceLedgerDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IDemandBalanceLedgerDB)Activator.GetObject(typeof(IDemandBalanceLedgerDB), string.Format("{0}/MyAppDemandBalanceLedger", wkStr));
		}
	}
}


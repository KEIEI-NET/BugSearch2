using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// PaymentBalanceLedgerDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IPaymentBalanceLedgerDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PaymentBalanceLedgerDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 980081 �R�c ���F</br>
	/// <br>Date       : 2007.10.03</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPaymentBalanceLedgerDB
	{
		/// <summary>
        /// PaymentBalanceLedgerDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.03</br>
		/// </remarks>
		public MediationPaymentBalanceLedgerDB()
		{
		}
		/// <summary>
        /// IPaymentBalanceLedgerDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IPaymentBalanceLedgerDB�I�u�W�F�N�g</returns>
        public static IPaymentBalanceLedgerDB GetPaymentBalanceLedgerDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPaymentBalanceLedgerDB)Activator.GetObject(typeof(IPaymentBalanceLedgerDB), string.Format("{0}/MyAppPaymentBalanceLedger", wkStr));
		}
	}
}

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// PaymentTableDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IPaymentTableDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PaymentTableDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 980081 �R�c ���F</br>
	/// <br>Date       : 2007.09.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPaymentTableDB
	{
		/// <summary>
        /// PaymentTableDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public MediationPaymentTableDB()
		{
		}
		/// <summary>
        /// IPaymentTableDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IPaymentTableDB�I�u�W�F�N�g</returns>
        public static IPaymentTableDB GetPaymentTableDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IPaymentTableDB)Activator.GetObject(typeof(IPaymentTableDB),string.Format("{0}/MyAppPaymentTable",wkStr));
		}
	}
}

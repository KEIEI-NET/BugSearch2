using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// ���R���[�i�������j DB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note         : ���̃N���X��IFrePDailyExtRet�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>               ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���FrePSalesSlipDB��</br>
	/// <br>               �C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer   : 22018�@��؁@���b</br>
	/// <br>Date         : 2008.05.28</br>
	/// <br></br>
	/// <br>Update Note  : </br>
	/// </remarks>
	public class MediationFrePBillDB
	{
		/// <summary>
        /// FrePSalesSlipDB DB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22018�@��؁@���b</br>
		/// <br>Date       : 2008.05.28</br>
		/// </remarks>
        public MediationFrePBillDB()
		{
		}
		/// <summary>
        /// IFrePSalesSlipDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
        public static IFrePBillDB GetFrePBillDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
# if DEBUG
            wkStr = "http://localhost:9001";
# endif
			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IFrePBillDB)Activator.GetObject( typeof( IFrePBillDB ), string.Format( "{0}/MyAppFrePBill", wkStr ) );
		}
	}
}

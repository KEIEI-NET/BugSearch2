using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// ���i�����ݒ�}�X�^����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IPriceChgProcStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���TaxRateSetDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.09.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPriceChgProcSt
	{
		/// <summary>
        /// ���i�����ݒ�}�X�^����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.19</br>
		/// </remarks>
		public MediationPriceChgProcSt()
		{
		}
		/// <summary>
        /// IPriceChgProcStDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IPriceChgProcStDB�I�u�W�F�N�g</returns>
        public static IPriceChgProcStDB GetPriceChgProcStDB()
		{
            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
            //USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "HTTP://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPriceChgProcStDB)Activator.GetObject(typeof(IPriceChgProcStDB), string.Format("{0}/MyAppPriceChgProcSt", wkStr));
            //�A�v���P�[�V�����T�[�o�[�ڑ��؂�ւ��Ή�����������
        }
	}
}

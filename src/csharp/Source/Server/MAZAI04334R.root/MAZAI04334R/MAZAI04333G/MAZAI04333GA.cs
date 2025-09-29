using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// StockAcPayHistDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IStockAcPayHistDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockAcPayHistDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.01.30</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationStockAcPayHistDB
	{
		/// <summary>
		/// StockAcPayHistDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.30</br>
		/// </remarks>
		public MediationStockAcPayHistDB()
		{
		}
		/// <summary>
        /// IStockAcPayHisDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IStockAcPayHisDB�I�u�W�F�N�g</returns>
		public static IStockAcPayHistDB GetStockAcPayHisDtDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IStockAcPayHistDB)Activator.GetObject(typeof(IStockAcPayHistDB),string.Format("{0}/MyAppStockAcPayHist",wkStr));
			                                                                                                 
		}
	}
}

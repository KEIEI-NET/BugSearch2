using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// StockMngTtlStDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IStockMngTtlStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockMngTtlStDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 20036�@�ē��@�떾</br>
	/// <br>Date       : 2007.03.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationStockMngTtlStDB
	{
		/// <summary>
		/// StockMngTtlStDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.03.02</br>
		/// </remarks>
		public MediationStockMngTtlStDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static IStockMngTtlStDB GetStockMngTtlStDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            //wkStr = "http://localhost:9001";  // dbg
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IStockMngTtlStDB)Activator.GetObject(typeof(IStockMngTtlStDB),string.Format("{0}/MyAppStockMngTtlSt",wkStr));
		}
	}
}

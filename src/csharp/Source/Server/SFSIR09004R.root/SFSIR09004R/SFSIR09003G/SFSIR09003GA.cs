using System;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// StockTtlStDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IStockTtlStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockTtlStDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.04.12</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationStockTtlStDB
	{
		/// <summary>
		/// StockTtlStDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public MediationStockTtlStDB()
		{
		}
		/// <summary>
		/// IStockTtlStDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IStockTtlStDB�I�u�W�F�N�g</returns>
		public static IStockTtlStDB GetStockTtlStDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IStockTtlStDB)Activator.GetObject(typeof(IStockTtlStDB),string.Format("{0}/MyAppStockTtlSt",wkStr));

		}
	}
}

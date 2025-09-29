using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// StockMoveDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IStockMoveDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StockMoveDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.01.19</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationStockMoveDB
	{
		/// <summary>
		/// StockMoveDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.19</br>
		/// </remarks>
		public MediationStockMoveDB()
		{
		}
		/// <summary>
        /// IStockMoveDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IStockMoveDB�I�u�W�F�N�g</returns>
		public static IStockMoveDB GetStockMoveDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG          
  wkStr = "http://localhost:9001";  //dbg
#endif            
            
			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IStockMoveDB)Activator.GetObject(typeof(IStockMoveDB),string.Format("{0}/MyAppStockMove",wkStr));
		}
	}
}

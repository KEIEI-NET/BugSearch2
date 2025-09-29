using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// GoodsDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IGoodsDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GoodsDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.02.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationGoodsDB
	{
		/// <summary>
		/// GoodsDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.02.06</br>
		/// </remarks>
		public MediationGoodsDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static IGoodsDB GetGoodsDB()
		{
			//OFFER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
			return (IGoodsDB)Activator.GetObject(typeof(IGoodsDB),string.Format("{0}/MyAppGoods",wkStr));
		}
	}
}

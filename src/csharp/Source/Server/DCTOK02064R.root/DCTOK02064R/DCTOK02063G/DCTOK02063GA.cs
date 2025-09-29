using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// ShipGoodsAnalyzeDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IShipGoodsAnalyzeDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���ShipGoodsAnalyzeDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 980081 �R�c ���F</br>
	/// <br>Date       : 2007.11.21</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationShipGoodsAnalyzeDB
	{
		/// <summary>
        /// ShipGoodsAnalyzeDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public MediationShipGoodsAnalyzeDB()
		{
		}
		/// <summary>
        /// IShipGoodsAnalyzeDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IShipGoodsAnalyzeDB�I�u�W�F�N�g</returns>
        public static IShipGoodsAnalyzeDB GetShipGoodsAnalyzeDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IShipGoodsAnalyzeDB)Activator.GetObject(typeof(IShipGoodsAnalyzeDB), string.Format("{0}/MyAppShipGoodsAnalyze", wkStr));
		}
	}
}

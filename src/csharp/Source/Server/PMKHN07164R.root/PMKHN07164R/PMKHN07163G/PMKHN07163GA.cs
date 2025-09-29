using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// ���i�}�X�^�G�N�X�|�[�g  DB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IGoodsExportDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GoodsExportDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date       : 2010/05/12</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationGoodsExportDB
	{
		/// <summary>
        /// GoodsExportDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 30517 �Ė� �x��</br>
        /// <br>Date       : 2010/05/12</br>
        /// </remarks>
        public MediationGoodsExportDB()
		{
		}
		/// <summary>
        /// IGoodsExportDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IGoodsExportDB�I�u�W�F�N�g</returns>
        public static IGoodsExportDB GetGoodsExportDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IGoodsExportDB)Activator.GetObject(typeof(IGoodsExportDB), string.Format("{0}/MyAppGoodsExport", wkStr));
		}
	}
}

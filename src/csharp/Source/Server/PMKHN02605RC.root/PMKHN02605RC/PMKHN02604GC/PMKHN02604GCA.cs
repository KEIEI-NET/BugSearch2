using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// ���i�}�X�^���  DB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IFutabaGoodsPrintDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���FutabaGoodsPrintDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFutabaGoodsPrintDB
	{
		/// <summary>
		/// FutabaGoodsPrintDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public MediationFutabaGoodsPrintDB()
		{
		}
		/// <summary>
        /// IFutabaGoodsPrintDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IFutabaGoodsPrintDB�I�u�W�F�N�g</returns>
        public static IFutabaGoodsPrintDB GetFutabaGoodsPrintDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IFutabaGoodsPrintDB)Activator.GetObject(typeof(IFutabaGoodsPrintDB), string.Format("{0}/MyAppFutabaGoodsPrint", wkStr));
		}
	}
}

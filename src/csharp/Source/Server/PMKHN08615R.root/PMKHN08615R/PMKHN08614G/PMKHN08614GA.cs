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
    /// <br>Note       : ���̃N���X��IGoodsPrintDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���GoodsPrintDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationGoodsPrintDB
	{
		/// <summary>
		/// GoodsPrintDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public MediationGoodsPrintDB()
		{
		}
		/// <summary>
        /// IGoodsPrintDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IGoodsPrintDB�I�u�W�F�N�g</returns>
        public static IGoodsPrintDB GetGoodsPrintDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IGoodsPrintDB)Activator.GetObject(typeof(IGoodsPrintDB), string.Format("{0}/MyAppGoodsPrint", wkStr));
		}
	}
}

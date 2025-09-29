using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// ImportantPrtStDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��ImportantPrtStDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���ImportantPrtStDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 20036�@�ē��@�떾</br>
	/// <br>Date       : 2007.03.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationImportantPrtStDB
	{
		/// <summary>
        /// ImportantPrtStDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.03.02</br>
		/// </remarks>
        public MediationImportantPrtStDB()
		{
		}
		/// <summary>
        /// IImportantPrtStDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IImportantPrtStDB�I�u�W�F�N�g</returns>
        public static IImportantPrtStDB GetImportantPrtStDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IImportantPrtStDB)Activator.GetObject(typeof(IImportantPrtStDB), string.Format("{0}/MyAppImportantPrtSt", wkStr));
		}
	}
}

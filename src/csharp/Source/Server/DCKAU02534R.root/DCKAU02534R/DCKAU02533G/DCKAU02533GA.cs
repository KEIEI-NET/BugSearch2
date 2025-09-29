using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// PaymentProgramDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��ICollectProgramDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PaymentProgramDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 980081 �R�c ���F</br>
	/// <br>Date       : 2007.11.15</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCollectProgramDB
	{
		/// <summary>
        /// PaymentProgramDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.15</br>
		/// </remarks>
		public MediationCollectProgramDB()
		{
		}
		/// <summary>
        /// ICollectProgramDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>ICollectProgramDB�I�u�W�F�N�g</returns>
        public static ICollectProgramDB GetCollectProgramDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ICollectProgramDB)Activator.GetObject(typeof(ICollectProgramDB), string.Format("{0}/MyAppCollectProgram", wkStr));
		}
	}
}

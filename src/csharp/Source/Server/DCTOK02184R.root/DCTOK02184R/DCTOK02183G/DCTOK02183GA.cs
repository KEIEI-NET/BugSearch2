using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// PastYearStatisticsDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IPastYearStatisticsDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PastYearStatisticsDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 980081 �R�c ���F</br>
	/// <br>Date       : 2007.12.04</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPastYearStatisticsDB
	{
		/// <summary>
        /// PastYearStatisticsDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
		/// </remarks>
		public MediationPastYearStatisticsDB()
		{
		}
		/// <summary>
        /// IPastYearStatisticsDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IPastYearStatisticsDB�I�u�W�F�N�g</returns>
        public static IPastYearStatisticsDB GetPastYearStatisticsDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            //AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IPastYearStatisticsDB)Activator.GetObject(typeof(IPastYearStatisticsDB), string.Format("{0}/MyAppPastYearStatistics", wkStr));
		}
	}
}

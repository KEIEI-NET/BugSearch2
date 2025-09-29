using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// OprtnHisLogDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IOprtnHisLogDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���OprtnHisLogDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
	/// <br>Date       : 2008.07.24</br>
	/// <br></br>
    /// </remarks>
	public class MediationOprtnHisLogDB
	{
		/// <summary>
		/// OprtnHisLogDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.24</br>
        /// </remarks>
		public MediationOprtnHisLogDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static IOprtnHisLogDB GetOprtnHisLogDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IOprtnHisLogDB)Activator.GetObject(typeof(IOprtnHisLogDB), string.Format("{0}/MyAppOprtnHisLog", wkStr));
		}
	}
}

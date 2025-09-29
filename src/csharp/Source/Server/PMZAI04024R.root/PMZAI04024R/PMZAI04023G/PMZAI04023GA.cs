using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// �݌ɑg���E��������  DB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IStckAssemOvhulDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���StckAssemOvhulDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.10.06</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationStckAssemOvhulDB
	{
		/// <summary>
		/// StckAssemOvhulDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.06</br>
        /// </remarks>
        public MediationStckAssemOvhulDB()
		{
		}
		/// <summary>
        /// IStckAssemOvhulDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>IStckAssemOvhulDB�I�u�W�F�N�g</returns>
        public static IStckAssemOvhulDB GetStckAssemOvhulDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            wkStr = "http://localhost:9001";
#endif

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (IStckAssemOvhulDB)Activator.GetObject(typeof(IStckAssemOvhulDB), string.Format("{0}/MyAppStckAssemOvhul", wkStr));
		}
	}
}

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// CustSlipMngDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��ICustSlipMngDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			 ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���CustSlipMngDB��</br>
	/// <br>			 �C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 20081�@�D�c�@�E�l</br>
	/// <br>Date       : 2007.09.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationCustSlipMngDB
	{
		/// <summary>
        /// SlipTypeMngDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 20081�@�D�c�@�E�l</br>
		/// <br>Date       : 2007.09.18</br>
		/// </remarks>
		public MediationCustSlipMngDB()
		{
		}
		/// <summary>
        /// ICustSlipMngDB�C���^�[�t�F�[�X�擾
		/// </summary>
        /// <returns>ICustSlipMngDB�I�u�W�F�N�g</returns>
		public static ICustSlipMngDB GetCustSlipMngDB()
		{
			//USER�f�[�^�A�v���P�[�V�����T�[�o�[��Path���擾�i�񋟃f�[�^AP�T�[�o�[�̏ꍇ�ɂ͈�����ς���j
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            
            //wkStr = "http://localhost:9001";

			//AppSettings����̎擾�͍s�킸�����ň���������𐶐�����
            return (ICustSlipMngDB)Activator.GetObject(typeof(ICustSlipMngDB), string.Format("{0}/MyAppCustSlipMng", wkStr));
		}
	}
}

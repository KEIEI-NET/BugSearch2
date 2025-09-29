using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// MediationDmdPrtPtnSetDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IDmdPrtPtnSetDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���DmdPrtPtnSetDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2007.07.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationDmdPrtPtnSetDB
	{
		/// <summary>
        /// DmdPrtPtnSetDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2007.07.02</br>
		/// </remarks>
        public MediationDmdPrtPtnSetDB()
		{
		}
		/// <summary>
        /// IDmdPrtPtnSetDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
        public static IDmdPrtPtnSetDB GetDmdPrtPtnSetDB()
		{
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            return (IDmdPrtPtnSetDB)Activator.GetObject(typeof(IDmdPrtPtnSetDB), string.Format("{0}/MyAppDmdPrtPtnSet", wkStr));
        }
	}
}

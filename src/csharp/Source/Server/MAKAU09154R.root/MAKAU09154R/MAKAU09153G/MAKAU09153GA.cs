using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
    /// MediationDmdPrtPtnDB����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���̃N���X��IDmdPrtPtnDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
    /// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���DmdPrtPtnDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2007.07.02</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationDmdPrtPtnDB
	{
		/// <summary>
        /// DmdPrtPtnDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2007.07.02</br>
		/// </remarks>
        public MediationDmdPrtPtnDB()
		{
		}
		/// <summary>
        /// IDmdPrtPtnDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
        public static IDmdPrtPtnDB GetDmdPrtPtnDB()
		{
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
#if DEBUG
            wkStr = "http://localhost:9001";
#endif
            return (IDmdPrtPtnDB)Activator.GetObject(typeof(IDmdPrtPtnDB), string.Format("{0}/MyAppDmdPrtPtn", wkStr));
        }
	}
}

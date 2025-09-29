using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// FreePprGrpDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IFreePprGrpDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			 ���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���FreePprGrpDB��</br>
	/// <br>		 	 �C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22011�@�����@���l</br>
	/// <br>Date       : 2007.05.22</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationFreePprGrpDB
	{
		/// <summary>
		/// FreePprGrpDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22011�@�����@���l</br>
		/// <br>Date       : 2007.05.22</br>
		/// </remarks>
		public MediationFreePprGrpDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static IFreePprGrpDB GetFreePprGrpDB()
		{
//            string wkStr = "HTTP://localhost:8008";
            string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
            return (IFreePprGrpDB)Activator.GetObject(typeof(IFreePprGrpDB),string.Format("{0}/MyAppFreePprGrp",wkStr));
        }
	}
}

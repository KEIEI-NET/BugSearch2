using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// PMakerNmDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IPMakerNmDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���PMakerNmDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 22027�@���{�@����</br>
	/// <br>Date       : 2006.06.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationPMakerNmDB
	{
		/// <summary>
		/// PMakerNmDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2006.06.08</br>
		/// </remarks>
		public MediationPMakerNmDB()
		{
		}
		/// <summary>
		/// IPMakerNmDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPMakerNmDB�I�u�W�F�N�g</returns>
		public static IPMakerNmDB GetPMakerNmDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_OfferAP);
#if DEBUG
            wkStr = "HTTP://localhost:9002";
#endif
			return (IPMakerNmDB)Activator.GetObject(typeof(IPMakerNmDB),string.Format("{0}/MyAppPMakerNm",wkStr));
		}
	}
}

using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.Adapter
{
	/// <summary>
	/// AlItmDspNmDB����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X��IAlItmDspNmDB�N���X�I�u�W�F�N�g��GetObject�Ŗ߂��܂��B</br>
	/// <br>			���S�X�^���h�A�����ɂ���ꍇ�ɂ͂��̃N���X�Œ���AlItmDspNmDB��</br>
	/// <br>			�C���X�^���X�����Ė߂��܂��B</br>
	/// <br>Programmer : 90027�@�����@��</br>
	/// <br>Date       : 2006.08.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class MediationAlItmDspNmDB
	{
		/// <summary>
		/// AlItmDspNmDB����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɃR���X�g���N�^���̏����͖����B</br>
		/// <br>Programmer : 90027�@�����@��</br>
		/// <br>Date       : 2006.08.28</br>
		/// </remarks>
		public MediationAlItmDspNmDB()
		{
		}
		/// <summary>
		/// IPrtmanageDB�C���^�[�t�F�[�X�擾
		/// </summary>
		/// <returns>IPrtmanageDB�I�u�W�F�N�g</returns>
		public static IAlItmDspNmDB GetAlItmDspNmDB()
		{
			string wkStr = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_UserAP);
			return (IAlItmDspNmDB)Activator.GetObject(typeof(IAlItmDspNmDB),string.Format("{0}/MyAppAlItmDspNm",wkStr));
		}
	}
}

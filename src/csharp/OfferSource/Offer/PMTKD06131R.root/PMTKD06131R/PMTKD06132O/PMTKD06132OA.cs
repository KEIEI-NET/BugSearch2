using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
	
namespace Broadleaf.Application.Remoting
{	
	
	/// <summary>
	/// �񋟎��q��񌋍�����DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �񋟎��q��񌋍����� RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 96186�@���ԁ@�T��</br>
	/// <br>Date       : 2007.03.05</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IPrdTypYearDB
	{		
		/// <summary>
		/// ���Y�N������߂��܂�
		/// </summary>
		/// <param name="prdTypYearRetWork"></param>
		/// <param name="prdTypYearCondWork"></param>
		/// <returns></returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186�@���ԁ@�T��</br>
		/// <br>Date       : 2007.03.05</br>
		[MustCustomSerialization]
		int SearchPrdTypYearInf(
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out object prdTypYearRetWork,
			object prdTypYearCondWork
		);


	}
}

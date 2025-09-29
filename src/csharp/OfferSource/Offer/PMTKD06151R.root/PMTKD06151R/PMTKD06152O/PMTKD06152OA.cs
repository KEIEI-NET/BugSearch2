using System;
using System.Collections;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

	
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
	public interface ICtgyMdlLnkDB
	{		
		/// <summary>
		/// �w�肳�ꂽ�p�����[�^�Œ񋟎��q��񌋍������擾���܂�
		/// </summary>
        /// <param name="ctgyMdlLnkCondWork">�����p�����[�^</param>
        /// <param name="ctgyMdlLnkRetWork">�擾�������</param>		
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 96186�@���ԁ@�T��</br>
		/// <br>Date       : 2007.03.05</br>
		[MustCustomSerialization]
		int GetCtgyMdlLnk(
			CtgyMdlLnkCondWork ctgyMdlLnkCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CtgyMdlLnkRetWork")]
			out ArrayList ctgyMdlLnkRetWork);
	
	}
}

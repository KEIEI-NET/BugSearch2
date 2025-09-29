using System;
using System.Collections;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
	
namespace Broadleaf.Application.Remoting
{	
	
	/// <summary>
    /// �ޕʑ������i���擾 RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �ޕʑ������i���擾 RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.07.29</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface ICategoryEquipmentDB
	{		
		/// <summary>
        /// �w�肳�ꂽ�p�����[�^�ŗޕʑ������i(TBO)�����擾���܂�
		/// </summary>
        /// <param name="retbyte">��������</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>		
        /// <param name="categoryNo">�ޕʔԍ�</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30290</br>
		/// <br>Date       : 2008.07.29</br>
		[MustCustomSerialization]
		int SearchCategoryEquipment(
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CategoryEquipmentRetWork")]
			out object retbyte,
			Int32 modelDesignationNo,
			Int32 categoryNo
		);

	}
}

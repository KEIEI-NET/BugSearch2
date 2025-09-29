using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// �d���`�[��� RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �d���`�[��� RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22013 kubo</br>
	/// <br>Date       : 2007.06.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStcDataRefListWorkDB
	{
		/// <summary>
		/// �d���`�[���List���擾����(�_���폜����)
		/// </summary>
		/// <param name="stcDataRefListWork">��������(�`�[)</param>
		/// <param name="stcDtlDataRefListWork">��������(�`�[����)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="supplierFomal">�d���`��</param>
		/// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : �`�[���List���擾����</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.06.06</br>
		/// </remarks>
        // �� 2007.12.04 980081 c
		//[MustCustomSerialization]
		//int Read(
		//	[CustomSerializationMethodParameter("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcDataRefWork")]
		//	out object stcDataRefListWork,
		//	[CustomSerializationMethodParameter("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcDtlDataRefWork")]
		//	out object stcDtlDataRefListWork,
		//	[CustomSerializationMethodParameter("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcExDataRefWork")]
		//	out object stcExDataRefListWork,
		//	string enterpriseCode,
		//	int supplierFomal,
		//	int supplierSlipNo,
		//	int readMode,
		//	ConstantManagement.LogicalMode logicalMode);
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameter("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcDataRefWork")]
			out object stcDataRefListWork,
            [CustomSerializationMethodParameter("MAKON02326D", "Broadleaf.Application.Remoting.ParamData.StcDtlDataRefWork")]
			out object stcDtlDataRefListWork,
            string enterpriseCode,
            int supplierFomal,
            int supplierSlipNo,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
        // �� 2007.12.04 980081 c

	}
}

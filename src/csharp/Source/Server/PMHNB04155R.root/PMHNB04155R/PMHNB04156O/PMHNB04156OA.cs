using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���㑬��\��DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���㑬��\��DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350 �N�� ����</br>
	/// <br>Date       : 2008.10.27</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesReportOrderWorkDB
	{
        
        /// <summary>
        /// ���㑬��\����LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="salesReportResultWork">��������</param>
        /// <param name=" salesReportOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30350 �N�� ����</br>
		/// <br>Date       : 2008.10.27</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB04157D", "Broadleaf.Application.Remoting.ParamData.SalesReportResultWork")]
			out object salesReportResultWork,
         object salesReportOrderCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);
	}
}

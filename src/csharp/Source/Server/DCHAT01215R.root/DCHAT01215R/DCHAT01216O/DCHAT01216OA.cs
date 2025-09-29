using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���������i�����_�jDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���������i�����_�jDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22008 ���� ���n</br>
	/// <br>Date       : 2007.10.23</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOrderPointOrderWorkDB
	{
        
    /// <summary>
    /// ���������i�����_�jLIST��S�Ė߂��܂��i�_���폜�����j
    /// </summary>
    /// <param name="orderPointOrderResultWork">��������</param>
    /// <param name=" orderPointOrderCndtnWork">�����p�����[�^</param>
    /// <param name="readMode">�����敪</param>
	/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	/// <returns>STATUS</returns>
	/// <br>Note       : </br>
	/// <br>Programmer : 22008 ���� ���n</br>
	/// <br>Date       : 2007.10.23</br>
    [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("DCHAT01213D", "Broadleaf.Application.Remoting.ParamData.AutoOrderResultWork")]
      			out object autoOrderResultWork,
            object orderPointOrderCndtnWork,
      			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}

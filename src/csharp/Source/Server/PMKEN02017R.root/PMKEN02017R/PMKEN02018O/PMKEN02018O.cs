using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �D�ǐݒ�}�X�^���DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �D�ǐݒ�}�X�^���DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350 �N�� ����</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPrmSettingPrintOrderWorkDB
	{
        
        /// <summary>
        /// �D�ǐݒ�}�X�^�����LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="prmSettingPrintResultWork">��������</param>
        /// <param name="prmSettingPrintOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30350 �N�� ����</br>
		/// <br>Date       : 2008.10.24</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN02019D", "Broadleaf.Application.Remoting.ParamData.PrmSettingPrintResultWork")]
			out object prmSettingPrintResultWork,
          object prmSettingPrintOrderCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}

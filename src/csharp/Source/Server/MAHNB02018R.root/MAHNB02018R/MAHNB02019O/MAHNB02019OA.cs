using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// �����m�F�\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �����m�F�\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2007.03.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
    /// <br>           :   2007.11.15  DC.NS �p�ɉ���  ���쏹��</br>
    /// <br></br>
    /// <br>Update Note: �o�l.�m�p�ɕύX </br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.07.01</br>
        /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IDepsitListWorkDB
	{
		/// <summary>
        /// �����m�F�\LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="depsitMainListResultWork">�������ʁi�����j</param>
        /// <param name="depsitMainListParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2007.03.06</br>
        [MustCustomSerialization]
		int SearchDepsitOnly(
            [CustomSerializationMethodParameterAttribute("MAHNB02016D", "Broadleaf.Application.Remoting.ParamData.DepsitMainListResultWork")]
			out object depsitMainListResultWork,
            object depsitMainListParamWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

        ///// <summary>
        ///// �����ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j
        ///// </summary>
        ///// <param name="depsitMainListResultWork">�������ʁi�����j</param>
        ///// <param name="depsitAlwcListResultWork">�������ʁi�����j</param>
        ///// <param name="depsitMainListParamWork">�����p�����[�^</param>
        ///// <param name="readMode">�����敪</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : </br>
        ///// <br>Programmer : 22035 �O�� �O��</br>
        ///// <br>Date       : 2007.03.06</br>
        //[MustCustomSerialization]
        //int SearchDepsitAndAllowance(
        //    [CustomSerializationMethodParameterAttribute("MAHNB02016D", "Broadleaf.Application.Remoting.ParamData.DepsitMainListResultWork")]
        //    out object depsitMainListResultWork,
        //    [CustomSerializationMethodParameterAttribute("MAHNB02016D", "Broadleaf.Application.Remoting.ParamData.DepsitAlwcListResultWork")]
        //    out object depsitAlwcListResultWork,
        //    object depsitMainListParamWork,
        //    int readMode,
        //    ConstantManagement.LogicalMode logicalMode);

        ///// <summary>
        ///// �����m�F�\LIST��S�Ė߂��܂��i�_���폜�����j
        ///// </summary>
        ///// <param name="depsitMainListResultWork">�������ʁi�����j</param>
        ///// <param name="depsitMainListParamWork">�����p�����[�^</param>
        ///// <param name="sectionDepositDiv">0:����̂݁A1:���큕���_�R�[�h</param>
        ///// <param name="readMode">�����敪</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : </br>
        ///// <br>Programmer : 22035 �O�� �O��</br>
        ///// <br>Date       : 2007.03.06</br>
        //[MustCustomSerialization]
        //int SearchAllTotal(
        //    [CustomSerializationMethodParameterAttribute("MAHNB02016D", "Broadleaf.Application.Remoting.ParamData.DepsitMainListResultWork")]
        //    out object depsitMainListResultWork,
        //    object depsitMainListParamWork,
        //    int sectionDepositDiv,
        //    int readMode,
        //    ConstantManagement.LogicalMode logicalMode);
	}
}

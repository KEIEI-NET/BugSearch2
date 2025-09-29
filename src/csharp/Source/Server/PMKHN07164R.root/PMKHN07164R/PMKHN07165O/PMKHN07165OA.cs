using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���i�}�X�^�G�N�X�|�[�g  DBRemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���i�}�X�^�G�N�X�|�[�g DBRemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date       : 2010/05/12</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsExportDB
	{
        /// <summary>
        /// �|���}�X�^LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="paraGoodsPrintResultWork">��������</param>
        /// <param name="paraGoodsPrintParamWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30517 �Ė� �x��</br>
        /// <br>Date       : 2010/05/12</br>
        [MustCustomSerialization]
		int Search(
             [CustomSerializationMethodParameterAttribute("PMKHN07166D", "Broadleaf.Application.Remoting.ParamData.GoodsExportResultWork")]
			 out object paraGoodsExportResultWork
            ,object paraGoodsExportParamWork
            ,ConstantManagement.LogicalMode logicalMode
            );
	}
}

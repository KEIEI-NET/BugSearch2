using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���i�}�X�^���  DBRemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���i�}�X�^��� DBRemoteObject Interface�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
	/// <br>Update Note: </br>
    /// <br>Update Note: �A�� 810 zhouyu </br>
    /// <br>Date       : 2011/08/12 </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsPrintDB
	{
        /// <summary>
        /// �|���}�X�^LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="paraGoodsPrintResultWork">��������</param>
        /// <param name="paraGoodsPrintParamWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        [MustCustomSerialization]
		int Search(
             [CustomSerializationMethodParameterAttribute("PMKHN08617D", "Broadleaf.Application.Remoting.ParamData.GoodsPrintResultWork")]
			 out object paraGoodsPrintResultWork
            ,object paraGoodsPrintParamWork
            ,ConstantManagement.LogicalMode logicalMode
            );

        //------------------------ADD 2011/08/12---------------------->>>>>
        /// <summary>
        /// ���i�Ǘ����擾�����Ǝd����
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="enterpriceCode">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�Ǘ����擾�����Ǝd����</br>
        /// <br>Programmer : zhouyu</br>
        /// <br>Date       : 2011/08/12</br>
        int SearchGoodsMsgSpler(
            [CustomSerializationMethodParameterAttribute("MAKHN09526D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
            [CustomSerializationMethodParameterAttribute("PMKHN09026D", "Broadleaf.Application.Remoting.ParamData.SupplierWork")]
            ref object retObj,
            string enterpriceCode,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
           );
        //------------------------ADD 2011/08/12----------------------<<<<<
	}
}

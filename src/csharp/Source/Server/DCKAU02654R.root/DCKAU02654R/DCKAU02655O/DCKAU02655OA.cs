using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �^�M�Ǘ��\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^�M�Ǘ��\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.11.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICreditMngListWorkDB
    {

        /// <summary>
        /// �^�M�Ǘ��\��߂��܂�
        /// </summary>
        /// <param name="creditMngListResultWork">��������</param>
        /// <param name=" creditMngListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.15</br>
        [MustCustomSerialization]
        int Search(
          [CustomSerializationMethodParameterAttribute("DCKAU02656D", "Broadleaf.Application.Remoting.ParamData.CreditMngListResultWork")]
          out object creditMngListResultWork, object creditMngListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode);

    }
}

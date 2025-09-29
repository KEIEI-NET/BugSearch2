using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���ϊm�F�\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ϊm�F�\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.11.12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEstimateListWorkDB
    {

        /// <summary>
        /// ���ϊm�F�\��߂��܂�
        /// </summary>
        /// <param name="estimateListResultWork">��������</param>
        /// <param name=" estimateListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.12</br>
        [MustCustomSerialization]
        int Search(
          [CustomSerializationMethodParameterAttribute("DCMIT02116D", "Broadleaf.Application.Remoting.ParamData.EstimateListResultWork")]
          out object estimateListResultWork, object estimateListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode);

    }
}

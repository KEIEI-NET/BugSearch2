using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����c������DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����c������DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.11.07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IDemandBalanceLedgerDB
    {

        /// <summary>
        /// �����c��������߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.07</br>
        [MustCustomSerialization]
        int SearchDemandBalanceLedger(
          [CustomSerializationMethodParameterAttribute("DCKAU02596D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_DemandBalanceWork")]
          out object retObj, object paraObj);

    }
}

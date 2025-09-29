using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �x���c������DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �x���c������DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.10.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPaymentBalanceLedgerDB
    {

        /// <summary>
        /// �x���c��������߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.03</br>
        [MustCustomSerialization]
        int SearchPaymentBalanceLedger([CustomSerializationMethodParameterAttribute("DCKAK02576D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PaymentBalanceWork")]out object retObj, object paraObj);

    }
}

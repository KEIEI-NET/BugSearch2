using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���|�c������DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���|�c������DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.11.09</br>
    /// <br></br>
    /// <br>Update Note: 2012/10/02 FSI�����@�v �d�����������Ή�</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAccPayBalanceLedgerDB
    {

        /// <summary>
        /// ���|�c��������߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        [MustCustomSerialization]
        int SearchAccPayBalanceLedger(
          [CustomSerializationMethodParameterAttribute("DCKAK02596D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccPayBalanceWork")]
          out object retObj, object paraObj);

        // ---------- ADD 2012/10/02 ---------->>>>>
        /// <summary>
        /// ���|�c��������߂��܂��i�d�������I�v�V�����L�����j
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI�����@�v</br>
        /// <br>Date       : 2012/10/02</br>
        [MustCustomSerialization]
        int SearchAccPayBalanceLedgerForSumOptOn(
          [CustomSerializationMethodParameterAttribute("DCKAK02596D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccPayBalanceWork")]
          out object retObj, object paraObj);
        // ---------- ADD 2012/10/02 ----------<<<<<
    }
}

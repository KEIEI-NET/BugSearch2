using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �������׈ꗗ�\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������׈ꗗ�\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.06.12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBillDetailTableDB
    {

        /// <summary>
        /// �������׈ꗗ�\��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.06.12</br>
        [MustCustomSerialization]
        int SearchBillDetailTable([CustomSerializationMethodParameterAttribute("MAKAU02052D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_DemandDetailWork")]out object retObj, object paraObj);
    }
}

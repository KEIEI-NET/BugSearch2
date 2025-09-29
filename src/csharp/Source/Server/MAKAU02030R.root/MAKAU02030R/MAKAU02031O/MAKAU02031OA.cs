using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����ꗗ�\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����ꗗ�\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.05.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBillTableDB
    {

        /// <summary>
        /// �����ꗗ�\��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.05.11</br>
        /// <br>Note       : </br>
        /// <br>Programmer : 30531�@��� �r��</br>
        /// <br>Date       : 2010.01.25</br>
        // --- ADD  ���r��  2010/01/25 ---------->>>>>
        //[MustCustomSerialization]
        //int SearchBillTable([CustomSerializationMethodParameterAttribute("MAKAU02032D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_DemandTotalWork")]out object retObj, object paraObj);
        int SearchBillTable(out object retObj, object paraObj);
        // --- ADD  ���r��  2010/01/25 ----------<<<<<
    }
}

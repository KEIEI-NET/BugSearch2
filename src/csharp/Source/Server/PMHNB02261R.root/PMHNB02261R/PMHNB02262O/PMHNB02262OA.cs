using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����ꗗ�\(����)DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����ꗗ�\(����)DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30350�@�N��@����</br>
    /// <br>Date       : 2009.04.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumBillTableDB
    {

        /// <summary>
        /// �����ꗗ�\(����)��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.13</br>
        /// <br>Note       : </br>
        /// <br>Update Note: 30531�@���@�r��</br>
        /// <br>Date       : 2010.02.01</br>
        [MustCustomSerialization]
        // --- ADD  ���r��  2010/02/01 ---------->>>>>
        //int SearchBillTable([CustomSerializationMethodParameterAttribute("PMHNB02263D", "Broadleaf.Application.Remoting.ParamData.SumRsltInfo_DemandTotalWork")]out object retObj, object paraObj);
        int SearchBillTable(out object retObj, object paraObj);
        // --- ADD  ���r��  2010/02/01 ----------<<<<<

    }
}

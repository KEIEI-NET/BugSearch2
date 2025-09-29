using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ߔN�x���v�\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ߔN�x���v�\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.12.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPastYearStatisticsDB
    {

        /// <summary>
        /// �ߔN�x���v�\��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̉ߔN�x���v�\��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.12.04</br>
        [MustCustomSerialization]
        int SearchPastYearStatistics([CustomSerializationMethodParameterAttribute("DCTOK02186D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PastYearStatisticsWork")]out object retObj, object paraObj);

    }
}

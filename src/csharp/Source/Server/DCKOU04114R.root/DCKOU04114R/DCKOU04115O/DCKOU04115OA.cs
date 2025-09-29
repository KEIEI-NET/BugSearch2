using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d�������Ɖ�DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�������Ɖ�DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2007.09.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStcHisRefDataDB
    {
        /// <summary>
        /// �d�������Ɖ�LIST��S�Ė߂��܂�(�_���폜����)
        /// </summary>
        /// <param name="stchisrefDataWork">��������</param>
        /// <param name="paramstchisrefExtraWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.21</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCKOU04116D", "Broadleaf.Application.Remoting.ParamData.StcHisRefDataWork")]
            out object stchisrefDataWork, object paramstchisrefExtraWork);
    }
}

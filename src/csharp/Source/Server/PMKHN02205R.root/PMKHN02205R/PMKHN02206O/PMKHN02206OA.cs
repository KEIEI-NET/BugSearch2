using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���j���[����ݒ���DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���j���[����ݒ���DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30747 �O�ˁ@�L��</br>
    /// <br>Date       : 2013/02/07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMenueStDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ���j���[����ݒ���LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="menueStWork">��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sortCode">�����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN02207D", "Broadleaf.Application.Remoting.ParamData.MenueStWork")]
            out object menueStWork, String enterpriseCode, Int32 sortCode);
        #endregion
    }
}

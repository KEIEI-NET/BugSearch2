using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �X�V����\��DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �X�V����\��DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUpdHisDspDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �X�V����\���f�[�^��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="rsltInfo_UpdHisDspWork">��������</param>
        /// <param name="extrInfo_UpdHisDspWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKAU04106D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_UpdHisDspWork")]
            out object rsltInfo_UpdHisDspWork,
            object extrInfo_UpdHisDspWork);
        #endregion
    }
}

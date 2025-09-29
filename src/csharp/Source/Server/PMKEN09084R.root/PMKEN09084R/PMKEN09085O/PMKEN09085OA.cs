using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ��փ}�X�^�V���֘A�\��DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��փ}�X�^�V���֘A�\��DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPartsSubstDspDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ��փ}�X�^�V���֘A�\���f�[�^��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="partsSubstUSearchResultWork">��������</param>
        /// <param name="partsSubstUSearchParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.01</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN09086D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUSearchResultWork")]
            out object partsSubstUSearchResultWork,
            object partsSubstUSearchParamWork);
        #endregion
    }
}

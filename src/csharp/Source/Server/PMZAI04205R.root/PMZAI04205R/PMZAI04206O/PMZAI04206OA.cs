using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �I���\��DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I���\��DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IInventoryDtDspDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �I���\���f�[�^��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="inventoryDataDspResultWork">��������</param>
        /// <param name="inventoryDataDspParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMZAI04207D", "Broadleaf.Application.Remoting.ParamData.InventoryDataDspResultWork")]
            out object inventoryDataDspResultWork,
            object inventoryDataDspParamWork);
        #endregion
    }
}

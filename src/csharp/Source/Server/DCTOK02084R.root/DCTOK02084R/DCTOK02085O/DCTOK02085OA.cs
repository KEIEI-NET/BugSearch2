using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d�����ڕ\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����ڕ\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : �R�c ���F</br>
    /// <br>Date       : 2007.11.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockTransListResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �d�����ڕ\�f�[�^��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="stockTransListResultWork">��������</param>
        /// <param name="stockTransListCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : �R�c ���F</br>
        /// <br>Date       : 2007.11.30</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCTOK02086D", "Broadleaf.Application.Remoting.ParamData.StockTransListResultWork")]
			out object stockTransListResultWork,
            object stockTransListCndtnWork);
        #endregion
    }
}

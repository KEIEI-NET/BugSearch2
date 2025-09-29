using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ɏ��яƉ�DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɏ��яƉ�DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockHisDspDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �݌Ɏ��яƉ�f�[�^��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="stockHistoryDspSearchResultWork">��������</param>
        /// <param name="stockHistoryDspSearchParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMZAI04107D", "Broadleaf.Application.Remoting.ParamData.StockHistoryDspSearchResultWork")]
            out object stockHistoryDspSearchResultWork,
            object stockHistoryDspSearchParamWork);

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�
        /// </summary>
        /// <param name="StockHistoryDspSearchResultWork">��������</param>
        /// <param name="StockHistoryDspSearchParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/07/20</br>
        [MustCustomSerialization]
        int SearchAll(
            [CustomSerializationMethodParameterAttribute("PMZAI04107D", "Broadleaf.Application.Remoting.ParamData.StockHistoryDspSearchResultWork")]
            out object stockHistoryDspSearchResultWork,
            object stockHistoryDspSearchParamWork);
        #endregion
    }
}

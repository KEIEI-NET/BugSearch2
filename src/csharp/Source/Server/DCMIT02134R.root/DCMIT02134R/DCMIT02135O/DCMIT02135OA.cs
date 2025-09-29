using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d������N��DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d������N��DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockMonthYearReportResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �d������N��f�[�^��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="stockMonthYearReportResultWork">��������</param>
        /// <param name="stockMonthYearReportParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.21</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCMIT02136D", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportResultWork")]
			out object stockMonthYearReportResultWork,
          object stockMonthYearReportParamWork);
        #endregion
    }
}

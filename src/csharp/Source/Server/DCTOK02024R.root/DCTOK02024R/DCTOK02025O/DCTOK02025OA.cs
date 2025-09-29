using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ������񌎕�DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������񌎕�DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.16</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�Ή�</br>
    /// <br>           : 23015 �X�{ ��P</br>
    /// <br>           : 2008.08.13</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesDayMonthReportResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ������񌎕�f�[�^��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="salesDayMonthReportResultWork">��������</param>
        /// <param name="salesDayMonthReportParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.16</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.13</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCTOK02026D", "Broadleaf.Application.Remoting.ParamData.SalesDayMonthReportResultWork")]
			out object salesDayMonthReportResultWork,
            object salesDayMonthReportParamWork);
        #endregion
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�ʎ�����z�\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʎ�����z�\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 23012 �����@�[���N</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustSalesDistributionReportResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ���Ӑ�ʎ�����z�\�f�[�^��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="CustSalesDistributionReportResult">��������</param>
        /// <param name="custSalesDistributionReportParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 �����@�[���N</br>
        /// <br>Date       : 2008.11.21</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB02189D", "Broadleaf.Application.Remoting.ParamData.CustSalesDistributionReportResultWork")]
			out object custSalesDistributionReportResultWork,
            object custSalesDistributionReportParamWork);
        #endregion
    }
}

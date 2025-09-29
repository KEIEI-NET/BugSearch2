using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �o�׏��i���ʕ\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i���ʕ\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.30</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�Ή�</br>
    /// <br>           : 23015 �X�{ ��P</br>
    /// <br>           : 2008.08.25</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IShipmGoodsOdrReportResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �o�׏��i���ʕ\�f�[�^��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="shipmGoodsOdrReportResultWork">��������</param>
        /// <param name="shipmGoodsOdrReportParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.21</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCHNB02066D", "Broadleaf.Application.Remoting.ParamData.ShipmGoodsOdrReportResultWork")]
			out object shipmGoodsOdrReportResultWork,
         object shipmGoodsOdrReportParamWork);
        #endregion
    }
}

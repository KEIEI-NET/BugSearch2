using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����ڕW�ݒ�}�X�^���DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����ڕW�ݒ�}�X�^���DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalTrgtPrintResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ����ڕW�ݒ�}�X�^����f�[�^��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="SalTrgtPrintResult">��������</param>
        /// <param name="salTrgtPrintParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN08637D", "Broadleaf.Application.Remoting.ParamData.SalTrgtPrintResultWork")]
			out object salTrgtPrintResultWork,
            object salTrgtPrintParamWork,
            ConstantManagement.LogicalMode logicalMode);
        #endregion
    }
}

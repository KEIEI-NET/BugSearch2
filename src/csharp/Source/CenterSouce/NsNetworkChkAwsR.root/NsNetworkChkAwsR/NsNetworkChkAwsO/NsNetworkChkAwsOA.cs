using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �l�b�g���[�N�ʐM����DBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �l�b�g���[�N�ʐM����DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2019.01.02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]
    public interface IAWSCommTstRsltDB
    {
        /// <summary>
        /// �l�b�g���[�N�ʐM�e�X�g���ʓo�^����
        /// </summary>
        /// <param name="aWSCommTstRsltWorkList">�l�b�g���[�N�ʐM�e�X�g���ʃp�����[�^���X�g</param>
        /// <param name="msgDiv">���b�Z�[�W�\���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int WriteDBData(
            [CustomSerializationMethodParameterAttribute("NsNetworkChkAwsD", "Broadleaf.Application.Remoting.ParamData.AWSComRsltWork")]
            ref object aWSCommTstRsltWorkList,
            out bool msgDiv,
            out string errMsg);
    }
}

//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���Ӑ�}�X�^�i�^�M�ݒ�jDB�C���^�[�t�F�[�X
//                  :   PMKHN09266O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.10.14
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�}�X�^�i�^�M�ݒ�jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^�i�^�M�ݒ�jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustCreditDB
    {
        /// <summary>
        /// ���Ӑ�}�X�^�i�^�M�ݒ�j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="resultList">�ǉ��E�X�V��̓��Ӑ�}�X�^�i�^�M�ݒ�j�����܂� ArrayList</param>
        /// <param name="paraCustCreditCndtn">���o�����N���X</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList �Ɋi�[����Ă��链�Ӑ�}�X�^�i�^�M�ݒ�j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.14</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09146D", "Broadleaf.Application.Remoting.ParamData.CustomerChangeWork")]
            out object resultList, object paraCustCreditCndtn);
    }
}

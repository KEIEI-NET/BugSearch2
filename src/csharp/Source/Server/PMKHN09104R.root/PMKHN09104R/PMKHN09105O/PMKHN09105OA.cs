//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   CustSlipNoSetDB�C���^�[�t�F�[�X
//                  :   PMKHN09105O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 �D�c �E�l
// Date             :   2008.06.16
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// CustSlipNoSetDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : CustSlipNoSetDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2008.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustSlipNoSetDB
    {
        /// <summary>
        /// �P���CustSlipNoSet�����擾���܂��B
        /// </summary>
        /// <param name="custSlipNoSetObj">CustSlipNoSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSet�̃L�[�l����v����CustSlipNoSet�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            ref object custSlipNoSetObj,
            int readMode);

        /// <summary>
        /// CustSlipNoSet���𕨗��폜���܂�
        /// </summary>
        /// <param name="custSlipNoSetList">�����폜����CustSlipNoSet�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSet�̃L�[�l����v����CustSlipNoSet���𕨗��폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            object custSlipNoSetList);

        /// <summary>
        /// CustSlipNoSet���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">��������</param>
        /// <param name="custSlipNoSetObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSet�̃L�[�l����v����A�S�Ă�CustSlipNoSet�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            ref object custSlipNoSetList,
            object custSlipNoSetObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// CustSlipNoSet����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�ǉ��E�X�V����CustSlipNoSet�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList �Ɋi�[����Ă���CustSlipNoSet����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            ref object custSlipNoSetList);

        /// <summary>
        /// CustSlipNoSet����_���폜���܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�_���폜����CustSlipNoSet�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork �Ɋi�[����Ă���CustSlipNoSet����_���폜���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            ref object custSlipNoSetList);

        /// <summary>
        /// CustSlipNoSet���̘_���폜���������܂��B
        /// </summary>
        /// <param name="custSlipNoSetList">�_���폜����������CustSlipNoSet�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork �Ɋi�[����Ă���CustSlipNoSet���̘_���폜���������܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.06.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09106D","Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork")]
            ref object custSlipNoSetList);
    }
}

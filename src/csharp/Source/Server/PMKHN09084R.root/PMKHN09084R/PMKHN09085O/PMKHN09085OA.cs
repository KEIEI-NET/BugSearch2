//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���Ӑ�i�������jDB�C���^�[�t�F�[�X
//                  :   PMKHN09085O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.06.06
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�i�������jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�i�������jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.06.06</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustDmdSetDB
    {
        /// <summary>
        /// �P��̓��Ӑ�i�������j�����擾���܂��B
        /// </summary>
        /// <param name="custDmdSetObj">CustDmdSetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�i�������j�̃L�[�l����v���链�Ӑ�i�������j�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.06</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            ref object custDmdSetObj,
            int readMode);

        /// <summary>
        /// ���Ӑ�i�������j���𕨗��폜���܂�
        /// </summary>
        /// <param name="custDmdSetList">�����폜���链�Ӑ�i�������j�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�i�������j�̃L�[�l����v���链�Ӑ�i�������j���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.06</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            object custDmdSetList);

        /// <summary>
        /// ���Ӑ�i�������j���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="custDmdSetList">��������</param>
        /// <param name="custDmdSetObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�i�������j�̃L�[�l����v����A�S�Ă̓��Ӑ�i�������j�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            ref object custDmdSetList,
            object custDmdSetObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���Ӑ�i�������j����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="custDmdSetList">�ǉ��E�X�V���链�Ӑ�i�������j�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custDmdSetList �Ɋi�[����Ă��链�Ӑ�i�������j����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            ref object custDmdSetList);

        /// <summary>
        /// ���Ӑ�i�������j����_���폜���܂��B
        /// </summary>
        /// <param name="custDmdSetList">�_���폜���链�Ӑ�i�������j�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custDmdSetWork �Ɋi�[����Ă��链�Ӑ�i�������j����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            ref object custDmdSetList);

        /// <summary>
        /// ���Ӑ�i�������j���̘_���폜���������܂��B
        /// </summary>
        /// <param name="custDmdSetList">�_���폜���������链�Ӑ�i�������j�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custDmdSetWork �Ɋi�[����Ă��链�Ӑ�i�������j���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09086D", "Broadleaf.Application.Remoting.ParamData.CustDmdSetWork")]
            ref object custDmdSetList);
    }
}

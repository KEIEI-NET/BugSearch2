//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���Ӑ�(�|���O���[�v)�}�X�^DB�C���^�[�t�F�[�X
//                  :   PMKHN09175O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   23012�@���� �[���N
// Date             :   2008.10.07
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
    /// ���Ӑ�(�|���O���[�v)�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 23012�@���� �[���N</br>
    /// <br>Date       : 2008.10.07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustRateGroupDB
    {
        /// <summary>
        /// �P��̓��Ӑ�(�|���O���[�v)�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="custRateGroupObj">CustRateGroupWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̃L�[�l����v���链�Ӑ�(�|���O���[�v)�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroup")]
            ref object custRateGroupObj,
            int readMode);

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="custRateGroupList">�����폜���链�Ӑ�(�|���O���[�v)�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̃L�[�l����v���链�Ӑ�(�|���O���[�v)�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork")]
            object custRateGroupList);

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="custRateGroupList">��������</param>
        /// <param name="custRateGroupObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̃L�[�l����v����A�S�Ă̓��Ӑ�(�|���O���[�v)�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork")]
            ref object custRateGroupList,
            object custRateGroupObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="custRateGroupList">�ǉ��E�X�V���链�Ӑ�(�|���O���[�v)�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custRateGroupList �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork")]
            ref object custRateGroupList);

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="custRateGroupList">�_���폜���链�Ӑ�(�|���O���[�v)�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custRateGroupWork �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork")]
            ref object custRateGroupList);

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="custRateGroupList">�_���폜���������链�Ӑ�(�|���O���[�v)�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custRateGroupWork �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork")]
            ref object custRateGroupList);
    }
}

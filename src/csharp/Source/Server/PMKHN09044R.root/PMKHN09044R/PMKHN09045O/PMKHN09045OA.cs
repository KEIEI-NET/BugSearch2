//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �������i�}�X�^DB�C���^�[�t�F�[�X
//                  :   PMKHN09045O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008�@���� ���n
// Date             :   2008.06.10
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
    /// �������i�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������i�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IIsolIslandPrcDB
    {
        /// <summary>
        /// �P��̗������i�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="isolIslandPrcObj">IsolIslandPrcWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������i�}�X�^�̃L�[�l����v���闣�����i�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            ref object isolIslandPrcObj,
            int readMode);

        /// <summary>
        /// �������i�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="isolIslandPrcList">�����폜���闣�����i�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������i�}�X�^�̃L�[�l����v���闣�����i�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            object isolIslandPrcList);

        /// <summary>
        /// �������i�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="isolIslandPrcList">��������</param>
        /// <param name="isolIslandPrcObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������i�}�X�^�̃L�[�l����v����A�S�Ă̗������i�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            ref object isolIslandPrcList,
            object isolIslandPrcObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �������i�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="isolIslandPrcList">�ǉ��E�X�V���闣�����i�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcList �Ɋi�[����Ă��闣�����i�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            ref object isolIslandPrcList);

        /// <summary>
        /// �������i�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="isolIslandPrcList">�_���폜���闣�����i�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcWork �Ɋi�[����Ă��闣�����i�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            ref object isolIslandPrcList);

        /// <summary>
        /// �������i�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="isolIslandPrcList">�_���폜���������闣�����i�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcWork �Ɋi�[����Ă��闣�����i�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork")]
            ref object isolIslandPrcList);
    }
}

//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���i��փ}�X�^DB�C���^�[�t�F�[�X
//                  :   PMKEN09095O.DLL
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
    /// ���i��փ}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i��փ}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPartsSubstUDB
    {
        /// <summary>
        /// �P��̕��i��փ}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="partsSubstUObj">PartsSubstUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v���镔�i��փ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            ref object partsSubstUObj,
            int readMode);

        /// <summary>
        /// ���i��փ}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="partsSubstUList">�����폜���镔�i��փ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v���镔�i��փ}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            object partsSubstUList);

        /// <summary>
        /// ���i��փ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="partsSubstUList">��������</param>
        /// <param name="partsSubstUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v����A�S�Ă̕��i��փ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            ref object partsSubstUList,
            object partsSubstUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i��փ}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="partsSubstUList">�ǉ��E�X�V���镔�i��փ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList �Ɋi�[����Ă��镔�i��փ}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            ref object partsSubstUList);

        /// <summary>
        /// ���i��փ}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="partsSubstUList">�_���폜���镔�i��փ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork �Ɋi�[����Ă��镔�i��փ}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            ref object partsSubstUList);

        /// <summary>
        /// ���i��փ}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="partsSubstUList">�_���폜���������镔�i��փ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork �Ɋi�[����Ă��镔�i��փ}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKEN09096D","Broadleaf.Application.Remoting.ParamData.PartsSubstUWork")]
            ref object partsSubstUList);
    }
}

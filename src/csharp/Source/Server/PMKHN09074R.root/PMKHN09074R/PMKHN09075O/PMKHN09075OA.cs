//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���i�����ރ}�X�^DB�C���^�[�t�F�[�X
//                  :   PMKHN09075O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.06.05
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
    /// ���i�����ރ}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�����ރ}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsGroupUDB
    {
        /// <summary>
        /// �P��̏��i�����ރ}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="goodsGroupUObj">GoodsGroupUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�����ރ}�X�^�̃L�[�l����v���鏤�i�����ރ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            ref object goodsGroupUObj,
            int readMode);

        /// <summary>
        /// ���i�����ރ}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="goodsGroupUList">�����폜���鏤�i�����ރ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�����ރ}�X�^�̃L�[�l����v���鏤�i�����ރ}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            object goodsGroupUList);

        /// <summary>
        /// ���i�����ރ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="goodsGroupUList">��������</param>
        /// <param name="goodsGroupUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�����ރ}�X�^�̃L�[�l����v����A�S�Ă̏��i�����ރ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            ref object goodsGroupUList,
            object goodsGroupUObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i�����ރ}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="goodsGroupUList">�ǉ��E�X�V���鏤�i�����ރ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUList �Ɋi�[����Ă��鏤�i�����ރ}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            ref object goodsGroupUList);

        /// <summary>
        /// ���i�����ރ}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="goodsGroupUList">�_���폜���鏤�i�����ރ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUWork �Ɋi�[����Ă��鏤�i�����ރ}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            ref object goodsGroupUList);

        /// <summary>
        /// ���i�����ރ}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="goodsGroupUList">�_���폜���������鏤�i�����ރ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : goodsGroupUWork �Ɋi�[����Ă��鏤�i�����ރ}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09076D", "Broadleaf.Application.Remoting.ParamData.GoodsGroupUWork")]
            ref object goodsGroupUList);
    }
}

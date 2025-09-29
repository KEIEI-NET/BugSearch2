//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �����S�̐ݒ�}�X�^DB�C���^�[�t�F�[�X
//                  :   SFUKK09105O.DLL
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
    /// �����S�̐ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����S�̐ݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBillAllStDB
    {
        /// <summary>
        /// �P��̐����S�̐ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="billAllStObj">BillAllStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����S�̐ݒ�}�X�^�̃L�[�l����v���鐿���S�̐ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            ref object billAllStObj,
            int readMode);

        /// <summary>
        /// �����S�̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="billAllStList">�����폜���鐿���S�̐ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����S�̐ݒ�}�X�^�̃L�[�l����v���鐿���S�̐ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            object billAllStList);

        /// <summary>
        /// �����S�̐ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="billAllStList">��������</param>
        /// <param name="billAllStObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����S�̐ݒ�}�X�^�̃L�[�l����v����A�S�Ă̐����S�̐ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            ref object billAllStList,
            object billAllStObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �����S�̐ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="billAllStList">�ǉ��E�X�V���鐿���S�̐ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            ref object billAllStList);

        /// <summary>
        /// �����S�̐ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="billAllStList">�_���폜���鐿���S�̐ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            ref object billAllStList);

        /// <summary>
        /// �����S�̐ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="billAllStList">�_���폜���������鐿���S�̐ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork �Ɋi�[����Ă��鐿���S�̐ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.05</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork")]
            ref object billAllStList);
    }
}

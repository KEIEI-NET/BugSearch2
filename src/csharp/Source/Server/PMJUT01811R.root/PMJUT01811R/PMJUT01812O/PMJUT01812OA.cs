//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �󒍃}�X�^(�ԗ�)DB�C���^�[�t�F�[�X
//                  :   PMJUT01812O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc
// Date             :   2008.05.28
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
    /// �󒍃}�X�^(�ԗ�)DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󒍃}�X�^(�ԗ�)DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc</br>
    /// <br>Date       : 2008.05.28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAcceptOdrCarDB
    {
        /// <summary>
        /// �P��̎󒍃}�X�^(�ԗ�)�����擾���܂��B
        /// </summary>
        /// <param name="acceptOdrCarObj">AcceptOdrCarWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMJUT01813D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork")]
            ref object acceptOdrCarObj,
            int readMode);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)��񃊃X�g���擾���܂��B
        /// </summary>
        /// <param name="acceptOdrCarObj">���o�������X�g(AcceptOdrCarWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : 22008�@����</br>
        /// <br>Date       : 2009.05.28</br>
        int ReadAll(
            [CustomSerializationMethodParameterAttribute("PMJUT01813D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork")]
            ref object acceptOdrCarObj);
        
        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���𕨗��폜���܂�
        /// </summary>
        /// <param name="acceptOdrCarList">�����폜����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object acceptOdrCarList);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="acceptOdrCarList">��������</param>
        /// <param name="acceptOdrCarObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����A�S�Ă̎󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object acceptOdrCarList,
            object acceptOdrCarObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="acceptOdrCarList">�ǉ��E�X�V����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object acceptOdrCarList);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)����_���폜���܂��B
        /// </summary>
        /// <param name="acceptOdrCarList">�_���폜����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����_���폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object acceptOdrCarList);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̘_���폜���������܂��B
        /// </summary>
        /// <param name="acceptOdrCarList">�_���폜����������󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : acceptOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���̘_���폜���������܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.05.28</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMJUT01813D","Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork")]
            ref object acceptOdrCarList);
    }
}

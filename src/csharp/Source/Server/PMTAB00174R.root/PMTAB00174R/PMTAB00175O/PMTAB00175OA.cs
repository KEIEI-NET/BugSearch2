//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �󒍃}�X�^(�ԗ�)DB�C���^�[�t�F�[�X
// �v���O�����T�v   : �󒍃}�X�^(�ԗ�)DB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt
// �� �� ��  2013/05/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �󒍃}�X�^(�ԗ�)DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �󒍃}�X�^(�ԗ�)DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/05/30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPmTabAcpOdrCarDB
    { 
        /// <summary>
        /// �P��̎󒍃}�X�^(�ԗ�)�����擾���܂��B
        /// </summary>
        /// <param name="pmTabAcceptOdrCarObj">PmTabAcpOdrCarWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarObj,
            int readMode);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)��񃊃X�g���擾���܂��B
        /// </summary>
        /// <param name="pmTabAcceptOdrCarObj">���o�������X�g(PmTabAcpOdrCarWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        int ReadAll(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarObj);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmTabAcceptOdrCarList">�����폜����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����󒍃}�X�^(�ԗ�)���𕨗��폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            object pmTabAcceptOdrCarList);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmTabAcceptOdrCarList">��������</param>
        /// <param name="pmTabAcceptOdrCarObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �󒍃}�X�^(�ԗ�)�̃L�[�l����v����A�S�Ă̎󒍃}�X�^(�ԗ�)�����擾���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarList,
            object pmTabAcceptOdrCarObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmTabAcceptOdrCarList">�ǉ��E�X�V����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcceptOdrCarList �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarList);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)����_���폜���܂��B
        /// </summary>
        /// <param name="pmTabAcceptOdrCarList">�_���폜����󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcceptOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)����_���폜���܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarList);

        /// <summary>
        /// �󒍃}�X�^(�ԗ�)���̘_���폜���������܂��B
        /// </summary>
        /// <param name="pmTabAcceptOdrCarList">�_���폜����������󒍃}�X�^(�ԗ�)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmTabAcceptOdrCarWork �Ɋi�[����Ă���󒍃}�X�^(�ԗ�)���̘_���폜���������܂��B</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/05/30</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB00176D", "Broadleaf.Application.Remoting.ParamData.PmTabAcpOdrCarWork")]
            ref object pmTabAcceptOdrCarList);
    }
}

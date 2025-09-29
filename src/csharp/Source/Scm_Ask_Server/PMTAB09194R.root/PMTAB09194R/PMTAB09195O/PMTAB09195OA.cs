//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PMTAB�����\���]�ƈ��ݒ�}�X�^DB�C���^�[�t�F�[�X
// �v���O�����T�v   : PMTAB�����\���]�ƈ��ݒ�}�X�^DB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/08/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB�����\���]�ƈ��ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPmtDefEmpDB
    {
        /// <summary>
        /// �P���PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpObj">PmtDefEmpWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpObj
            );

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^��񃊃X�g���擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpObj">���o�������X�g(PmtDefEmpWork)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B</br>
        int ReadAll(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpObj);

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="pmtDefEmpList">�����폜����PMTAB�����\���]�ƈ��ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����PMTAB�����\���]�ƈ��ݒ�}�X�^���𕨗��폜���܂��B</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            object pmtDefEmpList);

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">��������</param>
        /// <param name="pmtDefEmpObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�����\���]�ƈ��ݒ�}�X�^�̃L�[�l����v����A�S�Ă�PMTAB�����\���]�ƈ��ݒ�}�X�^�����擾���܂��B</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpList,
            object pmtDefEmpObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�ǉ��E�X�V����PMTAB�����\���]�ƈ��ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpList �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpList);

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�_���폜����PMTAB�����\���]�ƈ��ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpWord �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^����_���폜���܂��B</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpList);

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="pmtDefEmpList">�_���폜����������PMTAB�����\���]�ƈ��ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pmtDefEmpWord �Ɋi�[����Ă���PMTAB�����\���]�ƈ��ݒ�}�X�^���̘_���폜���������܂��B</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMTAB09196D", "Broadleaf.Application.Remoting.ParamData.PmtDefEmpWork")]
            ref object pmtDefEmpList);
    }
}
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC���Аݒ�}�X�^�����e
// �v���O�����T�v   : PCC���Аݒ�}�X�^�����eDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PCC���Аݒ�}�X�^�����eDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC���Аݒ�}�X�^�����eDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPccCmpnyStDB
    {

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            ref object pccCmpnyStWorkList);

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="parsePccCmpnyStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            out object pccCmpnyStWorkList, 
            PccCmpnyStWork parsePccCmpnyStWork, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            ref object pccCmpnyStWorkList, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            ref object pccCmpnyStWorkList);

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            ref object pccCmpnyStWorkList);

        /// <summary>
        /// PCC���Аݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC���Аݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09016D", "Broadleaf.Application.Remoting.ParamData.PccCmpnyStWork")]
            ref object pccCmpnyStWorkList);

    }
}
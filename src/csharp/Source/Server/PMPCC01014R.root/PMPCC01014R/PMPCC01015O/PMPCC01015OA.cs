//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����b�Z�[�W�ݒ菈��
// �v���O�����T�v   : ���[�����b�Z�[�W�ݒ菈��DB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.09  �C�����e : �V�K�쐬
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
    /// ���[�����b�Z�[�W�ݒ菈��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�����b�Z�[�W�ݒ菈��DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPccMailDtDB
    {

        /// <summary>
        /// ���[�����b�Z�[�W�ݒ菈���o�^�A�X�V����
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList);

        /// <summary>
        /// ���[�����b�Z�[�W�ݒ茟������
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <param name="parsePccMailDtWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList, 
            PccMailDtWork parsePccMailDtWork, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���[�����b�Z�[�W�ݒ茟������
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���[�����b�Z�[�W�ݒ�_���폜����
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList);

        /// <summary>
        /// ���[�����b�Z�[�W�ݒ蕨���폜����
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList);

        /// <summary>
        /// ���[�����b�Z�[�W�ݒ蕜������
        /// </summary>
        /// <param name="pccMailDtWorkList">PCC���[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC01016D", "Broadleaf.Application.Remoting.ParamData.PccMailDtWork")]
            ref object pccMailDtWorkList);

    }
}
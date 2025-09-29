//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC�i�ڃ}�X�^�����e
// �v���O�����T�v   : PCC�i�ڃ}�X�^�����eDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.07.20  �C�����e : �V�K�쐬
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
    /// PCC�i�ڃ}�X�^�����eDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�i�ڃ}�X�^�����eDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.07.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPccItemGrpDB
    {

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            ref object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            ref object pccItemStWorkList);

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="parsePccItemGrpWork">�����p�����[�^</param>
        /// <param name="parsePccItemStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            out object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            out object pccItemStWorkList,
            PccItemGrpWork parsePccItemGrpWork,
            PccItemStWork parsePccItemStWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            ref object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            ref object pccItemStWorkList,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            ref object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            ref object pccItemStWorkList);

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            ref object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            ref object pccItemStWorkList);

        /// <summary>
        /// PCC�i�ڐݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccItemGrpWorkList">PCC�i�ڃO���[�v�f�[�^���X�g</param>
        /// <param name="pccItemStWorkList">PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemGrpWork")]
            ref object pccItemGrpWorkList,
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PccItemStWork")]
            ref object pccItemStWorkList);

        /// <summary>
        /// PCCBL�R�[�h�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int WritePMBLGdsCd(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PMBLGdsCdWork")]
            ref object pMBLGdsCdWorkList);

        /// <summary>
        /// PCCBL�R�[�h�}�X�^�����e��������
        /// </summary>
        /// <param name="pMBLGdsCdWork">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int ReadPMBLGdsCd(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PMBLGdsCdWork")]
            ref object pMBLGdsCdWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCCBL�R�[�h�}�X�^�����e��������
        /// </summary>
        /// <param name="pMBLGdsCdWorkList">PCCBL�R�[�h�f�[�^���X�g</param>
        /// <param name="parsePMBLGdsCdWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchPMBLGdsCd(
            [CustomSerializationMethodParameterAttribute("PMPCC09046D", "Broadleaf.Application.Remoting.ParamData.PMBLGdsCdWork")]
            out object pMBLGdsCdWorkList,
            PMBLGdsCdWork parsePMBLGdsCdWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PMBL�R�[�h,PCC�i�ڃO���[�v,PCC�i�ڐݒ茟������
        /// </summary>
        /// <param name="retInfosList">PMBL�R�[�h,PCC�i�ڃO���[�v,PCC�i�ڐݒ�f�[�^���X�g</param>
        /// <param name="paraInfosList">PMBL�R�[�h,PCC�i�ڃO���[�v,PCC�i�ڐݒ茟���p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchFourInfos(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retInfosList,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object paraInfosList,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
    }
}
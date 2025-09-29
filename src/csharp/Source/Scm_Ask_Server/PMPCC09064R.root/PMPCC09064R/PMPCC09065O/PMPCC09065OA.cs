//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC�L�����y�[���ݒ�}�X�^�����e
// �v���O�����T�v   : PCC�L�����y�[���ݒ�}�X�^�����eDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2011.08.11  �C�����e : �V�K�쐬
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
    /// PCC�L�����y�[���ݒ�}�X�^�����eDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�L�����y�[���ݒ�}�X�^�����eDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2011.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPccCpMsgStDB
    {

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            ref object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            ref object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            ref object pccCpItmStWorkList);

		/// <summary>
		/// PCC�L�����y�[���ݒ��񌟍�����
		/// </summary>
		/// <param name="paraObj">�����p�����[�^</param>
		/// <param name="pccCpMsgStWorkObj">PCC�L�����y�[�����b�Z�[�W�ݒ���</param>
		/// <param name="pccCpItmStWorkObj">PCC�L�����y�[���i�ڐݒ���</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ������PCC�L�����y�[���ݒ����߂��܂��B</br>
        /// <br>Programmer : ���C��</br>
		/// <br>Date       : 2011.08.11</br>
		/// </remarks>
		[MustCustomSerialization]
		int SearchPccCampaign(
			object paraObj,
			[CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            out object pccCpMsgStWorkObj,
			[CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            out object pccCpItmStWorkObj,
		    out string errMsg);

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <param name="parsePccCpMsgStWork">�����p�����[�^</param>
        /// <param name="parsePccCpTgtStWork">�����p�����[�^</param>
        /// <param name="parsePccCpItmStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="dateSearchFlag">0:���t���������Ȃ�1�F���t��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            out object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            out object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            out object pccCpItmStWorkList, 
            PccCpMsgStWork parsePccCpMsgStWork,
            PccCpTgtStWork parsePccCpTgtStWork,
            PccCpItmStWork parsePccCpItmStWork,
            int readMode, 
            ConstantManagement.LogicalMode logicalMode,
            int dateSearchFlag);

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <param name="dateSearchFlag">0:���t���������Ȃ�1�F���t��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            ref object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            ref object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            ref object pccCpItmStWorkList, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode,
           int dateSearchFlag);

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            ref object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            ref object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            ref object pccCpItmStWorkList);

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            ref object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            ref object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            ref object pccCpItmStWorkList);

        /// <summary>
        /// PCC�L�����y�[�����b�Z�[�W�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCC�L�����y�[�����b�Z�[�W�}�X�^�ݒ�f�[�^���X�g</param>
        /// <param name="pccCpTgtStWorkList">PCC�L�����y�[���Ώېݒ�f�[�^���X�g</param>
        /// <param name="pccCpItmStWorkList">PCC�L�����y�[���i�ڐݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork")]
            ref object pccCpMsgStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpTgtStWork")]
            ref object pccCpTgtStWorkList, 
            [CustomSerializationMethodParameterAttribute("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpItmStWork")]
            ref object pccCpItmStWorkList);

    }
}
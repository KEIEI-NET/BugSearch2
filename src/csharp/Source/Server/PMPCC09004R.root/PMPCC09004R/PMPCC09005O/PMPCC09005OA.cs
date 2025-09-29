//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PCC�S�̐ݒ�}�X�^�擾�ݒ�}�X�^�����e
// �v���O�����T�v   : PCC�S�̐ݒ�}�X�^�擾�ݒ�}�X�^�����eDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �t�I��
// �� �� ��  2011.08.01  �C�����e : �V�K�쐬
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
    /// PCC�S�̐ݒ�}�X�^�擾�ݒ�}�X�^�����eDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC�S�̐ݒ�}�X�^�擾�ݒ�}�X�^�����eDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �t�I��</br>
    /// <br>Date       :2011.08.01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPccTtlStDB
    {

        /// <summary>
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccTtlStObj">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStObj,
            int readMode);


        /// <summary>
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e�����폜����
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStList);

        /// <summary>
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <param name="pccTtlStObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStList,
            PccTtlStWork pccTtlStObj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e�_���폜����
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStList);

        /// <summary>
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e��������
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStList);


        /// <summary>
        /// PCC�S�̐ݒ�擾�ݒ�}�X�^�����e�o�^�A�X�V����
        /// </summary>
        /// <param name="pccTtlStList">PCC�S�̐ݒ�擾�ݒ�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �t�I��</br>
        /// <br>Date       :2011.08.01</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMPCC09006D", "Broadleaf.Application.Remoting.ParamData.PccTtlStWork")]
            ref object pccTtlStList);



    }
}
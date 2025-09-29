//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����[�g�`���ݒ�}�X�^�����e
// �v���O�����T�v   : �����[�g�`���ݒ�}�X�^�����eDB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2011.08.03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����[�g�`���ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����[�g�`���ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011.08.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IRmSlpPrtStDB
    {

        /// <summary>
        /// �w�肳�ꂽ�����[�g�`���ݒ�}�X�^Guid�̃����[�g�`���ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="rmSlpPrtStWork">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����[�g�`���ݒ�}�X�^Guid�̃����[�g�`���ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        int Read(ref RmSlpPrtStWork rmSlpPrtStWork, int readMode);

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        int Delete(byte[] parabyte);

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �����[�g�`���ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="rmslpprtstWork">��������</param>
        /// <param name="pararmslpprtstWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09666D", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork")]
			out object rmslpprtstWork,
           RmSlpPrtStWork pararmslpprtstWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="rmslpprtstWork">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09666D", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork")]
			ref object rmslpprtstWork
            );

        /// <summary>
        /// �����[�g�`���ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="rmslpprtstWork">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����[�g�`���ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09666D", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork")]
			ref object rmslpprtstWork
            );

        /// <summary>
        /// �_���폜�����[�g�`���ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="rmslpprtstWork">RmSlpPrtStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�����[�g�`���ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.03</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09666D", "Broadleaf.Application.Remoting.ParamData.RmSlpPrtStWork")]
			ref object rmslpprtstWork
            );
        #endregion
    }
}

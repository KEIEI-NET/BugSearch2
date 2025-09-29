//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �L�����y�[���ڕW�ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2011/04/27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignTargetUDB
    {
        /// <summary>
        /// �P��̃L�����y�[���ڕW�ݒ�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="campaignTargetObj">CampaignTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̃L�[�l����v����L�����y�[���ڕW�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            ref object campaignTargetObj,
            int readMode);

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�����폜����L�����y�[���ڕW�ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̃L�[�l����v����L�����y�[���ڕW�ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            byte[] parabyte);

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="campaignTargetList">��������</param>
        /// <param name="campaignTargetObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���ڕW�ݒ�}�X�^�̃L�[�l����v����A�S�ẴL�����y�[���ڕW�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            ref object campaignTargetList,
            object campaignTargetObj,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="campaignTargetList">�ǉ��E�X�V����L�����y�[���ڕW�ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : campaignTargetList �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            ref object campaignTargetList);

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="campaignTargetList">�_���폜����L�����y�[���ڕW�ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            ref object campaignTargetList);

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="campaignTargetList">�_���폜����������L�����y�[���ڕW�ݒ�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork �Ɋi�[����Ă���L�����y�[���ڕW�ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011/04/27</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09657D", "Broadleaf.Application.Remoting.ParamData.CampaignTargetWork")]
            ref object campaignTargetList);
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[�������D��ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �L�����y�[�������D��ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�n��
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �L�����y�[�������D��ݒ�DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[�������D��ݒ�DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���N�n��</br>
    /// <br>Date       : 2011/04/25</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignPrcPrStDB
    {
        /// <summary>
        ///  �L�����y�[�������D��ݒ�ݒ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="outCampaignPrcPrSt">��������</param>
        /// <param name="paraCampaignPrcPrStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09617D", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork")]
			out object outCampaignPrcPrSt,
            object paraCampaignPrcPrStWork,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �w�肳�ꂽ�L�����y�[�������D��ݒ�Guid�̃L�����y�[�������D��ݒ��߂��܂�
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       :  �w�肳�ꂽ�L�����y�[�������D��ݒ�Guid�̃L�����y�[�������D��ݒ��߂��܂�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        int Read(ref byte[] parabyte, int readMode);
        
        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="campaignPrcPrStWork">�_���폜����L�����y�[�������D��ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMKHN09617D", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork")]
            ref object campaignPrcPrStWork);

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="campaignPrcPrStWorkbyte">�ǉ��E�X�V����L�����y�[�������D��ݒ�}�X�^���</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKHN09617D", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork")]
            ref object campaignPrcPrStWorkbyte, int writeMode);

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="campaignPrcPrStWork">�_���폜����������L�����y�[�������D��ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMKHN09617D", "Broadleaf.Application.Remoting.ParamData.CampaignPrcPrStWork")]
            ref object campaignPrcPrStWork);

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">CampaignPrcPrStWork�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[�������D��ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���N�n��</br>
        /// <br>Date       : 2011/04/25</br>
        int Delete(byte[] parabyte);

      
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I�[�g�o�b�N�X�ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �I�[�g�o�b�N�X�ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/08/02  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �I�[�g�o�b�N�X�ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.08.03</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISAndESettingDB
    {
        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SAndESettingWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�[�g�o�b�N�X�ݒ�}�X�^�̃L�[�l����v����I�[�g�o�b�N�X�ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork")]
            ref object parabyte);

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outSAndESettingList">��������</param>
        /// <param name="paraSAndESettingWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��ƃR�[�h�}�X�^�̃L�[�l����v����A�S�ẴI�[�g�o�b�N�X�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork")]
            out object outSAndESettingList, object paraSAndESettingWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="sAndESettingWorkbyte">�ǉ��E�X�V����I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">�X�V�敪</param>
        /// <br>Note       : SAndESettingWork �Ɋi�[����Ă���I�[�g�o�b�N�X�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork")]
            ref object sAndESettingWorkbyte, int writeMode);

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="sAndESettingWork">�_���폜����I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndESettingWork �Ɋi�[����Ă���I�[�g�o�b�N�X�ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork")]
            ref object sAndESettingWork);

        /// <summary>
        /// �I�[�g�o�b�N�X�ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="sAndESettingWork">�_���폜����������I�[�g�o�b�N�X�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndESettingWork �Ɋi�[����Ă���I�[�g�o�b�N�X�ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.08.03</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09016D", "Broadleaf.Application.Remoting.ParamData.SAndESettingWork")]
            ref object sAndESettingWork);
    }
}

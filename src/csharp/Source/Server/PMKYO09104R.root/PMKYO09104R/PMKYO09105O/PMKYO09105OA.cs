//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ��ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/03/27  �C�����e : �V�K�쐬
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
    /// ���_�Ǘ��ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�Ǘ��ݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISecMngSetDB
    {
        # region �J�X�^���V���A���C�Y
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outSecMngSetList">��������</param>
        /// <param name="paraSecMngSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̃L�[�l����v����A�S�Ă̋��_�Ǘ��ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork")]
                  out object outSecMngSetList, object paraSecMngSetWork,int readMode, ConstantManagement.LogicalMode logicalMode);
        # endregion

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWork�I�u�W�F�N�g</param>
        /// <param name="writeMode">�X�V�敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork")]
            ref object paraSecMngSetWork, int writeMode);

        /// <summary>
        ///  ���_�Ǘ��ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̃L�[�l����v���� ���_�Ǘ��ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork")]
            ref object paraSecMngSetWork);

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">SecMngSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork")]
            ref object paraSecMngSetWork);

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <remarks>
        /// <param name="paraSecMngSetWork">�_���폜���������鋒�_�Ǘ��ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.03.30</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMKYO09106D", "Broadleaf.Application.Remoting.ParamData.SecMngSetWork")]
            ref object paraSecMngSetWork);
    }
}

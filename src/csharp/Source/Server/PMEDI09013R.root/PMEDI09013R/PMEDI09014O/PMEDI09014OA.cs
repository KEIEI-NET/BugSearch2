//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : EDI�A�g�ݒ�}�X�^�����[�g�I�u�W�F�N�g�C���^�[�t�F�[�X
// �v���O�����T�v   : EDI�A�g�ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// �Ǘ��ԍ�  11370098-00  �쐬�S�� : ���O
// �� �� ��  2017/11/16   �C�����e : �V�K�쐬
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
    /// EDI�A�g�ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : EDI�A�g�ݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/11/16</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEDICooperatStDB
    {
        /// <summary>
        /// EDI�A�g�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">EDICooperatStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI�A�g�ݒ�}�X�^�̃L�[�l����v����EDI�A�g�ݒ�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(object parabyte);

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="paraObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="refObj">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�}�X�^�̃L�[�l����v����A�S�Ă�EDI�A�g�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMEDI09015D", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork")]
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, out object refObj);

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="eDICooperatStWork">�ǉ��E�X�V����EDI�A�g�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDICooperatStWork �Ɋi�[����Ă���EDI�A�g�ݒ�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMEDI09015D", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork")]
            ref object eDICooperatStWork);

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="eDICooperatStWork">�_���폜����EDI�A�g�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDICooperatStWork �Ɋi�[����Ă���EDI�A�g�ݒ�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMEDI09015D", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork")]
            ref object eDICooperatStWork);

        /// <summary>
        /// EDI�A�g�ݒ�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="eDICooperatStWork">�_���폜����������EDI�A�g�ݒ�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDICooperatStWork �Ɋi�[����Ă���EDI�A�g�ݒ�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMEDI09015D", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork")]
            ref object eDICooperatStWork);
    }
}

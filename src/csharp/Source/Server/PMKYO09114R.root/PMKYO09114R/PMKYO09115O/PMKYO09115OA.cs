//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ���Ɛݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
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
    /// ��ƃR�[�h�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��ƃR�[�h�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.3.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEnterpriseSetDB
    {
        /// <summary>
        /// ��ƃR�[�h�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">SecMngEpSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��ƃR�[�h�}�X�^�̃L�[�l����v�����ƃR�[�h�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork")]
            ref object parabyte);

        /// <summary>
        /// ��ƃR�[�h�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outenterpriseSetList">��������</param>
        /// <param name="paraenterpriseSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��ƃR�[�h�}�X�^�̃L�[�l����v����A�S�Ă̊�ƃR�[�h�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork")]
            out object outenterpriseSetList, object paraenterpriseSetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ��ƃR�[�h�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="enterpriseSetWorkbyte">�ǉ��E�X�V�����ƃR�[�h�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">�X�V�敪</param>
        /// <br>Note       : SecMngEpSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork")]
            ref object enterpriseSetWorkbyte, int writeMode);

        /// <summary>
        /// ��ƃR�[�h�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="enterpriseSetWork">�_���폜�����ƃR�[�h�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SecMngEpSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork")]
            ref object enterpriseSetWork);

        /// <summary>
        /// ��ƃR�[�h�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="enterpriseSetWork">�_���폜�����������ƃR�[�h�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SecMngEpSetWork �Ɋi�[����Ă����ƃR�[�h�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.27</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMKYO09116D", "Broadleaf.Application.Remoting.ParamData.SecMngEpSetWork")]
            ref object enterpriseSetWork);
    }
}

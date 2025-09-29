//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�����e�i���X
// �v���O�����T�v   : �\���敪�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/10/15  �C�����e : �V�K�쐬
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
    /// �\���敪�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �\���敪�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2009.10.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPriceSelectSetDB
    {
        /// <summary>
        /// �\���敪�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">PriceSelectSetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �\���敪�}�X�^�̃L�[�l����v����\���敪�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork")]
            ref object parabyte);

        /// <summary>
        /// �\���敪�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outPriceSelectSetList">��������</param>
        /// <param name="paraPriceSelectSetWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��ƃR�[�h�}�X�^�̃L�[�l����v����A�S�Ă̕\���敪�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork")]
            out object outPriceSelectSetList, object paraPriceSelectSetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �\���敪�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="PriceSelectSetWorkbyte">�ǉ��E�X�V����\���敪�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">�X�V�敪</param>
        /// <br>Note       : PriceSelectSetWork �Ɋi�[����Ă���\���敪�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork")]
            ref object PriceSelectSetWorkbyte, int writeMode);

        /// <summary>
        /// �\���敪�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="priceSelectSetWork">�_���폜����\���敪�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PriceSelectSetWork �Ɋi�[����Ă���\���敪�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork")]
            ref object priceSelectSetWork);

        /// <summary>
        /// �\���敪�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="priceSelectSetWork">�_���폜����������\���敪�}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PriceSelectSetWork �Ɋi�[����Ă���\���敪�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2009.10.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork")]
            ref object priceSelectSetWork);
    }
}

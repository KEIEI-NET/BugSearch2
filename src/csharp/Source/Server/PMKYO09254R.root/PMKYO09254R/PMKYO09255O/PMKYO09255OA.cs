//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ��ڑ���ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ڑ���ݒ�}�X�^�̓o�^�E�ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ڑ���ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ڑ���ݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.04.23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISecMngConnectStDB
    {
        /// <summary>
        /// �ڑ���ݒ�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="outSecMngConnectStWorkList">��������</param>
        /// <param name="paraSecMngConnectStWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ڑ���ݒ�}�X�^�̃L�[�l����v����A�S�Ă̔����_�ݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKYO09256D", "Broadleaf.Application.Remoting.ParamData.SecMngConnectStWork")]
                  out object outSecMngConnectStWorkList, object paraSecMngConnectStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �ڑ���ݒ�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <remarks>
        /// <param name="objSecMngConnectStWork">SecMngConnectStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ڑ���ݒ�}�X�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09256D", "Broadleaf.Application.Remoting.ParamData.SecMngConnectStWork")]
            ref object objSecMngConnectStWork);

        /// <summary>
        /// �T�[�o�[�p�ڑ���X�V����
        /// </summary>
        /// <remarks>
        /// <param name="objSecMngConnectStWork">SecMngConnectStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �T�[�o�[�p�ڑ�����X�V���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int UpdateRegistryKeyValue([CustomSerializationMethodParameterAttribute("PMKYO09256D", "Broadleaf.Application.Remoting.ParamData.SecMngConnectStWork")]
            ref object objSecMngConnectStWork);
    }
}

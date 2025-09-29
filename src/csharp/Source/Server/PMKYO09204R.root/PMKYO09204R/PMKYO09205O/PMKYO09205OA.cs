//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����M�Ώېݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ����M�Ώېݒ�̕ύX���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/04/22  �C�����e : �V�K�쐬
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
    /// ����M�Ώېݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����M�Ώېݒ�}�X�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.04.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISendSetDB
    {
        /// <summary>
        /// ����M�Ώېݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outSecMngSndRcvList">��������</param>
        /// <param name="paraSecMngSndRcvWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�Ώېݒ�}�X�^�̃L�[�l����v����A�S�Ă̑���M�Ώېݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKYO09206D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            out object outSecMngSndRcvList, object paraSecMngSndRcvWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ����M�Ώۏڍאݒ�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outSecMngSndRcvDtlList">��������</param>
        /// <param name="paraSecMngSndRcvDtlWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�Ώۏڍאݒ�}�X�^�̃L�[�l����v����A�S�Ă̑���M�Ώۏڍאݒ�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        [MustCustomSerialization]
        int SearchDtl([CustomSerializationMethodParameterAttribute("PMKYO09206D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvDtlWork")]
            out object outSecMngSndRcvDtlList, object paraSecMngSndRcvDtlWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ����M�Ώۃ}�X�^�����X�V���܂��B
        /// </summary>
        /// <param name="objsecMngSndRcvWorkList">�X�V���鑗��M�Ώۃ}�X�^���</param>
        /// <param name="objsecMngSndRcvDtlWorkList">�X�V���鑗��M�Ώۏڍ׃}�X�^���</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">�X�V�敪</param>
        /// <br>Note       : SecMngEpSetWork �Ɋi�[����Ă��鑗��M�Ώۃ}�X�^�����X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.04.22</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09206D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            ref object objsecMngSndRcvWorkList,
            [CustomSerializationMethodParameterAttribute("PMKYO09206D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvDtlWork")]
            ref object objsecMngSndRcvDtlWorkList, int writeMode);
    }
}

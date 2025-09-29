//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���}�X�^���
// �v���O�����T�v   : �L�����y�[���}�X�^��� DBRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �L�����y�[���}�X�^��� DBRemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �L�����y�[���}�X�^����@DBRemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br></br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignMasterWorkDB
	{
        /// <summary>
        /// ��ʂ̔��s�^�C�v���u�}�X�^���X�g�v�̏ꍇ�́A���o�����ɊY������A�f�[�^���擾����B
		/// </summary>
        /// <param name="stockMoveWork">��������</param>
        /// <param name="stockMovePrtWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɊY������A�f�[�^���擾����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int SearchForMasterType(
           [CustomSerializationMethodParameterAttribute("PMKHN08709D", "Broadleaf.Application.Remoting.ParamData.CampaignMasterWork")]
            ref object stockMoveWork,
           object stockMovePrtWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode
            );

        /// <summary>
        /// ��ʂ̔��s�^�C�v���u�}�X�^���X�g�v�ȊO�̏ꍇ�́A���o�����ɊY������A�f�[�^���擾����B
        /// </summary>
        /// <param name="stockMoveWork">��������</param>
        /// <param name="stockMovePrtWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���o�����ɊY������A�f�[�^���擾����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/04/26</br>
        [MustCustomSerialization]
        int Search(
           [CustomSerializationMethodParameterAttribute("PMKHN08709D", "Broadleaf.Application.Remoting.ParamData.CampaignMasterWork")]
            ref object stockMoveWork,
           object stockMovePrtWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode
            );
	}
}

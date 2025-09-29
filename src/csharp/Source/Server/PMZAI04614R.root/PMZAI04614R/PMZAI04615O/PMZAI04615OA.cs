//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌Ɉړ��d�q����
// �v���O�����T�v   : �݌Ɉړ��d�q���� DBRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangmj
// �� �� ��  2011/04/06  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �݌Ɉړ��d�q���� DBRemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌Ɉړ��d�q�����@DBRemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : yangmj</br>
    /// <br>Date       : 2011/04/06</br>
    /// <br></br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockMoveWorkDB
	{
        /// <summary>
        /// �݌Ɉړ��d�q�������ו\���̃��X�g�𒊏o���܂�
		/// </summary>
        /// <param name="stockMoveWork">��������(����f�[�^)</param>
        /// <param name="stockMovePrtWork">�����p�����[�^</param>
        /// <param name="recordCount">��������(����)</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/04/06</br>
        [MustCustomSerialization]
        int SearchRef(
           [CustomSerializationMethodParameterAttribute("PMZAI04616D", "Broadleaf.Application.Remoting.ParamData.StockMoveWork")]
            ref object stockMoveWork,
           object stockMovePrtWork,
            out Int64 recordCount,
			int readMode,
            ConstantManagement.LogicalMode logicalMode
            );
	}
}

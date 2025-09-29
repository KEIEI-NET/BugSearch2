//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�R���o�[�g
// �v���O�����T�v   : �݌ɊǗ��S�̐ݒ�̌��݌ɕ\���敪���A�o�׉\�����X�V����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/08/26  �C�����e : �A��No.1016 �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ƀ}�X�^�R���o�[�g�c�[���pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�R���o�[�g�c�[���pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2011/08/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockConvertDB
    {
        /// <summary>
        /// �݌Ƀ}�X�^�R���o�[�g�c�[���̍폜����
        /// </summary>
        /// <param name="stockConvertWorkObj">�݌Ƀ}�X�^�R���o�[�g�N���X���[�N</param>
        /// <param name="stockCount">�݌Ƀ}�X�^�@��������</param>
        /// <param name="stockAcPayHistCount">�݌Ɏ󕥗����f�[�^�@��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�R���o�[�g�������s���N���X�ł��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int ConvertShipmentPosCnt(
            object stockConvertWorkObj,
            out int stockCount,
            out int stockAcPayHistCount);
    }
}

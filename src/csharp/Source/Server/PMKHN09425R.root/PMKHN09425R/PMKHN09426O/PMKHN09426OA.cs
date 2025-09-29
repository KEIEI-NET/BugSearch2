//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�U�[���i�E�����ꊇ�ݒ�
// �v���O�����T�v   : ���[�U�[���i�E�����ꊇ�ݒ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/05/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DC�R���g���[��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : DC�R���g���[��DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUserPriceDB
    {
        /// <summary>
        /// ���i�ݒ�
        /// </summary>
        /// <param name="rateList">�|���}�X�^</param>
        /// <param name="goodsPriceUList">���i�}�X�^</param>
        /// <param name="rateDelList">�|���}�X�^�폜���X�g</param>
        /// <param name="goodsPriceUDelList">���i�}�X�^�폜���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        int Write(object rateList, object goodsPriceUList, object rateDelList, object goodsPriceUDelList, ref string msg);
    }
}

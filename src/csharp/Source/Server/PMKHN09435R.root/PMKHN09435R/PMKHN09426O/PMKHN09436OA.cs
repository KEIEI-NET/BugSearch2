//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����ꊇ�ݒ�
// �v���O�����T�v   : �����ꊇ�ݒ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/05/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DC�R���g���[��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : DC�R���g���[��DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISaleRateDB
    {
        /// <summary>
        /// �|���ݒ�
        /// </summary>
        /// <param name="delparaObj">�폜�f�[�^���X�g</param>
        /// <param name="updparaObj">�X�V�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        [MustCustomSerialization]
        int Save(object delparaObj, object updparaObj ,ref string message);
    }
}

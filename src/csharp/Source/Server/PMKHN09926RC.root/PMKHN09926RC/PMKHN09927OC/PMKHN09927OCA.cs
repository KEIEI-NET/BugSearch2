//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�e�L�X�g�ϊ�DB�C���^�[�t�F�[�X�N���X
// �v���O�����T�v   : ���i�e�L�X�g�ϊ�DB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-00  �쐬�S�� : FSI���� �f��
// �� �� ��  K2012/05/28  �C�����e : �V�K�쐬 �R�`���i�ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�e�L�X�g�ϊ�DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�e�L�X�g�ϊ�DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : K2012/05/28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsUMasDB
    {
�@      /// <summary>
        /// ���i�e�L�X�g���׏��̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outList">��������</param>
        /// <param name="paraWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�e�L�X�g�̃L�[�l����v����A�S�Ă̏��i�e�L�X�g���׏����擾���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : K2012/05/28</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKHN09928DC", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
                   out object outList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode);

    }
}
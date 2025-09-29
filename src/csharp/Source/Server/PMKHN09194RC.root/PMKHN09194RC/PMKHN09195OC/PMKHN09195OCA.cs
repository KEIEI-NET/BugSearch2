//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�i�e�L�X�g�ϊ��j
// �v���O�����T�v   : ���i�}�X�^�e�L�X�g�ϊ�  DBRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902160-00  �쐬�S�� : ���z
// �� �� ��  K2013/08/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���i�}�X�^�e�L�X�g�ϊ�  DBRemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���i�}�X�^�e�L�X�g�ϊ� DBRemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���z</br>
    /// <br>Date       : K2013/08/08</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsTextExpDB
	{
        /// <summary>
        /// ���i�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="goodsTextExpRetWork">��������</param>
        /// <param name="goodsTextExpWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���z</br>
        /// <br>Date       : K2013/08/08</br>
        [MustCustomSerialization]
		int Search(
             [CustomSerializationMethodParameterAttribute("PMKHN09196DC", "Broadleaf.Application.Remoting.ParamData.GoodsTextExpRetWork")]
			 out object goodsTextExpRetWork
            ,object goodsTextExpWork
            ,ConstantManagement.LogicalMode logicalMode
            );
	}
}

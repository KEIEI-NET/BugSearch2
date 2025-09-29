//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ǘ����}�X�^
// �v���O�����T�v   : ���i�Ǘ����}�X�^�̃G�N�X�|�[�g���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���R
// �� �� ��  2012/06/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// ���i�Ǘ����DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���i�Ǘ����DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : ���R</br>
	/// <br>Date       : 2012/06/05</br>
	/// <br></br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsMngExportDB
	{
		/// <summary>
        /// ���i�Ǘ����LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
        /// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : ���R</br>
		/// <br>Date       : 2012/06/05</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchGoodsMng(
            [CustomSerializationMethodParameterAttribute("MAKHN09526D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			out object retObj,
            object paraObj,
            ConstantManagement.LogicalMode logicalMode);
	}
}

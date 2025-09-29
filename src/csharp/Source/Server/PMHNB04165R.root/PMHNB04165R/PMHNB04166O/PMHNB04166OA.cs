//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �S���ҕʎ��яƉ�
// �v���O�����T�v   : �S���ҕʎ��яƉ�ꗗ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//


using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �S���ҕʎ��яƉ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �S���ҕʎ��яƉ�DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.01</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEmployeeResultsListDB
	{
        
        /// <summary>
        /// �S���ҕʎ��яƉ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="EmployeeResultsListResultWork">��������</param>
        /// <param name=" EmployeeResultsListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �S���ҕʎ��яƉ�LIST��S�Ė߂��܂����s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.01</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB04167D", "Broadleaf.Application.Remoting.ParamData.EmployeeResultsListResultWork")]
			out object EmployeeResultsListResultWork,
            object EmployeeResultsListCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}

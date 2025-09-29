//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �D�ǃf�[�^�폜����
// �v���O�����T�v   : �D�ǃf�[�^�폜����
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : ���X��
// �� �� ��  2011/07/15  �C�����e : �A��No.2 �V�K�쐬                      
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
//****************************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

using System.Data.SqlClient;    // ADD 2009/12/24

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �D�ǃf�[�^�X�VDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �D�ǃf�[�^�X�VDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer	: ���X��</br>
    /// <br>Date		: 2011/07/13</br>
    /// <br></br>
    /// <br>Update Note : 2011/07/21 caohh</br>
    /// <br>            : �D�ǃf�[�^�폜�`�F�b�N���X�g�Ή�</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IYuuRyouDataDelDB
    {
        /// <summary>
        /// �w�肳�ꂽ�����ɗD�ǃf�[�^�𕨗��폜�B
        /// </summary>
        /// <param name="deleteConditionWork">deleteConditionWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����ɗD�ǃf�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        int Delete([CustomSerializationMethodParameterAttribute("PMKHN01516D", "Broadleaf.Application.Remoting.ParamData.DeleteConditionWork")]
            ref object deleteConditionWork);

        // ---- ADD caohh 2011/07/21 ---->>>>
        /// <summary>
        /// �w�肳�ꂽ�����ɗD�ǃf�[�^��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="deleteResultWork">��������</param>
        /// <param name="deleteConditionObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����ɗD�ǃf�[�^��S�Ė߂��܂��i�_���폜�����j</br>
	    /// <br>Programmer : caohh</br>
	    /// <br>Date       : 2011.07.21</br>
        [MustCustomSerialization]
		    int Search(
                [CustomSerializationMethodParameterAttribute("PMKHN01516D", "Broadleaf.Application.Remoting.ParamData.DeleteResultWork")]
      			out object deleteResultWork,
                object deleteConditionObj,
      			int readMode,
                ConstantManagement.LogicalMode logicalMode);
       // ---- ADD caohh 2011/07/21 ----<<<< 
    }
}

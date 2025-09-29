//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DC�R���g���[��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : DC�R���g���[��DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Summary_AP)]
    public interface IMstTotalMachControlDB
    {
        /// <summary>
        /// �f�[�^���擾���܂��B
        /// </summary>
        /// <param name="masterDivList">�}�X�^�敪</param>
        /// <param name="pmEnterpriseCodes">PM��ƃR�[�h</param>
        /// <param name="BeginningDate">��������</param>
        /// <param name="EndingDate">��������</param>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchCustomSerializeArrayList(
            ArrayList masterDivList,
            string pmEnterpriseCodes,
            Int64 BeginningDate,
            Int64 EndingDate,
            ref CustomSerializeArrayList retCSAList,
            out string retMessage);

        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        [MustCustomSerialization]
        int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage);
    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���Е��i���������Ɖ�
// �v���O�����T�v   : ���Е��i���������Ɖ���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/11/19  �C�����e : Redmine#17394
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData; // ADD 2010/11/19

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Е��i���������Ɖ�DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Е��i���������Ɖ�DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �� ��</br>
    /// <br>Date       : 2010/11/11</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_ASK_AP_NS)]
    public interface IScmInqLogInquiryDB
    {
        /// <summary>
        /// SCM�⍇�����O�e�[�u���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="outScmInqLogList">��������</param>
        /// <param name="scmInqLogInquirySearchPara">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�⍇�����O�e�[�u���̃��X�g���擾���܂��B</br>
        /// <br>Programmer : ���</br>
        /// <br>Date       : 2010/11/11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN04207D", "Broadleaf.Application.Remoting.ParamData.ScmInqLogInquiryWork")]
            //out object outScmInqLogList, ScmInqLogInquirySearchPara scmInqLogInquirySearchPara, int readMode); // DEL 2010/11/19
            out object outScmInqLogList, ref object scmInqLogInquirySearchPara, int readMode); // ADD 2010/11/19
    }
}

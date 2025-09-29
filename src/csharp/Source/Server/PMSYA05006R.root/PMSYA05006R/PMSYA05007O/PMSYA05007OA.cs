//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Ԍ������X�V
// �v���O�����T�v   : �Ԍ������X�VDB Access RemoteObject�C���^�[�t�F�[�X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �Ԍ������X�V�pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ԍ������X�V�pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2010/04/21</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IInspectDateUpdDB
    {
        /// <summary>
        /// �Ԍ������X�V����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updateDate">�X�V�N��</param>
        /// <param name="searchNum">���o����</param>
        /// <param name="updNum">�X�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Ԍ������X�V�������s���N���X�ł��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        [MustCustomSerialization]
        int InspectDateUpdProc(string enterpriseCode, int updateDate, out int searchNum, out int updNum);
    }
}

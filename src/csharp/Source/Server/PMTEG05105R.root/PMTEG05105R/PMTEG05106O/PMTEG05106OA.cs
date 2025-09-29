//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���ώ�`��������
// �v���O�����T�v   : ���ώ�`��������DB Access RemoteObject�C���^�[�t�F�[�X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
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
    /// ���ώ�`���������pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ώ�`���������pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISettlementBillDelDB
    {
        /// <summary>
        /// ���ώ�`��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="processDate">������</param>
        /// <param name="prevTotalMonth">�O���������</param>
        /// <param name="billDiv">��`�敪0:����`;1:�x����`</param>
        /// <param name="pieceDelete">�폜����</param>
        /// <param name="totalpiece">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: ���ώ�`�����������s���B</br>
        /// <br>Programmer	: ���`</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        int SettlementBillDelProc(string enterpriseCode, int processDate, int prevTotalMonth, int billDiv, out int pieceDelete, out int totalpiece);
    }
}

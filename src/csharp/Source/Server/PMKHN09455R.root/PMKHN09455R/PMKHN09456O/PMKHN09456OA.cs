//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڕW�����ݒ�
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
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ڕW�����ݒ菈���pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ڕW�����ݒ菈���pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.02</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IObjAutoSetControlDB
    {
        /// <summary>
        /// �ڕW�����ݒ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="pastStartMonthDate">�O���K�p�J�n��</param>
        /// <param name="pastEndMonthDate">�O���K�p�I����</param>
        /// <param name="pastYearMonth">�O�������X�V�N��</param>
        /// <param name="nowStartMonthDate">����K�p�J�n��</param>
        /// <param name="nowEndMonthDate">����K�p�I����</param>
        /// <param name="nowYearMonth">���񌎎��X�V�N��</param>
        /// <param name="yearMonth">���ݏ����N��</param>
        /// <param name="objAutoSetWork">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ڕW�����ݒ肷��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.4.31</br>
        int ObjAutoSetProc(string enterpriseCode, string baseCode, List<DateTime> pastStartMonthDate, List<DateTime> pastEndMonthDate,
            List<DateTime> pastYearMonth, List<DateTime> nowStartMonthDate, List<DateTime> nowEndMonthDate, List<DateTime> nowYearMonth, DateTime yearMonth,
            ObjAutoSetWork objAutoSetWork);
    }
}

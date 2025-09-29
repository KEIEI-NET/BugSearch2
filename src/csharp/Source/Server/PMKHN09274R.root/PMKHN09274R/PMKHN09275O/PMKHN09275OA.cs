//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ꊇ���A���X�V
// �v���O�����T�v   : �ꊇ���A���X�VDB Access RemoteObject�C���^�[�t�F�[�X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/12/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ꊇ���A���X�V�pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ꊇ���A���X�V�pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAllRealUpdToolDB
    {
        /// <summary>
        /// �ꊇ���A���X�V����
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">���ハ�[�N</param>
        /// <param name="mTtlStockUpdParaWork">�d�����[�N</param>
        /// <param name="procDiv">�����敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ꊇ���A���X�V�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        [MustCustomSerialization]
        int AllRealUpdProc(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, MTtlStockUpdParaWork mTtlStockUpdParaWork, int procDiv);
    }
}

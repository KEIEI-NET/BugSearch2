//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d�񓚏��m��p �d���w�b�_�E���׏���`�N���X
// �v���O�����T�v   : �t�n�d�񓚏��m��p �d���w�b�_�E���׏����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �t�n�d�񓚏��m��p���d���w�b�_�E���׏��
    /// </summary>
    public class StockSlipGrp
    {
        public StockSlipWork stockSlipWork = null;
        public List<StockDetailWork> stockDetailWorkList = null;

        public StockSlipGrp()
        {
            Clear();
        }

        public void Clear()
        {
            stockSlipWork = new StockSlipWork();

            if (stockDetailWorkList == null)
            {
                stockDetailWorkList = new List<StockDetailWork>();
            }
            else
            {
                stockDetailWorkList.Clear();
            }
        }
    }

}

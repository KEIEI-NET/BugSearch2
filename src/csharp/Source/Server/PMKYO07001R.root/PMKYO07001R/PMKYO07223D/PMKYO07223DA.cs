//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �����񃏁[�N�N���X
//                  :   PMKYO07223D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   �Č���
// Date             :   2011.08.05
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MTtlStockSlipWork
    /// <summary>
    /// �����񃏁[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����񃏁[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   12/11</br>
    /// <br>Genarated Date   :   2011/08/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class APSalesInfoWork
    {
        /// <summary>��M��������f�[�^</summary>
        private APSalesSlipWork _salesSlipWork = null;

        /// <summary>��M�������㖾�׃f�[�^���X�g</summary>
        private List<APSalesDetailWork> _salesDetailWorkList = new List<APSalesDetailWork>();

        /// public propaty name  :  SalesSlipWork
        /// <summary>����f�[�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����f�[�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public APSalesSlipWork SalesSlipWork
        {
            get { return _salesSlipWork; }
            set { _salesSlipWork = value; }
        }

        /// public propaty name  :  SalesDetailWorkList
        /// <summary>���㖾�׃f�[�^���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㖾�׃f�[�^���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<APSalesDetailWork> SalesDetailWorkList
        {
            get { return _salesDetailWorkList; }
            set { _salesDetailWorkList = value; }
        }

    }
}

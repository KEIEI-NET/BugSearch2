//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   在庫調整ワーククラス
//                  :   PMKYO07243D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   孫東響
// Date             :   2011.08.10
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{

    /// <summary>
    /// 在庫調整ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫調整ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   12/11</br>
    /// <br>Genarated Date   :   2011/08/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class APStockAdjustInfoWork
    {
        /// <summary>受信した在庫調整データ</summary>
        private APStockAdjustWork _stockAdjustWork = null;

        /// <summary>受信した在庫調整明細データリスト</summary>
        private List<APStockAdjustDtlWork> _stockAdjustDtlWorkList = new List<APStockAdjustDtlWork>();

        /// public propaty name  :  StockAdjustWork
        /// <summary>在庫調整データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫調整データプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APStockAdjustWork StockAdjustWork
        {
            get { return _stockAdjustWork; }
            set { _stockAdjustWork = value; }
        }

        /// public propaty name  :  SalesDetailWorkList
        /// <summary>在庫調整明細データリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫調整明細データリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<APStockAdjustDtlWork> StockAdjustDtlWorkList
        {
            get { return _stockAdjustDtlWorkList; }
            set { _stockAdjustDtlWorkList = value; }
        }

    }
}



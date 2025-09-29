//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   売上情報ワーククラス
//                  :   PMKYO07223D.DLL
// Name Space       :   Broadleaf.Application.Remoting.ParamData
// Programmer       :   斉建華
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
    /// 売上情報ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上情報ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   12/11</br>
    /// <br>Genarated Date   :   2011/08/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class APSalesInfoWork
    {
        /// <summary>受信した売上データ</summary>
        private APSalesSlipWork _salesSlipWork = null;

        /// <summary>受信した売上明細データリスト</summary>
        private List<APSalesDetailWork> _salesDetailWorkList = new List<APSalesDetailWork>();

        /// public propaty name  :  SalesSlipWork
        /// <summary>売上データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上データプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APSalesSlipWork SalesSlipWork
        {
            get { return _salesSlipWork; }
            set { _salesSlipWork = value; }
        }

        /// public propaty name  :  SalesDetailWorkList
        /// <summary>売上明細データリストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上明細データリストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public List<APSalesDetailWork> SalesDetailWorkList
        {
            get { return _salesDetailWorkList; }
            set { _salesDetailWorkList = value; }
        }

    }
}

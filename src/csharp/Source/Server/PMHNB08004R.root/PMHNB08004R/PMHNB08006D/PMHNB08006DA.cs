using System;
using System.Collections;

//using Broadleaf.Library.Data; // DEL caohh 2011/08/17
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePSalesSlipWork
    /// <summary>
    ///                      自由帳票売上伝票データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票売上伝票データワークヘッダファイル</br>
    /// <br>Programmer       :   22018 鈴木正臣</br>
    /// <br>Date             :   2008/5/30</br>
    /// <br></br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePSalesSlipParaWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>伝票キーリスト</summary>
        private List<FrePSalesSlipParaKey> _frePSalesSlipParaKeyList;
        
        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// 伝票キーリスト
        /// </summary>
        public List<FrePSalesSlipParaKey> FrePSalesSlipParaKeyList
        {
            get { return _frePSalesSlipParaKeyList; }
            set { _frePSalesSlipParaKeyList = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrePSalesSlipParaWork()
        {
        }

        # region [伝票キー構造体]
        /// <summary>
        /// 自由帳票（売上伝票）キー構造体
        /// </summary>
        [Serializable]
        public struct FrePSalesSlipParaKey
        {
            private int _acptAnOdrStatus;
            private string _salesSlipNum;

            /// <summary>
            /// 受注ステータス
            /// </summary>
            public int AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }
            /// <summary>
            /// 売上伝票番号
            /// </summary>
            public string SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="acptAnOdrStatus"></param>
            /// <param name="salesSlipNum"></param>
            public FrePSalesSlipParaKey(int acptAnOdrStatus, string salesSlipNum)
            {
                _acptAnOdrStatus = acptAnOdrStatus;
                _salesSlipNum = salesSlipNum;
            }
        }
        # endregion
    }

}

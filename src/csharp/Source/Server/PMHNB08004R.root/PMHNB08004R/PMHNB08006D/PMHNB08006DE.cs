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
    ///                      自由帳票UOE伝票補足データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票UOE伝票補足データワークヘッダファイル</br>
    /// <br>Programmer       :   22018 鈴木正臣</br>
    /// <br>Date             :   2008/11/19</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePUOESlipParaWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>ＵＯＥ伝票単位データリスト</summary>
        private List<FrePUOESlipParaUnitWork> _uoeSlipParaUnitList;

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// ＵＯＥ伝票単位データリスト
        /// </summary>
        public List<FrePUOESlipParaUnitWork> UOESlipParaUnitList
        {
            get { return _uoeSlipParaUnitList; }
            set { _uoeSlipParaUnitList = value; }
        }
       
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrePUOESlipParaWork()
        {
        }

        # region [ＵＯＥ伝票単位データ]
        /// <summary>
        /// ＵＯＥ伝票単位データ
        /// </summary>
        [Serializable]
        [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
        public class FrePUOESlipParaUnitWork
        {
            /// <summary>伝票</summary>
            private FrePSalesSlipWork _slipWork;
            /// <summary>明細リスト</summary>
            private List<FrePSalesDetailWork> _detailWorkList;
            ///// <summary>補足情報</summary>
            //private object _extraData;

            /// <summary>
            /// 伝票リスト
            /// </summary>
            public FrePSalesSlipWork SlipWork
            {
                get { return _slipWork; }
                set { _slipWork = value; }
            }
            /// <summary>
            /// 明細リスト
            /// </summary>
            public List<FrePSalesDetailWork> DetailWorkList
            {
                get { return _detailWorkList; }
                set { _detailWorkList = value; }
            }
            ///// <summary>
            ///// 補足情報
            ///// </summary>
            //public object ExtraData
            //{
            //    get { return _extraData; }
            //    set { _extraData = value; }
            //}

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public FrePUOESlipParaUnitWork()
            {
            }
        }
        # endregion
    }
}

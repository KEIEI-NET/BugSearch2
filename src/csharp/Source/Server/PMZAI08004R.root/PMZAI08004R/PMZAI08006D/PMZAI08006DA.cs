using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Drawing;
using System.IO;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FrePStockMoveSlipWork
    /// <summary>
    ///                      自由帳票在庫移動伝票データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票在庫移動伝票データワークヘッダファイル</br>
    /// <br>Programmer       :   22018 鈴木正臣</br>
    /// <br>Date             :   2008/9/29</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FrePStockMoveSlipParaWork
    {
        /// <summary>企業コード</summary>
        private string _enterpriseCode;
        /// <summary>伝票キーリスト</summary>
        private List<FrePStockMoveSlipParaKey> _frePStockMoveSlipParaKeyList;

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
        public List<FrePStockMoveSlipParaKey> FrePStockMoveSlipParaKeyList
        {
            get { return _frePStockMoveSlipParaKeyList; }
            set { _frePStockMoveSlipParaKeyList = value; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrePStockMoveSlipParaWork()
        {
        }

        # region [伝票キー構造体]
        /// <summary>
        /// 自由帳票（在庫移動伝票）キー構造体
        /// </summary>
        [Serializable]
        public struct FrePStockMoveSlipParaKey
        {
            /// <summary>在庫移動形式</summary>
            private Int32 _stockMoveFormal;
            /// <summary>在庫移動伝票番号</summary>
            private Int32 _stockMoveSlipNo;
            /// <summary>
            /// 在庫移動形式
            /// </summary>
            /// <remarks>1:在庫移動、2：倉庫移動</remarks>
            public Int32 StockMoveFormal
            {
                get { return _stockMoveFormal; }
                set { _stockMoveFormal = value; }
            }
            /// <summary>
            /// 在庫移動伝票番号
            /// </summary>
            public Int32 StockMoveSlipNo
            {
                get { return _stockMoveSlipNo; }
                set { _stockMoveSlipNo = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="stockMoveFormal">在庫移動形式(1:在庫移動、2：倉庫移動)</param>
            /// <param name="stockMoveSlipNo">在庫移動伝票番号</param>
            public FrePStockMoveSlipParaKey( Int32 stockMoveFormal, Int32 stockMoveSlipNo )
            {
                _stockMoveFormal = stockMoveFormal;
                _stockMoveSlipNo = stockMoveSlipNo;
            }
        }
        # endregion
    }

}

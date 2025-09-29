using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// メール送信履歴表示検索条件 データクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   メール送信履歴表示検索条件 データクラス</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/05/25</br>
    /// <br>Genarated Date   :   2010/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class QrMailHistSearchCond
    {
        /// <summary>送信日付(開始)</summary>
        private DateTime _transmitDateSt;

        /// <summary>送信日付(終了)</summary>
        private DateTime _transmitDateEd;

        /// <summary>送信日付(開始)</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TransmitDateSt
        {
            get { return _transmitDateSt; }
            set { _transmitDateSt = value; }
        }

        /// <summary>送信日付(終了)</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TransmitDateEd
        {
            get { return _transmitDateEd; }
            set { _transmitDateEd = value; }
        }

        /// <summary>
        /// メール送信履歴表示検索条件データコンストラクタ
        /// </summary>
        /// <returns>DispatchInstsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   メール送信履歴表示検索条件 データクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public QrMailHistSearchCond()
        {
        }
    }
}

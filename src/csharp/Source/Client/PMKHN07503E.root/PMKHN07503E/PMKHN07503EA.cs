//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール送信履歴表示
// プログラム概要   : メール送信履歴表示を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢　貞義
// 作 成 日  2010/05/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// メール送信履歴表示 データクラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   メール送信履歴表示</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/05/25</br>
    /// <br>Genarated Date   :   2010/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MailHist
    {
        /// <summary>メールファイル名</summary>
        private string _fileName;

        /// <summary>QRコードファイル名</summary>
        private string _qRCode;

        /// <summary>送信日付</summary>
        private string _transmitDate;

        /// <summary>送信時間</summary>
        private string _transmitTime;

        /// <summary>受信者名称</summary>
        private string _employeeName;

        /// <summary>CC情報</summary>
        private string _cCInfo;

        /// <summary>件名</summary>
        private string _title;

        /// <summary>メールファイル名</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>QRコードファイル名</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string QRCode
        {
            get { return _qRCode; }
            set { _qRCode = value; }
        }

        /// <summary>送信日付</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransmitDate
        {
            get { return _transmitDate; }
            set { _transmitDate = value; }
        }

        /// <summary>送信時間</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransmitTime
        {
            get { return _transmitTime; }
            set { _transmitTime = value; }
        }

        /// <summary>受信者名称</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// <summary>CC情報</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CCInfo
        {
            get { return _cCInfo; }
            set { _cCInfo = value; }
        }

        /// <summary>件名</summary>
        /// <remarks>
        /// <br>Note             :   なし</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        /// <summary>
        /// メール送信履歴表示データコンストラクタ
        /// </summary>
        /// <returns>DispatchInstsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   メール送信履歴表示 データクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailHist()
        {
        }

    }
}

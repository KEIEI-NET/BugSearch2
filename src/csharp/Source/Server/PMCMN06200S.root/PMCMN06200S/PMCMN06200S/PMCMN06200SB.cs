using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.ServiceProcess
{
    /// public class name:   CheckCondWork
    /// <summary>
    ///                      チェック条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   チェック条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/31</br>
    /// <br>Genarated Date   :   2008/10/31  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   実行有無を追加</br>
    /// <br>Programmer       :   21024　佐々木 健</br>
    /// <br>Date             :   2010/05/19</br>
    /// </remarks>
    [Serializable]
    public class CheckCondWork
    {
        /// <summary>チェック開始時刻１</summary>
        /// <remarks>HHMM</remarks>
        private Int32 _chkStTime1;

        /// <summary>チェック終了時刻１</summary>
        /// <remarks>HHMM</remarks>
        private Int32 _chkEdTime1;

        /// <summary>チェック開始時刻２</summary>
        /// <remarks>HHMM</remarks>
        private Int32 _chkStTime2;

        /// <summary>チェック終了時刻２</summary>
        /// <remarks>HHMM</remarks>
        private Int32 _chkEdTime2;

        /// <summary>実行プログラム</summary>
        private string _pgId = "";

        /// <summary>実行パラメータ</summary>
        private string _pgParam = "";

        /// <summary>チェック間隔</summary>
        /// <remarks>時間</remarks>
        private Int32 _chkInterval;

        /// <summary>チェックまで残り</summary>
        /// <remarks>時間</remarks>
        private Int32 _remainedTm;

        /// <summary>チェック間隔チェック用</summary>        
        private Int32 _hourCnt;

        // 2010/05/19 Add >>>
        /// <summary>実行区分</summary>        
        private Int32 _processExecuteDiv;
        // 2010/05/19 Add <<<

        /// public propaty name  :  ChkStTime1
        /// <summary>チェック開始時刻１プロパティ</summary>
        /// <value>HHMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック開始時刻１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChkStTime1
        {
            get { return _chkStTime1; }
            set { _chkStTime1 = value; }
        }

        /// public propaty name  :  ChkEdTime1
        /// <summary>チェック終了時刻１プロパティ</summary>
        /// <value>HHMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック終了時刻１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChkEdTime1
        {
            get { return _chkEdTime1; }
            set { _chkEdTime1 = value; }
        }

        /// public propaty name  :  ChkStTime2
        /// <summary>チェック開始時刻２プロパティ</summary>
        /// <value>HHMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック開始時刻２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChkStTime2
        {
            get { return _chkStTime2; }
            set { _chkStTime2 = value; }
        }

        /// public propaty name  :  ChkEdTIme2
        /// <summary>チェック終了時刻２プロパティ</summary>
        /// <value>HHMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック終了時刻２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChkEdTime2
        {
            get { return _chkEdTime2; }
            set { _chkEdTime2 = value; }
        }

        /// public propaty name  :  PgId
        /// <summary>実行プログラムプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実行プログラムプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PgId
        {
            get { return _pgId; }
            set { _pgId = value; }
        }

        /// public propaty name  :  PgParam
        /// <summary>実行パラメータプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実行パラメータプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PgParam
        {
            get { return _pgParam; }
            set { _pgParam = value; }
        }

        /// public propaty name  :  ChkInterval
        /// <summary>チェック間隔プロパティ</summary>
        /// <value>時間</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェック間隔プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChkInterval
        {
            get { return _chkInterval; }
            set { _chkInterval = value; }
        }

        /// public propaty name  :  RemainedTm
        /// <summary>チェックまで残りプロパティ</summary>
        /// <value>時間</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェックまで残りプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RemainedTm
        {
            get { return _remainedTm; }
            set { _remainedTm = value; }
        }

        /// <summary>チェック間隔チェック用</summary>        
        public Int32 HourCnt
        {
            get { return _hourCnt; }
            set { _hourCnt = value; }
        }

        // 2010/05/19 Add >>>
        /// public propaty name  :  ProcessExecuteDiv
        /// <summary>実行区分</summary>
        /// <value>0:する、1:しない</value>
        public Int32 ProcessExecuteDiv
        {
            get { return _processExecuteDiv; }
            set { _processExecuteDiv = value; }
        }
        // 2010/05/19 Add <<<

        /// <summary>
        /// チェック条件ワークコンストラクタ
        /// </summary>
        /// <returns>CheckCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CheckCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CheckCondWork()
        {
        }

    }
}

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BLGroupPrintWork
	/// <summary>
	///                      ＢＬグループマスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   ＢＬグループマスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class BLGroupPrintWork 
    {
        # region ■ private field ■
        /// <summary>開始ＢＬグループコード</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>終了ＢＬグループコード</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>削除指定区分</summary>
        /// <remarks>0:有効,1:論理削除</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>開始削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeSt;

        /// <summary>終了削除日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeEd;

        # endregion  ■ private field ■

        # region ■ public propaty ■
        /// public propaty name  :  BLGroupCodeSt
        /// <summary>開始ＢＬグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始ＢＬグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>終了ＢＬグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了ＢＬグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>削除指定区分プロパティ</summary>
        /// <value>0:有効,1:論理削除</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DeleteDateTimeSt
        /// <summary>開始削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteDateTimeSt
        {
            get { return _deleteDateTimeSt; }
            set { _deleteDateTimeSt = value; }
        }

        /// public propaty name  :  DeleteDateTimeEd
        /// <summary>終了削除日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了削除日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteDateTimeEd
        {
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }
        # endregion ■ public propaty ■

        # region ■ Constructor ■
        /// <summary>
        /// ＢＬグループマスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>BLGroupPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeePrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGroupPrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}

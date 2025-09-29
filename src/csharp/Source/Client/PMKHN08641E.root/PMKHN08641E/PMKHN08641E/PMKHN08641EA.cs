using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   JoinPartsPrintWork
	/// <summary>
	///                      結合マスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   結合マスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class JoinPartsPrintWork 
    {
        # region ■ private field ■
        /// <summary>開始結合元メーカーコード</summary>
        private Int32 _joinSourceMakerCodeSt;

        /// <summary>終了結合元メーカーコード</summary>
        private Int32 _joinSourceMakerCodeEd;

        /// <summary>開始結合元品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinSourPartsNoWithHSt = "";

        /// <summary>終了結合元品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinSourPartsNoWithHEd = "";

        /// <summary>開始結合表示順位</summary>
        private Int32 _joinDispOrderSt;

        /// <summary>終了結合表示順位</summary>
        private Int32 _joinDispOrderEd;

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
        /// public propaty name  :  JoinSourceMakerCodeSt
        /// <summary>開始結合元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始結合元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCodeSt
        {
            get { return _joinSourceMakerCodeSt; }
            set { _joinSourceMakerCodeSt = value; }
        }

        /// public propaty name  :  JoinSourceMakerCodeEd
        /// <summary>終了結合元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了結合元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCodeEd
        {
            get { return _joinSourceMakerCodeEd; }
            set { _joinSourceMakerCodeEd = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithHSt
        /// <summary>開始結合元品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始結合元品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoWithHSt
        {
            get { return _joinSourPartsNoWithHSt; }
            set { _joinSourPartsNoWithHSt = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithHEd
        /// <summary>終了結合元品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了結合元品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoWithHEd
        {
            get { return _joinSourPartsNoWithHEd; }
            set { _joinSourPartsNoWithHEd = value; }
        }

        /// public propaty name  :  JoinDispOrderSt
        /// <summary>開始結合表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始結合表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDispOrderSt
        {
            get { return _joinDispOrderSt; }
            set { _joinDispOrderSt = value; }
        }

        /// public propaty name  :  JoinDispOrderEd
        /// <summary>終了結合表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了結合表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDispOrderEd
        {
            get { return _joinDispOrderEd; }
            set { _joinDispOrderEd = value; }
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
        /// 結合（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>JoinPartsPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeePrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public JoinPartsPrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}

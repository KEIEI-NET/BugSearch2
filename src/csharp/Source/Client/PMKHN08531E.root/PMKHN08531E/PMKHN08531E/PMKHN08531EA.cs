using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UserGdPrintWork
	/// <summary>
	///                      ユーザーガイドマスタ（印刷）条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   ユーザーガイドマスタ（印刷）条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
    public class UserGdPrintWork 
    {
        # region ■ private field ■
        /// <summary>ユーザーガイド区分</summary>
        private Int32 _userGuideDivCd;

        /// <summary>ユーザーガイド名称</summary>
        private string _userGuideDivName;

        /// <summary>開始ガイドコード</summary>
        private Int32 _guideCodeSt;

        /// <summary>終了ガイドコード</summary>
        private Int32 _guideCodeEd;

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
        /// public propaty name  :  UserGuideDivCd
        /// <summary>ユーザーガイド区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイド区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UserGuideDivCd
        {
            get { return _userGuideDivCd; }
            set { _userGuideDivCd = value; }
        }

        /// public propaty name  :  UserGuideDivName
        /// <summary>ユーザーガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ユーザーガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UserGuideDivName
        {
            get { return _userGuideDivName; }
            set { _userGuideDivName = value; }            
        }

        /// public propaty name  :  GuideCodeSt
        /// <summary>開始ガイドコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始ガイドコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GuideCodeSt
        {
            get { return _guideCodeSt; }
            set { _guideCodeSt = value; }
        }

        /// public propaty name  :  GuideCodeEd
        /// <summary>終了ガイドコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了ガイドコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GuideCodeEd
        {
            get { return _guideCodeEd; }
            set { _guideCodeEd = value; }
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
        /// ユーザーガイドマスタ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>UserGdPrintWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeePrintWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UserGdPrintWork()
        {
        }
        # endregion ■ Constructor ■
    }
}

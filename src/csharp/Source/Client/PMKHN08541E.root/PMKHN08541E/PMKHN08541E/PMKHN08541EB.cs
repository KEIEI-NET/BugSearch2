using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   NoteGuidSet
    /// <summary>
    ///                      備考ガイドマスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   備考ガイドマスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class NoteGuidSet 
    {
        /// <summary>備考ガイド区分</summary>
        private Int32 _noteGuideDivCode;

        /// <summary>備考ガイド区分名称</summary>
        private string _noteGuideDivName = "";

        /// <summary>備考ガイドコード</summary>
        private Int32 _noteGuideCode;

        /// <summary>備考ガイド名称</summary>
        private string _noteGuideName = "";


        /// public propaty name  :  NoteGuideDivCode
        /// <summary>備考ガイド区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考ガイド区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NoteGuideDivCode
        {
            get { return _noteGuideDivCode; }
            set { _noteGuideDivCode = value; }
        }

        /// public propaty name  :  NoteGuideDivName
        /// <summary>備考ガイド区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考ガイド区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NoteGuideDivName
        {
            get { return _noteGuideDivName; }
            set { _noteGuideDivName = value; }
        }

        /// public propaty name  :  NoteGuideCode
        /// <summary>備考ガイドコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考ガイドコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NoteGuideCode
        {
            get { return _noteGuideCode; }
            set { _noteGuideCode = value; }
        }

        /// public propaty name  :  NoteGuideName
        /// <summary>備考ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NoteGuideName
        {
            get { return _noteGuideName; }
            set { _noteGuideName = value; }
        }

        /// <summary>
        /// 備考ガイド（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public NoteGuidSet Clone()
        {
            return new NoteGuidSet(this._noteGuideDivCode, this._noteGuideDivName, this._noteGuideCode, this._noteGuideName);
        }

        /// <summary>
		/// 備考ガイド（印刷）データクラスワークコンストラクタ
		/// </summary>
		/// <returns>EmployeeSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public NoteGuidSet()
		{
		}

        /// <summary>
        /// 備考ガイド（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="NoteGuideDivCode"></param>
        /// <param name="NoteGuideDivName"></param>
        /// <param name="NoteGuideCode"></param>
        /// <param name="NoteGuideName"></param>
        public NoteGuidSet(Int32 NoteGuideDivCode, string NoteGuideDivName, Int32 NoteGuideCode, string NoteGuideName)
        {
            this._noteGuideDivCode = NoteGuideDivCode;
            this._noteGuideDivName = NoteGuideDivName;
            this._noteGuideCode = NoteGuideCode;
            this._noteGuideName = NoteGuideName;
        }
    }
}

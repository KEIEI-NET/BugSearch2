using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UserGdSet
    /// <summary>
    ///                      ユーザーガイドマスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ユーザーガイドマスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class UserGdSet 
    {
        /// <summary>ガイドコード</summary>
		private Int32 _guideCode;

		/// <summary>ガイド名称</summary>
		private string _guideName = "";


		/// public propaty name  :  GuideCode
		/// <summary>ガイドコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ガイドコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GuideCode
		{
			get{return _guideCode;}
			set{_guideCode = value;}
		}

		/// public propaty name  :  GuideName
		/// <summary>ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GuideName
		{
			get{return _guideName;}
			set{_guideName = value;}
		}

        /// <summary>
        /// ユーザーガイド（印刷）データクラス複製処理
        /// </summary>
        /// <returns>UserGdSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUserGdSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UserGdSet Clone()
        {
            return new UserGdSet(this._guideCode, this.GuideName);
        }

        /// <summary>
		/// ユーザーガイド（印刷）データクラスワークコンストラクタ
		/// </summary>
		/// <returns>UserGdSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public UserGdSet()
		{
		}
        
        /// <summary>
        /// ユーザーガイド（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="GuideCode"></param>
        /// <param name="GuideName"></param>
        public UserGdSet(Int32 GuideCode, string GuideName)
        {

            this._guideCode = GuideCode;
            this.GuideName = GuideName;
        }
    }
}

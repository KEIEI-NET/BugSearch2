using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsGroupSet
    /// <summary>
    ///                      商品中分類マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品中分類マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class GoodsGroupSet 
    {
        /// <summary>商品中分類コード</summary>
		private Int32 _goodsMGroup;

		/// <summary>商品中分類名称</summary>
		private string _goodsMGroupName = "";


		/// public propaty name  :  GoodsMGroup
		/// <summary>商品中分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMGroup
		{
			get{return _goodsMGroup;}
			set{_goodsMGroup = value;}
		}

		/// public propaty name  :  GoodsMGroupName
		/// <summary>商品中分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsMGroupName
		{
			get{return _goodsMGroupName;}
			set{_goodsMGroupName = value;}
		}

        /// <summary>
        /// 商品中分類（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsGroupSet Clone()
        {
            return new GoodsGroupSet(this._goodsMGroup, this._goodsMGroupName);
        }

        /// <summary>
		/// 商品中分類（印刷）データクラスワークコンストラクタ
		/// </summary>
		/// <returns>EmployeeSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public GoodsGroupSet()
		{
		}

        /// <summary>
        /// 商品中分類（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="GoodsMGroup"></param>
        /// <param name="GoodsMGroupName"></param>
        public GoodsGroupSet(Int32 GoodsMGroup, string GoodsMGroupName)
        {

            this._goodsMGroup = GoodsMGroup;
            this._goodsMGroupName = GoodsMGroupName;
        }
    }
}

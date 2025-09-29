using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   JoinPartsSet
    /// <summary>
    ///                      結合マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   結合マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class JoinPartsSet 
    {
        /// <summary>結合元メーカーコード</summary>
		private Int32 _joinSourceMakerCode;

		/// <summary>結合元メーカー名</summary>
		private string _joinSourceMakerName = "";

		/// <summary>結合元品番(－付き品番)</summary>
		private string _joinSourPartsNoWithH = "";

		/// <summary>商品名称カナ</summary>
		private string _goodsNameKana = "";

		/// <summary>結合表示順位</summary>
		/// <remarks>ユーザー登録分の表示順位（提供より必ず上になる）</remarks>
		private Int32 _joinDispOrder;

		/// <summary>結合先品番(－付き品番)</summary>
		private string _joinDestPartsNo = "";

		/// <summary>結合先メーカーコード</summary>
		private Int32 _joinDestMakerCd;

		/// <summary>結合先メーカー名</summary>
		private string _joinDestMakerName = "";

		/// <summary>結合QTY</summary>
		private Double _joinQty;


		/// public propaty name  :  JoinSourceMakerCode
		/// <summary>結合元メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合元メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinSourceMakerCode
		{
			get{return _joinSourceMakerCode;}
			set{_joinSourceMakerCode = value;}
		}

		/// public propaty name  :  JoinSourceMakerName
		/// <summary>結合元メーカー名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合元メーカー名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JoinSourceMakerName
		{
			get{return _joinSourceMakerName;}
			set{_joinSourceMakerName = value;}
		}

		/// public propaty name  :  JoinSourPartsNoWithH
		/// <summary>結合元品番(－付き品番)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合元品番(－付き品番)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JoinSourPartsNoWithH
		{
			get{return _joinSourPartsNoWithH;}
			set{_joinSourPartsNoWithH = value;}
		}

		/// public propaty name  :  GoodsNameKana
		/// <summary>商品名称カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNameKana
		{
			get{return _goodsNameKana;}
			set{_goodsNameKana = value;}
		}

		/// public propaty name  :  JoinDispOrder
		/// <summary>結合表示順位プロパティ</summary>
		/// <value>ユーザー登録分の表示順位（提供より必ず上になる）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinDispOrder
		{
			get{return _joinDispOrder;}
			set{_joinDispOrder = value;}
		}

		/// public propaty name  :  JoinDestPartsNo
		/// <summary>結合先品番(－付き品番)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合先品番(－付き品番)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JoinDestPartsNo
		{
			get{return _joinDestPartsNo;}
			set{_joinDestPartsNo = value;}
		}

		/// public propaty name  :  JoinDestMakerCd
		/// <summary>結合先メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合先メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinDestMakerCd
		{
			get{return _joinDestMakerCd;}
			set{_joinDestMakerCd = value;}
		}

		/// public propaty name  :  JoinDestMakerName
		/// <summary>結合先メーカー名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合先メーカー名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JoinDestMakerName
		{
			get{return _joinDestMakerName;}
			set{_joinDestMakerName = value;}
		}

		/// public propaty name  :  JoinQty
		/// <summary>結合QTYプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合QTYプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double JoinQty
		{
			get{return _joinQty;}
			set{_joinQty = value;}
		}

        /// <summary>
        /// 結合（印刷）データクラス複製処理
        /// </summary>
        /// <returns>JoinPartsSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public JoinPartsSet Clone()
        {
            return new JoinPartsSet(this._joinSourceMakerCode, this._joinSourceMakerName, this._joinSourPartsNoWithH, this._goodsNameKana, this._joinDispOrder, this._joinDestPartsNo, this._joinDestMakerCd, this._joinDestMakerName, this._joinQty);
        }

        /// <summary>
		/// 結合（印刷）データクラスワークコンストラクタ
		/// </summary>
		/// <returns>JoinPartsSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public JoinPartsSet()
		{
		}

        /// <summary>
        /// 結合（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="JoinSourceMakerCode"></param>
        /// <param name="JoinSourceMakerName"></param>
        /// <param name="JoinSourPartsNoWithH"></param>
        /// <param name="GoodsNameKana"></param>
        /// <param name="JoinDispOrder"></param>
        /// <param name="JoinDestPartsNo"></param>
        /// <param name="JoinDestMakerCd"></param>
        /// <param name="JoinDestMakerName"></param>
        /// <param name="JoinQty"></param>
        public JoinPartsSet(Int32 JoinSourceMakerCode, string JoinSourceMakerName, string JoinSourPartsNoWithH, string GoodsNameKana, Int32 JoinDispOrder, string JoinDestPartsNo, Int32 JoinDestMakerCd, string JoinDestMakerName, Double JoinQty)
        {
            this._joinSourceMakerCode = JoinSourceMakerCode;
            this._joinSourceMakerName = JoinSourceMakerName;
            this._joinSourPartsNoWithH = JoinSourPartsNoWithH;
            this._goodsNameKana = GoodsNameKana;
            this._joinDispOrder = JoinDispOrder;
            this._joinDestPartsNo = JoinDestPartsNo;
            this._joinDestMakerCd = JoinDestMakerCd;
            this._joinDestMakerName = JoinDestMakerName;
            this._joinQty = JoinQty;
        }
    }
}

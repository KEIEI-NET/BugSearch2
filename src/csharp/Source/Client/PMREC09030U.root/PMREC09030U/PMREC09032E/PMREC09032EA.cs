using System;
using System.Collections;
using System.Xml.Serialization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CustomerSearchPara
	/// <summary>
	///                      得意先検索条件パラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   得意先検索条件パラメータクラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/02/14  (CSharp File Generated Date)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 夏野 駿希</br>
    /// <br>             MANTIS:14720 得意先名検索追加</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2010/08/06 朱 猛</br>
    /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/08/19 黄海霞</br>
    /// <br>             PCC自社用得意先ガイド追加</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2011/07/22 徐錦山</br>
    /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// </remarks>
	public class RecBgnGrpPara
	{
		/// <summary>企業コード</summary>
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private Int64 _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private Int64 _updateDateTime;

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>問合せ元企業コード</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>問合せ元拠点コード</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>お買得商品グループコード</summary>
		/// <remarks>0:グループ無し</remarks>
		private Int16 _brgnGoodsGrpCode;

		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>お買得商品グループタイトル</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _brgnGoodsGrpTitle = "";

		/// <summary>お買得商品グループコメントタグ</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _brgnGoodsGrpTag = "";

		/// <summary>お買得商品グループコメント</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _brgnGoodsGrpComment = "";

		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int64 CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int64 UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  InqOriginalEpCd
		/// <summary>問合せ元企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get{return _inqOriginalEpCd;}
			set{_inqOriginalEpCd = value;}
		}

		/// public propaty name  :  InqOriginalSecCd
		/// <summary>問合せ元拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalSecCd
		{
			get{return _inqOriginalSecCd;}
			set{_inqOriginalSecCd = value;}
		}

		/// public propaty name  :  BrgnGoodsGrpCode
		/// <summary>お買得商品グループコードプロパティ</summary>
		/// <value>0:グループ無し</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   お買得商品グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 BrgnGoodsGrpCode
		{
			get{return _brgnGoodsGrpCode;}
			set{_brgnGoodsGrpCode = value;}
		}

		/// public propaty name  :  DisplayOrder
		/// <summary>表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

		/// public propaty name  :  BrgnGoodsGrpTitle
		/// <summary>お買得商品グループタイトルプロパティ</summary>
		/// <value>(半角全角混在)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   お買得商品グループタイトルプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BrgnGoodsGrpTitle
		{
			get{return _brgnGoodsGrpTitle;}
			set{_brgnGoodsGrpTitle = value;}
		}

		/// public propaty name  :  BrgnGoodsGrpTag
		/// <summary>お買得商品グループコメントタグプロパティ</summary>
		/// <value>(半角全角混在)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   お買得商品グループコメントタグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BrgnGoodsGrpTag
		{
			get{return _brgnGoodsGrpTag;}
			set{_brgnGoodsGrpTag = value;}
		}

		/// public propaty name  :  BrgnGoodsGrpComment
		/// <summary>お買得商品グループコメントプロパティ</summary>
		/// <value>(半角全角混在)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   お買得商品グループコメントプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BrgnGoodsGrpComment
		{
			get{return _brgnGoodsGrpComment;}
			set{_brgnGoodsGrpComment = value;}
		}


		/// <summary>
        /// お買得商品グループ条件パラメータクラスコンストラクタ
		/// </summary>
        /// <returns>RecBgnGrpParaクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpParaクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public RecBgnGrpPara()
		{
		}

		/// <summary>
        /// お買得商品グループ条件パラメータクラスコンストラクタ
		/// </summary>
        /// <param name="CreateDateTime">作成日時</param>
        /// <param name="UpdateDateTime">更新日時</param>
        /// <param name="LogicalDeleteCode">論理削除区分</param>
        /// <param name="InqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="InqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="BrgnGoodsGrpCode">お買得商品グループコード</param>
        /// <param name="DisplayOrder">表示順位</param>
        /// <param name="BrgnGoodsGrpTitle">お買得商品グループタイトル</param>
        /// <param name="BrgnGoodsGrpTag">お買得商品グループコメントタグ</param>
        /// <param name="BrgnGoodsGrpComment">お買得商品グループコメント</param>
        /// <returns>RecBgnGrpParaクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpParaクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        public RecBgnGrpPara(Int64 CreateDateTime, Int64 UpdateDateTime, Int32 LogicalDeleteCode, string InqOriginalEpCd, string InqOriginalSecCd, Int16 BrgnGoodsGrpCode, Int32 DisplayOrder, string BrgnGoodsGrpTitle, string BrgnGoodsGrpTag, string BrgnGoodsGrpComment)
        {
            this._createDateTime = CreateDateTime;
            this._updateDateTime = UpdateDateTime;
            this._logicalDeleteCode = LogicalDeleteCode;
            this._inqOriginalEpCd = InqOriginalEpCd;
            this._inqOriginalSecCd = InqOriginalSecCd;
            this._brgnGoodsGrpCode = BrgnGoodsGrpCode;
            this._displayOrder = DisplayOrder;
            this._brgnGoodsGrpTitle = BrgnGoodsGrpTitle;
            this._brgnGoodsGrpTag = BrgnGoodsGrpTag;
            this._brgnGoodsGrpComment = BrgnGoodsGrpComment;
           
        }

		/// <summary>
        /// お買得商品グループ条件パラメータクラス複製処理
		/// </summary>
        /// <returns>RecBgnGrpParaクラスのインスタンス</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいRecBgnGrpParaクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public RecBgnGrpPara Clone()
		{
            return new RecBgnGrpPara(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._brgnGoodsGrpCode, this._displayOrder, this._brgnGoodsGrpTitle, this._brgnGoodsGrpTag, this._brgnGoodsGrpComment);
        }

		/// <summary>
        /// お買得商品グループ条件パラメータクラス比較処理
		/// </summary>
        /// <param name="target">比較対象のRecBgnGrpParaクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpParaクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(RecBgnGrpPara target)
		{
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd == target.InqOriginalEpCd)
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.BrgnGoodsGrpCode == target.BrgnGoodsGrpCode)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.BrgnGoodsGrpTitle == target.BrgnGoodsGrpTitle)
                 && (this.BrgnGoodsGrpTag == target.BrgnGoodsGrpTag)
                 && (this.BrgnGoodsGrpComment == target.BrgnGoodsGrpComment)
                 );
		}

		/// <summary>
        /// お買得商品グループ条件パラメータクラス比較処理
		/// </summary>
        /// <param name="recBgnGrpPara1">比較するRecBgnGrpParaクラスのインスタンス</param>
        /// <param name="recBgnGrpPara2">比較するRecBgnGrpParaクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpParaクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public static bool Equals(RecBgnGrpPara recBgnGrpPara1, RecBgnGrpPara recBgnGrpPara2)
		{
            return ((recBgnGrpPara1.CreateDateTime == recBgnGrpPara2.CreateDateTime)
                 && (recBgnGrpPara1.UpdateDateTime == recBgnGrpPara2.UpdateDateTime)
                 && (recBgnGrpPara1.LogicalDeleteCode == recBgnGrpPara2.LogicalDeleteCode)
                 && (recBgnGrpPara1.InqOriginalEpCd == recBgnGrpPara2.InqOriginalEpCd)
                 && (recBgnGrpPara1.InqOriginalSecCd == recBgnGrpPara2.InqOriginalSecCd)
                 && (recBgnGrpPara1.BrgnGoodsGrpCode == recBgnGrpPara2.BrgnGoodsGrpCode)
                 && (recBgnGrpPara1.DisplayOrder == recBgnGrpPara2.DisplayOrder)
                 && (recBgnGrpPara1.BrgnGoodsGrpTitle == recBgnGrpPara2.BrgnGoodsGrpTitle)
                 && (recBgnGrpPara1.BrgnGoodsGrpTag == recBgnGrpPara2.BrgnGoodsGrpTag)
                 && (recBgnGrpPara1.BrgnGoodsGrpComment == recBgnGrpPara2.BrgnGoodsGrpComment)
                 );
		}
		/// <summary>
        /// お買得商品グループ検索条件パラメータクラス比較処理
		/// </summary>
        /// <param name="target">比較対象のRecBgnGrpRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpRetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		public ArrayList Compare(RecBgnGrpPara target)
		{
			ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd != target.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.BrgnGoodsGrpCode != target.BrgnGoodsGrpCode) resList.Add("BrgnGoodsGrpCode");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.BrgnGoodsGrpTitle != target.BrgnGoodsGrpTitle) resList.Add("BrgnGoodsGrpTitle");
            if (this.BrgnGoodsGrpTag != target.BrgnGoodsGrpTag) resList.Add("BrgnGoodsGrpTag");
            if (this.BrgnGoodsGrpComment != target.BrgnGoodsGrpComment) resList.Add("BrgnGoodsGrpComment");

			return resList;
		}

		/// <summary>
        /// お買得商品グループ条件パラメータクラス比較処理
		/// </summary>
        /// <param name="recBgnGrpPara1">比較するRecBgnGrpRetクラスのインスタンス</param>
        /// <param name="recBgnGrpPara2">比較するRecBgnGrpRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpRetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
        public static ArrayList Compare(RecBgnGrpPara recBgnGrpPara1, RecBgnGrpPara recBgnGrpPara2)
		{
			ArrayList resList = new ArrayList();
            if (recBgnGrpPara1.CreateDateTime != recBgnGrpPara2.CreateDateTime) resList.Add("CreateDateTime");
            if (recBgnGrpPara1.UpdateDateTime != recBgnGrpPara2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (recBgnGrpPara1.LogicalDeleteCode != recBgnGrpPara2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (recBgnGrpPara1.InqOriginalEpCd != recBgnGrpPara2.InqOriginalEpCd) resList.Add("InqOriginalEpCd");
            if (recBgnGrpPara1.InqOriginalSecCd != recBgnGrpPara2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (recBgnGrpPara1.BrgnGoodsGrpCode != recBgnGrpPara2.BrgnGoodsGrpCode) resList.Add("BrgnGoodsGrpCode");
            if (recBgnGrpPara1.DisplayOrder != recBgnGrpPara2.DisplayOrder) resList.Add("DisplayOrder");
            if (recBgnGrpPara1.BrgnGoodsGrpTitle != recBgnGrpPara2.BrgnGoodsGrpTitle) resList.Add("BrgnGoodsGrpTitle");
            if (recBgnGrpPara1.BrgnGoodsGrpTag != recBgnGrpPara2.BrgnGoodsGrpTag) resList.Add("BrgnGoodsGrpTag");
            if (recBgnGrpPara1.BrgnGoodsGrpComment != recBgnGrpPara2.BrgnGoodsGrpComment) resList.Add("BrgnGoodsGrpComment");
            
            return resList;
		}
	}
}

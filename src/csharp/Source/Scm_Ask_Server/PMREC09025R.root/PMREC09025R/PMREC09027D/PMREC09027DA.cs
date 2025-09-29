//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買い得商品設定マスタ抽出結果ワーク
// プログラム概要   : お買い得商品設定マスタ抽出結果ワークデータパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2015/01/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   RecBgnGdsWork
	/// <summary>
	///                      お買得商品設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   お買得商品設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2015/1/16</br>
	/// <br>Genarated Date   :   2015/01/30  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class RecBgnGdsWork 
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>問合せ元企業コード</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>問合せ元拠点コード</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>問合せ先企業コード</summary>
		private string _inqOtherEpCd = "";

		/// <summary>問合せ先拠点コード</summary>
		private string _inqOtherSecCd = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>管理拠点コード</summary>
		private string _mngSectionCode = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>商品メーカー名称</summary>
		private string _goodsMakerNm = "";

		/// <summary>商品名称</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _goodsName = "";

		/// <summary>BLグループコード</summary>
		/// <remarks>(PMで利用) 旧グループコード</remarks>
		private Int32 _bLGroupCode;

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>商品コメント</summary>
		/// <remarks>(半角全角混在)</remarks>
		private string _goodsComment = "";

		/// <summary>メーカー希望小売価格</summary>
		private Int64 _mkrSuggestRtPric;

		/// <summary>定価</summary>
		/// <remarks>0:オープン価格</remarks>
		private Int64 _listPrice;

		/// <summary>単価</summary>
		private Int64 _unitPrice;

		/// <summary>適用開始日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _applyStaDate;

		/// <summary>適用終了日</summary>
		/// <remarks>YYYYMMDD</remarks>
        private Int32 _applyEndDate;

		/// <summary>適合車種区分</summary>
		/// <remarks>0:適合車種なし,1:適合車種あり</remarks>
		private Int16 _modelFitDiv;

		/// <summary>商品画像</summary>
        private Byte[] _goodsImage = new Byte[0];

        /// <summary>お買得商品グループコード</summary>
        private Int16 _brgnGoodsGrpCode;

        /// <summary>表示区分</summary>
        /// <remarks>0:表示,1:非表示</remarks>
        private Int32 _displayDivCode;

		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
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
		public DateTime UpdateDateTime
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

		/// public propaty name  :  InqOtherEpCd
		/// <summary>問合せ先企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get{return _inqOtherEpCd;}
			set{_inqOtherEpCd = value;}
		}

		/// public propaty name  :  InqOtherSecCd
		/// <summary>問合せ先拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ先拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOtherSecCd
		{
			get{return _inqOtherSecCd;}
			set{_inqOtherSecCd = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  MngSectionCode
		/// <summary>管理拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   管理拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MngSectionCode
		{
			get{return _mngSectionCode;}
			set{_mngSectionCode = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  GoodsMakerNm
		/// <summary>商品メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsMakerNm
		{
			get{return _goodsMakerNm;}
			set{_goodsMakerNm = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>商品名称プロパティ</summary>
		/// <value>(半角全角混在)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  BLGroupCode
		/// <summary>BLグループコードプロパティ</summary>
		/// <value>(PMで利用) 旧グループコード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BLグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGroupCode
		{
			get{return _bLGroupCode;}
			set{_bLGroupCode = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  GoodsComment
		/// <summary>商品コメントプロパティ</summary>
		/// <value>(半角全角混在)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品コメントプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsComment
		{
			get{return _goodsComment;}
			set{_goodsComment = value;}
		}

		/// public propaty name  :  MkrSuggestRtPric
		/// <summary>メーカー希望小売価格プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー希望小売価格プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 MkrSuggestRtPric
		{
			get{return _mkrSuggestRtPric;}
			set{_mkrSuggestRtPric = value;}
		}

		/// public propaty name  :  ListPrice
		/// <summary>定価プロパティ</summary>
		/// <value>0:オープン価格</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 ListPrice
		{
			get{return _listPrice;}
			set{_listPrice = value;}
		}

		/// public propaty name  :  UnitPrice
		/// <summary>単価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 UnitPrice
		{
			get{return _unitPrice;}
			set{_unitPrice = value;}
		}

		/// public propaty name  :  ApplyStaDate
		/// <summary>適用開始日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   適用開始日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 ApplyStaDate
		{
			get{return _applyStaDate;}
			set{_applyStaDate = value;}
		}

		/// public propaty name  :  ApplyEndDate
		/// <summary>適用終了日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   適用終了日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public Int32 ApplyEndDate
		{
			get{return _applyEndDate;}
			set{_applyEndDate = value;}
		}

		/// public propaty name  :  ModelFitDiv
		/// <summary>適合車種区分プロパティ</summary>
		/// <value>0:適合車種なし,1:適合車種あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   適合車種区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int16 ModelFitDiv
		{
			get{return _modelFitDiv;}
			set{_modelFitDiv = value;}
		}

		/// public propaty name  :  GoodsImage
		/// <summary>商品画像プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品画像プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Byte[] GoodsImage
		{
			get{return _goodsImage;}
			set{_goodsImage = value;}
		}

        /// public propaty name  :  BrgnGoodsGrpCode
        /// <summary>お買得商品グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   お買得商品グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 BrgnGoodsGrpCode
        {
            get { return _brgnGoodsGrpCode; }
            set { _brgnGoodsGrpCode = value; }
        }


        /// public propaty name  :  DisplayDivCode
        /// <summary>表示区分プロパティ</summary>
        /// <value>0:0:表示,1:非表示</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayDivCode
        {
            get { return _displayDivCode; }
            set { _displayDivCode = value; }
        }

		/// <summary>
		/// お買得商品設定ワークコンストラクタ
		/// </summary>
		/// <returns>RecBgnGdsWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   RecBgnGdsWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public RecBgnGdsWork()
		{
		}

	}

/// <summary>
///  Ver5.10.1.0用のカスタムシライアライザです。
/// </summary>
/// <returns>RecBgnGdsWorkクラスのインスタンス(object)</returns>
/// <remarks>
/// <br>Note　　　　　　 :   RecBgnGdsWorkクラスのカスタムシリアライザを定義します</br>
/// <br>Programer        :   自動生成</br>
/// </remarks>
public class RecBgnGdsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
{
    #region ICustomSerializationSurrogate メンバ

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです
    /// </summary>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecBgnGdsWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public void Serialize(System.IO.BinaryWriter writer, object graph)
    {
        // TODO:  RecBgnGdsWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
        if (writer == null)
            throw new ArgumentNullException();

        if (graph != null && !(graph is RecBgnGdsWork || graph is ArrayList || graph is RecBgnGdsWork[]))
            throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RecBgnGdsWork).FullName));

        if (graph != null && graph is RecBgnGdsWork)
        {
            Type t = graph.GetType();
            if (!CustomFormatterServices.NeedCustomSerialization(t))
                throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
        }

        //SerializationTypeInfo
        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork");

        //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
        int occurrence = 0;     //一般にゼロの場合もありえます
        if (graph is ArrayList)
        {
            serInfo.RetTypeInfo = 0;
            occurrence = ((ArrayList)graph).Count;
        }
        else if (graph is RecBgnGdsWork[])
        {
            serInfo.RetTypeInfo = 2;
            occurrence = ((RecBgnGdsWork[])graph).Length;
        }
        else if (graph is RecBgnGdsWork)
        {
            serInfo.RetTypeInfo = 1;
            occurrence = 1;
        }

        serInfo.Occurrence = occurrence;		 //繰り返し数	

        //作成日時
        serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
        //更新日時
        serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
        //論理削除区分
        serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
        //問合せ元企業コード
        serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
        //問合せ元拠点コード
        serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
        //問合せ先企業コード
        serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
        //問合せ先拠点コード
        serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
        //得意先コード
        serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
        //管理拠点コード
        serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
        //商品番号
        serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
        //商品メーカーコード
        serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
        //商品メーカー名称
        serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
        //商品名称
        serInfo.MemberInfo.Add(typeof(string)); //GoodsName
        //BLグループコード
        serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
        //BL商品コード
        serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
        //商品コメント
        serInfo.MemberInfo.Add(typeof(string)); //GoodsComment
        //メーカー希望小売価格
        serInfo.MemberInfo.Add(typeof(Int64)); //MkrSuggestRtPric
        //定価
        serInfo.MemberInfo.Add(typeof(Int64)); //ListPrice
        //単価
        serInfo.MemberInfo.Add(typeof(Int64)); //UnitPrice
        //適用開始日
        serInfo.MemberInfo.Add(typeof(Int32)); //ApplyStaDate
        //適用終了日
        serInfo.MemberInfo.Add(typeof(Int32)); //ApplyEndDate
        //適合車種区分
        serInfo.MemberInfo.Add(typeof(Int16)); //ModelFitDiv
        //商品画像
        serInfo.MemberInfo.Add(typeof(Byte[])); //GoodsImage
        //お買得商品グループコード
        serInfo.MemberInfo.Add(typeof(Int16)); //BrgnGoodsGrpCode
        //表示区分
        serInfo.MemberInfo.Add(typeof(Int32)); //DisplayDivCode

        serInfo.Serialize(writer, serInfo);
        if (graph is RecBgnGdsWork)
        {
            RecBgnGdsWork temp = (RecBgnGdsWork)graph;

            SetRecBgnGdsWork(writer, temp);
        }
        else
        {
            ArrayList lst = null;
            if (graph is RecBgnGdsWork[])
            {
                lst = new ArrayList();
                lst.AddRange((RecBgnGdsWork[])graph);
            }
            else
            {
                lst = (ArrayList)graph;
            }

            foreach (RecBgnGdsWork temp in lst)
            {
                SetRecBgnGdsWork(writer, temp);
            }

        }


    }


    /// <summary>
    /// RecBgnGdsWorkメンバ数(publicプロパティ数)
    /// </summary>
    private const int currentMemberCount = 25;

    /// <summary>
    ///  RecBgnGdsWorkインスタンス書き込み
    /// </summary>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecBgnGdsWorkのインスタンスを書き込み</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    private void SetRecBgnGdsWork(System.IO.BinaryWriter writer, RecBgnGdsWork temp)
    {
        //作成日時
        writer.Write((Int64)temp.CreateDateTime.Ticks);
        //更新日時
        writer.Write((Int64)temp.UpdateDateTime.Ticks);
        //論理削除区分
        writer.Write(temp.LogicalDeleteCode);
        //問合せ元企業コード
        writer.Write(temp.InqOriginalEpCd);
        //問合せ元拠点コード
        writer.Write(temp.InqOriginalSecCd);
        //問合せ先企業コード
        writer.Write(temp.InqOtherEpCd);
        //問合せ先拠点コード
        writer.Write(temp.InqOtherSecCd);
        //得意先コード
        writer.Write(temp.CustomerCode);
        //管理拠点コード
        writer.Write(temp.MngSectionCode);
        //商品番号
        writer.Write(temp.GoodsNo);
        //商品メーカーコード
        writer.Write(temp.GoodsMakerCd);
        //商品メーカー名称
        writer.Write(temp.GoodsMakerNm);
        //商品名称
        writer.Write(temp.GoodsName);
        //BLグループコード
        writer.Write(temp.BLGroupCode);
        //BL商品コード
        writer.Write(temp.BLGoodsCode);
        //商品コメント
        writer.Write(temp.GoodsComment);
        //メーカー希望小売価格
        writer.Write(temp.MkrSuggestRtPric);
        //定価
        writer.Write(temp.ListPrice);
        //単価
        writer.Write(temp.UnitPrice);
        //適用開始日
        writer.Write(temp.ApplyStaDate);
        //適用終了日
        writer.Write(temp.ApplyEndDate);
        //適合車種区分
        writer.Write(temp.ModelFitDiv);
        //商品画像
        writer.Write(temp.GoodsImage.Length);
        writer.Write(temp.GoodsImage);
        //お買得商品グループコード
        writer.Write(temp.BrgnGoodsGrpCode);
        //表示区分
        writer.Write(temp.DisplayDivCode);
    }

    /// <summary>
    ///  RecBgnGdsWorkインスタンス取得
    /// </summary>
    /// <returns>RecBgnGdsWorkクラスのインスタンス</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecBgnGdsWorkのインスタンスを取得します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    private RecBgnGdsWork GetRecBgnGdsWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    {
        // V5.1.0.0なので不要ですが、V5.1.0.1以降では
        // serInfo.MemberInfo.Count < currentMemberCount
        // のケースについての配慮が必要になります。

        RecBgnGdsWork temp = new RecBgnGdsWork();

        //作成日時
        temp.CreateDateTime = new DateTime(reader.ReadInt64());
        //更新日時
        temp.UpdateDateTime = new DateTime(reader.ReadInt64());
        //論理削除区分
        temp.LogicalDeleteCode = reader.ReadInt32();
        //問合せ元企業コード
        temp.InqOriginalEpCd = reader.ReadString();
        //問合せ元拠点コード
        temp.InqOriginalSecCd = reader.ReadString();
        //問合せ先企業コード
        temp.InqOtherEpCd = reader.ReadString();
        //問合せ先拠点コード
        temp.InqOtherSecCd = reader.ReadString();
        //得意先コード
        temp.CustomerCode = reader.ReadInt32();
        //管理拠点コード
        temp.MngSectionCode = reader.ReadString();
        //商品番号
        temp.GoodsNo = reader.ReadString();
        //商品メーカーコード
        temp.GoodsMakerCd = reader.ReadInt32();
        //商品メーカー名称
        temp.GoodsMakerNm = reader.ReadString();
        //商品名称
        temp.GoodsName = reader.ReadString();
        //BLグループコード
        temp.BLGroupCode = reader.ReadInt32();
        //BL商品コード
        temp.BLGoodsCode = reader.ReadInt32();
        //商品コメント
        temp.GoodsComment = reader.ReadString();
        //メーカー希望小売価格
        temp.MkrSuggestRtPric = reader.ReadInt64();
        //定価
        temp.ListPrice = reader.ReadInt64();
        //単価
        temp.UnitPrice = reader.ReadInt64();
        //適用開始日
        temp.ApplyStaDate = reader.ReadInt32();
        //適用終了日
        temp.ApplyEndDate = reader.ReadInt32();
        //適合車種区分
        temp.ModelFitDiv = reader.ReadInt16();
        //商品画像
        int length = reader.ReadInt32();
        temp.GoodsImage = reader.ReadBytes(length);
        //お買得商品グループコード
        temp.BrgnGoodsGrpCode = reader.ReadInt16();
        //表示区分
        temp.DisplayDivCode = reader.ReadInt32();


        //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
        //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
        //型情報にしたがって、ストリームから情報を読み出します...といっても
        //読み出して捨てることになります。
        for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
        {
            //byte[],char[]をデシリアライズする直前に、そのlengthが
            //デシリアライズされているケースがある、byte[],char[]の
            //デシリアライズにはlengthが必要なのでint型のデータをデ
            //シリアライズした場合は、この値をこの変数に退避します。
            int optCount = 0;
            object oMemberType = serInfo.MemberInfo[k];
            if (oMemberType is Type)
            {
                Type t = (Type)oMemberType;
                object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                if (t.Equals(typeof(int)))
                {
                    optCount = Convert.ToInt32(oData);
                }
                else
                {
                    optCount = 0;
                }
            }
            else if (oMemberType is string)
            {
                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                object userData = formatter.Deserialize(reader);  //読み飛ばし
            }
        }
        return temp;
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムデシリアライザです
    /// </summary>
    /// <returns>RecBgnGdsWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecBgnGdsWorkクラスのカスタムデシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public object Deserialize(System.IO.BinaryReader reader)
    {
        object retValue = null;
        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
        ArrayList lst = new ArrayList();
        for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
        {
            RecBgnGdsWork temp = GetRecBgnGdsWork(reader, serInfo);
            lst.Add(temp);
        }
        switch (serInfo.RetTypeInfo)
        {
            case 0:
                retValue = lst;
                break;
            case 1:
                retValue = lst[0];
                break;
            case 2:
                retValue = (RecBgnGdsWork[])lst.ToArray(typeof(RecBgnGdsWork));
                break;
        }
        return retValue;
    }

    #endregion
}
}

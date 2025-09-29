using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
  /// public class name:   GoodsWork
  /// <summary>
  ///                      商品（提供）ワーク
  /// </summary>
  /// <remarks>
  /// <br>note             :   商品（提供）ワークヘッダファイル</br>
  /// <br>Programmer       :   自動生成</br>
  /// <br>Date             :   </br>
  /// <br>Genarated Date   :   2007/08/27  (CSharp File Generated Date)</br>
  /// <br>Update Note      :   </br>
  /// </remarks>
  [Serializable]
  [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
  public class GoodsWork : IFileHeaderOffer
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

    /// <summary>商品メーカーコード</summary>
    private Int32 _goodsMakerCd;

    /// <summary>メーカー名称</summary>
    private string _makerName = "";

    /// <summary>商品番号</summary>
    private string _goodsNo = "";

    /// <summary>商品名称</summary>
    private string _goodsName = "";

    /// <summary>商品名略称</summary>
    private string _goodsShortName = "";

    /// <summary>商品名称カナ</summary>
    private string _goodsNameKana = "";

    /// <summary>JANコード</summary>
    /// <remarks>標準タイプ13桁または短縮タイプ8桁のJANコード</remarks>
    private string _jan = "";

    /// <summary>BL商品コード</summary>
    private Int32 _bLGoodsCode;

    /// <summary>BL商品コード名称（全角）</summary>
    private string _bLGoodsFullName = "";

    /// <summary>単位コード</summary>
    private Int32 _unitCode;

    /// <summary>単位名称</summary>
    private string _unitName = "";

    /// <summary>表示順位</summary>
    private Int32 _displayOrder;

    /// <summary>商品区分グループコード</summary>
    /// <remarks>旧：商品大分類コード</remarks>
    private string _largeGoodsGanreCode = "";

    /// <summary>商品区分グループ名称</summary>
    /// <remarks>旧：商品大分類名称</remarks>
    private string _largeGoodsGanreName = "";

    /// <summary>商品区分コード</summary>
    /// <remarks>旧：商品中分類コード</remarks>
    private string _mediumGoodsGanreCode = "";

    /// <summary>商品区分名称</summary>
    /// <remarks>旧：商品中分類名称</remarks>
    private string _mediumGoodsGanreName = "";

    /// <summary>商品区分詳細コード</summary>
    private string _detailGoodsGanreCode = "";

    /// <summary>商品区分詳細名称</summary>
    private string _detailGoodsGanreName = "";

    /// <summary>商品掛率ランク</summary>
    private string _goodsRateRank = "";

    /// <summary>発注単位</summary>
    private Int32 _salesOrderUnit;

    /// <summary>セット商品区分</summary>
    private Int32 _goodsSetDivCd;

    /// <summary>課税区分</summary>
    private Int32 _taxationDivCd;

    /// <summary>ハイフン無商品番号</summary>
    private string _goodsNoNoneHyphen = "";

    /// <summary>提供日付</summary>
    /// <remarks>YYYYMMDD</remarks>
    private DateTime _offerDate;

    /// <summary>商品属性</summary>
    /// <remarks>0:純正　1:その他</remarks>
    private Int32 _goodsKindCode;

    /// <summary>商品備考１</summary>
    private string _goodsNote1 = "";

    /// <summary>商品備考２</summary>
    private string _goodsNote2 = "";

    /// <summary>商品規格・特記事項</summary>
    private string _goodsSpecialNote = "";


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
      get { return _createDateTime; }
      set { _createDateTime = value; }
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
      get { return _updateDateTime; }
      set { _updateDateTime = value; }
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
      get { return _logicalDeleteCode; }
      set { _logicalDeleteCode = value; }
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
      get { return _goodsMakerCd; }
      set { _goodsMakerCd = value; }
    }

    /// public propaty name  :  MakerName
    /// <summary>メーカー名称プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   メーカー名称プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string MakerName
    {
      get { return _makerName; }
      set { _makerName = value; }
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
      get { return _goodsNo; }
      set { _goodsNo = value; }
    }

    /// public propaty name  :  GoodsName
    /// <summary>商品名称プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品名称プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string GoodsName
    {
      get { return _goodsName; }
      set { _goodsName = value; }
    }

    /// public propaty name  :  GoodsShortName
    /// <summary>商品名略称プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品名略称プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string GoodsShortName
    {
      get { return _goodsShortName; }
      set { _goodsShortName = value; }
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
      get { return _goodsNameKana; }
      set { _goodsNameKana = value; }
    }

    /// public propaty name  :  Jan
    /// <summary>JANコードプロパティ</summary>
    /// <value>標準タイプ13桁または短縮タイプ8桁のJANコード</value>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   JANコードプロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string Jan
    {
      get { return _jan; }
      set { _jan = value; }
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
      get { return _bLGoodsCode; }
      set { _bLGoodsCode = value; }
    }

    /// public propaty name  :  BLGoodsFullName
    /// <summary>BL商品コード名称（全角）プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string BLGoodsFullName
    {
      get { return _bLGoodsFullName; }
      set { _bLGoodsFullName = value; }
    }

    /// public propaty name  :  UnitCode
    /// <summary>単位コードプロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   単位コードプロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public Int32 UnitCode
    {
      get { return _unitCode; }
      set { _unitCode = value; }
    }

    /// public propaty name  :  UnitName
    /// <summary>単位名称プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   単位名称プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string UnitName
    {
      get { return _unitName; }
      set { _unitName = value; }
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
      get { return _displayOrder; }
      set { _displayOrder = value; }
    }

    /// public propaty name  :  LargeGoodsGanreCode
    /// <summary>商品区分グループコードプロパティ</summary>
    /// <value>旧：商品大分類コード</value>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品区分グループコードプロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string LargeGoodsGanreCode
    {
      get { return _largeGoodsGanreCode; }
      set { _largeGoodsGanreCode = value; }
    }

    /// public propaty name  :  LargeGoodsGanreName
    /// <summary>商品区分グループ名称プロパティ</summary>
    /// <value>旧：商品大分類名称</value>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品区分グループ名称プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string LargeGoodsGanreName
    {
      get { return _largeGoodsGanreName; }
      set { _largeGoodsGanreName = value; }
    }

    /// public propaty name  :  MediumGoodsGanreCode
    /// <summary>商品区分コードプロパティ</summary>
    /// <value>旧：商品中分類コード</value>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品区分コードプロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string MediumGoodsGanreCode
    {
      get { return _mediumGoodsGanreCode; }
      set { _mediumGoodsGanreCode = value; }
    }

    /// public propaty name  :  MediumGoodsGanreName
    /// <summary>商品区分名称プロパティ</summary>
    /// <value>旧：商品中分類名称</value>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品区分名称プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string MediumGoodsGanreName
    {
      get { return _mediumGoodsGanreName; }
      set { _mediumGoodsGanreName = value; }
    }

    /// public propaty name  :  DetailGoodsGanreCode
    /// <summary>商品区分詳細コードプロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品区分詳細コードプロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string DetailGoodsGanreCode
    {
      get { return _detailGoodsGanreCode; }
      set { _detailGoodsGanreCode = value; }
    }

    /// public propaty name  :  DetailGoodsGanreName
    /// <summary>商品区分詳細名称プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品区分詳細名称プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string DetailGoodsGanreName
    {
      get { return _detailGoodsGanreName; }
      set { _detailGoodsGanreName = value; }
    }

    /// public propaty name  :  GoodsRateRank
    /// <summary>商品掛率ランクプロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品掛率ランクプロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string GoodsRateRank
    {
      get { return _goodsRateRank; }
      set { _goodsRateRank = value; }
    }

    /// public propaty name  :  SalesOrderUnit
    /// <summary>発注単位プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   発注単位プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public Int32 SalesOrderUnit
    {
      get { return _salesOrderUnit; }
      set { _salesOrderUnit = value; }
    }

    /// public propaty name  :  GoodsSetDivCd
    /// <summary>セット商品区分プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   セット商品区分プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public Int32 GoodsSetDivCd
    {
      get { return _goodsSetDivCd; }
      set { _goodsSetDivCd = value; }
    }

    /// public propaty name  :  TaxationDivCd
    /// <summary>課税区分プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   課税区分プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public Int32 TaxationDivCd
    {
      get { return _taxationDivCd; }
      set { _taxationDivCd = value; }
    }

    /// public propaty name  :  GoodsNoNoneHyphen
    /// <summary>ハイフン無商品番号プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   ハイフン無商品番号プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string GoodsNoNoneHyphen
    {
      get { return _goodsNoNoneHyphen; }
      set { _goodsNoNoneHyphen = value; }
    }

    /// public propaty name  :  OfferDate
    /// <summary>提供日付プロパティ</summary>
    /// <value>YYYYMMDD</value>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   提供日付プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public DateTime OfferDate
    {
      get { return _offerDate; }
      set { _offerDate = value; }
    }

    /// public propaty name  :  GoodsKindCode
    /// <summary>商品属性プロパティ</summary>
    /// <value>0:純正　1:その他</value>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品属性プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public Int32 GoodsKindCode
    {
      get { return _goodsKindCode; }
      set { _goodsKindCode = value; }
    }

    /// public propaty name  :  GoodsNote1
    /// <summary>商品備考１プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品備考１プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string GoodsNote1
    {
      get { return _goodsNote1; }
      set { _goodsNote1 = value; }
    }

    /// public propaty name  :  GoodsNote2
    /// <summary>商品備考２プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品備考２プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string GoodsNote2
    {
      get { return _goodsNote2; }
      set { _goodsNote2 = value; }
    }

    /// public propaty name  :  GoodsSpecialNote
    /// <summary>商品規格・特記事項プロパティ</summary>
    /// ----------------------------------------------------------------------
    /// <remarks>
    /// <br>note             :   商品規格・特記事項プロパティ</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public string GoodsSpecialNote
    {
      get { return _goodsSpecialNote; }
      set { _goodsSpecialNote = value; }
    }


    /// <summary>
    /// 商品（提供）ワークコンストラクタ
    /// </summary>
    /// <returns>GoodsWorkクラスのインスタンス</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsWorkクラスの新しいインスタンスを生成します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public GoodsWork()
    {
    }

  }

  /// <summary>
  ///  Ver5.10.1.0用のカスタムシライアライザです。
  /// </summary>
  /// <returns>GoodsWorkクラスのインスタンス(object)</returns>
  /// <remarks>
  /// <br>Note　　　　　　 :   GoodsWorkクラスのカスタムシリアライザを定義します</br>
  /// <br>Programer        :   自動生成</br>
  /// </remarks>
  public class GoodsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
  {
    #region ICustomSerializationSurrogate メンバ

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです
    /// </summary>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public void Serialize(System.IO.BinaryWriter writer, object graph)
    {
      // TODO:  GoodsWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
      if (writer == null)
        throw new ArgumentNullException();

      if (graph != null && !(graph is GoodsWork || graph is ArrayList || graph is GoodsWork[]))
        throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GoodsWork).FullName));

      if (graph != null && graph is GoodsWork)
      {
        Type t = graph.GetType();
        if (!CustomFormatterServices.NeedCustomSerialization(t))
          throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
      }

      //SerializationTypeInfo
      Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsWork");

      //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
      int occurrence = 0;     //一般にゼロの場合もありえます
      if (graph is ArrayList)
      {
        serInfo.RetTypeInfo = 0;
        occurrence = ((ArrayList)graph).Count;
      }
      else if (graph is GoodsWork[])
      {
        serInfo.RetTypeInfo = 2;
        occurrence = ((GoodsWork[])graph).Length;
      }
      else if (graph is GoodsWork)
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
      //商品メーカーコード
      serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
      //メーカー名称
      serInfo.MemberInfo.Add(typeof(string)); //MakerName
      //商品番号
      serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
      //商品名称
      serInfo.MemberInfo.Add(typeof(string)); //GoodsName
      //商品名略称
      serInfo.MemberInfo.Add(typeof(string)); //GoodsShortName
      //商品名称カナ
      serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
      //JANコード
      serInfo.MemberInfo.Add(typeof(string)); //Jan
      //BL商品コード
      serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
      //BL商品コード名称（全角）
      serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
      //単位コード
      serInfo.MemberInfo.Add(typeof(Int32)); //UnitCode
      //単位名称
      serInfo.MemberInfo.Add(typeof(string)); //UnitName
      //表示順位
      serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
      //商品区分グループコード
      serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreCode
      //商品区分グループ名称
      serInfo.MemberInfo.Add(typeof(string)); //LargeGoodsGanreName
      //商品区分コード
      serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreCode
      //商品区分名称
      serInfo.MemberInfo.Add(typeof(string)); //MediumGoodsGanreName
      //商品区分詳細コード
      serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreCode
      //商品区分詳細名称
      serInfo.MemberInfo.Add(typeof(string)); //DetailGoodsGanreName
      //商品掛率ランク
      serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
      //発注単位
      serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderUnit
      //セット商品区分
      serInfo.MemberInfo.Add(typeof(Int32)); //GoodsSetDivCd
      //課税区分
      serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
      //ハイフン無商品番号
      serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyphen
      //提供日付
      serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
      //商品属性
      serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
      //商品備考１
      serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
      //商品備考２
      serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2
      //商品規格・特記事項
      serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote


      serInfo.Serialize(writer, serInfo);
      if (graph is GoodsWork)
      {
        GoodsWork temp = (GoodsWork)graph;

        SetGoodsWork(writer, temp);
      }
      else
      {
        ArrayList lst = null;
        if (graph is GoodsWork[])
        {
          lst = new ArrayList();
          lst.AddRange((GoodsWork[])graph);
        }
        else
        {
          lst = (ArrayList)graph;
        }

        foreach (GoodsWork temp in lst)
        {
          SetGoodsWork(writer, temp);
        }

      }


    }


    /// <summary>
    /// GoodsWorkメンバ数(publicプロパティ数)
    /// </summary>
    private const int currentMemberCount = 31;

    /// <summary>
    ///  GoodsWorkインスタンス書き込み
    /// </summary>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsWorkのインスタンスを書き込み</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    private void SetGoodsWork(System.IO.BinaryWriter writer, GoodsWork temp)
    {
      //作成日時
      writer.Write((Int64)temp.CreateDateTime.Ticks);
      //更新日時
      writer.Write((Int64)temp.UpdateDateTime.Ticks);
      //論理削除区分
      writer.Write(temp.LogicalDeleteCode);
      //商品メーカーコード
      writer.Write(temp.GoodsMakerCd);
      //メーカー名称
      writer.Write(temp.MakerName);
      //商品番号
      writer.Write(temp.GoodsNo);
      //商品名称
      writer.Write(temp.GoodsName);
      //商品名略称
      writer.Write(temp.GoodsShortName);
      //商品名称カナ
      writer.Write(temp.GoodsNameKana);
      //JANコード
      writer.Write(temp.Jan);
      //BL商品コード
      writer.Write(temp.BLGoodsCode);
      //BL商品コード名称（全角）
      writer.Write(temp.BLGoodsFullName);
      //単位コード
      writer.Write(temp.UnitCode);
      //単位名称
      writer.Write(temp.UnitName);
      //表示順位
      writer.Write(temp.DisplayOrder);
      //商品区分グループコード
      writer.Write(temp.LargeGoodsGanreCode);
      //商品区分グループ名称
      writer.Write(temp.LargeGoodsGanreName);
      //商品区分コード
      writer.Write(temp.MediumGoodsGanreCode);
      //商品区分名称
      writer.Write(temp.MediumGoodsGanreName);
      //商品区分詳細コード
      writer.Write(temp.DetailGoodsGanreCode);
      //商品区分詳細名称
      writer.Write(temp.DetailGoodsGanreName);
      //商品掛率ランク
      writer.Write(temp.GoodsRateRank);
      //発注単位
      writer.Write(temp.SalesOrderUnit);
      //セット商品区分
      writer.Write(temp.GoodsSetDivCd);
      //課税区分
      writer.Write(temp.TaxationDivCd);
      //ハイフン無商品番号
      writer.Write(temp.GoodsNoNoneHyphen);
      //提供日付
      writer.Write((Int64)temp.OfferDate.Ticks);
      //商品属性
      writer.Write(temp.GoodsKindCode);
      //商品備考１
      writer.Write(temp.GoodsNote1);
      //商品備考２
      writer.Write(temp.GoodsNote2);
      //商品規格・特記事項
      writer.Write(temp.GoodsSpecialNote);

    }

    /// <summary>
    ///  GoodsWorkインスタンス取得
    /// </summary>
    /// <returns>GoodsWorkクラスのインスタンス</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsWorkのインスタンスを取得します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    private GoodsWork GetGoodsWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    {
      // V5.1.0.0なので不要ですが、V5.1.0.1以降では
      // serInfo.MemberInfo.Count < currentMemberCount
      // のケースについての配慮が必要になります。

      GoodsWork temp = new GoodsWork();

      //作成日時
      temp.CreateDateTime = new DateTime(reader.ReadInt64());
      //更新日時
      temp.UpdateDateTime = new DateTime(reader.ReadInt64());
      //論理削除区分
      temp.LogicalDeleteCode = reader.ReadInt32();
      //商品メーカーコード
      temp.GoodsMakerCd = reader.ReadInt32();
      //メーカー名称
      temp.MakerName = reader.ReadString();
      //商品番号
      temp.GoodsNo = reader.ReadString();
      //商品名称
      temp.GoodsName = reader.ReadString();
      //商品名略称
      temp.GoodsShortName = reader.ReadString();
      //商品名称カナ
      temp.GoodsNameKana = reader.ReadString();
      //JANコード
      temp.Jan = reader.ReadString();
      //BL商品コード
      temp.BLGoodsCode = reader.ReadInt32();
      //BL商品コード名称（全角）
      temp.BLGoodsFullName = reader.ReadString();
      //単位コード
      temp.UnitCode = reader.ReadInt32();
      //単位名称
      temp.UnitName = reader.ReadString();
      //表示順位
      temp.DisplayOrder = reader.ReadInt32();
      //商品区分グループコード
      temp.LargeGoodsGanreCode = reader.ReadString();
      //商品区分グループ名称
      temp.LargeGoodsGanreName = reader.ReadString();
      //商品区分コード
      temp.MediumGoodsGanreCode = reader.ReadString();
      //商品区分名称
      temp.MediumGoodsGanreName = reader.ReadString();
      //商品区分詳細コード
      temp.DetailGoodsGanreCode = reader.ReadString();
      //商品区分詳細名称
      temp.DetailGoodsGanreName = reader.ReadString();
      //商品掛率ランク
      temp.GoodsRateRank = reader.ReadString();
      //発注単位
      temp.SalesOrderUnit = reader.ReadInt32();
      //セット商品区分
      temp.GoodsSetDivCd = reader.ReadInt32();
      //課税区分
      temp.TaxationDivCd = reader.ReadInt32();
      //ハイフン無商品番号
      temp.GoodsNoNoneHyphen = reader.ReadString();
      //提供日付
      temp.OfferDate = new DateTime(reader.ReadInt64());
      //商品属性
      temp.GoodsKindCode = reader.ReadInt32();
      //商品備考１
      temp.GoodsNote1 = reader.ReadString();
      //商品備考２
      temp.GoodsNote2 = reader.ReadString();
      //商品規格・特記事項
      temp.GoodsSpecialNote = reader.ReadString();


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
    /// <returns>GoodsWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsWorkクラスのカスタムデシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public object Deserialize(System.IO.BinaryReader reader)
    {
      object retValue = null;
      Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
      ArrayList lst = new ArrayList();
      for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
      {
        GoodsWork temp = GetGoodsWork(reader, serInfo);
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
          retValue = (GoodsWork[])lst.ToArray(typeof(GoodsWork));
          break;
      }
      return retValue;
    }

    #endregion
  }
}

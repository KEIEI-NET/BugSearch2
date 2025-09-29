using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsUnitDataWork
    /// <summary>
    ///                      商品連結データクラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品連結データクラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/07/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2014/02/10 Redmine#41976 高陽 商品マスタⅡの追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsUnitDataWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>JANコード</summary>
        /// <remarks>標準タイプ13桁または短縮タイプ8桁のJANコード</remarks>
        private string _jan = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>商品掛率ランク</summary>
        /// <remarks>層別</remarks>
        private string _goodsRateRank = "";

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
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

        /// <summary>自社分類コード</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>更新年月日</summary>
        private DateTime _updateDate;

        /// <summary>提供データ区分</summary>
        private Int32 _offerDataDiv;

        /// <summary>価格リスト</summary>
        private ArrayList _priceList;

        /// <summary>在庫リスト</summary>
        private ArrayList _stockList;

        // -------- ADD START 2014/02/10 高陽 -------->>>>>
        /// <summary>商品マスタ表示用オプション</summary>
        private Int32 _optKonmanGoodsMstCtl;

        /// <summary>規格</summary>
        private string _standard = "";

        /// <summary>荷姿</summary>
        private string _packing = "";

        /// <summary>ＰＯＳNo.</summary>
        private string _posNo = "";

        /// <summary>メーカー品番</summary>
        private string _makerGoodsNo = "";

        /// <summary>作成日時Ⅱ</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTimeA;

        /// <summary>更新日時Ⅱ</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTimeA;

        /// <summary>GUIDⅡ</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuidA;
        // -------- ADD END 2014/02/10 高陽 --------<<<<<


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

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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

        /// public propaty name  :  GoodsRateRank
        /// <summary>商品掛率ランクプロパティ</summary>
        /// <value>層別</value>
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

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>更新年月日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>提供データ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }

        /// public propaty name  :  PriceList
        /// <summary>価格リストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList PriceList
        {
            get { return _priceList; }
            set { _priceList = value; }
        }

        /// public propaty name  :  StockList
        /// <summary>在庫リストプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫リストプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList StockList
        {
            get { return _stockList; }
            set { _stockList = value; }
        }

        // -------- ADD START 2014/02/10 高陽 -------->>>>>
        /// public propaty name  :  OptKonmanGoodsMstCtl
        /// <summary>商品マスタ表示用オプションプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品マスタ表示用オプションプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OptKonmanGoodsMstCtl
        {
            get { return _optKonmanGoodsMstCtl; }
            set { _optKonmanGoodsMstCtl = value; }
        }

        /// public propaty name  :  Standard
        /// <summary>規格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   規格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Standard
        {
            get { return _standard; }
            set { _standard = value; }
        }

        /// public propaty name  :  Packing
        /// <summary>荷姿プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   荷姿プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Packing
        {
            get { return _packing; }
            set { _packing = value; }
        }

        /// public propaty name  :  PosNo
        /// <summary>ＰＯＳNo.プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＰＯＳNo.プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PosNo
        {
            get { return _posNo; }
            set { _posNo = value; }
        }

        /// public propaty name  :  MakerGoodsNo
        /// <summary>メーカー品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerGoodsNo
        {
            get { return _makerGoodsNo; }
            set { _makerGoodsNo = value; }
        }

        /// public propaty name  :  CreateDateTimeA
        /// <summary>作成日時Ⅱプロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTimeA
        {
            get { return _createDateTimeA; }
            set { _createDateTimeA = value; }
        }

        /// public propaty name  :  UpdateDateTimeA
        /// <summary>更新日時Ⅱプロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時Ⅱプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTimeA
        {
            get { return _updateDateTimeA; }
            set { _updateDateTimeA = value; }
        }

        /// public propaty name  :  FileHeaderGuidA
        /// <summary>GUIDⅡプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuidA
        {
            get { return _fileHeaderGuidA; }
            set { _fileHeaderGuidA = value; }
        }
        // -------- ADD END 2014/02/10 高陽 --------<<<<<

        /// <summary>
        /// 商品連結データクラスワークコンストラクタ
        /// </summary>
        /// <returns>GoodsUnitDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsUnitDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GoodsUnitDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsUnitDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class GoodsUnitDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsUnitDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsUnitDataWork || graph is ArrayList || graph is GoodsUnitDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GoodsUnitDataWork).FullName));

            if (graph != null && graph is GoodsUnitDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsUnitDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsUnitDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsUnitDataWork[])graph).Length;
            }
            else if (graph is GoodsUnitDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //JANコード
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //ハイフン無商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyphen
            //提供日付
            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            //商品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //商品備考１
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
            //商品備考２
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2
            //商品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            //自社分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDate
            //提供データ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv
            //価格リスト
            serInfo.MemberInfo.Add(typeof(ArrayList)); //PriceList
            //在庫リスト
            serInfo.MemberInfo.Add(typeof(ArrayList)); //StockList
            // -------- ADD START 2014/02/10 高陽 -------->>>>>
            //商品マスタ表示用オプション
            serInfo.MemberInfo.Add(typeof(Int32)); //OptKonmanGoodsMstCtl
            //規格
            serInfo.MemberInfo.Add(typeof(string)); //Standard
            //荷姿
            serInfo.MemberInfo.Add(typeof(string)); //Packing
            //ＰＯＳNo.
            serInfo.MemberInfo.Add(typeof(string)); //PosNo
            //メーカー品番
            serInfo.MemberInfo.Add(typeof(string)); //MakerGoodsNo
            //作成日時Ⅱ
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTimeA
            //更新日時Ⅱ
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTimeA
            //GUIDⅡ
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuidA
            // -------- ADD END 2014/02/10 高陽 --------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsUnitDataWork)
            {
                GoodsUnitDataWork temp = (GoodsUnitDataWork)graph;

                SetGoodsUnitDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsUnitDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsUnitDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsUnitDataWork temp in lst)
                {
                    SetGoodsUnitDataWork(writer, temp);
                }

            }
        }


        /// <summary>
        /// GoodsUnitDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 30;// DEL 2014/02/10 高陽
        private const int currentMemberCount = 38;// ADD 2014/02/10 高陽

        /// <summary>
        ///  GoodsUnitDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGoodsUnitDataWork(System.IO.BinaryWriter writer, GoodsUnitDataWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //JANコード
            writer.Write(temp.Jan);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //表示順位
            writer.Write(temp.DisplayOrder);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
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
            //自社分類コード
            writer.Write(temp.EnterpriseGanreCode);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //提供データ区分
            writer.Write(temp.OfferDataDiv);
            // -------- ADD START 2014/02/10 高陽 -------->>>>>
            //商品マスタ表示用オプション
            writer.Write(temp.OptKonmanGoodsMstCtl);
            //規格
            writer.Write(temp.Standard);
            //荷姿
            writer.Write(temp.Packing);
            //ＰＯＳNo.
            writer.Write(temp.PosNo);
            //メーカー品番
            writer.Write(temp.MakerGoodsNo);
            //作成日時Ⅱ
            writer.Write((Int64)temp.CreateDateTimeA.Ticks);
            //更新日時Ⅱ
            writer.Write((Int64)temp.UpdateDateTimeA.Ticks);
            //GUIDⅡ
            byte[] fileHeaderGuidArrayA = temp.FileHeaderGuidA.ToByteArray();
            writer.Write(fileHeaderGuidArrayA.Length);
            writer.Write(temp.FileHeaderGuidA.ToByteArray());
            // -------- ADD END 2014/02/10 高陽 --------<<<<<
            //価格リスト
            if (temp.PriceList == null)
            {
                writer.Write(0);
            }
            else
            {
                writer.Write(temp.PriceList.Count);
                for (int i = 0; i < temp.PriceList.Count; i++)
                {
                    SetUsrGoodsPriceWork(writer, temp.PriceList[i] as GoodsPriceUWork);
                }
            }
            //在庫リスト
            if (temp.StockList == null)
            {
                writer.Write(0);
            }
            else
            {
                writer.Write(temp.StockList.Count);
                for (int i = 0; i < temp.StockList.Count; i++)
                {
                    SetStockWork(writer, temp.StockList[i] as StockWork);
                }
            }
        }

        /// <summary>
        ///  GoodsPriceUWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsPriceUWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetUsrGoodsPriceWork(System.IO.BinaryWriter writer, GoodsPriceUWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //価格開始日
            writer.Write((Int64)temp.PriceStartDate.Ticks);
            //定価（浮動）
            writer.Write(temp.ListPrice);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //仕入率
            writer.Write(temp.StockRate);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);

        }

        /// <summary>
        ///  StockWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockWork(System.IO.BinaryWriter writer, StockWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //仕入単価（税抜,浮動）
            writer.Write(temp.StockUnitPriceFl);
            //仕入在庫数
            writer.Write(temp.SupplierStock);
            //受注数
            writer.Write(temp.AcpOdrCount);
            //M/O発注数
            writer.Write(temp.MonthOrderCount);
            //発注数
            writer.Write(temp.SalesOrderCount);
            //在庫区分
            writer.Write(temp.StockDiv);
            //移動中仕入在庫数
            writer.Write(temp.MovingSupliStock);
            //出荷可能数
            writer.Write(temp.ShipmentPosCnt);
            //在庫保有総額
            writer.Write(temp.StockTotalPrice);
            //最終仕入年月日
            writer.Write((Int64)temp.LastStockDate.Ticks);
            //最終売上日
            writer.Write((Int64)temp.LastSalesDate.Ticks);
            //最終棚卸更新日
            writer.Write((Int64)temp.LastInventoryUpdate.Ticks);
            //最低在庫数
            writer.Write(temp.MinimumStockCnt);
            //最高在庫数
            writer.Write(temp.MaximumStockCnt);
            //基準発注数
            writer.Write(temp.NmlSalOdrCount);
            //発注単位
            writer.Write(temp.SalesOrderUnit);
            //在庫発注先コード
            writer.Write(temp.StockSupplierCode);
            //ハイフン無商品番号
            writer.Write(temp.GoodsNoNoneHyphen);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //重複棚番１
            writer.Write(temp.DuplicationShelfNo1);
            //重複棚番２
            writer.Write(temp.DuplicationShelfNo2);
            //部品管理区分１
            writer.Write(temp.PartsManagementDivide1);
            //部品管理区分２
            writer.Write(temp.PartsManagementDivide2);
            //在庫備考１
            writer.Write(temp.StockNote1);
            //在庫備考２
            writer.Write(temp.StockNote2);
            //出荷数（未計上）
            writer.Write(temp.ShipmentCnt);
            //入荷数（未計上）
            writer.Write(temp.ArrivalCnt);
            //在庫登録日
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);

        }

        /// <summary>
        ///  GoodsUnitDataWorkインスタンス取得
        /// </summary>
        /// <returns>GoodsUnitDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private GoodsUnitDataWork GetGoodsUnitDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            GoodsUnitDataWork temp = new GoodsUnitDataWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //JANコード
            temp.Jan = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //表示順位
            temp.DisplayOrder = reader.ReadInt32();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
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
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //更新年月日
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //提供データ区分
            temp.OfferDataDiv = reader.ReadInt32();
            // -------- ADD START 2014/02/10 高陽 -------->>>>>
            //商品マスタ表示用オプション
            temp.OptKonmanGoodsMstCtl = reader.ReadInt32();
            //規格
            temp.Standard = reader.ReadString();
            //荷姿
            temp.Packing = reader.ReadString();
            //ＰＯＳNo.
            temp.PosNo = reader.ReadString();
            //メーカー品番
            temp.MakerGoodsNo = reader.ReadString();
            //作成日時Ⅱ
            temp.CreateDateTimeA = new DateTime(reader.ReadInt64());
            //更新日時Ⅱ
            temp.UpdateDateTimeA = new DateTime(reader.ReadInt64());
            //GUIDⅡ
            int lenOfFileHeaderGuidArrayA = reader.ReadInt32();
            byte[] fileHeaderGuidArrayA = reader.ReadBytes(lenOfFileHeaderGuidArrayA);
            temp.FileHeaderGuidA = new Guid(fileHeaderGuidArrayA);
            // -------- ADD END 2014/02/10 高陽 --------<<<<<
            //価格リスト
            int priceCnt = reader.ReadInt32();
            temp.PriceList = new ArrayList();
            for (int i = 0; i < priceCnt; i++)
            {
                GoodsPriceUWork tempPrice = new GoodsPriceUWork();

                //作成日時
                tempPrice.CreateDateTime = new DateTime(reader.ReadInt64());
                //更新日時
                tempPrice.UpdateDateTime = new DateTime(reader.ReadInt64());
                //企業コード
                tempPrice.EnterpriseCode = reader.ReadString();
                //GUID
                lenOfFileHeaderGuidArray = reader.ReadInt32();
                fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
                tempPrice.FileHeaderGuid = new Guid(fileHeaderGuidArray);
                //更新従業員コード
                tempPrice.UpdEmployeeCode = reader.ReadString();
                //更新アセンブリID1
                tempPrice.UpdAssemblyId1 = reader.ReadString();
                //更新アセンブリID2
                tempPrice.UpdAssemblyId2 = reader.ReadString();
                //論理削除区分
                tempPrice.LogicalDeleteCode = reader.ReadInt32();
                //商品メーカーコード
                tempPrice.GoodsMakerCd = reader.ReadInt32();
                //商品番号
                tempPrice.GoodsNo = reader.ReadString();
                //価格開始日
                tempPrice.PriceStartDate = new DateTime(reader.ReadInt64());
                //定価（浮動）
                tempPrice.ListPrice = reader.ReadDouble();
                //原価単価
                tempPrice.SalesUnitCost = reader.ReadDouble();
                //仕入率
                tempPrice.StockRate = reader.ReadDouble();
                //オープン価格区分
                tempPrice.OpenPriceDiv = reader.ReadInt32();
                //提供日付
                tempPrice.OfferDate = new DateTime(reader.ReadInt64());
                //更新年月日
                tempPrice.UpdateDate = new DateTime(reader.ReadInt64());

                temp.PriceList.Add(tempPrice);
            }
            //在庫リスト
            int stockCnt = reader.ReadInt32();
            temp.StockList = new ArrayList();
            for (int i = 0; i < stockCnt; i++)
            {
                StockWork tempStock = new StockWork();

                //作成日時
                tempStock.CreateDateTime = new DateTime(reader.ReadInt64());
                //更新日時
                tempStock.UpdateDateTime = new DateTime(reader.ReadInt64());
                //企業コード
                tempStock.EnterpriseCode = reader.ReadString();
                //GUID
                lenOfFileHeaderGuidArray = reader.ReadInt32();
                fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
                tempStock.FileHeaderGuid = new Guid(fileHeaderGuidArray);
                //更新従業員コード
                tempStock.UpdEmployeeCode = reader.ReadString();
                //更新アセンブリID1
                tempStock.UpdAssemblyId1 = reader.ReadString();
                //更新アセンブリID2
                tempStock.UpdAssemblyId2 = reader.ReadString();
                //論理削除区分
                tempStock.LogicalDeleteCode = reader.ReadInt32();
                //拠点コード
                tempStock.SectionCode = reader.ReadString();
                //拠点ガイド名称
                tempStock.SectionGuideNm = reader.ReadString();
                //倉庫コード
                tempStock.WarehouseCode = reader.ReadString();
                //倉庫名称
                tempStock.WarehouseName = reader.ReadString();
                //商品メーカーコード
                tempStock.GoodsMakerCd = reader.ReadInt32();
                //商品番号
                tempStock.GoodsNo = reader.ReadString();
                //仕入単価（税抜,浮動）
                tempStock.StockUnitPriceFl = reader.ReadDouble();
                //仕入在庫数
                tempStock.SupplierStock = reader.ReadDouble();
                //受注数
                tempStock.AcpOdrCount = reader.ReadDouble();
                //M/O発注数
                tempStock.MonthOrderCount = reader.ReadDouble();
                //発注数
                tempStock.SalesOrderCount = reader.ReadDouble();
                //在庫区分
                tempStock.StockDiv = reader.ReadInt32();
                //移動中仕入在庫数
                tempStock.MovingSupliStock = reader.ReadDouble();
                //出荷可能数
                tempStock.ShipmentPosCnt = reader.ReadDouble();
                //在庫保有総額
                tempStock.StockTotalPrice = reader.ReadInt64();
                //最終仕入年月日
                tempStock.LastStockDate = new DateTime(reader.ReadInt64());
                //最終売上日
                tempStock.LastSalesDate = new DateTime(reader.ReadInt64());
                //最終棚卸更新日
                tempStock.LastInventoryUpdate = new DateTime(reader.ReadInt64());
                //最低在庫数
                tempStock.MinimumStockCnt = reader.ReadDouble();
                //最高在庫数
                tempStock.MaximumStockCnt = reader.ReadDouble();
                //基準発注数
                tempStock.NmlSalOdrCount = reader.ReadDouble();
                //発注単位
                tempStock.SalesOrderUnit = reader.ReadInt32();
                //在庫発注先コード
                tempStock.StockSupplierCode = reader.ReadInt32();
                //ハイフン無商品番号
                tempStock.GoodsNoNoneHyphen = reader.ReadString();
                //倉庫棚番
                tempStock.WarehouseShelfNo = reader.ReadString();
                //重複棚番１
                tempStock.DuplicationShelfNo1 = reader.ReadString();
                //重複棚番２
                tempStock.DuplicationShelfNo2 = reader.ReadString();
                //部品管理区分１
                tempStock.PartsManagementDivide1 = reader.ReadString();
                //部品管理区分２
                tempStock.PartsManagementDivide2 = reader.ReadString();
                //在庫備考１
                tempStock.StockNote1 = reader.ReadString();
                //在庫備考２
                tempStock.StockNote2 = reader.ReadString();
                //出荷数（未計上）
                tempStock.ShipmentCnt = reader.ReadDouble();
                //入荷数（未計上）
                tempStock.ArrivalCnt = reader.ReadDouble();
                //在庫登録日
                tempStock.StockCreateDate = new DateTime(reader.ReadInt64());
                //更新年月日
                tempStock.UpdateDate = new DateTime(reader.ReadInt64());

                temp.StockList.Add(tempStock);
            }

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
        /// <returns>GoodsUnitDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUnitDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsUnitDataWork temp = GetGoodsUnitDataWork(reader, serInfo);
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
                    retValue = (GoodsUnitDataWork[])lst.ToArray(typeof(GoodsUnitDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

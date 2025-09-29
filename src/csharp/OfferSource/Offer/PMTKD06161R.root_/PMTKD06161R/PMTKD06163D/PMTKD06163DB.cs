using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsSubstWork
    /// <summary>
    ///                      部品代替ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品代替ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2006/11/15</br>
    /// <br>Genarated Date   :   2007/01/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsSubstWork
    {
        /// <summary>カタログ部品メーカーコード</summary>
        private Int32 _catalogPartsMakerCd;

        /// <summary>ハイフン付旧品番</summary>
        private string _oldPartsNoWithHyphen = "";

        /// <summary>ハイフン付新品番</summary>
        private string _newPartsNoWithHyphen = "";

        /// <summary>ハイフン付新品番表示順位</summary>
        private Int32 _nPrtNoWithHypnDspOdr;

        /// <summary>部品複数代替フラグ</summary>
        /// <remarks>0:複数代替なし 1:複数代替あり</remarks>
        private Int32 _partsPluralSubstFlg;

        /// <summary>メイン・サブ部品区分</summary>
        /// <remarks>0:複数代替なし 1:メイン 2～:子</remarks>
        private Int32 _mainOrSubPartsDivCd;

        /// <summary>部品QTY</summary>
        /// <remarks>メイン・サブ部品区分が0以外の時に有効</remarks>
        private Double _partsQty;

        /// <summary>部品複数代替摘要</summary>
        /// <remarks>メイン・サブ部品区分が0以外の時に有効</remarks>
        private string _partsPluralSubstCmnt = "";

        /// <summary>複数代替元ハイフン付新品番</summary>
        /// <remarks>メイン・サブ部品区分が0以外の時に有効</remarks>
        private string _plrlSubNewPrtNoHypn = "";

        /// <summary>ハイフン無最新部品品番</summary>
        private string _newPrtsNoNoneHyphen = "";

        /// <summary>翼部品コード</summary>
        /// <remarks>1～99999:提供分,100000～ユーザー登録用</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>翼部品コード枝番</summary>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>メーカー提供部品名称</summary>
        private string _makerOfferPartsName = "";

        /// <summary>部品価格</summary>
        private Int64 _partsPrice;

        /// <summary>部品開始日</summary>
        private DateTime _partsPriceStDate;

        /// <summary>層別コード</summary>
        private string _partsLayerCd = "";

        /// <summary>部品情報制御フラグ</summary>
        /// <remarks>0:共通部品 1:SF.NS専用部品(PMからの検索は不可）</remarks>
        private Int32 _partsInfoCtrlFlg;

        /// <summary>部品名称</summary>
        private string _partsName = "";

        /// <summary>部品区分コード</summary>
        /// <remarks>作業部品区分マスタの区分コード</remarks>
        private Int32 _partsCode;

        /// <summary>部品検索区分</summary>
        /// <remarks>0:部品価格検索無し,1:通常部品価格検索,2:情報MTを検索</remarks>
        private Int32 _partsSearchCode;

        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>部品提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _priceOfferDate;

        /// <summary>メーカー提供部品カナ名称</summary>
        private string _makerOfferPartsKana;

        /// <summary>オープン価格区分</summary>
        private Int32 _openPriceDiv;

        /// public propaty name  :  CatalogPartsMakerCd
        /// <summary>カタログ部品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CatalogPartsMakerCd
        {
            get { return _catalogPartsMakerCd; }
            set { _catalogPartsMakerCd = value; }
        }

        /// public propaty name  :  OldPartsNoWithHyphen
        /// <summary>ハイフン付旧品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン付旧品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldPartsNoWithHyphen
        {
            get { return _oldPartsNoWithHyphen; }
            set { _oldPartsNoWithHyphen = value; }
        }

        /// public propaty name  :  NewPartsNoWithHyphen
        /// <summary>ハイフン付新品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン付新品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewPartsNoWithHyphen
        {
            get { return _newPartsNoWithHyphen; }
            set { _newPartsNoWithHyphen = value; }
        }

        /// public propaty name  :  NPrtNoWithHypnDspOdr
        /// <summary>ハイフン付新品番表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン付新品番表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NPrtNoWithHypnDspOdr
        {
            get { return _nPrtNoWithHypnDspOdr; }
            set { _nPrtNoWithHypnDspOdr = value; }
        }

        /// public propaty name  :  PartsPluralSubstFlg
        /// <summary>部品複数代替フラグプロパティ</summary>
        /// <value>0:複数代替なし 1:複数代替あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品複数代替フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsPluralSubstFlg
        {
            get { return _partsPluralSubstFlg; }
            set { _partsPluralSubstFlg = value; }
        }

        /// public propaty name  :  MainOrSubPartsDivCd
        /// <summary>メイン・サブ部品区分プロパティ</summary>
        /// <value>0:複数代替なし 1:メイン 2～:子</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メイン・サブ部品区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MainOrSubPartsDivCd
        {
            get { return _mainOrSubPartsDivCd; }
            set { _mainOrSubPartsDivCd = value; }
        }

        /// public propaty name  :  PartsQty
        /// <summary>部品QTYプロパティ</summary>
        /// <value>メイン・サブ部品区分が0以外の時に有効</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PartsQty
        {
            get { return _partsQty; }
            set { _partsQty = value; }
        }

        /// public propaty name  :  PartsPluralSubstCmnt
        /// <summary>部品複数代替摘要プロパティ</summary>
        /// <value>メイン・サブ部品区分が0以外の時に有効</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品複数代替摘要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsPluralSubstCmnt
        {
            get { return _partsPluralSubstCmnt; }
            set { _partsPluralSubstCmnt = value; }
        }

        /// public propaty name  :  PlrlSubNewPrtNoHypn
        /// <summary>複数代替元ハイフン付新品番プロパティ</summary>
        /// <value>メイン・サブ部品区分が0以外の時に有効</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   複数代替元ハイフン付新品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PlrlSubNewPrtNoHypn
        {
            get { return _plrlSubNewPrtNoHypn; }
            set { _plrlSubNewPrtNoHypn = value; }
        }

        /// public propaty name  :  NewPrtsNoNoneHyphen
        /// <summary>ハイフン無最新部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハイフン無最新部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewPrtsNoNoneHyphen
        {
            get { return _newPrtsNoNoneHyphen; }
            set { _newPrtsNoNoneHyphen = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>翼部品コードプロパティ</summary>
        /// <value>1～99999:提供分,100000～ユーザー登録用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼部品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>翼部品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   翼部品コード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  MakerOfferPartsName
        /// <summary>メーカー提供部品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー提供部品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerOfferPartsName
        {
            get { return _makerOfferPartsName; }
            set { _makerOfferPartsName = value; }
        }

        /// public propaty name  :  PartsPrice
        /// <summary>部品価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PartsPrice
        {
            get { return _partsPrice; }
            set { _partsPrice = value; }
        }

        /// public propaty name  :  PartsPriceStDate
        /// <summary>部品価格開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品価格開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PartsPriceStDate
        {
            get { return _partsPriceStDate; }
            set { _partsPriceStDate = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>層別コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
        }

        /// public propaty name  :  PartsInfoCtrlFlg
        /// <summary>部品情報制御フラグプロパティ</summary>
        /// <value>0:共通部品 1:SF.NS専用部品(PMからの検索は不可）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品情報制御フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsInfoCtrlFlg
        {
            get { return _partsInfoCtrlFlg; }
            set { _partsInfoCtrlFlg = value; }
        }

        /// public propaty name  :  PartsName
        /// <summary>部品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PartsName
        {
            get { return _partsName; }
            set { _partsName = value; }
        }

        /// public propaty name  :  PartsCode
        /// <summary>部品区分コードプロパティ</summary>
        /// <value>作業部品区分マスタの区分コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsCode
        {
            get { return _partsCode; }
            set { _partsCode = value; }
        }

        /// public propaty name  :  PartsSearchCode
        /// <summary>部品検索区分プロパティ</summary>
        /// <value>0:部品価格検索無し,1:通常部品価格検索,2:情報MTを検索</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsSearchCode
        {
            get { return _partsSearchCode; }
            set { _partsSearchCode = value; }
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

        /// public propaty name  :  PriceOfferDate
        /// <summary>価格提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime PriceOfferDate
        {
            get { return _priceOfferDate; }
            set { _priceOfferDate = value; }
        }

        /// public propaty name  :  MakerOfferPartsKana
        /// <summary>メーカー提供部品カナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   </br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerOfferPartsKana
        {
            get { return _makerOfferPartsKana; }
            set { _makerOfferPartsKana = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   </br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// <summary>
        /// 部品代替ワークコンストラクタ
        /// </summary>
        /// <returns>PartsSubstWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsSubstWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PartsSubstWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PartsSubstWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PartsSubstWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsSubstWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsSubstWork || graph is ArrayList || graph is PartsSubstWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PartsSubstWork).FullName));

            if (graph != null && graph is PartsSubstWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsSubstWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsSubstWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsSubstWork[])graph).Length;
            }
            else if (graph is PartsSubstWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //カタログ部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CatalogPartsMakerCd
            //ハイフン付旧品番
            serInfo.MemberInfo.Add(typeof(string)); //OldPartsNoWithHyphen
            //ハイフン付新品番
            serInfo.MemberInfo.Add(typeof(string)); //NewPartsNoWithHyphen
            //ハイフン付新品番表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //NPrtNoWithHypnDspOdr
            //部品複数代替フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsPluralSubstFlg
            //メイン・サブ部品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MainOrSubPartsDivCd
            //部品QTY
            serInfo.MemberInfo.Add(typeof(Double)); //PartsQty
            //部品複数代替摘要
            serInfo.MemberInfo.Add(typeof(string)); //PartsPluralSubstCmnt
            //複数代替元ハイフン付新品番
            serInfo.MemberInfo.Add(typeof(string)); //PlrlSubNewPrtNoHypn
            //ハイフン無最新部品品番
            serInfo.MemberInfo.Add(typeof(string)); //NewPrtsNoNoneHyphen
            //翼部品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //翼部品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //メーカー提供部品名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerOfferPartsName
            //部品価格
            serInfo.MemberInfo.Add(typeof(Int64)); //PartsPrice
            //部品価格開始日
            serInfo.MemberInfo.Add(typeof(Int64)); //PartsPriceStDate
            //層別コード
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //部品情報制御フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsInfoCtrlFlg
            //部品名称
            serInfo.MemberInfo.Add(typeof(string)); //PartsName
            //部品区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsCode
            //部品検索区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsSearchCode

            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceOfferDate

            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));

            serInfo.Serialize(writer, serInfo);
            if (graph is PartsSubstWork)
            {
                PartsSubstWork temp = (PartsSubstWork)graph;

                SetPartsSubstWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsSubstWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsSubstWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsSubstWork temp in lst)
                {
                    SetPartsSubstWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsSubstWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 24;

        /// <summary>
        ///  PartsSubstWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPartsSubstWork(System.IO.BinaryWriter writer, PartsSubstWork temp)
        {
            //カタログ部品メーカーコード
            writer.Write(temp.CatalogPartsMakerCd);
            //ハイフン付旧品番
            writer.Write(temp.OldPartsNoWithHyphen);
            //ハイフン付新品番
            writer.Write(temp.NewPartsNoWithHyphen);
            //ハイフン付新品番表示順位
            writer.Write(temp.NPrtNoWithHypnDspOdr);
            //部品複数代替フラグ
            writer.Write(temp.PartsPluralSubstFlg);
            //メイン・サブ部品区分
            writer.Write(temp.MainOrSubPartsDivCd);
            //部品QTY
            writer.Write(temp.PartsQty);
            //部品複数代替摘要
            writer.Write(temp.PartsPluralSubstCmnt);
            //複数代替元ハイフン付新品番
            writer.Write(temp.PlrlSubNewPrtNoHypn);
            //ハイフン無最新部品品番
            writer.Write(temp.NewPrtsNoNoneHyphen);
            //翼部品コード
            writer.Write(temp.TbsPartsCode);
            //翼部品コード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //メーカー提供部品名称
            writer.Write(temp.MakerOfferPartsName);
            //部品価格
            writer.Write(temp.PartsPrice);
            //部品価格開始日
            writer.Write((Int64)temp.PartsPriceStDate.Ticks);
            //層別コード
            writer.Write(temp.PartsLayerCd);
            //部品情報制御フラグ
            writer.Write(temp.PartsInfoCtrlFlg);
            //部品名称
            writer.Write(temp.PartsName);
            //部品区分コード
            writer.Write(temp.PartsCode);
            //部品検索区分
            writer.Write(temp.PartsSearchCode);
            writer.Write(temp.OfferDate.Ticks);
            writer.Write(temp.PriceOfferDate.Ticks);
            writer.Write(temp.MakerOfferPartsKana);
            writer.Write(temp.OpenPriceDiv);
        }

        /// <summary>
        ///  PartsSubstWorkインスタンス取得
        /// </summary>
        /// <returns>PartsSubstWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PartsSubstWork GetPartsSubstWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PartsSubstWork temp = new PartsSubstWork();

            //カタログ部品メーカーコード
            temp.CatalogPartsMakerCd = reader.ReadInt32();
            //ハイフン付旧品番
            temp.OldPartsNoWithHyphen = reader.ReadString();
            //ハイフン付新品番
            temp.NewPartsNoWithHyphen = reader.ReadString();
            //ハイフン付新品番表示順位
            temp.NPrtNoWithHypnDspOdr = reader.ReadInt32();
            //部品複数代替フラグ
            temp.PartsPluralSubstFlg = reader.ReadInt32();
            //メイン・サブ部品区分
            temp.MainOrSubPartsDivCd = reader.ReadInt32();
            //部品QTY
            temp.PartsQty = reader.ReadDouble();
            //部品複数代替摘要
            temp.PartsPluralSubstCmnt = reader.ReadString();
            //複数代替元ハイフン付新品番
            temp.PlrlSubNewPrtNoHypn = reader.ReadString();
            //ハイフン無最新部品品番
            temp.NewPrtsNoNoneHyphen = reader.ReadString();
            //翼部品コード
            temp.TbsPartsCode = reader.ReadInt32();
            //翼部品コード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //メーカー提供部品名称
            temp.MakerOfferPartsName = reader.ReadString();
            //部品価格
            temp.PartsPrice = reader.ReadInt64();
            //部品価格開始日
            temp.PartsPriceStDate = new DateTime(reader.ReadInt64());
            //層別コード
            temp.PartsLayerCd = reader.ReadString();
            //部品情報制御フラグ
            temp.PartsInfoCtrlFlg = reader.ReadInt32();
            //部品名称
            temp.PartsName = reader.ReadString();
            //部品区分コード
            temp.PartsCode = reader.ReadInt32();
            //部品検索区分
            temp.PartsSearchCode = reader.ReadInt32();

            temp.OfferDate = new DateTime(reader.ReadInt64());
            temp.PriceOfferDate = new DateTime(reader.ReadInt64());

            temp.MakerOfferPartsKana = reader.ReadString();
            temp.OpenPriceDiv = reader.ReadInt32();

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
        /// <returns>PartsSubstWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsSubstWork temp = GetPartsSubstWork(reader, serInfo);
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
                    retValue = (PartsSubstWork[])lst.ToArray(typeof(PartsSubstWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferSetPartsRetWork
    /// <summary>
    ///                      提供セット抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供セット抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      : 2009/11/24　21024 佐々木 健</br>
    /// <br>                 : プロパティに下記項目を追加(MANTIS[0013603])</br>
    /// <br>                 : ・優良部品BLコード(PrmPrtTbsPrtCd)</br>
    /// <br>                 : ・優良部品BLコード枝番(PrmPrtTbsPrtCdDerivNo)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferSetPartsRetWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BLコード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>セット親メーカーコード</summary>
        private Int32 _setMainMakerCd;

        /// <summary>セット親品番</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _setMainPartsNo = "";

        /// <summary>セット子メーカーコード</summary>
        private Int32 _setSubMakerCd;

        /// <summary>セット子品番</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _setSubPartsNo = "";

        /// <summary>セット表示順位</summary>
        private Int32 _setDispOrder;

        /// <summary>セットQTY</summary>
        private Double _setQty;

        /// <summary>セット名称</summary>
        private string _setName = "";

        /// <summary>セット規格・特記事項</summary>
        private string _setSpecialNote = "";

        /// <summary>カタログ図番</summary>
        private string _catalogShapeNo = "";

        /// <summary>優良部品名称</summary>
        /// <remarks>全角</remarks>
        private string _primePartsName = "";

        /// <summary>優良部品カナ名称</summary>
        /// <remarks>半角カナ</remarks>
        private string _primePartsKanaName = "";

        /// <summary>層別コード</summary>
        /// <remarks>掛率設定で使用する</remarks>
        private string _partsLayerCd = "";

        /// <summary>優良部品規格・特記事項</summary>
        private string _primePartsSpecialNote = "";

        /// <summary>部品属性</summary>
        /// <remarks>0:純正 や優良、用品などを区別するための属性</remarks>
        private Int32 _partsAttribute;

        /// <summary>カタログ削除フラグ</summary>
        private Int32 _catalogDeleteFlag;

        /// <summary>優良部品イラストコード</summary>
        private string _prmPartsIllustC = "";

        /// <summary>代替区分</summary>
        /// <remarks>1:代替</remarks>
        private Int32 _substKubun;

        /// <summary>検索品名（全角）</summary>
        private string _searchPartsFullName = "";

        /// <summary>検索品名（半角）</summary>
        private string _searchPartsHalfName = "";

        // 2009/11/24 Add >>>
        /// <summary>優良部品BLコード</summary>
        private Int32 _prmPrtTbsPrtCd;

        /// <summary>優良部品BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _prmPrtTbsPrtCdDerivNo;
        // 2009/11/24 Add <<<


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

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>※中分類</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BLコード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  SetMainMakerCd
        /// <summary>セット親メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット親メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetMainMakerCd
        {
            get { return _setMainMakerCd; }
            set { _setMainMakerCd = value; }
        }

        /// public propaty name  :  SetMainPartsNo
        /// <summary>セット親品番プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット親品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetMainPartsNo
        {
            get { return _setMainPartsNo; }
            set { _setMainPartsNo = value; }
        }

        /// public propaty name  :  SetSubMakerCd
        /// <summary>セット子メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット子メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetSubMakerCd
        {
            get { return _setSubMakerCd; }
            set { _setSubMakerCd = value; }
        }

        /// public propaty name  :  SetSubPartsNo
        /// <summary>セット子品番プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット子品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetSubPartsNo
        {
            get { return _setSubPartsNo; }
            set { _setSubPartsNo = value; }
        }

        /// public propaty name  :  SetDispOrder
        /// <summary>セット表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetDispOrder
        {
            get { return _setDispOrder; }
            set { _setDispOrder = value; }
        }

        /// public propaty name  :  SetQty
        /// <summary>セットQTYプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セットQTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SetQty
        {
            get { return _setQty; }
            set { _setQty = value; }
        }

        /// public propaty name  :  SetName
        /// <summary>セット名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetName
        {
            get { return _setName; }
            set { _setName = value; }
        }

        /// public propaty name  :  SetSpecialNote
        /// <summary>セット規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetSpecialNote
        {
            get { return _setSpecialNote; }
            set { _setSpecialNote = value; }
        }

        /// public propaty name  :  CatalogShapeNo
        /// <summary>カタログ図番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ図番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CatalogShapeNo
        {
            get { return _catalogShapeNo; }
            set { _catalogShapeNo = value; }
        }

        /// public propaty name  :  PrimePartsName
        /// <summary>優良部品名称プロパティ</summary>
        /// <value>全角</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsName
        {
            get { return _primePartsName; }
            set { _primePartsName = value; }
        }

        /// public propaty name  :  PrimePartsKanaName
        /// <summary>優良部品カナ名称プロパティ</summary>
        /// <value>半角カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品カナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsKanaName
        {
            get { return _primePartsKanaName; }
            set { _primePartsKanaName = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>層別コードプロパティ</summary>
        /// <value>掛率設定で使用する</value>
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

        /// public propaty name  :  PrimePartsSpecialNote
        /// <summary>優良部品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsSpecialNote
        {
            get { return _primePartsSpecialNote; }
            set { _primePartsSpecialNote = value; }
        }

        /// public propaty name  :  PartsAttribute
        /// <summary>部品属性プロパティ</summary>
        /// <value>0:純正 や優良、用品などを区別するための属性</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品属性プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsAttribute
        {
            get { return _partsAttribute; }
            set { _partsAttribute = value; }
        }

        /// public propaty name  :  CatalogDeleteFlag
        /// <summary>カタログ削除フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ削除フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CatalogDeleteFlag
        {
            get { return _catalogDeleteFlag; }
            set { _catalogDeleteFlag = value; }
        }

        /// public propaty name  :  PrmPartsIllustC
        /// <summary>優良部品イラストコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品イラストコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrmPartsIllustC
        {
            get { return _prmPartsIllustC; }
            set { _prmPartsIllustC = value; }
        }

        /// public propaty name  :  SubstKubun
        /// <summary>代替区分プロパティ</summary>
        /// <value>1:代替</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代替区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubstKubun
        {
            get { return _substKubun; }
            set { _substKubun = value; }
        }

        /// public propaty name  :  SearchPartsFullName
        /// <summary>検索品名（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索品名（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchPartsFullName
        {
            get { return _searchPartsFullName; }
            set { _searchPartsFullName = value; }
        }

        /// public propaty name  :  SearchPartsHalfName
        /// <summary>検索品名（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索品名（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchPartsHalfName
        {
            get { return _searchPartsHalfName; }
            set { _searchPartsHalfName = value; }
        }

        // 2009/11/24 Add >>>
        /// public propaty name  :  PrmPrtTbsPrtCd
        /// <summary>優良部品BLコードプロパティ</summary>
        /// <value>YYYYMMDD</value>
        public Int32 PrmPrtTbsPrtCd
        {
            get { return _prmPrtTbsPrtCd; }
            set { _prmPrtTbsPrtCd = value; }
        }

        /// public propaty name  :  PrmPrtTbsPrtCdDerivNo
        /// <summary>優良部品BLコード枝番プロパティ</summary>
        /// <value>※未使用項目（レイアウトには入れておく）</value>
        public Int32 PrmPrtTbsPrtCdDerivNo
        {
            get { return _prmPrtTbsPrtCdDerivNo; }
            set { _prmPrtTbsPrtCdDerivNo = value; }
        }
        // 2009/11/24 Add <<<

        /// <summary>
        /// 提供セット抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>OfferSetPartsRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferSetPartsRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfferSetPartsRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OfferSetPartsRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OfferSetPartsRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br></br>
    /// <br>Update Note      : 2009/11/24　21024 佐々木 健</br>
    /// <br>                 : プロパティに下記項目を追加(MANTIS[0013603])</br>
    /// <br>                 : ・優良部品BLコード(PrmPrtTbsPrtCd)</br>
    /// <br>                 : ・優良部品BLコード枝番(PrmPrtTbsPrtCdDerivNo)</br>    
    /// </remarks>
    public class OfferSetPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferSetPartsRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfferSetPartsRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfferSetPartsRetWork || graph is ArrayList || graph is OfferSetPartsRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OfferSetPartsRetWork).FullName));

            if (graph != null && graph is OfferSetPartsRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfferSetPartsRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfferSetPartsRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfferSetPartsRetWork[])graph).Length;
            }
            else if (graph is OfferSetPartsRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //BLコード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //セット親メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SetMainMakerCd
            //セット親品番
            serInfo.MemberInfo.Add(typeof(string)); //SetMainPartsNo
            //セット子メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SetSubMakerCd
            //セット子品番
            serInfo.MemberInfo.Add(typeof(string)); //SetSubPartsNo
            //セット表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //SetDispOrder
            //セットQTY
            serInfo.MemberInfo.Add(typeof(Double)); //SetQty
            //セット名称
            serInfo.MemberInfo.Add(typeof(string)); //SetName
            //セット規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //SetSpecialNote
            //カタログ図番
            serInfo.MemberInfo.Add(typeof(string)); //CatalogShapeNo
            //優良部品名称
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsName
            //優良部品カナ名称
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsKanaName
            //層別コード
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //優良部品規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsSpecialNote
            //部品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsAttribute
            //カタログ削除フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //CatalogDeleteFlag
            //優良部品イラストコード
            serInfo.MemberInfo.Add(typeof(string)); //PrmPartsIllustC
            //代替区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SubstKubun
            //検索品名（全角）
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsFullName
            //検索品名（半角）
            serInfo.MemberInfo.Add(typeof(string)); //SearchPartsHalfName
            // 2009/11/24 Add >>>
            // 優良部品BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmPrtTbsPrtCd
            // 優良部品BLコード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmPrtTbsPrtCdDerivNo
            // 2009/11/24 Add <<<


            serInfo.Serialize(writer, serInfo);
            if (graph is OfferSetPartsRetWork)
            {
                OfferSetPartsRetWork temp = (OfferSetPartsRetWork)graph;

                SetOfferSetPartsRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfferSetPartsRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfferSetPartsRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfferSetPartsRetWork temp in lst)
                {
                    SetOfferSetPartsRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfferSetPartsRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        // 2009/11/24 >>>
        //private const int currentMemberCount = 23;
        private const int currentMemberCount = 25;
        // 2009/11/24 <<<

        /// <summary>
        ///  OfferSetPartsRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferSetPartsRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOfferSetPartsRetWork(System.IO.BinaryWriter writer, OfferSetPartsRetWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate.Ticks);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //BLコード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //セット親メーカーコード
            writer.Write(temp.SetMainMakerCd);
            //セット親品番
            writer.Write(temp.SetMainPartsNo);
            //セット子メーカーコード
            writer.Write(temp.SetSubMakerCd);
            //セット子品番
            writer.Write(temp.SetSubPartsNo);
            //セット表示順位
            writer.Write(temp.SetDispOrder);
            //セットQTY
            writer.Write(temp.SetQty);
            //セット名称
            writer.Write(temp.SetName);
            //セット規格・特記事項
            writer.Write(temp.SetSpecialNote);
            //カタログ図番
            writer.Write(temp.CatalogShapeNo);
            //優良部品名称
            writer.Write(temp.PrimePartsName);
            //優良部品カナ名称
            writer.Write(temp.PrimePartsKanaName);
            //層別コード
            writer.Write(temp.PartsLayerCd);
            //優良部品規格・特記事項
            writer.Write(temp.PrimePartsSpecialNote);
            //部品属性
            writer.Write(temp.PartsAttribute);
            //カタログ削除フラグ
            writer.Write(temp.CatalogDeleteFlag);
            //優良部品イラストコード
            writer.Write(temp.PrmPartsIllustC);
            //代替区分
            writer.Write(temp.SubstKubun);
            //検索品名（全角）
            writer.Write(temp.SearchPartsFullName);
            //検索品名（半角）
            writer.Write(temp.SearchPartsHalfName);
            // 2009/11/24 Add >>>
            //優良部品BLコード
            writer.Write(temp.PrmPrtTbsPrtCd);
            //優良部品BLコード枝番
            writer.Write(temp.PrmPrtTbsPrtCdDerivNo);
            // 2009/11/24 Add <<<
        }

        /// <summary>
        ///  OfferSetPartsRetWorkインスタンス取得
        /// </summary>
        /// <returns>OfferSetPartsRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferSetPartsRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OfferSetPartsRetWork GetOfferSetPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OfferSetPartsRetWork temp = new OfferSetPartsRetWork();

            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //BLコード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //セット親メーカーコード
            temp.SetMainMakerCd = reader.ReadInt32();
            //セット親品番
            temp.SetMainPartsNo = reader.ReadString();
            //セット子メーカーコード
            temp.SetSubMakerCd = reader.ReadInt32();
            //セット子品番
            temp.SetSubPartsNo = reader.ReadString();
            //セット表示順位
            temp.SetDispOrder = reader.ReadInt32();
            //セットQTY
            temp.SetQty = reader.ReadDouble();
            //セット名称
            temp.SetName = reader.ReadString();
            //セット規格・特記事項
            temp.SetSpecialNote = reader.ReadString();
            //カタログ図番
            temp.CatalogShapeNo = reader.ReadString();
            //優良部品名称
            temp.PrimePartsName = reader.ReadString();
            //優良部品カナ名称
            temp.PrimePartsKanaName = reader.ReadString();
            //層別コード
            temp.PartsLayerCd = reader.ReadString();
            //優良部品規格・特記事項
            temp.PrimePartsSpecialNote = reader.ReadString();
            //部品属性
            temp.PartsAttribute = reader.ReadInt32();
            //カタログ削除フラグ
            temp.CatalogDeleteFlag = reader.ReadInt32();
            //優良部品イラストコード
            temp.PrmPartsIllustC = reader.ReadString();
            //代替区分
            temp.SubstKubun = reader.ReadInt32();
            //検索品名（全角）
            temp.SearchPartsFullName = reader.ReadString();
            //検索品名（半角）
            temp.SearchPartsHalfName = reader.ReadString();
            // 2009/11/24 Add >>>
            //優良部品BLコード
            temp.PrmPrtTbsPrtCd = reader.ReadInt32();
            //優良部品BLコード枝番
            temp.PrmPrtTbsPrtCdDerivNo = reader.ReadInt32();
            // 2009/11/24 Add <<<

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
        /// <returns>OfferSetPartsRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferSetPartsRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfferSetPartsRetWork temp = GetOfferSetPartsRetWork(reader, serInfo);
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
                    retValue = (OfferSetPartsRetWork[])lst.ToArray(typeof(OfferSetPartsRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

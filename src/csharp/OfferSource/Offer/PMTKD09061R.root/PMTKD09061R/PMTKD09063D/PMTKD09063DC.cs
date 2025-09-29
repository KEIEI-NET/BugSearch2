using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   OfferJoinPartsRetWork
    /// <summary>
    ///                      提供結合抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供結合抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class OfferJoinPartsRetWork
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

        /// <summary>優良設定詳細コード１</summary>
        /// <remarks>※セレクトコード</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>優良設定詳細コード２</summary>
        /// <remarks>※種別コード</remarks>
        private Int32 _prmSetDtlNo2;

        /// <summary>結合表示順位</summary>
        /// <remarks>2,3,5,6,8,9が同一の結合が複数存在する場合の連番</remarks>
        private Int32 _joinDispOrder;

        /// <summary>結合元メーカーコード</summary>
        private Int32 _joinSourceMakerCode;

        /// <summary>結合元品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinSourPartsNoWithH = "";

        /// <summary>結合元品番(－無し品番)</summary>
        private string _joinSourPartsNoNoneH = "";

        /// <summary>結合先メーカーコード</summary>
        private Int32 _joinDestMakerCd;

        /// <summary>結合先品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _joinDestPartsNo = "";

        /// <summary>結合QTY</summary>
        private Double _joinQty;

        /// <summary>セット品番フラグ</summary>
        /// <remarks>0:セット品無し　1:セット品有り</remarks>
        private Int32 _setPartsFlg;

        /// <summary>結合規格・特記事項</summary>
        private string _joinSpecialNote = "";

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

        /// public propaty name  :  PrmSetDtlNo1
        /// <summary>優良設定詳細コード１プロパティ</summary>
        /// <value>※セレクトコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo1
        {
            get { return _prmSetDtlNo1; }
            set { _prmSetDtlNo1 = value; }
        }

        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// <value>※種別コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  JoinDispOrder
        /// <summary>結合表示順位プロパティ</summary>
        /// <value>2,3,5,6,8,9が同一の結合が複数存在する場合の連番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDispOrder
        {
            get { return _joinDispOrder; }
            set { _joinDispOrder = value; }
        }

        /// public propaty name  :  JoinSourceMakerCode
        /// <summary>結合元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinSourceMakerCode
        {
            get { return _joinSourceMakerCode; }
            set { _joinSourceMakerCode = value; }
        }

        /// public propaty name  :  JoinSourPartsNoWithH
        /// <summary>結合元品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoWithH
        {
            get { return _joinSourPartsNoWithH; }
            set { _joinSourPartsNoWithH = value; }
        }

        /// public propaty name  :  JoinSourPartsNoNoneH
        /// <summary>結合元品番(－無し品番)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合元品番(－無し品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSourPartsNoNoneH
        {
            get { return _joinSourPartsNoNoneH; }
            set { _joinSourPartsNoNoneH = value; }
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
            get { return _joinDestMakerCd; }
            set { _joinDestMakerCd = value; }
        }

        /// public propaty name  :  JoinDestPartsNo
        /// <summary>結合先品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合先品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinDestPartsNo
        {
            get { return _joinDestPartsNo; }
            set { _joinDestPartsNo = value; }
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
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  SetPartsFlg
        /// <summary>セット品番フラグプロパティ</summary>
        /// <value>0:セット品無し　1:セット品有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット品番フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SetPartsFlg
        {
            get { return _setPartsFlg; }
            set { _setPartsFlg = value; }
        }

        /// public propaty name  :  JoinSpecialNote
        /// <summary>結合規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JoinSpecialNote
        {
            get { return _joinSpecialNote; }
            set { _joinSpecialNote = value; }
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


        /// <summary>
        /// 提供結合抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>OfferJoinPartsRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferJoinPartsRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfferJoinPartsRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>OfferJoinPartsRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   OfferJoinPartsRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class OfferJoinPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferJoinPartsRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  OfferJoinPartsRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is OfferJoinPartsRetWork || graph is ArrayList || graph is OfferJoinPartsRetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(OfferJoinPartsRetWork).FullName));

            if (graph != null && graph is OfferJoinPartsRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.OfferJoinPartsRetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is OfferJoinPartsRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((OfferJoinPartsRetWork[])graph).Length;
            }
            else if (graph is OfferJoinPartsRetWork)
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
            //優良設定詳細コード１
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo1
            //優良設定詳細コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //結合表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDispOrder
            //結合元メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinSourceMakerCode
            //結合元品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoWithH
            //結合元品番(－無し品番)
            serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoNoneH
            //結合先メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDestMakerCd
            //結合先品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //JoinDestPartsNo
            //結合QTY
            serInfo.MemberInfo.Add(typeof(Double)); //JoinQty
            //セット品番フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPartsFlg
            //結合規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //JoinSpecialNote
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


            serInfo.Serialize(writer, serInfo);
            if (graph is OfferJoinPartsRetWork)
            {
                OfferJoinPartsRetWork temp = (OfferJoinPartsRetWork)graph;

                SetOfferJoinPartsRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is OfferJoinPartsRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((OfferJoinPartsRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (OfferJoinPartsRetWork temp in lst)
                {
                    SetOfferJoinPartsRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// OfferJoinPartsRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 25;

        /// <summary>
        ///  OfferJoinPartsRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferJoinPartsRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetOfferJoinPartsRetWork(System.IO.BinaryWriter writer, OfferJoinPartsRetWork temp)
        {
            //提供日付
            writer.Write(temp.OfferDate.Ticks);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //BLコード
            writer.Write(temp.TbsPartsCode);
            //BLコード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //優良設定詳細コード１
            writer.Write(temp.PrmSetDtlNo1);
            //優良設定詳細コード２
            writer.Write(temp.PrmSetDtlNo2);
            //結合表示順位
            writer.Write(temp.JoinDispOrder);
            //結合元メーカーコード
            writer.Write(temp.JoinSourceMakerCode);
            //結合元品番(－付き品番)
            writer.Write(temp.JoinSourPartsNoWithH);
            //結合元品番(－無し品番)
            writer.Write(temp.JoinSourPartsNoNoneH);
            //結合先メーカーコード
            writer.Write(temp.JoinDestMakerCd);
            //結合先品番(－付き品番)
            writer.Write(temp.JoinDestPartsNo);
            //結合QTY
            writer.Write(temp.JoinQty);
            //セット品番フラグ
            writer.Write(temp.SetPartsFlg);
            //結合規格・特記事項
            writer.Write(temp.JoinSpecialNote);
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

        }

        /// <summary>
        ///  OfferJoinPartsRetWorkインスタンス取得
        /// </summary>
        /// <returns>OfferJoinPartsRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferJoinPartsRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private OfferJoinPartsRetWork GetOfferJoinPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            OfferJoinPartsRetWork temp = new OfferJoinPartsRetWork();

            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //BLコード
            temp.TbsPartsCode = reader.ReadInt32();
            //BLコード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //優良設定詳細コード１
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //優良設定詳細コード２
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            //結合表示順位
            temp.JoinDispOrder = reader.ReadInt32();
            //結合元メーカーコード
            temp.JoinSourceMakerCode = reader.ReadInt32();
            //結合元品番(－付き品番)
            temp.JoinSourPartsNoWithH = reader.ReadString();
            //結合元品番(－無し品番)
            temp.JoinSourPartsNoNoneH = reader.ReadString();
            //結合先メーカーコード
            temp.JoinDestMakerCd = reader.ReadInt32();
            //結合先品番(－付き品番)
            temp.JoinDestPartsNo = reader.ReadString();
            //結合QTY
            temp.JoinQty = reader.ReadDouble();
            //セット品番フラグ
            temp.SetPartsFlg = reader.ReadInt32();
            //結合規格・特記事項
            temp.JoinSpecialNote = reader.ReadString();
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
        /// <returns>OfferJoinPartsRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfferJoinPartsRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                OfferJoinPartsRetWork temp = GetOfferJoinPartsRetWork(reader, serInfo);
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
                    retValue = (OfferJoinPartsRetWork[])lst.ToArray(typeof(OfferJoinPartsRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

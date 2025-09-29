//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良部品バーコード情報抽出リモート
// プログラム概要   : 優良部品バーコード情報抽出結果ワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RettPrmPartsBrcdInfoWork
    /// <summary>
    ///                      優良部品バーコード情報抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良部品バーコード情報抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/09/20</br>
    /// <br>Genarated Date   :   2017/09/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RettPrmPartsBrcdInfoWork
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BLコード</summary>
        /// <remarks>曖昧検索で優良設定マスタをチェック</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>BLコード枝番</summary>
        /// <remarks>※未使用項目（レイアウトには入れておく）</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>優良設定詳細コード１</summary>
        /// <remarks>曖昧検索で優良設定マスタをチェック</remarks>
        private Int32 _prmSetDtlNo1;

        /// <summary>部品メーカーコード</summary>
        /// <remarks>曖昧検索で優良設定マスタをチェック</remarks>
        private Int32 _partsMakerCd;

        /// <summary>優良品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _primePartsNoWithH = "";

        /// <summary>優良品番(－無し品番)</summary>
        /// <remarks>ハイフン無し</remarks>
        private string _primePartsNoNoneH = "";

        /// <summary>優良品名</summary>
        /// <remarks>全角</remarks>
        private string _primePartsName = "";

        /// <summary>優良部品カナ名称</summary>
        /// <remarks>半角カナ</remarks>
        private string _primePartsKanaNm = "";

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

        /// <summary>バーコード提供日時</summary>
        private Int32 _barcodeOfferDate;

        /// <summary>部品バーコード種別</summary>
        /// <remarks>0:JAN/EAUコード(13桁),1:JAN/EAUコード(8桁),2:UPCコード1(A12桁),3:UPCコード1(E8桁),4:CODE39コード,5:CODE128コード,6:ITFコード,7:NW-7コード</remarks>
        private Int16 _primePrtsBarCdKndDiv;

        /// <summary>部品バーコード情報</summary>
        private string _primePartsBarCode = "";


        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDate
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BLコードプロパティ</summary>
        /// <value>曖昧検索で優良設定マスタをチェック</value>
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
        /// <value>曖昧検索で優良設定マスタをチェック</value>
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

        /// public propaty name  :  PartsMakerCd
        /// <summary>部品メーカーコードプロパティ</summary>
        /// <value>曖昧検索で優良設定マスタをチェック</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsMakerCd
        {
            get { return _partsMakerCd; }
            set { _partsMakerCd = value; }
        }

        /// public propaty name  :  PrimePartsNoWithH
        /// <summary>優良品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsNoWithH
        {
            get { return _primePartsNoWithH; }
            set { _primePartsNoWithH = value; }
        }

        /// public propaty name  :  PrimePartsNoNoneH
        /// <summary>優良品番(－無し品番)プロパティ</summary>
        /// <value>ハイフン無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良品番(－無し品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsNoNoneH
        {
            get { return _primePartsNoNoneH; }
            set { _primePartsNoNoneH = value; }
        }

        /// public propaty name  :  PrimePartsName
        /// <summary>優良品名プロパティ</summary>
        /// <value>全角</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良品名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsName
        {
            get { return _primePartsName; }
            set { _primePartsName = value; }
        }

        /// public propaty name  :  PrimePartsKanaNm
        /// <summary>優良部品カナ名称プロパティ</summary>
        /// <value>半角カナ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良部品カナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsKanaNm
        {
            get { return _primePartsKanaNm; }
            set { _primePartsKanaNm = value; }
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

        /// public propaty name  :  BarcodeOfferDate
        /// <summary>バーコード提供日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バーコード提供日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BarcodeOfferDate
        {
            get { return _barcodeOfferDate; }
            set { _barcodeOfferDate = value; }
        }

        /// public propaty name  :  PrimePrtsBarCdKndDiv
        /// <summary>部品バーコード種別プロパティ</summary>
        /// <value>0:JAN/EAUコード(13桁),1:JAN/EAUコード(8桁),2:UPCコード1(A12桁),3:UPCコード1(E8桁),4:CODE39コード,5:CODE128コード,6:ITFコード,7:NW-7コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品バーコード種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 PrimePrtsBarCdKndDiv
        {
            get { return _primePrtsBarCdKndDiv; }
            set { _primePrtsBarCdKndDiv = value; }
        }

        /// public propaty name  :  PrimePartsBarCode
        /// <summary>部品バーコード情報プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品バーコード情報プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsBarCode
        {
            get { return _primePartsBarCode; }
            set { _primePartsBarCode = value; }
        }


        /// <summary>
        /// 優良部品バーコード情報抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>RettPrmPartsWidthBrcdInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RettPrmPartsWidthBrcdInfoWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RettPrmPartsBrcdInfoWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RettPrmPartsBrcdInfoWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RettPrmPartsBrcdInfoWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RettPrmPartsBrcdInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RettPrmPartsBrcdInfoWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  RettPrmPartsBrcdInfoWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !( graph is RettPrmPartsBrcdInfoWork || graph is ArrayList || graph is RettPrmPartsBrcdInfoWork[] ))
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( RettPrmPartsBrcdInfoWork ).FullName ) );

            if (graph != null && graph is RettPrmPartsBrcdInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization( t ))
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RettPrmPartsBrcdInfoWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ( (ArrayList)graph ).Count;
            }
            else if (graph is RettPrmPartsBrcdInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ( (RettPrmPartsBrcdInfoWork[])graph ).Length;
            }
            else if (graph is RettPrmPartsBrcdInfoWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //OfferDate
            //商品中分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMGroup
            //翼部品コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TbsPartsCode
            //翼部品コード枝番
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TbsPartsCdDerivedNo
            //優良設定詳細コード１
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //PrmSetDtlNo1
            //部品メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //PartsMakerCd
            //優良品番(－付き品番)
            serInfo.MemberInfo.Add( typeof( string ) ); //PrimePartsNoWithH
            //優良品番(－無し品番)
            serInfo.MemberInfo.Add( typeof( string ) ); //PrimePartsNoNoneH
            //優良品名
            serInfo.MemberInfo.Add( typeof( string ) ); //PrimePartsName
            //優良部品カナ名称
            serInfo.MemberInfo.Add( typeof( string ) ); //PrimePartsKanaNm
            //層別コード
            serInfo.MemberInfo.Add( typeof( string ) ); //PartsLayerCd
            //優良部品規格・特記事項
            serInfo.MemberInfo.Add( typeof( string ) ); //PrimePartsSpecialNote
            //部品属性
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //PartsAttribute
            //カタログ削除フラグ
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CatalogDeleteFlag
            //優良部品イラストコード
            serInfo.MemberInfo.Add( typeof( string ) ); //PrmPartsIllustC
            //バーコード提供日時
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BarcodeOfferDate
            //部品バーコード種別
            serInfo.MemberInfo.Add( typeof( Int16 ) ); //PrimePrtsBarCdKndDiv
            //部品バーコード情報
            serInfo.MemberInfo.Add( typeof( string ) ); //PrimePartsBarCode


            serInfo.Serialize( writer, serInfo );
            if (graph is RettPrmPartsBrcdInfoWork)
            {
                RettPrmPartsBrcdInfoWork temp = (RettPrmPartsBrcdInfoWork)graph;

                SetRettPrmPartsBrcdInfoWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if (graph is RettPrmPartsBrcdInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange( (RettPrmPartsBrcdInfoWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RettPrmPartsBrcdInfoWork temp in lst)
                {
                    SetRettPrmPartsBrcdInfoWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// RettPrmPartsBrcdInfoWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  RettPrmPartsBrcdInfoWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RettPrmPartsBrcdInfoWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRettPrmPartsBrcdInfoWork( System.IO.BinaryWriter writer, RettPrmPartsBrcdInfoWork temp )
        {
            //提供日付
            writer.Write( temp.OfferDate );
            //商品中分類コード
            writer.Write( temp.GoodsMGroup );
            //翼部品コード
            writer.Write( temp.TbsPartsCode );
            //翼部品コード枝番
            writer.Write( temp.TbsPartsCdDerivedNo );
            //優良設定詳細コード１
            writer.Write( temp.PrmSetDtlNo1 );
            //部品メーカーコード
            writer.Write( temp.PartsMakerCd );
            //優良品番(－付き品番)
            writer.Write( temp.PrimePartsNoWithH );
            //優良品番(－無し品番)
            writer.Write( temp.PrimePartsNoNoneH );
            //優良品名
            writer.Write( temp.PrimePartsName );
            //優良部品カナ名称
            writer.Write( temp.PrimePartsKanaNm );
            //層別コード
            writer.Write( temp.PartsLayerCd );
            //優良部品規格・特記事項
            writer.Write( temp.PrimePartsSpecialNote );
            //部品属性
            writer.Write( temp.PartsAttribute );
            //カタログ削除フラグ
            writer.Write( temp.CatalogDeleteFlag );
            //優良部品イラストコード
            writer.Write( temp.PrmPartsIllustC );
            //バーコード提供日時
            writer.Write( temp.BarcodeOfferDate );
            //部品バーコード種別
            writer.Write( temp.PrimePrtsBarCdKndDiv );
            //部品バーコード情報
            writer.Write( temp.PrimePartsBarCode );

        }

        /// <summary>
        ///  RettPrmPartsBrcdInfoWorkインスタンス取得
        /// </summary>
        /// <returns>RettPrmPartsBrcdInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RettPrmPartsBrcdInfoWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RettPrmPartsBrcdInfoWork GetRettPrmPartsBrcdInfoWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RettPrmPartsBrcdInfoWork temp = new RettPrmPartsBrcdInfoWork();

            //提供日付
            temp.OfferDate = reader.ReadInt32();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //翼部品コード
            temp.TbsPartsCode = reader.ReadInt32();
            //翼部品コード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //優良設定詳細コード１
            temp.PrmSetDtlNo1 = reader.ReadInt32();
            //部品メーカーコード
            temp.PartsMakerCd = reader.ReadInt32();
            //優良品番(－付き品番)
            temp.PrimePartsNoWithH = reader.ReadString();
            //優良品番(－無し品番)
            temp.PrimePartsNoNoneH = reader.ReadString();
            //優良品名
            temp.PrimePartsName = reader.ReadString();
            //優良部品カナ名称
            temp.PrimePartsKanaNm = reader.ReadString();
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
            //バーコード提供日時
            temp.BarcodeOfferDate = reader.ReadInt32();
            //部品バーコード種別
            temp.PrimePrtsBarCdKndDiv = reader.ReadInt16();
            //部品バーコード情報
            temp.PrimePartsBarCode = reader.ReadString();


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
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if (t.Equals( typeof( int ) ))
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
                    object userData = formatter.Deserialize( reader );  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>RettPrmPartsBrcdInfoWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RettPrmPartsBrcdInfoWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RettPrmPartsBrcdInfoWork temp = GetRettPrmPartsBrcdInfoWork( reader, serInfo );
                lst.Add( temp );
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
                    retValue = (RettPrmPartsBrcdInfoWork[])lst.ToArray( typeof( RettPrmPartsBrcdInfoWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockAdjRefSearchParaWork
    /// <summary>
    ///                      在庫仕入伝票照会抽出条件ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫仕入伝票照会抽出条件ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/08/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockAdjRefSearchParaWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>受払元伝票区分</summary>
        /// <remarks>10:仕入,11:受託,12:受計上,13:在庫仕入,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>受払元取引区分</summary>
        /// <remarks>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</remarks>
        private Int32 _acPayTransCd;

        /// <summary>開始入力日付</summary>
        /// <remarks>入力日</remarks>
        private Int32 _st_InputDay;

        /// <summary>終了入力日付</summary>
        /// <remarks>入力日</remarks>
        private Int32 _ed_InputDay;

        /// <summary>開始調整日付</summary>
        /// <remarks>作成日</remarks>
        private Int32 _st_AdjustDate;

        /// <summary>終了調整日付</summary>
        /// <remarks>作成日</remarks>
        private Int32 _ed_AdjustDate;

        /// <summary>開始在庫調整伝票番号</summary>
        /// <remarks>伝票番号</remarks>
        private Int32 _st_StockAdjustSlipNo;

        /// <summary>終了在庫調整伝票番号</summary>
        /// <remarks>伝票番号</remarks>
        private Int32 _ed_StockAdjustSlipNo;

        /// <summary>仕入担当者コード</summary>
        /// <remarks>担当者</remarks>
        private string _stockAgentCode = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品番号検索タイプ</summary>
        /// <remarks>0:完全一致、1:前方一致、2:後方一致、3:あいまい</remarks>
        private Int32 _goodsNoTyp;

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>商品名称検索タイプ</summary>
        /// <remarks>0:完全一致、1:前方一致、2:後方一致、3:あいまい</remarks>
        private Int32 _goodsNameTyp;

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>倉庫棚番検索タイプ</summary>
        /// <remarks>0:完全一致、1:前方一致、2:後方一致、3:あいまい</remarks>
        private Int32 _warehouseShelfNoTyp;


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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  AcPaySlipCd
        /// <summary>受払元伝票区分プロパティ</summary>
        /// <value>10:仕入,11:受託,12:受計上,13:在庫仕入,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払元伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcPaySlipCd
        {
            get { return _acPaySlipCd; }
            set { _acPaySlipCd = value; }
        }

        /// public propaty name  :  AcPayTransCd
        /// <summary>受払元取引区分プロパティ</summary>
        /// <value>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払元取引区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcPayTransCd
        {
            get { return _acPayTransCd; }
            set { _acPayTransCd = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>開始入力日付プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>終了入力日付プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }

        /// public propaty name  :  St_AdjustDate
        /// <summary>開始調整日付プロパティ</summary>
        /// <value>作成日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始調整日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_AdjustDate
        {
            get { return _st_AdjustDate; }
            set { _st_AdjustDate = value; }
        }

        /// public propaty name  :  Ed_AdjustDate
        /// <summary>終了調整日付プロパティ</summary>
        /// <value>作成日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了調整日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_AdjustDate
        {
            get { return _ed_AdjustDate; }
            set { _ed_AdjustDate = value; }
        }

        /// public propaty name  :  St_StockAdjustSlipNo
        /// <summary>開始在庫調整伝票番号プロパティ</summary>
        /// <value>伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始在庫調整伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_StockAdjustSlipNo
        {
            get { return _st_StockAdjustSlipNo; }
            set { _st_StockAdjustSlipNo = value; }
        }

        /// public propaty name  :  Ed_StockAdjustSlipNo
        /// <summary>終了在庫調整伝票番号プロパティ</summary>
        /// <value>伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了在庫調整伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_StockAdjustSlipNo
        {
            get { return _ed_StockAdjustSlipNo; }
            set { _ed_StockAdjustSlipNo = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// <value>担当者</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
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

        /// public propaty name  :  GoodsNoTyp
        /// <summary>商品番号検索タイププロパティ</summary>
        /// <value>0:完全一致、1:前方一致、2:後方一致、3:あいまい</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoTyp
        {
            get { return _goodsNoTyp; }
            set { _goodsNoTyp = value; }
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

        /// public propaty name  :  GoodsNameTyp
        /// <summary>商品名称検索タイププロパティ</summary>
        /// <value>0:完全一致、1:前方一致、2:後方一致、3:あいまい</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNameTyp
        {
            get { return _goodsNameTyp; }
            set { _goodsNameTyp = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  WarehouseShelfNoTyp
        /// <summary>倉庫棚番検索タイププロパティ</summary>
        /// <value>0:完全一致、1:前方一致、2:後方一致、3:あいまい</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WarehouseShelfNoTyp
        {
            get { return _warehouseShelfNoTyp; }
            set { _warehouseShelfNoTyp = value; }
        }


        /// <summary>
        /// 在庫仕入伝票照会抽出条件ワークワークコンストラクタ
        /// </summary>
        /// <returns>StockAdjRefSearchParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjRefSearchParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockAdjRefSearchParaWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockAdjRefSearchParaWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockAdjRefSearchParaWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockAdjRefSearchParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjRefSearchParaWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  StockAdjRefSearchParaWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is StockAdjRefSearchParaWork || graph is ArrayList || graph is StockAdjRefSearchParaWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( StockAdjRefSearchParaWork ).FullName ) );

            if ( graph != null && graph is StockAdjRefSearchParaWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockAdjRefSearchParaWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is StockAdjRefSearchParaWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockAdjRefSearchParaWork[])graph).Length;
            }
            else if ( graph is StockAdjRefSearchParaWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add( typeof( string ) ); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
            //倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
            //受払元伝票区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcPaySlipCd
            //受払元取引区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcPayTransCd
            //開始入力日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //St_InputDay
            //終了入力日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //Ed_InputDay
            //開始調整日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //St_AdjustDate
            //終了調整日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //Ed_AdjustDate
            //開始在庫調整伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //St_StockAdjustSlipNo
            //終了在庫調整伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //Ed_StockAdjustSlipNo
            //仕入担当者コード
            serInfo.MemberInfo.Add( typeof( string ) ); //StockAgentCode
            //商品メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsNo
            //商品番号検索タイプ
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsNoTyp
            //商品名称
            serInfo.MemberInfo.Add( typeof( string ) ); //GoodsName
            //商品名称検索タイプ
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodsNameTyp
            //倉庫棚番
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseShelfNo
            //倉庫棚番検索タイプ
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //WarehouseShelfNoTyp


            serInfo.Serialize( writer, serInfo );
            if ( graph is StockAdjRefSearchParaWork )
            {
                StockAdjRefSearchParaWork temp = (StockAdjRefSearchParaWork)graph;

                SetStockAdjRefSearchParaWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is StockAdjRefSearchParaWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (StockAdjRefSearchParaWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( StockAdjRefSearchParaWork temp in lst )
                {
                    SetStockAdjRefSearchParaWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// StockAdjRefSearchParaWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 19;

        /// <summary>
        ///  StockAdjRefSearchParaWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjRefSearchParaWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockAdjRefSearchParaWork( System.IO.BinaryWriter writer, StockAdjRefSearchParaWork temp )
        {
            //企業コード
            writer.Write( temp.EnterpriseCode );
            //拠点コード
            writer.Write( temp.SectionCode );
            //倉庫コード
            writer.Write( temp.WarehouseCode );
            //受払元伝票区分
            writer.Write( temp.AcPaySlipCd );
            //受払元取引区分
            writer.Write( temp.AcPayTransCd );
            //開始入力日付
            writer.Write( temp.St_InputDay );
            //終了入力日付
            writer.Write( temp.Ed_InputDay );
            //開始調整日付
            writer.Write( temp.St_AdjustDate );
            //終了調整日付
            writer.Write( temp.Ed_AdjustDate );
            //開始在庫調整伝票番号
            writer.Write( temp.St_StockAdjustSlipNo );
            //終了在庫調整伝票番号
            writer.Write( temp.Ed_StockAdjustSlipNo );
            //仕入担当者コード
            writer.Write( temp.StockAgentCode );
            //商品メーカーコード
            writer.Write( temp.GoodsMakerCd );
            //商品番号
            writer.Write( temp.GoodsNo );
            //商品番号検索タイプ
            writer.Write( temp.GoodsNoTyp );
            //商品名称
            writer.Write( temp.GoodsName );
            //商品名称検索タイプ
            writer.Write( temp.GoodsNameTyp );
            //倉庫棚番
            writer.Write( temp.WarehouseShelfNo );
            //倉庫棚番検索タイプ
            writer.Write( temp.WarehouseShelfNoTyp );

        }

        /// <summary>
        ///  StockAdjRefSearchParaWorkインスタンス取得
        /// </summary>
        /// <returns>StockAdjRefSearchParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjRefSearchParaWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockAdjRefSearchParaWork GetStockAdjRefSearchParaWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockAdjRefSearchParaWork temp = new StockAdjRefSearchParaWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //受払元伝票区分
            temp.AcPaySlipCd = reader.ReadInt32();
            //受払元取引区分
            temp.AcPayTransCd = reader.ReadInt32();
            //開始入力日付
            temp.St_InputDay = reader.ReadInt32();
            //終了入力日付
            temp.Ed_InputDay = reader.ReadInt32();
            //開始調整日付
            temp.St_AdjustDate = reader.ReadInt32();
            //終了調整日付
            temp.Ed_AdjustDate = reader.ReadInt32();
            //開始在庫調整伝票番号
            temp.St_StockAdjustSlipNo = reader.ReadInt32();
            //終了在庫調整伝票番号
            temp.Ed_StockAdjustSlipNo = reader.ReadInt32();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品番号検索タイプ
            temp.GoodsNoTyp = reader.ReadInt32();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品名称検索タイプ
            temp.GoodsNameTyp = reader.ReadInt32();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //倉庫棚番検索タイプ
            temp.WarehouseShelfNoTyp = reader.ReadInt32();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if ( oMemberType is Type )
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
                    if ( t.Equals( typeof( int ) ) )
                    {
                        optCount = Convert.ToInt32( oData );
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if ( oMemberType is string )
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
        /// <returns>StockAdjRefSearchParaWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjRefSearchParaWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                StockAdjRefSearchParaWork temp = GetStockAdjRefSearchParaWork( reader, serInfo );
                lst.Add( temp );
            }
            switch ( serInfo.RetTypeInfo )
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (StockAdjRefSearchParaWork[])lst.ToArray( typeof( StockAdjRefSearchParaWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

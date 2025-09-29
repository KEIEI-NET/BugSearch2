using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockAdjRefSearchRetWork
    /// <summary>
    ///                      在庫仕入伝票照会抽出結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫仕入伝票照会抽出結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/08/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockAdjRefSearchRetWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用　拠点名称</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>受払元伝票区分</summary>
        /// <remarks>10:仕入,11:受託,12:受計上,13:在庫仕入,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>受払元取引区分</summary>
        /// <remarks>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除,30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消</remarks>
        private Int32 _acPayTransCd;

        /// <summary>入力日付</summary>
        /// <remarks>入力日</remarks>
        private DateTime _inputDay;

        /// <summary>調整日付</summary>
        /// <remarks>作成日</remarks>
        private DateTime _adjustDate;

        /// <summary>在庫調整伝票番号</summary>
        /// <remarks>伝票番号</remarks>
        private Int32 _stockAdjustSlipNo;

        /// <summary>仕入担当者コード</summary>
        /// <remarks>担当者</remarks>
        private string _stockAgentCode = "";

        /// <summary>仕入担当者名称</summary>
        /// <remarks>担当者</remarks>
        private string _stockAgentName = "";

        /// <summary>仕入金額小計</summary>
        private Int64 _stockSubttlPrice;

        /// <summary>伝票備考</summary>
        private string _slipNote = "";


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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用　拠点名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
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

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
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

        /// public propaty name  :  InputDay
        /// <summary>入力日付プロパティ</summary>
        /// <value>入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  AdjustDate
        /// <summary>調整日付プロパティ</summary>
        /// <value>作成日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   調整日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AdjustDate
        {
            get { return _adjustDate; }
            set { _adjustDate = value; }
        }

        /// public propaty name  :  StockAdjustSlipNo
        /// <summary>在庫調整伝票番号プロパティ</summary>
        /// <value>伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫調整伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockAdjustSlipNo
        {
            get { return _stockAdjustSlipNo; }
            set { _stockAdjustSlipNo = value; }
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

        /// public propaty name  :  StockAgentName
        /// <summary>仕入担当者名称プロパティ</summary>
        /// <value>担当者</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  StockSubttlPrice
        /// <summary>仕入金額小計プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額小計プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockSubttlPrice
        {
            get { return _stockSubttlPrice; }
            set { _stockSubttlPrice = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>伝票備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }


        /// <summary>
        /// 在庫仕入伝票照会抽出結果ワークワークコンストラクタ
        /// </summary>
        /// <returns>StockAdjRefSearchRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjRefSearchRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockAdjRefSearchRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockAdjRefSearchRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockAdjRefSearchRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockAdjRefSearchRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjRefSearchRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  StockAdjRefSearchRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is StockAdjRefSearchRetWork || graph is ArrayList || graph is StockAdjRefSearchRetWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( StockAdjRefSearchRetWork ).FullName ) );

            if ( graph != null && graph is StockAdjRefSearchRetWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockAdjRefSearchRetWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is StockAdjRefSearchRetWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockAdjRefSearchRetWork[])graph).Length;
            }
            else if ( graph is StockAdjRefSearchRetWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add( typeof( string ) ); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionGuideSnm
            //倉庫コード
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add( typeof( string ) ); //WarehouseName
            //受払元伝票区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcPaySlipCd
            //受払元取引区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AcPayTransCd
            //入力日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //InputDay
            //調整日付
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //AdjustDate
            //在庫調整伝票番号
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StockAdjustSlipNo
            //仕入担当者コード
            serInfo.MemberInfo.Add( typeof( string ) ); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add( typeof( string ) ); //StockAgentName
            //仕入金額小計
            serInfo.MemberInfo.Add( typeof( Int64 ) ); //StockSubttlPrice
            //伝票備考
            serInfo.MemberInfo.Add( typeof( string ) ); //SlipNote


            serInfo.Serialize( writer, serInfo );
            if ( graph is StockAdjRefSearchRetWork )
            {
                StockAdjRefSearchRetWork temp = (StockAdjRefSearchRetWork)graph;

                SetStockAdjRefSearchRetWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is StockAdjRefSearchRetWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (StockAdjRefSearchRetWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( StockAdjRefSearchRetWork temp in lst )
                {
                    SetStockAdjRefSearchRetWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// StockAdjRefSearchRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 14;

        /// <summary>
        ///  StockAdjRefSearchRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjRefSearchRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockAdjRefSearchRetWork( System.IO.BinaryWriter writer, StockAdjRefSearchRetWork temp )
        {
            //企業コード
            writer.Write( temp.EnterpriseCode );
            //拠点コード
            writer.Write( temp.SectionCode );
            //拠点ガイド略称
            writer.Write( temp.SectionGuideSnm );
            //倉庫コード
            writer.Write( temp.WarehouseCode );
            //倉庫名称
            writer.Write( temp.WarehouseName );
            //受払元伝票区分
            writer.Write( temp.AcPaySlipCd );
            //受払元取引区分
            writer.Write( temp.AcPayTransCd );
            //入力日付
            writer.Write( (Int64)temp.InputDay.Ticks );
            //調整日付
            writer.Write( (Int64)temp.AdjustDate.Ticks );
            //在庫調整伝票番号
            writer.Write( temp.StockAdjustSlipNo );
            //仕入担当者コード
            writer.Write( temp.StockAgentCode );
            //仕入担当者名称
            writer.Write( temp.StockAgentName );
            //仕入金額小計
            writer.Write( temp.StockSubttlPrice );
            //伝票備考
            writer.Write( temp.SlipNote );

        }

        /// <summary>
        ///  StockAdjRefSearchRetWorkインスタンス取得
        /// </summary>
        /// <returns>StockAdjRefSearchRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjRefSearchRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockAdjRefSearchRetWork GetStockAdjRefSearchRetWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockAdjRefSearchRetWork temp = new StockAdjRefSearchRetWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //受払元伝票区分
            temp.AcPaySlipCd = reader.ReadInt32();
            //受払元取引区分
            temp.AcPayTransCd = reader.ReadInt32();
            //入力日付
            temp.InputDay = new DateTime( reader.ReadInt64() );
            //調整日付
            temp.AdjustDate = new DateTime( reader.ReadInt64() );
            //在庫調整伝票番号
            temp.StockAdjustSlipNo = reader.ReadInt32();
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            //仕入金額小計
            temp.StockSubttlPrice = reader.ReadInt64();
            //伝票備考
            temp.SlipNote = reader.ReadString();


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
        /// <returns>StockAdjRefSearchRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjRefSearchRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                StockAdjRefSearchRetWork temp = GetStockAdjRefSearchRetWork( reader, serInfo );
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
                    retValue = (StockAdjRefSearchRetWork[])lst.ToArray( typeof( StockAdjRefSearchRetWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

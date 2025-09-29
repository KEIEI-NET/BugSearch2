using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region // DEL
    ///// public class name:   TtlDayCalcRetWork
    ///// <summary>
    /////                      締日算出抽出結果ワークワーク
    ///// </summary>
    ///// <remarks>
    ///// <br>note             :   締日算出抽出結果ワークワークヘッダファイル</br>
    ///// <br>Programmer       :   自動生成</br>
    ///// <br>Date             :   2008/3/25</br>
    ///// <br>Genarated Date   :   2008/08/11  (CSharp File Generated Date)</br>
    ///// <br>Update Note      :   </br>
    ///// </remarks>
    //[Serializable]
    //[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    //public class TtlDayCalcRetWork
    //{
    //    /// <summary>企業コード</summary>
    //    /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
    //    private string _enterpriseCode = "";

    //    /// <summary>処理区分</summary>
    //    /// <remarks>０：請求売掛 １：支払買掛</remarks>
    //    private Int32 _procDiv;

    //    /// <summary>拠点コード</summary>
    //    private string _sectionCode = "";

    //    /// <summary>得意先コード</summary>
    //    private Int32 _customerCode;

    //    /// <summary>仕入先コード</summary>
    //    private Int32 _supplierCd;

    //    /// <summary>締日</summary>
    //    /// <remarks>"YYYYMMDD"</remarks>
    //    private Int32 _totalDay;

    //    /// <summary>コンバート処理区分</summary>
    //    /// <remarks>0:通常　1:コンバートデータ　（←有効値は【履歴】抽出のみ）</remarks>
    //    private Int32 _convertProcessDivCd;


    //    /// public propaty name  :  EnterpriseCode
    //    /// <summary>企業コードプロパティ</summary>
    //    /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   企業コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string EnterpriseCode
    //    {
    //        get { return _enterpriseCode; }
    //        set { _enterpriseCode = value; }
    //    }

    //    /// public propaty name  :  ProcDiv
    //    /// <summary>処理区分プロパティ</summary>
    //    /// <value>０：請求売掛 １：支払買掛</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   処理区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ProcDiv
    //    {
    //        get { return _procDiv; }
    //        set { _procDiv = value; }
    //    }

    //    /// public propaty name  :  SectionCode
    //    /// <summary>拠点コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   拠点コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public string SectionCode
    //    {
    //        get { return _sectionCode; }
    //        set { _sectionCode = value; }
    //    }

    //    /// public propaty name  :  CustomerCode
    //    /// <summary>得意先コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   得意先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 CustomerCode
    //    {
    //        get { return _customerCode; }
    //        set { _customerCode = value; }
    //    }

    //    /// public propaty name  :  SupplierCd
    //    /// <summary>仕入先コードプロパティ</summary>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   仕入先コードプロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 SupplierCd
    //    {
    //        get { return _supplierCd; }
    //        set { _supplierCd = value; }
    //    }

    //    /// public propaty name  :  TotalDay
    //    /// <summary>締日プロパティ</summary>
    //    /// <value>"YYYYMMDD"</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   締日プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 TotalDay
    //    {
    //        get { return _totalDay; }
    //        set { _totalDay = value; }
    //    }

    //    /// public propaty name  :  ConvertProcessDivCd
    //    /// <summary>コンバート処理区分プロパティ</summary>
    //    /// <value>0:通常　1:コンバートデータ　（←有効値は【履歴】抽出のみ）</value>
    //    /// ----------------------------------------------------------------------
    //    /// <remarks>
    //    /// <br>note             :   コンバート処理区分プロパティ</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public Int32 ConvertProcessDivCd
    //    {
    //        get { return _convertProcessDivCd; }
    //        set { _convertProcessDivCd = value; }
    //    }


    //    /// <summary>
    //    /// 締日算出抽出結果ワークワークコンストラクタ
    //    /// </summary>
    //    /// <returns>TtlDayCalcRetWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   TtlDayCalcRetWorkクラスの新しいインスタンスを生成します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public TtlDayCalcRetWork()
    //    {
    //    }

    //}

    ///// <summary>
    /////  Ver5.10.1.0用のカスタムシライアライザです。
    ///// </summary>
    ///// <returns>TtlDayCalcRetWorkクラスのインスタンス(object)</returns>
    ///// <remarks>
    ///// <br>Note　　　　　　 :   TtlDayCalcRetWorkクラスのカスタムシリアライザを定義します</br>
    ///// <br>Programer        :   自動生成</br>
    ///// </remarks>
    //public class TtlDayCalcRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    //{
    //    #region ICustomSerializationSurrogate メンバ

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムシリアライザです
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   TtlDayCalcRetWorkクラスのカスタムシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public void Serialize( System.IO.BinaryWriter writer, object graph )
    //    {
    //        // TODO:  TtlDayCalcRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
    //        if ( writer == null )
    //            throw new ArgumentNullException();

    //        if ( graph != null && !(graph is TtlDayCalcRetWork || graph is ArrayList || graph is TtlDayCalcRetWork[]) )
    //            throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( TtlDayCalcRetWork ).FullName ) );

    //        if ( graph != null && graph is TtlDayCalcRetWork )
    //        {
    //            Type t = graph.GetType();
    //            if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
    //                throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
    //        }

    //        //SerializationTypeInfo
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TtlDayCalcRetWork" );

    //        //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
    //        int occurrence = 0;     //一般にゼロの場合もありえます
    //        if ( graph is ArrayList )
    //        {
    //            serInfo.RetTypeInfo = 0;
    //            occurrence = ((ArrayList)graph).Count;
    //        }
    //        else if ( graph is TtlDayCalcRetWork[] )
    //        {
    //            serInfo.RetTypeInfo = 2;
    //            occurrence = ((TtlDayCalcRetWork[])graph).Length;
    //        }
    //        else if ( graph is TtlDayCalcRetWork )
    //        {
    //            serInfo.RetTypeInfo = 1;
    //            occurrence = 1;
    //        }

    //        serInfo.Occurrence = occurrence;		 //繰り返し数	

    //        //企業コード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //EnterpriseCode
    //        //処理区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //ProcDiv
    //        //拠点コード
    //        serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
    //        //得意先コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
    //        //仕入先コード
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
    //        //締日
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //TotalDay
    //        //コンバート処理区分
    //        serInfo.MemberInfo.Add( typeof( Int32 ) ); //ConvertProcessDivCd


    //        serInfo.Serialize( writer, serInfo );
    //        if ( graph is TtlDayCalcRetWork )
    //        {
    //            TtlDayCalcRetWork temp = (TtlDayCalcRetWork)graph;

    //            SetTtlDayCalcRetWork( writer, temp );
    //        }
    //        else
    //        {
    //            ArrayList lst = null;
    //            if ( graph is TtlDayCalcRetWork[] )
    //            {
    //                lst = new ArrayList();
    //                lst.AddRange( (TtlDayCalcRetWork[])graph );
    //            }
    //            else
    //            {
    //                lst = (ArrayList)graph;
    //            }

    //            foreach ( TtlDayCalcRetWork temp in lst )
    //            {
    //                SetTtlDayCalcRetWork( writer, temp );
    //            }

    //        }


    //    }


    //    /// <summary>
    //    /// TtlDayCalcRetWorkメンバ数(publicプロパティ数)
    //    /// </summary>
    //    private const int currentMemberCount = 7;

    //    /// <summary>
    //    ///  TtlDayCalcRetWorkインスタンス書き込み
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   TtlDayCalcRetWorkのインスタンスを書き込み</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private void SetTtlDayCalcRetWork( System.IO.BinaryWriter writer, TtlDayCalcRetWork temp )
    //    {
    //        //企業コード
    //        writer.Write( temp.EnterpriseCode );
    //        //処理区分
    //        writer.Write( temp.ProcDiv );
    //        //拠点コード
    //        writer.Write( temp.SectionCode );
    //        //得意先コード
    //        writer.Write( temp.CustomerCode );
    //        //仕入先コード
    //        writer.Write( temp.SupplierCd );
    //        //締日
    //        writer.Write( temp.TotalDay );
    //        //コンバート処理区分
    //        writer.Write( temp.ConvertProcessDivCd );

    //    }

    //    /// <summary>
    //    ///  TtlDayCalcRetWorkインスタンス取得
    //    /// </summary>
    //    /// <returns>TtlDayCalcRetWorkクラスのインスタンス</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   TtlDayCalcRetWorkのインスタンスを取得します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    private TtlDayCalcRetWork GetTtlDayCalcRetWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
    //    {
    //        // V5.1.0.0なので不要ですが、V5.1.0.1以降では
    //        // serInfo.MemberInfo.Count < currentMemberCount
    //        // のケースについての配慮が必要になります。

    //        TtlDayCalcRetWork temp = new TtlDayCalcRetWork();

    //        //企業コード
    //        temp.EnterpriseCode = reader.ReadString();
    //        //処理区分
    //        temp.ProcDiv = reader.ReadInt32();
    //        //拠点コード
    //        temp.SectionCode = reader.ReadString();
    //        //得意先コード
    //        temp.CustomerCode = reader.ReadInt32();
    //        //仕入先コード
    //        temp.SupplierCd = reader.ReadInt32();
    //        //締日
    //        temp.TotalDay = reader.ReadInt32();
    //        //コンバート処理区分
    //        temp.ConvertProcessDivCd = reader.ReadInt32();


    //        //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
    //        //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
    //        //型情報にしたがって、ストリームから情報を読み出します...といっても
    //        //読み出して捨てることになります。
    //        for ( int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k )
    //        {
    //            //byte[],char[]をデシリアライズする直前に、そのlengthが
    //            //デシリアライズされているケースがある、byte[],char[]の
    //            //デシリアライズにはlengthが必要なのでint型のデータをデ
    //            //シリアライズした場合は、この値をこの変数に退避します。
    //            int optCount = 0;
    //            object oMemberType = serInfo.MemberInfo[k];
    //            if ( oMemberType is Type )
    //            {
    //                Type t = (Type)oMemberType;
    //                object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
    //                if ( t.Equals( typeof( int ) ) )
    //                {
    //                    optCount = Convert.ToInt32( oData );
    //                }
    //                else
    //                {
    //                    optCount = 0;
    //                }
    //            }
    //            else if ( oMemberType is string )
    //            {
    //                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
    //                object userData = formatter.Deserialize( reader );  //読み飛ばし
    //            }
    //        }
    //        return temp;
    //    }

    //    /// <summary>
    //    ///  Ver5.10.1.0用のカスタムデシリアライザです
    //    /// </summary>
    //    /// <returns>TtlDayCalcRetWorkクラスのインスタンス(object)</returns>
    //    /// <remarks>
    //    /// <br>Note　　　　　　 :   TtlDayCalcRetWorkクラスのカスタムデシリアライザを定義します</br>
    //    /// <br>Programer        :   自動生成</br>
    //    /// </remarks>
    //    public object Deserialize( System.IO.BinaryReader reader )
    //    {
    //        object retValue = null;
    //        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
    //        ArrayList lst = new ArrayList();
    //        for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
    //        {
    //            TtlDayCalcRetWork temp = GetTtlDayCalcRetWork( reader, serInfo );
    //            lst.Add( temp );
    //        }
    //        switch ( serInfo.RetTypeInfo )
    //        {
    //            case 0:
    //                retValue = lst;
    //                break;
    //            case 1:
    //                retValue = lst[0];
    //                break;
    //            case 2:
    //                retValue = (TtlDayCalcRetWork[])lst.ToArray( typeof( TtlDayCalcRetWork ) );
    //                break;
    //        }
    //        return retValue;
    //    }

    //    #endregion
    //}
    # endregion

    /// public class name:   TtlDayCalcRetWork
    /// <summary>
    ///                      締日算出抽出結果ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   締日算出抽出結果ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/05/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TtlDayCalcRetWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>処理区分</summary>
        /// <remarks>０：請求売掛 １：支払買掛</remarks>
        private Int32 _procDiv;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>締日</summary>
        /// <remarks>"YYYYMMDD"</remarks>
        private Int32 _totalDay;

        /// <summary>コンバート処理区分</summary>
        /// <remarks>0:通常　1:コンバートデータ　（←有効値は【履歴】抽出のみ）</remarks>
        private Int32 _convertProcessDivCd;

        /// <summary>締次更新開始年月日</summary>
        /// <remarks>"YYYYMMDD"  締次更新対象となる開始年月日</remarks>
        private DateTime _startCAddUpUpdDate;


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

        /// public propaty name  :  ProcDiv
        /// <summary>処理区分プロパティ</summary>
        /// <value>０：請求売掛 １：支払買掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日プロパティ</summary>
        /// <value>"YYYYMMDD"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  ConvertProcessDivCd
        /// <summary>コンバート処理区分プロパティ</summary>
        /// <value>0:通常　1:コンバートデータ　（←有効値は【履歴】抽出のみ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コンバート処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConvertProcessDivCd
        {
            get { return _convertProcessDivCd; }
            set { _convertProcessDivCd = value; }
        }

        /// public propaty name  :  StartCAddUpUpdDate
        /// <summary>締次更新開始年月日プロパティ</summary>
        /// <value>"YYYYMMDD"  締次更新対象となる開始年月日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締次更新開始年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StartCAddUpUpdDate
        {
            get { return _startCAddUpUpdDate; }
            set { _startCAddUpUpdDate = value; }
        }


        /// <summary>
        /// 締日算出抽出結果ワークワークコンストラクタ
        /// </summary>
        /// <returns>TtlDayCalcRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TtlDayCalcRetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TtlDayCalcRetWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TtlDayCalcRetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TtlDayCalcRetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TtlDayCalcRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TtlDayCalcRetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  TtlDayCalcRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if ( writer == null )
                throw new ArgumentNullException();

            if ( graph != null && !(graph is TtlDayCalcRetWork || graph is ArrayList || graph is TtlDayCalcRetWork[]) )
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( TtlDayCalcRetWork ).FullName ) );

            if ( graph != null && graph is TtlDayCalcRetWork )
            {
                Type t = graph.GetType();
                if ( !CustomFormatterServices.NeedCustomSerialization( t ) )
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TtlDayCalcRetWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if ( graph is ArrayList )
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if ( graph is TtlDayCalcRetWork[] )
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TtlDayCalcRetWork[])graph).Length;
            }
            else if ( graph is TtlDayCalcRetWork )
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add( typeof( string ) ); //EnterpriseCode
            //処理区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ProcDiv
            //拠点コード
            serInfo.MemberInfo.Add( typeof( string ) ); //SectionCode
            //得意先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //CustomerCode
            //仕入先コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //SupplierCd
            //締日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //TotalDay
            //コンバート処理区分
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //ConvertProcessDivCd
            //締次更新開始年月日
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //StartCAddUpUpdDate


            serInfo.Serialize( writer, serInfo );
            if ( graph is TtlDayCalcRetWork )
            {
                TtlDayCalcRetWork temp = (TtlDayCalcRetWork)graph;

                SetTtlDayCalcRetWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if ( graph is TtlDayCalcRetWork[] )
                {
                    lst = new ArrayList();
                    lst.AddRange( (TtlDayCalcRetWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach ( TtlDayCalcRetWork temp in lst )
                {
                    SetTtlDayCalcRetWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// TtlDayCalcRetWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 8;

        /// <summary>
        ///  TtlDayCalcRetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TtlDayCalcRetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetTtlDayCalcRetWork( System.IO.BinaryWriter writer, TtlDayCalcRetWork temp )
        {
            //企業コード
            writer.Write( temp.EnterpriseCode );
            //処理区分
            writer.Write( temp.ProcDiv );
            //拠点コード
            writer.Write( temp.SectionCode );
            //得意先コード
            writer.Write( temp.CustomerCode );
            //仕入先コード
            writer.Write( temp.SupplierCd );
            //締日
            writer.Write( temp.TotalDay );
            //コンバート処理区分
            writer.Write( temp.ConvertProcessDivCd );
            //締次更新開始年月日
            writer.Write( (Int64)temp.StartCAddUpUpdDate.Ticks );

        }

        /// <summary>
        ///  TtlDayCalcRetWorkインスタンス取得
        /// </summary>
        /// <returns>TtlDayCalcRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TtlDayCalcRetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private TtlDayCalcRetWork GetTtlDayCalcRetWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TtlDayCalcRetWork temp = new TtlDayCalcRetWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //処理区分
            temp.ProcDiv = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //締日
            temp.TotalDay = reader.ReadInt32();
            //コンバート処理区分
            temp.ConvertProcessDivCd = reader.ReadInt32();
            //締次更新開始年月日
            temp.StartCAddUpUpdDate = new DateTime( reader.ReadInt64() );


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
        /// <returns>TtlDayCalcRetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TtlDayCalcRetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt )
            {
                TtlDayCalcRetWork temp = GetTtlDayCalcRetWork( reader, serInfo );
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
                    retValue = (TtlDayCalcRetWork[])lst.ToArray( typeof( TtlDayCalcRetWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

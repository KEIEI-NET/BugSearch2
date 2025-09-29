//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良部品バーコード情報抽出リモート
// プログラム概要   : 優良部品バーコード情報抽出条件パラメータワーク
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
    /// public class name:   GetPrmPartsBrcdParaWork
    /// <summary>
    ///                      優良部品バーコード情報抽出条件パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良部品バーコード情報抽出条件パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/09/20</br>
    /// <br>Genarated Date   :   2017/09/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GetPrmPartsBrcdParaWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>メーカーコード</summary>
        private Int32 _makerCode;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;


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

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
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


        /// <summary>
        /// 優良部品バーコード情報抽出条件パラメータワークコンストラクタ
        /// </summary>
        /// <returns>GetPrmPartsBrcdParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetPrmPartsBrcdParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GetPrmPartsBrcdParaWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GetPrmPartsBrcdParaWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GetPrmPartsBrcdParaWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class GetPrmPartsBrcdParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetPrmPartsBrcdParaWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  GetPrmPartsBrcdParaWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !( graph is GetPrmPartsBrcdParaWork || graph is ArrayList || graph is GetPrmPartsBrcdParaWork[] ))
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( GetPrmPartsBrcdParaWork ).FullName ) );

            if (graph != null && graph is GetPrmPartsBrcdParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization( t ))
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GetPrmPartsBrcdParaWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ( (ArrayList)graph ).Count;
            }
            else if (graph is GetPrmPartsBrcdParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ( (GetPrmPartsBrcdParaWork[])graph ).Length;
            }
            else if (graph is GetPrmPartsBrcdParaWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add( typeof( string ) ); //EnterpriseCode
            //メーカーコード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCode
            //BL商品コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode


            serInfo.Serialize( writer, serInfo );
            if (graph is GetPrmPartsBrcdParaWork)
            {
                GetPrmPartsBrcdParaWork temp = (GetPrmPartsBrcdParaWork)graph;

                SetGetPrmPartsBrcdParaWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if (graph is GetPrmPartsBrcdParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange( (GetPrmPartsBrcdParaWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GetPrmPartsBrcdParaWork temp in lst)
                {
                    SetGetPrmPartsBrcdParaWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// GetPrmPartsBrcdParaWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 3;

        /// <summary>
        ///  GetPrmPartsBrcdParaWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetPrmPartsBrcdParaWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGetPrmPartsBrcdParaWork( System.IO.BinaryWriter writer, GetPrmPartsBrcdParaWork temp )
        {
            //企業コード
            writer.Write( temp.EnterpriseCode );
            //メーカーコード
            writer.Write( temp.MakerCode );
            //BL商品コード
            writer.Write( temp.BLGoodsCode );

        }

        /// <summary>
        ///  GetPrmPartsBrcdParaWorkインスタンス取得
        /// </summary>
        /// <returns>GetPrmPartsBrcdParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetPrmPartsBrcdParaWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private GetPrmPartsBrcdParaWork GetGetPrmPartsBrcdParaWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            GetPrmPartsBrcdParaWork temp = new GetPrmPartsBrcdParaWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();


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
        /// <returns>GetPrmPartsBrcdParaWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetPrmPartsBrcdParaWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GetPrmPartsBrcdParaWork temp = GetGetPrmPartsBrcdParaWork( reader, serInfo );
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
                    retValue = (GetPrmPartsBrcdParaWork[])lst.ToArray( typeof( GetPrmPartsBrcdParaWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

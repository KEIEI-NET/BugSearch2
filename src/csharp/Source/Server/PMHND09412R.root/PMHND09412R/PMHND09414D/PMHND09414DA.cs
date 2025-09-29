//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード更新リモート
// プログラム概要   : 優良設定検索条件パラメータワーク
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
    /// public class name:   PrmSetUParamForBrcdWork
    /// <summary>
    ///                      優良設定検索条件パラメータワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良設定検索条件パラメータワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/09/20</br>
    /// <br>Genarated Date   :   2017/09/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrmSetUParamForBrcdWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>メーカーコード（開始）</summary>
        private Int32 _makerCdST;

        /// <summary>メーカーコード（終了）</summary>
        private Int32 _makerCdED;

        /// <summary>商品中分類コード</summary>
        private Int32 _goodMGroup;

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

        /// public propaty name  :  MakerCdST
        /// <summary>メーカーコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCdST
        {
            get { return _makerCdST; }
            set { _makerCdST = value; }
        }

        /// public propaty name  :  MakerCdED
        /// <summary>メーカーコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCdED
        {
            get { return _makerCdED; }
            set { _makerCdED = value; }
        }

        /// public propaty name  :  GoodMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodMGroup
        {
            get { return _goodMGroup; }
            set { _goodMGroup = value; }
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
        /// 優良設定検索条件パラメータワークコンストラクタ
        /// </summary>
        /// <returns>PrmSetUParamForBrcdWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSetUParamForBrcdWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrmSetUParamForBrcdWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PrmSetUParamForBrcdWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PrmSetUParamForBrcdWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PrmSetUParamForBrcdWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSetUParamForBrcdWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize( System.IO.BinaryWriter writer, object graph )
        {
            // TODO:  PrmSetUParamForBrcdWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !( graph is PrmSetUParamForBrcdWork || graph is ArrayList || graph is PrmSetUParamForBrcdWork[] ))
                throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof( PrmSetUParamForBrcdWork ).FullName ) );

            if (graph != null && graph is PrmSetUParamForBrcdWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization( t ))
                    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmSetUParamForBrcdWork" );

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ( (ArrayList)graph ).Count;
            }
            else if (graph is PrmSetUParamForBrcdWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ( (PrmSetUParamForBrcdWork[])graph ).Length;
            }
            else if (graph is PrmSetUParamForBrcdWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add( typeof( string ) ); //EnterpriseCode
            //メーカーコード（開始）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCdST
            //メーカーコード（終了）
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //MakerCdED
            //商品中分類コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //GoodMGroup
            //BL商品コード
            serInfo.MemberInfo.Add( typeof( Int32 ) ); //BLGoodsCode


            serInfo.Serialize( writer, serInfo );
            if (graph is PrmSetUParamForBrcdWork)
            {
                PrmSetUParamForBrcdWork temp = (PrmSetUParamForBrcdWork)graph;

                SetPrmSetUParamForBrcdWork( writer, temp );
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmSetUParamForBrcdWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange( (PrmSetUParamForBrcdWork[])graph );
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmSetUParamForBrcdWork temp in lst)
                {
                    SetPrmSetUParamForBrcdWork( writer, temp );
                }

            }


        }


        /// <summary>
        /// PrmSetUParamForBrcdWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  PrmSetUParamForBrcdWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSetUParamForBrcdWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPrmSetUParamForBrcdWork( System.IO.BinaryWriter writer, PrmSetUParamForBrcdWork temp )
        {
            //企業コード
            writer.Write( temp.EnterpriseCode );
            //メーカーコード（開始）
            writer.Write( temp.MakerCdST );
            //メーカーコード（終了）
            writer.Write( temp.MakerCdED );
            //商品中分類コード
            writer.Write( temp.GoodMGroup );
            //BL商品コード
            writer.Write( temp.BLGoodsCode );

        }

        /// <summary>
        ///  PrmSetUParamForBrcdWorkインスタンス取得
        /// </summary>
        /// <returns>PrmSetUParamForBrcdWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSetUParamForBrcdWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PrmSetUParamForBrcdWork GetPrmSetUParamForBrcdWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PrmSetUParamForBrcdWork temp = new PrmSetUParamForBrcdWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //メーカーコード（開始）
            temp.MakerCdST = reader.ReadInt32();
            //メーカーコード（終了）
            temp.MakerCdED = reader.ReadInt32();
            //商品中分類コード
            temp.GoodMGroup = reader.ReadInt32();
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
        /// <returns>PrmSetUParamForBrcdWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmSetUParamForBrcdWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize( System.IO.BinaryReader reader )
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmSetUParamForBrcdWork temp = GetPrmSetUParamForBrcdWork( reader, serInfo );
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
                    retValue = (PrmSetUParamForBrcdWork[])lst.ToArray( typeof( PrmSetUParamForBrcdWork ) );
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
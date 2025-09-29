using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// 売上履歴データ用 共通関数
    /// </summary>
    public static class SalesHistTool
    {
        /// <summary>
        /// 文字を数値(Int64)に変換します、変換に失敗した場合はデフォルト値を返します。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="defaultvalue"></param>
        /// <returns></returns>
        public static Int64 StrToIntDef(string s, Int64 defaultvalue)
        {
            Int64 result = defaultvalue;

            try
            {
                result = Int64.Parse(s);
            }
            catch
            {

            }

            return result;
        }
    }

    /// public class name:   GetLastUnitPriceParamWork
    /// <summary>
    ///                      前回商品単価取得パラメータ(売上明細履歴)ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   前回商品単価取得パラメータ(売上明細履歴)ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GetLastUnitPriceParamWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";


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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
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


        /// <summary>
        /// 前回商品単価取得パラメータ(売上明細履歴)ワークコンストラクタ
        /// </summary>
        /// <returns>GetLastUnitPriceParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GetLastUnitPriceParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GetLastUnitPriceParamWork()
        {
        }
   }

   /// <summary>
   ///  Ver5.10.1.0用のカスタムシライアライザです。
   /// </summary>
   /// <returns>GetLastUnitPriceParamWorkクラスのインスタンス(object)</returns>
   /// <remarks>
   /// <br>Note　　　　　　 :   GetLastUnitPriceParamWorkクラスのカスタムシリアライザを定義します</br>
   /// <br>Programer        :   自動生成</br>
   /// </remarks>
   public class GetLastUnitPriceParamWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
   {
       #region ICustomSerializationSurrogate メンバ

       /// <summary>
       ///  Ver5.10.1.0用のカスタムシリアライザです
       /// </summary>
       /// <remarks>
       /// <br>Note　　　　　　 :   GetLastUnitPriceParamWorkクラスのカスタムシリアライザを定義します</br>
       /// <br>Programer        :   自動生成</br>
       /// </remarks>
       public void Serialize(System.IO.BinaryWriter writer, object graph)
       {
           // TODO:  GetLastUnitPriceParamWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
           if (writer == null)
               throw new ArgumentNullException();

           if (graph != null && !(graph is GetLastUnitPriceParamWork || graph is ArrayList || graph is GetLastUnitPriceParamWork[]))
               throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GetLastUnitPriceParamWork).FullName));

           if (graph != null && graph is GetLastUnitPriceParamWork)
           {
               Type t = graph.GetType();
               if (!CustomFormatterServices.NeedCustomSerialization(t))
                   throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
           }

           //SerializationTypeInfo
           Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GetLastUnitPriceParamWork");

           //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
           int occurrence = 0;     //一般にゼロの場合もありえます
           if (graph is ArrayList)
           {
               serInfo.RetTypeInfo = 0;
               occurrence = ((ArrayList)graph).Count;
           }
           else if (graph is GetLastUnitPriceParamWork[])
           {
               serInfo.RetTypeInfo = 2;
               occurrence = ((GetLastUnitPriceParamWork[])graph).Length;
           }
           else if (graph is GetLastUnitPriceParamWork)
           {
               serInfo.RetTypeInfo = 1;
               occurrence = 1;
           }

           serInfo.Occurrence = occurrence;		 //繰り返し数	

           //企業コード
           serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
           //得意先コード
           serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
           //商品メーカーコード
           serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
           //商品番号
           serInfo.MemberInfo.Add(typeof(string)); //GoodsNo


           serInfo.Serialize(writer, serInfo);
           if (graph is GetLastUnitPriceParamWork)
           {
               GetLastUnitPriceParamWork temp = (GetLastUnitPriceParamWork)graph;

               SetGetLastUnitPriceParamWork(writer, temp);
           }
           else
           {
               ArrayList lst = null;
               if (graph is GetLastUnitPriceParamWork[])
               {
                   lst = new ArrayList();
                   lst.AddRange((GetLastUnitPriceParamWork[])graph);
               }
               else
               {
                   lst = (ArrayList)graph;
               }

               foreach (GetLastUnitPriceParamWork temp in lst)
               {
                   SetGetLastUnitPriceParamWork(writer, temp);
               }

           }


       }


       /// <summary>
       /// GetLastUnitPriceParamWorkメンバ数(publicプロパティ数)
       /// </summary>
       private const int currentMemberCount = 4;

       /// <summary>
       ///  GetLastUnitPriceParamWorkインスタンス書き込み
       /// </summary>
       /// <remarks>
       /// <br>Note　　　　　　 :   GetLastUnitPriceParamWorkのインスタンスを書き込み</br>
       /// <br>Programer        :   自動生成</br>
       /// </remarks>
       private void SetGetLastUnitPriceParamWork(System.IO.BinaryWriter writer, GetLastUnitPriceParamWork temp)
       {
           //企業コード
           writer.Write(temp.EnterpriseCode);
           //得意先コード
           writer.Write(temp.CustomerCode);
           //商品メーカーコード
           writer.Write(temp.GoodsMakerCd);
           //商品番号
           writer.Write(temp.GoodsNo);

       }

       /// <summary>
       ///  GetLastUnitPriceParamWorkインスタンス取得
       /// </summary>
       /// <returns>GetLastUnitPriceParamWorkクラスのインスタンス</returns>
       /// <remarks>
       /// <br>Note　　　　　　 :   GetLastUnitPriceParamWorkのインスタンスを取得します</br>
       /// <br>Programer        :   自動生成</br>
       /// </remarks>
       private GetLastUnitPriceParamWork GetGetLastUnitPriceParamWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
       {
           // V5.1.0.0なので不要ですが、V5.1.0.1以降では
           // serInfo.MemberInfo.Count < currentMemberCount
           // のケースについての配慮が必要になります。

           GetLastUnitPriceParamWork temp = new GetLastUnitPriceParamWork();

           //企業コード
           temp.EnterpriseCode = reader.ReadString();
           //得意先コード
           temp.CustomerCode = reader.ReadInt32();
           //商品メーカーコード
           temp.GoodsMakerCd = reader.ReadInt32();
           //商品番号
           temp.GoodsNo = reader.ReadString();


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
       /// <returns>GetLastUnitPriceParamWorkクラスのインスタンス(object)</returns>
       /// <remarks>
       /// <br>Note　　　　　　 :   GetLastUnitPriceParamWorkクラスのカスタムデシリアライザを定義します</br>
       /// <br>Programer        :   自動生成</br>
       /// </remarks>
       public object Deserialize(System.IO.BinaryReader reader)
       {
           object retValue = null;
           Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
           ArrayList lst = new ArrayList();
           for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
           {
               GetLastUnitPriceParamWork temp = GetGetLastUnitPriceParamWork(reader, serInfo);
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
                   retValue = (GetLastUnitPriceParamWork[])lst.ToArray(typeof(GetLastUnitPriceParamWork));
                   break;
           }
           return retValue;
       }

       #endregion
   }
}
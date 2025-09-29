using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TbsPartsCdChgWork
    /// <summary>
    ///                      ＢＬコード変換ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ＢＬコード変換ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/5/18</br>
    /// <br>Genarated Date   :   2009/05/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TbsPartsCdChgWork 
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>SFバージョン</summary>
        /// <remarks>0,500,600など NSは"5.10.20.0"</remarks>
        private string _sfVersion = "";

        /// <summary>翼部品コード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>翼部品コード枝番</summary>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>変換後BLコード</summary>
        private Int32 _chgTbsPartsCode;

        /// <summary>変換後BLコード枝番</summary>
        private Int32 _chgTbsPartsCdDerivedNo;

        /// <summary>BLコード名称（全角）</summary>
        private string _tbsPartsFullName = "";

        /// <summary>BLコード名称（半角）</summary>
        private string _tbsPartsHalfName = "";


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

        /// public propaty name  :  SfVersion
        /// <summary>SFバージョンプロパティ</summary>
        /// <value>0,500,600など NSは"5.10.20.0"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SFバージョンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SfVersion
        {
            get { return _sfVersion; }
            set { _sfVersion = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>翼部品コードプロパティ</summary>
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

        /// public propaty name  :  ChgTbsPartsCode
        /// <summary>変換後BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChgTbsPartsCode
        {
            get { return _chgTbsPartsCode; }
            set { _chgTbsPartsCode = value; }
        }

        /// public propaty name  :  ChgTbsPartsCdDerivedNo
        /// <summary>変換後BLコード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後BLコード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChgTbsPartsCdDerivedNo
        {
            get { return _chgTbsPartsCdDerivedNo; }
            set { _chgTbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  TbsPartsFullName
        /// <summary>BLコード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TbsPartsFullName
        {
            get { return _tbsPartsFullName; }
            set { _tbsPartsFullName = value; }
        }

        /// public propaty name  :  TbsPartsHalfName
        /// <summary>BLコード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TbsPartsHalfName
        {
            get { return _tbsPartsHalfName; }
            set { _tbsPartsHalfName = value; }
        }


        /// <summary>
        /// ＢＬコード変換ワークコンストラクタ
        /// </summary>
        /// <returns>TbsPartsCdChgWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TbsPartsCdChgWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TbsPartsCdChgWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TbsPartsCdChgWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TbsPartsCdChgWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TbsPartsCdChgWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TbsPartsCdChgWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TbsPartsCdChgWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TbsPartsCdChgWork || graph is ArrayList || graph is TbsPartsCdChgWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TbsPartsCdChgWork).FullName));

            if (graph != null && graph is TbsPartsCdChgWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TbsPartsCdChgWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TbsPartsCdChgWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TbsPartsCdChgWork[])graph).Length;
            }
            else if (graph is TbsPartsCdChgWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //提供日付
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
            //SFバージョン
            serInfo.MemberInfo.Add(typeof(string)); //SfVersion
            //翼部品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //翼部品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //変換後BLコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ChgTbsPartsCode
            //変換後BLコード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //ChgTbsPartsCdDerivedNo
            //BLコード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //TbsPartsFullName
            //BLコード名称（半角）
            serInfo.MemberInfo.Add(typeof(string)); //TbsPartsHalfName


            serInfo.Serialize(writer, serInfo);
            if (graph is TbsPartsCdChgWork)
            {
                TbsPartsCdChgWork temp = (TbsPartsCdChgWork)graph;

                SetTbsPartsCdChgWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TbsPartsCdChgWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TbsPartsCdChgWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TbsPartsCdChgWork temp in lst)
                {
                    SetTbsPartsCdChgWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TbsPartsCdChgWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 8;

        /// <summary>
        ///  TbsPartsCdChgWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TbsPartsCdChgWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetTbsPartsCdChgWork(System.IO.BinaryWriter writer, TbsPartsCdChgWork temp)
        {
            //提供日付
            writer.Write((Int64)temp.OfferDate.Ticks);
            //SFバージョン
            writer.Write(temp.SfVersion);
            //翼部品コード
            writer.Write(temp.TbsPartsCode);
            //翼部品コード枝番
            writer.Write(temp.TbsPartsCdDerivedNo);
            //変換後BLコード
            writer.Write(temp.ChgTbsPartsCode);
            //変換後BLコード枝番
            writer.Write(temp.ChgTbsPartsCdDerivedNo);
            //BLコード名称（全角）
            writer.Write(temp.TbsPartsFullName);
            //BLコード名称（半角）
            writer.Write(temp.TbsPartsHalfName);

        }

        /// <summary>
        ///  TbsPartsCdChgWorkインスタンス取得
        /// </summary>
        /// <returns>TbsPartsCdChgWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TbsPartsCdChgWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private TbsPartsCdChgWork GetTbsPartsCdChgWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TbsPartsCdChgWork temp = new TbsPartsCdChgWork();

            //提供日付
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //SFバージョン
            temp.SfVersion = reader.ReadString();
            //翼部品コード
            temp.TbsPartsCode = reader.ReadInt32();
            //翼部品コード枝番
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //変換後BLコード
            temp.ChgTbsPartsCode = reader.ReadInt32();
            //変換後BLコード枝番
            temp.ChgTbsPartsCdDerivedNo = reader.ReadInt32();
            //BLコード名称（全角）
            temp.TbsPartsFullName = reader.ReadString();
            //BLコード名称（半角）
            temp.TbsPartsHalfName = reader.ReadString();


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
        /// <returns>TbsPartsCdChgWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TbsPartsCdChgWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TbsPartsCdChgWork temp = GetTbsPartsCdChgWork(reader, serInfo);
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
                    retValue = (TbsPartsCdChgWork[])lst.ToArray(typeof(TbsPartsCdChgWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
